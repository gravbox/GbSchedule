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
Imports System.ComponentModel
Imports System.Threading
Imports Gravitybox.Objects.EventArgs
Imports Gravitybox.Objects
Imports System.ComponentModel.Design.Serialization
Imports System.Runtime.CompilerServices

Namespace Gravitybox.Controls

	'LicenseProvider(GetType(licX.LicXLicenseProvider))> _

  ''' <summary>
  ''' This component is used to display appointment information or schedules
  ''' </summary>
	<Designer(GetType(Gravitybox.Design.Designers.ScheduleControlDesigner)), _
	ToolboxItem(True), _
	ToolboxBitmap(GetType(Gravitybox.Controls.Schedule)), _
	DesignTimeVisible(True), _
	Browsable(True)> _
 Public Class Schedule
		Inherits System.Windows.Forms.UserControl
		Implements System.Runtime.Serialization.IDeserializationCallback

		'Friend ComponentLicense As licX.LicXLicense

#Region " Windows Form Designer generated code "

		Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
			MyBase.OnLoad(e)
		End Sub

		Public Sub New()
			Me.New(True)
		End Sub

		Friend Sub New(ByVal useLicense As Boolean)
			MyBase.New()

			Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

			'This call is required by the Windows Form Designer.
			InitializeComponent()

#If VS2005 Then
            'Me.ToolTip1.IsBalloon = True
#End If

			'Do not show at design time
			If Me.DesignMode Then
				useLicense = False
			End If

			ErrorModule.SetParentComponent(Me)

			SetStyle(ControlStyles.UserPaint, True)
			SetStyle(ControlStyles.AllPaintingInWmPaint, True)
			SetStyle(ControlStyles.DoubleBuffer, True)

			'Validate the License
			Try
				If useLicense Then

					'#If SHAREWARE = 1 Then
					'					'If this is shareware then ALWAYS show the dialog
					'					Call Me.Dialogs.ShowAboutDialog(True)
					'#Else
					'					If (Environment.Version.Major < 2) Then
					'						'If this is software then ONLY show the dialog if there is no license
					'						ComponentLicense = CType(LicenseManager.Validate(GetType(Gravitybox.Controls.Schedule), Me), licX.LicXLicense)

					'						If ComponentLicense.IsEvaluation Then
					'							Call Me.Dialogs.ShowAboutDialog(True)
					'						End If
					'					End If
					'#End If
				End If
			Catch ex As Exception
				'MsgBox(ex.ToString)
				Dialogs.ShowLicenseDialog()
			End Try

			'Add any initialization after the InitializeComponent() call
			Try
				Call Schedule()
			Catch ex As Exception
				MsgBox(ex.ToString, MsgBoxStyle.Information, "Error!")
			End Try

			Try
				Canvas = New Gravitybox.Drawing.DrawScheduleMain(Me)
			Catch ex As Exception
				MsgBox(ex.ToString, MsgBoxStyle.Information, "Error!")
			End Try

			Try
				m_ScheduleIcons = New ScheduleIcons(Me)
			Catch ex As Exception
				MsgBox(ex.ToString, MsgBoxStyle.Information, "Error!")
			End Try

			Try
				m_DefaultIcons = New DefaultIcons(Me)
			Catch ex As Exception
				MsgBox(ex.ToString, MsgBoxStyle.Information, "Error!")
			End Try

			Me.ToolTip1.AutoPopDelay = m_ToolTipAutoPopDelay
			Me.ToolTip1.InitialDelay = m_ToolTipInitialDelay
			Me.ToolTip1.ShowAlways = m_ToolTipShowAlways
			Me.ToolTip1.ReshowDelay = m_ToolTipReshowDelay

			'Need to know when this collection is cleared
			AddHandler m_SelectedItems.ClearComplete, AddressOf SelectedItemsClearComplete
			AddHandler AppointmentCollection.ClearComplete, AddressOf SelectedItemsClearComplete
			AddHandler AppointmentCollection.InternalAfterRemove, AddressOf AppointmentRemoveHandler

		End Sub

		'UserControl1 overrides dispose to clean up the component list.
		Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)

			If disposing Then

				If Not Me.HasDisposed Then
					Me.HasDisposed = True

					m_DefaultAppointmentAppearance = Nothing
					m_DefaultAppointmentHeaderAppearance = Nothing
					m_Appearance = Nothing
					m_SelectedAppointmentAppearance = Nothing
					m_SelectedAppointmentHeaderAppearance = Nothing
					m_EventHeader = Nothing
					LockKeys.Clear()
					LockKeys = Nothing

					m_AppointmentCollection.Dispose()
					m_RoomCollection.Dispose()
					m_CategoryCollection.Dispose()
					m_PriorityCollection.Dispose()
					m_AppointmentTypeCollection.Dispose()
					m_ProviderCollection.Dispose()
					m_ResourceCollection.Dispose()
					m_AppearanceCollection.Dispose()
					m_Visibility.Dispose()
					m_ColumnHeader.Dispose()
					m_RowHeader.Dispose()
					m_TimeMarker.Dispose()
					m_ColoredAreaCollection.Dispose()
					m_NoDropAreaCollection.Dispose()
					m_Dialogs.Dispose()
					m_Selector.Dispose()
					m_SelectedItems.Dispose()

					m_RoomCollection = Nothing
					m_CategoryCollection = Nothing
					m_PriorityCollection = Nothing
					m_AppointmentTypeCollection = Nothing
					m_ProviderCollection = Nothing
					m_ResourceCollection = Nothing
					m_AppearanceCollection = Nothing
					m_Visibility = Nothing
					m_ColumnHeader = Nothing
					m_RowHeader = Nothing
					m_TimeMarker = Nothing
					m_ColoredAreaCollection = Nothing
					m_NoDropAreaCollection = Nothing
					m_Dialogs = Nothing
					m_Selector = Nothing
					m_SelectedItems = Nothing
					m_AppointmentCollection = Nothing
					m_RecurrenceCollection = Nothing
					m_ScheduleIcons = Nothing
					m_DefaultIcons = Nothing
					m_DataSource = Nothing
					m_DataBindings = Nothing
				End If

				If Not (components Is Nothing) Then
					components.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
			GC.Collect()

		End Sub

		'Required by the Windows Form Designer
		Private components As System.ComponentModel.IContainer

		'NOTE: The following procedure is required by the Windows Form Designer
		'It can be modified using the Windows Form Designer.  
		'Do not modify it using the code editor.
		Friend WithEvents HScroll1 As System.Windows.Forms.HScrollBar
		Friend WithEvents VScroll1 As System.Windows.Forms.VScrollBar
		Friend WithEvents TimerDrag As System.Windows.Forms.Timer
		Friend WithEvents lblResize As System.Windows.Forms.Label
		Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
		Friend WithEvents lblToolTip As System.Windows.Forms.Label
		Friend WithEvents TimerAppointmentStart As System.Windows.Forms.Timer
		Friend WithEvents txtBox As System.Windows.Forms.TextBox
		Friend WithEvents TimerEdit As System.Windows.Forms.Timer
		'Friend WithEvents LicXLicenseComponent1 As licX.LicXLicenseComponent
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container
			Me.HScroll1 = New System.Windows.Forms.HScrollBar
			Me.VScroll1 = New System.Windows.Forms.VScrollBar
			Me.TimerDrag = New System.Windows.Forms.Timer(Me.components)
			Me.lblResize = New System.Windows.Forms.Label
			Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
			Me.lblToolTip = New System.Windows.Forms.Label
			Me.TimerAppointmentStart = New System.Windows.Forms.Timer(Me.components)
			Me.txtBox = New System.Windows.Forms.TextBox
			Me.TimerEdit = New System.Windows.Forms.Timer(Me.components)
			'Me.LicXLicenseComponent1 = New licX.LicXLicenseComponent
			Me.SuspendLayout()
			'
			'HScroll1
			'
			Me.HScroll1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
			Me.HScroll1.Location = New System.Drawing.Point(16, 16)
			Me.HScroll1.Name = "HScroll1"
			Me.HScroll1.Size = New System.Drawing.Size(56, 16)
			Me.HScroll1.TabIndex = 2
			'
			'VScroll1
			'
			Me.VScroll1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
			Me.VScroll1.Location = New System.Drawing.Point(112, 8)
			Me.VScroll1.Name = "VScroll1"
			Me.VScroll1.Size = New System.Drawing.Size(16, 40)
			Me.VScroll1.TabIndex = 3
			'
			'TimerDrag
			'
			Me.TimerDrag.Interval = 200
			'
			'lblResize
			'
			Me.lblResize.BackColor = System.Drawing.Color.Black
			Me.lblResize.Location = New System.Drawing.Point(16, 64)
			Me.lblResize.Name = "lblResize"
			Me.lblResize.Size = New System.Drawing.Size(40, 24)
			Me.lblResize.TabIndex = 5
			Me.lblResize.Visible = False
			'
			'ToolTip1
			'
			Me.ToolTip1.ShowAlways = True
			'
			'lblToolTip
			'
			Me.lblToolTip.AutoSize = True
			Me.lblToolTip.BackColor = System.Drawing.SystemColors.Info
			Me.lblToolTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblToolTip.ForeColor = System.Drawing.SystemColors.InfoText
			Me.lblToolTip.Location = New System.Drawing.Point(16, 40)
			Me.lblToolTip.Name = "lblToolTip"
			Me.lblToolTip.Size = New System.Drawing.Size(74, 15)
			Me.lblToolTip.TabIndex = 6
			Me.lblToolTip.Text = "ToolTip Label"
			Me.lblToolTip.Visible = False
			'
			'TimerAppointmentStart
			'
			Me.TimerAppointmentStart.Enabled = True
			Me.TimerAppointmentStart.Interval = 5000
			'
			'txtBox
			'
			Me.txtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.txtBox.Location = New System.Drawing.Point(72, 64)
			Me.txtBox.Multiline = True
			Me.txtBox.Name = "txtBox"
			Me.txtBox.Size = New System.Drawing.Size(64, 16)
			Me.txtBox.TabIndex = 7
			Me.txtBox.Visible = False
			'
			'TimerEdit
			'
			Me.TimerEdit.Interval = 400
			'
			'LicXLicenseComponent1
			'
			'Me.LicXLicenseComponent1.ContactUrl = "http://www.gravitybox.com/company/contact.htm"
			'Me.LicXLicenseComponent1.ExpirationDate = New Date(CType(0, Long))
			'Me.LicXLicenseComponent1.MasterLicensePassword = "q1a2z3"
			'Me.LicXLicenseComponent1.NagDuringEvaluation = False
			'Me.LicXLicenseComponent1.ProductName = "Schedule.NET"
			'Me.LicXLicenseComponent1.VendorName = "Gravitybox Software"
			'
			'Schedule
			'
			Me.AllowDrop = True
			Me.Controls.Add(Me.txtBox)
			Me.Controls.Add(Me.lblToolTip)
			Me.Controls.Add(Me.lblResize)
			Me.Controls.Add(Me.VScroll1)
			Me.Controls.Add(Me.HScroll1)
			Me.Name = "Schedule"
			Me.Size = New System.Drawing.Size(160, 104)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

#End Region

#Region "Class Members"

		''' <summary>
		''' This enumeration is used to when setting the type resizing allowed
		''' </summary>
		Public Enum AppointmentResizingConstants As Integer
			None = 0
			StartTime = 1
			Length = 2
			All = 3
		End Enum

		Public Enum ThemeConstants
			Office2003 = 0
			Office2007 = 1
			Energy = 2
			Olive = 3
			Sunny = 4
		End Enum

		'Order: Date/Room/Provider/Time
		''' <summary>
		''' This enumeration is used to set the viewmode property
		''' </summary>
		Public Enum ViewModeConstants As Integer
			''' <summary>
			''' Display dates as the top headers and times as the left headers.
			''' </summary>
			<Description("Display dates as the top headers and times as the left headers.")> _
			DayTopTimeLeft = 0
			''' <summary>
			''' Display dates as the top headers and rooms as the left headers.
			''' </summary>
			<Description("Display dates as the top headers and rooms as the left headers.")> _
			DayTopRoomLeft = 1
			''' <summary>
			''' Display dates as the top headers and providers as the left headers.
			''' </summary>
			<Description("Display dates as the top headers and providers as the left headers.")> _
			DayTopProviderLeft = 2
			''' <summary>
			''' Display times as the top headers and dates as the left headers.
			''' </summary>
			<Description("Display times as the top headers and dates as the left headers.")> _
			DayLeftTimeTop = 3
			''' <summary>
			''' Display rooms as the top headers and dates as the left headers.
			''' </summary>
			<Description("Display rooms as the top headers and dates as the left headers.")> _
			DayLeftRoomTop = 4
			''' <summary>
			''' Display providers as the top headers and dates as the left headers.
			''' </summary>
			<Description("Display providers as the top headers and dates as the left headers.")> _
			DayLeftProviderTop = 5
			''' <summary>
			''' Display dates and rooms as the top headers and times as the left headers.
			''' </summary>
			<Description("Display dates and rooms as the top headers and times as the left headers.")> _
			DayRoomTopTimeLeft = 6
			''' <summary>
			''' Display times as the top headers and dates and rooms as the left headers.
			''' </summary>
			<Description("Display times as the top headers and dates and rooms as the left headers.")> _
			DayRoomLeftTimeTop = 7
			''' <summary>
			''' Display rooms as the top headers and times as the left headers.
			''' </summary>
			<Description("Display rooms as the top headers and times as the left headers.")> _
			RoomTopTimeLeft = 8
			''' <summary>
			''' Display rooms as the top headers and providers as the left headers.
			''' </summary>
			<Description("Display rooms as the top headers and providers as the left headers.")> _
			RoomTopProviderLeft = 9
			''' <summary>
			''' Display times as the top headers and rooms as the left headers.
			''' </summary>
			<Description("Display times as the top headers and rooms as the left headers.")> _
			RoomLeftTimeTop = 10
			''' <summary>
			''' Display providers as the top headers and rooms as the left headers.
			''' </summary>
			<Description("Display providers as the top headers and rooms as the left headers.")> _
			RoomLeftProviderTop = 11
			''' <summary>
			''' Display times as the top headers and providers as the left headers.
			''' </summary>
			<Description("Display times as the top headers and providers as the left headers.")> _
			ProviderLeftTimeTop = 12
			''' <summary>
			''' Display providers as the top headers and times as the left headers.
			''' </summary>
			<Description("Display providers as the top headers and times as the left headers.")> _
			ProviderTopTimeLeft = 13
			''' <summary>
			''' Display as a month calendar with 6 columns.
			''' </summary>
			<Description("Display as a month calendar with 6 columns.")> _
			Month = 14
			''' <summary>
			''' Display providers as the top headers and dates and time as the left headers.
			''' </summary>
			<Description("Display providers as the top headers and dates and time as the left headers.")> _
			DayTimeLeftProviderTop = 15
			''' <summary>
			''' Display rooms as the top headers and dates and time as the left headers.
			''' </summary>
			<Description("Display rooms as the top headers and dates and time as the left headers.")> _
			DayTimeLeftRoomTop = 16
			''' <summary>
			''' Display as a week calendar, days stacked in two columns.
			''' </summary>
			<Description("Display as a week calendar, days stacked in two columns.")> _
			Week = 17
			''' <summary>
			''' Display as a month calendar with 7 columns.
			''' </summary>
			<Description("Display as a month calendar with 7 columns.")> _
			MonthFull = 18
			''' <summary>
			''' Display resources as the top headers and times as the left headers.
			''' </summary>
			<Description("Display resources as the top headers and times as the left headers.")> _
			ResourceTopTimeLeft = 19
			''' <summary>
			''' Display resources as the left headers and times as the top headers.
			''' </summary>
			<Description("Display resources as the left headers and times as the top headers.")> _
			ResourceLeftTimeTop = 20
			''' <summary>
			''' Display resources as the top headers and dates as the left headers.
			''' </summary>
			<Description("Display resources as the top headers and dates as the left headers.")> _
			DayLeftResourceTop = 21
			'#If DAYTIMETOP = 1 Then
			'      DayTimeTopRoomLeft = 15
			'#End If
			''' <summary>
			''' Display dates and providers as the top headers and time as the left headers.
			''' </summary>
			<Description("Display dates and providers as the top headers and time as the left headers.")> _
			DayProviderLeftTimeTop = 22
			''' <summary>
			''' Display dates and providers as the left headers and time as the top headers.
			''' </summary>
			<Description("Display dates and providers as the left headers and time as the top headers.")> _
			DayProviderTopTimeLeft = 23

		End Enum

		''' <summary>
		''' This enumeration is used when setting the time increment for the schedule
		''' </summary>
		Public Enum TimeIncrementConstants As Integer
			Minute01 = 1
			Minute02 = 2
			Minute03 = 3
			Minute04 = 4
			Minute05 = 5
			Minute06 = 6
			Minute10 = 10
			Minute12 = 12
			Minute15 = 15
			Minute20 = 20
			Minute30 = 30
			Minute60 = 60
		End Enum

		''' <summary>
		''' This enumeration is used when setting the clock of the schedule either 12 or 24 hour.
		''' </summary>
		Public Enum ClockSettingConstants As Integer
			Clock12 = 0
			Clock24 = 1
		End Enum

		''' <summary>
		''' This enumeration is used to set the display of colored bars for appointments and the schedule.
		''' </summary>
		Public Enum AppointmentBarConstants As Integer
			None = 0
			UserDrawn = 1
			Category = 2
			Provider = 3
			Resource = 4
		End Enum

		''' <summary>
		''' This enumeration is used to control the display of the left time margin.
		''' </summary>
		Public Enum MinutesShownConstants As Integer
			All = 0
			FirstOnly = 1
			Normal = 2
		End Enum

		''' <summary>
		''' This enumeration is used to control the look-and-feel of conflicting appointments.
		''' </summary>
		Public Enum ConflictDisplayConstants As Integer
			Overlap = 0
			SideBySide = 1
			Stagger = 2
		End Enum

		''' <summary>
		''' This enumeration is used to control the look-and-feel of the selected appointment(s).
		''' </summary>
		Public Enum SelectionTypeConstants
			None = 0
			BorderOnly = 1
			SelectedAppearance = 2
		End Enum

		''' <summary>
		''' This enumeration is used to control the error handling of the component
		''' </summary>
		Public Enum ErrorHandlingConstants
			Normal = 0
			Advanced = 1
			Ignore = 2
		End Enum

		'Internal Constants
		Private Const ResizeBuffer As Integer = 4
		Friend Const MinRowColSize As Integer = 5
		Friend Const HiliteSize As Integer = 5
		Private Const DragScrollMargin As Integer = 15

		'Property Defaults
		Private Const m_def_AllowCopy As Boolean = True
		Private Const m_def_DayLength As Integer = 24
		Private Const m_def_StartTime As DateTime = PivotTime
		Private Const m_def_TimeIncrement As TimeIncrementConstants = TimeIncrementConstants.Minute30
		Private ReadOnly m_def_BlockoutColor As Color = Color.Black
		Private Const m_def_AppointmentResizing As AppointmentResizingConstants = AppointmentResizingConstants.All
		Private Const m_def_AutoRedraw As Boolean = True
		Private Const m_def_AllowAdd As Boolean = True
		Private Const m_def_AllowMove As Boolean = True
		Private Const m_def_MinDate As DateTime = #1/1/2004#
		Private Const m_def_MaxDate As DateTime = #1/10/2004#
		Private Const m_def_HeaderDateFormat As String = DefaultDateFormat
		Private Const m_def_HeaderTimeFormat As String = DefaultClockSetting12Hour
		Private Const m_def_AllowRemove As Boolean = True
		Private Const m_def_ViewMode As ViewModeConstants = ViewModeConstants.DayTopTimeLeft
		Private Const m_def_AllowInPlaceEdit As Boolean = True
		Private Const m_def_FirstDayOfWeek As DayOfWeek = DayOfWeek.Sunday
		Private Const m_def_AppointmentSpace As Integer = 8
		Private ReadOnly m_def_ClockSetting As ClockSettingConstants = ClockSettingConstants.Clock12
		Private ReadOnly m_def_MinutesShown As MinutesShownConstants = MinutesShownConstants.FirstOnly
		Private Const m_def_ScrollBars As System.Windows.Forms.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Private Const m_def_AllowSelector As Boolean = True
		Private Const m_def_AllowEvents As Boolean = True
		Private Const m_def_AllowGrid As Boolean = True
		Private Const m_def_AllowForeignDrops As Boolean = True
		Private Const m_def_AllowDragTip As Boolean = True
		'Private Const m_def_EnforceBounds As Boolean = True
		Private Const m_def_MultiSelect As Boolean = False
		Private Const m_def_ConflictDisplay As ConflictDisplayConstants = ConflictDisplayConstants.SideBySide
        Private Const m_def_ToolTipAutoPopDelay As Integer = 5000
#If VS2005 Then
        Private Const m_def_ToolTipIsBalloon As Boolean = True
#End If
		Private Const m_def_ToolTipInitialDelay As Integer = 500
		Private Const m_def_ToolTipShowAlways As Boolean = True
		Private Const m_def_ToolTipReshowDelay As Integer = 100
		Private Const m_def_UseDefaultAppearances As Boolean = True
		Private Const m_def_ErrorHanding As ErrorHandlingConstants = ErrorHandlingConstants.Advanced
		Private Const m_def_UseColumnBars As Boolean = False
		Private Const m_def_UseDefaultDrawnHeaders As Boolean = True
		Private Const m_def_UseRoomColorHeader As Boolean = False
		Private Const m_def_UseResourceColorHeader As Boolean = False
		Private Const m_def_DynamicScroll As Boolean = True

		'Property Variables
		Protected m_AllowCopy As Boolean = m_def_AllowCopy
		Protected m_DayLength As Integer = m_def_DayLength
		Protected m_StartTime As DateTime = m_def_StartTime
		Protected m_TimeIncrement As TimeIncrementConstants = m_def_TimeIncrement
		Protected m_AppointmentTimeIncrement As TimeIncrementConstants = m_def_TimeIncrement
		Protected m_BlockoutColor As Color = m_def_BlockoutColor
		Protected m_AppointmentResizing As AppointmentResizingConstants = m_def_AppointmentResizing
		Protected m_SelectedItem As Appointment = Nothing
		Protected m_AutoRedraw As Boolean = m_def_AutoRedraw
		Protected m_AllowAdd As Boolean = m_def_AllowAdd
		Protected m_AllowMove As Boolean = m_def_AllowMove
		Protected m_MinDate As DateTime = m_def_MinDate
		Protected m_MaxDate As DateTime = m_def_MaxDate
		Protected m_HeaderDateFormat As String = m_def_HeaderDateFormat
		Protected m_HeaderTimeFormat As String = m_def_HeaderTimeFormat
		Protected m_AllowRemove As Boolean = m_def_AllowRemove
		Protected m_ViewMode As ViewModeConstants = m_def_ViewMode
		Protected m_AllowInPlaceEdit As Boolean = m_def_AllowInPlaceEdit
		Protected m_FirstDayOfWeek As DayOfWeek = m_def_FirstDayOfWeek
		Protected m_AppointmentSpace As Integer = m_def_AppointmentSpace
		Protected m_AppointmentBar As ScheduleBar = New ScheduleBar(Me)
		Protected m_TimeBar As ScheduleBar = New ScheduleBar(Me)
		Protected m_ClockSetting As ClockSettingConstants = m_def_ClockSetting
		Protected m_MinutesShown As MinutesShownConstants = m_def_MinutesShown
		Protected m_ScrollBars As System.Windows.Forms.ScrollBars = m_def_ScrollBars
		Protected m_AllowSelector As Boolean = m_def_AllowSelector
		Protected m_AllowEvents As Boolean = m_def_AllowEvents
		Protected m_AllowGrid As Boolean = m_def_AllowGrid
		Protected m_AllowForeignDrops As Boolean = m_def_AllowForeignDrops
		Protected m_AllowDragTip As Boolean = m_def_AllowDragTip
		'Protected m_EnforceBounds As Boolean = m_def_EnforceBounds
		Protected m_MultiSelect As Boolean = m_def_MultiSelect
		Protected m_ConflictDisplay As ConflictDisplayConstants = m_def_ConflictDisplay
		Protected m_DefaultAppointmentAppearance As New AppointmentAppearance
		Protected m_DefaultAppointmentHeaderAppearance As New AppointmentHeaderAppearance
		Protected m_Appearance As New GridAppearance
		Protected m_SelectedAppointmentAppearance As New AppointmentAppearance
		Protected m_SelectedAppointmentHeaderAppearance As New AppointmentHeaderAppearance
		Protected m_SelectionType As SelectionTypeConstants = SelectionTypeConstants.BorderOnly
		Protected m_EventHeader As New Gravitybox.Objects.EventHeader
		Protected LockKeys As New ArrayList
		Protected m_SafeRedraw As Boolean = True
        Protected m_ToolTipAutoPopDelay As Integer = m_def_ToolTipAutoPopDelay
#If VS2005 Then
        Protected m_ToolTipIsBalloon As Boolean = m_def_ToolTipIsBalloon
#End If
		Protected m_ToolTipInitialDelay As Integer = m_def_ToolTipInitialDelay
		Protected m_ToolTipShowAlways As Boolean = m_def_ToolTipShowAlways
		Protected m_ToolTipReshowDelay As Integer = m_def_ToolTipReshowDelay
		Protected m_UseDefaultDrawnHeaders As Boolean = m_def_UseDefaultDrawnHeaders
		Protected m_UseRoomColorHeader As Boolean = m_def_UseRoomColorHeader
		Protected m_UseResourceColorHeader As Boolean = m_def_UseResourceColorHeader
		Protected m_DynamicScroll As Boolean = m_def_DynamicScroll

		'Public Collections/Objects
		Private m_AppointmentCollection As New AppointmentCollection(Me)
		Private m_RecurrenceCollection As New RecurrenceCollection
		Private m_RoomCollection As New RoomCollection(Me)
		Private m_CategoryCollection As New CategoryCollection(Me)
		Private m_PriorityCollection As New PriorityCollection(Me)
		Private m_AppointmentTypeCollection As New AppointmentTypeCollection(Me)
		Private m_ProviderCollection As New ProviderCollection(Me)
		Private m_ResourceCollection As New ResourceCollection(Me)
		Private m_AppearanceCollection As New AppearanceCollection(Me)
		Private m_Visibility As New ScheduleVisibility(Me)
		Private WithEvents m_ColumnHeader As New Objects.Header(Me, True)
		Private WithEvents m_RowHeader As New Objects.Header(Me, False)
		Private m_TimeMarker As New Objects.TimeMarker(Me)
		Private m_ScheduleIcons As ScheduleIcons
		Private m_DefaultIcons As DefaultIcons
		Private m_ColoredAreaCollection As New ScheduleAreaCollection(Me)
		Private m_NoDropAreaCollection As New ScheduleAreaCollection(Me)
		Private m_Dialogs As New ScheduleDialog(Me)
		Private m_Selector As New ScheduleSelector(Me)
		Private m_SelectedItems As New AppointmentList(Me)
		Private m_DataSource As Object
		Private m_DataBindings As New Gravitybox.Data.DataBindingRoot
		Private m_UseDefaultAppearances As Boolean = m_def_UseDefaultAppearances
		Private m_UseColumnBars As Boolean = m_def_UseColumnBars

		'Internal Objects
		Private _canvas As Gravitybox.Drawing.DrawScheduleMain
		Private IsLoaded As Boolean = False
		Private MoveX As Integer
		Private MoveY As Integer
		Private ResizeAppointmentObject As New ResizeAppointmentInfo
		Private ToolTipAppointment As Appointment
		Private OffScreenImage As Image
		Private OffScreenGraphics As Graphics
		Friend SelectedItemOnMouseDown As Appointment
		Friend m_MonthSelDate As DateTime = DefaultNoDate
		Private DragAppointmentValues As New AppointmentValueCache
		Friend _DrawingDirty As Boolean = True	 'Do we need to redraw?
		Private LastMouseObject As System.Windows.Forms.MouseEventArgs
		Friend _noDrawing As Boolean		'If there is midding info (room/provider) then some modes will not draw
		Private DataBinder As New Gravitybox.Objects.DataBinder(Me)
		Private AppointmentOutline As New AppointmentOutlineHelper(Me)
		Private CancelEventDataSourceUpdated As Boolean = False
		Private editBoxFromMouseDown As Rectangle = Rectangle.Empty
		Private dragBoxFromMouseDown As Rectangle = Rectangle.Empty
		Private _errorHanding As ErrorHandlingConstants = m_def_ErrorHanding
		Friend WeekClientRectangles As ArrayList = New ArrayList		'Stores the client rectangles of the cells in Week mode
		Private LastRowSize As Integer = RowHeader.Size
		Private LastColumnSize As Integer = ColumnHeader.Size
		Private VScrollEnabled As Boolean = False
		Private HScrollEnabled As Boolean = False
		Private HasDisposed As Boolean = False
		Friend DayCellArray As New DayCellCollection
		Private _syncRoot As Object = New DataSet()	'Just some object
		Private ScrollTimerH As System.Windows.Forms.Timer = New System.Windows.Forms.Timer()
		Private ScrollTimerV As System.Windows.Forms.Timer = New System.Windows.Forms.Timer()
		Private UsingMouseWheel As Boolean = False

#End Region

