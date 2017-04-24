Option Strict On
Option Explicit On 

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
  Friend WithEvents cmdAutoSizeRow As System.Windows.Forms.Button
  Friend WithEvents cmdAutoSizeCol As System.Windows.Forms.Button
  Friend WithEvents cmdAutoSizeRowCol As System.Windows.Forms.Button
  Friend WithEvents cmdSelector As System.Windows.Forms.Button
  Friend WithEvents cmdColors As System.Windows.Forms.Button
  Friend WithEvents cmdViewmode As System.Windows.Forms.Button
  Friend WithEvents cmdIcons As System.Windows.Forms.Button
  Friend WithEvents cmdUserDrawn As System.Windows.Forms.Button
  Friend WithEvents cmdXML As System.Windows.Forms.Button
  Friend WithEvents cmdPrint As System.Windows.Forms.Button
	Friend WithEvents cmdRecurrence As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.cmdAutoSizeRow = New System.Windows.Forms.Button
		Me.cmdAutoSizeCol = New System.Windows.Forms.Button
		Me.cmdAutoSizeRowCol = New System.Windows.Forms.Button
		Me.cmdSelector = New System.Windows.Forms.Button
		Me.cmdColors = New System.Windows.Forms.Button
		Me.cmdViewmode = New System.Windows.Forms.Button
		Me.cmdIcons = New System.Windows.Forms.Button
		Me.cmdUserDrawn = New System.Windows.Forms.Button
		Me.cmdXML = New System.Windows.Forms.Button
		Me.cmdPrint = New System.Windows.Forms.Button
		Me.cmdRecurrence = New System.Windows.Forms.Button
		Me.SuspendLayout()
		'
		'cmdAutoSizeRow
		'
		Me.cmdAutoSizeRow.Location = New System.Drawing.Point(8, 8)
		Me.cmdAutoSizeRow.Name = "cmdAutoSizeRow"
		Me.cmdAutoSizeRow.Size = New System.Drawing.Size(128, 24)
		Me.cmdAutoSizeRow.TabIndex = 0
		Me.cmdAutoSizeRow.Text = "AutoSize Row"
		'
		'cmdAutoSizeCol
		'
		Me.cmdAutoSizeCol.Location = New System.Drawing.Point(8, 40)
		Me.cmdAutoSizeCol.Name = "cmdAutoSizeCol"
		Me.cmdAutoSizeCol.Size = New System.Drawing.Size(128, 24)
		Me.cmdAutoSizeCol.TabIndex = 1
		Me.cmdAutoSizeCol.Text = "AutoSize Column"
		'
		'cmdAutoSizeRowCol
		'
		Me.cmdAutoSizeRowCol.Location = New System.Drawing.Point(8, 72)
		Me.cmdAutoSizeRowCol.Name = "cmdAutoSizeRowCol"
		Me.cmdAutoSizeRowCol.Size = New System.Drawing.Size(128, 24)
		Me.cmdAutoSizeRowCol.TabIndex = 2
		Me.cmdAutoSizeRowCol.Text = "AutoSize Row/Col"
		'
		'cmdSelector
		'
		Me.cmdSelector.Location = New System.Drawing.Point(8, 104)
		Me.cmdSelector.Name = "cmdSelector"
		Me.cmdSelector.Size = New System.Drawing.Size(128, 24)
		Me.cmdSelector.TabIndex = 3
		Me.cmdSelector.Text = "Selector"
		'
		'cmdColors
		'
		Me.cmdColors.Location = New System.Drawing.Point(8, 136)
		Me.cmdColors.Name = "cmdColors"
		Me.cmdColors.Size = New System.Drawing.Size(128, 24)
		Me.cmdColors.TabIndex = 4
		Me.cmdColors.Text = "Colors"
		'
		'cmdViewmode
		'
		Me.cmdViewmode.Location = New System.Drawing.Point(8, 168)
		Me.cmdViewmode.Name = "cmdViewmode"
		Me.cmdViewmode.Size = New System.Drawing.Size(128, 24)
		Me.cmdViewmode.TabIndex = 5
		Me.cmdViewmode.Text = "Viewmode"
		'
		'cmdIcons
		'
		Me.cmdIcons.Location = New System.Drawing.Point(8, 200)
		Me.cmdIcons.Name = "cmdIcons"
		Me.cmdIcons.Size = New System.Drawing.Size(128, 24)
		Me.cmdIcons.TabIndex = 6
		Me.cmdIcons.Text = "Appointment Icons"
		'
		'cmdUserDrawn
		'
		Me.cmdUserDrawn.Location = New System.Drawing.Point(9, 232)
		Me.cmdUserDrawn.Name = "cmdUserDrawn"
		Me.cmdUserDrawn.Size = New System.Drawing.Size(128, 24)
		Me.cmdUserDrawn.TabIndex = 7
		Me.cmdUserDrawn.Text = "User-Drawn"
		'
		'cmdXML
		'
		Me.cmdXML.Location = New System.Drawing.Point(8, 264)
		Me.cmdXML.Name = "cmdXML"
		Me.cmdXML.Size = New System.Drawing.Size(128, 24)
		Me.cmdXML.TabIndex = 8
		Me.cmdXML.Text = "XML"
		'
		'cmdPrint
		'
		Me.cmdPrint.Location = New System.Drawing.Point(9, 296)
		Me.cmdPrint.Name = "cmdPrint"
		Me.cmdPrint.Size = New System.Drawing.Size(128, 24)
		Me.cmdPrint.TabIndex = 9
		Me.cmdPrint.Text = "Print"
		'
		'cmdRecurrence
		'
		Me.cmdRecurrence.Location = New System.Drawing.Point(9, 328)
		Me.cmdRecurrence.Name = "cmdRecurrence"
		Me.cmdRecurrence.Size = New System.Drawing.Size(128, 24)
		Me.cmdRecurrence.TabIndex = 10
		Me.cmdRecurrence.Text = "Recurrence"
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(146, 359)
		Me.Controls.Add(Me.cmdRecurrence)
		Me.Controls.Add(Me.cmdPrint)
		Me.Controls.Add(Me.cmdXML)
		Me.Controls.Add(Me.cmdUserDrawn)
		Me.Controls.Add(Me.cmdIcons)
		Me.Controls.Add(Me.cmdViewmode)
		Me.Controls.Add(Me.cmdColors)
		Me.Controls.Add(Me.cmdSelector)
		Me.Controls.Add(Me.cmdAutoSizeRowCol)
		Me.Controls.Add(Me.cmdAutoSizeCol)
		Me.Controls.Add(Me.cmdAutoSizeRow)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "MainForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Gravitybox.NET"
		Me.ResumeLayout(False)

	End Sub

