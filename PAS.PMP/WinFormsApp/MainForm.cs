using Infragistics.Shared;
using Infragistics.Win;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void ultraTree1_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {

        }

        private void ultraTree1_DoubleClick(object sender, EventArgs e)
        {
       

            string strTag = string.Empty;
            string strGubun = string.Empty;
            string strType = string.Empty;
            string strFormNm = string.Empty;
            try
            {
                UltraTreeNode selectedNode = 네비게이션.SelectedNodes.Count > 0
                ? 네비게이션.SelectedNodes[0]
                : null;

                strTag = selectedNode.Tag == null ? string.Empty : selectedNode.Tag.ToString();

                
                if (string.IsNullOrEmpty(strTag) == false)
                {
                    Form form = null;


                    switch(strTag)
                    {
                        case "frmTRPAS00011":
                            form = new frmTRPAS00011();
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
                        
                        form.MdiParent = this;
                        form.Show();
                        form.WindowState = FormWindowState.Maximized;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            Console.WriteLine(this.m_LastNodeFromPos);

           
        }

        private void ultraTree1_MouseDown(object sender, MouseEventArgs e)
        {
            this.m_LastNodeFromPos = 네비게이션.GetNodeFromPoint(e.X, e.Y);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           


        }

    
    }
}
