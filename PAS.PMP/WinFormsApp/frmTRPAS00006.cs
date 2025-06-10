using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PAS.Core;
using TR_Common;
using TR_Library.Controls;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00006 : Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_Get");
        private DataTable m_분류_상품발송장대상Table = new DataTable("usp_분류_상품발송장_Get");
        private DataTable m_상품발송대상Set = new DataTable();

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_상품발송대상BS = new BindingSource();

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

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0);



                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid2.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid2, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "선택", "순번", "추가배치", "원배치번호", "관리번호", "장비명", "배치구분코드", "분류구분코드", "출하구분코드", "분류방법코드", "패턴구분", "패턴구분코드", "분류상태", "분류상태코드", "배치상태코드", "완료일시");
                Common.SetGridEditColumn(this.uGrid2, null);

                #endregion

                #region uGrid1 BindingSource 초기화

                this.분류_상품발송장_초기화();

                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Name, ex);
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
            Common.SetGridInit(myGrid, false, false, true, true, false, false);
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
                    Common.SetGridHiddenColumn(myGrid, "슈트번호");
                    pasTabPage.Controls.Add(myGrid);
                    this.tabControl1.TabPages.Add(pasTabPage);
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
            foreach (DataRow dataRow in dt.Select($"배송사명='{s배송사명}'"))
            {
                if (!stringList.Contains(dataRow["점코드"].ToString()))
                    stringList.Add(dataRow["점코드"].ToString());
            }

            foreach (string str1 in stringList)
            {
                DataRow[] dataRowArray1 = oDtatTable.Select($"배송사명='{s배송사명}' AND 점코드='{str1}'");
                int num1 = ConvertUtil.C2I(oDtatTable.Compute("SUM(내품수)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
                int num2 = ConvertUtil.C2I(oDtatTable.Compute("MAX(박스번호)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
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
                        DataRow[] dataRowArray2 = dt.Select($"배송사명='{s배송사명}' AND 점코드='{str1}' AND 박스번호='{num6.ToString("D3")}'");
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

        #endregion

        #region Event



        private void 조회_Click(object sender, EventArgs e)
        {
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);
        }




        #endregion

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
            this.분류_상품발송장_조회(oRow["분류번호"].ToString(), oRow["배치번호"].ToString());

        }
    }
}
