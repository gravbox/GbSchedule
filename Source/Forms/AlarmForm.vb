#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
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

  Friend Class AlarmForm
    Inherits IAlarmForm

#Region " Windows Form Designer generated code "

    Friend Sub New(ByVal dialogObject As ScheduleDialog)
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
    Friend WithEvents cmdDismiss As System.Windows.Forms.Button
    Friend WithEvents cmdSnooze As System.Windows.Forms.Button
    Friend WithEvents cmdOpen As System.Windows.Forms.Button
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblSnooze As System.Windows.Forms.Label
    Friend WithEvents cboSnooze As System.Windows.Forms.ComboBox
    Friend WithEvents pnlSnooze As System.Windows.Forms.Panel
    Friend WithEvents lstAlarm As Gravitybox.Controls.MultiLineListBox
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AlarmForm))
			Me.cmdDismiss = New System.Windows.Forms.Button
			Me.cmdSnooze = New System.Windows.Forms.Button
			Me.cmdOpen = New System.Windows.Forms.Button
			Me.pnlSnooze = New System.Windows.Forms.Panel
			Me.cboSnooze = New System.Windows.Forms.ComboBox
			Me.lblSnooze = New System.Windows.Forms.Label
			Me.lblLine = New System.Windows.Forms.Label
			Me.lstAlarm = New Gravitybox.Controls.MultiLineListBox
			Me.cmdSelectAll = New System.Windows.Forms.Button
			Me.cmdDelete = New System.Windows.Forms.Button
			Me.pnlSnooze.SuspendLayout()
			Me.SuspendLayout()
			'
			'cmdDismiss
			'
			Me.cmdDismiss.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdDismiss.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdDismiss.Location = New System.Drawing.Point(296, 40)
			Me.cmdDismiss.Name = "cmdDismiss"
			Me.cmdDismiss.Size = New System.Drawing.Size(96, 24)
			Me.cmdDismiss.TabIndex = 2
			Me.cmdDismiss.Text = "Dis&miss"
			'
			'cmdSnooze
			'
			Me.cmdSnooze.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdSnooze.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdSnooze.Location = New System.Drawing.Point(296, 72)
			Me.cmdSnooze.Name = "cmdSnooze"
			Me.cmdSnooze.Size = New System.Drawing.Size(96, 24)
			Me.cmdSnooze.TabIndex = 3
			Me.cmdSnooze.Text = "&Snooze"
			'
			'cmdOpen
			'
			Me.cmdOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdOpen.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdOpen.Location = New System.Drawing.Point(296, 104)
			Me.cmdOpen.Name = "cmdOpen"
			Me.cmdOpen.Size = New System.Drawing.Size(96, 24)
			Me.cmdOpen.TabIndex = 4
			Me.cmdOpen.Text = "&Open Item"
			'
			'pnlSnooze
			'
			Me.pnlSnooze.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.pnlSnooze.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
			Me.pnlSnooze.Controls.Add(Me.cboSnooze)
			Me.pnlSnooze.Controls.Add(Me.lblSnooze)
			Me.pnlSnooze.Controls.Add(Me.lblLine)
			Me.pnlSnooze.Location = New System.Drawing.Point(8, 166)
			Me.pnlSnooze.Name = "pnlSnooze"
			Me.pnlSnooze.Size = New System.Drawing.Size(382, 32)
			Me.pnlSnooze.TabIndex = 5
			'
			'cboSnooze
			'
			Me.cboSnooze.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cboSnooze.Location = New System.Drawing.Point(208, 8)
			Me.cboSnooze.Name = "cboSnooze"
			Me.cboSnooze.Size = New System.Drawing.Size(166, 21)
			Me.cboSnooze.TabIndex = 6
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
			Me.lblLine.Size = New System.Drawing.Size(382, 1)
			Me.lblLine.TabIndex = 0
			'
			'lstAlarm
			'
			Me.lstAlarm.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.lstAlarm.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
			Me.lstAlarm.IntegralHeight = False
			Me.lstAlarm.Location = New System.Drawing.Point(8, 8)
			Me.lstAlarm.Name = "lstAlarm"
			Me.lstAlarm.ScrollAlwaysVisible = True
			Me.lstAlarm.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
			Me.lstAlarm.Size = New System.Drawing.Size(280, 152)
			Me.lstAlarm.TabIndex = 0
			'
			'cmdSelectAll
			'
			Me.cmdSelectAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdSelectAll.Location = New System.Drawing.Point(296, 8)
			Me.cmdSelectAll.Name = "cmdSelectAll"
			Me.cmdSelectAll.Size = New System.Drawing.Size(96, 24)
			Me.cmdSelectAll.TabIndex = 1
			Me.cmdSelectAll.Text = "&Select All"
			'
			'cmdDelete
			'
			Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdDelete.Location = New System.Drawing.Point(296, 136)
			Me.cmdDelete.Name = "cmdDelete"
			Me.cmdDelete.Size = New System.Drawing.Size(96, 24)
			Me.cmdDelete.TabIndex = 5
			Me.cmdDelete.Text = "&Delete"
			'
			'AlarmForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(400, 205)
			Me.Controls.Add(Me.cmdDelete)
			Me.Controls.Add(Me.cmdSelectAll)
			Me.Controls.Add(Me.lstAlarm)
			Me.Controls.Add(Me.pnlSnooze)
			Me.Controls.Add(Me.cmdOpen)
			Me.Controls.Add(Me.cmdSnooze)
			Me.Controls.Add(Me.cmdDismiss)
      Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(408, 232)
			Me.Name = "AlarmForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
			Me.Text = "<AlarmForm>"
			Me.pnlSnooze.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Class Members"

    Private _dialogObject As ScheduleDialog

