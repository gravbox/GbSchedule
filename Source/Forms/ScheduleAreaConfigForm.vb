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

  Friend Class ScheduleAreaConfigForm
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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lvwItem As System.Windows.Forms.ListView
    Friend WithEvents cboRoom As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvider As System.Windows.Forms.ComboBox
    Friend WithEvents cmdDown As System.Windows.Forms.Button
    Friend WithEvents cmdUp As System.Windows.Forms.Button
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents chkTime As System.Windows.Forms.CheckBox
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents chkRoom As System.Windows.Forms.CheckBox
    Friend WithEvents chkProvider As System.Windows.Forms.CheckBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLength As System.Windows.Forms.TextBox
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.cmdCancel = New System.Windows.Forms.Button
      Me.cmdOK = New System.Windows.Forms.Button
      Me.lblLine = New System.Windows.Forms.Label
      Me.lvwItem = New System.Windows.Forms.ListView
      Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
      Me.chkDate = New System.Windows.Forms.CheckBox
      Me.chkTime = New System.Windows.Forms.CheckBox
      Me.lblLength = New System.Windows.Forms.Label
      Me.chkRoom = New System.Windows.Forms.CheckBox
      Me.chkProvider = New System.Windows.Forms.CheckBox
      Me.dtpDate = New System.Windows.Forms.DateTimePicker
      Me.dtpTime = New System.Windows.Forms.DateTimePicker
      Me.txtLength = New System.Windows.Forms.TextBox
      Me.cboRoom = New System.Windows.Forms.ComboBox
      Me.cboProvider = New System.Windows.Forms.ComboBox
      Me.cmdDown = New System.Windows.Forms.Button
      Me.cmdUp = New System.Windows.Forms.Button
      Me.cmdDelete = New System.Windows.Forms.Button
      Me.cmdAdd = New System.Windows.Forms.Button
      Me.SuspendLayout()
      '
      'cmdCancel
      '
      Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdCancel.Location = New System.Drawing.Point(472, 272)
      Me.cmdCancel.Name = "cmdCancel"
      Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
      Me.cmdCancel.TabIndex = 14
      Me.cmdCancel.Text = "Cancel"
      '
      'cmdOK
      '
      Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(384, 272)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(80, 24)
      Me.cmdOK.TabIndex = 13
      Me.cmdOK.Text = "OK"
      '
      'lblLine
      '
      Me.lblLine.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLine.BackColor = System.Drawing.Color.Black
      Me.lblLine.Location = New System.Drawing.Point(8, 264)
      Me.lblLine.Name = "lblLine"
      Me.lblLine.Size = New System.Drawing.Size(542, 1)
      Me.lblLine.TabIndex = 27
      '
      'lvwItem
      '
      Me.lvwItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwItem.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
      Me.lvwItem.FullRowSelect = True
      Me.lvwItem.Location = New System.Drawing.Point(8, 112)
      Me.lvwItem.MultiSelect = False
      Me.lvwItem.Name = "lvwItem"
      Me.lvwItem.Size = New System.Drawing.Size(512, 144)
      Me.lvwItem.TabIndex = 10
      Me.lvwItem.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Start Date"
      Me.ColumnHeader1.Width = 100
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Start Time"
      Me.ColumnHeader2.Width = 100
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Length"
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Room"
      Me.ColumnHeader4.Width = 120
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Provider"
      Me.ColumnHeader5.Width = 120
      '
      'chkDate
      '
      Me.chkDate.Location = New System.Drawing.Point(16, 16)
      Me.chkDate.Name = "chkDate"
      Me.chkDate.Size = New System.Drawing.Size(120, 16)
      Me.chkDate.TabIndex = 0
      Me.chkDate.Text = "Start date:"
      '
      'chkTime
      '
      Me.chkTime.Location = New System.Drawing.Point(288, 16)
      Me.chkTime.Name = "chkTime"
      Me.chkTime.Size = New System.Drawing.Size(120, 16)
      Me.chkTime.TabIndex = 6
      Me.chkTime.Text = "Start time:"
      '
      'lblLength
      '
      Me.lblLength.Location = New System.Drawing.Point(320, 40)
      Me.lblLength.Name = "lblLength"
      Me.lblLength.Size = New System.Drawing.Size(88, 16)
      Me.lblLength.TabIndex = 31
      Me.lblLength.Text = "Length:"
      '
      'chkRoom
      '
      Me.chkRoom.Location = New System.Drawing.Point(16, 40)
      Me.chkRoom.Name = "chkRoom"
      Me.chkRoom.Size = New System.Drawing.Size(120, 16)
      Me.chkRoom.TabIndex = 2
      Me.chkRoom.Text = "Room:"
      '
      'chkProvider
      '
      Me.chkProvider.Location = New System.Drawing.Point(16, 64)
      Me.chkProvider.Name = "chkProvider"
      Me.chkProvider.Size = New System.Drawing.Size(120, 16)
      Me.chkProvider.TabIndex = 4
      Me.chkProvider.Text = "Provider:"
      '
      'dtpDate
      '
      Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDate.Location = New System.Drawing.Point(152, 16)
      Me.dtpDate.Name = "dtpDate"
      Me.dtpDate.Size = New System.Drawing.Size(128, 20)
      Me.dtpDate.TabIndex = 1
      '
      'dtpTime
      '
      Me.dtpTime.CustomFormat = "HH:mm"
      Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpTime.Location = New System.Drawing.Point(424, 16)
      Me.dtpTime.Name = "dtpTime"
      Me.dtpTime.Size = New System.Drawing.Size(128, 20)
      Me.dtpTime.TabIndex = 3
      '
      'txtLength
      '
      Me.txtLength.Location = New System.Drawing.Point(424, 40)
      Me.txtLength.MaxLength = 3
      Me.txtLength.Name = "txtLength"
      Me.txtLength.Size = New System.Drawing.Size(48, 20)
      Me.txtLength.TabIndex = 7
      Me.txtLength.Text = "30"
      Me.txtLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cboRoom
      '
      Me.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboRoom.Location = New System.Drawing.Point(152, 40)
      Me.cboRoom.Name = "cboRoom"
      Me.cboRoom.Size = New System.Drawing.Size(128, 21)
      Me.cboRoom.TabIndex = 3
      '
      'cboProvider
      '
      Me.cboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboProvider.Location = New System.Drawing.Point(152, 64)
      Me.cboProvider.Name = "cboProvider"
      Me.cboProvider.Size = New System.Drawing.Size(128, 21)
      Me.cboProvider.TabIndex = 5
      '
      'cmdDown
      '
      Me.cmdDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDown.Location = New System.Drawing.Point(528, 144)
      Me.cmdDown.Name = "cmdDown"
      Me.cmdDown.Size = New System.Drawing.Size(24, 24)
      Me.cmdDown.TabIndex = 12
      '
      'cmdUp
      '
      Me.cmdUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdUp.Location = New System.Drawing.Point(528, 112)
      Me.cmdUp.Name = "cmdUp"
      Me.cmdUp.Size = New System.Drawing.Size(24, 24)
      Me.cmdUp.TabIndex = 11
      '
      'cmdDelete
      '
      Me.cmdDelete.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdDelete.Location = New System.Drawing.Point(488, 72)
      Me.cmdDelete.Name = "cmdDelete"
      Me.cmdDelete.Size = New System.Drawing.Size(64, 24)
      Me.cmdDelete.TabIndex = 9
      Me.cmdDelete.Text = "Delete"
      '
      'cmdAdd
      '
      Me.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAdd.Location = New System.Drawing.Point(416, 72)
      Me.cmdAdd.Name = "cmdAdd"
      Me.cmdAdd.Size = New System.Drawing.Size(64, 24)
      Me.cmdAdd.TabIndex = 8
      Me.cmdAdd.Text = "Add"
      '
      'ScheduleAreaConfigForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(562, 303)
      Me.Controls.Add(Me.cmdDelete)
      Me.Controls.Add(Me.cmdAdd)
      Me.Controls.Add(Me.cmdUp)
      Me.Controls.Add(Me.cboProvider)
      Me.Controls.Add(Me.cboRoom)
      Me.Controls.Add(Me.txtLength)
      Me.Controls.Add(Me.dtpTime)
      Me.Controls.Add(Me.dtpDate)
      Me.Controls.Add(Me.chkProvider)
      Me.Controls.Add(Me.chkRoom)
      Me.Controls.Add(Me.lblLength)
      Me.Controls.Add(Me.chkTime)
      Me.Controls.Add(Me.chkDate)
      Me.Controls.Add(Me.lvwItem)
      Me.Controls.Add(Me.cmdCancel)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.lblLine)
      Me.Controls.Add(Me.cmdDown)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ScheduleAreaConfigForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Schedule Area Configuration"
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Private m_ScheduleAreaCollection As ScheduleAreaCollection
    Private WorkingScheduleAreaCollection As ScheduleAreaCollection
    Private m_MainObject As Gravitybox.Controls.Schedule
		Private DirtyKeys As New Hashtable	 'The objects that were added or edited
		Dim Changed As Boolean = False

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public Property MainObject() As Gravitybox.Controls.Schedule
      Get
        Return m_MainObject
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule)
        m_MainObject = Value
        WorkingScheduleAreaCollection = New ScheduleAreaCollection(MainObject)

        'Setup the time format
        If MainObject.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12 Then
          dtpTime.CustomFormat = "hh:mm tt"
        ElseIf MainObject.ClockSetting = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12 Then
          dtpTime.CustomFormat = "HH:mm"
        End If

        'Setup the date pattern
        dtpTime.CustomFormat = System.Globalization.DateTimeFormatInfo.CurrentInfo.ShortDatePattern

        'Load Rooms
        Dim room As room
        For Each room In MainObject.RoomCollection
          cboRoom.Items.Add(room.ToString)
        Next

        'Load Providers
        Dim provider As Provider = Nothing
        For Each room In MainObject.ProviderCollection
          cboProvider.Items.Add(provider.ToString)
        Next

        AddHandler WorkingScheduleAreaCollection.Refresh, AddressOf OnRefresh

        MsgBox("Do not run this form as it is incomplete!")

      End Set
    End Property

    Public Property ScheduleAreaCollection() As ScheduleAreaCollection
      Get
        Return m_ScheduleAreaCollection
      End Get
      Set(ByVal Value As ScheduleAreaCollection)
        m_ScheduleAreaCollection = Value

        Try
          'Load a working collection with objects
          Call WorkingScheduleAreaCollection.FromXML(Me.ScheduleAreaCollection.ToXML)
          Call RefreshForm()
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
				Dim lastSelected As Integer = -1
				If lvwItem.SelectedItems.Count > 0 Then
					lastSelected = lvwItem.SelectedItems(0).Index
				End If

				Dim area As ScheduleArea
				For Each area In Me.WorkingScheduleAreaCollection
					Dim listitem As New ListViewItem

					'Check to add date
					If area.StartDate = DefaultNoDate Then
						listitem.Text = area.StartDate.ToShortDateString()
					Else
						listitem.Text = "---"
					End If

					'Check to add time
					If area.StartTime = DefaultNoTime Then
						listitem.SubItems.Add(GetTime(dtpTime.Value).ToShortTimeString())
						listitem.SubItems.Add(GetIntlInteger(txtLength.Text).ToString)
					Else
						listitem.SubItems.Add("---")
						listitem.SubItems.Add("---")
					End If

					'Check to add room
					If area.Room <> -1 Then
						listitem.SubItems.Add(MainObject.RoomCollection(area.Room).ToString)
					Else
						listitem.SubItems.Add("---")
					End If

					'Check to add provider
					If area.Provider <> -1 Then
						listitem.SubItems.Add(MainObject.ProviderCollection(area.Provider).ToString)
					Else
						listitem.SubItems.Add("---")
					End If

					'Add the listitem
					lvwItem.Items.Add(listitem)

				Next

				'Hilite
				If lastSelected >= lvwItem.Items.Count Then lastSelected = lvwItem.Items.Count - 1
				If lastSelected <> -1 Then lvwItem.Items(lastSelected).Selected = True

				Call EnableControls()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUp.Click

			Try
				'Check if there is an item selected
				If lvwItem.SelectedItems.Count = 0 Then Return

				'If already first, skip out
				Dim index As Integer = lvwItem.SelectedItems(0).Index
				If index = -1 Then Return

				Dim ScheduleArea As ScheduleArea = WorkingScheduleAreaCollection(index)
				Call WorkingScheduleAreaCollection.RemoveAt(index)
				Call WorkingScheduleAreaCollection.AddObject(ScheduleArea, index - 1)
				Call RefreshForm()
				lvwItem.Items(index - 1).Selected = True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDown.Click

			Try
				'Check if there is an item selected
				If lvwItem.SelectedItems.Count = 0 Then Return

				'If already last, skip out
				Dim index As Integer = lvwItem.SelectedItems(0).Index
				If index = lvwItem.Items.Count - 1 Then Return

				Dim ScheduleArea As ScheduleArea = WorkingScheduleAreaCollection(index)
				Call WorkingScheduleAreaCollection.RemoveAt(index)
				Call WorkingScheduleAreaCollection.AddObject(ScheduleArea, index + 1)
				Call RefreshForm()
				lvwItem.Items(index + 1).Selected = True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click

			Try
				Dim startDate As Date = Nothing
				Dim startTime As Date = Nothing
				Dim length As Integer = Nothing
				Dim room As room = Nothing
				Dim provider As provider = Nothing

				'Check to add date
				If chkDate.Checked Then
					startDate = dtpDate.Value
				End If

				'Check to add time
				If chkTime.Checked Then
					startTime = GetTime(dtpTime.Value)
					length = GetIntlInteger(txtLength.Text)
				End If

				'Check to add room
				If chkRoom.Checked And (cboRoom.SelectedIndex <> -1) Then
					room = MainObject.RoomCollection(cboRoom.SelectedIndex)
				End If

				'Check to add provider
				If chkProvider.Checked And (cboProvider.SelectedIndex <> -1) Then
					provider = MainObject.ProviderCollection(cboProvider.SelectedIndex)
				End If

				'Add the object
				Dim area As ScheduleArea = WorkingScheduleAreaCollection.Add("", Color.Blue, startDate, startTime, length, room, provider)
				DirtyKeys.Add(area.Key, area.Key)
				Call RefreshForm()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click

			Try
				If (lvwItem.SelectedItems.Count <> 0) Then
					Dim index As Integer = lvwItem.SelectedItems(0).Index
					Me.WorkingScheduleAreaCollection.RemoveAt(index)
					Call RefreshForm()
					If index > (lvwItem.Items.Count - 1) Then
						index = lvwItem.Items.Count - 1
						lvwItem.Items(index).Selected = True
					Else
						lvwItem.Items(index).Selected = True
					End If
					Call EnableControls()

				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

			Try
				Call SaveForm()
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Call Me.Close()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
			Call Me.Close()
		End Sub

		Private Sub ScheduleAreaConfigForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

			Try
				Call EnableControls()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SaveForm()

			Try
				ScheduleAreaCollection.UpdateCollection(WorkingScheduleAreaCollection, DirtyKeys)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub chkDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDate.CheckedChanged
			Call EnableControls()
		End Sub

		Private Sub chkTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTime.CheckedChanged
			Call EnableControls()
		End Sub

		Private Sub chkRoom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRoom.CheckedChanged
			Call EnableControls()
		End Sub

		Private Sub chkProvider_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkProvider.CheckedChanged
			Call EnableControls()
		End Sub

		Private Sub EnableControls()

			chkRoom.Enabled = (cboRoom.Items.Count > 0)
			If Not chkRoom.Enabled Then chkRoom.Checked = False
			chkProvider.Enabled = (cboProvider.Items.Count > 0)
			If Not chkProvider.Enabled Then chkProvider.Checked = False

			Dim somethingChecked As Boolean = chkDate.Checked Or chkTime.Checked Or chkRoom.Enabled Or chkProvider.Enabled
			dtpDate.Enabled = chkDate.Checked
			dtpTime.Enabled = chkTime.Checked
			lblLength.Enabled = chkTime.Checked
			cboRoom.Enabled = chkRoom.Checked
			cboProvider.Enabled = chkProvider.Checked

			If lvwItem.SelectedItems.Count = 0 Then
				Me.cmdDown.Enabled = False
				Me.cmdUp.Enabled = False
				Me.cmdDelete.Enabled = False
			Else
				Me.cmdDown.Enabled = (lvwItem.SelectedItems(0).Index < lvwItem.Items.Count - 1)
				Me.cmdUp.Enabled = (lvwItem.SelectedItems(0).Index > 0)
				Me.cmdDelete.Enabled = (lvwItem.SelectedItems(0).Index <> -1)
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

			Me.cmdDelete.Enabled = (lvwItem.SelectedItems.Count <> 0)
			Me.cmdAdd.Enabled = somethingChecked

		End Sub

		Private Sub txtLength_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtLength.Validating

			Try
				Dim i As Integer = GetIntlInteger(txtLength.Text)
				If i <= 0 Then i = 1
				txtLength.Text = i.ToString
			Catch ex As Exception
				'Error so default standard time increment
				txtLength.Text = MainObject.TimeIncrement.ToString("d")
			End Try

		End Sub

#End Region

  End Class

End Namespace