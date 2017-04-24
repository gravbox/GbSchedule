#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System.Reflection
Imports Gravitybox.Objects

Namespace Gravitybox.Forms

  Friend Class AboutForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Friend Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      PictureBox1.Image = New Bitmap(GetProjectFileAsStream("aboutheader.bmp"))
      picIcon.Image = (New Icon(GetProjectFileAsStream("appointment.ico"))).ToBitmap()

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
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents picIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblLicenseHeader2 As System.Windows.Forms.Label
    Friend WithEvents lblLicense As System.Windows.Forms.Label
    Friend WithEvents lblEmailHeader As System.Windows.Forms.Label
    Friend WithEvents lblWebsiteHeader As System.Windows.Forms.Label
    Friend WithEvents lblWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents lblEmail As System.Windows.Forms.LinkLabel
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.cmdOK = New System.Windows.Forms.Button
      Me.lblProduct = New System.Windows.Forms.Label
      Me.lblWarning = New System.Windows.Forms.Label
      Me.lblCopyright = New System.Windows.Forms.Label
      Me.picIcon = New System.Windows.Forms.PictureBox
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.lblLicenseHeader2 = New System.Windows.Forms.Label
      Me.lblLicense = New System.Windows.Forms.Label
      Me.lblEmailHeader = New System.Windows.Forms.Label
      Me.lblWebsiteHeader = New System.Windows.Forms.Label
      Me.lblWebsite = New System.Windows.Forms.LinkLabel
      Me.lblEmail = New System.Windows.Forms.LinkLabel
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Label1 = New System.Windows.Forms.Label
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(336, 345)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(88, 24)
      Me.cmdOK.TabIndex = 0
      Me.cmdOK.Text = "&OK"
      '
      'lblProduct
      '
      Me.lblProduct.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblProduct.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblProduct.Location = New System.Drawing.Point(136, 80)
      Me.lblProduct.Name = "lblProduct"
      Me.lblProduct.Size = New System.Drawing.Size(288, 16)
      Me.lblProduct.TabIndex = 1
      Me.lblProduct.Text = "[PRODUCT]"
      '
      'lblWarning
      '
      Me.lblWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWarning.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblWarning.Location = New System.Drawing.Point(136, 264)
      Me.lblWarning.Name = "lblWarning"
      Me.lblWarning.Size = New System.Drawing.Size(288, 72)
      Me.lblWarning.TabIndex = 6
      '
      'lblCopyright
      '
      Me.lblCopyright.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCopyright.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblCopyright.Location = New System.Drawing.Point(136, 144)
      Me.lblCopyright.Name = "lblCopyright"
      Me.lblCopyright.Size = New System.Drawing.Size(288, 32)
      Me.lblCopyright.TabIndex = 7
      Me.lblCopyright.Text = "[COPYRIGHT]"
      '
      'picIcon
      '
      Me.picIcon.Location = New System.Drawing.Point(16, 88)
      Me.picIcon.Name = "picIcon"
      Me.picIcon.Size = New System.Drawing.Size(48, 40)
      Me.picIcon.TabIndex = 8
      Me.picIcon.TabStop = False
      '
      'Timer1
      '
      Me.Timer1.Interval = 2000
      '
      'lblLicenseHeader2
      '
      Me.lblLicenseHeader2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLicenseHeader2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblLicenseHeader2.Location = New System.Drawing.Point(136, 104)
      Me.lblLicenseHeader2.Name = "lblLicenseHeader2"
      Me.lblLicenseHeader2.Size = New System.Drawing.Size(288, 16)
      Me.lblLicenseHeader2.TabIndex = 9
      Me.lblLicenseHeader2.Text = "License Key:"
      '
      'lblLicense
      '
      Me.lblLicense.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLicense.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblLicense.Location = New System.Drawing.Point(136, 120)
      Me.lblLicense.Name = "lblLicense"
      Me.lblLicense.Size = New System.Drawing.Size(288, 16)
      Me.lblLicense.TabIndex = 10
      Me.lblLicense.Text = "[LICENSE]"
      '
      'lblEmailHeader
      '
      Me.lblEmailHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblEmailHeader.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblEmailHeader.Location = New System.Drawing.Point(136, 224)
      Me.lblEmailHeader.Name = "lblEmailHeader"
      Me.lblEmailHeader.Size = New System.Drawing.Size(288, 14)
      Me.lblEmailHeader.TabIndex = 12
      Me.lblEmailHeader.Text = "Email:"
      '
      'lblWebsiteHeader
      '
      Me.lblWebsiteHeader.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWebsiteHeader.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
      Me.lblWebsiteHeader.Location = New System.Drawing.Point(136, 184)
      Me.lblWebsiteHeader.Name = "lblWebsiteHeader"
      Me.lblWebsiteHeader.Size = New System.Drawing.Size(288, 14)
      Me.lblWebsiteHeader.TabIndex = 14
      Me.lblWebsiteHeader.Text = "Website:"
      '
      'lblWebsite
      '
      Me.lblWebsite.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblWebsite.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.lblWebsite.Location = New System.Drawing.Point(136, 200)
      Me.lblWebsite.Name = "lblWebsite"
      Me.lblWebsite.Size = New System.Drawing.Size(288, 16)
      Me.lblWebsite.TabIndex = 15
      Me.lblWebsite.TabStop = True
      Me.lblWebsite.Text = "http://www.gravitybox.com"
      '
      'lblEmail
      '
      Me.lblEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblEmail.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
      Me.lblEmail.Location = New System.Drawing.Point(136, 240)
      Me.lblEmail.Name = "lblEmail"
      Me.lblEmail.Size = New System.Drawing.Size(288, 16)
      Me.lblEmail.TabIndex = 16
      Me.lblEmail.TabStop = True
      Me.lblEmail.Text = "feedback@gravitybox.com"
      '
      'Panel1
      '
      Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.PictureBox1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(434, 376)
      Me.Panel1.TabIndex = 18
      '
      'Label1
      '
      Me.Label1.BackColor = System.Drawing.Color.Black
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label1.Location = New System.Drawing.Point(0, 73)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(432, 1)
      Me.Label1.TabIndex = 19
      '
      'PictureBox1
      '
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(437, 73)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 18
      Me.PictureBox1.TabStop = False
      '
      'AboutForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(434, 376)
      Me.Controls.Add(Me.lblEmail)
      Me.Controls.Add(Me.lblWebsite)
      Me.Controls.Add(Me.lblWebsiteHeader)
      Me.Controls.Add(Me.lblEmailHeader)
      Me.Controls.Add(Me.lblLicense)
      Me.Controls.Add(Me.lblLicenseHeader2)
      Me.Controls.Add(Me.picIcon)
      Me.Controls.Add(Me.lblCopyright)
      Me.Controls.Add(Me.lblWarning)
      Me.Controls.Add(Me.lblProduct)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.Panel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AboutForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "<About>"
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

		'Public ComponentLicense As licX.LicXLicense
    Private m_QuickUnload As Boolean

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public Property QuickUnload() As Boolean
      Get
        Return m_QuickUnload
      End Get
      Set(ByVal Value As Boolean)
        m_QuickUnload = Value
        cmdOK.Visible = Not QuickUnload
      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Call Me.Close()
    End Sub

    Private Sub AboutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Try

        Dim backColor As Color = Color.White 'SystemColors.Control
        Dim foreColor As Color = Color.Black 'SystemColors.ControlText

        'Reset the deisgn-time color settings
        Dim ctrl As Control
        For Each ctrl In Me.Controls
          If ctrl.GetType Is GetType(System.Windows.Forms.Label) Then
            ctrl.BackColor = backColor
            ctrl.ForeColor = foreColor
          ElseIf ctrl.GetType Is GetType(LinkLabel) Then
            ctrl.BackColor = backColor
            ctrl.ForeColor = foreColor
            CType(ctrl, LinkLabel).LinkColor = foreColor
          End If
        Next

        Me.BackColor = backColor
        Me.ForeColor = foreColor

        'Get all of the assembly settings
        Dim MyAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim copyright As System.Reflection.AssemblyCopyrightAttribute = CType(System.Reflection.AssemblyCopyrightAttribute.GetCustomAttribute(MyAssembly, GetType(System.Reflection.AssemblyCopyrightAttribute)), System.Reflection.AssemblyCopyrightAttribute)
        Dim description As AssemblyDescriptionAttribute = CType(AssemblyDescriptionAttribute.GetCustomAttribute(MyAssembly, GetType(AssemblyDescriptionAttribute)), AssemblyDescriptionAttribute)
        Dim company As AssemblyCompanyAttribute = CType(AssemblyCompanyAttribute.GetCustomAttribute(MyAssembly, GetType(AssemblyCompanyAttribute)), AssemblyCompanyAttribute)
        Dim trademark As AssemblyTrademarkAttribute = CType(AssemblyTrademarkAttribute.GetCustomAttribute(MyAssembly, GetType(AssemblyTrademarkAttribute)), AssemblyTrademarkAttribute)
        Dim product As AssemblyProductAttribute = CType(AssemblyProductAttribute.GetCustomAttribute(MyAssembly, GetType(AssemblyProductAttribute)), AssemblyProductAttribute)
        Dim title As AssemblyTitleAttribute = CType(AssemblyTitleAttribute.GetCustomAttribute(MyAssembly, GetType(AssemblyTitleAttribute)), AssemblyTitleAttribute)
        'Dim guid As GuidAttribute = CType(GuidAttribute.GetCustomAttribute(MyAssembly, GetType(GuidAttribute)), GuidAttribute)
        Dim debuggable As DebuggableAttribute = CType(DebuggableAttribute.GetCustomAttribute(MyAssembly, GetType(DebuggableAttribute)), DebuggableAttribute)
        Dim CLSCompliant As CLSCompliantAttribute = CType(CLSCompliantAttribute.GetCustomAttribute(MyAssembly, GetType(CLSCompliantAttribute)), CLSCompliantAttribute)

        'Get the version information
        Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version()
        Dim versionString As String = version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision

        'Setup the form display
