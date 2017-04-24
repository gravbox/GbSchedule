<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.schedule1 = New Gravitybox.Controls.Schedule
    Me.Button1 = New System.Windows.Forms.Button
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.Button1)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Panel1.Location = New System.Drawing.Point(0, 344)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(611, 44)
    Me.Panel1.TabIndex = 0
    '
    'schedule1
    '
    Me.schedule1.AllowDrop = True
    Me.schedule1.Appearance.FontSize = 10.0!
    Me.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.schedule1.Appearance.NoFill = False
    Me.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.schedule1.ColumnHeader.Appearance.NoFill = False
    Me.schedule1.ColumnHeader.Size = 100
    Me.schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.schedule1.DefaultAppointmentAppearance.NoFill = False
    Me.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
    Me.schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
    Me.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
    Me.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
    Me.schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.schedule1.EventHeader.Appearance.NoFill = False
    Me.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
    Me.schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.schedule1.EventHeader.ExpandAppearance.NoFill = False
    Me.schedule1.Location = New System.Drawing.Point(0, 0)
    Me.schedule1.MaxDate = New Date(2006, 1, 31, 0, 0, 0, 0)
    Me.schedule1.MinDate = New Date(2006, 1, 1, 0, 0, 0, 0)
    Me.schedule1.Name = "schedule1"
    Me.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
    Me.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
    Me.schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.schedule1.RowHeader.Appearance.NoFill = False
    Me.schedule1.RowHeader.Size = 30
    Me.schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.schedule1.SelectedAppointmentAppearance.NoFill = False
    Me.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
    Me.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.schedule1.Selector.Appearance.FontSize = 10.0!
    Me.schedule1.Selector.Appearance.NoFill = False
    Me.schedule1.Size = New System.Drawing.Size(611, 344)
    Me.schedule1.StartTime = New Date(CType(0, Long))
    Me.schedule1.TabIndex = 3
    Me.schedule1.TimeMarker.Appearance.FontSize = 10.0!
    Me.schedule1.TimeMarker.Appearance.NoFill = False
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(8, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(611, 388)
    Me.Controls.Add(Me.schedule1)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.Panel1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Private WithEvents schedule1 As Gravitybox.Controls.Schedule

End Class
