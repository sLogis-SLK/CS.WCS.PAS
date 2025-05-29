// Decompiled with JetBrains decompiler
// Type: pas.mgp.DBProvider2
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

// #nullable disable

public class DBProvider2 : IDisposable
{
  private SqlConnection m_oConn;
  private SqlTransaction m_oTran;
  private SqlCommand m_oComm;
  private CommandType m_eType = CommandType.StoredProcedure;
  private string m_strErr = string.Empty;
  private bool m_bNoTransaction;
  private bool m_bCommit;

  public CommandType CommandType
  {
    get => this.m_eType;
    set => this.m_eType = value;
  }

  public DBProvider2(SqlConnection oConn, IsolationLevel level)
  {
    this.m_oConn = oConn;
    this.m_oConn.Open();
    try
    {
      this.m_oTran = oConn.BeginTransaction(level);
    }
    catch (Exception ex)
    {
      this.m_strErr = ex.Message;
      DBProvider2.DoCommand(oConn, "Commit");
      this.m_oTran = oConn.BeginTransaction(level);
    }
    this.m_oComm = this.m_oConn.CreateCommand();
    this.m_oComm.CommandTimeout = 0;
    this.m_oComm.Transaction = this.m_oTran;
  }

  public DBProvider2(SqlConnection oConn)
  {
    this.m_oConn = oConn;
    this.m_oConn.Open();
    this.m_oComm = this.m_oConn.CreateCommand();
    this.m_oComm.CommandTimeout = 0;
    this.m_bNoTransaction = true;
  }

  public static bool DatabaseExist(string sDir, string sFileName) => File.Exists(sDir + sFileName);

  public void Initialize(string strQuery, params string[] strParamNames)
  {
    this.m_oComm.CommandText = strQuery;
    this.m_oComm.CommandTimeout = 0;
    this.m_oComm.Parameters.Clear();
    if (strParamNames == null)
      return;
    foreach (string strParamName in strParamNames)
    {
      SqlParameter parameter = this.m_oComm.CreateParameter();
      parameter.ParameterName = strParamName;
      this.m_oComm.Parameters.Add(parameter);
    }
  }

  public void SetParams(ParameterDirection eDirection, params string[] strParamNames)
  {
    foreach (string strParamName in strParamNames)
    {
      SqlParameter parameter = this.m_oComm.CreateParameter();
      parameter.ParameterName = strParamName;
      parameter.Direction = eDirection;
      parameter.Size = 1000;
      this.m_oComm.Parameters.Add(parameter);
    }
  }

  public void SetParams(ParameterDirection eDirection, object obj, params string[] strParamNames)
  {
    foreach (string strParamName in strParamNames)
    {
      SqlParameter parameter = this.m_oComm.CreateParameter();
      parameter.ParameterName = strParamName;
      parameter.Direction = eDirection;
      parameter.Size = 0;
      parameter.Value = obj;
      this.m_oComm.Parameters.Add(parameter);
    }
  }

  public int Update(params object[] objs)
  {
    this.m_oComm.CommandType = this.m_eType;
    if (this.m_oComm.Parameters.Count > 0)
    {
      if (objs.Length > this.m_oComm.Parameters.Count)
        throw new Exception($"Invalid Value Count. Parameter = {this.m_oComm.Parameters.Count}, Value = {objs.Length}");
      for (int index = 0; index < objs.Length; ++index)
      {
        SqlParameter parameter = this.m_oComm.Parameters[index];
        if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
          parameter.Value = objs[index] == null ? (object) DBNull.Value : objs[index];
      }
    }
    return this.m_oComm.ExecuteNonQuery();
  }

  public int Update(out SqlParameterCollection oParams, params object[] objs)
  {
    this.m_oComm.CommandType = this.m_eType;
    if (this.m_oComm.Parameters.Count > 0)
    {
      if (objs.Length > this.m_oComm.Parameters.Count)
        throw new Exception($"Invalid Value Count. Parameter = {this.m_oComm.Parameters.Count}, Value = {objs.Length}");
      for (int index = 0; index < objs.Length; ++index)
        this.m_oComm.Parameters[index].Value = objs[index] == null ? (object) DBNull.Value : objs[index];
    }
    oParams = this.m_oComm.Parameters;
    return this.m_oComm.ExecuteNonQuery();
  }

  public int Update(SqlDataAdapter oSda, DataSet oDataSet) => oSda.Update(oDataSet);

