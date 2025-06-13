using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PAS.PMP.Models;
using PAS.PMP.PasWCS;
using PAS.PMP.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRPAS00011 : Form
    {
        #region 폼개체 선언부

        private DataTable m_PAS_배치정보Table = new DataTable("usp_PAS_배치정보_Get");
        private DataTable m_연동_작업지시Table = new DataTable("usp_연동_작업지시_Get");
        private DataTable m_분류_작업요약Table = new DataTable("usp_분류_작업요약_Get");

        private BindingSource m_PAS_배치정보BS = new BindingSource();
        private BindingSource m_연동_작업지시BS = new BindingSource();
        private BindingSource m_분류_작업요약BS = new BindingSource();


        private string m조회시작일자
        {
            get { return (Convert.ToDateTime(this.시작일자.Value)).ToString("yyyyMMdd"); }
        }

        private string m조회종료일자
        {
            get { return (Convert.ToDateTime(this.종료일자.Value)).ToString("yyyyMMdd"); }
        }

        private string m분류명 { get => 분류명.Text; }

        #endregion

        #region 초기화

        public frmTRPAS00011()
        {
            InitializeComponent();
            var valueList = ValueListUtil.ValueItemList.ValueList_출하위치();
            var comboItems = valueList.ValueListItems
                .Cast<ValueListItem>()
                .Select(item => new KeyValuePair<string, string>(item.DataValue.ToString(), item.DisplayText))
                .ToList();

            // ultraCombo1 세팅
            com출하구분.DataSource = new BindingSource(comboItems, null);
            com출하구분.DisplayMember = "Value";
            com출하구분.ValueMember = "Key";
            com출하구분.Value = "3";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            시작일자.Value = DateTime.Now.AddDays(-7);
            종료일자.Value = DateTime.Now;
            SetDataTableBindingInit();
        }

        #endregion

        #region 사용자정의함수

        private void SetDataTableBindingInit()
        {
            try
            {
                #region uGrid1 BindingSource 초기화

                연동.조회미수신기간별(m_PAS_배치정보Table, m조회시작일자, m조회종료일자, false);

                m_PAS_배치정보BS.DataSource = m_PAS_배치정보Table;
                uGrid1.DataSource = m_PAS_배치정보BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, "센터코드", "장비구분", "배치구분코드", "분류구분", "분류구분코드", "출하구분코드", "출력여부코드");
                Common.SetGridEditColumn(this.uGrid1, "선택");

                #endregion

                #region uGrid2 BindingSource 초기화

                연동.조회수신기간별(m_연동_작업지시Table, m조회시작일자, m조회종료일자, false);

                m_연동_작업지시BS.DataSource = m_연동_작업지시Table;
                uGrid2.DataSource = m_연동_작업지시BS;

                Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, "브랜드명", "센터코드", "장비구분", "배치구분코드", "분류구분", "분류구분코드", "출하구분코드", "출력여부코드");
                Common.SetGridEditColumn(this.uGrid2, "선택");

                #endregion

                #region uGrid3 BindingSource 초기화

                분류.배치리스트조회(m_분류_작업요약Table, null, 0);

                m_분류_작업요약BS.DataSource = m_분류_작업요약Table;
                uGrid3.DataSource = m_분류_작업요약BS;

                Common.SetGridInit(this.uGrid3, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "순번", "관리번호", "장비구분", "배치구분코드", "출하구분코드", "분류구분", "분류구분코드",  "분류방법코드", "패턴구분코드", "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid3, "선택");

                #endregion

            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Name, ex);
            }
        }

        #endregion

        #region IToolBase 멤버

        #endregion

        #region Event

        private void 전체선택1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in this.uGrid1.Rows)
            {
                row.Cells["선택"].Value = this.전체선택1.Checked;
            }
            this.m_PAS_배치정보BS.EndEdit();
        }

        private void 전체선택2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in this.uGrid2.Rows)
            {
                row.Cells["선택"].Value = this.전체선택2.Checked;
            }
            this.m_연동_작업지시BS.EndEdit(); // 변경 내용 적용
        }

        private void 전체선택3_CheckedChanged(object sender, EventArgs e)
        {
            foreach (UltraGridRow row in this.uGrid3.Rows)
            {
                row.Cells["선택"].Value = this.전체선택3.Checked;
            }
            this.m_분류_작업요약BS.EndEdit(); // 변경 내용 적용
        }

        #endregion

        #region 버튼Event

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                연동.조회미수신기간별(m_PAS_배치정보Table, m조회시작일자, m조회종료일자, true);
                연동.조회수신기간별(m_연동_작업지시Table, m조회시작일자, m조회종료일자, true);
                분류.배치리스트조회(m_분류_작업요약Table, null, 1);
                var 삭제대상 = new List<DataRow>();
                foreach (DataRow row in this.m_분류_작업요약Table.Rows)
                {
                    string 상태 = row["분류상태"].ToString();
                    if ((상태 == "종료" || 상태 == "중단") && !삭제대상.Contains(row))
                        삭제대상.Add(row);
                }

                foreach (DataRow row in 삭제대상)
                    this.m_분류_작업요약Table.Rows.Remove(row);

                this.m_분류_작업요약Table.AcceptChanges();

                if (this.m_분류_작업요약Table.Rows.Count <= 0 || this.uGrid3.Selected.Rows == null || this.uGrid3.Selected.Rows.Count <= 0)
                    return;

                this.분류명.Text = this.uGrid3.Selected.Rows[0].Cells["분류명"].Value.ToString();

                string 배치상태 = this.uGrid3.Selected.Rows[0].Cells["배치상태"].Value.ToString();
                this.작성취소버튼.Enabled = (배치상태 == "생성" || 배치상태 == "수신");
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }

        private void 수신버튼_Click(object sender, EventArgs e)
        {
            if (m_PAS_배치정보Table == null) return;
            try
            {
                var datas = m_PAS_배치정보Table.AsEnumerable()
                .Where(row => row.Field<bool>("선택"))
                .Select(row => row.Field<string>("배치번호"))
                .Distinct().ToList();

                if (datas.Count == 0)
                {
                    MessageBox.Show("선택된 배치가 없습니다.", this.Text);
                    return;
                }

                연동.수신(datas);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
            finally
            {
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void 슈트조정버튼_Click(object sender, EventArgs e)
        {
            if (this.uGrid2.Selected.Rows == null || this.uGrid2.Selected.Rows.Count <= 0)
            {
                Common.ErrorMessage(this.Text, "조정할 배치를 선택하세요.");
            }
            else
            {
                string 원배치번호 = this.uGrid2.Selected.Rows[0].Cells["원배치번호"].Value.ToString();
                var dlg = new frmTRDLG00002() { 원배치번호 = 원배치번호 }.ShowDialog();
            }
        }

        private void 새로고침버튼_Click(object sender, EventArgs e)
        {
            try
            {
                연동.조회수신기간별(m_연동_작업지시Table, m조회시작일자, m조회종료일자, true);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }

        private void 수신취소버튼_Click(object sender, EventArgs e)
        {
            if (m_연동_작업지시Table == null) return;
            try
            {
                var datas = m_PAS_배치정보Table.AsEnumerable()
                .Where(row => row.Field<bool>("선택"))
                .Select(row => row.Field<string>("원배치번호"))
                .Distinct().ToList();

                if (datas.Count == 0)
                {
                    MessageBox.Show("선택된 배치가 없습니다.", this.Text);
                    return;
                }
                연동.수신취소(datas);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
            finally
            {
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void 작업조회버튼_Click(object sender, EventArgs e)
        {
            분류.배치리스트조회(m_분류_작업요약Table, null, 1);
        }

        private void 출하위치변경버튼_Click(object sender, EventArgs e)
        {
            var rows = this.uGrid3.Selected.Rows;
            if (rows == null || rows.Count <= 0)
            {
                Common.ErrorMessage(this.Text, "변경할 대상을 선택해 주세요.");
            }

            string 분류번호 = rows[0].Cells["분류번호"].Value?.ToString();

            var dlg = new frmTRDLG00063() { 분류번호 = 분류번호, 출하위치 = this.com출하구분.Text }.ShowDialog();

            this.작업조회버튼_Click((object)null, EventArgs.Empty);
        }

        private void 배치명변경버튼_Click(object sender, EventArgs e)
        {
            var rows = this.uGrid3.Selected.Rows;
            if (rows == null || rows.Count <= 0)
            {
                Common.ErrorMessage(this.Text, "변경할 배치를 선택해 주세요.");
            }

            string 배치번호 = rows[0].Cells["배치번호"].Value.ToString();
            string 배치명 = rows[0].Cells["배치명"].Value.ToString();

            var dlg = new frmTRDLG00062() { 배치번호 = 배치번호, 배치명 = 배치명 }.ShowDialog();

            this.작업조회버튼_Click((object)null, EventArgs.Empty);
        }

        private void 배치작성버튼_Click(object sender, EventArgs e)
        {
            string s분류명 = m분류명.Trim();
            string s분류번호 = string.Empty;
            string messageText = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(s분류명))
                {
                    messageText = @"분류명을 지정하지 않았습니다.
                                분류명을 지정하지 않으면 분류번호가 분류명이 됩니다.
                                분류명을 지정 하시겠습니까?";
                    if (MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        분류명.Focus();
                        return;
                    }
                }
                if (s분류명.Length > 8)
                    s분류명 = s분류명.Substring(0, 4);

                messageText = @"기 분류번호에 이어서 작업 하시겠습니까?";
                if (this.m_분류_작업요약Table.Rows.Count > 0 &&
                    MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.No)
                {
                    var rows = this.uGrid3.Selected.Rows;
                    if (rows == null || rows.Count <= 0)
                    {
                        Common.ErrorMessage(this.Text, "변경할 배치를 선택해 주세요.");
                    }

                    s분류번호 = rows[0].Cells["분류번호"].Value.ToString();
                    DataRow[] dataRowArray1 = this.m_분류_작업요약Table.Select($"분류번호='{s분류번호}'");
                    if (dataRowArray1 == null || dataRowArray1.Length <= 0)
                    {
                        messageText = $@"선택한 분류번호는 {s분류번호} 입니다.분류번호가 맞습니까?";
                        if (MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            frmMessageBox.Show("더이상 작업을 할 수 없는 분류번호 입니다.", this.Text, false, true);
                            return;
                        }
                        frmMessageBox.Show("다른 분류번호를 선택하세요.", this.Text, false, true);
                        return;
                    }

                    DataRow[] dataRowArray2 = this.m_분류_작업요약Table.Select($"분류번호='{s분류번호}' AND 분류상태 IN ('종료')");
                    if (dataRowArray2 == null || dataRowArray2.Length <= 0)
                    {
                        messageText = @"더이상 작업을 할 수 없는 분류번호 입니다.
                                    새 분류번호로 작업 하시겠습니까?";
                        if (MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                            return;
                        string messageText2 = @"분류명을 새로 지정하시겠습니까?";
                        if (MessageBox.Show(messageText2, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            this.분류명.Text = string.Empty;
                            this.분류명.SelectAll();
                            return;
                        }
                        s분류번호 = string.Empty;
                    }
                }

                int iCount = 0;
                DataTable dataTable1 = new DataTable();
                bool flag = s분류번호 == string.Empty;
                GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Visible = true)));
                GlobalClass.전역진행상태.Maximum = this.uGrid2.Rows.Count;

                foreach (DataGridViewRow row1 in (IEnumerable)this.uGrid2.Rows)
                {
                    if (row1.Cells["선택"].Value.ToString() == bool.TrueString)
                    {
                        if (flag && !string.IsNullOrEmpty(row1.Cells["추가배치"].Value.ToString()))
                        {
                            frmMessageBox.Show("추가 배치는 단독으로 작업할 수 없습니다.", this.Text, false, true);
                            return;
                        }
                        string s장비명 = GlobalClass.장비명;
                        string s작업일자 = row1.Cells["작업일자"].Value.ToString();
                        string s배치번호 = row1.Cells["배치번호"].Value.ToString();
                        string s원배치번호 = row1.Cells["원배치번호"].Value.ToString();
                        string s배치명 = row1.Cells["배치명"].Value.ToString();
                        string s배치구분코드 = row1.Cells["배치구분코드"].Value.ToString();
                        string s분류구분코드 = row1.Cells["분류구분코드"].Value.ToString();
                        string s배치구분 = row1.Cells["배치구분"].Value.ToString();
                        string s분류구분 = row1.Cells["분류구분"].Value.ToString();
                        string s출하구분 = this.com출하구분.SelectedIndex.ToString();
                        string s패턴구분 = (!(s배치구분 == "반품") ? 1 : 2).ToString();
                        int 지시수 = Convert.ToInt32(row1.Cells["지시수"].Value);
                        string s슈트수 = GlobalClass.CHUTES;
                        string s월일;
                        try
                        {
                            s월일 = s작업일자.Substring(4, 4);
                        }
                        catch
                        {
                            s월일 = DateTime.Now.ToString("MMdd");
                        }
                      
                        분류.작업요약생성(s분류명, s장비명, s작업일자, s배치번호, s원배치번호, s배치명, s배치구분, s분류구분, s출하구분, s패턴구분, 지시수, s슈트수, out s분류번호);

                        if (string.IsNullOrEmpty(s분류번호))
                            break;
                        if (flag)
                        {
                            flag = false;

                            DataTable dtE = new DataTable("usp_분류_배치작성_Get");
                            DataTable dtC = new DataTable("usp_분류_배치작성_Get");
                            DataTable dtS = new DataTable("usp_분류_배치작성_Get");

                            분류.배치작성(dtE, GlobalClass.장비명, s배치번호, s원배치번호, "E");
                            분류.배치작성(dtC, GlobalClass.장비명, s배치번호, s원배치번호, "C");
                            분류.배치작성(dtS, GlobalClass.장비명, s배치번호, s원배치번호, "S");

                            var chuteList = dtC.Rows.Cast<DataRow>()
                            .Select(row => new Chute(
                                row["슈트번호"].ToString(), string.Empty, string.Empty, "1",
                                row["지시수"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty))
                            .ToList();

                            DataTable dtExceedLength = dtS.Clone();

                            var sortqList = new List<Sortq>();
                            foreach (DataRow row in dtS.Rows)
                            {
                                if (Convert.ToInt32(row["자리수"]) > 40)
                                    dtExceedLength.Rows.Add(row.ItemArray);

                                sortqList.Add(new Sortq(
                                    row["아이템코드"].ToString(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                    row["아이템구성"].ToString(), row["상품명"].ToString(), string.Empty, string.Empty,
                                    row["슈트번호"].ToString(), row["지시수"].ToString(), string.Empty, string.Empty,
                                    row["대표바코드"].ToString(), string.Empty, string.Empty,
                                    row["대체바코드1"].ToString(), row["대체바코드2"].ToString(), string.Empty));
                            }

                            if (dtExceedLength.Rows.Count > 0)
                            {
                                Common.ErrorMessage(this.Text, "상품코드 자리수가 40을 초과한 대상이 있습니다.\r\n\r\n배치 작성을 취소합니다.");
                                if (MessageBox.Show("대상을 확인 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    new frmTRDLG00061()
                                    {
                                        TITLE2 = $"자리수 40 초과 상품코드 확인 - {s배치번호}",
                                        자리수초과아이템 = dtExceedLength.Copy()
                                    }.ShowDialog();
                                    return;
                                }
                                break;
                            }
                            

                            var execbat = new Execbat(string.Empty, string.Empty, dtE.Rows[0]["작업일자"].ToString(), s분류번호, s분류명, "0",
                                "??????????", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                            var utf8Bytes = Command.GetStringToUTF8(s분류명);
                            if (utf8Bytes.Length > 20)
                            {
                                Common.ErrorMessage(this.Text, "분류명의 길이가 너무 길어 배치 작성을 취소 합니다.");
                                return;
                            }

                            if (Encoding.Default.GetString(utf8Bytes) != s분류명)
                            {
                                Common.ErrorMessage(this.Text, "분류명이 허용 자리수를 초과합니다.");
                                return;
                            }

                            MakeData.EXECBATManage(GlobalClass.LOCAL_FOLDER, DateTime.Now);
                            MakeData.MakeEXECBAT(GlobalClass.LOCAL_FOLDER, new[] { execbat });
                            MakeData.MakeCHUTE(GlobalClass.LOCAL_FOLDER, s월일, s분류번호, chuteList.ToArray(), false, Convert.ToInt32(GlobalClass.CHUTES));
                            MakeData.MakeSORTQ(GlobalClass.LOCAL_FOLDER, s월일, s분류번호, sortqList.ToArray());
                            MakeData.MakeMEMBER(GlobalClass.LOCAL_FOLDER, s월일, s분류번호);
                            MakeData.MakeSIMPLE(GlobalClass.LOCAL_FOLDER, s월일, s분류번호);
                            MakeData.MakeSORTA(GlobalClass.LOCAL_FOLDER, s월일, s분류번호);
                            MakeData.MakeREBUILD(GlobalClass.LOCAL_FOLDER, s월일, s분류번호, 재구성구분.빈파일, null);
                        }
                        else
                        {
                            DataTable dtS = new DataTable("usp_분류_배치작성_Get");

                            분류.배치작성(dtS, GlobalClass.장비명, s배치번호, s원배치번호, "S");

                            DataTable dtExceedLength = dtS.Clone();

                            var 재구성리스트 = new List<재구성Model>();
                            foreach (DataRow row in dtS.Rows)
                            {
                                if (Convert.ToInt32(row["자리수"]) > 40)
                                    dtExceedLength.Rows.Add(row.ItemArray);

                                재구성리스트.Add(new 재구성Model(string.Empty, "I", row["아이템코드"].ToString(), string.Empty, string.Empty,
                                    string.Empty, string.Empty, string.Empty, row["아이템구성"].ToString(), row["상품명"].ToString(),
                                    string.Empty, string.Empty, row["슈트번호"].ToString(), row["지시수"].ToString(), string.Empty,
                                    string.Empty, row["대표바코드"].ToString(), string.Empty, string.Empty, row["대체바코드1"].ToString(),
                                    row["대체바코드2"].ToString(), string.Empty, string.Empty, string.Empty));
                            }

                            if (dtExceedLength.Rows.Count > 0)
                            {
                                Common.ErrorMessage(this.Text, "상품코드 자리수가 40을 초과한 대상이 있습니다.");
                                if (MessageBox.Show("대상을 확인 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    new frmTRDLG00061()
                                    {
                                        TITLE2 = $"자리수 40 초과 상품코드 확인 - {s배치번호}",
                                        자리수초과아이템 = dtExceedLength.Copy()
                                    }.ShowDialog();
                                    break;
                                }
                                break;
                            }
                            MakeData.MakeREBUILD(GlobalClass.PATH_STARTUP + "\\TEMP", s월일, s원배치번호, 재구성구분.배치, 재구성리스트.ToArray());
                        }
                        ++iCount;
                        GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Value = iCount)));
                        Application.DoEvents();

                    }
                }
                if (iCount > 0)
                {
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Value = this.uGrid2.Rows.Count)));
                    frmMessageBox.Show("선택한 배치의 작성하였습니다.", this.Text, false, true);
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Value = 0)));
                }
                else
                {
                    frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
                    GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Value = 0)));
                }
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                GlobalClass.전역상태바.Invoke((Delegate)(new MethodInvoker(() => GlobalClass.전역진행상태.Visible = false)));
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void 작성취소버튼_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("분류번호 단위로 배치 작성을 취소합니다.\r\n계속 진행 하시겠습니까?", this.Text, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                this.m_분류_작업요약BS.EndEdit();
                this.m_분류_작업요약Table.AcceptChanges();

                Cursor.Current = Cursors.WaitCursor;

                string[] requiredPaths = {Path.Combine(GlobalClass.LOCAL_FOLDER, "DATA"), Path.Combine(GlobalClass.PATH_STARTUP, "DATA")};

                foreach (var path in requiredPaths)
                {
                    if (!string.IsNullOrWhiteSpace(path) && !Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }

                DataRow[] rows = this.m_분류_작업요약Table.Select($"선택='{bool.TrueString}' AND 배치상태 NOT IN ('생성', '수신')");
                if (rows.Length > 0)
                {
                    string s배치리스트 = string.Join(Environment.NewLine, rows.Select(row => row["배치번호"].ToString()));
                    Common.ErrorMessage(this.Text, $"{s배치리스트}{Environment.NewLine}나열된 배치는 이미 진행중이거나 완료된\r\n배치이므로 작성 취소를 할 수 없습니다.\r\n\r\n대상을 다시 선택하세요.");
                    return;
                }

                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (UltraGridRow row in (IEnumerable)this.uGrid3.Rows)
                {
                    if (row.Cells["선택"].Value.ToString() == bool.TrueString && (row.Cells["배치상태"].Value.ToString() == "생성" || row.Cells["배치상태"].Value.ToString() == "수신") && !dictionary.ContainsKey(row.Cells["원배치번호"].Value.ToString()))
                        dictionary.Add(row.Cells["원배치번호"].Value.ToString(), row.Cells["배치번호"].Value.ToString());
                }

                int 취소건수 = 0;

                foreach (KeyValuePair<string, string> keyValuePair in dictionary)
                {
                    DataRow[] rows2 = this.m_분류_작업요약Table.Select($"배치번호='{keyValuePair.Value}' AND 원배치번호='{keyValuePair.Key}'");

                    if (rows2.Length == 0) continue;

                    취소건수 += 분류.수신취소(rows2);

                }

                if (취소건수 > 0)
                {
                    frmMessageBox.Show("선택한 항목의 배치작성이 취소 되었습니다.", this.Text, false, true);
                }
                else
                {
                    frmMessageBox.Show("선택한 대상이 없습니다.", this.Text, false, true);
                }

            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void uGrid3_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var element = uGrid3.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y));
                var cell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
                if (cell == null)
                    return;

                var row = cell.Row;
                string s분류명 = string.Empty;

                if (this.m_분류_작업요약Table.Rows.Count > 0)
                    s분류명 = row.Cells["분류명"].Value?.ToString() ?? string.Empty;
                    this.com출하구분.Text = row.Cells["출하구분"].Value?.ToString() ?? string.Empty;

                this.작성취소버튼.Enabled = (s분류명 == "생성" || this.com출하구분.Text == "수신");
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

    }
}
