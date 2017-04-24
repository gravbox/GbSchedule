#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  Friend Class DataBinder

#Region "Class Members"

    'Constants
    Private Const ERROR_DOCUMENTATION As String = " Please see the documentation for the proper dataset format details."

    Private ReadOnly text_AppointmentTableName As String = "Appointment"
    Private ReadOnly text_RoomTableName As String = "Room"
    Private ReadOnly text_ProviderTableName As String = "Provider"
    Private ReadOnly text_AppointmentProviderTableName As String = "Appointment_Provider"
    Private ReadOnly text_ResourceTableName As String = "Resource"
    Private ReadOnly text_AppointmentResourceTableName As String = "Appointment_Resource"
    Private ReadOnly text_CategoryTableName As String = "Category"
    Private ReadOnly text_AppointmentCategoryTableName As String = "Appointment_Category"
    Private ReadOnly text_AppearanceTableName As String = "Appearance"
    Private ReadOnly text_RecurrenceTableName As String = "Recurrence"

    Private ReadOnly text_AccountGUID As String = "account_guid"
    Private ReadOnly text_AppointmentGUID As String = "appointment_guid"
    Private ReadOnly text_RoomGUID As String = "room_guid"
    Private ReadOnly text_ProviderGUID As String = "provider_guid"
    Private ReadOnly text_ResourceGUID As String = "resource_guid"
    Private ReadOnly text_CategoryGUID As String = "category_guid"
    Private ReadOnly text_AppearanceGUID As String = "appearance_guid"
    Private ReadOnly text_RecurrenceGUID As String = "recurrence_guid"
    Private ReadOnly text_Name As String = "Name"
    Private ReadOnly text_Color As String = "Color"
    Private ReadOnly text_StartDate As String = "Start_Date"
    Private ReadOnly text_StartTime As String = "Start_Time"
    Private ReadOnly text_Length As String = "Length"
    Private ReadOnly text_Blockout As String = "Blockout"
    Private ReadOnly text_IsEvent As String = "IsEvent"
    Private ReadOnly text_IsActivity As String = "IsActivity"
    Private ReadOnly text_IsFlagged As String = "IsFlagged"
    Private ReadOnly text_IsReadOnly As String = "IsReadOnly"
    Private ReadOnly text_MaxLength As String = "MaxLength"
    Private ReadOnly text_MinLength As String = "MinLength"
    Private ReadOnly text_Notes As String = "Notes"
    Private ReadOnly text_Priority As String = "Priority_guid"
    Private ReadOnly text_RecurrenceStamp As String = "recurrence_stamp"
    Private ReadOnly text_Room As String = "Room_guid"
    Private ReadOnly text_Subject As String = "Subject"
    Private ReadOnly text_Text As String = "Text"
    Private ReadOnly text_ToolTipText As String = "ToolTipText"
    Private ReadOnly text_Visible As String = "Visible"
    Private ReadOnly text_TimeStamp As String = "Time_Stamp"

    Private ReadOnly text_AlarmWindowText As String = "Alarm_Window_Text"
    Private ReadOnly text_AlarmIsArmed As String = "Alarm_Is_Armed"
    Private ReadOnly text_AlarmReminder As String = "Alarm_Reminder"
    Private ReadOnly text_AlarmAllowOpen As String = "Alarm_Allow_Open"
    Private ReadOnly text_AlarmAllowSnooze As String = "Alarm_Allow_Snooze"

    Private ReadOnly text_Alignment As String = "Alignment"
    Private ReadOnly text_BackColor As String = "BackColor"
    Private ReadOnly text_BackColor2 As String = "BackColor2"
    Private ReadOnly text_BackGradientStyle As String = "BackGradientStyle"
    Private ReadOnly text_BorderColor As String = "BorderColor"
    Private ReadOnly text_BorderWidth As String = "BorderWidth"
    Private ReadOnly text_FontBold As String = "FontBold"
    Private ReadOnly text_FontItalics As String = "FontItalics"
    Private ReadOnly text_FontSize As String = "FontSize"
    Private ReadOnly text_FontStrikeout As String = "FontStrikeout"
    Private ReadOnly text_FontUnderline As String = "FontUnderline"
    Private ReadOnly text_FontUnit As String = "FontUnit"
    Private ReadOnly text_ForeColor As String = "ForeColor"
    Private ReadOnly text_StringFormatFlags As String = "StringFormatFlags"
    Private ReadOnly text_TextTrimming As String = "TextTrimming"
    Private ReadOnly text_TextVAlign As String = "TextVAlign"
    Private ReadOnly text_ShadowSize As String = "ShadowSize"
    Private ReadOnly text_recurrence_interval As String = "recurrence_interval"
    Private ReadOnly text_End_Type As String = "end_type"
    Private ReadOnly text_End_Iterations As String = "end_iterations"
    Private ReadOnly text_EndDate As String = "end_date"
    Private ReadOnly text_Last_Create_Date As String = "last_create_date"
    Private ReadOnly text_Last_Create_GroupId As String = "last_create_groupId"
    Private ReadOnly text_Check_only As String = "check_only"
    Private ReadOnly text_Day_Recurrence_Mode As String = "day_recurrence_mode"
    Private ReadOnly text_Day_Day_Interval As String = "day_day_interval"
    Private ReadOnly text_Month_Recurrence_Mode As String = "month_recurrence_mode"
    Private ReadOnly text_Month_Month_Interval As String = "month_month_interval"
    Private ReadOnly text_Month_Day_Interval As String = "month_day_interval"
    Private ReadOnly text_Month_Day_Ordinal As String = "month_day_ordinal"
    Private ReadOnly text_Month_Day_Position As String = "month_day_position"
    Private ReadOnly text_Week_Week_Interval As String = "week_week_interval"
    Private ReadOnly text_Week_Use_Sun As String = "week_use_sun"
    Private ReadOnly text_Week_Use_Mon As String = "week_use_mon"
    Private ReadOnly text_Week_Use_Tue As String = "week_use_tue"
    Private ReadOnly text_Week_Use_Wed As String = "week_use_wed"
    Private ReadOnly text_Week_Use_Thu As String = "week_use_thu"
    Private ReadOnly text_Week_Use_Fri As String = "week_use_fri"
    Private ReadOnly text_Week_Use_Sat As String = "week_use_sat"
    Private ReadOnly text_Year_Day_Interval As String = "year_day_interval"
    Private ReadOnly text_Year_Day_Ordinal As String = "year_day_ordinal"
    Private ReadOnly text_Year_Day_Position As String = "year_day_position"
    Private ReadOnly text_Year_Month_Interval As String = "year_month_interval"
    Private ReadOnly text_Year_Month_Ordinal As String = "year_month_ordinal"
    Private ReadOnly text_Year_Recurrence_Mode As String = "year_recurrence_mode"

    'Create a list of valid fields for each data table
    Private validAppointmentFields() As String = {text_AccountGUID, text_AppointmentGUID, text_StartDate, text_StartTime, text_Length, text_Blockout, text_IsEvent, text_IsActivity, text_IsFlagged, text_IsReadOnly, text_MaxLength, text_MinLength, text_Notes, text_Priority, text_RecurrenceGUID, text_RecurrenceStamp, text_Room, text_Subject, text_Text, text_ToolTipText, text_Visible, text_AppearanceGUID, text_AlarmWindowText, text_AlarmIsArmed, text_AlarmReminder, text_AlarmAllowOpen, text_AlarmAllowSnooze, text_TimeStamp}
    Private validProviderFields() As String = {text_AccountGUID, text_ProviderGUID, text_Name, text_Color, text_Notes, text_TimeStamp}
    Private validResourceFields() As String = {text_AccountGUID, text_ResourceGUID, text_Name, text_Color, text_Notes, text_TimeStamp}
    Private validRoomFields() As String = {text_AccountGUID, text_RoomGUID, text_Name, text_Notes, text_Visible, text_TimeStamp}
    Private validCategoryFields() As String = {text_AccountGUID, text_CategoryGUID, text_Color, text_Name, text_Notes, text_TimeStamp}
    Private validAppointmentCategoryFields() As String = {text_AppointmentGUID, text_CategoryGUID}
    Private validAppointmentProviderFields() As String = {text_AppointmentGUID, text_ProviderGUID}
    Private validAppointmentResourceFields() As String = {text_AppointmentGUID, text_ResourceGUID}
    Private validAppearanceFields() As String = {text_AccountGUID, text_AppearanceGUID, text_Name, text_Alignment, text_BackColor, text_BackColor2, text_BackGradientStyle, text_BorderColor, text_BorderWidth, text_FontBold, text_FontItalics, text_FontSize, text_FontStrikeout, text_FontUnderline, text_FontUnit, text_ForeColor, text_StringFormatFlags, text_TextTrimming, text_TextVAlign, text_ShadowSize, text_TimeStamp}
    Private validRecurrenceFields() As String = {text_AccountGUID, text_RecurrenceGUID, text_recurrence_interval, text_StartDate, text_End_Type, text_End_Iterations, text_EndDate, text_Last_Create_Date, text_Last_Create_GroupId, text_Check_only, text_Day_Recurrence_Mode, text_Day_Day_Interval, text_Month_Recurrence_Mode, text_Month_Month_Interval, text_Month_Day_Interval, text_Month_Day_Ordinal, text_Month_Day_Position, text_Week_Week_Interval, text_Week_Use_Sun, text_Week_Use_Mon, text_Week_Use_Tue, text_Week_Use_Wed, text_Week_Use_Thu, text_Week_Use_Fri, text_Week_Use_Sat, text_Year_Day_Interval, text_Year_Day_Ordinal, text_Year_Day_Position, text_Year_Month_Interval, text_Year_Month_Ordinal, text_Year_Recurrence_Mode, text_TimeStamp}

    'Property Variables
    Private m_DataSource As Object

    'Internal Variables
    Private MainObject As Gravitybox.Controls.Schedule
    Private IsLoading As Boolean = False
    Private CascadeAppointmentCategory As Boolean = False
    Private CascadeAppointmentProvider As Boolean = False
    Private CascadeAppointmentResource As Boolean = False
    Private CascadeRoomAppointment As Boolean = False
    Private CascadeAppearanceAppointment As Boolean = False
    Private CascadeCategoryLink As Boolean = False
    Private CascadeProviderLink As Boolean = False
    Private CascadeResourceLink As Boolean = False
    Private _dataSet As System.Data.DataSet = Nothing

#End Region

#Region "Constructor"

    Friend Sub New(ByVal schedule As Gravitybox.Controls.Schedule)

      'Error Check
      If schedule Is Nothing Then
        Throw New Exceptions.GravityboxException("There must be a schedule specified!")
      End If
      MainObject = schedule

      'Make all checking arrays lower case
      FixArrayCase(text_AppointmentTableName, validAppointmentFields)
      FixArrayCase(text_ProviderTableName, validProviderFields)
      FixArrayCase(text_ResourceTableName, validResourceFields)
      FixArrayCase(text_RoomTableName, validRoomFields)
      FixArrayCase(text_CategoryTableName, validCategoryFields)
      FixArrayCase(text_AppointmentCategoryTableName, validAppointmentCategoryFields)
      FixArrayCase(text_AppointmentProviderTableName, validAppointmentProviderFields)
      FixArrayCase(text_RecurrenceTableName, validRecurrenceFields)

    End Sub

    Private Sub FixArrayCase(ByVal tableID As String, ByVal inArray As String())

      Dim ii As Integer = 0
      For Each s As String In inArray
        Dim fieldName As String = GetFieldName(tableID, s)
        inArray.SetValue(fieldName.ToLower(), ii)
        ii += 1
      Next

    End Sub

#End Region

