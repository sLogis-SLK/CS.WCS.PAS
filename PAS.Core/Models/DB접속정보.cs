using System;
using System.Data;

namespace PAS.Core
{
    public class DB접속정보 : PASDB접속정보
    {
        public string HOST_DB_IP { get; set; }
        public string HOST_DB_SERVICE { get; set; }
        public string HOST_DB_ID { get; set; }
        public string HOST_DB_PASSWORD { get; set; }

        internal void SetDataRow(DataRow row)
        {
            PAS_DB_IP = row["PAS_DB_IP"].ToString();
            PAS_DB_SERVICE = row["PAS_DB_SERVICE"].ToString();
            PAS_DB_ID = row["PAS_DB_ID"].ToString();
            PAS_DB_PASSWORD = row["PAS_DB_PASSWORD"].ToString();
            HOST_DB_ID = row["HOST_DB_ID"].ToString();
            HOST_DB_SERVICE = row["HOST_DB_SERVICE"].ToString();
            HOST_DB_ID = row["HOST_DB_ID"].ToString();
            HOST_DB_PASSWORD = row["HOST_DB_PASSWORD"].ToString();
        }
    }

    public class PASDB접속정보
    {
        public string PAS_DB_IP { get; set; }
        public string PAS_DB_SERVICE { get; set; }
        public string PAS_DB_ID { get; set; }
        public string PAS_DB_PASSWORD { get; set; }
    }
}
