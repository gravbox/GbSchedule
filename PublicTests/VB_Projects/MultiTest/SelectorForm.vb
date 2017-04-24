Option Strict On
Option Explicit On 

Public Class SelectorForm
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
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents cmdSetSelector As System.Windows.Forms.Button
  Friend WithEvents cmdAllowSelector As System.Windows.Forms.Button
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.lblDescription = New System.Windows.Forms.Label
    Me.cmdSetSelector = New System.Windows.Forms.Button
    Me.cmdAllowSelector = New System.Windows.Forms.Button
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'lblDescription
    '
    Me.lblDescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblDescription.Location = New System.Drawing.Point(4, 426)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(384, 24)
    Me.lblDescription.TabIndex = 8
    Me.lblDescription.Text = "XXX"
    '
    'cmdSetSelector
    '
    Me.cmdSetSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdSetSelector.Location = New System.Drawing.Point(500, 426)
    Me.cmdSetSelector.Name = "cmdSetSelector"
    Me.cmdSetSelector.Size = New System.Drawing.Size(96, 24)
    Me.cmdSetSelector.TabIndex = 7
    Me.cmdSetSelector.Text = "Set Selector"
    '
    'cmdAllowSelector
    '
    Me.cmdAllowSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdAllowSelector.Location = New System.Drawing.Point(396, 426)
    Me.cmdAllowSelector.Name = "cmdAllowSelector"
    Me.cmdAllowSelector.Size = New System.Drawing.Size(96, 24)
    Me.cmdAllowSelector.TabIndex = 6
    Me.cmdAllowSelector.Text = "Allow Selector"
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Schedule1.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.ColumnHeader.FrameIncrement = 0
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DayLength = 16
    Me.Schedule1.DefaultAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.DefaultAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.DefaultAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.DefaultAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Location = New System.Drawing.Point(4, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.Schedule1.RowHeader.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.RowHeader.FrameIncrement = 0
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.SelectedAppointmentHeaderAppearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Appearance.Alignment = System.Drawing.StringAlignment.Near
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.BackColor2 = System.Drawing.Color.Wheat
    Me.Schedule1.Selector.Appearance.StringFormatFlags = System.Drawing.StringFormatFlags.FitBlackBox
    Me.Schedule1.Selector.Column = 0
    Me.Schedule1.Selector.Length = 1
    Me.Schedule1.Selector.Row = 0
    Me.Schedule1.Size = New System.Drawing.Size(592, 416)
    Me.Schedule1.StartTime = New Date(1, 1, 1, 8, 0, 0, 0)
    Me.Schedule1.TabIndex = 9
    '
    'SelectorForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(600, 453)
    Me.Controls.Add(Me.Schedule1)
    Me.Controls.Add(Me.lblDescription)
    Me.Controls.Add(Me.cmdSetSelector)
    Me.Controls.Add(Me.cmdAllowSelector)
    Me.Name = "SelectorForm"
    Me.Text = "SelectorForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub cmdAllowSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllowSelector.Click
    'Toggle the selector block on/off
    Schedule1.AllowSelector = Not Schedule1.AllowSelector
  End Sub

  Private Sub cmdSetSelector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetSelector.Click

    'Turn off drawing then set the selector posistion 
    'and size and then turn on drawing
    Schedule1.AutoRedraw = False
    Schedule1.Selector.Column = 1
    Schedule1.Selector.Row = 1
    Schedule1.Selector.Length = 3
    Schedule1.AutoRedraw = True

  End Sub

  Private Sub cmdAllowSelector_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAllowSelector.MouseEnter
    lblDescription.Text = "This button will toggle the selector on/off."
  End Sub

  Private Sub cmdAllowSelector_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAllowSelector.MouseLeave
    lblDescription.Text = ""
  End Sub

  Private Sub cmdSetSelector_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSetSelector.MouseEnter
    lblDescription.Text = "This button will set the seletor to a specific place on the schedule."
  End Sub

  Private Sub cmdSetSelector_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSetSelector.MouseLeave
    lblDescription.Text = ""
  End Sub

End Class
