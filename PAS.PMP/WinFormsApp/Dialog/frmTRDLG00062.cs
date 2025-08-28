using System;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRDLG00062 : BaseForm
    {
        #region 폼개체 선언부

        public string 배치번호 { get; set; }

        public string 배치명 { get; set; }

        #endregion

        #region 초기화

        public frmTRDLG00062()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.textBox1.Text = this.배치명;
        }

        #endregion

        #region 사용자정의함수

        #endregion

        #region 버튼Event

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            try
            {
                관리.배치명변경(this.배치번호, this.textBox2.Text);
                MessageBox.Show("배치명을 변경 하였습니다.", this.Text, MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

    }
}
