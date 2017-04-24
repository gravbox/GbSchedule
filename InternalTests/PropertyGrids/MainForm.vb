Option Explicit On 
Option Strict On

Imports Gravitybox.Objects

Public Class MainForm
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
  Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
  Friend WithEvents cmdAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdCategory As System.Windows.Forms.Button
  Friend WithEvents cmdProvider As System.Windows.Forms.Button
  Friend WithEvents cmdRoom As System.Windows.Forms.Button
  Friend WithEvents cmdAlarm As System.Windows.Forms.Button
  Friend WithEvents cmdSchedule As System.Windows.Forms.Button
  Friend WithEvents cmdEConnect As System.Windows.Forms.Button
  Friend WithEvents cmdAppointmentCollection As System.Windows.Forms.Button
  Friend WithEvents cmdPropertyItem As System.Windows.Forms.Button
  Friend WithEvents cmdDialogAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdDialogCategory As System.Windows.Forms.Button
  Friend WithEvents cmdDialogPrint As System.Windows.Forms.Button
  Friend WithEvents cmdDialogCategoryMaster As System.Windows.Forms.Button
  Friend WithEvents cmdDialogProvider As System.Windows.Forms.Button
  Friend WithEvents cmdDialogConfiguration As System.Windows.Forms.Button
  Friend WithEvents cmdScheduleBar As System.Windows.Forms.Button
  Friend WithEvents cmdHeader As System.Windows.Forms.Button
  Friend WithEvents cmdScheduleProperties As System.Windows.Forms.Button
  Friend WithEvents cmdScheduleRecurrence As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdConfigAlarm As System.Windows.Forms.Button
  Friend WithEvents cmdConfigAppointment As System.Windows.Forms.Button
  Friend WithEvents cmdConfigCategory As System.Windows.Forms.Button
  Friend WithEvents cmdConfigCategoryMaster As System.Windows.Forms.Button
  Friend WithEvents cmdConfigDialog As System.Windows.Forms.Button
  Friend WithEvents cmdConfigPrint As System.Windows.Forms.Button
  Friend WithEvents cmdConfigProvider As System.Windows.Forms.Button
  Friend WithEvents cmdConfigRecurrence As System.Windows.Forms.Button
  Friend WithEvents cmdConfigTime As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
    Me.cmdAppointment = New System.Windows.Forms.Button
    Me.cmdCategory = New System.Windows.Forms.Button
    Me.cmdProvider = New System.Windows.Forms.Button
    Me.cmdRoom = New System.Windows.Forms.Button
    Me.cmdAlarm = New System.Windows.Forms.Button
    Me.cmdSchedule = New System.Windows.Forms.Button
    Me.cmdEConnect = New System.Windows.Forms.Button
    Me.cmdAppointmentCollection = New System.Windows.Forms.Button
    Me.cmdPropertyItem = New System.Windows.Forms.Button
    Me.cmdDialogAppointment = New System.Windows.Forms.Button
    Me.cmdDialogCategory = New System.Windows.Forms.Button
    Me.cmdDialogPrint = New System.Windows.Forms.Button
    Me.cmdDialogCategoryMaster = New System.Windows.Forms.Button
    Me.cmdDialogProvider = New System.Windows.Forms.Button
    Me.cmdDialogConfiguration = New System.Windows.Forms.Button
    Me.cmdScheduleBar = New System.Windows.Forms.Button
    Me.cmdHeader = New System.Windows.Forms.Button
    Me.cmdScheduleProperties = New System.Windows.Forms.Button
    Me.cmdScheduleRecurrence = New System.Windows.Forms.Button
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.cmdConfigTime = New System.Windows.Forms.Button
    Me.cmdConfigRecurrence = New System.Windows.Forms.Button
    Me.cmdConfigProvider = New System.Windows.Forms.Button
    Me.cmdConfigPrint = New System.Windows.Forms.Button
    Me.cmdConfigDialog = New System.Windows.Forms.Button
    Me.cmdConfigCategoryMaster = New System.Windows.Forms.Button
    Me.cmdConfigCategory = New System.Windows.Forms.Button
    Me.cmdConfigAppointment = New System.Windows.Forms.Button
    Me.cmdConfigAlarm = New System.Windows.Forms.Button
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'PropertyGrid1
    '
    Me.PropertyGrid1.CommandsVisibleIfAvailable = True
    Me.PropertyGrid1.LargeButtons = False
    Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
    Me.PropertyGrid1.Location = New System.Drawing.Point(8, 8)
    Me.PropertyGrid1.Name = "PropertyGrid1"
    Me.PropertyGrid1.Size = New System.Drawing.Size(248, 592)
    Me.PropertyGrid1.TabIndex = 0
    Me.PropertyGrid1.Text = "PropertyGrid1"
    Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
    Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
    '
    'cmdAppointment
    '
    Me.cmdAppointment.Location = New System.Drawing.Point(288, 8)
    Me.cmdAppointment.Name = "cmdAppointment"
    Me.cmdAppointment.Size = New System.Drawing.Size(104, 24)
    Me.cmdAppointment.TabIndex = 1
    Me.cmdAppointment.Text = "A"
    '
    'cmdCategory
    '
    Me.cmdCategory.Location = New System.Drawing.Point(288, 40)
    Me.cmdCategory.Name = "cmdCategory"
    Me.cmdCategory.Size = New System.Drawing.Size(104, 24)
    Me.cmdCategory.TabIndex = 2
    Me.cmdCategory.Text = "C"
    '
    'cmdProvider
    '
    Me.cmdProvider.Location = New System.Drawing.Point(288, 72)
    Me.cmdProvider.Name = "cmdProvider"
    Me.cmdProvider.Size = New System.Drawing.Size(104, 24)
    Me.cmdProvider.TabIndex = 3
    Me.cmdProvider.Text = "P"
    '
    'cmdRoom
    '
    Me.cmdRoom.Location = New System.Drawing.Point(288, 104)
    Me.cmdRoom.Name = "cmdRoom"
    Me.cmdRoom.Size = New System.Drawing.Size(104, 24)
    Me.cmdRoom.TabIndex = 4
    Me.cmdRoom.Text = "R"
    '
    'cmdAlarm
    '
    Me.cmdAlarm.Location = New System.Drawing.Point(288, 136)
    Me.cmdAlarm.Name = "cmdAlarm"
    Me.cmdAlarm.Size = New System.Drawing.Size(104, 24)
    Me.cmdAlarm.TabIndex = 5
    Me.cmdAlarm.Text = "Alarm"
    '
    'cmdSchedule
    '
    Me.cmdSchedule.Location = New System.Drawing.Point(424, 8)
    Me.cmdSchedule.Name = "cmdSchedule"
    Me.cmdSchedule.Size = New System.Drawing.Size(104, 24)
    Me.cmdSchedule.TabIndex = 6
    Me.cmdSchedule.Text = "Schedule"
    '
    'cmdEConnect
    '
    Me.cmdEConnect.Location = New System.Drawing.Point(288, 168)
    Me.cmdEConnect.Name = "cmdEConnect"
    Me.cmdEConnect.Size = New System.Drawing.Size(104, 24)
    Me.cmdEConnect.TabIndex = 7
    Me.cmdEConnect.Text = "EConnect"
    '
    'cmdAppointmentCollection
    '
    Me.cmdAppointmentCollection.Location = New System.Drawing.Point(288, 200)
    Me.cmdAppointmentCollection.Name = "cmdAppointmentCollection"
    Me.cmdAppointmentCollection.Size = New System.Drawing.Size(104, 24)
    Me.cmdAppointmentCollection.TabIndex = 8
    Me.cmdAppointmentCollection.Text = "App Col"
    '
    'cmdPropertyItem
    '
    Me.cmdPropertyItem.Location = New System.Drawing.Point(288, 232)
    Me.cmdPropertyItem.Name = "cmdPropertyItem"
    Me.cmdPropertyItem.Size = New System.Drawing.Size(104, 24)
    Me.cmdPropertyItem.TabIndex = 9
    Me.cmdPropertyItem.Text = "PropertyItem"
    '
    'cmdDialogAppointment
    '
    Me.cmdDialogAppointment.Location = New System.Drawing.Point(288, 272)
    Me.cmdDialogAppointment.Name = "cmdDialogAppointment"
    Me.cmdDialogAppointment.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogAppointment.TabIndex = 10
    Me.cmdDialogAppointment.Text = "App Dialog"
    '
    'cmdDialogCategory
    '
    Me.cmdDialogCategory.Location = New System.Drawing.Point(288, 304)
    Me.cmdDialogCategory.Name = "cmdDialogCategory"
    Me.cmdDialogCategory.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogCategory.TabIndex = 11
    Me.cmdDialogCategory.Text = "Cat Dialog"
    '
    'cmdDialogPrint
    '
    Me.cmdDialogPrint.Location = New System.Drawing.Point(288, 368)
    Me.cmdDialogPrint.Name = "cmdDialogPrint"
    Me.cmdDialogPrint.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogPrint.TabIndex = 13
    Me.cmdDialogPrint.Text = "Print Dialog"
    '
    'cmdDialogCategoryMaster
    '
    Me.cmdDialogCategoryMaster.Location = New System.Drawing.Point(288, 336)
    Me.cmdDialogCategoryMaster.Name = "cmdDialogCategoryMaster"
    Me.cmdDialogCategoryMaster.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogCategoryMaster.TabIndex = 12
    Me.cmdDialogCategoryMaster.Text = "Cat Master Dialog"
    '
    'cmdDialogProvider
    '
    Me.cmdDialogProvider.Location = New System.Drawing.Point(288, 400)
    Me.cmdDialogProvider.Name = "cmdDialogProvider"
    Me.cmdDialogProvider.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogProvider.TabIndex = 14
    Me.cmdDialogProvider.Text = "Provider Dialog"
    '
    'cmdDialogConfiguration
    '
    Me.cmdDialogConfiguration.Location = New System.Drawing.Point(288, 432)
    Me.cmdDialogConfiguration.Name = "cmdDialogConfiguration"
    Me.cmdDialogConfiguration.Size = New System.Drawing.Size(104, 24)
    Me.cmdDialogConfiguration.TabIndex = 15
    Me.cmdDialogConfiguration.Text = "Config Dialog"
    '
    'cmdScheduleBar
    '
    Me.cmdScheduleBar.Location = New System.Drawing.Point(288, 464)
    Me.cmdScheduleBar.Name = "cmdScheduleBar"
    Me.cmdScheduleBar.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleBar.TabIndex = 16
    Me.cmdScheduleBar.Text = "Sch Bar"
    '
    'cmdHeader
    '
    Me.cmdHeader.Location = New System.Drawing.Point(424, 40)
    Me.cmdHeader.Name = "cmdHeader"
    Me.cmdHeader.Size = New System.Drawing.Size(104, 24)
    Me.cmdHeader.TabIndex = 17
    Me.cmdHeader.Text = "Header"
    '
    'cmdScheduleProperties
    '
    Me.cmdScheduleProperties.Location = New System.Drawing.Point(424, 72)
    Me.cmdScheduleProperties.Name = "cmdScheduleProperties"
    Me.cmdScheduleProperties.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleProperties.TabIndex = 18
    Me.cmdScheduleProperties.Text = "Sch Properties"
    '
    'cmdScheduleRecurrence
    '
    Me.cmdScheduleRecurrence.Location = New System.Drawing.Point(424, 104)
    Me.cmdScheduleRecurrence.Name = "cmdScheduleRecurrence"
    Me.cmdScheduleRecurrence.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleRecurrence.TabIndex = 19
    Me.cmdScheduleRecurrence.Text = "Sch Recur"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmdConfigTime)
    Me.GroupBox1.Controls.Add(Me.cmdConfigRecurrence)
    Me.GroupBox1.Controls.Add(Me.cmdConfigProvider)
    Me.GroupBox1.Controls.Add(Me.cmdConfigPrint)
    Me.GroupBox1.Controls.Add(Me.cmdConfigDialog)
    Me.GroupBox1.Controls.Add(Me.cmdConfigCategoryMaster)
    Me.GroupBox1.Controls.Add(Me.cmdConfigCategory)
    Me.GroupBox1.Controls.Add(Me.cmdConfigAppointment)
    Me.GroupBox1.Controls.Add(Me.cmdConfigAlarm)
    Me.GroupBox1.Location = New System.Drawing.Point(408, 136)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(152, 272)
    Me.GroupBox1.TabIndex = 20
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Dialogs Config Objects"
    '
    'cmdConfigTime
    '
    Me.cmdConfigTime.Location = New System.Drawing.Point(16, 216)
    Me.cmdConfigTime.Name = "cmdConfigTime"
    Me.cmdConfigTime.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigTime.TabIndex = 8
    Me.cmdConfigTime.Text = "Time"
    '
    'cmdConfigRecurrence
    '
    Me.cmdConfigRecurrence.Location = New System.Drawing.Point(16, 192)
    Me.cmdConfigRecurrence.Name = "cmdConfigRecurrence"
    Me.cmdConfigRecurrence.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigRecurrence.TabIndex = 7
    Me.cmdConfigRecurrence.Text = "Recurrence"
    '
    'cmdConfigProvider
    '
    Me.cmdConfigProvider.Location = New System.Drawing.Point(16, 168)
    Me.cmdConfigProvider.Name = "cmdConfigProvider"
    Me.cmdConfigProvider.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigProvider.TabIndex = 6
    Me.cmdConfigProvider.Text = "Provider"
    '
    'cmdConfigPrint
    '
    Me.cmdConfigPrint.Location = New System.Drawing.Point(16, 144)
    Me.cmdConfigPrint.Name = "cmdConfigPrint"
    Me.cmdConfigPrint.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigPrint.TabIndex = 5
    Me.cmdConfigPrint.Text = "Print"
    '
    'cmdConfigDialog
    '
    Me.cmdConfigDialog.Location = New System.Drawing.Point(16, 120)
    Me.cmdConfigDialog.Name = "cmdConfigDialog"
    Me.cmdConfigDialog.Size = New System.Drawing.Size(128, 24)
    Me.cmdConfigDialog.TabIndex = 4
    Me.cmdConfigDialog.Text = "Configuration Dialog"
    '
    'cmdConfigCategoryMaster
    '
    Me.cmdConfigCategoryMaster.Location = New System.Drawing.Point(16, 96)
    Me.cmdConfigCategoryMaster.Name = "cmdConfigCategoryMaster"
    Me.cmdConfigCategoryMaster.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigCategoryMaster.TabIndex = 3
    Me.cmdConfigCategoryMaster.Text = "Category Master"
    '
    'cmdConfigCategory
    '
    Me.cmdConfigCategory.Location = New System.Drawing.Point(16, 72)
    Me.cmdConfigCategory.Name = "cmdConfigCategory"
    Me.cmdConfigCategory.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigCategory.TabIndex = 2
    Me.cmdConfigCategory.Text = "Category"
    '
    'cmdConfigAppointment
    '
    Me.cmdConfigAppointment.Location = New System.Drawing.Point(16, 48)
    Me.cmdConfigAppointment.Name = "cmdConfigAppointment"
    Me.cmdConfigAppointment.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigAppointment.TabIndex = 1
    Me.cmdConfigAppointment.Text = "Appointment"
    '
    'cmdConfigAlarm
    '
    Me.cmdConfigAlarm.Location = New System.Drawing.Point(16, 24)
    Me.cmdConfigAlarm.Name = "cmdConfigAlarm"
    Me.cmdConfigAlarm.Size = New System.Drawing.Size(112, 24)
    Me.cmdConfigAlarm.TabIndex = 0
    Me.cmdConfigAlarm.Text = "Alarm"
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(584, 613)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.cmdScheduleRecurrence)
    Me.Controls.Add(Me.cmdScheduleProperties)
    Me.Controls.Add(Me.cmdHeader)
    Me.Controls.Add(Me.cmdScheduleBar)
    Me.Controls.Add(Me.cmdDialogConfiguration)
    Me.Controls.Add(Me.cmdDialogProvider)
    Me.Controls.Add(Me.cmdDialogPrint)
    Me.Controls.Add(Me.cmdDialogCategoryMaster)
    Me.Controls.Add(Me.cmdDialogCategory)
    Me.Controls.Add(Me.cmdDialogAppointment)
    Me.Controls.Add(Me.cmdPropertyItem)
    Me.Controls.Add(Me.cmdAppointmentCollection)
    Me.Controls.Add(Me.cmdEConnect)
    Me.Controls.Add(Me.cmdSchedule)
    Me.Controls.Add(Me.cmdAlarm)
    Me.Controls.Add(Me.cmdRoom)
    Me.Controls.Add(Me.cmdProvider)
    Me.Controls.Add(Me.cmdCategory)
    Me.Controls.Add(Me.cmdAppointment)
    Me.Controls.Add(Me.PropertyGrid1)
    Me.Name = "MainForm"
    Me.Text = "MainForm"
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private schedule1 As New Gravitybox.Controls.Schedule

  Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    schedule1.CategoryCollection.Add("", "Category 1", Color.Yellow)
    schedule1.ProviderCollection.Add("", "Provider 1", Color.Orange)
    schedule1.RoomCollection.Add("", "Room 1")
    Dim appointment As Appointment = schedule1.AppointmentCollection.Add("", #1/1/2004#, schedule1.RoomCollection(0), #8:00:00 AM#, 60)
    appointment.PropertyItemCollection.Add("", "MyKey", "MySetting")

  End Sub

  Private Sub cmdAppointment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAppointment.Click
    PropertyGrid1.SelectedObject = schedule1.AppointmentCollection(0)
  End Sub

  Private Sub cmdCategory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCategory.Click
    PropertyGrid1.SelectedObject = schedule1.CategoryCollection(0)
  End Sub

  Private Sub cmdRoom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdRoom.Click
    PropertyGrid1.SelectedObject = schedule1.RoomCollection(0)
  End Sub

  Private Sub cmdProvider_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdProvider.Click
    PropertyGrid1.SelectedObject = schedule1.ProviderCollection(0)
  End Sub

  Private Sub cmdAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAlarm.Click
    PropertyGrid1.SelectedObject = schedule1.AppointmentCollection(0).Alarm
  End Sub

  Private Sub cmdSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSchedule.Click
    PropertyGrid1.SelectedObject = schedule1
  End Sub

  Private Sub cmdEConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEConnect.Click
    'PropertyGrid1.SelectedObject = schedule1.EnterpriseConnection
  End Sub

  Private Sub cmdAppointmentCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAppointmentCollection.Click
    PropertyGrid1.SelectedObject = schedule1.AppointmentCollection
  End Sub

  Private Sub cmdPropertyItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPropertyItem.Click
    PropertyGrid1.SelectedObject = schedule1.AppointmentCollection(0).PropertyItemCollection(0)
  End Sub

  Private Sub cmdDialogAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogAppointment.Click
    PropertyGrid1.SelectedObject = New AppointmentDialogSettings
  End Sub

  Private Sub cmdDialogCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogCategory.Click
    PropertyGrid1.SelectedObject = New CategoryDialogSettings
  End Sub

  Private Sub cmdDialogCategoryMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogCategoryMaster.Click
    PropertyGrid1.SelectedObject = (New CategoryDialogSettings).CategoryMasterDialog
  End Sub

  Private Sub cmdDialogPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogPrint.Click
    PropertyGrid1.SelectedObject = New Gravitybox.Objects.PrintDialogSettings(#1/1/2004#, #8:00:00 AM#, #1/1/2004#, #12:00:00 PM#)
  End Sub

  Private Sub cmdDialogProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogProvider.Click
    PropertyGrid1.SelectedObject = New ProviderDialogSettings
  End Sub

  Private Sub cmdDialogConfiguration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDialogConfiguration.Click
    PropertyGrid1.SelectedObject = New ConfigurationDialogSettings
  End Sub

  Private Sub cmdScheduleBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScheduleBar.Click
    PropertyGrid1.SelectedObject = schedule1.AppointmentBar
  End Sub

  Private Sub cmdHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHeader.Click
    PropertyGrid1.SelectedObject = New Gravitybox.Controls.Header
  End Sub

  Private Sub cmdScheduleProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScheduleProperties.Click
    PropertyGrid1.SelectedObject = New Gravitybox.Controls.AppointmentProperties
  End Sub

  Private Sub cmdScheduleRecurrence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScheduleRecurrence.Click
    PropertyGrid1.SelectedObject = New Gravitybox.Controls.AppointmentRecurrence
  End Sub

  Private Sub cmdConfigAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigAlarm.Click
    Dim d As New Gravitybox.Objects.AlarmDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigAppointment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigAppointment.Click
    Dim d As New Gravitybox.Objects.AppointmentDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigCategory.Click
    Dim d As New Gravitybox.Objects.CategoryDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigCategoryMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigCategoryMaster.Click
    'Dim d As New Gravitybox.Objects.CategoryMasterDialogSetting
    'PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigDialog.Click
    Dim d As New Gravitybox.Objects.ConfigurationDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigPrint.Click
    Dim d As New Gravitybox.Objects.PrintDialogSettings(Now, #8:00:00 AM#, Now, #6:00:00 PM#)
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigProvider.Click
    Dim d As New Gravitybox.Objects.ProviderDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigRecurrence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigRecurrence.Click
    Dim d As New Gravitybox.Objects.RecurrenceDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

  Private Sub cmdConfigTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConfigTime.Click
    Dim d As New Gravitybox.Objects.TimeDialogSettings
    PropertyGrid1.SelectedObject = d
  End Sub

End Class
