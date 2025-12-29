using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PAS.PMP.Utils;
using PAS.PMP.WinFormsApp.Dialog;
using TR_Common;
using TR_Library.Controls;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00007 : BaseForm, IToolBase
    {
        #region 폼개체 선언부

        private DataTable m_분류_작업배치그룹Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
        private DataTable m_출하_박스별패킹대상Table = new DataTable("usp_출하_박스별패킹대상_Get");

        private BindingSource m_분류_작업배치그룹BS = new BindingSource();
        private BindingSource m_출하_박스별패킹BS = new BindingSource();

        private Dictionary<string, string> _uGrid2RowKey;

        #endregion

        #region 초기화

        public frmTRPAS00007()
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

                분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 0);


                this.m_분류_작업배치그룹BS.DataSource = this.m_분류_작업배치그룹Table;
                this.uGrid2.DataSource = this.m_분류_작업배치그룹BS;

                Common.SetGridInit(this.uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "분류방법코드", "분류구분", "패턴구분", "분류상태", "완료일시", "선택", "순번", "장비명", "배치구분코드", "출하구분코드", "분류구분코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid2, null);

                this.uGrid2.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                #endregion

                #region uGrid1 BindingSource 초기화

                분류.출하박스별패킹대상(m_출하_박스별패킹대상Table, "", "", 0);

                this.m_출하_박스별패킹BS.CurrentChanged += (s, e) => this.uGrid1.Refresh();

                this.m_출하_박스별패킹BS.DataSource = this.m_출하_박스별패킹대상Table;
                this.uGrid1.DataSource = this.m_출하_박스별패킹BS;

                this.uGrid1.Refresh();
                this.uGrid1.Update();

                Common.SetGridInit(this.uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "배치번호", "슈트번호");
                Common.SetGridEditColumn(this.uGrid1, "선택");

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region IToolBase 멤버

        public void OnPrint(bool bPrevView)
        {
            frmTRDLG00001 oDlg = new frmTRDLG00001();
            DialogResult oResult = oDlg.ShowDialog();

            if (oResult == DialogResult.OK)
            {
                bool flag1;
                bool flag2;
                switch (oDlg.선택값)
                {
                    case 1:
                        flag1 = true;
                        flag2 = false;
                        break;
                    case 2:
                        flag1 = false;
                        flag2 = true;
                        break;
                    case 3:
                        flag1 = true;
                        flag2 = true;
                        break;
                    default:
                        MessageBox.Show("발행을 취소합니다.");
                        return;
                }

                try
                {
                    DataTable oDataTable1 = new DataTable("usp_기준_거래명세서용_마스터_Get");
                    분류.거래명세서출력조회(oDataTable1);
                    if (oDataTable1 == null || oDataTable1.Rows.Count <= 0)
                    {
                        MessageBox.Show("발행할 거래명세서 대상이 없습니다.");
                        return;
                    }

                    Cursor.Current = Cursors.WaitCursor;
                    this.uGrid1.PerformAction(UltraGridAction.CommitRow);

                    string empty1 = string.Empty;
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    foreach (UltraGridRow row in this.uGrid1.Rows)
                    {
                        if (row.Cells["선택"].Value.ToString() == bool.TrueString)
                        {
                            string s배치번호 = row.Cells["배치번호"].Value.ToString();
                            string s슈트번호 = row.Cells["슈트번호"].Value.ToString();
                            DataRow[] dataRowArray = oDataTable1.Select($"슈트번호 = '{s슈트번호}'");
                            string s거명용바코드 = dataRowArray == null || dataRowArray.Length <= 0 ? $"*SLK{s슈트번호}{1.ToString("D4")}*" : $"*{dataRowArray[0]["아이템코드"].ToString()}*";
                            if (flag1)
                                분류.거래명세서발행_박스별(s배치번호, s슈트번호, s거명용바코드);
                            if (flag2)
                                분류.거래명세서발행_토탈(s배치번호, s슈트번호, s거명용바코드);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                    this.조회_Click((object)null, EventArgs.Empty);
                }
            }
        }

        public void OnExcel()
        {
            throw new NotImplementedException();
        }

        public void OnControlVisible(object sender, ControlVisibleEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnBrandChange(object sender, BrandChangeEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event

        private void 조회_Click(object sender, EventArgs e)
        {
            _uGrid2RowKey = UltraGridHelper.RememberActiveRow(
                uGrid2,
                "배치번호",
                "분류번호"
            );
            분류.배치리스트조회(m_분류_작업배치그룹Table, Convert.ToDateTime(this.작업일자.Value).ToString("yyyyMMdd"), 1);

            UltraGridHelper.RestoreActiveRow(uGrid2, _uGrid2RowKey);
        }

        private void uGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            this.조회_Click(null, null);
        }
        private void uGrid2_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid2.ActiveRow == null || this.uGrid2.ActiveRow.Index < 0)
                return;

            Cursor = Cursors.WaitCursor;

            try
            {
                DataRow oRow = ((DataRowView)uGrid2.ActiveRow.ListObject).Row;
                분류.출하박스별패킹대상(m_출하_박스별패킹대상Table, oRow["분류번호"].ToString(), oRow["배치번호"].ToString(), 1);
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
            foreach (UltraGridRow row in this.uGrid1.Rows)
            {
                if (row.Tag == null || !(row.Tag.ToString() == "요약"))
                    row.Cells["선택"].Value = (object)this.checkBox1.Checked;
            }
            this.m_출하_박스별패킹BS.EndEdit();
        }

        #endregion

        
    }

}
