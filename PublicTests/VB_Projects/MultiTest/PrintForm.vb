Option Strict On
Option Explicit On 

Public Class PrintForm
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
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents cmdPrint As System.Windows.Forms.Button
  Friend WithEvents cmdPreview As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.Schedule1 = New Gravitybox.Controls.Schedule()
    Me.cmdPrint = New System.Windows.Forms.Button()
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.cmdPreview = New System.Windows.Forms.Button()
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
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.MinutesShown = Gravitybox.Controls.Schedule.MinutesShownConstants.FirstOnly
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.ScrollBars = System.Windows.Forms.ScrollBars.Both
    Me.Schedule1.SelectedItem = Nothing
    Me.Schedule1.Size = New System.Drawing.Size(584, 376)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 0
    Me.Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Me.Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    '
    'cmdPrint
    '
    Me.cmdPrint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdPrint.Location = New System.Drawing.Point(504, 384)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(80, 24)
    Me.cmdPrint.TabIndex = 1
    Me.cmdPrint.Text = "Print"
    '
    'ImageList1
    '
    Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
    Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'cmdPreview
    '
    Me.cmdPreview.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdPreview.Location = New System.Drawing.Point(416, 384)
    Me.cmdPreview.Name = "cmdPreview"
    Me.cmdPreview.Size = New System.Drawing.Size(80, 24)
    Me.cmdPreview.TabIndex = 2
    Me.cmdPreview.Text = "Preview"
    '
    'PrintForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(584, 413)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdPreview, Me.cmdPrint, Me.Schedule1})
    Me.Name = "PrintForm"
    Me.Text = "IconForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub PrintForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Setup schedule
    Call Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.EventHeader.AllowHeader = False
    Schedule1.AppointmentBar.BarType = Gravitybox.Controls.Schedule.AppointmentBarConstants.Category

    'Add Categories
    Call Schedule1.CategoryCollection.Add("", "Category 1", Color.Blue)
    Call Schedule1.CategoryCollection.Add("", "Category 2", Color.Yellow)
    Call Schedule1.CategoryCollection.Add("", "Category 3", Color.LightGreen)

    'Add appointments
    Dim appointment As Gravitybox.Objects.Appointment

    appointment = Schedule1.AppointmentCollection.Add("", #1/1/2004#, #9:00:00 AM#, 60)
    appointment.Subject = "Suzy Smith"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(2))

    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #11:00:00 AM#, 60)
    appointment.Subject = "Walter Cline"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(1))

    appointment = Schedule1.AppointmentCollection.Add("", #1/3/2004#, #9:30:00 AM#, 60)
    appointment.Subject = "Jeff Newton"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(2))

    appointment = Schedule1.AppointmentCollection.Add("", #1/5/2004#, #1:30:00 PM#, 60)
    appointment.Subject = "Tom Jones"
    appointment.CategoryList.Add(Schedule1.CategoryCollection(0))

  End Sub

  Private Sub cmdPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPreview.Click

    'Preview the defined schedule area
    Dim dialogSettings As New Gravitybox.Objects.PrintDialogSettings(#1/2/2004#, #9:00:00 AM#, #1/4/2004#, #4:00:00 PM#)
    Call Schedule1.GoPreview(dialogSettings)

  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click

    'Print a portion of the schedule
    Dim dialogSettings As New Gravitybox.Objects.PrintDialogSettings(#1/2/2004#, #9:00:00 AM#, #1/4/2004#, #4:00:00 PM#)
    Call Schedule1.GoPrint()

  End Sub

End Class
