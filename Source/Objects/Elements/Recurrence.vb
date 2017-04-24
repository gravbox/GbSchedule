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

Namespace Gravitybox.Objects

  Public Enum RecurrenceIntervalConstants As Integer
		Daily = 1
		Weekly = 2
		Monthly = 3
		Yearly = 4
  End Enum

  Public Enum RecurrenceEndConstants As Integer
		EndByInterval = 2
		EndByDate = 3
  End Enum

	<Serializable(), _
	DefaultEvent("Refresh")> _
	Public Class Recurrence
		Inherits BaseObject
		Implements System.Runtime.Serialization.IDeserializationCallback

#Region "Class Members"

		'Private Constants
		Friend Const MyXMLNodeName As String = "recurrence"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"
		Friend Const RecurrenceNumericMinimum As Integer = 1
    Friend Const RecurrenceNumericMaximum As Integer = 999
    Friend Const m_def_CheckOnly As Boolean = False

		'Private Member Constants
		Private m_RecurrenceInterval As RecurrenceIntervalConstants
		Private m_StartDate As DateTime
		Private m_EndType As RecurrenceEndConstants
		Private m_EndIterations As Integer
		Private m_EndDate As DateTime
		Private m_RecurrenceDay As RecurrenceDay
		Private m_RecurrenceWeek As RecurrenceWeek
		Private m_RecurrenceMonth As RecurrenceMonth
		Private m_RecurrenceYear As RecurrenceYear
		Private m_LastCreateDate As DateTime
		Private m_LastCreateGroupId As String = ""
    Private m_CheckOnly As Boolean = m_def_CheckOnly
		<NonSerialized()> Private m_Parent As RecurrenceCollection

#End Region

#Region "Constructor"

		Public Sub New()
			Me.New(Guid.NewGuid.ToString)
		End Sub

		Public Sub New(ByVal key As String)
			MyBase.New(key, "")
			Try
				m_RecurrenceDay = New RecurrenceDay
				m_RecurrenceWeek = New RecurrenceWeek
				m_RecurrenceMonth = New RecurrenceMonth
				m_RecurrenceYear = New RecurrenceYear
				RecurrenceDay.Parent = Me
				RecurrenceWeek.Parent = Me
				RecurrenceMonth.Parent = Me
				RecurrenceYear.Parent = Me
				m_RecurrenceInterval = RecurrenceIntervalConstants.Daily
				m_StartDate = GetDate(Now)
				m_EndDate = DateAdd(DateInterval.Year, 1, GetDate(Now))
				m_EndType = RecurrenceEndConstants.EndByDate
				m_CheckOnly = False
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "SetParent"

		'Internal method to set the parent pointer
		Friend Sub SetParent(ByVal NewParent As RecurrenceCollection)
			m_Parent = NewParent
		End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.Recurrence
				element.FromXML(Me.ToXML)
				element.SetKey(Guid.NewGuid.ToString)
				Return element
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

#End Region

