using Infragistics.Win;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PAS.PMP
{
    partial class frmMessageBox
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
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraLabel1
            // 
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Location = new System.Drawing.Point(30, 10);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(268, 48);
            this.ultraLabel1.TabIndex = 3;
            this.ultraLabel1.Text = "프로그램을 종료합니다.\r\n종료 하시겠습니까?";
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(32, 61);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(85, 32);
            this.ultraButton1.TabIndex = 4;
            this.ultraButton1.Text = "네";
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(125, 61);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(105, 32);
            this.ultraButton2.TabIndex = 5;
            this.ultraButton2.Text = "아니오";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ultraButton1);
            this.panel1.Controls.Add(this.ultraButton2);
            this.panel1.Controls.Add(this.ultraButton3);
            this.panel1.Controls.Add(this.ultraLabel1);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 102);
            this.panel1.TabIndex = 8;
            // 
            // ultraButton3
            // 
            this.ultraButton3.Location = new System.Drawing.Point(80, 61);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(100, 32);
            this.ultraButton3.TabIndex = 6;
            this.ultraButton3.Text = "확인";
            // 
            // frmMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 160);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(290, 160);
            this.Name = "frmMessageBox";
            this.Tag = "frmMessageBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMessageBox_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Panel panel1;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
    }
}