using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.PMP.Models
{
    public enum 응답상태 : uint
    {
        정상 = 48, // 0x00000030
        분류중 = 49, // 0x00000031
        개시완료 = 50, // 0x00000032
        종료완료 = 51, // 0x00000033
        전체완료 = 52, // 0x00000034
        대상외 = 53, // 0x00000035
        실패 = 57, // 0x00000039
    }
}
