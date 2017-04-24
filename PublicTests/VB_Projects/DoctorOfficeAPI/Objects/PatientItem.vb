Option Strict On
Option Explicit On 

Namespace Objects

  <Serializable()> _
  Public Class PatientItem
    Implements ICloneable

    'Private Member Variables
    Private m_Key As String
    <NonSerialized()> Private m_Parent As PatientCollection
    Private m_Text As String
    Private m_Notes As String
    Private m_Account As String
    Private m_AquiredDate As Date
    Private m_FName As String
    Private m_LName As String
    Private m_Address As String
    Private m_City As String
    Private m_State As String
    Private m_Zip As String
    Private m_PhoneHome As String
    Private m_PhoneBusiness As String
    Private m_PhoneMobile As String
    Private m_Email As String
    Private m_BirthDate As Date
    Private m_LastRecall As Date
    Private m_Physician As String
    Private m_SSN As String

    'This is the index of this object in its parent 
    <System.ComponentModel.Browsable(False)> _
    Public Property Index() As Integer
      Get
        Dim Element As PatientItem
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
        Dim MyParent As PatientCollection

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
    Public ReadOnly Property Parent() As PatientCollection
      Get
        Return m_Parent
      End Get
    End Property

    'Internal method to set the parent pointer
    Friend Sub SetParent(ByVal NewParent As PatientCollection)
      m_Parent = NewParent
    End Sub

    'Override constructor so that this object not publically creatable
    Friend Sub New()
      m_Key = Guid.NewGuid.ToString
      m_AquiredDate = Date.Parse(Now.ToShortDateString)
      m_BirthDate = Date.Parse(Now.ToShortDateString)
      m_LastRecall = Date.Parse(Now.ToShortDateString)
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
      Dim element As PatientItem = DirectCast(CloneObject(Me), PatientItem)
      Call element.SetParent(Nothing)
      Call element.SetKey(Guid.NewGuid.ToString)
      Return element
    End Function

#Region "Property Implementation"

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

    Public Property Account() As String
      Get
        Return m_Account
      End Get
      Set(ByVal Value As String)
        m_Account = Value
      End Set
    End Property

    Public Property AquiredDate() As Date
      Get
        Return m_AquiredDate
      End Get
      Set(ByVal Value As Date)
        m_AquiredDate = Value
      End Set
    End Property

    Public Property FName() As String
      Get
        Return m_FName
      End Get
      Set(ByVal Value As String)
        m_FName = Value
      End Set
    End Property

    Public Property LName() As String
      Get
        Return m_LName
      End Get
      Set(ByVal Value As String)
        m_LName = Value
      End Set
    End Property

    Public Property Address() As String
      Get
        Return m_Address
      End Get
      Set(ByVal Value As String)
        m_Address = Value
      End Set
    End Property

    Public Property City() As String
      Get
        Return m_City
      End Get
      Set(ByVal Value As String)
        m_City = Value
      End Set
    End Property

    Public Property State() As String
      Get
        Return m_State
      End Get
      Set(ByVal Value As String)
        m_State = Value
      End Set
    End Property

    Public Property Zip() As String
      Get
        Return m_Zip
      End Get
      Set(ByVal Value As String)
        m_Zip = Value
      End Set
    End Property

    Public Property PhoneHome() As String
      Get
        Return m_PhoneHome
      End Get
      Set(ByVal Value As String)
        m_PhoneHome = Value
      End Set
    End Property

    Public Property PhoneBusiness() As String
      Get
        Return m_PhoneBusiness
      End Get
      Set(ByVal Value As String)
        m_PhoneBusiness = Value
      End Set
    End Property

    Public Property PhoneMobile() As String
      Get
        Return m_PhoneMobile
      End Get
      Set(ByVal Value As String)
        m_PhoneMobile = Value
      End Set
    End Property

    Public Property Email() As String
      Get
        Return m_Email
      End Get
      Set(ByVal Value As String)
        m_Email = Value
      End Set
    End Property

    Public Property BirthDate() As Date
      Get
        Return m_BirthDate
      End Get
      Set(ByVal Value As Date)
        m_BirthDate = Value
      End Set
    End Property

    Public Property LastRecall() As Date
      Get
        Return m_LastRecall
      End Get
      Set(ByVal Value As Date)
        m_LastRecall = Value
      End Set
    End Property

    Public Property Physician() As String
      Get
        Return m_Physician
      End Get
      Set(ByVal Value As String)
        m_Physician = Value
      End Set
    End Property

    Public Property SSN() As String
      Get
        Return m_SSN
      End Get
      Set(ByVal Value As String)
        m_SSN = Value
      End Set
    End Property

#End Region

  End Class

End Namespace