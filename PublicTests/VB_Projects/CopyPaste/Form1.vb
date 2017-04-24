Option Explicit On 
Option Strict On

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
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents menuFile As System.Windows.Forms.MenuItem
  Friend WithEvents menuFileExit As System.Windows.Forms.MenuItem
  Friend WithEvents menuEdit As System.Windows.Forms.MenuItem
  Friend WithEvents menuEditCopy As System.Windows.Forms.MenuItem
  Friend WithEvents menuEditPaste As System.Windows.Forms.MenuItem
  Friend WithEvents menuEditCut As System.Windows.Forms.MenuItem
  Friend WithEvents menuHelp As System.Windows.Forms.MenuItem
  Friend WithEvents menuHelpAbout As System.Windows.Forms.MenuItem
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.menuFile = New System.Windows.Forms.MenuItem
    Me.menuFileExit = New System.Windows.Forms.MenuItem
    Me.menuEdit = New System.Windows.Forms.MenuItem
    Me.menuEditCut = New System.Windows.Forms.MenuItem
    Me.menuEditCopy = New System.Windows.Forms.MenuItem
    Me.menuEditPaste = New System.Windows.Forms.MenuItem
    Me.menuHelp = New System.Windows.Forms.MenuItem
    Me.menuHelpAbout = New System.Windows.Forms.MenuItem
    Me.Label1 = New System.Windows.Forms.Label
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuEdit, Me.menuHelp})
    '
    'menuFile
    '
    Me.menuFile.Index = 0
    Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFileExit})
    Me.menuFile.Text = "&File"
    '
    'menuFileExit
    '
    Me.menuFileExit.Index = 0
    Me.menuFileExit.Text = "E&xit"
    '
    'menuEdit
    '
    Me.menuEdit.Index = 1
    Me.menuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuEditCut, Me.menuEditCopy, Me.menuEditPaste})
    Me.menuEdit.Text = "&Edit"
    '
    'menuEditCut
    '
    Me.menuEditCut.Index = 0
    Me.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
    Me.menuEditCut.Text = "Cu&t"
    '
    'menuEditCopy
    '
    Me.menuEditCopy.Index = 1
    Me.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
    Me.menuEditCopy.Text = "&Copy"
    '
    'menuEditPaste
    '
    Me.menuEditPaste.Index = 2
    Me.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
    Me.menuEditPaste.Text = "&Paste"
    '
    'menuHelp
    '
    Me.menuHelp.Index = 2
    Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuHelpAbout})
    Me.menuHelp.Text = "&Help"
    '
    'menuHelpAbout
    '
    Me.menuHelpAbout.Index = 0
    Me.menuHelpAbout.Text = "&About"
    '
    'Label1
    '
    Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Label1.Location = New System.Drawing.Point(0, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(688, 56)
    Me.Label1.TabIndex = 0
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 56)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(688, 321)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(688, 377)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Label1)
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Form Variables"

  Private ClipboardAppointments As New ArrayList

#End Region

#Region "Form Load"

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the Schedule
    Schedule1.Appearance.BackColor = Color.LightYellow
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.SetMinMaxDate(Now, Now.AddDays(4))
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.MultiSelect = True

    Label1.Text = "Select one or more appointments. You can then use copy/cut/paste shortcuts or menus.  After you copy or cut, move the selector to the place you wish to place the appointments and paste. If you cut and paste, the appointment is moved. If you copy and paste, a new appointment is created (a copy)."

    'Add some appointments
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #8:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #9:30:00 AM#, 30)
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #11:00:00 AM#, 120)
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), #8:30:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), #10:00:00 AM#, 90)
    Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(1), #11:00:00 AM#, 60)

    For Each appointment As Appointment In Schedule1.AppointmentCollection
      appointment.Appearance.BackColor = Color.LightBlue
      appointment.Subject = "This is a test"
      appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
    Next

  End Sub

#End Region

