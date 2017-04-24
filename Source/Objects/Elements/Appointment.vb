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

Imports System.ComponentModel
Imports System.Windows.Forms.Design
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Lifetime
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  Public Enum AppointmentAccessConstants As Integer
    AccessPublic = 0
    AccessPrivate = 1
    AccessConfidential = 2
  End Enum

  <Serializable(), _
  DefaultEvent("Refresh"), _
  DefaultProperty("Text")> _
  Public Class Appointment
    Inherits BaseObject
		Implements System.Runtime.Serialization.IDeserializationCallback
		Implements IDisposable

#Region "Class Members"

    'Private Constants
    Friend Const MyXMLNodeName As String = "appointment"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Class Constants
    Private Const IconSize As Integer = 16
    Private Const RoundRadius As Integer = 12

    'Private Member Constants
    Protected Const m_def_MaxLength As Integer = -1
    Protected Const m_def_MinLength As Integer = -1
    Protected Const m_def_Access As AppointmentAccessConstants = AppointmentAccessConstants.AccessPublic
    Protected Const m_def_StartDate As DateTime = DefaultNoDate
    Protected Const m_def_StartTime As DateTime = DefaultNoTime
    Protected Const m_def_IsEvent As Boolean = False
    Protected Const m_def_Visible As Boolean = True
    Protected Const m_def_Blockout As Boolean = False
    Protected Const m_def_IsReadOnly As Boolean = False
    Protected Const m_def_IsFlagged As Boolean = False
    Protected Const m_def_IsActivity As Boolean = False

    'Protected Member Variables
    Protected m_StartDate As DateTime = m_def_StartDate
    Protected m_StartTime As DateTime = m_def_StartTime
    Protected m_Room As Room = Nothing
    Protected m_AppointmentType As AppointmentType
    Protected m_Recurrence As Recurrence = Nothing
    Protected m_Length As Integer = 0
    Protected m_Notes As String = ""
    Protected m_Priority As Priority = Nothing
    Protected m_Blockout As Boolean = m_def_Blockout
    Protected m_ToolTipText As String = ""
    Protected m_IsReadOnly As Boolean = m_def_IsReadOnly
    Protected m_Visible As Boolean = True
    Protected m_MaxLength As Integer = m_def_MaxLength
    Protected m_MinLength As Integer = m_def_MinLength
    Protected m_Subject As String = ""
    Protected m_IsFlagged As Boolean = m_def_IsFlagged
    Protected m_TabIndex As Integer = 0
    Protected m_Access As AppointmentAccessConstants = m_def_Access
    Protected m_CategoryList As CategoryList
    Protected m_ProviderList As ProviderList
    Protected m_ResourceList As ResourceList
    Protected m_FileCollection As New FileCollection
    Protected m_IconCollection As New IconCollection
    Protected m_Alarm As New AlarmItem(Me)
    Protected m_IsActivity As Boolean = m_def_IsActivity
    Protected m_IsEvent As Boolean = m_def_IsEvent
    Protected m_EventIndex As Integer = 0
    Protected m_RecurrenceStamp As String = ""
    Protected m_Header As AppointmentHeader = New AppointmentHeader
    <NonSerialized()> Protected m_TimeStamp As Long
    Protected m_Appearance As New Gravitybox.Objects.AppointmentAppearance

    'Internal Objects
    <NonSerialized()> Private m_MainObject As Object

    'Storage for appointment coordinates
    <NonSerialized()> Private m_Rectangles As New AppointmentRectangleInfoCollection(Me)

#End Region

#Region "Constructor"

		'Override constructor so that this object not publically creatable
    Protected Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
      Me.New(Guid.NewGuid.ToString, mainObject)
    End Sub

    Protected Friend Sub New(ByVal key As String, ByVal mainObject As Gravitybox.Controls.Schedule)

      MyBase.New(key, "")

      If mainObject Is Nothing Then
        Throw New Exception("The schedule object must be specified!")
      End If
      Try
        m_MainObject = mainObject
        m_MaxLength = m_def_MaxLength
        m_MinLength = m_def_MinLength
        m_Access = m_def_Access
        m_Visible = m_def_Visible
        m_CategoryList = New CategoryList(mainObject, Me)
        m_ProviderList = New ProviderList(mainObject, Me)
        m_ResourceList = New ResourceList(mainObject, Me)

        Call HookEvents()
        Call SetupDefaultAppearance()
        Call Me.ResetTimeStamp(False)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

		Private Sub OnDeserialization(ByVal sender As Object) Implements System.Runtime.Serialization.IDeserializationCallback.OnDeserialization

			Try
				Call HookEvents()
				m_Rectangles = New AppointmentRectangleInfoCollection(Me)
				Call ResetTimeStamp(True)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Hook/Unhook Events"

		Friend Sub HookEvents()

			Try
				'Readd the non-public delegates 
				Me.Header.HookEvents()
				AddHandler m_CategoryList.Refresh, AddressOf SubObjectRefresh
				AddHandler m_ProviderList.Refresh, AddressOf SubObjectRefresh
				AddHandler m_ResourceList.Refresh, AddressOf SubObjectRefresh
				AddHandler m_FileCollection.Refresh, AddressOf SubObjectRefreshFileCollection
				AddHandler m_IconCollection.Refresh, AddressOf SubObjectRefreshIconCollection
				AddHandler m_Alarm.Refresh, AddressOf SubObjectRefresh
				'AddHandler m_Header.Refresh, AddressOf OnRefresh
				AddHandler m_Appearance.Refresh, AddressOf OnRefresh

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend Sub UnHookEvents()

			Try
				'Readd the non-public delegates 
				Me.Header.UnHookEvents()
				RemoveHandler m_CategoryList.Refresh, AddressOf SubObjectRefresh
				RemoveHandler m_ProviderList.Refresh, AddressOf SubObjectRefresh
				RemoveHandler m_ResourceList.Refresh, AddressOf SubObjectRefresh
				RemoveHandler m_FileCollection.Refresh, AddressOf SubObjectRefreshFileCollection
				RemoveHandler m_IconCollection.Refresh, AddressOf SubObjectRefreshIconCollection
				RemoveHandler m_Alarm.Refresh, AddressOf SubObjectRefresh
				'RemoveHandler m_Header.Refresh, AddressOf OnRefresh
				RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "SetupDefaultAppearance"

		Private Sub SetupDefaultAppearance()

			Try
				'Create and default the appearance
				m_Appearance.FromXML((New Gravitybox.Objects.AppointmentAppearance).ToXML())
				Me.Appearance.BackColor = Color.White
				Me.Appearance.ForeColor = Color.Black
				Me.Appearance.HatchStyle = Drawing2D.HatchStyle.Min
				Me.Appearance.HatchColor = Color.LightGray
				Me.Appearance.Transparency = 0
				Me.Appearance.IsRound = False
				Me.Appearance.BorderColor = Color.Black
				Me.Appearance.StringFormatFlags = StringFormatFlags.FitBlackBox
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "MainObject"

    Protected Friend Property MainObject() As Gravitybox.Controls.Schedule
      Get
        Return CType(m_MainObject, Gravitybox.Controls.Schedule)
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule)
        Try
          m_MainObject = Value
          Me.CategoryList.MainObject = Value
          Me.ProviderList.MainObject = Value
          Me.ResourceList.MainObject = Value
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Set
    End Property

#End Region

#Region "ResetSubObjects"

		Friend Sub ResetSubObjects()

			'This method will reset all data collections/objects
			'so that the object will be as new
			Try
				m_CategoryList = New CategoryList(MainObject)
				m_ProviderList = New ProviderList(MainObject)
				m_ResourceList = New ResourceList(MainObject)
				m_FileCollection = New FileCollection
				m_IconCollection = New IconCollection
				m_Alarm = New AlarmItem(Me)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.Appointment(MainObject)
				element.FromXML(Me.ToXML)
				element.SetKey(Guid.NewGuid.ToString)
				Return element
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing
    End Function

#End Region

#Region "Contains"

		Public Function Contains(ByVal startDate As DateTime, ByVal endDate As DateTime) As Boolean

			If (startDate = Me.StartDate) And (endDate = Me.EndDate) Then
				Return True
			ElseIf (startDate <= Me.EndDate) And (endDate >= Me.StartDate) Then
				Return True
			Else
				Return False
			End If

		End Function

#End Region

