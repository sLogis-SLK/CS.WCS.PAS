
namespace PAS.Core.Controls
{
    partial class PrintPopupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintPopupForm));
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.저장버튼 = new Infragistics.Win.Misc.UltraButton();
            this.닫기버튼 = new Infragistics.Win.Misc.UltraButton();
            this.combo프린터 = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.combo프린터)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox2
            // 
            appearance1.AlphaLevel = ((short)(255));
            this.ultraGroupBox2.Appearance = appearance1;
            this.ultraGroupBox2.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.ultraGroupBox2.Controls.Add(this.combo프린터);
            this.ultraGroupBox2.Controls.Add(this.ultraLabel15);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(384, 63);
            this.ultraGroupBox2.TabIndex = 1040;
            this.ultraGroupBox2.Text = "프린트 정보";
            // 
            // ultraGroupBox1
            // 
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ultraGroupBox1.Appearance = appearance3;
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.ultraGroupBox1.Controls.Add(this.저장버튼);
            this.ultraGroupBox1.Controls.Add(this.닫기버튼);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 63);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(384, 38);
            this.ultraGroupBox1.TabIndex = 1042;
            // 
            // 저장버튼
            // 
            this.저장버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.저장버튼.Location = new System.Drawing.Point(182, 2);
            this.저장버튼.Name = "저장버튼";
            this.저장버튼.Size = new System.Drawing.Size(100, 34);
            this.저장버튼.TabIndex = 22;
            this.저장버튼.Text = "[F7]저장";
            // 
            // 닫기버튼
            // 
            this.닫기버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.닫기버튼.Location = new System.Drawing.Point(282, 2);
            this.닫기버튼.Name = "닫기버튼";
            this.닫기버튼.Size = new System.Drawing.Size(100, 34);
            this.닫기버튼.TabIndex = 24;
            this.닫기버튼.Text = "닫기";
            this.닫기버튼.Click += new System.EventHandler(this.닫기버튼_Click);
            // 
            // combo프린터
            // 
            this.combo프린터.Location = new System.Drawing.Point(58, 27);
            this.combo프린터.Name = "combo프린터";
            this.combo프린터.Size = new System.Drawing.Size(243, 21);
            this.combo프린터.TabIndex = 1;
            // 
            // ultraLabel15
            // 
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance2;
            this.ultraLabel15.AutoSize = true;
            this.ultraLabel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraLabel15.Location = new System.Drawing.Point(2, 18);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(50, 43);
            this.ultraLabel15.TabIndex = 73;
            this.ultraLabel15.Text = "프린터 :";
            // 
            // PrintPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 101);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(400, 140);
            this.MinimumSize = new System.Drawing.Size(400, 140);
            this.Name = "PrintPopupForm";
            this.Text = "프린트";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            this.ultraGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.combo프린터)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton 저장버튼;
        private Infragistics.Win.Misc.UltraButton 닫기버튼;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor combo프린터;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
    }
}