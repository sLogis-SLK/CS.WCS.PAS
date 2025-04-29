using System;
using System.IO;
using System.Net;
using System.Text;

namespace pas.smp
{
    public class 채번
    {

        public static 운송장채번Model 운송장채번(string sDivCd, string sCoCd, string sCenterCd, string sBcode, string sShippingCd, string sShopCd)
        {
            운송장채번Model waybill = new 운송장채번Model();
            string str1 = sDivCd;
            string str2 = sCoCd;
            string str3 = sCenterCd;
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            byte[] numArray = new byte[1024];
            string str4 = "\u0002";
            string str5 = "\u0003";
            string str6 = "\b";
            string str7 = "\a";
            try
            {
                Stream responseStream = WebRequest.Create(GlobalClass.URL + "sP1=" + str1 + "&sP2=" + str2 + "&sP3=" + str3 + "&sP4=" + sBcode + "&sP5=" + sShippingCd + "&sP6=" + sShopCd).GetResponse().GetResponseStream();
                while (responseStream.Read(numArray, 0, numArray.Length) != 0)
                    empty1 += Encoding.Default.GetString(numArray);
                responseStream.Close();

                string str8 = empty1;
                string empty4 = string.Empty;
                string empty5 = string.Empty;
                string empty6 = string.Empty;
                string str9 = str8.Trim().Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Replace("\0", "");
                if (str9.Substring(0, 1).Equals(str4))
                {
                    if (str9.Substring(str9.Length - 1, 1).Equals(str5))
                    {
                        string str10 = str9.Substring(1, str9.Length - 2);
                        string str11 = str10.Substring(0, 1);
                        int length1 = str10.IndexOf(str6, 0);
                        str10.Substring(0, length1);
                        switch (str11)
                        {
                            case "1":
                                string str12 = str10.Substring(length1 + 1, str10.Length - (length1 + 1));
                                int length2 = str12.IndexOf(str6, 0);
                                str12.Substring(0, length2);
                                string[] strArray = str12.Replace("\b", "").Split(Convert.ToChar(str7));
                                waybill.채번여부 = true;
                                waybill.메시지 = "성공";
                                waybill.운송장번호 = strArray[0].ToString();
                                waybill.출력값1 = strArray[1].ToString();
                                waybill.출력값2 = strArray[2].ToString();
                                waybill.출력값3 = strArray[3].ToString();
                                waybill.출력값4 = strArray[4].ToString();
                                waybill.출력값5 = strArray[5].ToString();
                                waybill.출력값6 = strArray[6].ToString();
                                waybill.배송사코드 = sShippingCd;
                                break;
                            default:
                                waybill.채번여부 = false;
                                waybill.메시지 = "운송장채번오류발생";
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                waybill.채번여부 = false;
                waybill.메시지 = "운송장채번오류발생";
            }
            return waybill;
        }

    }
}
