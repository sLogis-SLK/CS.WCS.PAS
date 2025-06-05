
using Infragistics.Win;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PAS.SMP
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                if (timer출하상태확인 != null)
                {
                    timer출하상태확인.Dispose();
                    timer출하상태확인 = null;
                }
                if (timer출하박스확인 != null)
                {
                    timer출하박스확인.Dispose();
                    timer출하박스확인 = null;
                }
                if (시리얼포트 != null)
                {
                    if (시리얼포트.IsOpen)
                        시리얼포트.Close();
                    시리얼포트.Dispose();
                    시리얼포트 = null;
                }
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
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            this.업데이트 = new Infragistics.Win.Misc.UltraButton();
            this.종료버튼 = new Infragistics.Win.Misc.UltraButton();
            this.설정버튼 = new Infragistics.Win.Misc.UltraButton();
            this.다시시작버튼 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton3 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.미발행대상버튼 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.박스번호 = new PAS.SMP.UserControlHeaderLabel();
            this.슈트번호 = new PAS.SMP.UserControlHeaderLabel();
            this.배치번호 = new PAS.SMP.UserControlHeaderLabel();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.마지막박스 = new PAS.SMP.UserControlHeaderLabel();
            this.내품수 = new PAS.SMP.UserControlHeaderLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraGroupBox4 = new Infragistics.Win.Misc.UltraGroupBox();
            this.중량무시_Check = new PAS.SMP.SMPCheckBox();
            this.재발행_Check = new PAS.SMP.SMPCheckBox();
            this.중량무시 = new PAS.SMP.UserControlHeaderLabel();
            this.재발행 = new PAS.SMP.UserControlHeaderLabel();
            this.운송장번호 = new PAS.SMP.UserControlHeaderLabel();
            this.매장명 = new PAS.SMP.UserControlHeaderLabel();
            this.배송사 = new PAS.SMP.UserControlHeaderLabel();
            this.중량 = new PAS.SMP.UserControlHeaderLabel();
            this.박스바코드 = new PAS.SMP.UserControlHeaderLabel();
            this.시리얼포트 = new System.IO.Ports.SerialPort(this.components);
            this.ultraGroupBox5 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.HeaderText = new Infragistics.Win.Misc.UltraLabel();
            this.현시간 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox6 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.uMessage1 = new PAS.SMP.uMessage();
            this.uGrid2 = new TR_Library.Controls.uGrid();
            this.uGrid1 = new TR_Library.Controls.uGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).BeginInit();
            this.ultraGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).BeginInit();
            this.ultraGroupBox5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).BeginInit();
            this.ultraGroupBox6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // 업데이트
            // 
            this.업데이트.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.업데이트.Location = new System.Drawing.Point(3, 717);
            this.업데이트.Name = "업데이트";
            this.업데이트.Size = new System.Drawing.Size(74, 74);
            this.업데이트.TabIndex = 6;
            this.업데이트.Text = "업데이트";
            // 
            // 종료버튼
            // 
            this.종료버튼.Dock = System.Windows.Forms.DockStyle.Top;
            this.종료버튼.Location = new System.Drawing.Point(3, 373);
            this.종료버튼.Name = "종료버튼";
            this.종료버튼.Size = new System.Drawing.Size(74, 74);
            this.종료버튼.TabIndex = 5;
            this.종료버튼.Text = "종료";
            // 
            // 설정버튼
            // 
            this.설정버튼.Dock = System.Windows.Forms.DockStyle.Top;
            this.설정버튼.Location = new System.Drawing.Point(3, 299);
            this.설정버튼.Name = "설정버튼";
            this.설정버튼.Size = new System.Drawing.Size(74, 74);
            this.설정버튼.TabIndex = 4;
            this.설정버튼.Text = "설정";
            // 
            // 다시시작버튼
            // 
            this.다시시작버튼.Dock = System.Windows.Forms.DockStyle.Top;
            this.다시시작버튼.Location = new System.Drawing.Point(3, 225);
            this.다시시작버튼.Name = "다시시작버튼";
            this.다시시작버튼.Size = new System.Drawing.Size(74, 74);
            this.다시시작버튼.TabIndex = 3;
            this.다시시작버튼.Text = "다시시작";
            // 
            // ultraButton3
            // 
            this.ultraButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraButton3.Location = new System.Drawing.Point(3, 151);
            this.ultraButton3.Name = "ultraButton3";
            this.ultraButton3.Size = new System.Drawing.Size(74, 74);
            this.ultraButton3.TabIndex = 2;
            this.ultraButton3.Text = "예약.";
            // 
            // ultraButton2
            // 
            this.ultraButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraButton2.Location = new System.Drawing.Point(3, 77);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(74, 74);
            this.ultraButton2.TabIndex = 1;
            this.ultraButton2.Text = "예약.";
            // 
            // 미발행대상버튼
            // 
            this.미발행대상버튼.Dock = System.Windows.Forms.DockStyle.Top;
            this.미발행대상버튼.Location = new System.Drawing.Point(3, 3);
            this.미발행대상버튼.Name = "미발행대상버튼";
            this.미발행대상버튼.Size = new System.Drawing.Size(74, 74);
            this.미발행대상버튼.TabIndex = 0;
            this.미발행대상버튼.Text = "미발행대상";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.업데이트);
            this.ultraGroupBox1.Controls.Add(this.종료버튼);
            this.ultraGroupBox1.Controls.Add(this.설정버튼);
            this.ultraGroupBox1.Controls.Add(this.다시시작버튼);
            this.ultraGroupBox1.Controls.Add(this.ultraButton3);
            this.ultraGroupBox1.Controls.Add(this.ultraButton2);
            this.ultraGroupBox1.Controls.Add(this.미발행대상버튼);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.ultraGroupBox1.Location = new System.Drawing.Point(948, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(80, 794);
            this.ultraGroupBox1.TabIndex = 5;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.박스번호);
            this.ultraGroupBox2.Controls.Add(this.슈트번호);
            this.ultraGroupBox2.Controls.Add(this.배치번호);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.Location = new System.Drawing.Point(3, 203);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(562, 94);
            this.ultraGroupBox2.TabIndex = 4;
            // 
            // 박스번호
            // 
            this.박스번호.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.박스번호.Dock = System.Windows.Forms.DockStyle.Fill;
            this.박스번호.Location = new System.Drawing.Point(393, 3);
            this.박스번호.Name = "박스번호";
            this.박스번호.SetHeaderText = "박스 번호";
            this.박스번호.Size = new System.Drawing.Size(166, 88);
            this.박스번호.TabIndex = 5;
            // 
            // 슈트번호
            // 
            this.슈트번호.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.슈트번호.Dock = System.Windows.Forms.DockStyle.Left;
            this.슈트번호.Location = new System.Drawing.Point(198, 3);
            this.슈트번호.Name = "슈트번호";
            this.슈트번호.SetHeaderText = "슈트 번호";
            this.슈트번호.Size = new System.Drawing.Size(195, 88);
            this.슈트번호.TabIndex = 4;
            // 
            // 배치번호
            // 
            this.배치번호.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.배치번호.Dock = System.Windows.Forms.DockStyle.Left;
            this.배치번호.Location = new System.Drawing.Point(3, 3);
            this.배치번호.Name = "배치번호";
            this.배치번호.SetHeaderText = "배치 번호";
            this.배치번호.Size = new System.Drawing.Size(195, 88);
            this.배치번호.TabIndex = 3;
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.마지막박스);
            this.ultraGroupBox3.Controls.Add(this.내품수);
            this.ultraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox3.Location = new System.Drawing.Point(571, 203);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(374, 94);
            this.ultraGroupBox3.TabIndex = 5;
            // 
            // 마지막박스
            // 
            this.마지막박스.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.마지막박스.Dock = System.Windows.Forms.DockStyle.Fill;
            this.마지막박스.Location = new System.Drawing.Point(198, 3);
            this.마지막박스.Name = "마지막박스";
            this.마지막박스.SetHeaderText = "마지막 박스";
            this.마지막박스.Size = new System.Drawing.Size(173, 88);
            this.마지막박스.TabIndex = 3;
            // 
            // 내품수
            // 
            this.내품수.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.내품수.Dock = System.Windows.Forms.DockStyle.Left;
            this.내품수.Location = new System.Drawing.Point(3, 3);
            this.내품수.Name = "내품수";
            this.내품수.SetHeaderText = "내 품 수";
            this.내품수.Size = new System.Drawing.Size(195, 88);
            this.내품수.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.ultraGroupBox4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.운송장번호, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ultraGroupBox3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.매장명, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.배송사, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.중량, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.박스바코드, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ultraGroupBox2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 68);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(948, 400);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ultraGroupBox4
            // 
            this.ultraGroupBox4.Controls.Add(this.중량무시_Check);
            this.ultraGroupBox4.Controls.Add(this.재발행_Check);
            this.ultraGroupBox4.Controls.Add(this.중량무시);
            this.ultraGroupBox4.Controls.Add(this.재발행);
            this.ultraGroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox4.Location = new System.Drawing.Point(571, 303);
            this.ultraGroupBox4.Name = "ultraGroupBox4";
            this.ultraGroupBox4.Size = new System.Drawing.Size(374, 94);
            this.ultraGroupBox4.TabIndex = 9;
            // 
            // 중량무시_Check
            // 
            this.중량무시_Check.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.중량무시_Check.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.중량무시_Check.Font = new System.Drawing.Font("굴림", 20F);
            this.중량무시_Check.Location = new System.Drawing.Point(262, 36);
            this.중량무시_Check.Name = "중량무시_Check";
            this.중량무시_Check.Size = new System.Drawing.Size(40, 40);
            this.중량무시_Check.TabIndex = 10;
            this.중량무시_Check.UseVisualStyleBackColor = true;
            // 
            // 재발행_Check
            // 
            this.재발행_Check.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.재발행_Check.Font = new System.Drawing.Font("굴림", 20F);
            this.재발행_Check.Location = new System.Drawing.Point(81, 36);
            this.재발행_Check.Name = "재발행_Check";
            this.재발행_Check.Size = new System.Drawing.Size(40, 40);
            this.재발행_Check.TabIndex = 9;
            this.재발행_Check.UseVisualStyleBackColor = true;
            // 
            // 중량무시
            // 
            this.중량무시.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.중량무시.Dock = System.Windows.Forms.DockStyle.Fill;
            this.중량무시.Location = new System.Drawing.Point(198, 3);
            this.중량무시.Name = "중량무시";
            this.중량무시.SetHeaderText = "중량 무시";
            this.중량무시.Size = new System.Drawing.Size(173, 88);
            this.중량무시.TabIndex = 3;
            // 
            // 재발행
            // 
            this.재발행.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.재발행.Dock = System.Windows.Forms.DockStyle.Left;
            this.재발행.Location = new System.Drawing.Point(3, 3);
            this.재발행.Name = "재발행";
            this.재발행.SetHeaderText = "재 발 행";
            this.재발행.Size = new System.Drawing.Size(195, 88);
            this.재발행.TabIndex = 2;
            // 
            // 운송장번호
            // 
            this.운송장번호.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.운송장번호.Dock = System.Windows.Forms.DockStyle.Fill;
            this.운송장번호.Location = new System.Drawing.Point(3, 303);
            this.운송장번호.Name = "운송장번호";
            this.운송장번호.SetHeaderText = "운송장 번호";
            this.운송장번호.Size = new System.Drawing.Size(562, 94);
            this.운송장번호.TabIndex = 8;
            // 
            // 매장명
            // 
            this.매장명.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.매장명.Dock = System.Windows.Forms.DockStyle.Fill;
            this.매장명.Location = new System.Drawing.Point(3, 103);
            this.매장명.Name = "매장명";
            this.매장명.SetHeaderText = "매 장 명";
            this.매장명.Size = new System.Drawing.Size(562, 94);
            this.매장명.TabIndex = 3;
            // 
            // 배송사
            // 
            this.배송사.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.배송사.Dock = System.Windows.Forms.DockStyle.Fill;
            this.배송사.Location = new System.Drawing.Point(571, 103);
            this.배송사.Name = "배송사";
            this.배송사.SetHeaderText = "배 송 사";
            this.배송사.Size = new System.Drawing.Size(374, 94);
            this.배송사.TabIndex = 2;
            // 
            // 중량
            // 
            this.중량.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.중량.Dock = System.Windows.Forms.DockStyle.Fill;
            this.중량.Location = new System.Drawing.Point(571, 3);
            this.중량.Name = "중량";
            this.중량.SetHeaderText = "중 량";
            this.중량.Size = new System.Drawing.Size(374, 94);
            this.중량.TabIndex = 1;
            // 
            // 박스바코드
            // 
            this.박스바코드.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.박스바코드.Dock = System.Windows.Forms.DockStyle.Fill;
            this.박스바코드.Location = new System.Drawing.Point(3, 3);
            this.박스바코드.Name = "박스바코드";
            this.박스바코드.SetHeaderText = "박스 바코드";
            this.박스바코드.Size = new System.Drawing.Size(562, 94);
            this.박스바코드.TabIndex = 0;
            // 
            // ultraGroupBox5
            // 
            this.ultraGroupBox5.Controls.Add(this.tableLayoutPanel2);
            this.ultraGroupBox5.Controls.Add(this.HeaderText);
            this.ultraGroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ultraGroupBox5.Location = new System.Drawing.Point(0, 468);
            this.ultraGroupBox5.Name = "ultraGroupBox5";
            this.ultraGroupBox5.Size = new System.Drawing.Size(948, 326);
            this.ultraGroupBox5.TabIndex = 7;
            this.ultraGroupBox5.Text = ".";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.uGrid2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.uGrid1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(35, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(910, 307);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // HeaderText
            // 
            appearance25.BackColor = System.Drawing.Color.LightSlateGray;
            appearance25.FontData.BoldAsString = "True";
            appearance25.ForeColor = System.Drawing.Color.White;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.HeaderText.Appearance = appearance25;
            this.HeaderText.Dock = System.Windows.Forms.DockStyle.Left;
            this.HeaderText.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HeaderText.Location = new System.Drawing.Point(3, 16);
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.Size = new System.Drawing.Size(32, 307);
            this.HeaderText.TabIndex = 8;
            this.HeaderText.Text = "출\r\n\r\n하\r\n\r\n이\r\n\r\n력";
            // 
            // 현시간
            // 
            appearance26.TextHAlignAsString = "Right";
            this.현시간.Appearance = appearance26;
            this.현시간.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.현시간.Location = new System.Drawing.Point(0, 794);
            this.현시간.Name = "현시간";
            this.현시간.Size = new System.Drawing.Size(1028, 23);
            this.현시간.TabIndex = 8;
            this.현시간.Text = "-";
            // 
            // ultraGroupBox6
            // 
            this.ultraGroupBox6.Controls.Add(this.tableLayoutPanel3);
            this.ultraGroupBox6.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox6.Name = "ultraGroupBox6";
            this.ultraGroupBox6.Size = new System.Drawing.Size(948, 68);
            this.ultraGroupBox6.TabIndex = 10;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.ultraButton1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(942, 62);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // ultraButton1
            // 
            this.ultraButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraButton1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.ultraButton1.Location = new System.Drawing.Point(567, 3);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(182, 56);
            this.ultraButton1.TabIndex = 1;
            this.ultraButton1.Text = "시작";
            this.ultraButton1.Click += new System.EventHandler(this.시작버튼_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("굴림", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(198, 10);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(356, 41);
            this.comboBox1.TabIndex = 0;
            // 
            // uMessage1
            // 
            this.uMessage1.BackColor = System.Drawing.Color.Red;
            this.uMessage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uMessage1.Location = new System.Drawing.Point(269, 183);
            this.uMessage1.Name = "uMessage1";
            this.uMessage1.Size = new System.Drawing.Size(398, 198);
            this.uMessage1.TabIndex = 9;
            // 
            // uGrid2
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.uGrid2.DisplayLayout.Appearance = appearance1;
            this.uGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.uGrid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.uGrid2.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uGrid2.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uGrid2.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.uGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.uGrid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.uGrid2.DisplayLayout.Override.CellAppearance = appearance8;
            this.uGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid2.DisplayLayout.Override.CellPadding = 0;
            this.uGrid2.DisplayLayout.Override.DefaultRowHeight = 24;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.uGrid2.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.uGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGrid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.uGrid2.DisplayLayout.Override.RowAppearance = appearance11;
            this.uGrid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None;
            this.uGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uGrid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.uGrid2.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid2.Location = new System.Drawing.Point(3, 156);
            this.uGrid2.Name = "uGrid2";
            this.uGrid2.Size = new System.Drawing.Size(904, 148);
            this.uGrid2.TabIndex = 1;
            this.uGrid2.Text = "uGrid2";
            // 
            // uGrid1
            // 
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.uGrid1.DisplayLayout.Appearance = appearance13;
            this.uGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.uGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.uGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.SystemColors.Highlight;
            appearance18.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.uGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.uGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.uGrid1.DisplayLayout.Override.CellAppearance = appearance20;
            this.uGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid1.DisplayLayout.Override.CellPadding = 0;
            this.uGrid1.DisplayLayout.Override.DefaultRowHeight = 24;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.TextHAlignAsString = "Left";
            this.uGrid1.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.uGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.uGrid1.DisplayLayout.Override.RowAppearance = appearance23;
            this.uGrid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None;
            this.uGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.uGrid1.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid1.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.uGrid1.Location = new System.Drawing.Point(3, 3);
            this.uGrid1.Name = "uGrid1";
            this.uGrid1.Size = new System.Drawing.Size(904, 147);
            this.uGrid1.TabIndex = 0;
            this.uGrid1.Text = "uGrid1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 817);
            this.Controls.Add(this.uMessage1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.ultraGroupBox6);
            this.Controls.Add(this.ultraGroupBox5);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.현시간);
            this.Name = "MainForm";
            this.Text = "출하관리프로그램";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox4)).EndInit();
            this.ultraGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox5)).EndInit();
            this.ultraGroupBox5.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox6)).EndInit();
            this.ultraGroupBox6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraButton 업데이트;
        private Infragistics.Win.Misc.UltraButton 종료버튼;
        private Infragistics.Win.Misc.UltraButton 설정버튼;
        private Infragistics.Win.Misc.UltraButton 다시시작버튼;
        private Infragistics.Win.Misc.UltraButton ultraButton3;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraButton 미발행대상버튼;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private UserControlHeaderLabel 박스번호;
        private UserControlHeaderLabel 슈트번호;
        private UserControlHeaderLabel 배치번호;
        private UserControlHeaderLabel 중량;
        private UserControlHeaderLabel 매장명;
        private UserControlHeaderLabel 배송사;
        private UserControlHeaderLabel 마지막박스;
        private UserControlHeaderLabel 내품수;
        private UserControlHeaderLabel 운송장번호;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private UserControlHeaderLabel 박스바코드;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.IO.Ports.SerialPort 시리얼포트;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private TR_Library.Controls.uGrid uGrid2;
        private TR_Library.Controls.uGrid uGrid1;
        private Infragistics.Win.Misc.UltraLabel HeaderText;
        private Infragistics.Win.Misc.UltraLabel 현시간;
        private uMessage uMessage1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox4;
        private SMPCheckBox 재발행_Check;
        private UserControlHeaderLabel 중량무시;
        private UserControlHeaderLabel 재발행;
        private SMPCheckBox 중량무시_Check;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox6;
        private ComboBox comboBox1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private TableLayoutPanel tableLayoutPanel3;
    }
}

