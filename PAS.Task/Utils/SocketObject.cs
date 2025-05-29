using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace PAS.Task
{
    public class SocketObject
    {
        private Socket m_oSocketClient;
        private byte[] m_yArrBuffer = new byte[4096];
        private int m_iTotalCount;
        private List<byte> m_olstBuffer = new List<byte>();

        public Socket Client
        {
            get => this.m_oSocketClient;
            set => this.m_oSocketClient = value;
        }

        public int TotalCount
        {
            get => this.m_iTotalCount;
            set => this.m_iTotalCount = value;
        }

        public byte[] Buffer => this.m_olstBuffer.ToArray();

        public SocketObject(Socket oClient) => this.m_oSocketClient = oClient;

        public void ReceiveCallback(SocketServer oListener)
        {
            try
            {
                this.m_oSocketClient.BeginReceive(this.m_yArrBuffer, 0, this.m_yArrBuffer.Length, SocketFlags.None, new AsyncCallback(oListener.OnReceive), (object)this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void SendCallback(byte[] yBuffer, SocketServer oListener)
        {
            try
            {
                this.m_oSocketClient.BeginSend(yBuffer, 0, yBuffer.Length, SocketFlags.None, new AsyncCallback(oListener.OnSend), (object)this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public byte[] GetReceiveData(IAsyncResult ar)
        {
            int length = 0;
            try
            {
                length = this.m_oSocketClient.EndReceive(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            byte[] destinationArray = new byte[length];
            Array.Copy((Array)this.m_yArrBuffer, (Array)destinationArray, length);
            return destinationArray;
        }

        public void AddBuffer(byte[] yArrBuffer)
        {
            if (yArrBuffer == null)
                return;
            this.m_olstBuffer.AddRange((IEnumerable<byte>)yArrBuffer);
        }

        public void ClearBuffer() => this.m_olstBuffer.Clear();
    }
}