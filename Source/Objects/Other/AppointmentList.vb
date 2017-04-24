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
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  <Serializable()> _
  Public Class AppointmentList
    Inherits Gravitybox.Objects.BaseList
		Implements IDisposable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "appointmentlist"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		<NonSerialized()> Private BaseAppointment As Gravitybox.Objects.Appointment

#End Region

#Region "Constructor"

		Friend Sub New()
		End Sub

		Friend Sub New(ByVal schedule As Gravitybox.Controls.Schedule, ByVal appointment As Appointment)
			MyBase.New(schedule)
      Me.BaseAppointment = appointment
    End Sub

    Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule, ByVal collection As Gravitybox.Objects.BaseObjectCollection)
      MyBase.New(schedule, collection)
    End Sub

    Public Sub New(ByVal schedule As Gravitybox.Controls.Schedule)
      MyBase.New(schedule)
    End Sub

    Public Sub New(ByVal collection As Gravitybox.Objects.BaseObjectCollection)
      MyBase.New(collection)
    End Sub

#End Region

#Region "On... Event Methods"

		Protected Overrides Sub OnClearComplete()
			MyBase.OnRefresh(Me, New System.EventArgs)
		End Sub

#End Region

#Region "Change Length"

		Friend Sub ChangeLengths(ByVal increaseAmount As Integer, ByVal timeIncrement As Integer, ByVal minLength As Integer)

			'This method will change the lengths of all appointment in this list by the specified amount. 
			'Also the length is rounded to the nearest increment and a minimim length is enforced.
			Try
				For Each appointment As Appointment In Me
          Dim length As Integer = appointment.Length
          length += increaseAmount
          length -= (length Mod timeIncrement)
          If length < minLength Then length = minLength
          appointment.Length = length
        Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts all objects in this list to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String
      Return Me.XmlNode.OuterXml
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overrides Function FromXML(ByVal xml As String) As Boolean

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        Call XMLDoc.LoadXml(xml)

        'Load the elements
        Dim xmlNode As System.Xml.XmlNode
        For Each xmlNode In XMLDoc.DocumentElement.ChildNodes
          If Me.MainObject.AppointmentCollection.Contains(xmlNode.InnerText) Then
            Call Me.Add(Me.MainObject.AppointmentCollection(xmlNode.InnerText))
          End If
        Next

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New System.EventArgs)
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
				Dim element As Appointment
				For Each element In Me
					Call xmlHelper.addElement(parentNode, "key", element.Key)
				Next

				'Return the XML string
				Return parentNode

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

