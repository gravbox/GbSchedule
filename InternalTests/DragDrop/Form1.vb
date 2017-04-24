Public Class Form1
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
	Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
	Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents Timer1 As System.Windows.Forms.Timer
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.ListBox1 = New System.Windows.Forms.ListBox
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.SuspendLayout()
		'
		'ListBox1
		'
		Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Right
		Me.ListBox1.IntegralHeight = False
		Me.ListBox1.Location = New System.Drawing.Point(408, 0)
		Me.ListBox1.Name = "ListBox1"
		Me.ListBox1.Size = New System.Drawing.Size(168, 309)
		Me.ListBox1.TabIndex = 0
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
		Me.Schedule1.Size = New System.Drawing.Size(408, 309)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 1
		'
		'Timer1
		'
		Me.Timer1.Interval = 250
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(576, 309)
		Me.Controls.Add(Me.Schedule1)
		Me.Controls.Add(Me.ListBox1)
		Me.Name = "Form1"
		Me.Text = "Form1"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		For ii As Integer = 1 To 10
			ListBox1.Items.Add("Text " & ii.ToString())
		Next

	End Sub

	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		Timer1.Enabled = False
		ListBox1.DoDragDrop(90, DragDropEffects.Move)
	End Sub

	Private Sub ListBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDown
		Timer1.Enabled = True
	End Sub

	Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp
		Timer1.Enabled = False
	End Sub

	Private Sub Schedule1_BeforeForeignAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentForeignEventArgs) Handles Schedule1.BeforeForeignAdd
		Dim appt As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
		appt.Subject = ListBox1.SelectedItem
	End Sub

End Class
