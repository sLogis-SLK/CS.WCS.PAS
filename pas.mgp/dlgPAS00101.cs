// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00101
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00101 : RSkinForm
{
  private DataTable m_관리_분류실적_백업Table = new DataTable("usp_관리_분류실적_백업_Get");
  private IContainer components;
  private Panel panel1;
  private RPanel rPanel1;
  private RButton 닫기버튼;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel1;
  private Label label1;
  private DateTimePicker dateTimePicker2;
  private Button 주버튼;
  private Button 달3버튼;
  private Button 달1버튼;
  private Button 오늘버튼;
  private RLabel rLabel2;
  private ComboBox comboBox1;
  private RButton 조회버튼;
  private RGrid rGrid1;
  private Label label2;
  private RButton 실행버튼;
  private Button 년버튼;
  private Label label3;
  private Label label4;
  private Label label5;
  private RLabel rLabel3;
  private RLabel rLabel7;
  private RLabel rLabel6;
  private RLabel rLabel5;
  private RLabel rLabel4;

  private string 배치상태값 { get; set; }

  public dlgPAS00101()
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.rLabel1.BackColor = this.rPanel1.PanelColor;
    this.rLabel2.BackColor = this.rPanel1.PanelColor;
    this.rLabel3.BackColor = this.rPanel1.PanelColor;
    this.rLabel4.BackColor = this.rPanel1.PanelColor;
    this.rLabel5.BackColor = this.rPanel1.PanelColor;
    this.rLabel6.BackColor = this.rPanel1.PanelColor;
    this.rLabel7.BackColor = this.rPanel1.PanelColor;
    this.rLabel1.Control = (System.Windows.Forms.Control) this.dateTimePicker1;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.comboBox1;
    this.dateTimePicker1.Value = this.dateTimePicker2.Value = DateTime.Now;
    this.comboBox1.Items.Add((object) "백업");
    this.comboBox1.Items.Add((object) "삭제");
    this.comboBox1.SelectedIndex = this.comboBox1.Items.Count - 1;
    Common.RGrid_Initializing(this.rGrid1, true);
    this.관리_분류실적_조회(string.Empty, 조회구분자.가조회);
    this.StartPosition = FormStartPosition.CenterScreen;
  }

  private void 관리_분류실적_조회(string s배치상태, 조회구분자 e)
  {
    string oValue1 = this.dateTimePicker1.Value.ToString("yyyyMMdd");
    string oValue2 = this.dateTimePicker2.Value.ToString("yyyyMMdd");
    if (s배치상태 == string.Empty)
      s배치상태 = "모두";
    DbProvider.Select(Common.ConnectionString(), this.m_관리_분류실적_백업Table, DbProvider.GetParameter("@조회앞", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@조회뒤", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) s배치상태, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid1.DataSource2 = (object) this.m_관리_분류실적_백업Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid1.Columns)
    {
      switch (column.HeaderText)
      {
        case "분류상태코드":
        case "배치상태코드":
          column.Visible = false;
          continue;
        default:
          column.Visible = true;
          continue;
      }
    }
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    foreach (DataRow row in (InternalDataCollectionBase) this.m_관리_분류실적_백업Table.Rows)
    {
      switch (row["배치상태코드"].ToString())
      {
        case "9":
          ++num1;
          continue;
        case "A":
          ++num2;
          continue;
        case "B":
          ++num3;
          continue;
        case "C":
          ++num4;
          continue;
        default:
          continue;
      }
    }
    this.rLabel3.Text = string.Format("완료 : {0:#,0}", (object) num1);
    this.rLabel4.Text = string.Format("실적작성 : {0:#,0}", (object) num2);
    this.rLabel5.Text = string.Format("실적반영 : {0:#,0}", (object) num3);
    this.rLabel6.Text = string.Format("배치반영 : {0:#,0}", (object) num4);
    this.rLabel7.Text = string.Format("Total : {0:#,0}", (object) this.m_관리_분류실적_백업Table.Rows.Count);
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

  private void 조회버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.배치상태값 = "모두";
      this.관리_분류실적_조회(string.Empty, 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void 기간버튼_Click(object sender, EventArgs e)
  {
    if (!(sender is Button))
      return;
    Button button = sender as Button;
    DateTime dateTime = DateTime.Now;
    DateTime now = DateTime.Now;
    switch (button.Text)
    {
      case "오늘":
        dateTime = DateTime.Now;
        now = DateTime.Now;
        break;
      case "1주":
        dateTime = DateTime.Now.AddDays(-7.0);
        now = DateTime.Now;
        break;
      case "1달":
        dateTime = DateTime.Now.AddMonths(-1);
        now = DateTime.Now;
        break;
      case "3달":
        dateTime = DateTime.Now.AddMonths(-3);
        now = DateTime.Now;
        break;
      case "1년":
        dateTime = DateTime.Now.AddYears(-1);
        now = DateTime.Now;
        break;
    }
    this.dateTimePicker1.Value = dateTime;
    this.dateTimePicker2.Value = now;
  }

  private void 배치상태별조회버튼_Click(object sender, EventArgs e)
  {
    if (!(sender is RLabel))
      return;
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      RLabel rlabel = sender as RLabel;
      if (rlabel.Tag == null)
        return;
      this.배치상태값 = rlabel.Tag.ToString();
      this.관리_분류실적_조회(this.배치상태값, 조회구분자.실조회);
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
    }
  }

  private void 실행버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      string str1 = this.dateTimePicker1.Value.ToString("yyyyMMdd");
      string str2 = this.dateTimePicker2.Value.ToString("yyyyMMdd");
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      if (string.IsNullOrEmpty(this.배치상태값))
        this.배치상태값 = "모두";
      using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
      {
        dbProvider2.Initialize("usp_관리_분류실적_백업_Set", "@조회앞", "@조회뒤", "@장비명", "@배치상태", "@관리상태");
        dbProvider2.Update((object) str1, (object) str2, (object) Common.Setting.NAME, (object) this.배치상태값, (object) this.comboBox1.Text);
        dbProvider2.Commit();
      }
      if (!(this.comboBox1.Text == "삭제"))
        return;
      foreach (DataRow row in (InternalDataCollectionBase) this.m_관리_분류실적_백업Table.Rows)
      {
        string str3 = row["분류번호"].ToString();
        string str4 = row["작업일자"].ToString();
        string str5;
        try
        {
          str5 = str4.Substring(4, 4);
        }
        catch
        {
          str5 = DateTime.Now.ToString("MMdd");
        }
        if (Directory.Exists($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str5}\\{str3}"))
          Directory.Delete($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str5}\\{str3}", true);
        if (Directory.GetDirectories($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str5}").Length == 0 && Directory.Exists($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str5}"))
          Directory.Delete($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str5}");
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
      if (this.m_관리_분류실적_백업Table.Rows.Count > 0)
        this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
  {
    if (this.comboBox1.Text == "삭제")
      this.label4.Text = "* 삭제는 백업된 배치에만 해당됩니다.";
    else
      this.label4.Text = "* 백업은 현재 운영중이거나 중단된 배치는 제외합니다.";
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00101));
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.rPanel1 = new RPanel();
    this.rLabel7 = new RLabel();
    this.rLabel6 = new RLabel();
    this.rLabel5 = new RLabel();
    this.rLabel4 = new RLabel();
    this.rLabel3 = new RLabel();
    this.label5 = new Label();
    this.실행버튼 = new RButton();
    this.label4 = new Label();
    this.label3 = new Label();
    this.년버튼 = new Button();
    this.label2 = new Label();
    this.조회버튼 = new RButton();
    this.comboBox1 = new ComboBox();
    this.rLabel2 = new RLabel();
    this.오늘버튼 = new Button();
    this.달3버튼 = new Button();
    this.달1버튼 = new Button();
    this.주버튼 = new Button();
    this.dateTimePicker2 = new DateTimePicker();
    this.label1 = new Label();
    this.dateTimePicker1 = new DateTimePicker();
    this.rLabel1 = new RLabel();
    this.닫기버튼 = new RButton();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 46);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(876, 442);
    this.panel1.TabIndex = 0;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid1.BackgroundColor = Color.White;
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Control;
    gridViewCellStyle1.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle1.ForeColor = SystemColors.WindowText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    this.rGrid1.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
    this.rGrid1.DataSource2 = (object) null;
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle2.BackColor = SystemColors.Window;
    gridViewCellStyle2.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle2.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid1.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid1.Location = new Point(6, 112 /*0x70*/);
    this.rGrid1.Name = "rGrid1";
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle3.BackColor = SystemColors.Control;
    gridViewCellStyle3.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle3.ForeColor = SystemColors.WindowText;
    gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle3.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    this.rGrid1.RowHeadersDefaultCellStyle = gridViewCellStyle3;
    this.rGrid1.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid1.Size = new Size(864, 320);
    this.rGrid1.TabIndex = 3;
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel7);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel6);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel5);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel4);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel3);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label5);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.실행버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label4);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label3);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.년버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.오늘버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.달3버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.달1버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.주버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 6);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(864, 100);
    this.rPanel1.TabIndex = 1;
    this.rLabel7.Control = (System.Windows.Forms.Control) null;
    this.rLabel7.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel7.ForeColor = Color.RosyBrown;
    this.rLabel7.IsBulletPoint = false;
    this.rLabel7.Location = new Point(396, 74);
    this.rLabel7.Name = "rLabel7";
    this.rLabel7.Size = new Size(100, 23);
    this.rLabel7.TabIndex = 34;
    this.rLabel7.Tag = (object) "모두";
    this.rLabel7.Text = "Total : 0";
    this.rLabel7.Click += new EventHandler(this.배치상태별조회버튼_Click);
    this.rLabel6.Control = (System.Windows.Forms.Control) null;
    this.rLabel6.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel6.ForeColor = Color.DarkGray;
    this.rLabel6.IsBulletPoint = false;
    this.rLabel6.Location = new Point(294, 74);
    this.rLabel6.Name = "rLabel6";
    this.rLabel6.Size = new Size(100, 23);
    this.rLabel6.TabIndex = 33;
    this.rLabel6.Tag = (object) "배치반영";
    this.rLabel6.Text = "배치반영 : 0";
    this.rLabel6.Click += new EventHandler(this.배치상태별조회버튼_Click);
    this.rLabel5.Control = (System.Windows.Forms.Control) null;
    this.rLabel5.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel5.ForeColor = Color.DarkGray;
    this.rLabel5.IsBulletPoint = false;
    this.rLabel5.Location = new Point(194, 74);
    this.rLabel5.Name = "rLabel5";
    this.rLabel5.Size = new Size(100, 23);
    this.rLabel5.TabIndex = 32 /*0x20*/;
    this.rLabel5.Tag = (object) "실적반영";
    this.rLabel5.Text = "실적반영 : 0";
    this.rLabel5.Click += new EventHandler(this.배치상태별조회버튼_Click);
    this.rLabel4.Control = (System.Windows.Forms.Control) null;
    this.rLabel4.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel4.ForeColor = Color.DarkGray;
    this.rLabel4.IsBulletPoint = false;
    this.rLabel4.Location = new Point(93, 74);
    this.rLabel4.Name = "rLabel4";
    this.rLabel4.Size = new Size(100, 23);
    this.rLabel4.TabIndex = 31 /*0x1F*/;
    this.rLabel4.Tag = (object) "실적작성";
    this.rLabel4.Text = "실적작성 : 0";
    this.rLabel4.Click += new EventHandler(this.배치상태별조회버튼_Click);
    this.rLabel3.Control = (System.Windows.Forms.Control) null;
    this.rLabel3.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel3.ForeColor = Color.DarkGray;
    this.rLabel3.IsBulletPoint = false;
    this.rLabel3.Location = new Point(12, 74);
    this.rLabel3.Name = "rLabel3";
    this.rLabel3.Size = new Size(80 /*0x50*/, 23);
    this.rLabel3.TabIndex = 30;
    this.rLabel3.Tag = (object) "완료";
    this.rLabel3.Text = "완료 : 0";
    this.rLabel3.Click += new EventHandler(this.배치상태별조회버튼_Click);
    this.label5.BackColor = SystemColors.Control;
    this.label5.Location = new Point(12, 70);
    this.label5.Name = "label5";
    this.label5.Size = new Size(844, 1);
    this.label5.TabIndex = 29;
    this.실행버튼.ButtonState = RButtonState.None;
    this.실행버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.실행버튼.ForeColor = Color.Red;
    this.실행버튼.Image = (Image) pas.mgp.Properties.Resources.database_cleanup;
    this.실행버튼.Location = new Point(315, 39);
    this.실행버튼.Name = "실행버튼";
    this.실행버튼.Size = new Size(80 /*0x50*/, 23);
    this.실행버튼.TabIndex = 25;
    this.실행버튼.Text = "실 행";
    this.실행버튼.UseVisualStyleBackColor = true;
    this.실행버튼.Click += new EventHandler(this.실행버튼_Click);
    this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.label4.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label4.ForeColor = Color.Blue;
    this.label4.Location = new Point(478, 39);
    this.label4.Name = "label4";
    this.label4.Size = new Size(378, 23);
    this.label4.TabIndex = 28;
    this.label4.Text = "* 삭제는 백업된 배치에만 해당됩니다.";
    this.label4.TextAlign = ContentAlignment.MiddleRight;
    this.label3.AutoSize = true;
    this.label3.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label3.ForeColor = Color.DimGray;
    this.label3.Location = new Point(272, 45);
    this.label3.Name = "label3";
    this.label3.Size = new Size(39, 11);
    this.label3.TabIndex = 27;
    this.label3.Text = "를(을)";
    this.label3.TextAlign = ContentAlignment.MiddleLeft;
    this.년버튼.FlatStyle = FlatStyle.Flat;
    this.년버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.년버튼.ForeColor = Color.DimGray;
    this.년버튼.Location = new Point(438, 9);
    this.년버튼.Name = "년버튼";
    this.년버튼.Size = new Size(40, 23);
    this.년버튼.TabIndex = 26;
    this.년버튼.Text = "1년";
    this.년버튼.UseVisualStyleBackColor = true;
    this.년버튼.Click += new EventHandler(this.기간버튼_Click);
    this.label2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(398, 39);
    this.label2.Name = "label2";
    this.label2.Size = new Size(100, 23);
    this.label2.TabIndex = 24;
    this.label2.Text = "합니다.";
    this.label2.TextAlign = ContentAlignment.MiddleLeft;
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(675, 9);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 23;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(188, 41);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(80 /*0x50*/, 20);
    this.comboBox1.TabIndex = 22;
    this.comboBox1.SelectedValueChanged += new EventHandler(this.comboBox1_SelectedValueChanged);
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(12, 40);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(170, 23);
    this.rLabel2.TabIndex = 21;
    this.rLabel2.Text = "선택한 기간의 분류 실적";
    this.오늘버튼.FlatStyle = FlatStyle.Flat;
    this.오늘버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.오늘버튼.ForeColor = Color.DimGray;
    this.오늘버튼.Location = new Point(274, 9);
    this.오늘버튼.Name = "오늘버튼";
    this.오늘버튼.Size = new Size(40, 23);
    this.오늘버튼.TabIndex = 20;
    this.오늘버튼.Text = "오늘";
    this.오늘버튼.UseVisualStyleBackColor = true;
    this.오늘버튼.Click += new EventHandler(this.기간버튼_Click);
    this.달3버튼.FlatStyle = FlatStyle.Flat;
    this.달3버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.달3버튼.ForeColor = Color.DimGray;
    this.달3버튼.Location = new Point(397, 9);
    this.달3버튼.Name = "달3버튼";
    this.달3버튼.Size = new Size(40, 23);
    this.달3버튼.TabIndex = 19;
    this.달3버튼.Text = "3달";
    this.달3버튼.UseVisualStyleBackColor = true;
    this.달3버튼.Click += new EventHandler(this.기간버튼_Click);
    this.달1버튼.FlatStyle = FlatStyle.Flat;
    this.달1버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.달1버튼.ForeColor = Color.DimGray;
    this.달1버튼.Location = new Point(356, 9);
    this.달1버튼.Name = "달1버튼";
    this.달1버튼.Size = new Size(40, 23);
    this.달1버튼.TabIndex = 18;
    this.달1버튼.Text = "1달";
    this.달1버튼.UseVisualStyleBackColor = true;
    this.달1버튼.Click += new EventHandler(this.기간버튼_Click);
    this.주버튼.FlatStyle = FlatStyle.Flat;
    this.주버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.주버튼.ForeColor = Color.DimGray;
    this.주버튼.Location = new Point(315, 9);
    this.주버튼.Name = "주버튼";
    this.주버튼.Size = new Size(40, 23);
    this.주버튼.TabIndex = 17;
    this.주버튼.Text = "1주";
    this.주버튼.UseVisualStyleBackColor = true;
    this.주버튼.Click += new EventHandler(this.기간버튼_Click);
    this.dateTimePicker2.Format = DateTimePickerFormat.Short;
    this.dateTimePicker2.Location = new Point(188, 10);
    this.dateTimePicker2.Name = "dateTimePicker2";
    this.dateTimePicker2.Size = new Size(80 /*0x50*/, 21);
    this.dateTimePicker2.TabIndex = 16 /*0x10*/;
    this.label1.AutoSize = true;
    this.label1.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(172, 14);
    this.label1.Name = "label1";
    this.label1.Size = new Size(15, 12);
    this.label1.TabIndex = 15;
    this.label1.Text = "~";
    this.label1.TextAlign = ContentAlignment.MiddleCenter;
    this.dateTimePicker1.Format = DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new Point(90, 10);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new Size(80 /*0x50*/, 21);
    this.dateTimePicker1.TabIndex = 14;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(12, 9);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(80 /*0x50*/, 23);
    this.rLabel1.TabIndex = 13;
    this.rLabel1.Text = "기간선택";
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(766, 9);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 2;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(900, 500);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.KeyPreview = true;
    this.Name = nameof (dlgPAS00101);
    this.Text = "PAS Management Program v1.0";
    this.Text2 = "데이터 백업/관리";
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.rPanel1.PerformLayout();
    this.ResumeLayout(false);
  }
}
