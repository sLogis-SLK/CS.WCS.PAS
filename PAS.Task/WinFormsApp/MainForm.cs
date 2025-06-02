using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS.Task
{
    public partial class MainForm : Form
    {
        #region 개체선언부

        //윈폼 Timer 로 일정시간 flag 변경해주기 위함
        private System.Windows.Forms.Timer mPasDurationTimer;
        private System.Windows.Forms.Timer mPrinterDurationTimer;

        //Pas 체크 Thread 및 소켓통신 쪽 함수
        private Thread mPasThread;
        private SocketServer mSocketServer;

        private DataTable m_표시기맵Table = new DataTable("표시기맵TABLE");
        private DataTable m_분류_숫자표시기값Table = new DataTable("usp_분류_숫자표시기값_Get");

        private bool 작업시작여부 //true시 작업시작 대기 상태, false시 작업중
        {
            get { return 시작버튼.Text == "시작" ? true : false; }
            set
            {
                string sText = "작업중";
                if (value) sText = "시작";

                if (시작버튼.InvokeRequired)
                {
                    시작버튼.Invoke(new Action(() => { 시작버튼.Text = sText; }));
                }
                else
                {
                    시작버튼.Text = sText;
                }

                if (PAS기기콤보.InvokeRequired)
                {
                    PAS기기콤보.Invoke(new Action(() => { PAS기기콤보.Enabled = value; }));
                }
                else 
                {
                    PAS기기콤보.Enabled = value;
                }

            }
        }

        #endregion

        #region 생성자 및 폼 override 이벤트

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //스크린 최상단으로 위치이동
            Screen screen = Screen.FromPoint(Location);
            Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);

            //최초 초기화 및 정보 가져오기
            GlobalClass.InitializationSettings();

            //PAS기기콤보 세팅
            foreach (var item in GlobalClass.DicPas기기)
            {
                PAS기기콤보.Items.Add(item.Key);
            }
            if (PAS기기콤보.Items.Count > 0) PAS기기콤보.SelectedIndex = 0;

            //시작버튼 이벤트
            시작버튼.Click += 시작버튼_Click;
            시작버튼.Focus();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (MessageBox.Show("PAS 동작에 심각한 문제가 발생 할 수 있습니다.\r\n그래도 종료 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    //this.m_eDPSStatus = DPSStatus.END;
                    MessageBox.Show("표시기를 종료하고 있습니다.\r\n\r\n표시기가 종료될때 까지 기다리세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    Thread.Sleep(5000); //5초 대기

                    모니터링종료(); //각종쓰레드 종료

                    Process.GetCurrentProcess().Kill();
                    base.OnClosed(e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                //미종료
                //e.Cancel = true;
            }
        }

        #endregion

        #region 사용자정의함수

        private void 사용불켜기(Enum.JobTaskType jobTask)
        {
            Label label = null;
            switch (jobTask)
            {
                case Enum.JobTaskType.PAS:
                    label = 사용라벨1;
                    break;
                case Enum.JobTaskType.숫자표시기:
                    label = 사용라벨2;
                    break;
                case Enum.JobTaskType.실적관리서버:
                    label = 사용라벨3;
                    break;
                case Enum.JobTaskType.거래명세서출력:
                    label = 사용라벨4;
                    break;
                default:
                    break;
            }
            if (label == null) return;

            string sText = "●";
            Color color = Color.Green;

            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => {
                    label.Text = sText;
                    label.ForeColor = color;
                }));
            }
            else
            {
                label.Text = sText;
                label.ForeColor = color;
            }
        }

        private void 사용불끄기(Enum.JobTaskType jobTask)
        {
            Label label = null;
            switch (jobTask)
            {
                case Enum.JobTaskType.PAS:
                    label = 사용라벨1;
                    break;
                case Enum.JobTaskType.숫자표시기:
                    label = 사용라벨2;
                    break;
                case Enum.JobTaskType.실적관리서버:
                    label = 사용라벨3;
                    break;
                case Enum.JobTaskType.거래명세서출력:
                    label = 사용라벨4;
                    break;
                default:
                    break;
            }

            if (label == null) return;

            string sText = "○";
            Color color = Color.Black;

            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => {
                    label.Text = sText;
                    label.ForeColor = color;
                }));
            }
            else
            {
                label.Text = sText;
                label.ForeColor = color;
            }
        }

        private void 오류불켜기(Enum.JobTaskType jobTask)
        {
            Label label = null;
            switch (jobTask)
            {
                case Enum.JobTaskType.PAS:
                    label = 오류라벨1;
                    break;
                case Enum.JobTaskType.숫자표시기:
                    label = 오류라벨2;
                    break;
                case Enum.JobTaskType.실적관리서버:
                    label = 오류라벨3;
                    break;
                case Enum.JobTaskType.거래명세서출력:
                    label = 오류라벨4;
                    break;
                default:
                    break;
            }

            if (label == null) return;

            string sText = "●";
            Color color = Color.Red;

            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => {
                    label.Text = sText;
                    label.ForeColor = color;
                }));
            }
            else
            {
                label.Text = sText;
                label.ForeColor = color;
            }
        }

        private void 오류불끄기(Enum.JobTaskType jobTask)
        {

            Label label = null;
            switch (jobTask)
            {
                case Enum.JobTaskType.PAS:
                    label = 오류라벨1;
                    break;
                case Enum.JobTaskType.숫자표시기:
                    label = 오류라벨2;
                    break;
                case Enum.JobTaskType.실적관리서버:
                    label = 오류라벨3;
                    break;
                case Enum.JobTaskType.거래명세서출력:
                    label = 오류라벨4;
                    break;
                default:
                    break;
            }

            if (label == null) return;

            string sText = "○";
            Color color = Color.Black;

            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => {
                    label.Text = sText;
                    label.ForeColor = color;
                }));
            }
            else
            {
                label.Text = sText;
                label.ForeColor = color;
            }
        }

        private void 모니터링시작()
        {
            try
            {
                if (this.mPasThread != null)
                {
                    //Common.IsPasThread = false;
                    this.mPasThread.Abort();
                    this.mPasThread = (Thread)null;
                }

                mPasThread = new Thread(new ThreadStart(PasThread));

                //Common.IsPasThread = true;
                //Common.IsPasContinue = false;
                //Common.IsPrintThread = true;
                //Common.IsPrintContinue = false;
                if (File.Exists(GlobalClass.PATH_STARTUP + "\\Task.dat"))
                {
                    string str = string.Empty;
                    using (StreamReader streamReader = new StreamReader(GlobalClass.PATH_STARTUP + "\\Task.dat", Encoding.Default))
                    {
                        str = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                    //Common.IsLog = !string.IsNullOrEmpty(str) && str.Trim() == "1";
                }
                //else
                //    Common.IsLog = false;
                //Common.GetSetting();

                m_표시기맵Table = Indicator.MakeDPSMap();


                //Pas상태모니터링
                mPasDurationTimer = new System.Windows.Forms.Timer();
                //거래명세표출력 모니터링
                mPrinterDurationTimer = new System.Windows.Forms.Timer();


                //SocketServer 관련
                if (this.mSocketServer != null)
                {
                    this.mSocketServer.Stop();
                    this.mSocketServer.Receiving -= new SocketBase.ReceivingEvent(mServer_Receiving);
                    this.mSocketServer.Accept -= new SocketBase.AcceptEvent(mServer_Accept);
                    this.mSocketServer = (SocketServer)null;
                }
                //this.m_eDPSStatus = DPSStatus.START;
                this.mSocketServer = new SocketServer();
                //this.m_oServer.IP = Common.Setting.INDICATOR_IP;
                //this.m_oServer.Port = Convert.ToInt32(Common.Setting.INDICATOR_PORT);
                this.mSocketServer.Accept += new SocketBase.AcceptEvent(mServer_Accept);
                this.mSocketServer.Receiving += new SocketBase.ReceivingEvent(mServer_Receiving);
            }
            catch (Exception ex)
            {
                //this.m_eDPSStatus = DPSStatus.NONE;
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            //이벤트 한군데서 사용
            mPasDurationTimer.Tick += mPasDurationTimer_Tick;
            mPrinterDurationTimer.Tick += mPrinterDurationTimer_Tick;
            mSocketServer.Accept += new SocketBase.AcceptEvent(mServer_Accept);
            mSocketServer.Receiving += new SocketBase.ReceivingEvent(mServer_Receiving);
        }

        private void 모니터링종료()
        {
            //각종 쓰레드 들 종료
            if (mPasDurationTimer != null)
            {
                //Common.IsPasContinue = false;
                mPasDurationTimer.Enabled = false;
            }
            if (mPrinterDurationTimer != null)
            {
                //Common.IsPrintContinue = false;
                mPrinterDurationTimer.Enabled = false;
            }
            //if (this.m_oPasThread != null)
            //{
            //    Common.IsPasThread = false;
            //    this.m_oPasThread.Abort();
            //    this.m_oPasThread = (Thread)null;
            //}

            if (this.mSocketServer != null)
            {
                this.mSocketServer.Stop();
                this.mSocketServer = (SocketServer)null;
            }
        }

        #endregion

        #region 스레드관련 사용자정의함수

        private void mServer_Accept()
        {
            List<byte> byteList = new List<byte>();
            byteList.Add((byte)2);
            byteList.Add((byte)49);
            byteList.Add((byte)49);
            byteList.Add((byte)67);
            byteList.Add((byte)4);
            byteList.Add((byte)63);
            byteList.Add((byte)3);
            //if (this.m_oServer.InitClient == null)
            //    return;
            //this.m_oServer.InitClient.Send(byteList.ToArray());
            //Common.Log((object)"ACCEPT", (object)"SEND", (object)Common.B2C(byteList.ToArray()));
        }

        private void mServer_Receiving(object sender, byte[] yBuffer)
        {
            List<byte> byteList = new List<byte>();
            Socket client = ((SocketObject)sender).Client;
            if (yBuffer[0] == (byte)2)
            {
                if (yBuffer[yBuffer.Length - 1] == (byte)3)
                {
                    if (client != null)
                    {
                        //if (!Common.IsSetting)
                        //{
                        //    Common.Log((object)"RECEIVING", (object)"RECV", (object)Common.B2C(yBuffer));
                        //    if (yBuffer[3] != (byte)6)
                        //    {
                        //        byteList.Add((byte)2);
                        //        byteList.Add(yBuffer[1]);
                        //        byteList.Add(yBuffer[2]);
                        //        byteList.Add((byte)6);
                        //        byteList.Add((byte)4);
                        //        byteList.Add((byte)63);
                        //        byteList.Add((byte)3);
                        //        if (client.Connected)
                        //            client.Send(byteList.ToArray());
                        //    }
                        //    Common.LightOn_Normal(TaskType.INDICATOR);
                        //    Common.LightOff_Error(TaskType.INDICATOR);
                        //    DBProvider2.GetData(this.m_분류_숫자표시기값Table, new SqlConnection(Common.ConnectionString()), new string[1] { "@장비명" }, (object)Common.Setting.NAME);
                        //    Common.Log((object)"RECEIVING", (object)"SELECT", (object)this.m_분류_숫자표시기값Table.Rows.Count.ToString());
                        //    DataTable oDataTable = this.m_표시기맵Table.Copy();
                        //    if (this.m_분류_숫자표시기값Table != null)
                        //    {
                        //        if (this.m_분류_숫자표시기값Table.Rows.Count > 0)
                        //        {
                        //            if (this.m_eDPSStatus == DPSStatus.START)
                        //            {
                        //                try
                        //                {
                        //                    foreach (DataRow row in (InternalDataCollectionBase)oDataTable.Rows)
                        //                    {
                        //                        DataRow[] dataRowArray = this.m_분류_숫자표시기값Table.Select("슈트번호='" + row["슈트번호"].ToString() + "'");
                        //                        if (dataRowArray != null && dataRowArray.Length > 0)
                        //                            row["수량"] = dataRowArray[0]["표시수"];
                        //                    }
                        //                    oDataTable.AcceptChanges();
                        //                    Common.Log((object)"RECEIVING", (object)"START", (object)oDataTable.Rows.Count.ToString());
                        //                    byte[] numArray = Indicator.MakeDPSCommand(oDataTable, Indicator.DPSCommandType.DATA);
                        //                    if (numArray != null)
                        //                    {
                        //                        if (numArray.Length > 0)
                        //                        {
                        //                            if (client.Connected)
                        //                            {
                        //                                client.Send(numArray);
                        //                                Common.Log((object)"RECEIVING", (object)"SEND", (object)Common.B2C(numArray));
                        //                                mServer_Disconnect(client); return;
                        //                                //goto label_31;
                        //                            }
                        //                            else
                        //                            {
                        //                                mServer_Disconnect(client); return;
                        //                            }
                        //                            //goto label_31;
                        //                        }
                        //                        else
                        //                        {
                        //                            mServer_Disconnect(client); return;
                        //                        }
                        //                            //goto label_31;
                        //                    }
                        //                    else
                        //                    {
                        //                        mServer_Disconnect(client); return;
                        //                    }
                        //                    //goto label_31;
                        //                }
                        //                catch (Exception ex)
                        //                {
                        //                    Common.LightOn_Error(TaskType.INDICATOR);
                        //                    Common.Log(true, (object)"[DpsProcess]", (object)"[ERR-02]", (object)ex.Message);
                        //                    mServer_Disconnect(client); return;
                        //                    //goto label_31;
                        //                }
                        //                finally
                        //                {
                        //                    Thread.SpinWait(1);
                        //                }
                        //            }
                        //        }
                        //    }
                        //    try
                        //    {
                        //        if (this.m_eDPSStatus != DPSStatus.NONE)
                        //        {
                        //            byte[] numArray = Indicator.MakeDPSCommand(this.m_표시기맵Table, Indicator.DPSCommandType.CLEAR);
                        //            if (numArray != null)
                        //            {
                        //                if (numArray.Length > 0)
                        //                {
                        //                    if (client.Connected)
                        //                    {
                        //                        client.Send(numArray);
                        //                        //Common.Log((object)"RECEIVING", (object)"SEND", (object)Common.B2C(numArray));
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        //Common.LightOn_Error(TaskType.INDICATOR);
                        //        //Common.Log(true, (object)"[DpsProcess]", (object)"[ERR-01]", (object)ex.Message);
                        //    }
                        //    finally
                        //    {
                        //        Thread.SpinWait(1);
                        //    }
                        //label_31: string ssss = ""; //의미없음
                        //    //Common.LightOff_Normal(TaskType.INDICATOR);
                        //}
                    }
                }
            }

            mServer_Disconnect(client); return;
        }

        private void mServer_Disconnect(Socket client)
        {
            try
            {
                client.Disconnect(false);
                client.Close(1000);
            }
            catch (SocketException ex)
            {
                //Common.LightOn_Error(TaskType.INDICATOR);
                //string message = ex.Message;
            }
            catch (Exception ex)
            {
                //Common.LightOn_Error(TaskType.INDICATOR);
                //string message = ex.Message;
            }
        }

        private void PasThread()
        {
            TcpClient oClient = (TcpClient)null;
            NetworkDrive networkDrive = (NetworkDrive)null;
            try
            {
                if (!string.IsNullOrEmpty(GlobalClass.SEIGYO_ID) && !string.IsNullOrEmpty(GlobalClass.SEIGYO_PASSWORD) && !string.IsNullOrEmpty(GlobalClass.SEIGYO_FOLDER))
                {
                    networkDrive = new NetworkDrive(GlobalClass.SEIGYO_ID, GlobalClass.SEIGYO_PASSWORD, GlobalClass.SEIGYO_FOLDER);
                }
                else
                {
                    MessageBox.Show("환경설정에 누락된 값이 있습니다..\r\n프로그램을 종료합니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                MessageBox.Show("PAS 제어 프로그램의 실적에 접근할 수 없습니다.\r\n프로그램을 종료합니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }
            if (networkDrive == null)
            {
                MessageBox.Show("PAS 제어 프로그램의 실적에 접근할 수 없습니다.\r\n프로그램을 종료합니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }

            bool IsPasThread = true;
            bool IsPrinting = true;
            bool IsSetting = true;
            bool IsPasEvent = true;
            bool IsPasContinue = true;

            while (IsPasThread)
            {
                //인쇄중이거나 세팅중이거나 파스이벤트 있으면 멈춤
                if (IsPrinting || IsSetting || IsPasEvent)
                {
                    continue;
                }

                //IsPasContinue 는 
                if (IsPasContinue == false)
                {
                    continue;
                }

                //if (!Common.IsPrinting && !Common.IsSetting && !Common.IsPasEvent && Common.IsPasContinue)
                //{
                //    
                //      //내부진행
                //}


                IsPasEvent = true;

                사용불켜기(Enum.JobTaskType.PAS);
                사용불끄기(Enum.JobTaskType.실적관리서버);
                오류불끄기(Enum.JobTaskType.실적관리서버);

                string s장비명 = "";
                DataTable dt = 작업.Pas작업.출하상태확인(s장비명);

                if (dt == null || dt.Rows.Count <= 0)
                {
                    //Common.IsPasEvent = false;
                    //Common.IsPasContinue = false;
                    Thread.Sleep(100);
                    continue;
                }

                string sBatchNo = dt.Rows[0]["분류번호"].ToString();
                string 작업일자 = dt.Rows[0]["작업일자"].ToString();
                //string empty = string.Empty;
                string 작업월일;

                try
                {
                    작업월일 = 작업일자.Substring(4, 4);
                }
                catch
                {
                    작업월일 = DateTime.Now.ToString("MMdd");
                }

                int iLastIndex = Convert.ToInt32(dt.Rows[0]["관리번호"]);
                string sDestPath = $"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{작업월일}\\{sBatchNo}";
                string sFileName = $"{작업일자}_{sBatchNo}.DB";

                if (!networkDrive.Exist(sFileName))
                {
                    //Common.IsPasEvent = false;
                    //Common.IsPasContinue = false;
                    Thread.Sleep(100);
                }

                try
                {
                    DataTable dataTable = networkDrive.ReadLineParser(sDestPath, sFileName, sBatchNo, iLastIndex).Copy();
                    if (dataTable == null || dataTable.Rows.Count <= 0)
                    {
                        //Common.IsPasEvent = false;
                        //Common.IsPasContinue = false;
                        Thread.Sleep(100);
                        continue;
                    }

                    int num = iLastIndex + dataTable.Rows.Count;
                    DataRow[] dataRowArray = dataTable.Select("MARK='C'", "IDX ASC");
                    작업.Pas작업.작업결과저장(sBatchNo, s장비명, num, dataTable);

                    if (dataRowArray == null || dataRowArray.Length <= 0)
                    {
                        continue;
                    }

                    //Common.IsPrinting = true;
                    foreach (DataRow dataRow in dataRowArray)
                    {
                        string s슈트번호 = dataRow["CHUTENO"].ToString();
                        try
                        {
                            string s마지막박스여부 = "0";
                            작업.Pas작업.박스풀(sBatchNo, s장비명, s슈트번호, s마지막박스여부);
                        }
                        catch (Exception ex)
                        {
                            //Common.Log(true, (object)"[PasProcess]", (object)string.Format("{0}번 슈트에서 박스풀 발행을 했으나 프린터에서 응답이 없습니다.\r\n{1}", (object)s슈트번호, (object)ex.Message));
                            //Common.LightOn_Error(TaskType.PAS);
                            오류불켜기(Enum.JobTaskType.PAS);
                            Thread.Sleep(300);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Common.Log(true, (object)"[PasProcess]", (object)ex.Message);
                    오류불켜기(Enum.JobTaskType.PAS);
                    Thread.Sleep(300);
                }
                finally
                {
                    //Common.IsPasEvent = false;
                    //Common.IsPasContinue = false;
                    //Common.IsPrinting = false;
                    Thread.Sleep(100);
                    if (oClient != null)
                    {
                        oClient.Close();
                        oClient = (TcpClient)null;
                    }
                    사용불끄기(Enum.JobTaskType.PAS);
                    오류불끄기(Enum.JobTaskType.PAS);
                    //Common.LightOff_Normal(TaskType.PAS);
                    //Common.LightOff_Error(TaskType.PAS);
                }
            }
        }

        #endregion

        #region 이벤트

        private void 시작버튼_Click(object sender, EventArgs e)
        {
            //불 다끄고 초기화
            사용불끄기(Enum.JobTaskType.PAS);
            사용불끄기(Enum.JobTaskType.숫자표시기);
            사용불끄기(Enum.JobTaskType.실적관리서버);
            사용불끄기(Enum.JobTaskType.거래명세서출력);
            오류불끄기(Enum.JobTaskType.PAS);
            오류불끄기(Enum.JobTaskType.숫자표시기);
            오류불끄기(Enum.JobTaskType.실적관리서버);
            오류불끄기(Enum.JobTaskType.거래명세서출력);

            if (작업시작여부) //시작
            {
                string sPAS기기 = PAS기기콤보.SelectedItem.ToString();

                if (GlobalClass.SettingsPas기기(sPAS기기)) //기기정보 세팅
                {
                    모니터링시작();
                }
                else
                {
                    작업시작여부 = !작업시작여부;
                    오류불켜기(Enum.JobTaskType.PAS);
                    오류불켜기(Enum.JobTaskType.숫자표시기);
                    오류불켜기(Enum.JobTaskType.실적관리서버);
                    오류불켜기(Enum.JobTaskType.거래명세서출력);
                    MessageBox.Show("작업시작시 오류발생하였습니다. \r\n\r\n전산팀에 문의 하여주시기 바랍니다.", this.Text);
                }

            }
            else //종료
            {
                모니터링종료();
            }

            //콤보에 맞게 저장
            작업시작여부 = !작업시작여부;

        }

        private void mPasDurationTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int num = now.Hour * 60 * 60 + now.Minute * 60 + now.Second;
            //if (Common.Setting.PAS_DURATION == 0 || num == 0 || num % Common.Setting.PAS_DURATION != 0)
            //    return;

            //PAS_DURATION 설정한 초에 한번 Flag 실행
            //Common.IsPasContinue = true;
        }

        private void mPrinterDurationTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int num = now.Hour * 60 * 60 + now.Minute * 60 + now.Second;
            
            if (num == 0 || num % 15 != 0) return;

            //15초에 한번 Flag 실행
            //Common.IsPrintContinue = true;
        }
        
        #endregion

    }
}
