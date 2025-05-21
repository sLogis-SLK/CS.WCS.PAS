using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace pas.smp.Controls
{
    [ToolboxItem(true)] // 도구 상자에 보이게 설정
    public partial class SMPCheckBox : CheckBox
    {
        private bool _isChecked = false;

        public SMPCheckBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.AutoSize = false;
        }

        //사용자 정의 Checked 속성
        [Browsable(true)]
        [DefaultValue(false)]
        public new bool Checked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    Invalidate(); // 다시 그리기
                    OnCheckedChanged(EventArgs.Empty); // 이벤트 발생
                    //MessageBox.Show("체크박스 상태확인 " + _isChecked);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(this.BackColor);

            int boxSize = 30;
            Rectangle checkRect = new Rectangle(5, (this.Height - boxSize) / 2, boxSize, boxSize);

            // 체크 박스 테두리
            using (Pen borderPen = new Pen(Color.Black, 2))
            {
                g.DrawRectangle(borderPen, checkRect);
            }

            // 체크 표시 직접 그리기
            if (_isChecked)
            {
                using (Pen checkPen = new Pen(Color.Black, 3))
                {
                    Point p1 = new Point(checkRect.Left + 6, checkRect.Top + checkRect.Height / 2);
                    Point p2 = new Point(checkRect.Left + (boxSize / 2) - 2, checkRect.Bottom - 6);
                    Point p3 = new Point(checkRect.Right - 5, checkRect.Top + 6);
                    g.DrawLines(checkPen, new Point[] { p1, p2, p3 });
                }
            }

            // 텍스트 출력
            Rectangle textRect = new Rectangle(checkRect.Right + 10, 0, this.Width - checkRect.Right - 10, this.Height);
            TextRenderer.DrawText(g, this.Text, this.Font, textRect, this.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Checked = !this.Checked;
            this.Invalidate(); // 다시 그리기
        }
    }
}
