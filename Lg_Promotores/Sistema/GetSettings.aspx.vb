Imports System.Xml

Partial Class Sistema_GetSettings
    Inherits XMWebPage




    'Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Dim c As IDictionary = SettingsExpression.SettingsCollection()
    '    Dim it As SettingsExpression.SettingsCollectionItem
    '    Dim doc As New XmlDocument()
    '    Dim root As XmlElement = doc.CreateNode(XmlNodeType.Element, "", "settings", "")
    '    doc.AppendChild(root)
    '    For Each key As String In c.Keys()
    '        it = c.Item(key)
    '        Dim vKey() As String = Split(key, "|")
    '        Dim el As XmlElement = GetElement(vKey(0), doc, root)
    '        Dim at As XmlAttribute = doc.CreateAttribute(vKey(1))
    '        at.Value = it.Value
    '        el.Attributes.SetNamedItem(at)
    '        Response.Write(IIf(it.isDefault, "#", "") & key & " = " & it.Value)
    '    Next
    '    Response.Write(doc.OuterXml)
    'End Sub

    'Protected Function GetElement(ByVal vPath As String, ByVal doc As XmlDocument, ByVal root As XmlElement) As XmlElement
    '    Dim vArr() As String = Split(vPath, ".")
    '    Dim current As XmlElement = root
    '    For i As Integer = 0 To UBound(vArr)

    '    Next

    'End Function


End Class
