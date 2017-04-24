Option Strict On
Option Explicit On 

Public Class ViewmodeForm
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
  Friend WithEvents cmdChange As System.Windows.Forms.Button
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule()
    Me.lblDescription = New System.Windows.Forms.Label()
    Me.cmdChange = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
    Me.Schedule1.DayLength = 12
    Me.Schedule1.FirstDayOfWeek = System.DayOfWeek.Sunday
    Me.Schedule1.HeaderDateFormat = "ddd MMM, dd"
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(592, 312)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'lblDescription
    '
    Me.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.lblDescription.Location = New System.Drawing.Point(0, 328)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(480, 16)
    Me.lblDescription.TabIndex = 1
    Me.lblDescription.Text = "XXX"
    '
    'cmdChange
    '
    Me.cmdChange.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdChange.Location = New System.Drawing.Point(488, 320)
    Me.cmdChange.Name = "cmdChange"
    Me.cmdChange.Size = New System.Drawing.Size(96, 24)
    Me.cmdChange.TabIndex = 2
    Me.cmdChange.Text = "Change"
    '
    'ViewmodeForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(592, 349)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdChange, Me.lblDescription, Me.Schedule1})
    Me.Name = "ViewmodeForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "ViewmodeForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ViewmodeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Add Providers
    Call Schedule1.ProviderCollection.Add("", "Provider 1")
    Call Schedule1.ProviderCollection.Add("", "Provider 2")

    'Add Rooms
    Call Schedule1.RoomCollection.Add("", "Room 1")
    Call Schedule1.RoomCollection.Add("", "Room 2")

    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Provider
    Dim a As Gravitybox.Objects.Appointment
    a = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #10:00:00 AM#, 60)
    a.ProviderList.Add(Schedule1.ProviderCollection(0))
    a.Subject = "qweqwe"
    a = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #11:00:00 AM#, 60)
    a.ProviderList.Add(Schedule1.ProviderCollection(0))
    a.Subject = "asdasd"
    a = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 60)
    a.ProviderList.Add(Schedule1.ProviderCollection(0))
    a.Subject = "zxczxc"

    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
    Call ChangeViewmode()

  End Sub

  Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
    Call ChangeViewmode()
  End Sub

  Private Sub ChangeViewmode()

    Select Case Schedule1.ViewMode
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        lblDescription.Text = "DayTop/RoomLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        lblDescription.Text = "DayTop/ProviderLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        lblDescription.Text = "DayLeft/TimeTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        lblDescription.Text = "DayLeft/RoomTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        lblDescription.Text = "DayLeft/ProviderTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        lblDescription.Text = "DayRoomTop/TimeLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        lblDescription.Text = "DayRoomLeft/TimeTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        lblDescription.Text = "RoomTop/TimeLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
        lblDescription.Text = "RoomTop/ProviderLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        lblDescription.Text = "RoomLeft/TimeTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        lblDescription.Text = "RoomLeft/ProviderTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
        lblDescription.Text = "ProviderLeft/TimeTop"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        lblDescription.Text = "ProviderTop/TimeLeft"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month
        lblDescription.Text = "Month"
      Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
        Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
        lblDescription.Text = "DayTop/TimeLeft"
    End Select

  End Sub

End Class
