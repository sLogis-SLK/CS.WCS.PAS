using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PAS.Core
{
    public class GlobalCore
    {
        public static string PATH_STARTUP { get => Application.StartupPath; }

        public static string PasDBConnectionString
        {
            get { return $"Data Source={db접속정보.PAS_DB_IP};Initial Catalog={db접속정보.PAS_DB_SERVICE};Persist Security Info=True;User ID={db접속정보.PAS_DB_ID};Password={db접속정보.PAS_DB_PASSWORD}"; }
        }

        public static string HostDBConnectionString
        {
            get { return $"Data Source={db접속정보.HOST_DB_IP};Initial Catalog={db접속정보.HOST_DB_SERVICE};Persist Security Info=True;User ID={db접속정보.HOST_DB_ID};Password={db접속정보.HOST_DB_PASSWORD}"; }
        }

        public static Dictionary<string, DataRow> DicPas기기 = new Dictionary<string, DataRow>();
        
        public static Dictionary<string, DataRow> Dic출하기기 = new Dictionary<string, DataRow>();

        public static DB접속정보 db접속정보 = new DB접속정보();

        public static PAS환경설정 pas환경설정 = new PAS환경설정();

        public static 출하라인환경설정 출하라인설정 = new 출하라인환경설정();


        public static void InitializationSettings()
        {
            db접속정보.PAS_DB_IP = "112.216.239.253,4222";
            db접속정보.PAS_DB_SERVICE = "PASOP";
            db접속정보.PAS_DB_ID = "pasuser";
            db접속정보.PAS_DB_PASSWORD = "paspass";

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
                SettingsPas기기("PAS01");

                //Pas출하라인접속정보 최초가져오기
                DataTable dt_Dic출하기기 = 공통.출하라인접속정보(PasDBConnectionString);
                foreach (DataRow row in dt_Dic출하기기.Rows)
                {
                    DataRow saveRow = dt_Dic출하기기.NewRow();
                    saveRow.ItemArray = row.ItemArray;
                    Dic출하기기.Add(row["NAME"].ToString(), saveRow);
                }
                Settings출하기기("A라인");
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
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
