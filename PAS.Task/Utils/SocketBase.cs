using System.Collections.Generic;

namespace PAS.Task
{
    public class SocketBase
    {
        public const int MAX_BUFFER = 4096;
        private string m_strIP = "127.0.0.1";
        private int m_iPort = 23;
        private List<string> m_olstFilter = new List<string>();

        public string IP
        {
            get => this.m_strIP;
            set => this.m_strIP = value;
        }

        public int Port
        {
            get => this.m_iPort;
            set => this.m_iPort = value;
        }

        public void FilterAdd(string strIP)
        {
            if (this.m_olstFilter == null)
                this.m_olstFilter = new List<string>();
            this.m_olstFilter.Add(strIP);
        }

        public void FilterAddRange(string[] strArrIP)
        {
            if (this.m_olstFilter == null)
                this.m_olstFilter = new List<string>();
            this.m_olstFilter.AddRange((IEnumerable<string>)strArrIP);
        }

        public void FilterClear()
        {
            if (this.m_olstFilter == null)
                return;
            this.m_olstFilter.Clear();
        }

        public void FilterRemoveAt(string strIP)
        {
            if (this.m_olstFilter == null)
                return;
            this.m_olstFilter.Remove(strIP);
        }

        public string[] GetFilters()
        {
            return this.m_olstFilter == null || this.m_olstFilter.Count <= 0 ? (string[])null : this.m_olstFilter.ToArray();
        }

        public delegate void LogEvent(object sender, string strMessage);

        public delegate void ReceivingEvent(object sender, byte[] yBuffer);

        public delegate void AcceptEvent();
    }
}