#Region "Events"

		'Event Delegates
		Public Delegate Sub StandardEventDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
		Public Delegate Sub MouseEventDelegate(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
		Public Delegate Sub TextExtendedEventDelegate(ByVal sender As Object, ByVal e As TextExtendedEventArgs)
		Public Delegate Sub TextAppointmentEventDelegate(ByVal sender As Object, ByVal e As TextAppointmentEventArgs)
		Public Delegate Sub ToolTipAppointmentEventDelegate(ByVal sender As Object, ByVal e As ToolTipAppointmentEventArgs)
		Public Delegate Sub BeforeDragTipEventDelegate(ByVal sender As Object, ByVal e As BeforeDragTipEventArgs)
		Public Delegate Sub AppointmentUserDrawEventDelegate(ByVal sender As Object, ByVal e As AppointmentUserDrawEventArgs)
		Public Delegate Sub BeforeAppointmentEventDelegate(ByVal sender As Object, ByVal e As BeforeBaseObjectEventArgs)
		Public Delegate Sub BeforeAlarmEventDelegate(ByVal sender As Object, ByVal e As BeforeAlarmEventArgs)
		Public Delegate Sub AfterAppointmentEventDelegate(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
		Public Delegate Sub BeforePropertyDialogEventDelegate(ByVal sender As Object, ByVal e As BeforePropertyDialogEventArgs)
		Public Delegate Sub BeforeAppointmentConflictEventDelegate(ByVal sender As Object, ByVal e As BeforeAppointmentConflictEventArgs)
		Public Delegate Sub BeforeAppointmentActionEventDelegate(ByVal sender As Object, ByVal e As BeforeAppointmentActionEventArgs)
		Public Delegate Sub BeforeAppointmentForeignEventDelegate(ByVal sender As Object, ByVal e As BeforeAppointmentForeignEventArgs)
		Public Delegate Sub AfterAppointmentForeignEventDelegate(ByVal sender As Object, ByVal e As AfterAppointmentForeignEventArgs)
		Public Delegate Sub BeforeRowColResizeEventDelegate(ByVal sender As Object, ByVal e As BeforeRowColResizeEventArgs)
		Public Delegate Sub AfterRowColResizeEventDelegate(ByVal sender As Object, ByVal e As AfterRowColResizeEventArgs)
		Public Delegate Sub BeforeHeaderEventDelegate(ByVal sender As Object, ByVal e As BeforeHeaderEventArgs)
		Public Delegate Sub BeforeRoomHeaderEventDelegate(ByVal sender As Object, ByVal e As BeforeRoomHeaderEventArgs)
		Public Delegate Sub BeforeResourceHeaderEventDelegate(ByVal sender As Object, ByVal e As BeforeResourceHeaderEventArgs)
		Public Delegate Sub BeforeProviderHeaderEventDelegate(ByVal sender As Object, ByVal e As BeforeProviderHeaderEventArgs)
		Public Delegate Sub AppointmentMouseEventDelegate(ByVal sender As Object, ByVal e As AppointmentMouseEventArgs)
		Public Delegate Sub AfterScheduleAreaEventDelegate(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
		Public Delegate Sub ScheduleAreaEventMouseDelegate(ByVal sender As Object, ByVal e As ScheduleAreaMouseEventArgs)
		Public Delegate Sub BeforeAppointmentTextEventDelegate(ByVal sender As Object, ByVal e As BeforeAppointmentTextEventArgs)
		Public Delegate Sub AppointmentSizeEventDelegate(ByVal sender As Object, ByVal e As AppointmentSizeEventsArgs)
		Public Delegate Sub DragAppointmentEventDelegate(ByVal sender As Object, ByVal e As DragAppointmentEventArgs)
		Public Delegate Sub BeforeCategoryListDialogEventDelegate(ByVal sender As Object, ByVal e As BeforeCategoryListDialogEventArgs)
		Public Delegate Sub BeforeProviderListDialogEventDelegate(ByVal sender As Object, ByVal e As BeforeProviderListDialogEventArgs)
		Public Delegate Sub BeforeResourceListDialogEventDelegate(ByVal sender As Object, ByVal e As BeforeResourceListDialogEventArgs)
		Public Delegate Sub BeforeConfigurationDialogEventDelegate(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
		Public Delegate Sub PrintEventDelegate(ByVal sender As Object, ByVal e As PrintEventArgs)
		Public Delegate Sub PrintSetupEventDelegate(ByVal sender As Object, ByVal e As PrintSetupEventArgs)
		Public Delegate Sub BeforePrintSectionEventDelegate(ByVal sender As Object, ByVal e As BeforePrintSectionEventArgs)
		Public Delegate Sub DateRangeEventDelegate(ByVal sender As Object, ByVal e As DateRangeEventArgs)
		Public Delegate Sub AfterHeaderEventDelegate(ByVal sender As Object, ByVal e As AfterHeaderEventArgs)
		Public Delegate Sub BeforeRecurrenceDialogEventDelegate(ByVal sender As Object, ByVal e As BeforeRecurrenceDialogEventArgs)
		Public Delegate Sub AfterRecurrenceDialogEventDelegate(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

		'Public Events
		''' <summary>
		''' Occurs when the background of the schedule is clicked.
		''' </summary>
		Public Event BackgroundClick As MouseEventDelegate
		''' <summary>
		''' Occurs when the background of the schedule is double-clicked.
		''' </summary>
		Public Event BackgroundDoubleClick As MouseEventDelegate
		''' <summary>
		''' Occurs before a tooltip is displayed.
		''' </summary>
		Public Event BeforeToolTip As ToolTipAppointmentEventDelegate
		''' <summary>
		''' Occurs before a tooltip is displayed when dragging an appointment.
		''' </summary>
		Public Event BeforeDragTip As BeforeDragTipEventDelegate
		''' <summary>
		''' Occurs before the tooltip is displayed when resizing an appointment.
		''' </summary>
		Public Event BeforeResizeTip As BeforeDragTipEventDelegate
		''' <summary>
		''' Occurs before the text is drawn for an appointment's alarm on the alarm screen, provides a chance to customize the text
		''' </summary>
		Public Event BeforeAlarmDrawText As BeforeAppointmentTextEventDelegate
		''' <summary>
		''' Occurs when an appointment bar is drawn, giving a place for user-defined drawing
		''' </summary>
		Public Event UserDrawnAppointmentBar As AppointmentUserDrawEventDelegate
		''' <summary>
		''' Occurs when the header of an appointment is to be drawn, giving a place for user-defined drawing
		''' </summary>
		Public Event UserDrawnAppointmentHeader As AppointmentUserDrawEventDelegate
		''' <summary>
		''' Occurs when a time bar in the left margin is to be drawn, giving a place for user-defined drawing
		''' </summary>
		Public Event UserDrawnTimeBar As AppointmentUserDrawEventDelegate
		''' <summary>
		''' Occurs before an appointment is added by the user by double-click or pressing [ENTER]
		''' </summary>
		Public Event BeforeUserAppointmentAdd As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after an appointment has been added by the user by double-click or pressing [ENTER]
		''' </summary>
		Public Event AfterUserAppointmentAdd As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is removed by the user by pressing [DELETE]
		''' </summary>
		Public Event BeforeUserAppointmentRemove As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after an appointment has been removed by the user by pressing [DELETE]
		''' </summary>
		Public Event AfterUserAppointmentRemove As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is added to the AppointmentCollection.
		''' </summary>
		Public Event BeforeAppointmentAdd As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after an appointment has been added to the AppointmentCollection.
		''' </summary>
		Public Event AfterAppointmentAdd As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before the default property dialog screen is displayed.
		''' </summary>
		Public Event BeforePropertyDialog As BeforePropertyDialogEventDelegate
		''' <summary>
		''' Occurs after the default property dialog screen has been displayed.
		''' </summary>
		Public Event AfterPropertyDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs after the default appointment dialog has been cancelled.
		''' </summary>
		Public Event AfterCancelPropertyDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs after the default appointment dialog has been saved.
		''' </summary>
		Public Event AfterSavePropertyDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is removed from the AppointmentCollection.
		''' </summary>
		Public Event BeforeAppointmentRemove As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after an appointment has been removed from the AppointmentCollection.
		''' </summary>
		Public Event AfterAppointmentRemove As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is copied as another appointment by user interaction.
		''' </summary>
		''' <remarks>After a copy there will be another appointment object in the AppointmentCollection</remarks>
		Public Event BeforeAppointmentCopy As BeforeAppointmentActionEventDelegate
		''' <summary>
		''' Occurs after an appointment has been copied as another appointment by user interaction.
		''' </summary>
		''' <remarks>After a copy there will be another appointment object in the AppointmentCollection</remarks>
		Public Event AfterAppointmentCopy As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is moved by user interaction.
		''' </summary>
		''' <remarks></remarks>
		Public Event BeforeAppointmentMove As BeforeAppointmentActionEventDelegate
		''' <summary>
		''' Occurs after an appointment has been moved by user interaction.
		''' </summary>
		Public Event AfterAppointmentMove As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before a foreign (non-appointment) object is dropped on the schedule.
		''' </summary>
		''' <remarks>This event may be used in conjunction with custom code to control custom drops from other controls onto the schedule.</remarks>
		Public Event BeforeForeignAdd As BeforeAppointmentForeignEventDelegate
		''' <summary>
		''' Occurs after a foreign (non-appointment) object has been dropped on the schedule.
		''' </summary>
		''' <remarks>This event may be used in conjunction with custom code to control custom drops from other controls onto the schedule.</remarks>
		Public Event AfterForeignAdd As AfterAppointmentForeignEventDelegate
		''' <summary>
		''' Occurs when the viewmode property changes
		''' </summary>
		Public Event ViewModeChange As StandardEventDelegate
		''' <summary>
		''' Occurs before an appointment is removed from the AppointmentCollection. It is raised after the BeforeAppointmentRemove and before AfterAppointmentRemove event.
		''' </summary>
		''' <remarks>When this event is called the appointment is still in the AppointmentCollection however so you can perform actions on it as if it were. However it is guaranteed to be removed. There is no way to cancel the action.</remarks>
		Public Event ValidateAppointmentRemove As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before a column is resized. You may cancel this action.
		''' </summary>
		Public Event BeforeColumnResize As BeforeRowColResizeEventDelegate
		''' <summary>
		''' Occurs after a column has been resized.
		''' </summary>
		Public Event AfterColumnResize As AfterRowColResizeEventDelegate
		''' <summary>
		''' Occurs before a row is resized. You may cancel this action.
		''' </summary>
		Public Event BeforeRowResize As BeforeRowColResizeEventDelegate
		''' <summary>
		''' Occurs before a row has been resized.
		''' </summary>
		Public Event AfterRowResize As AfterRowColResizeEventDelegate
		''' <summary>
		''' Occurs before the SelectItem property is changed.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event BeforeSelectedItemChange As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after the SelectedItem propert is changed.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event AfterSelectedItemChange As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before the text of a Room header is drawn.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event BeforeRoomHeaderDraw As BeforeRoomHeaderEventDelegate
		''' <summary>
		''' Occurs before the text of a Resource header is drawn.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event BeforeResourceHeaderDraw As BeforeResourceHeaderEventDelegate
		''' <summary>
		''' Occurs before the text of a Provider header is drawn.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event BeforeProviderHeaderDraw As BeforeProviderHeaderEventDelegate
		''' <summary>
		''' Occurs before the text of a date header is drawn.
		''' </summary>
		''' <remarks>This event allows you to cancel the action if desired.</remarks>
		Public Event BeforeDateHeaderDraw As BeforeHeaderEventDelegate
		''' <summary>
		''' Occurs before the reminder window of an appointment is displayed.
		''' </summary>
		Public Event BeforeAppointmentReminder As BeforeAlarmEventDelegate
		''' <summary>
		''' Occurs before the alarm window of an appointment is displayed.
		''' </summary>
		Public Event BeforeAppointmentDue As BeforeAlarmEventDelegate
		''' <summary>
		''' Occurs when an appointment is clicked.
		''' </summary>
		Public Event AppointmentClick As AppointmentMouseEventDelegate
		''' <summary>
		''' Occurs when an appointment is double-clicked.
		''' </summary>
		Public Event AppointmentDoubleClick As AppointmentMouseEventDelegate
		''' <summary>
		''' Occurs when the header of an appointment is clicked.
		''' </summary>
		Public Event AppointmentHeaderClick As AppointmentMouseEventDelegate
		''' <summary>
		''' Occurs when the header of an appointment is double-clicked.
		''' </summary>
		Public Event AppointmentHeaderDoubleClick As AppointmentMouseEventDelegate
		''' <summary>
		''' Occurs when a NoDropArea object is clicked.
		''' </summary>
		Public Event NoDropAreaClick As ScheduleAreaEventMouseDelegate
		''' <summary>
		''' Occurs when a ColoredArea object is clicked.
		''' </summary>
		Public Event ColoredAreaClick As ScheduleAreaEventMouseDelegate
		''' <summary>
		''' Occurs before the text an appointment is drawn.
		''' </summary>
		''' <remarks>This event provides a place to customize this text.</remarks>
		Public Event BeforeAppointmentTextDraw As BeforeAppointmentTextEventDelegate
		''' <summary>
		''' Occurs before an appointment is placed into edit mode.
		''' </summary>
		Public Event BeforeInPlaceEdit As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs after an appointment has been in-place edited.
		''' </summary>
		Public Event AfterInPlaceEdit As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before an appointment is resized by the user.
		''' </summary>
		Public Event BeforeAppointmentResize As AppointmentSizeEventDelegate
		''' <summary>
		''' Occurs while an appointment is being resized by the user.
		''' </summary>
		''' <remarks>This event may be called many times during a single resize operation.</remarks>
		Public Event WhileAppointmentResize As AppointmentSizeEventDelegate
		''' <summary>
		''' Occurs after an appointment has been resized by the user.
		''' </summary>
		Public Event AfterAppointmentResize As BeforeAppointmentEventDelegate
		''' <summary>
		''' Occurs when the mouse pointer leaves the control.
		''' </summary>
		Public Shadows Event MouseLeave As StandardEventDelegate
		''' <summary>
		''' Occurs when the mouse pointer enters the control.
		''' </summary>
		Public Shadows Event MouseEnter As StandardEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Shadows Event DragOver As DragAppointmentEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Shadows Event DragDrop As DragAppointmentEventDelegate
		''' <summary>
		''' Occurs before the default CategoryList dialog is displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event BeforeCategoryListDialog As BeforeCategoryListDialogEventDelegate
		''' <summary>
		''' Occurs after the default ProviderList dialog is displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event AfterProviderListDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before the default ProviderList dialog is displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event BeforeProviderListDialog As BeforeProviderListDialogEventDelegate
		''' <summary>
		''' Occurs after the default CategoryList dialog is displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event AfterCategoryListDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before the default ProviderCollection editor is displayed.
		''' </summary>
		Public Event BeforeProviderConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' Occurs after the default ProviderCollection editor has been displayed.
		''' </summary>
		Public Event AfterProviderConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' Occurs before the default ResourceList dialog is displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event BeforeResourceListDialog As BeforeResourceListDialogEventDelegate
		''' <summary>
		''' Occurs after the default ResourceList dialog has been displayed.
		''' </summary>
		''' <remarks>The dialog is displayed from the default Appoinment dialog and the AppointmentProperties UserControl.</remarks>
		Public Event AfterResourceListDialog As AfterAppointmentEventDelegate
		''' <summary>
		''' Occurs before the default ResourceCollection editor is displayed.
		''' </summary>
		Public Event BeforeResourceConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' Occurs after the default ResourceCollection editor has been displayed.
		''' </summary>
		Public Event AfterResourceConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' Occurs before the default CategoryCollection editor is displayed.
		''' </summary>
		Public Event BeforeCategoryConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' Occurs after the default CategoryCollection editor has been displayed.
		''' </summary>
		Public Event AfterCategoryConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' Occurs before the default RoomCollection editor is displayed.
		''' </summary>
		Public Event BeforeRoomConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' Occurs after the default RoomCollection editor has been displayed.
		''' </summary>
		Public Event AfterRoomConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' Not Implemented
		''' </summary>
		Public Event BeforeAppearanceConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' Not Implemented
		''' </summary>
		Public Event AfterAppearanceConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event BeforePropertyItemConfigurationDialog As BeforeConfigurationDialogEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event AfterPropertyItemConfigurationDialog As StandardEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PrintSetup As PrintSetupEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event BeforePrintHeader As BeforePrintSectionEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event BeforePrintFooter As BeforePrintSectionEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event BeforePrintPageNumber As BeforePrintSectionEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PrintProgress As PrintEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PrintCanceled As StandardEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PropertyDialogSaveInvalidArea As TextExtendedEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PropertyDialogRemoveFiles As TextExtendedEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event PropertyDialogSaveValueOutOfRange As TextExtendedEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event DateRangeChange As DateRangeEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event AppointmentHeaderInfoClick As AppointmentMouseEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Shadows Event Resize As StandardEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Shadows Event Paint As StandardEventDelegate
		''' <summary>
		''' Occurs when a column header is clicked.
		''' </summary>
		Public Shadows Event ColumnHeaderClick As AfterHeaderEventDelegate
		''' <summary>
		''' Occurs when a row header is clicked.
		''' </summary>
		Public Shadows Event RowHeaderClick As AfterHeaderEventDelegate
		''' <summary>
		''' Occurs when a column header is double-clicked.
		''' </summary>
		Public Shadows Event ColumnHeaderDoubleClick As AfterHeaderEventDelegate
		''' <summary>
		''' Occurs when a row header is double-clicked.
		''' </summary>
		Public Shadows Event RowHeaderDoubleClick As AfterHeaderEventDelegate
		''' <summary>
		''' Occurs when the DataSource property has been changed.
		''' </summary>
		Public Event DataSourceUpdated As RefreshDelegate
		''' <summary>
		''' Occurs when the user scrolls vertically the schedule.
		''' </summary>
		Public Shadows Event VerticalScroll As StandardEventDelegate
		''' <summary>
		''' Occurs when the user scrolls horizontally the schedule.
		''' </summary>
		Public Shadows Event HorizontalScroll As StandardEventDelegate
		''' <summary>
		''' Occurs when the user dismisses an appointment from the Alarm dialog.
		''' </summary>
		Public Event AppointmentDismissed As AfterAppointmentEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event AppointmentSnooze As AfterAppointmentEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event BeforeRecurrenceDialog As BeforeRecurrenceDialogEventDelegate
		''' <summary>
		''' 
		''' </summary>
		Public Event AfterRecurrenceDialog As AfterAppointmentEventDelegate

#End Region

#Region "Public Object Collections"

		''' <summary>
		''' This collection holds the set of Appointment objects
		''' </summary>
		<Browsable(False), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
		Description("This collection holds the set of Appointment objects")> _
		Public ReadOnly Property AppointmentCollection() As AppointmentCollection
			Get
				Return m_AppointmentCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Recurrence objects that can be associated with an appointment
		''' </summary>
		<Browsable(False), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
		Description("This collection holds a set of recurrence objects.")> _
		Public ReadOnly Property RecurrenceCollection() As RecurrenceCollection
			Get
				Return m_RecurrenceCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Room objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.RoomCollectionConverter)), _
		Description("This collection holds a set of room objects.")> _
		Public ReadOnly Property RoomCollection() As RoomCollection
			Get
				Return m_RoomCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Category objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.CategoryCollectionConverter)), _
		Description("This collection holds a set of category objects.")> _
		Public ReadOnly Property CategoryCollection() As CategoryCollection
			Get
				Return m_CategoryCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Priority objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.PriorityCollectionConverter)), _
		Description("This collection holds a set of priority objects.")> _
		Public ReadOnly Property PriorityCollection() As PriorityCollection
			Get
				Return m_PriorityCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of AppointmentType objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentTypeConverter)), _
		Description("This collection holds a set of appointment type objects.")> _
		Public ReadOnly Property AppointmentTypeCollection() As AppointmentTypeCollection
			Get
				Return m_AppointmentTypeCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Provider objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.ProviderCollectionConverter)), _
		Description("This collection holds a set of provider objects.")> _
		Public ReadOnly Property ProviderCollection() As ProviderCollection
			Get
				Return m_ProviderCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds the set of Resource objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.ResourceCollectionConverter)), _
		Description("This collection holds a set of provider objects.")> _
		Public ReadOnly Property ResourceCollection() As ResourceCollection
			Get
				Return m_ResourceCollection
			End Get
		End Property

		''' <summary>
		''' This collection holds a set of Appearance objects that can be associated with an appointment
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.AppearanceCollectionConverter)), _
		Description("This collection holds a set of appearance objects.")> _
		Public ReadOnly Property AppearanceCollection() As AppearanceCollection
			Get
				Return m_AppearanceCollection
			End Get
		End Property

		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property Visibility() As ScheduleVisibility
			Get
				Return m_Visibility
			End Get
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.HeaderConverter)), _
		Description("This object represents the display options used when drawing columns.")> _
		Public ReadOnly Property ColumnHeader() As Objects.Header
			Get
				Return m_ColumnHeader
			End Get
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.HeaderConverter)), _
		Description("This object represents the display options used when drawing rows.")> _
		Public ReadOnly Property RowHeader() As Objects.Header
			Get
				Return m_RowHeader
			End Get
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.TimeMarkerConverter)), _
		Description("This object represents the display options to draw a marker at the current time.")> _
		Public ReadOnly Property TimeMarker() As Objects.TimeMarker
			Get
				Return m_TimeMarker
			End Get
		End Property

		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property ScheduleIcons() As ScheduleIcons
			Get
				Return m_ScheduleIcons
			End Get
		End Property

		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property DefaultIcons() As DefaultIcons
			Get
				Return m_DefaultIcons
			End Get
		End Property

		<Browsable(False), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
		Description("This collection defines areas to be colored on the schedule.")> _
		Public ReadOnly Property ColoredAreaCollection() As ScheduleAreaCollection
			Get
				Return m_ColoredAreaCollection
			End Get
		End Property

		<Browsable(False), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
		Description("This collection defines areas where no appointments may be scheduled on the schedule.")> _
		Public ReadOnly Property NoDropAreaCollection() As ScheduleAreaCollection
			Get
				Return m_NoDropAreaCollection
			End Get
		End Property

		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property Dialogs() As ScheduleDialog
			Get
				Return m_Dialogs
			End Get
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.SelectorConverter)), _
		Description("This is the selector object used to select areas of a schedule.")> _
		Public ReadOnly Property Selector() As ScheduleSelector
			Get
				Return m_Selector
			End Get
		End Property

		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public ReadOnly Property SelectedItems() As AppointmentList
			Get
				Return m_SelectedItems
			End Get
		End Property

		<Browsable(True), _
		Category("Data"), _
		DefaultValue(CStr(Nothing)), _
		TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design"), _
		Description("Gets or sets the data source for this schedule.")> _
		Public Property DataSource() As Object
			Get
				Return m_DataSource
			End Get
			Set(ByVal Value As Object)
				m_DataSource = Value
			End Set
		End Property

#End Region

