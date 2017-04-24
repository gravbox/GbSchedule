Option Strict On
Option Explicit On 

Namespace Objects

  <Serializable()> _
  Public Class PracticeInfo

    Private m_Name As String
    Private m_Address As String

    Public Property Name() As String
      Get
        Return m_Name
      End Get
      Set(ByVal Value As String)
        m_Name = Value
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

  End Class

End Namespace