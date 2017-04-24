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
  Friend WithEvents cmdColumnHeader As System.Windows.Forms.Button
  Friend WithEvents cmdRowHeader As System.Windows.Forms.Button
  Friend WithEvents cmdSchedule As System.Windows.Forms.Button
  Friend WithEvents cmdAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdSelector As System.Windows.Forms.Button
  Friend WithEvents cmdArea As System.Windows.Forms.Button
  Friend WithEvents cmdSelectedAppointment As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.cmdColumnHeader = New System.Windows.Forms.Button
    Me.cmdRowHeader = New System.Windows.Forms.Button
    Me.cmdSchedule = New System.Windows.Forms.Button
    Me.cmdAppointment = New System.Windows.Forms.Button
    Me.cmdSelector = New System.Windows.Forms.Button
    Me.cmdArea = New System.Windows.Forms.Button
    Me.cmdSelectedAppointment = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
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
    Me.Schedule1.Size = New System.Drawing.Size(778, 376)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 0
    '
    'cmdColumnHeader
    '
    Me.cmdColumnHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdColumnHeader.Location = New System.Drawing.Point(8, 408)
    Me.cmdColumnHeader.Name = "cmdColumnHeader"
    Me.cmdColumnHeader.Size = New System.Drawing.Size(104, 24)
    Me.cmdColumnHeader.TabIndex = 1
    Me.cmdColumnHeader.Text = "Column Header"
    Me.ToolTip1.SetToolTip(Me.cmdColumnHeader, "Apply a gradient look to the column header.")
    '
    'cmdRowHeader
    '
    Me.cmdRowHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdRowHeader.Location = New System.Drawing.Point(8, 440)
    Me.cmdRowHeader.Name = "cmdRowHeader"
    Me.cmdRowHeader.Size = New System.Drawing.Size(104, 24)
    Me.cmdRowHeader.TabIndex = 2
    Me.cmdRowHeader.Text = "Row Header"
    Me.ToolTip1.SetToolTip(Me.cmdRowHeader, "Apply a gradient look to the row header.")
    '
    'cmdSchedule
    '
    Me.cmdSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdSchedule.Location = New System.Drawing.Point(120, 408)
    Me.cmdSchedule.Name = "cmdSchedule"
    Me.cmdSchedule.Size = New System.Drawing.Size(104, 24)
    Me.cmdSchedule.TabIndex = 3
    Me.cmdSchedule.Text = "Schedule"
    Me.ToolTip1.SetToolTip(Me.cmdSchedule, "Apply a gradient look to the schedule background.")
    '
    'cmdAppointment
    '
    Me.cmdAppointment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdAppointment.Location = New System.Drawing.Point(120, 440)
    Me.cmdAppointment.Name = "cmdAppointment"
    Me.cmdAppointment.Size = New System.Drawing.Size(104, 24)
    Me.cmdAppointment.TabIndex = 4
    Me.cmdAppointment.Text = "Appointment"
    Me.ToolTip1.SetToolTip(Me.cmdAppointment, "Apply a custom look to all appointments.")
    '
    'cmdSelector
    '
    Me.cmdSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdSelector.Location = New System.Drawing.Point(232, 408)
    Me.cmdSelector.Name = "cmdSelector"
    Me.cmdSelector.Size = New System.Drawing.Size(104, 24)
    Me.cmdSelector.TabIndex = 5
    Me.cmdSelector.Text = "Selector"
    Me.ToolTip1.SetToolTip(Me.cmdSelector, "Apply a colorful look to the area selector. Click the mouse on the schedule to mo" & _
    "ve the selector.")
    '
    'cmdArea
    '
    Me.cmdArea.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdArea.Location = New System.Drawing.Point(232, 442)
    Me.cmdArea.Name = "cmdArea"
    Me.cmdArea.Size = New System.Drawing.Size(104, 24)
    Me.cmdArea.TabIndex = 6
    Me.cmdArea.Text = "Area"
    Me.ToolTip1.SetToolTip(Me.cmdArea, "Create a highlighted area on the schedule with a custom appearance.")
    '
    'cmdSelectedAppointment
    '
    Me.cmdSelectedAppointment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdSelectedAppointment.Location = New System.Drawing.Point(344, 408)
    Me.cmdSelectedAppointment.Name = "cmdSelectedAppointment"
    Me.cmdSelectedAppointment.Size = New System.Drawing.Size(104, 24)
    Me.cmdSelectedAppointment.TabIndex = 7
    Me.cmdSelectedAppointment.Text = "Selected"
    Me.ToolTip1.SetToolTip(Me.cmdSelectedAppointment, "Create a custom appearance for selected appointments. Click on appointments to hi" & _
    "ghlight them.")
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 384)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(376, 16)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Press each button to apply a custom appearance to each object."
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(778, 471)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cmdSelectedAppointment)
    Me.Controls.Add(Me.cmdArea)
    Me.Controls.Add(Me.cmdSelector)
    Me.Controls.Add(Me.cmdAppointment)
    Me.Controls.Add(Me.cmdSchedule)
    Me.Controls.Add(Me.cmdRowHeader)
    Me.Controls.Add(Me.cmdColumnHeader)
    Me.Controls.Add(Me.Schedule1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup schedule
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Call Schedule1.SetMinMaxDate(Now, Now.AddDays(3))
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10

    'Add appointment
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection.Add("", Now.AddDays(1), #9:00:00 AM#, 150)
    appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Subject = "This is a test for you to see. I also have a tooltip."
    appointment.ToolTipText = "Just tooltip text."

    appointment = Schedule1.AppointmentCollection.Add("", Now.AddDays(2), #9:30:00 AM#, 150)
    appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Subject = "Some more text"
    appointment.ToolTipText = "Tooltip 2."

    appointment = Schedule1.AppointmentCollection.Add("", Now.AddDays(3), #10:00:00 AM#, 150)
    appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Subject = "Yet again more text!"
    appointment.ToolTipText = "Tooltip 3."

  End Sub

  Private Sub cmdColumnHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColumnHeader.Click

    Schedule1.ColumnHeader.Appearance.BackColor = Color.Aqua
    Schedule1.ColumnHeader.Appearance.BackColor2 = Color.White
    Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical

  End Sub

  Private Sub cmdRowHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRowHeader.Click

    Schedule1.RowHeader.Appearance.BackColor = Color.Aqua
    Schedule1.RowHeader.Appearance.BackColor2 = Color.White
    Schedule1.RowHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal

  End Sub

  Private Sub cmdSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedule.Click

    Schedule1.Appearance.BackColor = Color.White
    Schedule1.Appearance.BackColor2 = Color.Aqua
    Schedule1.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal

  End Sub

  Private Sub cmdAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppointment.Click

    If Schedule1.AppointmentCollection.Count = 0 Then Exit Sub
    Schedule1.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.None
    Dim appointment As Gravitybox.Objects.Appointment
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.IsRound = True
      appointment.Appearance.BackColor = Color.White
      appointment.Appearance.BackColor2 = Color.LightSkyBlue
      appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal
      appointment.Appearance.Transparency = 35
      appointment.Appearance.TextVAlign = StringAlignment.Center

      appointment.Header.Appearance.BackColor = Color.White
      appointment.Header.Appearance.BackColor2 = Color.Aqua
      appointment.Header.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
      appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.Text
      appointment.Header.Text = "This is a very long header text!"
      appointment.Header.Appearance.TextTrimming = StringTrimming.EllipsisCharacter
      appointment.Header.Appearance.TextVAlign = StringAlignment.Center
    Next

    Schedule1.Refresh()

  End Sub

  Private Sub cmdSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelector.Click

    Schedule1.Selector.Appearance.BackColor = Color.Blue
    Schedule1.Selector.Appearance.BackColor2 = Color.Yellow
    Schedule1.Selector.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical

  End Sub

  Private Sub cmdArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdArea.Click

    Schedule1.ColoredAreaCollection.Clear()
    Dim area As Gravitybox.Objects.ScheduleArea = Schedule1.ColoredAreaCollection.Add("", Color.LightPink, Now, #9:00:00 AM#, 90)
    area.Appearance.BorderWidth = 0
    area.Appearance.BackColor2 = Color.Red
    area.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal

    Schedule1.Refresh()

  End Sub

  Private Sub cmdSelectedAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectedAppointment.Click

    Schedule1.SelectionType = Gravitybox.Controls.Schedule.SelectionTypeConstants.SelectedAppearance

    Schedule1.SelectedAppointmentAppearance.BackColor = Color.White
    Schedule1.SelectedAppointmentAppearance.BackColor2 = Color.LightGreen
    Schedule1.SelectedAppointmentAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal
    Schedule1.SelectedAppointmentAppearance.IsRound = True

    Schedule1.SelectedAppointmentHeaderAppearance.BackColor = Color.White
    Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = Color.LightGreen
    Schedule1.SelectedAppointmentHeaderAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal

  End Sub

End Class
