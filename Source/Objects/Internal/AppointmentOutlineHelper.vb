Option Strict On
Option Explicit On 

Imports System
Imports Gravitybox.Objects.EventArgs
Imports Gravitybox.Objects

Namespace Gravitybox.Controls

	Friend Class AppointmentOutlineHelper

#Region "Class Members"

		Dim MainObject As Schedule
		Private m_DragRectArray As New ArrayList
		Private m_ResizeRowColObject As New ResizeRowColInfo

#End Region

#Region "Constructor"

		Friend Sub New(ByVal scheduleObject As Schedule)
			MainObject = scheduleObject
		End Sub

#End Region

#Region "Property Implementations"

		Friend ReadOnly Property DragRectArray() As ArrayList
			Get
				Return m_DragRectArray
			End Get
		End Property

		Friend Property ResizeRowColObject() As ResizeRowColInfo
			Get
				Return m_ResizeRowColObject
			End Get
			Set(ByVal Value As ResizeRowColInfo)
				m_ResizeRowColObject = Value
			End Set
		End Property

#End Region

#Region "DrawAppointmentResizeOutline"

		Friend Function DrawAppointmentResizeOutline(ByVal appointment As Appointment, _
		 ByVal pt As Point, _
		 ByVal useLength As Boolean, _
		 ByRef newStartDate As DateTime, ByRef newStartTime As DateTime, ByRef newLength As Integer) As Boolean

			'Error check
			If appointment Is Nothing Then Return False
			If appointment.IsReadOnly Then Return False

			Dim toolTipText As String = ""
			'Dim tmpDragRect As Rectangle
			'Dim left As Integer
			'Dim top As Integer
			'Dim width As Integer
			'Dim height As Integer

			'Error Check
			If pt.X < MainObject.ClientLeft Then pt.X = MainObject.ClientLeft
			If pt.Y < MainObject.ClientTop Then pt.Y = MainObject.ClientTop

			newStartDate = ScheduleGlobals.GetDateByViewMode(MainObject.ViewMode, appointment.StartDate)
			Try

				MainObject.DrawingDirty = True
				If useLength Then

					'************************************************
					'Calculate the Length
					Select Case MainObject.ViewMode
            Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
              Dim newEndDate As Date = MainObject.Visibility.GetDateFromCor(pt.X, pt.Y)
              newStartTime = MainObject.Visibility.GetTimeFromCor(New Point(pt.X + (MainObject.ColumnHeader.Size \ 2), pt.Y + (MainObject.RowHeader.Size \ 2)), MainObject.AppointmentTimeIncrement)
              If ResizeRowColObject.GetDateTime(newEndDate, newStartTime) <= ResizeRowColObject.GetDateTime Then
                newStartTime = ResizeRowColObject.StartTime
                newLength = MainObject.AppointmentTimeIncrement
              Else
                newLength = GetIntlInteger(ResizeRowColObject.GetDateTime(newEndDate, newStartTime).Subtract(ResizeRowColObject.GetDateTime).TotalMinutes)
                newStartTime = appointment.StartTime
              End If

              'Setup the cursor
              Select Case MainObject.ViewMode
                Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
                Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
              End Select

						Case Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop
							newStartTime = MainObject.Visibility.GetTimeFromCor(New Point(pt.X + (MainObject.ColumnHeader.Size \ 2), pt.Y + (MainObject.RowHeader.Size \ 2)), MainObject.AppointmentTimeIncrement)
							If ResizeRowColObject.GetDateTime(newStartDate, newStartTime) <= ResizeRowColObject.GetDateTime Then
								newStartTime = ResizeRowColObject.StartTime
								newLength = MainObject.AppointmentTimeIncrement
							Else
								newLength = GetIntlInteger(ResizeRowColObject.GetDateTime(newStartDate, newStartTime).Subtract(ResizeRowColObject.GetDateTime).TotalMinutes)
								newStartTime = appointment.StartTime
							End If

							'Setup the cursor
							Select Case MainObject.ViewMode
                Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
                Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
              End Select

            Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
              'Do Nothing
              Return False

						Case Schedule.ViewModeConstants.Month
							'TODO - Month
							Return False

						Case Schedule.ViewModeConstants.Week
							'Do Nothing

						Case Schedule.ViewModeConstants.MonthFull
							'TODO - MonthFull
							Return False

						Case Else
							Call ErrorModule.ViewmodeErr()

					End Select

				Else				'Do Not use length, use start time
					'************************************************
					'Calculate the StartTime
					Select Case MainObject.ViewMode
            Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft
              newStartDate = ScheduleGlobals.GetDateByViewMode(MainObject.ViewMode, MainObject.Visibility.GetDateFromCor(pt.X, pt.Y))
              newStartTime = MainObject.Visibility.GetTimeFromCor(New Point(pt.X + (MainObject.ColumnHeader.Size \ 2), pt.Y + (MainObject.RowHeader.Size \ 2)), MainObject.AppointmentTimeIncrement)
              Dim apptEnd As DateTime = DateAdd(DateInterval.Minute, ResizeRowColObject.Length, ResizeRowColObject.GetDateTime)
              newLength = GetIntlInteger(DateDiff(DateInterval.Minute, ResizeRowColObject.GetDateTime(newStartDate, newStartTime), apptEnd))
              If newLength < MainObject.AppointmentTimeIncrement Then
                newLength = MainObject.AppointmentTimeIncrement
                newStartTime = DateAdd(DateInterval.Minute, -newLength, apptEnd)
              End If

              'Setup the cursor
              Select Case MainObject.ViewMode
                Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.HSplit
                Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
                  System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.VSplit
              End Select

            Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
              'Do Nothing
              Return False

						Case Schedule.ViewModeConstants.Month
							'TODO - Month
							Return False

						Case Schedule.ViewModeConstants.Week
							'Do Nothing

						Case Schedule.ViewModeConstants.MonthFull
							'TODO - MonthFull

						Case Else
							Call ErrorModule.ViewmodeErr()

					End Select

				End If

				'If the new times overlap a NoDropArea then reset to the last valid settings
				If MainObject.NoDropAreaCollection.ToList.IsOverlap(newStartDate, newStartTime, newLength) Then
					newStartTime = ResizeRowColObject.StartTime
					newLength = ResizeRowColObject.Length
				End If

				'Validate min/max length
				If appointment.MinLength <> -1 Then
					If newLength < appointment.MinLength Then newLength = appointment.MinLength
				End If
				If appointment.MaxLength <> -1 Then
					If newLength > appointment.MaxLength Then newLength = appointment.MaxLength
				End If

				'Give the container a chance to cancel
				Dim eventParam1 As New AppointmentSizeEventsArgs(appointment, newStartTime, newLength)
				MainObject.OnWhileAppointmentResize(eventParam1)
				If eventParam1.Cancel Then Return False
				newStartTime = eventParam1.StartTime
				newLength = eventParam1.Length

				'Create a temp appointment for the necessary rectangles
				Dim drawAppointment As New appointment(MainObject)
				If ScheduleGlobals.ViewmodeHasDate(MainObject.ViewMode) Then
					drawAppointment.StartDate = newStartDate
				End If
				drawAppointment.StartTime = newStartTime
				drawAppointment.Length = newLength
				drawAppointment.Room = appointment.Room
				drawAppointment.ProviderList.Add(appointment.ProviderList)
				drawAppointment.ResourceList.Add(appointment.ResourceList)
				MainObject.Canvas.SetupAppointment(drawAppointment)
				drawAppointment.CalculateSortIndexes()

				Dim eventParam2 As New Gravitybox.Objects.EventArgs.BeforeDragTipEventArgs(newStartDate, newStartTime, appointment.Room, drawAppointment.FirstProvider)
				MainObject.OnBeforeResizeTip(eventParam2)
				If Not eventParam2.Cancel Then

					'Draw the drag tip if necessary
					If MainObject.AllowDragTip Then
						Select Case MainObject.ViewMode
              Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
                toolTipText = eventParam1.DateString & newStartTime.ToShortTimeString & "  " & eventParam1.TimeString & newLength
              Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
                'Do Nothing
							Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
								toolTipText = eventParam1.DateString & newStartTime.ToShortTimeString & "  " & eventParam1.TimeString & newLength
							Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
								toolTipText = eventParam1.DateString & newStartTime.ToShortTimeString & "  " & eventParam1.TimeString & newLength
							Case Schedule.ViewModeConstants.Week
								'Do Nothing
							Case Schedule.ViewModeConstants.MonthFull
								'Do Nothing
							Case Else
								Call ErrorModule.ViewmodeErr()
						End Select
					End If

					'If the schedule allows for a drag tip then show it
					If MainObject.AllowDragTip AndAlso (MainObject.lblToolTip.Text <> toolTipText) Then
						MainObject.lblToolTip.Text = toolTipText
						MainObject.lblToolTip.Location = New Point(10, 10)
						MainObject.lblToolTip.Visible = True
					End If

				End If				'Cancel DragTip

				'Draw the outline
				'Call DrawOutline(tmpDragRect)
				Call DrawOutline(drawAppointment)

				Return True

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "DrawDragOutline"

		Friend Function DrawDragOutline(ByVal pt As Point, ByVal appointment As Appointment, ByVal apptLength As Integer, ByVal ignoreToolTip As Boolean) As Boolean

			'Only draw if necessary
			If Not MainObject.Visibility.IsInRangeCor(pt) Then Return False

			Dim left As Integer
			Dim top As Integer
			Dim newStartDate As DateTime
			Dim newStartTime As DateTime
			Dim newRoom As Integer
			Dim newProvider As Integer
			Dim newResource As Integer
      Dim toolTipText As String = ""
			Dim cellBlockSize As Integer
			Dim isEvent As Boolean

			Try

				'If we are out of range then nothing to do
				If pt.X < MainObject.ClientLeft Then
					MainObject.lblToolTip.Visible = False
					Return False
				ElseIf pt.Y < MainObject.TopHeaderHeight Then
					MainObject.lblToolTip.Visible = False
					Return False
				ElseIf pt.X > MainObject.ClientLeft + MainObject.ClientWidth Then
					MainObject.lblToolTip.Visible = False
					Return False
				ElseIf pt.Y > MainObject.ClientTop + MainObject.ClientHeight Then
					MainObject.lblToolTip.Visible = False
					Return False
				End If

				newStartDate = MainObject.Visibility.GetDateFromCor(pt)
				newRoom = MainObject.Visibility.GetRoomFromCor(pt)
				newProvider = MainObject.Visibility.GetProviderFromCor(pt)
				newResource = MainObject.Visibility.GetResourceFromCor(pt)
				If MainObject.EventHeader.AllowHeader AndAlso pt.Y < MainObject.ClientTop Then
					newStartTime = PivotTime
					isEvent = True
				Else
					newStartTime = MainObject.Visibility.GetTimeFromCor(pt, MainObject.AppointmentTimeIncrement)
					isEvent = False
				End If

				'Check to enforce time limits if necessary
				'Select Case MainObject.ViewMode
				'  Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft
				'    If MainObject.EnforceBounds Then
				'      If Not IsTimeInRange(newStartTime, appointment.Length) Then Return False
				'    End If
				'End Select

				Dim rowHeight As Integer = MainObject.RowHeader.Size
				'Convert the indexes to real coordinates
				left = MainObject.ClientLeft + (left * MainObject.ColumnHeader.Size)
				top = MainObject.ClientTop + (top * rowHeight)

				'Build the prompt
				If MainObject.AllowDragTip Then
					'Raise the event to notify the user 
					Dim roomObject As Gravitybox.Objects.Room = Nothing
					Dim providerObject As Gravitybox.Objects.Provider = Nothing
					Dim resourceObject As Gravitybox.Objects.Resource = Nothing
					If MainObject.RoomCollection.Contains(newRoom) Then roomObject = MainObject.RoomCollection(newRoom)
					If MainObject.ProviderCollection.Contains(newProvider) Then providerObject = MainObject.ProviderCollection(newProvider)
					If MainObject.ResourceCollection.Contains(newResource) Then resourceObject = MainObject.ResourceCollection(newResource)
					Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeDragTipEventArgs(newStartDate, newStartTime, roomObject, providerObject)
					MainObject.OnBeforeDragTip(eventParam1)
					If Not eventParam1.Cancel Then

						Select Case MainObject.ViewMode
							Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.Month
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "{0}"
							Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayLeftRoomTop
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "  " & MainObject.RoomCollection.ObjectSingular & ": " & MainObject.RoomCollection(newRoom).Text
							Case Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftProviderTop
                toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "  " & MainObject.ProviderCollection.ObjectSingular & ": " & MainObject.ProviderCollection(newProvider).Text
              Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
                toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "  " & MainObject.ResourceCollection.ObjectSingular & ": " & MainObject.ResourceCollection(newResource).Text
              Case Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop
                toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "  " & MainObject.RoomCollection.ObjectSingular & ": " & MainObject.RoomCollection(newRoom).Text & "{0}"
              Case Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayProviderLeftTimeTop
                toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "  " & MainObject.ProviderCollection.ObjectSingular & ": " & MainObject.ProviderCollection(newProvider).Text & "{0}"
              Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop
                toolTipText = MainObject.RoomCollection.ObjectSingular & ": " & MainObject.RoomCollection(newRoom).Text & "{0}"
							Case Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop
								toolTipText = MainObject.RoomCollection.ObjectSingular & ": " & MainObject.RoomCollection(newRoom).Text & "  " & MainObject.ProviderCollection.ObjectSingular & ": " & MainObject.ProviderCollection(newProvider).Text
							Case Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft
								toolTipText = MainObject.ProviderCollection.ObjectSingular & ": " & MainObject.ProviderCollection(newProvider).Text & "{0}"
							Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "{0}" & "  " & MainObject.ProviderCollection.ObjectSingular & ": " & MainObject.ProviderCollection(newProvider).Text
							Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "{0}" & "  " & MainObject.RoomCollection.ObjectSingular & ": " & MainObject.RoomCollection(newRoom).Text
							Case Schedule.ViewModeConstants.Week
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString
							Case Schedule.ViewModeConstants.MonthFull
								toolTipText = eventParam1.DateString & newStartDate.ToShortDateString & "{0}"
							Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
								toolTipText = MainObject.ResourceCollection.ObjectSingular & ": " & MainObject.ResourceCollection(newResource).Text & "{0}"
							Case Else
								Call ErrorModule.ViewmodeErr()
						End Select

						'Only draw the time portion if this is not an "All Day Event"
						If isEvent OrElse (newStartTime = DefaultNoTime) Then
							toolTipText = String.Format(toolTipText, "")
						Else
							toolTipText = String.Format(toolTipText, "  " & eventParam1.TimeString & newStartTime.ToShortTimeString)
						End If

					End If

					'If the schedule allows for a drag tip then show it
					If MainObject.AllowDragTip AndAlso (MainObject.lblToolTip.Text <> toolTipText) AndAlso Not ignoreToolTip Then
						MainObject.lblToolTip.Text = toolTipText
						MainObject.lblToolTip.Location = New Point(10, 10)
						MainObject.lblToolTip.Visible = True
					End If

				End If				'Cancel DragTip

				Dim skipItems As New AppointmentList(MainObject)
				Call skipItems.Add(appointment)

				'Calculate if this area is enabled for an appointment
				If Not MainObject.IsAreaEnabledFromPoint(MainObject.NoDropAreaCollection.ToList, newStartDate, newStartTime, appointment.Length, newRoom, newProvider, newResource) Then
					Return False
				End If

				Dim tmpDragRect As Rectangle

				'If this is an event then just use one time increment
				If apptLength = MinutesPerDay - 1 Then
					apptLength = MainObject.TimeIncrement
				End If

				'Set the appointment's new position
        Select Case MainObject.ViewMode
          Case Schedule.ViewModeConstants.DayTopTimeLeft
            left = MainObject.ClientLeft + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayLeftTimeTop
            Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            left = MainObject.ClientLeft + CType((skew - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size, Integer)
            top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.ColumnHeader.Size)
            tmpDragRect = New Rectangle(left, top, cellBlockSize, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.DayTopRoomLeft
            left = MainObject.ClientLeft + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((newRoom - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = MainObject.RowHeader.Size
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayLeftRoomTop
            'left = MainObject.ClientLeft + ((newRoom - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(newRoom) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.DayTopProviderLeft
            left = MainObject.ClientLeft + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((newProvider - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = MainObject.RowHeader.Size
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayLeftProviderTop
            'left = MainObject.ClientLeft + ((newProvider - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(newProvider) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, MainObject.RowHeader.Size)

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            left = MainObject.ClientLeft + ((MainObject.ResourceCollection.IndexOfVisible(newResource) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((MainObject.Visibility.GetRowColFromDate(newStartDate) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
            left = MainObject.ClientLeft + ((MainObject.Visibility.GetColumnFromCor(pt.X, pt.Y) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop
            Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            left = MainObject.ClientLeft + CType((skew - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size, Integer)
            top = MainObject.ClientTop + ((MainObject.Visibility.GetRowFromCor(pt.X, pt.Y) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.ColumnHeader.Size)
            tmpDragRect = New Rectangle(left, top, cellBlockSize, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.RoomTopTimeLeft
            left = MainObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(newRoom) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.RoomLeftTimeTop
            Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            left = MainObject.ClientLeft + CType((skew - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size, Integer)
            top = MainObject.ClientTop + ((newRoom - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.ColumnHeader.Size)
            tmpDragRect = New Rectangle(left, top, cellBlockSize, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.RoomTopProviderLeft
            'left = MainObject.ClientLeft + ((newRoom - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'top = MainObject.ClientTop + ((newProvider - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(newRoom) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              top = MainObject.ClientTop + ((MainObject.ProviderCollection.IndexOfVisible(newProvider) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.RoomLeftProviderTop
            'left = MainObject.ClientLeft + ((newProvider - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'top = MainObject.ClientTop + ((newRoom - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(newProvider) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + ((MainObject.RoomCollection.IndexOfVisible(newRoom) - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.ProviderLeftTimeTop
            Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            left = MainObject.ClientLeft + CType((skew - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size, Integer)
            top = MainObject.ClientTop + ((newProvider - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.ColumnHeader.Size)
            tmpDragRect = New Rectangle(left, top, cellBlockSize, MainObject.RowHeader.Size)

          Case Schedule.ViewModeConstants.ProviderTopTimeLeft
            'left = MainObject.ClientLeft + ((newProvider - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            'top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
            'cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(newProvider) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            'left = MainObject.ClientLeft + ((newProvider - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'Dim skew As Decimal = MainObject.Visibility.GetRowColFromDate(newStartDate)
            'skew += MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            'top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
            'cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(newProvider) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromDate(newStartDate)
              skew += MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            'left = MainObject.ClientLeft + ((newRoom - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'Dim skew As Decimal = MainObject.Visibility.GetRowColFromDate(newStartDate)
            'skew += MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            'top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
            'cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(newRoom) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromDate(newStartDate)
              skew += MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Schedule.ViewModeConstants.Month
            Dim col As Integer = MainObject.Visibility.GetColumnFromCor(pt)
            Dim row As Integer = MainObject.Visibility.GetRowFromCor(pt)
            left = MainObject.ClientLeft + (col * MainObject.ColumnHeader.Size)
            top = MainObject.ClientTop + ((row \ 2) * MainObject.RowHeader.Size)
            If (row Mod 2) = 1 Then top += (MainObject.RowHeader.Size \ 2)
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, MainObject.TextHeight(MainObject.Font))

          Case Schedule.ViewModeConstants.Week
            tmpDragRect = WeekModeHelper.GetCellRectFromOffset(MainObject, newStartDate)

          Case Schedule.ViewModeConstants.MonthFull
            Dim col As Integer = MainObject.Visibility.GetColumnFromCor(pt)
            Dim row As Integer = MainObject.Visibility.GetRowFromCor(pt)
            left = MainObject.ClientLeft + (col * MainObject.ColumnHeader.Size)
            top = MainObject.ClientTop + (row * MainObject.RowHeader.Size)
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, MainObject.TextHeight(MainObject.Font))

          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            left = MainObject.ClientLeft + CType((skew - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size, Integer)
            top = MainObject.ClientTop + ((newResource - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size)
            cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.ColumnHeader.Size)
            tmpDragRect = New Rectangle(left, top, cellBlockSize, MainObject.RowHeader.Size)

          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            'left = MainObject.ClientLeft + ((newResource - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            'Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
            'top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
            'cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            left = MainObject.ClientLeft + ((MainObject.ResourceCollection.IndexOfVisible(newResource) - MainObject.Visibility.FirstVisibleColumn) * MainObject.ColumnHeader.Size)
            If isEvent Then
              cellBlockSize = Gravitybox.Objects.EventHeader.TopBuffer
              top = MainObject.ClientTop - cellBlockSize
            Else
              Dim skew As Decimal = MainObject.Visibility.GetRowColFromTime(newStartTime, MainObject.TimeIncrement)
              top = MainObject.ClientTop + CType((skew - MainObject.Visibility.FirstVisibleRow) * MainObject.RowHeader.Size, Integer)
              cellBlockSize = GetIntlInteger((apptLength / MainObject.TimeIncrement) * MainObject.RowHeader.Size)
            End If
            tmpDragRect = New Rectangle(left, top, MainObject.ColumnHeader.Size, cellBlockSize)

          Case Else
            Call ErrorModule.ViewmodeErr()

        End Select

				If isEvent Then
					'If this is an event then draw only this rectange
					Dim g As Graphics = MainObject.CreateGraphics
					If DragRectArray.Count > 0 Then
						Call DrawOutline(g, CType(DragRectArray(0), Rectangle))
					End If
					Call DrawOutline(g, tmpDragRect)
					DragRectArray.Clear()
					DragRectArray.Add(tmpDragRect)
				Else
					'Create a temp appointment for the necessary rectangles
					Dim drawAppointment As New appointment(MainObject)
					drawAppointment.StartDate = newStartDate
					drawAppointment.StartTime = newStartTime
					If appointment.IsEvent OrElse appointment.IsActivity Then
						drawAppointment.Length = appointment.GetRealLength
					Else
						drawAppointment.Length = appointment.Length
					End If
					Dim visibleIndex As Integer
					If newRoom = -1 Then
						visibleIndex = newRoom
					Else
						visibleIndex = Me.MainObject.RoomCollection.IndexOfVisible(Me.MainObject.RoomCollection(newRoom))
					End If
					If (0 <= visibleIndex) AndAlso (visibleIndex < Me.MainObject.RoomCollection.VisibleCount) Then
						drawAppointment.Room = Me.MainObject.RoomCollection(newRoom)
					End If

					If newProvider = -1 Then
						visibleIndex = newProvider
					Else
						visibleIndex = Me.MainObject.ProviderCollection.IndexOfVisible(Me.MainObject.ProviderCollection(newProvider))
					End If
					If (0 <= visibleIndex) AndAlso (visibleIndex < Me.MainObject.ProviderCollection.VisibleCount) Then
						drawAppointment.ProviderList.Add(Me.MainObject.ProviderCollection(newProvider))
					End If

					If newResource = -1 Then
						visibleIndex = newResource
					Else
						visibleIndex = Me.MainObject.ResourceCollection.IndexOfVisible(Me.MainObject.ResourceCollection(newResource))
					End If
					If (0 <= visibleIndex) AndAlso (visibleIndex < Me.MainObject.ResourceCollection.VisibleCount) Then
						drawAppointment.ResourceList.Add(Me.MainObject.ResourceCollection(newResource))
					End If

					MainObject.Canvas.SetupAppointment(drawAppointment)
					drawAppointment.CalculateSortIndexes()
					Call DrawOutline(drawAppointment)

				End If

				Return True

			Catch ex As Exceptions.GravityboxException
				ErrorModule.SetErr(ex)
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "DrawOutline"

    Private Sub DrawOutline(ByVal g As Graphics, ByVal rect As Rectangle)
      Call MainObject.Canvas.DrawXORRectangle(g, rect, 3)
    End Sub

    Private Sub DrawOutline(ByVal rect As Rectangle)
      Dim g As Graphics = MainObject.CreateGraphics
      Call MainObject.Canvas.DrawXORRectangle(g, rect)
    End Sub

    Private Sub DrawOutline(ByVal appointment As Appointment)

      Try

        'Verify that we do need to redraw this
        'If this is the same rectangles that we have drawn then skip out
        If appointment.Rectangles.Count = DragRectArray.Count Then
          Dim hasChanged As Boolean = False
          For ii As Integer = 0 To appointment.Rectangles.Count - 1
            If Not appointment.Rectangles(ii).Rect.Equals(CType(DragRectArray(ii), Rectangle)) Then
              hasChanged = True
            End If
          Next
          If Not hasChanged Then
            Return
          End If
        End If

        Dim newDragRects As New ArrayList
        Dim index As Integer = 0
        For Each rectInfo As AppointmentRectangleInfo In appointment.Rectangles
          Dim drawRect As New Rectangle
          If DragRectArray.Count > index Then drawRect = CType(DragRectArray(index), Rectangle)
          'Draw the rectangle over the current image
          If Not drawRect.Equals(rectInfo.Rect) Then
            Dim g As Graphics = MainObject.CreateGraphics
            DrawOutline(g, drawRect)
            'Call MainObject.Canvas.DrawXORRectangle(g, drawRect, 3)
            newDragRects.Add(rectInfo.Rect)
            'Call MainObject.Canvas.DrawXORRectangle(g, rectInfo.Rect, 3)
            DrawOutline(g, rectInfo.Rect)
            g.Dispose()
          End If
          index += 1
        Next
        m_DragRectArray = newDragRects

      Catch ex As Exceptions.GravityboxException
        ErrorModule.SetErr(ex)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace