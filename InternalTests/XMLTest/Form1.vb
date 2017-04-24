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
  Friend WithEvents cmdLoadCategory As System.Windows.Forms.Button
  Friend WithEvents cmdLoadProvider As System.Windows.Forms.Button
  Friend WithEvents cmdLoadAppointment As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cmdSaveAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdSaveProvider As System.Windows.Forms.Button
  Friend WithEvents cmdSaveCategory As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cmdClearAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdClearProvider As System.Windows.Forms.Button
  Friend WithEvents cmdClearCategory As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.cmdLoadCategory = New System.Windows.Forms.Button
    Me.cmdLoadProvider = New System.Windows.Forms.Button
    Me.cmdLoadAppointment = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.cmdSaveAppointment = New System.Windows.Forms.Button
    Me.cmdSaveProvider = New System.Windows.Forms.Button
    Me.cmdSaveCategory = New System.Windows.Forms.Button
    Me.Label3 = New System.Windows.Forms.Label
    Me.cmdClearAppointment = New System.Windows.Forms.Button
    Me.cmdClearProvider = New System.Windows.Forms.Button
    Me.cmdClearCategory = New System.Windows.Forms.Button
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowCopy = True
    Me.Schedule1.AllowDragTip = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowEvents = True
    Me.Schedule1.AllowForeignDrops = True
    Me.Schedule1.AllowGrid = True
    Me.Schedule1.AllowHighlightBar = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
    Me.Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
    Me.Schedule1.DayLength = 12
    Me.Schedule1.EventHeaderColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
    Me.Schedule1.GridBackColor = System.Drawing.Color.White
    Me.Schedule1.GridForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.MultiSelect = False
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(608, 368)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'cmdLoadCategory
    '
    Me.cmdLoadCategory.Location = New System.Drawing.Point(80, 408)
    Me.cmdLoadCategory.Name = "cmdLoadCategory"
    Me.cmdLoadCategory.Size = New System.Drawing.Size(96, 24)
    Me.cmdLoadCategory.TabIndex = 1
    Me.cmdLoadCategory.Text = "Category"
    '
    'cmdLoadProvider
    '
    Me.cmdLoadProvider.Location = New System.Drawing.Point(184, 408)
    Me.cmdLoadProvider.Name = "cmdLoadProvider"
    Me.cmdLoadProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdLoadProvider.TabIndex = 2
    Me.cmdLoadProvider.Text = "Provider"
    '
    'cmdLoadAppointment
    '
    Me.cmdLoadAppointment.Location = New System.Drawing.Point(288, 408)
    Me.cmdLoadAppointment.Name = "cmdLoadAppointment"
    Me.cmdLoadAppointment.Size = New System.Drawing.Size(96, 24)
    Me.cmdLoadAppointment.TabIndex = 3
    Me.cmdLoadAppointment.Text = "Appointment"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 384)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Save"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 416)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(56, 16)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "Load"
    '
    'cmdSaveAppointment
    '
    Me.cmdSaveAppointment.Location = New System.Drawing.Point(288, 376)
    Me.cmdSaveAppointment.Name = "cmdSaveAppointment"
    Me.cmdSaveAppointment.Size = New System.Drawing.Size(96, 24)
    Me.cmdSaveAppointment.TabIndex = 7
    Me.cmdSaveAppointment.Text = "Appointment"
    '
    'cmdSaveProvider
    '
    Me.cmdSaveProvider.Location = New System.Drawing.Point(184, 376)
    Me.cmdSaveProvider.Name = "cmdSaveProvider"
    Me.cmdSaveProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdSaveProvider.TabIndex = 6
    Me.cmdSaveProvider.Text = "Provider"
    '
    'cmdSaveCategory
    '
    Me.cmdSaveCategory.Location = New System.Drawing.Point(80, 376)
    Me.cmdSaveCategory.Name = "cmdSaveCategory"
    Me.cmdSaveCategory.Size = New System.Drawing.Size(96, 24)
    Me.cmdSaveCategory.TabIndex = 5
    Me.cmdSaveCategory.Text = "Category"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 448)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(56, 16)
    Me.Label3.TabIndex = 12
    Me.Label3.Text = "Clear"
    '
    'cmdClearAppointment
    '
    Me.cmdClearAppointment.Location = New System.Drawing.Point(288, 440)
    Me.cmdClearAppointment.Name = "cmdClearAppointment"
    Me.cmdClearAppointment.Size = New System.Drawing.Size(96, 24)
    Me.cmdClearAppointment.TabIndex = 11
    Me.cmdClearAppointment.Text = "Appointment"
    '
    'cmdClearProvider
    '
    Me.cmdClearProvider.Location = New System.Drawing.Point(184, 440)
    Me.cmdClearProvider.Name = "cmdClearProvider"
    Me.cmdClearProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdClearProvider.TabIndex = 10
    Me.cmdClearProvider.Text = "Provider"
    '
    'cmdClearCategory
    '
    Me.cmdClearCategory.Location = New System.Drawing.Point(80, 440)
    Me.cmdClearCategory.Name = "cmdClearCategory"
    Me.cmdClearCategory.Size = New System.Drawing.Size(96, 24)
    Me.cmdClearCategory.TabIndex = 9
    Me.cmdClearCategory.Text = "Category"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(608, 469)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.cmdClearAppointment, Me.cmdClearProvider, Me.cmdClearCategory, Me.Label2, Me.cmdSaveAppointment, Me.cmdSaveProvider, Me.cmdSaveCategory, Me.Label1, Me.cmdLoadAppointment, Me.cmdLoadProvider, Me.cmdLoadCategory, Me.Schedule1})
    Me.Name = "Form1"
    Me.Text = "XML Test"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Add Categories
    Call Schedule1.CategoryCollection.Add("", "Category 1", Color.Blue)
    Call Schedule1.CategoryCollection.Add("", "Category 2", Color.DarkMagenta)
    Call Schedule1.CategoryCollection.Add("", "Category 3", Color.Lime)

    'Add Providers
    Call Schedule1.ProviderCollection.Add("", "Provider 1", Color.Aquamarine)
    Call Schedule1.ProviderCollection.Add("", "Provider 2", Color.DarkSlateBlue)
    Call Schedule1.ProviderCollection.Add("", "Provider 3", Color.MediumSeaGreen)

    'Add Rooms
    Call Schedule1.RoomCollection.Add("", "Room 1")
    Call Schedule1.RoomCollection.Add("", "Room 2")
    Call Schedule1.RoomCollection.Add("", "Room 3")

    'Add Appointments
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "This is an appointment"
    appointment.Room = Schedule1.RoomCollection(0)
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
    Call appointment.CategoryList.Add(Schedule1.CategoryCollection(2))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(2))
    appointment.Header.Icon = Schedule1.ScheduleIcons.IconInfo
    appointment.Header.HeaderType = Gravitybox.Objects.AppointmentHeader.HeaderTypeConstants.TimeHeader
    appointment.IconCollection.Add("", Schedule1.DefaultIcons.IconFlag)

    'appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:00:00 AM#, 60)
    'appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:00:00 AM#, 60)

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft

    'Blue Scheme
    Schedule1.RowHeader.BackColor = Color.LightBlue
    Schedule1.ColumnHeader.BackColor = Color.LightBlue
    Schedule1.BackColor = Color.LightBlue
    Schedule1.GridBackColor = Color.FromArgb(238, 230, 247)

    'Green Scheme
    Schedule1.RowHeader.BackColor = Color.LightGreen
    Schedule1.ColumnHeader.BackColor = Color.LightGreen
    Schedule1.BackColor = Color.LightGreen
    Schedule1.GridBackColor = Color.FromArgb(255, 251, 225)

  End Sub

  Private Sub cmdSaveCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveCategory.Click
    Call Schedule1.CategoryCollection.SaveXML(AppPath() & "category.xml")
  End Sub

  Private Sub cmdSaveProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveProvider.Click
    Call Schedule1.ProviderCollection.SaveXML(AppPath() & "provider.xml")
  End Sub

  Private Sub cmdSaveAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveAppointment.Click
    Call Schedule1.AppointmentCollection.SaveXML(AppPath() & "appointment.xml")
  End Sub

  Private Sub cmdLoadCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadCategory.Click
    Call Schedule1.ProviderCollection.Clear()
    Call Schedule1.CategoryCollection.LoadXML(AppPath() & "category.xml")
    Call Schedule1.Refresh()
  End Sub

  Private Sub cmdLoadProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadProvider.Click
    Call Schedule1.ProviderCollection.Clear()
    Call Schedule1.ProviderCollection.LoadXML(AppPath() & "provider.xml")
    Call Schedule1.Refresh()
  End Sub

  Private Sub cmdLoadAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadAppointment.Click
    Call Schedule1.AppointmentCollection.Clear()
    Call Schedule1.AppointmentCollection.LoadXML(AppPath() & "appointment.xml")
    Call Schedule1.Refresh()
  End Sub

  Private Function AppPath() As String
    Return Environment.CurrentDirectory & "\"
  End Function

  Private Sub cmdClearCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearCategory.Click
    Call Schedule1.CategoryCollection.Clear()
    Call Schedule1.Refresh()
  End Sub

  Private Sub cmdClearProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearProvider.Click
    Call Schedule1.ProviderCollection.Clear()
    Call Schedule1.Refresh()
  End Sub

  Private Sub cmdClearAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAppointment.Click
    Call Schedule1.AppointmentCollection.Clear()
    Call Schedule1.Refresh()
  End Sub

  Private Sub Schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs) Handles Schedule1.BeforePropertyDialog
    e.DialogSettings.WarningText = "This is a test!"
  End Sub

End Class
