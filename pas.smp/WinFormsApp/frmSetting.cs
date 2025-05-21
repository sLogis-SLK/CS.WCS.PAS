using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace pas.smp.WinFormsApp
{
    public partial class frmSetting: Form
    {
        private bool IsSaved { get; set; }

        public frmSetting()
        {
            InitializeComponent();
            List<string> stringList = new List<string>();
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
                stringList.Add(installedPrinter);
            this.comboBox3.Items.AddRange((object[])stringList.ToArray());
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void 저장버튼_Click(object sender, EventArgs e)
        {
            try
            {
                INI ini = new INI(Global.g_sStartupPath + "\\smp.ini");
                ini.SetIniValue(INI_SECTION.SMP, INI_KEY.PLC_IP, this.textBox1.Text);
                ini.SetIniValue(INI_SECTION.SMP, INI_KEY.PLC_PORT, this.textBox2.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_IP, this.textBox3.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_SERVICE, this.textBox4.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_ID, this.textBox5.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_PASSWORD, this.textBox6.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_IP, this.textBox7.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_SERVICE, this.textBox8.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_ID, this.textBox9.Text);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_PASSWORD, this.textBox10.Text);
                ini.SetIniValue(INI_SECTION.ETC, INI_KEY.COM_NAME, this.comboBox1.Text);
                ini.SetIniValue(INI_SECTION.ETC, INI_KEY.COM_BAUDRATE, this.comboBox2.Text);
                ini.SetIniValue(INI_SECTION.ETC, INI_KEY.PRINTER_NAME, this.comboBox3.Text);
                ini.SetIniValue(INI_SECTION.ETC, INI_KEY.URL, this.textBox11.Text);
                MessageBox.Show("설정이 저장되었습니다.", this.Text);
                this.IsSaved = true;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(Name, ex.Message);
                LogUtil.Log((object)"[frmSetting 저장]", (object)ex.Message);
            }
        }

        private void 닫기버튼_Click(object sender, EventArgs e)
        {
            if (this.IsSaved)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalClass.GetSetting();
                this.textBox1.Text = GlobalClass.Setting.PLC_IP;
                this.textBox2.Text = GlobalClass.Setting.PLC_PORT;
                this.textBox3.Text = GlobalClass.Setting.PASDB_IP;
                this.textBox4.Text = GlobalClass.Setting.PASDB_SERVICE;
                this.textBox5.Text = GlobalClass.Setting.PASDB_ID;
                this.textBox6.Text = GlobalClass.Setting.PASDB_PASSWORD;
                this.textBox7.Text = GlobalClass.Setting.HOST_IP;
                this.textBox8.Text = GlobalClass.Setting.HOST_SERVICE;
                this.textBox9.Text = GlobalClass.Setting.HOST_ID;
                this.textBox10.Text = GlobalClass.Setting.HOST_PASSWORD;
                this.comboBox1.Text = GlobalClass.Setting.COM_NAME;
                this.comboBox2.Text = GlobalClass.Setting.COM_BAUDRATE;
                this.comboBox3.Text = GlobalClass.Setting.PRINTER_NAME;
                this.textBox11.Text = GlobalClass.Setting.URL;
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(this.Text, ex);
            }
        }
    }
}
