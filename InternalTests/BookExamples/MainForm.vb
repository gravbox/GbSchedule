Public Class MainForm
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
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents cmdFigure17 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure16 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure13 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure12 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure11 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure23 As System.Windows.Forms.Button
  Friend WithEvents cmdTestForm As System.Windows.Forms.Button
  Friend WithEvents cmdImportExport As System.Windows.Forms.Button
  Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
  Friend WithEvents cmdFigure65 As System.Windows.Forms.Button
  Friend WithEvents cmdFIgure64 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure63 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure62 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure61 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure31 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure66 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure15 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure14 As System.Windows.Forms.Button
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents cmdFigure71 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure81 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure82 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure84 As System.Windows.Forms.Button
  Friend WithEvents cmdFigure85 As System.Windows.Forms.Button
  Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
  Friend WithEvents cmdFigure121 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.cmdFigure17 = New System.Windows.Forms.Button()
    Me.cmdFigure16 = New System.Windows.Forms.Button()
    Me.cmdFigure15 = New System.Windows.Forms.Button()
    Me.cmdFigure14 = New System.Windows.Forms.Button()
    Me.cmdFigure13 = New System.Windows.Forms.Button()
    Me.cmdFigure12 = New System.Windows.Forms.Button()
    Me.cmdFigure11 = New System.Windows.Forms.Button()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.cmdFigure31 = New System.Windows.Forms.Button()
    Me.cmdFigure23 = New System.Windows.Forms.Button()
    Me.TabPage4 = New System.Windows.Forms.TabPage()
    Me.cmdFigure66 = New System.Windows.Forms.Button()
    Me.cmdFigure65 = New System.Windows.Forms.Button()
    Me.cmdFIgure64 = New System.Windows.Forms.Button()
    Me.cmdFigure63 = New System.Windows.Forms.Button()
    Me.cmdFigure62 = New System.Windows.Forms.Button()
    Me.cmdFigure61 = New System.Windows.Forms.Button()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.cmdFigure85 = New System.Windows.Forms.Button()
    Me.cmdFigure84 = New System.Windows.Forms.Button()
    Me.cmdFigure82 = New System.Windows.Forms.Button()
    Me.cmdFigure81 = New System.Windows.Forms.Button()
    Me.cmdFigure71 = New System.Windows.Forms.Button()
    Me.cmdTestForm = New System.Windows.Forms.Button()
    Me.cmdImportExport = New System.Windows.Forms.Button()
    Me.TabPage5 = New System.Windows.Forms.TabPage()
    Me.cmdFigure121 = New System.Windows.Forms.Button()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    Me.TabPage4.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    Me.TabPage5.SuspendLayout()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage4, Me.TabPage5, Me.TabPage3})
    Me.TabControl1.Location = New System.Drawing.Point(8, 8)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(208, 264)
    Me.TabControl1.TabIndex = 7
    '
    'TabPage1
    '
    Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdFigure17, Me.cmdFigure16, Me.cmdFigure15, Me.cmdFigure14, Me.cmdFigure13, Me.cmdFigure12, Me.cmdFigure11})
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Size = New System.Drawing.Size(200, 238)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "1"
    '
    'cmdFigure17
    '
    Me.cmdFigure17.Location = New System.Drawing.Point(8, 200)
    Me.cmdFigure17.Name = "cmdFigure17"
    Me.cmdFigure17.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure17.TabIndex = 13
    Me.cmdFigure17.Text = "Figure 1.7"
    '
    'cmdFigure16
    '
    Me.cmdFigure16.Location = New System.Drawing.Point(8, 168)
    Me.cmdFigure16.Name = "cmdFigure16"
    Me.cmdFigure16.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure16.TabIndex = 12
    Me.cmdFigure16.Text = "Figure 1.6"
    '
    'cmdFigure15
    '
    Me.cmdFigure15.Location = New System.Drawing.Point(8, 136)
    Me.cmdFigure15.Name = "cmdFigure15"
    Me.cmdFigure15.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure15.TabIndex = 11
    Me.cmdFigure15.Text = "Figure 1.5"
    '
    'cmdFigure14
    '
    Me.cmdFigure14.Location = New System.Drawing.Point(8, 104)
    Me.cmdFigure14.Name = "cmdFigure14"
    Me.cmdFigure14.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure14.TabIndex = 10
    Me.cmdFigure14.Text = "Figure 1.4"
    '
    'cmdFigure13
    '
    Me.cmdFigure13.Location = New System.Drawing.Point(8, 72)
    Me.cmdFigure13.Name = "cmdFigure13"
    Me.cmdFigure13.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure13.TabIndex = 9
    Me.cmdFigure13.Text = "Figure 1.3"
    '
    'cmdFigure12
    '
    Me.cmdFigure12.Location = New System.Drawing.Point(8, 40)
    Me.cmdFigure12.Name = "cmdFigure12"
    Me.cmdFigure12.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure12.TabIndex = 8
    Me.cmdFigure12.Text = "Figure 1.2"
    '
    'cmdFigure11
    '
    Me.cmdFigure11.Location = New System.Drawing.Point(8, 8)
    Me.cmdFigure11.Name = "cmdFigure11"
    Me.cmdFigure11.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure11.TabIndex = 7
    Me.cmdFigure11.Text = "Figure 1.1"
    '
    'TabPage2
    '
    Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdFigure31, Me.cmdFigure23})
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Size = New System.Drawing.Size(200, 238)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "2/3"
    '
    'cmdFigure31
    '
    Me.cmdFigure31.Location = New System.Drawing.Point(8, 40)
    Me.cmdFigure31.Name = "cmdFigure31"
    Me.cmdFigure31.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure31.TabIndex = 10
    Me.cmdFigure31.Text = "Figure 3.1"
    '
    'cmdFigure23
    '
    Me.cmdFigure23.Location = New System.Drawing.Point(8, 8)
    Me.cmdFigure23.Name = "cmdFigure23"
    Me.cmdFigure23.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure23.TabIndex = 8
    Me.cmdFigure23.Text = "Figure 2.3"
    '
    'TabPage4
    '
    Me.TabPage4.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdFigure66, Me.cmdFigure65, Me.cmdFIgure64, Me.cmdFigure63, Me.cmdFigure62, Me.cmdFigure61})
    Me.TabPage4.Location = New System.Drawing.Point(4, 22)
    Me.TabPage4.Name = "TabPage4"
    Me.TabPage4.Size = New System.Drawing.Size(200, 238)
    Me.TabPage4.TabIndex = 3
    Me.TabPage4.Text = "6"
    '
    'cmdFigure66
    '
    Me.cmdFigure66.Location = New System.Drawing.Point(8, 168)
    Me.cmdFigure66.Name = "cmdFigure66"
    Me.cmdFigure66.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure66.TabIndex = 20
    Me.cmdFigure66.Text = "Figure 6.6"
    '
    'cmdFigure65
    '
    Me.cmdFigure65.Location = New System.Drawing.Point(8, 136)
    Me.cmdFigure65.Name = "cmdFigure65"
    Me.cmdFigure65.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure65.TabIndex = 19
    Me.cmdFigure65.Text = "Figure 6.5"
    '
    'cmdFIgure64
    '
    Me.cmdFIgure64.Location = New System.Drawing.Point(8, 104)
    Me.cmdFIgure64.Name = "cmdFIgure64"
    Me.cmdFIgure64.Size = New System.Drawing.Size(104, 24)
    Me.cmdFIgure64.TabIndex = 18
    Me.cmdFIgure64.Text = "Figure 6.4"
    '
    'cmdFigure63
    '
    Me.cmdFigure63.Location = New System.Drawing.Point(8, 72)
    Me.cmdFigure63.Name = "cmdFigure63"
    Me.cmdFigure63.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure63.TabIndex = 17
    Me.cmdFigure63.Text = "Figure 6.3"
    '
    'cmdFigure62
    '
    Me.cmdFigure62.Location = New System.Drawing.Point(8, 40)
    Me.cmdFigure62.Name = "cmdFigure62"
    Me.cmdFigure62.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure62.TabIndex = 16
    Me.cmdFigure62.Text = "Figure 6.2"
    '
    'cmdFigure61
    '
    Me.cmdFigure61.Location = New System.Drawing.Point(8, 8)
    Me.cmdFigure61.Name = "cmdFigure61"
    Me.cmdFigure61.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure61.TabIndex = 15
    Me.cmdFigure61.Text = "Figure 6.1"
    '
    'TabPage3
    '
    Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdFigure85, Me.cmdFigure84, Me.cmdFigure82, Me.cmdFigure81, Me.cmdFigure71})
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Size = New System.Drawing.Size(200, 238)
    Me.TabPage3.TabIndex = 4
    Me.TabPage3.Text = "7/8"
    '
    'cmdFigure85
    '
    Me.cmdFigure85.Location = New System.Drawing.Point(8, 136)
    Me.cmdFigure85.Name = "cmdFigure85"
    Me.cmdFigure85.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure85.TabIndex = 12
    Me.cmdFigure85.Text = "Figure 8.5"
    '
    'cmdFigure84
    '
    Me.cmdFigure84.Location = New System.Drawing.Point(8, 104)
    Me.cmdFigure84.Name = "cmdFigure84"
    Me.cmdFigure84.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure84.TabIndex = 11
    Me.cmdFigure84.Text = "Figure 8.4"
    '
    'cmdFigure82
    '
    Me.cmdFigure82.Location = New System.Drawing.Point(8, 72)
    Me.cmdFigure82.Name = "cmdFigure82"
    Me.cmdFigure82.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure82.TabIndex = 10
    Me.cmdFigure82.Text = "Figure 8.2"
    '
    'cmdFigure81
    '
    Me.cmdFigure81.Location = New System.Drawing.Point(8, 40)
    Me.cmdFigure81.Name = "cmdFigure81"
    Me.cmdFigure81.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure81.TabIndex = 9
    Me.cmdFigure81.Text = "Figure 8.1"
    '
    'cmdFigure71
    '
    Me.cmdFigure71.Location = New System.Drawing.Point(8, 8)
    Me.cmdFigure71.Name = "cmdFigure71"
    Me.cmdFigure71.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure71.TabIndex = 8
    Me.cmdFigure71.Text = "Figure 7.1"
    '
    'cmdTestForm
    '
    Me.cmdTestForm.Location = New System.Drawing.Point(24, 280)
    Me.cmdTestForm.Name = "cmdTestForm"
    Me.cmdTestForm.Size = New System.Drawing.Size(104, 24)
    Me.cmdTestForm.TabIndex = 14
    Me.cmdTestForm.Text = "Test Form"
    '
    'cmdImportExport
    '
    Me.cmdImportExport.Location = New System.Drawing.Point(24, 312)
    Me.cmdImportExport.Name = "cmdImportExport"
    Me.cmdImportExport.Size = New System.Drawing.Size(104, 24)
    Me.cmdImportExport.TabIndex = 15
    Me.cmdImportExport.Text = "Import / Export"
    '
    'TabPage5
    '
    Me.TabPage5.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdFigure121})
    Me.TabPage5.Location = New System.Drawing.Point(4, 22)
    Me.TabPage5.Name = "TabPage5"
    Me.TabPage5.Size = New System.Drawing.Size(200, 238)
    Me.TabPage5.TabIndex = 5
    Me.TabPage5.Text = "12"
    '
    'cmdFigure121
    '
    Me.cmdFigure121.Location = New System.Drawing.Point(8, 8)
    Me.cmdFigure121.Name = "cmdFigure121"
    Me.cmdFigure121.Size = New System.Drawing.Size(104, 24)
    Me.cmdFigure121.TabIndex = 8
    Me.cmdFigure121.Text = "Figure 12.1"
    '
    'MainForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(218, 343)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdImportExport, Me.cmdTestForm, Me.TabControl1})
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Book"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage2.ResumeLayout(False)
    Me.TabPage4.ResumeLayout(False)
    Me.TabPage3.ResumeLayout(False)
    Me.TabPage5.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Location = New Point(0, 0)
  End Sub

  Private Sub cmdTestForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestForm.Click
    Dim F As New TestForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure11.Click
    Dim F As New Figure11()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure12.Click
    Dim F As New Figure12()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure13.Click
    Dim F As New Figure13()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdIFgure14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure14.Click
    Dim F As New Figure14()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdIFgure15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure15.Click
    Dim F As New Figure15()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure16.Click
    Dim F As New Figure16()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure17.Click
    Dim F As New Figure17()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure23.Click
    Dim F As New Figure23()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure31.Click
    Dim F As New Figure31()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdImportExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImportExport.Click
    Dim F As New ImportExportForm()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure61.Click
    Dim F As New Figure61()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure62.Click
    Dim F As New Figure62()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure63.Click
    Dim F As New Figure63()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFIgure64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFIgure64.Click
    Dim F As New Figure64()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure65.Click
    Dim F As New Figure65()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure66.Click
    Dim F As New Figure66()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure71.Click
    Dim F As New Figure71()
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure81.Click
    Dim F As New Figure8x()

    'Add some Categories
    Dim category As Gravitybox.Objects.Category
    category = F.Schedule1.CategoryCollection.Add("", "Major", Color.Blue)
    category.Notes = "Some Notes"
    category = F.Schedule1.CategoryCollection.Add("", "Surgery", Color.Yellow)
    category.Notes = "Some Notes"
    category = F.Schedule1.CategoryCollection.Add("", "Cleaning", Color.Green)
    category.Notes = "Some Notes"
    F.Schedule1.Dialogs.ShowCategoryConfiguration()
    F.Schedule1.Dialogs.ShowProviderConfiguration()
    F.Schedule1.Dialogs.ShowRoomConfiguration()

    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure82.Click
    Dim F As New Figure8x()

    'Add some Categories
    Dim category As Gravitybox.Objects.Category
    category = F.Schedule1.CategoryCollection.Add("", "Major", Color.Blue)
    category.Notes = "Some Notes"
    category = F.Schedule1.CategoryCollection.Add("", "Surgery", Color.Yellow)
    category.Notes = "Some Notes"
    category = F.Schedule1.CategoryCollection.Add("", "Cleaning", Color.Green)
    category.Notes = "Some Notes"

    'Add an appointment
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.CategoryList.Add(category)
    F.Schedule1.Dialogs.ShowCategoryDialog(appointment)
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure84.Click
    Dim F As New Figure8x()

    'Add some Providers
    Dim provider As Gravitybox.Objects.Provider
    provider = F.Schedule1.ProviderCollection.Add("", "John Doe", Color.Blue)
    provider.Notes = "Some Notes"
    provider = F.Schedule1.ProviderCollection.Add("", "Sally Majors", Color.Yellow)
    provider.Notes = "Some Notes"
    provider = F.Schedule1.ProviderCollection.Add("", "Jeff Winters", Color.Green)
    provider.Notes = "Some Notes"

    'Add an appointment
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.ProviderList.Add(provider)
    F.Schedule1.Dialogs.ShowProviderDialog(appointment)
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure85.Click
    Dim F As New Figure8x()

    'Add some Providers
    Dim provider As Gravitybox.Objects.Provider
    provider = F.Schedule1.ProviderCollection.Add("", "John Doe", Color.Blue)
    provider.Notes = "Some Notes"
    provider = F.Schedule1.ProviderCollection.Add("", "Sally Majors", Color.Yellow)
    provider.Notes = "Some Notes"
    provider = F.Schedule1.ProviderCollection.Add("", "Jeff Winters", Color.Green)
    provider.Notes = "Some Notes"

    'Add an appointment
    Dim appointment As Gravitybox.Objects.Appointment
    appointment = F.Schedule1.AppointmentCollection.Add("", #1/1/2004#, #8:00:00 AM#, 60)
    appointment.Subject = "Dental Cleaning"
    appointment.Text = "This is some notes!"
    appointment.ProviderList.Add(provider)
    F.Schedule1.Dialogs.ShowPropertyDialog(appointment)
    Call F.ShowDialog()
  End Sub

  Private Sub cmdFigure121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFigure121.Click
    Dim F As New Figure121()
    Call F.ShowDialog()
  End Sub

End Class