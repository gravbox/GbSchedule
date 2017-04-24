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
Imports Gravitybox.Objects.EventArgs
Imports System.ComponentModel

Namespace Gravitybox.Controls

  ''' <summary>
  ''' An appointment properties editor.
  ''' </summary>
  <ToolboxItem(True), _
  ToolboxBitmap(GetType(Gravitybox.Controls.AppointmentProperties)), _
  Browsable(True), _
  DesignTimeVisible(True)> _
  Public Class AppointmentProperties
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

			Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
			Me.SetupDefaultAppearance()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Call AppointmentProperties()

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then

				OriginalCategories.Clear()
				OriginalProviders.Clear()
				OriginalResources.Clear()

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
    Friend WithEvents pnlSubject As System.Windows.Forms.Panel
    Friend WithEvents pnlRoom As System.Windows.Forms.Panel
    Friend WithEvents pnlTime As System.Windows.Forms.Panel
    Friend WithEvents pnlCategory As System.Windows.Forms.Panel
    Friend WithEvents pnlProvider As System.Windows.Forms.Panel
    Friend WithEvents pnlText As System.Windows.Forms.Panel
    Friend WithEvents pnlAlarm As System.Windows.Forms.Panel
    Friend WithEvents lblSubject As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents lblRoom As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents chkReminder As System.Windows.Forms.CheckBox
    Friend WithEvents cboReminder As System.Windows.Forms.ComboBox
    Friend WithEvents imgAlarm As System.Windows.Forms.PictureBox
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents lblProvider As System.Windows.Forms.Label
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents cboRoom As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvider As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Line1 As System.Windows.Forms.Label
    Friend WithEvents Line2 As System.Windows.Forms.Label
    Friend WithEvents Line3 As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdProvider As System.Windows.Forms.Button
    Friend WithEvents cmdCategory As System.Windows.Forms.Button
    Friend WithEvents txtProvider As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents chkEvent As System.Windows.Forms.CheckBox
    Friend WithEvents hdrMessage As Gravitybox.Controls.Header
    Friend WithEvents picClock As System.Windows.Forms.PictureBox
    Friend WithEvents pnlResource As System.Windows.Forms.Panel
    Friend WithEvents txtResource As System.Windows.Forms.TextBox
    Friend WithEvents cmdResource As System.Windows.Forms.Button
    Friend WithEvents cboResource As System.Windows.Forms.ComboBox
    Friend WithEvents lblResource As System.Windows.Forms.Label
    Friend WithEvents cboDuration As System.Windows.Forms.ComboBox
    Friend WithEvents lblDuration As System.Windows.Forms.Label
    Friend WithEvents cboStartTime As System.Windows.Forms.ComboBox
    Friend WithEvents cboEndTime As System.Windows.Forms.ComboBox
    Friend WithEvents lblPriority As System.Windows.Forms.Label
    Friend WithEvents cboPriority As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPriority As System.Windows.Forms.Panel
    Friend WithEvents pnlAppointmentType As System.Windows.Forms.Panel
    Friend WithEvents cboAppointmentType As System.Windows.Forms.ComboBox
    Friend WithEvents lblAppointmentType As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.pnlSubject = New System.Windows.Forms.Panel
			Me.txtSubject = New System.Windows.Forms.TextBox
			Me.lblSubject = New System.Windows.Forms.Label
			Me.pnlRoom = New System.Windows.Forms.Panel
			Me.cboRoom = New System.Windows.Forms.ComboBox
			Me.lblRoom = New System.Windows.Forms.Label
			Me.pnlAlarm = New System.Windows.Forms.Panel
			Me.imgAlarm = New System.Windows.Forms.PictureBox
			Me.cboReminder = New System.Windows.Forms.ComboBox
			Me.chkReminder = New System.Windows.Forms.CheckBox
			Me.pnlTime = New System.Windows.Forms.Panel
			Me.cboEndTime = New System.Windows.Forms.ComboBox
			Me.cboStartTime = New System.Windows.Forms.ComboBox
			Me.lblDuration = New System.Windows.Forms.Label
			Me.chkEvent = New System.Windows.Forms.CheckBox
			Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
			Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
			Me.picClock = New System.Windows.Forms.PictureBox
			Me.lblTime = New System.Windows.Forms.Label
			Me.cboDuration = New System.Windows.Forms.ComboBox
			Me.pnlCategory = New System.Windows.Forms.Panel
			Me.txtCategory = New System.Windows.Forms.TextBox
			Me.cmdCategory = New System.Windows.Forms.Button
			Me.cboCategory = New System.Windows.Forms.ComboBox
			Me.lblCategory = New System.Windows.Forms.Label
			Me.pnlProvider = New System.Windows.Forms.Panel
			Me.txtProvider = New System.Windows.Forms.TextBox
			Me.cmdProvider = New System.Windows.Forms.Button
			Me.cboProvider = New System.Windows.Forms.ComboBox
			Me.lblProvider = New System.Windows.Forms.Label
			Me.pnlText = New System.Windows.Forms.Panel
			Me.txtText = New System.Windows.Forms.TextBox
			Me.Line1 = New System.Windows.Forms.Label
			Me.Line2 = New System.Windows.Forms.Label
			Me.Line3 = New System.Windows.Forms.Label
			Me.hdrMessage = New Gravitybox.Controls.Header
			Me.pnlResource = New System.Windows.Forms.Panel
			Me.txtResource = New System.Windows.Forms.TextBox
			Me.cmdResource = New System.Windows.Forms.Button
			Me.cboResource = New System.Windows.Forms.ComboBox
			Me.lblResource = New System.Windows.Forms.Label
			Me.pnlPriority = New System.Windows.Forms.Panel
			Me.cboPriority = New System.Windows.Forms.ComboBox
			Me.lblPriority = New System.Windows.Forms.Label
			Me.pnlAppointmentType = New System.Windows.Forms.Panel
			Me.cboAppointmentType = New System.Windows.Forms.ComboBox
			Me.lblAppointmentType = New System.Windows.Forms.Label
			Me.pnlSubject.SuspendLayout()
			Me.pnlRoom.SuspendLayout()
			Me.pnlAlarm.SuspendLayout()
      'CType(Me.imgAlarm, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlTime.SuspendLayout()
      'CType(Me.picClock, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlCategory.SuspendLayout()
			Me.pnlProvider.SuspendLayout()
			Me.pnlText.SuspendLayout()
			Me.pnlResource.SuspendLayout()
			Me.pnlPriority.SuspendLayout()
			Me.pnlAppointmentType.SuspendLayout()
			Me.SuspendLayout()
			'
			'pnlSubject
			'
			Me.pnlSubject.BackColor = System.Drawing.Color.Transparent
			Me.pnlSubject.Controls.Add(Me.txtSubject)
			Me.pnlSubject.Controls.Add(Me.lblSubject)
			Me.pnlSubject.Location = New System.Drawing.Point(8, 32)
			Me.pnlSubject.Name = "pnlSubject"
			Me.pnlSubject.Size = New System.Drawing.Size(512, 32)
			Me.pnlSubject.TabIndex = 0
			'
			'txtSubject
			'
			Me.txtSubject.Location = New System.Drawing.Point(120, 0)
			Me.txtSubject.Name = "txtSubject"
			Me.txtSubject.Size = New System.Drawing.Size(392, 20)
			Me.txtSubject.TabIndex = 0
			'
			'lblSubject
			'
			Me.lblSubject.Location = New System.Drawing.Point(8, 0)
			Me.lblSubject.Name = "lblSubject"
			Me.lblSubject.Size = New System.Drawing.Size(112, 16)
			Me.lblSubject.TabIndex = 0
			Me.lblSubject.Text = "Subject:"
			'
			'pnlRoom
			'
			Me.pnlRoom.BackColor = System.Drawing.Color.Transparent
			Me.pnlRoom.Controls.Add(Me.cboRoom)
			Me.pnlRoom.Controls.Add(Me.lblRoom)
			Me.pnlRoom.Location = New System.Drawing.Point(8, 88)
			Me.pnlRoom.Name = "pnlRoom"
			Me.pnlRoom.Size = New System.Drawing.Size(256, 32)
			Me.pnlRoom.TabIndex = 1
			'
			'cboRoom
			'
			Me.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboRoom.Location = New System.Drawing.Point(120, 0)
			Me.cboRoom.Name = "cboRoom"
			Me.cboRoom.Size = New System.Drawing.Size(136, 21)
			Me.cboRoom.TabIndex = 1
			'
			'lblRoom
			'
			Me.lblRoom.Location = New System.Drawing.Point(8, 0)
			Me.lblRoom.Name = "lblRoom"
			Me.lblRoom.Size = New System.Drawing.Size(100, 16)
			Me.lblRoom.TabIndex = 2
			Me.lblRoom.Text = "Room:"
			'
			'pnlAlarm
			'
			Me.pnlAlarm.BackColor = System.Drawing.Color.Transparent
			Me.pnlAlarm.Controls.Add(Me.imgAlarm)
			Me.pnlAlarm.Controls.Add(Me.cboReminder)
			Me.pnlAlarm.Controls.Add(Me.chkReminder)
			Me.pnlAlarm.Location = New System.Drawing.Point(8, 216)
			Me.pnlAlarm.Name = "pnlAlarm"
			Me.pnlAlarm.Size = New System.Drawing.Size(256, 40)
			Me.pnlAlarm.TabIndex = 3
			'
			'imgAlarm
			'
			Me.imgAlarm.BackColor = System.Drawing.Color.Transparent
			Me.imgAlarm.Location = New System.Drawing.Point(16, 8)
			Me.imgAlarm.Name = "imgAlarm"
			Me.imgAlarm.Size = New System.Drawing.Size(32, 32)
			Me.imgAlarm.TabIndex = 15
			Me.imgAlarm.TabStop = False
			'
			'cboReminder
			'
			Me.cboReminder.Location = New System.Drawing.Point(144, 16)
			Me.cboReminder.Name = "cboReminder"
			Me.cboReminder.Size = New System.Drawing.Size(112, 21)
			Me.cboReminder.TabIndex = 10
			'
			'chkReminder
			'
			Me.chkReminder.Location = New System.Drawing.Point(64, 16)
			Me.chkReminder.Name = "chkReminder"
			Me.chkReminder.Size = New System.Drawing.Size(72, 16)
			Me.chkReminder.TabIndex = 9
			Me.chkReminder.Text = "Reminder:"
			'
			'pnlTime
			'
			Me.pnlTime.BackColor = System.Drawing.Color.Transparent
			Me.pnlTime.Controls.Add(Me.cboEndTime)
			Me.pnlTime.Controls.Add(Me.cboStartTime)
			Me.pnlTime.Controls.Add(Me.lblDuration)
			Me.pnlTime.Controls.Add(Me.chkEvent)
			Me.pnlTime.Controls.Add(Me.dtpEndDate)
			Me.pnlTime.Controls.Add(Me.dtpStartDate)
			Me.pnlTime.Controls.Add(Me.picClock)
			Me.pnlTime.Controls.Add(Me.lblTime)
			Me.pnlTime.Controls.Add(Me.cboDuration)
			Me.pnlTime.Location = New System.Drawing.Point(8, 144)
			Me.pnlTime.Name = "pnlTime"
			Me.pnlTime.Size = New System.Drawing.Size(512, 56)
			Me.pnlTime.TabIndex = 2
			'
			'cboEndTime
			'
			Me.cboEndTime.Location = New System.Drawing.Point(288, 32)
			Me.cboEndTime.Name = "cboEndTime"
			Me.cboEndTime.Size = New System.Drawing.Size(104, 21)
			Me.cboEndTime.TabIndex = 7
			'
			'cboStartTime
			'
			Me.cboStartTime.Location = New System.Drawing.Point(288, 8)
			Me.cboStartTime.Name = "cboStartTime"
			Me.cboStartTime.Size = New System.Drawing.Size(104, 21)
			Me.cboStartTime.TabIndex = 4
			'
			'lblDuration
			'
			Me.lblDuration.Location = New System.Drawing.Point(64, 32)
			Me.lblDuration.Name = "lblDuration"
			Me.lblDuration.Size = New System.Drawing.Size(104, 16)
			Me.lblDuration.TabIndex = 17
			Me.lblDuration.Text = "Duration:"
			'
			'chkEvent
			'
			Me.chkEvent.Location = New System.Drawing.Point(400, 8)
			Me.chkEvent.Name = "chkEvent"
			Me.chkEvent.Size = New System.Drawing.Size(104, 20)
			Me.chkEvent.TabIndex = 5
			Me.chkEvent.Text = "All Day Event"
			'
			'dtpEndDate
			'
			Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpEndDate.Location = New System.Drawing.Point(176, 32)
			Me.dtpEndDate.Name = "dtpEndDate"
			Me.dtpEndDate.Size = New System.Drawing.Size(104, 20)
			Me.dtpEndDate.TabIndex = 6
			'
			'dtpStartDate
			'
			Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
			Me.dtpStartDate.Location = New System.Drawing.Point(176, 8)
			Me.dtpStartDate.Name = "dtpStartDate"
			Me.dtpStartDate.Size = New System.Drawing.Size(104, 20)
			Me.dtpStartDate.TabIndex = 3
			'
			'picClock
			'
			Me.picClock.BackColor = System.Drawing.Color.Transparent
			Me.picClock.Location = New System.Drawing.Point(16, 8)
			Me.picClock.Name = "picClock"
			Me.picClock.Size = New System.Drawing.Size(32, 32)
			Me.picClock.TabIndex = 16
			Me.picClock.TabStop = False
			'
			'lblTime
			'
			Me.lblTime.Location = New System.Drawing.Point(64, 8)
			Me.lblTime.Name = "lblTime"
			Me.lblTime.Size = New System.Drawing.Size(104, 16)
			Me.lblTime.TabIndex = 3
			Me.lblTime.Text = "Start Time:"
			'
			'cboDuration
			'
			Me.cboDuration.Location = New System.Drawing.Point(336, 32)
			Me.cboDuration.Name = "cboDuration"
			Me.cboDuration.Size = New System.Drawing.Size(104, 21)
			Me.cboDuration.TabIndex = 8
			'
			'pnlCategory
			'
			Me.pnlCategory.BackColor = System.Drawing.Color.Transparent
			Me.pnlCategory.Controls.Add(Me.txtCategory)
			Me.pnlCategory.Controls.Add(Me.cmdCategory)
			Me.pnlCategory.Controls.Add(Me.cboCategory)
			Me.pnlCategory.Controls.Add(Me.lblCategory)
			Me.pnlCategory.Location = New System.Drawing.Point(8, 408)
			Me.pnlCategory.Name = "pnlCategory"
			Me.pnlCategory.Size = New System.Drawing.Size(512, 32)
			Me.pnlCategory.TabIndex = 6
			'
			'txtCategory
			'
			Me.txtCategory.Location = New System.Drawing.Point(112, 0)
			Me.txtCategory.Name = "txtCategory"
			Me.txtCategory.ReadOnly = True
			Me.txtCategory.Size = New System.Drawing.Size(392, 20)
			Me.txtCategory.TabIndex = 16
			'
			'cmdCategory
			'
			Me.cmdCategory.Location = New System.Drawing.Point(0, 0)
			Me.cmdCategory.Name = "cmdCategory"
			Me.cmdCategory.Size = New System.Drawing.Size(104, 20)
			Me.cmdCategory.TabIndex = 15
			Me.cmdCategory.Text = "Categories"
			'
			'cboCategory
			'
			Me.cboCategory.Location = New System.Drawing.Point(456, 0)
			Me.cboCategory.Name = "cboCategory"
			Me.cboCategory.Size = New System.Drawing.Size(56, 21)
			Me.cboCategory.TabIndex = 5
			Me.cboCategory.Visible = False
			'
			'lblCategory
			'
			Me.lblCategory.Location = New System.Drawing.Point(456, 16)
			Me.lblCategory.Name = "lblCategory"
			Me.lblCategory.Size = New System.Drawing.Size(120, 16)
			Me.lblCategory.TabIndex = 4
			Me.lblCategory.Text = "Category:"
			Me.lblCategory.Visible = False
			'
			'pnlProvider
			'
			Me.pnlProvider.BackColor = System.Drawing.Color.Transparent
			Me.pnlProvider.Controls.Add(Me.txtProvider)
			Me.pnlProvider.Controls.Add(Me.cmdProvider)
			Me.pnlProvider.Controls.Add(Me.cboProvider)
			Me.pnlProvider.Controls.Add(Me.lblProvider)
			Me.pnlProvider.Location = New System.Drawing.Point(8, 368)
			Me.pnlProvider.Name = "pnlProvider"
			Me.pnlProvider.Size = New System.Drawing.Size(512, 32)
			Me.pnlProvider.TabIndex = 5
			'
			'txtProvider
			'
			Me.txtProvider.BackColor = System.Drawing.SystemColors.Control
			Me.txtProvider.Location = New System.Drawing.Point(112, 0)
			Me.txtProvider.Name = "txtProvider"
			Me.txtProvider.ReadOnly = True
			Me.txtProvider.Size = New System.Drawing.Size(392, 20)
			Me.txtProvider.TabIndex = 14
			'
			'cmdProvider
			'
			Me.cmdProvider.Location = New System.Drawing.Point(0, 0)
			Me.cmdProvider.Name = "cmdProvider"
			Me.cmdProvider.Size = New System.Drawing.Size(104, 20)
			Me.cmdProvider.TabIndex = 13
			Me.cmdProvider.Text = "Providers"
			'
			'cboProvider
			'
			Me.cboProvider.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboProvider.Location = New System.Drawing.Point(456, 0)
			Me.cboProvider.Name = "cboProvider"
			Me.cboProvider.Size = New System.Drawing.Size(48, 21)
			Me.cboProvider.TabIndex = 4
			Me.cboProvider.Visible = False
			'
			'lblProvider
			'
			Me.lblProvider.Location = New System.Drawing.Point(456, 16)
			Me.lblProvider.Name = "lblProvider"
			Me.lblProvider.Size = New System.Drawing.Size(112, 16)
			Me.lblProvider.TabIndex = 3
			Me.lblProvider.Text = "Provider:"
			Me.lblProvider.Visible = False
			'
			'pnlText
			'
			Me.pnlText.Controls.Add(Me.txtText)
			Me.pnlText.Location = New System.Drawing.Point(8, 264)
			Me.pnlText.Name = "pnlText"
			Me.pnlText.Size = New System.Drawing.Size(512, 80)
			Me.pnlText.TabIndex = 4
			'
			'txtText
			'
			Me.txtText.Dock = System.Windows.Forms.DockStyle.Fill
			Me.txtText.Location = New System.Drawing.Point(0, 0)
			Me.txtText.Multiline = True
			Me.txtText.Name = "txtText"
			Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txtText.Size = New System.Drawing.Size(512, 80)
			Me.txtText.TabIndex = 12
			'
			'Line1
			'
			Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
			Me.Line1.Location = New System.Drawing.Point(416, 456)
			Me.Line1.Name = "Line1"
			Me.Line1.Size = New System.Drawing.Size(32, 32)
			Me.Line1.TabIndex = 8
			Me.Line1.Text = "Label1"
			'
			'Line2
			'
			Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
			Me.Line2.Location = New System.Drawing.Point(456, 456)
			Me.Line2.Name = "Line2"
			Me.Line2.Size = New System.Drawing.Size(32, 32)
			Me.Line2.TabIndex = 9
			Me.Line2.Text = "Label1"
			'
			'Line3
			'
			Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
			Me.Line3.Location = New System.Drawing.Point(496, 456)
			Me.Line3.Name = "Line3"
			Me.Line3.Size = New System.Drawing.Size(32, 32)
			Me.Line3.TabIndex = 10
			Me.Line3.Text = "Label1"
			'
			'hdrMessage
			'
			Me.hdrMessage.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
			Me.hdrMessage.Appearance.BorderColor = System.Drawing.SystemColors.WindowFrame
			Me.hdrMessage.Appearance.FontSize = 18.0!
			Me.hdrMessage.Appearance.Key = "a5983ac8-d95c-489a-8acd-50017e7104c7"
			Me.hdrMessage.Appearance.NoFill = False
			Me.hdrMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
			Me.hdrMessage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.hdrMessage.ForeColor = System.Drawing.Color.Black
			Me.hdrMessage.IconAlignment = Gravitybox.Controls.Header.IconAlignmentConstants.Left
			Me.hdrMessage.Location = New System.Drawing.Point(8, 0)
			Me.hdrMessage.Name = "hdrMessage"
			Me.hdrMessage.Size = New System.Drawing.Size(512, 20)
			Me.hdrMessage.TabIndex = 11
			Me.hdrMessage.Visible = False
			'
			'pnlResource
			'
			Me.pnlResource.BackColor = System.Drawing.Color.Transparent
			Me.pnlResource.Controls.Add(Me.txtResource)
			Me.pnlResource.Controls.Add(Me.cmdResource)
			Me.pnlResource.Controls.Add(Me.cboResource)
			Me.pnlResource.Controls.Add(Me.lblResource)
			Me.pnlResource.Location = New System.Drawing.Point(8, 448)
			Me.pnlResource.Name = "pnlResource"
			Me.pnlResource.Size = New System.Drawing.Size(512, 32)
			Me.pnlResource.TabIndex = 12
			'
			'txtResource
			'
			Me.txtResource.Location = New System.Drawing.Point(112, 0)
			Me.txtResource.Name = "txtResource"
			Me.txtResource.ReadOnly = True
			Me.txtResource.Size = New System.Drawing.Size(392, 20)
			Me.txtResource.TabIndex = 18
			'
			'cmdResource
			'
			Me.cmdResource.Location = New System.Drawing.Point(0, 0)
			Me.cmdResource.Name = "cmdResource"
			Me.cmdResource.Size = New System.Drawing.Size(104, 20)
			Me.cmdResource.TabIndex = 17
			Me.cmdResource.Text = "Resources"
			'
			'cboResource
			'
			Me.cboResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboResource.Location = New System.Drawing.Point(456, 0)
			Me.cboResource.Name = "cboResource"
			Me.cboResource.Size = New System.Drawing.Size(56, 21)
			Me.cboResource.TabIndex = 5
			Me.cboResource.Visible = False
			'
			'lblResource
			'
			Me.lblResource.Location = New System.Drawing.Point(456, 16)
			Me.lblResource.Name = "lblResource"
			Me.lblResource.Size = New System.Drawing.Size(120, 16)
			Me.lblResource.TabIndex = 4
			Me.lblResource.Text = "Resource:"
			Me.lblResource.Visible = False
			'
			'pnlPriority
			'
			Me.pnlPriority.BackColor = System.Drawing.Color.Transparent
			Me.pnlPriority.Controls.Add(Me.cboPriority)
			Me.pnlPriority.Controls.Add(Me.lblPriority)
			Me.pnlPriority.Location = New System.Drawing.Point(272, 216)
			Me.pnlPriority.Name = "pnlPriority"
			Me.pnlPriority.Size = New System.Drawing.Size(248, 40)
			Me.pnlPriority.TabIndex = 13
			'
			'cboPriority
			'
			Me.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboPriority.Location = New System.Drawing.Point(104, 16)
			Me.cboPriority.Name = "cboPriority"
			Me.cboPriority.Size = New System.Drawing.Size(120, 21)
			Me.cboPriority.TabIndex = 11
			'
			'lblPriority
			'
			Me.lblPriority.Location = New System.Drawing.Point(8, 16)
			Me.lblPriority.Name = "lblPriority"
			Me.lblPriority.Size = New System.Drawing.Size(88, 16)
			Me.lblPriority.TabIndex = 4
			Me.lblPriority.Text = "Priority:"
			Me.lblPriority.TextAlign = System.Drawing.ContentAlignment.TopCenter
			'
			'pnlAppointmentType
			'
			Me.pnlAppointmentType.BackColor = System.Drawing.Color.Transparent
			Me.pnlAppointmentType.Controls.Add(Me.cboAppointmentType)
			Me.pnlAppointmentType.Controls.Add(Me.lblAppointmentType)
			Me.pnlAppointmentType.Location = New System.Drawing.Point(272, 88)
			Me.pnlAppointmentType.Name = "pnlAppointmentType"
			Me.pnlAppointmentType.Size = New System.Drawing.Size(248, 32)
			Me.pnlAppointmentType.TabIndex = 14
			'
			'cboAppointmentType
			'
			Me.cboAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cboAppointmentType.Location = New System.Drawing.Point(112, 0)
			Me.cboAppointmentType.Name = "cboAppointmentType"
			Me.cboAppointmentType.Size = New System.Drawing.Size(136, 21)
			Me.cboAppointmentType.TabIndex = 2
			'
			'lblAppointmentType
			'
			Me.lblAppointmentType.Location = New System.Drawing.Point(0, 0)
			Me.lblAppointmentType.Name = "lblAppointmentType"
			Me.lblAppointmentType.Size = New System.Drawing.Size(100, 16)
			Me.lblAppointmentType.TabIndex = 4
			Me.lblAppointmentType.Text = "Type:"
			Me.lblAppointmentType.TextAlign = System.Drawing.ContentAlignment.TopCenter
			'
			'AppointmentProperties
			'
			Me.BackColor = System.Drawing.Color.Transparent
			Me.Controls.Add(Me.pnlPriority)
			Me.Controls.Add(Me.pnlResource)
			Me.Controls.Add(Me.hdrMessage)
			Me.Controls.Add(Me.Line3)
			Me.Controls.Add(Me.Line2)
			Me.Controls.Add(Me.Line1)
			Me.Controls.Add(Me.pnlCategory)
			Me.Controls.Add(Me.pnlProvider)
			Me.Controls.Add(Me.pnlText)
			Me.Controls.Add(Me.pnlAlarm)
			Me.Controls.Add(Me.pnlTime)
			Me.Controls.Add(Me.pnlRoom)
			Me.Controls.Add(Me.pnlSubject)
			Me.Controls.Add(Me.pnlAppointmentType)
			Me.Name = "AppointmentProperties"
			Me.Size = New System.Drawing.Size(536, 480)
			Me.pnlSubject.ResumeLayout(False)
			Me.pnlSubject.PerformLayout()
			Me.pnlRoom.ResumeLayout(False)
			Me.pnlAlarm.ResumeLayout(False)
      'CType(Me.imgAlarm, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlTime.ResumeLayout(False)
      'CType(Me.picClock, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlCategory.ResumeLayout(False)
			Me.pnlCategory.PerformLayout()
			Me.pnlProvider.ResumeLayout(False)
			Me.pnlProvider.PerformLayout()
			Me.pnlText.ResumeLayout(False)
			Me.pnlText.PerformLayout()
			Me.pnlResource.ResumeLayout(False)
			Me.pnlResource.PerformLayout()
			Me.pnlPriority.ResumeLayout(False)
			Me.pnlAppointmentType.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Class Members"

    'Property Defaults
    Private Const m_def_AllowSubject As Boolean = True
    Private Const m_def_AllowRoom As Boolean = True
    Private Const m_def_AllowAppointmentType As Boolean = True
    Private Const m_def_AllowDate As Boolean = True
    Private Const m_def_AllowTime As Boolean = True
    Private Const m_def_AllowAlarm As Boolean = True
    Private Const m_def_AllowText As Boolean = True
    Private Const m_def_AllowProvider As Boolean = True
    Private Const m_def_AllowResource As Boolean = True
    Private Const m_def_AllowCategory As Boolean = True
    Private Const m_def_AllowPriority As Boolean = True
    Private Const m_def_AllowMasterCategories As Boolean = True
    Private Const m_def_AllowEvents As Boolean = True
    Private Const m_def_EnforceBounds As Boolean = False
    Private Const m_def_WarningText As String = ""
    Private Const m_def_ClockSetting As Schedule.ClockSettingConstants = Schedule.ClockSettingConstants.Clock12
    Private Const m_def_SubjectLength As Integer = 0
    Private Const m_def_TextLength As Integer = 0
    Private Const m_def_TimeDisplay As Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants = Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants.EndTime
    Private Const m_def_CategoryEditMode As Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants = Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants.Fixed
    Private Const m_def_TimeIncrement As Gravitybox.Controls.Schedule.TimeIncrementConstants = Schedule.TimeIncrementConstants.Minute30

    'Property Variables
    Private m_AllowSubject As Boolean
    Private m_AllowRoom As Boolean
    Private m_AllowAppointmentType As Boolean
    Private m_AllowDate As Boolean
    Private m_AllowTime As Boolean
    Private m_AllowAlarm As Boolean
    Private m_AllowText As Boolean
    Private m_AllowProvider As Boolean
    Private m_AllowResource As Boolean
    Private m_AllowCategory As Boolean
    Private m_AllowPriority As Boolean
    Private m_AllowMasterCategories As Boolean
    Private m_Appointment As Appointment
    Private m_AllowEvents As Boolean = m_def_AllowEvents
    Private m_EnforceBounds As Boolean = m_def_EnforceBounds
    Private m_WarningText As String = m_def_WarningText
    Private m_ScheduleObject As Schedule
    Private m_ClockSetting As Gravitybox.Controls.Schedule.ClockSettingConstants = m_def_ClockSetting
    Private m_TimeDisplay As Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants = m_def_TimeDisplay
		Private m_CategoryEditMode As Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants = m_def_CategoryEditMode
		Protected m_Appearance As Appearance

    'Private Variables
    Private Reminder As New AppointmentReminder(New TimeSettings)
    Private m_WasSaved As Boolean = False

    'Delegate
    Public Delegate Sub SaveInvalidAreaDelegate(ByVal sender As Object, ByVal e As TextExtendedEventArgs)
    Public Delegate Sub SaveValueOutOfRangeDelegate(ByVal sender As Object, ByVal e As TextExtendedEventArgs)

    'Public Events
    ''' <summary>
    ''' Occurs when trying to save an appointment that will overlap an invalid area.
    ''' </summary>
    Public Event SaveInvalidArea As SaveInvalidAreaDelegate
    ''' <summary>
    ''' Occurs when trying to save an appointment that is out of the valid range of the schedule.
    ''' </summary>
    ''' <remarks>The valid range is defined by the schedule properties: MinDate, MaxDate, StartTime, and DayLength.</remarks>
    Public Event SaveValueOutOfRange As SaveValueOutOfRangeDelegate

    Private DefaultAppointmentLength As Integer = 60

    'Save the Object Lists
    Private OriginalCategories As ArrayList
    Private OriginalProviders As ArrayList
    Private OriginalResources As ArrayList
    Private IsDirtyCategory As Boolean
    Private IsDirtyProvider As Boolean
    Private IsDirtyResource As Boolean

