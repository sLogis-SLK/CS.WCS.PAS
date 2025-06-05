using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace PAS.Core
{
    public class LogUtil
    {
        public static void Log(params object[] args)
        {
            string path = Global.g_sStartupPath + "\\LOG" + ("\\SMP_" + DateTime.Now.ToString("yyyyMMdd") + ".LOG");
            if (!Directory.Exists(Global.g_sStartupPath + "\\LOG"))
                Directory.CreateDirectory(Global.g_sStartupPath + "\\LOG");
            FileMode mode = System.IO.File.Exists(path) ? FileMode.Append : FileMode.CreateNew;
            string empty = string.Empty;
            string str = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff");
            for (int index = 0; index < args.Length; ++index)
                str = str + "," + args[index].ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path, mode))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(str + "\r\n");
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
            catch
            {
                LogUtil.Log(args);
            }
        }

        public static void History(params object[] args)
        {
            string path = Global.g_sStartupPath + "\\LOG" + ("\\SMP_HISTORY_" + DateTime.Now.ToString("yyyyMMdd") + ".LOG");
            if (!Directory.Exists(Global.g_sStartupPath + "\\LOG"))
                Directory.CreateDirectory(Global.g_sStartupPath + "\\LOG");
            FileMode mode = System.IO.File.Exists(path) ? FileMode.Append : FileMode.CreateNew;
            string empty = string.Empty;
            string str = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff");
            for (int index = 0; index < args.Length; ++index)
                str = str + "," + args[index].ToString();
            try
            {
                using (FileStream fileStream = new FileStream(path, mode))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(str + "\r\n");
                    fileStream.Write(bytes, 0, bytes.Length);
                    fileStream.Flush();
                    fileStream.Close();
                }
            }
            catch
            {
                LogUtil.History(args);
            }
        }
    }
}
