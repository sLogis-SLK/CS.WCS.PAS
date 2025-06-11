using DbProvider;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    internal class 분류
    {
        internal static void 배치리스트조회(DataTable dataTable, string s조회시작일자, int 구분자, string 장비명 = "")
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_작업요약_배치그룹별_Get")
            {
                dataTable.TableName = "usp_분류_작업요약_배치그룹별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@장비명", "@배치상태", "@작업일자", "@조회구분자" },
                new object[] { 장비명 == "" ? GlobalClass.장비명 : 장비명
                               ,"모두"
                               ,s조회시작일자
                               ,구분자 }
            );
        }

        internal static void 미출고슈트별조회(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_슈트별_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_슈트별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                               ,장비명
                               ,배치번호
                               ,구분자 }
            );
        }

        internal static void 미출고상품별조회(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_상품별_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_상품별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                               ,배치번호
                               ,구분자 }
            );
        }


        internal static void 미출고내역상품별출력(DataTable dataTable, string 분류번호, string 배치번호, string 슈트번호, string 장비명)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_상품별_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_상품별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
              new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호" },
                new object[] { 분류번호
                                    ,장비명
                                    ,배치번호
                                    ,슈트번호
                                }
      );

        }

        internal static void 미출고슈트별상세조회(DataTable dataTable, string 분류번호, string 배치번호, string 슈트번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_슈트별상세_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_슈트별상세_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호", "@서브슈트번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호
                                , null
                                ,구분자 }
            );
        }

        internal static void 미출고내역슈트별출력(DataTable dataTable, string 분류번호, string 배치번호, string 슈트번호, string 장비명)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_슈트별출력용_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_슈트별출력용_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
              new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호" },
                new object[] { 분류번호
                                    ,장비명
                                    ,배치번호
                                    ,슈트번호
                                }
      );

        }


        internal static void 박스재발행조회(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
            );
        }

        internal static void 슈트별박스풀조회(DataTable dataTable, string 분류번호, string 배치번호, string 슈트번호, string 서브슈트번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_슈트별_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_슈트별_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호", "@서브슈트번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호
                                ,서브슈트번호
                                ,구분자 }
            );
        }

        internal static void 슈트별박스풀상세조회(DataTable dataTable, string 분류번호, string 배치번호, string 슈트번호, string 서브슈트번호, string 박스번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_슈트별상세_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_슈트별상세_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호", "@서브슈트번호", "@박스번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호
                                ,서브슈트번호
                                ,박스번호
                                ,구분자 }
            );
        }

        internal static void 박스별패킹내역(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, string 슈트번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스별패킹내역_Get")
            {
                dataTable.TableName = "usp_분류_박스별패킹내역_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
          new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호" },
              new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호 }
          );
        }

        internal static void 마지막박스내역조회(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_마지막박스내역_Get")
            {
                dataTable.TableName = "usp_분류_마지막박스내역_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
            );
        }

        internal static void 분류상품발송장조회(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_상품발송장_Get")
            {
                dataTable.TableName = "usp_분류_상품발송장_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
            );
        }

        internal static void 출하박스별패킹대상(DataTable dataTable, string 분류번호, string 배치번호, string 장비명, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_출하_박스별패킹대상_Get")
            {
                dataTable.TableName = "usp_출하_박스별패킹대상_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
                new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                  new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
                );

        }

        internal static void 임계치조회(DataTable dataTable, string 분류번호, string 장비명)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_레코드수_Get")
            {
                dataTable.TableName = "usp_분류_레코드수_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명" },
            new object[] { 분류번호, 장비명 }
            );
        }

        internal static void 분류상태변경(string 장비명, string 분류번호, string 분류상태)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_분류상태변경_Set", "@장비명", "@분류번호", "@분류상태");
                    oScope.Update(장비명, 분류번호, 분류상태);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 분류상태변경_원배치용(string 장비명, string 분류번호, string 배치번호, string 원배치번호, string 배치상태)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_배치상태변경_원배치용_Set", "@장비명", "@분류번호", "@배치번호", "@원배치번호", "배치상태");
                    oScope.Update(장비명, 분류번호, 배치번호, 원배치번호, 배치상태);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 배치종료대상(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_배치종료대상_Get")
            {
                dataTable.TableName = "usp_분류_배치종료대상_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@원배치번호" },
            new object[] { 분류번호, 장비명, 원배치번호 }
            );
        }

        internal static void 배치종료확인(DataTable dataTable, string 분류번호, string 장비명, string 원배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_배치종료확인_Get")
            {
                dataTable.TableName = "usp_분류_배치종료확인_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@원배치번호" },
            new object[] { 분류번호, 장비명, 원배치번호 }
            );
        }

        internal static void 작업요약생성(string 분류명, string 장비명, string 작업일자, string 배치번호, string 원배치상태,
            string 배치명, string 배치구분, string 분류구분, string 출하구분, string 패턴구분, int 지시수, string 슈트수, string 분류번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_작업요약생성_Set", "@분류명", "@장비명", "@작업일자", "@배치번호", "@원배치번호",
                        "@배치명", "@배치구분", "@분류구분", "@출하구분", "@패턴구분", "@지시수", "@슈트수", "@분류번호");
                    oScope.Update(분류명, 장비명, 작업일자, 배치번호, 원배치상태, 배치명, 배치구분, 분류구분, 출하구분, 패턴구분, 지시수, 슈트수, 분류번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 출하상품이동생성(DataRow[] dataRowArr,  string 배치번호, string 슈트번호, string 박스번호, string 대상박스번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_출하_상품이동_Set", "@배치번호", "@슈트번호", "@박스번호", "@대상박스번호", "@아이템코드", "@조정수");
                    foreach (DataRow dataRow in dataRowArr)
                        oScope.Update(배치번호, 슈트번호, 박스번호, 대상박스번호, dataRow["아이템코드"], dataRow["조정"]);
                    oScope.Commit();
                }
                MessageBox.Show("상품이동 처리를 완료하였습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void 작업로그생성(string text)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_기록_로그_Set", "@TEXT");
                    oScope.Update(text);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
