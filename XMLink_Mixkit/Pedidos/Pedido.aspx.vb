
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"
        Protected Const VW_IDVISITA As String = "IDVisita"
         Protected Const ACAO_CANCELARPEDIDO As String = "Cancelar Pedido"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                'subAddConfirm(btnCancelar, "Deseja realmente cancelar este pedido?")
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
                ViewState(VW_IDVISITA) = CInt(0 & Request("IDVisita"))
                cls.Load(ViewState(VW_IDPEDIDO))

                Inflate()
                BindGrid()
            Else
                cls.Load(ViewState(VW_IDPEDIDO))
            End If

            'If cls.IDStatusPedido = 3 And VerificaPermissao(SECAO, ACAO_CANCELARPEDIDO) Then
            '    btnCancelar.Visible = True
            '    lblCancelar.Visible = True
            'End If
        End Sub


        Protected Sub Inflate()

            lblCliente.Text = cls.Cliente
            lblVendedor.Text = cls.Vendedor
            lblDataEmissao.Text = cls.DataEmissao
            lblDataEntrega.Text = cls.DataEntrega
            lblStatus.Text = cls.StatusPedido
            lblNumeroPedido.Text = cls.NumeroPedido
            lblCondicao.Text = cls.Condicao
            lblDesconto.Text = cls.Desconto
            lblFormaPagamento.Text = cls.FormaPagamento

            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude

            If cls.Total <> cls.SubTotal Then
                ltrSubTotal.Text = "Sub Total: <b>R$ " & FormatNumber(cls.SubTotal, 2) & "</b><br />"
                ltrDesconto.Text = "Desconto: <b>R$ " & FormatNumber(cls.SubTotal - cls.Total, 2) & " (" & FormatPercent((cls.SubTotal - cls.Total) / cls.SubTotal, 2) & ")</b><br />"
                ltrSubTotal.Visible = True
                ltrDesconto.Visible = True
            Else
                ltrSubTotal.Visible = False
                ltrDesconto.Visible = False
            End If
            ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b><br />"

            If cls.IDStatusPedido = 3 Then
                btnAprovar.Enabled = VerificaPermissao(Secao, "Aprovar Pedido")
                btnCancelar.Enabled = VerificaPermissao(Secao, "Cancelar Pedido")
            Else
                btnAprovar.Enabled = False
                btnCancelar.Enabled = False
            End If
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

        'Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        '    If VerificaPermissao(SECAO, ACAO_CANCELARPEDIDO) Then
        '        cls.CancelarPedido(ViewState(VW_IDPEDIDO))
        '        If ViewState(VW_IDVISITA) = 0 Then
        '            Response.Redirect("pedidos.aspx")
        '        Else
        '            Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
        '        End If
        '    End If
        'End Sub


        Protected Sub btnAprovar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprovar.Click
            plhListaItens.Visible = False
            plhAprovacao.Visible = True
            plhMotivo.Visible = False
            lblMensagem.Text = "Confirma a aprova&ccedil&atilde;o do pedido " & cls.NumeroPedido & "?"

        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            plhListaItens.Visible = False
            plhAprovacao.Visible = True
            plhMotivo.Visible = True
            lblMensagem.Text = "Deseja realmente cancelar o pedido " & cls.NumeroPedido & "?"
        End Sub

        Protected Sub btnNao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNao.Click
            plhListaItens.Visible = True
            plhAprovacao.Visible = False
        End Sub

        Protected Sub btnSim_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSim.Click
            If Not plhMotivo.Visible Then
                cls.AprovaPedido()
            Else
                cls.ReprovaPedido(txtMotivo.Text)
            End If
            Response.Redirect("pedido.aspx?idpedido=" & cls.IDPedido.ToString())
        End Sub

    End Class

End Namespace

