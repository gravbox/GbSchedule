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
Imports System.ComponentModel.Design.Serialization
Imports Gravitybox.Objects.EventArgs
Imports System.Runtime.CompilerServices

Namespace Gravitybox.Objects

	<Serializable()> _
	Public MustInherit Class BaseList
		Inherits System.Collections.CollectionBase
		Implements IXMLable

#Region "Interface"

		Public MustOverride Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
		Public MustOverride Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML
		Public MustOverride Function SaveXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.SaveXML
		Public MustOverride Function LoadXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.LoadXML

#End Region

#Region "Class Header"

		<NonSerialized()> Private m_MainObject As Gravitybox.Controls.Schedule
		Protected m_Comparer As IComparer

#End Region

#Region "Constructor"

		Friend Sub New()
		End Sub

		Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule, ByVal collection As Gravitybox.Objects.BaseObjectCollection)
			Me.New(collection)
			If schedule Is Nothing Then
				Throw New Exceptions.GravityboxException("This object cannot be created without a parent schedule.")
			End If
			m_MainObject = schedule
		End Sub

		'Override constructor so that this object not publically creatable
		Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule)
			If schedule Is Nothing Then
				Throw New Exceptions.GravityboxException("This object cannot be created without a parent schedule.")
			End If
			m_MainObject = schedule
		End Sub

		Public Sub New(ByVal collection As Gravitybox.Objects.BaseObjectCollection)

			Try
				If collection Is Nothing Then Return
				For Each element As Gravitybox.Objects.BaseObject In collection
					Call Me.Add(element)
				Next
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Events"

		Public Event BeforeAdd As BeforeAddDelegate
		Public Event AfterAdd As AfterAddDelegate
		Public Event BeforeRemove As BeforeRemoveDelegate
		Public Event AfterRemove As AfterRemoveDelegate
		Public Event ValidateRemove As ValidateRemoveDelegate
		Public Event Reload As ReloadDelegate
		Public Event Refresh As RefreshDelegate
		Public Event ClearComplete()

#End Region