#Region "Property Implementations"

		Friend Property DrawingDirty() As Boolean
			Get
				Return _DrawingDirty
			End Get
			Set(ByVal value As Boolean)
				If value Then cachedViewPort = New Rectangle
				_DrawingDirty = value
			End Set
		End Property


		Friend Property NoDrawing() As Boolean
			Get
				Return _noDrawing
			End Get
			Set(ByVal Value As Boolean)
				_noDrawing = Value
				If Not _noDrawing Then
					SetupScroll()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if an internal error is displays as a message box (Normal) or is submitted back to Gravitybox (Advanced). This should always by set to Normal in production.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_ErrorHanding), _
		Description("Determines if an internal error is displays as a message box (Normal) or is submitted back to Gravitybox (Advanced). This should always by set to Normal in production.")> _
		Public Property ErrorHanding() As ErrorHandlingConstants
			Get
				Return _errorHanding
			End Get
			Set(ByVal Value As ErrorHandlingConstants)
				_errorHanding = Value
			End Set
		End Property

		Friend Property Canvas() As Gravitybox.Drawing.DrawScheduleMain
			Get
				Return _canvas
			End Get
			Set(ByVal Value As Gravitybox.Drawing.DrawScheduleMain)
				_canvas = Value
			End Set
		End Property

		Friend Property MonthSelDate() As DateTime
			Get
				Return m_MonthSelDate
			End Get
			Set(ByVal Value As DateTime)
				m_MonthSelDate = DateSerial(Value.Year, Value.Month, 1)
				Me.DrawingDirty = True
			End Set
		End Property

		Friend ReadOnly Property MonthViewFirstDate() As DateTime
			Get
				Dim startDate As Date = Me.MinDate.AddDays(-(Me.MinDate.DayOfWeek - Me.FirstDayOfWeek))
				If Me.MinDate < startDate Then startDate = startDate.AddDays(-7)
				Return startDate
			End Get
		End Property

		''' <summary>
		''' The AllowCopy property determines if the user can make a copy of an appointment by dragging an appointment with the mouse.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowCopy), _
		Description("The AllowCopy property determines if the user can make a copy of an appointment by dragging an appointment with the mouse.")> _
		Public Property AllowCopy() As Boolean
			Get
				Return m_AllowCopy
			End Get
			Set(ByVal Value As Boolean)
				m_AllowCopy = Value
			End Set
		End Property

		''' <summary>
		''' Determines the number of hours in day to be displayed by the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DefaultValue(HourPerDay), _
		Description("Determines the number of hours in day to be displayed by the schedule.")> _
		Public Property DayLength() As Integer
			Get
				Return m_DayLength
			End Get
			Set(ByVal Value As Integer)
				If m_DayLength <> Value Then
					m_DayLength = Value
					CheckStartTimeDayLength()
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines the starting time of the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
		TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
		DefaultValue(GetType(DateTime), "12:00 AM"), _
		Description("Determines the starting time of the schedule.")> _
		Public Property StartTime() As DateTime
			Get
				Return m_StartTime
			End Get
			Set(ByVal Value As DateTime)
				Dim newValue As Date = GetTime(Value, True)
				If m_StartTime <> newValue Then
					m_StartTime = newValue
					CheckStartTimeDayLength()
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines displayed time increment. This is the number of minutes that correspond to the resolution of the grid.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(TimeIncrementConstants), "Minute30"), _
		Description("Determines displayed time increment. This is the number of minutes that correspond to the resolution of the grid.")> _
		Public Property TimeIncrement() As TimeIncrementConstants
			Get
				Return m_TimeIncrement
			End Get
			Set(ByVal Value As TimeIncrementConstants)
				If m_TimeIncrement <> Value Then
					m_TimeIncrement = Value
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines displayed time increment that is used for dragging and resizing. This is the number of minutes that correspond to the smallest increment of time that an appointment can be moved or resized.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(GetType(TimeIncrementConstants), "Minute30"), _
		Description("Determines displayed time increment that is used for dragging and resizing. This is the number of minutes that correspond to the smallest increment of time that an appointment can be moved or resized.")> _
		Public Property AppointmentTimeIncrement() As TimeIncrementConstants
			Get
				Return m_AppointmentTimeIncrement
			End Get
			Set(ByVal Value As TimeIncrementConstants)
				m_AppointmentTimeIncrement = Value
			End Set
		End Property

		Friend ReadOnly Property TimeIncrementValue() As Integer
			Get
				Return GetIntlInteger(Me.TimeIncrement)
			End Get
		End Property

		Friend ReadOnly Property TimeIncrementsPerHour() As Integer
			Get
				Return (MinutesPerHour \ TimeIncrementValue)
			End Get
		End Property

		Friend ReadOnly Property TimeIncrementsPerDay() As Integer
			Get
				Return ((MinutesPerHour * HourPerDay) \ TimeIncrementValue)
			End Get
		End Property

		Friend ReadOnly Property AppointmentTimeIncrementValue() As Integer
			Get
				Return GetIntlInteger(Me.AppointmentTimeIncrement)
			End Get
		End Property

		Friend ReadOnly Property AppointmentTimeIncrementsPerHour() As Integer
			Get
				Return (MinutesPerHour \ AppointmentTimeIncrementValue)
			End Get
		End Property

		Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
			Try
				OnRefresh()
				VScroll1.Enabled = False
				HScroll1.Enabled = False
				VScroll1.Enabled = VScrollEnabled
				HScroll1.Enabled = HScrollEnabled
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		''' <summary>
		''' Determines the color to paint appointment's whose Blockout property has been set to true.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(Color), "Black"), _
		Description("Determines the color to paint appointment's whose Blockout property has been set to true.")> _
		Public Property BlockoutColor() As Color
			Get
				Return m_BlockoutColor
			End Get
			Set(ByVal Value As Color)
				If Not m_BlockoutColor.Equals(Value) Then
					m_BlockoutColor = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if an appointment may be resized by the user.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(GetType(AppointmentResizingConstants), "All"), _
		Description("Determines if an appointment may be resized by the user.")> _
		Public Property AppointmentResizing() As AppointmentResizingConstants
			Get
				Return m_AppointmentResizing
			End Get
			Set(ByVal Value As AppointmentResizingConstants)
				m_AppointmentResizing = Value
			End Set
		End Property

		''' <summary>
		''' This is the appointment that is currently selected on the schedule. It may be set to Nothing if there is no selected appointment.
		''' </summary>
		<Browsable(False), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
		Description("This is the appointment that is currently selected on the schedule. It may be set to Nothing if there is no selected appointment.")> _
		Public Property SelectedItem() As Appointment
			Get
				'Make sure that this is not an invalid SelectedItem
				If Not (m_SelectedItem Is Nothing) Then
					If Not Me.AppointmentCollection.Contains(m_SelectedItem) Then
						m_SelectedItem = Nothing
					ElseIf m_SelectedItem.Blockout Then
						'Do not allow Blockout appointment to have focus
						m_SelectedItem = Nothing
					End If
				End If
				Return m_SelectedItem
			End Get
			Set(ByVal Value As Appointment)
				If Not (Value Is Nothing) Then
					'Do not set if this is a Blockout appointment
					If Value.Blockout Then
						Value = Nothing
						Return
					End If
					If Not Value.Visible Then
						Value = Nothing
						Return
					End If
				End If

				'If nothing has changed then exit
				If (Value Is m_SelectedItem) Then
					'Before exiting make sure that this object is in the SelectedItems collection
					If Not (Value Is Nothing) AndAlso Not Me.SelectedItems.Contains(Value) Then
						'Clear the collection if need be
						Dim lockKey As String = PrepareForProcessing()
						If Not Me.MultiSelect Then Call Me.SelectedItems.Clear()
						Call Me.SelectedItems.Add(m_SelectedItem)
						Me.PrepareForProcessing(lockKey)
						OnRefresh()
					End If
					Return
				End If

				Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(Value)
				OnBeforeSelectedItemChange(eventParam1)
				If eventParam1.Cancel Then Return

				'Set the value
				m_SelectedItem = Value

				'If the SelectItem is not in the SelectedItems collection then add it
				If MultiSelect Then
					If Not (m_SelectedItem Is Nothing) Then
						If Not Me.SelectedItems.Contains(m_SelectedItem) Then
							Call Me.SelectedItems.Add(m_SelectedItem)
						End If
					End If
				Else
					'Single select, so clear and add one object
					Dim lockKey As String = PrepareForProcessing()
					Call Me.SelectedItems.Clear()
					Call Me.SelectedItems.Add(Value)
					m_SelectedItem = Value
					Me.PrepareForProcessing(lockKey)
				End If

				OnRefresh()

				Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(Value)
				OnAfterSelectedItemChange(eventParam2)
			End Set
		End Property

		''' <summary>
		''' Determines if the schedule will repaint. This property may be set to false to load many appointments or make many changes. It can then be set to true to re-enable painting. This will ensure that the schedule is not repainted for each appointment load or change. Using this property wisely can significantly speed-up loading.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AutoRedraw), _
		Description("Determines if the schedule will repaint. This property may be set to false to load many appointments or make many changes. It can then be set to true to re-enable painting. This will ensure that the schedule is not repainted for each appointment load or change. Using this property wisely can significantly speed-up loading.")> _
		Public Property AutoRedraw() As Boolean
			Get
				Return m_AutoRedraw
			End Get
			Set(ByVal Value As Boolean)
				If m_AutoRedraw <> Value Then
					m_AutoRedraw = Value
					If AutoRedraw Then OnRefresh()
				End If
			End Set
		End Property

		Private Property SafeRedraw() As Boolean
			Get
				Return m_SafeRedraw
			End Get
			Set(ByVal Value As Boolean)
				m_SafeRedraw = Value
			End Set
		End Property

		''' <summary>
		''' The AllowAdd property determines if the user can double-click on the background and create an appointment.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowAdd), _
		Description("The AllowAdd property determines if the user can double-click on the background and create an appointment.")> _
		Public Property AllowAdd() As Boolean
			Get
				Return m_AllowAdd
			End Get
			Set(ByVal Value As Boolean)
				m_AllowAdd = Value
			End Set
		End Property

		''' <summary>
		''' The AllowMove property determines if the user can move an appointment with the mouse by dragging it.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowMove), _
		Description("The AllowMove property determines if the user can move an appointment with the mouse by dragging it.")> _
		Public Property AllowMove() As Boolean
			Get
				Return m_AllowMove
			End Get
			Set(ByVal Value As Boolean)
				m_AllowMove = Value
			End Set
		End Property

		''' <summary>
		''' This is the minimum date range for the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		Description("This is the minimum date range for the schedule.")> _
		Public Property MinDate() As DateTime
			Get
				If Me.ViewMode = ViewModeConstants.Month Then
					Return GetStartOfWeek(m_MinDate, Me.FirstDayOfWeek)
				ElseIf Me.ViewMode = ViewModeConstants.MonthFull Then
					Return GetStartOfWeek(m_MinDate, Me.FirstDayOfWeek)
				ElseIf Me.ViewMode = ViewModeConstants.Week Then
					Return GetStartOfWeek(m_MinDate, Me.FirstDayOfWeek)
				Else
					Return m_MinDate
				End If
			End Get
			Set(ByVal Value As DateTime)

				Dim newValue As Date = GetDate(Value)
				If m_MinDate = newValue Then Return

				'Error check
				If Value > Me.MaxDate Then
					Throw New Exceptions.GravityboxException("The mindate may not be greater than the maxdate!")
				End If

				m_MinDate = newValue
				If MonthSelDate < MinDate Then MonthSelDate = MinDate
				Me.DrawingDirty = True
				OnRefresh()

				'Raise the DateRangeChange event
				Dim eventParam As New Gravitybox.Objects.EventArgs.DateRangeEventArgs(Me.MinDate, Me.MaxDate)
				OnDateRangeChange(eventParam)

			End Set
		End Property

		Friend ReadOnly Property OrginalMinDate() As Date
			Get
				Return m_MinDate
			End Get
		End Property

		''' <summary>
		''' This is the maximum date range for the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		Description("This is the maximum date range for the schedule.")> _
		Public Property MaxDate() As DateTime
			Get
				If Me.ViewMode = ViewModeConstants.Month Then
					Return m_MinDate.AddMonths(1).AddDays(-1)					'End of month
				ElseIf Me.ViewMode = ViewModeConstants.MonthFull Then
					Return m_MinDate.AddMonths(1).AddDays(-1)					'End of month
				ElseIf Me.ViewMode = ViewModeConstants.Week Then
					Return m_MinDate.AddDays(DaysPerWeek - 1)					'7 days (1 week) from Mindate  
				Else
					Return m_MaxDate
				End If
			End Get
			Set(ByVal Value As DateTime)

				Dim newValue As Date = GetDate(Value)
				If m_MaxDate = newValue Then Return

				'Error check
				If Value < Me.MinDate Then
					Throw New Exceptions.GravityboxException("The mindate may not be greater than the maxdate!")
				End If

				m_MaxDate = newValue
				If MonthSelDate > MaxDate Then MonthSelDate = MaxDate
				Me.DrawingDirty = True
				OnRefresh()

				'Raise the DateRangeChange event
				Dim eventParam As New Gravitybox.Objects.EventArgs.DateRangeEventArgs(Me.MinDate, Me.MaxDate)
				OnDateRangeChange(eventParam)

			End Set
		End Property

		''' <summary>
		''' This method may be used to set the MinDate and MaxDate at the same time.
		''' </summary>
		<Browsable(True), _
		Description("This method may be used to set the MinDate and MaxDate at the same time.")> _
		Public Sub SetMinMaxDate(ByVal minDate As DateTime, ByVal maxDate As DateTime)
			Try
				minDate = GetDate(minDate)
				maxDate = GetDate(maxDate)

				If minDate > maxDate Then
					Throw New Exceptions.GravityboxException("The mindate may not be greater than the maxdate!")
				End If

				'If nothing has changed then do nothing
				If (m_MinDate = minDate) AndAlso (m_MaxDate = maxDate) Then Return

				m_MinDate = minDate
				m_MaxDate = maxDate
				If MonthSelDate < minDate Then MonthSelDate = minDate
				If MonthSelDate > maxDate Then MonthSelDate = maxDate

				'Raise the DateRangeChange event
				Dim eventParam As New Gravitybox.Objects.EventArgs.DateRangeEventArgs(Me.MinDate, Me.MaxDate)
				OnDateRangeChange(eventParam)

				Me.DrawingDirty = True
				OnRefresh()

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		''' <summary>
		''' This is the end time of the schedule.
		''' </summary>
		<Browsable(False), _
		Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
		TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
		Description("This is the end time of the schedule.")> _
		Public Property EndTime() As DateTime
			Get
				Return Me.StartTime.AddHours(Me.DayLength)
			End Get
			Set(ByVal Value As DateTime)
				Dim newValue As Date = GetTime(Value, True)
				Dim length As Integer = GetIntlInteger(newValue.Subtract(Me.StartTime).TotalHours)
				If length > 0 Then
					Me.DayLength = length
				End If
			End Set
		End Property

		''' <summary>
		''' This property is a format string for the dates displayed in the date headers.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue("ddd MMM, dd"), _
		Description("This property is a format string for the dates displayed in the date headers.")> _
		Public Property HeaderDateFormat() As String
			Get
				Return m_HeaderDateFormat
			End Get
			Set(ByVal Value As String)
				If m_HeaderDateFormat <> Value Then
					m_HeaderDateFormat = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' This property is a format string for the times displayed in the time headers.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue("h:mm tt"), _
		Description("This property is a format string for the times displayed in the time headers.")> _
		Public Property HeaderTimeFormat() As String
			Get
				Return m_HeaderTimeFormat
			End Get
			Set(ByVal Value As String)
				If m_HeaderTimeFormat <> Value Then
					m_HeaderTimeFormat = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if the user may use the [DELETE] key to remove an appointment.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowRemove), _
		Description("Determines if the user may use the <DELETE> key to remove an appointment.")> _
		Public Property AllowRemove() As Boolean
			Get
				Return m_AllowRemove
			End Get
			Set(ByVal Value As Boolean)
				m_AllowRemove = Value
			End Set
		End Property

		''' <summary>
		''' Determines the way a schedule is displayed. There are numerous options such As DateTimes on top and times on left. This property provides the schedule with much functionality in that it allows you to display the same data in various ways.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(ViewModeConstants), "DayTopTimeLeft"), _
		Description("Determines the way a schedule is displayed. There are numerous options such As DateTimes on top and times on left. This property provides the schedule with much functionality in that it allows you to display the same data in various ways.")> _
		Public Property ViewMode() As ViewModeConstants
			Get
				Return m_ViewMode
			End Get
			Set(ByVal Value As ViewModeConstants)
				Call SaveInGridEdit()
				If m_ViewMode <> Value Then

					Me.DayCellArray.Reset()
					Dim wasNoResize As Boolean = Me.IsHeaderFixed

					Dim oldValue As ViewModeConstants = m_ViewMode
					m_ViewMode = Value

					Me.DrawingDirty = True

					Dim lockKey As String = PrepareForProcessing()
					Try
						Call Me.OnResize(New System.EventArgs)
						If Me.Visibility.TotalColumnCount >= Me.Selector.Column Then
							Me.Selector.Column = Me.Selector.Column
						Else
							Me.Selector.Column = Me.Visibility.TotalColumnCount
						End If
						If Me.Visibility.TotalRowCount >= Me.Selector.Row Then
							Me.Selector.Row = Me.Selector.Row
						Else
							Me.Selector.Row = Me.Visibility.TotalRowCount
						End If

						'If did not resize before and now can resize then reset the sizes just in case 
						If wasNoResize And Not Me.IsHeaderFixed Then
							RowHeader.SetSize(LastRowSize)
							ColumnHeader.SetSize(LastColumnSize)
						ElseIf Not Me.IsHeaderFixed Then
							LastRowSize = RowHeader.Size
							LastColumnSize = ColumnHeader.Size
						End If
						Me.SetupScroll()

					Catch ex As Exception
						Throw
					Finally
						PrepareForProcessing(lockKey)
					End Try

					OnRefresh()
					OnViewModeChange(New System.EventArgs)
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if appointments may be edited in place. In-place edits change the 'Subject' property of an appointment.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowInPlaceEdit), _
		Description("Determines if appointments may be edited in place. In-place edits change the 'Subject' property of an appointment.")> _
		Public Property AllowInPlaceEdit() As Boolean
			Get
				Return m_AllowInPlaceEdit
			End Get
			Set(ByVal Value As Boolean)
				m_AllowInPlaceEdit = Value
			End Set
		End Property

		''' <summary>
		''' The font to use when drawing the schedule.
		''' </summary>
		<Browsable(True), _
		Description("The font to use when drawing the schedule.")> _
		Public Overrides Property Font() As Font
			Get
				Return MyBase.Font
			End Get
			Set(ByVal Value As Font)
				MyBase.Font = Value
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' Determines the first day of the week to use when drawing calendars.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(DayOfWeek), "Sunday"), _
		Description("Determines the first day of the week to use when drawing calendars.")> _
		Public Property FirstDayOfWeek() As DayOfWeek
			Get
				Return m_FirstDayOfWeek
			End Get
			Set(ByVal Value As DayOfWeek)
				If m_FirstDayOfWeek <> Value Then
					m_FirstDayOfWeek = Value
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines the number of pixels to indent the appointment from the right edge of its containing column.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(8), _
		Description("Determines the number of pixels to indent the appointment from the right edge of its containing column.")> _
		Public Property AppointmentSpace() As Integer
			Get
				Return m_AppointmentSpace
			End Get
			Set(ByVal Value As Integer)
				If m_AppointmentSpace <> Value Then
					m_AppointmentSpace = Value
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines what type of AppointmentBar to draw, if one at all.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("Determines what type of AppointmentBar to draw, if one at all.")> _
		Public ReadOnly Property AppointmentBar() As ScheduleBar
			Get
				Return m_AppointmentBar
			End Get
		End Property

		''' <summary>
		''' Determines what type of TimeBar to draw, if one at all.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("Determines what type of TimeBar to draw, if one at all.")> _
		Public ReadOnly Property TimeBar() As ScheduleBar
			Get
				Return m_TimeBar
			End Get
		End Property

		''' <summary>
		''' Determines whether times are displayed using the 12 or 24 hour clock.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(ClockSettingConstants), "Clock12"), _
		Description("Determines whether times are displayed using the 12 or 24 hour clock.")> _
		Public Property ClockSetting() As ClockSettingConstants
			Get
				Return m_ClockSetting
			End Get
			Set(ByVal Value As ClockSettingConstants)
				If m_ClockSetting <> Value Then
					m_ClockSetting = Value

					'Reset the time header format
					If Value = ClockSettingConstants.Clock12 Then
						m_HeaderTimeFormat = DefaultClockSetting12Hour
					ElseIf Value = ClockSettingConstants.Clock24 Then
						m_HeaderTimeFormat = DefaultClockSetting24Hour
					End If

					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if all minutes of an hour are displayed or just the '00' minute increment (MS-Outlook style).
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(MinutesShownConstants), "FirstOnly"), _
		Description("Determines if all minutes of an hour are displayed or just the '00' minute increment (MS-Outlook style).")> _
		Public Property MinutesShown() As MinutesShownConstants
			Get
				Return m_MinutesShown
			End Get
			Set(ByVal Value As MinutesShownConstants)
				If m_MinutesShown <> Value Then
					m_MinutesShown = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if one or more scroll bars are visible.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(ScrollBars), "Both"), _
		Description("Determines if one or more scroll bars are visible.")> _
		Public Property ScrollBars() As System.Windows.Forms.ScrollBars
			Get
				If ViewMode = ViewModeConstants.Month Then
					Return System.Windows.Forms.ScrollBars.None
				ElseIf ViewMode = ViewModeConstants.MonthFull Then
					Return System.Windows.Forms.ScrollBars.None
				Else
					Return m_ScrollBars
				End If
			End Get
			Set(ByVal Value As System.Windows.Forms.ScrollBars)
				If m_ScrollBars <> Value Then
					m_ScrollBars = Value
					Call OnResize(New System.EventArgs)
					Me.DrawingDirty = True
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if the highlight selector is visible.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(m_def_AllowSelector), _
		Description("Determines if the highlight selector is visible.")> _
		Public Property AllowSelector() As Boolean
			Get
				If Me.Visibility.IsPrinting Then
					Return False
				Else
					Return m_AllowSelector
				End If
			End Get
			Set(ByVal Value As Boolean)
				If m_AllowSelector <> Value Then
					m_AllowSelector = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if the grid is visible on the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(m_def_AllowGrid), _
		Description("Determines if the grid is visible on the schedule.")> _
		Public Property AllowGrid() As Boolean
			Get
				Return m_AllowGrid
			End Get
			Set(ByVal Value As Boolean)
				If m_AllowGrid <> Value Then
					m_AllowGrid = Value
					OnRefresh()
				End If
			End Set
		End Property

		''' <summary>
		''' Determines if the schedule redraws during a scrolling operation.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_DynamicScroll), _
		Description("Determines if the schedule redraws during a scrolling operation.")> _
		Public Property DynamicScroll() As Boolean
			Get
				Return m_DynamicScroll
			End Get
			Set(ByVal Value As Boolean)
				m_DynamicScroll = Value
			End Set
		End Property

		'Determines if foreign (non-appointment) drops are allowed on the schedule.
		''' <summary>
		''' Determines if non-appointments may be dropped on the schedule.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_AllowForeignDrops), _
		Description("Determines if non-appointments may be dropped on the schedule.")> _
		Public Property AllowForeignDrops() As Boolean
			Get
				Return m_AllowForeignDrops
			End Get
			Set(ByVal Value As Boolean)
				m_AllowForeignDrops = Value
			End Set
		End Property

		''' <summary>
		''' This determines if a drag tip is displayed when the user drags an appointment.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(m_def_AllowDragTip), _
		Description("This determines if a drag tip is displayed when the user drags an appointment.")> _
		Public Property AllowDragTip() As Boolean
			Get
				Return m_AllowDragTip
			End Get
			Set(ByVal Value As Boolean)
				m_AllowDragTip = Value
			End Set
		End Property

		'<Browsable(True), _
		'Category("Behavior"), _
		'DefaultValue(False), _
		'Description("")> _
		'Public Property EnforceBounds() As Boolean
		'  Get
		'    Return m_EnforceBounds
		'  End Get
		'  Set(ByVal Value As Boolean)
		'    m_EnforceBounds = Value
		'  End Set
		'End Property

		''' <summary>
		''' This determines if multiple appointments may be selected at the same time.
		''' </summary>
		''' <value></value>
		<Browsable(True), _
		Category("Behavior"), _
		DefaultValue(m_def_MultiSelect), _
		Description("This determines if multiple appointments may be selected at the same time.")> _
		Public Property MultiSelect() As Boolean
			Get
				Return m_MultiSelect
			End Get
			Set(ByVal Value As Boolean)
				m_MultiSelect = Value

				'If turn OFF multiselect, then make sure that there is [0,1] appointments selected
				If Not Value Then
					Dim lockKey As String = PrepareForProcessing()
					Call Me.SelectedItems.Clear()
					Me.SelectedItems.Add(Me.SelectedItem)
					Me.PrepareForProcessing(lockKey)
					OnRefresh()
				End If

			End Set
		End Property

		''' <summary>
		''' This determines the way in which conflicts are displayed visually.
		''' </summary>
		''' <value></value>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(ConflictDisplayConstants), "SideBySide"), _
		Description("This determines the way in which conflicts are displayed visually.")> _
		Public Property ConflictDisplay() As ConflictDisplayConstants
			Get
				Return m_ConflictDisplay
			End Get
			Set(ByVal Value As ConflictDisplayConstants)
				m_ConflictDisplay = Value
				Try
					Me.DrawingDirty = True
					OnRefresh()
				Catch ex As Exceptions.GravityboxException
					ErrorModule.SetErr(ex)
				Catch ex As Exception
					ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

		''' <summary>
		''' Determines how appointments are displayed when selected.
		''' </summary>
		''' <value></value>
		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(GetType(SelectionTypeConstants), "BorderOnly"), _
		Description("Determines how appointments are displayed when selected.")> _
		Public Property SelectionType() As SelectionTypeConstants
			Get
				Return m_SelectionType
			End Get
			Set(ByVal Value As SelectionTypeConstants)
				If m_SelectionType <> Value Then
					m_SelectionType = Value
					OnRefresh()
				End If
			End Set
		End Property

#If VS2005 Then
        ''' <summary>
        ''' Determines if the tooltips are displayed as a balloon
        ''' </summary>
        ''' <value></value>
        <Browsable(True), _
        Category("Behavior"), _
        Description("Determines if the tooltips are displayed as a balloon."), _
        DefaultValue(m_def_ToolTipIsBalloon)> _
        Public Property ToolTipIsBalloon() As Boolean
            Get
                Return m_ToolTipIsBalloon
            End Get
            Set(ByVal Value As Boolean)
                m_ToolTipIsBalloon = Value
                Me.ToolTip1.IsBalloon = m_ToolTipIsBalloon
            End Set
        End Property
#End If

        ''' <summary>
        ''' Determines the length of time the tool tip window remains visible if the pointer is stationary inside a tool tip region.
        ''' </summary>
        ''' <value></value>
		<Browsable(True), _
		Category("Behavior"), _
		Description("Determines the length of time the tool tip window remains visible if the pointer is stationary inside a tool tip region."), _
		DefaultValue(m_def_ToolTipAutoPopDelay)> _
		Public Property ToolTipAutoPopDelay() As Integer
			Get
				Return m_ToolTipAutoPopDelay
			End Get
			Set(ByVal Value As Integer)
				m_ToolTipAutoPopDelay = Value
				Me.ToolTip1.AutoPopDelay = m_ToolTipAutoPopDelay
			End Set
		End Property

		''' <summary>
		''' Gets or sets the time that passes before the ToolTip appears.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		Description("Gets or sets the time that passes before the ToolTip appears."), _
		DefaultValue(m_def_ToolTipInitialDelay)> _
		Public Property ToolTipInitialDelay() As Integer
			Get
				Return m_ToolTipInitialDelay
			End Get
			Set(ByVal Value As Integer)
				m_ToolTipInitialDelay = Value
				Me.ToolTip1.InitialDelay = m_ToolTipInitialDelay
			End Set
		End Property

		''' <summary>
		''' Gets or sets a value indicating whether a ToolTip window is displayed even when its parent control is not active.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		Description("Gets or sets a value indicating whether a ToolTip window is displayed even when its parent control is not active."), _
		DefaultValue(m_def_ToolTipShowAlways)> _
		Public Property ToolTipShowAlways() As Boolean
			Get
				Return m_ToolTipShowAlways
			End Get
			Set(ByVal Value As Boolean)
				m_ToolTipShowAlways = Value
				Me.ToolTip1.ShowAlways = m_ToolTipShowAlways
			End Set
		End Property

		''' <summary>
		''' Gets or sets the length of time that must transpire before subsequent ToolTip windows appear as the mouse pointer moves from one control to another.
		''' </summary>
		<Browsable(True), _
		Category("Behavior"), _
		Description("Gets or sets the length of time that must transpire before subsequent ToolTip windows appear as the mouse pointer moves from one control to another."), _
		DefaultValue(m_def_ToolTipReshowDelay)> _
		Public Property ToolTipReshowDelay() As Integer
			Get
				Return m_ToolTipReshowDelay
			End Get
			Set(ByVal Value As Integer)
				m_ToolTipReshowDelay = Value
				Me.ToolTip1.ReshowDelay = m_ToolTipReshowDelay
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		Description("Determines if the headers for objects are drawn according to the RowHeader and ColumnHeader Appearance objects or use the Appearance object of each room, provider, or resource object."), _
		DefaultValue(m_def_UseDefaultDrawnHeaders)> _
		Public Property UseDefaultDrawnHeaders() As Boolean
			Get
				Return m_UseDefaultDrawnHeaders
			End Get
			Set(ByVal Value As Boolean)
				m_UseDefaultDrawnHeaders = Value
				Me.DrawingDirty = True
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of selected appointments if the AllowSelectedAppearance property is set.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of selected appointments if the AllowSelectedAppearance property is set.")> _
		Public Property SelectedAppointmentAppearance() As Gravitybox.Objects.AppointmentAppearance
			Get
				Return m_SelectedAppointmentAppearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.AppointmentAppearance)
				'This object can never be null
				If Value Is Nothing Then Value = New Gravitybox.Objects.AppointmentAppearance
				RemoveHandler m_SelectedAppointmentAppearance.Refresh, AddressOf OnRefresh
				m_SelectedAppointmentAppearance = Value
				AddHandler m_SelectedAppointmentAppearance.Refresh, AddressOf OnRefresh
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of the header of selected appointments if the AllowSelectedAppearance property is set.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of the header of selected appointments if the AllowSelectedAppearance property is set.")> _
		Public Property SelectedAppointmentHeaderAppearance() As Gravitybox.Objects.AppointmentHeaderAppearance
			Get
				Return m_SelectedAppointmentHeaderAppearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.AppointmentHeaderAppearance)
				'This object can never be null
				If Value Is Nothing Then Value = New Gravitybox.Objects.AppointmentHeaderAppearance
				RemoveHandler m_SelectedAppointmentHeaderAppearance.Refresh, AddressOf OnRefresh
				m_SelectedAppointmentHeaderAppearance = Value
				AddHandler m_SelectedAppointmentHeaderAppearance.Refresh, AddressOf OnRefresh
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of a newly created appointment.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of a newly created appointment.")> _
		Public Property DefaultAppointmentAppearance() As AppointmentAppearance
			Get
				Return m_DefaultAppointmentAppearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.AppointmentAppearance)
				'This object can never be null
				If Value Is Nothing Then Value = New Gravitybox.Objects.AppointmentAppearance
				m_DefaultAppointmentAppearance = Value
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of the header of a newly created appointment.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of the header of a newly created appointment.")> _
		Public Property DefaultAppointmentHeaderAppearance() As AppointmentHeaderAppearance
			Get
				Return m_DefaultAppointmentHeaderAppearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.AppointmentHeaderAppearance)
				'This object can never be null
				If Value Is Nothing Then Value = New Gravitybox.Objects.AppointmentHeaderAppearance
				m_DefaultAppointmentHeaderAppearance = Value
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of the main schedule.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of the main schedule.")> _
		Public Property Appearance() As Gravitybox.Objects.GridAppearance
			Get
				Return m_Appearance
			End Get
			Set(ByVal Value As Gravitybox.Objects.GridAppearance)
				'This object can never be null
				If Value Is Nothing Then Value = New Gravitybox.Objects.GridAppearance
				RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
				m_Appearance = Value
				AddHandler m_Appearance.Refresh, AddressOf OnRefresh
				OnRefresh()
			End Set
		End Property

		''' <summary>
		''' This object determines the appearance of the event header.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		Description("This object determines the appearance of the event header.")> _
		Public ReadOnly Property EventHeader() As Gravitybox.Objects.EventHeader
			Get
				Return m_EventHeader
			End Get
		End Property

		''' <summary>
		''' This collection holds a set of room objects.
		''' </summary>
		<Browsable(True), _
		Category("Data"), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
		TypeConverter(GetType(Gravitybox.Design.Converters.RoomCollectionConverter)), _
		Description("This collection holds a set of room objects.")> _
		Public Shadows ReadOnly Property DataBindings() As Gravitybox.Data.DataBindingRoot
			Get
				Return m_DataBindings
			End Get
		End Property

		''' <summary>
		''' Determines if the header can be resized or not.
		''' </summary>
		<Browsable(False)> _
		Public ReadOnly Property IsHeaderFixed() As Boolean
			Get
				Select Case Me.ViewMode
					Case ViewModeConstants.Month
						Return True
					Case ViewModeConstants.MonthFull
						Return True
					Case ViewModeConstants.Week
						Return True
				End Select
				Return False
			End Get
		End Property

		''' <summary>
		''' Determines if newly added appointment inherit there appearance from the defaults.
		''' </summary>
		<Browsable(True), _
		DefaultValue(m_def_UseDefaultAppearances), _
		Description("Determines if newly added appointment inherit there appearance from the defaults.")> _
		Public Property UseDefaultAppearances() As Boolean
			Get
				Return m_UseDefaultAppearances
			End Get
			Set(ByVal value As Boolean)
				m_UseDefaultAppearances = value
			End Set
		End Property

		'''' <summary>
		'''' Determines if colored bars are drawn next in the column margin or in the schedule's left margin
		'''' </summary>
		'<Browsable(True), _
		'DefaultValue(m_def_UseColumnBars), _
		'Description("Determines if colored bars are drawn next in the column margin or in the schedule's left margin.")> _
		'Public Property UseColumnBars() As Boolean
		'  Get
		'    Return m_UseColumnBars
		'  End Get
		'  Set(ByVal value As Boolean)
		'    m_UseColumnBars = value
		'    Me.Refresh()
		'  End Set
		'End Property

		Friend ReadOnly Property SyncRoot() As Object
			Get
				Return _syncRoot
			End Get
		End Property

#End Region

#Region "Custom Friend Properties"

		Friend Function IsDateInRange(ByVal testDate As DateTime) As Boolean

			If (Me.MinDate <= testDate) AndAlso (testDate <= Me.MaxDate) Then
				Return True
			Else
				Return False
			End If

		End Function

		Friend Function IsTimeInRange(ByVal testTime As DateTime) As Boolean
			Return IsTimeInRange(testTime, 0)
		End Function

		Friend Function IsTimeInRange(ByVal testTime As DateTime, ByVal length As Integer) As Boolean

			testTime = GetTime(testTime)
			Dim testEndTime As DateTime = DateAdd(DateInterval.Minute, length, GetTime(testTime))
			If (Me.StartTime <= testTime) AndAlso (testTime <= Me.EndTime) AndAlso _
			 (Me.StartTime <= testEndTime) AndAlso (testEndTime <= Me.EndTime) Then
				Return True
			Else
				Return False
			End If

		End Function

		Friend Function GetTimeMarginWidth(ByVal timeOnly As Boolean) As Integer
			Dim theFont As Font = CreateFont(Me.RowHeader.Appearance, Me.Font.FontFamily)
			Return GetTimeMarginWidth(timeOnly, theFont)
		End Function

		Friend Function GetTimeMarginWidth(ByVal timeOnly As Boolean, ByVal theFont As Font) As Integer

			'If the parameter "timeOnly" is true then only the area where time is drawn is returned
			'The left side from 0 -> time margin where the bars are drawn is ignored
			'When this parameter is false the entire margin width is return bar area and all

			Dim retval As Integer
			If Me.MinutesShown = MinutesShownConstants.Normal Then
				retval = TextWidth("12:00", theFont) + (ScheduleGlobals.TextMargin * 5)
			Else
				retval = TextWidth("1212  00", theFont) + (ScheduleGlobals.TextMargin * 5)
			End If

			If Not timeOnly Then
				Select Case TimeBar.BarType
					Case AppointmentBarConstants.Category
						retval += Me.CategoryCollection.Count * TimeBar.Size
					Case AppointmentBarConstants.Provider
						retval += Me.ProviderCollection.VisibleCount * TimeBar.Size
					Case AppointmentBarConstants.Resource
						retval += Me.ResourceCollection.Count * TimeBar.Size
					Case AppointmentBarConstants.None
						'Do Nothing
					Case AppointmentBarConstants.UserDrawn
						retval += TimeBar.Size
				End Select
			End If
			Return retval

		End Function

		Friend ReadOnly Property DateMarginWidth() As Integer
			Get
				Dim theFont As Font = CreateFont(Me.RowHeader.Appearance, Me.Font.FontFamily)
				Dim DateCurrent As DateTime = #10/23/2002#
				Return TextWidth(DateCurrent.ToString(Me.HeaderDateFormat), theFont) + (ScheduleGlobals.TextMargin * 2)
			End Get
		End Property

		Friend ReadOnly Property EventItemHeight() As Integer
			Get
				Return TextHeight(Me.Font) + (TextMargin * 2)
			End Get
		End Property

		Friend ReadOnly Property EventHeaderHeight() As Integer
			Get
				If Me.EventHeader.SupportedViewmode(Me.ViewMode) Then
					If Me.EventHeader.AllowHeader And Me.EventHeader.IsExpanded Then
						'Return the number of events/activites for this date range as well as a 1/2 height buffer
						'Each item takes apace = EventItemHeight plus the event buffer
						Dim retval As Integer = AppointmentCollection.EventAppointmentCount * (EventItemHeight + (EventHeader.EventHeaderBuffer * 2))
						Return retval + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.BottomBuffer
					End If
				End If
				Return 0
			End Get
		End Property

		Friend ReadOnly Property ClientLeft(ByVal newViewmode As ViewModeConstants) As Integer
			Get

				If Me.HasDisposed Then Return 0
				Try
					Dim theFont As Font = CreateFont(Me.RowHeader.Appearance, Me.Font.FontFamily)
					Select Case newViewmode
						Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
							Return GetTimeMarginWidth(False, theFont)
						Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.RoomLeftProviderTop						', ViewModeConstants.DayTimeTopRoomLeft
							Return Me.RoomCollection.GetLeftMarginWidth(Me.CreateGraphics, theFont) + (ScheduleGlobals.TextMargin * 2)
						Case ViewModeConstants.DayTopProviderLeft, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.ProviderLeftTimeTop
							Return Me.ProviderCollection.GetLeftMarginWidth(Me.CreateGraphics, theFont) + (ScheduleGlobals.TextMargin * 2)
						Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.DayLeftProviderTop, ViewModeConstants.DayLeftResourceTop
							Return DateMarginWidth
						Case ViewModeConstants.DayRoomLeftTimeTop
							Return Me.RoomCollection.GetLeftMarginWidth(Me.CreateGraphics, theFont) + (ScheduleGlobals.TextMargin * 2) + DateMarginWidth
						Case ViewModeConstants.DayProviderLeftTimeTop
							Return Me.ProviderCollection.GetLeftMarginWidth(Me.CreateGraphics, theFont) + (ScheduleGlobals.TextMargin * 2) + DateMarginWidth
						Case ViewModeConstants.Month
							Return 0
						Case ViewModeConstants.DayTimeLeftProviderTop
							Return DateMarginWidth + GetTimeMarginWidth(False, theFont)
						Case ViewModeConstants.DayTimeLeftRoomTop
							Return DateMarginWidth + GetTimeMarginWidth(False, theFont)
						Case ViewModeConstants.Week
							Return 0
						Case ViewModeConstants.MonthFull
							Return 0
						Case ViewModeConstants.ResourceLeftTimeTop
							Return Me.ResourceCollection.GetLeftMarginWidth(Me.CreateGraphics, theFont) + (ScheduleGlobals.TextMargin * 2)
						Case Else
							Call ErrorModule.ViewmodeErr()
					End Select

				Catch ex As Exceptions.GravityboxException
					ErrorModule.SetErr(ex)
				Catch ex As Exception
					ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

		Friend ReadOnly Property ClientLeft() As Integer
			Get
				Try
					Return ClientLeft(Me.ViewMode)
				Catch ex As Exceptions.GravityboxException
					ErrorModule.SetErr(ex)
				Catch ex As Exception
					ErrorModule.SetErr(ex)
				End Try
			End Get
		End Property

		Friend ReadOnly Property ClientTop(ByVal newViewMode As ViewModeConstants) As Integer
			Get

				Try
					Dim theFont As Font = CreateFont(Me.ColumnHeader.Appearance, Me.Font.FontFamily)
					Select Case newViewMode
						Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayTopProviderLeft
							Dim text As String = Me.HeaderDateFormat
							text = text.Replace(ControlChars.CrLf, ControlChars.Cr)
							text = text.Replace(ControlChars.Lf, ControlChars.Cr)
							Dim lines As Integer = text.Length - text.Replace(ControlChars.Cr, "").Length + 1
							Return (Me.TextHeight(theFont) * lines) + (TextMargin * 2) + EventHeaderHeight
						Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
							Return Me.TextHeight(theFont) + (TextMargin * 2)
						Case ViewModeConstants.DayLeftRoomTop, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.DayTimeLeftRoomTop
							'Return (Me.TextHeight(theFont) * Me.RoomCollection.MaxLineCount) + (TextMargin * 2) + EventHeaderHeight
							Return GetColumnHeight(theFont, Me.RoomCollection) + EventHeaderHeight
						Case ViewModeConstants.DayLeftProviderTop, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayTimeLeftProviderTop
							'Return (Me.TextHeight(theFont) * Me.ProviderCollection.MaxLineCount) + (TextMargin * 2) + EventHeaderHeight
							Return GetColumnHeight(theFont, Me.ProviderCollection) + EventHeaderHeight
						Case ViewModeConstants.DayRoomTopTimeLeft
							Dim text As String = Me.HeaderDateFormat
							text = text.Replace(ControlChars.CrLf, ControlChars.Cr)
							text = text.Replace(ControlChars.Lf, ControlChars.Cr)
							Dim lines As Integer = text.Length - text.Replace(Chr(13), "").Length + 1
							'lines += Me.RoomCollection.MaxLineCount
							Dim roomHeight As Integer = GetColumnHeight(theFont, Me.RoomCollection)
							'Return (Me.TextHeight(theFont) * lines) + (TextMargin * 4) + EventHeaderHeight
							Return (Me.TextHeight(theFont) * lines) + roomHeight + (TextMargin * 2) + EventHeaderHeight
						Case ViewModeConstants.DayProviderTopTimeLeft
							Dim text As String = Me.HeaderDateFormat
							text = text.Replace(ControlChars.CrLf, ControlChars.Cr)
							text = text.Replace(ControlChars.Lf, ControlChars.Cr)
							Dim lines As Integer = text.Length - text.Replace(Chr(13), "").Length + 1
							'lines += Me.RoomCollection.MaxLineCount
							Dim providerHeight As Integer = GetColumnHeight(theFont, Me.ProviderCollection)
							'Return (Me.TextHeight(theFont) * lines) + (TextMargin * 4) + EventHeaderHeight
							Return (Me.TextHeight(theFont) * lines) + providerHeight + (TextMargin * 2) + EventHeaderHeight
						Case ViewModeConstants.Month
							'Day header size + double font for "Month YYYY"
							Return Me.TextHeight(theFont) * 3
						Case ViewModeConstants.Week
							Return 0
						Case ViewModeConstants.MonthFull
							'Day header size + double font for "Month YYYY"
							Return Me.TextHeight(theFont) * 3
						Case ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.DayLeftResourceTop
							'Return (Me.TextHeight(theFont) * Me.ResourceCollection.MaxLineCount) + (TextMargin * 2) + EventHeaderHeight
							Return GetColumnHeight(theFont, Me.ResourceCollection) + EventHeaderHeight
						Case Else
							Call ErrorModule.ViewmodeErr()
					End Select

				Catch ex As Exceptions.GravityboxException
					ErrorModule.SetErr(ex)
				Catch ex As Exception
					ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

		Friend ReadOnly Property ClientTop() As Integer
			Get
				Return ClientTop(Me.ViewMode)
			End Get
		End Property

		Friend ReadOnly Property ClientWidth() As Integer
			Get
				If ViewMode = ViewModeConstants.Month Then
					Return CanvasWidth
				ElseIf ViewMode = ViewModeConstants.MonthFull Then
					Return CanvasWidth
				ElseIf ViewMode = ViewModeConstants.Week Then
					Return CanvasWidth
				Else
					Return Me.Visibility.VisibleColumns * Me.ColumnHeader.Size
				End If
			End Get
		End Property

		Friend ReadOnly Property ClientHeight() As Integer
			Get
				If ViewMode = ViewModeConstants.Month Then
					Return CanvasHeight
				ElseIf ViewMode = ViewModeConstants.MonthFull Then
					Return CanvasHeight
				ElseIf ViewMode = ViewModeConstants.Week Then
					Return CanvasHeight
				Else
					Return Me.Visibility.VisibleRows * Me.RowHeader.Size
				End If
			End Get
		End Property

		''' <summary>
		''' Defines the grid rectangle without any headers.
		''' </summary>
		<Browsable(False)> _
		Public ReadOnly Property GridRectangle() As Rectangle
			Get
				Return New Rectangle(Me.ClientLeft, Me.ClientTop, Me.ClientWidth, Me.ClientHeight)
			End Get
		End Property

		Private cachedViewPort As Rectangle = New Rectangle
		Friend ReadOnly Property ViewPort() As Rectangle
			Get
				If cachedViewPort.IsEmpty Then
					'cachedViewPort = New Rectangle(Me.ClientLeft, Me.ClientTop, Me.ClientWidth, Me.ClientHeight)
					cachedViewPort = New Rectangle(Me.ClientLeft, Me.ClientTop - Me.EventHeaderHeight, Me.ClientWidth, Me.ClientHeight + Me.EventHeaderHeight)
				End If
				Return cachedViewPort
			End Get
		End Property

		Friend ReadOnly Property TopHeaderHeight() As Integer
			Get
				'This is the height of the top header margin 
				'It does NOT include the event header just the date,room,etc headers
				Return ClientTop - EventHeaderHeight
			End Get
		End Property

		Friend ReadOnly Property CanvasWidth() As Integer
			Get

				'If printing and Autofit then width is the page width
				If Me.Visibility.IsPrinting AndAlso Me.ColumnHeader.AutoFit Then
					Return Me.Visibility.PrinterPageWidth - Me.ClientLeft
				End If

				'If the vertical ScrollBar is visible then compensate for its size
				If (Me.ScrollBars = ScrollBars.Vertical) OrElse (Me.ScrollBars = ScrollBars.Both) Then
					Return Me.Width - Me.ClientLeft - VScroll1.Width
				Else
					Return Me.Width - Me.ClientLeft
				End If

			End Get
		End Property

		Friend ReadOnly Property CanvasHeight() As Integer
			Get

				'If printing and Autofit then height is the page width
				If Me.Visibility.IsPrinting AndAlso Me.RowHeader.AutoFit Then
					Return Me.Visibility.PrinterPageHeight - Me.ClientTop
				End If

				'If the horizontal ScrollBar is visible then compensate for its size
				If (Me.ScrollBars = ScrollBars.Horizontal) OrElse (Me.ScrollBars = ScrollBars.Both) Then
					Return Me.Height - Me.ClientTop - HScroll1.Height
				Else
					Return Me.Height - Me.ClientTop
				End If

			End Get
		End Property

		Friend Function TextWidth(ByVal text As String, ByVal theFont As Font) As Integer
			If Me.HasDisposed Then Return 0
			Dim g As Graphics = Me.CreateGraphics
			Return TextWidth(g, text, theFont)
			Call g.Dispose()
		End Function

		Friend Function TextWidth(ByVal g As Graphics, ByVal text As String, ByVal theFont As Font) As Integer

			'Try to error correct
			If theFont Is Nothing Then
				theFont = Me.Font
			End If

			Dim size As SizeF = g.MeasureString(text, theFont)
			Return GetIntlInteger(size.Width)

		End Function

		Friend Function TextHeight(ByVal theFont As Font) As Integer
			If Me.HasDisposed Then Return 0
			Dim g As Graphics = Me.CreateGraphics
			Return TextHeight(g, theFont)
			Call g.Dispose()
		End Function

		Friend Function TextHeight(ByVal g As Graphics, ByVal theFont As Font) As Integer
			Dim size As SizeF = g.MeasureString("W", theFont)
			Return GetIntlInteger(size.Height)
		End Function

