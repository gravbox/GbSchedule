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

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

Namespace Gravitybox.Objects

	'<remarks/>
	<System.Diagnostics.DebuggerStepThroughAttribute(), _
	 System.ComponentModel.DesignerCategoryAttribute("code"), _
	 System.Web.Services.WebServiceBindingAttribute(Name:="CustomerServicesSoap", [Namespace]:="http://tempuri.org/CustomerServices/Email")> _
	Friend Class CustomerServices
		Inherits System.Web.Services.Protocols.SoapHttpClientProtocol

		'<remarks/>
		Public Sub New(ByVal url As String)
			MyBase.New()
			Me.Url = url
		End Sub

		'<remarks/>
		<System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CustomerServices/Email/SendEmail", RequestNamespace:="http://tempuri.org/CustomerServices/Email", ResponseNamespace:="http://tempuri.org/CustomerServices/Email", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
		Public Function SendEmail(ByVal from As String, ByVal subject As String, ByVal message As String) As Boolean
			Dim results() As Object = Me.Invoke("SendEmail", New Object() {from, subject, message})
			Return CType(results(0), Boolean)
		End Function

		'<remarks/>
		Public Function BeginSendEmail(ByVal from As String, ByVal subject As String, ByVal message As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
			Return Me.BeginInvoke("SendEmail", New Object() {from, subject, message}, callback, asyncState)
		End Function

		'<remarks/>
		Public Function EndSendEmail(ByVal asyncResult As System.IAsyncResult) As Boolean
			Dim results() As Object = Me.EndInvoke(asyncResult)
			Return CType(results(0), Boolean)
		End Function

		'<remarks/>
		<System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CustomerServices/Email/PostError", RequestNamespace:="http://tempuri.org/CustomerServices/Email", ResponseNamespace:="http://tempuri.org/CustomerServices/Email", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)> _
		Public Function PostError(ByVal from As String, ByVal component As String, ByVal errorMessage As String) As Boolean
			Dim results() As Object = Me.Invoke("PostError", New Object() {from, component, errorMessage})
			Return CType(results(0), Boolean)
		End Function

		'<remarks/>
		Public Function BeginPostError(ByVal from As String, ByVal component As String, ByVal errorMessage As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
			Return Me.BeginInvoke("PostError", New Object() {from, component, errorMessage}, callback, asyncState)
		End Function

		'<remarks/>
		Public Function EndPostError(ByVal asyncResult As System.IAsyncResult) As Boolean
			Dim results() As Object = Me.EndInvoke(asyncResult)
			Return CType(results(0), Boolean)
		End Function
	End Class

End Namespace
