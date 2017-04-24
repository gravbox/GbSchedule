Imports Gravitybox.Objects

Public Class AllViewmodes
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
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AllViewmodes))
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.SuspendLayout()
		'
		'ListBox1
		'
		Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Left
		Me.ListBox1.Location = New System.Drawing.Point(0, 0)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(120, 485)
		Me.ListBox1.TabIndex = 0
		'
		'Schedule1
		'
		Me.Schedule1.AllowDrop = True
		Me.Schedule1.Appearance.FontSize = 10.0!
		Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.Schedule1.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.ColumnHeader.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Size = 100
		Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.Appearance.NoFill = False
		Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.Schedule1.Location = New System.Drawing.Point(120, 0)
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
		Me.Schedule1.Size = New System.Drawing.Size(600, 493)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 1
		'
		'AllViewmodes
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(720, 493)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.ListBox1)
		Me.Name = "AllViewmodes"
		Me.Text = "AllViewmodes"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub AllViewmodes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Schedule1.AutoRedraw = False

		Dim category1 As Category = Schedule1.CategoryCollection.Add("Category1", "Category 1", Color.Yellow)
		Dim category2 As Category = Schedule1.CategoryCollection.Add("Category2", "Category 2", Color.Blue)
		Dim category3 As Category = Schedule1.CategoryCollection.Add("Category3", "Category 3", Color.Green)

		Dim provider1 As Provider = Schedule1.ProviderCollection.Add("Provider1", "Provider 1", Color.Yellow)
		Dim provider2 As Provider = Schedule1.ProviderCollection.Add("Provider2", "Provider 2", Color.Salmon)
		Dim provider3 As Provider = Schedule1.ProviderCollection.Add("Provider3", "Provider 3", Color.SandyBrown)
		Dim provider4 As Provider = Schedule1.ProviderCollection.Add("Provider4", "Provider 4", Color.Turquoise)
		Dim provider5 As Provider = Schedule1.ProviderCollection.Add("Provider5", "Provider 5", Color.Green)

		Dim resource1 As Resource = Schedule1.ResourceCollection.Add("Resource1", "Resource 1", Color.Yellow)
		Dim resource2 As Resource = Schedule1.ResourceCollection.Add("Resource2", "Resource 2", Color.LightGray)
		Dim resource3 As Resource = Schedule1.ResourceCollection.Add("Resource3", "Resource 3", Color.LightBlue)

		Dim room1 As Room = Schedule1.RoomCollection.Add("Room1", "Room 1")
		Dim room2 As Room = Schedule1.RoomCollection.Add("Room2", "Room 2")
		Dim room3 As Room = Schedule1.RoomCollection.Add("Room3", "Room 3")
		Dim room4 As Room = Schedule1.RoomCollection.Add("Room4", "Room 4")
		Dim room5 As Room = Schedule1.RoomCollection.Add("Room5", "Room 5")

		For Each o As Object In [Enum].GetValues(GetType(Gravitybox.Controls.Schedule.ViewModeConstants))
			ListBox1.Items.Add(o)
		Next

		ListBox1.SelectedIndex = 0

		'******************************************************
		Dim minDate As Date = Now
		Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
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

		Dim a As Appointment = Schedule1.AppointmentCollection.Add("", #10/1/2005#, #12:00:00 AM#, 120)
		a.Subject = "1"
		a.Room = Schedule1.RoomCollection(0)
		a.ProviderList.Add(provider1)
		a.ResourceList.Add(resource1)
		a.IsEvent = True

		a = Schedule1.AppointmentCollection.Add("", #10/1/2005#, #12:30:00 AM#, 120)
		a.Subject = "2"
		a.ProviderList.Add(provider2)
		a.Room = Schedule1.RoomCollection(2)
		a.ResourceList.Add(resource2)

		a = Schedule1.AppointmentCollection.Add("", #10/1/2005#, #1:00:00 AM#, 120)
		a.Subject = "3"
		a.ProviderList.Add(provider3)
		a.Room = Schedule1.RoomCollection(4)
		a.ResourceList.Add(resource3)

		Schedule1.AutoRedraw = True

	End Sub

	Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
		Schedule1.ViewMode = ListBox1.SelectedItem
	End Sub

	Private Sub Schedule1_BeforeAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentActionEventArgs) Handles Schedule1.BeforeAppointmentMove
		Beep()
	End Sub

	Private Sub Schedule1_AfterAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentMove
		Beep()
	End Sub

	Private Sub Schedule1_AfterAppointmentResize(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs) Handles Schedule1.AfterAppointmentResize
		Beep()
	End Sub

	Private Sub Schedule1_BeforeAppointmentResize(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentSizeEventsArgs) Handles Schedule1.BeforeAppointmentResize
		Beep()
	End Sub

End Class
