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

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace Gravitybox.Controls

  <ToolboxItem(False)> _
  Friend Class MultiLineListBox
    Inherits System.Windows.Forms.ListBox

#Region "Class Header"

    Private TextList As New Hashtable

#End Region

#Region "Constructor"

    Friend Sub New()
      Me.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
      Me.ScrollAlwaysVisible = True
      tbox.Hide()
      tbox.mllb = Me
      Me.Controls.Add(tbox)
    End Sub

#End Region

#Region "Events"

    Friend Event BeforeDrawText(ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs)
    Protected Sub OnBeforeDrawText(ByVal e As Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs)
      RaiseEvent BeforeDrawText(e)
    End Sub

    Protected Overrides Sub OnMeasureItem(ByVal e As MeasureItemEventArgs)

      If Not (Site Is Nothing) Then Return

      Dim eventParam As Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs
      eventParam = New Gravitybox.Objects.EventArgs.BeforeAppointmentTextEventArgs(CType(Me.Items(e.Index), Gravitybox.Objects.Appointment))
      Me.OnBeforeDrawText(eventParam)

      If TextList.Contains(e.Index) Then
        TextList(e.Index) = eventParam.Text
      Else
        TextList.Add(e.Index, eventParam.Text)
      End If

      If (e.Index > -1) Then
        Dim sf As SizeF = e.Graphics.MeasureString(eventParam.Text, Me.Font, Me.Width)
        'If (e.Index = 0) Then
        'sf = e.Graphics.MeasureString("W", Me.Font, Me.Width)
        'End If
        e.ItemHeight = CType(sf.Height, Integer)
        e.ItemWidth = Width
      End If

    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)

      If Not (Site Is Nothing) Then Return

      If (e.Index > -1) Then
        Dim text As String = CType(TextList(e.Index), String)
        'If ((e.State <> DrawItemState.None) AndAlso (DrawItemState.Focus <> DrawItemState.None)) Then
        If ((e.State And DrawItemState.Selected) = DrawItemState.Selected) Then
          e.Graphics.FillRectangle(New SolidBrush(SystemColors.Highlight), e.Bounds)
          e.Graphics.DrawString(text, Me.Font, New SolidBrush(SystemColors.HighlightText), New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
        Else
          e.Graphics.FillRectangle(New SolidBrush(SystemColors.Window), e.Bounds)
          e.Graphics.DrawString(text, Me.Font, New SolidBrush(SystemColors.WindowText), New RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))
          e.Graphics.DrawRectangle(New Pen(SystemColors.Highlight), e.Bounds)
        End If
      End If

    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)

      'Dim index As Integer = IndexFromPoint(e.X, e.Y)
      'If (index <> ListBox.NoMatches AndAlso index <> 65535) Then
      '	If (e.Button = MouseButtons.Right) Then
      '		Dim s As String = Me.Items(index).ToString()
      '		Dim rect As Rectangle = GetItemRectangle(index)

      '		tbox.Location = New Point(rect.X, rect.Y)
      '		tbox.Size = New Size(rect.Width, rect.Height)
      '		tbox.Text = s
      '		tbox.index = index
      '		tbox.SelectAll()
      '		tbox.Show()
      '		tbox.Focus()
      '	End If
      'End If

      MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
      If (e.KeyData = Keys.F2) Then
        Dim index As Integer = Me.SelectedIndex
        If (index = ListBox.NoMatches OrElse index = 65535) Then
          If (Me.Items.Count > 0) Then
            index = 0
          End If
        End If

        If (index <> ListBox.NoMatches AndAlso index <> 65535) Then
          Dim s As String = Me.Items(index).ToString()
          Dim rect As Rectangle = Me.GetItemRectangle(index)

          tbox.Location = New Point(rect.X, rect.Y)
          tbox.Size = New Size(rect.Width, rect.Height)
          tbox.Text = s
          tbox.index = index
          tbox.SelectAll()
          tbox.Show()
          tbox.Focus()
        End If
      End If
      MyBase.OnKeyDown(e)
    End Sub

    Protected Overrides Sub RefreshItem(ByVal index As Integer)

    End Sub

    Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)

    End Sub

#End Region

    Private tbox As NTextBox = New NTextBox

    <ToolboxItem(False)> _
    Friend Class NTextBox
      Inherits TextBox

#Region "Class Header"

      Friend mllb As MultiLineListBox
      Friend index As Integer = -1
      Private errshown As Boolean = False
      Private brementer As Boolean = False

#End Region

#Region "Constructor"

      Friend Sub New()
        Multiline = True
        ScrollBars = Windows.Forms.ScrollBars.Vertical
      End Sub

#End Region

#Region "Events"

      Protected Overrides Sub OnKeyUp(ByVal e As KeyEventArgs)
        If (brementer) Then
          Text = ""
          brementer = False
        End If
        MyBase.OnKeyUp(e)
      End Sub

      Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)

        MyBase.OnKeyPress(e)

        If (e.KeyChar = Convert.ToChar(13)) Then
          If (Text.Trim() = "") Then
            errshown = True
            brementer = True
            MessageBox.Show("Cannot enter NULL string as item!", "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Else
            errshown = False
            mllb.Items(index) = Me.Text
            Hide()
          End If

        End If

        If (e.KeyChar = Convert.ToChar(27)) Then
          Text = mllb.Items(index).ToString()
          Hide()
          mllb.SelectedIndex = index
        End If

      End Sub

      Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)

        If (Text.Trim() = "") Then
          If (Not errshown) Then
            MessageBox.Show("Cannot enter NULL string as item!", "Fatal error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
          End If
          errshown = False
        Else
          errshown = False
          mllb.Items(index) = Me.Text
          Hide()
        End If
        MyBase.OnLostFocus(e)

      End Sub

#End Region

    End Class

  End Class

End Namespace
