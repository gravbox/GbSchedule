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

  Friend Class RecurForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents AppointmentRecurrence1 As Gravitybox.Controls.AppointmentRecurrence
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.AppointmentRecurrence1 = New Gravitybox.Controls.AppointmentRecurrence
			Me.cmdCancel = New System.Windows.Forms.Button
			Me.cmdOK = New System.Windows.Forms.Button
			Me.SuspendLayout()
			'
			'AppointmentRecurrence1
			'
			Me.AppointmentRecurrence1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
									Or System.Windows.Forms.AnchorStyles.Left) _
									Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.AppointmentRecurrence1.Appointment = Nothing
			Me.AppointmentRecurrence1.AppointmentCollection = Nothing
			Me.AppointmentRecurrence1.Location = New System.Drawing.Point(8, 8)
			Me.AppointmentRecurrence1.Name = "AppointmentRecurrence1"
			Me.AppointmentRecurrence1.Recurrence = Nothing
			Me.AppointmentRecurrence1.Size = New System.Drawing.Size(528, 280)
			Me.AppointmentRecurrence1.TabIndex = 0
			'
			'cmdCancel
			'
			Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdCancel.Location = New System.Drawing.Point(448, 288)
			Me.cmdCancel.Name = "cmdCancel"
			Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
			Me.cmdCancel.TabIndex = 7
			Me.cmdCancel.Text = "&Cancel"
			'
			'cmdOK
			'
			Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
			Me.cmdOK.Location = New System.Drawing.Point(360, 288)
			Me.cmdOK.Name = "cmdOK"
			Me.cmdOK.Size = New System.Drawing.Size(80, 24)
			Me.cmdOK.TabIndex = 6
			Me.cmdOK.Text = "&OK"
			'
			'RecurForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(538, 319)
			Me.Controls.Add(Me.cmdCancel)
			Me.Controls.Add(Me.cmdOK)
			Me.Controls.Add(Me.AppointmentRecurrence1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "RecurForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Appointment Recurrence"
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "Class Members"

    Private m_ReturnValues As ReturnValues
    Private m_DialogSettings As New Gravitybox.Objects.RecurrenceDialogSettings

#End Region

#Region "Form Handlers"

#If VS2005 Then
    Private Sub Form_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
			Me.Dispose()
		End Sub
#End If

#End Region

#Region "Property Implementations"

    Public Property Recurrence() As Recurrence
      Get
        Return Me.AppointmentRecurrence1.Recurrence
      End Get
      Set(ByVal Value As Recurrence)
        Me.AppointmentRecurrence1.Recurrence = Value
      End Set
    End Property

    Public Property Appointment() As Appointment
      Get
        Return Me.AppointmentRecurrence1.Appointment
      End Get
      Set(ByVal Value As Appointment)
        Me.AppointmentRecurrence1.Appointment = Value
      End Set
    End Property

    Public Property ReturnValues() As ReturnValues
      Get
        Return m_ReturnValues
      End Get
      Set(ByVal Value As ReturnValues)
        m_ReturnValues = Value
      End Set
    End Property

    Public Property DialogSettings() As Gravitybox.Objects.RecurrenceDialogSettings
      Get
        Return m_DialogSettings
      End Get
      Set(ByVal Value As Gravitybox.Objects.RecurrenceDialogSettings)
        If Value Is Nothing Then
          m_DialogSettings = New RecurrenceDialogSettings
        Else
          m_DialogSettings = Value
        End If
        Me.Text = Value.WindowText
        Me.StartPosition = Value.StartPosition
        'Me.Location = Value.Location
        'Me.Size = Value.Size
        'Me.FormBorderStyle = Value.FormBorderStyle
        Me.cmdOK.Text = Value.OkButtonText
        Me.cmdCancel.Text = Value.CancelButtonText
        Me.AppointmentRecurrence1.RecurrenceDialogSettings = Value
      End Set
    End Property

#End Region

#Region "Methods"

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

      If Not Me.AppointmentRecurrence1.Recurrence.IsValid Then
        Call MsgBox(DialogSettings.ErrorStringInvalidRecurrence, MsgBoxStyle.Exclamation, "Error!")
      Else
        Me.ReturnValues(0).Setting = True
        Call Me.ReturnValues.Add(Me.AppointmentRecurrence1.Recurrence)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Call Me.Close()
      End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
      Call Me.Close()
    End Sub

#End Region

  End Class

End Namespace