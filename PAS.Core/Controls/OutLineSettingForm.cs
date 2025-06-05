using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace PAS.Core.Controls
{
    public partial class OutLineSettingForm : Form
    {
        #region 폼개체 선언부

        private DataTable m환경설정Table = new DataTable();
        private BindingSource m환경설정BS = new BindingSource();

        enum enum신규입력
        {
            신규,
            신규취소
        }

        private enum신규입력 입력여부
        {
            get
            {
                if (신규버튼.Text == "[F6]신규") return enum신규입력.신규;
                return enum신규입력.신규취소;
            }
            set
            {
                if (value == enum신규입력.신규)
                {
                    신규버튼.Text = "[F6]신규취소"; //TEXT 는 반대로 설정
                    NAME.ReadOnly = false;
                }
                else
                {
                    신규버튼.Text = "[F6]신규";
                    NAME.ReadOnly = true;
                }
            }
        }

        #endregion

        #region 초기화

        public OutLineSettingForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

            SetDataTableBindingInit();
        }

        private void SetDataTableBindingInit()
        {
            try
            {
                #region uGrid1 BindingSource 초기화
                m환경설정Table = 공통.출하라인접속정보(GlobalCore.PasDBConnectionString);
                m환경설정BS.DataSource = m환경설정Table;

                uGrid1.DataSource = m환경설정BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                Common.SetGridEditColumn(this.uGrid1, "선택");

                NAME.DataBindings.Add(new Binding("Text", m환경설정BS, "NAME", true));
                PLC_IP.DataBindings.Add(new Binding("Text", m환경설정BS, "PLC_IP", true));
                PLC_PORT.DataBindings.Add(new Binding("Text", m환경설정BS, "PLC_PORT", true));
                COM_NAME.DataBindings.Add(new Binding("Text", m환경설정BS, "COM_NAME", true));
                COM_BAUDRATE.DataBindings.Add(new Binding("Text", m환경설정BS, "COM_BAUDRATE", true));
                PRINTER_NAME.DataBindings.Add(new Binding("Text", m환경설정BS, "PRINTER_NAME", true));
                BARCODE_POSITION.DataBindings.Add(new Binding("Text", m환경설정BS, "BARCODE_POSITION", true));
                URL.DataBindings.Add(new Binding("Text", m환경설정BS, "URL", true));

                NAME.ReadOnly = true;

                #endregion

                #region DB접속정보 Groupbox Control 초기Data

                DataTable dt_DB접속정보 = 공통.DB접속정보(GlobalCore.PasDBConnectionString);
                if (dt_DB접속정보 != null && dt_DB접속정보.Rows.Count > 0)
                {
                    DataRow row = dt_DB접속정보.Rows[0];
                    PAS_DB_IP.Text = row["PAS_DB_IP"].ToString();
                    PAS_DB_SERVICE.Text = row["PAS_DB_SERVICE"].ToString();
                    PAS_DB_ID.Text = row["PAS_DB_ID"].ToString();
                    PAS_DB_PASSWORD.Text = row["PAS_DB_PASSWORD"].ToString();
                    HOST_DB_IP.Text = row["HOST_DB_IP"].ToString();
                    HOST_DB_SERVICE.Text = row["HOST_DB_SERVICE"].ToString();
                    HOST_DB_ID.Text = row["HOST_DB_ID"].ToString();
                    HOST_DB_PASSWORD.Text = row["HOST_DB_PASSWORD"].ToString();
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }



        #endregion
         
        #region 사용자정의함수

        #endregion

        #region 버튼 Event

        private void 신규버튼_Click(object sender, EventArgs e)
        {
            if (입력여부 == enum신규입력.신규취소)
            {
                m환경설정BS.RemoveCurrent();
                입력여부 = enum신규입력.신규취소;
            }
            else
            {
                DataRow oRow = ((DataRowView)m환경설정BS.AddNew()).Row;
                oRow["선택"] = false;
                if (m환경설정Table.Rows.Count > 0) m환경설정Table.AcceptChanges();
                NAME.Focus();
                입력여부 = enum신규입력.신규;
            }
        }

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            //데이터저장
            m환경설정BS.EndEdit();
            DataTable changedTable = m환경설정Table.GetChanges();
            if (changedTable == null || changedTable.Rows.Count == 0)
            {
                MessageBox.Show("추가/변경된 데이터가 없습니다.", this.Text);
                return;
            }
            
            //환경설정 갱신
            try
            {
                공통.DB접속정보저장(GlobalCore.PasDBConnectionString, PAS_DB_IP.Text, PAS_DB_SERVICE.Text, PAS_DB_ID.Text, PAS_DB_PASSWORD.Text,
                                                                      HOST_DB_IP.Text, HOST_DB_SERVICE.Text, HOST_DB_ID.Text, HOST_DB_PASSWORD.Text);
                공통.출하라인접속정보저장(GlobalCore.PasDBConnectionString, changedTable);
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
        private void 삭제버튼_Click(object sender, EventArgs e)
        {
            string msgText = "정말 삭제 하시겠습니까?\r\n\r\n삭제시 되돌릴수 없습니다.";
            if (MessageBox.Show(msgText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;
             
            try
            {
                DataRow[] rows = m환경설정Table.Select("선택 = True");
                공통.출하라인접속정보삭제(GlobalCore.PasDBConnectionString, rows);

                foreach (DataRow row in rows)
                {
                    m환경설정Table.Rows.Remove(row); // 또는 row.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
                return;
            }
        }

        private void 닫기버튼_Click(object sender, EventArgs e)
        {
            //닫기
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #endregion

        #region 기타 Event

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.F5)
            {
            }
            else if (e.KeyCode == Keys.F6)
            {
                신규버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                저장버튼_Click(null, null);
            }
        }

        #endregion
    }
}
