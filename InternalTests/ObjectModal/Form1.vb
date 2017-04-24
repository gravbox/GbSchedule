Public Class Form1
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
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
    Me.Button1.Location = New System.Drawing.Point(464, 312)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(80, 24)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Load"
    '
    'TextBox1
    '
    Me.TextBox1.Multiline = True
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.TextBox1.Size = New System.Drawing.Size(544, 304)
    Me.TextBox1.TabIndex = 2
    Me.TextBox1.Text = ""
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(544, 341)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1, Me.Button1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Const path As String = "c:\Reflection.txt"

    Dim classInfo As New ClassInfo()
    Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFrom("C:\projects\Production\Schedule.NET\Source\bin\GbSchedule.dll")
    Dim typeArr As System.Type() = a.GetTypes
    Dim t As System.Type

    'Remove the file if necessary
    'If System.IO.File.Exists(path) Then
    'Call System.IO.File.Delete(path)
    'End If

    'Dim myFile As IO.File
    'Dim SW As IO.StreamWriter
    'SW = myFile.AppendText(path)
    'Call SW.Write(classInfo.GetClassInfo(t))

    For Each t In typeArr
      If t.Name = "Schedule" Then
        Debug.WriteLine(t.Name)

        Dim mArr As System.Reflection.MemberInfo() = t.GetMembers
        Dim m As System.Reflection.MemberInfo

        For Each m In mArr
          If m.Name.StartsWith("add_") Then
            'do nothing
          ElseIf m.Name.StartsWith("remove_") Then
            'do nothing
          ElseIf m.Name.StartsWith("get_") Then
            'do nothing
          ElseIf m.Name.StartsWith("set_") Then
            'do nothing
          Else
            Debug.WriteLine(m.Name & "  " & m.MemberType.ToString)
          End If
        Next

      End If
    Next

    'Call SW.Close()
    Call MsgBox("Done!", MsgBoxStyle.Information)

  End Sub

End Class
