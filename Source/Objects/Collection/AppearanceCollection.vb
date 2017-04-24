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

Imports Gravitybox.Objects.EventArgs
Imports System.Drawing
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization

Namespace Gravitybox.Objects

  <Serializable(), _
  Editor(GetType(Gravitybox.Design.Editors.AppearanceCollectionUITypeEditor), GetType(System.Drawing.Design.UITypeEditor)), _
  DefaultEvent("Refresh")> _
  Public Class AppearanceCollection
    Inherits Gravitybox.Objects.BaseObjectCollection

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "Appearancecollection"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Property variables
    <NonSerialized()> Private MainObject As Gravitybox.Controls.Schedule

#End Region

#Region "Constructor"

    'Override constructor so that this object not publicly creatable
    Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
      Me.MainObject = mainObject
      Me.ObjectSingular = "Appearance"
      Me.ObjectPlural = "Appearances"
      AddHandler Me.AfterRemove, AddressOf AfterRemoveHandler
      AddHandler Me.ClearComplete, AddressOf ClearCompleteHandler
    End Sub

#End Region

#Region "Add Methods"

    'Add -- No Parameters
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <returns>A newly created appearance object.</returns>
    Public Function Add() As Appearance
      Return Add(Guid.NewGuid().ToString(), "", -1)
    End Function

    'Add -- Object
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="appearance">This object to add to this collection.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal appearance As Appearance) As Appearance
      Return CType(AddObject(appearance), Gravitybox.Objects.Appearance)
    End Function

    'Add -- Object, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="appearance">This object to add to this collection.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal appearance As Appearance, ByVal index As Integer) As Appearance
      Return CType(AddObject(appearance, index), Gravitybox.Objects.Appearance)
    End Function

    'Add -- Key
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Add(ByVal key As String) As Appearance
      Return Add(key, "", -1)
    End Function

    'Add -- Key, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal index As Integer) As Appearance
      Return Add(key, "", index)
    End Function

    'Add -- Key, Text
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String) As Appearance
      Return Add(key, text, -1)
    End Function

    'Add -- Key, Text, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text"></param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String, ByVal index As Integer) As Appearance

      Dim newObject As New Gravitybox.Objects.Appearance

      If key <> "" Then
        'Error check that the new key does not exist
        If Contains(key) Then
          Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
        End If
        Call newObject.SetKey(key)
      Else
        key = newObject.Key
      End If

      'Error Check
      key = Trim(key)
      If key = "" Then
        Throw New Exceptions.GravityboxException(ErrorStringNoKey)
      ElseIf Contains(key) Then
        Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
      End If

      newObject.Text = text

      Try
        'Create the object and add it to the collections
        Call newObject.SetKey(key)
        Return CType(AddObject(newObject, index), Gravitybox.Objects.Appearance)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Protected Friend Overloads Overrides Function AddObject(ByVal newObject As Gravitybox.Objects.BaseObject) As Gravitybox.Objects.BaseObject
      Return AddObject(newObject, -1)
    End Function

    <System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)> _
    Protected Friend Overloads Overrides Function AddObject(ByVal newObject As Gravitybox.Objects.BaseObject, ByVal index As Integer) As Gravitybox.Objects.BaseObject

      'The object must be set and it must NOT have a parent
      If newObject Is Nothing Then Return Nothing
      If Contains(newObject) Then
        Throw New Exceptions.GravityboxException(ErrorStringObjectHasParent)
      End If

      If (index < -1) Or (index > Me.Count) Then
        'Subscript out of range
        Throw New System.ArgumentOutOfRangeException
      End If

      If newObject.Key = "" Then newObject.SetKey(System.Guid.NewGuid().ToString)

      Dim eventParam1 As New BeforeBaseObjectEventArgs(newObject)
      OnBeforeAdd(Me, eventParam1)
      If eventParam1.Cancel Then Return Nothing

      Try
        AddHandler newObject.Refresh, AddressOf OnRefresh
        If index = -1 Then
          MyBase.List.Add(newObject)
        Else
          MyBase.List.Insert(index, newObject)
        End If
        newObject.BaseCollection = Me
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

      Dim eventParam2 As New AfterBaseObjectEventArgs(newObject)
      OnInternalAfterAdd(Me, eventParam2)
      OnAfterAdd(Me, eventParam2)
      OnRefresh(Me, New AfterBaseObjectEventArgs(newObject))

      Return newObject

    End Function

#End Region

#Region "Item"

    ''' <summary>
    ''' Returns the object that matches the unique key.
    ''' </summary>
    ''' <param name="key">The key of the item to retrieve.</param>
    ''' <returns>The matching object or null if no match is found.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.Appearance
      Get
        Return CType(MyBase.Item(key), Gravitybox.Objects.Appearance)
      End Get
    End Property


    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.Appearance
      Get
        Return CType(MyBase.Item(index), Gravitybox.Objects.Appearance)
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub ClearCompleteHandler()
    End Sub

    Private Sub AfterRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
    End Sub

#End Region

#Region "Methods"

    Friend Function GetMainObject() As Gravitybox.Controls.Schedule
      Return Me.MainObject
    End Function

#End Region

#Region "Dispose"

    Protected Friend Overrides Sub Dispose()
      MainObject = Nothing
    End Sub

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the collection to an XML string.
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
      Dim xmlHelper As New Gravitybox.Objects.XMLHelper

      Try

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        'Load the elements
        For Each xmlNode As System.Xml.XmlElement In XMLDoc.DocumentElement.ChildNodes
          Dim newElement As Gravitybox.Objects.Appearance = Nothing
          Dim typeNode As Xml.XmlElement = xmlHelper.getElement(xmlNode, "type")
          If (typeNode Is Nothing) Then
            newElement = New Gravitybox.Objects.Appearance("")
          ElseIf typeNode.InnerText = "1" Then
            newElement = New Gravitybox.Objects.AppointmentAppearance("")
          ElseIf typeNode.InnerText = "2" Then
            newElement = New Gravitybox.Objects.AppointmentHeaderAppearance("")
          Else
            newElement = New Gravitybox.Objects.Appearance("")
          End If
          Call newElement.FromXML(xmlNode.OuterXml)
          Call AddObject(newElement)
          OnRefresh(Me, New AfterBaseObjectEventArgs(newElement))
        Next

        OnReload(Me, New System.EventArgs)
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
        Dim sb As New System.Text.StringBuilder
        For Each element As BaseObject In Me
          sb.Append(element.ToXML)
        Next
        parentNode.InnerXml = sb.ToString

        'Return the XML string
        Return parentNode

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Saves the collection to an XML file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to create.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Load the collection from an XML file.
    ''' </summary>
    ''' <param name="fileName">The name of the file from which to load.</param>
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
