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

  ''' <summary>
  ''' This object allows interaction with the built-in dialogs
  ''' </summary>
  Public Class ScheduleDialog
		Implements IDisposable

#Region "Class Members"

    Private _mainObject As Gravitybox.Controls.Schedule

    'Internal Objects
    Friend AlarmScreen As Gravitybox.Forms.IAlarmForm
    Friend PropertyScreens As New Collection
    Friend DialogCategoryBounds As New Rectangle
    Friend DialogCategoryMasterBounds As New Rectangle
    Friend DialogProviderBounds As New Rectangle
    Friend DialogResourceBounds As New Rectangle

#End Region

#Region "Constructor"

    Friend Sub New(ByVal mainSchedule As Gravitybox.Controls.Schedule)
      _mainObject = mainSchedule
    End Sub

#End Region

#Region "Property Implementations"

    Friend ReadOnly Property MainObject() As Gravitybox.Controls.Schedule
      Get
        Return _mainObject
      End Get
    End Property

#End Region

#Region "About Dialog"

    Friend Function ShowAboutDialog(ByVal quickUnload As Boolean) As Boolean

      Try
        Dim F As New Forms.AboutForm
				'If Not (MainObject Is Nothing) Then
				'  F.ComponentLicense = CType(MainObject.ComponentLicense, licX.LicXLicense)
				'End If
        F.QuickUnload = quickUnload
        Call F.ShowDialog()
        Return True
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the about box
    ''' </summary>
    Public Function ShowAboutDialog() As Boolean
      Return ShowAboutDialog(False)
    End Function

#End Region

