using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pas.smp.출하
{
    internal class 출력템플릿
    {
        internal static void 롯데택배_템플릿(StringBuilder builder, Dictionary<string, object> param, DataTable dt)
        {
            try
            {
                string 배치번호 = param["배치번호"] as string;
                string 슈트번호 = param["슈트번호"] as string;
                string 박스번호 = param["박스번호"] as string;
                string 중량 = param["중량"] as string;
                운송장채번Model 운송장 = param["운송장"] as 운송장채번Model;
                DataRow row = param["Row"] as DataRow;
                string 운송장번호 = param["운송장번호"] as string;
                string 정제운송장번호 = param["정제운송장번호"] as string;

                //글꼴
                builder.Append("^XA^SEE:UHANGUL.DAT^FS^CW1,E:KFONT3.FNT^FS^CI26^PON");
                //세로테두리
                builder.Append("^FO0,0,^GB718,1,1^FS")
                    .Append("^FO0,288^GB72,1,1^FS")
                    .Append("^FO0,440^GB72,1,1^FS")
                    .Append("^FO0,566.6^GB718,1,1^FS")
                    .Append("^FO0,958,^GB718,1,1^FS");

                builder.Append("^FO198,566.6^GB1,393.4,1^FS")
                    .Append("^FO640.8,0^GB1,566.6,1^FS")
                    .Append("^FO640.8,208^GB77.2,1,1^FS")
                    .Append("^FO640.8,375^GB77.2,1,1^FS")
                    .Append("^FO532.8,455^GB108,1,1^FS");

                builder.Append("^FO0,0,^GB1,960,1^FS")
                    .Append("^FO72,0^GB1,960,1^FS")
                    .Append("^FO532.8,0^GB1,960,1^FS")
                    .Append("^FO718,0,^GB1,960,1^FS");

                builder.Append("^FO685,0^A1R,20,20^FD 브랜드^FS")
                    .AppendFormat("^FO650,0^A1R,30,30^FD{0}:{1}^FS", row["브랜드코드"].ToString(), row["브랜드명"].ToString())
                    .Append("^FO685,208^A1R,20,20^FD배치번호^FS")
                    .AppendFormat("^FO650,208^A1R,30,30^FD{0}^FS", 배치번호)
                    .Append("^FO685,385^A1R,20,20^FD매장코드^FS")
                    .AppendFormat("^FO650,385^A1R,30,30^FD{0}^FS", row["점코드"].ToString())
                    .Append("^FO610.8,0^A1R,20,20^FD매장^FS")
                    .AppendFormat("^FO545.8,0^A1R,50,40^FD{0}^FS", row["점명"].ToString())
                    .Append("^FO610.8,455^A1R,20,20^FD박스번호^FS")
                    .AppendFormat("^FO565.8,475^A1R,30,30^FD{0}^FS", 박스번호)
                    .Append("^FO685,571.8^A1R,20,20^FD운송장바코드^FS")
                    .AppendFormat("^FO560.8,581.8^B3R,N,100,Y,N^FD>:#{0}^FS", 정제운송장번호)

                    .Append("^FO500,571.8^A1R,20,20^FD배송사정보^FS")
                    .AppendFormat("^FO420,571.8^A1R,60,70^FD{0}^FS", row["배송사명"].ToString())
                    .AppendFormat("^FO370,576.8^A1R,40,40^FD{0}^FS", 운송장.출력값1)
                    .AppendFormat("^FO320,571.8^A1R,35,35^FD{0}^FS", 운송장.출력값2)
                    .Append("^BY1")
                    .AppendFormat("^FO240,606.8^B3R,N,70,Y,N^FD>:#{0}^FS", 운송장.출력값3)
                    .AppendFormat("^FO275,760.8^A1R,30,30^FD{0}^FS", 운송장.출력값4)
                    .AppendFormat("^FO235,760.8^A1R,30,30^FD{0}^FS", 운송장.출력값5)

                    .Append("^FO165,571.8^A1R,20,20^FD수하인주소^FS")
                    .AppendFormat("^FO75,571.8^A1R,30,30^FB400,3,0,L,0 ^FD{0}^FS", row["점주소"].ToString())
                    .Append("^FO45,5^A1R,20,20^FD발행일시^FS")
                    .AppendFormat("^FO10,5^A1R,30,30^FD{0}^FS", DateTime.Now.ToString("yyyy-MM-dd"))
                    .Append("^FO45,293^A1R,20,20^FD슈트번호^FS")
                    .AppendFormat("^FO10,313^A1R,30,30^FD{0}^FS", 슈트번호)
                    .Append("^FO45,450^A1R,20,20^FD중 량^FS")
                    .AppendFormat("^FO10,450^A1R,30,30^FD{0}^FS", 중량)
                    .Append("^FO45,571.8^A1R,20,20^FD송하인^FS")
                    .AppendFormat("^FO10,571.8^A1R,30,30^FD{0}{1}^FS", "SLK ", row["센터명"].ToString());

                builder.Append("^FO500,5^A1R,25,25^FD상품^FS")
                    .Append("^FO500,485^A1R,25,25^FD수량^FS");

                builder.Append("^FO485,5^GB1,20,1^FS")
                    .Append("^FO485,35^GB1,20,1^FS")
                    .Append("^FO485,65^GB1,20,1^FS")
                    .Append("^FO485,95^GB1,20,1^FS")
                    .Append("^FO485,125^GB1,20,1^FS")
                    .Append("^FO485,155^GB1,20,1^FS")
                    .Append("^FO485,185^GB1,20,1^FS")
                    .Append("^FO485,215^GB1,20,1^FS")
                    .Append("^FO485,245^GB1,20,1^FS")
                    .Append("^FO485,275^GB1,20,1^FS")
                    .Append("^FO485,305^GB1,20,1^FS")
                    .Append("^FO485,335^GB1,20,1^FS")
                    .Append("^FO485,365^GB1,20,1^FS")
                    .Append("^FO485,395^GB1,20,1^FS")
                    .Append("^FO485,425^GB1,20,1^FS")
                    .Append("^FO485,455^GB1,20,1^FS")
                    .Append("^FO485,485^GB1,20,1^FS")
                    .Append("^FO485,515^GB1,20,1^FS")
                    .Append("^FO485,545^GB1,20,1^FS");

                #region 상품 리스트 for문

                int 첫행 = 450;
                int 간격 = 30;
                int 행 = 첫행;
                int 출력수량합 = 0;

                // 상위 10개 row 출력
                for (int i = 0; i < Math.Min(dt.Rows.Count, 10); i++)
                {
                    DataRow rows = dt.Rows[i];
                    string 상품정보 = $"{rows["품번"]} {rows["색상"]} {rows["사이즈"]}";
                    string 수량 = rows["수량"].ToString();

                    builder.AppendFormat("^FO{0},5^A1R,20,20^FD{1}^FS", 행, 상품정보);
                    builder.AppendFormat("^FO{0},505^A1R,20,20^FD{1}^FS", 행, 수량);

                    행 -= 간격;

                    if (int.TryParse(수량, out int parsedQty))
                    {
                        출력수량합 += parsedQty;
                    }
                }

                int 전체수량합 = dt.AsEnumerable()
                    .Select(r => r["수량"])
                    .Where(val => val != DBNull.Value)
                    .Sum(val => Convert.ToInt32(val));

                int 나머지수량 = 전체수량합 - 출력수량합;

                if (나머지수량 > 0)
                {
                    builder.AppendFormat("^FO130,475^A1R,20,20^FD 외 {0}건^FS", 나머지수량);
                }

                #endregion

                builder.Append("^FO115,5^GB1,20,1^FS")
                    .Append("^FO115,35^GB1,20,1^FS")
                    .Append("^FO115,65^GB1,20,1^FS")
                    .Append("^FO115,95^GB1,20,1^FS")
                    .Append("^FO115,125^GB1,20,1^FS")
                    .Append("^FO115,155^GB1,20,1^FS")
                    .Append("^FO115,185^GB1,20,1^FS")
                    .Append("^FO115,215^GB1,20,1^FS")
                    .Append("^FO115,245^GB1,20,1^FS")
                    .Append("^FO115,275^GB1,20,1^FS")
                    .Append("^FO115,305^GB1,20,1^FS")
                    .Append("^FO115,335^GB1,20,1^FS")
                    .Append("^FO115,365^GB1,20,1^FS")
                    .Append("^FO115,395^GB1,20,1^FS")
                    .Append("^FO115,425^GB1,20,1^FS")
                    .Append("^FO115,455^GB1,20,1^FS")
                    .Append("^FO115,485^GB1,20,1^FS")
                    .Append("^FO115,515^GB1,20,1^FS")
                    .Append("^FO115,545^GB1,20,1^FS");

                builder.Append("^FO80,415^A1R,20,20^FD합계^FS")
                    .AppendFormat("^FO75,485^A1R,30,30^FD{0}^FS", 전체수량합)
                    .Append("^XZ");
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 롯데택배_템플릿]", (object)ex.Message);
            }
        }

        internal static void 대한통운_템플릿(StringBuilder builder, Dictionary<string, object> param)
        {
            try
            {
                string 배치번호 = param["배치번호"] as string;
                string 슈트번호 = param["슈트번호"] as string;
                string 박스번호 = param["박스번호"] as string;
                string 중량 = param["중량"] as string;
                운송장채번Model 운송장 = param["운송장"] as 운송장채번Model;
                DataRow row = param["Row"] as DataRow;
                string 운송장번호 = param["운송장번호"] as string;
                string 정제운송장번호 = param["정제운송장번호"] as string;

                builder.Append("^XA^SEE:UHANGUL.DAT^FS^CW1,E:KFONT3.FNT^FS^CI26^PON^LH20,20");

                builder.AppendFormat("^FO620,20^A1R,45,35^FD{0}:{1}^FS", row["브랜드코드"].ToString(), row["브랜드명"].ToString())
                    .Append("^FO620,420^A1R,30,20^FD상품^FS")
                    .AppendFormat("FO550,600^BY4,3.0^BCR,120,N,N^FD{0}^FS", 운송장.출력값2)
                    .AppendFormat("^FO550,20^A1R,60,50^FD{0}^FS", row["점명"].ToString())
                    .AppendFormat("^FO500,170^A1R,30,20^FB730,1,0,R,0^FDTel : {0}^FS", row["점전화번호1"].ToString())
                    .AppendFormat("^FO500,0^A1R,30,20^FD{0}^FS", row["점주소"].ToString());

                builder.Append("^FO490,10^GB0,920,2^FS")
                    .Append("^FO450,20^A1R,30,20^FD배치번호^FS")
                    .Append("^FO450,220^A1R,30,20^FD슈트번호^FS")
                    .Append("^FO450,420^A1R,30,20^FD박스번호^FS")
                    .Append("^FO450,620^A1R,30,20^FD중 량^FS")
                    .Append("^FO450,820^A1R,30,20^FD수 량^FS")
                    .AppendFormat("^FO380,20^A1R,40,30^FD{0}^FS", 배치번호)
                    .AppendFormat("^FO380,220^A1R,60,40^FD{0}^FS", 슈트번호)
                    .AppendFormat("^FO380,420^A1R,60,40^FD{0}^FS", 박스번호)
                    .AppendFormat("^FO380,620^A1R,40,30^FD{0}kg^FS", 중량)
                    .AppendFormat("^FO380,820^A1R,60,40^FD{0}^FS", row["내품수"].ToString())
                    .Append("^FO370,10^GB0,920,2^FS");

                builder.AppendFormat("^FO300,40^A1R,60,50^FD{0}^FS", row["배송사명"].ToString());

                builder.AppendFormat("^FO150,40^A1R,150,100^FD{0}^FS", 운송장.출력값2)
                    .AppendFormat("^FO80,40^A1R,60,50^FD{0}^FS", 운송장.출력값1)
                    .AppendFormat("^FO150,370^BY4,3.0^B2R,170,N,N^FD{0}^FS", 정제운송장번호)
                    .AppendFormat("^FO110,370^A1R,30,30^FB550,1,0,C,0^FD{0}^FS", 운송장번호);

                builder.Append("^FO70,10^GB0,920,2^FS")
                    .AppendFormat("^FO20,20^A1R,40,25^FDSLK  {0}^FS", row["센터명"].ToString())
                    .AppendFormat("^FO20,170^A1R,40,25^FB730,1,0,R,0^FD{0}^FS", DateTime.Now.ToString("yyyy-MM-dd"))
                    .Append("^XZ");
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 대한통운_템플릿]", (object)ex.Message);
            }
        }

        internal static void 기본_템플릿(StringBuilder builder, Dictionary<string, object> param)
        {
            try
            {
                string 배치번호 = param["배치번호"] as string;
                string 슈트번호 = param["슈트번호"] as string;
                string 박스번호 = param["박스번호"] as string;
                string 중량 = param["중량"] as string;
                운송장채번Model 운송장 = param["운송장"] as 운송장채번Model;
                DataRow row = param["Row"] as DataRow;
                string 운송장번호 = param["운송장번호"] as string;
                string 정제운송장번호 = param["정제운송장번호"] as string;
                string 배송사코드 = param["배송사코드"] as string;

                builder.Append("^XA^SEE:UHANGUL.DAT^FS^CW1,E:KFONT3.FNT^FS^CI26^PON^LH20,20");

                builder.AppendFormat("^FO620,20^A1R,45,35^FD{0}:{1}^FS", row["브랜드코드"].ToString(), row["브랜드명"].ToString())
                    .Append("^FO620,170^A1R,45,35^FB730,1,0,R,0^FD상품^FS")
                    .AppendFormat("^FO550,20^A1R,60,50^FD{0}^FS", row["점명"].ToString())
                    .AppendFormat("^FO550,170^A1R,40,25^FB730,1,0,R,0^FDTel : {0}^FS", row["점전화번호1"].ToString())
                    .AppendFormat("^FO500,0^A1R,40,25^FB900,1,0,R,0^FD{0}^FS", row["점주소"].ToString());

                builder.Append("^FO490,10^GB0,920,2^FS")
                    .Append("^FO450,20^A1R,30,20^FD배치번호^FS")
                    .Append("^FO450,220^A1R,30,20^FD슈트번호^FS")
                    .Append("^FO450,420^A1R,30,20^FD박스번호^FS")
                    .Append("^FO450,620^A1R,30,20^FD중 량^FS")
                    .Append("^FO450,820^A1R,30,20^FD수 량^FS")
                    .AppendFormat("^FO380,20^A1R,40,30^FD{0}^FS", 배치번호)
                    .AppendFormat("^FO380,220^A1R,60,40^FD{0}^FS", 슈트번호)
                    .AppendFormat("^FO380,420^A1R,60,40^FD{0}^FS", 박스번호)
                    .AppendFormat("^FO380,620^A1R,40,30^FD{0}kg^FS", 중량)
                    .AppendFormat("^FO380,820^A1R,60,40^FD{0}^FS", row["내품수"].ToString())
                    .Append("^FO370,10^GB0,920,2^FS");

                builder.AppendFormat("^FO300,40^A1R,60,50^FD{0}^FS", row["배송사명"].ToString());

                builder.AppendFormat("^FO150,40^A1R,150,120^FD{0}^FS", 운송장.출력값1)
                    .AppendFormat("^FO80,40^A1R,60,50^FD{0}^FS", 운송장.출력값2);

                string 바코드줄 = 배송사코드 == "A316"
                    ? $"^FO150,320^BY2,3.0^B2R,170,N,N^FD{정제운송장번호}^FS"
                    : $"^FO150,320^BY4,3.0^B2R,170,N,N^FD{정제운송장번호}^FS";

                builder.Append(바코드줄)
                       .AppendFormat("^FO110,320^A1R,30,30^FB600,1,0,C,0^FD{0}^FS", 운송장번호);

                builder.Append("^FO70,10^GB0,920,2^FS")
                    .AppendFormat("^FO20,20^A1R,40,25^FDSLK  {0}^FS", row["센터명"].ToString())
                    .AppendFormat("^FO20,170^A1R,40,25^FB730,1,0,R,0^FD{0}^FS", DateTime.Now.ToString("yyyy-MM-dd"))
                    .Append("^XZ");
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 기본_템플릿]", (object)ex.Message);
            }
        }
    }
}
