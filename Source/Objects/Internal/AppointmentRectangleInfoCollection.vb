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

  <Serializable()> _
  Friend Class AppointmentRectangleInfoCollection
    Inherits System.Collections.CollectionBase

#Region "Class Members"

    'Private Property variables
    Private m_Parent As Appointment

#End Region

    'Override constructor so that this object not publically creatable
    Friend Sub New(ByVal parent As Appointment)
      m_Parent = parent
    End Sub

#Region "Property Implementations"

    Friend ReadOnly Property Parent() As Appointment
      Get
        Return m_Parent
      End Get
    End Property

#End Region

    Public Function Add() As AppointmentRectangleInfo

      Try
        Dim newObject As New AppointmentRectangleInfo(Me)
        Return AddObject(newObject)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Public Function AddObject(ByVal newObject As AppointmentRectangleInfo) As AppointmentRectangleInfo

      Try
        Call MyBase.List.Add(newObject)
        Return newObject
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Default Public ReadOnly Property Item(ByVal index As Integer) As AppointmentRectangleInfo
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), AppointmentRectangleInfo)
          Else
            Return New AppointmentRectangleInfo(Me)  'TEMP
            'Throw New System.ArgumentOutOfRangeException()
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Return Nothing
      End Get
    End Property

    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      Try
        Call MyBase.RemoveAt(index)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return True

    End Function

    Public Function InRectangle(ByVal x As Integer, ByVal y As Integer) As Boolean
      Return InRectangle(New Point(x, y))
    End Function

    Public Function InRectangle(ByVal pt As Point) As Boolean

      Try
        Dim element As AppointmentRectangleInfo
        For Each element In Me
          If element.Rect.Contains(pt) Then
            Return True
          End If
        Next
        Return False
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Public Function GetRectangle(ByVal x As Integer, ByVal y As Integer) As AppointmentRectangleInfo
      Return GetRectangle(New Point(x, y))
    End Function

    Public Function GetRectangle(ByVal pt As Point) As AppointmentRectangleInfo

      Try
				For Each rectangle As AppointmentRectangleInfo In Me
					If rectangle.Rect.Contains(pt) Then
						Return rectangle
					End If
				Next
			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

		Public Function GetRectangleIndex(ByVal x As Integer, ByVal y As Integer) As Integer
			Return GetRectangleIndex(New Point(x, y))
		End Function

		Public Function GetRectangleIndex(ByVal pt As Point) As Integer

			Try
				Dim ii As Integer = 0
				For Each rectangle As AppointmentRectangleInfo In Me
					If rectangle.Rect.Contains(pt) Then
						Return ii
					End If
					ii += 1
				Next
				Return -1

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Friend Function IsConflict(ByVal rectInfo As AppointmentRectangleInfo) As Boolean

			Try
				Dim element As AppointmentRectangleInfo
				For Each element In Me
					If element.IsConflict(rectInfo) Then
						Return True
					End If
				Next
				Return False
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Public Sub Merge(ByVal rectangles As AppointmentRectangleInfoCollection)

			Try
				Dim rectinfo As AppointmentRectangleInfo
				For Each rectinfo In rectangles
					Me.AddObject(rectinfo)
				Next
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Sub

	End Class

End Namespace
