// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00999
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00999 : RSkinForm
{
  private const int MAX_CHUTE_COUNT = 200;
  private Timer m_oDelayTimer;
  private IContainer components;
  private Panel panel1;
  private RPanel rPanel1;
  private TabControl tabControl1;
  private TabPage tabPage1;
  private TabPage tabPage2;
  private TabPage tabPage3;
  private RButton 닫기버튼;
  private RButton 저장버튼;
  private RLabel rLabel1;
  private RTextBox rTextBox1;
  private RTextBox rTextBox2;
  private RLabel rLabel2;
  private RTextBox rTextBox3;
  private RLabel rLabel3;
  private RTextBox rTextBox4;
  private RLabel rLabel4;
  private RTextBox rTextBox6;
  private RLabel rLabel6;
  private RTextBox rTextBox5;
  private RLabel rLabel5;
  private RTextBox rTextBox8;
  private RLabel rLabel8;
  private RTextBox rTextBox7;
  private RLabel rLabel7;
  private RDivider rDivider1;
  private RLabel rLabel9;
  private RLabel rLabel10;
  private NumericUpDown numericUpDown2;
  private NumericUpDown numericUpDown1;
  private RDivider rDivider2;
  private RButton 로컬폴더버튼;
  private Label label1;
  private Label label3;
  private Label label2;
  private RDivider rDivider3;
  private RLabel rLabel13;
  private RTextBox rTextBox10;
  private RLabel rLabel12;
  private RTextBox rTextBox9;
  private RLabel rLabel11;
  private RDivider rDivider4;
  private RTextBox rTextBox14;
  private RLabel rLabel17;
  private RTextBox rTextBox13;
  private RLabel rLabel16;
  private RTextBox rTextBox12;
  private RLabel rLabel15;
  private RTextBox rTextBox11;
  private RLabel rLabel14;
  private RDivider rDivider5;
  private RTextBox rTextBox18;
  private RLabel rLabel21;
  private RTextBox rTextBox17;
  private RLabel rLabel20;
  private RTextBox rTextBox16;
  private RLabel rLabel19;
  private RTextBox rTextBox15;
  private RLabel rLabel18;
  private RButton 연결테스트버튼;
  private RGrid rGrid1;
  private CheckBox checkBox1;
  private RTextBox rTextBox20;
  private RLabel rLabel23;
  private RTextBox rTextBox19;
  private RLabel rLabel22;
  private TabPage tabPage4;
  private RLabel rLabel24;
  private RGrid rGrid2;
  private RDivider rDivider6;
  private RLabel rLabel25;
  private ComboBox comboBox1;
  private ComboBox comboBox2;
  private RLabel rLabel26;
  private ComboBox comboBox3;
  private Label label4;
  private RButton 삭제버튼;
  private RButton 수정버튼;
  private RButton 추가버튼;
  private RButton 모두삭제버튼;
  private TabPage tabPage5;
  private RButton 모두삭제버튼2;
  private RButton 삭제버튼2;
  private RButton 추가버튼2;
  private ComboBox comboBox4;
  private RLabel rLabel27;
  private RDivider rDivider7;
  private RGrid rGrid3;
  private RLabel rLabel28;

  public dlgPAS00999()
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.tabPage1.BackColor = Color.White;
    this.tabPage2.BackColor = Color.White;
    this.tabPage3.BackColor = Color.White;
    this.tabPage4.BackColor = Color.White;
    this.rLabel1.BackColor = Color.White;
    this.rLabel2.BackColor = Color.White;
    this.rLabel3.BackColor = Color.White;
    this.rLabel4.BackColor = Color.White;
    this.rLabel5.BackColor = Color.White;
    this.rLabel6.BackColor = Color.White;
    this.rLabel7.BackColor = Color.White;
    this.rLabel8.BackColor = Color.White;
    this.rLabel9.BackColor = Color.White;
    this.rLabel10.BackColor = Color.White;
    this.rLabel22.BackColor = Color.White;
    this.rLabel23.BackColor = Color.White;
    this.rLabel11.BackColor = Color.White;
    this.rLabel12.BackColor = Color.White;
    this.rLabel13.BackColor = Color.White;
    this.rLabel14.BackColor = Color.White;
    this.rLabel15.BackColor = Color.White;
    this.rLabel16.BackColor = Color.White;
    this.rLabel17.BackColor = Color.White;
    this.rLabel18.BackColor = Color.White;
    this.rLabel19.BackColor = Color.White;
    this.rLabel20.BackColor = Color.White;
    this.rLabel21.BackColor = Color.White;
    this.rLabel24.BackColor = Color.White;
    this.rLabel25.BackColor = Color.White;
    this.rLabel26.BackColor = Color.White;
    this.rLabel27.BackColor = Color.White;
    this.rLabel28.BackColor = Color.White;
    this.rLabel1.Control = (System.Windows.Forms.Control) this.rTextBox1;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.rTextBox2;
    this.rLabel3.Control = (System.Windows.Forms.Control) this.rTextBox3;
    this.rLabel4.Control = (System.Windows.Forms.Control) this.rTextBox4;
    this.rLabel5.Control = (System.Windows.Forms.Control) this.rTextBox5;
    this.rLabel6.Control = (System.Windows.Forms.Control) this.rTextBox6;
    this.rLabel7.Control = (System.Windows.Forms.Control) this.rTextBox7;
    this.rLabel8.Control = (System.Windows.Forms.Control) this.rTextBox8;
    this.rLabel9.Control = (System.Windows.Forms.Control) this.numericUpDown1;
    this.rLabel10.Control = (System.Windows.Forms.Control) this.numericUpDown2;
    this.rLabel21.Control = (System.Windows.Forms.Control) this.rTextBox19;
    this.rLabel22.Control = (System.Windows.Forms.Control) this.rTextBox20;
    this.rLabel11.Control = (System.Windows.Forms.Control) this.rTextBox9;
    this.rLabel12.Control = (System.Windows.Forms.Control) this.rTextBox10;
    this.rLabel14.Control = (System.Windows.Forms.Control) this.rTextBox11;
    this.rLabel15.Control = (System.Windows.Forms.Control) this.rTextBox12;
    this.rLabel16.Control = (System.Windows.Forms.Control) this.rTextBox13;
    this.rLabel17.Control = (System.Windows.Forms.Control) this.rTextBox14;
    this.rLabel18.Control = (System.Windows.Forms.Control) this.rTextBox15;
    this.rLabel19.Control = (System.Windows.Forms.Control) this.rTextBox16;
    this.rLabel20.Control = (System.Windows.Forms.Control) this.rTextBox17;
    this.rLabel21.Control = (System.Windows.Forms.Control) this.rTextBox18;
    this.rLabel24.Control = (System.Windows.Forms.Control) this.comboBox1;
    this.rLabel26.Control = (System.Windows.Forms.Control) this.rGrid2;
    this.rTextBox1.FocusedColor = SystemColors.Info;
    this.rTextBox2.FocusedColor = SystemColors.Info;
    this.rTextBox3.FocusedColor = SystemColors.Info;
    this.rTextBox4.FocusedColor = SystemColors.Info;
    this.rTextBox5.FocusedColor = SystemColors.Info;
    this.rTextBox6.FocusedColor = SystemColors.Info;
    this.rTextBox7.FocusedColor = SystemColors.Info;
    this.rTextBox8.FocusedColor = SystemColors.Info;
    this.rTextBox8.PasswordChar = '*';
    this.rTextBox19.FocusedColor = SystemColors.Info;
    this.rTextBox20.FocusedColor = SystemColors.Info;
    this.rTextBox9.FocusedColor = SystemColors.Info;
    this.rTextBox10.FocusedColor = SystemColors.Info;
    this.rTextBox11.FocusedColor = SystemColors.Info;
    this.rTextBox12.FocusedColor = SystemColors.Info;
    this.rTextBox13.FocusedColor = SystemColors.Info;
    this.rTextBox14.FocusedColor = SystemColors.Info;
    this.rTextBox14.PasswordChar = '*';
    this.rTextBox15.FocusedColor = SystemColors.Info;
    this.rTextBox16.FocusedColor = SystemColors.Info;
    this.rTextBox17.FocusedColor = SystemColors.Info;
    this.rTextBox18.FocusedColor = SystemColors.Info;
    this.rTextBox18.PasswordChar = '*';
    this.rGrid1.RowHeaderStyle = RowHeaderStyle.Number;
    this.Text = Common.Title;
    for (int index = 0; index < 8; ++index)
    {
      DataGridViewCheckBoxColumn viewCheckBoxColumn = new DataGridViewCheckBoxColumn();
      viewCheckBoxColumn.HeaderText = (index + 1).ToString();
      viewCheckBoxColumn.Width = 50;
      this.rGrid1.Columns.Add((DataGridViewColumn) viewCheckBoxColumn);
    }
    this.rGrid1.Rows.Add(25);
    this.rGrid2.Columns.Add("프린터명", "프린터명");
    this.rGrid2.Columns.Add("슈트앞", "슈트앞");
    this.rGrid2.Columns.Add("슈트뒤", "슈트뒤");
    this.rGrid2.Columns[0].Width = 300;
    this.rGrid2.Columns[1].Width = 100;
    this.rGrid2.Columns[2].Width = 100;
    this.rGrid3.Columns.Add("프린터명", "프린터명");
    this.rGrid3.Columns[0].Width = 300;
    Common.RGrid_Initializing(this.rGrid2, true);
    Common.RGrid_Initializing(this.rGrid3, true);
    this.연결테스트버튼.Visible = false;
    this.checkBox1.Visible = false;
    this.numericUpDown1.Minimum = 3M;
    this.numericUpDown2.Minimum = 3M;
    List<string> stringList = new List<string>();
    foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
      stringList.Add(installedPrinter);
    this.comboBox1.Items.AddRange((object[]) stringList.ToArray());
    this.comboBox4.Items.AddRange((object[]) stringList.ToArray());
    int num1 = 200;
    int num2 = 1;
    int num3 = 200;
    if (!string.IsNullOrEmpty(this.rTextBox4.Text))
    {
      num1 = Common.C2I((object) this.rTextBox4.Text);
      int num4 = Common.C2I((object) this.rTextBox19.Text);
      int num5 = Common.C2I((object) this.rTextBox20.Text);
      if (num1 == 0)
        num1 = 200;
      if (num4 == 0)
        num2 = 1;
      if (num5 == 0)
        num3 = 200;
    }
    string empty = string.Empty;
    this.comboBox2.Items.Clear();
    this.comboBox3.Items.Clear();
    for (int index = 0; index < num1; ++index)
    {
      string str = (index + 1).ToString("D3");
      this.comboBox2.Items.Add((object) str);
      this.comboBox3.Items.Add((object) str);
    }
    this.comboBox2.Items.Add((object) "패키지");
    this.comboBox3.Items.Add((object) "패키지");
    if (this.comboBox2.Items.Count > 0)
      this.comboBox2.SelectedIndex = 0;
    if (this.comboBox3.Items.Count > 0)
      this.comboBox3.SelectedIndex = this.comboBox3.Items.Count - 2;
    this.StartPosition = FormStartPosition.CenterParent;
  }

  private string GetIndicatorStructure()
  {
    string empty = string.Empty;
    for (int index1 = 0; index1 < this.rGrid1.Rows.Count; ++index1)
    {
      for (int index2 = 0; index2 < this.rGrid1.Columns.Count; ++index2)
        empty += Common.C2S(this.rGrid1.Rows[index1].Cells[index2].Value) == bool.TrueString ? "1" : "0";
    }
    return empty;
  }

  private void SetIndicatorStructure(string sVal)
  {
    if (sVal.Length > 200)
      sVal = sVal.Substring(0, 200);
    else if (sVal.Length < 200)
    {
      int num = 200 - sVal.Length;
      for (int index = 0; index < num; ++index)
        sVal += "0";
    }
    int num1 = 25;
    if (0 > 0)
      ++num1;
    for (int index1 = 0; index1 < num1; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        string str = sVal.Substring(index1 * 8 + index2, 1);
        this.rGrid1.Rows[index1].Cells[index2].Value = (object) (str == "1");
      }
    }
  }

  private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
  {
    this.checkBox1.Visible = false;
    this.연결테스트버튼.Visible = false;
    switch (this.tabControl1.SelectedIndex)
    {
      case 1:
        this.checkBox1.Visible = true;
        break;
      case 2:
        this.연결테스트버튼.Visible = true;
        break;
    }
  }

  private void 폴더선택_Click(object sender, EventArgs e)
  {
    if (!(sender is RButton))
      return;
    RButton rbutton = (RButton) sender;
    string str = string.Empty;
    if (rbutton.Name == "로컬폴더버튼")
      str = this.rTextBox5.Text;
    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      str = folderBrowserDialog.SelectedPath;
    if (!(rbutton.Name == "로컬폴더버튼"))
      return;
    this.rTextBox5.Text = str;
  }

  private void frmSetting_Shown(object sender, EventArgs e)
  {
    this.m_oDelayTimer = new Timer();
    this.m_oDelayTimer.Tick += new EventHandler(this.m_oDelayTimer_Tick);
    this.m_oDelayTimer.Interval = 1000;
    this.m_oDelayTimer.Enabled = true;
  }

  private void m_oDelayTimer_Tick(object sender, EventArgs e)
  {
    this.m_oDelayTimer.Enabled = false;
    Common.GetSetting();
    this.rTextBox1.Text = Common.Setting.NAME;
    this.rTextBox2.Text = Common.Setting.SEIGYO_IP;
    this.rTextBox3.Text = Common.Setting.SEIGYO_PORT;
    this.rTextBox4.Text = Common.Setting.CHUTES;
    this.rTextBox19.Text = Common.Setting.CHUTES_ERROR;
    this.rTextBox20.Text = Common.Setting.CHUTES_OVERFLOW;
    this.rTextBox5.Text = Common.Setting.LOCAL_FOLDER;
    this.rTextBox6.Text = Common.Setting.SEIGYO_FOLDER;
    this.rTextBox7.Text = Common.Setting.SEIGYO_ID;
    this.rTextBox8.Text = Common.Setting.SEIGYO_PASSWORD;
    this.numericUpDown1.Value = (Decimal) Common.Setting.PAS_DURATION;
    this.numericUpDown2.Value = (Decimal) Common.Setting.INDICATOR_DURATION;
    this.rTextBox9.Text = Common.Setting.INDICATOR_IP;
    this.rTextBox10.Text = Common.Setting.INDICATOR_PORT;
    this.SetIndicatorStructure(Common.Setting.INDICATOR_STRUCTURE);
    this.rTextBox11.Text = Common.Setting.PAS_DB_IP;
    this.rTextBox12.Text = Common.Setting.PAS_DB_SERVICE;
    this.rTextBox13.Text = Common.Setting.PAS_DB_ID;
    this.rTextBox14.Text = Common.Setting.PAS_DB_PASSWORD;
    this.rTextBox15.Text = Common.Setting.HOST_DB_IP;
    this.rTextBox16.Text = Common.Setting.HOST_DB_SERVICE;
    this.rTextBox17.Text = Common.Setting.HOST_DB_ID;
    this.rTextBox18.Text = Common.Setting.HOST_DB_PASSWORD;
    string[] strArray1 = Common.Setting.BARCODE_PRINTER_LIST.Split(new string[1]
    {
      "|"
    }, StringSplitOptions.RemoveEmptyEntries);
    this.rGrid2.Rows.Clear();
    foreach (string str in strArray1)
    {
      string[] separator = new string[1]{ "," };
      string[] strArray2 = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      try
      {
        if (strArray2.Length == 3)
          this.rGrid2.Rows.Add((object) strArray2[0], (object) strArray2[1], (object) strArray2[2]);
      }
      catch
      {
      }
    }
    string[] strArray3 = Common.Setting.PRINTER_LIST.Split(new string[1]
    {
      "|"
    }, StringSplitOptions.RemoveEmptyEntries);
    this.rGrid3.Rows.Clear();
    foreach (string str in strArray3)
    {
      try
      {
        this.rGrid3.Rows.Add(new object[1]{ (object) str });
      }
      catch
      {
      }
    }
  }

  private void checkBox1_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid1.Rows)
    {
      foreach (DataGridViewCell cell in (BaseCollection) row.Cells)
        cell.Value = (object) this.checkBox1.Checked;
    }
  }

  private void 연결테스트버튼_Click(object sender, EventArgs e)
  {
    try
    {
      string str1 = "PAS : ";
      string str2 = (Common.C2S(DbProvider.Scalar(Common.ConnectionString(this.rTextBox11.Text, this.rTextBox12.Text, this.rTextBox13.Text, this.rTextBox14.Text), "SELECT GETDATE()")).Trim().Length <= 0 ? str1 + "실패" : str1 + "테스트 성공") + "\r\n" + "HOST : ";
      int num = (int) MessageBox.Show(Common.C2S(DbProvider.Scalar(Common.ConnectionString(this.rTextBox15.Text, this.rTextBox16.Text, this.rTextBox17.Text, this.rTextBox18.Text), "SELECT GETDATE()")).Trim().Length <= 0 ? str2 + "실패" : str2 + "테스트 성공", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void 저장버튼_Click(object sender, EventArgs e)
  {
    try
    {
      INI ini = new INI(Common.PATH_STARTUP + Common.FILE_SETTING);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.NAME, this.rTextBox1.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_IP, this.rTextBox2.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_PORT, this.rTextBox3.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES, this.rTextBox4.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES_ERROR, this.rTextBox19.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.CHUTES_OVERFLOW, this.rTextBox20.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.LOCAL_FOLDER, this.rTextBox5.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_FOLDER, this.rTextBox6.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_ID, this.rTextBox7.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.SEIGYO_PASSWORD, this.rTextBox8.Text);
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.PAS_DURATION, Common.C2S((object) this.numericUpDown1.Value));
      ini.SetIniValue(INI_SECTION.PAS, INI_KEY.INDICATOR_DURATION, Common.C2S((object) this.numericUpDown2.Value));
      ini.SetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_IP, this.rTextBox9.Text);
      ini.SetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_PORT, this.rTextBox10.Text);
      string indicatorStructure = this.GetIndicatorStructure();
      ini.SetIniValue(INI_SECTION.INDICATOR, INI_KEY.INDICATOR_STRUCTURE, indicatorStructure);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_IP, this.rTextBox11.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_SERVICE, this.rTextBox12.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_ID, this.rTextBox13.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_PASSWORD, this.rTextBox14.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_IP, this.rTextBox15.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_SERVICE, this.rTextBox16.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_ID, this.rTextBox17.Text);
      ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_DB_PASSWORD, this.rTextBox18.Text);
      string str1 = string.Empty;
      foreach (DataGridViewRow row in (IEnumerable) this.rGrid2.Rows)
        str1 = $"{str1}{row.Cells["프린터명"].Value.ToString()},{row.Cells["슈트앞"].Value.ToString()},{row.Cells["슈트뒤"].Value.ToString()}|";
      string str2 = string.Empty;
      foreach (DataGridViewRow row in (IEnumerable) this.rGrid3.Rows)
        str2 = $"{str2}{row.Cells["프린터명"].Value.ToString()}|";
      ini.SetIniValue(INI_SECTION.PRINTER, INI_KEY.BARCODE_PRINTER_LIST, str1);
      ini.SetIniValue(INI_SECTION.PRINTER, INI_KEY.PRINTER_LIST, str2);
      if (Common.Setting.INDICATOR_IP != this.rTextBox9.Text || Common.Setting.INDICATOR_PORT != this.rTextBox10.Text || Common.Setting.INDICATOR_STRUCTURE != indicatorStructure)
      {
        int num1 = (int) MessageBox.Show("숫자 표시기 설정 항목이 변경되었습니다.\r\n##### 반드시 프로그램이 재시작되어야 설정이 반영됩니다. #####", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else if (Common.Setting.SEIGYO_IP != this.rTextBox2.Text || Common.Setting.SEIGYO_PORT != this.rTextBox3.Text || Common.Setting.CHUTES != this.rTextBox4.Text || Common.Setting.CHUTES_ERROR != this.rTextBox19.Text || Common.Setting.CHUTES_OVERFLOW != this.rTextBox20.Text || Common.Setting.SEIGYO_FOLDER != this.rTextBox6.Text || Common.Setting.SEIGYO_ID != this.rTextBox7.Text || Common.Setting.SEIGYO_PASSWORD != this.rTextBox8.Text)
      {
        int num2 = (int) MessageBox.Show("PAS 설정 항목이 변경되었습니다.\r\n##### 반드시 프로그램이 재시작되어야 설정이 반영됩니다. #####", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num3 = (int) MessageBox.Show("변경한 내용으로 설정을 저장하였습니다.", Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Common.Title, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

  private void 추가버튼_Click(object sender, EventArgs e)
  {
    this.rGrid2.Rows.Add((object) this.comboBox1.Text, (object) this.comboBox2.Text, (object) this.comboBox3.Text);
  }

  private void 수정버튼_Click(object sender, EventArgs e)
  {
    if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
      return;
    this.rGrid2.SelectedRows[0].Cells["프린터명"].Value = (object) this.comboBox1.Text;
    this.rGrid2.SelectedRows[0].Cells["슈트앞"].Value = (object) this.comboBox2.Text;
    this.rGrid2.SelectedRows[0].Cells["슈트뒤"].Value = (object) this.comboBox3.Text;
  }

  private void 삭제버튼_Click(object sender, EventArgs e)
  {
    if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("선택한 대상이 없습니다.");
    }
    else
    {
      if (Common.QuestionMessageBox($"{this.comboBox2.Text} ~ {this.comboBox3.Text} 구간을 삭제 " + "하시겠습니까?") != DialogResult.Yes)
        return;
      this.rGrid2.Rows.Remove(this.rGrid2.SelectedRows[0]);
    }
  }

  private void 모두삭제버튼_Click(object sender, EventArgs e)
  {
    if (Common.QuestionMessageBox("지정한 설정이 모두 삭제됩니다.\r\n\r\n계속 진행 하시겠습니까?") != DialogResult.Yes)
      return;
    this.rGrid2.Rows.Clear();
  }

  private void rGrid2_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      DataGridView.HitTestInfo hitTestInfo = this.rGrid2.HitTest(e.X, e.Y);
      if (hitTestInfo.RowIndex < 0 || hitTestInfo.ColumnIndex < 0)
        return;
      this.comboBox1.Text = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["프린터명"].Value.ToString();
      this.comboBox2.Text = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["슈트앞"].Value.ToString();
      this.comboBox3.Text = this.rGrid2.Rows[hitTestInfo.RowIndex].Cells["슈트뒤"].Value.ToString();
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
  }

  private void 추가버튼2_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid3.Rows)
    {
      if (row.Cells["프린터명"].Value.ToString() == this.comboBox4.Text)
      {
        Common.ErrorMessageBox("이미 동일한 프린터가 등록되어 있습니다.");
        return;
      }
    }
    this.rGrid3.Rows.Add(new object[1]
    {
      (object) this.comboBox4.Text
    });
  }

  private void 삭제버튼2_Click(object sender, EventArgs e)
  {
    if (this.rGrid3.SelectedRows == null || this.rGrid3.SelectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("선택한 대상이 없습니다.");
    }
    else
    {
      if (Common.QuestionMessageBox(this.rGrid3.SelectedRows[0].Cells["프린터명"].Value.ToString() + " 을(를) 삭제 " + "하시겠습니까?") != DialogResult.Yes)
        return;
      this.rGrid3.Rows.Remove(this.rGrid3.SelectedRows[0]);
    }
  }

  private void 모두삭제버튼2_Click(object sender, EventArgs e)
  {
    if (Common.QuestionMessageBox("지정한 설정이 모두 삭제됩니다.\r\n\r\n계속 진행 하시겠습니까?") != DialogResult.Yes)
      return;
    this.rGrid3.Rows.Clear();
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00999));
    this.panel1 = new Panel();
    this.tabControl1 = new TabControl();
    this.tabPage1 = new TabPage();
    this.rTextBox20 = new RTextBox();
    this.rLabel23 = new RLabel();
    this.rTextBox19 = new RTextBox();
    this.rLabel22 = new RLabel();
    this.label3 = new Label();
    this.label2 = new Label();
    this.label1 = new Label();
    this.로컬폴더버튼 = new RButton();
    this.rDivider2 = new RDivider();
    this.numericUpDown2 = new NumericUpDown();
    this.numericUpDown1 = new NumericUpDown();
    this.rLabel10 = new RLabel();
    this.rLabel9 = new RLabel();
    this.rDivider1 = new RDivider();
    this.rTextBox8 = new RTextBox();
    this.rLabel8 = new RLabel();
    this.rTextBox7 = new RTextBox();
    this.rLabel7 = new RLabel();
    this.rTextBox6 = new RTextBox();
    this.rLabel6 = new RLabel();
    this.rTextBox5 = new RTextBox();
    this.rLabel5 = new RLabel();
    this.rTextBox4 = new RTextBox();
    this.rLabel4 = new RLabel();
    this.rTextBox3 = new RTextBox();
    this.rLabel3 = new RLabel();
    this.rTextBox2 = new RTextBox();
    this.rLabel2 = new RLabel();
    this.rTextBox1 = new RTextBox();
    this.rLabel1 = new RLabel();
    this.tabPage2 = new TabPage();
    this.rGrid1 = new RGrid();
    this.rLabel13 = new RLabel();
    this.rTextBox10 = new RTextBox();
    this.rLabel12 = new RLabel();
    this.rTextBox9 = new RTextBox();
    this.rLabel11 = new RLabel();
    this.rDivider3 = new RDivider();
    this.tabPage3 = new TabPage();
    this.rTextBox18 = new RTextBox();
    this.rLabel21 = new RLabel();
    this.rTextBox17 = new RTextBox();
    this.rLabel20 = new RLabel();
    this.rTextBox16 = new RTextBox();
    this.rLabel19 = new RLabel();
    this.rTextBox15 = new RTextBox();
    this.rLabel18 = new RLabel();
    this.rDivider5 = new RDivider();
    this.rTextBox14 = new RTextBox();
    this.rLabel17 = new RLabel();
    this.rTextBox13 = new RTextBox();
    this.rLabel16 = new RLabel();
    this.rTextBox12 = new RTextBox();
    this.rLabel15 = new RLabel();
    this.rTextBox11 = new RTextBox();
    this.rLabel14 = new RLabel();
    this.rDivider4 = new RDivider();
    this.tabPage4 = new TabPage();
    this.모두삭제버튼 = new RButton();
    this.삭제버튼 = new RButton();
    this.수정버튼 = new RButton();
    this.추가버튼 = new RButton();
    this.comboBox3 = new ComboBox();
    this.label4 = new Label();
    this.comboBox2 = new ComboBox();
    this.rLabel26 = new RLabel();
    this.comboBox1 = new ComboBox();
    this.rLabel25 = new RLabel();
    this.rDivider6 = new RDivider();
    this.rGrid2 = new RGrid();
    this.rLabel24 = new RLabel();
    this.rPanel1 = new RPanel();
    this.checkBox1 = new CheckBox();
    this.연결테스트버튼 = new RButton();
    this.저장버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.tabPage5 = new TabPage();
    this.모두삭제버튼2 = new RButton();
    this.삭제버튼2 = new RButton();
    this.추가버튼2 = new RButton();
    this.comboBox4 = new ComboBox();
    this.rLabel27 = new RLabel();
    this.rDivider7 = new RDivider();
    this.rGrid3 = new RGrid();
    this.rLabel28 = new RLabel();
    this.panel1.SuspendLayout();
    this.tabControl1.SuspendLayout();
    this.tabPage1.SuspendLayout();
    this.numericUpDown2.BeginInit();
    this.numericUpDown1.BeginInit();
    this.tabPage2.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.tabPage3.SuspendLayout();
    this.tabPage4.SuspendLayout();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    this.rPanel1.SuspendLayout();
    this.tabPage5.SuspendLayout();
    ((ISupportInitialize) this.rGrid3).BeginInit();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.BackColor = Color.White;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.tabControl1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 46);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(696, 367);
    this.panel1.TabIndex = 0;
    this.tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage1);
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage2);
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage3);
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage4);
    this.tabControl1.Controls.Add((System.Windows.Forms.Control) this.tabPage5);
    this.tabControl1.Location = new Point(6, 52);
    this.tabControl1.Name = "tabControl1";
    this.tabControl1.SelectedIndex = 0;
    this.tabControl1.Size = new Size(684, 310);
    this.tabControl1.TabIndex = 2;
    this.tabControl1.SelectedIndexChanged += new EventHandler(this.tabControl1_SelectedIndexChanged);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox20);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel23);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox19);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel22);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.label3);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.로컬폴더버튼);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rDivider2);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.numericUpDown2);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.numericUpDown1);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel10);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel9);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rDivider1);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox8);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel8);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox7);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel7);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox6);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel6);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox5);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel5);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox4);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel4);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox3);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel3);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox2);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rTextBox1);
    this.tabPage1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.tabPage1.Location = new Point(4, 22);
    this.tabPage1.Name = "tabPage1";
    this.tabPage1.Padding = new Padding(3);
    this.tabPage1.Size = new Size(676, 284);
    this.tabPage1.TabIndex = 0;
    this.tabPage1.Text = "PAS";
    this.tabPage1.UseVisualStyleBackColor = true;
    this.rTextBox20.FocusedColor = SystemColors.Window;
    this.rTextBox20.Location = new Point(471, 86);
    this.rTextBox20.Name = "rTextBox20";
    this.rTextBox20.Size = new Size(80 /*0x50*/, 21);
    this.rTextBox20.TabIndex = 5;
    this.rTextBox20.TextType = RTextBoxType.Both;
    this.rLabel23.Control = (System.Windows.Forms.Control) null;
    this.rLabel23.ForeColor = Color.DimGray;
    this.rLabel23.IsBulletPoint = true;
    this.rLabel23.Location = new Point(380, 85);
    this.rLabel23.Name = "rLabel23";
    this.rLabel23.Size = new Size(90, 23);
    this.rLabel23.TabIndex = 28;
    this.rLabel23.Text = "초과슈트";
    this.rTextBox19.FocusedColor = SystemColors.Window;
    this.rTextBox19.Location = new Point(294, 86);
    this.rTextBox19.Name = "rTextBox19";
    this.rTextBox19.Size = new Size(80 /*0x50*/, 21);
    this.rTextBox19.TabIndex = 4;
    this.rTextBox19.TextType = RTextBoxType.Both;
    this.rLabel22.Control = (System.Windows.Forms.Control) null;
    this.rLabel22.ForeColor = Color.DimGray;
    this.rLabel22.IsBulletPoint = true;
    this.rLabel22.Location = new Point(203, 85);
    this.rLabel22.Name = "rLabel22";
    this.rLabel22.Size = new Size(90, 23);
    this.rLabel22.TabIndex = 26;
    this.rLabel22.Text = "부합슈트";
    this.label3.ForeColor = Color.DimGray;
    this.label3.Location = new Point(201, 251);
    this.label3.Name = "label3";
    this.label3.Size = new Size(170, 23);
    this.label3.TabIndex = 24;
    this.label3.Text = "(1회/초)  ex. 기본값 3초";
    this.label3.TextAlign = ContentAlignment.MiddleLeft;
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(201, 222);
    this.label2.Name = "label2";
    this.label2.Size = new Size(170, 23);
    this.label2.TabIndex = 23;
    this.label2.Text = "(1회/초)  ex. 기본값 3초";
    this.label2.TextAlign = ContentAlignment.MiddleLeft;
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(503, 143);
    this.label1.Name = "label1";
    this.label1.Size = new Size(170, 23);
    this.label1.TabIndex = 22;
    this.label1.Text = "ex. \\\\SEIGYO-PC\\Data";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.로컬폴더버튼.ButtonState = RButtonState.None;
    this.로컬폴더버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.로컬폴더버튼.ForeColor = Color.DimGray;
    this.로컬폴더버튼.Image = (Image) pas.mgp.Properties.Resources._1395148894_folder;
    this.로컬폴더버튼.Location = new Point(503, 114);
    this.로컬폴더버튼.Name = "로컬폴더버튼";
    this.로컬폴더버튼.Size = new Size(50, 23);
    this.로컬폴더버튼.TabIndex = 5;
    this.로컬폴더버튼.Tag = (object) "";
    this.로컬폴더버튼.Text = "...";
    this.로컬폴더버튼.UseVisualStyleBackColor = true;
    this.로컬폴더버튼.Click += new EventHandler(this.폴더선택_Click);
    this.rDivider2.ForeColor = Color.DimGray;
    this.rDivider2.Location = new Point(6, 6);
    this.rDivider2.Name = "rDivider2";
    this.rDivider2.Size = new Size(664, 15);
    this.rDivider2.TabIndex = 21;
    this.rDivider2.Text = "기본설정";
    this.numericUpDown2.Location = new Point(97, 252);
    this.numericUpDown2.Name = "numericUpDown2";
    this.numericUpDown2.Size = new Size(100, 21);
    this.numericUpDown2.TabIndex = 11;
    this.numericUpDown1.Location = new Point(97, 223);
    this.numericUpDown1.Name = "numericUpDown1";
    this.numericUpDown1.Size = new Size(100, 21);
    this.numericUpDown1.TabIndex = 10;
    this.rLabel10.Control = (System.Windows.Forms.Control) null;
    this.rLabel10.ForeColor = Color.DimGray;
    this.rLabel10.IsBulletPoint = true;
    this.rLabel10.Location = new Point(6, 251);
    this.rLabel10.Name = "rLabel10";
    this.rLabel10.Size = new Size(90, 23);
    this.rLabel10.TabIndex = 18;
    this.rLabel10.Text = "숫자 표시기";
    this.rLabel9.Control = (System.Windows.Forms.Control) null;
    this.rLabel9.ForeColor = Color.DimGray;
    this.rLabel9.IsBulletPoint = true;
    this.rLabel9.Location = new Point(6, 222);
    this.rLabel9.Name = "rLabel9";
    this.rLabel9.Size = new Size(90, 23);
    this.rLabel9.TabIndex = 17;
    this.rLabel9.Text = "PAS";
    this.rDivider1.ForeColor = Color.DimGray;
    this.rDivider1.Location = new Point(6, 201);
    this.rDivider1.Name = "rDivider1";
    this.rDivider1.Size = new Size(664, 15);
    this.rDivider1.TabIndex = 16 /*0x10*/;
    this.rDivider1.Text = "탐색 시간설정";
    this.rTextBox8.FocusedColor = SystemColors.Window;
    this.rTextBox8.Location = new Point(294, 173);
    this.rTextBox8.Name = "rTextBox8";
    this.rTextBox8.Size = new Size(100, 21);
    this.rTextBox8.TabIndex = 9;
    this.rTextBox8.TextType = RTextBoxType.Both;
    this.rLabel8.Control = (System.Windows.Forms.Control) null;
    this.rLabel8.ForeColor = Color.DimGray;
    this.rLabel8.IsBulletPoint = true;
    this.rLabel8.Location = new Point(203, 172);
    this.rLabel8.Name = "rLabel8";
    this.rLabel8.Size = new Size(90, 23);
    this.rLabel8.TabIndex = 14;
    this.rLabel8.Text = "암호";
    this.rTextBox7.FocusedColor = SystemColors.Window;
    this.rTextBox7.Location = new Point(97, 173);
    this.rTextBox7.Name = "rTextBox7";
    this.rTextBox7.Size = new Size(100, 21);
    this.rTextBox7.TabIndex = 8;
    this.rTextBox7.TextType = RTextBoxType.Both;
    this.rLabel7.Control = (System.Windows.Forms.Control) null;
    this.rLabel7.ForeColor = Color.DimGray;
    this.rLabel7.IsBulletPoint = true;
    this.rLabel7.Location = new Point(6, 172);
    this.rLabel7.Name = "rLabel7";
    this.rLabel7.Size = new Size(90, 23);
    this.rLabel7.TabIndex = 12;
    this.rLabel7.Text = "계정";
    this.rTextBox6.FocusedColor = SystemColors.Window;
    this.rTextBox6.Location = new Point(97, 144 /*0x90*/);
    this.rTextBox6.Name = "rTextBox6";
    this.rTextBox6.Size = new Size(400, 21);
    this.rTextBox6.TabIndex = 7;
    this.rTextBox6.TextType = RTextBoxType.Both;
    this.rLabel6.Control = (System.Windows.Forms.Control) null;
    this.rLabel6.ForeColor = Color.DimGray;
    this.rLabel6.IsBulletPoint = true;
    this.rLabel6.Location = new Point(6, 143);
    this.rLabel6.Name = "rLabel6";
    this.rLabel6.Size = new Size(90, 23);
    this.rLabel6.TabIndex = 10;
    this.rLabel6.Text = "공유폴더";
    this.rTextBox5.FocusedColor = SystemColors.Window;
    this.rTextBox5.Location = new Point(97, 115);
    this.rTextBox5.Name = "rTextBox5";
    this.rTextBox5.Size = new Size(400, 21);
    this.rTextBox5.TabIndex = 6;
    this.rTextBox5.TextType = RTextBoxType.Both;
    this.rLabel5.Control = (System.Windows.Forms.Control) null;
    this.rLabel5.ForeColor = Color.DimGray;
    this.rLabel5.IsBulletPoint = true;
    this.rLabel5.Location = new Point(6, 114);
    this.rLabel5.Name = "rLabel5";
    this.rLabel5.Size = new Size(90, 23);
    this.rLabel5.TabIndex = 8;
    this.rLabel5.Text = "로컬폴더";
    this.rTextBox4.FocusedColor = SystemColors.Window;
    this.rTextBox4.Location = new Point(97, 86);
    this.rTextBox4.Name = "rTextBox4";
    this.rTextBox4.Size = new Size(100, 21);
    this.rTextBox4.TabIndex = 3;
    this.rTextBox4.TextType = RTextBoxType.Both;
    this.rLabel4.Control = (System.Windows.Forms.Control) null;
    this.rLabel4.ForeColor = Color.DimGray;
    this.rLabel4.IsBulletPoint = true;
    this.rLabel4.Location = new Point(6, 85);
    this.rLabel4.Name = "rLabel4";
    this.rLabel4.Size = new Size(90, 23);
    this.rLabel4.TabIndex = 6;
    this.rLabel4.Text = "슈트수";
    this.rTextBox3.FocusedColor = SystemColors.Window;
    this.rTextBox3.Location = new Point(294, 57);
    this.rTextBox3.Name = "rTextBox3";
    this.rTextBox3.Size = new Size(80 /*0x50*/, 21);
    this.rTextBox3.TabIndex = 2;
    this.rTextBox3.TextType = RTextBoxType.OnlyNumeric;
    this.rLabel3.Control = (System.Windows.Forms.Control) null;
    this.rLabel3.ForeColor = Color.DimGray;
    this.rLabel3.IsBulletPoint = true;
    this.rLabel3.Location = new Point(203, 56);
    this.rLabel3.Name = "rLabel3";
    this.rLabel3.Size = new Size(90, 23);
    this.rLabel3.TabIndex = 4;
    this.rLabel3.Text = "포트";
    this.rTextBox2.FocusedColor = SystemColors.Window;
    this.rTextBox2.Location = new Point(97, 57);
    this.rTextBox2.Name = "rTextBox2";
    this.rTextBox2.Size = new Size(100, 21);
    this.rTextBox2.TabIndex = 1;
    this.rTextBox2.TextType = RTextBoxType.Both;
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(6, 56);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(90, 23);
    this.rLabel2.TabIndex = 2;
    this.rLabel2.Text = "주소";
    this.rTextBox1.BackColor = SystemColors.Window;
    this.rTextBox1.FocusedColor = SystemColors.Window;
    this.rTextBox1.Location = new Point(97, 28);
    this.rTextBox1.Name = "rTextBox1";
    this.rTextBox1.Size = new Size(100, 21);
    this.rTextBox1.TabIndex = 0;
    this.rTextBox1.TextType = RTextBoxType.Both;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(6, 27);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(90, 23);
    this.rLabel1.TabIndex = 0;
    this.rLabel1.Text = "라인명";
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rLabel13);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rTextBox10);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rLabel12);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rTextBox9);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rLabel11);
    this.tabPage2.Controls.Add((System.Windows.Forms.Control) this.rDivider3);
    this.tabPage2.Location = new Point(4, 22);
    this.tabPage2.Name = "tabPage2";
    this.tabPage2.Padding = new Padding(3);
    this.tabPage2.Size = new Size(676, 284);
    this.tabPage2.TabIndex = 1;
    this.tabPage2.Text = "숫자 표시기";
    this.tabPage2.UseVisualStyleBackColor = true;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid1.BackgroundColor = Color.White;
    this.rGrid1.DataSource2 = (object) null;
    this.rGrid1.Location = new Point(97, 55);
    this.rGrid1.Name = "rGrid1";
    gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle1.BackColor = SystemColors.Control;
    gridViewCellStyle1.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle1.ForeColor = SystemColors.WindowText;
    gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle1.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
    this.rGrid1.RowHeadersDefaultCellStyle = gridViewCellStyle1;
    this.rGrid1.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid1.Size = new Size(573, 223);
    this.rGrid1.TabIndex = 28;
    this.rLabel13.Control = (System.Windows.Forms.Control) null;
    this.rLabel13.ForeColor = Color.DimGray;
    this.rLabel13.IsBulletPoint = true;
    this.rLabel13.Location = new Point(6, 56);
    this.rLabel13.Name = "rLabel13";
    this.rLabel13.Size = new Size(90, 23);
    this.rLabel13.TabIndex = 27;
    this.rLabel13.Text = "구성";
    this.rTextBox10.FocusedColor = SystemColors.Window;
    this.rTextBox10.Location = new Point(294, 28);
    this.rTextBox10.Name = "rTextBox10";
    this.rTextBox10.Size = new Size(100, 21);
    this.rTextBox10.TabIndex = 26;
    this.rTextBox10.TextType = RTextBoxType.OnlyNumeric;
    this.rLabel12.Control = (System.Windows.Forms.Control) null;
    this.rLabel12.ForeColor = Color.DimGray;
    this.rLabel12.IsBulletPoint = true;
    this.rLabel12.Location = new Point(203, 27);
    this.rLabel12.Name = "rLabel12";
    this.rLabel12.Size = new Size(90, 23);
    this.rLabel12.TabIndex = 25;
    this.rLabel12.Text = "포트";
    this.rTextBox9.FocusedColor = SystemColors.Window;
    this.rTextBox9.Location = new Point(97, 28);
    this.rTextBox9.Name = "rTextBox9";
    this.rTextBox9.Size = new Size(100, 21);
    this.rTextBox9.TabIndex = 24;
    this.rTextBox9.TextType = RTextBoxType.Both;
    this.rLabel11.Control = (System.Windows.Forms.Control) null;
    this.rLabel11.ForeColor = Color.DimGray;
    this.rLabel11.IsBulletPoint = true;
    this.rLabel11.Location = new Point(6, 27);
    this.rLabel11.Name = "rLabel11";
    this.rLabel11.Size = new Size(90, 23);
    this.rLabel11.TabIndex = 23;
    this.rLabel11.Text = "주소";
    this.rDivider3.ForeColor = Color.DimGray;
    this.rDivider3.Location = new Point(6, 6);
    this.rDivider3.Name = "rDivider3";
    this.rDivider3.Size = new Size(664, 15);
    this.rDivider3.TabIndex = 22;
    this.rDivider3.Text = "기본설정 (코텍 전용)";
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox18);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel21);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox17);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel20);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox16);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel19);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox15);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel18);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rDivider5);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox14);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel17);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox13);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel16);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox12);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel15);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rTextBox11);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rLabel14);
    this.tabPage3.Controls.Add((System.Windows.Forms.Control) this.rDivider4);
    this.tabPage3.Location = new Point(4, 22);
    this.tabPage3.Name = "tabPage3";
    this.tabPage3.Size = new Size(676, 284);
    this.tabPage3.TabIndex = 2;
    this.tabPage3.Text = "데이터베이스";
    this.tabPage3.UseVisualStyleBackColor = true;
    this.rTextBox18.FocusedColor = SystemColors.Window;
    this.rTextBox18.Location = new Point(97, 252);
    this.rTextBox18.Name = "rTextBox18";
    this.rTextBox18.Size = new Size(150, 21);
    this.rTextBox18.TabIndex = 7;
    this.rTextBox18.TextType = RTextBoxType.Both;
    this.rLabel21.Control = (System.Windows.Forms.Control) null;
    this.rLabel21.ForeColor = Color.DimGray;
    this.rLabel21.IsBulletPoint = true;
    this.rLabel21.Location = new Point(6, 251);
    this.rLabel21.Name = "rLabel21";
    this.rLabel21.Size = new Size(90, 23);
    this.rLabel21.TabIndex = 40;
    this.rLabel21.Text = "암호";
    this.rTextBox17.FocusedColor = SystemColors.Window;
    this.rTextBox17.Location = new Point(97, 223);
    this.rTextBox17.Name = "rTextBox17";
    this.rTextBox17.Size = new Size(150, 21);
    this.rTextBox17.TabIndex = 6;
    this.rTextBox17.TextType = RTextBoxType.Both;
    this.rLabel20.Control = (System.Windows.Forms.Control) null;
    this.rLabel20.ForeColor = Color.DimGray;
    this.rLabel20.IsBulletPoint = true;
    this.rLabel20.Location = new Point(6, 222);
    this.rLabel20.Name = "rLabel20";
    this.rLabel20.Size = new Size(90, 23);
    this.rLabel20.TabIndex = 38;
    this.rLabel20.Text = "계정";
    this.rTextBox16.FocusedColor = SystemColors.Window;
    this.rTextBox16.Location = new Point(97, 194);
    this.rTextBox16.Name = "rTextBox16";
    this.rTextBox16.Size = new Size(150, 21);
    this.rTextBox16.TabIndex = 5;
    this.rTextBox16.TextType = RTextBoxType.Both;
    this.rLabel19.Control = (System.Windows.Forms.Control) null;
    this.rLabel19.ForeColor = Color.DimGray;
    this.rLabel19.IsBulletPoint = true;
    this.rLabel19.Location = new Point(6, 193);
    this.rLabel19.Name = "rLabel19";
    this.rLabel19.Size = new Size(90, 23);
    this.rLabel19.TabIndex = 36;
    this.rLabel19.Text = "서비스명";
    this.rTextBox15.FocusedColor = SystemColors.Window;
    this.rTextBox15.Location = new Point(97, 165);
    this.rTextBox15.Name = "rTextBox15";
    this.rTextBox15.Size = new Size(150, 21);
    this.rTextBox15.TabIndex = 4;
    this.rTextBox15.TextType = RTextBoxType.Both;
    this.rLabel18.Control = (System.Windows.Forms.Control) null;
    this.rLabel18.ForeColor = Color.DimGray;
    this.rLabel18.IsBulletPoint = true;
    this.rLabel18.Location = new Point(6, 164);
    this.rLabel18.Name = "rLabel18";
    this.rLabel18.Size = new Size(90, 23);
    this.rLabel18.TabIndex = 34;
    this.rLabel18.Text = "주소";
    this.rDivider5.ForeColor = Color.DimGray;
    this.rDivider5.Location = new Point(6, 143);
    this.rDivider5.Name = "rDivider5";
    this.rDivider5.Size = new Size(664, 15);
    this.rDivider5.TabIndex = 33;
    this.rDivider5.Text = "상위 시스템 데이터베이스";
    this.rTextBox14.FocusedColor = SystemColors.Window;
    this.rTextBox14.Location = new Point(97, 115);
    this.rTextBox14.Name = "rTextBox14";
    this.rTextBox14.Size = new Size(150, 21);
    this.rTextBox14.TabIndex = 3;
    this.rTextBox14.TextType = RTextBoxType.Both;
    this.rLabel17.Control = (System.Windows.Forms.Control) null;
    this.rLabel17.ForeColor = Color.DimGray;
    this.rLabel17.IsBulletPoint = true;
    this.rLabel17.Location = new Point(6, 114);
    this.rLabel17.Name = "rLabel17";
    this.rLabel17.Size = new Size(90, 23);
    this.rLabel17.TabIndex = 31 /*0x1F*/;
    this.rLabel17.Text = "암호";
    this.rTextBox13.FocusedColor = SystemColors.Window;
    this.rTextBox13.Location = new Point(97, 86);
    this.rTextBox13.Name = "rTextBox13";
    this.rTextBox13.Size = new Size(150, 21);
    this.rTextBox13.TabIndex = 2;
    this.rTextBox13.TextType = RTextBoxType.Both;
    this.rLabel16.Control = (System.Windows.Forms.Control) null;
    this.rLabel16.ForeColor = Color.DimGray;
    this.rLabel16.IsBulletPoint = true;
    this.rLabel16.Location = new Point(6, 85);
    this.rLabel16.Name = "rLabel16";
    this.rLabel16.Size = new Size(90, 23);
    this.rLabel16.TabIndex = 29;
    this.rLabel16.Text = "계정";
    this.rTextBox12.FocusedColor = SystemColors.Window;
    this.rTextBox12.Location = new Point(97, 57);
    this.rTextBox12.Name = "rTextBox12";
    this.rTextBox12.Size = new Size(150, 21);
    this.rTextBox12.TabIndex = 1;
    this.rTextBox12.TextType = RTextBoxType.Both;
    this.rLabel15.Control = (System.Windows.Forms.Control) null;
    this.rLabel15.ForeColor = Color.DimGray;
    this.rLabel15.IsBulletPoint = true;
    this.rLabel15.Location = new Point(6, 56);
    this.rLabel15.Name = "rLabel15";
    this.rLabel15.Size = new Size(90, 23);
    this.rLabel15.TabIndex = 27;
    this.rLabel15.Text = "서비스명";
    this.rTextBox11.BackColor = SystemColors.Window;
    this.rTextBox11.FocusedColor = SystemColors.Window;
    this.rTextBox11.Location = new Point(97, 28);
    this.rTextBox11.Name = "rTextBox11";
    this.rTextBox11.Size = new Size(150, 21);
    this.rTextBox11.TabIndex = 0;
    this.rTextBox11.TextType = RTextBoxType.Both;
    this.rLabel14.Control = (System.Windows.Forms.Control) null;
    this.rLabel14.ForeColor = Color.DimGray;
    this.rLabel14.IsBulletPoint = true;
    this.rLabel14.Location = new Point(6, 27);
    this.rLabel14.Name = "rLabel14";
    this.rLabel14.Size = new Size(90, 23);
    this.rLabel14.TabIndex = 25;
    this.rLabel14.Text = "주소";
    this.rDivider4.ForeColor = Color.DimGray;
    this.rDivider4.Location = new Point(6, 6);
    this.rDivider4.Name = "rDivider4";
    this.rDivider4.Size = new Size(664, 15);
    this.rDivider4.TabIndex = 22;
    this.rDivider4.Text = "PAS 데이터베이스";
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.모두삭제버튼);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.삭제버튼);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.수정버튼);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.추가버튼);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.comboBox3);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.label4);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.comboBox2);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.rLabel26);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.rLabel25);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.rDivider6);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.tabPage4.Controls.Add((System.Windows.Forms.Control) this.rLabel24);
    this.tabPage4.Location = new Point(4, 22);
    this.tabPage4.Name = "tabPage4";
    this.tabPage4.Size = new Size(676, 284);
    this.tabPage4.TabIndex = 3;
    this.tabPage4.Text = "바코드 프린터";
    this.tabPage4.UseVisualStyleBackColor = true;
    this.모두삭제버튼.ButtonState = RButtonState.None;
    this.모두삭제버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.모두삭제버튼.ForeColor = Color.DimGray;
    this.모두삭제버튼.Image = (Image) pas.mgp.Properties.Resources._1395148857_eraser;
    this.모두삭제버튼.Location = new Point(580, 57);
    this.모두삭제버튼.Name = "모두삭제버튼";
    this.모두삭제버튼.Size = new Size(90, 23);
    this.모두삭제버튼.TabIndex = 39;
    this.모두삭제버튼.Text = "모두삭제";
    this.모두삭제버튼.UseVisualStyleBackColor = true;
    this.모두삭제버튼.Click += new EventHandler(this.모두삭제버튼_Click);
    this.삭제버튼.ButtonState = RButtonState.None;
    this.삭제버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.삭제버튼.ForeColor = Color.DimGray;
    this.삭제버튼.Image = (Image) pas.mgp.Properties.Resources._1395148857_eraser;
    this.삭제버튼.Location = new Point(489, 57);
    this.삭제버튼.Name = "삭제버튼";
    this.삭제버튼.Size = new Size(90, 23);
    this.삭제버튼.TabIndex = 38;
    this.삭제버튼.Text = "삭 제";
    this.삭제버튼.UseVisualStyleBackColor = true;
    this.삭제버튼.Click += new EventHandler(this.삭제버튼_Click);
    this.수정버튼.ButtonState = RButtonState.None;
    this.수정버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.수정버튼.ForeColor = Color.DimGray;
    this.수정버튼.Image = (Image) pas.mgp.Properties.Resources._1395148868_pencil_edit;
    this.수정버튼.Location = new Point(398, 57);
    this.수정버튼.Name = "수정버튼";
    this.수정버튼.Size = new Size(90, 23);
    this.수정버튼.TabIndex = 37;
    this.수정버튼.Text = "수 정";
    this.수정버튼.UseVisualStyleBackColor = true;
    this.수정버튼.Click += new EventHandler(this.수정버튼_Click);
    this.추가버튼.ButtonState = RButtonState.None;
    this.추가버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.추가버튼.ForeColor = Color.DimGray;
    this.추가버튼.Image = (Image) pas.mgp.Properties.Resources._1395148933_plus;
    this.추가버튼.Location = new Point(307, 57);
    this.추가버튼.Name = "추가버튼";
    this.추가버튼.Size = new Size(90, 23);
    this.추가버튼.TabIndex = 4;
    this.추가버튼.Text = "추 가";
    this.추가버튼.UseVisualStyleBackColor = true;
    this.추가버튼.Click += new EventHandler(this.추가버튼_Click);
    this.comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox3.FormattingEnabled = true;
    this.comboBox3.Location = new Point(203, 57);
    this.comboBox3.Name = "comboBox3";
    this.comboBox3.Size = new Size(80 /*0x50*/, 20);
    this.comboBox3.TabIndex = 36;
    this.label4.AutoSize = true;
    this.label4.ForeColor = Color.DimGray;
    this.label4.Location = new Point(183, 62);
    this.label4.Name = "label4";
    this.label4.Size = new Size(14, 12);
    this.label4.TabIndex = 35;
    this.label4.Text = "~";
    this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox2.FormattingEnabled = true;
    this.comboBox2.Location = new Point(97, 57);
    this.comboBox2.Name = "comboBox2";
    this.comboBox2.Size = new Size(80 /*0x50*/, 20);
    this.comboBox2.TabIndex = 34;
    this.rLabel26.Control = (System.Windows.Forms.Control) null;
    this.rLabel26.ForeColor = Color.DimGray;
    this.rLabel26.IsBulletPoint = true;
    this.rLabel26.Location = new Point(6, 56);
    this.rLabel26.Name = "rLabel26";
    this.rLabel26.Size = new Size(90, 23);
    this.rLabel26.TabIndex = 33;
    this.rLabel26.Text = "슈트범위";
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.DropDownWidth = 300;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(97, 28);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(186, 20);
    this.comboBox1.TabIndex = 32 /*0x20*/;
    this.rLabel25.Control = (System.Windows.Forms.Control) null;
    this.rLabel25.ForeColor = Color.DimGray;
    this.rLabel25.IsBulletPoint = true;
    this.rLabel25.Location = new Point(6, 27);
    this.rLabel25.Name = "rLabel25";
    this.rLabel25.Size = new Size(90, 23);
    this.rLabel25.TabIndex = 31 /*0x1F*/;
    this.rLabel25.Text = "프린터";
    this.rDivider6.ForeColor = Color.DimGray;
    this.rDivider6.Location = new Point(6, 6);
    this.rDivider6.Name = "rDivider6";
    this.rDivider6.Size = new Size(664, 15);
    this.rDivider6.TabIndex = 30;
    this.rDivider6.Text = "바코드 프린터";
    this.rGrid2.AllowUserToAddRows = false;
    this.rGrid2.AllowUserToDeleteRows = false;
    this.rGrid2.AlternateColor = Color.Empty;
    this.rGrid2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid2.BackgroundColor = Color.White;
    this.rGrid2.DataSource2 = (object) null;
    this.rGrid2.Location = new Point(97, 85);
    this.rGrid2.Name = "rGrid2";
    gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle2.BackColor = SystemColors.Control;
    gridViewCellStyle2.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle2.ForeColor = SystemColors.WindowText;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle2.WrapMode = DataGridViewTriState.True;
    this.rGrid2.RowHeadersDefaultCellStyle = gridViewCellStyle2;
    this.rGrid2.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid2.Size = new Size(573, 196);
    this.rGrid2.TabIndex = 29;
    this.rGrid2.MouseUp += new MouseEventHandler(this.rGrid2_MouseUp);
    this.rLabel24.Control = (System.Windows.Forms.Control) null;
    this.rLabel24.ForeColor = Color.DimGray;
    this.rLabel24.IsBulletPoint = true;
    this.rLabel24.Location = new Point(6, 85);
    this.rLabel24.Name = "rLabel24";
    this.rLabel24.Size = new Size(90, 23);
    this.rLabel24.TabIndex = 28;
    this.rLabel24.Text = "리스트";
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.연결테스트버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.저장버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 6);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(684, 40);
    this.rPanel1.TabIndex = 1;
    this.checkBox1.AutoSize = true;
    this.checkBox1.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(6, 12);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(76, 16 /*0x10*/);
    this.checkBox1.TabIndex = 3;
    this.checkBox1.Text = "전체선택";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox1.Click += new EventHandler(this.checkBox1_Click);
    this.연결테스트버튼.ButtonState = RButtonState.None;
    this.연결테스트버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.연결테스트버튼.ForeColor = Color.DimGray;
    this.연결테스트버튼.Image = (Image) pas.mgp.Properties.Resources._1395148946_network;
    this.연결테스트버튼.Location = new Point(394, 9);
    this.연결테스트버튼.Name = "연결테스트버튼";
    this.연결테스트버튼.Size = new Size(100, 23);
    this.연결테스트버튼.TabIndex = 0;
    this.연결테스트버튼.Text = "연결 테스트";
    this.연결테스트버튼.UseVisualStyleBackColor = true;
    this.연결테스트버튼.Click += new EventHandler(this.연결테스트버튼_Click);
    this.저장버튼.ButtonState = RButtonState.None;
    this.저장버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.저장버튼.ForeColor = Color.DimGray;
    this.저장버튼.Image = (Image) pas.mgp.Properties.Resources._1395148853_save_as;
    this.저장버튼.Location = new Point(495, 9);
    this.저장버튼.Name = "저장버튼";
    this.저장버튼.Size = new Size(90, 23);
    this.저장버튼.TabIndex = 1;
    this.저장버튼.Text = "저 장";
    this.저장버튼.UseVisualStyleBackColor = true;
    this.저장버튼.Click += new EventHandler(this.저장버튼_Click);
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(586, 9);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 2;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.모두삭제버튼2);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.삭제버튼2);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.추가버튼2);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.comboBox4);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.rLabel27);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.rDivider7);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.rGrid3);
    this.tabPage5.Controls.Add((System.Windows.Forms.Control) this.rLabel28);
    this.tabPage5.Location = new Point(4, 22);
    this.tabPage5.Name = "tabPage5";
    this.tabPage5.Size = new Size(676, 284);
    this.tabPage5.TabIndex = 4;
    this.tabPage5.Text = "거래명세서 프린터";
    this.tabPage5.UseVisualStyleBackColor = true;
    this.모두삭제버튼2.ButtonState = RButtonState.None;
    this.모두삭제버튼2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.모두삭제버튼2.ForeColor = Color.DimGray;
    this.모두삭제버튼2.Image = (Image) pas.mgp.Properties.Resources._1395148857_eraser;
    this.모두삭제버튼2.Location = new Point(489, 25);
    this.모두삭제버튼2.Name = "모두삭제버튼2";
    this.모두삭제버튼2.Size = new Size(90, 23);
    this.모두삭제버튼2.TabIndex = 47;
    this.모두삭제버튼2.Text = "모두삭제";
    this.모두삭제버튼2.UseVisualStyleBackColor = true;
    this.모두삭제버튼2.Click += new EventHandler(this.모두삭제버튼2_Click);
    this.삭제버튼2.ButtonState = RButtonState.None;
    this.삭제버튼2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.삭제버튼2.ForeColor = Color.DimGray;
    this.삭제버튼2.Image = (Image) pas.mgp.Properties.Resources._1395148857_eraser;
    this.삭제버튼2.Location = new Point(398, 25);
    this.삭제버튼2.Name = "삭제버튼2";
    this.삭제버튼2.Size = new Size(90, 23);
    this.삭제버튼2.TabIndex = 46;
    this.삭제버튼2.Text = "삭 제";
    this.삭제버튼2.UseVisualStyleBackColor = true;
    this.삭제버튼2.Click += new EventHandler(this.삭제버튼2_Click);
    this.추가버튼2.ButtonState = RButtonState.None;
    this.추가버튼2.Font = new Font("굴림", 9f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.추가버튼2.ForeColor = Color.DimGray;
    this.추가버튼2.Image = (Image) pas.mgp.Properties.Resources._1395148933_plus;
    this.추가버튼2.Location = new Point(307, 25);
    this.추가버튼2.Name = "추가버튼2";
    this.추가버튼2.Size = new Size(90, 23);
    this.추가버튼2.TabIndex = 40;
    this.추가버튼2.Text = "추 가";
    this.추가버튼2.UseVisualStyleBackColor = true;
    this.추가버튼2.Click += new EventHandler(this.추가버튼2_Click);
    this.comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox4.DropDownWidth = 300;
    this.comboBox4.FormattingEnabled = true;
    this.comboBox4.Location = new Point(97, 27);
    this.comboBox4.Name = "comboBox4";
    this.comboBox4.Size = new Size(186, 20);
    this.comboBox4.TabIndex = 45;
    this.rLabel27.Control = (System.Windows.Forms.Control) null;
    this.rLabel27.ForeColor = Color.DimGray;
    this.rLabel27.IsBulletPoint = true;
    this.rLabel27.Location = new Point(6, 26);
    this.rLabel27.Name = "rLabel27";
    this.rLabel27.Size = new Size(90, 23);
    this.rLabel27.TabIndex = 44;
    this.rLabel27.Text = "프린터";
    this.rDivider7.ForeColor = Color.DimGray;
    this.rDivider7.Location = new Point(6, 5);
    this.rDivider7.Name = "rDivider7";
    this.rDivider7.Size = new Size(664, 15);
    this.rDivider7.TabIndex = 43;
    this.rDivider7.Text = "거래명세서 프린터";
    this.rGrid3.AllowUserToAddRows = false;
    this.rGrid3.AllowUserToDeleteRows = false;
    this.rGrid3.AlternateColor = Color.Empty;
    this.rGrid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid3.BackgroundColor = Color.White;
    this.rGrid3.DataSource2 = (object) null;
    this.rGrid3.Location = new Point(97, 53);
    this.rGrid3.Name = "rGrid3";
    gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle3.BackColor = SystemColors.Control;
    gridViewCellStyle3.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle3.ForeColor = SystemColors.WindowText;
    gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle3.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
    this.rGrid3.RowHeadersDefaultCellStyle = gridViewCellStyle3;
    this.rGrid3.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid3.Size = new Size(573, 228);
    this.rGrid3.TabIndex = 42;
    this.rLabel28.Control = (System.Windows.Forms.Control) null;
    this.rLabel28.ForeColor = Color.DimGray;
    this.rLabel28.IsBulletPoint = true;
    this.rLabel28.Location = new Point(6, 53);
    this.rLabel28.Name = "rLabel28";
    this.rLabel28.Size = new Size(90, 23);
    this.rLabel28.TabIndex = 41;
    this.rLabel28.Text = "리스트";
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(720, 425);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.KeyPreview = true;
    this.Name = nameof (dlgPAS00999);
    this.Text = "PAS Management Program v1.0";
    this.Text2 = "환경설정";
    this.Shown += new EventHandler(this.frmSetting_Shown);
    this.panel1.ResumeLayout(false);
    this.tabControl1.ResumeLayout(false);
    this.tabPage1.ResumeLayout(false);
    this.tabPage1.PerformLayout();
    this.numericUpDown2.EndInit();
    this.numericUpDown1.EndInit();
    this.tabPage2.ResumeLayout(false);
    this.tabPage2.PerformLayout();
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.tabPage3.ResumeLayout(false);
    this.tabPage3.PerformLayout();
    this.tabPage4.ResumeLayout(false);
    this.tabPage4.PerformLayout();
    ((ISupportInitialize) this.rGrid2).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.rPanel1.PerformLayout();
    this.tabPage5.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid3).EndInit();
    this.ResumeLayout(false);
  }
}
