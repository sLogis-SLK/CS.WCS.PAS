// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00064
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00064 : RSkinForm
{
  private DataTable m_분류_작업요약_배치그룹별Table = new DataTable("usp_분류_작업요약_배치그룹별_Get");
  private DataTable m_PAS_배송사변경Table = new DataTable("usp_PAS_배송사변경_Get");
  private DataTable m_관리_배송사변경Table = new DataTable("usp_관리_배송사변경_Get");
  private IContainer components;
  private Panel panel1;
  private RButton 닫기버튼;
  private RPanel rPanel1;
  private RGrid rGrid1;
  private RButton 저장버튼;
  private Panel panel2;
  private Splitter splitter1;
  private RButton 조회버튼;
  private Panel panel3;
  private RGrid rGrid3;
  private Splitter splitter2;
  private RGrid rGrid2;

  public dlgPAS00064()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    this.splitter1.BackColor = Common.SPLITTER_COLOR;
    this.splitter2.BackColor = Common.SPLITTER_COLOR;
    this.StartPosition = FormStartPosition.CenterParent;
    Common.RGrid_Initializing(this.rGrid1, true, true);
    Common.RGrid_Initializing(this.rGrid2, true, true);
    Common.RGrid_Initializing(this.rGrid3, true, true);
  }

  private void 분류_작업요약_조회(조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_작업요약_배치그룹별Table, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "모두", ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    List<DataRow> dataRowList = new List<DataRow>();
    foreach (DataRow row in (InternalDataCollectionBase) this.m_분류_작업요약_배치그룹별Table.Rows)
    {
      if ((row["분류상태"].ToString() == "종료" || row["분류상태"].ToString() == "중단") && !dataRowList.Contains(row))
        dataRowList.Add(row);
    }
    foreach (DataRow row in dataRowList.ToArray())
      this.m_분류_작업요약_배치그룹별Table.Rows.Remove(row);
    this.m_분류_작업요약_배치그룹별Table.AcceptChanges();
    this.rGrid1.DataSource2 = (object) this.m_분류_작업요약_배치그룹별Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid1.Columns)
    {
      switch (column.HeaderText)
      {
        case "선택":
        case "순번":
        case "관리번호":
        case "장비구분":
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

  private void PAS_배송사변경_조회(string s배치번호, 조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(DB연결구분.시스템), this.m_PAS_배송사변경Table, DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid2.DataSource2 = (object) this.m_PAS_배송사변경Table;
  }

  private void 관리_배송사변경_조회(string s배치번호, 조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_관리_배송사변경Table, DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid3.DataSource2 = (object) this.m_관리_배송사변경Table;
  }

  private void dlgPAS00064_Load(object sender, EventArgs e)
  {
    this.Text = Common.Title;
    this.Text2 = "배송사 변경";
    this.분류_작업요약_조회(조회구분자.가조회);
    this.PAS_배송사변경_조회(string.Empty, 조회구분자.가조회);
    this.관리_배송사변경_조회(string.Empty, 조회구분자.가조회);
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.Close();

  private void 저장버튼_Click(object sender, EventArgs e)
  {
    try
    {
      if (this.rGrid1.SelectedRows == null || this.rGrid1.SelectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("배치를 선택해 주세요.");
      }
      else
      {
        Cursor.Current = Cursors.WaitCursor;
        string oValue = this.rGrid1.SelectedRows[0].Cells["배치번호"].Value.ToString();
        using (StringWriter writer = new StringWriter())
        {
          DataTable dataTable = this.m_PAS_배송사변경Table.Copy();
          dataTable.TableName = "배송사TABLE";
          dataTable.WriteXml((TextWriter) writer);
          DbProvider.Excute(Common.ConnectionString(), "usp_관리_배송사변경_Set", DbProvider.GetParameter("@배치번호", (object) oValue, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
        }
        Common.OkMessageBox("배송사 변경이 완료되었습니다.");
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

  private void 조회버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.분류_작업요약_조회(조회구분자.실조회);
      string empty = string.Empty;
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
        empty = this.m_분류_작업요약_배치그룹별Table.Rows[0]["배치번호"].ToString();
      this.PAS_배송사변경_조회(empty, 조회구분자.실조회);
      this.관리_배송사변경_조회(empty, 조회구분자.실조회);
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

  private void rGrid1_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      DataGridView.HitTestInfo hitTestInfo = this.rGrid1.HitTest(e.X, e.Y);
      if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0)
        return;
      string empty = string.Empty;
      if (this.m_분류_작업요약_배치그룹별Table.Rows.Count > 0)
        empty = this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치번호"].Value.ToString();
      this.PAS_배송사변경_조회(empty, 조회구분자.실조회);
      this.관리_배송사변경_조회(empty, 조회구분자.실조회);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00064));
    this.panel1 = new Panel();
    this.panel2 = new Panel();
    this.panel3 = new Panel();
    this.rGrid3 = new RGrid();
    this.splitter2 = new Splitter();
    this.rGrid2 = new RGrid();
    this.splitter1 = new Splitter();
    this.rGrid1 = new RGrid();
    this.rPanel1 = new RPanel();
    this.조회버튼 = new RButton();
    this.저장버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.panel1.SuspendLayout();
    this.panel2.SuspendLayout();
    this.panel3.SuspendLayout();
    ((ISupportInitialize) this.rGrid3).BeginInit();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.panel2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 47);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(776, 541);
    this.panel1.TabIndex = 0;
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.panel3);
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.splitter1);
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel2.Location = new Point(6, 54);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(764, 484);
    this.panel2.TabIndex = 16 /*0x10*/;
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rGrid3);
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.splitter2);
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.panel3.Dock = DockStyle.Fill;
    this.panel3.Location = new Point(0, 146);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(764, 338);
    this.panel3.TabIndex = 17;
    this.rGrid3.AllowUserToAddRows = false;
    this.rGrid3.AllowUserToDeleteRows = false;
    this.rGrid3.AlternateColor = Color.Empty;
    this.rGrid3.BackgroundColor = Color.White;
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Control;
    gridViewCellStyle1.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle1.ForeColor = SystemColors.WindowText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    this.rGrid3.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
    this.rGrid3.DataSource2 = (object) null;
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle2.BackColor = SystemColors.Window;
    gridViewCellStyle2.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle2.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid3.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid3.Dock = DockStyle.Fill;
    this.rGrid3.Location = new Point(353, 0);
    this.rGrid3.Name = "rGrid3";
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle3.BackColor = SystemColors.Control;
    gridViewCellStyle3.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle3.ForeColor = SystemColors.WindowText;
    gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle3.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    this.rGrid3.RowHeadersDefaultCellStyle = gridViewCellStyle3;
    this.rGrid3.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid3.Size = new Size(411, 338);
    this.rGrid3.TabIndex = 18;
    this.splitter2.Location = new Point(350, 0);
    this.splitter2.Name = "splitter2";
    this.splitter2.Size = new Size(3, 338);
    this.splitter2.TabIndex = 17;
    this.splitter2.TabStop = false;
    this.rGrid2.AllowUserToAddRows = false;
    this.rGrid2.AllowUserToDeleteRows = false;
    this.rGrid2.AlternateColor = Color.Empty;
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
    gridViewCellStyle5.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle5.WrapMode = DataGridViewTriState.False;
    this.rGrid2.DefaultCellStyle = gridViewCellStyle5;
    this.rGrid2.Dock = DockStyle.Left;
    this.rGrid2.Location = new Point(0, 0);
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
    this.rGrid2.Size = new Size(350, 338);
    this.rGrid2.TabIndex = 16 /*0x10*/;
    this.rGrid2.MouseUp += new MouseEventHandler(this.rGrid2_MouseUp);
    this.splitter1.Dock = DockStyle.Top;
    this.splitter1.Location = new Point(0, 143);
    this.splitter1.Name = "splitter1";
    this.splitter1.Size = new Size(764, 3);
    this.splitter1.TabIndex = 16 /*0x10*/;
    this.splitter1.TabStop = false;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.BackgroundColor = Color.White;
    gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle7.BackColor = SystemColors.Control;
    gridViewCellStyle7.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle7.ForeColor = SystemColors.WindowText;
    gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
    this.rGrid1.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
    this.rGrid1.DataSource2 = (object) null;
    gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle8.BackColor = SystemColors.Window;
    gridViewCellStyle8.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle8.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
    this.rGrid1.DefaultCellStyle = gridViewCellStyle8;
    this.rGrid1.Dock = DockStyle.Top;
    this.rGrid1.Location = new Point(0, 0);
    this.rGrid1.Name = "rGrid1";
    gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle9.BackColor = SystemColors.Control;
    gridViewCellStyle9.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle9.ForeColor = SystemColors.WindowText;
    gridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle9.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
    this.rGrid1.RowHeadersDefaultCellStyle = gridViewCellStyle9;
    this.rGrid1.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid1.Size = new Size(764, 143);
    this.rGrid1.TabIndex = 15;
    this.rGrid1.MouseUp += new MouseEventHandler(this.rGrid1_MouseUp);
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.저장버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 3);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(764, 45);
    this.rPanel1.TabIndex = 14;
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(466, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 2;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
    this.저장버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.저장버튼.ButtonState = RButtonState.None;
    this.저장버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.저장버튼.ForeColor = Color.DimGray;
    this.저장버튼.Image = (Image) pas.mgp.Properties.Resources._1395148855_recv;
    this.저장버튼.Location = new Point(557, 11);
    this.저장버튼.Name = "저장버튼";
    this.저장버튼.Size = new Size(110, 23);
    this.저장버튼.TabIndex = 1;
    this.저장버튼.Text = "변경내용 반영";
    this.저장버튼.UseVisualStyleBackColor = true;
    this.저장버튼.Click += new EventHandler(this.저장버튼_Click);
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(668, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 0;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(800, 600);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00064);
    this.Text = nameof (dlgPAS00064);
    this.Load += new EventHandler(this.dlgPAS00064_Load);
    this.panel1.ResumeLayout(false);
    this.panel2.ResumeLayout(false);
    this.panel3.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid3).EndInit();
    ((ISupportInitialize) this.rGrid2).EndInit();
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
