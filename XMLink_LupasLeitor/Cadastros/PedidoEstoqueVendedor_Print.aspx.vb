Imports Classes

Partial Class Cadastros_PedidoEstoqueVendedor_Print
    Inherits XMWebPage

    Dim cls As Classes.clsPedidoEstoqueVendedor
    Protected Const VW_IDPEDIDOESTOQUEVENDEDOR As String = "IDPedidoEstoqueVendedor"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState(VW_IDPEDIDOESTOQUEVENDEDOR) = CInt("0" & Request("idpev"))
            cls = New Classes.clsPedidoEstoqueVendedor
            cls.Load(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))

            lblData.Text = cls.Data
            lblVendedor.Text = cls.Vendedor
            lblUsuario.Text = cls.Usuario
            lblStatus.Text = cls.Status
            lblTipo.Text = IIf(cls.TipoPedido = 1, "Inclusão de Estoque", IIf(cls.TipoPedido = 2, "Devolução de Estoque", ""))

            grdItens.DataSource = cls.Itens.ListarItens(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
            grdItens.DataBind()

        End If

    End Sub
End Class
