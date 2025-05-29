// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmMessageBox
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

public class frmMessageBox : RSkinForm
{
  private Timer m_oMainTimer;
  private IContainer components;
  private Panel panel1;
  private Label label1;
  private RButton btnNo;
  private RButton btnYes;
  private RButton btnOK;

  private bool IsClicked { get; set; }

  private string Message
  {
    get => this.label1.Text;
    set => this.label1.Text = value;
  }

  private int Interval { get; set; }

  private bool IsTimerButton { get; set; }

  public frmMessageBox()
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.Text2 = "메시지";
    this.StartPosition = FormStartPosition.CenterParent;
    this.btnYes.Location = new Point(this.panel1.Width / 2 - 2 - this.btnYes.Width, this.btnYes.Location.Y);
    this.btnNo.Location = new Point(this.panel1.Width / 2 + 2, this.btnNo.Location.Y);
    this.btnOK.Location = new Point((this.panel1.Width - this.btnOK.Width) / 2, this.btnOK.Location.Y);
    this.m_oMainTimer = new Timer();
    this.m_oMainTimer.Interval = 1000;
    this.m_oMainTimer.Tick += new EventHandler(this.m_oMainTimer_Tick);
  }

  private void m_oMainTimer_Tick(object sender, EventArgs e)
  {
    ++this.Interval;
    if (this.Interval >= 3)
    {
      this.m_oMainTimer.Enabled = false;
      this.IsClicked = true;
      this.DialogResult = DialogResult.OK;
    }
    else
    {
      if (!this.IsTimerButton)
        return;
      this.btnOK.Text = $"확인 [-{(3 - this.Interval).ToString()}]";
    }
  }

  private void btnYes_Click(object sender, EventArgs e)
  {
    this.IsClicked = true;
    this.DialogResult = DialogResult.Yes;
  }

  private void btnNo_Click(object sender, EventArgs e)
  {
    this.IsClicked = true;
    this.DialogResult = DialogResult.No;
  }

  private void btnOK_Click(object sender, EventArgs e)
  {
    this.IsClicked = true;
    this.DialogResult = DialogResult.OK;
  }

  private void frmMessageBox_FormClosing(object sender, FormClosingEventArgs e)
  {
    if (this.IsClicked)
      return;
    this.DialogResult = DialogResult.No;
  }

  public static DialogResult Show(string sMessage) => frmMessageBox.Show(sMessage, "메시지", true);

  public static DialogResult Show(string sMessage, string sTitle)
  {
    return frmMessageBox.Show(sMessage, sTitle, true);
  }

  public static DialogResult Show(string sMessage, string sTitle, bool bButton)
  {
    return frmMessageBox.Show(sMessage, sTitle, bButton, false);
  }

  public static DialogResult Show(string sMessage, string sTitle, bool bButton, bool bTimerButton)
  {
    frmMessageBox frmMessageBox = new frmMessageBox();
    frmMessageBox.Text2 = sTitle;
    frmMessageBox.Message = sMessage;
    frmMessageBox.btnYes.Visible = bButton;
    frmMessageBox.btnNo.Visible = bButton;
    frmMessageBox.btnOK.Visible = !bButton;
    if (!bButton && bTimerButton)
    {
      frmMessageBox.IsTimerButton = true;
      frmMessageBox.btnOK.Text = "확인 [-3]";
      frmMessageBox.m_oMainTimer.Enabled = true;
    }
    return frmMessageBox.ShowDialog();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMessageBox));
    this.panel1 = new Panel();
    this.btnOK = new RButton();
    this.btnNo = new RButton();
    this.btnYes = new RButton();
    this.label1 = new Label();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.btnOK);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.btnNo);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.btnYes);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.panel1.Location = new Point(12, 46);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(326, 102);
    this.panel1.TabIndex = 1;
    this.btnOK.ButtonState = RButtonState.None;
    this.btnOK.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.btnOK.ForeColor = Color.DimGray;
    this.btnOK.Image = (Image) pas.mgp.Properties.Resources._1397196738_Dialog_Apply;
    this.btnOK.Location = new Point(80 /*0x50*/, 61);
    this.btnOK.Name = "btnOK";
    this.btnOK.Size = new Size(100, 32 /*0x20*/);
    this.btnOK.TabIndex = 3;
    this.btnOK.Text = "확인";
    this.btnOK.UseVisualStyleBackColor = true;
    this.btnOK.Click += new EventHandler(this.btnOK_Click);
    this.btnNo.ButtonState = RButtonState.None;
    this.btnNo.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.btnNo.ForeColor = Color.DimGray;
    this.btnNo.Image = (Image) pas.mgp.Properties.Resources._1397196739_gtk_dialog_error;
    this.btnNo.Location = new Point(125, 61);
    this.btnNo.Name = "btnNo";
    this.btnNo.Size = new Size(105, 32 /*0x20*/);
    this.btnNo.TabIndex = 2;
    this.btnNo.Text = "아니오";
    this.btnNo.UseVisualStyleBackColor = true;
    this.btnNo.Click += new EventHandler(this.btnNo_Click);
    this.btnYes.ButtonState = RButtonState.None;
    this.btnYes.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.btnYes.ForeColor = Color.DimGray;
    this.btnYes.Image = (Image) pas.mgp.Properties.Resources._1397196738_Dialog_Apply;
    this.btnYes.Location = new Point(32 /*0x20*/, 61);
    this.btnYes.Name = "btnYes";
    this.btnYes.Size = new Size(85, 32 /*0x20*/);
    this.btnYes.TabIndex = 1;
    this.btnYes.Text = "네";
    this.btnYes.UseVisualStyleBackColor = true;
    this.btnYes.Click += new EventHandler(this.btnYes_Click);
    this.label1.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(30, 10);
    this.label1.Name = "label1";
    this.label1.Size = new Size(266, 48 /*0x30*/);
    this.label1.TabIndex = 0;
    this.label1.Text = "프로그램을 종료합니다.\r\n종료 하시겠습니까?";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(350, 160 /*0xA0*/);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.MinimumSize = new Size(290, 160 /*0xA0*/);
    this.Name = nameof (frmMessageBox);
    this.FormClosing += new FormClosingEventHandler(this.frmMessageBox_FormClosing);
    this.panel1.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
