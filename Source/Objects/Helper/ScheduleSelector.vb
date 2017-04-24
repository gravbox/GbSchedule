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

Namespace Gravitybox.Objects

  Public Class ScheduleSelector
		Implements IDisposable

#Region "Class Members"

    'Property Variables
    Private m_Column As Integer = 0
    Private m_Row As Integer = 0
    Private m_Length As Integer = 1
    Private MainObject As Gravitybox.Controls.Schedule
		Private m_Appearance As New Gravitybox.Objects.Appearance
		Friend NoScroll As Boolean = False

    ''' <summary>
    ''' Occurs when a property of this object changes that requires the schedule to be repainted.
    ''' </summary>
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Constructor"

    Friend Sub New(ByVal mainobject As Gravitybox.Controls.Schedule)
      Me.MainObject = mainobject
      Appearance.BackColor = SystemColors.Highlight
      AddHandler m_Appearance.Refresh, AddressOf OnRefresh
    End Sub

#End Region

#Region "On... Event Methods"

    Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Refresh(sender, e)
    End Sub

    Private Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      RaiseEvent Refresh(sender, New System.EventArgs)
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' This is the starting column of the selector.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(0), _
    Description("This is the starting column of the selector.")> _
    Public Property Column() As Integer
      Get
        Return m_Column
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        If Value > MainObject.Visibility.TotalColumnCount - 1 Then Value = MainObject.Visibility.TotalColumnCount - 1
        m_Column = Value
        If Not NoScroll Then
          If (Column < MainObject.Visibility.FirstVisibleColumn) Then MainObject.Visibility.FirstVisibleColumn = Column
          If (Column >= (MainObject.Visibility.FirstVisibleColumn + MainObject.Visibility.VisibleColumns)) Then MainObject.Visibility.FirstVisibleColumn = Column - MainObject.Visibility.VisibleColumnsNoCorrection + 2
        End If
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    ''' <summary>
    ''' This is the starting row of the selector.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(0), _
    Description("This is the starting row of the selector.")> _
    Public Property Row() As Integer
      Get
        Return m_Row
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        If Value > MainObject.Visibility.TotalRowCount - 1 Then Value = MainObject.Visibility.TotalRowCount - 1
        m_Row = Value
        If Not NoScroll Then
          If (Row < MainObject.Visibility.FirstVisibleRow) Then MainObject.Visibility.FirstVisibleRow = Row
          If (Row >= (MainObject.Visibility.FirstVisibleRow + MainObject.Visibility.VisibleRows)) Then MainObject.Visibility.FirstVisibleRow = Row - MainObject.Visibility.VisibleRowsNoCorrection + 2
        End If
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    ''' <summary>
    ''' This is the number of cells that the selector covers.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(1), _
    Description("This is the number of cells that the selector covers.")> _
    Public Property Length() As Integer
      Get
        Return m_Length
      End Get
      Set(ByVal Value As Integer)
        If Value <= 0 Then Value = 1
        m_Length = Value
        OnRefresh(Me, New System.EventArgs)
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
        RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
        m_Appearance = Value
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    Public ReadOnly Property StartDate() As Date
      Get
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return DateAdd(DateInterval.Day, Me.Column, MainObject.MinDate)
          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return DateAdd(DateInterval.Day, Me.Row, MainObject.MinDate)
          Case Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            Else
              Return DateAdd(DateInterval.Day, Me.Column \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            Else
              Return DateAdd(DateInterval.Day, Me.Row \ MainObject.RoomCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.Month
            Return Me.MainObject.Visibility.FirstVisibleDate.AddDays((CInt(Me.Row / 2) * DaysPerWeek) + Me.Column + CInt(IIf(Me.Row Mod 2 = 1, 1, 0)))
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
            Return DateAdd(DateInterval.Day, Me.Row \ IncPerDay, MainObject.MinDate)
          Case Controls.Schedule.ViewModeConstants.Week
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.MonthFull
            Return Me.MainObject.Visibility.FirstVisibleDate.AddDays((Me.Row * DaysPerWeek) + Me.Column)
          Case Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return DefaultNoDate
          Case Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            Else
              Return DateAdd(DateInterval.Day, Me.Row \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return DefaultNoDate
            Else
              Return DateAdd(DateInterval.Day, Me.Column \ MainObject.ProviderCollection.VisibleCount, MainObject.MinDate)
            End If
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    Public ReadOnly Property StartTime() As Date
      Get
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return DateAdd(DateInterval.Minute, Me.Row * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
          Case Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            Return DateAdd(DateInterval.Minute, Me.Column * GetIntlInteger(MainObject.TimeIncrement), MainObject.StartTime)
          Case Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.Month
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Dim IncPerDay As Integer = MainObject.TimeIncrementsPerHour * HourPerDay
            Dim modValue As Integer = Me.Row Mod IncPerDay
            Return DateAdd(DateInterval.Minute, modValue * MainObject.TimeIncrementValue, PivotTime)
          Case Controls.Schedule.ViewModeConstants.Week
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.MonthFull
            Return DefaultNoTime
          Case Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return DefaultNoTime
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    Public ReadOnly Property StartRoom() As Room
      Get
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return CType(Me.MainObject.RoomCollection.VisibleList.Item(Me.Row), Room)
          Case Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return CType(Me.MainObject.RoomCollection.VisibleList.Item(Me.Column), Room)
          Case Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return Nothing
            Else
              Return CType(Me.MainObject.RoomCollection.VisibleList.Item((Me.Column Mod MainObject.RoomCollection.VisibleCount)), Room)
            End If
          Case Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            If MainObject.RoomCollection.VisibleCount = 0 Then
              Return Nothing
            Else
              Return CType(Me.MainObject.RoomCollection.VisibleList.Item((Me.Row Mod MainObject.RoomCollection.VisibleCount)), Room)
            End If
          Case Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.Month
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
          Case Controls.Schedule.ViewModeConstants.Week
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.MonthFull
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return Nothing
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    Public ReadOnly Property StartProvider() As Provider
      Get
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return CType(Me.MainObject.ProviderCollection.VisibleList.Item(Me.Row), Provider)
          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return CType(Me.MainObject.ProviderCollection.VisibleList.Item(Me.Column), Provider)
          Case Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.Month
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.Week
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.MonthFull
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return Nothing
            Else
              Return CType(Me.MainObject.ProviderCollection.VisibleList.Item((Me.Row Mod MainObject.ProviderCollection.VisibleCount)), Provider)
            End If
          Case Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            If MainObject.ProviderCollection.VisibleCount = 0 Then
              Return Nothing
            Else
              Return CType(Me.MainObject.ProviderCollection.VisibleList.Item((Me.Column Mod MainObject.ProviderCollection.VisibleCount)), Provider)
            End If
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

    Public ReadOnly Property StartResource() As Resource
      Get
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTopRoomLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTopProviderLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftRoomTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayLeftProviderTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomTopProviderLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.RoomLeftProviderTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.Month
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.Week
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.MonthFull
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft, Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            Return CType(Me.MainObject.ResourceCollection.VisibleList.Item(Me.Row), Resource)
          Case Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Return CType(Me.MainObject.ResourceCollection.VisibleList.Item(Me.Row), Resource)
          Case Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop
            Return Nothing
          Case Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            Return Nothing
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select
      End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub ExpandToCoordinate(ByVal pt As Point)
      Call ExpandToCoordinate(pt.X, pt.Y)
    End Sub

    Friend Sub ExpandToCoordinate(ByVal x As Integer, ByVal y As Integer)

      Try
        'If the <CTRL> key was pressed then make the selected area bigger (if possible)
        Dim newLength As Integer
        Select Case MainObject.ViewMode
          Case Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft, Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop, Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            Dim newRow As Integer = Me.MainObject.Visibility.GetRowFromCor(x, y) - Me.Row + 1
            Dim newColumn As Integer = Me.MainObject.Visibility.GetColumnFromCor(x, y)
            If Me.Column = newColumn Then
              newLength = newRow
              If newLength > 0 Then Me.Length = newLength
            ElseIf Me.Column < newColumn Then
              'TODO - Multiday Select
            End If

          Case Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop
            Dim newRow As Integer = Me.MainObject.Visibility.GetRowFromCor(x, y)
            Dim newColumn As Integer = Me.MainObject.Visibility.GetColumnFromCor(x, y) - Me.Column + 1
            If Me.Row = newRow Then
              newLength = newColumn
              If newLength > 0 Then Me.Length = newLength
            Else
              'TODO - Multiday Select
            End If

          Case Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            'Do Nothing
          Case Controls.Schedule.ViewModeConstants.Month
            'TODO
          Case Controls.Schedule.ViewModeConstants.MonthFull
            'TODO - MonthFull
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			Appearance = Nothing
			MainObject = Nothing
		End Sub

#End Region

  End Class

End Namespace