// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00002
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00002 : RSkinForm
{
  private DataTable m_분류_작업요약Table = new DataTable("usp_분류_작업요약_Get");
  private DataTable m_분류_슈트조정_슈트별현황Table = new DataTable("usp_분류_슈트조정_슈트별현황_Get");
  private DataTable m_분류_슈트조정_슈트별현황_변경Table = new DataTable("usp_분류_슈트조정_슈트별현황_Get");
  private DataTable m_분류_슈트조정_가용슈트Table = new DataTable("usp_분류_슈트조정_가용슈트_Get");
  private IContainer components;
  private Panel panel1;
  private RButton 닫기버튼;
  private RGrid rGrid4;
  private RGrid rGrid2;
  private RGrid rGrid3;
  private RPanel rPanel1;
  private Label label3;
  private Label label2;
  private RTextBox rTextBox1;
  private RButton 조정버튼;
  private Label label1;
  private RLabel rLabel2;
  private RButton 재설정버튼;
  private RButton 반영버튼;

  public string 원배치번호 { get; set; }

  public dlgPAS00002()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    this.StartPosition = FormStartPosition.CenterParent;
    this.rLabel2.BackColor = this.rPanel1.PanelColor;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.rTextBox1;
    Common.RGrid_Initializing(this.rGrid2, true, false);
    Common.RGrid_Initializing(this.rGrid3, true, false);
    Common.RGrid_Initializing(this.rGrid4, true, false);
  }

  private void dlgPAS00002_Load(object sender, EventArgs e)
  {
    this.Text = Common.Title;
    this.Text2 = "슈트 조정 - " + this.원배치번호;
    this.조회버튼_Click((object) null, EventArgs.Empty);
  }

  private void 분류_슈트조정_슈트별현황_조회(조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_슈트조정_슈트별현황Table, DbProvider.GetParameter("@원배치번호", (object) this.원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.m_분류_슈트조정_슈트별현황_변경Table = this.m_분류_슈트조정_슈트별현황Table.Clone();
    this.rGrid2.DataSource2 = (object) this.m_분류_슈트조정_슈트별현황Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid2.Columns)
    {
      string headerText = column.HeaderText;
      column.Visible = true;
    }
    this.rGrid3.DataSource2 = (object) this.m_분류_슈트조정_슈트별현황_변경Table;
    Font font = new Font(this.rGrid3.Font.Name, this.rGrid3.Font.Size, FontStyle.Bold);
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid3.Columns)
    {
      string headerText = column.HeaderText;
      column.Visible = true;
      if (column.HeaderText == "조정슈트")
      {
        column.DefaultCellStyle.BackColor = SystemColors.Info;
        column.DefaultCellStyle.ForeColor = Color.Red;
        column.DefaultCellStyle.Font = font;
      }
    }
    this.rTextBox1.Text = this.m_분류_슈트조정_슈트별현황Table.Rows.Count.ToString();
  }

  private void 분류_슈트조정_가용슈트_조회(조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_슈트조정_가용슈트Table, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid4.DataSource2 = (object) this.m_분류_슈트조정_가용슈트Table;
    if (this.m_분류_슈트조정_가용슈트Table.Rows.Count > 0)
      return;
    List<string> stringList = new List<string>();
    foreach (DataRow row in (InternalDataCollectionBase) this.m_분류_슈트조정_슈트별현황Table.Rows)
    {
      if (!stringList.Contains(row["슈트번호"].ToString()))
        stringList.Add(row["슈트번호"].ToString());
    }
    this.m_분류_슈트조정_가용슈트Table.Rows.Clear();
    int num1 = Common.C2I((object) Common.Setting.CHUTES);
    int num2 = Common.C2I((object) Common.Setting.CHUTES_ERROR);
    string empty = string.Empty;
    for (int index = 0; index < num1; ++index)
    {
      if (index + 1 != num2)
      {
        string str = (index + 1).ToString("D3");
        if (!stringList.Contains(str))
          this.m_분류_슈트조정_가용슈트Table.Rows.Add((object) (index + 1).ToString("D3"));
      }
    }
    this.m_분류_슈트조정_가용슈트Table.AcceptChanges();
  }

  private void 조회버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.분류_슈트조정_슈트별현황_조회(조회구분자.실조회);
      this.분류_슈트조정_가용슈트_조회(조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      this.rTextBox1.Focus();
      this.rTextBox1.SelectAll();
      this.label3.Text = $"( 대상 : {this.rGrid2.Rows.Count}, 가용 : {this.rGrid4.Rows.Count}, 조정 : {this.rGrid3.Rows.Count} )";
      Cursor.Current = Cursors.Default;
    }
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.Close();

  private void rGrid2_MouseDown(object sender, MouseEventArgs e)
  {
  }

  private void rGrid4_MouseDown(object sender, MouseEventArgs e)
  {
  }

  private void dlgPAS00002_KeyDown(object sender, KeyEventArgs e)
  {
  }

  private void dlgPAS00002_KeyUp(object sender, KeyEventArgs e)
  {
  }

  private void 재설정버튼_Click(object sender, EventArgs e)
  {
    this.m_분류_슈트조정_슈트별현황_변경Table.Rows.Clear();
    this.조회버튼_Click((object) null, EventArgs.Empty);
  }

  private void 조정버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
        Common.ErrorMessageBox("대상 슈트를 선택하세요.");
      else if (this.rGrid4.SelectedRows == null || this.rGrid4.SelectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("가용 슈트를 선택하세요.");
      }
      else
      {
        int num1 = Common.C2I((object) this.rTextBox1.Text);
        int index1 = this.rGrid2.SelectedRows[0].Index;
        int index2 = this.rGrid4.SelectedRows[0].Index;
        int num2 = this.rGrid2.Rows.Count - index1;
        int num3 = this.rGrid4.Rows.Count - index2;
        if (num1 != num2 && num1 > num2)
          num1 = num2;
        if (num1 > this.rGrid4.Rows.Count)
        {
          Common.ErrorMessageBox(string.Format("대상 슈트수가 가용 슈트수의 최대 허용치를 벗어납니다.\r\n조정 가능한 가용 슈트의 수는 {0}개 입니다."));
          this.rTextBox1.Text = this.rGrid4.Rows.Count.ToString();
          this.rTextBox1.SelectAll();
        }
        else if (num2 > num3)
        {
          Common.ErrorMessageBox("대상 슈트수가 가용 슈트수를 초과합니다.");
        }
        else
        {
          int num4 = index1 != index2 ? index2 - index1 : 0;
          List<DataGridViewRow> dataGridViewRowList1 = new List<DataGridViewRow>();
          List<DataGridViewRow> dataGridViewRowList2 = new List<DataGridViewRow>();
          for (int index3 = index1; index3 < index1 + num1; ++index3)
          {
            this.m_분류_슈트조정_슈트별현황_변경Table.Rows.Add((object) this.rGrid2.Rows[index3].Cells["슈트번호"].Value.ToString(), (object) this.rGrid4.Rows[index3 + num4].Cells["가용슈트"].Value.ToString(), (object) this.rGrid2.Rows[index3].Cells["점코드"].Value.ToString(), (object) this.rGrid2.Rows[index3].Cells["점명"].Value.ToString(), (object) Common.C2I(this.rGrid2.Rows[index3].Cells["지시수"].Value));
            if (!dataGridViewRowList1.Contains(this.rGrid2.Rows[index3]))
              dataGridViewRowList1.Add(this.rGrid2.Rows[index3]);
            if (!dataGridViewRowList2.Contains(this.rGrid4.Rows[index3 + num4]))
              dataGridViewRowList2.Add(this.rGrid4.Rows[index3 + num4]);
          }
          foreach (DataGridViewRow dataGridViewRow in dataGridViewRowList1)
          {
            if (this.rGrid2.Rows.Contains(dataGridViewRow))
              this.rGrid2.Rows.Remove(dataGridViewRow);
          }
          this.rGrid2.Invalidate();
          foreach (DataGridViewRow dataGridViewRow in dataGridViewRowList2)
          {
            if (this.rGrid4.Rows.Contains(dataGridViewRow))
              this.rGrid4.Rows.Remove(dataGridViewRow);
          }
          this.rGrid4.Invalidate();
        }
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      this.label3.Text = $"( 대상 : {this.rGrid2.Rows.Count}, 가용 : {this.rGrid4.Rows.Count}, 조정 : {this.rGrid3.Rows.Count} )";
      Cursor.Current = Cursors.Default;
    }
  }

  private void 반영버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      if (this.rGrid3.Rows.Count <= 0)
        Common.ErrorMessageBox("반영할 내용이 없습니다.");
      else if (string.IsNullOrEmpty(this.원배치번호))
      {
        Common.ErrorMessageBox("배치번호 값이 없습니다.");
      }
      else
      {
        this.rGrid3.EndEdit();
        DataTable dataTable = new DataTable("슈트조정TABLE");
        dataTable.Columns.Add("슈트번호", typeof (string));
        dataTable.Columns.Add("조정슈트", typeof (string));
        foreach (DataGridViewRow row in (IEnumerable) this.rGrid3.Rows)
          dataTable.Rows.Add((object) row.Cells["슈트번호"].Value.ToString(), (object) row.Cells["조정슈트"].Value.ToString());
        using (StringWriter writer = new StringWriter())
        {
          dataTable.WriteXml((TextWriter) writer);
          DbProvider.Excute(Common.ConnectionString(), "usp_분류_슈트조정_슈트별현황_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) this.원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
          DbProvider.Excute(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_슈트조정_Set", DbProvider.GetParameter("@원배치번호", (object) this.원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@XML", (object) writer.ToString(), ParameterDirection.Input));
        }
        Common.OkMessageBox("슈트 조정 결과가 반영 되었습니다.");
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00002));
    this.panel1 = new Panel();
    this.닫기버튼 = new RButton();
    this.rGrid4 = new RGrid();
    this.rGrid2 = new RGrid();
    this.rGrid3 = new RGrid();
    this.rPanel1 = new RPanel();
    this.재설정버튼 = new RButton();
    this.label3 = new Label();
    this.label2 = new Label();
    this.rTextBox1 = new RTextBox();
    this.조정버튼 = new RButton();
    this.label1 = new Label();
    this.rLabel2 = new RLabel();
    this.반영버튼 = new RButton();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid4).BeginInit();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    ((ISupportInitialize) this.rGrid3).BeginInit();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid4);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid3);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 47);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(1000, 541);
    this.panel1.TabIndex = 0;
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(892, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 0;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.rGrid4.AllowUserToAddRows = false;
    this.rGrid4.AllowUserToDeleteRows = false;
    this.rGrid4.AlternateColor = Color.Empty;
    this.rGrid4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
    this.rGrid4.BackgroundColor = Color.White;
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Control;
    gridViewCellStyle1.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle1.ForeColor = SystemColors.WindowText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    this.rGrid4.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
    this.rGrid4.DataSource2 = (object) null;
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle2.BackColor = SystemColors.Window;
    gridViewCellStyle2.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle2.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid4.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid4.Location = new Point(442, 54);
    this.rGrid4.Name = "rGrid4";
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle3.BackColor = SystemColors.Control;
    gridViewCellStyle3.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle3.ForeColor = SystemColors.WindowText;
    gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle3.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    this.rGrid4.RowHeadersDefaultCellStyle = gridViewCellStyle3;
    this.rGrid4.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid4.Size = new Size(96 /*0x60*/, 484);
    this.rGrid4.TabIndex = 15;
    this.rGrid4.MouseDown += new MouseEventHandler(this.rGrid4_MouseDown);
    this.rGrid2.AllowUserToAddRows = false;
    this.rGrid2.AllowUserToDeleteRows = false;
    this.rGrid2.AlternateColor = Color.Empty;
    this.rGrid2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
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
    this.rGrid2.Location = new Point(6, 54);
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
    this.rGrid2.Size = new Size(430, 484);
    this.rGrid2.TabIndex = 12;
    this.rGrid2.MouseDown += new MouseEventHandler(this.rGrid2_MouseDown);
    this.rGrid3.AllowUserToAddRows = false;
    this.rGrid3.AllowUserToDeleteRows = false;
    this.rGrid3.AlternateColor = Color.Empty;
    this.rGrid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
    gridViewCellStyle8.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
    this.rGrid3.DefaultCellStyle = gridViewCellStyle8;
    this.rGrid3.Location = new Point(544, 54);
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
    this.rGrid3.Size = new Size(450, 484);
    this.rGrid3.TabIndex = 13;
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.재설정버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.반영버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label3);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rTextBox1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조정버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 3);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(988, 45);
    this.rPanel1.TabIndex = 14;
    this.재설정버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.재설정버튼.ButtonState = RButtonState.None;
    this.재설정버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.재설정버튼.ForeColor = Color.DimGray;
    this.재설정버튼.Image = (Image) pas.mgp.Properties.Resources._1395148967_refresh;
    this.재설정버튼.Location = new Point(710, 11);
    this.재설정버튼.Name = "재설정버튼";
    this.재설정버튼.Size = new Size(90, 23);
    this.재설정버튼.TabIndex = 18;
    this.재설정버튼.Text = "재설정";
    this.재설정버튼.UseVisualStyleBackColor = true;
    this.재설정버튼.Click += new EventHandler(this.재설정버튼_Click);
    this.label3.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label3.ForeColor = Color.Red;
    this.label3.Location = new Point(478, 11);
    this.label3.Name = "label3";
    this.label3.Size = new Size(317, 23);
    this.label3.TabIndex = 24;
    this.label3.Text = "( 대상 : 0, 가용 : 0, 조정 : 0 )";
    this.label3.TextAlign = ContentAlignment.MiddleLeft;
    this.label2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(430, 11);
    this.label2.Name = "label2";
    this.label2.Size = new Size(57, 23);
    this.label2.TabIndex = 23;
    this.label2.Text = "합니다.";
    this.label2.TextAlign = ContentAlignment.MiddleLeft;
    this.rTextBox1.FocusedColor = SystemColors.Info;
    this.rTextBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.rTextBox1.ForeColor = Color.Red;
    this.rTextBox1.Location = new Point(137, 12);
    this.rTextBox1.Name = "rTextBox1";
    this.rTextBox1.Size = new Size(60, 20);
    this.rTextBox1.TabIndex = 22;
    this.rTextBox1.TextAlign = HorizontalAlignment.Center;
    this.rTextBox1.TextType = RTextBoxType.OnlyNumeric;
    this.조정버튼.ButtonState = RButtonState.None;
    this.조정버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조정버튼.ForeColor = Color.DimGray;
    this.조정버튼.Image = (Image) pas.mgp.Properties.Resources._1459937077_table_relationship;
    this.조정버튼.Location = new Point(334, 11);
    this.조정버튼.Name = "조정버튼";
    this.조정버튼.Size = new Size(90, 23);
    this.조정버튼.TabIndex = 16 /*0x10*/;
    this.조정버튼.Text = "조 정";
    this.조정버튼.UseVisualStyleBackColor = true;
    this.조정버튼.Click += new EventHandler(this.조정버튼_Click);
    this.label1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(203, 11);
    this.label1.Name = "label1";
    this.label1.Size = new Size(140, 23);
    this.label1.TabIndex = 21;
    this.label1.Text = "개의 슈트를 빈 슈트로";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(6, 11);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(130, 23);
    this.rLabel2.TabIndex = 19;
    this.rLabel2.Text = "선택한 슈트로 부터";
    this.반영버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.반영버튼.ButtonState = RButtonState.None;
    this.반영버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.반영버튼.ForeColor = Color.DimGray;
    this.반영버튼.Image = (Image) pas.mgp.Properties.Resources._1395148853_save_as;
    this.반영버튼.Location = new Point(801, 11);
    this.반영버튼.Name = "반영버튼";
    this.반영버튼.Size = new Size(90, 23);
    this.반영버튼.TabIndex = 17;
    this.반영버튼.Text = "반 영";
    this.반영버튼.UseVisualStyleBackColor = true;
    this.반영버튼.Click += new EventHandler(this.반영버튼_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1024 /*0x0400*/, 600);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00002);
    this.Text = nameof (dlgPAS00002);
    this.Load += new EventHandler(this.dlgPAS00002_Load);
    this.KeyDown += new KeyEventHandler(this.dlgPAS00002_KeyDown);
    this.KeyUp += new KeyEventHandler(this.dlgPAS00002_KeyUp);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid4).EndInit();
    ((ISupportInitialize) this.rGrid2).EndInit();
    ((ISupportInitialize) this.rGrid3).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.rPanel1.PerformLayout();
    this.ResumeLayout(false);
  }
}
