// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00023
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using CrystalDecisions.Windows.Forms;
using NetHelper.Control;
using pas.ff;
// using pas.mgp.Properties;
// using pas.mgp.Report;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00023 : Form
{
  private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
  private DataTable m_분류_박스바코드재발행Table = new DataTable("usp_분류_박스바코드재발행_Get");
  private DataTable m_분류_박스바코드재발행_슈트별Table = new DataTable("usp_분류_박스바코드재발행_슈트별_Get");
  private DataTable m_분류_박스바코드재발행_슈트별상세Table = new DataTable("usp_분류_박스바코드재발행_슈트별상세_Get");
  private DataTable m_분류_박스별패킹내역Table = new DataTable("usp_분류_박스별패킹내역_Get");
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Panel panel1;
  private RGrid rGrid1;
  private RButton 조회버튼;
  private Panel panel3;
  private RGrid rGrid2;
  private RGrid rGrid3;
  private Splitter splitter1;
  private Panel panel2;
  private RGrid rGrid4;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel1;
  private RButton 재발행버튼;
  private RadioButton radioButton2;
  private RadioButton radioButton1;
  private RLabel rLabel2;

  private string 배치구분 { get; set; }

  public frmPAS00023()
  {
    this.InitializeComponent();
    this.Text = "박스 재발행";
    this.BackColor = Color.White;
    this.splitter1.BackColor = Common.SPLITTER_COLOR;
    this.rLabel1.Control = (System.Windows.Forms.Control) this.dateTimePicker1;
    this.radioButton1.Checked = true;
    this.radioButton1.ForeColor = Color.DimGray;
    this.radioButton2.Checked = false;
    this.radioButton2.ForeColor = Color.DimGray;
    Common.RGrid_Initializing(this.rGrid1, true);
    Common.RGrid_Initializing(this.rGrid2, true);
    Common.RGrid_Initializing(this.rGrid3, true);
    Common.RGrid_Initializing(this.rGrid4, true);
  }

  private void frmPAS00023_Load(object sender, EventArgs e)
  {
    this.분류_작업요약_조회(조회구분자.가조회);
    this.분류_박스바코드재발행_조회(string.Empty, string.Empty, 조회구분자.가조회);
    this.분류_박스바코드재발행_슈트별_조회(string.Empty, string.Empty, string.Empty, string.Empty, 조회구분자.가조회);
    this.분류_박스바코드재발행_슈트별상세_조회(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 조회구분자.가조회);
  }

  private void 분류_작업요약_조회(조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_작업요약_배치그룹별Table, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "모두", ParameterDirection.Input), DbProvider.GetParameter("@작업일자", (object) this.dateTimePicker1.Value.ToString("yyyyMMdd"), ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid1.DataSource2 = (object) this.m_분류_작업요약_배치그룹별Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid1.Columns)
    {
      switch (column.HeaderText)
      {
        case "분류구분":
        case "패턴구분":
        case "분류상태":
        case "완료일시":
        case "선택":
        case "순번":
        case "관리번호":
        case "장비명":
        case "배치구분코드":
        case "출하구분코드":
        case "분류구분코드":
        case "분류방법코드":
        case "패턴구분코드":
        case "분류상태코드":
        case "배치상태코드":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          continue;
      }
    }
  }

  private void 분류_박스바코드재발행_조회(string s분류번호, string s배치번호, 조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_박스바코드재발행Table, DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid2.DataSource2 = (object) this.m_분류_박스바코드재발행Table;
    this.rGrid2.SetSummaries(new DataGridViewSummary("내품수", SummaryType.합계));
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid2.Columns)
    {
      switch (column.HeaderText)
      {
        case "분류번호":
        case "배치번호":
        case "서브슈트번호":
        case "배치구분":
        case "출력여부":
        case "배치구분코드":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          continue;
      }
    }
  }

  private void 분류_박스바코드재발행_슈트별_조회(
    string s분류번호,
    string s배치번호,
    string s슈트번호,
    string s서브슈트번호,
    조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_박스바코드재발행_슈트별Table, DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) s슈트번호, ParameterDirection.Input), DbProvider.GetParameter("@서브슈트번호", (object) s서브슈트번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid3.DataSource2 = (object) this.m_분류_박스바코드재발행_슈트별Table;
    this.rGrid3.SetSummaries(new DataGridViewSummary("내품수", SummaryType.합계));
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid3.Columns)
    {
      switch (column.HeaderText)
      {
        case "분류번호":
        case "배치번호":
        case "슈트번호":
        case "서브슈트번호":
        case "박스바코드":
        case "박스바코드구분":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          continue;
      }
    }
  }

  private void 분류_박스바코드재발행_슈트별상세_조회(
    string s분류번호,
    string s배치번호,
    string s슈트번호,
    string s서브슈트번호,
    string s박스번호,
    조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_박스바코드재발행_슈트별상세Table, DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) s슈트번호, ParameterDirection.Input), DbProvider.GetParameter("@서브슈트번호", (object) s서브슈트번호, ParameterDirection.Input), DbProvider.GetParameter("@박스번호", (object) s박스번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid4.DataSource2 = (object) this.m_분류_박스바코드재발행_슈트별상세Table;
    this.rGrid4.SetSummaries(new DataGridViewSummary("실적수", SummaryType.합계));
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid4.Columns)
    {
      switch (column.HeaderText)
      {
        case "아이템코드":
        case "브랜드코드":
        case "브랜드명":
        case "센터코드":
        case "센터명":
        case "배치명":
        case "IDX":
        case "조정":
        case "잔여":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          continue;
      }
    }
  }

  private void 조회버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      this.배치구분 = string.Empty;
      this.분류_작업요약_조회(조회구분자.실조회);
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
      {
        empty1 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["분류번호"].ToString();
        empty2 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();
      }
      this.분류_박스바코드재발행_조회(empty1, empty2, 조회구분자.실조회);
      if (this.m_분류_박스바코드재발행Table.Rows.Count > 1)
      {
        empty3 = this.m_분류_박스바코드재발행Table.Rows[1]["슈트번호"].ToString();
        empty4 = this.m_분류_박스바코드재발행Table.Rows[1]["서브슈트번호"].ToString();
        this.배치구분 = this.m_분류_박스바코드재발행Table.Rows[1]["배치구분"].ToString();
      }
      this.분류_박스바코드재발행_슈트별_조회(empty1, empty2, empty3, empty4, 조회구분자.실조회);
      if (this.m_분류_박스바코드재발행_슈트별Table.Rows.Count > 1)
        empty5 = this.m_분류_박스바코드재발행_슈트별Table.Rows[1]["박스번호"].ToString();
      this.분류_박스바코드재발행_슈트별상세_조회(empty1, empty2, empty3, empty4, empty5, 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.Close();

  private void rGrid1_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridView.HitTestInfo hitTestInfo = this.rGrid1.HitTest(e.X, e.Y);
      if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0)
        return;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string s분류번호 = this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString();
      string s배치번호 = this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString();
      this.분류_박스바코드재발행_조회(s분류번호, s배치번호, 조회구분자.실조회);
      if (this.m_분류_박스바코드재발행Table.Rows.Count > 1)
      {
        empty3 = this.m_분류_박스바코드재발행Table.Rows[1]["슈트번호"].ToString();
        empty4 = this.m_분류_박스바코드재발행Table.Rows[1]["서브슈트번호"].ToString();
      }
      this.분류_박스바코드재발행_슈트별_조회(s분류번호, s배치번호, empty3, empty4, 조회구분자.실조회);
      if (this.m_분류_박스바코드재발행_슈트별Table.Rows.Count > 1)
        empty5 = this.m_분류_박스바코드재발행_슈트별Table.Rows[1]["박스번호"].ToString();
      this.분류_박스바코드재발행_슈트별상세_조회(s분류번호, s배치번호, empty3, empty4, empty5, 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void rGrid2_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridView.HitTestInfo hitTestInfo = this.rGrid2.HitTest(e.X, e.Y);
      if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0)
        return;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string s분류번호 = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString();
      string s배치번호 = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString();
      string s슈트번호 = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["슈트번호"].Value.ToString();
      string s서브슈트번호 = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["서브슈트번호"].Value.ToString();
      this.배치구분 = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["배치구분"].Value.ToString();
      this.분류_박스바코드재발행_슈트별_조회(s분류번호, s배치번호, s슈트번호, s서브슈트번호, 조회구분자.실조회);
      if (this.m_분류_박스바코드재발행_슈트별Table.Rows.Count > 1)
        empty5 = this.m_분류_박스바코드재발행_슈트별Table.Rows[1]["박스번호"].ToString();
      this.분류_박스바코드재발행_슈트별상세_조회(s분류번호, s배치번호, s슈트번호, s서브슈트번호, empty5, 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void rGrid3_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridView.HitTestInfo hitTestInfo = this.rGrid3.HitTest(e.X, e.Y);
      if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0)
        return;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      this.분류_박스바코드재발행_슈트별상세_조회(this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString(), this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString(), this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["슈트번호"].Value.ToString(), this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["서브슈트번호"].Value.ToString(), this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["박스번호"].Value.ToString(), 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void 재발행버튼_Click(object sender, EventArgs e)
  {
    TcpClient oClient = (TcpClient) null;
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    string empty3 = string.Empty;
    string empty4 = string.Empty;
    string empty5 = string.Empty;
    string empty6 = string.Empty;
    string empty7 = string.Empty;
    string empty8 = string.Empty;
    string empty9 = string.Empty;
    string empty10 = string.Empty;
    string empty11 = string.Empty;
    string str1 = DateTime.Now.ToString("yyyy-MM-dd");
    string empty12 = string.Empty;
    string empty13 = string.Empty;
    string empty14 = string.Empty;
    string empty15 = string.Empty;
    string empty16 = string.Empty;
    string empty17 = string.Empty;
    string empty18 = string.Empty;
    if (this.rGrid1.SelectedRows == null || this.rGrid1.SelectedRows.Count <= 0)
      Common.ErrorMessageBox("배치를 선택해 주세요.");
    else if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
      Common.ErrorMessageBox("슈트를 선택해 주세요.");
    else if (this.rGrid3.SelectedRows == null || this.rGrid3.SelectedRows.Count <= 0)
      Common.ErrorMessageBox("박스번호를 선택해 주세요.");
    else if (this.배치구분 == "멀티반품")
    {
      Common.ErrorMessageBox("선택한 슈트는 테블릿 분류 대상입니다.\r\n\r\n테블릿 서버에서 재발행해 주세요.");
    }
    else
    {
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        string str2 = this.rGrid1.SelectedRows[0].Cells["배치번호"].Value.ToString();
        string s패턴구분 = this.rGrid1.SelectedRows[0].Cells["패턴구분"].Value.ToString();
        string s슈트번호 = this.rGrid2.SelectedRows[0].Cells["슈트번호"].Value.ToString();
        string str3 = this.rGrid2.SelectedRows[0].Cells["점코드"].Value.ToString();
        string str4 = this.rGrid2.SelectedRows[0].Cells["점명"].Value.ToString();
        string s배치구분 = this.rGrid2.SelectedRows[0].Cells["배치구분"].Value.ToString();
        string str5 = this.rGrid2.SelectedRows[0].Cells["출력여부"].Value.ToString();
        string s박스바코드 = this.rGrid3.SelectedRows[0].Cells["박스바코드"].Value.ToString();
        string s박스바코드구분 = this.rGrid3.SelectedRows[0].Cells["박스바코드구분"].Value.ToString();
        string str6 = this.rGrid3.SelectedRows[0].Cells["박스번호"].Value.ToString();
        string str7 = this.rGrid3.SelectedRows[0].Cells["내품수"].Value.ToString();
        int i박스풀대상수 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows.Count - 1;
        string empty19;
        string empty20;
        string empty21;
        if (i박스풀대상수 > 0)
        {
          empty19 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["브랜드코드"].ToString();
          empty20 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["브랜드명"].ToString();
          empty21 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["배치명"].ToString();
        }
        else
        {
          empty19 = string.Empty;
          empty20 = string.Empty;
          empty21 = string.Empty;
        }
        switch (s배치구분)
        {
          case "패키지":
            string printerName1 = Common.GetPrinterName("패키지");
            DataTable oDataTable = this.m_분류_박스바코드재발행_슈트별상세Table.Copy();
            oDataTable.Rows.RemoveAt(0);
            oDataTable.AcceptChanges();
            Common.GetPrintScript2(printerName1, s박스바코드, s박스바코드구분, oClient, oDataTable);
            return;
          case "반품":
          case "멀티반품":
            s패턴구분 = i박스풀대상수 <= 2 ? "반품유형1" : "반품유형2";
            break;
        }
        if (string.IsNullOrEmpty(str7) || !(str7 != "0") || !(str5 == "1"))
          return;
        string printScript = Common.GetPrintScript(s패턴구분, s배치구분, i박스풀대상수);
        string str8;
        switch (s패턴구분)
        {
          case "사용안함":
            str8 = string.Empty;
            break;
          case "출고유형":
            str8 = string.Format(printScript, (object) $"{empty19}:{empty20}", (object) str4, (object) s슈트번호, (object) str6, (object) str7, (object) s박스바코드, (object) str1);
            break;
          case "반품유형1":
            string empty22;
            string empty23;
            string empty24;
            string empty25;
            switch (i박스풀대상수)
            {
              case 1:
                empty22 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["대표바코드"].ToString();
                empty23 = string.Empty;
                empty24 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["수량"].ToString();
                empty25 = string.Empty;
                break;
              case 2:
                empty22 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["대표바코드"].ToString();
                empty23 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[2]["대표바코드"].ToString();
                empty24 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[1]["수량"].ToString();
                empty25 = this.m_분류_박스바코드재발행_슈트별상세Table.Rows[2]["수량"].ToString();
                break;
              default:
                empty22 = string.Empty;
                empty23 = string.Empty;
                empty24 = string.Empty;
                empty25 = string.Empty;
                break;
            }
            str8 = string.Format(printScript, (object) $"{empty19}:{empty21}", (object) str2, (object) s박스바코드, (object) s박스바코드구분, (object) s슈트번호, (object) str6, (object) str7, (object) empty22, (object) empty24, (object) empty23, (object) empty25, (object) str1);
            break;
          case "반품유형2":
            str8 = string.Format(printScript, (object) $"{empty19}:{empty21}", (object) s박스바코드, (object) s박스바코드구분, (object) str2, (object) s슈트번호, (object) str6, (object) str7, (object) i박스풀대상수.ToString(), (object) str1);
            break;
          default:
            str8 = string.Format(printScript, (object) str4, (object) s슈트번호, (object) str7, (object) s박스바코드);
            break;
        }
        string printerName2 = Common.GetPrinterName(s슈트번호);
        TcpClient tcpClient1;
        if (oClient != null)
        {
          oClient.Close();
          tcpClient1 = (TcpClient) null;
        }
        TcpClient tcpClient2 = new TcpClient();
        tcpClient2.Connect(printerName2, 9100);
        using (StreamWriter streamWriter = new StreamWriter((Stream) tcpClient2.GetStream(), Encoding.GetEncoding(949)))
        {
          streamWriter.Write(str8);
          streamWriter.Flush();
          streamWriter.Close();
        }
        Thread.Sleep(300);
        if (tcpClient2 != null)
        {
          tcpClient2.Close();
          tcpClient1 = (TcpClient) null;
        }
        string oValue = $"[재발행] {str2},{s슈트번호},{str3},{str6},{s박스바코드}";
        DbProvider.Excute(Common.ConnectionString(), "usp_기록_로그_Set", DbProvider.GetParameter("@TEXT", (object) oValue));
      }
      catch (Exception ex)
      {
        Common.ErrorMessageBox(ex.Message);
      }
      finally
      {
        Cursor.Current = Cursors.Default;
        this.조회버튼_Click((object) null, EventArgs.Empty);
      }
    }
  }

  public void Save()
  {
    Cursor.Current = Cursors.WaitCursor;
    string fileName = string.Empty;
    try
    {
      if (this.rGrid1.SelectedRows == null || this.rGrid1.SelectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("저장할 배치를 선택하세요.");
      }
      else
      {
        string oValue1 = this.rGrid1.SelectedRows[0].Cells["분류번호"].Value.ToString();
        string oValue2 = this.rGrid1.SelectedRows[0].Cells["배치번호"].Value.ToString();
        string oValue3 = string.Empty;
        if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
        {
          if (this.radioButton1.Checked)
            oValue3 = string.Empty;
          else if (this.rGrid2.Rows.Count > 0)
          {
            Common.ErrorMessageBox("슈트번호를 선택하세요.");
            return;
          }
        }
        else
          oValue3 = !this.radioButton1.Checked ? this.rGrid2.SelectedRows[0].Cells["슈트번호"].Value.ToString() : string.Empty;
        DbProvider.Select(Common.ConnectionString(), this.m_분류_박스별패킹내역Table, DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) oValue3, ParameterDirection.Input));
        if (this.m_분류_박스별패킹내역Table.Rows.Count <= 0)
          Common.ErrorMessageBox("저장할 대상이 없습니다.");
        else
          fileName = new Excel().Export(this.m_분류_박스별패킹내역Table);
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      if (string.IsNullOrEmpty(fileName))
        Common.ErrorMessageBox("엑셀 작성이 취소되었습니다.");
      else
        Process.Start(fileName);
      Cursor.Current = Cursors.Default;
    }
  }

  public void Print()
  {
    Cursor.Current = Cursors.WaitCursor;
    try
    {
      if (this.rGrid1.SelectedRows == null || this.rGrid1.SelectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("출력할 배치를 선택하세요.");
      }
      else
      {
        string oValue1 = this.rGrid1.SelectedRows[0].Cells["분류번호"].Value.ToString();
        string oValue2 = this.rGrid1.SelectedRows[0].Cells["배치번호"].Value.ToString();
        string oValue3 = string.Empty;
        if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
        {
          if (this.radioButton1.Checked)
            oValue3 = string.Empty;
          else if (this.rGrid2.Rows.Count > 0)
          {
            Common.ErrorMessageBox("슈트번호를 선택하세요.");
            return;
          }
        }
        else
          oValue3 = !this.radioButton1.Checked ? this.rGrid2.SelectedRows[0].Cells["슈트번호"].Value.ToString() : string.Empty;
        DbProvider.Select(Common.ConnectionString(), this.m_분류_박스별패킹내역Table, DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@슈트번호", (object) oValue3, ParameterDirection.Input));
        if (this.m_분류_박스별패킹내역Table == null || this.m_분류_박스별패킹내역Table.Rows.Count <= 0)
        {
          Common.ErrorMessageBox("출력할 대상이 없습니다.");
        }
        else
        {
          string val = $"{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_박스별패킹내역Table.Rows[0]["브랜드명"].ToString()}";
          패킹내역_박스별 패킹내역박스별 = new 패킹내역_박스별();
          패킹내역박스별.SetDataSource(this.m_분류_박스별패킹내역Table);
          패킹내역박스별.SetParameterValue("로컬장비명", (object) Common.Setting.NAME);
          패킹내역박스별.SetParameterValue("브랜드명", (object) val);
          Form form = new Form();
          form.Text = "인쇄 미리보기";
          form.StartPosition = FormStartPosition.CenterParent;
          form.Size = new Size(1024 /*0x0400*/, 768 /*0x0300*/);
          CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
          crystalReportViewer.ReportSource = (object) 패킹내역박스별;
          crystalReportViewer.ShowCloseButton = false;
          crystalReportViewer.ShowCopyButton = false;
          crystalReportViewer.ShowExportButton = false;
          crystalReportViewer.ShowGroupTreeButton = false;
          crystalReportViewer.ShowLogo = false;
          crystalReportViewer.ShowParameterPanelButton = false;
          crystalReportViewer.ShowRefreshButton = false;
          crystalReportViewer.ShowTextSearchButton = false;
          crystalReportViewer.ToolPanelView = ToolPanelViewType.None;
          crystalReportViewer.Dock = DockStyle.Fill;
          form.Controls.Add((System.Windows.Forms.Control) crystalReportViewer);
          int num = (int) form.ShowDialog();
        }
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
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
    DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.panel3 = new Panel();
    this.rGrid2 = new RGrid();
    this.rGrid3 = new RGrid();
    this.splitter1 = new Splitter();
    this.pasPanel1 = new PasPanel();
    this.radioButton2 = new RadioButton();
    this.radioButton1 = new RadioButton();
    this.rLabel2 = new RLabel();
    this.재발행버튼 = new RButton();
    this.dateTimePicker1 = new DateTimePicker();
    this.rLabel1 = new RLabel();
    this.조회버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.panel2 = new Panel();
    this.rGrid4 = new RGrid();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.panel3.SuspendLayout();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    ((ISupportInitialize) this.rGrid3).BeginInit();
    this.pasPanel1.SuspendLayout();
    this.panel2.SuspendLayout();
    ((ISupportInitialize) this.rGrid4).BeginInit();
    this.SuspendLayout();
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel1.Dock = DockStyle.Top;
    this.panel1.Location = new Point(0, 45);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(1000, 150);
    this.panel1.TabIndex = 4;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid1.BackgroundColor = Color.White;
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Control;
    gridViewCellStyle1.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle1.ForeColor = SystemColors.WindowText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    this.rGrid1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
    this.rGrid1.DataSource2 = (object) null;
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle2.BackColor = SystemColors.Window;
    gridViewCellStyle2.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle2.ForeColor = SystemColors.ControlText;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid1.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid1.Location = new Point(6, 6);
    this.rGrid1.Name = "rGrid1";
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle3.BackColor = SystemColors.Control;
    gridViewCellStyle3.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle3.ForeColor = SystemColors.WindowText;
    gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle3.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    this.rGrid1.RowHeadersDefaultCellStyle = gridViewCellStyle3;
    this.rGrid1.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid1.Size = new Size(988, 137);
    this.rGrid1.TabIndex = 2;
    this.rGrid1.MouseUp += new MouseEventHandler(this.rGrid1_MouseUp);
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rGrid3);
    this.panel3.Dock = DockStyle.Left;
    this.panel3.Location = new Point(0, 195);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(518, 415);
    this.panel3.TabIndex = 6;
    this.rGrid2.AllowUserToAddRows = false;
    this.rGrid2.AllowUserToDeleteRows = false;
    this.rGrid2.AlternateColor = Color.Empty;
    this.rGrid2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid2.BackgroundColor = Color.White;
    gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle4.BackColor = SystemColors.Control;
    gridViewCellStyle4.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle4.ForeColor = SystemColors.WindowText;
    gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
    this.rGrid2.ColumnHeadersDefaultCellStyle = gridViewCellStyle4;
    this.rGrid2.DataSource2 = (object) null;
    gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle5.BackColor = SystemColors.Window;
    gridViewCellStyle5.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle5.ForeColor = SystemColors.ControlText;
    gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle5.WrapMode = DataGridViewTriState.False;
    this.rGrid2.DefaultCellStyle = gridViewCellStyle5;
    this.rGrid2.Location = new Point(6, 6);
    this.rGrid2.Name = "rGrid2";
    gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle6.BackColor = SystemColors.Control;
    gridViewCellStyle6.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle6.ForeColor = SystemColors.WindowText;
    gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle6.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
    this.rGrid2.RowHeadersDefaultCellStyle = gridViewCellStyle6;
    this.rGrid2.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid2.Size = new Size(300, 397);
    this.rGrid2.TabIndex = 3;
    this.rGrid2.MouseUp += new MouseEventHandler(this.rGrid2_MouseUp);
    this.rGrid3.AllowUserToAddRows = false;
    this.rGrid3.AllowUserToDeleteRows = false;
    this.rGrid3.AlternateColor = Color.Empty;
    this.rGrid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
    this.rGrid3.BackgroundColor = Color.White;
    gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle7.BackColor = SystemColors.Control;
    gridViewCellStyle7.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle7.ForeColor = SystemColors.WindowText;
    gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
    this.rGrid3.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
    this.rGrid3.DataSource2 = (object) null;
    gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle8.BackColor = SystemColors.Window;
    gridViewCellStyle8.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle8.ForeColor = SystemColors.ControlText;
    gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
    this.rGrid3.DefaultCellStyle = gridViewCellStyle8;
    this.rGrid3.Location = new Point(312, 6);
    this.rGrid3.Name = "rGrid3";
    gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle9.BackColor = SystemColors.Control;
    gridViewCellStyle9.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle9.ForeColor = SystemColors.WindowText;
    gridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle9.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
    this.rGrid3.RowHeadersDefaultCellStyle = gridViewCellStyle9;
    this.rGrid3.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid3.Size = new Size(200, 397);
    this.rGrid3.TabIndex = 4;
    this.rGrid3.MouseUp += new MouseEventHandler(this.rGrid3_MouseUp);
    this.splitter1.Location = new Point(518, 195);
    this.splitter1.Name = "splitter1";
    this.splitter1.Size = new Size(3, 415);
    this.splitter1.TabIndex = 7;
    this.splitter1.TabStop = false;
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.radioButton2);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.radioButton1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.재발행버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 2;
    this.radioButton2.AutoSize = true;
    this.radioButton2.Location = new Point(322, 14);
    this.radioButton2.Name = "radioButton2";
    this.radioButton2.Size = new Size(87, 16 /*0x10*/);
    this.radioButton2.TabIndex = 18;
    this.radioButton2.TabStop = true;
    this.radioButton2.Text = "선택한 것만";
    this.radioButton2.UseVisualStyleBackColor = true;
    this.radioButton1.AutoSize = true;
    this.radioButton1.Location = new Point(269, 14);
    this.radioButton1.Name = "radioButton1";
    this.radioButton1.Size = new Size(47, 16 /*0x10*/);
    this.radioButton1.TabIndex = 17;
    this.radioButton1.TabStop = true;
    this.radioButton1.Text = "전체";
    this.radioButton1.UseVisualStyleBackColor = true;
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(194, 11);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(80 /*0x50*/, 23);
    this.rLabel2.TabIndex = 16 /*0x10*/;
    this.rLabel2.Text = "출력대상";
    this.재발행버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.재발행버튼.ButtonState = RButtonState.None;
    this.재발행버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.재발행버튼.ForeColor = Color.DimGray;
    this.재발행버튼.Image = (Image) pas.mgp.Properties.Resources._1397196762_stock_id;
    this.재발행버튼.Location = new Point(797, 11);
    this.재발행버튼.Name = "재발행버튼";
    this.재발행버튼.Size = new Size(100, 23);
    this.재발행버튼.TabIndex = 13;
    this.재발행버튼.Text = "재발행";
    this.재발행버튼.UseVisualStyleBackColor = true;
    this.재발행버튼.Click += new EventHandler(this.재발행버튼_Click);
    this.dateTimePicker1.Format = DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new Point(88, 12);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new Size(100, 21);
    this.dateTimePicker1.TabIndex = 12;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(12, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(80 /*0x50*/, 23);
    this.rLabel1.TabIndex = 11;
    this.rLabel1.Text = "작업일자";
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(706, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 1;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
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
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.rGrid4);
    this.panel2.Dock = DockStyle.Fill;
    this.panel2.Location = new Point(521, 195);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(479, 415);
    this.panel2.TabIndex = 8;
    this.rGrid4.AllowUserToAddRows = false;
    this.rGrid4.AllowUserToDeleteRows = false;
    this.rGrid4.AlternateColor = Color.Empty;
    this.rGrid4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid4.BackgroundColor = Color.White;
    gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle10.BackColor = SystemColors.Control;
    gridViewCellStyle10.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle10.ForeColor = SystemColors.WindowText;
    gridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle10.WrapMode = DataGridViewTriState.True;
    this.rGrid4.ColumnHeadersDefaultCellStyle = gridViewCellStyle10;
    this.rGrid4.DataSource2 = (object) null;
    gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle11.BackColor = SystemColors.Window;
    gridViewCellStyle11.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle11.ForeColor = SystemColors.ControlText;
    gridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle11.WrapMode = DataGridViewTriState.False;
    this.rGrid4.DefaultCellStyle = gridViewCellStyle11;
    this.rGrid4.Location = new Point(6, 6);
    this.rGrid4.Name = "rGrid4";
    gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle12.BackColor = SystemColors.Control;
    gridViewCellStyle12.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle12.ForeColor = SystemColors.WindowText;
    gridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle12.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle12.WrapMode = DataGridViewTriState.True;
    this.rGrid4.RowHeadersDefaultCellStyle = gridViewCellStyle12;
    this.rGrid4.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid4.Size = new Size(467, 397);
    this.rGrid4.TabIndex = 9;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.panel2);
    this.Controls.Add((System.Windows.Forms.Control) this.splitter1);
    this.Controls.Add((System.Windows.Forms.Control) this.panel3);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00023);
    this.Text = "frmPAS00021";
    this.Load += new EventHandler(this.frmPAS00023_Load);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.panel3.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid2).EndInit();
    ((ISupportInitialize) this.rGrid3).EndInit();
    this.pasPanel1.ResumeLayout(false);
    this.pasPanel1.PerformLayout();
    this.panel2.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid4).EndInit();
    this.ResumeLayout(false);
  }
}
