Option Explicit On 
Option Strict On

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
  Friend WithEvents OleDbConnection As System.Data.OleDb.OleDbConnection
  Friend WithEvents OleDbAppointment As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents Appointment As Datasets.ScheduleDataset
  Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents OleDbAppointment_Category As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDeleteCommand5 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand5 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand5 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand5 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbRoom As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDeleteCommand4 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand4 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand4 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand4 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbAppointment_Provider As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDeleteCommand6 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand6 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand6 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand6 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbProvider As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDeleteCommand3 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand3 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand3 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand3 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbCategory As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDeleteCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents cmdButton1 As System.Windows.Forms.Button
  Friend WithEvents OleDbAppearance As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbCommand3 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbCommand4 As System.Data.OleDb.OleDbCommand

  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.lblHeader = New System.Windows.Forms.Label
    Me.OleDbConnection = New System.Data.OleDb.OleDbConnection
    Me.OleDbAppointment = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand
    Me.Appointment = New Datasets.ScheduleDataset
    Me.cmdSave = New System.Windows.Forms.Button
    Me.OleDbAppointment_Category = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand5 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand5 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand5 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand5 = New System.Data.OleDb.OleDbCommand
    Me.OleDbRoom = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand4 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand4 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand4 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand4 = New System.Data.OleDb.OleDbCommand
    Me.OleDbAppointment_Provider = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand6 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand6 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand6 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand6 = New System.Data.OleDb.OleDbCommand
    Me.OleDbProvider = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand3 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand3 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand3 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand3 = New System.Data.OleDb.OleDbCommand
    Me.OleDbCategory = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand
    Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand
    Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand
    Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand
    Me.cmdButton1 = New System.Windows.Forms.Button
    Me.OleDbAppearance = New System.Data.OleDb.OleDbDataAdapter
    Me.OleDbCommand1 = New System.Data.OleDb.OleDbCommand
    Me.OleDbCommand2 = New System.Data.OleDb.OleDbCommand
    Me.OleDbCommand3 = New System.Data.OleDb.OleDbCommand
    Me.OleDbCommand4 = New System.Data.OleDb.OleDbCommand
    CType(Me.Appointment, System.ComponentModel.ISupportInitialize).BeginInit()
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
    'OleDbAppointment
    '
    Me.OleDbAppointment.DeleteCommand = Me.OleDbDeleteCommand1
    Me.OleDbAppointment.InsertCommand = Me.OleDbInsertCommand1
    Me.OleDbAppointment.SelectCommand = Me.OleDbSelectCommand1
    Me.OleDbAppointment.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Appointment", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("appointment_guid", "appointment_guid"), New System.Data.Common.DataColumnMapping("blockout", "blockout"), New System.Data.Common.DataColumnMapping("isevent", "isevent"), New System.Data.Common.DataColumnMapping("isflagged", "isflagged"), New System.Data.Common.DataColumnMapping("isreadonly", "isreadonly"), New System.Data.Common.DataColumnMapping("length", "length"), New System.Data.Common.DataColumnMapping("maxlength", "maxlength"), New System.Data.Common.DataColumnMapping("minlength", "minlength"), New System.Data.Common.DataColumnMapping("notes", "notes"), New System.Data.Common.DataColumnMapping("priority", "priority"), New System.Data.Common.DataColumnMapping("recurrenceid", "recurrenceid"), New System.Data.Common.DataColumnMapping("room_guid", "room_guid"), New System.Data.Common.DataColumnMapping("start_date", "start_date"), New System.Data.Common.DataColumnMapping("start_time", "start_time"), New System.Data.Common.DataColumnMapping("subject", "subject"), New System.Data.Common.DataColumnMapping("text", "text"), New System.Data.Common.DataColumnMapping("tooltiptext", "tooltiptext"), New System.Data.Common.DataColumnMapping("visible", "visible")})})
    Me.OleDbAppointment.UpdateCommand = Me.OleDbUpdateCommand1
    '
    'OleDbDeleteCommand1
    '
    Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Appointment WHERE (appointment_guid = ?)"
    Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "appointment_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand1
    '
    Me.OleDbInsertCommand1.CommandText = "INSERT INTO Appointment (appointment_guid, blockout, isevent, isflagged, isreadon" & _
    "ly, length, maxlength, minlength, notes, priority, recurrenceid, room_guid, star" & _
    "t_date, start_time, subject, [text], tooltiptext, visible) VALUES (?, ?, ?, ?, ?" & _
    ", ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
    Me.OleDbInsertCommand1.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("blockout", System.Data.OleDb.OleDbType.Boolean, 2, "blockout"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isevent", System.Data.OleDb.OleDbType.Boolean, 2, "isevent"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isflagged", System.Data.OleDb.OleDbType.Boolean, 2, "isflagged"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isreadonly", System.Data.OleDb.OleDbType.Boolean, 2, "isreadonly"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("maxlength", System.Data.OleDb.OleDbType.Integer, 0, "maxlength"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("minlength", System.Data.OleDb.OleDbType.Integer, 0, "minlength"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("notes", System.Data.OleDb.OleDbType.VarWChar, 255, "notes"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("priority", System.Data.OleDb.OleDbType.Integer, 0, "priority"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("recurrenceid", System.Data.OleDb.OleDbType.VarWChar, 255, "recurrenceid"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("room_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "room_guid"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 50, "subject"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("text", System.Data.OleDb.OleDbType.VarWChar, 50, "text"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("tooltiptext", System.Data.OleDb.OleDbType.VarWChar, 50, "tooltiptext"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("visible", System.Data.OleDb.OleDbType.Boolean, 2, "visible"))
    '
    'OleDbSelectCommand1
    '
    Me.OleDbSelectCommand1.CommandText = "SELECT appointment_guid, blockout, isevent, isflagged, isreadonly, length, maxlen" & _
    "gth, minlength, notes, priority, recurrenceid, room_guid, start_date, start_time" & _
    ", subject, [text], tooltiptext, visible FROM Appointment"
    Me.OleDbSelectCommand1.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand1
    '
    Me.OleDbUpdateCommand1.CommandText = "UPDATE Appointment SET blockout = ?, isevent = ?, isflagged = ?, isreadonly = ?, " & _
    "length = ?, maxlength = ?, minlength = ?, notes = ?, priority = ?, recurrenceid " & _
    "= ?, room_guid = ?, start_date = ?, start_time = ?, subject = ?, [text] = ?, too" & _
    "ltiptext = ?, visible = ? WHERE appointment_guid = ?"
    Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("blockout", System.Data.OleDb.OleDbType.Boolean, 2, "blockout"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isevent", System.Data.OleDb.OleDbType.Boolean, 2, "isevent"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isflagged", System.Data.OleDb.OleDbType.Boolean, 2, "isflagged"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("isreadonly", System.Data.OleDb.OleDbType.Boolean, 2, "isreadonly"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("maxlength", System.Data.OleDb.OleDbType.Integer, 0, "maxlength"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("minlength", System.Data.OleDb.OleDbType.Integer, 0, "minlength"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("notes", System.Data.OleDb.OleDbType.VarWChar, 255, "notes"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("priority", System.Data.OleDb.OleDbType.Integer, 0, "priority"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("recurrenceid", System.Data.OleDb.OleDbType.VarWChar, 255, "recurrenceid"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("room_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "room_guid"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_date", System.Data.OleDb.OleDbType.DBDate, 0, "start_date"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("start_time", System.Data.OleDb.OleDbType.Date, 0, "start_time"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("subject", System.Data.OleDb.OleDbType.VarWChar, 50, "subject"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("text", System.Data.OleDb.OleDbType.VarWChar, 50, "text"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("tooltiptext", System.Data.OleDb.OleDbType.VarWChar, 50, "tooltiptext"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("visible", System.Data.OleDb.OleDbType.Boolean, 2, "visible"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    '
    'Appointment
    '
    Me.Appointment.DataSetName = "Appointment"
    Me.Appointment.Locale = New System.Globalization.CultureInfo("fr-CH")
    '
    'cmdSave
    '
    Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdSave.Location = New System.Drawing.Point(512, 376)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(80, 24)
    Me.cmdSave.TabIndex = 5
    Me.cmdSave.Text = "Save"
    '
    'OleDbAppointment_Category
    '
    Me.OleDbAppointment_Category.DeleteCommand = Me.OleDbDeleteCommand5
    Me.OleDbAppointment_Category.InsertCommand = Me.OleDbInsertCommand5
    Me.OleDbAppointment_Category.SelectCommand = Me.OleDbSelectCommand5
    Me.OleDbAppointment_Category.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Appointment_Category", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("appointment_guid", "appointment_guid"), New System.Data.Common.DataColumnMapping("category_guid", "category_guid")})})
    Me.OleDbAppointment_Category.UpdateCommand = Me.OleDbUpdateCommand5
    '
    'OleDbDeleteCommand5
    '
    Me.OleDbDeleteCommand5.CommandText = "DELETE FROM Appointment_Category WHERE (appointment_guid = ?)"
    Me.OleDbDeleteCommand5.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "appointment_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand5
    '
    Me.OleDbInsertCommand5.CommandText = "INSERT INTO Appointment_Category(appointment_guid, category_guid) VALUES (?, ?)"
    Me.OleDbInsertCommand5.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    Me.OleDbInsertCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("category_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "category_guid"))
    '
    'OleDbSelectCommand5
    '
    Me.OleDbSelectCommand5.CommandText = "SELECT appointment_guid, category_guid FROM Appointment_Category"
    Me.OleDbSelectCommand5.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand5
    '
    Me.OleDbUpdateCommand5.CommandText = "UPDATE Appointment_Category SET appointment_guid = ?, category_guid = ?"
    Me.OleDbUpdateCommand5.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    Me.OleDbUpdateCommand5.Parameters.Add(New System.Data.OleDb.OleDbParameter("category_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "category_guid"))
    '
    'OleDbRoom
    '
    Me.OleDbRoom.DeleteCommand = Me.OleDbDeleteCommand4
    Me.OleDbRoom.InsertCommand = Me.OleDbInsertCommand4
    Me.OleDbRoom.SelectCommand = Me.OleDbSelectCommand4
    Me.OleDbRoom.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Room", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("name", "name"), New System.Data.Common.DataColumnMapping("room_guid", "room_guid")})})
    Me.OleDbRoom.UpdateCommand = Me.OleDbUpdateCommand4
    '
    'OleDbDeleteCommand4
    '
    Me.OleDbDeleteCommand4.CommandText = "DELETE FROM Room WHERE (room_guid = ?)"
    Me.OleDbDeleteCommand4.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("room_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "room_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand4
    '
    Me.OleDbInsertCommand4.CommandText = "INSERT INTO Room(name, room_guid) VALUES (?, ?)"
    Me.OleDbInsertCommand4.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    Me.OleDbInsertCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("room_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "room_guid"))
    '
    'OleDbSelectCommand4
    '
    Me.OleDbSelectCommand4.CommandText = "SELECT name, room_guid FROM Room"
    Me.OleDbSelectCommand4.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand4
    '
    Me.OleDbUpdateCommand4.CommandText = "UPDATE Room SET name = ?, room_guid = ?"
    Me.OleDbUpdateCommand4.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    Me.OleDbUpdateCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("room_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "room_guid"))
    '
    'OleDbAppointment_Provider
    '
    Me.OleDbAppointment_Provider.DeleteCommand = Me.OleDbDeleteCommand6
    Me.OleDbAppointment_Provider.InsertCommand = Me.OleDbInsertCommand6
    Me.OleDbAppointment_Provider.SelectCommand = Me.OleDbSelectCommand6
    Me.OleDbAppointment_Provider.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Appointment_Provider", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("appointment_guid", "appointment_guid"), New System.Data.Common.DataColumnMapping("provider_guid", "provider_guid")})})
    Me.OleDbAppointment_Provider.UpdateCommand = Me.OleDbUpdateCommand6
    '
    'OleDbDeleteCommand6
    '
    Me.OleDbDeleteCommand6.CommandText = "DELETE FROM Appointment_Provider WHERE (appointment_guid = ?)"
    Me.OleDbDeleteCommand6.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "appointment_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand6
    '
    Me.OleDbInsertCommand6.CommandText = "INSERT INTO Appointment_Provider(appointment_guid, provider_guid) VALUES (?, ?)"
    Me.OleDbInsertCommand6.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    Me.OleDbInsertCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("provider_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "provider_guid"))
    '
    'OleDbSelectCommand6
    '
    Me.OleDbSelectCommand6.CommandText = "SELECT appointment_guid, provider_guid FROM Appointment_Provider"
    Me.OleDbSelectCommand6.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand6
    '
    Me.OleDbUpdateCommand6.CommandText = "UPDATE Appointment_Provider SET appointment_guid = ?, provider_guid = ?"
    Me.OleDbUpdateCommand6.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("appointment_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appointment_guid"))
    Me.OleDbUpdateCommand6.Parameters.Add(New System.Data.OleDb.OleDbParameter("provider_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "provider_guid"))
    '
    'OleDbProvider
    '
    Me.OleDbProvider.DeleteCommand = Me.OleDbDeleteCommand3
    Me.OleDbProvider.InsertCommand = Me.OleDbInsertCommand3
    Me.OleDbProvider.SelectCommand = Me.OleDbSelectCommand3
    Me.OleDbProvider.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Provider", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("color", "color"), New System.Data.Common.DataColumnMapping("name", "name"), New System.Data.Common.DataColumnMapping("provider_guid", "provider_guid")})})
    Me.OleDbProvider.UpdateCommand = Me.OleDbUpdateCommand3
    '
    'OleDbDeleteCommand3
    '
    Me.OleDbDeleteCommand3.CommandText = "DELETE FROM Provider WHERE (provider_guid = ?)"
    Me.OleDbDeleteCommand3.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("provider_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "provider_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand3
    '
    Me.OleDbInsertCommand3.CommandText = "INSERT INTO Provider(color, name, provider_guid) VALUES (?, ?, ?)"
    Me.OleDbInsertCommand3.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("color", System.Data.OleDb.OleDbType.Integer, 0, "color"))
    Me.OleDbInsertCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    Me.OleDbInsertCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("provider_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "provider_guid"))
    '
    'OleDbSelectCommand3
    '
    Me.OleDbSelectCommand3.CommandText = "SELECT color, name, provider_guid FROM Provider"
    Me.OleDbSelectCommand3.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand3
    '
    Me.OleDbUpdateCommand3.CommandText = "UPDATE Provider SET color = ?, name = ?, provider_guid = ?"
    Me.OleDbUpdateCommand3.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("color", System.Data.OleDb.OleDbType.Integer, 0, "color"))
    Me.OleDbUpdateCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    Me.OleDbUpdateCommand3.Parameters.Add(New System.Data.OleDb.OleDbParameter("provider_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "provider_guid"))
    '
    'OleDbCategory
    '
    Me.OleDbCategory.DeleteCommand = Me.OleDbDeleteCommand2
    Me.OleDbCategory.InsertCommand = Me.OleDbInsertCommand2
    Me.OleDbCategory.SelectCommand = Me.OleDbSelectCommand2
    Me.OleDbCategory.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Category", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("category_guid", "category_guid"), New System.Data.Common.DataColumnMapping("color", "color"), New System.Data.Common.DataColumnMapping("name", "name")})})
    Me.OleDbCategory.UpdateCommand = Me.OleDbUpdateCommand2
    '
    'OleDbDeleteCommand2
    '
    Me.OleDbDeleteCommand2.CommandText = "DELETE FROM Category WHERE (category_guid = ?)"
    Me.OleDbDeleteCommand2.Connection = Me.OleDbConnection
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("category_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "category_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbInsertCommand2
    '
    Me.OleDbInsertCommand2.CommandText = "INSERT INTO Category (category_guid, color, name) VALUES (?, ?, ?)"
    Me.OleDbInsertCommand2.Connection = Me.OleDbConnection
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("category_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "category_guid"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("color", System.Data.OleDb.OleDbType.Integer, 0, "color"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    '
    'OleDbSelectCommand2
    '
    Me.OleDbSelectCommand2.CommandText = "SELECT category_guid, color, name FROM Category"
    Me.OleDbSelectCommand2.Connection = Me.OleDbConnection
    '
    'OleDbUpdateCommand2
    '
    Me.OleDbUpdateCommand2.CommandText = "UPDATE Category SET category_guid = ?, color = ?, name = ?"
    Me.OleDbUpdateCommand2.Connection = Me.OleDbConnection
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("category_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "category_guid"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("color", System.Data.OleDb.OleDbType.Integer, 0, "color"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.VarWChar, 50, "name"))
    '
    'cmdButton1
    '
    Me.cmdButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdButton1.Location = New System.Drawing.Point(8, 376)
    Me.cmdButton1.Name = "cmdButton1"
    Me.cmdButton1.Size = New System.Drawing.Size(80, 24)
    Me.cmdButton1.TabIndex = 6
    Me.cmdButton1.Text = "Button1"
    '
    'OleDbAppearance
    '
    Me.OleDbAppearance.DeleteCommand = Me.OleDbCommand1
    Me.OleDbAppearance.InsertCommand = Me.OleDbCommand2
    Me.OleDbAppearance.SelectCommand = Me.OleDbCommand3
    Me.OleDbAppearance.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Category", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("category_guid", "category_guid"), New System.Data.Common.DataColumnMapping("color", "color"), New System.Data.Common.DataColumnMapping("name", "name")})})
    Me.OleDbAppearance.UpdateCommand = Me.OleDbCommand4
    '
    'OleDbCommand1
    '
    Me.OleDbCommand1.CommandText = "DELETE FROM Appearance WHERE (appearance_guid = ?)"
    Me.OleDbCommand1.Connection = Me.OleDbConnection
    Me.OleDbCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("appearance_guid", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "category_guid", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbCommand2
    '
    Me.OleDbCommand2.CommandText = "INSERT INTO Appearance (appearance_guid, backcolor, backcolor2, forecolor, isround) VALUES (?, ?, ?, ?, ?)"
    Me.OleDbCommand2.Connection = Me.OleDbConnection
    Me.OleDbCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("appearance_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appearance_guid"))
    Me.OleDbCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("backcolor", System.Data.OleDb.OleDbType.Integer, 0, "backcolor"))
    Me.OleDbCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("backcolor2", System.Data.OleDb.OleDbType.Integer, 0, "backcolor2"))
    Me.OleDbCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("forecolor", System.Data.OleDb.OleDbType.Integer, 0, "forecolor"))
    Me.OleDbCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("isround", System.Data.OleDb.OleDbType.Boolean, 0, "isround"))
    '
    'OleDbCommand3
    '
    Me.OleDbCommand3.CommandText = "SELECT appearance_guid, backcolor, backcolor2, forecolor, isround FROM Appearance"
    Me.OleDbCommand3.Connection = Me.OleDbConnection
    '
    'OleDbCommand4
    '
    Me.OleDbCommand4.CommandText = "UPDATE Appearance SET backcolor = ?, backcolor2 = ?, forecolor = ?, isround = ? WHERE appearance_guid = ?"
    Me.OleDbCommand4.Connection = Me.OleDbConnection
    Me.OleDbCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("backcolor", System.Data.OleDb.OleDbType.Integer, 0, "backcolor"))
    Me.OleDbCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("backcolor2", System.Data.OleDb.OleDbType.Integer, 0, "backcolor2"))
    Me.OleDbCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("forecolor", System.Data.OleDb.OleDbType.Integer, 0, "forecolor"))
    Me.OleDbCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("isround", System.Data.OleDb.OleDbType.Boolean, 1, "isround"))
    Me.OleDbCommand4.Parameters.Add(New System.Data.OleDb.OleDbParameter("appearance_guid", System.Data.OleDb.OleDbType.VarWChar, 255, "appearance_guid"))
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(600, 405)
    Me.Controls.Add(Me.cmdButton1)
    Me.Controls.Add(Me.cmdSave)
    Me.Controls.Add(Me.lblHeader)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    CType(Me.Appointment, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

#Region "Binding"

  Private Sub BindDataset()

    'Bind the dataset to the schedule
    '*** Order Important ***
    Me.OleDbAppearance.Fill(Me.Appointment)
    Me.OleDbRoom.Fill(Me.Appointment)
    Me.OleDbCategory.Fill(Me.Appointment)
    Me.OleDbProvider.Fill(Me.Appointment)
    Me.OleDbAppointment.Fill(Me.Appointment)
    Me.OleDbAppointment_Category.Fill(Me.Appointment)
    Me.OleDbAppointment_Provider.Fill(Me.Appointment)
    Me.Schedule1.DataSource = Me.Appointment

  End Sub

  Private Sub UpdateDataset()

    Try
      'Save the modified tables back to the database
      '*** Order Important ***
      Me.OleDbAppearance.Update(Me.Appointment)
      Me.OleDbRoom.Update(Me.Appointment)
      Me.OleDbCategory.Update(Me.Appointment)
      Me.OleDbProvider.Update(Me.Appointment)
      Me.OleDbAppointment.Update(Me.Appointment)
      Me.OleDbAppointment_Category.Update(Me.Appointment)
      Me.OleDbAppointment_Provider.Update(Me.Appointment)

      'Refresh the dataset after save
      Me.BindDataset()

    Catch ex As Exception
      MsgBox(ex.ToString)
    End Try

  End Sub

#End Region

#Region "Methods"

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Me.UpdateDataset()
  End Sub

  Private Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    Me.UpdateDataset()
  End Sub

  Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterAppointmentAdd

    'If Schedule1.AppearanceCollection.Count > 0 Then
    '  e.Appointment.Appearance = CType(Schedule1.AppearanceCollection(0), Gravitybox.Objects.AppointmentAppearance)
    'End If

    'Setup the appointment to look nice
    Dim appt As Gravitybox.Objects.Appointment = CType(e.BaseObject, Gravitybox.Objects.Appointment)
    appt.Appearance.BackColor = Color.White
    appt.Appearance.BackColor2 = Color.LightBlue
    appt.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal
    appt.Appearance.IsRound = True

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    lblHeader.Text = "The first button below will create a dataset object and assign it to the schedule's Datasource property. The second button will add appointments to the schedule's AppointmentCollection and also update the underlying dataset. The third button will remove an appointment thereby updating the underlying dataset."

    'Setup the Dataset
    'Mark to disallow DBNull
    Me.Appointment.Appointment.Columns("appointment_guid").AllowDBNull = False
    Me.Appointment.Appointment.Columns("length").AllowDBNull = False
    Me.Appointment.Appointment.Columns("start_date").AllowDBNull = False
    Me.Appointment.Appointment.Columns("start_time").AllowDBNull = False

    Me.Appointment.Category.Columns("category_guid").AllowDBNull = False
    Me.Appointment.Category.Columns("name").AllowDBNull = False
    Me.Appointment.Category.Columns("color").AllowDBNull = False

    Me.Appointment.Provider.Columns("provider_guid").AllowDBNull = False
    Me.Appointment.Provider.Columns("name").AllowDBNull = False
    Me.Appointment.Provider.Columns("color").AllowDBNull = False

    Me.Appointment.Room.Columns("room_guid").AllowDBNull = False
    Me.Appointment.Room.Columns("name").AllowDBNull = False

    'Me.Appointment.Appearance.Columns("appearance_guid").AllowDBNull = False

    'Setup the datasource
    Me.OleDbConnection.ConnectionString = "Provider=""Microsoft.Jet.OleDb.4.0""; Data Source=""" & AppPath() & "Schedule.mdb"""

    'Setup the schedule
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
    Schedule1.SetMinMaxDate(#1/1/2004#, #1/4/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.ColumnHeader.AutoFit = True
    Schedule1.AllowRemove = True

    'Bind the dataset to the schedule
    Me.BindDataset()

    'Add rooms if there are none
    If Schedule1.RoomCollection.Count = 0 Then
      Schedule1.RoomCollection.Add("", "Room1")
      Schedule1.RoomCollection.Add("", "Room2")
    End If

    'Add providers if there are none
    If Schedule1.ProviderCollection.Count = 0 Then
      Schedule1.ProviderCollection.Add("", "Provider1")
      Schedule1.ProviderCollection.Add("", "Provider2")
    End If

    'Add categories if there are none
    If Schedule1.CategoryCollection.Count = 0 Then
      Schedule1.CategoryCollection.Add("", "Category1")
      Schedule1.CategoryCollection.Add("", "Category2")
    End If

  End Sub

#End Region

#Region "AppPath"

  Public Function AppPath() As String

    Try
      Dim retval As String = Application.ExecutablePath
      retval = New System.IO.DirectoryInfo(retval).Parent.FullName
      If Not retval.EndsWith("\") Then retval &= "\"
      Return retval
      'Return Application.StartupPath

    Catch ex As Exception
      System.Diagnostics.EventLog.WriteEntry(System.Reflection.Assembly.GetExecutingAssembly.FullName, ex.ToString())
    End Try

  End Function

#End Region

  Private Sub cmdButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdButton1.Click

    Dim ds As New ScheduleDataset
    Schedule1.DataSource = ds

  End Sub

End Class
