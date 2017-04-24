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

#Region "Enumerations"

	Public Enum RecurrenceSubTypeConstants As Integer
		Interval = 1
		Ordinal = 2
	End Enum

	Public Enum RecurrenceOrdinalConstants As Integer
		First = 1
		Second = 2
		Third = 3
		Fourth = 4
		Last = 5
	End Enum

	Public Enum RecurrenceOrdinalDayConstants As Integer
		Day = 0
		Weekday = 1
		WeekendDay = 2
		Sunday = 3
		Monday = 4
		Tuesday = 5
		Wednesday = 6
		Thursday = 7
		Friday = 8
		Saturday = 9
	End Enum

#End Region

	<Serializable()> _
	Public Class RecurrenceMonth

#Region "Class Members"

		'Private Constants
		Friend Const MyXMLNodeName As String = "recurrencemonth"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		'Private Member Variables
		Private Const m_def_RecurrenceMode As RecurrenceSubTypeConstants = RecurrenceSubTypeConstants.Interval
		Private Const m_def_MonthInterval As Integer = 1
		Private Const m_def_DayInterval As Integer = 1
		Private Const m_def_DayOrdinal As RecurrenceOrdinalConstants = RecurrenceOrdinalConstants.First
		Private Const m_def_DayPosition As RecurrenceOrdinalDayConstants = RecurrenceOrdinalDayConstants.Monday

		Private m_RecurrenceMode As RecurrenceSubTypeConstants
		Private m_MonthInterval As Integer
		Private m_DayInterval As Integer
		Private m_DayOrdinal As RecurrenceOrdinalConstants
		Private m_DayPosition As RecurrenceOrdinalDayConstants
		<NonSerialized()> Private m_Parent As Recurrence

		Public Event Reload As ReloadDelegate
		Public Event Refresh As RefreshDelegate

#End Region

#Region "Property Implementation"

		Friend Property Parent() As Recurrence
			Get
				Return m_Parent
			End Get
			Set(ByVal Value As Recurrence)
				m_Parent = Value
			End Set
		End Property

		<Browsable(False)> _
		Public Property RecurrenceMode() As RecurrenceSubTypeConstants
			Get
				Return m_RecurrenceMode
			End Get
			Set(ByVal Value As RecurrenceSubTypeConstants)
				Try
					Select Case Value
						Case RecurrenceSubTypeConstants.Interval, RecurrenceSubTypeConstants.Ordinal
							'Do Nothing
						Case Else
							Value = m_def_RecurrenceMode
					End Select

					If m_RecurrenceMode <> Value Then
						m_RecurrenceMode = Value
						OnRefresh(Me, New System.EventArgs)
					End If

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

		<Description(""), _
		Browsable(True)> _
		Public Property MonthInterval() As Integer
			Get
				If m_MonthInterval < Recurrence.RecurrenceNumericMinimum Then m_MonthInterval = Recurrence.RecurrenceNumericMinimum
				If m_MonthInterval > Recurrence.RecurrenceNumericMaximum Then m_MonthInterval = Recurrence.RecurrenceNumericMaximum
				Return m_MonthInterval
			End Get
			Set(ByVal Value As Integer)
				Try
					If Value < Recurrence.RecurrenceNumericMinimum Then Value = Recurrence.RecurrenceNumericMinimum
					If Value > Recurrence.RecurrenceNumericMaximum Then Value = Recurrence.RecurrenceNumericMaximum
					If m_MonthInterval <> Value Then
						m_MonthInterval = Value
						OnRefresh(Me, New System.EventArgs)
					End If
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

		<Description(""), _
		Browsable(True)> _
		Public Property DayInterval() As Integer
			Get
				If m_DayInterval < Recurrence.RecurrenceNumericMinimum Then m_DayInterval = Recurrence.RecurrenceNumericMinimum
				If m_DayInterval > Recurrence.RecurrenceNumericMaximum Then m_DayInterval = Recurrence.RecurrenceNumericMaximum
				Return m_DayInterval
			End Get
			Set(ByVal Value As Integer)
				Try
					If Value < Recurrence.RecurrenceNumericMinimum Then Value = Recurrence.RecurrenceNumericMinimum
					If Value > Recurrence.RecurrenceNumericMaximum Then Value = Recurrence.RecurrenceNumericMaximum
					If m_DayInterval <> Value Then
						m_DayInterval = Value
						OnRefresh(Me, New System.EventArgs)
					End If
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

		<Description(""), _
		Browsable(True)> _
		Public Property DayPosition() As RecurrenceOrdinalDayConstants
			Get
				Return m_DayPosition
			End Get
			Set(ByVal Value As RecurrenceOrdinalDayConstants)
				Try
					Select Case Value
						Case RecurrenceOrdinalDayConstants.Day, RecurrenceOrdinalDayConstants.Weekday, RecurrenceOrdinalDayConstants.WeekendDay, RecurrenceOrdinalDayConstants.Sunday, RecurrenceOrdinalDayConstants.Monday, RecurrenceOrdinalDayConstants.Tuesday, RecurrenceOrdinalDayConstants.Wednesday, RecurrenceOrdinalDayConstants.Thursday, RecurrenceOrdinalDayConstants.Friday, RecurrenceOrdinalDayConstants.Saturday
							'Do Nothing
						Case Else
							Value = m_def_DayPosition
					End Select

					If m_DayPosition <> Value Then
						m_DayPosition = Value
						OnRefresh(Me, New System.EventArgs)
					End If
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

		<Description(""), _
		Browsable(True)> _
		Public Property DayOrdinal() As RecurrenceOrdinalConstants
			Get
				Return m_DayOrdinal
			End Get
			Set(ByVal Value As RecurrenceOrdinalConstants)
				Try
					Select Case Value
						Case RecurrenceOrdinalConstants.First, RecurrenceOrdinalConstants.Second, RecurrenceOrdinalConstants.Third, RecurrenceOrdinalConstants.Fourth, RecurrenceOrdinalConstants.Last
							'Do Nothing
						Case Else
							Value = m_def_DayOrdinal
					End Select

					If m_DayOrdinal <> Value Then
						m_DayOrdinal = Value
						OnRefresh(Me, New System.EventArgs)
					End If

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Set
		End Property

