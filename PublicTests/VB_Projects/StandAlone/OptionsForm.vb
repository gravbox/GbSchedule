Option Explicit On 
Option Strict On

Namespace Gravitybox.Applications.StandAloneDemo

  Public Class OptionsForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

      'Initialize the combo
      cboConflict.Items.Add(Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap)
      cboConflict.Items.Add(Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide)
      cboConflict.Items.Add(Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger)

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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmdOK As FlatUI.Controls.XPButton
    Friend WithEvents cmdCancel As FlatUI.Controls.XPButton
    Friend WithEvents chkUseAutoFitColumns As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseAppointmentHeaders As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseRoundAppointment As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseColoredAppointments As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseTransparentAppointment As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseAppointmentIcons As FlatUI.Controls.FlatCheckBox
    Friend WithEvents chkUseNoDrop As FlatUI.Controls.FlatCheckBox
    Friend WithEvents lblConflictHeader As System.Windows.Forms.Label
    Friend WithEvents cboConflict As FlatUI.Controls.FlatComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OptionsForm))
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.cmdOK = New FlatUI.Controls.XPButton
      Me.cmdCancel = New FlatUI.Controls.XPButton
      Me.chkUseAutoFitColumns = New FlatUI.Controls.FlatCheckBox
      Me.chkUseAppointmentHeaders = New FlatUI.Controls.FlatCheckBox
      Me.chkUseRoundAppointment = New FlatUI.Controls.FlatCheckBox
      Me.chkUseColoredAppointments = New FlatUI.Controls.FlatCheckBox
      Me.chkUseTransparentAppointment = New FlatUI.Controls.FlatCheckBox
      Me.chkUseAppointmentIcons = New FlatUI.Controls.FlatCheckBox
      Me.chkUseNoDrop = New FlatUI.Controls.FlatCheckBox
      Me.lblConflictHeader = New System.Windows.Forms.Label
      Me.cboConflict = New FlatUI.Controls.FlatComboBox
      Me.SuspendLayout()
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(8, 8)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 0
      Me.PictureBox1.TabStop = False
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.Location = New System.Drawing.Point(186, 210)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(80, 24)
      Me.cmdOK.TabIndex = 8
      Me.cmdOK.Text = "OK"
      '
      'cmdCancel
      '
      Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancel.Location = New System.Drawing.Point(274, 210)
      Me.cmdCancel.Name = "cmdCancel"
      Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
      Me.cmdCancel.TabIndex = 9
      Me.cmdCancel.Text = "Cancel"
      '
      'chkUseAutoFitColumns
      '
      Me.chkUseAutoFitColumns.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseAutoFitColumns.Location = New System.Drawing.Point(88, 8)
      Me.chkUseAutoFitColumns.Name = "chkUseAutoFitColumns"
      Me.chkUseAutoFitColumns.Size = New System.Drawing.Size(264, 16)
      Me.chkUseAutoFitColumns.TabIndex = 0
      Me.chkUseAutoFitColumns.Text = "AutoFit Columns"
      '
      'chkUseAppointmentHeaders
      '
      Me.chkUseAppointmentHeaders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseAppointmentHeaders.Location = New System.Drawing.Point(88, 32)
      Me.chkUseAppointmentHeaders.Name = "chkUseAppointmentHeaders"
      Me.chkUseAppointmentHeaders.Size = New System.Drawing.Size(264, 16)
      Me.chkUseAppointmentHeaders.TabIndex = 1
      Me.chkUseAppointmentHeaders.Text = "Use Appointment Headers"
      '
      'chkUseRoundAppointment
      '
      Me.chkUseRoundAppointment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseRoundAppointment.Location = New System.Drawing.Point(88, 56)
      Me.chkUseRoundAppointment.Name = "chkUseRoundAppointment"
      Me.chkUseRoundAppointment.Size = New System.Drawing.Size(264, 16)
      Me.chkUseRoundAppointment.TabIndex = 2
      Me.chkUseRoundAppointment.Text = "Round Appointments"
      '
      'chkUseColoredAppointments
      '
      Me.chkUseColoredAppointments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseColoredAppointments.Location = New System.Drawing.Point(88, 80)
      Me.chkUseColoredAppointments.Name = "chkUseColoredAppointments"
      Me.chkUseColoredAppointments.Size = New System.Drawing.Size(264, 16)
      Me.chkUseColoredAppointments.TabIndex = 3
      Me.chkUseColoredAppointments.Text = "Colored Appointments"
      '
      'chkUseTransparentAppointment
      '
      Me.chkUseTransparentAppointment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseTransparentAppointment.Location = New System.Drawing.Point(88, 104)
      Me.chkUseTransparentAppointment.Name = "chkUseTransparentAppointment"
      Me.chkUseTransparentAppointment.Size = New System.Drawing.Size(264, 16)
      Me.chkUseTransparentAppointment.TabIndex = 4
      Me.chkUseTransparentAppointment.Text = "Transparent Appointments"
      '
      'chkUseAppointmentIcons
      '
      Me.chkUseAppointmentIcons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseAppointmentIcons.Location = New System.Drawing.Point(88, 128)
      Me.chkUseAppointmentIcons.Name = "chkUseAppointmentIcons"
      Me.chkUseAppointmentIcons.Size = New System.Drawing.Size(264, 16)
      Me.chkUseAppointmentIcons.TabIndex = 5
      Me.chkUseAppointmentIcons.Text = "Appointment Icons"
      '
      'chkUseNoDrop
      '
      Me.chkUseNoDrop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.chkUseNoDrop.Location = New System.Drawing.Point(88, 152)
      Me.chkUseNoDrop.Name = "chkUseNoDrop"
      Me.chkUseNoDrop.Size = New System.Drawing.Size(264, 16)
      Me.chkUseNoDrop.TabIndex = 6
      Me.chkUseNoDrop.Text = "No-drop Lunch Hour"
      '
      'lblConflictHeader
      '
      Me.lblConflictHeader.Location = New System.Drawing.Point(88, 176)
      Me.lblConflictHeader.Name = "lblConflictHeader"
      Me.lblConflictHeader.Size = New System.Drawing.Size(96, 16)
      Me.lblConflictHeader.TabIndex = 9
      Me.lblConflictHeader.Text = "Conflicts:"
      '
      'cboConflict
      '
      Me.cboConflict.DropDownStyle = ComboBoxStyle.DropDownList
      Me.cboConflict.Location = New System.Drawing.Point(192, 176)
      Me.cboConflict.Name = "cboConflict"
      Me.cboConflict.Size = New System.Drawing.Size(152, 21)
      Me.cboConflict.TabIndex = 7
      '
      'OptionsForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(362, 239)
      Me.Controls.Add(Me.cboConflict)
      Me.Controls.Add(Me.lblConflictHeader)
      Me.Controls.Add(Me.chkUseNoDrop)
      Me.Controls.Add(Me.chkUseAppointmentIcons)
      Me.Controls.Add(Me.chkUseTransparentAppointment)
      Me.Controls.Add(Me.chkUseColoredAppointments)
      Me.Controls.Add(Me.chkUseRoundAppointment)
      Me.Controls.Add(Me.chkUseAppointmentHeaders)
      Me.Controls.Add(Me.chkUseAutoFitColumns)
      Me.Controls.Add(Me.cmdCancel)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.PictureBox1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OptionsForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Options"
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

