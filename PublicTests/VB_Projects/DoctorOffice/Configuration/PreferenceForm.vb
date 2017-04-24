Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class PreferenceForm
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
  Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
  Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents cmdOk As System.Windows.Forms.Button
  Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.dtpStart = New System.Windows.Forms.DateTimePicker()
    Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
    Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.cmdOk = New System.Windows.Forms.Button()
    Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 16)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Start Time:"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(72, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "End Time:"
    '
    'dtpStart
    '
    Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Time
    Me.dtpStart.Location = New System.Drawing.Point(96, 16)
    Me.dtpStart.Name = "dtpStart"
    Me.dtpStart.ShowUpDown = True
    Me.dtpStart.Size = New System.Drawing.Size(104, 20)
    Me.dtpStart.TabIndex = 6
    '
    'dtpEnd
    '
    Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time
    Me.dtpEnd.Location = New System.Drawing.Point(96, 40)
    Me.dtpEnd.Name = "dtpEnd"
    Me.dtpEnd.ShowUpDown = True
    Me.dtpEnd.Size = New System.Drawing.Size(104, 20)
    Me.dtpEnd.TabIndex = 7
    '
    'ColorDialog1
    '
    Me.ColorDialog1.AnyColor = True
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(16, 80)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(72, 16)
    Me.Label3.TabIndex = 10
    Me.Label3.Text = "Schedule:"
    '
    'cmdCancel
    '
    Me.cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdCancel.Location = New System.Drawing.Point(222, 224)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
    Me.cmdCancel.TabIndex = 5
    Me.cmdCancel.Tag = ""
    Me.cmdCancel.Text = "&Cancel"
    '
    'cmdOk
    '
    Me.cmdOk.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.cmdOk.Location = New System.Drawing.Point(134, 224)
    Me.cmdOk.Name = "cmdOk"
    Me.cmdOk.Size = New System.Drawing.Size(80, 24)
    Me.cmdOk.TabIndex = 4
    Me.cmdOk.Text = "&OK"
    '
    'PropertyGrid1
    '
    Me.PropertyGrid1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right)
    Me.PropertyGrid1.CommandsVisibleIfAvailable = True
    Me.PropertyGrid1.HelpVisible = False
    Me.PropertyGrid1.LargeButtons = False
    Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
    Me.PropertyGrid1.Location = New System.Drawing.Point(8, 8)
    Me.PropertyGrid1.Name = "PropertyGrid1"
    Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
    Me.PropertyGrid1.Size = New System.Drawing.Size(294, 208)
    Me.PropertyGrid1.TabIndex = 6
    Me.PropertyGrid1.Text = "PropertyGrid"
    Me.PropertyGrid1.ToolbarVisible = False
    Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
    Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
    '
    'PreferenceForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(312, 255)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PropertyGrid1, Me.cmdCancel, Me.cmdOk})
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(192, 208)
    Me.Name = "PreferenceForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Preferences"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_Preferences As New Preferences()
  Private WorkingPreferences As Preferences

  Public Property Preferences() As Preferences
    Get
      Return m_Preferences
    End Get
    Set(ByVal Value As Preferences)
      m_Preferences = Value
      WorkingPreferences = CType(CloneObject(Me.Preferences), Preferences)
      PropertyGrid1.SelectedObject = WorkingPreferences
    End Set
  End Property

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    ParOut(0).Setting = True
    ParOut.Add(CType(CloneObject(WorkingPreferences), Preferences))
    Call Me.Close()
  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Call Me.Close()
  End Sub

  Private Sub PreferenceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Call ParOut.Clear()
    Call ParOut.Add(False)
  End Sub

End Class
