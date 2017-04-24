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

  Public Class CategoryDialogSettings
    Inherits DialogSettingsBase

#Region "Class Members"

    'Private Constants
		Private Shadows m_def_WindowText As String = "Select Categories"
		Private m_def_MasterButtonText As String = "&Master Categories"
    Private m_def_AllowMaster As Boolean = True
		Private Shadows m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.Sizable

    'Property Variables
    Private m_MasterButtonText As String
    Private m_AllowMaster As Boolean
    Private m_CategoryMasterDialog As New CategoryMasterDialogSettings

#End Region

#Region "Constructor"

    'Constructor
		Public Sub New()
			MyBase.New()
			MyBase.WindowText = m_def_WindowText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			m_MasterButtonText = m_def_MasterButtonText
			m_AllowMaster = m_def_AllowMaster
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the text displayed on the 'Master Categories' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Master Categories"), _
    Description("Determines the text displayed on the 'Master Categories' button.")> _
    Public Property MasterButtonText() As String
      Get
        Return m_MasterButtonText
      End Get
      Set(ByVal Value As String)
        m_MasterButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines if the dialog has a 'Master Categories' button.
    ''' </summary>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(True), _
    Description("Determines if the dialog has a 'Master Categories' button.")> _
    Public Property AllowMaster() As Boolean
      Get
        Return m_AllowMaster
      End Get
      Set(ByVal Value As Boolean)
        m_AllowMaster = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the dialog settings object for the master categories dialog.
    ''' </summary>
    <Browsable(False), _
    Category("Appearance"), _
    Description("This is the dialog settings object for the master categories dialog.")> _
    Public Property CategoryMasterDialog() As CategoryMasterDialogSettings
      Get
        Return m_CategoryMasterDialog
      End Get
      Set(ByVal Value As CategoryMasterDialogSettings)
        m_CategoryMasterDialog = Value
      End Set
    End Property

#End Region

  End Class

End Namespace