// Decompiled with JetBrains decompiler
// Type: pas.mgp.frmPAS00061
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
// using pas.mgp.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class frmPAS00061 : Form
{
  private DataTable m_PAS_배치정보Table = new DataTable("usp_PAS_배치정보_Get");
  private DataTable m_연동_작업지시Table = new DataTable("usp_연동_작업지시_Get");
  private DataTable m_분류_작업요약Table = new DataTable("usp_분류_작업요약_Get");
  private IContainer components;
  private Panel panel1;
  private Panel panel2;
  private Panel panel3;
  private PasPanel pasPanel1;
  private RButton 닫기버튼;
  private RPanel rPanel1;
  private RPanel rPanel2;
  private RGrid rGrid1;
  private RGrid rGrid2;
  private RButton 조회버튼;
  private RButton 수신버튼;
  private RButton 로컬새로고침버튼;
  private RButton 수신취소버튼;
  private RGrid rGrid3;
  private RPanel rPanel3;
  private RButton 작성취소버튼;
  private RButton 작업요약조회;
  private RButton 배치작성버튼;
  private Splitter splitter1;
  private CheckBox checkBox2;
  private CheckBox checkBox1;
  private RLabel rLabel1;
  private RTextBox 분류명;
  private ComboBox comboBox1;
  private RLabel rLabel2;
  private CheckBox checkBox3;
  private DateTimePicker dateTimePicker1;
  private RLabel rLabel4;
  private DateTimePicker dateTimePicker2;
  private Label label1;
  private RButton 슈트조정버튼;
  private RButton 배치명변경버튼;
  private RButton 출하위치변경버튼;

  private string 기간앞 => this.dateTimePicker1.Value.ToString("yyyyMMdd");

  private string 기간뒤 => this.dateTimePicker2.Value.ToString("yyyyMMdd");

  public frmPAS00061()
  {
    this.InitializeComponent();
    this.Text = "배치수신 및 생성";
    this.BackColor = Color.White;
    Common.RGrid_Initializing(this.rGrid1, false);
    Common.RGrid_Initializing(this.rGrid2, false);
    Common.RGrid_Initializing(this.rGrid3, false);
    this.rLabel1.BackColor = this.rPanel3.PanelColor;
    this.rLabel2.BackColor = this.rPanel3.PanelColor;
    this.rLabel4.BackColor = this.rPanel1.PanelColor;
    this.rLabel1.Control = (System.Windows.Forms.Control) this.분류명;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.comboBox1;
    this.label1.ForeColor = Color.DimGray;
    this.dateTimePicker1.Value = DateTime.Now;
    this.dateTimePicker2.Value = DateTime.Now;
    this.분류명.FocusedColor = SystemColors.Info;
    this.splitter1.BackColor = Common.SPLITTER_COLOR;
    this.comboBox1.Items.Add((object) "사용안함");
    this.comboBox1.Items.Add((object) "A라인");
    this.comboBox1.Items.Add((object) "B라인");
    this.comboBox1.Items.Add((object) "균등");
    this.comboBox1.SelectedIndex = 3;
    this.PAS_배치정보_조회(조회구분자.가조회);
    this.연동_작업지시_조회(조회구분자.가조회);
    this.분류_작업요약_조회(조회구분자.가조회);
  }

  private void PAS_배치정보_조회(조회구분자 e)
  {
    this.checkBox1.Checked = false;
    DbProvider.Select(Common.ConnectionString(DB연결구분.시스템), this.m_PAS_배치정보Table, DbProvider.GetParameter("@기간앞", (object) this.기간앞, ParameterDirection.Input), DbProvider.GetParameter("@기간뒤", (object) this.기간뒤, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid1.DataSource2 = (object) this.m_PAS_배치정보Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid1.Columns)
    {
      if (column.HeaderText == "선택")
      {
        column.ReadOnly = false;
      }
      else
      {
        column.ReadOnly = true;
        switch (column.HeaderText)
        {
          case "센터코드":
          case "장비구분":
          case "배치구분코드":
          case "분류구분":
          case "분류구분코드":
          case "출하구분코드":
          case "출력여부코드":
            column.Visible = false;
            continue;
          default:
            column.Visible = true;
            continue;
        }
      }
    }
  }

  private void 연동_작업지시_조회(조회구분자 e)
  {
    this.checkBox2.Checked = false;
    DbProvider.Select(Common.ConnectionString(), this.m_연동_작업지시Table, DbProvider.GetParameter("@기간앞", (object) this.기간앞, ParameterDirection.Input), DbProvider.GetParameter("@기간뒤", (object) this.기간뒤, ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    this.rGrid2.DataSource2 = (object) this.m_연동_작업지시Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid2.Columns)
    {
      if (column.HeaderText == "선택")
      {
        column.ReadOnly = false;
      }
      else
      {
        column.ReadOnly = true;
        switch (column.HeaderText)
        {
          case "브랜드명":
          case "센터코드":
          case "장비구분":
          case "배치구분코드":
          case "분류구분":
          case "분류구분코드":
          case "출하구분코드":
          case "출력여부코드":
            column.Visible = false;
            continue;
          default:
            column.Visible = true;
            continue;
        }
      }
    }
  }

  private void 분류_작업요약_조회(조회구분자 e)
  {
    this.checkBox3.Checked = false;
    this.분류명.Text = string.Empty;
    this.comboBox1.SelectedIndex = 3;
    DbProvider.Select(Common.ConnectionString(), this.m_분류_작업요약Table, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "모두", ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    List<DataRow> dataRowList = new List<DataRow>();
    foreach (DataRow row in (InternalDataCollectionBase) this.m_분류_작업요약Table.Rows)
    {
      if ((row["분류상태"].ToString() == "종료" || row["분류상태"].ToString() == "중단") && !dataRowList.Contains(row))
        dataRowList.Add(row);
    }
    foreach (DataRow row in dataRowList.ToArray())
      this.m_분류_작업요약Table.Rows.Remove(row);
    this.m_분류_작업요약Table.AcceptChanges();
    this.rGrid3.DataSource2 = (object) this.m_분류_작업요약Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid3.Columns)
    {
      if (column.HeaderText == "선택")
      {
        column.ReadOnly = false;
      }
      else
      {
        column.ReadOnly = true;
        switch (column.HeaderText)
        {
          case "순번":
          case "관리번호":
          case "장비구분":
          case "배치구분코드":
          case "출하구분코드":
          case "분류구분":
          case "분류구분코드":
          case "분류방법코드":
          case "패턴구분코드":
          case "분류상태코드":
          case "배치상태코드":
            column.Visible = false;
            continue;
          default:
            column.Visible = true;
            continue;
        }
      }
    }
    if (this.m_분류_작업요약Table.Rows.Count <= 0 || this.rGrid3.SelectedRows == null || this.rGrid3.SelectedRows.Count <= 0)
      return;
    this.분류명.Text = this.rGrid3.SelectedRows[0].Cells["분류명"].Value.ToString();
    if (this.rGrid3.SelectedRows[0].Cells["배치상태"].Value.ToString() == "생성" || this.rGrid3.SelectedRows[0].Cells["배치상태"].Value.ToString() == "수신")
      this.작성취소버튼.Enabled = true;
    else
      this.작성취소버튼.Enabled = false;
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.Close();

  private void 조회버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.PAS_배치정보_조회(조회구분자.실조회);
      this.연동_작업지시_조회(조회구분자.실조회);
      this.분류_작업요약_조회(조회구분자.실조회);
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

  private void 로컬새로고침버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.연동_작업지시_조회(조회구분자.실조회);
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

  private void 수신버튼_Click(object sender, EventArgs e)
  {
    Cursor.Current = Cursors.WaitCursor;
    DataTable oDataTable = new DataTable("usp_PAS_주문정보_Get");
    string empty = string.Empty;
    try
    {
      int num1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.rGrid1.Rows)
      {
        if (row.Cells["선택"].Value.ToString() == bool.TrueString)
        {
          string oValue = row.Cells["배치번호"].Value.ToString();
          DbProvider.Select(Common.ConnectionString(DB연결구분.시스템), oDataTable, DbProvider.GetParameter("@배치번호", (object) oValue, ParameterDirection.Input));
          DbProvider.Bulk(Common.ConnectionString(), "연동_작업지시", oDataTable);
          DbProvider.Excute(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_배치수신_Set", DbProvider.GetParameter("@배치번호", (object) oValue, ParameterDirection.Input));
          ++num1;
        }
      }
      if (num1 > 0)
      {
        int num2 = (int) frmMessageBox.Show("작업지시 내용이 수신 되었습니다.", this.Text, false, true);
      }
      else
      {
        int num3 = (int) frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      this.조회버튼_Click((object) null, EventArgs.Empty);
      Cursor.Current = Cursors.Default;
    }
  }

  private void checkBox1_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid1.Rows)
      row.Cells["선택"].Value = (object) this.checkBox1.Checked;
    this.rGrid1.EndEdit();
  }

  private void checkBox2_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid2.Rows)
      row.Cells["선택"].Value = (object) this.checkBox2.Checked;
    this.rGrid2.EndEdit();
  }

  private void checkBox3_Click(object sender, EventArgs e)
  {
    foreach (DataGridViewRow row in (IEnumerable) this.rGrid3.Rows)
    {
      if (row.Tag == null || !(row.Tag.ToString() == "요약"))
        row.Cells["선택"].Value = (object) this.checkBox3.Checked;
    }
    this.rGrid3.EndEdit();
  }

  private void 수신취소버튼_Click(object sender, EventArgs e)
  {
    Cursor.Current = Cursors.WaitCursor;
    string empty = string.Empty;
    try
    {
      int num1 = 0;
      foreach (DataGridViewRow row in (IEnumerable) this.rGrid2.Rows)
      {
        if (row.Cells["선택"].Value.ToString() == bool.TrueString)
        {
          string oValue = row.Cells["원배치번호"].Value.ToString();
          DbProvider.Excute(Common.ConnectionString(), "usp_연동_수신취소_Set", DbProvider.GetParameter("@원배치번호", (object) oValue, ParameterDirection.Input));
          DbProvider.Excute(Common.ConnectionString(DB연결구분.시스템), "usp_PAS_배치수신취소_Set", DbProvider.GetParameter("@원배치번호", (object) oValue, ParameterDirection.Input));
          ++num1;
        }
      }
      if (num1 > 0)
      {
        int num2 = (int) frmMessageBox.Show("선택한 항목의 수신이 취소 되었습니다.", this.Text, false, true);
      }
      else
      {
        int num3 = (int) frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      this.조회버튼_Click((object) null, EventArgs.Empty);
      Cursor.Current = Cursors.Default;
    }
  }

  private void 작업요약조회_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      this.분류_작업요약_조회(조회구분자.실조회);
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

  private void 배치작성버튼_Click(object sender, EventArgs e)
  {
    try
    {
      Cursor.Current = Cursors.WaitCursor;
      if (Common.Setting.LOCAL_FOLDER != string.Empty && !Directory.Exists(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA))
        Directory.CreateDirectory(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA);
      if (!Directory.Exists(Common.PATH_STARTUP + Common.PATH_TEMP))
        Directory.CreateDirectory(Common.PATH_STARTUP + Common.PATH_TEMP);
      string empty1 = string.Empty;
      string str1 = this.분류명.Text.Trim();
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string empty6 = string.Empty;
      string empty7 = string.Empty;
      string empty8 = string.Empty;
      string empty9 = string.Empty;
      string empty10 = string.Empty;
      string empty11 = string.Empty;
      string empty12 = string.Empty;
      string empty13 = string.Empty;
      if (string.IsNullOrEmpty(str1) && Common.QuestionMessageBox("분류명을 지정하지 않았습니다.\r\n\r\n분류명을 지정하지 않으면 분류번호가 분류명이 됩니다.\r\n\r\n분류명을 지정 하시겠습니까?") == DialogResult.Yes)
        return;
      if (str1.Length > 8)
        str1 = str1.Substring(0, 4);
      string empty14;
      if (this.m_분류_작업요약Table.Rows.Count <= 0)
        empty14 = string.Empty;
      else if (Common.QuestionMessageBox("기 분류번호에 이어서 작업 하시겠습니까?") == DialogResult.No)
      {
        empty14 = string.Empty;
      }
      else
      {
        DataGridViewSelectedRowCollection selectedRows = this.rGrid3.SelectedRows;
        if (selectedRows == null || selectedRows.Count <= 0)
        {
          Common.ErrorMessageBox("분류번호를 선택해 주세요.");
          return;
        }
        empty14 = selectedRows[0].Cells["분류번호"].Value.ToString();
        DataRow[] dataRowArray1 = this.m_분류_작업요약Table.Select($"분류번호='{empty14}'");
        if (dataRowArray1 == null || dataRowArray1.Length <= 0)
        {
          if (Common.QuestionMessageBox($"선택한 분류번호는 {empty14} 입니다.\r\n분류번호가 맞습니까?") == DialogResult.Yes)
          {
            int num = (int) frmMessageBox.Show("더이상 작업을 할 수 없는 분류번호 입니다.", this.Text, false, true);
            return;
          }
          int num1 = (int) frmMessageBox.Show("다른 분류번호를 선택하세요.", this.Text, false, true);
          return;
        }
        DataRow[] dataRowArray2 = this.m_분류_작업요약Table.Select($"분류번호='{empty14}' AND 분류상태 IN ('종료')");
        if (dataRowArray2 != null && dataRowArray2.Length > 0)
        {
          if (Common.QuestionMessageBox("더이상 작업을 할 수\r\n없는 분류번호 입니다.\r\n새 분류번호로 작업 하시겠습니까?") != DialogResult.Yes)
            return;
          if (Common.QuestionMessageBox("분류명을 새로 지정하시겠습니까?") == DialogResult.Yes)
          {
            this.분류명.Text = string.Empty;
            this.분류명.SelectAll();
            return;
          }
          empty14 = string.Empty;
        }
      }
      int iCount = 0;
      DataTable dataTable1 = new DataTable();
      bool flag = empty14 == string.Empty;
      Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Visible = true)));
      Common.전역진행상태.Maximum = this.rGrid2.Rows.Count;
      foreach (DataGridViewRow row1 in (IEnumerable) this.rGrid2.Rows)
      {
        if (row1.Cells["선택"].Value.ToString() == bool.TrueString)
        {
          if (flag && !string.IsNullOrEmpty(row1.Cells["추가배치"].Value.ToString()))
          {
            int num = (int) frmMessageBox.Show("추가 배치는 단독으로 작업할 수 없습니다.", this.Text, false, true);
            return;
          }
          string name = Common.Setting.NAME;
          string oValue1 = row1.Cells["작업일자"].Value.ToString();
          string oValue2 = row1.Cells["배치번호"].Value.ToString();
          string str2 = row1.Cells["원배치번호"].Value.ToString();
          string oValue3 = row1.Cells["배치명"].Value.ToString();
          string oValue4 = row1.Cells["배치구분코드"].Value.ToString();
          string oValue5 = row1.Cells["분류구분코드"].Value.ToString();
          string str3 = row1.Cells["배치구분"].Value.ToString();
          row1.Cells["분류구분"].Value.ToString();
          string oValue6 = this.comboBox1.SelectedIndex.ToString();
          string oValue7 = (!(str3 == "반품") ? 1 : 2).ToString();
          int oValue8 = Common.C2I(row1.Cells["지시수"].Value);
          string sDate;
          try
          {
            sDate = oValue1.Substring(4, 4);
          }
          catch
          {
            sDate = DateTime.Now.ToString("MMdd");
          }
          SqlParameterCollection oParameters;
          DbProvider.Excute(Common.ConnectionString(), "usp_분류_작업요약생성_Set", out oParameters, DbProvider.GetParameter("@분류명", (object) str1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) name, ParameterDirection.Input), DbProvider.GetParameter("@작업일자", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@배치명", (object) oValue3, ParameterDirection.Input), DbProvider.GetParameter("@배치구분", (object) oValue4, ParameterDirection.Input), DbProvider.GetParameter("@분류구분", (object) oValue5, ParameterDirection.Input), DbProvider.GetParameter("@출하구분", (object) oValue6, ParameterDirection.Input), DbProvider.GetParameter("@패턴구분", (object) oValue7, ParameterDirection.Input), DbProvider.GetParameter("@지시수", (object) oValue8, ParameterDirection.Input), DbProvider.GetParameter("@슈트수", (object) Common.Setting.CHUTES, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) empty14, ParameterDirection.InputOutput));
          if (oParameters != null)
          {
            if (oParameters.Count > 0)
            {
              empty14 = oParameters["@분류번호"].Value.ToString();
              if (!string.IsNullOrEmpty(empty14))
              {
                if (flag)
                {
                  flag = false;
                  DataTable oDataTable1 = new DataTable("usp_분류_배치작성_Get");
                  DataTable oDataTable2 = new DataTable("usp_분류_배치작성_Get");
                  DataTable oDataTable3 = new DataTable("usp_분류_배치작성_Get");
                  DbProvider.Select(Common.ConnectionString(), oDataTable1, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@구분", (object) "E", ParameterDirection.Input));
                  DbProvider.Select(Common.ConnectionString(), oDataTable2, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@구분", (object) "C", ParameterDirection.Input));
                  List<Chute> chuteList = new List<Chute>();
                  foreach (DataRow row2 in (InternalDataCollectionBase) oDataTable2.Rows)
                    chuteList.Add(new Chute(row2["슈트번호"].ToString(), string.Empty, string.Empty, "1", row2["지시수"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
                  DbProvider.Select(Common.ConnectionString(), oDataTable3, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@구분", (object) "S", ParameterDirection.Input));
                  DataTable dataTable2 = oDataTable3.Clone();
                  List<Sortq> sortqList = new List<Sortq>();
                  foreach (DataRow row3 in (InternalDataCollectionBase) oDataTable3.Rows)
                  {
                    if (Common.C2I(row3["자리수"]) > 40)
                      dataTable2.Rows.Add(row3.ItemArray);
                    sortqList.Add(new Sortq(row3["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row3["아이템구성"].ToString(), row3["상품명"].ToString(), string.Empty, string.Empty, row3["슈트번호"].ToString(), row3["지시수"].ToString(), string.Empty, string.Empty, row3["대표바코드"].ToString(), string.Empty, string.Empty, row3["대체바코드1"].ToString(), row3["대체바코드2"].ToString(), string.Empty));
                  }
                  if (dataTable2.Rows.Count > 0)
                  {
                    Common.ErrorMessageBox("상품코드 자리수가 40을 초과한 대상이 있습니다.\r\n\r\n배치 작성을 취소합니다.");
                    if (Common.QuestionMessageBox("대상을 확인 하시겠습니까?") == DialogResult.Yes)
                    {
                      int num = (int) new dlgPAS00061()
                      {
                        TITLE2 = ("자리수 40 초과 상품코드 확인 - " + oValue2),
                        자리수초과아이템 = dataTable2.Copy()
                      }.ShowDialog();
                      return;
                    }
                    break;
                  }
                  Execbat execbat = new Execbat(string.Empty, string.Empty, oDataTable1.Rows[0]["작업일자"].ToString(), empty14, str1, "0", "??????????", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                  byte[] stringToUtF8 = Command.GetStringToUTF8(str1);
                  if (Command.GetStringToUTF8(str1).Length > 20)
                  {
                    Common.ErrorMessageBox("분류명의 길이가 너무 길어 배치 작성을 취소 합니다.");
                    return;
                  }
                  if (Encoding.Default.GetString(stringToUtF8) != str1)
                  {
                    Common.ErrorMessageBox("분류명이 허용 자리수를 초과합니다.");
                    return;
                  }
                  MakeData.EXECBATManage(Common.Setting.LOCAL_FOLDER, DateTime.Now);
                  MakeData.MakeEXECBAT(Common.Setting.LOCAL_FOLDER, new Execbat[1]
                  {
                    execbat
                  });
                  MakeData.MakeCHUTE(Common.Setting.LOCAL_FOLDER, sDate, empty14, chuteList.ToArray(), false, Common.C2I((object) Common.Setting.CHUTES));
                  MakeData.MakeSORTQ(Common.Setting.LOCAL_FOLDER, sDate, empty14, sortqList.ToArray());
                  MakeData.MakeMEMBER(Common.Setting.LOCAL_FOLDER, sDate, empty14);
                  MakeData.MakeSIMPLE(Common.Setting.LOCAL_FOLDER, sDate, empty14);
                  MakeData.MakeSORTA(Common.Setting.LOCAL_FOLDER, sDate, empty14);
                  MakeData.MakeREBUILD(Common.Setting.LOCAL_FOLDER, sDate, empty14, 재구성구분.빈파일, (Rebuild[]) null);
                }
                else
                {
                  DataTable oDataTable = new DataTable("usp_분류_배치작성_Get");
                  DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@구분", (object) "S", ParameterDirection.Input));
                  DataTable dataTable3 = oDataTable.Clone();
                  List<Rebuild> rebuildList = new List<Rebuild>();
                  foreach (DataRow row4 in (InternalDataCollectionBase) oDataTable.Rows)
                  {
                    if (Common.C2I(row4["자리수"]) > 40)
                      dataTable3.Rows.Add(row4.ItemArray);
                    rebuildList.Add(new Rebuild(string.Empty, "I", row4["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row4["아이템구성"].ToString(), row4["상품명"].ToString(), string.Empty, string.Empty, row4["슈트번호"].ToString(), row4["지시수"].ToString(), string.Empty, string.Empty, row4["대표바코드"].ToString(), string.Empty, string.Empty, row4["대체바코드1"].ToString(), row4["대체바코드2"].ToString(), string.Empty, string.Empty, string.Empty));
                  }
                  if (dataTable3.Rows.Count > 0)
                  {
                    Common.ErrorMessageBox("상품코드 자리수가 40을 초과한 대상이 있습니다.");
                    if (Common.QuestionMessageBox("대상을 확인 하시겠습니까?") == DialogResult.Yes)
                    {
                      int num = (int) new dlgPAS00061()
                      {
                        TITLE2 = ("자리수 40 초과 상품코드 확인 - " + oValue2),
                        자리수초과아이템 = dataTable3.Copy()
                      }.ShowDialog();
                      break;
                    }
                    break;
                  }
                  MakeData.MakeREBUILD(Common.PATH_STARTUP + Common.PATH_TEMP, sDate, str2, 재구성구분.배치, rebuildList.ToArray());
                }
                ++iCount;
                Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Value = iCount)));
                Application.DoEvents();
              }
              else
                break;
            }
            else
              break;
          }
          else
            break;
        }
      }
      if (iCount > 0)
      {
        Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Value = this.rGrid2.Rows.Count)));
        int num = (int) frmMessageBox.Show("선택한 배치의 작성하였습니다.", this.Text, false, true);
        Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Value = 0)));
      }
      else
      {
        int num = (int) frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
        Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Value = 0)));
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역진행상태.Visible = false)));
      this.조회버튼_Click((object) null, EventArgs.Empty);
      Cursor.Current = Cursors.Default;
    }
  }

  private void 작성취소버튼_Click(object sender, EventArgs e)
  {
    int num1 = 0;
    try
    {
      if (Common.QuestionMessageBox("분류번호 단위로 배치 작성을 취소합니다.\r\n계속 진행 하시겠습니까?") != DialogResult.Yes)
        return;
      this.rGrid3.EndEdit();
      this.m_분류_작업요약Table.AcceptChanges();
      Cursor.Current = Cursors.WaitCursor;
      if (Common.Setting.LOCAL_FOLDER != string.Empty && !Directory.Exists(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA))
        Directory.CreateDirectory(Common.Setting.LOCAL_FOLDER + Common.PATH_DATA);
      if (!Directory.Exists(Common.PATH_STARTUP + Common.PATH_TEMP))
        Directory.CreateDirectory(Common.PATH_STARTUP + Common.PATH_TEMP);
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string str1 = string.Empty;
      string str2 = string.Empty;
      DataRow[] dataRowArray1 = this.m_분류_작업요약Table.Select($"선택='{bool.TrueString}' AND 배치상태 NOT IN ('생성', '수신')");
      if (dataRowArray1 != null && dataRowArray1.Length > 0)
      {
        foreach (DataRow dataRow in dataRowArray1)
          str2 = str2 + dataRow["배치번호"].ToString() + Environment.NewLine;
        Common.ErrorMessageBox($"{str2}{Environment.NewLine}나열된 배치는 이미 진행중이거나 완료된\r\n배치이므로 작성 취소를 할 수 없습니다.\r\n\r\n대상을 다시 선택하세요.");
      }
      else
      {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (DataGridViewRow row in (IEnumerable) this.rGrid3.Rows)
        {
          if (row.Cells["선택"].Value.ToString() == bool.TrueString && (row.Cells["배치상태"].Value.ToString() == "생성" || row.Cells["배치상태"].Value.ToString() == "수신") && !dictionary.ContainsKey(row.Cells["원배치번호"].Value.ToString()))
            dictionary.Add(row.Cells["원배치번호"].Value.ToString(), row.Cells["배치번호"].Value.ToString());
        }
        foreach (KeyValuePair<string, string> keyValuePair in dictionary)
        {
          DataRow[] dataRowArray2 = this.m_분류_작업요약Table.Select($"배치번호='{keyValuePair.Value}' AND 원배치번호='{keyValuePair.Key}'");
          if (dataRowArray2 != null && dataRowArray2.Length > 0)
          {
            using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
            {
              dbProvider2.Initialize("usp_분류_수신취소_Set", "@원배치번호");
              foreach (DataRow dataRow in dataRowArray2)
              {
                if (Common.C2I(dataRow["순번"]) != 1)
                {
                  empty1 = dataRow["분류번호"].ToString();
                  dataRow["배치번호"].ToString();
                  string str3 = dataRow["원배치번호"].ToString();
                  string str4 = dataRow["작업일자"].ToString();
                  try
                  {
                    str1 = str4.Substring(4, 4);
                  }
                  catch
                  {
                    str1 = DateTime.Now.ToString("MMdd");
                  }
                  dbProvider2.Update((object) str3);
                  if (File.Exists($"{Common.PATH_STARTUP}{Common.PATH_TEMP}\\{str3}_REBUILD.DAT"))
                    File.Delete($"{Common.PATH_STARTUP}{Common.PATH_TEMP}\\{str3}_REBUILD.DAT");
                  ++num1;
                }
              }
              foreach (DataRow dataRow in dataRowArray2)
              {
                if (Common.C2I(dataRow["순번"]) == 1)
                {
                  string sBatchNo = dataRow["분류번호"].ToString();
                  dataRow["배치번호"].ToString();
                  string str5 = dataRow["원배치번호"].ToString();
                  string sDate = dataRow["작업일자"].ToString();
                  string str6;
                  try
                  {
                    str6 = sDate.Substring(4, 4);
                  }
                  catch
                  {
                    str6 = DateTime.Now.ToString("MMdd");
                  }
                  dbProvider2.Update((object) str5);
                  if (Directory.Exists($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str6}\\{sBatchNo}"))
                    Directory.Delete($"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str6}\\{sBatchNo}", true);
                  if (Directory.Exists(Common.Setting.LOCAL_FOLDER + "\\DATA"))
                    MakeData.EXECBATDelete(Common.Setting.LOCAL_FOLDER, sDate, sBatchNo);
                  ++num1;
                }
              }
              dbProvider2.Commit();
            }
          }
        }
        if (num1 > 0)
        {
          int num2 = (int) frmMessageBox.Show("선택한 항목의 배치작성이 취소 되었습니다.", this.Text, false, true);
        }
        else
        {
          int num3 = (int) frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
        }
      }
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      Cursor.Current = Cursors.Default;
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private void rGrid3_MouseUp(object sender, MouseEventArgs e)
  {
    DataGridView.HitTestInfo hitTestInfo = this.rGrid3.HitTest(e.X, e.Y);
    if (hitTestInfo.RowIndex < 0)
      return;
    if (hitTestInfo.ColumnIndex < 0)
      return;
    try
    {
      this.분류명.Text = this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["분류명"].Value.ToString();
      this.comboBox1.Text = this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["출하구분"].Value.ToString();
      if (this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["배치상태"].Value.ToString() == "생성" || this.rGrid3.Rows[hitTestInfo.RowIndex].Cells["배치상태"].Value.ToString() == "수신")
        this.작성취소버튼.Enabled = true;
      else
        this.작성취소버튼.Enabled = false;
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
  }

  private void 슈트조정버튼_Click(object sender, EventArgs e)
  {
    if (this.rGrid2.SelectedRows == null || this.rGrid2.SelectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("조정할 배치를 선택하세요.");
    }
    else
    {
      string str = this.rGrid2.SelectedRows[0].Cells["원배치번호"].Value.ToString();
      int num = (int) new dlgPAS00002() { 원배치번호 = str }.ShowDialog();
    }
  }

  private void 배치명변경버튼_Click(object sender, EventArgs e)
  {
    DataGridViewSelectedRowCollection selectedRows = this.rGrid3.SelectedRows;
    if (selectedRows == null || selectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("변경할 배치를 선택해 주세요.");
    }
    else
    {
      string str1 = selectedRows[0].Cells["배치번호"].Value.ToString();
      string str2 = selectedRows[0].Cells["배치명"].Value.ToString();
      int num = (int) new dlgPAS00062()
      {
        배치번호 = str1,
        배치명 = str2
      }.ShowDialog();
      this.작업요약조회_Click((object) null, EventArgs.Empty);
    }
  }

  private void 출하위치변경버튼_Click(object sender, EventArgs e)
  {
    DataGridViewSelectedRowCollection selectedRows = this.rGrid3.SelectedRows;
    if (selectedRows == null || selectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("변경할 대상을 선택해 주세요.");
    }
    else
    {
      string str = selectedRows[0].Cells["분류번호"].Value.ToString();
      int num = (int) new dlgPAS00063()
      {
        분류번호 = str,
        출하위치 = this.comboBox1.Text
      }.ShowDialog();
      this.작업요약조회_Click((object) null, EventArgs.Empty);
    }
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
    DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
    DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
    this.panel1 = new Panel();
    this.panel2 = new Panel();
    this.rGrid1 = new RGrid();
    this.rPanel1 = new RPanel();
    this.checkBox1 = new CheckBox();
    this.조회버튼 = new RButton();
    this.수신버튼 = new RButton();
    this.splitter1 = new Splitter();
    this.panel3 = new Panel();
    this.rGrid2 = new RGrid();
    this.rPanel2 = new RPanel();
    this.슈트조정버튼 = new RButton();
    this.checkBox2 = new CheckBox();
    this.로컬새로고침버튼 = new RButton();
    this.수신취소버튼 = new RButton();
    this.rGrid3 = new RGrid();
    this.rPanel3 = new RPanel();
    this.배치명변경버튼 = new RButton();
    this.comboBox1 = new ComboBox();
    this.rLabel2 = new RLabel();
    this.분류명 = new RTextBox();
    this.rLabel1 = new RLabel();
    this.checkBox3 = new CheckBox();
    this.작성취소버튼 = new RButton();
    this.작업요약조회 = new RButton();
    this.배치작성버튼 = new RButton();
    this.pasPanel1 = new PasPanel();
    this.dateTimePicker1 = new DateTimePicker();
    this.닫기버튼 = new RButton();
    this.rLabel4 = new RLabel();
    this.dateTimePicker2 = new DateTimePicker();
    this.label1 = new Label();
    this.출하위치변경버튼 = new RButton();
    this.panel1.SuspendLayout();
    this.panel2.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.rPanel1.SuspendLayout();
    this.panel3.SuspendLayout();
    ((ISupportInitialize) this.rGrid2).BeginInit();
    this.rPanel2.SuspendLayout();
    ((ISupportInitialize) this.rGrid3).BeginInit();
    this.rPanel3.SuspendLayout();
    this.pasPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.panel2);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.splitter1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.panel3);
    this.panel1.Dock = DockStyle.Top;
    this.panel1.Location = new Point(0, 45);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(1000, 250);
    this.panel1.TabIndex = 0;
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel2.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel2.Dock = DockStyle.Fill;
    this.panel2.Location = new Point(0, 0);
    this.panel2.Name = "panel2";
    this.panel2.Size = new Size(547, 250);
    this.panel2.TabIndex = 0;
    this.rGrid1.AllowUserToAddRows = false;
    this.rGrid1.AllowUserToDeleteRows = false;
    this.rGrid1.AlternateColor = Color.Empty;
    this.rGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
    gridViewCellStyle2.ForeColor = SystemColors.ControlText;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid1.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid1.Location = new Point(6, 57);
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
    this.rGrid1.Size = new Size(535, 185);
    this.rGrid1.TabIndex = 1;
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.수신버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(6, 6);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(535, 45);
    this.rPanel1.TabIndex = 0;
    this.checkBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(6, 11);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(100, 23);
    this.checkBox1.TabIndex = 0;
    this.checkBox1.Text = "전체선택";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.checkBox1.Click += new EventHandler(this.checkBox1_Click);
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(346, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 1;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
    this.수신버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.수신버튼.ButtonState = RButtonState.None;
    this.수신버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.수신버튼.ForeColor = Color.DimGray;
    this.수신버튼.Image = (Image) pas.mgp.Properties.Resources._1395148855_recv;
    this.수신버튼.Location = new Point(437, 11);
    this.수신버튼.Name = "수신버튼";
    this.수신버튼.Size = new Size(90, 23);
    this.수신버튼.TabIndex = 2;
    this.수신버튼.Text = "수 신";
    this.수신버튼.UseVisualStyleBackColor = true;
    this.수신버튼.Click += new EventHandler(this.수신버튼_Click);
    this.splitter1.Dock = DockStyle.Right;
    this.splitter1.Location = new Point(547, 0);
    this.splitter1.Name = "splitter1";
    this.splitter1.Size = new Size(3, 250);
    this.splitter1.TabIndex = 3;
    this.splitter1.TabStop = false;
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rGrid2);
    this.panel3.Controls.Add((System.Windows.Forms.Control) this.rPanel2);
    this.panel3.Dock = DockStyle.Right;
    this.panel3.Location = new Point(550, 0);
    this.panel3.MinimumSize = new Size(450, 250);
    this.panel3.Name = "panel3";
    this.panel3.Size = new Size(450, 250);
    this.panel3.TabIndex = 2;
    this.rGrid2.AllowUserToAddRows = false;
    this.rGrid2.AllowUserToDeleteRows = false;
    this.rGrid2.AlternateColor = Color.Empty;
    this.rGrid2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid2.BackgroundColor = Color.White;
    gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle4.BackColor = SystemColors.Control;
    gridViewCellStyle4.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle4.ForeColor = SystemColors.WindowText;
    gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
    this.rGrid2.ColumnHeadersDefaultCellStyle = gridViewCellStyle4;
    this.rGrid2.DataSource2 = (object) null;
    gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle5.BackColor = SystemColors.Window;
    gridViewCellStyle5.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle5.ForeColor = SystemColors.ControlText;
    gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle5.WrapMode = DataGridViewTriState.False;
    this.rGrid2.DefaultCellStyle = gridViewCellStyle5;
    this.rGrid2.Location = new Point(6, 57);
    this.rGrid2.Name = "rGrid2";
    gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle6.BackColor = SystemColors.Control;
    gridViewCellStyle6.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle6.ForeColor = SystemColors.WindowText;
    gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle6.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
    this.rGrid2.RowHeadersDefaultCellStyle = gridViewCellStyle6;
    this.rGrid2.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid2.Size = new Size(438, 185);
    this.rGrid2.TabIndex = 2;
    this.rPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel2.BackColor = Color.Transparent;
    this.rPanel2.BorderColor = Color.MistyRose;
    this.rPanel2.Controls.Add((System.Windows.Forms.Control) this.슈트조정버튼);
    this.rPanel2.Controls.Add((System.Windows.Forms.Control) this.checkBox2);
    this.rPanel2.Controls.Add((System.Windows.Forms.Control) this.로컬새로고침버튼);
    this.rPanel2.Controls.Add((System.Windows.Forms.Control) this.수신취소버튼);
    this.rPanel2.EdgeRadius = 10;
    this.rPanel2.Location = new Point(6, 6);
    this.rPanel2.Name = "rPanel2";
    this.rPanel2.PanelColor = Color.Snow;
    this.rPanel2.Size = new Size(438, 45);
    this.rPanel2.TabIndex = 1;
    this.슈트조정버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.슈트조정버튼.ButtonState = RButtonState.None;
    this.슈트조정버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.슈트조정버튼.ForeColor = Color.DimGray;
    this.슈트조정버튼.Image = (Image) pas.mgp.Properties.Resources._1459937077_table_relationship;
    this.슈트조정버튼.Location = new Point(160 /*0xA0*/, 11);
    this.슈트조정버튼.Name = "슈트조정버튼";
    this.슈트조정버튼.Size = new Size(90, 23);
    this.슈트조정버튼.TabIndex = 3;
    this.슈트조정버튼.Text = "슈트조정";
    this.슈트조정버튼.UseVisualStyleBackColor = true;
    this.슈트조정버튼.Click += new EventHandler(this.슈트조정버튼_Click);
    this.checkBox2.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox2.ForeColor = Color.DimGray;
    this.checkBox2.Location = new Point(6, 11);
    this.checkBox2.Name = "checkBox2";
    this.checkBox2.Size = new Size(100, 23);
    this.checkBox2.TabIndex = 0;
    this.checkBox2.Text = "전체선택";
    this.checkBox2.UseVisualStyleBackColor = true;
    this.checkBox2.Click += new EventHandler(this.checkBox2_Click);
    this.로컬새로고침버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.로컬새로고침버튼.ButtonState = RButtonState.None;
    this.로컬새로고침버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.로컬새로고침버튼.ForeColor = Color.DimGray;
    this.로컬새로고침버튼.Image = (Image) pas.mgp.Properties.Resources._1395148967_refresh;
    this.로컬새로고침버튼.Location = new Point(251, 11);
    this.로컬새로고침버튼.Name = "로컬새로고침버튼";
    this.로컬새로고침버튼.Size = new Size(90, 23);
    this.로컬새로고침버튼.TabIndex = 1;
    this.로컬새로고침버튼.Text = "새로고침";
    this.로컬새로고침버튼.UseVisualStyleBackColor = true;
    this.로컬새로고침버튼.Click += new EventHandler(this.로컬새로고침버튼_Click);
    this.수신취소버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.수신취소버튼.ButtonState = RButtonState.None;
    this.수신취소버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.수신취소버튼.ForeColor = Color.DimGray;
    this.수신취소버튼.Image = (Image) pas.mgp.Properties.Resources._1395148855_recv_cancel;
    this.수신취소버튼.Location = new Point(342, 11);
    this.수신취소버튼.Name = "수신취소버튼";
    this.수신취소버튼.Size = new Size(90, 23);
    this.수신취소버튼.TabIndex = 2;
    this.수신취소버튼.Text = "수신취소";
    this.수신취소버튼.UseVisualStyleBackColor = true;
    this.수신취소버튼.Click += new EventHandler(this.수신취소버튼_Click);
    this.rGrid3.AllowUserToAddRows = false;
    this.rGrid3.AllowUserToDeleteRows = false;
    this.rGrid3.AlternateColor = Color.Empty;
    this.rGrid3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.rGrid3.BackgroundColor = Color.White;
    gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle7.BackColor = SystemColors.Control;
    gridViewCellStyle7.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle7.ForeColor = SystemColors.WindowText;
    gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
    this.rGrid3.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
    this.rGrid3.DataSource2 = (object) null;
    gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle8.BackColor = SystemColors.Window;
    gridViewCellStyle8.Font = new Font("굴림", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle8.ForeColor = SystemColors.ControlText;
    gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
    this.rGrid3.DefaultCellStyle = gridViewCellStyle8;
    this.rGrid3.Location = new Point(6, 346);
    this.rGrid3.Name = "rGrid3";
    gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
    gridViewCellStyle9.BackColor = SystemColors.Control;
    gridViewCellStyle9.Font = new Font("굴림", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 129);
    gridViewCellStyle9.ForeColor = SystemColors.WindowText;
    gridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle9.SelectionForeColor = Color.FromArgb(9, 32 /*0x20*/, 97);
    gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
    this.rGrid3.RowHeadersDefaultCellStyle = gridViewCellStyle9;
    this.rGrid3.RowHeaderStyle = RowHeaderStyle.None;
    this.rGrid3.Size = new Size(988, 252);
    this.rGrid3.TabIndex = 5;
    this.rGrid3.MouseUp += new MouseEventHandler(this.rGrid3_MouseUp);
    this.rPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel3.BackColor = Color.Transparent;
    this.rPanel3.BorderColor = Color.MistyRose;
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.출하위치변경버튼);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.배치명변경버튼);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.comboBox1);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.분류명);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.checkBox3);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.작성취소버튼);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.작업요약조회);
    this.rPanel3.Controls.Add((System.Windows.Forms.Control) this.배치작성버튼);
    this.rPanel3.EdgeRadius = 10;
    this.rPanel3.Location = new Point(6, 295);
    this.rPanel3.Name = "rPanel3";
    this.rPanel3.PanelColor = Color.Snow;
    this.rPanel3.Size = new Size(988, 45);
    this.rPanel3.TabIndex = 4;
    this.배치명변경버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.배치명변경버튼.ButtonState = RButtonState.None;
    this.배치명변경버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.배치명변경버튼.ForeColor = Color.DimGray;
    this.배치명변경버튼.Image = (Image) pas.mgp.Properties.Resources._1395148868_pencil_edit;
    this.배치명변경버튼.Location = new Point(698, 11);
    this.배치명변경버튼.Name = "배치명변경버튼";
    this.배치명변경버튼.Size = new Size(100, 23);
    this.배치명변경버튼.TabIndex = 7;
    this.배치명변경버튼.Text = "배치명 변경";
    this.배치명변경버튼.UseVisualStyleBackColor = true;
    this.배치명변경버튼.Click += new EventHandler(this.배치명변경버튼_Click);
    this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new Point(390, 12);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new Size(100, 20);
    this.comboBox1.TabIndex = 6;
    this.rLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rLabel2.Control = (System.Windows.Forms.Control) this.분류명;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(311, 11);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(80 /*0x50*/, 23);
    this.rLabel2.TabIndex = 5;
    this.rLabel2.Text = "출하구분";
    this.분류명.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.분류명.FocusedColor = SystemColors.Window;
    this.분류명.Location = new Point(205, 12);
    this.분류명.Name = "분류명";
    this.분류명.Size = new Size(100, 21);
    this.분류명.TabIndex = 0;
    this.분류명.TextType = RTextBoxType.Both;
    this.rLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rLabel1.Control = (System.Windows.Forms.Control) this.분류명;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(130, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(80 /*0x50*/, 23);
    this.rLabel1.TabIndex = 4;
    this.rLabel1.Text = "분류명";
    this.checkBox3.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.checkBox3.ForeColor = Color.DimGray;
    this.checkBox3.Location = new Point(6, 11);
    this.checkBox3.Name = "checkBox3";
    this.checkBox3.Size = new Size(100, 23);
    this.checkBox3.TabIndex = 3;
    this.checkBox3.Text = "전체선택";
    this.checkBox3.UseVisualStyleBackColor = true;
    this.checkBox3.Click += new EventHandler(this.checkBox3_Click);
    this.작성취소버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.작성취소버튼.ButtonState = RButtonState.None;
    this.작성취소버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.작성취소버튼.ForeColor = Color.DimGray;
    this.작성취소버튼.Image = (Image) pas.mgp.Properties.Resources._1456485840_invoice_cancel;
    this.작성취소버튼.Location = new Point(890, 11);
    this.작성취소버튼.Name = "작성취소버튼";
    this.작성취소버튼.Size = new Size(90, 23);
    this.작성취소버튼.TabIndex = 3;
    this.작성취소버튼.Text = "작성취소";
    this.작성취소버튼.UseVisualStyleBackColor = true;
    this.작성취소버튼.Click += new EventHandler(this.작성취소버튼_Click);
    this.작업요약조회.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.작업요약조회.ButtonState = RButtonState.None;
    this.작업요약조회.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.작업요약조회.ForeColor = Color.DimGray;
    this.작업요약조회.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.작업요약조회.Location = new Point(496, 11);
    this.작업요약조회.Name = "작업요약조회";
    this.작업요약조회.Size = new Size(90, 23);
    this.작업요약조회.TabIndex = 1;
    this.작업요약조회.Text = "조 회";
    this.작업요약조회.UseVisualStyleBackColor = true;
    this.작업요약조회.Click += new EventHandler(this.작업요약조회_Click);
    this.배치작성버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.배치작성버튼.ButtonState = RButtonState.None;
    this.배치작성버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.배치작성버튼.ForeColor = Color.DimGray;
    this.배치작성버튼.Image = (Image) pas.mgp.Properties.Resources._1456485840_invoice;
    this.배치작성버튼.Location = new Point(799, 11);
    this.배치작성버튼.Name = "배치작성버튼";
    this.배치작성버튼.Size = new Size(90, 23);
    this.배치작성버튼.TabIndex = 2;
    this.배치작성버튼.Text = "배치작성";
    this.배치작성버튼.UseVisualStyleBackColor = true;
    this.배치작성버튼.Click += new EventHandler(this.배치작성버튼_Click);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker1);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel4);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.dateTimePicker2);
    this.pasPanel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.pasPanel1.Dock = DockStyle.Top;
    this.pasPanel1.Location = new Point(0, 0);
    this.pasPanel1.Name = "pasPanel1";
    this.pasPanel1.PanelSeperator = true;
    this.pasPanel1.Size = new Size(1000, 45);
    this.pasPanel1.TabIndex = 1;
    this.dateTimePicker1.Format = DateTimePickerFormat.Short;
    this.dateTimePicker1.Location = new Point(88, 12);
    this.dateTimePicker1.Name = "dateTimePicker1";
    this.dateTimePicker1.Size = new Size(100, 21);
    this.dateTimePicker1.TabIndex = 6;
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(898, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 0;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.rLabel4.Control = (System.Windows.Forms.Control) this.분류명;
    this.rLabel4.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel4.ForeColor = Color.DimGray;
    this.rLabel4.IsBulletPoint = true;
    this.rLabel4.Location = new Point(12, 11);
    this.rLabel4.Name = "rLabel4";
    this.rLabel4.Size = new Size(80 /*0x50*/, 23);
    this.rLabel4.TabIndex = 5;
    this.rLabel4.Text = "조회기간";
    this.dateTimePicker2.Format = DateTimePickerFormat.Short;
    this.dateTimePicker2.Location = new Point(204, 12);
    this.dateTimePicker2.Name = "dateTimePicker2";
    this.dateTimePicker2.Size = new Size(100, 21);
    this.dateTimePicker2.TabIndex = 8;
    this.label1.AutoSize = true;
    this.label1.Location = new Point(189, 16 /*0x10*/);
    this.label1.Name = "label1";
    this.label1.Size = new Size(14, 12);
    this.label1.TabIndex = 7;
    this.label1.Text = "~";
    this.출하위치변경버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.출하위치변경버튼.ButtonState = RButtonState.None;
    this.출하위치변경버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.출하위치변경버튼.ForeColor = Color.DimGray;
    this.출하위치변경버튼.Image = (Image) pas.mgp.Properties.Resources._1459443534_sitemap;
    this.출하위치변경버튼.Location = new Point(587, 11);
    this.출하위치변경버튼.Name = "출하위치변경버튼";
    this.출하위치변경버튼.Size = new Size(110, 23);
    this.출하위치변경버튼.TabIndex = 8;
    this.출하위치변경버튼.Text = "출하위치 변경";
    this.출하위치변경버튼.UseVisualStyleBackColor = true;
    this.출하위치변경버튼.Click += new EventHandler(this.출하위치변경버튼_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(1000, 610);
    this.Controls.Add((System.Windows.Forms.Control) this.rGrid3);
    this.Controls.Add((System.Windows.Forms.Control) this.rPanel3);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    this.Controls.Add((System.Windows.Forms.Control) this.pasPanel1);
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmPAS00061);
    this.Text = "frmPAS00001";
    this.panel1.ResumeLayout(false);
    this.panel2.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.panel3.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid2).EndInit();
    this.rPanel2.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid3).EndInit();
    this.rPanel3.ResumeLayout(false);
    this.rPanel3.PerformLayout();
    this.pasPanel1.ResumeLayout(false);
    this.pasPanel1.PerformLayout();
    this.ResumeLayout(false);
  }
}
