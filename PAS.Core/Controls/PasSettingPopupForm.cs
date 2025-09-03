using Infragistics.Win.UltraWinGrid;
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return;

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
                //신규버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                저장버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                닫기버튼_Click(null, null);
            }
        }


        #endregion

        #region 사용자정의함수

        private void SetInitializeDatas()
        {
            try
            {
              //  키인덱스 as 순서
		      //, [NAME]
		      //, [SEIGYO_IP]
		      //, [SEIGYO_PORT]
      	    
		      //, [CHUTES]
		      //, [CHUTES_ERROR]
		      //, [CHUTES_OVERFLOW]		    
	  	    
		      //, [SEIGYO_FOLDER]
		      //, [SEIGYO_ID]
		      //, [SEIGYO_PASSWORD]
	  	    
		      //, [LOCAL_FOLDER]
		      //, [PAS_DURATION]
	  	    
		      //, [INDICATOR_DURATION]
		      //, [INDICATOR_IP]
		      //, [INDICATOR_PORT]
		    
		      //, [INDICATOR_STRUCTURE]
		      //, [BARCODE_PRINTER_LIST]
		      //, [PRINTER_LIST]
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void GetDatas()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        private void 바코드프린터추가수정창(DataRow row)
        {
            if (row == null) return;

            //PasSettingPopupForm frm = new PasSettingPopupForm();
            //frm.기초DataRow = row; //기초데이터 생성
            //frm.StartPosition = FormStartPosition.CenterParent;

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    //조회버튼_Click(null, null);
            //}
            //frm.Dispose();
        }

        private void 거래명세서프린터추가수정창(DataRow row)
        {
            if (row == null) return;

            //PasSettingPopupForm frm = new PasSettingPopupForm();
            //frm.기초DataRow = row; //기초데이터 생성
            //frm.StartPosition = FormStartPosition.CenterParent;

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    //조회버튼_Click(null, null);
            //}
            //frm.Dispose();
        }

        #endregion

        #region 버튼 및 기타 Event

        private void 바코드프린터추가버튼_Click(object sender, EventArgs e)
        {
            바코드프린터추가수정창(m바코드Table.NewRow());
        }

        private void 바코드프린터수정버튼_Click(object sender, EventArgs e)
        {
            UltraGridRow activeRow = uGrid1바코드프린트.ActiveRow;
            if (activeRow == null || !activeRow.IsDataRow) return;
            DataRow row = (activeRow.ListObject as DataRowView)?.Row;
            바코드프린터추가수정창(row);
        }

        private void 바코드프린터삭제버튼_Click(object sender, EventArgs e)
        {

        }

        private void uGrid1바코드프린트_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //Cursor = Cursors.WaitCursor;
            try
            {
                if (e.Row == null) return;
                if (e.Row.Index < 0) return;

                DataRow row = (e.Row.ListObject as DataRowView)?.Row;
                바코드프린터추가수정창(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                //Cursor = Cursors.Default;
            }
        }

        private void 거래명세서프린터추가버튼_Click(object sender, EventArgs e)
        {

        }

        private void 거래명세서프린터수정버튼_Click(object sender, EventArgs e)
        {

        }

        private void 거래명세서프린터삭제버튼_Click(object sender, EventArgs e)
        {

        }

        private void uGrid2거래명세서프린트_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (e.Row == null) return;
                if (e.Row.Index < 0) return;

                DataRow row = (e.Row.ListObject as DataRowView)?.Row;
                거래명세서프린터추가수정창(row);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor = Cursors.Default;
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