#End Region

#Region "Method Implementations"

		Private Function GetColumnHeight(ByVal theFont As Font, ByVal collection As BaseObjectCollection) As Integer

			Try
				Dim maxHeight As Integer = 0
				Dim g As Graphics = Me.CreateGraphics
				For Each baseObject As BaseObject In collection
					Dim size As SizeF = New SizeF(Me.ColumnHeader.Size, 0)
					Dim format As StringFormat = CreateStringFormat(Me.ColumnHeader.Appearance)
					Dim size2 As SizeF = g.MeasureString(baseObject.Text, theFont, size, format)
					Dim newValue As Integer = CInt(size2.Height)
					If (maxHeight < newValue) Then maxHeight = newValue
				Next
				Return maxHeight + (TextMargin * 2) + 2

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Binds the datasource to the schedule.
		''' </summary>
		<Description("Binds the datasource to the schedule.")> _
		Public Sub Bind()
			Try
				DataBinder.DataSource = Me.DataSource

				'Try to reselect the old appointments
				Dim list As New ArrayList
				For Each appointment As Appointment In Me.SelectedItems
					list.Add(appointment.Key)
				Next
				Me.SelectedItems.Clear()
				For Each key As String In list
					If Me.AppointmentCollection.Contains(key) Then
						Me.SelectedItems.Add(Me.AppointmentCollection(key))
					End If
				Next

				'If there are SelectedItems and NO SelectedItem then set the later
				If (Me.SelectedItems.Count > 0) AndAlso (Me.SelectedItem Is Nothing) Then
					m_SelectedItem = CType(Me.SelectedItems(0), Appointment)
				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Friend Sub SetDefaultAppearance()
			Try
				Me.Appearance.FromXML((New Appearance).ToXML)
				Me.Appearance.BackColor = Color.White
				Me.Appearance.ForeColor = Color.DarkGray
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Friend Sub SetDefaultRowColAppearance()
			Try
				ColumnHeader.SetDefaultAppearance()
				ColumnHeader.Appearance.Alignment = StringAlignment.Center
				RowHeader.SetDefaultAppearance()
				RowHeader.Appearance.Alignment = StringAlignment.Near
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Friend Sub SetDefaultSelectedAppearance()
			Try
				Me.SelectedAppointmentAppearance.FromXML((New AppointmentAppearance).ToXML)
				Me.SelectedAppointmentAppearance.BorderColor = Color.Black
				Me.SelectedAppointmentAppearance.BorderWidth = 3

				Me.SelectedAppointmentHeaderAppearance.FromXML((New AppointmentHeaderAppearance).ToXML)
				Me.SelectedAppointmentHeaderAppearance.BorderColor = Color.Black
				Me.SelectedAppointmentHeaderAppearance.BorderWidth = 3
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		''' <summary>
		''' This method forces a redraw of the schedule display.
		''' </summary>
		<Browsable(False), _
		Description("This method forces a redraw of the schedule display."), _
		MethodImpl(MethodImplOptions.Synchronized)> _
		Public Overrides Sub Refresh()

			If (Canvas Is Nothing) Then Return
			If Me.HasDisposed Then Return
			If Not SafeRedraw Then Return

			'If Not Monitor.TryEnter(Me, 5000) Then Return
			Try
				Call SetupScroll()
				Call Canvas.InternalRefresh(OffScreenGraphics)
				If AutoRedraw And SafeRedraw Then
					Dim g As Graphics = Me.CreateGraphics
					Call Canvas.DrawXORRectangle(OffScreenGraphics, AppointmentOutline.DragRectArray, 3)
					g.DrawImage(OffScreenImage, 0, 0)
					Call g.Dispose()
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'Monitor.Exit(Me)
			End Try

		End Sub

		Private Sub SetDimensions()
			Try
				If (Me.Width <= 0) OrElse (Me.Height <= 0) Then
					Me.OffScreenImage = New Bitmap(1, 1)
				Else
					Me.OffScreenImage = New Bitmap(Me.Width, Me.Height)
				End If
				Me.OffScreenGraphics = Graphics.FromImage(OffScreenImage)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		''' <summary>
		''' This method will cause appointment conflicts to be recalculated for display on the schedule.
		''' </summary>
		<Browsable(False), _
		Description("This method will cause appointment conflicts to be recalculated for display on the schedule.")> _
		Public Sub RecalculateConflicts()
			Try
				Me.DrawingDirty = True
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		'Ensure that the StartTime and DayLength do not have invalid states
		Private Sub CheckStartTimeDayLength()

			Try
				'Set this to an even hour boundary
				'The day legnth must be at least one hour so LATEST StarttTime is 23:00
				m_StartTime = GetTime(m_StartTime, True)
				If m_StartTime > #11:00:00 PM# Then m_StartTime = #11:00:00 PM#

				'Ensure that Daylength is valid
				Dim nextDay As Date = PivotTime.AddDays(1)
				Dim hours As Integer = GetIntlInteger(nextDay.Subtract(Me.StartTime).TotalHours)
				If m_DayLength > hours Then m_DayLength = hours
				If m_DayLength > 24 Then m_DayLength = 24

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend Sub SetupScroll()

			Dim colCount As Integer
			Dim rowCount As Integer
			Dim columnMaxSetting As Integer
			Dim rowMaxSetting As Integer
			Dim VR As Integer = Me.Visibility.VisibleRowsNoCorrection
			Dim VC As Integer = Me.Visibility.VisibleColumnsNoCorrection
			Dim lAbsWidth As Integer = (VC * Me.ColumnHeader.Size)
			Dim lAbsHeight As Integer = (VR * Me.RowHeader.Size)
			Dim HLargeChange As Integer = 0
			Dim VLargeChange As Integer = 0
			Dim HAutoFitEnabled As Boolean = False
			Dim VAutoFitEnabled As Boolean = False

			Try

				Select Case Me.ViewMode
					Case ViewModeConstants.DayLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1

					Case ViewModeConstants.DayRoomLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						rowCount *= Me.RoomCollection.VisibleCount					 '(days * rooms)

					Case ViewModeConstants.DayProviderLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						rowCount *= Me.ProviderCollection.VisibleCount					 '(days * rooms)

					Case ViewModeConstants.DayRoomTopTimeLeft
						colCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						colCount *= Me.RoomCollection.VisibleCount					 '(days * rooms)
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case ViewModeConstants.DayProviderTopTimeLeft
						colCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						colCount *= Me.ProviderCollection.VisibleCount					 '(days * rooms)
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case ViewModeConstants.DayTopTimeLeft
						colCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case ViewModeConstants.RoomLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = Me.RoomCollection.VisibleCount

					Case ViewModeConstants.RoomTopTimeLeft
						colCount = Me.RoomCollection.VisibleCount
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case ViewModeConstants.DayLeftRoomTop
						colCount = Me.RoomCollection.VisibleCount
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1

					Case ViewModeConstants.DayLeftResourceTop
						colCount = Me.ResourceCollection.VisibleCount
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1

					Case ViewModeConstants.DayTopRoomLeft
						colCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						rowCount = Me.RoomCollection.VisibleCount

					Case ViewModeConstants.DayLeftProviderTop
						colCount = Me.ProviderCollection.VisibleCount
						rowCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1

					Case ViewModeConstants.DayTopProviderLeft
						colCount = GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						rowCount = Me.ProviderCollection.VisibleCount

					Case ViewModeConstants.RoomLeftProviderTop
						colCount = Me.ProviderCollection.VisibleCount
						rowCount = Me.RoomCollection.VisibleCount

					Case ViewModeConstants.RoomTopProviderLeft
						colCount = Me.RoomCollection.VisibleCount
						rowCount = Me.ProviderCollection.VisibleCount

					Case ViewModeConstants.ProviderLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = Me.ProviderCollection.VisibleCount

					Case ViewModeConstants.ProviderTopTimeLeft
						colCount = Me.ProviderCollection.VisibleCount
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case ViewModeConstants.Month
						Dim dateStart As DateTime = MinDate
						Dim dateEnd As DateTime = MaxDate
						colCount = 6
						rowCount = Me.Visibility.TotalRowCount

					Case ViewModeConstants.DayTimeLeftProviderTop
						colCount = Me.ProviderCollection.VisibleCount
						rowCount = Me.Visibility.TotalRowCount

					Case ViewModeConstants.DayTimeLeftRoomTop
						colCount = Me.RoomCollection.VisibleCount
						rowCount = Me.Visibility.TotalRowCount

						'Case ViewModeConstants.DayTimeTopRoomLeft
						'  colCount = (GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)) + GetIntlInteger(DateDiff(DateInterval.Day, Me.MinDate, Me.MaxDate)) + 1
						'  rowCount = Me.RoomCollection.VisibleCount

					Case ViewModeConstants.Week
						colCount = 2
						rowCount = 3

					Case ViewModeConstants.MonthFull
						Dim dateStart As DateTime = MinDate
						Dim dateEnd As DateTime = MaxDate
						colCount = Me.Visibility.TotalColumnCount
						rowCount = Me.Visibility.TotalRowCount

					Case ViewModeConstants.ResourceLeftTimeTop
						colCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)
						rowCount = Me.ResourceCollection.Count

					Case ViewModeConstants.ResourceTopTimeLeft
						colCount = Me.ResourceCollection.Count
						rowCount = GetIntlInteger(DateDiff(DateInterval.Minute, Me.StartTime, Me.EndTime)) \ GetIntlInteger(Me.TimeIncrement)

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select

				'Fit the column if need be
				ColumnHeader.FrameIncrementActual = 0
				ColumnHeader.PerfectFit = True
				If ColumnHeader.AutoFit AndAlso (Me.ViewMode <> ViewModeConstants.Month) AndAlso (Me.ViewMode <> ViewModeConstants.MonthFull) Then
					If ColumnHeader.FrameIncrement > 0 Then
						Call ColumnHeader.SetSize(Me.CanvasWidth \ ColumnHeader.FrameIncrement)
						ColumnHeader.FrameIncrementActual = Me.Visibility.VisibleColumnsNoCorrection
						columnMaxSetting = colCount \ ColumnHeader.FrameIncrementActual
						If (colCount Mod ColumnHeader.FrameIncrementActual) = 0 Then columnMaxSetting -= 1
						VC = 1
						HLargeChange = 1
						HAutoFitEnabled = (columnMaxSetting > 1)
					ElseIf colCount > 0 Then
						Call ColumnHeader.SetSize(Me.CanvasWidth \ colCount)
						ColumnHeader.FrameIncrementActual = Me.Visibility.VisibleColumnsNoCorrection
						HLargeChange = GetIntlInteger(IIf(VC > 0, VC, 1))
						columnMaxSetting = colCount - 1
					End If
				Else
					HLargeChange = GetIntlInteger(IIf(VC > 0, VC, 1))
					columnMaxSetting = colCount
				End If

				'Fit the column if need be
				RowHeader.FrameIncrementActual = 0
				RowHeader.PerfectFit = True
				If RowHeader.AutoFit AndAlso (Me.ViewMode <> ViewModeConstants.Month) AndAlso (Me.ViewMode <> ViewModeConstants.MonthFull) Then
					If RowHeader.FrameIncrement > 0 Then
						Call RowHeader.SetSize(Me.CanvasHeight \ RowHeader.FrameIncrement)
						RowHeader.FrameIncrementActual = Me.Visibility.VisibleRowsNoCorrection
						rowMaxSetting = rowCount \ RowHeader.FrameIncrementActual
						If (rowCount Mod RowHeader.FrameIncrementActual) = 0 Then rowMaxSetting -= 1
						VR = 1
						VLargeChange = 1
						VAutoFitEnabled = (columnMaxSetting > 1)
					ElseIf rowCount > 0 Then
						Call RowHeader.SetSize(Me.CanvasHeight \ rowCount)
						RowHeader.FrameIncrementActual = Me.Visibility.VisibleRowsNoCorrection
						VLargeChange = GetIntlInteger(IIf(VR > 0, VR, 1))
						rowMaxSetting = rowCount - 1
					End If
				Else
					VLargeChange = GetIntlInteger(IIf(VR > 0, VR, 1))
					rowMaxSetting = rowCount
				End If

				Select Case Me.ScrollBars
					Case ScrollBars.Both
						VScroll1.Visible = True And Not Me.NoDrawing
						HScroll1.Visible = True And Not Me.NoDrawing
					Case ScrollBars.Horizontal
						VScroll1.Visible = False And Not Me.NoDrawing
						HScroll1.Visible = True And Not Me.NoDrawing
					Case ScrollBars.None
						VScroll1.Visible = False And Not Me.NoDrawing
						HScroll1.Visible = False And Not Me.NoDrawing
					Case ScrollBars.Vertical
						VScroll1.Visible = True And Not Me.NoDrawing
						HScroll1.Visible = False And Not Me.NoDrawing
				End Select
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

			Try
				VScroll1.Minimum = 0
				If rowMaxSetting < 0 Then rowMaxSetting = 0
				VScroll1.Maximum = rowMaxSetting
				VScroll1.SmallChange = 1
				VScroll1.LargeChange = VLargeChange
				If (lAbsHeight <= GridHeight) AndAlso (rowMaxSetting = 1) Then
					VScrollEnabled = False
					VScroll1.Value = 0
				ElseIf RowHeader.AutoFit Then
					VScrollEnabled = True					'False
					'If Not VAutoFitEnabled Then VScroll1.Value = 0
				ElseIf VR > rowMaxSetting Then
					VScrollEnabled = True					'False
					VScroll1.Value = 0
				Else
					VScrollEnabled = True
				End If

				If columnMaxSetting < 0 Then columnMaxSetting = 0
				HScroll1.Minimum = 0
				HScroll1.Maximum = columnMaxSetting
				HScroll1.SmallChange = 1
				HScroll1.LargeChange = HLargeChange
				If (lAbsWidth <= GridWidth) AndAlso (columnMaxSetting = 1) Then
					HScrollEnabled = False
					HScroll1.Value = 0
				ElseIf ColumnHeader.AutoFit Then
					HScrollEnabled = True					'False
					'If Not HAutoFitEnabled Then HScroll1.Value = 0
				ElseIf VC > columnMaxSetting Then
					HScrollEnabled = True					'False
					HScroll1.Value = 0
				Else
					HScrollEnabled = True
				End If

				If VScroll1.Value > VScroll1.Maximum Then VScroll1.Value = VScroll1.Maximum
				If HScroll1.Value > HScroll1.Maximum Then HScroll1.Value = HScroll1.Maximum

				If VScroll1.Maximum <= VR - 1 Then VScrollEnabled = False
				If HScroll1.Maximum <= VC - 1 Then HScrollEnabled = False

				'If autofitting and all columns/rows visible then ensure that the scrollbar is disabled
				If HScrollEnabled AndAlso Me.ColumnHeader.AutoFit AndAlso (HScroll1.Maximum < Me.Visibility.VisibleColumns) Then
					HScrollEnabled = False
				End If
				If VScrollEnabled AndAlso Me.RowHeader.AutoFit AndAlso (VScroll1.Maximum < Me.Visibility.VisibleRows) Then
					VScrollEnabled = False
				End If

				VScroll1.Enabled = VScrollEnabled
				HScroll1.Enabled = HScrollEnabled

				'If the vertical scroll is disabled then ensure that the vertical scroll value is top most
				If Not VScroll1.Enabled Then VScroll1.Value = 0
				'If the horizontal scroll is disabled then ensure that the horizontal scroll value is left most
				If Not HScroll1.Enabled Then HScroll1.Value = 0

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend ReadOnly Property GridWidth() As Integer
			Get

				'If printing then entire canvas is visible
				If Me.Visibility.IsPrinting Then
					Return Me.ClientLeft + (Me.Visibility.TotalColumnCount * Me.ColumnHeader.Size)
				End If

				Select Case ScrollBars
					Case ScrollBars.Both, ScrollBars.Vertical
						Return Me.Width - Me.ClientLeft - VScroll1.Width
					Case ScrollBars.Horizontal, ScrollBars.None
						Return Me.Width - Me.ClientLeft
				End Select

			End Get
		End Property

		Friend ReadOnly Property GridHeight() As Integer
			Get

				'If printing then entire canvas is visible
				If Me.Visibility.IsPrinting Then
					Return Me.ClientTop + (Me.Visibility.TotalRowCount * Me.RowHeader.Size)
				End If

				Select Case ScrollBars
					Case ScrollBars.Both, ScrollBars.Horizontal
						Return Me.Height - Me.ClientTop - HScroll1.Height
					Case ScrollBars.None, ScrollBars.Vertical
						Return Me.Height - Me.ClientTop
				End Select

			End Get
		End Property

#End Region

#Region "Initialize"

		Private Sub Schedule()

			Call SetDimensions()

			Call Me.ColumnHeader.SetSize(100)
			Call Me.RowHeader.SetSize(30)

			m_AllowCopy = m_def_AllowCopy
			m_DayLength = m_def_DayLength
			m_StartTime = m_def_StartTime
			m_TimeIncrement = m_def_TimeIncrement
			m_BlockoutColor = m_def_BlockoutColor
			m_AppointmentResizing = m_def_AppointmentResizing
			m_AutoRedraw = m_def_AutoRedraw
			m_AllowAdd = m_def_AllowAdd
			m_AllowMove = m_def_AllowMove
			m_MinDate = m_def_MinDate
			m_MaxDate = m_def_MaxDate
			m_HeaderDateFormat = m_def_HeaderDateFormat
			m_HeaderTimeFormat = m_def_HeaderTimeFormat
			m_AllowRemove = m_def_AllowRemove
			m_ViewMode = m_def_ViewMode
			m_AllowInPlaceEdit = m_def_AllowInPlaceEdit
			m_FirstDayOfWeek = m_def_FirstDayOfWeek
			m_AppointmentSpace = m_def_AppointmentSpace
			m_ClockSetting = m_def_ClockSetting
			m_MinutesShown = m_def_MinutesShown
			m_ScrollBars = m_def_ScrollBars
			m_AllowSelector = m_def_AllowSelector
			m_AllowEvents = m_def_AllowEvents
			m_AllowGrid = m_def_AllowGrid
			Call SetDefaultAppearance()
			Call SetDefaultRowColAppearance()
			Call SetDefaultSelectedAppearance()

			'Hook the appearance objects so that the schedule knows when to refresh
			AddHandler m_SelectedAppointmentAppearance.Refresh, AddressOf OnRefresh
			AddHandler m_SelectedAppointmentHeaderAppearance.Refresh, AddressOf OnRefresh
			AddHandler m_Appearance.Refresh, AddressOf OnRefresh
			AddHandler m_ColumnHeader.Refresh, AddressOf OnRefresh
			AddHandler m_RowHeader.Refresh, AddressOf OnRefresh
			AddHandler m_TimeMarker.Refresh, AddressOf OnRefresh
			AddHandler m_Selector.Refresh, AddressOf OnRefresh
			AddHandler m_EventHeader.Refresh, AddressOf OnRefresh

			AddHandler m_AppointmentCollection.Refresh, AddressOf OnRefresh
			AddHandler m_RoomCollection.Refresh, AddressOf OnRefresh
			AddHandler m_CategoryCollection.Refresh, AddressOf OnRefresh
			AddHandler m_PriorityCollection.Refresh, AddressOf OnRefresh
			AddHandler m_ProviderCollection.Refresh, AddressOf OnRefresh
			AddHandler m_ResourceCollection.Refresh, AddressOf OnRefresh
			AddHandler m_AppearanceCollection.Refresh, AddressOf OnRefresh

			AddHandler m_AppointmentCollection.Reload, AddressOf CollectionReload
			AddHandler m_RoomCollection.Reload, AddressOf CollectionReload
			AddHandler m_CategoryCollection.Reload, AddressOf CollectionReload
			AddHandler m_PriorityCollection.Reload, AddressOf CollectionReload
			AddHandler m_ProviderCollection.Reload, AddressOf CollectionReload
			AddHandler m_ResourceCollection.Reload, AddressOf CollectionReload
			AddHandler m_AppearanceCollection.Reload, AddressOf CollectionReload

			AddHandler m_AppointmentCollection.AfterAdd, AddressOf AppointmentCollectionAfterAdd
			AddHandler m_AppointmentCollection.AfterRemove, AddressOf AppointmentCollectionAfterRemove
			AddHandler m_AppointmentCollection.BeforeAdd, AddressOf AppointmentCollectionBeforeAdd
			AddHandler m_AppointmentCollection.BeforeRemove, AddressOf AppointmentCollectionBeforeRemove
			AddHandler m_AppointmentCollection.ValidateRemove, AddressOf AppointmentCollectionValidateRemove

			AddHandler m_RecurrenceCollection.ClearComplete, AddressOf RecurrenceCollectionRemove
			AddHandler m_RecurrenceCollection.AfterRemove, AddressOf RecurrenceCollectionRemove

			MonthSelDate = Me.MinDate
			AddHandler ScrollTimerH.Tick, AddressOf ScrollTimerHTick
			AddHandler ScrollTimerV.Tick, AddressOf ScrollTimerVTick
			ScrollTimerH.Enabled = True
			ScrollTimerV.Enabled = True

			Try
				'Get the default values for the form sizes
				Dim F2 As Forms.ProviderForm = New Forms.ProviderForm
				Dialogs.DialogProviderBounds = New Rectangle(F2.Left, F2.Top, F2.Width, F2.Height)
				Dim F3 As New Forms.CategoryForm
				Dialogs.DialogCategoryBounds = New Rectangle(F3.Left, F3.Top, F3.Width, F3.Height)
				Dim F4 As New Forms.CategoryMasterForm
				Dialogs.DialogCategoryMasterBounds = New Rectangle(F4.Left, F4.Top, F4.Width, F4.Height)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Resolve Methods"

		Friend Function ResolveRoom(ByVal room As Room) As Integer

			Try
				Return RoomCollection.IndexOf(room)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Function

		Friend Function ResolveRoom(ByVal room As String) As Integer

			Try
				If IsNumeric(room) Then
					If GetIntlInteger(room) = -1 Then
						Return -1
					ElseIf RoomCollection.Contains(GetIntlInteger(room)) Then
						Return RoomCollection.IndexOfVisible(RoomCollection(room))
					Else
						Return -1
					End If
				ElseIf room = "" Then
					Return -1
				ElseIf RoomCollection.Contains(room) Then
					Return RoomCollection.IndexOfVisible(RoomCollection(room))
				Else
					Return -1
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function ResolveProvider(ByVal provider As String) As Integer

			If IsNumeric(provider) Then
				If GetIntlInteger(provider) = -1 Then
					Return -1
				ElseIf ProviderCollection.Contains(GetIntlInteger(provider)) Then
					Return ProviderCollection.IndexOfVisible(Me.ProviderCollection(provider))
				Else
					Return -1
				End If
			ElseIf provider = "" Then
				Return -1
			ElseIf ProviderCollection.Contains(provider) Then
				Return ProviderCollection.IndexOfVisible(Me.ProviderCollection(provider))
			Else
				Return -1
			End If

		End Function

		Friend Function ResolveResource(ByVal resource As String) As Integer

			If IsNumeric(resource) Then
				If GetIntlInteger(resource) = -1 Then
					Return -1
				ElseIf ResourceCollection.Contains(GetIntlInteger(resource)) Then
					Return ResourceCollection.IndexOf(ResourceCollection(resource))
				Else
					Return -1
				End If
			ElseIf resource = "" Then
				Return -1
			ElseIf ResourceCollection.Contains(resource) Then
				Return ResourceCollection.IndexOf(ResourceCollection(resource))
			Else
				Return -1
			End If

		End Function

		Friend Function ResolveCategory(ByVal category As String) As Integer

			If IsNumeric(category) Then
				If GetIntlInteger(category) = -1 Then
					Return -1
				Else
					Return CategoryCollection.IndexOf(CategoryCollection(category))
				End If
			ElseIf category = "" Then
				Return -1
			ElseIf CategoryCollection.Contains(category) Then
				Return CategoryCollection.IndexOf(CategoryCollection(category))
			Else
				Return -1
			End If

		End Function

#End Region

#Region "CreateDefaultAppointment"

		''' <summary>
		''' Creates an appointment on the schedule at the current Selector position.
		''' </summary>
		Public Function CreateDefaultAppointment() As Appointment

			'This method will check to determine if the highlighted area is enabled 
			'(NoDropAreaCollection) and if so add an appointment that covers this area.
			Try

				'Only create a new appointment with the Selector if it is visible
				If Not Me.AllowSelector Then
					Return Nothing
				End If

				Dim appointment As Appointment = New Appointment(Me)
				Dim providerIndex As Integer = -1
				Dim roomindex As Integer = -1
				Dim resourceIndex As Integer = -1
				appointment.Length = Me.Selector.Length * Me.TimeIncrement

				Select Case Me.ViewMode
					Case ViewModeConstants.DayTopTimeLeft
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.DayTopRoomLeft
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Row)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
					Case ViewModeConstants.DayTopProviderLeft
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.DayLeftTimeTop
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.DayLeftRoomTop
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Column)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
					Case ViewModeConstants.DayLeftResourceTop
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						resourceIndex = Me.Visibility.GetResourceFromRowCol(Me.Selector.Column)
						If resourceIndex <> -1 Then
							appointment.ResourceList.Add(ResourceCollection(resourceIndex))
						End If
					Case ViewModeConstants.DayLeftProviderTop
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Column)
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.RoomTopTimeLeft
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Column)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.RoomTopProviderLeft
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Row)
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Column)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
					Case ViewModeConstants.RoomLeftTimeTop
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Row)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.RoomLeftProviderTop
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Row)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.ProviderLeftTimeTop
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.ProviderTopTimeLeft
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.Month
						'Calculate the selected cell 
						Dim cellIndex As Integer = ((Me.Selector.Row \ 2) * DaysPerWeek) + Me.Selector.Column
						If (Me.Selector.Row Mod 2) = 0 Then cellIndex += 1 'This is Sunday
						cellIndex -= Me.MonthSelDate.DayOfWeek						'Subtract off the last month's days displayed
						appointment.StartDate = DateAdd(DateInterval.Day, cellIndex, Me.MonthSelDate)
					Case ViewModeConstants.DayRoomTopTimeLeft
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Column)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.DayProviderTopTimeLeft
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Column)
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.DayRoomLeftTimeTop
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Row)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.DayProviderLeftTimeTop
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Row)
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
						'Case ViewModeConstants.DayTimeTopRoomLeft
						'  appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						'  appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)
						'  roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Row)
						'  If roomindex <> -1 Then
						'    appointment.Room = Me.RoomCollection(roomindex)
						'  End If
					Case ViewModeConstants.DayTimeLeftProviderTop
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
						providerIndex = Me.Visibility.GetProviderFromRowCol(Me.Selector.Column)
					Case ViewModeConstants.DayTimeLeftRoomTop
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
						roomindex = Me.Visibility.GetRoomFromRowCol(Me.Selector.Column)
						If roomindex <> -1 Then
							appointment.Room = Me.RoomCollection(roomindex)
						End If
					Case ViewModeConstants.Week
						appointment.StartDate = Me.Visibility.GetDateFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)
					Case ViewModeConstants.MonthFull
						'Calculate the selected cell 
						Dim cellIndex As Integer = (Me.Selector.Row * DaysPerWeek) + Me.Selector.Column
						cellIndex -= Me.MonthSelDate.DayOfWeek						'Subtract off the last month's days displayed
						appointment.StartDate = DateAdd(DateInterval.Day, cellIndex, Me.MonthSelDate)

					Case ViewModeConstants.ResourceLeftTimeTop
						resourceIndex = Me.Visibility.GetResourceFromRowCol(Me.Selector.Row)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Column)

					Case ViewModeConstants.ResourceTopTimeLeft
						resourceIndex = Me.Visibility.GetResourceFromRowCol(Me.Selector.Column)
						appointment.StartTime = Me.Visibility.GetTimeFromRowCol(Me.Selector.Row)

					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

				'Check to determine if thhe area for the appointment is enabled
				If Not IsAreaEnabledFromPoint(Me.NoDropAreaCollection.ToList, appointment.StartDate, appointment.StartTime, appointment.Length, roomindex, providerIndex, resourceIndex) Then
					Return Nothing
				End If

				'Add a Provider if need be
				If providerIndex >= 0 Then
					Call appointment.ProviderList.Add(Me.ProviderCollection(providerIndex))
				End If

				If (Me.UseDefaultAppearances) Then
					appointment.ResetAppearance(Me.DefaultAppointmentAppearance, Me.DefaultAppointmentHeaderAppearance)
				End If

				Dim eventParam1 As New BeforeBaseObjectEventArgs(appointment)
				OnBeforeUserAppointmentAdd(eventParam1)
				If eventParam1.Cancel = True Then Return Nothing
				Call AppointmentCollection.AddObject(appointment)
				Dim eventParam2 As New AfterBaseObjectEventArgs(appointment)
				OnAfterUserAppointmentAdd(eventParam2)
				Me.Selector.Length = 1

				Call Dialogs.ShowPropertyDialog(appointment, True)

				'Return the new appointment
				Return appointment

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
			Return Nothing

		End Function

		''' <summary>
		''' Creates an appointment on the schedule at the specified screen position.
		''' </summary>
		Public Function CreateDefaultAppointment(ByVal pt As Point) As Appointment

			Try
				If Me.NoDrawing Then Return Nothing

				'Check if this point is in a NoDropArea
				If Not (Me.NoDropAreaCollection.HitTest(pt) Is Nothing) Then
					Return Nothing
				End If

				Dim appointment As Appointment = New Appointment(Me)
				appointment.Length = Me.TimeIncrement
				appointment.StartDate = Me.Visibility.GetDateFromCor(pt)
				If (appointment.StartDate = ScheduleGlobals.DefaultNoDate) Then appointment.StartDate = Me.MinDate
				If (pt.Y < Me.ClientTop) Then
					appointment.IsEvent = True
				Else
					appointment.StartTime = Me.Visibility.GetTimeFromCor(pt)
				End If
				Dim roomIndex As Integer = Me.Visibility.GetRoomFromCor(pt)
				If roomIndex = -1 Then
					appointment.Room = Nothing
				Else
					appointment.Room = Me.RoomCollection(roomIndex)
				End If
				Dim providerIndex As Integer = Me.Visibility.GetProviderFromCor(pt)
				If providerIndex >= 0 Then
					Call appointment.ProviderList.Add(Me.ProviderCollection(providerIndex))
				End If
				Dim resourceIndex As Integer = Me.Visibility.GetResourceFromCor(pt)
				If resourceIndex >= 0 Then
					Call appointment.ResourceList.Add(Me.ResourceCollection(resourceIndex))
				End If

				If (Me.UseDefaultAppearances) Then
					appointment.ResetAppearance(Me.DefaultAppointmentAppearance, Me.DefaultAppointmentHeaderAppearance)
				End If

				'Refresh the rectangles of the new appointment
				Dim drawSchedule As New Drawing.DrawScheduleMain(Me)
				drawSchedule.SetupAppointment(appointment)
				appointment.CalculateSortIndexes(Me)

				'Raise the user events and show dialog
				Dim eventParam1 As New BeforeBaseObjectEventArgs(appointment)
				OnBeforeUserAppointmentAdd(eventParam1)
				If eventParam1.Cancel = True Then Return Nothing
				If AppointmentCollection.AddObject(appointment) Is Nothing Then Return Nothing
				Dim eventParam2 As New AfterBaseObjectEventArgs(appointment)
				OnAfterUserAppointmentAdd(eventParam2)
				Me.Selector.Length = 1

				Call Dialogs.ShowPropertyDialog(CType(eventParam2.BaseObject, Gravitybox.Objects.Appointment), True)

				Return CType(eventParam2.BaseObject, Appointment)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
			Return Nothing

		End Function

		''' <summary>
		''' Creates an appointment on the schedule at the specified screen position.
		''' </summary>
		Public Function CreateDefaultAppointment(ByVal x As Integer, ByVal y As Integer) As Appointment
			Return CreateDefaultAppointment(New Point(x, y))
		End Function