#Region "Property Implementations"

    Friend Property DataSource() As Object
      Get
        Return m_DataSource
      End Get
      Set(ByVal Value As Object)

        Me.Unbind()

        'If the value is null then unbind
        If Value Is Nothing Then
          Try
            m_DataSource = Value
            Me.Unbind()
            Return

          Catch ex As Exception
            Throw ex
          End Try
        End If

        'Otherwise this property is being set to something
        'Verify that it is a dataset and then bind the schedule
        Try
          Dim Proposed As Object = Value

          'Raise error if there is a problem with the datasource
          If Proposed Is Nothing Then
            Throw New Exceptions.GravityboxException("The '" & AppointmentTableName & "' datatable's cannot be null." & ERROR_DOCUMENTATION)
          End If

          'Make sure The '" & AppointmentTableName & "' datatable's is a dataset
					If IsTypeOf(Proposed.GetType(), GetType(System.Data.DataSet)) Then
						_dataSet = CType(Proposed, System.Data.DataSet)
          ElseIf IsTypeOf(Proposed.GetType(), GetType(System.Data.DataView)) Then
            Dim dv As System.Data.DataView = CType(Proposed, System.Data.DataView)
            If dv.Table.DataSet Is Nothing Then
              _dataSet = New System.Data.DataSet
              _dataSet.Tables.Add(dv.Table)
            Else
              _dataSet = dv.Table.DataSet
            End If
					Else
						Throw New Exceptions.GravityboxException("The '" & AppointmentTableName & "' datatable's must be a dataset!" & ERROR_DOCUMENTATION)
					End If

					'Check to determine if there is a data table
          'If Not GetDataSet().Tables.Contains(AppointmentTableName) Then
          '	Throw New Exceptions.GravityboxException("The '" & AppointmentTableName & "' datatable's must contain an '" & AppointmentTableName & "' table." & ERROR_DOCUMENTATION)
          'End If

          'Check for column existence
          If GetDataSet().Tables.Contains(AppointmentTableName) Then
            Dim appointmentTable As System.Data.DataTable = GetDataSet().Tables(AppointmentTableName)
            Dim errorString As String = ValidateAppointmentDataTable(appointmentTable)
            If errorString <> "" Then
              Dim ex As New ApplicationException(errorString & ERROR_DOCUMENTATION)
              Throw ex
            End If
          End If

					'Verify the Room table if one exists
					If GetDataSet().Tables.Contains(RoomTableName) Then
            Dim errorString As String = ValidateRoomDataTable(GetDataSet().Tables(RoomTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Provider table if one exists
					If GetDataSet().Tables.Contains(ProviderTableName) Then
            Dim errorString As String = ValidateProviderDataTable(GetDataSet().Tables(ProviderTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Appointment_Provider table if one exists
					If GetDataSet().Tables.Contains(AppointmentProviderTableName) Then
            Dim errorString As String = ValidateAppointmentProviderDataTable(GetDataSet().Tables(AppointmentProviderTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Resource table if one exists
					If GetDataSet().Tables.Contains(ResourceTableName) Then
            Dim errorString As String = ValidateResourceDataTable(GetDataSet().Tables(ResourceTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Appointment_Resource table if one exists
					If GetDataSet().Tables.Contains(AppointmentResourceTableName) Then
            Dim errorString As String = ValidateAppointmentResourceDataTable(GetDataSet().Tables(AppointmentResourceTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Category table if one exists
					If GetDataSet().Tables.Contains(CategoryTableName) Then
            Dim errorString As String = ValidateCategoryDataTable(GetDataSet().Tables(CategoryTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Appointment_Category table if one exists
					If GetDataSet().Tables.Contains(AppointmentCategoryTableName) Then
            Dim errorString As String = ValidateAppointmentCategoryDataTable(GetDataSet().Tables(AppointmentCategoryTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Appearance table if one exists
					If GetDataSet().Tables.Contains(AppearanceTableName) Then
            Dim errorString As String = ValidateAppearanceDataTable(GetDataSet().Tables(AppearanceTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Verify the Recurrence table if one exists
					If GetDataSet().Tables.Contains(RecurrenceTableName) Then
            Dim errorString As String = ValidateRecurrenceDataTable(GetDataSet().Tables(RecurrenceTableName))
						If errorString <> "" Then
							Throw New Exceptions.GravityboxException(errorString & ERROR_DOCUMENTATION)
						End If
					End If

					'Check mappings
					If Not MainObject.DataBindings.AppointmentBinding.ValidateFields(validAppointmentFields) Then
						Throw New Exceptions.GravityboxException("The '" & AppointmentTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.RoomBinding.ValidateFields(validRoomFields) Then
						Throw New Exceptions.GravityboxException("The '" & RoomTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.ProviderBinding.ValidateFields(validProviderFields) Then
						Throw New Exceptions.GravityboxException("The '" & ProviderTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.ResourceBinding.ValidateFields(validResourceFields) Then
						Throw New Exceptions.GravityboxException("The '" & ResourceTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.CategoryBinding.ValidateFields(validCategoryFields) Then
						Throw New Exceptions.GravityboxException("The '" & CategoryTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.AppointmentCategoryBinding.ValidateFields(validAppointmentCategoryFields) Then
						Throw New Exceptions.GravityboxException("The '" & AppointmentCategoryTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.AppointmentProviderBinding.ValidateFields(validAppointmentProviderFields) Then
						Throw New Exceptions.GravityboxException("The '" & AppointmentProviderTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.AppointmentResourceBinding.ValidateFields(validAppointmentResourceFields) Then
						Throw New Exceptions.GravityboxException("The '" & AppointmentResourceTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.AppearanceBinding.ValidateFields(validAppearanceFields) Then
						Throw New Exceptions.GravityboxException("The '" & AppearanceTableName & "' datatable bindings has fields that do not exist.")
					End If
					If Not MainObject.DataBindings.RecurrenceBinding.ValidateFields(validRecurrenceFields) Then
						Throw New Exceptions.GravityboxException("The '" & RecurrenceTableName & "' datatable bindings has fields that do not exist.")
					End If

					'Set the object if there was no error
					m_DataSource = Proposed

					'Finally bind the schedule to this dataset 
					Me.Bind()

				Catch ex As Exception
					Throw
				End Try

			End Set
		End Property

		Private Function GetDataSet() As System.Data.DataSet
			Return _dataSet
		End Function

		Friend ReadOnly Property AppointmentDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.AppointmentBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					Else
						Return ds.Tables(AppointmentTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentBinding.DataSource, System.Data.DataView).Table
				End If
				Return Nothing
			End Get
		End Property

		Friend ReadOnly Property RoomDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.RoomBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					ElseIf ds.Tables.Contains(RoomTableName) Then
						Return ds.Tables(RoomTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.RoomBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.RoomBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.RoomBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.RoomBinding.DataSource, System.Data.DataView).Table
				End If
				Return Nothing
			End Get
		End Property

		Friend ReadOnly Property ProviderDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.ProviderBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					ElseIf ds.Tables.Contains(ProviderTableName) Then
						Return ds.Tables(ProviderTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.ProviderBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.ProviderBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.ProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.ProviderBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

    Friend ReadOnly Property AppointmentProviderDataTable() As System.Data.DataTable
      Get
        If MainObject.DataBindings.AppointmentProviderBinding.DataSource Is Nothing Then
          Dim ds As System.Data.DataSet = GetDataSet()
          If (ds Is Nothing) Then
            Return Nothing
          ElseIf ds.Tables.Contains(AppointmentProviderTableName) Then
            Return ds.Tables(AppointmentProviderTableName)
          End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentProviderBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentProviderBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentProviderBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

		Friend ReadOnly Property ResourceDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.ResourceBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					ElseIf ds.Tables.Contains(ResourceTableName) Then
						Return ds.Tables(ResourceTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.ResourceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.ResourceBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.ResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.ResourceBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

    Friend ReadOnly Property AppointmentResourceDataTable() As System.Data.DataTable
      Get
        If MainObject.DataBindings.AppointmentResourceBinding.DataSource Is Nothing Then
          Dim ds As System.Data.DataSet = GetDataSet()
          If (ds Is Nothing) Then
            Return Nothing
          ElseIf ds.Tables.Contains(AppointmentResourceTableName) Then
            Return ds.Tables(AppointmentResourceTableName)
          End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentResourceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentResourceBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentResourceBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

		Friend ReadOnly Property CategoryDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.CategoryBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					ElseIf ds.Tables.Contains(CategoryTableName) Then
						Return ds.Tables(CategoryTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.CategoryBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.CategoryBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.CategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.CategoryBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

    Friend ReadOnly Property AppointmentCategoryDataTable() As System.Data.DataTable
      Get
        If MainObject.DataBindings.AppointmentCategoryBinding.DataSource Is Nothing Then
          Dim ds As System.Data.DataSet = GetDataSet()
          If (ds Is Nothing) Then
            Return Nothing
          ElseIf ds.Tables.Contains(AppointmentCategoryTableName) Then
            Return ds.Tables(AppointmentCategoryTableName)
          End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentCategoryBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentCategoryBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppointmentCategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentCategoryBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

		Friend ReadOnly Property AppearanceDataTable() As System.Data.DataTable
			Get
				If MainObject.DataBindings.AppearanceBinding.DataSource Is Nothing Then
					Dim ds As System.Data.DataSet = GetDataSet()
					If (ds Is Nothing) Then
						Return Nothing
					ElseIf ds.Tables.Contains(AppearanceTableName) Then
						Return ds.Tables(AppearanceTableName)
					End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppearanceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppearanceBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.AppearanceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppearanceBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

    Friend ReadOnly Property RecurrenceDataTable() As System.Data.DataTable
      Get
        If MainObject.DataBindings.RecurrenceBinding.DataSource Is Nothing Then
          Dim ds As System.Data.DataSet = GetDataSet()
          If (ds Is Nothing) Then
            Return Nothing
          ElseIf ds.Tables.Contains(RecurrenceTableName) Then
            Return ds.Tables(RecurrenceTableName)
          End If
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.RecurrenceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.RecurrenceBinding.DataSource, System.Data.DataTable)
        ElseIf ScheduleGlobals.IsTypeOf(MainObject.DataBindings.RecurrenceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.RecurrenceBinding.DataSource, System.Data.DataView).Table
        End If
        Return Nothing
      End Get
    End Property

		Private ReadOnly Property AppointmentDataView() As System.Data.DataView
			Get
				If Not (MainObject.DataBindings.AppointmentBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.AppointmentBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.AppointmentBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

    Private ReadOnly Property RoomDataView() As System.Data.DataView
      Get
        If Not (MainObject.DataBindings.RoomBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.RoomBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.RoomBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

		Private ReadOnly Property ProviderDataView() As System.Data.DataView
			Get
				If Not (MainObject.DataBindings.ProviderBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.ProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.ProviderBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

    Private ReadOnly Property AppointmentProviderDataView() As System.Data.DataView
      Get
        If Not (MainObject.DataBindings.AppointmentProviderBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.AppointmentProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.AppointmentProviderBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

		Private ReadOnly Property ResourceDataView() As System.Data.DataView
			Get
				If Not (MainObject.DataBindings.ResourceBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.ResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.ResourceBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

    Private ReadOnly Property AppointmentResourceDataView() As System.Data.DataView
      Get
        If Not (MainObject.DataBindings.AppointmentResourceBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.AppointmentResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.AppointmentResourceBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

		Private ReadOnly Property CategoryDataView() As System.Data.DataView
			Get
				If Not (MainObject.DataBindings.CategoryBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.CategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.CategoryBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

    Private ReadOnly Property AppointmentCategoryDataView() As System.Data.DataView
      Get
        If Not (MainObject.DataBindings.AppointmentCategoryBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.AppointmentCategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.AppointmentCategoryBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

		Private ReadOnly Property AppearanceDataView() As System.Data.DataView
			Get
				If Not (MainObject.DataBindings.AppearanceBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.AppearanceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.AppearanceBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

    Private ReadOnly Property RecurrenceDataView() As System.Data.DataView
      Get
        If Not (MainObject.DataBindings.RecurrenceBinding.DataSource Is Nothing) Then
          If IsTypeOf(MainObject.DataBindings.RecurrenceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
            Return CType(MainObject.DataBindings.RecurrenceBinding.DataSource, System.Data.DataView)
          End If
        End If
        Return Nothing
      End Get
    End Property

#End Region

#Region "Bind/Unbind"

		Private Function Bind() As Boolean

			'Error Check
			If DataSource Is Nothing Then Return False

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True
			Dim redraw As Boolean = MainObject.AutoRedraw

			Try
				MainObject.AutoRedraw = False

				'Clear all existing appointments
				Call MainObject.AppointmentCollection.Clear()

				'Cache the tables into variables
				Dim appointmentTable As System.Data.DataTable = Me.AppointmentDataTable
				Dim roomTable As System.Data.DataTable = Me.RoomDataTable
				Dim providerTable As System.Data.DataTable = Me.ProviderDataTable
				Dim resourceTable As System.Data.DataTable = Me.ResourceDataTable
				Dim categoryTable As System.Data.DataTable = Me.CategoryDataTable
				Dim appearanceTable As System.Data.DataTable = Me.AppearanceDataTable
				Dim recurrenceTable As System.Data.DataTable = Me.RecurrenceDataTable

				Dim appointmentDataview As System.Data.DataView = Me.AppointmentDataView
				Dim roomDataview As System.Data.DataView = Me.RoomDataView
				Dim providerDataview As System.Data.DataView = Me.ProviderDataView
				Dim resourceDataview As System.Data.DataView = Me.ResourceDataView
				Dim categoryDataview As System.Data.DataView = Me.CategoryDataView
				Dim appearanceDataview As System.Data.DataView = Me.AppearanceDataView
				Dim recurrenceDataview As System.Data.DataView = Me.RecurrenceDataView

				'Determine if cascading enabled
				CascadeAppointmentCategory = IsCascade(appointmentTable, categoryTable)
				CascadeAppointmentProvider = IsCascade(appointmentTable, providerTable)
				CascadeAppointmentResource = IsCascade(appointmentTable, resourceTable)
				CascadeRoomAppointment = IsCascade(roomTable, appointmentTable)
				CascadeAppearanceAppointment = IsCascade(appearanceTable, appointmentTable)
				CascadeCategoryLink = IsCascade(categoryTable, AppointmentCategoryDataTable)
				CascadeProviderLink = IsCascade(providerTable, AppointmentProviderDataTable)
				CascadeResourceLink = IsCascade(resourceTable, AppointmentResourceDataTable)

				'Loop through the datarows and create rooms
				MainObject.RoomCollection.Clear()
				If (roomDataview Is Nothing) AndAlso Not (roomTable Is Nothing) Then
					For Each dr As DataRow In roomTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateRoomFromDataRow(roomTable, dr)
						End If
					Next
				ElseIf Not (roomTable Is Nothing) Then
					For Each drv As DataRowView In roomDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateRoomFromDataRow(roomTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create providers
				MainObject.ProviderCollection.Clear()
				If (providerDataview Is Nothing) AndAlso Not (providerTable Is Nothing) Then
					For Each dr As DataRow In providerTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateProviderFromDataRow(providerTable, dr)
						End If
					Next
				ElseIf Not (providerTable Is Nothing) Then
					For Each drv As DataRowView In providerDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateProviderFromDataRow(providerTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create resources
				MainObject.ResourceCollection.Clear()
				If (resourceDataview Is Nothing) AndAlso Not (resourceTable Is Nothing) Then
					For Each dr As DataRow In resourceTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateResourceFromDataRow(resourceTable, dr)
						End If
					Next
				ElseIf Not (resourceTable Is Nothing) Then
					For Each drv As DataRowView In resourceDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateResourceFromDataRow(resourceTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create categories
				MainObject.CategoryCollection.Clear()
				If (categoryDataview Is Nothing) AndAlso Not (categoryTable Is Nothing) Then
					For Each dr As DataRow In categoryTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateCategoryFromDataRow(categoryTable, dr)
						End If
					Next
				ElseIf Not (categoryTable Is Nothing) Then
					For Each drv As DataRowView In categoryDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateCategoryFromDataRow(categoryTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create categories
				MainObject.AppearanceCollection.Clear()
				If (appearanceDataview Is Nothing) AndAlso Not (appearanceTable Is Nothing) Then
					For Each dr As DataRow In appearanceTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateAppearanceFromDataRow(appearanceTable, dr)
						End If
					Next
				ElseIf Not (appearanceTable Is Nothing) Then
					For Each drv As DataRowView In appearanceDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateAppearanceFromDataRow(appearanceTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create recurrences
				MainObject.RecurrenceCollection.Clear()
				If (recurrenceDataview Is Nothing) AndAlso Not (recurrenceTable Is Nothing) Then
					For Each dr As DataRow In recurrenceTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateRecurrenceFromDataRow(recurrenceTable, dr)
						End If
					Next
				ElseIf Not (recurrenceTable Is Nothing) Then
					For Each drv As DataRowView In recurrenceDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateRecurrenceFromDataRow(recurrenceTable, drv.Row)
						End If
					Next
				End If

				'Loop through the datarows and create appointments
				If (appointmentDataview Is Nothing) AndAlso Not (appointmentTable Is Nothing) Then
					For Each dr As DataRow In appointmentTable.Rows
						If dr.RowState <> DataRowState.Deleted Then
							CreateAppointmentFromDataRow(appointmentTable, dr)
						End If
					Next
				ElseIf Not (appointmentTable Is Nothing) Then
					For Each drv As DataRowView In appointmentDataview
						If drv.Row.RowState <> DataRowState.Deleted Then
							CreateAppointmentFromDataRow(appointmentTable, drv.Row)
						End If
					Next
				End If

        'Catch appointment add/delete
        If Not (appointmentTable Is Nothing) Then
          AddHandler MainObject.AppointmentCollection.InternalAfterAdd, AddressOf AppointmentAdd
          AddHandler MainObject.AppointmentCollection.InternalAfterRemove, AddressOf AppointmentRemove
          AddHandler MainObject.AppointmentCollection.InternalClearComplete, AddressOf AppointmentClear
          AddHandler Me.AppointmentDataTable.RowChanged, AddressOf DatasetRowChanged
          AddHandler Me.AppointmentDataTable.RowDeleting, AddressOf DatasetRowDeleted
        End If

				If Not (roomTable Is Nothing) Then
					'Catch room add/delete
					AddHandler MainObject.RoomCollection.InternalAfterAdd, AddressOf RoomAdd
					AddHandler MainObject.RoomCollection.InternalAfterRemove, AddressOf RoomRemove
					AddHandler MainObject.RoomCollection.InternalClearComplete, AddressOf RoomClear
					AddHandler Me.RoomDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.RoomDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				If Not (providerTable Is Nothing) Then
					'Catch provider add/delete
					AddHandler MainObject.ProviderCollection.InternalAfterAdd, AddressOf ProviderAdd
					AddHandler MainObject.ProviderCollection.InternalAfterRemove, AddressOf ProviderRemove
					AddHandler MainObject.ProviderCollection.InternalClearComplete, AddressOf ProviderClear
					AddHandler Me.ProviderDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.ProviderDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				If Not (resourceTable Is Nothing) Then
					'Catch resource add/delete
					AddHandler MainObject.ResourceCollection.InternalAfterAdd, AddressOf ResourceAdd
					AddHandler MainObject.ResourceCollection.InternalAfterRemove, AddressOf ResourceRemove
					AddHandler MainObject.ResourceCollection.InternalClearComplete, AddressOf ResourceClear
					AddHandler Me.ResourceDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.ResourceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				If Not (categoryTable Is Nothing) Then
					'Catch category add/delete
					AddHandler MainObject.CategoryCollection.InternalAfterAdd, AddressOf CategoryAdd
					AddHandler MainObject.CategoryCollection.InternalAfterRemove, AddressOf CategoryRemove
					AddHandler MainObject.CategoryCollection.InternalClearComplete, AddressOf CategoryClear
					AddHandler Me.CategoryDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.CategoryDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				If Not (appearanceTable Is Nothing) Then
					'Catch appearance add/delete
					AddHandler MainObject.AppearanceCollection.InternalAfterAdd, AddressOf AppearanceAdd
					AddHandler MainObject.AppearanceCollection.InternalAfterRemove, AddressOf AppearanceRemove
					AddHandler MainObject.AppearanceCollection.InternalClearComplete, AddressOf AppearanceClear
					AddHandler Me.AppearanceDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.AppearanceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				If Not (recurrenceTable Is Nothing) Then
					'Catch recurrence add/delete
					AddHandler MainObject.RecurrenceCollection.InternalAfterAdd, AddressOf RecurrenceAdd
					AddHandler MainObject.RecurrenceCollection.InternalAfterRemove, AddressOf RecurrenceRemove
					AddHandler MainObject.RecurrenceCollection.InternalClearComplete, AddressOf RecurrenceClear
					AddHandler Me.RecurrenceDataTable.RowChanged, AddressOf DatasetRowChanged
					AddHandler Me.RecurrenceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				MainObject.AutoRedraw = redraw
				IsLoading = oldLoad
			End Try

		End Function

		Private Function Unbind() As Boolean

			Try
				'Catch appointment add/delete
				RemoveHandler MainObject.AppointmentCollection.InternalAfterAdd, AddressOf AppointmentAdd
				RemoveHandler MainObject.AppointmentCollection.InternalAfterRemove, AddressOf AppointmentRemove
				RemoveHandler MainObject.AppointmentCollection.InternalClearComplete, AddressOf AppointmentClear
				If Not (Me.AppointmentDataTable Is Nothing) Then
					RemoveHandler Me.AppointmentDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.AppointmentDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all appointment handlers
				For Each appointment As Gravitybox.Objects.Appointment In MainObject.AppointmentCollection
					RemoveHandler appointment.Refresh, AddressOf AppointmentRefresh
				Next

				'Catch Room add/delete
				RemoveHandler MainObject.RoomCollection.InternalAfterAdd, AddressOf RoomAdd
				RemoveHandler MainObject.RoomCollection.InternalAfterRemove, AddressOf RoomRemove
				RemoveHandler MainObject.RoomCollection.InternalClearComplete, AddressOf RoomClear
				If Not (Me.RoomDataTable Is Nothing) Then
					RemoveHandler Me.RoomDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.RoomDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all room handlers
				For Each room As Gravitybox.Objects.Room In MainObject.RoomCollection
					RemoveHandler room.Refresh, AddressOf RoomRefresh
				Next

				'Catch provider add/delete
				RemoveHandler MainObject.ProviderCollection.InternalAfterAdd, AddressOf ProviderAdd
				RemoveHandler MainObject.ProviderCollection.InternalAfterRemove, AddressOf ProviderRemove
				RemoveHandler MainObject.ProviderCollection.InternalClearComplete, AddressOf ProviderClear
				If Not (Me.ProviderDataTable Is Nothing) Then
					RemoveHandler Me.ProviderDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.ProviderDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all provider handlers
				For Each provider As Gravitybox.Objects.Provider In MainObject.ProviderCollection
					RemoveHandler provider.Refresh, AddressOf ProviderRefresh
				Next

				'Catch resource add/delete
				RemoveHandler MainObject.ResourceCollection.InternalAfterAdd, AddressOf ResourceAdd
				RemoveHandler MainObject.ResourceCollection.InternalAfterRemove, AddressOf ResourceRemove
				RemoveHandler MainObject.ResourceCollection.InternalClearComplete, AddressOf ResourceClear
				If Not (Me.ResourceDataTable Is Nothing) Then
					RemoveHandler Me.ResourceDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.ResourceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all resource handlers
				For Each resource As Gravitybox.Objects.Resource In MainObject.ResourceCollection
					RemoveHandler resource.Refresh, AddressOf ResourceRefresh
				Next

				'Catch category add/delete
				RemoveHandler MainObject.CategoryCollection.InternalAfterAdd, AddressOf CategoryAdd
				RemoveHandler MainObject.CategoryCollection.InternalAfterRemove, AddressOf CategoryRemove
				RemoveHandler MainObject.CategoryCollection.InternalClearComplete, AddressOf CategoryClear
				If Not (Me.CategoryDataTable Is Nothing) Then
					RemoveHandler Me.CategoryDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.CategoryDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all category handlers
				For Each category As Gravitybox.Objects.Category In MainObject.CategoryCollection
					RemoveHandler category.Refresh, AddressOf CategoryRefresh
				Next

				'Catch appearance add/delete
				RemoveHandler MainObject.AppearanceCollection.InternalAfterAdd, AddressOf AppearanceAdd
				RemoveHandler MainObject.AppearanceCollection.InternalAfterRemove, AddressOf AppearanceRemove
				RemoveHandler MainObject.AppearanceCollection.InternalClearComplete, AddressOf AppearanceClear
				If Not (Me.AppearanceDataTable Is Nothing) Then
					RemoveHandler Me.AppearanceDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.AppearanceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all appearance handlers
				For Each appearance As Gravitybox.Objects.Appearance In MainObject.AppearanceCollection
					RemoveHandler appearance.Refresh, AddressOf AppearanceRefresh
				Next

				'Catch Recurrence add/delete
				RemoveHandler MainObject.RecurrenceCollection.InternalAfterAdd, AddressOf RecurrenceAdd
				RemoveHandler MainObject.RecurrenceCollection.InternalAfterRemove, AddressOf RecurrenceRemove
				RemoveHandler MainObject.RecurrenceCollection.InternalClearComplete, AddressOf RecurrenceClear
				If Not (Me.RecurrenceDataTable Is Nothing) Then
					RemoveHandler Me.RecurrenceDataTable.RowChanged, AddressOf DatasetRowChanged
					RemoveHandler Me.RecurrenceDataTable.RowDeleting, AddressOf DatasetRowDeleted
				End If

				'Remove all Recurrence handlers
				For Each recurrence As Gravitybox.Objects.Recurrence In MainObject.RecurrenceCollection
					RemoveHandler recurrence.Refresh, AddressOf RecurrenceRefresh
				Next

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Appointment Routines"

		Private Function CreateDataRowFromAppointment(ByVal dataTable As System.Data.DataTable, ByVal appointment As Gravitybox.Objects.Appointment) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this appointment
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, appointment.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_AppointmentTableName, text_AppointmentGUID, appointment.Key)
        Me.UpdateDataRowFromAppointment(appointment, dataTable, dr, isNew)
        MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateAppointmentFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Appointment

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_AppointmentTableName, text_AppointmentGUID)
				Dim startDate As Date = GetDateValue(dataRow, text_AppointmentTableName, text_StartDate)
        Dim startTime As Date = GetTime(startDate) 'Default start time to use this field
				Dim length As Integer = GetIntegerValue(dataRow, text_AppointmentTableName, text_Length)

				'If there is a start time field then use it
				If dataRow.Table.Columns.Contains(GetFieldName(text_AppointmentTableName, text_StartTime)) Then
          startDate = GetDateValue(dataRow, text_AppointmentTableName, text_StartDate)
					startTime = GetDateValue(dataRow, text_AppointmentTableName, text_StartTime)
				End If

				'Create the appointment
				Dim appointment As New Gravitybox.Objects.Appointment(key, MainObject)
				appointment.StartDate = startDate
				appointment.StartTime = startTime
        appointment.Length = length
        If (MainObject.UseDefaultAppearances) Then
          appointment.ResetAppearance(MainObject.DefaultAppointmentAppearance, MainObject.DefaultAppointmentHeaderAppearance)
        End If

				'Set optional properties
				Me.UpdateAppointmentFromDataRow(appointment, dataTable, dataRow)

				MainObject.AppointmentCollection.AddObject(appointment)

				'Add a handler for this appointment to catch when it changes
				AddHandler appointment.Refresh, AddressOf AppointmentRefresh

				Return appointment

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateAppointmentFromDataRow(ByVal appointment As Gravitybox.Objects.Appointment, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

      If dataRow.RowState = DataRowState.Detached Then Return False
			appointment.UnHookEvents()
			Try
				appointment.StartDate = GetDateValue(dataRow, text_AppointmentTableName, text_StartDate, appointment.StartDate)
				appointment.Length = GetIntegerValue(dataRow, text_AppointmentTableName, text_Length, appointment.Length)

				'Check for start time
				If TableContainsField(dataRow, text_AppointmentTableName, text_StartTime) Then
          appointment.StartDate = GetDateValue(dataRow, text_AppointmentTableName, text_StartDate, appointment.StartDate)
					appointment.StartTime = GetDateValue(dataRow, text_AppointmentTableName, text_StartTime, appointment.StartTime)
				Else
					appointment.StartTime = GetDateValue(dataRow, text_AppointmentTableName, text_StartDate, appointment.StartTime)
				End If

				appointment.Blockout = GetBooleanValue(dataRow, text_AppointmentTableName, text_Blockout, appointment.Blockout)
				appointment.IsEvent = GetBooleanValue(dataRow, text_AppointmentTableName, text_IsEvent, appointment.IsEvent)
				appointment.IsActivity = GetBooleanValue(dataRow, text_AppointmentTableName, text_IsActivity, appointment.IsActivity)
				appointment.IsFlagged = GetBooleanValue(dataRow, text_AppointmentTableName, text_IsFlagged, appointment.IsFlagged)
				appointment.IsReadOnly = GetBooleanValue(dataRow, text_AppointmentTableName, text_IsReadOnly, appointment.IsReadOnly)
				appointment.MaxLength = GetIntegerValue(dataRow, text_AppointmentTableName, text_MaxLength, appointment.MaxLength)
				appointment.MinLength = GetIntegerValue(dataRow, text_AppointmentTableName, text_MinLength, appointment.MinLength)
				appointment.Notes = GetStringValue(dataRow, text_AppointmentTableName, text_Notes)
				appointment.Subject = GetStringValue(dataRow, text_AppointmentTableName, text_Subject)
				appointment.Text = GetStringValue(dataRow, text_AppointmentTableName, text_Text)
				appointment.ToolTipText = GetStringValue(dataRow, text_AppointmentTableName, text_ToolTipText)
				appointment.Visible = GetBooleanValue(dataRow, text_AppointmentTableName, text_Visible, appointment.Visible)
				appointment.Alarm.WindowText = GetStringValue(dataRow, text_AppointmentTableName, text_AlarmWindowText)
				appointment.Alarm.IsArmed = GetBooleanValue(dataRow, text_AppointmentTableName, text_AlarmIsArmed, appointment.Alarm.IsArmed)
				appointment.Alarm.Reminder = GetIntegerValue(dataRow, text_AppointmentTableName, text_AlarmReminder, appointment.Alarm.Reminder)
				appointment.Alarm.AllowOpen = GetBooleanValue(dataRow, text_AppointmentTableName, text_AlarmAllowOpen, appointment.Alarm.AllowOpen)
				appointment.Alarm.AllowSnooze = GetBooleanValue(dataRow, text_AppointmentTableName, text_AlarmAllowSnooze, appointment.Alarm.AllowSnooze)

				'Check for Priority
        Dim priorityid As String = GetStringValue(dataRow, text_AppointmentTableName, text_Priority, Nothing)
        If Not (priorityid Is Nothing) Then
          If MainObject.PriorityCollection.Contains(priorityid) Then
            appointment.Priority = MainObject.PriorityCollection(priorityid)
          Else
            appointment.Priority = Nothing
          End If
        End If

				'Check for Recurrence
        Dim recurrenceid As String = GetStringValue(dataRow, text_AppointmentTableName, text_RecurrenceGUID, Nothing)
        If Not (recurrenceid Is Nothing) Then
          If MainObject.RecurrenceCollection.Contains(recurrenceid) Then
            appointment.Recurrence = MainObject.RecurrenceCollection(recurrenceid)
          Else
            appointment.Recurrence = Nothing
          End If
        End If

        'Check for RecurrenceStamp
        Dim recurrenceStamp As String = GetStringValue(dataRow, text_AppointmentTableName, text_RecurrenceStamp, Nothing)
        If Not (recurrenceStamp Is Nothing) Then
          appointment.ResetRecurrenceStamp(recurrenceStamp.Trim())
        End If

        'Check for Room
        Dim roomid As String = GetStringValue(dataRow, text_AppointmentTableName, text_Room, Nothing)
        If Not (roomid Is Nothing) Then
          If MainObject.RoomCollection.Contains(roomid) Then
            appointment.Room = MainObject.RoomCollection(roomid)
          Else
            appointment.Room = Nothing
          End If
        End If

        'Check for Appearance
        Dim appearanceid As String = GetStringValue(dataRow, text_AppointmentTableName, text_AppearanceGUID, Nothing)
        If Not (appearanceid Is Nothing) Then
          If MainObject.AppearanceCollection.Contains(appearanceid) Then
            appointment.Appearance = CType(MainObject.AppearanceCollection(appearanceid), AppointmentAppearance)
          End If
        End If

        'Update the Provider collections
        Dim apTable As System.Data.DataTable = Me.AppointmentProviderDataTable
        If Not (apTable Is Nothing) Then
          appointment.ProviderList.Clear()
          Dim drArray As System.Data.DataRow() = apTable.Select(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")
          Dim dr As System.Data.DataRow
          For Each dr In drArray
            Dim providerID As String = StripDBNull(dr(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)), "").Trim
            If MainObject.ProviderCollection.Contains(providerID) Then
              appointment.ProviderList.Add(MainObject.ProviderCollection(providerID))
            End If
          Next
        End If

        'Update the Resource collections
        Dim arTable As System.Data.DataTable = Me.AppointmentResourceDataTable
        If Not (arTable Is Nothing) Then
          appointment.ResourceList.Clear()
          Dim drArray As System.Data.DataRow() = arTable.Select(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")
          Dim dr As System.Data.DataRow
          For Each dr In drArray
            Dim resourceID As String = StripDBNull(dr(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)), "").Trim
            If MainObject.ResourceCollection.Contains(resourceID) Then
              appointment.ResourceList.Add(MainObject.ResourceCollection(resourceID))
            End If
          Next
        End If

        'Update the Category collections
        Dim acTable As System.Data.DataTable = Me.AppointmentCategoryDataTable
        If Not (acTable Is Nothing) Then
          appointment.CategoryList.Clear()
          Dim drArray As System.Data.DataRow() = acTable.Select(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")
          Dim dr As System.Data.DataRow
          For Each dr In drArray
            Dim categoryID As String = StripDBNull(dr(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)), "").Trim
            If MainObject.CategoryCollection.Contains(categoryID) Then
              appointment.CategoryList.Add(MainObject.CategoryCollection(categoryID))
            End If
          Next
        End If

        'Loop and find all columns NOT known and add them to the PropertyItemCollection
        Me.UpdateDataRowPropertyItems(dataRow, text_AppointmentTableName, validAppointmentFields, appointment.PropertyItemCollection)

        Return True

      Catch ex As Exception
        ErrorModule.SetErr(ex)
      Finally
        appointment.HookEvents()
        IsLoading = oldLoad
      End Try
			Return False

		End Function

		Private Function UpdateDataRowFromAppointment(ByVal appointment As Gravitybox.Objects.Appointment, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Length, appointment.Length)

				Me.UpdateValue(dataRow, text_AppointmentTableName, text_StartDate, appointment.StartDateTime)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_StartTime, appointment.StartDateTime)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Blockout, appointment.Blockout)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_IsEvent, appointment.IsEvent)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_IsActivity, appointment.IsActivity)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_IsFlagged, appointment.IsFlagged)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_IsReadOnly, appointment.IsReadOnly)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_MaxLength, appointment.MaxLength)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_MinLength, appointment.MinLength)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Notes, appointment.Notes)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Subject, appointment.Subject)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Text, appointment.Text)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_ToolTipText, appointment.ToolTipText)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_Visible, appointment.Visible)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_AlarmWindowText, appointment.Alarm.WindowText)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_AlarmIsArmed, appointment.Alarm.IsArmed)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_AlarmReminder, appointment.Alarm.Reminder)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_AlarmAllowOpen, appointment.Alarm.AllowOpen)
				Me.UpdateValue(dataRow, text_AppointmentTableName, text_AlarmAllowSnooze, appointment.Alarm.AllowSnooze)

				If appointment.Priority Is Nothing Then
					Me.UpdateValueNull(dataRow, text_AppointmentTableName, text_Priority)
				Else
					Me.UpdateValue(dataRow, text_AppointmentTableName, text_Priority, appointment.Priority.Key)
				End If

				If appointment.Recurrence Is Nothing Then
					Me.UpdateValueNull(dataRow, text_AppointmentTableName, text_RecurrenceGUID)
				Else
					Me.UpdateValue(dataRow, text_AppointmentTableName, text_RecurrenceGUID, appointment.Recurrence.Key)
				End If

				Me.UpdateValue(dataRow, text_AppointmentTableName, text_RecurrenceStamp, appointment.RecurrenceStamp)

				If appointment.Room Is Nothing Then
					Me.UpdateValueNull(dataRow, text_AppointmentTableName, text_Room)
				Else
					Me.UpdateValue(dataRow, text_AppointmentTableName, text_Room, appointment.Room.Key)
				End If

				'Check for Appearance link
				If MainObject.AppearanceCollection.Contains(appointment.Appearance.Key) Then
					Me.UpdateValue(dataRow, text_AppointmentTableName, text_AppearanceGUID, appointment.Appearance.Key)
				End If

				'**********************************************
				'This is the end of the appointment table updates so 
				'add the row so that the dependent tables below update correctly
				If isNew Then dataTable.Rows.Add(dataRow)
				'**********************************************

				'Update the Provider collections
				Dim apTable As System.Data.DataTable = Me.AppointmentProviderDataTable
				If Not (apTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = apTable.Select(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")

					'Loop through the Dataset and remove any rows that are no longer associated with the appointment
					Dim dr As System.Data.DataRow
					For Each dr In drArray
						Dim providerID As String = CStr(StripDBNull(dr(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID))))
						'If the datarow provider is NOT part of the appointment then remove the provider link datarow
						If Not appointment.ProviderList.Contains(providerID) Then
							dr.Delete()
						End If
					Next

					'Loop though the appointment's provider list and add any provider links that are NOT already in the dataset
					For Each provider As Gravitybox.Objects.Provider In appointment.ProviderList
						If apTable.Select(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "='" & appointment.Key & "' AND " & GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID) & "='" & provider.Key & "'").Length = 0 Then
							dr = apTable.NewRow()
							dr(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID)) = appointment.Key
							dr(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)) = provider.Key
							apTable.Rows.Add(dr)
						End If
					Next
				End If

				'Update the Resource collections
				Dim arTable As System.Data.DataTable = Me.AppointmentResourceDataTable
				If Not (arTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = arTable.Select(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")

					'Loop through the Dataset and remove any rows that are no longer associated with the appointment
					Dim dr As System.Data.DataRow
					For Each dr In drArray
						Dim resourceID As String = CStr(StripDBNull(dr(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID))))
						'If the datarow resource is NOT part of the appointment then remove the resource link datarow
						If Not appointment.ResourceList.Contains(resourceID) Then
							dr.Delete()
						End If
					Next

					'Loop though the appointment's resource list and add any resource links that are NOT already in the dataset
					For Each resource As Gravitybox.Objects.Resource In appointment.ResourceList
						If arTable.Select(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "='" & appointment.Key & "' AND " & GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID) & "='" & resource.Key & "'").Length = 0 Then
							dr = arTable.NewRow()
							dr(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID)) = appointment.Key
							dr(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)) = resource.Key
							arTable.Rows.Add(dr)
						End If
					Next
				End If

				'Update the Category collections
				Dim acTable As System.Data.DataTable = Me.AppointmentCategoryDataTable
				If Not (acTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = acTable.Select(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "='" & appointment.Key & "'")

					'Loop through the Dataset and remove any rows that are no longer associated with the appointment
					Dim dr As System.Data.DataRow
					For Each dr In drArray
						Dim categoryID As String = CStr(StripDBNull(dr(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID))))
						'If the datarow category is NOT part of the appointment then remove the category link datarow
						If Not appointment.CategoryList.Contains(categoryID) Then
							dr.Delete()
						End If
					Next

					'Loop though the appointment's category list and add any category links that are NOT already in the dataset
					For Each category As Gravitybox.Objects.Category In appointment.CategoryList
						If acTable.Select(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "='" & appointment.Key & "' AND " & GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID) & "='" & category.Key & "'").Length = 0 Then
							dr = acTable.NewRow()
							dr(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID)) = appointment.Key
							dr(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)) = category.Key
							acTable.Rows.Add(dr)
						End If
					Next
				End If

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In appointment.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateAppointmentDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_AppointmentGUID)) Then
					Return "The '" & AppointmentTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentTableName, text_AppointmentGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_StartDate)) Then
					Return "The '" & AppointmentTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentTableName, text_StartDate) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Length)) Then
					Return "The '" & AppointmentTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentTableName, text_Length) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_AppointmentTableName, text_AppointmentGUID)).AllowDBNull Then
					Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_AppointmentGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_AppointmentTableName, text_StartDate)).AllowDBNull Then
					Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_StartDate) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_StartTime)) AndAlso dataTable.Columns(GetFieldName(text_AppointmentTableName, text_StartTime)).AllowDBNull Then
					Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_StartTime) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Length)).AllowDBNull Then
					Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Length) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_AppointmentGUID)).Unique Then
					Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_AppointmentGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types

				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_AppointmentGUID)) Then
					Dim tp As System.Type = dataTable.Columns(GetFieldName(text_AppointmentTableName, text_AppointmentGUID)).DataType
					If (Not tp Is GetType(String)) AndAlso (Not tp Is GetType(System.Guid)) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_AppointmentGUID) & "' column must be marked String."
					End If
				End If

				'Check for StartDate
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_StartDate)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_StartDate)).DataType Is GetType(Date) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_StartDate) & "' column must be marked Date."
					End If
				End If

				'Check for StartTime
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_StartTime)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_StartTime)).DataType Is GetType(Date) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_StartTime) & "' column must be marked Date."
					End If
				End If

				'Check for Length
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Length)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Length)).DataType Is GetType(Integer) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Length) & "' column must be marked Integer."
					End If
				End If

				'Check for Blockout
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Blockout)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Blockout)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Blockout) & "' column must be marked Boolean."
					End If
				End If

				'Check for IsEvent
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_IsEvent)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_IsEvent)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_IsEvent) & "' column must be marked Boolean."
					End If
				End If

				'Check for IsActivity
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_IsActivity)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_IsActivity)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_IsActivity) & "' column must be marked Boolean."
					End If
				End If

				'Check for IsFlagged
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_IsFlagged)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_IsFlagged)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_IsFlagged) & "' column must be marked Boolean."
					End If
				End If

				'Check for IsReadOnly
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_IsReadOnly)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_IsReadOnly)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_IsReadOnly) & "' column must be marked Boolean."
					End If
				End If

				'Check for MaxLength
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_MaxLength)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_MaxLength)).DataType Is GetType(Integer) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_MaxLength) & "' column must be marked Integer."
					End If
				End If

				'Check for MinLength
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_MinLength)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_MinLength)).DataType Is GetType(Integer) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_MinLength) & "' column must be marked Integer."
					End If
				End If

				'Check for Notes
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Notes)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Notes)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Notes) & "' column must be marked String."
					End If
				End If

				'Check for Priority
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Priority)) Then
          If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Priority)).DataType Is GetType(String) Then
            Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Priority) & "' column must be marked String."
          End If
				End If

				'Check for RecurrenceId
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_RecurrenceGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_RecurrenceGUID)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_RecurrenceGUID) & "' column must be marked String."
					End If
				End If

				'Check for Recurrencestamp
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_RecurrenceStamp)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_RecurrenceStamp)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_RecurrenceStamp) & "' column must be marked String."
					End If
				End If

				'Check for Room
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Room)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Room)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Room) & "' column must be marked String."
					End If
				End If

				'Check for Subject
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Subject)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Subject)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Subject) & "' column must be marked String."
					End If
				End If

				'Check for Text
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Text)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Text)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Text) & "' column must be marked String."
					End If
				End If

				'Check for ToolTipText
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_ToolTipText)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_ToolTipText)).DataType Is GetType(String) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_ToolTipText) & "' column must be marked String."
					End If
				End If

				'Check for Visible
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentTableName, text_Visible)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentTableName, text_Visible)).DataType Is GetType(Boolean) Then
						Return "The '" & AppointmentTableName & "' datatable's '" & GetFieldName(text_AppointmentTableName, text_Visible) & "' column must be marked Boolean."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Room Routines"

		Private Function CreateDataRowFromRoom(ByVal dataTable As System.Data.DataTable, ByVal room As Gravitybox.Objects.Room) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this Room
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, room.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_RoomTableName, text_RoomGUID, room.Key)
				Me.UpdateDataRowFromRoom(room, dataTable, dr, isNew)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateRoomFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Room

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_RoomTableName, text_RoomGUID)
				Dim text As String = GetStringValue(dataRow, text_RoomTableName, text_Name)

				'Create the Room
				Dim room As New Gravitybox.Objects.Room(key)
				room.Text = text

				'Set optional properties
				Me.UpdateRoomFromDataRow(room, dataTable, dataRow)

				MainObject.RoomCollection.AddObject(room)

				'Add a handler for this Room to catch when it changes
				AddHandler room.Refresh, AddressOf RoomRefresh

				Return room

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateRoomFromDataRow(ByVal room As Gravitybox.Objects.Room, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				room.Text = GetStringValue(dataRow, text_RoomTableName, text_Name)
				room.Notes = GetStringValue(dataRow, text_RoomTableName, text_Notes)
				room.Visible = GetBooleanValue(dataRow, text_RoomTableName, text_Visible, room.Visible)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_RoomTableName, validRoomFields, room.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Sub UpdateDataRowPropertyItems(ByVal row As DataRow, ByVal tableName As String, ByVal validFieldNames As String(), ByVal propertyList As PropertyItemCollection)

			Try
				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				For Each dc As DataColumn In row.Table.Columns
          Dim columnName As String = Me.GetRealFieldName(tableName, dc.ColumnName)
          If Array.IndexOf(validFieldNames, columnName.ToLower) = -1 Then
            If Not (row.Table.Columns(columnName).DataType Is GetType(System.Byte())) Then
              If propertyList.Contains(columnName) Then
                propertyList(columnName).Setting = StripDBNull(row(columnName), Nothing)
              Else
                propertyList.Add(columnName, columnName, StripDBNull(row(columnName)))
              End If
            End If
          End If
        Next
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Function UpdateDataRowFromRoom(ByVal room As Gravitybox.Objects.Room, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_RoomTableName, text_Name, room.Text)
				Me.UpdateValue(dataRow, text_RoomTableName, text_Notes, room.Notes)
				Me.UpdateValue(dataRow, text_RoomTableName, text_Visible, room.Visible)

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In room.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				If isNew Then dataTable.Rows.Add(dataRow)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateRoomDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_RoomGUID)) Then
					Return "The '" & RoomTableName & "' datatable's must contain a '" & GetFieldName(text_RoomTableName, text_RoomGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_Name)) Then
					Return "The '" & RoomTableName & "' datatable's must contain a '" & GetFieldName(text_RoomTableName, text_Name) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_RoomTableName, text_RoomGUID)).AllowDBNull Then
					Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_RoomGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_RoomTableName, text_Name)).AllowDBNull Then
					Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_Name) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_RoomTableName, text_RoomGUID)).Unique Then
					Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_RoomGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_RoomGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_RoomTableName, text_RoomGUID)).DataType Is GetType(String) Then
						Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_RoomGUID) & "' column must be marked String."
					End If
				End If

				'Check for Name
				If dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_Name)) Then
					If Not dataTable.Columns(GetFieldName(text_RoomTableName, text_Name)).DataType Is GetType(String) Then
						Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_Name) & "' column must be marked String."
					End If
				End If

				'Check for Notes
				If dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_Notes)) Then
					If Not dataTable.Columns(GetFieldName(text_RoomTableName, text_Notes)).DataType Is GetType(String) Then
						Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_Notes) & "' column must be marked String."
					End If
				End If

				'Check for Visible
				If dataTable.Columns.Contains(GetFieldName(text_RoomTableName, text_Visible)) Then
					If Not dataTable.Columns(GetFieldName(text_RoomTableName, text_Visible)).DataType Is GetType(Boolean) Then
						Return "The '" & RoomTableName & "' datatable's '" & GetFieldName(text_RoomTableName, text_Visible) & "' column must be marked Boolean."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Provider Routines"

		Private Function CreateDataRowFromProvider(ByVal dataTable As System.Data.DataTable, ByVal provider As Gravitybox.Objects.Provider) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this Provider
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, provider.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_ProviderTableName, text_ProviderGUID, provider.Key)
				Me.UpdateDataRowFromProvider(provider, dataTable, dr, isNew)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateProviderFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Provider

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_ProviderTableName, text_ProviderGUID)
				Dim text As String = GetStringValue(dataRow, text_ProviderTableName, text_Name)
				Dim color As System.Drawing.Color = GetColorValue(dataRow, text_ProviderTableName, text_Color)

				'Create the Provider
				Dim provider As New Gravitybox.Objects.Provider(key)
				provider.Text = text

				'Set optional properties
				Me.UpdateProviderFromDataRow(provider, dataTable, dataRow)

				MainObject.ProviderCollection.AddObject(provider)

				'Add a handler for this Provider to catch when it changes
				AddHandler provider.Refresh, AddressOf ProviderRefresh

				Return provider

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateProviderFromDataRow(ByVal provider As Gravitybox.Objects.Provider, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				provider.Text = GetStringValue(dataRow, text_ProviderTableName, text_Name)
				'provider.Color = GetColorValue(dataRow, text_ProviderTableName, text_Color, provider.Color)
				provider.Appearance.BackColor = GetColorValue(dataRow, text_ProviderTableName, text_Color, provider.Appearance.BackColor)
				provider.Notes = GetStringValue(dataRow, text_ProviderTableName, text_Notes)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_ProviderTableName, validProviderFields, provider.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function UpdateDataRowFromProvider(ByVal provider As Gravitybox.Objects.Provider, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_ProviderTableName, text_Name, provider.Text)
				Me.UpdateValue(dataRow, text_ProviderTableName, text_Color, provider.Appearance.BackColor.ToArgb)
				Me.UpdateValue(dataRow, text_ProviderTableName, text_Notes, provider.Notes)

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In provider.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				If isNew Then dataTable.Rows.Add(dataRow)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateProviderDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_ProviderGUID)) Then
					Return "The '" & ProviderTableName & "' datatable must contain a '" & GetFieldName(text_ProviderTableName, text_ProviderGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_Name)) Then
					Return "The '" & ProviderTableName & "' datatable must contain a '" & GetFieldName(text_ProviderTableName, text_Name) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_Color)) Then
					Return "The '" & ProviderTableName & "' datatable must contain a '" & GetFieldName(text_ProviderTableName, text_Color) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_ProviderTableName, text_ProviderGUID)).AllowDBNull Then
					Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_ProviderGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_ProviderTableName, text_Name)).AllowDBNull Then
					Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_Name) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_ProviderTableName, text_Color)).AllowDBNull Then
					Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_Color) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_ProviderTableName, text_ProviderGUID)).Unique Then
					Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_ProviderGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_ProviderGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_ProviderTableName, text_ProviderGUID)).DataType Is GetType(String) Then
						Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_ProviderGUID) & "' column must be marked String."
					End If
				End If

				'Check for Name
				If dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_Name)) Then
					If Not dataTable.Columns(GetFieldName(text_ProviderTableName, text_Name)).DataType Is GetType(String) Then
						Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_Name) & "' column must be marked String."
					End If
				End If

				'Check for Notes
				If dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_Notes)) Then
					If Not dataTable.Columns(GetFieldName(text_ProviderTableName, text_Notes)).DataType Is GetType(String) Then
						Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_Notes) & "' column must be marked String."
					End If
				End If

				'Check for Color
				If dataTable.Columns.Contains(GetFieldName(text_ProviderTableName, text_Color)) Then
					If Not dataTable.Columns(GetFieldName(text_ProviderTableName, text_Color)).DataType Is GetType(Integer) Then
						Return "The '" & ProviderTableName & "' datatable's '" & GetFieldName(text_ProviderTableName, text_Color) & "' column must be marked Integer."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Resource Routines"

		Private Function CreateDataRowFromResource(ByVal dataTable As System.Data.DataTable, ByVal resource As Gravitybox.Objects.Resource) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this Resource
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, resource.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_ResourceTableName, text_ResourceGUID, resource.Key)
				Me.UpdateDataRowFromResource(resource, dataTable, dr, isNew)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateResourceFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Resource

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_ResourceTableName, text_ResourceGUID)
				Dim text As String = GetStringValue(dataRow, text_ResourceTableName, text_Name)
				Dim color As System.Drawing.Color = GetColorValue(dataRow, text_ResourceTableName, text_Color)

				'Create the Resource
				Dim resource As New Gravitybox.Objects.Resource(key)
				resource.Text = text

				'Set optional properties
				Me.UpdateResourceFromDataRow(resource, dataTable, dataRow)

				MainObject.ResourceCollection.AddObject(resource)

				'Add a handler for this Resource to catch when it changes
				AddHandler resource.Refresh, AddressOf ResourceRefresh

				Return resource

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateResourceFromDataRow(ByVal resource As Gravitybox.Objects.Resource, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				resource.Text = GetStringValue(dataRow, text_ResourceTableName, text_Name)
        resource.Appearance.BackColor = GetColorValue(dataRow, text_ResourceTableName, text_Color, resource.Appearance.BackColor)
				resource.Notes = GetStringValue(dataRow, text_ResourceTableName, text_Notes)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_ResourceTableName, validResourceFields, resource.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function UpdateDataRowFromResource(ByVal resource As Gravitybox.Objects.Resource, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_ResourceTableName, text_Name, resource.Text)
        Me.UpdateValue(dataRow, text_ResourceTableName, text_Color, resource.Appearance.BackColor.ToArgb)
				Me.UpdateValue(dataRow, text_ResourceTableName, text_Notes, resource.Notes)

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In resource.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				If isNew Then dataTable.Rows.Add(dataRow)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateResourceDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_ResourceGUID)) Then
					Return "The '" & ResourceTableName & "' datatable must contain a '" & GetFieldName(text_ResourceTableName, text_ResourceGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_Name)) Then
					Return "The '" & ResourceTableName & "' datatable must contain a '" & GetFieldName(text_ResourceTableName, text_Name) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_Color)) Then
					Return "The '" & ResourceTableName & "' datatable must contain a '" & GetFieldName(text_ResourceTableName, text_Color) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_ResourceTableName, text_ResourceGUID)).AllowDBNull Then
					Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_ResourceGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_ResourceTableName, text_Name)).AllowDBNull Then
					Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_Name) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_ResourceTableName, text_Color)).AllowDBNull Then
					Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_Color) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_ResourceTableName, text_ResourceGUID)).Unique Then
					Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_ResourceGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_ResourceGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_ResourceTableName, text_ResourceGUID)).DataType Is GetType(String) Then
						Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_ResourceGUID) & "' column must be marked String."
					End If
				End If

				'Check for Name
				If dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_Name)) Then
					If Not dataTable.Columns(GetFieldName(text_ResourceTableName, text_Name)).DataType Is GetType(String) Then
						Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_Name) & "' column must be marked String."
					End If
				End If

				'Check for Notes
				If dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_Notes)) Then
					If Not dataTable.Columns(GetFieldName(text_ResourceTableName, text_Notes)).DataType Is GetType(String) Then
						Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_Notes) & "' column must be marked String."
					End If
				End If

				'Check for Color
				If dataTable.Columns.Contains(GetFieldName(text_ResourceTableName, text_Color)) Then
					If Not dataTable.Columns(GetFieldName(text_ResourceTableName, text_Color)).DataType Is GetType(Integer) Then
						Return "The '" & ResourceTableName & "' datatable's '" & GetFieldName(text_ResourceTableName, text_Color) & "' column must be marked Integer."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Category Routines"

		Private Function CreateDataRowFromCategory(ByVal dataTable As System.Data.DataTable, ByVal category As Gravitybox.Objects.Category) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this Category
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, category.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_CategoryTableName, text_CategoryGUID, category.Key)
				Me.UpdateDataRowFromCategory(category, dataTable, dr, isNew)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateCategoryFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Category

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_CategoryTableName, text_CategoryGUID)
				Dim text As String = GetStringValue(dataRow, text_CategoryTableName, text_Name)
				Dim color As System.Drawing.Color = GetColorValue(dataRow, text_CategoryTableName, text_Color)

				'Create the Category
				Dim category As New Gravitybox.Objects.Category(key)
				category.Text = text

				'Set optional properties
				Me.UpdateCategoryFromDataRow(category, dataTable, dataRow)

				MainObject.CategoryCollection.AddObject(category)

				'Add a handler for this Category to catch when it changes
				AddHandler category.Refresh, AddressOf CategoryRefresh

				Return category

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateCategoryFromDataRow(ByVal category As Gravitybox.Objects.Category, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				category.Text = GetStringValue(dataRow, text_CategoryTableName, text_Name)
				category.Appearance.BackColor = GetColorValue(dataRow, text_CategoryTableName, text_Color)
				category.Notes = GetStringValue(dataRow, text_CategoryTableName, text_Notes)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_CategoryTableName, validCategoryFields, category.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function UpdateDataRowFromCategory(ByVal category As Gravitybox.Objects.Category, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_CategoryTableName, text_Name, category.Text)
				Me.UpdateValue(dataRow, text_CategoryTableName, text_Color, category.Appearance.BackColor.ToArgb)
				Me.UpdateValue(dataRow, text_CategoryTableName, text_Notes, category.Notes)

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In category.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				If isNew Then dataTable.Rows.Add(dataRow)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateCategoryDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_CategoryGUID)) Then
					Return "The '" & CategoryTableName & "' datatable must contain a '" & GetFieldName(text_CategoryTableName, text_CategoryGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_Name)) Then
					Return "The '" & CategoryTableName & "' datatable must contain a '" & GetFieldName(text_CategoryTableName, text_Name) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_Color)) Then
					Return "The '" & CategoryTableName & "' datatable must contain a '" & GetFieldName(text_CategoryTableName, text_Color) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_CategoryTableName, text_CategoryGUID)).AllowDBNull Then
					Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_CategoryGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_CategoryTableName, text_Name)).AllowDBNull Then
					Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_Name) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_CategoryTableName, text_Color)).AllowDBNull Then
					Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_Color) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_CategoryTableName, text_CategoryGUID)).Unique Then
					Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_CategoryGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_CategoryGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_CategoryTableName, text_CategoryGUID)).DataType Is GetType(String) Then
						Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_CategoryGUID) & "' column must be marked String."
					End If
				End If

				'Check for Name
				If dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_Name)) Then
					If Not dataTable.Columns(GetFieldName(text_CategoryTableName, text_Name)).DataType Is GetType(String) Then
						Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_Name) & "' column must be marked String."
					End If
				End If

				'Check for Notes
				If dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_Notes)) Then
					If Not dataTable.Columns(GetFieldName(text_CategoryTableName, text_Notes)).DataType Is GetType(String) Then
						Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_Notes) & "' column must be marked String."
					End If
				End If

				'Check for Color
				If dataTable.Columns.Contains(GetFieldName(text_CategoryTableName, text_Color)) Then
					If Not dataTable.Columns(GetFieldName(text_CategoryTableName, text_Color)).DataType Is GetType(Integer) Then
						Return "The '" & CategoryTableName & "' datatable's '" & GetFieldName(text_CategoryTableName, text_Color) & "' column must be marked Integer."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Appearance Routines"

		Private Function CreateDataRowFromAppearance(ByVal dataTable As System.Data.DataTable, ByVal appearance As Gravitybox.Objects.Appearance) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim newRow As Boolean = False
				'Create a new DataRow for this Appearance
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, appearance.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					newRow = True
				End If

				Me.UpdateValue(dr, text_AppearanceTableName, text_AppearanceGUID, appearance.Key)
				Me.UpdateDataRowFromAppearance(appearance, dataTable, dr)
				If newRow Then dataTable.Rows.Add(dr)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateAppearanceFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.AppointmentAppearance

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_AppearanceTableName, text_AppearanceGUID)
				Dim text As String = GetStringValue(dataRow, text_AppearanceTableName, text_Name)

				'Create the Appearance
				Dim appearance As New Gravitybox.Objects.AppointmentAppearance(key)
				appearance.Text = text

				'Set optional properties
				Me.UpdateAppearanceFromDataRow(appearance, dataTable, dataRow)

				MainObject.AppearanceCollection.AddObject(appearance)

				'Add a handler for this Appearance to catch when it changes
				AddHandler appearance.Refresh, AddressOf AppearanceRefresh

				Return appearance

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateAppearanceFromDataRow(ByVal appearance As Gravitybox.Objects.AppointmentAppearance, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				appearance.Text = GetStringValue(dataRow, text_AppearanceTableName, text_Name)
				appearance.Alignment = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_Alignment, appearance.Alignment), StringAlignment)
				appearance.BackColor = GetColorValue(dataRow, text_AppearanceTableName, text_BackColor, appearance.BackColor)
				appearance.BackColor2 = GetColorValue(dataRow, text_AppearanceTableName, text_BackColor2, appearance.BackColor2)
				appearance.BackGradientStyle = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_BackGradientStyle, appearance.BackGradientStyle), Gravitybox.Objects.GradientStyleConstants)
				appearance.BorderColor = GetColorValue(dataRow, text_AppearanceTableName, text_BorderColor, appearance.BorderColor)
				appearance.BorderWidth = GetIntegerValue(dataRow, text_AppearanceTableName, text_BorderWidth, appearance.BorderWidth)
				appearance.FontBold = GetBooleanValue(dataRow, text_AppearanceTableName, text_FontBold, appearance.FontBold)
				appearance.FontItalics = GetBooleanValue(dataRow, text_AppearanceTableName, text_FontItalics, appearance.FontItalics)
				appearance.FontSize = GetIntegerValue(dataRow, text_AppearanceTableName, text_FontSize, CType(appearance.FontSize, Integer))
				appearance.FontStrikeout = GetBooleanValue(dataRow, text_AppearanceTableName, text_FontStrikeout, appearance.FontStrikeout)
				appearance.FontUnderline = GetBooleanValue(dataRow, text_AppearanceTableName, text_FontUnderline, appearance.FontUnderline)
				appearance.FontUnit = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_FontUnit, appearance.FontUnit), GraphicsUnit)
				appearance.ForeColor = GetColorValue(dataRow, text_AppearanceTableName, text_ForeColor, appearance.ForeColor)
				appearance.StringFormatFlags = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_StringFormatFlags, appearance.StringFormatFlags), StringFormatFlags)
				appearance.TextTrimming = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_TextTrimming, appearance.TextTrimming), StringTrimming)
				appearance.TextVAlign = CType(GetIntegerValue(dataRow, text_AppearanceTableName, text_TextVAlign, appearance.TextVAlign), StringAlignment)
				appearance.ShadowSize = GetIntegerValue(dataRow, text_AppearanceTableName, text_ShadowSize, appearance.ShadowSize)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_AppearanceTableName, validAppearanceFields, appearance.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function UpdateDataRowFromAppearance(ByVal appearance As Gravitybox.Objects.Appearance, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_Name, appearance.Text)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_Alignment, CType(appearance.Alignment, Integer))
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_BackColor, appearance.BackColor.ToArgb)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_BackColor2, appearance.BackColor2.ToArgb)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_BackGradientStyle, CType(appearance.BackGradientStyle, Integer))
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_BorderColor, appearance.BorderColor.ToArgb)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_BorderWidth, appearance.BorderWidth)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontBold, appearance.FontBold)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontItalics, appearance.FontItalics)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontSize, appearance.FontSize)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontStrikeout, appearance.FontStrikeout)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontUnderline, appearance.FontUnderline)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_FontUnit, CType(appearance.FontUnit, Integer))
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_ForeColor, appearance.ForeColor.ToArgb)
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_StringFormatFlags, CType(appearance.StringFormatFlags, Integer))
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_TextTrimming, CType(appearance.TextTrimming, Integer))
				Me.UpdateValue(dataRow, text_AppearanceTableName, text_TextVAlign, CType(appearance.TextVAlign, Integer))
				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateAppearanceDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_AppearanceGUID)) Then
					Return "The '" & AppearanceTableName & "' datatable must contain a '" & GetFieldName(text_AppearanceTableName, text_AppearanceGUID) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_AppearanceTableName, text_AppearanceGUID)).AllowDBNull Then
					Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_AppearanceGUID) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_AppearanceGUID)).Unique Then
					Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_AppearanceGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_AppearanceGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_AppearanceGUID)).DataType Is GetType(String) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_AppearanceGUID) & "' column must be marked String."
					End If
				End If

				'Check for Text
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_Text)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_Text)).DataType Is GetType(String) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_Text) & "' column must be marked String."
					End If
				End If

				'Check for Alignment
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_Alignment)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_Alignment)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_Alignment) & "' column must be marked Integer."
					End If
				End If

				'Check for BackColor
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_BackColor)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_BackColor)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_BackColor) & "' column must be marked Integer."
					End If
				End If

				'Check for BackColor2
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_BackColor2)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_BackColor2)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_BackColor2) & "' column must be marked Integer."
					End If
				End If

				'Check for BackGradientStyle
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_BackGradientStyle)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_BackGradientStyle)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_BackGradientStyle) & "' column must be marked Integer."
					End If
				End If

				'Check for BorderColor
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_BorderColor)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_BorderColor)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_BorderColor) & "' column must be marked Integer."
					End If
				End If

				'Check for BorderWidth
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_BorderWidth)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_BorderWidth)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_BorderWidth) & "' column must be marked Integer."
					End If
				End If

				'Check for FontBold
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontBold)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontBold)).DataType Is GetType(Boolean) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontBold) & "' column must be marked Boolean."
					End If
				End If

				'Check for FontItalics
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontItalics)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontItalics)).DataType Is GetType(Boolean) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontItalics) & "' column must be marked Boolean."
					End If
				End If

				'Check for FontSize
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontSize)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontSize)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontSize) & "' column must be marked Integer."
					End If
				End If

				'Check for FontStrikeout
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontStrikeout)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontStrikeout)).DataType Is GetType(Boolean) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontStrikeout) & "' column must be marked Boolean."
					End If
				End If

				'Check for FontUnderline
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontUnderline)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontUnderline)).DataType Is GetType(Boolean) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontUnderline) & "' column must be marked Boolean."
					End If
				End If

				'Check for FontUnit
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_FontUnit)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_FontUnit)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_FontUnit) & "' column must be marked Integer."
					End If
				End If

				'Check for ForeColor
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_ForeColor)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_ForeColor)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_ForeColor) & "' column must be marked Integer."
					End If
				End If

				'Check for StringFormatFlags
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_StringFormatFlags)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_StringFormatFlags)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_StringFormatFlags) & "' column must be marked Integer."
					End If
				End If

				'Check for TextTrimming
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_TextTrimming)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_TextTrimming)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_TextTrimming) & "' column must be marked Integer."
					End If
				End If

				'Check for TextVAlign
				If dataTable.Columns.Contains(GetFieldName(text_AppearanceTableName, text_TextVAlign)) Then
					If Not dataTable.Columns(GetFieldName(text_AppearanceTableName, text_TextVAlign)).DataType Is GetType(Integer) Then
						Return "The '" & AppearanceTableName & "' datatable's '" & GetFieldName(text_AppearanceTableName, text_TextVAlign) & "' column must be marked Integer."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Recurrence Routines"

		Private Function CreateDataRowFromRecurrence(ByVal dataTable As System.Data.DataTable, ByVal recurrence As Gravitybox.Objects.Recurrence) As System.Data.DataRow

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Dim isNew As Boolean = False
				'Create a new DataRow for this Recurrence
				Dim dr As System.Data.DataRow = Me.GetDataRow(dataTable, recurrence.Key)
				If dr Is Nothing Then
					dr = dataTable.NewRow()
					isNew = True
				End If

				Me.UpdateValue(dr, text_RecurrenceTableName, text_RecurrenceGUID, recurrence.Key)
				Me.UpdateDataRowFromRecurrence(recurrence, dataTable, dr, isNew)
				MainObject.FireEventDataSourceUpdated()

				Return dr

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return Nothing

		End Function

		Private Function CreateRecurrenceFromDataRow(ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Gravitybox.Objects.Recurrence

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Must exist fields
				Dim key As String = GetStringValue(dataRow, text_RecurrenceTableName, text_RecurrenceGUID)

				'Create the Recurrence
				Dim recurrence As New Gravitybox.Objects.Recurrence(key)

				'Set optional properties
				Me.UpdateRecurrenceFromDataRow(recurrence, dataTable, dataRow)

				MainObject.RecurrenceCollection.AddObject(recurrence)

				'Add a handler for this Recurrence to catch when it changes
				AddHandler recurrence.Refresh, AddressOf RecurrenceRefresh

				Return recurrence

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

			Return Nothing

		End Function

		Private Function UpdateRecurrenceFromDataRow(ByVal recurrence As Gravitybox.Objects.Recurrence, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				recurrence.RecurrenceInterval = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_recurrence_interval, recurrence.RecurrenceInterval), RecurrenceIntervalConstants)
				recurrence.StartDate = GetDateValue(dataRow, text_RecurrenceTableName, text_StartDate, recurrence.StartDate)
				recurrence.EndType = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_End_Type, recurrence.EndType), RecurrenceEndConstants)
				recurrence.EndIterations = GetIntegerValue(dataRow, text_RecurrenceTableName, text_End_Iterations, recurrence.EndIterations)
				recurrence.EndDate = GetDateValue(dataRow, text_RecurrenceTableName, text_EndDate, recurrence.EndDate)
				recurrence.LastCreateDate = GetDateValue(dataRow, text_RecurrenceTableName, text_Last_Create_Date, recurrence.LastCreateDate)
				recurrence.LastCreateGroupId = GetStringValue(dataRow, text_RecurrenceTableName, text_Last_Create_GroupId, recurrence.LastCreateGroupId)
				recurrence.CheckOnly = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Check_only, recurrence.CheckOnly)
				recurrence.RecurrenceDay.RecurrenceMode = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Day_Recurrence_Mode, recurrence.RecurrenceDay.RecurrenceMode), RecurrenceDayConstants)
				recurrence.RecurrenceDay.DayInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Day_Day_Interval, recurrence.RecurrenceDay.DayInterval)
				recurrence.RecurrenceMonth.RecurrenceMode = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Month_Recurrence_Mode, recurrence.RecurrenceMonth.RecurrenceMode), RecurrenceSubTypeConstants)
				recurrence.RecurrenceMonth.MonthInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Month_Month_Interval, recurrence.RecurrenceMonth.MonthInterval)
				recurrence.RecurrenceMonth.DayInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Month_Day_Interval, recurrence.RecurrenceMonth.DayInterval)
				recurrence.RecurrenceMonth.DayOrdinal = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Month_Day_Ordinal, recurrence.RecurrenceMonth.DayOrdinal), RecurrenceOrdinalConstants)
				recurrence.RecurrenceMonth.DayPosition = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Month_Day_Position, recurrence.RecurrenceMonth.DayPosition), RecurrenceOrdinalDayConstants)
				recurrence.RecurrenceWeek.WeekInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Week_Week_Interval, recurrence.RecurrenceWeek.WeekInterval)
				recurrence.RecurrenceWeek.UseSun = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Sun, recurrence.RecurrenceWeek.UseSun)
				recurrence.RecurrenceWeek.UseMon = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Mon, recurrence.RecurrenceWeek.UseMon)
				recurrence.RecurrenceWeek.UseTue = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Tue, recurrence.RecurrenceWeek.UseTue)
				recurrence.RecurrenceWeek.UseWed = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Wed, recurrence.RecurrenceWeek.UseWed)
				recurrence.RecurrenceWeek.UseThu = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Thu, recurrence.RecurrenceWeek.UseThu)
				recurrence.RecurrenceWeek.UseFri = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Fri, recurrence.RecurrenceWeek.UseFri)
        recurrence.RecurrenceWeek.UseSat = GetBooleanValue(dataRow, text_RecurrenceTableName, text_Week_Use_Sat, recurrence.RecurrenceWeek.UseSat)
        recurrence.RecurrenceYear.DayInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Day_Interval, recurrence.RecurrenceYear.DayInterval)
        recurrence.RecurrenceYear.DayOrdinal = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Day_Ordinal, recurrence.RecurrenceYear.DayOrdinal), RecurrenceOrdinalConstants)
        recurrence.RecurrenceYear.DayPosition = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Day_Position, recurrence.RecurrenceYear.DayPosition), RecurrenceOrdinalDayConstants)
        recurrence.RecurrenceYear.MonthInterval = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Month_Interval, recurrence.RecurrenceYear.DayInterval)
        recurrence.RecurrenceYear.MonthOrdinal = GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Month_Ordinal, recurrence.RecurrenceYear.DayInterval)
        recurrence.RecurrenceYear.RecurrenceMode = CType(GetIntegerValue(dataRow, text_RecurrenceTableName, text_Year_Recurrence_Mode, recurrence.RecurrenceYear.RecurrenceMode), RecurrenceSubTypeConstants)

				'Loop and find all columns NOT known and add them to the PropertyItemCollection
				Me.UpdateDataRowPropertyItems(dataRow, text_RecurrenceTableName, validRecurrenceFields, recurrence.PropertyItemCollection)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function UpdateDataRowFromRecurrence(ByVal recurrence As Gravitybox.Objects.Recurrence, ByVal dataTable As System.Data.DataTable, ByVal dataRow As System.Data.DataRow, ByVal isNew As Boolean) As Boolean

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_recurrence_interval, recurrence.RecurrenceInterval)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_StartDate, recurrence.StartDate)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_End_Type, CType(recurrence.EndType, Integer))
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_End_Iterations, recurrence.EndIterations)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_EndDate, recurrence.EndDate)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Last_Create_Date, recurrence.LastCreateDate)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Last_Create_GroupId, recurrence.LastCreateGroupId)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Check_only, recurrence.CheckOnly)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Day_Recurrence_Mode, CType(recurrence.RecurrenceDay.RecurrenceMode, Integer))
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Day_Day_Interval, recurrence.RecurrenceDay.DayInterval)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Month_Recurrence_Mode, CType(recurrence.RecurrenceMonth.RecurrenceMode, Integer))
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Month_Month_Interval, recurrence.RecurrenceMonth.MonthInterval)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Month_Day_Interval, recurrence.RecurrenceMonth.DayInterval)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Month_Day_Ordinal, CType(recurrence.RecurrenceMonth.DayOrdinal, Integer))
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Month_Day_Position, CType(recurrence.RecurrenceMonth.DayPosition, Integer))
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Week_Interval, recurrence.RecurrenceWeek.WeekInterval)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Sun, recurrence.RecurrenceWeek.UseSun)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Mon, recurrence.RecurrenceWeek.UseMon)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Tue, recurrence.RecurrenceWeek.UseTue)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Wed, recurrence.RecurrenceWeek.UseWed)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Thu, recurrence.RecurrenceWeek.UseThu)
				Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Fri, recurrence.RecurrenceWeek.UseFri)
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Week_Use_Sat, recurrence.RecurrenceWeek.UseSat)
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Day_Interval, recurrence.RecurrenceYear.DayInterval)
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Day_Ordinal, CType(recurrence.RecurrenceYear.DayOrdinal, Integer))
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Day_Position, CType(recurrence.RecurrenceYear.DayPosition, Integer))
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Month_Interval, recurrence.RecurrenceYear.MonthInterval)
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Month_Ordinal, recurrence.RecurrenceYear.MonthOrdinal)
        Me.UpdateValue(dataRow, text_RecurrenceTableName, text_Year_Recurrence_Mode, CType(recurrence.RecurrenceYear.RecurrenceMode, Integer))

				'Loop through the PropertyItems and save the 
				'ones that match a column in the datarow
				Dim propItem As Gravitybox.Objects.PropertyItem
				For Each propItem In recurrence.PropertyItemCollection
					Me.SetPropertyItemDataRow(dataRow, propItem)
				Next

				If isNew Then dataTable.Rows.Add(dataRow)

				Return True

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try
			Return False

		End Function

		Private Function ValidateRecurrenceDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)) Then
					Return "The '" & RecurrenceTableName & "' datatable's must contain a '" & GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)).AllowDBNull Then
					Return "The '" & RecurrenceTableName & "' datatable's '" & GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for unique key
				If Not dataTable.Columns(GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)).Unique Then
					Return "The '" & RecurrenceTableName & "' datatable's '" & GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID) & "' column must marked as unique."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Key
				If dataTable.Columns.Contains(GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)).DataType Is GetType(String) Then
						Return "The '" & RecurrenceTableName & "' datatable's '" & GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID) & "' column must be marked String."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Other Validation"

		Private Function ValidateAppointmentProviderDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID)) Then
					Return "The '" & AppointmentProviderTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)) Then
					Return "The '" & AppointmentProviderTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID)).AllowDBNull Then
					Return "The '" & AppointmentProviderTableName & "' datatable's '" & GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)).AllowDBNull Then
					Return "The '" & AppointmentProviderTableName & "' datatable's '" & GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Appointment key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID)) Then
					Dim tp As System.Type = dataTable.Columns(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID)).DataType
					If (Not tp Is GetType(String)) AndAlso (Not tp Is GetType(System.Guid)) Then
						Return "The '" & AppointmentProviderTableName & "' datatable's '" & GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "' column must be marked String."
					End If
				End If

				'Check for Provider key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID)).DataType Is GetType(String) Then
						Return "The '" & AppointmentProviderTableName & "' datatable's '" & GetFieldName(text_AppointmentProviderTableName, text_ProviderGUID) & "' column must be marked String."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

		Private Function ValidateAppointmentResourceDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID)) Then
					Return "The '" & AppointmentResourceTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)) Then
					Return "The '" & AppointmentResourceTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID)).AllowDBNull Then
					Return "The '" & AppointmentResourceTableName & "' datatable's '" & GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)).AllowDBNull Then
					Return "The '" & AppointmentResourceTableName & "' datatable's '" & GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Appointment key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID)) Then
					Dim tp As System.Type = dataTable.Columns(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID)).DataType
					If (Not tp Is GetType(String)) AndAlso (Not tp Is GetType(System.Guid)) Then
						Return "The '" & AppointmentResourceTableName & "' datatable's '" & GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "' column must be marked String."
					End If
				End If

				'Check for Resource key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID)).DataType Is GetType(String) Then
						Return "The '" & AppointmentResourceTableName & "' datatable's '" & GetFieldName(text_AppointmentResourceTableName, text_ResourceGUID) & "' column must be marked String."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

		Private Function ValidateAppointmentCategoryDataTable(ByVal dataTable As System.Data.DataTable) As String

			Try

				'**************************************************
				'Verify that the required columns exist
				If Not dataTable.Columns.Contains(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID)) Then
					Return "The '" & AppointmentCategoryTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "' column."
				ElseIf Not dataTable.Columns.Contains(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)) Then
					Return "The '" & AppointmentCategoryTableName & "' datatable must contain a '" & GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID) & "' column."
				End If

				'**************************************************
				'Check for AllowDBNull
				If dataTable.Columns(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID)).AllowDBNull Then
					Return "The '" & AppointmentCategoryTableName & "' datatable's '" & GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "' column must be marked to disallow DbNull."
				ElseIf dataTable.Columns(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)).AllowDBNull Then
					Return "The '" & AppointmentCategoryTableName & "' datatable's '" & GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID) & "' column must be marked to disallow DbNull."
				End If

				'**************************************************
				'Check for valid column types
				'Check for Appointment key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID)) Then
					Dim tp As System.Type = dataTable.Columns(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID)).DataType
					If (Not tp Is GetType(String)) AndAlso (Not tp Is GetType(System.Guid)) Then
						Return "The '" & AppointmentCategoryTableName & "' datatable's '" & GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "' column must be marked String."
					End If
				End If

				'Check for Category key
				If dataTable.Columns.Contains(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)) Then
					If Not dataTable.Columns(GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID)).DataType Is GetType(String) Then
						Return "The '" & AppointmentCategoryTableName & "' datatable's '" & GetFieldName(text_AppointmentCategoryTableName, text_CategoryGUID) & "' column must be marked String."
					End If
				End If

			Catch ex As Exception
				Return ex.ToString
			End Try
			Return Nothing

		End Function

