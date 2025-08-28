using System;
using System.Data;
using System.Windows.Forms;
using TR_Common;
using TR_Library.Controls;

namespace PAS.PMP
{
    public partial class frmTRDLG00061 : BaseForm
    {
        #region 폼개체 선언부

        public string TITLE2 { get; set; }

        public DataTable 자리수초과아이템 { get; set; }

        #endregion

        #region 초기화

        public frmTRDLG00061()
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

                uGrid1.DataSource = (object)this.자리수초과아이템; ;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                //Common.SetGridEditColumn(this.uGrid1, "선택");

                #endregion
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        #region 버튼Event

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            //new Excel().Export(this.자리수초과아이템);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                this.uGridExcelExporter1.ExportAsync(uGrid1, saveFileDialog1.FileName);
        }

        #endregion

    }
}
