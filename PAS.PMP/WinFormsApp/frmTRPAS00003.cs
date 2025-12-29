using System;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;
using TR_Common;
using PAS.Core;
using System.IO;
using System.Text;
using System.Threading;
using PAS.PMP.Report;
using PAS.PMP.Services;
using System.Drawing;
using Infragistics.Win.UltraWinGrid;
using System.Linq;
using PAS.PMP.PasWCS;
using System.Collections.Generic;
using PAS.PMP.Utils;

namespace PAS.PMP
{
    public partial class frmTRPAS00003 : BaseForm, IToolBase
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_박스재발행Table = new DataTable("usp_분류_박스바코드재발행_Get_JHG");
        private DataTable m_분류_박스재발행_슈트별Table = new DataTable("usp_분류_박스바코드재발행_슈트별_Get");
        private DataTable m_분류_박스재발행_슈트별상세Table = new DataTable("usp_분류_박스바코드재발행_슈트별상세_Get");
        private DataTable m_분류_박스별패킹내역Table = new DataTable("usp_분류_박스별패킹내역_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_박스재발행BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별상세BS = new BindingSource();

        string _배치번호 = "";
        string _분류번호 = "";
        string _슈트번호 = "";
        string _서브슈트번호 = "";
        string _박스번호 = "";
        string _장비명 = string.Empty;
        string _배치구분 = string.Empty;

        private Dictionary<string, string> _uGrid4RowKey;
        #endregion

        #region 초기화

        public frmTRPAS00003()
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
                #region uGrid4 BindingSource 초기화

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0, GlobalClass.장비명);



                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid4.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid4, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid4, "분류방법코드", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid4, null);

                #endregion

                #region uGrid1 BindingSource 초기화

                분류.박스재발행조회(m_분류_박스재발행Table, "", "", 0);

                this.m_분류_박스재발행BS.DataSource = this.m_분류_박스재발행Table;
                this.uGrid1.DataSource = this.m_분류_박스재발행BS;

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호", "서브슈트번호", "배치구분코드", "배치구분", "출력여부");
                Common.SetGridEditColumn(this.uGrid1, null);

                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");
                this.uGrid1.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                #endregion

                #region uGrid2 BindingSource 초기화

                분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, "", "", "", "", 0);

                this.m_분류_박스재발행슈트별BS.DataSource = this.m_분류_박스재발행_슈트별Table;
                this.uGrid2.DataSource = this.m_분류_박스재발행슈트별BS;

                Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류번호", "배치번호", "슈트번호", "서브슈트번호", "박스바코드", "박스바코드구분");

                Common.SetGridEditColumn(this.uGrid2, null);
                Common.uGridSummarySet(this.uGrid2, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");
                this.uGrid2.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                #endregion

                #region uGrid3 BindingSource 초기화

                분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, "", "", "", "", "", 0);

                this.m_분류_박스재발행슈트별상세BS.DataSource = this.m_분류_박스재발행_슈트별상세Table;
                this.uGrid3.DataSource = this.m_분류_박스재발행슈트별상세BS;

                Common.SetGridInit(this.uGrid3, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "IDX", "아이템코드", "브랜드코드", "브랜드명", "센터코드", "센터명", "배치명");

                Common.SetGridEditColumn(this.uGrid3, "조정");

                #endregion

                this.출력대상유형.Value = "10";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region IToolBase 멤버
        public void OnPrint(bool bPrevView)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (_배치번호 == "")
                {
                    MessageBox.Show("출력할 배치를 선택하세요");
                    return;
                }

                if (_슈트번호 == "")
                {
                    MessageBox.Show("출력할 배치를 선택하세요");
                    return;
                }

                string oValue = string.Empty;

                oValue = 출력대상유형.Value.ToString() != "20" ? "" : _슈트번호;
                분류.박스별패킹내역(this.m_분류_박스별패킹내역Table, _분류번호, _배치번호, oValue);
                if (this.m_분류_박스별패킹내역Table == null || this.m_분류_박스별패킹내역Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.");
                    return;
                }

                string val = $"{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드명"].ToString()}";
                패킹내역_박스별 패킹내역박스별 = new 패킹내역_박스별();
                패킹내역박스별.SetDataSource(this.m_분류_박스별패킹내역Table);
                패킹내역박스별.SetParameterValue("로컬장비명", (object)_장비명);
                패킹내역박스별.SetParameterValue("브랜드명", (object)val);

                Common.PrintPrevView(패킹내역박스별);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void OnExcel()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (_배치번호 == "")
                {
                    MessageBox.Show("출력할 배치를 선택하세요");
                    return;
                }

                if (_슈트번호 == "")
                {
                    MessageBox.Show("출력할 배치를 선택하세요");
                    return;
                }

                string oValue = string.Empty;

                oValue = 출력대상유형.Value.ToString() != "20" ? "" : _슈트번호;
                분류.박스별패킹내역(this.m_분류_박스별패킹내역Table, _분류번호, _배치번호, oValue);
                if (this.m_분류_박스별패킹내역Table == null || this.m_분류_박스별패킹내역Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.");
                    return;
                }

                string val = $"{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드명"].ToString()}";
                패킹내역_박스별 패킹내역박스별 = new 패킹내역_박스별();
                패킹내역박스별.SetDataSource(this.m_분류_박스별패킹내역Table);
                패킹내역박스별.SetParameterValue("로컬장비명", (object)_장비명);
                패킹내역박스별.SetParameterValue("브랜드명", (object)val);

                Common.SetGridInit(this.uGrid5, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid5, null);
                Common.SetGridEditColumn(uGrid5, null);
                BindingSource myBinding = new BindingSource();
                myBinding.DataSource = m_분류_박스별패킹내역Table;
                this.uGrid5.DataSource = myBinding;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    this.uGridExcelExporter1.ExportAsync(uGrid5, saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void OnControlVisible(object sender, ControlVisibleEventArgs e)
        {

        }

        public void OnBrandChange(object sender, BrandChangeEventArgs e)
        {

        }

        #endregion

        #region Event

        private void 조회_Click(object sender, EventArgs e)
        {
            _uGrid4RowKey = UltraGridHelper.RememberActiveRow(
                uGrid4,
                "배치번호",
                "분류번호"
            );
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            UltraGridHelper.RestoreActiveRow(uGrid4, _uGrid4RowKey);
        }

        private void uGrid4_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid4.ActiveRow.ListObject).Row;
            _배치번호 = oRow["배치번호"].ToString();
            _분류번호 = oRow["분류번호"].ToString();
            _장비명 = oRow["장비명"].ToString();
            분류.박스재발행조회(m_분류_박스재발행Table, _분류번호,  _배치번호, 1);
            
        }

        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
            _슈트번호 = oRow["슈트번호"].ToString();
            _서브슈트번호 = oRow["서브슈트번호"].ToString();
            _배치구분 = oRow["배치구분"].ToString();
            분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, _분류번호, _배치번호, _슈트번호, _서브슈트번호, 1);
        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
            _박스번호 = oRow["박스번호"].ToString();
            분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, _분류번호, _배치번호, _슈트번호, _서브슈트번호, oRow["박스번호"].ToString(), 1);
        }

        private void 박스풀_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataRow[] dataRowArray = this.m_분류_박스재발행_슈트별상세Table.Select("수량 <> 잔여");

            if (dataRowArray == null || dataRowArray.Length <= 0)
            {
                MessageBox.Show("이동할 대상이 없습니다.");
                return;
            }

            if (_슈트번호 == null)
            {
                MessageBox.Show("슈트번호를 선택하세요.");
                return;
            }

            if (this.uGrid2.ActiveRow == null || this.uGrid3.ActiveRow.Index < 0)
            {
                MessageBox.Show("이동할 대상이 없습니다.");
                return;
            }

            if (this._박스번호 != "")
            {
                MessageBox.Show("이미 발행된 박스번호 입니다.");
                return;
            }

            try
            {
                DataTable dataTable = new DataTable("박스풀");
                dataTable.Columns.Add("아이템코드", typeof(string));
                dataTable.Columns.Add("조정", typeof(int));

                foreach (DataRow row in dataRowArray)
                    dataTable.Rows.Add(row["아이템코드"], row["조정"]);

                string s마지막박스여부 = "0";
                using (StringWriter writer = new StringWriter())
                {
                    dataTable.WriteXml(writer);
                    string xml = writer.ToString();

                    분류.미발행_대상박스풀(xml, _분류번호, GlobalClass.장비명, _슈트번호, s마지막박스여부);
                }
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.조회_Click((object)null, EventArgs.Empty);
            }
        }

        private void 재발행_Click(object sender, EventArgs e)
        {
            TcpClient oClient = (TcpClient)null;
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
            string str1 = DateTime.Now.ToString("yyyy-MM-dd");
            string empty12 = string.Empty;
            string empty13 = string.Empty;
            string empty14 = string.Empty;
            string empty15 = string.Empty;
            string empty16 = string.Empty;
            string empty17 = string.Empty;
            string empty18 = string.Empty;

            DataRow oRow = ((DataRowView)uGrid4.ActiveRow.ListObject).Row;
            DataRow oRowShut = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
            DataRow oRowBox = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;

            if (oRow == null)
            {
                MessageBox.Show("배치를 선택해 주세요.");
                return;
            }

            if (oRowShut == null)
            {
                MessageBox.Show("슈트를 선택해 주세요.");
                return;
            }

            if (oRowBox == null)
            {
                MessageBox.Show("박스를 선택해 주세요.");
                return;
            }

            if (this._배치구분 == "멀티반품")
            {
                MessageBox.Show("\"선택한 슈트는 테블릿 분류 대상입니다.\\r\\n\\r\\n테블릿 서버에서 재발행해 주세요.");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {

                string str2 = oRow["배치번호"].ToString();
                string s패턴구분 = oRow["패턴구분"].ToString();
                string s슈트번호 = oRowShut["슈트번호"].ToString();
                string str3 = oRowShut["점코드"].ToString();
                string str4 = oRowShut["점명"].ToString();
                string s배치구분 = oRowShut["배치구분"].ToString();
                string str5 = oRowShut["출력여부"].ToString();
                string s박스바코드 = oRowBox["박스바코드"].ToString();
                string s박스바코드구분 = oRowBox["박스바코드구분"].ToString();
                string str6 = oRowBox["박스번호"].ToString();
                string str7 = oRowBox["내품수"].ToString();
                int i박스풀대상수 = this.m_분류_박스재발행_슈트별상세Table.Rows.Count - 1;
                string empty19;
                string empty20;

                string empty21;
                if (i박스풀대상수 > 0)
                {
                    empty19 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["브랜드코드"].ToString();
                    empty20 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["브랜드명"].ToString();
                    empty21 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["배치명"].ToString();
                }
                else
                {
                    empty19 = string.Empty;
                    empty20 = string.Empty;
                    empty21 = string.Empty;
                }
                
                switch (s배치구분)
                {
                    case "패키지":
                        string printerName1 = PasLib.GetPrinterName("패키지");
                        DataTable oDataTable = this.m_분류_박스재발행_슈트별상세Table.Copy();
                        oDataTable.Rows.RemoveAt(0);
                        oDataTable.AcceptChanges();
                        PasLib.GetPrintScript2(printerName1, s박스바코드, s박스바코드구분, oClient, oDataTable);
                        return;
                    case "반품":
                    case "멀티반품":
                        s패턴구분 = i박스풀대상수 <= 2 ? "반품유형1" : "반품유형2";
                        break;
                }

                if (string.IsNullOrEmpty(str7) || !(str7 != "0") || !(str5 == "1"))
                    return;

                string printScript = PasLib.GetPrintScript(s패턴구분, s배치구분, i박스풀대상수);
                string str8;
                switch (s패턴구분)
                {
                    case "사용안함":
                        str8 = string.Empty;
                        break;
                    case "출고유형":
                        str8 = string.Format(printScript, (object)$"{empty19}:{empty20}", (object)str4, (object)s슈트번호, (object)str6, (object)str7, (object)s박스바코드, (object)str1);
                        break;
                    case "반품유형1":
                        string empty22;
                        string empty23;
                        string empty24;
                        string empty25;
                        switch (i박스풀대상수)
                        {
                            case 1:
                                empty22 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["대표바코드"].ToString();
                                empty23 = string.Empty;
                                empty24 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["수량"].ToString();
                                empty25 = string.Empty;
                                break;
                            case 2:
                                empty22 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["대표바코드"].ToString();
                                empty23 = this.m_분류_박스재발행_슈트별상세Table.Rows[2]["대표바코드"].ToString();
                                empty24 = this.m_분류_박스재발행_슈트별상세Table.Rows[1]["수량"].ToString();
                                empty25 = this.m_분류_박스재발행_슈트별상세Table.Rows[2]["수량"].ToString();
                                break;
                            default:
                                empty22 = string.Empty;
                                empty23 = string.Empty;
                                empty24 = string.Empty;
                                empty25 = string.Empty;
                                break;
                        }
                        str8 = string.Format(printScript, (object)$"{empty19}:{empty21}", (object)str2, (object)s박스바코드, (object)s박스바코드구분, (object)s슈트번호, (object)str6, (object)str7, (object)empty22, (object)empty24, (object)empty23, (object)empty25, (object)str1);
                        break;
                    case "반품유형2":
                        str8 = string.Format(printScript, (object)$"{empty19}:{empty21}", (object)s박스바코드, (object)s박스바코드구분, (object)str2, (object)s슈트번호, (object)str6, (object)str7, (object)i박스풀대상수.ToString(), (object)str1);
                        break;
                    default:
                        str8 = string.Format(printScript, (object)str4, (object)s슈트번호, (object)str7, (object)s박스바코드);
                        break;
                }

                string printerName2 = PasLib.GetPrinterName(s슈트번호);
                TcpClient tcpClient1;
                if (oClient != null)
                {
                    oClient.Close();
                    tcpClient1 = (TcpClient)null;
                }
                TcpClient tcpClient2 = new TcpClient();
                tcpClient2.Connect(printerName2, 9100);
                using (StreamWriter streamWriter = new StreamWriter((Stream)tcpClient2.GetStream(), Encoding.GetEncoding(949)))
                {
                    streamWriter.Write(str8);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                Thread.Sleep(300);
                if (tcpClient2 != null)
                {
                    tcpClient2.Close();
                    tcpClient1 = (TcpClient)null;
                }
                string oValue = $"[재발행] {str2},{s슈트번호},{str3},{str6},{s박스바코드}";
                분류.작업로그생성(oValue);

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
               Cursor.Current = Cursors.Default;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.조회_Click((object)null, EventArgs.Empty);
            }
        }

        private void uGrid3_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            object 조정 = e.Cell.Value;
            var row = e.Cell.Row;

            string 수량 = row.Cells["수량"].Value.ToString();
            string 잔여 = row.Cells["잔여"].Value.ToString();

            int num1 = ConvertUtil.ObjectToint(수량);
            int num2 = ConvertUtil.ObjectToint(조정);
            int num3 = ConvertUtil.ObjectToint(잔여);
            string str = row.Cells["아이템코드"].Value.ToString();

            DataRow[] dataRowArray = this.m_분류_박스재발행_슈트별상세Table.Select($"아이템코드='{str}'");

            if (dataRowArray == null || dataRowArray.Length <= 0)
                return;

            if (num1 - num2 < 0)
            {
                MessageBox.Show("조정수가 실적수보다 많을 수 없습니다.");
                row.Cells["조정"].Value = (object)(num1 - num3); ;
                row.Cells["잔여"].Value = num3;
            }
            else
            {
                dataRowArray[0]["잔여"] = (object)(num1 - num2);
                this.m_분류_박스재발행_슈트별상세Table.AcceptChanges();
            }


            #endregion


        }
    }
}
