#Region "Copyright (c) 1998-2007 Gravitybox LLC, All Rights Reserved"
'--------------------------------------------------------------------- *
'                          Gravitybox  LLC                             *
'             Copyright (c) 1998-2007 All Rights reserved              *
'                                                                      *
'                                                                      *
'This file and its contents are protected by United States and         *
'International copyright laws.  Unauthorized reproduction and/or       *
'distribution of all or any portion of the code contained herein       *
'is strictly prohibited and will result in severe civil and criminal   *
'penalties.  Any violations of this copyright will be prosecuted       *
'to the fullest extent possible under law.                             *
'                                                                      *
'THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
'TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
'TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
'CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
'THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF Gravitybox LLC    *
'                                                                      *
'UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
'PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
'SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY GRAVITYBOX PRODUCT.      *
'                                                                      *
'THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
'CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF GRAVITYBOX,        *
'INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
'INSURE ITS CONFIDENTIALITY.                                           *
'                                                                      *
'THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
'PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
'EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
'THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
'SOURCE CODE CONTAINED HEREIN.                                         *
'                                                                      *
'THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
'--------------------------------------------------------------------- *
#End Region

Option Strict On
Option Explicit On 

Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization

Namespace Gravitybox.Objects

  <Serializable(), _
  TypeConverter(GetType(Gravitybox.Design.Converters.AlarmItemConverter))> _
  Public Class AlarmItem
    Implements IXMLable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "alarm"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Property Constants
		Private Const m_def_WindowText As String = ""
		Private Const m_def_IsArmed As Boolean = False
		Private Const m_def_Reminder As Integer = 0
		Private Const m_def_AllowOpen As Boolean = True
		Private Const m_def_AllowSnooze As Boolean = True

    'Property Variables
    Private m_WindowText As String = m_def_WindowText
    Private m_IsArmed As Boolean = m_def_IsArmed
    Private m_Reminder As Integer = m_def_Reminder
    Private m_AllowOpen As Boolean = m_def_AllowOpen
    Private m_AllowSnooze As Boolean = m_def_AllowSnooze
    Private m_ApplicationName As String = ""
    Private m_ApplicationArgs As String = ""
		Private m_DueDisplayed As Boolean = False	 'The appointment due was already shown
    Private m_ReminderDisplayed As Boolean = False 'The appointment reminder was already shown for the set interval

    'Private Internal Object
    Private ParentAppointment As Appointment

    Public Event Reload As ReloadDelegate
    Public Event Refresh As RefreshDelegate

#End Region

#Region "On... Event Methods"

    Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Reload(sender, e)
    End Sub

    Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Refresh(sender, e)
    End Sub

#End Region

