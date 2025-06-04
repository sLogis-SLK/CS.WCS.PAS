using PAS.Core;

namespace PAS.Task
{
    internal class GlobalClass : GlobalCore
    {
        public static string NAME { get => pas환경설정.NAME; }

        public static string SEIGYO_ID { get => pas환경설정.SEIGYO_ID; }
        public static string SEIGYO_PASSWORD { get => pas환경설정.SEIGYO_PASSWORD; }
        public static string SEIGYO_FOLDER { get => pas환경설정.SEIGYO_FOLDER; }
        
        public static string LOCAL_FOLDER { get => pas환경설정.LOCAL_FOLDER; }
        
        public static int PAS_DURATION { get => pas환경설정.PAS_DURATION; }

        public static string INDICATOR_STRUCTURE { get => pas환경설정.INDICATOR_STRUCTURE; }
        public static string INDICATOR_IP { get => pas환경설정.INDICATOR_IP; }
        public static int INDICATOR_PORT { get => pas환경설정.INDICATOR_PORT; }


        public static string BARCODE_PRINTER_LIST { get => pas환경설정.BARCODE_PRINTER_LIST; }
        


    }
}
