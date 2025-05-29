// Decompiled with JetBrains decompiler
// Type: pas.mgp.Execbat
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

// #nullable disable
// namespace pas.mgp;

public class Execbat
{
  private string m_sLineNo = string.Empty;
  private string m_sJob = string.Empty;
  private string m_sMakeDate = string.Empty;
  private string m_sBatchNo = string.Empty;
  private string m_sBatchName = string.Empty;
  private string m_sStatusFlag = string.Empty;
  private string m_sCheckFlag = string.Empty;
  private string m_sMaxCaseCapacity = string.Empty;
  private string m_sResultFlag = string.Empty;
  private string m_sStartTime = string.Empty;
  private string m_sLoadTime = string.Empty;
  private string m_sWorkLineNo = string.Empty;
  private string m_sSendCancelFlag = string.Empty;
  private string m_sOperateType = string.Empty;
  private string m_sFilter = string.Empty;

  public string LineNo
  {
    get => this.m_sLineNo;
    set => this.m_sLineNo = Command.GetEmptyString(value, 1);
  }

  public string Job
  {
    get => this.m_sJob;
    set => this.m_sJob = Command.GetEmptyString(value, 1);
  }

  public string MakeDate
  {
    get => this.m_sMakeDate;
    set => this.m_sMakeDate = Command.GetEmptyString(value, 8);
  }

  public string BatchNo
  {
    get => this.m_sBatchNo;
    set => this.m_sBatchNo = Command.GetEmptyString(value, 8);
  }

  public string BatchName
  {
    get => this.m_sBatchName;
    set => this.m_sBatchName = Command.GetEmptyString(value, 20);
  }

  public string StatusFlag
  {
    get => this.m_sStatusFlag;
    set => this.m_sStatusFlag = Command.GetEmptyString(value, 1);
  }

  public string CheckFlag
  {
    get => this.m_sCheckFlag;
    set => this.m_sCheckFlag = Command.GetEmptyString(value, 10);
  }

  public string MaxCaseCapacity
  {
    get => this.m_sMaxCaseCapacity;
    set => this.m_sMaxCaseCapacity = Command.GetEmptyString(value, 4);
  }

  public string ResultFlag
  {
    get => this.m_sResultFlag;
    set => this.m_sResultFlag = Command.GetEmptyString(value, 1);
  }

  public string StartTime
  {
    get => this.m_sStartTime;
    set => this.m_sStartTime = Command.GetEmptyString(value, 4);
  }

  public string LoadTime
  {
    get => this.m_sLoadTime;
    set => this.m_sLoadTime = Command.GetEmptyString(value, 4);
  }

  public string WorkLineNo
  {
    get => this.m_sWorkLineNo;
    set => this.m_sWorkLineNo = Command.GetEmptyString(value, 1);
  }

  public string SendCancelFlag
  {
    get => this.m_sSendCancelFlag;
    set => this.m_sSendCancelFlag = Command.GetEmptyString(value, 1);
  }

  public string OperateType
  {
    get => this.m_sOperateType;
    set => this.m_sOperateType = Command.GetEmptyString(value, 1);
  }

  public string Filter
  {
    get => this.m_sFilter;
    set => this.m_sFilter = Command.GetEmptyString(value, 35);
  }

  public Execbat()
  {
    this.m_sLineNo = Command.GetEmptyString(string.Empty, 1);
    this.m_sJob = Command.GetEmptyString(string.Empty, 1);
    this.m_sMakeDate = Command.GetEmptyString(string.Empty, 8);
    this.m_sBatchNo = Command.GetEmptyString(string.Empty, 8);
    this.m_sBatchName = Command.GetEmptyString(string.Empty, 20);
    this.m_sStatusFlag = Command.GetEmptyString(string.Empty, 1);
    this.m_sCheckFlag = Command.GetEmptyString(string.Empty, 10);
    this.m_sMaxCaseCapacity = Command.GetEmptyString(string.Empty, 4);
    this.m_sResultFlag = Command.GetEmptyString(string.Empty, 1);
    this.m_sStartTime = Command.GetEmptyString(string.Empty, 4);
    this.m_sLoadTime = Command.GetEmptyString(string.Empty, 4);
    this.m_sWorkLineNo = Command.GetEmptyString(string.Empty, 1);
    this.m_sSendCancelFlag = Command.GetEmptyString(string.Empty, 1);
    this.m_sOperateType = Command.GetEmptyString(string.Empty, 1);
    this.m_sFilter = Command.GetEmptyString(string.Empty, 35);
  }

  public Execbat(
    string sLineNo,
    string sJob,
    string sMakeDate,
    string sBatchNo,
    string sBatchName,
    string sStatusFlag,
    string sCheckFlag,
    string sMaxCaseCapacity,
    string sResultFlag,
    string sStartTime,
    string sLoadTime,
    string sWorkLineNo,
    string sSendCancelFlag,
    string sOperateType,
    string sFilter)
  {
    this.m_sLineNo = Command.GetEmptyString(sLineNo, 1);
    this.m_sJob = Command.GetEmptyString(sJob, 1);
    this.m_sMakeDate = Command.GetEmptyString(sMakeDate, 8);
    this.m_sBatchNo = Command.GetEmptyString(sBatchNo, 8);
    this.m_sBatchName = Command.GetEmptyString(sBatchName, 20);
    this.m_sStatusFlag = Command.GetEmptyString(sStatusFlag, 1);
    this.m_sCheckFlag = Command.GetEmptyString(sCheckFlag, 10);
    this.m_sMaxCaseCapacity = Command.GetEmptyString(sMaxCaseCapacity, 4);
    this.m_sResultFlag = Command.GetEmptyString(sResultFlag, 1);
    this.m_sStartTime = Command.GetEmptyString(sStartTime, 4);
    this.m_sLoadTime = Command.GetEmptyString(sLoadTime, 4);
    this.m_sWorkLineNo = Command.GetEmptyString(sWorkLineNo, 1);
    this.m_sSendCancelFlag = Command.GetEmptyString(sSendCancelFlag, 1);
    this.m_sOperateType = Command.GetEmptyString(sOperateType, 1);
    this.m_sFilter = Command.GetEmptyString(sFilter, 35);
  }
}
