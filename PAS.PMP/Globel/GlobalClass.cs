using PAS.Core;
using PAS.PMP.PasWCS;

namespace PAS.PMP
{
    public class GlobalClass : GlobalCore
    {
        internal static string 장비명 { get => pas환경설정.NAME; }

        internal static string LOCAL_FOLDER { get => pas환경설정.LOCAL_FOLDER; }

        internal static string SEIGYO_IP { get => pas환경설정.SEIGYO_IP; }

        internal static string SEIGYO_PORT { get => pas환경설정.SEIGYO_PORT; }

        internal static string CHUTES { get => pas환경설정.CHUTES; }

        public static string GetEmptyString(string s, int iCapacity)
        {
            return string.Format($"{{0,-{(object)iCapacity}}}", (object)s).Substring(0, iCapacity);
        }
    }
}
