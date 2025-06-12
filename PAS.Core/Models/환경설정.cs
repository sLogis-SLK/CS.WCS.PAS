using System;
using System.Data;
using TR_Common;

namespace PAS.Core
{
    public class PAS환경설정
    {
        public string NAME { get; set; }
        public string SEIGYO_IP { get; set; }
        public string SEIGYO_PORT { get; set; }
        public string CHUTES { get; set; }
        public string CHUTES_ERROR { get; set; }
        public string CHUTES_OVERFLOW { get; set; }
        public string LOCAL_FOLDER { get; set; }
        public string SEIGYO_FOLDER { get; set; }
        public string SEIGYO_ID { get; set; }
        public string SEIGYO_PASSWORD { get; set; }
        public int PAS_DURATION { get; set; }
        public string INDICATOR_DURATION { get; set; }
        public string INDICATOR_IP { get; set; }
        public int INDICATOR_PORT { get; set; }
        public string INDICATOR_STRUCTURE { get; set; }
        public string BARCODE_PRINTER_LIST { get; set; }
        public string PRINTER_LIST { get; set; }

        public int PrinterIndex { get; set; }

        internal void SetDataRow(DataRow row)
        {
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
            PAS_DURATION = ConvertUtil.ObjectToint(row["PAS_DURATION"]);
            INDICATOR_DURATION = row["INDICATOR_DURATION"].ToString();
            INDICATOR_IP = row["INDICATOR_IP"].ToString();
            INDICATOR_PORT = ConvertUtil.ObjectToint(row["INDICATOR_PORT"]);
            INDICATOR_STRUCTURE = row["INDICATOR_STRUCTURE"].ToString();

            //PAS_DB_IP = row["PAS_DB_IP"].ToString();
            //PAS_DB_SERVICE = row["PAS_DB_SERVICE"].ToString();
            //PAS_DB_ID = row["PAS_DB_ID"].ToString();
            //PAS_DB_PASSWORD = row["PAS_DB_PASSWORD"].ToString();
            //HOST_DB_IP = row["HOST_DB_IP"].ToString();
            //HOST_DB_SERVICE = row["HOST_DB_SERVICE"].ToString();
            //HOST_DB_ID = row["HOST_DB_ID"].ToString();
            //HOST_DB_PASSWORD = row["HOST_DB_PASSWORD"].ToString();

            BARCODE_PRINTER_LIST = row["BARCODE_PRINTER_LIST"].ToString();
            PRINTER_LIST = row["PRINTER_LIST"].ToString();
            PrinterIndex = 0;
        }
    }

    public class 출하라인환경설정
    {
        public string PLC_IP { get; set; }
        public string PLC_PORT { get; set; }
        public string COM_NAME { get; set; }
        public string COM_BAUDRATE { get; set; }
        public string PRINTER_NAME { get; set; }
        public string BARCODE_POSITION { get; set; }
        public string URL { get; set; }

        internal void SetDataRow(DataRow row)
        {
            PLC_IP = row["PLC_IP"].ToString();
            PLC_PORT = row["PLC_PORT"].ToString();
            COM_NAME = row["COM_NAME"].ToString();
            COM_BAUDRATE = row["COM_BAUDRATE"].ToString();
            PRINTER_NAME = row["PRINTER_NAME"].ToString();
            BARCODE_POSITION = row["BARCODE_POSITION"].ToString();
            URL = row["URL"].ToString();
        }
    }
}
