using DbProvider;
using System;
using System.Data;
using TR_Common;

namespace PAS.Core
{
    internal class 공통
    {
        internal static DataTable DB접속정보(string ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_DB접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static void DB접속정보저장(string ConnectionString, string PAS_DB_IP, string PAS_DB_SERVICE, string PAS_DB_ID, string PAS_DB_PASSWORD,
                                                                     string HOST_DB_IP, string HOST_DB_SERVICE, string HOST_DB_ID, string HOST_DB_PASSWORD)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("USP_공통_DB접속정보_Set", "@PAS_DB_IP", "@PAS_DB_SERVICE", "@PAS_DB_ID", "@PAS_DB_PASSWORD",
                                                             "@HOST_DB_IP", "@HOST_DB_SERVICE", "@HOST_DB_ID", "@HOST_DB_PASSWORD");
                oScope.Update(PAS_DB_IP, PAS_DB_SERVICE, PAS_DB_ID, PAS_DB_PASSWORD, HOST_DB_IP, HOST_DB_SERVICE, HOST_DB_ID, HOST_DB_PASSWORD);
                oScope.Commit();
            }
        }

        internal static DataTable Pas접속정보(string ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_PAS접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static DataTable 출하라인접속정보(string ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_출하라인정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static void 출하라인접속정보저장(string ConnectionString, DataTable dt)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("USP_공통_출하라인정보_Set", "@키인덱스", "@NAME", "@PLC_IP", "@PLC_PORT", "@COM_NAME", "@COM_BAUDRATE", "@PRINTER_NAME", "@BARCODE_POSITION", "@URL");

                foreach (DataRow row in dt.Rows)
                {
                    int 키인덱스 = 0;
                    ConvertUtil.ObjectToInt32(row["순서"], out 키인덱스);
                    string NAME = row["NAME"].ToString();
                    string PLC_IP = row["PLC_IP"].ToString();
                    string PLC_PORT = row["PLC_PORT"].ToString();
                    string COM_NAME = row["COM_NAME"].ToString();
                    string COM_BAUDRATE = row["COM_BAUDRATE"].ToString();
                    string PRINTER_NAME = row["PRINTER_NAME"].ToString();
                    string BARCODE_POSITION = row["BARCODE_POSITION"].ToString();
                    string URL = row["URL"].ToString();

                    oScope.Update(키인덱스, NAME, PLC_IP, PLC_PORT, COM_NAME, COM_BAUDRATE, PRINTER_NAME, BARCODE_POSITION, URL);
                }
                oScope.Commit();
            }
        }

        internal static void PAS접속정보저장(string ConnectionString, DataRow dr)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("USP_공통_PAS접속정보_Set", "@키인덱스",
                    "@NAME", "@SEIGYO_IP", "@SEIGYO_PORT", "@CHUTES",
                    "@CHUTES_ERROR", "@CHUTES_OVERFLOW",
                    "@SEIGYO_FOLDER", "@SEIGYO_ID", "@SEIGYO_PASSWORD",
                    "@LOCAL_FOLDER", "@PAS_DURATION", "@INDICATOR_DURATION", "@INDICATOR_IP", 
                    "@INDICATOR_PORT", "@INDICATOR_STRUCTURE", "@BARCODE_PRINTER_LIST" , "@PRINTER_LIST");

              
                int 키인덱스 = 0;
                ConvertUtil.ObjectToInt32(dr["순서"], out 키인덱스);
                string NAME = dr["NAME"].ToString();
                string SEIGYO_IP = dr["SEIGYO_IP"].ToString();
                string SEIGYO_PORT = dr["SEIGYO_PORT"].ToString();
                string CHUTES = dr["CHUTES"].ToString();
                string CHUTES_ERROR = dr["CHUTES_ERROR"].ToString();
                string CHUTES_OVERFLOW = dr["CHUTES_OVERFLOW"].ToString();
                string SEIGYO_FOLDER = dr["SEIGYO_FOLDER"].ToString();
                string SEIGYO_ID = dr["SEIGYO_ID"].ToString();
                string SEIGYO_PASSWORD = dr["SEIGYO_PASSWORD"].ToString();
                string LOCAL_FOLDER = dr["LOCAL_FOLDER"].ToString();
                string PAS_DURATION = dr["PAS_DURATION"].ToString();
                string INDICATOR_DURATION = dr["INDICATOR_DURATION"].ToString();
                string INDICATOR_IP = dr["INDICATOR_IP"].ToString();
                string INDICATOR_PORT = dr["INDICATOR_PORT"].ToString();
                string INDICATOR_STRUCTURE = dr["INDICATOR_STRUCTURE"].ToString();
                string BARCODE_PRINTER_LIST = dr["BARCODE_PRINTER_LIST"].ToString();
                string PRINTER_LIST = dr["PRINTER_LIST"].ToString();

                oScope.Update(키인덱스, NAME, SEIGYO_IP, SEIGYO_PORT, CHUTES, 
                    CHUTES_ERROR, CHUTES_OVERFLOW, SEIGYO_FOLDER, SEIGYO_ID, SEIGYO_PASSWORD,
                    LOCAL_FOLDER, PAS_DURATION,
                    INDICATOR_DURATION, INDICATOR_IP, INDICATOR_PORT, INDICATOR_STRUCTURE,
                    BARCODE_PRINTER_LIST, PRINTER_LIST);
                
                oScope.Commit();
            }
        }

        internal static void 출하라인접속정보삭제(string ConnectionString, DataRow[] rows)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("USP_공통_출하라인정보삭제_Set", "@키인덱스");

                foreach (DataRow row in rows)
                {
                    int 키인덱스 = 0;
                    ConvertUtil.ObjectToInt32(row["순서"], out 키인덱스);
                    oScope.Update(키인덱스);
                }
                oScope.Commit();
            }
        }


    }
}
