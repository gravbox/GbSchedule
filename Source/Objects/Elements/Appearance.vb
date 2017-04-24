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
Imports System.Windows.Forms.Design
Imports System.Drawing.Design
Imports Gravitybox.Objects.EventArgs

Namespace Gravitybox.Objects

#Region "Enums"

  Public Enum GradientStyleConstants
    None = 0
    Vertical = 1
    Horizontal = 2
    BackwardDiagonal = 3
    ForwardDiagonal = 4
  End Enum

#End Region

	<Serializable(), _
	DefaultEvent("Refresh"), _
	DefaultProperty("Text"), _
	DesignerSerializer(GetType(Gravitybox.Design.Serializers.AppearanceSerializer), GetType(CodeDomSerializer)), _
	TypeConverter(GetType(Gravitybox.Design.Converters.AppearanceConverter))> _
	Public Class Appearance
		Inherits BaseObject

#Region "Class Members"

		Friend Const MyXMLNodeName As String = "appearance"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

		Private Const m_def_FontBold As Boolean = False
		Private Const m_def_FontUnderline As Boolean = False
		Private Const m_def_FontItalics As Boolean = False
		Private Const m_def_FontStrikeout As Boolean = False

		'Private Member Variables
		Private m_BackColor As Color = Color.White
		Private m_BackColor2 As Color = Color.Wheat
		Private m_ForeColor As Color = Color.Black
		Private m_FontBold As Boolean = m_def_FontBold
		Private m_FontUnderline As Boolean = m_def_FontUnderline
		Private m_FontItalics As Boolean = m_def_FontItalics
		Private m_FontStrikeout As Boolean = m_def_FontStrikeout
		Private m_FontSize As Single = 10
		Private m_FontUnit As System.Drawing.GraphicsUnit = GraphicsUnit.Point
		Private m_StringFormatFlags As System.Drawing.StringFormatFlags = StringFormatFlags.FitBlackBox
		Private m_Alignment As StringAlignment = StringAlignment.Near
		Private m_BorderColor As Color = Color.Black
		Private m_BackGradientStyle As GradientStyleConstants = GradientStyleConstants.None
		Private m_TextTrimming As System.Drawing.StringTrimming = StringTrimming.None
		Private m_TextVAlign As StringAlignment = StringAlignment.Near
		Private m_BorderWidth As Integer = 1
		Private m_NoFill As Boolean = False
		Private m_HatchStyle As Drawing2D.HatchStyle = Drawing2D.HatchStyle.Min
		Private m_HatchColor As System.Drawing.Color = Color.LightGray

#End Region

#Region "Constructor"

		Public Sub New()
			MyBase.New("", "")
		End Sub

		Public Sub New(ByVal key As String)
			MyBase.New(key, "")
		End Sub

		Public Sub New(ByVal key As String, ByVal text As String)
			MyBase.New(key, text)
			Me.Text = text
		End Sub

#End Region

