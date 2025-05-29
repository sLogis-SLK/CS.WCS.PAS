// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00901
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00901 : RSkinForm
{
  private IContainer components;
  private Panel panel1;
  private TextBox textBox1;

  public dlgPAS00901(string sPath)
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.Text2 = "업데이트 정보확인";
    this.BackColor = Color.White;
    this.textBox1.BackColor = Color.White;
    this.textBox1.ReadOnly = true;
    this.StartPosition = FormStartPosition.CenterParent;
    using (StreamReader streamReader = new StreamReader(sPath, Encoding.Default))
      this.textBox1.Text = streamReader.ReadToEnd();
    this.textBox1.SelectionStart = 0;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00901));
    this.panel1 = new Panel();
    this.textBox1 = new TextBox();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.Controls.Add((Control) this.textBox1);
    this.panel1.Location = new Point(12, 46);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(726, 482);
    this.panel1.TabIndex = 0;
    this.textBox1.BorderStyle = BorderStyle.None;
    this.textBox1.Dock = DockStyle.Fill;
    this.textBox1.Location = new Point(0, 0);
    this.textBox1.Multiline = true;
    this.textBox1.Name = "textBox1";
    this.textBox1.ScrollBars = ScrollBars.Vertical;
    this.textBox1.Size = new Size(726, 482);
    this.textBox1.TabIndex = 0;
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(750, 540);
    this.Controls.Add((Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00901);
    this.Text = "dlgPAS00001";
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.ResumeLayout(false);
  }
}
