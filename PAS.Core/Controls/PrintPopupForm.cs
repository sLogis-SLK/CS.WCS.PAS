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
    public partial class PrintPopupForm : Form
    {
        #region 폼개체 선언부

        #endregion

        #region 초기화

        public PrintPopupForm()
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
            //    공통.출하라인접속정보저장(GlobalCore.PasDBConnectionString, changedTable);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, this.Text);
            //    return;
            //}

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

        #region 기타 Event

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Escape)
            {
                if (닫기버튼.Enabled && 닫기버튼.Visible) 닫기버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                //if (신규버튼.Enabled && 신규버튼.Visible) 신규버튼_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                if (저장버튼.Enabled && 저장버튼.Visible) 저장버튼_Click(null, null);
            }
        }

        #endregion
    }
}
