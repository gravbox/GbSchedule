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

	Friend Class DayCellCollection
		Inherits System.Collections.CollectionBase

		'Override constructor so that this object not publically creatable
		Friend Sub New()

			Me.Clear()
			For ii As Integer = 1 To MonthLargeRowCount * DaysPerWeek
				Me.Add(New DayCell)
			Next

		End Sub

#Region "Add"

		Public Function Add(ByVal element As DayCell) As DayCell
			Call MyBase.List.Add(element)
			Return element
		End Function

#End Region

#Region "Contains"

		Public Function Contains(ByVal index As Integer) As Boolean
			Return (0 <= index) AndAlso (index < Me.Count)
		End Function

#End Region

#Region "Item"

		Default Public ReadOnly Property Item(ByVal index As Integer) As DayCell
			Get
				Try
          If (0 <= index) AndAlso (index < Me.Count) Then
            Return CType(MyBase.List(index), DayCell)
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

#Region "Methods"

		Friend Function HitTestUpButton(ByVal x As Integer, ByVal y As Integer) As DayCell

			For Each cell As DayCell In Me
				If cell.UpButtonRectangle.Contains(x, y) Then
					Return cell
				End If
			Next
			Return Nothing

		End Function

		Friend Function HitTestDownButton(ByVal x As Integer, ByVal y As Integer) As DayCell

			For Each cell As DayCell In Me
				If cell.DownButtonRectangle.Contains(x, y) Then
					Return cell
				End If
			Next
			Return Nothing

		End Function

		Friend Sub Reset()
			For Each cell As DayCell In Me
				cell.ScrollValue = 0
				cell.MaxScroll = 0
			Next
		End Sub

#End Region

	End Class

End Namespace
