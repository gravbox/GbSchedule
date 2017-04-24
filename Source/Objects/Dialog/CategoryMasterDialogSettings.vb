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

  Public Class CategoryMasterDialogSettings
    Inherits DialogSettingsBase

#Region "Class Members"

    'Property Constants
    Private ReadOnly m_def_HeaderText As String = "New Category"
    Private ReadOnly m_def_AddButtonText As String = "&Add"
		Private Shadows ReadOnly m_def_WindowText As String = "Master Category List"
		Private Shadows ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.Sizable
		Private Shadows ReadOnly m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.Manual

    'Property Variables
    Private m_HeaderText As String
    Private m_AddButtonText As String

#End Region

#Region "Constructor"

    'Constructor
		Friend Sub New()
			MyBase.New()
			MyBase.WindowText = m_def_WindowText
			MyBase.FormBorderStyle = m_def_FormBorderStyle
			MyBase.StartPosition = m_def_StartPosition
			MyBase.Location = m_def_Location
			MyBase.Size = m_def_Size
			m_HeaderText = m_def_HeaderText
			m_AddButtonText = m_def_AddButtonText
		End Sub

#End Region

#Region "Property Implementation"

    ''' <summary>
    ''' Determines the text of the header label.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("New Category"), _
    Description("Determines the text of the header label.")> _
    Public Property HeaderText() As String
      Get
        Return m_HeaderText
      End Get
      Set(ByVal Value As String)
        m_HeaderText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text displayed on the 'Add' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Add"), _
    Description("Determines the text displayed on the 'Add' button.")> _
    Public Property AddButtonText() As String
      Get
        Return m_AddButtonText
      End Get
      Set(ByVal Value As String)
        m_AddButtonText = Value
      End Set
    End Property

#End Region

	End Class

End Namespace