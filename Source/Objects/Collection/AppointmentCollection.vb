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
	DefaultEvent("Refresh")> _
	Public Class AppointmentCollection
    Inherits Gravitybox.Objects.BaseObjectCollection

#Region "Class Members"

		Friend Const MyXMLNodeName As String = "appointmentcollection"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"
		Private Const StaggerSize As Integer = 12

		'Private Property variables
		<NonSerialized()> Private MainObject As Gravitybox.Controls.Schedule
		Private m_CancelEvents As Boolean = False
		<NonSerialized()> Private m_EventAppointmentCount As Integer = 0

#End Region

#Region "Constructor"

		'Override constructor so that this object not publically creatable
		Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
			Me.MainObject = mainObject
			Me.ObjectSingular = "Appointment"
			Me.ObjectPlural = "Appointments"
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

#Region "Property Implementations"

    Friend Property CancelEvents() As Boolean
      Get
        Return m_CancelEvents
      End Get
      Set(ByVal Value As Boolean)
        m_CancelEvents = Value
      End Set
    End Property

		Friend Property EventAppointmentCount() As Integer
			Get
				Return m_EventAppointmentCount
			End Get
			Set(ByVal Value As Integer)
				If m_EventAppointmentCount <> Value Then
					m_EventAppointmentCount = Value
				End If
			End Set
		End Property

#End Region

#Region "Add Methods"

    'Add -- Date/Room/Time/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal room As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal index As Integer) As Appointment

      Dim newObject As New Appointment(Me.MainObject)

      'Error Check the StartTime
      startTime = GetTime(startTime)
      If Not ((PivotTime <= startTime) And (startTime <= #11:59:59 PM#)) Then
        Throw New Exceptions.GravityboxException("The start time is out of range!")
      End If

      'Error Check the Length
      If length <= 0 Then
        Throw New Exceptions.GravityboxException("The appointment length must be greater than 0!")
      End If

      If key <> "" Then
        'Error check that the new key does not exist
        If Contains(key) Then
          Throw New Exceptions.GravityboxException(ErrorStringDuplicateKeyCollection)
        End If
        Call newObject.SetKey(key)
      Else
        key = newObject.Key
      End If

      'Setup the appearance
      If (MainObject.UseDefaultAppearances) Then
        newObject.ResetAppearance(MainObject.DefaultAppointmentAppearance, MainObject.DefaultAppointmentHeaderAppearance)
      End If

      'Setup data properties
      newObject.StartDate = startDate
      newObject.StartTime = startTime
      newObject.Length = length
      newObject.Room = Room

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
        Return CType(AddObject(newObject, index), Gravitybox.Objects.Appointment)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Date/Room/Time(string)/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal room As Room, ByVal startTime As String, ByVal length As Integer, ByVal index As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, startDate, Room, st, length, index)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Date/Room/Time
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal room As Room, ByVal startTime As DateTime, ByVal length As Integer) As Appointment
      Return Add(key, startDate, Room, startTime, length, -1)
    End Function

    'Add -- Date/Room/Time(String)
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal room As Room, ByVal startTime As String, ByVal length As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, startDate, Room, st, length, -1)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Date/Room
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal room As Room) As Appointment
      Return Add(key, startDate, Room, PivotTime, MainObject.TimeIncrement, -1)
    End Function

    'Add -- Date/Time/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal index As Integer) As Appointment
      Return Add(key, startDate, Nothing, startTime, length, index)
    End Function

    'Add -- Date/Time(string)/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal startTime As String, ByVal length As Integer, ByVal index As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, startDate, Nothing, st, length, index)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Date/Time
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Appointment
      Return Add(key, startDate, Nothing, startTime, length, -1)
    End Function

    'Add -- Date/Time(string)
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="startDate">The starting date of the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal startDate As DateTime, ByVal startTime As String, ByVal length As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, startDate, Nothing, st, length, -1)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Room/Time/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal room As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal index As Integer) As Appointment
      Return Add(key, DefaultNoDate, room, startTime, length, index)
    End Function

    'Add -- Room/Time(string)/Index
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <param name="index">The index in the collection to insert the appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal room As Room, ByVal startTime As String, ByVal length As Integer, ByVal index As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, DefaultNoDate, Room, st, length, index)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- Room/Time
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal room As Room, ByVal startTime As DateTime, ByVal length As Integer) As Appointment
      Return Add(key, DefaultNoDate, room, startTime, length, -1)
    End Function

    'Add -- Room/Time(string)
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="key">The unique identifier for the new object. Use an empty string to generate a new key.</param>
    ''' <param name="room">The Room object to associate with the appointment.</param>
    ''' <param name="startTime">The starting time of the appointment.</param>
    ''' <param name="length">The length in minutes of the new appointment.</param>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add(ByVal key As String, ByVal room As Room, ByVal startTime As String, ByVal length As Integer) As Appointment

      Dim st As Date
      Try
        st = DateTime.Parse(startTime)
        st = GetTime(st)
      Catch ex As Exception
        Throw New Exceptions.GravityboxException(ErrorConvertStartTime & vbCrLf & "StartTime:" & startTime)
      End Try

      Try
        Return Add(key, DefaultNoDate, Room, st, length, -1)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Add -- No Parameters
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <returns>A newly created appointment object.</returns>
    Public Function Add() As Appointment
      Return Add(Guid.NewGuid().ToString(), #1/1/1980#, Nothing, PivotTime, MainObject.TimeIncrement, -1)
    End Function

    'Add
    ''' <summary>
    ''' Adds a new object to the collection.
    ''' </summary>
    ''' <param name="appointment">This object to add to this collection.</param>
    ''' <returns>A newly added appointment object.</returns>
    Public Function Add(ByVal appointment As Gravitybox.Objects.Appointment) As Appointment

      If appointment Is Nothing Then
        Throw New Exceptions.GravityboxException("The specified appointment cannot be null!")
      End If

      Return CType(AddObject(appointment), Gravitybox.Objects.Appointment)

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

      'Raise the BeforeAdd event
      Try
        If Not Me.CancelEvents Then
          Dim eventParam1 As BeforeBaseObjectEventArgs = New BeforeBaseObjectEventArgs(newObject)
          OnBeforeAdd(Me, eventParam1)
          If eventParam1.Cancel Then Return Nothing
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

      'Insert the item
      Try
        If Not (Me.MainObject Is Nothing) Then
          CType(newObject, Appointment).MainObject = Me.MainObject
        End If
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

      'Raise the AfterAdd event
      If Not Me.CancelEvents Then
        Dim eventParam2 As AfterBaseObjectEventArgs = New AfterBaseObjectEventArgs(newObject)
        OnInternalAfterAdd(Me, eventParam2)
        OnAfterAdd(Me, eventParam2)
        OnRefresh(Me, New AfterBaseObjectEventArgs(newObject))
      End If

      Return newObject

    End Function

#End Region