#Region "Property Implementations"

		Friend Property Parent() As RecurrenceCollection
			Get
				Return m_Parent
			End Get
			Set(ByVal Value As RecurrenceCollection)
				m_Parent = Value
			End Set
		End Property

    ''' <summary>
    ''' Determines if the object is being used for checking only or will be used to really add recurrences to the AppointmentCollection.
    ''' </summary>
    <Browsable(True), _
    DefaultValue(m_def_CheckOnly)> _
    Public Property CheckOnly() As Boolean
      Get
        Return m_CheckOnly
      End Get
      Set(ByVal Value As Boolean)
        If m_CheckOnly <> Value Then
          m_CheckOnly = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

		Friend Property LastCreateGroupId() As String
			Get
				Return m_LastCreateGroupId
			End Get
			Set(ByVal Value As String)
				m_LastCreateGroupId = Value
			End Set
		End Property

    ''' <summary>
    ''' Determines the last date an appointment was created on for this recurrence pattern.
    ''' </summary>
    <Browsable(True)> _
    Public Property LastCreateDate() As DateTime
      Get
        Return m_LastCreateDate
      End Get
      Set(ByVal Value As DateTime)
        If m_LastCreateDate <> Value Then
          m_LastCreateDate = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the number of appointments that will be created from this recurrence pattern.
    ''' </summary>
    <Browsable(True)> _
    Public Property EndIterations() As Integer
      Get
        Return m_EndIterations
      End Get
      Set(ByVal Value As Integer)
        If (Value < 1) Then Value = 1
        If m_EndIterations <> Value Then
          m_EndIterations = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the date on which to end the creating recurrences.
    ''' </summary>
    <Browsable(True)> _
    Public Property EndDate() As DateTime
      Get
        Return m_EndDate
      End Get
      Set(ByVal Value As DateTime)
        'If the End Date for the range is less than
        'the Startdate then add a year
        Value = GetDate(Value)
        If (Value < StartDate) Then
          Value = DateAdd(DateInterval.Year, 1, StartDate)
        End If

        If Not m_EndDate.Equals(Value) Then
          m_EndDate = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If

      End Set
    End Property

    ''' <summary>
    ''' A sub-object that defines details for a daily recurrence pattern
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property RecurrenceDay() As RecurrenceDay
      Get
        Return m_RecurrenceDay
      End Get
    End Property

    ''' <summary>
    ''' A sub-object that defines details for a weekly recurrence pattern
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property RecurrenceWeek() As RecurrenceWeek
      Get
        Return m_RecurrenceWeek
      End Get
    End Property

    ''' <summary>
    ''' A sub-object that defines details for a monthly recurrence pattern
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property RecurrenceMonth() As RecurrenceMonth
      Get
        Return m_RecurrenceMonth
      End Get
    End Property

    ''' <summary>
    ''' A sub-object that defines details for a yearly recurrence pattern
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property RecurrenceYear() As RecurrenceYear
      Get
        Return m_RecurrenceYear
      End Get
    End Property

    ''' <summary>
    ''' Determines the type of recurrence: Day, Week, Month, Year.
    ''' </summary>
    <Browsable(True)> _
    Public Property RecurrenceInterval() As RecurrenceIntervalConstants
      Get
        Return m_RecurrenceInterval
      End Get
      Set(ByVal Value As RecurrenceIntervalConstants)
        If m_RecurrenceInterval <> Value Then
          m_RecurrenceInterval = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the starting date of the recurrence pattern.
    ''' </summary>
    <Browsable(True)> _
    Public Property StartDate() As DateTime
      Get
        Return GetDate(m_StartDate)
      End Get
      Set(ByVal Value As DateTime)
        Value = GetDate(Value)
        If Not m_StartDate.Equals(Value) Then
          m_StartDate = Value
          'If the End Date for the range is less than
          'the Startdate then add a year
          If (EndDate < StartDate) Then
            EndDate = DateAdd(DateInterval.Year, 1, StartDate)
          End If
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines what type of data will end the pattern: date or interval.
    ''' </summary>
    <Browsable(True)> _
    Public Property EndType() As RecurrenceEndConstants
      Get
        Return m_EndType
      End Get
      Set(ByVal Value As RecurrenceEndConstants)
        If m_EndType <> Value Then
          m_EndType = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

#End Region

#Region "IsValid"

		Public Function IsValid() As Boolean

			Try

				'This method checks to determine if
				'this object is in a valid state

        'Make sure that the respective object are vlaid
				Select Case Me.RecurrenceInterval
					Case RecurrenceIntervalConstants.Daily : If Not RecurrenceDay.IsValid Then Return False
					Case RecurrenceIntervalConstants.Weekly : If Not RecurrenceWeek.IsValid Then Return False
					Case RecurrenceIntervalConstants.Monthly : If Not RecurrenceMonth.IsValid Then Return False
				End Select
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Index"

		<Browsable(False)> _
		Friend Property Index() As Integer
			Get
				Dim element As Recurrence
				Dim ii As Integer = 0
				If Parent Is Nothing Then Return -1

				Try
					For Each element In Parent
						If element Is Me Then
							Return ii
						End If
						ii += 1
					Next
					Return -1
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Get
			Set(ByVal Value As Integer)
				Dim ii As Integer
				Dim MyParent As RecurrenceCollection
				If Parent Is Nothing Then
					Throw New Exceptions.GravityboxException(ErrorStringNoParentIndex)
				End If

				Try
					'Get the index of the specified item
					ii = Me.Index
					If ii >= 0 Then
						MyParent = Me.Parent
						Call MyParent.RemoveAt(ii)
						Call MyParent.AddObject(Me, Value)
					End If
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

#End Region

#Region "OnDeserialization"

		Private Sub OnDeserialization(ByVal sender As Object) Implements System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
			Try
				Me.RecurrenceDay.Parent = Me
				Me.RecurrenceWeek.Parent = Me
				Me.RecurrenceMonth.Parent = Me
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the object to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement
      Dim elemNew As Xml.XmlNode

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Save the properties for this object
        Call xmlHelper.addElement(parentNode, "enddate", DateToLong(GetDate(m_EndDate)).ToString)
        Call xmlHelper.addElement(parentNode, "enditerations", m_EndIterations.ToString)
        Call xmlHelper.addElement(parentNode, "endtype", GetIntlInteger(m_EndType).ToString)
        Call xmlHelper.addElement(parentNode, "lastcreatedate", DateToLong(GetDate(m_LastCreateDate)).ToString)
        Call xmlHelper.addElement(parentNode, "recurrenceinterval", GetIntlInteger(m_RecurrenceInterval).ToString)
        Call xmlHelper.addElement(parentNode, "startdate", DateToLong(GetDate(m_StartDate)).ToString)
        Call xmlHelper.addElement(parentNode, "lastcreategroupid", m_LastCreateGroupId)

        'Save the sub-objects for this object
        elemNew = CType(xmlHelper.addElement(parentNode, RecurrenceDay.MyXMLNodeName, ""), Xml.XmlElement)
        elemNew.InnerXml = Me.RecurrenceDay.ToXML
        elemNew = CType(xmlHelper.addElement(parentNode, RecurrenceWeek.MyXMLNodeName, ""), Xml.XmlElement)
        elemNew.InnerXml = Me.RecurrenceWeek.ToXML
        elemNew = CType(xmlHelper.addElement(parentNode, RecurrenceMonth.MyXMLNodeName, ""), Xml.XmlElement)
        elemNew.InnerXml = Me.RecurrenceMonth.ToXML
        elemNew = CType(xmlHelper.addElement(parentNode, RecurrenceYear.MyXMLNodeName, ""), Xml.XmlElement)
        elemNew.InnerXml = Me.RecurrenceYear.ToXML

        'PropertyItemCollection
        elemNew = xmlHelper.addElement(parentNode, PropertyItemCollection.MyXMLNodeName, "")
        elemNew.InnerXml = PropertyItemCollection.XmlNode.InnerXml

        'Return the XML string
        Return parentNode.OuterXml

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean
      Return FromXML(xml, False, False)
    End Function

		Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean

			Dim XMLDoc As New xml.XmlDocument

			Try

				'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				m_EndDate = LongToDate(GetNodeValue(XMLDoc, startXPath & "enddate", DateToLong(GetDate(m_EndDate)).ToString))
				m_EndIterations = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "enditerations", m_EndIterations.ToString))
				m_EndType = CType([Enum].Parse(GetType(RecurrenceEndConstants), GetNodeValue(XMLDoc, startXPath & "endtype", m_EndType.ToString("d"))), RecurrenceEndConstants)
				m_LastCreateDate = LongToDate(GetNodeValue(XMLDoc, startXPath & "lastcreatedate", DateToLong(GetDate(m_LastCreateDate)).ToString))
				m_RecurrenceInterval = CType([Enum].Parse(GetType(RecurrenceIntervalConstants), GetNodeValue(XMLDoc, startXPath & "recurrenceinterval", m_RecurrenceInterval.ToString("d"))), RecurrenceIntervalConstants)
				m_StartDate = LongToDate(GetNodeValue(XMLDoc, startXPath & "startdate", DateToLong(GetDate(m_StartDate)).ToString))
				m_LastCreateGroupId = GetNodeValue(XMLDoc, startXPath & "lastcreategroupid", m_LastCreateGroupId)

				'Save the sub-objects for this object
        Me.RecurrenceDay.FromXML(GetNodeXML(XMLDoc, startXPath & RecurrenceDay.MyXMLNodeName, ""))
        Me.RecurrenceWeek.FromXML(GetNodeXML(XMLDoc, startXPath & RecurrenceWeek.MyXMLNodeName, ""))
        Me.RecurrenceMonth.FromXML(GetNodeXML(XMLDoc, startXPath & RecurrenceMonth.MyXMLNodeName, ""))
        Me.RecurrenceYear.FromXML(GetNodeXML(XMLDoc, startXPath & RecurrenceYear.MyXMLNodeName, ""))

				If Not shallow Then
					'Objects
					PropertyItemCollection.Clear()
					PropertyItemCollection.FromXML(GetNodeXML(XMLDoc, startXPath & PropertyItemCollection.MyXMLNodeName, "", True))
				End If

				If Not cancelEvents Then
					OnReload(Me, New System.EventArgs)
					OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
				End If
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overloads Overrides Function LoadXML(ByVal fileName As String) As Boolean
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