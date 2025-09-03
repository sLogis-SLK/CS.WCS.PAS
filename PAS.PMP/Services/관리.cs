using DbProvider;
using PAS.Core;
using System;
using System.Data;
using System.Windows.Forms;
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

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                       new string[] { "@원배치번호" },
                       new object[] { 원배치번호 }
                   );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        internal static void 바코드중복확인(string 분류번호, string 장비명, string 원배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_제약사항_바코드중복확인_Set", "@분류번호", "@장비명", "@원배치번호");
                    oScope.Update(분류번호, 장비명, 원배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하내역관리 출하박스저장]", (object)ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 배송사중복배정확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_배송사중복배정확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_배송사중복배정확인_Get";
            }

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                    new string[] { "@분류번호", "@장비명", "@원배치번호" },
                    new object[] { 분류번호, 장비명, 원배치번호 }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        internal static void 매장중복배정확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_매장중복배정확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_매장중복배정확인_Get";
            }

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                   new string[] { "@분류번호", "@장비명", "@원배치번호" },
                   new object[] { 분류번호, 장비명, 원배치번호 }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        internal static void 바코드중복확인취소(string 분류번호, string 장비명, string 원배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_제약사항_바코드중복확인취소_Set", "@분류번호", "@장비명", "@원배치번호");
                    oScope.Update(분류번호, 장비명, 원배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 재구성배치슈트중복확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_제약사항_재구성배치슈트중복확인_Get")
            {
                dataTable.TableName = "usp_관리_제약사항_재구성배치슈트중복확인_Get";
            }

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@분류번호", "@장비명", "@원배치번호" },
                new object[] { 분류번호, 장비명, 원배치번호 }
                 );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 분류실적백업_Get(DataTable dataTable, string 조회앞, string 조회뒤, string 장비명, string 배치상태, int 조회구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_분류실적_백업_Get")
            {
                dataTable.TableName = "usp_관리_분류실적_백업_Get";
            }

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                    new string[] { "@조회앞", "@조회뒤", "@장비명", "@배치상태", "@조회구분자" },
                    new object[] { 조회앞, 조회뒤, 장비명, 배치상태, 조회구분자 }
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 분류실적백업_Set(string 조회앞, string 조회뒤, string 장비명, string 배치상태, string 관리상태)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_분류실적_백업_Set", "@조회앞", "@조회뒤", "@장비명", "@배치상태", "@관리상태");
                    oScope.Update(조회앞, 조회뒤, 장비명, 배치상태, 관리상태);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 배송사변경_Get(DataTable dataTable, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_관리_배송사변경_Get")
            {
                dataTable.TableName = "usp_관리_배송사변경_Get";
            }

            try
            {
                TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@배치번호", "@조회구분자" },
                new object[] { 배치번호, 구분자 }
            );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        internal static void 배송사변경_Set(string 배치번호, string XML)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_배송사변경_Set", "@배치번호", "@XML");
                    oScope.Update(배치번호, XML);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 배치명변경(string 배치번호, string 배치명)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_배치명변경_Set", "@배치번호", "@배치명");
                    oScope.Update(배치번호, 배치명);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 출하위치변경(string 분류번호, string 출하구분)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_관리_출하위치변경_Set", "@분류번호", "@출하구분");
                    oScope.Update(분류번호, 출하구분);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
