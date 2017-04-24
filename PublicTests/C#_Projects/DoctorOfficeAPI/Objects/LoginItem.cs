Option Strict On
Option Explicit On 

namespace Objects

[Serializable()]
public class LoginItem
Implements ICloneable

//Private Member Variables
Private m_Key As String
<NonSerialized()> Private m_Parent As LoginCollection
Private m_Text As String
Private m_Notes As String

//This is the index of this object in its parent 
<System.ComponentModel.Browsable(false)> _
public Property Index() As Integer
Get
Dim Element As LoginItem
Dim ii As Integer = 0

try
foreach Element In Parent
If Element Is Me Then
return ii
}
ii += 1
}
Catch
Throw
}
return 0

End Get
Set(ByVal Value As Integer)
Dim ii As Integer
Dim MyParent As LoginCollection

try
//Get the index of the specified item
ii = Me.Index
If ii > 0 Then
MyParent = Me.Parent
MyParent.RemoveAt(ii)
MyParent.AddObject(Me, Value)
}
Catch
Throw
}
End Set
End Property

<System.ComponentModel.Browsable(false)> _
public Property Key() As String
Get
return m_Key
End Get
Set(ByVal Value As String)
If Value = "" Then
throw new Exception(ErrorStringNoKey)
}
//If there is no parent then there is nothign to do
If Parent == null Then
throw new Exception(ErrorStringNoParentIndex)
}
//If this is the same key then there == null to do
If m_Key.Equals(Value) Then Return
//If this key exists in the parent collection then this is an error
If Parent.Contains(Value) Then
throw new Exception(ErrorStringDuplicateKeyObject)
}
m_Key = Value
End Set
End Property

Fri} SetKey(ByVal value As String)
m_Key = value
}

//The Parent Pointer
<System.ComponentModel.Browsable(false)> _
public readonly Property Parent() As LoginCollection
Get
return m_Parent
End Get
End Property

//Internal method to set the parent pointer
Fri} SetParent(ByVal NewParent As LoginCollection)
m_Parent = NewParent
}

//Override constructor so that this object not publically creatable
Fri} New()
m_Key = Guid.NewGuid.ToString
}

public Function Clone() As Object Implements System.ICloneable.Clone
Dim element As LoginItem = DirectCast(CloneObject(Me), LoginItem)
element.SetParent(null)
element.SetKey(Guid.NewGuid.ToString)
return element
}

public Property Text() As String
Get
return m_Text
End Get
Set(ByVal Value As String)
m_Text = Value
End Set
End Property

public Property Notes() As String
Get
return m_Notes
End Get
Set(ByVal Value As String)
m_Notes = Value
End Set
End Property

}

}