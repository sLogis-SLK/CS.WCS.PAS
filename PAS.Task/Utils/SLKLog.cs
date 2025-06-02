using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PAS.Task
{
    //public partial class Utils
    //{
    //    #region SLkLog

    //    public static void SLkLog(string ActionLog, object DataLog = null)
    //    {
    //        try
    //        {
    //            var pFrame = new StackTrace().GetFrame(1);
    //            MethodBase callMethod = pFrame.GetMethod();

    //            //var pCurrent = HttpContext.Current;
    //            DateTime timestamp = DateTime.Now;
    //                //pCurrent == null ? DateTime.MinValue :
    //                //pCurrent.Timestamp == null ? DateTime.MinValue : pCurrent.Timestamp;

    //            //// 부모가 WebMethod 특성을 검사
    //            //if (callMethod.GetCustomAttributes(typeof(WebMethodAttribute), false).Any() == false)
    //            //{
    //            //    StackTrace stackTrace = new StackTrace();
    //            //    foreach (var frame in stackTrace.GetFrames())
    //            //    {
    //            //        MethodBase methodBase = frame.GetMethod();
    //            //        // WebMethod 특성을 검사
    //            //        if (methodBase.GetCustomAttributes(typeof(WebMethodAttribute), false).Any())
    //            //        {
    //            //            callMethod = methodBase; // WebMethod가 적용된 메서드 반환
    //            //            break;
    //            //        }
    //            //    }
    //            //}

    //            long keyValue = timestamp.Ticks;
    //            string projectName = Assembly.GetExecutingAssembly().GetName().Name;
    //            string logFile = @"C:\SLKLog\" + projectName + @"\" + callMethod.DeclaringType.Name + @"\" + callMethod.Name;

    //            if (DataLog == null)
    //                SLkLogSave(logFile, "ActionLog_", keyValue, ActionLog);
    //            else
    //            {
    //                string ticksKey = DateTime.Now.Ticks.ToString();

    //                SLkLogSave(logFile, "ActionLog_", keyValue, ActionLog + " [" + ticksKey + "]");

    //                string saveLog = ActionLog + " [" + ticksKey + "]\r\n";
    //                saveLog += ActionLog + " [" + ticksKey + "] Start ----------\r\n";
    //                saveLog += DataLog.ToString() + "\r\n";
    //                saveLog += ActionLog + " [" + ticksKey + "] End ----------\r\n";

    //                SLkLogSave(logFile, "DataLog_", keyValue, saveLog);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            //WriteLog("SLkLog 저장시 오류가 발생했습니다. : " + ex.Message);
    //        }
    //    }

    //    private static void SLkLogSave(string logPath, string fileName, long keyValue, string saveLog)
    //    {
    //        string logFile = logPath + @"\" + fileName + DateTime.Now.ToString("yyMMdd") + ".txt";

    //        StringBuilder sb = new StringBuilder();
    //        sb.Append("[" + keyValue.ToString() + DateTime.Now.ToString(" | yyyy-MM-dd HH:mm:ss:fff] ") + saveLog);
    //        string path = Path.GetDirectoryName(logFile);

    //        if (!Directory.Exists(path))
    //        {
    //            Directory.CreateDirectory(path);
    //        }

    //        FileStream fileStream = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
    //        StreamWriter streamWrite = new StreamWriter(fileStream, Encoding.Default);

    //        streamWrite.WriteLine(sb.ToString());
    //        streamWrite.Close();
    //        fileStream.Close();
    //    }

    //    #endregion


    //    public static void WriteLog(string message)
    //    {
    //        string logFile = @"C:\SLKLog\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
    //        StringBuilder sb = new StringBuilder();

    //        sb.Append(DateTime.Now.ToString("[yyyy-MM-dd][HH:mm:ss] ") + " : " + message);

    //        string path = Path.GetDirectoryName(logFile);

    //        if (!Directory.Exists(path))
    //        {
    //            Directory.CreateDirectory(path);
    //        }

    //        FileStream fileStream = new FileStream(logFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
    //        StreamWriter streamWrite = new StreamWriter(fileStream, Encoding.Default);

    //        streamWrite.WriteLine(sb.ToString());
    //        streamWrite.Close();
    //        fileStream.Close();
    //    }
    //}
}
