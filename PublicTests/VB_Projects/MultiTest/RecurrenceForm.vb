Option Strict On
Option Explicit On 

Public Class RecurrenceForm
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
	Friend WithEvents schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents panel1 As System.Windows.Forms.Panel
	Friend WithEvents lblDescription As System.Windows.Forms.Label
	Friend WithEvents cmdAdd As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RecurrenceForm))
		Me.schedule1 = New Gravitybox.Controls.Schedule
		Me.panel1 = New System.Windows.Forms.Panel
		Me.lblDescription = New System.Windows.Forms.Label
		Me.cmdAdd = New System.Windows.Forms.Button
		Me.panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'schedule1
		'
		Me.schedule1.AllowDrop = True
		Me.schedule1.Appearance.FontSize = 10.0!
		Me.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.schedule1.Appearance.NoFill = False
		Me.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.schedule1.ColumnHeader.Appearance.NoFill = False
		Me.schedule1.ColumnHeader.Size = 100
		Me.schedule1.Cursor = System.Windows.Forms.Cursors.Default
		Me.schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.schedule1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.schedule1.EventHeader.Appearance.NoFill = False
		Me.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.schedule1.Location = New System.Drawing.Point(0, 0)
		Me.schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
		Me.schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.schedule1.Name = "schedule1"
		Me.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.schedule1.RowHeader.Appearance.FontSize = 10.0!
		Me.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.schedule1.RowHeader.Appearance.NoFill = False
		Me.schedule1.RowHeader.Size = 30
		Me.schedule1.SelectedAppointmentAppearance.BorderWidth = 3
		Me.schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
		Me.schedule1.SelectedAppointmentAppearance.NoFill = False
		Me.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
		Me.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
		Me.schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
		Me.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
		Me.schedule1.Selector.Appearance.FontSize = 10.0!
		Me.schedule1.Selector.Appearance.NoFill = False
		Me.schedule1.Size = New System.Drawing.Size(640, 317)
		Me.schedule1.StartTime = New Date(CType(0, Long))
		Me.schedule1.TabIndex = 11
		'
		'panel1
		'
		Me.panel1.Controls.Add(Me.lblDescription)
		Me.panel1.Controls.Add(Me.cmdAdd)
		Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.panel1.Location = New System.Drawing.Point(0, 317)
		Me.panel1.Name = "panel1"
		Me.panel1.Size = New System.Drawing.Size(640, 40)
		Me.panel1.TabIndex = 12
		'
		'lblDescription
		'
		Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			 Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lblDescription.Location = New System.Drawing.Point(0, 8)
		Me.lblDescription.Name = "lblDescription"
		Me.lblDescription.Size = New System.Drawing.Size(488, 24)
		Me.lblDescription.TabIndex = 8
		'
		'cmdAdd
		'
		Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cmdAdd.Location = New System.Drawing.Point(504, 8)
		Me.cmdAdd.Name = "cmdAdd"
		Me.cmdAdd.Size = New System.Drawing.Size(128, 24)
		Me.cmdAdd.TabIndex = 7
		Me.cmdAdd.Text = "Add Recurrence"
		'
		'RecurrenceForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(640, 357)
		Me.Controls.Add(Me.schedule1)
		Me.Controls.Add(Me.panel1)
		Me.Name = "RecurrenceForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Recurrence"
		Me.panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub RecurrenceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		lblDescription.Text = "By pressing the button you will add a recurrence pattern for this appointment every 2 days for 8 occurrences."

		Dim minDate As Date = #1/1/2006#
		schedule1.SetMinMaxDate(minDate, minDate.AddDays(20))
		schedule1.StartTime = #8:00:00 AM#
		schedule1.DayLength = 10

		Dim appointment As Gravitybox.Objects.Appointment = schedule1.AppointmentCollection.Add("", minDate, schedule1.StartTime, 120)
		appointment.Subject = "This is a test"

	End Sub

	Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

		If (schedule1.AppointmentCollection.Count = 0) Then Return

		Dim appointment As Gravitybox.Objects.Appointment = schedule1.AppointmentCollection(0)
		Dim recurrence As Gravitybox.Objects.Recurrence = New Gravitybox.Objects.Recurrence

		'Setup recurrence object for every other day (every 2 days) for 8 occurrences
		recurrence.StartDate = appointment.StartDate
		recurrence.EndIterations = 8
		recurrence.EndType = Gravitybox.Objects.RecurrenceEndConstants.EndByInterval
		recurrence.RecurrenceInterval = Gravitybox.Objects.RecurrenceIntervalConstants.Daily

		recurrence.RecurrenceDay.DayInterval = 2
		recurrence.RecurrenceDay.RecurrenceMode = Gravitybox.Objects.RecurrenceDayConstants.DayInterval

		schedule1.AppointmentCollection.AddRecurrence(appointment, recurrence)

	End Sub

End Class
