using Infragistics.Win.UltraWinGrid;
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

namespace pas.smp.WinFormsApp
{
    public partial class frmSMP00004: Form
    {
        #region 개체선언부

        private DataTable m_출하_미발행박스Table = new DataTable("usp_출하_미발행박스_Get");
        private BindingSource m_출하_미발행박스 = new BindingSource();

        #endregion

        public frmSMP00004()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void frmSMP00004_Load(object sender, EventArgs e)
        {
            그리드초기화();
        }

        private void 그리드초기화()
        {
            try
            {
                #region uGrid1 BindingSource 초기화
                출하_미발행박스_조회(조회구분자.가조회);

                Common.SetGridInit(uGrid1, false, false, true, false, false, false);
                //Common.SetGridHiddenColumn(uGrid1, null);
                Common.SetGridEditColumn(uGrid1, null);

                //uGrid1.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //uGrid1.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";

                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(Name, ex);
            }
        }


        private void 출하_미발행박스_조회(조회구분자 e)
        {
            try
            {
                string s작업일자 = this.dateTimePicker1.Value.ToString("yyyyMMdd");

                출하.출하내역관리.출하미발행박스조회(m_출하_미발행박스Table, true, s작업일자);
                m_출하_미발행박스.DataSource = m_출하_미발행박스Table;
                uGrid1.DataSource = m_출하_미발행박스;
                Common.uGridSummarySet(uGrid1, SummaryType.Count, "박스바코드");

                foreach (UltraGridColumn column in this.uGrid1.DisplayLayout.Bands[0].Columns)
                {
                    string headerText = column.Header.Caption;
                    if (headerText == "작업일자" || headerText == "운송장번호")
                        column.Hidden = true;
                    else
                        column.Hidden = false;
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[SMP00004 출하_미발행박스_조회]", (object)ex.Message);
            }
        }

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                출하_미발행박스_조회(조회구분자.실조회);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(Name, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

    }
}
