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

Namespace Gravitybox.Objects

	Public Class AppointmentDialogSettings
		Inherits DialogSettingsBase

#Region "Class Members"

		Public Enum TimeDisplayConstants
			EndTime = 0
			Duration = 1
		End Enum

		Public Enum ListEditConstants
			Fixed = 0
			FreeForm = 1
		End Enum

		Protected Const m_def_AllowNavigate As Boolean = True
		Protected Const m_def_AllowFlag As Boolean = True
		Protected Const m_def_AllowRemove As Boolean = True
		Protected Const m_def_AllowNotes As Boolean = True
		Protected Const m_def_AllowRoom As Boolean = True
		Protected Const m_def_AllowDate As Boolean = True
		Protected Const m_def_AllowProvider As Boolean = True
		Protected Const m_def_AllowResource As Boolean = True
		Protected Const m_def_AllowCategory As Boolean = True
		Protected Const m_def_AllowPriority As Boolean = True
		Protected Const m_def_AllowAppointmentType As Boolean = True
		Protected Const m_def_AllowText As Boolean = True
		Protected Const m_def_AllowAlarm As Boolean = True
		Protected Const m_def_AllowTime As Boolean = True
		Protected Const m_def_AllowModal As Boolean = False
		Protected Const m_def_AllowSubject As Boolean = True
		Protected Const m_def_AllowMasterCategories As Boolean = True
		Protected Const m_def_AllowEvents As Boolean = True
		Protected Const m_def_AllowFiles As Boolean = True
		Protected Const m_def_CategoryEditMode As ListEditConstants = ListEditConstants.Fixed
		Protected Const m_def_EnforceBounds As Boolean = False
		Protected Const m_def_AllowRecurrence As Boolean = True
		Protected Const m_def_SubjectLength As Integer = 0
		Protected Const m_def_TextLength As Integer = 0
		Protected Const m_def_NotesLength As Integer = 0
		Protected Const m_def_SubjectPrompt As String = "Subject"
		Protected Const m_def_StartTimePrompt As String = "Start Time"
		Protected Const m_def_DurationPrompt As String = "Duration"
		Protected Const m_def_PriorityPrompt As String = "Priority"
		Protected Const m_def_EventPrompt As String = "All Day Event"
		Protected Const m_def_ReminderPrompt As String = "Reminder"
		Protected Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.FixedDialog
		Protected Shadows Const m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.CenterScreen
		Protected Shadows Const m_def_WindowText As String = "Appointment"
    Protected Shadows Const m_def_TimeDisplay As TimeDisplayConstants = TimeDisplayConstants.EndTime
    Protected Const m_def_TimeIncrement As Gravitybox.Controls.Schedule.TimeIncrementConstants = Controls.Schedule.TimeIncrementConstants.Minute30

		Protected m_AllowNavigate As Boolean = m_def_AllowNavigate
		Protected m_AllowFlag As Boolean = m_def_AllowFlag
		Protected m_AllowRemove As Boolean = m_def_AllowRemove
		Protected m_AllowNotes As Boolean = m_def_AllowNotes
		Protected m_AllowRoom As Boolean = m_def_AllowRoom
		Protected m_AllowDate As Boolean = m_def_AllowDate
		Protected m_AllowProvider As Boolean = m_def_AllowProvider
		Protected m_AllowResource As Boolean = m_def_AllowResource
		Protected m_AllowCategory As Boolean = m_def_AllowCategory
		Protected m_AllowPriority As Boolean = m_def_AllowPriority
		Protected m_AllowAppointmentType As Boolean = m_def_AllowAppointmentType
		Protected m_AllowText As Boolean = m_def_AllowText
		Protected m_AllowAlarm As Boolean = m_def_AllowAlarm
		Protected m_AllowTime As Boolean = m_def_AllowTime
		Protected m_AllowModal As Boolean = m_def_AllowModal
		Protected m_AllowSubject As Boolean = m_def_AllowSubject
		Protected m_AllowMasterCategories As Boolean = m_def_AllowMasterCategories
		Protected m_AllowEvents As Boolean = m_def_AllowEvents
		Protected m_AllowFiles As Boolean = m_def_AllowFiles
		Protected m_CategoryEditMode As ListEditConstants = m_def_CategoryEditMode
		Protected m_EnforceBounds As Boolean = m_def_EnforceBounds
		Protected m_AllowRecurrence As Boolean = m_def_AllowRecurrence
		Protected m_WarningText As String = ""
		Protected m_SubjectLength As Integer = m_def_SubjectLength
		Protected m_TextLength As Integer = m_def_TextLength
		Protected m_NotesLength As Integer = m_def_NotesLength
		Protected m_SubjectPrompt As String = m_def_SubjectPrompt
		Protected m_StartTimePrompt As String = m_def_StartTimePrompt
		Protected m_DurationPrompt As String = m_def_DurationPrompt
		Protected m_PriorityPrompt As String = m_def_PriorityPrompt
		Protected m_EventPrompt As String = m_def_EventPrompt
		Protected m_ReminderPrompt As String = m_def_ReminderPrompt
    Protected m_TimeDisplay As TimeDisplayConstants = m_def_TimeDisplay
    Protected m_TimeIncrement As Gravitybox.Controls.Schedule.TimeIncrementConstants = m_def_TimeIncrement

		Protected m_RecurrenceDialogSettings As New Gravitybox.Objects.RecurrenceDialogSettings

