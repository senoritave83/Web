Imports Classes


Partial Class pedidos_novopedido
    Inherits XMWebPage
    Protected intIDCliente As Integer
    Protected intIDVisita As Integer
    Protected cls As clsAtendimentoCliente

    Protected Enum enEtapa As Integer
        TipoCopia = 2
        OpcaoPedido = 3
        Listagem = 4
        Informar = 5
        Resultado = 6
    End Enum

    Protected Property TipoCopia() As enTipoCopia
        Get
            Return ViewState("TIPOCOPIA")
        End Get
        Set(ByVal value As enTipoCopia)
            ViewState("TIPOCOPIA") = value
        End Set
    End Property

    Protected Property Etapa() As enEtapa
        Get
            Return ViewState("Etapa")
        End Get
        Set(ByVal value As enEtapa)
            ViewState("Etapa") = value
            pnlCopiaInformar.Visible = (value = enEtapa.Informar)
            pnlCopiaLista.Visible = (value = enEtapa.Listagem)
            pnlCopiaPedidos.Visible = (value = enEtapa.OpcaoPedido)
            pnlCopiar.Visible = True
            pnlCopiaResultado.Visible = (value = enEtapa.Resultado)
            pnlOpcaoCopia.Visible = (value = enEtapa.TipoCopia)
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsAtendimentoCliente()

        If Not Page.IsPostBack Then
            intIDCliente = CInt("0" & Request("idcliente"))
            intIDVisita = CInt("0" & Request("idvisita"))
            ViewState("IDCLIENTE") = intIDCliente
            ViewState("IDVISITA") = intIDVisita
            Etapa = enEtapa.TipoCopia
            cls.Load(intIDCliente)
        Else
            intIDCliente = ViewState("IDCLIENTE")
            intIDVisita = ViewState("IDVISITA")

            cls.Load(intIDCliente)
        End If
    End Sub


    Protected Sub lnkNaoCopiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNaoCopiar.Click
        CriarPedido(-1)
    End Sub


    Protected Sub lnkCopiarPedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCopiarPedido.Click
        TipoCopia = enTipoCopia.Copiar_Pedido
        Etapa = enEtapa.OpcaoPedido
    End Sub

    Protected Sub lnkCopiarItens_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCopiarItens.Click
        TipoCopia = enTipoCopia.Copiar_Itens
        Etapa = enEtapa.OpcaoPedido
    End Sub

    Protected Sub lnkcopiaListar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkcopiaListar.Click
        Dim ped As New clsPedido
        Etapa = enEtapa.Listagem
        grdUltimosPedidos.DataSource = ped.ListarUltimosPedidos(cls.IDCliente)
        grdUltimosPedidos.DataBind()
    End Sub

    Protected Sub lnkcopiaInformar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkcopiaInformar.Click
        Etapa = enEtapa.Informar
        lblMensagem.Text = ""
        txtNumeroPedido.Text = ""
    End Sub

    Protected Sub btnCopiarVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCopiarVoltar.Click
        If Etapa = enEtapa.Informar Or Etapa = enEtapa.Listagem Then
            Etapa = enEtapa.OpcaoPedido
        ElseIf Etapa = enEtapa.OpcaoPedido Then
            Etapa = enEtapa.TipoCopia
        ElseIf Etapa = enEtapa.TipoCopia Then
            Response.Redirect("cliente.aspx?idcliente=" & intIDCliente)
        End If
    End Sub

    Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        Dim ped As New clsPedido
        If ped.ExistePedido(txtNumeroPedido.Text) Then
            CriarPedido(txtNumeroPedido.Text)
        Else
            lblMensagem.Text = "Pedido inexistente!"
        End If
    End Sub

    Protected Sub CriarPedido(ByVal vIDNumeroPedido As Integer)
        Dim ped As New clsPedido
        ped.NovoPedido(intIDVisita, intIDCliente, 1, vIDNumeroPedido, TipoCopia)
        Response.Redirect("produtos.aspx?idpedido=" & Server.UrlEncode(ped.IDPedido) & "&idcliente=" & ped.IDCliente)
    End Sub


    Protected Sub grdUltimosPedidos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdUltimosPedidos.RowCommand
        If e.CommandName = "Copiar" Then
            Dim vNumPedido As Integer
            vNumPedido = grdUltimosPedidos.DataKeys(e.CommandArgument).Value
            CriarPedido(vNumPedido)
        End If
    End Sub

    Protected Sub lnkCopiaUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCopiaUltimo.Click
        CriarPedido(0)
    End Sub
End Class
