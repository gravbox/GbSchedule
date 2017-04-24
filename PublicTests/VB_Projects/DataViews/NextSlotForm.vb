Option Explicit On 
Option Strict On

Imports Gravitybox.Objects

Public Class NextSlotForm
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
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.lblDescription = New System.Windows.Forms.Label
    Me.cmdClose = New System.Windows.Forms.Button
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
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
    Me.Schedule1.DayLength = 16
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
    Me.Schedule1.Size = New System.Drawing.Size(632, 400)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    '
    'lblDescription
    '
    Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblDescription.Location = New System.Drawing.Point(0, 408)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(536, 40)
    Me.lblDescription.TabIndex = 1
    Me.lblDescription.Text = "[XXX]"
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(544, 416)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(80, 24)
    Me.cmdClose.TabIndex = 2
    Me.cmdClose.Text = "&Close"
    '
    'Timer1
    '
    Me.Timer1.Interval = 2000
    '
    'NextSlotForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(632, 445)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.lblDescription)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "NextSlotForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Find Next Slot"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub NextSlotForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.WindowState = FormWindowState.Maximized
    Me.Timer1.Interval = 800

    lblDescription.Text = "This screen has a number of predefined appointments. An appointment will display in the top, left hand corner of the schedule and then move to the next free slot every 2 seconds. This functionality allows you query the schedule for available appointment space. Press 'Close' to close the screen."

    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.DayLength = 9
    Schedule1.RowHeader.Size = 25
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.AllowSelector = False

    'Load some appointments
    Call Schedule1.AppointmentCollection.Add("", #1/1/2004#, #10:00:00 AM#, 60)
    Call Schedule1.AppointmentCollection.Add("", #1/1/2004#, #12:00:00 PM#, 90)
    Call Schedule1.AppointmentCollection.Add("", #1/1/2004#, #2:00:00 PM#, 60)

    Call Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:30:00 AM#, 30)
    Call Schedule1.AppointmentCollection.Add("", #1/2/2004#, #10:00:00 AM#, 30)
    Call Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:00:00 AM#, 60)
    Call Schedule1.AppointmentCollection.Add("", #1/2/2004#, #3:00:00 PM#, 60)
    Call Schedule1.AppointmentCollection.Add("", #1/2/2004#, #4:30:00 PM#, 30)

    Call Schedule1.AppointmentCollection.Add("", #1/3/2004#, #8:00:00 AM#, 30)
    Call Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:30:00 AM#, 120)
    Call Schedule1.AppointmentCollection.Add("", #1/3/2004#, #3:30:00 PM#, 45)

    'Setup some appointment properties
    Dim appointment As Appointment
    Dim ii As Integer = 1
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Subject = "This is appointment " & ii.ToString
      ii += 1
    Next

    '*******************************************
    'Add the appointment for which we will search for slots
    'Its key is "xyz", this can be any unique string 
    appointment = Schedule1.AppointmentCollection.Add("xyz", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.Subject = "Test Appt"
    appointment.Appearance.BackColor = Color.LightBlue
    Timer1.Enabled = True

    'Refresh the schedule
    Call Schedule1.Refresh()

  End Sub

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    'Get a refernece to the appointment "xyz"
    Dim appointment As Appointment
    appointment = Schedule1.AppointmentCollection("xyz")

    'Create a skip collection to skip the test appointment itself
    'otherwise it will find itself as a conflict
    Dim skipAppts As New AppointmentList(Schedule1)
    Call skipAppts.Add(appointment)

    'Start the search at the appointment's current time + the schedule time increment (30 minutes)
    Dim startTime As Date = appointment.StartTime.Add(New TimeSpan(0, Schedule1.TimeIncrement, 0))

    'Find the next time slot
    Dim testSlot As Appointment = Schedule1.AppointmentCollection.ToList.NextAreaAvailable(appointment.StartDate, startTime, appointment.Length, True, skipAppts)

    'Set the appointment's properties to reflect the new time slot
    If testSlot Is Nothing Then
      appointment.StartDate = #1/1/2004#
      appointment.StartTime = #8:00:00 AM#
    Else
      appointment.StartDate = testSlot.StartDate
      appointment.StartTime = testSlot.StartTime
    End If

    'Refresh the schedule
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Call Me.Close()
  End Sub

End Class
