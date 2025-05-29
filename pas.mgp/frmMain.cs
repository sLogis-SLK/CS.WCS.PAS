// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmMain
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using Microsoft.Win32;
using NetHelper.Control;
using NetHelper.Forms;
using pas.dk;
// using pas.mgp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

// #nullable disable
namespace pas.mgp { 

public class frmMain : RSkinForm
{
  private Timer m_oNowTimer;
  private IContainer components;
  private Panel panel1;
  private ToolStrip toolStrip1;
  private ToolStripLabel toolStripLabel1;
  private ToolStripButton toolStripButton1;
  private RMdiTabControl rMdiTabControl1;
  private ToolStripButton toolStripButton2;
  private Panel panel2;
  private PasPanel pasPanel1;
  private Label label1;
  private RPictureBox pictureBox1;
  private TreeView tv;
  private ImageList imageList1;
  private StatusStrip statusStrip1;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripButton toolStripButton3;
  private ToolStripSeparator toolStripSeparator2;
  private ToolStripSeparator toolStripSeparator3;
  private ToolStripButton toolStripButton5;
  private Label label2;
  private ToolStripStatusLabel 상태메시지;
  private ToolStripProgressBar 진행상태;
  private ToolStripStatusLabel 현재시간;
  private ToolStripButton toolStripButton6;
  private ToolStripButton toolStripButton7;
  private ToolStripButton toolStripButton4;

  private bool IsUpdate { get; set; }

  private void RMdiLayoutInitializing(RMdiTabControl oMdi)
  {
    oMdi.Alignment = RMdiTabControl.TabAlignment.Bottom;
    oMdi.AutoSize = true;
    oMdi.BackColor = System.Drawing.Color.White;
    oMdi.DropButtonVisible = true;
    oMdi.DropButtonVisible = false;
    oMdi.FontBoldOnSelect = false;
    oMdi.ForeColor = System.Drawing.Color.White;
    oMdi.ForeColorDisabled = System.Drawing.Color.DimGray;
    oMdi.SmoothingMode = SmoothingMode.None;
    oMdi.TabBackHighColor = System.Drawing.Color.FromArgb(37, 56, 132);
    oMdi.TabBackHighColorDisabled = System.Drawing.Color.FromArgb(247, 251, 253);
    oMdi.TabBackLowColor = System.Drawing.Color.FromArgb(37, 56, 132);
    oMdi.TabBackLowColorDisabled = System.Drawing.Color.FromArgb(247, 251, 253);
    oMdi.TabBorderEnhanceWeight = RMdiTabControl.Weight.Medium;
    oMdi.TabCloseButtonVisible = false;
    oMdi.TabHeight = 25;
    oMdi.TabOffset = 0;
    oMdi.TabPadLeft = 0;
    oMdi.TabPadRight = 0;
    oMdi.TabsDirection = RMdiTabControl.FlowDirection.LeftToRight;
    oMdi.TopSeparator = true;
  }

  private void SetImageList()
  {
    this.imageList1.Images.Add((Image) pas.mgp.Properties.Resources._1459448605_folder);
    this.imageList1.Images.Add((Image) pas.mgp.Properties.Resources._1459448640_attibutes);
    this.imageList1.Images.Add((Image) pas.mgp.Properties.Resources.margin);
  }

