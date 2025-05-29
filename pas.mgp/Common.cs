// Decompiled with JetBrains decompiler
// Type: pas.mgp.Common
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using CrystalDecisions.CrystalReports.Engine;
using NetHelper.Control;
// using pas.mgp.Report;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class Common
{
  public static Color SPLITTER_COLOR = SystemColors.InactiveBorder;
  public static StatusStrip 전역상태바 = (StatusStrip) null;
  public static ToolStripStatusLabel 전역상태메시지 = (ToolStripStatusLabel) null;
  public static ToolStripProgressBar 전역진행상태 = (ToolStripProgressBar) null;

  public static string Version => "1.1.170601.1";

  public static string Title => $"PAS Management Program v{Common.Version}";

  public static string PATH_STARTUP { get; set; }

  public static string PATH_DATA => "\\DATA";

  public static string PATH_TEMP => "\\TEMP";

  public static string PATH_LOG => "\\LOG";

  public static string FILE_SETTING => "\\pas.ini";

  public static int REBUILD_DELAY_COUNT => 60;

  public static int BATCH_END_DELAY_TIME => 30000;

  public static string UPDATE_ARGUMENT
  {
    get
    {
      return "http://112.216.239.253:8888/pas/slk/mgp/index.jsp http://112.216.239.253:8888/pas/slk/mgp/fileDown.jsp pas.mgp.exe";
    }
  }

  public static Setting Setting { get; set; }

  public static bool IsLog { get; set; }

  public static int PrinterIndex { get; set; }

  public static string ConnectionString(DB연결구분 e = DB연결구분.로컬)
  {
    Common.GetSetting();
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string empty4 = string.Empty;
    string sIp;
    string sService;
    string sId;
    string sPassword;
    switch (e)
    {
      case DB연결구분.시스템:
        sIp = Common.Setting.HOST_DB_IP;
        sService = Common.Setting.HOST_DB_SERVICE;
        sId = Common.Setting.HOST_DB_ID;
        sPassword = Common.Setting.HOST_DB_PASSWORD;
        break;
      default:
        sIp = Common.Setting.PAS_DB_IP;
        sService = Common.Setting.PAS_DB_SERVICE;
        sId = Common.Setting.PAS_DB_ID;
        sPassword = Common.Setting.PAS_DB_PASSWORD;
        break;
    }
    return Common.ConnectionString(sIp, sService, sId, sPassword);
  }

  public static string ConnectionString(string sIp, string sService, string sId, string sPassword)
  {
    return "Data Source={HOST};Initial Catalog={DB};Persist Security Info=True;User ID={ID};Password={PASSWORD}".Replace("{HOST}", sIp).Replace("{DB}", sService).Replace("{ID}", sId).Replace("{PASSWORD}", sPassword);
  }

  public static int C2I(object obj)
  {
    try
    {
      return Convert.ToInt32(obj);
    }
    catch
    {
      return 0;
    }
  }

  public static long C2L(object obj)
  {
    try
    {
      return Convert.ToInt64(obj);
    }
    catch
    {
      return 0;
    }
  }

  public static string C2S(object obj)
  {
    try
    {
      return obj.ToString();
    }
    catch
    {
      return string.Empty;
    }
  }

  public static byte[] S2B(string inStr)
  {
    byte[] numArray = (byte[]) null;
    try
    {
      numArray = new byte[inStr.Length / 2];
      if (inStr.Length % 2 == 0)
      {
        for (int index = 0; index < inStr.Length / 2; ++index)
          numArray[index] = Convert.ToByte(inStr.ToString().Substring(index * 2, inStr.Length - (inStr.Length - 2)), 16 /*0x10*/);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.ToString());
    }
    return numArray;
  }

  public static string H2S(byte[] yBuffer)
  {
    string str = string.Empty;
    if (yBuffer == null)
      return string.Empty;
    try
    {
      for (int index = 0; index < yBuffer.Length; ++index)
        str = index != 0 ? $"{str}, {yBuffer[index].ToString("X2")}" : yBuffer[index].ToString("X2");
    }
    catch (Exception ex)
    {
      str = ex.Message;
    }
    return str;
  }

  public static string B2C(byte[] inBytes)
  {
    string empty = string.Empty;
    try
    {
      for (int index = 0; index < inBytes.Length; ++index)
        empty += Convert.ToChar(inBytes[index]).ToString();
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }
    return empty;
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

  public static void Log(params object[] args)
  {
    if (!Common.IsLog)
      return;
    string path = Common.PATH_STARTUP + Common.PATH_LOG + $"\\PAS_{DateTime.Now.ToString("yyyyMMdd")}.LOG";
    if (!Directory.Exists(Common.PATH_STARTUP + Common.PATH_LOG))
      Directory.CreateDirectory(Common.PATH_STARTUP + Common.PATH_LOG);
    FileMode mode = File.Exists(path) ? FileMode.Append : FileMode.CreateNew;
    string empty = string.Empty;
    string str = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff");
    for (int index = 0; index < args.Length; ++index)
      str = $"{str},{args[index].ToString()}";
    try
    {
      using (FileStream fileStream = new FileStream(path, mode))
      {
        byte[] bytes = Encoding.UTF8.GetBytes(str + "\r\n");
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Flush();
        fileStream.Close();
      }
    }
    catch
    {
      Common.Log(args);
    }
  }

  public static void GetSetting()
  {
    Setting setting = new Setting();
    try
    {
      INI ini = new INI(Common.PATH_STARTUP + Common.FILE_SETTING);
      setting.NAME = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.NAME);
      setting.SEIGYO_IP = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_IP);
      setting.SEIGYO_PORT = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_PORT);
      setting.CHUTES = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES);
      setting.CHUTES_ERROR = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES_ERROR);
      setting.CHUTES_OVERFLOW = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES_OVERFLOW);
      setting.LOCAL_FOLDER = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.LOCAL_FOLDER);
      setting.SEIGYO_FOLDER = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_FOLDER);
      setting.SEIGYO_ID = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_ID);
      setting.SEIGYO_PASSWORD = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_PASSWORD);
      setting.PAS_DURATION = Common.C2I((object) ini.GetIniValue(INI_SECTION.PAS, INI_KEY.PAS_DURATION));
      setting.INDICATOR_DURATION = Common.C2I((object) ini.GetIniValue(INI_SECTION.PAS, INI_KEY.INDICATOR_DURATION));
      if (setting.PAS_DURATION == 0)
        setting.PAS_DURATION = 3;
      if (setting.INDICATOR_DURATION == 0)
        setting.INDICATOR_DURATION = 3;
      setting.INDICATOR_IP = ini.GetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_IP);
      setting.INDICATOR_PORT = ini.GetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_PORT);
      setting.INDICATOR_STRUCTURE = ini.GetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_STRUCTURE);
      setting.PAS_DB_IP = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_IP);
      setting.PAS_DB_SERVICE = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_SERVICE);
      setting.PAS_DB_ID = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_ID);
      setting.PAS_DB_PASSWORD = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_PASSWORD);
      setting.HOST_DB_IP = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_IP);
      setting.HOST_DB_SERVICE = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_SERVICE);
      setting.HOST_DB_ID = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_ID);
      setting.HOST_DB_PASSWORD = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_PASSWORD);
      setting.BARCODE_PRINTER_LIST = ini.GetIniValue(INI_SECTION.PRINTER, INI_KEY.BARCODE_PRINTER_LIST);
      setting.PRINTER_LIST = ini.GetIniValue(INI_SECTION.PRINTER, INI_KEY.PRINTER_LIST);
      Common.PrinterIndex = 0;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
    Common.Setting = setting;
  }

  public static string GetPrinterName(string s슈트번호)
  {
    string empty = string.Empty;
    string printerName = new PrinterSettings().PrinterName;
    try
    {
      string[] strArray1 = Common.Setting.BARCODE_PRINTER_LIST.Split(new string[1]
      {
        "|"
      }, StringSplitOptions.RemoveEmptyEntries);
      if (s슈트번호 == "패키지")
      {
        foreach (string str in strArray1)
        {
          string[] separator = new string[1]{ "," };
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
        int num1 = Common.C2I((object) s슈트번호);
        foreach (string str in strArray1)
        {
          string[] separator = new string[1]{ "," };
          string[] strArray3 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          if (strArray3 != null && strArray3.Length > 0)
          {
            int num2 = Common.C2I((object) strArray3[1]);
            int num3 = Common.C2I((object) strArray3[2]);
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

  public static void RGrid_Initializing(RGrid oGrid, bool bReadOnly)
  {
    Common.RGrid_Initializing(oGrid, bReadOnly, true, false, RowHeaderStyle.None);
  }

  public static void RGrid_Initializing(RGrid oGrid, bool bReadOnly, bool bAlternateColor)
  {
    Common.RGrid_Initializing(oGrid, bReadOnly, bAlternateColor, false, RowHeaderStyle.None);
  }

  public static void RGrid_Initializing(
    RGrid oGrid,
    bool bReadOnly,
    bool bAlternateColor,
    bool bRowHeaderVisibale,
    RowHeaderStyle e)
  {
    oGrid.ForeColor = Color.DimGray;
    if (bAlternateColor)
      oGrid.AlternateColor = Color.Lavender;
    oGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
    oGrid.BorderStyle = BorderStyle.FixedSingle;
    oGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    oGrid.MultiSelect = false;
    oGrid.RowHeadersVisible = bRowHeaderVisibale;
    if (bRowHeaderVisibale)
      oGrid.RowHeaderStyle = e;
    oGrid.ReadOnly = bReadOnly;
  }

  public static void ErrorMessageBox(string sMessage)
  {
    int num = (int) MessageBox.Show(sMessage, Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
  }

  public static DialogResult QuestionMessageBox(string sMessage)
  {
    return MessageBox.Show(sMessage, Common.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
  }

  public static void OkMessageBox(string sMessage)
  {
    int num = (int) MessageBox.Show(sMessage, Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
      DataRow[] dataRowArray = oDataTable.Select("IDX=" + (object) (idx + 1));
      if (dataRowArray == null || dataRowArray.Length <= 0)
      {
        s스타일 = string.Empty;
        s색상 = string.Empty;
        s사이즈 = string.Empty;
        s내품수 = string.Empty;
      }
      else
      {
        s스타일 = Common.Substring(dataRowArray[0]["스타일"].ToString(), 18);
        s색상 = Common.Substring(dataRowArray[0]["색상"].ToString(), 16 /*0x10*/);
        s사이즈 = Common.Substring(dataRowArray[0]["사이즈"].ToString(), 7);
        int num = Common.C2I(dataRowArray[0]["수량"]);
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
    int num2 = Common.C2I(oDataTable.Compute("SUM(수량)", string.Empty));
    string empty5 = string.Empty;
    string str1 = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss");
    string str2 = "~DGSLKN.GRF,330,10," + "00000000000000000000" + "00000000000000000000" + "0007FFFF000000000000" + "007FFFFF000000000000" + "01FFFFFF800000000000" + "03FFFFFF800000000000" + "07FFFFFF800000000000" + "07FFFFFF800000000000" + "0FFFF80F800000000000" + "0FFFE000800000000000" + "0FFFE000000000000000" + "0FFFF000000000000000" + "07FFF800000000000000" + "03FFFE00000000000000" + "01FFFF80000000000000" + "00FFFFC0000000000000" + "003FFFF003F8007F03F8" + "000FFFFC03F800FF07F8" + "0007FFFE03F800FF0FF0" + "0001FFFF03F800FE1FC0" + "00007FFF83F800FE3F80" + "00003FFF83F800FE7F00" + "00001FFF83F800FFFE00" + "3C003FFF83F800FEFE00" + "1FE07FFF83F800FEFF00" + "1FFFFFFF83F800FE7F80" + "1FFFFFFF03F800FE3FC0" + "1FFFFFFE07FFFCFE1FE0" + "1FFFFFFC07FFFCFE0FF0" + "1FFFFFF007FFFCFE07F8" + "00FFFF0007FFF8FC03F8" + "00000000000000000000" + "00000000000000000000";
    string str3 = "~DGSLKR.GRF,400,5," + "0000000000" + "0000000000" + "00C0000000" + "1FC0000000" + "1FC0078000" + "1FC00FE000" + "1F801FF000" + "1F803FF800" + "3F807FF800" + "3F807FFC00" + "3F80FFFC00" + "3F00FFFC00" + "3F01FFFE00" + "3F03FFFE00" + "3F03FFFE00" + "3F07FFFE00" + "3F87FFFE00" + "3F8FFFFE00" + "3FDFFFFE00" + "3FFFF8FE00" + "3FFFF8FE00" + "3FFFF07E00" + "3FFFF07E00" + "3FFFE07E00" + "1FFFC07E00" + "1FFFC07E00" + "1FFF807E00" + "1FFF807E00" + "0FFF00FE00" + "07FF00FE00" + "07FE00FE00" + "03FC00FE00" + "01F801F800" + "0000000000" + "0000000000" + "0000000000" + "0000000000" + "3C00000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "3C00000000" + "1C00000000" + "0000000000" + "0000000000" + "3FFF000000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "3FFF800000" + "1FFF800000" + "0023800000" + "00E0000000" + "01F0000000" + "03F8000000" + "07FC000000" + "0FFE000000" + "1FFF000000" + "3FFF800000" + "3F9F800000" + "3F0F800000" + "3E07800000" + "3C03800000" + "3803800000" + "3001800000" + "0000000000" + "0000000000" + "0000000000";
    for (int index = 0; index < num1; ++index)
    {
      int num3 = 0;
      string str4 = $"{$"{"^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^POI" + "^LH20,20"}^FO690,20^A1R,70,70^FD{s박스바코드구분}^FS"}^FO690,500^BY3,2.0^BCR,70,N,N^FD{s박스바코드}^FS" + "^FO680,10^GB0,850,2^FS" + "^FO640,20^A1R,25,25^FD스타일^FS" + "^FO640,370^A1R,25,25^FD색상^FS" + "^FO640,650^A1R,25,25^FD사이즈^FS" + "^FO640,0^A1R,25,25^FB850,1,0,R,0^FD수량^FS" + "^FO630,10^GB0,850,2^FS";
      Common.DataTableVerify(oDataTable, index * 15, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str5 = $"{$"{$"{$"{str4}^FO590,10^A1R,30,25^FD{empty2}^FS"}^FO590,370^A1R,30,25^FD{empty3}^FS"}^FO590,650^A1R,30,25^FD{empty4}^FS"}^FO590,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 1, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str6 = $"{$"{$"{$"{str5}^FO555,10^A1R,30,25^FD{empty2}^FS"}^FO555,370^A1R,30,25^FD{empty3}^FS"}^FO555,650^A1R,30,25^FD{empty4}^FS"}^FO555,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 2, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str7 = $"{$"{$"{$"{str6}^FO520,10^A1R,30,25^FD{empty2}^FS"}^FO520,370^A1R,30,25^FD{empty3}^FS"}^FO520,650^A1R,30,25^FD{empty4}^FS"}^FO520,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 3, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str8 = $"{$"{$"{$"{str7}^FO485,10^A1R,30,25^FD{empty2}^FS"}^FO485,370^A1R,30,25^FD{empty3}^FS"}^FO485,650^A1R,30,25^FD{empty4}^FS"}^FO485,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 4, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str9 = $"{$"{$"{$"{str8}^FO450,10^A1R,30,25^FD{empty2}^FS"}^FO450,370^A1R,30,25^FD{empty3}^FS"}^FO450,650^A1R,30,25^FD{empty4}^FS"}^FO450,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 5, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str10 = $"{$"{$"{$"{str9}^FO415,10^A1R,30,25^FD{empty2}^FS"}^FO415,370^A1R,30,25^FD{empty3}^FS"}^FO415,650^A1R,30,25^FD{empty4}^FS"}^FO415,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 6, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str11 = $"{$"{$"{$"{str10}^FO380,10^A1R,30,25^FD{empty2}^FS"}^FO380,370^A1R,30,25^FD{empty3}^FS"}^FO380,650^A1R,30,25^FD{empty4}^FS"}^FO380,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 7, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str12 = $"{$"{$"{$"{str11}^FO345,10^A1R,30,25^FD{empty2}^FS"}^FO345,370^A1R,30,25^FD{empty3}^FS"}^FO345,650^A1R,30,25^FD{empty4}^FS"}^FO345,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 8, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str13 = $"{$"{$"{$"{str12}^FO310,10^A1R,30,25^FD{empty2}^FS"}^FO310,370^A1R,30,25^FD{empty3}^FS"}^FO310,650^A1R,30,25^FD{empty4}^FS"}^FO310,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 9, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str14 = $"{$"{$"{$"{str13}^FO275,10^A1R,30,25^FD{empty2}^FS"}^FO275,370^A1R,30,25^FD{empty3}^FS"}^FO275,650^A1R,30,25^FD{empty4}^FS"}^FO275,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 10, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str15 = $"{$"{$"{$"{str14}^FO240,10^A1R,30,25^FD{empty2}^FS"}^FO240,370^A1R,30,25^FD{empty3}^FS"}^FO240,650^A1R,30,25^FD{empty4}^FS"}^FO240,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 11, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str16 = $"{$"{$"{$"{str15}^FO205,10^A1R,30,25^FD{empty2}^FS"}^FO205,370^A1R,30,25^FD{empty3}^FS"}^FO205,650^A1R,30,25^FD{empty4}^FS"}^FO205,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 12, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str17 = $"{$"{$"{$"{str16}^FO170,10^A1R,30,25^FD{empty2}^FS"}^FO170,370^A1R,30,25^FD{empty3}^FS"}^FO170,650^A1R,30,25^FD{empty4}^FS"}^FO170,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 13, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str18 = $"{$"{$"{$"{str17}^FO135,10^A1R,30,25^FD{empty2}^FS"}^FO135,370^A1R,30,25^FD{empty3}^FS"}^FO135,650^A1R,30,25^FD{empty4}^FS"}^FO135,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS";
      Common.DataTableVerify(oDataTable, index * 15 + 14, ref empty2, ref empty3, ref empty4, ref empty5);
      num3 += Common.C2I((object) empty5);
      string str19 = $"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{$"{str18}^FO100,10^A1R,30,25^FD{empty2}^FS"}^FO100,370^A1R,30,25^FD{empty3}^FS"}^FO100,650^A1R,30,25^FD{empty4}^FS"}^FO100,780^A1R,30,25^FB70,1,0,R,0^FD{empty5}^FS" + "^FO95,10^GB0,850,2^FS"}^FO60,10^A1R30,25^FD소계. SKU : {(index + 1 != num1 ? 15 : Math.Min(val1, 15)).ToString()}, 수량 : {num3.ToString()}^FS"}^FO60,0^A1R30,25^FB850,1,0,R,0^FD누계. SKU : {oDataTable.Rows.Count.ToString()}, 수량 : {(object) num2}^FS" + "^FO45,10^GB0,850,2^FS"}^FO10,20^A1R,25,25^FD{oDataTable.Rows[0]["센터명"].ToString()}^FS"}^FO10,0^A1R,25,20^FB800,1,0,R,0^FD{str1}^FS" + "^FO10,230^A1R,25,25^FDPAS^FS"}^FO10,350^A1R,25,25^FD( {(index + 1).ToString()} / {num1.ToString()} )^FS"}^FO50,990^A1N,50,40^FD{s박스바코드구분}^FS"}^FO300,920^BY2,2.0^BCN,90,N,N^FD{s박스바코드}^FS"}^FO300,1015^A1N,25,17^FD{str1}^FS" + "^FO580,960^A1N,25,20^FD수량^FS"}^FO580,990^A1N,50,45^FD{num2.ToString()}^FS" + "^FO680,960^A1N,25,20^FDSKU^FS"}^FO680,990^A1N,50,45^FD{oDataTable.Rows.Count.ToString()}^FS"}^FO50,1110^A1N,50,40^FD{s박스바코드구분}^FS" + "^FO300,1080^A1N,25,20^FD수량^FS"}^FO300,1110^A1N,50,45^FD{num2.ToString()}^FS" + "^FO400,1080^A1N,25,20^FDSKU^FS"}^FO400,1110^A1N,50,45^FD{oDataTable.Rows.Count.ToString()}^FS"}^FO500,1040^BY2,2.0^BCN,90,N,N^FD{s박스바코드}^FS"}^FO500,1135^A1N,25,17^FD{str1}^FS" + "^XZ";
      if (!string.IsNullOrEmpty(str19))
      {
        if (oClient != null)
        {
          oClient.Close();
          oClient = (TcpClient) null;
        }
        oClient = new TcpClient();
        oClient.Connect(s프린터명, 9100);
        if (oClient.Connected)
        {
          using (StreamWriter streamWriter = new StreamWriter((Stream) oClient.GetStream(), Encoding.GetEncoding(949)))
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

  public static bool 거래명세서발행_토탈(string s배치번호, string s슈트번호, string s거명용바코드)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string empty4 = string.Empty;
    string empty5 = string.Empty;
    string empty6 = string.Empty;
    DataTable dataTable = new DataTable("usp_출하_토탈패킹내역_Get");
    DbProvider.Select(Common.ConnectionString(), dataTable, DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) s슈트번호, ParameterDirection.Input));
    if (dataTable == null || dataTable.Rows.Count <= 0)
      return false;
    string[] strArray = Common.Setting.PRINTER_LIST.Split(new string[1]
    {
      "|"
    }, StringSplitOptions.RemoveEmptyEntries);
    if (strArray == null || strArray.Length <= 0)
    {
      Common.ErrorMessageBox("설정된 프린터가 없습니다.");
      return false;
    }
    if (Common.PrinterIndex >= strArray.Length)
      Common.PrinterIndex = 0;
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
      ReportClass reportClass = (ReportClass) new 레포트_박스별실적상세_토탈();
      reportClass.SetDataSource(dataTable);
      reportClass.SetParameterValue(0, (object) val4);
      reportClass.SetParameterValue(1, (object) val1);
      reportClass.SetParameterValue(2, (object) val3);
      reportClass.SetParameterValue(3, (object) val2);
      reportClass.SetParameterValue(4, (object) s배치번호);
      reportClass.SetParameterValue(5, (object) s슈트번호);
      reportClass.SetParameterValue(6, (object) s거명용바코드);
      if (reportClass == null)
        return false;
      try
      {
        reportClass.PrintOptions.PrinterName = strArray[Common.PrinterIndex++];
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
      ++Common.PrinterIndex;
    }
  }

  public static bool 거래명세서발행_박스별(string s배치번호, string s슈트번호, string s거명용바코드)
  {
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string empty4 = string.Empty;
    string empty5 = string.Empty;
    string empty6 = string.Empty;
    DataTable dataTable = new DataTable("usp_출하_박스별패킹내역_Get");
    DbProvider.Select(Common.ConnectionString(), dataTable, DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) s슈트번호, ParameterDirection.Input));
    if (dataTable == null || dataTable.Rows.Count <= 0)
      return false;
    string[] strArray = Common.Setting.PRINTER_LIST.Split(new string[1]
    {
      "|"
    }, StringSplitOptions.RemoveEmptyEntries);
    if (strArray == null || strArray.Length <= 0)
    {
      Common.ErrorMessageBox("설정된 프린터가 없습니다.");
      return false;
    }
    if (Common.PrinterIndex >= strArray.Length)
      Common.PrinterIndex = 0;
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
          reportClass = (ReportClass) new 레포트_박스별실적상세_SM();
          reportClass.SetDataSource(dataTable);
          reportClass.SetParameterValue(0, (object) row["주문일자"].ToString());
          reportClass.SetParameterValue(1, (object) row["예정일자"].ToString());
          reportClass.SetParameterValue(2, (object) val2);
          reportClass.SetParameterValue(3, (object) s슈트번호);
          reportClass.SetParameterValue(4, (object) s거명용바코드);
          break;
        case "A1":
        case "A2":
        case "WW":
          reportClass = (ReportClass) new 레포트_박스별실적상세_상품명();
          reportClass.SetDataSource(dataTable);
          reportClass.SetParameterValue(0, (object) val4);
          reportClass.SetParameterValue(1, (object) val1);
          reportClass.SetParameterValue(2, (object) val3);
          reportClass.SetParameterValue(3, (object) val2);
          reportClass.SetParameterValue(4, (object) s배치번호);
          reportClass.SetParameterValue(5, (object) s슈트번호);
          reportClass.SetParameterValue(6, (object) s거명용바코드);
          break;
        default:
          reportClass = (ReportClass) new 레포트_박스별실적상세();
          reportClass.SetDataSource(dataTable);
          reportClass.SetParameterValue(0, (object) val4);
          reportClass.SetParameterValue(1, (object) val1);
          reportClass.SetParameterValue(2, (object) val3);
          reportClass.SetParameterValue(3, (object) val2);
          reportClass.SetParameterValue(4, (object) s배치번호);
          reportClass.SetParameterValue(5, (object) s슈트번호);
          reportClass.SetParameterValue(6, (object) s거명용바코드);
          break;
      }
      if (reportClass == null)
        return false;
      try
      {
        reportClass.PrintOptions.PrinterName = strArray[Common.PrinterIndex++];
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
      ++Common.PrinterIndex;
    }
  }
}
