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

	Friend Class AppointmentTypeConfigForm
		Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

		Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			m_MainObject = mainObject
			WorkingAppointmentTypeCollection = New AppointmentTypeCollection(mainObject)
			AddHandler WorkingAppointmentTypeCollection.Refresh, AddressOf OnRefresh

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
		Friend WithEvents lblProperties As System.Windows.Forms.Label
		Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
		Friend WithEvents cmdDown As System.Windows.Forms.Button
		Friend WithEvents cmdDelete As System.Windows.Forms.Button
		Friend WithEvents lblMembers As System.Windows.Forms.Label
		Friend WithEvents cmdUp As System.Windows.Forms.Button
		Friend WithEvents cmdAdd As System.Windows.Forms.Button
		Friend WithEvents lstMembers As System.Windows.Forms.ListBox
		Friend WithEvents cmdCancel As System.Windows.Forms.Button
		Friend WithEvents cmdOK As System.Windows.Forms.Button
		Friend WithEvents lblLine As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.lblProperties = New System.Windows.Forms.Label
			Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
			Me.cmdDown = New System.Windows.Forms.Button
			Me.cmdDelete = New System.Windows.Forms.Button
			Me.lblMembers = New System.Windows.Forms.Label
			Me.cmdUp = New System.Windows.Forms.Button
			Me.cmdAdd = New System.Windows.Forms.Button
			Me.lstMembers = New System.Windows.Forms.ListBox
			Me.cmdCancel = New System.Windows.Forms.Button
			Me.cmdOK = New System.Windows.Forms.Button
			Me.lblLine = New System.Windows.Forms.Label
			Me.SuspendLayout()
			'
			'lblProperties
			'
			Me.lblProperties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.lblProperties.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
			Me.lblProperties.Location = New System.Drawing.Point(263, 11)
			Me.lblProperties.Name = "lblProperties"
			Me.lblProperties.Size = New System.Drawing.Size(190, 16)
			Me.lblProperties.TabIndex = 34
			Me.lblProperties.Text = "Properties:"
			'
			'PropertyGrid1
			'
			Me.PropertyGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.PropertyGrid1.CommandsVisibleIfAvailable = True
			Me.PropertyGrid1.LargeButtons = False
			Me.PropertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.PropertyGrid1.Location = New System.Drawing.Point(263, 35)
			Me.PropertyGrid1.Name = "PropertyGrid1"
			Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.PropertyGrid1.Size = New System.Drawing.Size(198, 234)
			Me.PropertyGrid1.TabIndex = 30
			Me.PropertyGrid1.Text = "PropertyGrid"
			Me.PropertyGrid1.ToolbarVisible = False
			Me.PropertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
			Me.PropertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
			'
			'cmdDown
			'
			Me.cmdDown.Location = New System.Drawing.Point(223, 67)
			Me.cmdDown.Name = "cmdDown"
			Me.cmdDown.Size = New System.Drawing.Size(24, 24)
			Me.cmdDown.TabIndex = 29
			'
			'cmdDelete
			'
			Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdDelete.Location = New System.Drawing.Point(151, 283)
			Me.cmdDelete.Name = "cmdDelete"
			Me.cmdDelete.Size = New System.Drawing.Size(64, 24)
			Me.cmdDelete.TabIndex = 27
			Me.cmdDelete.Text = "Delete"
			'
			'lblMembers
			'
			Me.lblMembers.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
			Me.lblMembers.Location = New System.Drawing.Point(15, 11)
			Me.lblMembers.Name = "lblMembers"
			Me.lblMembers.Size = New System.Drawing.Size(192, 16)
			Me.lblMembers.TabIndex = 33
			Me.lblMembers.Text = "Members:"
			'
			'cmdUp
			'
			Me.cmdUp.Location = New System.Drawing.Point(223, 35)
			Me.cmdUp.Name = "cmdUp"
			Me.cmdUp.Size = New System.Drawing.Size(24, 24)
			Me.cmdUp.TabIndex = 28
			'
			'cmdAdd
			'
			Me.cmdAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdAdd.Location = New System.Drawing.Point(79, 283)
			Me.cmdAdd.Name = "cmdAdd"
			Me.cmdAdd.Size = New System.Drawing.Size(64, 24)
			Me.cmdAdd.TabIndex = 26
			Me.cmdAdd.Text = "Add"
			'
			'lstMembers
			'
			Me.lstMembers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.lstMembers.IntegralHeight = False
			Me.lstMembers.Location = New System.Drawing.Point(15, 35)
			Me.lstMembers.Name = "lstMembers"
			Me.lstMembers.Size = New System.Drawing.Size(200, 238)
			Me.lstMembers.TabIndex = 25
			'
			'cmdCancel
			'
			Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdCancel.Location = New System.Drawing.Point(377, 319)
			Me.cmdCancel.Name = "cmdCancel"
			Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
			Me.cmdCancel.TabIndex = 32
			Me.cmdCancel.Text = "Cancel"
			'
			'cmdOK
			'
			Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdOK.Location = New System.Drawing.Point(289, 319)
			Me.cmdOK.Name = "cmdOK"
			Me.cmdOK.Size = New System.Drawing.Size(80, 24)
			Me.cmdOK.TabIndex = 31
			Me.cmdOK.Text = "OK"
			'
			'lblLine
			'
			Me.lblLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.lblLine.BackColor = System.Drawing.Color.Black
			Me.lblLine.Location = New System.Drawing.Point(15, 311)
			Me.lblLine.Name = "lblLine"
			Me.lblLine.Size = New System.Drawing.Size(444, 1)
			Me.lblLine.TabIndex = 35
			'
			'AppointmentTypeConfigForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(464, 347)
			Me.Controls.Add(Me.PropertyGrid1)
			Me.Controls.Add(Me.cmdDown)
			Me.Controls.Add(Me.cmdDelete)
			Me.Controls.Add(Me.lblMembers)
			Me.Controls.Add(Me.cmdUp)
			Me.Controls.Add(Me.cmdAdd)
			Me.Controls.Add(Me.lstMembers)
			Me.Controls.Add(Me.cmdCancel)
			Me.Controls.Add(Me.cmdOK)
			Me.Controls.Add(Me.lblLine)
			Me.Controls.Add(Me.lblProperties)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(448, 232)
			Me.Name = "AppointmentTypeConfigForm"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "AppointmentType Configuration"
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Class Members"

		Private m_AppointmentTypeCollection As AppointmentTypeCollection
		Private WorkingAppointmentTypeCollection As AppointmentTypeCollection
		Private m_DialogSettings As ConfigurationDialogSettings
		Private m_MainObject As Gravitybox.Controls.Schedule
		Private DirtyKeys As New Hashtable		'The objects that were added or edited
		Private Changed As Boolean = False

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implmentations"

    Public Property DialogSettings() As ConfigurationDialogSettings
      Get
        Return m_DialogSettings
      End Get
      Set(ByVal Value As ConfigurationDialogSettings)
        m_DialogSettings = Value
        Me.lblMembers.Text = DialogSettings.Header1Text
        Me.lblProperties.Text = DialogSettings.Header2Text
        Me.cmdAdd.Text = DialogSettings.AddButtonText
        Me.cmdDelete.Text = DialogSettings.DeleteButtonText
        Me.cmdOK.Text = DialogSettings.OkButtonText
        Me.cmdCancel.Text = DialogSettings.CancelButtonText
        Me.Text = DialogSettings.WindowText
        Me.Icon = Me.DialogSettings.Icon
        Me.StartPosition = DialogSettings.StartPosition
        Me.Location = DialogSettings.Location
        Me.Size = DialogSettings.Size
        Me.FormBorderStyle = DialogSettings.FormBorderStyle
        Me.PropertyGrid1.HelpVisible = DialogSettings.AllowHelp
      End Set
    End Property

    Public ReadOnly Property MainObject() As Gravitybox.Controls.Schedule
      Get
        Return m_MainObject
      End Get
    End Property

    Public Property AppointmentTypeCollection() As AppointmentTypeCollection
      Get
        Return m_AppointmentTypeCollection
      End Get
      Set(ByVal Value As AppointmentTypeCollection)
        m_AppointmentTypeCollection = Value

        Try
          'Load a working collection with objects
          Call WorkingAppointmentTypeCollection.FromXML(Me.AppointmentTypeCollection.ToXML)
          Call RefreshForm()
          'Default to first item if one exists
          If Me.lstMembers.Items.Count > 0 Then Me.lstMembers.SelectedIndex = 0
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try

      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      Changed = True
    End Sub

    Private Sub RefreshForm()

      Try
        Dim AppointmentType As AppointmentType
        Call Me.lstMembers.Items.Clear()
        For Each AppointmentType In Me.WorkingAppointmentTypeCollection
          Call Me.lstMembers.Items.Add(AppointmentType.Text)
        Next
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click

      Try
        'Check if there is an item selected
        If lstMembers.SelectedItem Is Nothing Then Return

        'If already first, skip out
        Dim index As Integer = lstMembers.SelectedIndex
        If index = -1 Then Return

        'Raise event for cancel
        Changed = False
        Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs(Me.WorkingAppointmentTypeCollection, index, index - 1)
        Me.DialogSettings.OnMoveUpButtonClick(eventParam)
        If eventParam.Cancel Then Return
        'If the collection was modified then do not proceed
        If Changed Then Return

        Dim AppointmentType As AppointmentType = WorkingAppointmentTypeCollection(index)
        WorkingAppointmentTypeCollection.SetIndex(index, index - 1)
        'Call WorkingAppointmentTypeCollection.RemoveAt(index)
        'Call WorkingAppointmentTypeCollection.AddObject(AppointmentType, index - 1)
        Call RefreshForm()
        lstMembers.SelectedIndex = index - 1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown.Click

      Try
        'Check if there is an item selected
        If lstMembers.SelectedItem Is Nothing Then Return

        'If already last, skip out
        Dim index As Integer = lstMembers.SelectedIndex
        If index = lstMembers.Items.Count - 1 Then Return

        'Raise event for cancel
        Changed = False
        Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs(Me.WorkingAppointmentTypeCollection, index, index + 1)
        Me.DialogSettings.OnMoveDownButtonClick(eventParam)
        If eventParam.Cancel Then Return
        'If the collection was modified then do not proceed
        If Changed Then Return

        Dim AppointmentType As AppointmentType = WorkingAppointmentTypeCollection(index)
        WorkingAppointmentTypeCollection.SetIndex(index, index + 1)
        'Call WorkingAppointmentTypeCollection.RemoveAt(index)
        'Call WorkingAppointmentTypeCollection.AddObject(AppointmentType, index + 1)
        Call RefreshForm()
        lstMembers.SelectedIndex = index + 1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

      Try

        'Raise event for cancel
        Changed = False
        Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs(Me.WorkingAppointmentTypeCollection)
        Me.DialogSettings.OnAddButtonClick(eventParam)
        If eventParam.Cancel Then Return
        'If the collection was modified then do not proceed
        If Changed Then Return

        Dim AppointmentType As Gravitybox.Objects.AppointmentType = WorkingAppointmentTypeCollection.Add("", GetNewName)
        DirtyKeys.Add(AppointmentType.Key, AppointmentType.Key)
        Call Me.lstMembers.Items.Add(AppointmentType.Text)
        Me.lstMembers.SelectedItem = Me.lstMembers.Items(WorkingAppointmentTypeCollection.IndexOf(AppointmentType))
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

      Try
        If Not (Me.lstMembers.SelectedItem Is Nothing) Then

          Dim index As Integer = Me.lstMembers.SelectedIndex

          'Raise event for cancel
          Changed = False
          Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs(Me.WorkingAppointmentTypeCollection, index, -1)
          Me.DialogSettings.OnDeleteButtonClick(eventParam)
          If eventParam.Cancel Then Return
          'If the collection was modified then do not proceed
          If Changed Then Return

          Me.WorkingAppointmentTypeCollection.RemoveAt(index)
          Call RefreshForm()
          If Me.lstMembers.Items.Count = 0 Then
            PropertyGrid1.SelectedObject = Nothing
          ElseIf index > (Me.lstMembers.Items.Count - 1) Then
            index = Me.lstMembers.Items.Count - 1
            Me.lstMembers.SelectedIndex = index
          Else
            Me.lstMembers.SelectedIndex = index
          End If
          Call EnableButtons()

        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

      Try

        'Raise event for cancel
        Changed = False
        Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs(Me.WorkingAppointmentTypeCollection)
        Me.DialogSettings.OnOKButtonClick(eventParam)
        If eventParam.Cancel Then Return

        Call SaveForm()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Call Me.Close()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

      Try
        'Raise event for cancel
        Changed = False
        Dim eventParam As New Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs(Me.WorkingAppointmentTypeCollection)
        Me.DialogSettings.OnCancelButtonClick(eventParam)
        If eventParam.Cancel Then Return

        Call Me.Close()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub AppointmentTypeConfigForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Try
        lblMembers.BackColor = System.Drawing.SystemColors.Control
        lblProperties.BackColor = System.Drawing.SystemColors.Control
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub SaveForm()

      Try
        AppointmentTypeCollection.UpdateCollection(WorkingAppointmentTypeCollection, DirtyKeys)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Function GetNewName() As String

      Try
        Dim BaseName As String = MainObject.AppointmentTypeCollection.ObjectSingular
        Dim ii As Integer = 1
        Dim text As String = ""
        text = BaseName & ii
        Do While (lstMembers.FindString(text) <> -1)
          ii += 1
          text = BaseName & ii
        Loop
        Return text

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Private Sub LoadObject(ByVal AppointmentTypeIndex As Integer)

      Try
        'Index Key, Parent, PropertyItemCollection
        Me.PropertyGrid1.SelectedObject = WorkingAppointmentTypeCollection(AppointmentTypeIndex)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub lstMembers_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMembers.SelectedValueChanged

      Try
        Call LoadObject(lstMembers.SelectedIndex)
        Call EnableButtons()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub EnableButtons()

      Try
        If Me.lstMembers.SelectedIndex = -1 Then
          Me.cmdDown.Enabled = False
          Me.cmdUp.Enabled = False
          Me.cmdDelete.Enabled = False
        Else
          Me.cmdDown.Enabled = (Me.lstMembers.SelectedIndex < Me.lstMembers.Items.Count - 1)
          Me.cmdUp.Enabled = (Me.lstMembers.SelectedIndex > 0)
          Me.cmdDelete.Enabled = (Me.lstMembers.SelectedIndex <> -1)
        End If

        If Me.cmdUp.Enabled Then
          Me.cmdUp.Image = (New Icon(GetProjectFileAsStream("up.ico"))).ToBitmap
        Else
          Me.cmdUp.Image = (New Icon(GetProjectFileAsStream("up.disabled.ico"))).ToBitmap
        End If
        If Me.cmdDown.Enabled Then
          Me.cmdDown.Image = (New Icon(GetProjectFileAsStream("down.ico"))).ToBitmap
        Else
          Me.cmdDown.Image = (New Icon(GetProjectFileAsStream("down.disabled.ico"))).ToBitmap
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged

      Try
        If lstMembers.SelectedIndex <> -1 Then
          Dim index As Integer = lstMembers.SelectedIndex
          Dim element As AppointmentType = Me.WorkingAppointmentTypeCollection(lstMembers.SelectedIndex)
          If Not DirtyKeys.Contains(element.Key) Then DirtyKeys.Add(element.Key, element.Key)
          Dim text As String = element.Text
          If (CType(lstMembers.SelectedItem, String) <> text) Then
            lstMembers.Items.Insert(index, element.Text)
            lstMembers.SelectedIndex = index
            Call lstMembers.Items.RemoveAt(index + 1)
          End If
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace