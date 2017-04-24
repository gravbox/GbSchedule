Option Explicit On 
Option Strict On

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
  Friend WithEvents cmdAddMany As System.Windows.Forms.Button
  Friend WithEvents cmdClear As System.Windows.Forms.Button
  Friend WithEvents cmdReserved As System.Windows.Forms.Button
  Friend WithEvents cmdReserved2 As System.Windows.Forms.Button
  Friend WithEvents cmdReserved3 As System.Windows.Forms.Button
  Friend WithEvents cmdConflictDisplay As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
	Friend WithEvents menuTest As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
		Me.cmdAddMany = New System.Windows.Forms.Button
		Me.cmdClear = New System.Windows.Forms.Button
		Me.cmdReserved = New System.Windows.Forms.Button
		Me.cmdReserved2 = New System.Windows.Forms.Button
		Me.cmdReserved3 = New System.Windows.Forms.Button
		Me.cmdConflictDisplay = New System.Windows.Forms.Button
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
		Me.menuTest = New System.Windows.Forms.MenuItem
		Me.SuspendLayout()
		'
		'cmdAddMany
		'
		Me.cmdAddMany.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdAddMany.Location = New System.Drawing.Point(16, 304)
		Me.cmdAddMany.Name = "cmdAddMany"
		Me.cmdAddMany.Size = New System.Drawing.Size(112, 24)
		Me.cmdAddMany.TabIndex = 2
		Me.cmdAddMany.Text = "Add Many"
		'
		'cmdClear
		'
		Me.cmdClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdClear.Location = New System.Drawing.Point(136, 304)
		Me.cmdClear.Name = "cmdClear"
		Me.cmdClear.Size = New System.Drawing.Size(112, 24)
		Me.cmdClear.TabIndex = 3
		Me.cmdClear.Text = "Clear"
		'
		'cmdReserved
		'
		Me.cmdReserved.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdReserved.Location = New System.Drawing.Point(376, 304)
		Me.cmdReserved.Name = "cmdReserved"
		Me.cmdReserved.Size = New System.Drawing.Size(112, 24)
		Me.cmdReserved.TabIndex = 4
		Me.cmdReserved.Text = "Reserved"
		'
		'cmdReserved2
		'
		Me.cmdReserved2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdReserved2.Location = New System.Drawing.Point(496, 304)
		Me.cmdReserved2.Name = "cmdReserved2"
		Me.cmdReserved2.Size = New System.Drawing.Size(112, 24)
		Me.cmdReserved2.TabIndex = 5
		Me.cmdReserved2.Text = "Reserved2"
		'
		'cmdReserved3
		'
		Me.cmdReserved3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdReserved3.Location = New System.Drawing.Point(616, 304)
		Me.cmdReserved3.Name = "cmdReserved3"
		Me.cmdReserved3.Size = New System.Drawing.Size(112, 24)
		Me.cmdReserved3.TabIndex = 6
		Me.cmdReserved3.Text = "Reserved3"
		'
		'cmdConflictDisplay
		'
		Me.cmdConflictDisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmdConflictDisplay.Location = New System.Drawing.Point(256, 304)
		Me.cmdConflictDisplay.Name = "cmdConflictDisplay"
		Me.cmdConflictDisplay.Size = New System.Drawing.Size(112, 24)
		Me.cmdConflictDisplay.TabIndex = 7
		Me.cmdConflictDisplay.Text = "Conflict Display"
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
		Me.Schedule1.BackColor = System.Drawing.Color.White
		Me.Schedule1.CategoryCollection.Add(New Gravitybox.Objects.Category("975d3116-e70d-4bf1-9cc2-9aba67904709", "Category2", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.CategoryCollection.Add(New Gravitybox.Objects.Category("cc6f5c69-0ef6-4879-aea8-c239ed945956", "Category1", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.CategoryCollection.Add(New Gravitybox.Objects.Category("0427f29e-e1cd-431d-8bf8-31c58dc060c6", "Category3", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.CategoryCollection.Add(New Gravitybox.Objects.Category("a3d51d9d-ad7f-4355-bc5f-fca043894cd6", "Category5", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.ColumnHeader.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Size = 100
		Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Schedule1.DefaultAppointmentAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
		Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentAppearance.IsRound = True
		Me.Schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.Schedule1.DefaultAppointmentAppearance.Transparency = 44
		Me.Schedule1.DefaultAppointmentHeaderAppearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
		Me.Schedule1.DefaultAppointmentHeaderAppearance.FontBold = True
		Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.Color.Black
		Me.Schedule1.EventHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
		Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.Appearance.NoFill = False
		Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.Schedule1.Location = New System.Drawing.Point(0, 0)
		Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
		Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.Schedule1.Name = "Schedule1"
		Me.Schedule1.PriorityCollection.Add(New Gravitybox.Objects.Priority("ceeaa6b8-7b37-447c-b1bc-fec81b3c2ab1", "Priority1", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.PriorityCollection.Add(New Gravitybox.Objects.Priority("4aa44e19-e5d1-4289-96c3-35920481e902", "Priority2", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.PriorityCollection.Add(New Gravitybox.Objects.Priority("5549b3d7-d97c-4f39-99d6-3a73e55b2b01", "Priority3", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.ProviderCollection.Add(New Gravitybox.Objects.Provider("51fc459d-780c-4c08-8c4c-c8a92f0c7c2a", "Provider1", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.ProviderCollection.Add(New Gravitybox.Objects.Provider("bbe32a91-0da3-451f-a0b7-6d00ee3b778c", "Provider2", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.ProviderCollection.Add(New Gravitybox.Objects.Provider("5df93569-bba2-4f82-8ad0-103d7cdb0175", "Provider3", "", System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(255, Byte))))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("0378cb6f-4b46-4682-b747-1a14cd245368", "Room1", ""))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("5443c49e-254d-42f8-b0db-caf56a56c7f6", "Room2", ""))
		Me.Schedule1.RoomCollection.Add(New Gravitybox.Objects.Room("a2a5696a-b767-41a7-ab9c-81c73a3539ae", "Room3", ""))
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
		Me.Schedule1.Selector.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
		Me.Schedule1.Selector.Appearance.FontSize = 10.0!
		Me.Schedule1.Selector.Appearance.NoFill = False
		Me.Schedule1.Size = New System.Drawing.Size(760, 296)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 8
		'
		'ContextMenu1
		'
		Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuTest})
		'
		'menuTest
		'
		Me.menuTest.Index = 0
		Me.menuTest.Text = "&Test"
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(760, 333)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.cmdConflictDisplay)
		Me.Controls.Add(Me.cmdReserved3)
		Me.Controls.Add(Me.cmdReserved2)
		Me.Controls.Add(Me.cmdReserved)
		Me.Controls.Add(Me.cmdClear)
		Me.Controls.Add(Me.cmdAddMany)
		Me.HelpButton = True
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "MainForm"
		Me.ResumeLayout(False)

	End Sub

#End Region

  Private StartDrawTime As Date

  Private ReadOnly OutOfRangeColor As Color = Color.FromArgb(&HFF, &HF4, &HBC)
  Private ReadOnly BackColorNormal As Color = Color.FromArgb(&HFF, &HFF, &HD5)
  Private ReadOnly BackColorMonth As Color = Color.White

  Private Sub XXX1()
    'Schedule1.AppointmentCollection(0).Alarm.IsArmed = False

    Dim room As Room = Schedule1.RoomCollection.Add("", "Room1")
    Schedule1.ColoredAreaCollection.Add("", Color.Blue, room)

    Dim settings As New PrintDialogSettings(#1/1/2004#, #8:00:00 AM#, #1/5/2004#, #6:00:00 PM#)
    Schedule1.GoPrint(settings)

    Schedule1.AppointmentCollection.Clear()
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.Subject = "John Doe"

    Schedule1.AppointmentCollection.RemoveAt(5)
    Schedule1.AppointmentCollection.Remove(appointment)
    Schedule1.AppointmentCollection.Remove("abc123")

    Schedule1.Dialogs.ShowPropertyDialog(appointment)
    Schedule1.Dialogs.ShowCategoryDialog(appointment)
		Schedule1.Dialogs.ShowProviderDialog(appointment)

		'Dim appointment As Appointment
		'Dim dialogSettings As New AppointmentDialogSettings
		'dialogSettings.StartPosition = FormStartPosition.CenterScreen
		'dialogSettings.AllowCategory = False
		'dialogSettings.AllowNavigate = False

		'appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
		'Call Schedule1.Dialogs.ShowPropertyDialog(appointment)

		Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.All

		Dim list1 As Gravitybox.Objects.AppointmentList
		list1 = Schedule1.AppointmentCollection.Find(#1/1/2004#, #1/5/2004#)

		Dim list2 As Gravitybox.Objects.BaseList

		Dim list3 As Gravitybox.Objects.BaseList
		list3 = list1.Intersect(list2)

		Dim b As Boolean
		b = list1.IsAreaAvailable(#1/2/2004#, #10:00:00 AM#, 60)


		Dim proposed As Gravitybox.Objects.Appointment
    proposed = list1.NextAreaAvailable(#1/6/2004#, #8:00:00 AM#, 60, True)
		If Not (proposed Is Nothing) Then
			'Debug.WriteLine(proposed.StartDate)
			'Debug.WriteLine(proposed.StartTime)
			Schedule1.AppointmentCollection.Add(proposed)
		End If

		''Add an appointment
		'Dim appointment As Appointment
		'appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 60)
		'appointment.PropertyItemCollection.Add("", "OriginalLength", appointment.Length.ToString)

		''Compare the lengths and originals
		'Dim origLength As Integer
		'origLength = CType(appointment.PropertyItemCollection("OriginalLength").Setting, Integer)
		'If (origLength = appointment.Length) Then
		'  Call MsgBox("Length did NOT change.")
		'Else
		'  Call MsgBox("Length changed!")
		'End If

	End Sub

	Private Sub YYY()

		'Define lunchtime for every day
		Schedule1.NoDropAreaCollection.Add("", Color.Red, #12:00:00 PM#, 60)

		'Define surguries for 6/3/2004
		Schedule1.ColoredAreaCollection.Add("", Color.LightBlue, #6/3/2004#)

		Dim appointment As Appointment
		appointment = Schedule1.AppointmentCollection.Add("", #6/3/2004#, #8:00:00 AM#, 60)
		appointment.IconCollection.Add("", Schedule1.ScheduleIcons.IconInfo)

		Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
		Schedule1.TimeBar.Size = 5

		Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn
		Schedule1.AppointmentBar.Size = 5

		If False Then
			Dim list1 As BaseList
			Dim list2 As BaseList
			Dim list3 As BaseList
			list3 = list1.Union(list2)

			Schedule1.NoDropAreaCollection.Add("", Color.Red, #1/1/2004#, #11:00:00 AM#, 120)
			Dim b As Boolean = Schedule1.NoDropAreaCollection.ToList.IsOverlap(#1/1/2004#, #10:00:00 AM#, 70)
		End If

	End Sub

	Private Sub xpxp()


		'On Error Resume Next
		Dim appointment As Appointment
		Dim categoryID As String
		Dim providerID As String

		For Each appointment In Schedule1.AppointmentCollection
			If appointment.CategoryList.Count > 0 Then
				categoryID = appointment.CategoryList(0).Key
			End If

			If appointment.ProviderList.Count > 0 Then
				providerID = appointment.ProviderList(0).Key
			End If

			Dim sSql As String = "INSERT INTO tblschedule (StartDate, StartTime, Length, Description," & _
			 "RoomID, CategoryID, ProviderID) values (" & _
			 Format(appointment.StartDate, "yyyymmdd") & "," & _
			 Format(appointment.StartTime, "hhmmss") & "," & appointment.Length & ",'" & appointment.Text & "','" & _
			 appointment.Room.Key & "','" & categoryID & "','" & providerID & "')"

		Next

	End Sub

	Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Schedule1.AutoRedraw = False
		Try

			Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
			Schedule1.SetMinMaxDate(Now, Now.AddDays(5))
			Schedule1.Appearance.BackColor = Color.LightBlue

			Schedule1.StartTime = #8:00:00 AM#
			Schedule1.DayLength = 10

			'Appearance
			Schedule1.Appearance.BackColor2 = Color.LightBlue
			Schedule1.Appearance.BackGradientStyle = GradientStyleConstants.None
			Schedule1.ColumnHeader.Appearance.BackColor = Color.LightGray
			Schedule1.ColumnHeader.Appearance.BackColor2 = Color.White
			Schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
			Schedule1.ColumnHeader.Appearance.StringFormatFlags = StringFormatFlags.NoWrap
			Schedule1.ColumnHeader.Appearance.TextTrimming = StringTrimming.EllipsisCharacter
			Schedule1.RowHeader.Appearance.BackColor = Color.LightGray
			Schedule1.RowHeader.Appearance.BackColor2 = Color.White
			Schedule1.RowHeader.Appearance.BackGradientStyle = GradientStyleConstants.Horizontal

			Schedule1.EventHeader.AllowHeader = True
			Schedule1.EventHeader.Appearance.BackColor = Color.White
			Schedule1.EventHeader.Appearance.BackColor2 = Color.LightBlue
			Schedule1.EventHeader.Appearance.BackGradientStyle = GradientStyleConstants.Horizontal

			Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock24
			Schedule1.RoomCollection.Clear()
			Dim room1 As Gravitybox.Objects.Room = Schedule1.RoomCollection.Add("", "Room 1")
			Dim room2 As Gravitybox.Objects.Room = Schedule1.RoomCollection.Add("", "Room 2")

			Schedule1.CategoryCollection.Add("", "Category I")
			Schedule1.CategoryCollection.Add("", "Category II")
			Schedule1.ProviderCollection.Add("", "Provider 1")
			Schedule1.ProviderCollection.Add("", "Provider 2")

		Catch ex As Exception
			MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error")
		Finally
			Schedule1.AutoRedraw = True
		End Try

		Schedule1.AllowRemove = False

	End Sub

	Private Sub ClientTest1()

		Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
		Schedule1.SetMinMaxDate(Now, Now.AddDays(5))
		Schedule1.ColumnHeader.AutoFit = True
		Schedule1.Appearance.BackColor = Color.LightBlue
		Schedule1.AllowInPlaceEdit = True

		'Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #10:00:00 AM#, 2900)
		Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #10:00:00 AM#, 120)
		appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Subject = "My Subject"
		appointment.ToolTipText = "My Tooltip"
		appointment.Appearance.BackColor = Color.LightBlue

	End Sub

	Private Sub CreateMultiDayAppointment()

		Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #10:00:00 AM#, 1500)
		appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Subject = "My Subject"
		appointment.ToolTipText = "My Tooltip"
		appointment.Appearance.BackColor = Color.LightBlue

	End Sub

	Private Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)

		If Schedule1.AppointmentCollection.Count > 0 Then
			Dim s As String = Schedule1.AppointmentCollection(0).ToXML
			'System.Diagnostics.Debug.Write(s)
		End If

	End Sub

	Private Sub OnRefresh2(ByVal sender As Object, ByVal e As System.EventArgs)
		'System.Diagnostics.Debug.Write("YYY")
	End Sub

	Private Sub ProviderCheck()

		Schedule1.SetMinMaxDate(Today, Today.AddDays(5))
		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10
		Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft

		Schedule1.ProviderCollection.Clear()
		Dim prov1 As Provider = Schedule1.ProviderCollection.Add("", "Provider 1")
		Dim prov2 As Provider = Schedule1.ProviderCollection.Add("", "Provider 2")

		Dim appointment As Appointment
		Schedule1.AppointmentCollection.Clear()

		appointment = Schedule1.AppointmentCollection.Add("", Today, #9:00:00 AM#, 60)
		appointment.ProviderList.Add(prov1)

		appointment = Schedule1.AppointmentCollection.Add("", Today, #11:00:00 AM#, 60)
		appointment.ProviderList.Add(prov1)
		appointment.ProviderList.Add(prov2)

		appointment = Schedule1.AppointmentCollection.Add("", Today, #1:00:00 PM#, 60)
		appointment.ProviderList.Add(prov2)

		appointment = Schedule1.AppointmentCollection.Add("", Today, #3:00:00 PM#, 60)

		Dim st As Date = #7:30:00 AM#
		For ii As Integer = 1 To 4
			'schedule1.Availability.
		Next

	End Sub

	Private Sub xxyy()

		Schedule1.SetMinMaxDate(#1/1/2004#, #12/31/2004#)
		Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
		Schedule1.ColumnHeader.AutoFit = True
		Schedule1.ColumnHeader.FrameIncrement = 7

	End Sub

	Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClear.Click
		Schedule1.AppointmentCollection.Clear()
	End Sub

	Private Sub cmdAddMany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAddMany.Click
		For ii As Integer = 1 To 400
			Schedule1.AppointmentCollection.Add("", Now.AddDays(ii), #1:00:00 PM#, 60)
		Next
	End Sub

	Function FindHiddenAppointments() As Integer
		Dim BeforeFirstHour As AppointmentList
		BeforeFirstHour = Schedule1.AppointmentCollection.Find(Date.Parse(Today & " " & "00:00:00"), Date.Parse(Today & " " & Schedule1.StartTime))
		If BeforeFirstHour.Count > 0 Then
		End If

	End Function

	Private Sub cmdReserved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReserved.Click

		Schedule1.SetMinMaxDate(#1/1/2004#, #6/30/2004#)
		Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10
		Schedule1.AppointmentTimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
		Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
		Schedule1.RowHeader.Size = 20
		Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock24

		Schedule1.RoomCollection.Clear()
		Schedule1.AppointmentCollection.Clear()
		Schedule1.CategoryCollection.Clear()
		Schedule1.ProviderCollection.Clear()

		Schedule1.AutoRedraw = False

		Dim startTime As Date = Now
		For ii As Integer = 1 To 100
			Dim appointment As Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(ii), #9:00:00 AM#, 60)
			appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(ii), #11:00:00 AM#, 60)
		Next
		Dim endTime As Date = Now
		Debug.WriteLine(endTime.Subtract(startTime).TotalMilliseconds.ToString)

		Schedule1.AutoRedraw = True

	End Sub

	Private Sub cmdReserved2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReserved2.Click

		Dim ds As New ScheduleDataset

		ds.APPOINTMENT.Columns("start_date").AllowDBNull = False
		ds.APPOINTMENT.Columns("start_time").AllowDBNull = False
		ds.APPOINTMENT.Columns("length").AllowDBNull = False

		ds.APPOINTMENT.AddAPPOINTMENTRow("abc123", Schedule1.MinDate, #9:00:00 AM#, 120, "MySubject", "Some Text", "31728")
		Schedule1.DataSource = ds
		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10

		If Schedule1.AppointmentCollection.Count > 0 Then
			If Schedule1.AppointmentCollection(0).PropertyItemCollection.Count > 0 Then
				Dim key As String = Schedule1.AppointmentCollection(0).PropertyItemCollection(0).Key
				Dim setting As String = Schedule1.AppointmentCollection(0).PropertyItemCollection(0).Setting
				Dim text As String = Schedule1.AppointmentCollection(0).PropertyItemCollection(0).Text

				Schedule1.AppointmentCollection(0).PropertyItemCollection("zip").Setting = "30005"

				Dim newZip As String = CType(ds.APPOINTMENT.Rows(0)("zip"), String)
				Debug.WriteLine(newZip)

			End If
		End If

	End Sub

	Private Sub Reserved2(ByVal room As Room)

		'8/24
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:15:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 45)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:45:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:15:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:45:00 AM#, 15)

	End Sub

	Private Sub Reserved2_XXX(ByVal room As Room)

		'8/24
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #8:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:15:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/24/2003#, room, #9:45:00 AM#, 45)

		'8/25
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #8:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:15:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:30:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:45:00 AM#, 30)
		Schedule1.AppointmentCollection.Add("", #8/25/2003#, room, #9:45:00 AM#, 15)

	End Sub

	Private Sub Reserved3(ByVal room As Room)

		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #8:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #8:15:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #8:30:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #8:45:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #9:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #8:00:00 AM#, 45)

		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #11:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #11:00:00 AM#, 15)
		Schedule1.AppointmentCollection.Add("", #8/18/2003#, room, #11:00:00 AM#, 15)

		For ii As Integer = 1 To Schedule1.AppointmentCollection.Count
			Schedule1.AppointmentCollection(ii - 1).Subject = ii.ToString
			Schedule1.AppointmentCollection(ii - 1).Appearance.Transparency = 50
		Next

	End Sub

	Private Sub cmdReserved3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReserved3.Click

		Dim dialogSettings As New Gravitybox.Objects.AlarmDialogSettings
		dialogSettings.OkButtonText = "&DISMISS"
		dialogSettings.LocationHeaderText = "&LOCATION"
		dialogSettings.OpenButtonText = "&OPEN"
		dialogSettings.CancelButtonText = "&SNOOZE"
		dialogSettings.SnoozeText = "Yo look at this:"
		dialogSettings.WindowText = "Hello Window"
		'dialogSettings.DialogStyle = DialogStyleConstants.InfoBox
		dialogSettings.TimeSettings.MinuteTextSingular = "snail"
		dialogSettings.TimeSettings.MinuteTextPlural = "snails"
		Schedule1.Dialogs.ShowAlarmDialog(Schedule1.AppointmentCollection(0), dialogSettings)

	End Sub

	Private Sub cmdConflictDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConflictDisplay.Click

		Select Case Schedule1.ConflictDisplay
			Case Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap
				Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
			Case Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
				Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
			Case Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
				Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap
		End Select

	End Sub

	Private Sub ShowICAL()

		'Create "iCal" look-and-feel
		Dim F As New EffectsForm
		Dim appointment As Appointment

    'Initialize Schedule
    F.Schedule1.Appearance.BackColor = BackColorNormal
    F.Schedule1.Appearance.ForeColor = Color.FromArgb(&HF6, &HDB, &HA2)
    F.Schedule1.Font = New Font("Verdana", 8)

    F.Schedule1.Selector.Appearance.BackColor = Color.FromArgb(&H84, &H92, &HB4)

    F.Schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(&HF2, &HF1, &HE1)
    F.Schedule1.ColumnHeader.Appearance.BackColor2 = Color.FromArgb(&HD5, &HD1, &HCA)
    F.Schedule1.ColumnHeader.Appearance.FontSize = 8
    F.Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
    F.Schedule1.ColumnHeader.AutoFit = True

    F.Schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(&HF2, &HF1, &HE1)
    F.Schedule1.RowHeader.Appearance.BackColor2 = Color.FromArgb(&HD5, &HD1, &HCA)
    F.Schedule1.RowHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
    F.Schedule1.RowHeader.Appearance.FontSize = 8
    F.Schedule1.RowHeader.Size = 20

    F.Schedule1.AllowSelector = False
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    F.Schedule1.StartTime = #12:00:00 AM#
    F.Schedule1.DayLength = 24
		F.Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
		F.Schedule1.AppointmentSpace = 0
    F.Schedule1.EventHeader.AllowHeader = True
    F.Schedule1.EventHeader.AllowExpand = True
    F.Schedule1.Visibility.ShowTime(#6:00:00 AM#)

		'Add Appointments
		appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:30:00 AM#, 60)
		appointment.Subject = "Weekly Staff Meeting"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
		appointment.Header.Appearance.ForeColor = appointment.Appearance.ForeColor
		appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
		appointment.Header.Appearance.AllowBreak = False

    'Colored Areas
    Me.SetupColoredAreas(F.Schedule1)

    '******************************************************
    'Create the appointments
    appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:30:00 AM#, 60)
		appointment.Subject = "Lunch with Jill"
		appointment.Appearance.BackColor = Color.LightGreen
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Green
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
		appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
		appointment.Header.Appearance.ForeColor = appointment.Appearance.ForeColor
		appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
		appointment.Header.Appearance.AllowBreak = False
    'appointment.Header.Icon = F.Schedule1.DefaultIcons.IconInfo

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:00:00 AM#, 90)
		appointment.Subject = "Dentist Appt"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Blue
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = False
    appointment.Header.Icon = F.Schedule1.DefaultIcons.IconInfo

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/2/2004#, #10:30:00 AM#, 90)
		appointment.Subject = "Joan Dentist Appt"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Blue
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = False

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:00:00 AM#, 120)
		appointment.Subject = "Follow-up with Susan"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Blue
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = False
    'appointment.Header.Icon = F.Schedule1.DefaultIcons.IconInfo

    appointment = F.Schedule1.AppointmentCollection.Add("", #1/3/2004#, #11:30:00 AM#, 60)
    appointment.Subject = "John B-Day"
    appointment.IsEvent = True
    appointment.Appearance.BackColor = Color.White
    appointment.Appearance.Transparency = 0
    appointment.Appearance.BorderColor = Color.Black
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Green
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = False

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:00:00 AM#, 90)
		appointment.Subject = "5k Heart Run"
		appointment.Appearance.BackColor = Color.LightPink
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Black
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Red
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = True

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/4/2004#, #8:30:00 AM#, 90)
		appointment.Subject = "YMCA with Becky"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = Color.Blue
		appointment.Header.Appearance.ForeColor = Color.White
		appointment.Header.Appearance.Transparency = 0
		appointment.Header.Appearance.AllowBreak = False

		appointment = F.Schedule1.AppointmentCollection.Add("", #1/4/2004#, #11:00:00 AM#, 60)
		appointment.Subject = "Sunday Lunch"
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.Transparency = 30
		appointment.Appearance.BorderColor = Color.Blue
		appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
		appointment.Appearance.IsRound = True
		appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
		appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
		appointment.Header.Appearance.ForeColor = appointment.Appearance.ForeColor
		appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
		appointment.Header.Appearance.AllowBreak = False

		'Show the screen
    Call F.ShowDialog()

  End Sub

  Private Sub SetupColoredAreas(ByVal schedule As Gravitybox.Controls.Schedule)

    Try
      Dim area As ScheduleArea
      area = schedule.ColoredAreaCollection.Add("", OutOfRangeColor, #12:00:00 AM#, 480)
      area = schedule.ColoredAreaCollection.Add("", OutOfRangeColor, #5:00:00 PM#, 420)

      'Setup each area's properties
      For Each area In schedule.ColoredAreaCollection
        area.Appearance.BorderWidth = 0
        area.Appearance.ForeColor = Color.LightGray
        area.Appearance.Alignment = StringAlignment.Center
        area.Appearance.TextVAlign = StringAlignment.Center
        area.Text = "Out Of Range"
      Next
    Catch ex As Exception
      MsgBox(ex)
    End Try

  End Sub

  Private Sub AddScheme(ByVal apptBackColor As Color, ByVal apptForeColor As Color, ByVal headerBackColor As Color, ByVal headerForeColor As Color)

    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10

    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.MultiSelect = True
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider

    Call Schedule1.ProviderCollection.Add("", "Provider I", Color.Yellow)
    Call Schedule1.ProviderCollection.Add("", "Provider II", Color.Red)

    Call Schedule1.CategoryCollection.Add("", "Category I", Color.Yellow)
    Call Schedule1.CategoryCollection.Add("", "Category II", Color.Red)

    Call Schedule1.RoomCollection.Add("", "Room I")
    Call Schedule1.RoomCollection.Add("", "Room II")

    Call LoadSet5()





    Dim appointment As Appointment
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 90)
    appointment.Subject = "Appointment 1"

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 120)
    appointment.Subject = "Appointment 2"

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:00:00 AM#, 90)
    appointment.Subject = "Appointment 3"

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #10:00:00 AM#, 90)
    appointment.Subject = "Appointment 4"

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #9:30:00 AM#, 150)
    appointment.Subject = "Appointment 5"

    'Background 40% transparent
    'Appointment color white
    'Appointment is round
    'Header NOT transparent
    'Header Font White
    'Header Info Icon
    'Header has line below (break)
    'Header shows time
    For Each appointment In Schedule1.AppointmentCollection
      appointment.Appearance.BackColor = apptBackColor
      appointment.Appearance.ForeColor = apptForeColor
      appointment.Appearance.Transparency = 40
      appointment.Appearance.IsRound = True
      appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
      appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
      appointment.Header.Appearance.Transparency = 0
      appointment.Header.Appearance.AllowBreak = True
      appointment.Header.Appearance.BackColor = headerBackColor
      appointment.Header.Appearance.ForeColor = headerForeColor
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Sub LoadSet5()

    Const Transparency As Integer = 40
    Dim appointment As Appointment

    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Call Schedule1.AppointmentCollection.Clear()

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #8:00:00 AM#, 120)
    appointment.Subject = "Appointment 1"
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightBlue
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:00:00 AM#, 120)
    appointment.Subject = "Appointment 2"
    appointment.Appearance.BackColor = Color.LightCoral
    appointment.Appearance.Transparency = Transparency
    appointment.Header.Appearance.AllowBreak = True
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/4/2004#, #9:30:00 AM#, 60)
    appointment.Subject = "Appointment 3"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightCyan
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #12:30:00 PM#, 60)
    appointment.Subject = "Appointment 4"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGoldenrodYellow
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/5/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "Appointment 5"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.IsRound = True
    appointment.Appearance.BackColor = Color.LightGray
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.DateHeader
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #1:30:00 PM#, 60)
    appointment.Subject = "Appointment 6"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text
    appointment.Header.Text = "Custom"
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #8:30:00 AM#, 90)
    appointment.Subject = "Appointment 7"
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightPink
    appointment.Header.Appearance.Transparency = 0

    appointment = Schedule1.AppointmentCollection.Add("", #1/4/2004#, #11:30:00 AM#, 90)
    appointment.Subject = "Appointment 8"
    appointment.Appearance.IsRound = True
    appointment.Appearance.Transparency = Transparency
    appointment.Appearance.BackColor = Color.LightSeaGreen
    appointment.Header.Appearance.Transparency = 0
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None

    Call Schedule1.Refresh()

  End Sub

  Private Sub ShowAppointments()

    Dim msg As String
    msg += "Schedule1" & vbCrLf
    msg += "Appointment Count: " & Schedule1.AppointmentCollection.Count.ToString & vbCrLf
    If Schedule1.AppointmentCollection.Count = 1 Then
      msg += "Appointment1: " & vbCrLf
      msg += "StartDate: " & Schedule1.AppointmentCollection(0).StartDate.ToShortDateString & vbCrLf
      msg += "StartTime: " & Schedule1.AppointmentCollection(0).StartTime.ToShortTimeString & vbCrLf
    End If
    msg += vbCrLf

    Call MsgBox(msg, MsgBoxStyle.Information)

  End Sub

  Private Sub Schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs) Handles Schedule1.BeforePropertyDialog
    e.DialogSettings.WindowText = "Custom Text"
  End Sub

  Private Sub Schedule1_BeforeCategoryConfigurationDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs) Handles Schedule1.BeforeCategoryConfigurationDialog
    e.DialogSettings.FormBorderStyle = FormBorderStyle.SizableToolWindow
  End Sub

	Private Sub Schedule1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Schedule1.MouseDown

		'ContextMenu1.Show(Schedule1, New Point(e.X, e.Y))

	End Sub

End Class
