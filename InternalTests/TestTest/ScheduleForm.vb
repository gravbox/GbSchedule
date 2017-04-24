Option Strict On
Option Explicit On 

Imports Gravitybox.Objects

Public Class ScheduleForm
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
  Friend WithEvents cmdView As System.Windows.Forms.Button
  Friend WithEvents cmdScrollbars As System.Windows.Forms.Button
  Friend WithEvents cmdRemove As System.Windows.Forms.Button
  Friend WithEvents cmdShow As System.Windows.Forms.Button
  Friend WithEvents cmdPList As System.Windows.Forms.Button
  Friend WithEvents cmdCList As System.Windows.Forms.Button
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileClear As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileLoad As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFileSave As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFilePrint As System.Windows.Forms.MenuItem
  Friend WithEvents mnuFilePrintPreview As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents cmdFree As System.Windows.Forms.Button
  Friend WithEvents cmdToFile As System.Windows.Forms.Button
  Friend WithEvents cmdFromFile As System.Windows.Forms.Button
  Friend WithEvents cmdEffects As System.Windows.Forms.Button
  Friend WithEvents cmdReserved As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ScheduleForm))
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cmdReserved = New System.Windows.Forms.Button
    Me.cmdEffects = New System.Windows.Forms.Button
    Me.cmdFromFile = New System.Windows.Forms.Button
    Me.cmdToFile = New System.Windows.Forms.Button
    Me.cmdFree = New System.Windows.Forms.Button
    Me.cmdCList = New System.Windows.Forms.Button
    Me.cmdShow = New System.Windows.Forms.Button
    Me.cmdRemove = New System.Windows.Forms.Button
    Me.cmdPList = New System.Windows.Forms.Button
    Me.cmdScrollbars = New System.Windows.Forms.Button
    Me.cmdView = New System.Windows.Forms.Button
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.mnuFile = New System.Windows.Forms.MenuItem
    Me.mnuFileClear = New System.Windows.Forms.MenuItem
    Me.mnuFileLoad = New System.Windows.Forms.MenuItem
    Me.mnuFileSave = New System.Windows.Forms.MenuItem
    Me.MenuItem4 = New System.Windows.Forms.MenuItem
    Me.mnuFilePrint = New System.Windows.Forms.MenuItem
    Me.mnuFilePrintPreview = New System.Windows.Forms.MenuItem
    Me.MenuItem1 = New System.Windows.Forms.MenuItem
    Me.mnuFileExit = New System.Windows.Forms.MenuItem
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.cmdReserved)
    Me.Panel1.Controls.Add(Me.cmdEffects)
    Me.Panel1.Controls.Add(Me.cmdFromFile)
    Me.Panel1.Controls.Add(Me.cmdToFile)
    Me.Panel1.Controls.Add(Me.cmdFree)
    Me.Panel1.Controls.Add(Me.cmdCList)
    Me.Panel1.Controls.Add(Me.cmdShow)
    Me.Panel1.Controls.Add(Me.cmdRemove)
    Me.Panel1.Controls.Add(Me.cmdPList)
    Me.Panel1.Controls.Add(Me.cmdScrollbars)
    Me.Panel1.Controls.Add(Me.cmdView)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 289)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(744, 24)
    Me.Panel1.TabIndex = 1
    '
    'cmdReserved
    '
    Me.cmdReserved.Location = New System.Drawing.Point(672, 0)
    Me.cmdReserved.Name = "cmdReserved"
    Me.cmdReserved.Size = New System.Drawing.Size(64, 24)
    Me.cmdReserved.TabIndex = 10
    Me.cmdReserved.Text = "Reserved"
    '
    'cmdEffects
    '
    Me.cmdEffects.Location = New System.Drawing.Point(608, 0)
    Me.cmdEffects.Name = "cmdEffects"
    Me.cmdEffects.Size = New System.Drawing.Size(64, 24)
    Me.cmdEffects.TabIndex = 9
    Me.cmdEffects.Text = "Effects"
    '
    'cmdFromFile
    '
    Me.cmdFromFile.Location = New System.Drawing.Point(544, 0)
    Me.cmdFromFile.Name = "cmdFromFile"
    Me.cmdFromFile.Size = New System.Drawing.Size(64, 24)
    Me.cmdFromFile.TabIndex = 8
    Me.cmdFromFile.Text = "FromFile"
    '
    'cmdToFile
    '
    Me.cmdToFile.Location = New System.Drawing.Point(480, 0)
    Me.cmdToFile.Name = "cmdToFile"
    Me.cmdToFile.Size = New System.Drawing.Size(64, 24)
    Me.cmdToFile.TabIndex = 7
    Me.cmdToFile.Text = "ToFile"
    '
    'cmdFree
    '
    Me.cmdFree.Location = New System.Drawing.Point(416, 0)
    Me.cmdFree.Name = "cmdFree"
    Me.cmdFree.Size = New System.Drawing.Size(64, 24)
    Me.cmdFree.TabIndex = 6
    Me.cmdFree.Text = "Free"
    '
    'cmdCList
    '
    Me.cmdCList.Location = New System.Drawing.Point(224, 0)
    Me.cmdCList.Name = "cmdCList"
    Me.cmdCList.Size = New System.Drawing.Size(64, 24)
    Me.cmdCList.TabIndex = 5
    Me.cmdCList.Text = "CList"
    '
    'cmdShow
    '
    Me.cmdShow.Location = New System.Drawing.Point(352, 0)
    Me.cmdShow.Name = "cmdShow"
    Me.cmdShow.Size = New System.Drawing.Size(64, 24)
    Me.cmdShow.TabIndex = 4
    Me.cmdShow.Text = "Show"
    '
    'cmdRemove
    '
    Me.cmdRemove.Location = New System.Drawing.Point(288, 0)
    Me.cmdRemove.Name = "cmdRemove"
    Me.cmdRemove.Size = New System.Drawing.Size(64, 24)
    Me.cmdRemove.TabIndex = 3
    Me.cmdRemove.Text = "Remove"
    '
    'cmdPList
    '
    Me.cmdPList.Location = New System.Drawing.Point(160, 0)
    Me.cmdPList.Name = "cmdPList"
    Me.cmdPList.Size = New System.Drawing.Size(64, 24)
    Me.cmdPList.TabIndex = 2
    Me.cmdPList.Text = "PList"
    '
    'cmdScrollbars
    '
    Me.cmdScrollbars.Location = New System.Drawing.Point(80, 0)
    Me.cmdScrollbars.Name = "cmdScrollbars"
    Me.cmdScrollbars.Size = New System.Drawing.Size(80, 24)
    Me.cmdScrollbars.TabIndex = 1
    Me.cmdScrollbars.Text = "Scrollbars"
    '
    'cmdView
    '
    Me.cmdView.Location = New System.Drawing.Point(0, 0)
    Me.cmdView.Name = "cmdView"
    Me.cmdView.Size = New System.Drawing.Size(80, 24)
    Me.cmdView.TabIndex = 0
    Me.cmdView.Text = "Viewmode"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
    '
    'mnuFile
    '
    Me.mnuFile.Index = 0
    Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileClear, Me.mnuFileLoad, Me.mnuFileSave, Me.MenuItem4, Me.mnuFilePrint, Me.mnuFilePrintPreview, Me.MenuItem1, Me.mnuFileExit})
    Me.mnuFile.Text = "&File"
    '
    'mnuFileClear
    '
    Me.mnuFileClear.Index = 0
    Me.mnuFileClear.Text = "&Clear"
    '
    'mnuFileLoad
    '
    Me.mnuFileLoad.Index = 1
    Me.mnuFileLoad.Text = "&Load"
    '
    'mnuFileSave
    '
    Me.mnuFileSave.Index = 2
    Me.mnuFileSave.Text = "&Save"
    '
    'MenuItem4
    '
    Me.MenuItem4.Index = 3
    Me.MenuItem4.Text = "-"
    '
    'mnuFilePrint
    '
    Me.mnuFilePrint.Index = 4
    Me.mnuFilePrint.Text = "&Print"
    '
    'mnuFilePrintPreview
    '
    Me.mnuFilePrintPreview.Index = 5
    Me.mnuFilePrintPreview.Text = "Print Pre&view"
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 6
    Me.MenuItem1.Text = "-"
    '
    'mnuFileExit
    '
    Me.mnuFileExit.Index = 7
    Me.mnuFileExit.Text = "E&xit"
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.BackColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.AllowResize = False
    Me.Schedule1.ColumnHeader.Appearance = CType(resources.GetObject("Schedule1.ColumnHeader.Appearance"), Gravitybox.Objects.AppointmentHeaderAppearance)
    Me.Schedule1.ColumnHeader.AutoFit = True
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 44
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Location = New System.Drawing.Point(16, 24)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.AllowResize = False
    Me.Schedule1.RowHeader.Appearance = CType(resources.GetObject("Schedule1.RowHeader.Appearance"), Gravitybox.Objects.AppointmentHeaderAppearance)
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 10
    Me.Schedule1.Size = New System.Drawing.Size(520, 256)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 1
    Me.Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn
    Me.Schedule1.TimeBar.Size = 6
    '
    'ScheduleForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(560, 313)
    Me.Controls.Add(Me.Schedule1)
    Me.Menu = Me.MainMenu1
    Me.Name = "ScheduleForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Schedule"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
    Schedule1.Location = New Point(0, 0)
    Schedule1.Size = New Size(Me.ClientSize.Width, Me.ClientSize.Height - Panel1.Height)
    'Schedule2.Location = New Point(Schedule1.Width, 0)
    'Schedule2.Size = New Size(Me.ClientSize.Width \ 2, Me.ClientSize.Height - Panel1.Height)
  End Sub

  Private Sub Schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
    'Dim FF As New HeaderForm()
    'Call FF.ShowDialog()
    'Call Me.Close()
    'Return
    'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

    'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
    'Call cmdEffects_Click(Me, New EventArgs())
    'Return
    'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

    Schedule1.SetMinMaxDate(#1/1/2004#, #12/31/2004#)


    Call Schedule1.Dialogs.ShowAboutDialog()

    Schedule1.GridBackColor = Color.White 'Color.Wheat
    Schedule1.GridForeColor = SystemColors.ControlDark

    Call Schedule1.RoomCollection.Add("", "Room1")
    Call Schedule1.RoomCollection.Add("", "Room2")
    Call Schedule1.RoomCollection.Add("", "Room3")
    Call Schedule1.RoomCollection.Add("", "Room4")

    Call Schedule1.ProviderCollection.Add("", "Provider1", Color.Blue)
    Call Schedule1.ProviderCollection.Add("", "Provider2", Color.Yellow)
    Call Schedule1.ProviderCollection.Add("", "Provider3", Color.Gray)
    Call Schedule1.ProviderCollection.Add("", "Provider4", Color.Red)

    Call Schedule1.CategoryCollection.Add("", "Category1", Color.DarkKhaki)
    Call Schedule1.CategoryCollection.Add("", "Category2", Color.LightCyan)
    Call Schedule1.CategoryCollection.Add("", "Category3", Color.ForestGreen)
    Call Schedule1.CategoryCollection.Add("", "Category4", Color.BlanchedAlmond)
    Call Schedule1.CategoryCollection.Add("", "Category5", Color.HotPink)
    Call Schedule1.CategoryCollection.Add("", "Category6", Color.Blue)

    Dim appointment As Gravitybox.Objects.Appointment
    'appointment = Schedule1.AppointmentCollection.Add("", #1/17/2003#, "2", #8:30:00 AM#, 60)
    'appointment.Subject = "Appointment I"
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(3))
    'Call appointment.CategoryCollection.Add(Schedule1.CategoryCollection(4))
    'appointment.Appearance.BackColor = Color.Yellow
    'appointment.Appearance.ForeColor = Color.Black
    'appointment.FontBold = True
    'appointment.FontItalics = True
    'appointment.FontStrikeout = True
    'appointment.FontUnderline = True
    'appointment.IsFlagged = True
    'appointment.Alarm.IsArmed = False
    'Call appointment.IconItems.Add(New Icon("C:\projects\Production\Schedule\Distrib_Icons\appt_mailcontact.ico"))
    'Call appointment.IconItems.Add(New Icon("C:\projects\Production\Schedule\Distrib_Icons\appt_note.ico"))
    'Call appointment.IconItems.Add(New Icon("C:\projects\Production\Schedule\Distrib_Icons\appt_organize.ico"))
    'Call appointment.IconItems.Add(New Icon("C:\projects\Production\Schedule\Distrib_Icons\appt_people.ico"))
    'Call appointment.IconItems.Add(New Icon("C:\projects\Production\Schedule\Distrib_Icons\appt_preview.ico"))


    '************************************************
    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "3", #10:00:00 AM#, 60)
    'appointment.IsEvent = True
    'appointment.Subject = "XXX"
    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, Schedule1.RoomCollection(2), #11:00:00 AM#, 1400)
    'appointment.IsEvent = False
    'appointment.Subject = "YYY"
    'appointment = Schedule1.AppointmentCollection.Add("", #1/3/2003#, "3", #10:00:00 AM#, 60)
    'appointment.IsEvent = True
    'appointment = Schedule1.AppointmentCollection.Add("", #1/3/2003#, "3", #11:00:00 AM#, 60)
    'appointment.IsEvent = True
    '************************************************

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2003#, Schedule1.RoomCollection(2), #11:00:00 AM#, 60)

    'Dim NewA As Gravitybox.Objects.AppointmentItem
    'NewA = CType(appointment.Clone(), Gravitybox.Objects.AppointmentItem)
    'Debug.WriteLine(appointment.Key)
    'Debug.WriteLine(NewA.Key)


    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "3", #10:00:00 AM#, 60)
    'appointment.Subject = "Appointment II"
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))
    'Call appointment.CategoryCollection.Add(Schedule1.CategoryCollection(5))
    'appointment.BlockOut = True

    'appointment = Schedule1.AppointmentCollection.Add("", #1/3/2003#, "1", #11:00:00 AM#, 1380)
    'appointment.Subject = "Appointment III"
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(2))
    'Call appointment.CategoryCollection.Add(Schedule1.CategoryCollection(6))

    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "1", #8:00:00 AM#, 30)
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))
    'appointment.Appearance.BackColor = Color.Yellow
    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "1", #8:00:00 AM#, 30)
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))
    'appointment.Appearance.BackColor = Color.Gray

    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "1", #8:00:00 AM#, 30)
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))
    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "1", #9:00:00 AM#, 120)
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))
    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2003#, "1", #10:00:00 AM#, 90)
    'Call appointment.ProviderCollection.Add(Schedule1.ProviderCollection(1))

    Schedule1.ColumnHeader.Appearance.BackColor = SystemColors.Control
    Schedule1.ColumnHeader.Appearance.BorderColor = SystemColors.ControlDark
    Schedule1.ColumnHeader.Appearance.ForeColor = SystemColors.ControlText

    Schedule1.RowHeader.Appearance.BackColor = SystemColors.Control
    Schedule1.RowHeader.Appearance.BorderColor = SystemColors.ControlDark
    Schedule1.RowHeader.Appearance.ForeColor = SystemColors.ControlText

    Schedule1.AllowSelector = False
    Schedule1.AppointmentSpace = 8
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.All

    Schedule1.StartTime = #3:00:00 AM#
    Schedule1.DayLength = 12
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30

    Schedule1.AllowSelector = True
    Schedule1.Selector.Column = 2
    Schedule1.Selector.Row = 3
    'Call Schedule1.SetMinMaxDate(#1/1/2003#, #1/20/2003#)
    'Call Schedule1.Visibility.ShowTime(#8:00:00 AM#)

    'Call CreateRandomAppointments()

    'Call SaveSoap("c:\test_xxx.xml", Schedule1.AppointmentCollection.ToArray)
    'Call Schedule1.AppointmentCollection.Clear()
    'Dim array As ArrayList = CType(LoadSoap("c:\test_xxx.xml"), ArrayList)
    'Call Schedule1.AppointmentCollection.FromArray(array)

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 120)
    appointment.ToolTipText = "My Tip"
    appointment.Subject = "XXX"

    Schedule1.Font = New Font(Schedule1.Font.FontFamily, 8, 0, Schedule1.Font.Unit)

    Me.Size = New Size(800, 500)
    Me.StartPosition = FormStartPosition.CenterScreen

  End Sub

