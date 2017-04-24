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

  <Serializable(), _
  DefaultEvent("Refresh"), _
  DefaultProperty("Text")> _
  Public Class ScheduleArea
    Inherits BaseObject

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "schedulearea"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Property Constants
    Private Const m_def_StartDate As DateTime = DefaultNoDate
		Private Const m_def_Room As Integer = -1
		Private Const m_def_Resource As Integer = -1
    Private Const m_def_Provider As Integer = -1
    Private Const m_def_StartTime As DateTime = DefaultNoTime
    Private Const m_def_Length As Integer = 0
    Private ReadOnly m_def_AreaType As ScheduleAreaTypeConstants = ScheduleAreaTypeConstants.None

    'Property Variables
    Private m_StartDate As DateTime = m_def_StartDate
    Private m_Room As Integer = m_def_Room
    Private m_Resource As Integer = m_def_Resource
    Private m_Provider As Integer = m_def_Provider
    Private m_StartTime As DateTime = m_def_StartTime
    Private m_Length As Integer = m_def_Length
    Private m_AreaType As ScheduleAreaTypeConstants = m_def_AreaType

    'Internal Objects
    <NonSerialized()> Private MainObject As Gravitybox.Controls.Schedule
    Private m_Appearance As New Gravitybox.Objects.Appearance

#End Region

#Region "Constructor"

    Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
      MyBase.New("", "")
      Me.MainObject = mainObject
      AddHandler m_Appearance.Refresh, AddressOf OnRefreshAppearanceCollection
    End Sub

    Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule, ByVal backcolor As Color, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer, ByVal room As Room, ByVal provider As Provider)
      MyBase.New("", "")
      Me.MainObject = mainObject
      If startTime <> DefaultNoTime Then startTime = GetTime(startTime)
      Me.Appearance.BackColor = backcolor
      If startDate = DefaultNoDate Then
        m_StartDate = DefaultNoDate
      Else
        m_StartDate = GetDate(startDate)
      End If
      If startTime = DefaultNoTime Then
        m_StartTime = DefaultNoTime
      Else
        m_StartTime = GetTime(startTime)
      End If
      m_Length = length
      If room Is Nothing Then
        m_Room = -1
      Else
        m_Room = mainObject.RoomCollection.IndexOfVisible(room)
      End If
      If provider Is Nothing Then
        m_Provider = -1
      Else
        m_Provider = mainObject.ProviderCollection.IndexOfVisible(provider)
      End If
      Call CalculateAreaType()

      AddHandler m_Appearance.Refresh, AddressOf OnRefreshAppearanceCollection

    End Sub

#End Region

