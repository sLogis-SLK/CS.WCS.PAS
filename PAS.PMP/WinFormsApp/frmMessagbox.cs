using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PAS.PMP
{
    public partial class frmMessageBox : Form
    {
        #region 폼개체 선언부

        private System.Windows.Forms.Timer m_oMainTimer;

        private bool IsClicked { get; set; }

        private string Message
        {
            get => this.ultraLabel1.Text;
            set => this.ultraLabel1.Text = value;
        }

        private int Interval { get; set; }

        private bool IsTimerButton { get; set; }
        #endregion

        #region 초기화

        public frmMessageBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.ultraButton1.Location = new Point(this.panel1.Width / 2 - 2 - this.ultraButton1.Width, this.ultraButton1.Location.Y);
            this.ultraButton2.Location = new Point(this.panel1.Width / 2 + 2, this.ultraButton2.Location.Y);
            this.ultraButton3.Location = new Point((this.panel1.Width - this.ultraButton3.Width) / 2, this.ultraButton3.Location.Y);
            this.m_oMainTimer = new System.Windows.Forms.Timer();
            this.m_oMainTimer.Interval = 1000;
            this.m_oMainTimer.Tick += new EventHandler(this.m_oMainTimer_Tick);
        }

        private void m_oMainTimer_Tick(object sender, EventArgs e)
        {
            ++this.Interval;
            if (this.Interval >= 3)
            {
                this.m_oMainTimer.Enabled = false;
                this.IsClicked = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (!this.IsTimerButton)
                    return;
                this.ultraButton3.Text = $"확인 [-{(3 - this.Interval).ToString()}]";
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.IsClicked = true;
            this.DialogResult = DialogResult.Yes;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.IsClicked = true;
            this.DialogResult = DialogResult.No;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.IsClicked = true;
            this.DialogResult = DialogResult.OK;
        }

        private void frmMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.IsClicked)
                return;
            this.DialogResult = DialogResult.No;
        }

        public static DialogResult Show(string sMessage) => frmMessageBox.Show(sMessage, "메시지", true);

        public static DialogResult Show(string sMessage, string sTitle)
        {
            return frmMessageBox.Show(sMessage, sTitle, true);
        }

        public static DialogResult Show(string sMessage, string sTitle, bool bButton)
        {
            return frmMessageBox.Show(sMessage, sTitle, bButton, false);
        }

        public static DialogResult Show(string sMessage, string sTitle, bool bButton, bool bTimerButton)
        {
            frmMessageBox frmMessageBox = new frmMessageBox();
            frmMessageBox.Message = sMessage;
            frmMessageBox.ultraButton1.Visible = bButton;
            frmMessageBox.ultraButton2.Visible = bButton;
            frmMessageBox.ultraButton3.Visible = !bButton;
            if (!bButton && bTimerButton)
            {
                frmMessageBox.IsTimerButton = true;
                frmMessageBox.ultraButton3.Text = "확인 [-3]";
                frmMessageBox.m_oMainTimer.Enabled = true;
            }
            return frmMessageBox.ShowDialog();
        }

        #endregion

    }
}
