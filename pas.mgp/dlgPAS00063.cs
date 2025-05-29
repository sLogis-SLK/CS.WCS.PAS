// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00063
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00063 : RSkinForm
{
  private IContainer components;
  private Panel panel1;
  private RButton 닫기버튼;
  private RButton 저장버튼;
  private Label label1;
  private Label label2;
  private RPanel rPanel1;
  private ComboBox comboBox2;
  private ComboBox comboBox1;

  public string 분류번호 { get; set; }

  public string 출하위치 { get; set; }

  public dlgPAS00063()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    this.comboBox1.Items.Add((object) "사용안함");
    this.comboBox1.Items.Add((object) "A라인");
    this.comboBox1.Items.Add((object) "B라인");
    this.comboBox1.Items.Add((object) "균등");
    this.comboBox1.SelectedIndex = 3;
    this.comboBox2.Items.Add((object) "사용안함");
    this.comboBox2.Items.Add((object) "A라인");
    this.comboBox2.Items.Add((object) "B라인");
    this.comboBox2.Items.Add((object) "균등");
    this.comboBox2.SelectedIndex = 3;
    this.StartPosition = FormStartPosition.CenterParent;
  }

  private void dlgPAS00063_Load(object sender, EventArgs e)
  {
    this.Text = Common.Title;
    this.Text2 = $"출하위치 변경 - {this.분류번호}";
    if (string.IsNullOrEmpty(this.출하위치))
      return;
    this.comboBox1.Text = this.출하위치;
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

  private void 저장버튼_Click(object sender, EventArgs e)
  {
    try
    {
      using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
      {
        dbProvider2.Initialize("usp_관리_출하위치변경_Set", "@분류번호", "@출하구분");
        dbProvider2.Update((object) this.분류번호, (object) this.comboBox2.Text);
        dbProvider2.Commit();
      }
      Common.OkMessageBox("출하위치를 변경 하였습니다.");
      this.DialogResult = DialogResult.OK;
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00063));
    this.panel1 = new Panel();
    this.label2 = new Label();
    this.label1 = new Label();
    this.rPanel1 = new RPanel();
    this.닫기버튼 = new RButton();
    this.저장버튼 = new RButton();
    this.comboBox1 = new ComboBox();
    this.comboBox2 = new ComboBox();
    this.panel1.SuspendLayout();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.comboBox2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 47);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(351, 116);
    this.panel1.TabIndex = 0;
    this.label2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(5, 83);
    this.label2.Name = "label2";
    this.label2.Size = new Size(243, 23);
    this.label2.TabIndex = 19;
    this.label2.Text = "변경될 출하위치";
    this.label2.TextAlign = ContentAlignment.MiddleLeft;
    this.label1.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(5, 56);
    this.label1.Name = "label1";
    this.label1.Size = new Size(243, 23);
    this.label1.TabIndex = 15;
    this.label1.Text = "현재 출하위치";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.저장버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 3);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(339, 45);
    this.rPanel1.TabIndex = 14;
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(243, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 0;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.저장버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.저장버튼.ButtonState = RButtonState.None;
    this.저장버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.저장버튼.ForeColor = Color.DimGray;
    this.저장버튼.Image = (Image) pas.mgp.Properties.Resources._1395148853_save_as;
    this.저장버튼.Location = new Point(152, 11);
    this.저장버튼.Name = "저장버튼";
    this.저장버튼.Size = new Size(90, 23);
    this.저장버튼.TabIndex = 1;
    this.저장버튼.Text = "변 경";
    this.저장버튼.UseVisualStyleBackColor = true;
    this.저장버튼.Click += new EventHandler(this.저장버튼_Click);
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(109, 56);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(230, 20);
    this.comboBox1.TabIndex = 20;
    this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox2.FormattingEnabled = true;
    this.comboBox2.Location = new Point(109, 82);
    this.comboBox2.Name = "comboBox2";
    this.comboBox2.Size = new Size(230, 20);
    this.comboBox2.TabIndex = 21;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(375, 175);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00063);
    this.Text = nameof (dlgPAS00063);
    this.Load += new EventHandler(this.dlgPAS00063_Load);
    this.panel1.ResumeLayout(false);
    this.rPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
