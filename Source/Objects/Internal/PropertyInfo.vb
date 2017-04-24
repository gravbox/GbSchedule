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

Namespace Gravitybox.Objects

  Friend Class PropertyInfo

    Private m_IsRequired As Boolean = False
    Private m_IsKey As Boolean = False
    Private m_PropertyInfo As System.Reflection.PropertyInfo
    Private m_PropertyType As System.Type
    Private m_FieldName As String

    Friend Sub New(ByVal propertyInfo As System.Reflection.PropertyInfo, ByVal propertyType As System.Type, ByVal fieldName As String, ByVal isRequired As Boolean, ByVal isKey As Boolean)
      m_PropertyInfo = propertyInfo
      m_PropertyType = propertyType
      m_FieldName = fieldName
      m_IsRequired = isRequired
      m_IsKey = isKey
    End Sub

    Friend ReadOnly Property PropertyInfo() As System.Reflection.PropertyInfo
      Get
        Return m_PropertyInfo
      End Get
    End Property

    Friend ReadOnly Property PropertyType() As System.Type
      Get
        Return m_PropertyType
      End Get
    End Property

    Friend ReadOnly Property FieldName() As String
      Get
        Return m_FieldName
      End Get
    End Property

    Friend ReadOnly Property IsRequired() As Boolean
      Get
        Return m_IsRequired
      End Get
    End Property

    Friend ReadOnly Property IsKey() As Boolean
      Get
        Return m_IsKey
      End Get
    End Property

  End Class

End Namespace