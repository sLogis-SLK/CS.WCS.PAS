using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using TR_Common;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00007 : Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();

        #endregion

        #region 초기화

        public frmTRPAS00007()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //SetDataTableBindingInit();
        }

        #endregion

        #region 사용자정의함수

        private void SetDataTableBindingInit()
        {
            try
            {
                #region uGrid2 BindingSource 초기화

                PasWCS.분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0);


                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid2.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid2, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "선택", "순번", "추가배치", "원배치번호", "관리번호", "장비명", "배치구분코드", "분류구분코드", "출하구분코드", "분류방법코드", "패턴구분", "패턴구분코드", "분류상태", "분류상태코드", "배치상태코드", "완료일시");
                Common.SetGridEditColumn(this.uGrid2, null);

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

        #endregion


    }
}
