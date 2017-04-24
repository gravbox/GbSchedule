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
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents cmdLoad As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdAdd = New System.Windows.Forms.Button
    Me.cmdSave = New System.Windows.Forms.Button
    Me.cmdLoad = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'cmdAdd
    '
    Me.cmdAdd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdAdd.Location = New System.Drawing.Point(8, 296)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(96, 24)
    Me.cmdAdd.TabIndex = 1
    Me.cmdAdd.Text = "Add"
    '
    'cmdSave
    '
    Me.cmdSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdSave.Location = New System.Drawing.Point(112, 296)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(96, 24)
    Me.cmdSave.TabIndex = 2
    Me.cmdSave.Text = "Save"
    '
    'cmdLoad
    '
    Me.cmdLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdLoad.Location = New System.Drawing.Point(216, 296)
    Me.cmdLoad.Name = "cmdLoad"
    Me.cmdLoad.Size = New System.Drawing.Size(96, 24)
    Me.cmdLoad.TabIndex = 3
    Me.cmdLoad.Text = "Load"
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowCopy = True
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
    Me.Schedule1.BlockOutColor = System.Drawing.Color.Black
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
    Me.Schedule1.Size = New System.Drawing.Size(392, 288)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 4
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 325)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1, Me.cmdLoad, Me.cmdSave, Me.cmdAdd})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    Call Me.Schedule1.AppointmentCollection.Clear()

    'Add a template appointment
    Dim appointment As Appointment
    appointment = Me.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 60)

    'Dim recurrence As New RecurrenceItem()
    'recurrence.EndIterations = 3
    'recurrence.EndType = RecurrenceEndConstants.recEndByInterval
    'recurrence.StartDate = appointment.StartDate
    'recurrence.RecurrenceDay.DayInterval = 2
    'recurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.rdcDayInterval
    'Call Me.Schedule1.AppointmentItems.AddRecurrence(appointment, recurrence)
    Call Me.Schedule1.Refresh()

  End Sub

  Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

  End Sub

  Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Me.Schedule1.SetMinMaxDate(#1/1/2004#, #1/10/2004#)
    Me.Schedule1.StartTime = #8:00:00 AM#
    Me.Schedule1.DayLength = 10

    Me.WindowState = FormWindowState.Maximized

  End Sub

End Class
