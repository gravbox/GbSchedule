Option Strict On
Option Explicit On 

Public Class XMLForm
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
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents cmdLoad As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents cmdAddMore As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblDescription = New System.Windows.Forms.Label()
    Me.cmdLoad = New System.Windows.Forms.Button()
    Me.Schedule1 = New Gravitybox.Controls.Schedule()
    Me.cmdSave = New System.Windows.Forms.Button()
    Me.cmdAddMore = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'lblDescription
    '
    Me.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.lblDescription.Location = New System.Drawing.Point(4, 411)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(388, 24)
    Me.lblDescription.TabIndex = 7
    Me.lblDescription.Text = "XXX"
    '
    'cmdLoad
    '
    Me.cmdLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdLoad.Location = New System.Drawing.Point(568, 408)
    Me.cmdLoad.Name = "cmdLoad"
    Me.cmdLoad.Size = New System.Drawing.Size(80, 24)
    Me.cmdLoad.TabIndex = 2
    Me.cmdLoad.Text = "Load XML"
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowGrid = True
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
    Me.Schedule1.Location = New System.Drawing.Point(-4, 1)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(664, 394)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 3
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'cmdSave
    '
    Me.cmdSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdSave.Location = New System.Drawing.Point(480, 408)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(80, 24)
    Me.cmdSave.TabIndex = 1
    Me.cmdSave.Text = "Save XML"
    '
    'cmdAddMore
    '
    Me.cmdAddMore.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdAddMore.Location = New System.Drawing.Point(392, 408)
    Me.cmdAddMore.Name = "cmdAddMore"
    Me.cmdAddMore.Size = New System.Drawing.Size(80, 24)
    Me.cmdAddMore.TabIndex = 0
    Me.cmdAddMore.Text = "Add More"
    '
    'XMLForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(656, 437)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdAddMore, Me.cmdSave, Me.lblDescription, Me.cmdLoad, Me.Schedule1})
    Me.Name = "XMLForm"
    Me.Text = "XML Test"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Const FILENAME As String = "C:\appointments.xml"
  Private Const DAYCOUNT As Integer = 5
  Private Const MINDATE As Date = #1/1/2004#

  Private Sub XMLForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the screen
    Call Schedule1.SetMinMaxDate(MINDATE, DateAdd(DateInterval.Day, DAYCOUNT - 1, MINDATE))
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Schedule1.AppointmentBar.Size = 10
    lblDescription.Text = "Press the buttons to save and load the appointments to/from an XML file."

    Dim X As New Gravitybox.Objects.Recurrence()
    Dim S As String = X.ToXML
    Call X.FromXML(S)
    Call Debug.WriteLine(S)

    Call RandomAppointments()

  End Sub

  Private Sub RandomAppointments()

    Call Randomize()
    Dim ii As Integer
    For ii = 1 To 10
      Dim newDate As Date = DateAdd(DateInterval.Day, RandomInt(DAYCOUNT), Schedule1.MinDate)
      Dim newTime As Date = DateAdd(DateInterval.Minute, RandomInt(480), Schedule1.StartTime)
      Dim length As Integer = 1 + RandomInt(119)
      Call Schedule1.AppointmentCollection.Add("", newDate, newTime, length)
    Next
    Call Schedule1.Refresh()

  End Sub

  Private Function RandomInt(ByVal max As Integer) As Integer
    Return CInt(max * Rnd())
  End Function

  Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click

    Dim myFile As IO.File
    If myFile.Exists(FILENAME) Then
      Call Schedule1.AppointmentCollection.Clear()
      Call Schedule1.AppointmentCollection.LoadXML(FILENAME)
      Call Schedule1.Refresh()
    Else
      Call MsgBox("There is no appointment file!", MsgBoxStyle.Information)
    End If

  End Sub

  Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    Dim myFile As IO.File
    If myFile.Exists(FILENAME) Then Call myFile.Delete(FILENAME)
    Call Schedule1.AppointmentCollection.SaveXML(FILENAME)

  End Sub

  Private Sub cmdAddMore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMore.Click
    Call RandomAppointments()
  End Sub

End Class
