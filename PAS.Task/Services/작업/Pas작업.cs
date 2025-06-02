using DbProvider;
using PAS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

        internal static DataTable 숫자표시기값(string s장비명)
        {
            DataTable dt = new DataTable("usp_분류_숫자표시기값_Get");
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

                TcpClient oClient = new TcpClient(); //임시
                //Commit전에 출력
                bool 출력여부 = 출력(s슈트번호, dt, oClient);
                if (출력여부)
                    oScope.Commit();
                else
                    oScope.Rollback();
            }
        }


        private static bool 출력(string s슈트번호, DataTable oDataTable, TcpClient oClient)
        {
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
                int num = ParseUtils.ObjectToint(oDataTable.Rows[0]["SKU수"]);
                int count = oDataTable.Rows.Count;
                switch (s배치구분)
                {
                    case "패키지":
                        if (!string.IsNullOrEmpty(str5) && str5 != "0" && str6 == "1")
                            return true;// GetPrintScript2(Common.GetBarcodePrinterName("패키지"), oClient, oDataTable);
                        return true;
                        //goto label_32;
                    case "반품":
                        s패턴구분 = num <= 2 ? "반품유형1" : "반품유형2";
                        break;
                }
                if (!string.IsNullOrEmpty(str5) && str5 != "0" && str6 == "1")
                {
                    string printScript = "";// Common.GetPrintScript(s패턴구분, s배치구분, count);
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
                    string barcodePrinterName = "";// Common.GetBarcodePrinterName(s슈트번호);
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
            return true;
        }


        public static bool GetPrintScript2(string s프린터명, TcpClient oClient, DataTable oDataTable)
        {
            if (oDataTable == null || oDataTable.Rows.Count <= 0)
                return false;
            string empty1 = string.Empty;
            int num1 = oDataTable.Rows.Count / 15;
            int val1 = oDataTable.Rows.Count % 15;
            if (val1 > 0)
                ++num1;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            int num2 = ParseUtils.ObjectToint(oDataTable.Compute("SUM(수량)", string.Empty));
            string empty5 = string.Empty;
            string str1 = oDataTable.Rows[0]["박스바코드"].ToString();
            string str2 = oDataTable.Rows[0]["박스바코드구분"].ToString();
            string str3 = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss");
            string str4 = "~DGSLKN.GRF,330,10," + "00000000000000000000" + "00000000000000000000" + "0007FFFF000000000000" + "007FFFFF000000000000" + "01FFFFFF800000000000" + "03FFFFFF800000000000" + "07FFFFFF800000000000" + "07FFFFFF800000000000" + "0FFFF80F800000000000" + "0FFFE000800000000000" + "0FFFE000000000000000" + "0FFFF000000000000000" + "07FFF800000000000000" + "03FFFE00000000000000" + "01FFFF80000000000000" + "00FFFFC0000000000000" + "003FFFF003F8007F03F8" + "000FFFFC03F800FF07F8" + "0007FFFE03F800FF0FF0" + "0001FFFF03F800FE1FC0" + "00007FFF83F800FE3F80" + "00003FFF83F800FE7F00" + "00001FFF83F800FFFE00" + "3C003FFF83F800FEFE00" + "1FE07FFF83F800FEFF00" + "1FFFFFFF83F800FE7F80" + "1FFFFFFF03F800FE3FC0" + "1FFFFFFE07FFFCFE1FE0" + "1FFFFFFC07FFFCFE0FF0" + "1FFFFFF007FFFCFE07F8" + "00FFFF0007FFF8FC03F8" + "00000000000000000000" + "00000000000000000000";
            string str5 = "~DGSLKR.GRF,400,5," + "0000000000" + "0000000000" + "00C0000000" + "1FC0000000" + "1FC0078000" + "1FC00FE000" + "1F801FF000" + "1F803FF800" + "3F807FF800" + "3F807FFC00" + "3F80FFFC00" + "3F00FFFC00" + "3F01FFFE00" + "3F03FFFE00" + "3F03FFFE00" + "3F07FFFE00" + "3F87FFFE00" + "3F8FFFFE00" + "3FDFFFFE00" + "3FFFF8FE00" + "3FFFF8FE00" + "3FFFF07E00" + "3FFFF07E00" + "3FFFE07E00" + "1FFFC07E00" + "1FFFC07E00" + "1FFF807E00" + "1FFF807E00" + "0FFF00FE00" + "07FF00FE00" + "07FE00FE00" + "03FC00FE00" + "01F801F800" + "0000000000" + "0000000000" + "0000000000" + "0000000000" + "3C00000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "1C00000000" + "0000000000" + "0000000000" + "3FFF000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "1FFF800000" + "0023800000" + "00E0000000" + "01F0000000" + "03F8000000" + "07FC000000" + "0FFE000000" + "1FFF000000" + "3FFF800000" + "3F9F800000" + "3F0F800000" + "3E07800000" + "3C03800000" + "3803800000" + "3001800000" + "0000000000" + "0000000000" + "0000000000";
            for (int index = 0; index < num1; ++index)
            {
                int num3 = 0;
                string str6 = "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^POI" + "^LH20,20" + "^FO690,20^A1R,70,70^FD" + str2 + "^FS" + "^FO690,500^BY3,2.0^BCR,70,N,N^FD" + str1 + "^FS" + "^FO680,10^GB0,850,2^FS" + "^FO640,20^A1R,25,25^FD스타일^FS" + "^FO640,370^A1R,25,25^FD색상^FS" + "^FO640,650^A1R,25,25^FD사이즈^FS" + "^FO640,0^A1R,25,25^FB850,1,0,R,0^FD수량^FS" + "^FO630,10^GB0,850,2^FS";
                DataTableVerify(oDataTable, index * 15, ref empty2, ref empty3, ref empty4, ref empty5);
                int num4 = num3 + ParseUtils.ObjectToint((object)empty5);
                string str7 = str6 + "^FO590,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO590,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO590,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO590,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 1, ref empty2, ref empty3, ref empty4, ref empty5);
                int num5 = num4 + ParseUtils.ObjectToint((object)empty5);
                string str8 = str7 + "^FO555,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO555,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO555,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO555,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 2, ref empty2, ref empty3, ref empty4, ref empty5);
                int num6 = num5 + ParseUtils.ObjectToint((object)empty5);
                string str9 = str8 + "^FO520,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO520,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO520,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO520,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 3, ref empty2, ref empty3, ref empty4, ref empty5);
                int num7 = num6 + ParseUtils.ObjectToint((object)empty5);
                string str10 = str9 + "^FO485,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO485,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO485,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO485,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 4, ref empty2, ref empty3, ref empty4, ref empty5);
                int num8 = num7 + ParseUtils.ObjectToint((object)empty5);
                string str11 = str10 + "^FO450,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO450,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO450,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO450,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 5, ref empty2, ref empty3, ref empty4, ref empty5);
                int num9 = num8 + ParseUtils.ObjectToint((object)empty5);
                string str12 = str11 + "^FO415,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO415,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO415,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO415,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 6, ref empty2, ref empty3, ref empty4, ref empty5);
                int num10 = num9 + ParseUtils.ObjectToint((object)empty5);
                string str13 = str12 + "^FO380,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO380,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO380,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO380,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 7, ref empty2, ref empty3, ref empty4, ref empty5);
                int num11 = num10 + ParseUtils.ObjectToint((object)empty5);
                string str14 = str13 + "^FO345,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO345,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO345,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO345,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 8, ref empty2, ref empty3, ref empty4, ref empty5);
                int num12 = num11 + ParseUtils.ObjectToint((object)empty5);
                string str15 = str14 + "^FO310,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO310,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO310,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO310,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 9, ref empty2, ref empty3, ref empty4, ref empty5);
                int num13 = num12 + ParseUtils.ObjectToint((object)empty5);
                string str16 = str15 + "^FO275,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO275,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO275,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO275,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 10, ref empty2, ref empty3, ref empty4, ref empty5);
                int num14 = num13 + ParseUtils.ObjectToint((object)empty5);
                string str17 = str16 + "^FO240,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO240,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO240,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO240,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 11, ref empty2, ref empty3, ref empty4, ref empty5);
                int num15 = num14 + ParseUtils.ObjectToint((object)empty5);
                string str18 = str17 + "^FO205,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO205,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO205,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO205,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 12, ref empty2, ref empty3, ref empty4, ref empty5);
                int num16 = num15 + ParseUtils.ObjectToint((object)empty5);
                string str19 = str18 + "^FO170,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO170,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO170,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO170,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 13, ref empty2, ref empty3, ref empty4, ref empty5);
                int num17 = num16 + ParseUtils.ObjectToint((object)empty5);
                string str20 = str19 + "^FO135,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO135,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO135,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO135,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS";
                DataTableVerify(oDataTable, index * 15 + 14, ref empty2, ref empty3, ref empty4, ref empty5);
                int num18 = num17 + ParseUtils.ObjectToint((object)empty5);
                string str21 = str20 + "^FO100,10^A1R,30,25^FD" + empty2 + "^FS" + "^FO100,370^A1R,30,25^FD" + empty3 + "^FS" + "^FO100,650^A1R,30,25^FD" + empty4 + "^FS" + "^FO100,780^A1R,30,25^FB70,1,0,R,0^FD" + empty5 + "^FS" + "^FO95,10^GB0,850,2^FS" + "^FO60,10^A1R30,25^FD소계. SKU : " + (index + 1 != num1 ? 15 : Math.Min(val1, 15)).ToString() + ", 수량 : " + num18.ToString() + "^FS" + "^FO60,0^A1R30,25^FB850,1,0,R,0^FD누계. SKU : " + oDataTable.Rows.Count.ToString() + ", 수량 : " + (object)num2 + "^FS" + "^FO45,10^GB0,850,2^FS" + "^FO10,20^A1R,25,25^FD" + oDataTable.Rows[0]["센터명"].ToString() + "^FS" + "^FO10,0^A1R,25,20^FB800,1,0,R,0^FD" + str3 + "^FS" + "^FO10,230^A1R,25,25^FDPAS^FS" + "^FO10,350^A1R,25,25^FD( " + (index + 1).ToString() + " / " + num1.ToString() + " )^FS" + "^FO50,990^A1N,50,40^FD" + str2 + "^FS" + "^FO300,920^BY2,2.0^BCN,90,N,N^FD" + str1 + "^FS" + "^FO300,1015^A1N,25,17^FD" + str3 + "^FS" + "^FO580,960^A1N,25,20^FD수량^FS" + "^FO580,990^A1N,50,45^FD" + num2.ToString() + "^FS" + "^FO680,960^A1N,25,20^FDSKU^FS" + "^FO680,990^A1N,50,45^FD" + oDataTable.Rows.Count.ToString() + "^FS" + "^FO50,1110^A1N,50,40^FD" + str2 + "^FS" + "^FO300,1080^A1N,25,20^FD수량^FS" + "^FO300,1110^A1N,50,45^FD" + num2.ToString() + "^FS" + "^FO400,1080^A1N,25,20^FDSKU^FS" + "^FO400,1110^A1N,50,45^FD" + oDataTable.Rows.Count.ToString() + "^FS" + "^FO500,1040^BY2,2.0^BCN,90,N,N^FD" + str1 + "^FS" + "^FO500,1135^A1N,25,17^FD" + str3 + "^FS" + "^XZ";
                if (string.IsNullOrEmpty(str21))
                    return false;
                if (oClient != null)
                {
                    oClient.Close();
                    oClient = (TcpClient)null;
                }
                oClient = new TcpClient();
                WaitHandle asyncWaitHandle = oClient.BeginConnect(s프린터명, 9100, (AsyncCallback)null, (object)null).AsyncWaitHandle;
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
                            streamWriter.Write(str21);
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
            return true;
        }

        private static void DataTableVerify(DataTable oDataTable, int idx, ref string s스타일, ref string s색상, ref string s사이즈, ref string s내품수)
        {
            try
            {
                DataRow[] dataRowArray = oDataTable.Select("IDX=" + (object)(idx + 1));
                if (dataRowArray == null || dataRowArray.Length <= 0)
                {
                    s스타일 = string.Empty;
                    s색상 = string.Empty;
                    s사이즈 = string.Empty;
                }
                else
                {
                    s스타일 = ParseUtils.Substring(dataRowArray[0]["스타일"].ToString(), 18);
                    s색상 = ParseUtils.Substring(dataRowArray[0]["색상"].ToString(), 16);
                    s사이즈 = ParseUtils.Substring(dataRowArray[0]["사이즈"].ToString(), 7);
                    int num = ParseUtils.ObjectToint(dataRowArray[0]["수량"]);
                    if (num == 0)
                        s내품수 = string.Empty;
                    else
                        s내품수 = num.ToString();
                }
            }
            catch
            {
                s스타일 = string.Empty;
                s색상 = string.Empty;
                s사이즈 = string.Empty;
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
