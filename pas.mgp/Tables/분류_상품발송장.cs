// Decompiled with JetBrains decompiler
// Type: pas.mgp.Tables.분류_상품발송장
// Assembly: pas.mgp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CA03B7AC-3AB6-4BAB-9133-D086CEC3F322
// Assembly location: C:\Users\User\Desktop\pas_20170601\pas_20170601\pas.mgp.exe

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// #nullable disable
// namespace pas.mgp.Tables;

[XmlSchemaProvider("GetTypedDataSetSchema")]
[ToolboxItem(true)]
[HelpKeyword("vs.data.DataSet")]
[DesignerCategory("code")]
[XmlRoot("분류_상품발송장")]
[Serializable]
public class 분류_상품발송장 : DataSet
{
  private 분류_상품발송장.분류_상품발송장DataTable table분류_상품발송장;
  private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public 분류_상품발송장()
  {
    this.BeginInit();
    this.InitClass();
    CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
    base.Tables.CollectionChanged += changeEventHandler;
    base.Relations.CollectionChanged += changeEventHandler;
    this.EndInit();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  protected 분류_상품발송장(SerializationInfo info, StreamingContext context)
    : base(info, context, false)
  {
    if (this.IsBinarySerialized(info, context))
    {
      this.InitVars(false);
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      this.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }
    else
    {
      string s = (string) info.GetValue("XmlSchema", typeof (string));
      if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
      {
        DataSet dataSet = new DataSet();
        dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        if (dataSet.Tables[nameof (분류_상품발송장)] != null)
          base.Tables.Add((DataTable) new 분류_상품발송장.분류_상품발송장DataTable(dataSet.Tables[nameof (분류_상품발송장)]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
        this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
      this.GetSerializationData(info, context);
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      this.Relations.CollectionChanged += changeEventHandler;
    }
  }

  [DebuggerNonUserCode]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public 분류_상품발송장.분류_상품발송장DataTable _분류_상품발송장 => this.table분류_상품발송장;

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [Browsable(true)]
  public override SchemaSerializationMode SchemaSerializationMode
  {
    get => this._schemaSerializationMode;
    set => this._schemaSerializationMode = value;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public new DataTableCollection Tables => base.Tables;

  [DebuggerNonUserCode]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public new DataRelationCollection Relations => base.Relations;

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  protected override void InitializeDerivedDataSet()
  {
    this.BeginInit();
    this.InitClass();
    this.EndInit();
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  public override DataSet Clone()
  {
    분류_상품발송장 분류상품발송장 = (분류_상품발송장) base.Clone();
    분류상품발송장.InitVars();
    분류상품발송장.SchemaSerializationMode = this.SchemaSerializationMode;
    return (DataSet) 분류상품발송장;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  protected override bool ShouldSerializeTables() => false;

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  protected override bool ShouldSerializeRelations() => false;

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  protected override void ReadXmlSerializable(XmlReader reader)
  {
    if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
    {
      this.Reset();
      DataSet dataSet = new DataSet();
      int num = (int) dataSet.ReadXml(reader);
      if (dataSet.Tables[nameof (분류_상품발송장)] != null)
        base.Tables.Add((DataTable) new 분류_상품발송장.분류_상품발송장DataTable(dataSet.Tables[nameof (분류_상품발송장)]));
      this.DataSetName = dataSet.DataSetName;
      this.Prefix = dataSet.Prefix;
      this.Namespace = dataSet.Namespace;
      this.Locale = dataSet.Locale;
      this.CaseSensitive = dataSet.CaseSensitive;
      this.EnforceConstraints = dataSet.EnforceConstraints;
      this.Merge(dataSet, false, MissingSchemaAction.Add);
      this.InitVars();
    }
    else
    {
      int num = (int) this.ReadXml(reader);
      this.InitVars();
    }
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  protected override XmlSchema GetSchemaSerializable()
  {
    MemoryStream memoryStream = new MemoryStream();
    this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
    memoryStream.Position = 0L;
    return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  internal void InitVars() => this.InitVars(true);

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal void InitVars(bool initTable)
  {
    this.table분류_상품발송장 = (분류_상품발송장.분류_상품발송장DataTable) base.Tables[nameof (분류_상품발송장)];
    if (!initTable || this.table분류_상품발송장 == null)
      return;
    this.table분류_상품발송장.InitVars();
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  private void InitClass()
  {
    this.DataSetName = nameof (분류_상품발송장);
    this.Prefix = "";
    this.Namespace = "http://tempuri.org/분류_상품발송장.xsd";
    this.EnforceConstraints = true;
    this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
    this.table분류_상품발송장 = new 분류_상품발송장.분류_상품발송장DataTable();
    base.Tables.Add((DataTable) this.table분류_상품발송장);
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  [DebuggerNonUserCode]
  private bool ShouldSerialize_분류_상품발송장() => false;

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  private void SchemaChanged(object sender, CollectionChangeEventArgs e)
  {
    if (e.Action != CollectionChangeAction.Remove)
      return;
    this.InitVars();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
  {
    분류_상품발송장 분류상품발송장 = new 분류_상품발송장();
    XmlSchemaComplexType typedDataSetSchema = new XmlSchemaComplexType();
    XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
    xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
    {
      Namespace = 분류상품발송장.Namespace
    });
    typedDataSetSchema.Particle = (XmlSchemaParticle) xmlSchemaSequence;
    XmlSchema schemaSerializable = 분류상품발송장.GetSchemaSerializable();
    if (xs.Contains(schemaSerializable.TargetNamespace))
    {
      MemoryStream memoryStream1 = new MemoryStream();
      MemoryStream memoryStream2 = new MemoryStream();
      try
      {
        schemaSerializable.Write((Stream) memoryStream1);
        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
        while (enumerator.MoveNext())
        {
          XmlSchema current = (XmlSchema) enumerator.Current;
          memoryStream2.SetLength(0L);
          current.Write((Stream) memoryStream2);
          if (memoryStream1.Length == memoryStream2.Length)
          {
            memoryStream1.Position = 0L;
            memoryStream2.Position = 0L;
            do
              ;
            while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
            if (memoryStream1.Position == memoryStream1.Length)
              return typedDataSetSchema;
          }
        }
      }
      finally
      {
        memoryStream1?.Close();
        memoryStream2?.Close();
      }
    }
    xs.Add(schemaSerializable);
    return typedDataSetSchema;
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public delegate void 분류_상품발송장RowChangeEventHandler(
    object sender,
    분류_상품발송장.분류_상품발송장RowChangeEvent e);

  [XmlSchemaProvider("GetTypedTableSchema")]
  [Serializable]
  public class 분류_상품발송장DataTable : DataTable, IEnumerable
  {
    private DataColumn column슈트번호;
    private DataColumn column점코드;
    private DataColumn column점명;
    private DataColumn column01;
    private DataColumn column02;
    private DataColumn column03;
    private DataColumn column04;
    private DataColumn column05;
    private DataColumn column06;
    private DataColumn column07;
    private DataColumn column08;
    private DataColumn column09;
    private DataColumn column10;
    private DataColumn _columnC_T수;
    private DataColumn column총계;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public 분류_상품발송장DataTable()
    {
      this.TableName = nameof (분류_상품발송장);
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal 분류_상품발송장DataTable(DataTable table)
    {
      this.TableName = table.TableName;
      if (table.CaseSensitive != table.DataSet.CaseSensitive)
        this.CaseSensitive = table.CaseSensitive;
      if (table.Locale.ToString() != table.DataSet.Locale.ToString())
        this.Locale = table.Locale;
      if (table.Namespace != table.DataSet.Namespace)
        this.Namespace = table.Namespace;
      this.Prefix = table.Prefix;
      this.MinimumCapacity = table.MinimumCapacity;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected 분류_상품발송장DataTable(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn 슈트번호Column => this.column슈트번호;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn 점코드Column => this.column점코드;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn 점명Column => this.column점명;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _01Column => this.column01;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn _02Column => this.column02;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _03Column => this.column03;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _04Column => this.column04;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _05Column => this.column05;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn _06Column => this.column06;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _07Column => this.column07;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _08Column => this.column08;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public DataColumn _09Column => this.column09;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn _10Column => this.column10;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn _C_T수Column => this._columnC_T수;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataColumn 총계Column => this.column총계;

    [DebuggerNonUserCode]
    [Browsable(false)]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public int Count => this.Rows.Count;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public 분류_상품발송장.분류_상품발송장Row this[int index] => (분류_상품발송장.분류_상품발송장Row) this.Rows[index];

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public event 분류_상품발송장.분류_상품발송장RowChangeEventHandler 분류_상품발송장RowChanging;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public event 분류_상품발송장.분류_상품발송장RowChangeEventHandler 분류_상품발송장RowChanged;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public event 분류_상품발송장.분류_상품발송장RowChangeEventHandler 분류_상품발송장RowDeleting;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public event 분류_상품발송장.분류_상품발송장RowChangeEventHandler 분류_상품발송장RowDeleted;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Add분류_상품발송장Row(분류_상품발송장.분류_상품발송장Row row) => this.Rows.Add((DataRow) row);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public 분류_상품발송장.분류_상품발송장Row Add분류_상품발송장Row(
      string 슈트번호,
      string 점코드,
      string 점명,
      string _01,
      string _02,
      string _03,
      string _04,
      string _05,
      string _06,
      string _07,
      string _08,
      string _09,
      string _10,
      string _C_T수,
      string 총계)
    {
      분류_상품발송장.분류_상품발송장Row row = (분류_상품발송장.분류_상품발송장Row) this.NewRow();
      object[] objArray = new object[15]
      {
        (object) 슈트번호,
        (object) 점코드,
        (object) 점명,
        (object) _01,
        (object) _02,
        (object) _03,
        (object) _04,
        (object) _05,
        (object) _06,
        (object) _07,
        (object) _08,
        (object) _09,
        (object) _10,
        (object) _C_T수,
        (object) 총계
      };
      row.ItemArray = objArray;
      this.Rows.Add((DataRow) row);
      return row;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public virtual IEnumerator GetEnumerator() => this.Rows.GetEnumerator();

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public override DataTable Clone()
    {
      분류_상품발송장.분류_상품발송장DataTable 분류상품발송장DataTable = (분류_상품발송장.분류_상품발송장DataTable) base.Clone();
      분류상품발송장DataTable.InitVars();
      return (DataTable) 분류상품발송장DataTable;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override DataTable CreateInstance() => (DataTable) new 분류_상품발송장.분류_상품발송장DataTable();

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    internal void InitVars()
    {
      this.column슈트번호 = this.Columns["슈트번호"];
      this.column점코드 = this.Columns["점코드"];
      this.column점명 = this.Columns["점명"];
      this.column01 = this.Columns["01"];
      this.column02 = this.Columns["02"];
      this.column03 = this.Columns["03"];
      this.column04 = this.Columns["04"];
      this.column05 = this.Columns["05"];
      this.column06 = this.Columns["06"];
      this.column07 = this.Columns["07"];
      this.column08 = this.Columns["08"];
      this.column09 = this.Columns["09"];
      this.column10 = this.Columns["10"];
      this._columnC_T수 = this.Columns["C/T수"];
      this.column총계 = this.Columns["총계"];
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitClass()
    {
      this.column슈트번호 = new DataColumn("슈트번호", typeof (string), (string) null, MappingType.Element);
      this.Columns.Add(this.column슈트번호);
      this.column점코드 = new DataColumn("점코드", typeof (string), (string) null, MappingType.Element);
      this.Columns.Add(this.column점코드);
      this.column점명 = new DataColumn("점명", typeof (string), (string) null, MappingType.Element);
      this.Columns.Add(this.column점명);
      this.column01 = new DataColumn("01", typeof (string), (string) null, MappingType.Element);
      this.column01.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column01");
      this.column01.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "01");
      this.Columns.Add(this.column01);
      this.column02 = new DataColumn("02", typeof (string), (string) null, MappingType.Element);
      this.column02.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column02");
      this.column02.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "02");
      this.Columns.Add(this.column02);
      this.column03 = new DataColumn("03", typeof (string), (string) null, MappingType.Element);
      this.column03.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column03");
      this.column03.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "03");
      this.Columns.Add(this.column03);
      this.column04 = new DataColumn("04", typeof (string), (string) null, MappingType.Element);
      this.column04.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column04");
      this.column04.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "04");
      this.Columns.Add(this.column04);
      this.column05 = new DataColumn("05", typeof (string), (string) null, MappingType.Element);
      this.column05.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column05");
      this.column05.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "05");
      this.Columns.Add(this.column05);
      this.column06 = new DataColumn("06", typeof (string), (string) null, MappingType.Element);
      this.column06.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column06");
      this.column06.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "06");
      this.Columns.Add(this.column06);
      this.column07 = new DataColumn("07", typeof (string), (string) null, MappingType.Element);
      this.column07.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column07");
      this.column07.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "07");
      this.Columns.Add(this.column07);
      this.column08 = new DataColumn("08", typeof (string), (string) null, MappingType.Element);
      this.column08.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column08");
      this.column08.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "08");
      this.Columns.Add(this.column08);
      this.column09 = new DataColumn("09", typeof (string), (string) null, MappingType.Element);
      this.column09.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column09");
      this.column09.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "09");
      this.Columns.Add(this.column09);
      this.column10 = new DataColumn("10", typeof (string), (string) null, MappingType.Element);
      this.column10.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "column10");
      this.column10.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "10");
      this.Columns.Add(this.column10);
      this._columnC_T수 = new DataColumn("C/T수", typeof (string), (string) null, MappingType.Element);
      this._columnC_T수.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "_columnC_T수");
      this._columnC_T수.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "C/T수");
      this.Columns.Add(this._columnC_T수);
      this.column총계 = new DataColumn("총계", typeof (string), (string) null, MappingType.Element);
      this.Columns.Add(this.column총계);
      this.ExtendedProperties.Add((object) "Generator_TablePropName", (object) "_분류_상품발송장");
      this.ExtendedProperties.Add((object) "Generator_UserTableName", (object) nameof (분류_상품발송장));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public 분류_상품발송장.분류_상품발송장Row New분류_상품발송장Row() => (분류_상품발송장.분류_상품발송장Row) this.NewRow();

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
    {
      return (DataRow) new 분류_상품발송장.분류_상품발송장Row(builder);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override Type GetRowType() => typeof (분류_상품발송장.분류_상품발송장Row);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override void OnRowChanged(DataRowChangeEventArgs e)
    {
      base.OnRowChanged(e);
      if (this.분류_상품발송장RowChanged == null)
        return;
      this.분류_상품발송장RowChanged((object) this, new 분류_상품발송장.분류_상품발송장RowChangeEvent((분류_상품발송장.분류_상품발송장Row) e.Row, e.Action));
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override void OnRowChanging(DataRowChangeEventArgs e)
    {
      base.OnRowChanging(e);
      if (this.분류_상품발송장RowChanging == null)
        return;
      this.분류_상품발송장RowChanging((object) this, new 분류_상품발송장.분류_상품발송장RowChangeEvent((분류_상품발송장.분류_상품발송장Row) e.Row, e.Action));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override void OnRowDeleted(DataRowChangeEventArgs e)
    {
      base.OnRowDeleted(e);
      if (this.분류_상품발송장RowDeleted == null)
        return;
      this.분류_상품발송장RowDeleted((object) this, new 분류_상품발송장.분류_상품발송장RowChangeEvent((분류_상품발송장.분류_상품발송장Row) e.Row, e.Action));
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    protected override void OnRowDeleting(DataRowChangeEventArgs e)
    {
      base.OnRowDeleting(e);
      if (this.분류_상품발송장RowDeleting == null)
        return;
      this.분류_상품발송장RowDeleting((object) this, new 분류_상품발송장.분류_상품발송장RowChangeEvent((분류_상품발송장.분류_상품발송장Row) e.Row, e.Action));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Remove분류_상품발송장Row(분류_상품발송장.분류_상품발송장Row row) => this.Rows.Remove((DataRow) row);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
    {
      XmlSchemaComplexType typedTableSchema = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      분류_상품발송장 분류상품발송장 = new 분류_상품발송장();
      XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
      xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
      xmlSchemaAny1.MinOccurs = 0M;
      xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
      xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
      xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
      XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
      xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
      xmlSchemaAny2.MinOccurs = 1M;
      xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
      xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
      typedTableSchema.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
      {
        Name = "namespace",
        FixedValue = 분류상품발송장.Namespace
      });
      typedTableSchema.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
      {
        Name = "tableTypeName",
        FixedValue = nameof (분류_상품발송장DataTable)
      });
      typedTableSchema.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = 분류상품발송장.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return typedTableSchema;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return typedTableSchema;
    }
  }

  public class 분류_상품발송장Row : DataRow
  {
    private 분류_상품발송장.분류_상품발송장DataTable table분류_상품발송장;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal 분류_상품발송장Row(DataRowBuilder rb)
      : base(rb)
    {
      this.table분류_상품발송장 = (분류_상품발송장.분류_상품발송장DataTable) this.Table;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string 슈트번호
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장.슈트번호Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '슈트번호' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장.슈트번호Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string 점코드
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장.점코드Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '점코드' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장.점코드Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string 점명
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장.점명Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '점명' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장.점명Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _01
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._01Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '01' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._01Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _02
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._02Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '02' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._02Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string _03
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._03Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '03' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._03Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string _04
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._04Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '04' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._04Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _05
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._05Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '05' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._05Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string _06
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._06Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '06' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._06Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _07
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._07Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '07' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._07Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _08
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._08Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '08' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._08Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string _09
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._09Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '09' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._09Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _10
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._10Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '10' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._10Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public string _C_T수
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장._C_T수Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 'C/T수' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장._C_T수Column] = (object) value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public string 총계
    {
      get
      {
        try
        {
          return (string) this[this.table분류_상품발송장.총계Column];
        }
        catch (InvalidCastException ex)
        {
          throw new StrongTypingException("'분류_상품발송장' 테이블의 '총계' 열의 값이 DBNull입니다.", (Exception) ex);
        }
      }
      set => this[this.table분류_상품발송장.총계Column] = (object) value;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is슈트번호Null() => this.IsNull(this.table분류_상품발송장.슈트번호Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set슈트번호Null() => this[this.table분류_상품발송장.슈트번호Column] = Convert.DBNull;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public bool Is점코드Null() => this.IsNull(this.table분류_상품발송장.점코드Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set점코드Null() => this[this.table분류_상품발송장.점코드Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is점명Null() => this.IsNull(this.table분류_상품발송장.점명Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set점명Null() => this[this.table분류_상품발송장.점명Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_01Null() => this.IsNull(this.table분류_상품발송장._01Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_01Null() => this[this.table분류_상품발송장._01Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_02Null() => this.IsNull(this.table분류_상품발송장._02Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set_02Null() => this[this.table분류_상품발송장._02Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_03Null() => this.IsNull(this.table분류_상품발송장._03Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set_03Null() => this[this.table분류_상품발송장._03Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_04Null() => this.IsNull(this.table분류_상품발송장._04Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_04Null() => this[this.table분류_상품발송장._04Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_05Null() => this.IsNull(this.table분류_상품발송장._05Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set_05Null() => this[this.table분류_상품발송장._05Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_06Null() => this.IsNull(this.table분류_상품발송장._06Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set_06Null() => this[this.table분류_상품발송장._06Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_07Null() => this.IsNull(this.table분류_상품발송장._07Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_07Null() => this[this.table분류_상품발송장._07Column] = Convert.DBNull;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public bool Is_08Null() => this.IsNull(this.table분류_상품발송장._08Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_08Null() => this[this.table분류_상품발송장._08Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_09Null() => this.IsNull(this.table분류_상품발송장._09Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_09Null() => this[this.table분류_상품발송장._09Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_10Null() => this.IsNull(this.table분류_상품발송장._10Column);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public void Set_10Null() => this[this.table분류_상품발송장._10Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is_C_T수Null() => this.IsNull(this.table분류_상품발송장._C_T수Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set_C_T수Null() => this[this.table분류_상품발송장._C_T수Column] = Convert.DBNull;

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DebuggerNonUserCode]
    public bool Is총계Null() => this.IsNull(this.table분류_상품발송장.총계Column);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public void Set총계Null() => this[this.table분류_상품발송장.총계Column] = Convert.DBNull;
  }

  [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
  public class 분류_상품발송장RowChangeEvent : EventArgs
  {
    private 분류_상품발송장.분류_상품발송장Row eventRow;
    private DataRowAction eventAction;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public 분류_상품발송장RowChangeEvent(분류_상품발송장.분류_상품발송장Row row, DataRowAction action)
    {
      this.eventRow = row;
      this.eventAction = action;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public 분류_상품발송장.분류_상품발송장Row Row => this.eventRow;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public DataRowAction Action => this.eventAction;
  }
}
