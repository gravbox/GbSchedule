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

Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  <Serializable(), _
  DefaultEvent("Refresh"), _
  DefaultProperty("Text"), _
  TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentTypeConverter))> _
  Public Class AppointmentType
    Inherits BaseObject
    Implements System.Runtime.Serialization.IDeserializationCallback

#Region "Class Members"

    'Private Constants
    Friend Const MyXMLNodeName As String = "AppointmentType"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Private ReadOnly m_def_Color As System.Drawing.Color = System.Drawing.Color.Blue

    'Private Member Constants
    Private m_Color As Color = m_def_Color
    Private m_Notes As String = ""
    <NonSerialized()> Private m_TimeStamp As Long

#End Region

#Region "Constructor"

    Public Sub New()
      MyBase.New("", "")
    End Sub

    Public Sub New(ByVal key As String)
      Me.New(key, "", "", System.Drawing.Color.Blue)
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String)
      Me.New(key, text, "", System.Drawing.Color.Blue)
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String, ByVal notes As String)
      Me.New(key, text, notes, System.Drawing.Color.Blue)
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String, ByVal color As Color)
      Me.New(key, text, "", color)
    End Sub

    Public Sub New(ByVal key As String, ByVal text As String, ByVal notes As String, ByVal color As Color)
      MyBase.New(key, text)
      m_Notes = notes
      m_Color = color
      Me.ResetTimeStamp(False)
      AddHandler Me.TextChanged, AddressOf TextChangedHandler
    End Sub

#End Region

#Region "Clone"

    Friend Overrides Function CloneMe() As Object
      Try
        Dim element As New Gravitybox.Objects.AppointmentType
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
    ''' Determines the color drawn to represent this object.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("color"), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "Blue"), _
    Description("Determines the color drawn to represent this object.")> _
    Public Property Color() As Color
      Get
        Return m_Color
      End Get
      Set(ByVal Value As Color)
        If Not m_Color.Equals(Value) Then
          m_Color = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines note text associated with this object.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("notes"), _
    Category("Data"), _
    DefaultValue(""), _
    Description("Determines note text associated with this object.")> _
    Public Property Notes() As String
      Get
        Return m_Notes
      End Get
      Set(ByVal Value As String)
        If m_Notes <> Value Then
          m_Notes = Value
          Call Me.ResetTimeStamp(True)
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    Friend ReadOnly Property TimeStamp() As Long
      Get
        Return m_TimeStamp
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub TextChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
      Call ResetTimeStamp(True)
    End Sub

#End Region

#Region "TimeStamp"

    Friend Sub ResetTimeStamp(ByVal callRefresh As Boolean)
      Try
        Dim value As Long = DateTime.Now.ToUniversalTime.Ticks
        If m_TimeStamp <> value Then
          m_TimeStamp = value
          If callRefresh Then
            OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
          End If
        End If
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

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "key", Me.Key)
        Call xmlHelper.addElement(parentNode, "text", Me.Text)
        Call xmlHelper.addElement(parentNode, "color", m_Color.ToArgb.ToString)
        Call xmlHelper.addElement(parentNode, "notes", m_Notes)

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

    Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean

      Dim XMLDoc As New xml.XmlDocument

      Try
        'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				Me.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
				Me.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))

				m_Color = System.Drawing.Color.FromArgb(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "color", m_Color.ToArgb.ToString)))
				m_Notes = GetNodeValue(XMLDoc, startXPath & "notes", m_Notes)
				Call ResetTimeStamp(True)

				If Not shallow Then
					'Objects
					PropertyItemCollection.Clear()
					PropertyItemCollection.FromXML(GetNodeXML(XMLDoc, startXPath & PropertyItemCollection.MyXMLNodeName, "", True))
				End If

				If Not cancelEvents Then
					OnReload(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
					OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
				End If
				Return True

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean
      Return FromXML(xml, False, False)
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

#Region "OnDeserialization"

    Private Sub OnDeserialization(ByVal sender As Object) Implements System.Runtime.Serialization.IDeserializationCallback.OnDeserialization

      Try
        Call ResetTimeStamp(True)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace
