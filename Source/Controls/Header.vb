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
Imports Gravitybox.Objects

Namespace Gravitybox.Controls

  ''' <summary>
  ''' This is a header control for nice looking form or control headers
  ''' </summary>
  <ToolboxItem(True), _
  ToolboxBitmap(GetType(Gravitybox.Controls.Header)), _
  Browsable(True), _
  DesignTimeVisible(True)> _
  Public Class Header
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
      MyBase.New()

      Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      Call Header()

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      Me.HasDisposed = True
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      '
      'Header
      '
      Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "Header"
      Me.Size = New System.Drawing.Size(288, 80)

    End Sub

#End Region

#Region "Class Members"

    ''' <summary>
    ''' This enumeration is used to determine border style.
    ''' </summary>
    Public Enum BorderStyleConstants As Integer
      None = 0
      FixedSingle = 1
    End Enum

    ''' <summary>
    ''' This enumeration is used to determine icon position on the control.
    ''' </summary>
    Public Enum IconAlignmentConstants As Integer
      Left = 0
      Right = 1
    End Enum

    'Internal Constants
    Private Const TextMargin As Integer = 2
    Private Const IconBuffer As Integer = 2
    Private Const BorderSize As Integer = 1

    'Property Defaults
    Private ReadOnly m_def_IconAlignment As IconAlignmentConstants = IconAlignmentConstants.Right

    'Property Variables
    Private m_Icon As Icon
    Private m_IconAlignment As IconAlignmentConstants = m_def_IconAlignment
    Private m_Text As String = ""
    Private m_Appearance As New Gravitybox.Objects.Appearance

    'Internal Objects
    Private HasDisposed As Boolean = False

#End Region

#Region "Initialize"

    Private Sub Header()
      Me.Appearance.BackColor = SystemColors.AppWorkspace
      Me.Appearance.ForeColor = SystemColors.ActiveCaptionText
      Me.Appearance.BorderColor = SystemColors.WindowFrame
      m_IconAlignment = m_def_IconAlignment

      m_Appearance.BackColor = SystemColors.AppWorkspace
      m_Appearance.ForeColor = SystemColors.ActiveCaptionText

      'Setup the font
      Try
        Me.Appearance.FontSize = 18
        Dim fontStyle As New FontStyle
        fontStyle = fontStyle.Bold
        Me.Font = New Font("Arial", Me.Appearance.FontSize, fontStyle)
      Catch
        'Do Nothing
      End Try

    End Sub

#End Region

#Region "Events"

    Friend Overridable Sub OnRefresh()
      Try
        Me.Refresh()
      Catch ex As Exceptions.GravityboxException
        ErrorModule.SetErr(ex)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
    End Sub

    Private Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      Try
        OnRefresh()
      Catch ex As Exceptions.GravityboxException
        ErrorModule.SetErr(ex)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
    End Sub

    Protected Overridable Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
        OnRefresh()
      Catch ex As Exceptions.GravityboxException
        ErrorModule.SetErr(ex)
      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' This object determines the appearance of the header.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    Description("This object determines the appearance of the header.")> _
    Public Property Appearance() As Gravitybox.Objects.Appearance
      Get
        Return m_Appearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        'This object can never be null
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
        m_Appearance = Value
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh
        OnRefresh()
      End Set
    End Property

    ''' <summary>
    ''' Determines the backcolor.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "AppWorkspace"), _
    Description("Determines the backcolor.")> _
    Public Overrides Property BackColor() As System.Drawing.Color
      Get
        Return Me.Appearance.BackColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        MyBase.BackColor = Value
        Me.Appearance.BackColor = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the text color.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "White"), _
    Description("Determines the text color.")> _
    Public Overrides Property ForeColor() As System.Drawing.Color
      Get
        Return Me.Appearance.ForeColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        MyBase.ForeColor = Value
        Me.Appearance.ForeColor = Value
      End Set
    End Property

    ''' <summary>
    ''' Determines the icon to display on the control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Icon), Nothing), _
    Description("Determines the icon to display on the control.")> _
    Public Property Icon() As Icon
      Get
        Return m_Icon
      End Get
      Set(ByVal Value As Icon)
        m_Icon = Value
        Call Refresh()
      End Set
    End Property

    ''' <summary>
    ''' Determines where on the control the icon is drawn.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(IconAlignmentConstants), "Right"), _
    Description("Determines where on the control the icon is drawn.")> _
    Public Property IconAlignment() As IconAlignmentConstants
      Get
        Return m_IconAlignment
      End Get
      Set(ByVal Value As IconAlignmentConstants)
        m_IconAlignment = Value
        Call Refresh()
      End Set
    End Property

    ''' <summary>
    ''' Determines the text to display on the control.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("Determines the text to display on the control.")> _
    Public Shadows Property Text() As String
      Get
        Return m_Text
      End Get
      Set(ByVal Value As String)
        m_Text = Value
        Call Refresh()
      End Set
    End Property

#End Region

#Region "Refresh"

    ''' <summary>
    ''' Redraws the control.
    ''' </summary>
    Public Overrides Sub Refresh()

      If Me.HasDisposed Then Return

      Try
        'Setup the colors
        Dim g As Graphics = Me.CreateGraphics
        Dim textLeft As Integer = 0
        Dim currentBorder As Integer = 0

        Dim bodyRectangle As New Rectangle(0, 0, Me.Size.Width, Me.Size.Height)
        Dim fillBrush As Brush = CreateBrush(Me.Appearance, bodyRectangle)

        '**************************************************
        'Fill Backcolor
        g.FillRectangle(fillBrush, bodyRectangle)
        fillBrush.Dispose()

        '**************************************************
        'Draw icon if necessary
        If Not (Me.Icon Is Nothing) Then

          Dim iconRect As Rectangle

          'Left/Right align? Calculate rectangle
          If Me.IconAlignment = IconAlignmentConstants.Left Then
            textLeft = currentBorder + IconBuffer + Me.Icon.Width + TextMargin
            iconRect = New Rectangle(IconBuffer + currentBorder, IconBuffer + currentBorder, Me.Icon.Width, Me.Icon.Height)
          ElseIf Me.IconAlignment = IconAlignmentConstants.Right Then
            textLeft = currentBorder + TextMargin
            iconRect = New Rectangle(Me.Width - IconBuffer - currentBorder - Me.Icon.Width, IconBuffer + currentBorder, Me.Icon.Width, Me.Icon.Height)
          End If

          'Draw the icon
          Call g.DrawIconUnstretched(Me.Icon, iconRect)

        Else
          textLeft = currentBorder + TextMargin

        End If

        '**************************************************
        'Draw the text (if exists)
        Dim drawText As String = Me.Text.Trim
        If drawText <> "" Then
          Dim rectF As RectangleF = New RectangleF(textLeft, TextMargin + currentBorder, Me.Width - textLeft, Me.Height - TextMargin - currentBorder)

          'Setup the font
          Dim stringFormat As New StringFormat
          Dim textPen As Pen = CreateTextPen(Me.Appearance)

          Dim theFontStyle As System.Drawing.FontStyle
          If Me.Appearance.FontBold Then theFontStyle = theFontStyle Or FontStyle.Bold
          If Me.Appearance.FontItalics Then theFontStyle = theFontStyle Or FontStyle.Italic
          If Me.Appearance.FontStrikeout Then theFontStyle = theFontStyle Or FontStyle.Strikeout
          If Me.Appearance.FontUnderline Then theFontStyle = theFontStyle Or FontStyle.Underline

          Dim apptFont As New Font(Me.Font.FontFamily, Me.Appearance.FontSize, theFontStyle, Me.Appearance.FontUnit)
          stringFormat.FormatFlags = Me.Appearance.StringFormatFlags
          stringFormat.Alignment = Me.Appearance.Alignment
          stringFormat.LineAlignment = Me.Appearance.TextVAlign
          stringFormat.Trimming = Me.Appearance.TextTrimming

          Call g.DrawString(drawText, apptFont, textPen.Brush, rectF, stringFormat)
          textPen.Dispose()

        End If

        '**************************************************
        'Draw border if necessary
        Dim borderPen As Pen = CreateBorderPen(Me.Appearance)
        Call g.DrawRectangle(borderPen, 0, 0, Me.Size.Width - BorderSize, Me.Size.Height - BorderSize)
        borderPen.Dispose()

        'Dispose of used objects
        Call g.Dispose()

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

#Region "Control Events"

    Private Sub Header_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

      Try
        Call Refresh()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Private Sub Header_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

      Try
        Call Refresh()
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

#End Region

  End Class

End Namespace