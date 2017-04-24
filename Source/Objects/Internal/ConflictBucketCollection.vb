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

  Friend Class ConflictBucketCollection
    Inherits System.Collections.CollectionBase

    'Override constructor so that this object not publically creatable
    Friend Sub New()
    End Sub

#Region "Add"

    Private Function AddObject(ByVal newObject As ConflictBucket) As ConflictBucket
      Call MyBase.List.Add(newObject)
      Return newObject
    End Function

    Public Sub AddAppointment(ByVal appointment As Appointment)

			Try
				For Each rectInfo As AppointmentRectangleInfo In appointment.Rectangles

					'Cache the integer portion of the sort index for speed in looping
					Dim currentSortIndex As Integer = GetIntlInteger(Fix(rectInfo.SortIndexStart))

					'Loop through the buckets and find one to to add the appointment rectangle
					Dim bucket As ConflictBucket
					Dim found As Boolean = False
					For Each bucket In Me
						'Find an existing bucket that contains this appointment
						If bucket.SortIndex = currentSortIndex Then
							bucket.AddRectangle(rectInfo)
							found = True
							Exit For
						End If
					Next

					'If no matching bucket was found then add a bucket
					If Not found Then
						bucket = Me.AddObject(New ConflictBucket)
						bucket.SortIndex = currentSortIndex
						bucket.AddRectangle(rectInfo)
					End If

				Next				'Rectangle Loop

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

    End Sub

#End Region

#Region "Contains"

    Public Function Contains(ByVal index As Integer) As Boolean
      Return (0 <= index) AndAlso (index < Me.Count)
    End Function

#End Region

#Region "Item"

    Default Public ReadOnly Property Item(ByVal index As Integer) As ConflictBucket
      Get
        Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), ConflictBucket)
          End If
        Catch ex As Exception
          Call ErrorModule.SetErr(ex)
        End Try
        Throw New System.ArgumentOutOfRangeException
      End Get
    End Property

#End Region

#Region "Remove"

    Public Shadows Function RemoveAt(ByVal index As Integer) As Boolean

      If Not Contains(index) Then
        Throw New System.ArgumentOutOfRangeException
      End If

      Try
        Call MyBase.RemoveAt(index)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return True

    End Function

#End Region

  End Class

End Namespace
