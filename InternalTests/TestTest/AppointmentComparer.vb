Imports System.Collections
Imports Gravitybox.Objects

Public Class AppointmentComparer
	Implements IComparer

	Public Function Compare(ByVal object1 As Object, ByVal object2 As Object) As Integer Implements System.Collections.IComparer.Compare

		Dim appt1 As Appointment = CType(object1, Appointment)
		Dim appt2 As Appointment = CType(object2, Appointment)

		Debug.WriteLine(appt1.StartDateTime & " " & appt2.StartDateTime)
		If appt1.StartDateTime = appt2.StartDateTime Then
			Return 0
		ElseIf appt1.StartDateTime < appt2.StartDateTime Then
			Return -1
		Else
			Return 1
		End If

	End Function

End Class