#Region "IsAreaAvailable"

    'Date/Time/Length
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <returns>True if the area has no appointments in the defined region, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Boolean
			Return IsAreaAvailable(startDate, startTime, length, Nothing)
		End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal skipItems As AppointmentList) As Boolean

			Try
				If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

				startTime = GetTime(startTime)

				'Create a rectangle that cover this area used to 
				'check if it conflicts with any other appointment rectangles
				Dim rectInfo As New AppointmentRectangleInfo(Nothing)
				rectInfo.StartDate = startDate
				rectInfo.StartTime = startTime
				rectInfo.Length = length
				Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

				'Loop through the appointments to determine if the specified 
				'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
				'If the loop completes without any conflict 
				'then return True for area is available
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    'Date/Room/Time/Length
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean
			Return IsAreaAvailable(startDate, startRoom, startTime, length, Nothing)
		End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal skipItems As AppointmentList) As Boolean

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return Nothing
        If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

        startTime = GetTime(startTime)

        'Create a rectangle that cover this area used to 
        'check if it conflicts with any other appointment rectangles
        Dim rectInfo As New AppointmentRectangleInfo(Nothing)
        rectInfo.StartDate = startDate
        rectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(startRoom)
        rectInfo.StartTime = startTime
        rectInfo.Length = length
        Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

        'Loop through the appointments to determine if the specified 
        'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
        'If the loop completes without any conflict 
        'then return True for area is available
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room 
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room) As Boolean
      Return IsAreaAvailable(startDate, startRoom, Nothing)
    End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal skipItems As AppointmentList) As Boolean

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return Nothing
        If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

        'Create a rectangle that cover this area used to 
        'check if it conflicts with any other appointment rectangles
        Dim rectInfo As New AppointmentRectangleInfo(Nothing)
        rectInfo.StartDate = startDate
        rectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(startRoom)
        rectInfo.StartTime = PivotTime
        rectInfo.Length = MinutesPerDay
        Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

        'Loop through the appointments to determine if the specified 
        'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
        'If the loop completes without any conflict 
        'then return True for area is available
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider) As Boolean
      Return IsAreaAvailable(startDate, startProvider, Nothing)
    End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal skipItems As AppointmentList) As Boolean

      Try

        'If there is no provider then there is nothing to do
        If (startProvider Is Nothing) Then Return Nothing
        If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

        'Create a rectangle that cover this area used to 
        'check if it conflicts with any other appointment rectangles
        Dim rectInfo As New AppointmentRectangleInfo(Nothing)
        rectInfo.StartDate = startDate
        rectInfo.StartProvider = MainObject.ProviderCollection.IndexOfVisible(startProvider)
        rectInfo.StartTime = PivotTime
        rectInfo.Length = MinutesPerDay
        Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

        'Loop through the appointments to determine if the specified 
        'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
        'If the loop completes without any conflict 
        'then return True for area is available
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider/Time/Length
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean
      Return IsAreaAvailable(startDate, startProvider, startTime, length, Nothing)
    End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startDate">Determines the starting date of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer, ByVal skipItems As AppointmentList) As Boolean

      Try

        'If there is no provider then there is nothing to do
        If (startProvider Is Nothing) Then Return Nothing
        If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

        startTime = GetTime(startTime)

        'Create a rectangle that cover this area used to 
        'check if it conflicts with any other appointment rectangles
        Dim rectInfo As New AppointmentRectangleInfo(Nothing)
        rectInfo.StartDate = startDate
        rectInfo.StartProvider = MainObject.ProviderCollection.IndexOfVisible(startProvider)
        rectInfo.StartTime = startTime
        rectInfo.Length = length
        Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

        'Loop through the appointments to determine if the specified 
        'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
        'If the loop completes without any conflict 
        'then return True for area is available
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Time/Length
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean
      Return IsAreaAvailable(startRoom, startTime, length, Nothing)
    End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal skipItems As AppointmentList) As Boolean

			Try

				'If there is no room then there is nothing to do
				If (startRoom Is Nothing) Then Return Nothing
				If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

				startTime = GetTime(startTime)

				'Create a rectangle that cover this area used to 
				'check if it conflicts with any other appointment rectangles
				Dim rectInfo As New AppointmentRectangleInfo(Nothing)
				rectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(startRoom)
				rectInfo.StartTime = startTime
				rectInfo.Length = length
				Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

				'Loop through the appointments to determine if the specified 
				'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
				'If the loop completes without any conflict 
				'then return True for area is available
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    'Provider/Time/Length
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean
			Return IsAreaAvailable(startProvider, startTime, length, Nothing)
		End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="startTime">Determines the starting time of the area to check.</param>
    ''' <param name="length">Determines the length in minutes of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer, ByVal skipItems As AppointmentList) As Boolean

      Try

        'If there is no provider then there is nothing to do
        If (startProvider Is Nothing) Then Return Nothing
        If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

        startTime = GetTime(startTime)

        'Create a rectangle that cover this area used to 
        'check if it conflicts with any other appointment rectangles
        Dim rectInfo As New AppointmentRectangleInfo(Nothing)
        rectInfo.StartProvider = MainObject.ProviderCollection.IndexOfVisible(startProvider)
        rectInfo.StartTime = startTime
        rectInfo.Length = length
        Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

        'Loop through the appointments to determine if the specified 
        'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
        'If the loop completes without any conflict 
        'then return True for area is available
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Provider
    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsAreaAvailable(ByVal startRoom As Room, ByVal startProvider As Provider) As Boolean
      Return IsAreaAvailable(startRoom, startProvider, Nothing)
    End Function

    ''' <summary>
    ''' Determines if the defined area has any appointments in or overlapping it.
    ''' </summary>
    ''' <param name="startRoom">Determines the room of the area to check.</param>
    ''' <param name="startProvider">Determines the provider of the area to check.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking the defined area. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if the specified area has conflicting appointments in it, false otherwise.</returns>
    ''' <remarks></remarks>
		Public Function IsAreaAvailable(ByVal startRoom As Room, ByVal startProvider As Provider, ByVal skipItems As AppointmentList) As Boolean

			Try
				'If there is no room then there is nothing to do
				If (startRoom Is Nothing) Then Return Nothing
				If (startProvider Is Nothing) Then Return Nothing
				If skipItems Is Nothing Then skipItems = New AppointmentList(Me.MainObject)

				'Create a rectangle that cover this area used to 
				'check if it conflicts with any other appointment rectangles
				Dim rectInfo As New AppointmentRectangleInfo(Nothing)
				rectInfo.StartRoom = MainObject.RoomCollection.IndexOfVisible(startRoom)
				rectInfo.StartProvider = MainObject.ProviderCollection.IndexOfVisible(startProvider)
				rectInfo.StartTime = PivotTime
				rectInfo.Length = MinutesPerDay
				Call CalculateSortIndex(MainObject.ViewMode, rectInfo, MainObject)

				'Loop through the appointments to determine if the specified 
				'area overlaps (conflicts) with any rectangle of any appointment. 
        For Each appointment As Appointment In Me
          If Not skipItems.Contains(appointment) Then
            If appointment.Rectangles.IsConflict(rectInfo) Then
              Return False
            End If
          End If
        Next
				'If the loop completes without any conflict 
				'then return True for area is available
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "NextAreaAvailable"

    'Date/Time/Length
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean) As Appointment
      Return NextAreaAvailable(startDate, startTime, length, useScheduleTime, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean, ByVal skipItems As AppointmentList) As Appointment

      Try

        'Make sure that we are in the proper range
        startTime = GetTime(startTime)
        If startDate < MainObject.MinDate Then startDate = MainObject.MinDate
        If startTime < MainObject.StartTime Then startTime = MainObject.StartTime

        'Loop through the days forever
        Dim loopIndex As Integer
        Dim startTimeIndex As Integer
        Dim endTimeIndex As Integer
        startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, startTime)) \ MainObject.TimeIncrement
        If useScheduleTime Then
          endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
        Else
          endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
        End If
        While True
          'Loop through all of the times
          For ii As Integer = startTimeIndex To endTimeIndex
            'Get the next time
            startTime = DateAdd(DateInterval.Minute, ii * MainObject.TimeIncrement, PivotTime)
            If Me.IsAreaAvailable(startDate, startTime, length, skipItems) Then
              If Not useScheduleTime OrElse (useScheduleTime AndAlso MainObject.IsTimeInRange(startTime, length)) Then
                Dim appointment As New Appointment(Me.MainObject)
                appointment.StartDate = startDate
                appointment.StartTime = startTime
                Return appointment
              ElseIf (loopIndex > 1830) Then
                'We have searched 5 years, so quit
                Return Nothing
              End If
            End If
          Next

          'Next day
          startDate = DateAdd(DateInterval.Day, 1, startDate)
          'Reset the time for next day
          If useScheduleTime Then
            startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.StartTime)) \ MainObject.TimeIncrement
            endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
          Else
            startTimeIndex = 0
            endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
          End If
          loopIndex += 1

        End While

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Date/Room/Time/Length
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean) As Appointment
      Return NextAreaAvailable(startDate, startRoom, startTime, length, useScheduleTime, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean, ByVal skipItems As AppointmentList) As Appointment

      Try

        Dim roomIndex As Integer

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return Nothing

        startTime = GetTime(startTime)

        'Make sure that we are in the proper range
        If startDate < MainObject.MinDate Then startDate = MainObject.MinDate
        If startTime < MainObject.StartTime Then startTime = MainObject.StartTime

        'Validate room
        roomIndex = MainObject.RoomCollection.IndexOfVisible(startRoom)
        If roomIndex = -1 Then Return Nothing

        'Loop through the days forever
        Dim loopIndex As Integer
        Dim startTimeIndex As Integer
        Dim endTimeIndex As Integer
        startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, startTime)) \ MainObject.TimeIncrement
        If useScheduleTime Then
          endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
        Else
          endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
        End If
        While True
          Dim startRoomIndex As Integer = roomIndex

          For jj As Integer = startRoomIndex To MainObject.RoomCollection.VisibleCount - 1

            'Loop through all of the times
            For ii As Integer = startTimeIndex To endTimeIndex
              'Get the next time
              startTime = DateAdd(DateInterval.Minute, ii * MainObject.TimeIncrement, PivotTime)
              If Me.IsAreaAvailable(startDate, MainObject.RoomCollection(jj), startTime, length, skipItems) Then
                If Not useScheduleTime OrElse (useScheduleTime AndAlso MainObject.IsTimeInRange(startTime, length)) Then
                  Dim appointment As New Appointment(Me.MainObject)
                  appointment.StartDate = startDate
                  appointment.Room = MainObject.RoomCollection(jj)
                  appointment.StartTime = startTime
                  Return appointment
                ElseIf (loopIndex > 1830) Then
                  'We have searched 5 years, so quit
                  Return Nothing
                End If
              End If
            Next            'Time Loop

            'Reset the time for next day
            If useScheduleTime Then
              startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.StartTime)) \ MainObject.TimeIncrement
              endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
            Else
              startTimeIndex = 0
              endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
            End If

          Next          'Room Loop

          'Next day
          startDate = DateAdd(DateInterval.Day, 1, startDate)
          roomIndex = 0
          loopIndex += 1
        End While

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Date/Room 
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room) As Appointment
      Return NextAreaAvailable(startDate, startRoom, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal skipItems As AppointmentList) As Appointment

      Try

        Dim roomIndex As Integer

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return Nothing

        'Make sure that we are in the proper range
        If startDate < MainObject.MinDate Then startDate = MainObject.MinDate

        'Validate room
        roomIndex = MainObject.RoomCollection.IndexOfVisible(startRoom)
        If roomIndex = -1 Then Return Nothing

        'Loop through the days forever
        While True
          Dim jj As Integer
          Dim startRoomIndex As Integer = roomIndex
          For jj = startRoomIndex To MainObject.RoomCollection.VisibleCount - 1
            If Me.IsAreaAvailable(startDate, MainObject.RoomCollection(jj), skipItems) Then
              Dim appointment As New Appointment(Me.MainObject)
              appointment.StartDate = startDate
              appointment.Room = MainObject.RoomCollection(jj)
              Return appointment
            End If
          Next 'Room Loop
          'Next day
          startDate = DateAdd(DateInterval.Day, 1, startDate)
          roomIndex = 0
        End While

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Date/Provider
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startProvider">The starting Provider object to initialize the search.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider) As Appointment
      Return NextAreaAvailable(startDate, startProvider, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startDate">The starting date to initialize the search.</param>
    ''' <param name="startProvider">The starting Provider object to initialize the search.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal skipItems As AppointmentList) As Appointment

      Try

        Dim providerIndex As Integer

        'If there is no provider then there is nothing to do
        If (startProvider Is Nothing) Then Return Nothing

        'Make sure that we are in the proper range
        If startDate < MainObject.MinDate Then startDate = MainObject.MinDate

        'Validate provider
        providerIndex = MainObject.ProviderCollection.IndexOfVisible(startProvider)
        If providerIndex = -1 Then Return Nothing

        'Loop through the days forever
        While True
          Dim jj As Integer
          Dim startproviderIndex As Integer = providerIndex
          For jj = startproviderIndex To MainObject.ProviderCollection.VisibleCount - 1
            If Me.IsAreaAvailable(startDate, MainObject.ProviderCollection(jj), skipItems) Then
              Dim appointment As New Appointment(Me.MainObject)
              appointment.StartDate = startDate
              appointment.ProviderList.Add(MainObject.ProviderCollection(jj))
              Return appointment
            End If
          Next 'provider Loop
          'Next day
          startDate = DateAdd(DateInterval.Day, 1, startDate)
          providerIndex = 0
        End While

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Room/Time/Length
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean) As Appointment
      Return NextAreaAvailable(startRoom, startTime, length, useScheduleTime, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startTime">The starting time to initialize the search.</param>
    ''' <param name="length">The length in minutes of the area to find.</param>
    ''' <param name="useScheduleTime">Determines if the schedule's StartTime and DayLength are used to define the search area. If false, the area is defined as midnight for 24 hours.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer, ByVal useScheduleTime As Boolean, ByVal skipItems As AppointmentList) As Appointment

      Try

        Dim roomIndex As Integer

        startTime = GetTime(startTime)

        'If there is no provider then there is nothing to do
        If (startRoom Is Nothing) Then Return Nothing

        'Make sure that we are in the proper range
        If startTime < MainObject.StartTime Then startTime = MainObject.StartTime

        'Validate room
        roomIndex = MainObject.RoomCollection.IndexOfVisible(startRoom)
        If roomIndex = -1 Then Return Nothing

        Dim startTimeIndex As Integer
        Dim endTimeIndex As Integer
        Dim ii As Integer
        Dim jj As Integer
        startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, startTime)) \ MainObject.TimeIncrement
        If useScheduleTime Then
          endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
        Else
          endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
        End If
        Dim startRoomIndex As Integer = roomIndex

        For jj = startRoomIndex To MainObject.RoomCollection.VisibleCount - 1

          'Loop through all of the times
          For ii = startTimeIndex To endTimeIndex
            'Get the next time
            startTime = DateAdd(DateInterval.Minute, ii * MainObject.TimeIncrement, PivotTime)
            If Me.IsAreaAvailable(MainObject.RoomCollection(jj), startTime, length, skipItems) Then
              If Not useScheduleTime OrElse (useScheduleTime AndAlso MainObject.IsTimeInRange(startTime, length)) Then
                Dim appointment As New Appointment(Me.MainObject)
                appointment.Room = MainObject.RoomCollection(jj)
                appointment.StartTime = startTime
                Return appointment
              End If
            End If
          Next 'Time Loop

          'Reset the time for next day
          If useScheduleTime Then
            startTimeIndex = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, MainObject.StartTime)) \ MainObject.TimeIncrement
            endTimeIndex = (GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, MainObject.EndTime)) \ MainObject.TimeIncrement) - 1
          Else
            startTimeIndex = 0
            endTimeIndex = (MinutesPerDay \ MainObject.TimeIncrement) - 1
          End If

        Next        'Room Loop

        Return Nothing

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    'Room/Provider
    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startProvider">The starting Provider object to initialize the search.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
    Public Function NextAreaAvailable(ByVal startRoom As Room, ByVal startProvider As Provider) As Appointment
      Return NextAreaAvailable(startRoom, startProvider, Nothing)
    End Function

    ''' <summary>
    ''' Determines the next available area where the an appointment will fit with no conflicts.
    ''' </summary>
    ''' <param name="startRoom">The starting Room object to initialize the search.</param>
    ''' <param name="startProvider">The starting Provider object to initialize the search.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. The list of appointments will not be considered as conflicting.</param>
    ''' <returns>An appointment that is not in the AppointmentCollection but has its properties set to values that describe the next available, non-conflicting area.</returns>
    ''' <remarks>This method does considers NoDropAreas and will not return an area overlapping a NoDropArea.</remarks>
		Public Function NextAreaAvailable(ByVal startRoom As Room, ByVal startProvider As Provider, ByVal skipItems As AppointmentList) As Appointment

			Try

				Dim roomIndex As Integer
				Dim providerIndex As Integer

				'If there is no provider then there is nothing to do
				If (startRoom Is Nothing) Then Return Nothing

				'If there is no provider then there is nothing to do
				If (startProvider Is Nothing) Then Return Nothing

				'Validate room
				roomIndex = MainObject.RoomCollection.IndexOfVisible(startRoom)
				If roomIndex = -1 Then Return Nothing

				'Validate provider
				providerIndex = MainObject.ProviderCollection.IndexOfVisible(startProvider)
				If providerIndex = -1 Then Return Nothing

				Dim ii As Integer
				Dim jj As Integer
				Dim startRoomIndex As Integer = roomIndex
				Dim startproviderIndex As Integer = providerIndex

				For jj = startRoomIndex To MainObject.RoomCollection.VisibleCount - 1
					'Loop through all of the times
					For ii = startproviderIndex To MainObject.ProviderCollection.VisibleCount - 1
						'Get the next time
						If Me.IsAreaAvailable(MainObject.RoomCollection(jj), MainObject.ProviderCollection(ii), skipItems) Then
							Dim appointment As New appointment(Me.MainObject)
							appointment.Room = MainObject.RoomCollection(jj)
							Call appointment.ProviderList.Add(MainObject.ProviderCollection(ii))
							Return appointment
						End If
          Next 'Provider Loop
          providerIndex = 0
        Next 'Room Loop
				Return Nothing

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

#End Region

#Region "IsConflict"

    ''' <summary>
    ''' Determines of the specified appointment conflicts with any appointments in this list.
    ''' </summary>
    ''' <param name="appointment">The appointment to check for conflicts.</param>
    ''' <param name="skipItems">Determines the list of appointments to skip when checking for conflicts. This list of appointments will not be considered as conflicting.</param>
    ''' <returns>True if there is one or more appointments in this list that overlap the specified appointment.</returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal appointment As Gravitybox.Objects.Appointment, ByVal skipItems As Gravitybox.Objects.AppointmentList) As Boolean

			Try
				Dim element As Gravitybox.Objects.Appointment
				For Each element In Me
					'Determine if we are to skip this object
					If Not skipItems.Contains(element) Then
						'If there is a conflict then return True
						If (Not (appointment Is Nothing) AndAlso Not (appointment Is element)) AndAlso appointment.IsConflict(element) Then
							Return True
						End If
					End If
				Next
				'Otherwise return False
				Return False

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    ''' <summary>
    ''' Determines of the specified appointment conflicts with any appointments in this list.
    ''' </summary>
    ''' <param name="appointment">The appointment to check for conflicts.</param>
    ''' <returns>True if there is one or more appointments in this list that overlap the specified appointment.</returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal appointment As Gravitybox.Objects.Appointment) As Boolean
			Return IsConflict(appointment, New AppointmentList(Me.MainObject))
		End Function