  private void SetTreeMenu()
  {
    this.tv.Nodes.Clear();
    Font font = new Font(this.tv.Font.Name, this.tv.Font.Size, FontStyle.Bold);
    TreeNode node1 = new TreeNode("PAS 준비/완료", 0, 0);
    node1.NodeFont = font;
    node1.Nodes.Add(this.GetNode("배치 시작/완료"));
    TreeNode node2 = new TreeNode("작업내역 확인", 0, 0);
    node2.NodeFont = font;
    node2.Nodes.Add(this.GetNode("미출고 내역(슈트별)"));
    node2.Nodes.Add(this.GetNode("미출고 내역(상품별)"));
    node2.Nodes.Add(this.GetNode("--------------------"));
    node2.Nodes.Add(this.GetNode("박스 재발행"));
    node2.Nodes.Add(this.GetNode("박스 상품이동"));
    node2.Nodes.Add(this.GetNode("--------------------"));
    node2.Nodes.Add(this.GetNode("마지막 박스 확인"));
    node2.Nodes.Add(this.GetNode("매장별 박스 현황"));
    node2.Nodes.Add(this.GetNode("거래명세서 재출력"));
    TreeNode node3 = new TreeNode("WMS 연동", 0, 0);
    node3.NodeFont = font;
    node3.Nodes.Add(this.GetNode("배치수신 및 생성"));
    node3.Nodes.Add(this.GetNode("배송사 변경"));
    node3.Nodes.Add(this.GetNode("--------------------"));
    node3.Nodes.Add(this.GetNode("실적작성/반영, 배치반영"));
    node3.Nodes.Add(this.GetNode("실적작성/반영, 배치반영 취소"));
    TreeNode node4 = new TreeNode("PAS 관리", 0, 0);
    node4.NodeFont = font;
    node4.Nodes.Add(this.GetNode("데이터 백업/관리"));
    node4.Nodes.Add(this.GetNode("환경설정"));
    node4.Nodes.Add(this.GetNode("--------------------"));
    node4.Nodes.Add(this.GetNode("업데이트 정보확인"));
    this.tv.Nodes.Add(node1);
    this.tv.Nodes.Add(node2);
    this.tv.Nodes.Add(node3);
    this.tv.Nodes.Add(node4);
    this.tv.ExpandAll();
  }

  private TreeNode GetNode(string text)
  {
    int num = 1;
    if (string.IsNullOrEmpty(text))
      num = 2;
    return new TreeNode(text, num, num);
  }

  private void FormManager(string sName)
  {
    bool flag = false;
    foreach (RMdiTabPage tabPage in (CollectionBase) this.rMdiTabControl1.TabPages)
    {
      if (((System.Windows.Forms.Control) tabPage.Form).Text == sName)
      {
        tabPage.Select();
        flag = true;
        break;
      }
    }
    if (!flag)
    {
      Form Form = this.FormCreate(sName);
      if (Form == null)
      {
        int num = (int) MessageBox.Show("프로그램을 찾을 수 없습니다.", sName);
        return;
      }
      this.rMdiTabControl1.TabPages.Add(Form);
    }
    this.panel2.Visible = false;
  }

  private Form FormCreate(string sName)
  {
    try
    {
      Assembly.GetExecutingAssembly().Location.ToString();
      foreach (System.Type type in Assembly.GetExecutingAssembly().GetTypes())
      {
        if (type.BaseType.FullName == "System.Windows.Forms.Form")
        {
          Form instance = (Form) Activator.CreateInstance(type);
          if (instance != null && instance.Text == sName)
            return instance;
        }
      }
    }
    catch (LicenseException ex)
    {
    }
    catch (Exception ex)
    {
    }
    return (Form) null;
  }

  public frmMain()
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.toolStripButton6.Visible = false;
    this.RMdiLayoutInitializing(this.rMdiTabControl1);
    Common.GetSetting();
    Common.IsLog = true;
    if (Common.Setting.LOCAL_FOLDER != string.Empty && !Directory.Exists(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA))
      Directory.CreateDirectory(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA);
    if (!Directory.Exists(Common.PATH_STARTUP + Common.PATH_TEMP))
      Directory.CreateDirectory(Common.PATH_STARTUP + Common.PATH_TEMP);
    this.SetImageList();
    this.tv.ImageList = this.imageList1;
    this.tv.BackColor = System.Drawing.Color.LightYellow;
    this.tv.ShowLines = false;
    this.label2.BackColor = System.Drawing.Color.LightYellow;
    this.SetTreeMenu();
    this.현재시간.Text = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss");
    this.진행상태.Visible = false;
    Common.전역상태바 = this.statusStrip1;
    Common.전역상태메시지 = this.상태메시지;
    Common.전역진행상태 = this.진행상태;
    this.m_oNowTimer = new Timer();
    this.m_oNowTimer.Tick += new EventHandler(this.m_oNowTimer_Tick);
    this.m_oNowTimer.Start();
    this.StartPosition = FormStartPosition.CenterScreen;
    this.IsUpdate = false;
  }

