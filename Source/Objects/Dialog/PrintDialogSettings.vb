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

Imports System.ComponentModel

Namespace Gravitybox.Objects

  Public Class PrintDialogSettings
    Inherits DialogSettingsBase

    Public Enum PrintPositionConstants
      None = 0
      LeftTop = 1
      LeftBottom = 2
      RightTop = 3
      RightBottom = 4
    End Enum

#Region "Class Members"

    'Property Constants
		Protected Shadows ReadOnly m_def_WindowText As String = "Preview"
		Protected Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.Sizable
		Protected Shadows ReadOnly m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.CenterScreen
		Protected Const m_def_PageLabelText As String = "Page"
		Protected Const m_def_PrintToolTip As String = "Print"
		Protected Const m_def_ZoomToolTip As String = "Zoom"
		Protected Const m_def_OnePageToolTip As String = "One Page"
		Protected Const m_def_TwoPagesToolTip As String = "Two Pages"
		Protected Const m_def_ThreePagesToolTip As String = "Three Pages"
		Protected Const m_def_FourPagesToolTip As String = "Four Pages"
		Protected Const m_def_SixPagesToolTip As String = "Six Pages"
		Protected Const m_def_PageHeader As String = "Page "
		Protected Const m_def_StartDate As DateTime = #1/1/2004#
		Protected Const m_def_EndDate As DateTime = #1/1/2004#
		Protected Const m_def_StartTime As DateTime = #8:00:00 AM#
		Protected Const m_def_EndTime As DateTime = #6:00:00 PM#
		Protected Const m_def_PageNumberPosition As PrintPositionConstants = PrintPositionConstants.RightTop
		Protected Const m_def_WindowState As System.Windows.Forms.FormWindowState = FormWindowState.Normal
		Protected Const m_def_Zoom As Integer = 100

		'Property Variables
		Protected m_StartDate As DateTime = m_def_StartDate
		Protected m_EndDate As DateTime = m_def_EndDate
		Protected m_StartTime As DateTime = m_def_StartTime
		Protected m_EndTime As DateTime = m_def_EndTime
		Protected m_PageSettings As New System.Drawing.Printing.PageSettings
		Protected m_PageNumberPosition As PrintPositionConstants = m_def_PageNumberPosition
		Protected m_PageLabelText As String = m_def_PageLabelText
		Protected m_PrintToolTip As String = m_def_PrintToolTip
		Protected m_ZoomToolTip As String = m_def_ZoomToolTip
		Protected m_OnePageToolTip As String = m_def_OnePageToolTip
		Protected m_TwoPagesToolTip As String = m_def_TwoPagesToolTip
		Protected m_ThreePagesToolTip As String = m_def_ThreePagesToolTip
		Protected m_FourPagesToolTip As String = m_def_FourPagesToolTip
		Protected m_SixPagesToolTip As String = m_def_SixPagesToolTip
		Protected m_HeaderText As String = ""
		Protected m_FooterText As String = ""
		Protected m_PageStartNumber As Integer = 1
		Protected m_PageHeader As String = m_def_PageHeader
		Protected m_HeaderAppearance As New Gravitybox.Objects.Appearance
		Protected m_FooterAppearance As New Gravitybox.Objects.Appearance
		Protected m_PageNumberAppearance As New Gravitybox.Objects.Appearance
		Protected m_WindowState As System.Windows.Forms.FormWindowState = m_def_WindowState
		Protected m_Zoom As Integer = m_def_Zoom

#End Region

