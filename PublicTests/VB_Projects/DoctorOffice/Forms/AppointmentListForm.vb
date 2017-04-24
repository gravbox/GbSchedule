Option Strict On
Option Explicit On 

Imports Gravitybox.Objects
Imports DoctorOfficeAPI.Objects

Public Class AppointmentListForm
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
  Friend WithEvents lvwAppointment As System.Windows.Forms.ListView
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdClose = New System.Windows.Forms.Button()
    Me.lvwAppointment = New System.Windows.Forms.ListView()
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader()
    Me.SuspendLayout()
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdClose.Location = New System.Drawing.Point(462, 182)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(80, 24)
    Me.cmdClose.TabIndex = 2
    Me.cmdClose.Text = "&Close"
    '
    'lvwAppointment
    '
    Me.lvwAppointment.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.lvwAppointment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
    Me.lvwAppointment.FullRowSelect = True
    Me.lvwAppointment.HideSelection = False
    Me.lvwAppointment.Location = New System.Drawing.Point(8, 8)
    Me.lvwAppointment.MultiSelect = False
    Me.lvwAppointment.Name = "lvwAppointment"
    Me.lvwAppointment.Size = New System.Drawing.Size(534, 166)
    Me.lvwAppointment.TabIndex = 4
    Me.lvwAppointment.View = System.Windows.Forms.View.Details
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Date"
    Me.ColumnHeader1.Width = 80
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Time"
    Me.ColumnHeader2.Width = 80
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Room"
    Me.ColumnHeader3.Width = 100
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "Length"
    Me.ColumnHeader4.Width = 100
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "Patient"
    Me.ColumnHeader5.Width = 150
    '
    'AppointmentListForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(552, 213)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwAppointment, Me.cmdClose})
    Me.MaximizeBox = False
    Me.Name = "AppointmentListForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "<AppointmentList>"
    Me.TopMost = True
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_AppointmentList As AppointmentList
  Private m_PatientCollection As PatientCollection
  Private m_MDIForm As MDIForm

  Public Property AppointmentList() As AppointmentList
    Get
      Return m_AppointmentList
    End Get
    Set(ByVal Value As AppointmentList)
      m_AppointmentList = Value

      Try
        Dim appointment As Appointment
        Call lvwAppointment.Items.Clear()
        For Each appointment In Me.AppointmentList
          Dim listItem As New ListViewItem()
          listItem.Text = appointment.StartDate.ToShortDateString
          listItem.SubItems.Add(appointment.StartTime.ToShortTimeString)
          listItem.SubItems.Add(appointment.Room.Text)
          listItem.SubItems.Add(appointment.Length.ToString)
          listItem.SubItems.Add(PatientCollection(appointment.Text).LName & ", " & PatientCollection(appointment.Text).FName)
          listItem.Tag = appointment.Key
          lvwAppointment.Items.Add(listItem)
        Next

      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Set
  End Property

  Public Property PatientCollection() As PatientCollection
    Get
      Return m_PatientCollection
    End Get
    Set(ByVal Value As PatientCollection)
      m_PatientCollection = Value
    End Set
  End Property

  Public Property MDIForm() As MDIForm
    Get
      Return m_MDIForm
    End Get
    Set(ByVal Value As MDIForm)
      m_MDIForm = Value
    End Set
  End Property

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Call Me.Close()
  End Sub

  Private Sub lvwAppointment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAppointment.DoubleClick
    Call ShowAppointment()
  End Sub

  Private Sub lvwAppointment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvwAppointment.KeyPress
    If e.KeyChar = ControlChars.Cr Then
      Call ShowAppointment()
    End If
  End Sub

  Private Sub ShowAppointment()

    Try
      'Make sure that something is selected
      If lvwAppointment.SelectedItems.Count = 0 Then Return
      Dim key As String = CType(lvwAppointment.SelectedItems(0).Tag, String)
      If Not Me.AppointmentList.Contains(key) Then Return
			Dim appointment As Appointment = CType(Me.AppointmentList(key), Appointment)

      'If the schedule screen is not loaded then load it
      'otherwise use the current one
      Dim ScheduleF As ScheduleForm
      If Me.MDIForm.MdiChildren.Length = 0 Then
        ScheduleF = Me.MDIForm.OpenSchedule(appointment.StartDate)
      Else
        ScheduleF = CType(Me.MDIForm.MdiChildren(0), ScheduleForm)
        ScheduleF.ScheduleDate = appointment.StartDate
      End If

      'Ensure that the screen is visible and NOT minimized
      Call ScheduleF.Show()
      If ScheduleF.WindowState = FormWindowState.Minimized Then
        ScheduleF.WindowState = FormWindowState.Maximized
      End If
      Call ScheduleF.Focus()

      'Make the appointment color change
      Call ScheduleF.ColorAppointment(appointment)

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub FixColors()

    Try
      'If the schedule screen is not loaded then load it
      'otherwise use the current one
      Dim ScheduleF As ScheduleForm
      If Me.MDIForm.MdiChildren.Length <> 0 Then
        ScheduleF = CType(Me.MDIForm.MdiChildren(0), ScheduleForm)
        'Make the appointment color change
        Call ScheduleF.ColorAppointment(Nothing)
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub AppointmentListForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Try
      Me.Location = New Point(0, 0)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub AppointmentListForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
    Call FixColors()
  End Sub

End Class
