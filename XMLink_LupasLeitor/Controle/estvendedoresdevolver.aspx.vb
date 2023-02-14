Imports Classes

Partial Class Controle_estvendedoresdevolver
    Inherits XMWebPage
    Protected cls As clsVendedor
    Protected Const VW_IDVENDEDOR As String = "IDVENDEDOR"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsVendedor()
        If Not Page.IsPostBack Then
            ViewState(VW_IDVENDEDOR) = CInt("0" & Request("IDVENDEDOR"))
            cls.Load(ViewState(VW_IDVENDEDOR))

            'Bind Combos
            Dim cat As New clsCategoria
            cboIDCategoria.DataSource = cat.Listar
            cboIDCategoria.DataBind()
            cboIDCategoria.Items.Insert(0, New ListItem("TODOS", 0))
            cat = Nothing

            Inflate()
        Else
            cls.Load(ViewState(VW_IDVENDEDOR))
        End If
    End Sub

    Protected Sub Inflate()
        lblVendedor.Text = cls.Vendedor
        lblCodigo.Text = cls.Codigo
    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("estvendedores.aspx?idvendedor=" & cls.IDVendedor)
    End Sub

    Protected Sub btnAdicionar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        cls.Consignacao.AdicionaProduto(ViewState("IDProdutoSelecionado"), txtQuantidade.Text)
        plhAdicionar.Visible = False
        lblMensagem.Text = "O produto informado foi adicionado ao estoque do vendedor!"
        BindProdutos()
    End Sub


    Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
        If e.CommandName = "DevolverProduto" Then
            Dim prd As New clsProduto
            prd.Load(grdProdutos.DataKeys(e.CommandArgument).Value)

            ViewState("IDProdutoSelecionado") = prd.IDProduto
            plhAdicionar.Visible = True
            lblProdutoCodigo.Text = prd.Codigo
            lblProdutoDescricao.Text = prd.Descricao
            txtQuantidade.Text = ""
            lblMensagem.Text = ""
        End If
    End Sub


#Region "Filtro de Produtos"

    Protected Sub BindProdutos()
        Dim ret As IPaginaResult = cls.Consignacao.ProdutosNaoConsignados(ViewState("Filtro"), cboIDCategoria.SelectedValue, SortExpression, SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
        grdProdutos.DataSource = ret.Data
        grdProdutos.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing
    End Sub


    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindProdutos()
    End Sub

    Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
        Paginate1.CurrentPage = 0
        ViewState("Filtro") = txtFiltro.Text
        BindProdutos()
    End Sub

    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProdutos.Sorted
        BindProdutos()
    End Sub

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Paginate1.CurrentPage = 0
        BindProdutos()
    End Sub


#Region "Sorting"


    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdProdutos.Sorting
        If SortExpression = e.SortExpression Then
            If SortDirection = WebControls.SortDirection.Ascending Then
                SortDirection = WebControls.SortDirection.Descending
            Else
                SortDirection = WebControls.SortDirection.Ascending
            End If
        Else
            SortExpression = e.SortExpression
            SortDirection = WebControls.SortDirection.Ascending
        End If
    End Sub

    Protected Property SortExpression() As String
        Get
            If ViewState("SortExpression") Is Nothing Then
                Return ""
            Else
                Return ViewState("SortExpression")
            End If
        End Get
        Set(ByVal value As String)
            ViewState("SortExpression") = value
        End Set
    End Property

    Protected Property SortDirection() As SortDirection
        Get
            If ViewState("SortDirection") Is Nothing Then
                Return WebControls.SortDirection.Ascending
            Else
                Return ViewState("SortDirection")
            End If
        End Get
        Set(ByVal value As SortDirection)
            ViewState("SortDirection") = value
        End Set
    End Property

#End Region

#End Region


End Class
