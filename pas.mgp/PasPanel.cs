// Decompiled with JetBrains decompiler
// Type: pas.mgp.PasPanel
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System.Drawing;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class PasPanel : Panel
{
  public bool PanelSeperator { get; set; }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    if (!this.PanelSeperator)
      return;
    ControlPaint.DrawBorder3D(e.Graphics, new Rectangle()
    {
      X = -2,
      Y = this.Height + 2,
      Width = this.Width + 4,
      Height = -2
    });
  }
}
