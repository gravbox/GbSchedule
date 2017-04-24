﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On 

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(), _
System.ComponentModel.DesignerCategoryAttribute("code"), _
System.Diagnostics.DebuggerStepThrough(), _
System.ComponentModel.ToolboxItem(True)> _
Public Class DatasetX
  Inherits System.Data.DataSet

  Private tableAPPOINTMENT As APPOINTMENTDataTable

  Public Sub New()
    MyBase.New()
    Me.InitClass()
    Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
    AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
    AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
  End Sub

  Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
    MyBase.New()
    Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)), String)
    If (Not (strSchema) Is Nothing) Then
      Dim ds As System.Data.DataSet = New System.Data.DataSet
      ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
      If (Not (ds.Tables("APPOINTMENT")) Is Nothing) Then
        Me.Tables.Add(New APPOINTMENTDataTable(ds.Tables("APPOINTMENT")))
      End If
      Me.DataSetName = ds.DataSetName
      Me.Prefix = ds.Prefix
      Me.Namespace = ds.Namespace
      Me.Locale = ds.Locale
      Me.CaseSensitive = ds.CaseSensitive
      Me.EnforceConstraints = ds.EnforceConstraints
      Me.Merge(ds, False, System.Data.MissingSchemaAction.Add)
      Me.InitVars()
    Else
      Me.InitClass()
    End If
    Me.GetSerializationData(info, context)
    Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
    AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
    AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
  End Sub

  <System.ComponentModel.Browsable(False), _
  System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)> _
  Public ReadOnly Property APPOINTMENT() As APPOINTMENTDataTable
    Get
      Return Me.tableAPPOINTMENT
    End Get
  End Property

  Public Overrides Function Clone() As System.Data.DataSet
    Dim cln As DatasetX = CType(MyBase.Clone, DatasetX)
    cln.InitVars()
    Return cln
  End Function

  Protected Overrides Function ShouldSerializeTables() As Boolean
    Return False
  End Function

  Protected Overrides Function ShouldSerializeRelations() As Boolean
    Return False
  End Function

  Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
    Me.Reset()
    Dim ds As System.Data.DataSet = New System.Data.DataSet
    ds.ReadXml(reader)
    If (Not (ds.Tables("APPOINTMENT")) Is Nothing) Then
      Me.Tables.Add(New APPOINTMENTDataTable(ds.Tables("APPOINTMENT")))
    End If
    Me.DataSetName = ds.DataSetName
    Me.Prefix = ds.Prefix
    Me.Namespace = ds.Namespace
    Me.Locale = ds.Locale
    Me.CaseSensitive = ds.CaseSensitive
    Me.EnforceConstraints = ds.EnforceConstraints
    Me.Merge(ds, False, System.Data.MissingSchemaAction.Add)
    Me.InitVars()
  End Sub

  Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
    Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
    Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
    stream.Position = 0
    Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
  End Function

  Friend Sub InitVars()
    Me.tableAPPOINTMENT = CType(Me.Tables("APPOINTMENT"), APPOINTMENTDataTable)
    If (Not (Me.tableAPPOINTMENT) Is Nothing) Then
      Me.tableAPPOINTMENT.InitVars()
    End If
  End Sub

  Private Sub InitClass()
    Me.DataSetName = "DatasetX"
    Me.Prefix = ""
    Me.Namespace = "http://tempuri.org/DatasetX.xsd"
    Me.Locale = New System.Globalization.CultureInfo("en-US")
    Me.CaseSensitive = False
    Me.EnforceConstraints = True
    Me.tableAPPOINTMENT = New APPOINTMENTDataTable
    Me.Tables.Add(Me.tableAPPOINTMENT)
  End Sub

  Private Function ShouldSerializeAPPOINTMENT() As Boolean
    Return False
  End Function

  Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
    If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
      Me.InitVars()
    End If
  End Sub

  Public Delegate Sub APPOINTMENTRowChangeEventHandler(ByVal sender As Object, ByVal e As APPOINTMENTRowChangeEvent)

  <System.Diagnostics.DebuggerStepThrough()> _
  Public Class APPOINTMENTDataTable
    Inherits DataTable
    Implements System.Collections.IEnumerable

    Private columnappointment_guid As DataColumn

    Private columnstart_date As DataColumn

    Private columnlength As DataColumn

    Private columnsubject As DataColumn

    Private columnnotes As DataColumn

    Private columntooltiptext As DataColumn

    Private columnvisible As DataColumn

    Private columnblockout As DataColumn

    Private columnisevent As DataColumn

    Private columnisflagged As DataColumn

    Private columnisreadonly As DataColumn

    Private columnmaxlength As DataColumn

    Private columnminlength As DataColumn

    Private columnpriority As DataColumn

    Private columnappearance_guid As DataColumn

    Private columnroom_guid As DataColumn

    Private columntime_stamp As DataColumn

    Friend Sub New()
      MyBase.New("APPOINTMENT")
      Me.InitClass()
    End Sub

    Friend Sub New(ByVal table As DataTable)
      MyBase.New(table.TableName)
      If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
        Me.CaseSensitive = table.CaseSensitive
      End If
      If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
        Me.Locale = table.Locale
      End If
      If (table.Namespace <> table.DataSet.Namespace) Then
        Me.Namespace = table.Namespace
      End If
      Me.Prefix = table.Prefix
      Me.MinimumCapacity = table.MinimumCapacity
      Me.DisplayExpression = table.DisplayExpression
    End Sub

    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property Count() As Integer
      Get
        Return Me.Rows.Count
      End Get
    End Property

    Friend ReadOnly Property appointment_guidColumn() As DataColumn
      Get
        Return Me.columnappointment_guid
      End Get
    End Property

    Friend ReadOnly Property start_dateColumn() As DataColumn
      Get
        Return Me.columnstart_date
      End Get
    End Property

    Friend ReadOnly Property lengthColumn() As DataColumn
      Get
        Return Me.columnlength
      End Get
    End Property

    Friend ReadOnly Property subjectColumn() As DataColumn
      Get
        Return Me.columnsubject
      End Get
    End Property

    Friend ReadOnly Property notesColumn() As DataColumn
      Get
        Return Me.columnnotes
      End Get
    End Property

    Friend ReadOnly Property tooltiptextColumn() As DataColumn
      Get
        Return Me.columntooltiptext
      End Get
    End Property

    Friend ReadOnly Property visibleColumn() As DataColumn
      Get
        Return Me.columnvisible
      End Get
    End Property

    Friend ReadOnly Property blockoutColumn() As DataColumn
      Get
        Return Me.columnblockout
      End Get
    End Property

    Friend ReadOnly Property iseventColumn() As DataColumn
      Get
        Return Me.columnisevent
      End Get
    End Property

    Friend ReadOnly Property isflaggedColumn() As DataColumn
      Get
        Return Me.columnisflagged
      End Get
    End Property

    Friend ReadOnly Property isreadonlyColumn() As DataColumn
      Get
        Return Me.columnisreadonly
      End Get
    End Property

    Friend ReadOnly Property maxlengthColumn() As DataColumn
      Get
        Return Me.columnmaxlength
      End Get
    End Property

    Friend ReadOnly Property minlengthColumn() As DataColumn
      Get
        Return Me.columnminlength
      End Get
    End Property

    Friend ReadOnly Property priorityColumn() As DataColumn
      Get
        Return Me.columnpriority
      End Get
    End Property

    Friend ReadOnly Property appearance_guidColumn() As DataColumn
      Get
        Return Me.columnappearance_guid
      End Get
    End Property

    Friend ReadOnly Property room_guidColumn() As DataColumn
      Get
        Return Me.columnroom_guid
      End Get
    End Property

    Friend ReadOnly Property time_stampColumn() As DataColumn
      Get
        Return Me.columntime_stamp
      End Get
    End Property

    Default Public ReadOnly Property Item(ByVal index As Integer) As APPOINTMENTRow
      Get
        Return CType(Me.Rows(index), APPOINTMENTRow)
      End Get
    End Property

    Public Event APPOINTMENTRowChanged As APPOINTMENTRowChangeEventHandler

    Public Event APPOINTMENTRowChanging As APPOINTMENTRowChangeEventHandler

    Public Event APPOINTMENTRowDeleted As APPOINTMENTRowChangeEventHandler

    Public Event APPOINTMENTRowDeleting As APPOINTMENTRowChangeEventHandler

    Public Overloads Sub AddAPPOINTMENTRow(ByVal row As APPOINTMENTRow)
      Me.Rows.Add(row)
    End Sub

    Public Overloads Function AddAPPOINTMENTRow( _
                ByVal appointment_guid As String, _
                ByVal start_date As Date, _
                ByVal length As Integer, _
                ByVal subject As String, _
                ByVal notes As String, _
                ByVal tooltiptext As String, _
                ByVal visible As Boolean, _
                ByVal blockout As Boolean, _
                ByVal isevent As Boolean, _
                ByVal isflagged As Boolean, _
                ByVal isreadonly As Boolean, _
                ByVal maxlength As Integer, _
                ByVal minlength As Integer, _
                ByVal priority As Integer, _
                ByVal appearance_guid As String, _
                ByVal room_guid As String, _
                ByVal time_stamp() As Byte) As APPOINTMENTRow
      Dim rowAPPOINTMENTRow As APPOINTMENTRow = CType(Me.NewRow, APPOINTMENTRow)
      rowAPPOINTMENTRow.ItemArray = New Object() {appointment_guid, start_date, length, subject, notes, tooltiptext, visible, blockout, isevent, isflagged, isreadonly, maxlength, minlength, priority, appearance_guid, room_guid, time_stamp}
      Me.Rows.Add(rowAPPOINTMENTRow)
      Return rowAPPOINTMENTRow
    End Function

    Public Function FindByappointment_guid(ByVal appointment_guid As String) As APPOINTMENTRow
      Return CType(Me.Rows.Find(New Object() {appointment_guid}), APPOINTMENTRow)
    End Function

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
      Return Me.Rows.GetEnumerator
    End Function

    Public Overrides Function Clone() As DataTable
      Dim cln As APPOINTMENTDataTable = CType(MyBase.Clone, APPOINTMENTDataTable)
      cln.InitVars()
      Return cln
    End Function

    Protected Overrides Function CreateInstance() As DataTable
      Return New APPOINTMENTDataTable
    End Function

    Friend Sub InitVars()
      Me.columnappointment_guid = Me.Columns("appointment_guid")
      Me.columnstart_date = Me.Columns("start_date")
      Me.columnlength = Me.Columns("length")
      Me.columnsubject = Me.Columns("subject")
      Me.columnnotes = Me.Columns("notes")
      Me.columntooltiptext = Me.Columns("tooltiptext")
      Me.columnvisible = Me.Columns("visible")
      Me.columnblockout = Me.Columns("blockout")
      Me.columnisevent = Me.Columns("isevent")
      Me.columnisflagged = Me.Columns("isflagged")
      Me.columnisreadonly = Me.Columns("isreadonly")
      Me.columnmaxlength = Me.Columns("maxlength")
      Me.columnminlength = Me.Columns("minlength")
      Me.columnpriority = Me.Columns("priority")
      Me.columnappearance_guid = Me.Columns("appearance_guid")
      Me.columnroom_guid = Me.Columns("room_guid")
      Me.columntime_stamp = Me.Columns("time_stamp")
    End Sub

    Private Sub InitClass()
      Me.columnappointment_guid = New DataColumn("appointment_guid", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnappointment_guid)
      Me.columnstart_date = New DataColumn("start_date", GetType(System.DateTime), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnstart_date)
      Me.columnlength = New DataColumn("length", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnlength)
      Me.columnsubject = New DataColumn("subject", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnsubject)
      Me.columnnotes = New DataColumn("notes", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnnotes)
      Me.columntooltiptext = New DataColumn("tooltiptext", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columntooltiptext)
      Me.columnvisible = New DataColumn("visible", GetType(System.Boolean), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnvisible)
      Me.columnblockout = New DataColumn("blockout", GetType(System.Boolean), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnblockout)
      Me.columnisevent = New DataColumn("isevent", GetType(System.Boolean), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnisevent)
      Me.columnisflagged = New DataColumn("isflagged", GetType(System.Boolean), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnisflagged)
      Me.columnisreadonly = New DataColumn("isreadonly", GetType(System.Boolean), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnisreadonly)
      Me.columnmaxlength = New DataColumn("maxlength", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnmaxlength)
      Me.columnminlength = New DataColumn("minlength", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnminlength)
      Me.columnpriority = New DataColumn("priority", GetType(System.Int32), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnpriority)
      Me.columnappearance_guid = New DataColumn("appearance_guid", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnappearance_guid)
      Me.columnroom_guid = New DataColumn("room_guid", GetType(System.String), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columnroom_guid)
      Me.columntime_stamp = New DataColumn("time_stamp", GetType(System.Byte()), Nothing, System.Data.MappingType.Element)
      Me.Columns.Add(Me.columntime_stamp)
      Me.Constraints.Add(New UniqueConstraint("DatasetXKey1", New DataColumn() {Me.columnappointment_guid}, True))
      Me.columnappointment_guid.AllowDBNull = False
      Me.columnappointment_guid.Unique = True
      Me.columnstart_date.AllowDBNull = False
      Me.columnlength.AllowDBNull = False
      Me.columntime_stamp.ReadOnly = True
    End Sub

    Public Function NewAPPOINTMENTRow() As APPOINTMENTRow
      Return CType(Me.NewRow, APPOINTMENTRow)
    End Function

    Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
      Return New APPOINTMENTRow(builder)
    End Function

    Protected Overrides Function GetRowType() As System.Type
      Return GetType(APPOINTMENTRow)
    End Function

    Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
      MyBase.OnRowChanged(e)
      If (Not (Me.APPOINTMENTRowChangedEvent) Is Nothing) Then
        RaiseEvent APPOINTMENTRowChanged(Me, New APPOINTMENTRowChangeEvent(CType(e.Row, APPOINTMENTRow), e.Action))
      End If
    End Sub

    Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
      MyBase.OnRowChanging(e)
      If (Not (Me.APPOINTMENTRowChangingEvent) Is Nothing) Then
        RaiseEvent APPOINTMENTRowChanging(Me, New APPOINTMENTRowChangeEvent(CType(e.Row, APPOINTMENTRow), e.Action))
      End If
    End Sub

    Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
      MyBase.OnRowDeleted(e)
      If (Not (Me.APPOINTMENTRowDeletedEvent) Is Nothing) Then
        RaiseEvent APPOINTMENTRowDeleted(Me, New APPOINTMENTRowChangeEvent(CType(e.Row, APPOINTMENTRow), e.Action))
      End If
    End Sub

    Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
      MyBase.OnRowDeleting(e)
      If (Not (Me.APPOINTMENTRowDeletingEvent) Is Nothing) Then
        RaiseEvent APPOINTMENTRowDeleting(Me, New APPOINTMENTRowChangeEvent(CType(e.Row, APPOINTMENTRow), e.Action))
      End If
    End Sub

    Public Sub RemoveAPPOINTMENTRow(ByVal row As APPOINTMENTRow)
      Me.Rows.Remove(row)
    End Sub
  End Class

  <System.Diagnostics.DebuggerStepThrough()> _
  Public Class APPOINTMENTRow
    Inherits DataRow

    Private tableAPPOINTMENT As APPOINTMENTDataTable

    Friend Sub New(ByVal rb As DataRowBuilder)
      MyBase.New(rb)
      Me.tableAPPOINTMENT = CType(Me.Table, APPOINTMENTDataTable)
    End Sub

    Public Property appointment_guid() As String
      Get
        Return CType(Me(Me.tableAPPOINTMENT.appointment_guidColumn), String)
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.appointment_guidColumn) = Value
      End Set
    End Property

    Public Property start_date() As Date
      Get
        Return CType(Me(Me.tableAPPOINTMENT.start_dateColumn), Date)
      End Get
      Set(ByVal Value As Date)
        Me(Me.tableAPPOINTMENT.start_dateColumn) = Value
      End Set
    End Property

    Public Property length() As Integer
      Get
        Return CType(Me(Me.tableAPPOINTMENT.lengthColumn), Integer)
      End Get
      Set(ByVal Value As Integer)
        Me(Me.tableAPPOINTMENT.lengthColumn) = Value
      End Set
    End Property

    Public Property subject() As String
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.subjectColumn), String)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.subjectColumn) = Value
      End Set
    End Property

    Public Property notes() As String
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.notesColumn), String)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.notesColumn) = Value
      End Set
    End Property

    Public Property tooltiptext() As String
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.tooltiptextColumn), String)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.tooltiptextColumn) = Value
      End Set
    End Property

    Public Property visible() As Boolean
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.visibleColumn), Boolean)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Boolean)
        Me(Me.tableAPPOINTMENT.visibleColumn) = Value
      End Set
    End Property

    Public Property blockout() As Boolean
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.blockoutColumn), Boolean)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Boolean)
        Me(Me.tableAPPOINTMENT.blockoutColumn) = Value
      End Set
    End Property

    Public Property isevent() As Boolean
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.iseventColumn), Boolean)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Boolean)
        Me(Me.tableAPPOINTMENT.iseventColumn) = Value
      End Set
    End Property

    Public Property isflagged() As Boolean
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.isflaggedColumn), Boolean)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Boolean)
        Me(Me.tableAPPOINTMENT.isflaggedColumn) = Value
      End Set
    End Property

    Public Property isreadonly() As Boolean
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.isreadonlyColumn), Boolean)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Boolean)
        Me(Me.tableAPPOINTMENT.isreadonlyColumn) = Value
      End Set
    End Property

    Public Property maxlength() As Integer
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.maxlengthColumn), Integer)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Integer)
        Me(Me.tableAPPOINTMENT.maxlengthColumn) = Value
      End Set
    End Property

    Public Property minlength() As Integer
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.minlengthColumn), Integer)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Integer)
        Me(Me.tableAPPOINTMENT.minlengthColumn) = Value
      End Set
    End Property

    Public Property priority() As Integer
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.priorityColumn), Integer)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Integer)
        Me(Me.tableAPPOINTMENT.priorityColumn) = Value
      End Set
    End Property

    Public Property appearance_guid() As String
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.appearance_guidColumn), String)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.appearance_guidColumn) = Value
      End Set
    End Property

    Public Property room_guid() As String
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.room_guidColumn), String)
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As String)
        Me(Me.tableAPPOINTMENT.room_guidColumn) = Value
      End Set
    End Property

    Public Property time_stamp() As Byte()
      Get
        Try
          Return CType(Me(Me.tableAPPOINTMENT.time_stampColumn), Byte())
        Catch e As InvalidCastException
          Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
        End Try
      End Get
      Set(ByVal Value As Byte())
        Me(Me.tableAPPOINTMENT.time_stampColumn) = Value
      End Set
    End Property

    Public Function IssubjectNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.subjectColumn)
    End Function

    Public Sub SetsubjectNull()
      Me(Me.tableAPPOINTMENT.subjectColumn) = System.Convert.DBNull
    End Sub

    Public Function IsnotesNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.notesColumn)
    End Function

    Public Sub SetnotesNull()
      Me(Me.tableAPPOINTMENT.notesColumn) = System.Convert.DBNull
    End Sub

    Public Function IstooltiptextNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.tooltiptextColumn)
    End Function

    Public Sub SettooltiptextNull()
      Me(Me.tableAPPOINTMENT.tooltiptextColumn) = System.Convert.DBNull
    End Sub

    Public Function IsvisibleNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.visibleColumn)
    End Function

    Public Sub SetvisibleNull()
      Me(Me.tableAPPOINTMENT.visibleColumn) = System.Convert.DBNull
    End Sub

    Public Function IsblockoutNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.blockoutColumn)
    End Function

    Public Sub SetblockoutNull()
      Me(Me.tableAPPOINTMENT.blockoutColumn) = System.Convert.DBNull
    End Sub

    Public Function IsiseventNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.iseventColumn)
    End Function

    Public Sub SetiseventNull()
      Me(Me.tableAPPOINTMENT.iseventColumn) = System.Convert.DBNull
    End Sub

    Public Function IsisflaggedNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.isflaggedColumn)
    End Function

    Public Sub SetisflaggedNull()
      Me(Me.tableAPPOINTMENT.isflaggedColumn) = System.Convert.DBNull
    End Sub

    Public Function IsisreadonlyNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.isreadonlyColumn)
    End Function

    Public Sub SetisreadonlyNull()
      Me(Me.tableAPPOINTMENT.isreadonlyColumn) = System.Convert.DBNull
    End Sub

    Public Function IsmaxlengthNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.maxlengthColumn)
    End Function

    Public Sub SetmaxlengthNull()
      Me(Me.tableAPPOINTMENT.maxlengthColumn) = System.Convert.DBNull
    End Sub

    Public Function IsminlengthNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.minlengthColumn)
    End Function

    Public Sub SetminlengthNull()
      Me(Me.tableAPPOINTMENT.minlengthColumn) = System.Convert.DBNull
    End Sub

    Public Function IspriorityNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.priorityColumn)
    End Function

    Public Sub SetpriorityNull()
      Me(Me.tableAPPOINTMENT.priorityColumn) = System.Convert.DBNull
    End Sub

    Public Function Isappearance_guidNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.appearance_guidColumn)
    End Function

    Public Sub Setappearance_guidNull()
      Me(Me.tableAPPOINTMENT.appearance_guidColumn) = System.Convert.DBNull
    End Sub

    Public Function Isroom_guidNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.room_guidColumn)
    End Function

    Public Sub Setroom_guidNull()
      Me(Me.tableAPPOINTMENT.room_guidColumn) = System.Convert.DBNull
    End Sub

    Public Function Istime_stampNull() As Boolean
      Return Me.IsNull(Me.tableAPPOINTMENT.time_stampColumn)
    End Function

    Public Sub Settime_stampNull()
      Me(Me.tableAPPOINTMENT.time_stampColumn) = System.Convert.DBNull
    End Sub
  End Class

  <System.Diagnostics.DebuggerStepThrough()> _
  Public Class APPOINTMENTRowChangeEvent
    Inherits EventArgs

    Private eventRow As APPOINTMENTRow

    Private eventAction As DataRowAction

    Public Sub New(ByVal row As APPOINTMENTRow, ByVal action As DataRowAction)
      MyBase.New()
      Me.eventRow = row
      Me.eventAction = action
    End Sub

    Public ReadOnly Property Row() As APPOINTMENTRow
      Get
        Return Me.eventRow
      End Get
    End Property

    Public ReadOnly Property Action() As DataRowAction
      Get
        Return Me.eventAction
      End Get
    End Property
  End Class
End Class
