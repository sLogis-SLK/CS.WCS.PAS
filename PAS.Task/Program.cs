using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PAS.Task
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GlobalClass.InitializationSettings();
            //작업.Pas작업.test("1");

            //테스트시에는 필요함. - 나중에 필요없음
            GlobalClass.InitializationSettings();
            //Core.Controls.OutLineSettingForm lineSettingForm = new Core.Controls.OutLineSettingForm();
            //Application.Run(lineSettingForm);

            Core.Controls.PasSettingForm form = new Core.Controls.PasSettingForm();
            Application.Run(form);

            return;

            //하나만 실행하게끔 
            bool bcreate;
            Mutex mtx = new Mutex(true, Process.GetCurrentProcess().ProcessName, out bcreate);
            if (bcreate)
            {
                //Global.g_sStartupPath = Application.StartupPath;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
