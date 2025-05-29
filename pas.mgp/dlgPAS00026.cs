// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00026
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00026 : RSkinForm
{
  private IContainer components;
  private Panel panel1;
  private CheckBox checkBox2;
  private CheckBox checkBox1;
  private RButton 선택버튼;
  private RButton 취소버튼;

  public int 선택값 { get; set; }

  public dlgPAS00026()
  {
    this.InitializeComponent();
    this.BackColor = Color.White;
    this.checkBox1.Checked = true;
    this.checkBox2.Checked = false;
    this.StartPosition = FormStartPosition.CenterParent;
  }

  private void dlgPAS00026_Load(object sender, EventArgs e)
  {
    this.Text = Common.Title;
    this.Text2 = "거래명세서 선택";
  }

  private void 취소버튼_Click(object sender, EventArgs e)
  {
    this.선택값 = 0;
    this.DialogResult = DialogResult.Cancel;
  }

  private void 선택버튼_Click(object sender, EventArgs e)
  {
    if (this.checkBox1.Checked)
      ++this.선택값;
    if (this.checkBox2.Checked)
      this.선택값 += 2;
    this.DialogResult = DialogResult.OK;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00026));
    this.panel1 = new Panel();
    this.선택버튼 = new RButton();
    this.checkBox2 = new CheckBox();
    this.checkBox1 = new CheckBox();
    this.취소버튼 = new RButton();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.취소버튼);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.선택버튼);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.checkBox2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.panel1.Location = new Point(12, 47);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(246, 96 /*0x60*/);
    this.panel1.TabIndex = 0;
    this.선택버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.선택버튼.ButtonState = RButtonState.None;
    this.선택버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.선택버튼.ForeColor = Color.DimGray;
    this.선택버튼.Image = (Image) pas.mgp.Properties.Resources._1395148944_flag_mark_red;
    this.선택버튼.Location = new Point(33, 64 /*0x40*/);
    this.선택버튼.Name = "선택버튼";
    this.선택버튼.Size = new Size(90, 23);
    this.선택버튼.TabIndex = 6;
    this.선택버튼.Text = "선 택";
    this.선택버튼.UseVisualStyleBackColor = true;
    this.선택버튼.Click += new EventHandler(this.선택버튼_Click);
    this.checkBox2.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox2.ForeColor = Color.DimGray;
    this.checkBox2.Location = new Point(10, 35);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new Size(233, 23);
    this.checkBox2.TabIndex = 4;
    this.checkBox2.Text = "2. 토탈 거래명세서";
    this.checkBox2.UseVisualStyleBackColor = true;
    this.checkBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(10, 10);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(233, 23);
    this.checkBox1.TabIndex = 3;
    this.checkBox1.Text = "1. 박스별 거래명세서";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.취소버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.취소버튼.ButtonState = RButtonState.None;
    this.취소버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.취소버튼.ForeColor = Color.DimGray;
    this.취소버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.취소버튼.Location = new Point(124, 64 /*0x40*/);
    this.취소버튼.Name = "취소버튼";
    this.취소버튼.Size = new Size(90, 23);
    this.취소버튼.TabIndex = 7;
    this.취소버튼.Text = "취 소";
    this.취소버튼.UseVisualStyleBackColor = true;
    this.취소버튼.Click += new EventHandler(this.취소버튼_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(270, 155);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00026);
    this.Text = nameof (dlgPAS00026);
    this.Load += new EventHandler(this.dlgPAS00026_Load);
    this.panel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
