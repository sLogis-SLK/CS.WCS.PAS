using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PAS.SMP
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //하나만 실행하게끔 
            bool bcreate;
            Mutex mtx = new Mutex(true, Process.GetCurrentProcess().ProcessName, out bcreate);
            if (bcreate)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