#Region "Constructor"

    'Constructor
    Friend Sub New(ByVal appointment As Appointment)
      ParentAppointment = appointment

      'Deafauts
      m_WindowText = m_def_WindowText
      m_IsArmed = m_def_IsArmed
      m_Reminder = m_def_Reminder
      m_AllowOpen = m_def_AllowOpen
      m_AllowSnooze = m_def_AllowSnooze

    End Sub

    Public Sub New(ByVal windowText As String, ByVal isArmed As Boolean, ByVal reminder As Integer, ByVal allowOpen As Boolean, ByVal allowSnooze As Boolean, ByVal applicationName As String, ByVal applicationArgs As String)
      m_WindowText = windowText
      m_IsArmed = isArmed
      m_Reminder = reminder
      m_AllowOpen = allowOpen
      m_AllowSnooze = allowSnooze
      m_ApplicationName = applicationName
      m_ApplicationArgs = applicationArgs
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the caption of the alarm window.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("windowtext"), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("Determines the caption of the alarm window.")> _
    Public Property WindowText() As String
      Get
        Return m_WindowText
      End Get
      Set(ByVal Value As String)
        If m_WindowText <> Value Then
          m_WindowText = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the alarm is set.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("isarmed"), _
    Category("Behavior"), _
    DefaultValue(m_def_IsArmed), _
    Description("Determines if the alarm is set.")> _
    Public Property IsArmed() As Boolean
      Get
        Return m_IsArmed
      End Get
      Set(ByVal Value As Boolean)
        If m_IsArmed <> Value Then
          m_IsArmed = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the number of minutes before an alarm to display a reminder. If this value is zero, there is no reminder.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("reminder"), _
    Category("Behavior"), _
    DefaultValue(0), _
    Description("Determines the number of minutes before an alarm to display a reminder. If this value is zero, there is no reminder.")> _
    Public Property Reminder() As Integer
      Get
        Return m_Reminder
      End Get
      Set(ByVal Value As Integer)
        If m_Reminder <> Value Then
          m_ReminderDisplayed = False 'Now show a different reminder
          m_Reminder = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user may open the appointment from the alarm dialog.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("allowopen"), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowOpen), _
    Description("Determines if the user may open the appointment from the alarm dialog.")> _
    Public Property AllowOpen() As Boolean
      Get
        Return m_AllowOpen
      End Get
      Set(ByVal Value As Boolean)
        If m_AllowOpen <> Value Then
          m_AllowOpen = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if a snooze button is displayed on the reminder dialog.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("allowsnooze"), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowSnooze), _
    Description("Determines if a snooze button is displayed on the reminder dialog.")> _
    Public Property AllowSnooze() As Boolean
      Get
        Return m_AllowSnooze
      End Get
      Set(ByVal Value As Boolean)
        If m_AllowSnooze <> Value Then
          m_AllowSnooze = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the application to be run when an alarm comes due.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("applicationname"), _
    Category("Behavior"), _
    DefaultValue(""), _
    Obsolete("The schedule component will no longer launch applications. You must build your own launch code in the 'BeforeAppointmentDue' event."), _
    Description("Determines the application to be run when an alarm comes due.")> _
    Public Property ApplicationName() As String
      Get
        Return m_ApplicationName
      End Get
      Set(ByVal Value As String)
        If m_ApplicationName <> Value Then
          m_ApplicationName = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the arguments to send to the application to be executed by the 'ApplicationName' property value.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("applicationargs"), _
    Category("Behavior"), _
    DefaultValue(""), _
    Obsolete("The schedule component will no longer launch applications. You must build your own launch code in the 'BeforeAppointmentDue' event."), _
    Description("Determines the arguments to send to the application to be executed by the 'ApplicationName' property value.")> _
    Public Property ApplicationArgs() As String
      Get
        Return m_ApplicationArgs
      End Get
      Set(ByVal Value As String)
        If m_ApplicationArgs <> Value Then
          m_ApplicationArgs = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the starting date of the alarm. This is the appointment' StartDate.
    ''' </summary>
    <Browsable(False), _
    Category("Appearance"), _
    Description("Determines the starting date of the alarm. This is the appointment' StartDate.")> _
    Public ReadOnly Property StartDate() As DateTime
      Get
        Return ParentAppointment.StartDate
      End Get
    End Property

    ''' <summary>
    ''' Determines the starting time of the alarm. This is the appointment's StartTime.
    ''' </summary>
    <Browsable(False), _
    Category("Appearance"), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("Determines the starting time of the alarm. This is the appointment's StartTime.")> _
    Public ReadOnly Property StartTime() As DateTime
      Get
        Return ParentAppointment.StartTime
      End Get
    End Property

		Friend ReadOnly Property ReminderDateTime() As DateTime
			Get
				Dim retval As DateTime = Date.Parse(Me.StartDate.ToShortDateString & " " & Me.StartTime.ToShortTimeString)
				retval = retval.Add(New TimeSpan(0, -Me.Reminder, 0))
				Return retval
			End Get
		End Property

		Friend Property DueDisplayed() As Boolean
			Get
				Return m_DueDisplayed
			End Get
			Set(ByVal Value As Boolean)
				m_DueDisplayed = Value
			End Set
		End Property

		Friend Property ReminderDisplayed() As Boolean
			Get
				Return m_ReminderDisplayed
			End Get
			Set(ByVal Value As Boolean)
				m_ReminderDisplayed = Value
			End Set
		End Property

#End Region

#Region "Clone"

    Friend Function CloneMe() As Object
      Try
        'Dim element As Object = CloneObject(Me)
        Dim element As New Gravitybox.Objects.IconItem
        element.FromXML(Me.ToXML)
        element.SetKey(Guid.NewGuid.ToString)
        Return element
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing
    End Function

#End Region

#Region "ToString"

    Public Overrides Function ToString() As String

      Try
        Return "Alarm"
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts this object to an XML string.
    ''' </summary>
    Public Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
      Return Me.XmlNode.OuterXml
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        If xml = "" Then Return False
        XMLDoc.InnerXml = xml

        'Load all properties
        m_WindowText = GetNodeValue(XMLDoc, startXPath & "windowtext", m_WindowText)
        m_IsArmed = CBool(GetNodeValue(XMLDoc, startXPath & "isarmed", m_IsArmed.ToString))
        m_Reminder = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "reminder", m_Reminder.ToString))
        m_AllowOpen = CBool(GetNodeValue(XMLDoc, startXPath & "allowopen", m_AllowOpen.ToString))
        m_AllowSnooze = CBool(GetNodeValue(XMLDoc, startXPath & "allowsnooze", m_AllowSnooze.ToString))
        m_ApplicationName = GetNodeValue(XMLDoc, startXPath & "applicationname", m_ApplicationName)
        m_ApplicationArgs = GetNodeValue(XMLDoc, startXPath & "applicationargs", m_ApplicationArgs)

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New System.EventArgs)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "windowtext", m_WindowText)
        Call xmlHelper.addElement(parentNode, "isarmed", m_IsArmed.ToString)
        Call xmlHelper.addElement(parentNode, "reminder", m_Reminder.ToString)
        Call xmlHelper.addElement(parentNode, "allowopen", m_AllowOpen.ToString)
        Call xmlHelper.addElement(parentNode, "allowsnooze", m_AllowSnooze.ToString)
        Call xmlHelper.addElement(parentNode, "applicationname", m_ApplicationName)
        Call xmlHelper.addElement(parentNode, "applicationargs", m_ApplicationArgs)

        'Return the XML string
        Return parentNode

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Saves the XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The file name to use when saving.</param>
    Public Function SaveXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.SaveXML
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Load this object from an XML file.
    ''' </summary>
    ''' <param name="fileName">The name of the file from which to load.</param>
    Public Function LoadXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.LoadXML
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

  End Class

End Namespace