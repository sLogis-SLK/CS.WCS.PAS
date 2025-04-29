using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR_Common;

namespace pas.smp
{
    public partial class MainForm : Form
    {
        #region 개체선언부

        private System.Windows.Forms.Timer timer출하상태확인 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timer출하박스확인 = new System.Windows.Forms.Timer();

        private DataTable m_출하상태Table = new DataTable("usp_출하_상태확인_Get");
        private DataTable m_출하박스내역Table = new DataTable("usp_출하_박스내용_Get");

        private BindingSource m_출하상태BS = new BindingSource();
        private BindingSource m_출하박스내역BS = new BindingSource();
        #endregion

        #region 초기화

        public MainForm()
        {
            InitializeComponent();
            
            timer출하상태확인.Tick += Timer출하상태확인_Tick;
            timer출하박스확인.Tick += Timer출하박스확인_Tick;

            미발행대상버튼.Click += new System.EventHandler(this.미발행대상버튼_Click);
            다시시작버튼.Click += new System.EventHandler(this.다시시작버튼_Click);
            설정버튼.Click += new System.EventHandler(this.설정버튼_Click);
            종료버튼.Click += new System.EventHandler(this.종료버튼_Click);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            그리드초기화();

            //timer 초기 세팅값
            timer출하상태확인.Interval = 20000; //20초
            timer출하상태확인.Start();  //시작

            Refresh_시리얼포트();
        }

        #endregion

        #region Tick

        private void Timer출하상태확인_Tick(object sender, EventArgs e)
        {
            try
            {
                //DB에서 갱신해서 값 가지고 오기
                출하.출하내역관리.출하상태확인(m_출하상태Table, true);
            }
            catch (Exception)
            {

            }
        }

        private void Timer출하박스확인_Tick(object sender, EventArgs e)
        {
            timer출하박스확인.Stop();  //종료

            DateTime dateTime = DateTime.Now;
            현시간.Invoke(new Action(() => this.현시간.Text = dateTime.ToString("G")));

            //this.현시간.Text = dateTime.ToString("G");
            //Application.DoEvents();
            //Thread.Sleep(100000);
            //Thread.Sleep(10000);

            출하박스정보Receive();

            timer출하박스확인.Start();  //시작
        }

        #endregion

        #region 사용자 정의 함수

