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

Imports Gravitybox.Objects
Imports Gravitybox.Objects.EventArgs
Imports System.ComponentModel

Namespace Gravitybox.Data

  Public Class DataBinding
    Implements IXMLable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "datafieldbinding"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Private _propertyName As String = ""
    Private _dataMember As String = ""
    Private _locked As Boolean = False

#End Region

#Region "Constructor"

    Public Sub New()
      _propertyName = ""
      _dataMember = ""
    End Sub

    Public Sub New(ByVal propertyName As String, ByVal dataMember As String)
      _propertyName = propertyName
      _dataMember = dataMember
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' This is the original data table field name that the schedule expects.
    ''' </summary>
    <Browsable(True), _
    Description("This is the original data table field name that the schedule expects.")> _
    Public Property PropertyName() As String
      Get
        Return _propertyName
      End Get
      Set(ByVal Value As String)
        If Me.Locked Then
          Throw New Exceptions.GravityboxException("This property cannot be changed when it is a member of a collection!")
        End If

        If (Value Is Nothing) OrElse (Value = "") Then
          Throw New Exceptions.GravityboxException("This property must be set to a valid value!")
        End If

        _propertyName = Value
      End Set
    End Property

    ''' <summary>
    ''' This is the actual table field name the schedule will use instead of the original name it expects.
    ''' </summary>
    <Browsable(True), _
    Description("This is the actual table field name the schedule will use instead of the original name it expects.")> _
    Public Property DataMember() As String
      Get
        Return _dataMember
      End Get
      Set(ByVal Value As String)
        If Me.Locked Then
          Throw New Exceptions.GravityboxException("This property cannot be changed when it is a member of a collection!")
        End If

        If (Value Is Nothing) OrElse (Value = "") Then
          Throw New Exceptions.GravityboxException("This property must be set to a valid value!")
        End If

        _dataMember = Value
      End Set
    End Property

    Friend Property Locked() As Boolean
      Get
        Return _locked
      End Get
      Set(ByVal Value As Boolean)
        _locked = Value
      End Set
    End Property

#End Region

#Region "XML"

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Function FromXML(ByVal xml As String) As Boolean Implements Objects.IXMLable.FromXML

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        If xml = "" Then Return False
        XMLDoc.InnerXml = xml

        'Load all properties
        _propertyName = GetNodeValue(XMLDoc, "propertyname", _propertyName)
        _dataMember = GetNodeValue(XMLDoc, "datamember", _dataMember)

        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Converts this object to an XML string.
    ''' </summary>
    Public Function ToXML() As String Implements Objects.IXMLable.ToXML
      Return Me.XmlNode.OuterXml
    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "propertyname", _propertyName)
        Call xmlHelper.addElement(parentNode, "datamember", _dataMember)

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
