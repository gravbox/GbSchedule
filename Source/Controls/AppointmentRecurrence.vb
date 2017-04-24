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
Imports System.ComponentModel

Namespace Gravitybox.Controls

  ''' <summary>
  ''' This control is used to give the user a default appointment recurrence editor.
  ''' </summary>
  <ToolboxItem(True), _
  ToolboxBitmap(GetType(Gravitybox.Controls.AppointmentRecurrence)), _
  Browsable(True), _
  DesignTimeVisible(True)> _
  Public Class AppointmentRecurrence
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents pnlMiddle As System.Windows.Forms.Panel
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lblStartTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lblEndTimeHeader As System.Windows.Forms.Label
    Friend WithEvents lblDurationHeader As System.Windows.Forms.Label
    Friend WithEvents optMasterDay As System.Windows.Forms.RadioButton
    Friend WithEvents optMasterWeek As System.Windows.Forms.RadioButton
    Friend WithEvents optMasterMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optDay1 As System.Windows.Forms.RadioButton
    Friend WithEvents optDay2 As System.Windows.Forms.RadioButton
    Friend WithEvents udDayInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDayIntervalFooter As System.Windows.Forms.Label
    Friend WithEvents lblWeekHeader As System.Windows.Forms.Label
    Friend WithEvents udWeekInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblWeekFooter As System.Windows.Forms.Label
    Friend WithEvents chkWeekday1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkWeekday7 As System.Windows.Forms.CheckBox
    Friend WithEvents optMonth1 As System.Windows.Forms.RadioButton
    Friend WithEvents optMonth2 As System.Windows.Forms.RadioButton
    Friend WithEvents udMonthDayIndex As System.Windows.Forms.NumericUpDown
    Friend WithEvents udMonthInterval1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblMonthMiddle1 As System.Windows.Forms.Label
    Friend WithEvents lblMonthFooter1 As System.Windows.Forms.Label
    Friend WithEvents cboMonthDayOrdinal As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonthDayPosition As System.Windows.Forms.ComboBox
    Friend WithEvents lblMonthFooter2 As System.Windows.Forms.Label
    Friend WithEvents lblMonthMiddle2 As System.Windows.Forms.Label
    Friend WithEvents udMonthInterval2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblRangeStart As System.Windows.Forms.Label
    Friend WithEvents dtpRangeStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents optRangeEnd2 As System.Windows.Forms.RadioButton
    Friend WithEvents optRangeEnd3 As System.Windows.Forms.RadioButton
    Friend WithEvents lblRangeOccurFooter As System.Windows.Forms.Label
    Friend WithEvents udRangeOccurences As System.Windows.Forms.NumericUpDown
    Friend WithEvents pnlMonth As System.Windows.Forms.Panel
    Friend WithEvents pnlDay As System.Windows.Forms.Panel
    Friend WithEvents pnlWeek As System.Windows.Forms.Panel
    Friend WithEvents dtpRangeEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpHeader1 As System.Windows.Forms.GroupBox
    Friend WithEvents grpHeader2 As System.Windows.Forms.GroupBox
    Friend WithEvents grpHeader3 As System.Windows.Forms.GroupBox
    Friend WithEvents optMasterYear As System.Windows.Forms.RadioButton
    Friend WithEvents pnlYear As System.Windows.Forms.Panel
    Friend WithEvents optYear1 As System.Windows.Forms.RadioButton
    Friend WithEvents udYearDayInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents optYear2 As System.Windows.Forms.RadioButton
    Friend WithEvents lblYearMiddle1 As System.Windows.Forms.Label
    Friend WithEvents cboYearDayPosition As System.Windows.Forms.ComboBox
    Friend WithEvents cboYearDayOrdinal As System.Windows.Forms.ComboBox
    Friend WithEvents cboYearMonthOrdinal As System.Windows.Forms.ComboBox
    Friend WithEvents cboYearMonthInterval As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.pnlTop = New System.Windows.Forms.Panel
      Me.lblDurationHeader = New System.Windows.Forms.Label
      Me.lblEndTimeHeader = New System.Windows.Forms.Label
      Me.lblStartTimeHeader = New System.Windows.Forms.Label
      Me.pnlMiddle = New System.Windows.Forms.Panel
      Me.pnlYear = New System.Windows.Forms.Panel
      Me.cboYearMonthOrdinal = New System.Windows.Forms.ComboBox
      Me.lblYearMiddle1 = New System.Windows.Forms.Label
      Me.cboYearDayPosition = New System.Windows.Forms.ComboBox
      Me.cboYearDayOrdinal = New System.Windows.Forms.ComboBox
      Me.optYear2 = New System.Windows.Forms.RadioButton
      Me.udYearDayInterval = New System.Windows.Forms.NumericUpDown
      Me.cboYearMonthInterval = New System.Windows.Forms.ComboBox
      Me.optYear1 = New System.Windows.Forms.RadioButton
      Me.optMasterYear = New System.Windows.Forms.RadioButton
      Me.pnlDay = New System.Windows.Forms.Panel
      Me.lblDayIntervalFooter = New System.Windows.Forms.Label
      Me.udDayInterval = New System.Windows.Forms.NumericUpDown
      Me.optDay2 = New System.Windows.Forms.RadioButton
      Me.optDay1 = New System.Windows.Forms.RadioButton
      Me.optMasterMonth = New System.Windows.Forms.RadioButton
      Me.optMasterWeek = New System.Windows.Forms.RadioButton
      Me.optMasterDay = New System.Windows.Forms.RadioButton
      Me.pnlWeek = New System.Windows.Forms.Panel
      Me.chkWeekday7 = New System.Windows.Forms.CheckBox
      Me.chkWeekday6 = New System.Windows.Forms.CheckBox
      Me.chkWeekday5 = New System.Windows.Forms.CheckBox
      Me.chkWeekday4 = New System.Windows.Forms.CheckBox
      Me.chkWeekday3 = New System.Windows.Forms.CheckBox
      Me.chkWeekday2 = New System.Windows.Forms.CheckBox
      Me.chkWeekday1 = New System.Windows.Forms.CheckBox
      Me.lblWeekFooter = New System.Windows.Forms.Label
      Me.udWeekInterval = New System.Windows.Forms.NumericUpDown
      Me.lblWeekHeader = New System.Windows.Forms.Label
      Me.pnlMonth = New System.Windows.Forms.Panel
      Me.lblMonthFooter2 = New System.Windows.Forms.Label
      Me.lblMonthMiddle2 = New System.Windows.Forms.Label
      Me.udMonthInterval2 = New System.Windows.Forms.NumericUpDown
      Me.cboMonthDayPosition = New System.Windows.Forms.ComboBox
      Me.cboMonthDayOrdinal = New System.Windows.Forms.ComboBox
      Me.lblMonthFooter1 = New System.Windows.Forms.Label
      Me.lblMonthMiddle1 = New System.Windows.Forms.Label
      Me.udMonthInterval1 = New System.Windows.Forms.NumericUpDown
      Me.udMonthDayIndex = New System.Windows.Forms.NumericUpDown
      Me.optMonth2 = New System.Windows.Forms.RadioButton
      Me.optMonth1 = New System.Windows.Forms.RadioButton
      Me.pnlBottom = New System.Windows.Forms.Panel
      Me.dtpRangeEnd = New System.Windows.Forms.DateTimePicker
      Me.lblRangeOccurFooter = New System.Windows.Forms.Label
      Me.udRangeOccurences = New System.Windows.Forms.NumericUpDown
      Me.optRangeEnd3 = New System.Windows.Forms.RadioButton
      Me.optRangeEnd2 = New System.Windows.Forms.RadioButton
      Me.dtpRangeStart = New System.Windows.Forms.DateTimePicker
      Me.lblRangeStart = New System.Windows.Forms.Label
      Me.grpHeader1 = New System.Windows.Forms.GroupBox
      Me.grpHeader2 = New System.Windows.Forms.GroupBox
      Me.grpHeader3 = New System.Windows.Forms.GroupBox
      Me.pnlTop.SuspendLayout()
      Me.pnlMiddle.SuspendLayout()
      Me.pnlYear.SuspendLayout()
      'CType(Me.udYearDayInterval, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlDay.SuspendLayout()
      'CType(Me.udDayInterval, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlWeek.SuspendLayout()
      'CType(Me.udWeekInterval, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlMonth.SuspendLayout()
      'CType(Me.udMonthInterval2, System.ComponentModel.ISupportInitialize).BeginInit()
      'CType(Me.udMonthInterval1, System.ComponentModel.ISupportInitialize).BeginInit()
      'CType(Me.udMonthDayIndex, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlBottom.SuspendLayout()
      'CType(Me.udRangeOccurences, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grpHeader1.SuspendLayout()
      Me.grpHeader2.SuspendLayout()
      Me.grpHeader3.SuspendLayout()
      Me.SuspendLayout()
      '
      'pnlTop
      '
      Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.pnlTop.Controls.Add(Me.lblDurationHeader)
      Me.pnlTop.Controls.Add(Me.lblEndTimeHeader)
      Me.pnlTop.Controls.Add(Me.lblStartTimeHeader)
      Me.pnlTop.Location = New System.Drawing.Point(8, 16)
      Me.pnlTop.Name = "pnlTop"
      Me.pnlTop.Size = New System.Drawing.Size(496, 32)
      Me.pnlTop.TabIndex = 6
      '
      'lblDurationHeader
      '
      Me.lblDurationHeader.Location = New System.Drawing.Point(330, 8)
      Me.lblDurationHeader.Name = "lblDurationHeader"
      Me.lblDurationHeader.Size = New System.Drawing.Size(165, 16)
      Me.lblDurationHeader.TabIndex = 2
      Me.lblDurationHeader.Text = "Duration:"
      '
      'lblEndTimeHeader
      '
      Me.lblEndTimeHeader.Location = New System.Drawing.Point(165, 8)
      Me.lblEndTimeHeader.Name = "lblEndTimeHeader"
      Me.lblEndTimeHeader.Size = New System.Drawing.Size(165, 16)
      Me.lblEndTimeHeader.TabIndex = 1
      Me.lblEndTimeHeader.Text = "End Time:"
      '
      'lblStartTimeHeader
      '
      Me.lblStartTimeHeader.Location = New System.Drawing.Point(0, 8)
      Me.lblStartTimeHeader.Name = "lblStartTimeHeader"
      Me.lblStartTimeHeader.Size = New System.Drawing.Size(165, 16)
      Me.lblStartTimeHeader.TabIndex = 0
      Me.lblStartTimeHeader.Text = "Start Time:"
      '
      'pnlMiddle
      '
      Me.pnlMiddle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlMiddle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.pnlMiddle.Controls.Add(Me.pnlYear)
      Me.pnlMiddle.Controls.Add(Me.optMasterYear)
      Me.pnlMiddle.Controls.Add(Me.pnlDay)
      Me.pnlMiddle.Controls.Add(Me.optMasterMonth)
      Me.pnlMiddle.Controls.Add(Me.optMasterWeek)
      Me.pnlMiddle.Controls.Add(Me.optMasterDay)
      Me.pnlMiddle.Controls.Add(Me.pnlWeek)
      Me.pnlMiddle.Controls.Add(Me.pnlMonth)
      Me.pnlMiddle.Location = New System.Drawing.Point(8, 16)
      Me.pnlMiddle.Name = "pnlMiddle"
      Me.pnlMiddle.Size = New System.Drawing.Size(496, 280)
      Me.pnlMiddle.TabIndex = 7
      '
      'pnlYear
      '
      Me.pnlYear.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.pnlYear.Controls.Add(Me.cboYearMonthOrdinal)
      Me.pnlYear.Controls.Add(Me.lblYearMiddle1)
      Me.pnlYear.Controls.Add(Me.cboYearDayPosition)
      Me.pnlYear.Controls.Add(Me.cboYearDayOrdinal)
      Me.pnlYear.Controls.Add(Me.optYear2)
      Me.pnlYear.Controls.Add(Me.udYearDayInterval)
      Me.pnlYear.Controls.Add(Me.cboYearMonthInterval)
      Me.pnlYear.Controls.Add(Me.optYear1)
      Me.pnlYear.Location = New System.Drawing.Point(88, 208)
      Me.pnlYear.Name = "pnlYear"
      Me.pnlYear.Size = New System.Drawing.Size(400, 64)
      Me.pnlYear.TabIndex = 6
      '
      'cboYearMonthOrdinal
      '
      Me.cboYearMonthOrdinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboYearMonthOrdinal.Location = New System.Drawing.Point(264, 32)
      Me.cboYearMonthOrdinal.Name = "cboYearMonthOrdinal"
      Me.cboYearMonthOrdinal.Size = New System.Drawing.Size(120, 21)
      Me.cboYearMonthOrdinal.TabIndex = 28
      '
      'lblYearMiddle1
      '
      Me.lblYearMiddle1.Location = New System.Drawing.Point(224, 32)
      Me.lblYearMiddle1.Name = "lblYearMiddle1"
      Me.lblYearMiddle1.Size = New System.Drawing.Size(32, 16)
      Me.lblYearMiddle1.TabIndex = 24
      Me.lblYearMiddle1.Text = "of"
      Me.lblYearMiddle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'cboYearDayPosition
      '
      Me.cboYearDayPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboYearDayPosition.Location = New System.Drawing.Point(152, 32)
      Me.cboYearDayPosition.Name = "cboYearDayPosition"
      Me.cboYearDayPosition.Size = New System.Drawing.Size(72, 21)
      Me.cboYearDayPosition.TabIndex = 27
      '
      'cboYearDayOrdinal
      '
      Me.cboYearDayOrdinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboYearDayOrdinal.Location = New System.Drawing.Point(80, 32)
      Me.cboYearDayOrdinal.Name = "cboYearDayOrdinal"
      Me.cboYearDayOrdinal.Size = New System.Drawing.Size(72, 21)
      Me.cboYearDayOrdinal.TabIndex = 26
      '
      'optYear2
      '
      Me.optYear2.Location = New System.Drawing.Point(16, 32)
      Me.optYear2.Name = "optYear2"
      Me.optYear2.Size = New System.Drawing.Size(64, 16)
      Me.optYear2.TabIndex = 25
      Me.optYear2.Text = "The"
      '
      'udYearDayInterval
      '
      Me.udYearDayInterval.Location = New System.Drawing.Point(208, 8)
      Me.udYearDayInterval.Name = "udYearDayInterval"
      Me.udYearDayInterval.Size = New System.Drawing.Size(56, 20)
      Me.udYearDayInterval.TabIndex = 24
      '
      'cboYearMonthInterval
      '
      Me.cboYearMonthInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboYearMonthInterval.Location = New System.Drawing.Point(80, 8)
      Me.cboYearMonthInterval.Name = "cboYearMonthInterval"
      Me.cboYearMonthInterval.Size = New System.Drawing.Size(120, 21)
      Me.cboYearMonthInterval.TabIndex = 23
      '
      'optYear1
      '
      Me.optYear1.Location = New System.Drawing.Point(16, 8)
      Me.optYear1.Name = "optYear1"
      Me.optYear1.Size = New System.Drawing.Size(64, 16)
      Me.optYear1.TabIndex = 22
      Me.optYear1.Text = "&Every"
      '
      'optMasterYear
      '
      Me.optMasterYear.Location = New System.Drawing.Point(0, 80)
      Me.optMasterYear.Name = "optMasterYear"
      Me.optMasterYear.Size = New System.Drawing.Size(80, 16)
      Me.optMasterYear.TabIndex = 3
      Me.optMasterYear.Text = "&Yearly"
      '
      'pnlDay
      '
      Me.pnlDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.pnlDay.Controls.Add(Me.lblDayIntervalFooter)
      Me.pnlDay.Controls.Add(Me.udDayInterval)
      Me.pnlDay.Controls.Add(Me.optDay2)
      Me.pnlDay.Controls.Add(Me.optDay1)
      Me.pnlDay.Location = New System.Drawing.Point(88, 8)
      Me.pnlDay.Name = "pnlDay"
      Me.pnlDay.Size = New System.Drawing.Size(400, 56)
      Me.pnlDay.TabIndex = 3
      '
      'lblDayIntervalFooter
      '
      Me.lblDayIntervalFooter.Location = New System.Drawing.Point(168, 8)
      Me.lblDayIntervalFooter.Name = "lblDayIntervalFooter"
      Me.lblDayIntervalFooter.Size = New System.Drawing.Size(224, 16)
      Me.lblDayIntervalFooter.TabIndex = 3
      Me.lblDayIntervalFooter.Text = "day(s)"
      '
      'udDayInterval
      '
      Me.udDayInterval.Location = New System.Drawing.Point(96, 8)
      Me.udDayInterval.Name = "udDayInterval"
      Me.udDayInterval.Size = New System.Drawing.Size(56, 20)
      Me.udDayInterval.TabIndex = 5
      '
      'optDay2
      '
      Me.optDay2.Location = New System.Drawing.Point(16, 32)
      Me.optDay2.Name = "optDay2"
      Me.optDay2.Size = New System.Drawing.Size(376, 16)
      Me.optDay2.TabIndex = 6
      Me.optDay2.Text = "Every &weekday"
      '
      'optDay1
      '
      Me.optDay1.Location = New System.Drawing.Point(16, 8)
      Me.optDay1.Name = "optDay1"
      Me.optDay1.Size = New System.Drawing.Size(64, 16)
      Me.optDay1.TabIndex = 4
      Me.optDay1.Text = "&Every"
      '
      'optMasterMonth
      '
      Me.optMasterMonth.Location = New System.Drawing.Point(0, 56)
      Me.optMasterMonth.Name = "optMasterMonth"
      Me.optMasterMonth.Size = New System.Drawing.Size(80, 16)
      Me.optMasterMonth.TabIndex = 2
      Me.optMasterMonth.Text = "&Monthly"
      '
      'optMasterWeek
      '
      Me.optMasterWeek.Location = New System.Drawing.Point(0, 32)
      Me.optMasterWeek.Name = "optMasterWeek"
      Me.optMasterWeek.Size = New System.Drawing.Size(80, 16)
      Me.optMasterWeek.TabIndex = 1
      Me.optMasterWeek.Text = "&Weekly"
      '
      'optMasterDay
      '
      Me.optMasterDay.Location = New System.Drawing.Point(0, 8)
      Me.optMasterDay.Name = "optMasterDay"
      Me.optMasterDay.Size = New System.Drawing.Size(80, 16)
      Me.optMasterDay.TabIndex = 0
      Me.optMasterDay.Text = "&Daily"
      '
      'pnlWeek
      '
      Me.pnlWeek.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.pnlWeek.Controls.Add(Me.chkWeekday7)
      Me.pnlWeek.Controls.Add(Me.chkWeekday6)
      Me.pnlWeek.Controls.Add(Me.chkWeekday5)
      Me.pnlWeek.Controls.Add(Me.chkWeekday4)
      Me.pnlWeek.Controls.Add(Me.chkWeekday3)
      Me.pnlWeek.Controls.Add(Me.chkWeekday2)
      Me.pnlWeek.Controls.Add(Me.chkWeekday1)
      Me.pnlWeek.Controls.Add(Me.lblWeekFooter)
      Me.pnlWeek.Controls.Add(Me.udWeekInterval)
      Me.pnlWeek.Controls.Add(Me.lblWeekHeader)
      Me.pnlWeek.Location = New System.Drawing.Point(88, 72)
      Me.pnlWeek.Name = "pnlWeek"
      Me.pnlWeek.Size = New System.Drawing.Size(400, 64)
      Me.pnlWeek.TabIndex = 4
      '
      'chkWeekday7
      '
      Me.chkWeekday7.Location = New System.Drawing.Point(248, 40)
      Me.chkWeekday7.Name = "chkWeekday7"
      Me.chkWeekday7.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday7.TabIndex = 14
      Me.chkWeekday7.Text = "S"
      '
      'chkWeekday6
      '
      Me.chkWeekday6.Location = New System.Drawing.Point(216, 40)
      Me.chkWeekday6.Name = "chkWeekday6"
      Me.chkWeekday6.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday6.TabIndex = 13
      Me.chkWeekday6.Text = "F"
      '
      'chkWeekday5
      '
      Me.chkWeekday5.Location = New System.Drawing.Point(176, 40)
      Me.chkWeekday5.Name = "chkWeekday5"
      Me.chkWeekday5.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday5.TabIndex = 12
      Me.chkWeekday5.Text = "R"
      '
      'chkWeekday4
      '
      Me.chkWeekday4.Location = New System.Drawing.Point(136, 40)
      Me.chkWeekday4.Name = "chkWeekday4"
      Me.chkWeekday4.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday4.TabIndex = 1
      Me.chkWeekday4.Text = "W"
      '
      'chkWeekday3
      '
      Me.chkWeekday3.Location = New System.Drawing.Point(96, 40)
      Me.chkWeekday3.Name = "chkWeekday3"
      Me.chkWeekday3.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday3.TabIndex = 10
      Me.chkWeekday3.Text = "T"
      '
      'chkWeekday2
      '
      Me.chkWeekday2.Location = New System.Drawing.Point(56, 40)
      Me.chkWeekday2.Name = "chkWeekday2"
      Me.chkWeekday2.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday2.TabIndex = 9
      Me.chkWeekday2.Text = "M"
      '
      'chkWeekday1
      '
      Me.chkWeekday1.Location = New System.Drawing.Point(16, 40)
      Me.chkWeekday1.Name = "chkWeekday1"
      Me.chkWeekday1.Size = New System.Drawing.Size(32, 16)
      Me.chkWeekday1.TabIndex = 8
      Me.chkWeekday1.Text = "S"
      '
      'lblWeekFooter
      '
      Me.lblWeekFooter.Location = New System.Drawing.Point(176, 8)
      Me.lblWeekFooter.Name = "lblWeekFooter"
      Me.lblWeekFooter.Size = New System.Drawing.Size(216, 16)
      Me.lblWeekFooter.TabIndex = 4
      Me.lblWeekFooter.Text = "week(s) on:"
      '
      'udWeekInterval
      '
      Me.udWeekInterval.Location = New System.Drawing.Point(104, 8)
      Me.udWeekInterval.Name = "udWeekInterval"
      Me.udWeekInterval.Size = New System.Drawing.Size(56, 20)
      Me.udWeekInterval.TabIndex = 7
      '
      'lblWeekHeader
      '
      Me.lblWeekHeader.Location = New System.Drawing.Point(16, 8)
      Me.lblWeekHeader.Name = "lblWeekHeader"
      Me.lblWeekHeader.Size = New System.Drawing.Size(88, 16)
      Me.lblWeekHeader.TabIndex = 0
      Me.lblWeekHeader.Text = "Recur every"
      '
      'pnlMonth
      '
      Me.pnlMonth.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
      Me.pnlMonth.Controls.Add(Me.lblMonthFooter2)
      Me.pnlMonth.Controls.Add(Me.lblMonthMiddle2)
      Me.pnlMonth.Controls.Add(Me.udMonthInterval2)
      Me.pnlMonth.Controls.Add(Me.cboMonthDayPosition)
      Me.pnlMonth.Controls.Add(Me.cboMonthDayOrdinal)
      Me.pnlMonth.Controls.Add(Me.lblMonthFooter1)
      Me.pnlMonth.Controls.Add(Me.lblMonthMiddle1)
      Me.pnlMonth.Controls.Add(Me.udMonthInterval1)
      Me.pnlMonth.Controls.Add(Me.udMonthDayIndex)
      Me.pnlMonth.Controls.Add(Me.optMonth2)
      Me.pnlMonth.Controls.Add(Me.optMonth1)
      Me.pnlMonth.Location = New System.Drawing.Point(88, 144)
      Me.pnlMonth.Name = "pnlMonth"
      Me.pnlMonth.Size = New System.Drawing.Size(400, 56)
      Me.pnlMonth.TabIndex = 5
      '
      'lblMonthFooter2
      '
      Me.lblMonthFooter2.Location = New System.Drawing.Point(352, 32)
      Me.lblMonthFooter2.Name = "lblMonthFooter2"
      Me.lblMonthFooter2.Size = New System.Drawing.Size(56, 16)
      Me.lblMonthFooter2.TabIndex = 13
      Me.lblMonthFooter2.Text = "month(s)"
      '
      'lblMonthMiddle2
      '
      Me.lblMonthMiddle2.Location = New System.Drawing.Point(224, 32)
      Me.lblMonthMiddle2.Name = "lblMonthMiddle2"
      Me.lblMonthMiddle2.Size = New System.Drawing.Size(64, 16)
      Me.lblMonthMiddle2.TabIndex = 12
      Me.lblMonthMiddle2.Text = "of every"
      Me.lblMonthMiddle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'udMonthInterval2
      '
      Me.udMonthInterval2.Location = New System.Drawing.Point(288, 32)
      Me.udMonthInterval2.Name = "udMonthInterval2"
      Me.udMonthInterval2.Size = New System.Drawing.Size(56, 20)
      Me.udMonthInterval2.TabIndex = 21
      '
      'cboMonthDayPosition
      '
      Me.cboMonthDayPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboMonthDayPosition.Location = New System.Drawing.Point(152, 32)
      Me.cboMonthDayPosition.Name = "cboMonthDayPosition"
      Me.cboMonthDayPosition.Size = New System.Drawing.Size(72, 21)
      Me.cboMonthDayPosition.TabIndex = 20
      '
      'cboMonthDayOrdinal
      '
      Me.cboMonthDayOrdinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cboMonthDayOrdinal.Location = New System.Drawing.Point(80, 32)
      Me.cboMonthDayOrdinal.Name = "cboMonthDayOrdinal"
      Me.cboMonthDayOrdinal.Size = New System.Drawing.Size(72, 21)
      Me.cboMonthDayOrdinal.TabIndex = 19
      '
      'lblMonthFooter1
      '
      Me.lblMonthFooter1.Location = New System.Drawing.Point(296, 8)
      Me.lblMonthFooter1.Name = "lblMonthFooter1"
      Me.lblMonthFooter1.Size = New System.Drawing.Size(88, 16)
      Me.lblMonthFooter1.TabIndex = 7
      Me.lblMonthFooter1.Text = "month(s)"
      '
      'lblMonthMiddle1
      '
      Me.lblMonthMiddle1.Location = New System.Drawing.Point(144, 8)
      Me.lblMonthMiddle1.Name = "lblMonthMiddle1"
      Me.lblMonthMiddle1.Size = New System.Drawing.Size(80, 16)
      Me.lblMonthMiddle1.TabIndex = 6
      Me.lblMonthMiddle1.Text = "of every"
      Me.lblMonthMiddle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'udMonthInterval1
      '
      Me.udMonthInterval1.Location = New System.Drawing.Point(232, 8)
      Me.udMonthInterval1.Name = "udMonthInterval1"
      Me.udMonthInterval1.Size = New System.Drawing.Size(56, 20)
      Me.udMonthInterval1.TabIndex = 17
      '
      'udMonthDayIndex
      '
      Me.udMonthDayIndex.Location = New System.Drawing.Point(80, 8)
      Me.udMonthDayIndex.Name = "udMonthDayIndex"
      Me.udMonthDayIndex.Size = New System.Drawing.Size(56, 20)
      Me.udMonthDayIndex.TabIndex = 16
      '
      'optMonth2
      '
      Me.optMonth2.Location = New System.Drawing.Point(16, 32)
      Me.optMonth2.Name = "optMonth2"
      Me.optMonth2.Size = New System.Drawing.Size(64, 16)
      Me.optMonth2.TabIndex = 18
      Me.optMonth2.Text = "&The"
      '
      'optMonth1
      '
      Me.optMonth1.Location = New System.Drawing.Point(16, 8)
      Me.optMonth1.Name = "optMonth1"
      Me.optMonth1.Size = New System.Drawing.Size(64, 16)
      Me.optMonth1.TabIndex = 15
      Me.optMonth1.Text = "&Day"
      '
      'pnlBottom
      '
      Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.pnlBottom.Controls.Add(Me.dtpRangeEnd)
      Me.pnlBottom.Controls.Add(Me.lblRangeOccurFooter)
      Me.pnlBottom.Controls.Add(Me.udRangeOccurences)
      Me.pnlBottom.Controls.Add(Me.optRangeEnd3)
      Me.pnlBottom.Controls.Add(Me.optRangeEnd2)
      Me.pnlBottom.Controls.Add(Me.dtpRangeStart)
      Me.pnlBottom.Controls.Add(Me.lblRangeStart)
      Me.pnlBottom.Location = New System.Drawing.Point(8, 16)
      Me.pnlBottom.Name = "pnlBottom"
      Me.pnlBottom.Size = New System.Drawing.Size(496, 56)
      Me.pnlBottom.TabIndex = 8
      '
      'dtpRangeEnd
      '
      Me.dtpRangeEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpRangeEnd.Location = New System.Drawing.Point(312, 32)
      Me.dtpRangeEnd.Name = "dtpRangeEnd"
      Me.dtpRangeEnd.Size = New System.Drawing.Size(104, 20)
      Me.dtpRangeEnd.TabIndex = 25
      '
      'lblRangeOccurFooter
      '
      Me.lblRangeOccurFooter.Location = New System.Drawing.Point(376, 8)
      Me.lblRangeOccurFooter.Name = "lblRangeOccurFooter"
      Me.lblRangeOccurFooter.Size = New System.Drawing.Size(112, 16)
      Me.lblRangeOccurFooter.TabIndex = 7
      Me.lblRangeOccurFooter.Text = "occurences"
      '
      'udRangeOccurences
      '
      Me.udRangeOccurences.Location = New System.Drawing.Point(312, 8)
      Me.udRangeOccurences.Name = "udRangeOccurences"
      Me.udRangeOccurences.Size = New System.Drawing.Size(56, 20)
      Me.udRangeOccurences.TabIndex = 23
      '
      'optRangeEnd3
      '
      Me.optRangeEnd3.Location = New System.Drawing.Point(216, 32)
      Me.optRangeEnd3.Name = "optRangeEnd3"
      Me.optRangeEnd3.Size = New System.Drawing.Size(96, 16)
      Me.optRangeEnd3.TabIndex = 24
      Me.optRangeEnd3.Text = "End &by"
      '
      'optRangeEnd2
      '
      Me.optRangeEnd2.Location = New System.Drawing.Point(216, 8)
      Me.optRangeEnd2.Name = "optRangeEnd2"
      Me.optRangeEnd2.Size = New System.Drawing.Size(96, 16)
      Me.optRangeEnd2.TabIndex = 22
      Me.optRangeEnd2.Text = "&End after:"
      '
      'dtpRangeStart
      '
      Me.dtpRangeStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpRangeStart.Location = New System.Drawing.Point(88, 8)
      Me.dtpRangeStart.Name = "dtpRangeStart"
      Me.dtpRangeStart.Size = New System.Drawing.Size(104, 20)
      Me.dtpRangeStart.TabIndex = 21
      '
      'lblRangeStart
      '
      Me.lblRangeStart.Location = New System.Drawing.Point(0, 8)
      Me.lblRangeStart.Name = "lblRangeStart"
      Me.lblRangeStart.Size = New System.Drawing.Size(80, 16)
      Me.lblRangeStart.TabIndex = 1
      Me.lblRangeStart.Text = "Start:"
      '
      'grpHeader1
      '
      Me.grpHeader1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpHeader1.BackColor = System.Drawing.Color.Transparent
      Me.grpHeader1.Controls.Add(Me.pnlTop)
      Me.grpHeader1.Location = New System.Drawing.Point(8, 8)
      Me.grpHeader1.Name = "grpHeader1"
      Me.grpHeader1.Size = New System.Drawing.Size(520, 56)
      Me.grpHeader1.TabIndex = 9
      Me.grpHeader1.TabStop = False
      '
      'grpHeader2
      '
      Me.grpHeader2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpHeader2.BackColor = System.Drawing.Color.Transparent
      Me.grpHeader2.Controls.Add(Me.pnlMiddle)
      Me.grpHeader2.Location = New System.Drawing.Point(8, 72)
      Me.grpHeader2.Name = "grpHeader2"
      Me.grpHeader2.Size = New System.Drawing.Size(520, 304)
      Me.grpHeader2.TabIndex = 10
      Me.grpHeader2.TabStop = False
      '
      'grpHeader3
      '
      Me.grpHeader3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grpHeader3.Controls.Add(Me.pnlBottom)
      Me.grpHeader3.Location = New System.Drawing.Point(8, 376)
      Me.grpHeader3.Name = "grpHeader3"
      Me.grpHeader3.Size = New System.Drawing.Size(520, 80)
      Me.grpHeader3.TabIndex = 11
      Me.grpHeader3.TabStop = False
      '
      'AppointmentRecurrence
      '
      Me.BackColor = System.Drawing.Color.Transparent
      Me.Controls.Add(Me.grpHeader1)
      Me.Controls.Add(Me.grpHeader3)
      Me.Controls.Add(Me.grpHeader2)
      Me.Name = "AppointmentRecurrence"
      Me.Size = New System.Drawing.Size(536, 464)
      Me.pnlTop.ResumeLayout(False)
      Me.pnlMiddle.ResumeLayout(False)
      Me.pnlYear.ResumeLayout(False)
      'CType(Me.udYearDayInterval, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlDay.ResumeLayout(False)
      'CType(Me.udDayInterval, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlWeek.ResumeLayout(False)
      'CType(Me.udWeekInterval, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlMonth.ResumeLayout(False)
      'CType(Me.udMonthInterval2, System.ComponentModel.ISupportInitialize).EndInit()
      'CType(Me.udMonthInterval1, System.ComponentModel.ISupportInitialize).EndInit()
      'CType(Me.udMonthDayIndex, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlBottom.ResumeLayout(False)
      'CType(Me.udRangeOccurences, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grpHeader1.ResumeLayout(False)
      Me.grpHeader2.ResumeLayout(False)
      Me.grpHeader3.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    'Private Constants
    Private ColonSpace As String = ": "

    'Property Defaults
    Private Const m_def_ClockSetting As Schedule.ClockSettingConstants = Schedule.ClockSettingConstants.Clock12
    Private Const m_def_AllowDaily As Boolean = True
    Private Const m_def_AllowWeekly As Boolean = True
    Private Const m_def_AllowMonthly As Boolean = True
    Private Const m_def_AllowYearly As Boolean = True

    'Property Variables
    Private m_ClockSetting As Schedule.ClockSettingConstants = m_def_ClockSetting
    Private m_AllowDaily As Boolean = m_def_AllowDaily
    Private m_AllowWeekly As Boolean = m_def_AllowWeekly
    Private m_AllowMonthly As Boolean = m_def_AllowMonthly
    Private m_AllowYearly As Boolean = m_def_AllowYearly
    Private m_Appointment As Appointment
    Private m_AppointmentCollection As AppointmentCollection
    Private m_Recurrence As Recurrence
    Private m_RecurrenceDialogSettings As New Gravitybox.Objects.RecurrenceDialogSettings

    'Private Objects
    Private MonthDayOrdinalArray As New ArrayList
    Private MonthDayPositionArray As New ArrayList
    Private YearDayOrdinalArray As New ArrayList
    Private YearDayPositionArray As New ArrayList

#End Region

#Region "Property Implementations"

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
      Set(ByVal Value As Schedule.ClockSettingConstants)
        m_ClockSetting = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if daily recurrence patterns may be viewed/set.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowDaily), _
    Description("Determines if daily recurrence patterns may be viewed/set.")> _
    Public Property AllowDaily() As Boolean
      Get
        Return m_AllowDaily
      End Get
      Set(ByVal Value As Boolean)
        m_AllowDaily = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if weekly recurrence patterns may be viewed/set.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowWeekly), _
    Description("Determines if weekly recurrence patterns may be viewed/set.")> _
    Public Property AllowWeekly() As Boolean
      Get
        Return m_AllowWeekly
      End Get
      Set(ByVal Value As Boolean)
        m_AllowWeekly = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if monthly recurrence patterns may be viewed/set.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowMonthly), _
    Description("Determines if monthly recurrence patterns may be viewed/set.")> _
    Public Property AllowMonthly() As Boolean
      Get
        Return m_AllowMonthly
      End Get
      Set(ByVal Value As Boolean)
        m_AllowMonthly = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if yearly recurrence patterns may be viewed/set.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowYearly), _
    Description("Determines if yearly recurrence patterns may be viewed/set.")> _
    Public Property AllowYearly() As Boolean
      Get
        Return m_AllowYearly
      End Get
      Set(ByVal Value As Boolean)
        m_AllowYearly = Value
      End Set
    End Property

    ''' <summary>
    ''' The appointment on which this control is working.
    ''' </summary>
    <Browsable(False)> _
    Public Property Appointment() As Appointment
      Get
        Return m_Appointment
      End Get
      Set(ByVal Value As Appointment)
        m_Appointment = Value
        Call ResetTopFrame()
      End Set
    End Property

    ''' <summary>
    ''' The AppointmentCollection object from the current Schedule control.
    ''' </summary>
    <Browsable(False)> _
    Public Property AppointmentCollection() As AppointmentCollection
      Get
        Return m_AppointmentCollection
      End Get
      Set(ByVal Value As AppointmentCollection)
        m_AppointmentCollection = Value
        Call ResetTopFrame()
      End Set
    End Property

    ''' <summary>
    ''' The recurrence object on which hat this editor will be working.
    ''' </summary>
    <Browsable(False)> _
    Public Property Recurrence() As Recurrence
      Get
        Return m_Recurrence
      End Get
      Set(ByVal Value As Recurrence)
        m_Recurrence = Value
      End Set
    End Property

    ''' <summary>
    ''' The dialog settings object that provides a look-and-feel.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the texts used for captions. These should be customized for languages other than English.")> _
    Public Property RecurrenceDialogSettings() As Gravitybox.Objects.RecurrenceDialogSettings
      Get
        Return m_RecurrenceDialogSettings
      End Get
      Set(ByVal Value As Gravitybox.Objects.RecurrenceDialogSettings)
        If Value Is Nothing Then
          m_RecurrenceDialogSettings = New RecurrenceDialogSettings
        Else
          m_RecurrenceDialogSettings = Value
        End If
        Me.Refresh()
      End Set
    End Property

#End Region

#Region "UserControl Events"

    Private Sub AppointmentRecurrence_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Dim lockKey As String = PrepareforProcessing()
      Try
        pnlTop.BackColor = Color.Transparent
        pnlMiddle.BackColor = Color.Transparent
        pnlBottom.BackColor = Color.Transparent
        pnlDay.BackColor = Color.Transparent
        pnlWeek.BackColor = Color.Transparent
        pnlMonth.BackColor = Color.Transparent
        pnlYear.BackColor = Color.Transparent

        pnlWeek.Location = pnlDay.Location
        pnlMonth.Location = pnlDay.Location
        pnlYear.Location = pnlDay.Location
        pnlWeek.Visible = False
        pnlMonth.Visible = False
        pnlYear.Visible = False

        udRangeOccurences.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udRangeOccurences.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum
        udMonthInterval1.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udMonthInterval1.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum
        udMonthDayIndex.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udMonthDayIndex.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum
        udWeekInterval.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udWeekInterval.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum
        udDayInterval.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udDayInterval.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum
        udYearDayInterval.Minimum = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        udYearDayInterval.Maximum = Gravitybox.Objects.Recurrence.RecurrenceNumericMaximum

        'This will load all of the information needed for this control to function
        Call Initialize()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub AppointmentRecurrence_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

      Try
        Me.Size = New Size(grpHeader3.Location.X + grpHeader3.Size.Width + 8, grpHeader3.Location.Y + grpHeader3.Size.Height + 8)
      Catch ex As Exception
        'Do Nothing
      End Try

    End Sub

