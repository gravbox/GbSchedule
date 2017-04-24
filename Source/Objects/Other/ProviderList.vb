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
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  <Serializable()> _
  Public Class ProviderList
		Inherits Gravitybox.Objects.BaseList

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "providerlist"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    <NonSerialized()> Private BaseAppointment As Gravitybox.Objects.Appointment

#End Region

#Region "Constructor"

		Friend Sub New()
		End Sub

		Friend Sub New(ByVal schedule As Gravitybox.Controls.Schedule, ByVal appointment As Appointment)
			MyBase.New(schedule)
			Me.BaseAppointment = appointment
		End Sub

		Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule, ByVal collection As Gravitybox.Objects.BaseObjectCollection)
			MyBase.New(schedule, collection)
		End Sub

		Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule)
			MyBase.New(schedule)
		End Sub

		Public Sub New(ByVal collection As Gravitybox.Objects.BaseObjectCollection)
			MyBase.New(collection)
		End Sub

#End Region

#Region "On... Event Methods"

		Protected Overrides Sub OnClearComplete()
			If Not (BaseAppointment Is Nothing) Then
				BaseAppointment.OnRefresh(BaseAppointment, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(BaseAppointment))
			End If
			MyBase.OnRefresh(Me, New System.EventArgs)
		End Sub

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts all objects in this list to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String
      Return Me.XmlNode.OuterXml
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overrides Function FromXML(ByVal xml As String) As Boolean

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        'Load the elements
        Dim xmlNode As System.Xml.XmlNode
        For Each xmlNode In XMLDoc.DocumentElement.ChildNodes
          If Me.MainObject.ProviderCollection.Contains(xmlNode.InnerText) Then
            Call Me.Add(Me.MainObject.ProviderCollection(xmlNode.InnerText))
          End If
        Next

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

				'Loop and load all of the XML for the children
				Dim element As Provider
				For Each element In Me
					Call xmlHelper.addElement(parentNode, "key", element.Key)
				Next

				'Return the XML string
				Return parentNode

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overrides Function SaveXML(ByVal fileName As String) As Boolean
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
    Public Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
        OnRefresh(Me, New System.EventArgs)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

	End Class

End Namespace