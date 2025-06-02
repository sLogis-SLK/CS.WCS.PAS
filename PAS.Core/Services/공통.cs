using DbProvider;
using System;
using System.Data;
using TR_Common;

namespace PAS.Core
{
    internal class 공통
    {
        internal static DataTable Pas접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

        internal static DataTable Pas출하라인접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }
    }
}
