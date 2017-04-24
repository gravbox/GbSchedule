Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class MDIForm
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
  Friend WithEvents butPatient As System.Windows.Forms.ToolBarButton
  Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
  Friend WithEvents butSep1 As System.Windows.Forms.ToolBarButton
  Friend WithEvents butScheduleOpen As System.Windows.Forms.ToolBarButton
  Friend WithEvents butScheduleProperties As System.Windows.Forms.ToolBarButton
  Friend WithEvents butScheduleFind As System.Windows.Forms.ToolBarButton
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents menuAbout As System.Windows.Forms.MenuItem
  Friend WithEvents menuContents As System.Windows.Forms.MenuItem
  Friend WithEvents menuHelp As System.Windows.Forms.MenuItem
  Friend WithEvents menuSeach As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupLogin As System.Windows.Forms.MenuItem
  Friend WithEvents menuScheduleOpen As System.Windows.Forms.MenuItem
  Friend WithEvents menuScheduleClose As System.Windows.Forms.MenuItem
  Friend WithEvents menuView As System.Windows.Forms.MenuItem
  Friend WithEvents menuPatient As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetup As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupADA As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupPractice As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupProvider As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupCategories As System.Windows.Forms.MenuItem
  Friend WithEvents menuSetupRoom As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
  Friend WithEvents menuExit As System.Windows.Forms.MenuItem
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents menuFile As System.Windows.Forms.MenuItem
  Friend WithEvents menuPrintPreview As System.Windows.Forms.MenuItem
  Friend WithEvents menuPrint As System.Windows.Forms.MenuItem
  Friend WithEvents menuPreference As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents pnlPatient As System.Windows.Forms.Panel
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents tabList As System.Windows.Forms.TabPage
  Friend WithEvents cmdPatientDelete As System.Windows.Forms.Button
  Friend WithEvents cmdPatientEdit As System.Windows.Forms.Button
  Friend WithEvents cmdPatientAdd As System.Windows.Forms.Button
  Friend WithEvents tvwPatient As System.Windows.Forms.TreeView
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MDIForm))
    Me.butPatient = New System.Windows.Forms.ToolBarButton
    Me.ToolBar1 = New System.Windows.Forms.ToolBar
    Me.butSep1 = New System.Windows.Forms.ToolBarButton
    Me.butScheduleOpen = New System.Windows.Forms.ToolBarButton
    Me.butScheduleProperties = New System.Windows.Forms.ToolBarButton
    Me.butScheduleFind = New System.Windows.Forms.ToolBarButton
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.menuAbout = New System.Windows.Forms.MenuItem
    Me.menuContents = New System.Windows.Forms.MenuItem
    Me.menuHelp = New System.Windows.Forms.MenuItem
    Me.menuSeach = New System.Windows.Forms.MenuItem
    Me.MenuItem3 = New System.Windows.Forms.MenuItem
    Me.menuSetupLogin = New System.Windows.Forms.MenuItem
    Me.menuScheduleOpen = New System.Windows.Forms.MenuItem
    Me.menuScheduleClose = New System.Windows.Forms.MenuItem
    Me.menuView = New System.Windows.Forms.MenuItem
    Me.menuPatient = New System.Windows.Forms.MenuItem
    Me.menuSetup = New System.Windows.Forms.MenuItem
    Me.menuSetupADA = New System.Windows.Forms.MenuItem
    Me.menuSetupPractice = New System.Windows.Forms.MenuItem
    Me.menuSetupProvider = New System.Windows.Forms.MenuItem
    Me.menuSetupCategories = New System.Windows.Forms.MenuItem
    Me.menuSetupRoom = New System.Windows.Forms.MenuItem
    Me.MenuItem9 = New System.Windows.Forms.MenuItem
    Me.menuExit = New System.Windows.Forms.MenuItem
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.menuFile = New System.Windows.Forms.MenuItem
    Me.menuPrintPreview = New System.Windows.Forms.MenuItem
    Me.menuPrint = New System.Windows.Forms.MenuItem
    Me.menuPreference = New System.Windows.Forms.MenuItem
    Me.MenuItem2 = New System.Windows.Forms.MenuItem
    Me.pnlPatient = New System.Windows.Forms.Panel
    Me.TabControl1 = New System.Windows.Forms.TabControl
    Me.tabList = New System.Windows.Forms.TabPage
    Me.cmdPatientDelete = New System.Windows.Forms.Button
    Me.cmdPatientEdit = New System.Windows.Forms.Button
    Me.cmdPatientAdd = New System.Windows.Forms.Button
    Me.tvwPatient = New System.Windows.Forms.TreeView
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.pnlPatient.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.tabList.SuspendLayout()
    Me.SuspendLayout()
    '
    'butPatient
    '
    Me.butPatient.ImageIndex = 5
    Me.butPatient.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
    Me.butPatient.ToolTipText = "Patient List"
    '
    'ToolBar1
    '
    Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.butPatient, Me.butSep1, Me.butScheduleOpen, Me.butScheduleProperties, Me.butScheduleFind})
    Me.ToolBar1.DropDownArrows = True
    Me.ToolBar1.ImageList = Me.ImageList1
    Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
    Me.ToolBar1.Name = "ToolBar1"
    Me.ToolBar1.ShowToolTips = True
    Me.ToolBar1.Size = New System.Drawing.Size(512, 28)
    Me.ToolBar1.TabIndex = 9
    '
    'butSep1
    '
    Me.butSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
    '
    'butScheduleOpen
    '
    Me.butScheduleOpen.ImageIndex = 1
    Me.butScheduleOpen.ToolTipText = "Open a Schedule"
    '
    'butScheduleProperties
    '
    Me.butScheduleProperties.ImageIndex = 6
    Me.butScheduleProperties.ToolTipText = "Schedule Properties"
    '
    'butScheduleFind
    '
    Me.butScheduleFind.ImageIndex = 4
    Me.butScheduleFind.ToolTipText = "Find Appointments"
    '
    'ImageList1
    '
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'menuAbout
    '
    Me.menuAbout.Index = 3
    Me.menuAbout.Text = "&About"
    '
    'menuContents
    '
    Me.menuContents.Index = 0
    Me.menuContents.Text = "&Contents"
    '
    'menuHelp
    '
    Me.menuHelp.Index = 3
    Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuContents, Me.menuSeach, Me.MenuItem3, Me.menuAbout})
    Me.menuHelp.Text = "&Help"
    '
    'menuSeach
    '
    Me.menuSeach.Index = 1
    Me.menuSeach.Text = "&Search"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 2
    Me.MenuItem3.Text = "-"
    '
    'menuSetupLogin
    '
    Me.menuSetupLogin.Index = 6
    Me.menuSetupLogin.Text = "&Logins"
    '
    'menuScheduleOpen
    '
    Me.menuScheduleOpen.Index = 1
    Me.menuScheduleOpen.Text = "&Open Schedule"
    '
    'menuScheduleClose
    '
    Me.menuScheduleClose.Index = 2
    Me.menuScheduleClose.Text = "&Close Schedule"
    '
    'menuView
    '
    Me.menuView.Index = 1
    Me.menuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuPatient, Me.menuScheduleOpen, Me.menuScheduleClose})
    Me.menuView.Text = "&View"
    '
    'menuPatient
    '
    Me.menuPatient.Index = 0
    Me.menuPatient.Text = "&Patient List"
    '
    'menuSetup
    '
    Me.menuSetup.Index = 2
    Me.menuSetup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSetupADA, Me.menuSetupPractice, Me.menuSetupProvider, Me.menuSetupCategories, Me.menuSetupRoom, Me.MenuItem9, Me.menuSetupLogin})
    Me.menuSetup.Text = "Se&tup"
    '
    'menuSetupADA
    '
    Me.menuSetupADA.Index = 0
    Me.menuSetupADA.Text = "&ADA Codes"
    '
    'menuSetupPractice
    '
    Me.menuSetupPractice.Index = 1
    Me.menuSetupPractice.Text = "Practice &Info"
    '
    'menuSetupProvider
    '
    Me.menuSetupProvider.Index = 2
    Me.menuSetupProvider.Text = "&Providers"
    '
    'menuSetupCategories
    '
    Me.menuSetupCategories.Index = 3
    Me.menuSetupCategories.Text = "&Categories"
    '
    'menuSetupRoom
    '
    Me.menuSetupRoom.Index = 4
    Me.menuSetupRoom.Text = "&Rooms"
    '
    'MenuItem9
    '
    Me.MenuItem9.Index = 5
    Me.MenuItem9.Text = "-"
    '
    'menuExit
    '
    Me.menuExit.Index = 4
    Me.menuExit.Text = "E&xit"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuView, Me.menuSetup, Me.menuHelp})
    '
    'menuFile
    '
    Me.menuFile.Index = 0
    Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuPrintPreview, Me.menuPrint, Me.menuPreference, Me.MenuItem2, Me.menuExit})
    Me.menuFile.Text = "&File"
    '
    'menuPrintPreview
    '
    Me.menuPrintPreview.Index = 0
    Me.menuPrintPreview.Text = "Print Pre&view"
    '
    'menuPrint
    '
    Me.menuPrint.Index = 1
    Me.menuPrint.Text = "&Print"
    '
    'menuPreference
    '
    Me.menuPreference.Index = 2
    Me.menuPreference.Text = "&Preferences"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 3
    Me.MenuItem2.Text = "-"
    '
    'pnlPatient
    '
    Me.pnlPatient.Controls.Add(Me.TabControl1)
    Me.pnlPatient.Dock = System.Windows.Forms.DockStyle.Left
    Me.pnlPatient.Location = New System.Drawing.Point(0, 28)
    Me.pnlPatient.Name = "pnlPatient"
    Me.pnlPatient.Size = New System.Drawing.Size(168, 361)
    Me.pnlPatient.TabIndex = 13
    Me.pnlPatient.Visible = False
    '
    'TabControl1
    '
    Me.TabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom
    Me.TabControl1.Controls.Add(Me.tabList)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(168, 361)
    Me.TabControl1.TabIndex = 10
    '
    'tabList
    '
    Me.tabList.Controls.Add(Me.cmdPatientDelete)
    Me.tabList.Controls.Add(Me.cmdPatientEdit)
    Me.tabList.Controls.Add(Me.cmdPatientAdd)
    Me.tabList.Controls.Add(Me.tvwPatient)
    Me.tabList.Location = New System.Drawing.Point(4, 4)
    Me.tabList.Name = "tabList"
    Me.tabList.Size = New System.Drawing.Size(160, 335)
    Me.tabList.TabIndex = 0
    Me.tabList.Text = "List"
    '
    'cmdPatientDelete
    '
    Me.cmdPatientDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPatientDelete.ImageIndex = 3
    Me.cmdPatientDelete.ImageList = Me.ImageList1
    Me.cmdPatientDelete.Location = New System.Drawing.Point(136, 311)
    Me.cmdPatientDelete.Name = "cmdPatientDelete"
    Me.cmdPatientDelete.Size = New System.Drawing.Size(22, 22)
    Me.cmdPatientDelete.TabIndex = 4
    '
    'cmdPatientEdit
    '
    Me.cmdPatientEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPatientEdit.ImageIndex = 2
    Me.cmdPatientEdit.ImageList = Me.ImageList1
    Me.cmdPatientEdit.Location = New System.Drawing.Point(112, 311)
    Me.cmdPatientEdit.Name = "cmdPatientEdit"
    Me.cmdPatientEdit.Size = New System.Drawing.Size(22, 22)
    Me.cmdPatientEdit.TabIndex = 3
    '
    'cmdPatientAdd
    '
    Me.cmdPatientAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPatientAdd.ImageIndex = 0
    Me.cmdPatientAdd.ImageList = Me.ImageList1
    Me.cmdPatientAdd.Location = New System.Drawing.Point(88, 311)
    Me.cmdPatientAdd.Name = "cmdPatientAdd"
    Me.cmdPatientAdd.Size = New System.Drawing.Size(22, 22)
    Me.cmdPatientAdd.TabIndex = 2
    '
    'tvwPatient
    '
    Me.tvwPatient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tvwPatient.HideSelection = False
    Me.tvwPatient.ImageIndex = -1
    Me.tvwPatient.Location = New System.Drawing.Point(0, 0)
    Me.tvwPatient.Name = "tvwPatient"
    Me.tvwPatient.SelectedImageIndex = -1
    Me.tvwPatient.Size = New System.Drawing.Size(160, 313)
    Me.tvwPatient.Sorted = True
    Me.tvwPatient.TabIndex = 1
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
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DataSource = Nothing
    Me.Schedule1.DayLength = 16
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(212, 162)
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
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(88, 64)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 15
    Me.Schedule1.Visible = False
    '
    'MDIForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(512, 389)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.pnlPatient)
    Me.Controls.Add(Me.ToolBar1)
    Me.IsMdiContainer = True
    Me.Menu = Me.MainMenu1
    Me.Name = "MDIForm"
    Me.Text = "MDIForm"
    Me.pnlPatient.ResumeLayout(False)
    Me.TabControl1.ResumeLayout(False)
    Me.tabList.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  'Collections
  Private ADACodeCollection As New ADACodeCollection
  Private LoginCollection As New LoginCollection
  Private PatientCollection As New PatientCollection
  Public Preferences As New Preferences

  'Open Schedule Form
  Public ScheduleForm As ScheduleForm

  Private Sub MDIForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim SF As New SplashForm
    Call SF.ShowDialog()

    ToolBar1.Buttons(0).Pushed = True
    menuPatient.Checked = ToolBar1.Buttons(0).Pushed
    Call RefreshPatientBox()

    Me.Size = New System.Drawing.Size(CInt(Screen.PrimaryScreen.WorkingArea.Width * 0.8), CInt(Screen.PrimaryScreen.WorkingArea.Height * 0.8))
    Me.Location = New System.Drawing.Point(CInt(Screen.PrimaryScreen.WorkingArea.Width * 0.1), CInt(Screen.PrimaryScreen.WorkingArea.Height * 0.1))

    Call LoadAll()
    Call UpdateToolbar()

    Call LoadPatients()

  End Sub

