using DbProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace pas.smp.출하
{
    internal class 출하내역관리
    {
        internal static void 출하상태확인(DataTable dt, bool is조회구분자)
        {
            if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_상태확인_Get";
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString), new string[] { "@조회구분자" }, is조회구분자 ? 1 : 0);
        }

        internal static void 출하박스내역(DataTable dt, string s박스바코드)
        {
            if (string.IsNullOrEmpty(dt.TableName)) dt.TableName = "usp_출하_박스내용_Get";
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.ConnectionString), new string[] { "@박스바코드" }, s박스바코드);
        }

        internal static bool 출하박스저장()
        {
            //DbProvider.Excute(Common.ConnectionString(), "usp_출하_박스내용_Set", 
            //    DbProvider.GetParameter("@배치번호", (object)s실배치번호), 
            //    DbProvider.GetParameter("@슈트번호", (object)s슈트번호), 
            //    DbProvider.GetParameter("@박스번호", (object)s박스번호), 
            //    DbProvider.GetParameter("@출력값1", (object)oWaybill.운송장번호), 
            //    DbProvider.GetParameter("@출력값2", (object)oWaybill.출력값2), 
            //    DbProvider.GetParameter("@출력값3", (object)oWaybill.출력값1),
            //    DbProvider.GetParameter("@출력값4", (object)oWaybill.출력값4), 
            //    DbProvider.GetParameter("@출력값5", (object)oWaybill.출력값3), 
            //    DbProvider.GetParameter("@출력값6", (object)string.Empty),
            //    DbProvider.GetParameter("@출력값7", (object)string.Empty), 
            //    DbProvider.GetParameter("@출력값8", (object)string.Empty), 
            //    DbProvider.GetParameter("@출력값9", (object)string.Empty), 
            //    DbProvider.GetParameter("@출력값10", (object)string.Empty),
            //    DbProvider.GetParameter("@중량", (object)s중량), 
            //    DbProvider.GetParameter("@운송장출력", (object)"1"), 
            //    DbProvider.GetParameter("@거래명세서", (object)"1"));
            return true;
        }

        internal static string 바코드출력(string s배치번호, string s슈트번호, string s박스번호, string s중량, 운송장채번Model c운송장, DataRow row)
        {
            throw new NotImplementedException();
        }
    }
}
