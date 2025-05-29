// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmLoading
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

// using pas.mgp.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmLoading : Form
{
  private static frmLoading Loading;
  private IContainer components;
  private PictureBox pictureBox1;
  private Label label1;

  public frmLoading()
  {
    this.InitializeComponent();
    this.TopMost = true;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    e.Graphics.Clear(Color.White);
    using (Pen pen = new Pen(Brushes.Black, 2f))
    {
      Rectangle clientRectangle = this.ClientRectangle;
      e.Graphics.DrawRectangle(pen, clientRectangle);
    }
  }

  private void frmLoading_Click(object sender, EventArgs e)
  {
  }

  public static void ShowLoading()
  {
    if (frmLoading.Loading != null)
    {
      frmLoading.Loading.Dispose();
      frmLoading.Loading = (frmLoading) null;
    }
    Thread thread = new Thread(new ThreadStart(frmLoading.ShowForm));
    thread.IsBackground = true;
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
  }

  private static void ShowForm()
  {
    frmLoading.Loading = new frmLoading();
    frmLoading.Loading.ShowInTaskbar = false;
    frmLoading.Loading.TopMost = true;
    Application.Run((Form) frmLoading.Loading);
  }

  public static void CloseLoading()
  {
    if (frmLoading.Loading == null)
      return;
    frmLoading.Loading.Invoke((Delegate) new frmLoading.CloseEventHandler(frmLoading.CloseFormInternal));
  }

  private static void CloseFormInternal()
  {
    if (frmLoading.Loading == null)
      return;
    frmLoading.Loading.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.pictureBox1 = new PictureBox();
    this.label1 = new Label();
    ((ISupportInitialize) this.pictureBox1).BeginInit();
    this.SuspendLayout();
    this.pictureBox1.Image = (Image) pas.mgp.Properties.Resources.LOADING;
    this.pictureBox1.Location = new Point(12, 10);
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.Size = new Size(50, 50);
    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
    this.pictureBox1.TabIndex = 0;
    this.pictureBox1.TabStop = false;
    this.label1.Font = new Font("굴림체", 9.75f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label1.Location = new Point(68, 9);
    this.label1.Name = "label1";
    this.label1.Size = new Size(193, 53);
    this.label1.TabIndex = 1;
    this.label1.Text = "잠시만 기다려 주세요...";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackColor = Color.White;
    this.ClientSize = new Size(270, 70);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.pictureBox1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmLoading);
    this.Text = nameof (frmLoading);
    this.Click += new EventHandler(this.frmLoading_Click);
    ((ISupportInitialize) this.pictureBox1).EndInit();
    this.ResumeLayout(false);
  }

  private delegate void CloseEventHandler();
}
