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

Option Explicit On 
Option Strict On

Imports System.ComponentModel
Imports Gravitybox.Controls
Imports Gravitybox.Controls.Schedule
Imports System.ComponentModel.Design.Serialization

Namespace Gravitybox.Objects

  <DefaultProperty("BarType"), _
  TypeConverter(GetType(Gravitybox.Design.Converters.TimeMarkerConverter))> _
  Public Class TimeMarker
		Implements IDisposable

#Region "Class Members"

    Private Const m_def_Visible As Boolean = False

    'Property Variables
    Private m_Visible As Boolean = m_def_Visible
    Private m_Appearance As New Gravitybox.Objects.Appearance

    'Private Variables
    Private MainObject As Gravitybox.Controls.Schedule
    Private Timer1 As Timer

    'Events
    Public Event Refresh As RefreshDelegate

#End Region

#Region "Constructor"

    Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
      Me.MainObject = mainObject
      m_Visible = m_def_Visible
      AddHandler m_Appearance.Refresh, AddressOf OnRefresh
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines if the marker is visible.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(False), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines if the marker is visible.")> _
    Public Property Visible() As Boolean
      Get
        Return m_Visible
      End Get
      Set(ByVal Value As Boolean)
        m_Visible = Value
        If m_Visible AndAlso (Timer1 Is Nothing) Then
          MainObject.RepaintTimeHeader() 'Repaint now
          Timer1 = New Timer
          Timer1.Interval = 2000
          Timer1.Enabled = True
          AddHandler Timer1.Tick, AddressOf Timer1_Tick
        ElseIf (Not m_Visible) AndAlso Not (Timer1 Is Nothing) Then
          RemoveHandler Timer1.Tick, AddressOf Timer1_Tick
          Timer1 = Nothing
          MainObject.RepaintTimeHeader() 'Repaint now
        End If
        MainObject.OnRefresh()
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

#End Region

#Region "On... Event Methods"

    Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As System.EventArgs)
      RaiseEvent Refresh(sender, e)
    End Sub

    Private Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
      OnRefresh(sender, New System.EventArgs)
    End Sub

#End Region

#Region "CallBack Events"

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
      MainObject.RepaintTimeHeader()
    End Sub

#End Region

#Region "Dispose"

		Public Sub Dispose() Implements IDisposable.Dispose
			MainObject = Nothing
		End Sub

#End Region

  End Class

End Namespace