        private void InitializeComponent()
        {
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmMain));
            this.panel1 = new Panel();
            this.rMdiTabControl1 = new RMdiTabControl();
            this.panel2 = new Panel();
            this.tv = new TreeView();
            this.label2 = new Label();
            this.pasPanel1 = new PasPanel();
            this.pictureBox1 = new RPictureBox();
            this.label1 = new Label();
            this.statusStrip1 = new StatusStrip();
            this.상태메시지 = new ToolStripStatusLabel();
            this.진행상태 = new ToolStripProgressBar();
            this.현재시간 = new ToolStripStatusLabel();
            this.toolStrip1 = new ToolStrip();
            this.toolStripLabel1 = new ToolStripLabel();
            this.toolStripButton1 = new ToolStripButton();
            this.toolStripSeparator1 = new ToolStripSeparator();
            this.toolStripButton2 = new ToolStripButton();
            this.toolStripButton3 = new ToolStripButton();
            this.toolStripSeparator2 = new ToolStripSeparator();
            this.toolStripButton7 = new ToolStripButton();
            this.toolStripButton6 = new ToolStripButton();
            this.toolStripButton5 = new ToolStripButton();
            this.toolStripSeparator3 = new ToolStripSeparator();
            this.toolStripButton4 = new ToolStripButton();
            this.imageList1 = new ImageList(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pasPanel1.SuspendLayout();
            ((ISupportInitialize)this.pictureBox1).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add((System.Windows.Forms.Control)this.rMdiTabControl1);
            this.panel1.Controls.Add((System.Windows.Forms.Control)this.panel2);
            this.panel1.Controls.Add((System.Windows.Forms.Control)this.statusStrip1);
            this.panel1.Controls.Add((System.Windows.Forms.Control)this.toolStrip1);
            this.panel1.Location = new Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(1000, 710);
            this.panel1.TabIndex = 0;
            this.rMdiTabControl1.Dock = DockStyle.Fill;
            this.rMdiTabControl1.Location = new Point(250, 50);
            this.rMdiTabControl1.MenuRenderer = (ToolStripRenderer)null;
            this.rMdiTabControl1.Name = "rMdiTabControl1";
            this.rMdiTabControl1.Size = new Size(750, 638);
            this.rMdiTabControl1.TabCloseButtonImage = (Image)null;
            this.rMdiTabControl1.TabCloseButtonImageDisabled = (Image)null;
            this.rMdiTabControl1.TabCloseButtonImageHot = (Image)null;
            this.rMdiTabControl1.TabIndex = 2;
            this.panel2.BorderStyle = BorderStyle.Fixed3D;
            this.panel2.Controls.Add((System.Windows.Forms.Control)this.tv);
            this.panel2.Controls.Add((System.Windows.Forms.Control)this.label2);
            this.panel2.Controls.Add((System.Windows.Forms.Control)this.pasPanel1);
            this.panel2.Dock = DockStyle.Left;
            this.panel2.Location = new Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(250, 638);
            this.panel2.TabIndex = 3;
            this.tv.BorderStyle = BorderStyle.None;
            this.tv.Dock = DockStyle.Fill;
            this.tv.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte)129);
            this.tv.ForeColor = System.Drawing.Color.DimGray;
            this.tv.Location = new Point(0, 35);
            this.tv.Name = "tv";
            this.tv.Size = new Size(246, 599);
            this.tv.TabIndex = 1;
            this.tv.DoubleClick += new EventHandler(this.tv_DoubleClick);
            this.label2.Dock = DockStyle.Top;
            this.label2.Location = new Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new Size(246, 5);
            this.label2.TabIndex = 2;
            this.pasPanel1.Controls.Add((System.Windows.Forms.Control)this.pictureBox1);
            this.pasPanel1.Controls.Add((System.Windows.Forms.Control)this.label1);
            this.pasPanel1.Dock = DockStyle.Top;
            this.pasPanel1.Location = new Point(0, 0);
            this.pasPanel1.Name = "pasPanel1";
            this.pasPanel1.PanelSeperator = true;
            this.pasPanel1.Size = new Size(246, 30);
            this.pasPanel1.TabIndex = 0;
            this.pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.pictureBox1.Image = (Image)pas.mgp.Properties.Resources._1395148906_delete;
            this.pictureBox1.Location = new Point(222, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(20, 20);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBox1.Style = RPictureBox.RPictureBoxStyle.Button;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new EventHandler(this.pictureBox1_Click);
            this.label1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)129);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new Size(196, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = " 프로그램 메뉴";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Font = new Font("굴림", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte)129);
            this.statusStrip1.Items.AddRange(new ToolStripItem[3]
            {
      (ToolStripItem) this.상태메시지,
      (ToolStripItem) this.진행상태,
      (ToolStripItem) this.현재시간
            });
            this.statusStrip1.Location = new Point(0, 688);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new Size(1000, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.상태메시지.AutoSize = false;
            this.상태메시지.BackColor = SystemColors.Control;
            this.상태메시지.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)129);
            this.상태메시지.ForeColor = System.Drawing.Color.DimGray;
            this.상태메시지.Name = "상태메시지";
            this.상태메시지.Size = new Size(533, 17);
            this.상태메시지.Spring = true;
            this.상태메시지.TextAlign = ContentAlignment.MiddleLeft;
            this.진행상태.BackColor = SystemColors.Control;
            this.진행상태.Name = "진행상태";
            this.진행상태.Size = new Size(200, 16 /*0x10*/);
            this.현재시간.AutoSize = false;
            this.현재시간.BackColor = SystemColors.Control;
            this.현재시간.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte)129);
            this.현재시간.ForeColor = System.Drawing.Color.DimGray;
            this.현재시간.Name = "현재시간";
            this.현재시간.Size = new Size(250, 17);
            this.현재시간.TextAlign = ContentAlignment.MiddleRight;
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new Size(32 /*0x20*/, 32 /*0x20*/);
            this.toolStrip1.Items.AddRange(new ToolStripItem[11]
            {
      (ToolStripItem) this.toolStripLabel1,
      (ToolStripItem) this.toolStripButton1,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.toolStripButton2,
      (ToolStripItem) this.toolStripButton3,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.toolStripButton7,
      (ToolStripItem) this.toolStripButton6,
      (ToolStripItem) this.toolStripButton5,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.toolStripButton4
            });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new Size(1000, 50);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new Size(10, 47);
            this.toolStripLabel1.Text = " ";
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton1.Image = (Image)pas.mgp.Properties.Resources._1459503777_Menu_Item;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new Size(69, 47);
            this.toolStripButton1.Text = "메뉴";
            this.toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new Size(6, 50);
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton2.Image = (Image)pas.mgp.Properties.Resources._1395148853_save_as;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new Size(69, 47);
            this.toolStripButton2.Text = "저장";
            this.toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton3.Image = (Image)pas.mgp.Properties.Resources._1395148843_printer;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new Size(69, 47);
            this.toolStripButton3.Text = "인쇄";
            this.toolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new Size(6, 50);
            this.toolStripButton7.Alignment = ToolStripItemAlignment.Right;
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton7.Image = (Image)pas.mgp.Properties.Resources._1462963573_Gnome_Software_Update_Available_32;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new Size(69, 47);
            this.toolStripButton7.Text = "업데이트";
            this.toolStripButton7.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton6.Image = (Image)pas.mgp.Properties.Resources._1458550268_System_Restore;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new Size(69, 47);
            this.toolStripButton6.Text = "작업관리자";
            this.toolStripButton6.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton5.Image = (Image)pas.mgp.Properties.Resources._1395148859_help;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new Size(69, 47);
            this.toolStripButton5.Text = "도움말";
            this.toolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new Size(6, 50);
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.ForeColor = System.Drawing.Color.DimGray;
            this.toolStripButton4.Image = (Image)pas.mgp.Properties.Resources._1395148853_close_delete;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new Size(69, 47);
            this.toolStripButton4.Text = "종료";
            this.toolStripButton4.TextImageRelation = TextImageRelation.ImageAboveText;
            this.imageList1.ColorDepth = ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new Size(16 /*0x10*/, 16 /*0x10*/);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.AutoScaleDimensions = new SizeF(7f, 12f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1024 /*0x0400*/, 768 /*0x0300*/);
            this.Controls.Add((System.Windows.Forms.Control)this.panel1);
            this.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            this.KeyPreview = true;
            this.Name = nameof(frmMain);
            this.Text = "PAS";
            this.Text2 = "PAS 관리 프로그램";
            this.UseMaximizeBox = true;
            this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new EventHandler(this.frmMain_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pasPanel1.ResumeLayout(false);
            ((ISupportInitialize)this.pictureBox1).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
        }

        private void m_oNowTimer_Tick(object sender, EventArgs e)
  {
    this.statusStrip1.Invoke((Delegate) (new MethodInvoker(() => this.현재시간.Text = DateTime.Now.ToString("yyyy-MM-dd tt hh:mm:ss"))));
  }

  private void pictureBox1_Click(object sender, EventArgs e) => this.panel2.Visible = false;

  private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
  {
    switch (e.ClickedItem.Text)
    {
      case "메뉴":
        this.panel2.Visible = !this.panel2.Visible;
        break;
      case "저장":
        switch (this.rMdiTabControl1.ActiveControl.Name)
        {
          case null:
            return;
          case "frmPAS00021":
            ((frmPAS00021) this.rMdiTabControl1.ActiveControl).Save();
            return;
          case "frmPAS00022":
            ((frmPAS00022) this.rMdiTabControl1.ActiveControl).Save();
            return;
          case "frmPAS00023":
            ((frmPAS00023) this.rMdiTabControl1.ActiveControl).Save();
            return;
          case "frmPAS00025":
            ((frmPAS00025) this.rMdiTabControl1.ActiveControl).Save();
            return;
          default:
            return;
        }
      case "인쇄":
        switch (this.rMdiTabControl1.ActiveControl.Name)
        {
          case null:
            return;
          case "frmPAS00021":
            ((frmPAS00021) this.rMdiTabControl1.ActiveControl).Print();
            return;
          case "frmPAS00022":
            ((frmPAS00022) this.rMdiTabControl1.ActiveControl).Print();
            return;
          case "frmPAS00023":
            ((frmPAS00023) this.rMdiTabControl1.ActiveControl).Print();
            return;
          case "frmPAS00024":
            ((frmPAS00024) this.rMdiTabControl1.ActiveControl).Print();
            return;
          case "frmPAS00025":
            ((frmPAS00025) this.rMdiTabControl1.ActiveControl).Print();
            return;
          case "frmPAS00026":
            ((frmPAS00026) this.rMdiTabControl1.ActiveControl).Print();
            return;
          default:
            return;
        }
      case "업데이트":
        if (File.Exists(Common.PATH_STARTUP + "\\pas.update.exe"))
        {
          try
          {
            Process[] processesByName = Process.GetProcessesByName("pas.task");
            if (processesByName.Length > 0)
              processesByName[0].Kill();
            Process.Start(Common.PATH_STARTUP + "\\pas.update.exe", Common.UPDATE_ARGUMENT);
            this.IsUpdate = true;
            this.Close();
            break;
          }
          catch (Exception ex)
          {
            Common.ErrorMessageBox(ex.Message);
            break;
          }
        }
        else
        {
          Common.ErrorMessageBox("업데이트를 수행할 수 없습니다.");
          break;
        }
      case "도움말":
        try
        {
          string str = Common.PATH_STARTUP + "\\pas.mgp.pdf";
          if (!File.Exists(str))
          {
            Common.ErrorMessageBox("도움말 파일이 없습니다.");
            break;
          }
          List<string> stringList = new List<string>((IEnumerable<string>) Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type").GetSubKeyNames());
          object obj = Registry.GetValue("HKEY_CLASSES_ROOT\\MIME\\Database\\Content Type\\application/pdf", "CLSID", (object) string.Empty);
          if (!stringList.Contains("application/pdf") || obj == null || obj.ToString() == string.Empty)
          {
            if (Common.QuestionMessageBox("PDF 뷰어가 없습니다.\r\n\r\n설치 하시겠습니까?") != DialogResult.Yes)
              break;
            Process.Start("explorer.exe", "http://get.adobe.com/kr/reader/");
            break;
          }
          Process.Start(str);
          break;
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
          break;
        }
      case "종료":
        this.Close();
        break;
    }
  }

  private void tv_DoubleClick(object sender, EventArgs e)
  {
    if (this.tv.SelectedNode == null)
      return;
    string text = this.tv.SelectedNode.Text;
    if (string.IsNullOrEmpty(text))
      return;
    switch (text)
    {
      case "PAS 준비/완료":
        break;
      case "작업내역 확인":
        break;
      case "WMS 연동":
        break;
      case "PAS 관리":
        break;
      case "배치 시작/완료":
        dlgPAS00001 dlgPaS00001 = new dlgPAS00001();
        this.panel2.Visible = false;
        int num1 = (int) dlgPaS00001.ShowDialog();
        break;
      case "배송사 변경":
        dlgPAS00064 dlgPaS00064 = new dlgPAS00064();
        this.panel2.Visible = false;
        int num2 = (int) dlgPaS00064.ShowDialog();
        break;
      case "데이터 백업/관리":
        dlgPAS00101 dlgPaS00101 = new dlgPAS00101();
        this.panel2.Visible = false;
        int num3 = (int) dlgPaS00101.ShowDialog();
        break;
      case "업데이트":
        if (File.Exists(Common.PATH_STARTUP + "\\pas.update.exe"))
        {
          try
          {
            Process[] processesByName = Process.GetProcessesByName("pas.task");
            if (processesByName.Length > 0)
              processesByName[0].Kill();
            Process.Start(Common.PATH_STARTUP + "\\pas.update.exe", Common.UPDATE_ARGUMENT);
            this.IsUpdate = true;
            this.Close();
            break;
          }
          catch (Exception ex)
          {
            Common.ErrorMessageBox(ex.Message);
            break;
          }
        }
        else
        {
          Common.ErrorMessageBox("업데이트를 수행할 수 없습니다.");
          break;
        }
      case "업데이트 정보확인":
        if (!File.Exists(Common.PATH_STARTUP + "\\update.txt"))
          break;
        int num4 = (int) new dlgPAS00901(Common.PATH_STARTUP + "\\update.txt").ShowDialog();
        break;
      case "환경설정":
        dlgPAS00999 dlgPaS00999 = new dlgPAS00999();
        this.panel2.Visible = false;
        if (dlgPaS00999.ShowDialog() != DialogResult.OK)
          break;
        Common.GetSetting();
        break;
      case "--------------------":
        break;
      default:
        this.FormManager(text);
        break;
    }
  }

  private void frmMain_Shown(object sender, EventArgs e)
  {
    string[] commandLineArgs = Environment.GetCommandLineArgs();
    if (commandLineArgs.Length <= 1)
      return;
    try
    {
      if (!(commandLineArgs[1] == "UPDATE"))
        return;
      if (File.Exists(Common.PATH_STARTUP + "\\update.txt"))
      {
        int num = (int) new dlgPAS00901(Common.PATH_STARTUP + "\\update.txt").ShowDialog();
      }
      Process.Start(Common.PATH_STARTUP + "\\pas.task.exe");
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message);
    }
  }

  private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
  {
    if (this.IsUpdate)
    {
      if (this.m_oNowTimer != null && this.m_oNowTimer.Enabled)
        this.m_oNowTimer.Stop();
      Process.GetCurrentProcess().Kill();
    }
    else if (frmMessageBox.Show("프로그램을 종료 하시겠습니까?") == DialogResult.Yes)
    {
      if (this.m_oNowTimer != null && this.m_oNowTimer.Enabled)
        this.m_oNowTimer.Stop();
      Process.GetCurrentProcess().Kill();
    }
    else
      e.Cancel = true;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  
}
}