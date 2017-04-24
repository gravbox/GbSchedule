Option Explicit On 
Option Strict On

Public Class StartForm
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
  Friend WithEvents cmdDemo As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdDemo = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'cmdDemo
    '
    Me.cmdDemo.Location = New System.Drawing.Point(24, 8)
    Me.cmdDemo.Name = "cmdDemo"
    Me.cmdDemo.Size = New System.Drawing.Size(112, 32)
    Me.cmdDemo.TabIndex = 0
    Me.cmdDemo.Text = "Demo Start"
    '
    'StartForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(168, 45)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDemo})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "StartForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "StartForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdDemo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDemo.Click

    Dim F As ScheduleForm

    'Launch Server
    'TODO

    'Display form 1
    F = New ScheduleForm()
    F.Location = New Point(0, 0)
    'F.Schedule1.ServerName = "localhost"
    'F.Schedule1.ServerPort = "8090"
    'F.Schedule1.ServerConnect()
    F.Show()

    'Display form 2
    F = New ScheduleForm()
    F.Location = New Point(450, 0)
    'F.Schedule1.ServerName = "localhost"
    'F.Schedule1.ServerPort = "8090"
    'F.Schedule1.ServerConnect()
    F.Show()

  End Sub

End Class
