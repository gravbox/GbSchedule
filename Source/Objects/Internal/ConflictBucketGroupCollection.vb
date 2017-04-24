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

  Friend Class ConflictBucketGroupCollection
    Inherits System.Collections.CollectionBase

#Region "Class Members"

    Private Parent As ConflictBucket

#End Region

    'Override constructor so that this object not publically creatable
    Friend Sub New(ByVal bucket As ConflictBucket)
      Parent = bucket
    End Sub

#Region "Add"

    Public Function Add() As ConflictBucketGroup

      Try
        Return AddObject(New ConflictBucketGroup(Me))
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Private Function AddObject(ByVal newObject As ConflictBucketGroup) As ConflictBucketGroup
      Call MyBase.List.Add(newObject)
      Return newObject
    End Function

#End Region

#Region "Contains"

    Public Function Contains(ByVal index As Integer) As Boolean
      Return (0 <= index) AndAlso (index < Me.Count)
    End Function

#End Region

#Region "Item"

    Default Public ReadOnly Property Item(ByVal index As Integer) As ConflictBucketGroup
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), ConflictBucketGroup)
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

#Region "Methods"

    Friend Sub Compact()

      'Check to determine if there are any overlapping groups and if so merge them
      Try
        Dim group1 As ConflictBucketGroup
        For Each group1 In Me
          Dim removeIndex As Integer = 0
          Dim group2 As ConflictBucketGroup
          For Each group2 In Me
            'Do not compare a group against itself
            If Not (group1 Is group2) Then
              'Check for conflict
              If IsConflict(group1, group2) Then
                'There is an overlap so merge the groups
                group1.Merge(group2)

                'Remove Group2 as it has been merged with Group1
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

    Private Function IsConflict(ByVal group1 As ConflictBucketGroup, ByVal group2 As ConflictBucketGroup) As Boolean

      Try

        If (group1.SortIndexStart = group2.SortIndexStart) AndAlso _
           (group1.SortIndexEnd = group2.SortIndexEnd) Then
          'Appointments are exactly the same
          Return True

        ElseIf (group1.SortIndexStart < group2.SortIndexEnd) AndAlso _
               (group1.SortIndexEnd > group2.SortIndexStart) Then
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
