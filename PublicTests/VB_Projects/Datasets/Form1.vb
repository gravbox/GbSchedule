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
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents lblHeader As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.Button1 = New System.Windows.Forms.Button
    Me.Button2 = New System.Windows.Forms.Button
    Me.Button3 = New System.Windows.Forms.Button
    Me.lblHeader = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.Cursor = System.Windows.Forms.Cursors.Default
    Me.Schedule1.DataSource = Nothing
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 48)
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
    Me.Schedule1.Size = New System.Drawing.Size(600, 320)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Button1.Location = New System.Drawing.Point(8, 376)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(152, 24)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Create Dataset"
    '
    'Button2
    '
    Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Button2.Enabled = False
    Me.Button2.Location = New System.Drawing.Point(168, 376)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(152, 24)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "Add Appointments"
    '
    'Button3
    '
    Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Button3.Enabled = False
    Me.Button3.Location = New System.Drawing.Point(328, 376)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(152, 24)
    Me.Button3.TabIndex = 3
    Me.Button3.Text = "Remove Appointment"
    '
    'lblHeader
    '
    Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblHeader.Location = New System.Drawing.Point(0, 0)
    Me.lblHeader.Name = "lblHeader"
    Me.lblHeader.Size = New System.Drawing.Size(600, 48)
    Me.lblHeader.TabIndex = 4
    Me.lblHeader.Text = "[TEXT]"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(600, 405)
    Me.Controls.Add(Me.lblHeader)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Button3)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.Button1)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    'Setup the schedule
    Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.AllowRemove = True

    'Create a dataset with an "Appointment" table
    Dim ds As New System.Data.DataSet
    Dim dt As System.Data.DataTable = ds.Tables.Add("appointment")

    'Create the necessary columns
    dt.Columns.Add("appointment_guid", GetType(String))
    dt.Columns.Add("start_date", GetType(Date))
    dt.Columns.Add("start_time", GetType(Date))
    dt.Columns.Add("length", GetType(Integer))

    'Mark to disallow DBNull
    dt.Columns("appointment_guid").AllowDBNull = False
    dt.Columns("start_date").AllowDBNull = False
    dt.Columns("start_time").AllowDBNull = False
    dt.Columns("length").AllowDBNull = False

    'Mark the 'appointment_guid' column as a unique appointment_guid
    dt.Columns("appointment_guid").Unique = True

    'Optional Columns
    dt.Columns.Add("subject", GetType(String))
    dt.Columns.Add("ToolTipText", GetType(String))

    'Add datarows. This will be displayed by the schedule when it is databound
    Dim dr As System.Data.DataRow
    dr = CreateDataRow(dt, Guid.NewGuid().ToString(), #1/1/2004#, #8:00:00 AM#, 60, "Appointment 1")
    dr("ToolTipText") = "This is a tip!"
    dr = CreateDataRow(dt, Guid.NewGuid().ToString(), #1/2/2004#, #9:00:00 AM#, 60, "Appointment 2")
		dr = CreateDataRow(dt, Guid.NewGuid().ToString(), #1/3/2004#, #10:00:00 AM#, 60, "Appointment 3")

    'Bind the dataset to the schedule
    Schedule1.DataSource = ds
    Schedule1.Bind()

    DisplayAppointmentCount()

    Me.Button2.Enabled = True
    Me.Button3.Enabled = True

  End Sub

  Private Function CreateDataRow(ByVal dataTable As System.Data.DataTable, ByVal key As String, ByVal startDate As Date, ByVal startTime As Date, ByVal length As Integer, ByVal subject As String) As System.Data.DataRow

    'Create and populate a new row
    Dim dr As System.Data.DataRow = dataTable.NewRow()
    dr("appointment_guid") = key
    dr("start_date") = startDate
    dr("start_time") = startTime
    dr("length") = length
    dr("subject") = subject
    dataTable.Rows.Add(dr)
    Return dr

  End Function

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    'Add 4 appointments to the schedule
    Schedule1.AutoRedraw = False
    For ii As Integer = 0 To 3
      Dim appointment As Gravitybox.Objects.Appointment
      appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate.AddDays(ii), #11:00:00 AM#, 60)
      appointment.Subject = "Appointment " & Schedule1.AppointmentCollection.Count.ToString
    Next
    Schedule1.AutoRedraw = True
    DisplayAppointmentCount()

  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    'Remove an appointment if possible
    If Schedule1.AppointmentCollection.Count > 0 Then
      Schedule1.AppointmentCollection.RemoveAt(0)
      DisplayAppointmentCount()
    End If

  End Sub

  Private Sub DisplayAppointmentCount()

    'Display the current number of appointments in the dataset.
    'This shows that the dataset is being updated by the schedule
    Dim count As Integer = CType(Schedule1.DataSource, System.Data.DataSet).Tables(0).Rows.Count
    MessageBox.Show("The current number of appointments is " & count.ToString, "Appointment Count", MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub

  Private Sub Schedule1_DataSourceUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.DataSourceUpdated

    'Notification that the dataset has been updated
    Debug.WriteLine("DataSourceUpdated")

  End Sub

	Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentAdd

		'Setup the appointment to look nice
		Dim appointment As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
		appointment.Appearance.BackColor = Color.White
		appointment.Appearance.BackColor2 = Color.LightBlue
		appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal
		appointment.Appearance.IsRound = True

	End Sub

	Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		lblHeader.Text = "The first button below will create a dataset object and assign it to the schedule's Datasource property. The second button will add appointments to the schedule's AppointmentCollection and also update the underlying dataset. The third button will remove an appointment thereby updating the underlying dataset."
	End Sub

End Class
