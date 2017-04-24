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

Namespace Gravitybox.Objects

	<Serializable(), _
	Editor(GetType(Gravitybox.Design.Editors.ResourceCollectionUITypeEditor), GetType(System.Drawing.Design.UITypeEditor)), _
	DefaultEvent("Refresh")> _
	Public Class ResourceCollection
    Inherits Gravitybox.Objects.BaseObjectCollection

#Region "Class Members"

		Friend Const MyXMLNodeName As String = "resourcecollection"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		'Private constants needed for this object
		Private ReadOnly m_def_InitColor As Color = Color.Blue

    'Private Property variables
		<NonSerialized()> Private MainObject As Gravitybox.Controls.Schedule

#End Region

#Region "OnClear"

    Protected Overrides Sub OnClear()

      Try
				Call CleanAppointments()
				MyBase.OnClear()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Constructor"

    'Override constructor so that this object not publically creatable
    Friend Sub New(ByVal mainobject As Gravitybox.Controls.Schedule)
      Me.MainObject = mainobject
      Me.ObjectSingular = "Resource"
      Me.ObjectPlural = "Resources"
      AddHandler Me.AfterRemove, AddressOf AfterRemoveHandler
      AddHandler Me.ClearComplete, AddressOf ClearCompleteHandler
    End Sub

#End Region

#Region "Add Methods"

    'Add -- No Parameters
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add() As Resource
      Return Add(Guid.NewGuid().ToString(), "", m_def_InitColor, -1)
    End Function

    'Add -- Object
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="resource">This object to add to this collection.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal resource As Resource) As Resource
      Return CType(AddObject(resource), resource)
    End Function

    'Add -- Object, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="resource">This object to add to this collection.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal resource As Resource, ByVal index As Integer) As Resource
      Return CType(AddObject(resource, index), resource)
    End Function

    'Add -- Key
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Add(ByVal key As String) As Resource
      Return Add(key, "", m_def_InitColor, -1)
    End Function

    'Add -- Key, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal index As Integer) As Resource
      Return Add(key, "", m_def_InitColor, index)
    End Function

    'Add -- Key, Text
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text">The text to be used as the name of the object. This will be displayed on the schedule.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String) As Resource
      Return Add(key, text, m_def_InitColor, -1)
    End Function

    'Add -- Key, Text, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text">The text to be used as the name of the object. This will be displayed on the schedule.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String, ByVal index As Integer) As Resource
      Return Add(key, text, m_def_InitColor, index)
    End Function

    'Add -- Key, Text, Color
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text">The text to be used as the name of the object. This will be displayed on the schedule.</param>
    ''' <param name="color">The color associated with this object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String, ByVal color As Color) As Resource
      Return Add(key, text, color, -1)
    End Function

    'Add -- Key, Text, Color, Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="text">The text to be used as the name of the object. This will be displayed on the schedule.</param>
    ''' <param name="color">The color associated with this object.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal text As String, ByVal color As Color, ByVal index As Integer) As Resource

      Dim newObject As New Resource

      If key <> "" Then
        'Error check that the new key does not exist
        If Contains(key) Then
          Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
        End If
        Call newObject.SetKey(key)
      Else
        key = newObject.Key
      End If

      newObject.Text = text
      newObject.Appearance.BackColor = color

      'Error Check
      key = Trim(key)
      If key = "" Then
        Throw New Exceptions.GravityboxException(ErrorStringNoKey)
      ElseIf Contains(key) Then
        Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
      End If

      Try
        'Create the object and add it to the collections
        Call newObject.SetKey(key)
        Return CType(AddObject(newObject, index), Resource)
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

      Dim eventParam1 As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs = New Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs(newObject)
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

      Dim eventParam2 As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs = New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(newObject)
      OnInternalAfterAdd(Me, eventParam2)
      OnAfterAdd(Me, eventParam2)
      OnRefresh(Me, New AfterBaseObjectEventArgs(newObject))

      Return newObject

    End Function

#End Region

#Region "VisibleCount"

    <Browsable(False)> _
    Friend Shadows ReadOnly Property VisibleCount() As Integer
      Get
        Dim retval As Integer = 0
        For Each resource As Gravitybox.Objects.Resource In Me
          If resource.Visible Then
            retval += 1
          End If
        Next
        Return retval
      End Get
    End Property

#End Region

