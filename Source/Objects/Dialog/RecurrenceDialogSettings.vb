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

  <TypeConverter(GetType(Gravitybox.Design.Converters.RecurrenceDialogSettingsConverter))> _
  Public Class RecurrenceDialogSettings
    Inherits DialogSettingsBase

#Region "Class Members"

    'Private Constants
		Protected Const m_def_StartTimeString As String = "Start Time: %1%"
		Protected Const m_def_EndTimeString As String = "End Time: %1%"
		Protected Const m_def_DurationString As String = "Duration: %1% minutes"
		Protected Const m_def_DailyString As String = "&Daily"
		Protected Const m_def_WeeklyString As String = "&Weekly"
    Protected Const m_def_MonthlyString As String = "&Monthly"
    Protected Const m_def_YearlyString As String = "&Yearly"
		Protected Const m_def_EveryDayString As String = "Every %1% day(s)"
		Protected Const m_def_EveryWeekDayString As String = "Every weekday"
		Protected Const m_def_EveryWeekString As String = "Recur every %1% weeks on"
		Protected Const m_def_EveryMonth1String As String = "Day %1% of every %2% month(s)"
		Protected Const m_def_EveryMonth2String As String = "The %1% of every %2% month(s)"
		Protected Const m_def_StartDateString As String = "Start:"
		Protected Const m_def_RecurEndAfterString As String = "End after %1% occurrences"
		Protected Const m_def_RecurEndByString As String = "End by %1%"
		Protected Const m_def_Section1String As String = "Appointment"
		Protected Const m_def_Section2String As String = "Recurrence Pattern"
		Protected Const m_def_Section3String As String = "Range of Recurrence"
		Protected Const m_def_UnknownString As String = "Unknown"
		Protected Const m_def_MonthDayOrdinalString As String = "First|Second|Third|Fourth|Last"
		Protected Const m_def_MonthDayPositionString As String = "Day|Weekday|WeekendDay|Sunday|Monday|Tuesday|Wednesday|Thursday|Friday|Saturday"
		Protected Const m_def_ErrorStringInvalidRecurrence As String = "This is not a valid recurrence pattern!"
		Protected Shadows ReadOnly m_def_WindowText As String = "Appointment Recurrence"
		Protected Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.FixedDialog
		Protected Const m_def_EveryYear1String As String = "&Every"
		Protected Const m_def_EveryYear2String As String = "The %1% of"

    'Property Variables
		Protected m_StartTimeString As String = m_def_StartTimeString
		Protected m_EndTimeString As String = m_def_EndTimeString
		Protected m_DurationString As String = m_def_DurationString
		Protected m_DailyString As String = m_def_DailyString
		Protected m_WeeklyString As String = m_def_WeeklyString
    Protected m_MonthlyString As String = m_def_MonthlyString
    Protected m_YearlyString As String = m_def_YearlyString
		Protected m_EveryDayString As String = m_def_EveryDayString
		Protected m_EveryWeekDayString As String = m_def_EveryWeekDayString
		Protected m_EveryWeekString As String = m_def_EveryWeekString
		Protected m_EveryMonth1String As String = m_def_EveryMonth1String
		Protected m_EveryMonth2String As String = m_def_EveryMonth2String
		Protected m_StartDateString As String = m_def_StartDateString
		Protected m_RecurEndAfterString As String = m_def_RecurEndAfterString
		Protected m_RecurEndByString As String = m_def_RecurEndByString
		Protected m_Section1String As String = m_def_Section1String
		Protected m_Section2String As String = m_def_Section2String
		Protected m_Section3String As String = m_def_Section3String
		Protected m_UnknownString As String = m_def_UnknownString
		Protected m_MonthDayOrdinalString As String = m_def_MonthDayOrdinalString
		Protected m_MonthDayPositionString As String = m_def_MonthDayPositionString
		Protected m_ErrorStringInvalidRecurrence As String = m_def_ErrorStringInvalidRecurrence
		Protected m_EveryYear1String As String = m_def_EveryYear1String
		Protected m_EveryYear2String As String = m_def_EveryYear2String

#End Region