#Region "Random Appointments"

  Private Sub CreateRandomAppointments()

    Try
      Const AppointmentCount As Integer = 50
      Const DayCount As Integer = 30
      Const HourCount As Integer = 10

      Dim r As System.Random = New System.Random
      Dim ii As Integer

      Call Schedule1.AppointmentCollection.Clear()
      Call Schedule1.SetMinMaxDate(#1/1/2003#, DateAdd(DateInterval.Day, DayCount, #1/1/2003#))
      Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
      Schedule1.StartTime = #8:00:00 AM#
      Schedule1.DayLength = HourCount

      For ii = 1 To AppointmentCount
        Dim appointment As Gravitybox.Objects.Appointment
        Dim startDate As Date = DateAdd(DateInterval.Day, (r.Next Mod DayCount), Schedule1.MinDate)
        Dim startTime As Date = DateAdd(DateInterval.Minute, (r.Next Mod (HourCount * 60)), Schedule1.StartTime)
        appointment = Schedule1.AppointmentCollection.Add("", startDate, startTime, 60)
        appointment.Subject = RandomString()
        appointment.Room = Schedule1.RoomCollection(CInt((r.Next Mod Schedule1.RoomCollection.Count) + 1))
        appointment.ProviderList.Add(Schedule1.ProviderCollection(CInt((r.Next Mod Schedule1.ProviderCollection.Count) + 1)))
      Next

    Catch
      Throw
    End Try

  End Sub

#End Region

#Region "Viewmode Button"

  Private Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    End Select

  End Sub

#End Region


  Private Sub Schedule1_UserDrawnBar(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs)

    Try
      Dim rows As Integer = (e.rectangle.Height \ Schedule1.RowHeader.Size) + 1
      Dim ii As Integer
      Call e.graphics.FillRectangle(New SolidBrush(Color.White), e.rectangle)

      'Loop for each TimeIncrement
      'Draw an "X" in the bar area
      For ii = 0 To rows - 1
        Call e.graphics.DrawLine(New Pen(Color.Black), e.rectangle.Left, e.rectangle.Top + (ii * Schedule1.RowHeader.Size), e.rectangle.Left + e.rectangle.Width - 1, e.rectangle.Top + (ii * Schedule1.RowHeader.Size) + Schedule1.RowHeader.Size - 1)
        Call e.graphics.DrawLine(New Pen(Color.Black), e.rectangle.Left + e.rectangle.Width - 1, e.rectangle.Top + (ii * Schedule1.RowHeader.Size), e.rectangle.Left, e.rectangle.Top + (ii * Schedule1.RowHeader.Size) + Schedule1.RowHeader.Size - 1)
      Next
    Catch
      Throw
    End Try

  End Sub

  Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
    Call Schedule1.AppointmentCollection.RemoveAt(1)
  End Sub

  Private Sub cmdScrollBars_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScrollbars.Click

    Select Case Schedule1.ScrollBars
      Case ScrollBars.Both
        Schedule1.ScrollBars = ScrollBars.Horizontal
      Case ScrollBars.Horizontal
        Schedule1.ScrollBars = ScrollBars.None
      Case ScrollBars.None
        Schedule1.ScrollBars = ScrollBars.Vertical
      Case ScrollBars.Vertical
        Schedule1.ScrollBars = ScrollBars.Both
    End Select

  End Sub

  Private Sub cmdPList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPList.Click
    Call Schedule1.Dialogs.ShowPropertyDialog(Schedule1.AppointmentCollection(0))
  End Sub

  Private Sub cmdShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShow.Click
    Schedule1.Dialogs.ShowProviderConfiguration()
    'Call Schedule1.ShowAlarmDialog(Schedule1.AppointmentCollection(3))
    'Call Schedule1.ShowRoom(2)
    'Call MsgBox("buffer", MsgBoxStyle.Information)
    'Call Schedule1.ShowRoom(3)
    'Call MsgBox("buffer", MsgBoxStyle.Information)
    'Call Schedule1.ShowTime(#9:00:00 AM#)
    'Call MsgBox("buffer", MsgBoxStyle.Information)
    'Call Schedule1.ShowTime(#1:00:00 PM#)
    'Call MsgBox("buffer", MsgBoxStyle.Information)
    'Call Schedule1.ShowTime(#5:00:00 PM#)
  End Sub

  Private Sub cmdCList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCList.Click
    Call Schedule1.Dialogs.ShowCategoryDialog(Schedule1.AppointmentCollection(0))
  End Sub

  Private Sub mnuFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
    Me.Close()
  End Sub

  Private Sub mnuFileClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileClear.Click
    Call Schedule1.AppointmentCollection.Clear()
    'Call Schedule1.ProviderCollection.Clear()
    'Call Schedule1.RoomCollection.Clear()
    Call Schedule1.Refresh()
  End Sub

  Private Sub mnuFileLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileLoad.Click
    Call Schedule1.AppointmentCollection.LoadXML("c:\appointments10.xml")
    Call Schedule1.Refresh()
  End Sub

  Private Sub mnuFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFileSave.Click
    Call Schedule1.AppointmentCollection.SaveXML("c:\appointments10.xml")
  End Sub

  Private Sub mnuFilePrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFilePrintPreview.Click
    Call Schedule1.GoPreview()
  End Sub

  Private Sub mnuFilePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuFilePrint.Click
    Call Schedule1.GoPrint()
  End Sub

  Private Sub cmdFree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFree.Click

    'Dim b As Boolean = Schedule1.Availability.IsAvailableArea(#1/2/2003#, #9:00:00 AM#, 60)
    'Call MsgBox(b.ToString, MsgBoxStyle.Information)

    Dim appointment As Gravitybox.Objects.Appointment = Schedule1.Availability.NextAreaAvailable(#1/2/2003#, Schedule1.RoomCollection(1), #9:00:00 AM#, 60)
    Call MsgBox(appointment.ToString, MsgBoxStyle.Information)

  End Sub

  Private Sub cmdToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToFile.Click
    Call Schedule1.AppointmentCollection.ToVCAL("c:\test.vcs")
  End Sub

  Private Sub cmdFromFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFromFile.Click
    Call Schedule1.AppointmentCollection.Clear()
    Call Schedule1.AppointmentCollection.FromVCAL("c:\test.vcs")
  End Sub

  Private Sub cmdEffects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEffects.Click

    'Create "iCal" look-and-feel
    Dim F As New EffectsForm
    Dim appointment As Appointment

    F.Schedule1.AllowSelector = False
    Call F.Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    F.Schedule1.StartTime = #8:00:00 AM#
    F.Schedule1.DayLength = 10
    F.Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger
    F.Schedule1.AppointmentSpace = 0
    F.Schedule1.AllowEvents = False

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

    appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:30:00 AM#, 60)
    appointment.Subject = "Lunch with Jill"
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Appearance.Transparency = 30
    appointment.Appearance.BorderColor = Color.Green
    appointment.Appearance.ForeColor = appointment.Appearance.BorderColor
    appointment.Appearance.IsRound = True
    appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.Header.Appearance.BackColor = appointment.Appearance.BackColor
    appointment.Header.Appearance.ForeColor = appointment.Appearance.ForeColor
    appointment.Header.Appearance.Transparency = appointment.Appearance.Transparency
    appointment.Header.Appearance.AllowBreak = False
    appointment.Header.Icon = Schedule1.DefaultIcons.IconInfo

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
    appointment.Header.Icon = Schedule1.DefaultIcons.IconWarning

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
    appointment.Header.Icon = Schedule1.DefaultIcons.IconMoreInfo

    appointment = F.Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:30:00 AM#, 60)
    appointment.Subject = "Pizza with Grandma"
    appointment.Appearance.BackColor = Color.LightGreen
    appointment.Appearance.Transparency = 30
    appointment.Appearance.BorderColor = Color.Green
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

  Private Sub cmdReserved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReserved.Click

    'Schedule1.EnterpriseConnection.ServerName = "localhost"
    'Schedule1.EnterpriseConnection.ServerPort = 8090
    'Schedule1.EnterpriseConnection.IsConnected = True

  End Sub

  Private Sub XXX()

    Call Schedule1.RoomCollection.Add("123", "Room 1")
    Call Schedule1.RoomCollection.Add("456", "Room 2")
    Call Schedule1.RoomCollection.Add("789", "Room 3")

    Dim room As Gravitybox.Objects.Room
    room = Schedule1.RoomCollection("Room 2")
    'OR
    'room = Schedule1.RoomCollection("456")

    Call Schedule1.AppointmentCollection.Add("", #1/1/2004#, room, #1:00:00 AM#, 60)

  End Sub


  Private Overloads Sub Schedule1_DragOver(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.DragAppointmentEventArgs)

    Dim al As New AppointmentList
    al.Add(e.Appointment)
    If Schedule1.AppointmentCollection.IsConflict(e.Appointment, al) Then
      'Do Something
    End If

  End Sub


  Private Sub Schedule1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Debug.WriteLine(Now)
  End Sub

End Class
