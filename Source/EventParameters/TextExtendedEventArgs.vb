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

Imports Gravitybox.Objects

Namespace Gravitybox.Objects.EventArgs

  Public Class TextExtendedEventArgs
    Inherits TextEventArgs

		Protected m_Parameter2 As String = ""
		Protected m_Prompt As Boolean = False
		Protected m_IsValid As Boolean = True

    Public Property Parameter2() As String
      Get
        Return m_Parameter2
      End Get
      Set(ByVal Value As String)
        m_Parameter2 = Value
      End Set
    End Property

    Public Property Prompt() As Boolean
      Get
        Return m_Prompt
      End Get
      Set(ByVal Value As Boolean)
        m_Prompt = Value
      End Set
    End Property

    Public Property IsValid() As Boolean
      Get
        Return m_IsValid
      End Get
      Set(ByVal Value As Boolean)
        m_IsValid = Value
      End Set
    End Property

    'Public Not Creatable
		Protected Friend Sub New(ByVal newText As String)
			MyBase.New(newText)
		End Sub

    Protected Friend Sub New(ByVal newText As String, ByVal newParameter2 As String)
      MyBase.New(newText)
      m_Parameter2 = newParameter2
    End Sub

    Protected Friend Sub New(ByVal newText As String, ByVal newParameter2 As String, ByVal isValid As Boolean)
      Me.New(newText, newParameter2)
      m_IsValid = isValid
    End Sub

	End Class

End Namespace
