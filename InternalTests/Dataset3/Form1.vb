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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.Button1 = New System.Windows.Forms.Button
    Me.SuspendLayout()
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
    Me.Schedule1.Size = New System.Drawing.Size(432, 240)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(40, 224)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(72, 32)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Button1"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(440, 269)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Function CreateDataset() As System.Data.DataSet

    Dim ds As New DataSet

    '*****************************************************
    Dim dt As New DataTable("Appointment")
    dt.Columns.Add("appointment_guid", GetType(String))
    dt.Columns.Add("start_date", GetType(Date))
    dt.Columns.Add("start_time", GetType(Date))
    dt.Columns.Add("length", GetType(Integer))
    dt.Columns.Add("providerid", GetType(Integer))
    'dt.Columns.Add("jobid", GetType(Integer))

    dt.Columns("appointment_guid").Unique = True

    For Each dc As DataColumn In dt.Columns
      dc.AllowDBNull = False
    Next
    dt.Columns("providerid").AllowDBNull = True

    'Add appointment table
    ds.Tables.Add(dt)

    '*****************************************************
    dt = New DataTable("Category")
    dt.Columns.Add("category_guid", GetType(String))
    dt.Columns.Add("name", GetType(String))
    dt.Columns.Add("color", GetType(Integer))
    dt.Columns.Add("employeeid", GetType(Integer))

    dt.Columns("category_guid").Unique = True
    For Each dc As DataColumn In dt.Columns
      dc.AllowDBNull = False
    Next

    'Add category table
    ds.Tables.Add(dt)

    Return ds

  End Function

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Create a dataset with multiple tables
    Dim ds As DataSet = Me.CreateDataset()

    '**************************************
    'Create an categories
    Dim dr As DataRow = ds.Tables("Category").NewRow
    dr("category_guid") = "qqq"
    dr("name") = "Category 1"
    dr("color") = Color.Blue.ToArgb
    dr("employeeid") = 2001
    ds.Tables("Category").Rows.Add(dr)

    dr = ds.Tables("Category").NewRow
    dr("category_guid") = "www"
    dr("name") = "Category 2"
    dr("color") = Color.Yellow.ToArgb
    dr("employeeid") = 2002
    ds.Tables("Category").Rows.Add(dr)

    '**************************************
    'Create an appointment
    dr = ds.Tables("Appointment").NewRow
    dr("appointment_guid") = "qwe"
    dr("start_date") = Now
    dr("start_time") = #8:00:00 AM#
    dr("length") = 60
    'dr("jobid") = 101
    dr("providerid") = System.DBNull.Value
    ds.Tables("Appointment").Rows.Add(dr)

    '**************************************
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 4
    Schedule1.SetMinMaxDate(Now, Now)
    Schedule1.DataSource = ds

    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
    Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    'Schedule1.AppointmentCollection(0).PropertyItemCollection("jobid").Setting = "1"
    'Schedule1.AppointmentCollection(0).PropertyItemCollection("jobid").Setting = Nothing

    'ds.Tables(0).Rows(0).Item("JobID") = "102"
    'Schedule1.AppointmentCollection(0).PropertyItemCollection("jobid").Setting = "103"

    Schedule1.DataSource = Nothing
    Schedule1.AppointmentCollection.Clear()

    Schedule1.DataSource = ds
    Schedule1.Bind()

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Schedule1.SetMinMaxDate(Now, Now)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.ColumnHeader.AutoFit = True

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Dim ds As DataSet = CType(Schedule1.DataSource, DataSet)
    Dim count As Integer = ds.Tables("Appointment").Rows.Count
    Dim a As Gravitybox.Objects.Appointment = Schedule1.AppointmentCollection.Add("", Schedule1.MinDate, Schedule1.StartTime, 60)
    Schedule1.Dialogs.ShowPropertyDialog(a)
    count = ds.Tables("Appointment").Rows.Count
    Schedule1.AppointmentCollection.Remove(a)
    count = ds.Tables("Appointment").Rows.Count

  End Sub

End Class