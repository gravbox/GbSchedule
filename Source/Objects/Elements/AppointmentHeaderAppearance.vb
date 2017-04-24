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
  DesignerSerializer(GetType(Gravitybox.Design.Serializers.AppointmentHeaderAppearanceSerializer), GetType(CodeDomSerializer)), _
  TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentHeaderAppearanceConverter))> _
  Public Class AppointmentHeaderAppearance
    Inherits Gravitybox.Objects.Appearance

#Region "Class Members"

    'Private Constants
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Member Constants
    <NonSerialized()> Private Const m_def_Transparency As Integer = 0
    <NonSerialized()> Private Const m_def_AllowBreak As Boolean = True

    'Private Member Variables
    Private m_Transparency As Integer = m_def_Transparency
    Private m_AllowBreak As Boolean = m_def_AllowBreak

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
				Dim element As New Gravitybox.Objects.AppointmentHeaderAppearance
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

    ''' <summary>
    ''' Determines the level of transparency for the header.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(0), _
    Editor(GetType(Gravitybox.Design.Editors.IntegerRangeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.IntegerRangeConverter)), _
    Description("Determines the level of transparency for the header.")> _
    Public Property Transparency() As Integer
      Get
        Return m_Transparency
      End Get
      Set(ByVal Value As Integer)
        If m_Transparency <> Value Then
          m_Transparency = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if a line is drawn between the header and main portion of the parent appointment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowBreak), _
    Description("Determines if a line is drawn between the header and main portion of the parent appointment.")> _
    Public Property AllowBreak() As Boolean
      Get
        Return m_AllowBreak
      End Get
      Set(ByVal Value As Boolean)
        If m_AllowBreak <> Value Then
          m_AllowBreak = Value
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
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
        m_Transparency = GetIntlInteger((GetNodeValue(XMLDoc, startXPath & "transparency", m_Transparency.ToString)))
        m_AllowBreak = CBool(GetNodeValue(XMLDoc, startXPath & "allowbreak", m_AllowBreak.ToString))
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
					Call xmlHelper.addElement(parentNode, "type", "2")
				Else
					typeNode.InnerText = "2"
				End If
				Call xmlHelper.addElement(parentNode, "transparency", m_Transparency.ToString)
				Call xmlHelper.addElement(parentNode, "allowbreak", m_AllowBreak.ToString)

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
