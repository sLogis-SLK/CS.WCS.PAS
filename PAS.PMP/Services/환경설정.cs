using DbProvider;
using PAS.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TR_Common;

namespace PAS.PMP.PasWCS
{
    internal class 환경설정
    {
        internal void 조회()
        {

        }

        internal static DataTable DB접속정보()
        {
            DataTable dt = new DataTable("USP_공통_DB접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), null, null);
            return dt;
        }

        internal static void DB접속정보저장(string PAS_DB_IP, string PAS_DB_SERVICE, string PAS_DB_ID, string PAS_DB_PASSWORD,
                                                                     string HOST_DB_IP, string HOST_DB_SERVICE, string HOST_DB_ID, string HOST_DB_PASSWORD)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
            {
                oScope.Initialize("USP_공통_DB접속정보_Set", "@PAS_DB_IP", "@PAS_DB_SERVICE", "@PAS_DB_ID", "@PAS_DB_PASSWORD",
                                                             "@HOST_DB_IP", "@HOST_DB_SERVICE", "@HOST_DB_ID", "@HOST_DB_PASSWORD");
                oScope.Update(PAS_DB_IP, PAS_DB_SERVICE, PAS_DB_ID, PAS_DB_PASSWORD, HOST_DB_IP, HOST_DB_SERVICE, HOST_DB_ID, HOST_DB_PASSWORD);
                oScope.Commit();
            }
        }

        internal static DataTable Pas접속정보()
        {
            DataTable dt = new DataTable("USP_공통_PAS접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), null, null);
            return dt;
        }

        internal static DataTable 출하라인접속정보()
        {
            DataTable dt = new DataTable("USP_공통_출하라인정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), null, null);
            return dt;
        }

        internal static void 출하라인접속정보저장(DataTable dt)
        {
            using (TlkTranscope oScope = new TlkTranscope(Connections.GetConnection(Connections.CN_MSSQL, GlobalClass.PasDBConnectionString), IsolationLevel.ReadCommitted))
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
