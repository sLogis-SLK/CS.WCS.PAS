﻿using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinTabbedMdi;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
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

namespace PAS.PMP
{
    public partial class MainForm : Form
    {
        private UltraTreeNode m_LastNodeFromPos = null;
        private string _pasLine = string.Empty;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
        }


        private void ultraTree1_DoubleClick(object sender, EventArgs e)
        {
            string strTag = string.Empty;
            string strGubun = string.Empty;
            string strType = string.Empty;
            string strFormNm = string.Empty;
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
                            form = new frmTRPAS00023();
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
