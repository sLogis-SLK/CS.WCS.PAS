// Decompiled with JetBrains decompiler
// Type: pas.mgp.dlgPAS00001
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using NetHelper.Control;
using NetHelper.Forms;
// using pas.mgp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

// #nullable disable
// namespace pas.mgp;

public class dlgPAS00001 : RSkinForm
{
  private const byte STX = 2;
  private const byte ETX = 3;
  private DataTable m_분류_작업요약Table = new DataTable("usp_분류_작업요약_Get");
  private Socket m_oClient;
  private IContainer components;
  private Panel panel1;
  private RPanel rPanel1;
  private RButton 조회버튼;
  private RButton 배치종료버튼;
  private RGrid rGrid1;
  private RButton 배치개시버튼;
  private RLabel rLabel1;
  private RadioButton radioButton2;
  private RadioButton radioButton1;
  private RButton 닫기버튼;
  private RLabel rLabel2;
  private Label label1;
  private RButton 분류종료버튼;
  private PasProgressBar pasProgressBar1;
  private Label label3;
  private Label label2;
  private RButton rButton1;
  private RButton rButton2;
  private CheckBox checkBox1;

  public dlgPAS00001()
  {
    this.InitializeComponent();
    this.Text = Common.Title;
    this.Text2 = "배치 시작/완료";
    this.BackColor = Color.White;
    this.rLabel1.BackColor = this.rPanel1.PanelColor;
    this.rLabel2.BackColor = this.rPanel1.PanelColor;
    this.radioButton1.Checked = false;
    this.radioButton2.Checked = true;
    this.배치개시버튼.Enabled = true;
    this.배치종료버튼.Enabled = false;
    Common.RGrid_Initializing(this.rGrid1, true);
    this.분류_작업요약_조회(조회구분자.가조회);
    this.StartPosition = FormStartPosition.CenterParent;
  }

