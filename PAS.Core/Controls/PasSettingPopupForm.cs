using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace PAS.Core.Controls
{
    public partial class PasSettingPopupForm : Form
    {
        #region 폼개체 선언부
        private string mCaption = string.Empty;

        private DataTable m거래명세서Table = new DataTable();
        private BindingSource m거래명세서BS = new BindingSource();

        private DataTable m바코드Table = new DataTable();
        private BindingSource m바코드BS = new BindingSource();

        private DataTable m숫자표시기Table = new DataTable();
        private BindingSource m숫자표시기BS = new BindingSource();

        protected string 출력메시지
        {
            set
            {
                라벨_출력메시지.Text = value;
                //toolTip1.SetToolTip(라벨_출력메시지, value);
            }
        }

        enum enum입력
        {
            추가,
            수정
        }
        private enum입력 m입력 = enum입력.추가;

        private enum입력 입력여부
        {
            get
            {
                return m입력;
            }
            set
            {
                m입력 = value;
                if (m입력 == enum입력.추가)
                {
                    if (string.IsNullOrEmpty(mCaption)) mCaption = this.Text;
                    this.Text = mCaption + " - 추가";
                }
                else if(m입력 == enum입력.수정)
                {
                    if (string.IsNullOrEmpty(mCaption)) mCaption = this.Text;
                    this.Text = mCaption + " - 수정";
                }
            }
        }

        public DataRow 기초DataRow { get; internal set; }

        #endregion

        #region 초기화 및 override 함수

        public PasSettingPopupForm()
        {
            InitializeComponent();
        }

        public PasSettingPopupForm(string caption)
        {
            InitializeComponent();
            mCaption = caption;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

            //컨트롤 기본세팅
            combo슈트앞.Items.Clear();
            combo슈트뒤.Items.Clear();
            combo바코드프린터.Items.Clear();
            combo거래명세서프린터.Items.Clear();

            //슈트범위 - 1~201까지있음.
            int length = 200;
            for (int i = 0; i < length; i++)
            {
                string 숫자 = i.ToString("D3");
                combo슈트앞.Items.Add(숫자);
                combo슈트뒤.Items.Add(숫자);
            }

            //프린트 세팅
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                combo바코드프린터.Items.Add(installedPrinter);
                combo거래명세서프린터.Items.Add(installedPrinter);
            }

            //최초 데이터 세팅
            SetInitializeDatas();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.F5)
            {
            }
            else if (e.KeyCode == Keys.F6)
            {
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (저장버튼.Enabled && 저장버튼.Visible) 저장버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (닫기버튼.Enabled && 닫기버튼.Visible) 닫기버튼_Click(null, null);
            }
        }


        #endregion

        #region 사용자정의함수

        private void SetInitializeDatas()
        {
            try
            {
                if(기초DataRow == null)
                {
                    출력메시지 = "PAS 기기 데이터가 존재하지 않습니다. 다시확인하시기 바랍니다.";
                    저장버튼.Enabled = false;
                    return;
                }

                if (기초DataRow["순서"] == null || 기초DataRow["순서"].ToString() == string.Empty)
                {
                    //신규일경우
                    NAME.ReadOnly = false;
                    m입력 = enum입력.추가;
                }
                else 
                {
                    //수정일경우
                    NAME.ReadOnly = true;
                    m입력 = enum입력.수정;
                }

                //컨트롤에 데이터 넣기
                NAME.Value = 기초DataRow["NAME"];
                SEIGYO_IP.Value = 기초DataRow["SEIGYO_IP"];
                SEIGYO_PORT.Value = 기초DataRow["SEIGYO_PORT"];
                CHUTES.Value = 기초DataRow["CHUTES"];
                CHUTES_ERROR.Value = 기초DataRow["CHUTES_ERROR"];
                CHUTES_OVERFLOW.Value = 기초DataRow["CHUTES_OVERFLOW"];
                LOCAL_FOLDER.Value = 기초DataRow["LOCAL_FOLDER"];
                SEIGYO_FOLDER.Value = 기초DataRow["SEIGYO_FOLDER"];
                SEIGYO_ID.Value = 기초DataRow["SEIGYO_ID"];
                SEIGYO_PASSWORD.Value = 기초DataRow["SEIGYO_PASSWORD"];
                PAS_DURATION.Value = 기초DataRow["PAS_DURATION"];
                INDICATOR_DURATION.Value = 기초DataRow["INDICATOR_DURATION"];
                INDICATOR_IP.Value = 기초DataRow["INDICATOR_IP"];
                INDICATOR_PORT.Value = 기초DataRow["INDICATOR_PORT"];


                //바코드프린터 테이블 생성
                m바코드Table = new DataTable();
                m바코드Table.Columns.Add("선택", typeof(bool));
                m바코드Table.Columns.Add("프린터명", typeof(string));
                m바코드Table.Columns.Add("슈트앞", typeof(string));
                m바코드Table.Columns.Add("슈트뒤", typeof(string));

                /* 데이터 넣기 */
                //BARCODE_PRINTER_LIST
                string BARCODE_PRINTER_LIST = 기초DataRow["BARCODE_PRINTER_LIST"].ToString();
                List<string> 바코드프린터list = BARCODE_PRINTER_LIST.Split('|').ToList();
                foreach (string item in 바코드프린터list)
                {
                    string 프린터 = string.Empty;
                    string 슈트앞 = string.Empty;
                    string 슈트뒤 = string.Empty;
                    
                    try
                    {
                        List<string> dataList = item.Split(',').ToList();

                        if(dataList.Count >=3)
                        {
                            프린터 = dataList[0].Trim();
                            슈트앞 = dataList[1].Trim();
                            슈트뒤 = dataList[2].Trim();
                        }
                    }
                    catch
                    { 
                        //문제생기면 빈값으로 처리....
                    }
                    if (string.IsNullOrEmpty(프린터)) continue;

                    DataRow newRow = m바코드Table.NewRow();
                    newRow["선택"] = false;
                    newRow["프린터명"] = 프린터;
                    newRow["슈트앞"] = 슈트앞;
                    newRow["슈트뒤"] = 슈트뒤;
                    m바코드Table.Rows.Add(newRow);
                }
                m바코드BS.DataSource = m바코드Table;
                uGrid1바코드프린트.DataSource = m바코드BS;
                
                Common.SetGridInit(uGrid1바코드프린트, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(uGrid1바코드프린트, null);
                Common.SetGridEditColumn(uGrid1바코드프린트, "선택");

                //거래명세서 프린터
                m거래명세서Table = new DataTable();
                m거래명세서Table.Columns.Add("선택", typeof(bool));
                m거래명세서Table.Columns.Add("프린터명", typeof(string));

                /* 데이터 넣기 */
                //PRINTER_LIST
                string PRINTER_LIST = 기초DataRow["PRINTER_LIST"].ToString();
                List<string> 거래명세서프린터list = PRINTER_LIST.Split('|').ToList();
                foreach (string item in 거래명세서프린터list)
                {
                    DataRow newRow = m거래명세서Table.NewRow();
                    newRow["선택"] = false;
                    newRow["프린터명"] = item.Trim();
                    m거래명세서Table.Rows.Add(newRow);
                }
                m거래명세서BS.DataSource = m거래명세서Table;
                uGrid2거래명세서프린트.DataSource = m거래명세서BS;

                Common.SetGridInit(uGrid2거래명세서프린트, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(uGrid2거래명세서프린트, null);
                Common.SetGridEditColumn(uGrid2거래명세서프린트, "선택");

                //숫자표시기 
                m숫자표시기Table = new DataTable();
                m숫자표시기Table.Columns.Add("1", typeof(bool));
                m숫자표시기Table.Columns.Add("2", typeof(bool));
                m숫자표시기Table.Columns.Add("3", typeof(bool));
                m숫자표시기Table.Columns.Add("4", typeof(bool));
                m숫자표시기Table.Columns.Add("5", typeof(bool));
                m숫자표시기Table.Columns.Add("6", typeof(bool));
                m숫자표시기Table.Columns.Add("7", typeof(bool));
                m숫자표시기Table.Columns.Add("8", typeof(bool));

                /* 데이터 넣기 */
                //INDICATOR_STRUCTURE
                string INDICATOR_STRUCTURE = 기초DataRow["INDICATOR_STRUCTURE"].ToString();
                for (int i = 0; i < INDICATOR_STRUCTURE.Length; i += 8)
                {
                    string chunk = INDICATOR_STRUCTURE.Substring(i, 8); // 8자리 추출
                    DataRow row = m숫자표시기Table.NewRow();

                    for (int j = 0; j < 8; j++)
                    {
                        row[(j + 1).ToString()] = chunk[j] == '1'; // '1'이면 true
                    }

                    m숫자표시기Table.Rows.Add(row);
                }
                m숫자표시기BS.DataSource = m숫자표시기Table;
                uGrid3숫자표시기.DataSource = m숫자표시기BS;

                Common.SetGridInit(uGrid3숫자표시기, false, false, true, true, false, false);
                Common.SetGridHiddenColumn(uGrid3숫자표시기, null);
                Common.SetGridEditColumn(uGrid3숫자표시기, "1", "2", "3", "4", "5", "6", "7", "8");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private DataRow GetDatas()
        {
            try
            {
                if (기초DataRow == null)
                {
                    throw new Exception("데이터가 비정상적입니다. 확인하여 주시기 바랍니다.");
                }

                기초DataRow["NAME"] = NAME.Value;
                기초DataRow["SEIGYO_IP"] = SEIGYO_IP.Value;
                기초DataRow["SEIGYO_PORT"] = SEIGYO_PORT.Value;
                기초DataRow["CHUTES"] = CHUTES.Value;
                기초DataRow["CHUTES_ERROR"] = CHUTES_ERROR.Value;
                기초DataRow["CHUTES_OVERFLOW"] = CHUTES_OVERFLOW.Value;
                기초DataRow["LOCAL_FOLDER"] = LOCAL_FOLDER.Value;
                기초DataRow["SEIGYO_FOLDER"] = SEIGYO_FOLDER.Value;
                기초DataRow["SEIGYO_ID"] = SEIGYO_ID.Value;
                기초DataRow["SEIGYO_PASSWORD"] = SEIGYO_PASSWORD.Value;
                기초DataRow["PAS_DURATION"] = PAS_DURATION.Value;
                기초DataRow["INDICATOR_DURATION"] = INDICATOR_DURATION.Value;
                기초DataRow["INDICATOR_IP"] = INDICATOR_IP.Value;
                기초DataRow["INDICATOR_PORT"] = INDICATOR_PORT.Value;

                string INDICATOR_STRUCTURE = string.Empty;
                기초DataRow["INDICATOR_STRUCTURE"] = INDICATOR_STRUCTURE;
                foreach (DataRow row in m숫자표시기Table.Rows)
                {
                    bool 숫자1 = Convert.ToBoolean(row["1"]);
                    bool 숫자2 = Convert.ToBoolean(row["2"]);
                    bool 숫자3 = Convert.ToBoolean(row["3"]);
                    bool 숫자4 = Convert.ToBoolean(row["4"]);
                    bool 숫자5 = Convert.ToBoolean(row["5"]);
                    bool 숫자6 = Convert.ToBoolean(row["6"]);
                    bool 숫자7 = Convert.ToBoolean(row["7"]);
                    bool 숫자8 = Convert.ToBoolean(row["8"]);

                    INDICATOR_STRUCTURE += (숫자1 ? "1" : "0") + (숫자2 ? "1" : "0") + (숫자3 ? "1" : "0") + (숫자4 ? "1" : "0") +
                        (숫자5 ? "1" : "0") + (숫자6 ? "1" : "0") + (숫자7 ? "1" : "0") + (숫자8 ? "1" : "0");
                }
                    
                string BARCODE_PRINTER_LIST = string.Empty;
                foreach (DataRow row in m바코드Table.Rows)
                {
                    string 프린터 = row["프린터명"]?.ToString();
                    string 슈트앞 = row["슈트앞"]?.ToString();
                    string 슈트뒤 = row["슈트뒤"]?.ToString();
                    BARCODE_PRINTER_LIST += 프린터 + "," + 슈트앞 + "," + 슈트뒤 + "|";
                }
                기초DataRow["BARCODE_PRINTER_LIST"] = BARCODE_PRINTER_LIST;
                
                string PRINTER_LIST = string.Empty;
                foreach (DataRow row in m거래명세서Table.Rows)
                {
                    string 프린터 = row["프린터명"]?.ToString();
                    PRINTER_LIST += 프린터 + "|";
                }
                기초DataRow["PRINTER_LIST"] = PRINTER_LIST;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, this.Text);
                throw ex;
            }
            return 기초DataRow;
        }
        
        #endregion

        #region 버튼 및 기타 Event

        private void uGrid1바코드프린트_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                // 현재 Active 된 row를 반환
                DataRowView oRow = (DataRowView)uGrid1바코드프린트.ActiveRow?.ListObject;
                if (oRow == null) return;

                string 프린터명 = oRow["프린터명"].ToString();
                string 슈트앞 = oRow["슈트앞"].ToString();
                string 슈트뒤 = oRow["슈트뒤"].ToString();

                combo바코드프린터.Value = 프린터명;
                combo슈트앞.Value = 슈트앞;
                combo슈트뒤.Value = 슈트뒤;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void 바코드프린터추가버튼_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newRow = m바코드Table.NewRow();
                newRow["선택"] = false;
                newRow["프린터명"] = combo바코드프린터.Value;
                newRow["슈트앞"] = combo슈트앞.Value;
                newRow["슈트뒤"] = combo슈트뒤.Value;
                m바코드Table.Rows.Add(newRow);

                //추가이후 포커스이동해야함. 미구현
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void 바코드프린터수정버튼_Click(object sender, EventArgs e)
        {
            DataRowView oRow = (DataRowView)uGrid1바코드프린트.ActiveRow?.ListObject;
            if (oRow == null) return;

            oRow["프린터명"] = combo바코드프린터.Value;
            oRow["슈트앞"] = combo슈트앞.Value;
            oRow["슈트뒤"] = combo슈트뒤.Value;
        }

        private void 바코드프린터삭제버튼_Click(object sender, EventArgs e)
        {
            string msgText = "선택된 항목을 삭제 하시겠습니까?";
            if (MessageBox.Show(msgText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                DataRow[] rows = m바코드Table.Select("선택 = True");

                foreach (DataRow row in rows)
                {
                    m바코드Table.Rows.Remove(row); // 또는 row.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void uGrid2거래명세서프린트_AfterRowActivate(object sender, EventArgs e)
        {
            try
            {
                // 현재 Active 된 row를 반환
                DataRowView oRow = (DataRowView)uGrid2거래명세서프린트.ActiveRow?.ListObject;
                if (oRow == null) return;

                string 프린터명 = oRow["프린터명"].ToString();
                combo거래명세서프린터.Value = 프린터명;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void 거래명세서프린터추가버튼_Click(object sender, EventArgs e)
        {
            DataRow newRow = m거래명세서Table.NewRow();
            newRow["선택"] = false;
            newRow["프린터명"] = combo거래명세서프린터.Value;
            m거래명세서Table.Rows.Add(newRow);
            //추가이후 포커스이동해야함. 미구현
        }

        private void 거래명세서프린터수정버튼_Click(object sender, EventArgs e)
        {
            //Visible 처리 - 구현필요없음.
        }

        private void 거래명세서프린터삭제버튼_Click(object sender, EventArgs e)
        {
            string msgText = "선택된 항목을 삭제 하시겠습니까?";
            if (MessageBox.Show(msgText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                DataRow[] rows = m거래명세서Table.Select("선택 = True");

                foreach (DataRow row in rows)
                {
                    m거래명세서Table.Rows.Remove(row); // 또는 row.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void 저장버튼_Click(object sender, EventArgs e)
        {

            ////데이터저장
            //m환경설정BS.EndEdit();
            //DataTable changedTable = m환경설정Table.GetChanges();
            //if (changedTable == null || changedTable.Rows.Count == 0)
            //{
            //    MessageBox.Show("추가/변경된 데이터가 없습니다.", this.Text);
            //    return;
            //}

            ////환경설정 갱신
            //try
            //{
            //    공통.DB접속정보저장(GlobalCore.PasDBConnectionString, PAS_DB_IP.Text, PAS_DB_SERVICE.Text, PAS_DB_ID.Text, PAS_DB_PASSWORD.Text,
            //                                                          HOST_DB_IP.Text, HOST_DB_SERVICE.Text, HOST_DB_ID.Text, HOST_DB_PASSWORD.Text);

            //    //공통.출하라인접속정보저장(GlobalCore.PasDBConnectionString, changedTable);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, this.Text);
            //    return;
            //}

            ////닫기
            //DialogResult = DialogResult.OK;
            //this.Close();



            ////데이터저장
            //m환경설정BS.EndEdit();
            //DataTable changedTable = m환경설정Table.GetChanges();
            //if (changedTable == null || changedTable.Rows.Count == 0)
            //{
            //    MessageBox.Show("추가/변경된 데이터가 없습니다.", this.Text);
            //    return;
            //}

            //환경설정 갱신
            try
            {
                //공통.DB접속정보저장(GlobalCore.PasDBConnectionString, PAS_DB_IP.Text, PAS_DB_SERVICE.Text, PAS_DB_ID.Text, PAS_DB_PASSWORD.Text,
                //                                                      HOST_DB_IP.Text, HOST_DB_SERVICE.Text, HOST_DB_ID.Text, HOST_DB_PASSWORD.Text);
                //공통.출하라인접속정보저장(GlobalCore.PasDBConnectionString, changedTable);

                DataRow row = GetDatas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                return;
            }

            //닫기
            DialogResult = DialogResult.OK;
            this.Close();
        }
        
        private void 닫기버튼_Click(object sender, EventArgs e)
        {
            //닫기
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

    }
}
