using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TR_Common;
//using TR_Common;

namespace PAS.Task
{
    internal class GlobalClass
    {
        public static string PasDBConnectionString
        {
            get { return $"Data Source={GlobalClass.PAS_DB_IP};Initial Catalog={GlobalClass.PAS_DB_SERVICE};Persist Security Info=True;User ID={GlobalClass.PAS_DB_ID};Password={GlobalClass.PAS_DB_PASSWORD}"; }
        }

        public static string HostDBConnectionString
        {
            get { return $"Data Source={GlobalClass.HOST_DB_IP};Initial Catalog={GlobalClass.HOST_DB_SERVICE};Persist Security Info=True;User ID={GlobalClass.HOST_DB_ID};Password={GlobalClass.HOST_DB_PASSWORD}"; }
        }

        public static Dictionary<string, DataRow> DicPas기기 = new Dictionary<string, DataRow>();

        public static string PATH_STARTUP { get => Application.StartupPath; }

        public static string PAS_DB_IP { get; set; }
        public static string PAS_DB_SERVICE { get; set; }
        public static string PAS_DB_ID { get; set; }
        public static string PAS_DB_PASSWORD { get; set; }
        public static string HOST_DB_IP { get; private set; }
        public static string HOST_DB_SERVICE { get; private set; }
        public static string HOST_DB_ID { get; private set; }
        public static string HOST_DB_PASSWORD { get; private set; }
        public static string NAME { get; private set; }
        public static string SEIGYO_IP { get; private set; }
        public static string SEIGYO_PORT { get; private set; }
        public static string CHUTES { get; private set; }
        public static string CHUTES_ERROR { get; private set; }
        public static string CHUTES_OVERFLOW { get; private set; }
        public static string LOCAL_FOLDER { get; private set; }
        public static string SEIGYO_FOLDER { get; private set; }
        public static string SEIGYO_ID { get; private set; }
        public static string SEIGYO_PASSWORD { get; private set; }
        public static string PAS_DURATION { get; private set; }
        public static string INDICATOR_DURATION { get; private set; }
        public static string INDICATOR_IP { get; private set; }
        public static string INDICATOR_PORT { get; private set; }
        public static string INDICATOR_STRUCTURE { get; private set; }
        public static string BARCODE_PRINTER_LIST { get; private set; }
        public static string PRINTER_LIST { get; private set; }


        public static void InitializationSettings()
        {
            PAS_DB_IP = "112.216.239.253,4222";
            PAS_DB_SERVICE = "PASOP";
            PAS_DB_ID = "pasuser";
            PAS_DB_PASSWORD = "paspass";

            try
            {
                DataTable dt = 공통.접속정보(PasDBConnectionString);

                foreach (DataRow row in dt.Rows)
                {
                    DataRow saveRow = dt.NewRow();
                    saveRow.ItemArray = row.ItemArray;
                    DicPas기기.Add(row["NAME"].ToString(), saveRow);
                }

                SettingsPas기기("PAS01");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static bool SettingsPas기기(string key)
        {
            if (DicPas기기.ContainsKey(key) == false) return false;

            DataRow row = DicPas기기[key];

            NAME = row["NAME"].ToString();
            SEIGYO_IP = row["SEIGYO_IP"].ToString();
            SEIGYO_PORT = row["SEIGYO_PORT"].ToString();
            CHUTES = row["CHUTES"].ToString();
            CHUTES_ERROR = row["CHUTES_ERROR"].ToString();
            CHUTES_OVERFLOW = row["CHUTES_OVERFLOW"].ToString();
            LOCAL_FOLDER = row["LOCAL_FOLDER"].ToString();
            SEIGYO_FOLDER = row["SEIGYO_FOLDER"].ToString();
            SEIGYO_ID = row["SEIGYO_ID"].ToString();
            SEIGYO_PASSWORD = row["SEIGYO_PASSWORD"].ToString();
            PAS_DURATION = row["PAS_DURATION"].ToString();
            INDICATOR_DURATION = row["INDICATOR_DURATION"].ToString();
            INDICATOR_IP = row["INDICATOR_IP"].ToString();
            INDICATOR_PORT = row["INDICATOR_PORT"].ToString();
            INDICATOR_STRUCTURE = row["INDICATOR_STRUCTURE"].ToString();

            PAS_DB_IP = row["PAS_DB_IP"].ToString();
            PAS_DB_SERVICE = row["PAS_DB_SERVICE"].ToString();
            PAS_DB_ID = row["PAS_DB_ID"].ToString();
            PAS_DB_PASSWORD = row["PAS_DB_PASSWORD"].ToString();
            HOST_DB_IP = row["HOST_DB_IP"].ToString();
            HOST_DB_SERVICE = row["HOST_DB_SERVICE"].ToString();
            HOST_DB_ID = row["HOST_DB_ID"].ToString();
            HOST_DB_PASSWORD = row["HOST_DB_PASSWORD"].ToString();

            BARCODE_PRINTER_LIST = row["BARCODE_PRINTER_LIST"].ToString();
            PRINTER_LIST = row["PRINTER_LIST"].ToString();

            return true;
        }
    }
}