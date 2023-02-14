
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"
        Protected Const VW_IDVISITA As String = "IDVisita"
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
                ViewState(VW_IDVISITA) = CInt(0 & Request("IDVisita"))
                cls.Load(ViewState(VW_IDPEDIDO))

                Inflate()
                BindGrid()
            Else
                cls.Load(ViewState(VW_IDPEDIDO))
          End If
        End Sub


        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor
            lblCliente.Text = cls.Cliente
            lblDataEmissao.Text = cls.DataEmissao
            lblCodigo.Text = cls.Codigo
            lblDataEntrega.Text = cls.DataEntrega
            lblFormaPagamento.Text = cls.FormaPagamento
            lblStatus.Text = cls.StatusPedido
            lblDesconto.Text = FormatNumber(cls.Desconto, 2) & "%"
            lblNumeroPedido.Text = cls.NumeroPedido
            lblCondicao.Text = cls.Condicao

            lblIDCliente.Text = cls.CodigoCliente
            Dim ven As New clsVendedor
            ven.Load(cls.IDVendedor)
            lblCodigoVendedor.Text = ven.Codigo
            ven = Nothing

            lblEnderecoCobranca.Text = cls.EnderecoCobranca
            lblEnderecoEntrega.Text = cls.EnderecoEntrega
            lblEnderecoFaturamento.Text = cls.EnderecoFaturamento

            If cls.IDInsumo = 0 Then
                lblInsumo.Text = "N&atilde;o"
            Else
                lblInsumo.Text = "Sim"
            End If
            If cls.IDTransporte = 0 Then
                lblTransporte.Text = "Transportadora"
            End If
            If cls.IDTransporte = 1 Then
                lblTransporte.Text = "Assessor"
            End If
            If cls.IDTransporte = 2 Then
                lblTransporte.Text = "Cliente Retira"
            End If


            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude

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
            lnkVisita.Text = cls.IDVisita
            lnkVisita.NavigateUrl = "visita.aspx?idvisita=" & cls.IDVisita
        End Sub



        Protected Sub BindGrid()


            Dim dr As Data.IDataReader = cls.ListItensPedido(DataClass.enReturnType.DataReader)

            grdItens.DataSource = dr
            grdItens.DataBind()




        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            If ViewState(VW_IDVISITA) = 0 Then
                Response.Redirect("pedidos.aspx")
            Else
                Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
            End If
        End Sub

    End Class

End Namespace

