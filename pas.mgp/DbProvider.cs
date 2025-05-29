// Decompiled with JetBrains decompiler
// Type: pas.mgp.DbProvider
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;
using System.Data;
using System.Data.SqlClient;

// #nullable disable
// namespace pas.mgp;

public class DbProvider
{
  public static SqlParameter GetParameter(string sName, object oValue)
  {
    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = sName;
    parameter.Direction = ParameterDirection.Input;
    parameter.Size = string.IsNullOrEmpty(oValue.ToString()) ? 1000 : 0;
    parameter.Value = oValue;
    return parameter;
  }

  public static SqlParameter GetParameter(string sName, object oValue, ParameterDirection e)
  {
    SqlParameter parameter = new SqlParameter();
    parameter.ParameterName = sName;
    parameter.Direction = e;
    parameter.Size = string.IsNullOrEmpty(oValue.ToString()) ? 1000 : 0;
    parameter.Value = oValue;
    return parameter;
  }

  public static DataTable Select(string sConnectionString, string sQuery)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    DataTable dataTable = new DataTable();
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      new SqlDataAdapter() { SelectCommand = sqlCommand }.Fill(dataTable);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
    return dataTable;
  }

  public static DataTable Select(
    string sConnectionString,
    string sQuery,
    params SqlParameter[] oParams)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    DataTable dataTable = new DataTable();
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      if (oParams != null)
        sqlCommand.Parameters.AddRange(oParams);
      new SqlDataAdapter() { SelectCommand = sqlCommand }.Fill(dataTable);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
    return dataTable;
  }

  public static void Select(
    string sConnectionString,
    DataTable oDataTable,
    params SqlParameter[] oParams)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    oDataTable.Rows.Clear();
    oDataTable.Columns.Clear();
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = oDataTable.TableName;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.CommandTimeout = 0;
      if (oParams != null)
        sqlCommand.Parameters.AddRange(oParams);
      new SqlDataAdapter() { SelectCommand = sqlCommand }.Fill(oDataTable);
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static object Scalar(
    string sConnectionString,
    string sQuery,
    params SqlParameter[] oParams)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      if (oParams != null)
        sqlCommand.Parameters.AddRange(oParams);
      return sqlCommand.ExecuteScalar();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static object Scalar(string sConnectionString, string sQuery)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.Text;
      return sqlCommand.ExecuteScalar();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static void Excute(string sConnectionString, string sQuery)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    SqlTransaction sqlTransaction = (SqlTransaction) null;
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.Text;
      sqlCommand.Transaction = sqlTransaction;
      sqlCommand.ExecuteNonQuery();
      sqlTransaction.Commit();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlTransaction?.Dispose();
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static void Excute(string sConnectionString, string sQuery, params SqlParameter[] oParams)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    SqlTransaction sqlTransaction = (SqlTransaction) null;
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = sqlTransaction;
      if (oParams != null)
        sqlCommand.Parameters.AddRange(oParams);
      sqlCommand.ExecuteNonQuery();
      sqlTransaction.Commit();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlTransaction?.Dispose();
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static void Excute(
    string sConnectionString,
    string sQuery,
    out SqlParameterCollection oParameters,
    params SqlParameter[] oParams)
  {
    SqlConnection sqlConnection = (SqlConnection) null;
    SqlCommand sqlCommand = (SqlCommand) null;
    SqlTransaction sqlTransaction = (SqlTransaction) null;
    try
    {
      sqlConnection = new SqlConnection(sConnectionString);
      sqlConnection.Open();
      sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
      sqlCommand = new SqlCommand();
      sqlCommand.Connection = sqlConnection;
      sqlCommand.CommandText = sQuery;
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Transaction = sqlTransaction;
      if (oParams != null)
        sqlCommand.Parameters.AddRange(oParams);
      oParameters = sqlCommand.Parameters;
      sqlCommand.ExecuteNonQuery();
      sqlTransaction.Commit();
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
    finally
    {
      sqlTransaction?.Dispose();
      sqlCommand?.Dispose();
      sqlConnection?.Close();
    }
  }

  public static void Bulk(string sConnectionString, string sQuery, DataTable oDataTable)
  {
    try
    {
      using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(sConnectionString))
      {
        sqlBulkCopy.DestinationTableName = sQuery;
        sqlBulkCopy.BulkCopyTimeout = 0;
        sqlBulkCopy.BatchSize = oDataTable.Rows.Count;
        sqlBulkCopy.WriteToServer(oDataTable);
        sqlBulkCopy.Close();
      }
    }
    catch (Exception ex)
    {
      throw new Exception(ex.Message);
    }
  }
}