#Region "Add Recurrence"

    Public Function AddRecurrence(ByVal appointment As Appointment, ByVal recurrence As Recurrence) As Boolean

      Dim startDate As DateTime
      Dim endDate As DateTime
      Dim retval As Boolean
      Dim oldAutoredraw As Boolean

      If appointment Is Nothing Then
        Throw New Gravitybox.Exceptions.GravityboxException("The Appointment object must be set when adding a recurrence pattern!")
      ElseIf recurrence Is Nothing Then
        Throw New Gravitybox.Exceptions.GravityboxException("The Recurrence object must be set when adding a recurrence pattern!")
      End If

      'Make sure that the Recurrence object is valid
      If Not recurrence.IsValid Then
        Throw New Exceptions.GravityboxException("This is not a valid Recurrence object!")
      End If

      Try

        'Cache the Start and End range
        startDate = recurrence.StartDate
        Select Case recurrence.EndType
          Case RecurrenceEndConstants.EndByInterval
            endDate = DateTime.MaxValue      'MainObject.MaxDate
          Case RecurrenceEndConstants.EndByDate
            endDate = recurrence.EndDate
        End Select

        'Based on the Interval type add the specified recurrnces
        'Me.CancelEvents = True
        oldAutoredraw = MainObject.AutoRedraw
        MainObject.AutoRedraw = False
        appointment.ResetRecurrenceStamp()
        Select Case recurrence.RecurrenceInterval
          Case RecurrenceIntervalConstants.Daily
            retval = AddRecurrenceDay(appointment, recurrence, appointment.StartDate, startDate, endDate)
          Case RecurrenceIntervalConstants.Weekly
            retval = AddRecurrenceWeek(appointment, recurrence, appointment.StartDate, startDate, endDate)
          Case RecurrenceIntervalConstants.Monthly
            retval = AddRecurrenceMonth(appointment, recurrence, appointment.StartDate, startDate, endDate)
          Case RecurrenceIntervalConstants.Yearly
            retval = AddRecurrenceYear(appointment, recurrence, appointment.StartDate, startDate, endDate)
          Case Else
            retval = False
        End Select

        'If this recurrence pattern was added then append this recurrence 
        'object to the RecurrenceCollection collection for later reference
        If retval Then
          If Me.MainObject.RecurrenceCollection.Contains(recurrence) Then
            Me.MainObject.RecurrenceCollection(recurrence.Key).FromXML(recurrence.ToXML)
          Else
            Call Me.MainObject.RecurrenceCollection.AddObject(recurrence)
          End If
          appointment.Recurrence = recurrence
        End If

        'Me.CancelEvents = False
        MainObject.AutoRedraw = oldAutoredraw

        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

      Me.CancelEvents = False

    End Function

    Private Function AddRecurrenceDay(ByVal appointment As Appointment, _
     ByVal recurrence As Recurrence, _
     ByVal origDate As DateTime, _
     ByVal startDate As DateTime, _
     ByVal endDate As DateTime) As Boolean

      Dim dtCurrent As DateTime
      Dim cloneAppointment As Appointment
      Dim recurrenceDay As RecurrenceDay
      Dim maxCount As Long
      Dim tempAppointments As AppointmentCollection
      Dim loopAppointment As Appointment

      Try

        tempAppointments = New AppointmentCollection(Me.MainObject)
        tempAppointments.CancelEvents = True

        'Get a handle to the recurrence object
        recurrenceDay = recurrence.RecurrenceDay

        '********************************************************
        'Add specified number of appts every "X" days
        If (recurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval) And (recurrence.EndType = RecurrenceEndConstants.EndByInterval) Then

          dtCurrent = startDate
          maxCount = 0
          While (maxCount < CLng(recurrence.EndIterations) - 1)
            If Not DateMatch(dtCurrent, origDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = dtCurrent
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                maxCount += 1
              End If
            End If
            dtCurrent = GetDate(DateAdd(DateInterval.Day, recurrenceDay.DayInterval, dtCurrent))
          End While

          '********************************************************
          'Add specified number of appts in a date range
        ElseIf (recurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval) And _
         (recurrence.EndType = RecurrenceEndConstants.EndByDate) Then

          dtCurrent = startDate
          While ((dtCurrent < endDate) Or DateMatch(dtCurrent, endDate))
            If Not DateMatch(dtCurrent, origDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = dtCurrent
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
              End If
            End If
            dtCurrent = GetDate(DateAdd(DateInterval.Day, recurrenceDay.DayInterval, dtCurrent))
          End While

          '********************************************************
          'Add appts on weekdays for "X" appts
        ElseIf (recurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayWeekdays) And (recurrence.EndType = RecurrenceEndConstants.EndByInterval) Then

          maxCount = 0
          dtCurrent = startDate
          While maxCount < CLng(recurrence.EndIterations) - 1
            'If this is NOT a weekend then add the appointment
            If Not ((Weekday(dtCurrent, vbUseSystemDayOfWeek) = vbSaturday) Or (Weekday(dtCurrent, vbUseSystemDayOfWeek) = vbSunday)) Then
              If Not DateMatch(dtCurrent, origDate) Then
                cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
                cloneAppointment.StartDate = dtCurrent
                cloneAppointment.Recurrence = recurrence
                If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                  Call tempAppointments.AddObject(cloneAppointment)
                  recurrence.LastCreateDate = cloneAppointment.StartDate
                  recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                  maxCount += 1                 'Inc the count
                End If
              End If
            End If
            dtCurrent = DateAdd(DateInterval.Day, 1, dtCurrent)
          End While

          '********************************************************
          'Add appts on weekdays for date range
        ElseIf (recurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayWeekdays) And _
         (recurrence.EndType = RecurrenceEndConstants.EndByDate) Then

          maxCount = 0
          dtCurrent = startDate
          While (dtCurrent < endDate) Or DateMatch(dtCurrent, endDate)
            'If this is NOT a weekend then add the appointment
            If Not ((Weekday(dtCurrent, vbUseSystemDayOfWeek) = vbSaturday) Or (Weekday(dtCurrent, vbUseSystemDayOfWeek) = vbSunday)) Then
              If Not DateMatch(dtCurrent, origDate) Then
                cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
                cloneAppointment.StartDate = dtCurrent
                cloneAppointment.Recurrence = recurrence
                If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                  Call tempAppointments.AddObject(cloneAppointment)
                  recurrence.LastCreateDate = cloneAppointment.StartDate
                  recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                  maxCount += 1                 'Inc the count
                End If
              End If
            End If
            dtCurrent = DateAdd(DateInterval.Day, 1, dtCurrent)
          End While

        End If

        'If we are REALLY adding then do so
        If Not recurrence.CheckOnly Then
          'If everything is Ok then add the
          'appointments to the real collection
          For Each loopAppointment In tempAppointments
            Call AddObject(loopAppointment)
            loopAppointment.Recurrence = recurrence
            loopAppointment.MainObject = Me.MainObject
            loopAppointment.ResetRecurrenceStamp(loopAppointment.GetRecurrenceStamp)
            Call loopAppointment.CalculateSortIndexes()
            loopAppointment.OnRefresh(loopAppointment, New AfterBaseObjectEventArgs(loopAppointment))
          Next
        End If

        'Everything OK
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Private Function AddRecurrenceWeek(ByVal appointment As Appointment, _
     ByVal recurrence As Recurrence, _
     ByVal origDate As DateTime, _
     ByVal startDate As DateTime, _
     ByVal endDate As DateTime) As Boolean

      Dim ii As Long
      Dim currentDate As DateTime
      Dim checkDate As DateTime
      Dim cloneAppointment As Appointment
      Dim recurrenceWeek As RecurrenceWeek
      Dim maxCount As Long
      Dim tempAppointments As AppointmentCollection
      Dim loopAppointment As Appointment

      Try

        tempAppointments = New AppointmentCollection(Me.MainObject)
        tempAppointments.CancelEvents = True

        'Get a handle to the recurrence object
        recurrenceWeek = recurrence.RecurrenceWeek

        '********************************************************
        'Add specified number of appts every "X" weeks (for each day of week)
        If (recurrence.EndType = RecurrenceEndConstants.EndByInterval) Then

          maxCount = 0
          'Get the start (Sunday) of the week
          currentDate = DateAdd(DateInterval.Day, -(Weekday(startDate, vbUseSystemDayOfWeek) - 1), startDate)
          While maxCount < CLng(recurrence.EndIterations) - 1

            For ii = 1 To DaysPerWeek
              'This is the date for the weekday we are checking
              checkDate = DateAdd(DateInterval.Day, ii - 1, currentDate)

              'If this is NOT a weekend then add the appointment
              If (((Weekday(checkDate, vbUseSystemDayOfWeek) = vbSunday) And recurrenceWeek.UseSun) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbMonday) And recurrenceWeek.UseMon) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbTuesday) And recurrenceWeek.UseTue) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbWednesday) And recurrenceWeek.UseWed) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbThursday) And recurrenceWeek.UseThu) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbFriday) And recurrenceWeek.UseFri) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbSaturday) And recurrenceWeek.UseSat)) And _
               (maxCount < CLng(recurrence.EndIterations) - 1) Then

                'Do not add appointment to the very first day
                'since once already exists there anyway
                If (Not DateMatch(checkDate, origDate)) And ((checkDate > startDate) Or DateMatch(checkDate, startDate)) Then
                  cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
                  cloneAppointment.StartDate = checkDate
                  cloneAppointment.Recurrence = recurrence
                  If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                    Call tempAppointments.AddObject(cloneAppointment)
                    recurrence.LastCreateDate = cloneAppointment.StartDate
                    recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                    maxCount += 1                   'Inc the count
                  End If
                End If

              End If
            Next            'ii 'Days per week

            'Now increment the current date by "X" weeks
            'where "X" was specified in the Recurrence object
            currentDate = DateAdd(DateInterval.Day, recurrenceWeek.WeekInterval * DaysPerWeek, currentDate)

            'This will end the loop if we can not add this many appointemnts
            If (currentDate > endDate) Then maxCount = CLng(recurrence.EndIterations) - 1

          End While

          '********************************************************
          'Add specified number of appts in a date range
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByDate) Then

          'Get the start (Sunday) of the week
          currentDate = DateAdd(DateInterval.Day, -(Weekday(startDate, vbUseSystemDayOfWeek) - 1), startDate)
          While (currentDate < endDate) Or DateMatch(currentDate, endDate)

            For ii = 1 To DaysPerWeek
              'This is the date for the weekday we are checking
              checkDate = DateAdd(DateInterval.Day, ii - 1, currentDate)

              'If this is NOT a weekend then add the appointment
              If ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbSunday) And recurrenceWeek.UseSun) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbMonday) And recurrenceWeek.UseMon) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbTuesday) And recurrenceWeek.UseTue) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbWednesday) And recurrenceWeek.UseWed) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbThursday) And recurrenceWeek.UseThu) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbFriday) And recurrenceWeek.UseFri) Or _
               ((Weekday(checkDate, vbUseSystemDayOfWeek) = vbSaturday) And recurrenceWeek.UseSat) Then

                'Do not add appointment to the very first day
                'since once already exists there anyway
                If (Not DateMatch(checkDate, origDate)) And ((checkDate > startDate) Or DateMatch(checkDate, startDate)) Then
                  'If in date range
                  If (checkDate < endDate) Or DateMatch(checkDate, endDate) Then
                    cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
                    cloneAppointment.StartDate = checkDate
                    cloneAppointment.Recurrence = recurrence
                    If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                      Call tempAppointments.AddObject(cloneAppointment)
                      recurrence.LastCreateDate = cloneAppointment.StartDate
                      recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                    End If
                  End If
                End If

              End If
            Next            'ii 'Days per week

            'Now increment the current date by "X" weeks
            'where "X" was specified in the Recurrence object
            currentDate = DateAdd(DateInterval.Day, recurrenceWeek.WeekInterval * DaysPerWeek, currentDate)

          End While

        End If

        'If we are REALLY adding then do so
        If Not recurrence.CheckOnly Then
          'If everything is Ok then add the
          'appointments to the real collection
          For Each loopAppointment In tempAppointments
            Call AddObject(loopAppointment)
            loopAppointment.Recurrence = recurrence
            loopAppointment.MainObject = Me.MainObject
            loopAppointment.ResetRecurrenceStamp(loopAppointment.GetRecurrenceStamp)
            Call loopAppointment.CalculateSortIndexes()
            loopAppointment.OnRefresh(loopAppointment, New AfterBaseObjectEventArgs(loopAppointment))
          Next
        End If

        'Everything OK
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Private Function AddRecurrenceMonth(ByVal appointment As Appointment, _
     ByVal recurrence As Recurrence, _
     ByVal origDate As DateTime, _
     ByVal startDate As DateTime, _
     ByVal endDate As DateTime) As Boolean

      Dim currentDate As DateTime
      Dim cloneAppointment As Appointment
      Dim recurrenceMonth As RecurrenceMonth
      Dim lCount As Long
      Dim tempAppointments As AppointmentCollection
      Dim loopAppointment As Appointment

      Try

        tempAppointments = New AppointmentCollection(Me.MainObject)
        tempAppointments.CancelEvents = True

        'Get a handle to the recurrence object
        recurrenceMonth = recurrence.RecurrenceMonth

        '********************************************************
        'Add specified number of appts
        'Criteria: Add on Day "X" every "Y" months
        If (recurrence.EndType = RecurrenceEndConstants.EndByInterval) And (recurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Interval) Then

          lCount = 0
          If recurrenceMonth.DayInterval <= startDate.Day Then
            startDate = DateSerial(Year(startDate), Month(startDate), recurrenceMonth.DayInterval)
            startDate = DateAdd(DateInterval.Month, recurrenceMonth.MonthInterval, startDate)
          Else
            startDate = DateSerial(Year(startDate), Month(startDate), recurrenceMonth.DayInterval)
          End If
          currentDate = startDate

          'While we have not added the specified number of appointments keep looping
          For ii As Integer = 1 To recurrence.EndIterations - 1
            cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
            cloneAppointment.StartDate = currentDate.AddMonths((ii - 1) * recurrenceMonth.MonthInterval)
            cloneAppointment.Recurrence = recurrence
            If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
              Call tempAppointments.AddObject(cloneAppointment)
              recurrence.LastCreateDate = cloneAppointment.StartDate
              recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
            End If
          Next

          '********************************************************
          'Add specified number of appts in a date range
          'Criteria: Add on Day "X" every "Y" months
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByDate) And (recurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Interval) Then

          If recurrenceMonth.DayInterval <= startDate.Day Then
            startDate = DateSerial(Year(startDate), Month(startDate), recurrenceMonth.DayInterval)
            startDate = DateAdd(DateInterval.Month, recurrenceMonth.MonthInterval, startDate)
          Else
            startDate = DateSerial(Year(startDate), Month(startDate), recurrenceMonth.DayInterval)
          End If
          currentDate = startDate

          'While we are in the date range keep looping
          Dim ii As Integer = recurrenceMonth.MonthInterval
          While (currentDate < endDate) Or DateMatch(currentDate, endDate)
            If Not DateMatch(currentDate, origDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
              End If
            End If
            currentDate = startDate.AddMonths(ii)
            ii += recurrenceMonth.MonthInterval
          End While

          '********************************************************
          'Add specified number of appts
          'Criteria: Add on "X" DAY of every "Y" months
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByInterval) And (recurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal) Then

          lCount = 0
          currentDate = GetMonthRecurrenceDate(recurrenceMonth.DayPosition, recurrenceMonth.DayOrdinal, startDate)
          'While we have not added the specified number of appointments keep looping
          While lCount < CLng(recurrence.EndIterations) - 1
            If (Not DateMatch(currentDate, origDate)) And (Not DateMatch(currentDate, origDate)) And (startDate < currentDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                lCount = lCount + 1
              End If
            End If
            currentDate = DateAdd(DateInterval.Month, recurrenceMonth.MonthInterval, currentDate)
            currentDate = GetMonthRecurrenceDate(recurrenceMonth.DayPosition, recurrenceMonth.DayOrdinal, currentDate)

            'This will end the loop if need be
            If (currentDate > endDate) Then lCount = CLng(recurrence.EndIterations) - 1

          End While

          '********************************************************
          'Add specified number of appts in a date range 
          'Criteria: Add on "X" DAY of every "Y" months
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByDate) And (recurrenceMonth.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal) Then
          currentDate = GetMonthRecurrenceDate(recurrenceMonth.DayPosition, recurrenceMonth.DayOrdinal, startDate)

          'While we are in the date range keep looping
          While (currentDate < endDate) Or DateMatch(currentDate, endDate)
            If (Not DateMatch(currentDate, origDate)) And (Not DateMatch(currentDate, origDate)) And (startDate < currentDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
              End If
            End If
            currentDate = DateAdd(DateInterval.Month, recurrenceMonth.MonthInterval, currentDate)
            currentDate = GetMonthRecurrenceDate(recurrenceMonth.DayPosition, recurrenceMonth.DayOrdinal, currentDate)
          End While

        End If

        'If we are REALLY adding then do so
        If Not recurrence.CheckOnly Then
          'If everything is Ok then add the
          'appointments to the real collection
          For Each loopAppointment In tempAppointments
            Call AddObject(loopAppointment)
            loopAppointment.Recurrence = recurrence
            loopAppointment.MainObject = Me.MainObject
            loopAppointment.ResetRecurrenceStamp(loopAppointment.GetRecurrenceStamp)
            Call loopAppointment.CalculateSortIndexes()
            loopAppointment.OnRefresh(loopAppointment, New AfterBaseObjectEventArgs(loopAppointment))
          Next
        End If

        'Everything OK
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Private Function AddRecurrenceYear(ByVal appointment As Appointment, _
     ByVal recurrence As Recurrence, _
     ByVal origDate As DateTime, _
     ByVal startDate As DateTime, _
     ByVal endDate As DateTime) As Boolean

      Dim currentDate As DateTime
      Dim cloneAppointment As Appointment
      Dim recurrenceYear As RecurrenceYear
      Dim lCount As Long
      Dim tempAppointments As AppointmentCollection
      Dim loopAppointment As Appointment

      Try

        tempAppointments = New AppointmentCollection(Me.MainObject)
        tempAppointments.CancelEvents = True

        'Get a handle to the recurrence object
        recurrenceYear = recurrence.RecurrenceYear

        '********************************************************
        'Add specified number of appts
        'Criteria: Every MONTH X, DAY Y of each year
        If (recurrence.EndType = RecurrenceEndConstants.EndByInterval) And (recurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Interval) Then

          lCount = 0
          Dim newDate As Date = DateSerial(Year(startDate), recurrenceYear.MonthInterval, recurrenceYear.DayInterval)
          'If the start date is in the past then make the start date next year
          If (newDate < startDate) OrElse (DateMatch(newDate, origDate)) Then newDate = newDate.AddYears(1)
          startDate = newDate
          currentDate = startDate

          'While we have not added the specified number of appointments keep looping
          For ii As Integer = 1 To recurrence.EndIterations - 1
            cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
            cloneAppointment.StartDate = currentDate.AddYears(ii - 1)
            cloneAppointment.Recurrence = recurrence
            If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
              Call tempAppointments.AddObject(cloneAppointment)
              recurrence.LastCreateDate = cloneAppointment.StartDate
              recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
            End If
          Next

          '********************************************************
          'Add specified number of appts in a date range
          'Criteria: Every MONTH X, DAY Y of each year
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByDate) And (recurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Interval) Then

          Dim newDate As Date = DateSerial(Year(startDate), recurrenceYear.MonthInterval, recurrenceYear.DayInterval)
          'If the start date is in the past then make the start date next year
          If (newDate < startDate) OrElse (DateMatch(newDate, origDate)) Then newDate = newDate.AddYears(1)
          startDate = newDate
          currentDate = startDate

          'While we are in the date range keep looping
          Dim ii As Integer = 1
          While (currentDate < endDate) Or DateMatch(currentDate, endDate)
            If Not DateMatch(currentDate, origDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
              End If
            End If
            currentDate = startDate.AddYears(ii)
            ii += 1
          End While

          '********************************************************
          'Add specified number of appts
          'Criteria: The First Monday of each Month
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByInterval) And (recurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal) Then

          lCount = 0
          currentDate = GetYearRecurrenceDate(recurrenceYear.DayPosition, recurrenceYear.DayOrdinal, recurrenceYear.MonthOrdinal, startDate)
          'While we have not added the specified number of appointments keep looping
          While lCount < CLng(recurrence.EndIterations) - 1
            If (Not DateMatch(currentDate, origDate)) And (Not DateMatch(currentDate, origDate)) And (startDate < currentDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
                lCount = lCount + 1
              End If
            End If
            currentDate = GetYearRecurrenceDate(recurrenceYear.DayPosition, recurrenceYear.DayOrdinal, recurrenceYear.MonthOrdinal, currentDate.AddYears(1))

            'This will end the loop if need be
            If (currentDate > endDate) Then lCount = CLng(recurrence.EndIterations) - 1

          End While

          '********************************************************
          'Add specified number of appts in a date range 
          'Criteria: The First Monday of each Month
        ElseIf (recurrence.EndType = RecurrenceEndConstants.EndByDate) And (recurrenceYear.RecurrenceMode = RecurrenceSubTypeConstants.Ordinal) Then
          currentDate = GetYearRecurrenceDate(recurrenceYear.DayPosition, recurrenceYear.DayOrdinal, recurrenceYear.MonthOrdinal, startDate)

          'While we are in the date range keep looping
          While (currentDate < endDate) Or DateMatch(currentDate, endDate)
            If (Not DateMatch(currentDate, origDate)) And (Not DateMatch(currentDate, origDate)) And (startDate < currentDate) Then
              cloneAppointment = CType(appointment.Clone, Gravitybox.Objects.Appointment)
              cloneAppointment.StartDate = currentDate
              cloneAppointment.Recurrence = recurrence
              If MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, cloneAppointment.StartDate, cloneAppointment.StartTime, cloneAppointment.Length, MainObject.ResolveRoom(cloneAppointment.Room), -1, -1) Then
                Call tempAppointments.AddObject(cloneAppointment)
                recurrence.LastCreateDate = cloneAppointment.StartDate
                recurrence.LastCreateGroupId = cloneAppointment.Recurrence.Key
              End If
            End If
            currentDate = GetYearRecurrenceDate(recurrenceYear.DayPosition, recurrenceYear.DayOrdinal, recurrenceYear.MonthOrdinal, currentDate.AddYears(1))
          End While

        End If

        'If we are REALLY adding then do so
        If Not recurrence.CheckOnly Then
          'If everything is Ok then add the
          'appointments to the real collection
          For Each loopAppointment In tempAppointments
            Call AddObject(loopAppointment)
            loopAppointment.Recurrence = recurrence
            loopAppointment.MainObject = Me.MainObject
            loopAppointment.ResetRecurrenceStamp(loopAppointment.GetRecurrenceStamp)
            Call loopAppointment.CalculateSortIndexes()
            loopAppointment.OnRefresh(loopAppointment, New AfterBaseObjectEventArgs(loopAppointment))
          Next
        End If

        'Everything OK
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Sub DeleteRecurrences(ByVal recurrence As Recurrence, ByVal skipAppointment As Appointment)

      Try
        'Loop and remove all of the recurrences for this RecurrenceId
        'except for the appointment that we are going to use as the new 
        'recurrence template. Loop backwards so that there are no errors
        For ii As Integer = Me.Count - 1 To 0 Step -1
          If Not (Item(ii).Recurrence Is Nothing) Then
            If (String.Compare(Item(ii).Recurrence.Key, recurrence.Key, True) = 0) Then
              If Not (Item(ii) Is skipAppointment) Then
                Call RemoveAt(ii)
              End If
            End If
          End If
        Next ii

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Item"

    ''' <summary>
    ''' Returns the object that matches the unique key.
    ''' </summary>
    ''' <param name="key">The key of the item to retrieve.</param>
    ''' <returns>The matching object or null if no match is found.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal key As String) As Gravitybox.Objects.Appointment
      Get
        Return CType(MyBase.Item(key), Appointment)
      End Get
    End Property

    ''' <summary>
    ''' Returns the object at the index in the collection.
    ''' </summary>
    ''' <param name="index">The index of the item in the collection to retrieve.</param>
    ''' <returns>The matching object or an error if the index is out of bounds.</returns>
    Default Public Shadows ReadOnly Property Item(ByVal index As Integer) As Gravitybox.Objects.Appointment
      Get
        Return CType(MyBase.Item(index), Appointment)
      End Get
    End Property

