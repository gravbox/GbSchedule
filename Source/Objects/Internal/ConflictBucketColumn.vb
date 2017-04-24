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

  Friend Class ConflictBucketColumn

#Region "Class Members"

    Private m_AppointmentRectangles As New AppointmentRectangleInfoCollection(Nothing)
    Private m_ColumnIndex As Integer
    Private m_Parent As ConflictBucketColumnCollection
    Private m_SortIndexStart As Double = -1
    Private m_SortIndexEnd As Double = -1

#End Region

    Friend Sub New(ByVal newParent As ConflictBucketColumnCollection)
      m_Parent = newParent
    End Sub

#Region "Property Implementations"

    Friend ReadOnly Property Parent() As ConflictBucketColumnCollection
      Get
        Return m_Parent
      End Get
    End Property

    Public Property SortIndexStart() As Double
      Get
        Return m_SortIndexStart
      End Get
      Set(ByVal Value As Double)
        m_SortIndexStart = Value
      End Set
    End Property

    Public Property SortIndexEnd() As Double
      Get
        Return m_SortIndexEnd
      End Get
      Set(ByVal Value As Double)
        m_SortIndexEnd = Value
      End Set
    End Property

    Public ReadOnly Property AppointmentRectangles() As AppointmentRectangleInfoCollection
      Get
        Return m_AppointmentRectangles
      End Get
    End Property

    Public Property ColumnIndex() As Integer
      Get
        Return m_ColumnIndex
      End Get
      Set(ByVal Value As Integer)
        m_ColumnIndex = Value
      End Set
    End Property

#End Region

#Region "Methods"

    Public Sub AddRectangle(ByVal rectInfo As AppointmentRectangleInfo)

      Try

        'If this rectangle extends the group border then do so
        If (Me.SortIndexStart = -1) OrElse (Me.SortIndexStart > rectInfo.SortIndexStart) Then
          Me.SortIndexStart = rectInfo.SortIndexStart
        End If
        If (Me.SortIndexEnd = -1) OrElse (Me.SortIndexEnd < rectInfo.SortIndexEnd) Then
          Me.SortIndexEnd = rectInfo.SortIndexEnd
        End If

        'Add the actual rectangle
        Me.AppointmentRectangles.AddObject(rectInfo)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Public Sub Merge(ByVal conflictColumns As ConflictBucketColumn)
      Try
        'Merge the sort indexes as well
        If (Me.SortIndexStart = -1) OrElse (Me.SortIndexStart > conflictColumns.SortIndexStart) Then
          Me.SortIndexStart = conflictColumns.SortIndexStart
        End If
        If (Me.SortIndexEnd = -1) OrElse (Me.SortIndexEnd < conflictColumns.SortIndexEnd) Then
          Me.SortIndexEnd = conflictColumns.SortIndexEnd
        End If

        Me.AppointmentRectangles.Merge(conflictColumns.AppointmentRectangles)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace