using CrystalDecisions.CrystalReports.Engine;
using DbProvider;
using PAS.Core;
using PAS.PMP.Utils;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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

        internal static void 거래명세서출력조회(DataTable dataTable)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_기준_거래명세서용_마스터_Get")
            {
                dataTable.TableName = "usp_기준_거래명세서용_마스터_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
             new string[] {  },
                 new object[] {  }
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
                    oScope.Initialize("usp_분류_배치상태변경_원배치용_Set", "@장비명", "@분류번호", "@배치번호", "@원배치번호", "@배치상태");
                    oScope.Update(장비명, 분류번호, 배치번호, 원배치번호, 배치상태);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static bool 거래명세서발행_토탈(string s배치번호, string s슈트번호, string s거명용바코드)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;
            DataTable dataTable = new DataTable("usp_출하_토탈패킹내역_Get");

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
             new string[] { "@배치번호", "@슈트번호", },
             new object[] { s배치번호, s슈트번호 });
            if (dataTable == null || dataTable.Rows.Count <= 0)
                return false;

            PAS환경설정 pasSetting = new PAS환경설정();
            string[] strArray = pasSetting.BARCODE_PRINTER_LIST.Split(new string[1]
            {
                    "|"
            }, StringSplitOptions.RemoveEmptyEntries);

            if (strArray == null || strArray.Length <= 0)
            {
                MessageBox.Show("설정된 프린터가 없습니다.");
                return false;
            }
            if (pasSetting.PrinterIndex >= strArray.Length)
                pasSetting.PrinterIndex = 0;

            try
            {
                DataRow row = dataTable.Rows[0];
                if (row == null)
                    return false;
                row["브랜드코드"].ToString();
                string val1 = row["설비명"].ToString();
                string val2 = row["작업일자"].ToString();
                string val3 = $"('{row["매장코드"].ToString()}')'{row["매장명"].ToString()}'";
                string val4 = $"사용자:{"출하라인"}, 컴퓨터:{string.Empty}";
                ReportClass reportClass = (ReportClass)new 레포트_박스별실적상세_토탈();
                reportClass.SetDataSource(dataTable);
                reportClass.SetParameterValue(0, (object)val4);
                reportClass.SetParameterValue(1, (object)val1);
                reportClass.SetParameterValue(2, (object)val3);
                reportClass.SetParameterValue(3, (object)val2);
                reportClass.SetParameterValue(4, (object)s배치번호);
                reportClass.SetParameterValue(5, (object)s슈트번호);
                reportClass.SetParameterValue(6, (object)s거명용바코드);
                if (reportClass == null)
                    return false;

                try
                {
                    reportClass.PrintOptions.PrinterName = strArray[pasSetting.PrinterIndex++];
                }
                catch
                {
                }
                reportClass.PrintToPrinter(1, true, 0, 0);
                reportClass.Close();
                reportClass.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                ++pasSetting.PrinterIndex;
            }
        }

        internal static bool 거래명세서발행_박스별(string s배치번호, string s슈트번호, string s거명용바코드)
        {
            string empty1 = string.Empty;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            string empty5 = string.Empty;
            string empty6 = string.Empty;

            DataTable dataTable = new DataTable("usp_출하_박스별패킹내역_Get");

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
               new string[] { "@배치번호", "@슈트번호", },
               new object[] { s배치번호, s슈트번호 });

            if (dataTable == null || dataTable.Rows.Count <= 0)
                return false;
            PAS환경설정 pasSetting = new PAS환경설정();
            string[] strArray = pasSetting.BARCODE_PRINTER_LIST.Split(new string[1]
            {
                    "|"
            }, StringSplitOptions.RemoveEmptyEntries);

            if (strArray == null || strArray.Length <= 0)
            {
                MessageBox.Show("설정된 프린터가 없습니다.");
                return false;
            }
            if (pasSetting.PrinterIndex >= strArray.Length)
                pasSetting.PrinterIndex = 0;

            try
            {
                DataRow row = dataTable.Rows[0];
                if (row == null)
                    return false;
                string str = row["브랜드코드"].ToString();
                string val1 = row["설비명"].ToString();
                string val2 = row["작업일자"].ToString();
                string val3 = $"('{row["매장코드"].ToString()}')'{row["매장명"].ToString()}'";
                string val4 = $"사용자:{"출하라인"}, 컴퓨터:{string.Empty}";
                ReportClass reportClass;
                switch (str)
                {
                    case "SM":
                    case "FS":
                        reportClass = (ReportClass)new 레포트_박스별실적상세_SM();
                        reportClass.SetDataSource(dataTable);
                        reportClass.SetParameterValue(0, (object)row["주문일자"].ToString());
                        reportClass.SetParameterValue(1, (object)row["예정일자"].ToString());
                        reportClass.SetParameterValue(2, (object)val2);
                        reportClass.SetParameterValue(3, (object)s슈트번호);
                        reportClass.SetParameterValue(4, (object)s거명용바코드);
                        break;
                    case "A1":
                    case "A2":
                    case "WW":
                        reportClass = (ReportClass)new 레포트_박스별실적상세_상품명();
                        reportClass.SetDataSource(dataTable);
                        reportClass.SetParameterValue(0, (object)val4);
                        reportClass.SetParameterValue(1, (object)val1);
                        reportClass.SetParameterValue(2, (object)val3);
                        reportClass.SetParameterValue(3, (object)val2);
                        reportClass.SetParameterValue(4, (object)s배치번호);
                        reportClass.SetParameterValue(5, (object)s슈트번호);
                        reportClass.SetParameterValue(6, (object)s거명용바코드);
                        break;
                    default:
                        reportClass = (ReportClass)new 레포트_박스별실적상세();
                        reportClass.SetDataSource(dataTable);
                        reportClass.SetParameterValue(0, (object)val4);
                        reportClass.SetParameterValue(1, (object)val1);
                        reportClass.SetParameterValue(2, (object)val3);
                        reportClass.SetParameterValue(3, (object)val2);
                        reportClass.SetParameterValue(4, (object)s배치번호);
                        reportClass.SetParameterValue(5, (object)s슈트번호);
                        reportClass.SetParameterValue(6, (object)s거명용바코드);
                        break;
                }
                if (reportClass == null)
                    return false;
                try
                {
                    reportClass.PrintOptions.PrinterName = strArray[pasSetting.PrinterIndex++];
                }
                catch
                {
                }
                reportClass.PrintToPrinter(1, true, 0, 0);
                reportClass.Close();
                reportClass.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                ++pasSetting.PrinterIndex;
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

        internal static void 작업요약생성(string 분류명, string 장비명, string 작업일자, string 배치번호, string 원배치번호,
            string 배치명, string 배치구분, string 분류구분, string 출하구분, string 패턴구분, int 지시수, string 슈트수, out string 분류번호)
        {
            분류번호 = null;

            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    DbParameterCollection oParams = null;
                    oScope.Initialize("usp_분류_작업요약생성_Set", "@분류명", "@장비명", "@작업일자", "@배치번호", "@원배치번호",
                        "@배치명", "@배치구분", "@분류구분", "@출하구분", "@패턴구분", "@지시수", "@슈트수", "@분류번호");
                    oScope.Update(out oParams, 분류명, 장비명, 작업일자, 배치번호, 원배치번호, 배치명, 배치구분, 분류구분, 출하구분, 패턴구분, 지시수, 슈트수, 분류번호);

                    if (oParams != null && oParams.Count > 0 && oParams.Contains("@분류번호"))
                    {
                        분류번호 = oParams["@분류번호"].Value?.ToString();
                    }

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

        internal static void 배치작성(DataTable dataTable, string 장비명, string 배치번호, string 원배치번호, string 구분)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_배치작성_Get")
            {
                dataTable.TableName = "usp_분류_배치작성_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@장비명", "@배치번호", "@원배치번호", "@구분" },
            new object[] { 장비명, 배치번호, 원배치번호, 구분 }
            );
        }

        internal static int 수신취소(DataRow[] rows)
        {
            int 취소건수 = 0;

            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_수신취소_Set", "@원배치번호");

                    foreach (var row in rows)
                    {
                        int 순번 = Convert.ToInt32(row["순번"]);
                        string s분류번호 = row["분류번호"].ToString();
                        string s원배치번호 = row["원배치번호"].ToString();
                        string s작업일자 = row["작업일자"].ToString();
                        string s월일;
                        try
                        {
                            s월일 = s작업일자.Substring(4, 4);
                        }
                        catch
                        {
                            s월일 = DateTime.Now.ToString("MMdd");
                        }


                        oScope.Update(s원배치번호);

                        if (순번 != 1)
                        {
                            if (File.Exists($"{GlobalClass.PATH_STARTUP}\\TEMP\\{s원배치번호}_REBUILD.DAT"))
                                File.Delete($"{GlobalClass.PATH_STARTUP}\\TEMP\\{s원배치번호}_REBUILD.DAT");
                            ++취소건수;
                        }
                        else
                        {
                            if (Directory.Exists($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{s원배치번호}\\{s분류번호}"))
                                Directory.Delete($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{s원배치번호}\\{s분류번호}", true);
                            if (Directory.Exists(GlobalClass.LOCAL_FOLDER + "\\DATA"))
                                MakeData.EXECBATDelete(GlobalClass.LOCAL_FOLDER, s작업일자, s분류번호);
                            ++취소건수;
                        }
                    }

                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage("수신취소 오류", ex.Message);
            }

            return 취소건수;
        }

        internal static void 실적작성대상(DataTable dataTable, string 배치번호, int 조회구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_실적작성대상_Get")
            {
                dataTable.TableName = "usp_분류_실적작성대상_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@배치번호", "@조회구분자" },
            new object[] { 배치번호, 조회구분자 }
            );
        }

        internal static void 배치상태변경(string 장비명, string 분류번호, string 배치번호, string 배치상태)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_배치상태변경_Set", "@장비명", "@분류번호", "@배치번호", "@배치상태");
                    oScope.Update(장비명, 분류번호, 배치번호, 배치상태);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 실적작성내용(DataTable dataTable, string 분류번호, string 장비명, string 배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_실적작성내용_Get")
            {
                dataTable.TableName = "usp_분류_실적작성내용_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호" },
            new object[] { 분류번호, 장비명, 배치번호 }
            );
        }

        internal static void 실적작성(string 분류번호, string 장비명, string 배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_실적작성_Set", "@분류번호", "@장비명", "@배치번호");
                    oScope.Update(분류번호, 장비명, 배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 출하배치반영(DataTable dataTable, string 분류번호, string 장비명, string 배치번호, int 조회구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_출하_배치반영_Get")
            {
                dataTable.TableName = "usp_출하_배치반영_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@분류번호", "@장비명", "@배치번호", "@조회구분자" },
            new object[] { 분류번호, 장비명, 배치번호, 조회구분자 }
            );
        }

        internal static void 실적작성대상_중간(DataTable dataTable, string 배치번호)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_실적작성대상_중간_Get")
            {
                dataTable.TableName = "usp_분류_실적작성대상_중간_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@배치번호" },
            new object[] { 배치번호 }
            );
        }

        internal static void 실적작성취소(string 배치번호)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_실적작성취소_Set", "@배치번호");
                    oScope.Update(배치번호);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal static void 슈트조정_슈트별현황_Get(DataTable dataTable, string 원배치번호, int 조회구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_슈트조정_슈트별현황_Get")
            {
                dataTable.TableName = "usp_분류_슈트조정_슈트별현황_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@원배치번호", "@조회구분자" },
            new object[] { 원배치번호, 조회구분자 }
            );
        }

        internal static void 슈트조정_가용슈트_조회(DataTable dataTable, string 장비명, int 조회구분자)
        {
            if (string.IsNullOrEmpty(dataTable.TableName) || dataTable.TableName.ToUpper() != "usp_분류_슈트조정_가용슈트_Get")
            {
                dataTable.TableName = "usp_분류_슈트조정_가용슈트_Get";
            }

            TlkTranscope.GetData(dataTable, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString),
            new string[] { "@장비명", "@조회구분자" },
            new object[] { 장비명, 조회구분자 }
            );
        }

        internal static void 슈트조정_슈트별현황_Set(string 장비명, string 원배치번호, string XML)
        {
            try
            {
                using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
                {
                    oScope.Initialize("usp_분류_슈트조정_슈트별현황_Set", "@장비명", "@원배치번호", "@XML");
                    oScope.Update(장비명, 원배치번호, XML);
                    oScope.Commit();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
