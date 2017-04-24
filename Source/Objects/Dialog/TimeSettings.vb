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

  Public Class TimeSettings

#Region "Class Members"

    'Private Constants
    Private Const m_def_MinuteTextSingular As String = "minute"
    Private Const m_def_MinuteTextPlural As String = "minutes"
    Private Const m_def_HourTextSingular As String = "hour"
    Private Const m_def_HourTextPlural As String = "hours"
    Private Const m_def_DayTextSingular As String = "day"
		Private Const m_def_DayTextPlural As String = "days"
		Private Const m_def_TimeIncrement As Gravitybox.Controls.Schedule.TimeIncrementConstants = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
		Private Const m_def_ClockSetting As Gravitybox.Controls.Schedule.ClockSettingConstants = Gravitybox.Controls.Schedule.ClockSettingConstants.Clock12

    'Property Variables
    Private m_MinuteTextSingular As String = m_def_MinuteTextSingular
    Private m_MinuteTextPlural As String = m_def_MinuteTextPlural
    Private m_HourTextSingular As String = m_def_HourTextSingular
    Private m_HourTextPlural As String = m_def_HourTextPlural
    Private m_DayTextSingular As String = m_def_DayTextSingular
		Private m_DayTextPlural As String = m_def_DayTextPlural
		Private m_TimeIncrement As Gravitybox.Controls.Schedule.TimeIncrementConstants = m_def_TimeIncrement
		Private m_ClockSetting As Gravitybox.Controls.Schedule.ClockSettingConstants = m_def_ClockSetting

#End Region

#Region "Constructor"

    Public Sub New()
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines displayed time increment. This is the number of minutes that correspond to minute resolution.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Gravitybox.Controls.Schedule.TimeIncrementConstants), "Minute30"), _
    Description("Determines displayed time increment. This is the number of minutes that correspond to minute resolution.")> _
    Public Property TimeIncrement() As Gravitybox.Controls.Schedule.TimeIncrementConstants
      Get
        Return m_TimeIncrement
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.TimeIncrementConstants)
        m_TimeIncrement = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines whether times are displayed using the 12 or 24 hour clock.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Gravitybox.Controls.Schedule.ClockSettingConstants), "Clock12"), _
    Description("Determines whether times are displayed using the 12 or 24 hour clock.")> _
    Public Property ClockSetting() As Gravitybox.Controls.Schedule.ClockSettingConstants
      Get
        Return m_ClockSetting
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule.ClockSettingConstants)
        m_ClockSetting = Value
      End Set
    End Property

    ''' <summary>
    ''' The singular text for 'Minute'.
    ''' </summary>
    Public Property MinuteTextSingular() As String
      Get
        Return m_MinuteTextSingular
      End Get
      Set(ByVal Value As String)
        m_MinuteTextSingular = Value
      End Set
    End Property

    ''' <summary>
    ''' The plural text for 'Minutes'.
    ''' </summary>
    Public Property MinuteTextPlural() As String
      Get
        Return m_MinuteTextPlural
      End Get
      Set(ByVal Value As String)
        m_MinuteTextPlural = Value
      End Set
    End Property

    ''' <summary>
    ''' The singular text for 'Hour'.
    ''' </summary>
    Public Property HourTextSingular() As String
      Get
        Return m_HourTextSingular
      End Get
      Set(ByVal Value As String)
        m_HourTextSingular = Value
      End Set
    End Property

    ''' <summary>
    ''' The plural text for 'Hours'.
    ''' </summary>
    Public Property HourTextPlural() As String
      Get
        Return m_HourTextPlural
      End Get
      Set(ByVal Value As String)
        m_HourTextPlural = Value
      End Set
    End Property

    ''' <summary>
    ''' The singular text for 'day'.
    ''' </summary>
    Public Property DayTextSingular() As String
      Get
        Return m_DayTextSingular
      End Get
      Set(ByVal Value As String)
        m_DayTextSingular = Value
      End Set
    End Property

    ''' <summary>
    ''' The plural text for 'Days'.
    ''' </summary>
    Public Property DayTextPlural() As String
      Get
        Return m_DayTextPlural
      End Get
      Set(ByVal Value As String)
        m_DayTextPlural = Value
      End Set
    End Property

#End Region

  End Class

End Namespace