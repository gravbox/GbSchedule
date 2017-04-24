Option Strict On
Option Explicit On 

Namespace Objects

  <Serializable()> _
  Public Class CourseItem

    'Private Member Constants
    Private m_Key As String
    Private m_Text As String
    Private m_Notes As String
    <NonSerialized()> Private m_Parent As CourseItems

    'Internal method to set the parent pointer
    Friend Sub SetParent(ByVal NewParent As CourseItems)
      m_Parent = NewParent
    End Sub

    Friend Sub SetKey(ByVal value As String)
      m_Key = value
    End Sub

    'This is the index of this object in its parent 
    <System.ComponentModel.Browsable(False)> _
    Public Property Index() As Integer
      Get
        Dim element As CourseItem
        Dim ii As Integer = 0
        If Parent Is Nothing Then Return -1

        Try
          For Each element In Parent
            If element Is Me Then
              Return ii
            End If
            ii += 1
          Next
          Return -1
        Catch ex As Exception
          Call SetErr(ex)
        End Try

      End Get
      Set(ByVal Value As Integer)
        Dim ii As Integer
        Dim MyParent As CourseItems
        If Parent Is Nothing Then
          Throw New Exception(ErrorStringNoParentIndex)
        End If

        Try
          'Get the index of the specified item
          ii = Me.Index
          If ii >= 0 Then
            MyParent = Me.Parent
            Call MyParent.RemoveAt(ii)
            Call MyParent.AddObject(Me, Value)
          End If
        Catch ex As Exception
          Call SetErr(ex)
        End Try
      End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
    Public Property Key() As String
      Get
        Return m_Key
      End Get
      Set(ByVal Value As String)
        If Value = "" Then
          Throw New Exception(ErrorStringNoKey)
        End If
        'If there is no parent then there is nothign to do
        If Parent Is Nothing Then
          Throw New Exception(ErrorStringNoParentIndex)
        End If
        'If this is the same key then there is nothing to do
        If m_Key.Equals(Value) Then Return
        'If this key exists in the parent collection then this is an error
        If Parent.Exists(Value) Then
          Throw New Exception(ErrorStringDuplicateKeyObject)
        End If
        m_Key = Value
      End Set
    End Property

    'The Parent Pointer
    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property Parent() As CourseItems
      Get
        Return m_Parent
      End Get
    End Property

    'Override constructor so that this object not publically creatable
    Friend Sub New()
      Call SetKey(Guid.NewGuid.ToString)
    End Sub

    Public Function Clone() As CourseItem
      Try
        Dim element As CourseItem = DirectCast(CloneObject(Me), CourseItem)
        Call element.SetParent(Nothing)
        Call element.SetKey(Guid.NewGuid.ToString)
        Return element
      Catch ex As Exception
        Call SetErr(ex)
      End Try
    End Function

    Public Property Text() As String
      Get
        Return m_Text
      End Get
      Set(ByVal Value As String)
        m_Text = Value
      End Set
    End Property

    Public Property Notes() As String
      Get
        Return m_Notes
      End Get
      Set(ByVal Value As String)
        m_Notes = Value
      End Set
    End Property

    Public Shadows Function ToString() As String

      Try
        Return Me.Text
      Catch ex As Exception
        Call SetErr(ex)
      End Try

    End Function

  End Class

End Namespace
