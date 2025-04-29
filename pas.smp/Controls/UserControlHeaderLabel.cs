using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pas.smp.Controls
{
    public partial class UserControlHeaderLabel : UserControl
    {
        [Category("SetText")]
        [Description("Header 의 Text를 설정합니다.")]
        public string SetHeaderText
        {
            get => HeaderText.Text;
            set
            {
                HeaderText.Text = value;
            }
        }

        public override string Text
        {
            get => MainText.Text;
            set => MainText.Text = value;
        }

        //[Category("Custom Properties")]
        //[Description("컨트롤의 내용 Text를 설정합니다.")]
        //public string SetText
        //{
        //    get => MainText.Text; 
        //    set
        //    {
        //        MainText.Text = value;
        //    }
        //}

        public UserControlHeaderLabel()
        {
            InitializeComponent();


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

    }
}