#Region "File Menu"

  Private Sub menuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
    Call Me.Close()
  End Sub

  Private Sub menuPreferences_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPreference.Click
    Dim F As New PreferenceForm
    F.Preferences = Me.Preferences
    Call F.ShowDialog()
    If CBool(ParOut(0).Setting) Then
      Me.Preferences = CType(ParOut(1).Setting, Preferences)
      If Not (ScheduleForm Is Nothing) Then
        ScheduleForm.Schedule1.Appearance.BackColor = Me.Preferences.BackColor
      End If
    End If
  End Sub

#End Region

  Private Sub menuPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuPatient.Click
    ToolBar1.Buttons(0).Pushed = Not ToolBar1.Buttons(0).Pushed
    menuPatient.Checked = ToolBar1.Buttons(0).Pushed
    Call RefreshPatientBox()
  End Sub

#Region "Schedule Menu"

  Private Sub menuScheduleOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuScheduleOpen.Click

    Try
      Call OpenSchedule()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub menuScheduleClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuScheduleClose.Click

    Try
      Call CloseSchedule()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

#End Region

#Region "Setup Menu"

  Private Sub menuSetupADA_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupADA.Click
    Dim F As New ADAConfigForm
    F.ADACodeCollection = ADACodeCollection
    Call F.ShowDialog()
  End Sub

  Private Sub menuSetupPractice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupPractice.Click
    Dim F As New PracticeInfoForm
    F.PracticeInfo = Me.Preferences.PracticeInfo
    Call F.ShowDialog()
  End Sub

  Private Sub menuSetupLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupLogin.Click
    Dim F As New LoginConfigForm
    F.LoginCollection = LoginCollection
    Call F.ShowDialog()
  End Sub

  Private Sub menuSetupProvider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupProvider.Click

    Try
      Call Schedule1.ProviderCollection.LoadXML(GetPath() & "providers.xml")
      Call Schedule1.Dialogs.ShowProviderConfiguration()
      Call Schedule1.ProviderCollection.SaveXML(GetPath() & "providers.xml")
      Call Schedule1.ProviderCollection.Clear()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub menuSetupRoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupRoom.Click

    Try
      Call Schedule1.RoomCollection.LoadXML(GetPath() & "rooms.xml")
      Call Schedule1.Dialogs.ShowRoomConfiguration()
      Call Schedule1.RoomCollection.SaveXML(GetPath() & "rooms.xml")
      Call Schedule1.RoomCollection.Clear()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub menuSetupCategories_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSetupCategories.Click
    Try
      Call Schedule1.CategoryCollection.LoadXML(GetPath() & "categories.xml")
      Call Schedule1.Dialogs.ShowCategoryConfiguration()
      Call Schedule1.CategoryCollection.SaveXML(GetPath() & "categories.xml")
      Call Schedule1.CategoryCollection.Clear()
    Catch ex As Exception
      Call SetErr(ex)
    End Try
  End Sub

