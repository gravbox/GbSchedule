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
Imports System.ComponentModel
Imports Gravitybox.Objects

Namespace Gravitybox.Design.UIControls

  Friend Class FlaggedEnumControl
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lstItem As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.lstItem = New System.Windows.Forms.CheckedListBox
      Me.SuspendLayout()
      '
      'lstItem
      '
      Me.lstItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstItem.CheckOnClick = True
      Me.lstItem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lstItem.IntegralHeight = False
      Me.lstItem.Location = New System.Drawing.Point(0, 0)
      Me.lstItem.Name = "lstItem"
      Me.lstItem.Size = New System.Drawing.Size(192, 144)
      Me.lstItem.TabIndex = 1
      '
      'FlaggedEnumControl
      '
      Me.Controls.Add(Me.lstItem)
      Me.Name = "FlaggedEnumControl"
      Me.Size = New System.Drawing.Size(192, 144)
      Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_EnumerationObject As [Enum]

    Public Property EnumerationObject() As [Enum]
      Get
        Try
          Dim s As String = ""
          Dim newValue As Integer
          m_EnumerationObject = CType([Enum].Parse(m_EnumerationObject.GetType, "0"), [Enum])
          For Each s In lstItem.CheckedItems
            newValue += GetIntlInteger(CType([Enum].Parse(m_EnumerationObject.GetType, s), [Enum]))
          Next
          m_EnumerationObject = CType([Enum].Parse(m_EnumerationObject.GetType, newValue.ToString), [Enum])
        Catch ex As Exception
          ErrorModule.SetErr(ex)
        End Try
        Return m_EnumerationObject
      End Get
      Set(ByVal Value As [Enum])
        m_EnumerationObject = Value
        Try
          'Load the listbox
          Dim o As Object
          lstItem.Items.Clear()
          For Each o In [Enum].GetValues(m_EnumerationObject.GetType)
            'Add the item to the list
            lstItem.Items.Add(o)
            'If the enum value is selected then check it
            Dim test1 As Integer = GetIntlInteger(CType(o, [Enum]).ToString("d"))
            Dim test2 As Integer = GetIntlInteger(m_EnumerationObject.ToString("d"))
            If (test1 And test2) = test1 Then
              lstItem.SetItemChecked(lstItem.Items.Count - 1, True)
            End If
          Next
        Catch ex As Exception
          ErrorModule.SetErr(ex)
        End Try
        'Set the form caption
        Me.Text = "Choose Values"
      End Set
    End Property
  End Class

End Namespace