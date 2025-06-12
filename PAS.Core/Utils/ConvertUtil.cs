using System;

namespace PAS.Core
{
    public class ConvertUtil
    {
        public static int ObjectToint(Object obj)
        {
            int result = 0;
            string s = obj == null ? "0" : obj.ToString();
            Int32.TryParse(s, out result);
            return result;
        }

        public static string Substring(string s, int i)
        {
            try
            {
                return s.Substring(0, i);
            }
            catch
            {

            }
            return s;
        }

        public static byte[] StringToBuffer(string inStr)
        {
            byte[] numArray = (byte[])null;
            try
            {
                numArray = new byte[inStr.Length / 2];
                if (inStr.Length % 2 == 0)
                {
                    for (int index = 0; index < inStr.Length / 2; ++index)
                        numArray[index] = Convert.ToByte(inStr.ToString().Substring(index * 2, inStr.Length - (inStr.Length - 2)), 16);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return numArray;
        }

        public static bool ObjectToInt32(object obj, out int result)
        {
            try
            {
                string tmp = obj.ToString();
                return Int32.TryParse(tmp, out result);
            }
            catch (Exception ex)
            {
                result = (int)0;
                return false;
            }
        }
        public static bool ObjectToDouble(object obj, out double result)
        {
            try
            {
                string tmp = obj.ToString();
                return double.TryParse(tmp, out result);
            }
            catch (Exception ex)
            {
                result = (double)0;
                return false;
            }
        }
        public static bool IsDouble(string inStr)
        {
            try
            {
                double.Parse(inStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //LogUtil.Log((object)"[SMP9008]", (object)inStr, (object)ex.Message);
                return false;
            }
            return true;
        }

    }
}
