using System;
using System.Collections;
using System.Data;
using System.Net.Sockets;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using TR_Common;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00005 : Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_마지막박스내역Table = new DataTable("usp_분류_마지막박스내역_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_마지막박스내역BS = new BindingSource();

        string _분류번호 = string.Empty;
        string _배치번호 = string.Empty;
        string _장비명 = string.Empty;
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

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0, "모두");

                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid2.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid2, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid2, null);

                this.uGrid2.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";

                #endregion

                #region uGrid1 BindingSource 초기화

                분류.마지막박스내역조회(m_분류_마지막박스내역Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), "", "", 0);

                this.m_분류_마지막박스내역BS.DataSource = this.m_분류_마지막박스내역Table;
                this.uGrid1.DataSource = this.m_분류_마지막박스내역BS;

                Common.SetGridInit(this.uGrid1, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호", "서브슈트번호");
                Common.SetGridEditColumn(this.uGrid1, "선택");
                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "실적수");

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
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1, "모두");
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
                분류.마지막박스내역조회(m_분류_마지막박스내역Table, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), _장비명, 1);
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
            foreach (DataGridViewRow row in (IEnumerable)this.uGrid1.Rows)
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


        }
    }
}
