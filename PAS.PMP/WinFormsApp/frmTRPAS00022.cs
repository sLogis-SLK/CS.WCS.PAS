using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class frmTRPAS00022 : BaseForm
    {
        #region 폼개체 선언부
        private DataTable m_관리_분류실적_백업Table = new DataTable("usp_관리_분류실적_백업_Get");
        private BindingSource m_관리_분류실적_백업BS = new BindingSource();
        private string m조회시작일자
        {
            get { return (Convert.ToDateTime(this.ucl조회시작일.Value)).ToString("yyyyMMdd"); }
        }

        private string m조회종료일자
        {
            get { return (Convert.ToDateTime(this.ucl조회종료일.Value)).ToString("yyyyMMdd"); }
        }

        private string 배치상태값 { get; set; }

        #endregion

        #region 초기화

        public frmTRPAS00022()
        {
            InitializeComponent();
            var valueList = ValueListUtil.ValueItemList.ValueList_분류실적처리();
            var comboItems = valueList.ValueListItems
                .Cast<ValueListItem>()
                .Select(item => new KeyValuePair<string, string>(item.DataValue.ToString(), item.DisplayText))
                .ToList();

            // com분류실적처리 세팅
            com분류실적처리.DataSource = new BindingSource(comboItems, null);
            com분류실적처리.DisplayMember = "Value";
            com분류실적처리.ValueMember = "Key";
            com분류실적처리.Value = "0";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ucl조회시작일.Value = DateTime.Now;
            ucl조회종료일.Value = DateTime.Now;
            SetDataTableBindingInit();
        }

        #endregion

        #region 사용자정의함수

        private void SetDataTableBindingInit()
        {
            try
            {
                관리.분류실적백업_Get(m_관리_분류실적_백업Table, m조회시작일자, m조회종료일자, GlobalClass.장비명, "모두", 0);

                this.m_관리_분류실적_백업BS.DataSource = this.m_관리_분류실적_백업Table;
                this.uGrid3.DataSource = this.m_관리_분류실적_백업BS;

                Common.SetGridInit(this.uGrid3, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(this.uGrid3, "분류상태코드", "배치상태코드");
                Common.SetGridEditColumn(this.uGrid3, null);

                //this.uGrid3.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
        }

        #endregion

        #region 이벤트

        private void 조회버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                
                this.배치상태값 = "모두";
                관리.분류실적백업_Get(m_관리_분류실적_백업Table, m조회시작일자, m조회종료일자, GlobalClass.장비명, "모두", 1);

                int 완료 = 0;
                int 실적작성 = 0;
                int 실적반영 = 0;
                int 배치반영 = 0;

                foreach (DataRow row in this.m_관리_분류실적_백업Table.Rows)
                {
                    switch (row["배치상태코드"].ToString())
                    {
                        case "9":
                            완료++;
                            break;
                        case "A":
                            실적작성++;
                            break;
                        case "B":
                            실적반영++;
                            break;
                        case "C":
                            배치반영++;
                            break;
                    }
                }

                this.완료.Text = $"완료 : {완료:#,0}";
                this.실적작성.Text = $"실적작성 : {실적작성:#,0}";
                this.실적반영.Text = $"실적반영 : {실적반영:#,0}";
                this.배치반영.Text = $"배치반영 : {배치반영:#,0}";
                this.Total.Text = $"Total : {this.m_관리_분류실적_백업Table.Rows.Count:#,0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 기간버튼_Click(object sender, EventArgs e)
        {
            if (!(sender is Button))
                return;

            Button button = (Button)sender;
            DateTime now = DateTime.Now;
            DateTime startDate = now;
            switch (button.Text)
            {
                case "오늘":
                    break;
                case "1주":
                    startDate = now.AddDays(-7);
                    break;
                case "1달":
                    startDate = now.AddMonths(-1);
                    break;
                case "3달":
                    startDate = now.AddMonths(-3);
                    break;
                case "1년":
                    startDate = now.AddYears(-1);
                    break;
            }

            this.ucl조회시작일.Value = startDate;
            this.ucl조회종료일.Value = now;
        }

        private void 배치상태별조회버튼_Click(object sender, EventArgs e)
        {
            if (!(sender is UltraLabel))
                return;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                UltraLabel ulabel = sender as UltraLabel;
                if (ulabel.Tag == null)
                    return;
                this.배치상태값 = ulabel.Tag.ToString();
                관리.분류실적백업_Get(m_관리_분류실적_백업Table, m조회시작일자, m조회종료일자, GlobalClass.장비명, "모두", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void 실행버튼_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrEmpty(this.배치상태값))
                    this.배치상태값 = "모두";
                관리.분류실적백업_Set(m조회시작일자, m조회종료일자, GlobalClass.장비명, this.배치상태값, this.com분류실적처리.Text);
                if (!(this.com분류실적처리.Text == "삭제"))
                    return;
                foreach (DataRow row in (InternalDataCollectionBase)this.m_관리_분류실적_백업Table.Rows)
                {
                    string 분류번호 = row["분류번호"].ToString();
                    string 작업일자 = row["작업일자"].ToString();
                    string 월일;
                    try
                    {
                        월일 = 작업일자.Substring(4, 4);
                    }
                    catch
                    {
                        월일 = DateTime.Now.ToString("MMdd");
                    }
                    if (Directory.Exists($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}\\{분류번호}"))
                        Directory.Delete($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}\\{분류번호}", true);
                    if (Directory.GetDirectories($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}").Length == 0 && Directory.Exists($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}"))
                        Directory.Delete($"{GlobalClass.LOCAL_FOLDER}\\DATA\\DATE{월일}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                if (this.m_관리_분류실적_백업Table.Rows.Count > 0)
                    this.조회버튼_Click((object)null, EventArgs.Empty);
            }
        }

        private void com분류실적처리_ValueChanged(object sender, EventArgs e)
        {
            if (this.com분류실적처리.Text == "삭제")
                this.ultraLabel2.Text = "* 삭제는 백업된 배치에만 해당됩니다.";
            else
                this.ultraLabel2.Text = "* 백업은 현재 운영중이거나 중단된 배치는 제외합니다.";
        }

        #endregion

    }
}
