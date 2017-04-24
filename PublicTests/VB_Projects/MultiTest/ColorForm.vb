Option Strict On
Option Explicit On 

Public Class ColorForm
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
    Me.Schedule1.DayLength = 12
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
    Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(624, 445)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 2
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'ColorForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(624, 445)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1})
    Me.Name = "ColorForm"
    Me.Text = "ColorForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ColorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:00:00 AM#, 120)
    appointment.Subject = "This is a test"

    'Appointment Color
    appointment.Appearance.BackColor = Color.BlanchedAlmond
    appointment.Appearance.ForeColor = Color.DarkGray

    'Other Colors
    Schedule1.Appearance.BackColor = Color.Yellow
    Schedule1.Appearance.ForeColor = Color.Blue
    Schedule1.BackColor = Color.Green
    Schedule1.EventHeader.Appearance.BackColor = Color.DarkKhaki
    Schedule1.Selector.Appearance.BackColor = Color.DarkRed

    'RowHeader
    Schedule1.RowHeader.Appearance.BackColor = Color.Blue 'Background
    Schedule1.RowHeader.Appearance.ForeColor = Color.Yellow 'Text
    Schedule1.RowHeader.Appearance.BorderColor = Color.LightGray 'Border

    'ColumnHeader
    Schedule1.ColumnHeader.Appearance.BackColor = Color.Yellow 'Background
    Schedule1.ColumnHeader.Appearance.ForeColor = Color.Blue 'Text
    Schedule1.ColumnHeader.Appearance.BorderColor = Color.DarkGreen 'Border

  End Sub

End Class
