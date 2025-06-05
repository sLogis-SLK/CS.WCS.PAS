using DbProvider;
using PAS.Core;
using System;
using System.Data;
using TR_Common;

namespace PAS.PMP
{
    internal class 관리
    {
        internal static void 배정할수없는슈트확인(DataTable dataTable, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_배정할수없는슈트확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_배정할수없는슈트확인_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.PasDBConnectionString),
                new string[] { "@원배치번호", "@배치상태", "@작업일자", "@조회구분자" },
                new object[] { 원배치번호 }
            );
        }

        internal static void 바코드중복확인(string 분류번호, string 장비명, string 원배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_제약사항_바코드중복확인_Set", "@분류번호", "@장비명", "@원배치번호");
                    oScope.Update(분류번호, 장비명, 원배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하박스저장]", (object)ex.Message);
            }
        }

        internal static void 배송사중복배정확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_배송사중복배정확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_배송사중복배정확인_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.PasDBConnectionString),
                new string[] { "@분류번호", "@장비명", "@원배치번호" },
                new object[] { 분류번호, 장비명, 원배치번호 }
            );
        }

        internal static void 매장중복배정확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_매장중복배정확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_매장중복배정확인_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.PasDBConnectionString),
                new string[] { "@분류번호", "@장비명", "@원배치번호" },
                new object[] { 분류번호, 장비명, 원배치번호 }
            );
        }
    }
}