#End Region

#Region "Form Handlers"

#If VS2005 Then
		Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Friend ReadOnly Property DialogObject() As ScheduleDialog
      Get
        Return _dialogObject
      End Get
    End Property

    Private ReadOnly Property SelectedAppointment() As Gravitybox.Objects.Appointment
      Get
        If lstAlarm.SelectedIndex = -1 Then
          Return Nothing
        Else
          Return CType(lstAlarm.SelectedItem, Gravitybox.Objects.Appointment)
        End If
      End Get
    End Property

#End Region

#Region "Form Events"

    Private Sub AlarmForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

      Try
        Me.ScheduleObject.Dialogs.AlarmScreen = Nothing
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Methods"

    Friend Overrides Sub RefreshForm()

			Try
				lstAlarm.BeginUpdate()
				MyBase.RefreshForm()
				Dim selectedIndex As Integer = Me.lstAlarm.SelectedIndex

				lblSnooze.BackColor = SystemColors.Control
				pnlSnooze.BackColor = SystemColors.Control
				Reminder = New AppointmentReminder(DialogSettings.TimeSettings)
				Call Reminder.LoadReminderCombo(Me.cboSnooze)
				'Remove "0 minutes"
				Call Me.cboSnooze.Items.RemoveAt(0)

				'Setup Captions
				Me.Icon = Me.DialogSettings.Icon
				Me.Text = DialogSettings.WindowText
				Me.StartPosition = DialogSettings.StartPosition
				Me.Location = DialogSettings.Location
				Me.Size = DialogSettings.Size
				Me.FormBorderStyle = DialogSettings.FormBorderStyle
				Me.cmdDismiss.Text = DialogSettings.OkButtonText
				Me.cmdOpen.Text = DialogSettings.OpenButtonText
				Me.cmdSnooze.Text = DialogSettings.CancelButtonText
				Me.cmdDelete.Text = DialogSettings.DeleteButtonText
				Me.cmdSelectAll.Text = DialogSettings.SelectAllButtonText
				Me.lblSnooze.Text = DialogSettings.SnoozeText

				Me.cmdDismiss.Enabled = DialogSettings.DismissButtonEnabled
				Me.cmdOpen.Enabled = DialogSettings.OpenButtonEnabled
				Me.cmdSnooze.Enabled = DialogSettings.SnoozeButtonEnabled

				'Loop through all of the alarms
				lstAlarm.Items.Clear()
				For Each appointment As Gravitybox.Objects.Appointment In Me.AppointmentList
					lstAlarm.Items.Add(appointment)
				Next

				If selectedIndex >= 0 Then
					If selectedIndex < Me.lstAlarm.Items.Count Then
						Me.lstAlarm.SelectedIndex = selectedIndex
					Else
						Me.lstAlarm.SelectedIndex = Me.lstAlarm.Items.Count - 1
					End If
				ElseIf Me.lstAlarm.Items.Count > 0 Then
					Me.lstAlarm.SelectedIndex = 0
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			Finally
				lstAlarm.EndUpdate()
			End Try

    End Sub

#End Region

