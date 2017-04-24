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

  <Serializable()> _
  Friend Class AppointmentRectangleInfo

#Region "Class Members"

    Private m_Rect As Rectangle
    Private m_StartDate As DateTime
    Private m_StartTime As DateTime
    Private m_StartRoom As Integer
    Private m_StartResource As Integer
    Private m_StartProvider As Integer
    Private m_Length As Integer
    Private m_SortIndexStart As Double
    Private m_SortIndexEnd As Double
    Private m_Column As Integer 'which sub-column [0 based]
    Private m_ConflictCount As Integer
    Private m_Parent As AppointmentRectangleInfoCollection
    Private m_BrokenStart As Boolean
    Private m_BrokenEnd As Boolean

#End Region

#Region "Constructor"

    Friend Sub New()
    End Sub

    Friend Sub New(ByVal parent As AppointmentRectangleInfoCollection)
      m_Parent = parent
    End Sub

#End Region

#Region "Property Implementations"

    Public Property Rect() As Rectangle
      Get
        Return m_Rect
      End Get
      Set(ByVal Value As Rectangle)
        m_Rect = Value
      End Set
    End Property

    Public Property StartDate() As DateTime
      Get
        Return m_StartDate
      End Get
      Set(ByVal Value As DateTime)
        m_StartDate = Value
      End Set
    End Property

    Public Property StartTime() As DateTime
      Get
        Return m_StartTime
      End Get
      Set(ByVal Value As DateTime)
        m_StartTime = GetTime(Value)
      End Set
    End Property

    Public Property StartRoom() As Integer
      Get
        Return m_StartRoom
      End Get
      Set(ByVal Value As Integer)
        m_StartRoom = Value
      End Set
    End Property

    Public Property StartResource() As Integer
      Get
        Return m_StartResource
      End Get
      Set(ByVal Value As Integer)
        m_StartResource = Value
      End Set
    End Property

    Public Property StartProvider() As Integer
      Get
        Return m_StartProvider
      End Get
      Set(ByVal Value As Integer)
        m_StartProvider = Value
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

    Public ReadOnly Property EndTime() As DateTime
      Get
        If Me.Length <= 0 Then
          Return Me.StartTime
        Else
          Return DateAdd(DateInterval.Minute, Me.Length, Me.StartTime)
        End If
      End Get
    End Property

    Friend Property SortIndexStart() As Double
      Get
        Return m_SortIndexStart
      End Get
      Set(ByVal Value As Double)
        'Correct for rounding errors. There is only 86400 seconds in 
        'a day so round to the 100,000ths place. We lose no precision!
        Value = CLng(Value * 100000.0) / 100000.0
        m_SortIndexStart = Value
      End Set
    End Property

    Friend Property SortIndexEnd() As Double
      Get
        Return m_SortIndexEnd
      End Get
      Set(ByVal Value As Double)
        'Correct for rounding errors. There is only 86400 seconds in 
        'a day so round to the 100,000ths place. We lose no precision!
        Value = CLng(Value * 100000.0) / 100000.0
        m_SortIndexEnd = Value
      End Set
    End Property

    Friend Property Column() As Integer
      Get
        Return m_Column
      End Get
      Set(ByVal Value As Integer)
        m_Column = Value
      End Set
    End Property

    Friend Property ConflictCount() As Integer
      Get
        Return m_ConflictCount
      End Get
      Set(ByVal Value As Integer)
        m_ConflictCount = Value
      End Set
    End Property

    Friend ReadOnly Property Parent() As AppointmentRectangleInfoCollection
      Get
        Return m_Parent
      End Get
    End Property

    Friend Property BrokenStart() As Boolean
      Get
        Return m_BrokenStart
      End Get
      Set(ByVal Value As Boolean)
        m_BrokenStart = Value
      End Set
    End Property

    Friend Property BrokenEnd() As Boolean
      Get
        Return m_BrokenEnd
      End Get
      Set(ByVal Value As Boolean)
        m_BrokenEnd = Value
      End Set
    End Property

#End Region

#Region "IsConflict"

    Friend Function IsConflict(ByVal appointmentRectangle As AppointmentRectangleInfo) As Boolean

      Try

        If (appointmentRectangle.SortIndexStart = Me.SortIndexStart) AndAlso _
           (appointmentRectangle.SortIndexEnd = Me.SortIndexEnd) Then
          'Appointments are exactly the same
          Return True

        ElseIf (appointmentRectangle.SortIndexStart < Me.SortIndexEnd) AndAlso _
               (appointmentRectangle.SortIndexEnd > Me.SortIndexStart) Then
          'Overlap
          Return True

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

  End Class

End Namespace