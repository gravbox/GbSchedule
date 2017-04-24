Option Strict On
Option Explicit On 

Imports Gravitybox.Objects
Imports DoctorOfficeAPI.Objects

Public Class AppointmentPropertiesForm
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
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOk As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents txtNotes As System.Windows.Forms.TextBox
  Friend WithEvents cboPatient As System.Windows.Forms.ComboBox
  Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
  Friend WithEvents cboRoom As System.Windows.Forms.ComboBox
  Friend WithEvents cboLength As System.Windows.Forms.ComboBox
  Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
  Friend WithEvents lstProcedure As System.Windows.Forms.ListBox
  Friend WithEvents lblFee As System.Windows.Forms.Label
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents cmdRemove As System.Windows.Forms.Button
  Friend WithEvents cboADA As System.Windows.Forms.ComboBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.cboCategory = New System.Windows.Forms.ComboBox()
    Me.cboLength = New System.Windows.Forms.ComboBox()
    Me.dtpTime = New System.Windows.Forms.DateTimePicker()
    Me.cboRoom = New System.Windows.Forms.ComboBox()
    Me.dtpDate = New System.Windows.Forms.DateTimePicker()
    Me.cboPatient = New System.Windows.Forms.ComboBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.txtNotes = New System.Windows.Forms.TextBox()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.cmdRemove = New System.Windows.Forms.Button()
    Me.cmdAdd = New System.Windows.Forms.Button()
    Me.cboADA = New System.Windows.Forms.ComboBox()
    Me.lblFee = New System.Windows.Forms.Label()
    Me.lstProcedure = New System.Windows.Forms.ListBox()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
    Me.TabControl1.Location = New System.Drawing.Point(8, 8)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(312, 200)
    Me.TabControl1.TabIndex = 0
    '
    'TabPage1
    '
    Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCategory, Me.cboLength, Me.dtpTime, Me.cboRoom, Me.dtpDate, Me.cboPatient, Me.Label8, Me.Label5, Me.Label6, Me.Label3, Me.Label4, Me.Label2, Me.Label1})
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Size = New System.Drawing.Size(304, 174)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "General"
    '
    'cboCategory
    '
    Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboCategory.Location = New System.Drawing.Point(104, 144)
    Me.cboCategory.Name = "cboCategory"
    Me.cboCategory.Size = New System.Drawing.Size(192, 21)
    Me.cboCategory.TabIndex = 6
    '
    'cboLength
    '
    Me.cboLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboLength.Location = New System.Drawing.Point(104, 96)
    Me.cboLength.Name = "cboLength"
    Me.cboLength.Size = New System.Drawing.Size(192, 21)
    Me.cboLength.TabIndex = 4
    '
    'dtpTime
    '
    Me.dtpTime.CustomFormat = "h:mm tt"
    Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dtpTime.Location = New System.Drawing.Point(104, 77)
    Me.dtpTime.Name = "dtpTime"
    Me.dtpTime.ShowUpDown = True
    Me.dtpTime.Size = New System.Drawing.Size(112, 20)
    Me.dtpTime.TabIndex = 3
    '
    'cboRoom
    '
    Me.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboRoom.Location = New System.Drawing.Point(104, 56)
    Me.cboRoom.Name = "cboRoom"
    Me.cboRoom.Size = New System.Drawing.Size(192, 21)
    Me.cboRoom.TabIndex = 2
    '
    'dtpDate
    '
    Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpDate.Location = New System.Drawing.Point(104, 32)
    Me.dtpDate.Name = "dtpDate"
    Me.dtpDate.Size = New System.Drawing.Size(112, 20)
    Me.dtpDate.TabIndex = 1
    '
    'cboPatient
    '
    Me.cboPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboPatient.Location = New System.Drawing.Point(104, 8)
    Me.cboPatient.Name = "cboPatient"
    Me.cboPatient.Size = New System.Drawing.Size(192, 21)
    Me.cboPatient.TabIndex = 0
    '
    'Label8
    '
    Me.Label8.Location = New System.Drawing.Point(8, 152)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(88, 16)
    Me.Label8.TabIndex = 6
    Me.Label8.Text = "Category:"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(8, 128)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(88, 16)
    Me.Label5.TabIndex = 5
    Me.Label5.Text = "Provider:"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(8, 104)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(88, 16)
    Me.Label6.TabIndex = 4
    Me.Label6.Text = "Length:"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(8, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(88, 16)
    Me.Label3.TabIndex = 3
    Me.Label3.Text = "Start time:"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(8, 56)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(88, 16)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Room:"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 32)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(88, 16)
    Me.Label2.TabIndex = 1
    Me.Label2.Text = "Date:"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(88, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Patient:"
    '
    'TabPage2
    '
    Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNotes})
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Size = New System.Drawing.Size(304, 174)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Notes"
    '
    'txtNotes
    '
    Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
    Me.txtNotes.Multiline = True
    Me.txtNotes.Name = "txtNotes"
    Me.txtNotes.Size = New System.Drawing.Size(304, 174)
    Me.txtNotes.TabIndex = 7
    Me.txtNotes.Text = ""
    '
    'TabPage3
    '
    Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRemove, Me.cmdAdd, Me.cboADA, Me.lblFee, Me.lstProcedure})
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Size = New System.Drawing.Size(304, 174)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "Procedures"
    '
    'cmdRemove
    '
    Me.cmdRemove.Location = New System.Drawing.Point(232, 136)
    Me.cmdRemove.Name = "cmdRemove"
    Me.cmdRemove.Size = New System.Drawing.Size(64, 24)
    Me.cmdRemove.TabIndex = 11
    Me.cmdRemove.Text = "&Remove"
    '
    'cmdAdd
    '
    Me.cmdAdd.Location = New System.Drawing.Point(160, 136)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(64, 24)
    Me.cmdAdd.TabIndex = 10
    Me.cmdAdd.Text = "&Add"
    '
    'cboADA
    '
    Me.cboADA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboADA.Location = New System.Drawing.Point(16, 112)
    Me.cboADA.Name = "cboADA"
    Me.cboADA.Size = New System.Drawing.Size(280, 21)
    Me.cboADA.TabIndex = 9
    '
    'lblFee
    '
    Me.lblFee.Location = New System.Drawing.Point(16, 80)
    Me.lblFee.Name = "lblFee"
    Me.lblFee.Size = New System.Drawing.Size(280, 16)
    Me.lblFee.TabIndex = 1
    Me.lblFee.Text = "[FEE]"
    '
    'lstProcedure
    '
    Me.lstProcedure.Location = New System.Drawing.Point(16, 8)
    Me.lstProcedure.Name = "lstProcedure"
    Me.lstProcedure.Size = New System.Drawing.Size(280, 69)
    Me.lstProcedure.TabIndex = 8
    '
    'cmdCancel
    '
    Me.cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.Location = New System.Drawing.Point(240, 216)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 13
    Me.cmdCancel.Tag = ""
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdOk
    '
    Me.cmdOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.cmdOk.Location = New System.Drawing.Point(152, 216)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 12
    Me.cmdOk.Text = "&OK"
    '
    'AppointmentPropertiesForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(330, 247)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOk, Me.TabControl1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "AppointmentPropertiesForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Appointment Properties"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage3.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_Appointment As Appointment
  Private PatientCollection As PatientCollection
  Private RoomCollection As RoomCollection
  Private CategoryCollection As CategoryCollection
  Private ADACollection As ADACodeCollection
  Private RunningFees As Decimal = 0

  Public Property Appointment() As Appointment
    Get
      Return m_Appointment
    End Get
    Set(ByVal Value As Appointment)
      m_Appointment = Value

      Try
        If Me.PatientCollection.Contains(Me.Appointment.Text) Then
          Dim patient As PatientItem = Me.PatientCollection(Me.Appointment.Text)
          cboPatient.SelectedIndex = patient.Index
        End If

        dtpDate.Value = Me.Appointment.StartDate
        dtpTime.Value = Me.Appointment.StartDateTime
        cboLength.SelectedIndex = (Me.Appointment.Length \ 10) - 1
        txtNotes.Text = Me.Appointment.Notes

        If Not (Me.Appointment.Room Is Nothing) Then
          Me.cboRoom.SelectedIndex = Me.RoomCollection.IndexOf(Me.Appointment.Room)
        End If

        'TODO - Providers

        If Me.Appointment.CategoryList.Count > 0 Then
          cboCategory.Text = Me.Appointment.CategoryList(0).Text
        End If

        Call LoadProcedures()
        Call AddFee(0)

      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Set
  End Property

  Public Sub Initialize(ByVal patients As PatientCollection, ByVal rooms As RoomCollection, ByVal categories As CategoryCollection, ByVal adaCodes As ADACodeCollection)

    Try

      Me.PatientCollection = patients
      Me.RoomCollection = rooms
      Me.CategoryCollection = categories
      Me.ADACollection = adaCodes

      'Load the patient combo
      Dim patient As PatientItem
      For Each patient In patients
        Call cboPatient.Items.Add(patient.LName & ", " & patient.FName)
      Next

      'Load the room combo
      Dim room As Room
      For Each room In rooms
        Call cboRoom.Items.Add(room.Text)
      Next

      'Load the category combo
      Dim category As Category
      For Each category In categories
        Call cboCategory.Items.Add(category.Text)
      Next

      'Load the ADA combo
      Dim ada As ADACodeItem
      For Each ada In adaCodes
        Call cboADA.Items.Add(ada.Text)
      Next

      'Initialize the procedure stuff
      If cboADA.Items.Count = 0 Then
        cmdAdd.Enabled = False
      Else
        cmdAdd.Enabled = True
        cboADA.SelectedIndex = 0
      End If

      'Load the length combo
      Dim ii As Integer
      For ii = 1 To 24
        Call cboLength.Items.Add((ii * 10).ToString & " minutes")
      Next

    Catch ex As Exception
      Call SetErr(ex)
    End Try


  End Sub

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

    Try

      'Verify
      If cboPatient.SelectedIndex = -1 Then
        Call MsgBox("A patient must be specified!", MsgBoxStyle.Exclamation, "Error!")
        Return
      End If

      If cboRoom.SelectedIndex = -1 Then
        Call MsgBox("A room must be specified!", MsgBoxStyle.Exclamation, "Error!")
        Return
      End If

      If cboLength.SelectedIndex = -1 Then
        Call MsgBox("An appointment length must be specified!", MsgBoxStyle.Exclamation, "Error!")
        Return
      End If

      If cboCategory.SelectedIndex = -1 Then
        Call MsgBox("A category must be specified!", MsgBoxStyle.Exclamation, "Error!")
        Return
      End If

      'Save the details
      Me.Appointment.Text = Me.PatientCollection(cboPatient.SelectedIndex).Key
      Me.Appointment.StartDate = dtpDate.Value
      Me.Appointment.Room = Me.RoomCollection(cboRoom.SelectedIndex)
      Me.Appointment.StartTime = dtpTime.Value
      Me.Appointment.Length = (cboLength.SelectedIndex + 1) * 10
      Me.Appointment.Notes = txtNotes.Text
      'TODO - Providers
      Me.Appointment.CategoryList.Clear()
      Me.Appointment.CategoryList.Add(Me.CategoryCollection(cboCategory.SelectedIndex))
      Call SaveProcedures()

      Me.Close()

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Me.Close()
  End Sub

  Private Sub cboPatient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPatient.SelectedIndexChanged
    Me.cmdOk.Enabled = CheckOkEnabled()
  End Sub

  Private Sub cboCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.SelectedIndexChanged
    Me.cmdOk.Enabled = CheckOkEnabled()
  End Sub

  Private Sub cboRoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoom.SelectedIndexChanged
    Me.cmdOk.Enabled = CheckOkEnabled()
  End Sub

  Private Sub cboLength_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLength.SelectedIndexChanged
    Me.cmdOk.Enabled = CheckOkEnabled()
  End Sub

  Private Sub AppointmentPropertiesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.cmdOk.Enabled = CheckOkEnabled()
  End Sub

  Private Function CheckOkEnabled() As Boolean

    Try
      Return (Me.cboCategory.SelectedIndex <> -1) AndAlso (Me.cboLength.SelectedIndex <> -1) AndAlso (Me.cboPatient.SelectedIndex <> -1) AndAlso (Me.cboRoom.SelectedIndex <> -1)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

    Try
      If cboADA.SelectedIndex <> -1 Then
        Call AddFee(Me.ADACollection(cboADA.SelectedIndex).Price)
        lstProcedure.Items.Add(cboADA.SelectedItem)
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click

    Try
      'Remove the selected procedure
      If Me.lstProcedure.SelectedIndex <> -1 Then
        If MsgBox("Do you wish to remove the selected procedure? ", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Remove?") = MsgBoxResult.Yes Then
          Call AddFee(-Me.ADACollection(Me.cboADA.Items.IndexOf(lstProcedure.SelectedItem)).Price)
          Call Me.lstProcedure.Items.RemoveAt(Me.lstProcedure.SelectedIndex)
          'Default to the first item
          If Me.lstProcedure.Items.Count > 0 Then Me.lstProcedure.SelectedIndex = 0
        End If
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub AddFee(ByVal fee As Decimal)
    Try
      RunningFees += fee
      lblFee.Text = "Total Fees: " & RunningFees.ToString("$0.00")
    Catch ex As Exception
      Call SetErr(ex)
    End Try
  End Sub

  Private Sub LoadProcedures()

    Try

      If Me.Appointment.PropertyItemCollection.Contains("Procedures") Then
        Dim s As String = Me.Appointment.PropertyItemCollection("Procedures").Setting
        If s Is Nothing Then s = ""
        Dim arrS As String() = s.Split("|".Chars(0))
        Dim propertyItem As PropertyItem
        For Each s In arrS
          If Me.ADACollection.Contains(s) Then
            Call lstProcedure.Items.Add(Me.ADACollection(s).Text)
            Call AddFee(Me.ADACollection(s).Price)
          End If
        Next
      End If

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  Private Sub SaveProcedures()

    Dim o As Object
    Dim ii As Integer
    Dim text As String

    Try
      'Remove the Procedure item if one does exists
      If Me.Appointment.PropertyItemCollection.Contains("Procedures") Then
        Me.Appointment.PropertyItemCollection.Remove("Procedures")
      End If

      For ii = 0 To lstProcedure.Items.Count - 1
        o = lstProcedure.Items(ii)
        Dim index As Integer = Me.cboADA.Items.IndexOf(o)
        text = text & Me.ADACollection(index).Key & "|"
      Next

      Call Me.Appointment.PropertyItemCollection.Add("", "Procedures", text)

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

End Class
