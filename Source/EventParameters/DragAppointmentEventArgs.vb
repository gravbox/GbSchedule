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

  Public Class DragAppointmentEventArgs
    Inherits System.Windows.Forms.DragEventArgs

		Protected m_Appointment As Gravitybox.Objects.Appointment
		Private OriginalObject As System.Windows.Forms.DragEventArgs = Nothing
		Protected m_Cancel As Boolean = False

    Public ReadOnly Property Appointment() As Gravitybox.Objects.Appointment
      Get
        Return m_Appointment
      End Get
    End Property

		Public Property Cancel() As Boolean
			Get
				Return m_Cancel
			End Get
			Set(ByVal Value As Boolean)
				m_Cancel = Value
			End Set
		End Property

		'This is needed so that the settings is persisted to the original Effect property
		Public Overloads Property Effect() As System.Windows.Forms.DragDropEffects
			Get
				Return OriginalObject.Effect
			End Get
			Set(ByVal Value As System.Windows.Forms.DragDropEffects)
				OriginalObject.Effect = Value
				MyBase.Effect = Value
			End Set
		End Property

		Friend Sub SetAppointment(ByVal appointment As Gravitybox.Objects.Appointment)
			m_Appointment = CType(appointment, Gravitybox.Objects.Appointment)
		End Sub

		Protected Friend Sub New(ByVal e As System.Windows.Forms.DragEventArgs)
			MyBase.New(e.Data, e.KeyState, e.X, e.Y, e.AllowedEffect, e.Effect)
			OriginalObject = e
		End Sub

		Protected Friend Sub New(ByVal e As System.Windows.Forms.DragEventArgs, ByVal appointment As Appointment)
			MyBase.New(e.Data, e.KeyState, e.X, e.Y, e.AllowedEffect, e.Effect)
			OriginalObject = e
			Me.SetAppointment(appointment)
		End Sub

	End Class

End Namespace