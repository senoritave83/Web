Imports Classes

Namespace Pages.Cadastros

    Partial Public Class PedidoEstoqueVendedor
        Inherits XMWebPage
		
        Dim cls As clsPedidoEstoqueVendedor
        Protected Const VW_IDPEDIDOESTOQUEVENDEDOR As String = "IDPedidoEstoqueVendedor"
        Protected Const VW_IDRESPONSAVEL As String = "IdUsuarioResponsavel"
        Protected Const ACAO_CANCELAR As String = "Cancelar Movimentação"
        Protected Const ACAO_FINALIZA As String = "Finalizar Movimentação"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsPedidoEstoqueVendedor()
            If Not Page.IsPostBack Then

                subAddConfirm(btnCancelar, "Deseja realmente cancelar esta movimentação de estoque?")
                subAddConfirm(btnFinalizar, "Deseja realmente finalizar esta movimentação de estoque?")

                ViewState(VW_IDPEDIDOESTOQUEVENDEDOR) = CInt("0" & Request("idpev"))

                btnGravar.Visible = IIf(cls.IsNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnCancelar.Visible = IIf(cls.IsNew(), False, VerificaPermissao(SecaoAtual, ACAO_CANCELAR))
                btnFinalizar.Visible = IIf(cls.IsNew(), False, VerificaPermissao(SecaoAtual, ACAO_FINALIZA))
                btnNovo.Visible = VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)

                'Bind Combos
                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("Selecione...", 0))

                Dim clsCat As New clsCategoria
                drpCategoria.DataSource = clsCat.Listar()
                drpCategoria.DataBind()
                drpCategoria.Items.Insert(0, New ListItem("Selecione uma categoria...", "0"))
                clsCat = Nothing

                CarregaDados()

            Else

                cls.Load(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))

            End If

        End Sub

        Protected Sub CarregaDados()

            cls.Load(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
            Inflate()

        End Sub

        Protected Sub Inflate()

            setComboValue(cboTipoPedido, cls.TipoPedido)
            setComboValue(cboIDVendedor, cls.IDVendedor)

            If cls.IDPedidoEstoqueVendedor = 0 Then

                DataCriado.Text = cls.Data
                ViewState(VW_IDRESPONSAVEL) = Me.User.IDUser
                lblUsuario.Text = Me.User.Name
                lblStatus.Text = "Novo"

                btnGravar.Visible = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnFinalizar.Visible = False
                btnImprimir.Visible = False
                btnCancelar.Visible = False
                pnlProdutos.Visible = False

            Else

                DataCriado.Text = cls.Data
                ViewState(VW_IDRESPONSAVEL) = cls.IDUsuario
                lblUsuario.Text = cls.Usuario
                lblStatus.Text = cls.Status

                BindItens()

                btnGravar.Visible = False
                btnCancelar.Visible = VerificaPermissao(SecaoAtual, ACAO_CANCELAR) And cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.EmAberto
                btnFinalizar.Visible = VerificaPermissao(SecaoAtual, ACAO_FINALIZA) And grdItens.Rows.Count > 0 And cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.EmAberto
                btnImprimir.Visible = cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.Finalizado
                pnlProdutos.Visible = True

                If cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.Cancelada Or cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.Finalizado Then
                    divAdicionarProduto.Visible = False
                ElseIf cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.EmAberto Then
                    divAdicionarProduto.Visible = True
                    btnAdicionarProduto.Visible = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                End If

                If cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.Novo Then
                    cboTipoPedido.Enabled = True
                    cboIDVendedor.Enabled = True
                Else
                    cboTipoPedido.Enabled = False
                    cboIDVendedor.Enabled = False
                End If

                divGridItens.Visible = grdItens.Rows.Count > 0

            End If

        End Sub

        Protected Sub Deflate()

            cls.TipoPedido = getComboValues(cboTipoPedido)
            cls.IDVendedor = cboIDVendedor.SelectedValue
            cls.Data = DataCriado.Text
            cls.IDUsuario = ViewState(VW_IDRESPONSAVEL)

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
            If (cls.IsNew() And VerificaPermissao(SecaoAtual, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SecaoAtual, ACAO_EDITAR) = False) Then
                Exit Sub
            End If
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/pedidoestoquevendedor.aspx?idpev=" & cls.IDPedidoEstoqueVendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub BindItens()

            If cls.IdStatus = clsPedidoEstoqueVendedor.STATUS_MOVIMENTACAO.EmAberto Then
                grdItens.Columns(5).Visible = True
                grdItens.Columns(4).HeaderText = "Previsão"
            Else
                grdItens.Columns(5).Visible = False
                grdItens.Columns(4).HeaderText = "Total Vendedor"
            End If

            grdItens.DataSource = cls.Itens.ListarItens(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
            grdItens.DataBind()

        End Sub

        Protected Sub btnFinalizar_Click(sender As Object, e As System.EventArgs) Handles btnFinalizar.Click
            If grdItens.Rows.Count > 0 Then
                cls.Itens.FinalizarMovimentacao(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
                CarregaDados()
                drpCategoria.ClearSelection()
                divMovItens.Visible = False
            End If
        End Sub

        Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
            cls.Itens.CancelarMovimentacao(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
            CarregaDados()
            drpCategoria.ClearSelection()
            divMovItens.Visible = False
            Response.Redirect("pedidoestoquevendedores.aspx")
        End Sub

        Protected Sub grdItens_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdItens.RowCommand

            If e.CommandName = "ExcluirItem" Then

                cls.Itens.RemoverItem(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR), e.CommandArgument)
                CarregaDados()
                drpCategoria.ClearSelection()
                divMovItens.Visible = False
            End If

        End Sub

        Protected Sub drpCategoria_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpCategoria.SelectedIndexChanged

            Dim cls As New clsProduto
            grdProdutos.DataSource = cls.ListaProdutoCategoriaSemMovimentacao(drpCategoria.SelectedValue, ViewState(VW_IDPEDIDOESTOQUEVENDEDOR))
            grdProdutos.DataBind()

            divMovItens.Visible = drpCategoria.SelectedValue <> 0 And grdProdutos.Rows.Count > 0 'Exibe a div se o usuário escolheu uma categoria que possui produtos
            lblCategoria.Text = "Categoria: " + drpCategoria.SelectedItem.Text.ToUpper

        End Sub

        Protected Sub btnAdicionarProduto_Click(sender As Object, e As System.EventArgs) Handles btnAdicionarProduto.Click

            For Each row As GridViewRow In grdProdutos.Rows

                If row.RowType = DataControlRowType.DataRow Then
                    Dim IdProd As HiddenField = row.FindControl("hidIdProduto")
                    Dim txt As TextBox = row.FindControl("txtQuantidade")
                    Dim strIdProduto As String, strQuant As String = ""
                    If Not IdProd Is Nothing Then
                        strIdProduto = IdProd.Value
                    End If
                    If Not txt Is Nothing Then
                        strQuant = txt.Text
                    End If

                    'É permitido adicionar o item à movimentação se o ID do produto for diferente de vazio, se a qtde for maior que 0 e se o textbox estiver habilitado.
                    If strIdProduto <> "" And strQuant > "0" And txt.Enabled Then
                        cls.Itens.AdicionarItem(ViewState(VW_IDPEDIDOESTOQUEVENDEDOR), strIdProduto, strQuant)
                        txt.Enabled = False
                    End If

                End If

            Next

            CarregaDados()
            BindItens()

        End Sub

    End Class

End Namespace