#Region "Button Handlers"

    Private Sub cmdDismiss_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDismiss.Click

			Try
				'Just close form, nothing to do
				For ii As Integer = lstAlarm.Items.Count - 1 To 0 Step -1
					If lstAlarm.GetSelected(ii) Then
						Dim appt As Gravitybox.Objects.Appointment = CType(lstAlarm.Items(ii), Gravitybox.Objects.Appointment)
						appt.Alarm.IsArmed = False
						Me.DialogObject.MainObject.FireAppointmentDismissed(appt)
						lstAlarm.Items.RemoveAt(ii)
					End If
				Next

				If lstAlarm.Items.Count = 0 Then
					Me.Close()
				ElseIf lstAlarm.SelectedIndex = -1 Then
					lstAlarm.SelectedIndex = 0
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdSnooze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSnooze.Click

			Try
				'Snooze for another N minutes
				For ii As Integer = lstAlarm.Items.Count - 1 To 0 Step -1
					If lstAlarm.GetSelected(ii) Then
						Dim appt As Gravitybox.Objects.Appointment = CType(lstAlarm.Items(ii), Gravitybox.Objects.Appointment)
						Dim minutePause As Integer = GetIntlInteger(DateDiff(DateInterval.Minute, Now, appt.StartDateTime))
						minutePause -= Reminder.GetDurationValue(Me.cboSnooze.Text)
						appt.Alarm.Reminder = minutePause
						appt.Alarm.IsArmed = True
						appt.Alarm.ReminderDisplayed = False
						Me.DialogObject.MainObject.FireAppointmentSnooze(appt)
						lstAlarm.Items.RemoveAt(ii)
					End If
				Next

				If lstAlarm.Items.Count = 0 Then
					Me.Close()
				ElseIf lstAlarm.SelectedIndex = -1 Then
					lstAlarm.SelectedIndex = 0
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpen.Click

			Try
				'Open the appointment
				For ii As Integer = lstAlarm.Items.Count - 1 To 0 Step -1
					If lstAlarm.GetSelected(ii) Then
						Dim appt As Gravitybox.Objects.Appointment = CType(lstAlarm.Items(ii), Gravitybox.Objects.Appointment)
						Call ScheduleObject.Dialogs.ShowPropertyDialog(appt)
					End If
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAll.Click

			Try
				For ii As Integer = 0 To lstAlarm.Items.Count - 1
					lstAlarm.SetSelected(ii, True)
				Next
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

			Try
				'Make a list and remove
				Dim al As New ArrayList
				For ii As Integer = lstAlarm.Items.Count - 1 To 0 Step -1
					If lstAlarm.GetSelected(ii) Then
						Dim appt As Gravitybox.Objects.BaseObject = CType(lstAlarm.Items(ii), Gravitybox.Objects.BaseObject)
						al.Add(appt)
					End If
				Next

				For Each appt As Gravitybox.Objects.Appointment In al
					ScheduleObject.AppointmentCollection.Remove(appt)
				Next

				If lstAlarm.Items.Count = 0 Then
					Me.Close()
				ElseIf lstAlarm.SelectedIndex = -1 Then
					lstAlarm.SelectedIndex = 0
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "The ListBox Events"

    Private Sub lstAlarm_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAlarm.SelectedIndexChanged

			Try
				Dim appointment As Gravitybox.Objects.Appointment = Me.SelectedAppointment
				If appointment Is Nothing Then
					Me.cmdOpen.Enabled = False
					Me.cmdSnooze.Enabled = False
					Me.cmdDelete.Enabled = False
					Me.cmdDismiss.Enabled = False
					Return
				Else
					Me.cmdOpen.Enabled = Me.SelectedAppointment.Alarm.AllowOpen
					Me.cmdSnooze.Enabled = Me.SelectedAppointment.Alarm.AllowSnooze
					Me.cmdDelete.Enabled = ScheduleObject.AllowRemove
					Me.cmdDismiss.Enabled = True
				End If

				'Setup the form
				Me.cmdOpen.Visible = appointment.Alarm.AllowOpen
				Me.cmdSnooze.Visible = appointment.Alarm.AllowSnooze
				If Not appointment.Alarm.AllowSnooze Then
					'Shrink the form to remove the snooze feature
					Me.Size = New Size(Me.Size.Width, Me.Size.Height - Me.pnlSnooze.Height - 16)
					Me.pnlSnooze.Visible = False
				End If

				'Setup the window text
				If appointment.Alarm.WindowText = "" Then
					Me.Text = DialogSettings.WindowText
				Else
					Me.Text = appointment.Alarm.WindowText
				End If
				Me.Icon = Me.DialogSettings.Icon

				'Determine if there is a room
				Dim roomIndex As Integer = ScheduleObject.ResolveRoom(appointment.Room)

				'Default to first one
				cboSnooze.SelectedItem = cboSnooze.Items(1)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

    End Sub

		Private Sub lstAlarm_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstAlarm.DoubleClick

			If lstAlarm.SelectedIndex > -1 Then
				cmdOpen.PerformClick()
			End If

		End Sub

		Private Sub lstAlarm_BeforeDrawText(ByVal e As Objects.EventArgs.BeforeAppointmentTextEventArgs) Handles lstAlarm.BeforeDrawText

			Try
				Dim appointment As appointment = CType(e.BaseObject, appointment)
				Dim text As String = appointment.ToString()
				text = text.Replace(ControlChars.CrLf, " ")
				If appointment.Subject <> "" Then
					text &= ControlChars.CrLf & appointment.Subject
				End If
				e.Text = text
				ScheduleObject.FireBeforeAlarmDrawText(e)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub lstAlarm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstAlarm.KeyPress
			If e.KeyChar = vbCr Then
				If lstAlarm.SelectedIndex > -1 Then
					cmdOpen.PerformClick()
				End If
			End If
		End Sub

#End Region

	End Class

End Namespace