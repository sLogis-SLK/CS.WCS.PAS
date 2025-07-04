using Infragistics.Win.UltraWinGrid;
using PAS.PMP.PasWCS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRDLG00002 : Form
    {
        #region 폼개체 선언부

        private DataTable m_분류_슈트조정_슈트별현황Table = new DataTable("usp_분류_슈트조정_슈트별현황_Get");
        private DataTable m_분류_슈트조정_슈트별현황_변경Table = new DataTable("usp_분류_슈트조정_슈트별현황_Get");
        private DataTable m_분류_슈트조정_가용슈트Table = new DataTable("usp_분류_슈트조정_가용슈트_Get");

        private BindingSource m_분류_슈트조정_슈트별현황BS = new BindingSource();
        private BindingSource m_분류_슈트조정_슈트별현황_변경BS = new BindingSource();
        private BindingSource m_분류_슈트조정_가용슈트BS = new BindingSource();

        public string 원배치번호 { get; set; }

        #endregion

        #region 초기화

        public frmTRDLG00002()
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

                분류.슈트조정_슈트별현황_Get(this.m_분류_슈트조정_슈트별현황Table, this.원배치번호, 1);
                this.m_분류_슈트조정_슈트별현황_변경Table = this.m_분류_슈트조정_슈트별현황Table.Clone();
                m_분류_슈트조정_슈트별현황BS.DataSource = this.m_분류_슈트조정_슈트별현황Table;
                m_분류_슈트조정_슈트별현황_변경BS.DataSource = this.m_분류_슈트조정_슈트별현황_변경Table;
                uGrid1.DataSource = m_분류_슈트조정_슈트별현황BS;
                uGrid3.DataSource = m_분류_슈트조정_슈트별현황_변경BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                Common.SetGridEditColumn(this.uGrid1, null);
                #endregion

                #region uGrid2 BindingSource 초기화

                분류.슈트조정_가용슈트_조회(this.m_분류_슈트조정_가용슈트Table, GlobalClass.장비명, 1);

                m_분류_슈트조정_가용슈트BS.DataSource = m_분류_슈트조정_가용슈트Table;
                uGrid2.DataSource = m_분류_슈트조정_가용슈트BS;

                if (this.m_분류_슈트조정_가용슈트Table.Rows.Count > 0)
                    return;

                var 사용중인슈트번호 = new HashSet<string>(
                    m_분류_슈트조정_슈트별현황Table.AsEnumerable()
                    .Select(row => row["슈트번호"].ToString())
                );

                this.m_분류_슈트조정_가용슈트Table.Rows.Clear();
                int 전체슈트 = Convert.ToInt32((object)GlobalClass.CHUTES);
                int 에러슈트 = Convert.ToInt32((object)GlobalClass.CHUTES_ERROR);
                string empty = string.Empty;
                for (int index = 0; index < 전체슈트; ++index)
                {
                    if (index + 1 != 에러슈트)
                    {
                        string 슈트번호 = (index + 1).ToString("D3");
                        if (!사용중인슈트번호.Contains(슈트번호))
                            this.m_분류_슈트조정_가용슈트Table.Rows.Add((object)(index + 1).ToString("D3"));
                    }
                }
                this.m_분류_슈트조정_가용슈트Table.AcceptChanges();

                Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, null);
                Common.SetGridEditColumn(this.uGrid2, null);

                #endregion

                #region uGrid3 BindingSource 초기화

                m_분류_슈트조정_슈트별현황_변경BS.DataSource = m_분류_슈트조정_슈트별현황_변경Table;
                uGrid3.DataSource = m_분류_슈트조정_슈트별현황_변경BS;

                Common.SetGridInit(this.uGrid3, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, null);
                Common.SetGridEditColumn(this.uGrid3, null);

                this.uGrid3.DisplayLayout.Bands[0].Columns["조정슈트"].CellAppearance.BackColor = SystemColors.Info;
                this.uGrid3.DisplayLayout.Bands[0].Columns["조정슈트"].CellAppearance.ForeColor = Color.Red;

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
                SetDataTableBindingInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                this.textBox1.Focus();
                this.textBox1.SelectAll();
                this.ultraLabel4.Text = $"( 대상 : {this.uGrid1.Rows.Count}, 가용 : {this.uGrid1.Rows.Count}, 조정 : {this.uGrid1.Rows.Count} )";
                Cursor.Current = Cursors.Default;
            }
        }

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

        private void 재설정버튼_Click(object sender, EventArgs e)
        {
            this.m_분류_슈트조정_슈트별현황_변경Table.Rows.Clear();
            this.조회버튼_Click((object)null, EventArgs.Empty);
        }

        private void 조정버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DataRow oRow1 = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
                if (this.uGrid1.ActiveRow == null || this.uGrid1.ActiveRow.Index < 0)
                {
                    MessageBox.Show("대상 슈트를 선택하세요.", this.Text);
                    return;
                }

                if (this.uGrid2.ActiveRow == null || this.uGrid2.ActiveRow.Index < 0)
                {
                    MessageBox.Show("가용 슈트를 선택하세요.", this.Text);
                    return;
                }

                int 요청수량 = Convert.ToInt32((object)this.textBox1.Text);
                int 대상슈트인덱스 = this.uGrid1.ActiveRow.Index;
                int 가용슈트인덱스 = this.uGrid2.ActiveRow.Index;
                int 대상슈트수 = this.uGrid1.Rows.Count - 대상슈트인덱스;
                int 가용슈트수 = this.uGrid2.Rows.Count - 가용슈트인덱스;
                if (요청수량 != 대상슈트수 && 요청수량 > 대상슈트수)
                    요청수량 = 대상슈트수;
                if (요청수량 > this.uGrid2.Rows.Count)
                {
                    MessageBox.Show(string.Format("대상 슈트수가 가용 슈트수의 최대 허용치를 벗어납니다.\r\n조정 가능한 가용 슈트의 수는 {0}개 입니다."), this.Text);
                    this.textBox1.Text = this.uGrid2.Rows.Count.ToString();
                    this.textBox1.SelectAll();
                    return;
                }

                if (대상슈트수 > 가용슈트수)
                {
                    MessageBox.Show("대상 슈트수가 가용 슈트수를 초과합니다.", this.Text);
                    return;
                }

                int 인덱스차이 = 대상슈트인덱스 != 가용슈트인덱스 ? 가용슈트인덱스 - 대상슈트인덱스 : 0;
                var 대상Rows = new List<UltraGridRow>();
                var 가용Rows = new List<UltraGridRow>();

                for (int i = 0; i < 요청수량; i++)
                {
                    var 대상Row = uGrid1.Rows[대상슈트인덱스 + i];
                    var 가용Row = uGrid2.Rows[대상슈트인덱스 + i + 인덱스차이];

                    m_분류_슈트조정_슈트별현황_변경Table.Rows.Add(
                        대상Row.Cells["슈트번호"].Value.ToString(),
                        가용Row.Cells["가용슈트"].Value.ToString(),
                        대상Row.Cells["점코드"].Value.ToString(),
                        대상Row.Cells["점명"].Value.ToString(),
                        Convert.ToInt32(대상Row.Cells["지시수"].Value)
                    );

                    if(!대상Rows.Contains(대상Row))
                    {
                        대상Rows.Add(대상Row);
                    }
                    if (!가용Rows.Contains(가용Row))
                    {
                        가용Rows.Add(가용Row);
                    }
                    가용Rows.Add(가용Row);
                }

                foreach (var row in 대상Rows)
                {
                    if (row.ListObject is DataRowView drv)
                    {
                        drv.Row.Delete();
                    }
                }

                foreach (var row in 가용Rows)
                {
                    if (row.ListObject is DataRowView drv)
                    {
                        drv.Row.Delete();
                    }
                }

                uGrid1.UpdateData();
                uGrid2.UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                this.ultraLabel4.Text = $"( 대상 : {this.uGrid1.Rows.Count}, 가용 : {this.uGrid2.Rows.Count}, 조정 : {this.uGrid3.Rows.Count} )";
                Cursor.Current = Cursors.Default;
            }
        }

        private void 반영버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (this.uGrid3.Rows.Count <= 0)
                {
                    MessageBox.Show("반영할 내용이 없습니다.", this.Text);
                    return;
                }
                    
                if (string.IsNullOrEmpty(this.원배치번호))
                {
                    MessageBox.Show("배치번호 값이 없습니다.", this.Text);
                    return;
                }

                m_분류_슈트조정_슈트별현황_변경BS.EndEdit();
                DataTable dataTable = new DataTable("슈트조정TABLE");
                dataTable.Columns.Add("슈트번호", typeof(string));
                dataTable.Columns.Add("조정슈트", typeof(string));
                foreach (UltraGridRow row in this.uGrid3.Rows)
                    dataTable.Rows.Add(row.Cells["슈트번호"].Value.ToString(), row.Cells["조정슈트"].Value.ToString());
                using (StringWriter writer = new StringWriter())
                {
                    dataTable.WriteXml(writer);
                    string xml = writer.ToString();

                    분류.슈트조정_슈트별현황_Set(GlobalClass.장비명, this.원배치번호, xml);
                    연동.PAS슈트조정(this.원배치번호, xml);
                }
                MessageBox.Show("슈트 조정 결과가 반영 되었습니다.", this.Text, MessageBoxButtons.OK);
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

        #endregion

    }
}
