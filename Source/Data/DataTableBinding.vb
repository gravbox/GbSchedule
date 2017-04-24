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
Imports System.Data

Namespace Gravitybox.Data

  <Serializable(), _
  Editor(GetType(Gravitybox.Design.Editors.DataBindingTableUITypeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
  Public Class DataTableBinding
    Implements IXMLable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "datatablebinding"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Private _dataSource As Object
    Private _DataFieldBindingCollection As DataFieldBindingCollection

#End Region

#Region "Construcutor"

    Friend Sub New()
      _DataFieldBindingCollection = New DataFieldBindingCollection
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' This is the datatable to use when binding the underlying collection.
    ''' </summary>
    <Browsable(True), _
     Description("This is the datatable to use when binding the underlying collection.")> _
     Public Property DataSource() As Object
      Get
        Return _dataSource
      End Get
      Set(ByVal Value As Object)

        If Value Is Nothing Then
          _dataSource = Value
          Return
        End If

        Try
          _dataSource = CType(Value, DataTable)
          Return
        Catch ex As Exception
        End Try

        Try
          _dataSource = CType(Value, DataView)
          Return
        Catch ex As Exception
        End Try

        'Throw error if not correct type
        Throw New Exceptions.GravityboxException("The DataSource property must be of type DataTable or DataView.")

      End Set
    End Property

    ''' <summary>
    ''' This is a list of field names to map when binding to a collection.
    ''' </summary>
    <Browsable(True), _
  Description("This is a list of field names to map when binding to a collection.")> _
  Public ReadOnly Property DataFieldBindingCollection() As DataFieldBindingCollection
      Get
        Return _DataFieldBindingCollection
      End Get
    End Property

#End Region

#Region "Methods"

    Friend Function ValidateFields(ByVal fields() As String) As Boolean

      Dim count As Integer = 0
      For Each db As Gravitybox.Data.DataBinding In Me.DataFieldBindingCollection
        For Each fld As String In fields
          If String.Compare(db.PropertyName, fld) = 0 Then
            count += 1
          End If
        Next
      Next
      Return (Me.DataFieldBindingCollection.Count = count)

    End Function

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

        Me.DataFieldBindingCollection.Clear()
        Me.DataFieldBindingCollection.FromXML(GetNodeXML(XMLDoc, startXPath & DataFieldBindingCollection.MyXMLNodeName, "", True))

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
      Dim elemNew As Xml.XmlNode

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'DataFieldBindingCollection
        elemNew = xmlHelper.addElement(parentNode, DataFieldBindingCollection.MyXMLNodeName, "")
        elemNew.InnerXml = Me.DataFieldBindingCollection.XmlNode.InnerXml

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