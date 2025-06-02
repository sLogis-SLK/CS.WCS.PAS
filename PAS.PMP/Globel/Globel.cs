namespace PAS.PMP.PasWCS
{
    public class Globel
    {

        //DB접속정보
        internal static string GetDataBaseConnectionString
        {
            get
            {
#if DEBUG
                return "Data Source=" + "192.168.30.7,4222" + ";Initial Catalog=PASOP;Persist Security Info=True;User ID=sadmin;Password=its0622!@!";
#endif
                return "Data Source=" + "sol.slogis.co.kr,4222" + ";Initial Catalog=PASOP;Persist Security Info=True;User ID=pas_user;Password=i7w0ufs6jn9s4o";
            }
        }


        //DB접속정보
        internal static string GetWCSIFDataBaseConnectionString
        {
            get
            {
#if DEBUG
                return "Data Source=" + "192.168.30.7,4222" + ";Initial Catalog=WCSIF;Persist Security Info=True;User ID=sadmin;Password=its0622!@!";
#endif
                return "Data Source=" + "sol.slogis.co.kr,4222" + ";Initial Catalog=WCSIF;Persist Security Info=True;User ID=pas_user;Password=i7w0ufs6jn9s4o";
            }
        }
    }

}