#Region "Property Dialog"

    Friend Function ShowPropertyDialog(ByVal appointment As Appointment, ByVal removeOnCancel As Boolean) As Boolean
      Try
        Dim dialogSettings As New AppointmentDialogSettings
        dialogSettings.AllowCategory = (MainObject.CategoryCollection.Count > 0)
        dialogSettings.AllowProvider = (MainObject.ProviderCollection.VisibleCount > 0)
        dialogSettings.AllowResource = (MainObject.ResourceCollection.Count > 0)
        dialogSettings.AllowPriority = (MainObject.PriorityCollection.Count > 0)
        dialogSettings.AllowAppointmentType = (MainObject.AppointmentTypeCollection.Count > 0)
        dialogSettings.AllowSubject = True
        dialogSettings.AllowText = True
        dialogSettings.AllowEvents = MainObject.EventHeader.AllowHeader
        dialogSettings.AllowRemove = MainObject.AllowRemove
        dialogSettings.TimeIncrement = MainObject.TimeIncrement

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop
            dialogSettings.AllowRoom = True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            dialogSettings.AllowRoom = False
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop
            dialogSettings.AllowRoom = False
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            dialogSettings.AllowRoom = True
          Case Controls.Schedule.ViewModeConstants.Week
            dialogSettings.AllowRoom = False
          Case Controls.Schedule.ViewModeConstants.MonthFull
            dialogSettings.AllowRoom = False
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            dialogSettings.AllowRoom = False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            dialogSettings.AllowDate = True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft
            dialogSettings.AllowDate = False
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            dialogSettings.AllowDate = True
          Case Controls.Schedule.ViewModeConstants.Week
            dialogSettings.AllowDate = True
          Case Controls.Schedule.ViewModeConstants.MonthFull
            dialogSettings.AllowDate = True
          Case Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            dialogSettings.AllowDate = False
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

        Select Case MainObject.ViewMode
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ProviderTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.Month, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomTopTimeLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayRoomLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderLeftTimeTop, Controls.Schedule.ViewModeConstants.DayProviderTopTimeLeft
            dialogSettings.AllowTime = True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.DayTopRoomLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftRoomTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.RoomTopProviderLeft, Gravitybox.Controls.Schedule.ViewModeConstants.RoomLeftProviderTop, Gravitybox.Controls.Schedule.ViewModeConstants.DayLeftResourceTop
            dialogSettings.AllowTime = False
          Case Controls.Schedule.ViewModeConstants.DayTimeLeftProviderTop, Controls.Schedule.ViewModeConstants.DayTimeLeftRoomTop
            dialogSettings.AllowTime = True
          Case Controls.Schedule.ViewModeConstants.Week
            dialogSettings.AllowTime = True
          Case Controls.Schedule.ViewModeConstants.MonthFull
            dialogSettings.AllowTime = True
          Case Gravitybox.Controls.Schedule.ViewModeConstants.ResourceLeftTimeTop, Gravitybox.Controls.Schedule.ViewModeConstants.ResourceTopTimeLeft
            dialogSettings.AllowTime = True
          Case Else
            Call ErrorModule.ViewmodeErr()
        End Select

        'Now call the overloaded version of this method
        Return ShowPropertyDialog(appointment, removeOnCancel, dialogSettings)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the default appointment dialog.
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    Public Function ShowPropertyDialog(ByVal appointment As Appointment) As Boolean
      Return ShowPropertyDialog(appointment, False)
    End Function

    ''' <summary>
    ''' Shows the default appointment dialog.
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowPropertyDialog(ByVal appointment As Appointment, ByVal dialogSettings As AppointmentDialogSettings) As Boolean
      Return ShowPropertyDialog(appointment, False, dialogSettings)
    End Function

    Friend Function ShowPropertyDialog(ByVal appointment As Appointment, ByVal removeOnCancel As Boolean, ByVal dialogSettings As AppointmentDialogSettings) As Boolean

      Try
        'Cleanup / Error Check
        MainObject.TimerEdit.Enabled = False
        MainObject.SelectedItemOnMouseDown = Nothing 'So there is no edit after we return
        If appointment Is Nothing Then Return False
        If dialogSettings Is Nothing Then Return False

        'Try to get reminder form if it is loaded for this appointment
        Dim F As Forms.AppointmentPropertiesForm
        F = GetPropertyForm(appointment)

        'If it does not exist then create a new form
        If F Is Nothing Then
          F = New Forms.AppointmentPropertiesForm
          F.ScheduleObject = Me.MainObject
          F.RemoveOnCancel = removeOnCancel
          Dim returnValues As New ReturnValues

          'Raise the BeforePropertyDialog event
          Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforePropertyDialogEventArgs(appointment, dialogSettings)
          Call MainObject.FireEventBeforePropertyDialog(Me, eventParam1)
          If eventParam1.Cancel Then Return False
          If Not Me.MainObject.AppointmentCollection.Contains(appointment) Then Return False 'Ensure the appointment was not removed

          F.Appointment = appointment
          F.DialogSettings = dialogSettings
          F.ReturnValues = returnValues

          Call PropertyScreens.Add(F, F.Key)
          If dialogSettings.AllowModal Then
            Call F.ShowDialog()
            If CBool(returnValues(0).Setting) Then
              'The object was updated so repaint
              MainObject.OnRefresh()
              Return True
            Else
              'The object was canceled - Do Nothing
              Return False
            End If

          Else
            If F.WindowState = FormWindowState.Minimized Then F.WindowState = FormWindowState.Normal
            Call F.Show()
            'Make sure that the screen is in front
            Call F.BringToFront()
            Return True
          End If

        Else
          'Make sure that the screen is in front
          If F.WindowState = FormWindowState.Minimized Then F.WindowState = FormWindowState.Normal
          Call F.Show()
          Call F.BringToFront()
          Return True

        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function GetPropertyForm(ByVal appointmentKey As String) As Forms.AppointmentPropertiesForm

      Try
        Dim appointment As Appointment
        For Each appointment In MainObject.AppointmentCollection
          If appointment.Key = appointmentKey Then
            Return GetPropertyForm(appointment)
          End If
        Next
        Return Nothing
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    Friend Function GetPropertyForm(ByVal appointment As Appointment) As Forms.AppointmentPropertiesForm

      Try
        Dim ii As Integer
        Dim retval As Forms.AppointmentPropertiesForm
        For ii = 1 To PropertyScreens.Count
          retval = CType(PropertyScreens(ii), Forms.AppointmentPropertiesForm)
          If retval.Appointment Is appointment Then
            Return retval
          End If
        Next
        Return Nothing

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

