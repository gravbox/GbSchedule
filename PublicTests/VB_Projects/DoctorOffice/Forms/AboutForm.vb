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
  Friend WithEvents lblLine As System.Windows.Forms.Label
  Friend WithEvents cmdOk As System.Windows.Forms.Button
  Friend WithEvents lblHeader As System.Windows.Forms.Label
  Friend WithEvents lblLicenseHeader As System.Windows.Forms.Label
  Friend WithEvents lblLicenseInfo As System.Windows.Forms.Label
  Friend WithEvents lblCopyright As System.Windows.Forms.Label
  Friend WithEvents lblGraphic As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblHeader = New System.Windows.Forms.Label()
    Me.lblLicenseHeader = New System.Windows.Forms.Label()
    Me.lblLicenseInfo = New System.Windows.Forms.Label()
    Me.lblLine = New System.Windows.Forms.Label()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.lblCopyright = New System.Windows.Forms.Label()
    Me.lblGraphic = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lblHeader
    '
    Me.lblHeader.Location = New System.Drawing.Point(104, 8)
    Me.lblHeader.Name = "lblHeader"
    Me.lblHeader.Size = New System.Drawing.Size(336, 56)
    Me.lblHeader.TabIndex = 1
    '
    'lblLicenseHeader
    '
    Me.lblLicenseHeader.Location = New System.Drawing.Point(104, 88)
    Me.lblLicenseHeader.Name = "lblLicenseHeader"
    Me.lblLicenseHeader.Size = New System.Drawing.Size(336, 16)
    Me.lblLicenseHeader.TabIndex = 2
    Me.lblLicenseHeader.Text = "This product is licensed to"
    '
    'lblLicenseInfo
    '
    Me.lblLicenseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblLicenseInfo.Location = New System.Drawing.Point(104, 112)
    Me.lblLicenseInfo.Name = "lblLicenseInfo"
    Me.lblLicenseInfo.Size = New System.Drawing.Size(336, 32)
    Me.lblLicenseInfo.TabIndex = 3
    '
    'lblLine
    '
    Me.lblLine.BackColor = System.Drawing.Color.Black
    Me.lblLine.Location = New System.Drawing.Point(8, 160)
    Me.lblLine.Name = "lblLine"
    Me.lblLine.Size = New System.Drawing.Size(432, 1)
    Me.lblLine.TabIndex = 4
    Me.lblLine.Text = "Label4"
    '
    'cmdOk
    '
    Me.cmdOk.Location = New System.Drawing.Point(360, 208)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 5
    Me.cmdOk.Text = "OK"
    '
    'lblCopyright
    '
    Me.lblCopyright.Location = New System.Drawing.Point(8, 176)
    Me.lblCopyright.Name = "lblCopyright"
    Me.lblCopyright.Size = New System.Drawing.Size(344, 56)
    Me.lblCopyright.TabIndex = 6
    '
    'lblGraphic
    '
    Me.lblGraphic.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.lblGraphic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblGraphic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblGraphic.Location = New System.Drawing.Point(8, 8)
    Me.lblGraphic.Name = "lblGraphic"
    Me.lblGraphic.Size = New System.Drawing.Size(88, 136)
    Me.lblGraphic.TabIndex = 7
    Me.lblGraphic.Text = "Your Graphic Here"
    Me.lblGraphic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'AboutForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(448, 239)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGraphic, Me.lblCopyright, Me.cmdOk, Me.lblLine, Me.lblLicenseInfo, Me.lblLicenseHeader, Me.lblHeader})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Name = "AboutForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "AboutForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    Call Me.Close()
  End Sub

  Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try
      Me.Text = "About Doctor Office Demo"
      lblCopyright.Text = "Warning: This program is protected by the copyright law. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties and will be prosecuted to the maximum extent possible under law."
      lblHeader.Text = "Gravitybox Doctor Office Demo Application    Version: 1.0" & Chr(13) & Chr(10) & "Copyright  (c) 2002 Gravitybox LLC    All Rights Reserved"
      lblLicenseInfo.Text = "Test Company" & Chr(13) & Chr(10) & "Test Name"
    Catch
      Throw
    End Try

  End Sub

End Class
