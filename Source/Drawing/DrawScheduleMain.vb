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

Imports Gravitybox.Controls
Imports Gravitybox.Objects
Imports Gravitybox.Objects.EventArgs
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Runtime.CompilerServices

Namespace Gravitybox.Drawing

	Friend Class DrawScheduleMain
		Implements IDisposable

#Region "Class Members"

		'Private Constants
		Private Const MidnightPlusOneDay As DateTime = #1/2/0001#	'#11:59:59 PM#

		'Private variables for this object
		Private MainObject As Schedule
		Private CacheObject As New DrawScheduleCache
		Private EventHeaderTop As Integer
		Private DateHash As New Hashtable
		Private m_AppointmentCollection As AppointmentCollection
		Private _syncRoot As Object = New DataSet()	'Just some object

#End Region

#Region "Property Implementations"

		Friend ReadOnly Property SyncRoot() As Object
			Get
				Return _syncRoot
			End Get
		End Property

#End Region

#Region "Constructor"

		Friend Sub New(ByVal mainSchedule As Schedule)
			MainObject = mainSchedule
			m_AppointmentCollection = mainSchedule.AppointmentCollection
		End Sub

#End Region

#Region "DrawXORRectangle"

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawXORRectangle(ByVal g As Graphics, ByVal rectArray As ArrayList)
			DrawXORRectangle(g, rectArray, 1)
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawXORRectangle(ByVal g As Graphics, ByVal rectArray As ArrayList, ByVal lineWidth As Integer)
			For Each rect As Rectangle In rectArray
				DrawXORRectangle(g, rect, lineWidth)
			Next
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawXORRectangle(ByVal g As Graphics, ByVal rect As Rectangle)
			DrawXORRectangle(g, rect, 1)
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawXORRectangle(ByVal g As Graphics, ByVal rect As Rectangle, ByVal lineWidth As Integer)

			Dim WinSupport As New Win32Support
			Dim hdc As System.IntPtr = g.GetHdc()
			Try

				If lineWidth < 1 Then lineWidth = 1

				'Lock Thread
				'Monitor.Enter(Me)
				'While Not Monitor.TryEnter(Me, 100)
				'End While

				'Interop and good old GDI
				Dim hpen As System.IntPtr = Win32Support.CreatePen(4, lineWidth, System.Drawing.ColorTranslator.ToWin32(Color.Green))
				Dim rop As Integer = Win32Support.SetROP2(hdc, 7)
				Dim oldpen As IntPtr = Win32Support.SelectObject(hdc, hpen)
				Call Win32Support.MoveToEx(hdc, rect.Left, rect.Top, 0)
				Call Win32Support.LineTo(hdc, rect.Right, rect.Top)
				Call Win32Support.LineTo(hdc, rect.Right, rect.Bottom)
				Call Win32Support.LineTo(hdc, rect.Left, rect.Bottom)
				Call Win32Support.LineTo(hdc, rect.Left, rect.Top)
				Win32Support.SelectObject(hdc, oldpen)
				Win32Support.SetROP2(hdc, rop)
				Call g.ReleaseHdc(hdc)
				Win32Support.DeleteObject(hpen)
				Win32Support.DeleteObject(oldpen)

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			Finally
				'UnLock Thread
				'Call Monitor.Exit(Me)
			End Try

		End Sub

#End Region

#Region "InternalRefresh"

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub InternalRefresh(ByVal g As Graphics)

			Dim eventCount As Integer = 0
			Dim origColumnSize As Integer = MainObject.ColumnHeader.Size
			Dim origRowSize As Integer = MainObject.RowHeader.Size

			'MainObject.Cursor = System.Windows.Forms.Cursors.WaitCursor

#If DEBUG Then
			'Dim startTime As Date = Now
			'Dim endTime As Date = Now
#End If

			Try
				'Lock Thread
				'Monitor.Enter(Me)
				'While Not Monitor.TryEnter(Me, 100)
				'End While

				DateHash = New Hashtable

				'Calculate the event header height
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						eventCount = Me.AppointmentCollection.GetTopBlockAppointments(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate)
						Me.AppointmentCollection.EventAppointmentCount = eventCount
						EventHeaderTop = MainObject.ClientTop - MainObject.EventHeaderHeight
					Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.Week, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.MonthFull, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.DayLeftResourceTop, Schedule.ViewModeConstants.DayLeftResourceTop
						Me.AppointmentCollection.EventAppointmentCount = 0
						EventHeaderTop = 0
					Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
						eventCount = Me.AppointmentCollection.GetTopBlockAppointments(Date.MinValue, Date.MaxValue)
						Me.AppointmentCollection.EventAppointmentCount = eventCount
						EventHeaderTop = MainObject.ClientTop - MainObject.EventHeaderHeight
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Me.AppointmentCollection.EventAppointmentCount = 0
						EventHeaderTop = 0
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

				Call CacheObject.Load(MainObject)

				'Clear the canvas
				Me.DrawBackground(g)

				If MainObject.DrawingDirty Then
					'Clear all appointment rectangle coordinates
					Call Me.AppointmentCollection.ClearRetangles()
				End If

				MainObject.EventHeader.ResetRectangle()
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayLeftTimeTop
						MainObject.NoDrawing = False
						Call DrawGrid(g)
						If MainObject.DrawingDirty Then
							Call SetupAppointmentsDayLeftTimeTop()
						End If
						Call DrawDayHeaderLeft(g)
						Call DrawTimeHeaderTop(g)

					Case Schedule.ViewModeConstants.DayRoomLeftTimeTop
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayRoomLeftTimeTop()
							End If
							Call DrawDayRoomHeaderLeft(g)
							Call DrawTimeHeaderTop(g)
						End If

					Case Schedule.ViewModeConstants.DayRoomTopTimeLeft
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayRoomTopTimeLeft()
							End If
							Call DrawDayRoomHeaderTop(g)
							Call DrawTimeHeaderLeft(g)
							Call DrawEventHeader(g)
						End If

					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayProviderTopTimeLeft()
							End If
							Call DrawDayProviderHeaderTop(g)
							Call DrawTimeHeaderLeft(g)
							Call DrawEventHeader(g)
						End If

					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayProviderLeftTimeTop()
							End If
							Call DrawDayProviderHeaderLeft(g)
							Call DrawTimeHeaderTop(g)
						End If

					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayProviderTopTimeLeft()
							End If
							Call DrawDayProviderHeaderTop(g)
							Call DrawTimeHeaderLeft(g)
							Call DrawEventHeader(g)
						End If

					Case Schedule.ViewModeConstants.DayTopTimeLeft
						MainObject.NoDrawing = False
						Call DrawGrid(g)
						If MainObject.DrawingDirty Then
							Call SetupAppointmentsDayTopTimeLeft()
						End If
						Call DrawDayHeaderTop(g)
						Call DrawTimeHeaderLeft(g)
						Call DrawEventHeader(g)

					Case Schedule.ViewModeConstants.RoomLeftTimeTop
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsRoomLeftTimeTop()
							End If
							Call DrawRoomHeaderRoomLeft(g)
							Call DrawTimeHeaderTop(g)
						End If

					Case Schedule.ViewModeConstants.RoomTopTimeLeft
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsRoomTopTimeLeft()
							End If
							Call DrawRoomHeaderRoomTop(g)
							Call DrawTimeHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.DayLeftRoomTop
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayLeftRoomTop()
							End If
							Call DrawRoomHeaderRoomTop(g)
							Call DrawDayHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.DayLeftResourceTop
						If MainObject.ResourceCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ResourceCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayLeftResourceTop()
							End If
							Call DrawResourceHeaderResourceTop(g)
							Call DrawDayHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.DayTopRoomLeft
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayTopRoomLeft()
							End If
							Call DrawRoomHeaderRoomLeft(g)
							Call DrawDayHeaderTop(g)
							Call DrawEventHeader(g)
						End If

					Case Schedule.ViewModeConstants.DayLeftProviderTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayLeftProviderTop()
							End If
							Call DrawProviderHeaderProviderTop(g)
							Call DrawDayHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.DayTopProviderLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsDayTopProviderLeft()
							End If
							Call DrawProviderHeaderProviderLeft(g)
							Call DrawDayHeaderTop(g)
							Call DrawEventHeader(g)
						End If

					Case Schedule.ViewModeConstants.RoomLeftProviderTop
						If (MainObject.RoomCollection.VisibleCount = 0) Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						ElseIf (MainObject.ProviderCollection.VisibleCount = 0) Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsRoomLeftProviderTop()
							End If
							Call DrawProviderHeaderProviderTop(g)
							Call DrawRoomHeaderRoomLeft(g)
						End If

					Case Schedule.ViewModeConstants.RoomTopProviderLeft
						If (MainObject.RoomCollection.VisibleCount = 0) Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						ElseIf (MainObject.ProviderCollection.VisibleCount = 0) Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsRoomTopProviderLeft()
							End If
							Call DrawProviderHeaderProviderLeft(g)
							Call DrawRoomHeaderRoomTop(g)
						End If

					Case Schedule.ViewModeConstants.ProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsProviderLeftTimeTop()
							End If
							Call DrawProviderHeaderProviderLeft(g)
							Call DrawTimeHeaderTop(g)
						End If

					Case Schedule.ViewModeConstants.ProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsProviderTopTimeLeft()
							End If
							Call DrawProviderHeaderProviderTop(g)
							Call DrawTimeHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.Month
						MainObject.NoDrawing = False
						Call DrawMonthGrid(g)
						If MainObject.DrawingDirty Then
							Call SetupAppointmentsMonth()
						End If
						Call DrawHeaderMonth(g)
						Call DrawDayHeaderMonth(g)

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ProviderCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsProviderTopDayTimeLeft()
							End If
							Call DrawProviderHeaderProviderTop(g)
							Call DrawDayTimeHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						If MainObject.RoomCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.RoomCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsRoomTopDayTimeLeft()
							End If
							Call DrawRoomHeaderRoomTop(g)
							Call DrawDayTimeHeaderLeft(g)
						End If

					Case Schedule.ViewModeConstants.Week
						MainObject.NoDrawing = False
						Call DrawWeekGrid(g)
						If MainObject.DrawingDirty Then
							Call SetupAppointmentsWeek()
						End If

					Case Schedule.ViewModeConstants.MonthFull
						MainObject.NoDrawing = False
						Call DrawMonthFullGrid(g)
						If MainObject.DrawingDirty Then
							Call SetupAppointmentsMonthFull()
						End If
						Call DrawHeaderMonthFull(g)
						Call DrawDayHeaderMonthFull(g)

					Case Schedule.ViewModeConstants.ResourceLeftTimeTop
						If MainObject.ResourceCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ResourceCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsResourceLeftTimeTop()
							End If
							Call DrawResourceHeaderResourceLeft(g)
							Call DrawTimeHeaderTop(g)
						End If

					Case Schedule.ViewModeConstants.ResourceTopTimeLeft
						If MainObject.ResourceCollection.VisibleCount = 0 Then
							MainObject.NoDrawing = True
							Call DrawNoDrawError(g, MainObject.ResourceCollection.ObjectSingular)
						Else
							MainObject.NoDrawing = False
							Call DrawGrid(g)
							If MainObject.DrawingDirty Then
								Call SetupAppointmentsResourceTopTimeLeft()
							End If
							Call DrawResourceHeaderResourceTop(g)
							Call DrawTimeHeaderLeft(g)
						End If

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select

				'Event header is only visible in certain viewmodes
				If MainObject.EventHeader.SupportedViewmode(MainObject.ViewMode) Then
					Call DrawEventHeader(g)
				End If

				'Check to determine if the number of events has changed and if so then repaint.
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If eventCount <> Me.AppointmentCollection.GetTopBlockAppointments(MainObject.Visibility.FirstVisibleDate, MainObject.Visibility.LastVisibleDate) Then
							Call InternalRefresh(g)
							Return
						End If
					Case Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayLeftResourceTop
						'Do Nothing
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Do Nothing
					Case Schedule.ViewModeConstants.Week
						'Do Nothing
					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

#If DEBUG Then
				'endTime = Date.Now
				'Debug.WriteLine("InternalRefresh - Prep: " & endTime.Subtract(startTime).TotalMilliseconds)
				'startTime = Date.Now
#End If

				'Calculate the sort indexes if need be
				Dim appointment As Appointment
				If MainObject.DrawingDirty AndAlso Not MainObject.NoDrawing Then
					'Calculate the sort index used in conflict resolution
					For Each appointment In Me.AppointmentCollection
						Call appointment.CalculateSortIndexes()
					Next
					'Calculate the conflicts
					Call Me.AppointmentCollection.CalculateConflicts()
				End If

#If DEBUG Then
				'endTime = Date.Now
				'Debug.WriteLine("CalculateConflicts: " & endTime.Subtract(startTime).TotalMilliseconds)
				'startTime = Date.Now
#End If

				'Draw the non-selected appointments
				For Each appointment In Me.AppointmentCollection
					If Not appointment.MainObject Is Nothing Then
						If Not MainObject.SelectedItems.Contains(appointment) Then
							appointment.Draw(g, MainObject)
						End If
					End If
				Next
				'Draw the selected appointments
				For Each appointment In MainObject.SelectedItems
					If Not appointment.MainObject Is Nothing Then
						appointment.Draw(g, MainObject)
					End If
				Next

#If DEBUG Then
				'endTime = Date.Now
				'Debug.WriteLine("Draw: " & endTime.Subtract(startTime).TotalMilliseconds)
				'startTime = Date.Now
#End If

				'Fill the margin at the top, left corner
				Dim RectF As RectangleF
				If Not MainObject.NoDrawing Then
					RectF = New RectangleF(0, 0, CacheObject.ClientLeft, CacheObject.ClientTop)
					Call g.FillRectangle(New SolidBrush(Me.MainObject.RowHeader.Appearance.BackColor), RectF)
				End If

				'Event header is only visible in certain viewmodes
				If MainObject.EventHeader.SupportedViewmode(MainObject.ViewMode) Then
					DrawEventCollapser(g)
				End If

				'If not printing...
				If Not MainObject.Visibility.IsPrinting And Not MainObject.NoDrawing Then
					'Only fill if there is a space in the 2 Scrollbars
					Select Case MainObject.ScrollBars
						Case ScrollBars.Both
							'Fill the margin at the bottom/right corner
							RectF = New RectangleF(MainObject.Width - MainObject.VScroll1.Width, MainObject.Height - MainObject.HScroll1.Height, MainObject.VScroll1.Width, MainObject.HScroll1.Height)
							Call g.FillRectangle(New SolidBrush(MainObject.BackColor), RectF)
					End Select
				End If

				'If the column/row size changed in here then draw again. (For resizing/Month mode only)
				If MainObject.ViewMode = Schedule.ViewModeConstants.Month Then
					If (origColumnSize <> MainObject.ColumnHeader.Size) OrElse (origRowSize <> MainObject.RowHeader.Size) Then
						Call InternalRefresh(g)
					End If
				End If

				MainObject.DrawingDirty = False

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			Finally
				'UnLock Thread
				'Call Monitor.Exit(Me)
				'MainObject.Cursor = System.Windows.Forms.Cursors.Default
			End Try

		End Sub

#End Region

#Region "DrawBackground"

		Private Sub DrawBackground(ByVal g As Graphics)
			Call g.Clear(MainObject.BackColor)
			Dim bodyRectangle As Rectangle
			Select Case MainObject.ViewMode
				Case Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.MonthFull
					bodyRectangle = New Rectangle(0, 0, MainObject.Width, MainObject.Height)
				Case Else
					bodyRectangle = New Rectangle(0, 0, MainObject.ClientWidth, MainObject.ClientHeight)
			End Select
			Dim fillBrush As Brush = CreateBrush(MainObject.Appearance, bodyRectangle)
			g.FillRectangle(fillBrush, bodyRectangle)
			fillBrush.Dispose()
		End Sub

#End Region

#Region "DrawNoDrawError"

		Private Sub DrawNoDrawError(ByVal g As Graphics, ByVal objectName As String)

			Try

				Dim rect As New Rectangle(0, 0, MainObject.Width - 1, MainObject.Height - 1)
				Call g.FillRectangle(New SolidBrush(Color.White), rect)
				Call g.DrawRectangle(New Pen(Color.Black), rect)

				'Draw the date string
				Dim stringFormat As New System.Drawing.StringFormat
				stringFormat.Alignment = StringAlignment.Center
				stringFormat.LineAlignment = StringAlignment.Center
				Dim DrawRectF As RectangleF = New System.Drawing.RectangleF(rect.Left, rect.Top + ScheduleGlobals.TextMargin, rect.Width, rect.Height)
				Call g.DrawString("The schedule may not be displayed because of missing " & objectName & " information!", MainObject.Font, New SolidBrush(Color.Black), DrawRectF, stringFormat)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawEventHeader"

		Private Sub DrawEventHeader(ByVal g As Graphics)

			'If no event header then nothing to draw
			If Not MainObject.EventHeader.AllowHeader Then Return
			If Not MainObject.EventHeader.IsExpanded Then Return
			If MainObject.NoDrawing Then Return

			Try
				MainObject.EventHeader.Rectangle = New Rectangle(MainObject.ClientLeft, MainObject.ClientTop - MainObject.EventHeaderHeight, MainObject.ClientWidth, MainObject.EventHeaderHeight)
				Dim fillBrush As Brush = CreateBrush(MainObject.EventHeader.Appearance, MainObject.EventHeader.Rectangle)
				g.FillRectangle(fillBrush, MainObject.EventHeader.Rectangle)
				Call fillBrush.Dispose()

				Dim borderPen As Pen = CreateBorderPen(MainObject.EventHeader.Appearance)
				g.DrawRectangle(borderPen, MainObject.EventHeader.Rectangle)
				borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawEventCollapse"

		Private Sub DrawEventCollapser(ByVal g As Graphics)

			'If nothing to draw then return
			If Not Me.MainObject.EventHeader.AllowHeader Then Return
			If Not Me.MainObject.EventHeader.AllowExpand Then Return
			If MainObject.NoDrawing Then Return

			Try
				Const width As Integer = 11
				Const height As Integer = 9
				MainObject.EventHeader.ExpanderRectangle = New Rectangle(MainObject.ClientLeft - width + 1, MainObject.ClientTop - height + 1, width, height)
				If Me.MainObject.EventHeader.IsExpanded Then
					Call g.DrawImageUnscaled(New Bitmap(GetProjectFileAsStream("minus.bmp")), MainObject.EventHeader.ExpanderRectangle)
				Else
					Call g.DrawImageUnscaled(New Bitmap(GetProjectFileAsStream("plus.bmp")), MainObject.EventHeader.ExpanderRectangle)
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawWeekGrid"

		Private Sub DrawWeekGrid(ByVal g As Graphics)

			Const columnCount As Integer = 2
			Dim columnWidth As Integer = (MainObject.ClientWidth - 1) \ columnCount
			Dim rowHeight As Integer = (MainObject.ClientHeight - 1) \ 3
			Dim halfHeight As Integer = rowHeight \ 2
			Dim startDate As Date = MainObject.MinDate

			Try

				'Cache the values for later use when drawing the drag outline
				Call MainObject.ColumnHeader.SetSize(columnWidth)
				Call MainObject.RowHeader.SetSize(rowHeight)

				Dim gridRect As RectangleF = New RectangleF(CacheObject.ClientLeft + 1, CacheObject.ClientTop + 1, CacheObject.ClientWidth, CacheObject.ClientHeight)
				Dim gridbrush As Brush = CreateBrush(MainObject.Appearance, gridRect)

				'Fill the grid backcolor
				Call g.FillRectangle(gridbrush, gridRect)
				Call gridbrush.Dispose()

				'Fill the ColoredAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.ColoredAreaCollection)

				'Fill the NoDropAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.NoDropAreaCollection)

				'Loop and draw the cells for each day
				MainObject.WeekClientRectangles.Clear()
				For ii As Integer = 0 To DaysPerWeek - 2
					Dim skewX As Integer = (ii \ 3) * columnWidth
					Dim skewY As Integer = (ii Mod 3) * rowHeight
					Dim rect As Rectangle
					If (ii = 5) Then
						'Day before last (Saturday)
						rect = New Rectangle(CacheObject.ClientLeft + skewX, CacheObject.ClientTop + skewY, columnWidth, halfHeight)
						Dim dayClientRect As Rectangle = DrawWeekGridDay(g, startDate.AddDays(ii), rect)
						MainObject.WeekClientRectangles.Add(dayClientRect)
						'Last day of week (Sunday)
						rect = New Rectangle(CacheObject.ClientLeft + skewX, CacheObject.ClientTop + skewY + halfHeight, columnWidth, rowHeight - halfHeight)
						dayClientRect = DrawWeekGridDay(g, startDate.AddDays(ii + 1), rect)
						MainObject.WeekClientRectangles.Add(dayClientRect)
					Else
						rect = New Rectangle(CacheObject.ClientLeft + skewX, CacheObject.ClientTop + skewY, columnWidth, rowHeight)
						Dim dayClientRect As Rectangle = DrawWeekGridDay(g, startDate.AddDays(ii), rect)
						MainObject.WeekClientRectangles.Add(dayClientRect)
					End If
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Function DrawWeekGridDay(ByVal g As Graphics, ByVal drawDate As Date, ByVal rect As Rectangle) As Rectangle

			'Draw the cell border
			Dim gridPen As Pen = CreateBorderPen(MainObject.Appearance)
			g.DrawRectangle(gridPen, rect)

			'Format the string
			Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
			Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

			'Calculate the header rectangle
			Dim headerRect As Rectangle = New Rectangle(rect.Left, rect.Top, rect.Width, MainObject.TextHeight(theFont) + (TextMargin * 2))
			Dim headerRectF As RectangleF = New System.Drawing.RectangleF(headerRect.Left + ScheduleGlobals.TextMargin, headerRect.Top + ScheduleGlobals.TextMargin, headerRect.Width - ScheduleGlobals.TextMargin, headerRect.Height - ScheduleGlobals.TextMargin)

			'Create the broder pen
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)

			'Draw the header border
			Dim backbrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, headerRect)
			Call g.FillRectangle(backbrush, headerRect)
			Call backbrush.Dispose()
			If borderPen.Width > 0 Then
				Call g.DrawRectangle(borderPen, headerRect)
			End If

			'Draw the date text
			Dim textPen As Pen = CreateTextPen(MainObject.ColumnHeader.Appearance)
			Dim cellText As String = drawDate.ToString(MainObject.HeaderDateFormat)
			Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
			Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)
			Call g.DrawString(eventParam.Text, theFont, textPen.Brush, headerRectF, stringFormat)

			'Return the client area of the cell where appointments are displayed
			Return New Rectangle(rect.Left, rect.Top + headerRect.Height, rect.Width, rect.Height - headerRect.Height)

		End Function

