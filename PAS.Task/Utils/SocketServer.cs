using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PAS.Task
{
    public class SocketServer : SocketBase
    {
        private Socket m_oServerListener;
        private Socket m_oInitClinet;
        private ArrayList m_olstEventArgs = new ArrayList();

        public Socket InitClient
        {
            get => this.m_oInitClinet;
            set => this.m_oInitClinet = value;
        }

        public int ConnectedCount => 0;

        public string[] ConnectedIP => new List<string>().ToArray();

        public event SocketBase.LogEvent Log;

        public event SocketBase.ReceivingEvent Receiving;

        public event SocketBase.AcceptEvent Accept;

        public SocketServer()
        {
        }

        public SocketServer(string sIP) => this.IP = sIP;

        public SocketServer(string sIP, int iPort)
        {
            this.IP = sIP;
            this.Port = this.Port;
        }

        private void SendLogMessage(string sMessage)
        {
            if (this.Log == null)
                return;
            this.Log((object)this, sMessage);
        }

        private void SendLogMessage(Exception ex)
        {
            string empty = string.Empty;
            string sMessage = "Message : " + ex.Message + "\r\n" + "Helplink : " + ex.HelpLink + "r\r\n" + "Source : " + ex.Source + "\r\n" + "StackTrace : " + ex.StackTrace + "\r\n" + "TargetSite + " + ex.TargetSite.ToString() + "\r\n";
            foreach (DictionaryEntry dictionaryEntry in ex.Data)
                sMessage = sMessage + dictionaryEntry.Key.ToString() + " ==> " + dictionaryEntry.Value.ToString();
            this.SendLogMessage(sMessage);
        }

        public void Start() => this.Start(0);

        public void Start(int account)
        {
            try
            {
                this.m_oServerListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this.m_oServerListener.Bind(!(this.IP.Trim() == string.Empty) ? (EndPoint)new IPEndPoint(IPAddress.Parse(this.IP), this.Port) : (EndPoint)new IPEndPoint(IPAddress.Any, this.Port));
                this.m_oServerListener.Listen(account);
                this.SendLogMessage("Server is Started!!");
                this.m_oServerListener.BeginAccept(new AsyncCallback(this.OnAccept), (object)this.m_oServerListener);
            }
            catch (Exception ex)
            {
                ex.ToString();
                this.SendLogMessage("[Start][" + ex.GetHashCode().ToString() + ex.Message);
            }
        }

        public void Stop()
        {
            try
            {
                foreach (SocketObject olstEventArg in this.m_olstEventArgs)
                {
                    if (olstEventArg.Client != null && olstEventArg.Client.Connected)
                        olstEventArg.Client.Close();
                }
                if (this.m_oServerListener != null)
                    this.m_oServerListener.Close();
                this.m_olstEventArgs.Clear();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                this.SendLogMessage("Server is Stopped!!");
            }
            catch (Exception ex)
            {
                ex.ToString();
                this.SendLogMessage("[Stop][" + ex.GetHashCode().ToString() + ex.Message);
            }
        }

        private void OnAccept(IAsyncResult ar)
        {
            Socket state = (Socket)null;
            Socket oClient = (Socket)null;
            try
            {
                state = (Socket)ar.AsyncState;
                oClient = state.EndAccept(ar);
                if (oClient == null || !oClient.Connected)
                    return;
                string str = ((IPEndPoint)oClient.RemoteEndPoint).Address.ToString();
                this.InitClient = oClient;
                this.SendLogMessage("[" + str + "] is Connected!");
                if (this.Accept != null)
                    this.Accept();
                new SocketObject(oClient).ReceiveCallback(this);
                state.BeginAccept(new AsyncCallback(this.OnAccept), (object)state);
            }
            catch (Exception ex)
            {
                ex.ToString();
                this.SendLogMessage(ex.Message);
                state?.Close();
                oClient?.Close();
            }
        }

        public void Send(object sender, string sData)
        {
            this.Send(sender, Encoding.UTF8.GetBytes(sData));
        }

        public void Send(object sender, byte[] yBuffer)
        {
            SocketObject socketObject = (SocketObject)sender;
            if (socketObject.Client == null || yBuffer == null || yBuffer.Length <= 0)
                return;
            socketObject.SendCallback(yBuffer, this);
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                SocketObject asyncState = (SocketObject)ar.AsyncState;
                if (asyncState.Client.EndSend(ar) >= 1)
                    return;
                ((IPEndPoint)asyncState.Client.RemoteEndPoint).Address.ToString();
                asyncState.Client.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
                this.SendLogMessage("[OnSend][" + ex.GetHashCode().ToString() + "]" + ex.Message);
            }
        }

        public void OnReceive(IAsyncResult ar)
        {
            SocketObject asyncState = (SocketObject)ar.AsyncState;
            try
            {
                byte[] receiveData = asyncState.GetReceiveData(ar);
                if (receiveData != null)
                {
                    if (receiveData.Length < 1)
                    {
                        ((IPEndPoint)asyncState.Client.RemoteEndPoint).Address.ToString();
                        asyncState.Client.Close();
                    }
                    else
                    {
                        try
                        {
                            if (this.Receiving != null)
                                this.Receiving((object)asyncState, receiveData);
                        }
                        catch (Exception ex)
                        {
                            ex.ToString();
                            asyncState.Client.Close();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            this.SendLogMessage("[" + ex.GetHashCode().ToString() + "] [1] " + ex.Message);
                            return;
                        }
                    }
                }
                asyncState.ReceiveCallback(this);
            }
            catch (Exception ex)
            {
                ex.ToString();
                asyncState.Client.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                this.SendLogMessage("[" + ex.GetHashCode().ToString() + "] [2] " + ex.Message);
            }
        }
    }
}