#Region "Copyright (c) 1998-2005 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2005 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports Gravitybox.Objects

Namespace Gravitybox.Forms

  Friend Class AlarmFormXP
    Inherits IAlarmForm

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dialogObject As ScheduleDialog)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      MyBase.SetKey(Guid.NewGuid.ToString)
      _dialogObject = dialogObject

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
    Friend WithEvents lblWindowText As System.Windows.Forms.Label
    Friend WithEvents pnlSnooze As System.Windows.Forms.Panel
    Friend WithEvents cboSnooze As System.Windows.Forms.ComboBox
    Friend WithEvents lblSnooze As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents cmdDismiss As System.Windows.Forms.Button
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents cmdSnooze As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdDismiss = New System.Windows.Forms.Button
      Me.cmdOpen = New System.Windows.Forms.Button
      Me.cmdSnooze = New System.Windows.Forms.Button
      Me.lblWindowText = New System.Windows.Forms.Label
      Me.pnlSnooze = New System.Windows.Forms.Panel
      Me.cboSnooze = New System.Windows.Forms.ComboBox
      Me.lblSnooze = New System.Windows.Forms.Label
      Me.lblLine = New System.Windows.Forms.Label
      Me.lblLocation = New System.Windows.Forms.Label
      Me.lblSubject = New System.Windows.Forms.Label
      Me.pnlSnooze.SuspendLayout()
      Me.SuspendLayout()
      '
      'cmdDismiss
      '
      Me.cmdDismiss.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDismiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.cmdDismiss.Location = New System.Drawing.Point(32, 160)
      Me.cmdDismiss.Name = "cmdDismiss"
      Me.cmdDismiss.Size = New System.Drawing.Size(80, 24)
      Me.cmdDismiss.TabIndex = 1
      Me.cmdDismiss.Text = "Dismiss"
      '
      'cmdOpen
      '
      Me.cmdOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.cmdOpen.Location = New System.Drawing.Point(208, 160)
      Me.cmdOpen.Name = "cmdOpen"
      Me.cmdOpen.Size = New System.Drawing.Size(80, 24)
      Me.cmdOpen.TabIndex = 3
      Me.cmdOpen.Text = "Open"
      '
      'cmdSnooze
      '
      Me.cmdSnooze.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.cmdSnooze.Location = New System.Drawing.Point(120, 160)
      Me.cmdSnooze.Name = "cmdSnooze"
      Me.cmdSnooze.Size = New System.Drawing.Size(80, 24)
      Me.cmdSnooze.TabIndex = 2
      Me.cmdSnooze.Text = "Snooze"
      '
      'lblWindowText
      '
      Me.lblWindowText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWindowText.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblWindowText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblWindowText.Location = New System.Drawing.Point(8, 8)
      Me.lblWindowText.Name = "lblWindowText"
      Me.lblWindowText.Size = New System.Drawing.Size(312, 16)
      Me.lblWindowText.TabIndex = 3
      Me.lblWindowText.Text = "WINDOWTEXT"
      '
      'pnlSnooze
      '
      Me.pnlSnooze.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlSnooze.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.pnlSnooze.Controls.Add(Me.cboSnooze)
      Me.pnlSnooze.Controls.Add(Me.lblSnooze)
      Me.pnlSnooze.Controls.Add(Me.lblLine)
      Me.pnlSnooze.Location = New System.Drawing.Point(8, 120)
      Me.pnlSnooze.Name = "pnlSnooze"
      Me.pnlSnooze.Size = New System.Drawing.Size(312, 32)
      Me.pnlSnooze.TabIndex = 8
      '
      'cboSnooze
      '
      Me.cboSnooze.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cboSnooze.Location = New System.Drawing.Point(208, 8)
      Me.cboSnooze.Name = "cboSnooze"
      Me.cboSnooze.Size = New System.Drawing.Size(96, 21)
      Me.cboSnooze.TabIndex = 0
      '
      'lblSnooze
      '
      Me.lblSnooze.Location = New System.Drawing.Point(0, 8)
      Me.lblSnooze.Name = "lblSnooze"
      Me.lblSnooze.Size = New System.Drawing.Size(192, 16)
      Me.lblSnooze.TabIndex = 1
      Me.lblSnooze.Text = "&Click Snooze to remind me again:"
      '
      'lblLine
      '
      Me.lblLine.BackColor = System.Drawing.Color.Black
      Me.lblLine.Dock = System.Windows.Forms.DockStyle.Top
      Me.lblLine.Location = New System.Drawing.Point(0, 0)
      Me.lblLine.Name = "lblLine"
      Me.lblLine.Size = New System.Drawing.Size(312, 1)
      Me.lblLine.TabIndex = 0
      '
      'lblLocation
      '
      Me.lblLocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLocation.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblLocation.Location = New System.Drawing.Point(8, 96)
      Me.lblLocation.Name = "lblLocation"
      Me.lblLocation.Size = New System.Drawing.Size(312, 16)
      Me.lblLocation.TabIndex = 7
      '
      'lblSubject
      '
      Me.lblSubject.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblSubject.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblSubject.Location = New System.Drawing.Point(8, 32)
      Me.lblSubject.Name = "lblSubject"
      Me.lblSubject.Size = New System.Drawing.Size(312, 56)
      Me.lblSubject.TabIndex = 6
      '
      'AlarmFormXP
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(328, 208)
      Me.ControlBox = False
      Me.Controls.Add(Me.pnlSnooze)
      Me.Controls.Add(Me.lblLocation)
      Me.Controls.Add(Me.lblSubject)
      Me.Controls.Add(Me.lblWindowText)
      Me.Controls.Add(Me.cmdSnooze)
      Me.Controls.Add(Me.cmdOpen)
      Me.Controls.Add(Me.cmdDismiss)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(328, 216)
      Me.Name = "AlarmFormXP"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.pnlSnooze.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Private myPath As System.Drawing.Drawing2D.GraphicsPath
    Private _dialogObject As ScheduleDialog

