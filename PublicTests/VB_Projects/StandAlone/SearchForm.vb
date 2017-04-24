Option Explicit On 
Option Strict On

Imports Gravitybox.Controls
Imports Gravitybox.Objects
Imports FlatUI.Controls

Namespace Gravitybox.Applications.StandAloneDemo

  Public Class SearchForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal mainFormLink As MainForm)
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      _mainFormLink = mainFormLink

      For Each room As Gravitybox.Objects.Room In mainFormLink.lstRoom.Items
        lstRoom.Items.Add(room)
        lstRoom.SetItemChecked(lstRoom.Items.Count - 1, True)
      Next

      lvwAppointment.Columns.Add("Room", 80, HorizontalAlignment.Left)

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSubjectHeader As System.Windows.Forms.Label
    Friend WithEvents txtSubject As FlatUI.Controls.FlatTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpAfter As FlatUI.Controls.FlatDateTimePicker
    Friend WithEvents dtpBefore As FlatUI.Controls.FlatDateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstRoom As FlatUI.Controls.FlatCheckedListBox
    Friend WithEvents cmdSearch As FlatUI.Controls.XPButton
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwAppointment As FlatUI.Controls.FlatListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.cmdSearch = New FlatUI.Controls.XPButton
      Me.lstRoom = New FlatUI.Controls.FlatCheckedListBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.dtpBefore = New FlatUI.Controls.FlatDateTimePicker
      Me.dtpAfter = New FlatUI.Controls.FlatDateTimePicker
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtSubject = New FlatUI.Controls.FlatTextBox
      Me.lblSubjectHeader = New System.Windows.Forms.Label
      Me.lvwAppointment = New FlatUI.Controls.FlatListView
      Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
      Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.cmdSearch)
      Me.Panel1.Controls.Add(Me.lstRoom)
      Me.Panel1.Controls.Add(Me.Label3)
      Me.Panel1.Controls.Add(Me.dtpBefore)
      Me.Panel1.Controls.Add(Me.dtpAfter)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.txtSubject)
      Me.Panel1.Controls.Add(Me.lblSubjectHeader)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(458, 152)
      Me.Panel1.TabIndex = 0
      '
      'cmdSearch
      '
      Me.cmdSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSearch.Location = New System.Drawing.Point(368, 120)
      Me.cmdSearch.Name = "cmdSearch"
      Me.cmdSearch.Size = New System.Drawing.Size(80, 24)
      Me.cmdSearch.TabIndex = 4
      Me.cmdSearch.Text = "Search"
      '
      'lstRoom
      '
      Me.lstRoom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstRoom.CheckOnClick = True
      Me.lstRoom.IntegralHeight = False
      Me.lstRoom.Location = New System.Drawing.Point(96, 56)
      Me.lstRoom.Name = "lstRoom"
      Me.lstRoom.Size = New System.Drawing.Size(264, 88)
      Me.lstRoom.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(8, 56)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(80, 16)
      Me.Label3.TabIndex = 6
      Me.Label3.Text = "Providers:"
      '
      'dtpBefore
      '
      Me.dtpBefore.Checked = False
      Me.dtpBefore.Format = DateTimePickerFormat.Short
      Me.dtpBefore.Location = New System.Drawing.Point(328, 32)
      Me.dtpBefore.Name = "dtpBefore"
      Me.dtpBefore.ShowCheckBox = True
      Me.dtpBefore.Size = New System.Drawing.Size(120, 20)
      Me.dtpBefore.TabIndex = 2
      '
      'dtpAfter
      '
      Me.dtpAfter.Checked = False
      Me.dtpAfter.Format = DateTimePickerFormat.Short
      Me.dtpAfter.Location = New System.Drawing.Point(96, 32)
      Me.dtpAfter.Name = "dtpAfter"
      Me.dtpAfter.ShowCheckBox = True
      Me.dtpAfter.Size = New System.Drawing.Size(120, 20)
      Me.dtpAfter.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(224, 32)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(96, 16)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Starting before:"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(8, 32)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 16)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Starting after:"
      '
      'txtSubject
      '
      Me.txtSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSubject.Location = New System.Drawing.Point(96, 8)
      Me.txtSubject.Name = "txtSubject"
      Me.txtSubject.Size = New System.Drawing.Size(352, 20)
      Me.txtSubject.TabIndex = 0
      Me.txtSubject.Text = ""
      '
      'lblSubjectHeader
      '
      Me.lblSubjectHeader.Location = New System.Drawing.Point(8, 8)
      Me.lblSubjectHeader.Name = "lblSubjectHeader"
      Me.lblSubjectHeader.Size = New System.Drawing.Size(80, 16)
      Me.lblSubjectHeader.TabIndex = 0
      Me.lblSubjectHeader.Text = "Subject:"
      '
      'lvwAppointment
      '
      Me.lvwAppointment.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
      Me.lvwAppointment.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lvwAppointment.FullRowSelect = True
      Me.lvwAppointment.HideSelection = False
      Me.lvwAppointment.Location = New System.Drawing.Point(0, 152)
      Me.lvwAppointment.MultiSelect = False
      Me.lvwAppointment.Name = "lvwAppointment"
      Me.lvwAppointment.Size = New System.Drawing.Size(458, 98)
      Me.lvwAppointment.TabIndex = 5
      Me.lvwAppointment.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Subject"
      Me.ColumnHeader1.Width = 130
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Start date"
      Me.ColumnHeader2.Width = 70
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Start time"
      Me.ColumnHeader3.Width = 70
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Length"
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Provider"
      Me.ColumnHeader5.Width = 80
      '
      'SearchForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(458, 250)
      Me.Controls.Add(Me.lvwAppointment)
      Me.Controls.Add(Me.Panel1)
      Me.MaximizeBox = False
      Me.MinimumSize = New System.Drawing.Size(464, 272)
      Me.Name = "SearchForm"
      Me.Text = "Search"
      Me.TopMost = True
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Class Members"

    Private _mainFormLink As MainForm

