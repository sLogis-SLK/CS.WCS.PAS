using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinTabs;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using PAS.PMP.WinFormsApp;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TR_Common;

namespace PAS.PMP
{
    public partial class MainForm : BaseForm
    {
        private UltraTreeNode m_LastNodeFromPos = null;
        private string _pasLine = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string path_AppStyling = Application.StartupPath + @"\uStyle.isl";
            if (File.Exists(path_AppStyling))
            {
                //Infragistics.Win.AppStyling.StyleManager.Load(path_AppStyling);
            }


            Color 색상 = Color.FromArgb(221, 235, 247);

            //색상 = System.Drawing.Color.LightSteelBlue;
            //색상 = Color.FromArgb(0, 99, 177);
            //색상 = Color.FromArgb(0, 204, 106);
            //색상 = Color.FromArgb(176, 196, 222);
            //색상 = Color.FromArgb(198, 224, 180);
            //색상 = Color.FromArgb(221, 235, 247);
            //색상 = Color.FromArgb(255, 242, 204);
            //색상 = Color.FromArgb(130, 188, 0);
            //색상 = Color.FromArgb(0, 65, 106);

            _MainForm_Toolbars_Dock_Area_Right.BackColor = 색상;
            _MainForm_Toolbars_Dock_Area_Top.BackColor = 색상;
            _MainForm_Toolbars_Dock_Area_Bottom.BackColor = 색상;
            ultraToolbarsManager1.Appearance.BackColor = 색상;

            ultraTabbedMdiManager1.TabSettings.ActiveTabAppearance.BackColor = 색상;      //Color.Blue;
            ultraTabbedMdiManager1.TabSettings.ActiveTabAppearance.ForeColor = Color.Black;   //Color.White;
            ultraTabbedMdiManager1.TabSettings.ActiveTabAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

            //ultraDockManager1.floatin

            GlobalClass.InitializationSettings();
            ComboBoxTool cbo = ultraToolbarsManager1.Tools["라인설정"] as ComboBoxTool;
            foreach (var item in GlobalClass.DicPas기기)
            {
                cbo.ValueList.ValueListItems.Add(item.Key);
            }

            GlobalClass.전역상태바 = statusStrip1;

            cbo.Value = GlobalClass.DefaultValuePasName;

            if (cbo.SelectedItem != null)
            {
                if (GlobalClass.SettingsPas기기(GlobalClass.DefaultValuePasName))
                {

                }
                else
                {

                }
            }

            this.ultraTabbedMdiManager1.TabGroupSettings.TabOrientation = Infragistics.Win.UltraWinTabs.TabOrientation.BottomLeft;
            this.ultraTabbedMdiManager1.TabGroupSettings.TabSizing = TabSizing.AutoSize;
            this.ultraTabbedMdiManager1.TabSettings.TabAppearance.CreateFont(new Font("맑은 고딕", 24f, FontStyle.Regular));
        }


