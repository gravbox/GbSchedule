Option Explicit On 
Option Strict On

Imports Gravitybox
Imports Gravitybox.Objects
Imports Gravitybox.Controls
Imports FlatUI.Controls

Namespace Gravitybox.Applications.StandAloneDemo

  Public Class MainForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Me.Size = New Size(CInt(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width * 0.8), CInt(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * 0.8))

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
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarpnlNavBar As System.Windows.Forms.StatusBarPanel
    Friend WithEvents StatusBarPanel2 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents pnlNavBar As System.Windows.Forms.Panel
    Friend WithEvents calSchedule As System.Windows.Forms.MonthCalendar
    Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
    Friend WithEvents hdrSchedule As Gravitybox.Controls.Header
    Friend WithEvents VsNetMenuProvider1 As VSNetMenuProvider
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmdNew As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDay1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDay5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDay7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDay31 As System.Windows.Forms.ToolBarButton
    Friend WithEvents menuFile As System.Windows.Forms.MenuItem
    Friend WithEvents menuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents menuFileNew As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents menuView As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewNavBar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewDay As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewWorkWeek As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewWeek As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewMonth As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewStatus As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelp As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelpAbout As System.Windows.Forms.MenuItem
    Friend WithEvents Toolbar1 As FlatUI.Controls.FlatToolbar
    Friend WithEvents menuEdit As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditCut As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditCopy As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditPaste As System.Windows.Forms.MenuItem
    Friend WithEvents lstRoom As System.Windows.Forms.CheckedListBox
    Friend WithEvents hdrProvider As Gravitybox.Controls.Header
    Friend WithEvents menuEditEdit As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditDelete As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetup As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetupProvider As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetupCategory As System.Windows.Forms.MenuItem
    Friend WithEvents menuViewProvider As System.Windows.Forms.MenuItem
    Friend WithEvents TriggerTimer As System.Windows.Forms.Timer
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents menuEditSearch As System.Windows.Forms.MenuItem
    Friend WithEvents hdrCalendar As Gravitybox.Controls.Header
    Friend WithEvents pnlVBuffer As System.Windows.Forms.Panel
    Friend WithEvents menuFileSave As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents menuSetupOptions As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents menuHelpHelp As System.Windows.Forms.MenuItem
    Friend WithEvents menuFilePrint As System.Windows.Forms.MenuItem
    Friend WithEvents menuFilePrintPreview As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents cmdSearch As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MainForm))
      Me.Toolbar1 = New FlatUI.Controls.FlatToolbar
      Me.cmdNew = New System.Windows.Forms.ToolBarButton
      Me.cmdEdit = New System.Windows.Forms.ToolBarButton
      Me.cmdDelete = New System.Windows.Forms.ToolBarButton
      Me.cmdDay1 = New System.Windows.Forms.ToolBarButton
      Me.cmdDay5 = New System.Windows.Forms.ToolBarButton
      Me.cmdDay7 = New System.Windows.Forms.ToolBarButton
      Me.cmdDay31 = New System.Windows.Forms.ToolBarButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.MainMenu1 = New System.Windows.Forms.MainMenu
      Me.menuFile = New System.Windows.Forms.MenuItem
      Me.menuFileNew = New System.Windows.Forms.MenuItem
      Me.menuFileSave = New System.Windows.Forms.MenuItem
      Me.MenuItem4 = New System.Windows.Forms.MenuItem
      Me.menuFilePrint = New System.Windows.Forms.MenuItem
      Me.menuFilePrintPreview = New System.Windows.Forms.MenuItem
      Me.MenuItem10 = New System.Windows.Forms.MenuItem
      Me.menuFileExit = New System.Windows.Forms.MenuItem
      Me.menuEdit = New System.Windows.Forms.MenuItem
      Me.menuEditEdit = New System.Windows.Forms.MenuItem
      Me.menuEditDelete = New System.Windows.Forms.MenuItem
      Me.MenuItem6 = New System.Windows.Forms.MenuItem
      Me.menuEditCut = New System.Windows.Forms.MenuItem
      Me.menuEditCopy = New System.Windows.Forms.MenuItem
      Me.menuEditPaste = New System.Windows.Forms.MenuItem
      Me.MenuItem3 = New System.Windows.Forms.MenuItem
      Me.menuEditSearch = New System.Windows.Forms.MenuItem
      Me.menuView = New System.Windows.Forms.MenuItem
      Me.menuViewNavBar = New System.Windows.Forms.MenuItem
      Me.menuViewProvider = New System.Windows.Forms.MenuItem
      Me.MenuItem1 = New System.Windows.Forms.MenuItem
      Me.menuViewDay = New System.Windows.Forms.MenuItem
      Me.menuViewWorkWeek = New System.Windows.Forms.MenuItem
      Me.menuViewWeek = New System.Windows.Forms.MenuItem
      Me.menuViewMonth = New System.Windows.Forms.MenuItem
      Me.MenuItem2 = New System.Windows.Forms.MenuItem
      Me.menuViewStatus = New System.Windows.Forms.MenuItem
      Me.menuSetup = New System.Windows.Forms.MenuItem
      Me.menuSetupCategory = New System.Windows.Forms.MenuItem
      Me.menuSetupProvider = New System.Windows.Forms.MenuItem
      Me.MenuItem5 = New System.Windows.Forms.MenuItem
      Me.menuSetupOptions = New System.Windows.Forms.MenuItem
      Me.menuHelp = New System.Windows.Forms.MenuItem
      Me.menuHelpHelp = New System.Windows.Forms.MenuItem
      Me.MenuItem7 = New System.Windows.Forms.MenuItem
      Me.menuHelpAbout = New System.Windows.Forms.MenuItem
      Me.StatusBar1 = New System.Windows.Forms.StatusBar
      Me.StatusBarpnlNavBar = New System.Windows.Forms.StatusBarPanel
      Me.StatusBarPanel2 = New System.Windows.Forms.StatusBarPanel
      Me.pnlNavBar = New System.Windows.Forms.Panel
      Me.lstRoom = New System.Windows.Forms.CheckedListBox
      Me.hdrProvider = New Gravitybox.Controls.Header
      Me.calSchedule = New System.Windows.Forms.MonthCalendar
      Me.hdrCalendar = New Gravitybox.Controls.Header
      Me.Schedule1 = New Gravitybox.Controls.Schedule
      Me.hdrSchedule = New Gravitybox.Controls.Header
      Me.VsNetMenuProvider1 = New FlatUI.Controls.VSNetMenuProvider(Me.components)
      Me.TriggerTimer = New System.Windows.Forms.Timer(Me.components)
      Me.pnlVBuffer = New System.Windows.Forms.Panel
      Me.cmdSearch = New System.Windows.Forms.ToolBarButton
      CType(Me.StatusBarpnlNavBar, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlNavBar.SuspendLayout()
      Me.SuspendLayout()
      '
      'Toolbar1
      '
      Me.Toolbar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdNew, Me.cmdEdit, Me.cmdDelete, Me.cmdDay1, Me.cmdDay5, Me.cmdDay7, Me.cmdDay31, Me.cmdSearch})
      Me.Toolbar1.ButtonSize = New System.Drawing.Size(16, 16)
      Me.Toolbar1.DropDownArrows = True
      Me.Toolbar1.ImageList = Me.ImageList1
      Me.Toolbar1.Location = New System.Drawing.Point(0, 0)
      Me.Toolbar1.Name = "Toolbar1"
      Me.Toolbar1.ShowToolTips = True
      Me.Toolbar1.Size = New System.Drawing.Size(632, 26)
      Me.Toolbar1.TabIndex = 10
      Me.Toolbar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.Toolbar1.Wrappable = False
      '
      'cmdNew
      '
      Me.cmdNew.ImageIndex = 0
      Me.cmdNew.Text = "New"
      '
      'cmdEdit
      '
      Me.cmdEdit.ImageIndex = 1
      Me.cmdEdit.Text = "Edit"
      '
      'cmdDelete
      '
      Me.cmdDelete.ImageIndex = 2
      Me.cmdDelete.Text = "Delete"
      '
      'cmdDay1
      '
      Me.cmdDay1.ImageIndex = 3
      Me.cmdDay1.Text = "Day"
      '
      'cmdDay5
      '
      Me.cmdDay5.ImageIndex = 4
      Me.cmdDay5.Text = "Work Week"
      '
      'cmdDay7
      '
      Me.cmdDay7.ImageIndex = 5
      Me.cmdDay7.Text = "Week"
      '
      'cmdDay31
      '
      Me.cmdDay31.ImageIndex = 6
      Me.cmdDay31.Text = "Month"
      '
      'ImageList1
      '
      Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      '
      'MainMenu1
      '
      Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuEdit, Me.menuView, Me.menuSetup, Me.menuHelp})
      '
      'menuFile
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFile, -1)
      Me.menuFile.Index = 0
      Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFileNew, Me.menuFileSave, Me.MenuItem4, Me.menuFilePrint, Me.menuFilePrintPreview, Me.MenuItem10, Me.menuFileExit})
      Me.menuFile.OwnerDraw = True
      Me.menuFile.Text = "&File"
      '
      'menuFileNew
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFileNew, 0)
      Me.menuFileNew.Index = 0
      Me.menuFileNew.OwnerDraw = True
      Me.menuFileNew.Text = "&New"
      '
      'menuFileSave
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFileSave, -1)
      Me.menuFileSave.Index = 1
      Me.menuFileSave.OwnerDraw = True
      Me.menuFileSave.Text = "&Save"
      '
      'MenuItem4
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem4, -1)
      Me.MenuItem4.Index = 2
      Me.MenuItem4.OwnerDraw = True
      Me.MenuItem4.Text = "-"
      '
      'menuFilePrint
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFilePrint, -1)
      Me.menuFilePrint.Index = 3
      Me.menuFilePrint.OwnerDraw = True
      Me.menuFilePrint.Text = "&Print"
      '
      'menuFilePrintPreview
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFilePrintPreview, -1)
      Me.menuFilePrintPreview.Index = 4
      Me.menuFilePrintPreview.OwnerDraw = True
      Me.menuFilePrintPreview.Text = "Print Pre&view"
      '
      'MenuItem10
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem10, -1)
      Me.MenuItem10.Index = 5
      Me.MenuItem10.OwnerDraw = True
      Me.MenuItem10.Text = "-"
      '
      'menuFileExit
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuFileExit, -1)
      Me.menuFileExit.Index = 6
      Me.menuFileExit.OwnerDraw = True
      Me.menuFileExit.Text = "E&xit"
      '
      'menuEdit
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEdit, -1)
      Me.menuEdit.Index = 1
      Me.menuEdit.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuEditEdit, Me.menuEditDelete, Me.MenuItem6, Me.menuEditCut, Me.menuEditCopy, Me.menuEditPaste, Me.MenuItem3, Me.menuEditSearch})
      Me.menuEdit.OwnerDraw = True
      Me.menuEdit.Text = "&Edit"
      '
      'menuEditEdit
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditEdit, 1)
      Me.menuEditEdit.Index = 0
      Me.menuEditEdit.OwnerDraw = True
      Me.menuEditEdit.Text = "&Edit"
      '
      'menuEditDelete
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditDelete, 2)
      Me.menuEditDelete.Index = 1
      Me.menuEditDelete.OwnerDraw = True
      Me.menuEditDelete.Text = "&Delete"
      '
      'MenuItem6
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem6, -1)
      Me.MenuItem6.Index = 2
      Me.MenuItem6.OwnerDraw = True
      Me.MenuItem6.Text = "-"
      '
      'menuEditCut
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditCut, 7)
      Me.menuEditCut.Index = 3
      Me.menuEditCut.OwnerDraw = True
      Me.menuEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
      Me.menuEditCut.Text = "Cu&t"
      '
      'menuEditCopy
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditCopy, 8)
      Me.menuEditCopy.Index = 4
      Me.menuEditCopy.OwnerDraw = True
      Me.menuEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
      Me.menuEditCopy.Text = "&Copy"
      '
      'menuEditPaste
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditPaste, 9)
      Me.menuEditPaste.Index = 5
      Me.menuEditPaste.OwnerDraw = True
      Me.menuEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
      Me.menuEditPaste.Text = "&Paste"
      '
      'MenuItem3
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem3, -1)
      Me.MenuItem3.Index = 6
      Me.MenuItem3.OwnerDraw = True
      Me.MenuItem3.Text = "-"
      '
      'menuEditSearch
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuEditSearch, 11)
      Me.menuEditSearch.Index = 7
      Me.menuEditSearch.OwnerDraw = True
      Me.menuEditSearch.Text = "&Search"
      '
      'menuView
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuView, -1)
      Me.menuView.Index = 2
      Me.menuView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuViewNavBar, Me.menuViewProvider, Me.MenuItem1, Me.menuViewDay, Me.menuViewWorkWeek, Me.menuViewWeek, Me.menuViewMonth, Me.MenuItem2, Me.menuViewStatus})
      Me.menuView.OwnerDraw = True
      Me.menuView.Text = "&View"
      '
      'menuViewNavBar
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewNavBar, 10)
      Me.menuViewNavBar.Index = 0
      Me.menuViewNavBar.OwnerDraw = True
      Me.menuViewNavBar.Text = "&Navigation Bar"
      '
      'menuViewProvider
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewProvider, -1)
      Me.menuViewProvider.Index = 1
      Me.menuViewProvider.OwnerDraw = True
      Me.menuViewProvider.Text = "View by &Provider"
      '
      'MenuItem1
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem1, -1)
      Me.MenuItem1.Index = 2
      Me.MenuItem1.OwnerDraw = True
      Me.MenuItem1.Text = "-"
      '
      'menuViewDay
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewDay, 3)
      Me.menuViewDay.Index = 3
      Me.menuViewDay.OwnerDraw = True
      Me.menuViewDay.Text = "&Day"
      '
      'menuViewWorkWeek
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewWorkWeek, 4)
      Me.menuViewWorkWeek.Index = 4
      Me.menuViewWorkWeek.OwnerDraw = True
      Me.menuViewWorkWeek.Text = "Wor&k Week"
      '
      'menuViewWeek
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewWeek, 5)
      Me.menuViewWeek.Index = 5
      Me.menuViewWeek.OwnerDraw = True
      Me.menuViewWeek.Text = "&Week"
      '
      'menuViewMonth
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewMonth, 6)
      Me.menuViewMonth.Index = 6
      Me.menuViewMonth.OwnerDraw = True
      Me.menuViewMonth.Text = "&Month"
      '
      'MenuItem2
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem2, -1)
      Me.MenuItem2.Index = 7
      Me.MenuItem2.OwnerDraw = True
      Me.MenuItem2.Text = "-"
      '
      'menuViewStatus
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuViewStatus, -1)
      Me.menuViewStatus.Index = 8
      Me.menuViewStatus.OwnerDraw = True
      Me.menuViewStatus.Text = "&Status bar"
      '
      'menuSetup
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuSetup, -1)
      Me.menuSetup.Index = 3
      Me.menuSetup.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuSetupCategory, Me.menuSetupProvider, Me.MenuItem5, Me.menuSetupOptions})
      Me.menuSetup.OwnerDraw = True
      Me.menuSetup.Text = "&Setup"
      '
      'menuSetupCategory
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuSetupCategory, -1)
      Me.menuSetupCategory.Index = 0
      Me.menuSetupCategory.OwnerDraw = True
      Me.menuSetupCategory.Text = "&Categories"
      '
      'menuSetupProvider
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuSetupProvider, -1)
      Me.menuSetupProvider.Index = 1
      Me.menuSetupProvider.OwnerDraw = True
      Me.menuSetupProvider.Text = "&Providers"
      '
      'MenuItem5
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem5, -1)
      Me.MenuItem5.Index = 2
      Me.MenuItem5.OwnerDraw = True
      Me.MenuItem5.Text = "-"
      '
      'menuSetupOptions
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuSetupOptions, -1)
      Me.menuSetupOptions.Index = 3
      Me.menuSetupOptions.OwnerDraw = True
      Me.menuSetupOptions.Text = "&Options"
      '
      'menuHelp
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuHelp, -1)
      Me.menuHelp.Index = 4
      Me.menuHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuHelpHelp, Me.MenuItem7, Me.menuHelpAbout})
      Me.menuHelp.OwnerDraw = True
      Me.menuHelp.Text = "&Help"
      '
      'menuHelpHelp
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuHelpHelp, -1)
      Me.menuHelpHelp.Index = 0
      Me.menuHelpHelp.OwnerDraw = True
      Me.menuHelpHelp.Text = "&Help"
      '
      'MenuItem7
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.MenuItem7, -1)
      Me.MenuItem7.Index = 1
      Me.MenuItem7.OwnerDraw = True
      Me.MenuItem7.Text = "-"
      '
      'menuHelpAbout
      '
      Me.VsNetMenuProvider1.SetImageIndex(Me.menuHelpAbout, -1)
      Me.menuHelpAbout.Index = 2
      Me.menuHelpAbout.OwnerDraw = True
      Me.menuHelpAbout.Text = "&About"
      '
      'StatusBar1
      '
      Me.StatusBar1.Location = New System.Drawing.Point(0, 383)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarpnlNavBar, Me.StatusBarPanel2})
      Me.StatusBar1.ShowPanels = True
      Me.StatusBar1.Size = New System.Drawing.Size(632, 22)
      Me.StatusBar1.TabIndex = 0
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarpnlNavBar
      '
      Me.StatusBarpnlNavBar.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
      Me.StatusBarpnlNavBar.Width = 516
      '
      'pnlNavBar
      '
      Me.pnlNavBar.Controls.Add(Me.lstRoom)
      Me.pnlNavBar.Controls.Add(Me.hdrProvider)
      Me.pnlNavBar.Controls.Add(Me.calSchedule)
      Me.pnlNavBar.Controls.Add(Me.hdrCalendar)
      Me.pnlNavBar.Dock = System.Windows.Forms.DockStyle.Left
      Me.pnlNavBar.Location = New System.Drawing.Point(0, 26)
      Me.pnlNavBar.Name = "pnlNavBar"
      Me.pnlNavBar.Size = New System.Drawing.Size(192, 357)
      Me.pnlNavBar.TabIndex = 4
      '
      'lstRoom
      '
      Me.lstRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstRoom.CheckOnClick = True
      Me.lstRoom.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lstRoom.IntegralHeight = False
      Me.lstRoom.Location = New System.Drawing.Point(0, 203)
      Me.lstRoom.Name = "lstRoom"
      Me.lstRoom.Size = New System.Drawing.Size(192, 154)
      Me.lstRoom.TabIndex = 7
      '
      'hdrProvider
      '
      Me.hdrProvider.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.hdrProvider.Appearance.BorderColor = System.Drawing.SystemColors.WindowFrame
      Me.hdrProvider.Appearance.FontSize = 10.0!
      Me.hdrProvider.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrProvider.Dock = System.Windows.Forms.DockStyle.Top
      Me.hdrProvider.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
      Me.hdrProvider.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrProvider.Location = New System.Drawing.Point(0, 179)
      Me.hdrProvider.Name = "hdrProvider"
      Me.hdrProvider.Size = New System.Drawing.Size(192, 24)
      Me.hdrProvider.TabIndex = 6
      '
      'calSchedule
      '
      Me.calSchedule.Dock = System.Windows.Forms.DockStyle.Top
      Me.calSchedule.Location = New System.Drawing.Point(0, 24)
      Me.calSchedule.Name = "calSchedule"
      Me.calSchedule.TabIndex = 5
      Me.calSchedule.TitleBackColor = System.Drawing.Color.Silver
      Me.calSchedule.TitleForeColor = System.Drawing.Color.Black
      Me.calSchedule.TrailingForeColor = System.Drawing.Color.Silver
      '
      'hdrCalendar
      '
      Me.hdrCalendar.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.hdrCalendar.Appearance.BorderColor = System.Drawing.SystemColors.WindowFrame
      Me.hdrCalendar.Appearance.FontSize = 10.0!
      Me.hdrCalendar.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrCalendar.Dock = System.Windows.Forms.DockStyle.Top
      Me.hdrCalendar.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
      Me.hdrCalendar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrCalendar.Location = New System.Drawing.Point(0, 0)
      Me.hdrCalendar.Name = "hdrCalendar"
      Me.hdrCalendar.Size = New System.Drawing.Size(192, 24)
      Me.hdrCalendar.TabIndex = 8
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
      Me.Schedule1.Location = New System.Drawing.Point(198, 50)
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
      Me.Schedule1.Size = New System.Drawing.Size(434, 333)
      Me.Schedule1.StartTime = New Date(CType(0, Long))
      Me.Schedule1.TabIndex = 9
      '
      'hdrSchedule
      '
      Me.hdrSchedule.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.hdrSchedule.Appearance.BorderColor = System.Drawing.SystemColors.WindowFrame
      Me.hdrSchedule.Appearance.FontBold = True
      Me.hdrSchedule.Appearance.FontSize = 12.0!
      Me.hdrSchedule.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrSchedule.Dock = System.Windows.Forms.DockStyle.Top
      Me.hdrSchedule.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold)
      Me.hdrSchedule.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.hdrSchedule.Location = New System.Drawing.Point(198, 26)
      Me.hdrSchedule.Name = "hdrSchedule"
      Me.hdrSchedule.Size = New System.Drawing.Size(434, 24)
      Me.hdrSchedule.TabIndex = 8
      '
      'VsNetMenuProvider1
      '
      Me.VsNetMenuProvider1.ImageList = Me.ImageList1
      '
      'TriggerTimer
      '
      Me.TriggerTimer.Interval = 150
      '
      'pnlVBuffer
      '
      Me.pnlVBuffer.BackColor = System.Drawing.Color.White
      Me.pnlVBuffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlVBuffer.Dock = System.Windows.Forms.DockStyle.Left
      Me.pnlVBuffer.Location = New System.Drawing.Point(192, 26)
      Me.pnlVBuffer.Name = "pnlVBuffer"
      Me.pnlVBuffer.Size = New System.Drawing.Size(6, 357)
      Me.pnlVBuffer.TabIndex = 11
      '
      'cmdSearch
      '
      Me.cmdSearch.ImageIndex = 11
      Me.cmdSearch.Text = "Search"
      '
      'MainForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(632, 405)
      Me.Controls.Add(Me.Schedule1)
      Me.Controls.Add(Me.hdrSchedule)
      Me.Controls.Add(Me.pnlVBuffer)
      Me.Controls.Add(Me.pnlNavBar)
      Me.Controls.Add(Me.StatusBar1)
      Me.Controls.Add(Me.Toolbar1)
      Me.Menu = Me.MainMenu1
      Me.Name = "MainForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Gravitybox Schedule.NET Demo"
      CType(Me.StatusBarpnlNavBar, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.StatusBarPanel2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlNavBar.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Public Enum DisplayModeConstants
      Day = 0
      WorkWeek = 1
      Week = 2
      Month = 3
    End Enum

    Private ReadOnly OutOfRangeColor As Color = Color.FromArgb(&HFF, &HF4, &HBC)
    Private ReadOnly BackColorNormal As Color = Color.FromArgb(&HFF, &HFF, &HD5)
    Private ReadOnly BackColorMonth As Color = Color.White

    Private _useSettings As Boolean = True
    Private _useStatus As Boolean = True
    Private _viewByProviders As Boolean = False
    Private _displayMode As DisplayModeConstants = DisplayModeConstants.Day
    Private ClipboardAppointments As New ArrayList
    Private SearchDialog As SearchForm
    Private LockKeys As New ArrayList
    Private _useAppointmentHeader As Boolean
    Private _useAppointmentIcons As Boolean
    Private _useColoredAppointment As Boolean
    Private _useNoDropArea As Boolean
    Private _useRoundAppointment As Boolean
    Private _useTransparentAppointment As Boolean

#End Region

#Region "Property Implementations"

    Private Property DisplayMode() As DisplayModeConstants
      Get
        Return _displayMode
      End Get
      Set(ByVal Value As DisplayModeConstants)

        Dim lockKey As String = PrepareForProcessing()
        Try
          _displayMode = Value
          menuViewDay.Checked = (Value = DisplayModeConstants.Day)
          menuViewWorkWeek.Checked = (Value = DisplayModeConstants.WorkWeek)
          menuViewWeek.Checked = (Value = DisplayModeConstants.Week)
          menuViewMonth.Checked = (Value = DisplayModeConstants.Month)
          Me.SelectedDateChanged(calSchedule.SelectionStart)

          If Value = DisplayModeConstants.Month Then
            'If in month mode...
            Schedule1.Appearance.BackColor = BackColorMonth
            Schedule1.ViewMode = Schedule.ViewModeConstants.MonthFull
          ElseIf Value = DisplayModeConstants.Week Then
            'If in week mode...
            Schedule1.Appearance.BackColor = BackColorMonth
            Schedule1.ViewMode = Schedule.ViewModeConstants.Week
          Else
            'If in any other mode...
            Schedule1.Appearance.BackColor = BackColorNormal
            If ViewByProviders Then
              'Use the RoomCollection to show providers
              Schedule1.ViewMode = Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Else
              Schedule1.ViewMode = Schedule.ViewModeConstants.DayTopTimeLeft
            End If
          End If

          'Now redraw the schedule
          Me.DrawSchedule()

        Catch ex As Exception
          SetErr(ex)
        Finally
          PrepareForProcessing(lockKey)
        End Try

      End Set
    End Property

    Private Property UseStatus() As Boolean
      Get
        Return _useStatus
      End Get
      Set(ByVal Value As Boolean)
        _useStatus = Value

        StatusBar1.Visible = UseStatus
        If UseStatus Then
          VsNetMenuProvider1.SetImageIndex(menuViewStatus, 10)
        Else
          VsNetMenuProvider1.SetImageIndex(menuViewStatus, -1)
        End If

      End Set
    End Property

    Private Property UseSettings() As Boolean
      Get
        Return _useSettings
      End Get
      Set(ByVal Value As Boolean)
        _useSettings = Value

        pnlNavBar.Visible = UseSettings
        If UseSettings Then
          VsNetMenuProvider1.SetImageIndex(menuViewNavBar, 10)
        Else
          VsNetMenuProvider1.SetImageIndex(menuViewNavBar, -1)
        End If

      End Set
    End Property

    Private Property UseAppointmentHeader() As Boolean
      Get
        Return _useAppointmentHeader
      End Get
      Set(ByVal Value As Boolean)
        _useAppointmentHeader = Value
        DrawSchedule()
      End Set
    End Property

    Public Property UseAppointmentIcons() As Boolean
      Get
        Return _useAppointmentIcons
      End Get
      Set(ByVal Value As Boolean)
        _useAppointmentIcons = Value
        DrawSchedule()
      End Set
    End Property

    Public Property UseColoredAppointment() As Boolean
      Get
        Return _useColoredAppointment
      End Get
      Set(ByVal Value As Boolean)
        _useColoredAppointment = Value
        DrawSchedule()
      End Set
    End Property

    Public Property UseNoDropArea() As Boolean
      Get
        Return _useNoDropArea
      End Get
      Set(ByVal Value As Boolean)
        _useNoDropArea = Value
        DrawSchedule()
      End Set
    End Property

    Public Property UseRoundAppointment() As Boolean
      Get
        Return _useRoundAppointment
      End Get
      Set(ByVal Value As Boolean)
        _useRoundAppointment = Value
        DrawSchedule()
      End Set
    End Property

    Public Property UseTransparentAppointment() As Boolean
      Get
        Return _useTransparentAppointment
      End Get
      Set(ByVal Value As Boolean)
        _useTransparentAppointment = Value
        DrawSchedule()
      End Set
    End Property

    Private Property ViewByProviders() As Boolean
      Get
        Return _viewByProviders
      End Get
      Set(ByVal Value As Boolean)

        _viewByProviders = Value

        If ViewByProviders Then
          VsNetMenuProvider1.SetImageIndex(menuViewProvider, 10)
        Else
          VsNetMenuProvider1.SetImageIndex(menuViewProvider, -1)
        End If
        Me.DisplayMode = Me.DisplayMode 'Refresh the view
        Me.DrawSchedule()

      End Set
    End Property

    Private ReadOnly Property ScheduleCacheFile() As String
      Get
        Return AppPath() & "schedule.xml"
      End Get
    End Property

    Private ReadOnly Property ConfigurationFile() As String
      Get
        Return AppPath() & "configuration.xml"
      End Get
    End Property

#End Region

#Region "Form Events"

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      'Show the splash screen
      Me.ShowSplash()

      'Initialize Schedule
      Schedule1.Appearance.BackColor = BackColorNormal
      Schedule1.Appearance.ForeColor = Color.FromArgb(&HF6, &HDB, &HA2)
      Schedule1.Font = New Font("Verdana", 8)

      Schedule1.Selector.Appearance.BackColor = Color.FromArgb(&H84, &H92, &HB4)

      Schedule1.ColumnHeader.Appearance.BackColor = Color.FromArgb(&HF2, &HF1, &HE1)
      Schedule1.ColumnHeader.Appearance.BackColor2 = Color.FromArgb(&HD5, &HD1, &HCA)
      Schedule1.ColumnHeader.Appearance.FontSize = 8
      Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
      Schedule1.ColumnHeader.AutoFit = True

      Schedule1.RowHeader.Appearance.BackColor = Color.FromArgb(&HF2, &HF1, &HE1)
      Schedule1.RowHeader.Appearance.BackColor2 = Color.FromArgb(&HD5, &HD1, &HCA)
      Schedule1.RowHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal
      Schedule1.RowHeader.Appearance.FontSize = 8
      Schedule1.RowHeader.Size = 20

      Schedule1.RoomCollection.ObjectSingular = "Provider"
      Schedule1.RoomCollection.ObjectPlural = "Providers"

      Schedule1.StartTime = #12:00:00 AM#
      Schedule1.DayLength = 24

      'Colored Areas
      Me.SetupColoredAreas()

      'Initialize Headers
      hdrProvider.Text = "Providers"
      hdrProvider.Appearance.BackColor = Color.FromArgb(&HCB, &HC0, &HC7)
      hdrProvider.Appearance.BackColor2 = Color.FromArgb(&H80, &H80, &H80)
      hdrProvider.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
      hdrProvider.Appearance.ForeColor = Color.White
      hdrProvider.Appearance.BorderColor = hdrProvider.Appearance.BackColor2
      hdrProvider.Appearance.FontSize = 12
      hdrProvider.Appearance.FontBold = True

      hdrSchedule.Text = "Schedule"
      hdrSchedule.Appearance.BackColor = Color.FromArgb(&HCB, &HC0, &HC7)
      hdrSchedule.Appearance.BackColor2 = Color.FromArgb(&H80, &H80, &H80)
      hdrSchedule.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
      hdrSchedule.Appearance.ForeColor = Color.White
      hdrSchedule.Appearance.BorderColor = hdrSchedule.Appearance.BackColor2
      hdrSchedule.Appearance.FontSize = 12
      hdrSchedule.Appearance.FontBold = True

      hdrCalendar.Text = "Calendar"
      hdrCalendar.Appearance.BackColor = Color.FromArgb(&HCB, &HC0, &HC7)
      hdrCalendar.Appearance.BackColor2 = Color.FromArgb(&H80, &H80, &H80)
      hdrCalendar.Appearance.BackGradientStyle = GradientStyleConstants.Vertical
      hdrCalendar.Appearance.ForeColor = Color.White
      hdrCalendar.Appearance.BorderColor = hdrCalendar.Appearance.BackColor2
      hdrCalendar.Appearance.FontSize = 12
      hdrCalendar.Appearance.FontBold = True

      'Initialize menus
      VsNetMenuProvider1.SetImageIndex(menuViewNavBar, 10)
      VsNetMenuProvider1.SetImageIndex(menuViewStatus, 10)
      menuViewDay.Checked = True

      calSchedule.ForeColor = Color.Black
      calSchedule.TrailingForeColor = Color.FromArgb(&HCB, &HC0, &HC7)
      calSchedule.TitleBackColor = Color.FromArgb(&HCB, &HC0, &HC7)
      calSchedule.TitleForeColor = Color.Black

      'Load Data
      Me.LoadSchedule()
      Me.DrawSchedule()
      Me.DisplayMode = Me.DisplayMode 'Refresh
      Schedule1.Visibility.ShowTime(#8:00:00 AM#)

    End Sub

    Private Sub MainForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Me.SaveSchedule()
    End Sub

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

      If Me.WindowState = FormWindowState.Minimized Then
        If Not (SearchDialog Is Nothing) Then
          SearchDialog.Visible = False
        End If
      Else
        If Not (SearchDialog Is Nothing) Then
          SearchDialog.Visible = True
        End If
      End If

    End Sub

#End Region

#Region "Schedule Events"

		Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentAdd

			'Give each appointment a shadow effect
			CType(e.BaseObject, Appointment).Appearance.ShadowSize = 6

		End Sub

		Private Sub Schedule1_AfterSelectedItemChange(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterSelectedItemChange
			Me.UpdateMenus()
		End Sub

		Private Sub Schedule1_AfterUserAppointmentAdd(ByVal sender As Object, ByVal e As Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterUserAppointmentAdd

			'If there is no room then assign one
			Dim appointment As appointment = CType(e.BaseObject, appointment)
			If (appointment.Room Is Nothing) Then
				If Schedule1.RoomCollection.Count > 0 Then
					appointment.Room = Schedule1.RoomCollection(0)
				End If
			End If

		End Sub

		Private Sub Schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Objects.EventArgs.BeforePropertyDialogEventArgs) Handles Schedule1.BeforePropertyDialog
			e.DialogSettings.AllowRoom = True
			e.DialogSettings.AllowProvider = False
			DrawSchedule()
		End Sub

#End Region

#Region "Menus"

    Private Sub menuFileNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileNew.Click

      Try
        Dim appointment As appointment = Schedule1.CreateDefaultAppointment()
        Schedule1.SelectedItem = appointment
        Me.UpdateMenus()
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub menuFileSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileSave.Click
      Me.SaveSchedule()
    End Sub

    Private Sub menuFilePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFilePrint.Click
      Schedule1.GoPrint()
    End Sub

    Private Sub menuFilePrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFilePrintPreview.Click
      Schedule1.GoPreview()
    End Sub

    Private Sub menuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileExit.Click
      Me.Close()
    End Sub

    Private Sub menuEditEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditEdit.Click

      If Not (Schedule1.SelectedItem Is Nothing) Then
        Schedule1.Dialogs.ShowPropertyDialog(Schedule1.SelectedItem)
        Me.UpdateMenus()
      End If

    End Sub

    Private Sub menuEditDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditDelete.Click

      If Not (Schedule1.SelectedItem Is Nothing) Then
        If MsgBox("Do you wish to delete the selected appointment?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then
          Schedule1.AppointmentCollection.Remove(Schedule1.SelectedItem)
          Me.UpdateMenus()
        End If
      End If

    End Sub

    Private Sub menuEditCut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditCut.Click

      Me.ClearGhosted()
      Me.ClipboardAppointments.Clear()
      For Each appointment As appointment In Schedule1.SelectedItems
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
					appointment = CType(appointment.Clone, Appointment)
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

    Private Sub menuEditSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuEditSearch.Click

      Try
        If SearchDialog Is Nothing Then
          SearchDialog = New SearchForm(Me)
        End If
        SearchDialog.WindowState = FormWindowState.Normal
        SearchDialog.Show()
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub menuViewNavBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewNavBar.Click
      UseSettings = Not UseSettings
    End Sub

    Private Sub menuViewProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewProvider.Click
      ViewByProviders = Not ViewByProviders
    End Sub

    Private Sub menuViewDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewDay.Click
      DisplayMode = DisplayModeConstants.Day
    End Sub

    Private Sub menuViewWorkWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewWorkWeek.Click
      DisplayMode = DisplayModeConstants.WorkWeek
    End Sub

    Private Sub menuViewWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewWeek.Click
      DisplayMode = DisplayModeConstants.Week
    End Sub

    Private Sub menuViewMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewMonth.Click
      DisplayMode = DisplayModeConstants.Month
    End Sub

    Private Sub menuViewStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuViewStatus.Click
      UseStatus = Not UseStatus
    End Sub

    Private Sub menuSetupCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetupCategory.Click
      Schedule1.Dialogs.ShowCategoryConfiguration()
    End Sub

    Private Sub menuSetupProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetupProvider.Click

      Try
        Dim settings As New ConfigurationDialogSettings
        settings.WindowText = "Provider Configuration"
        Schedule1.Dialogs.ShowRoomConfiguration(settings)
        Me.LoadProviders()
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub menuSetupOptions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetupOptions.Click

      Dim lockKey As String = PrepareForProcessing()
      Try
        Dim F As New OptionsForm
        F.UseAutoFitColumns = Schedule1.ColumnHeader.AutoFit
        F.UseAppointmentHeader = Me.UseAppointmentHeader
        F.UseAppointmentIcons = Me.UseAppointmentIcons
        F.UseColoredAppointment = Me.UseColoredAppointment
        F.UseNoDropArea = Me.UseNoDropArea
        F.UseRoundAppointment = Me.UseRoundAppointment
        F.UseTransparentAppointment = Me.UseTransparentAppointment
        F.ConflictDisplay = Schedule1.ConflictDisplay

        If F.ShowDialog = DialogResult.OK Then
          Schedule1.ColumnHeader.AutoFit = F.UseAutoFitColumns
          Me.UseAppointmentHeader = F.UseAppointmentHeader
          Me.UseAppointmentIcons = F.UseAppointmentIcons
          Me.UseColoredAppointment = F.UseColoredAppointment
          Me.UseNoDropArea = F.UseNoDropArea
          Me.UseRoundAppointment = F.UseRoundAppointment
          Me.UseTransparentAppointment = F.UseTransparentAppointment
          Schedule1.ConflictDisplay = F.ConflictDisplay
        End If

      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

    Private Sub menuHelpHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHelpHelp.Click

      Try
        Call System.Diagnostics.Process.Start(AppPath() & "demo.help.txt")
      Catch ex As Exception
        'Do Nothing
      End Try

    End Sub

    Private Sub menuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuHelpAbout.Click

      Try
        Dim F As New AboutForm
        F.ShowDialog()
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

#End Region

#Region "DrawSchedule"

    Private Sub DrawSchedule()

      Dim lockKey As String = PrepareForProcessing()
      Try
        Schedule1.SetMinMaxDate(calSchedule.SelectionStart, calSchedule.SelectionEnd)

        'If viewing by providers then make visible invisible
        If ViewByProviders Then
          'Get a list of selected providers
          Dim providerList As ArrayList = GetCheckedProviders()

          For Each appointment As Appointment In Schedule1.AppointmentCollection
            Dim isVisible As Boolean = False
            For Each key As String In providerList
              If appointment.Room Is Nothing Then
                isVisible = True
              Else
                isVisible = isVisible Or (appointment.Room.Key = key)
              End If
            Next
            appointment.Visible = isVisible
          Next
        End If

        'Set the other properties
        For Each appointment As Appointment In Schedule1.AppointmentCollection
          'Use the header?
          If UseAppointmentHeader Then
            appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.TimeHeader
            appointment.Header.Icon = Schedule1.ScheduleIcons.IconInfo
          Else
            appointment.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.None
          End If

          If Me.UseAppointmentIcons Then
            If appointment.IconCollection.Count = 0 Then
              'Assign some random icons for demo
              appointment.IconCollection.Add("", Schedule1.DefaultIcons.IconAttention)
              appointment.IconCollection.Add("", Schedule1.DefaultIcons.IconClip)
              appointment.IconCollection.Add("", Schedule1.DefaultIcons.IconWarning)
            End If
          Else
            appointment.IconCollection.Clear()
          End If

          'Color the appointment or leave it white?
          If Me.UseColoredAppointment Then
            appointment.Appearance.BackColor = Color.LightBlue
          Else
            appointment.Appearance.BackColor = Color.White
          End If

          'Set the appointment round or square
          appointment.Appearance.IsRound = Me.UseRoundAppointment

          'Set the appointment transparency to some pleasant level
          If Me.UseTransparentAppointment Then
            appointment.Appearance.Transparency = 40
          Else
            appointment.Appearance.Transparency = 0
          End If

        Next

        'Add a blocked lunch hour if requested
        If Me.UseNoDropArea Then
          If Schedule1.NoDropAreaCollection.Count = 0 Then
            Dim area As ScheduleArea = Schedule1.NoDropAreaCollection.Add("", Color.LightSalmon, #12:00:00 PM#, 60)
            area.Appearance.BorderWidth = 0
            area.Appearance.ForeColor = Color.White
            area.Appearance.Alignment = StringAlignment.Center
            area.Appearance.TextVAlign = StringAlignment.Center
            area.Text = "Out To Lunch"
          End If
        Else
          Schedule1.NoDropAreaCollection.Clear()
        End If

        Me.UpdateMenus()

      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

#End Region

#Region "Calendar Events"

    Private Sub SelectedDateChanged(ByVal newStart As Date)

      Dim startDate As Date = newStart
      Dim endDate As Date

      Dim lockKey As String = PrepareForProcessing()
      Try
        If Me.DisplayMode = DisplayModeConstants.Day Then
          endDate = startDate
        ElseIf Me.DisplayMode = DisplayModeConstants.WorkWeek Then
          startDate = startDate.AddDays(-startDate.DayOfWeek + 1)
          endDate = startDate.AddDays(4)
        ElseIf Me.DisplayMode = DisplayModeConstants.Week Then
          startDate = startDate.AddDays(-startDate.DayOfWeek)
          endDate = startDate.AddDays(6)
        ElseIf Me.DisplayMode = DisplayModeConstants.Month Then
          endDate = startDate
        End If

        calSchedule.SelectionStart = startDate
        calSchedule.SelectionEnd = endDate
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try


    End Sub

    Private Sub calSchedule_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles calSchedule.DateChanged
      Me.DrawSchedule()
    End Sub

    Private Sub calSchedule_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles calSchedule.DateSelected
      Me.SelectedDateChanged(e.Start)
    End Sub

#End Region

#Region "Toolbar Events"

    Private Sub Toolbar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles Toolbar1.ButtonClick

      Try
        If e.Button Is cmdNew Then
          menuFileNew.PerformClick()
        ElseIf e.Button Is cmdEdit Then
          menuEditEdit.PerformClick()
        ElseIf e.Button Is cmdDelete Then
          menuEditDelete.PerformClick()
        ElseIf e.Button Is cmdDay1 Then
          menuViewDay.PerformClick()
        ElseIf e.Button Is cmdDay5 Then
          menuViewWorkWeek.PerformClick()
        ElseIf e.Button Is cmdDay7 Then
          menuViewWeek.PerformClick()
        ElseIf e.Button Is cmdDay31 Then
          menuViewMonth.PerformClick()
        ElseIf e.Button Is cmdSearch Then
          menuEditSearch.PerformClick()
        End If
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Methods"

    Private Sub ClearGhosted()

      Try
        For Each appointment As appointment In Schedule1.AppointmentCollection
          If appointment.Appearance.Ghosted Then
            appointment.Appearance.Ghosted = False
            If Me.ClipboardAppointments.Contains(appointment.Key) Then
              Me.ClipboardAppointments.Remove(appointment.Key)
            End If
          End If
        Next
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub UpdateMenus()

      Try
        Dim isSelected As Boolean = Not (Schedule1.SelectedItem Is Nothing)
        cmdDelete.Enabled = isSelected
        cmdEdit.Enabled = isSelected
        cmdNew.Enabled = True

        menuEditCopy.Enabled = (Schedule1.SelectedItems.Count > 0)
        menuEditCut.Enabled = (Schedule1.SelectedItems.Count > 0)
        menuEditPaste.Enabled = (ClipboardAppointments.Count > 0) AndAlso (Schedule1.SelectedItem Is Nothing)
        menuEditEdit.Enabled = isSelected
        menuEditDelete.Enabled = isSelected
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub LoadProviders()
      LoadProviders(False)
    End Sub

    Private Sub LoadProviders(ByVal ignoreDisplay As Boolean)

      Dim lockKey As String = PrepareForProcessing()
      Try

        'Get the checked providers
        Dim providerList As ArrayList = GetCheckedProviders()

        'Load the new items
        If Not ignoreDisplay Then
          lstRoom.Items.Clear()
          If Not SearchDialog Is Nothing Then SearchDialog.lstRoom.Items.Clear()
          For Each room As Gravitybox.Objects.Room In Schedule1.RoomCollection
            'Add the provider
            lstRoom.Items.Add(room)
            If Not SearchDialog Is Nothing Then SearchDialog.lstRoom.Items.Add(room)

            'If this object was checked then check it again
            If providerList.Contains(room.Key) Then
              lstRoom.SetItemChecked(lstRoom.Items.Count - 1, True)
            End If
          Next
        End If

        ShowAppointmentSubSet()

      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

    Private Sub ShowSplash()

      Try
        Dim F As New SplashForm
        F.ShowDialog()
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub SetupColoredAreas()

      Dim lockKey As String = PrepareForProcessing()
      Try
        Dim area As ScheduleArea
        area = Schedule1.ColoredAreaCollection.Add("", OutOfRangeColor, #12:00:00 AM#, 480)
        area = Schedule1.ColoredAreaCollection.Add("", OutOfRangeColor, #5:00:00 PM#, 420)

        'Setup each area's properties
        For Each area In Schedule1.ColoredAreaCollection
          area.Appearance.BorderWidth = 0
          area.Appearance.ForeColor = Color.LightGray
          area.Appearance.Alignment = StringAlignment.Center
          area.Appearance.TextVAlign = StringAlignment.Center
          area.Text = "Out Of Range"
        Next
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

    Private Function GetCheckedProviders() As ArrayList

      Dim lockKey As String = PrepareForProcessing()
      Try
        Dim retval As New ArrayList
        For ii As Integer = 0 To lstRoom.Items.Count - 1
          If lstRoom.GetItemChecked(ii) Then
            Dim room As Gravitybox.Objects.Room = CType(lstRoom.Items(ii), Gravitybox.Objects.Room)
            retval.Add(room.Key)
          End If
        Next
        Return retval
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Function

    Public Sub SetDate(ByVal newDate As Date)
      Try
        calSchedule.SelectionStart = newDate
        Me.DisplayMode = Me.DisplayMode
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Public Sub CloseSearch()

      Try
        If Not (SearchDialog Is Nothing) Then
          Dim F As SearchForm = SearchDialog
          SearchDialog = Nothing
          F.Close()
        End If
      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub ShowAppointmentSubSet()

      'Get the checked providers
      Dim providerList As ArrayList = GetCheckedProviders()

      Dim lockKey As String = PrepareForProcessing()
      Try
        'Hide all
        For Each appointment As Appointment In Schedule1.AppointmentCollection
          appointment.Visible = False
        Next

        'Show those we want to see
        For Each key As String In providerList
          For Each appointment As Appointment In Schedule1.AppointmentCollection
            If appointment.Room Is Nothing Then
              appointment.Visible = True
            ElseIf (appointment.Room.Key = key) Then
              appointment.Visible = True
            End If
          Next
        Next

      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

#End Region

#Region "PrepareForProcessing"

    Public Function PrepareForProcessing() As String

      Dim key As String = Guid.NewGuid.ToString
      LockKeys.Add(key)

			'Me.Enabled = False
      Schedule1.AutoRedraw = False

      Return key

    End Function

    Public Sub PrepareForProcessing(ByVal key As String)

      If LockKeys.Contains(key) Then
        LockKeys.Remove(key)
      Else
        Debug.WriteLine("No key found!")
      End If

      If LockKeys.Count = 0 Then
				'Me.Enabled = True
        Schedule1.AutoRedraw = True
      End If

    End Sub

#End Region

#Region "Load/Save"

    Private Sub SaveSchedule()

      Dim lockKey As String = PrepareForProcessing()
      Try
        'Delete the schedule file
        Dim fileName As String = ScheduleCacheFile
        If System.IO.File.Exists(fileName) Then
          System.IO.File.Delete(fileName)
        End If

        'Save the dataset to disk
        Dim ds As DataSet = CType(Schedule1.DataSource, DataSet)
        ds.WriteXml(fileName, XmlWriteMode.WriteSchema)

        'Save the configuration
        Me.SaveConfiguration()
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

    Private Sub LoadSchedule()

      Dim lockKey As String = PrepareForProcessing()
      Try
        Dim fileName As String = ScheduleCacheFile
        Dim ds As New DataSet
        If System.IO.File.Exists(fileName) Then
          ds.ReadXml(fileName, XmlReadMode.ReadSchema)
        Else
          ds = New ScheduleDataset
        End If
        Schedule1.DataSource = ds
        Schedule1.Bind()

        'Load the configuration
        Me.LoadProviders()
        Me.LoadConfiguration()

      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

    Private Sub LoadConfiguration()

      Try
        Dim document As New Xml.XmlDocument
        document.Load(Me.ConfigurationFile)

        'Create the provider node
        Dim providerListNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("selectedproviders")

        'Now mark the providers as checked so on the next load we can reset them
        For Each providerNode As Xml.XmlNode In providerListNode.ChildNodes
          Dim index As Integer = Schedule1.RoomCollection.IndexOf(providerNode.InnerText)
          If index <> -1 Then
            lstRoom.SetItemChecked(index, True)
          End If
        Next

        'Load the last selected date
        Dim dateNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("selecteddate")
        If Not (dateNode Is Nothing) Then
          calSchedule.SetDate(CType(dateNode.InnerText, Date))
          document.DocumentElement.AppendChild(dateNode)
        End If

        'Load the Row Height
        Dim rowHeightNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("rowheight")
        If Not (rowHeightNode Is Nothing) Then
          Schedule1.RowHeader.Size = CInt(rowHeightNode.InnerText)
        End If

        'Load the last display mode
        Dim displayNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("displaymode")
        If Not (displayNode Is Nothing) Then
          Me.DisplayMode = CType([Enum].Parse(GetType(DisplayModeConstants), displayNode.InnerText), DisplayModeConstants)
          document.DocumentElement.AppendChild(displayNode)
        End If

        'Load the View by Provider
        Dim viewProviderNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("viewbyproviders")
        If Not (viewProviderNode Is Nothing) Then
          ViewByProviders = Convert.ToBoolean(viewProviderNode.InnerText)
        End If

        'Create the settings
        Dim settingNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("usesettings")
        If Not (settingNode Is Nothing) Then
          Me.UseSettings = Convert.ToBoolean(settingNode.InnerText)
        End If

        'Create the status bar
        Dim statusBarNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("usestatusbar")
        If Not (statusBarNode Is Nothing) Then
          Me.UseStatus = Convert.ToBoolean(statusBarNode.InnerText)
        End If

        'Create the UseAppointmentHeader
        Dim appointmentHeaderNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("useappointmentheader")
        If Not (appointmentHeaderNode Is Nothing) Then
          Me.UseAppointmentHeader = Convert.ToBoolean(appointmentHeaderNode.InnerText)
        End If

        'Create the AutoFitColumn
        Dim autofitcolumnsNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("autofitcolumns")
        If Not (autofitcolumnsNode Is Nothing) Then
          Me.Schedule1.ColumnHeader.AutoFit = Convert.ToBoolean(autofitcolumnsNode.InnerText)
        End If

        'Create the UseAppointmentIcons
        Dim useAppointmentIconsNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("useappointmenticons")
        If Not (useAppointmentIconsNode Is Nothing) Then
          Me.UseAppointmentIcons = Convert.ToBoolean(useAppointmentIconsNode.InnerText)
        End If

        'Create the UseColoredAppointment
        Dim useColoredAppointmentNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("usecoloredappointment")
        If Not (useColoredAppointmentNode Is Nothing) Then
          Me.UseColoredAppointment = Convert.ToBoolean(useColoredAppointmentNode.InnerText)
        End If

        'Create the UseNoDropArea
        Dim useNoDropAreaNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("usenodroparea")
        If Not (useNoDropAreaNode Is Nothing) Then
          Me.UseNoDropArea = Convert.ToBoolean(useNoDropAreaNode.InnerText)
        End If

        'Create the UseRoundAppointment
        Dim useRoundAppointmentNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("useroundappointment")
        If Not (useRoundAppointmentNode Is Nothing) Then
          Me.UseRoundAppointment = Convert.ToBoolean(useRoundAppointmentNode.InnerText)
        End If

        'Create the UseTransparentAppointment
        Dim useTransparentAppointmentNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("usetransparentappointment")
        If Not (useTransparentAppointmentNode Is Nothing) Then
          Me.UseTransparentAppointment = Convert.ToBoolean(useTransparentAppointmentNode.InnerText)
        End If

        'Create the ConflictDisplay
        Dim conflictDisplayNode As Xml.XmlNode = document.DocumentElement.SelectSingleNode("conflictdisplay")
        If Not (conflictDisplayNode Is Nothing) Then
          Schedule1.ConflictDisplay = CType([Enum].Parse(GetType(Gravitybox.Controls.Schedule.ConflictDisplayConstants), conflictDisplayNode.InnerText), Gravitybox.Controls.Schedule.ConflictDisplayConstants)
        End If

      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Sub SaveConfiguration()

      Try
        Dim document As New Xml.XmlDocument
        document.LoadXml("<configuration></configuration>")

        'Create the provider node
        Dim providerListNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "selectedproviders", "")
        document.DocumentElement.AppendChild(providerListNode)

        'Get the checked providers
        Dim providerList As ArrayList = GetCheckedProviders()

        'Now mark the providers as checked so on the next load we can reset them
        For Each room As Gravitybox.Objects.Room In Schedule1.RoomCollection
          If providerList.Contains(room.Key) Then
            Dim providerNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "provider", "")
            providerNode.InnerText = room.Key
            providerListNode.AppendChild(providerNode)
          End If
        Next

        'Create the last selected date
        Dim dateNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "selecteddate", "")
        dateNode.InnerText = calSchedule.SelectionStart.ToString("yyyy-MM-dd")
        document.DocumentElement.AppendChild(dateNode)

        'Create the last display mode
        Dim displayNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "displaymode", "")
        displayNode.InnerText = Me.DisplayMode.ToString("d")
        document.DocumentElement.AppendChild(displayNode)

        'Create the View by Provider
        Dim viewProviderNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "viewbyproviders", "")
        viewProviderNode.InnerText = Me.ViewByProviders.ToString
        document.DocumentElement.AppendChild(viewProviderNode)

        'Create the RowHeight
        Dim rowHeightNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "rowheight", "")
        If Schedule1.IsHeaderFixed Then
          rowHeightNode.InnerText = Schedule1.RowHeader.Size.ToString
          document.DocumentElement.AppendChild(rowHeightNode)
        End If

        'Create the settings
        Dim settingNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "usesettings", "")
        settingNode.InnerText = Me.UseSettings.ToString
        document.DocumentElement.AppendChild(settingNode)

        'Create the status bar
        Dim statusBarNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "usestatusbar", "")
        statusBarNode.InnerText = Me.UseStatus.ToString
        document.DocumentElement.AppendChild(statusBarNode)

        'Create the UseAppointmentHeader
        Dim appointmentHeaderNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "useappointmentheader", "")
        appointmentHeaderNode.InnerText = Me.UseAppointmentHeader.ToString
        document.DocumentElement.AppendChild(appointmentHeaderNode)

        'Create the UseAppointmentHeader
        Dim autofitcolumnsNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "autofitcolumns", "")
        autofitcolumnsNode.InnerText = Schedule1.ColumnHeader.AutoFit.ToString
        document.DocumentElement.AppendChild(autofitcolumnsNode)

        'Create the UseAppointmentIcons
        Dim useAppointmentIconsNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "useappointmenticons", "")
        useAppointmentIconsNode.InnerText = Me.UseAppointmentIcons.ToString
        document.DocumentElement.AppendChild(useAppointmentIconsNode)

        'Create the UseColoredAppointment
        Dim useColoredAppointmentNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "usecoloredappointment", "")
        useColoredAppointmentNode.InnerText = Me.UseColoredAppointment.ToString
        document.DocumentElement.AppendChild(useColoredAppointmentNode)

        'Create the UseNoDropArea
        Dim useNoDropAreaNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "usenodroparea", "")
        useNoDropAreaNode.InnerText = Me.UseNoDropArea.ToString
        document.DocumentElement.AppendChild(useNoDropAreaNode)

        'Create the UseRoundAppointment
        Dim useRoundAppointmentNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "useroundappointment", "")
        useRoundAppointmentNode.InnerText = Me.UseRoundAppointment.ToString
        document.DocumentElement.AppendChild(useRoundAppointmentNode)

        'Create the UseTransparentAppointment
        Dim useTransparentAppointmentNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "usetransparentappointment", "")
        useTransparentAppointmentNode.InnerText = Me.UseTransparentAppointment.ToString
        document.DocumentElement.AppendChild(useTransparentAppointmentNode)

        'Create the ConflictDisplay
        Dim conflictDisplayNode As Xml.XmlNode = document.CreateNode(Xml.XmlNodeType.Element, "conflictdisplay", "")
        conflictDisplayNode.InnerText = Schedule1.ConflictDisplay.ToString("d")
        document.DocumentElement.AppendChild(conflictDisplayNode)

        document.Save(Me.ConfigurationFile)

      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

    Private Function AppPath() As String

      Try
        Dim retval As String = Application.ExecutablePath
        retval = New System.IO.DirectoryInfo(retval).Parent.FullName
        If Not retval.EndsWith("\") Then retval &= "\"
        Return retval
        'Return Application.StartupPath

      Catch ex As Exception
        System.Diagnostics.EventLog.WriteEntry(System.Reflection.Assembly.GetExecutingAssembly.FullName, ex.ToString())
      End Try

    End Function

#End Region

#Region "Provider Checklist Events"

    Private Sub lstRoom_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles lstRoom.ItemCheck

      Dim lockKey As String = PrepareForProcessing()
      Try
        'Do not uncheck the last item
        If lstRoom.CheckedItems.Count = 1 Then
          e.NewValue = CheckState.Checked
        End If
        TriggerTimer.Enabled = True
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

#End Region

#Region "Timer Trigger"

    Private Sub TriggerTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TriggerTimer.Tick

      Dim lockKey As String = PrepareForProcessing()
      Try
        TriggerTimer.Enabled = False
        Me.LoadProviders(True)
        ShowAppointmentSubSet()
      Catch ex As Exception
        SetErr(ex)
      Finally
        PrepareForProcessing(lockKey)
      End Try

    End Sub

#End Region

  End Class

End Namespace