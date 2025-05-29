// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00025
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using CrystalDecisions.Windows.Forms;
using NetHelper.Control;
using pas.ff;
// using pas.mgp.Properties;
// using pas.mgp.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00025 : Form
{
  private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
  private DataTable m_분류_상품발송장대상Table = new DataTable("usp_분류_상품발송장_Get");
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Panel panel1;
  private RGrid rGrid1;
  private RButton 조회버튼;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel1;
  private TabControl tabControl1;
  private TabPage tabPage1;
  private TabPage tabPage2;

  public frmPAS00025()
  {
    this.InitializeComponent();
    this.Text = "매장별 박스 현황";
    this.BackColor = Color.White;
    this.tabControl1.TabPages.Clear();
    Common.RGrid_Initializing(this.rGrid1, true);
    this.rLabel1.Control = (System.Windows.Forms.Control) this.dateTimePicker1;
  }

  private void frmPAS00025_Load(object sender, EventArgs e)
  {
    this.분류_작업요약_조회(조회구분자.가조회);
    this.분류_상품발송장_조회(string.Empty, string.Empty, 조회구분자.가조회);
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

  private DataTable 분류_상품발송장_배송사별(string s배송사명, DataTable oDataTable)
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("점코드", typeof (string));
    dataTable.Columns.Add("점명", typeof (string));
    dataTable.Columns.Add("01", typeof (string));
    dataTable.Columns.Add("02", typeof (string));
    dataTable.Columns.Add("03", typeof (string));
    dataTable.Columns.Add("04", typeof (string));
    dataTable.Columns.Add("05", typeof (string));
    dataTable.Columns.Add("06", typeof (string));
    dataTable.Columns.Add("07", typeof (string));
    dataTable.Columns.Add("08", typeof (string));
    dataTable.Columns.Add("09", typeof (string));
    dataTable.Columns.Add("10", typeof (string));
    dataTable.Columns.Add("C/T수", typeof (string));
    dataTable.Columns.Add("총계", typeof (string));
    List<string> stringList = new List<string>();
    foreach (DataRow dataRow in oDataTable.Select($"배송사명='{s배송사명}'"))
    {
      if (!stringList.Contains(dataRow["점코드"].ToString()))
        stringList.Add(dataRow["점코드"].ToString());
    }
    foreach (string str1 in stringList)
    {
      DataRow[] dataRowArray1 = oDataTable.Select($"배송사명='{s배송사명}' AND 점코드='{str1}'");
      int num1 = Common.C2I(oDataTable.Compute("SUM(내품수)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
      int num2 = Common.C2I(oDataTable.Compute("MAX(박스번호)", $"배송사명='{s배송사명}' AND 점코드='{str1}'"));
      int length = dataRowArray1.Length;
      int num3 = num2 / 10;
      int num4 = num2 % 10;
      string empty = string.Empty;
      if (num4 > 0)
        ++num3;
      for (int index1 = 0; index1 < num3; ++index1)
      {
        DataRow row = dataTable.NewRow();
        if (index1 == 0)
        {
          row[0] = (object) dataRowArray1[0]["점코드"].ToString();
          row[1] = (object) dataRowArray1[0]["점명"].ToString();
        }
        int num5 = num4 != 0 ? (index1 == num3 - 1 ? num4 : 10) : 10;
        for (int index2 = 0; index2 < num5; ++index2)
        {
          int num6 = index1 * 10 + (index2 + 1);
          DataRow[] dataRowArray2 = oDataTable.Select($"배송사명='{s배송사명}' AND 점코드='{str1}' AND 박스번호='{num6.ToString("D3")}'");
          string str2 = dataRowArray2 == null || dataRowArray2.Length <= 0 ? string.Empty : dataRowArray2[0]["내품수"].ToString();
          int num7 = num6 > 10 ? num6 % 10 : num6;
          if (num7 == 0)
            num7 = 10;
          row[1 + num7] = (object) str2;
        }
        if (index1 == 0)
        {
          row[12] = (object) length;
          row[13] = (object) num1;
        }
        dataTable.Rows.Add(row);
      }
    }
    return dataTable.Copy();
  }

  private void 분류_상품발송장_초기값()
  {
    DataTable dataTable = new DataTable();
    dataTable.Columns.Add("점코드", typeof (string));
    dataTable.Columns.Add("점명", typeof (string));
    dataTable.Columns.Add("01", typeof (string));
    dataTable.Columns.Add("02", typeof (string));
    dataTable.Columns.Add("03", typeof (string));
    dataTable.Columns.Add("04", typeof (string));
    dataTable.Columns.Add("05", typeof (string));
    dataTable.Columns.Add("06", typeof (string));
    dataTable.Columns.Add("07", typeof (string));
    dataTable.Columns.Add("08", typeof (string));
    dataTable.Columns.Add("09", typeof (string));
    dataTable.Columns.Add("10", typeof (string));
    dataTable.Columns.Add("C/T수", typeof (string));
    dataTable.Columns.Add("총계", typeof (string));
    PasTabPage pasTabPage = new PasTabPage();
    pasTabPage.Text = "상품발송장";
    RGrid oGrid = new RGrid();
    oGrid.BackgroundColor = Color.White;
    oGrid.Dock = DockStyle.Fill;
    Common.RGrid_Initializing(oGrid, true, false);
    pasTabPage.Controls.Add((System.Windows.Forms.Control) oGrid);
    this.tabControl1.TabPages.Add((TabPage) pasTabPage);
    pasTabPage.DataSource = dataTable;
    oGrid.DataSource2 = (object) pasTabPage.DataSource;
  }

  private void 분류_상품발송장_조회(string s분류번호, string s배치번호, 조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_상품발송장대상Table, DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.tabControl1.TabPages.Clear();
    if (this.m_분류_상품발송장대상Table.Rows.Count <= 0)
      this.분류_상품발송장_초기값();
    else if (e == 조회구분자.가조회)
    {
      this.분류_상품발송장_초기값();
    }
    else
    {
      List<string> stringList = new List<string>();
      foreach (DataRow row in (InternalDataCollectionBase) this.m_분류_상품발송장대상Table.Rows)
      {
        if (!stringList.Contains(row["배송사명"].ToString()))
          stringList.Add(row["배송사명"].ToString());
      }
      foreach (string s배송사명 in stringList)
      {
        PasTabPage pasTabPage = new PasTabPage();
        pasTabPage.Text = s배송사명;
        RGrid oGrid = new RGrid();
        oGrid.BackgroundColor = Color.White;
        oGrid.Dock = DockStyle.Fill;
        Common.RGrid_Initializing(oGrid, true, false);
        pasTabPage.Controls.Add((System.Windows.Forms.Control) oGrid);
        this.tabControl1.TabPages.Add((TabPage) pasTabPage);
        this.m_분류_상품발송장대상Table.Select($"배송사명='{s배송사명}'");
        pasTabPage.DataSource = this.분류_상품발송장_배송사별(s배송사명, this.m_분류_상품발송장대상Table);
        oGrid.DataSource2 = (object) pasTabPage.DataSource;
        foreach (DataGridViewColumn column in (BaseCollection) oGrid.Columns)
        {
          switch (column.HeaderText)
          {
            case "슈트번호":
              column.Visible = false;
              continue;
            case "01":
            case "02":
            case "03":
            case "04":
            case "05":
            case "06":
            case "07":
            case "08":
            case "09":
            case "10":
              column.DefaultCellStyle.BackColor = SystemColors.Info;
              column.DefaultCellStyle.ForeColor = Color.Blue;
              continue;
            case "C/T수":
            case "총계":
              column.DefaultCellStyle.ForeColor = Color.Red;
              continue;
            default:
              continue;
          }
        }
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
      this.분류_작업요약_조회(조회구분자.실조회);
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
      {
        empty1 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["분류번호"].ToString();
        empty2 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();
      }
      this.분류_상품발송장_조회(empty1, empty2, 조회구분자.실조회);
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
      this.분류_상품발송장_조회(this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString(), this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString(), 조회구분자.실조회);
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

  public void Save()
  {
    Cursor.Current = Cursors.WaitCursor;
    string fileName = string.Empty;
    try
    {
      if (this.m_분류_상품발송장대상Table == null || this.m_분류_상품발송장대상Table.Rows.Count <= 0)
      {
        Common.ErrorMessageBox("저장할 대상이 없습니다.");
      }
      else
      {
        string str1 = $"{this.m_분류_상품발송장대상Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_상품발송장대상Table.Rows[0]["브랜드명"].ToString()}";
        string str2 = this.m_분류_상품발송장대상Table.Rows[0]["배치번호"].ToString();
        PasTabPage selectedTab = (PasTabPage) this.tabControl1.SelectedTab;
        string text = selectedTab.Text;
        DataTable oDataTable = selectedTab.DataSource.Copy();
        oDataTable.Columns.Add("브랜드명", typeof (string));
        oDataTable.Columns.Add("배치번호", typeof (string));
        oDataTable.Columns.Add("배송사", typeof (string));
        oDataTable.Columns["배송사"].SetOrdinal(0);
        oDataTable.Columns["배치번호"].SetOrdinal(0);
        oDataTable.Columns["브랜드명"].SetOrdinal(0);
        foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
        {
          if (row["점코드"].ToString() != string.Empty)
          {
            row["브랜드명"] = (object) str1;
            row["배치번호"] = (object) str2;
            row["배송사"] = (object) text;
          }
        }
        oDataTable.AcceptChanges();
        fileName = new Excel().Export(oDataTable);
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
      if (this.m_분류_상품발송장대상Table == null || this.m_분류_상품발송장대상Table.Rows.Count <= 0)
      {
        Common.ErrorMessageBox("출력할 대상이 없습니다.");
      }
      else
      {
        string val1 = $"{this.m_분류_상품발송장대상Table.Rows[0]["브랜드코드"].ToString()}:{this.m_분류_상품발송장대상Table.Rows[0]["브랜드명"].ToString()}";
        string val2 = this.m_분류_상품발송장대상Table.Rows[0]["배치번호"].ToString();
        PasTabPage selectedTab = (PasTabPage) this.tabControl1.SelectedTab;
        string text = selectedTab.Text;
        상품발송장_매장별 상품발송장매장별 = new 상품발송장_매장별();
        상품발송장매장별.SetDataSource(selectedTab.DataSource);
        상품발송장매장별.SetParameterValue("로컬장비명", (object) Common.Setting.NAME);
        상품발송장매장별.SetParameterValue("브랜드명", (object) val1);
        상품발송장매장별.SetParameterValue("배치번호", (object) val2);
        상품발송장매장별.SetParameterValue("배송사", (object) text);
        int val3 = 0;
        int val4 = 0;
        foreach (DataRow row in (InternalDataCollectionBase) selectedTab.DataSource.Rows)
        {
          val3 += Common.C2I(row["C/T수"]);
          val4 += Common.C2I(row["총계"]);
        }
        상품발송장매장별.SetParameterValue("CT수", (object) val3);
        상품발송장매장별.SetParameterValue("총계", (object) val4);
        Form form = new Form();
        form.Text = "인쇄 미리보기";
        form.StartPosition = FormStartPosition.CenterParent;
        form.Size = new Size(1024 /*0x0400*/, 768 /*0x0300*/);
        CrystalReportViewer crystalReportViewer = new CrystalReportViewer();
        crystalReportViewer.ReportSource = (object) 상품발송장매장별;
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
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
  {
    try
    {
      foreach (System.Windows.Forms.Control control in (ArrangedElementCollection) this.tabControl1.SelectedTab.Controls)
      {
        if (control is RGrid)
          ((DataGridView) control).AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      }
    }
    catch (Exception ex)
    {
      string message = ex.Message;
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
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.tabControl1 = new TabControl();
    this.tabPage1 = new TabPage();
    this.tabPage2 = new TabPage();
    this.pasPanel1 = new PasPanel();
    this.dateTimePicker1 = new DateTimePicker();
    this.rLabel1 = new RLabel();
    this.조회버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.tabControl1.SuspendLayout();
    this.pasPanel1.SuspendLayout();
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
    this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage1);
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage2);
    this.tabControl1.Location = new Point(6, 201);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(988, 397);
    this.tabControl1.TabIndex = 5;
    this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(980, 371);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "tabPage1";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.tabPage2.Location = new Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Padding = new Padding(3);
    this.tabPage2.Size = new Size(980, 371);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "tabPage2";
    this.tabPage2.UseVisualStyleBackColor = true;
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
    this.dateTimePicker1.Format = DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new Point(88, 12);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new Size(100, 21);
    this.dateTimePicker1.TabIndex = 14;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(12, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(80 /*0x50*/, 23);
    this.rLabel1.TabIndex = 13;
    this.rLabel1.Text = "작업일자";
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(807, 11);
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
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.tabControl1);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00025);
    this.Text = "frmPAS00021";
    this.Load += new EventHandler(this.frmPAS00025_Load);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.tabControl1.ResumeLayout(false);
    this.pasPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