#End Region

#Region "DrawGrid"

		'This method draws the grid for all viewmodes
		Private Sub DrawGrid(ByVal g As Graphics)

			Dim Point1 As Point
			Dim Point2 As Point

			Try

				Dim gridRect As RectangleF = New RectangleF(CacheObject.ClientLeft + 1, CacheObject.ClientTop + 1, CacheObject.ClientWidth, CacheObject.ClientHeight)
				Dim gridbrush As Brush = CreateBrush(MainObject.Appearance, gridRect)

				'Fill the grid backcolor
				Call g.FillRectangle(gridbrush, gridRect)
				Call gridbrush.Dispose()

				'Fill the ColoredAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.ColoredAreaCollection)

				'Fill the NoDropAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.NoDropAreaCollection)

				'Calculate the number of day boundries crossed by the selector
				Dim dayBreaks As Integer = ((MainObject.StartTime.Hour * MinutesPerHour) + (MainObject.Selector.Length * MainObject.TimeIncrementValue)) \ MinutesPerDay
				Dim selectorEndTime As Date = MainObject.StartTime.AddMinutes((MainObject.Selector.Length * MainObject.TimeIncrementValue))
				Dim firstDaySelectTime As Date = PivotTime

				For jj As Integer = 0 To dayBreaks

					'Fill the grid selector (if necessary)
					If MainObject.AllowSelector AndAlso (MainObject.SelectedItem Is Nothing) Then
						Dim width As Integer
						Dim height As Integer
						If jj = 0 Then
							'If this is the first day highlighted by the selector
							Select Case MainObject.ViewMode
								Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
									width = CacheObject.ColumnWidth
									height = CacheObject.RowHeight * MainObject.Selector.Length
									Dim index As Integer = MainObject.Selector.Row
									If index >= 0 Then
										firstDaySelectTime = MainObject.StartTime.AddMinutes(index * MainObject.TimeIncrementValue)
									End If
								Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
									width = CacheObject.ColumnWidth * MainObject.Selector.Length
									height = CacheObject.RowHeight
									Dim index As Integer = MainObject.Selector.Column
									If index >= 0 Then
										firstDaySelectTime = MainObject.StartTime.AddMinutes(index * MainObject.TimeIncrementValue)
									End If
								Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.DayLeftResourceTop
									width = CacheObject.ColumnWidth
									height = CacheObject.RowHeight
								Case Schedule.ViewModeConstants.Month
									'Do Nothing
								Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
									width = CacheObject.ColumnWidth
									height = CacheObject.RowHeight * MainObject.Selector.Length
									Dim index As Integer = MainObject.Selector.Row Mod (MainObject.TimeIncrementsPerHour * HourPerDay)
									If index >= 0 Then
										firstDaySelectTime = MainObject.StartTime.AddMinutes(index * MainObject.TimeIncrementValue)
									End If
								Case Schedule.ViewModeConstants.Week
									'Do Nothing
								Case Schedule.ViewModeConstants.MonthFull
									'Do Nothing
								Case Else
									Call ErrorModule.ViewmodeErr()
							End Select

						ElseIf (jj >= 1) AndAlso (jj < dayBreaks) Then
							'If this is NOT the first or last day highlighted by a multi-day selector (IS a middle day)
							'TODO - Multiday Select

						ElseIf (jj = dayBreaks) Then
							'If this is the last day highlighted by a multi-day selector
							height = 0

							'TODO - Multiday Select

						End If

						'Only draw the selector if necessary
						If (height > 0) Then
							Dim selectorRect As Rectangle = New Rectangle(CacheObject.ClientLeft + ((MainObject.Selector.Column - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), _
							 CacheObject.ClientTop + ((MainObject.Selector.Row - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), width, height)
							Dim selectorBrush As Brush = CreateBrush(MainObject.Selector.Appearance, selectorRect)
							Call g.FillRectangle(selectorBrush, selectorRect)
							Call selectorBrush.Dispose()
						End If

					End If

				Next				'Loop through number day creaks crossed by Selector

				If MainObject.AllowGrid Then

					If Me.MainObject.Visibility.IsTimeOnTop Then
						'Create the draw pen
						Dim gridPen As Pen = New Pen(MainObject.Appearance.ItemLineColor, MainObject.Appearance.ItemLineWidth)
						Dim majorPen As Pen = New Pen(MainObject.Appearance.MajorLineColor, MainObject.Appearance.MajorLineWidth)
						Dim minorPen As Pen = New Pen(MainObject.Appearance.MinorLineColor, MainObject.Appearance.MinorLineWidth)

						'Draw the vertical lines
						Dim skewLineCount As Integer = (CacheObject.FirstVisibleColumn Mod CacheObject.TimeIncrementsPerHour)
						For ii As Integer = 1 To CacheObject.TotalVisibleColumns
							Point1 = New Point(CacheObject.ClientLeft + (ii * CacheObject.ColumnWidth), CacheObject.ClientTop)
							Point2 = New Point(Point1.X, Point1.Y + CacheObject.ClientHeight)
							If ((ii + skewLineCount) Mod CacheObject.TimeIncrementsPerHour) = 0 Then
								Call g.DrawLine(majorPen, Point1, Point2)
							Else
								Call g.DrawLine(minorPen, Point1, Point2)
							End If
						Next ii

						'Draw the horizontal lines
						For ii As Integer = 0 To CacheObject.TotalVisibleRows
							Point1 = New Point(CacheObject.ClientLeft, CacheObject.ClientTop + (ii * CacheObject.RowHeight))
							Point2 = New Point(Point1.X + CacheObject.ClientWidth, Point1.Y)
							Call g.DrawLine(gridPen, Point1, Point2)
						Next ii

						'Dispose of drawing objects
						Call gridPen.Dispose()

					ElseIf Me.MainObject.Visibility.IsTimeOnLeft Then
						'Create the draw pen
						Dim gridPen As Pen = New Pen(MainObject.Appearance.ItemLineColor, MainObject.Appearance.ItemLineWidth)
						Dim majorPen As Pen = New Pen(MainObject.Appearance.MajorLineColor, MainObject.Appearance.MajorLineWidth)
						Dim minorPen As Pen = New Pen(MainObject.Appearance.MinorLineColor, MainObject.Appearance.MinorLineWidth)

						'Draw the horizontal lines
						Dim skewLineCount As Integer = (CacheObject.FirstVisibleRow Mod CacheObject.TimeIncrementsPerHour)
						For ii As Integer = 0 To CacheObject.TotalVisibleRows
							Point1 = New Point(CacheObject.ClientLeft, CacheObject.ClientTop + (ii * CacheObject.RowHeight))
							Point2 = New Point(Point1.X + CacheObject.ClientWidth, Point1.Y)
							If ((ii + skewLineCount) Mod CacheObject.TimeIncrementsPerHour) = 0 Then
								Call g.DrawLine(majorPen, Point1, Point2)
							Else
								Call g.DrawLine(minorPen, Point1, Point2)
							End If
						Next ii

						'Draw the vertical lines
						For ii As Integer = 1 To CacheObject.TotalVisibleColumns
							Point1 = New Point(CacheObject.ClientLeft + (ii * CacheObject.ColumnWidth), CacheObject.ClientTop)
							Point2 = New Point(Point1.X, Point1.Y + CacheObject.ClientHeight)
							Call g.DrawLine(gridPen, Point1, Point2)
						Next ii

						'Dispose of drawing objects
						Call gridPen.Dispose()

					Else
						'Create the draw pen
						Dim gridPen As Pen = New Pen(MainObject.Appearance.ItemLineColor, MainObject.Appearance.ItemLineWidth)

						'Draw the vertical lines
						For ii As Integer = 1 To CacheObject.TotalVisibleColumns
							Point1 = New Point(CacheObject.ClientLeft + (ii * CacheObject.ColumnWidth), CacheObject.ClientTop)
							Point2 = New Point(Point1.X, Point1.Y + CacheObject.ClientHeight)
							Call g.DrawLine(gridPen, Point1, Point2)
						Next ii

						'Draw the horizontal lines
						For ii As Integer = 1 To CacheObject.TotalVisibleRows
							Point1 = New Point(CacheObject.ClientLeft, CacheObject.ClientTop + (ii * CacheObject.RowHeight))
							Point2 = New Point(Point1.X + CacheObject.ClientWidth, Point1.Y)
							Call g.DrawLine(gridPen, Point1, Point2)
						Next ii

						'Dispose of drawing objects
						Call gridPen.Dispose()

					End If

				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawMonthGrid(ByVal g As Graphics)

			Try

				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ (MainObject.Visibility.TotalRowCount \ 2))
				Dim left As Integer
				Dim top As Integer

				'If there is nothing to draw so skip out
				If columnWidth <= 0 Then Return
				If rowHeight <= 0 Then Return

				'Cache the values for later use when drawing the drag outline
				Call MainObject.ColumnHeader.SetSize(columnWidth)
				Call MainObject.RowHeader.SetSize(rowHeight)

				'Fill background
				left = CacheObject.ClientLeft
				top = CacheObject.ClientTop
				Dim gridRect As RectangleF = New RectangleF(left, top, (MainObject.Visibility.TotalColumnCount * columnWidth), ((MainObject.Visibility.TotalRowCount \ 2) * rowHeight))
				Dim gridBrush As Brush = CreateBrush(MainObject.Appearance, gridRect)
				Call g.FillRectangle(gridBrush, gridRect)
				Call gridBrush.Dispose()

				'Fill the ColoredAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.ColoredAreaCollection)

				'Fill the NoDropAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.NoDropAreaCollection)

				If MainObject.AllowGrid Then

					Dim gridPen As New Pen(MainObject.ColumnHeader.Appearance.BorderColor)

					'Draw the vertical grid lines 
					left = CacheObject.ClientLeft
					top = CacheObject.ClientTop
					For ii As Integer = 1 To MainObject.Visibility.TotalColumnCount + 1
						Call g.DrawLine(gridPen, left, top, left, top + ((MainObject.Visibility.TotalRowCount \ 2) * rowHeight))
						left += columnWidth
					Next

					'Draw the horizontal grid lines 
					left = CacheObject.ClientLeft
					top = CacheObject.ClientTop
					For ii As Integer = 1 To (MainObject.Visibility.TotalRowCount \ 2) + 1
						Call g.DrawLine(gridPen, left, top, left + (MainObject.Visibility.TotalColumnCount * columnWidth), top)
						top += rowHeight
					Next

					'Draw the half lines for weekends
					left = CacheObject.ClientLeft + (columnWidth * (MainObject.Visibility.TotalColumnCount - 1))
					top = CacheObject.ClientTop + (rowHeight \ 2)
					For ii As Integer = 1 To (MainObject.Visibility.TotalRowCount \ 2)
						Call g.DrawLine(gridPen, left, top, left + columnWidth, top)
						top += rowHeight
					Next

					'Dispose of drawing objects
					Call gridPen.Dispose()

				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawMonthFullGrid(ByVal g As Graphics)

			Try

				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ MainObject.Visibility.TotalRowCount)
				Dim left As Integer
				Dim top As Integer

				'If there is nothing to draw so skip out
				If columnWidth <= 0 Then Return
				If rowHeight <= 0 Then Return

				'Cache the values for later use when drawing the drag outline
				Call MainObject.ColumnHeader.SetSize(columnWidth)
				Call MainObject.RowHeader.SetSize(rowHeight)

				'Fill background
				left = CacheObject.ClientLeft
				top = CacheObject.ClientTop
				Dim gridRect As RectangleF = New RectangleF(left, top, (MainObject.Visibility.TotalColumnCount * columnWidth), (MainObject.Visibility.TotalRowCount * rowHeight))
				Dim gridBrush As Brush = CreateBrush(MainObject.Appearance, gridRect)
				Call g.FillRectangle(gridBrush, gridRect)
				Call gridBrush.Dispose()

				'Fill the ColoredAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.ColoredAreaCollection)

				'Fill the NoDropAreaCollection
				Call DrawColoredAreaCollection(g, MainObject.NoDropAreaCollection)

				If MainObject.AllowGrid Then

					Dim gridPen As New Pen(MainObject.ColumnHeader.Appearance.BorderColor)

					'Draw the vertical grid lines 
					left = CacheObject.ClientLeft
					top = CacheObject.ClientTop
					For ii As Integer = 1 To MainObject.Visibility.TotalColumnCount + 1
						Call g.DrawLine(gridPen, left, top, left, top + (MainObject.Visibility.TotalRowCount * rowHeight))
						left += columnWidth
					Next

					'Draw the horizontal grid lines 
					left = CacheObject.ClientLeft
					top = CacheObject.ClientTop
					For ii As Integer = 1 To MainObject.Visibility.TotalRowCount + 1
						Call g.DrawLine(gridPen, left, top, left + (MainObject.Visibility.TotalColumnCount * columnWidth), top)
						top += rowHeight
					Next

					'Dispose of drawing objects
					Call gridPen.Dispose()

				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawColoredAreaCollection"

		Private Function GetGridRectangle() As System.Drawing.Rectangle
			Return New Rectangle(CacheObject.ClientLeft, CacheObject.ClientTop, CacheObject.ClientWidth, CacheObject.ClientHeight)
		End Function

		'The draw area methods define a rectangle AndAlso use all constrining data to limit 
		'the size of the rectangle. This allows for the date/time/room/provider data to 
		'be used to define a region of the screen to be a specified color. Each routine 
		'shrinks the rectange until it is the proper size for the specified data.

		Private Sub DrawColoredAreaCollection(ByVal g As Graphics, ByVal areaList As ScheduleAreaCollection)

			Dim area As ScheduleArea
			Dim dayRect As Rectangle
			Dim timeRect() As Rectangle
			Dim roomRect() As Rectangle
			Dim providerRect() As Rectangle
			Dim resourceRect As Rectangle
			Dim masterRect As Rectangle
			Dim mustLoop As Boolean = False
			Dim loopRectangles() As Rectangle

			Try
				For Each area In areaList

					'Create a new rectangle
					masterRect = New Rectangle
					dayRect = New Rectangle
					'timeRect = New Rectangle
					'roomRect = New Rectangle
					'providerRect = New Rectangle
					resourceRect = New Rectangle

					Select Case MainObject.ViewMode
						Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayLeftTimeTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(timeRect(0))
							End If

						Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayLeftRoomTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Room Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = roomRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayRoom Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = dayRect
								masterRect.Intersect(roomRect(0))
							End If

						Case Schedule.ViewModeConstants.DayLeftResourceTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Resource Then
								Call DrawColoredAreaResource(g, area, resourceRect)
								masterRect = resourceRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayResource Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaResource(g, area, resourceRect)
								masterRect = dayRect
								masterRect.Intersect(resourceRect)
							End If

						Case Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftProviderTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = providerRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayProvider Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = dayRect
								masterRect.Intersect(providerRect(0))
							End If

						Case Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Room Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = GetGridRectangle()
								loopRectangles = roomRect
								mustLoop = True				 'room viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayRoom Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = dayRect
								masterRect.Intersect(roomRect(0))
								'mustLoop = True 'room viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomTime Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
								loopRectangles = roomRect
								mustLoop = True				 'room viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayRoomTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(timeRect(0))
								loopRectangles = roomRect
								mustLoop = True				 'room viewed multiple times - must loop
							End If

						Case Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayProviderLeftTimeTop
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = GetGridRectangle()
								loopRectangles = providerRect
								mustLoop = True				 'Provider viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayProvider Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = dayRect
								masterRect.Intersect(providerRect(0))
								'mustLoop = True 'Provider viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
								loopRectangles = providerRect
								mustLoop = True				 'Provider viewed multiple times - must loop
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayProviderTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(timeRect(0))
								loopRectangles = providerRect
								mustLoop = True				 'room viewed multiple times - must loop
							End If

						Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop
							If area.AreaType = ScheduleAreaTypeConstants.Room Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = roomRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomTime Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = roomRect(0)
								masterRect.Intersect(timeRect(0))
							End If

						Case Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop
							If area.AreaType = ScheduleAreaTypeConstants.Room Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = roomRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = providerRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomProvider Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = roomRect(0)
								masterRect.Intersect(providerRect(0))
							End If

						Case Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft
							If area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = providerRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = providerRect(0)
								masterRect.Intersect(timeRect(0))
							End If

						Case Schedule.ViewModeConstants.Month
							Call DrawColoredAreaDay(g, area, dayRect)
							masterRect = dayRect

						Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
							If area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = providerRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = GetGridRectangle()
								loopRectangles = timeRect
								mustLoop = True
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ProviderTime Then
								Call DrawColoredAreaProvider(g, area, providerRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = providerRect(0)
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ProviderDay Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								masterRect = dayRect
								masterRect.Intersect(providerRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ProviderDayTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaProvider(g, area, providerRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(providerRect(0))
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayTime Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							End If

						Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
							If area.AreaType = ScheduleAreaTypeConstants.Provider Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = roomRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = GetGridRectangle()
								loopRectangles = timeRect
								mustLoop = True
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomTime Then
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = roomRect(0)
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomDay Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaRoom(g, area, roomRect)
								masterRect = dayRect
								masterRect.Intersect(roomRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.RoomDayTime Then
								Call DrawColoredAreaDay(g, area, dayRect)
								Call DrawColoredAreaRoom(g, area, roomRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = dayRect
								masterRect.Intersect(roomRect(0))
								masterRect.Intersect(timeRect(0))
							ElseIf area.AreaType = ScheduleAreaTypeConstants.DayTime Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							End If

						Case Schedule.ViewModeConstants.Week
							If area.AreaType = ScheduleAreaTypeConstants.Day Then
								Call DrawColoredAreaDay(g, area, dayRect)
								masterRect = dayRect
							End If

						Case Schedule.ViewModeConstants.MonthFull
							Call DrawColoredAreaDay(g, area, dayRect)
							masterRect = dayRect

						Case Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft
							If area.AreaType = ScheduleAreaTypeConstants.Resource Then
								Call DrawColoredAreaResource(g, area, resourceRect)
								masterRect = resourceRect
							ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = timeRect(0)
							ElseIf area.AreaType = ScheduleAreaTypeConstants.ResourceTime Then
								Call DrawColoredAreaResource(g, area, resourceRect)
								Call DrawColoredAreaTime(g, area, timeRect)
								masterRect = resourceRect
								masterRect.Intersect(timeRect(0))
							End If

						Case Else
							Call ErrorModule.ViewmodeErr()
					End Select

					'If this viewmode has rooms viewed multiple times then loop
					If mustLoop Then
						For Each loopRect As Rectangle In loopRectangles
							Dim tempRect As Rectangle = masterRect
							tempRect.Intersect(loopRect)
							DrawColoredAreaCollectionSub(g, areaList, area, tempRect)
						Next
					ElseIf (masterRect.Width > 0) AndAlso (masterRect.Height > 0) Then
						DrawColoredAreaCollectionSub(g, areaList, area, masterRect)
					End If

				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaCollectionSub(ByVal g As Graphics, ByVal areas As ScheduleAreaCollection, ByVal area As ScheduleArea, ByVal masterRect As Rectangle)

			Try

				'Now draw the intersection of the calculated rectangles
				Dim borderRect As Rectangle = New System.Drawing.Rectangle(masterRect.Left + 1, masterRect.Top + 1, masterRect.Width - 1, masterRect.Height - 1)
				Dim areaBrush As Brush = CreateBrush(area.Appearance, borderRect)
				Call g.FillRectangle(areaBrush, borderRect)
				Call areaBrush.Dispose()

				If area.Appearance.BorderWidth > 0 Then
					Dim borderPen As Pen = CreateBorderPen(area.Appearance)
					borderPen.Alignment = Drawing2D.PenAlignment.Inset
					Call g.DrawRectangle(borderPen, borderRect)
					Call borderPen.Dispose()
				End If

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(area.Appearance)
				Dim theFont As Font = CreateFont(area.Appearance, MainObject.Font.FontFamily)

				'Draw the text if need be
				If area.Text <> "" Then
					Dim fontBrush As Brush = New SolidBrush(area.Appearance.ForeColor)
					Dim masterRectF As RectangleF = New System.Drawing.RectangleF(masterRect.Left + area.Appearance.BorderWidth, masterRect.Top + area.Appearance.BorderWidth, masterRect.Width - (area.Appearance.BorderWidth * 2), masterRect.Height - (area.Appearance.BorderWidth - 2))
					Call g.DrawString(area.Text, theFont, fontBrush, masterRectF, stringFormat)
					fontBrush.Dispose()
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaDay(ByVal g As Graphics, ByVal area As ScheduleArea, ByRef myRectangle As Rectangle)

			Dim left As Integer = CacheObject.ClientLeft
			Dim top As Integer = CacheObject.ClientTop
			Dim width As Integer
			Dim height As Integer

			Try

				'If the date is out of range then do not process
				'The month mode is special!
				If MainObject.ViewMode <> Schedule.ViewModeConstants.Month Then
					If area.StartDate < MainObject.MinDate Then Return
					If area.StartDate > MainObject.MaxDate Then Return
				End If

				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth
						height = CacheObject.ClientHeight
					Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.DayLeftResourceTop
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight
					Case Schedule.ViewModeConstants.DayRoomTopTimeLeft
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth * MainObject.RoomCollection.VisibleCount
						height = CacheObject.ClientHeight
					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth * MainObject.ProviderCollection.VisibleCount
						height = CacheObject.ClientHeight
					Case Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight * MainObject.RoomCollection.VisibleCount
					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight * MainObject.ProviderCollection.VisibleCount
					Case Schedule.ViewModeConstants.Month
						Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
						Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ (MainObject.Visibility.TotalRowCount \ 2))
						Dim firstDate As DateTime = MainObject.MinDate
						'Dim firstDate As DateTime = DateAdd(DateInterval.Day, -MainObject.MonthSelDate.DayOfWeek + 1, MainObject.MonthSelDate)
						Dim cellIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, firstDate, area.StartDate)) + 1
						Dim maxIndex As Integer = (MainObject.Visibility.TotalRowCount \ 2) * DaysPerWeek

						'If the date is out of range then there is nothing to do
						If (cellIndex < 1) OrElse (cellIndex > maxIndex) Then Return

						If (cellIndex Mod DaysPerWeek) = 0 Then
							'This is Sunday
							left += (DaysPerWeek - 2) * columnWidth
							top += (((cellIndex - 1) \ DaysPerWeek) * rowHeight) + (rowHeight \ 2)
							width = columnWidth
							height = rowHeight \ 2
						ElseIf (cellIndex Mod DaysPerWeek) = 6 Then
							'This is Saturday
							left += ((cellIndex - 1) Mod DaysPerWeek) * columnWidth
							top += ((cellIndex - 1) \ DaysPerWeek) * rowHeight
							width = columnWidth
							height = rowHeight \ 2
						Else
							'Any weekday
							left += ((cellIndex - 1) Mod DaysPerWeek) * columnWidth
							top += ((cellIndex - 1) \ DaysPerWeek) * rowHeight
							width = columnWidth
							height = rowHeight
						End If
					Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft
						'Do Nothing
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight * ((HourPerDay * MinutesPerHour) \ MainObject.TimeIncrementValue)
					Case Schedule.ViewModeConstants.Week
						Dim rect As Rectangle = WeekModeHelper.GetCellRectFromOffset(MainObject, area.StartDate)
						left = rect.Left
						top = rect.Top
						width = rect.Width
						height = rect.Height
					Case Schedule.ViewModeConstants.MonthFull
						Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
						Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ MainObject.Visibility.TotalRowCount)
						Dim firstDate As DateTime = MainObject.MonthViewFirstDate
						Dim cellIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, firstDate, area.StartDate)) + 1

						'If the date is out of range then there is nothing to do
						If (cellIndex < 1) OrElse (cellIndex > (MainObject.Visibility.TotalRowCount * DaysPerWeek) - 1) Then Return

						left += ((cellIndex - 1) Mod DaysPerWeek) * columnWidth
						top += ((cellIndex - 1) \ DaysPerWeek) * rowHeight
						width = columnWidth
						height = rowHeight

					Case Else
						Call ErrorModule.ViewmodeErr()
						Return

				End Select

				myRectangle = New Rectangle(left, top, width, height)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaTime(ByVal g As Graphics, ByVal area As ScheduleArea, ByRef myRectangle() As Rectangle)

			Dim left As Integer = CacheObject.ClientLeft
			Dim top As Integer = CacheObject.ClientTop
			Dim width As Integer
			Dim height As Integer

			Try

				'Default to something
				Dim defaultRects(1) As Rectangle
				defaultRects(0) = New Rectangle(left, top, width, height)
				myRectangle = defaultRects

				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromTime(area.StartTime)
						Dim rowPart As Integer = CInt(MainObject.Visibility.GetRemainderRowPercentFromTime(area.StartTime) * MainObject.RowHeader.Size)
						top += ((rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight) + rowPart
						width = CacheObject.ClientWidth
						height = GetIntlInteger((CSng(area.Length) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight))
						defaultRects(0) = New Rectangle(left, top, width, height)
					Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
						Dim rowcol As Integer = MainObject.Visibility.GetRowColFromTime(area.StartTime)
						Dim rowPart As Integer = CInt(MainObject.Visibility.GetRemainderRowPercentFromTime(area.StartTime) * MainObject.ColumnHeader.Size)
						left += ((rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + rowPart
						width = GetIntlInteger((CSng(area.Length) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth))
						height = CacheObject.ClientHeight
						defaultRects(0) = New Rectangle(left, top, width, height)
					Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.DayLeftResourceTop
						Return
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim rowcol As Integer = 0
						If (area.AreaType And ScheduleAreaTypeConstants.Day) = ScheduleAreaTypeConstants.Day Then
							'If there is a day component then only calculate the time in that one day
							Dim rects(1) As Rectangle
							Dim daterowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
							rowcol = daterowcol + TimeIncrementsFromStartOfDay(area.StartTime, MainObject.TimeIncrementValue)
							Dim rowSpan As Integer = (area.Length \ MainObject.TimeIncrementValue)
							If (area.Length Mod MainObject.TimeIncrementValue) <> 0 Then
								rowSpan += 1
							End If
							top = CacheObject.ClientTop + ((rowcol - CacheObject.FirstVisibleRow) * CacheObject.RowHeight)
							width = CacheObject.ClientWidth
							height = CacheObject.RowHeight * rowSpan
							rects(0) = New Rectangle(left, top, width, height)
							myRectangle = rects
						ElseIf area.AreaType = ScheduleAreaTypeConstants.Time Then
							'Otherwise calculate all time rectangles for every day
							Dim maxRowIncs As Integer = 0
							maxRowIncs = (MainObject.Visibility.VisibleRows \ MainObject.TimeIncrementsPerDay) + 1
							Dim rowSpan As Integer = (area.Length \ MainObject.TimeIncrementValue)
							If (area.Length Mod MainObject.TimeIncrementValue) <> 0 Then
								rowSpan += 1
							End If
							Dim rects(maxRowIncs) As Rectangle
							rowcol = TimeIncrementsFromStartOfDay(area.StartTime, MainObject.TimeIncrementValue)
							rowcol -= (MainObject.Visibility.FirstVisibleRow Mod MainObject.TimeIncrementsPerDay)
							For ii As Integer = 0 To maxRowIncs
								top = CacheObject.ClientTop + (rowcol + (ii * MainObject.TimeIncrementsPerDay)) * CacheObject.RowHeight
								width = CacheObject.ClientWidth
								height = CacheObject.RowHeight * rowSpan
								rects(ii) = New Rectangle(left, top, width, height)
							Next
							myRectangle = rects
						End If
					Case Schedule.ViewModeConstants.Week
						Return
					Case Schedule.ViewModeConstants.MonthFull
						Return
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaRoom(ByVal g As Graphics, ByVal area As ScheduleArea, ByRef myRectangle() As Rectangle)

			Dim left As Integer = CacheObject.ClientLeft
			Dim top As Integer = CacheObject.ClientTop
			Dim width As Integer
			Dim height As Integer

			Try

				'Default to something
				Dim defaultRects(1) As Rectangle
				myRectangle = defaultRects

				'Calculate the room rectangles
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.RoomLeftProviderTop
						Dim rowcol As Integer = area.Room
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight
						Dim rects(1) As Rectangle
						myRectangle = rects
						myRectangle(0) = New Rectangle(left, top, width, height)

					Case Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomTopProviderLeft, Schedule.ViewModeConstants.DayLeftRoomTop
						Dim rowcol As Integer = area.Room
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth
						height = CacheObject.ClientHeight
						Dim rects(1) As Rectangle
						myRectangle = rects
						myRectangle(0) = New Rectangle(left, top, width, height)

					Case Schedule.ViewModeConstants.DayRoomTopTimeLeft
						Dim rowcol As Integer = 0
						If (area.AreaType And ScheduleAreaTypeConstants.Day) = ScheduleAreaTypeConstants.Day Then
							'If there is a day component then only calculate the room in that one day
							Dim rects(1) As Rectangle
							Dim daterowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
							rowcol = daterowcol + area.Room
							left = CacheObject.ClientLeft + ((rowcol - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth)
							width = CacheObject.ColumnWidth
							height = CacheObject.ClientHeight
							rects(0) = New Rectangle(left, top, width, height)
							myRectangle = rects
						Else
							'Otherwise calculate all room rectangles for every day
							Dim maxColIncs As Integer = 0
							maxColIncs = (MainObject.Visibility.VisibleColumns \ MainObject.RoomCollection.VisibleCount) + 1
							Dim rects(maxColIncs) As Rectangle
							rowcol = area.Room - (MainObject.Visibility.FirstVisibleColumn Mod MainObject.RoomCollection.VisibleCount)
							For ii As Integer = 0 To maxColIncs
								left = CacheObject.ClientLeft + (rowcol + (ii * MainObject.RoomCollection.VisibleCount)) * CacheObject.ColumnWidth
								width = CacheObject.ColumnWidth
								height = CacheObject.ClientHeight
								rects(ii) = New Rectangle(left, top, width, height)
							Next
							myRectangle = rects
						End If

					Case Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim rowcol As Integer = 0
						If (area.AreaType And ScheduleAreaTypeConstants.Day) = ScheduleAreaTypeConstants.Day Then
							'If there is a day component then only calculate the room in that one day
							Dim rects(1) As Rectangle
							Dim daterowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
							rowcol = daterowcol + area.Room
							top = CacheObject.ClientTop + ((rowcol - CacheObject.FirstVisibleRow) * CacheObject.RowHeight)
							width = CacheObject.ClientWidth
							height = CacheObject.RowHeight
							rects(0) = New Rectangle(left, top, width, height)
							myRectangle = rects
						Else
							'Otherwise calculate all room rectangles for every day
							Dim maxRowIncs As Integer = 0
							maxRowIncs = (MainObject.Visibility.VisibleRows \ MainObject.RoomCollection.VisibleCount) + 1
							Dim rects(maxRowIncs) As Rectangle
							rowcol = area.Room - (MainObject.Visibility.FirstVisibleRow Mod MainObject.RoomCollection.VisibleCount)
							For ii As Integer = 0 To maxRowIncs
								top = CacheObject.ClientTop + (rowcol + (ii * MainObject.RoomCollection.VisibleCount)) * CacheObject.RowHeight
								width = CacheObject.ClientWidth
								height = CacheObject.RowHeight
								rects(ii) = New Rectangle(left, top, width, height)
							Next
							myRectangle = rects
						End If

					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return

					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayLeftResourceTop
						Return

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Return

						'*************************************************************************
						'THIS IS JUST LIKE ROOMTOP ABOVE
						'*************************************************************************
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim rowcol As Integer = area.Room
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth
						height = CacheObject.ClientHeight
						Dim rects(1) As Rectangle
						myRectangle = rects
						myRectangle(0) = New Rectangle(left, top, width, height)
						Return

					Case Schedule.ViewModeConstants.Week
						Return

					Case Schedule.ViewModeConstants.MonthFull
						Return

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaProvider(ByVal g As Graphics, ByVal area As ScheduleArea, ByRef myRectangle() As Rectangle)

			Dim left As Integer = CacheObject.ClientLeft
			Dim top As Integer = CacheObject.ClientTop
			Dim width As Integer
			Dim height As Integer

			Try

				'Default to something
				Dim defaultRects(1) As Rectangle
				myRectangle = defaultRects

				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopProviderLeft, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.RoomTopProviderLeft
						Dim rowcol As Integer = area.Provider
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight
						Dim rects(1) As Rectangle
						myRectangle = rects
						myRectangle(0) = New Rectangle(left, top, width, height)

					Case Schedule.ViewModeConstants.DayLeftProviderTop, Schedule.ViewModeConstants.RoomLeftProviderTop, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Dim rowcol As Integer = area.Provider
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth
						height = CacheObject.ClientHeight
						Dim rects(1) As Rectangle
						myRectangle = rects
						myRectangle(0) = New Rectangle(left, top, width, height)

					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Dim rowcol As Integer = 0
						If (area.AreaType And ScheduleAreaTypeConstants.Day) = ScheduleAreaTypeConstants.Day Then
							'If there is a day component then only calculate the provider in that one day
							Dim rects(1) As Rectangle
							Dim daterowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
							rowcol = daterowcol + area.Provider
							left = CacheObject.ClientLeft + ((rowcol - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth)
							width = CacheObject.ColumnWidth
							height = CacheObject.ClientHeight
							rects(0) = New Rectangle(left, top, width, height)
							myRectangle = rects
						Else
							'Otherwise calculate all provider rectangles for every day
							Dim maxColIncs As Integer = 0
							maxColIncs = (MainObject.Visibility.VisibleColumns \ MainObject.ProviderCollection.VisibleCount) + 1
							Dim rects(maxColIncs) As Rectangle
							rowcol = area.Provider - (MainObject.Visibility.FirstVisibleColumn Mod MainObject.ProviderCollection.VisibleCount)
							For ii As Integer = 0 To maxColIncs
								left = CacheObject.ClientLeft + (rowcol + (ii * MainObject.ProviderCollection.VisibleCount)) * CacheObject.ColumnWidth
								width = CacheObject.ColumnWidth
								height = CacheObject.ClientHeight
								rects(ii) = New Rectangle(left, top, width, height)
							Next
							myRectangle = rects
						End If

					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Dim rowcol As Integer = 0
						If (area.AreaType And ScheduleAreaTypeConstants.Day) = ScheduleAreaTypeConstants.Day Then
							'If there is a day component then only calculate the provider in that one day
							Dim rects(1) As Rectangle
							Dim daterowcol As Integer = MainObject.Visibility.GetRowColFromDate(area.StartDate)
							rowcol = daterowcol + area.Provider
							top = CacheObject.ClientTop + ((rowcol - CacheObject.FirstVisibleRow) * CacheObject.RowHeight)
							width = CacheObject.ClientWidth
							height = CacheObject.RowHeight
							rects(0) = New Rectangle(left, top, width, height)
							myRectangle = rects
						Else
							'Otherwise calculate all provider rectangles for every day
							Dim maxRowIncs As Integer = 0
							maxRowIncs = (MainObject.Visibility.VisibleRows \ MainObject.ProviderCollection.VisibleCount) + 1
							Dim rects(maxRowIncs) As Rectangle
							rowcol = area.Provider - (MainObject.Visibility.FirstVisibleRow Mod MainObject.ProviderCollection.VisibleCount)
							For ii As Integer = 0 To maxRowIncs
								top = CacheObject.ClientTop + (rowcol + (ii * MainObject.ProviderCollection.VisibleCount)) * CacheObject.RowHeight
								width = CacheObject.ClientWidth
								height = CacheObject.RowHeight
								rects(ii) = New Rectangle(left, top, width, height)
							Next
							myRectangle = rects
						End If

					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.Month
						Return
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop, Schedule.ViewModeConstants.Week, Schedule.ViewModeConstants.MonthFull, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayLeftResourceTop
						Return
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawColoredAreaResource(ByVal g As Graphics, ByVal area As ScheduleArea, ByRef myRectangle As Rectangle)

			Dim left As Integer = CacheObject.ClientLeft
			Dim top As Integer = CacheObject.ClientTop
			Dim width As Integer
			Dim height As Integer

			Try

				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.ResourceLeftTimeTop
						Dim rowcol As Integer = area.Resource
						top += (rowcol - MainObject.Visibility.FirstVisibleRow) * CacheObject.RowHeight
						width = CacheObject.ClientWidth
						height = CacheObject.RowHeight
					Case Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayLeftResourceTop
						Dim rowcol As Integer = area.Resource
						left += (rowcol - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth
						width = CacheObject.ColumnWidth
						height = CacheObject.ClientHeight
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayTopRoomLeft, Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayLeftRoomTop, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.Month, Schedule.ViewModeConstants.DayTimeLeftRoomTop, Schedule.ViewModeConstants.Week, Schedule.ViewModeConstants.MonthFull, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

				myRectangle = New Rectangle(left, top, width, height)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawDayHeaders"

		'Draw the day header when it is on the left
		Private Sub DrawDayHeaderLeft(ByVal g As Graphics)

			Dim DateCurrent As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim marginWidth As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1
					DateCurrent = DateAdd(DateInterval.Day, ii, CacheObject.FirstVisibleDate)
					cellText = DateCurrent.ToString(MainObject.HeaderDateFormat)

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(0, currentTop, marginWidth, CacheObject.RowHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Draw the border
					Dim backbrush As Brush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
					Call g.FillRectangle(backbrush, DrawRect)
					Call backbrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		'Draw the day header when it is on the top
		Private Sub DrawDayHeaderTop(ByVal g As Graphics)

			Dim DateCurrent As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim LeftCurrent As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Loop through the number of visible days and draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
					DateCurrent = DateAdd(DateInterval.Day, ii, CacheObject.FirstVisibleDate)
					cellText = DateCurrent.ToString(MainObject.HeaderDateFormat)

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, CacheObject.ClientTop - CacheObject.EventHeaderHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Draw the border
					Dim backbrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
					Call g.FillRectangle(backbrush, DrawRect)
					Call backbrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					LeftCurrent += CacheObject.ColumnWidth

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawTimeHeaders"

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawTimeHeaderLeft(ByVal g As Graphics)
			DrawTimeHeaderLeft(g, True)
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawTimeHeaderLeft(ByVal g As Graphics, ByVal drawTimeBars As Boolean)
			If Me.MainObject.MinutesShown = Schedule.MinutesShownConstants.Normal Then
				DrawTimeHeaderLeftNormal(g, drawTimeBars)
			Else
				DrawTimeHeaderLeftOutlook(g, drawTimeBars)
			End If
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
	 Private Sub DrawTimeHeaderLeftOutlook(ByVal g As Graphics, ByVal drawTimeBars As Boolean)

			Dim TimeCurrent As DateTime
			Dim hourText As String = ""
			Dim minuteText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim HourFont As Font
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)
			Dim minuteBarWidth As Integer
			Dim marginLeft As Integer
			Dim hasDrawnAMPM As Boolean = False
			Dim backBrush As Brush

			Try

				'Draw the Timebar
				If drawTimeBars Then
					Call DrawTimeBarLeft(g)
				End If

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				minuteBarWidth = MainObject.TextWidth(g, "00", theFont) + ScheduleGlobals.TextMargin

				HourFont = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily, theFont.Size * 2)

				'Get the 'Left' coordinate of the time margin - This is NOT always 0
				marginLeft = CacheObject.ClientLeft - Me.MainObject.GetTimeMarginWidth(True)

				'Loop through the number of visible times AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1

					TimeCurrent = CacheObject.FirstVisibleTime.AddMinutes(ii * GetIntlInteger(CacheObject.TimeIncrement))

					If MainObject.ClockSetting = Schedule.ClockSettingConstants.Clock24 Then
						hourText = TimeCurrent.ToString("HH")
					Else
						hourText = TimeCurrent.ToString("hh")
						If (TimeCurrent.Hour Mod 12) <> 10 Then hourText = Replace(hourText, "0", "")
					End If
					minuteText = TimeCurrent.ToString("mm")

					'If this is an hour break then draw the hour text
					If (TimeCurrent.Minute = 0) Then

						'Calculate the rectangle in which to draw the text
						DrawRect = New Rectangle(marginLeft, currentTop, CacheObject.ClientLeft - marginLeft, CacheObject.RowHeight * MainObject.TimeIncrementsPerHour)

						'Draw the border
						backBrush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
						Call g.FillRectangle(backBrush, DrawRect)
						Call backBrush.Dispose()
						If borderPen.Width > 0 Then
							Call g.DrawRectangle(borderPen, DrawRect)
						End If

						'Draw the hour text
						DrawRectF = New System.Drawing.RectangleF(DrawRect.Left, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin - minuteBarWidth, (DrawRect.Height * MainObject.TimeIncrementsPerHour) - ScheduleGlobals.TextMargin)
						stringFormat.Alignment = StringAlignment.Far
						stringFormat.LineAlignment = StringAlignment.Near
						stringFormat.Trimming = MainObject.RowHeader.Appearance.TextTrimming
						Call g.DrawString(hourText, HourFont, textPen.Brush, DrawRectF, stringFormat)

					Else
						'Draw the minute bar above the minute text if NOT on hour break
						If borderPen.Width > 0 Then
							Call g.DrawLine(borderPen, CacheObject.ClientLeft - minuteBarWidth, currentTop, CacheObject.ClientLeft, currentTop)
						End If

					End If

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(marginLeft, currentTop, CacheObject.ClientLeft - marginLeft, CacheObject.RowHeight)

					'If we are starting on a NON-hour break then draw the border
					If (TimeCurrent.Minute <> 0) AndAlso (ii = 0) Then
						'Draw the border
						Dim rtHeight As Integer = (MinutesPerHour - TimeCurrent.Minute) \ CacheObject.TimeIncrement
						Dim rt As Rectangle = New Rectangle(DrawRect.Left, DrawRect.Top, DrawRect.Width, CacheObject.RowHeight * rtHeight)
						backBrush = CreateBrush(MainObject.RowHeader.Appearance, rt)
						Call g.FillRectangle(backBrush, rt)
						Call backBrush.Dispose()
						If borderPen.Width > 0 Then
							Call g.DrawRectangle(borderPen, rt)
						End If
					End If

					'Draw the Minute text
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)
					stringFormat.Alignment = StringAlignment.Far
					stringFormat.LineAlignment = MainObject.RowHeader.Appearance.TextVAlign

					'Replace the "00" minutes with "AM/PM" if 12-hour
					'format and this is the first visible hour increment
					If (TimeCurrent.Minute = 0) AndAlso (Not hasDrawnAMPM) AndAlso (MainObject.ClockSetting = Schedule.ClockSettingConstants.Clock12) Then
						minuteText = TimeCurrent.ToString("tt")
						hasDrawnAMPM = True
					End If

					'If drawing "00" minute only then erase all others
					If MainObject.MinutesShown = Schedule.MinutesShownConstants.FirstOnly Then
						If (TimeCurrent.Minute <> 0) Then minuteText = ""
					End If

					stringFormat.Trimming = MainObject.RowHeader.Appearance.TextTrimming
					Call g.DrawString(minuteText, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Draw the time marker (If necesary)
					If MainObject.TimeMarker.Visible Then
						Dim offsetMinutes As Integer = -CInt(TimeCurrent.Subtract(GetTime(DateTime.Now)).TotalMinutes)
						If (0 <= offsetMinutes) AndAlso (offsetMinutes < MainObject.TimeIncrementValue) Then
							Dim offsetMinutesY As Integer = CInt((offsetMinutes * 1.0) / MainObject.TimeIncrementValue * CacheObject.RowHeight)
							g.DrawLine(New Pen(MainObject.TimeMarker.Appearance.BackColor), marginLeft, currentTop + offsetMinutesY, MainObject.ClientLeft, currentTop + offsetMinutesY)
						End If
					End If

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawTimeHeaderLeftNormal(ByVal g As Graphics, ByVal drawTimeBars As Boolean)

			Dim TimeCurrent As DateTime
			Dim timeText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)
			Dim marginLeft As Integer
			Dim backBrush As Brush

			Try

				'Draw the Timebar
				If drawTimeBars Then
					Call DrawTimeBarLeft(g)
				End If

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				'Get the 'Left' coordinate of the time margin - This is NOT always 0
				marginLeft = CacheObject.ClientLeft - Me.MainObject.GetTimeMarginWidth(True)

				'Loop through the number of visible times AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1

					TimeCurrent = CacheObject.FirstVisibleTime.AddMinutes(ii * GetIntlInteger(CacheObject.TimeIncrement))
					If MainObject.ClockSetting = Schedule.ClockSettingConstants.Clock24 Then
						timeText = TimeCurrent.ToString("HH:mm")
					Else
						timeText = TimeCurrent.ToString("hh:mm")

						'Make PM Bold
						If Not theFont.Bold AndAlso TimeCurrent.Hour >= 12 Then
							theFont = New Font(theFont, FontStyle.Bold)
						End If

					End If

					'Draw the minute bar above the minute text if NOT on hour break
					If borderPen.Width > 0 Then
						Call g.DrawLine(borderPen, CacheObject.ClientLeft, currentTop, CacheObject.ClientLeft, currentTop)
					End If

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(marginLeft, currentTop, CacheObject.ClientLeft - marginLeft, CacheObject.RowHeight)

					'Draw the border
					backBrush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					Call backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the hour text
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)
					stringFormat.Alignment = StringAlignment.Far
					stringFormat.LineAlignment = StringAlignment.Near
					stringFormat.Trimming = MainObject.RowHeader.Appearance.TextTrimming
					Call g.DrawString(timeText, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Draw the time marker (If necesary)
					If MainObject.TimeMarker.Visible Then
						Dim offsetMinutes As Integer = -CInt(TimeCurrent.Subtract(GetTime(DateTime.Now)).TotalMinutes)
						If (0 <= offsetMinutes) AndAlso (offsetMinutes < MainObject.TimeIncrementValue) Then
							Dim offsetMinutesY As Integer = CInt((offsetMinutes * 1.0) / MainObject.TimeIncrementValue * CacheObject.RowHeight)
							g.DrawLine(New Pen(MainObject.TimeMarker.Appearance.BackColor), marginLeft, currentTop + offsetMinutesY, MainObject.ClientLeft, currentTop + offsetMinutesY)
						End If
					End If

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawTimeHeaderTop(ByVal g As Graphics)

			Dim TimeCurrent As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim LeftCurrent As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)
			Dim backBrush As Brush

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Loop through the number of visible times AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
					TimeCurrent = DateAdd(DateInterval.Minute, ii * GetIntlInteger(CacheObject.TimeIncrement), CacheObject.FirstVisibleTime)
					cellText = TimeCurrent.ToString(MainObject.HeaderTimeFormat)

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, CacheObject.ClientTop)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Draw the border
					backBrush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					Call backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					stringFormat.Trimming = MainObject.ColumnHeader.Appearance.TextTrimming
					Call g.DrawString(cellText, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Draw the time marker (If necesary)
					If MainObject.TimeMarker.Visible Then
						Dim offsetMinutes As Integer = -CInt(TimeCurrent.Subtract(GetTime(DateTime.Now)).TotalMinutes)
						If (0 <= offsetMinutes) AndAlso (offsetMinutes < MainObject.TimeIncrementValue) Then
							Dim offsetMinutesX As Integer = CInt((offsetMinutes * 1.0) / MainObject.TimeIncrementValue * CacheObject.ColumnWidth)
							g.DrawLine(New Pen(MainObject.TimeMarker.Appearance.BackColor), LeftCurrent + offsetMinutesX, 0, LeftCurrent + offsetMinutesX, MainObject.ClientTop)
						End If
					End If

					LeftCurrent += CacheObject.ColumnWidth

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawTimeBarLeft"

		Private Sub DrawTimeBarLeft(ByVal g As Graphics)
			DrawTimeBarLeft(g, True)
		End Sub

		Private Sub DrawTimeBarLeft(ByVal g As Graphics, ByVal drawTimeBars As Boolean)

			'Draw the column outlines. the actual colored bars will be drawn by the appointments
			Try

				'Calculate the number of columns to draw
				Dim colCount As Integer = 0
				Select Case MainObject.TimeBar.BarType
					Case Schedule.AppointmentBarConstants.None
						Return
					Case Schedule.AppointmentBarConstants.Category
						colCount = MainObject.CategoryCollection.Count
					Case Schedule.AppointmentBarConstants.Provider
						colCount = MainObject.ProviderCollection.VisibleCount
					Case Schedule.AppointmentBarConstants.Resource
						colCount = MainObject.ResourceCollection.Count
					Case Schedule.AppointmentBarConstants.UserDrawn
						colCount = 1
				End Select

				Dim myBrush As Brush = New SolidBrush(Color.White)
				Dim myPen As Pen = New Pen(Color.Black)

				'Draw the column outlines
				Dim left As Integer = 0
				Dim height As Integer = CacheObject.ClientHeight
				Dim top As Integer = CacheObject.ClientTop
				For ii As Integer = 0 To colCount - 1
					g.FillRectangle(myBrush, left + (ii * MainObject.TimeBar.Size), top, MainObject.TimeBar.Size, height)
					g.DrawRectangle(myPen, left + (ii * MainObject.TimeBar.Size), top, MainObject.TimeBar.Size, height)
				Next

				'Dispose of drawing objects
				Call myBrush.Dispose()
				Call myPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawRoomHeaders"

		Private Sub DrawRoomHeaderRoomLeft(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.RowHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)

			Try
				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)
				Dim visibleRooms As ArrayList = MainObject.RoomCollection.VisibleList

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleRow + ii
					Dim room As Gravitybox.Objects.Room = CType(visibleRooms(currentIndex), Gravitybox.Objects.Room)
					cellText = room.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(0, currentTop, CacheObject.ClientLeft, CacheObject.RowHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = room.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeRoomHeaderEventArgs = New BeforeRoomHeaderEventArgs(room, cellText)
					Call MainObject.FireEventBeforeRoomHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawRoomHeaderRoomTop(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.ColumnHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim LeftCurrent As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)
				Dim visibleRooms As ArrayList = MainObject.RoomCollection.VisibleList

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleColumn + ii
					Dim room As Gravitybox.Objects.Room = CType(visibleRooms(currentIndex), Gravitybox.Objects.Room)
					cellText = room.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, CacheObject.ClientTop)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = room.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeRoomHeaderEventArgs = New BeforeRoomHeaderEventArgs(room, cellText)
					Call MainObject.FireEventBeforeRoomHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					LeftCurrent += CacheObject.ColumnWidth

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawResourceHeaders"

		Private Sub DrawResourceHeaderResourceLeft(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.RowHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)

			Try
				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleRow + ii
					Dim resource As Gravitybox.Objects.Resource = MainObject.ResourceCollection(currentIndex)
					cellText = resource.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(0, currentTop, CacheObject.ClientLeft, CacheObject.RowHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = resource.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeResourceHeaderEventArgs = New BeforeResourceHeaderEventArgs(resource, cellText)
					Call MainObject.FireEventBeforeResourceHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawResourceHeaderResourceTop(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.ColumnHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim LeftCurrent As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)
				Dim visibleResources As ArrayList = MainObject.ResourceCollection.VisibleList

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleColumn + ii
					Dim resource As Gravitybox.Objects.Resource = CType(visibleResources(currentIndex), Gravitybox.Objects.Resource)
					cellText = resource.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, CacheObject.ClientTop)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = resource.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeResourceHeaderEventArgs = New BeforeResourceHeaderEventArgs(resource, cellText)
					Call MainObject.FireEventBeforeResourceHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					LeftCurrent += CacheObject.ColumnWidth

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawDayRoomHeaders"

		Private Sub DrawDayRoomHeaderLeft(ByVal g As Graphics)

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer
			Dim dayMarginWidth As Integer
			Dim roomMarginWidth As Integer
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)
			Dim dayCount As Integer
			Dim room As Room
			Dim skew As Integer
			Dim rectTop As Integer
			Dim rectHeight As Integer

			'There are no rooms present. Nothing to do
			If MainObject.RoomCollection.VisibleCount = 0 Then Return

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				'Make the start row the first visible room of the first visible date
				If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
				Else
					skew = (MainObject.VScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
				End If
				startDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow)
				endDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows)
				dayCount = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))

				currentTop = CacheObject.ClientTop - (skew * CacheObject.RowHeight)

				'Get the width of the two rows
				dayMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.DayLeftProviderTop)
				roomMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.RoomLeftTimeTop)

				'Loop through the visible days
				For ii As Integer = 0 To dayCount
					'Day Text
					cellText = startDate.ToString(MainObject.HeaderDateFormat)

					'Draw the day text
					rectTop = currentTop
					rectHeight = CacheObject.RowHeight * MainObject.RoomCollection.VisibleCount
					If rectTop < CacheObject.ClientTop Then
						rectHeight -= (CacheObject.ClientTop - rectTop)
						rectTop = CacheObject.ClientTop
					End If
					DrawRect = New Rectangle(0, rectTop, dayMarginWidth, rectHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Raise the before header event
					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the border
					Dim backBrush As Brush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Loop through the visible rooms
					For Each room In MainObject.RoomCollection
						If (room.Visible) Then
							'Calculate the rectangle in which to draw the text
							DrawRect = New Rectangle(dayMarginWidth, currentTop, roomMarginWidth, CacheObject.RowHeight)
							DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

							'Raise the before header event
							eventParam = New BeforeHeaderEventArgs(room.Text)
							Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

							'Draw the border
							backBrush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
							Call g.FillRectangle(backBrush, DrawRect)
							backBrush.Dispose()
							If borderPen.Width > 0 Then
								Call g.DrawRectangle(borderPen, DrawRect)
							End If

							'Draw the date string
							Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

							'Increment the top coordinate
							currentTop += CacheObject.RowHeight
						End If
					Next
					Call backBrush.Dispose()

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)

				Next

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawDayRoomHeaderTop(ByVal g As Graphics)

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentLeft As Integer
			Dim dayMarginHeight As Integer
			Dim roomMarginHeight As Integer
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)
			Dim dayCount As Integer
			Dim room As Room
			Dim skew As Integer
			Dim rectLeft As Integer
			Dim rectWidth As Integer

			'There are no rooms present. Nothing to do
			If MainObject.RoomCollection.VisibleCount = 0 Then Return

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Make the start column the first visible room of the first visible date
				If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
				Else
					skew = (MainObject.HScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
				End If

				startDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleColumn)
				endDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns)
				dayCount = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))

				currentLeft = CacheObject.ClientLeft - (skew * CacheObject.ColumnWidth)

				'Get the height of the two rows
				dayMarginHeight = MainObject.ClientTop(Schedule.ViewModeConstants.DayTopProviderLeft) - CacheObject.EventHeaderHeight
				roomMarginHeight = MainObject.ClientTop(Schedule.ViewModeConstants.RoomTopProviderLeft)

				'Loop through the visible days
				For ii As Integer = 0 To dayCount
					'Day Text
					cellText = startDate.ToString(MainObject.HeaderDateFormat)

					'Draw the day text
					rectLeft = currentLeft
					rectWidth = CacheObject.ColumnWidth * MainObject.RoomCollection.VisibleCount
					If rectLeft < CacheObject.ClientLeft Then
						rectWidth -= (CacheObject.ClientLeft - rectLeft)
						rectLeft = CacheObject.ClientLeft
					End If
					DrawRect = New Rectangle(rectLeft, 0, rectWidth, dayMarginHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Raise the before header event
					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the border
					Dim backBrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Loop through the visible rooms
					For Each room In MainObject.RoomCollection.VisibleList
						If (room.Visible) Then
							'Calculate the rectangle in which to draw the text
							DrawRect = New Rectangle(currentLeft, dayMarginHeight, CacheObject.ColumnWidth, roomMarginHeight)
							DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

							'Raise the before header event
							eventParam = New BeforeHeaderEventArgs(room.Text)
							Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

							'Draw the border
							backBrush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
							Call g.FillRectangle(backBrush, DrawRect)
							Call backBrush.Dispose()
							If borderPen.Width > 0 Then
								Call g.DrawRectangle(borderPen, DrawRect)
							End If

							'Draw the date string
							Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

							'Increment the top coordinate
							currentLeft += CacheObject.ColumnWidth
						End If
					Next

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)

				Next

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawDayProviderHeaders"

		Private Sub DrawDayProviderHeaderLeft(ByVal g As Graphics)

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer
			Dim dayMarginWidth As Integer
			Dim providerMarginWidth As Integer
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)
			Dim dayCount As Integer
			Dim provider As Provider
			Dim skew As Integer
			Dim rectTop As Integer
			Dim rectHeight As Integer

			'There are no providers present. Nothing to do
			If MainObject.ProviderCollection.VisibleCount = 0 Then Return

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				'Make the start row the first visible provider of the first visible date
				If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
				Else
					skew = (MainObject.VScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
				End If
				startDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow)
				endDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows)
				dayCount = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))

				currentTop = CacheObject.ClientTop - (skew * CacheObject.RowHeight)

				'Get the width of the two rows
				dayMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.DayLeftProviderTop)
				providerMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.ProviderLeftTimeTop)

				'Loop through the visible days
				For ii As Integer = 0 To dayCount
					'Day Text
					cellText = startDate.ToString(MainObject.HeaderDateFormat)

					'Draw the day text
					rectTop = currentTop
					rectHeight = CacheObject.RowHeight * MainObject.ProviderCollection.VisibleCount
					If rectTop < CacheObject.ClientTop Then
						rectHeight -= (CacheObject.ClientTop - rectTop)
						rectTop = CacheObject.ClientTop
					End If
					DrawRect = New Rectangle(0, rectTop, dayMarginWidth, rectHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Raise the before header event
					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the border
					Dim backBrush As Brush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Loop through the visible providers
					For Each provider In MainObject.ProviderCollection

						If (provider.Visible) Then
							'Calculate the rectangle in which to draw the text
							DrawRect = New Rectangle(dayMarginWidth, currentTop, providerMarginWidth, CacheObject.RowHeight)
							DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

							'Raise the before header event
							eventParam = New BeforeHeaderEventArgs(provider.Text)
							Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

							'Draw the border
							backBrush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
							Call g.FillRectangle(backBrush, DrawRect)
							backBrush.Dispose()
							If borderPen.Width > 0 Then
								Call g.DrawRectangle(borderPen, DrawRect)
							End If

							'Draw the date string
							Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

							'Increment the top coordinate
							currentTop += CacheObject.RowHeight
						End If

					Next
					Call backBrush.Dispose()

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)

				Next

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawDayProviderHeaderTop(ByVal g As Graphics)

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentLeft As Integer
			Dim dayMarginHeight As Integer
			Dim providerMarginHeight As Integer
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)
			Dim dayCount As Integer
			Dim provider As Provider
			Dim skew As Integer
			Dim rectLeft As Integer
			Dim rectWidth As Integer

			'There are no providers present. Nothing to do
			If MainObject.ProviderCollection.VisibleCount = 0 Then Return

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Make the start column the first visible provider of the first visible date
				If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
				Else
					skew = (MainObject.HScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
				End If

				startDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleColumn)
				endDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns)
				dayCount = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))

				currentLeft = CacheObject.ClientLeft - (skew * CacheObject.ColumnWidth)

				'Get the height of the two rows
				dayMarginHeight = MainObject.ClientTop(Schedule.ViewModeConstants.DayTopProviderLeft) - CacheObject.EventHeaderHeight
				providerMarginHeight = MainObject.ClientTop(Schedule.ViewModeConstants.ProviderTopTimeLeft)

				'Loop through the visible days
				For ii As Integer = 0 To dayCount
					'Day Text
					cellText = startDate.ToString(MainObject.HeaderDateFormat)

					'Draw the day text
					rectLeft = currentLeft
					rectWidth = CacheObject.ColumnWidth * MainObject.ProviderCollection.VisibleCount
					If rectLeft < CacheObject.ClientLeft Then
						rectWidth -= (CacheObject.ClientLeft - rectLeft)
						rectLeft = CacheObject.ClientLeft
					End If
					DrawRect = New Rectangle(rectLeft, 0, rectWidth, dayMarginHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Raise the before header event
					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the border
					Dim backBrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					'Loop through the visible providers
					For Each provider In MainObject.ProviderCollection.VisibleList
						If (provider.Visible) Then
							'Calculate the rectangle in which to draw the text
							DrawRect = New Rectangle(currentLeft, dayMarginHeight, CacheObject.ColumnWidth, providerMarginHeight)
							DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

							'Raise the before header event
							eventParam = New BeforeHeaderEventArgs(provider.Text)
							Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

							'Draw the border
							backBrush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
							Call g.FillRectangle(backBrush, DrawRect)
							Call backBrush.Dispose()
							If borderPen.Width > 0 Then
								Call g.DrawRectangle(borderPen, DrawRect)
							End If

							'Draw the date string
							Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

							'Increment the top coordinate
							currentLeft += CacheObject.ColumnWidth
						End If
					Next

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)

				Next

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawDayTimeHeaders"

		Private Sub DrawDayTimeHeaderLeft(ByVal g As Graphics)
			DrawDayTimeHeaderLeft(g, MainObject.TimeBar.BarType <> Schedule.AppointmentBarConstants.None)
		End Sub

		<MethodImpl(MethodImplOptions.Synchronized)> _
		Friend Sub DrawDayTimeHeaderLeft(ByVal g As Graphics, ByVal drawTimeBars As Boolean)

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim TimeCurrent As DateTime
			Dim cellText As String = ""
			Dim timeText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim HourFont As Font
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)
			Dim minuteBarWidth As Integer
			Dim marginLeft As Integer
			Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
			Dim dayCount As Integer
			Dim hasDrawnAMPM As Boolean = False
			Dim backBrush As Brush
			Dim rectTop As Integer
			Dim rectHeight As Integer
			Dim dayMarginWidth As Integer
			Dim timeMarginWidth As Integer

			Try

				'Draw the Timebar
				If drawTimeBars Then
					Call DrawTimeBarLeft(g)
				End If

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)

				minuteBarWidth = MainObject.TextWidth(g, "00", theFont) + ScheduleGlobals.TextMargin

				HourFont = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily, theFont.Size * 2)

				'Get the width of the two rows
				dayMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.DayLeftProviderTop)
				timeMarginWidth = MainObject.ClientLeft(Schedule.ViewModeConstants.RoomLeftTimeTop)

				'Get the 'Left' coordinate of the time margin - This is NOT always 0
				marginLeft = CacheObject.ClientLeft - Me.MainObject.GetTimeMarginWidth(True)

				startDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow)
				endDate = MainObject.Visibility.GetDateFromRowCol(CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows)
				dayCount = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))

				'Loop through the visible days
				For ii As Integer = 0 To dayCount
					'Day Text
					cellText = startDate.ToString(MainObject.HeaderDateFormat)

					'Draw the day text
					rectTop = currentTop
					rectHeight = CacheObject.RowHeight * IncPerDay
					If rectTop < CacheObject.ClientTop Then
						rectHeight -= (CacheObject.ClientTop - rectTop)
						rectTop = CacheObject.ClientTop
					End If
					DrawRect = New Rectangle(marginLeft - dayMarginWidth, rectTop, dayMarginWidth, rectHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					'Raise the before header event
					Dim eventParam As BeforeHeaderEventArgs = New BeforeHeaderEventArgs(cellText)
					Call MainObject.FireEventBeforeDateHeaderDraw(Me, eventParam)

					'Draw the border
					backBrush = CreateBrush(MainObject.RowHeader.Appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					Dim startInc As Integer = 0
					If (ii = 0) Then
						startInc = CType(CacheObject.FirstVisibleTime.Subtract(#12:00:00 AM#).TotalMinutes / CacheObject.TimeIncrement, Integer)
					End If

					'Loop through the number of times per day and draw them
					For jj As Integer = startInc To IncPerDay - 1

						TimeCurrent = DateAdd(DateInterval.Minute, jj * GetIntlInteger(CacheObject.TimeIncrement), #12:00:00 AM#)
						timeText = TimeCurrent.ToString(MainObject.HeaderTimeFormat)

						'Calculate the rectangle in which to draw the text
						DrawRect = New Rectangle(marginLeft, currentTop + ((jj - startInc) * CacheObject.RowHeight), CacheObject.ClientLeft - marginLeft, CacheObject.RowHeight)

						'If we are starting on a NON-hour break then draw the border
						'Draw the border
						Dim rtHeight As Integer = (MinutesPerHour - TimeCurrent.Minute) \ CacheObject.TimeIncrement
						Dim rt As Rectangle = New Rectangle(DrawRect.Left, DrawRect.Top, DrawRect.Width, CacheObject.RowHeight * rtHeight)
						backBrush = CreateBrush(MainObject.RowHeader.Appearance, rt)
						Call g.FillRectangle(backBrush, rt)
						Call backBrush.Dispose()
						If borderPen.Width > 0 Then
							Call g.DrawRectangle(borderPen, rt)
						End If

						'Draw the Minute text
						DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)
						stringFormat.Alignment = StringAlignment.Far
						stringFormat.LineAlignment = MainObject.RowHeader.Appearance.TextVAlign

						stringFormat.Trimming = MainObject.RowHeader.Appearance.TextTrimming
						Call g.DrawString(timeText, theFont, textPen.Brush, DrawRectF, stringFormat)

					Next jj
					currentTop += (IncPerDay - startInc) * CacheObject.RowHeight

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)

				Next

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawDayTimeHeaderTop(ByVal g As Graphics)

			'Dim TimeCurrent As DateTime
			'Dim cellText As String = ""
			'Dim DrawRect As Rectangle
			'Dim DrawRectF As RectangleF
			'Dim LeftCurrent As Integer = CacheObject.ClientLeft
			'Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			'Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)
			'Dim backBrush As Brush

			'Try

			'  'Format the string
			'  Dim stringFormat As stringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
			'  Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

			'  'Loop through the number of visible times AndAlso draw them
			'  For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
			'    TimeCurrent = DateAdd(DateInterval.Minute, ii * GetIntlInteger(CacheObject.TimeIncrement), CacheObject.FirstVisibleTime)
			'    cellText = TimeCurrent.ToString(MainObject.HeaderTimeFormat)

			'    'Calculate the rectangle in which to draw the text
			'    DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, MainObject.TextHeight(g, theFont))
			'    DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

			'    'Draw the border
			'    backBrush = CreateBrush(MainObject.ColumnHeader.Appearance, DrawRect)
			'    Call g.FillRectangle(backBrush, DrawRect)
			'    Call backBrush.Dispose()
			'    If borderPen.Width > 0 Then
			'      Call g.DrawRectangle(borderPen, DrawRect)
			'    End If

			'    stringFormat.Trimming = MainObject.ColumnHeader.Appearance.TextTrimming
			'    Call g.DrawString(cellText, theFont, textPen.Brush, DrawRectF, stringFormat)

			'    LeftCurrent += CacheObject.ColumnWidth

			'  Next ii

			'  'Dispose of drawing objects
			'  Call textPen.Dispose()
			'  Call borderPen.Dispose()

			'Catch ex As Exception
			'  Call ErrorModule.SetErr(ex)
			'End Try

		End Sub

#End Region

#Region "DrawProviderHeaders"

		Private Sub DrawProviderHeaderProviderLeft(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.ColumnHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim currentTop As Integer = CacheObject.ClientTop
			Dim textPen As Pen = New Pen(MainObject.RowHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.RowHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.RowHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.RowHeader.Appearance, MainObject.Font.FontFamily)
				Dim visibleProviders As ArrayList = MainObject.ProviderCollection.VisibleList

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleRows - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleRow + ii
					Dim provider As Gravitybox.Objects.Provider = CType(visibleProviders(currentIndex), Gravitybox.Objects.Provider)
					cellText = provider.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(0, currentTop, CacheObject.ClientLeft, CacheObject.RowHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = provider.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)
					Call g.FillRectangle(backBrush, DrawRect)
					Call backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect)
					End If

					Dim eventParam As BeforeProviderHeaderEventArgs = New BeforeProviderHeaderEventArgs(provider, cellText)
					Call MainObject.FireEventBeforeProviderHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					currentTop += CacheObject.RowHeight

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawProviderHeaderProviderTop(ByVal g As Graphics)

			Dim appearance As Appearance = MainObject.ColumnHeader.Appearance
			Dim cellText As String = ""
			Dim DrawRect As Rectangle
			Dim DrawRectF As RectangleF
			Dim LeftCurrent As Integer = CacheObject.ClientLeft
			Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim borderPen As Pen = CreateBorderPen(MainObject.ColumnHeader.Appearance)

			Try

				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)
				Dim visibleProviders As ArrayList = MainObject.ProviderCollection.VisibleList

				'Loop through the number of visible days AndAlso draw them
				For ii As Integer = 0 To CacheObject.TotalVisibleColumns - 1
					Dim currentIndex As Integer = CacheObject.FirstVisibleColumn + ii
					Dim provider As Gravitybox.Objects.Provider = CType(visibleProviders(currentIndex), Gravitybox.Objects.Provider)
					cellText = provider.Text

					'Calculate the rectangle in which to draw the text
					DrawRect = New Rectangle(LeftCurrent, 0, CacheObject.ColumnWidth, CacheObject.ClientTop - CacheObject.EventHeaderHeight)
					DrawRectF = New System.Drawing.RectangleF(DrawRect.Left + ScheduleGlobals.TextMargin, DrawRect.Top + ScheduleGlobals.TextMargin, DrawRect.Width - ScheduleGlobals.TextMargin, DrawRect.Height - ScheduleGlobals.TextMargin)

					If Not MainObject.UseDefaultDrawnHeaders Then
						appearance = provider.Appearance
						textPen = New Pen(appearance.ForeColor)
						borderPen = CreateBorderPen(appearance)
						stringFormat = CreateStringFormat(appearance)
						theFont = CreateFont(appearance, MainObject.Font.FontFamily)
					End If

					'Draw the border
					Dim backBrush As Brush = CreateBrush(appearance, DrawRect)

					Call g.FillRectangle(backBrush, DrawRect)
					Call backBrush.Dispose()
					If borderPen.Width > 0 Then
						Call g.DrawRectangle(borderPen, DrawRect.Left, DrawRect.Top, DrawRect.Width, DrawRect.Height - 1)
					End If

					Dim eventParam As BeforeProviderHeaderEventArgs = New BeforeProviderHeaderEventArgs(provider, cellText)
					Call MainObject.FireEventBeforeProviderHeaderDraw(Me, eventParam)

					'Draw the date string
					Call g.DrawString(eventParam.Text, theFont, textPen.Brush, DrawRectF, stringFormat)

					LeftCurrent += CacheObject.ColumnWidth

				Next ii

				'Dispose of drawing objects
				Call textPen.Dispose()
				Call borderPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "DrawMonth Header"

		Private Sub DrawHeaderMonth(ByVal g As Graphics)

			Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
			Dim rectF As RectangleF
			Dim textBrush As Brush = New SolidBrush(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim gridPen As Pen = New Pen(MainObject.Appearance.ForeColor)
			Dim startDate As DateTime = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
			Dim left As Integer
			Dim dayHeaderHeight1 As Integer = CInt((CacheObject.ClientTop / 3) * 2)
			Dim dayHeaderHeight2 As Integer = CacheObject.ClientTop - dayHeaderHeight1

			Try
				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Fill the backcolor for the text "Month YYYY"
				'dayHeaderTop = CacheObject.TextHeight * 2
				Dim rect As New Rectangle(left, 0, (columnWidth * MainObject.Visibility.TotalColumnCount), dayHeaderHeight1)
				Dim gridBrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, rect)
				Call g.FillRectangle(gridBrush, rect)
				Call gridBrush.Dispose()
				Call g.DrawRectangle(gridPen, rect)

				'Draw the text for "Month YYYY"
				rectF = New RectangleF(left, 0, columnWidth * 6, dayHeaderHeight1)
				Dim stringFormat2 As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				stringFormat2.Alignment = StringAlignment.Center
				Dim monthFont As Font = New Font(MainObject.Font.FontFamily, MainObject.Font.Size * 2, FontStyle.Bold, MainObject.Font.Unit)
				Call g.DrawString(MainObject.MonthSelDate.ToString("MMMM yyyy"), monthFont, textBrush, rectF, stringFormat2)
				monthFont.Dispose()

				'Fill the backcolor of the column headers
				rect = New Rectangle(left, dayHeaderHeight1, (columnWidth * MainObject.Visibility.TotalColumnCount), dayHeaderHeight2)
				gridBrush = CreateBrush(MainObject.ColumnHeader.Appearance, rect)
				Call g.FillRectangle(gridBrush, rect)
				Call gridBrush.Dispose()
				Call g.DrawRectangle(gridPen, rect)

				'Loop AndAlso draw the day texts
				left = CacheObject.ClientLeft
				For ii As Integer = 0 To MainObject.Visibility.TotalColumnCount - 2				'Do NOT draw weekend
					rectF = New RectangleF(left, dayHeaderHeight1, columnWidth, dayHeaderHeight2)
					Call g.DrawString(startDate.ToString("ddd"), MainObject.Font, textBrush, rectF, stringFormat2)
					startDate = DateAdd(DateInterval.Day, 1, startDate)
					left += columnWidth

					'Draw a line seperator between days
					Call g.DrawLine(gridPen, rectF.Left + columnWidth, rectF.Top + 3, rectF.Left + columnWidth, rectF.Bottom - 3)
				Next

				'Draw the weekend
				Dim textWeekend As String = ""
				rectF = New RectangleF(left, dayHeaderHeight1, columnWidth, dayHeaderHeight2)
				textWeekend = startDate.ToString("ddd")
				startDate = DateAdd(DateInterval.Day, 1, startDate)
				textWeekend += "/" & startDate.ToString("ddd")
				Call g.DrawString(textWeekend, MainObject.Font, textBrush, rectF, stringFormat2)

				'Dispose of drawing objects
				Call textBrush.Dispose()
				Call gridPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawDayHeaderMonth(ByVal g As Graphics)

			Try
				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ (MainObject.Visibility.TotalRowCount \ 2))
				Dim startDate As DateTime
				Dim rectF As RectangleF
				Dim left As Integer
				Dim top As Integer
				Dim textPen As Pen = New Pen(MainObject.ColumnHeader.Appearance.ForeColor)
				Dim text As String = ""
				Dim stringformat As System.Drawing.StringFormat = New System.Drawing.StringFormat
				Dim isHilite As Boolean

				Dim textBrush As Brush = textPen.Brush
				startDate = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)

				'Setup the string format
				stringformat.Alignment = MainObject.ColumnHeader.Appearance.Alignment
				stringformat.LineAlignment = MainObject.ColumnHeader.Appearance.TextVAlign
				stringformat.Trimming = MainObject.ColumnHeader.Appearance.TextTrimming

				left = CacheObject.ClientLeft
				top = CacheObject.ClientTop

				'Loop AndAlso draw the days for 5/6 weeks
				For ii As Integer = 1 To (DaysPerWeek * (MainObject.Visibility.TotalRowCount \ 2))
					isHilite = False
					Dim cell As DayCell = CType(Me.MainObject.DayCellArray(ii - 1), DayCell)

					'Calculate the text rectangle
					rectF = New RectangleF(left, top, columnWidth, CacheObject.TextHeight)
					If (startDate.Day = 1) AndAlso (startDate.Month = 1) Then
						'Jan 1, YY
						text = startDate.ToString("MMM") & " " & startDate.Day.ToString & ", " & startDate.ToString("yy")
					ElseIf (startDate.Day = 1) Then
						'First of any other month
						text = startDate.ToString("MMM") & " " & startDate.Day.ToString
					Else
						'Just a day
						text = startDate.Day.ToString
					End If
					cell.Text = text

					'Highlight the day if necessary
					If (ii Mod DaysPerWeek = 0) Then
						'This is Sunday - (Last Column)
						isHilite = ((MainObject.Selector.Column + 1) = 6) AndAlso _
						 (MainObject.Selector.Row = (((ii \ DaysPerWeek) - 1) * 2) + 1)
					ElseIf (ii Mod DaysPerWeek = 6) Then
						'This is Saturday - (Last Column)
						isHilite = ((MainObject.Selector.Column + 1) = 6) AndAlso _
						 (MainObject.Selector.Row = ((ii \ DaysPerWeek) * 2))
					Else
						'This is NOT the last column
						isHilite = ((MainObject.Selector.Column + 1) = (ii Mod DaysPerWeek)) AndAlso _
						 ((MainObject.Selector.Row + 1) = ((ii \ DaysPerWeek) * 2) + 1)
					End If

					If isHilite Then
						'Fill the highlight color
						Call g.FillRectangle(New SolidBrush(SystemColors.Highlight), rectF.Left + 1, rectF.Top + 1, rectF.Width - 1, rectF.Height - 1)

						'Draw the highlighted text
						Call g.DrawString(text, MainObject.Font, New SolidBrush(SystemColors.HighlightText), rectF, stringformat)

					Else
						'Draw the normal text
						Call g.DrawString(text, MainObject.Font, textBrush, rectF, stringformat)

					End If

					'Draw the scroll bars for the hilighted day if there are too many appointments
					If isHilite Then
						Me.DrawMonthDayScrollBars(g, rectF, cell, stringformat.Alignment)
					End If

					'Recalculate the coordinates for the next iteration
					If (ii Mod DaysPerWeek) = 0 Then
						'If on last row then move to the next row (skip first time)
						'Sunday - Must do it this way in case the rowheight is not divisible by 2
						top -= (rowHeight \ 2)
						top += rowHeight
						left = CacheObject.ClientLeft

					ElseIf (ii Mod DaysPerWeek) <= 5 Then
						'Weekday
						left += columnWidth

					ElseIf (ii Mod DaysPerWeek) = 6 Then
						'Saturday
						top += (rowHeight \ 2)

					End If

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)
				Next

				'Dispose of drawing objects
				Call textBrush.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawMonthDayScrollBars(ByVal g As Graphics, ByVal rectF As RectangleF, ByVal cell As DayCell, ByVal textAlign As System.Drawing.StringAlignment)

			Const boxSize As Integer = 10
			Dim fillBrush As Brush = New SolidBrush(SystemColors.Window)
			Dim borderPen As Pen = New Pen(SystemColors.WindowFrame)

			Dim upRect As Rectangle
			Dim downRect As Rectangle
			Dim rect As Rectangle = New Rectangle(CType(rectF.Left, Integer), CType(rectF.Top, Integer), CType(rectF.Width, Integer), CType(rectF.Height, Integer))
			If textAlign = StringAlignment.Far Then
				'Text is right aligned so draw scroll bars on left
				downRect = New Rectangle(rect.Left + 1, rect.Top + 1, boxSize, boxSize - 1)
				upRect = New Rectangle(downRect.Right + 2, downRect.Top, downRect.Width, downRect.Height)
			Else
				'Text is left/center aligned so draw scroll bars on right
				upRect = New Rectangle(rect.Right - boxSize - 1, rect.Top + 1, boxSize, boxSize - 1)
				downRect = New Rectangle(upRect.Left - boxSize - 2, upRect.Top, upRect.Width, upRect.Height)
			End If

			cell.DownButtonRectangle = downRect
			cell.UpButtonRectangle = upRect

			'Draw Down Arrow
			g.FillRectangle(fillBrush, downRect)
			g.DrawRectangle(borderPen, downRect)
			Dim arrowLeft As Integer = downRect.Left + 2
			Dim arrowTop As Integer = downRect.Top + 3
			g.DrawLine(borderPen, arrowLeft + 0, arrowTop + 0, arrowLeft + boxSize - 4, arrowTop + 0)
			g.DrawLine(borderPen, arrowLeft + 1, arrowTop + 1, arrowLeft + boxSize - 5, arrowTop + 1)
			g.DrawLine(borderPen, arrowLeft + 2, arrowTop + 2, arrowLeft + boxSize - 6, arrowTop + 2)
			g.DrawLine(borderPen, arrowLeft + 3, arrowTop + 3, arrowLeft + boxSize - 7, arrowTop)

			'Draw Up Arrow
			g.FillRectangle(fillBrush, upRect)
			g.DrawRectangle(borderPen, upRect)
			arrowLeft = upRect.Left + 2
			Dim arrowBottom As Integer = upRect.Bottom - 3
			g.DrawLine(borderPen, arrowLeft + 0, arrowBottom - 0, arrowLeft + boxSize - 4, arrowBottom - 0)
			g.DrawLine(borderPen, arrowLeft + 1, arrowBottom - 1, arrowLeft + boxSize - 5, arrowBottom - 1)
			g.DrawLine(borderPen, arrowLeft + 2, arrowBottom - 2, arrowLeft + boxSize - 6, arrowBottom - 2)
			g.DrawLine(borderPen, arrowLeft + 3, arrowBottom - 3, arrowLeft + boxSize - 7, arrowBottom)

		End Sub

