Imports Gravitybox.Objects

Public Class Form2
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
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button1 As System.Windows.Forms.Button
	Friend WithEvents cmdBack As System.Windows.Forms.Button
  Friend WithEvents cmdForward As System.Windows.Forms.Button
	Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents Button3 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form2))
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
    Me.cmdForward = New System.Windows.Forms.Button
    Me.cmdBack = New System.Windows.Forms.Button
    Me.Button1 = New System.Windows.Forms.Button
    Me.Button2 = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.Button3 = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.NumericUpDown1)
    Me.Panel1.Controls.Add(Me.cmdForward)
    Me.Panel1.Controls.Add(Me.cmdBack)
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Controls.Add(Me.Button2)
    Me.Panel1.Controls.Add(Me.Button3)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 333)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(688, 48)
    Me.Panel1.TabIndex = 0
    '
    'NumericUpDown1
    '
    Me.NumericUpDown1.Location = New System.Drawing.Point(144, 16)
    Me.NumericUpDown1.Name = "NumericUpDown1"
    Me.NumericUpDown1.Size = New System.Drawing.Size(64, 20)
    Me.NumericUpDown1.TabIndex = 3
    '
    'cmdForward
    '
    Me.cmdForward.Location = New System.Drawing.Point(496, 16)
    Me.cmdForward.Name = "cmdForward"
    Me.cmdForward.Size = New System.Drawing.Size(24, 16)
    Me.cmdForward.TabIndex = 2
    Me.cmdForward.Text = ">"
    '
    'cmdBack
    '
    Me.cmdBack.Location = New System.Drawing.Point(464, 16)
    Me.cmdBack.Name = "cmdBack"
    Me.cmdBack.Size = New System.Drawing.Size(24, 16)
    Me.cmdBack.TabIndex = 1
    Me.cmdBack.Text = "<"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(24, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(88, 24)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Button1"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(240, 8)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(88, 24)
    Me.Button2.TabIndex = 0
    Me.Button2.Text = "Button1"
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.Appearance.ItemLineColor = System.Drawing.Color.FromArgb(CType(90, Byte), CType(142, Byte), CType(206, Byte))
    Me.Schedule1.Appearance.ItemLineWidth = 2
    Me.Schedule1.Appearance.Key = "a29c6998-fa57-4b16-9739-95733f8ad53a"
    Me.Schedule1.Appearance.MajorLineColor = System.Drawing.Color.FromArgb(CType(156, Byte), CType(186, Byte), CType(231, Byte))
    Me.Schedule1.Appearance.MajorLineWidth = 1
    Me.Schedule1.Appearance.MinorLineColor = System.Drawing.Color.FromArgb(CType(214, Byte), CType(231, Byte), CType(247, Byte))
    Me.Schedule1.Appearance.MinorLineWidth = 1
    Me.Schedule1.Appearance.NoFill = False
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Appearance.Key = "38fa0ce2-b833-4b48-9db3-2de19c3d6eda"
    Me.Schedule1.ColumnHeader.Appearance.NoFill = False
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentAppearance.Key = "ff2f3460-1eff-4768-baf8-a399bc720f18"
    Me.Schedule1.DefaultAppointmentAppearance.NoFill = False
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Key = "b37cc9ec-858a-4322-863a-16e3e8509be6"
    Me.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.Appearance.Key = "7b2f9bbf-f6fc-49c8-abff-fca64138280e"
    Me.Schedule1.EventHeader.Appearance.NoFill = False
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.Key = "5619a964-7b89-4dd5-ae61-90003c7240b1"
    Me.Schedule1.EventHeader.ExpandAppearance.NoFill = False
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 31, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Appearance.Key = "75f0f325-b5ec-4d0c-8cc0-ce640c3962ff"
    Me.Schedule1.RowHeader.Appearance.NoFill = False
    Me.Schedule1.RowHeader.Size = 25
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentAppearance.Key = "1077a292-5ec1-4997-bcb2-ca9540ae6279"
    Me.Schedule1.SelectedAppointmentAppearance.NoFill = False
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentHeaderAppearance.Key = "a58d9d0e-4155-456c-8e69-04d3ec778c67"
    Me.Schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.Key = "64b479ed-6967-421a-933a-9c7bb2cb05e9"
    Me.Schedule1.Selector.Appearance.NoFill = False
    Me.Schedule1.Size = New System.Drawing.Size(688, 333)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 2
    '
    'ImageList1
    '
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(344, 8)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(88, 24)
    Me.Button3.TabIndex = 0
    Me.Button3.Text = "Button1"
    '
    'Form2
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(688, 381)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Form2"
    Me.Text = "Form2"
    Me.Panel1.ResumeLayout(False)
    CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private ReadOnly minDate As Date = #1/1/2005#

  Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim ap As New Gravitybox.Controls.AppointmentProperties

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
		Schedule1.FirstDayOfWeek = DayOfWeek.Monday
		'Schedule1.RowHeader.Size = 30

		Dim minDate As Date = #1/1/2005#
		Call Schedule1.SetMinMaxDate(minDate, minDate.AddDays(10))
		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10

		For ii As Integer = 1 To 10
			Schedule1.ProviderCollection.Add("", "Provider " & ii.ToString)
		Next
		For ii As Integer = 1 To 10
			Schedule1.RoomCollection.Add("", "Room " & ii.ToString)
		Next

		Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Far
		NumericUpDown1.Value = Schedule1.ColumnHeader.Size

		Dim appt As Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(0), #8:00:00 AM#, 60)
		appt.StartDate = minDate.AddDays(18)
		appt.ProviderList.Add(Schedule1.ProviderCollection(0))
		appt.Subject = "111"

		appt = Schedule1.AppointmentCollection.Add("", Schedule1.RoomCollection(Schedule1.RoomCollection.Count - 1), #8:00:00 AM#, 60)
		appt.ProviderList.Add(Schedule1.ProviderCollection(Schedule1.ProviderCollection.Count - 1))

		'Dim recur As New Recurrence
		'recur.RecurrenceDay.DayInterval = 1
		'recur.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval
		'recur.EndIterations = 3
		'recur.EndType = RecurrenceEndConstants.EndByInterval
		'Schedule1.AppointmentCollection.AddRecurrence(appt, recur)

		'Dim p1 As Provider = Schedule1.ProviderCollection.Add("", "Provider 1")
		'Dim p2 As Provider = Schedule1.ProviderCollection.Add("", "Provider 2")
		'Dim p3 As Provider = Schedule1.ProviderCollection.Add("", "Provider 3")

		'Schedule1.ColoredAreaCollection.Add("", Color.LightBlue, p2)

		'For ii As Integer = 0 To 9
		'	Dim a1 As Appointment = Schedule1.AppointmentCollection.Add("", minDate, #8:00:00 AM#.AddHours(ii), 60)
		'	a1.Subject = ii.ToString
		'	a1.Appearance.BackColor = Color.LightBlue
		'Next

		'Schedule1.ColoredAreaCollection.Clear()
		'For ii As Integer = 1 To 31
		'	Dim dt As Date = minDate.AddDays(ii - 1)
		'	Schedule1.ColoredAreaCollection.Add("", Color.LightBlue, dt)
		'	Debug.WriteLine(dt.ToShortDateString)
		'Next

		'SetupMain()
		'CreateSaveXML()

	End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Dim F As New Form2
    F.ShowDialog()

    'Dim pds As New PrintDialogSettings(Schedule1.MinDate, Schedule1.StartTime, Schedule1.MaxDate, Schedule1.EndTime)
    'pds.CancelButtonText = "XXX"
    'pds.PageLabelText = "YYY"
    'pds.SixPagesToolTip = "Yo bro"
    'pds.PageSettings.Margins = New System.Drawing.Printing.Margins(20, 20, 20, 20)
    'Schedule1.GoPreview(pds)

    'If Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Near Then
    '	Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Far
    'Else
    '	Schedule1.ColumnHeader.Appearance.Alignment = StringAlignment.Near
    'End If

  End Sub

  Private Sub SetupMain()

    Schedule1.SetMinMaxDate(minDate, minDate.AddDays(30))
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Schedule1.AppointmentTimeIncrement = Schedule1.TimeIncrement
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10

    Dim settings As New PrintDialogSettings(#1/1/2004#, #6:00:00 AM#, #1/1/2004#, #7:00:00 PM#)
    settings.PageSettings.PrinterSettings.DefaultPageSettings.Margins.Left = 100

    Dim room1 As Room = Schedule1.RoomCollection.Add("", "Room 1")
    Dim room2 As Room = Schedule1.RoomCollection.Add("", "Room 2")
    Dim room3 As Room = Schedule1.RoomCollection.Add("", "Room 3")

    Dim provider1 As Provider = Schedule1.ProviderCollection.Add("", "Provider 1")
    Dim provider2 As Provider = Schedule1.ProviderCollection.Add("", "Provider 2")
    Dim provider3 As Provider = Schedule1.ProviderCollection.Add("", "Provider 3")
    Dim provider4 As Provider = Schedule1.ProviderCollection.Add("", "Provider 4")
    Dim provider5 As Provider = Schedule1.ProviderCollection.Add("", "Provider 5")

    Dim resource1 As Resource = Schedule1.ResourceCollection.Add("", "Resource 1")
    Dim resource2 As Resource = Schedule1.ResourceCollection.Add("", "Resource 2")
    Dim resource3 As Resource = Schedule1.ResourceCollection.Add("", "Resource 3")

    Dim category1 As Category = Schedule1.CategoryCollection.Add("", "Category 1")
    Dim category2 As Category = Schedule1.CategoryCollection.Add("", "Category 2")

    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection.Add("", minDate, #8:00:00 AM#, 120)
    appointment.ProviderList.Add(provider1)
    appointment.ProviderList.Add(provider3)
    appointment.ResourceList.Add(resource1)
    appointment.ResourceList.Add(resource3)

    appointment = Schedule1.AppointmentCollection.Add("", minDate.AddDays(1), #11:00:00 AM#, 120)
    appointment.ProviderList.Add(provider2)
    appointment.ResourceList.Add(resource2)

  End Sub

  Private Sub CreateSaveXML()

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Schedule1.SetMinMaxDate(#1/1/2004#, #12/31/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10

    Schedule1.AutoRedraw = False
    Dim startTime As Date = Now
    Schedule1.AppointmentCollection.Clear()
    For ii As Integer = 0 To 300 - 1
      Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(ii), #8:00:00 AM#, 60)
    Next
    Dim endTime As Date = Now
    Schedule1.AutoRedraw = True

    MsgBox("Load Time: " & endTime.Subtract(startTime).TotalMilliseconds, MsgBoxStyle.Information)

    startTime = Now
    Schedule1.AppointmentCollection.SaveXML("c:\20050404a.xml")
    endTime = Now
    MsgBox("Save XML Time:" & endTime.Subtract(startTime).TotalMilliseconds, MsgBoxStyle.Information)

  End Sub

  Private Sub Schedule1_BeforeUserAppointmentAdd(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)

    'If Schedule1.AppointmentCollection.IsConflict(e.Appointment, New AppointmentList(Schedule1, e.Appointment)) Then
    If Schedule1.AppointmentCollection.IsConflict(e.BaseObject) Then
      MsgBox("Operation cancelled!", MsgBoxStyle.Exclamation, "Conflict")
      e.Cancel = True
      Schedule1.AppointmentCollection.Remove(e.BaseObject)
    End If

  End Sub

  Private Sub ColorDays()

    Schedule1.ColoredAreaCollection.Clear()
    For ii As Integer = 0 To 40
      If ii Mod 2 = 0 Then
        Schedule1.ColoredAreaCollection.Add("", Color.LightBlue, Schedule1.MinDate.AddDays(ii))
      Else
        Schedule1.ColoredAreaCollection.Add("", Color.LightSalmon, Schedule1.MinDate.AddDays(ii))
      End If
    Next
    Schedule1.Refresh()

  End Sub

#Region "Navigation Buttons"

  Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
    Dim dt As Date = Schedule1.MinDate.AddMonths(-1)
    Schedule1.SetMinMaxDate(dt, dt)
    ColorDays()
  End Sub

  Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click
    Dim dt As Date = Schedule1.MinDate.AddMonths(1)
    Schedule1.SetMinMaxDate(dt, dt)
    ColorDays()
  End Sub

#End Region

  Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
    Schedule1.ColumnHeader.Size = NumericUpDown1.Value
  End Sub

  Private iconIndex As Integer
  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    Dim appt As Appointment
    appt = Me.Schedule1.AppointmentCollection.Add("", Me.Schedule1.MinDate, #8:00:00 AM#, 120)

    If iconIndex >= Me.ImageList1.Images.Count Then
      iconIndex = 0
    End If

    appt.IconCollection.Add("", Me.ImageList1.Images(iconIndex))
    iconIndex += 1

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    If Me.Schedule1.AppointmentCollection.Count > 0 Then
      Me.Schedule1.AppointmentCollection(Me.Schedule1.AppointmentCollection.Count - 1).IconCollection.Clear()
    End If

  End Sub

End Class
