Option Strict On
Option Explicit On 

Public Class UserDrawnForm
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
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule()
    Me.lblDescription = New System.Windows.Forms.Label()
    Me.cmdAdd = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowAdd = True
    Me.Schedule1.AllowCopy = True
    Me.Schedule1.AllowDragTip = True
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.AllowGrid = True
    Me.Schedule1.AllowInPlaceEdit = True
    Me.Schedule1.AppointmentResizing = Gravitybox.Controls.Schedule.AppointmentResizingConstants.All
    Me.Schedule1.AllowMove = True
    Me.Schedule1.AllowForeignDrops = True
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
    Me.Schedule1.Location = New System.Drawing.Point(0, 6)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(664, 394)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 1
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'lblDescription
    '
    Me.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.lblDescription.Location = New System.Drawing.Point(8, 416)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(512, 24)
    Me.lblDescription.TabIndex = 4
    Me.lblDescription.Text = "XXX"
    '
    'cmdAdd
    '
    Me.cmdAdd.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdAdd.Location = New System.Drawing.Point(528, 416)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(128, 24)
    Me.cmdAdd.TabIndex = 3
    Me.cmdAdd.Text = "Add Appointment"
    '
    'UserDrawnForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(664, 445)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Schedule1, Me.lblDescription, Me.cmdAdd})
    Me.Name = "UserDrawnForm"
    Me.Text = "User Drawn Appointment"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    'Add an appointment
    Dim appointment As Gravitybox.Objects.Appointment
    Call Schedule1.AppointmentCollection.Clear()
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:00:00 AM#, 90)
    appointment.Subject = "This is a test"

    'Add providers to the appointment
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(0))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(1))
    Call appointment.ProviderList.Add(Schedule1.ProviderCollection(2))

    'Redraw the schedule
    Call Schedule1.Refresh()

  End Sub

  Private Sub UserDrawnForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup the screen
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/10/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.UserDrawn
    Schedule1.AppointmentBar.Size = 10
    lblDescription.Text = "Press the 'Add' button to add an appointment with a user-drawn provider bar."

    'Add some Providers to the schedule
    'The appointment is 90 minutes and the scehdule increment is 30 minutes
    'This divides equally to 3 providers one for each 30 minute period
    Call Schedule1.ProviderCollection.Add("", "Provider1", Color.Blue)
    Call Schedule1.ProviderCollection.Add("", "Provider2", Color.Yellow)
    Call Schedule1.ProviderCollection.Add("", "Provider3", Color.Green)

  End Sub


  Private Sub Schedule1_UserDrawnBar(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentUserDrawEventArgs) Handles Schedule1.UserDrawnAppointmentBar

    Dim provider As Gravitybox.Objects.Provider
    Dim top As Integer = e.rectangle.Top 'start at the rectangle's top

    '*** NOTE **********************************************
    'The rectangle defined in this event's "e" parameter object
    'is the bounding rectangle of the bar that is to be user drawn.
    'You mayof course draw outside of this region but you WILL 
    'overwrite other graphics and this maynot look good.
    'It is best practice to draw inside of the bounding rectangle.
    '*******************************************************

    'Loop through all of the providers for the appointment
    'Assume that each provider serves one TimeIncrement (30 minutes)
    'so draw the provider color bar for an entire row
    For Each provider In e.Appointment.ProviderList

      Dim left As Integer = e.rectangle.Left 'the left side of the rectange
      Dim width As Integer = e.rectangle.Width 'the width of the rectangle
      Dim height As Integer = Schedule1.RowHeader.Size 'the height of an entire row

      'Fill a rectangle for this provider at this TimeIncrement
      Call e.graphics.FillRectangle(New SolidBrush(provider.Color), New Rectangle(left, top, width, height))

      'Move down one row for each provider
      top += Schedule1.RowHeader.Size
    Next

  End Sub

End Class