#End Region

#Region "DrawMonthFull Header"

		Private Sub DrawHeaderMonthFull(ByVal g As Graphics)

			Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
			Dim rectF As RectangleF
			Dim textBrush As Brush = New SolidBrush(MainObject.ColumnHeader.Appearance.ForeColor)
			Dim gridPen As Pen = New Pen(MainObject.Appearance.ForeColor)
			Dim startDate As DateTime = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
			Dim left As Integer
			Dim dayHeaderHeight1 As Integer = CInt((CacheObject.ClientTop / 3) * 2)
			Dim dayHeaderHeight2 As Integer = CacheObject.ClientTop - dayHeaderHeight1

			Try
				'Format the string
				Dim stringFormat As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				Dim theFont As Font = CreateFont(MainObject.ColumnHeader.Appearance, MainObject.Font.FontFamily)

				'Fill the backcolor for the text "Month YYYY"
				'dayHeaderTop = CacheObject.TextHeight * 2
				Dim rect As New Rectangle(left, 0, (columnWidth * MainObject.Visibility.TotalColumnCount), dayHeaderHeight1)
				Dim gridBrush As Brush = CreateBrush(MainObject.ColumnHeader.Appearance, rect)
				Call g.FillRectangle(gridBrush, rect)
				Call gridBrush.Dispose()
				Call g.DrawRectangle(gridPen, rect)

				'Draw the text for "Month YYYY"
				rectF = New RectangleF(left, 0, columnWidth * 7, dayHeaderHeight1)
				Dim stringFormat2 As StringFormat = CreateStringFormat(MainObject.ColumnHeader.Appearance)
				stringFormat2.Alignment = StringAlignment.Center
				Dim monthFont As Font = New Font(MainObject.Font.FontFamily, MainObject.Font.Size * 2, FontStyle.Bold, MainObject.Font.Unit)
				Call g.DrawString(MainObject.MonthSelDate.ToString("MMMM yyyy"), monthFont, textBrush, rectF, stringFormat2)
				monthFont.Dispose()

				'Fill the backcolor of the column headers
				rect = New Rectangle(left, dayHeaderHeight1, (columnWidth * MainObject.Visibility.TotalColumnCount), dayHeaderHeight2)
				gridBrush = CreateBrush(MainObject.ColumnHeader.Appearance, rect)
				Call g.FillRectangle(gridBrush, rect)
				Call gridBrush.Dispose()
				Call g.DrawRectangle(gridPen, rect)

				'Loop AndAlso draw the day texts
				left = CacheObject.ClientLeft
				For ii As Integer = 0 To MainObject.Visibility.TotalColumnCount - 1
					rectF = New RectangleF(left, dayHeaderHeight1, columnWidth, dayHeaderHeight2)
					Call g.DrawString(startDate.ToString("ddd"), MainObject.Font, textBrush, rectF, stringFormat2)
					startDate = DateAdd(DateInterval.Day, 1, startDate)
					left += columnWidth

					'Draw a line seperator between days
					Call g.DrawLine(gridPen, rectF.Left + columnWidth, rectF.Top + 3, rectF.Left + columnWidth, rectF.Bottom - 3)
				Next

				'Dispose of drawing objects
				Call textBrush.Dispose()
				Call gridPen.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub DrawDayHeaderMonthFull(ByVal g As Graphics)

			Try
				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ MainObject.Visibility.TotalRowCount)
				Dim startDate As DateTime
				Dim rectF As RectangleF
				Dim left As Integer
				Dim top As Integer
				Dim textBrush As Brush = New SolidBrush(MainObject.ColumnHeader.Appearance.ForeColor)
				Dim text As String = ""
				Dim stringformat As System.Drawing.StringFormat = New System.Drawing.StringFormat
				Dim isHilite As Boolean

				startDate = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)

				'Setup the string format
				stringformat.Alignment = MainObject.ColumnHeader.Appearance.Alignment
				stringformat.LineAlignment = MainObject.ColumnHeader.Appearance.TextVAlign
				stringformat.Trimming = MainObject.ColumnHeader.Appearance.TextTrimming

				left = CacheObject.ClientLeft
				top = CacheObject.ClientTop

				'Loop AndAlso draw the days for 5 weeks
				For ii As Integer = 1 To (DaysPerWeek * MainObject.Visibility.TotalRowCount)
					isHilite = False
					Dim cell As DayCell = CType(Me.MainObject.DayCellArray(ii - 1), DayCell)

					'Calculate the text rectangle
					rectF = New RectangleF(left, top, columnWidth, CacheObject.TextHeight)
					If (startDate.Day = 1) AndAlso (startDate.Month = 1) Then
						'Jan 1, YY
						text = startDate.ToString("MMM") & " " & startDate.Day.ToString & ", " & startDate.ToString("yy")
					ElseIf (startDate.Day = 1) Then
						'First of any other month
						text = startDate.ToString("MMM") & " " & startDate.Day.ToString
					Else
						'Just a day
						text = startDate.Day.ToString
					End If

					'Highlight the day if necessary
					isHilite = ((MainObject.Selector.Column) = ((ii - 1) Mod DaysPerWeek)) AndAlso ((MainObject.Selector.Row) = ((ii - 1) \ DaysPerWeek))

					If isHilite Then
						'Fill the highlight color
						Call g.FillRectangle(New SolidBrush(SystemColors.Highlight), rectF.Left + 1, rectF.Top + 1, rectF.Width - 1, rectF.Height - 1)

						'Draw the highlighted text
						Call g.DrawString(text, MainObject.Font, New SolidBrush(SystemColors.HighlightText), rectF, stringformat)

					Else
						'Draw the normal text
						Call g.DrawString(text, MainObject.Font, textBrush, rectF, stringformat)

					End If

					'Draw the scroll bars for the hilighted day if there are too many appointments
					If isHilite Then
						Me.DrawMonthDayScrollBars(g, rectF, cell, stringformat.Alignment)
					End If

					'Recalculate the coordinates for the next iteration
					If ((ii - 1) Mod DaysPerWeek) = (DaysPerWeek - 1) Then
						'First day of week
						top += rowHeight
						left = CacheObject.ClientLeft
					Else
						'Weekday
						left += columnWidth
					End If

					'Next Day
					startDate = DateAdd(DateInterval.Day, 1, startDate)
				Next

				'Dispose of drawing objects
				Call textBrush.Dispose()

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "SetupAppointments"

		Private Sub SetupAppointmentsDayLeftTimeTop()

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim startDateIndex As Integer
			Dim endDateIndex As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer
			Dim isEventActivity As Boolean

			Try
				startDate = CacheObject.FirstVisibleDate
				endDate = DateAdd(DateInterval.Day, CacheObject.TotalVisibleColumns - 1, CacheObject.FirstVisibleDate)

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					startDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					endDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
					timeStartSkewPixels = GetIntlInteger(Fix((CSng(appointment.StartTime.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

					'The appointment might span multiple days
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan

						Dim brokenStart As Boolean = False
						Dim brokenEnd As Boolean = False
						Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)
						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

						'Setup the structure to hold the appointment coordinates (date/time/room/provider)
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
						newRectInfo.StartTime = rectTimeStart
						newRectInfo.Length = rectTimeLength

						'If too long to draw then truncate draw length
						If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientLeft
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientLeft
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientLeft
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientLeft
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientRight
							End If
						End If

						If Not isEventActivity Then
							If (timeEndCor - timeStartCor) > 0 Then							'If off screen then do not draw
								'Draw the appointment rectangle
								rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + (startDateIndex * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
								newRectInfo.Rect = rectangle
							End If
						End If

						newRectInfo.BrokenStart = brokenStart
						newRectInfo.BrokenEnd = brokenEnd

						'Next day for next loop
						startDateIndex += 1
					Next					'DaySpan
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayTopTimeLeft()

			Dim dateStart As DateTime
			Dim dateEnd As DateTime
			Dim dateStartIndex As Integer
			Dim dateEndIndex As Integer
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer
			Dim isEventActivity As Boolean

			Try
				dateStart = CacheObject.FirstVisibleDate
				dateEnd = DateAdd(DateInterval.Day, CacheObject.TotalVisibleColumns - 1, CacheObject.FirstVisibleDate)

				'Loop through the appointments AndAlso paint what need be
				For Each appointment As Gravitybox.Objects.Appointment In Me.AppointmentCollection

					'If appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					dateStartIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					dateEndIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					'The appointment might span multiple days
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan

						Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

						'Setup the structure to hold the appointment coordinates (date/time/room/provider)
						Dim brokenStart As Boolean = False
						Dim brokenEnd As Boolean = False
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
						newRectInfo.StartTime = rectTimeStart
						newRectInfo.Length = rectTimeLength

						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

						'If too long to draw then truncate draw length
						If Not MainObject.Visibility.IsPrinting AndAlso DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientTop
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientTop
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientTop
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientTop
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientBottom
							End If
						End If

						If isEventActivity And (ii = 1) Then
							If appointment.Visible Then
								appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate)
								Dim itemTop As Integer = EventHeaderTop + EventHeader.TopBuffer + EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (EventHeader.EventHeaderBuffer * 2)))
								Dim itemLeft As Integer = CacheObject.ClientLeft + (dateStartIndex * CacheObject.ColumnWidth) + EventHeader.EventHeaderBuffer
								Dim itemWidth As Integer = (CacheObject.ColumnWidth * appointment.DaySpan) - (EventHeader.EventHeaderBuffer * 2)
								If itemLeft + itemWidth >= CacheObject.ClientLeft Then
									rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
									newRectInfo.Rect = rectangle
								End If
							End If
						ElseIf Not isEventActivity Then
							If (timeEndCor - timeStartCor) > 0 Then							 'If off screen then do not draw
								'Draw the appointment rectangle
								Dim width As Integer = CacheObject.ColumnWidth
								If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
								rectangle = New Rectangle(CacheObject.ClientLeft + (dateStartIndex * CacheObject.ColumnWidth), timeStartCor, width, timeEndCor - timeStartCor)
								If dateStartIndex >= 0 Then newRectInfo.Rect = rectangle
							End If
						End If

						newRectInfo.BrokenStart = brokenStart
						newRectInfo.BrokenEnd = brokenEnd

						'Next day for next loop
						dateStartIndex += 1
					Next
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsRoomLeftTimeTop()

			Dim displayStartRoom As Integer
			Dim displayEndRoom As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				displayStartRoom = CacheObject.FirstVisibleRoom
				displayEndRoom = displayStartRoom + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent
					roomIndex = MainObject.ResolveRoom(appointment.Room)

					'Calculate the column/row indexes
					rectTimeStart = appointment.StartTime
					rectTimeLength = appointment.Length
					rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
					timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
					timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

					'Setup the structure to hold the appointment coordinates (date/time/room/provider)
					Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
					newRectInfo.StartRoom = roomIndex
					newRectInfo.StartTime = rectTimeStart
					newRectInfo.Length = rectTimeLength

					'If too long to draw then truncate draw length
					If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
						rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
					End If

					'Calculate the top coordinate
					If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
						brokenStart = True
						timeStartCor = CacheObject.ClientLeft
					Else
						timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
						timeStartCor += timeStartSkewPixels
						timeStartCor += CacheObject.ClientLeft
						If timeStartCor < 0 Then timeStartCor = 0
					End If

					'Calculate the bottom coordinate
					If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
						timeEndCor = CacheObject.ClientLeft
					Else
						timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
						timeEndCor += timeEndSkewPixels
						timeEndCor += CacheObject.ClientLeft
						If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
							brokenEnd = True
							timeEndCor = CacheObject.ClientRight
						End If
					End If

					If Not isEventActivity Then
						If (timeEndCor - timeStartCor) > 0 Then						'If off screen then do not draw
							Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
							If (CacheObject.FirstVisibleRow <= visibleRoomIndex) AndAlso (visibleRoomIndex <= CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows) Then
								'Draw the appointment rectangle
								rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + ((visibleRoomIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
								newRectInfo.Rect = rectangle
							End If
						End If						'Appointment in date range
					End If

					newRectInfo.BrokenStart = brokenStart
					newRectInfo.BrokenEnd = brokenEnd

				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsRoomTopTimeLeft()

			Dim DisplayStartRoom As Integer
			Dim DisplayEndRoom As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartRoom = CacheObject.FirstVisibleRoom
				DisplayEndRoom = DisplayStartRoom + CacheObject.TotalVisibleColumns

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					roomIndex = MainObject.ResolveRoom(appointment.Room)

					'Calculate the column/row indexes
					rectTimeStart = appointment.StartTime
					rectTimeLength = appointment.Length
					rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
					timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
					timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

					'Setup the structure to hold the appointment coordinates (date/time/room/provider)
					Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
					newRectInfo.StartRoom = MainObject.ResolveRoom(appointment.Room)
					newRectInfo.StartTime = rectTimeStart
					newRectInfo.Length = rectTimeLength

					'If too long to draw then truncate draw length
					If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
						rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
					End If

					'Calculate the top coordinate
					If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
						brokenStart = True
						timeStartCor = CacheObject.ClientTop
					Else
						timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
						timeStartCor += timeStartSkewPixels
						timeStartCor += CacheObject.ClientTop
						If timeStartCor < 0 Then timeStartCor = 0
					End If

					'Calculate the bottom coordinate
					If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
						timeEndCor = CacheObject.ClientTop
					Else
						timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
						timeEndCor += timeEndSkewPixels
						timeEndCor += CacheObject.ClientTop
						If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
							brokenEnd = True
							timeEndCor = CacheObject.ClientBottom
						End If
					End If

					If isEventActivity Then
						appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate, newRectInfo.StartRoom, MainObject.RoomCollection.VisibleCount)
						Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
						Dim itemLeft As Integer = CacheObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(appointment.Room) - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
						Dim itemWidth As Integer = (CacheObject.ColumnWidth) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
						If itemLeft + itemWidth >= CacheObject.ClientLeft Then
							rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
							newRectInfo.Rect = rectangle
						End If
					Else
						If (timeEndCor - timeStartCor) > 0 Then						'If off screen then do not draw
							Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
							If (CacheObject.FirstVisibleColumn <= visibleRoomIndex) AndAlso (visibleRoomIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
								'Draw the appointment rectangle
								Dim width As Integer = CacheObject.ColumnWidth
								If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
								rectangle = New Rectangle(CacheObject.ClientLeft + ((visibleRoomIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), timeStartCor, width, timeEndCor - timeStartCor)
								newRectInfo.Rect = rectangle
							End If
						End If
					End If

					newRectInfo.BrokenStart = brokenStart
					newRectInfo.BrokenEnd = brokenEnd

				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayLeftRoomTop()

			Dim DisplayStartRoom As Integer
			Dim DisplayEndRoom As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim daySpan As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartRoom = CacheObject.FirstVisibleRoom
				DisplayEndRoom = DisplayStartRoom + CacheObject.TotalVisibleColumns

				'Loop through the appointments and paint what need be
				For Each appointment In Me.AppointmentCollection

					'Calculate the column/row indexes
					roomIndex = MainObject.ResolveRoom(appointment.Room)
					'If (CacheObject.FirstVisibleColumn <= roomIndex) AndAlso (roomIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
					If MainObject.RoomCollection.IsVisible(roomIndex) Then

						daySpan = appointment.DaySpan
						For ii As Integer = 1 To daySpan
							dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate)) + (ii - 1)
							dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate)) + (ii - 1)

							Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
							newRectInfo.StartRoom = roomIndex
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength

							If Not isEventActivity Then
								'Draw the appointment rectangle
								Dim width As Integer = CacheObject.ColumnWidth
								If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
								Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
								rectangle = New Rectangle(CacheObject.ClientLeft + ((visibleRoomIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), CacheObject.ClientTop + (dateStart * CacheObject.RowHeight), width, CacheObject.RowHeight)
								newRectInfo.Rect = rectangle
							End If

						Next						'Day Span
					End If					'Appointment in room range

				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayLeftResourceTop()

			Dim DisplayStartResource As Integer
			Dim DisplayEndResource As Integer
			Dim appointment As Appointment
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim resource As Resource
			Dim daySpan As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartResource = CacheObject.FirstVisibleResource
				DisplayEndResource = DisplayStartResource + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					'If Not (appointment.IsActivity OrElse appointment.IsEvent) AndAlso appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					'Calculate the column/row indexes
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan
						For Each resource In appointment.ResourceList
							Dim resourceIndex As Integer = MainObject.ResourceCollection.IndexOfVisible(resource)
							dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate)) + (ii - 1)
							dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate)) + (ii - 1)

							Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

							'Setup the structure to hold the appointment coordinates (date/time/room/resource)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
							newRectInfo.StartResource = resourceIndex
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength

							'Draw the appointment rectangle
							Dim width As Integer = CacheObject.ColumnWidth
							If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
							rectangle = New Rectangle(CacheObject.ClientLeft + ((resourceIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), CacheObject.ClientTop + (dateStart * CacheObject.RowHeight), width, CacheObject.RowHeight)
							newRectInfo.Rect = rectangle

						Next
					Next
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayTopRoomLeft()

			Dim DisplayStartRoom As Integer
			Dim DisplayEndRoom As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle

			Try
				DisplayStartRoom = CacheObject.FirstVisibleRoom
				DisplayEndRoom = DisplayStartRoom + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					'If appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					'Calculate the column/row indexes
					roomIndex = MainObject.ResolveRoom(appointment.Room)
					If MainObject.RoomCollection.IsVisible(roomIndex) Then

						If (appointment.IsActivity OrElse appointment.IsEvent) Then
							dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
							dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							If appointment.IsEvent Then
								newRectInfo.StartDate = appointment.StartDate
								newRectInfo.StartRoom = roomIndex
								newRectInfo.StartTime = PivotTime
								newRectInfo.Length = MinutesPerDay
							Else
								newRectInfo.StartDate = appointment.StartDate
								newRectInfo.StartRoom = roomIndex
								newRectInfo.StartTime = appointment.StartTime
								newRectInfo.Length = appointment.Length
							End If

							appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate)
							Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
							Dim itemLeft As Integer = CacheObject.ClientLeft + (dateStart * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
							Dim itemWidth As Integer = (CacheObject.ColumnWidth * appointment.DaySpan) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
							If itemLeft + itemWidth >= CacheObject.ClientLeft Then
								rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
								newRectInfo.Rect = rectangle
							End If

						Else
							For ii As Integer = 1 To appointment.DaySpan
								dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate)) + (ii - 1)
								dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate)) + (ii - 1)

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
								newRectInfo.StartRoom = roomIndex

								'Draw the appointment rectangle
								Dim width As Integer = CacheObject.ColumnWidth
								If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
								Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
								rectangle = New Rectangle(CacheObject.ClientLeft + (dateStart * CacheObject.ColumnWidth), CacheObject.ClientTop + ((visibleRoomIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), width, CacheObject.RowHeight)
								newRectInfo.Rect = rectangle

							Next							'Day Span
						End If
					End If					'Appointment in room range 
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayLeftProviderTop()

			Dim DisplayStartProvider As Integer
			Dim DisplayEndProvider As Integer
			Dim appointment As Appointment
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim provider As Provider
			Dim daySpan As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartProvider = CacheObject.FirstVisibleProvider
				DisplayEndProvider = DisplayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					'If Not (appointment.IsActivity OrElse appointment.IsEvent) AndAlso appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					'Calculate the column/row indexes
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan
						For Each provider In appointment.ProviderList
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate)) + (ii - 1)
							dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate)) + (ii - 1)

							Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
							newRectInfo.StartProvider = providerIndex
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength

							'Draw the appointment rectangle
							Dim width As Integer = CacheObject.ColumnWidth
							If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
							rectangle = New Rectangle(CacheObject.ClientLeft + ((providerIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), CacheObject.ClientTop + (dateStart * CacheObject.RowHeight), width, CacheObject.RowHeight)
							newRectInfo.Rect = rectangle

						Next
					Next
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayTopProviderLeft()

			Dim DisplayStartProvider As Integer
			Dim DisplayEndProvider As Integer
			Dim appointment As Appointment
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim provider As Provider
			Dim isEventActivity As Boolean
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer

			Try
				DisplayStartProvider = CacheObject.FirstVisibleProvider
				DisplayEndProvider = DisplayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					'Calculate the column/row indexes
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan
						For Each provider In appointment.ProviderList
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							If MainObject.ProviderCollection.Contains(providerIndex) Then

								dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate)) + (ii - 1)
								dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate)) + (ii - 1)

								Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								If isEventActivity And (ii = 1) Then 'Only on first iteration
									If appointment.Visible Then
										appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate)
										Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
										Dim itemLeft As Integer = CacheObject.ClientLeft + (dateStart * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
										Dim itemWidth As Integer = (CacheObject.ColumnWidth * appointment.DaySpan) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
										If itemLeft + itemWidth >= CacheObject.ClientLeft Then
											rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
											newRectInfo.Rect = rectangle
										End If
									End If
								ElseIf Not isEventActivity Then
									'Draw the appointment rectangle
									Dim width As Integer = CacheObject.ColumnWidth
									If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
									rectangle = New Rectangle(CacheObject.ClientLeft + (dateStart * CacheObject.ColumnWidth), CacheObject.ClientTop + ((providerIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), width, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If

							End If

						Next						'Each Provider
					Next					'Day Span
				Next				'Each Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsRoomLeftProviderTop()

			Dim displayStartRoom As Integer
			Dim displayEndRoom As Integer
			Dim displayStartProvider As Integer
			Dim displayEndProvider As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim provider As Provider
			Dim isEventActivity As Boolean
			Dim rectangle As Rectangle

			Try
				displayStartRoom = CacheObject.FirstVisibleRoom
				displayEndRoom = displayStartRoom + CacheObject.TotalVisibleRows
				displayStartProvider = MainObject.Visibility.FirstVisibleProvider
				displayEndProvider = displayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection
					isEventActivity = (appointment.IsActivity OrElse appointment.IsEvent)

					'Calculate the column/row indexes
					roomIndex = MainObject.ResolveRoom(appointment.Room)
					For Each provider In appointment.ProviderList
						Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
						'If (CacheObject.FirstVisibleColumn <= providerIndex) AndAlso (providerIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
						If MainObject.ProviderCollection.Contains(provider) Then
							'If (CacheObject.FirstVisibleRow <= roomIndex) AndAlso (roomIndex <= CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows) Then
							If MainObject.RoomCollection.IsVisible(roomIndex) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartRoom = roomIndex
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = PivotTime
								newRectInfo.Length = MinutesPerDay
								If isEventActivity Then
									appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate)
									Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
									Dim itemLeft As Integer = CacheObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(provider) - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
									Dim itemWidth As Integer = (CacheObject.ColumnWidth) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
									If itemLeft + itemWidth >= CacheObject.ClientLeft Then
										rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
										newRectInfo.Rect = rectangle
									End If
								Else
									'Draw the appointment rectangle
									Dim width As Integer = CacheObject.ColumnWidth
									If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
									Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
									rectangle = New Rectangle(CacheObject.ClientLeft + ((providerIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), CacheObject.ClientTop + ((visibleRoomIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), width, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If

							End If
						End If				 'Appointment in provider range

					Next
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsRoomTopProviderLeft()

			Dim displayStartRoom As Integer
			Dim displayEndRoom As Integer
			Dim displayStartProvider As Integer
			Dim displayEndProvider As Integer
			Dim appointment As Appointment
			Dim roomIndex As Integer
			Dim provider As Provider
			Dim isEventActivity As Boolean
			Dim rectangle As Rectangle

			Try
				displayStartRoom = CacheObject.FirstVisibleRoom
				displayEndRoom = displayStartRoom + CacheObject.TotalVisibleColumns
				displayStartProvider = CacheObject.FirstVisibleProvider
				displayEndProvider = displayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection
					isEventActivity = (appointment.IsActivity OrElse appointment.IsEvent)

					'Calculate the column/row indexes
					roomIndex = MainObject.ResolveRoom(appointment.Room)

					For Each provider In appointment.ProviderList
						'If (CacheObject.FirstVisibleColumn <= roomIndex) AndAlso (roomIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
						If MainObject.RoomCollection.IsVisible(roomIndex) Then
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							'If (CacheObject.FirstVisibleRow <= providerIndex) AndAlso (providerIndex <= CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows) Then
							If MainObject.ProviderCollection.Contains(provider) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartRoom = roomIndex
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = PivotTime
								newRectInfo.Length = MinutesPerDay
								If isEventActivity Then
									appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate, newRectInfo.StartRoom, MainObject.RoomCollection.VisibleCount)
									Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
									Dim itemLeft As Integer = CacheObject.ClientLeft + ((MainObject.RoomCollection.IndexOfVisible(appointment.Room) - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
									Dim itemWidth As Integer = (CacheObject.ColumnWidth) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
									If itemLeft + itemWidth >= CacheObject.ClientLeft Then
										rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
										newRectInfo.Rect = rectangle
									End If
								Else
									'Draw the appointment rectangle
									Dim width As Integer = CacheObject.ColumnWidth
									If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
									Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
									rectangle = New Rectangle(CacheObject.ClientLeft + ((visibleRoomIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), CacheObject.ClientTop + ((providerIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), width, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If

							End If
						End If						 'Appointment in room range
					Next
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsProviderLeftTimeTop()

			Dim displayStartProvider As Integer
			Dim displayEndProvider As Integer
			Dim appointment As Appointment
			Dim provider As Provider
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer

			Try
				displayStartProvider = CacheObject.FirstVisibleProvider
				displayEndProvider = displayStartProvider + CacheObject.TotalVisibleColumns

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					If (appointment.IsActivity OrElse appointment.IsEvent) Then
						'Setup the structure to hold the appointment coordinates (date/time/room/provider)
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						If appointment.IsEvent Then
							newRectInfo.StartTime = PivotTime
							newRectInfo.Length = MinutesPerDay
						Else
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength
						End If

					Else

						rectTimeStart = appointment.StartTime
						rectTimeLength = appointment.Length
						rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

						'If too long to draw then truncate draw length
						If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientLeft
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientLeft
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientLeft
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientLeft
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientRight
							End If
						End If

						For Each provider In appointment.ProviderList
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							If (CacheObject.FirstVisibleRow <= providerIndex) AndAlso (providerIndex <= CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
								If (timeEndCor - timeStartCor) > 0 Then								'If off screen then do not draw
									'Draw the appointment rectangle
									rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + ((providerIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If

								newRectInfo.BrokenStart = brokenStart
								newRectInfo.BrokenEnd = brokenEnd

							End If							'Appointment in date range

						Next
					End If					'is event/activity
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsProviderTopTimeLeft()

			Dim DisplayStartProvider As Integer
			Dim DisplayEndProvider As Integer
			Dim appointment As Appointment
			Dim provider As Provider
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartProvider = CacheObject.FirstVisibleProvider
				DisplayEndProvider = DisplayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					If isEventActivity Then
						Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
						For Each provider In appointment.ProviderList
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate, providerIndex, MainObject.ProviderCollection.VisibleCount)
							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartTime = PivotTime
							newRectInfo.Length = MinutesPerDay
							newRectInfo.StartProvider = providerIndex

							Dim itemLeft As Integer = CacheObject.ClientLeft + ((MainObject.ProviderCollection.IndexOfVisible(provider) - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
							Dim itemWidth As Integer = (CacheObject.ColumnWidth) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
							If itemLeft + itemWidth >= CacheObject.ClientLeft Then
								rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
								newRectInfo.Rect = rectangle
							End If
						Next					'Each Provider

					Else
						'Calculate the column/row indexes
						rectTimeStart = appointment.StartTime
						rectTimeLength = appointment.Length
						'Dim MinLeftInDay As Integer = MinutesLeftPerDay(rectTimeStart)
						'If rectTimeLength > MinLeftInDay Then rectTimeLength = MinLeftInDay

						rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

						'If too long to draw then truncate draw length
						If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientTop
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientTop
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientTop
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientTop
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientBottom
							End If
						End If

						For Each provider In appointment.ProviderList
							Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
							'If (CacheObject.FirstVisibleColumn <= providerIndex) AndAlso (providerIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
							If MainObject.ProviderCollection.Contains(providerIndex) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
								If (timeEndCor - timeStartCor) > 0 Then								 'If off screen then do not draw
									'Draw the appointment rectangle
									Dim width As Integer = CacheObject.ColumnWidth
									If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
									rectangle = New Rectangle(CacheObject.ClientLeft + ((providerIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), timeStartCor, width, timeEndCor - timeStartCor)
									newRectInfo.Rect = rectangle
								End If

							End If							 'Appointment in provider range
						Next
					End If					'is event/activity
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsProviderTopDayTimeLeft()

			Dim DisplayStartProvider As Integer
			Dim DisplayEndProvider As Integer
			Dim appointment As Appointment
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim provider As Provider
			Dim daySpan As Integer
			Dim isEventActivity As Boolean
			Dim startCor As Integer
			Dim endCor As Integer

			Try
				DisplayStartProvider = CacheObject.FirstVisibleProvider
				DisplayEndProvider = DisplayStartProvider + CacheObject.TotalVisibleRows

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					'Calculate the column/row indexes
					daySpan = appointment.DaySpan
					For Each provider In appointment.ProviderList
						Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
						dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
						dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))

						'Setup the structure to hold the appointment coordinates (date/time/provider)
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = appointment.StartDate
						newRectInfo.StartProvider = providerIndex
						newRectInfo.StartTime = appointment.StartTime
						newRectInfo.Length = appointment.Length

						startCor = (MainObject.Visibility.GetRowColFromDate(appointment.StartDate) - CacheObject.FirstVisibleRow) * CacheObject.RowHeight
						startCor += CInt((DateDiff(DateInterval.Minute, PivotTime, appointment.StartTime) / MainObject.TimeIncrementValue) * CacheObject.RowHeight)
						startCor += CacheObject.ClientTop
						endCor = CInt((appointment.Length / CacheObject.TimeIncrement) * CacheObject.RowHeight)
						If startCor < CacheObject.ClientTop Then
							endCor += startCor
							endCor -= CacheObject.ClientTop
							startCor = CacheObject.ClientTop
						End If
						If (startCor + endCor) > CacheObject.ClientBottom Then endCor = CacheObject.ClientBottom - startCor

						If isEventActivity Then
							'TODO
						Else
							'Draw the appointment rectangle
							Dim width As Integer = CacheObject.ColumnWidth
							If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
							rectangle = New Rectangle(CacheObject.ClientLeft + ((providerIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), startCor, width, endCor)
							newRectInfo.Rect = rectangle
						End If

					Next					'Each Provider
				Next				'Each Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsRoomTopDayTimeLeft()

			Dim DisplayStartRoom As Integer
			Dim DisplayEndRoom As Integer
			Dim appointment As Appointment
			Dim dateStart As Integer
			Dim dateEnd As Integer
			Dim rectangle As Rectangle
			Dim daySpan As Integer
			Dim isEventActivity As Boolean
			Dim startCor As Integer
			Dim endCor As Integer
			'Dim timeStartSkewPixels As Integer
			'Dim timeEndSkewPixels As Integer

			Try
				DisplayStartRoom = CacheObject.FirstVisibleRoom
				DisplayEndRoom = DisplayStartRoom + CacheObject.TotalVisibleColumns

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection
					If Not (appointment.Room Is Nothing) Then

						Dim brokenStart As Boolean = False
						Dim brokenEnd As Boolean = False

						isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

						'Calculate the column/row indexes
						daySpan = appointment.DaySpan
						Dim roomIndex As Integer = MainObject.ResolveRoom(appointment.Room)
						dateStart = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
						dateEnd = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))

						'Setup the structure to hold the appointment coordinates (date/time/room)
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = appointment.StartDate
						newRectInfo.StartRoom = roomIndex
						newRectInfo.StartTime = appointment.StartTime
						newRectInfo.Length = appointment.Length

						startCor = (MainObject.Visibility.GetRowColFromDate(appointment.StartDate) - CacheObject.FirstVisibleRow) * CacheObject.RowHeight
						startCor += CInt((DateDiff(DateInterval.Minute, PivotTime, appointment.StartTime) / MainObject.TimeIncrementValue) * CacheObject.RowHeight)
						startCor += CacheObject.ClientTop
						endCor = CInt((appointment.Length / CacheObject.TimeIncrement) * CacheObject.RowHeight)
						If Not MainObject.Visibility.IsPrinting AndAlso (startCor < CacheObject.ClientTop) Then
							brokenStart = True
							endCor += startCor
							endCor -= CacheObject.ClientTop
							startCor = CacheObject.ClientTop
						End If
						If Not MainObject.Visibility.IsPrinting AndAlso ((startCor + endCor) > CacheObject.ClientBottom) Then
							brokenEnd = True
							endCor = CacheObject.ClientBottom - startCor
						End If

						If Not isEventActivity Then
							'Draw the appointment rectangle
							Dim width As Integer = CacheObject.ColumnWidth
							If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then
								width -= MainObject.AppointmentSpace
							End If
							Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomIndex)
							rectangle = New Rectangle(CacheObject.ClientLeft + ((visibleRoomIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), startCor, width, endCor)
							newRectInfo.Rect = rectangle
						End If

						newRectInfo.BrokenStart = brokenStart
						newRectInfo.BrokenEnd = brokenEnd

					End If					'Room Exists
				Next				'Each Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsMonth()

			Try
				Dim dayArray(0) As Integer				'Keep track of number of appointments per day
				Dim appointment As Appointment
				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ (MainObject.Visibility.TotalRowCount \ 2))
				Dim firstDate As DateTime
				Dim lastDate As DateTime
				Dim cellIndex As Integer				'[0..34] range of visible days
				Dim cellTop As Integer
				Dim cellBottom As Integer
				Dim cellHeight As Integer
				Dim rectangle As Rectangle
				Dim row As Integer
				Dim column As Integer
				Dim itemTop As Integer
				Dim itemHeight As Integer
				Dim rectTimeStart As DateTime
				Dim rectTimeEnd As DateTime
				Dim rectTimeLength As Integer
				Dim daySpan As Integer

				ReDim dayArray(((MainObject.Visibility.TotalRowCount \ 2) * DaysPerWeek))

				'Initialize all array elements to 1
				For ii As Integer = 0 To UBound(dayArray) - 1
					dayArray(ii) = 1
				Next

				'Subtract off the last month's days displayed
				firstDate = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
				lastDate = DateAdd(DateInterval.Day, 35, firstDate)

				For Each appointment In Me.AppointmentCollection
					'If the appointment is in the visible range
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan

						'The index from the first visible date
						cellIndex = GetIntlInteger(DateDiff(DateInterval.Day, firstDate, appointment.StartDate)) + ii						'- 1

						'Calculate the col/row [0=Sunday, 1=Monday, 6=Saturday]
						If (cellIndex Mod DaysPerWeek) = 0 Then
							'If this is Sunday
							row = (cellIndex \ DaysPerWeek)
							column = 6
							cellTop = CacheObject.ClientTop + ((row - 1) * rowHeight) + (rowHeight \ 2)
							cellHeight = rowHeight \ 2
						ElseIf (cellIndex Mod DaysPerWeek) = 6 Then
							'If this is Saturday
							row = (cellIndex \ DaysPerWeek) + 1
							column = 6
							cellTop = CacheObject.ClientTop + ((row - 1) * rowHeight)
							cellHeight = rowHeight \ 2
						Else
							'Monday-Friday
							row = (cellIndex \ DaysPerWeek) + 1
							column = (cellIndex Mod DaysPerWeek)
							cellTop = CacheObject.ClientTop + (row - 1) * rowHeight
							cellHeight = rowHeight
						End If

						Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

						'Create the rectangle information
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = DateAdd(DateInterval.Day, cellIndex, firstDate)
						newRectInfo.StartTime = rectTimeStart
						newRectInfo.Length = rectTimeLength

						If (0 < cellIndex) And (cellIndex < dayArray.Length) Then
							itemHeight = CacheObject.TextHeight + (TextMargin * 2)
							cellBottom = cellTop + cellHeight
							itemTop = cellTop + (dayArray(cellIndex - 1) * (CacheObject.TextHeight + TextMargin + (appointment.Appearance.BorderWidth * 2)))

							Dim cell As DayCell = Me.MainObject.DayCellArray(cellIndex - 1)
							itemTop -= cell.ScrollValue * itemHeight

							If itemTop >= cellBottom Then
								itemHeight = 0
							ElseIf itemTop + itemHeight > cellBottom Then
								itemHeight = cellBottom - itemTop
							ElseIf itemTop < cellTop + CacheObject.TextHeight Then
								itemHeight = (itemTop + itemHeight) - (cellTop + CacheObject.TextHeight)
								itemTop = cellTop + CacheObject.TextHeight
							End If

							If itemHeight > 0 Then
								'Calculate the appointment's rectangle
								rectangle = New Rectangle(CacheObject.ClientLeft + ((column - 1) * columnWidth), itemTop, columnWidth, itemHeight)
								newRectInfo.Rect = rectangle
							End If

							'Increment the cells number of appointments
							dayArray(cellIndex - 1) += 1

						End If

					Next

				Next

				'Reset the max value of the day cell elements
				Dim index As Integer = 0
				For Each cell As DayCell In Me.MainObject.DayCellArray
					If index < dayArray.Length Then
						cell.MaxScroll = dayArray(index) - 2
					Else
						cell.MaxScroll = 0
					End If
					index += 1
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsMonthFull()

			Try
				Dim dayArray(0) As Integer				'Keep track of number of appointments per day
				Dim appointment As Appointment
				Dim columnWidth As Integer = ((CacheObject.ClientWidth - 1) \ MainObject.Visibility.TotalColumnCount)
				Dim rowHeight As Integer = ((CacheObject.ClientHeight - 1) \ MainObject.Visibility.TotalRowCount)
				Dim firstDate As DateTime
				Dim lastDate As DateTime
				Dim cellIndex As Integer				'[0..34] range of visible days
				Dim cellTop As Integer
				Dim cellBottom As Integer
				Dim cellHeight As Integer
				Dim rectangle As Rectangle
				Dim row As Integer
				Dim column As Integer
				Dim itemTop As Integer
				Dim itemHeight As Integer
				Dim rectTimeStart As DateTime
				Dim rectTimeEnd As DateTime
				Dim rectTimeLength As Integer
				Dim daySpan As Integer

				ReDim dayArray(MainObject.Visibility.TotalRowCount * DaysPerWeek)

				'Initialize all array elements to 1
				For ii As Integer = 0 To UBound(dayArray) - 1
					dayArray(ii) = 1
				Next

				'Subtract off the last month's days displayed
				firstDate = GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
				lastDate = DateAdd(DateInterval.Day, 35, firstDate)

				For Each appointment In Me.AppointmentCollection
					'If the appointment is in the visible range
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan

						'The index from the first visible date
						cellIndex = GetIntlInteger(DateDiff(DateInterval.Day, firstDate, appointment.StartDate)) + ii						'- 1

						row = ((cellIndex - 1) \ DaysPerWeek) + 1
						column = ((cellIndex - 1) Mod DaysPerWeek)
						cellTop = CacheObject.ClientTop + (row - 1) * rowHeight
						cellHeight = rowHeight

						Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

						'Create the rectangle information
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = DateAdd(DateInterval.Day, cellIndex, firstDate)
						newRectInfo.StartTime = rectTimeStart
						newRectInfo.Length = rectTimeLength

						If (1 <= cellIndex) AndAlso (cellIndex <= dayArray.GetUpperBound(0)) Then
							itemHeight = CacheObject.TextHeight + (TextMargin * 2)
							cellBottom = cellTop + cellHeight
							itemTop = cellTop + (dayArray(cellIndex - 1) * (CacheObject.TextHeight + TextMargin + (appointment.Appearance.BorderWidth * 2)))

							Dim cell As DayCell = Me.MainObject.DayCellArray(cellIndex - 1)
							itemTop -= cell.ScrollValue * itemHeight

							If itemTop >= cellBottom Then
								itemHeight = 0
							ElseIf itemTop + itemHeight > cellBottom Then
								itemHeight = cellBottom - itemTop
							ElseIf itemTop < cellTop + CacheObject.TextHeight Then
								itemHeight = (itemTop + itemHeight) - (cellTop + CacheObject.TextHeight)
								itemTop = cellTop + CacheObject.TextHeight
							End If

							If itemHeight > 0 Then
								'Calculate the appointment's rectangle
								rectangle = New Rectangle(CacheObject.ClientLeft + (column * columnWidth), itemTop, columnWidth, itemHeight)
								newRectInfo.Rect = rectangle
							End If

							'Increment the cells number of appointments
							dayArray(cellIndex - 1) += 1

						End If

					Next
				Next

				'Reset the max value of the day cell elements
				Dim index As Integer = 0
				For Each cell As DayCell In Me.MainObject.DayCellArray
					If index < dayArray.Length Then
						cell.MaxScroll = dayArray(index) - 2
					Else
						cell.MaxScroll = 0
					End If
					index += 1
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsWeek()

			Try
				Dim dayArray(7) As Integer				'Keep track of number of appointments per day
				Dim appointment As Appointment
				Dim columnWidth As Integer = MainObject.ColumnHeader.Size
				Dim rowHeight As Integer = MainObject.RowHeader.Size
				Dim cellIndex As Integer				'[0..6] range of visible days
				Dim cellBottom As Integer
				Dim rectangle As Rectangle
				Dim itemTop As Integer
				Dim itemHeight As Integer
				Dim rectTimeStart As DateTime
				Dim rectTimeEnd As DateTime
				Dim rectTimeLength As Integer
				Dim daySpan As Integer

				'Initialize all array elements to 1
				For ii As Integer = 0 To UBound(dayArray) - 1
					dayArray(ii) = 1
				Next

				For Each appointment In Me.AppointmentCollection
					'If the appointment is in the visible range
					daySpan = appointment.DaySpan
					For ii As Integer = 0 To daySpan - 1

						'The index from the first visible date
						cellIndex = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, appointment.StartDate)) + ii

						Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

						'Create the rectangle information
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						newRectInfo.StartDate = DateAdd(DateInterval.Day, cellIndex, MainObject.MinDate)
						newRectInfo.StartTime = rectTimeStart
						newRectInfo.Length = rectTimeLength
						newRectInfo.Rect = New System.Drawing.Rectangle

						If (0 <= cellIndex) AndAlso (cellIndex < DaysPerWeek) Then
							Dim clientRect As System.Drawing.Rectangle = CType(MainObject.WeekClientRectangles(cellIndex), Rectangle)

							itemHeight = CacheObject.TextHeight + (TextMargin * 2)
							cellBottom = clientRect.Top + clientRect.Height
							itemTop = clientRect.Top + (dayArray(cellIndex) * (itemHeight + TextMargin))

							If itemTop >= cellBottom Then
								itemHeight = 0
							ElseIf itemTop + itemHeight > cellBottom Then
								itemHeight = cellBottom - itemTop
							End If

							If itemHeight > 0 Then
								'Calculate the appointment's rectangle
								rectangle = New Rectangle(clientRect.Left, itemTop, columnWidth, itemHeight)
								newRectInfo.Rect = rectangle

								'Increment the number of appointments in this cell
								dayArray(cellIndex) += 1
							End If

						End If						'CellIndex in range
					Next					'DaySpan
				Next				'Each Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayRoomLeftTimeTop()

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim startDateIndex As Integer
			Dim endDateIndex As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim rowIndex As Integer
			Dim roomindex As Integer
			Dim skew As Integer
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer
			Dim isEventActivity As Boolean

			Try
				'There are no rooms present. Nothing to do
				If MainObject.RoomCollection.VisibleCount = 0 Then Return

				startDate = CacheObject.FirstVisibleDate
				endDate = DateAdd(DateInterval.Day, CacheObject.TotalVisibleRows - 1, CacheObject.FirstVisibleDate)
				If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
				Else
					skew = (MainObject.VScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
				End If

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = (appointment.IsActivity OrElse appointment.IsEvent)

					startDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					endDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
					roomindex = MainObject.ResolveRoom(appointment.Room)

					If MainObject.RoomCollection.IsVisible(roomindex) Then
						'The appointment might span multiple days
						daySpan = appointment.DaySpan
						For ii As Integer = 1 To daySpan

							Dim brokenStart As Boolean = False
							Dim brokenEnd As Boolean = False

							Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

							timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
							timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

							'Calculate the column index for this appointment
							Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomindex)
							rowIndex = (startDateIndex * MainObject.RoomCollection.VisibleCount) + visibleRoomIndex - skew

							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
							newRectInfo.StartRoom = roomindex
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength

							'If too long to draw then truncate draw length
							If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
								rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
							End If

							'Calculate the top coordinate
							If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
								brokenStart = True
								timeStartCor = CacheObject.ClientLeft
							Else
								timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
								timeStartCor += timeStartSkewPixels
								timeStartCor += CacheObject.ClientLeft
								If timeStartCor < 0 Then timeStartCor = 0
							End If

							'Calculate the bottom coordinate
							If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
								timeEndCor = CacheObject.ClientLeft
							Else
								timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
								timeEndCor += timeEndSkewPixels
								timeEndCor += CacheObject.ClientLeft
								If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
									brokenEnd = True
									timeEndCor = CacheObject.ClientRight
								End If
							End If

							If (Not isEventActivity) AndAlso (rowIndex >= 0) Then
								'Draw the appointment rectangle
								If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
								If (timeEndCor - timeStartCor) > 0 Then								'If off screen then do not draw
									rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + (rowIndex * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If
							End If

							'Next day for next loop
							startDateIndex += 1

							newRectInfo.BrokenStart = brokenStart
							newRectInfo.BrokenEnd = brokenEnd

						Next						'DaySpan
					End If					'If there is a room
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayProviderLeftTimeTop()

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim startDateIndex As Integer
			Dim endDateIndex As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim rowIndex As Integer
			Dim providerIndex As Integer
			Dim skew As Integer
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer
			Dim isEventActivity As Boolean

			Try
				'There are no providers present. Nothing to do
				If MainObject.ProviderCollection.VisibleCount = 0 Then Return

				startDate = CacheObject.FirstVisibleDate
				endDate = DateAdd(DateInterval.Day, CacheObject.TotalVisibleRows - 1, CacheObject.FirstVisibleDate)
				If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
				Else
					skew = (MainObject.VScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
				End If

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					isEventActivity = (appointment.IsActivity OrElse appointment.IsEvent)

					startDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					endDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
					'The appointment might span multiple days
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan
						For Each provider As Provider In appointment.ProviderList
							providerIndex = MainObject.ProviderCollection.IndexOf(provider)
							If MainObject.ProviderCollection.IsVisible(providerIndex) Then

								Dim brokenStart As Boolean = False
								Dim brokenEnd As Boolean = False

								Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

								timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
								timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

								'Calculate the column index for this appointment
								Dim visibleProviderIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(providerIndex)
								rowIndex = (startDateIndex * MainObject.ProviderCollection.VisibleCount) + visibleProviderIndex - skew

								'Setup the structure to hold the appointment coordinates (date/time/provider/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								'If too long to draw then truncate draw length
								If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
									rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
								End If

								'Calculate the top coordinate
								If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
									brokenStart = True
									timeStartCor = CacheObject.ClientLeft
								Else
									timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
									timeStartCor += timeStartSkewPixels
									timeStartCor += CacheObject.ClientLeft
									If timeStartCor < 0 Then timeStartCor = 0
								End If

								'Calculate the bottom coordinate
								If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
									timeEndCor = CacheObject.ClientLeft
								Else
									timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
									timeEndCor += timeEndSkewPixels
									timeEndCor += CacheObject.ClientLeft
									If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
										brokenEnd = True
										timeEndCor = CacheObject.ClientRight
									End If
								End If

								If (Not isEventActivity) AndAlso (rowIndex >= 0) Then
									'Draw the appointment rectangle
									If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
									If (timeEndCor - timeStartCor) > 0 Then								'If off screen then do not draw
										rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + (rowIndex * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
										newRectInfo.Rect = rectangle
									End If
								End If

								newRectInfo.BrokenStart = brokenStart
								newRectInfo.BrokenEnd = brokenEnd

							End If 'If there is a provider
						Next 'Provider

						'Next day for next loop
						startDateIndex += 1

					Next 'DaySpan
				Next 'Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayRoomTopTimeLeft()

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim startDateIndex As Integer
			Dim endDateIndex As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim colIndex As Integer
			Dim roomindex As Integer
			Dim skew As Integer
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer

			Try
				'There are no rooms present. Nothing to do
				If MainObject.RoomCollection.VisibleCount = 0 Then Return

				startDate = CacheObject.FirstVisibleDate
				endDate = DateAdd(DateInterval.Day, CacheObject.TotalVisibleColumns - 1, CacheObject.FirstVisibleDate)

				If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
				Else
					skew = (MainObject.HScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
				End If

				'Loop through the appointments and paint what need be
				For Each appointment In Me.AppointmentCollection

					'If appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					startDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					endDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
					roomindex = MainObject.ResolveRoom(appointment.Room)

					If MainObject.RoomCollection.IsVisible(roomindex) Then
						'The appointment might span multiple days
						daySpan = appointment.DaySpan
						For ii As Integer = 1 To daySpan

							Dim brokenStart As Boolean = False
							Dim brokenEnd As Boolean = False

							Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

							timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
							timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

							'Calculate the column index for this appointment
							Dim visibleRoomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(roomindex)
							colIndex = (startDateIndex * MainObject.RoomCollection.VisibleCount) + visibleRoomIndex - skew

							'Setup the structure to hold the appointment coordinates (date/time/room/provider)
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
							newRectInfo.StartRoom = roomindex
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength

							'If too long to draw then truncate draw length
							If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
								rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
							End If

							If (appointment.IsActivity OrElse appointment.IsEvent) Then
								appointment.EventIndex = NextHeaderIndex(newRectInfo.StartDate, newRectInfo.StartDate, newRectInfo.StartRoom, MainObject.RoomCollection.VisibleCount)
								Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
								Dim itemLeft As Integer = CacheObject.ClientLeft + (colIndex * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
								Dim itemWidth As Integer = CacheObject.ColumnWidth - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
								If itemLeft + itemWidth >= CacheObject.ClientLeft Then
									rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
									newRectInfo.Rect = rectangle
								End If

							Else
								'Calculate the top coordinate
								If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
									brokenStart = True
									timeStartCor = CacheObject.ClientTop
								Else
									timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
									timeStartCor += timeStartSkewPixels
									timeStartCor += CacheObject.ClientTop
									If timeStartCor < 0 Then timeStartCor = 0
								End If

								'Calculate the bottom coordinate
								If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
									timeEndCor = CacheObject.ClientTop
								Else
									timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
									timeEndCor += timeEndSkewPixels
									timeEndCor += CacheObject.ClientTop
									If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
										brokenEnd = True
										timeEndCor = CacheObject.ClientBottom
									End If
								End If

								If colIndex >= 0 Then
									'Draw the appointment rectangle
									If (timeEndCor - timeStartCor) > 0 Then									'If off screen then do not draw
										rectangle = New Rectangle(CacheObject.ClientLeft + (colIndex * CacheObject.ColumnWidth), timeStartCor, CacheObject.ColumnWidth, timeEndCor - timeStartCor)
										newRectInfo.Rect = rectangle
									End If
								End If

							End If

							'Next day for next loop
							startDateIndex += 1

							newRectInfo.BrokenStart = brokenStart
							newRectInfo.BrokenEnd = brokenEnd

						Next						'DaySpan
					End If					'If there is a room
					'End If 'Appointment in date range
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsDayProviderTopTimeLeft()

			Dim startDate As DateTime
			Dim endDate As DateTime
			Dim startDateIndex As Integer
			Dim endDateIndex As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim colIndex As Integer
			Dim providerIndex As Integer
			Dim skew As Integer
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim daySpan As Integer

			Try
				'There are no providers present. Nothing to do
				If MainObject.ProviderCollection.VisibleCount = 0 Then Return

				startDate = CacheObject.FirstVisibleDate
				endDate = DateAdd(DateInterval.Day, CacheObject.TotalVisibleColumns - 1, CacheObject.FirstVisibleDate)

				If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
					skew = ((MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
				Else
					skew = (MainObject.HScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
				End If

				'Loop through the appointments and paint what need be
				For Each appointment In Me.AppointmentCollection

					'If appointment.Contains(MainObject.MinDate, MainObject.MaxDate) Then
					startDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.StartDate))
					endDateIndex = GetIntlInteger(DateDiff(DateInterval.Day, CacheObject.FirstVisibleDate, appointment.EndDate))
					'The appointment might span multiple days
					daySpan = appointment.DaySpan
					For ii As Integer = 1 To daySpan

						For Each provider As Provider In appointment.ProviderList
							providerIndex = MainObject.ProviderCollection.IndexOf(provider)

							If MainObject.ProviderCollection.IsVisible(providerIndex) Then

								Dim brokenStart As Boolean = False
								Dim brokenEnd As Boolean = False

								Call CalculateAppointmentTimes(appointment, ii, daySpan, rectTimeStart, rectTimeEnd, rectTimeLength)

								timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
								timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

								'Calculate the column index for this appointment
								Dim visibleProviderIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(providerIndex)
								colIndex = (startDateIndex * MainObject.ProviderCollection.VisibleCount) + visibleProviderIndex - skew

								'Setup the structure to hold the appointment coordinates (date/time/provider/provider)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartDate = DateAdd(DateInterval.Day, ii - 1, appointment.StartDate)
								newRectInfo.StartProvider = providerIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								'If too long to draw then truncate draw length
								If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
									rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
								End If

								If (appointment.IsActivity OrElse appointment.IsEvent) Then
									appointment.EventIndex = NextHeaderIndex(newRectInfo.StartDate, newRectInfo.StartDate, newRectInfo.StartProvider, MainObject.ProviderCollection.VisibleCount)
									Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
									Dim itemLeft As Integer = CacheObject.ClientLeft + (colIndex * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
									Dim itemWidth As Integer = CacheObject.ColumnWidth - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
									If itemLeft + itemWidth >= CacheObject.ClientLeft Then
										rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
										newRectInfo.Rect = rectangle
									End If

								Else
									'Calculate the top coordinate
									If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
										brokenStart = True
										timeStartCor = CacheObject.ClientTop
									Else
										timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
										timeStartCor += timeStartSkewPixels
										timeStartCor += CacheObject.ClientTop
										If timeStartCor < 0 Then timeStartCor = 0
									End If

									'Calculate the bottom coordinate
									If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
										timeEndCor = CacheObject.ClientTop
									Else
										timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
										timeEndCor += timeEndSkewPixels
										timeEndCor += CacheObject.ClientTop
										If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
											brokenEnd = True
											timeEndCor = CacheObject.ClientBottom
										End If
									End If

									If colIndex >= 0 Then
										'Draw the appointment rectangle
										If (timeEndCor - timeStartCor) > 0 Then									'If off screen then do not draw
											rectangle = New Rectangle(CacheObject.ClientLeft + (colIndex * CacheObject.ColumnWidth), timeStartCor, CacheObject.ColumnWidth, timeEndCor - timeStartCor)
											newRectInfo.Rect = rectangle
										End If
									End If

								End If

								newRectInfo.BrokenStart = brokenStart
								newRectInfo.BrokenEnd = brokenEnd

							End If 'If there is a provider
						Next 'Provider

						'Next day for next loop
						startDateIndex += 1

					Next 'DaySpan
				Next 'Appointment

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsResourceLeftTimeTop()

			Dim displayStartResource As Integer
			Dim displayEndResource As Integer
			Dim appointment As Appointment
			Dim resource As Resource
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer

			Try
				displayStartResource = CacheObject.FirstVisibleResource
				displayEndResource = displayStartResource + CacheObject.TotalVisibleColumns

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					If (appointment.IsActivity OrElse appointment.IsEvent) Then
						'Setup the structure to hold the appointment coordinates (date/time/room/resource)
						Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
						If appointment.IsEvent Then
							newRectInfo.StartTime = PivotTime
							newRectInfo.Length = MinutesPerDay
						Else
							newRectInfo.StartTime = rectTimeStart
							newRectInfo.Length = rectTimeLength
						End If

					Else

						rectTimeStart = appointment.StartTime
						rectTimeLength = appointment.Length
						rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.ColumnWidth)))

						'If too long to draw then truncate draw length
						If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientLeft
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientLeft
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientLeft
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.ColumnWidth
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientLeft
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientRight) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientRight
							End If
						End If

						For Each resource In appointment.ResourceList
							Dim resourceIndex As Integer = MainObject.ResourceCollection.IndexOf(resource)
							If (CacheObject.FirstVisibleRow <= resourceIndex) AndAlso (resourceIndex <= CacheObject.FirstVisibleRow + CacheObject.TotalVisibleRows) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/resource)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartResource = resourceIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
								If (timeEndCor - timeStartCor) > 0 Then								'If off screen then do not draw
									'Draw the appointment rectangle
									rectangle = New Rectangle(timeStartCor, CacheObject.ClientTop + ((resourceIndex - CacheObject.FirstVisibleRow) * CacheObject.RowHeight), timeEndCor - timeStartCor, CacheObject.RowHeight)
									newRectInfo.Rect = rectangle
								End If

								newRectInfo.BrokenStart = brokenStart
								newRectInfo.BrokenEnd = brokenEnd

							End If							'Appointment in date range

						Next
					End If					'is event/activity
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub SetupAppointmentsResourceTopTimeLeft()

			Dim DisplayStartResource As Integer
			Dim DisplayEndResource As Integer
			Dim appointment As Appointment
			Dim rectangle As Rectangle
			Dim timeStartSkewPixels As Integer
			Dim timeEndSkewPixels As Integer
			Dim timeStartCor As Integer
			Dim timeEndCor As Integer
			Dim rectTimeStart As DateTime
			Dim rectTimeEnd As DateTime
			Dim rectTimeLength As Integer
			Dim isEventActivity As Boolean

			Try
				DisplayStartResource = CacheObject.FirstVisibleResource
				DisplayEndResource = DisplayStartResource + CacheObject.TotalVisibleColumns

				'Loop through the appointments AndAlso paint what need be
				For Each appointment In Me.AppointmentCollection

					Dim brokenStart As Boolean = False
					Dim brokenEnd As Boolean = False

					isEventActivity = appointment.IsActivity OrElse appointment.IsEvent

					If isEventActivity Then
						appointment.EventIndex = -1
						For Each resource As Gravitybox.Objects.Resource In appointment.ResourceList
							Dim resourceIndex As Integer = MainObject.ResourceCollection.IndexOfVisible(resource)
							appointment.EventIndex = NextHeaderIndex(appointment.StartDate, appointment.EndDate, resourceIndex, MainObject.ResourceCollection.VisibleCount)
							Dim itemTop As Integer = EventHeaderTop + Gravitybox.Objects.EventHeader.TopBuffer + Gravitybox.Objects.EventHeader.EventHeaderBuffer + (appointment.EventIndex * (MainObject.EventItemHeight + (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)))
							Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
							newRectInfo.StartTime = PivotTime
							newRectInfo.Length = MinutesPerDay
							newRectInfo.StartResource = resourceIndex

							Dim itemLeft As Integer = CacheObject.ClientLeft + ((MainObject.ResourceCollection.IndexOfVisible(resource) - MainObject.Visibility.FirstVisibleColumn) * CacheObject.ColumnWidth) + Gravitybox.Objects.EventHeader.EventHeaderBuffer
							Dim itemWidth As Integer = (CacheObject.ColumnWidth) - (Gravitybox.Objects.EventHeader.EventHeaderBuffer * 2)
							If itemLeft + itemWidth >= CacheObject.ClientLeft Then
								rectangle = New Rectangle(itemLeft, itemTop, itemWidth, MainObject.EventItemHeight)
								newRectInfo.Rect = rectangle
							End If
						Next						'Each Resource

					Else

						'Calculate the column/row indexes
						rectTimeStart = appointment.StartTime
						rectTimeLength = appointment.Length
						'Dim MinLeftInDay As Integer = MinutesLeftPerDay(rectTimeStart)
						'If rectTimeLength > MinLeftInDay Then rectTimeLength = MinLeftInDay

						rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)
						timeStartSkewPixels = GetIntlInteger(Fix((CSng(rectTimeStart.Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))
						timeEndSkewPixels = GetIntlInteger(Fix((CSng(DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart).Minute Mod CacheObject.TimeIncrement) / CSng(CacheObject.TimeIncrement)) * CSng(CacheObject.RowHeight)))

						'If too long to draw then truncate draw length
						If DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart) > MainObject.EndTime Then
							rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, rectTimeEnd))
						End If

						'Calculate the top coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeStart < CacheObject.FirstVisibleTime) Then
							brokenStart = True
							timeStartCor = CacheObject.ClientTop
						Else
							timeStartCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeStart)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeStartCor += timeStartSkewPixels
							timeStartCor += CacheObject.ClientTop
							If timeStartCor < 0 Then timeStartCor = 0
						End If

						'Calculate the bottom coordinate
						If Not MainObject.Visibility.IsPrinting AndAlso (rectTimeEnd < CacheObject.FirstVisibleTime) Then
							timeEndCor = CacheObject.ClientTop
						Else
							timeEndCor = (GetIntlInteger(DateDiff(DateInterval.Minute, CacheObject.FirstVisibleTime, rectTimeEnd)) \ CacheObject.TimeIncrement) * CacheObject.RowHeight
							timeEndCor += timeEndSkewPixels
							timeEndCor += CacheObject.ClientTop
							If Not MainObject.Visibility.IsPrinting AndAlso (timeEndCor > CacheObject.ClientBottom) Then
								brokenEnd = True
								timeEndCor = CacheObject.ClientBottom
							End If
						End If

						For Each resource As Gravitybox.Objects.Resource In appointment.ResourceList
							Dim resourceIndex As Integer = MainObject.ResourceCollection.IndexOfVisible(resource)
							'If (CacheObject.FirstVisibleColumn <= resourceIndex) AndAlso (resourceIndex <= CacheObject.FirstVisibleColumn + CacheObject.TotalVisibleColumns) Then
							If MainObject.ResourceCollection.Contains(resourceIndex) Then

								'Setup the structure to hold the appointment coordinates (date/time/room/resource)
								Dim newRectInfo As AppointmentRectangleInfo = appointment.Rectangles.Add()
								newRectInfo.StartResource = resourceIndex
								newRectInfo.StartTime = rectTimeStart
								newRectInfo.Length = rectTimeLength

								If timeStartCor < 0 Then timeStartCor = 0 'Correct so the drawing does not overlap the left header margin
								If (timeEndCor - timeStartCor) > 0 Then								'If off screen then do not draw
									'Draw the appointment rectangle
									Dim width As Integer = CacheObject.ColumnWidth
									If CacheObject.ColumnWidth > MainObject.AppointmentSpace Then width -= MainObject.AppointmentSpace
									rectangle = New Rectangle(CacheObject.ClientLeft + ((resourceIndex - CacheObject.FirstVisibleColumn) * CacheObject.ColumnWidth), timeStartCor, width, timeEndCor - timeStartCor)
									newRectInfo.Rect = rectangle
								End If

							End If							'Appointment in date range
						Next
					End If					'is event/activity
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Calculate Appointment Times"

		Private Sub CalculateAppointmentTimes(ByVal appointment As Appointment, ByVal ii As Integer, ByVal daySpan As Integer, ByRef rectTimeStart As DateTime, ByRef rectTimeEnd As DateTime, ByRef rectTimeLength As Integer)

			Try
				If (ii = 1) AndAlso (daySpan = 1) Then
					'Span 1 day
					rectTimeStart = appointment.StartTime
					rectTimeLength = appointment.Length
				ElseIf (ii = 1) Then
					'Span multiple days AndAlso current loop is first day
					rectTimeStart = appointment.StartTime
					rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, MidnightPlusOneDay))
				ElseIf (ii = daySpan) Then
					'Span multiple days AndAlso current loop is last day
					rectTimeStart = PivotTime
					rectTimeLength = GetIntlInteger(DateDiff(DateInterval.Minute, rectTimeStart, appointment.EndTime))
				Else
					'Span multiple days AndAlso current loop is NOT first or last day
					rectTimeStart = PivotTime
					rectTimeLength = MinutesPerDay
				End If
				rectTimeEnd = DateAdd(DateInterval.Minute, rectTimeLength, rectTimeStart)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "NextHeaderIndex"

		Private Function NextHeaderIndex(ByVal startDate As DateTime, ByVal endDate As DateTime) As Integer

			Try

				'Calculate the number of dates through which to cycle
				Dim count As Integer = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate))
				If count < 0 Then Return -1

				Dim retval As Integer = 0

				'Find the largest retval for all dates
				For ii As Integer = 0 To count
					Dim checkDate As DateTime = DateAdd(DateInterval.Day, ii, startDate)
					If DateHash(checkDate.ToLongDateString) Is Nothing Then
						DateHash(checkDate.ToLongDateString) = 0
					ElseIf GetIntlInteger(DateHash(checkDate.ToLongDateString)) > retval Then
						retval = GetIntlInteger(DateHash(checkDate.ToLongDateString))
					End If
				Next ii

				'Reset all dates to the new retval
				For ii As Integer = 0 To count
					Dim checkDate As DateTime = DateAdd(DateInterval.Day, ii, startDate)
					DateHash(checkDate.ToLongDateString) = retval + 1
				Next ii

				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function NextHeaderIndex(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal objectIndex As Integer, ByVal visibleObjectCount As Integer) As Integer

			Try

				'Calculate the number of dates through which to cycle
				Dim count As Integer = GetIntlInteger(DateDiff(DateInterval.Day, startDate, endDate)) * visibleObjectCount
				If count < 0 Then Return -1

				Dim retval As Integer = 0
				Dim baseOffset As Integer = GetIntlInteger(startDate.Subtract(MainObject.MinDate).TotalDays) * visibleObjectCount

				'Find the largest retval for all dates
				For ii As Integer = 0 To count
					Dim indexValue As Integer = baseOffset + (ii * visibleObjectCount) + objectIndex
					Dim hashKey As String = "X" & indexValue
					If DateHash(hashKey) Is Nothing Then
						DateHash(hashKey) = 0
					ElseIf GetIntlInteger(DateHash(hashKey)) > retval Then
						retval = GetIntlInteger(DateHash(hashKey))
					End If
				Next ii

				'Reset all dates to the new retval
				For ii As Integer = 0 To count
					Dim indexValue As Integer = baseOffset + (ii * visibleObjectCount) + objectIndex
					Dim hashKey As String = "X" & indexValue
					DateHash(hashKey) = retval + 1
				Next ii

				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "SetupAppointment"

		Private ReadOnly Property AppointmentCollection() As AppointmentCollection
			Get
				Return m_AppointmentCollection
			End Get
		End Property

		Public Sub SetupAppointment(ByVal appointment As Appointment)

			Try
				Dim oldAC As AppointmentCollection = m_AppointmentCollection
				m_AppointmentCollection = New AppointmentCollection(Nothing)
				m_AppointmentCollection.CancelEvents = True
				m_AppointmentCollection.AddObject(appointment)
				m_AppointmentCollection.CancelEvents = False
				Call CacheObject.Load(MainObject)
				Me.RecalculateRectangles()
				m_AppointmentCollection = oldAC
			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub RecalculateRectangles()

			Select Case MainObject.ViewMode
				Case Schedule.ViewModeConstants.DayLeftTimeTop
					Call SetupAppointmentsDayLeftTimeTop()
				Case Schedule.ViewModeConstants.DayRoomLeftTimeTop
					Call SetupAppointmentsDayRoomLeftTimeTop()
				Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
					Call SetupAppointmentsDayProviderLeftTimeTop()
				Case Schedule.ViewModeConstants.DayRoomTopTimeLeft
					Call SetupAppointmentsDayRoomTopTimeLeft()
				Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
					Call SetupAppointmentsDayProviderTopTimeLeft()
				Case Schedule.ViewModeConstants.DayTopTimeLeft
					Call SetupAppointmentsDayTopTimeLeft()
				Case Schedule.ViewModeConstants.RoomLeftTimeTop
					Call SetupAppointmentsRoomLeftTimeTop()
				Case Schedule.ViewModeConstants.RoomTopTimeLeft
					Call SetupAppointmentsRoomTopTimeLeft()
				Case Schedule.ViewModeConstants.DayLeftRoomTop
					Call SetupAppointmentsDayLeftRoomTop()
				Case Schedule.ViewModeConstants.DayTopRoomLeft
					Call SetupAppointmentsDayTopRoomLeft()
				Case Schedule.ViewModeConstants.DayLeftResourceTop
					Call SetupAppointmentsDayLeftResourceTop()
				Case Schedule.ViewModeConstants.DayLeftProviderTop
					Call SetupAppointmentsDayLeftProviderTop()
				Case Schedule.ViewModeConstants.DayTopProviderLeft
					Call SetupAppointmentsDayTopProviderLeft()
				Case Schedule.ViewModeConstants.RoomLeftProviderTop
					Call SetupAppointmentsRoomLeftProviderTop()
				Case Schedule.ViewModeConstants.RoomTopProviderLeft
					Call SetupAppointmentsRoomTopProviderLeft()
				Case Schedule.ViewModeConstants.ProviderLeftTimeTop
					Call SetupAppointmentsProviderLeftTimeTop()
				Case Schedule.ViewModeConstants.ProviderTopTimeLeft
					Call SetupAppointmentsProviderTopTimeLeft()
				Case Schedule.ViewModeConstants.Month
					Call SetupAppointmentsMonth()
				Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
					Call SetupAppointmentsProviderTopDayTimeLeft()
				Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
					Call SetupAppointmentsRoomTopDayTimeLeft()
				Case Schedule.ViewModeConstants.Week
					Call SetupAppointmentsWeek()
				Case Schedule.ViewModeConstants.MonthFull
					Call SetupAppointmentsMonthFull()
				Case Schedule.ViewModeConstants.ResourceLeftTimeTop
					Call SetupAppointmentsResourceLeftTimeTop()
				Case Schedule.ViewModeConstants.ResourceTopTimeLeft
					Call SetupAppointmentsResourceTopTimeLeft()
				Case Else
					Call ErrorModule.ViewmodeErr()
			End Select

		End Sub

#End Region

#Region "DrawClickToAddMessage"

		Public Sub DrawClickToAddMessage(ByVal g As Graphics, ByVal x As Integer, ByVal y As Integer)

			'Try
			'	Dim column As Integer = MainObject.Visibility.GetColumnFromCor(x, y)
			'	Dim row As Integer = MainObject.Visibility.GetRowFromCor(x, y)

			'	column -= MainObject.Visibility.FirstVisibleColumn
			'	row -= MainObject.Visibility.FirstVisibleRow

			'	Dim rect As Rectangle = New Rectangle(MainObject.ClientLeft + (column * MainObject.ColumnHeader.Size), MainObject.ClientTop + (row * MainObject.RowHeader.Size), MainObject.ColumnHeader.Size, MainObject.RowHeader.Size)
			'	If (rect.Width < 6) OrElse (rect.Height < 6) Then
			'		Return
			'	End If

			'	rect = New Rectangle(rect.Left + 2, rect.Top + 2, rect.Width - 4, rect.Height - 4)
			'	g.DrawRectangle(New Pen(MainObject.Appearance.ItemLineColor), rect)
			'	'g.DrawString("Click to Add", mainobject.Font, )


			'Catch ex As Exception
			'	ErrorModule.SetErr(ex)
			'End Try

		End Sub

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			MainObject = Nothing
			CacheObject = Nothing
			DateHash.Clear()
			DateHash = Nothing
			m_AppointmentCollection = Nothing
			_syncRoot = Nothing
		End Sub

#End Region

	End Class

End Namespace