using DbProvider;
using System;
using System.Data;
using TR_Common;

namespace PAS.Core
{
    internal class 공통
    {
        internal static DataTable DB접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_DB접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static DataTable Pas접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_PAS접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static DataTable 출하라인접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_출하라인정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }
    }
}
