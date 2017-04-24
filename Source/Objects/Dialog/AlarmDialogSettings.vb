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

	'Public Enum DialogStyleConstants
	'  Standard = 0
	'  InfoBox = 1
	'End Enum

  Public Class AlarmDialogSettings
    Inherits DialogSettingsBase

#Region "Class Members"

    'Property Constants
		Protected Shadows Const m_def_OkButtonText As String = "Dis&miss"
		Protected Shadows Const m_def_CancelButtonText As String = "&Snooze"
		Protected Shadows Const m_def_WindowText As String = "Alarm"
		Protected Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.Sizable
		Protected Shadows Const m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.CenterScreen
		Protected Const m_def_OpenButtonText As String = "&Open Item"
		Protected Const m_def_LocationHeaderText As String = "Room"
		Protected Const m_def_SnoozeText As String = "&Click Snooze to remind me again:"
		Protected Const m_def_IsModal As Boolean = False
		'Protected Const m_def_DialogStyle As DialogStyleConstants = DialogStyleConstants.Standard
		Protected Const m_def_DismissButtonEnabled As Boolean = True
		Protected Const m_def_SnoozeButtonEnabled As Boolean = True
		Protected Const m_def_OpenButtonEnabled As Boolean = True

    'Property Variables
    Private m_DismissButtonText As String
    Private m_SnoozeButtonText As String
    Private m_OpenButtonText As String
    Private m_LocationHeaderText As String
    Private m_SnoozeText As String
    Private m_IsModal As Boolean
    Private m_TimeSettings As New TimeSettings
		'Private m_DialogStyle As DialogStyleConstants
    Private m_DismissButtonEnabled As Boolean
    Private m_SnoozeButtonEnabled As Boolean
    Private m_OpenButtonEnabled As Boolean

    'Delegate
    Public Delegate Sub StandardButtonEventDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
    Public Delegate Sub ChangeButtonEventDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)

    'Events
    Public Event DismissButtonClick As StandardButtonEventDelegate
    Public Event SnoozeButtonClick As StandardButtonEventDelegate
    Public Event OpenButtonClick As ChangeButtonEventDelegate
    Public Event OKButtonClick As StandardButtonEventDelegate
    Public Event MoveUpButtonClick As ChangeButtonEventDelegate
    Public Event MoveDownButtonClick As ChangeButtonEventDelegate

#End Region

#Region "On... Event Methods"

    Protected Friend Overridable Sub OnDismissButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
      RaiseEvent DismissButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnSnoozeButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
      RaiseEvent SnoozeButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnOpenButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)
      RaiseEvent OpenButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnOKButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
      RaiseEvent OKButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnMoveUpButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)
      RaiseEvent MoveUpButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnMoveDownButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)
      RaiseEvent MoveDownButtonClick(Me, e)
    End Sub

#End Region

#Region "Constructor"

    'Constructor
		Public Sub New()
			MyBase.New()
			MyBase.WindowText = m_def_WindowText
			MyBase.StartPosition = m_def_StartPosition
			MyBase.Location = m_def_Location
			MyBase.Size = m_def_Size
			MyBase.OkButtonText = m_def_OkButtonText
			MyBase.CancelButtonText = m_def_CancelButtonText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			MyBase.Icon = New Icon(GetProjectFileAsStream("alarm.ico"))

			m_OpenButtonText = m_def_OpenButtonText
			m_LocationHeaderText = m_def_LocationHeaderText
			m_SnoozeText = m_def_SnoozeText
			m_IsModal = m_def_IsModal
			'm_DialogStyle = m_def_DialogStyle
			m_DismissButtonEnabled = m_def_DismissButtonEnabled
			m_SnoozeButtonEnabled = m_def_SnoozeButtonEnabled
			m_OpenButtonEnabled = m_def_OpenButtonEnabled
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the text of the 'Delete' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Delete"), _
    Description("Determines the text of the 'Delete' button.")> _
    Public Property OpenButtonText() As String
      Get
        Return m_OpenButtonText
      End Get
      Set(ByVal Value As String)
        m_OpenButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of the 'OK' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&OK"), _
    Description("Determines the text of the 'OK' button.")> _
    Public Property LocationHeaderText() As String
      Get
        Return m_LocationHeaderText
      End Get
      Set(ByVal Value As String)
        m_LocationHeaderText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of left-side header label.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Members:"), _
    Description("Determines the text of left-side header label.")> _
    Public Property SnoozeText() As String
      Get
        Return m_SnoozeText
      End Get
      Set(ByVal Value As String)
        m_SnoozeText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the dialog is displayed as modal.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(False), _
    Description("Determines if the dialog is displayed as modal.")> _
    Public Property IsModal() As Boolean
      Get
        Return m_IsModal
      End Get
      Set(ByVal Value As Boolean)
        m_IsModal = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text to be displayed for time units.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the text to be displayed for time units.")> _
    Public ReadOnly Property TimeSettings() As TimeSettings
      Get
        Return m_TimeSettings
      End Get
    End Property

		'<Browsable(True), _
		'Category("Appearance"), _
		'DefaultValue(GetType(DialogStyleConstants), "Standard"), _
		'Description("Determines if the look of the dialog.")> _
		'Public Property DialogStyle() As DialogStyleConstants
		'  Get
		'    Return m_DialogStyle
		'  End Get
		'  Set(ByVal Value As DialogStyleConstants)
		'    m_DialogStyle = Value
		'  End Set
		'End Property

    ''' <summary>
    ''' Determines if the 'Dismiss' button is enabled.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_DismissButtonEnabled), _
    Description("Determines if the 'Dismiss' button is enabled.")> _
    Public Property DismissButtonEnabled() As Boolean
      Get
        Return m_DismissButtonEnabled
      End Get
      Set(ByVal Value As Boolean)
        m_DismissButtonEnabled = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the 'Snooze' button is enabled.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_SnoozeButtonEnabled), _
    Description("Determines if the 'Snooze' button is enabled.")> _
    Public Property SnoozeButtonEnabled() As Boolean
      Get
        Return m_SnoozeButtonEnabled
      End Get
      Set(ByVal Value As Boolean)
        m_SnoozeButtonEnabled = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the 'Open' button is enabled.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_OpenButtonEnabled), _
    Description("Determines if the 'Open' button is enabled.")> _
    Public Property OpenButtonEnabled() As Boolean
      Get
        Return m_OpenButtonEnabled
      End Get
      Set(ByVal Value As Boolean)
        m_OpenButtonEnabled = Value
      End Set
    End Property

#End Region

  End Class

End Namespace