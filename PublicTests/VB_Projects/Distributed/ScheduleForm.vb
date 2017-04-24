Option Explicit On 
Option Strict On

Public Class ScheduleForm
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
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ScheduleForm))
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.Size = New System.Drawing.Size(442, 405)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 1
    '
    'ScheduleForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(442, 405)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "ScheduleForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "ScheduleForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ScheduleForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    'Disconnect from the server
    'F.Schedule1.ServerDisconnect()

  End Sub

End Class
