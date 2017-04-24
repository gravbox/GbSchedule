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

  Friend Class AppointmentReminder

#Region "Class Members"

    'Private Property Variables
		Private _dialogSettings As TimeSettings

#End Region

#Region "Constructor"

    Friend Sub New(ByVal dialogSettings As TimeSettings)
			_dialogSettings = dialogSettings
    End Sub

#End Region

#Region "Methods"

    'This will load the a reminder combobox
    Friend Sub LoadReminderCombo(ByVal combo As ComboBox)

      Try
        Call combo.Items.Clear()
				Call AddDurationItem(0, combo)
				Call AddDurationItem(5, combo)
				Call AddDurationItem(10, combo)
				Call AddDurationItem(15, combo)
				Call AddDurationItem(30, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 1, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 2, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 3, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 4, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 5, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 6, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 7, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 8, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 9, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 10, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 11, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerHour * 12, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerDay * 1, combo)
				Call AddDurationItem(ScheduleGlobals.MinutesPerDay * 2, combo)
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend Sub LoadDurationCombo(ByVal combo As ComboBox)
			Me.LoadDurationCombo(combo, False)
		End Sub

		'This will load the a duration combobox
		Friend Sub LoadDurationCombo(ByVal combo As ComboBox, ByVal forceSmallest As Boolean)

      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
			'Debug.WriteLine("LoadDurationCombo:Begin")
      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

			Try
				Dim increment As Integer = GetIntlInteger(Me.DialogSettings.TimeIncrement)
				Dim IncsPerDay As Integer = (HourPerDay * MinutesPerHour) \ increment

				Call combo.Items.Clear()
				For ii As Integer = 1 To IncsPerDay - 2
					Call AddDurationItem(ii * increment, combo, True)
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
			'Debug.WriteLine("LoadDurationCombo:End")
      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

		End Sub

		Friend Sub LoadTimeCombo(ByVal combo As ComboBox)

			Try
				Dim increment As Integer = GetIntlInteger(Me.DialogSettings.TimeIncrement)
				Dim IncsPerDay As Integer = (HourPerDay * MinutesPerHour) \ increment
				Dim startTime As Date = #12:00:00 AM#

				Call combo.Items.Clear()
				For ii As Integer = 0 To IncsPerDay - 1
					Call AddTimeItem(startTime.AddMinutes(ii * increment), combo)
				Next

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Function AddTimeItem(ByVal startTime As Date, ByVal combo As ComboBox) As Integer

			Try
				'Loop and determine if the specified value exists in the list
				Dim dateObject As InternalTime = New InternalTime(startTime, Me.TimeFormat)
				For ii As Integer = 0 To combo.Items.Count - 1
					Dim currentTime As Date = CType(combo.Items(ii), InternalTime).TimeValue
					If currentTime = startTime Then
						'This item is already added
						Return ii
					ElseIf (currentTime > startTime) AndAlso (startTime > #12:00:00 AM#) Then
						'This item is NOT in the list so add it
						Call combo.Items.Insert(ii, dateObject)
						Return ii
					ElseIf currentTime > startTime Then
						'Add to the actual list at this position
						Call combo.Items.Insert(ii + 1, dateObject)
						Return ii
					End If
				Next

				'Otherwise just tack on the end
				Call combo.Items.Add(dateObject)
				Return (combo.Items.Count - 1)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Private Function AddDurationItem(ByVal minuteLength As Integer, ByVal combo As ComboBox) As Integer
			Return AddDurationItem(minuteLength, combo, False)
		End Function

		Private Function AddDurationItem(ByVal minuteLength As Integer, ByVal combo As ComboBox, ByVal forceSmallest As Boolean) As Integer

			Dim minutes As Integer
			Dim hours As Integer
			Dim days As Integer
      Dim text As String = ""

			'Error check. Negative numbers are allowed BUT NOT from the GUI
			'If set programaticaly then this will signify a reminder AFTER
			'the appointment has past; however this is NOT an option from the GUI
			If minuteLength < 0 Then Return 0

      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
			Dim debugStartTime As Date = Now
      'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

			Try
				'Parse into minutes/hours/days buckets
				minutes = minuteLength
				days = minutes \ ScheduleGlobals.MinutesPerDay
				minutes = minutes Mod ScheduleGlobals.MinutesPerDay
				hours = minutes \ ScheduleGlobals.MinutesPerHour
				minutes = minutes Mod ScheduleGlobals.MinutesPerHour

				Dim setterCount As Integer = 0
				If days > 0 Then setterCount += 1
				If hours > 0 Then setterCount += 1
				If minutes > 0 Then setterCount += 1

				'Build the display string
				'If days > 0 Then
				'	text = days.ToString & " " & CStr(IIf(days = 1, DialogSettings.DayTextSingular, DialogSettings.DayTextPlural))
				'ElseIf hours > 0 Then
				'	text = hours.ToString & " " & CStr(IIf(hours = 1, DialogSettings.HourTextSingular, DialogSettings.HourTextPlural))
				'ElseIf minutes >= 0 Then
				'	text = minutes.ToString & " " & CStr(IIf(minutes = 1, DialogSettings.MinuteTextSingular, DialogSettings.MinuteTextPlural))
				'Else
				'	text = ""
				'End If

				If (setterCount > 1) OrElse forceSmallest Then
					text = minuteLength.ToString & " " & CStr(IIf(minuteLength = 1, DialogSettings.MinuteTextSingular, DialogSettings.MinuteTextPlural))
				ElseIf minutes > 0 Then
					text = minutes.ToString & " " & CStr(IIf(minutes = 1, DialogSettings.MinuteTextSingular, DialogSettings.MinuteTextPlural))
				ElseIf hours > 0 Then
					text = hours.ToString & " " & CStr(IIf(hours = 1, DialogSettings.HourTextSingular, DialogSettings.HourTextPlural))
				ElseIf days > 0 Then
					text = days.ToString & " " & CStr(IIf(days = 1, DialogSettings.DayTextSingular, DialogSettings.DayTextPlural))
				Else
					text = minuteLength.ToString & " " & CStr(IIf(minuteLength = 1, DialogSettings.MinuteTextSingular, DialogSettings.MinuteTextPlural))
				End If

				'Loop and determine if the specified value exists in the list 
				Dim ii As Integer
				Dim value As Integer = GetDurationValue(text)
				For ii = 0 To combo.Items.Count - 1
					If GetDurationValue(CStr(combo.Items(ii))) = value Then
						'This item is already added
						Return ii
					ElseIf (GetDurationValue(CStr(combo.Items(ii))) > value) AndAlso (value > 0) Then
						'This item is NOT in the list so add it
						Call combo.Items.Insert(ii, text)
						Return ii
					ElseIf GetDurationValue(CStr(combo.Items(ii))) > value Then
						'Add to the actual list at this position
						Call combo.Items.Insert(ii + 1, text)
						Return ii
					End If
				Next

				'Otherwise just tack on the end
				Call combo.Items.Add(text)
				Return (combo.Items.Count - 1)

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      Finally
        'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
				Dim debugEndTime As Date = Now
				'Debug.WriteLine("AddDurationItem:" & debugEndTime.Subtract(debugStartTime).TotalMilliseconds.ToString())
        'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
      End Try

		End Function

		Friend Function GetDurationValue(ByVal text As String) As Integer

			Dim numberValue As String = ""
			Dim ii As Integer = 0
			Dim found As Boolean = False
			Dim multiplier As Integer = 1

			'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
			Dim debugStartTime As Date = Now
			Dim debugEndTime As Date = Now
			'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP

			Try
				'Find the first number
				For ii = 0 To text.Length - 1
					Dim c As Char = text.Chars(ii)
					If ScheduleGlobals.IsNumeric(c) Then
						numberValue &= c
					ElseIf found Then
						'If the letter is NOT numeric and we have found at 
						'least one numeric then we have found our number
						Exit For
					End If
				Next
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

			debugEndTime = Now
			'Debug.WriteLine("GetDurationValue1:" & debugEndTime.Subtract(debugStartTime).TotalMilliseconds.ToString())
			debugStartTime = Now

			Try
				'Just in case default to the number 1 
				If Not IsNumeric(numberValue) Then numberValue = "1"

				'For processing ease
				numberValue = CStr(GetIntlInteger(numberValue))

				'Get the multiplier (number of minutes)
				If CBool(InStr(text, DialogSettings.MinuteTextSingular, CompareMethod.Text) > 0) Then
					multiplier = 1
				ElseIf CBool(InStr(text, DialogSettings.HourTextSingular, CompareMethod.Text) > 0) Then
					multiplier = ScheduleGlobals.MinutesPerHour
				ElseIf CBool(InStr(text, DialogSettings.DayTextSingular, CompareMethod.Text) > 0) Then
					multiplier = ScheduleGlobals.MinutesPerDay
				ElseIf CBool(InStr(text, DialogSettings.MinuteTextPlural, CompareMethod.Text) > 0) Then
					multiplier = 1
				ElseIf CBool(InStr(text, DialogSettings.HourTextPlural, CompareMethod.Text) > 0) Then
					multiplier = ScheduleGlobals.MinutesPerHour
				ElseIf CBool(InStr(text, DialogSettings.DayTextPlural, CompareMethod.Text) > 0) Then
					multiplier = ScheduleGlobals.MinutesPerDay
				Else
					multiplier = 1
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

			debugEndTime = Now
			'Debug.WriteLine("GetDurationValue2:" & debugEndTime.Subtract(debugStartTime).TotalMilliseconds.ToString())
			debugStartTime = Now

			Try
				'Return the numeric value
				Return (multiplier * GetIntlInteger(numberValue))
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			Finally
				'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
				debugEndTime = Now
				'Debug.WriteLine("GetDurationValue3:" & debugEndTime.Subtract(debugStartTime).TotalMilliseconds.ToString())
				debugStartTime = Now
				'TEMPTEMPTEMPTEMPTEMPTEMPTEMPTEMP
			End Try

		End Function

		Private Function Exists(ByVal value As Integer, ByVal combo As ComboBox) As Boolean

			'Loop and determine if the specified value exists in the list 
			Dim ii As Integer
			For ii = 0 To combo.Items.Count - 1
				If Me.GetDurationValue(CStr(combo.Items(ii))) = value Then
					Return True
				End If
			Next
			Return False

		End Function

		Private Function Exists(ByVal value As Date, ByVal combo As ComboBox) As Boolean

			'Loop and determine if the specified value exists in the list 
			Dim ii As Integer
			For ii = 0 To combo.Items.Count - 1
				If CType(combo.Items(ii), InternalTime).TimeValue = value Then
					Return True
				End If
			Next
			Return False

		End Function

		Friend Sub SetItem(ByVal text As String, ByVal combo As ComboBox)
			Me.SetItem(text, combo, False)
		End Sub

		Friend Sub SetItem(ByVal text As String, ByVal combo As ComboBox, ByVal forceSmallest As Boolean)

			Try
				Dim value As Integer = Me.GetDurationValue(text)
				Dim index As Integer = AddDurationItem(value, combo, forceSmallest)
				If (0 <= index) And (index <= combo.Items.Count - 1) Then
					combo.SelectedItem = combo.Items(index)
				Else
					combo.SelectedItem = Nothing
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

		Friend Sub SetItem(ByVal theDate As Date, ByVal combo As ComboBox)

			Try
				Dim index As Integer = Me.AddTimeItem(theDate, combo)
				If (0 <= index) And (index <= combo.Items.Count - 1) Then
					combo.SelectedItem = combo.Items(index)
				Else
					combo.SelectedItem = Nothing
				End If
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

#End Region

#Region "Property Implementations"

		Private ReadOnly Property TimeFormat() As String
			Get
				If Me.DialogSettings.ClockSetting = Controls.Schedule.ClockSettingConstants.Clock12 Then
					Return DefaultClockSetting12Hour
				ElseIf Me.DialogSettings.ClockSetting = Controls.Schedule.ClockSettingConstants.Clock24 Then
					Return DefaultClockSetting24Hour
				End If
        Return Nothing
      End Get
		End Property

		Friend ReadOnly Property DialogSettings() As TimeSettings
			Get
				Return _dialogSettings
			End Get
		End Property

#End Region

	End Class

End Namespace
