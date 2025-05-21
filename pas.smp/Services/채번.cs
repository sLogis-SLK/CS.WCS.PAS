using System;
using System.IO;
using System.Net;
using System.Text;

namespace pas.smp
{
    public class 채번
    {
        //s센터코드, sB코드, s배송사코드, s점코드
        public static 운송장채번Model 운송장채번(string s장비코드, string s회원사코드, string s센터코드, string sB코드, string s배송사코드, string s점코드)
        {
            운송장채번Model waybill = new 운송장채번Model();
            
            try
            {
                string sResponse원본 = string.Empty;

                byte[] numArray = new byte[1024];
                string str1 = "\u0002";
                string str2 = "\u0003";
                string str3 = "\b";
                string str4 = "\a";

                Stream responseStream = WebRequest.Create(GlobalClass.Setting.URL + "sP1=" + s장비코드 + "&sP2=" + s회원사코드 + "&sP3=" + s센터코드 + "&sP4=" + sB코드 + "&sP5=" + s배송사코드 + "&sP6=" + s점코드).GetResponse().GetResponseStream();
                while (responseStream.Read(numArray, 0, numArray.Length) != 0)
                    sResponse원본 += Encoding.Default.GetString(numArray);
                responseStream.Close();

                //변환한 데이터
                string sResponseData = sResponse원본.Trim().Replace("\t", "").Replace("\r", "").Replace("\n", "").Replace("\r\n", "").Replace("\0", "");
                if (sResponseData.Substring(0, 1).Equals(str1))
                {
                    if (sResponseData.Substring(sResponseData.Length - 1, 1).Equals(str2))
                    {
                        string strTmp1 = sResponseData.Substring(1, sResponseData.Length - 2);
                        int lengthTmp1 = strTmp1.IndexOf(str3, 0);

                        switch (strTmp1.Substring(0, 1))
                        {
                            case "1":
                                string strTmp2 = strTmp1.Substring(lengthTmp1 + 1, strTmp1.Length - (lengthTmp1 + 1));

                                string[] strArray = strTmp2.Replace("\b", "").Split(Convert.ToChar(str4));
                                waybill.채번여부 = true;
                                waybill.메시지 = "성공";
                                waybill.운송장번호 = strArray[0].ToString();
                                waybill.출력값1 = strArray[1].ToString();
                                waybill.출력값2 = strArray[2].ToString();
                                waybill.출력값3 = strArray[3].ToString();
                                waybill.출력값4 = strArray[4].ToString();
                                waybill.출력값5 = strArray[5].ToString();
                                waybill.출력값6 = strArray[6].ToString();
                                waybill.배송사코드 = s배송사코드;
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
