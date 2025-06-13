using PAS.Core;
using PAS.PMP.PasWCS;
using System.Windows.Forms;

namespace PAS.PMP
{
    public class GlobalClass : GlobalCore
    {
        public static StatusStrip 전역상태바 = (StatusStrip)null;
        public static ToolStripStatusLabel 전역상태메시지 = (ToolStripStatusLabel)null;
        public static ToolStripProgressBar 전역진행상태 = (ToolStripProgressBar)null;

        internal static string 장비명 { get => pas환경설정.NAME; }

        //internal static string 

        internal static string LOCAL_FOLDER { get => pas환경설정.LOCAL_FOLDER; }

        internal static string SEIGYO_IP { get => pas환경설정.SEIGYO_IP; }

        internal static string SEIGYO_PORT { get => pas환경설정.SEIGYO_PORT; }

        internal static string CHUTES { get => pas환경설정.CHUTES; }

        internal static string CHUTES_ERROR { get => pas환경설정.CHUTES_ERROR; }

        public static string GetEmptyString(string s, int iCapacity)
        {
            return string.Format($"{{0,-{(object)iCapacity}}}", (object)s).Substring(0, iCapacity);
        }
    }
}
