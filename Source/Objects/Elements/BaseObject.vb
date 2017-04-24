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

Namespace Gravitybox.Objects

	Public Delegate Sub StandardDelegate(ByVal sender As Object, ByVal e As System.EventArgs)

	Public MustInherit Class BaseObject
		Implements IXMLable
		Implements System.ICloneable
		Implements IComparable

#Region "Interface"

		Public MustOverride Function ToXML() As String Implements Gravitybox.Objects.IXMLable.ToXML
		Friend MustOverride Function FromXML(ByVal xml As String, ByVal shallow As Boolean, ByVal cancelEvents As Boolean) As Boolean
		Public MustOverride Function FromXML(ByVal xml As String) As Boolean Implements Gravitybox.Objects.IXMLable.FromXML
		Public MustOverride Function SaveXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.SaveXML
		Public MustOverride Function LoadXML(ByVal fileName As String) As Boolean Implements Gravitybox.Objects.IXMLable.LoadXML
    Friend MustOverride Function CloneMe() As Object

#End Region

#Region "Class Header"

    Protected m_Key As String = ""
    Protected m_Text As String = ""
    Private m_PropertyItemCollection As New PropertyItemCollection
    Private m_BaseCollection As BaseObjectCollection

		Public Event Reload As ReloadDelegate
		Public Event Refresh As AfterAddDelegate
		Public Event TextChanged As StandardDelegate

#End Region

#Region "Constructor"

    Friend Sub New(ByVal key As String, ByVal text As String)
      If key = "" Then key = Guid.NewGuid().ToString()
      m_Key = key
      m_Text = text
      AddHandler m_PropertyItemCollection.Refresh, AddressOf OnRefreshPropertyItemCollection
    End Sub

#End Region

#Region "Property Implementations"

    ''' <summary>
    ''' The unique identifier for this object.
    ''' </summary>
    <Browsable(False), _
    Description("The unique identifier for this object."), _
    Gravitybox.Design.Attributes.Persistable("", True, True)> _
    Public Property Key() As String
      Get
        Return m_Key
      End Get
      Set(ByVal value As String)
        'If no change then skip out
        If (value = Me.Key) Then Return
        If value.Trim = "" Then
          value = Guid.NewGuid.ToString
        End If

        'Check for uniqueness
        If Not (Me.BaseCollection Is Nothing) Then
          For Each bo As BaseObject In Me.BaseCollection
            If bo.Key = value Then
              Throw New Exception("The specified key is not unique!")
            End If
          Next
        End If

        m_Key = value

      End Set
    End Property

    ''' <summary>
    ''' Determines the name of this object as well as the text used for its display.
    ''' </summary>
    <Browsable(True), _
    Gravitybox.Design.Attributes.Persistable("text"), _
    Category("Data"), _
    DefaultValue(""), _
    Description("Determines the name of this object as well as the text used for its display.")> _
    Public Property Text() As String
      Get
        Return m_Text
      End Get
      Set(ByVal Value As String)
        If m_Text <> Value Then
          m_Text = Value
          OnTextChanged(Me, New System.EventArgs)
          OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
        End If
      End Set
    End Property

		<Browsable(False)> _
		Public ReadOnly Property PropertyItemCollection() As PropertyItemCollection
			Get
				Return m_PropertyItemCollection
			End Get
    End Property

    <Browsable(False)> _
    Friend Property BaseCollection() As BaseObjectCollection
      Get
        Return m_BaseCollection
      End Get
      Set(ByVal value As BaseObjectCollection)
        m_BaseCollection = value
      End Set
    End Property

#End Region

#Region "Internal Set Methods"

		Friend Sub SetKey(ByVal value As String)
      m_Key = value
    End Sub

		Friend Sub SetText(ByVal value As String)
			m_Text = value
		End Sub

#End Region

#Region "ToString"

		Public Overrides Function ToString() As String

			Try
				Return Me.Text
			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
      Return Nothing

		End Function

#End Region

#Region "On... Event Methods"

		Protected Friend Sub OnReload(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent Reload(sender, e)
		End Sub

		Protected Friend Sub OnRefresh(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			RaiseEvent Refresh(sender, e)
		End Sub

		Protected Friend Sub OnTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
			RaiseEvent TextChanged(sender, e)
		End Sub

#End Region

#Region "OnRefreshPropertyItemCollection"

		Private Sub OnRefreshPropertyItemCollection(ByVal sender As Object, ByVal e As Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs)
			OnRefresh(Me, New Gravitybox.Objects.EventArgs.AfterBaseObjectEventArgs(Me))
		End Sub

#End Region

#Region "Clone"

    Public Function Clone() As Object Implements System.ICloneable.Clone
      Try
        Return CType(Me.CloneMe(), Gravitybox.Objects.BaseObject)
      Catch ex As Exception
        Call ErrorModule.SetErr(ex)
      End Try
      Return Nothing
    End Function

#End Region

#Region "ICompare"

		Friend Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
			Try
				If (obj Is Nothing) Then Return -1
				Dim o1Index As String = Me.Text
				Dim o2Index As String = CType(obj, Gravitybox.Objects.BaseObject).Text
				If o1Index = o2Index Then
					Return 0
				ElseIf o1Index < o2Index Then
					Return -1
				Else
					Return 1
				End If

			Catch ex As Exception
				Call ErrorModule.SetErr(ex)
			End Try
		End Function

#End Region

	End Class

End Namespace