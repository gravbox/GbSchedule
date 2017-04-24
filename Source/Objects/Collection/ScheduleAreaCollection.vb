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

  'This enum describes the area to be colored
  'Depending on the values set, these constants
  'describe the area
  Friend Enum ScheduleAreaTypeConstants
    None = 0
    Day = 1
    Time = 2
    Room = 4
    Provider = 8
    Resource = 16
    DayTime = Day Or Time
    DayRoom = Day Or Room
    DayRoomTime = Day Or Room Or Time
    DayProvider = Day Or Provider
    DayResource = Day Or Resource
    RoomTime = Room Or Time
    RoomDay = Day Or Room
    RoomDayTime = Day Or Room Or Time
    RoomProvider = Room Or Provider
    ProviderTime = Provider Or Time
    ProviderDay = Provider Or Day
    ProviderDayTime = Provider Or Day Or Time
    ResourceTime = Resource Or Time
    DayProviderTime = Day Or Provider Or Time
  End Enum

  <Serializable(), _
  DefaultEvent("Refresh")> _
  Public Class ScheduleAreaCollection
    Inherits Gravitybox.Objects.BaseObjectCollection

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "scheduleareacollection"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Property variables
    Private m_Text As String

    'Internal Objects
    <NonSerialized()> Private MainObject As Controls.Schedule

#End Region

#Region "Constructor"

		'Override constructor so that this object not publically creatable
		Friend Sub New(ByVal mainObject As Controls.Schedule)
			Me.MainObject = mainObject
			AddHandler Me.AfterRemove, AddressOf AfterRemoveHandler
			AddHandler Me.ClearComplete, AddressOf ClearCompleteHandler
		End Sub

#End Region

#Region "OnClear"

		Protected Overrides Sub OnClear()

			MyBase.OnClear()
			Try
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Add Methods"

    'Add - Color, StartDate
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime) As ScheduleArea

			Try
				Return Add(key, backColor, startDate, DefaultNoTime, 0, Nothing, Nothing)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, StartDate, Room
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="room"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal room As Room) As ScheduleArea

      Try
        Return Add(key, backColor, startDate, DefaultNoTime, 0, room, Nothing)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartDate, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal provider As Provider) As ScheduleArea

			Try
				Return Add(key, backColor, startDate, DefaultNoTime, 0, Nothing, provider)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, Room, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="room"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal room As Room, ByVal provider As Provider) As ScheduleArea

      Try
        Return Add(key, backColor, DefaultNoDate, DefaultNoTime, 0, room, provider)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartDate, Room, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="room"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal room As Room, ByVal provider As Provider) As ScheduleArea

			Try
				Return Add(key, backColor, startDate, DefaultNoTime, 0, room, provider)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, StartTime, Length
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startTime As DateTime, ByVal length As Integer) As ScheduleArea

      Try
        Return Add(key, backColor, DefaultNoDate, startTime, length, Nothing, Nothing)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartDate, StartTime, Length
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As ScheduleArea

			Try
				Return Add(key, backColor, startDate, startTime, length, Nothing, Nothing)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, Room
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="room"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal room As Room) As ScheduleArea

      Try
        Return Add(key, backColor, DefaultNoDate, DefaultNoTime, 0, room, Nothing)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal provider As Provider) As ScheduleArea

			Try
				Return Add(key, backColor, DefaultNoDate, DefaultNoTime, 0, Nothing, provider)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, StartTime, Length, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startTime As DateTime, ByVal length As Integer, ByVal provider As Provider) As ScheduleArea

      Try
        Return Add(key, backColor, DefaultNoDate, startTime, length, Nothing, provider)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartTime, Length, Room
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="room"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startTime As DateTime, ByVal length As Integer, ByVal room As Room) As ScheduleArea

			Try
				Return Add(key, backColor, DefaultNoDate, startTime, length, room, Nothing)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

		End Function

    'Add - Color, StartTime, Length, Room, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="room"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startTime As DateTime, ByVal length As Integer, ByVal room As Room, ByVal provider As Provider) As ScheduleArea

      Try
        Return Add(key, backColor, DefaultNoDate, startTime, length, room, provider)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartDate, StartTime, Length, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal provider As Provider) As ScheduleArea

			Try
				Return Add(key, backColor, startDate, startTime, length, Nothing, provider)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    'Add - Color, StartDate, StartTime, Length, Room
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="room"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal room As Room) As ScheduleArea

      Try
        Return Add(key, backColor, startDate, startTime, length, room, Nothing)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add - Color, StartDate, StartTime, Length, Room, Provider
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="backColor"></param>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <param name="room"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function Add(ByVal key As String, ByVal backColor As Color, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal room As Room, ByVal provider As Provider) As ScheduleArea

			Try
				If (key Is Nothing) OrElse (key = "") Then key = Guid.NewGuid.ToString
				'If startDate = Date.MinValue Then startDate = DefaultNoDate
				'If startTime = Date.MinValue Then startTime = DefaultNoTime
				If startDate <> DefaultNoDate Then startDate = GetDate(startDate)
				If startTime <> DefaultNoTime Then startTime = GetTime(startTime)
				If length = Nothing Then length = 60
				If length < 0 Then length = 0
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

			'Error Check
			key = Trim(key)
			If key = "" Then
				Throw New Exceptions.GravityboxException(ErrorStringNoKey)
			ElseIf Contains(key) Then
				Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
			End If

			'Error Check
			If length <= 0 Then
				Throw New Exceptions.GravityboxException("The length property must be greater than 0!")
			End If
			If (startDate = DefaultNoDate) AndAlso (startTime = DefaultNoTime) AndAlso (provider Is Nothing) AndAlso (room Is Nothing) Then
				Throw New Exceptions.GravityboxException("There was not enough information specified to create an area!")
			End If

			Try
				Dim newObject As New ScheduleArea(Me.MainObject, backColor, startDate, startTime, length, room, provider)
				newObject.SetKey(key)
				Return CType(AddObject(newObject), ScheduleArea)
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

      Try
        If newObject.Key = "" Then newObject.SetKey(System.Guid.NewGuid().ToString)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

      Try
        Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(newObject)
        OnBeforeAdd(Me, eventParam1)
        If eventParam1.Cancel Then Return Nothing
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

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

      Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(newObject)
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
    Default Public Shadows ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.ScheduleArea
      Get
        Return CType(MyBase.Item(key), ScheduleArea)
      End Get
    End Property

    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.ScheduleArea
      Get
        Return CType(MyBase.Item(index), ScheduleArea)
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub ClearCompleteHandler()
    End Sub

    Private Sub AfterRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
    End Sub

