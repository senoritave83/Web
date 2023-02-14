
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"
        Protected Const VW_IDVISITA As String = "IDVisita"
        Protected Const SECAO As String = "Cadastro de Pedido"
        Protected Const ACAO_CANCELARPEDIDO As String = "Cancelar Pedido"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                subAddConfirm(btnCancelar, "Deseja realmente cancelar este pedido?")
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
                ViewState(VW_IDVISITA) = CInt(0 & Request("IDVisita"))
                cls.Load(ViewState(VW_IDPEDIDO))

                Inflate()
                BindGrid()
            Else
                cls.Load(ViewState(VW_IDPEDIDO))
            End If

            If cls.IDStatusPedido = 3 And VerificaPermissao(SECAO, ACAO_CANCELARPEDIDO) Then
                btnCancelar.Visible = True
                lblCancelar.Visible = True
            End If
        End Sub


        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor
            lblCliente.Text = cls.Cliente
            lblDataEmissao.Text = cls.DataEmissao
            'lblDataEntrega.Text = cls.DataEntrega
            lblStatus.Text = cls.StatusPedido
            lblDesconto.Text = FormatNumber(cls.Desconto, 2) & "%"
            lblNumeroPedido.Text = cls.NumeroPedido
            'lblCondicao.Text = cls.Condicao


            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude

            If cls.Desconto <> 0 Then
                ltrSubTotal.Text = "Sub-Total: R$ " & FormatNumber(cls.SubTotal, 2) & "<br />"
                ltrDesconto.Text = "Desconto: " & FormatNumber(cls.Desconto, 2) & "%<br />"
            Else
                ltrSubTotal.Text = ""
                ltrDesconto.Text = ""
            End If
            ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b>"
            lnkVisita.Text = cls.IDVisita
            lnkVisita.NavigateUrl = "visita.aspx?idvisita=" & cls.IDVisita
            lblObservacao.Text = cls.Observacao
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

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            If VerificaPermissao(SECAO, ACAO_CANCELARPEDIDO) Then
                cls.CancelarPedido(ViewState(VW_IDPEDIDO))
                If ViewState(VW_IDVISITA) = 0 Then
                    Response.Redirect("pedidos.aspx")
                Else
                    Response.Redirect("visita.aspx?idvisita=" & ViewState(VW_IDVISITA))
                End If
            End If
        End Sub
    End Class

End Namespace