#End Region

#Region "Help Menu"

  Private Sub menuContents_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuContents.Click
    Call MsgBox("Add Help Contents Here.", MsgBoxStyle.Information, "Help")
  End Sub

  Private Sub menuSeach_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSeach.Click
    Call MsgBox("Add Help Search Here.", MsgBoxStyle.Information, "Help")
  End Sub

  Private Sub menuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAbout.Click
    Dim F As New AboutForm
    Call F.ShowDialog()
  End Sub

#End Region

  Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick

    Try
      If e.Button Is ToolBar1.Buttons(0) Then
        'Patient Info
        menuPatient.Checked = ToolBar1.Buttons(0).Pushed
        Call RefreshPatientBox()
      ElseIf e.Button Is ToolBar1.Buttons(2) Then
        'Open a Schedule
        Call OpenSchedule()
      ElseIf e.Button Is ToolBar1.Buttons(3) Then
        'Schedule Properties
        Call ShowScheduleFees()
      ElseIf e.Button Is ToolBar1.Buttons(4) Then
        'Find Appointments
        Call ShowFind()
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub ShowFind()

    Try
      Dim F As New AppointmentFindForm
      F.ScheduleObject = Schedule1
      F.AppointmentCollection = Me.ScheduleForm.Schedule1.AppointmentCollection
      F.PatientCollection = Me.PatientCollection
      If F.ShowDialog() = DialogResult.OK Then
        Dim FindF As New AppointmentListForm
        FindF.MDIForm = Me
        FindF.PatientCollection = Me.PatientCollection
        FindF.AppointmentList = F.AppointmentList
        Call FindF.Show()
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub ShowScheduleFees()

    Try
      'Add all fees for the apopointments that are visible in the viewport (day/week/month)
      Dim appointment As Gravitybox.Objects.Appointment
      Dim fees As Decimal = 0
      Dim count As Integer = 0
      For Each appointment In Me.ScheduleForm.Schedule1.AppointmentCollection
        If (Me.ScheduleForm.Schedule1.MinDate <= appointment.StartDate) AndAlso (appointment.StartDate <= Me.ScheduleForm.Schedule1.MaxDate) Then
          fees += GetAppointmentFees(appointment, Me.ADACodeCollection)
          count += 1
        End If
      Next

      Dim text As String = ""
      text &= "Date Range: " & Me.ScheduleForm.Schedule1.MinDate.ToShortDateString & " - " & Me.ScheduleForm.Schedule1.MaxDate.ToShortDateString & ControlChars.CrLf
      text &= "Appointment Count: " & count.ToString & ControlChars.CrLf
      text &= "Total Fees: " & fees.ToString("$0.00") & ControlChars.CrLf
      Call MsgBox(text, MsgBoxStyle.Information, "Information")

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub RefreshPatientBox()
    Me.pnlPatient.Visible = ToolBar1.Buttons(0).Pushed
  End Sub

  Public Function OpenSchedule(ByVal openDate As Date) As ScheduleForm

    Try
      'Create a new schedule window
      ScheduleForm = New ScheduleForm
      ScheduleForm.MdiParent = Me
      ScheduleForm.PatientCollection = Me.PatientCollection
      ScheduleForm.ADACodeCollection = Me.ADACodeCollection
      ScheduleForm.ScheduleDate = openDate
      Call ScheduleForm.LoadForm()
      ScheduleForm.WindowState = FormWindowState.Maximized
      ScheduleForm.Schedule1.Appearance.BackColor = Me.Preferences.BackColor
      ScheduleForm.SetTabDisplay(Me.Preferences.ScheduleDisplay)
      ScheduleForm.Show()
      ScheduleForm.RefreshSize()
      Call UpdateToolbar()
      Return ScheduleForm

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Public Function OpenSchedule() As ScheduleForm

    Try
      Dim newDate As Date = GetDate()
      If newDate = DefaultNoDate Then Return Nothing
      Return OpenSchedule(newDate)

    Catch ex As Exception
      Call SetErr(ex)
    End Try


  End Function

  Private Sub CloseSchedule()
    If Me.MdiChildren.Length > 0 Then
      Call Me.MdiChildren(0).Close()
    End If
  End Sub

  Private Sub MDIForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Call SaveAll()
  End Sub

  Private Sub LoadAll()
    Call Me.ADACodeCollection.LoadXML(GetPath() & "adacodes.xml")
    Call Me.LoginCollection.LoadXML(GetPath() & "logins.xml")
    Preferences = CType(LoadSoapFromFile(GetPath() & "preferences.xml"), Preferences)
    If Preferences Is Nothing Then Preferences = New Preferences
    Call PatientCollection.LoadXML(GetPath() & "patients.xml")
  End Sub

  Private Sub SaveAll()
    Call Me.ADACodeCollection.SaveXML(GetPath() & "adacodes.xml", True)
    Call Me.LoginCollection.SaveXML(GetPath() & "logins.xml", True)
    Call SaveSoapToFile(GetPath() & "preferences.xml", Preferences)
    Call PatientCollection.SaveXML(GetPath() & "patients.xml", True)
  End Sub

  Public Sub UpdateToolbar()

    Try

      menuSetupADA.Enabled = (ScheduleForm Is Nothing)
      menuSetupPractice.Enabled = (ScheduleForm Is Nothing)
      menuSetupProvider.Enabled = (ScheduleForm Is Nothing)
      menuSetupRoom.Enabled = (ScheduleForm Is Nothing)
      menuSetupLogin.Enabled = (ScheduleForm Is Nothing)
      menuSetupCategories.Enabled = (ScheduleForm Is Nothing)
      menuScheduleOpen.Enabled = (ScheduleForm Is Nothing)
      menuScheduleClose.Enabled = Not (ScheduleForm Is Nothing)

      Me.ToolBar1.Buttons(2).Enabled = (ScheduleForm Is Nothing)
      Me.ToolBar1.Buttons(3).Enabled = Not (ScheduleForm Is Nothing)
      Me.ToolBar1.Buttons(4).Enabled = Not (ScheduleForm Is Nothing)

      menuPrint.Enabled = Not (ScheduleForm Is Nothing)
      menuPrintPreview.Enabled = Not (ScheduleForm Is Nothing)

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub menuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPrint.Click

    Try
      Call ScheduleForm.Schedule1.GoPrint()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub menuPrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPrintPreview.Click

    Try
      Call ScheduleForm.Schedule1.GoPreview()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub MDIForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    Call pnlPatient.SetBounds(0, ToolBar1.Height, pnlPatient.Width, Me.ClientSize.Height - ToolBar1.Height)
  End Sub

  Private Sub cmdPatientAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPatientAdd.Click
    Dim patient As PatientItem = Me.PatientCollection.Add("")
    Call EditPatient(patient)
  End Sub

  Private Sub cmdPatientEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPatientEdit.Click

    'Error Check
    If Not (Me.tvwPatient.SelectedNode Is Nothing) Then
      Dim patient As PatientItem = Me.PatientCollection(CType(Me.tvwPatient.SelectedNode.Tag, String))
      Call EditPatient(patient)
    End If

  End Sub

  Private Sub cmdPatientDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPatientDelete.Click

    If Not (tvwPatient.SelectedNode Is Nothing) Then
      Call DeletePatient(CStr(tvwPatient.SelectedNode.Tag))
    End If

  End Sub

  Private Sub LoadPatients()

    Dim lastIndex As Integer = -1
    Dim patient As PatientItem

    'Cache the selected index for reset later
    If Not tvwPatient.SelectedNode Is Nothing Then
      lastIndex = tvwPatient.SelectedNode.Index
    End If

    'Load all patients
    Call tvwPatient.Nodes.Clear()
    For Each patient In Me.PatientCollection
      Dim node As TreeNode = tvwPatient.Nodes.Add(patient.LName & ", " & patient.FName)
      node.Tag = patient.Key
    Next

    'Default to last selected (if possible) or the first node
    If (tvwPatient.Nodes.Count > 0) AndAlso (lastIndex <> -1) Then
      If lastIndex < tvwPatient.Nodes.Count Then tvwPatient.SelectedNode = tvwPatient.Nodes(lastIndex)
      If tvwPatient.SelectedNode Is Nothing Then tvwPatient.SelectedNode = tvwPatient.Nodes(tvwPatient.Nodes.Count - 1)
    Else
      If tvwPatient.SelectedNode Is Nothing Then tvwPatient.SelectedNode = tvwPatient.Nodes(0)
    End If

  End Sub

  Private Sub tvwPatient_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tvwPatient.DoubleClick

    'Edit patient
    If Not (tvwPatient.SelectedNode Is Nothing) Then
      Call EditPatient(CStr(tvwPatient.SelectedNode.Tag))
    End If

  End Sub

  Private Sub EditPatient(ByVal patient As PatientItem)

    'This routine will display the edit patient screen
    Dim F As New PatientForm
    F.PatientItem = patient
    Call F.ShowDialog()
    Call LoadPatients()

  End Sub

  Private Sub EditPatient(ByVal key As String)

    Call EditPatient(PatientCollection(key))

  End Sub

  Private Sub DeletePatient(ByVal key As String)
    Call DeletePatient(PatientCollection(key))
  End Sub

  Private Sub DeletePatient(ByVal patient As PatientItem)

    'ALL schedules must be closed to delete patients
    If Me.MdiChildren.Length > 0 Then
      Call MsgBox("All schedules must be closed to remove a patient!", MsgBoxStyle.Information, "Error!")
      Return
    End If

    'Prompt for removal
    If MsgBox("Do you wish to remove this patient and ALL associated appointments?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then
      Call Me.PatientCollection.Remove(patient)

      'Load the appointments for checking
      Call Schedule1.ProviderCollection.LoadXML(GetPath() & "providers.xml")
      Call Schedule1.RoomCollection.LoadXML(GetPath() & "rooms.xml")
      Call Schedule1.CategoryCollection.LoadXML(GetPath() & "categories.xml")
      Call Schedule1.AppointmentCollection.LoadXML(GetPath() & "appointments.xml")

      'Loop through the appointments to remove all for this patient
      Dim count As Integer
      Dim appointment As Gravitybox.Objects.Appointment
      Dim ii As Integer
      For ii = Schedule1.AppointmentCollection.Count - 1 To 0 Step -1
        appointment = Schedule1.AppointmentCollection(ii)
        'This first PropertyItem is the PatientId
        If appointment.Text.Equals(patient.Key) Then
          'If the appointment is for this Patient then remove it
          Call Schedule1.AppointmentCollection.Remove(appointment)
          count += 1
        End If
      Next

      If count > 0 Then
        'Resave the appointments
        Call Schedule1.AppointmentCollection.SaveXML(GetPath() & "appointments.xml")
      End If

      'Refresh the screen
      Call PatientCollection.SaveXML(GetPath() & "patients.xml")
      Call LoadPatients()

      'Prompt the user with how many appointments were removed
      Call MsgBox("There were " & count & " appointments deleted.", MsgBoxStyle.Information)

    End If

  End Sub

  Private Sub tvwPatient_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvwPatient.ItemDrag
    tvwPatient.DoDragDrop(CType(e.Item, TreeNode), DragDropEffects.Move)
  End Sub

  Private Sub tvwPatient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tvwPatient.KeyPress

    'If pressed <ENTER> then edit patient
    If e.KeyChar.ToString.StartsWith(Chr(Keys.Enter)) Then
      If Not (tvwPatient.SelectedNode Is Nothing) Then
        Call EditPatient(CStr(tvwPatient.SelectedNode.Tag))
      End If
    End If

  End Sub

  Public Function SelectedPatientId() As String

    If Not (tvwPatient.SelectedNode Is Nothing) Then
      Return CStr(tvwPatient.SelectedNode.Tag)
    Else
      Return ""
    End If

  End Function

  Public Function SelectedPatientNode() As TreeNode

    If Not (tvwPatient.SelectedNode Is Nothing) Then
      Return tvwPatient.SelectedNode
    Else
      Return Nothing
    End If

  End Function

End Class
