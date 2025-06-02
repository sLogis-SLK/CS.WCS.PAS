using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PAS.Task
{
    internal class PasProcess
    {
        private static bool IsPrint(
          string s슈트번호,
          DataTable oDataTable,
          TcpClient oClient)
        {
            /*
            if (oDataTable != null && oDataTable.Rows.Count > 0)
            {
                string str1 = oDataTable.Rows[0]["박스바코드"].ToString();
                string str2 = oDataTable.Rows[0]["박스바코드구분"].ToString();
                oDataTable.Rows[0]["점코드"].ToString();
                string str3 = oDataTable.Rows[0]["점명"].ToString();
                string str4 = oDataTable.Rows[0]["박스번호"].ToString();
                string str5 = oDataTable.Rows[0]["내품수"].ToString();
                string s배치구분 = oDataTable.Rows[0]["배치구분"].ToString();
                string s패턴구분 = oDataTable.Rows[0]["패턴구분"].ToString();
                string str6 = oDataTable.Rows[0]["출력여부"].ToString();
                string str7 = oDataTable.Rows[0]["브랜드코드"].ToString();
                string str8 = oDataTable.Rows[0]["브랜드명"].ToString();
                string str9 = oDataTable.Rows[0]["배치번호"].ToString();
                string str10 = oDataTable.Rows[0]["배치명"].ToString();
                oDataTable.Rows[0]["대표바코드"].ToString();
                oDataTable.Rows[0]["수량"].ToString();
                string str11 = DateTime.Now.ToString("yyyy-MM-dd");
                string empty1 = string.Empty;
                string empty2 = string.Empty;
                string empty3 = string.Empty;
                string empty4 = string.Empty;
                int num = Common.C2I(oDataTable.Rows[0]["SKU수"]);
                int count = oDataTable.Rows.Count;
                switch (s배치구분)
                {
                    case "패키지":
                        if (!string.IsNullOrEmpty(str5) && str5 != "0" && str6 == "1")
                            return Common.GetPrintScript2(Common.GetBarcodePrinterName("패키지"), oClient, oDataTable);
                        return true;
                    case "반품":
                        s패턴구분 = num <= 2 ? "반품유형1" : "반품유형2";
                        break;
                }
                if (!string.IsNullOrEmpty(str5) && str5 != "0" && str6 == "1")
                {
                    string printScript = Common.GetPrintScript(s패턴구분, s배치구분, count);
                    string str12;
                    switch (s패턴구분)
                    {
                        case "사용안함":
                            str12 = string.Empty;
                            break;
                        case "출고유형":
                            str12 = string.Format(printScript, (object)(str7 + ":" + str8), (object)str3, (object)s슈트번호, (object)str4, (object)str5, (object)str1, (object)str11);
                            break;
                        case "반품유형1":
                            string empty5;
                            string empty6;
                            string empty7;
                            string empty8;
                            switch (count)
                            {
                                case 1:
                                    empty5 = oDataTable.Rows[0]["대표바코드"].ToString();
                                    empty6 = string.Empty;
                                    empty7 = oDataTable.Rows[0]["수량"].ToString();
                                    empty8 = string.Empty;
                                    break;
                                case 2:
                                    empty5 = oDataTable.Rows[0]["대표바코드"].ToString();
                                    empty6 = oDataTable.Rows[1]["대표바코드"].ToString();
                                    empty7 = oDataTable.Rows[0]["수량"].ToString();
                                    empty8 = oDataTable.Rows[1]["수량"].ToString();
                                    break;
                                default:
                                    empty5 = string.Empty;
                                    empty6 = string.Empty;
                                    empty7 = string.Empty;
                                    empty8 = string.Empty;
                                    break;
                            }
                            str12 = string.Format(printScript, (object)(str7 + ":" + str10), (object)str9, (object)str1, (object)str2, (object)s슈트번호, (object)str4, (object)str5, (object)empty5, (object)empty7, (object)empty6, (object)empty8, (object)str11);
                            break;
                        case "반품유형2":
                            str12 = string.Format(printScript, (object)(str7 + ":" + str10), (object)str1, (object)str2, (object)str9, (object)s슈트번호, (object)str4, (object)str5, (object)num.ToString(), (object)str11);
                            break;
                        default:
                            str12 = string.Format(printScript, (object)str3, (object)s슈트번호, (object)str5, (object)str1);
                            break;
                    }
                    if (string.IsNullOrEmpty(str12))
                        return false;
                    string barcodePrinterName = Common.GetBarcodePrinterName(s슈트번호);
                    if (oClient != null)
                    {
                        oClient.Close();
                        oClient = (TcpClient)null;
                    }
                    oClient = new TcpClient();
                    WaitHandle asyncWaitHandle = oClient.BeginConnect(barcodePrinterName, 9100, (AsyncCallback)null, (object)null).AsyncWaitHandle;
                    try
                    {
                        if (!asyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3.0), false))
                        {
                            oClient.Close();
                            return false;
                        }
                        if (oClient.Connected)
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)oClient.GetStream(), Encoding.GetEncoding(949)))
                            {
                                streamWriter.Write(str12);
                                streamWriter.Flush();
                                streamWriter.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        asyncWaitHandle.Close();
                    }
                    Thread.Sleep(300);
                }
            }
        //label_32:
            */
            return true;
        }

        public static void Analyze()
        {
            /*
            DataTable oDataTable1 = new DataTable("usp_분류_작업정보_Get");
            DataTable oDataTable2 = new DataTable("usp_분류_박스풀작성_Set");
            TcpClient oClient = (TcpClient)null;
            NetworkDrive networkDrive = (NetworkDrive)null;
            try
            {
                if (!string.IsNullOrEmpty(Common.Setting.SEIGYO_ID) && !string.IsNullOrEmpty(Common.Setting.SEIGYO_PASSWORD) && !string.IsNullOrEmpty(Common.Setting.SEIGYO_FOLDER))
                {
                    networkDrive = new NetworkDrive(Common.Setting.SEIGYO_ID, Common.Setting.SEIGYO_PASSWORD, Common.Setting.SEIGYO_FOLDER);
                }
                else
                {
                    int num = (int)MessageBox.Show("환경설정에 누락된 값이 있습니다..\r\n프로그램을 종료합니다.", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                int num = (int)MessageBox.Show("PAS 제어 프로그램의 실적에 접근할 수 없습니다.\r\n프로그램을 종료합니다.", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }
            if (networkDrive == null)
            {
                int num = (int)MessageBox.Show("PAS 제어 프로그램의 실적에 접근할 수 없습니다.\r\n프로그램을 종료합니다.", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Process.GetCurrentProcess().Kill();
            }


            while (Common.IsPasThread)
            {
                if (!Common.IsPrinting && !Common.IsSetting && !Common.IsPasEvent && Common.IsPasContinue)
                {
                    Common.IsPasEvent = true;
                    Common.LightOn_Normal(TaskType.PAS);
                    Common.LightOff_Normal(TaskType.LOCAL);
                    Common.LightOff_Error(TaskType.LOCAL);

                    //DBProvider2.GetData(oDataTable1, new SqlConnection(Common.ConnectionString()), new string[1] { "@장비명" }, (object)Common.Setting.NAME);

                    string s장비명 = "";
                    DataTable dt = 작업.Pas작업.출하상태확인(s장비명);

                    if (oDataTable1 == null || oDataTable1.Rows.Count <= 0)
                    {
                        Common.IsPasEvent = false;
                        Common.IsPasContinue = false;
                        Thread.Sleep(100);
                    }
                    else
                    {
                        string sBatchNo = oDataTable1.Rows[0]["분류번호"].ToString();
                        string str1 = oDataTable1.Rows[0]["작업일자"].ToString();
                        string empty = string.Empty;
                        string str2;
                        try
                        {
                            str2 = str1.Substring(4, 4);
                        }
                        catch
                        {
                            str2 = DateTime.Now.ToString("MMdd");
                        }
                        int iLastIndex = Common.C2I(oDataTable1.Rows[0]["관리번호"]);
                        string sFileName = string.Format("{0}_{1}.DB", (object)str1, (object)sBatchNo);
                        string sDestPath = string.Format("{0}\\DATA\\DATE{1}\\{2}", (object)Common.Setting.LOCAL_FOLDER, (object)str2, (object)sBatchNo);
                        if (!networkDrive.Exist(sFileName))
                        {
                            Common.IsPasEvent = false;
                            Common.IsPasContinue = false;
                            Thread.Sleep(100);
                        }
                        else
                        {
                            try
                            {
                                DataTable dataTable = networkDrive.ReadLineParser(sDestPath, sFileName, sBatchNo, iLastIndex).Copy();
                                if (dataTable == null || dataTable.Rows.Count <= 0)
                                {
                                    Common.IsPasEvent = false;
                                    Common.IsPasContinue = false;
                                    Thread.Sleep(100);
                                }
                                else
                                {
                                    int num = iLastIndex + dataTable.Rows.Count;
                                    DataRow[] dataRowArray = dataTable.Select("MARK='C'", "IDX ASC");
                                    using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
                                    {
                                        dbProvider2.Initialize("usp_분류_작업결과작성_Set", "@분류번호", "@장비명", "@관리번호", "@udt_DBTABLE");
                                        dbProvider2.Update((object)sBatchNo, (object)Common.Setting.NAME, (object)num, (object)dataTable);
                                        dbProvider2.Commit();
                                    }
                                    if (dataRowArray != null)
                                    {
                                        if (dataRowArray.Length > 0)
                                        {
                                            Common.IsPrinting = true;
                                            foreach (DataRow dataRow in dataRowArray)
                                            {
                                                string s슈트번호 = dataRow["CHUTENO"].ToString();
                                                try
                                                {
                                                    using (DBProvider2 oProvider = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
                                                    {
                                                        oProvider.Initialize("usp_분류_박스풀작성_Set", "@분류번호", "@장비명", "@슈트번호", "@마지막박스여부");
                                                        oProvider.Fill(oDataTable2, (object)sBatchNo, (object)Common.Setting.NAME, (object)s슈트번호, (object)"0");
                                                        if (!PasProcess.IsPrint(s슈트번호, oDataTable2, oClient, oProvider))
                                                            oProvider.Rollback();
                                                        else
                                                            oProvider.Commit();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Common.Log(true, (object)"[PasProcess]", (object)string.Format("{0}번 슈트에서 박스풀 발행을 했으나 프린터에서 응답이 없습니다.\r\n{1}", (object)s슈트번호, (object)ex.Message));
                                                    Common.LightOn_Error(TaskType.PAS);
                                                    Thread.Sleep(300);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Common.Log(true, (object)"[PasProcess]", (object)ex.Message);
                                Common.LightOn_Error(TaskType.PAS);
                                Thread.Sleep(300);
                            }
                            finally
                            {
                                Common.IsPasEvent = false;
                                Common.IsPasContinue = false;
                                Common.IsPrinting = false;
                                Thread.Sleep(100);
                                if (oClient != null)
                                {
                                    oClient.Close();
                                    oClient = (TcpClient)null;
                                }
                                Common.LightOff_Normal(TaskType.PAS);
                                Common.LightOff_Error(TaskType.PAS);
                            }
                        }
                    }
                }
            }
            */
        }
    }
}
