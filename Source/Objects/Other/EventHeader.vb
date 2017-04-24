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

Imports Gravitybox.Controls.Schedule
Imports System.ComponentModel
Imports System.ComponentModel.Design.Serialization
Imports Gravitybox.Controls
Imports System.Drawing

Namespace Gravitybox.Objects

  <Serializable(), _
  DesignerSerializer(GetType(Gravitybox.Design.Serializers.EventHeaderSerializer), GetType(CodeDomSerializer)), _
  TypeConverterAttribute(GetType(Gravitybox.Design.Converters.EventHeaderConverter))> _
  Public Class EventHeader
    Implements IXMLable

#Region "Class Members"

    'Private Constants
    Friend Const MyXMLNodeName As String = "eventheader"
		Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"
		Friend Const TopBuffer As Integer = 5
		Friend Const BottomBuffer As Integer = 8

    Friend Const EventHeaderBuffer As Integer = 2
		Private Const m_def_AllowHeader As Boolean = True
		Private Const m_def_AllowExpand As Boolean = False
		Private Const m_def_IsExpanded As Boolean = True

    'Property Variables
		Private m_AllowHeader As Boolean
		Private m_AllowExpand As Boolean
		Private m_IsExpanded As Boolean
    Private m_Appearance As New Gravitybox.Objects.Appearance
    Private m_ExpandAppearance As New Gravitybox.Objects.Appearance
    <NonSerialized()> Private m_Rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, 0, 0)
    <NonSerialized()> Private m_ExpanderRectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, 0, 0)

    Public Event Reload As ReloadDelegate
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Constructor"

    Friend Sub New()
      m_Appearance.BackColor = SystemColors.AppWorkspace
      m_ExpandAppearance.BackColor = Color.LightYellow
			m_ExpandAppearance.ForeColor = Color.Black
			m_AllowHeader = m_def_AllowHeader
			m_AllowExpand = m_def_AllowExpand
			m_IsExpanded = m_def_IsExpanded

      AddHandler m_Appearance.Refresh, AddressOf OnRefresh
      AddHandler m_ExpandAppearance.Refresh, AddressOf OnRefresh
    End Sub

#End Region

#Region "On... Event Methods"

    Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Reload(sender, e)
    End Sub

    Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Refresh(sender, e)
    End Sub

    Private Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      OnRefresh(sender, New System.EventArgs)
    End Sub

#End Region

