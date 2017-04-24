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
  DesignerSerializer(GetType(Gravitybox.Design.Serializers.ScheduleBarSerializer), GetType(CodeDomSerializer)), _
  TypeConverter(GetType(Gravitybox.Design.Converters.ScheduleBarConverter))> _
  Public Class ScheduleBar

#Region "Class Members"

		Private Const m_def_Size As Integer = 5

		'Property Variables
    Private m_BarType As Schedule.AppointmentBarConstants = Schedule.AppointmentBarConstants.None
    Private m_Size As Integer = m_def_Size

		'Private Variables
		Dim MainObject As Gravitybox.Controls.Schedule

#End Region

#Region "Constructor"

		Friend Sub New(ByVal mainObject As Gravitybox.Controls.Schedule)
			Me.MainObject = mainObject
		End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' Determines the type of bar to display.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(GetType(Schedule.AppointmentBarConstants), "None"), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines the type of bar to display.")> _
    Public Property BarType() As Schedule.AppointmentBarConstants
      Get
        Return m_BarType
      End Get
      Set(ByVal Value As Schedule.AppointmentBarConstants)
        m_BarType = Value
        MainObject.DrawingDirty = True
        MainObject.OnRefresh()
      End Set
    End Property

    ''' <summary>
    ''' Determines the width of the bar.
    ''' </summary>
    <Browsable(True), _
    Category("Appearance"), _
    DefaultValue(m_def_Size), _
    NotifyParentProperty(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Determines the width of the bar.")> _
    Public Property Size() As Integer
      Get
        Return m_Size
      End Get
      Set(ByVal Value As Integer)
        If Value <= 0 Then Value = 1
        m_Size = Value
        MainObject.DrawingDirty = True
        MainObject.OnRefresh()
      End Set
    End Property

#End Region

	End Class

End Namespace