#Region "Property Implementations"

		<Browsable(False)> _
		Friend ReadOnly Property Rectangles() As AppointmentRectangleInfoCollection
			Get
				Return m_Rectangles
			End Get
		End Property

    ''' <summary>
    ''' Determines the starting date and time of this appointment.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    Description("Determines the starting date and time of this appointment.")> _
    Public Property StartDateTime() As DateTime
      Get
        If Me.StartTime = DefaultNoTime Then
          Return Date.Parse(Me.StartDate.ToShortDateString & " " & PivotTime.ToShortTimeString)
        Else
          Return Date.Parse(Me.StartDate.ToShortDateString & " " & Me.StartTime.ToShortTimeString)
        End If
      End Get
      Set(ByVal Value As DateTime)
        m_StartDate = GetDate(Value)
        m_StartTime = GetTime(Value)
        Call GoRefresh()
        Call Me.ResetTimeStamp(True)
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
      End Set
    End Property

    ''' <summary>
    ''' Determines the ending date and time of the appointment by taking the starting date and time and adding the length to it.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property EndDateTime() As DateTime
      Get
        Return StartDateTime.Add(New TimeSpan(0, Me.Length, 0))
      End Get
    End Property

    ''' <summary>
    ''' Determines the starting date of this appointment.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("start_date"), _
    Category("Data"), _
    Description("Determines the starting date of this appointment.")> _
    Public Property StartDate() As DateTime
      Get
        Return m_StartDate
      End Get
      Set(ByVal Value As DateTime)
        Dim newValue As Date = GetDate(Value)
        If m_StartDate <> newValue Then
          m_StartDate = newValue
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the ending date of this appointment. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the ending date of this appointment. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.")> _
    Public ReadOnly Property EndDate() As DateTime
      Get
        Dim retval As DateTime
        Dim length As Integer
        Try
          length = Me.Length
          If (Me.StartDate = DefaultNoDate) And (Me.StartTime = DefaultNoTime) Then
            retval = GetDate(Now)
          ElseIf (Me.StartDate = DefaultNoDate) Then
            retval = Date.Parse(GetDate(Now).ToShortDateString & " " & Me.StartTime.ToShortTimeString)
            retval = GetDate(DateAdd(DateInterval.Minute, length, retval))
          ElseIf (Me.StartTime = DefaultNoTime) Then
            retval = Date.Parse(Me.StartDate.ToShortDateString & " " & PivotTime.ToShortTimeString)
            retval = GetDate(DateAdd(DateInterval.Minute, length, retval))
          Else
            retval = Date.Parse(Me.StartDate.ToShortDateString & " " & Me.StartTime.ToShortTimeString)
            retval = GetDate(DateAdd(DateInterval.Minute, length, retval))
          End If
          Return retval
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Get
    End Property

    ''' <summary>
    ''' Determines the number of day boundaries that this appointment crosses. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the number of day boundaries that this appointment crosses. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.")> _
    Public ReadOnly Property DaySpan() As Integer
      Get
        Try
          If Me.StartDate = DefaultNoDate Then
            Return 0
          Else
            Return GetIntlInteger(DateDiff(DateInterval.Day, Me.StartDate, Me.EndDate)) + 1
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Get
    End Property

    ''' <summary>
    ''' Determines the starting time of this appointment.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("start_time"), _
    Category("Data"), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("Determines the starting time of this appointment.")> _
    Public Property StartTime() As DateTime
      Get
        If IsEvent Then
          Return PivotTime
        Else
          Return m_StartTime
        End If
      End Get
      Set(ByVal Value As DateTime)
        Dim newValue As Date = GetTime(Value)
        If m_StartTime <> newValue Then
          m_StartTime = newValue
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the ending time of this appointment. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.
    ''' </summary>
    <Browsable(False), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("Determines the ending time of this appointment. This value is calculated based on the StartDate, StartTime, and Length properties of this appointment.")> _
    Public ReadOnly Property EndTime() As DateTime
      Get
        Try
          Dim retval As DateTime
          Dim myLength As Integer
          myLength = Me.Length Mod MinutesPerDay
          retval = DateAdd(DateInterval.Minute, myLength, Me.StartTime)
          retval = GetTime(retval)
          Return retval
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Get
    End Property

    ''' <summary>
    ''' Determines the Room object that has been associated with this appointment. This value may be Nothing if there is no associated Room object.
    ''' </summary>
    <Browsable(False), _
    Gravitybox.Design.Attributes.Persistable("room_guid"), _
    Category("Data"), _
    Description("Determines the Room object that has been associated with this appointment. This value may be Nothing if there is no associated Room object.")> _
    Public Property Room() As Room
      Get
        Return m_Room
      End Get
      Set(ByVal Value As Room)
        If Not (m_Room Is Value) Then
          m_Room = Value
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the AppointmentType object that has been associated with this appointment. This value may be Nothing if there is no associated AppointmentType object.
    ''' </summary>
    <Browsable(False), _
    Gravitybox.Design.Attributes.Persistable("appointment_type_guid"), _
    Category("Data"), _
    Description("Determines the AppointmentType object that has been associated with this appointment. This value may be Nothing if there is no associated AppointmentType object.")> _
    Public Property AppointmentType() As AppointmentType
      Get
        Return m_AppointmentType
      End Get
      Set(ByVal Value As AppointmentType)
        If Not (m_AppointmentType Is Value) Then
          m_AppointmentType = Value
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the length of the appointment in minutes.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("length"), _
    Category("Data"), _
    Description("Determines the length of the appointment in minutes.")> _
    Public Property Length() As Integer
      Get
        If IsEvent Then
          Return MinutesPerDay - 1
        Else
          Return m_Length
        End If
      End Get
      Set(ByVal Value As Integer)

        'Do nothing if nothing to do
        If m_Length = Value Then Return

        'Error correct for 0 or less. 0 minutes or less is an Error!
        If Value <= 0 Then
          If MainObject Is Nothing Then
            Value = 1
          Else
            Value = MainObject.TimeIncrement
          End If
        End If

        If m_Length <> Value Then
          m_Length = Value
          Call CheckMinMaxLength()
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If

      End Set
    End Property

    ''' <summary>
    ''' Determines an extra string property for this object. This property is displayed in the property dialog.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("notes"), _
    Category("Data"), _
    Description("Determines an extra string property for this object. This property is displayed in the property dialog.")> _
    Public Property Notes() As String
      Get
        Return m_Notes
      End Get
      Set(ByVal Value As String)
        If m_Notes <> Value Then
          m_Notes = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines an integer priority level for the appointment. This property is displayed in the property dialog.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("priority"), _
    Category("Data"), _
    DefaultValue(0), _
    Description("Determines an integer priority level for the appointment. This property is displayed in the property dialog.")> _
    Public Property Priority() As Priority
      Get
        Return m_Priority
      End Get
      Set(ByVal Value As Priority)
        If Not (m_Priority Is Value) Then
          m_Priority = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines whether this appointment is block in a solid color on the schedule. When true, no appointment about the appointment is visible to the user. Also, the appointment is read-only.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("blockout"), _
    Category("Appearance"), _
    DefaultValue(m_def_Blockout), _
    Description("Determines whether this appointment is block in a solid color on the schedule. When true, no appointment about the appointment is visible to the user. Also, the appointment is read-only.")> _
    Public Property Blockout() As Boolean
      Get
        Return m_Blockout
      End Get
      Set(ByVal Value As Boolean)
        If m_Blockout <> Value Then
          m_Blockout = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the tooltip that is displayed over the appointment when the mouse hovers over it.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("tooltiptext"), _
    Category("Appearance"), _
    Description("Determines the tooltip that is displayed over the appointment when the mouse hovers over it.")> _
    Public Property ToolTipText() As String
      Get
        Return m_ToolTipText
      End Get
      Set(ByVal Value As String)
        If m_ToolTipText <> Value Then
          m_ToolTipText = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment may be modified by the user.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("isreadonly"), _
    Category("Behavior"), _
    DefaultValue(m_def_IsReadOnly), _
    Description("Determines if the appointment may be modified by the user.")> _
    Public Property IsReadOnly() As Boolean
      Get
        Return m_IsReadOnly
      End Get
      Set(ByVal Value As Boolean)
        If m_IsReadOnly <> Value Then
          m_IsReadOnly = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment is visible on the schedule.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("visible"), _
    Category("Appearance"), _
    DefaultValue(True), _
    Description("Determines if the appointment is visible on the schedule.")> _
    Public Property Visible() As Boolean
      Get
        Return m_Visible
      End Get
      Set(ByVal Value As Boolean)
        If m_Visible <> Value Then
          m_Visible = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the maximum length of the appointment. Set to -1 for no maximum value.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("maxlength"), _
    Category("Behavior"), _
    DefaultValue(-1), _
    Description("Determines the maximum length of the appointment. Set to -1 for no maximum value.")> _
    Public Property MaxLength() As Integer
      Get
        Return m_MaxLength
      End Get
      Set(ByVal Value As Integer)
        If m_MaxLength <> Value Then
          m_MaxLength = Value
          Call CheckMinMaxLength()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the minimum length of the appointment. Set to -1 for no minimum value.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("minlength"), _
    Category("Behavior"), _
    DefaultValue(-1), _
    Description("Determines the minimum length of the appointment. Set to -1 for no minimum value.")> _
    Public Property MinLength() As Integer
      Get
        Return m_MinLength
      End Get
      Set(ByVal Value As Integer)
        If m_MinLength <> Value Then
          m_MinLength = Value
          Call CheckMinMaxLength()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the subject of the appointment. This is the text that is used to to paint an appointment.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("subject"), _
    Category("Data"), _
    Description("Determines the subject of the appointment. This is the text that is used to to paint an appointment.")> _
    Public Property Subject() As String
      Get
        Return m_Subject
      End Get
      Set(ByVal Value As String)
        If m_Subject <> Value Then
          m_Subject = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment is flagged. Flagged appointments are displayed with a flag icon to notify the user.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("isflagged"), _
    Category("Appearance"), _
    DefaultValue(m_def_IsFlagged), _
    Description("Determines if the appointment is flagged. Flagged appointments are displayed with a flag icon to notify the user.")> _
    Public Property IsFlagged() As Boolean
      Get
        Return m_IsFlagged
      End Get
      Set(ByVal Value As Boolean)
        If m_IsFlagged <> Value Then
          m_IsFlagged = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

		<Browsable(False)> _
		Friend Property TabIndex() As Integer
			Get
				Return m_TabIndex
			End Get
			Set(ByVal Value As Integer)
				m_TabIndex = Value
			End Set
		End Property

    ''' <summary>
    ''' Determines if the appointment is public or private. This has no effect in its display.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("access"), _
    Category("Data"), _
    DefaultValue(GetType(AppointmentAccessConstants), "AccessPublic"), _
    Description("Determines if the appointment is public or private. This has no effect in its display.")> _
    Public Property Access() As AppointmentAccessConstants
      Get
        Return m_Access
      End Get
      Set(ByVal Value As AppointmentAccessConstants)
        If m_Access <> Value Then
          m_Access = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' This is a list of Category objects from the schedule's CategoryList object. These categories are said to be associated with this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("This is a list of Category objects from the schedule's CategoryList object. These categories are said to be associated with this appointment.")> _
    Public ReadOnly Property CategoryList() As CategoryList
      Get
        Return m_CategoryList
      End Get
    End Property

    ''' <summary>
    ''' This is a list of Provider objects from the schedule's ProviderList object. These providers are said to be associated with this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("This is a list of Provider objects from the schedule's ProviderList object. These providers are said to be associated with this appointment.")> _
    Public ReadOnly Property ProviderList() As ProviderList
      Get
        Return m_ProviderList
      End Get
    End Property

    ''' <summary>
    ''' This is a list of Resource objects from the schedule's ResourceList object. These resources are said to be associated with this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("This is a list of Resource objects from the schedule's ResourceList object. These resources are said to be associated with this appointment.")> _
    Public ReadOnly Property ResourceList() As ResourceList
      Get
        Return m_ResourceList
      End Get
    End Property

    ''' <summary>
    ''' This is a collection of files that are associated with this appointment.
    ''' </summary>
    <Browsable(False), _
    Description("This is a collection of files that are associated with this appointment.")> _
    Public ReadOnly Property FileCollection() As FileCollection
      Get
        Return m_FileCollection
      End Get
    End Property

    ''' <summary>
    ''' This is a collection of icons that are drawn on an appointment. This collection enables you to define custom icons to notify your user of information specific to your application.
    ''' </summary>
    <Browsable(False), _
    Description("This is a collection of icons that are drawn on an appointment. This collection enables you to define custom icons to notify your user of information specific to your application.")> _
    Public ReadOnly Property IconCollection() As IconCollection
      Get
        Return m_IconCollection
      End Get
    End Property

    ''' <summary>
    ''' This object contains all of the information to set an alarm and optional reminder.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    Description("This object contains all of the information to set an alarm and optional reminder.")> _
    Public ReadOnly Property Alarm() As AlarmItem
      Get
        Return m_Alarm
      End Get
    End Property

    ''' <summary>
    ''' Determines is this this non-event appointment is displayed in the event header.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("isactivity"), _
    DefaultValue(m_def_IsActivity), _
    Category("Appearance"), _
    Description("Determines is this this non-event appointment is displayed in the event header.")> _
    Public Property IsActivity() As Boolean
      Get
        If IsEvent Then
          'Events are never activities
          Return False
        Else
          Return m_IsActivity
        End If
      End Get
      Set(ByVal Value As Boolean)
        If m_IsActivity <> Value Then
          m_IsActivity = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if this appointment has been marked as an event. An event has no defined start time or length.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("isevent"), _
    DefaultValue(m_def_IsEvent), _
    Category("Appearance"), _
    Description("Determines if this appointment has been marked as an event. An event has no defined start time or length.")> _
    Public Property IsEvent() As Boolean
      Get
        Return m_IsEvent
      End Get
      Set(ByVal Value As Boolean)
        If m_IsEvent <> Value Then
          m_IsEvent = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

		Friend Property EventIndex() As Integer
			Get
				Return m_EventIndex
			End Get
			Set(ByVal Value As Integer)
				m_EventIndex = Value
			End Set
		End Property

    ''' <summary>
    ''' Determines the Recurrence object that has been associated with this appointment. This value may be Nothing if there is no associated object.
    ''' </summary>
    <Browsable(False), _
    Gravitybox.Design.Attributes.Persistable("recurrence_guid"), _
    Category("Data"), _
    Description("Determines the Recurrence object that has been associated with this appointment. This value may be Nothing if there is no associated object.")> _
    Public Property Recurrence() As Recurrence
      Get
        Return m_Recurrence
      End Get
      Set(ByVal Value As Recurrence)
        If Not (m_Recurrence Is Value) Then
          m_Recurrence = Value
          m_RecurrenceStamp = Me.GetRecurrenceStamp
          Call GoRefresh()
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        Else
          m_RecurrenceStamp = Me.GetRecurrenceStamp
        End If
      End Set
    End Property

		Friend ReadOnly Property RecurrenceStamp() As String
			Get
				Return m_RecurrenceStamp
			End Get
		End Property

    ''' <summary>
    ''' This object contains all the information to customize the header of this appointment object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentHeaderConverter)), _
    Description("This object contains all the information to customize the header of this appointment object.")> _
    Public ReadOnly Property Header() As AppointmentHeader
      Get
        Return m_Header
      End Get
    End Property

    ''' <summary>
    ''' This object contains all the format information for this object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentAppearanceConverter)), _
    Description("This object contains all the format information for this object.")> _
    Public Property Appearance() As Gravitybox.Objects.AppointmentAppearance
      Get
        Return m_Appearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.AppointmentAppearance)
        If Value Is Nothing Then
          SetupDefaultAppearance()
        Else
          RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
          m_Appearance = Value
          AddHandler m_Appearance.Refresh, AddressOf OnRefresh
        End If
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
      End Set
    End Property

		Friend ReadOnly Property TimeStamp() As Long
			Get
				Return m_TimeStamp
			End Get
		End Property

