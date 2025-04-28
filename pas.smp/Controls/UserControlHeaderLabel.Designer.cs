
namespace pas.smp.Controls
{
    partial class UserControlHeaderLabel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.HeaderText = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel1 = new Infragistics.Win.Misc.UltraPanel();
            this.MainText = new Infragistics.Win.Misc.UltraLabel();
            this.ultraPanel1.ClientArea.SuspendLayout();
            this.ultraPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderText
            // 
            appearance1.BackColor = System.Drawing.Color.LightSlateGray;
            appearance1.FontData.BoldAsString = "True";
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.HeaderText.Appearance = appearance1;
            this.HeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderText.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HeaderText.Location = new System.Drawing.Point(0, 0);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(344, 25);
            this.HeaderText.TabIndex = 1;
            this.HeaderText.Text = "Header Text";
            // 
            // ultraPanel1
            // 
            // 
            // ultraPanel1.ClientArea
            // 
            this.ultraPanel1.ClientArea.Controls.Add(this.MainText);
            this.ultraPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraPanel1.Location = new System.Drawing.Point(0, 25);
            this.ultraPanel1.Name = "ultraPanel1";
            this.ultraPanel1.Size = new System.Drawing.Size(344, 87);
            this.ultraPanel1.TabIndex = 2;
            // 
            // MainText
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.MainText.Appearance = appearance2;
            this.MainText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainText.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MainText.Location = new System.Drawing.Point(0, 0);
            this.MainText.Name = "MainText";
            this.MainText.Size = new System.Drawing.Size(344, 87);
            this.MainText.TabIndex = 0;
            // 
            // UserControlHeaderLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ultraPanel1);
            this.Controls.Add(this.HeaderText);
            this.Name = "UserControlHeaderLabel";
            this.Size = new System.Drawing.Size(344, 112);
            this.ultraPanel1.ClientArea.ResumeLayout(false);
            this.ultraPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraLabel HeaderText;
        private Infragistics.Win.Misc.UltraPanel ultraPanel1;
        private Infragistics.Win.Misc.UltraLabel MainText;
    }
}
