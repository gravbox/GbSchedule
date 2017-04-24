Public Class Form2

  Private Sub Schedule_AfterAppointmentMove(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs) Handles schedule1.AfterAppointmentMove
    AddAppts()

    schedule1.AppointmentCollection.Add("", schedule1.MinDate, schedule1.RoomCollection(0), #10:00:00 AM#, 60)

  End Sub

  Private Sub AddAppts()
    schedule1.AutoRedraw = False
    schedule1.RoomCollection.Clear()
    schedule1.AppointmentCollection.Clear()
    Me.AddRooms()

    schedule1.AppointmentCollection.Add("", schedule1.MinDate, schedule1.RoomCollection(0), #8:00:00 AM#, 60)

    schedule1.AutoRedraw = True
    schedule1.ViewMode = Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft

  End Sub

  Private Sub AddRooms()
    schedule1.RoomCollection.Add("", "Room 1")
    schedule1.RoomCollection.Add("", "Room 2")
    schedule1.RoomCollection.Add("", "Room 3")
  End Sub

  Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    AddAppts()
  End Sub

End Class