using System.Xml.Linq;
using System;
using TR_Common;
using System.Runtime.CompilerServices;

namespace pas.smp
{
    public static class GlobalClass
    {

        public static string CMD_01_BUF = "500000FFFF03000C00100001040000100400A82300";
        public static string CMD_02_BUF = "500000FFFF03000C00100001040000E80300A82300";
        public static string LAST_BOX_IDENTIFIER = "★";

        public static string PATH_LOG => "\\LOG";

        public static string PATH_DATA => "\\DATA";

        public static string FILE_SETTING => "\\smp.ini";

        public static Setting Setting { get; set; }

        public static bool IsThread { get; set; }

        public static bool IsLog { get; set; }

        public static string ConnectionString
        {
            get { return $"Data Source={GlobalClass.Setting.PASDB_IP};Initial Catalog={GlobalClass.Setting.PASDB_SERVICE};Persist Security Info=True;User ID={GlobalClass.Setting.PASDB_ID};Password={GlobalClass.Setting.PASDB_PASSWORD}"; }
        }


        public static void GetSetting()
        {
            Setting setting = new Setting();
            try 
            {
                INI ini = new INI(Global.g_sStartupPath + "\\smp.ini");
                setting.PLC_IP = ini.GetIniValue(INI_SECTION.SMP, INI_KEY.PLC_IP);
                setting.PLC_PORT = ini.GetIniValue(INI_SECTION.SMP, INI_KEY.PLC_PORT);
                setting.PASDB_IP = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_IP);
                setting.PASDB_SERVICE = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_SERVICE);
                setting.PASDB_ID = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_ID);
                setting.PASDB_PASSWORD = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PASDB_PASSWORD);
                setting.HOST_IP = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_IP);
                setting.HOST_SERVICE = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_SERVICE);
                setting.HOST_ID = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_ID);
                setting.HOST_PASSWORD = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.HOST_PASSWORD);
                setting.COM_NAME = ini.GetIniValue(INI_SECTION.ETC, INI_KEY.COM_NAME);
                setting.COM_BAUDRATE = ini.GetIniValue(INI_SECTION.ETC, INI_KEY.COM_BAUDRATE);
                setting.PRINTER_NAME = ini.GetIniValue(INI_SECTION.ETC, INI_KEY.PRINTER_NAME);
                setting.BARCODE_POSITION = ini.GetIniValue(INI_SECTION.ETC, INI_KEY.BARCODE_POSITION);
                setting.URL = ini.GetIniValue(INI_SECTION.ETC, INI_KEY.URL);
            }
            catch (Exception ex)
            {
                Common.ErrorMessage("GlobalClass GetSetting", ex.Message);
            }
            GlobalClass.Setting = setting;
        }

        #region ini 파일 하드코딩
        /*
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
            public static string PRINTER_NAME = "ZDesigner GK420d (EPL)";
            public static string BARCODE_POSITION = "Brand Name";
            public static string URL = "http://112.216.239.250:8888/edi/m_waybill_get.jsp?";
        */
        #endregion

        //신규
        public static byte[] GetBufferBybyte
        {
            get => ConvertUtil.StringToBuffer(GlobalClass.Setting.PLC_PORT == "2011" ? GlobalClass.CMD_01_BUF : GlobalClass.CMD_02_BUF);
        }
    }
}