#Region "Constructor"

    'Constructor
		Public Sub New()
			MyBase.New()
			MyBase.WindowText = m_def_WindowText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Text for 'Start time'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Start time'"), _
    DefaultValue(m_def_StartTimeString)> _
    Public Property StartTimeString() As String
      Get
        Return m_StartTimeString
      End Get
      Set(ByVal Value As String)
        m_StartTimeString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'End time'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'End time'"), _
    DefaultValue(m_def_EndTimeString)> _
    Public Property EndTimeString() As String
      Get
        Return m_EndTimeString
      End Get
      Set(ByVal Value As String)
        m_EndTimeString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Duration'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Duration'"), _
    DefaultValue(m_def_DurationString)> _
    Public Property DurationString() As String
      Get
        Return m_DurationString
      End Get
      Set(ByVal Value As String)
        m_DurationString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Daily'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Daily'"), _
    DefaultValue(m_def_DailyString)> _
    Public Property DailyString() As String
      Get
        Return m_DailyString
      End Get
      Set(ByVal Value As String)
        m_DailyString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Weekly'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Weekly'"), _
    DefaultValue(m_def_WeeklyString)> _
    Public Property WeeklyString() As String
      Get
        Return m_WeeklyString
      End Get
      Set(ByVal Value As String)
        m_WeeklyString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Monthly'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Monthly'"), _
    DefaultValue(m_def_MonthlyString)> _
    Public Property MonthlyString() As String
      Get
        Return m_MonthlyString
      End Get
      Set(ByVal Value As String)
        m_MonthlyString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Yearly'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Yearly'"), _
    DefaultValue(m_def_YearlyString)> _
    Public Property YearlyString() As String
      Get
        Return m_YearlyString
      End Get
      Set(ByVal Value As String)
        m_YearlyString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Every day'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Every day'"), _
    DefaultValue(m_def_EveryDayString)> _
    Public Property EveryDayString() As String
      Get
        Return m_EveryDayString
      End Get
      Set(ByVal Value As String)
        m_EveryDayString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Every weekday'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Every weekday'"), _
    DefaultValue(m_def_EveryWeekDayString)> _
    Public Property EveryWeekDayString() As String
      Get
        Return m_EveryWeekDayString
      End Get
      Set(ByVal Value As String)
        m_EveryWeekDayString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Every week'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Every week'"), _
    DefaultValue(m_def_EveryWeekString)> _
    Public Property EveryWeekString() As String
      Get
        Return m_EveryWeekString
      End Get
      Set(ByVal Value As String)
        m_EveryWeekString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for month prompt 1 on the recurrence UserControl
    ''' </summary>
    <Browsable(True), _
    Description("Text for month prompt 1 on the recurrence UserControl"), _
    DefaultValue(m_def_EveryMonth1String)> _
    Public Property EveryMonth1String() As String
      Get
        Return m_EveryMonth1String
      End Get
      Set(ByVal Value As String)
        m_EveryMonth1String = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for month prompt 2 on the recurrence UserControl
    ''' </summary>
    <Browsable(True), _
    Description("Text for month prompt 2 on the recurrence UserControl"), _
    DefaultValue(m_def_EveryMonth2String)> _
    Public Property EveryMonth2String() As String
      Get
        Return m_EveryMonth2String
      End Get
      Set(ByVal Value As String)
        m_EveryMonth2String = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Start date'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Start date'"), _
    DefaultValue(m_def_StartDateString)> _
    Public Property StartDateString() As String
      Get
        Return m_StartDateString
      End Get
      Set(ByVal Value As String)
        m_StartDateString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for recurrence end label
    ''' </summary>
    <Browsable(True), _
    Description("Text for recurrence end label"), _
    DefaultValue(m_def_RecurEndAfterString)> _
    Public Property RecurEndAfterString() As String
      Get
        Return m_RecurEndAfterString
      End Get
      Set(ByVal Value As String)
        m_RecurEndAfterString = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for recurrence end label
    ''' </summary>
    <Browsable(True), _
    Description("Text for recurrence end label"), _
    DefaultValue(m_def_RecurEndByString)> _
    Public Property RecurEndByString() As String
      Get
        Return m_RecurEndByString
      End Get
      Set(ByVal Value As String)
        m_RecurEndByString = Value
      End Set
    End Property

    ''' <summary>
    ''' Section 1 text for recurrence UserControl
    ''' </summary>
    <Browsable(True), _
    Description("Section 1 text for recurrence UserControl"), _
    DefaultValue(m_def_Section1String)> _
    Public Property Section1String() As String
      Get
        Return m_Section1String
      End Get
      Set(ByVal Value As String)
        m_Section1String = Value
      End Set
    End Property

    ''' <summary>
    ''' Section 2 text for recurrence UserControl
    ''' </summary>
    <Browsable(True), _
    Description("Section 2 text for recurrence UserControl"), _
    DefaultValue(m_def_Section2String)> _
    Public Property Section2String() As String
      Get
        Return m_Section2String
      End Get
      Set(ByVal Value As String)
        m_Section2String = Value
      End Set
    End Property

    ''' <summary>
    ''' Section 3 text for recurrence UserControl
    ''' </summary>
    <Browsable(True), _
    Description("Section 3 text for recurrence UserControl"), _
    DefaultValue(m_def_Section3String)> _
    Public Property Section3String() As String
      Get
        Return m_Section3String
      End Get
      Set(ByVal Value As String)
        m_Section3String = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for 'Unknown'
    ''' </summary>
    <Browsable(True), _
    Description("Text for 'Unknown'"), _
    DefaultValue(m_def_UnknownString)> _
    Public Property UnknownString() As String
      Get
        Return m_UnknownString
      End Get
      Set(ByVal Value As String)
        m_UnknownString = Value
      End Set
    End Property

    ''' <summary>
    ''' Pipe delimited list for day ordinals in the recurrence UserControl: first, second, etc.
    ''' </summary>
    <Browsable(True), _
    Description("Pipe delimited list for day ordinals in the recurrence UserControl: first, second, etc."), _
    DefaultValue(m_def_MonthDayOrdinalString)> _
    Public Property MonthDayOrdinalString() As String
      Get
        Return m_MonthDayOrdinalString
      End Get
      Set(ByVal Value As String)
        m_MonthDayOrdinalString = Value
      End Set
    End Property

    ''' <summary>
    ''' Pipe delimited list for day position in the recurrence UserControl:Monday, Tuesday, etc.
    ''' </summary>
    <Browsable(True), _
    Description("Pipe delimited list for day position in the recurrence UserControl:Monday, Tuesday, etc."), _
    DefaultValue(m_def_MonthDayPositionString)> _
    Public Property MonthDayPositionString() As String
      Get
        Return m_MonthDayPositionString
      End Get
      Set(ByVal Value As String)
        m_MonthDayPositionString = Value
      End Set
    End Property

    ''' <summary>
    ''' Error message for the invalid recurrence patterns.
    ''' </summary>
    <Browsable(True), _
    Description("Error message for the invalid recurrence patterns."), _
    DefaultValue(m_def_ErrorStringInvalidRecurrence)> _
    Public Property ErrorStringInvalidRecurrence() As String
      Get
        Return m_ErrorStringInvalidRecurrence
      End Get
      Set(ByVal Value As String)
        m_ErrorStringInvalidRecurrence = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for the year 2 recurrence prompt
    ''' </summary>
    <Browsable(True), _
    Description("Text for the year 2 recurrence prompt"), _
    DefaultValue(m_def_EveryYear1String)> _
    Public Property EveryYear1String() As String
      Get
        Return m_EveryYear1String
      End Get
      Set(ByVal Value As String)
        m_EveryYear1String = Value
      End Set
    End Property

    ''' <summary>
    ''' Text for the year 2 recurrence prompt
    ''' </summary>
    <Browsable(True), _
    Description("Text for the year 2 recurrence prompt"), _
    DefaultValue(m_def_EveryYear2String)> _
    Public Property EveryYear2String() As String
      Get
        Return m_EveryYear2String
      End Get
      Set(ByVal Value As String)
        m_EveryYear2String = Value
      End Set
    End Property

#End Region

  End Class

End Namespace