Imports Classes

Partial Class Controle_consignacaohistorico
    Inherits XMWebPage
    Protected cls As clsCliente
    Protected prd As clsProduto
    Protected Const VW_IDCLIENTE As String = "IDCliente"
    Protected Const VW_IDPRODUTO As String = "IDProduto"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsCliente()
        prd = New clsProduto()
        If Not Page.IsPostBack Then
            ViewState(VW_IDCLIENTE) = CInt("0" & Request("IDCliente"))
            ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))


            cls.Load(ViewState(VW_IDCLIENTE))
            prd.Load(ViewState(VW_IDPRODUTO))

            'Move para página final
            Paginate1.CurrentPage = 100000

            Inflate()
            BindGrid()
        Else
            cls.Load(ViewState(VW_IDCLIENTE))
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
        lblCliente.Text = cls.Cliente
        lblCNPJ.Text = cls.CNPJ
        lblCodigo.Text = cls.Codigo
        lblProdutoCodigo.Text = prd.Codigo
        lblProdutoDescricao.Text = prd.Descricao
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("consignado.aspx?idcliente=" & cls.IDCliente)
    End Sub

End Class
