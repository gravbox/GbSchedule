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
Imports System.ComponentModel.Design.Serialization
Imports System.Runtime.CompilerServices

Namespace Gravitybox.Objects

#Region "Delegates"

	'Delegates
	Public Delegate Sub BeforeAddDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
	Public Delegate Sub AfterAddDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
	Public Delegate Sub BeforeRemoveDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
	Public Delegate Sub AfterRemoveDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
  Public Delegate Sub ValidateRemoveDelegate(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
	Public Delegate Sub ReloadDelegate(ByVal sender As Object, ByVal e As System.EventArgs)
	Public Delegate Sub RefreshDelegate(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

	Public MustInherit Class BaseObjectCollection
		Inherits System.Collections.CollectionBase
		Implements IXMLable
		Implements IDisposable

#Region "Interface"
    Protected Friend MustOverride Function AddObject(ByVal element As Gravitybox.Objects.BaseObject) As Gravitybox.Objects.BaseObject
    Protected Friend MustOverride Function AddObject(ByVal element As Gravitybox.Objects.BaseObject, ByVal index As Integer) As Gravitybox.Objects.BaseObject
    ''' <summary>
    ''' Converts the collection to an XML string.
    ''' </summary>
    Public MustOverride Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
    Public MustOverride Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML
    Public MustOverride Function SaveXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.SaveXML
    Public MustOverride Function LoadXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.LoadXML

#End Region

#Region "Class Header"

		'Private Property variables
		Private m_ObjectSingular As String
		Private m_ObjectPlural As String

#End Region

#Region "Events"

		'Public Events
		Public Event BeforeAdd As BeforeAddDelegate
		Public Event AfterAdd As AfterAddDelegate
    Public Event BeforeRemove As BeforeRemoveDelegate
		Public Event AfterRemove As AfterRemoveDelegate
    Public Event ValidateRemove As ValidateRemoveDelegate
    Public Event Reload As ReloadDelegate
		Public Event Refresh As AfterAddDelegate
		Public Event ClearComplete()

    Friend Event InternalAfterAdd As AfterAddDelegate
    Friend Event InternalAfterRemove As AfterRemoveDelegate
    Friend Event InternalClearComplete()

#End Region

#Region "On... Event Methods"

		Protected Friend Sub OnBeforeAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
			RaiseEvent BeforeAdd(Me, e)
		End Sub

		Protected Friend Sub OnAfterAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			RaiseEvent AfterAdd(Me, e)
		End Sub

		Protected Friend Sub OnBeforeRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs)
			RaiseEvent BeforeRemove(Me, e)
		End Sub

		Protected Friend Sub OnAfterRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			RaiseEvent AfterRemove(Me, e)
		End Sub

		Protected Friend Sub OnValidateRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			RaiseEvent ValidateRemove(Me, e)
		End Sub

		Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Reload(sender, e)
		End Sub

		Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			RaiseEvent Refresh(sender, e)
		End Sub

		Protected Overrides Sub OnClear()

			MyBase.OnClear()

			'Dispose if necessary
			For Each bo As BaseObject In Me
				If Not (bo.GetType.GetInterface("IDisposable") Is Nothing) Then
					CType(bo, IDisposable).Dispose()
				End If
			Next

		End Sub

    Protected Overrides Sub OnClearComplete()
      RaiseEvent InternalClearComplete()
      RaiseEvent ClearComplete()
    End Sub

    Protected Friend Sub OnInternalAfterAdd(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      RaiseEvent InternalAfterAdd(Me, e)
    End Sub

    Protected Friend Sub OnInternalAfterRemove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      RaiseEvent InternalAfterRemove(Me, e)
    End Sub

#If VS2005 Then

    <Browsable(False)> _
    Public Overloads Property Capacity() As Integer
      Get
        Return MyBase.Capacity
      End Get
      Set(ByVal value As Integer)
        MyBase.Capacity = value
      End Set
    End Property

#End If

#End Region

#Region "Property Implementations"

		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(""), _
		NotifyParentProperty(True), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
		Description("Determines the text used when labeling 1 object.")> _
		Public Property ObjectSingular() As String
			Get
				Return m_ObjectSingular
			End Get
			Set(ByVal Value As String)
				m_ObjectSingular = Value
			End Set
		End Property

		<Browsable(True), _
		Category("Appearance"), _
		DefaultValue(""), _
		NotifyParentProperty(True), _
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
		Description("Determines the text used when labeling more or less than 1 object.")> _
		Public Property ObjectPlural() As String
			Get
				Return m_ObjectPlural
			End Get
			Set(ByVal Value As String)
				m_ObjectPlural = Value
			End Set
		End Property

#End Region

#Region "Contains"

    ''' <summary>
    ''' Determines if a specific object is in the collection.
    ''' </summary>
    ''' <param name="index">A zero-based index of the item to search for</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Contains(ByVal index As Integer) As Boolean
			Return (0 <= index) AndAlso (index < Me.Count)
		End Function

    ''' <summary>
    ''' Determines if a specific object is in the collection.
    ''' </summary>
    ''' <param name="key">The unique key of the object to search for.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Contains(ByVal key As String) As Boolean

			Dim element As Gravitybox.Objects.BaseObject
			Try
				'Check the Key
				For Each element In Me
					If (String.Compare(element.Key, key, True) = 0) Then
						Return True
					End If
				Next
				Return False

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Function

    ''' <summary>
    ''' Determines if a specific object is in the collection.
    ''' </summary>
    ''' <param name="element">The object to search for.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Contains(ByVal element As Gravitybox.Objects.BaseObject) As Boolean

			If element Is Nothing Then Return False
			Try
				'Look for the object and then its key
				If (Me.IndexOf(element) <> -1) Then
					Return True
				Else
					Return Contains(element.Key)
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Count"

    ''' <summary>
    ''' Determines the number of items in this collection.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
		<Browsable(False)> _
		Public Shadows ReadOnly Property Count() As Integer
			Get
				Return MyBase.List.Count
			End Get
		End Property

#End Region

#Region "IndexOf"

    ''' <summary>
    ''' Determines the index in the collection of the object.
    ''' </summary>
    ''' <param name="key">A unique key identifying a collection object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IndexOf(ByVal key As String) As Integer

			Try
				'Check the Key
				Dim retval As Integer = 0
				For Each element As Gravitybox.Objects.BaseObject In Me
					If (String.Compare(element.Key, key, True) = 0) Then
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

    ''' <summary>
    ''' Determines the index in the collection of the object.
    ''' </summary>
    ''' <param name="element">The object to check.</param>
    Public Function IndexOf(ByVal element As Gravitybox.Objects.BaseObject) As Integer

      If element Is Nothing Then Return -1
      Try
        Dim retval As Integer

        'Check the Key
        retval = 0
        For Each item As Gravitybox.Objects.BaseObject In Me
          If (String.Compare(element.Key, item.Key, True) = 0) Then
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

#Region "UpdateCollection"

		Friend Sub UpdateCollection(ByVal newCollection As Gravitybox.Objects.BaseObjectCollection, ByVal dirtyKeys As Hashtable)

			Try
				Dim ii As Integer
				'Remove all objects that are not needed
				For ii = Me.Count - 1 To 0 Step -1
					If Not newCollection.Contains(Me(ii).Key) Then
						Call Me.RemoveAt(ii)
					End If
				Next

				'Add the new objects
				For ii = 0 To newCollection.Count - 1
					If Not Me.Contains(newCollection(ii).Key) Then
						Call Me.AddObject(newCollection(ii), ii)
					End If
				Next

				'Update all objects
				Dim keys As IEnumerable = dirtyKeys.Keys
				For Each key As String In keys
					If newCollection.Contains(key) Then
						Dim element As Gravitybox.Objects.BaseObject = newCollection(key)
						Me.Item(element.Key).FromXML(element.ToXML, True, False)
					End If
				Next

				'Reorder All
				Dim jj As Integer = 0
				For Each element As BaseObject In newCollection
					Dim index As Integer = Me.IndexOf(element.Key)
					Me.SetIndex(index, jj)
					jj += 1
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "SetIndex"

    ''' <summary>
    ''' This method reorders the collection by moving one object to another position in the collection.
    ''' </summary>
    ''' <param name="index">The index of the object to reset.</param>
    ''' <param name="newIndex">The new index of the object.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function SetIndex(ByVal index As Integer, ByVal newIndex As Integer) As Boolean

			Try
				If index = newIndex Then Return False

				'Verify that the indexes is valid
				If Me.Contains(index) AndAlso Me.Contains(newIndex) Then
					Dim element As Gravitybox.Objects.BaseObject = Me.Item(index)
					Call MyBase.RemoveAt(index)
					MyBase.List.Insert(newIndex, element)
					Return True
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
			Return False

		End Function

#End Region

#Region "Item"

    ''' <summary>
    ''' Returns the object that matches the unique key.
    ''' </summary>
    ''' <param name="key">The key of the item to retrieve.</param>
    ''' <returns>The matching object or null if no match is found.</returns>
    Default Public Overridable ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.BaseObject
      Get
        Try
          'Loop for Key
          For Each element As Gravitybox.Objects.BaseObject In Me
            If (String.Compare(element.Key, key, True) = 0) Then
              Return element
            End If
          Next

        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Overridable ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.BaseObject
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), BaseObject)
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

#End Region

#Region "Reset Key"

    ''' <summary>
    ''' This method will rest the key of an object.
    ''' </summary>
    ''' <param name="element">The element on which to change the key.</param>
    ''' <param name="newKey">The new key for the specified object.</param>
    ''' <remarks>The key is a unique identifier that is read-only for the object. This is the only way to reset a key once an object has been created.</remarks>
    Public Function ResetKey(ByVal element As Gravitybox.Objects.BaseObject, ByVal newKey As String) As Boolean

      'Error Check
      If (element Is Nothing) Then Return False
      If (newKey.Trim = "") Then Return False
      If Not Me.Contains(element) Then Return False

      'If case changed then reset
      If (String.Compare(element.Key, newKey, True) = 0) Then
        element.SetKey(newKey)
        Return True
      End If

      'If the key exists then ERROR!
      If Me.Contains(newKey) Then
        Throw New Exceptions.GravityboxException("Duplicate key!")
        Return False
      End If

      'Reset the key
      element.SetKey(newKey)

    End Function

#End Region

#Region "Remove"

    ''' <summary>
    ''' Removes an object from the collection.
    ''' </summary>
    ''' <param name="index">A zero-based index of the item to remove.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <MethodImpl(MethodImplOptions.Synchronized)> _
    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      If Not Contains(index) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Dim element As Gravitybox.Objects.BaseObject
        element = Me.Item(index)

        Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(element)
        OnBeforeRemove(Me, eventParam1)
        If eventParam1.Cancel Then Return False
        If Not Me.Contains(element) Then Return False

        Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(element)
        OnValidateRemove(Me, eventParam2)
        If Not Me.Contains(element) Then Return False

        If (0 <= index) AndAlso (index < Me.Count) Then
          RemoveHandler element.Refresh, AddressOf OnRefresh
          Call MyBase.RemoveAt(index)
          element.BaseCollection = Nothing
          OnInternalAfterRemove(Me, eventParam2)
          OnAfterRemove(Me, eventParam2)
					OnRefresh(Me, New AfterBaseObjectEventArgs(element))

					'Dispose if necessary
					If Not (element.GetType.GetInterface("IDisposable") Is Nothing) Then
						CType(element, IDisposable).Dispose()
					End If

          Return True
        End If
        Return False

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Removes an object from the collection
    ''' </summary>
    ''' <param name="key">The unique key that identifies na object in the collection.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function Remove(ByVal key As String) As Boolean

      If Not Contains(key) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Dim index As Integer = IndexOf(Item(key))
        Return Me.RemoveAt(index)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Removes an object from the collection.
    ''' </summary>
    ''' <param name="element">The object to remove from this collection.</param>
    Public Shadows Function Remove(ByVal element As Gravitybox.Objects.BaseObject) As Boolean

      'Make sure it is in this collection
      If Not Contains(element) Then Return False

      'Make sure that is has a parent
      Dim index As Integer = IndexOf(element)
      If index = -1 Then Return False

      'Remove the actual item
      Return RemoveAt(index)

    End Function

#End Region

#Region "Array Methods"

    ''' <summary>
    ''' Create an arraylist of all objects in the collection.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ToArray() As ArrayList

      Try
        Dim array As ArrayList = New ArrayList
        Dim element As Gravitybox.Objects.BaseObject
        For Each element In Me
          Call array.Add(element)
        Next
        Return array
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Populates the collection from an ArrayList of properly typed objects.
    ''' </summary>
    ''' <param name="array"></param>
    ''' <remarks></remarks>
    Public Sub FromArray(ByVal array As ArrayList)

      Try
        Dim o As Object
        Dim element As Gravitybox.Objects.BaseObject
        For Each o In array
          element = CType(o, Gravitybox.Objects.BaseObject)
          Call Me.AddObject(element)
          OnRefresh(Me, New AfterBaseObjectEventArgs(element))
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Dispose"

    Protected Friend Overridable Sub Dispose() Implements IDisposable.Dispose
    End Sub

#End Region

  End Class

End Namespace