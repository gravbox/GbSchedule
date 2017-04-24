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
Imports System.ComponentModel

Namespace Gravitybox.Objects

  <Serializable(), _
  DefaultEvent("Refresh")> _
  Public Class IconCollection
    Inherits Gravitybox.Objects.BaseObjectCollection

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "iconcollection"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

#End Region

#Region "Constructor"

		'Override constructor so that this object not publically creatable
		Friend Sub New()
			Me.ObjectSingular = "Icon"
			Me.ObjectPlural = "Icons"
			AddHandler Me.AfterRemove, AddressOf AfterRemoveHandler
			AddHandler Me.ClearComplete, AddressOf ClearCompleteHandler
		End Sub

#End Region

#Region "Add Methods"

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="icon">The associated icon of this object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal icon As System.Drawing.Icon) As IconItem
      Return Add(key, icon, New Size(0, 0), -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="icon">The associated icon of this object.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal icon As System.Drawing.Icon, ByVal index As Integer) As IconItem
      Return Add(key, icon, New Size(0, 0), index)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="icon">The associated icon of this object.</param>
    ''' <param name="size">The size of the icon.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal icon As System.Drawing.Icon, ByVal size As System.Drawing.Size) As IconItem
      Return Add(key, icon, size, -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="icon">The associated icon of this object.</param>
    ''' <param name="size">The size of the icon.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal icon As System.Drawing.Icon, ByVal size As System.Drawing.Size, ByVal index As Integer) As IconItem

			Dim newObject As New IconItem
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

			Try
				'Create the object and add it to the collections
				If (size.Width > 0) AndAlso (size.Height > 0) Then
					If (icon.Width <> size.Width) OrElse (icon.Height <> size.Height) Then
            icon = New System.Drawing.Icon(icon, size)
					End If
				End If

				'Create the object and add it to the collections
				Call newObject.SetKey(key)
				newObject.Icon = icon
				Return CType(AddObject(newObject, index), Gravitybox.Objects.IconItem)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="image"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal image As System.Drawing.Image) As IconItem
      Return Add(key, image, New Size(0, 0), -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="image"></param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal image As System.Drawing.Image, ByVal index As Integer) As IconItem
      Return Add(key, image, New Size(0, 0), index)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="image"></param>
    ''' <param name="size">The size of the icon.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal image As System.Drawing.Image, ByVal size As System.Drawing.Size) As IconItem
      Return Add(key, image, size, -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="image"></param>
    ''' <param name="size">The size of the icon.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal image As System.Drawing.Image, ByVal size As System.Drawing.Size, ByVal index As Integer) As IconItem

			Try
				'This will convert the specified Image to an Icon
				Dim myBitmap As Bitmap = New Bitmap(image)
				Dim iPtr As System.IntPtr = myBitmap.GetHicon()
				Dim myIcon As Icon = System.Drawing.Icon.FromHandle(iPtr)
				Dim retval As IconItem = Add(key, myIcon, size, index)
				myBitmap = Nothing
				myIcon = Nothing
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="bitmap">The associated image of this object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal bitmap As System.Drawing.Bitmap) As IconItem
      Return Add(key, bitmap, New Size(0, 0), -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="bitmap">The associated image of this object.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal bitmap As System.Drawing.Bitmap, ByVal index As Integer) As IconItem
      Return Add(key, bitmap, New Size(0, 0), index)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="bitmap">The associated image of this object.</param>
    ''' <param name="size">The size of the icon.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal bitmap As System.Drawing.Bitmap, ByVal size As System.Drawing.Size) As IconItem
      Return Add(key, bitmap, size, -1)
    End Function

    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="bitmap">The associated image of this object.</param>
    ''' <param name="size">The size of the icon.</param>
    ''' <param name="index">The index in the collection to insert the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal bitmap As System.Drawing.Bitmap, ByVal size As System.Drawing.Size, ByVal index As Integer) As IconItem

			Try
				'This will convert the specified Image to an Icon
				Dim iPtr As System.IntPtr = bitmap.GetHicon()
				Dim myIcon As Icon = System.Drawing.Icon.FromHandle(iPtr)
				Dim retval As IconItem = Add(key, myIcon, size, index)
				myIcon = Nothing
				Return retval

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

      If (index < -1) Or (index > Me.Count) Then
        'Subscript out of range
        Throw New System.ArgumentOutOfRangeException
      End If

      Try

        If newObject.Key = "" Then newObject.SetKey(System.Guid.NewGuid().ToString)

        Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(newObject)
        OnBeforeAdd(Me, eventParam1)
        If eventParam1.Cancel Then Return Nothing

        AddHandler newObject.Refresh, AddressOf OnRefresh
        If index = -1 Then
          MyBase.List.Add(newObject)
        Else
          MyBase.List.Insert(index, newObject)
        End If
        newObject.BaseCollection = Me

        Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(newObject)
        OnInternalAfterAdd(Me, eventParam2)
        OnAfterAdd(Me, eventParam2)
        OnRefresh(Me, New AfterBaseObjectEventArgs(newObject))

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return newObject

    End Function

#End Region

#Region "Item"

    ''' <summary>
    ''' Returns the object that matches the unique key.
    ''' </summary>
    ''' <param name="key">The key of the item to retrieve.</param>
    ''' <returns>The matching object or null if no match is found.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.IconItem
      Get
        Return CType(MyBase.Item(key), IconItem)
      End Get
    End Property

    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.IconItem
      Get
        Return CType(MyBase.Item(index), IconItem)
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub ClearCompleteHandler()
    End Sub

    Private Sub AfterRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
    End Sub

#End Region

#Region "Dispose"

    Protected Friend Overrides Sub Dispose()
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
          Dim newElement As New IconItem
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