#End Region

#Region "Property Implementations"

    Friend ReadOnly Property WasSaved() As Boolean
      Get
        Return m_WasSaved
      End Get
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'Subject' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowSubject), _
    Description("Determines if the user may view/edit an appointment's 'Subject' property with this control.")> _
    Public Property AllowSubject() As Boolean
      Get
        Return m_AllowSubject
      End Get
      Set(ByVal Value As Boolean)
        m_AllowSubject = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'Room' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowRoom), _
    Description("Determines if the user may view/edit an appointment's 'Room' property with this control.")> _
    Public Property AllowRoom() As Boolean
      Get
        Return m_AllowRoom
      End Get
      Set(ByVal Value As Boolean)
        m_AllowRoom = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'AppointmentType' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowAppointmentType), _
    Description("Determines if the user may view/edit an appointment's 'AppointmentType' property with this control.")> _
    Public Property AllowAppointmentType() As Boolean
      Get
        Return m_AllowAppointmentType
      End Get
      Set(ByVal Value As Boolean)
        m_AllowAppointmentType = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'StartDate' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowDate), _
    Description("Determines if the user may view/edit an appointment's 'StartDate' property with this control.")> _
    Public Property AllowDate() As Boolean
      Get
        Return m_AllowDate
      End Get
      Set(ByVal Value As Boolean)
        m_AllowDate = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'StartTime' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowTime), _
    Description("Determines if the user may view/edit an appointment's 'StartTime' property with this control.")> _
    Public Property AllowTime() As Boolean
      Get
        Return m_AllowTime
      End Get
      Set(ByVal Value As Boolean)
        m_AllowTime = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's Alarm property object with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowAlarm), _
    Description("Determines if the user may view/edit an appointment's Alarm property object with this control.")> _
    Public Property AllowAlarm() As Boolean
      Get
        Return m_AllowAlarm
      End Get
      Set(ByVal Value As Boolean)
        m_AllowAlarm = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's 'Text' property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowText), _
    Description("Determines if the user may view/edit an appointment's 'Text' property with this control.")> _
    Public Property AllowText() As Boolean
      Get
        Return m_AllowText
      End Get
      Set(ByVal Value As Boolean)
        m_AllowText = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's ProviderCollection object with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowProvider), _
    Description("Determines if the user may view/edit an appointment's ProviderCollection object with this control.")> _
    Public Property AllowProvider() As Boolean
      Get
        Return m_AllowProvider
      End Get
      Set(ByVal Value As Boolean)
        m_AllowProvider = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's ResourceCollection object with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowResource), _
    Description("Determines if the user may view/edit an appointment's ResourceCollection object with this control.")> _
    Public Property AllowResource() As Boolean
      Get
        Return m_AllowResource
      End Get
      Set(ByVal Value As Boolean)
        m_AllowResource = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's CategoryCollection object with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowCategory), _
    Description("Determines if the user may view/edit an appointment's CategoryCollection object with this control.")> _
    Public Property AllowCategory() As Boolean
      Get
        Return m_AllowCategory
      End Get
      Set(ByVal Value As Boolean)
        m_AllowCategory = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's Priority property with this control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowPriority), _
    Description("Determines if the user may view/edit an appointment's Priority property with this control.")> _
    Public Property AllowPriority() As Boolean
      Get
        Return m_AllowPriority
      End Get
      Set(ByVal Value As Boolean)
        m_AllowPriority = Value
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' Determines if the categories popup screen has a 'Master Categories' button.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowMasterCategories), _
    Description("Determines if the categories popup screen has a 'Master Categories' button.")> _
    Public Property AllowMasterCategories() As Boolean
      Get
        Return m_AllowMasterCategories
      End Get
      Set(ByVal Value As Boolean)
        m_AllowMasterCategories = Value
      End Set
    End Property

    ''' <summary>
    ''' The appointment object that this control is editing.
    ''' </summary>
    <Browsable(False)> _
    Public Property Appointment() As Appointment
      Get
        Return m_Appointment
      End Get
      Set(ByVal Value As Appointment)
        Try
          If Not (m_Appointment Is Value) Then
            m_Appointment = Value
            If Not (m_Appointment Is Nothing) Then
              OriginalCategories = Me.Appointment.CategoryList.ToArray
              OriginalProviders = Me.Appointment.ProviderList.ToArray
              OriginalResources = Me.Appointment.ResourceList.ToArray

              DefaultAppointmentLength = m_Appointment.Length
            End If
            Call Refresh()
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may view/edit an appointment's IsEvent property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowEvents), _
    Description("Determines if the user may view/edit an appointment's IsEvent property.")> _
    Public Property AllowEvents() As Boolean
      Get
        Return m_AllowEvents And Me.AllowTime
      End Get
      Set(ByVal Value As Boolean)
        m_AllowEvents = Value
        chkEvent.Visible = m_AllowEvents
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user is forced to enter data in range. (Date between the MinDate and MaxDate. Times between the StartTime and DayLength.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_EnforceBounds), _
    Description("Determines if the user is forced to enter data in range. (Date between the MinDate and MaxDate. Times between the StartTime and DayLength.")> _
    Public Property EnforceBounds() As Boolean
      Get
        Return m_EnforceBounds
      End Get
      Set(ByVal Value As Boolean)
        m_EnforceBounds = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the text displayed at the top of the control to warn the user of some issue.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_WarningText), _
    Description("Determines if the text displayed at the top of the control to warn the user of some issue.")> _
    Public Property WarningText() As String
      Get
        Return m_WarningText
      End Get
      Set(ByVal Value As String)
        m_WarningText = Value
        hdrMessage.Text = WarningText
        Call ResizeControl()
      End Set
    End Property

    ''' <summary>
    ''' The Schedule UserControl on which the appointment being edited resides.
    ''' </summary>
    <Browsable(False)> _
    Public Property ScheduleObject() As Schedule
      Get
        Return m_ScheduleObject
      End Get
      Set(ByVal Value As Schedule)
        m_ScheduleObject = Value
        Me.ResetCaptions()
      End Set
    End Property

    ''' <summary>
    ''' Determines whether times are displayed using the 12 or 24 hour clock.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Schedule.ClockSettingConstants), "Clock12"), _
    Description("Determines whether times are displayed using the 12 or 24 hour clock.")> _
    Public Property ClockSetting() As Schedule.ClockSettingConstants
      Get
        Return m_ClockSetting
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.ClockSettingConstants)
        If (m_ClockSetting <> Value) Then
          m_ClockSetting = Value
          Reminder.DialogSettings.ClockSetting = Value
          'TODO - Refresh the start/end time combos
          Me.Refresh()
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the 'Subject' textbox's maximum length.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_SubjectLength), _
    Description("Determines the 'Subject' textbox's maximum length.")> _
    Public Property SubjectLength() As Integer
      Get
        Return txtSubject.MaxLength
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        txtSubject.MaxLength = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the 'Text' textbox's maximum length.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_TextLength), _
    Description("Determines the 'Text' textbox's maximum length.")> _
    Public Property TextLength() As Integer
      Get
        Return txtText.MaxLength
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        txtText.MaxLength = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Subject' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Subject"), _
    Description("Determines the prompt for the 'Subject' property.")> _
    Public Property SubjectPrompt() As String
      Get
        Dim retval As String = ""
        'Strip off the colon
        If lblSubject.Text.EndsWith(":") Then
          retval = lblSubject.Text.Substring(0, lblSubject.Text.Length - 1)
        Else
          retval = lblSubject.Text
        End If
        Return retval
      End Get
      Set(ByVal Value As String)
        If Value Is Nothing Then Value = ""
        If Value <> "" Then Value = Value & ":"
        lblSubject.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'StartTime' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Start Time"), _
    Description("Determines the prompt for the 'StartTime' property.")> _
    Public Property StartTimePrompt() As String
      Get
        Dim retval As String = ""
        'Strip off the colon
        If lblTime.Text.EndsWith(":") Then
          retval = lblTime.Text.Substring(0, lblTime.Text.Length - 1)
        Else
          retval = lblTime.Text
        End If
        Return retval
      End Get
      Set(ByVal Value As String)
        If Value Is Nothing Then Value = ""
        If Value <> "" Then Value = Value & ":"
        lblTime.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'IsEvent' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("All Day Event"), _
    Description("Determines the prompt for the 'IsEvent' property.")> _
    Public Property EventPrompt() As String
      Get
        Return chkEvent.Text
      End Get
      Set(ByVal Value As String)
        chkEvent.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Reminder' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Reminder:"), _
    Description("Determines the prompt for the 'Reminder' property.")> _
    Public Property ReminderPrompt() As String
      Get
        Return chkReminder.Text
      End Get
      Set(ByVal Value As String)
        chkReminder.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Duration' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Duration:"), _
    Description("Determines the prompt for the 'Duration' property.")> _
    Public Property DurationPrompt() As String
      Get
        Return lblDuration.Text
      End Get
      Set(ByVal Value As String)
        lblDuration.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the prompt for the 'Priority' property.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Priority:"), _
    Description("Determines the prompt for the 'Priority' property.")> _
    Public Property PriorityPrompt() As String
      Get
        Return lblPriority.Text
      End Get
      Set(ByVal Value As String)
        lblPriority.Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines how the user will set an appointment's length.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_TimeDisplay), _
    Description("Determines how the user will set an appointment's length.")> _
    Public Property TimeDisplay() As Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants
      Get
        Return m_TimeDisplay
      End Get
      Set(ByVal Value As Gravitybox.Objects.AppointmentDialogSettings.TimeDisplayConstants)
        m_TimeDisplay = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the increment into which to break an hour.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_TimeIncrement), _
    Description("Determines the increment into which to break an hour.")> _
    Public Property TimeIncrement() As Gravitybox.Controls.Schedule.TimeIncrementConstants
      Get
        Return Me.Reminder.DialogSettings.TimeIncrement
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.TimeIncrementConstants)
        Me.Reminder.DialogSettings.TimeIncrement = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the mode of category selection by the user.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_CategoryEditMode), _
    Description("Determines the mode of category selection by the user.")> _
    Public Property CategoryEditMode() As Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants
      Get
        Return m_CategoryEditMode
      End Get
      Set(ByVal Value As Gravitybox.Objects.AppointmentDialogSettings.ListEditConstants)
        m_CategoryEditMode = Value
      End Set
    End Property

		''' <summary>
		''' Determines the display attributes of the window.
		''' </summary>
		<Browsable(True), _
		Category("Appearance"), _
		Description("Determines the display attributes of the window.")> _
		Public Property Appearance() As Appearance
			Get
				Return m_Appearance
			End Get
			Set(ByVal Value As Appearance)
				If Value Is Nothing Then
					Me.SetupDefaultAppearance()
				Else
					m_Appearance = Value
				End If

				Me.BackColor = Me.Appearance.BackColor
				Me.txtCategory.BackColor = Me.Appearance.BackColor
				Me.txtProvider.BackColor = Me.Appearance.BackColor
				Me.txtResource.BackColor = Me.Appearance.BackColor
				Me.txtText.BackColor = Me.Appearance.BackColor
			End Set
		End Property

#End Region

#Region "Initialize"

    Private Sub AppointmentProperties()

      m_AllowSubject = m_def_AllowSubject
      m_AllowRoom = m_def_AllowRoom
      m_AllowAppointmentType = m_def_AllowAppointmentType
      m_AllowDate = m_def_AllowDate
      m_AllowTime = m_def_AllowTime
      m_AllowAlarm = m_def_AllowAlarm
      m_AllowText = m_def_AllowText
      m_AllowProvider = m_def_AllowProvider
      m_AllowResource = m_def_AllowResource
      m_AllowCategory = m_def_AllowCategory
      m_AllowPriority = m_def_AllowPriority
      m_AllowMasterCategories = m_def_AllowMasterCategories
      m_EnforceBounds = m_def_EnforceBounds

      'Initialize the screen controls
      Me.cboReminder.Enabled = Me.chkReminder.Checked

      imgAlarm.Image = (New Icon(GetProjectFileAsStream("bell.big.ico"))).ToBitmap()
      picClock.Image = (New Icon(GetProjectFileAsStream("clock.ico"))).ToBitmap()

    End Sub

#End Region

#Region "Save"

    ''' <summary>
    ''' Determines if this control is in a valid state.
    ''' </summary>
    ''' <remarks>This value determines if the length is greater than 0, the date is in bounds, the time is in bounds, etc.</remarks>
    Public Function IsValid() As Boolean

      Try

        Dim outOfRange As Boolean = False

        'Verify that the date is valid
        If Me.AllowDate AndAlso Me.EnforceBounds Then
          If IsEndDateVisible() Then
            'Check the start and end dates to be in range
            If Not Me.Appointment.MainObject.IsDateInRange(dtpStartDate.Value) Then
              outOfRange = True
            ElseIf Not Me.Appointment.MainObject.IsDateInRange(dtpEndDate.Value) Then
              outOfRange = True
            End If
          Else
            'Check the start date to be in range
            If Not Me.Appointment.MainObject.IsDateInRange(dtpStartDate.Value) Then
              outOfRange = True
            End If
          End If
        End If

        'If there is a value of of range then raise an event to give a chance to change the default prompt 
        If outOfRange Then
          Dim eventParam As New Gravitybox.Objects.EventArgs.TextExtendedEventArgs("A specified value is out of range!", "Error!", False)
          Me.OnSaveValueOutOfRange(eventParam)
          If eventParam.Prompt And (eventParam.Text <> "") Then
            Call MsgBox(eventParam.Text, MsgBoxStyle.Exclamation, eventParam.Parameter2)
          End If
          Return eventParam.IsValid
        End If

        'Validate min/max length
        Dim bMinMaxOutOfRange As Boolean = False
        If Appointment.MinLength <> -1 Then
          If GetSpecifiedAppointmentLength() < Appointment.MinLength Then bMinMaxOutOfRange = True
        End If
        If Appointment.MaxLength <> -1 Then
          If GetSpecifiedAppointmentLength() > Appointment.MaxLength Then bMinMaxOutOfRange = True
        End If

        'Dispaly an error if the MinLength/MaxLength value is out of range
        If bMinMaxOutOfRange Then
          Dim eventParam As New Gravitybox.Objects.EventArgs.TextExtendedEventArgs("The appointment's minimum length or maximum length value is out of range!", "Error!", False)
          OnSaveValueOutOfRange(eventParam)
          If eventParam.Prompt And (eventParam.Text <> "") Then
            Call MsgBox(eventParam.Text, MsgBoxStyle.Exclamation, eventParam.Parameter2)
          End If
          Return eventParam.IsValid
        End If

        'Verify that the room is valid
        If Me.AllowRoom Then
          If Me.cboRoom.SelectedIndex = -1 Then
            Return False
          End If
        End If

        'Verify that the room is valid
        If Me.AllowAppointmentType Then
          If Me.cboAppointmentType.SelectedIndex = -1 Then
            Return False
          End If
        End If

        'Verify that the priority is valid
        If Me.AllowPriority Then
          If Me.cboPriority.SelectedIndex = -1 Then
            Return False
          End If
        End If

        'Make sure that the appointment is not in a NoDropArea
        If Not CheckNoDropAreaCollection() Then
          Return False
        End If

        'All is well - IsValid
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Private Function CheckNoDropAreaCollection() As Boolean

      Try

        Dim isError As Boolean = False
        Me.ValidateTimeCombos()

        'Enforce NoDropAreaCollection
        Select Case Me.Appointment.MainObject.ViewMode
          Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.Month
            'Date/Time
            If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
              isError = True
            End If

          Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayLeftRoomTop
            'Date/Room
            If cboRoom.SelectedIndex <> -1 Then
              Dim room As Gravitybox.Objects.Room = CType(Me.Appointment.MainObject.RoomCollection.VisibleList(cboRoom.SelectedIndex), Room)
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), room) Then
                isError = True
              End If
            End If

          Case Schedule.ViewModeConstants.DayLeftResourceTop
            'Date/Resource
            For Each resource As Gravitybox.Objects.Resource In Appointment.ResourceList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), resource) Then
                isError = True
                Exit For
              End If
            Next

          Case Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftProviderTop
            'Date/Provider 
            For Each provider As Gravitybox.Objects.Provider In Appointment.ProviderList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), provider) Then
                isError = True
                Exit For
              End If
            Next

          Case Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop
            'Day/Room/Time
            If cboRoom.SelectedIndex <> -1 Then
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), Me.Appointment.MainObject.RoomCollection(cboRoom.SelectedIndex), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
              End If
            End If

          Case Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayProviderLeftTimeTop
            'Day/Provider/Time
            If cboProvider.SelectedIndex <> -1 Then
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), Me.Appointment.MainObject.ProviderCollection(cboProvider.SelectedIndex), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
              End If
            End If

          Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop
            'Room/Time
            If cboRoom.SelectedIndex <> -1 Then
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(Me.Appointment.MainObject.RoomCollection(cboRoom.SelectedIndex), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
              End If
            End If

          Case Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft
            'Provider/Time
            For Each provider As Gravitybox.Objects.Provider In Appointment.ProviderList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(provider, CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
                Exit For
              End If
            Next

          Case Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop
            'Room/Provider
            If cboRoom.SelectedIndex <> -1 Then
              For Each provider As Gravitybox.Objects.Provider In Appointment.ProviderList
                If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(Me.Appointment.MainObject.RoomCollection(cboRoom.SelectedIndex), provider) Then
                  isError = True
                  Exit For
                End If
              Next
            End If

          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            'Date/Time/Provider
            For Each provider As Gravitybox.Objects.Provider In Appointment.ProviderList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(provider, GetDate(dtpStartDate.Value), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
                Exit For
              End If
            Next

          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            'Date/Time/Provider
            For Each room As Gravitybox.Objects.Room In Appointment.ProviderList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), room, CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
                Exit For
              End If
            Next

          Case Schedule.ViewModeConstants.Week
            'Date/Time
            If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
              isError = True
            End If

          Case Schedule.ViewModeConstants.MonthFull
            'Date/Time
            If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(GetDate(dtpStartDate.Value), CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
              isError = True
            End If

          Case Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft
            'Resource/Time
            For Each resource As Gravitybox.Objects.Resource In Appointment.ResourceList
              If Me.Appointment.MainObject.NoDropAreaCollection.ToList.IsOverlap(resource, CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, Me.GetSpecifiedAppointmentLength) Then
                isError = True
                Exit For
              End If
            Next

          Case Else
            Call ErrorModule.ViewmodeErr()

        End Select

        'Prompt with error if need be
        If isError Then
          Dim eventParam As New Gravitybox.Objects.EventArgs.TextExtendedEventArgs("The appointment overlaps an invalid area. The appointment was not saved!", "Error!", False)
          OnSaveInvalidArea(eventParam)
          If eventParam.Prompt And (eventParam.Text <> "") Then
            Call MsgBox(eventParam.Text, MsgBoxStyle.Exclamation, eventParam.Parameter2)
          End If
          'This allows one to override this error
          Return eventParam.IsValid
        Else
          Return True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Persists the control settings to the appointment object.
    ''' </summary>
    Public Function Save() As Boolean

      If Me.Appointment Is Nothing Then Return False

      Dim lockKey As String = Me.ScheduleObject.PrepareForProcessing
      Try

        'Verify that this control is in a state that may be saved
        If Not IsValid() Then Return False

        Me.ValidateTimeCombos()

        If Me.AllowSubject Then
          Appointment.Subject = txtSubject.Text
        End If

        If Me.AllowRoom And (Not (cboRoom.SelectedItem Is Nothing)) Then
          Appointment.Room = CType(cboRoom.SelectedItem, Gravitybox.Objects.Room)
        End If

        If Me.AllowAppointmentType And (Not (cboAppointmentType.SelectedItem Is Nothing)) Then
          Appointment.AppointmentType = CType(cboAppointmentType.SelectedItem, Gravitybox.Objects.AppointmentType)
        End If

        If Me.AllowPriority And (Not (cboPriority.SelectedItem Is Nothing)) Then
          Appointment.Priority = CType(cboPriority.SelectedItem, Gravitybox.Objects.Priority)
        End If

        If Me.AllowAlarm Then
          Appointment.Alarm.Reminder = Reminder.GetDurationValue(Me.cboReminder.Text)
					Appointment.Alarm.IsArmed = CBool(chkReminder.CheckState = CheckState.Checked)
					If Appointment.Alarm.IsArmed Then
						Appointment.Alarm.ReminderDisplayed = False
					End If
        End If

        If Me.AllowDate And Me.AllowTime Then
          Appointment.StartDate = GetDate(dtpStartDate.Value)
          Appointment.StartTime = CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue
          Appointment.Length = GetSpecifiedAppointmentLength()
        ElseIf Me.AllowDate Then
          Appointment.StartDate = GetDate(dtpStartDate.Value)
          Appointment.Length = GetSpecifiedAppointmentLength()
        ElseIf Me.AllowTime Then
          Appointment.StartTime = CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue
          Appointment.Length = GetSpecifiedAppointmentLength()
        End If

        If Me.AllowEvents Then
          Appointment.IsEvent = chkEvent.Checked
        End If

        If Me.AllowText Then
          Appointment.Text = txtText.Text
        End If

        If Me.AllowPriority Then
          'TODO
        End If

        m_WasSaved = True
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        Me.ScheduleObject.PrepareForProcessing(lockKey)
      End Try

    End Function

