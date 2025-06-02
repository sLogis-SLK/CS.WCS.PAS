using System;

namespace PAS.Core
{
    public class ParseUtils
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
    }
}
