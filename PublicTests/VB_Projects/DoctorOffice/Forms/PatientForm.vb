Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class PatientForm
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
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
  Friend WithEvents tabNotes As System.Windows.Forms.TabPage
  Friend WithEvents txtNotes As System.Windows.Forms.TextBox
  Friend WithEvents tabAppointments As System.Windows.Forms.TabPage
  Friend WithEvents lvwAppointments As System.Windows.Forms.ListView
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
  Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents Label18 As System.Windows.Forms.Label
  Friend WithEvents dtpLastRecall As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpAquired As System.Windows.Forms.DateTimePicker
  Friend WithEvents txtAccount As System.Windows.Forms.TextBox
  Friend WithEvents txtSSN As System.Windows.Forms.TextBox
  Friend WithEvents txtZip As System.Windows.Forms.TextBox
  Friend WithEvents txtState As System.Windows.Forms.TextBox
  Friend WithEvents txtCity As System.Windows.Forms.TextBox
  Friend WithEvents txtPhoneMobile As System.Windows.Forms.TextBox
  Friend WithEvents txtPhoneBusiness As System.Windows.Forms.TextBox
  Friend WithEvents txtPhoneHome As System.Windows.Forms.TextBox
  Friend WithEvents txtEmail As System.Windows.Forms.TextBox
  Friend WithEvents txtAddress As System.Windows.Forms.TextBox
  Friend WithEvents txtLName As System.Windows.Forms.TextBox
  Friend WithEvents txtFName As System.Windows.Forms.TextBox
  Friend WithEvents txtPhysician As System.Windows.Forms.TextBox
  Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
  Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.tabGeneral = New System.Windows.Forms.TabPage()
    Me.txtPhysician = New System.Windows.Forms.TextBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.dtpLastRecall = New System.Windows.Forms.DateTimePicker()
    Me.Label16 = New System.Windows.Forms.Label()
    Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker()
    Me.Label15 = New System.Windows.Forms.Label()
    Me.dtpAquired = New System.Windows.Forms.DateTimePicker()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.txtAccount = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.txtSSN = New System.Windows.Forms.TextBox()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.txtZip = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.txtState = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.txtCity = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.txtPhoneMobile = New System.Windows.Forms.TextBox()
    Me.txtPhoneBusiness = New System.Windows.Forms.TextBox()
    Me.txtPhoneHome = New System.Windows.Forms.TextBox()
    Me.PictureBox4 = New System.Windows.Forms.PictureBox()
    Me.PictureBox3 = New System.Windows.Forms.PictureBox()
    Me.PictureBox2 = New System.Windows.Forms.PictureBox()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.txtEmail = New System.Windows.Forms.TextBox()
    Me.txtAddress = New System.Windows.Forms.TextBox()
    Me.txtLName = New System.Windows.Forms.TextBox()
    Me.txtFName = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.tabAppointments = New System.Windows.Forms.TabPage()
    Me.lvwAppointments = New System.Windows.Forms.ListView()
    Me.tabNotes = New System.Windows.Forms.TabPage()
    Me.txtNotes = New System.Windows.Forms.TextBox()
    Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader()
    Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader()
    Me.TabControl1.SuspendLayout()
    Me.tabGeneral.SuspendLayout()
    Me.tabAppointments.SuspendLayout()
    Me.tabNotes.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdCancel
    '
    Me.cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdCancel.Location = New System.Drawing.Point(560, 288)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 3
    Me.cmdCancel.Tag = ""
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdOk
    '
    Me.cmdOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdOk.Location = New System.Drawing.Point(472, 288)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 2
    Me.cmdOk.Text = "&OK"
    '
    'TabControl1
    '
    Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGeneral, Me.tabAppointments, Me.tabNotes})
    Me.TabControl1.Location = New System.Drawing.Point(8, 8)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(632, 272)
    Me.TabControl1.TabIndex = 4
    '
    'tabGeneral
    '
    Me.tabGeneral.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPhysician, Me.Label18, Me.dtpLastRecall, Me.Label16, Me.dtpBirthDate, Me.Label15, Me.dtpAquired, Me.Label14, Me.txtAccount, Me.Label13, Me.txtSSN, Me.Label11, Me.txtZip, Me.Label10, Me.txtState, Me.Label9, Me.txtCity, Me.Label5, Me.txtPhoneMobile, Me.txtPhoneBusiness, Me.txtPhoneHome, Me.PictureBox4, Me.PictureBox3, Me.PictureBox2, Me.PictureBox1, Me.txtEmail, Me.txtAddress, Me.txtLName, Me.txtFName, Me.Label6, Me.Label7, Me.Label8, Me.Label3, Me.Label4, Me.Label2, Me.Label1})
    Me.tabGeneral.Location = New System.Drawing.Point(4, 22)
    Me.tabGeneral.Name = "tabGeneral"
    Me.tabGeneral.Size = New System.Drawing.Size(624, 246)
    Me.tabGeneral.TabIndex = 0
    Me.tabGeneral.Text = "General"
    '
    'txtPhysician
    '
    Me.txtPhysician.Location = New System.Drawing.Point(464, 192)
    Me.txtPhysician.Name = "txtPhysician"
    Me.txtPhysician.Size = New System.Drawing.Size(152, 20)
    Me.txtPhysician.TabIndex = 39
    Me.txtPhysician.Text = ""
    '
    'Label18
    '
    Me.Label18.Location = New System.Drawing.Point(360, 192)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(96, 16)
    Me.Label18.TabIndex = 38
    Me.Label18.Text = "Physician:"
    '
    'dtpLastRecall
    '
    Me.dtpLastRecall.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpLastRecall.Location = New System.Drawing.Point(464, 168)
    Me.dtpLastRecall.Name = "dtpLastRecall"
    Me.dtpLastRecall.Size = New System.Drawing.Size(96, 20)
    Me.dtpLastRecall.TabIndex = 36
    '
    'Label16
    '
    Me.Label16.Location = New System.Drawing.Point(360, 168)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(96, 16)
    Me.Label16.TabIndex = 35
    Me.Label16.Text = "Last Recall:"
    '
    'dtpBirthDate
    '
    Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpBirthDate.Location = New System.Drawing.Point(464, 144)
    Me.dtpBirthDate.Name = "dtpBirthDate"
    Me.dtpBirthDate.Size = New System.Drawing.Size(96, 20)
    Me.dtpBirthDate.TabIndex = 34
    '
    'Label15
    '
    Me.Label15.Location = New System.Drawing.Point(360, 144)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(96, 16)
    Me.Label15.TabIndex = 33
    Me.Label15.Text = "Birth Date:"
    '
    'dtpAquired
    '
    Me.dtpAquired.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpAquired.Location = New System.Drawing.Point(160, 32)
    Me.dtpAquired.Name = "dtpAquired"
    Me.dtpAquired.Size = New System.Drawing.Size(96, 20)
    Me.dtpAquired.TabIndex = 32
    '
    'Label14
    '
    Me.Label14.Location = New System.Drawing.Point(56, 32)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(96, 16)
    Me.Label14.TabIndex = 31
    Me.Label14.Text = "Aquired:"
    '
    'txtAccount
    '
    Me.txtAccount.Location = New System.Drawing.Point(160, 8)
    Me.txtAccount.Name = "txtAccount"
    Me.txtAccount.ReadOnly = True
    Me.txtAccount.Size = New System.Drawing.Size(152, 20)
    Me.txtAccount.TabIndex = 30
    Me.txtAccount.Text = ""
    '
    'Label13
    '
    Me.Label13.Location = New System.Drawing.Point(56, 8)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(96, 16)
    Me.Label13.TabIndex = 29
    Me.Label13.Text = "Account:"
    '
    'txtSSN
    '
    Me.txtSSN.Location = New System.Drawing.Point(464, 216)
    Me.txtSSN.Name = "txtSSN"
    Me.txtSSN.Size = New System.Drawing.Size(152, 20)
    Me.txtSSN.TabIndex = 26
    Me.txtSSN.Text = ""
    '
    'Label11
    '
    Me.Label11.Location = New System.Drawing.Point(360, 216)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(96, 16)
    Me.Label11.TabIndex = 25
    Me.Label11.Text = "SSN:"
    '
    'txtZip
    '
    Me.txtZip.Location = New System.Drawing.Point(160, 216)
    Me.txtZip.Name = "txtZip"
    Me.txtZip.Size = New System.Drawing.Size(152, 20)
    Me.txtZip.TabIndex = 24
    Me.txtZip.Text = ""
    '
    'Label10
    '
    Me.Label10.Location = New System.Drawing.Point(56, 216)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(96, 16)
    Me.Label10.TabIndex = 23
    Me.Label10.Text = "Zip:"
    '
    'txtState
    '
    Me.txtState.Location = New System.Drawing.Point(160, 192)
    Me.txtState.Name = "txtState"
    Me.txtState.Size = New System.Drawing.Size(152, 20)
    Me.txtState.TabIndex = 22
    Me.txtState.Text = ""
    '
    'Label9
    '
    Me.Label9.Location = New System.Drawing.Point(56, 192)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(96, 16)
    Me.Label9.TabIndex = 21
    Me.Label9.Text = "State:"
    '
    'txtCity
    '
    Me.txtCity.Location = New System.Drawing.Point(160, 168)
    Me.txtCity.Name = "txtCity"
    Me.txtCity.Size = New System.Drawing.Size(152, 20)
    Me.txtCity.TabIndex = 20
    Me.txtCity.Text = ""
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(56, 168)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(96, 16)
    Me.Label5.TabIndex = 19
    Me.Label5.Text = "City:"
    '
    'txtPhoneMobile
    '
    Me.txtPhoneMobile.Location = New System.Drawing.Point(464, 56)
    Me.txtPhoneMobile.Name = "txtPhoneMobile"
    Me.txtPhoneMobile.Size = New System.Drawing.Size(152, 20)
    Me.txtPhoneMobile.TabIndex = 18
    Me.txtPhoneMobile.Text = ""
    '
    'txtPhoneBusiness
    '
    Me.txtPhoneBusiness.Location = New System.Drawing.Point(464, 32)
    Me.txtPhoneBusiness.Name = "txtPhoneBusiness"
    Me.txtPhoneBusiness.Size = New System.Drawing.Size(152, 20)
    Me.txtPhoneBusiness.TabIndex = 17
    Me.txtPhoneBusiness.Text = ""
    '
    'txtPhoneHome
    '
    Me.txtPhoneHome.Location = New System.Drawing.Point(464, 8)
    Me.txtPhoneHome.Name = "txtPhoneHome"
    Me.txtPhoneHome.Size = New System.Drawing.Size(152, 20)
    Me.txtPhoneHome.TabIndex = 16
    Me.txtPhoneHome.Text = ""
    '
    'PictureBox4
    '
    Me.PictureBox4.Location = New System.Drawing.Point(320, 8)
    Me.PictureBox4.Name = "PictureBox4"
    Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox4.TabIndex = 15
    Me.PictureBox4.TabStop = False
    '
    'PictureBox3
    '
    Me.PictureBox3.Location = New System.Drawing.Point(16, 144)
    Me.PictureBox3.Name = "PictureBox3"
    Me.PictureBox3.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox3.TabIndex = 14
    Me.PictureBox3.TabStop = False
    '
    'PictureBox2
    '
    Me.PictureBox2.Location = New System.Drawing.Point(320, 88)
    Me.PictureBox2.Name = "PictureBox2"
    Me.PictureBox2.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox2.TabIndex = 13
    Me.PictureBox2.TabStop = False
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(16, 80)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
    Me.PictureBox1.TabIndex = 12
    Me.PictureBox1.TabStop = False
    '
    'txtEmail
    '
    Me.txtEmail.Location = New System.Drawing.Point(464, 96)
    Me.txtEmail.Name = "txtEmail"
    Me.txtEmail.Size = New System.Drawing.Size(152, 20)
    Me.txtEmail.TabIndex = 11
    Me.txtEmail.Text = ""
    '
    'txtAddress
    '
    Me.txtAddress.Location = New System.Drawing.Point(160, 144)
    Me.txtAddress.Name = "txtAddress"
    Me.txtAddress.Size = New System.Drawing.Size(152, 20)
    Me.txtAddress.TabIndex = 10
    Me.txtAddress.Text = ""
    '
    'txtLName
    '
    Me.txtLName.Location = New System.Drawing.Point(160, 104)
    Me.txtLName.Name = "txtLName"
    Me.txtLName.Size = New System.Drawing.Size(152, 20)
    Me.txtLName.TabIndex = 9
    Me.txtLName.Text = ""
    '
    'txtFName
    '
    Me.txtFName.Location = New System.Drawing.Point(160, 80)
    Me.txtFName.Name = "txtFName"
    Me.txtFName.Size = New System.Drawing.Size(152, 20)
    Me.txtFName.TabIndex = 8
    Me.txtFName.Text = ""
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(360, 56)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(96, 16)
    Me.Label6.TabIndex = 6
    Me.Label6.Text = "Mobile:"
    '
    'Label7
    '
    Me.Label7.Location = New System.Drawing.Point(360, 32)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(96, 16)
    Me.Label7.TabIndex = 5
    Me.Label7.Text = "Business Phone:"
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(360, 8)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(96, 16)
    Me.Label8.TabIndex = 4
    Me.Label8.Text = "Home Phone:"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(360, 96)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(96, 16)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "Email:"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(56, 144)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(96, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Address:"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(56, 104)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(96, 16)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Last Name:"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(56, 80)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "First Name:"
    '
    'tabAppointments
    '
    Me.tabAppointments.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvwAppointments})
    Me.tabAppointments.Location = New System.Drawing.Point(4, 22)
    Me.tabAppointments.Name = "tabAppointments"
    Me.tabAppointments.Size = New System.Drawing.Size(624, 246)
    Me.tabAppointments.TabIndex = 3
    Me.tabAppointments.Text = "Appointments"
    '
    'lvwAppointments
    '
    Me.lvwAppointments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader4, Me.ColumnHeader6})
    Me.lvwAppointments.Dock = System.Windows.Forms.DockStyle.Fill
    Me.lvwAppointments.FullRowSelect = True
    Me.lvwAppointments.HideSelection = False
    Me.lvwAppointments.Name = "lvwAppointments"
    Me.lvwAppointments.Size = New System.Drawing.Size(624, 246)
    Me.lvwAppointments.TabIndex = 0
    Me.lvwAppointments.View = System.Windows.Forms.View.Details
    '
    'tabNotes
    '
    Me.tabNotes.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNotes})
    Me.tabNotes.Location = New System.Drawing.Point(4, 22)
    Me.tabNotes.Name = "tabNotes"
    Me.tabNotes.Size = New System.Drawing.Size(624, 246)
    Me.tabNotes.TabIndex = 1
    Me.tabNotes.Text = "Notes"
    '
    'txtNotes
    '
    Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtNotes.Multiline = True
    Me.txtNotes.Name = "txtNotes"
    Me.txtNotes.Size = New System.Drawing.Size(624, 246)
    Me.txtNotes.TabIndex = 0
    Me.txtNotes.Text = ""
    '
    'ColumnHeader1
    '
    Me.ColumnHeader1.Text = "Date"
    '
    'ColumnHeader2
    '
    Me.ColumnHeader2.Text = "Time"
    '
    'ColumnHeader3
    '
    Me.ColumnHeader3.Text = "Room"
    '
    'ColumnHeader4
    '
    Me.ColumnHeader4.Text = "Patient"
    Me.ColumnHeader4.Width = 300
    '
    'ColumnHeader5
    '
    Me.ColumnHeader5.Text = "Category"
    '
    'ColumnHeader6
    '
    Me.ColumnHeader6.Text = "Fees"
    Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'PatientForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(650, 319)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.cmdCancel, Me.cmdOk})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "PatientForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "<Patient>"
    Me.TabControl1.ResumeLayout(False)
    Me.tabGeneral.ResumeLayout(False)
    Me.tabAppointments.ResumeLayout(False)
    Me.tabNotes.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_PatientItem As PatientItem

  Public Property PatientItem() As PatientItem
    Get
      Return m_PatientItem
    End Get
    Set(ByVal Value As PatientItem)
      m_PatientItem = Value
      Call LoadPatient()
    End Set
  End Property

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Call Me.Close()
  End Sub

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    Call SavePatient()
    Call Me.Close()
  End Sub

  Private Sub LoadPatient()

    txtAccount.Text = PatientItem.Account
    txtAddress.Text = PatientItem.Address
    txtCity.Text = PatientItem.City
    txtEmail.Text = PatientItem.Email
    txtFName.Text = PatientItem.FName
    txtLName.Text = PatientItem.LName
    txtNotes.Text = PatientItem.Notes
    txtPhoneBusiness.Text = PatientItem.PhoneBusiness
    txtPhoneHome.Text = PatientItem.PhoneHome
    txtPhoneMobile.Text = PatientItem.PhoneMobile
    txtPhysician.Text = PatientItem.Physician
    txtSSN.Text = PatientItem.SSN
    txtState.Text = PatientItem.State
    txtZip.Text = PatientItem.Zip
    dtpAquired.Value = PatientItem.AquiredDate
    dtpBirthDate.Value = PatientItem.BirthDate
    dtpLastRecall.Value = PatientItem.LastRecall

  End Sub

  Private Sub SavePatient()

    PatientItem.Account = txtAccount.Text
    PatientItem.Address = txtAddress.Text
    PatientItem.City = txtCity.Text
    PatientItem.Email = txtEmail.Text
    PatientItem.FName = txtFName.Text
    PatientItem.LName = txtLName.Text
    PatientItem.Notes = txtNotes.Text
    PatientItem.PhoneBusiness = txtPhoneBusiness.Text
    PatientItem.PhoneHome = txtPhoneHome.Text
    PatientItem.PhoneMobile = txtPhoneMobile.Text
    PatientItem.Physician = txtPhysician.Text
    PatientItem.SSN = txtSSN.Text
    PatientItem.State = txtState.Text
    PatientItem.Zip = txtZip.Text
    PatientItem.AquiredDate = dtpAquired.Value
    PatientItem.BirthDate = dtpBirthDate.Value
    PatientItem.LastRecall = dtpLastRecall.Value

  End Sub

End Class
