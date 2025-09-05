using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PAS.Core
{
    public class GlobalCore
    {
        public static string PATH_STARTUP { get => Application.StartupPath; }

        private static string DafaultValuePathToIni { get => PATH_STARTUP + "\\Default.ini"; }
        
        public static string PasDBConnectionString
        {
            get { return $"Data Source={db접속정보.PAS_DB_IP};Initial Catalog={db접속정보.PAS_DB_SERVICE};Persist Security Info=True;User ID={db접속정보.PAS_DB_ID};Password={db접속정보.PAS_DB_PASSWORD}"; }
        }

        public static string HostDBConnectionString
        {
            get { return $"Data Source={db접속정보.PAS_DB_IP};Initial Catalog={db접속정보.HOST_DB_SERVICE};Persist Security Info=True;User ID={db접속정보.HOST_DB_ID};Password={db접속정보.HOST_DB_PASSWORD}"; }
        }

        public static Dictionary<string, DataRow> DicPas기기 = new Dictionary<string, DataRow>();
        
        public static Dictionary<string, DataRow> Dic출하기기 = new Dictionary<string, DataRow>();

        public static DB접속정보 db접속정보 = new DB접속정보();

        public static PAS환경설정 pas환경설정 = new PAS환경설정();

        public static 출하라인환경설정 출하라인설정 = new 출하라인환경설정();

        public static string DefaultValuePasName = string.Empty;

        public static string DefaultValue출하라인 = string.Empty;

        public static void InitializationSettings()
        {

            try
            {
                //기본값확인
                GetDefaultValueToIni();
                RefreshInfo();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static void RefreshInfo()
        {
            try
            {
                //DB접속정보 최초가져오기
                DataTable dt_DB접속정보 = 공통.DB접속정보(PasDBConnectionString);
                db접속정보.SetDataRow(dt_DB접속정보.Rows[0]);

                //Pas접속정보 최초가져오기
                DataTable dt_DicPas기기 = 공통.Pas접속정보(PasDBConnectionString);
                foreach (DataRow row in dt_DicPas기기.Rows)
                {
                    DataRow saveRow = dt_DicPas기기.NewRow();
                    saveRow.ItemArray = row.ItemArray;
                    DicPas기기.Add(row["NAME"].ToString(), saveRow);
                }

                //Pas출하라인접속정보 최초가져오기
                DataTable dt_Dic출하기기 = 공통.출하라인접속정보(PasDBConnectionString);
                foreach (DataRow row in dt_Dic출하기기.Rows)
                {
                    DataRow saveRow = dt_Dic출하기기.NewRow();
                    saveRow.ItemArray = row.ItemArray;
                    Dic출하기기.Add(row["NAME"].ToString(), saveRow);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        private static void GetDefaultValueToIni()
        {
            //기본Default값 가지고 오기
            INI ini = new INI(DafaultValuePathToIni);
            db접속정보.PAS_DB_IP = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_IP);
            db접속정보.PAS_DB_SERVICE = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_SERVICE);
            db접속정보.PAS_DB_ID = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_ID);
            db접속정보.PAS_DB_PASSWORD = ini.GetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_PASSWORD);
            DefaultValuePasName = ini.GetIniValue(INI_SECTION.PAS, INI_KEY.NAME);
            DefaultValue출하라인 = ini.GetIniValue(INI_SECTION.SMP, INI_KEY.LINE_NAME);

            //비었으면 Default 값 넣기
            if (string.IsNullOrEmpty(db접속정보.PAS_DB_IP))
            {
                db접속정보.PAS_DB_IP = "sol.slogis.co.kr,4222";
                db접속정보.PAS_DB_SERVICE = "PASOP";
                db접속정보.PAS_DB_ID = "pas_user";
                db접속정보.PAS_DB_PASSWORD = "i7w0ufs6jn9s4o";
            }
        }

        public static bool SaveDefaultValueToIni(string pasDefaultValue, string 출하DefaultValue)
        {
            //기본Default값 저장
            try
            {
                INI ini = new INI(DafaultValuePathToIni);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_IP, db접속정보.PAS_DB_IP);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_SERVICE, db접속정보.PAS_DB_SERVICE);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_ID, db접속정보.PAS_DB_ID);
                ini.SetIniValue(INI_SECTION.DATABASE, INI_KEY.PAS_DB_PASSWORD, db접속정보.PAS_DB_PASSWORD);

                if (string.IsNullOrEmpty(pasDefaultValue) == false)
                {
                    ini.SetIniValue(INI_SECTION.PAS, INI_KEY.NAME, pasDefaultValue);
                }

                if (string.IsNullOrEmpty(출하DefaultValue) == false)
                {
                    ini.SetIniValue(INI_SECTION.SMP, INI_KEY.LINE_NAME, 출하DefaultValue);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public static bool SettingsPas기기(string key)
        {
            if (DicPas기기.ContainsKey(key) == false) 
                return false;
            pas환경설정.SetDataRow(DicPas기기[key]);
            return true;
        }

        public static bool Settings출하기기(string key)
        {
            if (Dic출하기기.ContainsKey(key) == false)
                return false;
            출하라인설정.SetDataRow(Dic출하기기[key]);
            return true;
        }
    }



}
