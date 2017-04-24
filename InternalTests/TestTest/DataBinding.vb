Public Class DataBinding
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
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents cmdBind As System.Windows.Forms.Button
	Friend WithEvents ScheduleDomainController1 As Gravitybox.Controls.ScheduleDomainController
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DataBinding))
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.cmdBind = New System.Windows.Forms.Button
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.ScheduleDomainController1 = New Gravitybox.Controls.ScheduleDomainController
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.cmdBind)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 349)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(520, 40)
		Me.Panel1.TabIndex = 0
		'
		'cmdBind
		'
		Me.cmdBind.Location = New System.Drawing.Point(16, 8)
		Me.cmdBind.Name = "cmdBind"
		Me.cmdBind.Size = New System.Drawing.Size(120, 24)
		Me.cmdBind.TabIndex = 0
		Me.cmdBind.Text = "cmdBind"
		'
		'Schedule1
		'
		Me.Schedule1.AllowDrop = True
		Me.Schedule1.Appearance.FontSize = 10.0!
		Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.Schedule1.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.ColumnHeader.Appearance.NoFill = False
		Me.Schedule1.ColumnHeader.Size = 100
		Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.Appearance.NoFill = False
		Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.Schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.Schedule1.Location = New System.Drawing.Point(0, 0)
		Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
		Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
		Me.Schedule1.Name = "Schedule1"
		Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.RowHeader.Appearance.NoFill = False
		Me.Schedule1.RowHeader.Size = 30
		Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.SelectedAppointmentAppearance.NoFill = False
		Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
		Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
		Me.Schedule1.Selector.Appearance.FontSize = 10.0!
		Me.Schedule1.Selector.Appearance.NoFill = False
		Me.Schedule1.Size = New System.Drawing.Size(520, 349)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 3
		'
		'ScheduleDomainController1
		'
		Me.ScheduleDomainController1.ConnectionString = ""
		'
		'DataBinding
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(520, 389)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "DataBinding"
		Me.Text = "DataBinding"
		Me.Panel1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub cmdBind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBind.Click

		Schedule1.SetMinMaxDate(#3/1/2005#, #3/31/2005#)

		'Get appointments from a date range
		ScheduleDomainController1.ConnectionString = "data source=localhost;database=Gravitybox;uid=sa;pwd=;"
		Schedule1.DataSource = ScheduleDomainController1.GetScheduleDataSet("", Schedule1.MinDate, Schedule1.MaxDate)
		Schedule1.Bind()

	End Sub

End Class
