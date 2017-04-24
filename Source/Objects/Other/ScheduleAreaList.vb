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
  Public Class ScheduleAreaList
    Inherits Gravitybox.Objects.BaseList

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "schedulearealist"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

#End Region

#Region "On... Event Methods"

    Protected Overrides Sub OnClearComplete()
    End Sub

#End Region

#Region "Constructor"

    Friend Sub New()
    End Sub

    Public Sub New(ByVal scheduleAreaCollection As Gravitybox.Objects.ScheduleAreaCollection)
      Me.New()
      Try
        If scheduleAreaCollection Is Nothing Then Return
        Dim ScheduleArea As Gravitybox.Objects.ScheduleArea
        For Each ScheduleArea In scheduleAreaCollection
          Call Me.Add(ScheduleArea)
        Next
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "IndexOf"

    'Date/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try
        startTime = GetTime(startTime)
        If length < 0 Then length = 0

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startRoom">The Room object of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return -1

        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startRoom, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startProvider">The Provider object of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startProvider Is Nothing) Then Return -1

        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startProvider, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room 
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startRoom">The Room object of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startRoom As Room) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return -1

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startRoom) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startProvider">The Provider object of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startProvider As Provider) As Integer

      Try

        'If there is no provider then there is nothing to do
        If (startProvider Is Nothing) Then Return -1

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startProvider) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Resource
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startResource">The Resource object of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startDate As DateTime, ByVal startResource As Resource) As Integer

      Try

        'If there is no provider then there is nothing to do
        If (startResource Is Nothing) Then Return -1

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startDate, startResource) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startRoom">The Room object of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return -1

        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startRoom, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Resource/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startResource">The Resource object of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startResource As Resource, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no Resource then there is nothing to do
        If (startResource Is Nothing) Then Return -1

        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startResource, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Provider/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startProvider">The Provider object of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startProvider Is Nothing) Then Return -1

        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startProvider, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Provider/Date/Time/Length
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startProvider">The Provider object of the area to find.</param>
    ''' <param name="startDate">The date of the area to find.</param>
    ''' <param name="startTime">The time inside of the area to find.</param>
    ''' <param name="length">The minimum length in minutes of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startProvider As Provider, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startProvider Is Nothing) Then Return -1

        startDate = GetDate(startDate)
        startTime = GetTime(startTime)

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startProvider, startDate, startTime, length) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Provider
    ''' <summary>
    ''' Determines the index of an area that matches the specified criteria.
    ''' </summary>
    ''' <param name="startRoom">The Room object of the area to find.</param>
    ''' <param name="startProvider">The Provider object of the area to find.</param>
    ''' <returns></returns>
    ''' <remarks>The date, time, and length may not exactly match the returned area. The area returned will contain these attributes but may not match these attributes. For example, the area #1:00 PM# to #6:00 PM# contains the area #3:00 PM# to #4:00 PM# but does not match it.</remarks>
    Public Shadows Function IndexOf(ByVal startRoom As Room, ByVal startProvider As Provider) As Integer

      Try

        'If there is no room then there is nothing to do
        If (startRoom Is Nothing) Then Return -1
        If (startProvider Is Nothing) Then Return -1

        'Loop to determine if there are any areas that conflict with the 
        'input parameters and if so Return -1 since the area is NOT enabled
        For Each element As ScheduleArea In Me
          'Check to make sure that the nodrop area is the proper format for checking
          If element.IsConflict(startRoom, startProvider) Then
            Return MyBase.IndexOf(element)
          End If
        Next
        Return -1

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "IsOverlap"

    'Date/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startDate, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startProvider">The Provider object of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startDate, startProvider, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startRoom">The Room object of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startDate, startRoom, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Room 
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startRoom">The Room object of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startRoom As Room) As Boolean

      Try
        Return (Me.IndexOf(startDate, startRoom) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Provider
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startProvider">The Provider object of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startProvider As Provider) As Boolean

      Try
        Return (Me.IndexOf(startDate, startProvider) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Date/Resource
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startResource">The Resource object of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startDate As DateTime, ByVal startResource As Resource) As Boolean

      Try
        Return (Me.IndexOf(startDate, startResource) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startRoom">The Room object of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startRoom As Room, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startRoom, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Resource/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startResource">The Resource object of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startResource As Resource, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startResource, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Provider/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startProvider">The Provider object of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startProvider As Provider, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startProvider, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Provider/Date/Time/Length
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startProvider">The Provider object of the area to check.</param>
    ''' <param name="startDate">The date of the area to check.</param>
    ''' <param name="startTime">The time of the area to check.</param>
    ''' <param name="length">The length in minutes of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startProvider As Provider, ByVal startDate As DateTime, ByVal startTime As DateTime, ByVal length As Integer) As Boolean

      Try
        Return (Me.IndexOf(startProvider, startDate, startTime, length) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    'Room/Provider
    ''' <summary>
    ''' Determines if the specified parameters define an area that overlaps any other area in this list.
    ''' </summary>
    ''' <param name="startRoom">The Room object of the area to check.</param>
    ''' <param name="startProvider">The Provider object of the area to check.</param>
    ''' <returns>True if there is an overlap, false otherwise.</returns>
    Public Function IsOverlap(ByVal startRoom As Room, ByVal startProvider As Provider) As Boolean

      Try
        Return (Me.IndexOf(startRoom, startProvider) <> -1)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts all objects in this list to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String
      Return ""
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overrides Function FromXML(ByVal xml As String) As Boolean
      Return False
    End Function

    Friend Function XmlNode() As System.Xml.XmlNode
      Return Nothing
    End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Return False
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Return False
    End Function

#End Region

  End Class

End Namespace