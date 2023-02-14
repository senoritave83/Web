Imports System.Xml

Partial Class Principal
    Inherits System.Web.UI.MasterPage

    Protected permissao As Classes.clsPermissao

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Page.Title = ConfigurationManager.AppSettings("Title")

        If Not Page.ClientScript.IsClientScriptIncludeRegistered("xm_scriptBlock") Then
            Page.ClientScript.RegisterClientScriptInclude(Me.GetType, "xm_scriptBlock", ResolveClientUrl("~/js/functions.js"))
        End If

        permissao = New Classes.clsPermissao
        If Not Page.IsPostBack Then
            If Page.User.Identity.IsAuthenticated Then
                Dim strCurrentNode As String = ""
                mnuSuperior.Items.Clear()
                Dim doc As New XmlDocument()
                doc.Load(Server.MapPath("~") & "\web.sitemap")

                Dim l As New Generic.List(Of MenuItem)
                Dim mi As MenuItem

                For Each nd As XmlNode In doc.DocumentElement.FirstChild
                    mi = New MenuItem()
                    mi.Text = nd.Attributes.GetNamedItem("title").Value
                    mi.NavigateUrl = nd.Attributes.GetNamedItem("url").Value
                    mi.Selected = isSelected(nd)
                    Dim ndSecao As XmlNode = nd.Attributes.GetNamedItem("Secao")
                    Dim strSecao As String = ""
                    If Not ndSecao Is Nothing Then strSecao = ndSecao.Value

                    If mi.Selected Then
                        strCurrentNode = mi.NavigateUrl
                        BindMenuLateral(nd)
                    End If
                    If strSecao <> "" Then
                        If permissao.VerificaPermissao(strSecao, "Visualizar") Then l.Add(mi)
                    Else
                        l.Add(mi)
                    End If


                    'If TypeOf (Me.Page) Is XMWebPage Then
                    '    Dim WebPage As XMWebPage = CType(Me.Page, XMWebPage)
                    '    If WebPage.VerificaPermissao(mi.Text, "Visualizar") Then
                    '        l.Add(mi)
                    '    End If
                    'Else
                    '    l.Add(mi)
                    'End If

                Next
                For i As Integer = 0 To l.Count - 1
                    mnuSuperior.Items.Add(l.Item(i))
                Next

                doc = Nothing

            End If
        End If

    End Sub

    Protected Function isSelected(ByVal nd As XmlNode) As Boolean
        Dim blnReturn As Boolean = False
        Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
        If nd.Attributes.GetNamedItem("url").Value.ToLower() = strCurrentURL Then
            blnReturn = True
        ElseIf nd.HasChildNodes Then
            For Each n As XmlNode In nd.ChildNodes
                blnReturn = isSelected(n)
                If blnReturn = True Then Exit For
            Next
        End If
        Return blnReturn
    End Function


    Protected Sub SiteMapPath1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SiteMapNodeItemEventArgs) Handles SiteMapPath1.ItemDataBound
        If e.Item.SiteMapNode Is Nothing Then
            Exit Sub
        End If
        If e.Item.ItemType = SiteMapNodeItemType.Current Then
            If Not e.Item.SiteMapNode("caption") Is Nothing Then
                lblTitulo.Text = e.Item.SiteMapNode("caption")
            Else
                lblTitulo.Text = e.Item.SiteMapNode.Title
            End If
            If Not e.Item.SiteMapNode("img") Is Nothing Then
                imgImagem.Src = e.Item.SiteMapNode("img")
            End If
            lblDescricao.Text = e.Item.SiteMapNode.Description
            trTopo.Visible = True
            Me.Page.Title = ConfigurationManager.AppSettings("Title") & " - " & e.Item.SiteMapNode("caption")

            Dim strSecao As String = ""
            If Not e.Item.SiteMapNode("Secao") Is Nothing Then
                strSecao = e.Item.SiteMapNode("Secao")
                If Not permissao.VerificaPermissao(strSecao, "Visualizar") Then
                    Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
                    If strCurrentURL <> "~/home/default.aspx" Then
                        Response.Redirect("~/home/default.aspx")
                    End If

                End If

            End If

            'If TypeOf (Me.Page) Is XMWebPage Then
            '    Dim WebPage As XMWebPage = CType(Me.Page, XMWebPage)
            '    If Not WebPage.VerificaPermissao(e.Item.SiteMapNode.Title, "Visualizar") Then
            '        Response.Redirect("~/home/default.aspx")
            '    End If
            'End If

        End If

        If Not e.Item.SiteMapNode("parameters") Is Nothing Then
            Dim vParams() As String = e.Item.SiteMapNode("parameters").Split(",")
            Dim strParams As String = ""
            Dim blnFirst As Boolean = True
            For i As Integer = 0 To vParams.GetUpperBound(0)
                If blnFirst Then
                    strParams &= "?"
                    blnFirst = False
                Else
                    strParams &= "&"
                End If
                strParams &= vParams(i) & "=" & Request(vParams(i))
            Next
            If e.Item.Controls(0).GetType().ToString = "System.Web.UI.WebControls.HyperLink" Then
                CType(e.Item.Controls(0), System.Web.UI.WebControls.HyperLink).NavigateUrl &= strParams
            End If
        End If
    End Sub

    Protected Sub BindMenuLateral(ByVal ndParent As XmlNode)
        Dim l As New Generic.List(Of MenuItem)
        Dim miLateral As MenuItem
        mnuLateral.Items.Clear()
        For Each nd As XmlNode In ndParent.ChildNodes
            miLateral = New MenuItem()
            miLateral.Text = nd.Attributes.GetNamedItem("title").Value
            miLateral.NavigateUrl = nd.Attributes.GetNamedItem("url").Value
            miLateral.Selected = isSelected(nd)
            miLateral.ImageUrl = nd.Attributes.GetNamedItem("img").Value
            Dim ndSecao As XmlNode = nd.Attributes.GetNamedItem("Secao")
            Dim strSecao As String = ""
            If Not ndSecao Is Nothing Then strSecao = ndSecao.Value

            If strSecao <> "" Then
                If permissao.VerificaPermissao(strSecao, "Visualizar") Then l.Add(miLateral)
            Else
                l.Add(miLateral)
            End If

            'If TypeOf (Me.Page) Is XMWebPage Then
            '    Dim WebPage As XMWebPage = CType(Me.Page, XMWebPage)
            '    If WebPage.VerificaPermissao(miLateral.Text, "Visualizar") Then
            '        l.Add(miLateral)
            '    End If
            'Else
            '    l.Add(miLateral)
            'End If

        Next
        For i As Integer = 0 To l.Count - 1
            mnuLateral.Items.Add(l.Item(i))
        Next

    End Sub


End Class

