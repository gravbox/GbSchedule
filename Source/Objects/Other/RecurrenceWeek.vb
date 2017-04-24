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

Namespace Gravitybox.Objects

  <Serializable()> _
  Public Class RecurrenceWeek

#Region "Class Members"

		Private Const m_def_WeekInterval As Integer = Recurrence.RecurrenceNumericMinimum
    Private Const m_def_UseSun As Boolean = False
    Private Const m_def_UseMon As Boolean = False
    Private Const m_def_UseTue As Boolean = False
    Private Const m_def_UseWed As Boolean = False
    Private Const m_def_UseThu As Boolean = False
    Private Const m_def_UseFri As Boolean = False
    Private Const m_def_UseSat As Boolean = False

    'Private Constants
    Friend Const MyXMLNodeName As String = "recurrenceweek"
    Private ReadOnly startXPath As String = "//" & MyXMLNodeName & "/"

    'Private Member Variables
    Private m_WeekInterval As Integer
    Private m_UseSun As Boolean
    Private m_UseMon As Boolean
    Private m_UseTue As Boolean
    Private m_UseWed As Boolean
    Private m_UseThu As Boolean
    Private m_UseFri As Boolean
    Private m_UseSat As Boolean
    <NonSerialized()> Private m_Parent As Recurrence

    Public Event Reload As ReloadDelegate
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Methods"

    Friend Function IsValid() As Boolean

      Try
        If Not (UseSun Or UseMon Or UseTue Or UseWed Or UseThu Or UseFri Or UseSat) Then
          Return False
        Else
          Return True
        End If

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

#End Region

#Region "Property Implementations"

    <Description(""), _
    Browsable(True)> _
    Public Property WeekInterval() As Integer
      Get
				If m_WeekInterval < Recurrence.RecurrenceNumericMinimum Then m_WeekInterval = Recurrence.RecurrenceNumericMinimum
				If m_WeekInterval > Recurrence.RecurrenceNumericMaximum Then m_WeekInterval = Recurrence.RecurrenceNumericMaximum
				Return m_WeekInterval
      End Get
      Set(ByVal Value As Integer)
				If Value < Recurrence.RecurrenceNumericMinimum Then Value = Recurrence.RecurrenceNumericMinimum
				If Value > Recurrence.RecurrenceNumericMaximum Then Value = Recurrence.RecurrenceNumericMaximum
				If m_WeekInterval <> Value Then
					m_WeekInterval = Value
					OnRefresh(Me, New System.EventArgs)
				End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseSun() As Boolean
      Get
        Return m_UseSun
      End Get
      Set(ByVal Value As Boolean)
        If m_UseSun <> Value Then
          m_UseSun = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseMon() As Boolean
      Get
        Return m_UseMon
      End Get
      Set(ByVal Value As Boolean)
        If m_UseMon <> Value Then
          m_UseMon = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseTue() As Boolean
      Get
        Return m_UseTue
      End Get
      Set(ByVal Value As Boolean)
        If m_UseTue <> Value Then
          m_UseTue = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseWed() As Boolean
      Get
        Return m_UseWed
      End Get
      Set(ByVal Value As Boolean)
        If m_UseWed <> Value Then
          m_UseWed = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseThu() As Boolean
      Get
        Return m_UseThu
      End Get
      Set(ByVal Value As Boolean)
        If m_UseThu <> Value Then
          m_UseThu = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseFri() As Boolean
      Get
        Return m_UseFri
      End Get
      Set(ByVal Value As Boolean)
        If m_UseFri <> Value Then
          m_UseFri = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Description(""), _
    Browsable(True)> _
    Public Property UseSat() As Boolean
      Get
        Return m_UseSat
      End Get
      Set(ByVal Value As Boolean)
        If m_UseSat <> Value Then
          m_UseSat = Value
          OnRefresh(Me, New System.EventArgs)
        End If
      End Set
    End Property

    <Browsable(False)> _
    Friend Property Parent() As Recurrence
      Get
        Return m_Parent
      End Get
      Set(ByVal Value As Recurrence)
        m_Parent = Value
      End Set
    End Property

#End Region

#Region "Constructor"

    Friend Sub New()
      m_WeekInterval = m_def_WeekInterval
      m_UseSun = m_def_UseSun
      m_UseMon = m_def_UseMon
      m_UseTue = m_def_UseTue
      m_UseWed = m_def_UseWed
      m_UseThu = m_def_UseThu
      m_UseFri = m_def_UseFri
      m_UseSat = m_def_UseSat
    End Sub

#End Region

#Region "On... Event Methods"

    Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Reload(sender, e)
    End Sub

    Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Refresh(sender, e)
    End Sub

#End Region

#Region "XML"

    Friend Function FromXML(ByVal xml As String) As Boolean

      Dim XMLDoc As New xml.XmlDocument

      Try

        'Setup the Node Name
				If xml = "" Then Return False
				XMLDoc.InnerXml = xml

				'Load all properties
				m_WeekInterval = GetIntlInteger(GetNodeValue(XMLDoc, startXPath & "weekinterval", m_WeekInterval.ToString))
				m_UseSun = CType(GetNodeValue(XMLDoc, startXPath & "usesun", m_UseSun.ToString), Boolean)
				m_UseMon = CType(GetNodeValue(XMLDoc, startXPath & "usemon", m_UseMon.ToString), Boolean)
				m_UseTue = CType(GetNodeValue(XMLDoc, startXPath & "usetue", m_UseTue.ToString), Boolean)
				m_UseWed = CType(GetNodeValue(XMLDoc, startXPath & "usewed", m_UseWed.ToString), Boolean)
				m_UseThu = CType(GetNodeValue(XMLDoc, startXPath & "usethu", m_UseThu.ToString), Boolean)
				m_UseFri = CType(GetNodeValue(XMLDoc, startXPath & "usefri", m_UseFri.ToString), Boolean)
				m_UseSat = CType(GetNodeValue(XMLDoc, startXPath & "usesat", m_UseSat.ToString), Boolean)

				OnReload(Me, New System.EventArgs)
				OnRefresh(Me, New System.EventArgs)
				Return True

			Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try

    End Function

    Friend Function ToXML() As String

      Dim xmlHelper As New Gravitybox.Objects.XMLHelper
      Dim XMLDoc As New Xml.XmlDocument
      Dim parentNode As Xml.XmlElement

      Try
        'Setup the Node Name
        parentNode = CType(xmlHelper.addElement(XMLDoc, MyXMLNodeName, ""), Xml.XmlElement)

        'Add the appropriate properties
        Call xmlHelper.addElement(parentNode, "usesun", m_UseSun.ToString)
        Call xmlHelper.addElement(parentNode, "usemon", m_UseMon.ToString)
        Call xmlHelper.addElement(parentNode, "usetue", m_UseTue.ToString)
        Call xmlHelper.addElement(parentNode, "usewed", m_UseWed.ToString)
        Call xmlHelper.addElement(parentNode, "usethu", m_UseThu.ToString)
        Call xmlHelper.addElement(parentNode, "usefri", m_UseFri.ToString)
        Call xmlHelper.addElement(parentNode, "usesat", m_UseSat.ToString)
        Call xmlHelper.addElement(parentNode, "weekinterval", m_WeekInterval.ToString)

        'Return the XML string
        Return parentNode.OuterXml

      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing

    End Function

#End Region

  End Class

End Namespace