using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using TR_Common;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00003 : Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_Get");
        private DataTable m_분류_박스재발행Table = new DataTable("usp_분류_박스바코드재발행_Get");
        private DataTable m_분류_박스재발행_슈트별Table = new DataTable("usp_분류_박스바코드재발행_슈트별_Get");
        private DataTable m_분류_박스재발행_슈트별상세Table = new DataTable("usp_분류_박스바코드재발행_슈트별상세_Get");
        

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_박스재발행BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별상세BS = new BindingSource();

        string _장비명 = "";
        string _배치번호 = "";
        string _분류번호 = "";
        string _슈트번호 = "";
        string _서브슈트번호 = "";
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

                PasWCS.분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0);



                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid4.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid4, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid4, "선택", "순번", "추가배치", "원배치번호", "관리번호", "장비명", "배치구분코드", "분류구분코드", "출하구분코드", "분류방법코드", "패턴구분", "패턴구분코드", "분류상태", "분류상태코드", "배치상태코드", "완료일시");
                Common.SetGridEditColumn(this.uGrid4, null);

                #endregion

                #region uGrid1 BindingSource 초기화

                PasWCS.분류.박스재발행조회(m_분류_박스재발행Table, "", "", "", 0);

                this.m_분류_박스재발행BS.DataSource = this.m_분류_박스재발행Table;
                this.uGrid1.DataSource = this.m_분류_박스재발행BS;

                Common.SetGridInit(this.uGrid1, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호", "서브슈트번호", "배치구분코드", "배치구분", "출력여부");
                Common.SetGridEditColumn(this.uGrid1, null);

                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");

                #endregion

                #region uGrid2 BindingSource 초기화

                PasWCS.분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, "", "", "", "", "", 0);

                this.m_분류_박스재발행슈트별BS.DataSource = this.m_분류_박스재발행_슈트별Table;
                this.uGrid2.DataSource = this.m_분류_박스재발행슈트별BS;

                Common.SetGridInit(this.uGrid2, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류번호", "배치번호", "슈트번호", "서브슈트번호", "박스바코드", "박스바코드구분");

                Common.SetGridEditColumn(this.uGrid2, null);
                Common.uGridSummarySet(this.uGrid2, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");

                #endregion

                #region uGrid3 BindingSource 초기화

                PasWCS.분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, "", "", "", "", "", "", 0);

                this.m_분류_박스재발행슈트별상세BS.DataSource = this.m_분류_박스재발행_슈트별상세Table;
                this.uGrid3.DataSource = this.m_분류_박스재발행슈트별상세BS;

                Common.SetGridInit(this.uGrid3, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "IDX", "아이템코드", "조정", "잔여", "센터코드", "센터명", "배치명");

                Common.SetGridEditColumn(this.uGrid3, null);

                #endregion

            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Name, ex);
            }
        }

        #endregion

        #region IToolBase 멤버

        #endregion

        #region Event

        private void 조회_Click(object sender, EventArgs e)
        {
            PasWCS.분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);
        }

        private void uGrid4_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid4.ActiveRow.ListObject).Row;
            _장비명 = oRow["장비명"].ToString();
            _배치번호 = oRow["배치번호"].ToString();
            _분류번호 = oRow["분류번호"].ToString();
            PasWCS.분류.박스재발행조회(m_분류_박스재발행Table, _분류번호, _장비명, _배치번호, 1);
            
        }


        #endregion

        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
            _슈트번호 = oRow["슈트번호"].ToString();
            _서브슈트번호 = oRow["서브슈트번호"].ToString();
            PasWCS.분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, _분류번호, _장비명, _배치번호, _슈트번호, _서브슈트번호, 1);
        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
            PasWCS.분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, _분류번호, _장비명, _배치번호, _슈트번호, _서브슈트번호, oRow["박스번호"].ToString(), 1);
        }
    }
}
