Imports Classes


Partial Class pedidos_pedido
    Inherits XMWebPage

    Protected ped As clsPedido
    Protected m_decTotal As Decimal = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ped = New clsPedido
        If Not Page.IsPostBack Then

            ViewState("IDPEDIDO") = Request("idpedido")
            Dim strPedido As String = ViewState("IDPEDIDO") & ""

            If strPedido <> "" Then

                ped.Load(strPedido)
                valCompDataentrega.ValueToCompare = Now().AddDays(1).ToString("dd/MM/yyyy")

                'Dim cli As New clsCliente
                'cli.Load(ped.IDCliente)
                'If cli.CondicaoPadrao <> "" Then cboCondicao.Items.Insert(0, New ListItem(cli.CondicaoPadrao, "0"))
                'cboCondicao.Items.Insert(0, New ListItem("", ""))
                'If cli.CondicaoPadrao <> "" Then cboCondicao.SelectedIndex = 1
                'CompareValidator2.ValueToCompare = cli.DescontoMax
                'CompareValidator2.ErrorMessage = "O valor do desconto máximo é de " & FormatNumber(cli.DescontoMax, 0) & "%"

                BindProdutos()
                BindCondicaoPagamento()
                BindFormaPagamento()
                Inflate()

            Else

                Response.Redirect("default.aspx", True)

            End If

        Else
            ped.Load(ViewState("IDPEDIDO"))
        End If
    End Sub

    Protected Sub BindFormaPagamento()
        Dim form As New clsFormaPagamento
        cboIDFormaPagamento.DataSource = form.Listar()
        cboIDFormaPagamento.DataBind()
        cboIDFormaPagamento.Items.Insert(0, New ListItem("Selecione...", 0))
    End Sub

    Protected Sub BindCondicaoPagamento()
        Dim cond As New clsCondicao
        cboIDCondicao.DataSource = cond.Listar()
        cboIDCondicao.DataBind()
        cboIDCondicao.Items.Insert(0, New ListItem("Selecione...", 0))
    End Sub

    Protected Sub BindProdutos()
        m_decTotal = 0
        grdProdutos.DataSource = ped.ListarItens()
        grdProdutos.DataBind()
        ltrTotal.Text = FormatCurrency(m_decTotal, 2)
        'btnAvancar.Enabled = m_decTotal > 0

    End Sub

    Protected Function GetSubTotal(ByVal vQuantidade As Integer, ByVal vPreco As Decimal) As String
        m_decTotal += (vQuantidade * vPreco)
        Return FormatCurrency(vQuantidade * vPreco, 2)
    End Function

    
    
    Protected Sub btnAvancar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAvancar.Click
        If Page.IsValid Then
            Deflate()
            ped.Update()
            Response.Redirect("resumo.aspx?idpedido=" & Server.UrlEncode(ped.IDPedido) & "&idcliente=" & ped.IDCliente)
        End If
    End Sub

    Protected Sub Deflate()
        With ped
            .DataEntrega = txtDataEntrega.Text
            .DataEmissao = txtDataEmissao.Text
            .Observacao = txtObservacao.Text
            .IDCondicao = getComboValues(cboIDCondicao)
            .IDFormaPagamento = getComboValues(cboIDFormaPagamento)
            .IDOpcao = getComboValues(drpIdOpcao)
            .IDTipoPedido = getComboValues(drpIdTipoPedido)
        End With
    End Sub

    Protected Sub Inflate()
        With ped

            Dim cli As New clsCliente

            lblCliente.Text = .Cliente
            lblDataCriacao.Text = .DataCriacao
            cli.Load(.IDCliente)
            lblCNPJ.Text = cli.CNPJ
            lblCodigoCliente.Text = cli.Codigo
            txtDataEntrega.Text = .DataEntrega
            If .DataEmissao = "" Then
                txtDataEmissao.Text = Now().ToString("dd/MM/yyyy")
            Else
                txtDataEmissao.Text = .DataEmissao
            End If
            txtObservacao.Text = .Observacao
            setComboValue(cboIDCondicao, .IDCondicao)
            setComboValue(cboIDFormaPagamento, .IDFormaPagamento)
            setComboValue(drpIdOpcao, .IDOpcao)
            setComboValue(drpIdTipoPedido, .IDTipoPedido)

            cli = Nothing

        End With

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("produtos.aspx?idpedido=" & Server.UrlEncode(ped.IDPedido) & "&idcliente=" & ped.IDCliente)
    End Sub
End Class
