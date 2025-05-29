// Decompiled with JetBrains decompiler
// Type: pas.mgp.Rebuild
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;

// #nullable disable
// namespace pas.mgp;

public class Rebuild
{
  private string m_sFlag = string.Empty;
  private string m_sMark = string.Empty;
  private string m_sMajorCode = string.Empty;
  private string m_sBlock1 = string.Empty;
  private string m_sBlock2 = string.Empty;
  private string m_sBlock3 = string.Empty;
  private string m_sMinorCode = string.Empty;
  private string m_sBarcode = string.Empty;
  private string m_sItemCode = string.Empty;
  private string m_sItemName = string.Empty;
  private string m_sItemCapacity = string.Empty;
  private string m_sPrice = string.Empty;
  private string m_sChuteNo = string.Empty;
  private string m_sOrder = string.Empty;
  private string m_sResult = string.Empty;
  private string m_sReserved = string.Empty;
  private string m_sBarcode1 = string.Empty;
  private string m_sFiller1 = string.Empty;
  private string m_sSortNo = string.Empty;
  private string m_sBarcode2 = string.Empty;
  private string m_sBarcode3 = string.Empty;
  private string m_sFiller2 = string.Empty;
  private string m_sTime = string.Empty;
  private string m_sFiller3 = string.Empty;
  private string m_sLf = "\n";
  private long m_lOrder;
  private long m_lResult;
  private long m_lReserved;
  private string m_sBatchNo = string.Empty;

  public string BatchNo
  {
    get => this.m_sBatchNo;
    set => this.m_sBatchNo = value;
  }

  public string Flag
  {
    get => this.m_sFlag;
    set => this.m_sFlag = Command.GetEmptyString(value, 1);
  }

  public string Mark
  {
    get => this.m_sMark;
    set => this.m_sMark = Command.GetEmptyString(value, 1);
  }

  public string MajorCode
  {
    get => this.m_sMajorCode;
    set => this.m_sMajorCode = Command.GetEmptyString(value, 40);
  }

  public string MajorBlock1
  {
    get => this.m_sBlock1;
    set => this.m_sBlock1 = Command.GetEmptyString(value, 20);
  }

  public string MajorBlock2
  {
    get => this.m_sBlock2;
    set => this.m_sBlock2 = Command.GetEmptyString(value, 10);
  }

  public string MajorBlock3
  {
    get => this.m_sBlock3;
    set => this.m_sBlock3 = Command.GetEmptyString(value, 10);
  }

  public string MinorCode
  {
    get => this.m_sMinorCode;
    set => this.m_sMinorCode = Command.GetEmptyString(value, 20);
  }

  public string Barcode
  {
    get => this.m_sBarcode;
    set => this.m_sBarcode = Command.GetEmptyString(value, 20);
  }

  public string ItemCode
  {
    get => this.m_sItemCode;
    set => this.m_sItemCode = Command.GetEmptyString(value, 40);
  }

  public string ItemName
  {
    get => this.m_sItemName;
    set => this.m_sItemName = Command.GetEmptyString(value, 40);
  }

  public string ItemCapacity
  {
    get => this.m_sItemCapacity;
    set => this.m_sItemCapacity = Command.GetEmptyString(value, 4);
  }

  public string Price
  {
    get => this.m_sPrice;
    set => this.m_sPrice = Command.GetEmptyString(value, 4);
  }

  public string ChuteNo
  {
    get => this.m_sChuteNo;
    set => this.m_sChuteNo = Command.GetEmptyString(value, 3);
  }

  public string Order
  {
    get => this.m_sOrder;
    set => this.m_sOrder = Command.GetEmptyString(value, 4);
  }

  public string Result
  {
    get => this.m_sResult;
    set => this.m_sResult = Command.GetEmptyString(value, 4);
  }

  public string Reserved
  {
    get => this.m_sReserved;
    set => this.m_sReserved = Command.GetEmptyString(value, 4);
  }

  public string Barcode1
  {
    get => this.m_sBarcode1;
    set => this.m_sBarcode1 = Command.GetEmptyString(value, 30);
  }

  public string Filler1
  {
    get => this.m_sFiller1;
    set => this.m_sFiller1 = Command.GetEmptyString(value, 20);
  }

  public string SortNo
  {
    get => this.m_sSortNo;
    set => this.m_sSortNo = Command.GetEmptyString(value, 3);
  }

  public string Barcode2
  {
    get => this.m_sBarcode2;
    set => this.m_sBarcode2 = Command.GetEmptyString(value, 30);
  }

  public string Barcode3
  {
    get => this.m_sBarcode3;
    set => this.m_sBarcode3 = Command.GetEmptyString(value, 30);
  }

  public string Filler2
  {
    get => this.m_sFiller2;
    set => this.m_sFiller2 = Command.GetEmptyString(value, 4);
  }

  public string Time
  {
    get => this.m_sTime;
    set => this.m_sTime = Command.GetEmptyString(value, 9);
  }

  public string Filler3
  {
    get => this.m_sFiller3;
    set => this.m_sFiller3 = Command.GetEmptyString(value, 48 /*0x30*/);
  }

  public string Lf => this.m_sLf;

  public long OrderCount
  {
    get
    {
      string empty = string.Empty;
      this.m_lOrder = Convert.ToInt64(!(this.m_sOrder.Trim() == string.Empty) ? this.m_sOrder.Trim() : "0");
      return this.m_lOrder;
    }
  }