#End Region

#Region "Methods"

		Friend Function IsValid() As Boolean

			Try
        Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Constructor"

		Friend Sub New()
			Try
				m_RecurrenceMode = m_def_RecurrenceMode
				m_MonthInterval = m_def_MonthInterval
				m_DayInterval = m_def_DayInterval
				m_DayPosition = m_def_DayPosition
				m_DayOrdinal = m_def_DayOrdinal
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "On... Event Methods"

		Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Reload(sender, e)
		End Sub

		Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Refresh(sender, e)
		End Sub

#End Region

#Region "XML"

		Friend Function FromXML(ByVal xml As String) As Boolean

			Dim XMLDoc As New xml.XmlDocument

			Try

				'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				m_DayInterval = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "dayinterval", m_DayInterval.ToString))
				m_DayOrdinal = CType([Enum].Parse(GetType(RecurrenceOrdinalConstants), GetNodeValue(XMLDoc, startXPath & "dayordinal", m_DayOrdinal.ToString("d"))), RecurrenceOrdinalConstants)
				m_DayPosition = CType([Enum].Parse(GetType(RecurrenceOrdinalDayConstants), GetNodeValue(XMLDoc, startXPath & "dayposition", m_DayPosition.ToString("d"))), RecurrenceOrdinalDayConstants)
				m_MonthInterval = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "monthinterval", m_MonthInterval.ToString))
				m_RecurrenceMode = CType([Enum].Parse(GetType(RecurrenceSubTypeConstants), GetNodeValue(XMLDoc, startXPath & "recurrencemode", m_RecurrenceMode.ToString("d"))), RecurrenceSubTypeConstants)

				OnReload(Me, New System.EventArgs)
				OnRefresh(Me, New System.EventArgs)
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function ToXML() As String

			Dim xmlHelper As New Gravitybox.Objects.XMLHelper
			Dim XMLDoc As New Xml.XmlDocument
			Dim parentNode As Xml.XmlElement
			
			Try
				'Setup the Node Name
				parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

				'Add the appropriate properties
				Call xmlHelper.addElement(parentNode, "dayinterval", m_DayInterval.ToString)
				Call xmlHelper.addElement(parentNode, "dayordinal", GetIntlInteger(m_DayOrdinal).ToString)
				Call xmlHelper.addElement(parentNode, "dayposition", GetIntlInteger(m_DayPosition).ToString)
				Call xmlHelper.addElement(parentNode, "monthinterval", m_MonthInterval.ToString)
				Call xmlHelper.addElement(parentNode, "recurrencemode", GetIntlInteger(m_RecurrenceMode).ToString)

				'Return the XML string
				Return parentNode.OuterXml

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

#End Region

	End Class

End Namespace