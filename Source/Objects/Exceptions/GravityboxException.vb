Option Strict On
Option Explicit On 

Imports System

Namespace Gravitybox.Exceptions

  Public Class GravityboxException
    Inherits ApplicationException

    Public Sub New()
      MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
      MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
      MyBase.New(message, innerException)
    End Sub

  End Class

End Namespace