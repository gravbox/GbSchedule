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
  Friend WithEvents Schedule1 As Gravitybox.Controls.Schedule
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Schedule1 = New Gravitybox.Controls.Schedule
    Me.SuspendLayout()
    '
    'Schedule1
    '
    Me.Schedule1.AllowDrop = True
    Me.Schedule1.Appearance.FontSize = 10.0!
    Me.Schedule1.Appearance.ForeColor = System.Drawing.Color.DarkGray
    Me.Schedule1.ColumnHeader.Appearance.Alignment = System.Drawing.StringAlignment.Center
    Me.Schedule1.ColumnHeader.Appearance.BackColor = System.Drawing.Color.LightSkyBlue
    Me.Schedule1.ColumnHeader.Appearance.BackColor2 = System.Drawing.Color.White
    Me.Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical
    Me.Schedule1.ColumnHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(162, Byte), CType(141, Byte), CType(104, Byte))
    Me.Schedule1.ColumnHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.ColumnHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.ColumnHeader.Size = 100
    Me.Schedule1.DefaultAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.DefaultAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Schedule1.EventHeader.AllowExpand = False
    Me.Schedule1.EventHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.EventHeader.ExpandAppearance.FontSize = 10.0!
    Me.Schedule1.Location = New System.Drawing.Point(0, 0)
    Me.Schedule1.MaxDate = New Date(2004, 1, 10, 0, 0, 0, 0)
    Me.Schedule1.MinDate = New Date(2004, 1, 1, 0, 0, 0, 0)
    Me.Schedule1.Name = "Schedule1"
    Me.Schedule1.RowHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(213, Byte), CType(204, Byte), CType(187, Byte))
    Me.Schedule1.RowHeader.Appearance.BorderColor = System.Drawing.Color.FromArgb(CType(162, Byte), CType(141, Byte), CType(104, Byte))
    Me.Schedule1.RowHeader.Appearance.FontSize = 10.0!
    Me.Schedule1.RowHeader.Appearance.ForeColor = System.Drawing.SystemColors.ControlText
    Me.Schedule1.RowHeader.Size = 30
    Me.Schedule1.SelectedAppointmentAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentAppearance.FontSize = 10.0!
    Me.Schedule1.SelectedAppointmentHeaderAppearance.BorderWidth = 3
    Me.Schedule1.SelectedAppointmentHeaderAppearance.FontSize = 10.0!
    Me.Schedule1.Selector.Appearance.BackColor = System.Drawing.SystemColors.Highlight
    Me.Schedule1.Selector.Appearance.FontSize = 10.0!
    Me.Schedule1.Size = New System.Drawing.Size(608, 413)
    Me.Schedule1.StartTime = New Date(CType(0, Long))
    Me.Schedule1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(608, 413)
    Me.Controls.Add(Me.Schedule1)
    Me.Name = "Form1"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Gravitybox Schedule.NET"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Schedule1.StartTime = #8:00:00 AM#
    Schedule1.DayLength = 10
    Schedule1.SetMinMaxDate(#1/1/2004#, #1/5/2004#)

    Schedule1.ColumnHeader.Appearance.BackColor = Color.LightSkyBlue
    Schedule1.ColumnHeader.Appearance.BackColor2 = Color.White
    Schedule1.ColumnHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Vertical

    Schedule1.RowHeader.Appearance.BackColor = Color.LightSkyBlue
    Schedule1.RowHeader.Appearance.BackColor2 = Color.White
    Schedule1.RowHeader.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.Horizontal

    Schedule1.Appearance.BackColor = Color.White
    Schedule1.Appearance.BackColor2 = Color.LightBlue
    Schedule1.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal

    Dim appointment As Gravitybox.Objects.Appointment
    appointment = Schedule1.AppointmentCollection.Add("", #1/2/2004#, #9:00:00 AM#, 120)
    appointment.Appearance.BackColor = Color.White
    appointment.Appearance.BackColor2 = Color.Salmon
    appointment.Appearance.BackGradientStyle = Gravitybox.Objects.GradientStyleConstants.ForwardDiagonal
    'appointment.Appearance.IsRound = True
    appointment.Subject = "This is a test!"

  End Sub

End Class
