Option Explicit On 
Option Strict On

Namespace Gravitybox.Applications.StandAloneDemo

  Module Globals

    Public Sub SetErr(ByVal ex As Exception)
      MsgBox(ex.ToString, MsgBoxStyle.Exclamation, "Error!")
    End Sub

  End Module

End Namespace