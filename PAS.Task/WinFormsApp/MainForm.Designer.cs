
namespace PAS.Task
{
    partial class MainForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.PAS기기콤보 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.오류라벨4 = new System.Windows.Forms.Label();
            this.사용라벨4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.오류라벨3 = new System.Windows.Forms.Label();
            this.사용라벨3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.오류라벨2 = new System.Windows.Forms.Label();
            this.사용라벨2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.오류라벨1 = new System.Windows.Forms.Label();
            this.사용라벨1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.시작버튼 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PAS기기콤보
            // 
            this.PAS기기콤보.Dock = System.Windows.Forms.DockStyle.Left;
            this.PAS기기콤보.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PAS기기콤보.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PAS기기콤보.FormattingEnabled = true;
            this.PAS기기콤보.Location = new System.Drawing.Point(3, 17);
            this.PAS기기콤보.Name = "PAS기기콤보";
            this.PAS기기콤보.Size = new System.Drawing.Size(223, 32);
            this.PAS기기콤보.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.시작버튼);
            this.groupBox1.Controls.Add(this.PAS기기콤보);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pas기기선택";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 158);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "모니터링";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 229F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.오류라벨4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.사용라벨4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.오류라벨3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.사용라벨3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.오류라벨2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.사용라벨2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.오류라벨1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.사용라벨1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 138);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // 오류라벨4
            // 
            this.오류라벨4.AutoSize = true;
            this.오류라벨4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.오류라벨4.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.오류라벨4.Location = new System.Drawing.Point(281, 102);
            this.오류라벨4.Name = "오류라벨4";
            this.오류라벨4.Size = new System.Drawing.Size(44, 36);
            this.오류라벨4.TabIndex = 11;
            this.오류라벨4.Text = "○";
            this.오류라벨4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 사용라벨4
            // 
            this.사용라벨4.AutoSize = true;
            this.사용라벨4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.사용라벨4.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.사용라벨4.Location = new System.Drawing.Point(232, 102);
            this.사용라벨4.Name = "사용라벨4";
            this.사용라벨4.Size = new System.Drawing.Size(43, 36);
            this.사용라벨4.TabIndex = 10;
            this.사용라벨4.Text = "○";
            this.사용라벨4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(3, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 36);
            this.label10.TabIndex = 9;
            this.label10.Text = "거래명세서 출력";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 오류라벨3
            // 
            this.오류라벨3.AutoSize = true;
            this.오류라벨3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.오류라벨3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.오류라벨3.Location = new System.Drawing.Point(281, 68);
            this.오류라벨3.Name = "오류라벨3";
            this.오류라벨3.Size = new System.Drawing.Size(44, 34);
            this.오류라벨3.TabIndex = 8;
            this.오류라벨3.Text = "○";
            this.오류라벨3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 사용라벨3
            // 
            this.사용라벨3.AutoSize = true;
            this.사용라벨3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.사용라벨3.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.사용라벨3.Location = new System.Drawing.Point(232, 68);
            this.사용라벨3.Name = "사용라벨3";
            this.사용라벨3.Size = new System.Drawing.Size(43, 34);
            this.사용라벨3.TabIndex = 7;
            this.사용라벨3.Text = "○";
            this.사용라벨3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(3, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 34);
            this.label7.TabIndex = 6;
            this.label7.Text = "실적관리 서버";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 오류라벨2
            // 
            this.오류라벨2.AutoSize = true;
            this.오류라벨2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.오류라벨2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.오류라벨2.Location = new System.Drawing.Point(281, 34);
            this.오류라벨2.Name = "오류라벨2";
            this.오류라벨2.Size = new System.Drawing.Size(44, 34);
            this.오류라벨2.TabIndex = 5;
            this.오류라벨2.Text = "○";
            this.오류라벨2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 사용라벨2
            // 
            this.사용라벨2.AutoSize = true;
            this.사용라벨2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.사용라벨2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.사용라벨2.Location = new System.Drawing.Point(232, 34);
            this.사용라벨2.Name = "사용라벨2";
            this.사용라벨2.Size = new System.Drawing.Size(43, 34);
            this.사용라벨2.TabIndex = 4;
            this.사용라벨2.Text = "○";
            this.사용라벨2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(223, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "숫자 표시기";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 오류라벨1
            // 
            this.오류라벨1.AutoSize = true;
            this.오류라벨1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.오류라벨1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.오류라벨1.Location = new System.Drawing.Point(281, 0);
            this.오류라벨1.Name = "오류라벨1";
            this.오류라벨1.Size = new System.Drawing.Size(44, 34);
            this.오류라벨1.TabIndex = 2;
            this.오류라벨1.Text = "○";
            this.오류라벨1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 사용라벨1
            // 
            this.사용라벨1.AutoSize = true;
            this.사용라벨1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.사용라벨1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.사용라벨1.Location = new System.Drawing.Point(232, 0);
            this.사용라벨1.Name = "사용라벨1";
            this.사용라벨1.Size = new System.Drawing.Size(43, 34);
            this.사용라벨1.TabIndex = 1;
            this.사용라벨1.Text = "○";
            this.사용라벨1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 시작버튼
            // 
            this.시작버튼.Dock = System.Windows.Forms.DockStyle.Fill;
            this.시작버튼.Location = new System.Drawing.Point(226, 17);
            this.시작버튼.Name = "시작버튼";
            this.시작버튼.Size = new System.Drawing.Size(105, 33);
            this.시작버튼.TabIndex = 2;
            this.시작버튼.Text = "시작";
            this.시작버튼.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Task Monitoring";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox PAS기기콤보;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label 오류라벨4;
        private System.Windows.Forms.Label 사용라벨4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label 오류라벨3;
        private System.Windows.Forms.Label 사용라벨3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label 오류라벨2;
        private System.Windows.Forms.Label 사용라벨2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label 오류라벨1;
        private System.Windows.Forms.Label 사용라벨1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 시작버튼;
    }
}

