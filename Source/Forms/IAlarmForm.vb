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

Namespace Gravitybox.Forms

  Friend Class IAlarmForm
    Inherits System.Windows.Forms.Form

#Region "Class Members"

    'Priate Member Variables
		Private WithEvents m_AppointmentList As New AppointmentList
		Friend Reminder As AppointmentReminder
    Private m_Key As String
    Private m_ScheduleObject As Gravitybox.Controls.Schedule
    Private m_DialogSettings As AlarmDialogSettings

#End Region

#Region "Constructor"

    Friend Sub New()
      AddHandler m_AppointmentList.AfterAdd, AddressOf AppointmentAddEvent
			AddHandler m_AppointmentList.AfterRemove, AddressOf AppointmentRemoveEvent
		End Sub

		Private Sub AppointmentAddEvent(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Me.RefreshForm()
		End Sub

		Private Sub AppointmentRemoveEvent(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			Me.RefreshForm()
		End Sub

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public ReadOnly Property Key() As String
      Get
        Return m_Key
      End Get
    End Property

    Public Property ScheduleObject() As Gravitybox.Controls.Schedule
      Get
        Return m_ScheduleObject
      End Get
      Set(ByVal Value As Gravitybox.Controls.Schedule)
        m_ScheduleObject = Value
      End Set
    End Property

    Public Property DialogSettings() As AlarmDialogSettings
      Get
        Return m_DialogSettings
      End Get
      Set(ByVal Value As AlarmDialogSettings)
        m_DialogSettings = Value
      End Set
    End Property

    Public ReadOnly Property AppointmentList() As AppointmentList
      Get
        Return m_AppointmentList
      End Get
    End Property

#End Region

#Region "Methods"

    Friend Overridable Sub RefreshForm()
    End Sub

    Friend Sub SetKey(ByVal key As String)
      m_Key = key
    End Sub

#End Region

  End Class

End Namespace