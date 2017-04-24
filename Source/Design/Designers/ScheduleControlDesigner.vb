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

Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports System.ComponentModel.Design
Imports System.Windows.Forms.Design
Imports Gravitybox.Objects

Namespace Gravitybox.Design.Designers

  Friend Class ScheduleControlDesigner
    Inherits ControlDesigner

    Private SiteSchedule As Gravitybox.Controls.Schedule

#Region "Verbs"

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
      Get
        Dim col As New System.ComponentModel.Design.DesignerVerbCollection
        Try
          Dim verb As System.ComponentModel.Design.DesignerVerb

          verb = New System.ComponentModel.Design.DesignerVerb("About", AddressOf ShowAboutBox)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Room Setup", AddressOf ShowRoomSetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Category Setup", AddressOf ShowCategorySetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Provider Setup", AddressOf ShowProviderSetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Appearance Setup", AddressOf ShowAppearanceSetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Schedule Appearance", AddressOf ShowScheduleAppearanceSetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Appointment Appearance", AddressOf ShowAppointmentAppearanceSetup)
          col.Add(verb)

          verb = New System.ComponentModel.Design.DesignerVerb("Reset Appearances", AddressOf ResetAppearances)
          col.Add(verb)

          'verb = New System.ComponentModel.Design.DesignerVerb("Generate Dataset", AddressOf GenerateDataset)
          'col.Add(verb)

          'verb = New System.ComponentModel.Design.DesignerVerb("NoDropArea Setup", AddressOf ShowNoDropAreaSetup)
          'col.Add(verb)

          'verb = New System.ComponentModel.Design.DesignerVerb("ColoredArea Setup", AddressOf ShowColoredAreaSetup)
          'col.Add(verb)
        Catch ex As Exception
					ErrorModule.SetErr(ex)
        End Try
        Return col
      End Get
    End Property

#End Region

