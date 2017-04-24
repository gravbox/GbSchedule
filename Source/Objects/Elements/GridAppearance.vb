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
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

	<Serializable(), _
	DesignerSerializer(GetType(Gravitybox.Design.Serializers.GridAppearanceSerializer), GetType(CodeDomSerializer)), _
	TypeConverter(GetType(Gravitybox.Design.Converters.GridAppearanceConverter))> _
	Public Class GridAppearance
		Inherits Gravitybox.Objects.Appearance

#Region "Class Members"

		'Private Constants
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		Private ReadOnly m_def_MajorLineColor As Color = System.Drawing.Color.FromArgb(&H9C, &HBA, &HE7)
		Private ReadOnly m_def_MinorLineColor As Color = System.Drawing.Color.FromArgb(&HD6, &HE7, &HF7)
		Private ReadOnly m_def_ItemLineColor As Color = System.Drawing.Color.FromArgb(&H5A, &H8E, &HCE)
		Private Const m_def_MajorLineWidth As Integer = 1
		Private Const m_def_MinorLineWidth As Integer = 1
		Private Const m_def_ItemLineWidth As Integer = 2

		'Private Member Variables
		Protected m_MajorLineColor As Color = m_def_MajorLineColor
		Protected m_MinorLineColor As Color = m_def_MinorLineColor
		Protected m_ItemLineColor As Color = m_def_ItemLineColor
		Protected m_MajorLineWidth As Integer = m_def_MajorLineWidth
		Protected m_MinorLineWidth As Integer = m_def_MinorLineWidth
		Protected m_ItemLineWidth As Integer = m_def_ItemLineWidth

#End Region

#Region "Constructor"

		Public Sub New()
			MyBase.New("", "")
		End Sub

		Public Sub New(ByVal key As String)
			MyBase.New(key, "")
		End Sub

		Public Sub New(ByVal key As String, ByVal text As String)
			MyBase.New(key, text)
		End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.GridAppearance
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

		<Browsable(True), _
		Category("Appearance")> _
		Public Property MajorLineColor() As Color
			Get
				Return m_MajorLineColor
			End Get
			Set(ByVal Value As Color)
				m_MajorLineColor = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance")> _
		Public Property MinorLineColor() As Color
			Get
				Return m_MinorLineColor
			End Get
			Set(ByVal Value As Color)
				m_MinorLineColor = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance")> _
		Public Property ItemLineColor() As Color
			Get
				Return m_ItemLineColor
			End Get
			Set(ByVal Value As Color)
				m_ItemLineColor = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance")> _
		Public Property MajorLineWidth() As Integer
			Get
				Return m_MajorLineWidth
			End Get
			Set(ByVal Value As Integer)
				m_MajorLineWidth = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance")> _
		Public Property MinorLineWidth() As Integer
			Get
				Return m_MinorLineWidth
			End Get
			Set(ByVal Value As Integer)
				m_MinorLineWidth = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance")> _
		Public Property ItemLineWidth() As Integer
			Get
				Return m_ItemLineWidth
			End Get
			Set(ByVal Value As Integer)
				m_ItemLineWidth = Value
			End Set
		End Property

#End Region

#Region "XML"

		''' <summary>
		''' Converts the object to an XML string.
		''' </summary>
		Public Overrides Function ToXML() As String
			Return Me.XmlNode.OuterXml
		End Function

		''' <summary>
		''' Reconstitute this object from an XML string.
		''' </summary>
		''' <param name="xml">The XML string</param>
		''' <returns>True if this object was successfully loaded</returns>
		Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean

			Dim XMLDoc As New Xml.XmlDocument

			Try

				'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				m_MajorLineColor = System.Drawing.Color.FromArgb(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "majorlinecolor", m_MajorLineColor.ToArgb.ToString)))
				m_MinorLineColor = System.Drawing.Color.FromArgb(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "minorlinecolor", m_MinorLineColor.ToArgb.ToString)))
				m_ItemLineColor = System.Drawing.Color.FromArgb(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "itemlinecolor", m_ItemLineColor.ToArgb.ToString)))
				m_MajorLineWidth = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "majorlinewidth", m_MajorLineWidth.ToString()))
				m_MinorLineWidth = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "minorlinewidth", m_MinorLineWidth.ToString()))
				m_ItemLineWidth = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "itemlinewidth", m_ItemLineWidth.ToString()))
				MyBase.FromXML(xml)
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Overrides Function XmlNode() As System.Xml.XmlNode

			Dim xmlHelper As New Gravitybox.Objects.XMLHelper
			Dim XMLDoc As New Xml.XmlDocument
			Dim parentNode As Xml.XmlElement

			Try
				'Setup the Node Name
				parentNode = CType(MyBase.XmlNode, Xml.XmlElement)
				Dim typeNode As Xml.XmlElement = xmlHelper.getElement(parentNode, "type")
				If typeNode Is Nothing Then
					Call xmlHelper.addElement(parentNode, "type", "1")
				Else
					typeNode.InnerText = "1"
				End If

				Call xmlHelper.addElement(parentNode, "majorlinecolor", m_MajorLineColor.ToArgb.ToString)
				Call xmlHelper.addElement(parentNode, "minorlinecolor", m_MinorLineColor.ToArgb.ToString)
				Call xmlHelper.addElement(parentNode, "itemlinecolor", m_ItemLineColor.ToArgb.ToString)
				Call xmlHelper.addElement(parentNode, "majorlinewidth", m_MajorLineWidth.ToString)
				Call xmlHelper.addElement(parentNode, "minorlinewidth", m_MinorLineWidth.ToString)
				Call xmlHelper.addElement(parentNode, "itemlinewidth", m_ItemLineWidth.ToString)

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
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Function

#End Region

	End Class

End Namespace