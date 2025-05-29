// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00062
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

public class dlgPAS00062 : RSkinForm
{
  private IContainer components;
  private Panel panel1;
  private RButton 닫기버튼;
  private RButton 저장버튼;
  private Label label1;
  private RTextBox rTextBox1;
  private RTextBox rTextBox2;
  private Label label2;
  private RPanel rPanel1;

  public string 배치번호 { get; set; }

  public string 배치명 { get; set; }

  public dlgPAS00062()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    this.rTextBox1.FocusedColor = SystemColors.Info;
    this.rTextBox2.FocusedColor = SystemColors.Info;
    this.rTextBox1.ForeColor = Color.Blue;
    this.rTextBox2.ForeColor = Color.Red;
    this.StartPosition = FormStartPosition.CenterParent;
  }

  private void dlgPAS00062_Load(object sender, EventArgs e)
  {
    this.Text = Common.Title;
    this.Text2 = $"배치명 변경 - {this.배치번호}";
    this.rTextBox1.Text = this.배치명;
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

  private void 저장버튼_Click(object sender, EventArgs e)
  {
    try
    {
      using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
      {
        dbProvider2.Initialize("usp_관리_배치명변경_Set", "@배치번호", "@배치명");
        dbProvider2.Update((object) this.배치번호, (object) this.rTextBox2.Text);
        dbProvider2.Commit();
      }
      Common.OkMessageBox("배치명을 변경 하였습니다.");
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00062));
    this.panel1 = new Panel();
    this.저장버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.label1 = new Label();
    this.rTextBox1 = new RTextBox();
    this.rTextBox2 = new RTextBox();
    this.rPanel1 = new RPanel();
    this.label2 = new Label();
    this.panel1.SuspendLayout();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rTextBox2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rTextBox1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 47);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(351, 116);
    this.panel1.TabIndex = 0;
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
    this.label1.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(5, 56);
    this.label1.Name = "label1";
    this.label1.Size = new Size(243, 23);
    this.label1.TabIndex = 15;
    this.label1.Text = "선택한 배치명 ";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.rTextBox1.FocusedColor = SystemColors.Window;
    this.rTextBox1.Location = new Point(101, 56);
    this.rTextBox1.Name = "rTextBox1";
    this.rTextBox1.Size = new Size(238, 21);
    this.rTextBox1.TabIndex = 16 /*0x10*/;
    this.rTextBox1.TextType = RTextBoxType.Both;
    this.rTextBox2.FocusedColor = SystemColors.Window;
    this.rTextBox2.Location = new Point(101, 83);
    this.rTextBox2.Name = "rTextBox2";
    this.rTextBox2.Size = new Size(238, 21);
    this.rTextBox2.TabIndex = 18;
    this.rTextBox2.TextType = RTextBoxType.Both;
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
    this.label2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(5, 83);
    this.label2.Name = "label2";
    this.label2.Size = new Size(243, 23);
    this.label2.TabIndex = 19;
    this.label2.Text = "변경할 배치명 ";
    this.label2.TextAlign = ContentAlignment.MiddleLeft;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(375, 175);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00062);
    this.Text = nameof (dlgPAS00062);
    this.Load += new EventHandler(this.dlgPAS00062_Load);
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.rPanel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
