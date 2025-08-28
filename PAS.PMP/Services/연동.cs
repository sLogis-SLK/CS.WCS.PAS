using DbProvider;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace PAS.PMP.PasWCS
{
    internal class 연동
    {
        public static void 조회미수신기간별(DataTable 관리Table, string 조회시작일자, string 조회종료일자, bool 데이터조회여부)
        {
            관리Table.TableName = "usp_PAS_배치정보_Get";

            TlkTranscope.GetData(관리Table, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString),
                new string[] { "@기간앞", "@기간뒤", "@조회구분자" }, 조회시작일자, 조회종료일자, 데이터조회여부 ? 1 : 0);
        }

        public static void 조회수신기간별(DataTable 관리Table, string 조회시작일자, string 조회종료일자, bool 데이터조회여부)
        {
            관리Table.TableName = "usp_연동_작업지시_Get_JHG";

            TlkTranscope.GetData(관리Table, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@기간앞", "@기간뒤", "@조회구분자" }, 조회시작일자, 조회종료일자, 데이터조회여부 ? 1 : 0);
        }

        internal static void 수신(List<string> 배치번호리스트)
        {
            int count = 0;
            string 진행배치번호 = string.Empty;
            try
            {
                foreach (var 배치번호 in 배치번호리스트)
                {
                    count++;
                    진행배치번호 = 배치번호;
                    //배치번호 한개씩 처리하도록 함 - SqlBulkCopy 때문
                    using (TlkTranscope oScopeWCSIF = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                    {
                        DataTable dt = new DataTable("usp_PAS_주문정보_Get");
                        TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), new string[] { "@배치번호" }, 배치번호);

                        oScopeWCSIF.Initialize("usp_PAS_배치수신_Set", "@배치번호");
                        oScopeWCSIF.Update(배치번호);

                        using (SqlConnection connection = new SqlConnection(GlobalClass.PasDBConnectionString))
                        {
                            connection.Open();

                            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                            {
                                bulkCopy.DestinationTableName = "연동_작업지시";  // 삽입할 테이블 이름
                                bulkCopy.BatchSize = 50000;  // 배치 크기 설정 (한 번에 삽입할 데이터 수)
                                bulkCopy.WriteToServer(dt);  // 데이터 삽입
                            }
                        }
                        oScopeWCSIF.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{진행배치번호} - {count}/{배치번호리스트.Count}  처리중 오류 : " + ex.Message, ex);
            }
        }

        internal static void 수신취소(List<string> 배치번호리스트)
        {
            using (TlkTranscope oScopeWCSIF = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
            using (TlkTranscope oScopeOP = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
            {
                foreach (var 배치번호 in 배치번호리스트)
                {
                    oScopeOP.Initialize("usp_연동_수신취소_Set", "@원배치번호");
                    oScopeOP.Update(배치번호);

                    oScopeWCSIF.Initialize("usp_PAS_배치반영취소_Set", "@원배치번호");
                    oScopeWCSIF.Update(배치번호);
                }

                //한번에 수신취소
                oScopeWCSIF.Commit();
                oScopeOP.Commit();
            }
        }

        public static void 배치작업조회(DataTable 관리Table, string 장비명, string 배치상태, string 작업일자, bool 데이터조회여부)
        {
            관리Table.TableName = "usp_분류_작업요약_Get";
            if (string.IsNullOrEmpty(장비명)) 장비명 = "모두";
            if (string.IsNullOrEmpty(배치상태)) 배치상태 = "모두";

            TlkTranscope.GetData(관리Table, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@장비명", "@배치상태", "@작업일자", "@조회구분자" }, 장비명, 배치상태, 작업일자, 데이터조회여부 ? 1 : 0);
        }

        internal static void PAS배송사변경(DataTable dataTable, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_PAS_배송사변경_Get")
            {
                dataTable.TableName = "usp_PAS_배송사변경_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString),
            new string[] { "@배치번호", "@조회구분자" },
            new object[] { 배치번호, 구분자 }
            );
        }

        internal static void PAS실적반영(string 배치번호, string XML)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_PAS_실적반영_Set", "@배치번호", "@상태", "@XML");
                    oScope.Update(배치번호, null, XML);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void PAS배치반영(string 배치번호, string XML)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_PAS_배치반영_Set", "@배치번호", "@XML");
                    oScope.Update(배치번호, XML);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void PAS실적반영취소(string 배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_PAS_실적반영취소_Set", "@배치번호");
                    oScope.Update(배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void PAS배치반영취소(string 배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_PAS_배치반영취소_Set", "@배치번호");
                    oScope.Update(배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void PAS슈트조정(string 원배치번호, string XML)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.HostDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_PAS_슈트조정_Set", "@원배치번호", "@XML");
                    oScope.Update(원배치번호, XML);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
