using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Library.Controls;

namespace PAS.PMP.WinFormsApp
{
    public partial class frmTRPASTEST : BaseForm
    {
        public frmTRPASTEST()
        {
            InitializeComponent();
            this.tabControl1.TabPages.Add(this.tabPage1);
            uGrid myGrid = new uGrid();

            myGrid.Dock = DockStyle.Fill;
            
        }

        
    }
}
