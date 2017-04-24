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

  Friend Class AppointmentPropertiesForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Friend Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      m_Key = Guid.NewGuid.ToString

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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents AppointmentProperties1 As Gravitybox.Controls.AppointmentProperties
    Friend WithEvents txtNotes As System.Windows.Forms.TextBox
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents cmdSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdFlag As System.Windows.Forms.ToolBarButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdFileAdd As System.Windows.Forms.Button
    Friend WithEvents cmdFileDelete As System.Windows.Forms.Button
    Friend WithEvents hdrName As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrFolder As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents hdrModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwFile As System.Windows.Forms.ListView
    Friend WithEvents Dialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdRecurrence As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdPrevious As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmdNext As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AppointmentPropertiesForm))
			Me.TabControl1 = New System.Windows.Forms.TabControl
			Me.TabPage1 = New System.Windows.Forms.TabPage
			Me.AppointmentProperties1 = New Gravitybox.Controls.AppointmentProperties
			Me.TabPage2 = New System.Windows.Forms.TabPage
			Me.txtNotes = New System.Windows.Forms.TextBox
			Me.TabPage3 = New System.Windows.Forms.TabPage
			Me.Panel1 = New System.Windows.Forms.Panel
			Me.cmdFileDelete = New System.Windows.Forms.Button
			Me.cmdFileAdd = New System.Windows.Forms.Button
			Me.lvwFile = New System.Windows.Forms.ListView
			Me.hdrName = New System.Windows.Forms.ColumnHeader
			Me.hdrFolder = New System.Windows.Forms.ColumnHeader
			Me.hdrSize = New System.Windows.Forms.ColumnHeader
			Me.hdrModified = New System.Windows.Forms.ColumnHeader
			Me.ToolBar1 = New System.Windows.Forms.ToolBar
			Me.cmdSave = New System.Windows.Forms.ToolBarButton
			Me.cmdSep1 = New System.Windows.Forms.ToolBarButton
			Me.cmdRecurrence = New System.Windows.Forms.ToolBarButton
			Me.cmdSep2 = New System.Windows.Forms.ToolBarButton
			Me.cmdDelete = New System.Windows.Forms.ToolBarButton
			Me.cmdFlag = New System.Windows.Forms.ToolBarButton
			Me.cmdPrevious = New System.Windows.Forms.ToolBarButton
			Me.cmdNext = New System.Windows.Forms.ToolBarButton
			Me.Dialog1 = New System.Windows.Forms.OpenFileDialog
			Me.TabControl1.SuspendLayout()
			Me.TabPage1.SuspendLayout()
			Me.TabPage2.SuspendLayout()
			Me.TabPage3.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.SuspendLayout()
			'
			'TabControl1
			'
			Me.TabControl1.Controls.Add(Me.TabPage1)
			Me.TabControl1.Controls.Add(Me.TabPage2)
			Me.TabControl1.Controls.Add(Me.TabPage3)
			Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.TabControl1.Location = New System.Drawing.Point(0, 28)
			Me.TabControl1.Name = "TabControl1"
			Me.TabControl1.SelectedIndex = 0
			Me.TabControl1.Size = New System.Drawing.Size(546, 363)
			Me.TabControl1.TabIndex = 2
			'
			'TabPage1
			'
			Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
			Me.TabPage1.Controls.Add(Me.AppointmentProperties1)
			Me.TabPage1.Location = New System.Drawing.Point(4, 22)
			Me.TabPage1.Name = "TabPage1"
			Me.TabPage1.Size = New System.Drawing.Size(538, 337)
			Me.TabPage1.TabIndex = 0
			Me.TabPage1.Text = "General"
			'
			'AppointmentProperties1
			'
			Me.AppointmentProperties1.Appointment = Nothing
			Me.AppointmentProperties1.BackColor = System.Drawing.Color.Transparent
			Me.AppointmentProperties1.CategoryEditMode = Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants.Fixed
			Me.AppointmentProperties1.Enabled = False
			Me.AppointmentProperties1.EnforceBounds = True
			Me.AppointmentProperties1.Location = New System.Drawing.Point(8, 8)
			Me.AppointmentProperties1.Name = "AppointmentProperties1"
			Me.AppointmentProperties1.ScheduleObject = Nothing
			Me.AppointmentProperties1.Size = New System.Drawing.Size(528, 347)
			Me.AppointmentProperties1.SubjectLength = 32767
			Me.AppointmentProperties1.TabIndex = 0
			Me.AppointmentProperties1.TextLength = 32767
			Me.AppointmentProperties1.TimeDisplay = Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants.EndTime
			Me.AppointmentProperties1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
			'
			'TabPage2
			'
			Me.TabPage2.Controls.Add(Me.txtNotes)
			Me.TabPage2.Location = New System.Drawing.Point(4, 22)
			Me.TabPage2.Name = "TabPage2"
			Me.TabPage2.Size = New System.Drawing.Size(538, 337)
			Me.TabPage2.TabIndex = 1
			Me.TabPage2.Text = "Notes"
			'
			'txtNotes
			'
			Me.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill
			Me.txtNotes.Location = New System.Drawing.Point(0, 0)
			Me.txtNotes.Multiline = True
			Me.txtNotes.Name = "txtNotes"
			Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txtNotes.Size = New System.Drawing.Size(538, 337)
			Me.txtNotes.TabIndex = 3
			'
			'TabPage3
			'
			Me.TabPage3.Controls.Add(Me.Panel1)
			Me.TabPage3.Controls.Add(Me.lvwFile)
			Me.TabPage3.Location = New System.Drawing.Point(4, 22)
			Me.TabPage3.Name = "TabPage3"
			Me.TabPage3.Size = New System.Drawing.Size(538, 337)
			Me.TabPage3.TabIndex = 2
			Me.TabPage3.Text = "Files"
			'
			'Panel1
			'
			Me.Panel1.BackColor = System.Drawing.Color.Transparent
			Me.Panel1.Controls.Add(Me.cmdFileDelete)
			Me.Panel1.Controls.Add(Me.cmdFileAdd)
			Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.Panel1.Location = New System.Drawing.Point(0, 313)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(538, 24)
			Me.Panel1.TabIndex = 4
			'
			'cmdFileDelete
			'
			Me.cmdFileDelete.Dock = System.Windows.Forms.DockStyle.Right
			Me.cmdFileDelete.Location = New System.Drawing.Point(474, 0)
			Me.cmdFileDelete.Name = "cmdFileDelete"
			Me.cmdFileDelete.Size = New System.Drawing.Size(64, 24)
			Me.cmdFileDelete.TabIndex = 1
			Me.cmdFileDelete.Text = "Delete"
			'
			'cmdFileAdd
			'
			Me.cmdFileAdd.Anchor = System.Windows.Forms.AnchorStyles.Right
			Me.cmdFileAdd.Location = New System.Drawing.Point(408, 0)
			Me.cmdFileAdd.Name = "cmdFileAdd"
			Me.cmdFileAdd.Size = New System.Drawing.Size(64, 24)
			Me.cmdFileAdd.TabIndex = 0
			Me.cmdFileAdd.Text = "Add"
			'
			'lvwFile
			'
			Me.lvwFile.AllowDrop = True
			Me.lvwFile.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.lvwFile.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.hdrName, Me.hdrFolder, Me.hdrSize, Me.hdrModified})
			Me.lvwFile.Location = New System.Drawing.Point(0, 0)
			Me.lvwFile.Name = "lvwFile"
			Me.lvwFile.Size = New System.Drawing.Size(538, 309)
			Me.lvwFile.TabIndex = 3
      'Me.lvwFile.UseCompatibleStateImageBehavior = False
			Me.lvwFile.View = System.Windows.Forms.View.Details
			'
			'hdrName
			'
			Me.hdrName.Text = "Name"
			Me.hdrName.Width = 234
			'
			'hdrFolder
			'
			Me.hdrFolder.Text = "In Folder"
			'
			'hdrSize
			'
			Me.hdrSize.Text = "Size"
			'
			'hdrModified
			'
			Me.hdrModified.Text = "Modified"
			'
			'ToolBar1
			'
			Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
			Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.cmdSave, Me.cmdSep1, Me.cmdRecurrence, Me.cmdSep2, Me.cmdDelete, Me.cmdFlag, Me.cmdPrevious, Me.cmdNext})
			Me.ToolBar1.DropDownArrows = True
			Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
			Me.ToolBar1.Name = "ToolBar1"
			Me.ToolBar1.ShowToolTips = True
			Me.ToolBar1.Size = New System.Drawing.Size(546, 28)
			Me.ToolBar1.TabIndex = 1
			'
			'cmdSave
			'
      'Me.cmdSave.Name = "cmdSave"
			'
			'cmdSep1
			'
      'Me.cmdSep1.Name = "cmdSep1"
			Me.cmdSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
			'
			'cmdRecurrence
			'
      'Me.cmdRecurrence.Name = "cmdRecurrence"
			'
			'cmdSep2
			'
      'Me.cmdSep2.Name = "cmdSep2"
			Me.cmdSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
			'
			'cmdDelete
			'
      'Me.cmdDelete.Name = "cmdDelete"
			'
			'cmdFlag
			'
      'Me.cmdFlag.Name = "cmdFlag"
			Me.cmdFlag.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
			'
			'cmdPrevious
			'
      'Me.cmdPrevious.Name = "cmdPrevious"
			'
			'cmdNext
			'
      'Me.cmdNext.Name = "cmdNext"
			'
			'Dialog1
			'
			Me.Dialog1.AddExtension = False
			'
			'AppointmentPropertiesForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.SystemColors.Control
			Me.ClientSize = New System.Drawing.Size(546, 391)
			Me.Controls.Add(Me.TabControl1)
			Me.Controls.Add(Me.ToolBar1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(552, 416)
			Me.Name = "AppointmentPropertiesForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
			Me.Text = "Appointment"
			Me.TabControl1.ResumeLayout(False)
			Me.TabPage1.ResumeLayout(False)
			Me.TabPage2.ResumeLayout(False)
			Me.TabPage2.PerformLayout()
			Me.TabPage3.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

#End Region

#Region "Class Members"

    'Property Variables
    Private m_Appointment As Appointment
    Private m_ReturnValues As ReturnValues
    Private m_Key As String
    Private m_DialogSettings As AppointmentDialogSettings
    Private m_ScheduleObject As Gravitybox.Controls.Schedule
    Private m_RemoveOnCancel As Boolean = False

    'Private Objects
    Private Recurrence As Recurrence
    Private UseRecurrence As Boolean = False
    Private AppointmentList As AppointmentList
    Private focusProcessed As Boolean = False
		Private ImageList1 As New Windows.Forms.ImageList
		Private SaveSuccess As Boolean = False

#End Region

#Region "Form Handlers"

#If VS2005 Then
		Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

			ToolBar1.ImageList = Nothing
			lvwFile.SmallImageList = Nothing
			m_Appointment = Nothing
			m_ReturnValues = Nothing
			m_DialogSettings = Nothing
			m_ScheduleObject = Nothing
			Recurrence = Nothing
			AppointmentList.Clear()
			AppointmentList = Nothing
			ImageList1.Dispose()
			ImageList1 = Nothing

			AppointmentProperties1.Dispose()

			'Me.Dispose()
			'GC.Collect()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public Property Appointment() As Appointment
      Get
        Return m_Appointment
      End Get
      Set(ByVal Value As Appointment)
        m_Appointment = Value

        'Add event handler to refresh the collection each time an appointment is added/removed
        AddHandler ScheduleObject.AppointmentCollection.AfterAdd, AddressOf CollectionRefresh
        AddHandler ScheduleObject.AppointmentCollection.AfterRemove, AddressOf CollectionRefresh
        Call CollectionRefresh(Nothing, Nothing)

        Me.AppointmentProperties1.Appointment = Appointment
        Call LoadFiles()
        ToolBar1.Buttons(5).Pushed = Appointment.IsFlagged
        Me.txtNotes.Text = Appointment.Notes
        Call UpdateToobar()

      End Set
    End Property

    Friend Property ReturnValues() As ReturnValues
      Get
        Return m_ReturnValues
      End Get
      Set(ByVal Value As ReturnValues)
        m_ReturnValues = Value
      End Set
    End Property

    Public ReadOnly Property Key() As String
      Get
        Return m_Key
      End Get
    End Property

    Public Property DialogSettings() As AppointmentDialogSettings
      Get
        Return m_DialogSettings
      End Get
      Set(ByVal Value As AppointmentDialogSettings)
        m_DialogSettings = Value
        Try
          'Remove any elements that should not be displayed
          If Not DialogSettings.AllowRecurrence Then ToolBar1.Buttons(2).Visible = False
          If Not DialogSettings.AllowRemove Then ToolBar1.Buttons(4).Visible = False
          If Not DialogSettings.AllowFlag Then ToolBar1.Buttons(5).Visible = False
          If Not DialogSettings.AllowNavigate Then ToolBar1.Buttons(6).Visible = False
          If Not DialogSettings.AllowNavigate Then ToolBar1.Buttons(7).Visible = False
          If Not DialogSettings.AllowFiles Then TabControl1.TabPages.RemoveAt(2)
          If Not DialogSettings.AllowNotes Then TabControl1.TabPages.RemoveAt(1)

          Me.AppointmentProperties1.AllowAlarm = DialogSettings.AllowAlarm
          Me.AppointmentProperties1.AllowCategory = DialogSettings.AllowCategory And (ScheduleObject.CategoryCollection.Count > 0)
          Me.AppointmentProperties1.AllowPriority = DialogSettings.AllowPriority And (ScheduleObject.PriorityCollection.Count > 0)
          Me.AppointmentProperties1.AllowProvider = DialogSettings.AllowProvider And (ScheduleObject.ProviderCollection.VisibleCount > 0)
          Me.AppointmentProperties1.AllowResource = DialogSettings.AllowResource And (ScheduleObject.ResourceCollection.Count > 0)
          Me.AppointmentProperties1.AllowRoom = DialogSettings.AllowRoom
          Me.AppointmentProperties1.AllowAppointmentType = DialogSettings.AllowAppointmentType
          Me.AppointmentProperties1.AllowDate = DialogSettings.AllowDate
          Me.AppointmentProperties1.AllowSubject = DialogSettings.AllowSubject
          Me.AppointmentProperties1.AllowText = DialogSettings.AllowText
          Me.AppointmentProperties1.AllowTime = DialogSettings.AllowTime
          Me.AppointmentProperties1.AllowMasterCategories = DialogSettings.AllowMasterCategories
          Me.AppointmentProperties1.AllowEvents = DialogSettings.AllowEvents
          Me.AppointmentProperties1.WarningText = DialogSettings.WarningText
          Me.AppointmentProperties1.ClockSetting = Me.ScheduleObject.ClockSetting
          Me.AppointmentProperties1.TimeDisplay = DialogSettings.TimeDisplay
          Me.AppointmentProperties1.SubjectLength = DialogSettings.SubjectLength
          Me.AppointmentProperties1.TextLength = DialogSettings.TextLength
          Me.AppointmentProperties1.SubjectPrompt = DialogSettings.SubjectPrompt
          Me.AppointmentProperties1.StartTimePrompt = DialogSettings.StartTimePrompt
          Me.AppointmentProperties1.EventPrompt = DialogSettings.EventPrompt
          Me.AppointmentProperties1.ReminderPrompt = DialogSettings.ReminderPrompt
          Me.AppointmentProperties1.DurationPrompt = DialogSettings.DurationPrompt
          Me.AppointmentProperties1.PriorityPrompt = DialogSettings.PriorityPrompt
          Me.AppointmentProperties1.CategoryEditMode = DialogSettings.CategoryEditMode
          Me.AppointmentProperties1.TimeIncrement = DialogSettings.TimeIncrement
          Me.AppointmentProperties1.Refresh()

          Me.Text = DialogSettings.WindowText
          Me.FormBorderStyle = Me.DialogSettings.FormBorderStyle
          Me.StartPosition = Me.DialogSettings.StartPosition
          Me.Location = Me.DialogSettings.Location
          Me.Size = Me.DialogSettings.Size
          Me.Icon = Me.DialogSettings.Icon

          txtNotes.MaxLength = DialogSettings.NotesLength

          TabControl1.SelectedTab = TabControl1.TabPages(0)

          'Change the window style base on modality
          Me.MinimizeBox = Not DialogSettings.AllowModal
          Me.StartPosition = Me.DialogSettings.StartPosition
          Me.Location = Me.DialogSettings.Location
					Me.Size = Me.DialogSettings.Size

					Me.BackColor = Me.DialogSettings.Appearance.BackColor
					Me.Panel1.BackColor = Me.DialogSettings.Appearance.BackColor
					Me.AppointmentProperties1.Appearance = Me.DialogSettings.Appearance
					For Each page As TabPage In Me.TabControl1.TabPages
						page.BackColor = Me.DialogSettings.Appearance.BackColor
					Next

					Call ResizeForm()
					Call UpdateToobar()
					Me.AppointmentProperties1.Focus()

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
      End Set
    End Property

    Public Property ScheduleObject() As Gravitybox.Controls.Schedule
      Get
        Return m_ScheduleObject
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule)
        m_ScheduleObject = Value
        Me.AppointmentProperties1.ScheduleObject = Value

        'Setup Images
        ToolBar1.ImageList = ImageList1
        lvwFile.SmallImageList = ImageList1

        'Delete Button
        If ScheduleObject.ScheduleIcons.IconDelete Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("delete.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconDelete)
        End If
        cmdDelete.ImageIndex = ImageList1.Images.Count - 1

        'Flag Button
        If ScheduleObject.ScheduleIcons.IconFlag Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("flag.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconFlag)
        End If
        cmdFlag.ImageIndex = ImageList1.Images.Count - 1

        'Next Button
        If ScheduleObject.ScheduleIcons.IconNext Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("next.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconNext)
        End If
        cmdNext.ImageIndex = ImageList1.Images.Count - 1

        'Previous Button
        If ScheduleObject.ScheduleIcons.IconPrevious Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("previous.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconPrevious)
        End If
        cmdPrevious.ImageIndex = ImageList1.Images.Count - 1

        'Recur Button
        If ScheduleObject.ScheduleIcons.IconRecurrence Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("recur.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconRecurrence)
        End If
        cmdRecurrence.ImageIndex = ImageList1.Images.Count - 1

        'Save Button
        If ScheduleObject.ScheduleIcons.IconSave Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("save.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconSave)
        End If
        cmdSave.ImageIndex = ImageList1.Images.Count - 1

        'File icon
        If ScheduleObject.ScheduleIcons.IconFile Is Nothing Then
          ImageList1.Images.Add(New Icon(GetProjectFileAsStream("file.ico")))
        Else
          ImageList1.Images.Add(ScheduleObject.ScheduleIcons.IconFile)
        End If
 
      End Set

    End Property

    Public Property RemoveOnCancel() As Boolean
      Get
        Return m_RemoveOnCancel
      End Get
      Set(ByVal Value As Boolean)
        m_RemoveOnCancel = Value
      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub ResizeForm()

      Try
        Dim margin As Integer = (TabControl1.Height - TabControl1.DisplayRectangle.Height) + ToolBar1.Height + (Me.Height - Me.ClientSize.Height)
        Me.Size = New Size(Me.Size.Width, Me.AppointmentProperties1.Height + margin)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub AppointmentPropertiesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
        Call ReturnValues.Clear()
        Call ReturnValues.Add(False)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Function GoSave() As Boolean

			Try
				Me.SaveSuccess = False
				Me.ReturnValues(0).Setting = CBool(True).ToString
				If Me.AppointmentProperties1.Save() Then
					Me.Appointment.Notes = Me.txtNotes.Text
					Me.Appointment.IsFlagged = ToolBar1.Buttons(5).Pushed
					Call SaveFiles()

					'If the user wishes to save a recurrence pattern then add one
					If UseRecurrence Then
						'Reset an existing Recurrence object
						'If Me.ScheduleObject.RecurrenceCollection.Contains(Me.Recurrence.Key) Then
						'Me.ScheduleObject.RecurrenceCollection(Me.Recurrence.Key).FromXML(Me.Recurrence.ToXML)
						'End If

						'Remove all appointments in this recurrence pattern except for the current appointment
            Call Me.ScheduleObject.AppointmentCollection.DeleteRecurrences(Me.Recurrence, Me.Appointment)
						'Readd a the recurrence pattern based on the current appointment
						Call Me.ScheduleObject.AppointmentCollection.AddRecurrence(Me.Appointment, Me.Recurrence)
					End If

					'If this is not a modal dialog then inform the container that this appointment was saved
					Dim eventParam1 As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs
					eventParam1 = New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me.Appointment)
					Call Me.Appointment.MainObject.FireEventAfterSavePropertyDialog(Me, eventParam1)

					Return True
				Else
					Return False
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Sub LoadFiles()

			Try
				Call lvwFile.Items.Clear()
				Dim file As file
				For Each file In Appointment.FileCollection
					Call Me.AppendNewFile(file.Key)
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SaveFiles()

			Try
				Dim listItem As ListViewItem
				Call Appointment.FileCollection.Clear()
				For Each listItem In Me.lvwFile.Items
					Call Appointment.FileCollection.Add(CStr(listItem.Tag))
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub GoRecur()

			Try
				Dim F As New RecurForm
				Dim rv As New ReturnValues
        Call rv.Add(False)
				F.ReturnValues = rv

				'If there is no reference object then try to find one in the Recurrences collection
				If Me.Recurrence Is Nothing Then
					If Me.ScheduleObject.RecurrenceCollection.Contains(Me.Appointment.Recurrence) Then
						'Use a previously cached recurrence object
						F.Recurrence = Me.Appointment.Recurrence
					Else
						'Default properties for the recurrence 
						Dim recurrence As Gravitybox.Objects.Recurrence = Me.ScheduleObject.RecurrenceCollection.Add("")
						recurrence.StartDate = Me.Appointment.StartDate
						Dim eventParam As New Gravitybox.Objects.EventArgs.BeforeRecurrenceDialogEventArgs(recurrence, DialogSettings.RecurrenceDialogSettings)
						ScheduleObject.FireBeforeRecurrenceDialog(eventParam)
						If eventParam.Cancel Then Return
						F.Recurrence = recurrence
					End If
				Else
					'Reuse the existing Recurrence object
					F.Recurrence = Me.Recurrence
				End If
				F.AppointmentRecurrence1.AppointmentCollection = Me.ScheduleObject.AppointmentCollection
        F.AppointmentRecurrence1.RecurrenceDialogSettings = DialogSettings.RecurrenceDialogSettings
        F.DialogSettings = Me.DialogSettings.RecurrenceDialogSettings
				F.Appointment = Me.Appointment
				Call F.ShowDialog()
				ScheduleObject.FireAfterRecurrenceDialog(Me.Appointment)

				'If the user saved the recurrence pattern then we need 
				'persist this for later to add the actual recurrence pattern
				If CBool(rv(0).Setting) Then
					Me.Recurrence = CType(rv(1).Setting, recurrence)
					Me.Appointment.Recurrence = Me.Recurrence
					UseRecurrence = True
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub GoDelete()

			Try

				'Remove this item and close the form
				If ScheduleObject.AppointmentCollection.IndexOf(Appointment) >= 0 Then
					AppointmentProperties1.Appointment = Nothing
					'Close the form first as if this is a new add it will be removed automatically
					'if not then the appointment exists in the collection so remove it.
					Dim so As Gravitybox.Controls.Schedule = Me.ScheduleObject
					Dim appt As Appointment = Me.Appointment
					Call Me.Close()
					If so.AppointmentCollection.Contains(appt) Then
						Call so.AppointmentCollection.Remove(appt)
					End If
					so.Refresh()
					Me.DialogResult = System.Windows.Forms.DialogResult.OK
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub MoveUp()

			Try

				'Remove this item and close the form
				If AppointmentList.IndexOf(Appointment) > 0 Then
					'Make sure that the current appointment was saved
					If Not GoSave() Then Exit Sub

					Dim newAppointment As Appointment
					Dim F As AppointmentPropertiesForm
					newAppointment = CType(AppointmentList(AppointmentList.IndexOf(Appointment) - 1), Appointment)
					F = ScheduleObject.Dialogs.GetPropertyForm(newAppointment)
					If Not (F Is Nothing) Then F.Close()
					Appointment = newAppointment
				End If
				Call UpdateToobar()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub MoveDown()

			Try

				'Remove this item and close the form
				If AppointmentList.IndexOf(Appointment) < AppointmentList.Count - 1 Then
					'Make sure that the current appointment was saved
					If Not GoSave() Then Exit Sub

					Dim newAppointment As Appointment
					Dim F As AppointmentPropertiesForm
					newAppointment = CType(AppointmentList(AppointmentList.IndexOf(Appointment) + 1), Appointment)
					F = ScheduleObject.Dialogs.GetPropertyForm(newAppointment)
					If Not (F Is Nothing) Then F.Close()
					Appointment = newAppointment
				End If
				Call UpdateToobar()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick

			Try
				If e.Button Is ToolBar1.Buttons(0) Then				'Save
					If GoSave() Then
						SaveSuccess = True
						Me.DialogResult = System.Windows.Forms.DialogResult.OK
						Call Me.Close()
					End If
				ElseIf e.Button Is ToolBar1.Buttons(2) Then				'Recur
					Call GoRecur()
				ElseIf e.Button Is ToolBar1.Buttons(4) Then				'Remove
					Call GoDelete()
				ElseIf e.Button Is ToolBar1.Buttons(6) Then				'Move Up
					Call MoveUp()
				ElseIf e.Button Is ToolBar1.Buttons(7) Then				'Move Down
					Call MoveDown()
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub UpdateToobar()

			Try

				If (Me.Appointment Is Nothing) OrElse (DialogSettings Is Nothing) Then
					Me.ToolBar1.Buttons(0).Enabled = False
					Me.ToolBar1.Buttons(2).Enabled = False
					Me.ToolBar1.Buttons(4).Enabled = False
					Me.ToolBar1.Buttons(5).Enabled = False
					Me.ToolBar1.Buttons(6).Enabled = False
					Me.ToolBar1.Buttons(7).Enabled = False
				Else
					Me.ToolBar1.Buttons(0).Enabled = True
					Me.ToolBar1.Buttons(2).Enabled = Me.DialogSettings.AllowRecurrence
					Me.ToolBar1.Buttons(4).Enabled = Me.DialogSettings.AllowRemove
					Me.ToolBar1.Buttons(5).Enabled = Me.DialogSettings.AllowFlag
					Me.ToolBar1.Buttons(6).Enabled = CBool(AppointmentList.IndexOf(Appointment) > 0)
					Me.ToolBar1.Buttons(7).Enabled = CBool(AppointmentList.IndexOf(Appointment) < AppointmentList.Count - 1)
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub AppointmentPropertiesForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

			Try
				Call ScheduleObject.Dialogs.PropertyScreens.Remove(Me.Key)
				'If we need to remove this appointment on cancel then check for cancel and remove if possible
        If Me.RemoveOnCancel AndAlso (Me.DialogResult <> System.Windows.Forms.DialogResult.OK) AndAlso ScheduleObject.AppointmentCollection.Contains(Me.Appointment) Then
          ScheduleObject.AppointmentCollection.Remove(Me.Appointment)
        End If

				'If the appointment was NOT saved and it is part of the collection then reset its collection to original
				If (Not Me.AppointmentProperties1.WasSaved) AndAlso ScheduleObject.AppointmentCollection.Contains(Me.Appointment) Then
					Me.AppointmentProperties1.ResetCollections()
				End If

				ScheduleObject.OnRefresh()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub AppointmentPropertiesForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

			Try

				'If the cancel button was pressed then through cancel
				Dim eventParam1 As New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me.Appointment)
				If Not SaveSuccess Then
					If Not (Me.Appointment.MainObject Is Nothing) Then
						Call Me.Appointment.MainObject.FireEventAfterCancelPropertyDialog(Me, eventParam1)
					End If
				End If

				'If this is not a modal dialog then inform the container that this appointment was saved
				If Not (Me.Appointment.MainObject Is Nothing) Then
					Call Me.Appointment.MainObject.FireEventAfterPropertyDialog(Me, eventParam1)
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub lvwFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwFile.KeyDown

			Try
				If e.KeyCode = Keys.Delete Then
					Call RemoveSelectedFiles()
				ElseIf e.KeyCode = Keys.Return Then
					If lvwFile.SelectedItems.Count > 0 Then
						Call EditFile(CStr(lvwFile.SelectedItems(0).Tag))
					End If
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub RemoveSelectedFiles()

			Try
				If lvwFile.SelectedItems.Count > 0 Then


					Dim eventparam As New Gravitybox.Objects.EventArgs.TextExtendedEventArgs("Do you wish to remove the association of the selected files to this appointment? No files will be removed from disk.", "Delete?")
					Call Me.Appointment.MainObject.FireEventPropertyDialogRemoveFiles(Me, eventparam)

					'Prompt for delete 
					If eventparam.Text <> "" Then
						If MsgBox(eventparam.Text, MsgBoxStyle.Question Or MsgBoxStyle.YesNo, eventparam.Parameter2) <> MsgBoxResult.Yes Then Return
					End If

					'Loop and remove all
					Dim ii As Integer
					For ii = lvwFile.Items.Count - 1 To 0 Step -1
						If lvwFile.Items(ii).Selected Then
							Call lvwFile.Items.RemoveAt(ii)
						End If
					Next

				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub lvwFile_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFile.DragDrop

			Try
				If e.Data.GetDataPresent(DataFormats.FileDrop, False) Then
					'Append all of the file to the file listview
					Dim arrString As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
					Dim ii As Integer
					For ii = 0 To arrString.GetLength(0)
						Call AppendNewFile(arrString(ii))
					Next

				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub AppendNewFile(ByVal newFile As String)

			Try
				Dim fileName As String = System.IO.Path.GetFileName(newFile)
				Dim listItem As ListViewItem
				listItem = lvwFile.Items.Add(fileName)
				Call listItem.SubItems.Add("")
				Call listItem.SubItems.Add("")
				Call listItem.SubItems.Add("")

				'Get the folder name
				Dim folder As String = System.IO.Path.GetDirectoryName(newFile)
				If Not folder.EndsWith("\") Then folder += "\"
				listItem.SubItems(1).Text = folder				'Parent Folder
				listItem.Tag = newFile				'Full Path

				'Populate the other fields based on existence
				If System.IO.File.Exists(newFile) Then
					Dim fileInfo As System.IO.FileInfo = New System.IO.FileInfo(newFile)
					listItem.SubItems(2).Text = fileInfo.Length.ToString					'File Size
					listItem.SubItems(3).Text = fileInfo.LastWriteTime.ToShortTimeString					'Last Saved
				Else
					'This file does not exist
					listItem.ForeColor = SystemColors.GrayText
					listItem.SubItems(2).Text = "-"
					listItem.SubItems(3).Text = "-"
				End If
				listItem.ImageIndex = ImageList1.Images.Count - 1

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub lvwFile_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles lvwFile.DragOver

			Try
				If e.Data.GetDataPresent(DataFormats.FileDrop, False) Then
					e.Effect = DragDropEffects.Copy
				Else
					e.Effect = DragDropEffects.None
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub EditFiles()

			Try
				Dim listItem As ListViewItem
				For Each listItem In lvwFile.SelectedItems
					Call EditFile(CStr(listItem.Tag))
				Next
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub EditFile(ByVal fileName As String)

			Try
				Call System.Diagnostics.Process.Start(fileName)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub lvwFile_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwFile.DoubleClick

			Try
				Call EditFile(CStr(lvwFile.SelectedItems(0).Tag))
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdFileAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileAdd.Click

			Try
				Dialog1.Filter = "All Files (*.*)|*.*"
				Dialog1.FilterIndex = 0
				Dialog1.Multiselect = True
				Dialog1.Title = "Choose Files"
				Dialog1.FileName = ""
				Call Dialog1.ShowDialog()
				Dim ii As Integer
				'If cancelled then skip out
				If Dialog1.FileName = "" Then Return

				'Now load all the selected files
				For ii = 0 To Dialog1.FileNames.Length - 1
					Call Me.AppendNewFile(Dialog1.FileNames(ii))
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub cmdFileDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileDelete.Click
			Try
				Call RemoveSelectedFiles()
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentProperties1_SaveInvalidArea(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.TextExtendedEventArgs) Handles AppointmentProperties1.SaveInvalidArea
			Try
				Call Me.Appointment.MainObject.FireEventPropertyDialogSaveInvalidArea(Me, e)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub AppointmentProperties1_SaveValueOutOfRange(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.TextExtendedEventArgs) Handles AppointmentProperties1.SaveValueOutOfRange
			Try
				Call Me.Appointment.MainObject.FireEventPropertyDialogSaveValueOutOfRange(Me, e)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

		Private Sub CollectionRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)

			Try
				If (ScheduleObject Is Nothing) Then
					Return
				End If

				Dim list As AppointmentList = ScheduleObject.AppointmentCollection.GetUnBlocked()
				Call list.Sort()
				If AppointmentList Is Nothing Then
					AppointmentList = list
				ElseIf AppointmentList.Equals(list) Then
					AppointmentList = list
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
			If focusProcessed Then Return
			focusProcessed = True
			AppointmentProperties1.Focus()
		End Sub

#End Region

	End Class

End Namespace