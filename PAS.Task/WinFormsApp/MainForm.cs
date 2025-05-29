using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS.Task
{
    public partial class MainForm : Form
    {
        private Timer m_oPasDurationTimer;
        private Timer m_oPrinterDurationTimer;
        private SocketServer m_oServer;

        private DataTable m_표시기맵Table = new DataTable("표시기맵TABLE");
        private DataTable m_분류_숫자표시기값Table = new DataTable("usp_분류_숫자표시기값_Get");

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
