Option Strict On
Option Explicit On 

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
  Friend WithEvents mnuFileFlip As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.mnuFileFlip = New System.Windows.Forms.MenuItem
    Me.mnuFileExit = New System.Windows.Forms.MenuItem
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.mnuFile = New System.Windows.Forms.MenuItem
    Me.MenuItem3 = New System.Windows.Forms.MenuItem
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'mnuFileFlip
    '
    Me.mnuFileFlip.Index = 0
    Me.mnuFileFlip.RadioCheck = True
    Me.mnuFileFlip.Text = "&Flip Mode"
    '
    'mnuFileExit
    '
    Me.mnuFileExit.Index = 2
    Me.mnuFileExit.Text = "E&xit"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileFlip, Me.MenuItem3, Me.mnuFileExit})
    Me.mnuFile.Text = "&File"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 1
    Me.MenuItem3.Text = "-"
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
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
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
    Me.Schedule1.Size = New System.Drawing.Size(504, 349)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 3
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(504, 349)
    Me.Controls.Add(Me.Schedule1)
    Me.Menu = Me.MainMenu1
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET Blockout Example"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Load"

  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.SetBounds(0, 0, 800, 500)

    'Setup the Schedule properties
    Schedule1.HeaderDateFormat = "MM/dd"
    Call Schedule1.SetMinMaxDate(#1/12/2004#, #1/16/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.BlockoutColor = Color.Blue

    'Create the lunch hour
    Call Schedule1.ColoredAreaCollection.Add("", Color.LightGreen, #12:00:00 PM#, 60)
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.RowHeader.AutoFit = True

    'Load the Rooms
    Call Schedule1.RoomCollection.Add("", "Room1")
    Call Schedule1.RoomCollection.Add("", "Room2")

    'Load some appointments
    Dim appointment As Appointment
    appointment = Schedule1.AppointmentCollection.Add("", #1/12/2004#, Schedule1.RoomCollection(0), #9:00:00 AM#, 90)
    appointment = Schedule1.AppointmentCollection.Add("", #1/13/2004#, Schedule1.RoomCollection(1), #3:00:00 PM#, 120)
    appointment = Schedule1.AppointmentCollection.Add("", #1/13/2004#, Schedule1.RoomCollection(0), #10:00:00 AM#, 90)
    appointment = Schedule1.AppointmentCollection.Add("", #1/13/2004#, Schedule1.RoomCollection(1), #9:00:00 AM#, 120)
    appointment = Schedule1.AppointmentCollection.Add("", #1/13/2004#, Schedule1.RoomCollection(0), #11:00:00 AM#, 60)
    appointment = Schedule1.AppointmentCollection.Add("", #1/13/2004#, Schedule1.RoomCollection(1), #4:00:00 PM#, 120)
    appointment = Schedule1.AppointmentCollection.Add("", #1/14/2004#, Schedule1.RoomCollection(0), #8:00:00 AM#, 60)
    appointment = Schedule1.AppointmentCollection.Add("", #1/14/2004#, Schedule1.RoomCollection(1), #9:00:00 AM#, 60)
    appointment = Schedule1.AppointmentCollection.Add("", #1/14/2004#, Schedule1.RoomCollection(0), #9:30:00 AM#, 90)
    appointment = Schedule1.AppointmentCollection.Add("", #1/14/2004#, Schedule1.RoomCollection(1), #11:00:00 AM#, 30)
    appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(0), #8:30:00 AM#, 30)
    appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(1), #3:30:00 AM#, 90)
    appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(0), #1:30:00 AM#, 60)
    appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(1), #1:30:00 PM#, 120)
    appointment = Schedule1.AppointmentCollection.Add("", #1/15/2004#, Schedule1.RoomCollection(0), #3:00:00 PM#, 90)
    appointment = Schedule1.AppointmentCollection.Add("", #1/16/2004#, Schedule1.RoomCollection(1), #9:00:00 AM#, 120)
    appointment = Schedule1.AppointmentCollection.Add("", #1/16/2004#, Schedule1.RoomCollection(0), #10:30:00 AM#, 60)
    appointment = Schedule1.AppointmentCollection.Add("", #1/16/2004#, Schedule1.RoomCollection(1), #4:30:00 AM#, 30)

    For Each appointment In Schedule1.AppointmentCollection
      appointment.Subject = RandomString()
    Next

  End Sub

#End Region

#Region "Random String"

  Public Function RandomString() As String
    Return RandomString(10)
  End Function

  Public Function RandomString(ByVal count As Integer) As String

    Dim retval As String
    Dim ii As Integer
    If count < 1 Then count = 1
    For ii = 1 To count
      retval += Chr(65 + CInt(25 * Rnd()))
    Next
    Return retval

  End Function

#End Region

#Region "Menus"

  Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
    Me.Close()
  End Sub

  Private Sub mnuFileFlip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileFlip.Click

    Schedule1.AutoRedraw = False

    'Now check to normal interactive day mode
    Dim appointment As Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Blockout = Not mnuFileFlip.Checked
    Next
    Schedule1.AllowSelector = mnuFileFlip.Checked
    mnuFileFlip.Checked = Not mnuFileFlip.Checked

    Schedule1.AutoRedraw = True

  End Sub

#End Region

End Class
