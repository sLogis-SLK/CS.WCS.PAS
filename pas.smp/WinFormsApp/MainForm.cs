using Infragistics.Win.UltraWinGrid;
using PAS.Core;
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
using TR_Provider;

namespace PAS.SMP
{
    public partial class MainForm : Form
    {
        #region 개체선언부
        //private List<KeyValuePair<string, string>> items;

        private System.Timers.Timer timer출하상태확인 = new System.Timers.Timer();
        private System.Timers.Timer timer출하박스확인 = new System.Timers.Timer();

        private DataTable m_출하상태Table = new DataTable("usp_출하_상태확인_Get");
        private DataTable m_출하박스내역Table = new DataTable("usp_출하_박스내용_Get");

        private BindingSource m_출하상태BS = new BindingSource();
        private BindingSource m_출하박스내역BS = new BindingSource();

        //Socket 통신용
        private Socket socket;

        #endregion

        #region 컨트롤-인덱스

        private string m박스바코드
        {
            get => 박스바코드.Text == null ? string.Empty : 박스바코드.Text;
        }

        private bool m재발행
        {
            get => 재발행_Check.Checked;
        }

        private bool m중량무시
        {
            get => 중량무시_Check.Checked;
        }

        private bool 시작여부
        {
            get => ultraButton1.Text == "시작" ? true : false;
            set
            {
                if (value)
                {
                    ultraButton1.Text = "시작";
                }
                else
                {
                    ultraButton1.Text = "동작중";
                }
                comboBox1.Enabled = value;
            }
        }

        #endregion

        #region 초기화

        public MainForm()
        {
            InitializeComponent();

            ControlInit();
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (DesignMode) return; //디자인모드일때 아래 부분 적용안되게 함.

            //구초기화..
            GlobalClass.GetSetting();
            GlobalClass.IsLog = true;

            //최초 초기화 및 정보 가져오기
            GlobalClass.InitializationSettings();

            //PAS기기콤보 세팅
            foreach (var item in GlobalClass.Dic출하기기)
            {
                comboBox1.Items.Add(item.Key);
            }
            comboBox1.SelectedItem = GlobalClass.DefaultValue출하라인;
            if (comboBox1.SelectedItem != null)
            {
                if (GlobalClass.Settings출하기기(GlobalClass.DefaultValue출하라인)) //DefaultValue출하라인 세팅
                {
                    //성공
                }
                else
                {
                    //실패
                }
            }

            //이벤트모음
            timer출하상태확인.Elapsed += Timer출하상태확인_Tick;
            timer출하박스확인.Elapsed += Timer출하박스확인_Tick;

            미발행대상버튼.Click += new System.EventHandler(this.미발행대상버튼_Click);
            다시시작버튼.Click += new System.EventHandler(this.다시시작버튼_Click);
            설정버튼.Click += new System.EventHandler(this.설정버튼_Click);
            종료버튼.Click += new System.EventHandler(this.종료버튼_Click);

            그리드초기화();

            ////timer 초기 세팅값
            //timer출하상태확인.Interval = 2000; //2초
            //timer출하상태확인.Start();  //시작

            //Refresh시리얼포트();
        }

        private void ControlInit()
        {
            this.박스바코드.Text = string.Empty;
            this.중량.Text = string.Empty;
            this.매장명.Text = string.Empty;
            this.배송사.Text = string.Empty;
            this.배치번호.Text = string.Empty;
            this.슈트번호.Text = string.Empty;
            this.박스번호.Text = string.Empty;
            this.내품수.Text = string.Empty;
            this.마지막박스.Text = string.Empty;
            this.운송장번호.Text = string.Empty;
            this.uMessage1.HideMessage();
        }

        #endregion

        #region Tick

        private void Timer출하상태확인_Tick(object sender, EventArgs e)
        {
            //DB에서 갱신해서 값 가지고 오기
            출하.출하내역관리.출하상태확인(m_출하상태Table, true);
        }

