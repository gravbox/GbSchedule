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

Namespace Gravitybox.Objects

  <Serializable(), _
  DesignerSerializer(GetType(Gravitybox.Design.Serializers.AppointmentHeaderSerializer), GetType(CodeDomSerializer)), _
  TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentHeaderConverter))> _
  Public Class AppointmentHeader
    Implements System.Runtime.Serialization.IDeserializationCallback
		Implements IXMLable
		Implements IDisposable

#Region "Class Members"

    Friend Const MyXMLNodeName As String = "appointmentheader"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    Public Enum HeaderTypeConstants
      None = 0
      DateHeader = 1
      TimeHeader = 2
			Text = 3
			UserDrawn = 4
    End Enum

    'Private Member Constants
    <NonSerialized()> Private Const m_def_Text As String = ""
    <NonSerialized()> Private Const m_def_HeaderType As HeaderTypeConstants = HeaderTypeConstants.None

    'Private Member Variables
    Private m_Text As String = m_def_Text
    Private m_HeaderType As HeaderTypeConstants = m_def_HeaderType
    Private m_Icon As Icon = Nothing
    Private m_IconBuffer As Bitmap = Nothing
    <NonSerialized()> Private m_ClientRectangle As Rectangle = New Rectangle(0, 0, 0, 0)
    Private m_Appearance As New Gravitybox.Objects.AppointmentHeaderAppearance

    Public Event Reload As ReloadDelegate
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Constructor"

    Public Sub New()
      Me.HookEvents()
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

#Region "Property Implementations"

    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(""), _
    Description("Determines the text displayed in the parent appointment's header area.")> _
    Public Property Text() As String
      Get
        Return m_Text
      End Get
      Set(ByVal Value As String)
        If m_Text <> Value Then
          m_Text = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(HeaderTypeConstants), "None"), _
    Description("Determines the type of header to be drawn.")> _
    Public Property HeaderType() As HeaderTypeConstants
      Get
        Return m_HeaderType
      End Get
      Set(ByVal Value As HeaderTypeConstants)
        If m_HeaderType <> Value Then
          m_HeaderType = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Icon), Nothing), _
    Description("Determines icon displayed in this header.")> _
    Public Property Icon() As Icon
      Get
        Return m_Icon
      End Get
      Set(ByVal Value As Icon)
        m_Icon = Value
        If (Value Is Nothing) Then
          m_IconBuffer = Nothing
        Else
          m_IconBuffer = Me.Icon.ToBitmap
        End If
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(Gravitybox.Design.Converters.AppointmentHeaderAppearanceConverter)), _
    Description("This object contains all the format information for this object.")> _
    Public Property Appearance() As Gravitybox.Objects.AppointmentHeaderAppearance
      Get
        Return m_Appearance
      End Get
      Set(ByVal Value As Gravitybox.Objects.AppointmentHeaderAppearance)
        'If set to null then create the default object
        If Value Is Nothing Then Value = New Gravitybox.Objects.AppointmentHeaderAppearance
        RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
        m_Appearance = Value
        AddHandler m_Appearance.Refresh, AddressOf OnRefresh
        OnRefresh(Me, New System.EventArgs)
      End Set
    End Property

		Public ReadOnly Property ClientRectangle() As Rectangle
			Get
				Return m_ClientRectangle
			End Get
		End Property

		Protected Friend Sub SetClientRectangle(ByVal Value As Rectangle)
			m_ClientRectangle = Value
		End Sub

#End Region

#Region "XML"

    ''' <summary>
    ''' Converts this object to an XML string.
    ''' </summary>
    Public Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
      Return Me.XmlNode.OuterXml
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
        m_Text = GetNodeValue(XMLDoc, startXPath & "text", m_Text)
        m_HeaderType = CType([Enum].Parse(GetType(HeaderTypeConstants), GetNodeValue(XMLDoc, startXPath & "headertype", m_HeaderType.ToString("d"))), HeaderTypeConstants)

        'Load Icon
        Dim iconString As String = GetNodeValue(XMLDoc, startXPath & "icon", "")
        If (iconString <> "") Then
          Me.Icon = System.Drawing.Icon.FromHandle(CType(XMLToObject(iconString), System.Drawing.Bitmap).GetHicon)
        Else
          Me.Icon = Nothing
        End If

        OnReload(Me, New System.EventArgs)
        OnRefresh(Me, New System.EventArgs)
        Return True

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function XmlNode() As System.Xml.XmlNode

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "text", m_Text)
        Call xmlHelper.addElement(parentNode, "headertype", m_HeaderType.ToString("d"))

        'Save Icon
        If Not (Me.Icon Is Nothing) Then
          Call xmlHelper.addElement(parentNode, "icon", ObjectToXML(Me.Icon.ToBitmap))
        End If

        'Return the XML string
        Return parentNode

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

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

#Region "Hooking"

    Friend Sub HookEvents()
      AddHandler m_Appearance.Refresh, AddressOf OnRefresh
    End Sub

    Friend Sub UnHookEvents()
      RemoveHandler m_Appearance.Refresh, AddressOf OnRefresh
    End Sub

#End Region

#Region "Deserialization"

    Private Sub OnDeserialization(ByVal sender As Object) Implements System.Runtime.Serialization.IDeserializationCallback.OnDeserialization
      Try
        m_ClientRectangle = New Rectangle(0, 0, 0, 0)
        If Not (m_IconBuffer Is Nothing) Then
          m_Icon = System.Drawing.Icon.FromHandle(m_IconBuffer.GetHicon)
        End If
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
    End Sub

#End Region

#Region "Dispose"

		Private Sub Dispose() Implements IDisposable.Dispose
			If Not (Me.Icon Is Nothing) Then
				Win32Support.DestroyIcon(Me.Icon.Handle)
			End If
		End Sub

#End Region

  End Class

End Namespace