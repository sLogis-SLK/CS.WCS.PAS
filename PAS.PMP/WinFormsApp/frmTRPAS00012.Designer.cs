using Infragistics.Win;
using System.Drawing;
using System.Windows.Forms;

namespace PAS.PMP
{
    partial class frmTRPAS00012
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTRPAS00012));
            this.uGrid1 = new TR_Library.Controls.uGrid();
            this.조회버튼 = new Infragistics.Win.Misc.UltraButton();
            this.중간실적반영버튼 = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.배치반영버튼 = new Infragistics.Win.Misc.UltraButton();
            this.작업일자 = new TR_Library.Controls.uCalendarCombo();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.실적작성버튼 = new Infragistics.Win.Misc.UltraButton();
            this.실적전송버튼 = new Infragistics.Win.Misc.UltraButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uGrid2 = new TR_Library.Controls.uGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.작업일자)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // uGrid1
            // 
            this.uGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.uGrid1.DisplayLayout.Appearance = appearance1;
            this.uGrid1.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid1.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid1.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.uGrid1.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid1.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.uGrid1.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid1.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uGrid1.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uGrid1.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.uGrid1.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid1.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.uGrid1.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.uGrid1.DisplayLayout.Override.CellAppearance = appearance8;
            this.uGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid1.DisplayLayout.Override.CellPadding = 0;
            this.uGrid1.DisplayLayout.Override.DefaultRowHeight = 24;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid1.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.uGrid1.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.uGrid1.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGrid1.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.uGrid1.DisplayLayout.Override.RowAppearance = appearance11;
            this.uGrid1.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None;
            this.uGrid1.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uGrid1.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.uGrid1.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid1.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid1.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid1.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGrid1.Location = new System.Drawing.Point(6, 57);
            this.uGrid1.Name = "uGrid1";
            this.uGrid1.Size = new System.Drawing.Size(988, 137);
            this.uGrid1.TabIndex = 3;
            this.uGrid1.Text = "uGrid1";
            this.uGrid1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.uGrid1_MouseUp);
            // 
            // 조회버튼
            // 
            this.조회버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.조회버튼.Location = new System.Drawing.Point(538, 0);
            this.조회버튼.Name = "조회버튼";
            this.조회버튼.Size = new System.Drawing.Size(90, 45);
            this.조회버튼.TabIndex = 2;
            this.조회버튼.Text = "조회";
            this.조회버튼.Click += new System.EventHandler(this.조회버튼_Click);
            // 
            // 중간실적반영버튼
            // 
            this.중간실적반영버튼.AutoSize = true;
            this.중간실적반영버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.중간실적반영버튼.Location = new System.Drawing.Point(874, 0);
            this.중간실적반영버튼.Name = "중간실적반영버튼";
            this.중간실적반영버튼.Size = new System.Drawing.Size(126, 45);
            this.중간실적반영버튼.TabIndex = 6;
            this.중간실적반영버튼.Text = "WMS 중간실적 반영";
            this.중간실적반영버튼.Click += new System.EventHandler(this.중간실적반영버튼_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.uGrid1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 200);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.조회버튼);
            this.panel2.Controls.Add(this.실적작성버튼);
            this.panel2.Controls.Add(this.실적전송버튼);
            this.panel2.Controls.Add(this.배치반영버튼);
            this.panel2.Controls.Add(this.작업일자);
            this.panel2.Controls.Add(this.ultraLabel1);
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 45);
            this.panel2.TabIndex = 16;
            // 
            // 배치반영버튼
            // 
            this.배치반영버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.배치반영버튼.Location = new System.Drawing.Point(868, 0);
            this.배치반영버튼.Name = "배치반영버튼";
            this.배치반영버튼.Size = new System.Drawing.Size(120, 45);
            this.배치반영버튼.TabIndex = 1;
            this.배치반영버튼.Text = "WMS 패킹반영";
            this.배치반영버튼.Click += new System.EventHandler(this.배치반영버튼_Click);
            // 
            // 작업일자
            // 
            this.작업일자.DateButtons.Add(dateButton1);
            this.작업일자.Location = new System.Drawing.Point(82, 12);
            this.작업일자.Name = "작업일자";
            this.작업일자.NonAutoSizeHeight = 21;
            this.작업일자.Size = new System.Drawing.Size(100, 21);
            this.작업일자.TabIndex = 4;
            // 
            // ultraLabel1
            // 
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance13;
            this.ultraLabel1.AutoSize = true;
            this.ultraLabel1.Location = new System.Drawing.Point(11, 15);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(62, 16);
            this.ultraLabel1.TabIndex = 17;
            this.ultraLabel1.Text = ">작업일자";
            // 
            // 실적작성버튼
            // 
            this.실적작성버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.실적작성버튼.Location = new System.Drawing.Point(628, 0);
            this.실적작성버튼.Name = "실적작성버튼";
            this.실적작성버튼.Size = new System.Drawing.Size(120, 45);
            this.실적작성버튼.TabIndex = 3;
            this.실적작성버튼.Text = "PAS 실적작성";
            this.실적작성버튼.Click += new System.EventHandler(this.실적작성버튼_Click);
            // 
            // 실적전송버튼
            // 
            this.실적전송버튼.Dock = System.Windows.Forms.DockStyle.Right;
            this.실적전송버튼.Location = new System.Drawing.Point(748, 0);
            this.실적전송버튼.Name = "실적전송버튼";
            this.실적전송버튼.Size = new System.Drawing.Size(120, 45);
            this.실적전송버튼.TabIndex = 2;
            this.실적전송버튼.Text = "WMS 실적반영";
            this.실적전송버튼.Click += new System.EventHandler(this.실적전송버튼_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.중간실적반영버튼);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 45);
            this.panel3.TabIndex = 17;
            // 
            // uGrid2
            // 
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.uGrid2.DisplayLayout.Appearance = appearance14;
            this.uGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance15.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.GroupByBox.Appearance = appearance15;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance16;
            this.uGrid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance17.BackColor2 = System.Drawing.SystemColors.Control;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.PromptAppearance = appearance17;
            this.uGrid2.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uGrid2.DisplayLayout.Override.ActiveCellAppearance = appearance18;
            appearance19.BackColor = System.Drawing.SystemColors.Highlight;
            appearance19.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uGrid2.DisplayLayout.Override.ActiveRowAppearance = appearance19;
            this.uGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.uGrid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.CardAreaAppearance = appearance20;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            appearance21.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.uGrid2.DisplayLayout.Override.CellAppearance = appearance21;
            this.uGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid2.DisplayLayout.Override.CellPadding = 0;
            this.uGrid2.DisplayLayout.Override.DefaultRowHeight = 24;
            appearance22.BackColor = System.Drawing.SystemColors.Control;
            appearance22.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance22.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance22.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.GroupByRowAppearance = appearance22;
            appearance23.TextHAlignAsString = "Left";
            this.uGrid2.DisplayLayout.Override.HeaderAppearance = appearance23;
            this.uGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGrid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            this.uGrid2.DisplayLayout.Override.RowAppearance = appearance24;
            this.uGrid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None;
            this.uGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uGrid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance25;
            this.uGrid2.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.uGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid2.Location = new System.Drawing.Point(0, 0);
            this.uGrid2.Name = "uGrid2";
            this.uGrid2.Size = new System.Drawing.Size(1000, 362);
            this.uGrid2.TabIndex = 0;
            this.uGrid2.Text = "uGrid2";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 245);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1000, 3);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.uGrid2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1000, 362);
            this.panel4.TabIndex = 19;
            // 
            // frmTRPAS00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 610);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTRPAS00012";
            this.Tag = "TRPAS00012";
            this.Text = "실적작성/반영, 배치반영(TRPAS00012)";
            ((System.ComponentModel.ISupportInitialize)(this.uGrid1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.작업일자)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TR_Library.Controls.uGrid uGrid1;
        private TR_Library.Controls.uGrid uGrid2;
        private Infragistics.Win.Misc.UltraButton 조회버튼;
        private Infragistics.Win.Misc.UltraButton 중간실적반영버튼;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Infragistics.Win.Misc.UltraButton 배치반영버튼;
        private Infragistics.Win.Misc.UltraButton 실적전송버튼;
        private Infragistics.Win.Misc.UltraButton 실적작성버튼;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private TR_Library.Controls.uCalendarCombo 작업일자;
        private Splitter splitter1;
        private Panel panel4;
    }
}