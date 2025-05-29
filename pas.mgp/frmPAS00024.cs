// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00024
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
// using pas.mgp.Properties;
using System;
using System.Collections;
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

public class frmPAS00024 : Form
{
  private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
  private DataTable m_분류_마지막박스내역Table = new DataTable("usp_분류_마지막박스내역_Get");
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Panel panel1;
  private RGrid rGrid1;
  private RButton 조회버튼;
  private RGrid rGrid2;
  private CheckBox checkBox1;
  private RLabel rLabel2;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel1;
  private RButton 마지막박스발행버튼;

  public frmPAS00024()
  {
    this.InitializeComponent();
    this.Text = "마지막 박스 확인";
    this.BackColor = Color.White;
    Common.RGrid_Initializing(this.rGrid1, true);
    Common.RGrid_Initializing(this.rGrid2, false);
    this.rLabel1.Control = (System.Windows.Forms.Control) this.dateTimePicker1;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.checkBox1;
  }

  private void frmPAS00024_Load(object sender, EventArgs e)
  {
    this.분류_작업요약_조회(조회구분자.가조회);
    this.분류_마지막박스내역_조회(string.Empty, string.Empty, 조회구분자.가조회);
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

  private void 분류_마지막박스내역_조회(string s분류번호, string s배치번호, 조회구분자 e)
  {
    this.checkBox1.Checked = false;
    DbProvider.Select(Common.ConnectionString(), this.m_분류_마지막박스내역Table, DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid2.DataSource2 = (object) this.m_분류_마지막박스내역Table;
    this.rGrid2.SetSummaries(new DataGridViewSummary("실적수", SummaryType.합계));
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid2.Columns)
    {
      switch (column.HeaderText)
      {
        case "분류번호":
        case "배치번호":
        case "서브슈트번호":
          column.Visible = false;
          continue;
        default:
          if (column.HeaderText == "선택")
            column.ReadOnly = false;
          else
            column.ReadOnly = true;
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
      this.분류_작업요약_조회(조회구분자.실조회);
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
      {
        empty1 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["분류번호"].ToString();
        empty2 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();
      }
      this.분류_마지막박스내역_조회(empty1, empty2, 조회구분자.실조회);
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
      this.분류_마지막박스내역_조회(this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString(), this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString(), 조회구분자.실조회);
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

  private void checkBox1_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid2.Rows)
    {
      if (row.Tag == null || !(row.Tag.ToString() == "요약"))
        row.Cells["선택"].Value = (object) this.checkBox1.Checked;
    }
    this.rGrid2.EndEdit();
  }

  private void 마지막박스발행버튼_Click(object sender, EventArgs e)
  {
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
    string empty12 = string.Empty;
    string empty13 = string.Empty;
    string empty14 = string.Empty;
    string empty15 = string.Empty;
    string empty16 = string.Empty;
    string empty17 = string.Empty;
    DateTime.Now.ToString("yyyy-MM-dd");
    TcpClient oClient = (TcpClient) null;
    if (this.rGrid1.SelectedRows == null || this.rGrid1.SelectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("배치를 선택해 주세요.");
    }
    else
    {
      dlgPAS00026 dlgPaS00026 = new dlgPAS00026();
      if (dlgPaS00026.ShowDialog() == DialogResult.OK)
      {
        bool flag1;
        bool flag2;
        switch (dlgPaS00026.선택값)
        {
          case 1:
            flag1 = true;
            flag2 = false;
            break;
          case 2:
            flag1 = false;
            flag2 = true;
            break;
          case 3:
            flag1 = true;
            flag2 = true;
            break;
          default:
            Common.ErrorMessageBox("발행을 취소합니다.");
            return;
        }
        try
        {
          DataTable oDataTable1 = new DataTable("usp_기준_거래명세서용_마스터_Get");
          DbProvider.Select(Common.ConnectionString(), oDataTable1, (SqlParameter[]) null);
          if (oDataTable1 == null || oDataTable1.Rows.Count <= 0)
          {
            Common.ErrorMessageBox("발행할 거래명세서 대상이 없습니다.");
          }
          else
          {
            Cursor.Current = Cursors.WaitCursor;
            string empty18 = string.Empty;
            using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
            {
              DataTable oDataTable2 = new DataTable("usp_분류_박스풀작성_Set");
              dbProvider2.Initialize("usp_분류_박스풀작성_Set", "@분류번호", "@장비명", "@슈트번호", "@마지막박스여부");
              foreach (DataGridViewRow row in (IEnumerable) this.rGrid2.Rows)
              {
                if (row.Cells["선택"].Value.ToString() == bool.TrueString)
                {
                  string str1 = row.Cells["분류번호"].Value.ToString();
                  string s슈트번호 = row.Cells["슈트번호"].Value.ToString();
                  dbProvider2.Fill(oDataTable2, (object) str1, (object) Common.Setting.NAME, (object) s슈트번호, (object) "1");
                  if (oDataTable2 != null && oDataTable2.Rows.Count > 0)
                  {
                    string s박스바코드 = oDataTable2.Rows[0]["박스바코드"].ToString();
                    string str2 = oDataTable2.Rows[0]["점명"].ToString();
                    string str3 = oDataTable2.Rows[0]["내품수"].ToString();
                    string s배치구분 = oDataTable2.Rows[0]["배치구분"].ToString();
                    string s박스바코드구분 = oDataTable2.Rows[0]["박스바코드구분"].ToString();
                    oDataTable2.Rows[0]["점코드"].ToString();
                    string str4 = oDataTable2.Rows[0]["박스번호"].ToString();
                    string s패턴구분 = oDataTable2.Rows[0]["패턴구분"].ToString();
                    string str5 = oDataTable2.Rows[0]["출력여부"].ToString();
                    string str6 = oDataTable2.Rows[0]["브랜드코드"].ToString();
                    string str7 = oDataTable2.Rows[0]["브랜드명"].ToString();
                    string s배치번호 = oDataTable2.Rows[0]["배치번호"].ToString();
                    string str8 = oDataTable2.Rows[0]["배치명"].ToString();
                    oDataTable2.Rows[0]["대표바코드"].ToString();
                    oDataTable2.Rows[0]["수량"].ToString();
                    string str9 = DateTime.Now.ToString("yyyy-MM-dd");
                    string empty19 = string.Empty;
                    string empty20 = string.Empty;
                    string empty21 = string.Empty;
                    string empty22 = string.Empty;
                    int num = Common.C2I(oDataTable2.Rows[0]["SKU수"]);
                    int count = oDataTable2.Rows.Count;
                    switch (s배치구분)
                    {
                      case "패키지":
                        Common.GetPrintScript2(Common.GetPrinterName("패키지"), s박스바코드, s박스바코드구분, oClient, oDataTable2.Copy());
                        break;
                      case "반품":
                        s패턴구분 = num <= 3 ? "반품유형1" : "반품유형2";
                        goto default;
                      default:
                        if (!string.IsNullOrEmpty(str3) && str3 != "0" && str5 == "1")
                        {
                          string printScript = Common.GetPrintScript(s패턴구분, s배치구분, count);
                          string str10;
                          switch (s패턴구분)
                          {
                            case "사용안함":
                              str10 = string.Empty;
                              break;
                            case "출고유형":
                              str10 = string.Format(printScript, (object) $"{str6}:{str7}", (object) str2, (object) s슈트번호, (object) str4, (object) str3, (object) s박스바코드, (object) str9);
                              break;
                            case "반품유형1":
                              string empty23;
                              string empty24;
                              string empty25;
                              string empty26;
                              switch (count)
                              {
                                case 1:
                                  empty23 = oDataTable2.Rows[0]["대표바코드"].ToString();
                                  empty24 = string.Empty;
                                  empty25 = oDataTable2.Rows[0]["수량"].ToString();
                                  empty26 = string.Empty;
                                  break;
                                case 2:
                                  empty23 = oDataTable2.Rows[0]["대표바코드"].ToString();
                                  empty24 = oDataTable2.Rows[1]["대표바코드"].ToString();
                                  empty25 = oDataTable2.Rows[0]["수량"].ToString();
                                  empty26 = oDataTable2.Rows[1]["수량"].ToString();
                                  break;
                                default:
                                  empty23 = string.Empty;
                                  empty24 = string.Empty;
                                  empty25 = string.Empty;
                                  empty26 = string.Empty;
                                  break;
                              }
                              str10 = string.Format(printScript, (object) $"{str6}:{str8}", (object) s배치번호, (object) s박스바코드, (object) s박스바코드구분, (object) s슈트번호, (object) str4, (object) str3, (object) empty23, (object) empty25, (object) empty24, (object) empty26, (object) str9);
                              break;
                            case "반품유형2":
                              str10 = string.Format(printScript, (object) $"{str6}:{str8}", (object) s박스바코드, (object) s박스바코드구분, (object) s배치번호, (object) s슈트번호, (object) str4, (object) str3, (object) num.ToString(), (object) str9);
                              break;
                            default:
                              str10 = string.Format(printScript, (object) str2, (object) s슈트번호, (object) str3, (object) s박스바코드);
                              break;
                          }
                          string printerName = Common.GetPrinterName(s슈트번호);
                          if (oClient != null)
                          {
                            oClient.Close();
                            oClient = (TcpClient) null;
                          }
                          oClient = new TcpClient();
                          oClient.Connect(printerName, 9100);
                          using (StreamWriter streamWriter = new StreamWriter((Stream) oClient.GetStream(), Encoding.GetEncoding(949)))
                          {
                            streamWriter.Write(str10);
                            streamWriter.Flush();
                            streamWriter.Close();
                          }
                          Thread.Sleep(300);
                          break;
                        }
                        break;
                    }
                    if (s배치구분 == "출하")
                    {
                      DataRow[] dataRowArray = oDataTable1.Select($"슈트번호 = '{s슈트번호}'");
                      string s거명용바코드 = dataRowArray == null || dataRowArray.Length <= 0 ? $"*SLK{s슈트번호}{1.ToString("D4")}*" : $"*{dataRowArray[0]["아이템코드"].ToString()}*";
                      if (flag1)
                        Common.거래명세서발행_박스별(s배치번호, s슈트번호, s거명용바코드);
                      if (flag2)
                        Common.거래명세서발행_토탈(s배치번호, s슈트번호, s거명용바코드);
                    }
                  }
                }
              }
              dbProvider2.Commit();
            }
          }
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
        }
        finally
        {
          oClient?.Close();
          Cursor.Current = Cursors.Default;
          this.조회버튼_Click((object) null, EventArgs.Empty);
        }
      }
      else
        Common.ErrorMessageBox("발행을 취소합니다.");
    }
  }

  public void Save()
  {
  }

  public void Print()
  {
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
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.pasPanel1 = new PasPanel();
    this.마지막박스발행버튼 = new RButton();
    this.rLabel2 = new RLabel();
    this.dateTimePicker1 = new DateTimePicker();
    this.rLabel1 = new RLabel();
    this.checkBox1 = new CheckBox();
    this.조회버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.rGrid2 = new RGrid();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.pasPanel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid2).BeginInit();
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
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.마지막박스발행버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 2;
    this.마지막박스발행버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.마지막박스발행버튼.ButtonState = RButtonState.None;
    this.마지막박스발행버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.마지막박스발행버튼.ForeColor = Color.DimGray;
    this.마지막박스발행버튼.Image = (Image) pas.mgp.Properties.Resources._1397196762_stock_id;
    this.마지막박스발행버튼.Location = new Point(767 /*0x02FF*/, 11);
    this.마지막박스발행버튼.Name = "마지막박스발행버튼";
    this.마지막박스발행버튼.Size = new Size(130, 23);
    this.마지막박스발행버튼.TabIndex = 16 /*0x10*/;
    this.마지막박스발행버튼.Text = "마지막박스 발행";
    this.마지막박스발행버튼.UseVisualStyleBackColor = true;
    this.마지막박스발행버튼.Click += new EventHandler(this.마지막박스발행버튼_Click);
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(194, 11);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(80 /*0x50*/, 23);
    this.rLabel2.TabIndex = 15;
    this.rLabel2.Text = "전체선택";
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
    this.checkBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(280, 11);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(100, 23);
    this.checkBox1.TabIndex = 2;
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox1.Click += new EventHandler(this.checkBox1_Click);
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(676, 11);
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
    this.rGrid2.Location = new Point(6, 201);
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
    this.rGrid2.Size = new Size(988, 397);
    this.rGrid2.TabIndex = 4;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00024);
    this.Text = "frmPAS00021";
    this.Load += new EventHandler(this.frmPAS00024_Load);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.pasPanel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid2).EndInit();
    this.ResumeLayout(false);
  }
}
