Option Strict On
Option Explicit On 

Public Class Main
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
  Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuExit As System.Windows.Forms.MenuItem
  Friend WithEvents mnuSetup As System.Windows.Forms.MenuItem
  Friend WithEvents mnuSetupProvider As System.Windows.Forms.MenuItem
  Friend WithEvents mnuSetupCategory As System.Windows.Forms.MenuItem
  Friend WithEvents mnuSetupRoom As System.Windows.Forms.MenuItem
  Friend WithEvents mnuNewAppointment As System.Windows.Forms.MenuItem
  Friend WithEvents mnuApptDelete As System.Windows.Forms.MenuItem
  Friend WithEvents Header1 As Gravitybox.Controls.Header
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents mnuViewDay As System.Windows.Forms.MenuItem
  Friend WithEvents mnuViewWorkWeek As System.Windows.Forms.MenuItem
  Friend WithEvents mnuViewWeek As System.Windows.Forms.MenuItem
  Friend WithEvents mnuView As System.Windows.Forms.MenuItem
  Friend WithEvents mnuViewMonth As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
  Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
  Friend WithEvents mnuHelpAbout As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuApptOpen As System.Windows.Forms.MenuItem
  Friend WithEvents mnuApptCategory As System.Windows.Forms.MenuItem
  Friend WithEvents mnuApptProvider As System.Windows.Forms.MenuItem
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents AppointmentMenu As System.Windows.Forms.ContextMenu
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Main))
    Me.MenuItem5 = New System.Windows.Forms.MenuItem
    Me.mnuExit = New System.Windows.Forms.MenuItem
    Me.mnuSetup = New System.Windows.Forms.MenuItem
    Me.mnuSetupProvider = New System.Windows.Forms.MenuItem
    Me.mnuSetupCategory = New System.Windows.Forms.MenuItem
    Me.mnuSetupRoom = New System.Windows.Forms.MenuItem
    Me.mnuNewAppointment = New System.Windows.Forms.MenuItem
    Me.mnuApptDelete = New System.Windows.Forms.MenuItem
    Me.Header1 = New Gravitybox.Controls.Header
    Me.mnuFile = New System.Windows.Forms.MenuItem
    Me.mnuViewDay = New System.Windows.Forms.MenuItem
    Me.mnuViewWorkWeek = New System.Windows.Forms.MenuItem
    Me.mnuViewWeek = New System.Windows.Forms.MenuItem
    Me.mnuView = New System.Windows.Forms.MenuItem
    Me.mnuViewMonth = New System.Windows.Forms.MenuItem
    Me.MenuItem9 = New System.Windows.Forms.MenuItem
    Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
    Me.mnuHelpAbout = New System.Windows.Forms.MenuItem
    Me.MenuItem2 = New System.Windows.Forms.MenuItem
    Me.mnuHelp = New System.Windows.Forms.MenuItem
    Me.MenuItem1 = New System.Windows.Forms.MenuItem
    Me.MenuItem3 = New System.Windows.Forms.MenuItem
    Me.mnuApptOpen = New System.Windows.Forms.MenuItem
    Me.mnuApptCategory = New System.Windows.Forms.MenuItem
    Me.mnuApptProvider = New System.Windows.Forms.MenuItem
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.AppointmentMenu = New System.Windows.Forms.ContextMenu
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'MenuItem5
    '
    Me.MenuItem5.Index = 1
    Me.MenuItem5.Text = "-"
    '
    'mnuExit
    '
    Me.mnuExit.Index = 2
    Me.mnuExit.Text = "E&xit"
    '
    'mnuSetup
    '
    Me.mnuSetup.Index = 1
    Me.mnuSetup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSetupProvider, Me.mnuSetupCategory, Me.mnuSetupRoom})
    Me.mnuSetup.Text = "&Setup"
    '
    'mnuSetupProvider
    '
    Me.mnuSetupProvider.Index = 0
    Me.mnuSetupProvider.Text = "&Providers"
    '
    'mnuSetupCategory
    '
    Me.mnuSetupCategory.Index = 1
    Me.mnuSetupCategory.Text = "&Categories"
    '
    'mnuSetupRoom
    '
    Me.mnuSetupRoom.Index = 2
    Me.mnuSetupRoom.Text = "&Rooms"
    '
    'mnuNewAppointment
    '
    Me.mnuNewAppointment.Index = 0
    Me.mnuNewAppointment.Text = "&New Appointment"
    '
    'mnuApptDelete
    '
    Me.mnuApptDelete.Index = 4
    Me.mnuApptDelete.Text = "&Delete"
    '
    'Header1
    '
    Me.Header1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(203, Byte), CType(192, Byte), CType(199, Byte))
    Me.Header1.Appearance.BackColor2 = System.Drawing.Color.Gray
    Me.Header1.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
    Me.Header1.Appearance.BorderColor = System.Drawing.SystemColors.WindowFrame
    Me.Header1.Appearance.FontSize = 18.0!
    Me.Header1.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Header1.BackColor = System.Drawing.Color.FromArgb(CType(203, Byte), CType(192, Byte), CType(199, Byte))
    Me.Header1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Header1.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
    Me.Header1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Header1.Location = New System.Drawing.Point(0, 0)
    Me.Header1.Name = "Header1"
    Me.Header1.Size = New System.Drawing.Size(560, 32)
    Me.Header1.TabIndex = 5
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNewAppointment, Me.MenuItem5, Me.mnuExit})
    Me.mnuFile.Text = "&File"
    '
    'mnuViewDay
    '
    Me.mnuViewDay.Index = 0
    Me.mnuViewDay.Text = "&Day"
    '
    'mnuViewWorkWeek
    '
    Me.mnuViewWorkWeek.Index = 1
    Me.mnuViewWorkWeek.Text = "Wo&rk Week"
    '
    'mnuViewWeek
    '
    Me.mnuViewWeek.Index = 2
    Me.mnuViewWeek.Text = "&Week"
    '
    'mnuView
    '
    Me.mnuView.Index = 2
    Me.mnuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuViewDay, Me.mnuViewWorkWeek, Me.mnuViewWeek, Me.mnuViewMonth})
    Me.mnuView.Text = "&View"
    '
    'mnuViewMonth
    '
    Me.mnuViewMonth.Index = 3
    Me.mnuViewMonth.Text = "&Month"
    '
    'MenuItem9
    '
    Me.MenuItem9.Index = 3
    Me.MenuItem9.Text = "-"
    '
    'MonthCalendar1
    '
    Me.MonthCalendar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.MonthCalendar1.CalendarDimensions = New System.Drawing.Size(1, 2)
    Me.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Sunday
    Me.MonthCalendar1.Location = New System.Drawing.Point(368, 90)
    Me.MonthCalendar1.Name = "MonthCalendar1"
    Me.MonthCalendar1.ShowToday = False
    Me.MonthCalendar1.ShowTodayCircle = False
    Me.MonthCalendar1.TabIndex = 4
    '
    'mnuHelpAbout
    '
    Me.mnuHelpAbout.Index = 3
    Me.mnuHelpAbout.Text = "&About"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.Text = "&Search"
    '
    'mnuHelp
    '
    Me.mnuHelp.Index = 3
    Me.mnuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3, Me.mnuHelpAbout})
    Me.mnuHelp.Text = "&Help"
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.Text = "&Contents"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 2
    Me.MenuItem3.Text = "-"
    '
    'mnuApptOpen
    '
    Me.mnuApptOpen.Index = 0
    Me.mnuApptOpen.Text = "&Open"
    '
    'mnuApptCategory
    '
    Me.mnuApptCategory.Index = 1
    Me.mnuApptCategory.Text = "&Categories"
    '
    'mnuApptProvider
    '
    Me.mnuApptProvider.Index = 2
    Me.mnuApptProvider.Text = "&Providers"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile, Me.mnuSetup, Me.mnuView, Me.mnuHelp})
    '
    'AppointmentMenu
    '
    Me.AppointmentMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuApptOpen, Me.mnuApptCategory, Me.mnuApptProvider, Me.MenuItem9, Me.mnuApptDelete})
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DayLength = 16
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(64, 72)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(272, 200)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 6
    '
    'Main
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(560, 437)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Header1)
    Me.Controls.Add(Me.MonthCalendar1)
    Me.Menu = Me.MainMenu1
    Me.Name = "Main"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET Outlook Example"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Public Enum DisplayModeConstants
    Day = 1
    WorkWeek = 2
    Week = 3
    Month = 4
  End Enum

  Private m_DisplayMode As DisplayModeConstants

  Public Property DisplayMode() As DisplayModeConstants
    Get
      Return m_DisplayMode
    End Get
    Set(ByVal Value As DisplayModeConstants)
      m_DisplayMode = Value
      Call RefreshRange(MonthCalendar1.SelectionStart)
    End Set
  End Property

  Private Sub RefreshRange(ByVal selectedDate As Date)

    Try
      Dim startDate As Date
      Dim endDate As Date
      Static inHere As Boolean

      If inHere Then Return
      inHere = True

      Schedule1.AutoRedraw = False

      'Uncheck all menu items
      mnuViewDay.Checked = False
      mnuViewWorkWeek.Checked = False
      mnuViewWeek.Checked = False
      mnuViewMonth.Checked = False

      'Setup the display mode
      If Me.DisplayMode = DisplayModeConstants.Day Then
        Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
        mnuViewDay.Checked = True
        Schedule1.HeaderDateFormat = "dddd, MMMM dd"
        startDate = selectedDate
        endDate = selectedDate
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.RowHeader.Size = 25
      ElseIf Me.DisplayMode = DisplayModeConstants.WorkWeek Then
        Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
        mnuViewWorkWeek.Checked = True
        Schedule1.HeaderDateFormat = "ddd, MMM dd"
        startDate = DateAdd(DateInterval.Day, -selectedDate.DayOfWeek + 1, selectedDate)
        endDate = DateAdd(DateInterval.Day, 4, startDate)
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.RowHeader.Size = 25
      ElseIf Me.DisplayMode = DisplayModeConstants.Week Then
        Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
        mnuViewWeek.Checked = True
        Schedule1.HeaderDateFormat = "ddd, MMM dd"
        startDate = DateAdd(DateInterval.Day, -selectedDate.DayOfWeek, selectedDate)
        endDate = DateAdd(DateInterval.Day, 6, startDate)
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.RowHeader.Size = 25
      ElseIf Me.DisplayMode = DisplayModeConstants.Month Then
        Schedule1.Appearance.ForeColor = System.Drawing.Color.Black
        mnuViewMonth.Checked = True
        startDate = DateAdd(DateInterval.Day, -selectedDate.Day + 1, selectedDate)
        endDate = DateAdd(DateInterval.Month, 1, startDate)
        endDate = DateAdd(DateInterval.Day, -1, endDate)
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month
      End If

      If Me.DisplayMode = DisplayModeConstants.Month Then
        Call Me.MonthCalendar1.SetSelectionRange(selectedDate, selectedDate)
        Me.MonthCalendar1.SelectionRange.Start = selectedDate
        Me.MonthCalendar1.SelectionRange.End = selectedDate
        Call Schedule1.SetMinMaxDate(startDate, endDate)
      Else
        Call Me.MonthCalendar1.SetSelectionRange(startDate, endDate)
        Me.MonthCalendar1.SelectionRange.Start = startDate
        Me.MonthCalendar1.SelectionRange.End = endDate
        Call Schedule1.SetMinMaxDate(MonthCalendar1.SelectionStart, MonthCalendar1.SelectionEnd)
      End If

      Schedule1.AutoRedraw = True
      inHere = False

    Catch
      Throw
    End Try

  End Sub

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try
      Me.Header1.Text = "Outlook Example"
      MonthCalendar1.FirstDayOfWeek = Windows.Forms.Day.Sunday
      DisplayMode = DisplayModeConstants.Month
      Schedule1.ColumnHeader.AutoFit = True
      Call ResizeForm()

      'Refresh the scehdule display
      Call RefreshRange(MonthCalendar1.SelectionStart)

      Call LoadTestAppointments()

    Catch
      Throw
    End Try

  End Sub

  Private Sub LoadTestAppointments()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", Date.Today, #10:00:00 AM#, 60)
		appointment.Subject = "This is a test!"
		appointment.ToolTipText = appointment.Subject
    appointment.Appearance.BackColor = System.Drawing.Color.Yellow

    appointment = Schedule1.AppointmentCollection.Add("", Date.Today, #11:00:00 AM#, 60)
		appointment.Subject = "Just Another Test!"
		appointment.ToolTipText = appointment.Subject
    appointment.IsFlagged = True
    appointment.Appearance.BackColor = System.Drawing.Color.Aqua

    Call Schedule1.Refresh()

  End Sub

  Private Sub ResizeForm()

    Try
      Schedule1.Location = New System.Drawing.Point(0, Header1.Height)
      Schedule1.Size = New System.Drawing.Size(Me.ClientSize.Width - Me.MonthCalendar1.Width, Me.ClientSize.Height - Header1.Height)
      MonthCalendar1.Location = New System.Drawing.Point(Me.ClientSize.Width - MonthCalendar1.Width, Header1.Height)
      Call SetupDateFormat()
    Catch
      Throw
    End Try

  End Sub

  Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    Try
      Call RefreshRange(e.Start)
    Catch
      Throw
    End Try

  End Sub

#Region "View Menus"

  Private Sub mnuViewDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewDay.Click
    Me.DisplayMode = DisplayModeConstants.Day
  End Sub

  Private Sub mnuViewWorkWeek_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuViewWorkWeek.Click
    Me.DisplayMode = DisplayModeConstants.WorkWeek
  End Sub

  Private Sub mnuViewWeek_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuViewWeek.Click
    Me.DisplayMode = DisplayModeConstants.Week
  End Sub

  Private Sub mnuViewMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuViewMonth.Click
    Me.DisplayMode = DisplayModeConstants.Month
  End Sub

#End Region

  Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    Call ResizeForm()
  End Sub

#Region "Setup Menus"

  Private Sub mnuSetupProvider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupProvider.Click
    Call Schedule1.Dialogs.ShowProviderConfiguration()
  End Sub

  Private Sub mnuSetupCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupCategory.Click
    Call Schedule1.Dialogs.ShowCategoryConfiguration()
  End Sub

  Private Sub mnuSetupRoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSetupRoom.Click
    Call Schedule1.Dialogs.ShowRoomConfiguration()
  End Sub

#End Region

  Private Sub mnuHelpAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click

    Try
      Dim F As AboutForm
      F = New AboutForm
      Call F.ShowDialog()
    Catch
      Throw
    End Try

  End Sub

  Private Sub mnuNewAppointment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNewAppointment.Click

    Try
      Dim newDate As Date = DateAdd(DateInterval.Day, Schedule1.Selector.Column, Schedule1.MinDate)
      If newDate < Schedule1.MinDate Then newDate = Schedule1.MinDate
      If newDate > Schedule1.MaxDate Then newDate = Schedule1.MaxDate
      Dim newTime As Date = DateAdd(DateInterval.Minute, Schedule1.Selector.Row * Schedule1.TimeIncrement, Schedule1.StartTime)
      Dim newLength As Integer = Schedule1.Selector.Length * Schedule1.TimeIncrement

      Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", newDate, newTime, newLength)
      Call Schedule1.Dialogs.ShowPropertyDialog(appointment)

    Catch
      Throw
    End Try

  End Sub

  Private Sub mnuApptDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuApptDelete.Click

    Try
      If Schedule1.SelectedItem Is Nothing Then Return
      If MsgBox("", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete?") <> MsgBoxResult.Yes Then Return
      Call Schedule1.AppointmentCollection.Remove(Schedule1.SelectedItem)
      Call Schedule1.Refresh()
    Catch
      Throw
    End Try

  End Sub

  Private Sub mnuApptProvider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuApptProvider.Click

    Try
      If Schedule1.SelectedItem Is Nothing Then Return
      Call Schedule1.Dialogs.ShowProviderDialog(Schedule1.SelectedItem)
    Catch
      Throw
    End Try

  End Sub

  Private Sub mnuApptCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuApptCategory.Click

    Try
      If Schedule1.SelectedItem Is Nothing Then Return
      Call Schedule1.Dialogs.ShowCategoryDialog(Schedule1.SelectedItem)
    Catch
      Throw
    End Try

  End Sub

  Private Sub mnuApptOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuApptOpen.Click

    Try
      If Schedule1.SelectedItem Is Nothing Then Return
      Call Schedule1.Dialogs.ShowPropertyDialog(Schedule1.SelectedItem)
    Catch
      Throw
    End Try

  End Sub


  Private Sub Schedule1_AppointmentClick(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs)

    Try
      If e.Button = Windows.Forms.MouseButtons.Right Then
        Me.AppointmentMenu.Show(Schedule1, New System.Drawing.Point(e.X, e.Y))
      End If
    Catch
      Throw
    End Try

  End Sub

  Private Sub Schedule1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Call SetupDateFormat()
  End Sub

  Private Sub SetupDateFormat()

    'When not in month mode this will format the date headers to match the width of the columns
    If Schedule1.ViewMode <> Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
      If Schedule1.ColumnHeader.Size < 60 Then
        Schedule1.HeaderDateFormat = "M/d"
      ElseIf Schedule1.ColumnHeader.Size < 90 Then
        Schedule1.HeaderDateFormat = "ddd dd"
      Else
        Schedule1.HeaderDateFormat = "ddd, MMM dd"
      End If
    End If

  End Sub

  Private Sub MainForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
    'Click the form to reload the default appointments for testing
    Call LoadTestAppointments()
  End Sub

  Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click
    Me.Close()
  End Sub

End Class
