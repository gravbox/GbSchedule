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

  Friend Class ConflictBucketColumnCollection
    Inherits System.Collections.CollectionBase

#Region "Class Members"

    Private Parent As ConflictBucketGroup

#End Region

    'Override constructor so that this object not publically creatable
    Friend Sub New(ByVal group As ConflictBucketGroup)
      Parent = group
    End Sub

#Region "Add"

    Public Function Add() As ConflictBucketColumn

      Try
        Return AddObject(New ConflictBucketColumn(Me))
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Private Function AddObject(ByVal newObject As ConflictBucketColumn) As ConflictBucketColumn
      Call MyBase.List.Add(newObject)
      Return newObject
    End Function

#End Region

#Region "Contains"

    Public Function Contains(ByVal index As Integer) As Boolean
      Return (0 <= index) AndAlso (index < Me.Count)
    End Function

#End Region

#Region "Methods"

    Public Function FindFit(ByVal rectInfo As AppointmentRectangleInfo) As Integer

      Try
        Dim isConflict As Boolean = False
        Dim column As ConflictBucketColumn
        Dim rect As AppointmentRectangleInfo
        Dim ii As Integer

        ii = 0
        For Each column In Me
          isConflict = False

          'Loop through all of the rectangles in this column
          'and check for conflicts
          For Each rect In column.AppointmentRectangles
            If rect.IsConflict(rectInfo) Then
              isConflict = True
              Exit For
            End If
          Next

          'If this column has no conflicts then return it
          If Not isConflict Then
            'return current column index
            Return ii
          End If

          'Cache next column index
          ii += 1
        Next

        'If made it here they are all conflicts so return (count+1)
        Return ii

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Sub Merge(ByVal columns As ConflictBucketColumnCollection)

      Try

        'Make sure that this column collection has enough columns to hold the new collection
        'Dim column As ConflictBucketColumn
        'For Each column In columns
        '  'Add enough columns to handle the new column index
        '  Dim ii As Integer
        '  For ii = 0 To (column.ColumnIndex - Me.Count)
        '    Call Me.Add()
        '  Next

        '  'Now add all of the rectangles from the source column to the destination column
        '  Dim rectInfo As AppointmentRectangleInfo
        '  For Each rectInfo In column.AppointmentRectangles
        '    Item(column.ColumnIndex).AddRectangle(rectInfo)
        '  Next

        'Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Friend Sub Compact()

      'Check to determine if there are any overlapping columns and if so merge them
      Try
        Dim column1 As ConflictBucketColumn
        For Each column1 In Me
          Dim removeIndex As Integer = 0
          Dim column2 As ConflictBucketColumn
          For Each column2 In Me
            'Do not compare a column against itself
            If Not (column1 Is column2) Then
              'Check for conflict
              If IsConflict(column1, column2) Then
                'There is an overlap so merge the columns
                column1.Merge(column2)

                'Remove column2 as it has been merged with column1
                Me.RemoveAt(removeIndex)

                'Compact again, the loop can not continue because the 
                'collection has changed and this will cause an error
                Call Compact()
                Return
              End If
            End If

            removeIndex += 1
          Next
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Function IsConflict(ByVal column1 As ConflictBucketColumn, ByVal column2 As ConflictBucketColumn) As Boolean

      Try

        If (column1.SortIndexStart = column2.SortIndexStart) AndAlso _
           (column1.SortIndexEnd = column2.SortIndexEnd) Then
          'Appointments are exactly the same
          Return True

        ElseIf (column1.SortIndexStart < column2.SortIndexEnd) AndAlso _
               (column1.SortIndexEnd > column2.SortIndexStart) Then
          'Overlap
          Return True

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Item"

    Default Public ReadOnly Property Item(ByVal index As Integer) As ConflictBucketColumn
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), ConflictBucketColumn)
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

#End Region

#Region "Remove"

    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      If Not Contains(index) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Call MyBase.RemoveAt(index)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return True

    End Function

#End Region

  End Class

End Namespace
