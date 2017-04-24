Option Strict On
Option Explicit On 

Public Class DateForm
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
  Friend WithEvents cmdOK As System.Windows.Forms.Button
  Friend WithEvents cmdCancel As System.Windows.Forms.Button
  Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.dtpDate = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmdOK = New System.Windows.Forms.Button()
    Me.cmdCancel = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'dtpDate
    '
    Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
    Me.dtpDate.Location = New System.Drawing.Point(72, 8)
    Me.dtpDate.Name = "dtpDate"
    Me.dtpDate.Size = New System.Drawing.Size(112, 20)
    Me.dtpDate.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(48, 16)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Date:"
    '
    'cmdOK
    '
    Me.cmdOK.Location = New System.Drawing.Point(32, 40)
    Me.cmdOK.Name = "cmdOK"
    Me.cmdOK.Size = New System.Drawing.Size(72, 24)
    Me.cmdOK.TabIndex = 1
    Me.cmdOK.Text = "&OK"
    Me.cmdOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    '
    'cmdCancel
    '
    Me.cmdCancel.Location = New System.Drawing.Point(112, 40)
    Me.cmdCancel.Name = "cmdCancel"
    Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
    Me.cmdCancel.TabIndex = 2
    Me.cmdCancel.Text = "&Cancel"
    '
    'DateForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(194, 71)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOK, Me.Label1, Me.dtpDate})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "DateForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Choose Date"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private m_IsSet As Boolean
  Private m_DateValue As Date

  Public Property IsSet() As Boolean
    Get
      Return m_IsSet
    End Get
    Set(ByVal Value As Boolean)
      m_IsSet = Value
    End Set
  End Property

  Public Property DateValue() As Date
    Get
      Return m_DateValue
    End Get
    Set(ByVal Value As Date)
      m_DateValue = Value
    End Set
  End Property

  Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
    Me.IsSet = True
    Me.DateValue = dtpDate.Value
    Call Me.Close()
  End Sub

  Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    Me.IsSet = False
    Call Me.Close()
  End Sub

End Class
