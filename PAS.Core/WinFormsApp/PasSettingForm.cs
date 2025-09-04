using Infragistics.Win.UltraWinGrid;
using PAS.Core.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using TR_Common;

namespace PAS.Core.WinFormsApp
{
    public partial class PasSettingForm : Form
    {
        #region 폼개체 선언부

        private DataTable m환경설정Table = new DataTable();
        private BindingSource m환경설정BS = new BindingSource();

        public bool m환경설정변경여부 { get; private set; }

        #endregion

        #region 초기화 관련 메서드 및 override 메서드

        public PasSettingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

            Cursor = Cursors.WaitCursor;

            SetDataTableBindingInit(); //초기 데이터 바인딩

            Cursor = Cursors.Default;

            uGrid1.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.F5)
            {
                if (조회버튼.Enabled && 조회버튼.Visible) 조회버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                if (신규버튼.Enabled && 신규버튼.Visible) 신규버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (수정버튼.Enabled && 수정버튼.Visible) 수정버튼_Click(null, null);
            }
        }

        private void SetDataTableBindingInit()
        {
            try
            {
                //초기값 설정
                m환경설정변경여부 = false;

                //DB접속정보 Groupbox Control 초기Data
                DB접속정보조회();
                //uGrid1 BindingSource 초기화
                장비Grid정보조회();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        #region 사용자정의함수

        private void DB접속정보조회()
        {
            DataTable dt_DB접속정보 = 공통.DB접속정보(GlobalCore.PasDBConnectionString);
            if (dt_DB접속정보 != null && dt_DB접속정보.Rows.Count > 0)
            {
                DataRow row = dt_DB접속정보.Rows[0];
                PAS_DB_IP.Text = row["PAS_DB_IP"].ToString();
                PAS_DB_SERVICE.Text = row["PAS_DB_SERVICE"].ToString();
                PAS_DB_ID.Text = row["PAS_DB_ID"].ToString();
                PAS_DB_PASSWORD.Text = row["PAS_DB_PASSWORD"].ToString();
                HOST_DB_IP.Text = row["HOST_DB_IP"].ToString();
                HOST_DB_SERVICE.Text = row["HOST_DB_SERVICE"].ToString();
                HOST_DB_ID.Text = row["HOST_DB_ID"].ToString();
                HOST_DB_PASSWORD.Text = row["HOST_DB_PASSWORD"].ToString();
            }
        }

        private void 장비Grid정보조회()
        {
            m환경설정Table = 공통.Pas접속정보(GlobalCore.PasDBConnectionString);
            m환경설정BS.DataSource = m환경설정Table;
            uGrid1.DataSource = m환경설정BS;

            Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
            Common.SetGridHiddenColumn(this.uGrid1, null);
            Common.SetGridEditColumn(this.uGrid1, "선택");
        }

        private void 장비등록수정창열기(DataRow row)
        {
            if (row == null) return;

            PasSettingPopupForm frm = new PasSettingPopupForm();
            frm.기초DataRow = row; //기초데이터 생성
            frm.StartPosition = FormStartPosition.CenterParent;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                조회버튼_Click(null, null);
            }
            frm.Dispose();
        }

        #endregion

        #region 버튼 Event

        private void 새로고침버튼_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DB접속정보조회();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DB정보저장버튼_Click(object sender, EventArgs e)
        {
            string msgText = "저장시 변경전 DataBase에 수정된 접속정보를 저장합니다.\r\n\r\n정말 저장 하시겠습니까?";
            if (MessageBox.Show(msgText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
            
            Cursor = Cursors.WaitCursor;
            try
            {
                //환경설정 갱신
                공통.DB접속정보저장(GlobalCore.PasDBConnectionString, PAS_DB_IP.Text, PAS_DB_SERVICE.Text, PAS_DB_ID.Text, PAS_DB_PASSWORD.Text,
                                                                      HOST_DB_IP.Text, HOST_DB_SERVICE.Text, HOST_DB_ID.Text, HOST_DB_PASSWORD.Text);
                //공통.출하라인접속정보저장(GlobalCore.PasDBConnectionString, changedTable);

                m환경설정변경여부 = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                장비Grid정보조회();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void 신규버튼_Click(object sender, EventArgs e)
        {
            장비등록수정창열기(m환경설정Table.NewRow());
        }

        private void 수정버튼_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = uGrid1.ActiveRow;
            if (activeRow == null || !activeRow.IsDataRow) return;
            DataRow row = (activeRow.ListObject as DataRowView)?.Row;
            장비등록수정창열기(row);
        }

        private void 삭제버튼_Click(object sender, EventArgs e)
        {
            string msgText = "정말 삭제 하시겠습니까?\r\n\r\n삭제시 되돌릴수 없습니다.";
            if (MessageBox.Show(msgText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            //위험성이 있어 구현은 해놓고 사용하지 못하게 하였음. 25.09.03 김동준
            MessageBox.Show("위험성이 있어 삭제하지 않았습니다. IT 솔루션팀에 문의하시기 바랍니다.", this.Text);
            return;

            Cursor = Cursors.WaitCursor;
            try
            {
                DataRow[] rows = m환경설정Table.Select("선택 = True");
                //공통.출하라인접속정보삭제(GlobalCore.PasDBConnectionString, rows); 

                foreach (DataRow row in rows)
                {
                    m환경설정Table.Rows.Remove(row); // 또는 row.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #region 기타 Event
        
        private void uGrid1_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                if (e.Row == null) return;
                if (e.Row.Index < 0) return;

                DataRow row = (e.Row.ListObject as DataRowView)?.Row;
                장비등록수정창열기(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion
    }
}
