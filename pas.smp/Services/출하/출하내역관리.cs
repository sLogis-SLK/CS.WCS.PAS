using DbProvider;
using PAS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace PAS.SMP.출하
{
    internal partial class 출하내역관리
    {
        internal static void 출하상태확인(DataTable dt, bool is조회구분자)
        {
            try
            {
                if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_상태확인_Get";
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), new string[] { "@조회구분자" }, is조회구분자 ? 1 : 0);
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
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), new string[] { "@박스바코드" }, s박스바코드);
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
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
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
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
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
                TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
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
                    DataTable m_출하박스내역Table = new DataTable("usp_출하_박스별패킹내역_Get_JH");
                    출하박스패킹내역(m_출하박스내역Table, s배치번호, s슈트번호, s박스번호);
                    출력템플릿.롯데택배_템플릿(builder, param, m_출하박스내역Table);
                }
                else if (배송사코드 == "A304")
                {
                    출력템플릿.대한통운_템플릿(builder, param);
                }
                else
                {
                    출력템플릿.기본_템플릿(builder, param);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 바코드출력]", (object)ex.Message);
            }
            return builder.ToString();
        }

    }
}
