Option Strict On
Option Explicit On 

Imports SchoolTutor.Objects

Namespace Forms

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
    Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
    Friend WithEvents Header1 As Gravitybox.Controls.Header
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents menuFile As System.Windows.Forms.MenuItem
    Friend WithEvents menuExit As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelpContents As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelpIndex As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelpSearch As System.Windows.Forms.MenuItem
    Friend WithEvents menuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents menuTutors As System.Windows.Forms.MenuItem
    Friend WithEvents menuStudents As System.Windows.Forms.MenuItem
    Friend WithEvents menuCourses As System.Windows.Forms.MenuItem
    Friend WithEvents MonthCalendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTutor As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Schedule1 = New Gravitybox.Controls.Schedule
      Me.Header1 = New Gravitybox.Controls.Header
      Me.MainMenu1 = New System.Windows.Forms.MainMenu
      Me.menuFile = New System.Windows.Forms.MenuItem
      Me.menuExit = New System.Windows.Forms.MenuItem
      Me.menuEdit = New System.Windows.Forms.MenuItem
      Me.menuCourses = New System.Windows.Forms.MenuItem
      Me.menuTutors = New System.Windows.Forms.MenuItem
      Me.menuStudents = New System.Windows.Forms.MenuItem
      Me.menuHelp = New System.Windows.Forms.MenuItem
      Me.menuHelpContents = New System.Windows.Forms.MenuItem
      Me.menuHelpIndex = New System.Windows.Forms.MenuItem
      Me.menuHelpSearch = New System.Windows.Forms.MenuItem
      Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar
      Me.Label1 = New System.Windows.Forms.Label
      Me.cboTutor = New System.Windows.Forms.ComboBox
      Me.SuspendLayout()
      '
      'Schedule1
      '
      Me.Schedule1.AllowAdd = True
      Me.Schedule1.AllowDrop = True
      Me.Schedule1.AllowEvents = True
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
      Me.Schedule1.EventHeaderColor = System.Drawing.SystemColors.AppWorkspace
      Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
      Me.Schedule1.GridBackColor = System.Drawing.Color.White
      Me.Schedule1.GridForeColor = System.Drawing.Color.DarkGray
      Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
      Me.Schedule1.Location = New System.Drawing.Point(0, 40)
      Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
      Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
      Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
      Me.Schedule1.Name = "Schedule1"
      Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.Schedule1.SelectedItem = Nothing
      Me.Schedule1.Size = New System.Drawing.Size(472, 392)
      Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
      Me.Schedule1.TabIndex = 0
      Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
      Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
      '
      'Header1
      '
      Me.Header1.BorderStyle = Gravitybox.Controls.Header.BorderStyleConstants.None
      Me.Header1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Header1.Icon = Nothing
      Me.Header1.IconAlignment = Gravitybox.Controls.Header.IconAlignmentConstants.Right
      Me.Header1.Name = "Header1"
      Me.Header1.Size = New System.Drawing.Size(664, 40)
      Me.Header1.TabIndex = 1
      '
      'MainMenu1
      '
      Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuEdit, Me.menuHelp})
      '
      'menuFile
      '
      Me.menuFile.Index = 0
      Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuExit})
      Me.menuFile.Text = "&File"
      '
      'menuExit
      '
      Me.menuExit.Index = 0
      Me.menuExit.Text = "E&xit"
      '
      'menuEdit
      '
      Me.menuEdit.Index = 1
      Me.menuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCourses, Me.menuTutors, Me.menuStudents})
      Me.menuEdit.Text = "&Edit"
      '
      'menuCourses
      '
      Me.menuCourses.Index = 0
      Me.menuCourses.Text = "&Courses"
      '
      'menuTutors
      '
      Me.menuTutors.Index = 1
      Me.menuTutors.Text = "&Tutors"
      '
      'menuStudents
      '
      Me.menuStudents.Index = 2
      Me.menuStudents.Text = "&Students"
      '
      'menuHelp
      '
      Me.menuHelp.Index = 2
      Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuHelpContents, Me.menuHelpIndex, Me.menuHelpSearch})
      Me.menuHelp.Text = "&Help"
      '
      'menuHelpContents
      '
      Me.menuHelpContents.Index = 0
      Me.menuHelpContents.Text = "&Contents"
      '
      'menuHelpIndex
      '
      Me.menuHelpIndex.Index = 1
      Me.menuHelpIndex.Text = "&Index"
      '
      'menuHelpSearch
      '
      Me.menuHelpSearch.Index = 2
      Me.menuHelpSearch.Text = "&Seach"
      '
      'MonthCalendar1
      '
      Me.MonthCalendar1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
      Me.MonthCalendar1.CalendarDimensions = New System.Drawing.Size(1, 2)
      Me.MonthCalendar1.Location = New System.Drawing.Point(472, 80)
      Me.MonthCalendar1.Name = "MonthCalendar1"
      Me.MonthCalendar1.TabIndex = 2
      '
      'Label1
      '
      Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
      Me.Label1.Location = New System.Drawing.Point(472, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(184, 16)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Tutors:"
      '
      'cboTutor
      '
      Me.cboTutor.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
      Me.cboTutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTutor.Location = New System.Drawing.Point(472, 56)
      Me.cboTutor.Name = "cboTutor"
      Me.cboTutor.Size = New System.Drawing.Size(192, 21)
      Me.cboTutor.TabIndex = 4
      '
      'ScheduleForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(664, 433)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTutor, Me.Label1, Me.MonthCalendar1, Me.Header1, Me.Schedule1})
      Me.Menu = Me.MainMenu1
      Me.Name = "ScheduleForm"
      Me.Text = "School Schedule"
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private CourseItems As New Objects.CourseItems
    Private StudentItems As New Objects.StudentItems
    Private TutorItems As New Objects.TutorItems

    Private Sub ScheduleForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Schedule1.StartTime = #8:00:00 AM#
      Schedule1.HeaderDateFormat = "MM/dd/yy"
      Schedule1.DayLength = 10
      Schedule1.ColumnHeader.AutoFit = True
      Call RefreshRange(Now)
      Call LoadInitialData()

    End Sub

    Private Sub LoadInitialData()

      'Add Courses
      Call CourseItems.Add("", "MAT 100")
      Call CourseItems.Add("", "MAT 101")
      Call CourseItems.Add("", "CS 100")
      Call CourseItems.Add("", "CS 101")
      Call CourseItems.Add("", "BUS 321")
      Call CourseItems.Add("", "BUS 202")
      Call CourseItems.Add("", "ECO 151")
      Call CourseItems.Add("", "ECO 173")

      'Add Students
      Call StudentItems.Add("", "Chris", "Johnson")
      Call StudentItems.Add("", "Rusty", "Majors")
      Call StudentItems.Add("", "Suzy", "Daniels")
      Call StudentItems.Add("", "Clifford", "Weaver")

      'Add Tutors
      Dim tutor As Objects.TutorItem
      tutor = TutorItems.Add("", "John", "Black", Color.LightPink)
      Call tutor.CourseItems.Add(CourseItems(0))
      Call tutor.CourseItems.Add(CourseItems(1))

      tutor = TutorItems.Add("", "Frank", "White", Color.LightGreen)
      Call tutor.CourseItems.Add(CourseItems(2))
      Call tutor.CourseItems.Add(CourseItems(3))

      tutor = TutorItems.Add("", "Joe", "Collins", Color.LightYellow)
      Call tutor.CourseItems.Add(CourseItems(4))
      Call tutor.CourseItems.Add(CourseItems(5))

      tutor = TutorItems.Add("", "Bill", "Woods", Color.LightGray)
      Call tutor.CourseItems.Add(CourseItems(6))
      Call tutor.CourseItems.Add(CourseItems(7))

      Call LoadTutorCombo()

    End Sub

    Private Sub LoadTutorCombo()

      Dim tutor As Objects.TutorItem
      Call cboTutor.Items.Clear()
      Call cboTutor.Items.Add("(All)")
      For Each tutor In Me.TutorItems
        Call cboTutor.Items.Add(tutor.ToString)
      Next
      cboTutor.SelectedIndex = 0

    End Sub

    Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
      Call Me.Close()
    End Sub

    Private Sub menuTutors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuTutors.Click
      Dim F As New Forms.TutorForm
      F.TutorItems = Me.TutorItems
      F.ShowDialog()
    End Sub

    Private Sub menuStudents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuStudents.Click
      Dim F As New Forms.StudentForm
      F.StudentItems = Me.StudentItems
      F.ShowDialog()
    End Sub

    Private Sub menuCourses_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuCourses.Click
      Dim F As New Forms.CourseForm
      F.CourseItems = Me.CourseItems
      F.ShowDialog()
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
      Call RefreshRange(e.Start)
    End Sub

    Private Sub RefreshRange(ByVal selectedDate As Date)

      Dim startDate As Date
      Dim endDate As Date
      Static inHere As Boolean

      If inHere Then Return
      inHere = True

      Schedule1.AutoRedraw = False
      Schedule1.GridForeColor = System.Drawing.Color.DarkGray
      startDate = DateAdd(DateInterval.Day, -selectedDate.DayOfWeek + 1, selectedDate)
      endDate = DateAdd(DateInterval.Day, 4, startDate)

      Call Me.MonthCalendar1.SetSelectionRange(startDate, endDate)
      Me.MonthCalendar1.SelectionRange.Start = startDate
      Me.MonthCalendar1.SelectionRange.End = endDate
      Call Schedule1.SetMinMaxDate(MonthCalendar1.SelectionStart, MonthCalendar1.SelectionEnd)
      Schedule1.AutoRedraw = True
      inHere = False

    End Sub

    Private Sub Schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs) Handles Schedule1.BeforePropertyDialog

      e.Cancel = True

      Dim F As New Forms.PropertyForm
      F.CourseItems = Me.CourseItems
      F.StudentItems = Me.StudentItems
      F.TutorItems = Me.TutorItems
      F.Appointment = e.Appointment
      Call F.ShowDialog()

      If e.Appointment.PropertyItemCollection("student").Setting = "" Then
        Call Schedule1.AppointmentCollection.Remove(e.Appointment)
      Else
        e.Appointment.Subject = Me.StudentItems(e.Appointment.PropertyItemCollection("student").Setting).ToString
        Call RedrawAppointments()
      End If

    End Sub

    Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentAdd
      Call e.Appointment.PropertyItemCollection.Add("", "student", "")
      Call e.Appointment.PropertyItemCollection.Add("", "tutor", "")
      Call e.Appointment.PropertyItemCollection.Add("", "course", "")
    End Sub




    Private Sub cboTutor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTutor.SelectedIndexChanged
      Call RedrawAppointments()
    End Sub

    Private Sub RedrawAppointments()

      If cboTutor.SelectedIndex = -1 Then Exit Sub

      Dim tutor As Objects.TutorItem
      If cboTutor.SelectedIndex > 0 Then
        tutor = Me.TutorItems(cboTutor.SelectedIndex - 1)
      End If

      'This will filter the appointments for a specific tutor
      Dim appointment As Gravitybox.Objects.Appointment
      For Each appointment In Schedule1.AppointmentCollection
        If cboTutor.SelectedIndex = 0 Then
          'All tutors
          appointment.Visible = True
        Else
          'Only a specified tutor
          If appointment.PropertyItemCollection("tutor").Setting = tutor.Key Then
            appointment.Visible = True
          Else
            appointment.Visible = False
          End If
        End If

        appointment.Appearance.BackColor = Me.TutorItems(appointment.PropertyItemCollection("tutor").Setting).BackColor

      Next
      Schedule1.RecalculateConflicts()
      Call Schedule1.Refresh()

    End Sub

  End Class

End Namespace