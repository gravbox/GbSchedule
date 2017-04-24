Option Explicit On 
Option Strict On

Imports Gravitybox.Objects

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
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents cmdNextSlot As System.Windows.Forms.Button
  Friend WithEvents lblHeader4 As System.Windows.Forms.Label
  Friend WithEvents cmdToggleConflicts As System.Windows.Forms.Button
  Friend WithEvents cmdToggleTransparency As System.Windows.Forms.Button
  Friend WithEvents cmdToggleRound As System.Windows.Forms.Button
  Friend WithEvents cmdToggleHeader As System.Windows.Forms.Button
  Friend WithEvents lblHeader3 As System.Windows.Forms.Label
  Friend WithEvents cmdBlue As System.Windows.Forms.Button
  Friend WithEvents cmdColorRoom As System.Windows.Forms.Button
  Friend WithEvents cmdColorProvider As System.Windows.Forms.Button
  Friend WithEvents cmdColorCategory As System.Windows.Forms.Button
  Friend WithEvents cmdViewmodeProvider As System.Windows.Forms.Button
  Friend WithEvents cmdViewmodeRoom As System.Windows.Forms.Button
  Friend WithEvents cmdViewmodeDay As System.Windows.Forms.Button
  Friend WithEvents cmdViewmodeDayRoom As System.Windows.Forms.Button
  Friend WithEvents lblHeader2 As System.Windows.Forms.Label
  Friend WithEvents lblHeader1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.cmdNextSlot = New System.Windows.Forms.Button
		Me.lblHeader4 = New System.Windows.Forms.Label
		Me.cmdToggleConflicts = New System.Windows.Forms.Button
		Me.cmdToggleTransparency = New System.Windows.Forms.Button
		Me.cmdToggleRound = New System.Windows.Forms.Button
		Me.cmdToggleHeader = New System.Windows.Forms.Button
		Me.lblHeader3 = New System.Windows.Forms.Label
		Me.cmdBlue = New System.Windows.Forms.Button
		Me.cmdColorRoom = New System.Windows.Forms.Button
		Me.cmdColorProvider = New System.Windows.Forms.Button
		Me.cmdColorCategory = New System.Windows.Forms.Button
		Me.cmdViewmodeProvider = New System.Windows.Forms.Button
		Me.cmdViewmodeRoom = New System.Windows.Forms.Button
		Me.cmdViewmodeDay = New System.Windows.Forms.Button
		Me.cmdViewmodeDayRoom = New System.Windows.Forms.Button
		Me.lblHeader2 = New System.Windows.Forms.Label
		Me.lblHeader1 = New System.Windows.Forms.Label
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Schedule1
		'
		Me.Schedule1.AllowDrop = True
		Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
								Or System.Windows.Forms.AnchorStyles.Left) _
								Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Schedule1.Appearance.FontSize = 10.0!
		Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
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
		Me.Schedule1.Location = New System.Drawing.Point(119, 0)
		Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
		Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.Schedule1.Name = "Schedule1"
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("c0b4778a-72e2-4124-9357-20a0e7648f6c", "Room1", ""))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("3b7674c7-da67-4ce3-b2db-c1c696ae71b2", "Room2", ""))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("c5906e32-a8c5-4bf8-a28f-9c2edf7b8373", "Room3", ""))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("38d0c22a-dd62-431f-bf1b-3dcc402a8f57", "Room4", ""))
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
		Me.Schedule1.Size = New System.Drawing.Size(568, 528)
		Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
		Me.Schedule1.TabIndex = 2
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.cmdNextSlot)
		Me.Panel1.Controls.Add(Me.lblHeader4)
		Me.Panel1.Controls.Add(Me.cmdToggleConflicts)
		Me.Panel1.Controls.Add(Me.cmdToggleTransparency)
		Me.Panel1.Controls.Add(Me.cmdToggleRound)
		Me.Panel1.Controls.Add(Me.cmdToggleHeader)
		Me.Panel1.Controls.Add(Me.lblHeader3)
		Me.Panel1.Controls.Add(Me.cmdBlue)
		Me.Panel1.Controls.Add(Me.cmdColorRoom)
		Me.Panel1.Controls.Add(Me.cmdColorProvider)
		Me.Panel1.Controls.Add(Me.cmdColorCategory)
		Me.Panel1.Controls.Add(Me.cmdViewmodeProvider)
		Me.Panel1.Controls.Add(Me.cmdViewmodeRoom)
		Me.Panel1.Controls.Add(Me.cmdViewmodeDay)
		Me.Panel1.Controls.Add(Me.cmdViewmodeDayRoom)
		Me.Panel1.Controls.Add(Me.lblHeader2)
		Me.Panel1.Controls.Add(Me.lblHeader1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(120, 531)
		Me.Panel1.TabIndex = 3
		'
		'cmdNextSlot
		'
		Me.cmdNextSlot.Location = New System.Drawing.Point(8, 488)
		Me.cmdNextSlot.Name = "cmdNextSlot"
		Me.cmdNextSlot.Size = New System.Drawing.Size(104, 24)
		Me.cmdNextSlot.TabIndex = 16
		Me.cmdNextSlot.Text = "Next Slot"
		'
		'lblHeader4
		'
		Me.lblHeader4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHeader4.Location = New System.Drawing.Point(8, 464)
		Me.lblHeader4.Name = "lblHeader4"
		Me.lblHeader4.Size = New System.Drawing.Size(104, 16)
		Me.lblHeader4.TabIndex = 15
		Me.lblHeader4.Text = "Effects (Toggle)"
		'
		'cmdToggleConflicts
		'
		Me.cmdToggleConflicts.Location = New System.Drawing.Point(8, 432)
		Me.cmdToggleConflicts.Name = "cmdToggleConflicts"
		Me.cmdToggleConflicts.Size = New System.Drawing.Size(104, 24)
		Me.cmdToggleConflicts.TabIndex = 14
		Me.cmdToggleConflicts.Text = "Conflicts"
		'
		'cmdToggleTransparency
		'
		Me.cmdToggleTransparency.Location = New System.Drawing.Point(8, 400)
		Me.cmdToggleTransparency.Name = "cmdToggleTransparency"
		Me.cmdToggleTransparency.Size = New System.Drawing.Size(104, 24)
		Me.cmdToggleTransparency.TabIndex = 13
		Me.cmdToggleTransparency.Text = "Transparency"
		'
		'cmdToggleRound
		'
		Me.cmdToggleRound.Location = New System.Drawing.Point(8, 368)
		Me.cmdToggleRound.Name = "cmdToggleRound"
		Me.cmdToggleRound.Size = New System.Drawing.Size(104, 24)
		Me.cmdToggleRound.TabIndex = 12
		Me.cmdToggleRound.Text = "Round"
		'
		'cmdToggleHeader
		'
		Me.cmdToggleHeader.Location = New System.Drawing.Point(8, 336)
		Me.cmdToggleHeader.Name = "cmdToggleHeader"
		Me.cmdToggleHeader.Size = New System.Drawing.Size(104, 24)
		Me.cmdToggleHeader.TabIndex = 11
		Me.cmdToggleHeader.Text = "Header"
		'
		'lblHeader3
		'
		Me.lblHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHeader3.Location = New System.Drawing.Point(8, 312)
		Me.lblHeader3.Name = "lblHeader3"
		Me.lblHeader3.Size = New System.Drawing.Size(104, 16)
		Me.lblHeader3.TabIndex = 10
		Me.lblHeader3.Text = "Effects (Toggle)"
		'
		'cmdBlue
		'
		Me.cmdBlue.Location = New System.Drawing.Point(8, 280)
		Me.cmdBlue.Name = "cmdBlue"
		Me.cmdBlue.Size = New System.Drawing.Size(104, 24)
		Me.cmdBlue.TabIndex = 9
		Me.cmdBlue.Text = "Blue"
		'
		'cmdColorRoom
		'
		Me.cmdColorRoom.Location = New System.Drawing.Point(8, 184)
		Me.cmdColorRoom.Name = "cmdColorRoom"
		Me.cmdColorRoom.Size = New System.Drawing.Size(104, 24)
		Me.cmdColorRoom.TabIndex = 8
		Me.cmdColorRoom.Text = "by Room"
		'
		'cmdColorProvider
		'
		Me.cmdColorProvider.Location = New System.Drawing.Point(8, 248)
		Me.cmdColorProvider.Name = "cmdColorProvider"
		Me.cmdColorProvider.Size = New System.Drawing.Size(104, 24)
		Me.cmdColorProvider.TabIndex = 7
		Me.cmdColorProvider.Text = "by Provider"
		'
		'cmdColorCategory
		'
		Me.cmdColorCategory.Location = New System.Drawing.Point(8, 216)
		Me.cmdColorCategory.Name = "cmdColorCategory"
		Me.cmdColorCategory.Size = New System.Drawing.Size(104, 24)
		Me.cmdColorCategory.TabIndex = 6
		Me.cmdColorCategory.Text = "by Category"
		'
		'cmdViewmodeProvider
		'
		Me.cmdViewmodeProvider.Location = New System.Drawing.Point(8, 128)
		Me.cmdViewmodeProvider.Name = "cmdViewmodeProvider"
		Me.cmdViewmodeProvider.Size = New System.Drawing.Size(104, 24)
		Me.cmdViewmodeProvider.TabIndex = 5
		Me.cmdViewmodeProvider.Text = "by Provider"
		'
		'cmdViewmodeRoom
		'
		Me.cmdViewmodeRoom.Location = New System.Drawing.Point(8, 96)
		Me.cmdViewmodeRoom.Name = "cmdViewmodeRoom"
		Me.cmdViewmodeRoom.Size = New System.Drawing.Size(104, 24)
		Me.cmdViewmodeRoom.TabIndex = 4
		Me.cmdViewmodeRoom.Text = "by Room"
		'
		'cmdViewmodeDay
		'
		Me.cmdViewmodeDay.Location = New System.Drawing.Point(8, 64)
		Me.cmdViewmodeDay.Name = "cmdViewmodeDay"
		Me.cmdViewmodeDay.Size = New System.Drawing.Size(104, 24)
		Me.cmdViewmodeDay.TabIndex = 3
		Me.cmdViewmodeDay.Text = "by Date"
		'
		'cmdViewmodeDayRoom
		'
		Me.cmdViewmodeDayRoom.Location = New System.Drawing.Point(8, 32)
		Me.cmdViewmodeDayRoom.Name = "cmdViewmodeDayRoom"
		Me.cmdViewmodeDayRoom.Size = New System.Drawing.Size(104, 24)
		Me.cmdViewmodeDayRoom.TabIndex = 2
		Me.cmdViewmodeDayRoom.Text = "by Date/Room"
		'
		'lblHeader2
		'
		Me.lblHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHeader2.Location = New System.Drawing.Point(8, 160)
		Me.lblHeader2.Name = "lblHeader2"
		Me.lblHeader2.Size = New System.Drawing.Size(104, 16)
		Me.lblHeader2.TabIndex = 1
		Me.lblHeader2.Text = "Color Appts"
		'
		'lblHeader1
		'
		Me.lblHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblHeader1.Location = New System.Drawing.Point(8, 8)
		Me.lblHeader1.Name = "lblHeader1"
		Me.lblHeader1.Size = New System.Drawing.Size(104, 16)
		Me.lblHeader1.TabIndex = 0
		Me.lblHeader1.Text = "ViewMode"
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(686, 531)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Gravitybox Schedule.NET Dataviews Example"
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

  Dim headerOn As Boolean = False
  Dim TransparencyOn As Boolean = True

  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup Schedule
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None
    Schedule1.AllowSelector = False

    'Add NoDropAreas
    Schedule1.NoDropAreaCollection.Add("", Color.Red, #12:00:00 PM#, 90) 'Lunch hour

    'Load Data
    Dim appointment As Appointment
    Dim provider As Provider
    Dim room As Room
    Dim category As Category

    'Load Providers
    provider = Schedule1.ProviderCollection.Add("", "Sam", Color.LightGoldenrodYellow)
    provider = Schedule1.ProviderCollection.Add("", "Julie", Color.LightGray)
    provider = Schedule1.ProviderCollection.Add("", "Joe", Color.LightGreen)

    'Load Categories
    category = Schedule1.CategoryCollection.Add("", "Major", Color.LightBlue)
    category = Schedule1.CategoryCollection.Add("", "Cleaning", Color.LightCoral)
    category = Schedule1.CategoryCollection.Add("", "Misc", Color.LightCyan)

    'Load Rooms
    room = Schedule1.RoomCollection.Add("", "Exam I")
    room = Schedule1.RoomCollection.Add("", "Exam II")

    'Load Appointments
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(0), #8:00:00 AM#, 60)
    appointment.Subject = "Sue Collins"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(0), #9:30:00 AM#, 60)
    appointment.Subject = "Joe Jones"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(2))

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(0), #10:30:00 AM#, 60)
    appointment.Subject = "Bill Sellers"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(1))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(1), #8:30:00 AM#, 60)
    appointment.Subject = "Jack Jones"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(1))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(1), #9:30:00 AM#, 60)
    appointment.Subject = "Mike Martin"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, Schedule1.RoomCollection(1), #10:30:00 AM#, 90)
    appointment.Subject = "Ian Davis"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(2))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, Schedule1.RoomCollection(0), #9:00:00 AM#, 90)
    appointment.Subject = "Rusty Grey"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(1))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 90)
    appointment.Subject = "John Smith"
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(2))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

    'Format all appointments
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.IsRound = True
      appointment.Appearance.Transparency = 30
      appointment.Appearance.BackColor = Color.LightBlue
    Next

    Schedule1.Refresh()

  End Sub

  Private Sub cmdViewmodeDayRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewmodeDayRoom.Click
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
  End Sub

  Private Sub cmdViewmodeDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewmodeDay.Click
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
  End Sub

  Private Sub cmdViewmodeRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewmodeRoom.Click
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
  End Sub

  Private Sub cmdViewmodeProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewmodeProvider.Click
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
  End Sub

  Private Sub cmdColorRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColorRoom.Click

    'There is no room color so just map the room to some color
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      Select Case Schedule1.RoomCollection.IndexOf(appointment.Room)
        Case 0 : appointment.Appearance.BackColor = Color.LightPink
        Case 1 : appointment.Appearance.BackColor = Color.LightSeaGreen
      End Select
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdColorCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColorCategory.Click

    'Set the color to its Category's color
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.BackColor = CType(appointment.CategoryList(0), Gravitybox.Objects.Category).Appearance.BackColor
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdColorProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColorProvider.Click

    'Set the color to its Provider's color
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.BackColor = CType(appointment.ProviderList(0), Gravitybox.Objects.Provider).Appearance.BackColor
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlue.Click

    'Set the color to Blue
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.BackColor = Color.LightBlue
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdToggleHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleHeader.Click

    'Toggle the appointment header on/off
    headerOn = Not headerOn
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      If headerOn Then
        appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
        appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
        appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
        appointment.Header.Appearance.AllowBreak = True
        appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
      Else
        appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
      End If
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdToggleRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleRound.Click

    'Set the color to Blue
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.IsRound = Not appointment.Appearance.IsRound
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdToggleTransparency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleTransparency.Click

    'Set the color to Blue
    TransparencyOn = Not TransparencyOn
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      If TransparencyOn Then
        appointment.Appearance.Transparency = 30
      Else
        appointment.Appearance.Transparency = 0
      End If
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdToggleConflicts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToggleConflicts.Click

    If Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap Then
      Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
    ElseIf Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide Then
      Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
    ElseIf Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger Then
      Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap
    End If

  End Sub

  Private Sub cmdNextSlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextSlot.Click

    Dim F As New NextSlotForm
    Call F.ShowDialog()

  End Sub

End Class
