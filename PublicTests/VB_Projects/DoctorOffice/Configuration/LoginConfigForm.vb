Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class LoginConfigForm
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
  Friend WithEvents lblProperties As System.Windows.Forms.Label
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents lblLine As System.Windows.Forms.Label
  Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
  Friend WithEvents cmdDown As System.Windows.Forms.Button
  Friend WithEvents cmdUp As System.Windows.Forms.Button
  Friend WithEvents cmdDelete As System.Windows.Forms.Button
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents lstMembers As System.Windows.Forms.ListBox
  Friend WithEvents lblMembers As System.Windows.Forms.Label
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LoginConfigForm))
    Me.lblProperties = New System.Windows.Forms.Label()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.lblLine = New System.Windows.Forms.Label()
    Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
    Me.cmdDown = New System.Windows.Forms.Button()
    Me.cmdUp = New System.Windows.Forms.Button()
    Me.cmdDelete = New System.Windows.Forms.Button()
    Me.cmdAdd = New System.Windows.Forms.Button()
    Me.lstMembers = New System.Windows.Forms.ListBox()
    Me.lblMembers = New System.Windows.Forms.Label()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'lblProperties
    '
    Me.lblProperties.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.lblProperties.Location = New System.Drawing.Point(256, 10)
    Me.lblProperties.Name = "lblProperties"
    Me.lblProperties.Size = New System.Drawing.Size(192, 16)
    Me.lblProperties.TabIndex = 23
    Me.lblProperties.Text = "Properties:"
    '
    'ImageList1
    '
    Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'lblLine
    '
    Me.lblLine.BackColor = System.Drawing.Color.Black
    Me.lblLine.Location = New System.Drawing.Point(8, 314)
    Me.lblLine.Name = "lblLine"
    Me.lblLine.Size = New System.Drawing.Size(436, 1)
    Me.lblLine.TabIndex = 24
    '
    'PropertyGrid1
    '
    Me.PropertyGrid1.CommandsVisibleIfAvailable = True
    Me.PropertyGrid1.HelpVisible = False
    Me.PropertyGrid1.LargeButtons = False
    Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
    Me.PropertyGrid1.Location = New System.Drawing.Point(256, 34)
    Me.PropertyGrid1.Name = "PropertyGrid1"
    Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
    Me.PropertyGrid1.Size = New System.Drawing.Size(192, 248)
    Me.PropertyGrid1.TabIndex = 5
    Me.PropertyGrid1.Text = "PropertyGrid"
    Me.PropertyGrid1.ToolbarVisible = False
    Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
    Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
    '
    'cmdDown
    '
    Me.cmdDown.Image = CType(resources.GetObject("cmdDown.Image"), System.Drawing.Bitmap)
    Me.cmdDown.ImageIndex = 1
    Me.cmdDown.ImageList = Me.ImageList1
    Me.cmdDown.Location = New System.Drawing.Point(216, 66)
    Me.cmdDown.Name = "cmdDown"
    Me.cmdDown.Size = New System.Drawing.Size(24, 24)
    Me.cmdDown.TabIndex = 4
    '
    'cmdUp
    '
    Me.cmdUp.Image = CType(resources.GetObject("cmdUp.Image"), System.Drawing.Bitmap)
    Me.cmdUp.ImageIndex = 0
    Me.cmdUp.ImageList = Me.ImageList1
    Me.cmdUp.Location = New System.Drawing.Point(216, 34)
    Me.cmdUp.Name = "cmdUp"
    Me.cmdUp.Size = New System.Drawing.Size(24, 24)
    Me.cmdUp.TabIndex = 3
    '
    'cmdDelete
    '
    Me.cmdDelete.Location = New System.Drawing.Point(144, 282)
    Me.cmdDelete.Name = "cmdDelete"
    Me.cmdDelete.Size = New System.Drawing.Size(64, 24)
    Me.cmdDelete.TabIndex = 2
    Me.cmdDelete.Text = "Delete"
    '
    'cmdAdd
    '
    Me.cmdAdd.Location = New System.Drawing.Point(72, 282)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(64, 24)
    Me.cmdAdd.TabIndex = 1
    Me.cmdAdd.Text = "Add"
    '
    'lstMembers
    '
    Me.lstMembers.Location = New System.Drawing.Point(8, 34)
    Me.lstMembers.Name = "lstMembers"
    Me.lstMembers.Size = New System.Drawing.Size(200, 238)
    Me.lstMembers.TabIndex = 0
    '
    'lblMembers
    '
    Me.lblMembers.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.lblMembers.Location = New System.Drawing.Point(8, 10)
    Me.lblMembers.Name = "lblMembers"
    Me.lblMembers.Size = New System.Drawing.Size(192, 16)
    Me.lblMembers.TabIndex = 22
    Me.lblMembers.Text = "Members:"
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(368, 322)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 7
    Me.cmdCancel.Text = "Cancel"
    '
    'cmdOK
    '
    Me.cmdOK.Location = New System.Drawing.Point(280, 322)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(80, 24)
    Me.cmdOK.TabIndex = 6
    Me.cmdOK.Text = "OK"
    '
    'LoginConfigForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(456, 357)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLine, Me.PropertyGrid1, Me.cmdDown, Me.cmdUp, Me.cmdDelete, Me.cmdAdd, Me.lstMembers, Me.lblMembers, Me.cmdCancel, Me.cmdOK, Me.lblProperties})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "LoginConfigForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Login Codes"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_LoginCollection As LoginCollection
  Private WorkingLoginCollection As New LoginCollection()

  Public Property LoginCollection() As LoginCollection
    Get
      Return m_LoginCollection
    End Get
    Set(ByVal Value As LoginCollection)
      m_LoginCollection = Value

      Try
        'Load a working collection with objects
        Call WorkingLoginCollection.FromXML(Me.LoginCollection.ToXML)
        Call RefreshForm()
        'Default to first item if one exists
        If Me.lstMembers.Items.Count > 0 Then Me.lstMembers.SelectedIndex = 0
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Set
  End Property

  Private Sub RefreshForm()

    Try
      Dim login As LoginItem
      Call Me.lstMembers.Items.Clear()
      For Each login In Me.WorkingLoginCollection
        Call Me.lstMembers.Items.Add(login.Text)
      Next
      Call EnableButtons()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click

    Try
      'Check if there is an item selected
      If lstMembers.SelectedItem Is Nothing Then Return

      'If already first, skip out
      Dim index As Integer = lstMembers.SelectedIndex
      If index = -1 Then Return

      Dim login As LoginItem = WorkingLoginCollection(index)
      Call WorkingLoginCollection.RemoveAt(index)
      Call WorkingLoginCollection.AddObject(login, index - 1)
      Call RefreshForm()
      lstMembers.SelectedIndex = index - 1

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown.Click

    Try
      'Check if there is an item selected
      If lstMembers.SelectedItem Is Nothing Then Return

      'If already last, skip out
      Dim index As Integer = lstMembers.SelectedIndex
      If index = lstMembers.Items.Count - 1 Then Return

      Dim login As LoginItem = WorkingLoginCollection(index)
      Call WorkingLoginCollection.RemoveAt(index)
      Call WorkingLoginCollection.AddObject(login, index + 1)
      Call RefreshForm()
      lstMembers.SelectedIndex = index + 1

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    Try
      Dim login As LoginItem = WorkingLoginCollection.Add("", GetNewName)
      Call Me.lstMembers.Items.Add(login.Text)
      Me.lstMembers.SelectedItem = Me.lstMembers.Items(login.Index)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

    Try
      If Not (Me.lstMembers.SelectedItem Is Nothing) Then
        Dim index As Integer = Me.lstMembers.SelectedIndex
        Me.WorkingLoginCollection.RemoveAt(index)
        Call RefreshForm()
        If Me.lstMembers.Items.Count = 0 Then
          PropertyGrid1.SelectedObject = Nothing
        ElseIf index > (Me.lstMembers.Items.Count - 1) Then
          index = Me.lstMembers.Items.Count - 1
          Me.lstMembers.SelectedIndex = index
        Else
          Me.lstMembers.SelectedIndex = index
        End If
        Call EnableButtons()

      End If
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

    Try
      Call SaveForm()
      Call Me.Close()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Call Me.Close()
  End Sub

  Private Sub LoginConfigForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try
      lblMembers.BackColor = System.Drawing.SystemColors.Control
      lblProperties.BackColor = System.Drawing.SystemColors.Control
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub SaveForm()

    Try
      Call LoginCollection.FromXML(WorkingLoginCollection.ToXML)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Function GetNewName() As String

    Try
      Const BaseName As String = "Login"
      Dim ii As Integer = 1
      Dim text As String
      text = BaseName & ii
      Do While (lstMembers.FindString(text) <> -1)
        ii += 1
        text = BaseName & ii
      Loop
      Return text

    Catch ex As Exception
      Call SetErr(ex)
    End Try
  End Function

  Private Sub LoadObject(ByVal loginIndex As Integer)

    Try
      'Index Key, Parent, PropertyItems
      Me.PropertyGrid1.SelectedObject = WorkingLoginCollection(loginIndex)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub lstMembers_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstMembers.SelectedValueChanged

    Try
      Call LoadObject(lstMembers.SelectedIndex)
      Call EnableButtons()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub EnableButtons()

    Try
      If Me.lstMembers.SelectedIndex = -1 Then
        Me.cmdDown.Enabled = False
        Me.cmdUp.Enabled = False
        Me.cmdDelete.Enabled = False
      Else
        Me.cmdDown.Enabled = (Me.lstMembers.SelectedIndex < Me.lstMembers.Items.Count - 1)
        Me.cmdUp.Enabled = (Me.lstMembers.SelectedIndex > 0)
        Me.cmdDelete.Enabled = (Me.lstMembers.SelectedIndex <> -1)
      End If
      Me.cmdDown.ImageIndex = CInt(IIf(Me.cmdDown.Enabled, 1, 3))
      Me.cmdUp.ImageIndex = CInt(IIf(Me.cmdUp.Enabled, 0, 2))

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged

    Try
      If lstMembers.SelectedIndex <> -1 Then
        Dim index As Integer = lstMembers.SelectedIndex
        Dim text As String = Me.LoginCollection(lstMembers.SelectedIndex).Text
        If (CType(lstMembers.SelectedItem, String) <> text) Then
          lstMembers.Items.Insert(index, Me.LoginCollection(lstMembers.SelectedIndex).Text)
          lstMembers.SelectedIndex = index
          Call lstMembers.Items.RemoveAt(index + 1)
        End If
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

End Class