#Region "VisibleList"

    <Browsable(False)> _
    Public ReadOnly Property VisibleList() As ArrayList
      Get
        Dim retval As New ArrayList
        For Each resource As Gravitybox.Objects.Resource In Me
          If resource.Visible Then
            retval.Add(resource)
          End If
        Next
        Return retval
      End Get
    End Property

    Public Function IsVisible(ByVal index As Integer) As Boolean

      If Me.Contains(index) Then
        Return Me(index).Visible
      End If

    End Function

    Public Function IndexOfVisible(ByVal item As Gravitybox.Objects.Resource) As Integer

      If item Is Nothing Then Return -1
      Dim index As Integer
      For Each loopResource As Gravitybox.Objects.Resource In Me
        If (item Is loopResource) AndAlso (item.Visible) Then
          Return index
        End If
        If loopResource.Visible Then
          index += 1
        End If
      Next
      Return -1

    End Function

    Friend Function IndexOfVisible(ByVal absoluteIndex As Integer) As Integer
      If Me.Contains(absoluteIndex) Then
        Return Me.IndexOfVisible(Me(absoluteIndex))
      Else
        Return -1
      End If
    End Function

#End Region

#Region "Methods"

    Friend Function GetMainObject() As Gravitybox.Controls.Schedule
      Return Me.MainObject
    End Function

    Friend Function MaxLineCount() As Integer

      Try
        Dim retval As Integer = 1
        For Each resource As Gravitybox.Objects.Resource In Me
          Dim s As String = resource.Text.Replace(vbCr, "")
          Dim length As Integer = resource.Text.Length - s.Length + 1
          If retval < length Then retval = length
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return 1

    End Function

    Friend Function GetLeftMarginWidth(ByVal g As Graphics, ByVal font As Font) As Integer

      Dim resource As resource
      Dim retval As Integer
      Dim length As Integer
      Try
        For Each resource In Me
          length = GetIntlInteger(g.MeasureString(resource.Text, font).Width)
          If retval < length Then retval = length
        Next
        Return retval
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Item"

    ''' <summary>
    ''' Returns the object that matches the unique key.
    ''' </summary>
    ''' <param name="key">The key of the item to retrieve.</param>
    ''' <returns>The matching object or null if no match is found.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.Resource
      Get
        Return CType(MyBase.Item(key), Resource)
      End Get
    End Property

    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.Resource
      Get
        Return CType(MyBase.Item(index), Resource)
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub ClearCompleteHandler()
      Call CleanAppointments()
    End Sub

    Private Sub AfterRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      Dim element As Resource = CType(e.BaseObject, Resource)
      Call CleanAppointments(element)
    End Sub

#End Region

#Region "CleanAppointments"

    Private Sub CleanAppointments()

      Try
        'Error Check
        If MainObject Is Nothing Then Return

        'Loop through the appointments and remove 
        'ALL references to ALL Resource objects 
        For Each appointment As Gravitybox.Objects.Appointment In MainObject.AppointmentCollection
          Call appointment.ResourceList.Clear()
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub CleanAppointments(ByVal resource As Resource)

      Try
        'Error Check
        If MainObject Is Nothing Then Return

        'Loop through the appointments and remove the 
        'references the Resource object that was just removed
        For Each appointment As Gravitybox.Objects.Appointment In MainObject.AppointmentCollection
          appointment.ResourceList.RemoveAll(resource)
        Next

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "ToList"

    ''' <summary>
    ''' Converts the collection to a list.
    ''' </summary>
    Public Function ToList() As Gravitybox.Objects.ResourceList

      Try
        Dim list As New Gravitybox.Objects.ResourceList(Me.MainObject, Me)
        Return list
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Loads objects from a list into this collection.
    ''' </summary>
    ''' <param name="list">The source list from which to load</param>
    Public Sub FromList(ByVal list As Gravitybox.Objects.ResourceList)

      Try
        For Each element As BaseObject In list
          Me.AddObject(element)
        Next
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Find"

    'Find categories by text
    Public Function Find(ByVal text As String) As ResourceList

      Try
        Dim element As Gravitybox.Objects.Resource
        Dim retval As New ResourceList(Me.MainObject)
        For Each element In Me
          If (String.Compare(element.Text, text, True) = 0) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

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

      Try

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        'Load the elements
        Dim xmlNode As System.Xml.XmlNode
        For Each xmlNode In XMLDoc.DocumentElement.ChildNodes
          Dim newElement As New Resource
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
