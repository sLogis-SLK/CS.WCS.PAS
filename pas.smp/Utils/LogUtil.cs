using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace PAS.SMP
{
    public class LogUtil
    {
        /*
         *  25.06.04 김동준 
         *  해당 로그를 위로 올릴수 없는지 확인해보시고 올릴수 있으면 PAS.Core.LogUtil 로 올려보세요~
         *  나중에 Core 쪽에서 로그 하나로 통일 할 예정입니다.
         *  PS : GlobalClass의 경우 최대한 Winform App에서 사용하시고 DB 접속 정보는 Services 에서만 사용하는 걸 추천합니다.
         *       그래야 모듈 개발이 가능함. static 변수 아무데서나 사용가능하다고 다 가져다 쓰면 모듈 구분이 안됨.
         *  나중에 해당 주석은 삭제요망.
         */
        public static void Log(params object[] args)
        {
            if (!GlobalClass.IsLog)
                return;
            string path = Global.g_sStartupPath + GlobalClass.PATH_LOG + ("\\SMP_" + DateTime.Now.ToString("yyyyMMdd") + ".LOG");
            if (!Directory.Exists(Global.g_sStartupPath + GlobalClass.PATH_LOG))
                Directory.CreateDirectory(Global.g_sStartupPath + GlobalClass.PATH_LOG);
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
            if (!GlobalClass.IsLog)
                return;
            string path = Global.g_sStartupPath + GlobalClass.PATH_LOG + ("\\SMP_HISTORY_" + DateTime.Now.ToString("yyyyMMdd") + ".LOG");
            if (!Directory.Exists(Global.g_sStartupPath + GlobalClass.PATH_LOG))
                Directory.CreateDirectory(Global.g_sStartupPath + GlobalClass.PATH_LOG);
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