  public long ResultCount
  {
    get
    {
      string empty = string.Empty;
      this.m_lResult = Convert.ToInt64(!(this.m_sResult.Trim() == string.Empty) ? this.m_sResult.Trim() : "0");
      return this.m_lResult;
    }
  }

  public long ReservedCount
  {
    get
    {
      string empty = string.Empty;
      this.m_lReserved = Convert.ToInt64(!(this.m_sReserved.Trim() == string.Empty) ? this.m_sReserved.Trim() : "0");
      return this.m_lReserved;
    }
  }

  public Rebuild()
  {
    this.m_sFlag = Command.GetEmptyString(string.Empty, 1);
    this.m_sMark = Command.GetEmptyString(string.Empty, 1);
    this.m_sMajorCode = Command.GetEmptyString(string.Empty, 40);
    this.m_sBlock1 = Command.GetEmptyString(string.Empty, 20);
    this.m_sBlock2 = Command.GetEmptyString(string.Empty, 10);
    this.m_sBlock3 = Command.GetEmptyString(string.Empty, 10);
    this.m_sMinorCode = Command.GetEmptyString(string.Empty, 20);
    this.m_sBarcode = Command.GetEmptyString(string.Empty, 20);
    this.m_sItemCode = Command.GetEmptyString(string.Empty, 40);
    this.m_sItemName = Command.GetEmptyString(string.Empty, 40);
    this.m_sItemCapacity = Command.GetEmptyString(string.Empty, 4);
    this.m_sPrice = Command.GetEmptyString(string.Empty, 4);
    this.m_sChuteNo = Command.GetEmptyString(string.Empty, 3);
    this.m_sOrder = Command.GetEmptyString(string.Empty, 4);
    this.m_sResult = Command.GetEmptyString(string.Empty, 4);
    this.m_sReserved = Command.GetEmptyString(string.Empty, 4);
    this.m_sBarcode1 = Command.GetEmptyString(string.Empty, 30);
    this.m_sFiller1 = Command.GetEmptyString(string.Empty, 20);
    this.m_sSortNo = Command.GetEmptyString(string.Empty, 3);
    this.m_sBarcode2 = Command.GetEmptyString(string.Empty, 30);
    this.m_sBarcode3 = Command.GetEmptyString(string.Empty, 30);
    this.m_sFiller2 = Command.GetEmptyString(string.Empty, 4);
    this.m_sTime = Command.GetEmptyString(string.Empty, 9);
    this.m_sFiller3 = Command.GetEmptyString(string.Empty, 48 /*0x30*/);
  }

  public Rebuild(
    string sFlag,
    string sMark,
    string sMajorCode,
    string sBlock1,
    string sBlock2,
    string sBlock3,
    string sMinorCode,
    string sBarcode,
    string sItemCode,
    string sItemName,
    string sItemCapacity,
    string sPrice,
    string sChuteNo,
    string sOrder,
    string sResult,
    string sReserved,
    string sBarcode1,
    string sFiller1,
    string sSortNo,
    string sBarcode2,
    string sBarcode3,
    string sFiller2,
    string sTime,
    string sFiller3)
  {
    this.m_sFlag = Command.GetEmptyString(sFlag, 1);
    this.m_sMark = Command.GetEmptyString(sMark, 1);
    this.m_sMajorCode = Command.GetEmptyString(sMajorCode, 40);
    if (sBlock1 != string.Empty && sBlock2 != string.Empty && sBlock2 != string.Empty)
    {
      this.m_sBlock1 = Command.GetEmptyString(sBlock1, 20);
      this.m_sBlock2 = Command.GetEmptyString(sBlock2, 10);
      this.m_sBlock3 = Command.GetEmptyString(sBlock3, 10);
      this.m_sMajorCode = Command.GetEmptyString(Command.GetEmptyString(sBlock1 + sBlock2 + sBlock3, 30), 40);
    }
    this.m_sMinorCode = Command.GetEmptyString(sMinorCode, 20);
    this.m_sBarcode = Command.GetEmptyString(sBarcode, 20);
    this.m_sItemCode = Command.GetEmptyString(sItemCode, 40);
    this.m_sItemName = Command.GetEmptyString(sItemName, 40);
    this.m_sItemCapacity = Command.GetEmptyString(sItemCapacity, 4);
    this.m_sPrice = Command.GetEmptyString(sPrice, 4);
    this.m_sChuteNo = Command.GetEmptyString(sChuteNo, 3);
    this.m_sOrder = Command.GetEmptyString(sOrder, 4);
    this.m_sResult = Command.GetEmptyString(sResult, 4);
    this.m_sReserved = Command.GetEmptyString(sReserved, 4);
    this.m_sBarcode1 = Command.GetEmptyString(sBarcode1, 30);
    this.m_sFiller1 = Command.GetEmptyString(sFiller1, 20);
    this.m_sSortNo = Command.GetEmptyString(sSortNo, 3);
    this.m_sBarcode2 = Command.GetEmptyString(sBarcode2, 30);
    this.m_sBarcode3 = Command.GetEmptyString(sBarcode3, 30);
    this.m_sFiller2 = Command.GetEmptyString(sFiller2, 4);
    this.m_sTime = Command.GetEmptyString(sTime, 9);
    this.m_sFiller3 = Command.GetEmptyString(sFiller3, 48 /*0x30*/);
  }
}
