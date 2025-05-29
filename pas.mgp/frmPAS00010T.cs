// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00010T
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
// using pas.mgp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00010T : Form
{
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Button button1;
  private Button button2;
  private Button button3;
  private Button button4;
  private Button button5;
  private Button button6;
  private Button button7;
  private Button button8;
  private Button button9;
  private ComboBox comboBox1;
  private TextBox textBox1;
  private TextBox textBox2;
  private TextBox textBox3;
  private Button button10;

  public frmPAS00010T()
  {
    this.InitializeComponent();
    this.Text = "배치 개시/종료 (TEST)";
    this.BackColor = Color.White;
    for (int index = 2; index <= 150; ++index)
      this.comboBox1.Items.Add((object) index.ToString("D3"));
    this.comboBox1.SelectedIndex = 0;
  }

  private void button1_Click(object sender, EventArgs e)
  {
    DataTable oDataTable = new DataTable("usp_데이터검증용_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@구분자", (object) "X", ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) "D1633001", ParameterDirection.Input));
    MakeData.MakeEXECBAT(".\\", new Execbat[1]
    {
      new Execbat(string.Empty, string.Empty, oDataTable.Rows[0]["작업일자"].ToString(), "N1640501", "TEST", "0", "??????????", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    });
  }

  private void button2_Click(object sender, EventArgs e)
  {
    DataTable oDataTable = new DataTable("usp_데이터검증용_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@구분자", (object) "S", ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) "D1633001", ParameterDirection.Input));
    List<Sortq> sortqList = new List<Sortq>();
    foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
      sortqList.Add(new Sortq(row["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row["아이템구성"].ToString(), row["상품명"].ToString(), string.Empty, string.Empty, row["슈트번호"].ToString(), row["지시수"].ToString(), string.Empty, string.Empty, row["대표바코드"].ToString(), string.Empty, string.Empty, row["대체바코드1"].ToString(), row["대체바코드2"].ToString(), string.Empty));
    MakeData.MakeSORTQ(".\\", "0405", "N1640501", sortqList.ToArray());
  }

  private void button3_Click(object sender, EventArgs e)
  {
    DataTable oDataTable = new DataTable("usp_데이터검증용_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@구분자", (object) "C", ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) "D1633001", ParameterDirection.Input));
    List<Chute> chuteList = new List<Chute>();
    foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
      chuteList.Add(new Chute(row["슈트번호"].ToString(), string.Empty, string.Empty, "1", row["지시수"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
    MakeData.MakeCHUTE(".\\", "0405", "N1640501", chuteList.ToArray(), false, 150);
  }

  private void button7_Click(object sender, EventArgs e)
  {
    MakeData.MakeMEMBER(".\\", "0405", "N1640501");
    MakeData.MakeSIMPLE(".\\", "0405", "N1640501");
    MakeData.MakeSORTA(".\\", "0405", "N1640501");
    MakeData.MakeREBUILD(".\\", "0405", "N1640501", 재구성구분.빈파일, (Rebuild[]) null);
  }

  private void button4_Click(object sender, EventArgs e)
  {
    DataTable oDataTable = new DataTable("usp_데이터검증용_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@구분자", (object) "S", ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) "D1633002", ParameterDirection.Input));
    List<Rebuild> rebuildList = new List<Rebuild>();
    foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
      rebuildList.Add(new Rebuild(string.Empty, "I", row["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row["아이템구성"].ToString(), row["상품명"].ToString(), string.Empty, string.Empty, row["슈트번호"].ToString(), row["지시수"].ToString(), string.Empty, string.Empty, row["대표바코드"].ToString(), string.Empty, string.Empty, row["대체바코드1"].ToString(), row["대체바코드2"].ToString(), string.Empty, string.Empty, string.Empty));
    MakeData.MakeREBUILD(".\\", "0405", "N1640501", 재구성구분.배치, rebuildList.ToArray());
  }

  private void button6_Click(object sender, EventArgs e)
  {
    DataTable oDataTable = new DataTable("usp_데이터검증용_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@구분자", (object) "S", ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) "D1633007", ParameterDirection.Input));
    List<Rebuild> rebuildList = new List<Rebuild>();
    foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
      rebuildList.Add(new Rebuild(string.Empty, "I", row["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row["아이템구성"].ToString(), row["상품명"].ToString(), string.Empty, string.Empty, row["슈트번호"].ToString(), row["지시수"].ToString(), string.Empty, string.Empty, row["대표바코드"].ToString(), string.Empty, string.Empty, row["대체바코드1"].ToString(), row["대체바코드2"].ToString(), string.Empty, string.Empty, string.Empty));
    MakeData.MakeREBUILD(".\\", "0405", "N1640501", 재구성구분.배치, rebuildList.ToArray());
  }

  private void button5_Click(object sender, EventArgs e)
  {
    List<Rebuild> rebuildList = new List<Rebuild>();
    for (int index = 2; index <= 75; ++index)
    {
      if (index != 56)
        rebuildList.Add(new Rebuild(string.Empty, "E", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, index.ToString("D3"), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
    }
    MakeData.MakeREBUILD(".\\", "0405", "N1640501", 재구성구분.종료, rebuildList.ToArray());
  }

  private void button8_Click(object sender, EventArgs e)
  {
    try
    {
      List<Rebuild> rebuildList = MakeData.REBUILDParsing(Common.Setting.LOCAL_FOLDER, this.textBox1.Text, this.textBox2.Text);
      this.textBox3.Text = MakeData.REBUILDComplete(Common.Setting.LOCAL_FOLDER, this.textBox1.Text, this.textBox2.Text).ToString() + "\r\n";
      foreach (Rebuild rebuild in rebuildList.ToArray())
        this.textBox3.AppendText($"{rebuild.Mark}/{rebuild.Flag}\r\n");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
  }

  private void button9_Click(object sender, EventArgs e)
  {
    MakeData.MakeREBUILD(Common.Setting.LOCAL_FOLDER, this.textBox1.Text, this.textBox2.Text, 재구성구분.종료, new List<Rebuild>()
    {
      new Rebuild(string.Empty, "E", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, this.comboBox1.Text, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
    }.ToArray());
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.Close();

  private string GetPrintScript(string s패턴구분, string s배치구분, int i박스풀대상수)
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
        printScript = str2 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH10,10" + "^FO480,20^A1R,40,40^FD{0}^FS" + "^FO430,20^A1R,40,40^FD{1}^FS" + "^FO410,10^GB0,530,1^FS" + "^FO350,20^A1R,35,35^FD슈트번호^FS" + "^FO350,200^A1R,35,35^FD박스번호^FS" + "^FO350,400^A1R,35,35^FD수량^FS" + "^FO280,20^A1R,50,40^FD{2}^FS" + "^FO280,200^A1R,50,40^FD{3}^FS" + "^FO280,400^A1R,50,40^FD{4}^FS" + "^FO100,30^BY2,2.0" + "^B3R,R,150,Y,N,N^FD*{5}*^FS" + "^FO10,20^A1R,25,20^FD{6}^FS" + "^FO10,450^XGSLKR,1,1,^FS" + "^PQ1^XZ";
        break;
      case "반품유형1":
        string str3 = str2 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH10,10" + "^FO480,20^A1R,30,25^FD{0}^FS" + "^FO480,320^A1R,30,25^FD[{1}]^FS" + "^FO410,20^BY3" + "^BCR,50,N,N,N^FD{2}^FS" + "^FO380,140^A1R,25,20^FD{3}^FS" + "^FO350,20^A1R,20,20^FD슈트번호^FS" + "^FO270,20^A1R,80,60^FD{4}^FS" + "^FO350,210^A1R,20,20^FD박스번호^FS" + "^FO270,210^A1R,80,60^FD{5}^FS" + "^FO350,350^A1R,20,20^FD수량^FS" + "^FO270,350^A1R,80,60^FD{6}^FS";
        if (i박스풀대상수 >= 1)
          str3 = str3 + "^FO220,20^BY2.2.0" + "^BCR,40,N,N,N^FD{7}^FS" + "^FO190,20^A1R,25,20^FD{7}^FS" + "^FO190,350^A1R,25,20^FD{8}^FS";
        if (i박스풀대상수 >= 2)
          str3 = str3 + "^FO150,20^BY2.2.0" + "^BCR,40,N,N,N^FD{9}^FS" + "^FO120,20^A1R,25,20^FD{9}^FS" + "^FO120,350^A1R,25,20^FD{10}^FS";
        if (i박스풀대상수 >= 3)
          str3 = str3 + "^FO80,20^BY2.2.0" + "^BCR,40,N,N,N^FD{11}^FS" + "^FO50,20^A1R,25,20^FD{11}^FS" + "^FO50,350^A1R,25,20^FD{12}^FS";
        printScript = str3 + "^FO0,20^A1R,25,20^FD{13}^FS" + "^FO0,450^XGSLKR,1,1,^FS" + "^PQ1^XZ";
        break;
      case "반품유형2":
        printScript = str2 + "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26" + "^PON" + "^LH10,10" + "^FO480,20^A1R,30,25^FD{0}^FS" + "^FO410,20^BY3" + "^BCR,50,N,N,N^FD{1}^FS" + "^FO380,140^A1R,25,20^FD{2}^FS" + "^FO330,20^A1R,20,20^FD배치번호^FS" + "^FO290,20^A1R,40,30^FD{3}^FS" + "^FO250,20^A1R,20,20^FD슈트번호^FS" + "^FO170,20^A1R,80,60^FD{4}^FS" + "^FO250,270^A1R,20,20^FD박스번호^FS" + "^FO170,270^A1R,80,60^FD{5}^FS" + "^FO140,270^A1R,20,20^FD수량^FS" + "^FO60,270^A1R,80,60^FD{6}^FS" + "^FO140,20^A1R,20,20^FDSKU^FS" + "^FO60,20^A1R,80,60^FD{7}^FS" + "^FO0,20^A1R,25,20^FD{8}^FS" + "^FO0,450^XGSLKR,1,1,^FS" + "^PQ1^XZ";
        break;
      default:
        string str4 = "^XA" + "^SEE:UHANGUL.DAT^FS" + "^CW1,E:KFONT3.FNT^FS" + "^CI26";
        string str5 = (!(s배치구분 == "반품") ? str4 + "^FO30,15^A1N,40,40^FD점명:{0}^FS" : str4 + "^FO30,15^A1N,40,40^FDSKU:{0}^FS") + "^FO30,65^A1N,40,40^FD슈트:{1}^FS" + "^FO300,65^A1N,40,40^FD수량:{2}^FS" + "^FO60,118^BY2,2.0";
        printScript = (!(s배치구분 == "반품") ? str5 + "^B3N,N,120,Y,N,N^FD*{3}*^FS" : str5 + "^B3N,N,120,Y,N,N^FD{3}^FS") + "^PQ1^XZ";
        break;
    }
    return printScript;
  }

  private void button10_Click(object sender, EventArgs e)
  {
    TcpClient tcpClient1 = (TcpClient) null;
    using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
    {
      DataTable oDataTable = new DataTable("usp_분류_박스풀작성_Set");
      string s슈트번호 = "088";
      string str1 = "S1681601";
      string str2 = "PAS01";
      dbProvider2.Initialize("usp_분류_박스풀작성_Set", "@분류번호", "@장비명", "@슈트번호", "@마지막박스여부");
      dbProvider2.Fill(oDataTable, (object) str1, (object) str2, (object) s슈트번호, (object) "0");
      if (oDataTable != null && oDataTable.Rows.Count > 0)
      {
        string str3 = oDataTable.Rows[0]["박스바코드"].ToString();
        string str4 = oDataTable.Rows[0]["박스바코드구분"].ToString();
        oDataTable.Rows[0]["점코드"].ToString();
        string str5 = oDataTable.Rows[0]["점명"].ToString();
        string str6 = oDataTable.Rows[0]["박스번호"].ToString();
        string str7 = oDataTable.Rows[0]["내품수"].ToString();
        string s배치구분 = oDataTable.Rows[0]["배치구분"].ToString();
        string s패턴구분 = oDataTable.Rows[0]["패턴구분"].ToString();
        string str8 = oDataTable.Rows[0]["출력여부"].ToString();
        string str9 = oDataTable.Rows[0]["브랜드코드"].ToString();
        string str10 = oDataTable.Rows[0]["브랜드명"].ToString();
        string str11 = oDataTable.Rows[0]["배치번호"].ToString();
        string str12 = oDataTable.Rows[0]["배치명"].ToString();
        oDataTable.Rows[0]["대표바코드"].ToString();
        oDataTable.Rows[0]["수량"].ToString();
        string str13 = DateTime.Now.ToString("yyyy-MM-dd");
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string empty3 = string.Empty;
        string empty4 = string.Empty;
        string empty5 = string.Empty;
        string empty6 = string.Empty;
        int num = Common.C2I(oDataTable.Rows[0]["SKU수"]);
        int count = oDataTable.Rows.Count;
        if (s배치구분 == "반품")
          s패턴구분 = num <= 3 ? "반품유형1" : "반품유형2";
        if (!string.IsNullOrEmpty(str7) && str7 != "0" && str8 == "1")
        {
          string printScript = this.GetPrintScript(s패턴구분, s배치구분, count);
          string str14;
          switch (s패턴구분)
          {
            case "사용안함":
              str14 = string.Empty;
              break;
            case "출고유형":
              str14 = string.Format(printScript, (object) $"{str9}:{str10}", (object) str5, (object) s슈트번호, (object) str6, (object) str7, (object) str3, (object) str13);
              break;
            case "반품유형1":
              string empty7;
              string empty8;
              string empty9;
              string empty10;
              string empty11;
              string empty12;
              switch (count)
              {
                case 1:
                  empty7 = oDataTable.Rows[0]["대표바코드"].ToString();
                  empty8 = string.Empty;
                  empty9 = string.Empty;
                  empty10 = oDataTable.Rows[0]["수량"].ToString();
                  empty11 = string.Empty;
                  empty12 = string.Empty;
                  break;
                case 2:
                  empty7 = oDataTable.Rows[0]["대표바코드"].ToString();
                  empty8 = oDataTable.Rows[1]["대표바코드"].ToString();
                  empty9 = string.Empty;
                  empty10 = oDataTable.Rows[0]["수량"].ToString();
                  empty11 = oDataTable.Rows[1]["수량"].ToString();
                  empty12 = string.Empty;
                  break;
                case 3:
                  empty7 = oDataTable.Rows[0]["대표바코드"].ToString();
                  empty8 = oDataTable.Rows[1]["대표바코드"].ToString();
                  empty9 = oDataTable.Rows[2]["대표바코드"].ToString();
                  empty10 = oDataTable.Rows[0]["수량"].ToString();
                  empty11 = oDataTable.Rows[1]["수량"].ToString();
                  empty12 = oDataTable.Rows[2]["수량"].ToString();
                  break;
                default:
                  empty7 = string.Empty;
                  empty8 = string.Empty;
                  empty9 = string.Empty;
                  empty10 = string.Empty;
                  empty11 = string.Empty;
                  empty12 = string.Empty;
                  break;
              }
              str14 = string.Format(printScript, (object) $"{str9}:{str12}", (object) str11, (object) str3, (object) str4, (object) s슈트번호, (object) str6, (object) str7, (object) empty7, (object) empty10, (object) empty8, (object) empty11, (object) empty9, (object) empty12, (object) str13);
              break;
            case "반품유형2":
              str14 = string.Format(printScript, (object) $"{str9}:{str12}", (object) str3, (object) str4, (object) str11, (object) s슈트번호, (object) str6, (object) str7, (object) num.ToString(), (object) str13);
              break;
            default:
              str14 = string.Format(printScript, (object) str5, (object) s슈트번호, (object) str7, (object) str3);
              break;
          }
          if (!string.IsNullOrEmpty(str14))
          {
            string printerName = Common.GetPrinterName(s슈트번호);
            tcpClient1?.Close();
            TcpClient tcpClient2 = new TcpClient();
            tcpClient2.Connect(printerName, 9100);
            if (tcpClient2.Connected)
            {
              using (StreamWriter streamWriter = new StreamWriter((Stream) tcpClient2.GetStream(), Encoding.GetEncoding(949)))
              {
                streamWriter.Write(str14);
                streamWriter.Flush();
                streamWriter.Close();
              }
            }
          }
          Thread.Sleep(300);
        }
      }
      dbProvider2.Commit();
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.button1 = new Button();
    this.button2 = new Button();
    this.button3 = new Button();
    this.button4 = new Button();
    this.button5 = new Button();
    this.button6 = new Button();
    this.button7 = new Button();
    this.button8 = new Button();
    this.button9 = new Button();
    this.comboBox1 = new ComboBox();
    this.textBox1 = new TextBox();
    this.textBox2 = new TextBox();
    this.textBox3 = new TextBox();
    this.pasPanel1 = new PasPanel();
    this.닫기버튼 = new RButton();
    this.button10 = new Button();
    this.pasPanel1.SuspendLayout();
    this.SuspendLayout();
    this.button1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button1.ForeColor = Color.DimGray;
    this.button1.Location = new Point(41, 65);
    this.button1.Name = "button1";
    this.button1.Size = new Size(305, 34);
    this.button1.TabIndex = 3;
    this.button1.Text = "EXECBAT";
    this.button1.UseVisualStyleBackColor = true;
    this.button1.Click += new EventHandler(this.button1_Click);
    this.button2.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button2.ForeColor = Color.DimGray;
    this.button2.Location = new Point(41, 105);
    this.button2.Name = "button2";
    this.button2.Size = new Size(305, 34);
    this.button2.TabIndex = 4;
    this.button2.Text = "SORT_Q";
    this.button2.UseVisualStyleBackColor = true;
    this.button2.Click += new EventHandler(this.button2_Click);
    this.button3.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button3.ForeColor = Color.DimGray;
    this.button3.Location = new Point(41, 145);
    this.button3.Name = "button3";
    this.button3.Size = new Size(305, 34);
    this.button3.TabIndex = 5;
    this.button3.Text = "CHUTE";
    this.button3.UseVisualStyleBackColor = true;
    this.button3.Click += new EventHandler(this.button3_Click);
    this.button4.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button4.ForeColor = Color.DimGray;
    this.button4.Location = new Point(41, 225);
    this.button4.Name = "button4";
    this.button4.Size = new Size(305, 34);
    this.button4.TabIndex = 6;
    this.button4.Text = "REBUILD - 추가배치용 (+1)";
    this.button4.UseVisualStyleBackColor = true;
    this.button4.Click += new EventHandler(this.button4_Click);
    this.button5.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button5.ForeColor = Color.DimGray;
    this.button5.Location = new Point(41, 305);
    this.button5.Name = "button5";
    this.button5.Size = new Size(305, 34);
    this.button5.TabIndex = 7;
    this.button5.Text = "REBUILD - 개별슈트종료용";
    this.button5.UseVisualStyleBackColor = true;
    this.button5.Click += new EventHandler(this.button5_Click);
    this.button6.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button6.ForeColor = Color.DimGray;
    this.button6.Location = new Point(41, 265);
    this.button6.Name = "button6";
    this.button6.Size = new Size(305, 34);
    this.button6.TabIndex = 8;
    this.button6.Text = "REBUILD - 추가배치용 (+2)";
    this.button6.UseVisualStyleBackColor = true;
    this.button6.Click += new EventHandler(this.button6_Click);
    this.button7.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button7.ForeColor = Color.DimGray;
    this.button7.Location = new Point(41, 185);
    this.button7.Name = "button7";
    this.button7.Size = new Size(305, 34);
    this.button7.TabIndex = 9;
    this.button7.Text = "나머지 생성";
    this.button7.UseVisualStyleBackColor = true;
    this.button7.Click += new EventHandler(this.button7_Click);
    this.button8.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button8.ForeColor = Color.DimGray;
    this.button8.Location = new Point(41, 345);
    this.button8.Name = "button8";
    this.button8.Size = new Size(305, 34);
    this.button8.TabIndex = 10;
    this.button8.Text = "REBUILD - PARSING";
    this.button8.UseVisualStyleBackColor = true;
    this.button8.Click += new EventHandler(this.button8_Click);
    this.button9.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button9.ForeColor = Color.DimGray;
    this.button9.Location = new Point(683, 103);
    this.button9.Name = "button9";
    this.button9.Size = new Size(305, 34);
    this.button9.TabIndex = 11;
    this.button9.Text = "슈트 개별 종료 확인";
    this.button9.UseVisualStyleBackColor = true;
    this.button9.Click += new EventHandler(this.button9_Click);
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.Font = new Font("굴림", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(683, 65);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(80 /*0x50*/, 32 /*0x20*/);
    this.comboBox1.TabIndex = 12;
    this.textBox1.Font = new Font("굴림", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    this.textBox1.Location = new Point(769, 65);
    this.textBox1.Name = "textBox1";
    this.textBox1.Size = new Size(100, 32 /*0x20*/);
    this.textBox1.TabIndex = 13;
    this.textBox1.Text = "0612";
    this.textBox2.Font = new Font("굴림", 15.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    this.textBox2.Location = new Point(875, 65);
    this.textBox2.Name = "textBox2";
    this.textBox2.Size = new Size(113, 32 /*0x20*/);
    this.textBox2.TabIndex = 14;
    this.textBox2.Text = "S1661201";
    this.textBox3.Location = new Point(41, 385);
    this.textBox3.Multiline = true;
    this.textBox3.Name = "textBox3";
    this.textBox3.ScrollBars = ScrollBars.Vertical;
    this.textBox3.Size = new Size(305, 213);
    this.textBox3.TabIndex = 15;
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 2;
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(898, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 0;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.button10.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.button10.ForeColor = Color.DimGray;
    this.button10.Location = new Point(683, 185);
    this.button10.Name = "button10";
    this.button10.Size = new Size(305, 34);
    this.button10.TabIndex = 16 /*0x10*/;
    this.button10.Text = "박스풀 테스트 - TASK";
    this.button10.UseVisualStyleBackColor = true;
    this.button10.Click += new EventHandler(this.button10_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.button10);
    this.Controls.Add((System.Windows.Forms.Control) this.textBox3);
    this.Controls.Add((System.Windows.Forms.Control) this.textBox2);
    this.Controls.Add((System.Windows.Forms.Control) this.textBox1);
    this.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.Controls.Add((System.Windows.Forms.Control) this.button9);
    this.Controls.Add((System.Windows.Forms.Control) this.button8);
    this.Controls.Add((System.Windows.Forms.Control) this.button7);
    this.Controls.Add((System.Windows.Forms.Control) this.button6);
    this.Controls.Add((System.Windows.Forms.Control) this.button5);
    this.Controls.Add((System.Windows.Forms.Control) this.button4);
    this.Controls.Add((System.Windows.Forms.Control) this.button3);
    this.Controls.Add((System.Windows.Forms.Control) this.button2);
    this.Controls.Add((System.Windows.Forms.Control) this.button1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00010T);
    this.Text = "frmPAS00010";
    this.pasPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
