﻿using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TR_Common;

namespace PAS.Core
{
    public class Libs
    {
        public static string GetPrinterName(string s슈트번호)
        {
            string empty = string.Empty;
            string printerName = new PrinterSettings().PrinterName;
            try
            {
                PAS환경설정 pasSetting = new PAS환경설정();
                string[] strArray1 = pasSetting.BARCODE_PRINTER_LIST.Split(new string[1]
                {
                    "|"
                }, StringSplitOptions.RemoveEmptyEntries);
                if (s슈트번호 == "패키지")
                {
                    foreach (string str in strArray1)
                    {
                        string[] separator = new string[1] { "," };
                        string[] strArray2 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (strArray2[1] == "패키지" && strArray2[2] == "패키지")
                        {
                            printerName = strArray2[0];
                            break;
                        }
                    }
                }
                else
                {
                    int num1 = ConvertUtil.ObjectToint((object)s슈트번호);
                    foreach (string str in strArray1)
                    {
                        string[] separator = new string[1] { "," };
                        string[] strArray3 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (strArray3 != null && strArray3.Length > 0)
                        {
                            int num2 = ConvertUtil.ObjectToint((object)strArray3[1]);
                            int num3 = ConvertUtil.ObjectToint((object)strArray3[2]);
                            if (num2 != 0)
                            {
                                if (num3 != 0)
                                {
                                    if (num1 >= num2 && num1 <= num3)
                                    {
                                        printerName = strArray3[0];
                                        break;
                                    }
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
            return printerName;
        }

        public static string Substring(string s, int i)
        {
            try
            {
                return s.Substring(0, i);
            }
            catch
            {
                return s;
            }
        }

        private static void DataTableVerify(
                   DataTable oDataTable,
                   int idx,
                   ref string s스타일,
                   ref string s색상,
                   ref string s사이즈,
                   ref string s내품수)
        {
            try
            {
                DataRow[] dataRowArray = oDataTable.Select("IDX=" + (object)(idx + 1));
                if (dataRowArray == null || dataRowArray.Length <= 0)
                {
                    s스타일 = string.Empty;
                    s색상 = string.Empty;
                    s사이즈 = string.Empty;
                    s내품수 = string.Empty;
                }
                else
                {
                    s스타일 = Substring(dataRowArray[0]["스타일"].ToString(), 18);
                    s색상 = Substring(dataRowArray[0]["색상"].ToString(), 16 /*0x10*/);
                    s사이즈 = Substring(dataRowArray[0]["사이즈"].ToString(), 7);
                    int num = ConvertUtil.ObjectToint(dataRowArray[0]["수량"]);
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
                s내품수 = string.Empty;
            }
        }

        public static string GetPrintScript(string s패턴구분, string s배치구분, int i박스풀대상수)
        {
            string empty = string.Empty;
            string str1 = "~DGSLKN.GRF,330,10," + "00000000000000000000" + "00000000000000000000" + "0007FFFF000000000000" + "007FFFFF000000000000" + "01FFFFFF800000000000" + "03FFFFFF800000000000" + "07FFFFFF800000000000" + "07FFFFFF800000000000" + "0FFFF80F800000000000" + "0FFFE000800000000000" + "0FFFE000000000000000" + "0FFFF000000000000000" + "07FFF800000000000000" + "03FFFE00000000000000" + "01FFFF80000000000000" + "00FFFFC0000000000000" + "003FFFF003F8007F03F8" + "000FFFFC03F800FF07F8" + "0007FFFE03F800FF0FF0" + "0001FFFF03F800FE1FC0" + "00007FFF83F800FE3F80" + "00003FFF83F800FE7F00" + "00001FFF83F800FFFE00" + "3C003FFF83F800FEFE00" + "1FE07FFF83F800FEFF00" + "1FFFFFFF83F800FE7F80" + "1FFFFFFF03F800FE3FC0" + "1FFFFFFE07FFFCFE1FE0" + "1FFFFFFC07FFFCFE0FF0" + "1FFFFFF007FFFCFE07F8" + "00FFFF0007FFF8FC03F8" + "00000000000000000000" + "00000000000000000000";
            string str2 = "~DGSLKR.GRF,400,5," + "0000000000" + "0000000000" + "00C0000000" + "1FC0000000" + "1FC0078000" + "1FC00FE000" + "1F801FF000" + "1F803FF800" + "3F807FF800" + "3F807FFC00" + "3F80FFFC00" + "3F00FFFC00" + "3F01FFFE00" + "3F03FFFE00" + "3F03FFFE00" + "3F07FFFE00" + "3F87FFFE00" + "3F8FFFFE00" + "3FDFFFFE00" + "3FFFF8FE00" + "3FFFF8FE00" + "3FFFF07E00" + "3FFFF07E00" + "3FFFE07E00" + "1FFFC07E00" + "1FFFC07E00" + "1FFF807E00" + "1FFF807E00" + "0FFF00FE00" + "07FF00FE00" + "07FE00FE00" + "03FC00FE00" + "01F801F800" + "0000000000" + "0000000000" + "0000000000" + "0000000000" + "3C00000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "1C00000000" + "0000000000" + "0000000000" + "3FFF000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "1FFF800000" + "0023800000" + "00E0000000" + "01F0000000" + "03F8000000" + "07FC000000" + "0FFE000000" + "1FFF000000" + "3FFF800000" + "3F9F800000" + "3F0F800000" + "3E07800000" + "3C03800000" + "3803800000" + "3001800000" + "0000000000" + "0000000000" + "0000000000";
            string printScript;
            switch (s패턴구분)
            {
                case "사용안함":
                    printScript = string.Empty;
                    break;
                case "출고유형":
                    printScript = str1 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH20,20" + "^FO10,20^A1N,40,40^FD{0}^FS" + "^FO10,70^A1N,40,40^FD{1}^FS" + "^FO10,120^GB490,0,1^FS" + "^FO10,145^A1N,35,35^FD슈트번호^FS" + "^FO200,145^A1N,35,35^FD박스번호^FS" + "^FO400,145^A1N,35,35^FD수량^FS" + "^FO10,195^A1N,35,35^FD{2}^FS" + "^FO200,195^A1N,35,35^FD{3}^FS" + "^FO400,195^A1N,35,35^FD{4}^FS" + "^FO10,250^BY2,2.0" + "^B3N,N,150,Y,N,N^FD*{5}*^FS" + "^FO10,450^A1N,25,25^FD{6}^FS" + "^FO400,450^XGSLKN,1,1,^FS" + "^PQ1^XZ";
                    break;
                case "반품유형1":
                    string str3 = str2 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH10,10" + "^FO480,20^A1R,30,25^FD{0}^FS" + "^FO480,320^A1R,30,25^FD[{1}]^FS" + "^FO410,20^BY3" + "^BCR,50,N,N,N^FD{2}^FS" + "^FO320,60^A1R,80,60^FD*{3}*^FS" + "^FO290,10^A1R,20,20^FD슈트번호^FS" + "^FO210,10^A1R,70,50^FD{4}^FS" + "^FO290,210^A1R,20,20^FD박스번호^FS" + "^FO210,210^A1R,70,50^FD{5}^FS" + "^FO290,350^A1R,20,20^FD수량^FS" + "^FO210,350^A1R,70,50^FD{6}^FS";
                    if (i박스풀대상수 >= 1)
                        str3 = str3 + "^FO160,10^BY2.2.0" + "^BCR,40,N,N,N^FD{7}^FS" + "^FO130,10^A1R,25,20^FD{7}^FS" + "^FO130,250^A1R,25,20^FD{8}^FS";
                    if (i박스풀대상수 >= 2)
                        str3 = str3 + "^FO80,10^BY2.2.0" + "^BCR,40,N,N,N^FD{9}^FS" + "^FO50,10^A1R,25,20^FD{9}^FS" + "^FO50,250^A1R,25,20^FD{10}^FS";
                    printScript = str3 + "^FO0,20^A1R,25,20^FD{11}^FS" + "^FO0,450^XGSLKR,1,1,^FS" + "^PQ1^XZ";
                    break;
                case "반품유형2":
                    printScript = str2 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH10,10" + "^FO480,20^A1R,30,25^FD{0}^FS" + "^FO410,20^BY3" + "^BCR,50,N,N,N^FD{1}^FS" + "^FO320,60^A1R,80,60^FD*{2}*^FS" + "^FO290,10^A1R,20,20^FD배치번호^FS" + "^FO250,10^A1R,40,30^FD{3}^FS" + "^FO210,10^A1R,20,20^FD슈트번호^FS" + "^FO140,10^A1R,70,50^FD{4}^FS" + "^FO210,270^A1R,20,20^FD박스번호^FS" + "^FO140,270^A1R,70,50^FD{5}^FS" + "^FO120,270^A1R,20,20^FD수량^FS" + "^FO40,270^A1R,70,50^FD{6}^FS" + "^FO120,10^A1R,20,20^FDSKU^FS" + "^FO40,10^A1R,70,50^FD{7}^FS" + "^FO0,20^A1R,25,20^FD{8}^FS" + "^FO0,450^XGSLKR,1,1,^FS" + "^PQ1^XZ";
                    break;
                default:
                    string str4 = "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26";
                    string str5 = (!(s배치구분 == "반품") ? str4 + "^FO30,15^A1N,40,40^FD점명:{0}^FS" : str4 + "^FO30,15^A1N,40,40^FDSKU:{0}^FS") + "^FO30,65^A1N,40,40^FD슈트:{1}^FS" + "^FO300,65^A1N,40,40^FD수량:{2}^FS" + "^FO60,118^BY2,2.0";
                    printScript = (!(s배치구분 == "반품") ? str5 + "^B3N,N,120,Y,N,N^FD*{3}*^FS" : str5 + "^B3N,N,120,Y,N,N^FD{3}^FS") + "^PQ1^XZ";
                    break;
            }
            return printScript;
        }

        public static void GetPrintScript2(
              string s프린터명,
              string s박스바코드,
              string s박스바코드구분,
              TcpClient oClient,
                DataTable oDataTable)
        {
            if (oDataTable == null || oDataTable.Rows.Count <= 0)
                return;
            string empty1 = string.Empty;
            int num1 = oDataTable.Rows.Count / 15;
            int val1 = oDataTable.Rows.Count % 15;
            if (val1 > 0)
                ++num1;
            string empty2 = string.Empty;
            string empty3 = string.Empty;
            string empty4 = string.Empty;
            int num2 = ConvertUtil.ObjectToint(oDataTable.Compute("SUM(수량)", string.Empty));
            string empty5 = string.Empty;
            string str1 = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss");
            string str2 = "~DGSLKN.GRF,330,10," + "00000000000000000000" + "00000000000000000000" + "0007FFFF000000000000" + "007FFFFF000000000000" + "01FFFFFF800000000000" + "03FFFFFF800000000000" + "07FFFFFF800000000000" + "07FFFFFF800000000000" + "0FFFF80F800000000000" + "0FFFE000800000000000" + "0FFFE000000000000000" + "0FFFF000000000000000" + "07FFF800000000000000" + "03FFFE00000000000000" + "01FFFF80000000000000" + "00FFFFC0000000000000" + "003FFFF003F8007F03F8" + "000FFFFC03F800FF07F8" + "0007FFFE03F800FF0FF0" + "0001FFFF03F800FE1FC0" + "00007FFF83F800FE3F80" + "00003FFF83F800FE7F00" + "00001FFF83F800FFFE00" + "3C003FFF83F800FEFE00" + "1FE07FFF83F800FEFF00" + "1FFFFFFF83F800FE7F80" + "1FFFFFFF03F800FE3FC0" + "1FFFFFFE07FFFCFE1FE0" + "1FFFFFFC07FFFCFE0FF0" + "1FFFFFF007FFFCFE07F8" + "00FFFF0007FFF8FC03F8" + "00000000000000000000" + "00000000000000000000";
            string str3 = "~DGSLKR.GRF,400,5," + "0000000000" + "0000000000" + "00C0000000" + "1FC0000000" + "1FC0078000" + "1FC00FE000" + "1F801FF000" + "1F803FF800" + "3F807FF800" + "3F807FFC00" + "3F80FFFC00" + "3F00FFFC00" + "3F01FFFE00" + "3F03FFFE00" + "3F03FFFE00" + "3F07FFFE00" + "3F87FFFE00" + "3F8FFFFE00" + "3FDFFFFE00" + "3FFFF8FE00" + "3FFFF8FE00" + "3FFFF07E00" + "3FFFF07E00" + "3FFFE07E00" + "1FFFC07E00" + "1FFFC07E00" + "1FFF807E00" + "1FFF807E00" + "0FFF00FE00" + "07FF00FE00" + "07FE00FE00" + "03FC00FE00" + "01F801F800" + "0000000000" + "0000000000" + "0000000000" + "0000000000" + "3C00000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "1C00000000" + "0000000000" + "0000000000" + "3FFF000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "1FFF800000" + "0023800000" + "00E0000000" + "01F0000000" + "03F8000000" + "07FC000000" + "0FFE000000" + "1FFF000000" + "3FFF800000" + "3F9F800000" + "3F0F800000" + "3E07800000" + "3C03800000" + "3803800000" + "3001800000" + "0000000000" + "0000000000" + "0000000000";
            for (int index = 0; index < num1; ++index)
            {
                int num3 = 0;
                string str4 = $"{$"{"^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^POI" + "^LH20,20"}^FO690,20^A1R,70,70^FD{s박스바코드구분}^FS"}^FO690,500^BY3,2.0^BCR,70,N,N^FD{s박스바코드}^FS" + "^FO680,10^GB0,850,2^FS" + "^FO640,20^A1R,25,25^FD스타일^FS" + "^FO640,370^A1R,25,25^FD색상^FS" + "^FO640,650^A1R,25,25^FD사이즈^FS" + "^FO640,0^A1R,25,25^FB850,1,0,R,0^FD수량^FS" + "^FO630,10^GB0,850,2^FS";
                DataTableVerify(oDataTable, index * 15, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str5 = $"{$"{$"{$"{str4}^FO590,10^A1R,30,25^FD{empty2}^FS"}^FO590,370^A1R,30,25^FD{empty3}^FS"}^FO590,650^A1R,30,25^FD{empty4}^FS"}^FO590,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 1, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str6 = $"{$"{$"{$"{str5}^FO555,10^A1R,30,25^FD{empty2}^FS"}^FO555,370^A1R,30,25^FD{empty3}^FS"}^FO555,650^A1R,30,25^FD{empty4}^FS"}^FO555,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 2, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str7 = $"{$"{$"{$"{str6}^FO520,10^A1R,30,25^FD{empty2}^FS"}^FO520,370^A1R,30,25^FD{empty3}^FS"}^FO520,650^A1R,30,25^FD{empty4}^FS"}^FO520,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 3, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str8 = $"{$"{$"{$"{str7}^FO485,10^A1R,30,25^FD{empty2}^FS"}^FO485,370^A1R,30,25^FD{empty3}^FS"}^FO485,650^A1R,30,25^FD{empty4}^FS"}^FO485,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 4, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str9 = $"{$"{$"{$"{str8}^FO450,10^A1R,30,25^FD{empty2}^FS"}^FO450,370^A1R,30,25^FD{empty3}^FS"}^FO450,650^A1R,30,25^FD{empty4}^FS"}^FO450,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 5, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str10 = $"{$"{$"{$"{str9}^FO415,10^A1R,30,25^FD{empty2}^FS"}^FO415,370^A1R,30,25^FD{empty3}^FS"}^FO415,650^A1R,30,25^FD{empty4}^FS"}^FO415,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 6, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str11 = $"{$"{$"{$"{str10}^FO380,10^A1R,30,25^FD{empty2}^FS"}^FO380,370^A1R,30,25^FD{empty3}^FS"}^FO380,650^A1R,30,25^FD{empty4}^FS"}^FO380,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 7, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str12 = $"{$"{$"{$"{str11}^FO345,10^A1R,30,25^FD{empty2}^FS"}^FO345,370^A1R,30,25^FD{empty3}^FS"}^FO345,650^A1R,30,25^FD{empty4}^FS"}^FO345,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 8, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str13 = $"{$"{$"{$"{str12}^FO310,10^A1R,30,25^FD{empty2}^FS"}^FO310,370^A1R,30,25^FD{empty3}^FS"}^FO310,650^A1R,30,25^FD{empty4}^FS"}^FO310,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 9, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str14 = $"{$"{$"{$"{str13}^FO275,10^A1R,30,25^FD{empty2}^FS"}^FO275,370^A1R,30,25^FD{empty3}^FS"}^FO275,650^A1R,30,25^FD{empty4}^FS"}^FO275,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 10, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str15 = $"{$"{$"{$"{str14}^FO240,10^A1R,30,25^FD{empty2}^FS"}^FO240,370^A1R,30,25^FD{empty3}^FS"}^FO240,650^A1R,30,25^FD{empty4}^FS"}^FO240,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 11, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str16 = $"{$"{$"{$"{str15}^FO205,10^A1R,30,25^FD{empty2}^FS"}^FO205,370^A1R,30,25^FD{empty3}^FS"}^FO205,650^A1R,30,25^FD{empty4}^FS"}^FO205,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 12, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str17 = $"{$"{$"{$"{str16}^FO170,10^A1R,30,25^FD{empty2}^FS"}^FO170,370^A1R,30,25^FD{empty3}^FS"}^FO170,650^A1R,30,25^FD{empty4}^FS"}^FO170,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 13, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str18 = $"{$"{$"{$"{str17}^FO135,10^A1R,30,25^FD{empty2}^FS"}^FO135,370^A1R,30,25^FD{empty3}^FS"}^FO135,650^A1R,30,25^FD{empty4}^FS"}^FO135,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
                DataTableVerify(oDataTable, index * 15 + 14, ref empty2, ref empty3, ref empty4, ref empty5);
                num3 += ConvertUtil.ObjectToint((object)empty5);
                string str19 = $"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{str18}^FO100,10^A1R,30,25^FD{empty2}^FS"}^FO100,370^A1R,30,25^FD{empty3}^FS"}^FO100,650^A1R,30,25^FD{empty4}^FS"}^FO100,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS" + "^FO95,10^GB0,850,2^FS"}^FO60,10^A1R30,25^FD소계. SKU : {(index + 1 != num1 ? 15 : Math.Min(val1, 15)).ToString()}, 수량 : {num3.ToString()}^FS"}^FO60,0^A1R30,25^FB850,1,0,R,0^FD누계. SKU : {oDataTable.Rows.Count.ToString()}, 수량 : {(object)num2}^FS" + "^FO45,10^GB0,850,2^FS"}^FO10,20^A1R,25,25^FD{oDataTable.Rows[0]["센터명"].ToString()}^FS"}^FO10,0^A1R,25,20^FB800,1,0,R,0^FD{str1}^FS" + "^FO10,230^A1R,25,25^FDPAS^FS"}^FO10,350^A1R,25,25^FD( {(index + 1).ToString()} / {num1.ToString()} )^FS"}^FO50,990^A1N,50,40^FD{s박스바코드구분}^FS"}^FO300,920^BY2,2.0^BCN,90,N,N^FD{s박스바코드}^FS"}^FO300,1015^A1N,25,17^FD{str1}^FS" + "^FO580,960^A1N,25,20^FD수량^FS"}^FO580,990^A1N,50,45^FD{num2.ToString()}^FS" + "^FO680,960^A1N,25,20^FDSKU^FS"}^FO680,990^A1N,50,45^FD{oDataTable.Rows.Count.ToString()}^FS"}^FO50,1110^A1N,50,40^FD{s박스바코드구분}^FS" + "^FO300,1080^A1N,25,20^FD수량^FS"}^FO300,1110^A1N,50,45^FD{num2.ToString()}^FS" + "^FO400,1080^A1N,25,20^FDSKU^FS"}^FO400,1110^A1N,50,45^FD{oDataTable.Rows.Count.ToString()}^FS"}^FO500,1040^BY2,2.0^BCN,90,N,N^FD{s박스바코드}^FS"}^FO500,1135^A1N,25,17^FD{str1}^FS" + "^XZ";
                if (!string.IsNullOrEmpty(str19))
                {
                    if (oClient != null)
                    {
                        oClient.Close();
                        oClient = (TcpClient)null;
                    }
                    oClient = new TcpClient();
                    oClient.Connect(s프린터명, 9100);
                    if (oClient.Connected)
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)oClient.GetStream(), Encoding.GetEncoding(949)))
                        {
                            streamWriter.Write(str19);
                            streamWriter.Flush();
                            streamWriter.Close();
                        }
                    }
                }
                Thread.Sleep(300);
            }
        }
    }
}