#End Region

  Private Sub cmdAutoSizeRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoSizeRow.Click
    Dim F As New AutoSizeForm()
    F.lblDescription.Text = "Resize this screen and notice that the rows stretch to fit the schedule height."
    F.Schedule1.RowHeader.AutoFit = True
    Call F.ShowDialog()
  End Sub

  Private Sub cmdAutoSizeCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoSizeCol.Click
    Dim F As New AutoSizeForm()
    F.lblDescription.Text = "Resize this screen and notice that the columns stretch to fit the schedule width."
    F.Schedule1.ColumnHeader.AutoFit = True
    Call F.ShowDialog()
  End Sub

  Private Sub cmdAutoSizeRowCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAutoSizeRowCol.Click
    Dim F As New AutoSizeForm()
    F.lblDescription.Text = "Resize this screen and notice that the rows and columns stretch to fill the schedule."
    F.Schedule1.RowHeader.AutoFit = True
    F.Schedule1.ColumnHeader.AutoFit = True
    Call F.ShowDialog()
  End Sub

  Private Sub cmdSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelector.Click
    Dim F As New SelectorForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdColors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColors.Click
    Dim F As New ColorForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdViewmode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdViewmode.Click
    Dim F As New ViewmodeForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdIcons.Click
    Dim F As New IconForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdUserDrawn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUserDrawn.Click
    Dim F As New UserDrawnForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdXML.Click
    Dim F As New XMLForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim F As New PrintForm()
    Call F.ShowDialog()
  End Sub

	Private Sub cmdRecurrence_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecurrence.Click
		Dim F As New RecurrenceForm
		F.ShowDialog()
	End Sub

End Class
