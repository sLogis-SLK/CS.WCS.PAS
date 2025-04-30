namespace pas.smp
{
    public static class GlobalClass
    {

        public static string CMD_01_BUF = "500000FFFF03000C00100001040000100400A82300";
        public static string CMD_02_BUF = "500000FFFF03000C00100001040000E80300A82300";
        public static string LAST_BOX_IDENTIFIER = "★";

        public static string ConnectionString
        {
            get { return $"Data Source={HOST};Initial Catalog={DB};Persist Security Info=True;User ID={ID};Password={PASSWORD}"; }
        }

        
        //ini 파일 하드코딩

        //[SMP]
        public static string PLC_IP = "192.168.20.69";
        public static int PLC_PORT = 2011;

        //[DATABASE]
        public static string PASDB_IP = "112.216.239.253,4222";
        public static string PASDB_SERVICE = "PASOP";
        public static string PASDB_ID = "pasuser";
        public static string PASDB_PASSWORD = "paspass";
        public static string HOST_IP = "112.216.239.253,4222";
        public static string HOST_SERVICE = "WCSIF";
        public static string HOST_ID = "pasuser";
        public static string HOST_PASSWORD = "paspass";

        //임시임
        private static string HOST = PASDB_IP;
        private static string DB = PASDB_SERVICE;
        private static string ID = PASDB_ID;
        private static string PASSWORD = PASDB_PASSWORD;

        //[ETC]
        public static string COM_NAME = "COM1";
        public static int COM_BAUDRATE = 19200;
        public static string PRINTER_NAME = "Samsung ML-4050 Series PCL6";
        public static string BARCODE_POSITION = "Brand Name";
        public static string URL = "http://112.216.239.250:8888/edi/m_waybill_get.jsp?";


        //신규
        public static byte[] GetBufferBybyte
        {
            get => ConvertUtil.StringToBuffer(GlobalClass.PLC_PORT == 2011 ? GlobalClass.CMD_01_BUF : GlobalClass.CMD_02_BUF);
        }




    }
}
