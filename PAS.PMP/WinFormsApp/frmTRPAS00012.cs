﻿using Infragistics.Win.UltraWinGrid;
using PAS.PMP.PasWCS;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRPAS00012: Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_실적작성대상Table = new DataTable("usp_분류_실적작성대상_Get");
        private DataTable m_분류_실적작성내용Table = new DataTable("usp_분류_실적작성내용_Get");
        private DataTable m_분류_실적작성대상_중간Table = new DataTable("usp_분류_실적작성대상_중간_Get");
        private DataTable m_출하_배치반영Table = new DataTable("usp_출하_배치반영_Get");

        private BindingSource m_분류_작업요약_배치그룹별BS = new BindingSource();
        private BindingSource m_분류_실적작성대상BS = new BindingSource();

        private string m작업일자
        {
            get { return (Convert.ToDateTime(this.작업일자.Value)).ToString("yyyyMMdd"); }
        }

        #endregion

        #region 초기화

        public frmTRPAS00012()
        {
            InitializeComponent();
            this.실적작성버튼.Enabled = true;
            this.실적전송버튼.Enabled = false;
            this.배치반영버튼.Enabled = false;
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

                분류.배치리스트조회(this.m_분류_작업요약_배치그룹별Table, m작업일자, 0);

                m_분류_작업요약_배치그룹별BS.DataSource = m_분류_작업요약_배치그룹별Table;
                uGrid1.DataSource = m_분류_작업요약_배치그룹별BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류구분", "패턴구분", "분류상태", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "분류방법코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid1, "선택");

                #endregion

                #region uGrid2 BindingSource 초기화

                분류.실적작성대상(this.m_분류_실적작성대상Table, null, 0);

                m_분류_실적작성대상BS.DataSource = m_분류_실적작성대상Table;
                uGrid2.DataSource = m_분류_실적작성대상BS;

                Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "일련번호", "계산용");
                //Common.SetGridEditColumn(this.uGrid2, "선택");
                Common.uGridSummarySet(this.uGrid2, SummaryType.Sum, "지시수", "실적수", "부족수");

                this.uGrid2.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid2.DisplayLayout.Bands[0].Columns["부족수"].CellAppearance.ForeColor = Color.Red;

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        #region 버튼Event

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string 배치번호 = string.Empty;
                분류.배치리스트조회(m_분류_작업요약_배치그룹별Table, null, 1);
                if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
                {
                    배치번호 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();

                    string 배치상태 = uGrid1.Rows[0].Cells["배치상태"].Text;

                    switch (배치상태)
                    {
                        case "완료":
                            this.실적작성버튼.Enabled = true;
                            this.실적전송버튼.Enabled = false;
                            this.배치반영버튼.Enabled = false;
                            break;
                        case "실적작성":
                            this.실적작성버튼.Enabled = true;
                            this.실적전송버튼.Enabled = true;
                            this.배치반영버튼.Enabled = false;
                            break;
                        case "실적반영":
                            this.실적작성버튼.Enabled = false;
                            this.실적전송버튼.Enabled = true;
                            this.배치반영버튼.Enabled = true;
                            break;
                        case "배치반영":
                            this.실적작성버튼.Enabled = false;
                            this.실적전송버튼.Enabled = false;
                            this.배치반영버튼.Enabled = true;
                            break;
                        default:
                            this.실적작성버튼.Enabled = false;
                            this.실적전송버튼.Enabled = false;
                            this.배치반영버튼.Enabled = false;
                            break;
                    }
                }
                분류.실적작성대상(this.m_분류_실적작성대상Table, 배치번호, 1);

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

        private void 중간실적반영버튼_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
                if (oRow == null)
                {
                    MessageBox.Show("배치를 선택해 주세요.", this.Text);
                    return;
                }

                string s분류번호 = oRow["분류번호"].ToString();
                string s배치번호 = oRow["배치번호"].ToString();
                string s배치구분 = oRow["배치구분"].ToString();

                if (s배치구분 == "반품")
                {
                    분류.실적작성대상_중간(this.m_분류_실적작성대상_중간Table, s배치번호);
                    using (StringWriter writer = new StringWriter())
                    {
                        var dataTable = m_분류_실적작성대상_중간Table.Copy();
                        dataTable.TableName = "실적TABLE";
                        dataTable.WriteXml(writer);
                        string xml = writer.ToString();

                        연동.PAS실적반영(s배치번호, xml);
                    }
                }
                분류.출하배치반영(this.m_출하_배치반영Table, s분류번호, GlobalClass.장비명, s배치번호, 1);
                using (StringWriter writer = new StringWriter())
                {
                    var dataTable = m_출하_배치반영Table.Copy();
                    dataTable.TableName = "배치TABLE";
                    dataTable.WriteXml(writer);
                    string xml = writer.ToString();

                    연동.PAS배치반영(s배치번호, xml);
                }
                MessageBox.Show("WMS에 중간 실적을 반영하였습니다.", this.Text, MessageBoxButtons.OK);
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

        private void 실적작성버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
                if (oRow == null)
                {
                    MessageBox.Show("배치를 선택해 주세요.", this.Text);
                    return;
                }

                string s배치번호 = oRow["배치번호"].ToString();
                string s분류번호 = oRow["분류번호"].ToString();

                if (MessageBox.Show($"배치번호 : {s배치번호}\r\n\r\n선택한 배치의 실적을 작성 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("작업을 취소합니다!!", this.Text);
                    return;
                }

                분류.실적작성내용(this.m_분류_실적작성내용Table, s분류번호, GlobalClass.장비명, s배치번호);

                if (this.m_분류_실적작성내용Table.Rows.Count <= 0)
                {
                    MessageBox.Show("작업한 내용이 없습니다.", this.Text);
                }
                else
                {
                    분류.실적작성(s분류번호, GlobalClass.장비명, s배치번호);
                    분류.배치상태변경(GlobalClass.장비명, s분류번호, s배치번호, "실적작성");
                    MessageBox.Show("실적 작성이 완료되었습니다.", this.Text, MessageBoxButtons.OK);
                }
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

        private void 실적전송버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
                if (oRow == null)
                {
                    MessageBox.Show("배치를 선택해 주세요.", this.Text);
                    return;
                }

                string s분류번호 = oRow["분류번호"].ToString();
                string s배치번호 = oRow["배치번호"].ToString();
                string s배치상태 = oRow["배치상태"].ToString();

                if (s배치상태 == "완료")
                {
                    MessageBox.Show("선택한 배치는 실적작성이 되지 않았습니다.", this.Text);
                    return;
                }

                object o지시수 = this.m_분류_실적작성대상Table.Compute("SUM(지시수)", string.Empty);
                object o실적수 = this.m_분류_실적작성대상Table.Compute("SUM(실적수)", string.Empty);
                object o부족수 = this.m_분류_실적작성대상Table.Compute("SUM(부족수)", string.Empty);

                string message =
                    $"배치번호 : {s배치번호}\r\n\r\n" +
                    $"지시수 : {Convert.ToInt32(o지시수)}\r\n" +
                    $"실적수 : {Convert.ToInt32(o실적수)}\r\n" +
                    $"부족수 : {Convert.ToInt32(o부족수)}\r\n\r\n" +
                    "배치 내역을 확인하세요.\r\n실적 전송을 실행 하시겠습니까?";

                if (MessageBox.Show(message, this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("작업을 취소합니다!!", this.Text);
                    return;
                }

                using (StringWriter writer = new StringWriter())
                {
                    var dataTable = m_분류_실적작성대상Table.Copy();
                    dataTable.TableName = "실적TABLE";
                    dataTable.WriteXml(writer);
                    string xml = writer.ToString();

                    연동.PAS실적반영(s배치번호, xml);
                    분류.배치상태변경(GlobalClass.장비명, s분류번호, s배치번호, "실적반영");
                    MessageBox.Show("실적 전송이 완료되었습니다.", this.Text, MessageBoxButtons.OK);
                }

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

        private void 배치반영버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var rows = this.uGrid1.Selected.Rows;
                if (rows == null || rows.Count == 0)
                {
                    MessageBox.Show("배치를 선택해 주세요.", this.Text);
                    return;
                }

                string s분류번호 = rows[0].Cells["분류번호"].Value.ToString();
                string s배치번호 = rows[0].Cells["배치번호"].Value.ToString();

                if (MessageBox.Show($"배치번호 : {s배치번호}\r\n\r\n선택한 배치의 패킹실적을 작성 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    MessageBox.Show("작업을 취소합니다!!", this.Text);
                    return;
                }

                분류.출하배치반영(this.m_출하_배치반영Table, s분류번호, GlobalClass.장비명, s배치번호, 1);
                using (StringWriter writer = new StringWriter())
                {
                    DataTable dataTable = this.m_출하_배치반영Table.Copy();
                    dataTable.TableName = "배치TABLE";
                    dataTable.WriteXml(writer);
                    string xml = writer.ToString();
                    연동.PAS배치반영(s배치번호, xml);
                    분류.배치상태변경(GlobalClass.장비명, s분류번호, s배치번호, "배치반영");
                }
                MessageBox.Show("배치반영이 완료되었습니다.", this.Text, MessageBoxButtons.OK);
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

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

        private void uGrid1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var element = uGrid1.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
                var cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell == null)
                    return;

                var row = cell.Row;
                string s배치번호 = string.Empty;
                if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
                    s배치번호 = row.Cells["배치번호"].Value?.ToString() ?? string.Empty;

                switch (row.Cells["배치상태"].Value.ToString())
                {
                    case "완료":
                        this.실적작성버튼.Enabled = true;
                        this.실적전송버튼.Enabled = false;
                        this.배치반영버튼.Enabled = false;
                        break;
                    case "실적작성":
                        this.실적작성버튼.Enabled = true;
                        this.실적전송버튼.Enabled = true;
                        this.배치반영버튼.Enabled = false;
                        break;
                    case "실적반영":
                        this.실적작성버튼.Enabled = false;
                        this.실적전송버튼.Enabled = true;
                        this.배치반영버튼.Enabled = true;
                        break;
                    case "배치반영":
                        this.실적작성버튼.Enabled = false;
                        this.실적전송버튼.Enabled = false;
                        this.배치반영버튼.Enabled = true;
                        break;
                    default:
                        this.실적작성버튼.Enabled = false;
                        this.실적전송버튼.Enabled = false;
                        this.배치반영버튼.Enabled = false;
                        break;
                }
                분류.실적작성대상(this.m_분류_실적작성대상Table, s배치번호, 1);
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
