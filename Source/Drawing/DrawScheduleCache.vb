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

Namespace Gravitybox.Drawing

  Friend Class DrawScheduleCache

    Private ScheduleObject As Gravitybox.Controls.Schedule
    Private m_FirstVisibleDate As DateTime
    Private m_FirstVisibleTime As DateTime
    Private m_FirstVisibleRoom As Integer
		Private m_FirstVisibleProvider As Integer
		Private m_FirstVisibleResource As Integer
    Private m_FirstVisibleRow As Integer
    Private m_FirstVisibleColumn As Integer
    Private m_TotalVisibleRows As Integer
    Private m_TotalVisibleColumns As Integer
    Private m_RowHeight As Integer
    Private m_ColumnWidth As Integer
    Private m_TimeIncrement As Integer
    Private m_ClientLeft As Integer
    Private m_ClientTop As Integer
    Private m_ClientWidth As Integer
    Private m_ClientHeight As Integer
    Private m_TextHeight As Integer
		Private m_EventHeaderHeight As Integer
		Private m_TimeIncrementsPerHour As Integer

    Friend ReadOnly Property FirstVisibleDate() As DateTime
      Get
				Return m_FirstVisibleDate
      End Get
    End Property

    Friend ReadOnly Property FirstVisibleTime() As DateTime
      Get
				Return m_FirstVisibleTime
      End Get
    End Property

    Friend ReadOnly Property FirstVisibleRoom() As Integer
      Get
				Return m_FirstVisibleRoom
      End Get
    End Property

    Friend ReadOnly Property FirstVisibleProvider() As Integer
      Get
				Return m_FirstVisibleProvider
      End Get
    End Property

		Friend ReadOnly Property FirstVisibleResource() As Integer
			Get
				Return m_FirstVisibleResource
			End Get
		End Property

		Friend ReadOnly Property FirstVisibleRow() As Integer
			Get
				Return m_FirstVisibleRow
			End Get
		End Property

		Friend ReadOnly Property FirstVisibleColumn() As Integer
			Get
				Return m_FirstVisibleColumn
			End Get
		End Property

		Friend ReadOnly Property TotalVisibleRows() As Integer
			Get
				Return m_TotalVisibleRows
			End Get
		End Property

		Friend ReadOnly Property TotalVisibleColumns() As Integer
			Get
				Return m_TotalVisibleColumns
			End Get
		End Property

		Friend ReadOnly Property RowHeight() As Integer
			Get
				Return m_RowHeight
			End Get
		End Property

		Friend ReadOnly Property ColumnWidth() As Integer
			Get
				Return m_ColumnWidth
			End Get
		End Property

		Friend ReadOnly Property TimeIncrement() As Integer
			Get
				Return m_TimeIncrement
			End Get
		End Property

		Friend ReadOnly Property ClientLeft() As Integer
			Get
				Return m_ClientLeft
			End Get
		End Property

		Friend ReadOnly Property ClientTop() As Integer
			Get
				Return m_ClientTop
			End Get
		End Property

		Friend ReadOnly Property ClientWidth() As Integer
			Get
				Return m_ClientWidth
			End Get
		End Property

		Friend ReadOnly Property ClientHeight() As Integer
			Get
				Return m_ClientHeight
			End Get
		End Property

		Friend ReadOnly Property ClientRight() As Integer
			Get
				Dim retval As Integer = Me.ClientLeft + Me.ClientWidth
				If retval > Me.LastVisibleX Then retval = Me.LastVisibleX
				Return retval
			End Get
		End Property

		Friend ReadOnly Property ClientBottom() As Integer
			Get
				Dim retval As Integer = Me.ClientTop + Me.ClientHeight
				If retval > Me.LastVisibleY Then retval = Me.LastVisibleY
				Return retval
			End Get
		End Property

		Friend ReadOnly Property TextHeight() As Integer
			Get
				Return m_TextHeight
			End Get
		End Property

		Friend ReadOnly Property EventHeaderHeight() As Integer
			Get
				Return m_EventHeaderHeight
			End Get
		End Property

		Private ReadOnly Property LastVisibleX() As Integer
			Get
				Return ScheduleObject.Width - ScheduleObject.VScroll1.Width
			End Get
		End Property

		Private ReadOnly Property LastVisibleY() As Integer
			Get
				Return ScheduleObject.Height - ScheduleObject.HScroll1.Height
			End Get
		End Property

		Friend ReadOnly Property TimeIncrementsPerHour() As Integer
			Get
				Return m_TimeIncrementsPerHour
			End Get
		End Property

		Friend Sub Load(ByVal MainObject As Gravitybox.Controls.Schedule)
			ScheduleObject = MainObject

			m_FirstVisibleDate = MainObject.Visibility.FirstVisibleDate
			m_FirstVisibleTime = MainObject.Visibility.FirstVisibleTime
			m_FirstVisibleProvider = MainObject.Visibility.FirstVisibleProvider
			m_FirstVisibleResource = MainObject.Visibility.FirstVisibleResource
			m_FirstVisibleRow = MainObject.Visibility.FirstVisibleRow
			m_FirstVisibleColumn = MainObject.Visibility.FirstVisibleColumn
			m_TotalVisibleRows = MainObject.Visibility.VisibleRows
			m_TotalVisibleColumns = MainObject.Visibility.VisibleColumns
			m_RowHeight = MainObject.RowHeader.Size
			m_ColumnWidth = MainObject.ColumnHeader.Size
			m_TimeIncrement = MainObject.TimeIncrement
			m_ClientLeft = MainObject.ClientLeft
			m_ClientTop = MainObject.ClientTop
			m_ClientWidth = MainObject.ClientWidth
			m_ClientHeight = MainObject.ClientHeight
			m_TextHeight = MainObject.TextHeight(MainObject.Font)
			m_EventHeaderHeight = MainObject.EventHeaderHeight
			m_TimeIncrementsPerHour = MainObject.TimeIncrementsPerHour

		End Sub

	End Class

End Namespace