#End Region

#Region "Refresh"

    ''' <summary>
    ''' Redraw the component.
    ''' </summary>
    Public Overrides Sub Refresh()

      Dim lockKey As String = ""
      Try

        If (Me.Recurrence Is Nothing) OrElse (Me.Appointment Is Nothing) Then
          Call EnableAll(False)
          Return
        End If
        Call EnableAll(True)

        lockKey = PrepareforProcessing()

        '********************************************************
        'Set the master interval to whatever needs to be set
        Select Case Recurrence.RecurrenceInterval
          Case RecurrenceIntervalConstants.Daily
            If Me.AllowDaily Then optMasterDay.Checked = True
          Case RecurrenceIntervalConstants.Weekly
            If Me.AllowWeekly Then optMasterWeek.Checked = True
          Case RecurrenceIntervalConstants.Monthly
            If Me.AllowMonthly Then optMasterMonth.Checked = True
          Case RecurrenceIntervalConstants.Yearly
            If Me.AllowYearly Then optMasterYear.Checked = True
        End Select
        pnlDay.Visible = optMasterDay.Checked
        pnlWeek.Visible = optMasterWeek.Checked
        pnlMonth.Visible = optMasterMonth.Checked
        pnlYear.Visible = optMasterYear.Checked

        '********************************************************
        'Daliy Settings
        If Recurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval Then
          optDay1.Checked = True
        ElseIf Recurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayWeekdays Then
          optDay2.Checked = True
        End If
        udDayInterval.Value = Recurrence.RecurrenceDay.DayInterval

        '********************************************************
        'Weekly Settings
        udWeekInterval.Value = Recurrence.RecurrenceWeek.WeekInterval
        chkWeekday1.Checked = Recurrence.RecurrenceWeek.UseSun
        chkWeekday2.Checked = Recurrence.RecurrenceWeek.UseMon
        chkWeekday3.Checked = Recurrence.RecurrenceWeek.UseTue
        chkWeekday4.Checked = Recurrence.RecurrenceWeek.UseWed
        chkWeekday5.Checked = Recurrence.RecurrenceWeek.UseThu
        chkWeekday6.Checked = Recurrence.RecurrenceWeek.UseFri
        chkWeekday7.Checked = Recurrence.RecurrenceWeek.UseSat

        '********************************************************
        'Monthly Settings
        If Recurrence.RecurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Interval Then
          optMonth1.Checked = True
        ElseIf Recurrence.RecurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal Then
          optMonth2.Checked = True
        End If
        udMonthDayIndex.Value = Recurrence.RecurrenceMonth.DayInterval
        udMonthInterval1.Value = Recurrence.RecurrenceMonth.MonthInterval
        Call SetCombo(cboMonthDayOrdinal, Recurrence.RecurrenceMonth.DayOrdinal.ToString, True)
        Call SetCombo(cboMonthDayPosition, Recurrence.RecurrenceMonth.DayPosition.ToString, True)
        udMonthInterval2.Value = Recurrence.RecurrenceMonth.MonthInterval

        '********************************************************
        'Yearly Settings
        If Recurrence.RecurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Interval Then
          optYear1.Checked = True
        ElseIf Recurrence.RecurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal Then
          optYear2.Checked = True
        End If
        Call SetCombo(cboYearMonthInterval, Recurrence.RecurrenceYear.MonthInterval.ToString, True)
        udYearDayInterval.Value = Recurrence.RecurrenceYear.DayInterval
        If (1 <= Recurrence.RecurrenceYear.MonthInterval) AndAlso (Recurrence.RecurrenceYear.MonthInterval <= cboYearMonthInterval.Items.Count) Then
          cboYearMonthInterval.SelectedIndex = Recurrence.RecurrenceYear.MonthInterval - 1
        Else
          cboYearMonthInterval.SelectedIndex = 0
        End If
        Call SetCombo(cboYearDayOrdinal, Recurrence.RecurrenceYear.DayOrdinal.ToString, True)
        Call SetCombo(cboYearDayPosition, Recurrence.RecurrenceYear.DayPosition.ToString, True)
        If (1 <= Recurrence.RecurrenceYear.MonthOrdinal) AndAlso (Recurrence.RecurrenceYear.MonthOrdinal <= cboYearMonthOrdinal.Items.Count) Then
          cboYearMonthOrdinal.SelectedIndex = Recurrence.RecurrenceYear.MonthOrdinal - 1
        Else
          cboYearMonthOrdinal.SelectedIndex = 0
        End If

        '********************************************************
        'Bottom Frame Settings (Criteria)
        dtpRangeStart.Value = Recurrence.StartDate
        optRangeEnd2.Checked = (Recurrence.EndType = RecurrenceEndConstants.EndByInterval)
        optRangeEnd3.Checked = (Recurrence.EndType = RecurrenceEndConstants.EndByDate)
        If (Recurrence.EndType = RecurrenceEndConstants.EndByInterval) Then
          udRangeOccurences.Value = Recurrence.EndIterations
        Else
          udRangeOccurences.Value = Gravitybox.Objects.Recurrence.RecurrenceNumericMinimum
        End If
        dtpRangeEnd.Value = Recurrence.EndDate

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub EnableAll(ByVal value As Boolean)

      Try
        Dim control As Control
        For Each control In Me.Controls
          control.Enabled = value
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub ResetTopFrame()

      Try

        'Make sure that the objects are set and that this 
        'collection IS the parent of the appointment
        Me.Enabled = False        'Just in case
        If Appointment Is Nothing Then Return
        If AppointmentCollection Is Nothing Then Return
        If AppointmentCollection.IndexOf(Appointment) = -1 Then Return
        Me.Enabled = True       'This control is editable

        Dim ClockSettingString As String = ""
        If ClockSetting = Schedule.ClockSettingConstants.Clock12 Then
          ClockSettingString = DefaultClockSetting12Hour
        Else
          ClockSettingString = DefaultClockSetting24Hour
        End If

        If Not (Appointment Is Nothing) Then
          lblStartTimeHeader.Text = RecurrenceDialogSettings.StartTimeString.Replace("%1%", Appointment.StartTime.ToString(ClockSettingString).ToLower)
          lblEndTimeHeader.Text = RecurrenceDialogSettings.EndTimeString.Replace("%1%", DateAdd(DateInterval.Minute, Appointment.Length, Appointment.StartTime).ToString(ClockSettingString).ToLower)
          lblDurationHeader.Text = RecurrenceDialogSettings.DurationString.Replace("%1%", Appointment.Length.ToString)
          'grpHeader1.Text = AppointmentCollection.ObjectSingular

        Else
          lblStartTimeHeader.Text = RecurrenceDialogSettings.StartTimeString.Replace("%1%", RecurrenceDialogSettings.UnknownString)
          lblEndTimeHeader.Text = RecurrenceDialogSettings.EndTimeString.Replace("%1%", RecurrenceDialogSettings.UnknownString)
          lblDurationHeader.Text = RecurrenceDialogSettings.DurationString.Replace("%1%", RecurrenceDialogSettings.UnknownString)
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Initialize"

    Private Sub Initialize()

      Dim lockKey As String = PrepareforProcessing()
      Try

        'Get system names for the days (language specific)
        chkWeekday1.Text = WeekdayName(vbSunday)
        chkWeekday2.Text = WeekdayName(vbMonday)
        chkWeekday3.Text = WeekdayName(vbTuesday)
        chkWeekday4.Text = WeekdayName(vbWednesday)
        chkWeekday5.Text = WeekdayName(vbThursday)
        chkWeekday6.Text = WeekdayName(vbFriday)
        chkWeekday7.Text = WeekdayName(vbSaturday)

        'REMOVED...
        SetupCaptions()

        optMasterDay.Visible = Me.AllowDaily
        optMasterWeek.Visible = Me.AllowWeekly
        optMasterMonth.Visible = Me.AllowMonthly

        dtpRangeEnd.Value = DateAdd(DateInterval.Year, 1, dtpRangeStart.Value)

        'Top Frame
        Call ResetTopFrame()

        '********************************************************
        'Get the date format from the system and make sure that it has 4-digits
        dtpRangeStart.Format = DateTimePickerFormat.Custom
        dtpRangeEnd.Format = DateTimePickerFormat.Custom
        dtpRangeStart.CustomFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        dtpRangeEnd.CustomFormat = dtpRangeStart.CustomFormat

        PrepareforProcessing(lockKey)
        lockKey = ""

        'This will syncronize all of the child
        'controls with the Recurrence object defaults
        Call Refresh()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        PrepareforProcessing(lockKey)
      End Try

    End Sub

#End Region

#Region "SetupCaptions"

    Private Sub SetupCaptions()

      Try
        '****************************************************
        'Load the Month Ordinal combo
        Call cboMonthDayOrdinal.Items.Add("First")
        Call MonthDayOrdinalArray.Add(RecurrenceOrdinalConstants.First)
        Call cboMonthDayOrdinal.Items.Add("Second")
        Call MonthDayOrdinalArray.Add(RecurrenceOrdinalConstants.Second)
        Call cboMonthDayOrdinal.Items.Add("Third")
        Call MonthDayOrdinalArray.Add(RecurrenceOrdinalConstants.Third)
        Call cboMonthDayOrdinal.Items.Add("Fourth")
        Call MonthDayOrdinalArray.Add(RecurrenceOrdinalConstants.Fourth)
        Call cboMonthDayOrdinal.Items.Add("Last")
        Call MonthDayOrdinalArray.Add(RecurrenceOrdinalConstants.Last)

        'Now that these values are initialized reset the language if specified
        Dim sa As String() = SplitString(RecurrenceDialogSettings.MonthDayOrdinalString, "|")
        If sa.Length >= 1 Then cboMonthDayOrdinal.Items(0) = sa(0)
        If sa.Length >= 2 Then cboMonthDayOrdinal.Items(1) = sa(1)
        If sa.Length >= 3 Then cboMonthDayOrdinal.Items(2) = sa(2)
        If sa.Length >= 4 Then cboMonthDayOrdinal.Items(3) = sa(3)
        If sa.Length >= 5 Then cboMonthDayOrdinal.Items(4) = sa(4)

        '****************************************************
        'Load the Day DayChoice combo
        Call cboMonthDayPosition.Items.Add("Day")
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Day)
        Call cboMonthDayPosition.Items.Add("Weekday")
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Weekday)
        Call cboMonthDayPosition.Items.Add("WeekendDay")
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.WeekendDay)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbSunday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Sunday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbMonday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Monday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbTuesday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Tuesday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbWednesday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Wednesday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbThursday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Thursday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbFriday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Friday)
        Call cboMonthDayPosition.Items.Add(WeekdayName(vbSaturday))
        Call MonthDayPositionArray.Add(RecurrenceOrdinalDayConstants.Saturday)

        'Now that these values are initialized reset the language if specified
        sa = SplitString(RecurrenceDialogSettings.MonthDayPositionString, "|")
        If sa.Length >= 1 Then cboMonthDayPosition.Items(0) = sa(0)
        If sa.Length >= 2 Then cboMonthDayPosition.Items(1) = sa(1)
        If sa.Length >= 3 Then cboMonthDayPosition.Items(2) = sa(2)
        If sa.Length >= 4 Then cboMonthDayPosition.Items(3) = sa(3)
        If sa.Length >= 5 Then cboMonthDayPosition.Items(4) = sa(4)
        If sa.Length >= 6 Then cboMonthDayPosition.Items(5) = sa(5)
        If sa.Length >= 7 Then cboMonthDayPosition.Items(6) = sa(6)
        If sa.Length >= 8 Then cboMonthDayPosition.Items(7) = sa(7)
        If sa.Length >= 9 Then cboMonthDayPosition.Items(8) = sa(8)
        If sa.Length >= 10 Then cboMonthDayPosition.Items(9) = sa(9)

        grpHeader1.Text = RecurrenceDialogSettings.Section1String
        grpHeader2.Text = RecurrenceDialogSettings.Section2String
        grpHeader3.Text = RecurrenceDialogSettings.Section3String

        'Middle Frame
        optMasterDay.Text = RecurrenceDialogSettings.DailyString
        optMasterWeek.Text = RecurrenceDialogSettings.WeeklyString
        optMasterMonth.Text = RecurrenceDialogSettings.MonthlyString
        optMasterYear.Text = RecurrenceDialogSettings.YearlyString

        'Bottom Frame
        lblRangeStart.Text = RecurrenceDialogSettings.StartDateString.Replace("%1%", "")
        sa = SplitString(RecurrenceDialogSettings.RecurEndAfterString, "%1%")
        If sa.Length >= 1 Then optRangeEnd2.Text = sa(0)
        If sa.Length >= 2 Then lblRangeOccurFooter.Text = sa(1)
        optRangeEnd3.Text = RecurrenceDialogSettings.RecurEndByString.Replace("%1%", "")

        'Day Frame
        sa = SplitString(RecurrenceDialogSettings.EveryDayString, "%1%")
        If sa.Length >= 1 Then optDay1.Text = sa(0)
        If sa.Length >= 2 Then lblDayIntervalFooter.Text = sa(1)
        optDay2.Text = RecurrenceDialogSettings.EveryWeekDayString

        'Week Frame
        sa = SplitString(RecurrenceDialogSettings.EveryWeekString, "%1%")
        If sa.Length >= 1 Then lblWeekHeader.Text = sa(0)
        If sa.Length >= 2 Then lblWeekFooter.Text = sa(1)

        'Month Frame
        sa = SplitString(RecurrenceDialogSettings.EveryMonth1String, "%1%")
        If sa.Length >= 1 Then optMonth1.Text = sa(0)
        If sa.Length >= 2 Then
          sa = SplitString(sa(1), "%2%")
          lblMonthMiddle1.Text = sa(0)
          lblMonthFooter1.Text = sa(1)
        End If

        '****************************************************
        'Load the Year Ordinal combo
        Call cboYearDayOrdinal.Items.Add("First")
        Call YearDayOrdinalArray.Add(RecurrenceOrdinalConstants.First)
        Call cboYearDayOrdinal.Items.Add("Second")
        Call YearDayOrdinalArray.Add(RecurrenceOrdinalConstants.Second)
        Call cboYearDayOrdinal.Items.Add("Third")
        Call YearDayOrdinalArray.Add(RecurrenceOrdinalConstants.Third)
        Call cboYearDayOrdinal.Items.Add("Fourth")
        Call YearDayOrdinalArray.Add(RecurrenceOrdinalConstants.Fourth)
        Call cboYearDayOrdinal.Items.Add("Last")
        Call YearDayOrdinalArray.Add(RecurrenceOrdinalConstants.Last)

        '****************************************************
        'Load the Day DayChoice combo
        Call cboYearDayPosition.Items.Add("Day")
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Day)
        Call cboYearDayPosition.Items.Add("Weekday")
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Weekday)
        Call cboYearDayPosition.Items.Add("WeekendDay")
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.WeekendDay)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbSunday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Sunday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbMonday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Monday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbTuesday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Tuesday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbWednesday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Wednesday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbThursday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Thursday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbFriday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Friday)
        Call cboYearDayPosition.Items.Add(WeekdayName(vbSaturday))
        Call YearDayPositionArray.Add(RecurrenceOrdinalDayConstants.Saturday)

        'Setup Year-month list
        For ii As Integer = 0 To 11
          cboYearMonthInterval.Items.Add(#1/1/2005#.AddMonths(ii).ToString("MMMM"))
          cboYearMonthOrdinal.Items.Add(#1/1/2005#.AddMonths(ii).ToString("MMMM"))
        Next

        sa = SplitString(RecurrenceDialogSettings.EveryMonth2String, "%1%")
        If sa.Length >= 1 Then optMonth2.Text = sa(0)
        If sa.Length >= 2 Then
          sa = SplitString(sa(1), "%2%")
          lblMonthMiddle2.Text = sa(0)
          lblMonthFooter2.Text = sa(1)
        End If

        'Year Frame
        optYear1.Text = RecurrenceDialogSettings.EveryYear1String
        sa = SplitString(RecurrenceDialogSettings.EveryYear2String, "%1%")
        If sa.Length >= 1 Then optYear2.Text = sa(0)
        If sa.Length >= 2 Then
          lblYearMiddle1.Text = sa(1)
        End If

      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Screen Control Functionality"

    Private Sub optMasterDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasterDay.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        pnlDay.Visible = True
        pnlWeek.Visible = False
        pnlMonth.Visible = False
        pnlYear.Visible = False
        Recurrence.RecurrenceInterval = RecurrenceIntervalConstants.Daily
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optMasterWeek_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasterWeek.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        pnlDay.Visible = False
        pnlWeek.Visible = True
        pnlMonth.Visible = False
        pnlYear.Visible = False
        Recurrence.RecurrenceInterval = RecurrenceIntervalConstants.Weekly
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optMasterMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasterMonth.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        pnlDay.Visible = False
        pnlWeek.Visible = False
        pnlMonth.Visible = True
        pnlYear.Visible = False
        Recurrence.RecurrenceInterval = RecurrenceIntervalConstants.Monthly
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optMasterYear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMasterYear.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        pnlDay.Visible = False
        pnlWeek.Visible = False
        pnlMonth.Visible = False
        pnlYear.Visible = True
        Recurrence.RecurrenceInterval = RecurrenceIntervalConstants.Yearly
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub udRangeOccurences_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udRangeOccurences.ValueChanged, udRangeOccurences.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        optRangeEnd2.Checked = True
        If (udRangeOccurences.Text <> "") Then
          Dim value As Integer = GetIntlInteger(udRangeOccurences.Value)
          If (udRangeOccurences.Minimum <= value) AndAlso (value <= udRangeOccurences.Maximum) Then
            Recurrence.EndIterations = value
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub optRangeEnd2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRangeEnd2.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optRangeEnd2.Checked Then
          Recurrence.EndType = RecurrenceEndConstants.EndByInterval
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optRangeEnd3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optRangeEnd3.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optRangeEnd3.Checked Then
          Recurrence.EndType = RecurrenceEndConstants.EndByDate
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub dtpRangeEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRangeEnd.ValueChanged

      Try
        If Me.IsProcessing Then Return
        optRangeEnd3.Checked = True
        Recurrence.EndDate = GetDate(dtpRangeEnd.Value)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub udDayInterval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udDayInterval.ValueChanged, udDayInterval.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        optDay1.Checked = True
        If udDayInterval.Text <> "" Then
          Dim value As Integer = GetIntlInteger(udDayInterval.Value)
          If (udDayInterval.Minimum <= value) AndAlso (value <= udDayInterval.Maximum) Then
            Recurrence.RecurrenceDay.DayInterval = value
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub udMonthDayIndex_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udMonthDayIndex.ValueChanged, udMonthDayIndex.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        optMonth1.Checked = True
        If udMonthDayIndex.Text <> "" Then
          Dim value As Integer = GetIntlInteger(udMonthDayIndex.Value)
          If (udMonthDayIndex.Minimum <= value) AndAlso (value <= udMonthDayIndex.Maximum) Then
            Recurrence.RecurrenceMonth.DayInterval = value
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub udMonthInterval1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udMonthInterval1.ValueChanged, udMonthInterval1.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        If (udMonthInterval1.Text <> "") Then
          Dim value As Integer = GetIntlInteger(udMonthInterval1.Value)
          If (udMonthInterval1.Minimum <= value) AndAlso (value <= udMonthInterval1.Maximum) Then
            Recurrence.RecurrenceMonth.MonthInterval = value
            'Sync the two boxes
            udMonthInterval2.Value = value
          End If
        End If
        optMonth1.Checked = True
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub cboMonthDayOrdinal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonthDayOrdinal.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optMonth2.Checked = True
        Recurrence.RecurrenceMonth.DayOrdinal = CType(MonthDayOrdinalArray(cboMonthDayOrdinal.SelectedIndex), RecurrenceOrdinalConstants)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cboMonthDayPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMonthDayPosition.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optMonth2.Checked = True
        Recurrence.RecurrenceMonth.DayPosition = CType(MonthDayPositionArray(cboMonthDayPosition.SelectedIndex), RecurrenceOrdinalDayConstants)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub udMonthInterval2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udMonthInterval2.ValueChanged, udMonthInterval2.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        If (udMonthInterval2.Text <> "") Then
          Dim value As Integer = GetIntlInteger(udMonthInterval2.Value)
          If (udMonthInterval2.Minimum <= value) AndAlso (value <= udMonthInterval2.Maximum) Then
            Recurrence.RecurrenceMonth.MonthInterval = value
            'Sync the two boxes
            udMonthInterval1.Value = value
          End If
        End If
        optMonth2.Checked = True
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub optDay1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDay1.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optDay1.Checked Then
          Recurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optDay2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDay2.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optDay2.Checked Then
          Recurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayWeekdays
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optMonth1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonth1.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optMonth1.Checked Then
          Recurrence.RecurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Interval
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optMonth2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonth2.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optMonth2.Checked Then
          Recurrence.RecurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub udWeekInterval_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udWeekInterval.ValueChanged, udWeekInterval.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        If udWeekInterval.Text <> "" Then
          Dim value As Integer = GetIntlInteger(udWeekInterval.Value)
          If (udWeekInterval.Minimum <= value) AndAlso (value <= udWeekInterval.Maximum) Then
            Recurrence.RecurrenceWeek.WeekInterval = value
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub chkWeekday1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday1.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseSun = chkWeekday1.Checked
    End Sub

    Private Sub chkWeekday2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday2.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseMon = chkWeekday2.Checked
    End Sub

    Private Sub chkWeekday3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday3.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseTue = chkWeekday3.Checked
    End Sub

    Private Sub chkWeekday4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday4.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseWed = chkWeekday4.Checked
    End Sub

    Private Sub chkWeekday5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday5.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseThu = chkWeekday5.Checked
    End Sub

    Private Sub chkWeekday6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday6.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseFri = chkWeekday6.Checked
    End Sub

    Private Sub chkWeekday7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWeekday7.CheckedChanged
      If Me.IsProcessing Then Return
      Recurrence.RecurrenceWeek.UseSat = chkWeekday7.Checked
    End Sub

    Private Sub dtpRangeStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpRangeStart.ValueChanged
      If Me.IsProcessing Then Return
      Recurrence.StartDate = GetDate(dtpRangeStart.Value)
    End Sub

    Private Sub udRangeOccurences_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
     udRangeOccurences.KeyPress, udMonthInterval1.KeyPress, udMonthDayIndex.KeyPress, _
     udWeekInterval.KeyPress, udDayInterval.KeyPress

      Try
        'Only process if it is a number
        If Not (Char.IsDigit(e.KeyChar)) Then
          e.Handled = True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub UpDownControlLostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles udDayInterval.LostFocus, udMonthDayIndex.LostFocus, udMonthInterval1.LostFocus, udMonthInterval2.LostFocus, udRangeOccurences.LostFocus, udWeekInterval.LostFocus, udYearDayInterval.LostFocus
      Dim ctrl As System.Windows.Forms.NumericUpDown = CType(sender, System.Windows.Forms.NumericUpDown)
      If (ctrl.Text = "") Then
        ctrl.Text = ctrl.Value.ToString()
      End If
    End Sub

    Private Sub udYearDayInterval_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udYearDayInterval.ValueChanged, udYearDayInterval.TextChanged

      If Me.IsProcessing Then Return
      'Dim lockKey As String = PrepareforProcessing()
      Try
        optYear1.Checked = True
        If udYearDayInterval.Text <> "" Then
          Dim value As Integer = GetIntlInteger(udYearDayInterval.Value)
          If (udYearDayInterval.Minimum <= value) AndAlso (value <= udYearDayInterval.Maximum) Then
            Recurrence.RecurrenceYear.DayInterval = value
          End If
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'PrepareforProcessing(lockKey)
      End Try

    End Sub

    Private Sub cboYearDayOrdinal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYearDayOrdinal.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optYear2.Checked = True
        Recurrence.RecurrenceYear.DayOrdinal = CType(YearDayOrdinalArray(cboYearDayOrdinal.SelectedIndex), RecurrenceOrdinalConstants)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cboYearDayPosition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYearDayPosition.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optYear2.Checked = True
        Recurrence.RecurrenceYear.DayPosition = CType(YearDayPositionArray(cboYearDayPosition.SelectedIndex), RecurrenceOrdinalDayConstants)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cboYearMonthInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYearMonthInterval.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optYear1.Checked = True
        Recurrence.RecurrenceYear.MonthInterval = cboYearMonthInterval.SelectedIndex + 1
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub cboYearMonthOrdinal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYearMonthOrdinal.SelectedIndexChanged

      Try
        If Me.IsProcessing Then Return
        optYear2.Checked = True
        Recurrence.RecurrenceYear.MonthOrdinal = cboYearMonthOrdinal.SelectedIndex + 1
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optYear1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optYear1.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optYear1.Checked Then
          Recurrence.RecurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Interval
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub optYear2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optYear2.CheckedChanged

      Try
        If Me.IsProcessing Then Return
        If optYear2.Checked Then
          Recurrence.RecurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Processing"

    Private ProcessingKeyList As New ArrayList
    Private Function PrepareforProcessing() As String
      Try
        Dim key As String = Guid.NewGuid.ToString
        ProcessingKeyList.Add(key)
        Return key
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Private Sub PrepareforProcessing(ByVal key As String)
      If key = "" Then Return
      Try
        If ProcessingKeyList.Contains(key) Then
          ProcessingKeyList.Remove(key)
        Else
          Throw New Exception("The lock key does not exist!")
        End If
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Function IsProcessing() As Boolean
      Return (ProcessingKeyList.Count > 0)
    End Function

#End Region

  End Class

End Namespace