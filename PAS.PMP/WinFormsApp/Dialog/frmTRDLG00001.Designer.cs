namespace PAS.PMP.WinFormsApp.Dialog
{
    partial class frmTRDLG00001
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
            this.선택 = new Infragistics.Win.Misc.UltraButton();
            this.취소 = new Infragistics.Win.Misc.UltraButton();
            this.box별 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.total별 = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.box별)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total별)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 선택
            // 
            this.선택.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.선택.Location = new System.Drawing.Point(12, 11);
            this.선택.Name = "선택";
            this.선택.Size = new System.Drawing.Size(155, 40);
            this.선택.TabIndex = 0;
            this.선택.Text = "선택";
            this.선택.Click += new System.EventHandler(this.선택_Click);
            // 
            // 취소
            // 
            this.취소.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.취소.Location = new System.Drawing.Point(226, 11);
            this.취소.Name = "취소";
            this.취소.Size = new System.Drawing.Size(155, 40);
            this.취소.TabIndex = 1;
            this.취소.Text = "취소";
            this.취소.Click += new System.EventHandler(this.취소_Click);
            // 
            // box별
            // 
            this.box별.Location = new System.Drawing.Point(65, 49);
            this.box별.Name = "box별";
            this.box별.Size = new System.Drawing.Size(271, 20);
            this.box별.TabIndex = 2;
            this.box별.Text = "1. 박스별 거래명세서";
            // 
            // total별
            // 
            this.total별.Location = new System.Drawing.Point(65, 75);
            this.total별.Name = "total별";
            this.total별.Size = new System.Drawing.Size(270, 24);
            this.total별.TabIndex = 3;
            this.total별.Text = "2. 토탈 거래명세서";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.선택);
            this.ultraGroupBox1.Controls.Add(this.취소);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 148);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(393, 63);
            this.ultraGroupBox1.TabIndex = 4;
            // 
            // frmTRDLG00001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 211);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.total별);
            this.Controls.Add(this.box별);
            this.Name = "frmTRDLG00001";
            this.Text = "거래명세서 선택";
            ((System.ComponentModel.ISupportInitialize)(this.box별)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total별)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton 선택;
        private Infragistics.Win.Misc.UltraButton 취소;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor box별;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor total별;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
    }
}