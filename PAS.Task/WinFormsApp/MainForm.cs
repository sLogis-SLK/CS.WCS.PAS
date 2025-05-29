using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS.Task
{
    public partial class MainForm : Form
    {
        #region 개체선언부

        private System.Windows.Forms.Timer mPasDurationTimer;
        private System.Windows.Forms.Timer mPrinterDurationTimer;
        private SocketServer m_oServer;

        private DataTable m_표시기맵Table = new DataTable("표시기맵TABLE");
        private DataTable m_분류_숫자표시기값Table = new DataTable("usp_분류_숫자표시기값_Get");

        #endregion

        #region 생성자 및 폼 override 이벤트

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //스크린 최상단으로 위치이동
            Screen screen = Screen.FromPoint(Location);
            Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

            //Pas상태모니터링
            mPasDurationTimer = new System.Windows.Forms.Timer();
            mPasDurationTimer.Enabled = true;

            //거래명세표출력 모니터링
            mPrinterDurationTimer = new System.Windows.Forms.Timer();
            mPrinterDurationTimer.Enabled = true;




            //이벤트 한군데서 사용
            mPasDurationTimer.Tick += mPasDurationTimer_Tick;
            mPrinterDurationTimer.Tick += mPrinterDurationTimer_Tick;
        }

        protected override void OnClosed(EventArgs e)
        {
            if (MessageBox.Show("PAS 동작에 심각한 문제가 발생 할 수 있습니다.\r\n그래도 종료 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    //this.m_eDPSStatus = DPSStatus.END;
                    int num = (int)MessageBox.Show("표시기를 종료하고 있습니다.\r\n\r\n표시기가 종료될때 까지 기다리세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    Thread.Sleep(5000); //5초 대기

                    //각종 쓰레드 들 종료
                    //if (this.m_oPasDurationTimer != null)
                    //{
                    //    Common.IsPasContinue = false;
                    //    this.m_oPasDurationTimer.Enabled = false;
                    //}
                    //if (this.m_oPrinterDurationTimer != null)
                    //{
                    //    Common.IsPrintContinue = false;
                    //    this.m_oPrinterDurationTimer.Enabled = false;
                    //}
                    //if (this.m_oPasThread != null)
                    //{
                    //    Common.IsPasThread = false;
                    //    this.m_oPasThread.Abort();
                    //    this.m_oPasThread = (Thread)null;
                    //}

                    if (this.m_oServer != null)
                    {
                        this.m_oServer.Stop();
                        this.m_oServer = (SocketServer)null;
                    }
                    Process.GetCurrentProcess().Kill();
                    base.OnClosed(e);

                }
                catch (Exception ex)
                {
                    int num = (int)MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                //미종료
                //e.Cancel = true;
            }


        }
        #endregion

        private void mPasDurationTimer_Tick(object sender, EventArgs e)
        {

        }

        private void mPrinterDurationTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            int num = now.Hour * 60 * 60 + now.Minute * 60 + now.Second;
            if (num == 0 || num % 15 != 0)
                return;
            //Common.IsPrintContinue = true;
        }

    }
}
