using DbProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace pas.smp.출하
{
    internal class 출하내역관리
    {
        private static DataTable m_출하박스내역Table = new DataTable("usp_출하_박스별패킹내역_Get_JH");
        internal static void 출하상태확인(DataTable dt, bool is조회구분자)
        {
            try
            {
                if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_상태확인_Get";
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString), new string[] { "@조회구분자" }, is조회구분자 ? 1 : 0);
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하상태확인]", (object)ex.Message);
            }
            
        }
        
        internal static void 출하박스내역(DataTable dt, string s박스바코드)
        {
            try
            {
                if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_박스내용_Get";
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString), new string[] { "@박스바코드" }, s박스바코드);
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하박스내역]", (object)ex.Message);
            }
            
        }

        internal static DataTable 출하박스이력()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("매장명", typeof(string));
            dt.Columns.Add("★", typeof(string));
            dt.Columns.Add("배치번호", typeof(string));
            dt.Columns.Add("슈트번호", typeof(string));
            dt.Columns.Add("박스", typeof(string));
            dt.Columns.Add("중량", typeof(string));
            return dt;
        }

        internal static bool 출하박스저장(string 배치번호, string 슈트번호, string 박스번호, string 출력값1, string 출력값2, string 출력값3, string 출력값4, string 출력값5, string 출력값6, string 출력값7, string 출력값8, string 출력값9, string 출력값10, string 중량, string 운송장출력, string 거래명세서)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_출하_박스내용_Set", "@배치번호", "@슈트번호", "@박스번호",
                        "@출력값1", "@출력값2", "@출력값3", "@출력값4", "@출력값5", "@출력값6", "@출력값7", "@출력값8", "@출력값9", "@출력값10",
                        "@중량", "@운송장출력", "@거래명세서");
                    oScope.Update(배치번호, 슈트번호, 박스번호,
                        출력값1, 출력값2, 출력값3, 출력값4, 출력값5, 출력값6, 출력값7, 출력값8, 출력값9, 출력값10,
                        중량, 운송장출력, 거래명세서);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하박스저장]", (object)ex.Message);
            }
            return true;
        }

        internal static void 출하미발행박스조회(DataTable dt, bool is조회구분자, string 작업일자)
        {
            try
            {
                if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_미발행박스_Get";
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString),
                    new string[] { "@작업일자", "@분류번호", "@조회구분자" }
                    , 작업일자
                    , string.Empty
                    , is조회구분자
                    );
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하미발행박스조회]", (object)ex.Message);
            }
        }

        internal static void 출하박스패킹내역(DataTable dt, string 배치번호, string 슈트번호, string 박스번호)
        {
            try 
            {
                if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_박스별패킹내역_Get_JH";
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString),
                    new string[] { "@배치번호", "@슈트번호", "@박스번호" },
                    new object[] { 배치번호
                                , 슈트번호
                                , 박스번호}
                    );
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하박스패킹내역]", (object)ex.Message);
            }
        }

        internal static string 바코드출력(string s배치번호, string s슈트번호, string s박스번호, string s중량, 운송장채번Model c운송장, DataRow row)
        {
            var builder = new StringBuilder();
            try 
            {
                if (c운송장 == null || row == null || row.ItemArray == null || row.ItemArray.Length == 0)
                    return string.Empty;

                string 운송장번호 = c운송장.운송장번호;
                string 정제운송장번호 = Regex.Replace(운송장번호, "[^0-9a-zA-Z]", string.Empty);
                string 배송사코드 = row["배송사코드"].ToString();

                var param = new Dictionary<string, object>
                {
                    ["배치번호"] = s배치번호,
                    ["슈트번호"] = s슈트번호,
                    ["박스번호"] = s박스번호,
                    ["중량"] = s중량,
                    ["운송장"] = c운송장,
                    ["Row"] = row,
                    ["운송장번호"] = 운송장번호,
                    ["정제운송장번호"] = 정제운송장번호,
                    ["배송사코드"] = 배송사코드,
                };

                // 배송사별 처리
                if (배송사코드 == "A302")
                {
                    출하박스패킹내역(m_출하박스내역Table, s배치번호, s슈트번호, s박스번호);
                    롯데택배_템플릿(builder, param, m_출하박스내역Table);
                }
                else if (배송사코드 == "A304")
                {
                    대한통운_템플릿(builder, param);
                }
                else
                {
                    기본_템플릿(builder, param);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 바코드출력]", (object)ex.Message);
            }
            return builder.ToString();
        }

        private static void 롯데택배_템플릿(StringBuilder builder, Dictionary<string, object> param, DataTable dt)
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

                builder.Append("^XA^SEE:UHANGUL.DAT^FS^CW1,E:KFONT3.FNT^FS^CI26^PON");

                builder.Append("^FO360,0^GB1,80,1^FS")
                    .Append("^FO600,0^GB1,200,1^FS")
                    .Append("^FO760,0^GB1,800,1^FS")
                    .Append("^FO0,80^GB760,1,1^FS")
                    .Append("^FO0,200^GB1200,1,1^FS")
                    .Append("^FO360,720^GB1,80,1^FS")
                    .Append("^FO600,720^GB1,200,1^FS")
                    .Append("^FO0,720^GB1200,1,1^FS")
                    .Append("^FO760,570^GB480,1,1^FS");

                builder.Append("^FO5,8^A1,N,8,8^FD브랜드^FS")
                    .Append("^FO365,8^A1,N,8,8^FD배치번호^FS")
                    .Append("^FO605,8^A1,N,8,8^FD매장코드^FS")
                    .Append("^FO765,8^A1,N,8,8^FD운송장바코드^FS")
                    .Append("^FO0,85^A1,N,8,8^FD매장^FS")
                    .Append("^FO605,85^A1,N,8,8^FD박스번호^FS")
                    .Append("^FO765,210^A1,N,8,8^FD배송사정보^FS")
                    .Append("^FO765,580^A1,N,8,8^FD수하인 주소^FS")
                    .Append("^FO5,725^A1,N,8,8^FD발행일시^FS")
                    .Append("^FO365,725^A1,N,8,8^FD슈트번호^FS")
                    .Append("^FO605,725^A1,N,8,8^FD중 량^FS")
                    .Append("^FO765,725^A1,N,8,8^FD송하인^FS");

                builder.AppendFormat("^FO5,40^A1,N,15,15^FD{0}:{1}^FS", row["브랜드코드"].ToString(), row["브랜드명"].ToString())
                    .AppendFormat("^FO365,40^A1,N,15,15^FD{0}^FS", 배치번호)
                    .AppendFormat("^FO605,40^A1,N,15,15^FD{0}^FS", row["점코드"].ToString())
                    .AppendFormat("^FO765,40^B2,N,100,Y,N^FD>:{0}^FS", 정제운송장번호)
                    .AppendFormat("^FO5,120^A1,N,25,25^FD{0}^FS", row["점명"].ToString())
                    .AppendFormat("^FO610,120^A1,N,15,15^FD{0}^FS", 박스번호)
                    .AppendFormat("^FO765,250^A1,N,20,20^FD#{0}^FS", row["배송사명"].ToString())
                    .AppendFormat("^FO765,300^A1,N,25,25^FD#{0}^FS", 운송장.출력값1)
                    .AppendFormat("^FO765,360^A1,N,20,20^FD#{0}^FS", 운송장.출력값2)
                    .Append("^BY1")
                    .AppendFormat("^FO765,430^B3,N,80,N,N^FD>:#{0}^FS", 운송장.출력값3)
                    .AppendFormat("^FO970,430^A1,N,20,20^FD#{0}^FS", 운송장.출력값4)
                    .AppendFormat("^FO970,500^A1,N,20,20^FD#{0}^FS", 운송장.출력값5)
                    .AppendFormat("^FO766,615^A1,N,10,10^FB400,4,0,L^FD{0}^FS", row["점주소"].ToString())
                    .AppendFormat("^FO5,755^A1,N,10,10^FD{0}^FS", DateTime.Now.ToString("yyyy-MM-dd"))
                    .AppendFormat("^FO365,755^A1,N,8,8^FD{0}^FS", 슈트번호)
                    .AppendFormat("^FO605,755^A1,N,8,8^FD{0}^FS", 중량)
                    .AppendFormat("^FO765,755^A1,N,8,8^FD{0}{1}^FS", "SLK ", row["센터명"].ToString());

                builder.Append("^FO10,215^A1,N,12,12^FD상품^FS")
                    .Append("^FO635,215^A1,N,8,8^FD수량^FS");

                builder.Append("^FO5,250^GB20,1,1^FS")
                    .Append("^F35,250^GB20,1,1^FS")
                    .Append("^F65,250^GB20,1,1^FS")
                    .Append("^F95,250^GB20,1,1^FS")
                    .Append("^F125,250^GB20,1,1^FS")
                    .Append("^F155,250^GB20,1,1^FS")
                    .Append("^F185,250^GB20,1,1^FS")
                    .Append("^F215,250^GB20,1,1^FS")
                    .Append("^F245,250^GB20,1,1^FS")
                    .Append("^F275,250^GB20,1,1^FS")
                    .Append("^F305,250^GB20,1,1^FS")
                    .Append("^F335,250^GB20,1,1^FS")
                    .Append("^F365,250^GB20,1,1^FS")
                    .Append("^F395,250^GB20,1,1^FS")
                    .Append("^F425,250^GB20,1,1^FS")
                    .Append("^F455,250^GB20,1,1^FS")
                    .Append("^F485,250^GB20,1,1^FS")
                    .Append("^F515,250^GB20,1,1^FS")
                    .Append("^F545,250^GB20,1,1^FS")
                    .Append("^F575,250^GB20,1,1^FS")
                    .Append("^F605,250^GB20,1,1^FS")
                    .Append("^F635,250^GB20,1,1^FS")
                    .Append("^F665,250^GB20,1,1^FS")
                    .Append("^F695,250^GB20,1,1^FS")
                    .Append("^F725,250^GB20,1,1^FS");

                #region 상품 리스트 for문

                int 첫행 = 270;
                int 간격 = 30;
                int 행 = 첫행;
                int 출력수량합 = 0;

                // 상위 10개 row 출력
                for (int i = 0; i < Math.Min(dt.Rows.Count, 10); i++)
                {
                    DataRow rows = dt.Rows[i];
                    string 상품정보 = $"{rows["상품명"]} {rows["색상"]} {rows["사이즈"]}";
                    string 수량 = rows["수량"].ToString();

                    builder.AppendFormat("^FO5,{0}^A1,N,12,12^FD {1}^FS", 행, 상품정보);
                    builder.AppendFormat("^FO650,{0}^A1,N,12,12^FD{1}^FS", 행, 수량);

                    행 += 간격;

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
                    builder.AppendFormat("^FO600,625^A1,N,12,12^FD 외 {0}건^FS", 나머지수량);
                }

                #endregion

                builder.Append("^FO5,655^GB20,1,1^FS")
                    .Append("^F35,655^GB20,1,1^FS")
                    .Append("^F65,655^GB20,1,1^FS")
                    .Append("^F95,655^GB20,1,1^FS")
                    .Append("^F125,655^GB20,1,1^FS")
                    .Append("^F155,655^GB20,1,1^FS")
                    .Append("^F185,655^GB20,1,1^FS")
                    .Append("^F215,655^GB20,1,1^FS")
                    .Append("^F245,655^GB20,1,1^FS")
                    .Append("^F275,655^GB20,1,1^FS")
                    .Append("^F305,655^GB20,1,1^FS")
                    .Append("^F335,655^GB20,1,1^FS")
                    .Append("^F365,655^GB20,1,1^FS")
                    .Append("^F395,655^GB20,1,1^FS")
                    .Append("^F425,655^GB20,1,1^FS")
                    .Append("^F455,655^GB20,1,1^FS")
                    .Append("^F485,655^GB20,1,1^FS")
                    .Append("^F515,655^GB20,1,1^FS")
                    .Append("^F545,655^GB20,1,1^FS")
                    .Append("^F575,655^GB20,1,1^FS")
                    .Append("^F605,655^GB20,1,1^FS")
                    .Append("^F635,655^GB20,1,1^FS")
                    .Append("^F665,655^GB20,1,1^FS")
                    .Append("^F695,655^GB20,1,1^FS")
                    .Append("^F725,655^GB20,1,1^FS");

                builder.Append("^FO660,670^A1,N,10,10^FD합계^FS")
                    .AppendFormat("^FO660,670^A1,N,18,18^FD{0}^FS", 전체수량합)
                    .Append("^XZ");
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 롯데택배_템플릿]", (object)ex.Message);
            }
        }

        private static void 대한통운_템플릿(StringBuilder builder, Dictionary<string, object> param)
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

        private static void 기본_템플릿(StringBuilder builder, Dictionary<string, object> param)
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

                builder.AppendFormat("^FO150,40^A1R,150,100^FD{0}^FS", 운송장.출력값2)
                    .AppendFormat("^FO80,40^A1R,60,50^FD{0}^FS", 운송장.출력값1);

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
