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
  DefaultProperty("Size"), _
  DesignerSerializer(GetType(Gravitybox.Design.Serializers.HeaderSerializer), GetType(CodeDomSerializer)), _
  TypeConverterAttribute(GetType(Gravitybox.Design.Converters.HeaderConverter))> _
  Public Class Header
    Implements IXMLable
		Implements IDisposable

#Region "Class Members"

    'Private Constants
    Friend Const MyXMLNodeName As String = "header"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Property Constants
		<NonSerialized()> Private Const m_def_Size As Integer = 50
    <NonSerialized()> Private Const m_def_AutoFit As Boolean = False
		<NonSerialized()> Private Const m_def_AllowResize As Boolean = True
		<NonSerialized()> Private Const m_def_FrameIncrement As Integer = 0

    'Property Variables
		Private m_Size As Integer = m_def_Size
		Private m_AutoFit As Boolean = m_def_AutoFit
		Private m_AllowResize As Boolean = m_def_AllowResize
		Private m_FrameIncrement As Integer = m_def_FrameIncrement
    Private m_Appearance As New Gravitybox.Objects.Appearance

    <NonSerialized()> Friend FrameIncrementActual As Integer
    <NonSerialized()> Friend PerfectFit As Boolean
    <NonSerialized()> Private MainObject As Gravitybox.Controls.Schedule
    Private IsColumnHeader As Boolean = False

    'Events
    Public Event Reload As ReloadDelegate
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Constructor"

    Friend Sub New(ByVal isColumnHeader As Boolean, ByVal size As Integer, ByVal backColor As Color, _
                  ByVal borderColor As Color, ByVal foreColor As Color, _
                  ByVal autoFit As Boolean, ByVal allowResize As Boolean, _
                  ByVal alignment As StringAlignment)

      Try
        Me.IsColumnHeader = isColumnHeader

        'Needed for design-time persistence
        m_Size = size
        Appearance.BackColor = backColor
        Appearance.BorderColor = borderColor
        Appearance.ForeColor = foreColor
        Appearance.Alignment = alignment
        m_AutoFit = autoFit
        m_AllowResize = allowResize
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Sub

    Friend Sub New(ByVal mainSchedule As Gravitybox.Controls.Schedule, ByVal isColumnHeader As Boolean)

      Try
        Me.IsColumnHeader = isColumnHeader
        MainObject = mainSchedule

        'Defaults
        m_Size = m_def_Size
        m_AutoFit = m_def_AutoFit
        m_AllowResize = m_def_AllowResize
        Call SetDefaultAppearance()
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

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
      Appearance.FromXML((New Appearance).ToXML)
      Appearance.BackColor = SystemColors.Control
      Appearance.BorderColor = SystemColors.ControlDark
      Appearance.ForeColor = SystemColors.ControlText
      Appearance.Alignment = StringAlignment.Center
    End Sub

    Friend Sub SetScheduleObject(ByVal mainSchedule As Gravitybox.Controls.Schedule)
      'When persisting the sdchedule object is NOT sent 
      'to the constructor so this is needed later
      MainObject = mainSchedule
    End Sub

    Friend Sub SetSize(ByVal value As Integer)
      If value < Schedule.MinRowColSize Then
        value = Schedule.MinRowColSize
        PerfectFit = False
      Else
        PerfectFit = True
      End If
      m_Size = value
    End Sub

    Friend Function HitTest(ByVal pt As System.Drawing.Point) As Integer
      Return Me.HitTest(pt.X, pt.Y)
    End Function

    Friend Function HitTest(ByVal x As Integer, ByVal y As Integer) As Integer

      Dim retval As Integer = -1
      If Me.IsColumnHeader Then
        If (0 <= y) AndAlso (y < MainObject.ClientTop - MainObject.EventHeaderHeight) Then
          retval = MainObject.Visibility.FirstVisibleColumn + ((x - MainObject.ClientLeft) \ Me.Size)
          If retval >= MainObject.Visibility.TotalColumnCount Then retval = -1
        End If
      Else
        If (0 <= x) AndAlso (x < MainObject.ClientLeft) Then
          retval = MainObject.Visibility.FirstVisibleRow + ((y - MainObject.ClientTop) \ Me.Size)
          If retval >= MainObject.Visibility.TotalRowCount Then retval = -1
        End If
      End If
      Return retval

    End Function

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the size in pixels of the header defined by this object. This property may the width or height depending on which type of header this object defines.
    ''' </summary>
    ''' <value></value>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_Size), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines the size in pixels of the header defined by this object. This property may the width or height depending on which type of header this object defines.")> _
    Public Property Size() As Integer
      Get
        Return m_Size
      End Get
      Set(ByVal Value As Integer)
        'No resizing then when in auto mode!
        If AutoFit Then
          'Throw New Exceptions.GravityboxException(ErrorStringAutoNoSize)
          Return
        End If
        If Not (MainObject Is Nothing) Then
          If MainObject.IsHeaderFixed Then
            'Throw New Exceptions.GravityboxException(ErrorStringMonthModeNoSize)
            Return
          End If
        End If
        Call SetSize(Value)
        If Not (MainObject Is Nothing) Then
          MainObject.DrawingDirty = True
        End If
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    ''' <summary>
    ''' Determines if this header is automatically resized by the schedule to fit a certain portion of the schedule.
    ''' </summary>
    ''' <value></value>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AutoFit), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if this header is automatically resized by the schedule to fit a certain portion of the schedule.")> _
    Public Property AutoFit() As Boolean
      Get
        Return m_AutoFit
      End Get
      Set(ByVal Value As Boolean)
        If m_AutoFit <> Value Then
          m_AutoFit = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines if the user can resize the header by dragging its margins with the mouse.
    ''' </summary>
    ''' <value></value>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_AllowResize), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if the user can resize the header by dragging its margins with the mouse.")> _
    Public Property AllowResize() As Boolean
      Get
        Return m_AllowResize And Not Me.AutoFit
      End Get
      Set(ByVal Value As Boolean)
        'There is no resizing if we are autofitting
        If m_AllowResize <> Value Then
          m_AllowResize = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the number of columns or rows that are in one viewable pane when AutoFit is set to true.
    ''' </summary>
    ''' <value></value>
    <Browsable(True), _
    Category("Behavior"), _
    DefaultValue(m_def_FrameIncrement), _
    Description("Determines the number of columns or rows that are in one viewable pane when AutoFit is set to true.")> _
    Public Property FrameIncrement() As Integer
      Get
        Return m_FrameIncrement
      End Get
      Set(ByVal Value As Integer)
        If Value < 0 Then Value = 0
        If m_FrameIncrement <> Value Then
          m_FrameIncrement = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    ''' <summary>
    ''' Determines the appearance of the object.
    ''' </summary>
    ''' <value></value>
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

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			MainObject = Nothing
		End Sub

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
        Call xmlHelper.addElement(parentNode, "size", m_Size.ToString)
        Call xmlHelper.addElement(parentNode, "autofit", m_AutoFit.ToString)
        Call xmlHelper.addElement(parentNode, "allowresize", m_AllowResize.ToString)
        Call xmlHelper.addElement(parentNode, "frameincrement", m_FrameIncrement.ToString)

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
        m_Size = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "size", m_Size.ToString))
        m_AutoFit = CBool(GetNodeValue(XMLDoc, startXPath & "autofit", m_AutoFit.ToString))
        m_AllowResize = CBool(GetNodeValue(XMLDoc, startXPath & "allowresize", m_AllowResize.ToString))
        m_FrameIncrement = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "frameincrement", m_FrameIncrement.ToString))

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