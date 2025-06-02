using DbProvider;
using System;
using System.Data;
using TR_Common;

namespace PAS.Task
{
    internal class 공통
    {
        internal static DataTable 접속정보(String ConnectionString)
        {
            DataTable dt = new DataTable("USP_공통_접속정보_Get");
            TlkTranscope.GetData(dt, Connections.GetConnection(Connections.CN_MSSQL, ConnectionString), null, null);
            return dt;
        }

    }
}
