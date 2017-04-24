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
Imports Gravitybox.Controls

Namespace Gravitybox.Objects

  Public Class ScheduleVisibility
		Implements IDisposable

#Region "Class Members"

    Private MainObject As Gravitybox.Controls.Schedule
    Friend IsPrinting As Boolean
    Friend PrinterPageWidth As Integer
    Friend PrinterPageHeight As Integer

#End Region

#Region "Property Implementations"

    Friend Sub New(ByVal MainSchedule As Gravitybox.Controls.Schedule)
      MainObject = MainSchedule
    End Sub

    ''' <summary>
    ''' Determines the total width of all columns and margins displayed on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the total width of all columns and margins displayed on the schedule.")> _
    Public ReadOnly Property TotalWidth() As Integer
      Get
        Return MainObject.ClientLeft + (Me.TotalColumnCount * MainObject.ColumnHeader.Size)
      End Get
    End Property

    ''' <summary>
    ''' Determines the total height of all rows and margins displayed on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the total height of all rows and margins displayed on the schedule.")> _
    Public ReadOnly Property TotalHeight() As Integer
      Get
        Return MainObject.ClientTop + (Me.TotalRowCount * MainObject.RowHeader.Size)
      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible date on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the first visible date on the schedule.")> _
    Public ReadOnly Property FirstVisibleDate() As DateTime
      Get

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, (MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, (MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            ElseIf MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, (MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            ElseIf MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, (MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual, MainObject.MinDate)
            Else
              Return DateAdd(DateInterval.Day, MainObject.HScroll1.Value, MainObject.MinDate)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return MainObject.MinDate
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
            Return DateAdd(DateInterval.Day, MainObject.VScroll1.Value \ IncPerDay, MainObject.MinDate)
          Case Schedule.ViewModeConstants.Week
            Return MainObject.MinDate
          Case Schedule.ViewModeConstants.MonthFull
            Return MainObject.MinDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return DefaultNoDate
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      End Get
    End Property

    Friend ReadOnly Property LastVisibleDate() As DateTime
      Get
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return DateAdd(DateInterval.Day, MainObject.Visibility.VisibleColumns - 1, MainObject.Visibility.FirstVisibleDate)
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return DateAdd(DateInterval.Day, MainObject.Visibility.VisibleRows - 1, MainObject.Visibility.FirstVisibleDate)
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            If MainObject.RoomCollection.VisibleCount = 0 Then Return DefaultNoDate
            Dim VC As Integer = MainObject.Visibility.VisibleColumns
            If VC = 0 Then Return DefaultNoDate
            VC += MainObject.RoomCollection.VisibleCount - ((VC - 1) Mod MainObject.RoomCollection.VisibleCount)
            Dim days As Integer = ((VC - 1) \ MainObject.RoomCollection.VisibleCount)    '+ 1
            Dim retval As DateTime = DateAdd(DateInterval.Day, days, MainObject.Visibility.FirstVisibleDate)
            If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
            Return retval
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If MainObject.ProviderCollection.VisibleCount = 0 Then Return DefaultNoDate
            Dim VC As Integer = MainObject.Visibility.VisibleColumns
            If VC = 0 Then Return DefaultNoDate
            VC += MainObject.ProviderCollection.VisibleCount - ((VC - 1) Mod MainObject.ProviderCollection.VisibleCount)
            Dim days As Integer = ((VC - 1) \ MainObject.ProviderCollection.VisibleCount)    '+ 1
            Dim retval As DateTime = DateAdd(DateInterval.Day, days, MainObject.Visibility.FirstVisibleDate)
            If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
            Return retval
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            If MainObject.RoomCollection.VisibleCount = 0 Then Return DefaultNoDate
            Dim VR As Integer = MainObject.Visibility.VisibleRows
            If VR = 0 Then Return DefaultNoDate
            VR += MainObject.RoomCollection.VisibleCount - ((VR - 1) Mod MainObject.RoomCollection.VisibleCount)
            Dim days As Integer = ((VR - 1) \ MainObject.RoomCollection.VisibleCount)    '+ 1
            Dim retval As DateTime = DateAdd(DateInterval.Day, days, MainObject.Visibility.FirstVisibleDate)
            If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
            Return retval
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            If MainObject.ProviderCollection.VisibleCount = 0 Then Return DefaultNoDate
            Dim VR As Integer = MainObject.Visibility.VisibleColumns
            If VR = 0 Then Return DefaultNoDate
            VR += MainObject.ProviderCollection.VisibleCount - ((VR - 1) Mod MainObject.ProviderCollection.VisibleCount)
            Dim days As Integer = ((VR - 1) \ MainObject.ProviderCollection.VisibleCount)    '+ 1
            Dim retval As DateTime = DateAdd(DateInterval.Day, days, MainObject.Visibility.FirstVisibleDate)
            If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
            Return retval
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return DefaultNoDate
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
            Dim visibleDays As Integer = Me.VisibleRows \ IncPerDay
            Return DateAdd(DateInterval.Day, IncPerDay, MainObject.Visibility.FirstVisibleDate)
          Case Schedule.ViewModeConstants.Week
            Return MainObject.MaxDate
          Case Schedule.ViewModeConstants.MonthFull
            Return MainObject.MaxDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return DefaultNoDate
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return DefaultNoDate
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible time on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the first visible time on the schedule."), _
    TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter))> _
    Public ReadOnly Property FirstVisibleTime() As DateTime
      Get

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Minute, MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
            Else
              Return DateAdd(DateInterval.Minute, MainObject.HScroll1.Value * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return DateAdd(DateInterval.Minute, MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
            Else
              Return DateAdd(DateInterval.Minute, MainObject.VScroll1.Value * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return ScheduleGlobals.DefaultNoTime
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return ScheduleGlobals.DefaultNoTime
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
            Dim modValue As Integer = MainObject.VScroll1.Value Mod IncPerDay
            Return DateAdd(DateInterval.Minute, modValue * MainObject.TimeIncrementValue, PivotTime)
          Case Schedule.ViewModeConstants.Week
            Return DefaultNoTime
          Case Schedule.ViewModeConstants.MonthFull
            Return ScheduleGlobals.DefaultNoTime
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      End Get
    End Property

    <TypeConverter(GetType(Gravitybox.Design.Converters.TimeConverter))> _
    Friend ReadOnly Property LastVisibleTime() As DateTime
      Get
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return DateAdd(DateInterval.Minute, Me.VisibleRows * MainObject.TimeIncrement, Me.FirstVisibleTime)
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return DateAdd(DateInterval.Minute, Me.VisibleColumns * MainObject.TimeIncrement, Me.FirstVisibleTime)
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return DefaultNoTime
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return DateAdd(DateInterval.Minute, Me.VisibleRows * MainObject.TimeIncrement, Me.FirstVisibleTime)
          Case Schedule.ViewModeConstants.Week
            Return DefaultNoTime
          Case Schedule.ViewModeConstants.MonthFull
            Return ScheduleGlobals.DefaultNoTime
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible room on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the first visible room on the schedule.")> _
    Public ReadOnly Property FirstVisibleRoom() As Integer
      Get

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return -1
            ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
            Else
              Return (MainObject.VScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return -1
            ElseIf MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return ((MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual) Mod MainObject.RoomCollection.VisibleCount)
            Else
              Return (MainObject.HScroll1.Value Mod MainObject.RoomCollection.VisibleCount)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return -1
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return -1
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Schedule.ViewModeConstants.Week
            Return -1
          Case Schedule.ViewModeConstants.MonthFull
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return -1
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible resource on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the first visible resource on the schedule.")> _
    Public ReadOnly Property FirstVisibleResource() As Integer
      Get

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            Return -1
          Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return -1
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return -1
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return -1
          Case Schedule.ViewModeConstants.Week
            Return -1
          Case Schedule.ViewModeConstants.MonthFull
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If

          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible provider on the schedule.
    ''' </summary>
    <Browsable(False), _
    Description("Determines the first visible provider on the schedule.")> _
    Public ReadOnly Property FirstVisibleProvider() As Integer
      Get

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            Return -1
          Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return -1
            ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return ((MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
            Else
              Return (MainObject.VScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
            End If
          Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return -1
            ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return ((MainObject.HScroll1.Value * MainObject.RowHeader.FrameIncrementActual) Mod MainObject.ProviderCollection.VisibleCount)
            Else
              Return (MainObject.HScroll1.Value Mod MainObject.ProviderCollection.VisibleCount)
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
              Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
            Else
              Return MainObject.VScroll1.Value
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return -1
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
              Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
            Else
              Return MainObject.HScroll1.Value
            End If
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return -1
          Case Schedule.ViewModeConstants.Week
            Return -1
          Case Schedule.ViewModeConstants.MonthFull
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return -1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return -1
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      End Get
    End Property

    ''' <summary>
    ''' Determines the first visible row on the schedule.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the first visible row on the schedule.")> _
    Public Property FirstVisibleRow() As Integer
      Get
        If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
          Return 0
        ElseIf MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
          Return MainObject.VScroll1.Value * MainObject.RowHeader.FrameIncrementActual
        Else
          Return MainObject.VScroll1.Value
        End If
      End Get
      Set(ByVal Value As Integer)
        If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then Return
        If Value < 0 Then Value = 0

        If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
          Dim skew As Boolean = ((Value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
          Value = Value \ MainObject.RowHeader.FrameIncrementActual
          If skew Then Value += 1
        End If

        If Value > MainObject.VScroll1.Maximum Then Value = MainObject.VScroll1.Maximum
        MainObject.VScroll1.Value = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the first visible column on the schedule.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    Description("Determines the first visible column on the schedule.")> _
    Public Property FirstVisibleColumn() As Integer
      Get
        If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
          Return 0
        ElseIf MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
          Return MainObject.HScroll1.Value * MainObject.ColumnHeader.FrameIncrementActual
        Else
          Return MainObject.HScroll1.Value
        End If
      End Get
      Set(ByVal Value As Integer)
        If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then Return
        If Value < 0 Then Value = 0

        If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
          Dim skew As Boolean = ((Value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
          Value = Value \ MainObject.ColumnHeader.FrameIncrementActual
          If skew Then Value += 1
        End If

        If Value > MainObject.HScroll1.Maximum Then Value = MainObject.HScroll1.Maximum
        MainObject.HScroll1.Value = Value
      End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsRoomVisible(ByVal room As Room) As Boolean
      Try

        'If printing then entire canvas is visible
        If Me.IsPrinting Then Return True
        If room Is Nothing Then Return False
        Dim roomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(room)
        If roomIndex = -1 Then Return False

        'When printing everything is visible
        If (Me.IsPrinting) Then Return True

        Dim lastRoom As Integer
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            lastRoom = Me.FirstVisibleRoom + Me.VisibleRows - 1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            lastRoom = Me.FirstVisibleRoom + Me.VisibleColumns - 1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            lastRoom = Me.FirstVisibleRoom + Me.VisibleColumns - 1
            If Me.VisibleColumns >= MainObject.RoomCollection.VisibleCount Then
              'If there are more columns than rooms then all of them are visible
              Return True
            ElseIf lastRoom <= MainObject.RoomCollection.VisibleCount Then
              'This we have NOT rolled over the next day
              'Do Nothing - Fall through to check below
            Else
              If (Me.FirstVisibleRoom <= roomIndex) AndAlso (roomIndex <= MainObject.RoomCollection.VisibleCount) Then
                'If room if between [Index..N]
                Return True
              ElseIf MainObject.RoomCollection.VisibleCount = 0 Then
                Return False
              ElseIf (0 <= roomIndex) AndAlso (roomIndex <= (lastRoom Mod MainObject.RoomCollection.VisibleCount)) Then
                'If room if between [1..room%roomcount]
                Return True
              End If
            End If

          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            lastRoom = Me.FirstVisibleRoom + Me.VisibleRows - 1
            If Me.VisibleRows >= MainObject.RoomCollection.VisibleCount Then
              'If there are more rows than rooms then all of them are visible
              Return True
            ElseIf lastRoom <= MainObject.RoomCollection.VisibleCount Then
              'This we have NOT rolled over the next day
              'Do Nothing - Fall through to check below
            Else
              If (Me.FirstVisibleRoom <= roomIndex) AndAlso (roomIndex <= MainObject.RoomCollection.VisibleCount) Then
                'If room if between [Index..N]
                Return True
              ElseIf MainObject.RoomCollection.VisibleCount = 0 Then
                Return False
              ElseIf (0 <= roomIndex) AndAlso (roomIndex <= (lastRoom Mod MainObject.RoomCollection.VisibleCount)) Then
                'If room if between [1..room%roomcount]
                Return True
              End If
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            lastRoom = Me.FirstVisibleRoom + Me.VisibleColumns - 1
          Case Schedule.ViewModeConstants.Week
            Return False
          Case Schedule.ViewModeConstants.MonthFull
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
        If (Me.FirstVisibleRoom <= roomIndex) AndAlso (roomIndex <= lastRoom) Then
          Return True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsRoomVisible(ByVal key As String) As Boolean
      Return IsRoomVisible(MainObject.ResolveRoom(key))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsRoomVisible(ByVal index As Integer) As Boolean
      If Not MainObject.RoomCollection.Contains(index) Then Return False
      Return IsRoomVisible(MainObject.RoomCollection(index))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsResourceVisible(ByVal resource As Resource) As Boolean
      Try

        'If printing then entire canvas is visible
        If Me.IsPrinting Then Return True
        If resource Is Nothing Then Return False
        Dim resourceIndex As Integer = MainObject.ResourceCollection.IndexOfVisible(resource)
        If resourceIndex = -1 Then Return False

        'When printing everything is visible
        If (Me.IsPrinting) Then Return True

        Dim lastResource As Integer
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            Return False
          Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return False
          Case Schedule.ViewModeConstants.Week
            Return False
          Case Schedule.ViewModeConstants.MonthFull
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            lastResource = Me.FirstVisibleResource + Me.VisibleRows - 1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            lastResource = Me.FirstVisibleResource + Me.VisibleColumns - 1
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

        If (Me.FirstVisibleResource <= resourceIndex) AndAlso (resourceIndex <= lastResource) Then
          Return True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsResourceVisible(ByVal key As String) As Boolean
      Return IsResourceVisible(MainObject.ResolveResource(key))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsResourceVisible(ByVal index As Integer) As Boolean
      If Not MainObject.ResourceCollection.Contains(index) Then Return False
      Return IsResourceVisible(MainObject.ResourceCollection(index))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsProviderVisible(ByVal provider As Provider) As Boolean
      Try

        'If printing then entire canvas is visible
        If Me.IsPrinting Then Return True
        If provider Is Nothing Then Return False
        Dim providerIndex As Integer = MainObject.ProviderCollection.IndexOfVisible(provider)
        If providerIndex = -1 Then Return False

        'When printing everything is visible
        If (Me.IsPrinting) Then Return True

        Dim lastprovider As Integer
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            lastprovider = Me.FirstVisibleProvider + Me.VisibleRows - 1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            lastprovider = Me.FirstVisibleProvider + Me.VisibleColumns - 1
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
            lastprovider = Me.FirstVisibleProvider + Me.VisibleColumns - 1
          Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return False
          Case Schedule.ViewModeConstants.Week
            Return False
          Case Schedule.ViewModeConstants.MonthFull
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
        If (Me.FirstVisibleProvider <= providerIndex) AndAlso (providerIndex <= lastprovider) Then
          Return True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsProviderVisible(ByVal key As String) As Boolean
      Return IsProviderVisible(MainObject.ResolveProvider(key))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsProviderVisible(ByVal index As Integer) As Boolean
      If Not MainObject.ProviderCollection.Contains(index) Then Return False
      Return IsProviderVisible(MainObject.ProviderCollection(index))
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsDateVisible(ByVal dateValue As DateTime) As Boolean
      Try

        'If printing then entire canvas is visible
        If Me.IsPrinting Then Return True

        Dim lastDate As DateTime
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            lastDate = DateAdd(DateInterval.Day, Me.VisibleColumns - 1, Me.FirstVisibleDate)
            If (Me.FirstVisibleDate <= dateValue) AndAlso (dateValue <= lastDate) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            lastDate = DateAdd(DateInterval.Day, Me.VisibleRows - 1, Me.FirstVisibleDate)
            If (Me.FirstVisibleDate <= dateValue) AndAlso (dateValue <= lastDate) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
            lastDate = MainObject.Visibility.GetDateFromRowCol(Me.VisibleColumns)
            If (Me.FirstVisibleDate <= dateValue) AndAlso (dateValue <= lastDate) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop
            lastDate = MainObject.Visibility.GetDateFromRowCol(Me.VisibleRows)
            If (Me.FirstVisibleDate <= dateValue) AndAlso (dateValue <= lastDate) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            'If in the same Month/Year (ignore day since whole month is displayed)
            Return (dateValue.Month = MainObject.MonthSelDate.Month) AndAlso (dateValue.Year = MainObject.MonthSelDate.Year)
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim dayStartRow As Integer = Me.GetRowColFromDate(dateValue)
            Dim dayEndRow As Integer = dayStartRow + MainObject.TimeIncrementsPerDay
            Dim visibleStartRow As Integer = Me.FirstVisibleRow
            Dim visibleEndRow As Integer = visibleStartRow + Me.VisibleRows

            If ((dayStartRow = visibleStartRow) AndAlso (dayEndRow = visibleEndRow)) OrElse _
             (dayStartRow < visibleEndRow) AndAlso (dayEndRow > visibleStartRow) Then
              Return True
            End If
          Case Schedule.ViewModeConstants.Week
            Return (WeekModeHelper.GetDayOffset(MainObject.MinDate, dateValue) <> -1)
          Case Schedule.ViewModeConstants.MonthFull
            'If in the same Month/Year (ignore day since whole month is displayed)
            Return (dateValue.Month = MainObject.MonthSelDate.Month) AndAlso (dateValue.Year = MainObject.MonthSelDate.Year)
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsTimeVisible(ByVal timeValue As DateTime) As Boolean
      Try

        'If printing then entire canvas is visible
        If Me.IsPrinting Then Return True

        Dim lastTime As DateTime
        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            lastTime = DateAdd(DateInterval.Minute, (Me.VisibleColumns - 1) * MainObject.TimeIncrement, Me.FirstVisibleTime)
            If (Me.FirstVisibleTime <= timeValue) AndAlso (timeValue <= lastTime) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            lastTime = DateAdd(DateInterval.Minute, (Me.VisibleRows - 1) * MainObject.TimeIncrement, Me.FirstVisibleTime)
            If (Me.FirstVisibleTime <= timeValue) AndAlso (timeValue <= lastTime) Then
              Return True
            End If
          Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
            Return False
          Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
            'TODO - DayTimeLeftProviderTop, DayTimeLeftRoomTop
          Case Schedule.ViewModeConstants.Week
            Return False
          Case Schedule.ViewModeConstants.MonthFull
            Return False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Function IsTimeRangeVisible(ByVal startTime As DateTime, ByVal endTime As DateTime) As Boolean
      Try
        startTime = GetTime(startTime)
        endTime = GetTime(endTime)
        If (startTime = Me.FirstVisibleTime) AndAlso (endTime = Me.LastVisibleTime) Then
          Return True
        ElseIf (startTime < Me.LastVisibleTime) AndAlso (endTime > Me.FirstVisibleTime) Then
          Return True
        Else
          Return False
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

		End Function

		Friend ReadOnly Property IsTimeOnTop() As Boolean
			Get
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayLeftTimeTop, Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.RoomLeftTimeTop, Schedule.ViewModeConstants.ProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Return True

					Case Schedule.ViewModeConstants.DayTopTimeLeft
					Case Schedule.ViewModeConstants.DayTopRoomLeft
					Case Schedule.ViewModeConstants.DayTopProviderLeft
					Case Schedule.ViewModeConstants.DayLeftRoomTop
					Case Schedule.ViewModeConstants.DayLeftProviderTop
					Case Schedule.ViewModeConstants.DayRoomTopTimeLeft
					Case Schedule.ViewModeConstants.RoomTopTimeLeft
					Case Schedule.ViewModeConstants.RoomTopProviderLeft
					Case Schedule.ViewModeConstants.RoomLeftProviderTop
					Case Schedule.ViewModeConstants.ProviderTopTimeLeft
					Case Schedule.ViewModeConstants.Month
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
					Case Schedule.ViewModeConstants.Week
					Case Schedule.ViewModeConstants.MonthFull
					Case Schedule.ViewModeConstants.ResourceTopTimeLeft
					Case Schedule.ViewModeConstants.DayLeftResourceTop
					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return False

					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
			End Get
		End Property

		Friend ReadOnly Property IsTimeOnLeft() As Boolean
			Get
				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTopTimeLeft, Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.RoomTopTimeLeft, Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop, Schedule.ViewModeConstants.ResourceTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return True

					Case Schedule.ViewModeConstants.DayTopRoomLeft
					Case Schedule.ViewModeConstants.DayTopProviderLeft
					Case Schedule.ViewModeConstants.DayLeftTimeTop
					Case Schedule.ViewModeConstants.DayLeftRoomTop
					Case Schedule.ViewModeConstants.DayLeftProviderTop
					Case Schedule.ViewModeConstants.DayRoomLeftTimeTop
					Case Schedule.ViewModeConstants.RoomTopProviderLeft
					Case Schedule.ViewModeConstants.RoomLeftTimeTop
					Case Schedule.ViewModeConstants.RoomLeftProviderTop
					Case Schedule.ViewModeConstants.ProviderLeftTimeTop
					Case Schedule.ViewModeConstants.Month
					Case Schedule.ViewModeConstants.Week
					Case Schedule.ViewModeConstants.MonthFull
					Case Schedule.ViewModeConstants.ResourceLeftTimeTop
					Case Schedule.ViewModeConstants.DayLeftResourceTop
					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Return False

					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
			End Get
		End Property

		'This is the number of visible columns with no end range checking
		Friend ReadOnly Property VisibleColumnsNoCorrection() As Integer
			Get
				Try
					Dim retval As Integer
					If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
						retval = 6
					ElseIf MainObject.ColumnHeader.AutoFit AndAlso MainObject.ColumnHeader.PerfectFit Then
						'Calculate the number of columns to display
						retval = GetIntlInteger(MainObject.GridWidth \ MainObject.ColumnHeader.Size)
					Else
						'Calculate the number of columns to display
						retval = GetIntlInteger(MainObject.GridWidth \ MainObject.ColumnHeader.Size)
						If (MainObject.GridWidth Mod MainObject.ColumnHeader.Size) <> 0 Then retval += 1
					End If
					Return retval
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Get
		End Property

		''' <summary>
		''' 
		''' </summary>
		Public ReadOnly Property VisibleColumns() As Integer
			Get
				Try
					Return VisibleColumns(MainObject.ViewMode)
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try
			End Get
		End Property

		'This is the number of visible columns
		Friend ReadOnly Property VisibleColumns(ByVal newViewmode As Schedule.ViewModeConstants) As Integer
			Get

				Try
					Dim retval As Integer

					'Calculate the number of columns to display
					retval = GetIntlInteger(MainObject.GridWidth \ MainObject.ColumnHeader.Size)
					If (MainObject.GridWidth Mod MainObject.ColumnHeader.Size) <> 0 Then retval += 1

					Select Case newViewmode

						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
							Dim TimeEnd As DateTime
							Dim MaxTime As DateTime = PivotTime.AddHours(24)
							'If the number of days is past then end date then truncate to this end
							Try
								TimeEnd = Me.FirstVisibleTime.AddMinutes(retval * GetIntlInteger(MainObject.TimeIncrement))
							Catch ex As Exception
								Return 0
							End Try
							If TimeEnd > MaxTime Then
								TimeEnd = MainObject.EndTime
								retval = CType(TimeEnd.Subtract(Me.FirstVisibleTime).TotalMinutes, Integer) \ GetIntlInteger(MainObject.TimeIncrement)
							ElseIf TimeEnd > MainObject.EndTime Then
								retval -= GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.EndTime, TimeEnd)) \ GetIntlInteger(MainObject.TimeIncrement)
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
							If retval > MainObject.RoomCollection.VisibleCount Then
								retval = MainObject.RoomCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleRoom > MainObject.RoomCollection.VisibleCount Then
								retval = MainObject.RoomCollection.VisibleCount - Me.FirstVisibleRoom
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
							If retval > MainObject.ProviderCollection.VisibleCount Then
								retval = MainObject.ProviderCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleProvider > MainObject.ProviderCollection.VisibleCount Then
								retval = MainObject.ProviderCollection.VisibleCount - Me.FirstVisibleProvider
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
							If retval > MainObject.ResourceCollection.VisibleCount Then
								retval = MainObject.ResourceCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleResource > MainObject.ResourceCollection.VisibleCount Then
								retval = MainObject.ResourceCollection.VisibleCount - Me.FirstVisibleResource
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
							Dim DateEnd As DateTime
							'If the number of days is past then end date then truncate to this end
							'DateEnd = DateAdd(DateInterval.Day, retval, Me.FirstVisibleDate)
							DateEnd = Me.FirstVisibleDate.AddDays(retval)
							If DateEnd > MainObject.MaxDate Then
								DateEnd = MainObject.MaxDate
								retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, DateEnd)) + 1
							ElseIf DateEnd > MainObject.MaxDate Then
								retval -= GetIntlInteger(DateDiff(DateInterval.Day, DateEnd, MainObject.MaxDate))
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
							If Me.FirstVisibleColumn + retval > Me.TotalColumnCount Then
								retval = Me.TotalColumnCount - Me.FirstVisibleColumn
							End If

						Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
							Return 6

						Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
							If retval > MainObject.ProviderCollection.VisibleCount Then
								retval = MainObject.ProviderCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleProvider > MainObject.ProviderCollection.VisibleCount Then
								retval = MainObject.ProviderCollection.VisibleCount - Me.FirstVisibleProvider
							End If

						Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
							If retval > MainObject.RoomCollection.VisibleCount Then
								retval = MainObject.RoomCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleRoom > MainObject.RoomCollection.VisibleCount Then
								retval = MainObject.RoomCollection.VisibleCount - Me.FirstVisibleRoom
							End If

						Case Schedule.ViewModeConstants.Week
							Return 2

						Case Schedule.ViewModeConstants.MonthFull
							Return 7

						Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
							If retval > MainObject.ResourceCollection.VisibleCount Then
								retval = MainObject.ResourceCollection.VisibleCount
							End If
							If retval + Me.FirstVisibleResource > MainObject.ResourceCollection.VisibleCount Then
								retval = MainObject.ResourceCollection.VisibleCount - Me.FirstVisibleResource
							End If

						Case Else
							Call ErrorModule.ViewmodeErr()

					End Select
					Return retval
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

		'This is the number of visible rows with no end range checking
		Friend ReadOnly Property VisibleRowsNoCorrection() As Integer
			Get
				Try
					Dim retval As Integer

					If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
						Return 5
					ElseIf MainObject.RowHeader.AutoFit AndAlso MainObject.RowHeader.PerfectFit Then
						'Error Check
						If MainObject.GridHeight <= 0 Then Return 0
						'Calculate the number of rows to display
						retval = GetIntlInteger(MainObject.GridHeight \ MainObject.RowHeader.Size)
					Else
						'Error Check
						If MainObject.GridHeight <= 0 Then Return 0
						'Calculate the number of rows to display
						retval = GetIntlInteger(MainObject.GridHeight \ MainObject.RowHeader.Size)
						If (MainObject.GridHeight Mod MainObject.RowHeader.Size) <> 0 Then retval += 1
					End If
					Return retval

				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

		''' <summary>
		''' 
		''' </summary>
		Public Function VisibleRows() As Integer
			Try
				Return VisibleRows(MainObject.ViewMode)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' The total number of visible rows inside of the viewport
		''' </summary>
		Public Function VisibleRows(ByVal newViewmode As Schedule.ViewModeConstants) As Integer
			Dim retval As Integer

			Try
				'Error Check
				If MainObject.GridHeight <= 0 Then Return 0
				'Calculate the number of rows to display
				retval = GetIntlInteger(MainObject.GridHeight \ MainObject.RowHeader.Size)
				If (MainObject.GridHeight Mod MainObject.RowHeader.Size) <> 0 Then retval += 1

				Select Case MainObject.ViewMode

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Dim DateEnd As DateTime
						'If the number of days is past then end date then truncate to this end
						'DateEnd = DateAdd(DateInterval.Day, retval, Me.FirstVisibleDate)
						DateEnd = Me.FirstVisibleDate.AddDays(retval)
						If DateEnd > MainObject.MaxDate Then
							DateEnd = MainObject.MaxDate
							retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, DateEnd)) + 1
						ElseIf DateEnd > MainObject.MaxDate Then
							retval -= GetIntlInteger(DateDiff(DateInterval.Day, DateEnd, MainObject.MaxDate))
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If Me.FirstVisibleRow + retval > Me.TotalRowCount Then
							retval = Me.TotalRowCount - Me.FirstVisibleRow
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Dim TimeEnd As DateTime
						Dim MaxTime As DateTime = PivotTime.AddHours(HourPerDay)
						'If the number of days is past then end date then truncate to this end
						Try
							TimeEnd = Me.FirstVisibleTime.AddMinutes(retval * GetIntlInteger(MainObject.TimeIncrement))
						Catch ex As Exception
							Return 0
						End Try
						If TimeEnd > MaxTime Then
							TimeEnd = MainObject.EndTime
							retval = GetIntlInteger(DateDiff(DateInterval.Minute, Me.FirstVisibleTime, TimeEnd)) \ GetIntlInteger(MainObject.TimeIncrement)
						ElseIf TimeEnd > MainObject.EndTime Then
							retval -= GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.EndTime, TimeEnd)) \ GetIntlInteger(MainObject.TimeIncrement)
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						If retval > MainObject.RoomCollection.VisibleCount Then
							retval = MainObject.RoomCollection.VisibleCount
						End If
						If retval + Me.FirstVisibleRoom > MainObject.RoomCollection.VisibleCount Then
							retval = MainObject.RoomCollection.VisibleCount - Me.FirstVisibleRoom
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						If retval > MainObject.ProviderCollection.VisibleCount Then
							retval = MainObject.ProviderCollection.VisibleCount
						End If
						If retval + Me.FirstVisibleProvider > MainObject.ProviderCollection.VisibleCount Then
							retval = MainObject.ProviderCollection.VisibleCount - Me.FirstVisibleProvider
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Return 5

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'If the number of rows is past then end then truncate to this end
						If retval > Me.TotalRowCount Then
							retval = Me.TotalRowCount - Me.FirstVisibleRow
						End If
						Return retval

					Case Schedule.ViewModeConstants.Week
						Return 4

					Case Schedule.ViewModeConstants.MonthFull
						Return 5

					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
						If retval > MainObject.ResourceCollection.VisibleCount Then
							retval = MainObject.ResourceCollection.VisibleCount
						End If
						If retval + Me.FirstVisibleResource > MainObject.ResourceCollection.VisibleCount Then
							retval = MainObject.ResourceCollection.VisibleCount - Me.FirstVisibleResource
						End If

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return retval
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' The total number of columns displayed on the schedule.
		''' </summary>
		Public ReadOnly Property TotalColumnCount() As Integer
			Get
				Try
					Select Case MainObject.ViewMode
						Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
							Return MainObject.RoomCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
							Return MainObject.ProviderCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
							Return MainObject.ResourceCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
							Return GetIntlInteger(MainObject.DayLength * GetIntlInteger(MinutesPerHour \ MainObject.TimeIncrement))
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1)
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1) * MainObject.RoomCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1) * MainObject.ProviderCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
							Return 6
						Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
							Return MainObject.ProviderCollection.VisibleCount
						Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
							Return MainObject.RoomCollection.VisibleCount
						Case Schedule.ViewModeConstants.Week
							Return 2
						Case Schedule.ViewModeConstants.MonthFull
							Return 7
						Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
							Return MainObject.ResourceCollection.VisibleCount
						Case Else
							Call ErrorModule.ViewmodeErr()
					End Select
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

		''' <summary>
		''' The total number of rows displayed on the schedule.
		''' </summary>
		Public ReadOnly Property TotalRowCount() As Integer
			Get
				Try
					Select Case MainObject.ViewMode
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
							Return GetIntlInteger(MainObject.DayLength * GetIntlInteger(MinutesPerHour \ MainObject.TimeIncrement))
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1)
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
							Return MainObject.RoomCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
							Return MainObject.ProviderCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1) * MainObject.RoomCollection.VisibleCount
						Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
							Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1) * MainObject.ProviderCollection.VisibleCount
						Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
							'Return 10
							Dim lastDayOfMonth As Date = MainObject.OrginalMinDate.AddMonths(1).AddDays(-1)
							Dim lastDate As Date = MainObject.MonthViewFirstDate.AddDays((MonthSmallRowCount * DaysPerWeek) - 1)
							If lastDate >= lastDayOfMonth Then
								Return MonthSmallRowCount * 2
							Else
								Return MonthLargeRowCount * 2
							End If
						Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
							Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
							Return IncPerDay * GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, MainObject.MaxDate) + 1)
						Case Schedule.ViewModeConstants.Week
							Return 4
						Case Schedule.ViewModeConstants.MonthFull
							Dim lastDayOfMonth As Date = MainObject.OrginalMinDate.AddMonths(1).AddDays(-1)
							Dim lastDate As Date = MainObject.MonthViewFirstDate.AddDays((MonthSmallRowCount * DaysPerWeek) - 1)
							If lastDate >= lastDayOfMonth Then
								Return MonthSmallRowCount
							Else
								Return MonthLargeRowCount
							End If
						Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
							Return MainObject.ResourceCollection.VisibleCount
						Case Else
							Call ErrorModule.ViewmodeErr()
					End Select
				Catch ex As Exception
					Call ErrorModule.SetErr(ex)
				End Try

			End Get
		End Property