#End Region

#Region "Property Implementations"

    Friend ReadOnly Property DialogObject() As ScheduleDialog
      Get
        Return _dialogObject
      End Get
    End Property

#End Region

#Region "Form Events"


    Private Sub AlarmForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      myPath = GetRegion(ClientRectangle)
      Me.Region = New Region(myPath)
      Me.BackColor = System.Drawing.SystemColors.Info
      Me.Location = New Point(0, Screen.PrimaryScreen.WorkingArea.Height - Me.Height - 30)

    End Sub

    Private Sub AlarmForm_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
      Me.CreateGraphics.DrawPath(New Pen(Color.Black, 2), myPath)
    End Sub

    Private Sub AlarmForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

      Try
        Call Me.ScheduleObject.Dialogs.AlarmScreens.Remove(Me.Key)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "GetRegion"

    Private Function GetRegion(ByVal rect As Rectangle) As System.Drawing.Drawing2D.GraphicsPath

      Const RoundRadius As Integer = 25
      Const ShortLine As Integer = 15
      Const PointSize As Integer = 20

      Me.Size = New Size(rect.Width, rect.Height + PointSize)
      Dim rectHeight As Integer = rect.Height

      Try
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath
        Call gp.AddLine(rect.Left + RoundRadius, rect.Top, rect.Left + rect.Width - RoundRadius, rect.Top) 'Top
        Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top, RoundRadius, RoundRadius, 270, 90) 'Top/Right Corner
        Call gp.AddLine(rect.Left + rect.Width, rect.Top + RoundRadius, rect.Left + rect.Width, rect.Top + rectHeight - RoundRadius) 'Right
        Call gp.AddArc(rect.Left + rect.Width - RoundRadius, rect.Top + rectHeight - RoundRadius, RoundRadius, RoundRadius, 0, 90) 'Bottom/Right Corner

        'Draw the pointer
        Dim A As New Point(rect.Left + rect.Width - RoundRadius, rect.Top + rectHeight)
        Dim B As New Point(A.X - ShortLine, A.Y)
        Dim C As New Point(B.X, B.Y + PointSize)
        Dim D As New Point(B.X - PointSize, A.Y)
        Dim E As New Point(rect.Left + RoundRadius, A.Y)
        Call gp.AddLine(A, B)
        Call gp.AddLine(B, C)
        Call gp.AddLine(C, D)
        Call gp.AddLine(D, E)

        Call gp.AddArc(rect.Left, rect.Top + rectHeight - RoundRadius, RoundRadius, RoundRadius, 90, 90) 'Bottom/Left Corner
        Call gp.AddLine(rect.Left, rect.Top + rectHeight - RoundRadius, rect.Left, rect.Top + RoundRadius) 'Left
        Call gp.AddArc(rect.Left, rect.Top, RoundRadius, RoundRadius, 180, 90) 'Top/Left Corner
        Call gp.CloseFigure()
        Return gp

      Catch ex As Exception
        'Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Refresh"

    Friend Overrides Sub RefreshForm()

      Try
        'Nothing to do - skip out
        If Me.Appointment Is Nothing Then Return

        lblWindowText.BackColor = System.Drawing.SystemColors.Info
        lblLocation.BackColor = System.Drawing.SystemColors.Info
        lblSnooze.BackColor = System.Drawing.SystemColors.Info
        lblSubject.BackColor = System.Drawing.SystemColors.Info
        pnlSnooze.BackColor = System.Drawing.SystemColors.Info
        Reminder = New AppointmentReminder(DialogSettings.TimeSettings)
        Call Reminder.LoadReminderCombo(Me.cboSnooze)
        'Remove "0 minutes"
        Call Me.cboSnooze.Items.RemoveAt(0)

        'Setup Captions
        Me.StartPosition = DialogSettings.StartPosition
        Me.FormBorderStyle = DialogSettings.FormBorderStyle
        Me.cmdDismiss.Text = DialogSettings.OkButtonText
        Me.cmdOpen.Text = DialogSettings.OpenButtonText
        Me.cmdSnooze.Text = DialogSettings.CancelButtonText
        Me.lblSnooze.Text = DialogSettings.SnoozeText

        Me.cmdDismiss.Enabled = DialogSettings.DismissButtonEnabled
        Me.cmdOpen.Enabled = DialogSettings.OpenButtonEnabled
        Me.cmdSnooze.Enabled = DialogSettings.SnoozeButtonEnabled

        'Setup the form
        Me.cmdOpen.Visible = Me.Appointment.Alarm.AllowOpen
        Me.cmdSnooze.Visible = Me.Appointment.Alarm.AllowSnooze
        If Not Me.Appointment.Alarm.AllowSnooze Then
          'Shrink the form to remove the snooze feature
          Me.Size = New Size(Me.Size.Width, Me.Size.Height - Me.pnlSnooze.Height - 16)
          Me.pnlSnooze.Visible = False
        End If

        'Setup the window text
        If Appointment.Alarm.WindowText = "" Then
          Me.lblWindowText.Text = DialogSettings.WindowText
        Else
          Me.lblWindowText.Text = Appointment.Alarm.WindowText
        End If
        Me.Icon = Me.DialogSettings.Icon

        'Determine if there is a room
        Dim roomIndex As Integer = ScheduleObject.ResolveRoom(Appointment.Room)

        'Load the form's controls
        lblSubject.Text = Appointment.Subject
        If roomIndex >= 0 Then
          Dim locationHeader As String = DialogSettings.LocationHeaderText.Trim
          If locationHeader.Length > 0 Then locationHeader = locationHeader & ": "
          lblLocation.Text = locationHeader & ScheduleObject.RoomCollection(roomIndex).Text
        End If
        'Default to first one
        cboSnooze.SelectedItem = cboSnooze.Items(1)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Button Handlers"

    Private Sub cmdDismiss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDismiss.Click
      'Just close form, nothing to do
			Appointment.Alarm.IsArmed = False
      Me.DialogObject.MainObject.FireAppointmentDismissed(Me.Appointment)
      Call Me.Close()
    End Sub

    Private Sub cmdSnooze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnooze.Click
      'Snooze for another N minutes
      Dim minutePause As Integer = GetIntlInteger(DateDiff(DateInterval.Minute, Now, Appointment.StartDateTime))
			minutePause += Reminder.GetDurationValue(Me.cboSnooze.Text)
      Appointment.Alarm.Reminder = -minutePause
      Appointment.Alarm.IsArmed = True
      Me.DialogObject.MainObject.FireAppointmentSnooze(Me.Appointment)
      Call Me.Close()
    End Sub

    Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click
      Call Me.Close()
      'Open the appointment
      Call ScheduleObject.Dialogs.ShowPropertyDialog(Me.Appointment)
    End Sub

#End Region

  End Class

End Namespace