        private void 그리드초기화()
        {
            try
            {
                #region uGrid1 BindingSource 초기화
                
                출하.출하내역관리.출하상태확인(m_출하상태Table, true);
                
                m_출하상태BS.DataSource = m_출하상태Table;
                uGrid1.DataSource = m_출하상태BS;

                Common.SetGridInit(uGrid1, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(uGrid1, null);
                Common.SetGridEditColumn(uGrid1, null);

                //uGrid1.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //uGrid1.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";

                //Common.uGridSummarySet(uGrid1, SummaryType.Count, "센터코드");

                #endregion

                #region uGrid2 BindingSource 초기화

                출하.출하내역관리.출하박스내역(m_출하박스내역Table, string.Empty);

                m_출하박스내역BS.DataSource = m_출하박스내역Table;
                uGrid2.DataSource = m_출하박스내역BS;

                Common.SetGridInit(uGrid2, false, false, true, false, false, false);
                Common.SetGridHiddenColumn(uGrid2, null);
                Common.SetGridEditColumn(uGrid2, null);

                //uGrid2.DisplayLayout.Bands[0].Columns["등록일시"].Format = "yy-MM-dd HH:mm";
                //uGrid2.DisplayLayout.Bands[0].Columns["수정일시"].Format = "yy-MM-dd HH:mm";
                
                //Common.uGridSummarySet(uGrid2, SummaryType.Count, "브랜드코드");

                #endregion
            }
            catch (Exception ex)
            {
                Common.ErrorMessage(Name, ex);
            }
        }

        private void Refresh_시리얼포트()
        {
            //시리얼포트 갱신 및 박스체크 쓰레드 동작

            try
            {
                시리얼포트.Close();
                시리얼포트.PortName = GlobalClass.COM_NAME;
                시리얼포트.BaudRate = GlobalClass.COM_BAUDRATE;
                시리얼포트.Open();
            }
            catch (Exception ex)
            {

            }

            //쓰레드 다시 동작
            timer출하박스확인.Stop();//종료
            timer출하박스확인.Interval = 100; //0.1초
            timer출하박스확인.Start();//시작
        }

        private bool 출하박스정보Receive()
        {
            //if (this.uMessage1.Visible)
            //    return frmMain.상태처리.FALSE;


            //string buf = GlobalClass.PLC_PORT == 2001 ? GlobalClass.CMD_01_BUF : GlobalClass.CMD_02_BUF;


            string buf2 = !(GlobalClass.PLC_PORT == 2001) ? (!(GlobalClass.PLC_PORT == 2011) ? GlobalClass.CMD_02_BUF : GlobalClass.CMD_01_BUF) : GlobalClass.CMD_02_BUF;

            //byte[] buffer = ConvertUtil.StringToBuffer();

            try
            {
                byte[] numArray1 = new byte[4096];

                //소켓통신용 Socket 
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(GlobalClass.PLC_IP, GlobalClass.PLC_PORT);
                socket.Send(GlobalClass.GetBufferBybyte);

                IAsyncResult asyncResult = socket.BeginReceive(numArray1, 0, numArray1.Length, SocketFlags.None, (AsyncCallback)null, (object)null);
                if (asyncResult.AsyncWaitHandle.WaitOne(10000, false) == false)
                {
                    return true;
                }

                int socketCnt = socket.EndReceive(asyncResult);
                if (socketCnt <= 0)
                {
                    return true;
                }

                byte[] numArray2 = new byte[socketCnt];
                Buffer.BlockCopy((Array)numArray1, 0, (Array)numArray2, 0, socketCnt);

                if (numArray2[numArray2.Length - 2] == (byte)107 && numArray2[numArray2.Length - 1] == (byte)103)
                {
                    byte[] numArray3 = new byte[numArray2.Length - 31];
                    Buffer.BlockCopy((Array)numArray2, 31, (Array)numArray3, 0, numArray2.Length - 31);
                    string str1 = new string(numArray3.Select(b => (char)b).ToArray());

                    string[] strArray = str1.Split(new string[1] { " " }, StringSplitOptions.None);
                    List<string> lstTemp = new List<string>();
                    for (int index = 0; index < strArray.Length; ++index)
                    {
                        if (strArray[index].Trim() != string.Empty)
                            lstTemp.Add(strArray[index]);
                    }

                    if (lstTemp.Count >= 7)
                    {
                        화면에박스정보출력(lstTemp);
                    }
                    else
                    {
                        //Common.Log((object)"[SMP0001]", (object)Common.H2S(numArray2), (object)Common.B2C(numArray2));
                    }
                }
                else
                {
                    //Common.Log((object)"[SMP0002]", (object)Common.H2S(numArray2), (object)Common.B2C(numArray2));
                }

            }
            catch (Exception ex)
            {

                //throw;
            }


            return true;

        }

        private bool 화면에박스정보출력(List<string> lstTemp)
        {
            string s바코드 = string.Empty;
            string s실배치번호 = string.Empty;
            string s슈트번호 = string.Empty;
            string s박스번호 = string.Empty;
            string s마지막박스 = string.Empty;
            string s중량 = string.Empty;
            string s배송사명 = string.Empty;
            string s매장명 = string.Empty;
            string s내품수 = string.Empty;

            //public static string B2C(byte[] inBytes) => new string(inBytes.Select(b => (char)b).ToArray());
            if (this.박스바코드.Text == lstTemp[0].Trim())
            {
                return true;
            }

            //컨트롤초기화
            ControlInit();

            int num1 = IsValidWeight(lstTemp , /*중량무시.checked*/ false) ? 1 : 0;

            this.Invoke(new Action(() => this.ControlInit()));
            //this.중량무시.Invoke(new Action(() => this.중량무시.Checked = false));

            if (num1 == 0)
            {
                s바코드 = lstTemp[0];
                string s배치번호 = lstTemp[0].Substring(0, 8);
                s슈트번호 = lstTemp[0].Substring(8, 3);
                s박스번호 = lstTemp[0].Substring(11, 3);
                lstTemp[0].Substring(14, 1);
                s중량 = lstTemp[5] + lstTemp[6];
                s중량 = s중량.Replace("U", string.Empty);
                s중량 = s중량.Replace("u", string.Empty);

                //데이터 가져오기
                DataTable dt = new DataTable();

                m_출하박스내역Table.Clear();
                출하.출하내역관리.출하박스내역(m_출하박스내역Table, s바코드);

                if (m_출하박스내역Table == null || m_출하박스내역Table.Rows.Count <= 0)
                {
                    //this.uMessage1.ShowMessage(uMessage.MessageType.발행대상없음);
                    //발행대상없음이라고 메시지 띄움
                    Application.DoEvents();
                    return false;
                }

                DataRow row = m_출하박스내역Table.Rows[0];

                if (row["운송장출력여부"].ToString() == "1" /*&& 재발행.Checked == false*/)
                {
                    //this.uMessage1.ShowMessage(uMessage.MessageType.재발행);
                    //재발행이라고 메시지 띄움
                    Application.DoEvents();
                    return false;
                }

                string sBcode = row["브랜드코드"].ToString();
                row["브랜드명"].ToString();
                string sCenterCd = row["센터코드"].ToString();
                string sShippingCd = row["배송사코드"].ToString();
                s배송사명 = row["배송사명"].ToString();
                string sShopCd = row["점코드"].ToString();
                s매장명 = row["점명"].ToString();
                s내품수 = row["내품수"].ToString();
                row["점주소"].ToString();
                row["점전화번호1"].ToString();
                s마지막박스 = row["마지막박스여부"].ToString();
                s실배치번호 = row["실배치번호"].ToString();
                string str2 = row["출력값1"].ToString();
                string str3 = row["출력값2"].ToString();
                string str4 = row["출력값3"].ToString();
                string str5 = row["출력값4"].ToString();
                string str6 = row["출력값5"].ToString();
                row["출력값6"].ToString();
                row["출력값7"].ToString();
                row["출력값8"].ToString();
                row["출력값9"].ToString();
                row["출력값10"].ToString();
                if (row["배송사코드"].ToString() == string.Empty)
                {
                    //this.uMessage1.ShowMessage(uMessage.MessageType.배송사없음);
                    Application.DoEvents();
                    return false;
                }

                운송장채번Model c운송장 = null;

                //배송사 채번
                if (string.IsNullOrEmpty(str2))
                {
                    c운송장 = 채번.운송장채번("PAS", "9650", sCenterCd, sBcode, sShippingCd, sShopCd);
                }
                else
                {
                    c운송장 = new 운송장채번Model();
                    c운송장.운송장번호 = str2;
                    c운송장.출력값1 = str4;
                    c운송장.출력값2 = str3;
                    c운송장.출력값3 = str6;
                    c운송장.출력값4 = str5;
                    c운송장.채번여부 = true;
                }

                if (c운송장 != null && !c운송장.채번여부)
                {
                    //this.uMessage1.ShowMessage(uMessage.MessageType.채번실패);
                    Application.DoEvents();
                    return false;
                }

                this.박스바코드.Invoke(new Action(() => this.박스바코드.Text = s바코드));
                this.중량.Invoke(new Action(() => this.중량.Text = s중량));
                this.매장명.Invoke(new Action(() => this.매장명.Text = s매장명));
                this.배송사.Invoke(new Action(() => this.배송사.Text = s배송사명));
                this.배치번호.Invoke(new Action(() => this.배치번호.Text = s실배치번호));
                this.슈트번호.Invoke(new Action(() => this.슈트번호.Text = s슈트번호));
                this.박스번호.Invoke(new Action(() => this.박스번호.Text = s박스번호));
                this.내품수.Invoke(new Action(() => this.내품수.Text = s내품수));
                this.마지막박스.Invoke(new Action(() => this.마지막박스.Text = s마지막박스 == "1" ? GlobalClass.LAST_BOX_IDENTIFIER : string.Empty));
                this.운송장번호.Invoke(new Action(() => this.운송장번호.Text = c운송장.운송장번호));


                //그리드에 추가하고, 20개 까지만 화면에 표시한다.
                //this.smpGrid1.Invoke(new Action(() =>
                //{
                //    int count2 = this.smpGrid1.Rows.Count;
                //    if (count2 >= 20)
                //        this.smpGrid1.Rows.RemoveAt(count2 - 1);
                //    this.smpGrid1.Rows.Insert(0, (object)this.매장명.Text, (object)this.마지막박스.Text, (object)this.배치번호.Text, (object)this.슈트번호.Text, (object)this.박스번호.Text, (object)this.중량.Text);
                //}));

                if (c운송장 == null || c운송장.채번여부 == false)
                {
                    //채번안됨

                    return false;
                }


                try
                {
                    출하.출하내역관리.출하박스저장();

                    if (시리얼포트.IsOpen == false)
                    {
                        //시리얼포트 안열림
                        return false;
                    }

                    string barcodeScript2 = 출하.출하내역관리.바코드출력(s배치번호, s슈트번호, s박스번호, s중량, c운송장, row);
                    //.GetBarcodeScript2(s배치번호, s슈트번호, s박스번호, s중량, oWaybill, row);
                    if (string.IsNullOrEmpty(barcodeScript2))
                    {
                        //this.uMessage1.ShowMessage(uMessage.MessageType.채번실패);
                        Application.DoEvents();
                    }
                    else
                    {
                        byte[] bytes = Encoding.GetEncoding(949).GetBytes(barcodeScript2);
                        시리얼포트.Write(bytes, 0, bytes.Length);
                    }

                    int num2 = this.마지막박스.Text == GlobalClass.LAST_BOX_IDENTIFIER ? 1 : 0;

                    //DbProvider.Excute(Common.ConnectionString(), "usp_출하_박스내용_Set", 
                    //    DbProvider.GetParameter("@배치번호", (object)s실배치번호), 
                    //    DbProvider.GetParameter("@슈트번호", (object)s슈트번호), 
                    //    DbProvider.GetParameter("@박스번호", (object)s박스번호), 
                    //    DbProvider.GetParameter("@출력값1", (object)oWaybill.운송장번호), 
                    //    DbProvider.GetParameter("@출력값2", (object)oWaybill.출력값2), 
                    //    DbProvider.GetParameter("@출력값3", (object)oWaybill.출력값1),
                    //    DbProvider.GetParameter("@출력값4", (object)oWaybill.출력값4), 
                    //    DbProvider.GetParameter("@출력값5", (object)oWaybill.출력값3), 
                    //    DbProvider.GetParameter("@출력값6", (object)string.Empty),
                    //    DbProvider.GetParameter("@출력값7", (object)string.Empty), 
                    //    DbProvider.GetParameter("@출력값8", (object)string.Empty), 
                    //    DbProvider.GetParameter("@출력값9", (object)string.Empty), 
                    //    DbProvider.GetParameter("@출력값10", (object)string.Empty),
                    //    DbProvider.GetParameter("@중량", (object)s중량), 
                    //    DbProvider.GetParameter("@운송장출력", (object)"1"), 
                    //    DbProvider.GetParameter("@거래명세서", (object)"1"));

                    //if (this.serialPort1.IsOpen)
                    //{
                    //    string barcodeScript2 = Common.GetBarcodeScript2(s배치번호, s슈트번호, s박스번호, s중량, oWaybill, row);
                    //    if (string.IsNullOrEmpty(barcodeScript2))
                    //    {
                    //        this.uMessage1.Invoke(new Action(() =>
                    //        {
                    //            this.uMessage1.ShowMessage(uMessage.MessageType.채번실패);
                    //            Application.DoEvents();
                    //        }));
                    //    }
                    //    else
                    //    {
                    //        byte[] bytes = Encoding.GetEncoding(949).GetBytes(barcodeScript2);
                    //        this.serialPort1.Write(bytes, 0, bytes.Length);
                    //    }
                    //}

                    //int num2 = this.마지막박스.Text == Common.LAST_BOX_IDENTIFIER ? 1 : 0;
                }
                catch (Exception ex)
                {
                    //Common.Log((object)"[SMP9006]", (object)ex.Message);
                    //Common.Log((object)"[SMP9101]", (object)s바코드, (object)s배치번호, (object)s슈트번호, (object)s박스번호, (object)oWaybill.운송장번호, (object)oWaybill.출력값2, (object)oWaybill.출력값1, (object)oWaybill.출력값4, (object)oWaybill.출력값3, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)s중량, (object)str1);
                }

            }

            //Common.History((object)s바코드, (object)s중량);
            //this.smpCheckBox1.Invoke(new Action(() => this.smpCheckBox1.Checked = false));

            return true;
        }

        private void ControlInit()
        {
            박스바코드.Text = string.Empty;
            중량.Text = string.Empty;
            매장명.Text = string.Empty;
            배송사.Text = string.Empty;
            배치번호.Text = string.Empty;
            슈트번호.Text = string.Empty;
            박스번호.Text = string.Empty;
            내품수.Text = string.Empty;
            마지막박스.Text = string.Empty;
            운송장번호.Text = string.Empty;

            //this.uMessage1.HideMessage();
        }

        private bool IsValidWeight(List<string> sList, bool 중량무시여부)
        {
            bool result = false;

            if (sList[sList.Count - 1].ToUpper() != "KG")
            {
                result = true;
            }

            double weight = (double)0;

            if (ConvertUtil.ObjectToDouble(sList[sList.Count - 2], out weight) == false && result == false)
            {
                if (sList[sList.Count - 2].Trim() == string.Empty)
                {
                    if (중량무시여부)
                    {
                        sList[sList.Count - 2] = "100";
                        result = false;
                    }
                    else
                        result = true;
                }
                else
                    result = true;
            }
            else if (weight <= (double)0) //중량이 있으면
            {
                if (중량무시여부)
                {
                    sList[sList.Count - 2] = "100";
                    result = false;
                }
                else
                    result = true;
            }
            return result;
        }

        #endregion

        #region 버튼이벤트

        private void 미발행대상버튼_Click(object sender, EventArgs e)
        {
            //팝업창띄우기

        }

        private void 다시시작버튼_Click(object sender, EventArgs e)
        {
            //시리얼 포트 재시작 으로 보임
            Refresh_시리얼포트();
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (timer출하상태확인 != null) timer출하상태확인.Stop(); //안해도 될거 같은데 그냥 함.. 해당 폼만 닫힐 경우 대비
        }
    }
}
