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
Imports Gravitybox.Controls

Namespace Gravitybox.Forms

	Friend Class ResourceForm
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
		Friend WithEvents cmdOK As System.Windows.Forms.Button
		Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lstList As System.Windows.Forms.CheckedListBox
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdOK = New System.Windows.Forms.Button
      Me.cmdCancel = New System.Windows.Forms.Button
      Me.lstList = New System.Windows.Forms.CheckedListBox
      Me.SuspendLayout()
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(238, 192)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(88, 24)
      Me.cmdOK.TabIndex = 0
      Me.cmdOK.Text = "Ok"
      '
      'cmdCancel
      '
      Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCancel.Location = New System.Drawing.Point(334, 192)
      Me.cmdCancel.Name = "cmdCancel"
      Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
      Me.cmdCancel.TabIndex = 1
      Me.cmdCancel.Text = "Cancel"
      '
      'lstList
      '
      Me.lstList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstList.CheckOnClick = True
      Me.lstList.IntegralHeight = False
      Me.lstList.Location = New System.Drawing.Point(8, 8)
      Me.lstList.Name = "lstList"
      Me.lstList.ScrollAlwaysVisible = True
      Me.lstList.Size = New System.Drawing.Size(414, 176)
      Me.lstList.TabIndex = 2
      '
      'ResourceForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(432, 221)
      Me.Controls.Add(Me.lstList)
      Me.Controls.Add(Me.cmdCancel)
      Me.Controls.Add(Me.cmdOK)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(320, 160)
      Me.Name = "ResourceForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Select Resources"
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

		Private m_ResourceCollection As ResourceCollection
		Private m_Appointment As Appointment
		Private m_DialogSettings As ResourceDialogSettings
		Friend MainObject As Schedule

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

		Public Property ResourceCollection() As ResourceCollection
			Get
				Return m_ResourceCollection
			End Get
			Set(ByVal Value As ResourceCollection)
				m_ResourceCollection = Value
				Call RefreshForm()
			End Set
		End Property

		Public Property Appointment() As Appointment
			Get
				Return m_Appointment
			End Get
			Set(ByVal Value As Appointment)
				m_Appointment = Value
				Call RefreshForm()
			End Set
		End Property

		Public Property DialogSettings() As ResourceDialogSettings
			Get
				Return m_DialogSettings
			End Get
			Set(ByVal Value As ResourceDialogSettings)

				m_DialogSettings = Value
				Try
					Me.Text = DialogSettings.WindowText
					Me.Icon = Me.DialogSettings.Icon
					Me.cmdOK.Text = DialogSettings.OkButtonText
					Me.cmdCancel.Text = DialogSettings.CancelButtonText
					Me.FormBorderStyle = DialogSettings.FormBorderStyle
					Me.StartPosition = DialogSettings.StartPosition
					Me.Location = DialogSettings.Location
					Me.Size = DialogSettings.Size

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Set
		End Property

#End Region

#Region "Methods"

		Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

			Try

				'Save the checked items to the current appointment
				Dim ii As Integer
				Call Appointment.ResourceList.Clear()
				For ii = 0 To lstList.CheckedItems.Count - 1
					Call Appointment.ResourceList.Add(Me.ResourceCollection(lstList.Items.IndexOf(lstList.CheckedItems(ii))))
				Next

				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Call Me.Close()

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

		Private Sub RefreshForm()

			Try
				If Me.ResourceCollection Is Nothing Then Return
				If Me.Appointment Is Nothing Then Return

				'Load the list with items
				Dim resource As resource
				Call lstList.Items.Clear()
				For Each resource In Me.ResourceCollection
					Call lstList.Items.Add(resource.Text, Appointment.ResourceList.Contains(resource))
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ResourceForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

			Try
				If Not (MainObject Is Nothing) Then
					MainObject.Dialogs.DialogResourceBounds = New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ResourceForm_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Move
			If Not (MainObject Is Nothing) Then
				MainObject.Dialogs.DialogResourceBounds = New Rectangle(Me.Left, Me.Top, Me.Width, Me.Height)
			End If
		End Sub

#End Region

	End Class

End Namespace