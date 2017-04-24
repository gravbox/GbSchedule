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

Imports System.Xml

Namespace Gravitybox.Objects

  Friend Class XMLHelper

#Region "AddElement"

    Public Function addElement(ByRef XmlElement As XmlElement, ByVal Name As String, ByVal value As String) As XmlNode

      Dim docXML As XmlDocument
      Dim elemNew As XmlElement

      docXML = XmlElement.OwnerDocument
      elemNew = docXML.CreateElement(Name)
      If TypeName(value) = "String" Then
        If value <> "" Then
          elemNew.InnerText = value
        End If
      Else
        elemNew.InnerText = value
      End If
      Return XmlElement.AppendChild(elemNew)

    End Function

    Public Function addElement(ByRef XMLDocument As XmlDocument, ByVal Name As String, ByVal value As String) As XmlNode
      Dim docXML As XMLDocument
      Dim elemNew As XmlElement

      docXML = XMLDocument

      elemNew = docXML.CreateElement(Name)
      If TypeName(value) = "String" Then
        If value <> "" Then
          elemNew.InnerText = value
        End If
      Else
        elemNew.Value = value
      End If
      Return XMLDocument.AppendChild(elemNew)
    End Function

    Public Function addElement(ByRef XMLElement As XmlElement, ByVal Name As String) As XmlNode
      Dim docXML As XmlDocument
      Dim elemNew As XMLElement
      docXML = XMLElement.OwnerDocument
      elemNew = docXML.CreateElement(Name)
      Return XMLElement.AppendChild(elemNew)
    End Function

    Public Function addElement(ByRef XMLDocument As XmlDocument, ByVal Name As String) As XmlNode
      Dim elemNew As XmlElement
      elemNew = XMLDocument.CreateElement(Name)
      Return XMLDocument.AppendChild(elemNew)
    End Function

    Public Function addAttribute(ByRef XmlElement As XmlElement, ByVal Name As String, ByVal value As String) As XmlAttribute

      Dim docOwner As XmlDocument
      Dim attrNew As XmlAttribute

      docOwner = XmlElement.OwnerDocument
      attrNew = docOwner.CreateAttribute(Name)
      attrNew.InnerText = value
      XmlElement.Attributes.Append(attrNew)
      'XmlElement.Attributes.SetNamedItem(attrNew)
      Return attrNew

    End Function

#End Region

#Region "RemoveElement"

    Public Sub removeElement(ByRef XMLDoc As XmlDocument, ByVal XPath As String)

      Dim parentNode As XmlNode
      Dim nodes As XmlNodeList
      Dim node As XmlElement

      nodes = XMLDoc.SelectNodes(XPath)
      For Each node In nodes
        parentNode = node.ParentNode
        node.RemoveAll()
        parentNode.RemoveChild(node)
      Next

    End Sub

    Public Sub removeElement(ByRef xmlElement As XmlElement)
      Dim parentNode As XmlNode
      parentNode = xmlElement.ParentNode
      parentNode.RemoveChild(xmlElement)
    End Sub

    Public Sub removeAttribute(ByRef XMLElement As XmlElement, ByVal attributeName As String)
      Dim attrDelete As XmlAttribute
      attrDelete = CType(XMLElement.Attributes.GetNamedItem(attributeName), XmlAttribute)
      XMLElement.Attributes.Remove(attrDelete)
    End Sub

#End Region

#Region "UpdateElement"

    Public Sub updateElement(ByRef XMLElement As XmlElement, ByVal NewValue As String)
      XMLElement.InnerText = NewValue
    End Sub

    Public Sub updateElement(ByRef XMLDocument As XmlDocument, ByVal Xpath As String, ByVal NewValue As String)
      XMLDocument.SelectSingleNode(Xpath).InnerText = NewValue
    End Sub

    Public Sub updateAttribute(ByRef XmlElement As XmlElement, ByVal AtrributeName As String, ByVal newValue As String)
      Dim attrTemp As XmlAttribute
      attrTemp = CType(XmlElement.Attributes.GetNamedItem(AtrributeName), XmlAttribute)
      attrTemp.InnerText = newValue
    End Sub

#End Region

#Region "GetElement"

		Public Function getElement(ByVal parentElement As XmlElement, ByVal tagName As String) As XmlElement
			Dim list As XmlNodeList = parentElement.GetElementsByTagName(tagName)
			If list.Count > 0 Then
				Return CType(list(0), XmlElement)
			Else
				Return Nothing
			End If
		End Function

#End Region

	End Class

End Namespace
