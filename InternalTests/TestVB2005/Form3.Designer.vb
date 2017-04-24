<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
		Me.Panel1 = New System.Windows.Forms.Panel
		Me.Label1 = New System.Windows.Forms.Label
		Me.Button3 = New System.Windows.Forms.Button
		Me.Button2 = New System.Windows.Forms.Button
		Me.Button1 = New System.Windows.Forms.Button
		Me.schedule1 = New Gravitybox.Controls.Schedule
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.Button3)
		Me.Panel1.Controls.Add(Me.Button2)
		Me.Panel1.Controls.Add(Me.Button1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 280)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(568, 58)
		Me.Panel1.TabIndex = 6
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(488, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(39, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Label1"
		'
		'Button3
		'
		Me.Button3.Location = New System.Drawing.Point(168, 16)
		Me.Button3.Name = "Button3"
		Me.Button3.Size = New System.Drawing.Size(75, 23)
		Me.Button3.TabIndex = 0
		Me.Button3.Text = "Button1"
		Me.Button3.UseVisualStyleBackColor = True
		'
		'Button2
		'
		Me.Button2.Location = New System.Drawing.Point(88, 16)
		Me.Button2.Name = "Button2"
		Me.Button2.Size = New System.Drawing.Size(75, 23)
		Me.Button2.TabIndex = 0
		Me.Button2.Text = "Button1"
		Me.Button2.UseVisualStyleBackColor = True
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(8, 16)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(75, 23)
		Me.Button1.TabIndex = 0
		Me.Button1.Text = "Button1"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'schedule1
		'
		Me.schedule1.AllowDrop = True
		Me.schedule1.Appearance.FontSize = 10.0!
		Me.schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
		Me.schedule1.Appearance.ItemLineColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(206, Byte), Integer))
		Me.schedule1.Appearance.ItemLineWidth = 2
		Me.schedule1.Appearance.Key = "3f567600-62b3-4c68-b97b-91648f72da80"
		Me.schedule1.Appearance.MajorLineColor = System.Drawing.Color.FromArgb(CType(CType(156, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(231, Byte), Integer))
		Me.schedule1.Appearance.MajorLineWidth = 1
		Me.schedule1.Appearance.MinorLineColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(247, Byte), Integer))
		Me.schedule1.Appearance.MinorLineWidth = 1
		Me.schedule1.Appearance.NoFill = False
		Me.schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
		Me.schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.schedule1.ColumnHeader.Appearance.FontSize = 10.0!
		Me.schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.schedule1.ColumnHeader.Appearance.Key = "08c6405c-0191-44c9-a265-4e0215fd33d3"
		Me.schedule1.ColumnHeader.Appearance.NoFill = False
		Me.schedule1.ColumnHeader.Size = 100
		Me.schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
		Me.schedule1.DefaultAppointmentAppearance.Key = "70560add-2230-4f85-836c-83df73ea62a6"
		Me.schedule1.DefaultAppointmentAppearance.NoFill = False
		Me.schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
		Me.schedule1.DefaultAppointmentHeaderAppearance.Key = "7421bf91-2661-4309-8add-316cabbeb025"
		Me.schedule1.DefaultAppointmentHeaderAppearance.NoFill = False
		Me.schedule1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.schedule1.EndTime = New Date(1, 1, 2, 0, 0, 0, 0)
		Me.schedule1.ErrorHanding = Gravitybox.Controls.Schedule.ErrorHandlingConstants.Advanced
		Me.schedule1.EventHeader.Appearance.BackColor = System.Drawing.SystemColors.AppWorkspace
		Me.schedule1.EventHeader.Appearance.FontSize = 10.0!
		Me.schedule1.EventHeader.Appearance.Key = "b9569917-685a-4ff1-8475-494274cef0bf"
		Me.schedule1.EventHeader.Appearance.NoFill = False
		Me.schedule1.EventHeader.ExpandAppearance.BackColor = System.Drawing.Color.LightYellow
		Me.schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
		Me.schedule1.EventHeader.ExpandAppearance.Key = "153c3a1e-b736-4b2a-99b9-708d70df1ef1"
		Me.schedule1.EventHeader.ExpandAppearance.NoFill = False
		Me.schedule1.Location = New System.Drawing.Point(0, 0)
		Me.schedule1.MaxDate = New Date(2006, 1, 31, 0, 0, 0, 0)
		Me.schedule1.MinDate = New Date(2006, 1, 1, 0, 0, 0, 0)
		Me.schedule1.Name = "schedule1"
		Me.schedule1.RowHeader.Appearance.BackColor = System.Drawing.SystemColors.Control
		Me.schedule1.RowHeader.Appearance.BorderColor = System.Drawing.SystemColors.ControlDark
		Me.schedule1.RowHeader.Appearance.FontSize = 10.0!
		Me.schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
		Me.schedule1.RowHeader.Appearance.Key = "fb4c490c-f818-4b68-a2ae-18832133eb07"
		Me.schedule1.RowHeader.Appearance.NoFill = False
		Me.schedule1.RowHeader.Size = 30
		Me.schedule1.SelectedAppointmentAppearance.BorderWidth = 3
		Me.schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
		Me.schedule1.SelectedAppointmentAppearance.Key = "368a6765-09ba-4954-8ed7-60262f08fdb9"
		Me.schedule1.SelectedAppointmentAppearance.NoFill = False
		Me.schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
		Me.schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
		Me.schedule1.SelectedAppointmentHeaderAppearance.Key = "c82ea29b-25ce-4bff-b485-bb27c1eab5a4"
		Me.schedule1.SelectedAppointmentHeaderAppearance.NoFill = False
		Me.schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
		Me.schedule1.Selector.Appearance.FontSize = 10.0!
		Me.schedule1.Selector.Appearance.Key = "369f3f63-b203-40e4-abed-cc67b991b28e"
		Me.schedule1.Selector.Appearance.NoFill = False
		Me.schedule1.Size = New System.Drawing.Size(568, 280)
		Me.schedule1.StartTime = New Date(CType(0, Long))
		Me.schedule1.TabIndex = 5
		Me.schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute15
		Me.schedule1.TimeMarker.Appearance.FontSize = 10.0!
		Me.schedule1.TimeMarker.Appearance.Key = "d25ee816-5380-46c3-b42b-2f9001b2eddb"
		Me.schedule1.TimeMarker.Appearance.NoFill = False
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'ImageList1
		'
		Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
		Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
		Me.ImageList1.Images.SetKeyName(0, "appt_clock.ico")
		Me.ImageList1.Images.SetKeyName(1, "appt_addrbook.ico")
		Me.ImageList1.Images.SetKeyName(2, "appt_attend.ico")
		Me.ImageList1.Images.SetKeyName(3, "appt_attention.ico")
		Me.ImageList1.Images.SetKeyName(4, "appt_bell.ico")
		Me.ImageList1.Images.SetKeyName(5, "appt_book.ico")
		Me.ImageList1.Images.SetKeyName(6, "appt_cal.ico")
		Me.ImageList1.Images.SetKeyName(7, "appt_caution.ico")
		Me.ImageList1.Images.SetKeyName(8, "appt_cert.ico")
		Me.ImageList1.Images.SetKeyName(9, "appt_check.ico")
		Me.ImageList1.Images.SetKeyName(10, "appt_clip.ico")
		Me.ImageList1.Images.SetKeyName(11, "appt_clip_dis.ico")
		'
		'Form3
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(568, 338)
		Me.Controls.Add(Me.schedule1)
		Me.Controls.Add(Me.Panel1)
		Me.Name = "Form3"
		Me.Text = "Form3"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
  Private WithEvents schedule1 As Gravitybox.Controls.Schedule
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
	Friend WithEvents Button3 As System.Windows.Forms.Button
	Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