#End Region

#Region "GoRefresh"

		Friend Sub GoRefresh()
			Try
				If MainObject Is Nothing Then Return
				MainObject.DrawingDirty = True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "ResetAppearance"

		Friend Sub ResetAppearance(ByVal appearance As AppointmentAppearance, ByVal headerAppearance As AppointmentHeaderAppearance)

			Try
				Me.Appearance.FromXML(appearance.ToXML())
				Me.Header.Appearance.FromXML(headerAppearance.ToXML())
				'Reset the key
				Me.Appearance.SetKey(Guid.NewGuid.ToString())
				Me.Header.Appearance.SetKey(Guid.NewGuid.ToString())
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "ResetTimeStamp"

    Friend Sub ResetTimeStamp(ByVal callRefresh As Boolean)
      Try
        Dim value As Long = DateTime.Now.ToUniversalTime.Ticks
        If m_TimeStamp <> value Then
          m_TimeStamp = value
          If callRefresh Then
            OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "ResetRecurrenceStamp"

    Public Sub ResetRecurrenceStamp()
      Try
        m_RecurrenceStamp = Me.GetRecurrenceStamp
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

    Friend Sub ResetRecurrenceStamp(ByVal value As String)
      Try
        m_RecurrenceStamp = value
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "Other Methods"

    Friend Function GetRecurrenceStamp() As String

      'This method is a stamp of the date/time/length/room for an appointment
      'This is used to remember the original position of an appointment after 
      'a recurrence is added. If this appointment's "RecurrenceStamp" changes
			'then this is a broken recurrence

			If Me.Recurrence Is Nothing Then Return ""
			Try
        Dim dateIndex As Double
				Dim timeIndex As Double
				Dim roomIndex As Integer
				dateIndex = DateDiff(DateInterval.Day, PivotDate, Me.StartDate)
				timeIndex = CDbl(DateDiff(DateInterval.Minute, PivotTime, Me.StartTime) / MinutesPerDay)
				If (Me.Room Is Nothing) Then
					roomIndex = -1
				Else
					roomIndex = Me.Room.Key.GetHashCode
					'roomIndex = MainObject.RoomCollection.IndexOfVisible(Me.Room)
				End If

        'Calculate the stamp; however if longer than 36 chars then truncate the time as this is causing issues with the data binder
        Dim retval As String = dateIndex.ToString & "|" & timeIndex.ToString & "|" & Me.Length & "|" & roomIndex.ToString
        If (retval.Length > 36) Then
          retval = dateIndex.ToString & "|" & (Math.Round(timeIndex * 100000) / 100000).ToString & "|" & Me.Length & "|" & roomIndex.ToString
        End If
        Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

    Private Sub CheckMinMaxLength()

      Try
        'Check min/max lengths
        If Me.MinLength <> -1 Then If m_Length < Me.MinLength Then m_Length = Me.MinLength
        If Me.MaxLength <> -1 Then If m_Length > Me.MaxLength Then m_Length = Me.MaxLength
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Friend ReadOnly Property FirstCategory() As Gravitybox.Objects.Category
      Get
        If Me.CategoryList.Count = 0 Then
          Return Nothing
        Else
          Return CType(Me.CategoryList(0), Gravitybox.Objects.Category)
        End If
      End Get
    End Property

    Friend ReadOnly Property FirstProvider() As Gravitybox.Objects.Provider
      Get
        If Me.ProviderList.Count = 0 Then
          Return Nothing
        Else
          Return CType(Me.ProviderList(0), Gravitybox.Objects.Provider)
        End If
      End Get
    End Property

    Friend ReadOnly Property FirstResource() As Gravitybox.Objects.Resource
      Get
        If Me.ResourceList.Count = 0 Then
          Return Nothing
        Else
          Return CType(Me.ResourceList(0), Gravitybox.Objects.Resource)
        End If
      End Get
    End Property

    Friend ReadOnly Property PivotStartValue(ByVal useReminder As Boolean) As Single
      Get
        Try
          Dim dayIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, PivotDate, Me.StartDate))
          If useReminder Then
            'Dim tmp As Integer = Me.Alarm.Reminder Mod (HourPerDay * MinutesPerHour)
            'Dim anchorTime As Date = Me.StartDate
            'Dim testTime As Date = Me.StartDateTime.AddMinutes(tmp)
            'timeIndex = CSng(testTime.Subtract(anchorTime).TotalMinutes)
            Return GetAlarmPivotValue(Me.StartDateTime.AddMinutes(-Me.Alarm.Reminder))
          Else
            'timeIndex = CSng(DateDiff(DateInterval.Minute, PivotTime, Me.StartTime))
            Return GetAlarmPivotValue(Me.StartDateTime)
          End If
          'Return dayIndex + (timeIndex / MinutesPerDay)
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Get
    End Property

    Friend Function GetRealLength() As Integer
      Return m_Length
    End Function

    Public Sub SetStartTime(ByVal value As String)

      Try
        Dim st As Date = DateTime.Parse(value)
        m_StartTime = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime)
      End Try

    End Sub

#End Region

