Option Strict On
Option Explicit On 

Imports Gravitybox.Objects

Public Class Form1
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
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents cmdNextSlot As System.Windows.Forms.Button
  Friend WithEvents cmdTestForm As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.mnuFile = New System.Windows.Forms.MenuItem
    Me.mnuFileExit = New System.Windows.Forms.MenuItem
    Me.cmdNextSlot = New System.Windows.Forms.Button
    Me.cmdTestForm = New System.Windows.Forms.Button
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
    Me.Schedule1.Size = New System.Drawing.Size(456, 381)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileExit})
    Me.mnuFile.Text = "&File"
    '
    'mnuFileExit
    '
    Me.mnuFileExit.Index = 0
    Me.mnuFileExit.Text = "E&xit"
    '
    'cmdNextSlot
    '
    Me.cmdNextSlot.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdNextSlot.Location = New System.Drawing.Point(368, 392)
    Me.cmdNextSlot.Name = "cmdNextSlot"
    Me.cmdNextSlot.Size = New System.Drawing.Size(80, 24)
    Me.cmdNextSlot.TabIndex = 1
    Me.cmdNextSlot.Text = "Next Slot"
    '
    'cmdTestForm
    '
    Me.cmdTestForm.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdTestForm.Location = New System.Drawing.Point(8, 392)
    Me.cmdTestForm.Name = "cmdTestForm"
    Me.cmdTestForm.Size = New System.Drawing.Size(80, 24)
    Me.cmdTestForm.TabIndex = 2
    Me.cmdTestForm.Text = "Test Form"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(456, 417)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdTestForm, Me.cmdNextSlot, Me.Schedule1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Conflict Checking"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
    Call Me.Close()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the schedule
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Call Schedule1.SetMinMaxDate(#1/1/2002#, #1/5/2002#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.AllowSelector = False
    Me.WindowState = FormWindowState.Maximized

    Dim appointment As Gravitybox.Objects.Appointment

    'Test Appointment
    appointment = Schedule1.AppointmentCollection.Add("xyz", #1/1/2002#, #8:00:00 AM#, 60)
    appointment.Subject = "Test Appointment"
    appointment.Appearance.BackColor = Color.LightBlue

    'Junk appointments
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2002#, #10:00:00 AM#, 60)
    appointment.Subject = "A1"
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2002#, #11:30:00 AM#, 120)
    appointment.Subject = "A2"
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2002#, #3:30:00 PM#, 30)
    appointment.Subject = "A3"
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2002#, #8:30:00 AM#, 30)
    appointment.Subject = "A4"
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2002#, #12:00:00 PM#, 30)
    appointment.Subject = "A5"
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2002#, #1:30:00 AM#, 60)
    appointment.Subject = "A6"

    ConflictTest()

  End Sub

  Private Sub cmdNextSlot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextSlot.Click

    'Get a reference to the first test appointment
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection("xyz")

    'Create a list of appointments to skip when searching
    'We want to skip the test appointment because we do not
    'care that it conflicts with itsself.
    Dim appointmentList As New Gravitybox.Objects.AppointmentList(Schedule1)
    Call appointmentList.Add(appointment)

    'Start the search at the next time increment, 
    'the appointment start time + 30 minutes
    Dim startTime As Date
    startTime = DateAdd(DateInterval.Minute, Schedule1.TimeIncrement, appointment.StartTime)

    'Get the next free slot
    Dim space As Gravitybox.Objects.Appointment
        space = Schedule1.AppointmentCollection.ToList.NextAreaAvailable(appointment.StartDate, startTime, appointment.Length, False, appointmentList)

    'Reset the appointment to the next slot
    appointment.StartDate = space.StartDate
    appointment.StartTime = space.StartTime
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdTestForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestForm.Click
    Dim F As New TestForm1
    Call F.ShowDialog()
  End Sub

  Private Sub ConflictTest()

		Dim a As Appointment
		Schedule1.AppointmentCollection.Clear()
		Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #9:00:00 AM#, 60)
		a = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #10:00:00 AM#, 60)

		Dim bb As Boolean = Schedule1.AppointmentCollection.IsConflict(a)

		Dim b As Boolean
		b = Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.MinDate, #8:00:00 AM#, 60)
		b = Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.MinDate, #9:00:00 AM#, 60)
		b = Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.MinDate, #10:00:00 AM#, 60)
		b = Schedule1.AppointmentCollection.ToList.IsAreaAvailable(Schedule1.MinDate, #11:00:00 AM#, 60)

  End Sub

End Class
