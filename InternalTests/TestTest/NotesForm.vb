Public Class NotesForm
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
  Friend WithEvents Notes1 As GbSchedule.Notes
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Notes1 = New GbSchedule.Notes()
    Me.SuspendLayout()
    '
    'Notes1
    '
    Me.Notes1.AllowAdd = True
    Me.Notes1.AllowCopy = True
    Me.Notes1.AllowDelete = True
    Me.Notes1.AllowEdit = True
    Me.Notes1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Notes1.Name = "Notes1"
    Me.Notes1.Size = New System.Drawing.Size(312, 205)
    Me.Notes1.TabIndex = 0
    Me.Notes1.View = GbSchedule.Notes.NotesViewConstants.LargeIcons
    '
    'NotesForm
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(312, 205)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Notes1})
    Me.Name = "NotesForm"
    Me.Text = "NotesForm"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub NotesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Call Notes1.NoteItems.Add("", "Hello")
    Call Notes1.NoteItems.Add("", "Just for you")
    Call Notes1.NoteItems.Add("", "Chris Davis")

  End Sub

End Class
