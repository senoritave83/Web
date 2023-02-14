Namespace Controls
    <Themeable(True)> _
    Partial Public Class XMTitulo
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
                    imgImagem.ImageUrl = e.Item.SiteMapNode("img")
                Else
                    If imgImagem.ImageUrl = "" Then imgImagem.Visible = False
                End If
                lblDescricao.Text = e.Item.SiteMapNode.Description

                Dim strSecao As String = ""
                If Not e.Item.SiteMapNode("Secao") Is Nothing Then
                    strSecao = e.Item.SiteMapNode("Secao")
                    Dim permissao As New Classes.clsPermissao
                    If Not permissao.VerificaPermissao(strSecao, "Visualizar") Then
                        Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
                        If strCurrentURL <> "~/home/default.aspx" Then
                            Response.Redirect("~/home/default.aspx")
                        End If

                    End If

                End If

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
            'If e.Item.SiteMapNode.Title = "Atleta" Then
            '    Dim ltr As Literal = e.Item.Controls(0)
            '    Dim oAtleta As New Classes.Atletas
            '    Dim dr As System.Data.Common.DbDataReader = oAtleta.GetAtleta(CInt("0" & Request("idAtleta")))
            '    If dr.Read Then
            '        ltr.Text = dr.Item("atl_Nome_chr")
            '    End If
            '    dr.Close()
            '    dr = Nothing
            'ElseIf e.Item.SiteMapNode.Title = "categoria" Then
            '    Dim ltr As Object = e.Item.Controls(0)
            '    Dim oCategoria As New Classes.Categoria
            '    oCategoria.Load(CInt("0" & Request("idcategoria")))
            '    If oCategoria.IDCategoria > 0 Then ltr.Text = oCategoria.Categoria
            '    If TypeOf (ltr) Is HyperLink Then CType(ltr, HyperLink).NavigateUrl &= "?idcategoria=" & Request("idcategoria")
            '    oCategoria = Nothing
            'ElseIf e.Item.SiteMapNode.Title = "subcategoria" Then
            '    Dim ltr As Object = e.Item.Controls(0)
            '    Dim oSub As New Classes.SubCategoria
            '    oSub.Load(CInt("0" & Request("idsubcategoria")))
            '    If oSub.IDSubCategoria > 0 Then ltr.Text = oSub.SubCategoria
            '    If TypeOf (ltr) Is HyperLink Then CType(ltr, HyperLink).NavigateUrl &= "?idcategoria=" & Request("idcategoria") & "&idsubcategoria=" & Request("idsubcategoria")
            '    oSub = Nothing
            'ElseIf e.Item.SiteMapNode.Title = "Current" Then
            '    Dim ltr As Literal = e.Item.Controls(0)
            '    Try
            '        ltr.Text = CType(Me.mainContent.Page, XMWebPage).PageName
            '    Catch
            '        ltr.Text = "Erro"
            '    End Try
            'End If
        End Sub


        Public Property Descricao() As String
            Get
                Return lblDescricao.Text
            End Get
            Set(ByVal Value As String)
                lblDescricao.Text = Value
            End Set
        End Property

        Public Property Titulo() As String
            Get
                Return lblTitulo.Text
            End Get
            Set(ByVal Value As String)
                lblTitulo.Text = Value
            End Set
        End Property

        Public Property Imagem() As String
            Get
                Return imgImagem.ImageUrl
            End Get
            Set(ByVal Value As String)
                imgImagem.ImageUrl = Value
            End Set
        End Property

        Public WriteOnly Property ShowSiteMapPath() As Boolean
            Set(ByVal Value As Boolean)
                SiteMapPath1.Visible = Value
            End Set
        End Property

        Protected Sub SiteMapPath1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles SiteMapPath1.PreRender

            Dim strCurrentURL As String = Me.Request.AppRelativeCurrentExecutionFilePath.ToLower()
            If strCurrentURL = "~/home/login.aspx" Then
                tblXMTitulo.Visible = False
            End If

        End Sub
    End Class

End Namespace
