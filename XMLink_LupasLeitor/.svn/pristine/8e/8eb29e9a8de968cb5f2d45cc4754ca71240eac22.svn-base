Imports Classes

Partial Class Controle_ConsignacaoVendedores_Historico
    Inherits XMWebPage
    Protected cls As clsVendedor
    Protected prd As clsProduto
    Protected Const VW_IDVENDEDOR As String = "IDVENDEDOR"
    Protected Const VW_IDPRODUTO As String = "IDProduto"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsVendedor()
        prd = New clsProduto()
        If Not Page.IsPostBack Then
            ViewState(VW_IDVENDEDOR) = CInt("0" & Request("IDVENDEDOR"))
            ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))


            cls.Load(ViewState(VW_IDVENDEDOR))
            prd.Load(ViewState(VW_IDPRODUTO))

            'Move para página final
            Paginate1.CurrentPage = 100000

            Inflate()
            BindGrid()
        Else
            cls.Load(ViewState(VW_IDVENDEDOR))
        End If
    End Sub

    Protected Sub BindGrid()
        Dim ret As IPaginaResult = cls.Consignacao.ListaHistorico(prd.IDProduto, Paginate1.CurrentPage, 20)

        grdHistorico.DataSource = ret.Data
        grdHistorico.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()

    End Sub

    Protected Sub Inflate()
        lblVendedor.Text = cls.Vendedor
        lblCodigo.Text = cls.Codigo
        lblProdutoCodigo.Text = prd.Codigo
        lblProdutoDescricao.Text = prd.Descricao
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("consignadovendedores.aspx?idvendedor=" & cls.IDVendedor)
    End Sub

End Class