#End Region

#Region "GetFromCoordinates"

		Friend Function IsInRangeCor(ByVal x As Integer, ByVal y As Integer) As Boolean
			Return IsInRangeCor(New Point(x, y))
		End Function

		Friend Function IsInRangeCor(ByVal pt As Point) As Boolean

			Dim retval As Boolean = True

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetRoomFromCor(pt) >= 0)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetProviderFromCor(pt) >= 0)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetResourceFromCor(pt) >= 0)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
						retval = retval AndAlso CBool(Me.GetRoomFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						retval = retval AndAlso CBool(Me.GetRoomFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetProviderFromCor(pt) >= 0)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						retval = retval AndAlso CBool(Me.GetProviderFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'TODO
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetRoomFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetProviderFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetProviderFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
						retval = retval AndAlso CBool(Me.GetRoomFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Schedule.ViewModeConstants.Week
						retval = retval AndAlso CBool(Me.GetDateFromCor(pt) <> ScheduleGlobals.DefaultNoDate)
					Case Schedule.ViewModeConstants.MonthFull
						'TODO - MonthFull
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						retval = retval AndAlso CBool(Me.GetResourceFromCor(pt) >= 0)
						retval = retval AndAlso CBool(Me.GetTimeFromCor(pt) <> ScheduleGlobals.DefaultNoTime)
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the appointment under a screen point.
		''' </summary>
		Public Function GetAppointmentFromCor(ByVal pt As Point) As Appointment
			Return GetAppointmentFromCor(pt.X, pt.Y)
		End Function

		''' <summary>
		''' Determines the appointment under a screen point.
		''' </summary>
		Public Function GetAppointmentFromCor(ByVal x As Integer, ByVal y As Integer) As Appointment
			Try
				Return Me.MainObject.AppointmentCollection.HitTest(x, y)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
			Return Nothing
		End Function

		''' <summary>
		''' Determines the date at displayed a screen point.
		''' </summary>
		Public Function GetDateFromCor(ByVal x As Integer, ByVal y As Integer) As DateTime
			Return GetDateFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the date displayed at a screen point.
		''' </summary>
		Public Function GetDateFromCor(ByVal pt As Point) As DateTime

			Dim retval As DateTime

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						'Date on Left
						Dim skew As Integer = GetIntlInteger((pt.Y - MainObject.ClientTop) \ MainObject.RowHeader.Size)
						'retval = DateAdd(DateInterval.Day, skew, Me.FirstVisibleDate)
						retval = Me.FirstVisibleDate.AddDays(skew)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
						'Date on Top
						Dim skew As Integer = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size)
						'retval = DateAdd(DateInterval.Day, skew, Me.FirstVisibleDate)
						retval = Me.FirstVisibleDate.AddDays(skew)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						retval = ScheduleGlobals.DefaultNoDate
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Dim column As Integer = Me.GetColumnFromCor(pt)
						Dim row As Integer = Me.GetRowFromCor(pt)
						Dim cellIndex As Integer
						If (column = 5) AndAlso (row Mod 2) = 1 Then
							'This is Sunday
							cellIndex = ((row \ 2) * DaysPerWeek) + column + 1
						ElseIf (column = 5) AndAlso (row Mod 2) = 0 Then
							'This is Saturday
							cellIndex = ((row \ 2) * DaysPerWeek) + column
						Else
							'This is any Mon-Fri
							cellIndex = ((row \ 2) * DaysPerWeek) + column
						End If
						Dim startOfWeek As Date = WeekModeHelper.GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
						'retval = DateAdd(DateInterval.Day, cellIndex, startOfWeek)
						retval = startOfWeek.AddDays(cellIndex)
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						If MainObject.RoomCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim column As Integer = Me.GetColumnFromCor(pt)
						Dim dayIndex As Integer = column \ MainObject.RoomCollection.VisibleCount
						'retval = DateAdd(DateInterval.Day, dayIndex, MainObject.MinDate)
						retval = MainObject.MinDate.AddDays(dayIndex)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim column As Integer = Me.GetColumnFromCor(pt)
						Dim dayIndex As Integer = column \ MainObject.ProviderCollection.VisibleCount
						'retval = DateAdd(DateInterval.Day, dayIndex, MainObject.MinDate)
						retval = MainObject.MinDate.AddDays(dayIndex)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						If MainObject.RoomCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim row As Integer = Me.GetRowFromCor(pt)
						Dim dayIndex As Integer = row \ MainObject.RoomCollection.VisibleCount
						retval = MainObject.MinDate.AddDays(dayIndex)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim row As Integer = Me.GetRowFromCor(pt)
						Dim dayIndex As Integer = row \ MainObject.ProviderCollection.VisibleCount
						retval = MainObject.MinDate.AddDays(dayIndex)
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Date on Left
						Dim skew As Integer = GetIntlInteger((pt.Y - MainObject.ClientTop) \ MainObject.RowHeader.Size)
						skew = Me.FirstVisibleRow + skew
						Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
						skew = skew \ IncPerDay
						'retval = DateAdd(DateInterval.Day, skew, MainObject.MinDate)
						retval = MainObject.MinDate.AddDays(skew)
					Case Schedule.ViewModeConstants.Week
						Dim ii As Integer = 0
						For Each rect As Rectangle In MainObject.WeekClientRectangles
							If rect.Contains(pt) Then
								Return MainObject.MinDate.AddDays(ii)
							End If
							ii += 1
						Next
						retval = ScheduleGlobals.DefaultNoDate
					Case Schedule.ViewModeConstants.MonthFull
						Dim column As Integer = Me.GetColumnFromCor(pt)
						Dim row As Integer = Me.GetRowFromCor(pt)
						Dim cellIndex As Integer
						cellIndex = (row * DaysPerWeek) + column
						Dim startOfWeek As Date = WeekModeHelper.GetStartOfWeek(MainObject.MinDate, MainObject.FirstDayOfWeek)
						'retval = DateAdd(DateInterval.Day, cellIndex, startOfWeek)
						retval = startOfWeek.AddDays(cellIndex)
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						retval = ScheduleGlobals.DefaultNoDate
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				If retval > MainObject.MaxDate Then retval = ScheduleGlobals.DefaultNoDate
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the room displayed at a screen point.
		''' </summary>
		Public Function GetRoomFromCor(ByVal x As Integer, ByVal y As Integer) As Integer
			Return GetRoomFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the room displayed at a screen point.
		''' </summary>
		Public Function GetRoomFromCor(ByVal pt As Point) As Integer

			Dim visibleIndex As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						visibleIndex = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						'Room on Left
						visibleIndex = GetIntlInteger((pt.Y - MainObject.ClientTop) \ MainObject.RowHeader.Size) + Me.FirstVisibleRoom
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
						'Room on Top
						visibleIndex = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size) + Me.FirstVisibleRoom
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						If MainObject.RoomCollection.VisibleCount = 0 Then Return -1
						Dim column As Integer = Me.GetColumnFromCor(pt)
						visibleIndex = (column Mod MainObject.RoomCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return -1
						Dim column As Integer = Me.GetColumnFromCor(pt)
						visibleIndex = (column Mod MainObject.ProviderCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						If MainObject.RoomCollection.VisibleCount = 0 Then Return -1
						Dim row As Integer = Me.GetRowFromCor(pt)
						visibleIndex = (row Mod MainObject.RoomCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return -1
						Dim row As Integer = Me.GetRowFromCor(pt)
						visibleIndex = (row Mod MainObject.ProviderCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						visibleIndex = -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						visibleIndex = -1
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Room on Top
						visibleIndex = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size) + Me.FirstVisibleRoom
					Case Schedule.ViewModeConstants.Week
						visibleIndex = -1
					Case Schedule.ViewModeConstants.MonthFull
						visibleIndex = -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				If visibleIndex = -1 Then Return -1
				If visibleIndex >= MainObject.RoomCollection.VisibleCount Then Return -1
				Dim absoluteIndex As Integer = MainObject.RoomCollection.IndexOf(CType(MainObject.RoomCollection.VisibleList(visibleIndex), Room))
				Return absoluteIndex

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the provider displayed at a screen point.
		''' </summary>
		Public Function GetProviderFromCor(ByVal x As Integer, ByVal y As Integer) As Integer
			Return GetProviderFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the provider displayed at a screen point.
		''' </summary>
		Public Function GetProviderFromCor(ByVal pt As Point) As Integer

			Dim retval As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1
					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return -1
						Dim row As Integer = Me.GetRowFromCor(pt)
						retval = (row Mod MainObject.ProviderCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return -1
						Dim column As Integer = Me.GetColumnFromCor(pt)
						retval = (column Mod MainObject.ProviderCollection.VisibleCount)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						'Provider on Left
						retval = GetIntlInteger((pt.Y - MainObject.ClientTop) \ MainObject.RowHeader.Size) + Me.FirstVisibleProvider
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						'Provider on Top
						retval = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size) + Me.FirstVisibleProvider
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						'Provider on Top
						retval = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size) + Me.FirstVisibleProvider
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = -1
					Case Schedule.ViewModeConstants.Week
						retval = -1
					Case Schedule.ViewModeConstants.MonthFull
						retval = -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				If retval = -1 Then Return -1
				If retval >= MainObject.ProviderCollection.VisibleCount Then Return -1
				Dim absoluteIndex As Integer = MainObject.ProviderCollection.IndexOf(CType(MainObject.ProviderCollection.VisibleList(retval), Provider))
				Return absoluteIndex
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the resource displayed at a screen point.
		''' </summary>
		Public Function GetResourceFromCor(ByVal x As Integer, ByVal y As Integer) As Integer
			Return GetResourceFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the resource displayed at a screen point.
		''' </summary>
		Public Function GetResourceFromCor(ByVal pt As Point) As Integer

			Dim retval As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						retval = -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						retval = -1
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = -1
					Case Schedule.ViewModeConstants.Week
						retval = -1
					Case Schedule.ViewModeConstants.MonthFull
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
						'Resource on Left
						retval = GetIntlInteger((pt.Y - MainObject.ClientTop) \ MainObject.RowHeader.Size) + Me.FirstVisibleResource
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						'Resource on Top
						retval = GetIntlInteger((pt.X - MainObject.ClientLeft) \ MainObject.ColumnHeader.Size) + Me.FirstVisibleResource
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				If retval >= MainObject.ResourceCollection.VisibleCount Then retval = -1
				Return retval
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function GetTimeFromCor(ByVal x As Integer, ByVal y As Integer, ByVal resolution As Gravitybox.Controls.Schedule.TimeIncrementConstants) As DateTime
			Return GetTimeFromCor(New Point(x, y), resolution)
		End Function

		''' <summary>
		''' Determines the time displayed at a screen point.
		''' </summary>
		Public Function GetTimeFromCor(ByVal x As Integer, ByVal y As Integer) As DateTime
			Return GetTimeFromCor(New Point(x, y), MainObject.TimeIncrement)
		End Function

		''' <summary>
		''' Determines the time displayed at a screen point.
		''' </summary>
		Public Function GetTimeFromCor(ByVal pt As Point) As DateTime
			Return GetTimeFromCor(pt, MainObject.TimeIncrement)
		End Function

		Friend Function GetTimeFromCor(ByVal pt As Point, ByVal resolution As Gravitybox.Controls.Schedule.TimeIncrementConstants) As DateTime

			Dim retval As DateTime

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = ScheduleGlobals.DefaultNoTime

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
						'Time on Left
						Dim resolutionMinutes As Integer = GetIntlInteger(resolution)
						Dim incrementsPerHour As Integer = (MinutesPerHour \ resolutionMinutes)
						Dim pixelsPerInc As Single = (MainObject.TimeIncrementsPerHour * MainObject.RowHeader.Size) / CSng(incrementsPerHour)
						Dim skew As Integer = GetIntlInteger((pt.Y - MainObject.ClientTop) / pixelsPerInc)
						If skew < 0 Then
							retval = DefaultNoTime
						Else
							retval = DateAdd(DateInterval.Minute, skew * resolutionMinutes, Me.FirstVisibleTime)
						End If

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
						'Time on Top
						Dim resolutionMinutes As Integer = GetIntlInteger(resolution)
						Dim incrementsPerHour As Integer = (MinutesPerHour \ resolutionMinutes)
						Dim pixelsPerInc As Single = (MainObject.TimeIncrementsPerHour * MainObject.ColumnHeader.Size) / CSng(incrementsPerHour)
						Dim skew As Integer = GetIntlInteger((pt.X - MainObject.ClientLeft) / pixelsPerInc)
						If skew < 0 Then
							retval = DefaultNoTime
						Else
							retval = DateAdd(DateInterval.Minute, skew * resolutionMinutes, Me.FirstVisibleTime)
						End If

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Time on Left
						Dim resolutionMinutes As Integer = GetIntlInteger(resolution)
						Dim pixelsPerInc As Single = (MainObject.TimeIncrementsPerHour * MainObject.RowHeader.Size) / CSng(MainObject.TimeIncrementsPerHour)
						Dim skew As Integer = GetIntlInteger((pt.Y - MainObject.ClientTop) / pixelsPerInc)
						Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
						skew = skew Mod IncPerDay
						If skew < 0 Then
							retval = DefaultNoTime
						Else
							retval = DateAdd(DateInterval.Minute, skew * resolutionMinutes, Me.FirstVisibleTime)
						End If

					Case Schedule.ViewModeConstants.Week
						retval = ScheduleGlobals.DefaultNoTime

					Case Schedule.ViewModeConstants.MonthFull
						retval = ScheduleGlobals.DefaultNoTime

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select

				Select Case MainObject.ViewMode
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Do Nothing
					Case Else
						'All other viewmodes that show only one day
						If retval > MainObject.EndTime Then retval = ScheduleGlobals.DefaultNoTime
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the column displayed at a screen point.
		''' </summary>
		Public Function GetColumnFromCor(ByVal x As Integer, ByVal y As Integer) As Integer
			Return GetColumnFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the column displayed at a screen point.
		''' </summary>
		Public Function GetColumnFromCor(ByVal pt As Point) As Integer

			Try
				If MainObject.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Month Then
					Dim columnWidth As Integer = ((MainObject.ClientWidth - 1) \ Me.TotalColumnCount)
					Dim column As Integer = ((pt.X - MainObject.ClientLeft) \ columnWidth)
					Return column
				Else
					Dim retval As Integer
					retval = pt.X - MainObject.ClientLeft
					If retval < 0 Then Return -1
					retval \= MainObject.ColumnHeader.Size
					retval += Me.FirstVisibleColumn
					If retval >= Me.TotalColumnCount Then retval = Me.TotalColumnCount - 1
					Return retval
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the row displayed at a screen point.
		''' </summary>
		Public Function GetRowFromCor(ByVal x As Integer, ByVal y As Integer) As Integer
			GetRowFromCor = GetRowFromCor(New Point(x, y))
		End Function

		''' <summary>
		''' Determines the row displayed at a screen point.
		''' </summary>
		Public Function GetRowFromCor(ByVal pt As Point) As Integer

			Try
				If MainObject.ViewMode = Schedule.ViewModeConstants.Month Then
					Dim rowHeight As Double = ((MainObject.ClientHeight - 1) / Me.TotalRowCount)
					Dim row As Integer = CType(Math.Floor(((pt.Y - MainObject.ClientTop) / rowHeight)), Integer)
					If GetColumnFromCor(pt) < 5 Then
						'If in the range Monday-Friday then make all even row even
						If ((row Mod 2) = 1) Then row -= 1
						Return row
					Else
						Return row
					End If

				Else
					Dim retval As Integer
					retval = pt.Y - MainObject.ClientTop
					If retval < 0 Then Return -1
					retval \= MainObject.RowHeader.Size
					retval += Me.FirstVisibleRow
					If retval >= Me.TotalRowCount Then retval = Me.TotalRowCount - 1
					Return retval

				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the date displayed in a row or column.
		''' </summary>
		''' <param name="rowcol">The method determines whether the coordinate is a row or column based on the viewmode.</param>
		Public Function GetDateFromRowCol(ByVal rowcol As Integer) As DateTime

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Return DateAdd(DateInterval.Day, rowcol, MainObject.MinDate)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return ScheduleGlobals.DefaultNoDate
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						If MainObject.RoomCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim value As Integer = (rowcol \ MainObject.RoomCollection.VisibleCount)
						Dim retval As DateTime = DateAdd(DateInterval.Day, value, MainObject.MinDate)
						If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then Return DefaultNoDate
						Dim value As Integer = (rowcol \ MainObject.ProviderCollection.VisibleCount)
						Dim retval As DateTime = DateAdd(DateInterval.Day, value, MainObject.MinDate)
						If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'TODO
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim value As Integer = (rowcol \ (MainObject.TimeIncrementsPerHour * HourPerDay))
						Dim retval As DateTime = DateAdd(DateInterval.Day, value, MainObject.MinDate)
						If retval > MainObject.MaxDate Then retval = MainObject.MaxDate
						Return retval
					Case Schedule.ViewModeConstants.Week
						Return ScheduleGlobals.DefaultNoDate
					Case Schedule.ViewModeConstants.MonthFull
						'TODO - MonthFull
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the row or column index for a date.
		''' </summary>
		''' <param name="checkDate">The date to check.</param>
		Public Function GetRowColFromDate(ByVal checkDate As DateTime) As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, checkDate))
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim retval As Integer = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, checkDate))
						retval *= MainObject.RoomCollection.VisibleCount
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Dim retval As Integer = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, checkDate))
						retval *= MainObject.ProviderCollection.VisibleCount
						Return retval
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'TODO
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
						Return GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, checkDate)) * IncPerDay
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						'TODO - MonthFull
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the time displayed in a row or column.
		''' </summary>
		''' <param name="rowcol">The method determines whether the coordinate is a row or column based on the viewmode.</param>
		Public Function GetTimeFromRowCol(ByVal rowcol As Integer) As DateTime

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return DateAdd(DateInterval.Minute, rowcol * MainObject.TimeIncrement, MainObject.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Return ScheduleGlobals.DefaultNoTime
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Return ScheduleGlobals.DefaultNoTime
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Return DateAdd(DateInterval.Minute, rowcol * MainObject.TimeIncrement, PivotTime)
					Case Schedule.ViewModeConstants.Week
						Return ScheduleGlobals.DefaultNoTime
					Case Schedule.ViewModeConstants.MonthFull
						Return ScheduleGlobals.DefaultNoTime
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the row or column index for a time.
		''' </summary>
		''' <param name="checkTime">The time to check.</param>
		Public Function GetRowColFromTime(ByVal checkTime As DateTime) As Integer
			Dim retval As Decimal = GetRowColFromTime(checkTime, MainObject.TimeIncrement)
			Return CType(Math.Floor(retval), Integer)
		End Function

		Friend Function GetRowColFromTime(ByVal checkTime As DateTime, ByVal resolution As Gravitybox.Controls.Schedule.TimeIncrementConstants) As Decimal

			Try
				Dim retval As Decimal
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						retval = DateDiff(DateInterval.Minute, MainObject.StartTime, checkTime) / CType(resolution.ToString("d"), Decimal)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						retval = -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim dayCount As Integer = GetIntlInteger(DateDiff(DateInterval.Day, PivotTime, checkTime))
						retval = (dayCount * MainObject.TimeIncrementsPerHour * HourPerDay) + DateDiff(DateInterval.Minute, PivotTime, GetTime(checkTime)) / CType(resolution.ToString("d"), Decimal)
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						retval = -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the room displayed in a row or column.
		''' </summary>
		''' <param name="rowcol">The method determines whether the coordinate is a row or column based on the viewmode.</param>
		Public Function GetRoomFromRowCol(ByVal rowcol As Integer) As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						Dim list As ArrayList = Me.MainObject.RoomCollection.VisibleList
						If (0 <= rowcol) AndAlso (rowcol < list.Count) Then
							Return Me.MainObject.RoomCollection.IndexOf(CType(list(rowcol), Room))
						End If
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						If MainObject.RoomCollection.VisibleCount = 0 Then
							Return -1
						Else
							Return (rowcol Mod MainObject.RoomCollection.VisibleCount)
						End If
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							Return -1
						Else
							Return (rowcol Mod MainObject.RoomCollection.VisibleCount)
						End If
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Return -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Return -1
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the provider displayed in a row or column.
		''' </summary>
		''' <param name="rowcol">The method determines whether the coordinate is a row or column based on the viewmode.</param>
		Public Function GetProviderFromRowCol(ByVal rowcol As Integer) As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						Dim list As ArrayList = Me.MainObject.ProviderCollection.VisibleList
						If (0 <= rowcol) AndAlso (rowcol < list.Count) Then
							Return Me.MainObject.ProviderCollection.IndexOf(CType(list(rowcol), Provider))
						End If
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						If MainObject.ProviderCollection.VisibleCount = 0 Then
							Return -1
						Else
							Return (rowcol Mod MainObject.ProviderCollection.VisibleCount)
						End If
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Return -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Return rowcol
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Return -1
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the resource displayed in a row or column.
		''' </summary>
		''' <param name="rowcol">The method determines whether the coordinate is a row or column based on the viewmode.</param>
		Public Function GetResourceFromRowCol(ByVal rowcol As Integer) As Integer

			Try
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Return -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Return -1
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Return -1
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Dim list As ArrayList = Me.MainObject.ResourceCollection.VisibleList
						If (0 <= rowcol) AndAlso (rowcol < list.Count) Then
							Return Me.MainObject.ResourceCollection.IndexOf(CType(list(rowcol), Resource))
						End If
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "GetCorFrom..."

		''' <summary>
		''' Determines the screen coordinate from the date.
		''' </summary>
		''' <param name="theDate">The date to check</param>
		''' <remarks>The coordinate returned is the left or top most pixel for the starting column or row. Whether it is a row or column is determined by the viewmode.</remarks>
		Public Function GetCorFromDate(ByVal theDate As DateTime) As Integer

			Try
				Dim retval As Integer
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval *= MainObject.RoomCollection.VisibleCount
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval *= MainObject.ProviderCollection.VisibleCount
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval *= MainObject.RoomCollection.VisibleCount
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval *= MainObject.ProviderCollection.VisibleCount
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'TODO
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Schedule.ViewModeConstants.Week
						Return -1
					Case Schedule.ViewModeConstants.MonthFull
						'TODO - MonthFull
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the screen coordinate from the time.
		''' </summary>
		''' <param name="theTime">The time to check</param>
		''' <remarks>The coordinate returned is the left or top most pixel for the starting column or row. Whether it is a row or column is determined by the viewmode.</remarks>
		Public Function GetCorFromTime(ByVal theTime As DateTime) As Integer

			Try
				Dim retval As Integer
				theTime = TruncateTimeToInterval(theTime, MainObject.TimeIncrement)
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
						retval = GetIntlInteger(DateDiff(DateInterval.Minute, Me.FirstVisibleTime, theTime))
						retval \= MainObject.TimeIncrement
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
						retval = GetIntlInteger(DateDiff(DateInterval.Minute, Me.FirstVisibleTime, theTime))
						retval \= MainObject.TimeIncrement
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						While Me.FirstVisibleTime > theTime
							theTime = theTime.AddDays(1)
						End While
						retval = GetIntlInteger(DateDiff(DateInterval.Minute, Me.FirstVisibleTime, theTime))
						retval \= MainObject.TimeIncrement
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)

					Case Schedule.ViewModeConstants.Week
						retval = -1

					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the screen coordinate from the room.
		''' </summary>
		''' <param name="room">The room to check</param>
		''' <remarks>The coordinate returned is the left or top most pixel for the starting column or row. Whether it is a row or column is determined by the viewmode.</remarks>
		Public Function GetCorFromRoom(ByVal room As Room) As Integer

			Try
				Dim retval As Integer
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						retval = MainObject.RoomCollection.IndexOfVisible(room)
						If retval = -1 Then Return retval 'There is no such room
						retval = retval - Me.FirstVisibleRoom
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
						retval = MainObject.RoomCollection.IndexOfVisible(room)
						If retval = -1 Then Return retval 'There is no such room
						retval = retval - Me.FirstVisibleRoom
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						retval = -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						retval = -1
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = MainObject.RoomCollection.IndexOfVisible(room)
						If retval = -1 Then Return retval 'There is no such room
						retval = retval - Me.FirstVisibleRoom
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
					Case Schedule.ViewModeConstants.Week
						retval = -1
					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the screen coordinate from the provider.
		''' </summary>
		''' <param name="provider">The provider to check</param>
		''' <remarks>The coordinate returned is the left or top most pixel for the starting column or row. Whether it is a row or column is determined by the viewmode.</remarks>
		Public Function GetCorFromProvider(ByVal provider As Provider) As Integer

			Try
				Dim retval As Integer
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1
					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						retval = MainObject.ProviderCollection.IndexOfVisible(provider)
						If retval = -1 Then Return retval 'There is no such provider
						retval = retval - Me.FirstVisibleProvider
						retval = MainObject.ClientTop + (retval * MainObject.RowHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						retval = MainObject.ProviderCollection.IndexOfVisible(provider)
						If retval = -1 Then Return retval 'There is no such provider
						retval = retval - Me.FirstVisibleProvider
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)
						'***********************************************************
						'THIS IS THE SAME AS THE PROVIDERTOP CASE. CHANGE PRODUCTION
						'***********************************************************
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						retval = MainObject.ProviderCollection.IndexOfVisible(provider)
						If retval = -1 Then Return retval 'There is no such provider
						retval = retval - Me.FirstVisibleProvider
						retval = MainObject.ClientLeft + (retval * MainObject.ColumnHeader.Size)

					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						retval = -1

					Case Schedule.ViewModeConstants.Week
						retval = -1

					Case Schedule.ViewModeConstants.MonthFull
						Return -1

					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Determines the screen coordinate from the date and room. Used for viemodes with date and rooms on the same axis.
		''' </summary>
		''' <param name="theDate">The date to check</param>
		''' <param name="room">The room to check.</param>
		''' <remarks>The coordinate returned is the left or top most pixel for the starting column or row. Whether it is a row or column is determined by the viewmode.</remarks>
		Public Function GetCorFromDateRoom(ByVal theDate As DateTime, ByVal room As Room) As Integer

			Try
				Dim retval As Integer
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						retval = -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						Dim roomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(room)
						If roomIndex = -1 Then Return -1 'There is no such room
						Dim dateIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						Dim roomSkew As Integer = Me.FirstVisibleColumn Mod MainObject.RoomCollection.VisibleCount
						Dim index As Integer = ((dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex) - roomSkew
						retval = MainObject.ClientLeft + (index * MainObject.ColumnHeader.Size)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim roomIndex As Integer = MainObject.RoomCollection.IndexOfVisible(room)
						If roomIndex = -1 Then Return -1 'There is no such room
						Dim dateIndex As Integer = GetIntlInteger(DateDiff(DateInterval.Day, Me.FirstVisibleDate, theDate))
						Dim roomSkew As Integer = Me.FirstVisibleRow Mod MainObject.RoomCollection.VisibleCount
						Dim index As Integer = ((dateIndex * MainObject.RoomCollection.VisibleCount) + roomIndex) - roomSkew
						retval = MainObject.ClientTop + (index * MainObject.RowHeader.Size)
					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Return -1
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Return -1
					Case Schedule.ViewModeConstants.Week
						retval = -1
					Case Schedule.ViewModeConstants.MonthFull
						Return -1
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						Return -1
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function GetRemainderRowPercentFromTime(ByVal checkTime As DateTime) As Double

			Try
				Dim remainder As Integer = checkTime.Minute Mod MainObject.TimeIncrementValue
				Return remainder / CDbl(MainObject.TimeIncrementValue)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "Show Methods"

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowDate(ByVal newDate As DateTime) As Boolean

			Try
				newDate = GetDate(newDate)
				If newDate < MainObject.MinDate Then Return False
				If newDate > MainObject.MaxDate Then Return False
				MainObject.DrawingDirty = True
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						'Do Nothing
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))
						value *= MainObject.RoomCollection.VisibleCount

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))
						value *= MainObject.ProviderCollection.VisibleCount

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))
						value *= MainObject.RoomCollection.VisibleCount

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))
						value *= MainObject.ProviderCollection.VisibleCount

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'Do Nothing
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Day, MainObject.MinDate, newDate))
						value *= (MainObject.TimeIncrementsPerHour * HourPerDay)

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value
					Case Schedule.ViewModeConstants.Week
						'Do Nothing
					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						'Do Nothing
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowTime(ByVal newTime As DateTime) As Boolean

			Try
				newTime = GetTime(newTime, True)
				If newTime < MainObject.StartTime Then Return False
				If newTime > MainObject.EndTime Then Return False
				MainObject.DrawingDirty = True
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.ResourceLeftTimeTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, newTime)) \ MainObject.TimeIncrement

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Schedule.ViewModeConstants.DayProviderTopTimeLeft, Schedule.ViewModeConstants.ResourceTopTimeLeft
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Minute, MainObject.StartTime, newTime)) \ MainObject.TimeIncrement

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop, Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim value As Integer
						value = GetIntlInteger(DateDiff(DateInterval.Minute, PivotTime, newTime)) \ MainObject.TimeIncrement
						Dim IncPerDay As Integer = (MainObject.TimeIncrementsPerHour * HourPerDay)
						Dim dayBefore As Integer = FirstVisibleRow \ IncPerDay
						value = (dayBefore * IncPerDay) + value
						If value < 0 Then value = 0

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'Do Nothing

					Case Schedule.ViewModeConstants.Week
						'Do Nothing

					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowRoom(ByVal room As Room) As Boolean

			Try
				If Not (room Is Nothing) Then
					Return ShowRoom(MainObject.RoomCollection.IndexOfVisible(room))
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowRoom(ByVal key As String) As Boolean

			Try
				Return ShowRoom(MainObject.ResolveRoom(key))
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowRoom(ByVal index As Integer) As Boolean

			Try
				If index < 0 Then Return False
				If index >= MainObject.RoomCollection.VisibleCount Then Return False
				MainObject.DrawingDirty = True
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						Dim value As Integer = index

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
						Dim value As Integer = index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
						Dim col As Integer = MainObject.HScroll1.Value
						'Round to nearest room and add the room number
						col = col - (col Mod MainObject.RoomCollection.VisibleCount) + index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((col Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							col = col \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then col += 1
						End If

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						'Do Nothing
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Dim value As Integer = index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Dim row As Integer = MainObject.VScroll1.Value
						'Round to nearest room and add the room number
						row = row - (row Mod MainObject.RoomCollection.VisibleCount) + index

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((row Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							row = row \ MainObject.RowHeader.FrameIncrementActual
							If skew Then row += 1
						End If

						If row > MainObject.VScroll1.Maximum Then Return False
						If row < MainObject.VScroll1.Minimum Then Return False
						MainObject.VScroll1.Value = row

					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						Dim col As Integer = MainObject.HScroll1.Value
						'Round to nearest room and add the room number
						col = col - (col Mod MainObject.RoomCollection.VisibleCount) + index
						If col > MainObject.HScroll1.Maximum Then Return False
						If col < MainObject.HScroll1.Minimum Then Return False
						MainObject.HScroll1.Value = col

					Case Schedule.ViewModeConstants.Week
						'Do Nothing

					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						'Do Nothing

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowProvider(ByVal provider As Provider) As Boolean

			Try
				If Not (provider Is Nothing) Then
					Return ShowProvider(MainObject.ProviderCollection.IndexOfVisible(provider))
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowProvider(ByVal key As String) As Boolean

			Try
				Return ShowProvider(MainObject.ResolveProvider(key))
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowProvider(ByVal index As Integer) As Boolean

			Try
				If index < 0 Then Return False
				If index >= MainObject.ProviderCollection.VisibleCount Then Return False
				MainObject.DrawingDirty = True
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						Dim value As Integer = index

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						Dim value As Integer = index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Dim value As Integer = index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Dim row As Integer = MainObject.VScroll1.Value
						'Round to nearest Provider and add the Provider number
						row = row - (row Mod MainObject.ProviderCollection.VisibleCount) + index

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((row Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							row = row \ MainObject.RowHeader.FrameIncrementActual
							If skew Then row += 1
						End If

						If row > MainObject.VScroll1.Maximum Then Return False
						If row < MainObject.VScroll1.Minimum Then Return False
						MainObject.VScroll1.Value = row

					Case Schedule.ViewModeConstants.DayProviderTopTimeLeft
						Dim col As Integer = MainObject.HScroll1.Value
						'Round to nearest Provider and add the Provider number
						col = col - (col Mod MainObject.ProviderCollection.VisibleCount) + index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((col Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							col = col \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then col += 1
						End If

						If col > MainObject.HScroll1.Maximum Then Return False
						If col < MainObject.HScroll1.Minimum Then Return False
						MainObject.VScroll1.Value = col

					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'Do Nothing

					Case Schedule.ViewModeConstants.Week
						'Do Nothing

					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowResource(ByVal resource As Resource) As Boolean

			Try
				If Not (resource Is Nothing) Then
					Return ShowResource(MainObject.ResourceCollection.IndexOfVisible(resource))
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowResource(ByVal key As String) As Boolean

			Try
				Return ShowResource(MainObject.ResolveResource(key))
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' 
		''' </summary>
		Public Function ShowResource(ByVal index As Integer) As Boolean

			Try
				If index <= 0 Then Return False
				If index > MainObject.ResourceCollection.Count Then Return False
				MainObject.DrawingDirty = True
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						'Do Nothing

					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						'Do Nothing

					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						'Do Nothing

					Case Schedule.ViewModeConstants.DayProviderLeftTimeTop, Schedule.ViewModeConstants.DayProviderTopTimeLeft
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'Do Nothing

					Case Schedule.ViewModeConstants.Week
						'Do Nothing

					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing

					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
						Dim value As Integer = index

						If MainObject.RowHeader.AutoFit AndAlso (MainObject.RowHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.RowHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.RowHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.VScroll1.Maximum Then value = MainObject.VScroll1.Maximum
						MainObject.VScroll1.Value = value

					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Dim value As Integer = index

						If MainObject.ColumnHeader.AutoFit AndAlso (MainObject.ColumnHeader.FrameIncrementActual > 0) Then
							Dim skew As Boolean = ((value Mod MainObject.ColumnHeader.FrameIncrementActual) <> 0)
							value = value \ MainObject.ColumnHeader.FrameIncrementActual
							If skew Then value += 1
						End If

						If value > MainObject.HScroll1.Maximum Then value = MainObject.HScroll1.Maximum
						MainObject.HScroll1.Value = value

					Case Else
						Call ErrorModule.ViewmodeErr()

				End Select
				Return True
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Ensures that the specified appointment is inside the viewport, if possible.
		''' </summary>
		Public Function ShowAppointment(ByVal appointment As Appointment) As Boolean

			Try
				If MainObject.AppointmentCollection.IndexOf(appointment) = -1 Then Return False
				Select Case MainObject.ViewMode
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop
						Call ShowDate(appointment.StartDate)
						Call ShowTime(appointment.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop
						Call ShowDate(appointment.StartDate)
						Call ShowRoom(appointment.Room)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop
						Call ShowDate(appointment.StartDate)
						If appointment.ProviderList.Count > 0 Then Call ShowProvider(CType(appointment.ProviderList(0), Provider))
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
						Call ShowDate(appointment.StartDate)
						If appointment.ResourceList.Count > 0 Then Call ShowResource(CType(appointment.ResourceList(0), Resource))
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
						Call ShowDate(appointment.StartDate)
						Call ShowRoom(appointment.Room)
						Call ShowTime(appointment.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
						Call ShowDate(appointment.StartDate)
						If appointment.ProviderList.Count > 0 Then
							Call ShowProvider(CType(appointment.ProviderList(0), Provider))
						End If
						Call ShowTime(appointment.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
						Call ShowRoom(appointment.Room)
						Call ShowTime(appointment.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
						Call ShowRoom(appointment.Room)
						If appointment.ProviderList.Count > 0 Then Call ShowProvider(CType(appointment.ProviderList(0), Provider))
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
						If appointment.ProviderList.Count > 0 Then Call ShowProvider(CType(appointment.ProviderList(0), Provider))
						Call ShowTime(appointment.StartTime)
					Case Gravitybox.Controls.Schedule.ViewModeConstants.Month
						'Do Nothing
					Case Schedule.ViewModeConstants.DayTimeLeftProviderTop
						Call ShowDate(appointment.StartDate)
						Call ShowTime(appointment.StartTime)
						If appointment.ProviderList.Count > 0 Then Call ShowProvider(CType(appointment.ProviderList(0), Provider))
					Case Schedule.ViewModeConstants.DayTimeLeftRoomTop
						Call ShowDate(appointment.StartDate)
						Call ShowTime(appointment.StartTime)
						Call ShowRoom(appointment.Room)
					Case Schedule.ViewModeConstants.Week
						Call ShowDate(appointment.StartDate)
					Case Schedule.ViewModeConstants.MonthFull
						'Do Nothing
					Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
						If appointment.ResourceList.Count > 0 Then Call ShowResource(CType(appointment.ResourceList(0), Resource))
						Call ShowTime(appointment.StartTime)
					Case Else
						Call ErrorModule.ViewmodeErr()
				End Select
				Return True

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		''' <summary>
		''' Ensures that the specified appointment is inside the viewport, if possible.
		''' </summary>
		Public Function ShowAppointment(ByVal key As String) As Boolean
			If Not MainObject.AppointmentCollection.Contains(key) Then Return False
			Return ShowAppointment(MainObject.AppointmentCollection(key))
		End Function

		''' <summary>
		''' Ensures that the specified appointment is inside the viewport, if possible.
		''' </summary>
		Public Function ShowAppointment(ByVal index As Integer) As Boolean
			Return ShowAppointment(index)
		End Function

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			MainObject = Nothing
		End Sub

#End Region

	End Class

End Namespace