  public void Fill(DataTable oDataTable, params object[] objs)
  {
    this.m_oComm.CommandType = this.m_eType;
    if (this.m_oComm.Parameters.Count > 0)
    {
      if (objs.Length > this.m_oComm.Parameters.Count)
        throw new Exception($"Invalid Value Count. Parameter = {this.m_oComm.Parameters.Count}, Value = {objs.Length}");
      for (int index = 0; index < objs.Length; ++index)
      {
        SqlParameter parameter = this.m_oComm.Parameters[index];
        if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
          parameter.Value = objs[index] == null ? (object) DBNull.Value : objs[index];
      }
    }
    SqlDataReader sqlDataReader = this.m_oComm.ExecuteReader();
    oDataTable.Clear();
    for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
    {
      if (!oDataTable.Columns.Contains(sqlDataReader.GetName(ordinal)))
        oDataTable.Columns.Add(sqlDataReader.GetName(ordinal), sqlDataReader.GetFieldType(ordinal));
    }
    int count = oDataTable.Columns.Count;
    int num = 0;
    while (sqlDataReader.Read())
    {
      DataRow row = oDataTable.NewRow();
      string empty = string.Empty;
      for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
      {
        string name = sqlDataReader.GetName(ordinal);
        if (oDataTable.Columns.Contains(name))
          row[name] = sqlDataReader[name];
      }
      oDataTable.Rows.Add(row);
      ++num;
    }
    oDataTable.AcceptChanges();
    sqlDataReader.Close();
  }

  public void Commit() => this.Commit(true);

  public void Commit(bool bIsClose)
  {
    if (this.m_bNoTransaction)
      return;
    this.m_oTran.Commit();
    if (bIsClose)
      this.m_oConn.Close();
    this.m_bCommit = true;
  }

  public void Rollback() => this.Rollback(true);

  public void Rollback(bool bIsClose)
  {
    if (this.m_bNoTransaction)
      return;
    this.m_oTran.Rollback();
    if (bIsClose)
      this.m_oConn.Close();
    this.m_bCommit = true;
  }

  public void Dispose()
  {
    if (this.m_bNoTransaction)
    {
      this.m_oConn.Close();
      if (this.m_oComm != null)
        this.m_oComm.Dispose();
      GC.Collect();
      this.m_oConn.Dispose();
    }
    else
    {
      if (this.m_oConn.State != ConnectionState.Closed)
      {
        if (!this.m_bCommit && this.m_oTran != null)
          this.m_oTran.Rollback();
        this.m_oConn.Close();
      }
      if (this.m_oComm != null)
        this.m_oComm.Dispose();
      if (this.m_oTran != null)
        this.m_oTran.Dispose();
      this.m_oConn.Dispose();
      GC.Collect();
    }
  }

  public static void GetData(
    DataTable oDataTable,
    SqlConnection oConn,
    string strQuery,
    CommandType eType,
    string[] strParamNames,
    params object[] objs)
  {
    using (DBProvider2 dbProvider2 = new DBProvider2(oConn))
    {
      dbProvider2.CommandType = eType;
      if (strParamNames == null)
        dbProvider2.Initialize(strQuery);
      else if (strParamNames == null)
        dbProvider2.Initialize(strQuery);
      else
        dbProvider2.Initialize(strQuery, strParamNames);
      dbProvider2.Fill(oDataTable, objs);
    }
  }

  public static bool DoCommand(SqlConnection oConn, string strCmd)
  {
    try
    {
      SqlCommand command = oConn.CreateCommand();
      command.CommandType = CommandType.Text;
      command.CommandText = strCmd;
      command.Connection = oConn;
      command.ExecuteNonQuery();
    }
    catch
    {
      return false;
    }
    return true;
  }

  public static void GetData(
    DataTable oDataTable,
    SqlConnection oConn,
    string[] strParamNames,
    params object[] objs)
  {
    DBProvider2.GetData(oDataTable, oConn, oDataTable.TableName, CommandType.StoredProcedure, strParamNames, objs);
  }

  public static void GetTableInfo(
    DataTable oDataTable,
    SqlConnection oConn,
    params string[] strParamNames)
  {
    DBProvider2.GetTableInfo(oDataTable, oConn, oDataTable.TableName, CommandType.StoredProcedure, strParamNames);
  }

  public static void GetTableInfo(
    DataTable oDataTable,
    SqlConnection oConn,
    string p,
    CommandType commandType,
    params string[] strParamNames)
  {
    object[] objArray = new object[strParamNames.Length];
    DBProvider2.GetData(oDataTable, oConn, oDataTable.TableName, CommandType.StoredProcedure, strParamNames, objArray);
  }
}