#Region "Conflicts"

    Friend Sub CalculateSortIndexes()
      CalculateSortIndexes(MainObject)
    End Sub

    Friend Sub CalculateSortIndexes(ByVal scheduleObject As Gravitybox.Controls.Schedule)

      Try

        'If there is no main object then there is nothing to do
        If scheduleObject Is Nothing Then Return

        'This method will calculate the sort index for each rectangle
        'this allows for conflicts to be displayed side-by-side with no overlap
        Dim rectInfo As AppointmentRectangleInfo
        Dim viewmode As Gravitybox.Controls.Schedule.ViewModeConstants
        viewmode = scheduleObject.ViewMode
        For Each rectInfo In Me.Rectangles
          Call CalculateSortIndex(viewmode, rectInfo, scheduleObject)
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    <Browsable(False), _
    Description("This method returns a Boolean value indicating whether the parameter appointment conflicts with this appointment object.")> _
    Public Function IsConflict(ByVal appointment As Appointment) As Boolean

      'If there is no object then there is no conflict
      If appointment Is Nothing Then Return False
      If appointment Is Me Then Return False

      Try

        'Check to determine if the SortIndexes overlap, if not
        'then there is no way that the appointments conflict.
        Dim rect1 As AppointmentRectangleInfo
        Dim rect2 As AppointmentRectangleInfo
        For Each rect1 In Me.Rectangles
          For Each rect2 In appointment.Rectangles
            If rect1.IsConflict(rect2) Then
              Return True
            End If
          Next
        Next
        Return False

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'This is only called for appointments that are not part of a collection
    'This is used for temp appointments for testing when moving/coping appointments
    Friend Sub InitializeRectangle()

      'If this appointment has rectangle then there is some mistake
      'This method should only be called for appointments with no rectangles
      If Me.Rectangles.Count <> 0 Then Return

      Try
        Dim provider As provider
        If Me.ProviderList.Count = 0 Then
          Dim newRectInfo As AppointmentRectangleInfo = Me.Rectangles.Add()
          newRectInfo.StartDate = Me.StartDate
          newRectInfo.StartTime = Me.StartTime
          newRectInfo.Length = Me.Length
          If Me.Room Is Nothing Then
            newRectInfo.StartRoom = -1
          Else
            newRectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(Me.Room)
          End If
          newRectInfo.StartProvider = -1

        Else
          For Each provider In Me.ProviderList
            Dim newRectInfo As AppointmentRectangleInfo = Me.Rectangles.Add()
            newRectInfo.StartDate = Me.StartDate
            newRectInfo.StartTime = Me.StartTime
            newRectInfo.Length = Me.Length
            If Me.Room Is Nothing Then
              newRectInfo.StartRoom = -1
            Else
              newRectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(Me.Room)
            End If
            newRectInfo.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
          Next

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "ToString"

    Public Overrides Function ToString() As String

      Try
        Const CRLF As String = ControlChars.CrLf
        Const CommaString As String = ", "
        Dim retval As String = ""
        Dim dateString As String = ""
        Dim roomString As String = ""
        Dim providerString As String = ""
        Dim resourceString As String = ""
        Dim timeString As String = ""

        If Me.StartDate = DefaultNoDate Then
          dateString = "Date: N/A"
        Else
          dateString = "Date: " & Me.StartDate.ToShortDateString
        End If
        If Me.StartTime = DefaultNoTime Then
          timeString = "Time: N/A"
        Else
          timeString = "Time: " & Me.StartTime.ToShortTimeString
        End If

        If Not (Me.Room Is Nothing) Then
          roomString = MainObject.RoomCollection.ObjectSingular
          If roomString <> "" Then roomString &= ": "
          roomString &= Me.Room.Text
        End If

        If Me.ProviderList.Count > 0 Then
          providerString = MainObject.ProviderCollection.ObjectSingular
          If providerString <> "" Then providerString &= ": "
          Dim provider As provider
          For Each provider In Me.ProviderList
            providerString &= provider.Text & CommaString
          Next
          If providerString.EndsWith(CommaString) Then
            providerString = Left(providerString, providerString.Length - CommaString.Length)
          End If
        End If

        If Me.ResourceList.Count > 0 Then
          resourceString = MainObject.ResourceCollection.ObjectSingular
          If resourceString <> "" Then resourceString &= ": "
          For Each resource As resource In Me.ResourceList
            resourceString &= resource.Text & CommaString
          Next
          If resourceString.EndsWith(CommaString) Then
            resourceString = Left(resourceString, resourceString.Length - CommaString.Length)
          End If
        End If

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month
            retval = dateString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            retval = dateString & CRLF & roomString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            retval = dateString & CRLF & providerString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            retval = dateString & CRLF & resourceString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            retval = dateString & CRLF & roomString & CRLF & timeString
          Case Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            retval = dateString & CRLF & providerString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            retval = roomString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            retval = roomString & CRLF & providerString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            retval = providerString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            retval = dateString & CRLF & timeString & CRLF & providerString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            retval = dateString & CRLF & timeString & CRLF & roomString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
            retval = dateString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
            retval = dateString & CRLF & timeString
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            retval = resourceString & CRLF & timeString
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "VCal Import/Export"

    Public Function ToVCAL(ByVal useUniversalTime As Boolean) As String

      Try
        'Create the VCS file with this appointment
        Dim appointmentList As New AppointmentList(Me.MainObject)
        Call appointmentList.Add(Me)
        Return CreateVCSAppointment(appointmentList, useUniversalTime)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function ToVCAL(ByVal filename As String, ByVal useUniversalTime As Boolean) As Boolean

      Try
        'Create the VCS file with this appointment
        Dim appointmentList As New AppointmentList(Me.MainObject)
        Call appointmentList.Add(Me)
        Return CreateVCSAppointment(appointmentList, filename, useUniversalTime)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the object to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String
      Return Me.XmlNode.OuterXml
    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

			Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement
      Dim elemNew As Xml.XmlNode

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "key", Me.Key)
        Call xmlHelper.addElement(parentNode, "text", Me.Text)
        Call xmlHelper.addElement(parentNode, "startdate", DateToLong(GetDate(m_StartDate)).ToString)
        Call xmlHelper.addElement(parentNode, "starttime", TimeToLong(GetTime(m_StartTime)).ToString)
        Call xmlHelper.addElement(parentNode, "length", m_Length.ToString)
        Call xmlHelper.addElement(parentNode, "notes", m_Notes)
        Call xmlHelper.addElement(parentNode, "blockout", m_Blockout.ToString)
        Call xmlHelper.addElement(parentNode, "tooltiptext", m_ToolTipText)
        Call xmlHelper.addElement(parentNode, "isreadonly", m_IsReadOnly.ToString)
        Call xmlHelper.addElement(parentNode, "visible", m_Visible.ToString)
        Call xmlHelper.addElement(parentNode, "maxlength", m_MaxLength.ToString)
        Call xmlHelper.addElement(parentNode, "minlength", m_MinLength.ToString)
        Call xmlHelper.addElement(parentNode, "subject", m_Subject)
        Call xmlHelper.addElement(parentNode, "isflagged", m_IsFlagged.ToString)
        Call xmlHelper.addElement(parentNode, "tabindex", m_TabIndex.ToString)
        Call xmlHelper.addElement(parentNode, "isevent", m_IsEvent.ToString)
        Call xmlHelper.addElement(parentNode, "eventindex", m_EventIndex.ToString)
        Call xmlHelper.addElement(parentNode, "recurrencestamp", m_RecurrenceStamp)
        Call xmlHelper.addElement(parentNode, "access", m_Access.ToString("d"))

        'Room
        If Not Me.Room Is Nothing Then
          Call xmlHelper.addElement(parentNode, "room", Me.Room.Key)
        End If

				'Appearance
				If Not Me.Appearance Is Nothing Then
					Call xmlHelper.addElement(parentNode, "appearance", Me.Appearance.Key)
				End If

				'Priority
				If Not Me.Priority Is Nothing Then
					Call xmlHelper.addElement(parentNode, "priority", Me.Priority.Key)
				End If

				'AppointmentType
				If Not Me.AppointmentType Is Nothing Then
					Call xmlHelper.addElement(parentNode, "appointmenttype", Me.AppointmentType.Key)
				End If

				'Recurrence
				If Not Me.Recurrence Is Nothing Then
					Call xmlHelper.addElement(parentNode, "recurrence", Me.Recurrence.Key)
				End If

				'Header
        elemNew = xmlHelper.addElement(parentNode, AppointmentHeader.MyXMLNodeName, "")
				elemNew.InnerXml = Header.XmlNode.InnerXml

				'PropertyItemCollection
				elemNew = xmlHelper.addElement(parentNode, PropertyItemCollection.MyXMLNodeName, "")
				elemNew.InnerXml = PropertyItemCollection.XmlNode.InnerXml

				'CategoryList
				elemNew = xmlHelper.addElement(parentNode, CategoryList.MyXMLNodeName, "")
				elemNew.InnerXml = CategoryList.XmlNode.InnerXml

				'ProviderList
				elemNew = xmlHelper.addElement(parentNode, ProviderList.MyXMLNodeName, "")
				elemNew.InnerXml = ProviderList.XmlNode.InnerXml

				'ResourceList
				elemNew = xmlHelper.addElement(parentNode, ResourceList.MyXMLNodeName, "")
				elemNew.InnerXml = ResourceList.XmlNode.InnerXml

				'FileCollection
				elemNew = xmlHelper.addElement(parentNode, FileCollection.MyXMLNodeName, "")
				elemNew.InnerXml = FileCollection.XmlNode.InnerXml

				'IconCollection
				elemNew = xmlHelper.addElement(parentNode, IconCollection.MyXMLNodeName, "")
				elemNew.InnerXml = IconCollection.XmlNode.InnerXml

				'Alarm
        elemNew = xmlHelper.addElement(parentNode, Gravitybox.Objects.AlarmItem.MyXMLNodeName, "")
				elemNew.InnerXml = Alarm.XmlNode.InnerXml

				'Return the XML string
				Return parentNode

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean
      Return FromXML(xml, False, False)
    End Function

    Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean
      Return FromXML(xml, Not shallow)
    End Function

    Friend Overloads Function FromXML(ByVal xml As String, ByVal includeChildren As Boolean) As Boolean

      Dim XMLDoc As New xml.XmlDocument

      Try

				'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				MyBase.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
				MyBase.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))
				m_StartDate = LongToDate(GetNodeValue(XMLDoc, startXPath & "startdate", DateToLong(GetDate(m_StartDate)).ToString))
				m_StartTime = LongToTime(GetNodeValue(XMLDoc, startXPath & "starttime", TimeToLong(GetTime(m_StartTime)).ToString))
				m_Length = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "length", m_Length.ToString("d")))
				m_Notes = GetNodeValue(XMLDoc, startXPath & "notes", m_Notes)
				m_Blockout = CBool(GetNodeValue(XMLDoc, startXPath & "blockout", m_Blockout.ToString))
				m_ToolTipText = GetNodeValue(XMLDoc, startXPath & "tooltiptext", m_ToolTipText)
				m_IsReadOnly = CBool(GetNodeValue(XMLDoc, startXPath & "isreadonly", m_IsReadOnly.ToString))
				m_Visible = CBool(GetNodeValue(XMLDoc, startXPath & "visible", m_Visible.ToString))
				m_MaxLength = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "maxlength", m_MaxLength.ToString))
				m_MinLength = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "minlength", m_MinLength.ToString))
				m_Subject = GetNodeValue(XMLDoc, startXPath & "subject", m_Subject)
				m_IsFlagged = CBool(GetNodeValue(XMLDoc, startXPath & "isflagged", m_IsFlagged.ToString))
				m_TabIndex = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "tabindex", m_TabIndex.ToString))
				m_IsEvent = CBool(GetNodeValue(XMLDoc, startXPath & "isevent", m_IsEvent.ToString))
				m_EventIndex = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "eventindex", m_EventIndex.ToString))
				m_RecurrenceStamp = GetNodeValue(XMLDoc, startXPath & "recurrencestamp", m_RecurrenceStamp)
				m_Access = CType([Enum].Parse(GetType(AppointmentAccessConstants), GetNodeValue(XMLDoc, startXPath & "access", m_Access.ToString("d"))), AppointmentAccessConstants)
				Call ResetTimeStamp(True)

				'Room
				Dim roomKey As String = GetNodeValue(XMLDoc, startXPath & "room", "")
				If MainObject.RoomCollection.Contains(roomKey) Then
					m_Room = MainObject.RoomCollection(roomKey)
				End If

				'Appearanace
				Dim appearanceKey As String = GetNodeValue(XMLDoc, startXPath & "appearance", "")
				If MainObject.AppearanceCollection.Contains(appearanceKey) Then
					m_Appearance = CType(MainObject.AppearanceCollection(appearanceKey), AppointmentAppearance)
				End If

				'Priority
				Dim priorityKey As String = GetNodeValue(XMLDoc, startXPath & "priority", "")
				If MainObject.PriorityCollection.Contains(priorityKey) Then
					m_Priority = MainObject.PriorityCollection(priorityKey)
				End If

				'AppointmentType
				Dim appointmentTypeKey As String = GetNodeValue(XMLDoc, startXPath & "appointmenttype", "")
				If MainObject.AppointmentTypeCollection.Contains(appointmentTypeKey) Then
					m_AppointmentType = MainObject.AppointmentTypeCollection(appointmentTypeKey)
				End If

				'Recurrence
				Dim recurrenceKey As String = GetNodeValue(XMLDoc, startXPath & "recurrence", "")
				If MainObject.RecurrenceCollection.Contains(recurrenceKey) Then
					m_Recurrence = MainObject.RecurrenceCollection(recurrenceKey)
				End If

				If includeChildren Then
					'Objects
					PropertyItemCollection.Clear()
					CategoryList.Clear()
					ProviderList.Clear()
					ResourceList.Clear()
					FileCollection.Clear()
					IconCollection.Clear()
					Alarm.FromXML(GetNodeXML(XMLDoc, startXPath & AlarmItem.MyXMLNodeName, "", True))
					Header.FromXML(GetNodeXML(XMLDoc, startXPath & Gravitybox.Objects.AppointmentHeader.MyXMLNodeName, "", True))
					PropertyItemCollection.FromXML(GetNodeXML(XMLDoc, startXPath & PropertyItemCollection.MyXMLNodeName, "", True))
					CategoryList.FromXML(GetNodeXML(XMLDoc, startXPath & CategoryList.MyXMLNodeName, "", True))
					ProviderList.FromXML(GetNodeXML(XMLDoc, startXPath & ProviderList.MyXMLNodeName, "", True))
					ResourceList.FromXML(GetNodeXML(XMLDoc, startXPath & ResourceList.MyXMLNodeName, "", True))
					FileCollection.FromXML(GetNodeXML(XMLDoc, startXPath & FileCollection.MyXMLNodeName, "", True))
					IconCollection.FromXML(GetNodeXML(XMLDoc, startXPath & IconCollection.MyXMLNodeName, "", True))
				End If

				OnReload(Me, New System.EventArgs)
				OnRefresh(Me, New AfterBaseObjectEventArgs(Me))

				Return True

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overloads Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