#Region "On... Event Methods"

		Protected Friend Sub OnBeforeAdd(ByVal sender As Object, ByVal e As BeforeBaseObjectEventArgs)
			RaiseEvent BeforeAdd(Me, e)
		End Sub

		Protected Friend Sub OnAfterAdd(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			RaiseEvent AfterAdd(Me, e)
		End Sub

		Protected Friend Sub OnBeforeRemove(ByVal sender As Object, ByVal e As BeforeBaseObjectEventArgs)
			RaiseEvent BeforeRemove(Me, e)
		End Sub

		Protected Friend Sub OnAfterRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			RaiseEvent AfterRemove(Me, e)
		End Sub

		Protected Friend Sub OnValidateRemove(ByVal sender As Object, ByVal e As AfterBaseObjectEventArgs)
			RaiseEvent ValidateRemove(Me, e)
		End Sub

		Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Reload(sender, e)
		End Sub

		Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Refresh(sender, e)
		End Sub

#End Region

#Region "Add"

    ''' <summary>
    ''' Adds an existing object to the list.
    ''' </summary>
    ''' <param name="element">The object to add to the collection.</param>
    <Description("Adds an existing object to the list."), Browsable(True)> _
    Public Function Add(ByVal element As Gravitybox.Objects.BaseObject) As Gravitybox.Objects.BaseObject
      Return Add(element, -1)
    End Function

    ''' <summary>
    ''' Adds an existing object to the list at a specific index.
    ''' </summary>
    ''' <param name="element">The object to add to the collection.</param>
    ''' <param name="index">The index in the collection the new object will have.</param>
    <Description("Adds an existing object to the list at a specific index."), _
    Browsable(True), _
    MethodImpl(MethodImplOptions.Synchronized)> _
    Public Function Add(ByVal element As Gravitybox.Objects.BaseObject, ByVal index As Integer) As Gravitybox.Objects.BaseObject

      If Not (element Is Nothing) Then

        'Raise the BeforeAdd event
        Try
          Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(element)
          OnBeforeAdd(Me, eventParam1)
          If eventParam1.Cancel Then Return Nothing
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try

        If index = -1 Then
          MyBase.List.Add(element)
        Else
          MyBase.List.Insert(index, element)
        End If

        'Raise the AfterAdd event
        Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(element)
        OnAfterAdd(Me, eventParam2)

        OnRefresh(Me, New System.EventArgs)

      End If
      Return element

    End Function

    ''' <summary>
    ''' Adds all objects in another list to this list.
    ''' </summary>
    ''' <param name="list">The list of objects to add.</param>
    <Description("Adds all objects in another list to this list."), Browsable(True)> _
    Public Function Add(ByVal list As Gravitybox.Objects.BaseList) As Boolean

      For Each element As Gravitybox.Objects.BaseObject In list
        Me.Add(element, -1)
      Next
      Return True

    End Function

#End Region

#Region "Contains"

		<Description(""), _
		Browsable(True)> _
		Public Function Contains(ByVal index As Integer) As Boolean
			Return (0 <= index) AndAlso (index < Me.Count)
		End Function

		<Description(""), _
		Browsable(True)> _
		Public Function Contains(ByVal value As Gravitybox.Objects.BaseObject) As Boolean
			Try
				Return (Me.IndexOf(value) <> -1)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Function

		<Description(""), _
		Browsable(True)> _
		Public Function Contains(ByVal key As String) As Boolean

			Dim element As BaseObject
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

#End Region

#Region "IndexOf"

		Public Function IndexOf(ByVal item As Gravitybox.Objects.BaseObject) As Integer

			If item Is Nothing Then Return -1
			Try
				Dim retval As Integer

				'Check the Key
				retval = 0
				For Each element As Gravitybox.Objects.BaseObject In Me
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

#Region "Item"

		<Description(""), _
		Browsable(True)> _
		Default Public ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.BaseObject
			Get
				Try
					If (0 <= index) AndAlso (index < Me.Count) Then
						Return CType(MyBase.List(index), Gravitybox.Objects.BaseObject)
					End If
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
				Throw New System.ArgumentOutOfRangeException
			End Get
		End Property

		<Description(""), _
		Browsable(True)> _
		Default Public ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.BaseObject
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

#End Region

#Region "Remove"

    <Description(""), _
    Browsable(True), _
    MethodImpl(MethodImplOptions.Synchronized)> _
    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      If Not ((0 <= index) And (index < Me.Count)) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Dim element As Gravitybox.Objects.BaseObject = Me.Item(index)
        Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(element)
        OnBeforeRemove(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(element)
        OnValidateRemove(Me, eventParam2)

        Call MyBase.RemoveAt(index)

        Dim eventParam3 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(element)
        OnAfterRemove(Me, eventParam3)

        OnRefresh(Me, New System.EventArgs)

        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

		<Description(""), _
		Browsable(True)> _
		Public Shadows Function Remove(ByVal key As String) As Boolean

			Try
				Dim ii As Integer
				For Each element As Gravitybox.Objects.BaseObject In Me
					If (String.Compare(element.Key, key, True) = 0) Then
						Return Me.RemoveAt(ii)
					End If
					ii += 1
				Next
				Return False

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		<Description(""), _
		Browsable(True)> _
		Public Shadows Function Remove(ByVal element As Gravitybox.Objects.BaseObject) As Boolean

			Try
				Dim ii As Integer
				For Each item As Gravitybox.Objects.BaseObject In Me
					If element Is item Then
						Return Me.RemoveAt(ii)
					End If
					ii += 1
				Next
				Return False

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		<Description(""), _
		Browsable(True)> _
		Public Shadows Function RemoveAll(ByVal element As Gravitybox.Objects.BaseObject) As Boolean

			Try
				Dim ii As Integer
				For ii = Me.Count - 1 To 0 Step -1
					If Item(ii).Key = element.Key Then
						Me.RemoveAt(ii)
					End If
				Next
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Sort"

		Public Sub Sort()

			Try
				'Only sort if there is a comparer
				If Not (Me.Comparer Is Nothing) Then
					Dim al As New ArrayList(Me)
					al.Sort(Me.Comparer)
					Call Me.Clear()
					For Each element As Gravitybox.Objects.BaseObject In al
						Call Me.Add(element)
					Next
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Sub

#End Region

#Region "Equals"

		Public Overloads Function Equals(ByVal list As Gravitybox.Objects.BaseList) As Boolean

			Try
				'Make sure the two lists have the same count
				If Me.Count <> list.Count Then Return False

				'If any element does not match then this list is different
				Dim ii As Integer = 0
				For Each element As Gravitybox.Objects.BaseObject In Me
					If Not (element Is list(ii)) Then
						Return False
					End If
				Next

				'All is well. The lists match
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Merge Functions"

		Public Function Intersect(ByVal list As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList
			Return Intersect(Me, list)
		End Function

		Public Function Intersect(ByVal list1 As Gravitybox.Objects.BaseList, ByVal list2 As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList

			If list1 Is Nothing Then Return Nothing
			If list2 Is Nothing Then Return Nothing

			Try
				'Loop through list1 and try to find each element in list2
				'If the element is in BOTH lists then add it to the return list
				Dim retval As BaseList = Me.CloneEmpty
				For Each element As BaseObject In list1
					If list2.Contains(element) Then
						'Do NOT add duplicates!
						If Not retval.Contains(element) Then
							Call retval.Add(element)
						End If
					End If
				Next
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

		Public Function Union(ByVal list As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList
			Return Union(Me, list)
		End Function

		Public Function Union(ByVal list1 As Gravitybox.Objects.BaseList, ByVal list2 As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList

			If list1 Is Nothing Then Return Nothing
			If list2 Is Nothing Then Return Nothing

			Try
				'Loop through list1 and list2 and add all elements to the return list
				Dim retval As BaseList = Me.CloneEmpty
				list1.ToArray()
				For Each element As BaseObject In list1
					'Do NOT add duplicates!
					If Not retval.Contains(element) Then
						Call retval.Add(element)
					End If
				Next

				For Each element As BaseObject In list2
					'Do NOT add duplicates!
					If Not retval.Contains(element) Then
						Call retval.Add(element)
					End If
				Next

				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

		Public Function Subtract(ByVal list As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList
			Return Subtract(Me, list)
		End Function

		Public Function Subtract(ByVal list1 As Gravitybox.Objects.BaseList, ByVal list2 As Gravitybox.Objects.BaseList) As Gravitybox.Objects.BaseList

			If list1 Is Nothing Then Return Nothing
			If list2 Is Nothing Then Return Nothing

			Try
				'Loop through list2 and remove ALL of its elements from list1
				Dim retval As BaseList = Me.CloneEmpty
				For Each element As BaseObject In list1
					'Do NOT add duplicates!
					If Not retval.Contains(element) Then
						Call retval.Add(element)
					End If
				Next

				For Each element As BaseObject In list2
					Call retval.RemoveAll(element)
				Next

				Return retval

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
				For Each element As Gravitybox.Objects.BaseObject In Me
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
				For Each o In array
					Call Me.Add(CType(o, Gravitybox.Objects.BaseObject))
				Next
				OnRefresh(Me, New System.EventArgs)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Property Implementations"

		Public Property Comparer() As IComparer
			Get
				Return m_Comparer
			End Get
			Set(ByVal Value As IComparer)
				m_Comparer = Value
			End Set
		End Property

		Friend Property MainObject() As Gravitybox.Controls.Schedule
			Get
				Return m_MainObject
			End Get
			Set(ByVal Value As Gravitybox.Controls.Schedule)
				m_MainObject = Value
			End Set
		End Property

#End Region

#Region "Clone"

		Private Function CloneEmpty() As BaseList
			Try
				Dim type As System.Type = Me.GetType()
				Dim a As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
				Dim o() As Object = {Me.MainObject}
				Dim retval As BaseList = CType(Activator.CreateInstance(type, o), BaseList)
				retval.MainObject = Me.MainObject
				Return retval
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

#End Region

	End Class

End Namespace