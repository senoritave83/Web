Imports Classes

Partial Class Pedidos_negociacao
    Inherits XMWebPage
    Dim cls As clsNegociacao
    Protected Const VW_IDNEGOCIACAO As String = "IDNegociacao"
    Protected Soma As New Somarizador
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsNegociacao()
        If Not Page.IsPostBack Then
            ViewState(VW_IDNEGOCIACAO) = CStr("" & Request("IDNegociacao"))
            cls.Load(ViewState(VW_IDNEGOCIACAO))

            Inflate()
            BindGrid()
        Else
            cls.Load(ViewState(VW_IDNEGOCIACAO))
        End If
    End Sub


    Protected Function CalcularDesconto(ByVal vTotal As Decimal, ByVal vFinal As Decimal) As Decimal
        If vTotal = 0 Then
            Return 0
        Else
            Return (vTotal - vFinal) / vTotal
        End If
    End Function



    Protected Sub Inflate()

        lblVendedor.Text = cls.Vendedor
        lblCliente.Text = cls.Cliente
        lblDataEmissao.Text = cls.DataEmissao
        lblCodigo.Text = cls.OrdemVenda
        lblNumeroCompra.Text = cls.Codigo

        lblDataEntrega.Text = cls.DataEntrega
        'lblFormaPagamento.Text = cls.FormaPagamento
        'lblValorBruto.Text = FormatCurrency(cls.ValorBruto, 2)
        lblNumeroPedido.Text = cls.NumeroNegociacao
        lblCondicao.Text = cls.Condicao
        lblMarketCode.Text = cls.MarketCode

        'lblEnderecoCobranca.Text = cls.EnderecoCobranca
        'lblEnderecoEntrega.Text = cls.EnderecoEntrega
        'lblEnderecoFaturamento.Text = cls.EnderecoFaturamento

        lblObservacao.Text = cls.Observacao


        lblReferencia.Text = cls.Referencia
        lblOrdemHeader.Text = cls.OrdemHeader
        'lblOrdemFooter.Text = cls.OrdemFooter
        lblPrioridade.Text = cls.Prioridade

        Dim ven As New clsVendedor
        ven.Load(cls.IDVendedor)
        lblCodigoVendedor.Text = ven.Codigo
        ven = Nothing

        lblIDCliente.Text = cls.CodigoCliente

        'If cls.IDInsumo = 0 Then
        '    lblInsumo.Text = "N&atilde;o"
        'Else
        '    lblInsumo.Text = "Sim"
        'End If
        'If cls.IDTransporte = 0 Then
        '    lblTransporte.Text = "Transportadora"
        'End If
        'If cls.IDTransporte = 1 Then
        '    lblTransporte.Text = "Assessor"
        'End If
        'If cls.IDTransporte = 2 Then
        '    lblTransporte.Text = "Cliente Retira"
        'End If

        If cls.Desconto <> 0 Then
            ltrSubTotal.Text = "Sub-Total: R$ " & FormatNumber(cls.SubTotal, 2) & "<br />"

            If cls.Desconto > 0 Then
                ltrDesconto.Text = "Desconto: R$ " & FormatNumber(cls.Desconto, 2) & " (" & FormatPercent(cls.PorcentagemDesconto, 2) & ")<br />"
            Else
                ltrDesconto.Text = "Acrescimo: R$ " & FormatNumber(cls.Desconto * -1, 2) & " (" & FormatPercent(cls.PorcentagemDesconto * -1, 2) & ")<br />"
            End If
        Else
            ltrSubTotal.Text = ""
            ltrDesconto.Text = ""
        End If
        ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b>"
    End Sub



    Protected Sub BindGrid()


        Dim dr As Data.IDataReader = cls.ListaItens(DataClass.enReturnType.DataReader)

        grdItens.DataSource = dr
        grdItens.DataBind()




    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("negociacoes.aspx")
    End Sub

End Class
