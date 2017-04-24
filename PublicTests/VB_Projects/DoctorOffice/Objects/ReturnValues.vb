Option Strict On
Option Explicit On 

Public Class ReturnValues
  Inherits System.Collections.CollectionBase

#Region "Add Methods"

  Public Function Add(ByVal setting As Object) As ReturnValue

    Dim newObject As New ReturnValue()
    newObject.Setting = setting

    Try
      'Create the object and add it to the collections
      Return AddObject(newObject, -1)
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Private Function AddObject(ByVal newObject As ReturnValue) As ReturnValue
    Return AddObject(newObject, -1)
  End Function

  Private Function AddObject(ByVal newObject As ReturnValue, ByVal index As Integer) As ReturnValue

    If (index < -1) Or (index > Me.Count) Then
      'Subscript out of range
      Throw New System.ArgumentOutOfRangeException()
    End If

    Try
      If index = -1 Then
        MyBase.List.Add(newObject)
      Else
        MyBase.List.Insert(index, newObject)
      End If
    Catch ex As Exception
      Call SetErr(ex)
    End Try
    Return newObject

  End Function

#End Region

  Public Function Exists(ByVal index As Integer) As Boolean
    Return (0 <= index) AndAlso (index < Me.Count)
  End Function

  Default Public ReadOnly Property Item(ByVal index As Integer) As ReturnValue
    Get
      Try
        If (0 <= index) AndAlso (index < Me.Count) Then
          Return CType(MyBase.List(index), ReturnValue)
        End If
      Catch ex As Exception
        Call SetErr(ex)
      End Try
      Throw New System.ArgumentOutOfRangeException()
    End Get
  End Property

  Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

    If Not Exists(index) Then
      Throw New System.ArgumentOutOfRangeException()
    End If

    Try
      Dim element As ReturnValue
      element = Item(index)
      Call MyBase.RemoveAt(index)
      Return True
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

End Class