#End Region

#Region "Property Implementations"

    Public Property UseAutoFitColumns() As Boolean
      Get
        Return chkUseAutoFitColumns.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseAutoFitColumns.Checked = Value
      End Set
    End Property

    Public Property UseAppointmentHeader() As Boolean
      Get
        Return chkUseAppointmentHeaders.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseAppointmentHeaders.Checked = Value
      End Set
    End Property

    Public Property UseRoundAppointment() As Boolean
      Get
        Return chkUseRoundAppointment.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseRoundAppointment.Checked = Value
      End Set
    End Property

    Public Property UseColoredAppointment() As Boolean
      Get
        Return chkUseColoredAppointments.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseColoredAppointments.Checked = Value
      End Set
    End Property

    Public Property UseTransparentAppointment() As Boolean
      Get
        Return chkUseTransparentAppointment.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseTransparentAppointment.Checked = Value
      End Set
    End Property

    Public Property UseAppointmentIcons() As Boolean
      Get
        Return chkUseAppointmentIcons.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseAppointmentIcons.Checked = Value
      End Set
    End Property

    Public Property UseNoDropArea() As Boolean
      Get
        Return chkUseNoDrop.Checked
      End Get
      Set(ByVal Value As Boolean)
        chkUseNoDrop.Checked = Value
      End Set
    End Property

    Public Property ConflictDisplay() As Gravitybox.Controls.Schedule.ConflictDisplayConstants
      Get
        Return CType(cboConflict.SelectedItem, Gravitybox.Controls.Schedule.ConflictDisplayConstants)
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.ConflictDisplayConstants)
        cboConflict.SelectedItem = Value
      End Set
    End Property

#End Region

#Region "Button Handlers"

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Me.DialogResult = DialogResult.OK
      Me.Close()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
      Me.DialogResult = DialogResult.Cancel
      Me.Close()
    End Sub

#End Region

#Region "Form Events"

#End Region

  End Class

End Namespace