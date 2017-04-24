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

  Public Class AppointmentSizeEventsArgs
    Inherits System.EventArgs

#Region "Class Members"

		Protected m_StartTime As DateTime
		Protected m_Length As Integer
		Protected m_Cancel As Boolean
		Protected m_DateString As String = "Date: "
		Protected m_TimeString As String = "Time: "
		Protected m_Appointment As Gravitybox.Objects.Appointment

#End Region

#Region "Property Implementations"

    Public Property StartTime() As DateTime
      Get
        Return m_StartTime
      End Get
      Set(ByVal Value As DateTime)
        m_StartTime = GetTime(Value)
      End Set
    End Property

    Public Property Length() As Integer
      Get
        Return m_Length
      End Get
      Set(ByVal Value As Integer)
        m_Length = Value
      End Set
    End Property

		Public Property Cancel() As Boolean
			Get
				Return m_Cancel
			End Get
			Set(ByVal Value As Boolean)
				m_Cancel = Value
			End Set
		End Property

		Public Property DateString() As String
			Get
				Return m_DateString
			End Get
			Set(ByVal Value As String)
				m_DateString = Value
			End Set
		End Property

		Public Property TimeString() As String
			Get
				Return m_TimeString
			End Get
			Set(ByVal Value As String)
				m_TimeString = Value
			End Set
		End Property

		Public ReadOnly Property Appointment() As Gravitybox.Objects.Appointment
			Get
				Return m_Appointment
			End Get
		End Property

#End Region

#Region "Constructor"

    'Public Not Creatable
		Protected Friend Sub New(ByVal appointment As Gravitybox.Objects.Appointment, ByVal startTime As DateTime, ByVal length As Integer)
			m_StartTime = GetTime(startTime)
			m_Length = length
			m_Cancel = False
			m_Appointment = appointment
		End Sub

#End Region

  End Class

End Namespace
