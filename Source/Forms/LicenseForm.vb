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

Imports System.IO
Imports Gravitybox.Objects

Namespace Gravitybox.Forms

  Friend Class LicenseForm
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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents optEvalMode As System.Windows.Forms.RadioButton
    Friend WithEvents optFindLic As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblFolder As System.Windows.Forms.Label
    Friend WithEvents pnlFolder As System.Windows.Forms.Panel
    Friend WithEvents txtSearchFolder As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrentFolder As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSearchFolder As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(LicenseForm))
      Me.lblHeader = New System.Windows.Forms.Label
      Me.cmdClose = New System.Windows.Forms.Button
      Me.optEvalMode = New System.Windows.Forms.RadioButton
      Me.optFindLic = New System.Windows.Forms.RadioButton
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.pnlFolder = New System.Windows.Forms.Panel
      Me.cmdSearchFolder = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtCurrentFolder = New System.Windows.Forms.TextBox
      Me.txtSearchFolder = New System.Windows.Forms.TextBox
      Me.lblFolder = New System.Windows.Forms.Label
      Me.pnlFolder.SuspendLayout()
      Me.SuspendLayout()
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.BackColor = System.Drawing.SystemColors.Control
      Me.lblHeader.Location = New System.Drawing.Point(8, 8)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(408, 40)
      Me.lblHeader.TabIndex = 0
      Me.lblHeader.Text = "The license check failed for the Gravitybox Schedule.NET software component. Eith" & _
      "er the license file was not found or the key was invalid."
      '
      'cmdClose
      '
      Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdClose.Location = New System.Drawing.Point(336, 256)
      Me.cmdClose.Name = "cmdClose"
      Me.cmdClose.Size = New System.Drawing.Size(80, 24)
      Me.cmdClose.TabIndex = 5
      Me.cmdClose.Text = "&OK"
      '
      'optEvalMode
      '
      Me.optEvalMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.optEvalMode.BackColor = System.Drawing.SystemColors.Control
      Me.optEvalMode.Checked = True
      Me.optEvalMode.Location = New System.Drawing.Point(56, 56)
      Me.optEvalMode.Name = "optEvalMode"
      Me.optEvalMode.Size = New System.Drawing.Size(360, 16)
      Me.optEvalMode.TabIndex = 0
      Me.optEvalMode.TabStop = True
      Me.optEvalMode.Text = "Continue in evaluation mode."
      Me.optEvalMode.TextAlign = System.Drawing.ContentAlignment.TopLeft
      '
      'optFindLic
      '
      Me.optFindLic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.optFindLic.BackColor = System.Drawing.SystemColors.Control
      Me.optFindLic.Location = New System.Drawing.Point(56, 80)
      Me.optFindLic.Name = "optFindLic"
      Me.optFindLic.Size = New System.Drawing.Size(360, 48)
      Me.optFindLic.TabIndex = 1
      Me.optFindLic.Text = "Attempt to find the installed license file and copy it to the current application" & _
      " folder. This will prevent this dialog screen from displaying the next time you " & _
      "load this project."
      Me.optFindLic.TextAlign = System.Drawing.ContentAlignment.TopLeft
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(8, 56)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
      Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox1.TabIndex = 3
      Me.PictureBox1.TabStop = False
      '
      'pnlFolder
      '
      Me.pnlFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlFolder.Controls.Add(Me.cmdSearchFolder)
      Me.pnlFolder.Controls.Add(Me.Label1)
      Me.pnlFolder.Controls.Add(Me.txtCurrentFolder)
      Me.pnlFolder.Controls.Add(Me.txtSearchFolder)
      Me.pnlFolder.Controls.Add(Me.lblFolder)
      Me.pnlFolder.Location = New System.Drawing.Point(80, 136)
      Me.pnlFolder.Name = "pnlFolder"
      Me.pnlFolder.Size = New System.Drawing.Size(336, 112)
      Me.pnlFolder.TabIndex = 4
      '
      'cmdSearchFolder
      '
      Me.cmdSearchFolder.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdSearchFolder.Location = New System.Drawing.Point(304, 24)
      Me.cmdSearchFolder.Name = "cmdSearchFolder"
      Me.cmdSearchFolder.Size = New System.Drawing.Size(24, 16)
      Me.cmdSearchFolder.TabIndex = 3
      Me.cmdSearchFolder.Text = "···"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(8, 64)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(128, 16)
      Me.Label1.TabIndex = 4
      Me.Label1.Text = "Current Folder:"
      '
      'txtCurrentFolder
      '
      Me.txtCurrentFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCurrentFolder.Location = New System.Drawing.Point(8, 80)
      Me.txtCurrentFolder.Name = "txtCurrentFolder"
      Me.txtCurrentFolder.ReadOnly = True
      Me.txtCurrentFolder.Size = New System.Drawing.Size(320, 20)
      Me.txtCurrentFolder.TabIndex = 4
      Me.txtCurrentFolder.Text = ""
      '
      'txtSearchFolder
      '
      Me.txtSearchFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSearchFolder.Location = New System.Drawing.Point(8, 24)
      Me.txtSearchFolder.Name = "txtSearchFolder"
      Me.txtSearchFolder.Size = New System.Drawing.Size(288, 20)
      Me.txtSearchFolder.TabIndex = 2
      Me.txtSearchFolder.Text = ""
      '
      'lblFolder
      '
      Me.lblFolder.Location = New System.Drawing.Point(8, 8)
      Me.lblFolder.Name = "lblFolder"
      Me.lblFolder.Size = New System.Drawing.Size(128, 16)
      Me.lblFolder.TabIndex = 0
      Me.lblFolder.Text = "Search Folder:"
      '
      'LicenseForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(426, 287)
      Me.ControlBox = False
      Me.Controls.Add(Me.pnlFolder)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.optFindLic)
      Me.Controls.Add(Me.optEvalMode)
      Me.Controls.Add(Me.cmdClose)
      Me.Controls.Add(Me.lblHeader)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LicenseForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "License Failed"
      Me.pnlFolder.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Private Const LicenseFile As String = "Gravitybox.Controls.Schedule.lic"
    Private Const CloseText As String = "&OK"
    Private Const CancelText As String = "&Cancel"

    Public Dialogs As Gravitybox.Objects.ScheduleDialog
    Private IsFound As Boolean = False
    Private IsCanceled As Boolean = False
    Private folderCount As Integer = 0

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Methods"

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click

      'If this button is for canceling then cancel the search
      If Me.cmdClose.Text = CancelText Then
        IsCanceled = True
        Return
      Else
        IsCanceled = False
      End If

      If Me.optEvalMode.Checked Then
        'If run in eval mode then show the splash screen
        Me.Hide()
        Dialogs.ShowAboutDialog(True)

      ElseIf Me.optFindLic.Checked Then
        'Find the license file and copy it to the current folder

        'Verify that the folder exists
        If Not Directory.Exists(txtSearchFolder.Text) Then
          Call MsgBox("The specified folder does not exist!", MsgBoxStyle.Exclamation, "Error!")
          Return
        End If

        'This is the target folder
        Dim targetFolder As String = New FileInfo(Application.ExecutablePath).DirectoryName
        Dim sourceFolder As String = FindLicenseFile()
        If sourceFolder = "" Then Return

        'Copy the file found
        If sourceFolder <> "" Then
          If Not sourceFolder.EndsWith("\") Then sourceFolder += "\"
          If Not targetFolder.EndsWith("\") Then targetFolder += "\"

          'If the target file exists then remove it
          If System.IO.File.Exists(targetFolder & LicenseFile) Then
            Try
              System.IO.File.Delete(targetFolder & LicenseFile)
              Dim ii As Integer
              For ii = 1 To 5
                System.Windows.Forms.Application.DoEvents()
              Next
            Catch ex As Exception
              'Do Nothing
            End Try
          End If

          'Copy the file
          Try
            System.Diagnostics.EventLog.WriteEntry("GbSchedule Copy License", "Source: " & sourceFolder & LicenseFile & vbCrLf & "Target: " & targetFolder & LicenseFile)
            System.IO.File.Copy(sourceFolder & LicenseFile, targetFolder & LicenseFile)
          Catch ex As Exception
            'Do Nothing
          End Try

        End If

      End If

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()

    End Sub

    Private Function FindLicenseFile() As String

      'Find the source folder
      Dim sourceFolder As String = ""

      'Look in the Program Files folder first
      System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
      Me.cmdClose.Text = CancelText
      System.Windows.Forms.Application.DoEvents()
      IsFound = False
      sourceFolder = ProcessDirectory(txtSearchFolder.Text, LicenseFile)
      If sourceFolder Is Nothing Then sourceFolder = ""
      Me.cmdClose.Text = CloseText
      System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

      If (sourceFolder = "") And (Not IsCanceled) Then
        'The license file could not be found. ERROR!
        If sourceFolder = "" Then
          Call MsgBox("The file '" & LicenseFile & "' could not be found in the specified path!", MsgBoxStyle.Exclamation, "File not found!")
        End If
      End If

      Return sourceFolder

    End Function

    'Process all files in the directory passed in, and recurse on any directories 
    'that are found to process the files they contain
    Public Function ProcessDirectory(ByVal targetDirectory As String, ByVal licenseFilename As String) As String

      Try

        'System.Windows.Forms.Application.DoEvents()

        'Process the list of files found in the directory
        Dim fileName As String = ""
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory, licenseFilename)
        For Each fileName In fileEntries
          IsFound = True
          Return targetDirectory
        Next

        folderCount += 1
        If IsCanceled Then Return ""

        'Every so often refresh screen
        If (folderCount Mod 50) = 0 Then
          System.Windows.Forms.Application.DoEvents()
        End If

        'Recurse into subdirectories of this directory
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String = ""
        For Each subdirectory In subdirectoryEntries
          fileName = ProcessDirectory(subdirectory, licenseFilename)
          If fileName <> "" Then Return fileName
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Private Sub LicenseForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      txtSearchFolder.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
      txtCurrentFolder.Text = AppPath()
      Call EnableControls()
    End Sub

    Private Sub optFindLic_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optFindLic.CheckedChanged
      Call EnableControls()
    End Sub

    Private Sub optEvalMode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optEvalMode.CheckedChanged
      Call EnableControls()
    End Sub

    Private Sub EnableControls()

      txtSearchFolder.Enabled = optFindLic.Checked
      lblFolder.Enabled = optFindLic.Checked

    End Sub

    Private Sub cmdSearchFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchFolder.Click

			Try
				Dim fb As New FolderBrowserDialog
				If fb.ShowDialog = System.Windows.Forms.DialogResult.OK Then
					txtSearchFolder.Text = fb.SelectedPath
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

    End Sub

    Private Sub optEvalMode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles optEvalMode.KeyDown, optFindLic.KeyDown
      If (e.KeyCode = Keys.Enter) Then
        cmdClose.PerformClick()
      End If
    End Sub

#End Region

  End Class

End Namespace