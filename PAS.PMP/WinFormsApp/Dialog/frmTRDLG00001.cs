using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS.PMP.WinFormsApp.Dialog
{
    public partial class frmTRDLG00001 : Form
    {
        public int 선택값 { get; set; }

        public frmTRDLG00001()
        {
            InitializeComponent();
        }

        private void 선택_Click(object sender, EventArgs e)
        {
            if (this.box별.Checked)
                ++this.선택값;
            if (this.total별.Checked)
                this.선택값 += 2;

            this.DialogResult = DialogResult.OK;
        }

        private void 취소_Click(object sender, EventArgs e)
        {
            this.선택값 = 0;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
