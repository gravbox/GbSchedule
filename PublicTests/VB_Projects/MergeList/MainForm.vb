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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lstList1 As System.Windows.Forms.ListBox
  Friend WithEvents lstList2 As System.Windows.Forms.ListBox
  Friend WithEvents lstUnion As System.Windows.Forms.ListBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lstSubtract As System.Windows.Forms.ListBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lstIntersect As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label2 = New System.Windows.Forms.Label
    Me.lstList1 = New System.Windows.Forms.ListBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.lstList2 = New System.Windows.Forms.ListBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.lstUnion = New System.Windows.Forms.ListBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.lstSubtract = New System.Windows.Forms.ListBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.lstIntersect = New System.Windows.Forms.ListBox
    Me.SuspendLayout()
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 8)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(160, 16)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "List 1"
    '
    'lstList1
    '
    Me.lstList1.Location = New System.Drawing.Point(8, 24)
    Me.lstList1.Name = "lstList1"
    Me.lstList1.Size = New System.Drawing.Size(312, 82)
    Me.lstList1.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 120)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(160, 16)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "List 2"
    '
    'lstList2
    '
    Me.lstList2.Location = New System.Drawing.Point(8, 136)
    Me.lstList2.Name = "lstList2"
    Me.lstList2.Size = New System.Drawing.Size(312, 82)
    Me.lstList2.TabIndex = 1
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(336, 8)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(160, 16)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Union"
    '
    'lstUnion
    '
    Me.lstUnion.Location = New System.Drawing.Point(336, 24)
    Me.lstUnion.Name = "lstUnion"
    Me.lstUnion.Size = New System.Drawing.Size(312, 82)
    Me.lstUnion.TabIndex = 2
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(336, 112)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(160, 16)
    Me.Label5.TabIndex = 13
    Me.Label5.Text = "Subtract"
    '
    'lstSubtract
    '
    Me.lstSubtract.Location = New System.Drawing.Point(336, 128)
    Me.lstSubtract.Name = "lstSubtract"
    Me.lstSubtract.Size = New System.Drawing.Size(312, 82)
    Me.lstSubtract.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(336, 224)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(160, 16)
    Me.Label1.TabIndex = 16
    Me.Label1.Text = "Intersect"
    '
    'lstIntersect
    '
    Me.lstIntersect.Location = New System.Drawing.Point(336, 240)
    Me.lstIntersect.Name = "lstIntersect"
    Me.lstIntersect.Size = New System.Drawing.Size(312, 82)
    Me.lstIntersect.TabIndex = 4
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(658, 335)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.lstIntersect)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.lstSubtract)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.lstUnion)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.lstList2)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.lstList1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Schedule1 As New Gravitybox.Controls.Schedule
  Private list1 As AppointmentList
  Private list2 As AppointmentList

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'Create appointments
    Schedule1.AppointmentCollection.Add("appt0", #1/1/2004#, #8:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("appt1", #1/1/2004#, #9:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("appt2", #1/2/2004#, #8:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("appt3", #1/2/2004#, #9:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("appt4", #1/3/2004#, #8:00:00 AM#, 60)
    Schedule1.AppointmentCollection.Add("appt5", #1/3/2004#, #9:00:00 AM#, 60)

    'Create list 1 appointments 0, 1, 2, 3
    list1 = New Gravitybox.Objects.AppointmentList(Schedule1)
    list1.Add(Schedule1.AppointmentCollection(0))
    list1.Add(Schedule1.AppointmentCollection(1))
    list1.Add(Schedule1.AppointmentCollection(2))
    list1.Add(Schedule1.AppointmentCollection(3))
    DisplayAppointments(list1, lstList1)

    'Create list 2 appointments 3, 4, 5
    list2 = New Gravitybox.Objects.AppointmentList(Schedule1)
    list2.Add(Schedule1.AppointmentCollection(3))
    list2.Add(Schedule1.AppointmentCollection(4))
    list2.Add(Schedule1.AppointmentCollection(5))
    DisplayAppointments(list2, lstList2)

    'RESULTS:
    'UNION (list1 + list2) = Appointments[0,1,2,3,4,5]
    'SUBTRACTION (list1 - list2) = Appointments[0,1,2]
    'INTERSECTION (appointments in list1 AND list2) = Appointments[3]

    Dim listAdd As AppointmentList
    listAdd = list1.Union(list2)
    DisplayAppointments(listAdd, lstUnion)

    Dim listSubtract As AppointmentList
    listSubtract = list1.Subtract(list2)
    DisplayAppointments(listSubtract, lstSubtract)

    Dim listIntersect As AppointmentList
    listIntersect = list1.Intersect(list2)
    DisplayAppointments(listIntersect, lstIntersect)

  End Sub

  Private Sub DisplayAppointments(ByVal appointmentList As AppointmentList, ByVal lstbox As System.Windows.Forms.ListBox)

    lstbox.Items.Clear()
    Dim appointment As Appointment
    For Each appointment In appointmentList
      lstbox.Items.Add(appointment.Key)
    Next

  End Sub

End Class
