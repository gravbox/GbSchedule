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

  Public Class DialogSettingsBase

#Region "Class Members"

    'Private Constants
		Protected Const m_def_WindowText As String = ""
		Protected Const m_def_OkButtonText As String = "&OK"
		Protected Const m_def_CancelButtonText As String = "&Cancel"
		Protected Const m_def_DeleteButtonText As String = "&Delete"
		Protected Const m_def_SelectAllButtonText As String = "Select &All"
		Protected ReadOnly m_def_FormBorderStyle As System.Windows.Forms.FormBorderStyle = FormBorderStyle.FixedDialog
		Protected ReadOnly m_def_StartPosition As System.Windows.Forms.FormStartPosition = FormStartPosition.CenterScreen
		Protected ReadOnly m_def_Location As System.Drawing.Point = New Point(0, 0)
		Protected ReadOnly m_def_Size As System.Drawing.Size = New Size(300, 300)

    'Property Variables
		Protected m_WindowText As String
		Protected m_OkButtonText As String
		Protected m_CancelButtonText As String
		Protected m_DeleteButtonText As String
		Protected m_SelectAllButtonText As String
		Protected m_FormBorderStyle As System.Windows.Forms.FormBorderStyle
		Protected m_StartPosition As System.Windows.Forms.FormStartPosition
		Protected m_Icon As System.Drawing.Icon
		Protected m_Location As System.Drawing.Point
		Protected m_Size As System.Drawing.Size
		Protected m_Appearance As Appearance

#End Region

#Region "Constructor"

    'Constructor
		Protected Sub New()
			Me.SetupDefaultAppearance()
			m_WindowText = m_def_WindowText
			m_OkButtonText = m_def_OkButtonText
			m_CancelButtonText = m_def_CancelButtonText
			m_SelectAllButtonText = m_def_SelectAllButtonText
			m_DeleteButtonText = m_def_DeleteButtonText
			m_FormBorderStyle = m_def_FormBorderStyle
			m_StartPosition = m_def_StartPosition
			m_Location = m_def_Location
			m_Size = m_def_Size
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the dialog caption.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("Determines the dialog caption.")> _
    Public Property WindowText() As String
      Get
        Return m_WindowText
      End Get
      Set(ByVal Value As String)
        m_WindowText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text displayed on the 'OK' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&OK"), _
    Description("Determines the text displayed on the 'OK' button.")> _
    Public Property OkButtonText() As String
      Get
        Return m_OkButtonText
      End Get
      Set(ByVal Value As String)
        m_OkButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text displayed on the 'Cancel' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Cancel"), _
    Description("Determines the text displayed on the 'Cancel' button.")> _
    Public Property CancelButtonText() As String
      Get
        Return m_CancelButtonText
      End Get
      Set(ByVal Value As String)
        m_CancelButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text displayed on the 'Delete' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Cancel"), _
    Description("Determines the text displayed on the 'Delete' button.")> _
    Public Property DeleteButtonText() As String
      Get
        Return m_DeleteButtonText
      End Get
      Set(ByVal Value As String)
        m_DeleteButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text displayed on the 'SelectAll' button.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue("&Cancel"), _
    Description("Determines the text displayed on the 'SelectAll' button.")> _
    Public Property SelectAllButtonText() As String
      Get
        Return m_SelectAllButtonText
      End Get
      Set(ByVal Value As String)
        m_SelectAllButtonText = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the dialog borderstyle.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(FormBorderStyle), "Sizable"), _
    Description("Determines the dialog borderstyle.")> _
    Public Property FormBorderStyle() As System.Windows.Forms.FormBorderStyle
      Get
        Return m_FormBorderStyle
      End Get
      Set(ByVal Value As System.Windows.Forms.FormBorderStyle)
        m_FormBorderStyle = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the starting position of the dialog when displayed.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(FormStartPosition), "CenterScreen"), _
    Description("Determines the starting position of the dialog when displayed.")> _
    Public Property StartPosition() As System.Windows.Forms.FormStartPosition
      Get
        Return m_StartPosition
      End Get
      Set(ByVal Value As System.Windows.Forms.FormStartPosition)
        m_StartPosition = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the icon to be displayed in the dialog controlbox.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the icon to be displayed in the dialog controlbox.")> _
    Public Property Icon() As System.Drawing.Icon
      Get
        Return m_Icon
      End Get
      Set(ByVal Value As System.Drawing.Icon)
        m_Icon = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the location of the window.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the location of the window.")> _
    Public Property Location() As System.Drawing.Point
      Get
        Return m_Location
      End Get
      Set(ByVal Value As System.Drawing.Point)
        m_Location = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the size of the window.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the size of the window.")> _
    Public Property Size() As System.Drawing.Size
      Get
        Return m_Size
      End Get
      Set(ByVal Value As System.Drawing.Size)
        m_Size = Value
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
			End Set
		End Property

#End Region

#Region "Methods"

		Private Sub SetupDefaultAppearance()
			m_Appearance = New Appearance
			m_Appearance.BackColor = SystemColors.Control
			m_Appearance.ForeColor = Color.Black
		End Sub

#End Region

  End Class

End Namespace
