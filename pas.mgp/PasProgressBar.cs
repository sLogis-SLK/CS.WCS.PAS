// Decompiled with JetBrains decompiler
// Type: pas.mgp.PasProgressBar
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class PasProgressBar : Control
{
  private long m_lMinValue;
  private long m_lMaxValue;
  private long m_lValue;

  public long MinValue
  {
    get => this.m_lMinValue;
    set
    {
      if (value < 0L)
      {
        int num1 = (int) MessageBox.Show("최소 설정값은 음수를 허용하지 않습니다.");
      }
      else if (value > this.MaxValue)
      {
        int num2 = (int) MessageBox.Show("최소 설정값은 최대 설정값을 넘을 수 없습니다.");
      }
      else
      {
        this.m_lMinValue = value;
        this.Invalidate();
      }
    }
  }

  public long MaxValue
  {
    get => this.m_lMaxValue;
    set
    {
      if (value < 0L)
      {
        int num1 = (int) MessageBox.Show("최대 설정값은 음수를 허용하지 않습니다.");
      }
      else if (value < this.MinValue)
      {
        int num2 = (int) MessageBox.Show("최대 설정값은 최소 설정값보다 작을 수 없습니다.");
      }
      else
      {
        this.m_lMaxValue = value;
        this.Invalidate();
      }
    }
  }

  public long Value
  {
    get => this.m_lValue;
    set
    {
      if (this.MaxValue < value)
      {
        int num1 = (int) MessageBox.Show("현재값은 최대 설정값보다 작아야 합니다.");
      }
      else if (this.MinValue > value)
      {
        int num2 = (int) MessageBox.Show("현재값은 최소 설정값보다 커야 합니다.");
      }
      else
      {
        this.m_lValue = value;
        this.Invalidate();
      }
    }
  }

  public int Percent
  {
    get
    {
      int percent = 0;
      try
      {
        percent = (int) ((double) this.Value / ((double) this.MaxValue - (double) this.MinValue) * 100.0);
      }
      catch
      {
      }
      return percent;
    }
  }

  public string PercentString => this.Percent.ToString() + "%";

  public PasProgressBar()
  {
    this.DoubleBuffered = true;
    this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
    this.BackColor = Color.White;
    this.Size = new Size(100, 23);
  }

  protected override void OnResize(EventArgs e)
  {
    base.OnResize(e);
    this.Invalidate();
  }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
    {
      using (Graphics graphics = Graphics.FromImage((Image) bitmap))
      {
        graphics.Clear(this.BackColor);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        Rectangle rect1 = new Rectangle();
        rect1.Width = this.Width;
        rect1.Height = this.Height;
        LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect1, this.BackColor, this.BackColor, LinearGradientMode.Horizontal);
        linearGradientBrush.InterpolationColors = new ColorBlend()
        {
          Colors = new Color[3]
          {
            Color.Green,
            Color.Yellow,
            Color.Red
          },
          Positions = new float[3]{ 0.0f, 0.5f, 1f }
        };
        graphics.FillRectangle((Brush) linearGradientBrush, rect1);
        int num = this.Width * this.Percent / 100;
        Rectangle rect2 = new Rectangle();
        rect2.X = num;
        rect2.Y = 0;
        rect2.Width = this.Width - num;
        rect2.Height = this.Height;
        Brush brush = (Brush) new SolidBrush(this.BackColor);
        graphics.FillRectangle(brush, rect2);
        Rectangle rect3 = new Rectangle();
        rect3.Width = this.Width - 1;
        rect3.Height = this.Height - 1;
        Pen pen = new Pen(SystemColors.ActiveCaption);
        graphics.DrawRectangle(pen, rect3);
        linearGradientBrush.Dispose();
        brush.Dispose();
        pen.Dispose();
      }
      e.Graphics.DrawImage((Image) bitmap, 0, 0);
    }
  }
}
