
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
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
            lblDataEmissao.Text = FormatDateTime(cls.DataEmissao, 2)
            lblDataEntrega.Text = FormatDateTime(cls.DataEntrega, 2)
            lblStatus.Text = cls.StatusPedido
            lblDesconto.Text = FormatPercent(cls.Desconto, 0)
            lblNumeroPedido.Text = cls.NumeroPedido
            lblCondicao.Text = cls.Condicao
            lblForma.Text = cls.FormaPagamento
            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude
            lblCodigo.Text = cls.Codigo
            ltrQuantidadeItens.Text = "Total de Itens: <b>" & cls.TotalItens & "</b>"
            lblObservacao.Text = cls.Observacao
            rowObservacao.Visible = (cls.Observacao <> "")

            If cls.IDStatusPedido = 3 Then
                btnAprovar.Enabled = VerificaPermissao(Secao, "Aprovar Pedido")
                btnCancelar.Enabled = VerificaPermissao(Secao, "Cancelar Pedido")
            Else
                btnAprovar.Enabled = False
                btnCancelar.Enabled = False
            End If

            'lblDataDevolucao.Text = cls.DataDevolucao
        End Sub



        Protected Sub BindGrid()


            Dim dr As Data.IDataReader = cls.ListItensPedido(DataClass.enReturnType.DataReader)

            grdItens.DataSource = dr
            grdItens.DataBind()

            plhSubTotal.Visible = cls.Total <> cls.SubTotal
            ltrSubTotal.Text = "Sub-Total: <b>R$ " & FormatNumber(cls.SubTotal, 2) & "</b>"
            ltrDesconto.Text = "Desconto: <b>R$ " & FormatNumber(cls.SubTotal - cls.Total, 2) & " (" & FormatPercent(cls.Desconto) & ")</b>"


            ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b>"


        End Sub

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

