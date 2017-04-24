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

  <Serializable(), _
  DefaultEvent("Refresh"), _
  DefaultProperty("Text")> _
  Public Class PropertyItem
    Inherits BaseObject

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "propertyitem"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Member Variables
		Private m_Setting As String = ""

#End Region

#Region "Constructor"

		'Override constructor so that this object not publically creatable
		Friend Sub New()
			MyBase.New("", "")
			AddHandler Me.TextChanged, AddressOf TextChangedHandler
		End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.PropertyItem
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
    ''' Determines the setting for this object.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("setting"), _
    Category("Data"), _
    Description("Determines the value associated with this object.")> _
    Public Property Setting() As String
      Get
        Return m_Setting
      End Get
      Set(ByVal Value As String)
        If (m_Setting <> Value) OrElse ((m_Setting Is Nothing) Xor (Value Is Nothing)) Then
          m_Setting = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

#End Region

#Region "Handlers"

		Private Sub TextChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
		End Sub

#End Region

#Region "ToString"

		Public Overrides Function ToString() As String

			Try
				Return Me.Text & ": " & Me.Setting
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the object to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "key", Me.Key)
        Call xmlHelper.addElement(parentNode, "text", Me.Text)
        Call xmlHelper.addElement(parentNode, "setting", m_Setting)

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
				Me.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
				Me.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))
				m_Setting = GetNodeValue(XMLDoc, startXPath & "setting", m_Setting)

				OnReload(Me, New System.EventArgs)
				OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
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
