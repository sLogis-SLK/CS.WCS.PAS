namespace PAS.Task
{
    public class DatabaseArgs
    {
        private string m_sBatchNo = string.Empty;
        private string m_sMark = string.Empty;
        private string m_sLineNo = string.Empty;
        private string m_sGateNo = string.Empty;
        private string m_sDate = string.Empty;
        private string m_sTime = string.Empty;
        private string m_sMajorCode = string.Empty;
        private string m_sChuteNo = string.Empty;
        private string m_sCaseNo = string.Empty;
        private string m_sResultCode = string.Empty;
        private string m_sCount = string.Empty;
        private string m_sMinorCode = string.Empty;
        private string m_sPLCCode = string.Empty;
        private string m_sFilter = string.Empty;
        private string m_sLf = "\n";
        //private MarkType m_eMark = MarkType.S;
        private string m_sRowData = string.Empty;

        public string BatchNo
        {
            get => this.m_sBatchNo;
            set => this.m_sBatchNo = value;
        }

        public string RowData
        {
            get => this.m_sRowData;
            set => this.m_sRowData = value;
        }

        public string Mark
        {
            get => this.m_sMark;
            set => this.m_sMark = GetEmptyString(value, 1);
        }

        //public MarkType Type
        //{
        //    get
        //    {
        //        try
        //        {
        //            this.m_eMark = (MarkType)Enum.Parse(typeof(MarkType), this.m_sMark);
        //        }
        //        catch
        //        {
        //            this.m_eMark = MarkType.N;
        //        }
        //        return this.m_eMark;
        //    }
        //}

        public string LineNo
        {
            get => this.m_sLineNo;
            set => this.m_sLineNo = GetEmptyString(value, 1);
        }

        public string GateNo
        {
            get => this.m_sGateNo;
            set => this.m_sGateNo = GetEmptyString(value, 1);
        }

        public string Date
        {
            get => this.m_sDate;
            set => this.m_sDate = GetEmptyString(value, 8);
        }

        public string Time
        {
            get => this.m_sTime;
            set => this.m_sTime = GetEmptyString(value, 9);
        }

        public string MajorCode
        {
            get => this.m_sMajorCode;
            set => this.m_sMajorCode = GetEmptyString(value, 40);
        }

        public string ChuteNo
        {
            get => this.m_sChuteNo;
            set => this.m_sChuteNo = GetEmptyString(value, 3);
        }

        public string CaseNo
        {
            get => this.m_sCaseNo;
            set => this.m_sCaseNo = GetEmptyString(value, 3);
        }

        public string ResultCode
        {
            get => this.m_sResultCode;
            set => this.m_sResultCode = GetEmptyString(value, 30);
        }

        public string Count
        {
            get => this.m_sCount;
            set => this.m_sCount = GetEmptyString(value, 10);
        }

        public string MinorCode
        {
            get => this.m_sMinorCode;
            set => this.m_sMinorCode = GetEmptyString(value, 20);
        }

        public string PLCCode
        {
            get => this.m_sPLCCode;
            set => this.m_sPLCCode = GetEmptyString(value, 4);
        }

        public string Filter
        {
            get => this.m_sFilter;
            set => this.m_sFilter = GetEmptyString(value, 19);
        }

        public string LF => this.m_sLf;

        public DatabaseArgs()
        {
            this.m_sMark = GetEmptyString(string.Empty, 1);
            this.m_sLineNo = GetEmptyString(string.Empty, 1);
            this.m_sGateNo = GetEmptyString(string.Empty, 1);
            this.m_sDate = GetEmptyString(string.Empty, 8);
            this.m_sTime = GetEmptyString(string.Empty, 9);
            this.m_sMajorCode = GetEmptyString(string.Empty, 40);
            this.m_sChuteNo = GetEmptyString(string.Empty, 3);
            this.m_sCaseNo = GetEmptyString(string.Empty, 3);
            this.m_sResultCode = GetEmptyString(string.Empty, 30);
            this.m_sCount = GetEmptyString(string.Empty, 10);
            this.m_sMinorCode = GetEmptyString(string.Empty, 20);
            this.m_sPLCCode = GetEmptyString(string.Empty, 4);
            this.m_sFilter = GetEmptyString(string.Empty, 19);
            this.m_sBatchNo = string.Empty;
            this.m_sRowData = string.Empty;
        }

        public DatabaseArgs(
          string sMark,
          string sLineNo,
          string sGateNo,
          string sDate,
          string sTime,
          string sMajorCode,
          string sChuteNo,
          string sCaseNo,
          string sResultCode,
          string sCount,
          string sMinorCode,
          string sPLCCode,
          string sFilter,
          string sBatchNo,
          string sRowData)
        {
            this.m_sMark = GetEmptyString(sMark, 1);
            this.m_sLineNo = GetEmptyString(sLineNo, 1);
            this.m_sGateNo = GetEmptyString(sGateNo, 1);
            this.m_sDate = GetEmptyString(sDate, 8);
            this.m_sTime = GetEmptyString(sTime, 9);
            this.m_sMajorCode = GetEmptyString(sMajorCode, 40);
            this.m_sChuteNo = GetEmptyString(sChuteNo, 3);
            this.m_sCaseNo = GetEmptyString(sCaseNo, 3);
            this.m_sResultCode = GetEmptyString(sResultCode, 30);
            this.m_sCount = GetEmptyString(sCount, 10);
            this.m_sMinorCode = GetEmptyString(sMinorCode, 20);
            this.m_sPLCCode = GetEmptyString(sPLCCode, 4);
            this.m_sFilter = GetEmptyString(sFilter, 19);
            this.m_sBatchNo = sBatchNo;
            this.m_sRowData = sRowData;
        }

        public string GetEmptyString(string s, int iCapacity)
        {
            return string.Format("{0,-" + (object)iCapacity + "}", (object)s).Substring(0, iCapacity);
        }
    }
}
