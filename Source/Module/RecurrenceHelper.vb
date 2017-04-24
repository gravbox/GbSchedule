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

Namespace Gravitybox.Objects

  Module RecurrenceHelper

#Region "GetMonthRecurrenceDate"

    Public Function GetMonthRecurrenceDate(ByVal dayPosition As RecurrenceOrdinalDayConstants, ByVal lDayOrdinal As RecurrenceOrdinalConstants, ByVal dtDate As DateTime) As DateTime

      Const LastDaySentinal As Integer = 100

      Dim ii As Integer
      Dim retval As DateTime
      Dim lDayIndex As Integer
      Dim lDayCheckIndex As Integer
      Dim lDay As Integer
      Dim dtCheck As DateTime

      Try

        'Get the position of the day first, second, etc...
        Select Case lDayOrdinal
          Case RecurrenceOrdinalConstants.First : lDayIndex = 1
          Case RecurrenceOrdinalConstants.Second : lDayIndex = 2
          Case RecurrenceOrdinalConstants.Third : lDayIndex = 3
          Case RecurrenceOrdinalConstants.Fourth : lDayIndex = 4
          Case RecurrenceOrdinalConstants.Last : lDayIndex = LastDaySentinal
        End Select

        'If this a general day not a specified day like Monday
        'then handle the date calculation differently
        If dayPosition = RecurrenceOrdinalDayConstants.Day Then
          If lDayOrdinal = RecurrenceOrdinalConstants.Last Then
            'The last day of the month
            lDay = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(Year(dtDate), Month(dtDate), 1))).Day
          Else
            lDay = lDayIndex
          End If
        ElseIf dayPosition = RecurrenceOrdinalDayConstants.Weekday Then
          'Loop until we find a weekday
          For ii = 1 To 31
            dtCheck = DateSerial(Year(dtDate), Month(dtDate), ii)
            If Not ((Weekday(dtCheck) = vbSaturday) Or (Weekday(dtCheck) = vbSunday)) Then
              lDay = ii
              Exit For
            End If
          Next 'ii

        ElseIf dayPosition = RecurrenceOrdinalDayConstants.WeekendDay Then
          'Loop until we find a weekendday
          For ii = 1 To 31
            dtCheck = DateSerial(Year(dtDate), Month(dtDate), ii)
            If ((Weekday(dtCheck) = vbSaturday) Or (Weekday(dtCheck) = vbSunday)) Then
              lDay = ii
              Exit For
            End If
          Next 'ii

        Else

          'Loop until we find the specified day
          For ii = 1 To 31
            dtCheck = DateSerial(Year(dtDate), Month(dtDate), ii)
            If Month(dtCheck) <> Month(dtDate) Then
              Exit For
            End If

            'Sunday
            If ((Weekday(dtCheck) = vbSunday) And (dayPosition = RecurrenceOrdinalDayConstants.Sunday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Monday
            If ((Weekday(dtCheck) = vbMonday) And (dayPosition = RecurrenceOrdinalDayConstants.Monday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Tuesday
            If ((Weekday(dtCheck) = vbTuesday) And (dayPosition = RecurrenceOrdinalDayConstants.Tuesday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Wednesday
            If ((Weekday(dtCheck) = vbWednesday) And (dayPosition = RecurrenceOrdinalDayConstants.Wednesday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Thursday
            If ((Weekday(dtCheck) = vbThursday) And (dayPosition = RecurrenceOrdinalDayConstants.Thursday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Friday
            If ((Weekday(dtCheck) = vbFriday) And (dayPosition = RecurrenceOrdinalDayConstants.Friday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

            'Saturday
            If ((Weekday(dtCheck) = vbSaturday) And (dayPosition = RecurrenceOrdinalDayConstants.Saturday)) Then
              lDayCheckIndex = lDayCheckIndex + 1
              If lDayCheckIndex = lDayIndex Then
                lDay = ii
                Exit For
              ElseIf lDayIndex = LastDaySentinal Then
                lDay = ii
              End If
            End If

          Next 'ii


        End If

        If lDay > 0 Then
          retval = DateSerial(Year(dtDate), Month(dtDate), lDay)
        End If

        Return retval

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

      Return DefaultNoDate

    End Function

#End Region

#Region "GetYearRecurrenceDate"

		Public Function GetYearRecurrenceDate(ByVal dayPosition As RecurrenceOrdinalDayConstants, ByVal lDayOrdinal As RecurrenceOrdinalConstants, ByVal monthIndex As Integer, ByVal dtDate As DateTime) As DateTime

			Const LastDaySentinal As Integer = 100

			Dim ii As Integer
			Dim retval As DateTime
			Dim lDayIndex As Integer
			Dim lDayCheckIndex As Integer
			Dim lDay As Integer
			Dim dtCheck As DateTime

			Try

				'Get the position of the day first, second, etc...
				Select Case lDayOrdinal
					Case RecurrenceOrdinalConstants.First : lDayIndex = 1
					Case RecurrenceOrdinalConstants.Second : lDayIndex = 2
					Case RecurrenceOrdinalConstants.Third : lDayIndex = 3
					Case RecurrenceOrdinalConstants.Fourth : lDayIndex = 4
					Case RecurrenceOrdinalConstants.Last : lDayIndex = LastDaySentinal
				End Select

				'If this a general day not a specified day like Monday
				'then handle the date calculation differently
				If dayPosition = RecurrenceOrdinalDayConstants.Day Then
					If lDayOrdinal = RecurrenceOrdinalConstants.Last Then
						'The last day of the month
						lDay = DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Month, 1, DateSerial(Year(dtDate), monthIndex, 1))).Day
					Else
						lDay = lDayIndex
					End If
				ElseIf dayPosition = RecurrenceOrdinalDayConstants.Weekday Then
					'Loop until we find a weekday
					For ii = 1 To 31
						dtCheck = DateSerial(Year(dtDate), monthIndex, ii)
						If Not ((Weekday(dtCheck) = vbSaturday) Or (Weekday(dtCheck) = vbSunday)) Then
							lDay = ii
							Exit For
						End If
					Next					'ii

				ElseIf dayPosition = RecurrenceOrdinalDayConstants.WeekendDay Then
					'Loop until we find a weekendday
					For ii = 1 To 31
						dtCheck = DateSerial(Year(dtDate), monthIndex, ii)
						If ((Weekday(dtCheck) = vbSaturday) Or (Weekday(dtCheck) = vbSunday)) Then
							lDay = ii
							Exit For
						End If
					Next					'ii

				Else

					'Loop until we find the specified day
					For ii = 1 To 31
						dtCheck = DateSerial(Year(dtDate), monthIndex, ii)
						If Month(dtCheck) <> monthIndex Then
							Exit For
						End If

						'Sunday
						If ((Weekday(dtCheck) = vbSunday) And (dayPosition = RecurrenceOrdinalDayConstants.Sunday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Monday
						If ((Weekday(dtCheck) = vbMonday) And (dayPosition = RecurrenceOrdinalDayConstants.Monday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Tuesday
						If ((Weekday(dtCheck) = vbTuesday) And (dayPosition = RecurrenceOrdinalDayConstants.Tuesday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Wednesday
						If ((Weekday(dtCheck) = vbWednesday) And (dayPosition = RecurrenceOrdinalDayConstants.Wednesday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Thursday
						If ((Weekday(dtCheck) = vbThursday) And (dayPosition = RecurrenceOrdinalDayConstants.Thursday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Friday
						If ((Weekday(dtCheck) = vbFriday) And (dayPosition = RecurrenceOrdinalDayConstants.Friday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

						'Saturday
						If ((Weekday(dtCheck) = vbSaturday) And (dayPosition = RecurrenceOrdinalDayConstants.Saturday)) Then
							lDayCheckIndex = lDayCheckIndex + 1
							If lDayCheckIndex = lDayIndex Then
								lDay = ii
								Exit For
							ElseIf lDayIndex = LastDaySentinal Then
								lDay = ii
							End If
						End If

					Next					'ii


				End If

				If lDay > 0 Then
					retval = DateSerial(Year(dtDate), monthIndex, lDay)
				End If

				Return retval

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

			Return DefaultNoDate

		End Function

#End Region

	End Module

End Namespace