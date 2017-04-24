Option Strict On
Option Explicit On 

Public Class frmMain
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
  Friend WithEvents fraBack1 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdConfigCateogry As System.Windows.Forms.Button
  Friend WithEvents cmdConfigProvider As System.Windows.Forms.Button
  Friend WithEvents cmdConfigRoom As System.Windows.Forms.Button
  Friend WithEvents fraBack2 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdDialogProvider As System.Windows.Forms.Button
  Friend WithEvents cmdDialogCategory As System.Windows.Forms.Button
  Friend WithEvents cmdDialogAlarm As System.Windows.Forms.Button
  Friend WithEvents cmdDialogProperties As System.Windows.Forms.Button
  Friend WithEvents fraBack3 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdAbout As System.Windows.Forms.Button
  Friend WithEvents cmdConfigPropertyItem As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.fraBack1 = New System.Windows.Forms.GroupBox
    Me.cmdConfigPropertyItem = New System.Windows.Forms.Button
    Me.cmdConfigRoom = New System.Windows.Forms.Button
    Me.cmdConfigProvider = New System.Windows.Forms.Button
    Me.cmdConfigCateogry = New System.Windows.Forms.Button
    Me.fraBack2 = New System.Windows.Forms.GroupBox
    Me.cmdDialogProperties = New System.Windows.Forms.Button
    Me.cmdDialogAlarm = New System.Windows.Forms.Button
    Me.cmdDialogProvider = New System.Windows.Forms.Button
    Me.cmdDialogCategory = New System.Windows.Forms.Button
    Me.fraBack3 = New System.Windows.Forms.GroupBox
    Me.cmdAbout = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.fraBack1.SuspendLayout()
    Me.fraBack2.SuspendLayout()
    Me.fraBack3.SuspendLayout()
    Me.SuspendLayout()
    '
    'fraBack1
    '
    Me.fraBack1.Controls.Add(Me.cmdConfigPropertyItem)
    Me.fraBack1.Controls.Add(Me.cmdConfigRoom)
    Me.fraBack1.Controls.Add(Me.cmdConfigProvider)
    Me.fraBack1.Controls.Add(Me.cmdConfigCateogry)
    Me.fraBack1.Location = New System.Drawing.Point(8, 8)
    Me.fraBack1.Name = "fraBack1"
    Me.fraBack1.Size = New System.Drawing.Size(136, 152)
    Me.fraBack1.TabIndex = 0
    Me.fraBack1.TabStop = False
    Me.fraBack1.Text = "Configuration"
    '
    'cmdConfigPropertyItem
    '
    Me.cmdConfigPropertyItem.Location = New System.Drawing.Point(24, 120)
    Me.cmdConfigPropertyItem.Name = "cmdConfigPropertyItem"
    Me.cmdConfigPropertyItem.Size = New System.Drawing.Size(96, 24)
    Me.cmdConfigPropertyItem.TabIndex = 3
    Me.cmdConfigPropertyItem.Text = "PropertyItems"
    '
    'cmdConfigRoom
    '
    Me.cmdConfigRoom.Location = New System.Drawing.Point(24, 88)
    Me.cmdConfigRoom.Name = "cmdConfigRoom"
    Me.cmdConfigRoom.Size = New System.Drawing.Size(96, 24)
    Me.cmdConfigRoom.TabIndex = 2
    Me.cmdConfigRoom.Text = "Rooms"
    '
    'cmdConfigProvider
    '
    Me.cmdConfigProvider.Location = New System.Drawing.Point(24, 56)
    Me.cmdConfigProvider.Name = "cmdConfigProvider"
    Me.cmdConfigProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdConfigProvider.TabIndex = 1
    Me.cmdConfigProvider.Text = "Providers"
    '
    'cmdConfigCateogry
    '
    Me.cmdConfigCateogry.Location = New System.Drawing.Point(24, 24)
    Me.cmdConfigCateogry.Name = "cmdConfigCateogry"
    Me.cmdConfigCateogry.Size = New System.Drawing.Size(96, 24)
    Me.cmdConfigCateogry.TabIndex = 0
    Me.cmdConfigCateogry.Text = "Categories"
    '
    'fraBack2
    '
    Me.fraBack2.Controls.Add(Me.cmdDialogProperties)
    Me.fraBack2.Controls.Add(Me.cmdDialogAlarm)
    Me.fraBack2.Controls.Add(Me.cmdDialogProvider)
    Me.fraBack2.Controls.Add(Me.cmdDialogCategory)
    Me.fraBack2.Location = New System.Drawing.Point(8, 168)
    Me.fraBack2.Name = "fraBack2"
    Me.fraBack2.Size = New System.Drawing.Size(136, 160)
    Me.fraBack2.TabIndex = 1
    Me.fraBack2.TabStop = False
    Me.fraBack2.Text = "Dialogs"
    '
    'cmdDialogProperties
    '
    Me.cmdDialogProperties.Location = New System.Drawing.Point(24, 88)
    Me.cmdDialogProperties.Name = "cmdDialogProperties"
    Me.cmdDialogProperties.Size = New System.Drawing.Size(96, 24)
    Me.cmdDialogProperties.TabIndex = 5
    Me.cmdDialogProperties.Text = "Properties"
    '
    'cmdDialogAlarm
    '
    Me.cmdDialogAlarm.Location = New System.Drawing.Point(24, 24)
    Me.cmdDialogAlarm.Name = "cmdDialogAlarm"
    Me.cmdDialogAlarm.Size = New System.Drawing.Size(96, 24)
    Me.cmdDialogAlarm.TabIndex = 3
    Me.cmdDialogAlarm.Text = "Alarm"
    '
    'cmdDialogProvider
    '
    Me.cmdDialogProvider.Location = New System.Drawing.Point(24, 120)
    Me.cmdDialogProvider.Name = "cmdDialogProvider"
    Me.cmdDialogProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdDialogProvider.TabIndex = 6
    Me.cmdDialogProvider.Text = "Provider"
    '
    'cmdDialogCategory
    '
    Me.cmdDialogCategory.Location = New System.Drawing.Point(24, 56)
    Me.cmdDialogCategory.Name = "cmdDialogCategory"
    Me.cmdDialogCategory.Size = New System.Drawing.Size(96, 24)
    Me.cmdDialogCategory.TabIndex = 4
    Me.cmdDialogCategory.Text = "Category"
    '
    'fraBack3
    '
    Me.fraBack3.Controls.Add(Me.cmdAbout)
    Me.fraBack3.Location = New System.Drawing.Point(8, 344)
    Me.fraBack3.Name = "fraBack3"
    Me.fraBack3.Size = New System.Drawing.Size(136, 56)
    Me.fraBack3.TabIndex = 3
    Me.fraBack3.TabStop = False
    Me.fraBack3.Text = "Misc"
    '
    'cmdAbout
    '
    Me.cmdAbout.Location = New System.Drawing.Point(20, 24)
    Me.cmdAbout.Name = "cmdAbout"
    Me.cmdAbout.Size = New System.Drawing.Size(96, 24)
    Me.cmdAbout.TabIndex = 4
    Me.cmdAbout.Text = "About"
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DayLength = 16
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Location = New System.Drawing.Point(168, 8)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Column = 0
    Me.Schedule1.Selector.Length = 1
    Me.Schedule1.Selector.Row = 0
    Me.Schedule1.Size = New System.Drawing.Size(456, 384)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 5
    '
    'frmMain
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(624, 407)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.fraBack1)
    Me.Controls.Add(Me.fraBack2)
    Me.Controls.Add(Me.fraBack3)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.Name = "frmMain"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET Dialogs Example"
    Me.fraBack1.ResumeLayout(False)
    Me.fraBack2.ResumeLayout(False)
    Me.fraBack3.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdConfigCateogry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigCateogry.Click
    Call Schedule1.Dialogs.ShowCategoryConfiguration()
  End Sub

  Private Sub cmdConfigProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigProvider.Click
    Call Schedule1.Dialogs.ShowProviderConfiguration()
  End Sub

  Private Sub cmdConfigRoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigRoom.Click
    Call Schedule1.Dialogs.ShowRoomConfiguration()
  End Sub

  Private Sub cmdConfigPropertyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigPropertyItem.Click
    Call Schedule1.Dialogs.ShowPropertyItemConfiguration(Schedule1.AppointmentCollection(0).PropertyItemCollection)
  End Sub

  Private Sub cmdDialogCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogCategory.Click
    If Not (Schedule1.SelectedItem Is Nothing) Then
      Call Schedule1.Dialogs.ShowCategoryDialog(Schedule1.SelectedItem)
    End If
  End Sub

  Private Sub cmdDialogProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogProvider.Click
    If Not (Schedule1.SelectedItem Is Nothing) Then
      Call Schedule1.Dialogs.ShowProviderDialog(Schedule1.SelectedItem)
    End If
  End Sub

  Private Sub cmdDialogAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogAlarm.Click
    If Not (Schedule1.SelectedItem Is Nothing) Then
      Call Schedule1.Dialogs.ShowAlarmDialog(Schedule1.SelectedItem)
    End If
  End Sub

  Private Sub cmdDialogProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogProperties.Click
    If Not (Schedule1.SelectedItem Is Nothing) Then
      Dim dialogSettings As New Gravitybox.Objects.AppointmentDialogSettings
      dialogSettings.AllowRoom = False
      'dialogSettings.WarningText = "This is a warning!"
      Call Schedule1.Dialogs.ShowPropertyDialog(Schedule1.SelectedItem, dialogSettings)
    End If
  End Sub

  Private Sub cmdAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAbout.Click
    Call Schedule1.Dialogs.ShowAboutDialog()
  End Sub

  Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Schedule1.SetMinMaxDate(#1/1/2003#, #1/1/2003#)
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.AllowRemove = False

    'Add an appointments so that all of the dialogs will work!
    Dim appointment As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, #9:00:00 AM#, 120)
    appointment.Subject = "This is my subject!"

    Schedule1.SelectedItem = appointment

  End Sub

	Private Sub Schedule1_BeforeAppointmentRemove(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
		e.Cancel = True
	End Sub

End Class
