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
  Friend WithEvents cmdFile As System.Windows.Forms.Button
  Friend WithEvents cmdConflictDisplay As System.Windows.Forms.Button
  Friend WithEvents cmdRed As System.Windows.Forms.Button
  Friend WithEvents cmdGreen As System.Windows.Forms.Button
  Friend WithEvents cmdBlue As System.Windows.Forms.Button
  Friend WithEvents cmdConflicts As System.Windows.Forms.Button
  Friend WithEvents cmdAllowHeaders As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
  Friend WithEvents cmdRound As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.cmdFile = New System.Windows.Forms.Button
    Me.cmdConflictDisplay = New System.Windows.Forms.Button
    Me.cmdRed = New System.Windows.Forms.Button
    Me.cmdGreen = New System.Windows.Forms.Button
    Me.cmdBlue = New System.Windows.Forms.Button
    Me.cmdConflicts = New System.Windows.Forms.Button
    Me.cmdAllowHeaders = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.TrackBar1 = New System.Windows.Forms.TrackBar
    Me.cmdRound = New System.Windows.Forms.Button
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdFile
    '
    Me.cmdFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdFile.Location = New System.Drawing.Point(544, 421)
    Me.cmdFile.Name = "cmdFile"
    Me.cmdFile.Size = New System.Drawing.Size(96, 24)
    Me.cmdFile.TabIndex = 19
    Me.cmdFile.Text = "File"
    '
    'cmdConflictDisplay
    '
    Me.cmdConflictDisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdConflictDisplay.Location = New System.Drawing.Point(336, 421)
    Me.cmdConflictDisplay.Name = "cmdConflictDisplay"
    Me.cmdConflictDisplay.Size = New System.Drawing.Size(96, 24)
    Me.cmdConflictDisplay.TabIndex = 15
    Me.cmdConflictDisplay.Text = "Conflict Display"
    '
    'cmdRed
    '
    Me.cmdRed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdRed.Location = New System.Drawing.Point(440, 389)
    Me.cmdRed.Name = "cmdRed"
    Me.cmdRed.Size = New System.Drawing.Size(96, 24)
    Me.cmdRed.TabIndex = 16
    Me.cmdRed.Text = "Red"
    '
    'cmdGreen
    '
    Me.cmdGreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdGreen.Location = New System.Drawing.Point(440, 421)
    Me.cmdGreen.Name = "cmdGreen"
    Me.cmdGreen.Size = New System.Drawing.Size(96, 24)
    Me.cmdGreen.TabIndex = 17
    Me.cmdGreen.Text = "Green"
    '
    'cmdBlue
    '
    Me.cmdBlue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdBlue.Location = New System.Drawing.Point(544, 389)
    Me.cmdBlue.Name = "cmdBlue"
    Me.cmdBlue.Size = New System.Drawing.Size(96, 24)
    Me.cmdBlue.TabIndex = 18
    Me.cmdBlue.Text = "Blue"
    '
    'cmdConflicts
    '
    Me.cmdConflicts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdConflicts.Location = New System.Drawing.Point(336, 389)
    Me.cmdConflicts.Name = "cmdConflicts"
    Me.cmdConflicts.Size = New System.Drawing.Size(96, 24)
    Me.cmdConflicts.TabIndex = 13
    Me.cmdConflicts.Text = "Conflicts"
    '
    'cmdAllowHeaders
    '
    Me.cmdAllowHeaders.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdAllowHeaders.Location = New System.Drawing.Point(232, 389)
    Me.cmdAllowHeaders.Name = "cmdAllowHeaders"
    Me.cmdAllowHeaders.Size = New System.Drawing.Size(96, 24)
    Me.cmdAllowHeaders.TabIndex = 11
    Me.cmdAllowHeaders.Text = "Allow Headers"
    '
    'Label1
    '
    Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.Location = New System.Drawing.Point(16, 397)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(200, 16)
    Me.Label1.TabIndex = 14
    Me.Label1.Text = "Transparency"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'TrackBar1
    '
    Me.TrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TrackBar1.LargeChange = 20
    Me.TrackBar1.Location = New System.Drawing.Point(8, 413)
    Me.TrackBar1.Maximum = 100
    Me.TrackBar1.Name = "TrackBar1"
    Me.TrackBar1.Size = New System.Drawing.Size(216, 40)
    Me.TrackBar1.SmallChange = 5
    Me.TrackBar1.TabIndex = 20
    Me.TrackBar1.TickFrequency = 5
    Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft
    '
    'cmdRound
    '
    Me.cmdRound.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdRound.Location = New System.Drawing.Point(232, 421)
    Me.cmdRound.Name = "cmdRound"
    Me.cmdRound.Size = New System.Drawing.Size(96, 24)
    Me.cmdRound.TabIndex = 12
    Me.cmdRound.Text = "Round"
    '
    'ImageList1
    '
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
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
    Me.Schedule1.Size = New System.Drawing.Size(640, 384)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 21
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(640, 453)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.cmdFile)
    Me.Controls.Add(Me.cmdConflictDisplay)
    Me.Controls.Add(Me.cmdRed)
    Me.Controls.Add(Me.cmdGreen)
    Me.Controls.Add(Me.cmdBlue)
    Me.Controls.Add(Me.cmdConflicts)
    Me.Controls.Add(Me.cmdAllowHeaders)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TrackBar1)
    Me.Controls.Add(Me.cmdRound)
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET Effects Example"
    CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Dim AllowHeaders As Boolean = True
  Dim Msg1Displayed As Boolean = False
  Dim Msg2Displayed As Boolean = False

  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.MultiSelect = True
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider

    Call Schedule1.ProviderCollection.Add("", "Provider I", Color.Yellow)
    Call Schedule1.ProviderCollection.Add("", "Provider II", Color.Red)

    Call Schedule1.CategoryCollection.Add("", "Category I", Color.Yellow)
    Call Schedule1.CategoryCollection.Add("", "Category II", Color.Red)

    Call Schedule1.RoomCollection.Add("", "Room I")
    Call Schedule1.RoomCollection.Add("", "Room II")

		Call LoadSet5()
		Schedule1.Visibility.ShowTime(#8:00:00 AM#)

  End Sub

  Private Sub LoadSet1()

    Const Transparency As Integer = 40
    Dim appointment As Appointment

		Schedule1.AutoRedraw = False
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 120)
    appointment.Subject = "Appointment 1"
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightBlue
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 120)
    appointment.Subject = "Appointment 2"
    appointment.Appearance.BackColor = Color.LightCoral
    appointment.Appearance.Transparency = Transparency
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:30:00 AM#, 60)
    appointment.Subject = "Appointment 3"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightCyan
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #12:30:00 PM#, 60)
    appointment.Subject = "Appointment 4"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGoldenrodYellow
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "Appointment 5"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightGray
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #1:30:00 PM#, 60)
    appointment.Subject = "Appointment 6"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text
    appointment.Header.Text = "Custom"
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/4/2004#, #8:30:00 AM#, 90)
    appointment.Subject = "Appointment 7"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightPink
    appointment.Header.Appearance.Transparency = 0

    appointment = Schedule1.AppointmentCollection.Add("", #1/5/2004#, #11:30:00 AM#, 90)
    appointment.Subject = "Appointment 8"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightSeaGreen
    appointment.Header.Appearance.Transparency = 0
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None

		Schedule1.AutoRedraw = True

  End Sub

  Private Sub LoadSet2()

    Const Transparency As Integer = 50
    Dim appointment As Appointment

		Schedule1.AutoRedraw = False
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 120)
    appointment.Subject = "Appointment 1"
    appointment.Appearance.BackColor = Color.LightCoral
    appointment.Appearance.Transparency = Transparency
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    appointment.Header.Appearance.AllowBreak = True
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))
    Call appointment.IconCollection.Add("", Me.ImageList1.Images(0))
    Call appointment.IconCollection.Add("", Me.ImageList1.Images(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "Appointment 2"
    appointment.Appearance.BackColor = Color.LightGray
    appointment.Appearance.Transparency = Transparency
    appointment.Header.Icon = Schedule1.DefaultIcons.IconQuestion
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    TrackBar1.Value = Transparency
		Schedule1.AutoRedraw = True

  End Sub

  Private Sub LoadSet3()

    Const Transparency As Integer = 50
    Dim appointment As Appointment

    'If Not Msg2Displayed Then
    '  Call MsgBox("This example will toggle the appointment headers on/off.", MsgBoxStyle.Information)
    '  Msg2Displayed = True
    'End If

		Schedule1.AutoRedraw = False
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #12:00:00 PM#, 90)
    appointment.Subject = "Appointment 1"
    appointment.Appearance.BackColor = Color.LightBlue
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    appointment.Header.Appearance.AllowBreak = True

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 150)
    appointment.Subject = "Appointment 2"
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    appointment.Header.Appearance.AllowBreak = True

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:30:00 AM#, 60)
    appointment.Subject = "Appointment 3"
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    appointment.Header.Appearance.AllowBreak = True

    TrackBar1.Value = Transparency
		Schedule1.AutoRedraw = True

  End Sub

  Private Sub LoadSet5()

    Const Transparency As Integer = 40
    Dim appointment As Appointment

		Schedule1.AutoRedraw = False
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #8:00:00 AM#, 120)
    appointment.Subject = "Appointment 1"
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightBlue
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:00:00 AM#, 120)
    appointment.Subject = "Appointment 2"
    appointment.Appearance.BackColor = Color.LightCoral
    appointment.Appearance.Transparency = Transparency
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/4/2004#, #9:30:00 AM#, 60)
    appointment.Subject = "Appointment 3"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightCyan
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #12:30:00 PM#, 60)
    appointment.Subject = "Appointment 4"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGoldenrodYellow
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/5/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "Appointment 5"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightGray
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #1:30:00 PM#, 60)
    appointment.Subject = "Appointment 6"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text
    appointment.Header.Text = "Custom"
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:30:00 AM#, 90)
    appointment.Subject = "Appointment 7"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightPink
    appointment.Header.Appearance.Transparency = 0

    appointment = Schedule1.AppointmentCollection.Add("", #1/4/2004#, #11:30:00 AM#, 90)
    appointment.Subject = "Appointment 8"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightSeaGreen
    appointment.Header.Appearance.Transparency = 0
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None

		Schedule1.AutoRedraw = True

  End Sub

  Private Sub cmdRound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRound.Click

    If Not Msg1Displayed Then
      Call MsgBox("This example will toggle the corners of the appointment between round and square.", MsgBoxStyle.Information)
      Msg1Displayed = True
    End If

		Schedule1.AutoRedraw = False
		Dim appointment As Appointment = Nothing
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.IsRound = Not appointment.Appearance.IsRound
    Next
		Schedule1.AutoRedraw = True

  End Sub

  Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged

		Schedule1.AutoRedraw = False
		Dim appointment As Appointment = Nothing
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.Transparency = TrackBar1.Value
      appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    Next
		Schedule1.AutoRedraw = True

  End Sub

  Private Sub cmdAllowHeaders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllowHeaders.Click

		Me.AllowHeaders = Not Me.AllowHeaders
		Schedule1.AutoRedraw = False
		Dim appointment As Appointment = Nothing
    For Each appointment In Schedule1.AppointmentCollection
      If AllowHeaders Then
        appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
      Else
        appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
      End If
    Next
		Schedule1.AutoRedraw = True

  End Sub

  Private Sub cmdConflicts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConflicts.Click

    Call MsgBox("This example will turn off the side-by-side conflict view but you can still see the appointment because the top layer is 50% transparent.", MsgBoxStyle.Information)

    Call LoadSet3()
    Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap

  End Sub

	Private Sub Schedule1_AppointmentHeaderInfoClick(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)

		Dim appointment As Appointment = CType(e.BaseObject, Appointment)
		Call MsgBox("You clicked the info box for appointment: " & appointment.Subject, MsgBoxStyle.Information)

	End Sub

#Region "Color Schemes"

	Private Sub cmdBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBlue.Click
		Call AddScheme(Color.LightBlue, Color.Black, Color.Blue, Color.White)
	End Sub

	Private Sub cmdGreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGreen.Click
		Call AddScheme(Color.LightGreen, Color.Black, Color.Green, Color.White)
	End Sub

	Private Sub cmdRed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRed.Click
		Call AddScheme(Color.LightPink, Color.Black, Color.Red, Color.White)
	End Sub

	Private Sub AddScheme(ByVal apptBackColor As Color, ByVal apptForeColor As Color, ByVal headerBackColor As Color, ByVal headerForeColor As Color)

		Schedule1.AutoRedraw = False
		Dim appointment As Appointment = Nothing
		Call Schedule1.AppointmentCollection.Clear()

		appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 90)
		appointment.Subject = "Appointment 1"

		appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 120)
		appointment.Subject = "Appointment 2"

		appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:00:00 AM#, 90)
		appointment.Subject = "Appointment 3"

		appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #10:00:00 AM#, 90)
		appointment.Subject = "Appointment 4"

		appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #9:30:00 AM#, 150)
		appointment.Subject = "Appointment 5"

		'Background 40% transparent
		'Appointment color white
		'Appointment is round
		'Header NOT transparent
		'Header Font White
		'Header Info Icon
		'Header has line below (break)
		'Header shows time
		For Each appointment In Schedule1.AppointmentCollection
			appointment.Appearance.BackColor = apptBackColor
			appointment.Appearance.ForeColor = apptForeColor
			appointment.Appearance.Transparency = 40
			appointment.Appearance.IsRound = True
			appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
			appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
			appointment.Header.Appearance.Transparency = 0
			appointment.Header.Appearance.AllowBreak = True
			appointment.Header.Appearance.BackColor = headerBackColor
			appointment.Header.Appearance.ForeColor = headerForeColor
		Next
		Schedule1.AutoRedraw = True

	End Sub

#End Region

	Private Sub cmdConflictDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConflictDisplay.Click

		If Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap Then
			Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
		ElseIf Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide Then
			Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
		ElseIf Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger Then
			Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap
		End If

	End Sub

	Private Sub cmdFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFile.Click

		Call MsgBox("This example will save the entire appointment collection to the file 'C:\Test.vcs' and then reload it.", MsgBoxStyle.Information)

    Call Schedule1.AppointmentCollection.ToVCAL("C:\Test.vcs", False)
		Schedule1.AppointmentCollection.Clear()
    Call Schedule1.AppointmentCollection.FromVCAL("C:\Test.vcs", False)
		Call Schedule1.Refresh()

	End Sub

End Class
