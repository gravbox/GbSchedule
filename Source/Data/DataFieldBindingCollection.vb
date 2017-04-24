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
Imports Gravitybox.Objects

Namespace Gravitybox.Data

  <Serializable()> _
  Public Class DataFieldBindingCollection
		Inherits System.Collections.CollectionBase
		Implements IXMLable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "DataFieldBindingCollection"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

#End Region

#Region "Add Methods"

    Public Function Add(ByVal propertyName As String, ByVal dataMember As String) As DataBinding

      Dim newObject As New DataBinding
      newObject.PropertyName = propertyName
      newObject.DataMember = dataMember
      Return Me.Add(newObject)

    End Function

    Public Function Add(ByVal dataBinding As DataBinding) As DataBinding

      'Cannot add to 2 collections
      If dataBinding.Locked Then
        Throw New Exceptions.GravityboxException("The specified object is already a member of a collection!")
      End If

      'Cannot add the same property name twice
      If Me.Contains(dataBinding.PropertyName) Then
        Throw New Exceptions.GravityboxException("A mapping has already been added for this property!")
      End If

      dataBinding.Locked = True
      MyBase.List.Add(dataBinding)
      Return dataBinding

    End Function

#End Region

#Region "Count"

    <Browsable(False)> _
    Public Shadows ReadOnly Property Count() As Integer
      Get
        Return MyBase.Count
      End Get
    End Property

#End Region

#Region "Contains"

    Public Function Contains(ByVal propertyName As String) As Boolean

      Try
        'Check the Key
        For Each element As DataBinding In Me
          If (String.Compare(element.PropertyName, propertyName, True) = 0) Then
            Return True
          End If
        Next

        Return False

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Function Contains(ByVal index As Integer) As Boolean
      Return (0 <= index) AndAlso (index < Me.Count)
    End Function

		Public Function Contains(ByVal element As DataBinding) As Boolean
			If element Is Nothing Then Return False
			Try
				'Look for the object and then its key
				If (Me.IndexOf(element) <> -1) Then
					Return True
				Else
					Return Contains(element.PropertyName)
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Function

    Friend Function ContainsDataMember(ByVal dataMember As String) As Boolean

      Try
        'Check the Key
        For Each element As DataBinding In Me
          If (String.Compare(element.DataMember, dataMember, True) = 0) Then
            Return True
          End If
        Next

        Return False

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Item"

    Default Public ReadOnly Property Item(ByVal propertyName As String) As DataBinding
      Get
        Try

          'Loop for PropertyName
          For Each element As DataBinding In Me
            If (String.Compare(element.PropertyName, propertyName, True) = 0) Then
              Return element
            End If
          Next

        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

    Default Public ReadOnly Property Item(ByVal index As Integer) As DataBinding
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), DataBinding)
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

#End Region

#Region "IndexOf"

    Public Function IndexOf(ByVal dataBinding As DataBinding) As Integer

      Try
        Dim element As dataBinding
        Dim retval As Integer

        'Check the Key
        retval = 0
        For Each element In Me
          If (String.Compare(element.PropertyName, dataBinding.PropertyName, True) = 0) Then
            Return retval
          End If
          retval += 1
        Next
        retval = -1
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "RemoveAt"

    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      If Not Contains(index) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Dim element As DataBinding = Item(index)
        Call MyBase.RemoveAt(index)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Shadows Function Remove(ByVal propertyName As String) As Boolean

      If Not Contains(propertyName) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Dim index As Integer = IndexOf(Item(propertyName))
        Return Me.RemoveAt(index)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Shadows Function Remove(ByVal value As DataBinding) As Boolean

      'Make sure it is in this collection
      If Not Contains(value) Then Return False

      'Make sure that is has a parent
      Dim index As Integer = IndexOf(value)
      If index = -1 Then Return False

      'Remove the actual item
      Return RemoveAt(index)

    End Function

#End Region

#Region "GetPropertyName"

    Friend Function GetPropertyName(ByVal dataMember As String) As String

      Try
        'Check the Key
        For Each element As DataBinding In Me
          If (String.Compare(element.DataMember, dataMember, True) = 0) Then
            Return element.PropertyName
          End If
        Next
        Return ""

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "Array Methods"

    Public Function ToArray() As ArrayList

      Try
        Dim array As ArrayList = New ArrayList
        Dim element As DataBinding
        For Each element In Me
          Call array.Add(element)
        Next
        Return array
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Sub FromArray(ByVal array As ArrayList)

      Try
        Dim o As Object
        Dim element As DataBinding
        For Each o In array
          element = CType(o, DataBinding)
          Call Me.Add(element)
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

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

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        'Load the elements
        Dim xmlNode As System.Xml.XmlNode
        For Each xmlNode In XMLDoc.DocumentElement.ChildNodes
          Dim newElement As New DataBinding
          Call newElement.FromXML(xmlNode.OuterXml)
          Call Me.Add(newElement)
        Next

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