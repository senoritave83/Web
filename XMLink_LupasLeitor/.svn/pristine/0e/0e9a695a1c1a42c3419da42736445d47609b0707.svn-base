
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class PedidoEstoqueVendedores
        Inherits XMWebPage

		Dim cls As clsPedidoEstoqueVendedor
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedidoEstoqueVendedor()
            If Not Page.IsPostBack Then
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                'Bind Combos
                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("TODOS", 0))
				ven = Nothing

                Dim usu As New clsUsuario
                cboIDUsuario.DataSource = usu.Listar
                cboIDUsuario.DataBind()
                cboIDUsuario.Items.Insert(0, New ListItem("TODOS", 0))
				usu = Nothing

                Me.RecuperaFiltro(txtFiltro, Paginate1, Letras1, txtIDPedidoEstoqueVendedor, cboTipoPedido, cboIDVendedor, txtDataInicial, txtDataFinal, cboIDUsuario)
                BindGrid()
            End If			
        End Sub

        Public Sub BindGrid()
            Dim p_IdPedido As Integer = 0
            If txtIDPedidoEstoqueVendedor.Text <> "" And IsNumeric(txtIDPedidoEstoqueVendedor.Text) Then
                p_IdPedido = txtIDPedidoEstoqueVendedor.Text
            End If
            Dim ret As IPaginaResult = cls.Listar(Paginate1.Filtro, p_IdPedido, cboTipoPedido.SelectedValue, cboIDVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDUsuario.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(txtFiltro, Letras1, Paginate1, txtIDPedidoEstoqueVendedor, cboTipoPedido, cboIDVendedor, txtDataInicial, txtDataFinal, cboIDUsuario)
        End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub

        Private Sub txtFiltro_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFiltro.TextChanged
            Paginate1.CurrentPage = 0
            Letras1.Letra = ""
            Paginate1.Filtro = txtFiltro.Text
            BindGrid()
        End Sub

        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub
		

        Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
            Paginate1.CurrentPage = 0
            Paginate1.Filtro = vLetra
            txtFiltro.Text = ""
            BindGrid()
        End Sub

        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub		

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub

    End Class

End Namespace

