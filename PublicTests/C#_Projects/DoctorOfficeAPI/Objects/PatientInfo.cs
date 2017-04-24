Option Strict On
Option Explicit On 

namespace Objects

[Serializable()]
public class PracticeInfo

Private m_Name As String
Private m_Address As String

public Property Name() As String
Get
return m_Name
End Get
Set(ByVal Value As String)
m_Name = Value
End Set
End Property

public Property Address() As String
Get
return m_Address
End Get
Set(ByVal Value As String)
m_Address = Value
End Set
End Property

}

}