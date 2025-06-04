using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS.SMP
{
    public partial class uMessage: UserControl
    {
        public enum MessageType
        {
            재발행,
            채번실패,
            배송사없음,
            발행대상없음,
        }

        private Timer m_oLightTimer;

        public uMessage()
        {
            InitializeComponent();
            this.m_oLightTimer = new Timer();
            this.m_oLightTimer.Interval = 1000;
            this.m_oLightTimer.Tick += new EventHandler(this.m_oLightTimer_Tick);
        }

        private void m_oLightTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second % 2 == 1)
                this.Invoke(new Action(() => this.BackColor = Color.White));
            else
                this.Invoke(new Action(() => this.BackColor = Color.Red));
        }

        public void ShowMessage(uMessage.MessageType e) => this.ShowMessage(string.Empty, e);

        public void ShowMessage(string sMessage, uMessage.MessageType e)
        {
            this.Visible = true;
            switch (e)
            {
                case uMessage.MessageType.재발행:
                    this.label1.Invoke(new Action(() => this.label1.Text = "재발행 대상 입니다."));
                    this.label2.Invoke(new Action(() => this.label2.Text = "재발행을 체크하고 계속하십시오."));
                    break;
                case uMessage.MessageType.채번실패:
                    this.label1.Invoke(new Action(() => this.label1.Text = "운송장 발행 실패 !"));
                    this.label2.Invoke(new Action(() => this.label2.Text = string.IsNullOrEmpty(sMessage) ? "매장정보를 확인하세요." : sMessage));
                    break;
                case uMessage.MessageType.배송사없음:
                    this.label1.Invoke(new Action(() => this.label1.Text = "운송장 발행 실패 !"));
                    this.label2.Invoke(new Action(() => this.label2.Text = "지정되지 않은 배송사입니다."));
                    break;
                default:
                    this.label1.Invoke(new Action(() => this.label1.Text = "발행 대상이 없습니다 !"));
                    this.label2.Invoke(new Action(() => this.label2.Text = "배치 정보를 다시 확인해 보세요."));
                    break;
            }
            this.m_oLightTimer.Enabled = true;
        }

        public void HideMessage()
        {
            this.m_oLightTimer.Enabled = false;
            this.Visible = false;
        }

        private void uMessage_Click(object sender, EventArgs e) => this.HideMessage();
    }

    
}