#Region "Category Dialog"

    ''' <summary>
    ''' Shows the category dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    Public Function ShowCategoryDialog(ByVal appointment As Appointment) As Boolean

      Try
        Return ShowCategoryDialog(appointment, New CategoryDialogSettings)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the category dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowCategoryDialog(ByVal appointment As Appointment, ByVal dialogSettings As CategoryDialogSettings) As Boolean

      Dim retval As Boolean = False
      Try
        MainObject.TimerEdit.Enabled = False
        'Need an appointment to continue
        If appointment Is Nothing Then Return False

        'Raise the BeforePropertyDialog event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeCategoryListDialogEventArgs(appointment, dialogSettings)
        Call MainObject.FireEventBeforeCategoryListDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        'Load the category screen
        Dim F As Forms.CategoryForm
        F = New Forms.CategoryForm
        F.MainObject = Me.MainObject
        F.DialogSettings = dialogSettings
        F.SetBounds(DialogCategoryBounds.Left, DialogCategoryBounds.Top, DialogCategoryBounds.Width, DialogCategoryBounds.Height)
        F.CategoryCollection = MainObject.CategoryCollection
        F.Appointment = appointment
        If F.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          retval = True
        End If

        'Raise the AfterPropertyDialog event
        Dim eventParam2 As New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(appointment)
        Call MainObject.FireEventAfterCategoryListDialog(Me, eventParam2)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return retval

    End Function

#End Region

#Region "Provider Dialog"

    ''' <summary>
    ''' Shows the provider dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    Public Function ShowProviderDialog(ByVal appointment As Appointment) As Boolean

      Try
        Return ShowProviderDialog(appointment, New ProviderDialogSettings)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the provider dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowProviderDialog(ByVal appointment As Appointment, ByVal dialogSettings As ProviderDialogSettings) As Boolean

      Dim retval As Boolean = False
      Try
        MainObject.TimerEdit.Enabled = False
        'Need an appointment to continue
        If appointment Is Nothing Then Return False

        'Raise the BeforePropertyDialog event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeProviderListDialogEventArgs(appointment, dialogSettings)
        Call MainObject.FireEventBeforeProviderListDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        'Load the provider screen
        Dim F As Forms.ProviderForm
        F = New Forms.ProviderForm
        F.MainObject = Me.MainObject
        F.DialogSettings = dialogSettings
        F.ProviderCollection = MainObject.ProviderCollection
        F.SetBounds(DialogProviderBounds.Left, DialogProviderBounds.Top, DialogProviderBounds.Width, DialogProviderBounds.Height)
        F.Appointment = appointment
        If F.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          retval = True
        End If

        'Raise the AfterPropertyDialog event
        Dim eventParam2 As New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(appointment)
        Call MainObject.FireEventAfterProviderListDialog(Me, eventParam2)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return retval

    End Function

#End Region

