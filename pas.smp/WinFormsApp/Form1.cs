using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pas.smp.WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //박스바코드.SetHeaderText = "박스바 코드";
            //총량.SetHeaderText = "총 량";
            //매장명.SetHeaderText = "매 장 명";
            //배송사.SetHeaderText = "배 송 사";
            //배치번호.SetHeaderText = "배치 번호";
            //슈트번호.SetHeaderText = "슈트 번호";
            //박스번호.SetHeaderText = "박스 번호";
            //내품수.SetHeaderText = "내 품 수";
            //마지막박스.SetHeaderText = "마지막 박스";
            //운송장번호.SetHeaderText = "운송장 번호";
            //재발행.SetHeaderText = "재 발 행";
            //총량무시.SetHeaderText = "총량 무시";


            미발행대상버튼.Click += new System.EventHandler(this.미발행대상버튼_Click);
            다시시작버튼.Click += new System.EventHandler(this.다시시작버튼_Click);
            설정버튼.Click += new System.EventHandler(this.설정버튼_Click);
            종료버튼.Click += new System.EventHandler(this.종료버튼_Click);
        }




        #region 버튼이벤트

        private void 미발행대상버튼_Click(object sender, EventArgs e)
        {

        }

        private void 다시시작버튼_Click(object sender, EventArgs e)
        {

        }

        private void 설정버튼_Click(object sender, EventArgs e)
        {

        }

        private void 종료버튼_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
