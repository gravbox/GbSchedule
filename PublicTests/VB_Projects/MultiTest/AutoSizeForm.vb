Option Strict On
Option Explicit On 

Public Class AutoSizeForm
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
  Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
    Me.lblDescription = New System.Windows.Forms.Label
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
    Me.Schedule1.Location = New System.Drawing.Point(192, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(424, 422)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'MonthCalendar1
    '
    Me.MonthCalendar1.Name = "MonthCalendar1"
    Me.MonthCalendar1.TabIndex = 1
    '
    'lblDescription
    '
    Me.lblDescription.Location = New System.Drawing.Point(0, 160)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(192, 208)
    Me.lblDescription.TabIndex = 2
    Me.lblDescription.Text = "XXX"
    '
    'AutoSizeForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(616, 421)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDescription, Me.MonthCalendar1, Me.Schedule1})
    Me.Name = "AutoSizeForm"
    Me.Text = "AutoSizeForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub AutoSizeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the contorols
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 9
    Schedule1.HeaderDateFormat = "ddd M/d"
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft

    'Reset the display date
    Call ReloadWeek(Now)

  End Sub

  Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged

    'Reset the display date
    Call ReloadWeek(e.Start)

  End Sub

  Private Sub ReloadWeek(ByVal newDate As Date)

    'This will display the work week that contains the specified date
    Dim dayIndex As Integer = newDate.DayOfWeek
    Dim weekStart As Date = DateAdd(DateInterval.Day, -dayIndex + 1, newDate)
    Dim weekEnd As Date = DateAdd(DateInterval.Day, 4, weekStart)
    Call Schedule1.SetMinMaxDate(weekStart, weekEnd)
    Call MonthCalendar1.SetSelectionRange(weekStart, weekEnd)

    'Add code to load appointments here
    'TODO

  End Sub

End Class
