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
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents Button1 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.Button1 = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 253)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(472, 40)
    Me.Panel1.TabIndex = 0
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(472, 253)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 1
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(16, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(80, 24)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Button1"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(472, 293)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Dim ds As New DataSet
		Dim dt As New DataTable("Appointment1")

		dt.Columns.Add("Appointment_GUID", GetType(String))
		dt.Columns.Add("start_date", GetType(Date))
		dt.Columns.Add("length", GetType(Integer))
		dt.Columns.Add("subject", GetType(String))

		dt.Columns(0).Unique = True
		dt.Columns(0).AllowDBNull = False
		dt.Columns(1).AllowDBNull = False
		dt.Columns(2).AllowDBNull = False

		AddRows(dt)

		ds.Tables.Add(dt)

		Schedule1.ColumnHeader.Size = 150
		Schedule1.SetMinMaxDate(Now, Now)
		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10

		Dim dv As New DataView(ds.Tables(0))
		dv.RowFilter = "length = 30"
		Schedule1.DataBindings.AppointmentBinding.DataSource = dv
		Schedule1.DataSource = ds
		Schedule1.Bind()

		For Each a As Gravitybox.Objects.Appointment In Schedule1.AppointmentCollection
			a.Appearance.BackColor = Color.LightBlue
		Next

		Debug.WriteLine(Schedule1.AppointmentCollection.Count)

	End Sub

	Private Sub AddRows(ByVal dt As DataTable)

		For ii As Integer = 0 To 9
			Dim dr As DataRow = dt.NewRow
			dr("appointment_guid") = Guid.NewGuid.ToString
			dr("start_date") = #1/19/2005 8:00:00 AM#.AddMinutes(30 * ii)
			dr("length") = IIf(ii Mod 2 = 0, 30, 60)
			dr("subject") = ii.ToString
			dt.Rows.Add(dr)
		Next

	End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    MsgBox(CType(Schedule1.DataSource, DataSet).Tables(0).Rows.Count)

  End Sub

End Class