#End Region

#Region "HitTest"

    Friend Function HitTest(ByVal x As Integer, ByVal y As Integer) As ScheduleArea
      Return HitTest(New Point(x, y))
    End Function

    Friend Function HitTest(ByVal pt As Point) As ScheduleArea

      Try

        'If in the top or left margins then there is nothing to check
        If (pt.X < MainObject.ClientLeft) OrElse (pt.Y < MainObject.ClientTop) Then
          Return Nothing
        End If

        Dim currentDate As DateTime = MainObject.Visibility.GetDateFromCor(pt)
        Dim currentTime As DateTime = MainObject.Visibility.GetTimeFromCor(pt)
        Dim currentRoom As Integer = MainObject.Visibility.GetRoomFromCor(pt)
        Dim currentProvider As Integer = MainObject.Visibility.GetProviderFromCor(pt)
        Dim currentResource As Integer = MainObject.Visibility.GetResourceFromCor(pt)

        For Each area As ScheduleArea In Me
          'Calculate if this area is enabled for an appointment
          If Not MainObject.IsAreaEnabledFromPoint(area, currentDate, currentTime, MainObject.TimeIncrementValue, currentRoom, currentProvider, currentResource) Then
            Return area
          End If
        Next
        Return Nothing

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "ToList"

    ''' <summary>
    ''' Converts the collection to a list.
    ''' </summary>
    Public Function ToList() As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim list As New Gravitybox.Objects.ScheduleAreaList(Me)
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
    Public Sub FromList(ByVal list As Gravitybox.Objects.ScheduleAreaList)

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

    'Find ScheduleAreas by text
    Friend Function Find(ByVal areaType As ScheduleAreaTypeConstants) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim element As Gravitybox.Objects.ScheduleArea
        Dim retval As New ScheduleAreaList
        For Each element In Me
          If element.AreaType = areaType Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date
    Public Function Find(ByVal startDate As Date) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim element As Gravitybox.Objects.ScheduleArea
        Dim retval As New ScheduleAreaList
        For Each element In Me
          If element.StartDate = startDate Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date/time/length
    Public Function Find(ByVal startDate As Date, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startDate, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date/time/room/length
    Public Function Find(ByVal startDate As Date, ByVal startRoom As Room, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startDate, startRoom, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date/room
    Public Function Find(ByVal startDate As Date, ByVal startRoom As Room) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startDate, startRoom) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date/provider
    Public Function Find(ByVal startDate As Date, ByVal startProvider As Provider) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startDate, startProvider) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by date/resource
    Public Function Find(ByVal startDate As Date, ByVal startResource As Resource) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startDate, startResource) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by room/time/length
    Public Function Find(ByVal startRoom As Room, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startRoom, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by resource/time/length
    Public Function Find(ByVal startResource As Resource, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startResource, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by provider/time/length
    Public Function Find(ByVal startProvider As Provider, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startProvider, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by provider/date/time/length
    Public Function Find(ByVal startProvider As Provider, ByVal startDate As DateTime, ByVal startTime As Date, ByVal length As Integer) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        For Each element As Gravitybox.Objects.ScheduleArea In Me
          If element.IsConflict(startProvider, startDate, startTime, length) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Find ScheduleAreas by room
    Public Function Find(ByVal room As Gravitybox.Objects.Room) As Gravitybox.Objects.ScheduleAreaList

      Try
        Dim retval As New ScheduleAreaList
        If Not (room Is Nothing) Then
          Dim element As Gravitybox.Objects.ScheduleArea
          For Each element In Me
            If (0 <= element.Room) AndAlso (element.Room < MainObject.RoomCollection.Count) AndAlso (element.Room = MainObject.RoomCollection.IndexOf(room)) Then
              Call retval.Add(element)
            End If
          Next
        End If
        Return retval

      Catch ex As Exception
        Throw       'call ErrorModule.SetErr(ex)
      End Try

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
          Dim newElement As New ScheduleArea(MainObject)
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