        private void ultraTree1_DoubleClick(object sender, EventArgs e)
        {
            string strTag = string.Empty;
            string strGubun = string.Empty;
            string strType = string.Empty;
            string strFormNm = string.Empty;

            if (uTreeProgram?.SelectedNodes == null || uTreeProgram.SelectedNodes.Count == 0)
                return;

            if (string.IsNullOrEmpty(GlobalClass.장비명))
            {
                MessageBox.Show("상단에 PAS Line 을 선택해주세요.");
                return;
            }

            try
            {
                UltraTreeNode selectedNode = uTreeProgram.SelectedNodes.Count > 0
                ? uTreeProgram.SelectedNodes[0]
                : null;

                strTag = selectedNode.Tag == null ? string.Empty : selectedNode.Tag.ToString();

                if (string.IsNullOrEmpty(strTag) == false)
                {
                    Form form = null;

                    switch(strTag)
                    {
                        case "frmTRPAS00021":
                            form = new frmTRPAS00021();
                            break;
                        case "frmTRPAS00001":
                            form = new frmTRPAS00001();
                            break;
                        case "frmTRPAS00002":
                            form = new frmTRPAS00002();
                            break;
                        case "frmTRPAS00003":
                            form = new frmTRPAS00003();
                            break;
                        case "frmTRPAS00004":
                            form = new frmTRPAS00004();
                            break;
                        case "frmTRPAS00005":
                            form = new frmTRPAS00005();
                            break;
                        case "frmTRPAS00006":
                            form = new frmTRPAS00006();
                            break;
                        case "frmTRPAS00007":
                            form = new frmTRPAS00007();
                            break;
                        case "frmTRPAS00008":
                            form = new frmTRPAS00008();
                            break;
                        case "frmTRPAS00011":
                            form = new frmTRPAS00011();
                            break;
                        case "frmTRPAS00012":
                            form = new frmTRPAS00012();
                            break;
                        case "frmTRPAS00013":
                            form = new frmTRPAS00013();
                            break;
                        case "frmTRPAS00022":
                            form = new frmTRPAS00022();
                            break;
                        case "frmTRPAS00023":
                            //form = new frmTRPAS00023();
                            form = new Core.WinFormsApp.PasSettingForm();
                            break;
                        case "frmTRPAS00024":
                            form = new frmTRPAS00024();
                            break;
                        case "frmTRDLG00064":
                            form = new frmTRDLG00064();
                            break;
                        default:
                            MessageBox.Show("해당 태그에 해당하는 폼이 없습니다.");
                            break;
                    }

                    if (form != null)
                    {
                        //this.mdi
                        // 이미 열린 폼인지 확인 (중복 방지)
                        foreach (Form openForm in this.MdiChildren)
                        {
                            if (openForm.GetType() == form.GetType())
                            {
                                openForm.Activate();
                                return;
                            }
                        }
                        DockableControlPane dcPane = this.ultraDockManager1.ControlPanes["uTreeProgram"];
                        dcPane.Close();
                        form.MdiParent = this;
                        if (form is BaseForm)
                        {
                            (form as BaseForm).StatusChanged += MainForm_StatusChanged1;
                        }

                        form.Show();
                        //form.WindowState = FormWindowState.Maximized;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MainForm_StatusChanged1(string message)
        {
            if (statusStrip1.InvokeRequired)
            {
                // 비동기 (UI 스레드가 아님): Invoke로 처리
                statusStrip1.Invoke((MethodInvoker)(() => toolStripStatusLabel1.Text = message));
            }
            else
            {
                // 동기 (UI 스레드): 바로 처리
                toolStripStatusLabel1.Text = message;
            }
        }

        private void ultraTree1_MouseDown(object sender, MouseEventArgs e)
        {
            this.m_LastNodeFromPos = uTreeProgram.GetNodeFromPoint(e.X, e.Y);
        }

        private void ultraToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            //Form frmDlg = null;
            DockableControlPane dcPane = this.ultraDockManager1.ControlPanes["uTreeProgram"];

            if (e.Tool.Key == "메뉴")
            {
                if (dcPane.IsVisible)
                    dcPane.Close();
                else
                    dcPane.Show();
            }
            else if (e.Tool.Key == "저장")
            {
                if (this.ActiveMdiChild is IToolBase)
                    ((IToolBase)this.ActiveMdiChild).OnExcel();
            }
            else if (e.Tool.Key == "프린트" || e.Tool.Key == "인쇄")
            {
                if (this.ActiveMdiChild is IToolBase)
                    ((IToolBase)this.ActiveMdiChild).OnPrint(false);
            }
        }

        private void ultraToolbarsManager1_ToolValueChanged(object sender, ToolEventArgs e)
        {
            if (e.Tool.Key == "라인설정")
            {
                ComboBoxTool cbo = ultraToolbarsManager1.Tools["라인설정"] as ComboBoxTool;
                _pasLine = cbo.Value.ToString();

                if (GlobalClass.SettingsPas기기(_pasLine)) //기기정보 세팅
                {
                    // 모든창 닫기 
                    MdiTab oTab = this.ultraTabbedMdiManager1.ActiveTab;
                    while (oTab != null)
                    {
                        oTab.Close();
                        if (oTab.Index >= 0)
                            break;

                        oTab = this.ultraTabbedMdiManager1.ActiveTab;
                    }
                }
            }
        }
    }
}
