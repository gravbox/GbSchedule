Option Strict On
Option Explicit On 

Namespace Objects

  <Serializable()> _
  Public Class LoginItem
    Implements ICloneable

    'Private Member Variables
    Private m_Key As String
    <NonSerialized()> Private m_Parent As LoginCollection
    Private m_Text As String
    Private m_Notes As String

    'This is the index of this object in its parent 
    <System.ComponentModel.Browsable(False)> _
    Public Property Index() As Integer
      Get
        Dim Element As LoginItem
        Dim ii As Integer = 0

        Try
          For Each Element In Parent
            If Element Is Me Then
              Return ii
            End If
            ii += 1
          Next
        Catch
          Throw
        End Try
        Return 0

      End Get
      Set(ByVal Value As Integer)
        Dim ii As Integer
        Dim MyParent As LoginCollection

        Try
          'Get the index of the specified item
          ii = Me.Index
          If ii > 0 Then
            MyParent = Me.Parent
            Call MyParent.RemoveAt(ii)
            Call MyParent.AddObject(Me, Value)
          End If
        Catch
          Throw
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
        If Parent.Contains(Value) Then
          Throw New Exception(ErrorStringDuplicateKeyObject)
        End If
        m_Key = Value
      End Set
    End Property

    Friend Sub SetKey(ByVal value As String)
      m_Key = value
    End Sub

    'The Parent Pointer
    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property Parent() As LoginCollection
      Get
        Return m_Parent
      End Get
    End Property

    'Internal method to set the parent pointer
    Friend Sub SetParent(ByVal NewParent As LoginCollection)
      m_Parent = NewParent
    End Sub

    'Override constructor so that this object not publically creatable
    Friend Sub New()
      m_Key = Guid.NewGuid.ToString
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim element As LoginItem = DirectCast(CloneObject(Me), LoginItem)
      Call element.SetParent(Nothing)
      Call element.SetKey(Guid.NewGuid.ToString)
      Return element
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

  End Class

End Namespace