        private void Timer출하박스확인_Tick(object sender, EventArgs e)
        {
            timer출하박스확인.Stop();  //종료

            DateTime dateTime = DateTime.Now;
            this.Invoke(new Action(() =>{현시간.Text = dateTime.ToString("G");}));

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
                
                출하.출하내역관리.출하상태확인(m_출하상태Table, false);
                
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


                m_출하박스내역Table = 출하.출하내역관리.출하박스이력();

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

        private void Refresh시리얼포트()
        {
            //시리얼포트 갱신 및 박스체크 쓰레드 동작
            //return;
            //string value = comboBox1.SelectedValue.ToString();
            try
            {
                시리얼포트.Close();
                시리얼포트.PortName = GlobalClass.출하라인설정.COM_NAME;
                시리얼포트.BaudRate = Convert.ToInt32(GlobalClass.출하라인설정.COM_BAUDRATE);
                시리얼포트.Open();
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[Refresh시리얼포트]", (object)ex.Message);
            }

            //쓰레드 다시 동작
            timer출하박스확인.Stop();//종료
            timer출하박스확인.Interval = 100; //0.1초
            timer출하박스확인.Start();//시작
        }

        private bool Disconnection()
        {
            try
            {
                Thread.Sleep(1000);
                if (this.socket != null)
                {
                    this.socket.Close();
                    this.socket = (Socket)null;
                }
                return true;
            }
            catch (SocketException ex)
            {
                LogUtil.Log((object)"[Disconnection]", (object)ex.Message);
            }
            return false;
        }

        private bool Connection()
        {
            try
            {
                if (!this.Disconnection())
                    return false;
                this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.socket.Connect(GlobalClass.출하라인설정.PLC_IP, Convert.ToInt32(GlobalClass.출하라인설정.PLC_PORT));
                return true;
            }
            catch (SocketException ex)
            {
                LogUtil.Log((object)"[Connection]", (object)ex.Message);
            }
            return false;
        }

        private bool 출하박스정보Receive()
        {
            try
            {
                byte[] numArray1 = new byte[4096];

                //if (this.socket != null)
                //{
                //    this.socket.Close();
                //    this.socket = (Socket)null;
                //}

                //if (this.socket == null)
                //{
                //    //PLC통신용 Socket 
                //    this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //    this.socket.Connect(GlobalClass.Setting.PLC_IP, Convert.ToInt32(GlobalClass.Setting.PLC_PORT));
                //}

                if (!this.Connection())
                {
                    return false;
                }

                //this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //this.socket.Connect(GlobalClass.Setting.PLC_IP, Convert.ToInt32(GlobalClass.Setting.PLC_PORT));

                this.socket.Send(GlobalClass.GetBufferBybyte);

                //수신시작
                IAsyncResult asyncResult = socket.BeginReceive(numArray1, 0, numArray1.Length, SocketFlags.None, (AsyncCallback)null, (object)null);
                //응답대기 10초
                if (asyncResult.AsyncWaitHandle.WaitOne(10000, false) == false)
                {
                    //타임아웃
                    return true; 
                }

                //실 데이터 수신
                int socketCnt = socket.EndReceive(asyncResult);
                if (socketCnt <= 0)
                {
                    //연결종료 에러 발생
                    return true;
                }
                //
                byte[] numArray2 = new byte[socketCnt];
                Buffer.BlockCopy((Array)numArray1, 0, (Array)numArray2, 0, socketCnt);

                if (numArray2[numArray2.Length - 2] == (byte)107 && numArray2[numArray2.Length - 1] == (byte)103)
                {
                    byte[] numArray3 = new byte[numArray2.Length - 31];
                    Buffer.BlockCopy((Array)numArray2, 31, (Array)numArray3, 0, numArray2.Length - 31);
                    string str1 = new string(numArray3.Select(b => (char)b).ToArray());

                    string[] strArray = str1.Split(new string[1] { " " }, StringSplitOptions.None);
                    List<string> sList = new List<string>();
                    for (int index = 0; index < strArray.Length; ++index)
                    {
                        if (strArray[index].Trim() != string.Empty)
                            sList.Add(strArray[index]);
                    }
                    if (sList.Count >= 7)
                    {
                        체크후화면에출력(sList);
                    }
                    else
                    {
                        LogUtil.Log((object)"[수신 데이터 오류]");
                    }
                }
            }
            catch (SocketException ex)
            {
                LogUtil.Log((object)"[Socket통신 실패]", (object)ex.Message, (object)ex.ErrorCode, (object)ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[출하박스정보Receive 실패]", (object)ex.Message);
            }
            finally
            {
                this.Disconnection();
            }
            return true;
        }

        private bool 체크후화면에출력(List<string> sList)
        {
            string s바코드 = string.Empty;
            string s슈트번호 = string.Empty;
            string s박스번호 = string.Empty;
            string s중량 = string.Empty;

            //박스바코드랑 같으면 동일한 정보이기에 PASS
            if (m박스바코드 == sList[0].Trim())
            {
                return true;
            }

            this.Invoke(new Action(() => this.ControlInit()));

            #region IsValidWeight
            /* 
            *  true 일경우 실행
            *  false 이면 Pass
            */
            bool result = true;

            //단위 KG 이 아닌경우
            if (sList[sList.Count - 1].ToUpper() != "KG")
            {
                result = false;
            }

            double weight;
            bool isDouble = ConvertUtil.ObjectToDouble(sList[sList.Count - 2], out weight);

            if (isDouble == false && result == false)//숫자아닌형태로 들어오고, 단위가 KG 이 아니면??
            {
                result = false;
            }
            else if (weight <= (double)0) //중량이 없으면
            {
                result = false;
            }

            //중량등이 안넘어와 있을때 중량 무시인경우 - 기본값 주고 실행하도록 함.
            if (result && m중량무시)
            {
                sList[sList.Count - 2] = "100";//중량무시일경우
                result = true;
            }
            #endregion

            this.중량무시_Check.Invoke(new Action(() => this.중량무시_Check.Checked = false));

            if (result)
            {
                s바코드 = sList[0];
                s슈트번호 = sList[0].Substring(8, 3);
                s박스번호 = sList[0].Substring(11, 3);

                //lstTemp[0].Substring(14, 1); //??

                s중량 = sList[5] + sList[6];
                s중량 = s중량.Replace("U", string.Empty);
                s중량 = s중량.Replace("u", string.Empty);
                
                string s배치번호 = sList[0].Substring(0, 8);

                return 화면에박스정보출력(s바코드, s슈트번호, s박스번호, s중량, s배치번호);
            }
            else
            {
                LogUtil.Log((object)"[SMP0001]");
            }

            return result;
        }

        private bool 화면에박스정보출력(string s바코드, string s슈트번호, string s박스번호, string s중량, string s배치번호)
        {
            string s실배치번호 = string.Empty;
            string s마지막박스 = string.Empty;
            string s배송사명 = string.Empty;
            string s매장명 = string.Empty;
            string s내품수 = string.Empty;

            //컨트롤초기화
            //데이터세팅(string.Empty, string.Empty, s매장명, s배송사명, s실배치번호, string.Empty, string.Empty, s내품수, s마지막박스, string.Empty);
            데이터세팅(s바코드, s중량, s매장명, s배송사명, s실배치번호, s슈트번호, s박스번호, s내품수, s마지막박스, string.Empty);

            //데이터 가져오기
            DataTable dt = new DataTable();

            //m_출하박스내역Table.Clear();
            출하.출하내역관리.출하박스내역(dt, s바코드);

            if (dt == null || dt.Rows.Count <= 0)
            {
                this.uMessage1.Invoke(new Action(() =>
                {
                    this.uMessage1.ShowMessage(uMessage.MessageType.발행대상없음);
                    Application.DoEvents();
                }));
                return false;
            }

            DataRow row = dt.Rows[0];
            if (row == null)
            {
                return false;
            }
            if (row["운송장출력여부"].ToString() == "1" && m재발행 == false)
            {
                this.uMessage1.Invoke(new Action(() =>
                {
                    this.uMessage1.ShowMessage(uMessage.MessageType.재발행);
                    Application.DoEvents();
                }));
            }

            string sB코드 = row["브랜드코드"].ToString();
            //row["브랜드명"].ToString();
            string s센터코드 = row["센터코드"].ToString();
            string s배송사코드 = row["배송사코드"].ToString();
            s배송사명 = row["배송사명"].ToString();
            string s점코드 = row["점코드"].ToString();
            s매장명 = row["점명"].ToString();
            s내품수 = row["내품수"].ToString();
            //row["점주소"].ToString();
            //row["점전화번호1"].ToString();
            s마지막박스 = row["마지막박스여부"].ToString() == "1" ? GlobalClass.LAST_BOX_IDENTIFIER : string.Empty;
            s실배치번호 = row["실배치번호"].ToString();
            string str2 = row["출력값1"].ToString();
            string str3 = row["출력값2"].ToString();
            string str4 = row["출력값3"].ToString();
            string str5 = row["출력값4"].ToString();
            string str6 = row["출력값5"].ToString();
            //row["출력값6"].ToString();
            //row["출력값7"].ToString();
            //row["출력값8"].ToString();
            //row["출력값9"].ToString();
            //row["출력값10"].ToString();
            if (row["배송사코드"].ToString() == string.Empty)
            {
                this.uMessage1.Invoke(new Action(() =>
                {
                    this.uMessage1.ShowMessage(uMessage.MessageType.배송사없음);
                    Application.DoEvents();
                }));
                return false;
            }

            운송장채번Model c운송장 = null;
            //출력값이 없다고 판단되면 배송사 채번
            if (string.IsNullOrEmpty(str2))
            {
                c운송장 = 채번.운송장채번(GlobalClass.출하라인설정.URL, "PAS", "9650", s센터코드, sB코드, s배송사코드, s점코드);
                //c운송장 = new 운송장채번Model();
            }
            //출력값이 있다고 판단되면 기존 출력값을 사용하여 출력
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
                this.uMessage1.Invoke(new Action(() =>
                {
                    this.uMessage1.ShowMessage(uMessage.MessageType.채번실패);
                    Application.DoEvents();
                }));
                return false;
            }

            데이터세팅(s바코드, s중량, s매장명, s배송사명, s실배치번호, s슈트번호, s박스번호, s내품수, s마지막박스, c운송장.운송장번호);

            //그리드에 추가하고, 20개 까지만 화면에 표시한다.
            this.uGrid1.Invoke(new Action(() =>
            {
                if (m_출하박스내역Table.Rows.Count >= 20)
                    m_출하박스내역Table.Rows.RemoveAt(m_출하박스내역Table.Rows.Count - 1);

                DataRow newRow = m_출하박스내역Table.NewRow();
                newRow["매장명"] = this.매장명.Text;
                newRow["★"] = this.마지막박스.Text;
                newRow["배치번호"] = this.배치번호.Text;
                newRow["슈트번호"] = this.슈트번호.Text;
                newRow["박스"] = this.박스번호.Text;
                newRow["중량"] = this.중량.Text;

                // 0번째에 삽입하려면 InsertAt 사용
                m_출하박스내역Table.Rows.InsertAt(newRow, 0);
            }));

            if (c운송장 == null || c운송장.채번여부 == false)
            {
                //채번안됨

                return false;
            }

            try
            {
                출하.출하내역관리.출하박스저장(s실배치번호, s슈트번호, s박스번호, c운송장.운송장번호, c운송장.출력값2, c운송장.출력값1, c운송장.출력값4, c운송장.출력값3, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, s중량, "1", "1");

                if (시리얼포트.IsOpen == false)
                {
                    MessageBox.Show("시리얼포트 안열림");
                    //시리얼포트 안열림
                    return false;
                }

                string barcodeScript2 = 출하.출하내역관리.바코드출력(s배치번호, s슈트번호, s박스번호, s중량, c운송장, row);
                if (string.IsNullOrEmpty(barcodeScript2))
                {
                    this.uMessage1.Invoke(new Action(() =>
                    {
                        this.uMessage1.ShowMessage(uMessage.MessageType.채번실패);
                        Application.DoEvents();
                    }));
                }
                else
                {
                    byte[] bytes = Encoding.GetEncoding(949).GetBytes(barcodeScript2);
                    시리얼포트.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log((object)"[SMP9006]", (object)ex.Message);
                LogUtil.Log((object)"[SMP9101]", (object)s바코드, (object)s배치번호, (object)s슈트번호, (object)s박스번호, (object)c운송장.운송장번호, (object)c운송장.출력값2, (object)c운송장.출력값1, (object)c운송장.출력값4, (object)c운송장.출력값3, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)string.Empty, (object)s중량);
            }

            LogUtil.History((object)s바코드, (object)s중량);
            this.재발행_Check.Invoke(new Action(() => this.재발행_Check.Checked = false));

            return true;
        }

        private void 데이터세팅(string s바코드, string s중량, string s매장명, string s배송사명, string s실배치번호, string s슈트번호, string s박스번호, string s내품수, string s마지막박스, string s운송장번호)
        {
            this.박스바코드.Invoke(new Action(() => this.박스바코드.Text = s바코드));
            this.중량.Invoke(new Action(() => this.중량.Text = s중량));
            this.매장명.Invoke(new Action(() => this.매장명.Text = s매장명));
            this.배송사.Invoke(new Action(() => this.배송사.Text = s배송사명));
            this.배치번호.Invoke(new Action(() => this.배치번호.Text = s실배치번호));
            this.슈트번호.Invoke(new Action(() => this.슈트번호.Text = s슈트번호));
            this.박스번호.Invoke(new Action(() => this.박스번호.Text = s박스번호));
            this.내품수.Invoke(new Action(() => this.내품수.Text = s내품수));
            this.마지막박스.Invoke(new Action(() => this.마지막박스.Text = s마지막박스));
            this.운송장번호.Invoke(new Action(() => this.운송장번호.Text = s운송장번호));
        }

        #endregion

        #region 버튼이벤트

        private void 시작버튼_Click(object sender, EventArgs e)
        {
            if (시작여부)
            {
                string s출하기기 = comboBox1.SelectedItem.ToString();

                if (GlobalClass.Settings출하기기(s출하기기)) //기기정보 세팅
                {
                    //timer 초기 세팅값
                    timer출하상태확인.Interval = 2000; //2초
                    timer출하상태확인.Start();  //시작

                    Refresh시리얼포트();
                }
                else
                {
                    MessageBox.Show("작업시작시 오류발생하였습니다. \r\n\r\n전산팀에 문의 하여주시기 바랍니다.", this.Text);
                    return;
                }
            }
            else
            {
                //작업중시
                timer출하상태확인?.Stop();
                timer출하박스확인?.Stop();

                if (시리얼포트?.IsOpen == true)
                    시리얼포트.Close();

                //25.06.04 김동준
                //작업중시시 화면 클리어 할지 안할지는 알아서 판단...주석으로 남겨놓음
            }
            시작여부 = !시작여부;
        }

        private void 미발행대상버튼_Click(object sender, EventArgs e)
        {
            //팝업창띄우기
            Form frm = new frmSMP00004();
            frm.ShowDialog();
        }

        private void 다시시작버튼_Click(object sender, EventArgs e)
        {
            //시리얼 포트 재시작 으로 보임
            Refresh시리얼포트();
        }

        private void 설정버튼_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DB에서 직접 데이터 제어중... 변경창 만드는중...", this.Text);
            return;

            //세팅창 띄우기
            Form frm = new frmSetting();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GlobalClass.GetSetting();
                this.Refresh시리얼포트();
            }
        }

        private void 종료버튼_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 폼 및 컨트롤 이벤트

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                timer출하상태확인?.Stop();
                timer출하박스확인?.Stop();

                if (시리얼포트?.IsOpen == true)
                    시리얼포트.Close();

                //기본Default 값 저장
                string sDefault기기 = comboBox1.SelectedItem.ToString();
                GlobalClass.SaveDefaultValueToIni(string.Empty, sDefault기기);

                base.OnClosed(e);
            }
            catch (Exception ex)
            {
                LogUtil.Log("[SMP9001]", ex.Message);
            }
        }

        #endregion
    }
}
