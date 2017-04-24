Option Strict On
Option Explicit On 

Imports System.Drawing

Namespace Objects

  Public Enum ScheduleDisplayConstants
    Day01 = 1
    Day05 = 2
    Day07 = 3
    Day31 = 4
  End Enum

  <Serializable()> _
  Public Class Preferences

    'Property Defaults
    Private ReadOnly m_def_BackColor As Color = Color.White
    Private ReadOnly m_def_ScheduleDisplay As ScheduleDisplayConstants = ScheduleDisplayConstants.Day05

    'Property Variables
    Private m_BackColor As Color = m_BackColor
    Private m_ScheduleDisplay As ScheduleDisplayConstants
    Private m_PracticeInfo As New PracticeInfo()

    Public Sub New()
      m_BackColor = m_def_BackColor
      m_ScheduleDisplay = m_def_ScheduleDisplay
    End Sub

#Region "Property Implementations"

    Public Property BackColor() As Color
      Get
        Return m_BackColor
      End Get
      Set(ByVal Value As Color)
        m_BackColor = Value
      End Set
    End Property

    Public Property ScheduleDisplay() As ScheduleDisplayConstants
      Get
        Return m_ScheduleDisplay
      End Get
      Set(ByVal Value As ScheduleDisplayConstants)
        m_ScheduleDisplay = Value
      End Set
    End Property

    <System.ComponentModel.Browsable(False)> _
    Public ReadOnly Property PracticeInfo() As PracticeInfo
      Get
        Return m_PracticeInfo
      End Get
    End Property

#End Region

  End Class

End Namespace