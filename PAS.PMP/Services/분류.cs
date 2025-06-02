using DbProvider;
using System.Data;
using TR_Common;

namespace PAS.PMP.PasWCS
{
    internal class 분류
    {
        internal static void 배치리스트조회( DataTable dataTable, string s조회시작일자, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_작업요약_Get")
            {
                dataTable.TableName = "usp_분류_작업요약_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
                new string[] { "@장비명", "@배치상태", "@작업일자", "@조회구분자" },
                new object[] { "모두"
                               ,"모두"
                               ,s조회시작일자
                               ,구분자 }
            );
        }

        internal static void 미출고슈트별조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_슈트별_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_슈트별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                               ,장비명
                               ,배치번호
                               ,구분자 }
            );
        }

        internal static void 미출고상품별조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_상품별_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_상품별_Get";
            }
            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                               ,장비명
                               ,배치번호
                               ,구분자 }
            );
        }

        internal static void 미출고슈트별상세조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, string 슈트번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_미출고내역_슈트별상세_Get")
            {
                dataTable.TableName = "usp_분류_미출고내역_슈트별상세_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호", "@서브슈트번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호
                                , null
                                ,구분자 }
            );
        }


        internal static void 박스재발행조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
            );
        }

        internal static void 슈트별박스풀조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, string 슈트번호, string 서브슈트번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_슈트별_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_슈트별_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@슈트번호", "@서브슈트번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,슈트번호
                                ,서브슈트번호
                                ,구분자 }
            );
        }

        internal static void 슈트별박스풀상세조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, string 슈트번호, string 서브슈트번호, string 박스번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_박스바코드재발행_슈트별상세_Get")
            {
                dataTable.TableName = "usp_분류_박스바코드재발행_슈트별상세_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
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

        internal static void 마지막박스내역조회(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, int 구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_마지막박스내역_Get")
            {
                dataTable.TableName = "usp_분류_마지막박스내역_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, PasWCS.Globel.GetDataBaseConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
                new object[] { 분류번호
                                ,장비명
                                ,배치번호
                                ,구분자 }
            );
        }
    }
}
