using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.PMP.Utils
{
    internal class Command
    {
        public static string GetEmptyString(string s, int iCapacity)
        {
            return string.Format($"{{0,-{(object)iCapacity}}}", (object)s).Substring(0, iCapacity);
        }

        public static byte[] GetStringNumberByte(string s, int iCapacity)
        {
            long num;
            try
            {
                num = Convert.ToInt64(s);
            }
            catch
            {
                num = 0L;
            }
            byte[] numArray = new byte[4];
            byte[] bytes = BitConverter.GetBytes((int)num);
            byte[] dst = new byte[iCapacity];
            Buffer.BlockCopy((Array)bytes, 0, (Array)dst, 0, iCapacity);
            return dst;
        }

        public static byte[] GetStringToUTF8(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            int length = s.Length;
            byte[] dst = new byte[length];
            Buffer.BlockCopy((Array)bytes, 0, (Array)dst, 0, length);
            return dst;
        }

        public static byte[] GetStringToHangul(string s)
        {
            List<byte> byteList = new List<byte>();
            int num1 = 20;
            int num2 = 0;
            for (int index = 0; index < s.Length; ++index)
            {
                if (char.GetUnicodeCategory(s[index]) == UnicodeCategory.OtherLetter)
                    num2 += 2;
                else
                    ++num2;
                if (num1 > num2)
                    byteList.AddRange((IEnumerable<byte>)Encoding.Default.GetBytes(new char[1]
                    {
          s[index]
                    }));
            }
            return byteList.ToArray();
        }
    }
}