#Region "Provider Dialog"

    ''' <summary>
    ''' Shows the resource dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    Public Function ShowResourceDialog(ByVal appointment As Appointment) As Boolean

      Try
        Return ShowResourceDialog(appointment, New ResourceDialogSettings)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the resource dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    ''' ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowResourceDialog(ByVal appointment As Appointment, ByVal dialogSettings As ResourceDialogSettings) As Boolean

      Dim retval As Boolean = False
      Try
        MainObject.TimerEdit.Enabled = False
        'Need an appointment to continue
        If appointment Is Nothing Then Return False

        'Raise the BeforePropertyDialog event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeResourceListDialogEventArgs(appointment, dialogSettings)
        Call MainObject.FireEventBeforeResourceListDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        'Load the Resource screen
        Dim F As Forms.ResourceForm
        F = New Forms.ResourceForm
        F.MainObject = Me.MainObject
        F.DialogSettings = dialogSettings
        F.ResourceCollection = MainObject.ResourceCollection
        F.SetBounds(DialogResourceBounds.Left, DialogResourceBounds.Top, DialogResourceBounds.Width, DialogResourceBounds.Height)
        F.Appointment = appointment
        If F.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          retval = True
        End If

        'Raise the AfterPropertyDialog event
        Dim eventParam2 As New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(appointment)
        Call MainObject.FireEventAfterResourceListDialog(Me, eventParam2)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return retval

    End Function

#End Region

#Region "Alarm Dialog"

    Friend Sub RefreshAlarm(ByVal appointment As Appointment)
      If Me.AlarmVisible(appointment) Then
        Me.ShowAlarmDialog(appointment)
      End If
    End Sub

    ''' <summary>
    ''' Shows the alarm dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    Public Sub ShowAlarmDialog(ByVal appointment As Appointment)

      Try
        Dim dialogSettings As New AlarmDialogSettings
        dialogSettings.WindowText = "Alarm"
        Call ShowAlarmDialog(appointment, dialogSettings, False)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    ''' <summary>
    ''' Shows the alarm dialog for an appointment
    ''' </summary>
    ''' <param name="appointment">The appointment to edit.</param>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Sub ShowAlarmDialog(ByVal appointment As Appointment, ByVal dialogSettings As AlarmDialogSettings)
      ShowAlarmDialog(appointment, dialogSettings, True)
    End Sub

    Friend Sub ShowAlarmDialog(ByVal appointment As Appointment, ByVal dialogSettings As AlarmDialogSettings, ByVal forceFocus As Boolean)

      Try
        MainObject.TimerEdit.Enabled = False

        'If there is no appointment then nothing to do
        If appointment Is Nothing Then Return

        Dim F As Forms.IAlarmForm
        'Try to get reminder form if it is loaded for this appointment
        'If it does not exist then create a new form
        Dim isNew As Boolean = False
        If Me.AlarmScreen Is Nothing Then
          'If dialogSettings.DialogStyle = DialogStyleConstants.Standard Then
          isNew = True
          F = New Forms.AlarmForm(Me)
          'Else
          'F = New Forms.AlarmFormXP(Me)
          'End If
          F.ScheduleObject = Me.MainObject
          F.DialogSettings = dialogSettings
          Me.AlarmScreen = F
        Else
          F = Me.AlarmScreen
        End If

        'Add the alarm and refresh
        If Not F.AppointmentList.Contains(appointment) Then
          F.AppointmentList.Add(appointment)
        Else
          F.RefreshForm()
        End If

        If dialogSettings.IsModal Then
          If isNew Then
            F.ShowDialog()
          Else
            F.Visible = True
          End If
        Else
          If F.WindowState = FormWindowState.Minimized Then F.WindowState = FormWindowState.Normal
          Call F.Show()
          'Make sure that the screen is in front
          If forceFocus Then
            Call F.BringToFront()
          End If
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Friend Function AlarmVisible(ByVal appointment As Gravitybox.Objects.Appointment) As Boolean

      Try
        If Me.AlarmScreen Is Nothing Then
          Return False
        Else
          Return Me.AlarmScreen.AppointmentList.Contains(appointment)
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function RemoveAlarm(ByVal appointment As Gravitybox.Objects.Appointment) As Boolean

      Try
        If Not (Me.AlarmScreen Is Nothing) Then
          If Me.AlarmScreen.AppointmentList.Contains(appointment) Then
            Me.AlarmScreen.AppointmentList.Remove(appointment)
          End If

          'If this was the last alarm then close the form
          If Me.AlarmScreen.AppointmentList.Count = 0 Then
            Me.AlarmScreen.Close()
          End If

        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Screen Configuration"

    ''' <summary>
    ''' Shows the ProviderCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the provider objects in their parent collection.</remarks>
    Public Function ShowProviderConfiguration() As Boolean

      Try
        Dim configuration As New ConfigurationDialogSettings
        configuration.WindowText = "Provider Configuration"
        Return ShowProviderConfiguration(configuration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the ProviderCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the provider objects in their parent collection.</remarks>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowProviderConfiguration(ByVal dialogSettings As ConfigurationDialogSettings) As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        Call MainObject.FireEventBeforeProviderConfigurationDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim F As New Forms.ProviderConfigForm(Me.MainObject)
        F.DialogSettings = dialogSettings
        F.ProviderCollection = MainObject.ProviderCollection
        Dim dr As DialogResult = F.ShowDialog()
        Call MainObject.FireEventAfterProviderConfigurationDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the CategoryCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the category objects in their parent collection.</remarks>
    Public Function ShowCategoryConfiguration() As Boolean

      Try
        Dim configuration As New ConfigurationDialogSettings
        configuration.WindowText = "Category Configuration"
        Return ShowCategoryConfiguration(configuration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the CategoryCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the category objects in their parent collection.</remarks>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowCategoryConfiguration(ByVal dialogSettings As ConfigurationDialogSettings) As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        Call MainObject.FireEventBeforeCategoryConfigurationDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim F As New Forms.CategoryConfigForm(Me.MainObject)
        F.DialogSettings = dialogSettings
        F.CategoryCollection = MainObject.CategoryCollection
        Dim dr As DialogResult = F.ShowDialog()
        Call MainObject.FireEventAfterCategoryConfigurationDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the RoomCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the room objects in their parent collection.</remarks>
    Public Function ShowRoomConfiguration() As Boolean

      Try
        Dim configuration As New ConfigurationDialogSettings
        configuration.WindowText = "Room Configuration"
        Return ShowRoomConfiguration(configuration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the RoomCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the room objects in their parent collection.</remarks>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowRoomConfiguration(ByVal dialogSettings As ConfigurationDialogSettings) As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        Call MainObject.FireEventBeforeRoomConfigurationDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim F As Forms.RoomConfigForm
        F = New Forms.RoomConfigForm(Me.MainObject)
        F.DialogSettings = dialogSettings
        F.RoomCollection = MainObject.RoomCollection
        Dim dr As DialogResult = F.ShowDialog()
        Call MainObject.FireEventAfterRoomConfigurationDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the AppearanceCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the appearance objects in their parent collection.</remarks>
    Public Function ShowAppearanceConfiguration() As Boolean

      Try
        Dim configuration As New ConfigurationDialogSettings
        configuration.WindowText = "Appearance Configuration"
        Return ShowAppearanceConfiguration(configuration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the AppearanceCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the appearance objects in their parent collection.</remarks>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowAppearanceConfiguration(ByVal dialogSettings As ConfigurationDialogSettings) As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        Call MainObject.FireEventBeforeAppearanceConfigurationDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim F As New Forms.AppearanceConfigForm(Me.MainObject)
        F.DialogSettings = dialogSettings
        F.AppearanceCollection = MainObject.AppearanceCollection
        Dim dr As DialogResult = F.ShowDialog()
        Call MainObject.FireEventAfterAppearanceConfigurationDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the PropertyItemCollection editor
    ''' </summary>
    ''' <param name="propertyItemCollection">The PropertyItemCollection object to edit.</param>
    ''' <remarks>This is a built-in dialog that can be used to edit the PropertyItem objects in their parent collection.</remarks>
    Public Function ShowPropertyItemConfiguration(ByVal propertyItemCollection As PropertyItemCollection) As Boolean

      Try
        Dim configuration As New ConfigurationDialogSettings
        configuration.WindowText = "PropertyItem Configuration"
        Return ShowPropertyItemConfiguration(propertyItemCollection, configuration)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Shows the PropertyItemCollection editor
    ''' </summary>
    ''' <remarks>This is a built-in dialog that can be used to edit the PropertyItem objects in their parent collection.</remarks>
    ''' <param name="propertyItemCollection">The PropertyItemCollection object to edit.</param>
    ''' <param name="dialogSettings">The settings object to setup the dialog.</param>
    Public Function ShowPropertyItemConfiguration(ByVal propertyItemCollection As PropertyItemCollection, ByVal dialogSettings As ConfigurationDialogSettings) As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        Call MainObject.FireEventBeforePropertyItemConfigurationDialog(Me, eventParam1)
        If eventParam1.Cancel Then Return False

        Dim F As Forms.PropertyItemConfigForm
        F = New Forms.PropertyItemConfigForm
        F.DialogSettings = dialogSettings
        F.PropertyItemCollection = propertyItemCollection
        Dim dr As DialogResult = F.ShowDialog()
        Call MainObject.FireEventAfterPropertyItemConfigurationDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function ShowNoDropAreaConfiguration() As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        'Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        'Call MainObject.FireEventBeforePropertyItemConfigurationDialog(Me, eventParam1)
        'If eventParam1.Cancel Then Return False

        Dim F As Forms.ScheduleAreaConfigForm
        F = New Forms.ScheduleAreaConfigForm
        'F.DialogSettings = dialogSettings
        'F.PropertyItemCollection = PropertyItemCollection
        Dim dr As DialogResult = F.ShowDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)
        'Call MainObject.FireEventAfterPropertyItemConfigurationDialog()
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function ShowColoredAreaConfiguration() As Boolean

      Try
        MainObject.TimerEdit.Enabled = False

        'Raise the Before event
        'Dim eventParam1 As New Gravitybox.Objects.EventArgs.BeforeConfigurationDialogEventArgs(dialogSettings)
        'Call MainObject.FireEventBeforePropertyItemConfigurationDialog(Me, eventParam1)
        'If eventParam1.Cancel Then Return False

        Dim F As Forms.ScheduleAreaConfigForm
        F = New Forms.ScheduleAreaConfigForm
        F.MainObject = Me.MainObject
        'F.DialogSettings = dialogSettings
        'F.PropertyItemCollection = PropertyItemCollection
        Dim dr As DialogResult = F.ShowDialog()
        Return (dr = System.Windows.Forms.DialogResult.OK)
        'Call MainObject.FireEventAfterPropertyItemConfigurationDialog()
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

		Public Function ShowAppointmentAppearanceConfiguration() As Boolean

			Try
				MainObject.TimerEdit.Enabled = False

				Dim F As Forms.AppointmentAppearanceForm
				F = New Forms.AppointmentAppearanceForm
				F.MainObject = Me.MainObject
				Dim dr As DialogResult = F.ShowDialog()
				Return (dr = System.Windows.Forms.DialogResult.OK)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

		Public Function ShowScheduleAppearanceConfiguration() As Boolean

			Try
				MainObject.TimerEdit.Enabled = False

				Dim F As Forms.ScheduleAppearanceForm
				F = New Forms.ScheduleAppearanceForm
				F.MainObject = Me.MainObject
				Dim dr As DialogResult = F.ShowDialog()
				Return (dr = System.Windows.Forms.DialogResult.OK)

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try

		End Function

#End Region

#Region "License Dialog"

    Friend Function ShowLicenseDialog() As Boolean

      Try
        Dim F As New Forms.LicenseForm
        F.Dialogs = Me
        Call F.ShowDialog()
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			_mainObject = Nothing
      AlarmScreen = Nothing
#If VS2005 Then
      PropertyScreens.Clear()
#Else
      For ii As Integer = 0 To PropertyScreens.Count - 1
        PropertyScreens.Remove(0)
      Next
#End If

      PropertyScreens = Nothing
		End Sub

#End Region

  End Class

End Namespace