#Region "Refresh Events"

    Private Sub SubObjectRefreshFileCollection(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      SubObjectRefresh(sender, CType(e, System.EventArgs))
    End Sub

    Private Sub SubObjectRefreshPropertyItemCollection(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      SubObjectRefresh(sender, CType(e, System.EventArgs))
    End Sub

    Private Sub SubObjectRefreshIconCollection(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      SubObjectRefresh(sender, CType(e, System.EventArgs))
    End Sub

    Private Sub SubObjectRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
        Call Me.CalculateSortIndexes()
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "ICompare"

    Private Overloads Function CompareTo(ByVal obj As Object) As Integer
      Try
        If (obj Is Nothing) Then Return -1
        Dim o1Index As Double = Me.Rectangles(0).SortIndexStart
        Dim o2Index As Double = CType(obj, Appointment).Rectangles(0).SortIndexStart
        If o1Index = o2Index Then
          Return 0
        ElseIf o1Index < o2Index Then
          Return -1
        Else
          Return 1
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

#Region "Drawing"

    Friend Sub Draw(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule)

      Dim bodyRectangle As Rectangle
      Dim headerRectangle As Rectangle
      Dim iconBuffer As Integer
      Dim currentAppearance As AppointmentAppearance = Me.Appearance
      Dim currentHeaderAppearance As AppointmentHeaderAppearance = Me.Header.Appearance
      Dim shadowSize As Integer = 0
      Dim allowShadow As Boolean = (MainObject.ViewMode <> Gravitybox.Controls.Schedule.ViewModeConstants.Month) AndAlso (MainObject.ViewMode <> Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull) AndAlso (MainObject.ViewMode <> Gravitybox.Controls.Schedule.ViewModeConstants.Week)

      'If this is an event/activity and the schedule does not 
      'display the event header then nothing to draw
      If (Not MainObject.EventHeader.AllowHeader OrElse Not MainObject.EventHeader.IsExpanded) AndAlso (Me.IsActivity OrElse Me.IsEvent) Then
        Return
      End If

      Try
        'Do not draw if this object is invisible
        If Not Me.Visible Then Return

        'Use the selected appearance object if need be

        Dim borderPenWidth As Integer = Me.Appearance.BorderWidth
        If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
          currentAppearance = MainObject.SelectedAppointmentAppearance
          currentHeaderAppearance = MainObject.SelectedAppointmentHeaderAppearance
          borderPenWidth = currentAppearance.BorderWidth
        ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
          borderPenWidth = 3
        End If

#If DEBUG Then
        Dim startTime As Date = Now
        Dim endTime As Date = Now
#End If

        'If the appointment is NOT in the viewport then draw the timebar but NOTHING ELSE
        If Not InViewport() Then
#If DEBUG Then
          endTime = Date.Now
          'Debug.WriteLine("Not Viewport 1: " & endTime.Subtract(startTime).TotalMilliseconds)
          startTime = Date.Now
#End If
          For Each rectInfo As AppointmentRectangleInfo In Me.Rectangles
#If DEBUG Then
            endTime = Date.Now
            'Debug.WriteLine("Not Viewport 2: " & endTime.Subtract(startTime).TotalMilliseconds)
            startTime = Date.Now
#End If
            Dim rectangle As System.Drawing.Rectangle = rectInfo.Rect
            'Draw the TimeBar if necessary
            Call DrawTimeBar(g, rectangle)
#If DEBUG Then
            endTime = Date.Now
            'Debug.WriteLine("Not Viewport 3: " & endTime.Subtract(startTime).TotalMilliseconds)
            startTime = Date.Now
#End If
          Next

#If DEBUG Then
          endTime = Date.Now
          'Debug.WriteLine("Not Viewport 4: " & endTime.Subtract(startTime).TotalMilliseconds)
          startTime = Date.Now
#End If

          Return
        End If

#If DEBUG Then
        endTime = Date.Now
        'Debug.WriteLine("In Viewport: " & endTime.Subtract(startTime).TotalMilliseconds)
        startTime = Date.Now
#End If

        'The shadow can NOT be bigger than the space to draw it
        shadowSize = Me.Appearance.ShadowSize
        If shadowSize > MainObject.AppointmentSpace Then
          shadowSize = MainObject.AppointmentSpace
        End If

        For Each rectInfo As AppointmentRectangleInfo In Me.Rectangles

          Dim rectangle As System.Drawing.Rectangle = rectInfo.Rect

          'Draw the TimeBar if necessary
          Call DrawTimeBar(g, rectangle)

          If (rectangle.Width = 0) Or (rectangle.Height = 0) Then
            'Do Nothing
            'There is no visible rectangle so do not draw anything

          ElseIf (Not Me.IsEvent And Not Me.IsActivity) AndAlso ((rectangle.Right <= MainObject.ClientLeft) OrElse (rectangle.Bottom <= MainObject.ClientTop)) Then
            'Do Nothing
            'If the rectangle is NOT visible?

          ElseIf Me.Blockout Then

            'If this appointment is blocked-out then just draw a solid color block
            If currentAppearance.IsRound Then

              'Draw the shadow
              If (allowShadow) AndAlso (shadowSize > 0) Then
                Dim shadowRect As New Rectangle(rectangle.Location, rectangle.Size)
                shadowRect.Offset(shadowSize, shadowSize)
                Call g.FillPath(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), GetRoundRect(shadowRect, False, False))
              End If
              'Real rectangle
              Call g.FillPath(New SolidBrush(MainObject.BlockoutColor), GetRoundRect(rectangle, False, False))
            Else

              'Draw the shadow
              If (allowShadow) AndAlso (shadowSize > 0) Then
                Dim shadowRect As New Rectangle(rectangle.Location, rectangle.Size)
                shadowRect.Offset(shadowSize, shadowSize)
                Call g.FillRectangle(New SolidBrush(Color.FromArgb(50, 0, 0, 0)), shadowRect)
              End If
              'Real rectangle
              Call g.FillRectangle(New SolidBrush(MainObject.BlockoutColor), rectangle)
            End If

          Else

            'Setup the header font
            Dim headerFontStyle As System.Drawing.FontStyle
            If currentHeaderAppearance.FontBold Then headerFontStyle = headerFontStyle Or fontStyle.Bold
            If currentHeaderAppearance.FontItalics Then headerFontStyle = headerFontStyle Or fontStyle.Italic
            If currentHeaderAppearance.FontStrikeout Then headerFontStyle = headerFontStyle Or fontStyle.Strikeout
            If currentHeaderAppearance.FontUnderline Then headerFontStyle = headerFontStyle Or fontStyle.Underline
            Dim headerFont As New Font(MainObject.Font.FontFamily, Me.Header.Appearance.FontSize, headerFontStyle, Me.Header.Appearance.FontUnit)

            'Do not draw the header if one is explicitly specified
            headerRectangle = New Rectangle(0, 0, 0, 0)
            If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
              bodyRectangle = New Rectangle(rectangle.Left + 1, rectangle.Top, rectangle.Width - 1, rectangle.Height)
            ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then
              bodyRectangle = New Rectangle(rectangle.Left + 1, rectangle.Top, rectangle.Width - 1, rectangle.Height)
            ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week Then
              bodyRectangle = New Rectangle(rectangle.Left + 1, rectangle.Top, rectangle.Width - 1, rectangle.Height)
            ElseIf (Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None) OrElse (Me.IsEvent) Then
							bodyRectangle = rectangle
            Else
              'Calculate the header height
              Dim fontStyle As System.Drawing.FontStyle
              fontStyle = fontStyle Or fontStyle.Bold
              Dim apptFont As New Font(MainObject.Font.FontFamily, Me.Appearance.FontSize, fontStyle, Me.Appearance.FontUnit)
              Dim stringFormat As New stringFormat
              stringFormat.FormatFlags = currentAppearance.StringFormatFlags
              Dim headerTextHeight As Integer = GetIntlInteger(g.MeasureString("W", headerFont).Height)
              If Not (Me.Header.Icon Is Nothing) Then
                'This is for the 16x16 icons
                If headerTextHeight < 18 Then headerTextHeight = 18
              End If
              bodyRectangle = New Rectangle(rectangle.Left, rectangle.Top + headerTextHeight, rectangle.Width, rectangle.Height - headerTextHeight)
              headerRectangle = New Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, headerTextHeight)
							Me.Header.SetClientRectangle(headerRectangle)
            End If

            'Determine if the appointment is round
            Dim borderRect As Rectangle = rectangle
            If (headerRectangle.Height > rectangle.Height) OrElse (headerRectangle.Width > rectangle.Width) Then
              borderRect = headerRectangle
              rectInfo.Rect = New Rectangle(rectInfo.Rect.Left, rectInfo.Rect.Top, borderRect.Width, borderRect.Height)
            End If

            'Make sure we are to fill this appointment
            If Not Me.Appearance.NoFill Then

              'Shadow Stuff
              Dim shadowBrush As Brush = Nothing
              Dim shadowRect As System.Drawing.Rectangle
              If (allowShadow) AndAlso (shadowSize > 0) Then
                shadowBrush = New SolidBrush(Color.FromArgb(50, 0, 0, 0))
                If headerRectangle.Height = 0 Then
                  'If there is no header then do not consider it
                  shadowRect = New System.Drawing.Rectangle(bodyRectangle.Location, bodyRectangle.Size)
                Else
                  'If there is a header then draw the shadow to include it as well
                  shadowRect = New System.Drawing.Rectangle(headerRectangle.Location.X, headerRectangle.Location.Y, bodyRectangle.Size.Width, headerRectangle.Size.Height + bodyRectangle.Size.Height)
                End If
                shadowRect.Offset(shadowSize, shadowSize)
              End If

              'Create the fill brush
              Dim fillBrush As Brush = CreateBrush(currentAppearance, bodyRectangle)
              If Me.Appearance.Ghosted Then fillBrush = CreateGhostedBrush()

              'Determine if the appointment is round
              If Me.IsEvent AndAlso currentAppearance.IsRound Then
                'Draw the shadow
                If (allowShadow) AndAlso (shadowSize > 0) Then
                  Call g.FillPath(shadowBrush, GetRoundRect(shadowRect, False, False))
                End If
                'Draw the Rectangle
                Call g.FillPath(fillBrush, GetRoundRect(bodyRectangle, False, False))
              ElseIf Me.IsEvent AndAlso Not currentAppearance.IsRound Then
                'Draw the shadow
                If (allowShadow) AndAlso (shadowSize > 0) Then
                  Call g.FillRectangle(shadowBrush, shadowRect)
                End If
                'Draw the Rectangle
                Call g.FillRectangle(fillBrush, bodyRectangle)
              ElseIf currentAppearance.IsRound AndAlso (Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None) Then
                'Draw the shadow
                If (allowShadow) AndAlso (shadowSize > 0) Then
                  Call g.FillPath(shadowBrush, GetRoundRect(shadowRect, False, False))
                End If
                'Draw the Rectangle
                Call g.FillPath(fillBrush, GetRoundRect(bodyRectangle, False, False))
              ElseIf currentAppearance.IsRound Then
                'Draw the shadow
                If (allowShadow) AndAlso (shadowSize > 0) Then
                  Call g.FillPath(shadowBrush, GetRoundRect(shadowRect, False, False))
                End If
                'Draw the Rectangle
                Call g.FillPath(fillBrush, GetRoundRect(bodyRectangle, False, True))
              Else
                'Draw the shadow
                If (allowShadow) AndAlso (shadowSize > 0) Then
                  Call g.FillRectangle(shadowBrush, shadowRect)
                End If
                'Draw the Rectangle
                Call g.FillRectangle(fillBrush, bodyRectangle)
              End If
              Call fillBrush.Dispose()

              'Draw the appointment icons
              iconBuffer = DrawIcons(g, MainObject, bodyRectangle)

            End If     'NoFill

            'Draw text
            Call DrawText(g, MainObject, headerRectangle, iconBuffer)
						Call DrawSideBar(g, MainObject, rectInfo, headerRectangle)

            'Draw the header (if need be)
            Call DrawHeader(g, MainObject, headerFont, headerRectangle)

            If MainObject.SelectedItems.Contains(Me) Then
              Call DrawHilite(g, MainObject)
            End If

            If currentAppearance.IsRound Then
              If borderPenWidth > 0 Then
                Dim borderPen As Pen = CreateBorderPen(currentAppearance, borderPenWidth)
                If Me.Appearance.Ghosted Then
                  borderPen = CreateGhostedPen()
                End If
                Call g.DrawPath(borderPen, GetRoundRect(borderRect, False, False))
                borderPen.Dispose()
              End If
            Else
              If borderPenWidth > 0 Then
                Dim borderPen As Pen = CreateBorderPen(currentAppearance, borderPenWidth)
                If Me.Appearance.Ghosted Then
                  borderPen = CreateGhostedPen()
                End If
                Call g.DrawRectangle(borderPen, borderRect)
                borderPen.Dispose()
              End If
            End If

          End If

					If Not (Me.IsActivity OrElse Me.IsEvent) AndAlso (rectInfo.Rect.Width > 0) AndAlso (rectInfo.Rect.Height > 0) Then
						If rectInfo.BrokenStart AndAlso Not Me.MainObject.Visibility.IsPrinting Then
							Dim targetRect As New Rectangle(rectInfo.Rect.Right - 20, rectInfo.Rect.Top + Me.Header.ClientRectangle.Height, 20, 8)
							Call g.DrawImageUnscaled(New Bitmap(GetProjectFileAsStream("scroll.up.bmp")), targetRect)
						End If
						If rectInfo.BrokenEnd AndAlso Not Me.MainObject.Visibility.IsPrinting Then
							Dim targetRect As New Rectangle(rectInfo.Rect.Right - 20, rectInfo.Rect.Bottom - 8, 20, 8)
							Call g.DrawImageUnscaled(New Bitmap(GetProjectFileAsStream("scroll.down.bmp")), targetRect)
						End If
					End If

				Next				'Loop through rectangles

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub DrawHilite(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule)

      Dim rectInfo As AppointmentRectangleInfo
      Dim apptRect As Rectangle
      Dim CurrentAppearance As AppointmentAppearance = Me.Appearance

      'In month mode there is nothing to draw
      If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
        Return
      ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then
        Return
      End If

      Try
        'Use the selected appearance object if need be
        Dim borderPenWidth As Integer = 1
        If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
          CurrentAppearance = MainObject.SelectedAppointmentAppearance
          borderPenWidth = CurrentAppearance.BorderWidth
        ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
          borderPenWidth = 3
        ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
          borderPenWidth = 0
        End If

        'Nothing to do, there is no border
        If borderPenWidth = 0 Then Return

        'Create the border pen
        Dim borderPen As Pen = CreateBorderPen(CurrentAppearance, borderPenWidth)
        If Me.Appearance.Ghosted Then
          borderPen = CreateGhostedPen()
        End If

        'Loop and highlight all rectangles
        For Each rectInfo In Me.Rectangles
          apptRect = rectInfo.Rect
          If (apptRect.Right > MainObject.ClientLeft) AndAlso (apptRect.Bottom > MainObject.ClientTop) Then
            If CurrentAppearance.IsRound Then
              Call g.DrawPath(borderPen, GetRoundRect(apptRect, False, False))
            ElseIf Me.IsActivity OrElse Me.IsEvent Then
              'Thick border around activities and events
              Dim borderRect As Rectangle = New Rectangle(apptRect.Left, apptRect.Top, apptRect.Width, apptRect.Height)
              If (borderRect.Left >= MainObject.ClientLeft) AndAlso (borderRect.Top >= MainObject.TopHeaderHeight) Then
                Call g.DrawRectangle(borderPen, borderRect)
              End If
            Else
              Call g.DrawRectangle(borderPen, apptRect)
            End If
          End If
        Next
        Call borderPen.Dispose()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub DrawHeader(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule, ByVal headerFont As Font, ByVal rect As Rectangle)

      Dim CurrentAppearance As AppointmentAppearance = Me.Appearance
      Dim CurrentHeaderAppearance As AppointmentHeaderAppearance = Me.Header.Appearance

      Try

				'**************************************************
				'If there is no header then there is nothing to do
				If Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None Then Return
				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then Return
				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then Return
				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week Then Return
				If Me.IsEvent Then Return

				'If the header is owner drawn then raise the event
        If Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.UserDrawn Then
          MainObject.RaiseAppointmentHeaderUserDrawnEvent(g, Me, rect)
          Return
        End If

				'Use the selected appearance object if need be
				Dim borderPenWidth As Integer = 1
				If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
					CurrentAppearance = MainObject.SelectedAppointmentAppearance
					CurrentHeaderAppearance = MainObject.SelectedAppointmentHeaderAppearance
					borderPenWidth = CurrentAppearance.BorderWidth
				ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
					borderPenWidth = 3
				End If

				'**************************************************
				'Determine the text to display in the header
        Dim drawText As String = ""
				If Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader Then
					drawText = Me.StartDate.ToShortDateString
				ElseIf Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader Then
					drawText = Me.StartTime.ToString(MainObject.HeaderTimeFormat)
				ElseIf Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text Then
					drawText = Me.Header.Text
				End If

				'Setup the font
				Dim stringFormat As New stringFormat
				stringFormat.FormatFlags = CurrentHeaderAppearance.StringFormatFlags Or StringFormatFlags.NoWrap Or StringFormatFlags.FitBlackBox
				stringFormat.LineAlignment = CurrentHeaderAppearance.TextVAlign
				stringFormat.Trimming = CurrentHeaderAppearance.TextTrimming

				'**************************************************
				'Determine if the appointment is round
				Dim rectF As RectangleF
				If CurrentAppearance.IsRound Then
					rectF = New RectangleF(rect.Left + (RoundRadius \ 2), rect.Top, rect.Width - RoundRadius, rect.Height)
				Else
					rectF = New RectangleF(rect.Left, rect.Top, rect.Width, rect.Height)
				End If

				If Not Me.Header.Appearance.NoFill Then
					Dim fillBrush As Brush = CreateBrush(CurrentHeaderAppearance, rect)
					If Me.Appearance.Ghosted Then
						fillBrush = CreateGhostedBrush()
					End If
					If CurrentAppearance.IsRound Then
						Call g.FillPath(fillBrush, GetRoundRect(rect, True, False))
					Else
						Call g.FillRectangle(fillBrush, rect)
					End If
					Call fillBrush.Dispose()
				End If

				'**************************************************
				'Draw the text
				Dim textPen As Pen = CreateTextPen(CurrentHeaderAppearance)
				If Me.Appearance.Ghosted Then
					textPen = CreateGhostedPen()
				End If
				Call g.DrawString(drawText, headerFont, textPen.Brush, rectF, stringFormat)
				textPen.Dispose()

				'For right now do not draw icons is ghosted
				If Not Me.Appearance.Ghosted Then
					'Draw the info icon if necessary
					If Not (Me.Header.Icon Is Nothing) Then
						Dim skew As Integer = 0
						Call DrawIcon(1, 0, rect.Right - 18 - skew, rect.Top + 2, rect, 0, 0, g, Me.Header.Icon)
					End If
				End If

				'Draw a line under the header if necessary
				If CurrentHeaderAppearance.AllowBreak Then
					Dim borderPen As Pen = CreateBorderPen(CurrentHeaderAppearance)
					If Me.Appearance.Ghosted Then
						borderPen = CreateGhostedPen()
					End If
          Call g.DrawLine(borderPen, rect.Left, rect.Bottom, rect.Right, rect.Bottom)
					borderPen.Dispose()
				End If

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub DrawText(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule, ByVal headerRectangle As Rectangle, ByVal iconBuffer As Integer)

      Dim appointmentFontStyle As System.Drawing.FontStyle
      Dim buffer As Integer
      Dim foreColor As Color
      Dim CurrentAppearance As AppointmentAppearance = Me.Appearance

      Try
        'Use the selected appearance object if need be
        Dim borderPenWidth As Integer = 1
        If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
          CurrentAppearance = MainObject.SelectedAppointmentAppearance
          borderPenWidth = CurrentAppearance.BorderWidth
        ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
          borderPenWidth = 3
        End If

        If CurrentAppearance.FontBold Then appointmentFontStyle = appointmentFontStyle Or FontStyle.Bold
        If CurrentAppearance.FontItalics Then appointmentFontStyle = appointmentFontStyle Or FontStyle.Italic
        If CurrentAppearance.FontStrikeout Then appointmentFontStyle = appointmentFontStyle Or FontStyle.Strikeout
        If CurrentAppearance.FontUnderline Then appointmentFontStyle = appointmentFontStyle Or FontStyle.Underline

        'In month mode there is no highlight space at the top of the appointment
        If (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month) Then
          buffer = 0
        ElseIf (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull) Then
          buffer = 0
        ElseIf (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week) Then
          buffer = 0
        ElseIf Me.IsActivity OrElse Me.IsEvent Then
          buffer = TextMargin
        ElseIf Me.Header.HeaderType <> AppointmentHeader.HeaderTypeConstants.None Then
          buffer = 0
        Else
          buffer = Gravitybox.Controls.Schedule.HiliteSize
        End If

        'In month mode use the system hilite colors
        If (Me Is MainObject.SelectedItem) And (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month) Then
          foreColor = SystemColors.HighlightText
        ElseIf (Me Is MainObject.SelectedItem) And (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull) Then
          foreColor = SystemColors.HighlightText
        Else
          foreColor = CurrentAppearance.ForeColor
        End If

        'Setup the appointment font
        Dim apptFont As New Font(MainObject.Font.FontFamily, Me.Appearance.FontSize, appointmentFontStyle, Me.Appearance.FontUnit)
        Dim stringFormat As New stringFormat
        stringFormat.FormatFlags = CurrentAppearance.StringFormatFlags
        stringFormat.Alignment = CurrentAppearance.Alignment
        stringFormat.LineAlignment = CurrentAppearance.TextVAlign
        stringFormat.Trimming = CurrentAppearance.TextTrimming

        'Calculate header size
        Dim headerHeight As Integer
        If Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None Then
          headerHeight = 0
        ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
          headerHeight = 0
        ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then
          headerHeight = 0
        ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week Then
          headerHeight = 0
        ElseIf Me.IsEvent Then
          headerHeight = 0
        Else
          headerHeight = headerRectangle.Height     'GetIntlInteger(g.MeasureString("W", headerFont).Height) + (TextMargin * 2)
        End If

        Dim barWidth As Integer
        If MainObject.AppointmentBar.BarType <> Gravitybox.Controls.Schedule.AppointmentBarConstants.None Then
          barWidth = MainObject.AppointmentBar.Size
        End If

        'Draw the text in each rectangle
        Dim rectInfo As AppointmentRectangleInfo
        For Each rectInfo In Me.Rectangles
          Dim rectF As New RectangleF(rectInfo.Rect.Left + barWidth + ScheduleGlobals.TextMargin + iconBuffer, rectInfo.Rect.Top + headerHeight + TextMargin, rectInfo.Rect.Width - buffer - iconBuffer - barWidth, rectInfo.Rect.Height - headerHeight - TextMargin)

          Dim textInRange As Boolean = False
          If Me.IsEvent OrElse Me.IsActivity Then
            textInRange = (rectF.Bottom > (MainObject.ClientTop - MainObject.EventHeaderHeight))
          Else
            textInRange = (rectF.Bottom > MainObject.ClientTop)
          End If

          If (rectF.Width > 0) AndAlso (rectF.Height > 0) AndAlso (rectF.Right > MainObject.ClientLeft) AndAlso textInRange Then
            'Raise an event to give the user a chance to cancel or change the text
            Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs(Me)
            Call MainObject.FireEventBeforeAppointmentTextDraw(Me, eventParam1)
            If (Not eventParam1.Cancel) AndAlso (eventParam1.Text <> "") Then
              Dim textPen As Pen = CreateTextPen(Me.Appearance)
              If Me.Appearance.Ghosted Then
                textPen = CreateGhostedPen()
							End If
							Call g.DrawString(eventParam1.Text, apptFont, textPen.Brush, rectF, stringFormat)
							textPen.Dispose()
						End If
					End If
				Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub DrawTimeBar(ByVal g As Graphics, ByVal rectangle As Rectangle)

      Try

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
          Case Else
            Return
        End Select

        Dim ghostBrush As Brush = CreateGhostedBrush()
        Dim ghostPen As Pen = CreateGhostedPen()

        'Determine which TimeBar is being displayed
        Select Case MainObject.TimeBar.BarType
          Case Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
            'For each category assigned to this appointment color its TimeBar
            For Each category As category In Me.CategoryList
              Dim index As Integer = MainObject.CategoryCollection.IndexOf(category)
              Dim barRect As rectangle = New rectangle((index * MainObject.TimeBar.Size) + 1, rectangle.Top, MainObject.TimeBar.Size - 1, rectangle.Height)
              If (index >= 0) AndAlso (barRect.Bottom > MainObject.ClientTop) Then
								Call g.FillRectangle(New SolidBrush(category.Appearance.BackColor), barRect)
                barRect = New rectangle(barRect.Left - 1, barRect.Top, barRect.Width + 1, barRect.Height)
                Call g.DrawRectangle(New Pen(Color.Black), barRect)
              End If
            Next

          Case Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider
            'For each provider assigned to this appointment color its TimeBar
            For Each provider As provider In Me.ProviderList
              Dim index As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
              Dim barRect As rectangle = New rectangle((index * MainObject.TimeBar.Size) + 1, rectangle.Top, MainObject.TimeBar.Size - 1, rectangle.Height)
              If (index >= 0) AndAlso (barRect.Bottom > MainObject.ClientTop) Then
								Call g.FillRectangle(New SolidBrush(provider.Appearance.BackColor), barRect)
                barRect = New rectangle(barRect.Left - 1, barRect.Top, barRect.Width + 1, barRect.Height)
                Call g.DrawRectangle(New Pen(Color.Black), barRect)
              End If
            Next

          Case Gravitybox.Controls.Schedule.AppointmentBarConstants.Resource
            'For each resource assigned to this appointment color its TimeBar
            For Each resource As Gravitybox.Objects.Resource In Me.ResourceList
              Dim index As Integer = MainObject.ResourceCollection.IndexOf(resource)
              Dim barRect As rectangle = New rectangle((index * MainObject.TimeBar.Size) + 1, rectangle.Top, MainObject.TimeBar.Size - 1, rectangle.Height)
              If (index >= 0) AndAlso (barRect.Bottom > MainObject.ClientTop) Then
                Call g.FillRectangle(New SolidBrush(resource.Appearance.BackColor), barRect)
                barRect = New rectangle(barRect.Left - 1, barRect.Top, barRect.Width + 1, barRect.Height)
                Call g.DrawRectangle(New Pen(Color.Black), barRect)
              End If
            Next

          Case Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn
            'Let the container draw the TimeBar
            Dim barRect As rectangle = New rectangle(1, rectangle.Top, MainObject.TimeBar.Size - 1, rectangle.Height)
            If (barRect.Bottom > MainObject.ClientTop) Then
              Dim eventParam1 As New Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs(g, Me, barRect)
              Call MainObject.FireEventBeforeTimeBarDraw(Me, eventParam1)
            End If

        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

		Private Sub DrawSideBar(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule, ByVal rectInfo As AppointmentRectangleInfo, ByVal headerRectangle As Rectangle)

			Dim color As color
			Dim CurrentAppearance As AppointmentAppearance = Me.Appearance

			Try

				'Use the selected appearance object if need be
				Dim borderPenWidth As Integer = 1
				If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
					CurrentAppearance = MainObject.SelectedAppointmentAppearance
					borderPenWidth = CurrentAppearance.BorderWidth
				ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
					borderPenWidth = 3
				End If

				'Determine which bar should be drawn Provider or Category
				If MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None Then
					Return

				ElseIf MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn Then
					'Do Nothing

				ElseIf MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category Then
					Dim category As Gravitybox.Objects.Category = Me.FirstCategory
					If category Is Nothing Then
						Return
					ElseIf Me.Appearance.Ghosted Then
						color = GhostedBrushColor
					Else
						color = category.Appearance.BackColor
					End If

				ElseIf MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider Then
					Dim provider As Gravitybox.Objects.Provider = Me.FirstProvider
					If provider Is Nothing Then
						Return
					ElseIf Me.Appearance.Ghosted Then
						color = GhostedBrushColor
					Else
						color = provider.Appearance.BackColor
					End If

				ElseIf MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Resource Then
					Dim resource As Gravitybox.Objects.Resource = Me.FirstResource
					If resource Is Nothing Then
						Return
					ElseIf Me.Appearance.Ghosted Then
						color = GhostedBrushColor
					Else
            color = resource.Appearance.BackColor
					End If

				End If

				If (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month) OrElse _
				 (MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull) Then

					'MonthView
					Dim rectangle As Rectangle
					'Dim rectInfo As AppointmentRectangleInfo
					'For Each rectInfo In Me.Rectangles
					Dim size As Integer = 7
					If size > rectInfo.Rect.Height - 4 Then size = rectInfo.Rect.Height - 4
					If size > 0 Then
						rectangle = New Rectangle(rectInfo.Rect.Left + 2, rectInfo.Rect.Top + 4, 7, size)
						If MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn Then
							'Remove the border coordintes from the rectangle. This is the actual painting rectangle of the bar
							Call MainObject.RaiseAppointmentBarUserDrawnEvent(g, Me, New Rectangle(rectangle.Left + 1, rectangle.Top + 1, MainObject.AppointmentBar.Size - 1, rectangle.Height - 1))
						Else
							'Fill in the rectangle
							Call g.FillEllipse(New SolidBrush(color), rectangle)
						End If
						'Draw a border around the bar
						If Me.Appearance.Ghosted Then
							Call g.DrawEllipse(CreateGhostedPen, rectangle)
						Else
							Call g.DrawEllipse(New Pen(CurrentAppearance.BorderColor), rectangle)
						End If
					End If
					'Next

				Else
					'All modes but NOT month
					Dim rectangle As Rectangle
					'Dim rectInfo As AppointmentRectangleInfo
					'For Each rectInfo In Me.Rectangles

					'Calculate the side bar rectangle
					Dim skew As Integer = 0
					If CurrentAppearance.IsRound Then skew = RoundRadius \ 2
					If Me.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None Then
						rectangle = New Rectangle(rectInfo.Rect.Left, rectInfo.Rect.Top + headerRectangle.Height + skew, MainObject.AppointmentBar.Size, rectInfo.Rect.Height - headerRectangle.Height - (skew * 2))
					Else
						rectangle = New Rectangle(rectInfo.Rect.Left, rectInfo.Rect.Top + headerRectangle.Height, MainObject.AppointmentBar.Size, rectInfo.Rect.Height - headerRectangle.Height - skew)
					End If

					'If the rectangle is inside the grid
					If (rectangle.Right > MainObject.ClientLeft) AndAlso (rectangle.Bottom > MainObject.ClientTop) Then
						If MainObject.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn Then
							'Remove the border coordintes from the rectangle. This is the actual painting rectangle of the bar
							'Call MainObject.RaiseAppointmentBarUserDrawnEvent(g, Me, New Rectangle(rectangle.Left + 1, rectangle.Top + 1, MainObject.AppointmentBar.Size - 1, rectangle.Height - 1))
							Call MainObject.RaiseAppointmentBarUserDrawnEvent(g, Me, New Rectangle(rectangle.Left, rectangle.Top, MainObject.AppointmentBar.Size, rectangle.Height))
						Else
							'Fill in the rectangle
							Call g.FillRectangle(New SolidBrush(color), rectangle)
						End If
						'Draw a border around the bar

						If MainObject.AppointmentBar.BarType <> Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn Then
							If Me.Appearance.Ghosted Then
								Call g.DrawRectangle(CreateGhostedPen, rectangle)
							Else
								Call g.DrawRectangle(New Pen(CurrentAppearance.BorderColor), rectangle)
							End If
						End If

					End If

					'Next

				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Function DrawIcons(ByVal g As Graphics, ByVal MainObject As Gravitybox.Controls.Schedule, ByVal rectangle As Rectangle) As Integer

			'For right now do not draw icons is ghosted
			If Me.Appearance.Ghosted Then
				Return 0
			End If

			Try
				Dim iconItem As iconItem
        Dim vertCount As Integer
				Dim column As Integer
				Dim left As Integer
				Dim top As Integer
				Dim height As Integer
				Dim ii As Integer
				Dim retval As Integer
				Dim buffer As Integer
				Const IconRightBuffer As Integer = 2

				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
					buffer = 0
				ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then
					buffer = 0
				ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week Then
					buffer = 0
				ElseIf Me.IsActivity Or Me.IsEvent Then
					buffer = 0
				ElseIf MainObject.SelectedItems.Contains(Me) Then
					buffer = 0					'Gravitybox.Controls.Schedule.HiliteSize
				Else
					buffer = 0
				End If

				'Calculate the number of icons that will fit vertically
				'If there is no room then skip out
				vertCount = (rectangle.Height - buffer) \ IconSize
				If vertCount = 0 Then vertCount = 1

				'Draw the appointment icons
				retval = 0
				top = rectangle.Top + buffer + 2
				left = rectangle.Left + MainObject.AppointmentBar.Size + 2 + retval
				height = IconSize

				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
					'Do Nothing
				ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull Then
					'Do Nothing
				ElseIf MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week Then
					'Do Nothing
				Else
					If rectangle.Left = 0 Then Return retval
				End If

				'Draw the Standard icons
				If Me.Alarm.IsArmed AndAlso Not (MainObject.ScheduleIcons.IconReminder Is Nothing) Then
					If Not DrawIcon(vertCount, column, left, top, rectangle, ii, retval, g, MainObject.ScheduleIcons.IconReminder) Then Return retval
				End If
				If MainObject.AppointmentCollection.IsRecurrence(Me) Then
					If (Me.RecurrenceStamp = Me.GetRecurrenceStamp) AndAlso Not (MainObject.ScheduleIcons.IconRecurrence Is Nothing) Then
						If Not DrawIcon(vertCount, column, left, top, rectangle, ii, retval, g, MainObject.ScheduleIcons.IconRecurrence) Then Return retval
					ElseIf (Me.RecurrenceStamp <> Me.GetRecurrenceStamp) AndAlso Not (MainObject.ScheduleIcons.IconRecurrenceBroken Is Nothing) Then
						If Not DrawIcon(vertCount, column, left, top, rectangle, ii, retval, g, MainObject.ScheduleIcons.IconRecurrenceBroken) Then Return retval
					End If
				End If
				If Me.IsFlagged AndAlso Not (MainObject.ScheduleIcons.IconFlag Is Nothing) Then
					If Not DrawIcon(vertCount, column, left, top, rectangle, ii, retval, g, MainObject.ScheduleIcons.IconFlag) Then Return retval
				End If

				'Draw the custom icons
				For Each iconItem In Me.IconCollection
					If Not DrawIcon(vertCount, column, left, top, rectangle, ii, retval, g, iconItem.Icon) Then
						'No more icons can be shown so skip out
						Return retval
					End If
				Next

				If retval = 0 Then
					Return retval
				Else
					Return retval + (IconRightBuffer * 2)
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function DrawIcon(ByVal vertCount As Integer, ByRef column As Integer, _
		 ByVal left As Integer, ByVal top As Integer, _
		 ByVal apptRectangle As Rectangle, ByRef drawIndex As Integer, _
		 ByRef leftMargin As Integer, ByVal g As Graphics, _
		 ByVal icon As System.Drawing.Icon) As Boolean

			Dim vertIndex As Integer
			Dim iconPT As Point
			Dim targetRect As Rectangle
			Dim iconWidth As Integer
			Dim iconHeight As Integer
			Dim scaled As Boolean = False

			'Calculate the icon left/top coordinates
			vertIndex = (drawIndex Mod vertCount)
			If vertIndex = 0 Then column += 1
			iconPT = New Point(left + ((column - 1) * IconSize), top + (vertIndex * IconSize))
			drawIndex += 1

			'Calculate the icon rectangle
			iconWidth = IconSize
			If iconPT.X + iconWidth > apptRectangle.Right Then
				iconWidth = apptRectangle.Right - iconPT.X
				scaled = True
			End If
			iconHeight = IconSize
			If iconPT.Y + iconHeight > apptRectangle.Bottom Then
				iconHeight = apptRectangle.Bottom - iconPT.Y
				scaled = True
			End If
			targetRect = New Rectangle(iconPT.X, iconPT.Y, iconWidth, iconHeight)

			'To many icons skip out!
			If iconWidth <= 0 Then Return False

			'If this is the start of the column then increment the running width
			If vertIndex = 0 Then leftMargin += iconWidth

			'Draw the actual icon
			'This is faster than 'DrawIcon'
			If scaled Then
				'Setup a clipping region to draw the icon
				Dim rgn As System.Drawing.Region = g.Clip
				g.SetClip(targetRect)
				Call g.DrawImageUnscaled(icon.ToBitmap, targetRect)
				g.Clip = rgn
			Else
				Call g.DrawImageUnscaled(icon.ToBitmap, targetRect)
			End If

			Return True

		End Function

		Friend Sub SetNewStartByCor(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal x As Integer, ByVal y As Integer)

			Try
				'Dim startTime As DateTime = MainObject.Visibility.GetTimeFromCor(x, y)
				'If startTime >= Me.EndTime Then startTime = DateAdd(DateInterval.Minute, -MainObject.TimeIncrement, Me.EndTime)
				'Dim additionalLength As Integer = GetIntlInteger(DateDiff(DateInterval.Minute, startTime, Me.StartTime))
				'Me.StartTime = startTime
				'Me.Length = Me.Length + additionalLength

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend Sub SetNewEndByCor(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal x As Integer, ByVal y As Integer)

			Try
				'Dim endTime As DateTime = MainObject.Visibility.GetTimeFromCor(x, y)
				'Me.Length = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, endTime)) + MainObject.TimeIncrement

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Function GetRoundRect(ByVal rect As Rectangle, ByVal flatBottom As Boolean, ByVal flatTop As Boolean) As System.Drawing.Drawing2D.GraphicsPath

			Try
				Dim gp As New System.Drawing.Drawing2D.GraphicsPath

				'Determine round and flat areas of the rectangle
				If flatTop And flatBottom Then
					Call gp.AddLine(rect.Left, rect.Top, rect.Left + rect.Width, rect.Top)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top, rect.Left + rect.Width, rect.Top + rect.Height)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top + rect.Height, rect.Left, rect.Top + rect.Height)
					Call gp.AddLine(rect.Left, rect.Top + rect.Height, rect.Left, rect.Top)
					Call gp.CloseFigure()

				ElseIf Not flatTop And flatBottom Then
					Call gp.AddLine(rect.Left + RoundRadius, rect.Top, rect.Left + rect.Width - RoundRadius, rect.Top)
					Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top, RoundRadius, RoundRadius, 270, 90)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top + RoundRadius, rect.Left + rect.Width, rect.Top + rect.Height)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top + rect.Height, rect.Left, rect.Top + rect.Height)
					Call gp.AddLine(rect.Left, rect.Top + rect.Height, rect.Left, rect.Top + RoundRadius)
					Call gp.AddArc(rect.Left, rect.Top, RoundRadius, RoundRadius, 180, 90)
					Call gp.CloseFigure()

				ElseIf flatTop And Not flatBottom Then
					Call gp.AddLine(rect.Left, rect.Top, rect.Left + rect.Width, rect.Top)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top, rect.Left + rect.Width, rect.Top + rect.Height - RoundRadius)
					Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top + rect.Height - RoundRadius, RoundRadius, RoundRadius, 0, 90)
					Call gp.AddLine(rect.Left + rect.Width - RoundRadius, rect.Top + rect.Height, rect.Left + RoundRadius, rect.Top + rect.Height)
					Call gp.AddArc(rect.Left, rect.Top + rect.Height - RoundRadius, RoundRadius, RoundRadius, 90, 90)
					Call gp.AddLine(rect.Left, rect.Top + rect.Height - RoundRadius, rect.Left, rect.Top)
					Call gp.CloseFigure()

				ElseIf Not flatTop And Not flatBottom Then
					Call gp.AddLine(rect.Left + RoundRadius, rect.Top, rect.Left + rect.Width - RoundRadius, rect.Top)
					Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top, RoundRadius, RoundRadius, 270, 90)
					Call gp.AddLine(rect.Left + rect.Width, rect.Top + RoundRadius, rect.Left + rect.Width, rect.Top + rect.Height - RoundRadius)
					Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top + rect.Height - RoundRadius, RoundRadius, RoundRadius, 0, 90)
					Call gp.AddLine(rect.Left + rect.Width - RoundRadius, rect.Top + rect.Height, rect.Left + RoundRadius, rect.Top + rect.Height)
					Call gp.AddArc(rect.Left, rect.Top + rect.Height - RoundRadius, RoundRadius, RoundRadius, 90, 90)
					Call gp.AddLine(rect.Left, rect.Top + rect.Height - RoundRadius, rect.Left, rect.Top + RoundRadius)
					Call gp.AddArc(rect.Left, rect.Top, RoundRadius, RoundRadius, 180, 90)
					Call gp.CloseFigure()

				End If

				Return gp

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

		Friend Function InViewport() As Boolean

      Dim retval As Boolean = False
      For Each rectInfo As AppointmentRectangleInfo In Me.Rectangles
        If Me.MainObject.ViewPort.IntersectsWith(rectInfo.Rect) Then
          retval = True
        End If
      Next
      Return retval

      'This method is used for optimization to know which appointments to draw
      Try

        'There is no verification routine for multi-day appointments right 
        'now. They may have an end time less than there start time, 
        'therefore no optimization, just paint them
        If (Me.DaySpan > 1) Then Return True

        'When printing everything is visible
        If (Me.MainObject.Visibility.IsPrinting) Then Return True

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            If Not MainObject.Visibility.IsTimeRangeVisible(Me.StartTime, Me.EndTime) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            If Not MainObject.Visibility.IsRoomVisible(Me.Room) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            If Not ProviderInViewPort() Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            If Not ResourceInViewPort() Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            If Not MainObject.Visibility.IsRoomVisible(Me.Room) Then Return False
            If Not MainObject.Visibility.IsTimeRangeVisible(Me.StartTime, Me.EndTime) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            If Not MainObject.Visibility.IsRoomVisible(Me.Room) Then Return False
            If Not ProviderInViewPort() Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            If Not ProviderInViewPort() Then Return False
            If Not MainObject.Visibility.IsTimeRangeVisible(Me.StartTime, Me.EndTime) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            If Not ProviderInViewPort() Then Return False
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            If Not RoomInViewPort() Then Return False
            If Not Me.Contains(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
            If Not Me.Contains(MainObject.MinDate, MainObject.MinDate.AddDays(DaysPerWeek - 1)) Then Return False
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
            Return True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            If Not ResourceInViewPort() Then Return False
            If Not MainObject.Visibility.IsTimeRangeVisible(Me.StartTime, Me.EndTime) Then Return False
            Return True
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

		Private Function ProviderInViewPort() As Boolean

			Try
				'When printing everything is visible
				If (Me.MainObject.Visibility.IsPrinting) Then Return True

				Dim provider As Gravitybox.Objects.Provider = Nothing
				Dim isVisible As Boolean = False
				For Each provider In Me.ProviderList
					If Not isVisible AndAlso MainObject.Visibility.IsProviderVisible(provider) Then isVisible = True
				Next
				Return isVisible

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function ResourceInViewPort() As Boolean

			Try
				'When printing everything is visible
				If (Me.MainObject.Visibility.IsPrinting) Then Return True

				Dim resource As Gravitybox.Objects.Resource = Nothing
				Dim isVisible As Boolean = False
				For Each resource In Me.ResourceList
					If Not isVisible AndAlso MainObject.Visibility.IsResourceVisible(resource) Then isVisible = True
				Next
				Return isVisible

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function RoomInViewPort() As Boolean

			Try
				Return MainObject.Visibility.IsRoomVisible(Me.Room)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "HitTests"

    Friend Function OverInfoBox(ByVal x As Integer, ByVal y As Integer) As Boolean

      Dim CurrentAppearance As AppointmentAppearance = Me.Appearance

      Try
        'Use the selected appearance object if need be
        Dim borderPenWidth As Integer = 1
        If (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance) AndAlso MainObject.SelectedItems.Contains(Me) Then
          CurrentAppearance = MainObject.SelectedAppointmentAppearance
          borderPenWidth = CurrentAppearance.BorderWidth
        ElseIf (MainObject.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.BorderOnly) AndAlso MainObject.SelectedItems.Contains(Me) Then
          borderPenWidth = 3
        End If

        'If there is a header and there is an info box...
        If Me.Header.HeaderType <> AppointmentHeader.HeaderTypeConstants.None Then
          If Not (Me.Header.Icon Is Nothing) Then

            Dim apptRect As AppointmentRectangleInfo
            Dim skew As Integer
            For Each apptRect In Me.Rectangles
              If CurrentAppearance.IsRound Then skew = (RoundRadius \ 2)
              If (apptRect.Rect.Right - 18 - skew <= x) AndAlso (x <= apptRect.Rect.Right - 2 - skew) Then
                If (apptRect.Rect.Top + 2 <= y) AndAlso (y <= apptRect.Rect.Top + 16) Then
                  Return True
                End If
              End If
            Next

          End If
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function OverTopResizeBorder(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal x As Integer, ByVal y As Integer) As Boolean

      Try
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            If Me.Rectangles.Count = 0 Then Return False
            Dim rectangle As Rectangle = Me.Rectangles(0).Rect
            Dim checkY As Integer = rectangle.Y
            If (checkY <= y) And (y <= (checkY + Gravitybox.Controls.Schedule.HiliteSize)) Then
              Return CBool((rectangle.Left <= x) AndAlso (x <= rectangle.Left + rectangle.Width))
            Else
              Return False
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            If Me.Rectangles.Count = 0 Then Return False
            Dim rectangle As Rectangle = Me.Rectangles(0).Rect
            Dim checkX As Integer = rectangle.X
            If (checkX <= x) And (x <= (checkX + Gravitybox.Controls.Schedule.HiliteSize)) Then
              Return CBool((rectangle.Top <= y) AndAlso (y <= rectangle.Top + rectangle.Height))
            Else
              Return False
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            'Do Nothing

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            'Do Nothing

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
            Return False

          Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
            'Do Nothing

          Case Else
            Call ErrorModule.ViewmodeErr()

        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function OverBottomResizeBorder(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal x As Integer, ByVal y As Integer) As Boolean

      Try
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            If Me.Rectangles.Count = 0 Then Return False
            Dim rectangle As Rectangle = Me.Rectangles(Me.Rectangles.Count - 1).Rect
            Dim checkY As Integer = rectangle.Y + rectangle.Height - Gravitybox.Controls.Schedule.HiliteSize
            If (checkY <= y) AndAlso (y <= (checkY + Gravitybox.Controls.Schedule.HiliteSize)) Then
              Return CBool((rectangle.Left <= x) AndAlso (x <= rectangle.Left + rectangle.Width))
            Else
              Return False
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            If Me.Rectangles.Count = 0 Then Return False
            Dim rectangle As Rectangle = Me.Rectangles(Me.Rectangles.Count - 1).Rect
            Dim checkX As Integer = rectangle.X + rectangle.Width - Gravitybox.Controls.Schedule.HiliteSize
            If (checkX <= x) AndAlso (x <= (checkX + Gravitybox.Controls.Schedule.HiliteSize)) Then
              Return CBool((rectangle.Top <= y) AndAlso (y <= rectangle.Top + rectangle.Height))
            Else
              Return False
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            'Do Nothing

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            'Do Nothing

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
            Return False

          Case Gravitybox.Controls.Schedule.ViewModeConstants.MonthFull
            Return False

          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Dispose"

		Private Sub Dispose() Implements IDisposable.Dispose
			Me.UnHookEvents()
			If Not (m_IconCollection Is Nothing) Then
				m_IconCollection.Clear()
			End If
			CType(m_Header, IDisposable).Dispose()
			m_Rectangles = Nothing
			m_MainObject = Nothing
		End Sub

#End Region

	End Class

End Namespace