#End Region

#Region "Resize"

    Private Sub AppointmentProperties_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      Call ResizeControl()
    End Sub

    Private Sub ResizeControl()

      Const TheLeft As Integer = 8
      Const TheWidth As Integer = 512
      Const BufferSize As Integer = 10
      Dim position As Integer = 0
      Static inHere As Boolean = False

      If inHere Then Return
      inHere = True

      Try

        'Resize the appropriate panels
        hdrMessage.Width = TheWidth
        pnlSubject.Size = New Size(TheWidth, txtSubject.Height)
        pnlRoom.Size = New Size(TheWidth \ 2, cboRoom.Height)
        pnlAppointmentType.Size = New Size(TheWidth \ 2, cboAppointmentType.Height)
        pnlProvider.Size = New Size(TheWidth, cmdProvider.Height)
        pnlResource.Size = New Size(TheWidth, cmdResource.Height)
        pnlCategory.Size = New Size(TheWidth, cmdCategory.Height)

        'Resize the lines
        Line1.Size = New Size(TheWidth, 1)
        Line2.Size = Line1.Size
        Line3.Size = Line1.Size

        'Set the visiblility of all 
        Me.pnlAlarm.Visible = Me.AllowAlarm
        Me.pnlCategory.Visible = Me.AllowCategory
        Me.pnlPriority.Visible = Me.AllowPriority
        Me.pnlProvider.Visible = Me.AllowProvider
        Me.pnlResource.Visible = Me.AllowResource
        Me.pnlRoom.Visible = Me.AllowRoom
        Me.pnlAppointmentType.Visible = Me.AllowAppointmentType
        Me.pnlSubject.Visible = Me.AllowSubject
        Me.pnlTime.Visible = Me.AllowDate Or Me.AllowTime
        Me.pnlText.Visible = Me.AllowText

        If WarningText = "" Then
          hdrMessage.Visible = False
        Else
          hdrMessage.Visible = True
          position += hdrMessage.Height + (TextMargin * 3)
        End If

        If Me.AllowSubject Then
          pnlSubject.Location = New Point(TheLeft, position)
          position += pnlSubject.Height + BufferSize
        End If

        'If Me.AllowRoom Then
        pnlRoom.Location = New Point(TheLeft, position)
        'End If
        'If Me.AllowAppointmentType Then
        pnlAppointmentType.Location = New Point(pnlRoom.Left + pnlRoom.Width, position)
        'End If
        If Me.AllowRoom Or Me.AllowAppointmentType Then
          position += pnlRoom.Height + BufferSize
        End If

        'Add line if necessary
        If Me.AllowSubject Or Me.AllowRoom Or Me.AllowAppointmentType Then
          Line1.Location = New Point(TheLeft, position - (BufferSize \ 2))
        Else
          Line1.Location = New Point(TheLeft, -1)
        End If

        If Me.AllowDate Or Me.AllowTime Then
          pnlTime.Location = New Point(TheLeft, position)
          position += pnlTime.Height + BufferSize
        End If

        'If there is time but no date then move time boxes
        If Not Me.AllowDate AndAlso Me.AllowTime Then
          cboStartTime.Location = dtpStartDate.Location
          cboEndTime.Location = dtpEndDate.Location
          cboDuration.Location = cboEndTime.Location
        End If

        'Add line if necessary
        If Me.AllowTime Or Me.AllowDate Or Me.AllowAlarm Or Me.AllowPriority Then
          Line2.Location = New Point(TheLeft, position - (BufferSize \ 2))
        Else
          Line2.Location = New Point(TheLeft, -1)
        End If

        'Alarm/Priority
        If Me.AllowAlarm Then
          pnlAlarm.Location = New Point(TheLeft, position)
        End If
        If Me.AllowPriority Then
          pnlPriority.Location = New Point(pnlPriority.Left, position)
        End If
        If Me.AllowAlarm Or Me.AllowPriority Then
          position += pnlAlarm.Height + BufferSize
        End If

        If Me.AllowText Then
          pnlText.Location = New Point(TheLeft, position)
          position += pnlText.Height + BufferSize
        End If

        'Add line if necessary
        If (Me.AllowAlarm Or Me.AllowPriority Or Me.AllowText) And (Me.AllowProvider Or Me.AllowCategory Or Me.AllowResource) Then
          Line3.Location = New Point(TheLeft, position - (BufferSize \ 2))
        Else
          Line3.Location = New Point(TheLeft, -1)
        End If

        If Me.AllowProvider Then
          pnlProvider.Location = New Point(TheLeft, position)
          position += pnlProvider.Height + BufferSize
        End If
        If Me.AllowResource Then
          pnlResource.Location = New Point(TheLeft, position)
          position += pnlResource.Height + BufferSize
        End If
        If Me.AllowCategory Then
          pnlCategory.Location = New Point(TheLeft, position)
          position += pnlCategory.Height + BufferSize
        End If

        'Setup category edit mode
        lblCategory.SetBounds(cmdCategory.Left, cmdCategory.Top, cmdCategory.Width, cmdCategory.Height)
        cboCategory.SetBounds(txtCategory.Left, txtCategory.Top, txtCategory.Width, txtCategory.Height)
        If Me.CategoryEditMode = AppointmentDialogSettings.ListEditConstants.Fixed Then
          lblCategory.Visible = False
          cboCategory.Visible = False
          cmdCategory.Visible = True
          txtCategory.Visible = True
        ElseIf Me.CategoryEditMode = AppointmentDialogSettings.ListEditConstants.FreeForm Then
          lblCategory.Visible = True
          cboCategory.Visible = True
          cmdCategory.Visible = False
          txtCategory.Visible = False
        End If

        'Remove last buffer
        If Me.AllowProvider OrElse Me.AllowResource OrElse Me.AllowCategory Then
          position -= BufferSize
        End If

        Me.Size = New Size(TheWidth + (TheLeft * 2), position)
      Catch ex As Exception
        'Do Nothing
      Finally
        inHere = False
      End Try

    End Sub

