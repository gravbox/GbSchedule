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
  Friend WithEvents lblHeader As System.Windows.Forms.Label
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.lblHeader = New System.Windows.Forms.Label
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'lblHeader
    '
    Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
    Me.lblHeader.Location = New System.Drawing.Point(0, 0)
    Me.lblHeader.Name = "lblHeader"
    Me.lblHeader.Size = New System.Drawing.Size(464, 40)
    Me.lblHeader.TabIndex = 3
    Me.lblHeader.Text = "[LABEL]"
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
    Me.Schedule1.DefaultAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 40)
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
    Me.Schedule1.SelectedAppointmentAppearance.ShadowSize = 0
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(464, 253)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 4
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 293)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.lblHeader)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule"
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "PopulateSchedule"

  Private Sub PopulateSchedule(ByVal ds As DataSet)

    'Map fields

    'Clear all bindings
    schedule1.DataBindings.FromXML("")

    'Appointment
    schedule1.DataBindings.AppointmentBinding.DataSource = ds.Tables("A_Table")
    schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("appointment_guid", "key")
    schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("start_date", "the_start")
    schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("length", "the_length")
    schedule1.DataBindings.AppointmentBinding.DataFieldBindingCollection.Add("subject", "the_text")

    'Category
    schedule1.DataBindings.CategoryBinding.DataSource = ds.Tables("C_Table")
    schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("category_guid", "key")
    schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("name", "the_text")
    schedule1.DataBindings.CategoryBinding.DataFieldBindingCollection.Add("color", "the_color")

    'Appointment-Category Link table
    schedule1.DataBindings.AppointmentCategoryBinding.DataSource = ds.Tables("AC_Table")
    schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("appointment_guid", "key1")
    schedule1.DataBindings.AppointmentCategoryBinding.DataFieldBindingCollection.Add("category_guid", "key2")

    'Provider
    schedule1.DataBindings.ProviderBinding.DataSource = ds.Tables("P_Table")
    schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("provider_guid", "key")
    schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("name", "the_text")
    schedule1.DataBindings.ProviderBinding.DataFieldBindingCollection.Add("color", "the_color")

    'Appointment-Provider Link table
    schedule1.DataBindings.AppointmentProviderBinding.DataSource = ds.Tables("AP_Table")
    schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("appointment_guid", "key1")
    schedule1.DataBindings.AppointmentProviderBinding.DataFieldBindingCollection.Add("provider_guid", "key2")

    'Room
    schedule1.DataBindings.RoomBinding.DataSource = ds.Tables("R_Table")
    schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("room_guid", "key")
    schedule1.DataBindings.RoomBinding.DataFieldBindingCollection.Add("name", "the_text")

    'Bind the dataset to the schedule
    schedule1.DataSource = ds
    schedule1.Bind()

    MessageBox.Show("Load Success!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub

#End Region

#Region "Form Load"

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    lblHeader.Text = "The dataset would normally be created by querying a database but in this example we will just build it manually."
    Dim ds As DataSet = CreateDataset()
    FillData(ds)
    PopulateSchedule(ds)

    'Setup the schedule
    schedule1.SetMinMaxDate(DateTime.Now, DateTime.Now.AddDays(5))
    schedule1.StartTime = New DateTime(2004, 1, 1, 8, 0, 0)
    schedule1.DayLength = 10
    schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
  End Sub

#End Region

#Region "CreateDataset"

  Private Function CreateDataset() As DataSet

    '**************************************
    'This method creates tables that will be 
    'mapped to the schedule control with data mapping
    'A_Table = Appointment
    'C_Table = Category
    'P_Table = Provider
    'R_Table = Room
    'AC_Table = AppointmentCategory
    'AP_Table = AppointmentProvider
    '**************************************

    'Create a new dataset
    Dim ds As DataSet = New DataSet
    Dim dt As DataTable = Nothing

    'Create the table to map to the Appointment table
    dt = New DataTable("A_Table")
    dt.Columns.Add("key", GetType(String))
    dt.Columns.Add("the_start", GetType(DateTime))
    dt.Columns.Add("the_length", GetType(Integer))
    dt.Columns.Add("the_text", GetType(String))
    ds.Tables.Add(dt)

    'Create the table to map to the Category table
    dt = New DataTable("C_Table")
    dt.Columns.Add("key", GetType(String))
    dt.Columns.Add("the_text", GetType(String))
    dt.Columns.Add("the_color", GetType(Integer))
    ds.Tables.Add(dt)

    'Create the table to map to the Provider table
    dt = New DataTable("P_Table")
    dt.Columns.Add("key", GetType(String))
    dt.Columns.Add("the_text", GetType(String))
    dt.Columns.Add("the_color", GetType(Integer))
    ds.Tables.Add(dt)

    'Create the table to map to the Room table
    dt = New DataTable("R_Table")
    dt.Columns.Add("key", GetType(String))
    dt.Columns.Add("the_text", GetType(String))
    ds.Tables.Add(dt)

    'Create the table to map to the Appoitment_Category table
    dt = New DataTable("AC_Table")
    dt.Columns.Add("key1", GetType(String))
    dt.Columns.Add("key2", GetType(String))
    ds.Tables.Add(dt)

    'Create the table to map to the Appoitment_Provider table
    dt = New DataTable("AP_Table")
    dt.Columns.Add("key1", GetType(String))
    dt.Columns.Add("key2", GetType(String))
    ds.Tables.Add(dt)

    'Set fields to be unique if required
    ds.Tables("A_Table").Columns("key").Unique = True
    ds.Tables("C_Table").Columns("key").Unique = True
    ds.Tables("P_Table").Columns("key").Unique = True
    ds.Tables("R_Table").Columns("key").Unique = True

    'Set fields to disallow Null if required
    ds.Tables("A_Table").Columns("key").AllowDBNull = False
    ds.Tables("A_Table").Columns("the_start").AllowDBNull = False
    ds.Tables("A_Table").Columns("the_length").AllowDBNull = False
    ds.Tables("C_Table").Columns("key").AllowDBNull = False
    ds.Tables("C_Table").Columns("the_text").AllowDBNull = False
    ds.Tables("C_Table").Columns("the_color").AllowDBNull = False
    ds.Tables("P_Table").Columns("key").AllowDBNull = False
    ds.Tables("P_Table").Columns("the_text").AllowDBNull = False
    ds.Tables("P_Table").Columns("the_color").AllowDBNull = False
    ds.Tables("R_Table").Columns("key").AllowDBNull = False
    ds.Tables("R_Table").Columns("the_text").AllowDBNull = False
    ds.Tables("AC_Table").Columns("key1").AllowDBNull = False
    ds.Tables("AC_Table").Columns("key2").AllowDBNull = False
    ds.Tables("AP_Table").Columns("key1").AllowDBNull = False
    ds.Tables("AP_Table").Columns("key2").AllowDBNull = False

    'Return the newly create dataset
    Return ds

  End Function

#End Region

#Region "FillData"

  Private Sub FillData(ByVal ds As DataSet)

    'This simulates loading from a database. There will be data in the dataset when we bind it
    Dim dr As DataRow = Nothing

    'Create an appointment at 9:00 AM tommorrow
    dr = ds.Tables("A_Table").NewRow()
    dr("key") = "A111" 'Some key
    dr("the_start") = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 9, 0, 0)
    dr("the_length") = 120 '2 hours
    dr("the_text") = "Test Appointment"
    ds.Tables("A_Table").Rows.Add(dr)

    'Create a Category
    dr = ds.Tables("C_Table").NewRow()
    dr("key") = "C111" 'Some key
    dr("the_text") = "Category 1"
    dr("the_Color") = Color.Blue.ToArgb()
    ds.Tables("C_Table").Rows.Add(dr)

    'Create a Provider
    dr = ds.Tables("P_Table").NewRow()
    dr("key") = "P111" 'Some key
    dr("the_text") = "Provider 1"
    dr("the_Color") = Color.Yellow.ToArgb()
    ds.Tables("P_Table").Rows.Add(dr)

    'Connect the Appointment and Category
    dr = ds.Tables("AC_Table").NewRow()
    dr("key1") = "A111"
    dr("key2") = "C111"
    ds.Tables("AC_Table").Rows.Add(dr)

    'Connect the Appointment and Provider
    dr = ds.Tables("AP_Table").NewRow()
    dr("key1") = "A111"
    dr("key2") = "P111"
    ds.Tables("AP_Table").Rows.Add(dr)

  End Sub

#End Region

End Class
