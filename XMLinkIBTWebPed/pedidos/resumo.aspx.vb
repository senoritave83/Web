Imports Classes

Partial Class pedidos_resumo
    Inherits XMWebPage

    Protected ped As clsPedido
    Protected m_decTotal As Decimal = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ped = New clsPedido
        If Not Page.IsPostBack Then
            ViewState("IDPEDIDO") = Request("idpedido")
            Dim strPedido As String = ViewState("IDPEDIDO") & ""
            If strPedido <> "" Then
                ped.Load(ViewState("IDPEDIDO"))
                Inflate()
                BindProdutos()
            Else
                Response.Redirect("default.aspx", True)
            End If
        Else
            ped.Load(ViewState("IDPEDIDO"))
        End If
    End Sub

    Protected Sub Inflate()
        With ped
            lblCliente.Text = .Cliente
            lblDataEntrega.Text = .DataEntrega
            lblObservacao.Text = .Observacao
            lblIDCondicao.Text = .Condicao
            lblIDFormaPagamento.Text = .FormaPagamento
            lblDataCriacao.Text = .DataCriacao
            lblDataEmissao.Text = .DataEmissao
            Select Case .IDTipoPedido
                Case 1
                    lblIDTipoPedido.Text = "Venda"
                Case Else
                    lblIDTipoPedido.Text = ""
            End Select

            Select Case .IDOpcao
                Case 1
                    lblIDOpcao.Text = "Opção 1"
                Case 2
                    lblIDOpcao.Text = "Opção 2"
                Case Else
                    lblIDOpcao.Text = ""
            End Select

            Dim cli As New clsCliente
            cli.Load(.IDCliente)
            lblCNPJ.Text = cli.CNPJ
            lblCodigoCliente.Text = cli.Codigo

        End With
    End Sub

    Protected Sub BindProdutos()
        m_decTotal = 0
        grdProdutos.DataSource = ped.ListarItens()
        grdProdutos.DataBind()

        ltrSubTotal.Text = FormatCurrency(m_decTotal, 2)
        Dim m_curDesconto As Decimal = m_decTotal * ped.Desconto / 100
        ltrDesconto.Text = FormatCurrency(m_curDesconto, 2) & " (" & FormatNumber(ped.Desconto, 2) & "%)"
        plhSubTotal.Visible = ped.Desconto > 0
        ltrTotal.Text = FormatCurrency(m_decTotal - m_curDesconto, 2)
        'btnAvancar.Enabled = m_decTotal > 0

    End Sub

    Protected Function GetSubTotal(ByVal vQuantidade As Integer, ByVal vPreco As Decimal) As String
        m_decTotal += (vQuantidade * vPreco)
        Return FormatCurrency(vQuantidade * vPreco, 2)
    End Function


    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("pedido.aspx?idpedido=" & Server.UrlEncode(ped.IDPedido) & "&idcliente=" & ped.IDCliente)
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        ped.FinalizarPedido()
        Response.Redirect("gravado.aspx?numpedido=" & ped.NumeroPedido & "&idcliente=" & ped.IDCliente)
    End Sub
End Class
