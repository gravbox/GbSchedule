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

  Public Enum RecurrenceDayConstants As Integer
    DayInterval = 1
    DayWeekdays = 2
	End Enum

	<Serializable()> _
	Public Class RecurrenceDay

#Region "Class Members"

		'Private Constants
		Friend Const MyXMLNodeName As String = "recurrenceday"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		'Private Member Constants
		Private Const m_def_RecurrenceMode As RecurrenceDayConstants = RecurrenceDayConstants.DayInterval
		Private Const m_def_DayInterval As Integer = Recurrence.RecurrenceNumericMinimum

		'Private Member Variables
		Private m_RecurrenceMode As RecurrenceDayConstants
		Private m_DayInterval As Integer
		<NonSerialized()> Private m_Parent As Recurrence

		Public Event Reload As ReloadDelegate
		Public Event Refresh As RefreshDelegate

#End Region

#Region "Methods"

		Friend Function IsValid() As Boolean

			Try
				Dim bRetval As Boolean
				Select Case RecurrenceMode
					Case RecurrenceDayConstants.DayWeekdays
						bRetval = True
					Case RecurrenceDayConstants.DayInterval
						bRetval = (DayInterval >= 1)
				End Select
				Return bRetval
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Property Implementations"

		Friend Property Parent() As Recurrence
			Get
				Return m_Parent
			End Get
			Set(ByVal Value As Recurrence)
				m_Parent = Value
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
		Public Property RecurrenceMode() As RecurrenceDayConstants
			Get
				Return m_RecurrenceMode
			End Get
			Set(ByVal Value As RecurrenceDayConstants)
				Try
					Select Case Value
						Case RecurrenceDayConstants.DayWeekdays, RecurrenceDayConstants.DayInterval
						Case Else : Value = RecurrenceDayConstants.DayInterval
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

#End Region

#Region "Constructor"

		Friend Sub New()
			m_RecurrenceMode = m_def_RecurrenceMode
			m_DayInterval = m_def_DayInterval
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
				m_RecurrenceMode = CType([Enum].Parse(GetType(RecurrenceDayConstants), GetNodeValue(XMLDoc, startXPath & "recurrencemode", m_RecurrenceMode.ToString("d"))), RecurrenceDayConstants)

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