#End Region

#Region "Draw and Resize"

#Region "IsAreaEnabledFromPoint"

		Friend Function IsAreaEnabledFromPoint(ByVal area As ScheduleArea, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal roomIndex As Integer, ByVal providerIndex As Integer, ByVal resourceIndex As Integer) As Boolean

			Try

				'This will calculate if the specfied area (calculated from a point) is enabled in this current viewmode
				startTime = GetTime(startTime)
				Select Case Me.ViewMode
					Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayLeftTimeTop
						Return Not area.IsConflict(startDate, startTime, length)
					Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayLeftRoomTop
						If roomIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.RoomCollection(roomIndex))
					Case ViewModeConstants.DayLeftResourceTop
						If resourceIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.ResourceCollection(resourceIndex))
					Case ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftProviderTop
						If providerIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.ProviderCollection(providerIndex))
					Case ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayRoomLeftTimeTop
						If roomIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.DayProviderLeftTimeTop
						If providerIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.ProviderCollection(providerIndex), startTime, length)
					Case ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.RoomLeftTimeTop
						If roomIndex = -1 Then Return True
						Return Not area.IsConflict(RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.RoomLeftProviderTop
						If roomIndex = -1 Then Return True
						Return Not area.IsConflict(RoomCollection(roomIndex), Nothing, length)
					Case ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ProviderTopTimeLeft
						If providerIndex = -1 Then Return True
						Return Not area.IsConflict(Me.ProviderCollection(providerIndex), startTime, length)
					Case ViewModeConstants.Month
						Return Not area.IsConflict(startDate, startTime, length)
					Case ViewModeConstants.DayTimeLeftProviderTop
						If providerIndex = -1 Then Return True
						Return Not area.IsConflict(Me.ProviderCollection(providerIndex), startDate, startTime, length)
					Case ViewModeConstants.DayTimeLeftRoomTop
						If roomIndex = -1 Then Return True
						Return Not area.IsConflict(startDate, Me.RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.Week
						Return Not area.IsConflict(startDate, startTime, length)
					Case ViewModeConstants.MonthFull
						Return Not area.IsConflict(startDate, startTime, length)
					Case ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.ResourceTopTimeLeft
						If resourceIndex = -1 Then Return True
						Return Not area.IsConflict(ResourceCollection(resourceIndex), startTime, length)
					Case Else
						Call ErrorModule.ViewmodeErr()
						Return False
				End Select
				Return True

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function IsAreaEnabledFromPoint(ByVal list As ScheduleAreaList, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal roomIndex As Integer, ByVal providerIndex As Integer, ByVal resourceIndex As Integer) As Boolean

			Try

				'This will calculate if the specfied area (calculated from a point) is enabled in this current viewmode
				startTime = GetTime(startTime)
				Select Case Me.ViewMode
					Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayLeftTimeTop
						Return Not list.IsOverlap(startDate, startTime, length)
					Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayLeftRoomTop
						If roomIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.RoomCollection(roomIndex))
					Case ViewModeConstants.DayLeftResourceTop
						If resourceIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.ResourceCollection(resourceIndex))
					Case ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftProviderTop
						If providerIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.ProviderCollection(providerIndex))
					Case ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayRoomLeftTimeTop
						If roomIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.DayProviderLeftTimeTop
						If providerIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.ProviderCollection(providerIndex), startTime, length)
					Case ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.RoomLeftTimeTop
						If roomIndex = -1 Then Return True
						Return Not list.IsOverlap(RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.RoomLeftProviderTop
						If roomIndex = -1 Then Return True
						Return Not list.IsOverlap(RoomCollection(roomIndex), Nothing, length)
					Case ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ProviderTopTimeLeft
						If providerIndex = -1 Then Return True
						Return Not list.IsOverlap(Me.ProviderCollection(providerIndex), startTime, length)
					Case ViewModeConstants.Month
						Return Not list.IsOverlap(startDate, startTime, length)
					Case ViewModeConstants.DayTimeLeftProviderTop
						If providerIndex = -1 Then Return True
						Return Not list.IsOverlap(Me.ProviderCollection(providerIndex), startDate, startTime, length)
					Case ViewModeConstants.DayTimeLeftRoomTop
						If roomIndex = -1 Then Return True
						Return Not list.IsOverlap(startDate, Me.RoomCollection(roomIndex), startTime, length)
					Case ViewModeConstants.Week
						Return Not list.IsOverlap(startDate, startTime, length)
					Case ViewModeConstants.MonthFull
						Return Not list.IsOverlap(startDate, startTime, length)
					Case ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.ResourceTopTimeLeft
						If resourceIndex = -1 Then Return True
						Return Not list.IsOverlap(ResourceCollection(resourceIndex), startTime, length)
					Case Else
						Call ErrorModule.ViewmodeErr()
						Return False
				End Select
				Return True

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function IsAreaEnabledFromPoint(ByVal pt As Point, ByVal appointmentLength As Integer) As Boolean

			Try

				Dim currentDate As DateTime
				Dim currentTime As DateTime
				Dim currentRoom As Integer
				Dim currentProvider As Integer
				Dim currentResource As Integer

				'Calculate the current grid properties from the specified point
				currentDate = Me.Visibility.GetDateFromCor(pt)
				currentTime = Me.Visibility.GetTimeFromCor(pt)
				currentRoom = Me.Visibility.GetRoomFromCor(pt)
				currentProvider = Me.Visibility.GetProviderFromCor(pt)
				currentResource = Me.Visibility.GetResourceFromCor(pt)

				'This will calculate if the specified area (calculated from a point) is enabled in this current viewmode
				Return IsAreaEnabledFromPoint(Me.NoDropAreaCollection.ToList, currentDate, currentTime, appointmentLength, currentRoom, currentProvider, currentResource)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

		Private Sub RescheduleAppointment(ByVal appointment As Appointment, ByVal pt As Point, ByVal IsCopy As Boolean, ByVal IsForeign As Boolean, ByVal data As IDataObject)

			'Error Check
			If appointment Is Nothing Then Return

			Try

				Dim originalSchedule As Schedule = appointment.MainObject

				'Ensure that we may move/copy an appointment
				If IsCopy AndAlso Not Me.AllowCopy Then
					Return
				ElseIf Not IsCopy AndAlso Not Me.AllowMove Then
					Return
				End If

				Dim newDate As DateTime = Me.Visibility.GetDateFromCor(pt)
				Dim newTime As DateTime = Me.Visibility.GetTimeFromCor(pt, Me.AppointmentTimeIncrement)
				Dim newRoom As Integer = Me.Visibility.GetRoomFromCor(pt)
				Dim newProvider As Integer = Me.Visibility.GetProviderFromCor(pt)
				Dim newResource As Integer = Me.Visibility.GetResourceFromCor(pt)

				'Dim newAppointment As New Gravitybox.Objects.Appointment(Me)
				Dim newAppointment As Gravitybox.Objects.Appointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
				CancelEventDataSourceUpdated = True
				newAppointment.FromXML(appointment.ToXML)
				If IsCopy Then
					newAppointment.SetKey(Guid.NewGuid.ToString)
					Me.FireEventDataSourceUpdated()
				End If
				CancelEventDataSourceUpdated = False

				If (IsCopy OrElse IsForeign) Then
					'If this is a copy or foreign drop then check to determine if
					'the RecurrenceId exists in the Recurrence collection and if not
					'change the ID so that it does not form an implicit recurence pattern
					If Not Me.RecurrenceCollection.Contains(newAppointment.Recurrence) Then
						newAppointment.Recurrence = Nothing
					End If
				Else
					'Ensure that since this is the same appointment 
					'that was dragged that it has the same ID
					Call newAppointment.SetKey(appointment.Key)
				End If

				'Dim lockKey As String = PrepareForProcessing()
				Select Case Me.ViewMode
					Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayLeftTimeTop
						newAppointment.StartDate = newDate
						newAppointment.StartTime = newTime
					Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayLeftRoomTop
						newAppointment.Room = Me.RoomCollection(newRoom)
						newAppointment.StartDate = newDate
					Case ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftProviderTop
						newAppointment.StartDate = newDate
						If newProvider >= 0 Then
							'If there is a provider then get it and remove it from the new 
							'appointment, since we are moving from this provider to a new provider
							If data.GetDataPresent(GetType(Gravitybox.Objects.Provider)) Then
								Dim oldProvider As Gravitybox.Objects.Provider = CType(data.GetData(GetType(Gravitybox.Objects.Provider)), Gravitybox.Objects.Provider)
								If Not (oldProvider Is Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.RemoveAll(oldProvider)
									If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
										Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all providers
								Call newAppointment.ProviderList.Clear()
								If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
								End If
							End If
						End If
					Case ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.RoomLeftTimeTop
						newAppointment.Room = Me.RoomCollection(newRoom)
						newAppointment.StartTime = newTime
					Case ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.RoomLeftProviderTop
						newAppointment.Room = Me.RoomCollection(newRoom)
						If newProvider >= 0 Then
							'If there is a provider then get it and remove it from the new 
							'appointment, since we are moving from this provider to a new provider
							If data.GetDataPresent(GetType(Gravitybox.Objects.Provider)) Then
								Dim oldProvider As Gravitybox.Objects.Provider = CType(data.GetData(GetType(Gravitybox.Objects.Provider)), Gravitybox.Objects.Provider)
								If Not (oldProvider Is Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.RemoveAll(oldProvider)
									If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
										Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all providers
								Call newAppointment.ProviderList.Clear()
								If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
								End If
							End If
						End If
					Case ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ProviderTopTimeLeft
						newAppointment.StartTime = newTime
						If newProvider >= 0 Then
							'If there is a provider then get it and remove it from the new 
							'appointment, since we are moving from this provider to a new provider
							If data.GetDataPresent(GetType(Gravitybox.Objects.Provider)) Then
								Dim oldProvider As Gravitybox.Objects.Provider = CType(data.GetData(GetType(Gravitybox.Objects.Provider)), Gravitybox.Objects.Provider)
								If Not (oldProvider Is Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.RemoveAll(oldProvider)
									If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
										Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all providers
								Call newAppointment.ProviderList.Clear()
								If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
								End If
							End If
						End If
					Case ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayRoomLeftTimeTop
						newAppointment.StartDate = newDate
						newAppointment.Room = Me.RoomCollection(newRoom)
						newAppointment.StartTime = newTime
					Case ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.DayProviderLeftTimeTop
						newAppointment.StartDate = newDate
						newAppointment.ProviderList.Clear()
						newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
						newAppointment.StartTime = newTime
					Case ViewModeConstants.Month
						newAppointment.StartDate = newDate
					Case ViewModeConstants.DayTimeLeftProviderTop
						newAppointment.StartDate = newDate
						newAppointment.StartTime = newTime
						If newProvider >= 0 Then
							'If there is a provider then get it and remove it from the new 
							'appointment, since we are moving from this provider to a new provider
							If data.GetDataPresent(GetType(Gravitybox.Objects.Provider)) Then
								Dim oldProvider As Gravitybox.Objects.Provider = CType(data.GetData(GetType(Gravitybox.Objects.Provider)), Gravitybox.Objects.Provider)
								If Not (oldProvider Is Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.RemoveAll(oldProvider)
									If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
										Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all providers
								Call newAppointment.ProviderList.Clear()
								If Not newAppointment.ProviderList.Contains(Me.ProviderCollection(newProvider)) Then
									Call newAppointment.ProviderList.Add(Me.ProviderCollection(newProvider))
								End If
							End If
						End If
					Case ViewModeConstants.DayTimeLeftRoomTop
						newAppointment.StartDate = newDate
						newAppointment.StartTime = newTime
						If newRoom >= 0 Then
							newAppointment.Room = Me.RoomCollection(newRoom)
						End If
					Case ViewModeConstants.Week
						newAppointment.StartDate = newDate
						newAppointment.StartTime = newTime
					Case ViewModeConstants.MonthFull
						newAppointment.StartDate = newDate
					Case ViewModeConstants.DayLeftResourceTop
						newAppointment.StartDate = newDate
						If newResource >= 0 Then
							'If there is a resource then get it and remove it from the new 
							'appointment, since we are moving from this resource to a new resource
							If data.GetDataPresent(GetType(Gravitybox.Objects.Resource)) Then
								Dim oldResource As Gravitybox.Objects.Resource = CType(data.GetData(GetType(Gravitybox.Objects.Resource)), Gravitybox.Objects.Resource)
								If Not (oldResource Is Me.ResourceCollection(newResource)) Then
									Call newAppointment.ResourceList.RemoveAll(oldResource)
									If Not newAppointment.ResourceList.Contains(Me.ResourceCollection(newResource)) Then
										Call newAppointment.ResourceList.Add(Me.ResourceCollection(newResource))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all resources
								Call newAppointment.ResourceList.Clear()
								If Not Me.ResourceCollection.Contains(newResource) Then
									Call newAppointment.ResourceList.Add(Me.ResourceCollection(newResource))
								End If
							End If
						End If
					Case ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.DayLeftResourceTop
						newAppointment.StartTime = newTime
						If newResource >= 0 Then
							'If there is a resource then get it and remove it from the new 
							'appointment, since we are moving from this resource to a new resource
							If data.GetDataPresent(GetType(Gravitybox.Objects.Resource)) Then
								Dim oldResource As Gravitybox.Objects.Resource = CType(data.GetData(GetType(Gravitybox.Objects.Resource)), Gravitybox.Objects.Resource)
								If Not (oldResource Is Me.ResourceCollection(newResource)) Then
									Call newAppointment.ResourceList.RemoveAll(oldResource)
									If Not newAppointment.ResourceList.Contains(Me.ResourceCollection(newResource)) Then
										Call newAppointment.ResourceList.Add(Me.ResourceCollection(newResource))
									End If
								End If
							Else
								'If we cannot decide what to remove then clear all resources
								Call newAppointment.ResourceList.Clear()
								If Not Me.ResourceCollection.Contains(newResource) Then
									Call newAppointment.ResourceList.Add(Me.ResourceCollection(newResource))
								End If
							End If
						End If
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				'Me.PrepareForProcessing(lockKey)

				'Reset the conflict information for this temp appointment
				Call newAppointment.InitializeRectangle()
				newAppointment.CalculateSortIndexes()

				'Create the parameter for the next event
				Dim appointmentList As New AppointmentList(Me)
				If (Not IsCopy) AndAlso Me.AppointmentCollection.Contains(newAppointment.Key) Then
					Call appointmentList.Add(Me.AppointmentCollection(newAppointment.Key))
				End If
				Dim eventParam1 As New BeforeAppointmentActionEventArgs(appointment, newAppointment, Me.AppointmentCollection.IsConflict(newAppointment, appointmentList))

				'If this is a foreign (non-appointment) drop...
				If IsForeign Then
					Dim eventParam3 As New BeforeAppointmentForeignEventArgs(newAppointment, Me.AppointmentCollection.IsConflict(newAppointment, appointmentList), data)
					OnBeforeForeignAdd(eventParam3)
					If eventParam3.Cancel Then Return
					Me.AppointmentCollection.AddObject(newAppointment)
				Else
					'Determine if we are going to go or stop
					If IsCopy Then
						OnBeforeAppointmentCopy(eventParam1)
						If eventParam1.Cancel Then
							Call OnRefresh()
							Return
						End If
					Else
						OnBeforeAppointmentMove(eventParam1)
						If eventParam1.Cancel Then
							Call OnRefresh()
							Return
						End If
					End If

				End If

				'If Move and the appointment is NOT in this schedule's collection
				'Then remove it from its parent collection
				If Not IsCopy AndAlso Not Me.AppointmentCollection.Contains(newAppointment.Key) Then
					If originalSchedule.AppointmentCollection.Contains(newAppointment.Key) Then
						If originalSchedule.AppointmentCollection.Remove(newAppointment.Key) Then
							'This appointment is NOT in this schedule's collection 
							'then remove it from the original collection and 
							'if the remove was successful then add it to the currect collection
							Me.AppointmentCollection.AddObject(newAppointment)
						Else
							'The remove failed so do not proceed
							originalSchedule.Refresh()
							If Not (originalSchedule Is Me) Then Me.Refresh() 'Do not call refresh twice
							Return
						End If

					End If

				ElseIf IsCopy Then
					'If this is a copy then make a copy
					Me.AppointmentCollection.AddObject(newAppointment)

				ElseIf Not IsForeign Then
					'Move on same schedule so update the dragged appointment
					CancelEventDataSourceUpdated = True
					Dim xml As String = newAppointment.ToXML
					'Try a short cut and if it does not work do a full load
					Dim lockKey2 As String = PrepareForProcessing()
					Select Case Me.ViewMode
						Case ViewModeConstants.DayLeftProviderTop, ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTopProviderLeft, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.RoomTopProviderLeft
							Call appointment.ProviderList.Clear()
							Call appointment.ProviderList.Add(Me.ProviderCollection(newProvider), 0)
						Case ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.ResourceTopTimeLeft
							Call appointment.ResourceList.Clear()
							Call appointment.ResourceList.Add(Me.ResourceCollection(newResource), 0)
					End Select
					appointment.FromXML(xml, False)
					If appointment.ToXML <> xml Then appointment.FromXML(xml)
					CType(newAppointment, IDisposable).Dispose()
					Me.PrepareForProcessing(lockKey2)
					CancelEventDataSourceUpdated = False
					Me.FireEventDataSourceUpdated()
				End If

				'Set the pointer to the actual appointment in the collection
				newAppointment = Me.AppointmentCollection(newAppointment.Key)

				'Set the SelectedItem to the newly added item
				Dim lockKey3 As String = PrepareForProcessing()
				Call Me.SelectedItems.Clear()
				Me.SelectedItem = newAppointment
				Me.PrepareForProcessing(lockKey3)

				'Repaint the screen
				OnRefresh()

				'If this is a foreign (non-appointment) drop...
				If IsForeign Then
					Dim eventParam4 As New AfterAppointmentForeignEventArgs(newAppointment, data)
					OnAfterForeignAdd(eventParam4)

				Else
					'Raise the events to inform the container of this action
					Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(newAppointment)
					If IsCopy Then
						OnAfterAppointmentCopy(eventParam2)
					Else
						OnAfterAppointmentMove(eventParam2)
					End If

				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				OnRefresh()
			End Try

		End Sub

		Private Sub RescheduleAppointment(ByVal appointment As Appointment, ByVal x As Integer, ByVal y As Integer, ByVal IsCopy As Boolean, ByVal IsForeign As Boolean, ByVal data As IDataObject)
			Call RescheduleAppointment(appointment, New Point(x, y), IsCopy, IsForeign, data)
		End Sub

		Public Sub ApplyTheme(ByVal theme As ThemeConstants)
			ThemeHelper.SetupStyleTheme(Me, theme)
			ThemeHelper.SetupStyleAppointmentTheme(Me, theme)
		End Sub

#End Region

#Region "Over Column/Row"

		'This method detmermines if the specifeid coordinate is over a column break
		Private Function OverColumnBreak(ByVal x As Integer, ByVal y As Integer) As Boolean
			Return OverColumnBreak(New Point(x, y))
		End Function

		Private Function OverColumnBreak(ByVal pt As Point) As Boolean
			Try
				If pt.X <= Me.ClientLeft Then Return False
				If pt.X > Me.ClientLeft + (Me.Visibility.VisibleColumns * Me.ColumnHeader.Size) Then Return False
				Dim remainder As Integer = (pt.X - Me.ClientLeft) Mod Me.ColumnHeader.Size
				Return (-ResizeBuffer <= remainder) AndAlso (remainder <= ResizeBuffer)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Function

		'This method detmermines if the specified coordinate is over a row break
		Private Function OverRowBreak(ByVal x As Integer, ByVal y As Integer) As Boolean
			Return OverRowBreak(New Point(x, y))
		End Function

		Private Function OverRowBreak(ByVal pt As Point) As Boolean

			Try
				If pt.Y <= Me.ClientTop Then Return False
				If pt.Y > Me.ClientTop + (Me.Visibility.VisibleRows * Me.RowHeader.Size) Then Return False
				Dim remainder As Integer = (pt.Y - Me.ClientTop) Mod Me.RowHeader.Size
				Return (-ResizeBuffer <= remainder) AndAlso (remainder <= ResizeBuffer)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "InSet"

		Friend Function InSet(ByVal check As ViewModeConstants, <ParamArrayAttribute()> ByVal values() As ViewModeConstants) As Boolean

			Try
				Dim ii As Integer
				For ii = 0 To values.Length - 1
					If check = values(ii) Then
						Return True
					End If
				Next
				Return True
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "RaiseAppointmentBarUserDrawnEvent"

		Friend Sub RaiseAppointmentBarUserDrawnEvent(ByVal g As Graphics, ByVal appointment As Appointment, ByVal rectangle As Rectangle)
			Try
				OnUserDrawnAppointmentBar(New AppointmentUserDrawEventArgs(g, appointment, rectangle))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "RaiseAppointmentHeaderUserDrawnEvent"

		Friend Sub RaiseAppointmentHeaderUserDrawnEvent(ByVal g As Graphics, ByVal appointment As Appointment, ByVal rectangle As Rectangle)
			Try
				OnUserDrawnAppointmentHeader(New AppointmentUserDrawEventArgs(g, appointment, rectangle))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "Schedule Events"

		Private Sub Schedule_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DragLeave

			Try
				AppointmentOutline.DragRectArray.Clear()
				lblToolTip.Visible = False
				OnRefresh()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub Schedule_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles MyBase.QueryContinueDrag

			Try
				'If pressed the <ESC> then cancel the drag and 
				'restore appointment to original state
				If e.EscapePressed Then
					AppointmentOutline.DragRectArray.Clear()
					OnRefresh()
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub Schedule_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragOver

			Try
				Dim appointment As Gravitybox.Objects.Appointment
				Dim pt As Point = Me.PointToClient(New Point(e.X, e.Y))
				If Not (e.Data.GetDataPresent(GetType(Gravitybox.Objects.Appointment)) Or Me.AllowForeignDrops) Then
					e.Effect = DragDropEffects.None
					'Fire the DragOver event 
					Call OnDragOver(New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e))
					Return
				End If

				'If we are out of range then nothing to do
				If (pt.X < Me.ClientLeft) OrElse (pt.Y < Me.TopHeaderHeight) OrElse (pt.X > Me.ClientLeft + Me.ClientWidth) OrElse (pt.Y > Me.ClientTop + Me.ClientHeight) Then
					e.Effect = DragDropEffects.None
					'Fire the DragOver event 
					Call OnDragOver(New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e))
					Return
				End If

				'Add the dragged appointment or create a new one if this is another drop type
				If e.Data.GetDataPresent(GetType(Gravitybox.Objects.Appointment)) Then
					Try
						appointment = CType(e.Data.GetData(GetType(Gravitybox.Objects.Appointment)), Gravitybox.Objects.Appointment)
					Catch ex As Exception
						'This was added for an issue on a multi-processor machine
						e.Effect = DragDropEffects.None
						Return
					End Try
				Else
					'This is foreign drop
					e.Effect = e.AllowedEffect
					appointment = New Gravitybox.Objects.Appointment(Me)
					appointment.Length = Me.GetForeignDragLength(e.Data)
				End If

				If Me.AllowCopy AndAlso ((e.KeyState And 8) = 8) Then				 '<CTRL> key
					e.Effect = DragDropEffects.Copy
				ElseIf Me.AllowMove AndAlso ((e.KeyState And 8) = 0) Then				 '<CTRL> key
					e.Effect = DragDropEffects.Move
				Else
					e.Effect = DragDropEffects.None
					'Fire the DragOver event 
					Call OnDragOver(New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e))
					Return
				End If

				'If the appointment is dragged over the edges 
				'of the canvas then scroll if possible
				If pt.X < Me.ClientLeft + DragScrollMargin Then
					'Left Margin
					If HScroll1.Value > HScroll1.Minimum Then HScroll1.Value -= 1
				ElseIf pt.X > Me.Width - VScroll1.Width - DragScrollMargin Then
					'Right Margin
					If HScroll1.Value < HScroll1.Maximum Then HScroll1.Value += 1
				ElseIf (Me.ClientTop <= pt.Y) AndAlso (pt.Y < Me.ClientTop + DragScrollMargin) Then
					'Top Margin
					If VScroll1.Value > VScroll1.Minimum Then VScroll1.Value -= 1
				ElseIf pt.Y > Me.Height - HScroll1.Height - DragScrollMargin Then
					'Bottom Margin
					If VScroll1.Value < VScroll1.Maximum Then VScroll1.Value += 1
				End If

				'Fire the DragOver event 
				Dim dae As DragAppointmentEventArgs = New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e, appointment)
				Me.OnDragOver(dae)
				If dae.Cancel Then
					e.Effect = DragDropEffects.None
					Return
				End If

				Me.DrawingDirty = True
				If Not AppointmentOutline.DrawDragOutline(pt, appointment, appointment.GetRealLength, False) Then
					e.Effect = DragDropEffects.None
				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub Schedule_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MyBase.DragDrop

			Try
				'Dim lockKey As String = PrepareForProcessing()
				Dim pt As Point = Me.PointToClient(New Point(e.X, e.Y))
				AppointmentOutline.DragRectArray.Clear()
				lblToolTip.Visible = False
				Dim newPoint As Point = Me.PointToClient(New Point(e.X, e.Y))
				Dim appointment As Gravitybox.Objects.Appointment

				If Not Me.Visibility.IsInRangeCor(newPoint) Then
					'Fire the DragDrop event 
					OnDragDrop(New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e))
					Return
				End If

				'If this is a foreign drop...
				If (Not e.Data.GetDataPresent(GetType(Gravitybox.Objects.Appointment)) And Not Me.AllowForeignDrops) Then
					'Fire the DragDrop event 
					OnDragDrop(New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e))
					Return
				End If

				Dim lockKey As String = PrepareForProcessing()
				Try
					'Add the dragged appointment or create a new one if this is another drop type
					Dim isForeign As Boolean
					If e.Data.GetDataPresent(GetType(Gravitybox.Objects.Appointment)) Then
						appointment = CType(e.Data.GetData(GetType(Gravitybox.Objects.Appointment)), Gravitybox.Objects.Appointment)
						isForeign = False
					Else
						appointment = New Gravitybox.Objects.Appointment(Me)
						appointment.Length = Me.GetForeignDragLength(e.Data)
						isForeign = True
					End If

					'If dragging above or below the event header then make sure that 
					'the appointment is either an event or not as it is appropriate
					If (pt.Y < Me.ClientTop) AndAlso (Not appointment.IsEvent) Then
						appointment.IsEvent = True
						DrawingDirty = True
					ElseIf (pt.Y >= Me.ClientTop) AndAlso ((appointment.IsEvent) OrElse (appointment.IsActivity)) Then
						If Me.EventHeader.SupportedViewmode(Me.ViewMode) Then
							appointment.IsEvent = False
							appointment.IsActivity = False
						End If
						DrawingDirty = True
					End If

					Dim dae As DragAppointmentEventArgs = New Gravitybox.Objects.EventArgs.DragAppointmentEventArgs(e, appointment)
					OnDragDrop(dae)
					If dae.Cancel Then
						Return
					End If
					Call RescheduleAppointment(appointment, newPoint, CBool(IIf(((e.KeyState And 8) = 8), True, False)), isForeign, e.Data)

				Catch ex As Exception
					ErrorModule.SetErr(ex)
				Finally
					PrepareForProcessing(lockKey)
				End Try

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'Me.PrepareForProcessing(lockKey)
			End Try

		End Sub

		Protected Overrides Sub OnMouseWheel(ByVal e As System.Windows.Forms.MouseEventArgs)

			Try
				UsingMouseWheel = True
				If e.Delta > 0 Then
					Dim index As Integer = Me.Visibility.FirstVisibleRow
					If index >= 1 Then Me.Visibility.FirstVisibleRow -= 1
				Else
					Dim index As Integer = Me.Visibility.FirstVisibleRow
					If index <= (Me.Visibility.TotalRowCount - Me.Visibility.VisibleRowsNoCorrection + 1) Then Me.Visibility.FirstVisibleRow += 1
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				UsingMouseWheel = False
			End Try

		End Sub

		Private Function GetForeignDragLength(ByVal data As System.Windows.Forms.IDataObject) As Integer

			Dim retval As Integer = Me.TimeIncrement
			Try
				If Not data.GetData(GetType(String)) Is Nothing Then
					If IsNumeric(data.GetData(GetType(String))) Then
						retval = GetIntlInteger(data.GetData(GetType(String)))
					End If
				ElseIf Not data.GetData(GetType(Integer)) Is Nothing Then
					retval = CType(data.GetData(GetType(Integer)), Integer)
				End If
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
			If retval <= 0 Then retval = Me.TimeIncrement
			Return retval

		End Function

