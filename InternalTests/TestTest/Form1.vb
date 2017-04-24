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
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
	Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents ContextMenu2 As System.Windows.Forms.ContextMenu
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.Button1 = New System.Windows.Forms.Button
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.Button2 = New System.Windows.Forms.Button
		Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
		Me.MenuItem1 = New System.Windows.Forms.MenuItem
		Me.Button3 = New System.Windows.Forms.Button
		Me.ContextMenu2 = New System.Windows.Forms.ContextMenu
		Me.MenuItem2 = New System.Windows.Forms.MenuItem
		Me.SuspendLayout()
		'
		'Button1
		'
		Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Button1.Location = New System.Drawing.Point(8, 376)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(88, 24)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "Button1"
		'
		'Schedule1
		'
		Me.Schedule1.AllowDrop = True
		Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
								Or System.Windows.Forms.AnchorStyles.Left) _
								Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Schedule1.Appearance.FontSize = 10.0!
		Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.Schedule1.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.ColumnHeader.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Size = 46
		Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.Appearance.NoFill = False
		Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.Schedule1.Location = New System.Drawing.Point(8, 8)
		Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
		Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.Schedule1.Name = "Schedule1"
		Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.RowHeader.Appearance.NoFill = False
		Me.Schedule1.RowHeader.Size = 30
		Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.SelectedAppointmentAppearance.NoFill = False
		Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
		Me.Schedule1.Selector.Appearance.FontSize = 10.0!
		Me.Schedule1.Selector.Appearance.NoFill = False
		Me.Schedule1.Size = New System.Drawing.Size(544, 368)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 2
		Me.Schedule1.ToolTipAutoPopDelay = 10000
		'
		'Button2
		'
		Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Button2.Location = New System.Drawing.Point(104, 376)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(88, 24)
		Me.Button2.TabIndex = 3
		Me.Button2.Text = "Button2"
		'
		'ContextMenu1
		'
		Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
		'
		'MenuItem1
		'
		Me.MenuItem1.Index = 0
		Me.MenuItem1.Text = "&Test"
		'
		'Button3
		'
		Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.Button3.Location = New System.Drawing.Point(200, 376)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(88, 24)
		Me.Button3.TabIndex = 4
		Me.Button3.Text = "Button3"
		'
		'ContextMenu2
		'
		Me.ContextMenu2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
		'
		'MenuItem2
		'
		Me.MenuItem2.Index = 0
		Me.MenuItem2.Text = "Popup Test"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.Color.Blue
		Me.ClientSize = New System.Drawing.Size(568, 405)
		Me.Controls.Add(Me.Button3)
		Me.Controls.Add(Me.Button2)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.Button1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)

	End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Schedule1.AutoRedraw = False

		Dim category1 As Category = Schedule1.CategoryCollection.Add("Category1", "Category 1", Color.Yellow)
		Dim category2 As Category = Schedule1.CategoryCollection.Add("Category2", "Category 2", Color.Blue)
		Dim category3 As Category = Schedule1.CategoryCollection.Add("Category3", "Category 3", Color.Green)

		Dim provider1 As Provider = Schedule1.ProviderCollection.Add("Provider1", "Provider 1", Color.Yellow)
		Dim provider2 As Provider = Schedule1.ProviderCollection.Add("Provider2", "Provider 2")
		Dim provider3 As Provider = Schedule1.ProviderCollection.Add("Provider3", "Provider 3")
		Dim provider4 As Provider = Schedule1.ProviderCollection.Add("Provider4", "Provider 4")
		Dim provider5 As Provider = Schedule1.ProviderCollection.Add("Provider5", "Provider 5", Color.Green)
		'Schedule1.ProviderCollection(1).Visible = False
		'Schedule1.ProviderCollection(3).Visible = False

		Dim resource1 As Resource = Schedule1.ResourceCollection.Add("Resource1", "Resource 1", Color.Yellow)
		Dim resource2 As Resource = Schedule1.ResourceCollection.Add("Resource2", "Resource 2", Color.LightGray)
		Dim resource3 As Resource = Schedule1.ResourceCollection.Add("Resource3", "Resource 3", Color.LightBlue)

		Schedule1.RoomCollection.Clear()
		For ii As Integer = 1 To 5
			Schedule1.RoomCollection.Add("", "Room " & ii)
		Next
		Schedule1.RoomCollection(1).Visible = False
		Schedule1.RoomCollection(3).Visible = False

		Dim minDate As Date = Now
		Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.Normal
		Schedule1.StartTime = #12:00:00 AM#
		Schedule1.DayLength = 24
		Schedule1.SetMinMaxDate(#10/1/2005#, #10/31/2005#)
		Schedule1.TimeMarker.Visible = True
		Schedule1.TimeMarker.Appearance.BackColor = Color.Blue
		Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock24
		Schedule1.ColumnHeader.Size = 120
		Schedule1.Appearance.BackColor = Color.LightYellow
		Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None
		Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Resource
		Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
		Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
		Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger

		Dim a As Appointment = Schedule1.AppointmentCollection.Add("", #10/2/2005#, #12:00:00 AM#, 120)
		a.Subject = "1"
		a.Room = Schedule1.RoomCollection(0)
		a.ProviderList.Add(provider1)
		a.IsEvent = True
		a = Schedule1.AppointmentCollection.Add("", #10/2/2005#, #12:30:00 AM#, 120)
		a.Subject = "2"
		a.ProviderList.Add(provider2)
		a.Room = Schedule1.RoomCollection(2)
		a = Schedule1.AppointmentCollection.Add("", #10/2/2005#, #1:00:00 AM#, 120)
		a.Subject = "3"
		a.ProviderList.Add(provider3)
		a.Room = Schedule1.RoomCollection(4)

		Schedule1.AutoRedraw = True

		Return

	End Sub


	Private Sub Schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs) Handles Schedule1.BeforePropertyDialog
		e.DialogSettings.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.Duration
	End Sub

	Private Sub SetAppointmentsVisible()

		Try
			Me.Schedule1.AutoRedraw = False

			Dim appointment As Gravitybox.objects.Appointment
			For Each appointment In Me.Schedule1.AppointmentCollection
				Debug.WriteLine(appointment.PropertyItemCollection("app_type").Setting)
				appointment.Visible = Not appointment.Visible
			Next

			Me.Schedule1.AutoRedraw = True

		Catch ex As Exception
			MsgBox(ex.ToString)
		End Try

	End Sub

	Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentAdd

		If Not e.BaseObject.PropertyItemCollection.Contains("app_type") Then
			e.BaseObject.PropertyItemCollection.Add("app_type", "", Now)
		End If

	End Sub

	Private Sub SetUpNoDropColored()

		Schedule1.NoDropAreaCollection.Clear()

		Dim dsAppointmentSet As New DataSet
		Dim da As New System.Data.SqlClient.SqlDataAdapter("select * from tblScheduleNoDropArea", "data source=localhost;database=Gravitybox;uid=sa;pwd=;")
		da.Fill(dsAppointmentSet)

		'delete the No Drop areas from the schedule
		Schedule1.NoDropAreaCollection.Clear()

		'Get the No Drop Items
		For Each dr As DataRow In dsAppointmentSet.Tables(0).Rows
			Dim NoDrop_Guid As String, GroupID As Long, col As Integer = 0
			Dim startdate As DateTime = #1/3/0001#
			Dim starttime As DateTime = #1/4/0001#
			Dim Length As Integer = -1
			Dim Room_Guid As String = ""
			Dim Provider_Guid As String = ""

			NoDrop_Guid = dr("NoDrop_Guid").ToString
			col = CInt(dr("Color"))
			Dim ColA As Color = Color.FromArgb(255, (col And &HFF0000) \ &H10000, (col And &HFF00) \ &H100, col And &HFF)
			'MsgBox(Hex(ColA.R) & " " & Hex(ColA.G) & " " & Hex(ColA.B))
			If Not (dr("Start_date") Is DBNull.Value) Then startdate = Format(CDate(dr("Start_date")), "d")
			If Not (dr("Start_time") Is DBNull.Value) Then starttime = Format(CDate(dr("Start_time")), "t")
			If Not (dr("Length") Is DBNull.Value) Then Length = CInt(dr("Length"))
			If Not (dr("Room_Guid") Is DBNull.Value) Then
				Room_Guid = dr("room_Guid").ToString
			End If
			If Not (dr("Provider_Guid") Is DBNull.Value) Then
				Provider_Guid = dr("Provider_Guid").ToString
			End If

			Dim p As Gravitybox.Objects.Provider = Nothing
			Dim r As Gravitybox.Objects.Room = Nothing
			If Provider_Guid <> "" Then
				p = Schedule1.ProviderCollection.Item(Provider_Guid)
			End If
			If Room_Guid <> "" Then
				r = Schedule1.RoomCollection.Item(Room_Guid)
			End If


			Dim text As String
			If Not (dr("Text") Is System.DBNull.Value) Then
				text = dr("Text").ToString
			End If

			Schedule1.NoDropAreaCollection.Add(NoDrop_Guid, ColA, startdate, CDate(starttime), Length, r)

		Next

	End Sub

	Private Sub Schedule1_BackgroundClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Schedule1.BackgroundClick

		If e.Button = MouseButtons.Right Then
			ContextMenu1.Show(Schedule1, New Point(e.X, e.Y))
		End If

	End Sub

	Private Sub Schedule1_AppointmentClick(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs) Handles Schedule1.AppointmentClick
		If e.Button = MouseButtons.Right Then
			ContextMenu1.Show(Schedule1, New Point(e.X, e.Y))
		End If
	End Sub

	Sub XXX()

		Dim room1 As Gravitybox.Objects.Room
		room1 = Schedule1.RoomCollection.Add("", "Room 1")

		Dim appointment As Gravitybox.Objects.Appointment
		room1 = Schedule1.RoomCollection.Add("", "Room 1")
		appointment = Schedule1.AppointmentCollection.Add("", Now, #8:00:00 AM#, 120)

		appointment.Room = room1

	End Sub

	Private Sub Schedule1_BeforeUserAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs) Handles Schedule1.BeforeUserAppointmentAdd

		'Dim dtSchCaseStart As Date = e.Appointment.StartDate.ToShortDateString & " " & e.Appointment.StartTime.ToShortTimeString()
		'Dim dtSchCaseEnd As Date = e.Appointment.EndDate.ToShortDateString & " " & e.Appointment.EndTime.ToShortTimeString()
		'Dim iSchRoomID As String = e.Appointment.Room.Key
		'Dim iSchDeptID As Integer = 0
		'e.Cancel = True

	End Sub

  Private Sub Schedule1_BeforeDragTip(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeDragTipEventArgs) Handles Schedule1.BeforeDragTip
    e.Cancel = True
    Debug.WriteLine("")
  End Sub

  Private Sub Schedule1_BeforeResizeTip(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeDragTipEventArgs) Handles Schedule1.BeforeResizeTip
    'e.Cancel = True
  End Sub

  Private Sub Schedule1_BeforeAppointmentRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs) Handles Schedule1.BeforeAppointmentRemove
    Dim a As Appointment = CType(e.BaseObject, Appointment)
    If a.Recurrence Is Nothing Then
      Debug.WriteLine("Null")
    Else
      Debug.WriteLine("Something")
    End If
  End Sub

  Private Sub Schedule1_BeforeAppointmentResize(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentSizeEventsArgs) Handles Schedule1.BeforeAppointmentResize
    'e.Cancel = True
  End Sub

  Private Sub Schedule1_BeforeAlarmDrawText(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs) Handles Schedule1.BeforeAlarmDrawText
    Dim appt As Appointment = CType(e.BaseObject, Appointment)
    If appt.Subject = "A" Then
      e.Text &= "This is a very special appointment" & vbCrLf & "for you to see"
    End If

  End Sub

  Private Sub SetUp20050606()

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Schedule1.SetMinMaxDate(Now, Now)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.ColumnHeader.AutoFit = True

    'Schedule1.AppointmentCollection.Clear()
    'Dim a As Appointment = Schedule1.AppointmentCollection.Add("", Now, Now.AddMinutes(10), 60)
    'a.Alarm.Reminder = 10
    'a.Alarm.IsArmed = True

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Schedule1.AppointmentCollection.Clear()
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    Schedule1.ProviderCollection(1).Visible = Not Schedule1.ProviderCollection(1).Visible
    Schedule1.ProviderCollection(3).Visible = Not Schedule1.ProviderCollection(3).Visible

    Schedule1.RoomCollection(1).Visible = Not Schedule1.RoomCollection(1).Visible
    Schedule1.RoomCollection(3).Visible = Not Schedule1.RoomCollection(3).Visible

  End Sub

  Private monthIndex As Integer = 0
  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    If Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft Then
      Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
    Else
      Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    End If

  End Sub

  Private Sub Schedule1_ColoredAreaClick(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.ScheduleAreaMouseEventArgs) Handles Schedule1.ColoredAreaClick
    Debug.WriteLine(e.ScheduleArea.Key)
  End Sub

  Private Sub Schedule1_BeforeRecurrenceDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeRecurrenceDialogEventArgs) Handles Schedule1.BeforeRecurrenceDialog
    e.Recurrence.EndDate = #1/1/2010#
  End Sub

  Private Sub Schedule1_ColumnHeaderClick(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterHeaderEventArgs) Handles Schedule1.ColumnHeaderClick

  End Sub

  Private Sub Schedule1_UserDrawnAppointmentBar(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs) Handles Schedule1.UserDrawnAppointmentBar
    Debug.WriteLine(Now & " " & e.Appointment.Key & " " & e.rectangle.Left & ", " & e.rectangle.Top & ", " & e.rectangle.Width & ", " & e.rectangle.Height)
  End Sub

  Private Sub Schedule1_AfterAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentMove
    Beep()
  End Sub

  Private Sub Schedule1_BeforeAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentActionEventArgs) Handles Schedule1.BeforeAppointmentMove
    Beep()
  End Sub

End Class
