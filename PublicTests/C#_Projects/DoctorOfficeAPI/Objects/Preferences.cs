Option Strict On
Option Explicit On 

using System.Drawing

namespace Objects

public Enum ScheduleDisplayConstants
Day01 = 1
Day05 = 2
Day07 = 3
Day31 = 4
End Enum

[Serializable()]
public class Preferences

//Property Defaults
Private readonly m_def_BackColor As Color = Color.White
Private readonly m_def_ScheduleDisplay As ScheduleDisplayConstants = ScheduleDisplayConstants.Day05

//Property Variables
Private m_BackColor As Color = m_BackColor
Private m_ScheduleDisplay As ScheduleDisplayConstants
Private m_PracticeInfo As New PracticeInfo()

public void New()
m_BackColor = m_def_BackColor
m_ScheduleDisplay = m_def_ScheduleDisplay
}

#region Property Implementations"

public Property BackColor() As Color
Get
return m_BackColor
End Get
Set(ByVal Value As Color)
m_BackColor = Value
End Set
End Property

public Property ScheduleDisplay() As ScheduleDisplayConstants
Get
return m_ScheduleDisplay
End Get
Set(ByVal Value As ScheduleDisplayConstants)
m_ScheduleDisplay = Value
End Set
End Property

<System.ComponentModel.Browsable(false)> _
public readonly Property PracticeInfo() As PracticeInfo
Get
return m_PracticeInfo
End Get
End Property

#endregion

}

}