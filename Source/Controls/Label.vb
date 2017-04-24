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
Imports System.Runtime.CompilerServices
Imports Gravitybox.Objects
Imports System.ComponentModel.Design.Serialization

Namespace Gravitybox.Controls

	Friend Class Label
		Inherits System.Windows.Forms.Label

#Region "Class Members"

		Private m_Appearance As Appearance = New Gravitybox.Objects.Appearance

#End Region

#Region "Constructor"

		Public Sub New()
			MyBase.New()
			MyBase.BorderStyle = Windows.Forms.BorderStyle.None
		End Sub

#End Region

#Region "Overrides"

		'Paint the canvas
		<MethodImpl(MethodImplOptions.Synchronized)> _
		Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
			'MyBase.OnPaint(e)

			'Fill the background
			Dim fillBrush As Brush = CreateBrush(Me.Appearance, Me.ClientRectangle)
			e.Graphics.FillRectangle(fillBrush, Me.ClientRectangle)

			'Draw the border
			If Me.Appearance.BorderWidth > 0 Then
				Dim borderPen As Pen = New Pen(Me.Appearance.BorderColor, Me.Appearance.BorderWidth)
				e.Graphics.DrawRectangle(borderPen, 0, 0, Me.Width - Me.Appearance.BorderWidth, Me.Height - Me.Appearance.BorderWidth)
			End If

			'Dim size As SizeF = e.Graphics.MeasureString(Me.Text, Me.Font, Me.ClientRectangle.Width)

			'Draw the Text
			Dim textBrush As Brush = New SolidBrush(Me.Appearance.ForeColor)
			Dim format As New StringFormat

			Select Case Me.TextAlign
				Case ContentAlignment.BottomCenter
					format.Alignment = StringAlignment.Center
					format.LineAlignment = StringAlignment.Far
				Case ContentAlignment.BottomLeft
					format.Alignment = StringAlignment.Near
					format.LineAlignment = StringAlignment.Far
				Case ContentAlignment.BottomRight
					format.Alignment = StringAlignment.Far
					format.LineAlignment = StringAlignment.Far
				Case ContentAlignment.MiddleCenter
					format.Alignment = StringAlignment.Center
					format.LineAlignment = StringAlignment.Center
				Case ContentAlignment.MiddleLeft
					format.Alignment = StringAlignment.Near
					format.LineAlignment = StringAlignment.Center
				Case ContentAlignment.MiddleRight
					format.Alignment = StringAlignment.Far
					format.LineAlignment = StringAlignment.Center
				Case ContentAlignment.TopCenter
					format.Alignment = StringAlignment.Center
					format.LineAlignment = StringAlignment.Near
				Case ContentAlignment.TopLeft
					format.Alignment = StringAlignment.Near
					format.LineAlignment = StringAlignment.Near
				Case ContentAlignment.TopRight
					format.Alignment = StringAlignment.Far
					format.LineAlignment = StringAlignment.Near
			End Select

			e.Graphics.DrawString(Me.Text, Me.Font, textBrush, New RectangleF(2, 1, Me.Width - 5, Me.Height - 1), format)

		End Sub

#End Region

#Region "Property Implementations"

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Property Appearance() As Appearance
			Get
				Return m_Appearance
			End Get
			Set(ByVal value As Appearance)
				If value Is Nothing Then
					m_Appearance = New Gravitybox.Objects.Appearance
				Else
					m_Appearance = value
				End If
			End Set
		End Property

		Public Overrides Property BorderStyle() As System.Windows.Forms.BorderStyle
			Get
				Return Windows.Forms.BorderStyle.None
			End Get
			Set(ByVal value As System.Windows.Forms.BorderStyle)
			End Set
		End Property

		Public Overrides Property AutoSize() As Boolean
			Get
				Return False
			End Get
			Set(ByVal value As Boolean)
			End Set
		End Property

		Public Overrides Property BackColor() As System.Drawing.Color
			Get
				Return Me.Appearance.BackColor
			End Get
			Set(ByVal value As System.Drawing.Color)
				Me.Appearance.BackColor = value
			End Set
		End Property

		Public Overrides Property ForeColor() As System.Drawing.Color
			Get
				Return Me.Appearance.ForeColor
			End Get
			Set(ByVal value As System.Drawing.Color)
				Me.Appearance.ForeColor = value
			End Set
		End Property

#End Region

	End Class

End Namespace