#End Region

#Region "Form Events"

    Private Sub SearchForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      MainFormLink.CloseSearch()
    End Sub

#End Region

#Region "Property Implementations"

    Private ReadOnly Property MainFormLink() As MainForm
      Get
        Return _mainFormLink
      End Get
    End Property

#End Region

#Region "Search Button"

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
      PerformSearch()
    End Sub

#End Region

#Region "Actions"

    Private Sub lvwAppointment_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAppointment.DoubleClick
      ProcessAppointment()
    End Sub

    Private Sub lvwAppointment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvwAppointment.KeyDown

      If e.KeyData = Keys.Enter Then
        ProcessAppointment()
      ElseIf e.KeyData = Keys.Delete Then
        DeleteAppointment()
      End If

    End Sub

    Private Sub ProcessAppointment()

      If lvwAppointment.SelectedItems.Count > 0 Then
        Dim appt As Appointment = CType(lvwAppointment.SelectedItems(0).Tag, Appointment)
        MainFormLink.SetDate(appt.StartDate)
        MainFormLink.Schedule1.Visibility.ShowDate(appt.StartDate)
        MainFormLink.Schedule1.Visibility.ShowTime(appt.StartTime)
        MainFormLink.Schedule1.Visibility.ShowRoom(appt.Room)
        If appt.ProviderList.Count > 0 Then
					MainFormLink.Schedule1.Visibility.ShowProvider(CType(appt.ProviderList(0), Provider))
        End If

        'Minimize the search window
        Me.WindowState = FormWindowState.Minimized

        'Set the SelectedItem
        MainFormLink.Schedule1.SelectedItem = appt

        'Edit the appointment
        MainFormLink.Schedule1.Dialogs.ShowPropertyDialog(MainFormLink.Schedule1.SelectedItem)

      End If

    End Sub

    Private Sub DeleteAppointment()

      If lvwAppointment.SelectedItems.Count > 0 Then
        If MsgBox("Do you wish to remove the selected appointments?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Delete?") = MsgBoxResult.Yes Then
          Dim appt As Appointment = CType(lvwAppointment.SelectedItems(0).Tag, Appointment)
          MainFormLink.Schedule1.AppointmentCollection.Remove(appt)
          PerformSearch() 'Requery
        End If
      End If

    End Sub

#End Region

#Region "PerformSearch"

    Private Sub PerformSearch()

      Try
        Dim afterDate As Date = New Date(dtpAfter.Value.Year, dtpAfter.Value.Month, dtpAfter.Value.Day)
        Dim beforeDate As Date = New Date(dtpBefore.Value.Year, dtpBefore.Value.Month, dtpBefore.Value.Day)

        lvwAppointment.Items.Clear()
        For Each appointment As appointment In MainFormLink.Schedule1.AppointmentCollection
          Dim included As Boolean = True

          'If there is a subject then use it
          If txtSubject.Text <> "" Then
            If appointment.Subject.ToLower.IndexOf(txtSubject.Text.ToLower) = -1 Then
              included = False
            End If
          End If

          'Now check for after date
          If included Then
            If dtpAfter.Checked Then
              If appointment.StartDate < afterDate Then
                included = False
              End If
            End If
          End If

          'Now check for before date
          If included Then
            If dtpBefore.Checked Then
              If appointment.StartDate > beforeDate Then
                included = False
              End If
            End If
          End If

          'Now check providers
          Dim roomFound As Boolean = False
          For Each room As Gravitybox.Objects.Room In lstRoom.CheckedItems
            If (Not (appointment.Room Is Nothing)) AndAlso (room.Key = appointment.Room.Key) Then
              roomFound = True
            End If
          Next
          included = included And roomFound

          'If passed all tests then add it list
          If included Then
            Dim li As New ListViewItem(appointment.Subject)
            li.SubItems.Add(appointment.StartDate.ToString("yyyy-MM-dd"))
            li.SubItems.Add(appointment.StartTime.ToString("hh:mm tt"))
            li.SubItems.Add(appointment.Length.ToString(""))
            If appointment.ProviderList.Count = 0 Then
              li.SubItems.Add("---")
            Else
              li.SubItems.Add(appointment.ProviderList(0).Text)
            End If

            If appointment.Room Is Nothing Then
              li.SubItems.Add("---")
            Else
              li.SubItems.Add(appointment.Room.Text)
            End If

            li.Tag = appointment
            lvwAppointment.Items.Add(li)

          End If

        Next

      Catch ex As Exception
        SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace