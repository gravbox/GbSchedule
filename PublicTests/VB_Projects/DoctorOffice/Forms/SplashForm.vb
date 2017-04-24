Public Class SplashForm
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
  Friend WithEvents lblProduct As System.Windows.Forms.Label
  Friend WithEvents lblVersion As System.Windows.Forms.Label
  Friend WithEvents lblCompany As System.Windows.Forms.Label
  Friend WithEvents picGraphic As System.Windows.Forms.PictureBox
  Friend WithEvents lblWarning As System.Windows.Forms.Label
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SplashForm))
    Me.lblProduct = New System.Windows.Forms.Label()
    Me.lblCompany = New System.Windows.Forms.Label()
    Me.lblVersion = New System.Windows.Forms.Label()
    Me.picGraphic = New System.Windows.Forms.PictureBox()
    Me.lblWarning = New System.Windows.Forms.Label()
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.SuspendLayout()
    '
    'lblProduct
    '
    Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblProduct.Location = New System.Drawing.Point(16, 16)
    Me.lblProduct.Name = "lblProduct"
    Me.lblProduct.Size = New System.Drawing.Size(392, 40)
    Me.lblProduct.TabIndex = 0
    Me.lblProduct.Text = "[PRODUCT]"
    '
    'lblCompany
    '
    Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblCompany.Location = New System.Drawing.Point(184, 128)
    Me.lblCompany.Name = "lblCompany"
    Me.lblCompany.Size = New System.Drawing.Size(232, 24)
    Me.lblCompany.TabIndex = 1
    Me.lblCompany.Text = "[COMPANY]"
    '
    'lblVersion
    '
    Me.lblVersion.Location = New System.Drawing.Point(176, 56)
    Me.lblVersion.Name = "lblVersion"
    Me.lblVersion.Size = New System.Drawing.Size(232, 16)
    Me.lblVersion.TabIndex = 2
    Me.lblVersion.Text = "[VERSION]"
    Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'picGraphic
    '
    Me.picGraphic.Image = CType(resources.GetObject("picGraphic.Image"), System.Drawing.Bitmap)
    Me.picGraphic.Location = New System.Drawing.Point(16, 88)
    Me.picGraphic.Name = "picGraphic"
    Me.picGraphic.Size = New System.Drawing.Size(152, 104)
    Me.picGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.picGraphic.TabIndex = 3
    Me.picGraphic.TabStop = False
    '
    'lblWarning
    '
    Me.lblWarning.Location = New System.Drawing.Point(184, 160)
    Me.lblWarning.Name = "lblWarning"
    Me.lblWarning.Size = New System.Drawing.Size(240, 88)
    Me.lblWarning.TabIndex = 4
    Me.lblWarning.Text = "[WARNING]"
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    Me.Timer1.Interval = 1500
    '
    'SplashForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.Color.White
    Me.ClientSize = New System.Drawing.Size(430, 254)
    Me.ControlBox = False
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWarning, Me.picGraphic, Me.lblVersion, Me.lblCompany, Me.lblProduct})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Name = "SplashForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub SplashForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.lblCompany.Text = "Gravitybox Software"
    Me.lblProduct.Text = "Office Management System"
    Me.lblVersion.Text = "Version 1.0"
    Me.lblWarning.Text = "Warning: This program is protected by the copyright law. Unauthorized reproduction or distribution of this program, or any portion of it, may result in severe civil and criminal penalties and will be prosecuted to the maximum extent possible under law."

  End Sub

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    Me.Close()
  End Sub

End Class
