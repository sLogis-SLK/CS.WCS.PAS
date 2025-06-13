using Infragistics.Win.UltraWinGrid;
using PAS.PMP.Models;
using PAS.PMP.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRPAS00021 : Form
    {
        #region 폼개체 선언부
        private DataTable m_분류_작업요약Table = new DataTable("usp_분류_작업요약_Get");
        private BindingSource m_분류_작업요약BS = new BindingSource();

        private Socket socket;

        #endregion

        #region 초기화

        public frmTRPAS00021()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetDataTableBindingInit();
        }

        #endregion

        #region 사용자정의함수

        private void SetDataTableBindingInit()
        {
            try
            {
                분류.배치리스트조회(m_분류_작업요약Table, Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd"), 0);


                this.m_분류_작업요약BS.DataSource = this.m_분류_작업요약Table;
                this.uGrid3.DataSource = this.m_분류_작업요약BS;

                Common.SetGridInit(this.uGrid3, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "실적수", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "관리번호", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "분류방법코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid3, null);

                this.uGrid3.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";

            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
        }

        private void 분류_임계치_조회(string s분류번호)
        {
            DataTable oDataTable = new DataTable("usp_분류_레코드수_Get");
            분류.임계치조회(oDataTable, s분류번호, GlobalClass.장비명);

            long 레코드총합 = 0;
            long 파일크기 = 0;
            long 파일줄수 = 0;

            if (oDataTable != null && oDataTable.Rows.Count > 0)
            {
                string 작업일자 = oDataTable.Rows[0]["작업일자"].ToString();
                string 작업월일 = (!string.IsNullOrEmpty(작업일자) && 작업일자.Length >= 8) ? 작업일자.Substring(4, 4) : DateTime.Now.ToString("MMdd");
                string 파일경로 = $"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{작업월일}\\{s분류번호}\\{작업일자}_{s분류번호}.DB";

                레코드총합 = Convert.ToInt64(oDataTable.Rows[0]["레코드총합"]);

                if (File.Exists(파일경로))
                {
                    파일크기 = new FileInfo(파일경로).Length;
                    파일줄수 = File.ReadAllLines(파일경로).LongLength;
                }
                게이지비교(레코드총합, 파일크기, 파일줄수);
            }
            else
            {
                this.ultraLinearGauge1.MaximumValue = 200000L;
                this.ultraLinearGauge1.Value = 0L;
            }
            this.임계치퍼센트.Text = this.ultraLinearGauge1.Value.ToString() + "%";
        }

        private void 게이지비교(long 레코드총합, long 파일크기, long 파일줄수)
        {
            var 기준목록 = new[]
            {
                new { Max = 200000L, Value = 레코드총합, Percent = 백분율계산(레코드총합, 200000L) },
                new { Max = 80000000L, Value = 파일크기, Percent = 백분율계산(파일크기, 80000000L) },
                new { Max = 100000L, Value = 파일줄수, Percent = 백분율계산(파일줄수, 100000L) }
            };

            var 최대 = 기준목록.OrderByDescending(k => k.Percent).First();
            게이지설정(최대.Max, 최대.Value);
        }

        private void 게이지설정(long maxValue, long value)
        {
            this.ultraLinearGauge1.MaximumValue = maxValue;
            this.ultraLinearGauge1.Value = value;
        }

        private int 백분율계산(long lValue, long lMaxValue)
        {
            return lMaxValue == 0 ? 0 : (int)((double)lValue / lMaxValue * 100.0);
        }

        private void 버튼제어(string 분류상태, string 배치상태)
        {
            bool 특정배치상태 = new HashSet<string> { "이관", "완료", "실적작성", "실적반영", "배치반영" }.Contains(배치상태);

            if (분류상태 == "개시")
            {
                this.배치개시버튼.Enabled = !특정배치상태 && 배치상태 != "작업중";
                this.배치종료버튼.Enabled = 배치상태 == "작업중";
                this.연속.Enabled = false;
                this.균등.Enabled = false;
            }
            else
            {
                this.배치개시버튼.Enabled = true;
                this.배치종료버튼.Enabled = false;
                this.연속.Enabled = true;
                this.균등.Enabled = true;
            }
        }

        private string 분류_작업요약_작업중인분류번호()
        {
            DataRow[] dataRowArray = this.m_분류_작업요약Table.Select("분류상태='개시'");
            return dataRowArray == null || dataRowArray.Length <= 0 ? string.Empty : dataRowArray[0]["분류번호"].ToString();
        }

        private bool Disconnection()
        {
            try
            {
                Thread.Sleep(1000);
                if (this.socket != null)
                {
                    this.socket.Close();
                    this.socket = (Socket)null;
                }
                return true;
            }
            catch (SocketException ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            return false;
        }

        private bool Connection()
        {
            try
            {
                if (!this.Disconnection())
                    return false;
                this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IAsyncResult asyncResult = this.socket.BeginConnect((EndPoint)new IPEndPoint(IPAddress.Parse(GlobalClass.SEIGYO_IP), Convert.ToInt32((object)GlobalClass.SEIGYO_PORT)), (AsyncCallback)null, (object)null);
                if (!asyncResult.AsyncWaitHandle.WaitOne(60000, false))
                    return false;
                this.socket.EndConnect(asyncResult);
                return true;
            }
            catch (SocketException ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            return false;
        }

        private 상태처리 SendReceive(string s배치번호, string s배치명, string s작업일자, 동작모드 e1, 분류방법 e2)
        {
            byte[] sendBytes = Encoding.Default.GetBytes(
                $"{(char)2}B{(char)e1}{GlobalClass.GetEmptyString(s배치번호, 8)}{GlobalClass.GetEmptyString(s배치명, 20)}{GlobalClass.GetEmptyString(s작업일자, 8)}{(char)e2}{(char)3}"
            );

            byte[] receiveBuffer = new byte[4096];

            try
            {
                this.socket.Send(sendBytes);
                IAsyncResult asyncResult = this.socket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, (AsyncCallback)null, (object)null);

                if (!asyncResult.AsyncWaitHandle.WaitOne(60000, false))
                    return 상태처리.FALSE;

                int count = socket.EndReceive(asyncResult);
                if (count <= 0)
                    return 상태처리.FALSE;

                byte[] response = new byte[count];
                Buffer.BlockCopy(receiveBuffer, 0, response, 0, count);

                if (response[0] != (byte)2 || response[1] != (byte)'B' || response[count - 1] != (byte)3 || (동작모드)response[2] != e1)
                    return 상태처리.FALSE;

                byte resultCode = response[3];

                if (e1 == 동작모드.개시)
                {
                    switch (resultCode)
                    {
                        case 48 /*0x30*/:
                        case 50:
                            return 상태처리.TRUE;
                        case 49:
                            Common.ErrorMessage(this.Text, "이미 개시중인 배치 입니다.");
                            return 상태처리.ERROR;
                        default:
                            //Common.Log((object)e1.ToString(), (object)"[SEND]", (object)Common.H2S(bytes), (object)DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            //Common.Log((object)e1.ToString(), (object)"[RECV]", (object)Common.H2S(numArray2), (object)DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            break;
                    }
                }
                else
                {
                    switch (resultCode)
                    {
                        case 48 /*0x30*/:
                        case 51:
                        case 52:
                            return 상태처리.TRUE;
                        case 49:
                            Common.ErrorMessage(this.Text, "아직 배치가 완료되지 않았습니다.\r\n\r\n컨베이어에 상품이 있는지 확인하세요.");
                            return 상태처리.ERROR;
                        default:
                            //Common.Log((object)e1.ToString(), (object)"[SEND]", (object)Common.H2S(bytes), (object)DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            //Common.Log((object)e1.ToString(), (object)"[RECV]", (object)Common.H2S(numArray2), (object)DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            break;
                    }
                }
            }
            catch (SocketException ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                this.Disconnection();
            }
            return 상태처리.FALSE;
        }

        private 상태처리 재구성_배치개시(string s분류번호, string s월일)
        {
            try
            {
                if (MakeData.REBUILDComplete(GlobalClass.LOCAL_FOLDER, s월일, s분류번호))
                    return 상태처리.TRUE;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return 상태처리.ERROR;
            }
            finally
            {
                Thread.Sleep(10000);
            }
            return 상태처리.FALSE;
        }

        private 상태처리 재구성_배치종료(string s분류번호, string s배치번호, string s원배치번호)
        {
            try
            {
                DataTable dt = new DataTable("usp_분류_배치종료확인_Get");
                분류.배치종료확인(dt, s분류번호, GlobalClass.장비명, s원배치번호);
                if (dt == null || dt.Rows.Count == 0  || dt.Rows[0]["결과"].ToString() != "성공")
                    return 상태처리.FALSE;
                분류.분류상태변경_원배치용(GlobalClass.장비명, s분류번호, s배치번호, s원배치번호, "종료");
                return 상태처리.TRUE;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return 상태처리.ERROR;
            }
            finally
            {
                Thread.Sleep(10000);
            }
        }

        private bool 부모배치검사(string 배치번호, string 원배치번호, string 추가배치)
        {
            if (배치번호 == 원배치번호 || string.IsNullOrEmpty(추가배치))
                return true;

            var rows = this.m_분류_작업요약Table.Select(
                $"배치번호='{배치번호}' AND 배치번호=원배치번호 AND 분류상태 IN ('개시', '중단')");
            if (rows.Length > 0) return true;

            Common.ErrorMessage(this.Text, "선택한 배치는 단독으로 개시할 수 없습니다.\r\n부모 배치를 먼저 개시하여 주세요.");
            return false;
        }

        private bool 중복슈트확인(string 원배치번호)
        {
            try
            {
                DataTable dt = new DataTable("usp_관리_제약사항_배정할수없는슈트확인_Get");
                관리.배정할수없는슈트확인(dt, 원배치번호);
                if (dt.Rows.Count > 0)
                {
                    Common.ErrorMessage(this.Text, "1번 슈트에 분류가 배정 되었습니다.\r\n선택한 배치를 개시할 수 없습니다.");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return false;
            }
        }

        private bool 중복바코드확인(string 분류번호, string 원배치번호)
        {
            try
            {
                관리.바코드중복확인(분류번호, GlobalClass.장비명, 원배치번호);
                return true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, $"선택한 [{원배치번호}] 배치는 중복되는 아이템이 있어 개시할 수 없습니다.\r\n{ex.Message}");
                return false;
            }
        }

        private bool 배송사중복배정확인(string 분류번호, string 원배치번호)
        {
            try
            {
                DataTable dt = new DataTable("usp_관리_제약사항_배송사중복배정확인_Get");
                관리.배송사중복배정확인(dt, 분류번호, GlobalClass.장비명, 원배치번호);
                if (dt.Rows.Count > 0)
                {
                    Common.ErrorMessage(this.Text, "동일 매장에 배송사가 중복 배정되었습니다.\r\n선택한 배치를 개시할 수 없습니다.");
                    if (MessageBox.Show("대상을 확인 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return false;
                    var dlg = new frmTRDLG00061()
                    {
                        TITLE2 = "배송사 중복 배정 확인 - " + 원배치번호,
                        자리수초과아이템 = dt.Copy()
                    }.ShowDialog();

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return false;
            }
        }

        private bool 매장중복배정확인(string 분류번호, string 원배치번호)
        {
            try
            {
                DataTable dt = new DataTable("usp_관리_제약사항_매장중복배정확인_Get");
                관리.매장중복배정확인(dt, 분류번호, GlobalClass.장비명, 원배치번호);
                if (dt.Rows.Count > 0)
                {
                    Common.ErrorMessage(this.Text, "동일 슈트에 매장이 중복 배정되었습니다.\r\n\r\n선택한 배치를 개시할 수 없습니다.");
                    if (MessageBox.Show("대상을 확인 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return false;
                    var dlg = new frmTRDLG00061()
                    {
                        TITLE2 = ("매장 중복 배정 확인 - " + 원배치번호),
                        자리수초과아이템 = dt.Copy()
                    }.ShowDialog();
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return false;
            }
        }

        private void 배치개시(string 분류번호, string 분류명, string 작업일자, string 배치번호, string 원배치번호)
        {
            var 동작구분 = 동작모드.개시;
            var 분류구분 = this.연속.Checked ? 분류방법.연속 : 분류방법.균등;

            for (int i = 0; i < 5; i++)
            {
                if (!this.Connection())
                {
                    Common.ErrorMessage(this.Text, "PAS에 연결할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    break;
                }

                Application.DoEvents();

                var 결과 = this.SendReceive(분류번호, 분류명, 작업일자, 동작구분, 분류구분);
                if (결과 == 상태처리.TRUE)
                {
                    분류.분류상태변경(GlobalClass.장비명, 분류번호, "개시");
                    분류.분류상태변경_원배치용(GlobalClass.장비명, 분류번호, 배치번호, 원배치번호, "작업중");
                    return;
                }

                if (결과 == 상태처리.FALSE && i == 4)
                {
                    Common.ErrorMessage(this.Text, "배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    try
                    {
                        관리.바코드중복확인취소(분류번호, GlobalClass.장비명, 원배치번호);
                    }
                    catch (Exception ex)
                    {
                        // 로그용: ex.Message
                    }
                }
            }
        }

        private void 배치재구성및개시(string 분류번호, string 원배치번호)
        {
            var rows = this.m_분류_작업요약Table.Select($"분류번호='{분류번호}' AND 순번=1");
            if (rows.Length == 0)
            {
                Common.ErrorMessage(this.Text, "배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                return;
            }

            string 작업일자 = rows[0]["작업일자"].ToString();
            string 월일;
            try
            {
                월일 = 작업일자.Substring(4, 4);
            }
            catch
            {
                월일 = DateTime.Now.ToString("MMdd");
            }

            string sourcePath = $"{GlobalClass.PATH_STARTUP}\\TEMP\\{원배치번호}_REBUILD.DAT";
            string targetPath = $"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}\\{원배치번호}\\REBUILD.DAT";

            if (!File.Exists(sourcePath))
            {
                Common.ErrorMessage(this.Text, "선택한 배치가 준비되지 않습니다.\r\n배치 수신처리 및 작성이 되어있는지 확인하세요.");
                return;
            }

            if (!파일복사(sourcePath, targetPath))
            {
                Common.ErrorMessage(this.Text, "배치개시 준비가 되지 않았습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                return;
            }

            if (!File.Exists(targetPath))
            {
                GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = string.Empty)));
                Common.ErrorMessage(this.Text, "배치를 개시하는 중 문제가 발생하였습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                return;
            }

            for (int i = 0; i < 60; i++)
            {
                GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
                Application.DoEvents();

                var result = this.재구성_배치개시(분류번호, 월일);
                if (result == 상태처리.TRUE)
                {
                    분류.분류상태변경_원배치용(GlobalClass.장비명, 분류번호, 분류번호, 원배치번호, "작업중");
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = $"[{원배치번호}] 배치를 개시 하였습니다.")));
                    break;
                }

                if (result == 상태처리.FALSE && i == 59)
                {
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = "배치 개시 실패!!")));
                    Common.ErrorMessage(this.Text, "배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = string.Empty)));
                }

                Thread.Sleep(10000);
            }

            File.Delete(sourcePath);
        }

        private bool 파일복사(string sourcePath, string targetPath)
        {
            FileStream source = null;
            FileStream target = null;

            try
            {
                source = File.Open(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                target = File.Open(targetPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);

                source.CopyTo(target);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (source != null) source.Dispose();
                if (target != null) target.Dispose();
            }
        }

        private bool 재구성배치슈트중복확인(string 분류번호, string 원배치번호)
        {
            try
            {
                DataTable dt = new DataTable("usp_관리_제약사항_재구성배치슈트중복확인_Get");
                관리.재구성배치슈트중복확인(dt, 분류번호, GlobalClass.장비명, 원배치번호);

                if (dt.Rows.Count > 0)
                {
                    string message = "슈트가 두개 이상의 배치에 배정되어 있습니다.\r\n\r\n지금 배치를 종료하게되면 해당 배치들은 모두 종료됩니다.\r\n\r\n그래도 종료 하시겠습니까?";
                    return MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes;
                }
                return true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
                return false;
            }
        }

        private List<재구성Model> 배치종료대상(string 분류번호, string 원배치번호)
        {
            DataTable dt = new DataTable("usp_분류_배치종료대상_Get");
            분류.배치종료대상(dt, 분류번호, GlobalClass.장비명, 원배치번호);

            return dt.AsEnumerable().Select(row =>
                new 재구성Model(string.Empty, "E", string.Empty, string.Empty, string.Empty,
                            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                            string.Empty, string.Empty, row["슈트번호"].ToString(), string.Empty,
                            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                            string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)).ToList();
        }

        private string 재구성데이터저장(string 원배치번호, List<재구성Model> rebuildList)
        {
            string path = $"{GlobalClass.PATH_STARTUP}\\TEMP";
            string sDate = DateTime.Now.ToString("yyyyMMdd");
            MakeData.MakeREBUILD(path, sDate, 원배치번호, 재구성구분.종료, rebuildList.ToArray());

            return $"{path}\\{원배치번호}_END_REBUILD.DAT";
        }

        private bool 재구성데이터복사(string 원배치번호, string sourcePath)
        {
            try
            {
                string sDate = DateTime.Now.ToString("yyyyMMdd");
                string targetPath = $"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{sDate}\\{GlobalClass.장비명}\\REBUILD.DAT";

                using (FileStream targetStream = System.IO.File.Open(targetPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                using (FileStream sourceStream = System.IO.File.Open(sourcePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    byte[] buffer = new byte[sourceStream.Length];
                    sourceStream.Read(buffer, 0, buffer.Length);
                    targetStream.Write(buffer, 0, buffer.Length);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void 배치종료(string 분류번호, string 배치번호, string 원배치번호, string filePath)
        {
            Thread.Sleep(30000);

            for (int i = 0; i < 60; i++)
            {
                Application.DoEvents();

                switch (재구성_배치종료(분류번호, 배치번호, 원배치번호))
                {
                    case 상태처리.TRUE:
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        return;

                    case 상태처리.FALSE:
                        if (i == 59)
                            Common.ErrorMessage(this.Text, "배치를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                        continue;

                    default:
                        return;
                }
            }
        }

        #endregion

        #region 이벤트

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                분류.배치리스트조회(m_분류_작업요약Table, Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd"), 1);

                List<DataRow> dataRowList = new List<DataRow>();
                var 배치상태값 = new HashSet<string> { "이관", "완료", "실적작성", "실적반영", "배치반영" };

                foreach (DataRow row in this.m_분류_작업요약Table.Rows)
                {
                    if (row["분류상태"].ToString() == "종료")
                    {
                        dataRowList.Add(row);
                    }
                    else if (!this.ultraCheckEditor1.Checked && 배치상태값.Contains(row["배치상태"].ToString()))
                    {
                        dataRowList.Add(row);
                    }
                }

                foreach (DataRow row in dataRowList)
                    this.m_분류_작업요약Table.Rows.Remove(row);
                this.m_분류_작업요약Table.AcceptChanges();

                this.ultraLinearGauge1.MinimumValue = 0L;
                this.ultraLinearGauge1.MaximumValue = 0L;
                this.ultraLinearGauge1.Value = 0L;

                if (this.m_분류_작업요약Table.Rows.Count <= 0)
                    return;

                string 분류상태 = this.uGrid3.Rows[0].Cells["분류상태"].Value.ToString();
                string 배치상태 = this.uGrid3.Rows[0].Cells["배치상태"].Value.ToString();

                this.버튼제어(분류상태, 배치상태);
                this.분류_임계치_조회(this.uGrid3.Rows[0].Cells["분류번호"].Value.ToString());
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = string.Empty)));
                this.ultraCheckEditor1.Checked = false;
                Cursor.Current = Cursors.Default;
            }
        }

        private void uGrid3_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var element = uGrid3.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
                var cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;

                if (cell == null)
                    return;

                var row = cell.Row;

                string 분류상태 = row.Cells["분류상태"].Value?.ToString() ?? string.Empty;
                string 배치상태 = row.Cells["배치상태"].Value?.ToString() ?? string.Empty;

                this.버튼제어(분류상태, 배치상태);
                this.분류_임계치_조회(row.Cells["분류번호"].Value?.ToString() ?? string.Empty);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
        }

        private void 배치개시_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = this.uGrid3.Selected.Rows;
                if (selectedRows == null || selectedRows.Count == 0)
                {
                    Common.ErrorMessage(this.Text, "배치를 선택해 주세요.");
                    return;
                }
                UltraGridRow row = selectedRows[0];

                frmLoading.ShowLoading();
                string 분류번호 = row.Cells["분류번호"].Value.ToString();
                string 분류명 = row.Cells["분류명"].Value.ToString();
                string 배치번호 = row.Cells["배치번호"].Value.ToString();
                string 원배치번호 = row.Cells["원배치번호"].Value.ToString();
                string 추가배치 = row.Cells["추가배치"].Value.ToString();
                string 순번 = row.Cells["순번"].Value.ToString();
                string 작업일자 = row.Cells["작업일자"].Value.ToString();

                if (!부모배치검사(배치번호, 원배치번호, 추가배치)) return;
                if (!중복슈트확인(원배치번호)) return;
                if (!중복바코드확인(분류번호, 원배치번호)) return;
                if (!배송사중복배정확인(분류번호, 원배치번호)) return;
                if (!매장중복배정확인(분류번호, 원배치번호)) return;

                string 작업중인분류번호 = this.분류_작업요약_작업중인분류번호();
                if(분류번호 != 작업중인분류번호 && !string.IsNullOrEmpty(작업중인분류번호))
                {
                    Common.ErrorMessage(this.Text, "선택한 배치는 개시할 수 없습니다.");
                    return;
                }

                if (순번 == "1")
                    배치개시(분류번호, 분류명, 작업일자, 배치번호, 원배치번호);
                else
                    배치재구성및개시(분류번호, 원배치번호);   
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, "배치 개시 중 오류가 발생했습니다.\r\n\r\n" + ex.Message);
            }
            finally
            {
                frmLoading.CloseLoading();
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void 배치종료_Click(object sender, EventArgs e)
        {
            var selectedRows = this.uGrid3.Selected.Rows;
            if (selectedRows == null || selectedRows.Count == 0)
            {
                Common.ErrorMessage(this.Text, "배치를 선택해 주세요.");
                return;
            }
            UltraGridRow row = selectedRows[0];

            string 분류번호 = row.Cells["분류번호"].Value.ToString();
            string 배치번호 = row.Cells["배치번호"].Value.ToString();
            string 원배치번호 = row.Cells["원배치번호"].Value.ToString();

            DataRow[] array = this.m_분류_작업요약Table.Select($"배치번호='{배치번호}'");
            if (array != null && array.Length > 1)
            {
                Common.ErrorMessage(this.Text, "선택한 배치는 종속된 배치가 있어서 종료를 할 수 없습니다.\r\n분류종료를 하십시오.");
                return;
            }
            if (MessageBox.Show($"선택한 배치번호는 [{원배치번호}] 입니다.\r\n종료 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes ||
                MessageBox.Show("★★★ 마지막 박스 발행은 하셨나요? ★★★\r\n\r\n배치를 종료하면 마지막 박스 발행 작업을 할 수 없습니다.\r\n\r\n그래도 종료 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;
            MessageBox.Show("PAS의 작동이 완료되었는지,\r\n\r\n컨베이어 위에 상품이 있는지,\r\n\r\n다시한번 확인해 주세요.", this.Text, MessageBoxButtons.OK);

            DataRow[] rows = this.m_분류_작업요약Table.Select($"분류번호='{분류번호}' AND 순번=1");
            var 첫작업Row = rows.Length > 0 ? rows[0] : null;
            if (첫작업Row == null)
            {
                Common.ErrorMessage(this.Text, "배치를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                return;
            }

            try
            {
                if (!재구성배치슈트중복확인(분류번호, 원배치번호)) return;

                frmLoading.ShowLoading();
                string 작업일자 = 첫작업Row["작업일자"].ToString();
                string s월일 = 작업일자.Length >= 8 ? 작업일자.Substring(4, 4) : DateTime.Now.ToString("MMdd");

                var 대상List = 배치종료대상(분류번호, 원배치번호);
                string 종료파일경로 = 재구성데이터저장(원배치번호, 대상List);

                if (!재구성데이터복사(원배치번호, 종료파일경로))
                {
                    Common.ErrorMessage(this.Text, "배치종료 준비가 되지 않았습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    return;
                }

                배치종료(분류번호, 배치번호, 원배치번호, 종료파일경로);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                frmLoading.CloseLoading();
                조회버튼_Click(null, EventArgs.Empty);
            }
        }

        private void 분류종료_Click(object sender, EventArgs e)
        {
            try
            {
                var 동작구분 = 동작모드.종료;
                var 분류구분 = this.연속.Checked ? 분류방법.연속 : 분류방법.균등;

                var selectedRows = this.uGrid3.Selected.Rows;
                if (selectedRows == null || selectedRows.Count == 0)
                {
                    Common.ErrorMessage(this.Text, "분류를 선택해 주세요.");
                    return;
                }
                UltraGridRow row = selectedRows[0];

                string 분류번호 = row.Cells["분류번호"].Value.ToString();
                string 분류상태 = row.Cells["분류상태"].Value.ToString();
                string 분류명 = row.Cells["분류명"].Value.ToString();
                string 배치번호 = row.Cells["배치번호"].Value.ToString();
                string 원배치번호 = row.Cells["원배치번호"].Value.ToString();

                if (분류상태 == "준비" || 분류상태 == "종료")
                {
                    Common.ErrorMessage(this.Text, "선택한 분류는 종료할 수 없습니다.");
                    return;
                }
                if (MessageBox.Show("현재 분류를 모두 종료합니다.\r\n\r\n★★★ 정말로 종료 하시겠습니까? ★★★", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes) return;
                MessageBox.Show("PAS의 작동이 완료되었는지,\r\n\r\n컨베이어 위에 상품이 있는지,\r\n\r\n다시한번 확인해 주세요.", this.Text, MessageBoxButtons.OK);

                var rows = this.m_분류_작업요약Table.Select($"분류번호='{분류번호}' AND 순번=1");
                if (rows == null || rows.Length <= 0)
                {
                    Common.ErrorMessage(this.Text, "분류를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    return;
                }
                string 작업일자 = rows[0]["작업일자"].ToString();

                if (string.IsNullOrEmpty(작업일자))
                {
                    Common.ErrorMessage(this.Text, "분류를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    return;
                }

                for (int i = 0; i < 5; i++)
                {
                    if (!this.Connection())
                    {
                        Common.ErrorMessage(this.Text, "PAS에 연결할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                        GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = string.Empty)));
                        break;
                    }
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
                    Application.DoEvents();
                    var 결과 = this.SendReceive(분류번호, 분류명, 작업일자, 동작구분, 분류구분);

                    if (결과 == 상태처리.TRUE)
                    {
                        분류.분류상태변경_원배치용(GlobalClass.장비명, 분류번호, 배치번호, 원배치번호, "완료");
                        분류.분류상태변경(GlobalClass.장비명, 분류번호, "종료");
                        GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = $"[{분류번호}] 분류를 종료 하였습니다.")));
                        return;
                    }

                    if (결과 == 상태처리.FALSE && i + 1 == 5)
                    {
                        GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = "분류 종료 실패!!")));
                        Common.ErrorMessage(this.Text, "분류를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                        GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역상태메시지.Text = string.Empty)));
                    }
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        #endregion

    }
}
