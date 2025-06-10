
namespace PAS.PMP
{
    partial class frmTRPAS00006
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
            Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton dateButton1 = new Infragistics.Win.UltraWinSchedule.CalendarCombo.DateButton();
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
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.작업일자 = new TR_Library.Controls.uCalendarCombo();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.조회 = new Infragistics.Win.Misc.UltraButton();
            this.닫기 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.uGrid2 = new TR_Library.Controls.uGrid();
            this.ultraGroupBox3 = new Infragistics.Win.Misc.UltraGroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.작업일자)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).BeginInit();
            this.ultraGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.ultraGroupBox1.Controls.Add(this.작업일자);
            this.ultraGroupBox1.Controls.Add(this.ultraLabel11);
            this.ultraGroupBox1.Controls.Add(this.조회);
            this.ultraGroupBox1.Controls.Add(this.닫기);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(1388, 44);
            this.ultraGroupBox1.TabIndex = 1027;
            // 
            // 작업일자
            // 
            this.작업일자.DateButtons.Add(dateButton1);
            this.작업일자.Location = new System.Drawing.Point(85, 9);
            this.작업일자.Name = "작업일자";
            this.작업일자.NonAutoSizeHeight = 21;
            this.작업일자.Size = new System.Drawing.Size(121, 21);
            this.작업일자.TabIndex = 7;
            // 
            // ultraLabel11
            // 
            this.ultraLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance2;
            this.ultraLabel11.Location = new System.Drawing.Point(11, 9);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(66, 29);
            this.ultraLabel11.TabIndex = 6;
            this.ultraLabel11.Text = "작업일자";
            // 
            // 조회
            // 
            this.조회.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.조회.Location = new System.Drawing.Point(1190, 12);
            this.조회.Name = "조회";
            this.조회.Size = new System.Drawing.Size(90, 25);
            this.조회.TabIndex = 4;
            this.조회.Text = "조회";
            this.조회.Click += new System.EventHandler(this.조회_Click);
            // 
            // 닫기
            // 
            this.닫기.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.닫기.Location = new System.Drawing.Point(1286, 12);
            this.닫기.Name = "닫기";
            this.닫기.Size = new System.Drawing.Size(90, 25);
            this.닫기.TabIndex = 5;
            this.닫기.Text = "닫기";
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.Controls.Add(this.uGrid2);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.ultraGroupBox2.Location = new System.Drawing.Point(0, 44);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(1388, 250);
            this.ultraGroupBox2.TabIndex = 1028;
            // 
            // uGrid2
            // 
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.uGrid2.DisplayLayout.Appearance = appearance3;
            this.uGrid2.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.uGrid2.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance4.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.GroupByBox.Appearance = appearance4;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.BandLabelAppearance = appearance5;
            this.uGrid2.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance6.BackColor2 = System.Drawing.SystemColors.Control;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.uGrid2.DisplayLayout.GroupByBox.PromptAppearance = appearance6;
            this.uGrid2.DisplayLayout.MaxColScrollRegions = 1;
            this.uGrid2.DisplayLayout.MaxRowScrollRegions = 1;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            appearance7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uGrid2.DisplayLayout.Override.ActiveCellAppearance = appearance7;
            appearance8.BackColor = System.Drawing.SystemColors.Highlight;
            appearance8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.uGrid2.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.uGrid2.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid2.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.uGrid2.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.CardAreaAppearance = appearance9;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.uGrid2.DisplayLayout.Override.CellAppearance = appearance10;
            this.uGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.uGrid2.DisplayLayout.Override.CellPadding = 0;
            this.uGrid2.DisplayLayout.Override.DefaultRowHeight = 24;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.uGrid2.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.TextHAlignAsString = "Left";
            this.uGrid2.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.uGrid2.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.uGrid2.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            this.uGrid2.DisplayLayout.Override.RowAppearance = appearance13;
            this.uGrid2.DisplayLayout.Override.RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.None;
            this.uGrid2.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.uGrid2.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.uGrid2.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid2.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.uGrid2.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            appearance15.BackColor = System.Drawing.Color.IndianRed;
            appearance15.BackColor2 = System.Drawing.Color.Firebrick;
            this.uGrid2.DisplayLayout.SplitterBarHorizontalAppearance = appearance15;
            this.uGrid2.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.uGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.uGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid2.Location = new System.Drawing.Point(3, 3);
            this.uGrid2.Name = "uGrid2";
            this.uGrid2.Size = new System.Drawing.Size(1382, 244);
            this.uGrid2.TabIndex = 0;
            this.uGrid2.Text = "uGrid2";
            this.uGrid2.AfterRowActivate += new System.EventHandler(this.uGrid2_AfterRowActivate);
            // 
            // ultraGroupBox3
            // 
            this.ultraGroupBox3.Controls.Add(this.tabControl1);
            this.ultraGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox3.Location = new System.Drawing.Point(0, 294);
            this.ultraGroupBox3.Name = "ultraGroupBox3";
            this.ultraGroupBox3.Size = new System.Drawing.Size(1388, 410);
            this.ultraGroupBox3.TabIndex = 1029;
            // 
            // splitter1
            // 
            this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 294);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1388, 3);
            this.splitter1.TabIndex = 1030;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1382, 404);
            this.tabControl1.TabIndex = 0;
            // 
            // frmTRPAS00006
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1388, 704);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ultraGroupBox3);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.KeyPreview = true;
            this.Name = "frmTRPAS00006";
            this.Tag = "TRPAS00006";
            this.Text = "매장별 박스 현황(TRPAS00006)";
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.작업일자)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox3)).EndInit();
            this.ultraGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton 닫기;
        private Infragistics.Win.Misc.UltraButton 조회;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private TR_Library.Controls.uCalendarCombo 작업일자;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox3;
        private System.Windows.Forms.Splitter splitter1;
        private TR_Library.Controls.uGrid uGrid2;
        private System.Windows.Forms.TabControl tabControl1;
    }
}