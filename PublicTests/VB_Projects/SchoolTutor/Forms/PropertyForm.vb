Option Strict On
Option Explicit On 

Imports SchoolTutor.Objects

Namespace Forms

  Public Class PropertyForm
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStudent As System.Windows.Forms.ComboBox
    Friend WithEvents cboTutor As System.Windows.Forms.ComboBox
    Friend WithEvents cboCourse As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLength As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmdClose = New System.Windows.Forms.Button()
      Me.dtpDate = New System.Windows.Forms.DateTimePicker()
      Me.dtpTime = New System.Windows.Forms.DateTimePicker()
      Me.cboStudent = New System.Windows.Forms.ComboBox()
      Me.cboTutor = New System.Windows.Forms.ComboBox()
      Me.cboCourse = New System.Windows.Forms.ComboBox()
      Me.cmdSave = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblLength = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(128, 16)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Date:"
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(16, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(128, 16)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Time:"
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(16, 88)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(128, 16)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "Student:"
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(16, 112)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(128, 16)
      Me.Label4.TabIndex = 3
      Me.Label4.Text = "Tutor:"
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(16, 136)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(128, 16)
      Me.Label5.TabIndex = 4
      Me.Label5.Text = "Course:"
      '
      'cmdClose
      '
      Me.cmdClose.Location = New System.Drawing.Point(216, 168)
      Me.cmdClose.Name = "cmdClose"
      Me.cmdClose.Size = New System.Drawing.Size(80, 24)
      Me.cmdClose.TabIndex = 6
      Me.cmdClose.Text = "&Close"
      '
      'dtpDate
      '
      Me.dtpDate.CustomFormat = "mm/dd/yyy"
      Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDate.Location = New System.Drawing.Point(160, 16)
      Me.dtpDate.Name = "dtpDate"
      Me.dtpDate.ShowUpDown = True
      Me.dtpDate.Size = New System.Drawing.Size(136, 20)
      Me.dtpDate.TabIndex = 0
      '
      'dtpTime
      '
      Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpTime.Location = New System.Drawing.Point(160, 40)
      Me.dtpTime.Name = "dtpTime"
      Me.dtpTime.ShowUpDown = True
      Me.dtpTime.Size = New System.Drawing.Size(136, 20)
      Me.dtpTime.TabIndex = 1
      '
      'cboStudent
      '
      Me.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboStudent.Location = New System.Drawing.Point(160, 88)
      Me.cboStudent.Name = "cboStudent"
      Me.cboStudent.Size = New System.Drawing.Size(136, 21)
      Me.cboStudent.TabIndex = 2
      '
      'cboTutor
      '
      Me.cboTutor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboTutor.Location = New System.Drawing.Point(160, 112)
      Me.cboTutor.Name = "cboTutor"
      Me.cboTutor.Size = New System.Drawing.Size(136, 21)
      Me.cboTutor.TabIndex = 3
      '
      'cboCourse
      '
      Me.cboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboCourse.Location = New System.Drawing.Point(160, 136)
      Me.cboCourse.Name = "cboCourse"
      Me.cboCourse.Size = New System.Drawing.Size(136, 21)
      Me.cboCourse.TabIndex = 4
      '
      'cmdSave
      '
      Me.cmdSave.Location = New System.Drawing.Point(128, 168)
      Me.cmdSave.Name = "cmdSave"
      Me.cmdSave.Size = New System.Drawing.Size(80, 24)
      Me.cmdSave.TabIndex = 5
      Me.cmdSave.Text = "&Save"
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(16, 64)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(128, 16)
      Me.Label6.TabIndex = 7
      Me.Label6.Text = "Length:"
      '
      'lblLength
      '
      Me.lblLength.Location = New System.Drawing.Point(160, 64)
      Me.lblLength.Name = "lblLength"
      Me.lblLength.Size = New System.Drawing.Size(128, 16)
      Me.lblLength.TabIndex = 8
      Me.lblLength.Text = "XXX"
      '
      'PropertyForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(304, 199)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLength, Me.Label6, Me.cmdSave, Me.cboCourse, Me.cboTutor, Me.cboStudent, Me.dtpTime, Me.dtpDate, Me.cmdClose, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1})
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PropertyForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Appointment Properties"
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_Appointment As Gravitybox.Objects.Appointment
    Private m_CourseItems As New Objects.CourseItems()
    Private m_StudentItems As New Objects.StudentItems()
    Private m_TutorItems As New Objects.TutorItems()

    Public Property Appointment() As Gravitybox.Objects.Appointment
      Get
        Return m_Appointment
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appointment)
        m_Appointment = Value
        Call SetupAppointment()
      End Set
    End Property

    Public Property CourseItems() As Objects.CourseItems
      Get
        Return m_CourseItems
      End Get
      Set(ByVal Value As Objects.CourseItems)
        m_CourseItems = Value

        Dim course As Objects.CourseItem
        Call cboCourse.Items.Clear()
        For Each course In Me.CourseItems
          Call cboCourse.Items.Add(course.Text)
        Next

      End Set
    End Property

    Public Property StudentItems() As Objects.StudentItems
      Get
        Return m_StudentItems
      End Get
      Set(ByVal Value As Objects.StudentItems)
        m_StudentItems = Value

        Dim student As Objects.StudentItem
        Call cboStudent.Items.Clear()
        For Each student In Me.StudentItems
          Call cboStudent.Items.Add(student.ToString)
        Next

      End Set
    End Property

    Public Property TutorItems() As Objects.TutorItems
      Get
        Return m_TutorItems
      End Get
      Set(ByVal Value As Objects.TutorItems)
        m_TutorItems = Value

        Dim tutor As Objects.TutorItem
        Call cboTutor.Items.Clear()
        For Each tutor In Me.TutorItems
          Call cboTutor.Items.Add(tutor.ToString)
        Next

      End Set
    End Property

    Private Sub SetupAppointment()

      dtpDate.Value = Appointment.StartDate
      dtpTime.Value = Date.Parse("1/1/2002 " & Appointment.StartTime)
      lblLength.Text = Appointment.Length.ToString & " minute(s)"
      If Me.StudentItems.Exists(Appointment.PropertyItemCollection("student").Setting) Then
        cboStudent.SelectedIndex = Me.StudentItems(Appointment.PropertyItemCollection("student").Setting).Index
      End If
      If Me.TutorItems.Exists(Appointment.PropertyItemCollection("tutor").Setting) Then
        cboTutor.SelectedIndex = Me.TutorItems(Appointment.PropertyItemCollection("tutor").Setting).Index
      End If
      If Me.CourseItems.Exists(Appointment.PropertyItemCollection("course").Setting) Then
        cboCourse.SelectedIndex = Me.CourseItems(Appointment.PropertyItemCollection("course").Setting).Index
      End If

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
      Call Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
      If Save() Then
        Call Me.Close()
      End If
    End Sub

    Private Function Save() As Boolean

      'Verify
      If (cboStudent.SelectedIndex = -1) OrElse (cboTutor.SelectedIndex = -1) OrElse (cboCourse.SelectedIndex = -1) Then
        Call MsgBox("All fields must be filled-in!", MsgBoxStyle.Exclamation, "Error!")
        Return False
      End If

      'Now save
      Appointment.StartDate = dtpDate.Value
      Appointment.StartTime = dtpTime.Value

      Call Appointment.PropertyItemCollection.Clear()
      Call Appointment.PropertyItemCollection.Add("", "student", Me.StudentItems(cboStudent.SelectedIndex).Key)
      Call Appointment.PropertyItemCollection.Add("", "tutor", Me.TutorItems(cboTutor.SelectedIndex).Key)
      Call Appointment.PropertyItemCollection.Add("", "course", Me.CourseItems(cboCourse.SelectedIndex).Key)

      Return True

    End Function

  End Class

End Namespace