#If SHAREWARE = 1 Then
        dim licenseText as String = "(Shareware)"
#Else
        Dim licenseText As String = "(Licensed)"
#End If

        'Me.lblUserInfo.Text = System.Windows.Forms.SystemInformation.UserName & ControlChars.CrLf
				'If ComponentLicense Is Nothing Then
				'  Me.lblLicense.Text = licenseText
				'Else
				'  If ComponentLicense.IsEvaluation Then
				'    Me.lblLicense.Text = licenseText
				'  Else
				'    Me.lblLicense.Text = ComponentLicense.LicenseKey
				'  End If
				'End If

        'Me.lblLicenseHeader1.Text = "This product licensed to"
        Me.lblLicenseHeader2.Text = "License Key:"
        Me.lblProduct.Text = title.Title & " " & versionString
        Me.lblWarning.Text = trademark.Trademark
        Me.lblCopyright.Text = copyright.Copyright
        Me.Text = "About " & title.Title & " " & versionString

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub AboutForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

      Try
        'If this is a nag screen then unload it quickly
        If QuickUnload Then Timer1.Enabled = True
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Try
        Call Me.Close()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Sub lblWebsite_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblWebsite.LinkClicked
      Try
        Call System.Diagnostics.Process.Start(lblWebsite.Text)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Sub lblEmail_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblEmail.LinkClicked
      Try
        Call System.Diagnostics.Process.Start("mailto:" & lblEmail.Text)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Sub AboutForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

      If (e.KeyCode = Keys.Escape) Then
        Me.Close()
      End If

    End Sub

#End Region

  End Class

End Namespace