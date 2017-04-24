Option Strict On
Option Explicit On 

Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization.Formatters.Soap

Module Globals

  'Private constants needed for this object
  Public Const ErrorStringNoKey As String = "The specified key may not empty!"
  Public Const ErrorStringDuplicateKeyCollection As String = "The specified key already exists in this collection!"
  Public Const ErrorStringDuplicateKeyObject As String = "An object exists in the parent collection with the specified key!"
  Public Const ErrorStringObjectHasParent As String = "This object is already a member of a collection!"
  Public Const ErrorStringNoParentIndex As String = "This object does not have a parent collection and as such has no index value!"
  Public Const ErrorStringObjectHasNoParent As String = "This specified object must have a parent!"

  'Serialize an object to file in SOAP format.
  Public Sub SaveSoapToFile(ByVal fileName As String, ByVal o As Object)

    Try
      ' Open a file stream for output.
      Dim fs As System.IO.FileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Create)
      ' Create a SOAP formatter for this stream.
      Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File))
      ' Serialize the array to the file stream, and close the stream.
      sf.Serialize(fs, o)
      fs.Close()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Sub

  'Deserialize an object from a file in SOAP format.
  Public Function LoadSoapFromFile(ByVal fileName As String) As Object

    Try
      If Not System.IO.File.Exists(fileName) Then Return Nothing
      'Open a file stream for input.
      Dim fs As System.IO.FileStream = New System.IO.FileStream(fileName, System.IO.FileMode.Open)
      ' Create a SOAP formatter for this stream.
      Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File))

      ' Deserialize the contents of the file stream into an object.
      LoadSoapFromFile = sf.Deserialize(fs)
      ' close the stream.
      fs.Close()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Public Function CloneObject(ByVal obj As Object) As Object

    Try
      ' Create a memory stream and a formatter.
      Dim ms As New System.IO.MemoryStream(1000)
      Dim bf As New BinaryFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
      ' Serialize the object into the stream.
      Call bf.Serialize(ms, obj)
      ' Position streem pointer back to first byte.
      Call ms.Seek(0, SeekOrigin.Begin)
      ' Deserialize into another object.
      CloneObject = bf.Deserialize(ms)
      ' release memory.
      Call ms.Close()
    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Public Function ObjectToXML(ByVal obj As Object) As String

    Try
      ' Create a memory stream and a formatter.
      Dim ms As New System.IO.MemoryStream(1000)
      Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))
      ' Serialize the object into the stream.
      Call sf.Serialize(ms, obj)
      ' Position stream pointer back to first byte.
      Call ms.Seek(0, SeekOrigin.Begin)
      Dim arr As Array = Array.CreateInstance(GetType(Byte), CInt(ms.Length))
      Call ms.Read(CType(arr, Byte()), 0, CInt(ms.Length))
      Dim byteArr() As Byte = ms.ToArray()
      Dim ii As Integer
      Dim retval As String
      For ii = 0 To UBound(byteArr)
        retval &= Chr(byteArr(ii))
      Next
      ' release memory.
      Call ms.Close()
      Return retval

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Public Function XMLToObject(ByVal xml As String) As Object


    Try
      Dim retval As Object

      ' Create a memory stream and a formatter.
      Dim ms As New System.IO.MemoryStream(1000)
      Dim sf As New System.Runtime.Serialization.Formatters.Soap.SoapFormatter(Nothing, New StreamingContext(StreamingContextStates.Clone))

      Dim arr As Array = Array.CreateInstance(GetType(Byte), xml.Length)
      Dim charArr() As Char = xml.ToCharArray()
      Dim byteArr(xml.Length) As Byte

      Dim ii As Integer
      Dim S As String
      For ii = 0 To xml.Length - 1
        byteArr(ii) = CByte(Asc(charArr(ii)))
        S &= Chr(byteArr(ii))
      Next

      Call ms.Write(byteArr, 0, xml.Length)
      Call ms.Seek(0, SeekOrigin.Begin)

      retval = sf.Deserialize(ms)

      ' release memory.
      Call ms.Close()
      Return retval

    Catch ex As Exception
      Call SetErr(ex)
    End Try

  End Function

  Public Sub SetErr(ByVal ex As Exception)
    On Error Resume Next
    Call MsgBox(ex.ToString, MsgBoxStyle.Information)
  End Sub

End Module
