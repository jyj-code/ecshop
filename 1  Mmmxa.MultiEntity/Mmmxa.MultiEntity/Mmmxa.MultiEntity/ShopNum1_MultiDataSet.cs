namespace ShopNum1MultiEntity
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    [Serializable, XmlSchemaProvider("GetTypedDataSetSchema"), DesignerCategory("code"), GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), HelpKeyword("vs.data.DataSet"), ToolboxItem(true), XmlRoot("ShopNum1_MultiDataSet")]
    public class ShopNum1_MultiDataSet : DataSet
    {
        private System.Data.SchemaSerializationMode _schemaSerializationMode;
        private ShopNum1_ShopInfoDataTable tableShopNum1_ShopInfo;

        [DebuggerNonUserCode]
        public ShopNum1_MultiDataSet()
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += handler;
            base.Relations.CollectionChanged += handler;
            base.EndInit();
        }

        [DebuggerNonUserCode]
        protected ShopNum1_MultiDataSet(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            this._schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler handler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += handler;
                this.Relations.CollectionChanged += handler;
            }
            else
            {
                string s = (string) info.GetValue("XmlSchema", typeof(string));
                if (base.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                    if (dataSet.Tables["ShopNum1_ShopInfo"] != null)
                    {
                        base.Tables.Add(new ShopNum1_ShopInfoDataTable(dataSet.Tables["ShopNum1_ShopInfo"]));
                    }
                    base.DataSetName = dataSet.DataSetName;
                    base.Prefix = dataSet.Prefix;
                    base.Namespace = dataSet.Namespace;
                    base.Locale = dataSet.Locale;
                    base.CaseSensitive = dataSet.CaseSensitive;
                    base.EnforceConstraints = dataSet.EnforceConstraints;
                    base.Merge(dataSet, false, MissingSchemaAction.Add);
                    this.InitVars();
                }
                else
                {
                    base.ReadXmlSchema(new XmlTextReader(new StringReader(s)));
                }
                base.GetSerializationData(info, context);
                CollectionChangeEventHandler handler2 = new CollectionChangeEventHandler(this.SchemaChanged);
                base.Tables.CollectionChanged += handler2;
                this.Relations.CollectionChanged += handler2;
            }
        }

        [DebuggerNonUserCode]
        public override DataSet Clone()
        {
            ShopNum1_MultiDataSet set = (ShopNum1_MultiDataSet) base.Clone();
            set.InitVars();
            set.SchemaSerializationMode = this.SchemaSerializationMode;
            return set;
        }

        [DebuggerNonUserCode]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream w = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(w, null));
            w.Position = 0L;
            return XmlSchema.Read(new XmlTextReader(w), null);
        }

        [DebuggerNonUserCode]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            ShopNum1_MultiDataSet set = new ShopNum1_MultiDataSet();
            XmlSchemaComplexType type = new XmlSchemaComplexType();
            XmlSchemaSequence sequence = new XmlSchemaSequence();
            XmlSchemaAny item = new XmlSchemaAny();
            item.Namespace = set.Namespace;
            sequence.Items.Add(item);
            type.Particle = sequence;
            XmlSchema schemaSerializable = set.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream stream = new MemoryStream();
                MemoryStream stream2 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(stream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema) enumerator.Current;
                        stream2.SetLength(0L);
                        current.Write(stream2);
                        if (stream.Length != stream2.Length)
                        {
                            continue;
                        }
                        stream.Position = 0L;
                        stream2.Position = 0L;
                        while (stream.Position == stream.Length)
                        {
                        Label_00E7:
                            if (0 == 0)
                            {
                                goto Label_010F;
                            }
                        }
                        //goto Label_00E7;
                    Label_010F:
                        if (stream.Position == stream.Length)
                        {
                            return type;
                        }
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            xs.Add(schemaSerializable);
            return type;
        }

        [DebuggerNonUserCode]
        private void InitClass()
        {
            base.DataSetName = "ShopNum1_MultiDataSet";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/ShopNum1_MultiDataSet.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableShopNum1_ShopInfo = new ShopNum1_ShopInfoDataTable();
            base.Tables.Add(this.tableShopNum1_ShopInfo);
        }

        [DebuggerNonUserCode]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        internal void InitVars(bool initTable)
        {
            this.tableShopNum1_ShopInfo = (ShopNum1_ShopInfoDataTable) base.Tables["ShopNum1_ShopInfo"];
            if (initTable && (this.tableShopNum1_ShopInfo != null))
            {
                this.tableShopNum1_ShopInfo.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)
            {
                this.Reset();
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(reader);
                if (dataSet.Tables["ShopNum1_ShopInfo"] != null)
                {
                    base.Tables.Add(new ShopNum1_ShopInfoDataTable(dataSet.Tables["ShopNum1_ShopInfo"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            else
            {
                base.ReadXml(reader);
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        private bool ShouldSerializeShopNum1_ShopInfo()
        {
            return false;
        }

        [DebuggerNonUserCode]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DebuggerNonUserCode]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), DebuggerNonUserCode]
        public ShopNum1_ShopInfoDataTable ShopNum1_ShopInfo
        {
            get
            {
                return this.tableShopNum1_ShopInfo;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DebuggerNonUserCode]
        public DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [Serializable, GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0"), XmlSchemaProvider("GetTypedTableSchema")]
        public class ShopNum1_ShopInfoDataTable : TypedTableBase<ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow>
        {
            private DataColumn columnAddress;
            private DataColumn columnApplyTime;
            private DataColumn columnBanner;
            private DataColumn columnClickCount;
            private DataColumn columnCollectCount;
            private DataColumn columnGuid;
            private DataColumn columnIsAudit;
            private DataColumn columnIsDeleted;
            private DataColumn columnIsHot;
            private DataColumn columnIsRecommend;
            private DataColumn columnIsVisits_;
            private DataColumn columnMemberLoginID;
            private DataColumn columnMemo;
            private DataColumn columnModifyTime;
            private DataColumn columnModifyUser;
            private DataColumn columnName;
            private DataColumn columnOpenTime;
            private DataColumn columnRegionCode;
            private DataColumn columnSalesRange;
            private DataColumn columnShopCategoryID;

            public event ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEventHandler ShopNum1_ShopInfoRowChanged;

            public event ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEventHandler ShopNum1_ShopInfoRowChanging;

            public event ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEventHandler ShopNum1_ShopInfoRowDeleted;

            public event ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEventHandler ShopNum1_ShopInfoRowDeleting;

            [DebuggerNonUserCode]
            public ShopNum1_ShopInfoDataTable()
            {
                base.TableName = "ShopNum1_ShopInfo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            internal ShopNum1_ShopInfoDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            protected ShopNum1_ShopInfoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            public void AddShopNum1_ShopInfoRow(ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            public ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow AddShopNum1_ShopInfoRow(Guid Guid, string Name, string SalesRange, string Address, string Memo, string Banner, int ClickCount, int CollectCount, DateTime ApplyTime, DateTime OpenTime, string ModifyUser, DateTime ModifyTime, int IsAudit, int IsDeleted, string ShopCategoryID, string MemberLoginID, string RegionCode, int IsHot, int IsRecommend, int IsVisits_)
            {
                ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow row = (ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) base.NewRow();
                row.ItemArray = new object[] { 
                    Guid, Name, SalesRange, Address, Memo, Banner, ClickCount, CollectCount, ApplyTime, OpenTime, ModifyUser, ModifyTime, IsAudit, IsDeleted, ShopCategoryID, MemberLoginID, 
                    RegionCode, IsHot, IsRecommend, IsVisits_
                 };
                base.Rows.Add(row);
                return row;
            }

            [DebuggerNonUserCode]
            public override DataTable Clone()
            {
                ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable table = (ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable) base.Clone();
                table.InitVars();
                return table;
            }

            [DebuggerNonUserCode]
            protected override DataTable CreateInstance()
            {
                return new ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable();
            }

            [DebuggerNonUserCode]
            public ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow FindByGuid(Guid Guid)
            {
                return (ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) base.Rows.Find(new object[] { Guid });
            }

            [DebuggerNonUserCode]
            protected override Type GetRowType()
            {
                return typeof(ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow);
            }

            [DebuggerNonUserCode]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType type = new XmlSchemaComplexType();
                XmlSchemaSequence sequence = new XmlSchemaSequence();
                ShopNum1_MultiDataSet set = new ShopNum1_MultiDataSet();
                XmlSchemaAny item = new XmlSchemaAny();
                item.Namespace = "http://www.w3.org/2001/XMLSchema";
                item.MinOccurs = 0M;
                item.MaxOccurs = 79228162514264337593543950335M;
                item.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(item);
                XmlSchemaAny any2 = new XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = 1M;
                any2.ProcessContents = XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                XmlSchemaAttribute attribute = new XmlSchemaAttribute();
                attribute.Name = "namespace";
                attribute.FixedValue = set.Namespace;
                type.Attributes.Add(attribute);
                XmlSchemaAttribute attribute2 = new XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "ShopNum1_ShopInfoDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                XmlSchema schemaSerializable = set.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream stream = new MemoryStream();
                    MemoryStream stream2 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(stream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema) enumerator.Current;
                            stream2.SetLength(0L);
                            current.Write(stream2);
                            if (stream.Length != stream2.Length)
                            {
                                continue;
                            }
                            stream.Position = 0L;
                            stream2.Position = 0L;
                            while (stream.Position == stream.Length)
                            {
                            Label_019A:
                                if (0 == 0)
                                {
                                    goto Label_01C2;
                                }
                            }
                            //goto Label_019A;
                        Label_01C2:
                            if (stream.Position == stream.Length)
                            {
                                return type;
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (stream2 != null)
                        {
                            stream2.Close();
                        }
                    }
                }
                xs.Add(schemaSerializable);
                return type;
            }

            [DebuggerNonUserCode]
            private void InitClass()
            {
                this.columnGuid = new DataColumn("Guid", typeof(Guid), null, MappingType.Element);
                base.Columns.Add(this.columnGuid);
                this.columnName = new DataColumn("Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnName);
                this.columnSalesRange = new DataColumn("SalesRange", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSalesRange);
                this.columnAddress = new DataColumn("Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnAddress);
                this.columnMemo = new DataColumn("Memo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMemo);
                this.columnBanner = new DataColumn("Banner", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBanner);
                this.columnClickCount = new DataColumn("ClickCount", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnClickCount);
                this.columnCollectCount = new DataColumn("CollectCount", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCollectCount);
                this.columnApplyTime = new DataColumn("ApplyTime", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnApplyTime);
                this.columnOpenTime = new DataColumn("OpenTime", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnOpenTime);
                this.columnModifyUser = new DataColumn("ModifyUser", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnModifyUser);
                this.columnModifyTime = new DataColumn("ModifyTime", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnModifyTime);
                this.columnIsAudit = new DataColumn("IsAudit", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIsAudit);
                this.columnIsDeleted = new DataColumn("IsDeleted", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIsDeleted);
                this.columnShopCategoryID = new DataColumn("ShopCategoryID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnShopCategoryID);
                this.columnMemberLoginID = new DataColumn("MemberLoginID", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnMemberLoginID);
                this.columnRegionCode = new DataColumn("RegionCode", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRegionCode);
                this.columnIsHot = new DataColumn("IsHot", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIsHot);
                this.columnIsRecommend = new DataColumn("IsRecommend", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIsRecommend);
                this.columnIsVisits_ = new DataColumn("IsVisits ", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnIsVisits_);
                base.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] { this.columnGuid }, true));
                this.columnGuid.AllowDBNull = false;
                this.columnGuid.Unique = true;
                this.columnName.AllowDBNull = false;
                this.columnName.MaxLength = 50;
                this.columnSalesRange.AllowDBNull = false;
                this.columnSalesRange.MaxLength = 150;
                this.columnAddress.AllowDBNull = false;
                this.columnAddress.MaxLength = 150;
                this.columnMemo.AllowDBNull = false;
                this.columnMemo.MaxLength = 150;
                this.columnBanner.MaxLength = 250;
                this.columnCollectCount.AllowDBNull = false;
                this.columnApplyTime.AllowDBNull = false;
                this.columnOpenTime.AllowDBNull = false;
                this.columnModifyUser.AllowDBNull = false;
                this.columnModifyUser.MaxLength = 50;
                this.columnModifyTime.AllowDBNull = false;
                this.columnIsAudit.AllowDBNull = false;
                this.columnIsDeleted.AllowDBNull = false;
                this.columnShopCategoryID.AllowDBNull = false;
                this.columnShopCategoryID.MaxLength = 9;
                this.columnMemberLoginID.AllowDBNull = false;
                this.columnMemberLoginID.MaxLength = 50;
                this.columnRegionCode.AllowDBNull = false;
                this.columnRegionCode.MaxLength = 150;
                this.columnIsHot.AllowDBNull = false;
                this.columnIsRecommend.AllowDBNull = false;
                this.columnIsVisits_.AllowDBNull = false;
            }

            [DebuggerNonUserCode]
            internal void InitVars()
            {
                this.columnGuid = base.Columns["Guid"];
                this.columnName = base.Columns["Name"];
                this.columnSalesRange = base.Columns["SalesRange"];
                this.columnAddress = base.Columns["Address"];
                this.columnMemo = base.Columns["Memo"];
                this.columnBanner = base.Columns["Banner"];
                this.columnClickCount = base.Columns["ClickCount"];
                this.columnCollectCount = base.Columns["CollectCount"];
                this.columnApplyTime = base.Columns["ApplyTime"];
                this.columnOpenTime = base.Columns["OpenTime"];
                this.columnModifyUser = base.Columns["ModifyUser"];
                this.columnModifyTime = base.Columns["ModifyTime"];
                this.columnIsAudit = base.Columns["IsAudit"];
                this.columnIsDeleted = base.Columns["IsDeleted"];
                this.columnShopCategoryID = base.Columns["ShopCategoryID"];
                this.columnMemberLoginID = base.Columns["MemberLoginID"];
                this.columnRegionCode = base.Columns["RegionCode"];
                this.columnIsHot = base.Columns["IsHot"];
                this.columnIsRecommend = base.Columns["IsRecommend"];
                this.columnIsVisits_ = base.Columns["IsVisits "];
            }

            [DebuggerNonUserCode]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow(builder);
            }

            [DebuggerNonUserCode]
            public ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow NewShopNum1_ShopInfoRow()
            {
                return (ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) base.NewRow();
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.ShopNum1_ShopInfoRowChanged != null)
                {
                    this.ShopNum1_ShopInfoRowChanged(this, new ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEvent((ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.ShopNum1_ShopInfoRowChanging != null)
                {
                    this.ShopNum1_ShopInfoRowChanging(this, new ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEvent((ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.ShopNum1_ShopInfoRowDeleted != null)
                {
                    this.ShopNum1_ShopInfoRowDeleted(this, new ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEvent((ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.ShopNum1_ShopInfoRowDeleting != null)
                {
                    this.ShopNum1_ShopInfoRowDeleting(this, new ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEvent((ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            public void RemoveShopNum1_ShopInfoRow(ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow row)
            {
                base.Rows.Remove(row);
            }

            [DebuggerNonUserCode]
            public DataColumn AddressColumn
            {
                get
                {
                    return this.columnAddress;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ApplyTimeColumn
            {
                get
                {
                    return this.columnApplyTime;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn BannerColumn
            {
                get
                {
                    return this.columnBanner;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ClickCountColumn
            {
                get
                {
                    return this.columnClickCount;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn CollectCountColumn
            {
                get
                {
                    return this.columnCollectCount;
                }
            }

            [DebuggerNonUserCode, Browsable(false)]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn GuidColumn
            {
                get
                {
                    return this.columnGuid;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsAuditColumn
            {
                get
                {
                    return this.columnIsAudit;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsDeletedColumn
            {
                get
                {
                    return this.columnIsDeleted;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsHotColumn
            {
                get
                {
                    return this.columnIsHot;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsRecommendColumn
            {
                get
                {
                    return this.columnIsRecommend;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn IsVisits_Column
            {
                get
                {
                    return this.columnIsVisits_;
                }
            }

            [DebuggerNonUserCode]
            public ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow this[int index]
            {
                get
                {
                    return (ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow) base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            public DataColumn MemberLoginIDColumn
            {
                get
                {
                    return this.columnMemberLoginID;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn MemoColumn
            {
                get
                {
                    return this.columnMemo;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ModifyTimeColumn
            {
                get
                {
                    return this.columnModifyTime;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ModifyUserColumn
            {
                get
                {
                    return this.columnModifyUser;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn NameColumn
            {
                get
                {
                    return this.columnName;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn OpenTimeColumn
            {
                get
                {
                    return this.columnOpenTime;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn RegionCodeColumn
            {
                get
                {
                    return this.columnRegionCode;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn SalesRangeColumn
            {
                get
                {
                    return this.columnSalesRange;
                }
            }

            [DebuggerNonUserCode]
            public DataColumn ShopCategoryIDColumn
            {
                get
                {
                    return this.columnShopCategoryID;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class ShopNum1_ShopInfoRow : DataRow
        {
            private ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable tableShopNum1_ShopInfo;

            [DebuggerNonUserCode]
            internal ShopNum1_ShopInfoRow(DataRowBuilder rb) : base(rb)
            {
                this.tableShopNum1_ShopInfo = (ShopNum1_MultiDataSet.ShopNum1_ShopInfoDataTable) base.Table;
            }

            [DebuggerNonUserCode]
            public bool IsBannerNull()
            {
                return base.IsNull(this.tableShopNum1_ShopInfo.BannerColumn);
            }

            [DebuggerNonUserCode]
            public bool IsClickCountNull()
            {
                return base.IsNull(this.tableShopNum1_ShopInfo.ClickCountColumn);
            }

            [DebuggerNonUserCode]
            public void SetBannerNull()
            {
                base[this.tableShopNum1_ShopInfo.BannerColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public void SetClickCountNull()
            {
                base[this.tableShopNum1_ShopInfo.ClickCountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            public string Address
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.AddressColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime ApplyTime
            {
                get
                {
                    return (DateTime) base[this.tableShopNum1_ShopInfo.ApplyTimeColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.ApplyTimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Banner
            {
                get
                {
                    string str;
                    try
                    {
                        str = (string) base[this.tableShopNum1_ShopInfo.BannerColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'Banner' in table 'ShopNum1_ShopInfo' is DBNull.", exception);
                    }
                    return str;
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.BannerColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int ClickCount
            {
                get
                {
                    int num;
                    try
                    {
                        num = (int) base[this.tableShopNum1_ShopInfo.ClickCountColumn];
                    }
                    catch (InvalidCastException exception)
                    {
                        throw new StrongTypingException("The value for column 'ClickCount' in table 'ShopNum1_ShopInfo' is DBNull.", exception);
                    }
                    return num;
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.ClickCountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int CollectCount
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.CollectCountColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.CollectCountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public System.Guid Guid
            {
                get
                {
                    return (System.Guid) base[this.tableShopNum1_ShopInfo.GuidColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.GuidColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IsAudit
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.IsAuditColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.IsAuditColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IsDeleted
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.IsDeletedColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.IsDeletedColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IsHot
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.IsHotColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.IsHotColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IsRecommend
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.IsRecommendColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.IsRecommendColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public int IsVisits_
            {
                get
                {
                    return (int) base[this.tableShopNum1_ShopInfo.IsVisits_Column];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.IsVisits_Column] = value;
                }
            }

            [DebuggerNonUserCode]
            public string MemberLoginID
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.MemberLoginIDColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.MemberLoginIDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Memo
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.MemoColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.MemoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime ModifyTime
            {
                get
                {
                    return (DateTime) base[this.tableShopNum1_ShopInfo.ModifyTimeColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.ModifyTimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string ModifyUser
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.ModifyUserColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.ModifyUserColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string Name
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.NameColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public DateTime OpenTime
            {
                get
                {
                    return (DateTime) base[this.tableShopNum1_ShopInfo.OpenTimeColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.OpenTimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string RegionCode
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.RegionCodeColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.RegionCodeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string SalesRange
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.SalesRangeColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.SalesRangeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            public string ShopCategoryID
            {
                get
                {
                    return (string) base[this.tableShopNum1_ShopInfo.ShopCategoryIDColumn];
                }
                set
                {
                    base[this.tableShopNum1_ShopInfo.ShopCategoryIDColumn] = value;
                }
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class ShopNum1_ShopInfoRowChangeEvent : EventArgs
        {
            private DataRowAction eventAction;
            private ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow eventRow;

            [DebuggerNonUserCode]
            public ShopNum1_ShopInfoRowChangeEvent(ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }

            [DebuggerNonUserCode]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            public ShopNum1_MultiDataSet.ShopNum1_ShopInfoRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }
        }

        public delegate void ShopNum1_ShopInfoRowChangeEventHandler(object sender, ShopNum1_MultiDataSet.ShopNum1_ShopInfoRowChangeEvent e);
    }
}

