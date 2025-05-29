// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00010
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
// using pas.mgp.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00010 : Form
{
  private IContainer components;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private Panel panel1;
  private RPanel rPanel3;
  private RGrid rGrid1;
  private RButton 조회버튼;
  private RLabel rLabel1;
  private ComboBox comboBox1;
  private CheckBox checkBox1;
  private RButton 로컬새로고침버튼;
  private RButton rButton2;
  private RButton rButton1;

  public frmPAS00010()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    Common.RGrid_Initializing(this.rGrid1, false);
    this.comboBox1.Items.Add((object) "5초");
    this.comboBox1.Items.Add((object) "15초");
    this.comboBox1.Items.Add((object) "30초");
    this.comboBox1.Items.Add((object) "1분");
    this.comboBox1.SelectedIndex = 3;
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
    this.pasPanel1 = new PasPanel();
    this.닫기버튼 = new RButton();
    this.panel1 = new Panel();
    this.rPanel3 = new RPanel();
    this.rGrid1 = new RGrid();
    this.조회버튼 = new RButton();
    this.rLabel1 = new RLabel();
    this.comboBox1 = new ComboBox();
    this.checkBox1 = new CheckBox();
    this.로컬새로고침버튼 = new RButton();
    this.rButton1 = new RButton();
    this.rButton2 = new RButton();
    this.pasPanel1.SuspendLayout();
    this.rPanel3.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.SuspendLayout();
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 3;
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
    this.panel1.Dock = DockStyle.Top;
    this.panel1.Location = new Point(0, 45);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(1000, 250);
    this.panel1.TabIndex = 4;
    this.rPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel3.BackColor = Color.Transparent;
    this.rPanel3.BorderColor = Color.MistyRose;
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.rButton2);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.rButton1);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.로컬새로고침버튼);
    this.rPanel3.EdgeRadius = 10;
    this.rPanel3.Location = new Point(6, 300);
    this.rPanel3.Name = "rPanel3";
    this.rPanel3.PanelColor = Color.Snow;
    this.rPanel3.Size = new Size(988, 45);
    this.rPanel3.TabIndex = 5;
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
    this.rGrid1.Location = new Point(6, 351);
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
    this.rGrid1.Size = new Size(988, 247);
    this.rGrid1.TabIndex = 6;
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(807, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 2;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(12, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(100, 23);
    this.rLabel1.TabIndex = 5;
    this.rLabel1.Text = "현황 자동갱신";
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(113, 12);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(100, 20);
    this.comboBox1.TabIndex = 7;
    this.checkBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(219, 11);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(100, 23);
    this.checkBox1.TabIndex = 8;
    this.checkBox1.Text = "사용";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.로컬새로고침버튼.ButtonState = RButtonState.None;
    this.로컬새로고침버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.로컬새로고침버튼.ForeColor = Color.DimGray;
    this.로컬새로고침버튼.Image = (Image) pas.mgp.Properties.Resources._1395148967_refresh;
    this.로컬새로고침버튼.Location = new Point(6, 11);
    this.로컬새로고침버튼.Name = "로컬새로고침버튼";
    this.로컬새로고침버튼.Size = new Size(90, 23);
    this.로컬새로고침버튼.TabIndex = 2;
    this.로컬새로고침버튼.Text = "새로고침";
    this.로컬새로고침버튼.UseVisualStyleBackColor = true;
    this.rButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rButton1.ButtonState = RButtonState.None;
    this.rButton1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.rButton1.ForeColor = Color.DimGray;
    this.rButton1.Image = (Image) pas.mgp.Properties.Resources._1395148967_refresh;
    this.rButton1.Location = new Point(801, 11);
    this.rButton1.Name = "rButton1";
    this.rButton1.Size = new Size(90, 23);
    this.rButton1.TabIndex = 3;
    this.rButton1.Text = "배치개시";
    this.rButton1.UseVisualStyleBackColor = true;
    this.rButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rButton2.ButtonState = RButtonState.None;
    this.rButton2.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.rButton2.ForeColor = Color.DimGray;
    this.rButton2.Image = (Image) pas.mgp.Properties.Resources._1395148967_refresh;
    this.rButton2.Location = new Point(892, 11);
    this.rButton2.Name = "rButton2";
    this.rButton2.Size = new Size(90, 23);
    this.rButton2.TabIndex = 4;
    this.rButton2.Text = "배치종료";
    this.rButton2.UseVisualStyleBackColor = true;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.Controls.Add((System.Windows.Forms.Control) this.rPanel3);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00010);
    this.Text = nameof (frmPAS00010);
    this.pasPanel1.ResumeLayout(false);
    this.rPanel3.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.ResumeLayout(false);
  }
}
