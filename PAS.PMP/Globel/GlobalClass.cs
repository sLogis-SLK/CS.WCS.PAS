using PAS.Core;
using PAS.PMP.PasWCS;

namespace PAS.PMP
{
    public class GlobalClass : GlobalCore
    {
        internal static string 장비명 { get => pas환경설정.NAME; }

    }
}
