
Partial Class controls_Titulo
    Inherits System.Web.UI.UserControl


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
                'If Not permissao.VerificaPermissao(strSecao, "Visualizar") Then
                '    Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
                '    If strCurrentURL <> "~/home/default.aspx" Then
                '        Response.Redirect("~/home/default.aspx")
                '    End If

                'End If

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


End Class
