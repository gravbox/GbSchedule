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

Imports Gravitybox.Objects

Namespace Gravitybox.Forms

  Friend Class ErrorForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal errorMessge As String)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add Custom code here
      txtError.Text = errorMessge

      img1.Image = (New Icon(GetProjectFileAsStream("error1.ico"))).ToBitmap()
      img2.Image = (New Icon(GetProjectFileAsStream("error2.ico"))).ToBitmap()

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
    Friend WithEvents cmdSend As System.Windows.Forms.Button
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtError As System.Windows.Forms.TextBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents img1 As System.Windows.Forms.PictureBox
    Friend WithEvents img2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdSend = New System.Windows.Forms.Button
      Me.lblName = New System.Windows.Forms.Label
      Me.lblEmail = New System.Windows.Forms.Label
      Me.cmdCancel = New System.Windows.Forms.Button
      Me.txtName = New System.Windows.Forms.TextBox
      Me.txtEmail = New System.Windows.Forms.TextBox
      Me.txtComments = New System.Windows.Forms.TextBox
      Me.lblComments = New System.Windows.Forms.Label
      Me.txtError = New System.Windows.Forms.TextBox
      Me.lblError = New System.Windows.Forms.Label
      Me.lblHeader = New System.Windows.Forms.Label
      Me.img1 = New System.Windows.Forms.PictureBox
      Me.img2 = New System.Windows.Forms.PictureBox
      Me.SuspendLayout()
      '
      'cmdSend
      '
      Me.cmdSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSend.BackColor = System.Drawing.Color.Transparent
      Me.cmdSend.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSend.Location = New System.Drawing.Point(240, 384)
      Me.cmdSend.Name = "cmdSend"
      Me.cmdSend.Size = New System.Drawing.Size(80, 24)
      Me.cmdSend.TabIndex = 4
      Me.cmdSend.Text = "&Send"
      '
      'lblName
      '
      Me.lblName.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblName.Location = New System.Drawing.Point(56, 88)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(64, 16)
      Me.lblName.TabIndex = 1
      Me.lblName.Text = "Full Name:"
      '
      'lblEmail
      '
      Me.lblEmail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblEmail.Location = New System.Drawing.Point(56, 112)
      Me.lblEmail.Name = "lblEmail"
      Me.lblEmail.Size = New System.Drawing.Size(64, 16)
      Me.lblEmail.TabIndex = 2
      Me.lblEmail.Text = "Email:"
      '
      'cmdCancel
      '
      Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancel.BackColor = System.Drawing.Color.Transparent
      Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCancel.Location = New System.Drawing.Point(328, 384)
      Me.cmdCancel.Name = "cmdCancel"
      Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
      Me.cmdCancel.TabIndex = 5
      Me.cmdCancel.Text = "&Cancel"
      '
      'txtName
      '
      Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtName.Location = New System.Drawing.Point(128, 88)
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(280, 20)
      Me.txtName.TabIndex = 0
      Me.txtName.Text = ""
      '
      'txtEmail
      '
      Me.txtEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEmail.Location = New System.Drawing.Point(128, 112)
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.Size = New System.Drawing.Size(280, 20)
      Me.txtEmail.TabIndex = 1
      Me.txtEmail.Text = ""
      '
      'txtComments
      '
      Me.txtComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtComments.Location = New System.Drawing.Point(72, 200)
      Me.txtComments.Multiline = True
      Me.txtComments.Name = "txtComments"
      Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtComments.Size = New System.Drawing.Size(336, 72)
      Me.txtComments.TabIndex = 2
      Me.txtComments.Text = ""
      '
      'lblComments
      '
      Me.lblComments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblComments.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblComments.Location = New System.Drawing.Point(72, 160)
      Me.lblComments.Name = "lblComments"
      Me.lblComments.Size = New System.Drawing.Size(336, 32)
      Me.lblComments.TabIndex = 6
      Me.lblComments.Text = "Please provide as much information as you can detailing the events leading to thi" & _
      "s error."
      '
      'txtError
      '
      Me.txtError.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtError.Location = New System.Drawing.Point(72, 280)
      Me.txtError.Multiline = True
      Me.txtError.Name = "txtError"
      Me.txtError.ReadOnly = True
      Me.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtError.Size = New System.Drawing.Size(336, 96)
      Me.txtError.TabIndex = 3
      Me.txtError.Text = ""
      '
      'lblError
      '
      Me.lblError.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.lblError.Location = New System.Drawing.Point(8, 280)
      Me.lblError.Name = "lblError"
      Me.lblError.Size = New System.Drawing.Size(64, 16)
      Me.lblError.TabIndex = 9
      Me.lblError.Text = "Error:"
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.Location = New System.Drawing.Point(80, 8)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(328, 64)
      Me.lblHeader.TabIndex = 10
      Me.lblHeader.Text = "An error has occurred in the Schedule.NET component. Use this screen to report th" & _
      "e error to Gravitybox Software. Please provide a name and email address that we " & _
      "may use for contact if we have any questions."
      '
      'img1
      '
      Me.img1.Location = New System.Drawing.Point(16, 8)
      Me.img1.Name = "img1"
      Me.img1.Size = New System.Drawing.Size(32, 32)
      Me.img1.TabIndex = 11
      Me.img1.TabStop = False
      '
      'img2
      '
      Me.img2.Location = New System.Drawing.Point(16, 160)
      Me.img2.Name = "img2"
      Me.img2.Size = New System.Drawing.Size(32, 32)
      Me.img2.TabIndex = 12
      Me.img2.TabStop = False
      '
      'ErrorForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.Control
      Me.CancelButton = Me.cmdCancel
      Me.ClientSize = New System.Drawing.Size(426, 414)
      Me.ControlBox = False
      Me.Controls.Add(Me.img2)
      Me.Controls.Add(Me.img1)
      Me.Controls.Add(Me.lblHeader)
      Me.Controls.Add(Me.lblError)
      Me.Controls.Add(Me.txtError)
      Me.Controls.Add(Me.txtComments)
      Me.Controls.Add(Me.txtEmail)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.lblComments)
      Me.Controls.Add(Me.cmdCancel)
      Me.Controls.Add(Me.lblEmail)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.cmdSend)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(428, 416)
      Me.Name = "ErrorForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Additional Details"
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Event Handlers"

		Private Sub cmdSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSend.Click

			Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
			Try

				'Save user info for next time
				Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Gravitybox\Common\Error")
				regKey.SetValue("UserName", txtName.Text)
				regKey.SetValue("Email", txtEmail.Text)

				'Get the version information
				Dim version As System.Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version()
				Dim versionString As String = version.Major & "." & version.Minor & "." & version.Build & "." & version.Revision

				'Submit to web service
				Dim cs As New CustomerServices("http://gravitybox.m6.net/CustomerServices/CustomerServices.asmx")
				Dim errorMessage As String = ""
				errorMessage = "Customer: " & txtName.Text & ControlChars.CrLf & _
							"Email: " & txtEmail.Text & ControlChars.CrLf & _
							"Time: " & Now.ToUniversalTime.ToLongDateString & " " & Now.ToUniversalTime.ToLongTimeString & ControlChars.CrLf & _
							"Version: " & versionString & ControlChars.CrLf & _
							"Comments: " & ControlChars.CrLf & txtComments.Text & ControlChars.CrLf & ControlChars.CrLf & _
							"Error Message:" & ControlChars.CrLf & txtError.Text
				cs.PostError(txtName.Text, "Schedule.NET", errorMessage)

			Catch ex As Exception
				MsgBox(txtError.Text, MsgBoxStyle.Exclamation, "Error!")
			Finally
				Me.Cursor = System.Windows.Forms.Cursors.Default
			End Try

			Me.Close()

		End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
      Me.Close()
    End Sub

    Private Sub ErrorForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

      'This way the ESC key can be used to cancel cascading errors quickly
      If e.KeyCode = Keys.Escape Then
        Me.Close()
      End If

    End Sub

    Private Sub ErrorForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

      lblHeader.Text = "An error has occurred in the Schedule.NET component. Use this screen to report the error to Gravitybox Software. Please provide a name and email address that we may use for contact if we have any questions."
      lblComments.Text = "Please provide as much information as you can detailing the events leading to this error."

      Dim regKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\Gravitybox\Common\Error")
      txtName.Text = CType(regKey.GetValue("UserName"), String)
      txtEmail.Text = CType(regKey.GetValue("Email"), String)

    End Sub

    Private Sub txtEmail_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmail.GotFocus
      txtEmail.SelectionStart = 0
      txtEmail.SelectionLength = txtEmail.Text.Length
    End Sub

    Private Sub txtName_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.GotFocus
      txtName.SelectionStart = 0
      txtName.SelectionLength = txtName.Text.Length
    End Sub

    Private Sub txtComments_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtComments.GotFocus
      txtComments.SelectionStart = 0
      txtComments.SelectionLength = txtComments.Text.Length
    End Sub

#End Region

  End Class

End Namespace