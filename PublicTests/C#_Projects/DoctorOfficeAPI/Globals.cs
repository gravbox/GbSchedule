Option Strict On
Option Explicit On 

using System.IO
using System.Runtime.Serialization
using System.Runtime.Serialization.Formatters.Binary
using System.Runtime.Serialization.Formatters.Soap

Module DoctorOfficeGlobals

//Private constants needed for this object
public const string ErrorStringNoKey = "The specified key may not empty!";
public const string ErrorStringDuplicateKeyCollection = "The specified key already exists in this collection!";
public const string ErrorStringDuplicateKeyObject = "An object exists in the parent collection with the specified key!";
public const string ErrorStringObjectHasParent = "This object is already a member of a collection!";
public const string ErrorStringNoParentIndex = "This object does not have a parent collection and as such has no index value!";
public const string ErrorStringObjectHasNoParent = "This specified object must have a parent!";

//Serialize an object to file in SOAP format.
public void SaveSoapToFile(string fileName, object o)
{

try
{
// Open a file stream for output.
System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
// Create a SOAP formatter for this stream.
System.Runtime.Serialization.Formatters.Soap.SoapFormatter sf = new System.Runtime.Serialization.Formatters.Soap.SoapFormatter(null, new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File));
// Serialize the array to the file stream, and close the stream.
sf.Serialize(fs, o);
fs.Close();
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

//Deserialize an object from a file in SOAP format.
public Function LoadSoapFromFile(string fileName) As Object

try
If Not System.IO.File.Exists(fileName) Then return null
//Open a file stream for input.
Dim fs As System.IO.FileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open)
// Create a SOAP formatter for this stream.
Dim sf As new System.Runtime.Serialization.Formatters.Soap.SoapFormatter(null, new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.File))

// Deserialize the contents of the file stream into an object.
LoadSoapFromFile = sf.Deserialize(fs)
// close the stream.
fs.Close()
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function CloneObject(ByVal obj As Object) As Object

try
// Create a memory stream and a formatter.
Dim ms As new System.IO.MemoryStream(1000)
Dim bf As New BinaryFormatter(null, New StreamingContext(StreamingContextStates.Clone))
// Serialize the object into the stream.
bf.Serialize(ms, obj)
// Position streem pointer back to first byte.
ms.Seek(0, SeekOrigin.Begin)
// Deserialize into another object.
CloneObject = bf.Deserialize(ms)
// release memory.
ms.Close()
} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function ObjectToXML(ByVal obj As Object) As String

try
// Create a memory stream and a formatter.
Dim ms As new System.IO.MemoryStream(1000)
Dim sf As new System.Runtime.Serialization.Formatters.Soap.SoapFormatter(null, New StreamingContext(StreamingContextStates.Clone))
// Serialize the object into the stream.
sf.Serialize(ms, obj)
// Position stream pointer back to first byte.
ms.Seek(0, SeekOrigin.Begin)
Dim arr As Array = Array.CreateInstance(GetType(Byte), CInt(ms.Length))
ms.Read(CType(arr, Byte()), 0, CInt(ms.Length))
Dim byteArr() As Byte = ms.ToArray()
Dim ii As Integer
Dim retval As String
For ii = 0 To UBound(byteArr)
retval &= Chr(byteArr(ii))
}
// release memory.
ms.Close()
return retval

} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public Function XMLToObject(ByVal xml As String) As Object


try
Dim retval As Object

// Create a memory stream and a formatter.
Dim ms As new System.IO.MemoryStream(1000)
Dim sf As new System.Runtime.Serialization.Formatters.Soap.SoapFormatter(null, New StreamingContext(StreamingContextStates.Clone))

Dim arr As Array = Array.CreateInstance(GetType(Byte), xml.Length)
Dim charArr() As Char = xml.ToCharArray()
Dim byteArr(xml.Length) As Byte

Dim ii As Integer
Dim S As String
For ii = 0 To xml.Length - 1
byteArr(ii) = CByte(Asc(charArr(ii)))
S &= Chr(byteArr(ii))
}

ms.Write(byteArr, 0, xml.Length)
ms.Seek(0, SeekOrigin.Begin)

retval = sf.Deserialize(ms)

// release memory.
ms.Close()
return retval

} catch (Exception ex) {
Globals.SetErr(ex);
}

}

public void SetErr(ByVal ex As Exception)
On Error Resume }
MessageBox.Show(ex.ToString, MsgBoxStyle.Information)
}

End Module
