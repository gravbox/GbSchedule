Option Explicit On 
Option Strict On

Namespace Gravitybox.Applications.StandAloneDemo

  Public Class SplashForm
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.pnlBottom = New System.Windows.Forms.Panel
      Me.Label1 = New System.Windows.Forms.Label
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.pnlBottom.SuspendLayout()
      Me.SuspendLayout()
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1500
      '
      'pnlBottom
      '
      Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
      Me.pnlBottom.Controls.Add(Me.Label1)
      Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnlBottom.Location = New System.Drawing.Point(0, 174)
      Me.pnlBottom.Name = "pnlBottom"
      Me.pnlBottom.Size = New System.Drawing.Size(454, 48)
      Me.pnlBottom.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(272, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(176, 16)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "http://www.gravitybox.com"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(454, 48)
      Me.Panel1.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(24, 64)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(376, 48)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Gravitybox Schedule.NET"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(88, 112)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(336, 24)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Demo Application"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'SplashForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.Window
      Me.ClientSize = New System.Drawing.Size(454, 222)
      Me.ControlBox = False
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.pnlBottom)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SplashForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.TopMost = True
      Me.pnlBottom.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Me.Close()
    End Sub

  End Class

End Namespace