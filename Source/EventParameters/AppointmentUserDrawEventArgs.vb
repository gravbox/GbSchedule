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

  Public Class AppointmentUserDrawEventArgs
		Inherits System.EventArgs

#Region "Class Header"

		Protected m_Graphics As System.Drawing.Graphics
		Protected m_Appointment As Gravitybox.Objects.Appointment
		Protected m_Rectangle As System.Drawing.Rectangle

#End Region

#Region "Constructor"

		Protected Friend Sub New(ByVal g As graphics, ByVal appointment As Gravitybox.Objects.Appointment, ByVal rectangle As rectangle)
			m_Graphics = g
			m_Appointment = appointment
			m_Rectangle = rectangle
		End Sub

#End Region

#Region "Property Implementations"


		Public ReadOnly Property graphics() As System.Drawing.Graphics
			Get
				Return m_Graphics
			End Get
		End Property

		Public ReadOnly Property Appointment() As Gravitybox.Objects.Appointment
			Get
				Return m_Appointment
			End Get
		End Property

		Public ReadOnly Property rectangle() As System.Drawing.Rectangle
			Get
				Return m_Rectangle
			End Get
		End Property

#End Region

	End Class

End Namespace