  private void 분류_작업요약_조회(조회구분자 e)
  {
    DbProvider.Select(Common.ConnectionString(), this.m_분류_작업요약Table, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "모두", ParameterDirection.Input), DbProvider.GetParameter("@조회구분자", (object) (int) e, ParameterDirection.Input));
    List<DataRow> dataRowList = new List<DataRow>();
    foreach (DataRow row in (InternalDataCollectionBase) this.m_분류_작업요약Table.Rows)
    {
      if (row["분류상태"].ToString() == "종료")
        dataRowList.Add(row);
      else if (!this.checkBox1.Checked && (row["배치상태"].ToString() == "이관" || row["배치상태"].ToString() == "완료" || row["배치상태"].ToString() == "실적작성" || row["배치상태"].ToString() == "실적반영" || row["배치상태"].ToString() == "배치반영"))
        dataRowList.Add(row);
    }
    foreach (DataRow row in dataRowList)
      this.m_분류_작업요약Table.Rows.Remove(row);
    this.m_분류_작업요약Table.AcceptChanges();
    this.rGrid1.DataSource2 = (object) this.m_분류_작업요약Table;
    foreach (DataGridViewColumn column in (BaseCollection) this.rGrid1.Columns)
    {
      switch (column.HeaderText)
      {
        case "실적수":
        case "분류구분":
        case "패턴구분":
        case "분류상태":
        case "완료일시":
        case "선택":
        case "순번":
        case "관리번호":
        case "장비명":
        case "배치구분코드":
        case "출하구분코드":
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
    this.pasProgressBar1.MinValue = 0L;
    this.pasProgressBar1.MaxValue = 0L;
    this.pasProgressBar1.Value = 0L;
    if (this.m_분류_작업요약Table.Rows.Count <= 0)
      return;
    switch (this.rGrid1.Rows[0].Cells["분류상태"].Value.ToString())
    {
      case "개시":
        switch (this.rGrid1.Rows[0].Cells["배치상태"].Value.ToString())
        {
          case "작업중":
            this.배치개시버튼.Enabled = false;
            this.배치종료버튼.Enabled = true;
            break;
          case "이관":
          case "완료":
          case "실적작성":
          case "실적반영":
          case "배치반영":
            this.배치개시버튼.Enabled = false;
            this.배치종료버튼.Enabled = false;
            break;
          default:
            this.배치개시버튼.Enabled = true;
            this.배치종료버튼.Enabled = false;
            break;
        }
        this.radioButton1.Enabled = false;
        this.radioButton2.Enabled = false;
        break;
      default:
        this.배치개시버튼.Enabled = true;
        this.배치종료버튼.Enabled = false;
        this.radioButton1.Enabled = true;
        this.radioButton2.Enabled = true;
        break;
    }
    this.분류_임계치_조회(this.rGrid1.Rows[0].Cells["분류번호"].Value.ToString());
  }

  private void 분류_임계치_조회(string s분류번호)
  {
    DataTable oDataTable = new DataTable("usp_분류_레코드수_Get");
    DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input));
    this.label1.Text = this.pasProgressBar1.PercentString;
    if (oDataTable != null && oDataTable.Rows.Count > 0)
    {
      string str1 = oDataTable.Rows[0]["작업일자"].ToString();
      string str2 = $"{str1}_{s분류번호}.DB";
      string empty = string.Empty;
      string str3;
      try
      {
        str3 = str1.Substring(4, 4);
      }
      catch
      {
        str3 = DateTime.Now.ToString("MMdd");
      }
      string str4 = $"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str3}\\{s분류번호}\\{str2}";
      int lValue1 = Common.C2I(oDataTable.Rows[0]["레코드총합"]);
      long lValue2 = 0;
      long lValue3 = 0;
      if (System.IO.File.Exists(str4))
      {
        lValue2 = new FileInfo(str4).Length;
        lValue3 = (long) System.IO.File.ReadAllLines(str4).Length;
      }
      int calcPercent1 = this.GetCalcPercent(lValue2, 80000000L);
      int calcPercent2 = this.GetCalcPercent((long) lValue1, 200000L);
      int calcPercent3 = this.GetCalcPercent(lValue3, 100000L);
      if (calcPercent1 > calcPercent2 || calcPercent1 > calcPercent3)
      {
        this.pasProgressBar1.MaxValue = 80000000L;
        this.pasProgressBar1.Value = lValue2;
      }
      else if (calcPercent2 > calcPercent1 || calcPercent2 > calcPercent3)
      {
        this.pasProgressBar1.MaxValue = 200000L;
        this.pasProgressBar1.Value = (long) lValue1;
      }
      else if (calcPercent3 > calcPercent1 || calcPercent3 > calcPercent2)
      {
        this.pasProgressBar1.MaxValue = 100000L;
        this.pasProgressBar1.Value = lValue3;
      }
      else
      {
        this.pasProgressBar1.MaxValue = 100000L;
        this.pasProgressBar1.Value = 0L;
      }
    }
    else
    {
      this.pasProgressBar1.MaxValue = 200000L;
      this.pasProgressBar1.Value = 0L;
    }
    this.label1.Text = this.pasProgressBar1.PercentString;
  }

  private int GetCalcPercent(long lValue, long lMaxValue)
  {
    int calcPercent = 0;
    try
    {
      calcPercent = (int) ((double) lValue / (double) lMaxValue * 100.0);
    }
    catch
    {
    }
    return calcPercent;
  }

  private string 분류_작업요약_작업중인분류번호()
  {
    string empty = string.Empty;
    DataRow[] dataRowArray = this.m_분류_작업요약Table.Select("분류상태='개시'");
    return dataRowArray == null || dataRowArray.Length <= 0 ? string.Empty : dataRowArray[0]["분류번호"].ToString();
  }

  private bool 분류_작업요약_작업중인배치존재여부(string s분류번호)
  {
    bool flag = false;
    DataRow[] dataRowArray = this.m_분류_작업요약Table.Select($"분류번호='{s분류번호}' AND 배치상태='작업중'");
    return dataRowArray == null || dataRowArray.Length <= 0 || flag;
  }

  private void 조회버튼_Click(object sender, EventArgs e)
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
      Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
      this.checkBox1.Checked = false;
      Cursor.Current = Cursors.Default;
    }
  }

  private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

  private void rGrid1_MouseUp(object sender, MouseEventArgs e)
  {
    try
    {
      DataGridView.HitTestInfo hitTestInfo = this.rGrid1.HitTest(e.X, e.Y);
      if (hitTestInfo.ColumnIndex < 0 || hitTestInfo.RowIndex < 0)
        return;
      switch (this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류상태"].Value.ToString())
      {
        case "개시":
          switch (this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["배치상태"].Value.ToString())
          {
            case "작업중":
              this.배치개시버튼.Enabled = false;
              this.배치종료버튼.Enabled = true;
              break;
            case "이관":
            case "완료":
            case "실적작성":
            case "실적반영":
            case "배치반영":
              this.배치개시버튼.Enabled = false;
              this.배치종료버튼.Enabled = false;
              break;
            default:
              this.배치개시버튼.Enabled = true;
              this.배치종료버튼.Enabled = false;
              break;
          }
          this.radioButton1.Enabled = false;
          this.radioButton2.Enabled = false;
          break;
        default:
          this.배치개시버튼.Enabled = true;
          this.배치종료버튼.Enabled = false;
          this.radioButton1.Enabled = true;
          this.radioButton2.Enabled = true;
          break;
      }
      this.분류_임계치_조회(this.rGrid1.Rows[hitTestInfo.RowIndex].Cells["분류번호"].Value.ToString());
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
  }

  private void 배치개시버튼_Click(object sender, EventArgs e)
  {
    try
    {
      string str1 = this.분류_작업요약_작업중인분류번호();
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("배치를 선택해 주세요.");
      }
      else
      {
        frmLoading.ShowLoading();
        string str2 = selectedRows[0].Cells["분류번호"].Value.ToString();
        string s배치명 = selectedRows[0].Cells["분류명"].Value.ToString();
        string empty1 = string.Empty;
        string oValue = selectedRows[0].Cells["배치번호"].Value.ToString();
        string s원배치번호 = selectedRows[0].Cells["원배치번호"].Value.ToString();
        string str3 = selectedRows[0].Cells["추가배치"].Value.ToString();
        if (oValue != s원배치번호)
        {
          if (!string.IsNullOrEmpty(str3))
          {
            DataRow[] dataRowArray = this.m_분류_작업요약Table.Select($"배치번호='{oValue}' AND 배치번호=원배치번호 AND 분류상태 IN ('개시', '중단')");
            if (dataRowArray != null)
            {
              if (dataRowArray.Length > 0)
                goto label_7;
            }
            Common.ErrorMessageBox("선택한 배치는 단독으로 개시할 수 없습니다.\r\n부모 배치를 먼저 개시하여 주세요.");
            return;
          }
        }
label_7:
        try
        {
          DataTable oDataTable = new DataTable("usp_관리_제약사항_배정할수없는슈트확인_Get");
          DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
          if (oDataTable.Rows.Count > 0)
          {
            Common.ErrorMessageBox("1번 슈트에 분류가 배정 되었습니다.\r\n\r\n선택한 배치를 개시할 수 없습니다.");
            return;
          }
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
          return;
        }
        try
        {
          using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
          {
            dbProvider2.Initialize("usp_관리_제약사항_바코드중복확인_Set", "@분류번호", "@장비명", "@원배치번호");
            dbProvider2.Update((object) str2, (object) Common.Setting.NAME, (object) s원배치번호);
            dbProvider2.Commit();
          }
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox($"선택한 [{s원배치번호}] 배치는 N현재 작업중인 대상과 중복되는 아이템이 있어 개시할 수 없습니다.\r\n\r\n{ex.Message}");
          return;
        }
        try
        {
          DataTable oDataTable = new DataTable("usp_관리_제약사항_배송사중복배정확인_Get");
          DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@분류번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
          if (oDataTable.Rows.Count > 0)
          {
            Common.ErrorMessageBox("동일 매장에 배송사가 중복 배정되었습니다.\r\n\r\n선택한 배치를 개시할 수 없습니다.");
            if (Common.QuestionMessageBox("대상을 확인 하시겠습니까?") != DialogResult.Yes)
              return;
            int num = (int) new dlgPAS00061()
            {
              TITLE2 = ("배송사 중복 배정 확인 - " + s원배치번호),
              자리수초과아이템 = oDataTable.Copy()
            }.ShowDialog();
            return;
          }
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
          return;
        }
        try
        {
          DataTable oDataTable = new DataTable("usp_관리_제약사항_매장중복배정확인_Get");
          DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@분류번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
          if (oDataTable.Rows.Count > 0)
          {
            Common.ErrorMessageBox("동일 슈트에 매장이 중복 배정되었습니다.\r\n\r\n선택한 배치를 개시할 수 없습니다.");
            if (Common.QuestionMessageBox("대상을 확인 하시겠습니까?") != DialogResult.Yes)
              return;
            int num = (int) new dlgPAS00061()
            {
              TITLE2 = ("매장 중복 배정 확인 - " + s원배치번호),
              자리수초과아이템 = oDataTable.Copy()
            }.ShowDialog();
            return;
          }
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
          return;
        }
        if (str2 == str1 || str1 == string.Empty)
        {
          if (selectedRows[0].Cells["순번"].Value.ToString() == "1")
          {
            string s작업일자 = selectedRows[0].Cells["작업일자"].Value.ToString();
            dlgPAS00001.분류방법 e2 = dlgPAS00001.분류방법.연속;
            if (!this.radioButton1.Checked)
              e2 = dlgPAS00001.분류방법.균등;
            dlgPAS00001.동작모드 e1 = dlgPAS00001.동작모드.개시;
            for (int i = 0; i < 5; ++i)
            {
              if (!this.Connection())
              {
                Common.ErrorMessageBox("PAS에 연결할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                break;
              }
              Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
              Application.DoEvents();
              switch (this.SendReceive(str2, s배치명, s작업일자, e1, e2))
              {
                case dlgPAS00001.상태처리.TRUE:
                  DbProvider.Excute(Common.ConnectionString(), "usp_분류_분류상태변경_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@분류상태", (object) "개시", ParameterDirection.Input));
                  DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_원배치용_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "작업중", ParameterDirection.Input));
                  Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"[{s원배치번호}] 배치를 개시 하였습니다.")));
                  return;
                case dlgPAS00001.상태처리.FALSE:
                  if (i + 1 == 5)
                  {
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = "배치 개시 실패!!")));
                    Common.ErrorMessageBox("배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                    try
                    {
                      using (DBProvider2 dbProvider2 = new DBProvider2(new SqlConnection(Common.ConnectionString()), IsolationLevel.ReadCommitted))
                      {
                        dbProvider2.Initialize("usp_관리_제약사항_바코드중복확인취소_Set", "@분류번호", "@장비명", "@원배치번호");
                        dbProvider2.Update((object) str2, (object) Common.Setting.NAME, (object) s원배치번호);
                        dbProvider2.Commit();
                        continue;
                      }
                    }
                    catch (Exception ex)
                    {
                      string message = ex.Message;
                      continue;
                    }
                  }
                  else
                    continue;
                default:
                  return;
              }
            }
          }
          else
          {
            DataRow[] dataRowArray = this.m_분류_작업요약Table.Select($"분류번호='{str2}' AND 순번=1");
            if (dataRowArray == null || dataRowArray.Length <= 0)
            {
              Common.ErrorMessageBox("배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
            }
            else
            {
              string str4 = dataRowArray[0]["작업일자"].ToString();
              string empty2 = string.Empty;
              string s월일;
              try
              {
                s월일 = str4.Substring(4, 4);
              }
              catch
              {
                s월일 = DateTime.Now.ToString("MMdd");
              }
              string path1 = $"{Common.PATH_STARTUP}{Common.PATH_TEMP}\\{s원배치번호}_REBUILD.DAT";
              string path2 = $"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{s월일}\\{str2}\\REBUILD.DAT";
              if (!System.IO.File.Exists(path1))
              {
                Common.ErrorMessageBox("선택한 배치가 준비되지 않습니다.\r\n배치 수신처리 및 작성이 되어있는지 확인하시고\r\n\r\n### 관리자에게 문의하세요. ###");
                Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
              }
              else
              {
                FileStream fileStream1 = (FileStream) null;
                FileStream fileStream2 = (FileStream) null;
                FileStream fileStream3;
                FileStream fileStream4;
                try
                {
                  fileStream3 = System.IO.File.Open(path2, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                  fileStream4 = System.IO.File.Open(path1, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                  byte[] buffer = new byte[fileStream4.Length];
                  fileStream4.Read(buffer, 0, buffer.Length);
                  fileStream3.Write(buffer, 0, buffer.Length);
                }
                catch
                {
                  Common.ErrorMessageBox("배치개시 준비가 되지 않았습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                  return;
                }
                try
                {
                  if (fileStream3 != null)
                  {
                    fileStream3.Close();
                    fileStream1 = (FileStream) null;
                  }
                  if (fileStream4 != null)
                  {
                    fileStream4.Close();
                    fileStream2 = (FileStream) null;
                  }
                }
                catch
                {
                }
                if (!System.IO.File.Exists(path2))
                {
                  Common.ErrorMessageBox("배치를 개시하는 중 문제가 발생하였습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                }
                else
                {
                  for (int i = 0; i < Common.REBUILD_DELAY_COUNT; ++i)
                  {
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
                    Application.DoEvents();
                    switch (this.재구성_배치개시(str2, s월일))
                    {
                      case dlgPAS00001.상태처리.TRUE:
                        DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_원배치용_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) str2, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "작업중", ParameterDirection.Input));
                        Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"[{s원배치번호}] 배치를 개시 하였습니다.")));
                        goto label_68;
                      case dlgPAS00001.상태처리.FALSE:
                        if (i + 1 == Common.REBUILD_DELAY_COUNT)
                        {
                          Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = "배치 개시 실패!!")));
                          Common.ErrorMessageBox("배치를 개시할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                          Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                        }
                        Thread.Sleep(10000);
                        break;
                    }
                  }
label_68:
                  System.IO.File.Delete(path1);
                }
              }
            }
          }
        }
        else
          Common.ErrorMessageBox("선택한 배치는 개시할 수 없습니다.");
      }
    }
    finally
    {
      frmLoading.CloseLoading();
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private void 배치종료버튼_Click(object sender, EventArgs e)
  {
    DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
    if (selectedRows != null)
    {
      if (selectedRows.Count > 0)
      {
        try
        {
          string str1 = selectedRows[0].Cells["분류번호"].Value.ToString();
          string s배치번호 = selectedRows[0].Cells["배치번호"].Value.ToString();
          string s원배치번호 = selectedRows[0].Cells["원배치번호"].Value.ToString();
          string empty1 = string.Empty;
          string empty2 = string.Empty;
          DataRow[] dataRowArray1 = this.m_분류_작업요약Table.Select($"배치번호='{s배치번호}'");
          if (dataRowArray1 != null && dataRowArray1.Length > 1)
          {
            Common.ErrorMessageBox("선택한 배치는 종속된 배치가 있어서 종료를 할 수 없습니다.\r\n분류종료를 하십시오.");
            return;
          }
          if (Common.QuestionMessageBox($"선택한 배치번호는 [{s원배치번호}] 입니다.\r\n종료 하시겠습니까?") != DialogResult.Yes || Common.QuestionMessageBox("★★★ 마지막 박스 발행은 하셨나요? ★★★\r\n\r\n배치를 종료하면 마지막 박스 발행 작업을 할 수 없습니다.\r\n\r\n그래도 종료 하시겠습니까?") != DialogResult.Yes)
            return;
          Common.OkMessageBox("PAS의 작동이 완료되었는지,\r\n\r\n컨베이어 위에 상품이 있는지,\r\n\r\n다시한번 확인해 주세요.");
          DataRow[] dataRowArray2 = this.m_분류_작업요약Table.Select($"분류번호='{str1}' AND 순번=1");
          if (dataRowArray2 != null)
          {
            if (dataRowArray2.Length > 0)
            {
              try
              {
                DataTable oDataTable = new DataTable("usp_관리_제약사항_재구성배치슈트중복확인_Get");
                DbProvider.Select(Common.ConnectionString(), oDataTable, DbProvider.GetParameter("@분류번호", (object) str1, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
                if (oDataTable.Rows.Count > 0)
                {
                  string str2 = string.Empty;
                  int num = 0;
                  foreach (DataRow row in (InternalDataCollectionBase) oDataTable.Rows)
                  {
                    string str3 = str2 + row["슈트번호"].ToString();
                    ++num;
                    str2 = num % 5 != 0 ? (num != oDataTable.Rows.Count ? str3 + ", " : str3 + string.Empty) : str3 + "\r\n";
                  }
                  if (Common.QuestionMessageBox(string.Format("슈트가 두개 이상의 배치에 배정되어 있습니다.\r\n\r\n지금 배치를 종료하게되면 해당 배치들은 모두 종료됩니다.\r\n\r\n그래도 종료 하시겠습니까?")) != DialogResult.Yes)
                    return;
                }
              }
              catch (Exception ex)
              {
                Common.ErrorMessageBox(ex.Message);
                return;
              }
              frmLoading.ShowLoading();
              string str4 = dataRowArray2[0]["작업일자"].ToString();
              string sDate;
              try
              {
                sDate = str4.Substring(4, 4);
              }
              catch
              {
                sDate = DateTime.Now.ToString("MMdd");
              }
              DataTable oDataTable1 = new DataTable("usp_분류_배치종료대상_Get");
              DbProvider.Select(Common.ConnectionString(), oDataTable1, DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) str1, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
              List<Rebuild> rebuildList = new List<Rebuild>();
              foreach (DataRow row in (InternalDataCollectionBase) oDataTable1.Rows)
                rebuildList.Add(new Rebuild(string.Empty, "E", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, row["슈트번호"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
              MakeData.MakeREBUILD(Common.PATH_STARTUP + Common.PATH_TEMP, sDate, s원배치번호, 재구성구분.종료, rebuildList.ToArray());
              string path1 = $"{Common.PATH_STARTUP}{Common.PATH_TEMP}\\{s원배치번호}_END_REBUILD.DAT";
              string path2 = $"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{sDate}\\{str1}\\REBUILD.DAT";
              FileStream fileStream1 = (FileStream) null;
              FileStream fileStream2 = (FileStream) null;
              FileStream fileStream3;
              FileStream fileStream4;
              try
              {
                fileStream3 = System.IO.File.Open(path2, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                fileStream4 = System.IO.File.Open(path1, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                byte[] buffer = new byte[fileStream4.Length];
                fileStream4.Read(buffer, 0, buffer.Length);
                fileStream3.Write(buffer, 0, buffer.Length);
              }
              catch
              {
                Common.ErrorMessageBox("배치종료 준비가 되지 않았습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                return;
              }
              try
              {
                if (fileStream3 != null)
                {
                  fileStream3.Close();
                  fileStream1 = (FileStream) null;
                }
                if (fileStream4 != null)
                {
                  fileStream4.Close();
                  fileStream2 = (FileStream) null;
                }
              }
              catch
              {
              }
              Thread.Sleep(Common.BATCH_END_DELAY_TIME);
              for (int i = 0; i < Common.REBUILD_DELAY_COUNT; ++i)
              {
                Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
                Application.DoEvents();
                switch (this.재구성_배치종료(str1, s배치번호, s원배치번호))
                {
                  case dlgPAS00001.상태처리.TRUE:
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"[{s원배치번호}] 배치를 종료 하였습니다.")));
                    if (!System.IO.File.Exists(path1))
                      return;
                    System.IO.File.Delete(path1);
                    return;
                  case dlgPAS00001.상태처리.FALSE:
                    if (i + 1 == Common.REBUILD_DELAY_COUNT)
                    {
                      Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = "배치 종료 실패!!")));
                      Common.ErrorMessageBox("배치를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                      Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                      continue;
                    }
                    continue;
                  default:
                    return;
                }
              }
              return;
            }
          }
          Common.ErrorMessageBox("배치를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
          return;
        }
        catch (Exception ex)
        {
          Common.ErrorMessageBox(ex.Message);
          return;
        }
        finally
        {
          frmLoading.CloseLoading();
          this.조회버튼_Click((object) null, EventArgs.Empty);
        }
      }
    }
    Common.ErrorMessageBox("배치를 선택해 주세요.");
  }

  private void 분류종료버튼_Click(object sender, EventArgs e)
  {
    try
    {
      DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
      if (selectedRows == null || selectedRows.Count <= 0)
      {
        Common.ErrorMessageBox("분류를 선택해 주세요.");
      }
      else
      {
        string s분류번호 = selectedRows[0].Cells["분류번호"].Value.ToString();
        switch (selectedRows[0].Cells["분류상태"].Value.ToString())
        {
          case "준비":
          case "종료":
            Common.ErrorMessageBox("선택한 분류는 종료할 수 없습니다.");
            break;
          default:
            if (Common.QuestionMessageBox("현재 분류를 모두 종료합니다.\r\n\r\n★★★ 정말로 종료 하시겠습니까? ★★★") != DialogResult.Yes)
              break;
            Common.OkMessageBox("PAS의 작동이 완료되었는지,\r\n\r\n컨베이어 위에 상품이 있는지,\r\n\r\n다시한번 확인해 주세요.");
            string s배치명 = selectedRows[0].Cells["분류명"].Value.ToString();
            string empty = string.Empty;
            DataRow[] dataRowArray = this.m_분류_작업요약Table.Select($"분류번호='{s분류번호}' AND 순번=1");
            if (dataRowArray == null || dataRowArray.Length <= 0)
            {
              Common.ErrorMessageBox("분류를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
              break;
            }
            string s작업일자 = dataRowArray[0]["작업일자"].ToString();
            string oValue1 = selectedRows[0].Cells["배치번호"].Value.ToString();
            string oValue2 = selectedRows[0].Cells["원배치번호"].Value.ToString();
            dlgPAS00001.분류방법 e2 = dlgPAS00001.분류방법.연속;
            if (!this.radioButton1.Checked)
              e2 = dlgPAS00001.분류방법.균등;
            dlgPAS00001.동작모드 e1 = dlgPAS00001.동작모드.종료;
            for (int i = 0; i < 5; ++i)
            {
              if (!this.Connection())
              {
                Common.ErrorMessageBox("PAS에 연결할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                break;
              }
              Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"{i + 1}번째 시도중입니다.")));
              Application.DoEvents();
              switch (this.SendReceive(s분류번호, s배치명, s작업일자, e1, e2))
              {
                case dlgPAS00001.상태처리.TRUE:
                  DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_원배치용_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "완료", ParameterDirection.Input));
                  DbProvider.Excute(Common.ConnectionString(), "usp_분류_분류상태변경_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@분류상태", (object) "종료", ParameterDirection.Input));
                  Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = $"[{s분류번호}] 분류를 종료 하였습니다.")));
                  return;
                case dlgPAS00001.상태처리.FALSE:
                  if (i + 1 == 5)
                  {
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = "분류 종료 실패!!")));
                    Common.ErrorMessageBox("분류를 종료할 수 없습니다.\r\n\r\n### 관리자에게 문의하세요. ###");
                    Common.전역상태바.Invoke((Delegate) (new MethodInvoker(() => Common.전역상태메시지.Text = string.Empty)));
                    continue;
                  }
                  continue;
                default:
                  return;
              }
            }
            break;
        }
      }
    }
    finally
    {
      this.조회버튼_Click((object) null, EventArgs.Empty);
    }
  }

  private bool Disconnection()
  {
    try
    {
      Thread.Sleep(1000);
      if (this.m_oClient != null)
      {
        this.m_oClient.Close();
        this.m_oClient = (Socket) null;
      }
      return true;
    }
    catch (SocketException ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    return false;
  }

  private bool Connection()
  {
    try
    {
      if (!this.Disconnection())
        return false;
      this.m_oClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IAsyncResult asyncResult = this.m_oClient.BeginConnect((EndPoint) new IPEndPoint(IPAddress.Parse(Common.Setting.SEIGYO_IP), Common.C2I((object) Common.Setting.SEIGYO_PORT)), (AsyncCallback) null, (object) null);
      if (!asyncResult.AsyncWaitHandle.WaitOne(60000, false))
        return false;
      this.m_oClient.EndConnect(asyncResult);
      return true;
    }
    catch (SocketException ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    return false;
  }

  private dlgPAS00001.상태처리 SendReceive(
    string s배치번호,
    string s배치명,
    string s작업일자,
    dlgPAS00001.동작모드 e1,
    dlgPAS00001.분류방법 e2)
  {
    string empty = string.Empty;
    byte[] bytes = Encoding.Default.GetBytes(Convert.ToChar((byte) 2).ToString() + "B" + Convert.ToChar((int) e1).ToString() + Command.GetEmptyString(s배치번호, 8) + Command.GetEmptyString(s배치명, 20) + Command.GetEmptyString(s작업일자, 8) + Convert.ToChar((int) e2).ToString() + Convert.ToChar((byte) 3).ToString());
    byte[] numArray1 = new byte[4096 /*0x1000*/];
    try
    {
      this.m_oClient.Send(bytes);
      IAsyncResult asyncResult = this.m_oClient.BeginReceive(numArray1, 0, numArray1.Length, SocketFlags.None, (AsyncCallback) null, (object) null);
      if (asyncResult.AsyncWaitHandle.WaitOne(60000, false))
      {
        int count = this.m_oClient.EndReceive(asyncResult);
        if (count > 0)
        {
          byte[] numArray2 = new byte[count];
          Buffer.BlockCopy((Array) numArray1, 0, (Array) numArray2, 0, count);
          if (numArray2[0] == (byte) 2)
          {
            if ((int) numArray2[1] == (int) Convert.ToByte('B'))
            {
              if (numArray2[count - 1] == (byte) 3)
              {
                if ((dlgPAS00001.동작모드) numArray2[2] == e1)
                {
                  if (e1 == dlgPAS00001.동작모드.개시)
                  {
                    switch (numArray2[3])
                    {
                      case 48 /*0x30*/:
                      case 50:
                        return dlgPAS00001.상태처리.TRUE;
                      case 49:
                        Common.ErrorMessageBox("이미 개시중인 배치 입니다.");
                        return dlgPAS00001.상태처리.ERROR;
                      default:
                        Common.Log((object) e1.ToString(), (object) "[SEND]", (object) Common.H2S(bytes), (object) DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        Common.Log((object) e1.ToString(), (object) "[RECV]", (object) Common.H2S(numArray2), (object) DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        break;
                    }
                  }
                  else
                  {
                    switch (numArray2[3])
                    {
                      case 48 /*0x30*/:
                      case 51:
                      case 52:
                        return dlgPAS00001.상태처리.TRUE;
                      case 49:
                        Common.ErrorMessageBox("아직 배치가 완료되지 않았습니다.\r\n\r\n컨베이어에 상품이 있는지 확인하세요.");
                        return dlgPAS00001.상태처리.ERROR;
                      default:
                        Common.Log((object) e1.ToString(), (object) "[SEND]", (object) Common.H2S(bytes), (object) DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        Common.Log((object) e1.ToString(), (object) "[RECV]", (object) Common.H2S(numArray2), (object) DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                        break;
                    }
                  }
                }
              }
            }
          }
        }
      }
    }
    catch (SocketException ex)
    {
      Common.ErrorMessageBox(ex.Message);
    }
    finally
    {
      this.Disconnection();
    }
    return dlgPAS00001.상태처리.FALSE;
  }

  private dlgPAS00001.상태처리 재구성_배치개시(string s분류번호, string s월일)
  {
    try
    {
      if (MakeData.REBUILDComplete(Common.Setting.LOCAL_FOLDER, s월일, s분류번호))
        return dlgPAS00001.상태처리.TRUE;
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
      return dlgPAS00001.상태처리.ERROR;
    }
    finally
    {
      Thread.Sleep(10000);
    }
    return dlgPAS00001.상태처리.FALSE;
  }

  private dlgPAS00001.상태처리 재구성_배치종료(string s분류번호, string s배치번호, string s원배치번호)
  {
    try
    {
      object obj = DbProvider.Scalar(Common.ConnectionString(), "usp_분류_배치종료확인_Get", DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input));
      if (obj == null || obj.ToString() == string.Empty || !(obj.ToString() == "성공"))
        return dlgPAS00001.상태처리.FALSE;
      DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_원배치용_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) s분류번호, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) s배치번호, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) s원배치번호, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "종료", ParameterDirection.Input));
      return dlgPAS00001.상태처리.TRUE;
    }
    catch (Exception ex)
    {
      Common.ErrorMessageBox(ex.Message);
      return dlgPAS00001.상태처리.ERROR;
    }
    finally
    {
      Thread.Sleep(10000);
    }
  }

  private void rButton1_Click(object sender, EventArgs e)
  {
    DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
    if (selectedRows == null || selectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("배치를 선택해 주세요.");
    }
    else
    {
      string str = selectedRows[0].Cells["분류번호"].Value.ToString();
      selectedRows[0].Cells["분류명"].Value.ToString();
      string empty1 = string.Empty;
      string oValue1 = selectedRows[0].Cells["배치번호"].Value.ToString();
      string oValue2 = selectedRows[0].Cells["원배치번호"].Value.ToString();
      string empty2 = string.Empty;
      string s월일;
      try
      {
        s월일 = empty1.Substring(4, 4);
      }
      catch
      {
        s월일 = DateTime.Now.ToString("MMdd");
      }
      if (this.재구성_배치개시(str, s월일) != dlgPAS00001.상태처리.TRUE)
        return;
      DbProvider.Excute(Common.ConnectionString(), "usp_분류_배치상태변경_원배치용_Set", DbProvider.GetParameter("@장비명", (object) Common.Setting.NAME, ParameterDirection.Input), DbProvider.GetParameter("@분류번호", (object) str, ParameterDirection.Input), DbProvider.GetParameter("@배치번호", (object) oValue1, ParameterDirection.Input), DbProvider.GetParameter("@원배치번호", (object) oValue2, ParameterDirection.Input), DbProvider.GetParameter("@배치상태", (object) "작업중", ParameterDirection.Input));
      Common.OkMessageBox($"[{oValue1}] 배치를 개시 하였습니다.");
    }
  }

  private void rButton2_Click(object sender, EventArgs e)
  {
    DataGridViewSelectedRowCollection selectedRows = this.rGrid1.SelectedRows;
    if (selectedRows == null || selectedRows.Count <= 0)
    {
      Common.ErrorMessageBox("배치를 선택해 주세요.");
    }
    else
    {
      string s분류번호 = selectedRows[0].Cells["분류번호"].Value.ToString();
      selectedRows[0].Cells["분류명"].Value.ToString();
      string empty1 = string.Empty;
      string s배치번호 = selectedRows[0].Cells["배치번호"].Value.ToString();
      string s원배치번호 = selectedRows[0].Cells["원배치번호"].Value.ToString();
      string empty2 = string.Empty;
      string str;
      try
      {
        str = empty1.Substring(4, 4);
      }
      catch
      {
        str = DateTime.Now.ToString("MMdd");
      }
      string path = $"{Common.PATH_STARTUP}{Common.PATH_TEMP}\\{s원배치번호}_END_REBUILD.DAT";
        //    $"{Common.Setting.LOCAL_FOLDER}\\DATA\\DATE{str}\\{s분류번호}\\REBUILD.DAT";
      if (this.재구성_배치종료(s분류번호, s배치번호, s원배치번호) != dlgPAS00001.상태처리.TRUE)
        return;
      Common.OkMessageBox($"[{s원배치번호}] 배치를 종료 하였습니다.");
      if (!System.IO.File.Exists(path))
        return;
      System.IO.File.Delete(path);
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
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (dlgPAS00001));
    this.panel1 = new Panel();
    this.rGrid1 = new RGrid();
    this.rPanel1 = new RPanel();
    this.checkBox1 = new CheckBox();
    this.label3 = new Label();
    this.label2 = new Label();
    this.pasProgressBar1 = new PasProgressBar();
    this.분류종료버튼 = new RButton();
    this.label1 = new Label();
    this.rLabel2 = new RLabel();
    this.조회버튼 = new RButton();
    this.닫기버튼 = new RButton();
    this.radioButton2 = new RadioButton();
    this.radioButton1 = new RadioButton();
    this.rLabel1 = new RLabel();
    this.배치개시버튼 = new RButton();
    this.배치종료버튼 = new RButton();
    this.rButton1 = new RButton();
    this.rButton2 = new RButton();
    this.panel1.SuspendLayout();
    ((ISupportInitialize) this.rGrid1).BeginInit();
    this.rPanel1.SuspendLayout();
    this.SuspendLayout();
    this.panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rGrid1);
    this.panel1.Controls.Add((System.Windows.Forms.Control) this.rPanel1);
    this.panel1.Location = new Point(12, 46);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(726, 482);
    this.panel1.TabIndex = 0;
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
    gridViewCellStyle2.ForeColor = Color.WhiteSmoke;
    gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
    gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
    gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
    this.rGrid1.DefaultCellStyle = gridViewCellStyle2;
    this.rGrid1.Location = new Point(10, 89);
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
    this.rGrid1.Size = new Size(708, 387);
    this.rGrid1.TabIndex = 2;
    this.rGrid1.MouseUp += new MouseEventHandler(this.rGrid1_MouseUp);
    this.rPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.rPanel1.BackColor = Color.Transparent;
    this.rPanel1.BorderColor = Color.MistyRose;
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.checkBox1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label3);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.pasProgressBar1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.분류종료버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.label1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.조회버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.닫기버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.radioButton2);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.radioButton1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.rLabel1);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.배치개시버튼);
    this.rPanel1.Controls.Add((System.Windows.Forms.Control) this.배치종료버튼);
    this.rPanel1.EdgeRadius = 10;
    this.rPanel1.Location = new Point(10, 10);
    this.rPanel1.Name = "rPanel1";
    this.rPanel1.PanelColor = Color.Snow;
    this.rPanel1.Size = new Size(708, 73);
    this.rPanel1.TabIndex = 1;
    this.checkBox1.AutoSize = true;
    this.checkBox1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.checkBox1.ForeColor = Color.DimGray;
    this.checkBox1.Location = new Point(230, 15);
    this.checkBox1.Name = "checkBox1";
    this.checkBox1.Size = new Size(101, 15);
    this.checkBox1.TabIndex = 18;
    this.checkBox1.Text = "배치완료 대상";
    this.checkBox1.UseVisualStyleBackColor = true;
    this.label3.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label3.ForeColor = Color.DimGray;
    this.label3.Location = new Point(503, 56);
    this.label3.Name = "label3";
    this.label3.Size = new Size(50, 17);
    this.label3.TabIndex = 17;
    this.label3.Text = "혼잡";
    this.label3.TextAlign = ContentAlignment.TopRight;
    this.label2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label2.ForeColor = Color.DimGray;
    this.label2.Location = new Point(102, 56);
    this.label2.Name = "label2";
    this.label2.Size = new Size(50, 17);
    this.label2.TabIndex = 16 /*0x10*/;
    this.label2.Text = "쾌적";
    this.pasProgressBar1.BackColor = Color.White;
    this.pasProgressBar1.Location = new Point(102, 40);
    this.pasProgressBar1.MaxValue = 100L;
    this.pasProgressBar1.MinValue = 0L;
    this.pasProgressBar1.Name = "pasProgressBar1";
    this.pasProgressBar1.Size = new Size(451, 13);
    this.pasProgressBar1.TabIndex = 15;
    this.pasProgressBar1.Text = "pasProgressBar1";
    this.pasProgressBar1.Value = 0L;
    this.분류종료버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.분류종료버튼.ButtonState = RButtonState.None;
    this.분류종료버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.분류종료버튼.ForeColor = Color.DimGray;
    this.분류종료버튼.Image = (Image) pas.mgp.Properties.Resources._1460118545_button_stop_basic_red;
    this.분류종료버튼.Location = new Point(610, 40);
    this.분류종료버튼.Name = "분류종료버튼";
    this.분류종료버튼.Size = new Size(90, 23);
    this.분류종료버튼.TabIndex = 14;
    this.분류종료버튼.Text = "분류종료";
    this.분류종료버튼.UseVisualStyleBackColor = true;
    this.분류종료버튼.Click += new EventHandler(this.분류종료버튼_Click);
    this.label1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.label1.ForeColor = Color.DimGray;
    this.label1.Location = new Point(559, 40);
    this.label1.Name = "label1";
    this.label1.Size = new Size(50, 23);
    this.label1.TabIndex = 13;
    this.label1.Text = "0%";
    this.label1.TextAlign = ContentAlignment.MiddleLeft;
    this.rLabel2.Control = (System.Windows.Forms.Control) null;
    this.rLabel2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel2.ForeColor = Color.DimGray;
    this.rLabel2.IsBulletPoint = true;
    this.rLabel2.Location = new Point(6, 40);
    this.rLabel2.Name = "rLabel2";
    this.rLabel2.Size = new Size(90, 23);
    this.rLabel2.TabIndex = 11;
    this.rLabel2.Text = "분류 임계치";
    this.조회버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.조회버튼.ButtonState = RButtonState.None;
    this.조회버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.조회버튼.ForeColor = Color.DimGray;
    this.조회버튼.Image = (Image) pas.mgp.Properties.Resources._1395148872_search_lense;
    this.조회버튼.Location = new Point(337, 11);
    this.조회버튼.Name = "조회버튼";
    this.조회버튼.Size = new Size(90, 23);
    this.조회버튼.TabIndex = 1;
    this.조회버튼.Text = "조 회";
    this.조회버튼.UseVisualStyleBackColor = true;
    this.조회버튼.Click += new EventHandler(this.조회버튼_Click);
    this.닫기버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.닫기버튼.ButtonState = RButtonState.None;
    this.닫기버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.닫기버튼.ForeColor = Color.DimGray;
    this.닫기버튼.Image = (Image) pas.mgp.Properties.Resources._1395148906_delete;
    this.닫기버튼.Location = new Point(610, 11);
    this.닫기버튼.Name = "닫기버튼";
    this.닫기버튼.Size = new Size(90, 23);
    this.닫기버튼.TabIndex = 10;
    this.닫기버튼.Text = "닫 기";
    this.닫기버튼.UseVisualStyleBackColor = true;
    this.닫기버튼.Click += new EventHandler(this.닫기버튼_Click);
    this.radioButton2.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.radioButton2.ForeColor = Color.DimGray;
    this.radioButton2.Location = new Point(158, 10);
    this.radioButton2.Name = "radioButton2";
    this.radioButton2.Size = new Size(55, 24);
    this.radioButton2.TabIndex = 9;
    this.radioButton2.TabStop = true;
    this.radioButton2.Text = "균등";
    this.radioButton2.UseVisualStyleBackColor = true;
    this.radioButton1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.radioButton1.ForeColor = Color.DimGray;
    this.radioButton1.Location = new Point(102, 10);
    this.radioButton1.Name = "radioButton1";
    this.radioButton1.Size = new Size(55, 24);
    this.radioButton1.TabIndex = 8;
    this.radioButton1.TabStop = true;
    this.radioButton1.Text = "연속";
    this.radioButton1.UseVisualStyleBackColor = true;
    this.rLabel1.Control = (System.Windows.Forms.Control) null;
    this.rLabel1.Font = new Font("굴림", 8.25f, FontStyle.Bold);
    this.rLabel1.ForeColor = Color.DimGray;
    this.rLabel1.IsBulletPoint = true;
    this.rLabel1.Location = new Point(6, 11);
    this.rLabel1.Name = "rLabel1";
    this.rLabel1.Size = new Size(90, 23);
    this.rLabel1.TabIndex = 7;
    this.rLabel1.Text = "분류방법";
    this.배치개시버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.배치개시버튼.ButtonState = RButtonState.None;
    this.배치개시버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.배치개시버튼.ForeColor = Color.DimGray;
    this.배치개시버튼.Image = (Image) pas.mgp.Properties.Resources._1460118536_button_play_basic_blue;
    this.배치개시버튼.Location = new Point(428, 11);
    this.배치개시버튼.Name = "배치개시버튼";
    this.배치개시버튼.Size = new Size(90, 23);
    this.배치개시버튼.TabIndex = 3;
    this.배치개시버튼.Text = "배치개시";
    this.배치개시버튼.UseVisualStyleBackColor = true;
    this.배치개시버튼.Click += new EventHandler(this.배치개시버튼_Click);
    this.배치종료버튼.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.배치종료버튼.ButtonState = RButtonState.None;
    this.배치종료버튼.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.배치종료버튼.ForeColor = Color.DimGray;
    this.배치종료버튼.Image = (Image) pas.mgp.Properties.Resources._1460118534_button_stop_basic_blue;
    this.배치종료버튼.Location = new Point(519, 11);
    this.배치종료버튼.Name = "배치종료버튼";
    this.배치종료버튼.Size = new Size(90, 23);
    this.배치종료버튼.TabIndex = 2;
    this.배치종료버튼.Text = "배치종료";
    this.배치종료버튼.UseVisualStyleBackColor = true;
    this.배치종료버튼.Click += new EventHandler(this.배치종료버튼_Click);
    this.rButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rButton1.ButtonState = RButtonState.None;
    this.rButton1.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.rButton1.ForeColor = Color.DimGray;
    this.rButton1.Image = (Image) pas.mgp.Properties.Resources._1460118536_button_play_basic_blue;
    this.rButton1.Location = new Point(450, 12);
    this.rButton1.Name = "rButton1";
    this.rButton1.Size = new Size(90, 23);
    this.rButton1.TabIndex = 19;
    this.rButton1.Text = "배치개시";
    this.rButton1.UseVisualStyleBackColor = true;
    this.rButton1.Visible = false;
    this.rButton1.Click += new EventHandler(this.rButton1_Click);
    this.rButton2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
    this.rButton2.ButtonState = RButtonState.None;
    this.rButton2.Font = new Font("굴림", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 129);
    this.rButton2.ForeColor = Color.DimGray;
    this.rButton2.Image = (Image) pas.mgp.Properties.Resources._1460118534_button_stop_basic_blue;
    this.rButton2.Location = new Point(541, 12);
    this.rButton2.Name = "rButton2";
    this.rButton2.Size = new Size(90, 23);
    this.rButton2.TabIndex = 18;
    this.rButton2.Text = "배치종료";
    this.rButton2.UseVisualStyleBackColor = true;
    this.rButton2.Visible = false;
    this.rButton2.Click += new EventHandler(this.rButton2_Click);
    this.AutoScaleDimensions = new SizeF(7f, 12f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(750, 540);
    this.Controls.Add((System.Windows.Forms.Control) this.rButton1);
    this.Controls.Add((System.Windows.Forms.Control) this.rButton2);
    this.Controls.Add((System.Windows.Forms.Control) this.panel1);
    //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
    this.IsDialog = true;
    this.Name = nameof (dlgPAS00001);
    this.Text = nameof (dlgPAS00001);
    this.panel1.ResumeLayout(false);
    ((ISupportInitialize) this.rGrid1).EndInit();
    this.rPanel1.ResumeLayout(false);
    this.rPanel1.PerformLayout();
    this.ResumeLayout(false);
  }

  private enum 동작모드 : uint
  {
    개시 = 49, // 0x00000031
    종료 = 50, // 0x00000032
    중단 = 51, // 0x00000033
  }

  private enum 분류방법 : uint
  {
    연속 = 48, // 0x00000030
    균등 = 49, // 0x00000031
  }

  private enum 응답상태 : uint
  {
    정상 = 48, // 0x00000030
    분류중 = 49, // 0x00000031
    개시완료 = 50, // 0x00000032
    종료완료 = 51, // 0x00000033
    전체완료 = 52, // 0x00000034
    대상외 = 53, // 0x00000035
    실패 = 57, // 0x00000039
  }

  private enum 상태처리 : uint
  {
    TRUE,
    FALSE,
    ERROR,
  }
}
