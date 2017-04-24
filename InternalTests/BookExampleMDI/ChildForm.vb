Option Strict On
Option Explicit On 

Public Class ChildForm
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowCopy = True
    Me.Schedule1.AllowDragTip = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowEvents = True
    Me.Schedule1.AllowGrid = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowForeignDrops = True
    Me.Schedule1.AllowRemove = True
    Me.Schedule1.AllowSelector = True
    Me.Schedule1.AppointmentSpace = 8
    Me.Schedule1.AutoRedraw = True
    Me.Schedule1.BlockoutColor = System.Drawing.Color.Black
    Me.Schedule1.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12
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
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(560, 349)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'ChildForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(560, 349)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1})
    Me.Name = "ChildForm"
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_ScheduleDate As Date
  Private m_Changed As Boolean

  Public Property ScheduleDate() As Date
    Get
      Return m_ScheduleDate
    End Get
    Set(ByVal Value As Date)
      m_ScheduleDate = Value
      Me.Text = ScheduleDate.ToLongDateString
      Call Schedule1.SetMinMaxDate(ScheduleDate, ScheduleDate)
      Call LoadFile()
    End Set
  End Property

  Public Property Changed() As Boolean
    Get
      Return m_Changed
    End Get
    Set(ByVal Value As Boolean)
      m_Changed = Value
    End Set
  End Property

  Public Sub LoadRooms()
    Call Schedule1.RoomCollection.Clear()
    Call Schedule1.RoomCollection.Add("D6C68D58-BD2F-40A5-87CA-EA974483A2C4", "Operatory I")
    Call Schedule1.RoomCollection.Add("951B041B-DA8D-4409-B693-8749E8F957BD", "Operatory II")
    Call Schedule1.RoomCollection.Add("66D10474-3F26-4D2D-9E42-96E2F0AA4135", "Exam I")
    Call Schedule1.RoomCollection.Add("792D5919-A695-4331-89F3-57DFFDC9D9EA", "Exam II")
  End Sub

  Private Sub ChildForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Set to proper viewmode
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft

  End Sub

  Public Function LoadFile() As Boolean
    Call Schedule1.AppointmentCollection.LoadXML(Me.FileName)
    Changed = False
  End Function

  Public Function SaveFile() As Boolean
    If Me.Changed Then
      Call Schedule1.AppointmentCollection.SaveXML(Me.FileName)
      Changed = False
    End If
  End Function

  Public Function FileName() As String
    FileName = AppPath() & ScheduleDate.Year.ToString & Format(ScheduleDate.Month, "00") & Format(ScheduleDate.Day, "00") & ".sched"
  End Function

#Region "Changed"

  Private Sub Schedule1_AfterAppointmentAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentAdd
    Changed = True
  End Sub

  Private Sub Schedule1_AfterAppointmentCopy(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentCopy
    Changed = True
  End Sub

  Private Sub Schedule1_AfterAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentMove
    Changed = True
  End Sub

  Private Sub Schedule1_AfterAppointmentRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentRemove
    Changed = True
  End Sub

  Private Sub Schedule1_AfterAppointmentResize(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterAppointmentResize
    Changed = True
  End Sub

  Private Sub Schedule1_AfterInPlaceEdit(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterAppointmentEventArgs) Handles Schedule1.AfterInPlaceEdit
    Changed = True
  End Sub

#End Region

  Private Function AppPath() As String
    Return Environment.CurrentDirectory() & "\"
  End Function

  Private Sub ChildForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    Dim F As MDIForm = CType(Me.ParentForm, MDIForm)
    Call F.CloseDate(Me.ScheduleDate)
    Call F.RefreshMenus()
  End Sub

  Private Sub ChildForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Call SaveFile()
  End Sub

  Private Sub ChildForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    Dim F As MDIForm
    F = CType(Me.ParentForm, MDIForm)
    F.RefreshMenus()
  End Sub

  Private Sub ChildForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
    Dim F As MDIForm
    F = CType(Me.ParentForm, MDIForm)
    F.RefreshMenus()
  End Sub

End Class
