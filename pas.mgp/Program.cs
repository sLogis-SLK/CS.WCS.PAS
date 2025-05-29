// Decompiled with JetBrains decompiler
// Type: pas.mgp.Program
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
namespace pas.mgp { 

internal static class Program
{
  [STAThread]
  private static void Main()
  {
    bool createdNew = false;
    Mutex mutex = new Mutex(true, "pas.mgp", out createdNew);
    if (createdNew)
    {
      Common.PATH_STARTUP = Application.StartupPath;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new frmMain());
      mutex.ReleaseMutex();
    }
    else
      Process.GetCurrentProcess().Kill();
  }
}

}
