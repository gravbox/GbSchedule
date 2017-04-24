Option Strict On
Option Explicit On 

Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap

Module TestModule

  Public Sub SaveSoap(ByVal path As String, ByVal o As Object)

    Try
      Dim fs As FileStream = New FileStream(path, FileMode.Create)
      Dim sf As SoapFormatter = New SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.File))
      Call sf.Serialize(fs, o)
      Call fs.Close()
    Catch
      Throw
    End Try

  End Sub

  Public Function LoadSoap(ByVal path As String) As Object

    Try
      Dim fs As FileStream = New FileStream(path, FileMode.Open)
      Dim sf As SoapFormatter = New SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.File))
      Return sf.Deserialize(fs)
    Catch
      Throw
    End Try

  End Function

  Public Function RandomString() As String
    Return RandomString(10)
  End Function

  Public Function RandomString(ByVal count As Integer) As String

    Dim retval As String
    Dim ii As Integer
    If count < 1 Then count = 1
    For ii = 1 To count
      retval += Chr(65 + CInt(25 * Rnd()))
    Next
    Return retval

  End Function

End Module
