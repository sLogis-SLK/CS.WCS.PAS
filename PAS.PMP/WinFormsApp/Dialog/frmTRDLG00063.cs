using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PAS.PMP
{
    public partial class frmTRDLG00063 : Form
    {
        #region 폼개체 선언부

        public string 분류번호 { get; set; }

        public string 출하위치 { get; set; }

        #endregion

        #region 초기화

        public frmTRDLG00063()
        {
            InitializeComponent();
            var valueList = ValueListUtil.ValueItemList.ValueList_출하위치();
            var comboItems = valueList.ValueListItems
                .Cast<ValueListItem>()
                .Select(item => new KeyValuePair<string, string>(item.DataValue.ToString(), item.DisplayText))
                .ToList();

            // ultraCombo1 세팅
            ultraCombo1.DataSource = new BindingSource(comboItems, null);
            ultraCombo1.DisplayMember = "Value";
            ultraCombo1.ValueMember = "Key";
            ultraCombo1.Value = "3";

            // ultraCombo2 세팅
            ultraCombo2.DataSource = new BindingSource(comboItems, null);
            ultraCombo2.DisplayMember = "Value";
            ultraCombo2.ValueMember = "Key";
            ultraCombo2.Value = "3";
            this.StartPosition = FormStartPosition.CenterParent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ultraCombo1.Text = this.출하위치;
        }

        #endregion

        #region 사용자정의함수

        #endregion

        #region 버튼Event

        private void 닫기버튼_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Cancel;

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            try
            {
                관리.출하위치변경(this.분류번호, this.ultraCombo2.Text);
                MessageBox.Show("출하위치를 변경 하였습니다.", this.Text, MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

    }
}
