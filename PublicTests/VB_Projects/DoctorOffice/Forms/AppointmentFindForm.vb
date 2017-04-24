Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects
Imports Gravitybox.Objects

Public Class AppointmentFindForm
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
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOk As System.Windows.Forms.Button
  Friend WithEvents fraPatient As System.Windows.Forms.GroupBox
  Friend WithEvents lstPatient As System.Windows.Forms.CheckedListBox
  Friend WithEvents fraDate As System.Windows.Forms.GroupBox
  Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
  Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
  Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.fraPatient = New System.Windows.Forms.GroupBox()
    Me.cmdUncheckAll = New System.Windows.Forms.Button()
    Me.cmdCheckAll = New System.Windows.Forms.Button()
    Me.lstPatient = New System.Windows.Forms.CheckedListBox()
    Me.fraDate = New System.Windows.Forms.GroupBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.dtpStart = New System.Windows.Forms.DateTimePicker()
    Me.fraPatient.SuspendLayout()
    Me.fraDate.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdCancel
    '
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.Location = New System.Drawing.Point(392, 248)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 6
    Me.cmdCancel.Tag = ""
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdOk
    '
    Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.cmdOk.Location = New System.Drawing.Point(304, 248)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 5
    Me.cmdOk.Text = "&OK"
    '
    'fraPatient
    '
    Me.fraPatient.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUncheckAll, Me.cmdCheckAll, Me.lstPatient})
    Me.fraPatient.Location = New System.Drawing.Point(8, 8)
    Me.fraPatient.Name = "fraPatient"
    Me.fraPatient.Size = New System.Drawing.Size(464, 168)
    Me.fraPatient.TabIndex = 5
    Me.fraPatient.TabStop = False
    Me.fraPatient.Text = "Patient"
    '
    'cmdUncheckAll
    '
    Me.cmdUncheckAll.Location = New System.Drawing.Point(352, 128)
    Me.cmdUncheckAll.Name = "cmdUncheckAll"
    Me.cmdUncheckAll.Size = New System.Drawing.Size(104, 24)
    Me.cmdUncheckAll.TabIndex = 2
    Me.cmdUncheckAll.Text = "Uncheck All"
    '
    'cmdCheckAll
    '
    Me.cmdCheckAll.Location = New System.Drawing.Point(240, 128)
    Me.cmdCheckAll.Name = "cmdCheckAll"
    Me.cmdCheckAll.Size = New System.Drawing.Size(104, 24)
    Me.cmdCheckAll.TabIndex = 1
    Me.cmdCheckAll.Text = "Check All"
    '
    'lstPatient
    '
    Me.lstPatient.Location = New System.Drawing.Point(16, 24)
    Me.lstPatient.Name = "lstPatient"
    Me.lstPatient.Size = New System.Drawing.Size(440, 94)
    Me.lstPatient.TabIndex = 0
    '
    'fraDate
    '
    Me.fraDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.dtpEnd, Me.Label1, Me.dtpStart})
    Me.fraDate.Location = New System.Drawing.Point(8, 184)
    Me.fraDate.Name = "fraDate"
    Me.fraDate.Size = New System.Drawing.Size(464, 56)
    Me.fraDate.TabIndex = 6
    Me.fraDate.TabStop = False
    Me.fraDate.Text = "Dates"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(240, 24)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "End Date:"
    '
    'dtpEnd
    '
    Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpEnd.Location = New System.Drawing.Point(344, 24)
    Me.dtpEnd.Name = "dtpEnd"
    Me.dtpEnd.ShowCheckBox = True
    Me.dtpEnd.Size = New System.Drawing.Size(112, 20)
    Me.dtpEnd.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 16)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Start Date:"
    '
    'dtpStart
    '
    Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpStart.Location = New System.Drawing.Point(120, 24)
    Me.dtpStart.Name = "dtpStart"
    Me.dtpStart.ShowCheckBox = True
    Me.dtpStart.Size = New System.Drawing.Size(112, 20)
    Me.dtpStart.TabIndex = 3
    '
    'AppointmentFindForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(482, 279)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.fraDate, Me.fraPatient, Me.cmdCancel, Me.cmdOk})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AppointmentFindForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Find"
    Me.fraPatient.ResumeLayout(False)
    Me.fraDate.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_PatientCollection As PatientCollection
  Private m_AppointmentList As AppointmentList
  Private m_AppointmentCollection As AppointmentCollection
  Private m_ScheduleObject As Gravitybox.Controls.Schedule

  Public Property ScheduleObject() As Gravitybox.Controls.Schedule
    Get
      Return m_ScheduleObject
    End Get
    Set(ByVal Value As Gravitybox.Controls.Schedule)
      m_ScheduleObject = Value
    End Set
  End Property

  Public Property PatientCollection() As PatientCollection
    Get
      Return m_PatientCollection
    End Get
    Set(ByVal Value As PatientCollection)

      m_PatientCollection = Value

      'Load the Patient listbox
      Dim patient As PatientItem
      For Each patient In Me.PatientCollection
        Me.lstPatient.Items.Add(patient.LName & ", " & patient.FName)
      Next

    End Set
  End Property

  Public ReadOnly Property AppointmentList() As AppointmentList
    Get
      Return m_AppointmentList
    End Get
  End Property

  Public Property AppointmentCollection() As AppointmentCollection
    Get
      Return m_AppointmentCollection
    End Get
    Set(ByVal Value As AppointmentCollection)
      m_AppointmentCollection = Value
    End Set
  End Property

  Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click

    Dim ii As Integer
    For ii = 0 To lstPatient.Items.Count - 1
      Call lstPatient.SetItemChecked(ii, True)
    Next

  End Sub

  Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click

    Dim ii As Integer
    For ii = 0 To lstPatient.Items.Count - 1
      Call lstPatient.SetItemChecked(ii, False)
    Next

  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Call Me.Close()
  End Sub

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

		Dim masterList As BaseList = CType(New AppointmentList(ScheduleObject), Gravitybox.Objects.BaseList)

		'Narrow by patient
    Dim o As Object
		For Each o In Me.lstPatient.CheckedItems
			Dim apptList As Gravitybox.Objects.BaseList = CType(Me.AppointmentCollection.Find(CType(o, String)), Gravitybox.Objects.BaseList)
			masterList = masterList.Union(apptList)
		Next

		'Narrow by date range
		Dim startDate As Date = #1/1/1900#
		Dim endDate As Date = #1/1/2200#
		If Me.dtpStart.Checked Then startDate = Me.dtpStart.Value
		If Me.dtpEnd.Checked Then endDate = Me.dtpEnd.Value
		masterList = masterList.Intersect(Me.AppointmentCollection.Find(startDate, endDate))

		m_AppointmentList = CType(masterList, AppointmentList)
		Call Me.Close()

  End Sub

  Private Sub AppointmentFindForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    dtpStart.Value = Now
    dtpStart.Checked = True
    dtpEnd.Value = DateAdd(DateInterval.Month, 1, Now)
    dtpEnd.Checked = True
  End Sub

End Class
