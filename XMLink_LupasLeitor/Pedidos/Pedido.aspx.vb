
Imports Classes
Imports System.Data

Namespace Pages.Pedidos

    Partial Public Class Pedido
        Inherits XMWebPage
        Dim cls As clsPedido
        Protected Const VW_IDPEDIDO As String = "IDPedido"
        Protected Message As String = ""


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPedido()
            If Not Page.IsPostBack Then
                ViewState(VW_IDPEDIDO) = CStr("" & Request("IDPedido"))
                cls.Load(ViewState(VW_IDPEDIDO))

                BindFormaPagamento()
                BindCondicaoPagamento()
                Inflate()
                BindGrid()
            Else
                cls.Load(ViewState(VW_IDPEDIDO))
            End If

            btnApagar.Attributes.Add("onClick", "return fncConfirmDelete();")
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

        Protected Sub Inflate()

            lblVendedor.Text = cls.Vendedor
            lblCliente.Text = cls.Cliente
            lblDataEmissao.Text = cls.DataEmissao
            lblDataEntrega.Text = cls.DataEntrega
            lblStatus.Text = cls.StatusPedido
            lblDesconto.Text = FormatPercent(cls.Desconto, 0)
            lblNumeroPedido.Text = cls.NumeroPedido
            cboIDCondicao.SelectedValue = cls.IDCondicao
            cboIDFormaPagamento.SelectedValue = cls.IDFormaPagamento
            lblTipoPedido.Text = cls.TipoPedido
            lblOpcao.Text = cls.Opcao
            plhPedidoComum.Visible = (cls.IDTipoPedido = clsPedido.enTipoPedido.Venda)
            plhPedidoFaturado.Visible = (cls.IDTipoPedido <> clsPedido.enTipoPedido.Bonificacao)
            Localizacao1.Latitude = cls.Latitude
            Localizacao1.Longitude = cls.Longitude

            grdHistorico.DataSource = cls.Historico()
            grdHistorico.DataBind()
            trHistorico.Visible = (grdHistorico.Rows.Count > 0)

            btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR) And cls.IDStatusPedido <> 4 And cls.IDStatusPedido <> 7

            If cls.IDStatusPedido = 3 And (cls.IDTipoPedido = 1 Or cls.IDTipoPedido = 2) Then
                cboIDCondicao.Enabled = True
                cboIDFormaPagamento.Enabled = True
                btnAlterar.Visible = True
                lclAjudaAlterar.Visible = True
                grdItens.Columns.Item(0).Visible = True 'ImageButton "Excluir"
                grdItens.Columns.Item(7).Visible = True 'LinkButton "Editar"
            Else
                cboIDCondicao.Enabled = False
                cboIDFormaPagamento.Enabled = False
                btnAlterar.Visible = False
                lclAjudaAlterar.Visible = False
                grdItens.Columns.Item(0).Visible = False 'ImageButton "Excluir"
                grdItens.Columns.Item(7).Visible = False 'LinkButton "Editar"
            End If

        End Sub


        Protected Sub BindGrid()

            Dim dr As Data.IDataReader = cls.ListItensPedido(DataClass.enReturnType.DataReader)

            grdItens.DataSource = dr
            grdItens.DataBind()

            For Each row As System.Web.UI.WebControls.GridViewRow In grdItens.Rows

                Dim imgDel As ImageButton = row.FindControl("imgExc")
                If grdItens.Rows.Count = 1 Then
                    If Not imgDel Is Nothing Then
                        imgDel.OnClientClick = "return confirm('Exclusão não permitida quando o pedido tem apenas um item. CONFIRMA CANCELAMENTO AUTOMÁTICO DO PEDIDO ?');"
                        imgDel.CommandName = "CancelarPedido"
                    End If
                Else
                    If Not imgDel Is Nothing Then
                        imgDel.OnClientClick = "return confirm('Deseja realmente excluir este item ?');"
                        imgDel.CommandName = "ExcluirItem"
                    End If
                End If

            Next

            If cls.IDTipoPedido = clsPedido.enTipoPedido.Consignacao Then
                grdItens.Columns.Item(5).Visible = False
                grdItens.Columns.Item(4).Visible = True
                grdItens.Columns.Item(6).Visible = True
                plhTotal.Visible = True
                plhReposicao.Visible = True
            ElseIf cls.IDTipoPedido = clsPedido.enTipoPedido.Venda Then
                grdItens.Columns.Item(5).Visible = True
                grdItens.Columns.Item(4).Visible = True
                grdItens.Columns.Item(6).Visible = True
                plhTotal.Visible = True
                plhReposicao.Visible = False
            Else
                grdItens.Columns.Item(5).Visible = False
                grdItens.Columns.Item(4).Visible = False
                grdItens.Columns.Item(6).Visible = False
                plhTotal.Visible = False
                plhReposicao.Visible = False
            End If

            grdReposicao.DataSource = cls.ListItensRepostos(DataClass.enReturnType.DataReader)
            grdReposicao.DataBind()

            If plhTotal.Visible Then ltrTotal.Text = "Total: <b>R$ " & FormatNumber(cls.Total, 2) & "</b>"

        End Sub


        Protected Sub grdItens_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdItens.RowCommand
            ViewState("IDItemPedido") = e.CommandArgument

            If e.CommandName = "EditarItem" Then
                divEditarItemPed.Visible = True
                Dim ds As DataSet = cls.LoadItemPedido(ViewState("IDItemPedido"), ViewState(VW_IDPEDIDO))
                txtPrecoUnitario.Text = FormatNumber(ds.Tables(0).Rows(0).Item("ValorUnitario"), 2)

            ElseIf e.CommandName = "ExcluirItem" Then
                If cls.DeleteItemPedido(ViewState("IDItemPedido"), ViewState(VW_IDPEDIDO)) Then
                    Response.Redirect("Pedido.aspx?IDPedido=" & ViewState(VW_IDPEDIDO))
                End If

            ElseIf e.CommandName = "CancelarPedido" Then
                cls.Delete() 'Passa o status do pedido p/ "Apagado" e retorna os itens para o estoque do vendedor
                Response.Redirect("Pedido.aspx?IDPedido=" & ViewState(VW_IDPEDIDO))

            End If

        End Sub


        Protected Sub btnAlterar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterar.Click
            Message = cls.Update(cboIDCondicao.SelectedValue, cboIDFormaPagamento.SelectedValue)
            If Message = "" Then
                ltrMsgBox.Text = "<script type='text/javascript'>alert('Pedido alterado com sucesso!');</script>"
            Else
                ltrMsgBox.Text = "<script type='text/javascript'>alert('" & Message & "');</script>"
            End If
            cls.Load(ViewState(VW_IDPEDIDO))
            Inflate()
        End Sub


        Protected Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SecaoAtual, ACAO_APAGAR) Then
                Message = cls.Delete()
                If Message = "" Then
                    ltrMsgBox.Text = "<script type='text/javascript'>alert('Pedido apagado com sucesso!');</script>"
                Else
                    ltrMsgBox.Text = "<script type='text/javascript'>alert('" & Message & "');</script>"
                End If
                Response.Redirect("Pedido.aspx?IDPedido=" & ViewState(VW_IDPEDIDO))
            End If
        End Sub


        Protected Sub btnGravarItemPedido_ServerClick(sender As Object, e As System.EventArgs) Handles btnGravarItemPedido.ServerClick

            If cls.SalvarItemPedido(ViewState("IDItemPedido"), ViewState(VW_IDPEDIDO), txtPrecoUnitario.Text) Then
                Response.Redirect("Pedido.aspx?IDPedido=" & ViewState(VW_IDPEDIDO))
            End If

        End Sub


    End Class

End Namespace