#End Region

#Region "Handlers"

    Private Sub ClearCompleteHandler()
      Me.CleanAppointments(Nothing)
    End Sub

    Private Sub AfterRemoveHandler(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      Dim element As Appointment = CType(e.BaseObject, Appointment)
      Call element.ResetTimeStamp(False)
      Me.CleanAppointments(element)
    End Sub

    Private Sub CleanAppointments()

      Try
        MainObject.RecurrenceCollection.Clear()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub CleanAppointments(ByVal element As Appointment)

      If element Is Nothing Then Return
      Try
        'If the element has a Recurrence object...
        If Not (element.Recurrence Is Nothing) Then
          'If the Recurrence is in the RecurrenceCollection...
          If MainObject.RecurrenceCollection.Contains(element.Recurrence) Then
            'If there are no longer any appointments with this Recurrence...
            If Me.GetRecurrences(element.Recurrence).Count = 0 Then
              'Remove the Recurrence altogether
              MainObject.RecurrenceCollection.Remove(element.Recurrence)
            End If
          End If
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "IsRecurrence"

    Public Function IsRecurrence(ByVal element As Appointment) As Boolean

      If element.Recurrence Is Nothing Then
        Return False
      Else
        Return (Me.GetRecurrences(element.Recurrence).Count > 0)
        'Return MainObject.RecurrenceCollection.Contains(element.Recurrence)
      End If

    End Function

#End Region

#Region "ClearRetangles"

    'This will clear all the coordinate rectangles for all appointments
    Friend Sub ClearRetangles()

      Try
        Dim appointment As Appointment
        For Each appointment In Me
          Call appointment.Rectangles.Clear()
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "HitTest"

    Public Function HitTest(ByVal pt As Point) As Appointment

      Try
        'Determine if this point is contained within this appointment
        'Loop backwards so last drawn is checked first
        For ii As Integer = Me.Count - 1 To 0 Step -1
          Dim element As Gravitybox.Objects.Appointment = Item(ii)
          'MUST BE VISIBLE
          If element.Visible AndAlso element.Rectangles.InRectangle(pt) Then
            Return element
          End If
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function HitTest(ByVal x As Integer, ByVal y As Integer) As Appointment

      Try
        'Determine if this point is contained within this appointment
        Return HitTest(New Point(x, y))
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
    Public Function ToList() As Gravitybox.Objects.AppointmentList

      Try
        Dim list As New Gravitybox.Objects.AppointmentList(Me.MainObject, Me)
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
    Public Sub FromList(ByVal list As Gravitybox.Objects.AppointmentList)

      Try
        For Each element As BaseObject In list
          Me.AddObject(element)
        Next
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "CalculateConflicts"

    Friend Sub CalculateConflicts()

      Try

        'If there are no appointments then there is nothing to do
        If Me.Count = 0 Then Return

        'Parse into column (or row) buckets
        'Worst case is count buckets
        Dim buckets As New ConflictBucketCollection

        'Loop through all appointments and parse to buckets
        Dim appointment As Appointment
        For Each appointment In Me
          appointment.TabIndex = 0
          'Only parse into buckets if this is a normal appointment
          'Events and Activities are displayed in the top margin and 
          'there is no need to display them side-by-side
          If appointment.Visible AndAlso (Not ((appointment.IsActivity) OrElse (appointment.IsEvent))) Then
            Call buckets.AddAppointment(appointment)
          End If
        Next        'Appointment Loop

        '********************************************************************
        'Now calculate the number of conflicts for each appointment rectangle
        Dim bucket As ConflictBucket
        For Each bucket In buckets
          Dim group As ConflictBucketGroup
          For Each group In bucket.Groups
            Dim column As ConflictBucketColumn
            For Each column In group.Columns
              Dim rectInfo As AppointmentRectangleInfo
              For Each rectInfo In column.AppointmentRectangles
                'Loop through the rectangles and calculate number of conflicts between every rectangle
                Dim loopRectInfo As AppointmentRectangleInfo
                Dim loopColumn As ConflictBucketColumn
                For Each loopColumn In group.Columns
                  For Each loopRectInfo In loopColumn.AppointmentRectangles
                    If loopRectInfo.IsConflict(rectInfo) Then
                      'If Not (loopRectInfo Is rectInfo) AndAlso loopRectInfo.IsConflict(rectInfo) Then
                      loopRectInfo.ConflictCount += 1
                    End If
                  Next
                Next
              Next
            Next
          Next
        Next
        '********************************************************************
        If Me.MainObject Is Nothing Then Return

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            'Loop and make the rectangle widths the correct size
            'Dim bucket As ConflictBucket
            For Each bucket In buckets
              Dim ii As Integer = 0
              Dim skewSize As Integer
              Dim group As ConflictBucketGroup
              For Each group In bucket.Groups
                ii = 0
                Dim column As ConflictBucketColumn
                For Each column In group.Columns

                  If MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap Then
                    'Do Nothing

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide Then
                    Dim rectInfo As AppointmentRectangleInfo
                    For Each rectInfo In column.AppointmentRectangles
                      'Divide the column width by the number of 
                      'conflicts or at most the number of rows
                      Dim colCount As Integer = group.Columns.Count
                      Dim width As Integer = (MainObject.ColumnHeader.Size \ colCount)
                      Dim left As Integer = rectInfo.Rect.Left + (width * column.ColumnIndex)
                      rectInfo.Rect = New Rectangle(left, rectInfo.Rect.Top, width - MainObject.AppointmentSpace, rectInfo.Rect.Height)
                    Next

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger Then
                    Dim rectInfo As AppointmentRectangleInfo
                    For Each rectInfo In column.AppointmentRectangles
                      'Take a fixed width off for each conflicting appointment
                      'then stagger the appointments across the column
                      Dim colCount As Integer = group.Columns.Count
                      skewSize = (StaggerSize * (colCount - 1))
                      Dim width As Integer = MainObject.ColumnHeader.Size - skewSize
                      If width < 0 Then width = 0
                      Dim left As Integer = rectInfo.Rect.Left + (ii * StaggerSize)
                      rectInfo.Rect = New Rectangle(left, rectInfo.Rect.Top, width - MainObject.AppointmentSpace, rectInfo.Rect.Height)
                    Next

                  End If
                  ii += 1

                Next
              Next
            Next

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            'Loop and make the rectangle widths the correct size
            'Dim bucket As ConflictBucket
            For Each bucket In buckets
              Dim column As ConflictBucketColumn
              Dim ii As Integer = 0
              Dim skewSize As Integer             '= (StaggerSize * (bucket.Columns.Count - 1))

              Dim group As ConflictBucketGroup
              For Each group In bucket.Groups
                For Each column In group.Columns

                  Dim rectInfo As AppointmentRectangleInfo
                  If MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap Then
                    'Do Nothing

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide Then
                    For Each rectInfo In column.AppointmentRectangles
                      'Divide the row height by the number of 
                      'conflicts or at most the number of rows
                      Dim rowCount As Integer = group.Columns.Count
                      'If rowCount > rectInfo.ConflictCount Then rowCount = rectInfo.ConflictCount
                      Dim height As Integer = (MainObject.RowHeader.Size \ rowCount)
                      Dim top As Integer = rectInfo.Rect.Top + (height * column.ColumnIndex)
                      rectInfo.Rect = New Rectangle(rectInfo.Rect.Left, top, rectInfo.Rect.Width, height - MainObject.AppointmentSpace)
                    Next

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger Then
                    For Each rectInfo In column.AppointmentRectangles
                      'Take a fixed width off for each conflicting appointment
                      'then stagger the appointments across the column
                      Dim rowCount As Integer = group.Columns.Count
                      'If rowCount > rectInfo.ConflictCount Then rowCount = rectInfo.ConflictCount
                      skewSize = (StaggerSize * (rowCount - 1))
                      Dim height As Integer = (MainObject.RowHeader.Size - skewSize)
                      If height < 0 Then height = 0
                      Dim top As Integer = rectInfo.Rect.Top + (ii * StaggerSize)
                      rectInfo.Rect = New Rectangle(rectInfo.Rect.Left, top, rectInfo.Rect.Width, height - MainObject.AppointmentSpace)
                    Next

                  End If
                  ii += 1

                Next
              Next
            Next

            '*******************************************************************************
            'THIS IS THE SAME AS ABOVE TIMELEFT IN PRODUCTION VERSION ADD THIS VIEWMODE TO CASE ABOVE
            '*******************************************************************************

          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            'Loop and make the rectangle widths the correct size
            'Dim bucket As ConflictBucket
            For Each bucket In buckets
              Dim ii As Integer = 0
              Dim skewSize As Integer
              Dim group As ConflictBucketGroup
              For Each group In bucket.Groups
                ii = 0
                Dim column As ConflictBucketColumn
                For Each column In group.Columns

                  If MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Overlap Then
                    'Do Nothing

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.SideBySide Then
                    Dim rectInfo As AppointmentRectangleInfo
                    For Each rectInfo In column.AppointmentRectangles
                      'Divide the column width by the number of 
                      'conflicts or at most the number of rows
                      Dim colCount As Integer = group.Columns.Count
                      Dim width As Integer = (MainObject.ColumnHeader.Size \ colCount)
                      Dim left As Integer = rectInfo.Rect.Left + (width * column.ColumnIndex)
                      rectInfo.Rect = New Rectangle(left, rectInfo.Rect.Top, width - MainObject.AppointmentSpace, rectInfo.Rect.Height)
                    Next

                  ElseIf MainObject.ConflictDisplay = Gravitybox.Controls.Schedule.ConflictDisplayConstants.Stagger Then
                    Dim rectInfo As AppointmentRectangleInfo
                    For Each rectInfo In column.AppointmentRectangles
                      'Take a fixed width off for each conflicting appointment
                      'then stagger the appointments across the column
                      Dim colCount As Integer = group.Columns.Count
                      skewSize = (StaggerSize * (colCount - 1))
                      Dim width As Integer = MainObject.ColumnHeader.Size - skewSize
                      If width < 0 Then width = 0
                      Dim left As Integer = rectInfo.Rect.Left + (ii * StaggerSize)
                      rectInfo.Rect = New Rectangle(left, rectInfo.Rect.Top, width - MainObject.AppointmentSpace, rectInfo.Rect.Height)
                    Next

                  End If
                  ii += 1

                Next
              Next
            Next

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            'Do Nothing

          Case Gravitybox.Controls.Schedule.ViewModeConstants.Week
            'Do Nothing

          Case Controls.Schedule.ViewModeConstants.MonthFull
            'Do Nothing

          Case Else
            Call ErrorModule.ViewmodeErr()

        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "IsConflict"

    Public Function IsConflict(ByVal appointment As Gravitybox.Objects.Appointment) As Boolean
      Return IsConflict(appointment, New AppointmentList(Me.MainObject, appointment))
    End Function

    Public Function IsConflict(ByVal appointment As Gravitybox.Objects.Appointment, ByVal skipItems As Gravitybox.Objects.AppointmentList) As Boolean

      Try
        Dim list As New Gravitybox.Objects.AppointmentList(Me.MainObject, Me)
        Return list.IsConflict(appointment, skipItems)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "VCal Import/Export"

    Public Function FromVCAL(ByVal filename As String, ByVal useUniversalTime As Boolean) As Boolean

      Try
        'Create the .VCS file.
        Dim text As String = ""
        Dim appointment As Appointment = Nothing
        Dim ii As Integer = 0
        Dim sw As System.IO.StreamReader
        Dim fileText As String = ""

        'Erorr check for file exisitence
        If Not System.IO.File.Exists(filename) Then Return False

        'Load the file into a string array
        sw = New System.IO.StreamReader(filename)
        fileText = sw.ReadToEnd()
        Call sw.Close()

        Dim stringArray As String() = Split(fileText, ControlChars.CrLf)

        'Read first line
        While ii < stringArray.Length
          text = stringArray(ii)

          If text.Replace(" ", "").StartsWith("BEGIN:VCALENDAR") Then
            'Do Nothing

          ElseIf text.Replace(" ", "").StartsWith("BEGIN:VEVENT") Then
            'New Appointment
            appointment = New Appointment(MainObject)

          ElseIf text.Replace(" ", "").StartsWith("END:VEVENT") Then
            'End of appointment - so add it
            Call Me.AddObject(appointment)

          ElseIf text.Replace(" ", "").StartsWith("END:VCALENDAR") Then
            'End of file
            Call sw.Close()
            Return True

          ElseIf text.Replace(" ", "").StartsWith("VERSION") Then
            'Do Nothing

          ElseIf text.Replace(" ", "").StartsWith("METHOD") Then
            'TODO

          ElseIf text.Replace(" ", "").StartsWith("DTSTAMP") Then
            'Do Nothing

          ElseIf text.Replace(" ", "").StartsWith("CATEGORIES") Then
            text = StripToChar(text, ":", True)
            Dim arrS As String() = Split(text, ",")
            Dim jj As Integer
            For jj = 0 To arrS.Length - 1
              If MainObject.CategoryCollection.Contains(arrS(jj).Trim) Then
                Call appointment.CategoryList.Add(MainObject.CategoryCollection(arrS(jj).Trim))
              End If
            Next

          ElseIf text.Replace(" ", "").StartsWith("CLASS") Then
            If text.EndsWith("PUBLIC") Then
              appointment.Access = AppointmentAccessConstants.AccessPublic
            ElseIf text.EndsWith("PRIVATE") Then
              appointment.Access = AppointmentAccessConstants.AccessPrivate
            ElseIf text.EndsWith("CONFIDENTIAL") Then
              appointment.Access = AppointmentAccessConstants.AccessConfidential
            End If

          ElseIf text.Replace(" ", "").StartsWith("SUMMARY") Then
            Dim lineText As String = ""
            lineText = StripToChar(text, ":", True)
            'Find other lines as long as there is a space for the first char
            While (ii + 1 < stringArray.Length) AndAlso stringArray(ii + 1).StartsWith(" ")
              ii += 1
              lineText &= stringArray(ii).Replace(" \n", ControlChars.CrLf).Replace("\n", ControlChars.CrLf).Trim
            End While
            appointment.Subject = lineText

          ElseIf text.Replace(" ", "").StartsWith("PRIORITY") Then
            Dim index As Integer = text.Replace(" ", "").IndexOf(":")
            Dim priorityName As String = StripToChar(text, ":", True)
            If MainObject.PriorityCollection.Contains(priorityName) Then
              appointment.Priority = MainObject.PriorityCollection(priorityName)
            End If

          ElseIf text.Replace(" ", "").StartsWith("DESCRIPTION") Then
            Dim lineText As String = ""
            lineText = StripToChar(text, ":", True)
            'Find other lines as long as there is a space for the first char
            While (ii + 1 < stringArray.Length) AndAlso stringArray(ii + 1).StartsWith(" ")
              ii += 1
              lineText &= stringArray(ii).Replace(" \n", ControlChars.CrLf).Replace("\n", ControlChars.CrLf).Trim
            End While
            appointment.Text = lineText

          ElseIf text.Replace(" ", "").StartsWith("NOTES") Then
            Dim lineText As String = ""
            lineText = StripToChar(text, ":", True)
            'Find other lines as long as there is a space for the first char
            While (ii + 1 < stringArray.Length) AndAlso stringArray(ii + 1).StartsWith(" ")
              ii += 1
              lineText &= stringArray(ii).Replace(" \n", ControlChars.CrLf).Replace("\n", ControlChars.CrLf).Trim
            End While
            appointment.Notes = lineText

          ElseIf text.Replace(" ", "").StartsWith("LOCATION") Then
            'Check for the room and if it exists then set the appointment's room object
            Dim roomName As String = StripToChar(text, ":", True)
            If MainObject.RoomCollection.Contains(roomName) Then
              appointment.Room = MainObject.RoomCollection(roomName)
            End If

          ElseIf text.Replace(" ", "").StartsWith("URL") Then
            'Do Nothing

          ElseIf text.Replace(" ", "").StartsWith("TRIGGER") Then
            Dim startDateTime As DateTime = FromVCALDateTime(text)
            If useUniversalTime Then startDateTime = startDateTime.ToLocalTime
            appointment.Alarm.Reminder = GetIntlInteger(startDateTime.Subtract(appointment.StartDateTime).TotalMinutes)
            appointment.Alarm.IsArmed = True

          ElseIf text.Replace(" ", "").StartsWith("DTSTART") Then
            Dim startDateTime As DateTime = FromVCALDateTime(text)
            If useUniversalTime Then startDateTime = startDateTime.ToLocalTime
            appointment.StartDate = startDateTime.Date
            If VCALHasTime(text) Then
              appointment.StartTime = TimeSerial(startDateTime.TimeOfDay.Hours, startDateTime.TimeOfDay.Minutes, 0)
            Else
              appointment.IsEvent = True
            End If

          ElseIf text.Replace(" ", "").StartsWith("DTEND") Then
            'If this appointment was marked as an event then do not worry about the end time
            If Not appointment.IsEvent Then
              Dim startDateTime As DateTime = FromVCALDateTime(text)
              If useUniversalTime Then startDateTime = startDateTime.ToLocalTime
              appointment.Length = GetIntlInteger(startDateTime.Subtract(appointment.StartDateTime).TotalMinutes)
            End If

          ElseIf text.Replace(" ", "").StartsWith("UID") Then
            Dim lineText As String = StripToChar(text, ":", True)
            'If this GUID exists then create a new one
            If Me.Contains(lineText) Then lineText = Guid.NewGuid.ToString
            appointment.SetKey(lineText)

          ElseIf text.Replace(" ", "").StartsWith("ISEVENT") Then
            appointment.IsEvent = CBool(StripToChar(text, ":", True))

          ElseIf text.Replace(" ", "").StartsWith("ISFLAGGED") Then
            appointment.IsFlagged = CBool(StripToChar(text, ":", True))

          ElseIf text.Replace(" ", "").StartsWith("MINLENGTH") Then
            appointment.MinLength = GetIntlInteger(StripToChar(text, ":", True))

          ElseIf text.Replace(" ", "").StartsWith("MAXLENGTH") Then
            appointment.MaxLength = GetIntlInteger(StripToChar(text, ":", True))

          End If
          ii += 1

        End While

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Function ToVCAL(ByVal useUniversalTime As Boolean) As String

      Try
        Dim list As AppointmentList = Me.ToList()
        Return ToVCAL(list, useUniversalTime)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function ToVCAL(ByVal filename As String, ByVal useUniversalTime As Boolean) As Boolean

      Try
        Dim list As AppointmentList = Me.ToList()
        Return ToVCAL(filename, list, useUniversalTime)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Function ToVCAL(ByVal appointmentList As AppointmentList, ByVal useUniversalTime As Boolean) As String

      Try
        'Error Check
        If appointmentList Is Nothing Then
          Return ""
        ElseIf appointmentList.Count = 0 Then
          Return ""
        Else
          Return CreateVCSAppointment(appointmentList, useUniversalTime)
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function ToVCAL(ByVal filename As String, ByVal appointmentList As AppointmentList, ByVal useUniversalTime As Boolean) As Boolean

      Try
        'Error Check
        If appointmentList Is Nothing Then
          Return False
        ElseIf appointmentList.Count = 0 Then
          Return False
        ElseIf filename.Trim = "" Then
          Return False
        Else
          Return CreateVCSAppointment(appointmentList, filename, useUniversalTime)
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Helper Lists"

    Friend Function GetBlocked(ByVal startDate As Date, ByVal endDate As Date) As AppointmentList

      Try
        Dim list1 As BaseList = Me.GetBlocked
        Dim list2 As BaseList = Me.Find(startDate, endDate)
        Return CType(list1.Intersect(list2), AppointmentList)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Friend Function GetEvents(ByVal startDate As Date, ByVal endDate As Date) As AppointmentList

      Try
        Dim list1 As BaseList = Me.GetEvents
        Dim list2 As BaseList = Me.Find(startDate, endDate)
        Return CType(list1.Intersect(list2), AppointmentList)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Friend Function GetTopBlockAppointments(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer

      Try
        'Range check
        If endDate < startDate Then endDate = startDate

        Dim appointment As Appointment
        Dim retval As Integer = -1
        For Each appointment In Me
          If appointment.Rectangles.Count > 0 Then
            'If this appointment is an event or activity...
						If appointment.Visible AndAlso (appointment.IsEvent OrElse appointment.IsActivity) Then
							'and it is in the speified date range...
							If appointment.Contains(startDate, endDate) Then
								'remember this appointment's header index if it is larger than any others
								If retval < appointment.EventIndex Then
									retval = appointment.EventIndex
								End If
							End If
						End If
          End If
        Next

        'This returns the largest header index in this date range.
        'The information lets us know the maximum number of event 
        'rows that will be displayed in the event header. From this info 
        'we know how large to make the header
        Return retval + 1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "GetEvents"

    Public Function GetEvents() As AppointmentList

      Try
        Dim retval As New AppointmentList(Me.MainObject)
        Dim appointment As Appointment
        For Each appointment In Me
          If appointment.IsEvent Then
            Call retval.Add(appointment)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "GetBlocked"

    Public Function GetBlocked() As AppointmentList

      Try
        Dim retval As New AppointmentList(Me.MainObject)
        Dim appointment As Appointment
        For Each appointment In Me
          If appointment.Blockout Then
            Call retval.Add(appointment)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function GetUnBlocked() As AppointmentList

      Try
        Dim retval As New AppointmentList(Me.MainObject)
        Dim appointment As Appointment
        For Each appointment In Me
          If Not appointment.Blockout Then
            Call retval.Add(appointment)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "GetFromRow/GetFromColumn"

    Public Function GetFromColumn(ByVal index As Integer) As AppointmentList

      Dim retval As New AppointmentList(Me.MainObject)
      Try
        Dim appointment As Gravitybox.Objects.Appointment
        Dim left As Integer = MainObject.ClientLeft + (MainObject.ColumnHeader.Size * (index - MainObject.Visibility.FirstVisibleColumn))
        Dim checkRect As New Rectangle(left, MainObject.ClientTop, MainObject.ColumnHeader.Size, MainObject.Visibility.TotalRowCount * MainObject.RowHeader.Size)
        For Each appointment In Me
          Dim apptRect As AppointmentRectangleInfo
          For Each apptRect In appointment.Rectangles
            If checkRect.IntersectsWith(apptRect.Rect) Then
              retval.Add(appointment)
              Exit For
            End If
          Next
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return retval

    End Function

    Public Function GetFromRow(ByVal index As Integer) As AppointmentList

      Dim retval As New AppointmentList(Me.MainObject)
      Try
        Dim appointment As Gravitybox.Objects.Appointment
        Dim top As Integer = MainObject.ClientTop + (MainObject.RowHeader.Size * (index - MainObject.Visibility.FirstVisibleRow))
        Dim checkRect As New Rectangle(MainObject.ClientLeft, top, MainObject.Visibility.TotalColumnCount * MainObject.ColumnHeader.Size, MainObject.RowHeader.Size)
        For Each appointment In Me
          Dim apptRect As AppointmentRectangleInfo
          For Each apptRect In appointment.Rectangles
            If checkRect.IntersectsWith(apptRect.Rect) Then
              retval.Add(appointment)
              Exit For
            End If
          Next
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return retval

    End Function

#End Region

#Region "GetRecurrences"

    Public Function GetRecurrences(ByVal recurrence As Recurrence) As AppointmentList

      Try
        'Loop and retrun a collection of appointments that have a matching RecurrenceId
        Dim retval As New AppointmentList(Me.MainObject)
        If recurrence Is Nothing Then
          Return retval
        End If

        For Each element As Gravitybox.Objects.Appointment In Me
          If element.Recurrence Is recurrence Then
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

#Region "Find"

    'Find appointments by date range
    Public Function Find(ByVal startDate As Date, ByVal endDate As Date) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        startDate = GetDate(startDate)
        endDate = GetDate(endDate)
        For Each element In Me
          If element.Contains(startDate, endDate) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Find appointments by room
    Public Function Find(ByVal room As Room) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element In Me
          If element.Room Is room Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Find appointments by category
    Public Function Find(ByVal category As Category) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element In Me
          If element.CategoryList.Contains(category) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Find appointments by provider
    Public Function Find(ByVal provider As Provider) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element In Me
          If element.ProviderList.Contains(provider) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Find appointments by subject
    Public Function Find(ByVal subject As String) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element In Me
          If (String.Compare(element.Subject, subject, True) = 0) Then
            Call retval.Add(element)
          End If
        Next
        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Find appointments by access
    Public Function Find(ByVal access As AppointmentAccessConstants) As AppointmentList

      Try
        Dim element As Gravitybox.Objects.Appointment
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element In Me
          If element.Access = access Then
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
					Dim newElement As New Appointment(Me.MainObject)
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