#Region "OnRefreshAppearanceCollection"

    Private Sub OnRefreshAppearanceCollection(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
    End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.ScheduleArea(Me.MainObject)
				element.FromXML(Me.ToXML)
				element.SetKey(Guid.NewGuid.ToString)
				Return element
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' The associated starting date defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("The associated starting date defined by this area.")> _
    Public ReadOnly Property StartDate() As DateTime
      Get
        Return m_StartDate
      End Get
    End Property

    ''' <summary>
    ''' The associated room defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("The associated room defined by this area.")> _
    Public ReadOnly Property Room() As Integer
      Get
        Return m_Room
      End Get
    End Property

    ''' <summary>
    ''' The associated resource defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("The associated resource defined by this area.")> _
    Public ReadOnly Property Resource() As Integer
      Get
        Return m_Resource
      End Get
    End Property

    ''' <summary>
    ''' The associated provider defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("The associated provider defined by this area.")> _
    Public ReadOnly Property Provider() As Integer
      Get
        Return m_Provider
      End Get
    End Property

    ''' <summary>
    ''' The associated starting time defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Editor(GetType(Gravitybox.Design.Editors.TimeUIEditor), GetType(System.Drawing.Design.UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter)), _
    Description("The associated starting time defined by this area.")> _
    Public ReadOnly Property StartTime() As DateTime
      Get
        Return m_StartTime
      End Get
    End Property

    ''' <summary>
    ''' The associated length in minutes defined by this area.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("The associated length in minutes defined by this area.")> _
    Public ReadOnly Property Length() As Integer
      Get
        Return m_Length
      End Get
    End Property

		<Browsable(False)> _
		Friend Property AreaType() As ScheduleAreaTypeConstants
			Get
				Return m_AreaType
			End Get
			Set(ByVal Value As ScheduleAreaTypeConstants)
				m_AreaType = Value
			End Set
		End Property

    ''' <summary>
    ''' Determines the appearance of the object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("Determines the appearance of the object.")> _
    Public Property Appearance() As Appearance
      Get
        Return m_Appearance
      End Get
      Set(ByVal Value As Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        RemoveHandler m_Appearance.Refresh, AddressOf OnRefreshAppearanceCollection
        m_Appearance = Value
        AddHandler m_Appearance.Refresh, AddressOf OnRefreshAppearanceCollection
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
      End Set
    End Property

#End Region

#Region "CalculateAreaType"

		Private Sub CalculateAreaType()

			Dim myType As ScheduleAreaTypeConstants = ScheduleAreaTypeConstants.None

			Try
				'Calculate the settings for this area object
				If Me.StartDate <> m_def_StartDate Then myType = myType Or ScheduleAreaTypeConstants.Day
				If Me.StartTime <> m_def_StartTime Then myType = myType Or ScheduleAreaTypeConstants.Time
				If Me.Room <> m_def_Room Then myType = myType Or ScheduleAreaTypeConstants.Room
				If Me.Provider <> m_def_Provider Then myType = myType Or ScheduleAreaTypeConstants.Provider
				Me.AreaType = myType
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "IsConflict"

    'Date/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'Error Check
        startDate = GetDate(startDate)
        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.DayTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

		End Function

    'Date/Room/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="room"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal startDate As DateTime, ByVal room As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no room then there is nothing to do
        If (Room Is Nothing) Then Return False

        startDate = GetDate(startDate)
        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.DayRoomTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartRoom = Me.Room
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.DayRoom Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.DayTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.RoomTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Room Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="provider"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal startDate As DateTime, ByVal provider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no room then there is nothing to do
        If (provider Is Nothing) Then Return False

        startDate = GetDate(startDate)
        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.DayProviderTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.DayProvider Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.DayTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Provider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room 
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="Room"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal startDate As DateTime, ByVal Room As Room) As Boolean

			Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no room then there is nothing to do
				If (Room Is Nothing) Then Return False

				startDate = GetDate(startDate)

				'Check to ensure that the object type and parameter list matches
				'If any portion of the area does not match then there is no conflict
				If Me.AreaType = ScheduleAreaTypeConstants.DayRoom Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(Room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Room Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(Room)
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    'Date/Provider
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="Provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal startDate As DateTime, ByVal Provider As Provider) As Boolean

			Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no provider then there is nothing to do
				If (Provider Is Nothing) Then Return False

				startDate = GetDate(startDate)

				'Check to ensure that the object type and parameter list matches
				'If any portion of the area does not match then there is no conflict
				If Me.AreaType = ScheduleAreaTypeConstants.DayProvider Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Provider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Resource
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="resource"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal startDate As DateTime, ByVal resource As Resource) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no resource then there is nothing to do
        If (resource Is Nothing) Then Return False

        startDate = GetDate(startDate)

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.DayResource Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartResource = Me.Resource
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartResource = MainObject.ResourceCollection.IndexOfVisible(resource)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Day Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          testRect.StartDate = startDate
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Resource Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartResource = Me.Resource
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartResource = MainObject.ResourceCollection.IndexOfVisible(resource)
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="Room"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal Room As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no room then there is nothing to do
        If (Room Is Nothing) Then Return False

        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.RoomTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(Room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Room Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(Room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Resource/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="resource"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal resource As Resource, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

			Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no Resource then there is nothing to do
				If (resource Is Nothing) Then Return False

				startTime = GetTime(startTime)
				If length < 0 Then length = 0

				'Check to ensure that the object type and parameter list matches
				'If any portion of the area does not match then there is no conflict
				If Me.AreaType = ScheduleAreaTypeConstants.ResourceTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartResource = Me.Resource
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartResource = MainObject.ResourceCollection.IndexOfVisible(resource)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Resource Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartResource = Me.Resource
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartResource = MainObject.ResourceCollection.IndexOfVisible(resource)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

    'Provider/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="Provider"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
		Public Function IsConflict(ByVal Provider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

			Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no provider then there is nothing to do
				If (Provider Is Nothing) Then Return False

				startTime = GetTime(startTime)
				If length < 0 Then length = 0

				'Check to ensure that the object type and parameter list matches
				'If any portion of the area does not match then there is no conflict
				If Me.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Provider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Provider/Date/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="provider"></param>
    ''' <param name="startDate"></param>
    ''' <param name="startTime"></param>
    ''' <param name="length"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal provider As Provider, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'If there is no provider then there is nothing to do
        If (Provider Is Nothing) Then Return False

        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Provider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(Provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Time Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = startTime
          testRect.Length = length
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.ProviderDayTime Then
          areaRect.StartDate = Me.StartDate
          areaRect.StartTime = Me.StartTime
          areaRect.Length = Me.Length
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = startDate
          testRect.StartTime = startTime
          testRect.Length = length
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Provider
    ''' <summary>
    ''' Determines if the specified parameters conflict with this schedule area object.
    ''' </summary>
    ''' <param name="room"></param>
    ''' <param name="provider"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsConflict(ByVal room As Room, ByVal provider As Provider) As Boolean

      Try
        Dim areaRect As New AppointmentRectangleInfo()
        Dim testRect As New AppointmentRectangleInfo()

        'Check to ensure that the object type and parameter list matches
        'If any portion of the area does not match then there is no conflict
        If Me.AreaType = ScheduleAreaTypeConstants.RoomProvider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Room Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartRoom = Me.Room
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartRoom = MainObject.RoomCollection.IndexOfVisible(room)
        ElseIf Me.AreaType = ScheduleAreaTypeConstants.Provider Then
          areaRect.StartDate = #1/1/2000#
          areaRect.StartTime = PivotTime
          areaRect.Length = MinutesPerDay
          areaRect.StartProvider = Me.Provider
          testRect.StartDate = #1/1/2000#
          testRect.StartTime = PivotTime
          testRect.Length = MinutesPerDay
          testRect.StartProvider = MainObject.ProviderCollection.IndexOfVisible(provider)
        End If

        CalculateSortIndex(MainObject.ViewMode, areaRect, MainObject)
        CalculateSortIndex(MainObject.ViewMode, testRect, MainObject)
        Return (areaRect.SortIndexStart < testRect.SortIndexEnd) AndAlso (areaRect.SortIndexEnd > testRect.SortIndexStart)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the object to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement
      Dim elemNew As Xml.XmlNode

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "key", Me.Key)
        Call xmlHelper.addElement(parentNode, "text", Me.Text)
        Call xmlHelper.addElement(parentNode, "startdate", DateToLong(GetDate(m_StartDate)).ToString)
        Call xmlHelper.addElement(parentNode, "room", m_Room.ToString)
        Call xmlHelper.addElement(parentNode, "resource", m_Resource.ToString)
        Call xmlHelper.addElement(parentNode, "provider", m_Provider.ToString)
        Call xmlHelper.addElement(parentNode, "starttime", TimeToLong(GetTime(m_StartTime)).ToString)
        Call xmlHelper.addElement(parentNode, "length", m_Length.ToString)
        Call xmlHelper.addElement(parentNode, "AreaType", m_AreaType.ToString)

        'PropertyItemCollection
        elemNew = xmlHelper.addElement(parentNode, PropertyItemCollection.MyXMLNodeName, "")
        elemNew.InnerXml = PropertyItemCollection.XmlNode.InnerXml

        'Return the XML string
        Return parentNode.OuterXml

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

		Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean
			Return Me.FromXML(xml, False, False)
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
        If xml = "" Then Return False
        XMLDoc.InnerXml = xml

        'Load all properties
        Me.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
        Me.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))
        m_StartDate = LongToDate(GetNodeValue(XMLDoc, startXPath & "startdate", DateToLong(GetDate(m_StartDate)).ToString))
        m_Room = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "room", m_Room.ToString))
        m_Resource = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "resource", m_Resource.ToString))
        m_Provider = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "provider", m_Provider.ToString))
        m_StartTime = LongToTime(GetNodeValue(XMLDoc, startXPath & "starttime", TimeToLong(GetTime(m_StartTime)).ToString))
        m_Length = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "length", m_Length.ToString))
        m_AreaType = CType([Enum].Parse(GetType(ScheduleAreaTypeConstants), GetNodeValue(XMLDoc, startXPath & "AreaType", m_AreaType.ToString("d"))), ScheduleAreaTypeConstants)

        'Objects
        PropertyItemCollection.Clear()
        PropertyItemCollection.FromXML(GetNodeXML(XMLDoc, startXPath & PropertyItemCollection.MyXMLNodeName, "", True))

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
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