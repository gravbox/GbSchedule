Imports Gravitybox.Objects

Public Class Form3

	Private Const XMLSchedule As String = "C:\XMLSchedule.xml"

	Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		'Dim appointment As Appointment = schedule1.AppointmentCollection.Add("", DateTime.Now, #11:00:00 AM#, 60)

		'Dim AppointmentRecurrence As Recurrence = New Recurrence(Guid.NewGuid.ToString)
		'AppointmentRecurrence.StartDate = appointment.StartDate
		''If dudQuantity.Text = "" Then
		''	AppointmentRecurrence.EndType = RecurrenceEndConstants.EndByDate
		''	AppointmentRecurrence.EndDate = DateTime.Now.AddDays(3)
		''Else
		'AppointmentRecurrence.EndType = RecurrenceEndConstants.EndByInterval
		'AppointmentRecurrence.EndIterations = 10
		''End If

		'Select Case "Day"
		'	Case "Day"
		'		AppointmentRecurrence.RecurrenceInterval = RecurrenceIntervalConstants.Daily
		'		AppointmentRecurrence.RecurrenceDay.DayInterval = 1
		'		'If cbSkipWeekends.Checked Then
		'		'	AppointmentRecurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayWeekdays
		'		'Else
		'		AppointmentRecurrence.RecurrenceDay.RecurrenceMode = RecurrenceDayConstants.DayInterval
		'		'End If
		'	Case "Week"
		'		AppointmentRecurrence.RecurrenceInterval = RecurrenceIntervalConstants.Weekly
		'		AppointmentRecurrence.RecurrenceWeek.WeekInterval = 1
		'		AppointmentRecurrence.RecurrenceWeek.UseMon = True
		'		AppointmentRecurrence.RecurrenceWeek.UseTue = False
		'		AppointmentRecurrence.RecurrenceWeek.UseWed = True
		'		AppointmentRecurrence.RecurrenceWeek.UseThu = False
		'		AppointmentRecurrence.RecurrenceWeek.UseFri = False
		'		AppointmentRecurrence.RecurrenceWeek.UseSat = False
		'		AppointmentRecurrence.RecurrenceWeek.UseSun = False
		'	Case "Month"
		'		AppointmentRecurrence.RecurrenceInterval = RecurrenceIntervalConstants.Monthly
		'		AppointmentRecurrence.RecurrenceMonth.MonthInterval = 1
		'	Case "Year"
		'		AppointmentRecurrence.RecurrenceInterval = RecurrenceIntervalConstants.Yearly
		'End Select
		'AppointmentRecurrence.ToXML()
		'appointment.Recurrence = AppointmentRecurrence



		'schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
		'schedule1.UseDefaultDrawnHeaders = True
		'Dim objProv As Provider
		'objProv = schedule1.ProviderCollection.Add("1", "Dr. Ray - 1")
		'objProv.Appearance.BackColor = System.Drawing.Color.Blue
		'Dim a As Appointment = schedule1.AppointmentCollection.Add("", Now, Now.AddHours(1), 120)
		'a.Alarm.AllowSnooze = True
		'a.Alarm.AllowOpen = True
		'a.Alarm.Reminder = 60
		'a.Alarm.IsArmed = True
		'a.Key = "xxx"
		'Return

		'  schedule1.SetMinMaxDate(#2/1/2006#, #3/15/2006#)
		'  schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.Week
		'  Return

		'  'schedule1.AppointmentCollection.Clear()
		'  'Dim appt As Appointment = schedule1.AppointmentCollection.Add("", #1/1/2000#, #8:00:00 AM#, 60)
		'  'appt.PropertyItemCollection.Add("", "MyText", "MySetting")

		'  'If System.IO.File.Exists(XMLSchedule) Then Call System.IO.File.Delete(XMLSchedule)
		'  'Call schedule1.AppointmentCollection.SaveXML(XMLSchedule)

		'  schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop

		'  schedule1.SetMinMaxDate(#7/27/2006#, #7/28/2006#)
		'  schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
		'  schedule1.RoomCollection.Clear()
		'  schedule1.RoomCollection.Add("S106", "S106")
		'  schedule1.RoomCollection.Add("N2H4", "N2H4")
		'  schedule1.RoomCollection.Add("S110", "S110")
		'  'Dim room4 As Room = schedule1.RoomCollection.Add("N2P3", "N2P3")
		'  'Dim room5 As Room = schedule1.RoomCollection.Add("N2FI", "N2FI")
		'  schedule1.StartTime = #8:00:00 AM#
		'schedule1.DayLength = 12

		schedule1.ProviderCollection.Add("", "Provider 1")
		schedule1.ProviderCollection.Add("", "Provider 2")
		schedule1.ProviderCollection.Add("", "Provider 3")
		schedule1.ProviderCollection.Add("", "Provider 4")

		schedule1.ProviderCollection(2).Visible = False

		schedule1.Appearance.MajorLineWidth = 2
		schedule1.DynamicScroll = True
		schedule1.SetMinMaxDate(#1/1/2007#, #2/15/2007#)
		schedule1.StartTime = #8:00:00 AM#
		schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop
		Return
		schedule1.ColumnHeader.Appearance.StringFormatFlags = StringFormatFlags.NoWrap
		schedule1.ColumnHeader.Appearance.TextTrimming = StringTrimming.Character
		schedule1.TimeIncrement = Gravitybox.Controls.Schedule.TimeIncrementConstants.Minute30
		schedule1.HeaderDateFormat = "yyyy-dd-MM"

		For ii As Integer = 1 To 5
			schedule1.RoomCollection.Add("", "Room " + ii.ToString)
		Next

		'schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
		schedule1.StartTime = #8:00:00 AM#
		'Dim appt As Appointment = schedule1.AppointmentCollection.Add("", schedule1.MinDate, #8:00:00 AM#, 60)
		'appt.Header.HeaderType = AppointmentHeader.HeaderTypeConstants.Text
		'appt.Appearance.BackGradientStyle = GradientStyleConstants.Horizontal
		'appt.Appearance.BackColor2 = Color.LightBlue
		'appt.Header.Appearance.AllowBreak = False
		'appt.Header.Appearance.BackGradientStyle = GradientStyleConstants.Horizontal
		'appt.Header.Appearance.BackColor2 = Color.LightBlue
		'appt.Header.Text = "Header"
		'appt.Subject = "Body"

		'    schedule1.AppointmentCollection(0).setke()

	End Sub

	Private iconIndex As Integer
	Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

		If (schedule1.AppointmentCollection.Count > 0) Then
			schedule1.AppointmentCollection.RemoveAt(0)
		End If

	End Sub

	Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
		Me.schedule1.AppointmentCollection.Clear()
		Me.schedule1.Refresh()
	End Sub

	Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
		'If Me.schedule1.AppointmentCollection.Count > 0 Then
		'	Me.schedule1.AppointmentCollection.RemoveAt(0)
		'End If

		schedule1.AutoRedraw = False
		schedule1.RoomCollection.Clear()
		schedule1.AutoRedraw = True

	End Sub

	Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
		Label1.Text = schedule1.Selector.StartDate & " " & schedule1.Selector.StartTime
	End Sub

	Private Sub schedule1_AfterPropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles schedule1.AfterPropertyDialog

	End Sub

	Private Sub schedule1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles schedule1.MouseUp

	End Sub

	Private Sub schedule1_AppointmentClick(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AppointmentMouseEventArgs) Handles schedule1.AppointmentClick
		If e.Button = Windows.Forms.MouseButtons.Right Then
			'Do Something
		End If
	End Sub

	Private Sub schedule1_AfterAppointmentMove(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles schedule1.AfterAppointmentMove
	End Sub

	Private Sub schedule1_BeforeAppointmentAdd(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.BeforeBaseObjectEventArgs) Handles schedule1.BeforeAppointmentAdd
		CType(e.BaseObject, Appointment).Appearance.BackColor = Color.Blue
	End Sub

	Private Sub schedule1_AfterAppointmentAdd(ByVal sender As System.Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles schedule1.AfterAppointmentAdd
		CType(e.BaseObject, Appointment).ToolTipText = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit." + vbCrLf + " Phasellus et nisl. Ut sed risus." + vbCrLf + "Maecenas id sapien quis risus placerat varius. Quisque ut eros. Etiam ornare, ligula vitae faucibus mattis, pede metus adipiscing nibh, eget gravida odio magna id ipsum. Pellentesque non lorem. Donec convallis. Proin id nisl. Curabitur leo nunc, facilisis a, eleifend nec, adipiscing eget, elit. Etiam varius libero sed neque. Suspendisse vitae lacus sed felis dictum lobortis. Pellentesque vehicula purus at pede. Proin accumsan tincidunt turpis. Sed aliquet pharetra augue. Praesent ut odio ut nulla fringilla blandit."
	End Sub

	Private Sub schedule1_BeforePropertyDialog(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs) Handles schedule1.BeforePropertyDialog
		'e.Cancel = True
		'Dim KEY As String = CType(e.BaseObject, Appointment).Key
		'schedule1.AppointmentCollection.Remove(KEY)
	End Sub

End Class