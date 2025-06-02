using DbProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace PAS.Task.작업
{
    internal class Pas작업
    {
        internal static DataTable 출하상태확인(string s장비명)
        {
            DataTable dt = new DataTable("usp_분류_작업정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), new string[] { "@장비명" }, s장비명);
            return dt;
        }

        internal static void 작업결과저장(string 분류번호, string 장비명, int 관리번호, DataTable dataTable)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("usp_분류_작업결과작성_Set", "@분류번호", "@장비명", "@관리번호", "@udt_DBTABLE");
                oScope.Update(분류번호, 장비명, 관리번호, dataTable);
                oScope.Commit();
            }
        }

        internal static void 박스풀(string s분류번호, string s장비명, string s슈트번호, string s마지막박스여부)
        {
            DataTable dt = new DataTable("usp_분류_박스풀작성_Set");
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("usp_분류_박스풀작성_Set", "@분류번호", "@장비명", "@슈트번호", "@마지막박스여부");
                oScope.Fill(dt, s분류번호, s장비명, s슈트번호, s마지막박스여부);

                //Commit전에 출력
                bool 출력 = true;
                if (출력)
                    oScope.Commit();
                else
                    oScope.Rollback();
            }
        }

        //internal static void test(string ss)
        //{
        //    DataTable dt = new DataTable("usp_김동준_테스트프로시저");
        //    using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
        //    {
        //        oScope.Initialize("usp_김동준_테스트프로시저", "@tmp");
        //        oScope.Fill(dt, ss);
        //        //oScope.Update(s분류번호, s장비명, s슈트번호,s마지막박스여부);
        //        //Commit전에 출력

        //        oScope.Rollback();
        //    }
        //}

    }
}
