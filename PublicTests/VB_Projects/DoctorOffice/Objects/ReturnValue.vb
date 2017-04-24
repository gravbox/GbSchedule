Option Strict On
Option Explicit On 

Public Class ReturnValue

  Private m_Setting As Object

  Public Property Setting() As Object
    Get
      Return m_Setting
    End Get
    Set(ByVal Value As Object)
      m_Setting = Value
    End Set
  End Property

End Class
