Imports System
Imports System.Data
Imports Gravitybox.Objects

Public Class Form1

  Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


    'Dim recurrece As Recurrence = schedule1.AppointmentCollection(0).Recurrence
    'Dim list As AppointmentList = schedule1.AppointmentCollection.GetRecurrences(recurrece)
    'If list.Count > 1 Then
    '  MsgBox("Multiple Recurrences", MsgBoxStyle.Information, "Information")
    'Else
    '  MsgBox("Single Appointment", MsgBoxStyle.Information, "Information")
		'End If

		schedule1.ProviderCollection.Add("", "Provider 1")
    schedule1.ProviderCollection.Add("", "Provider 2")
    schedule1.ProviderCollection.Add("", "Provider 3")

    schedule1.SetMinMaxDate(#1/1/2006#, #1/5/2006#)
    schedule1.StartTime = #8:00:00 AM#
    schedule1.DayLength = 10
    schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft
    schedule1.AppointmentCollection.Clear()
    'schedule1.AppointmentCollection.Add("", schedule1.MinDate, #9:00:00 AM#, 120)

    schedule1.NoDropAreaCollection.Add("", Color.Red, schedule1.MinDate.AddDays(1), #10:00:00 AM#, 60)

    Dim a As Appointment = schedule1.AppointmentCollection.ToList().NextAreaAvailable(#1/1/2007#, #8:00:00 AM#, 120, False)
    Debug.Print(a.StartDateTime)

    Dim b As Boolean = schedule1.NoDropAreaCollection.ToList().IsOverlap(schedule1.MinDate, #10:00:00 AM#, 1450)
    Debug.WriteLine(b)

  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    schedule1.AppointmentCollection(0).Recurrence = Nothing
  End Sub

End Class
