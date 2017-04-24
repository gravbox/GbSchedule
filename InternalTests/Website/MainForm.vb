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
  Friend WithEvents cmdDayTopTimeLeft As System.Windows.Forms.Button
  Friend WithEvents cmdDayRoomTopTimeLeft As System.Windows.Forms.Button
  Friend WithEvents cmdRoomTopTimeLeft As System.Windows.Forms.Button
  Friend WithEvents cmdProviderTopTimeLeft As System.Windows.Forms.Button
  Friend WithEvents cmdXP1 As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdDayTopTimeLeft = New System.Windows.Forms.Button
    Me.cmdDayRoomTopTimeLeft = New System.Windows.Forms.Button
    Me.cmdRoomTopTimeLeft = New System.Windows.Forms.Button
    Me.cmdProviderTopTimeLeft = New System.Windows.Forms.Button
    Me.cmdXP1 = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.SuspendLayout()
    '
    'cmdDayTopTimeLeft
    '
    Me.cmdDayTopTimeLeft.Location = New System.Drawing.Point(8, 8)
    Me.cmdDayTopTimeLeft.Name = "cmdDayTopTimeLeft"
    Me.cmdDayTopTimeLeft.Size = New System.Drawing.Size(192, 24)
    Me.cmdDayTopTimeLeft.TabIndex = 0
    Me.cmdDayTopTimeLeft.Text = "DayTopTimeLeft"
    '
    'cmdDayRoomTopTimeLeft
    '
    Me.cmdDayRoomTopTimeLeft.Location = New System.Drawing.Point(8, 40)
    Me.cmdDayRoomTopTimeLeft.Name = "cmdDayRoomTopTimeLeft"
    Me.cmdDayRoomTopTimeLeft.Size = New System.Drawing.Size(192, 24)
    Me.cmdDayRoomTopTimeLeft.TabIndex = 1
    Me.cmdDayRoomTopTimeLeft.Text = "DayRoomTopTimeLeft"
    '
    'cmdRoomTopTimeLeft
    '
    Me.cmdRoomTopTimeLeft.Location = New System.Drawing.Point(8, 72)
    Me.cmdRoomTopTimeLeft.Name = "cmdRoomTopTimeLeft"
    Me.cmdRoomTopTimeLeft.Size = New System.Drawing.Size(192, 24)
    Me.cmdRoomTopTimeLeft.TabIndex = 2
    Me.cmdRoomTopTimeLeft.Text = "RoomTopTimeLeft"
    '
    'cmdProviderTopTimeLeft
    '
    Me.cmdProviderTopTimeLeft.Location = New System.Drawing.Point(8, 104)
    Me.cmdProviderTopTimeLeft.Name = "cmdProviderTopTimeLeft"
    Me.cmdProviderTopTimeLeft.Size = New System.Drawing.Size(192, 24)
    Me.cmdProviderTopTimeLeft.TabIndex = 3
    Me.cmdProviderTopTimeLeft.Text = "ProviderTopTimeLeft"
    '
    'cmdXP1
    '
    Me.cmdXP1.Location = New System.Drawing.Point(8, 136)
    Me.cmdXP1.Name = "cmdXP1"
    Me.cmdXP1.Size = New System.Drawing.Size(192, 24)
    Me.cmdXP1.TabIndex = 4
    Me.cmdXP1.Text = "XP - 1"
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.Color.PaleVioletRed
    Me.Panel1.Location = New System.Drawing.Point(40, 184)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(72, 40)
    Me.Panel1.TabIndex = 5
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(208, 245)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.cmdXP1)
    Me.Controls.Add(Me.cmdProviderTopTimeLeft)
    Me.Controls.Add(Me.cmdRoomTopTimeLeft)
    Me.Controls.Add(Me.cmdDayRoomTopTimeLeft)
    Me.Controls.Add(Me.cmdDayTopTimeLeft)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Main Form"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Control Methods"

  Private Sub cmdDayTopTimeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDayTopTimeLeft.Click

    Dim F As New Form1
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    F.Schedule1.StartTime = #8:00:00 AM#
    F.Schedule1.DayLength = 10
    F.Schedule1.RowHeader.Size = 20
    F.Schedule1.AllowSelector = False
    F.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    Call AddAppointments(F.Schedule1)

    'Show screen
    Call F.ShowDialog()

  End Sub

  Private Sub cmdDayRoomTopTimeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDayRoomTopTimeLeft.Click

    Dim F As New Form1
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    F.Schedule1.StartTime = #8:00:00 AM#
    F.Schedule1.DayLength = 10
    F.Schedule1.RowHeader.Size = 20
    F.Schedule1.ColumnHeader.Size = 75
    F.Schedule1.AllowSelector = False
    F.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    Call AddAppointments(F.Schedule1)

    'Show screen
    Call F.ShowDialog()

  End Sub

  Private Sub cmdRoomTopTimeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRoomTopTimeLeft.Click

    Dim F As New Form1
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    F.Schedule1.StartTime = #8:00:00 AM#
    F.Schedule1.DayLength = 10
    F.Schedule1.RowHeader.Size = 20
    F.Schedule1.ColumnHeader.Size = 150
    F.Schedule1.AllowSelector = False
    F.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    Call AddAppointments(F.Schedule1)

    'Show screen
    Call F.ShowDialog()

  End Sub

  Private Sub cmdProviderTopTimeLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProviderTopTimeLeft.Click

    Dim F As New Form1
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    F.Schedule1.StartTime = #8:00:00 AM#
    F.Schedule1.DayLength = 10
    F.Schedule1.RowHeader.Size = 20
    F.Schedule1.ColumnHeader.Size = 100
    F.Schedule1.AllowSelector = False
    F.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    Call AddAppointments(F.Schedule1)

    'Show screen
    Call F.ShowDialog()

  End Sub

  Private Sub AddAppointments(ByVal sch As Gravitybox.Controls.Schedule)

    'Add Categories
    Call sch.CategoryCollection.Add("", "Category1", Color.Blue)
    Call sch.CategoryCollection.Add("", "Category2", Color.Yellow)
    Call sch.CategoryCollection.Add("", "Category3", Color.Red)

    'Add Providers
    Call sch.ProviderCollection.Add("", "Provider1", Color.Blue)
    Call sch.ProviderCollection.Add("", "Provider2", Color.Yellow)
    Call sch.ProviderCollection.Add("", "Provider3", Color.Red)

    'Add Rooms
    Call sch.RoomCollection.Add("", "Room1")
    Call sch.RoomCollection.Add("", "Room2")

    'Add Appointments
    Dim appointment As Appointment
    appointment = sch.AppointmentCollection.Add("", #1/1/2004#, sch.RoomCollection(0), #8:30:00 AM#, 150)
    appointment.Subject = "John Doe"
    Call appointment.CategoryList.Add(sch.CategoryCollection(0))
    Call appointment.ProviderList.Add(sch.ProviderCollection(0))

    appointment = sch.AppointmentCollection.Add("", #1/2/2004#, sch.RoomCollection(1), #10:30:00 AM#, 120)
    appointment.Subject = "Suzy Collins"
    Call appointment.CategoryList.Add(sch.CategoryCollection(1))
    Call appointment.ProviderList.Add(sch.ProviderCollection(1))

    appointment = sch.AppointmentCollection.Add("", #1/3/2004#, sch.RoomCollection(0), #9:30:00 AM#, 120)
    appointment.Subject = "Jeff Johnson"
    Call appointment.CategoryList.Add(sch.CategoryCollection(2))
    Call appointment.ProviderList.Add(sch.ProviderCollection(2))

  End Sub

  Private Sub cmdXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXP1.Click

    Const THEDATE As Date = #1/12/2004#
    Dim COLOR1 As Color = Color.FromArgb(&HF7, &HEF, &HD6)
    Dim COLOR2 As Color = Color.FromArgb(&HC6, &HD7, &HDE)
    Dim TEXTCOLOR1 As Color = Color.SandyBrown 'Color.FromArgb(&HC6, &HAE, &H7B)
    Dim GRIDCOLOR As Color = Color.FromArgb(&HDE, &HE3, &HBD)

    Dim F As New XPForm
    F.Size = New Size(430, 380)
    F.Schedule1.SetMinMaxDate(THEDATE, THEDATE)
    Dim room1 As Gravitybox.Objects.Room = F.Schedule1.RoomCollection.Add("", "Mr. Steven Right")
    Dim room2 As Gravitybox.Objects.Room = F.Schedule1.RoomCollection.Add("", "Mr. Micheal Hopkins")
    Dim provider1 As Gravitybox.Objects.Provider = F.Schedule1.ProviderCollection.Add("", "Provider1")
    Dim provider2 As Gravitybox.Objects.Provider = F.Schedule1.ProviderCollection.Add("", "Provider2")
    F.Schedule1.StartTime = #12:00:00 AM#
    F.Schedule1.DayLength = 24
    F.Schedule1.RowHeader.Size = 20
    F.Schedule1.ColumnHeader.AutoFit = True
    F.Schedule1.AllowSelector = True
    F.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None
    F.Schedule1.Visibility.ShowTime(#9:00:00 AM#)
    F.Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider
    F.Schedule1.AppointmentBar.Size = 5

    '********************************
    'Selector
    F.Schedule1.Selector.Appearance.BackColor = Color.PaleVioletRed
    F.Schedule1.Selector.Appearance.BorderWidth = 0

    '********************************
    'Setup colors
    F.Schedule1.ColumnHeader.Appearance.BackColor = Color.White
    F.Schedule1.ColumnHeader.Appearance.BackColor2 = Color.Bisque 'Color.FromArgb(&HE7, &HEF, &HE7)
    F.Schedule1.ColumnHeader.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
    F.Schedule1.ColumnHeader.Appearance.FontSize = 8

    F.Schedule1.RowHeader.Appearance.BackColor = Color.White
    F.Schedule1.RowHeader.Appearance.BackColor2 = Color.Bisque 'Color.FromArgb(&HE7, &HEF, &HE7)
    F.Schedule1.RowHeader.Appearance.BackGradientStyle = GradientStyleConstants.Horizontal
    F.Schedule1.RowHeader.Appearance.FontSize = 8
    F.Schedule1.RowHeader.Size = 16

    F.Schedule1.Appearance.BackColor = Color.FromArgb(&HFF, &HFF, &HDE)
    F.Schedule1.Appearance.ForeColor = GRIDCOLOR

    '********************************
    'Setup colored areas
    Dim area As Gravitybox.Objects.ScheduleArea = F.Schedule1.ColoredAreaCollection.Add("", Color.LightGreen, #12:00:00 AM#, 480)
    area.Appearance.BorderWidth = 0
    area = F.Schedule1.ColoredAreaCollection.Add("", Color.LightGreen, #5:00:00 PM#, 560)
    area.Appearance.BorderWidth = 0

    '********************************
    'Drraw Appointments
    Dim appointment As Gravitybox.Objects.Appointment

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #12:00:00 PM#, 60)
    appointment.IsEvent = True
    appointment.Subject = "Meeting with Anne Dodsworth"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #9:30:00 AM#, 90)
    appointment.Subject = "Call to Customer"
    appointment.Appearance.BackColor = COLOR2
    appointment.IconCollection.Add("", F.ImageList1.Images(1))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #10:30:00 AM#, 120)
    appointment.Subject = "Meeting with Micheal Suyama"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #1:30:00 PM#, 150)
    appointment.Subject = "Meeting with Nancy Davolio"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #1:30:00 PM#, 30)
    appointment.Subject = "Meeting with Matt Lords"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #2:30:00 PM#, 30)
    appointment.Subject = "Meeting with Reba Johnson"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room1, #3:30:00 PM#, 30)
    appointment.Subject = "Meeting with Anne Hawks"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room2, #9:30:00 AM#, 90)
    appointment.Subject = "Meeting with Steve Johns"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room2, #1:30:00 PM#, 90)
    appointment.Subject = "Meeting with Robert King"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room2, #1:30:00 PM#, 60)
    appointment.Subject = "Call to Customer"
    appointment.Appearance.BackColor = COLOR2
    appointment.IconCollection.Add("", F.ImageList1.Images(1))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room2, #3:30:00 PM#, 30)
    appointment.Subject = "Meeting with Laura Callahan"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    appointment = F.Schedule1.AppointmentCollection.Add("", THEDATE, room2, #4:30:00 PM#, 60)
    appointment.Subject = "Meeting with Nancy Highsmith"
    appointment.Appearance.BackColor = COLOR1
    appointment.Appearance.ForeColor = TEXTCOLOR1
    appointment.IconCollection.Add("", F.ImageList1.Images(0))

    For Each appointment In F.Schedule1.AppointmentCollection
      appointment.Appearance.BorderColor = Color.PaleVioletRed 'GRIDCOLOR
      appointment.Appearance.FontSize = 8
      appointment.Appearance.FontUnit = GraphicsUnit.Point
      appointment.ProviderList.Add(provider1)
    Next

    F.Schedule1.Selector.Column = 1
    F.Schedule1.Selector.Row = 24

    'Show screen
    Call F.ShowDialog()

  End Sub

#End Region

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim F As New Form1
    F.Schedule1.AutoRedraw = False
    Dim a As Appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    F.Schedule1.AutoRedraw = True

  End Sub

End Class
