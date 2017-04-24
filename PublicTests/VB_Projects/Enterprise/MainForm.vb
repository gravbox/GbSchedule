Option Explicit On 
Option Strict On

Public Class MainForm
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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(376, 64)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "This example application starts a Gravitybox Enterrpise Server application that c" & _
    "oordinates appointment information. A few seconds later it displays 2 forms with" & _
    " a GbSchedule.NET component on each. You can then add/edit/delete appointments t" & _
    "o either schedule to the changes applied to the other form."
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(200, 80)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(184, 24)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Start Example"
    '
    'Timer1
    '
    Me.Timer1.Interval = 4000
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 111)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Label1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET Enterprise Test"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    'Only allow button to be pushed once
    Button1.Enabled = False

    Dim fileName As String
    fileName = System.Environment.CurrentDirectory & "\ServerMachine.exe"
    Call System.Diagnostics.Process.Start(fileName)

    'Wait 2 seconds and load the 2 schedules
    Timer1.Enabled = True

  End Sub

  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    'Turn off the timer
    Timer1.Enabled = False

    'Load the schedule forms
    Dim F As ScheduleForm

    'Load form 1
    F = New ScheduleForm()
    F.Location = New Point(0, 0)
    F.Show()

    'Wait 1 second before launching the next one
    System.Threading.Thread.CurrentThread.Sleep(1000)

    'Load form 2
    F = New ScheduleForm()
    F.Location = New Point(F.Width, 0)
    F.Show()

  End Sub

End Class