#If VS2005 Then
		Private Sub Schedule_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover

			'Try
			'	'If the mouse is in the viewport
			'	If Me.ViewPort.Contains(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y) Then
			'		'If the mouse is NOT over another appointment
			'		Dim appt As Appointment = Me.AppointmentCollection.HitTest(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
			'		If appt Is Nothing Then
			'			Me.Canvas.DrawClickToAddMessage(Me.CreateGraphics(), System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y)
			'		End If
			'	End If

			'Catch ex As Exception
			'	ErrorModule.SetErr(ex)
			'End Try

		End Sub
#End If

		Private Sub Schedule_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

			LastMouseObject = New System.Windows.Forms.MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta)

			Dim lockKey As String = PrepareForProcessing()
			Try
				Call SaveInGridEdit()

				'If clicked the expander then expand/collapse
				If Me.EventHeader.HitTestExpander(e.X, e.Y) Then
					Me.EventHeader.IsExpanded = Not Me.EventHeader.IsExpanded
					Me.DrawingDirty = True
					Return
				End If

				'**************************************************
				'Determine if a header was clicked
				Dim headerIndex As Integer = Me.ColumnHeader.HitTest(e.X, e.Y)
				If headerIndex <> -1 Then
					If Not Me.OverColumnBreak(e.X, e.Y) Then
						OnColumnHeaderClick(New Gravitybox.Objects.EventArgs.AfterHeaderEventArgs(headerIndex))
					End If
				End If
				headerIndex = Me.RowHeader.HitTest(e.X, e.Y)
				If headerIndex <> -1 Then
					If Not Me.OverRowBreak(e.X, e.Y) Then
						OnRowHeaderClick(New Gravitybox.Objects.EventArgs.AfterHeaderEventArgs(headerIndex))
					End If
				End If

				'**************************************************
				Dim appointment As Gravitybox.Objects.Appointment
				If Not (Me.SelectedItem Is Nothing) AndAlso (CType(Me.SelectedItem, Gravitybox.Objects.Appointment).OverTopResizeBorder(Me, e.X, e.Y) OrElse CType(Me.SelectedItem, Appointment).OverBottomResizeBorder(Me, e.X, e.Y)) Then
					'The mouse was clicked on a resize bar of the SelectedItem,
					'do NOT reset the SelectedItem
					appointment = CType(Me.SelectedItem, Appointment)
				Else
					appointment = Me.AppointmentCollection.HitTest(e.X, e.Y)
				End If

				If Not (appointment Is Nothing) Then

					'If the CTRL key was pressed then multiselect
					If Me.MultiSelect AndAlso (Control.ModifierKeys = Keys.Control) Then
						If Me.SelectedItems.Contains(appointment) Then
							'The appointment is in the SelectedItem so take it out
							Call Me.SelectedItems.Remove(appointment)
							Me.SelectedItem = Nothing
						Else
							'The appointment is NOT in the SelectedItem so put it in
							Me.SelectedItem = appointment
						End If
					Else
						'The CTRL key was not pressed (or single select) so clear the 
						'SelectedItems collection and add this one appointment
						Dim localLockKey As String = PrepareForProcessing()
						Call Me.SelectedItems.Clear()
						Me.SelectedItem = appointment
						Me.PrepareForProcessing(localLockKey)
					End If

					'If the appoointment is a Blockout then it will not be set so skip out
					If Me.SelectedItem Is Nothing Then
						SelectedItemOnMouseDown = Me.SelectedItem
						Return
					End If

					'Check to determine if the user clicked the header info box
					If e.Button = System.Windows.Forms.MouseButtons.Left Then
						If appointment.OverInfoBox(e.X, e.Y) Then
							Dim eventParam As New AppointmentMouseEventArgs(appointment, e)
							OnAppointmentHeaderInfoClick(eventParam)
							Return
						End If
					End If

					'Check to determine if the user us resizing the appointment
					If (Not Me.SelectedItem.IsReadOnly) AndAlso Not (Me.SelectedItem.IsEvent OrElse Me.SelectedItem.IsActivity) AndAlso CType(Me.SelectedItem, Appointment).OverTopResizeBorder(Me, e.X, e.Y) Then
						ResizeAppointmentObject = New ResizeAppointmentInfo
						ResizeAppointmentObject.Appointment = Me.SelectedItem
						ResizeAppointmentObject.AppointmentValues.StartDate = Me.SelectedItem.StartDate
						ResizeAppointmentObject.AppointmentValues.StartTime = Me.SelectedItem.StartTime
						ResizeAppointmentObject.ClickTime = Visibility.GetTimeFromCor(e.X, e.Y)
						If Not Me.SelectedItem.Room Is Nothing Then
							ResizeAppointmentObject.AppointmentValues.StartRoom = Me.RoomCollection.IndexOfVisible(SelectedItem.Room).ToString
						End If
						Call ResizeAppointmentObject.AppointmentValues.Providers.Clear()
						ResizeAppointmentObject.AppointmentValues.Providers.FromArray(Me.SelectedItem.ProviderList.ToArray())
						ResizeAppointmentObject.AppointmentValues.Length = Me.SelectedItem.Length
						ResizeAppointmentObject.IsStartResizing = (AppointmentResizing = AppointmentResizingConstants.All) OrElse (AppointmentResizing = AppointmentResizingConstants.StartTime)
						AppointmentOutline.ResizeRowColObject.StartDate = ScheduleGlobals.GetDateByViewMode(Me.ViewMode, Me.SelectedItem.StartDate)
						AppointmentOutline.ResizeRowColObject.StartTime = Me.SelectedItem.StartTime
						AppointmentOutline.ResizeRowColObject.Length = Me.SelectedItem.Length
					ElseIf (Not Me.SelectedItem.IsReadOnly) AndAlso Not (Me.SelectedItem.IsEvent OrElse Me.SelectedItem.IsActivity) AndAlso CType(Me.SelectedItem, Appointment).OverBottomResizeBorder(Me, e.X, e.Y) Then
						ResizeAppointmentObject = New ResizeAppointmentInfo
						ResizeAppointmentObject.ClickTime = Visibility.GetTimeFromCor(e.X, e.Y)
						ResizeAppointmentObject.Appointment = Me.SelectedItem
						ResizeAppointmentObject.AppointmentValues.StartDate = Me.SelectedItem.StartDate
						ResizeAppointmentObject.AppointmentValues.StartTime = Me.SelectedItem.StartTime
						If Not Me.SelectedItem.Room Is Nothing Then
							ResizeAppointmentObject.AppointmentValues.StartRoom = Me.RoomCollection.IndexOfVisible(SelectedItem.Room).ToString
						End If
						Call ResizeAppointmentObject.AppointmentValues.Providers.Clear()
						ResizeAppointmentObject.AppointmentValues.Providers.FromArray(Me.SelectedItem.ProviderList.ToArray())
						ResizeAppointmentObject.AppointmentValues.Length = Me.SelectedItem.Length
						ResizeAppointmentObject.IsEndResizing = (AppointmentResizing = AppointmentResizingConstants.All) OrElse (AppointmentResizing = AppointmentResizingConstants.Length)
						AppointmentOutline.ResizeRowColObject.StartDate = ScheduleGlobals.GetDateByViewMode(Me.ViewMode, Me.SelectedItem.StartDate)
						AppointmentOutline.ResizeRowColObject.StartTime = Me.SelectedItem.StartTime
						AppointmentOutline.ResizeRowColObject.Length = Me.SelectedItem.Length
					Else

						'If in Month mode then highlight the day of the selected appointment
						If Me.ViewMode = ViewModeConstants.Month Then
							If Me.AllowSelector Then
								Dim localLockKey As String = PrepareForProcessing()
								Me.Selector.NoScroll = True
								Me.Selector.Column = Me.Visibility.GetColumnFromCor(e.X, e.Y)
								Me.Selector.Row = Me.Visibility.GetRowFromCor(e.X, e.Y)
								Me.Selector.NoScroll = False
								Me.PrepareForProcessing(localLockKey)
								OnRefresh()
							End If
						End If

						'Start the edit timer
						'If clicked on the SelectedItem then start the edit timer
						If (e.Button = System.Windows.Forms.MouseButtons.Left) AndAlso (SelectedItemOnMouseDown Is Me.SelectedItem) Then
							editBoxFromMouseDown = New Rectangle(New Point(e.X - (SystemInformation.DragSize.Width \ 2), e.Y - (SystemInformation.DragSize.Height \ 2)), SystemInformation.DragSize)
						End If
						If (e.Button = System.Windows.Forms.MouseButtons.Left) AndAlso (Not (Me.SelectedItem Is Nothing)) Then
							dragBoxFromMouseDown = New Rectangle(New Point(e.X - (SystemInformation.DragSize.Width \ 2), e.Y - (SystemInformation.DragSize.Height \ 2)), SystemInformation.DragSize)
						End If

					End If

				Else

					'In month mode check to determine if the arrow keys were pressed
					If (Me.ViewMode = ViewModeConstants.Month) OrElse (Me.ViewMode = ViewModeConstants.MonthFull) Then
						Dim cell As DayCell = Me.DayCellArray.HitTestDownButton(e.X, e.Y)
						If Not (cell Is Nothing) Then
							cell.ScrollValue += 1
							Me.OnRefresh()
							Return
						Else
							cell = Me.DayCellArray.HitTestUpButton(e.X, e.Y)
							If Not (cell Is Nothing) Then
								cell.ScrollValue -= 1
								Me.OnRefresh()
								Return
							End If
						End If
					End If

					Dim useBackgroundClick As Boolean = True
					Call Me.SelectedItems.Clear()
					Me.SelectedItem = Nothing

					'Check to determine if we are resizing a row/column
					If e.Button = System.Windows.Forms.MouseButtons.Left Then
						If Me.ColumnHeader.AllowResize AndAlso (e.Y <= Me.ClientTop) And Me.OverColumnBreak(e.X, e.Y) Then
							lblResize.Size = New Size(1, Me.Height)
							lblResize.Visible = True
							AppointmentOutline.ResizeRowColObject.OriginalCor = Me.ColumnHeader.Size
							AppointmentOutline.ResizeRowColObject.IsResizing = True
							AppointmentOutline.ResizeRowColObject.ResizeCor = e.X
							AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Column
							useBackgroundClick = False
						ElseIf Me.RowHeader.AllowResize AndAlso (e.X <= Me.ClientLeft) And Me.OverRowBreak(e.X, e.Y) Then
							lblResize.Size = New Size(Me.Width, 1)
							lblResize.Visible = True
							AppointmentOutline.ResizeRowColObject.OriginalCor = Me.RowHeader.Size
							AppointmentOutline.ResizeRowColObject.IsResizing = True
							AppointmentOutline.ResizeRowColObject.ResizeCor = e.Y
							AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Row
							useBackgroundClick = False
						Else
							If ModifierKeys = Keys.Shift AndAlso Me.AllowSelector Then

								Me.Selector.ExpandToCoordinate(e.X, e.Y)
								OnRefresh()

								''If the <CTRL> key was pressed then make the selected area bigger (if possible)
								'Dim newLength As Integer
								'Select Case Me.ViewMode
								'  Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft
								'    Dim newRow As Integer = Me.Visibility.GetRowFromCor(e.X, e.Y) - Me.Selector.Row + 1
								'    Dim newColumn As Integer = Me.Visibility.GetColumnFromCor(e.X, e.Y) - Me.Selector.Column + 1
								'    newLength = newRow
								'    If newLength > 0 Then Me.Selector.Length = newLength
								'    OnRefresh()

								'  Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop
								'    Dim newRow As Integer = Me.Visibility.GetRowFromCor(e.X, e.Y) - Me.Selector.Row + 1
								'    Dim newColumn As Integer = Me.Visibility.GetColumnFromCor(e.X, e.Y) - Me.Selector.Column + 1
								'    newLength = newColumn
								'    If newLength > 0 Then Me.Selector.Length = newLength
								'    OnRefresh()

								'  Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.DayLeftProviderTop, ViewModeConstants.RoomLeftProviderTop
								'    'Do Nothing
								'  Case ViewModeConstants.Month
								'    'TODO
								'  Case ViewModeConstants.MonthFull
								'								'TODO - MonthFull
								'  Case ViewModeConstants.ResourceLeftTimeTop
								'    'TODO - Write ResourceLeftTimeTop
								'  Case ViewModeConstants.ResourceTopTimeLeft
								'    'TODO - Write ResourceTopTimeLeft
								'  Case Else
								'    Call ErrorModule.ViewmodeErr()
								'End Select
							Else
								If Me.AllowSelector Then
									Dim newCol As Integer = Me.Visibility.GetColumnFromCor(e.X, e.Y)
									Dim newRow As Integer = Me.Visibility.GetRowFromCor(e.X, e.Y)
									If (newCol <> -1) AndAlso (newRow <> -1) Then
										Dim localLockKey As String = PrepareForProcessing()
										Me.Selector.NoScroll = True
										Me.Selector.Column = newCol
										Me.Selector.Row = newRow
										Me.Selector.NoScroll = False
										Me.Selector.Length = 1
										Me.PrepareForProcessing(localLockKey)
										OnRefresh()
									End If
								End If
							End If

							Dim area As ScheduleArea
							'Add ability to know if clicked a NoDropZone
							area = Me.NoDropAreaCollection.HitTest(e.X, e.Y)
							If Not (area Is Nothing) Then
								Dim eventParam1 As ScheduleAreaMouseEventArgs = New ScheduleAreaMouseEventArgs(area, e)
								OnNoDropAreaClick(eventParam1)
								useBackgroundClick = False
							End If

							'Add ability to know if clicked an ColoredAreaCollection
							area = Me.ColoredAreaCollection.HitTest(e.X, e.Y)
							If Not (area Is Nothing) Then
								Dim eventParam1 As ScheduleAreaMouseEventArgs = New ScheduleAreaMouseEventArgs(area, e)
								OnColoredAreaClick(eventParam1)
								useBackgroundClick = False
							End If

						End If

					End If

					'Raise the background click event
					If useBackgroundClick AndAlso (e.X > Me.ClientLeft) AndAlso (e.Y > Me.ClientTop) Then
						OnBackgroundClick(e)
					End If

				End If
				SelectedItemOnMouseDown = Me.SelectedItem

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				PrepareForProcessing(lockKey)
			End Try

		End Sub

		Private Sub Schedule_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseEnter
			OnMouseEnter(e)
		End Sub

		Private Sub Schedule_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.MouseLeave

			Try
				'If the mouse left then there should be no tooltip
				ToolTipAppointment = Nothing
				Call Me.ToolTip1.SetToolTip(Me, "")
				OnMouseLeave(e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub Schedule_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

			If Not Me.Enabled Then Return
			MoveX = e.X
			MoveY = e.Y

			Try

				'******************************************************
				'Calculate the row/col resize and make GUI adjustments
				If AppointmentOutline.ResizeRowColObject.IsResizing Then
					If AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Column Then
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
						lblResize.Location = New Point(e.X, 0)
					ElseIf AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Row Then
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
						lblResize.Location = New Point(0, e.Y)
					End If
					Call lblResize.Refresh()

				ElseIf ResizeAppointmentObject.IsEndResizing Then
					Dim startDate As DateTime
					Dim startTime As DateTime
					Dim length As Integer
					If AppointmentOutline.DrawAppointmentResizeOutline(Me.SelectedItem, New Point(e.X, e.Y), True, startDate, startTime, length) Then
						'AppointmentOutline.ResizeRowColObject.StartDate = ScheduleGlobals.GetDateByViewMode(me.ViewMode, Me.SelectedItem.StartDate)
						AppointmentOutline.ResizeRowColObject.StartTime = startTime
						AppointmentOutline.ResizeRowColObject.Length = length
					End If

				ElseIf ResizeAppointmentObject.IsStartResizing Then
					Dim startDate As DateTime
					Dim startTime As DateTime
					Dim length As Integer
					If AppointmentOutline.DrawAppointmentResizeOutline(Me.SelectedItem, New Point(e.X, e.Y), False, startDate, startTime, length) Then
						AppointmentOutline.ResizeRowColObject.StartDate = ScheduleGlobals.GetDateByViewMode(Me.ViewMode, startDate)
						AppointmentOutline.ResizeRowColObject.StartTime = startTime
						AppointmentOutline.ResizeRowColObject.Length = length
					End If

				Else
					'If not resizing then check to change the mousepointer
					If Me.ColumnHeader.AllowResize AndAlso (e.Y <= Me.ClientTop) And Me.OverColumnBreak(e.X, e.Y) Then
						'Over column break
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
						Return
					ElseIf Me.RowHeader.AllowResize AndAlso (e.X <= Me.ClientLeft) And Me.OverRowBreak(e.X, e.Y) Then
						'Over row break
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
						Return
					ElseIf Not (Me.SelectedItem Is Nothing) AndAlso (Not Me.SelectedItem.IsReadOnly) Then
						'If the mouse is over the selected item then show the resize handles
						'If it is a normal appointment (not event or activity)
						If Not (Me.SelectedItem.IsActivity OrElse Me.SelectedItem.IsEvent) AndAlso (CType(Me.SelectedItem, Appointment).OverTopResizeBorder(Me, e.X, e.Y) OrElse CType(Me.SelectedItem, Appointment).OverBottomResizeBorder(Me, e.X, e.Y)) Then
							Select Case Me.ViewMode
								Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
									System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
								Case ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.DayLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
									System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
								Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.DayLeftProviderTop, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.Month, ViewModeConstants.DayLeftResourceTop
									'Do Nothing
								Case ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTimeLeftRoomTop
									System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
								Case ViewModeConstants.Week
									'Do Nothing
								Case ViewModeConstants.MonthFull
									'Do Nothing
								Case Else
									Call ErrorModule.ViewmodeErr()
							End Select
						Else
							System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
						End If
					Else
						'There is no SelectedItem
						System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

						'If the mouse if moving with the mouse pressed and we are not 
						'resizing or dragging then the Selector length is being modified
						If (e.Button = System.Windows.Forms.MouseButtons.Left) AndAlso (Me.AllowSelector) Then
							Dim row As Integer = Me.Visibility.GetRowFromCor(e.X, e.Y)
							Dim column As Integer = Me.Visibility.GetColumnFromCor(e.X, e.Y)

							Select Case Me.ViewMode
								Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
									'Row can grow
									Dim newLength As Integer = row - Me.Selector.Row + 1
									Me.Selector.Length = newLength
								Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
									'Column can grow
									Dim newLength As Integer = column - Me.Selector.Column + 1
									Me.Selector.Length = newLength
								Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayTopProviderLeft, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.Month, ViewModeConstants.DayLeftProviderTop, ViewModeConstants.DayLeftResourceTop
									'Do Nothing
								Case ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTimeLeftRoomTop
									'Row can grow
									Dim newLength As Integer = row - Me.Selector.Row + 1
									Me.Selector.Length = newLength
								Case ViewModeConstants.Week
									'Do Nothing
								Case ViewModeConstants.MonthFull
									'Do Nothing
								Case Else
									Call ErrorModule.ViewmodeErr()
							End Select

						End If									'Mouse Button Pressed

					End If

				End If

				'If there was no button pressed and over an appointment then show tooltip text
				If e.Button = System.Windows.Forms.MouseButtons.None Then
					'No mouse button is pressed
					'Check to determine if the mouse is over an appointment
					Dim appointment As Appointment = Me.AppointmentCollection.HitTest(MoveX, MoveY)
					If (appointment Is Nothing) AndAlso (ToolTipAppointment Is Nothing) Then
						'Do Nothing
					ElseIf (appointment Is Nothing) Then
						ToolTipAppointment = Nothing
						Call Me.ToolTip1.SetToolTip(Me, "")
					ElseIf appointment.Blockout Then
						ToolTipAppointment = Nothing
						Call Me.ToolTip1.SetToolTip(Me, "")
					ElseIf Not (appointment Is ToolTipAppointment) Then
						ToolTipAppointment = appointment
						Dim text As String = appointment.ToolTipText
						Dim eventParam1 As New ToolTipAppointmentEventArgs(text, "", appointment)
						OnBeforeToolTip(eventParam1)
						If eventParam1.Text <> "" Then
#If VS2005 Then
							Me.ToolTip1.ToolTipTitle = eventParam1.HeaderText
#End If
							Call Me.ToolTip1.SetToolTip(Me, eventParam1.Text)
						End If
					End If
				End If

				'Start dragging if necessary
				If ((e.Button And System.Windows.Forms.MouseButtons.Left) = System.Windows.Forms.MouseButtons.Left) Then
					'If the mouse moves outside the rectangle, start the drag. 
					If (Rectangle.op_Inequality(dragBoxFromMouseDown, Rectangle.Empty) And (Not dragBoxFromMouseDown.Contains(e.X, e.Y))) And (Not TimerDrag.Enabled) Then
						TimerDrag.Enabled = True
					End If
				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub Schedule_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

			TimerDrag.Enabled = False
			lblToolTip.Visible = False

			Try
				If ((e.Button And System.Windows.Forms.MouseButtons.Left) = System.Windows.Forms.MouseButtons.Left) Then
					' If the mouse moves outside the rectangle, start the drag. 
					If (Rectangle.op_Inequality(editBoxFromMouseDown, Rectangle.Empty) And editBoxFromMouseDown.Contains(e.X, e.Y)) And (Not TimerEdit.Enabled) Then
						TimerEdit.Enabled = True
					End If
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				editBoxFromMouseDown = Rectangle.Empty
				dragBoxFromMouseDown = Rectangle.Empty
			End Try

			Dim lockKey As String = PrepareForProcessing()
			Try
				'******************************************************
				'If we are resizing an appointment
				If (ResizeAppointmentObject.IsStartResizing OrElse ResizeAppointmentObject.IsEndResizing) AndAlso Not (Me.SelectedItem Is Nothing) Then
					If (Me.SelectedItem.StartDate <> AppointmentOutline.ResizeRowColObject.StartDate) OrElse _
					(ResizeAppointmentObject.Appointment.StartTime <> AppointmentOutline.ResizeRowColObject.StartTime) OrElse _
					(ResizeAppointmentObject.Appointment.Length <> AppointmentOutline.ResizeRowColObject.Length) Then

						Dim eventParam1 As New AppointmentSizeEventsArgs(Me.SelectedItem, AppointmentOutline.ResizeRowColObject.StartTime, AppointmentOutline.ResizeRowColObject.Length)
						OnBeforeAppointmentResize(eventParam1)
						If eventParam1.Cancel Then
							AppointmentOutline.DragRectArray.Clear()
							AppointmentOutline.ResizeRowColObject.IsResizing = False
							ResizeAppointmentObject.IsStartResizing = False
							ResizeAppointmentObject.IsEndResizing = False
							Me.DrawingDirty = True
							OnRefresh()
							Return
						End If

						Dim lockKey1 As String = PrepareForProcessing()
						Try
							If AppointmentOutline.ResizeRowColObject.StartDate <> DefaultNoDate Then
								Me.SelectedItem.StartDate = AppointmentOutline.ResizeRowColObject.StartDate
							End If
							If AppointmentOutline.ResizeRowColObject.StartDate <> DefaultNoTime Then
								Me.SelectedItem.StartTime = AppointmentOutline.ResizeRowColObject.StartTime
							End If
							Me.SelectedItem.Length = AppointmentOutline.ResizeRowColObject.Length
						Catch
						Finally
							Me.PrepareForProcessing(lockKey1)
						End Try
						Me.DrawingDirty = True
						OnRefresh()
						Dim eventParam2 As New BeforeBaseObjectEventArgs(Me.SelectedItem)
						OnAfterAppointmentResize(eventParam2)
						If eventParam2.Cancel Then
							Dim lockKey2 As String = PrepareForProcessing()
							Try
								ResizeAppointmentObject.Appointment.StartTime = ResizeAppointmentObject.AppointmentValues.StartTime
								ResizeAppointmentObject.Appointment.Length = ResizeAppointmentObject.AppointmentValues.Length
							Catch ex As Exceptions.GravityboxException
								ErrorModule.SetErr(ex)
							Catch ex As Exception
								ErrorModule.SetErr(ex)
							Finally
								Me.PrepareForProcessing(lockKey2)
							End Try
							AppointmentOutline.DragRectArray.Clear()
							Me.Refresh()
						End If
					End If
				End If
				AppointmentOutline.DragRectArray.Clear()

				'******************************************************
				'If we are resizing a row/column then reset the size
				If AppointmentOutline.ResizeRowColObject.IsResizing Then
					AppointmentOutline.ResizeRowColObject.IsResizing = False
					lblResize.Visible = False
					If AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Column Then
						Dim diff As Integer = e.X - AppointmentOutline.ResizeRowColObject.ResizeCor

						'Calculate the size
						Dim value As Integer = (Me.ColumnHeader.Size + diff)
						If value < MinRowColSize Then value = MinRowColSize

						'Raise an event to the caller
						Dim eventParam1 As New BeforeRowColResizeEventArgs(value)
						OnBeforeColumnResize(eventParam1)
						If eventParam1.Cancel Then Exit Sub
						If eventParam1.Size < MinRowColSize Then eventParam1.Size = MinRowColSize

						Me.ColumnHeader.Size = eventParam1.Size

						'Raise an event to the caller
						Dim eventParam2 As New AfterRowColResizeEventArgs(eventParam1.Size)
						LastColumnSize = eventParam1.Size
						OnAfterColumnResize(eventParam2)

					ElseIf AppointmentOutline.ResizeRowColObject.ResizeDirection = ResizeRowColInfo.ResizeInfoDirection.Row Then
						Dim diff As Integer = e.Y - AppointmentOutline.ResizeRowColObject.ResizeCor

						'Calculate the size
						Dim value As Integer = (Me.RowHeader.Size + diff)
						If value < MinRowColSize Then value = MinRowColSize

						'Raise an event to the caller
						Dim eventParam1 As New BeforeRowColResizeEventArgs(value)
						OnBeforeRowResize(eventParam1)
						If eventParam1.Cancel Then Exit Sub
						If eventParam1.Size < MinRowColSize Then eventParam1.Size = MinRowColSize

						Me.RowHeader.Size = eventParam1.Size

						'Raise an event to the caller
						Dim eventParam2 As New AfterRowColResizeEventArgs(eventParam1.Size)
						LastRowSize = eventParam1.Size
						OnAfterRowResize(eventParam2)

					End If

				ElseIf ResizeAppointmentObject.IsStartResizing Then
					ResizeAppointmentObject.IsStartResizing = False
					If Not (Me.SelectedItem Is Nothing) Then
						Call CType(Me.SelectedItem, Appointment).SetNewStartByCor(Me, e.X, e.Y)
					End If
					Me.DrawingDirty = True
					OnRefresh()

				ElseIf ResizeAppointmentObject.IsEndResizing Then
					ResizeAppointmentObject.IsEndResizing = False
					If Not (Me.SelectedItem Is Nothing) Then
						Call CType(Me.SelectedItem, Appointment).SetNewEndByCor(Me, e.X, e.Y)
					End If
					Me.DrawingDirty = True
					OnRefresh()

				ElseIf Not (Me.SelectedItem Is Nothing) Then
					Dim eventParam As New AppointmentMouseEventArgs(Me.SelectedItem, e.Button, e.Clicks, e.X, e.Y, e.Delta)
					If (Me.SelectedItem.Header.HeaderType <> AppointmentHeader.HeaderTypeConstants.None) AndAlso Me.SelectedItem.Header.ClientRectangle.Contains(LastMouseObject.X, LastMouseObject.Y) Then
						OnAppointmentHeaderClick(eventParam)
					Else
						OnAppointmentClick(eventParam)
					End If

				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				PrepareForProcessing(lockKey)
			End Try

		End Sub

		Private Sub Schedule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

			Try

				If e.KeyCode = Keys.Delete AndAlso Me.AllowRemove Then
					For ii As Integer = Me.SelectedItems.Count - 1 To 0 Step -1
						Dim appointment As Gravitybox.Objects.Appointment = CType(Me.SelectedItems(ii), Gravitybox.Objects.Appointment)
						If (Not appointment.IsReadOnly) AndAlso (Not appointment.Blockout) Then
							Dim eventParam1 As New BeforeBaseObjectEventArgs(appointment)
							OnBeforeUserAppointmentRemove(eventParam1)
							If eventParam1.Cancel = True Then Return
							Call Me.AppointmentCollection.Remove(appointment)
							Dim eventParam2 As New AfterBaseObjectEventArgs(appointment)
							OnAfterUserAppointmentRemove(eventParam2)
						End If
					Next
					Call Me.SelectedItems.Clear()
					OnRefresh()

				ElseIf e.KeyCode = Keys.Left Then
					If ViewMode = ViewModeConstants.Month Then
						Dim lockKey As String = PrepareForProcessing()
						If (Me.Selector.Column = 0) AndAlso (Me.Selector.Row = 0) Then
							'Do Nothing
						ElseIf Me.Selector.Column = 0 Then
							Me.Selector.Row -= 1
							If Me.Selector.Row > 0 Then Me.Selector.Column = Me.Visibility.TotalColumnCount
						ElseIf Me.Selector.Column < 5 Then
							Me.Selector.Column -= 1
						ElseIf (Me.Selector.Row Mod 2) = 0 Then
							Me.Selector.Column -= 1
						Else
							Me.Selector.Row -= 1
						End If
						Me.PrepareForProcessing(lockKey)
						Me.Refresh()
					ElseIf ViewMode = ViewModeConstants.MonthFull Then
						Dim lockKey As String = PrepareForProcessing()
						If (Me.Selector.Column = 0) AndAlso (Me.Selector.Row = 0) Then
							'Do Nothing
						ElseIf (Me.Selector.Column = 0) AndAlso (Me.Selector.Row > 0) Then
							Me.Selector.Column = DaysPerWeek - 1
							Me.Selector.Row -= 1
						ElseIf (Me.Selector.Column > 0) Then
							Me.Selector.Column -= 1
						End If
						Me.PrepareForProcessing(lockKey)
						Me.Refresh()
					ElseIf e.Shift AndAlso (Me.SelectedItems.Count = 0) Then
						'There are NO appointments selected so resize Selector
						Select Case Me.ViewMode
							Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
								Me.Selector.Length -= 1
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf e.Shift And (Me.SelectedItems.Count > 0) Then
						'There are appointments selected so resize them
						Select Case Me.ViewMode
							Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
								Call Me.SelectedItems.ChangeLengths(-Me.TimeIncrement, Me.TimeIncrement, Me.TimeIncrement)
								OnRefresh()
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf Me.AllowSelector Then
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Column -= 1
					Else
						If HScroll1.Value > HScroll1.Minimum Then HScroll1.Value -= 1
					End If

				ElseIf e.KeyCode = Keys.Right Then
					If ViewMode = ViewModeConstants.Month Then
						Dim lockKey As String = PrepareForProcessing()
						If Me.Selector.Column < 5 Then
							Me.Selector.Column += 1
						ElseIf (Me.Selector.Row Mod 2) = 0 Then
							Me.Selector.Row += 1
						ElseIf Me.Selector.Row < Me.Visibility.TotalRowCount - 1 Then
							Me.Selector.Column = 0
							Me.Selector.Row += 1
						End If
						Me.PrepareForProcessing(lockKey)
						Me.Refresh()
					ElseIf ViewMode = ViewModeConstants.MonthFull Then
						Dim lockKey As String = PrepareForProcessing()
						If Me.Selector.Column < 6 Then
							Me.Selector.Column += 1
						ElseIf Me.Selector.Row < Me.Visibility.TotalRowCount - 1 Then
							Me.Selector.Column = 0
							Me.Selector.Row += 1
						End If
						Me.PrepareForProcessing(lockKey)
						Me.Refresh()
					ElseIf e.Shift And (Me.SelectedItems.Count = 0) Then
						'There are NO appointments selected so resize Selector
						Select Case Me.ViewMode
							Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
								Me.Selector.Length += 1
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf e.Shift And (Me.SelectedItems.Count > 0) Then
						'There are appointments selected so resize them
						Select Case Me.ViewMode
							Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop
								Call Me.SelectedItems.ChangeLengths(Me.TimeIncrement, Me.TimeIncrement, Me.TimeIncrement)
								OnRefresh()
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf Me.AllowSelector Then
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Column += 1
					Else
						If HScroll1.Value < HScroll1.Maximum Then HScroll1.Value += 1
					End If

				ElseIf e.KeyCode = Keys.Up Then
					If ViewMode = ViewModeConstants.Month Then
						If Me.Selector.Column < 5 Then
							If Me.Selector.Row > 1 Then Me.Selector.Row -= 2
						Else
							If Me.Selector.Row > 0 Then Me.Selector.Row -= 1
						End If
					ElseIf e.Shift And (Me.SelectedItems.Count = 0) Then
						'There are NO appointments selected so resize Selector
						Select Case Me.ViewMode
							Case ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
								Me.Selector.Length -= 1
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf e.Shift And (Me.SelectedItems.Count > 0) Then
						'There are appointments selected so resize them
						Select Case Me.ViewMode
							Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
								Call Me.SelectedItems.ChangeLengths(-Me.TimeIncrement, Me.TimeIncrement, Me.TimeIncrement)
								OnRefresh()
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf Me.AllowSelector Then
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Row -= 1
					Else
						If VScroll1.Value > VScroll1.Minimum Then VScroll1.Value -= 1
					End If

				ElseIf e.KeyCode = Keys.Down Then
					If ViewMode = ViewModeConstants.Month Then
						If Me.Selector.Column < 5 Then
							If Me.Selector.Row < Me.Visibility.TotalRowCount - 2 Then Me.Selector.Row += 2
						Else
							If Me.Selector.Row < Me.Visibility.TotalRowCount - 1 Then Me.Selector.Row += 1
						End If
					ElseIf e.Shift And (Me.SelectedItems.Count = 0) Then
						'There are NO appointments selected so resize Selector
						Select Case Me.ViewMode
							Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft
								Me.Selector.Length += 1
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf e.Shift And (Me.SelectedItems.Count > 0) Then
						'There are appointments selected so resize them
						Select Case Me.ViewMode
							Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft
								Call Me.SelectedItems.ChangeLengths(Me.TimeIncrement, Me.TimeIncrement, Me.TimeIncrement)
								OnRefresh()
								'Case Else
								'Call ErrorModule.ViewmodeErr()
						End Select
					ElseIf Me.AllowSelector Then
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Row += 1
					Else
						If VScroll1.Value < VScroll1.Maximum Then VScroll1.Value += 1
					End If

				ElseIf e.KeyCode = Keys.PageUp Then
					If Me.ViewMode = ViewModeConstants.Month Then
						Dim newDate As DateTime = DateAdd(DateInterval.Month, -1, Me.MonthSelDate)
						If Not ((Me.MinDate <= newDate) And (newDate <= Me.MaxDate)) Then Return
						Me.MonthSelDate = newDate
						OnRefresh()
					Else
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Row -= VScroll1.LargeChange
					End If

				ElseIf e.KeyCode = Keys.PageDown Then
					If Me.ViewMode = ViewModeConstants.Month Then
						Dim newDate As DateTime = DateAdd(DateInterval.Month, 1, Me.MonthSelDate)
						If Not ((Me.MinDate <= newDate) And (newDate <= Me.MaxDate)) Then Return
						Me.MonthSelDate = newDate
						OnRefresh()
					Else
						Me.SelectedItems.Clear()
						Me.Selector.Length = 1
						Me.Selector.Row += VScroll1.LargeChange
					End If

				ElseIf e.KeyCode = Keys.Home Then
					Me.SelectedItems.Clear()
					Me.Selector.Length = 1
					If e.Control Then
						Me.Selector.Row = 1
					End If
					Me.Selector.Column = 1

				ElseIf e.KeyCode = Keys.End Then
					Me.SelectedItems.Clear()
					Me.Selector.Length = 1
					If e.Control Then Me.Selector.Row = Me.Visibility.TotalRowCount
					Me.Selector.Column = Me.Visibility.TotalColumnCount

				ElseIf e.KeyCode = Keys.Escape Then

					'If nothing to do then exit
					If Not (ResizeAppointmentObject.IsStartResizing Or ResizeAppointmentObject.IsEndResizing Or AppointmentOutline.ResizeRowColObject.IsResizing) Then
						Return
					End If

					If Not (Me.SelectedItem Is Nothing) Then
						Me.SelectedItem.StartDate = ResizeAppointmentObject.AppointmentValues.StartDate
						Me.SelectedItem.StartTime = ResizeAppointmentObject.AppointmentValues.StartTime
						If RoomCollection.Contains(ResizeAppointmentObject.AppointmentValues.StartRoom) Then
							Me.SelectedItem.Room = Me.RoomCollection(ResizeAppointmentObject.AppointmentValues.StartRoom)
						End If
						Me.SelectedItem.Length = ResizeAppointmentObject.AppointmentValues.Length
					End If

					If ResizeAppointmentObject.IsStartResizing Or ResizeAppointmentObject.IsEndResizing Then
						ResizeAppointmentObject = New ResizeAppointmentInfo
					ElseIf AppointmentOutline.ResizeRowColObject.IsResizing Then
						AppointmentOutline.ResizeRowColObject = New ResizeRowColInfo
					End If
					OnRefresh()

				ElseIf e.KeyCode = Keys.Enter Then
					Call Me.CreateDefaultAppointment()

				ElseIf e.KeyCode = Keys.F2 Then
					If Not (Me.SelectedItem Is Nothing) AndAlso (Not Me.SelectedItem.IsReadOnly) Then
						Call StartInGridEdit(Me.SelectedItem)
					End If

				ElseIf e.KeyCode = Keys.ShiftKey Then
					'Do Nothing

				End If
				e.Handled = False

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
			End Try

		End Sub

		Private Sub ScrollTimerHTick(ByVal sender As Object, ByVal e As System.EventArgs)
			Me.ScrollTimerH.Stop()
			If Not Me.DynamicScroll Then
				Me.DrawingDirty = True
				OnRefresh()
				OnHorizontalScroll(New System.EventArgs)
			End If
			lblToolTip.Visible = False
		End Sub

		Private Sub ScrollTimerVTick(ByVal sender As Object, ByVal e As System.EventArgs)
			Me.ScrollTimerV.Stop()
			If Not Me.DynamicScroll Then
				Me.DrawingDirty = True
				OnRefresh()
				OnVerticalScroll(New System.EventArgs)
			End If
			lblToolTip.Visible = False
		End Sub

#End Region

#Region "AppointmentCollection Events"

		Private Sub AppointmentCollectionAfterAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.DrawingDirty = True
			Try
				Me.DrawingDirty = True
				OnAfterAppointmentAdd(e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentCollectionBeforeAdd(ByVal sender As Object, ByVal e As BeforeBaseObjectEventArgs)
			Try
				Me.DrawingDirty = True
				OnBeforeAppointmentAdd(e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentCollectionAfterRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Try
				Me.DrawingDirty = True
				OnAfterAppointmentRemove(e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentCollectionBeforeRemove(ByVal sender As Object, ByVal e As BeforeBaseObjectEventArgs)
			Try
				OnBeforeAppointmentRemove(e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentCollectionValidateRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)

			Try
				Dialogs.RemoveAlarm(CType(e.BaseObject, Appointment))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

			Try
				Dim F As Forms.AppointmentPropertiesForm
				F = Dialogs.GetPropertyForm(e.BaseObject.Key)
				If Not (F Is Nothing) Then Call F.Close()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

			OnValidateAppointmentRemove(e)

		End Sub

		Private Sub RecurrenceCollectionRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Try
				For Each appointment As Gravitybox.Objects.Appointment In Me.AppointmentCollection
					If e.BaseObject Is appointment.Recurrence Then
						appointment.Recurrence = Nothing
					End If
				Next
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub RecurrenceCollectionRemove()
			Try
				For Each appointment As Gravitybox.Objects.Appointment In Me.AppointmentCollection
					appointment.Recurrence = Nothing
				Next
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub CollectionReload(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Me.DrawingDirty = True
				OnRefresh()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "InGridEdit"

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Function IsInplaceEditing() As Boolean
			Return txtBox.Visible
		End Function

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub SaveInGridEdit()

			If Me.HasDisposed Then Return
			Try
				If Not txtBox.Visible Then Return
				If Me.SelectedItem Is Nothing Then Return
				Me.SelectedItem.Subject = txtBox.Text
				txtBox.Visible = False

				If Me.SafeRedraw Then
					CType(Me.SelectedItem, Appointment).Draw(Me.CreateGraphics, Me)
				End If

				'Raise the after event
				Dim eventParam1 As New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me.SelectedItem)
				OnAfterInPlaceEdit(eventParam1)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub StartInGridEdit(ByVal appointment As Appointment, ByVal pt As Point)

			Try
				'If no appointment then skip out
				If appointment Is Nothing Then Return
				If Not Me.AllowInPlaceEdit Then Return

				'Make sure that this is the SelectedItem
				If Not (Me.SelectedItem Is appointment) Then
					Dim lockKey As String = PrepareForProcessing()
					Call Me.SelectedItems.Clear()
					Me.SelectedItem = appointment
					Me.PrepareForProcessing(lockKey)
				End If

				'Raise the after event
				Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs(Me.SelectedItem)
				OnBeforeInPlaceEdit(eventParam1)
				If eventParam1.Cancel Then Return

				Dim rectangle As Rectangle
				If (pt.X = 0) And (pt.Y = 0) Then
					If appointment.Rectangles.Count = 0 Then Return
					rectangle = appointment.Rectangles(0).Rect
				Else
					rectangle = appointment.Rectangles.GetRectangle(pt).Rect
				End If

				Dim CurrentAppearance As AppointmentAppearance = appointment.Appearance
				If (Me.SelectionType = SelectionTypeConstants.SelectedAppearance) AndAlso SelectedItems.Contains(appointment) Then
					CurrentAppearance = Me.SelectedAppointmentAppearance
				End If

				txtBox.SetBounds(rectangle.Left, rectangle.Top, rectangle.Width, rectangle.Height)
				txtBox.BackColor = CurrentAppearance.BackColor
				txtBox.ForeColor = CurrentAppearance.ForeColor
				Dim fontStyle As New System.Drawing.FontStyle
				If CurrentAppearance.FontBold Then fontStyle = fontStyle Or fontStyle.Bold
				If CurrentAppearance.FontItalics Then fontStyle = fontStyle Or fontStyle.Italic
				If CurrentAppearance.FontStrikeout Then fontStyle = fontStyle Or fontStyle.Strikeout
				If CurrentAppearance.FontUnderline Then fontStyle = fontStyle Or fontStyle.Underline
				txtBox.BackColor = CurrentAppearance.BackColor
				txtBox.Font = New Font(txtBox.Font.FontFamily, CurrentAppearance.FontSize, fontStyle, CurrentAppearance.FontUnit)
				txtBox.Text = appointment.Subject
				txtBox.Visible = True
				Call txtBox.Focus()

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		''' <summary>
		''' This method will start an inplace edit of an appointment.
		''' </summary>
		<Browsable(False), _
		Description("This method will start an inplace edit of an appointment.")> _
		Public Sub StartInGridEdit(ByVal appointment As Appointment)

			Try
				Call StartInGridEdit(appointment, New Point(0, 0))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "IsInputKey"

		Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean

			Try
				keyData = keyData And Keys.KeyCode
				Select Case keyData
					Case Keys.Up, Keys.Down, Keys.Right, Keys.Left, Keys.PageUp, Keys.PageDown, Keys.Home, Keys.End, Keys.Escape, Keys.Shift, Keys.ShiftKey, Keys.Control, Keys.Alt, Keys.F2
						Call MyBase.IsInputKey(keyData)
						Return True
					Case Else
						Return False
				End Select

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Internal Fire Events"

		Friend Sub FireEventBeforeResourceHeaderDraw(ByVal sender As Object, ByVal e As BeforeResourceHeaderEventArgs)
			Me.OnBeforeResourceHeaderDraw(e)
		End Sub

		Friend Sub FireEventBeforeRoomHeaderDraw(ByVal sender As Object, ByVal e As BeforeRoomHeaderEventArgs)
			Me.OnBeforeRoomHeaderDraw(e)
		End Sub

		Friend Sub FireEventBeforeProviderHeaderDraw(ByVal sender As Object, ByVal e As BeforeProviderHeaderEventArgs)
			Me.OnBeforeProviderHeaderDraw(e)
		End Sub

		Friend Sub FireEventBeforeDateHeaderDraw(ByVal sender As Object, ByVal e As BeforeHeaderEventArgs)
			Me.OnBeforeDateHeaderDraw(e)
		End Sub

		Friend Sub FireEventBeforeAppointmentTextDraw(ByVal sender As Object, ByVal e As BeforeAppointmentTextEventArgs)
			Me.OnBeforeAppointmentTextDraw(e)
		End Sub

		Friend Sub FireEventBeforeTimeBarDraw(ByVal sender As Object, ByVal e As AppointmentUserDrawEventArgs)
			Me.OnUserDrawnTimeBar(e)
		End Sub

		Friend Sub FireEventBeforePropertyDialog(ByVal sender As Object, ByVal e As BeforePropertyDialogEventArgs)
			Me.OnBeforePropertyDialog(e)
		End Sub

		Friend Sub FireEventAfterPropertyDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterPropertyDialog(e)
		End Sub

		Friend Sub FireEventAfterCancelPropertyDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterCancelPropertyDialog(e)
		End Sub

		Friend Sub FireEventAfterSavePropertyDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterSavePropertyDialog(e)
		End Sub

		Friend Sub FireEventBeforeCategoryListDialog(ByVal sender As Object, ByVal e As BeforeCategoryListDialogEventArgs)
			Me.OnBeforeCategoryListDialog(e)
		End Sub

		Friend Sub FireEventAfterCategoryListDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterCategoryListDialog(e)
		End Sub

		Friend Sub FireEventBeforeProviderListDialog(ByVal sender As Object, ByVal e As BeforeProviderListDialogEventArgs)
			Me.OnBeforeProviderListDialog(e)
		End Sub

		Friend Sub FireEventAfterProviderListDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterProviderListDialog(e)
		End Sub

		Friend Sub FireEventBeforeProviderConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforeProviderConfigurationDialog(e)
		End Sub

		Friend Sub FireEventAfterProviderConfigurationDialog()
			Me.OnAfterProviderConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventBeforeResourceListDialog(ByVal sender As Object, ByVal e As BeforeResourceListDialogEventArgs)
			Me.OnBeforeResourceListDialog(e)
		End Sub

		Friend Sub FireEventAfterResourceListDialog(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Me.OnAfterResourceListDialog(e)
		End Sub

		Friend Sub FireEventBeforeResourceConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforeResourceConfigurationDialog(e)
		End Sub

		Friend Sub FireEventAfterResourceConfigurationDialog()
			Me.OnAfterResourceConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventBeforeCategoryConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforeCategoryConfigurationDialog(e)
		End Sub

		Friend Sub FireEventAfterCategoryConfigurationDialog()
			Me.OnAfterCategoryConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventBeforeRoomConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforeRoomConfigurationDialog(e)
		End Sub

		Friend Sub FireEventBeforeAppearanceConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforeAppearanceConfigurationDialog(e)
		End Sub

		Friend Sub FireEventAfterRoomConfigurationDialog()
			Me.OnAfterRoomConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventAfterAppearanceConfigurationDialog()
			Me.OnAfterAppearanceConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventBeforePropertyItemConfigurationDialog(ByVal sender As Object, ByVal e As BeforeConfigurationDialogEventArgs)
			Me.OnBeforePropertyItemConfigurationDialog(e)
		End Sub

		Friend Sub FireEventAfterPropertyItemConfigurationDialog()
			Me.OnAfterPropertyItemConfigurationDialog(New System.EventArgs)
		End Sub

		Friend Sub FireEventPrintSetup(ByVal sender As Object, ByVal e As PrintSetupEventArgs)
			Me.OnPrintSetup(e)
		End Sub

		Friend Sub FireEventBeforePrintHeader(ByVal sender As Object, ByVal e As BeforePrintSectionEventArgs)
			Me.OnBeforePrintHeader(e)
		End Sub

		Friend Sub FireEventBeforePrintFooter(ByVal sender As Object, ByVal e As BeforePrintSectionEventArgs)
			Me.OnBeforePrintFooter(e)
		End Sub

		Friend Sub FireEventBeforePrintPageNumber(ByVal sender As Object, ByVal e As BeforePrintSectionEventArgs)
			Me.OnBeforePrintPageNumber(e)
		End Sub

		Friend Sub FireEventPrintProgress(ByVal sender As Object, ByVal e As PrintEventArgs)
			Me.OnPrintProgress(e)
		End Sub

		Friend Sub FireEventPrintCanceled()
			Me.OnPrintCanceled(New System.EventArgs)
		End Sub

		Friend Sub FireEventPropertyDialogSaveInvalidArea(ByVal sender As Object, ByVal e As TextExtendedEventArgs)
			Me.OnPropertyDialogSaveInvalidArea(e)
		End Sub

		Friend Sub FireEventPropertyDialogRemoveFiles(ByVal sender As Object, ByVal e As TextExtendedEventArgs)
			Me.OnPropertyDialogRemoveFiles(e)
		End Sub

		Friend Sub FireEventPropertyDialogSaveValueOutOfRange(ByVal sender As Object, ByVal e As TextExtendedEventArgs)
			Me.OnPropertyDialogSaveValueOutOfRange(e)
		End Sub

		Friend Sub FireEventDataSourceUpdated()
			'Ensure that we should not cancel this event
			If Not CancelEventDataSourceUpdated Then
				RaiseEvent DataSourceUpdated(Me, New System.EventArgs)
			End If
		End Sub

		Friend Sub FireBeforeRecurrenceDialog(ByVal e As BeforeRecurrenceDialogEventArgs)
			Me.OnBeforeRecurrenceDialog(Me, e)
		End Sub

		Friend Sub FireAfterRecurrenceDialog(ByVal appointment As Appointment)
			Dim e As New AfterBaseObjectEventArgs(appointment)
			Me.OnAfterRecurrenceDialog(Me, e)
		End Sub

		Friend Sub FireAppointmentDismissed(ByVal appointment As Appointment)
			Me.OnAppointmentDismissed(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(appointment))
		End Sub

		Friend Sub FireAppointmentSnooze(ByVal appointment As Appointment)
			Me.OnAppointmentSnooze(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(appointment))
		End Sub

		Friend Sub FireBeforeDragTip(ByVal e As BeforeDragTipEventArgs)
			Me.OnBeforeDragTip(e)
		End Sub

		Friend Sub FireBeforeAlarmDrawText(ByVal e As Objects.EventArgs.BeforeAppointmentTextEventArgs)
			Me.OnBeforeAlarmDrawText(e)
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub RepaintTimeHeader()

			If Me.HasDisposed Then Return

			'If the viewmode shows time then redraw
			Select Case Me.ViewMode
				Case ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop, ViewModeConstants.DayLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.RoomLeftTimeTop
					Call Canvas.DrawTimeHeaderTop(Me.CreateGraphics)
				Case ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft, ViewModeConstants.DayTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.RoomTopTimeLeft
					Call Canvas.DrawTimeHeaderLeft(Me.CreateGraphics, False)
				Case ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTimeLeftRoomTop
					Call Canvas.DrawDayTimeHeaderLeft(Me.CreateGraphics, False)
			End Select

		End Sub

#End Region

#Region "Timers"

		Private Sub TimerEdit_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerEdit.Tick

			Try
				editBoxFromMouseDown = Rectangle.Empty
				dragBoxFromMouseDown = Rectangle.Empty
				TimerEdit.Enabled = False
				If Me.SelectedItem Is Nothing Then Return
				If Me.SelectedItem.IsReadOnly Then Return
				Call Me.StartInGridEdit(Me.SelectedItem)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub TimerDrag_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerDrag.Tick

			editBoxFromMouseDown = Rectangle.Empty
			dragBoxFromMouseDown = Rectangle.Empty
			TimerDrag.Enabled = False
			TimerEdit.Enabled = False
			Try
				If Me.SelectedItem Is Nothing Then Return
				If Me.SelectedItem.IsReadOnly Then Return
				If Me.SelectedItem.Blockout Then Return

				DragAppointmentValues.StartDate = Me.SelectedItem.StartDate
				DragAppointmentValues.StartTime = Me.SelectedItem.StartTime
				If Not Me.SelectedItem.Room Is Nothing Then
					DragAppointmentValues.StartRoom = Me.RoomCollection.IndexOfVisible(SelectedItem.Room).ToString
				End If
				DragAppointmentValues.Providers.FromArray(Me.SelectedItem.ProviderList.ToArray())
				DragAppointmentValues.IsEvent = Me.SelectedItem.IsEvent
				'Dim myDataObject As DataObject = New DataObject(CType(Me.SelectedItem, Gravitybox.Objects.Appointment))
				Dim myDataObject As DataObject = New DataObject("Gravitybox.Objects.Appointment", Me.SelectedItem)

				'If in Provider mode then save the actual provider clicked
				Select Case Me.ViewMode
					Case ViewModeConstants.DayLeftProviderTop, ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTopProviderLeft, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.RoomTopProviderLeft
						Dim rectIndex As Integer = Me.SelectedItem.Rectangles.GetRectangleIndex(LastMouseObject.X, LastMouseObject.Y)
						If (rectIndex <> -1) Then
							myDataObject.SetData(GetType(Gravitybox.Objects.Provider), Me.SelectedItem.ProviderList(rectIndex))
						End If
				End Select

				'If in Resource mode then save the actual resource clicked
				Select Case Me.ViewMode
					Case ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.DayLeftResourceTop
						Dim rectIndex As Integer = Me.SelectedItem.Rectangles.GetRectangleIndex(LastMouseObject.X, LastMouseObject.Y)
						If (rectIndex <> -1) Then
							myDataObject.SetData(GetType(Gravitybox.Objects.Resource), Me.SelectedItem.ResourceList(rectIndex))
						End If
				End Select

				Call Me.DoDragDrop(myDataObject, DragDropEffects.Move Or DragDropEffects.Copy)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub TimerAppointmentStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAppointmentStart.Tick

			Try
				'Dim dayIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, PivotDate, GetDate(Now.Date)))
				'Dim timeIndex As Single = CSng(DateDiff(DateInterval.Minute, PivotTime, TimeSerial(Now.Hour, Now.Minute, 0)))
				'Dim pivotValue As Single = (dayIndex + (timeIndex / MinutesPerDay))
				Dim pivotValue As Single = GetAlarmPivotValue(Now)

				Dim appointment As Appointment
				For Each appointment In Me.AppointmentCollection

					'Only process if the alarm is set
					If appointment.Alarm.IsArmed Then
						'This is the appointments reminder time?
						Debug.WriteLine("Appointment Pivot: " & appointment.PivotStartValue(True) & "  -  " & "Time Pivot: " & pivotValue)
						If appointment.PivotStartValue(True) = pivotValue Then
							'Only go through all of this if the alarm is not already shown
							If (Not appointment.Alarm.ReminderDisplayed) AndAlso (Not Dialogs.AlarmVisible(appointment)) Then
								Dim dialogSettings As New AlarmDialogSettings
								dialogSettings.TimeSettings.TimeIncrement = Me.TimeIncrement
								dialogSettings.TimeSettings.ClockSetting = Me.ClockSetting
								If appointment.StartDateTime < Now Then
									dialogSettings.WindowText = "Overdue - " & appointment.StartDate.ToString("ddd") & " " & appointment.StartDate.ToShortDateString & " " & appointment.StartTime.ToShortTimeString
								Else
									dialogSettings.WindowText = "Reminder - " & appointment.StartDate.ToString("ddd") & " " & appointment.StartDate.ToShortDateString & " " & appointment.StartTime.ToShortTimeString
								End If
								Dim eventParam As BeforeAlarmEventArgs = New BeforeAlarmEventArgs(appointment, dialogSettings)
								OnBeforeAppointmentReminder(eventParam)
								appointment.Alarm.ReminderDisplayed = True
								If Not eventParam.Cancel Then
									Call Dialogs.ShowAlarmDialog(appointment, dialogSettings)
								End If
							End If
						End If

					End If					'IsArmed

					'Just in case it was removed in the last event
					If AppointmentCollection.IndexOf(appointment) <> -1 Then
						'This is the appointment start time?
						'Only go through all of this if the alarm is not already shown and time match
						If (Not appointment.Alarm.DueDisplayed) AndAlso (appointment.PivotStartValue(False) = pivotValue) Then
							Dim dialogSettings As New AlarmDialogSettings
							dialogSettings.TimeSettings.TimeIncrement = Me.TimeIncrement
							dialogSettings.TimeSettings.ClockSetting = Me.ClockSetting
							dialogSettings.WindowText = "Appointment Due"
							Dim eventParam As BeforeAlarmEventArgs = New BeforeAlarmEventArgs(appointment, dialogSettings)
							OnBeforeAppointmentDue(eventParam)
							appointment.Alarm.DueDisplayed = True
							If Not eventParam.Cancel Then
								If appointment.Alarm.IsArmed Then
									'Show the appointment alarm dialog
									Call Dialogs.ShowAlarmDialog(appointment, dialogSettings)
								End If
							End If
						End If
					End If

				Next

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Textbox Events"

		Private Sub txtBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBox.KeyDown

			Try
				If (e.KeyCode = Keys.Enter) AndAlso (e.Control) Then
					e.Handled = True
				ElseIf (e.KeyCode = Keys.Enter) Then
					Call SaveInGridEdit()
				ElseIf IsInplaceEditing() AndAlso (e.KeyCode = Keys.Escape) Then
					txtBox.Visible = False
				ElseIf (e.KeyCode = Keys.Escape) Then
					'Dim lockKey As String = PrepareForProcessing()
					'Me.SelectedItem = Nothing
					'Call SelectedItems.Clear()
					'Me.PrepareForProcessing(lockKey)
				End If
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Printing"

		''' <summary>
		''' This method previews the schedule.
		''' </summary>
		<Browsable(False), _
		Description("This method previews the schedule.")> _
		Public Function GoPreview(ByVal dialogSettings As PrintDialogSettings) As Boolean

			If dialogSettings Is Nothing Then
				Throw New Exceptions.GravityboxException("The settings object must be specified!")
			End If

			Me.Visibility.IsPrinting = True
			Try
				Me.DrawingDirty = True
				Me.Refresh()

				'Preview or print the specified view
				Dim printObject As New SchedulePrint(dialogSettings, Me)
				Call printObject.ShowDialog()
				Me.DrawingDirty = True
				Me.Refresh()

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
			Me.Visibility.IsPrinting = False

		End Function

		''' <summary>
		''' This method previews the schedule.
		''' </summary>
		<Browsable(False), _
		Description("This method previews the schedule.")> _
		Public Function GoPreview() As Boolean

			Try
				Dim dialogSettings As New PrintDialogSettings(Me.MinDate, Me.StartTime, Me.MaxDate, Me.EndTime)
				Return GoPreview(dialogSettings)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' This method prints the schedule.
		''' </summary>
		<Browsable(False), _
		Description("This method prints the schedule.")> _
		Public Function GoPrint(ByVal dialogSettings As PrintDialogSettings) As Boolean

			If dialogSettings Is Nothing Then
				Throw New Exceptions.GravityboxException("The settings object must be specified!")
			End If

			Me.Visibility.IsPrinting = True
			Try

				'Preview or print the specified view
				Dim printObject As New SchedulePrint(dialogSettings, Me)
				Call printObject.Print()
				Me.DrawingDirty = True
				Me.Refresh()

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
			Me.Visibility.IsPrinting = False

		End Function

		''' <summary>
		''' This method prints the schedule.
		''' </summary>
		<Browsable(False), _
		Description("This method prints the schedule.")> _
		Public Function GoPrint() As Boolean

			Try
				Dim dialogSettings As New PrintDialogSettings(Me.MinDate, Me.StartTime, Me.MaxDate, Me.EndTime)
				Return GoPrint(dialogSettings)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "OnDeserialization"

		Private Sub OnDeserialization(ByVal sender As Object) Implements System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			Call Schedule()
			Canvas = New Gravitybox.Drawing.DrawScheduleMain(Me)

		End Sub

#End Region

#Region "Scrolling Events"

		Private Sub HScroll1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles HScroll1.ValueChanged

			'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			Try

#If DEBUG Then
				Dim startTime As Date = DateTime.Now
#End If

				Me.ScrollTimerH.Stop()
				If Me.DynamicScroll Or UsingMouseWheel Then
					Me.DrawingDirty = True
					OnRefresh()
					OnHorizontalScroll(New System.EventArgs)
					Me.ScrollTimerH.Interval = 1000
				Else
					Me.ScrollTimerH.Enabled = True
					Me.ScrollTimerH.Interval = 200
				End If
				Me.ScrollTimerH.Start()
				lblToolTip.Text = Me.GetHorizontalScrollText()
				If (lblToolTip.Text <> "") Then
					lblToolTip.Location = New Point((Me.Width \ 2) - (lblToolTip.Width \ 2), Me.Height - lblToolTip.Height - Me.HScroll1.Height)
					lblToolTip.Visible = True
					lblToolTip.Refresh()
				End If

#If DEBUG Then
				Dim endTime As Date = DateTime.Now
				Debug.WriteLine("Scroll time: " & endTime.Subtract(startTime).TotalMilliseconds)
#End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'Me.Cursor = System.Windows.Forms.Cursors.Default
			End Try

		End Sub

		Private Sub VScroll1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles VScroll1.ValueChanged

			'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			Try

				Me.ScrollTimerV.Stop()
				If Me.DynamicScroll Or UsingMouseWheel Then
					Me.DrawingDirty = True
					OnRefresh()
					OnVerticalScroll(New System.EventArgs)
					Me.ScrollTimerV.Interval = 1000
				Else
					Me.ScrollTimerV.Enabled = True
					Me.ScrollTimerV.Interval = 200
				End If
				Me.ScrollTimerV.Start()
				lblToolTip.Text = Me.GetVerticalScrollText()
				If (lblToolTip.Text <> "") Then
					lblToolTip.Location = New Point(Me.Width - lblToolTip.Width - Me.VScroll1.Width, (Me.Height \ 2) - (lblToolTip.Height \ 2))
					lblToolTip.Visible = True
					lblToolTip.Refresh()
				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'Me.Cursor = System.Windows.Forms.Cursors.Default
			End Try

		End Sub

#End Region

#Region "LeftTopMargin"

		''' <summary>
		''' Returns the rectangle to the left of the column headers and above the row header.
		''' </summary>
		<Browsable(False)> _
		Public ReadOnly Property LeftTopMargin() As Rectangle
			Get
				'Return the rectangle for the top/left area
				Return New Rectangle(0, 0, Me.ClientLeft, Me.ClientTop)
			End Get
		End Property

#End Region

#Region "Scroll Texts"

		Private Function GetHorizontalScrollText() As String

			Dim retval As String = ""
			Select Case Me.ViewMode
				'Day Top
				Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayTopRoomLeft, ViewModeConstants.DayTopProviderLeft
					retval = Me.MinDate.AddDays(Me.HScroll1.Value).ToShortDateString()

					'Time Top
				Case ViewModeConstants.DayLeftTimeTop, ViewModeConstants.DayRoomLeftTimeTop, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.ProviderLeftTimeTop, ViewModeConstants.ResourceLeftTimeTop, ViewModeConstants.DayProviderLeftTimeTop
					retval = Me.StartTime.AddMinutes(Me.HScroll1.Value * Me.TimeIncrementValue).ToShortTimeString()

					'DayRoom Top
				Case ViewModeConstants.DayRoomTopTimeLeft

					'Room Top
				Case ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.DayTimeLeftRoomTop
					Dim ii As Integer = Me.HScroll1.Value
					If ii < Me.RoomCollection.Count Then
						retval = CType(Me.RoomCollection.VisibleList(ii), Room).Text
					End If

					'Provider Top
				Case ViewModeConstants.DayLeftProviderTop, ViewModeConstants.RoomLeftProviderTop, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.DayTimeLeftProviderTop
					Dim ii As Integer = Me.HScroll1.Value
					If ii < Me.ProviderCollection.Count Then
						retval = CType(Me.ProviderCollection.VisibleList(ii), Provider).Text
					End If

				Case ViewModeConstants.Month
				Case ViewModeConstants.Week
				Case ViewModeConstants.MonthFull
					'Do Nothing

					'Resource Top
				Case ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.DayLeftResourceTop
					Dim ii As Integer = Me.HScroll1.Value
					If ii < Me.ResourceCollection.Count Then
						retval = CType(Me.ResourceCollection.VisibleList(ii), Resource).Text
					End If

					'DayProvider Top
				Case ViewModeConstants.DayProviderTopTimeLeft
					Dim providerindex As Integer = Me.Visibility.GetProviderFromRowCol(Me.HScroll1.Value)
					Dim newDate As Date = Me.Visibility.GetDateFromRowCol(Me.HScroll1.Value)
					retval = newDate.ToShortDateString
					If providerindex <> -1 Then
						retval &= " " & Me.ProviderCollection(providerindex).Text
					End If

			End Select
			Return retval

		End Function

		Private Function GetVerticalScrollText() As String

			Dim retval As String = ""
			Select Case Me.ViewMode
				'Time Left
				Case ViewModeConstants.DayTopTimeLeft, ViewModeConstants.DayRoomTopTimeLeft, ViewModeConstants.RoomTopTimeLeft, ViewModeConstants.ProviderTopTimeLeft, ViewModeConstants.ResourceTopTimeLeft, ViewModeConstants.DayProviderTopTimeLeft
					retval = Me.StartTime.AddMinutes(Me.VScroll1.Value * Me.TimeIncrementValue).ToShortTimeString()

					'Room Left
				Case ViewModeConstants.DayTopRoomLeft, ViewModeConstants.RoomLeftTimeTop, ViewModeConstants.RoomLeftProviderTop
					Dim ii As Integer = Me.VScroll1.Value
					If (ii < Me.RoomCollection.VisibleList.Count) Then
						retval = CType(Me.RoomCollection.VisibleList(ii), Room).Text
					End If

					'Provider Left
				Case ViewModeConstants.DayTopProviderLeft, ViewModeConstants.RoomTopProviderLeft, ViewModeConstants.ProviderLeftTimeTop
					Dim ii As Integer = Me.VScroll1.Value
					If (ii < Me.ProviderCollection.VisibleList.Count) Then
						retval = CType(Me.ProviderCollection.VisibleList(ii), Provider).Text
					End If

					'Day Left
				Case ViewModeConstants.DayLeftResourceTop, ViewModeConstants.DayLeftTimeTop, ViewModeConstants.DayLeftRoomTop, ViewModeConstants.DayLeftProviderTop
					retval = Me.MinDate.AddDays(Me.VScroll1.Value).ToShortDateString()

					'Resource Left
				Case ViewModeConstants.ResourceLeftTimeTop
					Dim ii As Integer = Me.VScroll1.Value
					If (ii < Me.ResourceCollection.VisibleList.Count) Then
						retval = CType(Me.ResourceCollection.VisibleList(ii), Resource).Text
					End If

					'DayRoom Left
				Case ViewModeConstants.DayRoomLeftTimeTop
					Dim roomindex As Integer = Me.Visibility.GetRoomFromRowCol(Me.VScroll1.Value)
					Dim newDate As Date = Me.Visibility.GetDateFromRowCol(Me.VScroll1.Value)
					retval = newDate.ToShortDateString
					If roomindex <> -1 Then
						retval &= " " & Me.RoomCollection(roomindex).Text
					End If

					'DayTime Left
				Case ViewModeConstants.DayTimeLeftProviderTop, ViewModeConstants.DayTimeLeftRoomTop
					Dim newDate As Date = Me.Visibility.GetDateFromRowCol(Me.VScroll1.Value)
					Dim newTime As Date = Me.Visibility.GetTimeFromRowCol(Me.VScroll1.Value)
					retval = newDate.ToShortDateString & " " & newTime.ToShortTimeString

				Case ViewModeConstants.Month, ViewModeConstants.Week, ViewModeConstants.MonthFull
					'Do Nothing

					'DayProvider Left
				Case ViewModeConstants.DayProviderLeftTimeTop
					Dim providerindex As Integer = Me.Visibility.GetProviderFromRowCol(Me.VScroll1.Value)
					Dim newDate As Date = Me.Visibility.GetDateFromRowCol(Me.VScroll1.Value)
					retval = newDate.ToShortDateString
					If providerindex <> -1 Then
						retval &= " " & Me.ProviderCollection(providerindex).Text
					End If

			End Select
			Return retval

		End Function

#End Region

#Region "On... Event Methods"

		Protected Overridable Sub OnBackgroundClick(ByVal e As System.Windows.Forms.MouseEventArgs)
			Try
				RaiseEvent BackgroundClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBackgroundDoubleClick(ByVal e As System.Windows.Forms.MouseEventArgs)
			Try
				RaiseEvent BackgroundDoubleClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeToolTip(ByVal e As ToolTipAppointmentEventArgs)
			Try
				RaiseEvent BeforeToolTip(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Friend Overridable Sub OnBeforeDragTip(ByVal e As BeforeDragTipEventArgs)
			Try
				RaiseEvent BeforeDragTip(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Friend Overridable Sub OnBeforeResizeTip(ByVal e As BeforeDragTipEventArgs)
			Try
				RaiseEvent BeforeResizeTip(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Friend Overridable Sub OnBeforeAlarmDrawText(ByVal e As Objects.EventArgs.BeforeAppointmentTextEventArgs)
			Try
				RaiseEvent BeforeAlarmDrawText(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnUserDrawnAppointmentBar(ByVal e As AppointmentUserDrawEventArgs)
			Try
				RaiseEvent UserDrawnAppointmentBar(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnUserDrawnAppointmentHeader(ByVal e As AppointmentUserDrawEventArgs)
			Try
				RaiseEvent UserDrawnAppointmentHeader(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnUserDrawnTimeBar(ByVal e As AppointmentUserDrawEventArgs)
			Try
				RaiseEvent UserDrawnTimeBar(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeUserAppointmentAdd(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeUserAppointmentAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterUserAppointmentAdd(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterUserAppointmentAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeUserAppointmentRemove(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeUserAppointmentRemove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterUserAppointmentRemove(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterUserAppointmentRemove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentAdd(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeAppointmentAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppointmentAdd(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterAppointmentAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforePropertyDialog(ByVal e As BeforePropertyDialogEventArgs)
			Try
				RaiseEvent BeforePropertyDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterPropertyDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterPropertyDialog(Me, e)
				Me.Dialogs.RefreshAlarm(CType(e.BaseObject, Appointment))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterCancelPropertyDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterCancelPropertyDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterSavePropertyDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterSavePropertyDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentRemove(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeAppointmentRemove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppointmentRemove(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterAppointmentRemove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentCopy(ByVal e As BeforeAppointmentActionEventArgs)
			Try
				RaiseEvent BeforeAppointmentCopy(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppointmentCopy(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterAppointmentCopy(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentMove(ByVal e As BeforeAppointmentActionEventArgs)
			Try
				RaiseEvent BeforeAppointmentMove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppointmentMove(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterAppointmentMove(Me, e)
				Me.Dialogs.RefreshAlarm(CType(e.BaseObject, Appointment))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeForeignAdd(ByVal e As BeforeAppointmentForeignEventArgs)
			Try
				RaiseEvent BeforeForeignAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterForeignAdd(ByVal e As AfterAppointmentForeignEventArgs)
			Try
				RaiseEvent AfterForeignAdd(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnViewModeChange(ByVal e As System.EventArgs)
			Try
				RaiseEvent ViewModeChange(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnValidateAppointmentRemove(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent ValidateAppointmentRemove(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeColumnResize(ByVal e As BeforeRowColResizeEventArgs)
			Try
				RaiseEvent BeforeColumnResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterColumnResize(ByVal e As AfterRowColResizeEventArgs)
			Try
				RaiseEvent AfterColumnResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeRowResize(ByVal e As BeforeRowColResizeEventArgs)
			Try
				RaiseEvent BeforeRowResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterRowResize(ByVal e As AfterRowColResizeEventArgs)
			Try
				RaiseEvent AfterRowResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeSelectedItemChange(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeSelectedItemChange(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterSelectedItemChange(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterSelectedItemChange(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeRoomHeaderDraw(ByVal e As BeforeRoomHeaderEventArgs)
			Try
				RaiseEvent BeforeRoomHeaderDraw(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeResourceHeaderDraw(ByVal e As BeforeResourceHeaderEventArgs)
			Try
				RaiseEvent BeforeResourceHeaderDraw(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeProviderHeaderDraw(ByVal e As BeforeProviderHeaderEventArgs)
			Try
				RaiseEvent BeforeProviderHeaderDraw(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeDateHeaderDraw(ByVal e As BeforeHeaderEventArgs)
			Try
				RaiseEvent BeforeDateHeaderDraw(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentReminder(ByVal e As BeforeAlarmEventArgs)
			Try
				RaiseEvent BeforeAppointmentReminder(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentDue(ByVal e As BeforeAlarmEventArgs)
			Try
				RaiseEvent BeforeAppointmentDue(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAppointmentClick(ByVal e As AppointmentMouseEventArgs)
			Try
				RaiseEvent AppointmentClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAppointmentDoubleClick(ByVal e As AppointmentMouseEventArgs)
			Try
				RaiseEvent AppointmentDoubleClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAppointmentHeaderClick(ByVal e As AppointmentMouseEventArgs)
			Try
				RaiseEvent AppointmentHeaderClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAppointmentHeaderDoubleClick(ByVal e As AppointmentMouseEventArgs)
			Try
				RaiseEvent AppointmentHeaderDoubleClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnNoDropAreaClick(ByVal e As ScheduleAreaMouseEventArgs)
			Try
				RaiseEvent NoDropAreaClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnColoredAreaClick(ByVal e As ScheduleAreaMouseEventArgs)
			Try
				RaiseEvent ColoredAreaClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppointmentTextDraw(ByVal e As BeforeAppointmentTextEventArgs)
			Try
				RaiseEvent BeforeAppointmentTextDraw(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeInPlaceEdit(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent BeforeInPlaceEdit(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterInPlaceEdit(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterInPlaceEdit(Me, e)
				Me.Dialogs.RefreshAlarm(CType(e.BaseObject, Appointment))
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Friend Overridable Sub OnBeforeAppointmentResize(ByVal e As AppointmentSizeEventsArgs)
			Try
				RaiseEvent BeforeAppointmentResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Friend Overridable Sub OnWhileAppointmentResize(ByVal e As AppointmentSizeEventsArgs)
			Try
				RaiseEvent WhileAppointmentResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppointmentResize(ByVal e As BeforeBaseObjectEventArgs)
			Try
				RaiseEvent AfterAppointmentResize(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeCategoryListDialog(ByVal e As BeforeCategoryListDialogEventArgs)
			Try
				RaiseEvent BeforeCategoryListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterCategoryListDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterCategoryListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeProviderListDialog(ByVal e As BeforeProviderListDialogEventArgs)
			Try
				RaiseEvent BeforeProviderListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterProviderListDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterProviderListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeProviderConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforeProviderConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterProviderConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterProviderConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeResourceListDialog(ByVal e As BeforeResourceListDialogEventArgs)
			Try
				RaiseEvent BeforeResourceListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterResourceListDialog(ByVal e As AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterResourceListDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeResourceConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforeResourceConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterResourceConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterResourceConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeCategoryConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforeCategoryConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterCategoryConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterCategoryConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeRoomConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforeRoomConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforeAppearanceConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforeAppearanceConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterRoomConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterRoomConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterAppearanceConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterAppearanceConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforePropertyItemConfigurationDialog(ByVal e As BeforeConfigurationDialogEventArgs)
			Try
				RaiseEvent BeforePropertyItemConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAfterPropertyItemConfigurationDialog(ByVal e As System.EventArgs)
			Try
				RaiseEvent AfterPropertyItemConfigurationDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPrintSetup(ByVal e As PrintSetupEventArgs)
			Try
				RaiseEvent PrintSetup(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforePrintHeader(ByVal e As BeforePrintSectionEventArgs)
			Try
				RaiseEvent BeforePrintHeader(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforePrintFooter(ByVal e As BeforePrintSectionEventArgs)
			Try
				RaiseEvent BeforePrintFooter(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnBeforePrintPageNumber(ByVal e As BeforePrintSectionEventArgs)
			Try
				RaiseEvent BeforePrintPageNumber(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPrintProgress(ByVal e As PrintEventArgs)
			Try
				RaiseEvent PrintProgress(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPrintCanceled(ByVal e As System.EventArgs)
			Try
				RaiseEvent PrintCanceled(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPropertyDialogSaveInvalidArea(ByVal e As TextExtendedEventArgs)
			Try
				RaiseEvent PropertyDialogSaveInvalidArea(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPropertyDialogRemoveFiles(ByVal e As TextExtendedEventArgs)
			Try
				RaiseEvent PropertyDialogRemoveFiles(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnPropertyDialogSaveValueOutOfRange(ByVal e As TextExtendedEventArgs)
			Try
				RaiseEvent PropertyDialogSaveValueOutOfRange(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnDateRangeChange(ByVal e As DateRangeEventArgs)
			Try
				RaiseEvent DateRangeChange(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnAppointmentHeaderInfoClick(ByVal e As AppointmentMouseEventArgs)
			Try
				RaiseEvent AppointmentHeaderInfoClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnColumnHeaderClick(ByVal e As AfterHeaderEventArgs)
			Try
				RaiseEvent ColumnHeaderClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnColumnHeaderDoubleClick(ByVal e As AfterHeaderEventArgs)
			Try
				RaiseEvent ColumnHeaderDoubleClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnRowHeaderClick(ByVal e As AfterHeaderEventArgs)
			Try
				RaiseEvent RowHeaderClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnRowHeaderDoubleClick(ByVal e As AfterHeaderEventArgs)
			Try
				RaiseEvent RowHeaderDoubleClick(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Overloads Sub OnDragOver(ByVal e As DragAppointmentEventArgs)
			Try
				RaiseEvent DragOver(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Overloads Sub OnDragDrop(ByVal e As DragAppointmentEventArgs)
			Try
				RaiseEvent DragDrop(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Overloads Sub OnMouseEnter(ByVal e As System.EventArgs)
			Try
				RaiseEvent MouseEnter(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Overloads Sub OnMouseLeave(ByVal e As System.EventArgs)
			Try
				RaiseEvent MouseLeave(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnHorizontalScroll(ByVal e As System.EventArgs)
			Try
				RaiseEvent HorizontalScroll(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnVerticalScroll(ByVal e As System.EventArgs)
			Try
				RaiseEvent VerticalScroll(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Friend Overridable Sub OnRefresh()
			Try
				Me.DrawingDirty = True
				Me.Refresh()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overridable Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
			Try
				OnRefresh()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub OnRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			Try
				Me.DrawingDirty = True
				If Me.AutoRedraw Then OnRefresh()
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Overrides Sub OnDoubleClick(ByVal e As System.EventArgs)

			editBoxFromMouseDown = Rectangle.Empty
			dragBoxFromMouseDown = Rectangle.Empty
			TimerDrag.Enabled = False
			TimerEdit.Enabled = False

			Try
				'If the month scroll buttons were clicked then do nothing
				If (Me.ViewMode = ViewModeConstants.Month) OrElse (Me.ViewMode = ViewModeConstants.MonthFull) Then
					If (Not (Me.DayCellArray.HitTestDownButton(MoveX, MoveY) Is Nothing)) OrElse (Not (Me.DayCellArray.HitTestUpButton(MoveX, MoveY) Is Nothing)) Then
						Return
					End If
				End If

				Dim appointment As Appointment = Me.AppointmentCollection.HitTest(MoveX, MoveY)

				If (appointment Is Nothing) Then
					If LastMouseObject.Button = System.Windows.Forms.MouseButtons.Left Then

						'Make sure that click was not on headers 
						If Not ((MoveX < Me.ClientLeft) OrElse (Me.ClientLeft + Me.ClientWidth < MoveX) OrElse (MoveY < Me.ClientTop - Me.EventHeaderHeight) OrElse (Me.ClientTop - Me.EventHeaderHeight + Me.ClientHeight < MoveY)) Then
							'Raise the background click event
							Dim eventParam1 As New MouseEventArgs(LastMouseObject.Button, LastMouseObject.Clicks, MoveX, MoveY, LastMouseObject.Delta)
							OnBackgroundDoubleClick(eventParam1)
							If Me.AllowAdd Then Call CreateDefaultAppointment(MoveX, MoveY)
							Return
						End If

						'**************************************************
						'Determine if a header was clicked
						Dim headerIndex As Integer = Me.ColumnHeader.HitTest(MoveX, MoveY)
						If headerIndex <> -1 Then
							If Not Me.OverColumnBreak(MoveX, MoveY) Then
								OnColumnHeaderDoubleClick(New Gravitybox.Objects.EventArgs.AfterHeaderEventArgs(headerIndex))
							End If
						End If
						headerIndex = Me.RowHeader.HitTest(MoveX, MoveY)
						If headerIndex <> -1 Then
							If Not Me.OverRowBreak(MoveX, MoveY) Then
								OnRowHeaderDoubleClick(New Gravitybox.Objects.EventArgs.AfterHeaderEventArgs(headerIndex))
							End If
						End If

					End If

				ElseIf Not (appointment Is Nothing) AndAlso (Not appointment.Blockout) Then
					Dim eventParam As New AppointmentMouseEventArgs(appointment, LastMouseObject.Button, LastMouseObject.Clicks, LastMouseObject.X, LastMouseObject.Y, LastMouseObject.Delta)
					'If there is a header then check for it
					If (appointment.Header.HeaderType <> AppointmentHeader.HeaderTypeConstants.None) AndAlso appointment.Header.ClientRectangle.Contains(LastMouseObject.X, LastMouseObject.Y) Then
						OnAppointmentHeaderDoubleClick(eventParam)
					Else
						OnAppointmentDoubleClick(eventParam)
					End If

					'If left button and not readonly...
					If (LastMouseObject.Button = System.Windows.Forms.MouseButtons.Left) AndAlso (Not appointment.IsReadOnly) Then
						Call Dialogs.ShowPropertyDialog(appointment, False)
					End If

				End If

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		'Paint the canvas
		<MethodImpl(MethodImplOptions.Synchronized)> _
		Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

			'If can not lock this object then exit
			'If Not Monitor.TryEnter(Me) Then Return
			'If Not Monitor.TryEnter(e.Graphics) Then Return

			Dim startTime As Date = Now
			Try
				'Call Canvas.InternalRefresh(OffScreenGraphics)
				'Call Canvas.DrawXORRectangle(OffScreenGraphics, AppointmentOutline.DragRectArray, 3)
				e.Graphics.DrawImage(OffScreenImage, 0, 0)
				RaiseEvent Paint(Me, e)

				Dim endTime As Date = Now
				Debug.WriteLine("OnPaint " & endTime.Subtract(startTime).TotalMilliseconds)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'Unlock Objects
				'Monitor.Exit(e.Graphics)
				'Monitor.Exit(Me)
			End Try

		End Sub

		'Resize the canvas and repaint
		Protected Overrides Sub OnResize(ByVal e As System.EventArgs)

			Const ScrollSize As Integer = 16
			Static inHere As Boolean = False

			If inHere Then Return
			inHere = True

			Try
				'Move/Size the scroll bars
				Select Case Me.ScrollBars
					Case ScrollBars.Both
						VScroll1.Size = New Size(ScrollSize, Me.Height - ScrollSize)
						HScroll1.Size = New Size(Me.Width - ScrollSize, ScrollSize)
					Case ScrollBars.Horizontal
						HScroll1.Size = New Size(Me.Width, ScrollSize)
					Case ScrollBars.None
						'Do Nothing
					Case ScrollBars.Vertical
						VScroll1.Size = New Size(ScrollSize, Me.Height)
				End Select
				VScroll1.Location = New Point(Me.Width - VScroll1.Width, 0)
				HScroll1.Location = New Point(0, Me.Height - ScrollSize)
				Me.DrawingDirty = True
				Call SetDimensions()
				OnRefresh()
				RaiseEvent Resize(Me, e)

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				'Do Nothing
			Finally
				inHere = False
			End Try

		End Sub

		Protected Sub OnBeforeRecurrenceDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeRecurrenceDialogEventArgs)
			Try
				RaiseEvent BeforeRecurrenceDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Sub OnAfterRecurrenceDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Try
				RaiseEvent AfterRecurrenceDialog(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Sub OnAppointmentDismissed(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Try
				RaiseEvent AppointmentDismissed(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

		Protected Sub OnAppointmentSnooze(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Try
				RaiseEvent AppointmentSnooze(Me, e)
			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "CallBackHeaderRefresh"

		Private Sub CallBackHeaderRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
			OnRefresh()
		End Sub

#End Region

#Region "Callbacks"

		Private Sub SelectedItemsClearComplete()
			Me.SelectedItem = Nothing
		End Sub

		Private Sub AppointmentRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Me.SelectedItems.Remove(e.BaseObject)
		End Sub

#End Region

#Region "RefreshLocking"

		''' <summary>
		''' This method turns off screen and returns a lock key. The key is returned in another method call to toggle painting back on.
		''' </summary>
		''' <remarks>This is used to improve performance when executing many actions at one time.</remarks>
		Public Function PrepareForProcessing() As String

			Dim key As String = Guid.NewGuid.ToString
			LockKeys.Add(key)
			SafeRedraw = False
			Return key

		End Function

		''' <summary>
		''' This method toggles screen painting back on when all lock keys have been returned.
		''' </summary>
		''' <param name="key">This is the lock key that was returned from a previous call.</param>
		''' <remarks>This is used to improve performance when executing many actions at one time.</remarks>
		Public Sub PrepareForProcessing(ByVal key As String)

			If LockKeys.Contains(key) Then
				LockKeys.Remove(key)
			Else
				Debug.WriteLine("No key found!")
			End If

			If LockKeys.Count = 0 Then
				SafeRedraw = True
				OnRefresh()
			End If

		End Sub

#End Region

	End Class

End Namespace