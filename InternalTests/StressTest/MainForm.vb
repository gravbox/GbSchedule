Option Explicit On 
Option Strict On

Imports Gravitybox
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
  Friend WithEvents cmdAddmany As System.Windows.Forms.Button
  Friend WithEvents lstResults As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.cmdAddmany = New System.Windows.Forms.Button
    Me.lstResults = New System.Windows.Forms.ListBox
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Schedule1.ColumnHeader.Appearance = CType(resources.GetObject("Schedule1.ColumnHeader.Appearance"), Gravitybox.Objects.AppointmentHeaderAppearance)
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.BackColor = System.Drawing.Color.Blue
    Me.Schedule1.DefaultAppointmentAppearance.BorderColor = System.Drawing.Color.Blue
    Me.Schedule1.DefaultAppointmentAppearance.ForeColor = System.Drawing.Color.Blue
    Me.Schedule1.DefaultAppointmentAppearance.Header = CType(resources.GetObject("resource.Header"), Gravitybox.Objects.AppointmentHeaderAppearance2)
    Me.Schedule1.DefaultAppointmentAppearance.IsRound = True
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentAppearance.Transparency = 85
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.BackColor = System.Drawing.Color.Blue
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontBold = True
    Me.Schedule1.DefaultAppointmentHeaderAppearance.ForeColor = System.Drawing.Color.White
    Me.Schedule1.DefaultAppointmentHeaderAppearance.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Transparency = 20
    Me.Schedule1.Location = New System.Drawing.Point(-8, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance = CType(resources.GetObject("Schedule1.RowHeader.Appearance"), Gravitybox.Objects.AppointmentHeaderAppearance)
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.Size = New System.Drawing.Size(624, 344)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    '
    'cmdAddmany
    '
    Me.cmdAddmany.Location = New System.Drawing.Point(544, 408)
    Me.cmdAddmany.Name = "cmdAddmany"
    Me.cmdAddmany.Size = New System.Drawing.Size(80, 24)
    Me.cmdAddmany.TabIndex = 1
    Me.cmdAddmany.Text = "Add Many"
    '
    'lstResults
    '
    Me.lstResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lstResults.Location = New System.Drawing.Point(8, 352)
    Me.lstResults.Name = "lstResults"
    Me.lstResults.Size = New System.Drawing.Size(304, 69)
    Me.lstResults.TabIndex = 2
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(624, 437)
    Me.Controls.Add(Me.lstResults)
    Me.Controls.Add(Me.cmdAddmany)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "MainForm"
    Me.Text = "Stress Test"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdAddmany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddmany.Click

    Const TotalCount As Integer = 500
    Const StartDate As Date = #1/1/2004#
    Dim appointment As Appointment
    Dim ii As Integer
    Dim startTime As Date
    Dim endTime As Date

    Schedule1.AutoRedraw = False
    Schedule1.MultiSelect = True
    Call Schedule1.SetMinMaxDate(StartDate, StartDate.AddDays(TotalCount - 1))
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Call Schedule1.AppointmentCollection.Clear()

    Dim appearance As New AppointmentAppearance
    Dim headerappearance As New AppointmentHeaderAppearance

    startTime = Now
    For ii = 1 To TotalCount
      appointment = Schedule1.AppointmentCollection.Add("", DateAdd(DateInterval.Day, ii - 1, Schedule1.MinDate), #8:00:00 AM#, 120)
      appointment.Subject = "Subject " & ii.ToString
      appointment.Appearance = appearance
    Next
    endTime = Now
    Call lstResults.Items.Add(endTime.Subtract(startTime).TotalMilliseconds.ToString)

    startTime = Now
    appearance.IsRound = True
    appearance.Transparency = 30
    appearance.BackColor = Color.LightBlue
    appearance.ForeColor = Color.Black
    headerappearance.Transparency = 0
    headerappearance.BackColor = Color.Blue
    headerappearance.ForeColor = Color.White
    endTime = Now
    Call lstResults.Items.Add(endTime.Subtract(startTime).TotalMilliseconds.ToString)

    startTime = Now
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    Next
    endTime = Now
    Call lstResults.Items.Add(endTime.Subtract(startTime).TotalMilliseconds.ToString)

    Schedule1.AutoRedraw = True
    'Call Schedule1.Refresh()

  End Sub

End Class