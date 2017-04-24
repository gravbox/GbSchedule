Option Strict On
Option Explicit On 

Public Class DateCollection
  Inherits CollectionBase

  Public Sub Add(ByVal newDate As Date)
    Call MyBase.List.Add(newDate)
  End Sub

  Public Function Exists(ByVal testDate As Date) As Boolean
    Dim o As Object
    For Each o In Me
      If CType(o, Date) = testDate Then
        Return True
      End If
    Next
  End Function

  Public Shadows Function RemoveAt(ByVal testDate As Date) As Boolean

    Dim o As Object
    Dim ii As Integer

    For Each o In Me
      If CType(o, Date) = testDate Then
        Call MyBase.RemoveAt(ii)
        Return True
      End If
      ii += 1
    Next
    Return False

  End Function

End Class