#Region "Constructors"

		'Date/Time
		Public Sub New(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal endDate As DateTime, ByVal endTime As DateTime)

			MyBase.New()
			MyBase.OkButtonText = m_def_OkButtonText
			MyBase.CancelButtonText = m_def_CancelButtonText
			MyBase.WindowText = m_def_WindowText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			MyBase.StartPosition = m_def_StartPosition
			MyBase.Location = m_def_Location
			MyBase.Size = m_def_Size
			Me.StartDate = startDate
			Me.EndDate = endDate
			Me.StartTime = GetTime(startTime)
			Me.EndTime = GetTime(endTime)
			Me.Icon = New Icon(GetProjectFileAsStream("print.ico"))

			m_PageNumberAppearance.StringFormatFlags = StringFormatFlags.MeasureTrailingSpaces
			m_PageNumberAppearance.StringFormatFlags = StringFormatFlags.NoWrap
			m_PageNumberAppearance.TextTrimming = StringTrimming.Character

		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the first date to print.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    Description("Determines the first date to print.")> _
    Public Property StartDate() As DateTime
      Get
        Return m_StartDate
      End Get
      Set(ByVal Value As DateTime)
        m_StartDate = Value
        If m_EndDate < m_StartDate Then m_EndDate = m_StartDate
      End Set
    End Property

    ''' <summary>
    ''' Determines the last date to print.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    Description("Determines the last date to print.")> _
    Public Property EndDate() As DateTime
      Get
        Return m_EndDate
      End Get
      Set(ByVal Value As DateTime)
        m_EndDate = Value
        If m_EndDate < m_StartDate Then m_StartDate = m_EndDate
      End Set
    End Property

    ''' <summary>
    ''' Determines the first time to print.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("Determines the first time to print.")> _
    Public Property StartTime() As DateTime
      Get
        Return m_StartTime
      End Get
      Set(ByVal Value As DateTime)
        Value = TimeSerial(Value.Hour, 0, 0)
        m_StartTime = GetTime(Value)
        If m_EndTime < m_StartTime Then m_EndTime = m_StartTime
      End Set
    End Property

    ''' <summary>
    ''' Determines the last time to print.
    ''' </summary>
    <Browsable(True), _
    Category("Data"), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("Determines the last time to print.")> _
    Public Property EndTime() As DateTime
      Get
        Return m_EndTime
      End Get
      Set(ByVal Value As DateTime)

        Dim nextDay As Date = PivotTime.AddDays(1)
        Value = New DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, 0, 0)

        'It must be 12 the next day since daylength cannot be 0 hours
        If DateMatch(Value, PivotTime) OrElse (Value >= nextDay) Then
          Value = nextDay
        Else
          If Value >= nextDay Then Value = nextDay
          If DateMatch(Value, nextDay) Then Value = nextDay
          If Value = nextDay Then
            m_EndDate = Value
          Else
            Value = GetTime(TimeSerial(Value.Hour, 0, 0))
          End If
        End If
        m_EndTime = Value
        If m_EndTime < m_StartTime Then m_StartTime = m_EndTime

      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the page label in the preview dialog.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Page"), _
    Description("Determines the text of the page label in the preview dialog.")> _
    Public Property PageLabelText() As String
      Get
        Return m_PageLabelText
      End Get
      Set(ByVal Value As String)
        m_PageLabelText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the position of the page numbers.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(PrintPositionConstants), "RightTop"), _
    Description("Determines the position of the page numbers.")> _
    Public Property PageNumberPosition() As PrintPositionConstants
      Get
        Return m_PageNumberPosition
      End Get
      Set(ByVal Value As PrintPositionConstants)
        m_PageNumberPosition = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog print button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_PrintToolTip), _
    Description("Determines the text of the preview dialog print button.")> _
    Public Property PrintToolTip() As String
      Get
        Return m_PrintToolTip
      End Get
      Set(ByVal Value As String)
        m_PrintToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog zoom button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_ZoomToolTip), _
    Description("Determines the text of the preview dialog zoom button.")> _
    Public Property ZoomToolTip() As String
      Get
        Return m_ZoomToolTip
      End Get
      Set(ByVal Value As String)
        m_ZoomToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog one-page button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_OnePageToolTip), _
    Description("Determines the text of the preview dialog one-page button.")> _
    Public Property OnePageToolTip() As String
      Get
        Return m_OnePageToolTip
      End Get
      Set(ByVal Value As String)
        m_OnePageToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog two-page button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_TwoPagesToolTip), _
    Description("Determines the text of the preview dialog two-page button.")> _
    Public Property TwoPagesToolTip() As String
      Get
        Return m_TwoPagesToolTip
      End Get
      Set(ByVal Value As String)
        m_TwoPagesToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog three-page button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_ThreePagesToolTip), _
    Description("Determines the text of the preview dialog three-page button.")> _
    Public Property ThreePagesToolTip() As String
      Get
        Return m_ThreePagesToolTip
      End Get
      Set(ByVal Value As String)
        m_ThreePagesToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog four-page button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_FourPagesToolTip), _
    Description("Determines the text of the preview dialog four-page button.")> _
    Public Property FourPagesToolTip() As String
      Get
        Return m_FourPagesToolTip
      End Get
      Set(ByVal Value As String)
        m_FourPagesToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the preview dialog six-page button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_SixPagesToolTip), _
    Description("Determines the text of the preview dialog six-page button.")> _
    Public Property SixPagesToolTip() As String
      Get
        Return m_SixPagesToolTip
      End Get
      Set(ByVal Value As String)
        m_SixPagesToolTip = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the header text.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the header text.")> _
    Public Property HeaderText() As String
      Get
        Return m_HeaderText
      End Get
      Set(ByVal Value As String)
        m_HeaderText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the footer text.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the footer text.")> _
    Public Property FooterText() As String
      Get
        Return m_FooterText
      End Get
      Set(ByVal Value As String)
        m_FooterText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the starting page number.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(1), _
    Description("Determines the starting page number.")> _
    Public Property PageStartNumber() As Integer
      Get
        Return m_PageStartNumber
      End Get
      Set(ByVal Value As Integer)
        m_PageStartNumber = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text to prepend the page number.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_PageHeader), _
    Description("Determines the text to prepend the page number.")> _
    Public Property PageHeader() As String
      Get
        Return m_PageHeader
      End Get
      Set(ByVal Value As String)
        m_PageHeader = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the header.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the appearance of the header.")> _
    Public Property HeaderAppearance() As Gravitybox.Objects.Appearance
      Get
        Return m_HeaderAppearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        m_HeaderAppearance = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the footer.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the appearance of the footer.")> _
    Public Property FooterAppearance() As Gravitybox.Objects.Appearance
      Get
        Return m_FooterAppearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        m_FooterAppearance = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the page numbering.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the appearance of the page numbering.")> _
    Public Property PageNumberAppearance() As Gravitybox.Objects.Appearance
      Get
        Return m_PageNumberAppearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        m_PageNumberAppearance = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the page layout.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines if the page layout.")> _
    Public Property PageSettings() As System.Drawing.Printing.PageSettings
      Get
        Return m_PageSettings
      End Get
      Set(ByVal Value As System.Drawing.Printing.PageSettings)
        m_PageSettings = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the state of the preview window.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the state of the preview window.")> _
    Public Property WindowState() As System.Windows.Forms.FormWindowState
      Get
        Return m_WindowState
      End Get
      Set(ByVal Value As System.Windows.Forms.FormWindowState)
        m_WindowState = Value
      End Set
    End Property

    <Browsable(False)> _
    Friend ReadOnly Property DayLength() As Integer
      Get
        Return GetIntlInteger(DateDiff(DateInterval.Hour, GetTime(Me.StartTime), Me.EndTime))
      End Get
    End Property

    ''' <summary>
    ''' Determines the zoom level of the preview window.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the zoom level of the preview window.")> _
    Public Property Zoom() As Integer
      Get
        Return m_Zoom
      End Get
      Set(ByVal Value As Integer)
        If Value < 1 Then Value = 1
        If Value > 1000 Then Value = 1000
        m_Zoom = Value
      End Set
    End Property

#End Region

	End Class

End Namespace