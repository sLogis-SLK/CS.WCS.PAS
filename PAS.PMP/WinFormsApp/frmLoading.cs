using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmLoading : BaseForm
    {
        #region 폼개체 선언부

        private static frmLoading Loading;

        #endregion

        #region 초기화

        public frmLoading()
        {
            InitializeComponent();
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            using (Pen pen = new Pen(Brushes.Black, 2f))
            {
                Rectangle clientRectangle = this.ClientRectangle;
                e.Graphics.DrawRectangle(pen, clientRectangle);
            }
        }

        private void frmLoading_Click(object sender, EventArgs e)
        {
        }

        public static void ShowLoading()
        {
            if (frmLoading.Loading != null)
            {
                frmLoading.Loading.Dispose();
                frmLoading.Loading = (frmLoading)null;
            }
            Thread thread = new Thread(new ThreadStart(frmLoading.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void ShowForm()
        {
            frmLoading.Loading = new frmLoading();
            frmLoading.Loading.ShowInTaskbar = false;
            frmLoading.Loading.TopMost = true;
            Application.Run((Form)frmLoading.Loading);
        }

        public static void CloseLoading()
        {
            if (frmLoading.Loading == null)
                return;
            frmLoading.Loading.Invoke((Delegate)new frmLoading.CloseEventHandler(frmLoading.CloseFormInternal));
        }

        private static void CloseFormInternal()
        {
            if (frmLoading.Loading == null)
                return;
            frmLoading.Loading.Close();
        }
        #endregion

        private delegate void CloseEventHandler();
    }
}