#Region "Methods"

    Friend Sub SetDefaultAppearance()

      Try
        Appearance.FromXML((New Appearance).ToXML)
        Appearance.BackColor = SystemColors.AppWorkspace
        Appearance.BorderColor = SystemColors.ActiveBorder
        Appearance.ForeColor = SystemColors.ControlText

        ExpandAppearance.FromXML((New Appearance).ToXML)
        ExpandAppearance.BackColor = Color.LightYellow
        ExpandAppearance.BorderColor = Color.Black
        ExpandAppearance.ForeColor = Color.Black

      Catch ex As Exception
        ErrorModule.SetErr(ex)
      End Try

    End Sub

    Friend Sub ResetRectangle()
      m_Rectangle = New System.Drawing.Rectangle(0, 0, 0, 0)
      m_ExpanderRectangle = New System.Drawing.Rectangle(0, 0, 0, 0)
    End Sub

    Friend Function HitTest(ByVal pt As Point) As Boolean
      Return Me.Rectangle.Contains(pt) 
    End Function

    Friend Function HitTest(ByVal x As Integer, ByVal y As Integer) As Boolean
      Return HitTest(New Point(x, y))
    End Function

    Friend Function HitTestExpander(ByVal pt As Point) As Boolean
      Return Me.ExpanderRectangle.Contains(pt)
    End Function

    Friend Function HitTestExpander(ByVal x As Integer, ByVal y As Integer) As Boolean
      Return HitTestExpander(New Point(x, y))
    End Function

    ''' <summary>
    ''' Determines if the specified viewmode supports event headers.
    ''' </summary>
    ''' <param name="viewmode">The viewmode to check.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function SupportedViewmode(ByVal viewmode As Gravitybox.Controls.Schedule.ViewModeConstants) As Boolean
      'Event header is only visible in certain viewmodes
			Select Case viewmode
        Case Schedule.ViewModeConstants.DayTopProviderLeft, _
        ViewModeConstants.DayTopRoomLeft, _
        ViewModeConstants.DayTopTimeLeft, _
        ViewModeConstants.DayRoomTopTimeLeft, _
        ViewModeConstants.DayProviderTopTimeLeft, _
        ViewModeConstants.ProviderTopTimeLeft, _
        ViewModeConstants.ResourceTopTimeLeft, _
        ViewModeConstants.RoomTopProviderLeft, _
        ViewModeConstants.RoomTopTimeLeft, _
        ViewModeConstants.RoomLeftProviderTop
          Return True
				Case Else
					Return False
			End Select
			Return False
    End Function

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines if appointments that are marked as events will be displayed on the schedule.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowHeader), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if appointments that are marked as events will be displayed on the schedule.")> _
    Public Property AllowHeader() As Boolean
      Get
        Return m_AllowHeader
      End Get
      Set(ByVal Value As Boolean)
        If m_AllowHeader <> Value Then
          m_AllowHeader = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if an expander is visible next to the event header.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_AllowExpand), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if an expander is visible next to the event header.")> _
    Public Property AllowExpand() As Boolean
      Get
        Return m_AllowExpand
      End Get
      Set(ByVal Value As Boolean)
        If m_AllowExpand <> Value Then
          m_AllowExpand = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the event header displays an expander to allow the user to expand/collapse the header.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_IsExpanded), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if the event header displays an expander to allow the user to expand/collapse the header.")> _
    Public Property IsExpanded() As Boolean
      Get
        Return m_IsExpanded
      End Get
      Set(ByVal Value As Boolean)
        If m_IsExpanded <> Value Then
          m_IsExpanded = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the object.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(Gravitybox.Design.Converters.AppearanceConverter)), _
    Description("Determines the appearance of the object.")> _
    Public Property Appearance() As Gravitybox.Objects.Appearance
      Get
        Return m_Appearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
        m_Appearance = Value
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the expander region. The AllowExpand property must be true to see the expander.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(Gravitybox.Design.Converters.AppearanceConverter)), _
    Description("Determines the appearance of the expander region. The AllowExpand property must be true to see the expander.")> _
    Public Property ExpandAppearance() As Gravitybox.Objects.Appearance
      Get
        Return m_ExpandAppearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.Appearance)
        If Value Is Nothing Then Value = New Gravitybox.Objects.Appearance
        RemoveHandler m_ExpandAppearance.Refresh, AddressOf OnRefresh
        m_ExpandAppearance = Value
        AddHandler m_ExpandAppearance.Refresh, AddressOf OnRefresh
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

		Friend Property Rectangle() As System.Drawing.Rectangle
			Get
				Return m_Rectangle
			End Get
			Set(ByVal Value As System.Drawing.Rectangle)
				m_Rectangle = Value
			End Set
		End Property

		Friend Property ExpanderRectangle() As System.Drawing.Rectangle
			Get
				Return m_ExpanderRectangle
			End Get
			Set(ByVal Value As System.Drawing.Rectangle)
				m_ExpanderRectangle = Value
			End Set
		End Property

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts this object to an XML string.
    ''' </summary>
    Public Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
      Return Me.XmlNode.OuterXml
    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "allowexpand", m_AllowExpand.ToString)
        Call xmlHelper.addElement(parentNode, "allowheader", m_AllowHeader.ToString)
        Call xmlHelper.addElement(parentNode, "isexpanded", m_IsExpanded.ToString)

        'Return the XML string
        Return parentNode

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

    ''' <summary>
    ''' Reconstitute this object from an XML string.
    ''' </summary>
    ''' <param name="xml">The XML string</param>
    ''' <returns>True if this object was successfully loaded</returns>
    Public Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML

      Dim XMLDoc As New Xml.XmlDocument

      Try

        'Setup the Node Name
        If xml = "" Then Return False
        XMLDoc.InnerXml = xml

        'Load all properties
        m_AllowExpand = CBool(GetNodeValue(XMLDoc, startXPath & "allowexpand", m_AllowExpand.ToString))
        m_AllowHeader = CBool(GetNodeValue(XMLDoc, startXPath & "allowheader", m_AllowHeader.ToString))
        m_IsExpanded = CBool(GetNodeValue(XMLDoc, startXPath & "isexpanded", m_IsExpanded.ToString))

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New System.EventArgs)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    ''' <summary>
    ''' Saves the XML representation of this object to a file.
    ''' </summary>
    ''' <param name="fileName">The file name to use when saving.</param>
    Public Function SaveXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.SaveXML
      Try
        Call ScheduleGlobals.SaveFile(fileName, Me.ToXML)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Function

    ''' <summary>
    ''' Load this object from an XML file.
    ''' </summary>
    ''' <param name="fileName">The name of the file from which to load.</param>
    Public Function LoadXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.LoadXML
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