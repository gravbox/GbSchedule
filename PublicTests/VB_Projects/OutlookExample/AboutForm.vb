Option Strict On
Option Explicit On 

Public Class AboutForm
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
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents lblHeader As System.Windows.Forms.Label
  Friend WithEvents lblCopyright As System.Windows.Forms.Label
  Friend WithEvents lblWarning As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AboutForm))
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.lblHeader = New System.Windows.Forms.Label()
    Me.lblCopyright = New System.Windows.Forms.Label()
    Me.lblWarning = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'cmdOK
    '
    Me.cmdOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdOK.Location = New System.Drawing.Point(272, 232)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(80, 24)
    Me.cmdOK.TabIndex = 0
    Me.cmdOK.Text = "OK"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
    Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(63, 246)
    Me.PictureBox1.TabIndex = 1
    Me.PictureBox1.TabStop = False
    '
    'lblHeader
    '
    Me.lblHeader.Location = New System.Drawing.Point(80, 8)
    Me.lblHeader.Name = "lblHeader"
    Me.lblHeader.Size = New System.Drawing.Size(280, 48)
    Me.lblHeader.TabIndex = 2
    '
    'lblCopyright
    '
    Me.lblCopyright.Location = New System.Drawing.Point(80, 64)
    Me.lblCopyright.Name = "lblCopyright"
    Me.lblCopyright.Size = New System.Drawing.Size(280, 16)
    Me.lblCopyright.TabIndex = 3
    '
    'lblWarning
    '
    Me.lblWarning.Location = New System.Drawing.Point(80, 144)
    Me.lblWarning.Name = "lblWarning"
    Me.lblWarning.Size = New System.Drawing.Size(280, 80)
    Me.lblWarning.TabIndex = 4
    '
    'AboutForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(362, 263)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWarning, Me.lblCopyright, Me.lblHeader, Me.PictureBox1, Me.cmdOK})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AboutForm"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "About"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
    Call Me.Close()
  End Sub

  Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.Text = "About Gravitybox Outlook Example"
    lblHeader.Text = "This is a sample application to demonstrate the abilities of Gravitybox Schedule."
    lblCopyright.Text = "Gravitybox Copyright © 1998-2002"
    lblWarning.Text = "Warning: This program is protected by the copyright law. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties and will be prosecuted to the maximum extent possible under law."

  End Sub

End Class
