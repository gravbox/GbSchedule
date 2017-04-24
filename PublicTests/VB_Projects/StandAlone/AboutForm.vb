Option Explicit On 
Option Strict On

Namespace Gravitybox.Applications.StandAloneDemo

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
    Friend WithEvents cmdOK As FlatUI.Controls.XPButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdOK = New FlatUI.Controls.XPButton
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.lblWebsite = New System.Windows.Forms.LinkLabel
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.BackColor = System.Drawing.SystemColors.Control
      Me.cmdOK.Location = New System.Drawing.Point(272, 264)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(72, 24)
      Me.cmdOK.TabIndex = 0
      Me.cmdOK.Text = "&OK"
      '
      'Label1
      '
      Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(24, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(312, 16)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Gravitybox Schedule.NET for WinForms"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label2
      '
      Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(24, 104)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(312, 16)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "for Microsoft.NET"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Label3
      '
      Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(24, 192)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(312, 16)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Copyright Gravitybox Software LLC 1998-2004"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblWebsite
      '
      Me.lblWebsite.Location = New System.Drawing.Point(24, 216)
      Me.lblWebsite.Name = "lblWebsite"
      Me.lblWebsite.Size = New System.Drawing.Size(312, 16)
      Me.lblWebsite.TabIndex = 5
      Me.lblWebsite.TabStop = True
      Me.lblWebsite.Text = "http://www.gravitybox.com"
      Me.lblWebsite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(352, 48)
      Me.Panel1.TabIndex = 6
      '
      'AboutForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.Window
      Me.ClientSize = New System.Drawing.Size(352, 293)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.lblWebsite)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "AboutForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "About"
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Me.Close()
    End Sub

    Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.Text = "About Gravitytbox Schedule.NET Demo"
    End Sub

    Private Sub lblWebsite_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblWebsite.LinkClicked

      Try
        Call System.Diagnostics.Process.Start(lblWebsite.Text)
      Catch ex As Exception
        'Do Nothing
      End Try

    End Sub

  End Class

End Namespace