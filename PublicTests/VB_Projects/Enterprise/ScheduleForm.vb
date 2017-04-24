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
  Friend WithEvents Schedule1 As GbSchedule.Controls.Schedule
  Friend WithEvents cmdConnect As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ScheduleForm))
    Me.Schedule1 = New GbSchedule.Controls.Schedule()
    Me.cmdConnect = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.EnterpriseConnection.IsConnected = False
    Me.Schedule1.EnterpriseConnection.ServerName = ""
    Me.Schedule1.EnterpriseConnection.ServerPort = 8090
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.Size = New System.Drawing.Size(440, 224)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    '
    'cmdConnect
    '
    Me.cmdConnect.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdConnect.Location = New System.Drawing.Point(336, 232)
    Me.cmdConnect.Name = "cmdConnect"
    Me.cmdConnect.Size = New System.Drawing.Size(96, 24)
    Me.cmdConnect.TabIndex = 1
    Me.cmdConnect.Text = "Connect"
    '
    'ScheduleForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(440, 261)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdConnect, Me.Schedule1})
    Me.Name = "ScheduleForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ScheduleForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'Setup the schedule
    Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.ColumnHeader.AutoFit = True

    'Default Window Text
    Me.Text = "Gravitybox Schedule.NET [Disconnected]"
    cmdConnect.Text = "Connect"

    'Connect to the Enterprise server
    Schedule1.EnterpriseConnection.ServerName = "localhost"
    Schedule1.EnterpriseConnection.ServerPort = 8090
    Schedule1.EnterpriseConnection.IsConnected = True

  End Sub

  Private Sub Schedule1_EnterpriseConnected(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.EnterpriseConnected
    Me.Text = "Gravitybox Schedule.NET [Connected]"
    cmdConnect.Text = "Disconnect"
  End Sub

  Private Sub Schedule1_EnterpriseDisconnected(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.EnterpriseDisconnected
    Me.Text = "Gravitybox Schedule.NET [Disconnected]"
    cmdConnect.Text = "Connect"
  End Sub

  Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
    Schedule1.EnterpriseConnection.IsConnected = Not Schedule1.EnterpriseConnection.IsConnected
  End Sub

End Class