#End Region

#Region "GetConflicts"

    ''' <summary>
    ''' Returns a list of appointments that conflict with the specified appointment.
    ''' </summary>
    ''' <param name="appointment">The appointment to use when checking for conflicts.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function GetConflicts(ByVal appointment As Appointment) As AppointmentList

			'Check for error
			If appointment Is Nothing Then Return New AppointmentList(Me.MainObject)

			'Calculate list of appointments that conflict with the specfied object
			Try
				Dim retval As New AppointmentList(Me.MainObject)
				Dim element As appointment
				For Each element In Me
					'Make sure they are not the same appointment
					If Not (element Is appointment) Then
						'If conflict then return true
						If element.IsConflict(appointment) Then
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

    Public Function GetConflicts() As AppointmentList

      'Calculate list of appointments that conflict with the specfied object
      Try
        Dim retval As New AppointmentList(Me.MainObject)
        For Each element As Appointment In Me
          'Make sure they appointment is has not already been changed
          If Not retval.Contains(element) Then
            For Each element2 As Appointment In Me
              If element.IsConflict(element2) Then
                Call retval.Add(element)
                Exit For
              End If
            Next
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

		Public Sub Dispose() Implements IDisposable.Dispose
			BaseAppointment = Nothing
		End Sub

#End Region

	End Class

End Namespace