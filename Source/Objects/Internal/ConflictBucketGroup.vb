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

  Friend Class ConflictBucketGroup

#Region "Class Members"

    Private m_SortIndexStart As Double = -1
    Private m_SortIndexEnd As Double = -1
    Private m_Columns As New ConflictBucketColumnCollection(Me)
    Private m_Parent As ConflictBucketGroupCollection

#End Region

    Friend Sub New(ByVal newParent As ConflictBucketGroupCollection)
      m_Parent = newParent
    End Sub

#Region "Property Implementations"

    Friend ReadOnly Property Parent() As ConflictBucketGroupCollection
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

    Public ReadOnly Property Columns() As ConflictBucketColumnCollection
      Get
        Return m_Columns
      End Get
    End Property

#End Region

#Region "Methods"

    Public Sub Merge(ByVal conflictGroup As ConflictBucketGroup)

      Try
        'Merge the sort indexes as well
        'If (Me.SortIndexStart = -1) OrElse (Me.SortIndexStart > conflictGroup.SortIndexStart) Then
        '  Me.SortIndexStart = conflictGroup.SortIndexStart
        'End If
        'If (Me.SortIndexEnd = -1) OrElse (Me.SortIndexEnd < conflictGroup.SortIndexEnd) Then
        '  Me.SortIndexEnd = conflictGroup.SortIndexEnd
        'End If
        'Me.Columns.Merge(conflictGroup.Columns)

        Dim column As ConflictBucketColumn
        For Each column In conflictGroup.Columns
          Dim rectInfo As AppointmentRectangleInfo
          For Each rectInfo In column.AppointmentRectangles
            Me.AddRectangle(rectInfo)
          Next
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Public Function IsFit(ByVal rectInfo As AppointmentRectangleInfo) As Boolean

      Try
        If (rectInfo.SortIndexStart = Me.SortIndexStart) AndAlso _
           (rectInfo.SortIndexEnd = Me.SortIndexEnd) Then
          'Appointments are exactly the same
          Return True

        ElseIf (rectInfo.SortIndexStart < Me.SortIndexEnd) AndAlso _
               (rectInfo.SortIndexEnd > Me.SortIndexStart) Then
          'Overlap
          Return True

        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Sub AddRectangle(ByVal rectInfo As AppointmentRectangleInfo)

      Try

        'If this rectangle extends the group border then do so
        If (Me.SortIndexStart = -1) OrElse (Me.SortIndexStart > rectInfo.SortIndexStart) Then
          Me.SortIndexStart = rectInfo.SortIndexStart
        End If
        If (Me.SortIndexEnd = -1) OrElse (Me.SortIndexEnd < rectInfo.SortIndexEnd) Then
          Me.SortIndexEnd = rectInfo.SortIndexEnd
        End If

        Dim columnIndex As Integer = Me.Columns.FindFit(rectInfo)
        If columnIndex >= Me.Columns.Count Then
          'If a suitable bucket was not found in an 
          'existing column then create a new column
          Dim columnObject As ConflictBucketColumn = Me.Columns.Add()
          columnObject.ColumnIndex = columnIndex
          Call columnObject.AddRectangle(rectInfo)
        Else
          Dim columnObject As ConflictBucketColumn = Me.Columns(columnIndex)
          Call columnObject.AddRectangle(rectInfo)
          'Me.Columns.Compact()
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace