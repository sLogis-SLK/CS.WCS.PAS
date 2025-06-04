using System.Drawing;
using System.Windows.Forms;
using System;

namespace PAS.SMP
{
    partial class uMessage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = Color.White;
            this.panel1.Controls.Add((Control)this.label2);
            this.panel1.Controls.Add((Control)this.label1);
            this.panel1.Location = new Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(380, 180);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new EventHandler(this.uMessage_Click);
            // 
            // label1
            // 
            this.label1.Font = new Font("굴림체", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)129);
            this.label1.ForeColor = Color.Red;
            this.label1.Location = new Point(79, 45);
            this.label1.Name = "label1";
            this.label1.Size = new Size(300, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "운송장 발행 실패 !";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.label1.Click += new EventHandler(this.uMessage_Click);
            // 
            // label2
            // 
            this.label2.Font = new Font("굴림체", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte)129);
            this.label2.ForeColor = Color.Red;
            this.label2.Location = new Point(79, 93);
            this.label2.Name = "label2";
            this.label2.Size = new Size(300, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "재발행을 체크하고 계속하십시오.";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.label2.Click += new EventHandler(this.uMessage_Click);
            // 
            // uMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.Red;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "uMessage";
            this.Size = new Size(398, 198);
            this.Click += new EventHandler(this.uMessage_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
