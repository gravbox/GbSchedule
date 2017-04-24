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

Namespace Gravitybox.Objects

  Public Class DefaultIcons

#Region "Class Members"

    'Private Objects
    Private MainObject As Gravitybox.Controls.Schedule

#End Region

#Region "Constructor"

    'Constructor
    Friend Sub New(ByVal MainSchedule As Gravitybox.Controls.Schedule)
      MainObject = MainSchedule
    End Sub

#End Region

#Region "Property Implementations"

    <Browsable(False)> _
    Public ReadOnly Property IconFlag() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("flag.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconReminder() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("alarm.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconRecurrence() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("recur.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconRecurrenceBroken() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("recurbroken.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconInfo() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("info.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconPrevious() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("previous.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconNext() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("next.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconQuestion() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("question.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconAttention() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("attention.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconClip() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("clip.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconPrint() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("print.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconSave() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("save.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconDelete() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("delete.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconFile() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("file.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconWarning() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("warning.ico"))
      End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property IconBell() As Icon
      Get
        Return New Icon(GetProjectFileAsStream("alarm.ico"))
      End Get
    End Property

#End Region

  End Class

End Namespace