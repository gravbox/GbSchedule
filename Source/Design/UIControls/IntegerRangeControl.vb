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

Namespace Gravitybox.Design.UIControls

  Friend Class IntegerRangeControl
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
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents lblValue As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.TrackBar1 = New System.Windows.Forms.TrackBar
      Me.lblValue = New System.Windows.Forms.Label
      CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'TrackBar1
      '
      Me.TrackBar1.Location = New System.Drawing.Point(80, 0)
      Me.TrackBar1.Name = "TrackBar1"
      Me.TrackBar1.Size = New System.Drawing.Size(192, 42)
      Me.TrackBar1.TabIndex = 0
      Me.TrackBar1.TickStyle = System.Windows.Forms.TickStyle.Both
      '
      'lblValue
      '
      Me.lblValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblValue.Location = New System.Drawing.Point(8, 16)
      Me.lblValue.Name = "lblValue"
      Me.lblValue.Size = New System.Drawing.Size(56, 16)
      Me.lblValue.TabIndex = 1
      Me.lblValue.Text = "000000"
      '
      'IntegerRangeControl
      '
      Me.Controls.Add(Me.lblValue)
      Me.Controls.Add(Me.TrackBar1)
      Me.Name = "IntegerRangeControl"
      Me.Size = New System.Drawing.Size(272, 48)
      CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

    Public Property Minimum() As Integer
      Get
        Return TrackBar1.Minimum
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.Minimum = Value
      End Set
    End Property

    Public Property Maximum() As Integer
      Get
        Return TrackBar1.Maximum
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.Maximum = Value
      End Set
    End Property

    Public Property TickFrequency() As Integer
      Get
        Return TrackBar1.TickFrequency
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.TickFrequency = Value
      End Set
    End Property

    Public Property SmallChange() As Integer
      Get
        Return TrackBar1.SmallChange
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.SmallChange = Value
      End Set
    End Property

    Public Property LargeChange() As Integer
      Get
        Return TrackBar1.LargeChange
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.LargeChange = Value
      End Set
    End Property

    Public Property Value() As Integer
      Get
        Return TrackBar1.Value
      End Get
      Set(ByVal Value As Integer)
        TrackBar1.Value = Value
        lblValue.Text = Me.Value.ToString()
      End Set
    End Property

    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
      lblValue.Text = Me.Value.ToString()
    End Sub

    Private Sub IntegerRangeControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.BackColor = SystemColors.Control
      lblValue.BackColor = SystemColors.Control
      TrackBar1.BackColor = SystemColors.Control
    End Sub

  End Class

End Namespace