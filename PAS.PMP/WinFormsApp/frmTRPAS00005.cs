using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DbProvider;
using Infragistics.Win.UltraWinGrid;
using PAS.Core;
using PAS.PMP.Services;
using PAS.PMP.Utils;
using PAS.PMP.WinFormsApp.Dialog;
using TR_Common;
using TR_Library.Controls;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00005 : BaseForm
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_마지막박스내역Table = new DataTable("usp_분류_마지막박스내역_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_마지막박스내역BS = new BindingSource();

        string _분류번호 = string.Empty;
        string _배치번호 = string.Empty;
        string _장비명 = string.Empty;

        private Dictionary<string, string> _uGrid2RowKey;
        #endregion

        #region 초기화

        public frmTRPAS00005()
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
                #region uGrid2 BindingSource 초기화

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0, GlobalClass.장비명);

                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid2.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류방법코드", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid2, null);

                this.uGrid2.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";

                #endregion

                #region uGrid1 BindingSource 초기화

                분류.마지막박스내역조회(m_분류_마지막박스내역Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), "", 0);

                this.m_분류_마지막박스내역BS.DataSource = this.m_분류_마지막박스내역Table;
                this.uGrid1.DataSource = this.m_분류_마지막박스내역BS;

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호", "서브슈트번호");
                Common.SetGridEditColumn(this.uGrid1, "선택");
                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "실적수");
                this.uGrid1.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Name, ex);
            }
        }

        #endregion

        #region Event

        private void 조회_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            _uGrid2RowKey = UltraGridHelper.RememberActiveRow(
               uGrid2,
               "배치번호",
               "분류번호"
           );

            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            UltraGridHelper.RestoreActiveRow(uGrid2, _uGrid2RowKey);
            Cursor = Cursors.Default;
        }

        private void uGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            this.조회_Click(null, null);
        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid2.ActiveRow == null || this.uGrid2.ActiveRow.Index < 0)
                return;


            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
                _배치번호 = oRow["배치번호"].ToString();
                _분류번호 = oRow["분류번호"].ToString();
                _장비명 = oRow["장비명"].ToString();
                분류.마지막박스내역조회(m_분류_마지막박스내역Table, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), 1);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in this.uGrid1.Rows)
            {
                if (row.Tag == null || !(row.Tag.ToString() == "요약"))
                    row.Cells["선택"].Value = (object)this.checkBox1.Checked;
            }
            this.m_분류_마지막박스내역BS.EndEdit();
        }


        #endregion

        private void 박스발행_Click(object sender, EventArgs e)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;
            string empty7 = string.Empty;
            string empty8 = string.Empty;
            string empty9 = string.Empty;
            string empty10 = string.Empty;
            string empty11 = string.Empty;
            string empty12 = string.Empty;
            string empty13 = string.Empty;
            string empty14 = string.Empty;
            string empty15 = string.Empty;
            string empty16 = string.Empty;
            string empty17 = string.Empty;
            DateTime.Now.ToString("yyyy-MM-dd");
            TcpClient oClient = (TcpClient)null;

            if (_배치번호 == "")
            {
                MessageBox.Show("배치를 선택해 주세요.");
                return;
            }

            frmTRDLG00001 dialog = new frmTRDLG00001();

            // 모달로 다이얼로그 표시
            DialogResult oResult = dialog.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                bool flag1;
                bool flag2;
                switch (dialog.선택값)
                {
                    case 1:
                        flag1 = true;
                        flag2 = false;
                        break;
                    case 2:
                        flag1 = false;
                        flag2 = true;
                        break;
                    case 3:
                        flag1 = true;
                        flag2 = true;
                        break;
                    default:
                        MessageBox.Show("발행을 취소합니다.");
                        return;
                }

                try
                {
                    DataTable oDataTable1 = new DataTable("usp_기준_거래명세서용_마스터_Get");
                    분류.거래명세서출력조회(oDataTable1);
                    if (oDataTable1 == null || oDataTable1.Rows.Count <= 0)
                    {
                        MessageBox.Show("발행할 거래명세서 대상이 없습니다.");
                        return;
                    }

                    DataTable 처리성공데이터 = new DataTable();
                    처리성공데이터.Columns.Add("프린트명", typeof(string));
                    처리성공데이터.Columns.Add("프린트str", typeof(string));
                    처리성공데이터.Columns.Add("배치구분", typeof(string));
                    처리성공데이터.Columns.Add("슈트번호", typeof(string));
                    처리성공데이터.Columns.Add("배치번호", typeof(string));

                    Cursor.Current = Cursors.WaitCursor;
                    string empty18 = string.Empty;

                    using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                    {
                        try
                        {
                            DataTable oDataTable2 = new DataTable("usp_분류_박스풀작성_Set");
                            oScope.Initialize("usp_분류_박스풀작성_Set", "@분류번호", "@장비명", "@슈트번호", "@마지막박스여부");
                            this.uGrid1.PerformAction(UltraGridAction.CommitRow);
                            foreach (UltraGridRow row in this.uGrid1.Rows)
                            {
                                if (row.Cells["선택"].Value.ToString() == bool.TrueString)
                                {
                                    string str1 = row.Cells["분류번호"].Value.ToString();
                                    string s슈트번호 = row.Cells["슈트번호"].Value.ToString();
                                    oScope.Fill(oDataTable2, (object)str1, (object)_장비명, (object)s슈트번호, (object)"1");
                                    if (oDataTable2 != null && oDataTable2.Rows.Count > 0)
                                    {
                                        string s박스바코드 = oDataTable2.Rows[0]["박스바코드"].ToString();
                                        string str2 = oDataTable2.Rows[0]["점명"].ToString();
                                        string str3 = oDataTable2.Rows[0]["내품수"].ToString();
                                        string s배치구분 = oDataTable2.Rows[0]["배치구분"].ToString();
                                        string s박스바코드구분 = oDataTable2.Rows[0]["박스바코드구분"].ToString();
                                        oDataTable2.Rows[0]["점코드"].ToString();
                                        string str4 = oDataTable2.Rows[0]["박스번호"].ToString();
                                        string s패턴구분 = oDataTable2.Rows[0]["패턴구분"].ToString();
                                        string str5 = oDataTable2.Rows[0]["출력여부"].ToString();
                                        string str6 = oDataTable2.Rows[0]["브랜드코드"].ToString();
                                        string str7 = oDataTable2.Rows[0]["브랜드명"].ToString();
                                        string s배치번호 = oDataTable2.Rows[0]["배치번호"].ToString();
                                        string str8 = oDataTable2.Rows[0]["배치명"].ToString();
                                        oDataTable2.Rows[0]["대표바코드"].ToString();
                                        oDataTable2.Rows[0]["수량"].ToString();
                                        string str9 = DateTime.Now.ToString("yyyy-MM-dd");
                                        string empty19 = string.Empty;
                                        string empty20 = string.Empty;
                                        string empty21 = string.Empty;
                                        string empty22 = string.Empty;
                                        int num = ConvertUtil.ObjectToint(oDataTable2.Rows[0]["SKU수"]);
                                        int count = oDataTable2.Rows.Count;

                                        switch (s배치구분)
                                        {
                                            case "패키지":
                                                foreach(string str in PasLib.GetPrintScript4(s박스바코드, s박스바코드구분, oDataTable2.Copy()))
                                                {
                                                    처리성공데이터.Rows.Add(PasLib.GetPrinterName("패키지"), str, s배치구분, s슈트번호, s배치번호);
                                                }

                                                break;
                                            case "반품":
                                                s패턴구분 = num <= 3 ? "반품유형1" : "반품유형2";
                                                goto default;
                                            default:
                                                if (!string.IsNullOrEmpty(str3) && str3 != "0" && str5 == "1")
                                                {
                                                    string printScript = PasLib.GetPrintScript(s패턴구분, s배치구분, count);
                                                    string str10;
                                                    switch (s패턴구분)
                                                    {
                                                        case "사용안함":
                                                            str10 = string.Empty;
                                                            break;
                                                        case "출고유형":
                                                            str10 = string.Format(printScript, (object)$"{str6}:{str7}", (object)str2, (object)s슈트번호, (object)str4, (object)str3, (object)s박스바코드, (object)str9);
                                                            break;
                                                        case "반품유형1":
                                                            string empty23;
                                                            string empty24;
                                                            string empty25;
                                                            string empty26;
                                                            switch (count)
                                                            {
                                                                case 1:
                                                                    empty23 = oDataTable2.Rows[0]["대표바코드"].ToString();
                                                                    empty24 = string.Empty;
                                                                    empty25 = oDataTable2.Rows[0]["수량"].ToString();
                                                                    empty26 = string.Empty;
                                                                    break;
                                                                case 2:
                                                                    empty23 = oDataTable2.Rows[0]["대표바코드"].ToString();
                                                                    empty24 = oDataTable2.Rows[1]["대표바코드"].ToString();
                                                                    empty25 = oDataTable2.Rows[0]["수량"].ToString();
                                                                    empty26 = oDataTable2.Rows[1]["수량"].ToString();
                                                                    break;
                                                                default:
                                                                    empty23 = string.Empty;
                                                                    empty24 = string.Empty;
                                                                    empty25 = string.Empty;
                                                                    empty26 = string.Empty;
                                                                    break;
                                                            }
                                                            str10 = string.Format(printScript, (object)$"{str6}:{str8}", (object)s배치번호, (object)s박스바코드, (object)s박스바코드구분, (object)s슈트번호, (object)str4, (object)str3, (object)empty23, (object)empty25, (object)empty24, (object)empty26, (object)str9);
                                                            break;
                                                        case "반품유형2":
                                                            str10 = string.Format(printScript, (object)$"{str6}:{str8}", (object)s박스바코드, (object)s박스바코드구분, (object)s배치번호, (object)s슈트번호, (object)str4, (object)str3, (object)num.ToString(), (object)str9);
                                                            break;
                                                        default:
                                                            str10 = string.Format(printScript, (object)str2, (object)s슈트번호, (object)str3, (object)s박스바코드);
                                                            break;
                                                    }


                                                    DataRow rowTemp = 처리성공데이터.NewRow();
                                                    rowTemp["프린트명"] = PasLib.GetPrinterName(s슈트번호);
                                                    rowTemp["프린트str"] = str10;
                                                    rowTemp["배치구분"] = s배치구분;
                                                    rowTemp["슈트번호"] = s슈트번호;
                                                    rowTemp["배치번호"] = s배치번호;

                                                    처리성공데이터.Rows.Add(rowTemp);
                                                    //string printerName = PasLib.GetPrinterName(s슈트번호);
                                                    //if (oClient != null)
                                                    //{
                                                    //    oClient.Close();
                                                    //    oClient = (TcpClient)null;
                                                    //}
                                                    //oClient = new TcpClient();
                                                    //oClient.Connect(printerName, 9100);
                                                    //using (StreamWriter streamWriter = new StreamWriter((Stream)oClient.GetStream(), Encoding.GetEncoding(949)))
                                                    //{
                                                    //    streamWriter.Write(str10);
                                                    //    streamWriter.Flush();
                                                    //    streamWriter.Close();
                                                    //}
                                                    //Thread.Sleep(300);
                                                    break;
                                                }
                                                break;
                                        }

                                        //if (s배치구분 == "출하")
                                        //{
                                        //    DataRow[] dataRowArray = oDataTable1.Select($"슈트번호 = '{s슈트번호}'");
                                        //    string s거명용바코드 = dataRowArray == null || dataRowArray.Length <= 0 ? $"*SLK{s슈트번호}{1.ToString("D4")}*" : $"*{dataRowArray[0]["아이템코드"].ToString()}*";
                                        //    if (flag1)
                                        //        분류.거래명세서발행_박스별(s배치번호, s슈트번호, s거명용바코드);
                                        //    if (flag2)
                                        //        분류.거래명세서발행_토탈(s배치번호, s슈트번호, s거명용바코드);
                                        //}
                                    }
                                }
                            }

                            oScope.Commit();
                        }
                        catch (Exception ex)
                        {
                            Cursor.Current = Cursors.Default;
                            try
                            {
                                oScope.Rollback();
                            }
                            catch (Exception rollbackEx)
                            {
                                MessageBox.Show($"롤백 실패: {rollbackEx.Message}");
                            }

                            MessageBox.Show($"박스 발행 중 오류가 발생했습니다: {ex.Message}");
                            return; // 또는 return으로 메서드 종료
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }

                    foreach(DataRow row in 처리성공데이터.Rows)
                    {
                        string printerName = row["프린트명"].ToString();

                        if (oClient != null)
                        {
                            oClient.Close();
                            oClient = (TcpClient)null;
                        }
                        oClient = new TcpClient();
                        oClient.Connect(printerName, 9100);
                        using (StreamWriter streamWriter = new StreamWriter((Stream)oClient.GetStream(), Encoding.GetEncoding(949)))
                        {
                            streamWriter.Write(row["프린트str"].ToString());
                            streamWriter.Flush();
                            streamWriter.Close();
                        }

                        Thread.Sleep(300);

                        if (row["배치구분"].ToString() == "출하")
                        {
                            string s슈트번호 = row["슈트번호"].ToString();
                            string s배치번호 = row["배치번호"].ToString();
                            DataRow[] dataRowArray = oDataTable1.Select($"슈트번호 = '{s슈트번호}'");
                            string s거명용바코드 = dataRowArray == null || dataRowArray.Length <= 0 ? $"*SLK{s슈트번호}{1.ToString("D4")}*" : $"*{dataRowArray[0]["아이템코드"].ToString()}*";
                            if (flag1)
                                분류.거래명세서발행_박스별(s배치번호, s슈트번호, s거명용바코드);
                            if (flag2)
                                분류.거래명세서발행_토탈(s배치번호, s슈트번호, s거명용바코드);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Cursor.Current = Cursors.Default;
                }
                finally { 
                    Cursor.Current = Cursors.Default;
                    조회_Click((object)null, EventArgs.Empty);
                }
            }
            else
            {

            }
        }

       
    }
}
