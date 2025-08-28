using Infragistics.Win.UltraWinGrid;
using PAS.PMP.PasWCS;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TR_Common;
using TR_Library.Controls;

namespace PAS.PMP
{
    public partial class frmTRDLG00064 : BaseForm
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_PAS_배송사변경Table = new DataTable("usp_PAS_배송사변경_Get");
        private DataTable m_관리_배송사변경Table = new DataTable("usp_관리_배송사변경_Get");

        private BindingSource m_분류_작업요약_배치그룹별BS = new BindingSource();
        private BindingSource m_PAS_배송사변경BS = new BindingSource();
        private BindingSource m_관리_배송사변경BS = new BindingSource();

        #endregion

        #region 초기화

        public frmTRDLG00064()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
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
                #region uGrid1 BindingSource 초기화

                분류.배치리스트조회(m_분류_작업요약_배치그룹별Table, null, 0);

                m_분류_작업요약_배치그룹별BS.DataSource = m_분류_작업요약_배치그룹별Table;
                uGrid1.DataSource = m_분류_작업요약_배치그룹별BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                Common.SetGridEditColumn(this.uGrid1, "선택");

                #endregion

                #region uGrid2 BindingSource 초기화

                연동.PAS배송사변경(m_PAS_배송사변경Table, null, 0);

                m_PAS_배송사변경BS.DataSource = m_PAS_배송사변경Table;
                uGrid2.DataSource = m_PAS_배송사변경BS;

                Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, null);
                //Common.SetGridEditColumn(this.uGrid2, "선택");

                #endregion

                #region uGrid3 BindingSource 초기화

                관리.배송사변경_Get(m_PAS_배송사변경Table, null, 0);

                m_관리_배송사변경BS.DataSource = m_관리_배송사변경Table;
                uGrid3.DataSource = m_관리_배송사변경BS;

                Common.SetGridInit(this.uGrid3, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, null);
                //Common.SetGridEditColumn(this.uGrid3, "선택");

                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(Name, ex);
            }
        }

        #endregion

        #region 버튼Event

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                분류.배치리스트조회(m_분류_작업요약_배치그룹별Table, null, 1);
                연동.PAS배송사변경(m_PAS_배송사변경Table, null, 1);
                관리.배송사변경_Get(m_PAS_배송사변경Table, null, 1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.uGrid1.Selected.Rows == null || this.uGrid1.Selected.Rows.Count <= 0)
                {
                    MessageBox.Show("배치를 선택해 주세요.", this.Text);
                }

                Cursor.Current = Cursors.WaitCursor;
                string s배치번호 = this.uGrid1.Selected.Rows[0].Cells["배치번호"].Value.ToString();

                using (StringWriter writer = new StringWriter())
                {
                    DataTable dataTable = this.m_PAS_배송사변경Table.Copy();
                    dataTable.TableName = "배송사TABLE";
                    dataTable.WriteXml((TextWriter)writer);
                    string XML = writer.ToString();

                    관리.배송사변경_Set(s배치번호, XML);
                }

                MessageBox.Show("배송사 변경이 완료되었습니다.", this.Text, MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }


        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;

                string s배치번호 = string.Empty;
                if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
                    s배치번호 = oRow["배치번호"].ToString() ?? string.Empty;

                연동.PAS배송사변경(m_PAS_배송사변경Table, s배치번호, 1);
                관리.배송사변경_Get(m_PAS_배송사변경Table, s배치번호, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

    }
}
