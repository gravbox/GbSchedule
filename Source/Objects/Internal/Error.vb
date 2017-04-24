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

Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

  Friend Class ErrorModule

    Private Shared _instance As ErrorModule
    Private Shared _component As Gravitybox.Controls.Schedule
    Private Shared _useDialog As Boolean = True

    'Private Constructor
    Private Sub New()
    End Sub

    Private Shared ReadOnly Property Component() As Gravitybox.Controls.Schedule
      Get
        Return _component
      End Get
    End Property

    Friend Shared ReadOnly Property Instance() As ErrorModule
      Get
        Try
          If _instance Is Nothing Then
            _instance = New ErrorModule
          End If
          Return _instance
        Catch ex As Exception
          MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return Nothing
      End Get
    End Property

    Friend Shared Sub SetParentComponent(ByVal schedule As Gravitybox.Controls.Schedule)
      Try
        _component = schedule
      Catch ex As Exception
        MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

#Region "SetErr"

    Friend Shared Sub SetErr(ByVal text As String)

      Try
        If (Component Is Nothing) Then
          MsgBox(text, MsgBoxStyle.Exclamation, "Error!")

        ElseIf Component.ErrorHanding = Controls.Schedule.ErrorHandlingConstants.Normal Then
          MsgBox(text, MsgBoxStyle.Exclamation, "Error!")

        ElseIf Component.ErrorHanding = Controls.Schedule.ErrorHandlingConstants.Advanced Then
          'Write the error the event log
          If Not EventLog.SourceExists("Gravitybox") Then
            EventLog.CreateEventSource("Gravitybox", "Gravitybox")
          End If
          EventLog.WriteEntry("Gravitybox", text, EventLogEntryType.Error)

          'Show the error form
          Dim F As New Gravitybox.Forms.ErrorForm(text)
          F.ShowDialog()

        ElseIf Component.ErrorHanding = Controls.Schedule.ErrorHandlingConstants.Ignore Then
          'Do Nothing

        End If
      Catch ex As Exception
        'Do Nothing
      End Try

    End Sub

    Public Shared Sub SetErr(ByVal ex As Exception)
			Call ErrorModule.SetErr(ex.ToString)
    End Sub

#End Region

#Region "ViewmodeErr"

    Public Shared Sub ViewmodeErr()
      Call MsgBox(ScheduleGlobals.MessageNeverGet, MsgBoxStyle.Exclamation)
    End Sub

#End Region

  End Class

End Namespace