#End Region

#Region "Other Methods"

		Friend Function TableContainsField(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As Boolean
			Return row.Table.Columns.Contains(GetFieldName(tableName, fieldName))
		End Function

		Friend Function GetDateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As Date
			Return GetDateValue(row, tableName, fieldName, ScheduleGlobals.DefaultNoDate)
		End Function

    Friend Function GetDateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal defaultValue As Date) As Date
      Try
        fieldName = GetFieldName(tableName, fieldName)
        If Not row.Table.Columns.Contains(fieldName) Then Return defaultValue
        If row(fieldName) Is DBNull.Value Then
          Return defaultValue
        Else
          Return CDate(row(fieldName))
        End If
      Catch ex As Exception
        Throw
      End Try
    End Function

		Friend Function GetStringValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As String
			Return GetStringValue(row, tableName, fieldName, "")
		End Function

		Friend Function GetStringValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal defaultValue As String) As String
			fieldName = GetFieldName(tableName, fieldName)
			If Not row.Table.Columns.Contains(fieldName) Then Return defaultValue
			If row(fieldName) Is DBNull.Value Then
				Return defaultValue
			Else
				Return CStr(row(fieldName))
			End If
		End Function

		Friend Function GetBooleanValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As Boolean
			Return GetBooleanValue(row, tableName, fieldName, False)
		End Function

		Friend Function GetBooleanValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal defaultValue As Boolean) As Boolean
			fieldName = GetFieldName(tableName, fieldName)
      If Not row.Table.Columns.Contains(fieldName) Then Return defaultValue
			If row(fieldName) Is DBNull.Value Then
				Return defaultValue
			Else
				Return CBool(row(fieldName))
			End If
		End Function

		Friend Function GetIntegerValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As Integer
			Return GetIntegerValue(row, tableName, fieldName, 0)
		End Function

		Friend Function GetIntegerValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal defaultValue As Integer) As Integer
			fieldName = GetFieldName(tableName, fieldName)
			If Not row.Table.Columns.Contains(fieldName) Then Return defaultValue
			If row(fieldName) Is DBNull.Value Then
				Return defaultValue
			Else
				Return GetIntlInteger(row(fieldName))
			End If
		End Function

		Friend Function GetColorValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String) As Color
			Return GetColorValue(row, tableName, fieldName, Color.Black)
		End Function

		Friend Function GetColorValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal defaultValue As Color) As Color
			fieldName = GetFieldName(tableName, fieldName)
			If Not row.Table.Columns.Contains(fieldName) Then Return defaultValue
			If row(fieldName) Is DBNull.Value Then
				Return defaultValue
			Else
				Return GetColor(GetIntlInteger(row(fieldName)))
			End If
		End Function

		Private Function GetDataRow(ByVal dataTable As System.Data.DataTable, ByVal key As String) As System.Data.DataRow

			Try
				Dim fieldName As String = ""
				Select Case dataTable.TableName.ToLower
					Case AppointmentTableName.ToLower
						fieldName = GetFieldName(text_AppointmentTableName, text_AppointmentGUID)
					Case RoomTableName.ToLower
						fieldName = GetFieldName(text_RoomTableName, text_RoomGUID)
					Case ProviderTableName.ToLower
						fieldName = GetFieldName(text_ProviderTableName, text_ProviderGUID)
					Case ResourceTableName.ToLower
						fieldName = GetFieldName(text_ResourceTableName, text_ResourceGUID)
					Case CategoryTableName.ToLower
						fieldName = GetFieldName(text_CategoryTableName, text_CategoryGUID)
					Case AppearanceTableName.ToLower
						fieldName = GetFieldName(text_AppearanceTableName, text_AppearanceGUID)
					Case RecurrenceTableName.ToLower
						fieldName = GetFieldName(text_RecurrenceTableName, text_RecurrenceGUID)
				End Select
				Dim rows() As DataRow = dataTable.Select(fieldName & "='" & key & "'")
				If rows.Length = 1 Then
					Return rows(0)
				Else
					Return Nothing
				End If
			Catch ex As Exception
				Throw ex
			End Try

		End Function

		Friend Function StripDBNull(ByVal o As Object) As String
			Return StripDBNull(o, Nothing)
		End Function

		Friend Function StripDBNull(ByVal o As Object, ByVal defaultValue As String) As String

			If o Is System.DBNull.Value Then
				Return defaultValue
			Else
				Return CStr(o)
			End If

		End Function

		Private Function GetString(ByVal text As String, ByVal maxLength As Integer) As String

			'Error Check
			If text Is Nothing Then text = ""
			If maxLength = -1 Then Return text
			If maxLength < 0 Then maxLength = 0

			'Ensure that the string is NOT longer than the maxlength
			If text.Length > maxLength Then
				text.Substring(0, maxLength)
			End If
			Return text

		End Function

		Private Function IsCascade(ByVal dataTable1 As DataTable, ByVal dataTable2 As DataTable) As Boolean

			Try
				Dim ds As DataSet = GetDataSet()
				For Each relation As System.Data.DataRelation In ds.Relations
					'Determine if this relation is for the two defined table
					If (relation.ParentTable Is dataTable1) AndAlso (relation.ChildTable Is dataTable2) Then
						If Not (relation.ChildKeyConstraint Is Nothing) Then
							If relation.ChildKeyConstraint.DeleteRule = Rule.Cascade Then
								Return True
							End If
						End If
					End If
				Next
				Return False
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Sub UpdateValueNull(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String)
			Try
				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				If Not (row(fieldName) Is DBNull.Value) Then
					row(fieldName) = DBNull.Value
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub UpdateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal newValue As Boolean)
			Try
				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				Dim oldValue As Boolean
				If row(fieldName) Is DBNull.Value Then
					oldValue = Not newValue					'Something Different
				Else
					oldValue = CType(row(fieldName), Boolean)
				End If
				If oldValue <> newValue Then row(fieldName) = newValue
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub UpdateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal newValue As Integer)
			Try
				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				Dim oldValue As Integer = 0
				If row(fieldName) Is DBNull.Value Then
					oldValue = newValue + 1				 'Something Different
				Else
					oldValue = CType(row(fieldName), Integer)
				End If
				If oldValue <> newValue Then row(fieldName) = newValue
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub UpdateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal newValue As Single)
			Try
				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				Dim oldValue As Single = 0
				If row(fieldName) Is DBNull.Value Then
					oldValue = newValue + 1				 'Something Different
				Else
					oldValue = CType(row(fieldName), Single)
				End If
				If oldValue <> newValue Then row(fieldName) = newValue
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub UpdateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal newValue As DateTime)
			Try
				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				Dim oldValue As DateTime
				If row(fieldName) Is DBNull.Value Then
					oldValue = newValue.AddMinutes(1)				 'Something Different
				Else
					oldValue = CType(row(fieldName), DateTime)
				End If
				If oldValue <> newValue Then row(fieldName) = newValue
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub UpdateValue(ByVal row As DataRow, ByVal tableName As String, ByVal fieldName As String, ByVal newValue As String)
			Try
				If (newValue Is Nothing) Then
					Me.UpdateValueNull(row, tableName, fieldName)
					Return
				End If

				fieldName = Me.GetFieldName(tableName, fieldName)
				If Not row.Table.Columns.Contains(fieldName) Then Return
				Dim maxLength As Integer = row.Table.Columns(fieldName).MaxLength
				Dim oldValue As String = ""
				If row(fieldName) Is DBNull.Value Then
					oldValue = newValue & "X"				 'Something Different
				Else
					oldValue = CType(row(fieldName), String)
				End If
        If oldValue <> newValue Then
          If row.Table.Columns(fieldName).DataType Is GetType(Date) Then
            If newValue = "" Then
              row(fieldName) = System.DBNull.Value
            Else
              row(fieldName) = DateTime.Parse(Me.GetString(newValue, maxLength))
            End If
          Else
            row(fieldName) = Me.GetString(newValue, maxLength)
          End If
        End If
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
		End Sub

