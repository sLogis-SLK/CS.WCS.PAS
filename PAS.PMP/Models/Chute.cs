using PAS.PMP.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAS.PMP.Models
{
    public class Chute
    {
        private string m_sChuteNo = string.Empty;
        private string m_sMaxCaseCapacity = string.Empty;
        private string m_sCaseCapacity = string.Empty;
        private string m_sCaseNo = string.Empty;
        private string m_sOrder = string.Empty;
        private string m_sResult = string.Empty;
        private string m_sOption = string.Empty;
        private string m_sChuteType = string.Empty;
        private string m_sItemCount = string.Empty;
        private string m_sFilter = string.Empty;
        private string m_sBatchNo = string.Empty;

        public string BatchNo
        {
            get => this.m_sBatchNo;
            set => this.m_sBatchNo = value;
        }

        public string ChuteNo
        {
            get => this.m_sChuteNo;
            set => this.m_sChuteNo = Command.GetEmptyString(value, 3);
        }

        public string MaxCaseCapacity
        {
            get => this.m_sMaxCaseCapacity;
            set => this.m_sMaxCaseCapacity = Command.GetEmptyString(value, 4);
        }

        public string CaseCapacity
        {
            get => this.m_sCaseCapacity;
            set => this.m_sCaseCapacity = Command.GetEmptyString(value, 4);
        }

        public string CaseNo
        {
            get => this.m_sCaseNo;
            set => this.m_sCaseNo = Command.GetEmptyString(value, 2);
        }

        public string Order
        {
            get => this.m_sOrder;
            set => this.m_sOrder = Command.GetEmptyString(value, 4);
        }

        public string Result
        {
            get => this.m_sResult;
            set => this.m_sResult = Command.GetEmptyString(value, 4);
        }

        public string Option
        {
            get => this.m_sOption;
            set => this.m_sOption = Command.GetEmptyString(value, 50);
        }

        public string ChuteType
        {
            get => this.m_sChuteType;
            set => this.m_sChuteType = Command.GetEmptyString(value, 2);
        }

        public string ItemCount
        {
            get => this.m_sItemCount;
            set => this.m_sItemCount = Command.GetEmptyString(value, 2);
        }

        public string Filter
        {
            get => this.m_sFilter;
            set => this.m_sFilter = Command.GetEmptyString(value, 25);
        }

        public Chute()
        {
            this.m_sChuteNo = Command.GetEmptyString(string.Empty, 3);
            this.m_sMaxCaseCapacity = Command.GetEmptyString(string.Empty, 4);
            this.m_sCaseCapacity = Command.GetEmptyString(string.Empty, 4);
            this.m_sCaseNo = Command.GetEmptyString(string.Empty, 2);
            this.m_sOrder = Command.GetEmptyString(string.Empty, 4);
            this.m_sResult = Command.GetEmptyString(string.Empty, 4);
            this.m_sOption = Command.GetEmptyString(string.Empty, 50);
            this.m_sChuteType = Command.GetEmptyString(string.Empty, 2);
            this.m_sItemCount = Command.GetEmptyString(string.Empty, 2);
            this.m_sFilter = Command.GetEmptyString(string.Empty, 25);
        }

        public Chute(
          string sChuteNo,
          string sMaxCaseCapacity,
          string sCaseCapacity,
          string sCaseNo,
          string sOrder,
          string sResult,
          string sOption,
          string sChuteType,
          string sItemCount,
          string sFilter)
        {
            this.m_sChuteNo = Command.GetEmptyString(sChuteNo, 3);
            this.m_sMaxCaseCapacity = Command.GetEmptyString(sMaxCaseCapacity, 4);
            this.m_sCaseCapacity = Command.GetEmptyString(sCaseCapacity, 4);
            this.m_sCaseNo = Command.GetEmptyString(sCaseNo, 2);
            this.m_sOrder = Command.GetEmptyString(sOrder, 4);
            this.m_sResult = Command.GetEmptyString(sResult, 4);
            this.m_sOption = Command.GetEmptyString(sOption, 50);
            this.m_sChuteType = Command.GetEmptyString(sChuteType, 2);
            this.m_sItemCount = Command.GetEmptyString(sItemCount, 2);
            this.m_sFilter = Command.GetEmptyString(sFilter, 25);
        }
    }
}
