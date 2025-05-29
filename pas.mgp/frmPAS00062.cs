// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00062
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
// using pas.mgp.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00062 : Form
{
  private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
  private DataTable m_분류_실적작성대상Table = new DataTable("usp_분류_실적작성대상_Get");
  private DataTable m_분류_실적작성내용Table = new DataTable("usp_분류_실적작성내용_Get");
  private DataTable m_출하_배치반영Table = new DataTable("usp_출하_배치반영_Get");
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Panel panel1;
  private Splitter splitter1;
  private RPanel rPanel1;
  private RButton 조회버튼;
  private RGrid rGrid1;
  private RGrid rGrid2;
  private RButton 실적전송버튼;
  private RButton 실적작성버튼;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel1;
  private RButton 배치반영버튼;
  private RButton 중간실적반영버튼;

  public frmPAS00062()
  {
    this.InitializeComponent();
    this.Text = "실적작성/반영, 배치반영";
    this.BackColor = Color.White;
    this.splitter1.BackColor = Common.SPLITTER_COLOR;
    this.rLabel1.BackColor = this.rPanel1.PanelColor;
    Common.RGrid_Initializing(this.rGrid1, false);
    Common.RGrid_Initializing(this.rGrid2, true, false);
    this.실적작성버튼.Enabled = true;
    this.실적전송버튼.Enabled = false;
    this.배치반영버튼.Enabled = false;
  }

  private void frmPAS00062_Load(object sender, EventArgs e)
  {
    this.분류_작업요약_조회(조회구분자.가조회);
    this.분류_실적작성_조회(string.Empty, string.Empty, 조회구분자.가조회);
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
          if (column.HeaderText == "선택")
            column.ReadOnly = false;
          else
            column.ReadOnly = true;
          column.Visible = true;
          continue;
      }
    }
    IEnumerator enumerator = ((IEnumerable) this.rGrid1.Rows).GetEnumerator();
    try
    {
      if (!enumerator.MoveNext())
        return;
      switch (((DataGridViewRow) enumerator.Current).Cells["배치상태"].Value.ToString())
      {
        case "완료":
          this.실적작성버튼.Enabled = true;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = false;
          break;
        case "실적작성":
          this.실적작성버튼.Enabled = true;
          this.실적전송버튼.Enabled = true;
          this.배치반영버튼.Enabled = false;
          break;
        case "실적반영":
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = true;
          this.배치반영버튼.Enabled = true;
          break;
        case "배치반영":
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = true;
          break;
        default:
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = false;
          break;
      }
    }
    finally
    {
      if (enumerator is IDisposable disposable)
        disposable.Dispose();
    }
  }

  private void 분류_실적작성_조회(string s분류번호, string s배치번호, 조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_실적작성대상Table, DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid2.DataSource2 = (object) this.m_분류_실적작성대상Table;
    this.rGrid2.SetSummaries(new DataGridViewSummary("지시수", SummaryType.합계), new DataGridViewSummary("실적수", SummaryType.합계), new DataGridViewSummary("부족수", SummaryType.합계));
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid2.Columns)
    {
      switch (column.HeaderText)
      {
        case "일련번호":
        case "계산용":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          if (column.HeaderText == "부족수")
          {
            column.DefaultCellStyle.BackColor = SystemColors.Info;
            column.DefaultCellStyle.ForeColor = Color.Red;
            continue;
          }
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
      this.분류_작업요약_조회(조회구분자.실조회);
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
      {
        empty1 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["분류번호"].ToString();
        empty2 = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();
      }
      this.분류_실적작성_조회(empty1, empty2, 조회구분자.실조회);
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

  private void 실적전송버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("선택한 대상이 없습니다.\r\n배치를 선택해 주세요.");
      }
      else
      {
        string oValue1 = selectedRows[0].Cells["분류번호"].Value.ToString();
        string oValue2 = selectedRows[0].Cells["배치번호"].Value.ToString();
        if (selectedRows[0].Cells["배치상태"].Value.ToString() == "완료")
        {
          Common.ErrorMessageBox("선택한 배치는 실적작성이 되지 않았습니다.");
        }
        else
        {
          object obj1 = this.m_분류_실적작성대상Table.Compute("SUM(지시수)", string.Empty);
          object obj2 = this.m_분류_실적작성대상Table.Compute("SUM(실적수)", string.Empty);
          object obj3 = this.m_분류_실적작성대상Table.Compute("SUM(부족수)", string.Empty);
          if (Common.QuestionMessageBox($"배치번호 : {oValue2}\r\n\r\n지시수 : {Common.C2I(obj1)}\r\n실적수 : {Common.C2I(obj2)}\r\n부족수 : {Common.C2I(obj3)}\r\n\r\n배치 내역을 확인하세요.\r\n실적 전송을 실행 하시겠습니까?") == DialogResult.Yes)
          {
            DataTable dataTable = this.m_분류_실적작성대상Table.Copy();
            dataTable.TableName = "실적TABLE";
            using (StringWriter writer = new StringWriter())
            {
              dataTable.WriteXml((TextWriter) writer);
              DbProvider.Excute(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_실적반영_Set", DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
              DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "실적반영", ParameterDirection.Input));
            }
            Common.OkMessageBox("실적 전송이 완료되었습니다.");
          }
          else
            Common.ErrorMessageBox("작업을 취소합니다!!");
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
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

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
      string s분류번호 = this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString();
      string s배치번호 = this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString();
      switch (this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치상태"].Value.ToString())
      {
        case "완료":
          this.실적작성버튼.Enabled = true;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = false;
          break;
        case "실적작성":
          this.실적작성버튼.Enabled = true;
          this.실적전송버튼.Enabled = true;
          this.배치반영버튼.Enabled = false;
          break;
        case "실적반영":
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = true;
          this.배치반영버튼.Enabled = true;
          break;
        case "배치반영":
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = true;
          break;
        default:
          this.실적작성버튼.Enabled = false;
          this.실적전송버튼.Enabled = false;
          this.배치반영버튼.Enabled = false;
          break;
      }
      this.분류_실적작성_조회(s분류번호, s배치번호, 조회구분자.실조회);
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

  private void 실적작성버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("선택한 대상이 없습니다.\r\n배치를 선택해 주세요.");
      }
      else
      {
        string oValue1 = selectedRows[0].Cells["배치번호"].Value.ToString();
        string oValue2 = selectedRows[0].Cells["분류번호"].Value.ToString();
        if (Common.QuestionMessageBox($"배치번호 : {oValue1}\r\n\r\n선택한 배치의 실적을 작성 하시겠습니까?") != DialogResult.Yes)
        {
          Common.ErrorMessageBox("작업을 취소합니다!!");
        }
        else
        {
          DbProvider.Select(Common.ConnectionString(), this.m_분류_실적작성내용Table, DbProvider.GetParameter("@분류번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue1, ParameterDirection.Input));
          if (this.m_분류_실적작성내용Table.Rows.Count <= 0)
          {
            Common.ErrorMessageBox("작업한 내용이 없습니다.");
          }
          else
          {
            DbProvider.Excute(Common.ConnectionString(), "usp_분류_실적작성_Set", DbProvider.GetParameter("@분류번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue1, ParameterDirection.Input));
            DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "실적작성", ParameterDirection.Input));
            Common.OkMessageBox("실적 작성이 완료되었습니다.");
          }
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
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private void 배치반영버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("선택한 대상이 없습니다.\r\n배치를 선택해 주세요.");
      }
      else
      {
        string oValue1 = selectedRows[0].Cells["분류번호"].Value.ToString();
        string oValue2 = selectedRows[0].Cells["장비명"].Value.ToString();
        string oValue3 = selectedRows[0].Cells["배치번호"].Value.ToString();
        if (Common.QuestionMessageBox($"배치번호 : {oValue3}\r\n\r\n선택한 배치의 패킹실적을 작성 하시겠습니까?") != DialogResult.Yes)
        {
          Common.ErrorMessageBox("작업을 취소합니다!!");
        }
        else
        {
          DbProvider.Select(Common.ConnectionString(), this.m_출하_배치반영Table, DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) 1, ParameterDirection.Input));
          using (StringWriter writer = new StringWriter())
          {
            DataTable dataTable = this.m_출하_배치반영Table.Copy();
            dataTable.TableName = "배치TABLE";
            dataTable.WriteXml((TextWriter) writer);
            DbProvider.Select(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_배치반영_Set", DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
            DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_Set", DbProvider.GetParameter("@장비명", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "배치반영", ParameterDirection.Input));
          }
          Common.OkMessageBox("배치반영이 완료되었습니다.");
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
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private void 중간실적반영버튼_Click(object sender, EventArgs e)
  {
    try
    {
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("선택한 대상이 없습니다.\r\n배치를 선택해 주세요.");
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        string oValue1 = selectedRows[0].Cells["분류번호"].Value.ToString();
        string oValue2 = selectedRows[0].Cells["장비명"].Value.ToString();
        string oValue3 = selectedRows[0].Cells["배치번호"].Value.ToString();
        string str = selectedRows[0].Cells["배치구분"].Value.ToString();
        DataTable oDataTable1 = new DataTable("usp_분류_실적작성대상_중간_Get");
        DataTable oDataTable2 = new DataTable("usp_출하_배치반영_Get");
        if (str == "반품")
        {
          DbProvider.Select(Common.ConnectionString(), oDataTable1, DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input));
          using (StringWriter writer = new StringWriter())
          {
            DataTable dataTable = oDataTable1.Copy();
            dataTable.TableName = "실적TABLE";
            dataTable.WriteXml((TextWriter) writer);
            DbProvider.Excute(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_실적반영_Set", DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
          }
        }
        DbProvider.Select(Common.ConnectionString(), oDataTable2, DbProvider.GetParameter("@분류번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) 1, ParameterDirection.Input));
        using (StringWriter writer = new StringWriter())
        {
          DataTable dataTable = oDataTable2.Copy();
          dataTable.TableName = "배치TABLE";
          dataTable.WriteXml((TextWriter) writer);
          DbProvider.Select(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_배치반영_Set", DbProvider.GetParameter("@배치번호", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
        }
        Common.OkMessageBox("WMS에 중간 실적을 반영하였습니다.");
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
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.rPanel1 = new RPanel();
    this.배치반영버튼 = new RButton();
    this.dateTimePicker1 = new DateTimePicker();
    this.rLabel1 = new RLabel();
    this.실적작성버튼 = new RButton();
    this.실적전송버튼 = new RButton();
    this.조회버튼 = new RButton();
    this.splitter1 = new Splitter();
    this.rGrid2 = new RGrid();
    this.pasPanel1 = new PasPanel();
    this.중간실적반영버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.rPanel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    this.pasPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Dock = DockStyle.Top;
    this.panel1.Location = new Point(0, 45);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(1000, 200);
    this.panel1.TabIndex = 3;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
    this.rGrid1.Location = new Point(6, 57);
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
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.배치반영버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.실적작성버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.실적전송버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 6);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(988, 45);
    this.rPanel1.TabIndex = 1;
    this.배치반영버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.배치반영버튼.ButtonState = RButtonState.None;
    this.배치반영버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.배치반영버튼.ForeColor = Color.DimGray;
    this.배치반영버튼.Image = (Image) pas.mgp.Properties.Resources._1395148855_send;
    this.배치반영버튼.Location = new Point(862, 11);
    this.배치반영버튼.Name = "배치반영버튼";
    this.배치반영버튼.Size = new Size(120, 23);
    this.배치반영버튼.TabIndex = 9;
    this.배치반영버튼.Text = "WMS 패킹반영";
    this.배치반영버튼.UseVisualStyleBackColor = true;
    this.배치반영버튼.Click += new EventHandler(this.배치반영버튼_Click);
    this.dateTimePicker1.Format = DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new Point(82, 12);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new Size(100, 21);
    this.dateTimePicker1.TabIndex = 8;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(6, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(80 /*0x50*/, 23);
    this.rLabel1.TabIndex = 7;
    this.rLabel1.Text = "작업일자";
    this.실적작성버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.실적작성버튼.ButtonState = RButtonState.None;
    this.실적작성버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.실적작성버튼.ForeColor = Color.DimGray;
    this.실적작성버튼.Image = (Image) pas.mgp.Properties.Resources._1397196465_app;
    this.실적작성버튼.Location = new Point(620, 11);
    this.실적작성버튼.Name = "실적작성버튼";
    this.실적작성버튼.Size = new Size(120, 23);
    this.실적작성버튼.TabIndex = 4;
    this.실적작성버튼.Text = "PAS 실적작성";
    this.실적작성버튼.UseVisualStyleBackColor = true;
    this.실적작성버튼.Click += new EventHandler(this.실적작성버튼_Click);
    this.실적전송버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.실적전송버튼.ButtonState = RButtonState.None;
    this.실적전송버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.실적전송버튼.ForeColor = Color.DimGray;
    this.실적전송버튼.Image = (Image) pas.mgp.Properties.Resources._1395148855_send;
    this.실적전송버튼.Location = new Point(741, 11);
    this.실적전송버튼.Name = "실적전송버튼";
    this.실적전송버튼.Size = new Size(120, 23);
    this.실적전송버튼.TabIndex = 2;
    this.실적전송버튼.Text = "WMS 실적반영";
    this.실적전송버튼.UseVisualStyleBackColor = true;
    this.실적전송버튼.Click += new EventHandler(this.실적전송버튼_Click);
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(529, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 1;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
    this.splitter1.Dock = DockStyle.Top;
    this.splitter1.Location = new Point(0, 245);
    this.splitter1.Name = "splitter1";
    this.splitter1.Size = new Size(1000, 3);
    this.splitter1.TabIndex = 4;
    this.splitter1.TabStop = false;
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
    this.rGrid2.Location = new Point(6, 250);
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
    this.rGrid2.Size = new Size(988, 348);
    this.rGrid2.TabIndex = 5;
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.중간실적반영버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 2;
    this.중간실적반영버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.중간실적반영버튼.ButtonState = RButtonState.None;
    this.중간실적반영버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.중간실적반영버튼.ForeColor = Color.DimGray;
    this.중간실적반영버튼.Image = (Image) pas.mgp.Properties.Resources.database_access;
    this.중간실적반영버튼.Location = new Point(747, 11);
    this.중간실적반영버튼.Name = "중간실적반영버튼";
    this.중간실적반영버튼.Size = new Size(150, 23);
    this.중간실적반영버튼.TabIndex = 10;
    this.중간실적반영버튼.Text = "WMS 중간실적 반영";
    this.중간실적반영버튼.UseVisualStyleBackColor = true;
    this.중간실적반영버튼.Click += new EventHandler(this.중간실적반영버튼_Click);
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
    this.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.Controls.Add((System.Windows.Forms.Control) this.splitter1);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00062);
    this.Text = nameof (frmPAS00062);
    this.Load += new EventHandler(this.frmPAS00062_Load);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.rPanel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid2).EndInit();
    this.pasPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
