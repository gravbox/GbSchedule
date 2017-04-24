Option Strict On
Option Explicit On 

Imports Gravitybox.Objects

Public Class TestForm1
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
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents cmdTest1 As System.Windows.Forms.Button
  Friend WithEvents cmdTest2 As System.Windows.Forms.Button
  Friend WithEvents cmdTest4 As System.Windows.Forms.Button
  Friend WithEvents cmdTest3 As System.Windows.Forms.Button
  Friend WithEvents lstResults As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule()
    Me.cmdTest1 = New System.Windows.Forms.Button()
    Me.cmdTest2 = New System.Windows.Forms.Button()
    Me.cmdTest4 = New System.Windows.Forms.Button()
    Me.cmdTest3 = New System.Windows.Forms.Button()
    Me.lstResults = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowCopy = True
    Me.Schedule1.AllowDragTip = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowForeignDrops = True
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
    Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
    Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.MultiSelect = False
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(584, 360)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'cmdTest1
    '
    Me.cmdTest1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdTest1.Location = New System.Drawing.Point(8, 416)
    Me.cmdTest1.Name = "cmdTest1"
    Me.cmdTest1.Size = New System.Drawing.Size(88, 24)
    Me.cmdTest1.TabIndex = 1
    Me.cmdTest1.Text = "Test 1"
    '
    'cmdTest2
    '
    Me.cmdTest2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdTest2.Location = New System.Drawing.Point(104, 416)
    Me.cmdTest2.Name = "cmdTest2"
    Me.cmdTest2.Size = New System.Drawing.Size(88, 24)
    Me.cmdTest2.TabIndex = 2
    Me.cmdTest2.Text = "Test 2"
    '
    'cmdTest4
    '
    Me.cmdTest4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdTest4.Location = New System.Drawing.Point(296, 416)
    Me.cmdTest4.Name = "cmdTest4"
    Me.cmdTest4.Size = New System.Drawing.Size(88, 24)
    Me.cmdTest4.TabIndex = 4
    Me.cmdTest4.Text = "Test 4"
    '
    'cmdTest3
    '
    Me.cmdTest3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdTest3.Location = New System.Drawing.Point(200, 416)
    Me.cmdTest3.Name = "cmdTest3"
    Me.cmdTest3.Size = New System.Drawing.Size(88, 24)
    Me.cmdTest3.TabIndex = 3
    Me.cmdTest3.Text = "Test 3"
    '
    'lstResults
    '
    Me.lstResults.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.lstResults.Location = New System.Drawing.Point(416, 368)
    Me.lstResults.Name = "lstResults"
    Me.lstResults.Size = New System.Drawing.Size(160, 69)
    Me.lstResults.TabIndex = 5
    '
    'TestForm1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(584, 445)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstResults, Me.cmdTest4, Me.cmdTest3, Me.cmdTest2, Me.cmdTest1, Me.Schedule1})
    Me.Name = "TestForm1"
    Me.Text = "Test1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub TestForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Schedule1.RoomCollection.Add("", "Room1")
    Call Schedule1.RoomCollection.Add("", "Room2")
    Call Schedule1.RoomCollection.Add("", "Room3")

    Call Schedule1.ProviderCollection.Add("", "Provider1")
    Call Schedule1.ProviderCollection.Add("", "Provider2")
    Call Schedule1.ProviderCollection.Add("", "Provider3")

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft

    Call LoadDateTime()

  End Sub

  Private Sub LoadDateTime()

    Dim appointment As Appointment

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
        appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #10:00:00 AM#, 240) 'On screen
        appointment = Schedule1.AppointmentCollection.Add("", #1/20/2004#, #10:00:00 AM#, 240) 'Off screen
        appointment = Schedule1.AppointmentCollection.Add("", #1/7/2004#, #9:00:00 AM#, 60) 'event
        appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, #10:00:00 AM#, 1440) 'activity

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
        appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 240) 'On screen
        appointment = Schedule1.AppointmentCollection.Add("", #1/20/2004#, Schedule1.RoomCollection(1), #10:00:00 AM#, 240) 'Off screen
        appointment = Schedule1.AppointmentCollection.Add("", #1/7/2004#, Schedule1.RoomCollection(2), #9:00:00 AM#, 60) 'event
        appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 1440) 'activity

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
        appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #10:00:00 AM#, 240)  'On screen
        appointment.ProviderList.Add(Schedule1.ProviderCollection(0))
        appointment = Schedule1.AppointmentCollection.Add("", #1/20/2004#, #10:00:00 AM#, 240)  'Off screen
        appointment.ProviderList.Add(Schedule1.ProviderCollection(1))
        appointment = Schedule1.AppointmentCollection.Add("", #1/7/2004#, #9:00:00 AM#, 60)  'event
        appointment.ProviderList.Add(Schedule1.ProviderCollection(2))
        appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, #10:00:00 AM#, 1440) 'activity
        appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        appointment = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(0), #10:00:00 AM#, 240) 'On screen
        appointment = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(1), #10:00:00 AM#, 240) 'Off screen
        appointment = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(2), #9:00:00 AM#, 60) 'event
        appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(0), #10:00:00 AM#, 1440) 'activity

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
        appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 240) 'On screen
        appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

        appointment = Schedule1.AppointmentCollection.Add("", #1/20/2004#, Schedule1.RoomCollection(1), #10:00:00 AM#, 240) 'Off screen
        appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

        appointment = Schedule1.AppointmentCollection.Add("", #1/7/2004#, Schedule1.RoomCollection(2), #9:00:00 AM#, 60) 'event
        appointment.ProviderList.Add(Schedule1.ProviderCollection(2))

        appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 1440) 'activity
        appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        'Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
        'appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #10:00:00 AM#, 240) 'On screen
        'Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))
        'appointment = Schedule1.AppointmentCollection.Add("", #1/20/2004#, #10:00:00 AM#, 240) 'Off screen
        'Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))
        'appointment = Schedule1.AppointmentCollection.Add("", #1/7/2004#, #9:00:00 AM#, 60) 'event
        'Call appointment.ProviderList.Add(Schedule1.ProviderCollection(2))
        'appointment.IsEvent = True
        appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, #10:00:00 AM#, 1440) 'activity
        Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

      Case Else
    End Select

    For Each appointment In Schedule1.AppointmentCollection
      appointment.Subject = "XXXXX"
    Next

  End Sub

  Private Sub cmdTest1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest1.Click

    Call lstResults.Items.Clear()

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, #9:00:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, #9:30:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, #1:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, #2:00:00 PM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #9:00:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #1:00:00 PM#, 60))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0), #9:00:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0), #1:00:00 PM#, 60))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #9:00:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #1:00:00 PM#, 60))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        'Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0)))
        'Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(1)))
        'Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #9:00:00 AM#, 30))
        'Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.RoomCollection(0), #1:00:00 PM#, 60))

        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(1)))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0), #9:00:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/1/2004#, Schedule1.ProviderCollection(0), #1:00:00 PM#, 60))

      Case Else
    End Select

  End Sub

  Private Sub cmdTest2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest2.Click

    Call lstResults.Items.Clear()

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, #9:00:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, #9:30:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, #1:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, #2:00:00 PM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1), #1:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1), #2:00:00 PM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.ProviderCollection(1), #1:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.ProviderCollection(1), #2:00:00 PM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop

        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1), #1:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/20/2004#, Schedule1.RoomCollection(1), #2:00:00 PM#, 30))

        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(1)))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft

      Case Else
    End Select

  End Sub

  Private Sub cmdTest3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest3.Click

    Call lstResults.Items.Clear()

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/6/2004#, #9:00:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, #9:30:00 AM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, #11:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/8/2004#, #2:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/6/2004#, Schedule1.RoomCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(2), #11:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/8/2004#, Schedule1.RoomCollection(2), #2:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/6/2004#, Schedule1.ProviderCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.ProviderCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.ProviderCollection(2), #11:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/8/2004#, Schedule1.ProviderCollection(2), #2:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(2), #8:30:00 PM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/7/2004#, Schedule1.RoomCollection(2), #9:30:00 PM#, 60))

        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(2)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(2), Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(2), Schedule1.ProviderCollection(2)))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft

      Case Else
    End Select

  End Sub

  Private Sub cmdTest4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest4.Click

    Call lstResults.Items.Clear()

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, #8:00:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, #1:30:00 PM#, 60))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, #3:30:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, #10:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, Schedule1.RoomCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, Schedule1.RoomCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, Schedule1.RoomCollection(0), #3:30:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/15/2004#, Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, Schedule1.ProviderCollection(0), #3:30:00 AM#, 30))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(#1/16/2004#, Schedule1.ProviderCollection(0), #10:00:00 AM#, 30))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop

      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(0), Schedule1.ProviderCollection(1)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(0)))
        Call lstResults.Items.Add(Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.RoomCollection(1), Schedule1.ProviderCollection(1)))

      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft

      Case Else
    End Select

  End Sub

End Class
