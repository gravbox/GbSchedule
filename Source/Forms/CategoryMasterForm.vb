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

  Friend Class CategoryMasterForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Friend Sub New()
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
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
    Friend WithEvents lstList As System.Windows.Forms.ListBox
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdAdd = New System.Windows.Forms.Button
      Me.cmdDelete = New System.Windows.Forms.Button
      Me.cmdOK = New System.Windows.Forms.Button
      Me.cmdCancel = New System.Windows.Forms.Button
      Me.lblHeader = New System.Windows.Forms.Label
      Me.txtNew = New System.Windows.Forms.TextBox
      Me.lstList = New System.Windows.Forms.ListBox
      Me.SuspendLayout()
      '
      'cmdAdd
      '
      Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAdd.Location = New System.Drawing.Point(170, 32)
      Me.cmdAdd.Name = "cmdAdd"
      Me.cmdAdd.Size = New System.Drawing.Size(80, 24)
      Me.cmdAdd.TabIndex = 2
      Me.cmdAdd.Text = "&Add"
      '
      'cmdDelete
      '
      Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdDelete.Location = New System.Drawing.Point(170, 64)
      Me.cmdDelete.Name = "cmdDelete"
      Me.cmdDelete.Size = New System.Drawing.Size(80, 24)
      Me.cmdDelete.TabIndex = 3
      Me.cmdDelete.Text = "&Delete"
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(82, 226)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(80, 24)
      Me.cmdOK.TabIndex = 4
      Me.cmdOK.Text = "&OK"
      '
      'cmdCancel
      '
      Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCancel.Location = New System.Drawing.Point(170, 226)
      Me.cmdCancel.Name = "cmdCancel"
      Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
      Me.cmdCancel.TabIndex = 5
      Me.cmdCancel.Text = "&Cancel"
      '
      'lblHeader
      '
      Me.lblHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblHeader.Location = New System.Drawing.Point(8, 8)
      Me.lblHeader.Name = "lblHeader"
      Me.lblHeader.Size = New System.Drawing.Size(154, 16)
      Me.lblHeader.TabIndex = 6
      Me.lblHeader.Text = "New Category:"
      '
      'txtNew
      '
      Me.txtNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNew.Location = New System.Drawing.Point(8, 32)
      Me.txtNew.Name = "txtNew"
      Me.txtNew.Size = New System.Drawing.Size(154, 20)
      Me.txtNew.TabIndex = 0
      Me.txtNew.Text = ""
      '
      'lstList
      '
      Me.lstList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstList.IntegralHeight = False
      Me.lstList.Location = New System.Drawing.Point(8, 56)
      Me.lstList.Name = "lstList"
      Me.lstList.Size = New System.Drawing.Size(154, 160)
      Me.lstList.TabIndex = 1
      '
      'CategoryMasterForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(258, 255)
      Me.Controls.Add(Me.lstList)
      Me.Controls.Add(Me.txtNew)
      Me.Controls.Add(Me.lblHeader)
      Me.Controls.Add(Me.cmdCancel)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdDelete)
      Me.Controls.Add(Me.cmdAdd)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(260, 280)
      Me.Name = "CategoryMasterForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Master Category List"
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Private m_CategoryCollection As CategoryCollection
    Friend MainObject As Gravitybox.Controls.Schedule
    Private m_DialogSettings As CategoryMasterDialogSettings

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public Property DialogSettings() As CategoryMasterDialogSettings
      Get
        Return m_DialogSettings
      End Get
      Set(ByVal Value As CategoryMasterDialogSettings)
        m_DialogSettings = Value

        Me.cmdAdd.Text = DialogSettings.AddButtonText
        Me.cmdCancel.Text = DialogSettings.CancelButtonText
        Me.cmdDelete.Text = DialogSettings.DeleteButtonText
        Me.cmdOK.Text = DialogSettings.OkButtonText
        Me.lblHeader.Text = DialogSettings.HeaderText
        Me.Text = DialogSettings.WindowText
        Me.Icon = Me.DialogSettings.Icon
        Me.FormBorderStyle = DialogSettings.FormBorderStyle
        Me.StartPosition = DialogSettings.StartPosition
        Me.Location = DialogSettings.Location
        Me.Size = DialogSettings.Size

      End Set
    End Property

    Public Property CategoryCollection() As CategoryCollection
      Get
        Return m_CategoryCollection
      End Get
      Set(ByVal Value As CategoryCollection)
        m_CategoryCollection = Value
        Call RefreshForm()
      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub RefreshForm()

      Try
        Dim category As category
        For Each category In Me.CategoryCollection
          Call Me.lstList.Items.Add(category.Text)
        Next
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

      Try
        Call Me.Close()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

      Try

        'Add the items that need to added
        Dim ii As Integer
        For ii = 0 To Me.lstList.Items.Count - 1
          If Not CategoryCollection.Contains(CStr(Me.lstList.Items(ii))) Then
            Call CategoryCollection.Add("", CStr(Me.lstList.Items(ii)))
          End If
        Next

        'Remove the items that need to be removed
        For ii = Me.CategoryCollection.Count - 1 To 0 Step -1
          If Me.lstList.Items.IndexOf(Me.CategoryCollection(ii).Text) = -1 Then
            Call Me.CategoryCollection.RemoveAt(ii)
          End If
        Next

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Call Me.Close()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub EnableButtons()

      Try
        cmdAdd.Enabled = (Me.txtNew.Text.Trim.Length > 0)
        cmdDelete.Enabled = Not (Me.lstList.SelectedItem Is Nothing)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub lstList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstList.SelectedIndexChanged

      Try
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

      Try
        Me.txtNew.Text = Me.txtNew.Text.Trim()

        'Do not insert twice!
        If Me.lstList.Items.IndexOf(Me.txtNew.Text) <> -1 Then
          Return
        End If

        Call Me.lstList.Items.Add(Me.txtNew.Text)
        Me.txtNew.Text = ""
        Call EnableButtons()
        Call txtNew.Focus()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

      Try
        Call Me.lstList.Items.Remove(Me.lstList.SelectedItem)
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub txtNew_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNew.TextChanged

      Try
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub CategoryMasterForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Not (MainObject Is Nothing) Then
        MainObject.Dialogs.DialogCategoryMasterBounds = New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
      End If
    End Sub

    Private Sub CategoryMasterForm_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
      If Not (MainObject Is Nothing) Then
        MainObject.Dialogs.DialogCategoryMasterBounds = New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
      End If
    End Sub

    Private Sub txtNew_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNew.KeyDown

      Try
        If e.KeyCode = Keys.Enter Then
          Dim text As String = txtNew.Text.Trim
          If text.Length > 0 Then
            Call cmdAdd.PerformClick()
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace