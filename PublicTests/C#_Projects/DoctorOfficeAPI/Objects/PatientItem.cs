Option Strict On
Option Explicit On 

namespace Objects

[Serializable()]
public class PatientItem
Implements ICloneable

//Private Member Variables
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
Private m_LastReAs Date
Private m_Physician As String
Private m_SSN As String

//This is the index of this object in its parent 
<System.ComponentModel.Browsable(false)> _
public Property Index() As Integer
Get
Dim Element As PatientItem
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
Dim MyParent As PatientCollection

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
public readonly Property Parent() As PatientCollection
Get
return m_Parent
End Get
End Property

//Internal method to set the parent pointer
Fri} SetParent(ByVal NewParent As PatientCollection)
m_Parent = NewParent
}

//Override constructor so that this object not publically creatable
Fri} New()
m_Key = Guid.NewGuid.ToString
m_AquiredDate = Date.Parse(Now.ToShortDateString)
m_BirthDate = Date.Parse(Now.ToShortDateString)
m_LastRe= Date.Parse(Now.ToShortDateString)
}

public Function Clone() As Object Implements System.ICloneable.Clone
Dim element As PatientItem = DirectCast(CloneObject(Me), PatientItem)
element.SetParent(null)
element.SetKey(Guid.NewGuid.ToString)
return element
}

#region Property Implementation"

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

public Property Account() As String
Get
return m_Account
End Get
Set(ByVal Value As String)
m_Account = Value
End Set
End Property

public Property AquiredDate() As Date
Get
return m_AquiredDate
End Get
Set(ByVal Value As Date)
m_AquiredDate = Value
End Set
End Property

public Property FName() As String
Get
return m_FName
End Get
Set(ByVal Value As String)
m_FName = Value
End Set
End Property

public Property LName() As String
Get
return m_LName
End Get
Set(ByVal Value As String)
m_LName = Value
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

public Property City() As String
Get
return m_City
End Get
Set(ByVal Value As String)
m_City = Value
End Set
End Property

public Property State() As String
Get
return m_State
End Get
Set(ByVal Value As String)
m_State = Value
End Set
End Property

public Property Zip() As String
Get
return m_Zip
End Get
Set(ByVal Value As String)
m_Zip = Value
End Set
End Property

public Property PhoneHome() As String
Get
return m_PhoneHome
End Get
Set(ByVal Value As String)
m_PhoneHome = Value
End Set
End Property

public Property PhoneBusiness() As String
Get
return m_PhoneBusiness
End Get
Set(ByVal Value As String)
m_PhoneBusiness = Value
End Set
End Property

public Property PhoneMobile() As String
Get
return m_PhoneMobile
End Get
Set(ByVal Value As String)
m_PhoneMobile = Value
End Set
End Property

public Property Email() As String
Get
return m_Email
End Get
Set(ByVal Value As String)
m_Email = Value
End Set
End Property

public Property BirthDate() As Date
Get
return m_BirthDate
End Get
Set(ByVal Value As Date)
m_BirthDate = Value
End Set
End Property

public Property LastRecall() As Date
Get
return m_LastRecall
End Get
Set(ByVal Value As Date)
m_LastRe= Value
End Set
End Property

public Property Physician() As String
Get
return m_Physician
End Get
Set(ByVal Value As String)
m_Physician = Value
End Set
End Property

public Property SSN() As String
Get
return m_SSN
End Get
Set(ByVal Value As String)
m_SSN = Value
End Set
End Property

#endregion

}

}