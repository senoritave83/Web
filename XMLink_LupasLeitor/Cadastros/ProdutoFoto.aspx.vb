Imports System.Web.Services


Imports Classes

Partial Class Cadastros_ProdutoFoto
    Inherits XMWebPage

    Dim cls As clsProdutoFoto
    Protected Const VW_IDPRODUTO As String = "IDProduto"
    Protected Const VW_IDPRODUTOFOTO As String = "IDProdutoFoto"



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        cls = New clsProdutoFoto()
        If Not Page.IsPostBack Then
            ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
            ViewState("From") = CStr("" & Request("From"))
            If String.IsNullOrEmpty(Request("IDProdutoFoto")) Then
                Response.Redirect("produto.aspx?idproduto=" & ViewState(VW_IDPRODUTO))
            End If
            ViewState(VW_IDPRODUTOFOTO) = New Guid(CStr(Request("IDProdutoFoto")))

            cls.Load(ViewState(VW_IDPRODUTOFOTO), ViewState(VW_IDPRODUTO))
            Inflate()
        End If
    End Sub


    Protected Sub Inflate()
        Dim prd As New clsProduto
        prd.Load(ViewState(VW_IDPRODUTO))
        lblCodigo.Text = prd.Codigo
        lblDescricao.Text = prd.Descricao
        imgProduto.ImageUrl = "~/imagens/produtos/" & cls.Foto
    End Sub


    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        If ViewState("From") = "fotos" Then
            Response.Redirect("Produtofotos.aspx?idproduto=" & ViewState(VW_IDPRODUTO))
        Else
            Response.Redirect("Produto.aspx?idproduto=" & ViewState(VW_IDPRODUTO))
        End If

    End Sub
End Class