#Region "Menus"

  Private Sub menuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileExit.Click
    Me.Close()
  End Sub

  Private Sub menuEdit_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuEdit.Popup

    'Enable the menus
    menuEditCopy.Enabled = (Schedule1.SelectedItems.Count > 0)
    menuEditCut.Enabled = (Schedule1.SelectedItems.Count > 0)
    menuEditPaste.Enabled = (ClipboardAppointments.Count > 0) AndAlso (Schedule1.SelectedItem Is Nothing)

  End Sub

  Private Sub menuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditCut.Click

    Me.ClearGhosted()
    Me.ClipboardAppointments.Clear()
    For Each appointment As Appointment In Schedule1.SelectedItems
      appointment.Appearance.Ghosted = True
      Me.ClipboardAppointments.Add(appointment.Key)
    Next
    Me.Schedule1.SelectedItems.Clear()

  End Sub

  Private Sub menuEditCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditCopy.Click

    Me.ClipboardAppointments.Clear()

    'When coping make all appointment blink 
    Schedule1.AutoRedraw = False
    For Each appointment As Appointment In Schedule1.SelectedItems
      appointment.Appearance.Ghosted = True
      Me.ClipboardAppointments.Add(appointment.Key)
    Next
    Schedule1.AutoRedraw = True

    'Sleep for a time period
    System.Threading.Thread.CurrentThread.Sleep(200)

    'Make them all visible again
    Schedule1.AutoRedraw = False
    For Each appointment As Appointment In Schedule1.SelectedItems
      appointment.Appearance.Ghosted = False
    Next
    Schedule1.AutoRedraw = True

  End Sub

  Private Sub menuEditPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditPaste.Click

    'When pasting calculate the earliest appointments date/time
    Dim firstTime As Date = Date.MaxValue
    For Each key As String In Me.ClipboardAppointments
      Dim appointment As Appointment = Schedule1.AppointmentCollection(key)
      If firstTime > appointment.StartDateTime Then
        firstTime = appointment.StartDateTime
      End If
    Next

    'There was some error, do nothing
    If firstTime = Date.MaxValue Then
      Return
    End If

    'Now that we have the first time...
    Dim selectorDate As Date = Schedule1.Visibility.GetDateFromRowCol(Me.Schedule1.Selector.Column)
    Dim selectorTime As Date = Schedule1.Visibility.GetTimeFromRowCol(Me.Schedule1.Selector.Row)
    Dim selector As Date = selectorDate.AddHours(selectorTime.Hour).AddMinutes(selectorTime.Minute)

    'Get the number of minutes between the first appointment's position and the selector
    Dim differenceMinutes As Integer = CInt(selector.Subtract(firstTime).TotalMinutes)
    Schedule1.AutoRedraw = False
    For Each key As String In Me.ClipboardAppointments
      Dim appointment As Appointment = Schedule1.AppointmentCollection(key)
      Dim apptDateTime As Date = appointment.StartDateTime
      apptDateTime = apptDateTime.AddMinutes(differenceMinutes)

      'If the appointment is ghosted then the user cut the appointment 
      'and pasted it somewhere else, otherwise it was copied
      If appointment.Appearance.Ghosted Then
        'Move the appointment, so just reset their date/time
        appointment.StartDate = apptDateTime
        appointment.StartTime = apptDateTime
      Else
        'Create a copy of the appointment and add them to the collection
				appointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
        appointment.StartDate = apptDateTime
        appointment.StartTime = apptDateTime
        appointment.Recurrence = Nothing
        Schedule1.AppointmentCollection.Add(appointment)
      End If

    Next
    Schedule1.AutoRedraw = True

    'Clear all ghosted appointments
    Me.ClearGhosted()

  End Sub

  Private Sub menuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHelpAbout.Click
    MsgBox("About Gravitybox Schedule Copy/Paste Test" & vbCrLf & "Version 1.0", MsgBoxStyle.Information, "About")
  End Sub

#End Region

#Region "Schedule Events"

  Private Sub Schedule1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Schedule1.KeyPress

    'If pressed <ESC> then clear all ghosted items
    If e.KeyChar = ChrW(Keys.Escape) Then
      Me.ClearGhosted()
    End If

  End Sub

#End Region

#Region "Methods"

  Private Sub ClearGhosted()

    For Each appointment As Appointment In Schedule1.AppointmentCollection
      If appointment.Appearance.Ghosted Then
        appointment.Appearance.Ghosted = False
        If Me.ClipboardAppointments.Contains(appointment.Key) Then
          Me.ClipboardAppointments.Remove(appointment.Key)
        End If
      End If
    Next

  End Sub

#End Region

End Class
