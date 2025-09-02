using CrystalDecisions.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TR_Common;
using TR_Library.Controls;

namespace PAS.PMP
{
    public partial class frmTRPAS00001 : BaseForm, IToolBase
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_슈트별미출고Table = new DataTable("usp_분류_미출고내역_슈트별_Get");
        private DataTable m_분류_슈트별미출고상세Table = new DataTable("usp_분류_미출고내역_슈트별상세_Get");
        private DataTable m_분류_미출고내역_슈트별출력용_Table = new DataTable("usp_분류_미출고내역_슈트별출력용_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_슈트별미출고BS = new BindingSource();
        private BindingSource m_분류_슈트별미출고상세BS = new BindingSource();

        string _배치번호 = "";
        string _분류번호 = "";

        enum enum신규입력
        {
            신규,
            신규취소
        }

        //private enum신규입력 입력여부
        //{
        //    get
        //    {
        //        if (신규버튼.Text == "[F6]신규") return enum신규입력.신규;
        //        return enum신규입력.신규취소;
        //    }
        //    set
        //    {
        //        if (value == enum신규입력.신규)
        //        {
        //            신규버튼.Text = "[F6]신규취소"; //TEXT 는 반대로 설정
        //            소속코드.ReadOnly = false;
        //            브랜드코드.ReadOnly = false;
        //            센터코드.ReadOnly = false;
        //        }
        //        else
        //        {
        //            신규버튼.Text = "[F6]신규";
        //            소속코드.ReadOnly = true;
        //            브랜드코드.ReadOnly = true;
        //            센터코드.ReadOnly = true;
        //        }
        //    }
        //}

        #endregion

        #region 초기화

        public frmTRPAS00001()
        {
            InitializeComponent();
        }

        private void frmTRPAS00001_Load(object sender, EventArgs e)
        {
            SetDataTableBindingInit();
        }

        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    SetDataTableBindingInit();
        //}

        #endregion

        #region 사용자정의함수

        private void SetDataTableBindingInit()
        {
            try
            {
                //#region uGrid3 BindingSource 초기화
                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.조회시작일.Value).ToString("yyyyMMdd"), 0, GlobalClass.장비명);


                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid3.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid3, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "분류방법코드", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid3, null);
                this.uGrid3.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";


                분류.미출고슈트별조회(m_분류_슈트별미출고Table, "", "", 0);

                this.m_분류_슈트별미출고BS.DataSource = this.m_분류_슈트별미출고Table;
                this.uGrid1.DataSource = this.m_분류_슈트별미출고BS;

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridEditColumn(this.uGrid1, null);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호");
                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "부족수");
                this.uGrid1.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                this.uGrid1.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid1.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.ForeColor = Color.Red;


                분류.미출고슈트별상세조회(m_분류_슈트별미출고상세Table, "", "", "", 0);

                this.m_분류_슈트별미출고상세BS.DataSource = this.m_분류_슈트별미출고상세Table;
                this.uGrid2.DataSource = this.m_분류_슈트별미출고상세BS;

                Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, null);
                Common.SetGridEditColumn(this.uGrid2, null);
                
                Common.uGridSummarySet(this.uGrid2, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "부족수");
                this.uGrid2.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                this.uGrid2.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid2.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.ForeColor = Color.Red;

                this.출력대상유형.Value = "10"; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        private void frmTRPAS00001_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F5)
            //{
            //    조회버튼_Click(null, null);
            //}
            //else if (e.KeyCode == Keys.F6)
            //{
            //    신규버튼_Click(null, null);
            //}
            //else if (e.KeyCode == Keys.F7)
            //{
            //    저장버튼_Click(null, null);
            //}
        }

        private void uGrid3_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid3.ActiveRow ==  null || this.uGrid3.ActiveRow.Index < 0)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid3.ActiveRow.ListObject).Row;
                _배치번호 = oRow["배치번호"].ToString();
                _분류번호 = oRow["분류번호"].ToString();
                분류.미출고슈트별조회(m_분류_슈트별미출고Table, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), 1);
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

        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid1.ActiveRow == null || this.uGrid1.ActiveRow.Index < 0)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
                분류.미출고슈트별상세조회(m_분류_슈트별미출고상세Table, _분류번호, _배치번호, oRow["슈트번호"].ToString(), 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                Cursor = Cursors.Default;
            }
            finally
            {
                Cursor= Cursors.Default;
            }
        }


        private void 조회_Click(object sender, EventArgs e)
        {
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.조회시작일.Value).ToString("yyyyMMdd"), 1);
        }

        public void OnPrint(bool bPrevView)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DataRow oRow = ((DataRowView)uGrid3.ActiveRow.ListObject).Row;

                if (oRow == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                string s분류번호 = oRow["분류번호"].ToString();
                string s배치번호 = oRow["배치번호"].ToString();
                string oValue3 = string.Empty;

                DataRow oRowSute = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;

                if (oRowSute == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                oValue3 = this.출력대상유형.Value == (object)"20" ? oRowSute["슈트번호"].ToString() : string.Empty;
                분류.미출고내역슈트별출력(this.m_분류_미출고내역_슈트별출력용_Table, s분류번호, s배치번호, oValue3);

                if (this.m_분류_미출고내역_슈트별출력용_Table == null || this.m_분류_미출고내역_슈트별출력용_Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.", this.Text);
                }
                else
                {
                    string val = $"{this.m_분류_미출고내역_슈트별출력용_Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_미출고내역_슈트별출력용_Table.Rows[0]["브랜드명"].ToString()}";
                    미출고내역_슈트별 미출고내역슈트별 = new 미출고내역_슈트별();
                    미출고내역슈트별.SetDataSource(this.m_분류_미출고내역_슈트별출력용_Table);
                    미출고내역슈트별.SetParameterValue("로컬장비명", GlobalClass.장비명);
                    미출고내역슈트별.SetParameterValue("브랜드명", (object)val);

                    Common.PrintPrevView(미출고내역슈트별);
                }
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
            Cursor.Current = Cursors.WaitCursor;
            
            try
            {
                DataRow oRow = ((DataRowView)uGrid3.ActiveRow.ListObject).Row;

                if (oRow == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                string s분류번호 = oRow["분류번호"].ToString();
                string s배치번호 = oRow["배치번호"].ToString();
                string oValue3 = string.Empty;

                DataRow oRowSute = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;

                if (oRowSute == null)
                {
                    MessageBox.Show("출력할 배치를 선택하세요.", this.Text);
                    return;
                }

                oValue3 = this.출력대상유형.Value == (object)"20" ? oRowSute["슈트번호"].ToString() : string.Empty;
                분류.미출고내역슈트별출력(this.m_분류_미출고내역_슈트별출력용_Table, s분류번호, s배치번호, oValue3);

                if (this.m_분류_미출고내역_슈트별출력용_Table == null || this.m_분류_미출고내역_슈트별출력용_Table.Rows.Count <= 0)
                {
                    MessageBox.Show("출력할 대상이 없습니다.", this.Text);
                    return;
                }

                Common.SetGridInit(this.uGrid4, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid4, null);
                Common.SetGridEditColumn(uGrid4, null);
                BindingSource myBinding = new BindingSource();
                myBinding.DataSource = m_분류_미출고내역_슈트별출력용_Table;
                this.uGrid4.DataSource = myBinding;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    this.uGridExcelExporter1.ExportAsync(uGrid4, saveFileDialog1.FileName);
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
      
        }

        public void OnBrandChange(object sender, BrandChangeEventArgs e)
        {
          
        }

   
    }

}