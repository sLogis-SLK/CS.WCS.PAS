using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PAS.PMP.Report;
using TR_Common;
using TR_Library.Controls;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00002 : BaseForm, IToolBase
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_상품별미출고Table = new DataTable("usp_분류_미출고내역_상품별_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_상품별미출고BS = new BindingSource();

        #endregion

        #region 초기화

        public frmTRPAS00002()
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

                //#region uGrid1 BindingSource 초기화

                분류.미출고상품별조회(m_분류_상품별미출고Table, "", "", 0);

                this.m_분류_상품별미출고BS.DataSource = this.m_분류_상품별미출고Table;
                this.uGrid1.DataSource = this.m_분류_상품별미출고BS;

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "브랜드코드", "브랜드명", "분류번호", "배치번호");
                Common.SetGridEditColumn(this.uGrid1, null);
                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "지시수", "실적수", "부족수");
                this.uGrid1.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                //#endregion

                this.uGrid1.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid1.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.ForeColor = Color.Red;
                this.uGrid1.DisplayLayout.Bands[0].Columns["지시수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid1.DisplayLayout.Bands[0].Columns["지시수"].CellAppearance.ForeColor = Color.Red;
                this.uGrid1.DisplayLayout.Bands[0].Columns["실적수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid1.DisplayLayout.Bands[0].Columns["실적수"].CellAppearance.ForeColor = Color.Red;
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
                DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;

                if (oRow == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                DataTable 상품별미출고 = new DataTable("usp_분류_미출고내역_상품별_Get");
                분류.미출고내역상품별출력(상품별미출고, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), "1");

                if (상품별미출고.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.", this.Text);
                    return;
                }

                string val = $"{상품별미출고.Rows[0]["브랜드코드"].ToString()}:{상품별미출고.Rows[0]["브랜드명"].ToString()}";
                미출고내역_상품별 미출고내역상품별 = new 미출고내역_상품별();
                미출고내역상품별.SetDataSource(상품별미출고);
                미출고내역상품별.SetParameterValue("로컬장비명", (object)oRow["장비명"].ToString());
                미출고내역상품별.SetParameterValue("브랜드명", (object)val);

                Common.PrintPrevView(미출고내역상품별);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        public void OnExcel()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;

                if (oRow == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                DataTable 상품별미출고 = new DataTable("usp_분류_미출고내역_상품별_Get");
                분류.미출고상품별조회(상품별미출고, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), 1);

                if (상품별미출고.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.", this.Text);
                    return;
                }

                Common.SetGridInit(this.uGrid3, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, null);
                Common.SetGridEditColumn(uGrid3, null);

                BindingSource myBinding = new BindingSource();
                myBinding.DataSource = 상품별미출고;
                this.uGrid3.DataSource = myBinding;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    this.uGridExcelExporter1.ExportAsync(uGrid3, saveFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
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
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);
        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid2.ActiveRow == null || this.uGrid2.ActiveRow.Index < 0)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
                분류.미출고상품별조회(m_분류_상품별미출고Table, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        #endregion
    }
}