#Region "Methods"

    Private Sub ShowAboutBox(ByVal sender As Object, ByVal e As System.EventArgs)

      Try
        Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
        If dialogs.ShowAboutDialog() Then
          'Tell the control to something has changed (so it will persist)
          SiteSchedule.DrawingDirty = True
          SiteSchedule.Refresh()
          SiteSchedule.SetupScroll()
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowRoomSetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowRoomConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowAppearanceSetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowAppearanceConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowCategorySetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowCategoryConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowProviderSetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowProviderConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowScheduleAppearanceSetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowScheduleAppearanceConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ShowAppointmentAppearanceSetup(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
				If dialogs.ShowAppointmentAppearanceConfiguration() Then
					'Tell the control to something has changed (so it will persist)
					SiteSchedule.DrawingDirty = True
					SiteSchedule.Refresh()
					SiteSchedule.SetupScroll()
					RaiseComponentChanged(Nothing, "", "")
        End If
        dialogs.Dispose()

      Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		Private Sub ResetAppearances(ByVal sender As Object, ByVal e As System.EventArgs)

			Try
				If MsgBox("Do you wish to reset all Appearance objects on the schedule?", MsgBoxStyle.YesNo, "Reset?") = MsgBoxResult.Yes Then
					SiteSchedule.DefaultAppointmentAppearance.FromXML((New Gravitybox.Objects.AppointmentAppearance).ToXML)
					SiteSchedule.DefaultAppointmentHeaderAppearance.FromXML((New Gravitybox.Objects.AppointmentHeaderAppearance).ToXML)
					Call SiteSchedule.SetDefaultAppearance()
					Call SiteSchedule.SetDefaultRowColAppearance()
					RaiseComponentChanged(Nothing, "", "")
				End If

			Catch ex As Exception
				ErrorModule.SetErr(ex)
			End Try

		End Sub

		'Private Sub ShowNoDropAreaSetup(ByVal sender As Object, ByVal e As System.EventArgs)
		'  Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
		'  If dialogs.ShowNoDropAreaConfiguration() Then
		'    'Tell the control to something has changed (so it will persist)
		'    SiteSchedule.DrawingDirty = True
		'    SiteSchedule.Refresh()
		'    SiteSchedule.SetupScroll()
		'    RaiseComponentChanged(Nothing, "", "")
		'  End If
		'End Sub

		'Private Sub ShowColoredAreaSetup(ByVal sender As Object, ByVal e As System.EventArgs)
		'  Dim dialogs As New Objects.ScheduleDialog(SiteSchedule)
		'  If dialogs.ShowColoredAreaConfiguration() Then
		'    'Tell the control to something has changed (so it will persist)
		'    SiteSchedule.DrawingDirty = True
		'    SiteSchedule.Refresh()
		'    SiteSchedule.SetupScroll()
		'    RaiseComponentChanged(Nothing, "", "")
		'  End If
		'End Sub

#End Region

#Region "Dataset Generation"

    'Private Sub GenerateDataset(ByVal sender As Object, ByVal e As System.EventArgs)

    '  Try
    '    Dim dte As EnvDTE._DTE = CType(System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE"), EnvDTE._DTE)
    '    Dim projects As System.Array = CType(dte.ActiveSolutionProjects, System.Array)
    '    If projects.Length = 1 Then
    '      Dim project As EnvDTE.Project = CType(projects.GetValue(0), EnvDTE.Project)
    '      Dim beforeCount As Integer = project.ProjectItems.Count

    '      'Prompt the user for the new name
    '      Dim newName As String = "ScheduleDataset"
    '      newName = InputBox("Enter the name of the new dataset.", "New Gravitybox Schedule Dataset", newName)
    '      If newName = "" Then
    '        Return
    '      End If

    '      'Create the temp file
    '      Dim tempFile As String = System.IO.Path.GetTempFileName
    '      Dim sw As System.IO.StreamWriter = System.IO.File.CreateText(tempFile)
    '      Dim fileText As String = GetProjectFileAsString("ScheduleDataset.xsd")
    '      fileText = fileText.Replace("ScheduleDataset", newName) 'Replace name references
    '      sw.Write(fileText)
    '      sw.Close()
    '      Dim item As EnvDTE.ProjectItem = project.ProjectItems.AddFromFileCopy(tempFile)
    '      item.Name = GetUniqueName(project.ProjectItems, newName, "xsd")

    '      'Delete the temp file
    '      System.IO.File.Delete(tempFile)

    '      item.Properties.Item("CustomTool").Value = "MSDataSetGenerator"
    '      If (beforeCount < project.ProjectItems.Count) Then
    '        MsgBox("The dataset generation is complete.", MsgBoxStyle.Information, "Complete")
    '      Else
    '        MsgBox("There was an error in dataset generation!", MsgBoxStyle.Exclamation, "Error")
    '      End If
    '    Else
    '      MsgBox("A single project must be selected.")
    '    End If

    '  Catch ex As Exception
    '    SetErr(ex)
    '  End Try

    'End Sub

    'Private Function GetUniqueName(ByVal projectItems As EnvDTE.ProjectItems, ByVal baseName As String, ByVal extName As String) As String

    '  Try
    '    Dim found As Boolean = True
    '    Dim newName As String = ""
    '    Dim ii As Integer = 0
    '    While found

    '      found = False
    '      If ii = 0 Then
    '        newName = baseName & "." & extName
    '      Else
    '        newName = baseName & ii.ToString & "." & extName
    '      End If
    '      For Each item As EnvDTE.ProjectItem In projectItems
    '        If String.Compare(item.Name, newName, True) = 0 Then
    '          ii += 1
    '          found = True
    '          Exit For
    '        End If
    '      Next

    '    End While
    '    Return newName
    '  Catch ex As Exception
    '    SetErr(ex)
    '  End Try

    'End Function

#End Region

#Region "Initialize"

    Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
      MyBase.Initialize(component)
      SiteSchedule = CType(component, Gravitybox.Controls.Schedule)
    End Sub

#End Region

  End Class

End Namespace
