Imports Gravitybox.Objects

Public Class Form1
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
  Friend WithEvents ScheduleDomainController1 As Gravitybox.Controls.ScheduleDomainController
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents cmdLoad As System.Windows.Forms.Button
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmdCustom As System.Windows.Forms.Button
  Friend WithEvents cboRoom As System.Windows.Forms.ComboBox
  Friend WithEvents WebServiceController1 As Gravitybox.Controls.WebServiceController
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents menuFile As System.Windows.Forms.MenuItem
  Friend WithEvents menuExit As System.Windows.Forms.MenuItem
  Friend WithEvents menuProvider As System.Windows.Forms.MenuItem
  Friend WithEvents menuCategory As System.Windows.Forms.MenuItem
  Friend WithEvents cmdRemoveAll As System.Windows.Forms.Button
  Friend WithEvents cmdPopup As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.ScheduleDomainController1 = New Gravitybox.Controls.ScheduleDomainController
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.cmdRemoveAll = New System.Windows.Forms.Button
    Me.cboRoom = New System.Windows.Forms.ComboBox
    Me.cmdCustom = New System.Windows.Forms.Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.cmdSave = New System.Windows.Forms.Button
    Me.cmdLoad = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.WebServiceController1 = New Gravitybox.Controls.WebServiceController
    Me.MainMenu1 = New System.Windows.Forms.MainMenu
    Me.menuFile = New System.Windows.Forms.MenuItem
    Me.menuProvider = New System.Windows.Forms.MenuItem
    Me.menuCategory = New System.Windows.Forms.MenuItem
    Me.menuExit = New System.Windows.Forms.MenuItem
    Me.cmdPopup = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'ScheduleDomainController1
    '
    Me.ScheduleDomainController1.ConnectionString = ""
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.cmdPopup)
    Me.Panel1.Controls.Add(Me.cmdRemoveAll)
    Me.Panel1.Controls.Add(Me.cboRoom)
    Me.Panel1.Controls.Add(Me.cmdCustom)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.cmdSave)
    Me.Panel1.Controls.Add(Me.cmdLoad)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 281)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(680, 40)
    Me.Panel1.TabIndex = 0
    '
    'cmdRemoveAll
    '
    Me.cmdRemoveAll.Location = New System.Drawing.Point(280, 8)
    Me.cmdRemoveAll.Name = "cmdRemoveAll"
    Me.cmdRemoveAll.Size = New System.Drawing.Size(56, 24)
    Me.cmdRemoveAll.TabIndex = 5
    Me.cmdRemoveAll.Text = "Clear"
    '
    'cboRoom
    '
    Me.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboRoom.Location = New System.Drawing.Point(392, 8)
    Me.cboRoom.Name = "cboRoom"
    Me.cboRoom.Size = New System.Drawing.Size(112, 21)
    Me.cboRoom.TabIndex = 4
    '
    'cmdCustom
    '
    Me.cmdCustom.Location = New System.Drawing.Point(144, 8)
    Me.cmdCustom.Name = "cmdCustom"
    Me.cmdCustom.Size = New System.Drawing.Size(56, 24)
    Me.cmdCustom.TabIndex = 3
    Me.cmdCustom.Text = "Custom"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(512, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(136, 16)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Label1"
    '
    'cmdSave
    '
    Me.cmdSave.Location = New System.Drawing.Point(80, 8)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(56, 24)
    Me.cmdSave.TabIndex = 1
    Me.cmdSave.Text = "Save"
    '
    'cmdLoad
    '
    Me.cmdLoad.Location = New System.Drawing.Point(16, 8)
    Me.cmdLoad.Name = "cmdLoad"
    Me.cmdLoad.Size = New System.Drawing.Size(56, 24)
    Me.cmdLoad.TabIndex = 0
    Me.cmdLoad.Text = "Load"
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(212, Byte), CType(208, Byte), CType(200, Byte))
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.Color.Gray
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.Schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.Schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(212, Byte), CType(208, Byte), CType(200, Byte))
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.Color.Gray
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(680, 281)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 1
    '
    'WebServiceController1
    '
    Me.WebServiceController1.AccountId = ""
    Me.WebServiceController1.WebServiceURL = "http://localhost/"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile})
    '
    'menuFile
    '
    Me.menuFile.Index = 0
    Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuProvider, Me.menuCategory, Me.menuExit})
    Me.menuFile.Text = "&File"
    '
    'menuProvider
    '
    Me.menuProvider.Index = 0
    Me.menuProvider.Text = "&Provider"
    '
    'menuCategory
    '
    Me.menuCategory.Index = 1
    Me.menuCategory.Text = "&Category"
    '
    'menuExit
    '
    Me.menuExit.Index = 2
    Me.menuExit.Text = "E&xit"
    '
    'cmdPopup
    '
    Me.cmdPopup.Location = New System.Drawing.Point(208, 8)
    Me.cmdPopup.Name = "cmdPopup"
    Me.cmdPopup.Size = New System.Drawing.Size(56, 24)
    Me.cmdPopup.TabIndex = 6
    Me.cmdPopup.Text = "Popup"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(680, 321)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.Panel1)
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Const AccountId As String = "00000000-0000-0000-0000-000000000000" 'Home
	Private Const COMPUTERNAME As String = "(local)"
	Private Const PORTNUMBER As String = "80"

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim i As Integer = Color.Black.ToArgb
		Dim c As Color = Color.FromArgb(i)

    'Make schedule pretty6
    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
    Schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    Schedule1.SetMinMaxDate(Now, Now.AddDays(10))
    Schedule1.Visibility.ShowTime(#4:00:00 PM#)
    Schedule1.RowHeader.Size = 20
    Schedule1.EventHeader.AllowExpand = True

    'Schedule1.ProviderCollection.Add("", "Provider1")
    'Schedule1.ProviderCollection.Add("", "Provider2" & vbCrLf & "XXX")
    'Schedule1.ProviderCollection.Add("", "Provider3")

    'Schedule1.RoomCollection.Add("", "Room1")
    'Schedule1.RoomCollection.Add("", "Room2" & vbCrLf & "XXX")
    'Schedule1.RoomCollection.Add("", "Room3")

    'Schedule1.NoDropAreaCollection.Add("", Color.Red, #10:00:00 AM#, 60)

  End Sub

	Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click

    Dim startTime As Date = Now
    Debug.WriteLine("Load Start:" & startTime.ToString)
    Me.Enabled = False
		Schedule1.MultiSelect = True

#If LOCALCONNECT = 1 Then
		ScheduleDomainController1.ConnectionString = "data source=" & COMPUTERNAME & ";database=Gravitybox;uid=sa;pwd=;"

		''TEMPTEMPTEMPTEMPTEMP
		'Dim ds As DataSet = ScheduleDomainController1.GetScheduleDataSet(AccountId)
		'Dim dv As New DataView(ds.Tables("Appointment"))
		'ds.Tables.Remove("Appointment")
		'Schedule1.DataBindings.AppointmentBinding.DataSource = dv
		'Schedule1.DataSource = ds
		'Schedule1.Bind()
		''TEMPTEMPTEMPTEMPTEMP

		Schedule1.DataSource = ScheduleDomainController1.GetScheduleDataSet(AccountId)
		Schedule1.Bind()
#Else
    WebServiceController1.WebServiceURL = "http://" & COMPUTERNAME & ":" & PORTNUMBER & "/GravityboxWebServices/EnterpriseServices.asmx"
    WebServiceController1.FillAppointments()
    Schedule1.DataSource = WebServiceController1.DataSource
    Schedule1.Bind()
#End If

    Me.Enabled = True
    Dim endTime As Date = Now
    Debug.WriteLine("Load End:" & endTime & "   duration:" & endTime.Subtract(startTime).TotalMilliseconds)

  End Sub

  Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    Me.Enabled = False
    Schedule1.RoomCollection.Add("", "Room 1")

    Try
#If LOCALCONNECT = 1 Then
      ScheduleDomainController1.UpdateData(AccountId, Schedule1.DataSource)
      Schedule1.DataSource = ScheduleDomainController1.GetScheduleDataSet(AccountId)
      Schedule1.Bind()
#Else
    WebServiceController1.WebServiceURL = "http://" & COMPUTERNAME & ":" & PORTNUMBER & "/GravityboxWebServices/EnterpriseServices.asmx"
    WebServiceController1.UpdateData()
    Schedule1.DataSource = Nothing
    Schedule1.Bind()

    'Reload
    WebServiceController1.FillAppointments()
    Schedule1.DataSource = WebServiceController1.DataSource
    Schedule1.Bind()
#End If

      Beep()

    Catch ex As Exception
      SetErr(ex)
    Finally
      Me.Enabled = True
    End Try

  End Sub

  Private Sub cmdCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustom.Click

    For Each appt As Appointment In Me.Schedule1.AppointmentCollection
      Debug.WriteLine(appt.StartDate.ToShortDateString)
    Next
    Debug.WriteLine("")
    Debug.WriteLine("")

  End Sub

  Private Sub Schedule1_AfterPropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles Schedule1.AfterPropertyDialog

    Dim appt As Appointment = CType(e.BaseObject, Appointment)
    Dim ap As AppointmentAppearance = appt.Appearance
    If Schedule1.AppearanceCollection.Count = 0 Then
      Schedule1.AppearanceCollection.Add(ap)
      ap.BackColor = Color.Yellow
    Else
      appt.Appearance = Schedule1.AppearanceCollection(0)
    End If

  End Sub

  Private Sub menuProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuProvider.Click
    Schedule1.Dialogs.ShowProviderConfiguration()
  End Sub

  Private Sub menuCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCategory.Click
    Schedule1.Dialogs.ShowCategoryConfiguration()
  End Sub

  Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
    Me.Close()
  End Sub

  Private Sub SetErr(ByVal ex As Exception)
    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Error!")
  End Sub

  Private Sub cmdRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveAll.Click

    For ii As Integer = Schedule1.AppointmentCollection.Count - 1 To 0 Step -1
      Schedule1.AppointmentCollection.RemoveAt(ii)
    Next

  End Sub

  Private Sub cmdPopup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPopup.Click
    MsgBox(Schedule1.ResourceCollection.Count)
  End Sub

End Class
