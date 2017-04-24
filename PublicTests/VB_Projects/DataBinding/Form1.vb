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
	Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
	Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
	Friend WithEvents menuFile As System.Windows.Forms.MenuItem
	Friend WithEvents menuFileExit As System.Windows.Forms.MenuItem
	Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
	Friend WithEvents menuFileConnection As System.Windows.Forms.MenuItem
	Friend WithEvents menuFileSynchronize As System.Windows.Forms.MenuItem
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.ScheduleDomainController1 = New Gravitybox.Controls.ScheduleDomainController
		Me.Schedule1 = New Gravitybox.Controls.Schedule
		Me.MainMenu1 = New System.Windows.Forms.MainMenu
		Me.menuFile = New System.Windows.Forms.MenuItem
		Me.menuFileExit = New System.Windows.Forms.MenuItem
		Me.MenuItem3 = New System.Windows.Forms.MenuItem
		Me.menuFileConnection = New System.Windows.Forms.MenuItem
		Me.menuFileSynchronize = New System.Windows.Forms.MenuItem
		Me.SuspendLayout()
		'
		'ScheduleDomainController1
		'
		Me.ScheduleDomainController1.ConnectionString = ""
		'
		'Schedule1
		'
		Me.Schedule1.AllowDrop = True
		Me.Schedule1.Appearance.FontSize = 10.0!
		Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
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
		Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
		Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Schedule1.RowHeader.Size = 30
		Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
		Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
		Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
		Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
		Me.Schedule1.Selector.Appearance.FontSize = 10.0!
		Me.Schedule1.Size = New System.Drawing.Size(512, 349)
		Me.Schedule1.StartTime = New Date(CType(0, Long))
		Me.Schedule1.TabIndex = 0
		'
		'MainMenu1
		'
		Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile})
		'
		'menuFile
		'
		Me.menuFile.Index = 0
		Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFileConnection, Me.menuFileSynchronize, Me.MenuItem3, Me.menuFileExit})
		Me.menuFile.Text = "&File"
		'
		'menuFileExit
		'
		Me.menuFileExit.Index = 3
		Me.menuFileExit.Text = "E&xit"
		'
		'MenuItem3
		'
		Me.MenuItem3.Index = 2
		Me.MenuItem3.Text = "-"
		'
		'menuFileConnection
		'
		Me.menuFileConnection.Index = 0
		Me.menuFileConnection.Text = "&Connection"
		'
		'menuFileSynchronize
		'
		Me.menuFileSynchronize.Index = 1
		Me.menuFileSynchronize.Text = "&Synchronize"
		'
		'Form1
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(512, 349)
		Me.Controls.Add(Me.Schedule1)
		Me.Menu = Me.MainMenu1
		Me.Name = "Form1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Gravitybox Software"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private _connectionString As String = "data source=localhost;database=Gravitybox;uid=sa;pwd=;"
	Private AccountId As String = "00000000-0000-0000-0000-000000000000"
	Private ScheduleDataSet As DataSet = Nothing
	Private _changed As Boolean = False

	Public Property ConnectionString() As String
		Get
			Return _connectionString
		End Get
		Set(ByVal Value As String)
			_connectionString = Value
			Me.DatabaseConnect()
		End Set
	End Property

	Public Property Changed() As Boolean
		Get
			Return _changed
		End Get
		Set(ByVal Value As Boolean)
			_changed = Value
			Me.Text = "Gravitybox Software"
			If Me.Changed Then
				Me.Text += "*"
			End If
		End Set
	End Property

	Public Sub DatabaseConnect()

		Me.ScheduleDomainController1.ConnectionString = ConnectionString
		If Not (ScheduleDataSet Is Nothing) Then
			Me.ScheduleDomainController1.UpdateData(AccountId, ScheduleDataSet)
		End If
		ScheduleDataSet = Me.ScheduleDomainController1.GetScheduleDataSet(AccountId)
		Schedule1.DataSource = ScheduleDataSet
		Schedule1.Bind()
		Changed = False

	End Sub

	Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

		Schedule1.StartTime = #8:00:00 AM#
		Schedule1.DayLength = 10
		Schedule1.SetMinMaxDate(#1/1/2005#, #1/31/2005#)

		'Create a lunch area
		Dim area As Gravitybox.Objects.ScheduleArea = Schedule1.ColoredAreaCollection.Add("", Color.LightSalmon, #12:00:00 PM#, 60)
		area.Appearance.BorderWidth = 0
		area.Text = "Lunch"

		Me.DatabaseConnect()

  End Sub

  Private Sub menuFileConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileConnection.Click

    'Reset connection string 
    Dim s = InputBox("Enter the database connection string.", "Connection String", ConnectionString)
    If s <> "" Then
      Me.ConnectionString = s
    End If

  End Sub

  Private Sub menuFileSynchronize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileSynchronize.Click
    'Synchronize with the database
    Me.DatabaseConnect()
  End Sub

  Private Sub menuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuFileExit.Click
    Me.Close()
  End Sub

  Private Sub Schedule1_DataSourceUpdated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Schedule1.DataSourceUpdated
    'The schedule has changed so we must remember to synchronize
    Changed = True
  End Sub

  Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    'Prompt to save if necessary
    If Me.Changed Then
      If MsgBox("Do you wish to synchronize with the database.", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
        Me.DatabaseConnect()
      End If
    End If

  End Sub

End Class
