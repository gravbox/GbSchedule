Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class PracticeInfoForm
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
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOk As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtName As System.Windows.Forms.TextBox
  Friend WithEvents txtAddress As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtName = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtAddress = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(280, 120)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 3
    Me.cmdCancel.Tag = ""
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdOk
    '
    Me.cmdOk.Location = New System.Drawing.Point(192, 120)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 2
    Me.cmdOk.Text = "&OK"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 16)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Practice Name:"
    '
    'txtName
    '
    Me.txtName.Location = New System.Drawing.Point(104, 8)
    Me.txtName.Name = "txtName"
    Me.txtName.Size = New System.Drawing.Size(256, 20)
    Me.txtName.TabIndex = 0
    Me.txtName.Text = ""
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 16)
    Me.Label2.TabIndex = 6
    Me.Label2.Text = "Address:"
    '
    'txtAddress
    '
    Me.txtAddress.Location = New System.Drawing.Point(104, 32)
    Me.txtAddress.Multiline = True
    Me.txtAddress.Name = "txtAddress"
    Me.txtAddress.Size = New System.Drawing.Size(256, 80)
    Me.txtAddress.TabIndex = 1
    Me.txtAddress.Text = ""
    '
    'PracticeInfoForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(370, 151)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtAddress, Me.Label2, Me.txtName, Me.Label1, Me.cmdCancel, Me.cmdOk})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "PracticeInfoForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Practice Information"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_PracticeInfo As PracticeInfo

  Public Property PracticeInfo() As PracticeInfo
    Get
      Return m_PracticeInfo
    End Get
    Set(ByVal Value As PracticeInfo)
      m_PracticeInfo = Value
      Me.txtName.Text = PracticeInfo.Name
      Me.txtAddress.Text = PracticeInfo.Address
    End Set
  End Property

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    PracticeInfo.Name = Me.txtName.Text
    PracticeInfo.Address = Me.txtAddress.Text
    Call Me.Close()
  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Call Me.Close()
  End Sub

End Class
