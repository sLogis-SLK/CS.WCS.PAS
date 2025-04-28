using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pas.smp
{
    public partial class MainForm : Form
    {
        string COM_NAME = "COM1";
        int COM_BAUDRATE = 19200;

        public MainForm()
        {

            InitializeComponent();

            미발행대상버튼.Click += new System.EventHandler(this.미발행대상버튼_Click);
            다시시작버튼.Click += new System.EventHandler(this.다시시작버튼_Click);
            설정버튼.Click += new System.EventHandler(this.설정버튼_Click);
            종료버튼.Click += new System.EventHandler(this.종료버튼_Click);
        }

        #region 버튼이벤트

        private void 미발행대상버튼_Click(object sender, EventArgs e)
        {
            //팝업창띄우기

        }

        private void 다시시작버튼_Click(object sender, EventArgs e)
        {
            //시리얼 포트 재시작 으로 보임

        }

        private void 설정버튼_Click(object sender, EventArgs e)
        {
            //세팅창 띄우기
        }

        private void 종료버튼_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 사용자 정의 함수

        private void Refresh_시리얼포트()
        {
            try
            {
                시리얼포트.Close();
                시리얼포트.PortName = COM_NAME;
                시리얼포트.BaudRate = COM_BAUDRATE;
                시리얼포트.Open();
            }
            catch (Exception ex)
            {

            }

            //쓰레드 다시 동작
            
        }

        #endregion
    }
}
