using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;
using TR_Library.Controls;

namespace PAS.PMP.WinFormsApp
{
    public partial class frmTRPAS00008 : BaseForm
    {
        #region 폼개체 선언부
        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_출하_미발행박스내역Table = new DataTable("usp_출하_미발행박스_Get");



        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_출하_미발행박스내역BS = new BindingSource();

        string _분류번호 = string.Empty;
        string _배치번호 = string.Empty;
        string _장비명 = string.Empty;
        #endregion

        #region 초기화
        public frmTRPAS00008()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SetDataTableBindingInit();
        }

        private void SetDataTableBindingInit()
        {
            #region uGrid1 BindingSource 초기화

            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0, GlobalClass.장비명);

            this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
            this.uGrid1.DataSource = this.m_분류_작업배치그룹BS;

            Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
            Common.SetGridHiddenColumn(this.uGrid1, "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "분류방법코드", "배치상태코드");
            Common.SetGridEditColumn(this.uGrid1, null);

            this.uGrid1.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
            #endregion

            #region uGrid2 BindingSource 초기화

            분류.출하미발행대상조회(m_출하_미발행박스내역Table, "", Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0);

            this.m_출하_미발행박스내역BS.DataSource = this.m_출하_미발행박스내역Table;
            this.uGrid2.DataSource = this.m_출하_미발행박스내역BS;

            Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
            Common.SetGridHiddenColumn(this.uGrid2, "작업일자", "장비명", "박스바코드");
            Common.SetGridEditColumn(this.uGrid2, null);

            Common.uGridSummarySet(this.uGrid2, Infragistics.Win.UltraWinGrid.SummaryType.Count, "운송장번호");
            this.uGrid2.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
            this.uGrid2.DisplayLayout.Bands[0].Columns["운송장번호"].CellAppearance.BackColor = SystemColors.Info;
            this.uGrid2.DisplayLayout.Bands[0].Columns["운송장번호"].CellAppearance.ForeColor = Color.Red;
            #endregion

        }
        #endregion

        #region 사용자정의함수

        private void 조회_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);
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

        #endregion

        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;

                분류.출하미발행대상조회(m_출하_미발행박스내역Table, oRow["분류번호"].ToString(), Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
