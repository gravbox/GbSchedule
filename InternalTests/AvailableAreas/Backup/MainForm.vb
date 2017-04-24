Public Class MainForm
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
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents cmdViewMode As System.Windows.Forms.Button
  Friend WithEvents cmdNextAvailable As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cmdNextAvailable = New System.Windows.Forms.Button
    Me.cmdViewMode = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdNextAvailable, Me.cmdViewMode})
    Me.Panel1.Location = New System.Drawing.Point(0, 360)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(536, 32)
    Me.Panel1.TabIndex = 0
    '
    'cmdNextAvailable
    '
    Me.cmdNextAvailable.Location = New System.Drawing.Point(96, 0)
    Me.cmdNextAvailable.Name = "cmdNextAvailable"
    Me.cmdNextAvailable.Size = New System.Drawing.Size(88, 24)
    Me.cmdNextAvailable.TabIndex = 1
    Me.cmdNextAvailable.Text = "Next Available"
    '
    'cmdViewMode
    '
    Me.cmdViewMode.Name = "cmdViewMode"
    Me.cmdViewMode.Size = New System.Drawing.Size(88, 24)
    Me.cmdViewMode.TabIndex = 0
    Me.cmdViewMode.Text = "ViewMode"
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowEvents = True
    Me.Schedule1.AllowGrid = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
    Me.Schedule1.DayLength = 12
    Me.Schedule1.EventHeaderColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
    Me.Schedule1.GridBackColor = System.Drawing.Color.White
    Me.Schedule1.GridForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(536, 352)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 1
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(536, 389)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1, Me.Panel1})
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Available Areas"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "ViewMode"

  Private Sub cmdViewMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewMode.Click

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        Call LoadDateRoom()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        Call LoadDateProvider()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        Call LoadDateTime()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call LoadDateRoom()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call LoadDateProvider()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Call LoadDateRoomTime()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        Call LoadDateRoomTime()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        Call LoadRoomTime()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Call LoadRoomTime()

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month

      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Call LoadDateTime()

    End Select

  End Sub

#End Region

  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Schedule1.RoomCollection.Clear()
    Call Schedule1.RoomCollection.Add("", "Room1")
    Call Schedule1.RoomCollection.Add("", "Room2")

    Call Schedule1.ProviderCollection.Clear()
    Call Schedule1.ProviderCollection.Add("", "Provider1")
    Call Schedule1.ProviderCollection.Add("", "Provider2")

    Call Schedule1.SetMinMaxDate(#1/1/2003#, #1/5/2003#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Call Schedule1.Visibility.ShowTime(#8:00:00 AM#)
    Call Schedule1.Visibility.ShowDate(#1/1/2003#)

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month
    Call LoadDateTime()

    'Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
    'Call LoadDateRoomTime()

    Call SetupNoDrop()

  End Sub

  Private Sub SetupNoDrop()

    Call Schedule1.NoDropAreaCollection.Clear()
    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.RoomCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.RoomCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #1/2/2003#)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.ProviderCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.RoomCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.RoomCollection(1))
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.ProviderCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.ProviderCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        Schedule1.NoDropAreaCollection.Add(Color.Red, #12:00:00 PM#, 60)
        Schedule1.NoDropAreaCollection.Add(Color.Red, Schedule1.ProviderCollection(1))
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
    End Select
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadDateTime()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    Call Schedule1.AppointmentCollection.Add("", #1/1/2003#, #8:00:00 AM#, 60) 'Normal
    Call Schedule1.AppointmentCollection.Add("", #1/1/2003#, #10:00:00 AM#, 60) 'Normal
    'Call Schedule1.AppointmentCollection.Add("", #1/1/2003#, #5:00:00 PM#, 60 * 16) 'Activity
    'appointment = Schedule1.AppointmentCollection.Add("", #1/1/2003#, #9:00:00 AM#, 30) 'Event
    'appointment.IsEvent = True
    'appointment.Subject = "This is a multiline test for all to see!" & vbCrLf & "This is line 2!"
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadDateRoom()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2003#, Schedule1.RoomCollection(0))  'Normal
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadDateRoomTime()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2003#, Schedule1.RoomCollection(0), #8:00:00 AM#, 60) 'Normal
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadRoomTime()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2003#, Schedule1.RoomCollection(0))  'Normal
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadDateProvider()

    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2003#, Nothing)  'Normal
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdNextAvailable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextAvailable.Click

    Dim appointment As Gravitybox.Objects.Appointment
    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        appointment = Schedule1.Availability.NextAreaAvailable(#1/1/2003#, #8:00:00 AM#, 60)
        Call MsgBox(appointment.ToString, MsgBoxStyle.Information)

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        appointment = Schedule1.Availability.NextAreaAvailable(#1/1/2003#, Schedule1.RoomCollection(0))
        Call MsgBox(appointment.ToString, MsgBoxStyle.Information)

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        appointment = Schedule1.Availability.NextAreaAvailable(#1/1/2003#, Schedule1.ProviderCollection(0))
        Call MsgBox(appointment.ToString, MsgBoxStyle.Information)

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        appointment = Schedule1.Availability.NextAreaAvailable(#1/1/2003#, Schedule1.RoomCollection(0), #8:00:00 AM#, 60)
        Call MsgBox(appointment.ToString, MsgBoxStyle.Information)

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
    End Select

  End Sub


  Private Sub Schedule1_BeforeMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentConflictEventArgs) Handles Schedule1.BeforeAppointmentMove

    If e.IsConflict Then
      Call MsgBox("Conflict", MsgBoxStyle.Information)
    End If

  End Sub

  Private Sub Schedule1_BeforeCopy(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentConflictEventArgs) Handles Schedule1.BeforeAppointmentCopy

    If e.IsConflict Then
      Call MsgBox("Conflict", MsgBoxStyle.Information)
    End If

  End Sub

  Private Sub Schedule1_ViewModeChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.ViewModeChange
    Call SetupNoDrop()
  End Sub

End Class
