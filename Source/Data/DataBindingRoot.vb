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

  <Serializable(), _
  Editor(GetType(Gravitybox.Design.Editors.DataBindingRootUITypeEditor), GetType(System.Drawing.Design.UITypeEditor))> _
  Public Class DataBindingRoot
    Implements IXMLable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "databindingroot"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Private _appointmentBinding As DataTableBinding
    Private _roomBinding As DataTableBinding
    Private _categoryBinding As DataTableBinding
    Private _providerBinding As DataTableBinding
    Private _resourceBinding As DataTableBinding
    Private _appointmentCategoryBinding As DataTableBinding
    Private _appointmentProviderBinding As DataTableBinding
    Private _appointmentResourceBinding As DataTableBinding
    Private _appearanceBinding As DataTableBinding
    Private _recurrenceBinding As DataTableBinding

#End Region

#Region "Constructor"

    Friend Sub New()
      _appointmentBinding = New DataTableBinding
      _roomBinding = New DataTableBinding
      _categoryBinding = New DataTableBinding
      _providerBinding = New DataTableBinding
      _resourceBinding = New DataTableBinding
      _appointmentCategoryBinding = New DataTableBinding
      _appointmentProviderBinding = New DataTableBinding
      _appointmentResourceBinding = New DataTableBinding
      _appearanceBinding = New DataTableBinding
      _recurrenceBinding = New DataTableBinding
    End Sub

#End Region

#Region "Property Implementations"

    <Browsable(True), _
    Description("This object contains information for mapping the 'appointment' datatable.")> _
    Public ReadOnly Property AppointmentBinding() As DataTableBinding
      Get
        Return _appointmentBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'room' datatable.")> _
    Public ReadOnly Property RoomBinding() As DataTableBinding
      Get
        Return _roomBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'category' datatable.")> _
    Public ReadOnly Property CategoryBinding() As DataTableBinding
      Get
        Return _categoryBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'provider' datatable.")> _
    Public ReadOnly Property ProviderBinding() As DataTableBinding
      Get
        Return _providerBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'resource' datatable.")> _
    Public ReadOnly Property ResourceBinding() As DataTableBinding
      Get
        Return _resourceBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'appointment_category' datatable.")> _
    Public ReadOnly Property AppointmentCategoryBinding() As DataTableBinding
      Get
        Return _appointmentCategoryBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'appointment_provider' datatable.")> _
    Public ReadOnly Property AppointmentProviderBinding() As DataTableBinding
      Get
        Return _appointmentProviderBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'appointment_resource' datatable.")> _
    Public ReadOnly Property AppointmentResourceBinding() As DataTableBinding
      Get
        Return _appointmentResourceBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'appearance' datatable.")> _
    Friend ReadOnly Property AppearanceBinding() As DataTableBinding
      Get
        Return _appearanceBinding
      End Get
    End Property

    <Browsable(True), _
    Description("This object contains information for mapping the 'recurrence' datatable.")> _
    Friend ReadOnly Property RecurrenceBinding() As DataTableBinding
      Get
        Return _recurrenceBinding
      End Get
    End Property

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts this object to an XML string.
    ''' </summary>
    Public Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
      Return Me.XmlNode.OuterXml
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Clear all collections
        Me.AppearanceBinding.DataSource = Nothing
        Me.AppointmentBinding.DataSource = Nothing
        Me.AppointmentCategoryBinding.DataSource = Nothing
        Me.AppointmentProviderBinding.DataSource = Nothing
        Me.AppointmentResourceBinding.DataSource = Nothing
        Me.CategoryBinding.DataSource = Nothing
        Me.ProviderBinding.DataSource = Nothing
        Me.ResourceBinding.DataSource = Nothing
        Me.RoomBinding.DataSource = Nothing

        'Clear all collections
        Me.AppearanceBinding.DataFieldBindingCollection.Clear()
        Me.AppointmentBinding.DataFieldBindingCollection.Clear()
        Me.AppointmentCategoryBinding.DataFieldBindingCollection.Clear()
        Me.AppointmentProviderBinding.DataFieldBindingCollection.Clear()
        Me.AppointmentResourceBinding.DataFieldBindingCollection.Clear()
        Me.CategoryBinding.DataFieldBindingCollection.Clear()
        Me.ProviderBinding.DataFieldBindingCollection.Clear()
        Me.ResourceBinding.DataFieldBindingCollection.Clear()
        Me.RoomBinding.DataFieldBindingCollection.Clear()

        'Return so there is no error is blank text
        If xml = "" Then Return True

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        Dim node As System.Xml.XmlNode

        node = XMLDoc.SelectSingleNode("//AppointmentBinding")
        If Not (node Is Nothing) Then
          Me.AppointmentBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//RoomBinding")
        If Not (node Is Nothing) Then
          Me.RoomBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//CategoryBinding")
        If Not (node Is Nothing) Then
          Me.CategoryBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//ProviderBinding")
        If Not (node Is Nothing) Then
          Me.ProviderBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//ResourceBinding")
        If Not (node Is Nothing) Then
          Me.ResourceBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//AppointmentCategoryBinding")
        If Not (node Is Nothing) Then
          Me.AppointmentCategoryBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//AppointmentProviderBinding")
        If Not (node Is Nothing) Then
          Me.AppointmentProviderBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//AppointmentResourceBinding")
        If Not (node Is Nothing) Then
          Me.AppointmentResourceBinding.FromXML(node.OuterXml)
        End If

        node = XMLDoc.SelectSingleNode("//AppearanceBinding")
        If Not (node Is Nothing) Then
          Me.AppearanceBinding.FromXML(node.OuterXml)
        End If

        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement
      Dim elemNew As Xml.XmlNode

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        elemNew = xmlHelper.addElement(parentNode, "AppointmentBinding")
        elemNew.InnerXml = Me.AppointmentBinding.ToXML()

        elemNew = xmlHelper.addElement(parentNode, "AppointmentCategoryBinding")
        elemNew.InnerXml = Me.AppointmentCategoryBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "AppointmentProviderBinding")
        elemNew.InnerXml = Me.AppointmentProviderBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "AppointmentResourceBinding")
        elemNew.InnerXml = Me.AppointmentResourceBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "CategoryBinding")
        elemNew.InnerXml = Me.CategoryBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "ProviderBinding")
        elemNew.InnerXml = Me.ProviderBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "ResourceBinding")
        elemNew.InnerXml = Me.ResourceBinding.ToXML

        elemNew = xmlHelper.addElement(parentNode, "RoomBinding")
        elemNew.InnerXml = Me.RoomBinding.ToXML

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