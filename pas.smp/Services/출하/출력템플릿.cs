using PAS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.SMP.출하
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
                builder.Append("^FO0,0,^GB678,1,1^FS")
                    .Append("^FO0,268^GB57,1,1^FS")
                    .Append("^FO0,420^GB57,1,1^FS")
                    .Append("^FO0,526.6^GB678,1,1^FS")
                    .Append("^FO0,918,^GB678,1,1^FS");

                builder.Append("^FO208,526.6^GB1,392.4,1^FS")
                    .Append("^FO610.8,0^GB1,526.6,1^FS")
                    .Append("^FO610.8,248^GB67.2,1,1^FS")
                    .Append("^FO517.8,415^GB160.2,1,1^FS");

                builder.Append("^FO0,0,^GB1,919,1^FS")
                    .Append("^FO57,0^GB1,919,1^FS")
                    .Append("^FO517.8,0^GB1,919,1^FS")
                    .Append("^FO678,0,^GB1,919,1^FS");

                builder.Append("^FO655,0^A1R,20,20^FD 브랜드^FS")
                    .AppendFormat("^FO620,0^A1R,30,30^FD{0}:{1}^FS", row["브랜드코드"].ToString(), row["브랜드명"].ToString())

                    .Append("^FO655,248^A1R,20,20^FD배치번호^FS")
                    .AppendFormat("^FO620,248^A1R,30,30^FD{0}^FS", 배치번호)

                    .Append("^FO655,415^A1R,20,20^FD매장코드^FS")
                    .AppendFormat("^FO620,415^A1R,30,30^FD{0}^FS", row["점코드"].ToString())

                    .Append("^FO580.8,0^A1R,20,20^FD매장^FS")
                    .AppendFormat("^FO525.8,0^A1R,50,40^FD{0}^FS", row["점명"].ToString())

                    .Append("^FO580.8,415^A1R,20,20^FD박스번호^FS")
                    .AppendFormat("^FO535.8,435^A1R,30,30^FD{0}^FS", 박스번호)

                    .Append("^FO660,526.8^A1R,20,20^FD운송장바코드^FS")
                    .AppendFormat("^FO550.8,541.8^BY2,3.0^B3R,N,100,N,N^FD>:#{0}^FS", 정제운송장번호)

                    .Append("^FO490,531.8^A1R,20,20^FD배송사정보^FS")
                    .AppendFormat("^FO420,531.8^A1R,60,70^FD{0}^FS", row["배송사명"].ToString())
                    .AppendFormat("^FO370,536.8^A1R,40,40^FD{0}^FS", 운송장.출력값1)
                    .AppendFormat("^FO320,531.8^A1R,35,35^FD{0}^FS", 운송장.출력값2)
                    .AppendFormat("^FO240,566.8^BY2,3.0^B3R,N,70,N,N^FD>:#{0}^FS", 운송장.출력값3)
                    .AppendFormat("^FO275,720.8^A1R,30,30^FD{0}^FS", 운송장.출력값4)
                    .AppendFormat("^FO235,720.8^A1R,30,30^FD{0}^FS", 운송장.출력값5)

                    .Append("^FO180,531.8^A1R,20,20^FD수하인주소^FS")
                    .AppendFormat("^FO75,531.8^A1R,30,30^FB370,3,0,L,0 ^FD{0}^FS", row["점주소"].ToString())
                    .Append("^FO35,5^A1R,20,20^FD발행일시^FS")
                    .AppendFormat("^FO0,5^A1R,30,30^FD{0}^FS", DateTime.Now.ToString("yyyy-MM-dd"))
                    .Append("^FO35,273^A1R,20,20^FD슈트번호^FS")
                    .AppendFormat("^FO0,293^A1R,30,30^FD{0}^FS", 슈트번호)
                    .Append("^FO35,430^A1R,20,20^FD중 량^FS")
                    .AppendFormat("^FO0,430^A1R,30,30^FD{0}^FS", 중량)
                    .Append("^FO35,531.8^A1R,20,20^FD송하인^FS")
                    .AppendFormat("^FO0,531.8^A1R,30,30^FD{0}{1}^FS", "SLK ", row["센터명"].ToString());

                builder.Append("^FO490,10^A1R,25,25^FD상품^FS")
                    .Append("^FO490,470^A1R,25,25^FD수량^FS");

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
                    .Append("^FO485,515^GB1,10,1^FS");

                #region 상품 리스트 for문

                int 첫행 = 440;
                int 간격 = 40;
                int 행 = 첫행;
                int 출력수량합 = 0;

                // 상위 10개 row 출력
                for (int i = 0; i < Math.Min(dt.Rows.Count, 8); i++)
                {
                    DataRow rows = dt.Rows[i];
                    string 상품정보 = $"{rows["품번"]} {rows["색상"]} {rows["사이즈"]}";
                    string 수량 = rows["수량"].ToString();

                    builder.AppendFormat("^FO{0},5^A1R,30,30^FD{1}^FS", 행, 상품정보);
                    builder.AppendFormat("^FO{0},485^A1R,30,30^FD{1}^FS", 행, 수량);

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
                    builder.AppendFormat("^FO120,425^A1R,30,30^FD 외 {0}건^FS", 나머지수량);
                }

                #endregion

                builder.Append("^FO105,5^GB1,20,1^FS")
                    .Append("^FO105,35^GB1,20,1^FS")
                    .Append("^FO105,65^GB1,20,1^FS")
                    .Append("^FO105,95^GB1,20,1^FS")
                    .Append("^FO105,125^GB1,20,1^FS")
                    .Append("^FO105,155^GB1,20,1^FS")
                    .Append("^FO105,185^GB1,20,1^FS")
                    .Append("^FO105,215^GB1,20,1^FS")
                    .Append("^FO105,245^GB1,20,1^FS")
                    .Append("^FO105,275^GB1,20,1^FS")
                    .Append("^FO105,305^GB1,20,1^FS")
                    .Append("^FO105,335^GB1,20,1^FS")
                    .Append("^FO105,365^GB1,20,1^FS")
                    .Append("^FO105,395^GB1,20,1^FS")
                    .Append("^FO105,425^GB1,20,1^FS")
                    .Append("^FO105,455^GB1,20,1^FS")
                    .Append("^FO105,485^GB1,20,1^FS")
                    .Append("^FO105,515^GB1,10,1^FS");

                builder.Append("^FO70,400^A1R,20,20^FD합계^FS")
                    .AppendFormat("^FO65,460^A1R,30,30^FD{0}^FS", 전체수량합)
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
