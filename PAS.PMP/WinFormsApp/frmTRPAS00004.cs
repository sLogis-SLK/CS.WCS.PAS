using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using PAS.Core;
using PAS.PMP.Utils;
using TR_Common;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00004 : BaseForm
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_분류_박스재발행Table = new DataTable("usp_분류_박스바코드재발행_Get_JHG");
        private DataTable m_분류_박스재발행_슈트별Table = new DataTable("usp_분류_박스바코드재발행_슈트별_Get");
        private DataTable m_분류_박스재발행_슈트별상세Table = new DataTable("usp_분류_박스바코드재발행_슈트별상세_Get");


        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_분류_박스재발행BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별BS = new BindingSource();
        private BindingSource m_분류_박스재발행슈트별상세BS = new BindingSource();

        string _배치번호 = "";
        string _분류번호 = "";
        string _슈트번호 = "";
        string _박스번호 = string.Empty;
        string _배치구분 = string.Empty;
        string _장비명 = "";
        string _서브슈트번호 = "";

        private Dictionary<string, string> _uGrid4RowKey;

        #endregion

        #region 초기화

        public frmTRPAS00004()
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

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0, GlobalClass.장비명);



                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid4.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid4, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid4, "분류방법코드", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid4, null);

                #endregion

                #region uGrid1 BindingSource 초기화

                분류.박스재발행조회(m_분류_박스재발행Table, "", "", 0);

                this.m_분류_박스재발행BS.DataSource = this.m_분류_박스재발행Table;
                this.uGrid1.DataSource = this.m_분류_박스재발행BS;

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "분류번호", "배치번호", "서브슈트번호", "배치구분코드", "배치구분", "출력여부");
                Common.SetGridEditColumn(this.uGrid1, null);

                Common.uGridSummarySet(this.uGrid1, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");
                this.uGrid1.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                #endregion

                #region uGrid2 BindingSource 초기화

                분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, "", "", "", "", 0);

                this.m_분류_박스재발행슈트별BS.DataSource = this.m_분류_박스재발행_슈트별Table;
                this.uGrid2.DataSource = this.m_분류_박스재발행슈트별BS;

                Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류번호", "배치번호", "슈트번호", "서브슈트번호", "박스바코드", "박스바코드구분");

                Common.SetGridEditColumn(this.uGrid2, null);
                Common.uGridSummarySet(this.uGrid2, Infragistics.Win.UltraWinGrid.SummaryType.Sum, "내품수");
                this.uGrid2.DisplayLayout.Override.SummaryValueAppearance.ForeColor = Color.Red;
                this.박스번호리스트.DataSource = null;
                #endregion

                #region uGrid3 BindingSource 초기화

                분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, "", "", "", "", "", 0);

                this.m_분류_박스재발행슈트별상세BS.DataSource = this.m_분류_박스재발행_슈트별상세Table;
                this.uGrid3.DataSource = this.m_분류_박스재발행슈트별상세BS;

                Common.SetGridInit(this.uGrid3, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "IDX", "아이템코드", "브랜드코드", "브랜드명", "센터코드", "센터명", "배치명");

                Common.SetGridEditColumn(this.uGrid3, "조정");

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region IToolBase 멤버

        #endregion

        #region Event

        private void 조회_Click(object sender, EventArgs e)
        {
            _uGrid4RowKey = UltraGridHelper.RememberActiveRow(
                uGrid4,
                "배치번호",
                "분류번호"
            );

            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            UltraGridHelper.RestoreActiveRow(uGrid4, _uGrid4RowKey);

            if (m_분류_작업배치그룹Table.Rows.Count == 0)
            {
                m_분류_박스재발행Table.Clear();
                m_분류_박스재발행_슈트별Table.Clear();
                m_분류_박스재발행_슈트별상세Table.Clear();

                return;
            }

            if (uGrid4.ActiveRow == null)
            {
                uGrid4.ActiveRow = uGrid4.Rows[0];
            }

            Load박스재발행슈트별ByActiveRow();
        }

        private void Load박스재발행슈트별ByActiveRow()
        {
            if (this.uGrid4.ActiveRow == null || this.uGrid4.ActiveRow.Index < 0)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid4.ActiveRow.ListObject).Row;
                _배치번호 = oRow["배치번호"].ToString();
                _분류번호 = oRow["분류번호"].ToString();
                _장비명 = oRow["장비명"].ToString();
                _배치구분 = oRow["배치구분"].ToString();
                분류.박스재발행조회(m_분류_박스재발행Table, _분류번호, _배치번호, 1);

                if (m_분류_박스재발행Table.Rows.Count == 0)
                {
                    m_분류_박스재발행_슈트별Table.Clear();
                    m_분류_박스재발행_슈트별상세Table.Clear();
                }
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

        private void uGrid4_MouseClick(object sender, MouseEventArgs e)
        {
            this.조회_Click(null, null);
        }


        private void uGrid1_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid1.ActiveRow.ListObject).Row;
            _슈트번호 = oRow["슈트번호"].ToString();
            _서브슈트번호 = oRow["서브슈트번호"].ToString();
            분류.슈트별박스풀조회(m_분류_박스재발행_슈트별Table, _분류번호, _배치번호, _슈트번호, _서브슈트번호, 1);

            // 박스번호 리스트업
            this.박스번호리스트.DataSource = getBoxListup();

            if (this.박스번호리스트.Rows.Count <= 0)
                return;
            this.박스번호리스트.ActiveRow = this.박스번호리스트.Rows[0];


        }

        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
            _박스번호 = oRow["박스번호"].ToString();
            분류.슈트별박스풀상세조회(m_분류_박스재발행_슈트별상세Table, _분류번호, _배치번호, _슈트번호, _서브슈트번호, _박스번호, 1);
        }


        private DataTable getBoxListup()
        {
            DataTable sourceTable = m_분류_박스재발행_슈트별Table;

            var distinctTable = sourceTable.DefaultView.ToTable(true, "박스번호");
            DataRow emptyRow = distinctTable.NewRow();
            emptyRow["박스번호"] = ""; // 또는 DBNull.Value
            distinctTable.Rows.InsertAt(emptyRow, 0);
            return distinctTable;

        }

        private void 박스이동_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                m_분류_박스재발행슈트별상세BS.EndEdit();
                DataRow[] dataRowArray = this.m_분류_박스재발행_슈트별상세Table.Select("수량 <> 잔여");
                if (dataRowArray == null || dataRowArray.Length <= 0)
                {
                    MessageBox.Show("이동할 대상이 없습니다.");
                    return;
                }

                if (this.uGrid2.ActiveRow == null || this.uGrid3.ActiveRow.Index < 0)
                {
                    MessageBox.Show("이동할 대상이 없습니다.");
                    return;
                }


                string empty1 = string.Empty;

                if (_배치번호 == "")
                {
                    MessageBox.Show("배치번호를 선택하세요.");
                    return;
                }

                if (_슈트번호 == "")
                {
                    MessageBox.Show("슈트번호를 선택하세요.");
                    return;
                }

                //if (_박스번호 == "")
                //{
                //    MessageBox.Show("박스번호를 선택하세요.");
                //    return;
                //}

                if (string.IsNullOrEmpty(_박스번호))
                {
                    MessageBox.Show("이동할 대상 박스를 선택하세요.");
                    return;
                }

                if (_배치구분 == "멀티반품")
                {
                    MessageBox.Show("선택한 슈트는 테블릿 분류 대상입니다.\r\n\r\n박스 이동을 할 수 없습니다.");
                    return;
                }
                string empty3 = string.Empty;
                분류.출하상품이동생성(dataRowArray, _배치번호, _슈트번호, _박스번호, this.박스번호리스트.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.조회_Click((object)null, EventArgs.Empty);
                Cursor.Current = Cursors.Default;
            }
        }


        #endregion

        private void uGrid3_AfterCellUpdate(object sender, CellEventArgs e)
        {
            //string columnKey = e.Cell.Column.Key;
            object 조정 = e.Cell.Value;
            var row = e.Cell.Row;

            string 수량 = row.Cells["수량"].Value.ToString();
            string 잔여 = row.Cells["잔여"].Value.ToString();

            int num1 = ConvertUtil.ObjectToint(수량);
            int num2 = ConvertUtil.ObjectToint(조정);
            int num3 = ConvertUtil.ObjectToint(잔여);
            string str = row.Cells["아이템코드"].Value.ToString();

            DataRow[] dataRowArray = this.m_분류_박스재발행_슈트별상세Table.Select($"아이템코드='{str}'");

            if (dataRowArray == null || dataRowArray.Length <= 0)
                return;

            if (num1 - num2 < 0)
            {
                MessageBox.Show("조정수가 실적수보다 많을 수 없습니다.");
                row.Cells["조정"].Value = (object)(num1 - num3); ;
                row.Cells["잔여"].Value = num3;
            }
            else
            {
                dataRowArray[0]["잔여"] = (object)(num1 - num2);
                this.m_분류_박스재발행_슈트별상세Table.AcceptChanges();
            }

        }

        
    }
}