#Region "Clone"

		Friend Overrides Function CloneMe() As Object
			Try
				Dim element As New Gravitybox.Objects.Appearance
				element.FromXML(Me.ToXML)
				element.SetKey(Guid.NewGuid.ToString)
				Return element
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

    End Function

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the color of the background of the object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "White"), _
    Description("Determines the color of the background of the object.")> _
    Public Property BackColor() As Color
      Get
        Return m_BackColor
      End Get
      Set(ByVal Value As Color)
        If Not m_BackColor.Equals(Value) Then
          m_BackColor = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the color to which the background fades if using a gradient.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "Wheat"), _
    Description("Determines the color to which the background fades if using a gradient.")> _
    Public Property BackColor2() As Color
      Get
        Return m_BackColor2
      End Get
      Set(ByVal Value As Color)
        If Not m_BackColor2.Equals(Value) Then
          m_BackColor2 = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the color of the displayed text of the object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "Black"), _
    Description("Determines the color of the displayed text of the object.")> _
    Public Property ForeColor() As Color
      Get
        Return m_ForeColor
      End Get
      Set(ByVal Value As Color)
        If Not m_ForeColor.Equals(Value) Then
          m_ForeColor = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the color of the border drawn around this appointment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Color), "Black"), _
    Description("Determines the color of the border drawn around this appointment.")> _
    Public Property BorderColor() As Color
      Get
        Return m_BorderColor
      End Get
      Set(ByVal Value As Color)
        If Not m_BorderColor.Equals(Value) Then
          m_BorderColor = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the type of gradient to apply to the background.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(GradientStyleConstants), "None"), _
    Description("Determines the type of gradient to apply to the background.")> _
    Public Property BackGradientStyle() As GradientStyleConstants
      Get
        Return m_BackGradientStyle
      End Get
      Set(ByVal Value As GradientStyleConstants)
        If m_BackGradientStyle <> Value Then
          m_BackGradientStyle = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines how text is trimmed when the needed space is not available to display it in its entirety.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(StringTrimming), "None"), _
    Description("Determines how text is trimmed when the needed space is not available to display it in its entirety.")> _
    Public Property TextTrimming() As System.Drawing.StringTrimming
      Get
        Return m_TextTrimming
      End Get
      Set(ByVal Value As System.Drawing.StringTrimming)
        If m_TextTrimming <> Value Then
          m_TextTrimming = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the text vertical alignment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(StringAlignment), "Near"), _
    Description("Determines the text vertical alignment.")> _
    Public Property TextVAlign() As StringAlignment
      Get
        Return m_TextVAlign
      End Get
      Set(ByVal Value As StringAlignment)
        If m_TextVAlign <> Value Then
          m_TextVAlign = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the size in pixels of the border line.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(1), _
    Description("Determines the size in pixels of the border line.")> _
    Public Property BorderWidth() As Integer
      Get
        Return m_BorderWidth
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0 'Error Check
        If m_BorderWidth <> Value Then
          m_BorderWidth = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the background is drawn.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(1), _
    Description("Determines if the background is drawn.")> _
    Public Property NoFill() As Boolean
      Get
        Return m_NoFill
      End Get
      Set(ByVal Value As Boolean)
        If m_NoFill <> Value Then
          m_NoFill = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the font used is bold.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_FontBold), _
    Description("Determines if the font used is bold.")> _
    Public Property FontBold() As Boolean
      Get
        Return m_FontBold
      End Get
      Set(ByVal Value As Boolean)
        If m_FontBold <> Value Then
          m_FontBold = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the font used is underlined.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_FontUnderline), _
    Description("Determines if the font used is underlined.")> _
    Public Property FontUnderline() As Boolean
      Get
        Return m_FontUnderline
      End Get
      Set(ByVal Value As Boolean)
        If m_FontUnderline <> Value Then
          m_FontUnderline = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the font used is italics.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_FontItalics), _
    Description("Determines if the font used is italics.")> _
    Public Property FontItalics() As Boolean
      Get
        Return m_FontItalics
      End Get
      Set(ByVal Value As Boolean)
        If m_FontItalics <> Value Then
          m_FontItalics = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the font used is strikeout.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_FontStrikeout), _
    Description("Determines if the font used is strikeout.")> _
    Public Property FontStrikeout() As Boolean
      Get
        Return m_FontStrikeout
      End Get
      Set(ByVal Value As Boolean)
        If m_FontStrikeout <> Value Then
          m_FontStrikeout = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the size of the font.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(10.0), _
    Description("Determines if the size of the font.")> _
    Public Property FontSize() As Single
      Get
        Return m_FontSize
      End Get
      Set(ByVal Value As Single)
        If m_FontSize <> Value Then
          m_FontSize = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property


    ''' <summary>
    ''' Determines if the unit in which the font size is measured.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(GraphicsUnit), "Point"), _
    Description("Determines if the unit in which the font size is measured.")> _
    Public Property FontUnit() As System.Drawing.GraphicsUnit
      Get
        Return m_FontUnit
      End Get
      Set(ByVal Value As System.Drawing.GraphicsUnit)
        If m_FontUnit <> Value Then
          m_FontUnit = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the text drawing settings.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(StringFormatFlags), "FitBlackBox"), _
    Editor(GetType(Gravitybox.Design.Editors.FlaggedEnumEditor), GetType(UITypeEditor)), _
    TypeConverter(GetType(Gravitybox.Design.Converters.FlagEnumConverter)), _
    Description("Determines the text drawing settings.")> _
    Public Property StringFormatFlags() As StringFormatFlags
      Get
        Return m_StringFormatFlags
      End Get
      Set(ByVal Value As StringFormatFlags)
        If m_StringFormatFlags <> Value Then
          m_StringFormatFlags = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the text alignment.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(System.Drawing.StringAlignment), "Near"), _
    Description("Determines the text alignment.")> _
    Public Property Alignment() As System.Drawing.StringAlignment
      Get
        Return m_Alignment
      End Get
      Set(ByVal Value As System.Drawing.StringAlignment)
        If m_Alignment <> Value Then
          m_Alignment = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the hatch brush to use. Set to 'Min' for no hatch brush.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Drawing2D.HatchStyle), "Min"), _
    Description("Determines the hatch brush to use. Set to 'Min' for no hatch brush.")> _
    Public Property HatchStyle() As Drawing2D.HatchStyle
      Get
        Return m_HatchStyle
      End Get
      Set(ByVal Value As Drawing2D.HatchStyle)
        If m_HatchStyle <> Value Then
          m_HatchStyle = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the hatch brush color.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(System.Drawing.Color), "LightGray"), _
    Description("Determines the hatch brush color.")> _
    Public Property HatchColor() As System.Drawing.Color
      Get
        Return m_HatchColor
      End Get
      Set(ByVal Value As System.Drawing.Color)
        If Not m_HatchColor.Equals(Value) Then
          m_HatchColor = Value
          OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts the object to an XML string.
    ''' </summary>
    Public Overrides Function ToXML() As String
      Return Me.XmlNode.OuterXml
    End Function

    Friend Overloads Overrides Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean
      Return Me.FromXML(xml, False, False)
    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Overloads Overrides Function FromXML(ByVal xml As String) As Boolean

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        If xml = "" Then Return False
        XMLDoc.InnerXml = xml

        'Load all properties
        MyBase.SetKey(GetNodeValue(XMLDoc, startXPath & "key", Me.Key))
        MyBase.SetText(GetNodeValue(XMLDoc, startXPath & "text", Me.Text))
        m_BackColor = ColorTranslator.FromWin32(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "backcolor", ColorTranslator.ToWin32(m_BackColor).ToString)))
        m_BackColor2 = ColorTranslator.FromWin32(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "backcolor2", ColorTranslator.ToWin32(m_BackColor2).ToString)))
        m_ForeColor = ColorTranslator.FromWin32(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "forecolor", ColorTranslator.ToWin32(m_ForeColor).ToString)))
        m_BorderColor = ColorTranslator.FromWin32(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "bordercolor", ColorTranslator.ToWin32(m_BorderColor).ToString)))
        m_FontBold = Boolean.Parse(GetNodeValue(XMLDoc, startXPath & "fontbold", m_FontBold.ToString()))
        m_FontItalics = Boolean.Parse(GetNodeValue(XMLDoc, startXPath & "fontitalics", m_FontItalics.ToString()))
        m_FontUnderline = Boolean.Parse(GetNodeValue(XMLDoc, startXPath & "fontunderline", m_FontUnderline.ToString()))
        m_FontStrikeout = Boolean.Parse(GetNodeValue(XMLDoc, startXPath & "fontstrikeout", m_FontStrikeout.ToString()))
        m_FontSize = Single.Parse(GetNodeValue(XMLDoc, startXPath & "fontsize", m_FontSize.ToString()))
        m_FontUnit = CType([Enum].Parse(GetType(GraphicsUnit), GetNodeValue(XMLDoc, startXPath & "fontunit", m_FontUnit.ToString("d"))), GraphicsUnit)
        m_StringFormatFlags = CType([Enum].Parse(GetType(System.Drawing.StringFormatFlags), GetNodeValue(XMLDoc, startXPath & "stringformatflags", m_StringFormatFlags.ToString("d"))), System.Drawing.StringFormatFlags)
        m_Alignment = CType([Enum].Parse(GetType(System.Drawing.StringAlignment), GetNodeValue(XMLDoc, startXPath & "alignment", m_Alignment.ToString("d"))), System.Drawing.StringAlignment)
        m_BackGradientStyle = CType([Enum].Parse(GetType(GradientStyleConstants), GetNodeValue(XMLDoc, startXPath & "backgradientstyle", m_BackGradientStyle.ToString("d"))), GradientStyleConstants)
        m_TextTrimming = CType([Enum].Parse(GetType(System.Drawing.StringTrimming), GetNodeValue(XMLDoc, startXPath & "texttrimming", m_TextTrimming.ToString("d"))), System.Drawing.StringTrimming)
        m_TextVAlign = CType([Enum].Parse(GetType(System.Drawing.StringAlignment), GetNodeValue(XMLDoc, startXPath & "textvalign", m_TextVAlign.ToString("d"))), System.Drawing.StringAlignment)
        m_BorderWidth = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "borderwidth", m_BorderWidth.ToString("d")))
        m_NoFill = Boolean.Parse(GetNodeValue(XMLDoc, startXPath & "nofill", m_NoFill.ToString()))
        m_HatchColor = ColorTranslator.FromWin32(GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "hatchcolor", ColorTranslator.ToWin32(m_HatchColor).ToString)))
        m_HatchStyle = CType([Enum].Parse(GetType(System.Drawing.Drawing2D.HatchStyle), GetNodeValue(XMLDoc, startXPath & "hatchstyle", m_HatchStyle.ToString("d"))), System.Drawing.Drawing2D.HatchStyle)

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New AfterBaseObjectEventArgs(Me))
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

		Friend Overridable Function XmlNode() As System.Xml.XmlNode

			Dim xmlHelper As New Gravitybox.Objects.XMLHelper
			Dim XMLDoc As New Xml.XmlDocument
			Dim parentNode As Xml.XmlElement

			Try
				'Setup the Node Name
				parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

				'Add the appropriate properties
				Call xmlHelper.addElement(parentNode, "key", Me.Key)
				Call xmlHelper.addElement(parentNode, "type", "0")
				Call xmlHelper.addElement(parentNode, "text", Me.Text)
				Call xmlHelper.addElement(parentNode, "backcolor", ColorTranslator.ToWin32(m_BackColor).ToString)
				Call xmlHelper.addElement(parentNode, "backcolor2", ColorTranslator.ToWin32(m_BackColor2).ToString)
				Call xmlHelper.addElement(parentNode, "forecolor", ColorTranslator.ToWin32(m_ForeColor).ToString)
				Call xmlHelper.addElement(parentNode, "bordercolor", ColorTranslator.ToWin32(m_BorderColor).ToString)
				Call xmlHelper.addElement(parentNode, "fontbold", m_FontBold.ToString())
				Call xmlHelper.addElement(parentNode, "fontitalics", m_FontItalics.ToString())
				Call xmlHelper.addElement(parentNode, "fontunderline", m_FontUnderline.ToString())
				Call xmlHelper.addElement(parentNode, "fontstrikeout", m_FontStrikeout.ToString())
				Call xmlHelper.addElement(parentNode, "fontsize", m_FontSize.ToString())
				Call xmlHelper.addElement(parentNode, "fontunit", m_FontUnit.ToString("d"))
				Call xmlHelper.addElement(parentNode, "stringformatflags", m_StringFormatFlags.ToString("d"))
				Call xmlHelper.addElement(parentNode, "alignment", m_Alignment.ToString("d"))
				Call xmlHelper.addElement(parentNode, "backgradientstyle", m_BackGradientStyle.ToString("d"))
				Call xmlHelper.addElement(parentNode, "texttrimming", m_TextTrimming.ToString("d"))
				Call xmlHelper.addElement(parentNode, "textvalign", m_TextVAlign.ToString("d"))
				Call xmlHelper.addElement(parentNode, "borderwidth", m_BorderWidth.ToString("d"))
				Call xmlHelper.addElement(parentNode, "nofill", m_NoFill.ToString())
				Call xmlHelper.addElement(parentNode, "hatchstyle", m_HatchStyle.ToString("d"))
				Call xmlHelper.addElement(parentNode, "hatchcolor", ColorTranslator.ToWin32(m_HatchColor).ToString)

				'Return the XML string
				Return parentNode

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

    ''' <summary>
    ''' Saves an XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to save.</param>
    Public Overloads Overrides Function SaveXML(ByVal fileName As String) As Boolean
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Loads an XML representation of this object from a file.
    ''' </summary>
    ''' <param name="fileName">The name of the file to load.</param>
    Public Overloads Overrides Function LoadXML(ByVal fileName As String) As Boolean
      Try
        If System.IO.File.Exists(fileName) Then
          Call Me.FromXML(ScheduleGlobals.LoadFile(fileName))
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

#End Region

	End Class

End Namespace