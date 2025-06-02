using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using TR_Common;
using TR_Provider;

namespace PAS.PMP
{
    public partial class frmTRPAS00011 : Form
    {
        #region 폼개체 선언부

        private DataTable m배치연동Table = new DataTable("");
        private DataTable m배치수신Table = new DataTable("");
        private DataTable m배치분류Table = new DataTable("");

        private BindingSource m배치연동BS = new BindingSource();
        private BindingSource m배치수신BS = new BindingSource();
        private BindingSource m배치분류BS = new BindingSource();


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

                PasWCS.연동.조회미수신기간별(m배치연동Table, m조회시작일자, m조회종료일자, false);

                m배치연동BS.DataSource = m배치연동Table;
                uGrid1.DataSource = m배치연동BS;

                Common.SetGridInit(this.uGrid1, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid1, null);
                Common.SetGridEditColumn(this.uGrid1, "선택");

                //this.uGrid1.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //this.uGrid1.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";

                //Common.uGridSummarySet(this.uGrid1, SummaryType.Count, "소속코드");

                #endregion

                #region uGrid2 BindingSource 초기화

                PasWCS.연동.조회수신기간별(m배치수신Table, m조회시작일자, m조회종료일자, false);

                m배치수신BS.DataSource = m배치수신Table;
                uGrid2.DataSource = m배치수신BS;

                Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid2, null);
                Common.SetGridEditColumn(this.uGrid2, "선택");

                //정산.마스터관리.브랜드.조회전체(m_브랜드관리Table, 0);

                //this.m_브랜드관리BS.DataSource = this.m_브랜드관리Table;
                //this.uGrid2.DataSource = this.m_브랜드관리BS;

                //Common.SetGridInit(this.uGrid2, true, true, true, true, false, false);
                //Common.SetGridHiddenColumn(this.uGrid2, null);
                //Common.SetGridEditColumn(this.uGrid2, "선택");

                //this.uGrid2.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //this.uGrid2.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";

                //Common.uGridSummarySet(this.uGrid2, SummaryType.Count, "브랜드코드");

                //브랜드센터코드.DataBindings.Add(new Binding("Value", this.m_브랜드관리BS, "센터코드", true));
                //브랜드코드.DataBindings.Add(new Binding("Value", this.m_브랜드관리BS, "브랜드코드", true));
                //브랜드명.DataBindings.Add(new Binding("Text", this.m_브랜드관리BS, "브랜드명", true));
                //브랜드비고.DataBindings.Add(new Binding("Text", this.m_브랜드관리BS, "비고", true));
                //브랜드사용여부.DataBindings.Add(new Binding("CheckedValue", this.m_브랜드관리BS, "사용여부", true));

                #endregion

                #region uGrid3 BindingSource 초기화

                PasWCS.연동.배치작업조회(m배치분류Table, "", "", m조회종료일자, false);

                m배치분류BS.DataSource = m배치분류Table;
                uGrid3.DataSource = m배치분류BS;

                Common.SetGridInit(this.uGrid3, true, true, true, true, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, null);
                Common.SetGridEditColumn(this.uGrid3, "선택");

                //this.uGrid3.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //this.uGrid3.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";

                //Common.uGridSummarySet(this.uGrid3, SummaryType.Count, "센터코드");

                //센터코드.DataBindings.Add(new Binding("Value", this.m_센터관리BS, "센터코드", true));
                //센터명.DataBindings.Add(new Binding("Text", this.m_센터관리BS, "센터명", true));
                //센터비고.DataBindings.Add(new Binding("Text", this.m_센터관리BS, "비고", true));

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

        }

        private void 전체선택2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void 전체선택3_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region 버튼Event

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                PasWCS.연동.조회미수신기간별(m배치연동Table, m조회시작일자, m조회종료일자, true);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }

        private void 수신버튼_Click(object sender, EventArgs e)
        {
            if (m배치연동Table == null) return;
            try
            {
                var datas = m배치연동Table.AsEnumerable()
                .Where(row => row.Field<bool>("선택"))
                .Select(row => row.Field<string>("배치번호"))
                .Distinct().ToList();

                if (datas.Count == 0)
                {
                    MessageBox.Show("선택된 배치가 없습니다.", this.Text);
                    return;
                }

                PasWCS.연동.수신(datas);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }


        private void 슈트조정버튼_Click(object sender, EventArgs e)
        {
        }

        private void 새로고침버튼_Click(object sender, EventArgs e)
        {
            try
            {
                PasWCS.연동.조회수신기간별(m배치수신Table, m조회시작일자, m조회종료일자, true);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }
 
        private void 수신취소버튼_Click(object sender, EventArgs e)
        {
            if (m배치수신Table == null) return;
            try
            {

                var datas = m배치연동Table.AsEnumerable()
                .Where(row => row.Field<bool>("선택"))
                .Select(row => row.Field<string>("원배치번호"))
                .Distinct().ToList();

                if (datas.Count == 0)
                {
                    MessageBox.Show("선택된 배치가 없습니다.", this.Text);
                    return;
                }
                PasWCS.연동.수신취소(datas);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
            try
            {
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }


        private void 작업조회버튼_Click(object sender, EventArgs e)
        {
            PasWCS.연동.배치작업조회(m배치분류Table, "", "", m조회종료일자, true);
        }

        private void 출하위치변경버튼_Click(object sender, EventArgs e)
        {

        }

        private void 배치명변경버튼_Click(object sender, EventArgs e)
        {

        }

        private void 배치작성버튼_Click(object sender, EventArgs e)
        {
            string messageText = string.Empty;
            if (string.IsNullOrEmpty(m분류명))
            {
                messageText = @"분류명을 지정하지 않았습니다.

분류명을 지정하지 않으면 분류번호가 분류명이 됩니다.

분류명을 지정하시겠습니까?
";
                if (MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    분류명.Focus();
                    return;
                }
            }


            //기분류
            messageText = @"기 분류번호에 이어서 작업 하시겠습니까?";
            if (MessageBox.Show(messageText, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                //추가작업
            }
            else
            {
                //신규작업
            }

            //usp_분류_작업수신_Set
            //ㅁㅁ                              ==
        }

        private void 작성취소버튼_Click(object sender, EventArgs e)
        {
            // usp_분류_수신취소_Set
        }

        #endregion

    }
}
