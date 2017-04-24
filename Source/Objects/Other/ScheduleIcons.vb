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

Imports Gravitybox.Controls.Schedule
Imports System.ComponentModel

Namespace Gravitybox.Objects

  Public Class ScheduleIcons

#Region "Class Members"

    'Property Variables
    Private m_IconDelete As Icon
    Private m_IconFile As Icon
    Private m_IconFlag As Icon
    Private m_IconReminder As Icon
    Private m_IconRecurrence As Icon
    Private m_IconRecurrenceBroken As Icon
    Private m_IconInfo As Icon
    Private m_IconPrevious As Icon
    Private m_IconNext As Icon
    Private m_IconSave As Icon

#End Region

#Region "Constructor"

    'Constructor
    Friend Sub New(ByVal MainSchedule As Gravitybox.Controls.Schedule)

      Dim defaultIcons As New DefaultIcons(MainSchedule)

      'Default the icons
      m_IconDelete = defaultIcons.IconDelete
      m_IconFile = defaultIcons.IconFile
      m_IconFlag = defaultIcons.IconFlag
      m_IconReminder = defaultIcons.IconReminder
      m_IconRecurrence = defaultIcons.IconRecurrence
      m_IconRecurrenceBroken = defaultIcons.IconRecurrenceBroken
      m_IconInfo = defaultIcons.IconInfo
      m_IconPrevious = defaultIcons.IconPrevious
      m_IconNext = defaultIcons.IconNext
      m_IconSave = defaultIcons.IconSave

    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' This is the icon that is used to display delete functionality.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display delete functionality.")> _
    Public Property IconDelete() As Icon
      Get
        Return m_IconDelete
      End Get
      Set(ByVal Value As Icon)
        m_IconDelete = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display a flag visualization on an appointment. This icon is only drawn if the associated appointment's IsFlagged property is set to true.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display a flag visualization on an appointment. This icon is only drawn if the associated appointment's IsFlagged property is set to true.")> _
    Public Property IconFlag() As Icon
      Get
        Return m_IconFlag
      End Get
      Set(ByVal Value As Icon)
        m_IconFlag = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display file objects.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display file objects.")> _
    Public Property IconFile() As Icon
      Get
        Return m_IconFile
      End Get
      Set(ByVal Value As Icon)
        m_IconFile = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display a reminder visualization on an appointment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display a reminder visualization on an appointment.")> _
    Public Property IconReminder() As Icon
      Get
        Return m_IconReminder
      End Get
      Set(ByVal Value As Icon)
        m_IconReminder = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display a recurrence visualization on an appointment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display a recurrence visualization on an appointment.")> _
    Public Property IconRecurrence() As Icon
      Get
        Return m_IconRecurrence
      End Get
      Set(ByVal Value As Icon)
        m_IconRecurrence = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display a visualization notifying the user that an appointment is not fully displayed. An appointment might cover an area so large that it is not displayed fully in the view port. An icon is painted on the appointment to signify to the user that the appointment extends outside of the visual bounds.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display a visualization notifying the user that an appointment is not fully displayed. An appointment might cover an area so large that it is not displayed fully in the view port. An icon is painted on the appointment to signify to the user that the appointment extends outside of the visual bounds.")> _
    Public Property IconRecurrenceBroken() As Icon
      Get
        Return m_IconRecurrenceBroken
      End Get
      Set(ByVal Value As Icon)
        m_IconRecurrenceBroken = Value
      End Set
    End Property

    ''' <summary>
    ''' Custom Icon.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Custom Icon.")> _
    Public Property IconInfo() As Icon
      Get
        Return m_IconInfo
      End Get
      Set(ByVal Value As Icon)
        m_IconInfo = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon used on the 'previous' button of the ScheduleProperties control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon used on the 'previous' button of the ScheduleProperties control.")> _
    Public Property IconPrevious() As Icon
      Get
        Return m_IconPrevious
      End Get
      Set(ByVal Value As Icon)
        m_IconPrevious = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon used on the 'next' button of the ScheduleProperties control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon used on the 'next' button of the ScheduleProperties control.")> _
    Public Property IconNext() As Icon
      Get
        Return m_IconNext
      End Get
      Set(ByVal Value As Icon)
        m_IconNext = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the icon that is used to display save functionality.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("This is the icon that is used to display save functionality.")> _
    Public Property IconSave() As Icon
      Get
        Return m_IconSave
      End Get
      Set(ByVal Value As Icon)
        m_IconSave = Value
      End Set
    End Property

#End Region

  End Class

End Namespace