#End Region

#Region "Constructor"

		Public Sub New()
			MyBase.New()
			MyBase.WindowText = m_def_WindowText
			MyBase.StartPosition = m_def_StartPosition
			MyBase.Location = m_def_Location
			MyBase.Size = m_def_Size
			MyBase.OkButtonText = m_def_OkButtonText
			MyBase.CancelButtonText = m_def_CancelButtonText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			Me.Icon = New Icon(GetProjectFileAsStream("appointment.ico"))
		End Sub

		Friend Sub New(ByVal scheduleObject As Controls.Schedule)
			MyBase.WindowText = m_def_WindowText
			MyBase.StartPosition = m_def_StartPosition
			MyBase.Location = m_def_Location
			MyBase.Size = m_def_Size
			MyBase.OkButtonText = m_def_OkButtonText
			MyBase.CancelButtonText = m_def_CancelButtonText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			Me.Icon = New Icon(GetProjectFileAsStream("appointment.ico"))
			Me.AllowRemove = scheduleObject.AllowRemove
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines if navigation buttons are enabled to traverse the AppointmentCollection.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowNavigate), _
    Description("Determines if navigation buttons are enabled to traverse the AppointmentCollection.")> _
    Public Property AllowNavigate() As Boolean
      Get
        Return m_AllowNavigate
      End Get
      Set(ByVal Value As Boolean)
        m_AllowNavigate = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'IsFlagged' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowFlag), _
    Description("Determines if the appointment property value 'IsFlagged' may be edited.")> _
    Public Property AllowFlag() As Boolean
      Get
        Return m_AllowFlag
      End Get
      Set(ByVal Value As Boolean)
        m_AllowFlag = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if appointments may be removed from the dialog.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowRemove), _
    Description("Determines if appointments may be removed from the dialog.")> _
    Public Property AllowRemove() As Boolean
      Get
        Return m_AllowRemove
      End Get
      Set(ByVal Value As Boolean)
        m_AllowRemove = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'Notes' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowNotes), _
    Description("Determines if the appointment property value 'Notes' may be edited.")> _
    Public Property AllowNotes() As Boolean
      Get
        Return m_AllowNotes
      End Get
      Set(ByVal Value As Boolean)
        m_AllowNotes = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'Room' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowRoom), _
    Description("Determines if the appointment property value 'Room' may be edited.")> _
    Public Property AllowRoom() As Boolean
      Get
        Return m_AllowRoom
      End Get
      Set(ByVal Value As Boolean)
        m_AllowRoom = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'StartDate' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowDate), _
    Description("Determines if the appointment property value 'StartDate' may be edited.")> _
    Public Property AllowDate() As Boolean
      Get
        Return m_AllowDate
      End Get
      Set(ByVal Value As Boolean)
        m_AllowDate = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property collection 'ProviderList' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowProvider), _
    Description("Determines if the appointment property collection 'ProviderList' may be edited.")> _
    Public Property AllowProvider() As Boolean
      Get
        Return m_AllowProvider
      End Get
      Set(ByVal Value As Boolean)
        m_AllowProvider = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property collection 'ResourceList' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowResource), _
    Description("Determines if the appointment property collection 'ResourceList' may be edited.")> _
    Public Property AllowResource() As Boolean
      Get
        Return m_AllowResource
      End Get
      Set(ByVal Value As Boolean)
        m_AllowResource = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property collection 'CategoryList' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowCategory), _
    Description("Determines if the appointment property collection 'CategoryList' may be edited.")> _
    Public Property AllowCategory() As Boolean
      Get
        Return m_AllowCategory
      End Get
      Set(ByVal Value As Boolean)
        m_AllowCategory = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property priority may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowPriority), _
    Description("Determines if the appointment property priority may be edited.")> _
    Public Property AllowPriority() As Boolean
      Get
        Return m_AllowPriority
      End Get
      Set(ByVal Value As Boolean)
        m_AllowPriority = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property AppointmentType may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowAppointmentType), _
    Description("Determines if the appointment property AppointmentType may be edited.")> _
    Public Property AllowAppointmentType() As Boolean
      Get
        Return m_AllowAppointmentType
      End Get
      Set(ByVal Value As Boolean)
        m_AllowAppointmentType = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'Text' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowText), _
    Description("Determines if the appointment property value 'Text' may be edited.")> _
    Public Property AllowText() As Boolean
      Get
        Return m_AllowText
      End Get
      Set(ByVal Value As Boolean)
        m_AllowText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property object 'Alarm' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowAlarm), _
    Description("Determines if the appointment property object 'Alarm' may be edited.")> _
    Public Property AllowAlarm() As Boolean
      Get
        Return m_AllowAlarm
      End Get
      Set(ByVal Value As Boolean)
        m_AllowAlarm = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'StartTime' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowTime), _
    Description("Determines if the appointment property value 'StartTime' may be edited.")> _
    Public Property AllowTime() As Boolean
      Get
        Return m_AllowTime
      End Get
      Set(ByVal Value As Boolean)
        m_AllowTime = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines of the dialog is displayed modal.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowModal), _
    Description("Determines of the dialog is displayed modal.")> _
    Public Property AllowModal() As Boolean
      Get
        Return m_AllowModal
      End Get
      Set(ByVal Value As Boolean)
        m_AllowModal = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'Subject' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowSubject), _
    Description("Determines if the appointment property value 'Subject' may be edited.")> _
    Public Property AllowSubject() As Boolean
      Get
        Return m_AllowSubject
      End Get
      Set(ByVal Value As Boolean)
        m_AllowSubject = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the category edit dialog displayed from this dialog has a 'Master Categories' button.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowMasterCategories), _
    Description("Determines if the category edit dialog displayed from this dialog has a 'Master Categories' button.")> _
    Public Property AllowMasterCategories() As Boolean
      Get
        Return m_AllowMasterCategories
      End Get
      Set(ByVal Value As Boolean)
        m_AllowMasterCategories = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property value 'IsEvent' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowEvents), _
    Description("Determines if the appointment property value 'IsEvent' may be edited.")> _
    Public Property AllowEvents() As Boolean
      Get
        Return m_AllowEvents
      End Get
      Set(ByVal Value As Boolean)
        m_AllowEvents = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the appointment property object 'FileCollection' may be edited.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowFiles), _
    Description("Determines if the appointment property object 'FileCollection' may be edited.")> _
    Public Property AllowFiles() As Boolean
      Get
        Return m_AllowFiles
      End Get
      Set(ByVal Value As Boolean)
        m_AllowFiles = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the mode of category selection by the user.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_CategoryEditMode), _
    Description("Determines the mode of category selection by the user.")> _
    Public Property CategoryEditMode() As ListEditConstants
      Get
        Return m_CategoryEditMode
      End Get
      Set(ByVal Value As ListEditConstants)
        m_CategoryEditMode = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the date and times specified by the user must be in the schedule's min-max range.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_EnforceBounds), _
    Description("Determines if the date and times specified by the user must be in the schedule's min-max range.")> _
    Public Property EnforceBounds() As Boolean
      Get
        Return m_EnforceBounds
      End Get
      Set(ByVal Value As Boolean)
        m_EnforceBounds = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the specified appointment may be put into a recurrence pattern.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowRecurrence), _
    Description("Determines if the specified appointment may be put into a recurrence pattern.")> _
    Public Property AllowRecurrence() As Boolean
      Get
        Return m_AllowRecurrence
      End Get
      Set(ByVal Value As Boolean)
        m_AllowRecurrence = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text to be displayed as a warning at the top of the screen.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("Determines the text to be displayed as a warning at the top of the screen.")> _
    Public Property WarningText() As String
      Get
        Return m_WarningText
      End Get
      Set(ByVal Value As String)
        m_WarningText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the 'Subject' textbox's maximum length.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_SubjectLength), _
    Description("Determines the 'Subject' textbox's maximum length.")> _
    Public Property SubjectLength() As Integer
      Get
        Return m_SubjectLength
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        m_SubjectLength = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the 'Text' textbox's maximum length.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_TextLength), _
    Description("Determines the 'Text' textbox's maximum length.")> _
    Public Property TextLength() As Integer
      Get
        Return m_TextLength
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        m_TextLength = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the 'Notes' textbox's maximum length.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_NotesLength), _
    Description("Determines the 'Notes' textbox's maximum length.")> _
    Public Property NotesLength() As Integer
      Get
        Return m_NotesLength
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        m_NotesLength = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Subject' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Subject"), _
    Description("Determines the prompt for the 'Subject' property.")> _
    Public Property SubjectPrompt() As String
      Get
        Return m_SubjectPrompt
      End Get
      Set(ByVal Value As String)
        m_SubjectPrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'StartTime' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Start Time"), _
    Description("Determines the prompt for the 'StartTime' property.")> _
    Public Property StartTimePrompt() As String
      Get
        Return m_StartTimePrompt
      End Get
      Set(ByVal Value As String)
        m_StartTimePrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the appointment 'Duration'.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Start Time"), _
    Description("Determines the prompt for the appointment 'Duration'.")> _
    Public Property DurationPrompt() As String
      Get
        Return m_DurationPrompt
      End Get
      Set(ByVal Value As String)
        m_DurationPrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the appointment 'Priority'.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Start Time"), _
    Description("Determines the prompt for the appointment 'Priority'.")> _
    Public Property PriorityPrompt() As String
      Get
        Return m_PriorityPrompt
      End Get
      Set(ByVal Value As String)
        m_PriorityPrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'IsEvent' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("All Day Event"), _
    Description("Determines the prompt for the 'IsEvent' property.")> _
    Public Property EventPrompt() As String
      Get
        Return m_EventPrompt
      End Get
      Set(ByVal Value As String)
        m_EventPrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Reminder' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Reminder"), _
    Description("Determines the prompt for the 'Reminder' property.")> _
    Public Property ReminderPrompt() As String
      Get
        Return m_ReminderPrompt
      End Get
      Set(ByVal Value As String)
        m_ReminderPrompt = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt strings used in the recurrence dialog.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the prompt strings used in the recurrence dialog.")> _
    Public Property RecurrenceDialogSettings() As Gravitybox.Objects.RecurrenceDialogSettings
      Get
        Return m_RecurrenceDialogSettings
      End Get
      Set(ByVal Value As Gravitybox.Objects.RecurrenceDialogSettings)
        If Value Is Nothing Then Value = New Gravitybox.Objects.RecurrenceDialogSettings
        m_RecurrenceDialogSettings = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines how the user will set an appointment's length.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines how the user will set an appointment's length.")> _
    Public Property TimeDisplay() As TimeDisplayConstants
      Get
        Return m_TimeDisplay
      End Get
      Set(ByVal Value As TimeDisplayConstants)
        m_TimeDisplay = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the increment into which to break an hour.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the increment into which to break an hour.")> _
    Public Property TimeIncrement() As Gravitybox.Controls.Schedule.TimeIncrementConstants
      Get
        Return m_TimeIncrement
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.TimeIncrementConstants)
        m_TimeIncrement = Value
      End Set
    End Property

#End Region

	End Class

End Namespace