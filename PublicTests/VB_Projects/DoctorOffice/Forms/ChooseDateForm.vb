Option Strict On
Option Explicit On 

Imports DoctorOfficeAPI.Objects

Public Class ChooseDateForm
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
  Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.dtpDate = New System.Windows.Forms.DateTimePicker()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Date:"
    '
    'dtpDate
    '
    Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpDate.Location = New System.Drawing.Point(64, 8)
    Me.dtpDate.Name = "dtpDate"
    Me.dtpDate.Size = New System.Drawing.Size(104, 20)
    Me.dtpDate.TabIndex = 1
    '
    'cmdOK
    '
    Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.cmdOK.Location = New System.Drawing.Point(176, 8)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(64, 24)
    Me.cmdOK.TabIndex = 2
    Me.cmdOK.Text = "&OK"
    '
    'cmdCancel
    '
    Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdCancel.Location = New System.Drawing.Point(248, 8)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(64, 24)
    Me.cmdCancel.TabIndex = 3
    Me.cmdCancel.Text = "&Cancel"
    '
    'ChooseDateForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(314, 39)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOK, Me.dtpDate, Me.Label1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "ChooseDateForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Choose Date"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Dim m_ReturnValues As ReturnValues

  Public Property ReturnValues() As ReturnValues

    Get
      Return m_ReturnValues
    End Get
    Set(ByVal Value As ReturnValues)
      m_ReturnValues = Value
      Call ReturnValues.Add(False)
      Call ReturnValues.Add(Globals.DefaultNoDate.ToShortDateString)
    End Set

  End Property

  Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

    Try
      ReturnValues(0).Setting = True.ToString
      ReturnValues(1).Setting = dtpDate.Value.ToShortDateString
      Call Me.Close()

    Catch
      Throw
    End Try

  End Sub

  Private Sub ChooseDateForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    dtpDate.Value = Now
  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Me.Close()
  End Sub

End Class
