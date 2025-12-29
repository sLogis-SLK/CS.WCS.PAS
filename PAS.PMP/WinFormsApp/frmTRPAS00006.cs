using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PAS.Core;
using PAS.PMP.Report;
using PAS.PMP.Utils;
using TR_Common;
using TR_Library.Controls;
using TR_Provider;
using static System.Net.Mime.MediaTypeNames;

namespace PAS.PMP
{
    public partial class frmTRPAS00006 : BaseForm, IToolBase
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_Get");
        private DataTable m_분류_상품발송장대상Table = new DataTable("usp_분류_상품발송장_Get");
        private DataTable m_상품발송대상Set = new DataTable();

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_상품발송대상BS = new BindingSource();

        private Dictionary<string, string> _uGrid2RowKey;

        string _장비명 = string.Empty;
        #endregion

        #region 초기화

        public frmTRPAS00006()
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

                #endregion

                #region uGrid1 BindingSource 초기화

                this.분류_상품발송장_초기화();

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void 분류_상품발송장_초기화()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("점코드", typeof(string));
            dt.Columns.Add("점명", typeof(string));
            dt.Columns.Add("01", typeof(string));
            dt.Columns.Add("02", typeof(string));
            dt.Columns.Add("03", typeof(string));
            dt.Columns.Add("04", typeof(string));
            dt.Columns.Add("05", typeof(string));
            dt.Columns.Add("06", typeof(string));
            dt.Columns.Add("07", typeof(string));
            dt.Columns.Add("08", typeof(string));
            dt.Columns.Add("09", typeof(string));
            dt.Columns.Add("10", typeof(string));
            dt.Columns.Add("C/T수", typeof(string));
            dt.Columns.Add("총계", typeof(string));
            PasTabPage pasTabPage = new PasTabPage();
            pasTabPage.Text = "상품발송장";
            uGrid myGrid = new uGrid();
            myGrid.Dock = DockStyle.Fill;
            Common.SetGridInit(myGrid, false, false, true, false, false, false);
            pasTabPage.Controls.Add(myGrid);
            this.tabControl1.TabPages.Add(pasTabPage);
            pasTabPage.DataSource = dt;
            myGrid.DataSource = (object)pasTabPage.DataSource;
        }

        private void 분류_상품발송장_조회(string s분류번호, string s배치번호)
        {
            분류.분류상품발송장조회(m_분류_상품발송장대상Table, s분류번호, s배치번호, 1);
            this.tabControl1.TabPages.Clear();
            if (this.m_분류_상품발송장대상Table.Rows.Count <= 0)
            {
                this.분류_상품발송장_초기화();
            }
            else
            {
                List<string> stringList = new List<string>();
                foreach (DataRow row in this.m_분류_상품발송장대상Table.Rows)
                {
                    if (!stringList.Contains(row["배송사명"].ToString()))
                        stringList.Add(row["배송사명"].ToString());
                }
                foreach (string s배송사명 in stringList)
                {
                    PasTabPage pasTabPage = new PasTabPage();
                    uGrid myGrid = new uGrid();
                    myGrid.Dock = DockStyle.Fill;
                    Common.SetGridInit(myGrid, false, false, true, true, false, false);
                    pasTabPage.Controls.Add(myGrid);
                    this.tabControl1.TabPages.Add(pasTabPage);
                    pasTabPage.Text = s배송사명;
                    this.m_분류_상품발송장대상Table.Select($"배송사명='{s배송사명}'");
                    pasTabPage.DataSource = this.분류_상품발송장_배송사별(s배송사명, this.m_분류_상품발송장대상Table);
                    myGrid.DataSource = (object) pasTabPage.DataSource;

                }
            }
        }

        private DataTable 분류_상품발송장_배송사별(string s배송사명, DataTable oDtatTable)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("점코드", typeof(string));
            dt.Columns.Add("점명", typeof(string));
            dt.Columns.Add("01", typeof(string));
            dt.Columns.Add("02", typeof(string));
            dt.Columns.Add("03", typeof(string));
            dt.Columns.Add("04", typeof(string));
            dt.Columns.Add("05", typeof(string));
            dt.Columns.Add("06", typeof(string));
            dt.Columns.Add("07", typeof(string));
            dt.Columns.Add("08", typeof(string));
            dt.Columns.Add("09", typeof(string));
            dt.Columns.Add("10", typeof(string));
            dt.Columns.Add("C/T수", typeof(string));
            dt.Columns.Add("총계", typeof(string));
            List<string> stringList = new List<string>();
            foreach (DataRow dataRow in oDtatTable.Select($"배송사명='{s배송사명}'"))
            {
                if (!stringList.Contains(dataRow["점코드"].ToString()))
                    stringList.Add(dataRow["점코드"].ToString());
            }

            foreach (string str1 in stringList)
            {
                DataRow[] dataRowArray1 = oDtatTable.Select($"배송사명='{s배송사명}' AND 점코드='{str1}'");
                int num1 = ConvertUtil.ObjectToint(oDtatTable.Compute("SUM(내품수)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
                int num2 = ConvertUtil.ObjectToint(oDtatTable.Compute("MAX(박스번호)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
                int length = dataRowArray1.Length;
                int num3 = num2 / 10;
                int num4 = num2 % 10;
                string empty = string.Empty;
                if (num4 > 0)
                    ++num3;
                for (int index1 = 0; index1 < num3; ++index1)
                {
                    DataRow row = dt.NewRow();
                    if (index1 == 0)
                    {
                        row[0] = (object)dataRowArray1[0]["점코드"].ToString();
                        row[1] = (object)dataRowArray1[0]["점명"].ToString();
                    }
                    int num5 = num4 != 0 ? (index1 == num3 - 1 ? num4 : 10) : 10;
                    for (int index2 = 0; index2 < num5; ++index2)
                    {
                        int num6 = index1 * 10 + (index2 + 1);
                        DataRow[] dataRowArray2 = oDtatTable.Select($"배송사명='{s배송사명}' AND 점코드='{str1}' AND 박스번호='{num6.ToString("D3")}'");
                        string str2 = dataRowArray2 == null || dataRowArray2.Length <= 0 ? string.Empty : dataRowArray2[0]["내품수"].ToString();
                        int num7 = num6 > 10 ? num6 % 10 : num6;
                        if (num7 == 0)
                            num7 = 10;
                        row[1 + num7] = (object)str2;
                    }
                    if (index1 == 0)
                    {
                        row[12] = (object)length;
                        row[13] = (object)num1;
                    }
                    dt.Rows.Add(row);
                }
            }

            return dt.Copy(); ;
        }

        #endregion

        #region IToolBase 멤버


        public void OnPrint(bool bPrevView)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.m_분류_상품발송장대상Table == null || this.m_분류_상품발송장대상Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.");
                    return;
                }

                string val1 = $"{this.m_분류_상품발송장대상Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_상품발송장대상Table.Rows[0]["브랜드명"].ToString()}";
                string val2 = this.m_분류_상품발송장대상Table.Rows[0]["배치번호"].ToString();
                PasTabPage selectedTab = (PasTabPage)this.tabControl1.SelectedTab;
                string text = selectedTab.Text;
                상품발송장_매장별 상품발송장매장별 = new 상품발송장_매장별();
                상품발송장매장별.SetDataSource(selectedTab.DataSource);
                상품발송장매장별.SetParameterValue("로컬장비명", (object)_장비명);
                상품발송장매장별.SetParameterValue("브랜드명", (object)val1);
                상품발송장매장별.SetParameterValue("배치번호", (object)val2);
                상품발송장매장별.SetParameterValue("배송사", (object)text);
                int val3 = 0;
                int val4 = 0;
                foreach (DataRow row in (InternalDataCollectionBase)selectedTab.DataSource.Rows)
                {
                    val3 += ConvertUtil.ObjectToint(row["C/T수"]);
                    val4 += ConvertUtil.ObjectToint(row["총계"]);
                }
                상품발송장매장별.SetParameterValue("CT수", (object)val3);
                상품발송장매장별.SetParameterValue("총계", (object)val4);

                Common.PrintPrevView(상품발송장매장별);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void OnExcel()
        {
            try
            {
                if (this.m_분류_상품발송장대상Table == null || this.m_분류_상품발송장대상Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.");
                    return;
                }

                string str1 = $"{this.m_분류_상품발송장대상Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_상품발송장대상Table.Rows[0]["브랜드명"].ToString()}";
                string str2 = this.m_분류_상품발송장대상Table.Rows[0]["배치번호"].ToString();
                PasTabPage selectedTab = (PasTabPage)this.tabControl1.SelectedTab;
                string text = selectedTab.Text;
                DataTable oDataTable = selectedTab.DataSource.Copy();
                oDataTable.Columns.Add("브랜드명", typeof(string));
                oDataTable.Columns.Add("배치번호", typeof(string));
                oDataTable.Columns.Add("배송사", typeof(string));
                oDataTable.Columns["배송사"].SetOrdinal(0);
                oDataTable.Columns["배치번호"].SetOrdinal(0);
                oDataTable.Columns["브랜드명"].SetOrdinal(0);
                foreach (DataRow row in (InternalDataCollectionBase)oDataTable.Rows)
                {
                    if (row["점코드"].ToString() != string.Empty)
                    {
                        row["브랜드명"] = (object)str1;
                        row["배치번호"] = (object)str2;
                        row["배송사"] = (object)text;
                    }
                }
                oDataTable.AcceptChanges();


                Common.SetGridInit(this.uGrid1, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                Common.SetGridEditColumn(uGrid1, null);
                BindingSource myBinding = new BindingSource();
                myBinding.DataSource = oDataTable;
                this.uGrid1.DataSource = myBinding;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    this.uGridExcelExporter1.ExportAsync(uGrid1, saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public void OnControlVisible(object sender, ControlVisibleEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnBrandChange(object sender, BrandChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event



        private void 조회_Click(object sender, EventArgs e)
        {
            _uGrid2RowKey = UltraGridHelper.RememberActiveRow(
                uGrid2,
                "배치번호",
                "분류번호"
            );
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            UltraGridHelper.RestoreActiveRow(uGrid2, _uGrid2RowKey);
        }

        private void uGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            this.조회_Click(null, null);
        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
            _장비명 = oRow["장비명"].ToString();
            this.분류_상품발송장_조회(oRow["분류번호"].ToString(), oRow["배치번호"].ToString());

        }




        #endregion

        
    }
}
