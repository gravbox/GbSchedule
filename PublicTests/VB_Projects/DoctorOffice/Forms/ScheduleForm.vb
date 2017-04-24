Option Strict On
Option Explicit On 

Imports System.IO
Imports DoctorOfficeAPI.Objects
Imports Gravitybox.Objects

Public Class ScheduleForm
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents tabDay As System.Windows.Forms.TabPage
  Friend WithEvents tabWeek As System.Windows.Forms.TabPage
  Friend WithEvents tabWorkWeek As System.Windows.Forms.TabPage
  Friend WithEvents tabMonth As System.Windows.Forms.TabPage
  Friend WithEvents calSetting As System.Windows.Forms.MonthCalendar
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.tabDay = New System.Windows.Forms.TabPage
    Me.tabWorkWeek = New System.Windows.Forms.TabPage
    Me.tabWeek = New System.Windows.Forms.TabPage
    Me.tabMonth = New System.Windows.Forms.TabPage
    Me.calSetting = New System.Windows.Forms.MonthCalendar
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.TabControl1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.tabDay)
    Me.TabControl1.Controls.Add(Me.tabWorkWeek)
    Me.TabControl1.Controls.Add(Me.tabWeek)
    Me.TabControl1.Controls.Add(Me.tabMonth)
    Me.TabControl1.Location = New System.Drawing.Point(32, 24)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(352, 56)
    Me.TabControl1.TabIndex = 1
    '
    'tabDay
    '
    Me.tabDay.Location = New System.Drawing.Point(4, 22)
    Me.tabDay.Name = "tabDay"
    Me.tabDay.Size = New System.Drawing.Size(344, 30)
    Me.tabDay.TabIndex = 0
    Me.tabDay.Text = "Day"
    '
    'tabWorkWeek
    '
    Me.tabWorkWeek.Location = New System.Drawing.Point(4, 22)
    Me.tabWorkWeek.Name = "tabWorkWeek"
    Me.tabWorkWeek.Size = New System.Drawing.Size(344, 30)
    Me.tabWorkWeek.TabIndex = 2
    Me.tabWorkWeek.Text = "WorkWeek"
    '
    'tabWeek
    '
    Me.tabWeek.Location = New System.Drawing.Point(4, 22)
    Me.tabWeek.Name = "tabWeek"
    Me.tabWeek.Size = New System.Drawing.Size(344, 30)
    Me.tabWeek.TabIndex = 1
    Me.tabWeek.Text = "Week"
    '
    'tabMonth
    '
    Me.tabMonth.Location = New System.Drawing.Point(4, 22)
    Me.tabMonth.Name = "tabMonth"
    Me.tabMonth.Size = New System.Drawing.Size(344, 30)
    Me.tabMonth.TabIndex = 3
    Me.tabMonth.Text = "Month"
    '
    'calSetting
    '
    Me.calSetting.CalendarDimensions = New System.Drawing.Size(1, 2)
    Me.calSetting.Location = New System.Drawing.Point(424, 8)
    Me.calSetting.Name = "calSetting"
    Me.calSetting.TabIndex = 2
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DayLength = 16
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Location = New System.Drawing.Point(233, 107)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Column = 0
    Me.Schedule1.Selector.Length = 1
    Me.Schedule1.Selector.Row = 0
    Me.Schedule1.Size = New System.Drawing.Size(168, 120)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 3
    '
    'ScheduleForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(634, 335)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.calSetting)
    Me.Controls.Add(Me.TabControl1)
    Me.Name = "ScheduleForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "<Schedule>"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.TabControl1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_ScheduleDate As Date = Globals.DefaultNoDate
  Public PatientCollection As PatientCollection
  Private RowSize As Integer = 30
  Public ADACodeCollection As ADACodeCollection

  Public Property ScheduleDate() As Date
    Get
      Return m_ScheduleDate
    End Get
    Set(ByVal Value As Date)
      Try
        m_ScheduleDate = Value
        RefreshForm()
      Catch ex As Exception
        Call SetErr(ex)
      End Try
    End Set
  End Property

  Public Sub LoadForm()

    Try
      RowSize = Schedule1.RowHeader.Size
      Call Schedule1.CategoryCollection.LoadXML(GetPath() & "categories.xml")
      Call Schedule1.ProviderCollection.LoadXML(GetPath() & "providers.xml")
      Call Schedule1.RoomCollection.LoadXML(GetPath() & "rooms.xml")
      Call Schedule1.AppointmentCollection.LoadXML(GetPath() & "appointments.xml")
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Public Sub SaveForm()

    Try
      Call Schedule1.AppointmentCollection.SaveXML(GetPath() & "appointments.xml")
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub ScheduleForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try

      'Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
      Schedule1.ColumnHeader.AutoFit = True
      Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute10
      Schedule1.AppointmentTimeIncrement = Schedule1.TimeIncrement
      Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.All
      Schedule1.AllowInPlaceEdit = False
      Schedule1.EventHeader.AllowHeader = False

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub ScheduleForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    Call RefreshSize()
  End Sub

  Public Sub RefreshSize()

    Try
      'Move all controls
      TabControl1.SetBounds(0, 0, Me.ClientSize.Width - calSetting.Width, Me.ClientSize.Height)
      calSetting.Location = New System.Drawing.Point(Me.ClientSize.Width - calSetting.Width, 0)
      Schedule1.SetBounds(Me.TabControl1.DisplayRectangle.Left, Me.TabControl1.DisplayRectangle.Top, Me.TabControl1.DisplayRectangle.Width, Me.TabControl1.DisplayRectangle.Height)

      'Set different date header formats depending on how much room there is
      If Schedule1.ColumnHeader.Size > 85 Then
        Schedule1.HeaderDateFormat = "ddd MMM, dd"
      ElseIf Schedule1.ColumnHeader.Size > 55 Then
        Schedule1.HeaderDateFormat = "ddd dd"
      Else
        Schedule1.HeaderDateFormat = "MM/dd"
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub RefreshForm()

    Try

      'Bases on which tab was pressed display the schedule in different ways
      Schedule1.AutoRedraw = False
      If TabControl1.SelectedTab Is Me.tabDay Then
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Call Schedule1.SetMinMaxDate(Me.ScheduleDate, Me.ScheduleDate)
        Call calSetting.SetSelectionRange(Me.ScheduleDate, Me.ScheduleDate)
        Schedule1.RowHeader.Size = RowSize
      ElseIf TabControl1.SelectedTab Is Me.tabWorkWeek Then
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Dim dayIndex As Integer = Me.ScheduleDate.DayOfWeek
        Dim weekStart As Date = DateAdd(DateInterval.Day, -dayIndex + 1, Me.ScheduleDate)
        Dim weekEnd As Date = DateAdd(DateInterval.Day, 4, weekStart)
        Call Schedule1.SetMinMaxDate(weekStart, weekEnd)
        Call calSetting.SetSelectionRange(weekStart, weekEnd)
        Schedule1.RowHeader.Size = RowSize
      ElseIf TabControl1.SelectedTab Is Me.tabWeek Then
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Dim dayIndex As Integer = Me.ScheduleDate.DayOfWeek
        Dim weekStart As Date = DateAdd(DateInterval.Day, -dayIndex, Me.ScheduleDate)
        Dim weekEnd As Date = DateAdd(DateInterval.Day, 6, weekStart)
        Call Schedule1.SetMinMaxDate(weekStart, weekEnd)
        Call calSetting.SetSelectionRange(weekStart, weekEnd)
        Schedule1.RowHeader.Size = RowSize
      ElseIf TabControl1.SelectedTab Is Me.tabMonth Then
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call calSetting.SetSelectionRange(Me.ScheduleDate, Me.ScheduleDate)
        Dim monthStart As Date = DateSerial(Me.ScheduleDate.Year, Me.ScheduleDate.Month, 1)
        Dim monthEnd As Date = DateAdd(DateInterval.Month, 1, monthStart)
        monthEnd = DateAdd(DateInterval.Day, -1, monthEnd)
        Call Schedule1.SetMinMaxDate(monthStart, monthEnd)
      End If
      Schedule1.Selector.Length = 1
      Schedule1.AutoRedraw = True

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub ScheduleForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    Try
      Call SaveForm()
      CType(Me.ParentForm, MDIForm).ScheduleForm = Nothing
      Call CType(Me.ParentForm, MDIForm).UpdateToolbar()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub calSetting_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles calSetting.DateChanged
    ScheduleDate = e.Start
  End Sub

  Private Sub Schedule1_BeforePropertyDialog(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs)

    Try

      'Cancel the default dialog and display our custom one
      e.Cancel = True
      Dim F As New AppointmentPropertiesForm
			Call F.Initialize(PatientCollection, Schedule1.RoomCollection, Schedule1.CategoryCollection, Me.ADACodeCollection)

			Dim appointment As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
			F.Appointment = appointment
      If (F.ShowDialog() = DialogResult.OK) Then
				Dim patient As PatientItem = Me.PatientCollection(appointment.Text)
				appointment.Subject = patient.LName & ", " & patient.FName
      Else
        'If there is no subject then this is a newly added appointment
				If (appointment.Subject = "") Then
					Call Schedule1.AppointmentCollection.Remove(appointment)
					Call Schedule1.Refresh()
					Return
				End If
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub Schedule1_AfterRowResize(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterRowColResizeEventArgs)
    'This will keep track of the row size so that the 
    'month view will not through off the display
    RowSize = e.Size
  End Sub

  Public Sub ColorAppointment(ByVal appointment As Appointment)

    Try
      Dim element As Appointment
      For Each element In Me.Schedule1.AppointmentCollection
        element.Appearance.BackColor = Color.White
      Next

      'Color the appointment's background
      If Not (appointment Is Nothing) Then
        appointment.Appearance.BackColor = Color.LightGray
      End If
      Call Me.Schedule1.Refresh()

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub Schedule1_AfterForeignAdd(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentForeignEventArgs)

    'Determine if the drop was a Treenode and if so get a refernce to it
    Dim node As TreeNode = New TreeNode
    If Not e.Data.GetDataPresent(node.GetType()) Then
      Return
    End If
    node = CType(e.Data.GetData(node.GetType()), TreeNode)

    'Determine if the node was from the parent's treeview
    If Not CType(Me.MdiParent, MDIForm).tvwPatient.Nodes.Contains(node) Then
      Return
		End If

		Dim appointment As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)

		'This event is raised when a patient is dropped from the treeview
		Dim patientID As String = CStr(node.Tag)
		If patientID <> "" Then
			Dim patient As PatientItem = Me.PatientCollection(patientID)
			appointment.Subject = patient.LName & ", " & patient.FName
			appointment.Text = patientID

			'If there is no room specified then default to first
			If appointment.Room Is Nothing Then
				appointment.Room = Schedule1.RoomCollection(0)
			End If

			'If there is a category then default the appointment to the first one
			If Schedule1.CategoryCollection.Count > 0 Then
				appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
			End If

		End If

  End Sub

	Private Sub Schedule1_BeforeAppointmentRemove(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)

		'Prompt for removal only if the appointment has a subject
		'If not subject then this appointment has never really been added anyway
		'since the patient's name should be in here

		Dim appointment As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
		If appointment.Subject <> "" Then
			If MsgBox("Do you wish to remove the selected appointment?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Remove?") <> MsgBoxResult.Yes Then
				e.Cancel = True
			End If
		End If

	End Sub

	Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
		Call RefreshForm()
	End Sub

	Public Sub SetTabDisplay(ByVal display As DoctorOfficeAPI.Objects.ScheduleDisplayConstants)

		Select Case display
			Case ScheduleDisplayConstants.Day01
				TabControl1.SelectedTab = Me.tabDay
			Case ScheduleDisplayConstants.Day05
				TabControl1.SelectedTab = Me.tabWorkWeek
			Case ScheduleDisplayConstants.Day07
				TabControl1.SelectedTab = Me.tabWeek
			Case ScheduleDisplayConstants.Day31
				TabControl1.SelectedTab = Me.tabMonth
		End Select
		Call RefreshForm()

	End Sub

End Class