#End Region

#Region "Refresh"

    ''' <summary>
    ''' Redraw the control.
    ''' </summary>
    Public Overrides Sub Refresh()
      Try

        'If this control is NOT enabled then default the control
        If Not CheckEnabled() Then
          txtSubject.Text = ""
          cboRoom.Text = ""
          cboPriority.Text = ""
          cboAppointmentType.Text = ""
          chkReminder.CheckState = CheckState.Unchecked
          txtText.Text = ""
          cboProvider.Text = ""
          cboResource.Text = ""
          cboCategory.Text = ""
          dtpStartDate.Value = #1/1/1980#         'DefaultNoDate
          dtpEndDate.Value = dtpStartDate.Value
          If cboStartTime.Items.Count > 0 Then cboStartTime.SelectedIndex = 0
          If cboEndTime.Items.Count > 0 Then cboEndTime.SelectedIndex = 0
          Me.Enabled = False
          chkEvent.Checked = False
          Call SetupEvent()
          Call ResizeControl()
          Return
        End If

        Call LoadRooms()
        Call LoadPriorities()
        Call LoadAppointmentTypes()
        Call Reminder.LoadReminderCombo(Me.cboReminder)
        Call Reminder.LoadDurationCombo(Me.cboDuration, True)
        Call Reminder.LoadTimeCombo(Me.cboStartTime)
        Call Reminder.LoadTimeCombo(Me.cboEndTime)

        txtSubject.Text = Appointment.Subject
        txtText.Text = Appointment.Text
        hdrMessage.Text = WarningText
        Reminder.SetItem(Appointment.Length.ToString, cboDuration)

        chkReminder.CheckState = CType(IIf(Appointment.Alarm.IsArmed, CheckState.Checked, CheckState.Unchecked), CheckState)
        Call Reminder.SetItem(Appointment.Alarm.Reminder.ToString, cboReminder)

        '******************************************
        'Set Combos
        Dim comboIndex As Integer
        comboIndex = ScheduleObject.RoomCollection.IndexOfVisible(Appointment.Room)
        If comboIndex >= 0 Then cboRoom.SelectedItem = cboRoom.Items(comboIndex)
        comboIndex = ScheduleObject.PriorityCollection.IndexOf(Appointment.Priority)
        If comboIndex >= 0 Then cboPriority.SelectedItem = cboPriority.Items(comboIndex)
        comboIndex = ScheduleObject.AppointmentTypeCollection.IndexOf(Appointment.AppointmentType)
        If comboIndex >= 0 Then cboAppointmentType.SelectedItem = cboAppointmentType.Items(comboIndex)

        Call ReloadCategories()
        Call ReloadProviders()
        Call ReloadResources()

        '******************************************

        Dim startDate As DateTime = Appointment.StartDate
        Dim startTime As DateTime = Appointment.StartTime
        Dim endDate As DateTime
        Dim endTime As DateTime

        If (startDate = DefaultNoDate) Then startDate = GetDate(Now)
        If (startTime = DefaultNoTime) Then startTime = PivotTime

        endDate = GetDate(DateAdd(DateInterval.Minute, Appointment.Length, Date.Parse(startDate.ToShortDateString & " " & startTime.ToShortTimeString)))
        endTime = GetTime(DateAdd(DateInterval.Minute, Appointment.Length, Date.Parse(startDate.ToShortDateString & " " & startTime.ToShortTimeString)))

        If Me.AllowDate Then
          dtpStartDate.Value = startDate
          dtpEndDate.Value = endDate
        End If

        If Me.AllowTime Then
          Call Reminder.SetItem(startTime, cboStartTime)
          Call Reminder.SetItem(endTime, cboEndTime)
          Me.cboStartTime.Visible = True
          Me.cboEndTime.Visible = (Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.EndTime)
          'dtpStartTime.Value = Date.Parse(startDate.ToShortDateString & " " & startTime.ToShortTimeString)
          'dtpEndTime.Value = Date.Parse(endDate.ToShortDateString & " " & endTime.ToShortTimeString)
        End If

        Me.Enabled = True

        'Hide the date box if necessary
        If Me.AllowDate Then
          Me.dtpStartDate.Visible = True
          Me.dtpEndDate.Visible = IsEndDateVisible()
        Else
          Me.dtpStartDate.Visible = False
          Me.dtpEndDate.Visible = False
          Me.cboStartTime.Location = Me.dtpStartDate.Location
          Me.cboEndTime.Location = dtpEndDate.Location
        End If

        Me.cboStartTime.Visible = Me.AllowTime
        Me.cboEndTime.Visible = Me.AllowTime

        'Setup the IsEvent checkbox
        If Me.AllowEvents And Me.AllowTime Then
          chkEvent.Visible = True
          chkEvent.Checked = Appointment.IsEvent
        Else
          chkEvent.Visible = False
        End If
        Call SetupEvent()
        Call ResizeControl()

        'Set Focus
        If Me.AllowSubject Then
          txtSubject.Focus()
        ElseIf Me.AllowRoom Then
          cboRoom.Focus()
        ElseIf Me.AllowAppointmentType Then
          cboRoom.Focus()
        ElseIf Me.AllowTime Then
          dtpStartDate.Focus()
        ElseIf Me.AllowAlarm Then
          chkReminder.Focus()
        ElseIf Me.AllowPriority Then
          cboPriority.Focus()
        ElseIf Me.AllowText Then
          txtText.Focus()
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "LoadRooms"

    Private Sub LoadRooms()

      If Not CheckEnabled() Then Return

      Try

        Call Me.cboRoom.Items.Clear()
        For Each element As Gravitybox.Objects.Room In ScheduleObject.RoomCollection
          If element.Visible Then
            Call Me.cboRoom.Items.Add(element)
          End If
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "LoadPriorities"

    Private Sub LoadPriorities()

      If Not CheckEnabled() Then Return

      Try

        Call Me.cboPriority.Items.Clear()
        For Each element As Gravitybox.Objects.Priority In ScheduleObject.PriorityCollection
          Call Me.cboPriority.Items.Add(element)
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "LoadAppointmentTypes"

    Private Sub LoadAppointmentTypes()

      If Not CheckEnabled() Then Return

      Try

        Call Me.cboAppointmentType.Items.Clear()
        For Each element As Gravitybox.Objects.AppointmentType In ScheduleObject.AppointmentTypeCollection
          Call Me.cboAppointmentType.Items.Add(element)
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Reload Lists"

    Private Sub ReloadCategories()

      Try

        If Not CheckEnabled() Then Return
        If Me.CategoryEditMode = AppointmentDialogSettings.ListEditConstants.Fixed Then
          Me.txtCategory.Text = ""
          For Each category As Gravitybox.Objects.Category In Appointment.CategoryList
            txtCategory.Text += category.Text & ", "
          Next

          'Remove the last comma
          If Appointment.CategoryList.Count > 0 Then txtCategory.Text = txtCategory.Text.Substring(0, txtCategory.Text.Length - 2)

        ElseIf Me.CategoryEditMode = AppointmentDialogSettings.ListEditConstants.FreeForm Then
          'Load the combo with all categories
          cboCategory.Items.Clear()
          For Each category As Gravitybox.Objects.Category In Me.ScheduleObject.CategoryCollection
            cboCategory.Items.Add(category.Text)
          Next

          'Set the combo to the first cateogry if it exists
          If Appointment.CategoryList.Count > 0 Then
            cboCategory.Text = Appointment.CategoryList(0).Text
          End If

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub ReloadProviders()

      Try
        If Not CheckEnabled() Then Return

        Dim provider As Provider
        Me.txtProvider.Text = ""
        For Each provider In Appointment.ProviderList
          txtProvider.Text += provider.Text & ", "
        Next
        'Remove the last comma
        If Appointment.ProviderList.Count > 0 Then txtProvider.Text = txtProvider.Text.Substring(0, txtProvider.Text.Length - 2)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub ReloadResources()

      Try

        If Not CheckEnabled() Then Return

        Me.txtResource.Text = ""
        For Each resource As Gravitybox.Objects.Resource In Appointment.ResourceList
          txtResource.Text += resource.Text & ", "
        Next
        'Remove the last comma
        If Appointment.ResourceList.Count > 0 Then txtResource.Text = txtResource.Text.Substring(0, txtResource.Text.Length - 2)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Child Controls"

    Private Sub cboReminder_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboReminder.Validating
      Call Reminder.SetItem(cboReminder.Text, cboReminder)
    End Sub

    Private Sub cboDuration_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboDuration.Validating
      Call Reminder.SetItem(cboDuration.Text, cboDuration, True)
    End Sub

    Private Sub chkReminder_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkReminder.CheckStateChanged
      Me.cboReminder.Enabled = Me.chkReminder.Checked
    End Sub

    Private Sub cmdProvider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProvider.Click

      Try
        If ScheduleObject.Dialogs.ShowProviderDialog(Me.Appointment) Then
          Call ReloadProviders()
          IsDirtyProvider = True
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdResource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdResource.Click

      Try
        If ScheduleObject.Dialogs.ShowResourceDialog(Me.Appointment) Then
          Call ReloadResources()
          IsDirtyResource = True
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cmdCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategory.Click

      Try
        Dim configuration As New CategoryDialogSettings
        configuration.AllowMaster = Me.AllowMasterCategories
        If ScheduleObject.Dialogs.ShowCategoryDialog(Me.Appointment, configuration) Then
          Call ReloadCategories()
          IsDirtyCategory = True
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub chkEvent_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEvent.CheckedChanged

      Try
        Call SetupEvent()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Sub cboCategory_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cboCategory.Validating

      Try
        'Search for the entered text to determine if it exists
        Dim found As Boolean = False
        For Each category As Gravitybox.Objects.Category In Me.ScheduleObject.CategoryCollection
          If String.Compare(category.Text, cboCategory.Text, True) = 0 Then
            found = True
          End If
        Next

        'If the item is not found in the colleciton then add it to the collection
        If (Not found) Then
          Dim newCategory As Gravitybox.Objects.Category = Me.ScheduleObject.CategoryCollection.Add("", cboCategory.Text)
          Me.Appointment.CategoryList.Clear()
          Me.Appointment.CategoryList.Add(newCategory)
          Me.ReloadCategories()
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "SetupEvent"

    Private Sub SetupEvent()

      Try
        cboDuration.Location = dtpEndDate.Location
        cboStartTime.Visible = (Not chkEvent.Checked) AndAlso Me.AllowTime
        cboEndTime.Visible = (Not chkEvent.Checked) AndAlso Me.AllowTime AndAlso (Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.EndTime)
        dtpEndDate.Visible = IsEndDateVisible()
        lblDuration.Visible = (Not chkEvent.Checked) AndAlso Me.AllowTime AndAlso (Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.Duration)
        cboDuration.Visible = (Not chkEvent.Checked) AndAlso Me.AllowTime AndAlso (Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.Duration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "IsEndDateVisible"

    Private Function IsEndDateVisible() As Boolean
      If (Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.Duration) Then
        Return False
      ElseIf chkEvent.Checked Then
        Return False
      ElseIf Me.AllowDate Then
        Return True
      Else
        Return False
      End If
    End Function

#End Region

#Region "Date/Time in bounds"

    Private Function GetSpecifiedAppointmentLength() As Integer

      Try

        If Me.AllowDate And Me.AllowTime Then

          Me.ValidateTimeCombos()

          'Allow Date/Time
          Dim startDateTime As DateTime = Date.Parse(GetDate(dtpStartDate.Value) & " " & CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue)
          Dim endDateTime As DateTime
          If Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.EndTime Then
            If cboEndTime.SelectedIndex = -1 Then
              Dim theValue As Date
#If VS2005 Then
              If (Date.TryParse(cboEndTime.Text, theValue)) Then
#Else
              Try
                theValue = Date.Parse(cboEndTime.Text)
              Catch ex As Exception
                theValue = startDateTime.AddHours(1)
              End Try
              If (True) Then
#End If
                Dim theTime As New InternalTime(theValue, CType(cboEndTime.Items(0), InternalTime).Format)
                endDateTime = Date.Parse(GetDate(dtpEndDate.Value) & " " & theTime.TimeValue)
              Else
                endDateTime = startDateTime.AddHours(1)
              End If
            Else
              endDateTime = Date.Parse(GetDate(dtpEndDate.Value) & " " & CType(cboEndTime.Items(cboEndTime.SelectedIndex), InternalTime).TimeValue)
            End If

          ElseIf Me.TimeDisplay = AppointmentDialogSettings.TimeDisplayConstants.Duration Then
            endDateTime = startDateTime.AddMinutes(Reminder.GetDurationValue(cboDuration.Text))
          End If
          Dim length As Integer = GetIntlInteger(DateDiff(DateInterval.Minute, startDateTime, endDateTime))
          If length < 0 Then length = 0
          Return length

        ElseIf Me.AllowDate Then
          'Allow Date/No Time 
          Return 0

        ElseIf Me.AllowTime Then
          'Allow Time/No Date
          Me.ValidateTimeCombos()
          Dim length As Integer = GetIntlInteger(DateDiff(DateInterval.Minute, CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue, CType(cboEndTime.Items(cboEndTime.SelectedIndex), InternalTime).TimeValue))
          If length < 0 Then length = 0
          Return length

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Private Sub CheckBounds()

      Try
        If Not CheckEnabled() Then Return

        Me.ValidateTimeCombos()

        Dim startTime As Date = CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue
        Dim startDate As DateTime = New DateTime(dtpStartDate.Value.Year, dtpStartDate.Value.Month, dtpStartDate.Value.Day, startTime.Hour, startTime.Minute, 0)

        Dim endTime As Date = CType(cboEndTime.Items(cboEndTime.SelectedIndex), InternalTime).TimeValue
        Dim endDate As DateTime = New DateTime(dtpEndDate.Value.Year, dtpEndDate.Value.Month, dtpEndDate.Value.Day, endTime.Hour, endTime.Minute, 0)

        If endDate <= startDate Then
          startTime = CType(cboStartTime.Items(cboStartTime.SelectedIndex), InternalTime).TimeValue
          Reminder.SetItem(startTime.AddMinutes(DefaultAppointmentLength), cboEndTime)
        Else
          'Reset the new default length
          DefaultAppointmentLength = CInt(endDate.Subtract(startDate).TotalMinutes)
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub dtpStartDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpStartDate.Validating
      Call CheckBounds()
    End Sub

    Private Sub dtpStartTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
      Call CheckBounds()
    End Sub

    Private Sub dtpEndDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpEndDate.Validating
      Call CheckBounds()
    End Sub

    Private Sub dtpEndTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
      Call CheckBounds()
    End Sub

#End Region

#Region "CheckEnabled"

    Private Function CheckEnabled() As Boolean

      Try
        If Appointment Is Nothing Then
          Me.Enabled = False
          Return False
        End If
        If ScheduleObject Is Nothing Then
          Me.Enabled = False
          Return False
        End If
        If ScheduleObject.AppointmentCollection.IndexOf(Appointment) = -1 Then Return False
        Me.Enabled = True       'All is well
        Return True
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Load"

    Private Sub AppointmentProperties_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Try
        imgAlarm.Image = (New Icon(GetProjectFileAsStream("bell.big.ico"))).ToBitmap
        hdrMessage.Icon = New Icon(GetProjectFileAsStream("warning.ico"))
        picClock.Image = (New Icon(GetProjectFileAsStream("clock.ico"))).ToBitmap
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "ValidateTimeCombos"

    Private Sub ValidateTimeCombos()

      If (cboStartTime.SelectedIndex = -1) Then
        Reminder.SetItem(GetTime(DateTime.Parse(cboStartTime.Text)), cboStartTime)
      End If
      If (cboEndTime.SelectedIndex = -1) Then
        Reminder.SetItem(GetTime(DateTime.Parse(cboEndTime.Text)), cboEndTime)
      End If

    End Sub

#End Region

#Region "ResetCaptions"

    Private Sub ResetCaptions()

      If ScheduleObject Is Nothing Then Return

      Try
        lblRoom.Text = ScheduleObject.RoomCollection.ObjectSingular & ":"
        cmdProvider.Text = ScheduleObject.ProviderCollection.ObjectPlural
        cmdResource.Text = ScheduleObject.ResourceCollection.ObjectPlural
        cmdCategory.Text = ScheduleObject.CategoryCollection.ObjectPlural

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "ResetCollections"

    Friend Sub ResetCollections()
      Try
        If IsDirtyCategory Then
          Me.Appointment.CategoryList.Clear()
          Me.Appointment.CategoryList.FromArray(Me.OriginalCategories)
        End If

        If IsDirtyResource Then
          Me.Appointment.ResourceList.Clear()
          Me.Appointment.ResourceList.FromArray(Me.OriginalResources)
        End If

        If IsDirtyProvider Then
          Me.Appointment.ProviderList.Clear()
          Me.Appointment.ProviderList.FromArray(Me.OriginalProviders)
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "SetupDefaultAppearance"

		Private Sub SetupDefaultAppearance()
			m_Appearance = New Appearance
			m_Appearance.BackColor = SystemColors.Control
			m_Appearance.ForeColor = Color.Black
		End Sub

#End Region

#Region "On... Event Methods"

    Protected Overridable Sub OnSaveInvalidArea(ByVal e As TextExtendedEventArgs)
      RaiseEvent SaveInvalidArea(Me, e)
    End Sub

    Protected Overridable Sub OnSaveValueOutOfRange(ByVal e As TextExtendedEventArgs)
      RaiseEvent SaveValueOutOfRange(Me, e)
    End Sub

#End Region

  End Class

End Namespace