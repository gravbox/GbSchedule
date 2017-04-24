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

  Public Class ConfigurationDialogSettings
    Inherits DialogSettingsBase

#Region "Class Members"

    'Property Constants
		Protected ReadOnly m_def_AddButtonText As String = "&Add"
		Protected ReadOnly m_def_Header1Text As String = "Members:"
		Protected ReadOnly m_def_Header2Text As String = "Properties:"
		Protected Shadows ReadOnly m_def_WindowText As String = "Object Configuration"
		Protected Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.Sizable
		Protected Shadows ReadOnly m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.CenterScreen
		Protected Shadows ReadOnly m_def_AllowHelp As Boolean = False

    'Property Variables
		Protected m_AddButtonText As String
		Protected m_Header1Text As String
		Protected m_Header2Text As String
		Protected m_AllowHelp As Boolean = m_def_AllowHelp

    'Delegate
    Public Delegate Sub StandardButtonEventDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
    Public Delegate Sub ChangeButtonEventDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)

    'Events
    Public Event AddButtonClick As StandardButtonEventDelegate
    Public Event CancelButtonClick As StandardButtonEventDelegate
    Public Event DeleteButtonClick As ChangeButtonEventDelegate
    Public Event OKButtonClick As StandardButtonEventDelegate
    Public Event MoveUpButtonClick As ChangeButtonEventDelegate
		Public Event MoveDownButtonClick As ChangeButtonEventDelegate
		Public Event SelectAllButtonClick As StandardButtonEventDelegate

#End Region

#Region "On... Event Methods"

    Protected Friend Overridable Sub OnAddButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
      RaiseEvent AddButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnCancelButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
      RaiseEvent CancelButtonClick(Me, e)
    End Sub

    Protected Friend Overridable Sub OnDeleteButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenChangeButtonEventArgs)
      RaiseEvent DeleteButtonClick(Me, e)
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

		Protected Friend Overridable Sub OnSelectAllButtonClick(ByVal e As Gravitybox.Objects.EventArgs.ConfigScreenStandardButtonEventArgs)
			RaiseEvent SelectAllButtonClick(Me, e)
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
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			MyBase.Size = New Size(472, 374)
			m_AddButtonText = m_def_AddButtonText
			m_Header1Text = m_def_Header1Text
			m_Header2Text = m_def_Header2Text
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the text of the 'Add' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Add"), _
    Description("Determines the text of the 'Add' button.")> _
    Public Property AddButtonText() As String
      Get
        Return m_AddButtonText
      End Get
      Set(ByVal Value As String)
        m_AddButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of left-side header label.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Members:"), _
    Description("Determines the text of left-side header label.")> _
    Public Property Header1Text() As String
      Get
        Return m_Header1Text
      End Get
      Set(ByVal Value As String)
        m_Header1Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text of right-side header label.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("Properties:"), _
    Description("Determines the text of right-side header label.")> _
    Public Property Header2Text() As String
      Get
        Return m_Header2Text
      End Get
      Set(ByVal Value As String)
        m_Header2Text = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the help text for each property is displayed.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(False), _
    Description("Determines if the help text for each property is displayed.")> _
    Public Property AllowHelp() As Boolean
      Get
        Return m_AllowHelp
      End Get
      Set(ByVal Value As Boolean)
        m_AllowHelp = Value
      End Set
    End Property

#End Region

  End Class

End Namespace