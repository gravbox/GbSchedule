Option Explicit On 
Option Strict On

Imports System.Data
Imports System.Data.OleDb

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
  Friend WithEvents OleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
  Friend WithEvents Label1 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection
    Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
    Me.Label1 = New System.Windows.Forms.Label
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
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
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
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(464, 221)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 0
    '
    'OleDbDataAdapter1
    '
    Me.OleDbDataAdapter1.DeleteCommand = Me.OleDbDeleteCommand1
    Me.OleDbDataAdapter1.InsertCommand = Me.OleDbInsertCommand1
    Me.OleDbDataAdapter1.SelectCommand = Me.OleDbSelectCommand1
    Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Appointment", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("appointment_guid", "appointment_guid"), New System.Data.Common.DataColumnMapping("length", "length"), New System.Data.Common.DataColumnMapping("start_date", "start_date"), New System.Data.Common.DataColumnMapping("start_time", "start_time"), New System.Data.Common.DataColumnMapping("subject", "subject")})})
    Me.OleDbDataAdapter1.UpdateCommand = Me.OleDbUpdateCommand1
    '
    'OleDbDeleteCommand1
    '
    Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Appointment WHERE (appointment_guid = ?)"
    Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "appointment_guid", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "length", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "length", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_date", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_date", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_time", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_time", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "subject", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "subject", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbConnection1
    '
    Me.OleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=schedule.mdb"
    '
    'OleDbInsertCommand1
    '
    Me.OleDbInsertCommand1.CommandText = "INSERT INTO Appointment(appointment_guid, length, start_date, start_time, subject" & _
    ") VALUES (?, ?, ?, ?, ?)"
    Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"))
    '
    'OleDbSelectCommand1
    '
    Me.OleDbSelectCommand1.CommandText = "SELECT appointment_guid, length, start_date, start_time, subject FROM Appointment" & _
    ""
    Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
    '
    'OleDbUpdateCommand1
    '
    Me.OleDbUpdateCommand1.CommandText = "UPDATE Appointment SET appointment_guid = ?, length = ?, start_date = ?, start_ti" & _
    "me = ?, subject = ? WHERE (appointment_guid = ?)"
    Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, "appointment_guid"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 100, "subject"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 36, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "appointment_guid", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "length", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_length1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "length", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_date", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_date", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_date1", System.Data.OleDb.OleDbType.DBDate, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_date", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_time", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_time", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_start_time1", System.Data.OleDb.OleDbType.Date, 0, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "start_time", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_subject", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "subject", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_subject1", System.Data.OleDb.OleDbType.VarWChar, 100, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "subject", System.Data.DataRowVersion.Original, Nothing))
    '
    'Label1
    '
    Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.Location = New System.Drawing.Point(8, 0)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(448, 40)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "This form interfaces with an MS-Access database and saves appointments. It only p" & _
    "ersists the appointment's key, start date, start time, length, and subject."
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 261)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Schedule1)
    Me.MinimumSize = New System.Drawing.Size(472, 288)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Dim MyDataset As GravityboxDataset

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the schedule
    Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.EventHeader.AllowHeader = False
    Schedule1.HeaderDateFormat = "MMM dd"

    'Setup the dataset
    MyDataset = New GravityboxDataset
    Me.OleDbDataAdapter1.Fill(MyDataset, "Appointment")

		Schedule1.DataSource = MyDataset
		Schedule1.Bind()

  End Sub

	Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentAdd

		Dim appointment As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
		appointment.Appearance.IsRound = True
		appointment.Appearance.BackColor = Color.LightBlue
		appointment.Appearance.BackColor2 = Color.White
		appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
		appointment.Appearance.Transparency = 40

	End Sub

	Private Sub Schedule1_DataSourceUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.DataSourceUpdated
		Me.OleDbDataAdapter1.Update(MyDataset)
	End Sub

End Class
