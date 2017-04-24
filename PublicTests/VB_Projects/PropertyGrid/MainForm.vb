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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
    Me.cmdAppointment = New System.Windows.Forms.Button
    Me.cmdCategory = New System.Windows.Forms.Button
    Me.cmdProvider = New System.Windows.Forms.Button
    Me.cmdRoom = New System.Windows.Forms.Button
    Me.cmdAlarm = New System.Windows.Forms.Button
    Me.cmdSchedule = New System.Windows.Forms.Button
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'PropertyGrid1
    '
    Me.PropertyGrid1.CommandsVisibleIfAvailable = True
    Me.PropertyGrid1.LargeButtons = False
    Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
    Me.PropertyGrid1.Location = New System.Drawing.Point(8, 64)
    Me.PropertyGrid1.Name = "PropertyGrid1"
    Me.PropertyGrid1.Size = New System.Drawing.Size(248, 536)
    Me.PropertyGrid1.TabIndex = 0
    Me.PropertyGrid1.Text = "PropertyGrid1"
    Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
    Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
    '
    'cmdAppointment
    '
    Me.cmdAppointment.Location = New System.Drawing.Point(392, 96)
    Me.cmdAppointment.Name = "cmdAppointment"
    Me.cmdAppointment.Size = New System.Drawing.Size(104, 24)
    Me.cmdAppointment.TabIndex = 5
    Me.cmdAppointment.Text = "Appointment"
    '
    'cmdCategory
    '
    Me.cmdCategory.Location = New System.Drawing.Point(392, 128)
    Me.cmdCategory.Name = "cmdCategory"
    Me.cmdCategory.Size = New System.Drawing.Size(104, 24)
    Me.cmdCategory.TabIndex = 6
    Me.cmdCategory.Text = "Category"
    '
    'cmdProvider
    '
    Me.cmdProvider.Location = New System.Drawing.Point(392, 160)
    Me.cmdProvider.Name = "cmdProvider"
    Me.cmdProvider.Size = New System.Drawing.Size(104, 24)
    Me.cmdProvider.TabIndex = 7
    Me.cmdProvider.Text = "Provider"
    '
    'cmdRoom
    '
    Me.cmdRoom.Location = New System.Drawing.Point(392, 192)
    Me.cmdRoom.Name = "cmdRoom"
    Me.cmdRoom.Size = New System.Drawing.Size(104, 24)
    Me.cmdRoom.TabIndex = 8
    Me.cmdRoom.Text = "Room"
    '
    'cmdAlarm
    '
    Me.cmdAlarm.Location = New System.Drawing.Point(392, 224)
    Me.cmdAlarm.Name = "cmdAlarm"
    Me.cmdAlarm.Size = New System.Drawing.Size(104, 24)
    Me.cmdAlarm.TabIndex = 9
    Me.cmdAlarm.Text = "Alarm"
    '
    'cmdSchedule
    '
    Me.cmdSchedule.Location = New System.Drawing.Point(272, 96)
    Me.cmdSchedule.Name = "cmdSchedule"
    Me.cmdSchedule.Size = New System.Drawing.Size(104, 24)
    Me.cmdSchedule.TabIndex = 1
    Me.cmdSchedule.Text = "Schedule"
    '
    'cmdPropertyItem
    '
    Me.cmdPropertyItem.Location = New System.Drawing.Point(392, 256)
    Me.cmdPropertyItem.Name = "cmdPropertyItem"
    Me.cmdPropertyItem.Size = New System.Drawing.Size(104, 24)
    Me.cmdPropertyItem.TabIndex = 11
    Me.cmdPropertyItem.Text = "PropertyItem"
    '
    'cmdDialogAppointment
    '
    Me.cmdDialogAppointment.Location = New System.Drawing.Point(304, 408)
    Me.cmdDialogAppointment.Name = "cmdDialogAppointment"
    Me.cmdDialogAppointment.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogAppointment.TabIndex = 13
    Me.cmdDialogAppointment.Text = "Appointment  Dialog"
    '
    'cmdDialogCategory
    '
    Me.cmdDialogCategory.Location = New System.Drawing.Point(304, 440)
    Me.cmdDialogCategory.Name = "cmdDialogCategory"
    Me.cmdDialogCategory.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogCategory.TabIndex = 14
    Me.cmdDialogCategory.Text = "Category Dialog"
    '
    'cmdDialogPrint
    '
    Me.cmdDialogPrint.Location = New System.Drawing.Point(304, 504)
    Me.cmdDialogPrint.Name = "cmdDialogPrint"
    Me.cmdDialogPrint.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogPrint.TabIndex = 16
    Me.cmdDialogPrint.Text = "Print Dialog"
    '
    'cmdDialogCategoryMaster
    '
    Me.cmdDialogCategoryMaster.Location = New System.Drawing.Point(304, 472)
    Me.cmdDialogCategoryMaster.Name = "cmdDialogCategoryMaster"
    Me.cmdDialogCategoryMaster.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogCategoryMaster.TabIndex = 15
    Me.cmdDialogCategoryMaster.Text = "Category Master Dialog"
    '
    'cmdDialogProvider
    '
    Me.cmdDialogProvider.Location = New System.Drawing.Point(304, 536)
    Me.cmdDialogProvider.Name = "cmdDialogProvider"
    Me.cmdDialogProvider.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogProvider.TabIndex = 17
    Me.cmdDialogProvider.Text = "Provider Dialog"
    '
    'cmdDialogConfiguration
    '
    Me.cmdDialogConfiguration.Location = New System.Drawing.Point(304, 568)
    Me.cmdDialogConfiguration.Name = "cmdDialogConfiguration"
    Me.cmdDialogConfiguration.Size = New System.Drawing.Size(160, 24)
    Me.cmdDialogConfiguration.TabIndex = 18
    Me.cmdDialogConfiguration.Text = "Configuration Dialog"
    '
    'cmdScheduleBar
    '
    Me.cmdScheduleBar.Location = New System.Drawing.Point(392, 288)
    Me.cmdScheduleBar.Name = "cmdScheduleBar"
    Me.cmdScheduleBar.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleBar.TabIndex = 12
    Me.cmdScheduleBar.Text = "Schedule Bar"
    '
    'cmdHeader
    '
    Me.cmdHeader.Location = New System.Drawing.Point(272, 128)
    Me.cmdHeader.Name = "cmdHeader"
    Me.cmdHeader.Size = New System.Drawing.Size(104, 24)
    Me.cmdHeader.TabIndex = 2
    Me.cmdHeader.Text = "Header"
    '
    'cmdScheduleProperties
    '
    Me.cmdScheduleProperties.Location = New System.Drawing.Point(272, 160)
    Me.cmdScheduleProperties.Name = "cmdScheduleProperties"
    Me.cmdScheduleProperties.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleProperties.TabIndex = 3
    Me.cmdScheduleProperties.Text = "Sch Properties"
    '
    'cmdScheduleRecurrence
    '
    Me.cmdScheduleRecurrence.Location = New System.Drawing.Point(272, 192)
    Me.cmdScheduleRecurrence.Name = "cmdScheduleRecurrence"
    Me.cmdScheduleRecurrence.Size = New System.Drawing.Size(104, 24)
    Me.cmdScheduleRecurrence.TabIndex = 4
    Me.cmdScheduleRecurrence.Text = "Sch Recur"
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(272, 64)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(104, 16)
    Me.Label1.TabIndex = 20
    Me.Label1.Text = "Components"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.Location = New System.Drawing.Point(392, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(104, 16)
    Me.Label2.TabIndex = 21
    Me.Label2.Text = "Objects"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.Location = New System.Drawing.Point(304, 376)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 16)
    Me.Label3.TabIndex = 22
    Me.Label3.Text = "Dialogs"
    Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 8)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(488, 48)
    Me.Label4.TabIndex = 23
    Me.Label4.Text = "This example loads different objects into the object browser. It displays how eac" & _
    "h object looks in a PropertyGrid. If you like the format of the objects then you" & _
    " may use this paradigm in your own applications to display object properties."
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(504, 613)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
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
    Me.Controls.Add(Me.cmdSchedule)
    Me.Controls.Add(Me.cmdAlarm)
    Me.Controls.Add(Me.cmdRoom)
    Me.Controls.Add(Me.cmdProvider)
    Me.Controls.Add(Me.cmdCategory)
    Me.Controls.Add(Me.cmdAppointment)
    Me.Controls.Add(Me.PropertyGrid1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET PropertyGrid Example"
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

  Private Sub cmdAppointmentCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

End Class
