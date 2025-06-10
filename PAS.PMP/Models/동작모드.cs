using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.PMP.Models
{
    public enum 동작모드 : uint
    {
        개시 = 49, // 0x00000031
        종료 = 50, // 0x00000032
        중단 = 51, // 0x00000033
    }
}