#End Region

#Region "Appointment Events"

		Private Sub AppointmentAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this appointment
				Dim dt As System.Data.DataTable = Me.AppointmentDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromAppointment(dt, CType(e.BaseObject, Appointment))
        Me.UpdateAppointmentFromDataRow(CType(e.BaseObject, Appointment), dt, dr)

				'Add a handler for this appointment to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf AppointmentRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub AppointmentRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this appointment is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf AppointmentRefresh

				'Update the Appointment_Provider table
				Dim apTable As System.Data.DataTable = Me.AppointmentProviderDataTable
				If Not (apTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = apTable.Select(GetFieldName(text_AppointmentProviderTableName, text_AppointmentGUID) & "='" & e.BaseObject.Key & "'")

					'Loop through the Dataset and remove all rows
					For Each loopRow As System.Data.DataRow In drArray
						loopRow.Delete()
					Next

				End If

				'Update the Appointment_Resource table
				Dim arTable As System.Data.DataTable = Me.AppointmentResourceDataTable
				If Not (arTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = arTable.Select(GetFieldName(text_AppointmentResourceTableName, text_AppointmentGUID) & "='" & e.BaseObject.Key & "'")

					'Loop through the Dataset and remove all rows
					For Each loopRow As System.Data.DataRow In drArray
						loopRow.Delete()
					Next

				End If

				'Update the Appointment_Category table
				Dim acTable As System.Data.DataTable = Me.AppointmentCategoryDataTable
				If Not (acTable Is Nothing) Then
					'Find the datarows
					Dim drArray As System.Data.DataRow() = acTable.Select(GetFieldName(text_AppointmentCategoryTableName, text_AppointmentGUID) & "='" & e.BaseObject.Key & "'")

					'Loop through the Dataset and remove all rows
					For Each loopRow As System.Data.DataRow In drArray
						loopRow.Delete()
					Next

				End If

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.AppointmentDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub AppointmentClear()

			Try
				Dim apTable As System.Data.DataTable = Me.AppointmentDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub AppointmentRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Try
				If IsTypeOf(e.BaseObject.GetType, GetType(Gravitybox.Objects.Appearance)) Then
					Me.AppearanceRefresh(Nothing, e)
					Return
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				If Not IsTypeOf(e.BaseObject.GetType, GetType(Gravitybox.Objects.Appointment)) Then Return

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.AppointmentDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromAppointment(dataTable, CType(e.BaseObject, Appointment))
				Else
					Me.UpdateDataRowFromAppointment(CType(e.BaseObject, Appointment), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Room Events"

		Private Sub RoomAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this Room
				Dim dt As System.Data.DataTable = Me.RoomDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromRoom(dt, CType(e.BaseObject, Room))
        Me.UpdateRoomFromDataRow(CType(e.BaseObject, Room), dt, dr)

				'Add a handler for this Room to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf RoomRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub RoomRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Room is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf RoomRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.RoomDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub RoomClear()

			Try
				Dim apTable As System.Data.DataTable = Me.RoomDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub RoomRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.RoomDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromRoom(dataTable, CType(e.BaseObject, Room))
				Else
					Me.UpdateDataRowFromRoom(CType(e.BaseObject, Room), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Provider Events"

		Private Sub ProviderAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this Provider
				Dim dt As System.Data.DataTable = Me.ProviderDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromProvider(dt, CType(e.BaseObject, Gravitybox.Objects.Provider))
        Me.UpdateProviderFromDataRow(CType(e.BaseObject, Provider), dt, dr)

				'Add a handler for this Provider to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf ProviderRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub ProviderRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Provider is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf ProviderRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.ProviderDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub ProviderClear()

			Try
				Dim apTable As System.Data.DataTable = Me.ProviderDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ProviderRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.ProviderDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromProvider(dataTable, CType(e.BaseObject, Gravitybox.Objects.Provider))
				Else
					Me.UpdateDataRowFromProvider(CType(e.BaseObject, Gravitybox.Objects.Provider), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Resource Events"

		Private Sub ResourceAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this Resource
				Dim dt As System.Data.DataTable = Me.ResourceDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromResource(dt, CType(e.BaseObject, Resource))
        Me.UpdateResourceFromDataRow(CType(e.BaseObject, Resource), dt, dr)

				'Add a handler for this Resource to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf ResourceRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub ResourceRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Resource is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf ResourceRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.ResourceDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub ResourceClear()

			Try
				Dim apTable As System.Data.DataTable = Me.ResourceDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ResourceRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.ResourceDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromResource(dataTable, CType(e.BaseObject, Resource))
				Else
					Me.UpdateDataRowFromResource(CType(e.BaseObject, Resource), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Category Events"

		Private Sub CategoryAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this Category
				Dim dt As System.Data.DataTable = Me.CategoryDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromCategory(dt, CType(e.BaseObject, Gravitybox.Objects.Category))
        Me.UpdateCategoryFromDataRow(CType(e.BaseObject, Category), dt, dr)

				'Add a handler for this Category to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf CategoryRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub CategoryRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Category is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf CategoryRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.CategoryDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub CategoryClear()

			Try
				Dim apTable As System.Data.DataTable = Me.CategoryDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub CategoryRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.CategoryDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromCategory(dataTable, CType(e.BaseObject, Gravitybox.Objects.Category))
				Else
					Me.UpdateDataRowFromCategory(CType(e.BaseObject, Gravitybox.Objects.Category), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Appearance Events"

		Private Sub AppearanceAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				'Only persist AppointmentAppearance objects
				If Not (e.BaseObject.GetType Is GetType(AppointmentAppearance)) Then
					Return
				End If

				'Create a new DataRow for this Appearance
				Dim dt As System.Data.DataTable = Me.AppearanceDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromAppearance(dt, CType(e.BaseObject, Gravitybox.Objects.AppointmentAppearance))
        Me.UpdateAppearanceFromDataRow(CType(e.BaseObject, Gravitybox.Objects.AppointmentAppearance), dt, dr)

				'Add a handler for this Appearance to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf AppearanceRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub AppearanceRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Appearance is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf AppearanceRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.AppearanceDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub AppearanceClear()

			Try
				Dim apTable As System.Data.DataTable = Me.AppearanceDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub AppearanceRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.AppearanceDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromAppearance(dataTable, CType(e.BaseObject, Gravitybox.Objects.Appearance))
				Else
					Me.UpdateDataRowFromAppearance(CType(e.BaseObject, Gravitybox.Objects.Appearance), dataTable, dataRow)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Recurrence Events"

		Private Sub RecurrenceAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Create a new DataRow for this Recurrence
				Dim dt As System.Data.DataTable = Me.RecurrenceDataTable
        Dim dr As System.Data.DataRow = Me.CreateDataRowFromRecurrence(dt, CType(e.BaseObject, Recurrence))
        Me.UpdateRecurrenceFromDataRow(CType(e.BaseObject, Recurrence), dt, dr)

				'Add a handler for this Recurrence to catch when it changes
				AddHandler e.BaseObject.Refresh, AddressOf RecurrenceRefresh

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub RecurrenceRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Remove a handler since this Recurrence is removed
				RemoveHandler e.BaseObject.Refresh, AddressOf RecurrenceRefresh

				'Remove the datarow
				Dim dr As System.Data.DataRow = GetDataRow(Me.RecurrenceDataTable, e.BaseObject.Key)
				If Not (dr Is Nothing) Then
					Call dr.Delete()
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub RecurrenceClear()

			Try
				Dim apTable As System.Data.DataTable = Me.RecurrenceDataTable
				If Not (apTable Is Nothing) Then
					'Loop through the Dataset and remove all rows
					For ii As Integer = apTable.Rows.Count - 1 To 0 Step -1
						apTable.Rows.RemoveAt(ii)
					Next
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub RecurrenceRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try

				'Get the table
				Dim dataTable As System.Data.DataTable = Me.RecurrenceDataTable
				If dataTable Is Nothing Then Return

				'Get the datarow
				Dim dataRow As System.Data.DataRow = GetDataRow(dataTable, e.BaseObject.Key)

				'Add/Update
				If dataRow Is Nothing Then
					CreateDataRowFromRecurrence(dataTable, CType(e.BaseObject, Recurrence))
				Else
					Me.UpdateDataRowFromRecurrence(CType(e.BaseObject, Recurrence), dataTable, dataRow, False)
					MainObject.FireEventDataSourceUpdated()
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

#End Region

#Region "Dataset Changed Event/Methods"

		Private Sub DatasetRowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			'Do NOT process detached datarows
			If e.Row.RowState = DataRowState.Detached Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Select Case e.Row.Table.TableName.ToLower
					Case AppointmentTableName.ToLower
						DatasetRowChangedAppointment(Me.AppointmentDataTable, e.Row)
					Case RoomTableName.ToLower
						DatasetRowChangedRoom(Me.RoomDataTable, e.Row)
					Case ProviderTableName.ToLower
						DatasetRowChangedProvider(Me.ProviderDataTable, e.Row)
					Case ResourceTableName.ToLower
						DatasetRowChangedResource(Me.ResourceDataTable, e.Row)
					Case CategoryTableName.ToLower
						DatasetRowChangedCategory(Me.CategoryDataTable, e.Row)
					Case AppearanceTableName.ToLower
						DatasetRowChangedAppearance(Me.AppearanceDataTable, e.Row)
					Case RecurrenceTableName.ToLower
						DatasetRowChangedRecurrence(Me.RecurrenceDataTable, e.Row)
				End Select

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub DatasetRowChangedAppointment(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this appointment
				Dim appointment As Gravitybox.Objects.Appointment
				Dim key As String = GetStringValue(row, text_AppointmentTableName, text_AppointmentGUID)
				If MainObject.AppointmentCollection.Contains(key) Then
					appointment = MainObject.AppointmentCollection(key)
				Else
					appointment = Me.CreateAppointmentFromDataRow(dataTable, row)

					'Add a handler for this appointment to catch when it changes
					AddHandler appointment.Refresh, AddressOf AppointmentRefresh
				End If
				Me.UpdateAppointmentFromDataRow(appointment, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedRoom(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this room
				Dim room As Gravitybox.Objects.Room
				Dim key As String = GetStringValue(row, text_RoomTableName, text_RoomGUID)
				If MainObject.RoomCollection.Contains(key) Then
					room = MainObject.RoomCollection(key)
				Else
					room = Me.CreateRoomFromDataRow(dataTable, row)

					'Add a handler for this room to catch when it changes
					AddHandler room.Refresh, AddressOf RoomRefresh
				End If
				Me.UpdateRoomFromDataRow(room, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedProvider(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this provider
				Dim provider As Gravitybox.Objects.Provider
				Dim key As String = GetStringValue(row, text_ProviderTableName, text_ProviderGUID)
				If MainObject.ProviderCollection.Contains(key) Then
					provider = MainObject.ProviderCollection(key)
				Else
					provider = Me.CreateProviderFromDataRow(dataTable, row)

					'Add a handler for this provider to catch when it changes
					AddHandler provider.Refresh, AddressOf ProviderRefresh
				End If
				Me.UpdateProviderFromDataRow(provider, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedResource(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this Resource
				Dim resource As Gravitybox.Objects.Resource
				Dim key As String = GetStringValue(row, text_ResourceTableName, text_ResourceGUID)
				If MainObject.ResourceCollection.Contains(key) Then
					resource = MainObject.ResourceCollection(key)
				Else
					resource = Me.CreateResourceFromDataRow(dataTable, row)

					'Add a handler for this Resource to catch when it changes
					AddHandler resource.Refresh, AddressOf ResourceRefresh
				End If
				Me.UpdateResourceFromDataRow(resource, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedCategory(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this category
				Dim category As Gravitybox.Objects.Category
				Dim key As String = GetStringValue(row, text_CategoryTableName, text_CategoryGUID)
				If MainObject.CategoryCollection.Contains(key) Then
					category = MainObject.CategoryCollection(key)
				Else
					category = Me.CreateCategoryFromDataRow(dataTable, row)

					'Add a handler for this category to catch when it changes
					AddHandler category.Refresh, AddressOf CategoryRefresh
				End If
				Me.UpdateCategoryFromDataRow(category, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedAppearance(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this Appearance
				Dim appearance As Gravitybox.Objects.AppointmentAppearance
				Dim key As String = GetStringValue(row, text_AppearanceTableName, text_AppearanceGUID)
				If MainObject.AppearanceCollection.Contains(key) Then
					appearance = CType(MainObject.AppearanceCollection(key), AppointmentAppearance)
				Else
					appearance = Me.CreateAppearanceFromDataRow(dataTable, row)

					'Add a handler for this Appearance to catch when it changes
					AddHandler appearance.Refresh, AddressOf AppearanceRefresh
				End If
				Me.UpdateAppearanceFromDataRow(appearance, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DatasetRowChangedRecurrence(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			Try
				'Create a new DataRow for this recurrence
				Dim recurrence As Gravitybox.Objects.Recurrence
				Dim key As String = GetStringValue(row, text_RecurrenceTableName, text_RecurrenceGUID)
				If MainObject.RecurrenceCollection.Contains(key) Then
					recurrence = MainObject.RecurrenceCollection(key)
				Else
					recurrence = Me.CreateRecurrenceFromDataRow(dataTable, row)

					'Add a handler for this recurrence to catch when it changes
					AddHandler recurrence.Refresh, AddressOf RecurrenceRefresh
				End If
				Me.UpdateRecurrenceFromDataRow(recurrence, dataTable, row)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Dataset Deleted Event/Methods"

		Private Sub DatasetRowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

			'If loading then do not process the update
			If IsLoading Then Return

			Dim oldLoad As Boolean = IsLoading
			IsLoading = True

			Try
				Select Case e.Row.Table.TableName.ToLower
					Case AppointmentTableName.ToLower
						DatasetRowDeletedAppointment(Me.AppointmentDataTable, e.Row)
					Case RoomTableName.ToLower
						DatasetRowDeletedRoom(Me.RoomDataTable, e.Row)
					Case ProviderTableName.ToLower
						DatasetRowDeletedProvider(Me.ProviderDataTable, e.Row)
					Case ResourceTableName.ToLower
						DatasetRowDeletedResource(Me.ResourceDataTable, e.Row)
					Case CategoryTableName.ToLower
						DatasetRowDeletedCategory(Me.CategoryDataTable, e.Row)
					Case AppearanceTableName.ToLower
						DatasetRowDeletedAppearance(Me.AppearanceDataTable, e.Row)
					Case RecurrenceTableName.ToLower
						DatasetRowDeletedRecurrence(Me.RecurrenceDataTable, e.Row)
				End Select

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				IsLoading = oldLoad
			End Try

		End Sub

		Private Sub DatasetRowDeletedAppointment(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the appointment for this row and remove the appointment
			Dim key As String = GetStringValue(row, text_AppointmentTableName, text_AppointmentGUID)
			If Not MainObject.AppointmentCollection.Contains(key) Then
				Return
			End If

			'Remove the appointment
			Dim appointment As Gravitybox.Objects.Appointment = MainObject.AppointmentCollection(key)
			If Not MainObject.AppointmentCollection.Remove(appointment) Then
				'If the appointment was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this appointment to catch when it changes
			RemoveHandler appointment.Refresh, AddressOf AppointmentRefresh

		End Sub

		Private Sub DatasetRowDeletedRoom(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the room for this row and remove the room
			Dim key As String = GetStringValue(row, text_RoomTableName, text_RoomGUID)
			If Not MainObject.RoomCollection.Contains(key) Then
				Return
			End If

			'Remove the room
			Dim room As Gravitybox.Objects.Room = MainObject.RoomCollection(key)
			If Not MainObject.RoomCollection.Remove(room) Then
				'If the room was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this room to catch when it changes
			RemoveHandler room.Refresh, AddressOf RoomRefresh

		End Sub

		Private Sub DatasetRowDeletedProvider(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the provider for this row and remove the provider
			Dim key As String = GetStringValue(row, text_ProviderTableName, text_ProviderGUID)
			If Not MainObject.ProviderCollection.Contains(key) Then
				Return
			End If

			'Remove the provider
			Dim provider As Gravitybox.Objects.Provider = MainObject.ProviderCollection(key)
			If Not MainObject.ProviderCollection.Remove(provider) Then
				'If the provider was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this provider to catch when it changes
			RemoveHandler provider.Refresh, AddressOf ProviderRefresh

		End Sub

		Private Sub DatasetRowDeletedResource(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the resource for this row and remove the resource
			Dim key As String = GetStringValue(row, text_ResourceTableName, text_ResourceGUID)
			If Not MainObject.ResourceCollection.Contains(key) Then
				Return
			End If

			'Remove the resource
			Dim resource As Gravitybox.Objects.Resource = MainObject.ResourceCollection(key)
			If Not MainObject.ResourceCollection.Remove(resource) Then
				'If the Resource was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this Resource to catch when it changes
			RemoveHandler resource.Refresh, AddressOf ResourceRefresh

		End Sub

		Private Sub DatasetRowDeletedCategory(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the category for this row and remove the category
			Dim key As String = GetStringValue(row, text_CategoryTableName, text_CategoryGUID)
			If Not MainObject.CategoryCollection.Contains(key) Then
				Return
			End If

			'Remove the category
			Dim category As Gravitybox.Objects.Category = MainObject.CategoryCollection(key)
			If Not MainObject.CategoryCollection.Remove(category) Then
				'If the category was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this category to catch when it changes
			RemoveHandler category.Refresh, AddressOf CategoryRefresh

		End Sub

		Private Sub DatasetRowDeletedAppearance(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the appearance for this row and remove the appearance
			Dim key As String = GetStringValue(row, text_AppearanceTableName, text_AppearanceGUID)
			If Not MainObject.AppearanceCollection.Contains(key) Then
				Return
			End If

			'Remove the appearance
			Dim appearance As Gravitybox.Objects.Appearance = MainObject.AppearanceCollection(key)
			If Not MainObject.AppearanceCollection.Remove(appearance) Then
				'If the appearance was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this appearance to catch when it changes
			RemoveHandler appearance.Refresh, AddressOf AppearanceRefresh

		End Sub

		Private Sub DatasetRowDeletedRecurrence(ByVal dataTable As System.Data.DataTable, ByVal row As System.Data.DataRow)

			'Find the recurrence for this row and remove the recurrence
			Dim key As String = GetStringValue(row, text_RecurrenceTableName, text_RecurrenceGUID)
			If Not MainObject.RecurrenceCollection.Contains(key) Then
				Return
			End If

			'Remove the recurrence
			Dim recurrence As Gravitybox.Objects.Recurrence = MainObject.RecurrenceCollection(key)
			If Not MainObject.RecurrenceCollection.Remove(recurrence) Then
				'If the recurrence was NOT removed then readd the datarow
				dataTable.Rows.Add(row)
				Return
			End If

			'Add a handler for this recurrence to catch when it changes
			RemoveHandler recurrence.Refresh, AddressOf RecurrenceRefresh

		End Sub

#End Region

#Region "SetPropertyItemDataRow"

		Private Sub SetPropertyItemDataRow(ByVal dataRow As System.Data.DataRow, ByVal propertyItem As Gravitybox.Objects.PropertyItem)

			'Error Check
			If dataRow Is Nothing Then Return
			If propertyItem Is Nothing Then Return

			'If the column exists...
			If dataRow.Table.Columns.Contains(propertyItem.Key) Then

				'Get the value setting
				Try
					If propertyItem.Setting Is Nothing Then
            'This is a DbNull
            Me.UpdateValueNull(dataRow, Me.GetMaskTableName(dataRow.Table.TableName), propertyItem.Key)
						Return
					End If
				Catch ex As Exception
					ErrorModule.SetErr(ex)
				End Try

        Dim setting As String = propertyItem.Setting

				'If this is a number and we are trying to set it to empty string then set to DbNull if possible
				If IsNumericDataType(dataRow.Table.Columns(propertyItem.Key).DataType) Then
					If (setting.GetType() Is GetType(String)) AndAlso (CType(setting, String) = "") Then
						'This is a DbNull
						If dataRow.Table.Columns(propertyItem.Key).AllowDBNull Then
              Me.UpdateValueNull(dataRow, Me.GetMaskTableName(dataRow.Table.TableName), propertyItem.Key)
						Else
							Throw New Gravitybox.Exceptions.GravityboxException("The numeric data field '" & propertyItem.Setting & "' is not being set to a valid number and it does not support DbNull!")
						End If
					ElseIf (setting.GetType() Is GetType(String)) AndAlso IsNumeric(setting) Then
						'This is a valid number
						Try
              Me.UpdateValue(dataRow, Me.GetMaskTableName(dataRow.Table.TableName), propertyItem.Key, ScheduleGlobals.GetIntlInteger(setting))
						Catch ex As Exception
							ErrorModule.SetErr("Setting: " & propertyItem.Setting & ControlChars.CrLf & ex.ToString)
						End Try

					End If
				Else
					'This is a string
					Try
            Me.UpdateValue(dataRow, Me.GetMaskTableName(dataRow.Table.TableName), propertyItem.Key, setting)
					Catch ex As Exception
						ErrorModule.SetErr("Setting: " & propertyItem.Setting & ControlChars.CrLf & ex.ToString)
					End Try
				End If

			End If

		End Sub

#End Region

#Region "IsNumericDataType"

		Private Function IsNumericDataType(ByVal type As System.Type) As Boolean

			Try
				If type Is GetType(Integer) Then
					Return True
				ElseIf type Is GetType(Long) Then
					Return True
				ElseIf type Is GetType(Decimal) Then
					Return True
				ElseIf type Is GetType(Double) Then
					Return True
				ElseIf type Is GetType(Single) Then
					Return True
				End If
			Catch ex As Exception
				'Do Nothing
			End Try
			Return False

		End Function

#End Region

#Region "Get Table Names"

		Public ReadOnly Property AppointmentTableName() As String
			Get
				If MainObject.DataBindings.AppointmentBinding.DataSource Is Nothing Then
					Return text_AppointmentTableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

    Public ReadOnly Property CategoryTableName() As String
      Get
        If MainObject.DataBindings.CategoryBinding.DataSource Is Nothing Then
          Return text_CategoryTableName
        ElseIf IsTypeOf(MainObject.DataBindings.CategoryBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.CategoryBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.CategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.CategoryBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

		Public ReadOnly Property ProviderTableName() As String
			Get
				If MainObject.DataBindings.ProviderBinding.DataSource Is Nothing Then
					Return text_ProviderTableName
        ElseIf IsTypeOf(MainObject.DataBindings.ProviderBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.ProviderBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.ProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.ProviderBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

    Public ReadOnly Property ResourceTableName() As String
      Get
        If MainObject.DataBindings.ResourceBinding.DataSource Is Nothing Then
          Return text_ResourceTableName
        ElseIf IsTypeOf(MainObject.DataBindings.ResourceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.ResourceBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.ResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.ResourceBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

		Public ReadOnly Property RoomTableName() As String
			Get
				If MainObject.DataBindings.RoomBinding.DataSource Is Nothing Then
					Return text_RoomTableName
        ElseIf IsTypeOf(MainObject.DataBindings.RoomBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.RoomBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.RoomBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.RoomBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing

      End Get
    End Property

    Public ReadOnly Property AppearanceTableName() As String
      Get
        If MainObject.DataBindings.AppearanceBinding.DataSource Is Nothing Then
          Return text_AppearanceTableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppearanceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppearanceBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppearanceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppearanceBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

		Public ReadOnly Property AppointmentCategoryTableName() As String
			Get
				If MainObject.DataBindings.AppointmentCategoryBinding.DataSource Is Nothing Then
					Return text_AppointmentCategoryTableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentCategoryBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentCategoryBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentCategoryBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentCategoryBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

    Public ReadOnly Property AppointmentProviderTableName() As String
      Get
        If MainObject.DataBindings.AppointmentProviderBinding.DataSource Is Nothing Then
          Return text_AppointmentProviderTableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentProviderBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentProviderBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentProviderBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentProviderBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

		Public ReadOnly Property AppointmentResourceTableName() As String
			Get
				If MainObject.DataBindings.AppointmentResourceBinding.DataSource Is Nothing Then
					Return text_AppointmentResourceTableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentResourceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.AppointmentResourceBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.AppointmentResourceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.AppointmentResourceBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

    Public ReadOnly Property RecurrenceTableName() As String
      Get
        If MainObject.DataBindings.RecurrenceBinding.DataSource Is Nothing Then
          Return text_RecurrenceTableName
        ElseIf IsTypeOf(MainObject.DataBindings.RecurrenceBinding.DataSource.GetType(), GetType(System.Data.DataTable)) Then
          Return CType(MainObject.DataBindings.RecurrenceBinding.DataSource, DataTable).TableName
        ElseIf IsTypeOf(MainObject.DataBindings.RecurrenceBinding.DataSource.GetType(), GetType(System.Data.DataView)) Then
          Return CType(MainObject.DataBindings.RecurrenceBinding.DataSource, DataView).Table.TableName
        End If
        Return Nothing
      End Get
    End Property

		Public Function GetFieldName(ByVal tableID As String, ByVal fieldID As String) As String

      If (String.Compare(tableID, text_AppointmentTableName, True) = 0) Then
        If MainObject.DataBindings.AppointmentBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.AppointmentBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_RoomTableName, True) = 0) Then
        If MainObject.DataBindings.RoomBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.RoomBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_CategoryTableName, True) = 0) Then
        If MainObject.DataBindings.CategoryBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.CategoryBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_ProviderTableName, True) = 0) Then
        If MainObject.DataBindings.ProviderBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.ProviderBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_ResourceTableName, True) = 0) Then
        If MainObject.DataBindings.ResourceBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.ResourceBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_AppointmentCategoryTableName, True) = 0) Then
        If MainObject.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_AppointmentProviderTableName, True) = 0) Then
        If MainObject.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_AppointmentResourceTableName, True) = 0) Then
        If MainObject.DataBindings.AppointmentResourceBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.AppointmentResourceBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      ElseIf (String.Compare(tableID, text_AppearanceTableName, True) = 0) Then
        Return fieldID

      ElseIf (String.Compare(tableID, text_RecurrenceTableName, True) = 0) Then
        If MainObject.DataBindings.RecurrenceBinding.DataFieldBindingCollection.Contains(fieldID) Then
          Return MainObject.DataBindings.RecurrenceBinding.DataFieldBindingCollection(fieldID).DataMember
        Else
          Return fieldID
        End If

      Else
        Throw New Exceptions.GravityboxException("The table name was not defined: " & tableID & "!")

      End If
			Return fieldID

		End Function

		Private Function GetRealFieldName(ByVal tableID As String, ByVal dataMemberID As String) As String

			If (tableID = text_AppointmentTableName) Then
				If MainObject.DataBindings.AppointmentBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.AppointmentBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_RoomTableName) Then
				If MainObject.DataBindings.RoomBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.RoomBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_CategoryTableName) Then
				If MainObject.DataBindings.CategoryBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.CategoryBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_ProviderTableName) Then
				If MainObject.DataBindings.ProviderBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.ProviderBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_ResourceTableName) Then
				If MainObject.DataBindings.ResourceBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.ResourceBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_AppointmentCategoryTableName) Then
				If MainObject.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_AppointmentProviderTableName) Then
				If MainObject.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_AppointmentResourceTableName) Then
				If MainObject.DataBindings.AppointmentResourceBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.AppointmentResourceBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			ElseIf (tableID = text_AppearanceTableName) Then
				Return dataMemberID

			ElseIf (tableID = text_RecurrenceTableName) Then
				If MainObject.DataBindings.RecurrenceBinding.DataFieldBindingCollection.ContainsDataMember(dataMemberID) Then
					Return MainObject.DataBindings.RecurrenceBinding.DataFieldBindingCollection.GetPropertyName(dataMemberID)
				Else
					Return dataMemberID
				End If

			Else
				Throw New Exceptions.GravityboxException("The table name was not defined: " & tableID & "!")

			End If
			Return dataMemberID

    End Function

    Private Function GetMaskTableName(ByVal tableID As String) As String

      If (String.Compare(tableID, AppointmentTableName, True) = 0) Then
        Return text_AppointmentTableName
      ElseIf (String.Compare(tableID, RoomTableName, True) = 0) Then
        Return text_RoomTableName
      ElseIf (String.Compare(tableID, CategoryTableName, True) = 0) Then
        Return text_CategoryTableName
      ElseIf (String.Compare(tableID, ProviderTableName, True) = 0) Then
        Return text_ProviderTableName
      ElseIf (String.Compare(tableID, ResourceTableName, True) = 0) Then
        Return text_ResourceTableName
      ElseIf (String.Compare(tableID, AppointmentCategoryTableName, True) = 0) Then
        Return text_AppointmentCategoryTableName
      ElseIf (String.Compare(tableID, AppointmentProviderTableName, True) = 0) Then
        Return text_AppointmentProviderTableName
      ElseIf (String.Compare(tableID, AppointmentResourceTableName, True) = 0) Then
        Return text_AppointmentResourceTableName
      ElseIf (String.Compare(tableID, AppearanceTableName, True) = 0) Then
        Return text_AppearanceTableName
      ElseIf (String.Compare(tableID, RecurrenceTableName, True) = 0) Then
        Return text_RecurrenceTableName
      Else
        Throw New Exceptions.GravityboxException("The table name was not defined: " & tableID & "!")
      End If

    End Function

#End Region

	End Class

End Namespace