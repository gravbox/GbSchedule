﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace MSAccess {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("GravityboxDataset")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class GravityboxDataset : System.Data.DataSet {
        
        private APPOINTMENTDataTable tableAPPOINTMENT;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public GravityboxDataset() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected GravityboxDataset(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["APPOINTMENT"] != null)) {
                    base.Tables.Add(new APPOINTMENTDataTable(ds.Tables["APPOINTMENT"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public APPOINTMENTDataTable APPOINTMENT {
            get {
                return this.tableAPPOINTMENT;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override System.Data.DataSet Clone() {
            GravityboxDataset cln = ((GravityboxDataset)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["APPOINTMENT"] != null)) {
                    base.Tables.Add(new APPOINTMENTDataTable(ds.Tables["APPOINTMENT"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableAPPOINTMENT = ((APPOINTMENTDataTable)(base.Tables["APPOINTMENT"]));
            if ((initTable == true)) {
                if ((this.tableAPPOINTMENT != null)) {
                    this.tableAPPOINTMENT.InitVars();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "GravityboxDataset";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/GravityboxDataset.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableAPPOINTMENT = new APPOINTMENTDataTable();
            base.Tables.Add(this.tableAPPOINTMENT);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeAPPOINTMENT() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            GravityboxDataset ds = new GravityboxDataset();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void APPOINTMENTRowChangeEventHandler(object sender, APPOINTMENTRowChangeEvent e);
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class APPOINTMENTDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnappointment_guid;
            
            private System.Data.DataColumn columnstart_date;
            
            private System.Data.DataColumn columnstart_time;
            
            private System.Data.DataColumn columnlength;
            
            private System.Data.DataColumn columnrecurrence_guid;
            
            private System.Data.DataColumn columnsubject;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTDataTable() {
                this.TableName = "APPOINTMENT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal APPOINTMENTDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected APPOINTMENTDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn appointment_guidColumn {
                get {
                    return this.columnappointment_guid;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn start_dateColumn {
                get {
                    return this.columnstart_date;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn start_timeColumn {
                get {
                    return this.columnstart_time;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn lengthColumn {
                get {
                    return this.columnlength;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn recurrence_guidColumn {
                get {
                    return this.columnrecurrence_guid;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn subjectColumn {
                get {
                    return this.columnsubject;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRow this[int index] {
                get {
                    return ((APPOINTMENTRow)(this.Rows[index]));
                }
            }
            
            public event APPOINTMENTRowChangeEventHandler APPOINTMENTRowChanging;
            
            public event APPOINTMENTRowChangeEventHandler APPOINTMENTRowChanged;
            
            public event APPOINTMENTRowChangeEventHandler APPOINTMENTRowDeleting;
            
            public event APPOINTMENTRowChangeEventHandler APPOINTMENTRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddAPPOINTMENTRow(APPOINTMENTRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRow AddAPPOINTMENTRow(string appointment_guid, System.DateTime start_date, System.DateTime start_time, int length, string recurrence_guid, string subject) {
                APPOINTMENTRow rowAPPOINTMENTRow = ((APPOINTMENTRow)(this.NewRow()));
                rowAPPOINTMENTRow.ItemArray = new object[] {
                        appointment_guid,
                        start_date,
                        start_time,
                        length,
                        recurrence_guid,
                        subject};
                this.Rows.Add(rowAPPOINTMENTRow);
                return rowAPPOINTMENTRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRow FindByappointment_guid(string appointment_guid) {
                return ((APPOINTMENTRow)(this.Rows.Find(new object[] {
                            appointment_guid})));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                APPOINTMENTDataTable cln = ((APPOINTMENTDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new APPOINTMENTDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnappointment_guid = base.Columns["appointment_guid"];
                this.columnstart_date = base.Columns["start_date"];
                this.columnstart_time = base.Columns["start_time"];
                this.columnlength = base.Columns["length"];
                this.columnrecurrence_guid = base.Columns["recurrence_guid"];
                this.columnsubject = base.Columns["subject"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnappointment_guid = new System.Data.DataColumn("appointment_guid", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnappointment_guid);
                this.columnstart_date = new System.Data.DataColumn("start_date", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnstart_date);
                this.columnstart_time = new System.Data.DataColumn("start_time", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnstart_time);
                this.columnlength = new System.Data.DataColumn("length", typeof(int), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnlength);
                this.columnrecurrence_guid = new System.Data.DataColumn("recurrence_guid", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnrecurrence_guid);
                this.columnsubject = new System.Data.DataColumn("subject", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnsubject);
                this.Constraints.Add(new System.Data.UniqueConstraint("GravityboxDatasetKey1", new System.Data.DataColumn[] {
                                this.columnappointment_guid}, true));
                this.columnappointment_guid.AllowDBNull = false;
                this.columnappointment_guid.Unique = true;
                this.columnstart_date.AllowDBNull = false;
                this.columnstart_time.AllowDBNull = false;
                this.columnlength.AllowDBNull = false;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRow NewAPPOINTMENTRow() {
                return ((APPOINTMENTRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new APPOINTMENTRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(APPOINTMENTRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.APPOINTMENTRowChanged != null)) {
                    this.APPOINTMENTRowChanged(this, new APPOINTMENTRowChangeEvent(((APPOINTMENTRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.APPOINTMENTRowChanging != null)) {
                    this.APPOINTMENTRowChanging(this, new APPOINTMENTRowChangeEvent(((APPOINTMENTRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.APPOINTMENTRowDeleted != null)) {
                    this.APPOINTMENTRowDeleted(this, new APPOINTMENTRowChangeEvent(((APPOINTMENTRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.APPOINTMENTRowDeleting != null)) {
                    this.APPOINTMENTRowDeleting(this, new APPOINTMENTRowChangeEvent(((APPOINTMENTRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveAPPOINTMENTRow(APPOINTMENTRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                GravityboxDataset ds = new GravityboxDataset();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "APPOINTMENTDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class APPOINTMENTRow : System.Data.DataRow {
            
            private APPOINTMENTDataTable tableAPPOINTMENT;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal APPOINTMENTRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableAPPOINTMENT = ((APPOINTMENTDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string appointment_guid {
                get {
                    return ((string)(this[this.tableAPPOINTMENT.appointment_guidColumn]));
                }
                set {
                    this[this.tableAPPOINTMENT.appointment_guidColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime start_date {
                get {
                    return ((System.DateTime)(this[this.tableAPPOINTMENT.start_dateColumn]));
                }
                set {
                    this[this.tableAPPOINTMENT.start_dateColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime start_time {
                get {
                    return ((System.DateTime)(this[this.tableAPPOINTMENT.start_timeColumn]));
                }
                set {
                    this[this.tableAPPOINTMENT.start_timeColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int length {
                get {
                    return ((int)(this[this.tableAPPOINTMENT.lengthColumn]));
                }
                set {
                    this[this.tableAPPOINTMENT.lengthColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string recurrence_guid {
                get {
                    try {
                        return ((string)(this[this.tableAPPOINTMENT.recurrence_guidColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'recurrence_guid\' in table \'APPOINTMENT\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableAPPOINTMENT.recurrence_guidColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string subject {
                get {
                    try {
                        return ((string)(this[this.tableAPPOINTMENT.subjectColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'subject\' in table \'APPOINTMENT\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableAPPOINTMENT.subjectColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool Isrecurrence_guidNull() {
                return this.IsNull(this.tableAPPOINTMENT.recurrence_guidColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void Setrecurrence_guidNull() {
                this[this.tableAPPOINTMENT.recurrence_guidColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IssubjectNull() {
                return this.IsNull(this.tableAPPOINTMENT.subjectColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetsubjectNull() {
                this[this.tableAPPOINTMENT.subjectColumn] = System.Convert.DBNull;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class APPOINTMENTRowChangeEvent : System.EventArgs {
            
            private APPOINTMENTRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRowChangeEvent(APPOINTMENTRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public APPOINTMENTRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591