Imports Classes

Partial Class vendedores_consignado
    Inherits XMWebPage
    Protected cls As clsVendedor
    Protected Const VW_IDVENDEDOR As String = "IDVENDEDOR"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsVendedor()
        If Not Page.IsPostBack Then
            ViewState(VW_IDVENDEDOR) = CInt("0" & Request("IDVENDEDOR"))
            cls.Load(ViewState(VW_IDVENDEDOR))
            Inflate()
        Else
            cls.Load(ViewState(VW_IDVENDEDOR))
        End If
    End Sub

    Protected Sub Inflate()
        lblVendedor.Text = cls.Vendedor
        lblCodigo.Text = cls.Codigo

        BindProdutos()
    End Sub

    Protected Sub BindProdutos()
        grdProdutos.DataSource = cls.Consignacao.ListarProdutosConsignados()
        grdProdutos.DataBind()
    End Sub

    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Editing = True
        BindProdutos()
    End Sub

    Public Property Editing() As Boolean
        Get
            Return btnGravar.Visible
        End Get
        Set(ByVal value As Boolean)
            btnGravar.Visible = value
            btnEditar.Visible = Not value
            btnCancelar.Visible = value
            btnAdicionar.Visible = Not value
            btnVoltar.Visible = Not value
        End Set
    End Property

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Editing = False
        BindProdutos()
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Dim col As New clsConsignacaoVendedor.clsProdutosConsignados

        For Each row As GridViewRow In grdProdutos.Rows
            Dim intIDProduto As Integer
            intIDProduto = grdProdutos.DataKeys(row.RowIndex).Value
            Dim txtEstoque As TextBox = CType(row.FindControl("txtEstoque"), TextBox)
            col.Add(intIDProduto, txtEstoque.Text)
        Next
        cls.Consignacao.AtualizaQuantidades(col)
        Editing = False
        BindProdutos()
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Response.Redirect("estvendedoresadicionar.aspx?idvendedor=" & cls.IDVendedor)
    End Sub

    Protected Sub btnDevolver_Click(sender As Object, e As System.EventArgs) Handles btnDevolver.Click
        Response.Redirect("estvendedoresdevolver.aspx?idvendedor=" & cls.IDVendedor)
    End Sub

End Class
