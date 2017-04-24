Option Explicit On 
Option Strict On

Imports Gravitybox.Objects

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
  Friend WithEvents cmdTimeBar As System.Windows.Forms.Button
  Friend WithEvents cmdCategory As System.Windows.Forms.Button
  Friend WithEvents cmdProvider As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.cmdTimeBar = New System.Windows.Forms.Button
    Me.cmdCategory = New System.Windows.Forms.Button
    Me.cmdProvider = New System.Windows.Forms.Button
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
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
    Me.Schedule1.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide
    Me.Schedule1.DayLength = 12
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
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
    Me.Schedule1.Size = New System.Drawing.Size(456, 245)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'cmdTimeBar
    '
    Me.cmdTimeBar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdTimeBar.Location = New System.Drawing.Point(0, 216)
    Me.cmdTimeBar.Name = "cmdTimeBar"
    Me.cmdTimeBar.Size = New System.Drawing.Size(72, 24)
    Me.cmdTimeBar.TabIndex = 1
    Me.cmdTimeBar.Text = "TimeBar"
    '
    'cmdCategory
    '
    Me.cmdCategory.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdCategory.Location = New System.Drawing.Point(80, 216)
    Me.cmdCategory.Name = "cmdCategory"
    Me.cmdCategory.Size = New System.Drawing.Size(96, 24)
    Me.cmdCategory.TabIndex = 2
    Me.cmdCategory.Text = "Add Cateogry"
    '
    'cmdProvider
    '
    Me.cmdProvider.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
    Me.cmdProvider.Location = New System.Drawing.Point(184, 216)
    Me.cmdProvider.Name = "cmdProvider"
    Me.cmdProvider.Size = New System.Drawing.Size(96, 24)
    Me.cmdProvider.TabIndex = 3
    Me.cmdProvider.Text = "Add Provider"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(456, 245)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1, Me.cmdProvider, Me.cmdCategory, Me.cmdTimeBar})
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdTimeBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTimeBar.Click

    If Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category Then
      Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider
    ElseIf Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider Then
      Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None
    ElseIf Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.None Then
      Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn
    ElseIf Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn Then
      Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
    End If
    Call Schedule1.Refresh()

  End Sub

  Private Sub cmdCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategory.Click
    Call Schedule1.CategoryCollection.Add("", "Category" & Schedule1.CategoryCollection.Count.ToString)
    Call Schedule1.Refresh()
  End Sub

  Private Sub cmdProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProvider.Click
    Call Schedule1.ProviderCollection.Add("", "Provider" & Schedule1.ProviderCollection.Count.ToString)
    Call Schedule1.Refresh()
  End Sub

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Schedule1.CategoryCollection.Add("", "Category 1", Color.Blue)
    Call Schedule1.CategoryCollection.Add("", "Category 2", Color.Yellow)
    Call Schedule1.CategoryCollection.Add("", "Category 3", Color.Red)

    Call Schedule1.ProviderCollection.Add("", "Provider 1", Color.LightBlue)
    Call Schedule1.ProviderCollection.Add("", "Provider 2", Color.Orange)
    Call Schedule1.ProviderCollection.Add("", "Provider 3", Color.Green)

    Schedule1.AllowSelector = False
    Schedule1.TimeBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    Dim appointment As Appointment
    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.Subject = "Appointment 1"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(0))
    appointment.ProviderList.Add(Schedule1.ProviderCollection(0))

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:00:00 AM#, 90)
    appointment.Subject = "Appointment 2"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(1))
    appointment.ProviderList.Add(Schedule1.ProviderCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #10:00:00 AM#, 60)
    appointment.Subject = "Appointment 3"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(2))
    appointment.ProviderList.Add(Schedule1.ProviderCollection(2))

  End Sub

  Private Sub Schedule1_UserDrawnTimeBar(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs) Handles Schedule1.UserDrawnTimeBar
    e.graphics.FillRectangle(New SolidBrush(Color.Orange), e.rectangle)
  End Sub

End Class
