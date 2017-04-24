Option Strict On
Option Explicit On 

Namespace Objects

  <Serializable()> _
  Public Class CourseItems
    Inherits System.Collections.CollectionBase

    'Private constants needed for this object
    Private ReadOnly m_def_InitColor As Color = Color.Blue

#Region "Add Methods"

    Friend Function Add(ByVal key As String) As CourseItem
      Return Add(key, "", -1)
    End Function

    Public Function Add(ByVal key As String, ByVal index As Integer) As CourseItem
      Return Add(key, "", index)
    End Function

    Public Function Add(ByVal key As String, ByVal text As String) As CourseItem
      Return Add(key, text, -1)
    End Function

    Public Function Add(ByVal key As String, ByVal text As String, ByVal index As Integer) As CourseItem

      Dim newObject As New CourseItem()

      If key <> "" Then
        'Error check that the new key does not exist
        If Exists(key) Then
          Throw New Exception(ErrorStringDuplicateKeyCollection)
        End If
        Call newObject.SetKey(key)
      Else
        key = newObject.Key
      End If

      newObject.Text = text

      'Error Check
      key = Trim(key)
      If key = "" Then
        Throw New Exception(ErrorStringNoKey)
      ElseIf Exists(key) Then
        Throw New Exception(ErrorStringDuplicateKeyCollection)
      End If

      Try
        'Create the object and add it to the collections
        Call newObject.SetKey(key)
        Return AddObject(newObject, index)
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Friend Function AddObject(ByVal newObject As CourseItem) As CourseItem
      Return AddObject(newObject, -1)
    End Function

    Friend Function AddObject(ByVal newObject As CourseItem, ByVal index As Integer) As CourseItem

      'The object must be set and it must NOT have a parent
      If newObject Is Nothing Then Return Nothing
      If Not (newObject.Parent Is Nothing) Then
        Throw New Exception(ErrorStringObjectHasParent)
      End If

      If (index < -1) Or (index > Me.Count) Then
        'Subscript out of range
        Throw New System.ArgumentOutOfRangeException()
      End If

      If newObject.Key = "" Then newObject.Key = System.Guid.NewGuid().ToString

      Try
        Call newObject.SetParent(Me)
        If index = -1 Then
          MyBase.List.Add(newObject)
        Else
          MyBase.List.Insert(index, newObject)
        End If
      Catch ex As Exception
        Call SetErr(ex)
      End Try
      Call newObject.SetParent(Me)

      Return newObject

    End Function

#End Region

    'Implementation of Exists property
    Public Function Exists(ByVal key As String) As Boolean
      Dim element As CourseItem
      Try

        If IsNumeric(key) Then
          Return Exists(CInt(key))
        End If

        'Check the Key
        For Each element In Me
          If element.Key.Equals(key) Then
            Return True
          End If
        Next
        'Check the Text
        For Each element In Me
          If StrComp(element.Text, key, CompareMethod.Text) = 0 Then
            Return True
          End If
        Next
        Return False
      Catch ex As Exception
        Call SetErr(ex)
      End Try
    End Function

    Public Function Exists(ByVal index As Integer) As Boolean
      Return (0 <= index) AndAlso (index < Me.Count)
    End Function

    Public Function Exists(ByVal value As CourseItem) As Boolean
      Dim element As CourseItem
      Try
        For Each element In Me
          If element Is value Then
            Return True
          End If
        Next
        Return False
      Catch ex As Exception
        Call SetErr(ex)
      End Try
    End Function

    Default Public ReadOnly Property Item(ByVal key As String) As CourseItem
      Get
        Try
          Dim element As CourseItem

          If IsNumeric(key) Then
            Return Item(CInt(key))
          End If

          'Loop for Key
          For Each element In Me
            If element.Key.Equals(key) Then
              Return element
            End If
          Next
          'Loop for Text
          For Each element In Me
            If StrComp(element.Text, key, CompareMethod.Text) = 0 Then
              Return element
            End If
          Next
        Catch ex As Exception
          Call SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException()
      End Get
    End Property

    Default Public ReadOnly Property Item(ByVal index As Integer) As CourseItem
      Get
        Try
          If Exists(index) Then
            Return CType(MyBase.List(index), CourseItem)
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
        Dim element As CourseItem
        element = Item(index)

        Call element.SetParent(Nothing)
        Call MyBase.RemoveAt(index)
        Return True

      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Shadows Function RemoveAt(ByVal key As String) As Boolean

      Dim element As CourseItem

      Try
        element = Item(key)

        Call element.SetParent(Nothing)
        Call MyBase.RemoveAt(element.Index)
        Return True

      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Shadows Function RemoveAt(ByVal value As CourseItem) As Boolean

      'Make sure that is has a parent
      Dim index As Integer = value.Index
      If index = -1 Then Return False

      'Make sure it is in this collection
      If Not Exists(value) Then Return False

      'Remove the actial item
      Return RemoveAt(index)

    End Function

#Region "Array Methods"

    Public Function ToArray() As ArrayList

      Try
        Dim array As ArrayList = New ArrayList()
        Dim element As CourseItem
        For Each element In Me
          Call array.Add(element)
        Next
        Return array
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Sub FromArray(ByVal array As ArrayList)

      Try
        Dim o As Object
        Dim element As CourseItem
        For Each o In array
          element = CType(o, CourseItem)
          Call element.SetParent(Nothing)
          Call Me.AddObject(element)
        Next
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Sub

#End Region

#Region "XML"

    Public Function ToXML() As String

      Try
        Return ObjectToXML(Me.ToArray)
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Sub FromXML(ByVal xml As String)

      Try
        Call Me.Clear()
        Call Me.FromArray(CType(XMLToObject(xml), ArrayList))
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Sub

    Public Function SaveXML(ByVal fileName As String) As Boolean

      Try
        Return SaveXML(fileName, False)
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Function SaveXML(ByVal fileName As String, ByVal overWrite As Boolean) As Boolean

      Try

        'Check for existence and remove if necessary
        If System.IO.File.Exists(fileName) Then
          If overWrite Then
            Call System.IO.File.Delete(fileName)
          Else
            'Do NOT overwrite. There is nothing to do
            Return False
          End If
        End If

        Call SaveSoapToFile(fileName, Me.ToArray)
        Return True

      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

    Public Function LoadXML(ByVal fileName As String) As Boolean

      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromArray(CType(LoadSoapFromFile(fileName), ArrayList))
        End If
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function


#End Region

  End Class

End Namespace
