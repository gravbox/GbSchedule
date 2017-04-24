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

Imports Gravitybox.Objects

Module WeekModeHelper

#Region "GetStartOfWeek"

	Public Function GetStartOfWeek(ByVal startDate As Date, ByVal firstDayOfWeek As DayOfWeek) As Date

		Try
			Dim firstDate As Date = startDate
      Dim diff As Integer = 0
      If firstDate.DayOfWeek = firstDayOfWeek Then
        diff = 0
      ElseIf firstDate.DayOfWeek > firstDayOfWeek Then
        diff = firstDate.DayOfWeek - firstDayOfWeek
      Else
        diff = DaysPerWeek - firstDayOfWeek + firstDate.DayOfWeek
      End If
      firstDate = firstDate.AddDays(-diff)
      Return firstDate
    Catch ex As Exception
			ErrorModule.SetErr(ex)
		End Try
		Return startDate

	End Function

#End Region

#Region "GetDayOffset"

	Public Function GetDayOffset(ByVal baseDate As Date, ByVal offSetDate As Date) As Integer

		Dim retval As Integer = -1
		Try
			retval = GetIntlInteger(offSetDate.Subtract(baseDate).TotalDays)
			If Not ((0 <= retval) AndAlso (retval < DaysPerWeek)) Then
				retval = -1
			End If
		Catch ex As Exception
			retval = -1
			ErrorModule.SetErr(ex)
		End Try
		Return retval

	End Function

#End Region

#Region "GetCellRectFromOffset"

	Public Function GetCellRectFromOffset(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal offsetIndex As Integer) As Rectangle

		If (0 <= offsetIndex) AndAlso (offsetIndex < DaysPerWeek) Then
			Return CType(MainObject.WeekClientRectangles(offsetIndex), Rectangle)
		Else
			Return New Rectangle(0, 0, 0, 0)
		End If

	End Function

	Public Function GetCellRectFromOffset(ByVal MainObject As Gravitybox.Controls.Schedule, ByVal offSetDate As Date) As Rectangle

		Dim offsetIndex As Integer = GetDayOffset(MainObject.MinDate, offSetDate)
		Return GetCellRectFromOffset(MainObject, offsetIndex)

	End Function

#End Region

End Module
