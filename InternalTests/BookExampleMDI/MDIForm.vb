Option Strict On
Option Explicit On 

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
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
  Friend WithEvents menuFile As System.Windows.Forms.MenuItem
  Friend WithEvents menuExit As System.Windows.Forms.MenuItem
  Friend WithEvents menuOpen As System.Windows.Forms.MenuItem
  Friend WithEvents menuClose As System.Windows.Forms.MenuItem
  Friend WithEvents menuSave As System.Windows.Forms.MenuItem
  Friend WithEvents menuPrint As System.Windows.Forms.MenuItem
  Friend WithEvents menuPreview As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.menuFile = New System.Windows.Forms.MenuItem()
    Me.menuOpen = New System.Windows.Forms.MenuItem()
    Me.menuSave = New System.Windows.Forms.MenuItem()
    Me.menuPrint = New System.Windows.Forms.MenuItem()
    Me.menuClose = New System.Windows.Forms.MenuItem()
    Me.MenuItem5 = New System.Windows.Forms.MenuItem()
    Me.menuExit = New System.Windows.Forms.MenuItem()
    Me.menuPreview = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.MenuItem3 = New System.Windows.Forms.MenuItem()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile})
    '
    'menuFile
    '
    Me.menuFile.Index = 0
    Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuOpen, Me.menuSave, Me.MenuItem2, Me.menuPreview, Me.menuPrint, Me.MenuItem3, Me.menuClose, Me.MenuItem5, Me.menuExit})
    Me.menuFile.Text = "&File"
    '
    'menuOpen
    '
    Me.menuOpen.Index = 0
    Me.menuOpen.Text = "&Open"
    '
    'menuSave
    '
    Me.menuSave.Index = 1
    Me.menuSave.Text = "&Save"
    '
    'menuPrint
    '
    Me.menuPrint.Index = 4
    Me.menuPrint.Text = "&Print"
    '
    'menuClose
    '
    Me.menuClose.Index = 6
    Me.menuClose.Text = "&Close"
    '
    'MenuItem5
    '
    Me.MenuItem5.Index = 7
    Me.MenuItem5.Text = "-"
    '
    'menuExit
    '
    Me.menuExit.Index = 8
    Me.menuExit.Text = "E&xit"
    '
    'menuPreview
    '
    Me.menuPreview.Index = 3
    Me.menuPreview.Text = "P&review"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 2
    Me.MenuItem2.Text = "-"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 5
    Me.MenuItem3.Text = "-"
    '
    'MDIForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(648, 477)
    Me.IsMdiContainer = True
    Me.Menu = Me.MainMenu1
    Me.Name = "MDIForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"

  End Sub

#End Region

  Dim dateCol As New DateCollection()

  Public Sub CloseDate(ByVal newDate As Date)
    Call dateCol.RemoveAt(newDate)
  End Sub

  Private Sub menuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuOpen.Click

    'Choose the date
    Dim F1 As New DateForm()
    Call F1.ShowDialog()
    If Not F1.IsSet Then Return
    Dim newDate As Date = GetDate(F1.DateValue)

    'Check to determine if the date is open
    'and if so do not open it again
    If dateCol.Exists(newDate) Then
      Call MsgBox("This date window is already opened!", MsgBoxStyle.Exclamation)
      Return
    End If
    Call dateCol.Add(newDate)

    'Load a screen for this date
    Dim F2 As New ChildForm()
    F2.MdiParent = Me
    Call F2.LoadRooms()
    F2.ScheduleDate = newDate
    Call F2.Show()
    Call RefreshMenus()

  End Sub

  Private Sub menuClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuClose.Click

    'If there is a form to close then do so
    If Not (Me.ActiveMdiChild Is Nothing) Then
      Call Me.ActiveMdiChild.Close()
    End If
    Call RefreshMenus()

  End Sub

  Private Sub menuSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSave.Click

    'If there is a form to save then do so
    If Not (Me.ActiveMdiChild Is Nothing) Then
      Dim F As ChildForm
      F = CType(Me.ActiveMdiChild, ChildForm)
      Call F.SaveFile()
    End If
    Call RefreshMenus()

  End Sub

  Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
    Call Me.Close()
    Call RefreshMenus()
  End Sub

  Private Sub menuFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuFile.Click
    Call RefreshMenus()
  End Sub

  Private Sub menuPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPrint.Click

    'If there is a form to print then do so
    If Not (Me.ActiveMdiChild Is Nothing) Then
      Dim F As ChildForm
      F = CType(Me.ActiveMdiChild, ChildForm)
      Call F.Schedule1.GoPrint()
    End If
    Call RefreshMenus()

  End Sub

  Private Sub menuPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuPreview.Click

    'If there is a form to preview then do so
    If Not (Me.ActiveMdiChild Is Nothing) Then
      Dim F As ChildForm
      F = CType(Me.ActiveMdiChild, ChildForm)
      Call F.Schedule1.GoPreview()
    End If
    Call RefreshMenus()

    Dim X As Gravitybox.Objects.PrintDialogSettings
    'X.PrinterSettings.p

  End Sub

  Public Sub RefreshMenus()

    Dim windowOpen As Boolean = Not (Me.ActiveMdiChild Is Nothing)
    menuClose.Enabled = windowOpen
    menuSave.Enabled = windowOpen
    menuPrint.Enabled = windowOpen
    menuPreview.Enabled = windowOpen

  End Sub

  Private Sub MDIForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Call RefreshMenus()
  End Sub

End Class
