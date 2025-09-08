using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PAS.Task
{
    static class Program
    {
        private const string MUTEX_NAME = "Global\\UniqueAppPAS_SingleInstance";
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //GlobalClass.InitializationSettings();
            //작업.Pas작업.test("1");

            ////테스트시에는 필요함. - 나중에 필요없음
            //GlobalClass.InitializationSettings();
            ////Core.Controls.OutLineSettingForm lineSettingForm = new Core.Controls.OutLineSettingForm();
            ////Application.Run(lineSettingForm);

            //Core.Controls.PasSettingForm form = new Core.Controls.PasSettingForm();
            //Application.Run(form);

            //return;

            //하나만 실행하게끔 
            //bool bcreate;
            //Mutex mtx = new Mutex(true, Process.GetCurrentProcess().ProcessName, out bcreate);
            //if (bcreate)
            //{
            //    //Global.g_sStartupPath = Application.StartupPath;
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new MainForm());
            //}

            bool createdNew;

            using (Mutex mutex = new Mutex(true, MUTEX_NAME, out createdNew))
            {
                if (createdNew)
                {
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new MainForm());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"애플리케이션 실행 중 오류: {ex.Message}");
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
                else
                {
                    // 기존 인스턴스를 포그라운드로 가져오기
                    BringExistingInstanceToFront();
                    MessageBox.Show("프로그램이 이미 실행 중입니다.", "중복 실행",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private static void BringExistingInstanceToFront()
        {
            Process current = Process.GetCurrentProcess();
            foreach (Process process in Process.GetProcessesByName(current.ProcessName))
            {
                if (process.Id != current.Id && process.MainWindowHandle != IntPtr.Zero)
                {
                    // 기존 창을 앞으로 가져오기
                    ShowWindow(process.MainWindowHandle, SW_RESTORE);
                    SetForegroundWindow(process.MainWindowHandle);
                    break;
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private const int SW_RESTORE = 9;
    }
}
