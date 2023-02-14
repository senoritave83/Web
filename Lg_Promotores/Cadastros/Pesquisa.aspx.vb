
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Pesquisa
        Inherits XMWebPage
        Dim cls As clsPesquisa
        Protected Const VW_IDPESQUISA As String = "IDPesquisa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPesquisa()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta pesquisa?")
                ViewState(VW_IDPESQUISA) = Cint("0" & Request("IDPesquisa"))
                cls.Load(ViewState(VW_IDPESQUISA))

                VerifyPermissions()
                'btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                'btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                'btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))
                BindCategoria()
                BindSubCategoria()
                BindProduto()
                BindRegiao()
                BindEstados()
                BindTipoLoja()
                BindClientes()
                BindLojas()
                BindPerguntas()

                Inflate()
            Else
                cls.Load(ViewState(VW_IDPESQUISA))
          End If
        End Sub

        Protected Sub BindClientes()
            Dim cli As New clsCliente
            cboIDCliente.DataSource = cli.Listar()
            cboIDCliente.DataBind()
            cboIDCliente.Items.Insert(0, New ListItem("Todas", "0"))
        End Sub

        Protected Sub BindLojas()

            Dim loj As New clsLoja

            cboIDLoja.Items.Clear()
            cboIDLoja.DataSource = loj.Listar(cboIDCliente.SelectedItem.Value, cboIDRegiao.SelectedItem.Value, cboIDTipoLoja.SelectedItem.Value, cboUF.SelectedItem.Value, txtCidade.Text)
            cboIDLoja.DataBind()
            cboIDLoja.Items.Insert(0, New ListItem("Todas", "0"))

        End Sub

        Protected Sub BindRegiao()
            Dim reg As New clsRegiao
            cboIDRegiao.DataSource = reg.Listar()
            cboIDRegiao.DataBind()
            cboIDRegiao.Items.Insert(0, New ListItem("Todas", "0"))

        End Sub

        Protected Sub BindEstados()
            Dim est As New clsEstado
            cboUF.DataSource = est.Listar()
            cboUF.DataBind()
            cboUF.Items.Insert(0, New ListItem("Todos", ""))
        End Sub

        Protected Sub BindTipoLoja()
            Dim tip As New clsTipoLoja
            cboIDTipoLoja.DataSource = tip.Listar()
            cboIDTipoLoja.DataBind()
            cboIDTipoLoja.Items.Insert(0, New ListItem("Todos", "0"))
        End Sub


        Protected Sub BindCategoria()
            Dim cat As New clsCategoria()
            cboCategoria.DataSource = cat.Listar()
            cboCategoria.DataBind()
            cboCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
        End Sub

        Protected Sub BindSubCategoria()
            Dim sct As New clsSubCategoria()
            cboSubCategoria.DataSource = sct.Listar(cboCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            cboSubCategoria.DataBind()
            cboSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))
        End Sub

        Protected Sub BindProduto()

            Dim prd As New clsProduto()
            cboProduto.DataSource = prd.Listar(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, cls.Concorrente, DataClass.enReturnType.DataReader)
            cboProduto.DataBind()
            cboProduto.Items.Insert(0, New ListItem("TODOS", "0"))

        End Sub

        Protected Sub BindPerguntas()
            Dim per As New clsPergunta()
            cboPergunta.DataSource = per.Listar(cls.IDPesquisa)
            cboPergunta.DataBind()
        End Sub

        Protected Sub Inflate()
            txtPesquisa.Text = cls.Pesquisa
            Me.PageName = cls.Pesquisa
            setComboValue(cboConcorrente, cls.Concorrente)
            lblCriado.Text = cls.Criado
            Roteiro1.Dia = cls.Dia
            Roteiro1.DiaSemana = cls.DiaSemana
            Roteiro1.Mes = cls.Mes
            Roteiro1.SemanaMes = cls.SemanaMes
            chkAtivo.Checked = cls.Ativo
            chkEstoque.Checked = (cls.Acao And 1)
            chkPreco.Checked = (cls.Acao And 2)
            chkPerguntas.Checked = (cls.Acao And 4)
            BindGridProdutos()
            BindGridSegmentos()
            BindGridPerguntas()
            'cboConcorrente.Enabled = (cls.IDPesquisa = 0)
            phlOpcoes.Visible = (cls.IDPesquisa > 0)
        End Sub

        Protected Sub BindGridProdutos()
            grdProdutos.DataSource = cls.ListarProdutos(rdTipoBusCaProduto.SelectedItem.Value, txtBuscaProduto.Text)
            grdProdutos.DataBind()
        End Sub

        Protected Sub BindGridPerguntas()
            grdPerguntas.DataSource = cls.ListarPerguntas(txtBuscaPergunta.Text)
            grdPerguntas.DataBind()
        End Sub

        Protected Sub Deflate()
            cls.Pesquisa = txtPesquisa.Text
            cls.Concorrente = cboConcorrente.SelectedValue
            cls.Dia = Roteiro1.Dia
            cls.DiaSemana = Roteiro1.DiaSemana
            cls.SemanaMes = Roteiro1.SemanaMes
            cls.Mes = Roteiro1.Mes
            cls.Ativo = chkAtivo.Checked
            cls.Acao = IIf(chkEstoque.Checked, 1, 0) + IIf(chkPreco.Checked, 2, 0) + IIf(chkPerguntas.Checked, 4, 0)
        End Sub

        Protected Sub VerifyPermissions()

            btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
            If btnGravar.Enabled = False Then

                'PAINEL - Pesquisa cadastrada
                btnAdicionarSegmento.Enabled = False
                btnAddSegmentacao.Enabled = False
                chkEstoque.Enabled = False
                chkPerguntas.Enabled = False
                chkPreco.Enabled = False
                chkAtivo.Enabled = False
                txtPesquisa.ReadOnly = True
                chkAtivo.Enabled = False

                'PAINEIS - Dia / Mês / Dia da Semana
                divRoteiro1.Disabled = True

                'PAINEL - Exibir a pergunta para a seguinte segmentação:
                rdTipoBusCaProduto.Enabled = False
                txtBuscaProduto.ReadOnly = True
                btnBuscarProdutos.Enabled = False
                grdProdutos.Columns(3).Visible = False
                cboCategoria.Enabled = False
                cboProduto.Enabled = False
                cboSubCategoria.Enabled = False
                cboConcorrente.Enabled = False

                'PAINEL - Exibir a pergunta para os seguintes critérios de lojas:
                tdTipoBuscaLoja.Enabled = False
                txtBuscaLoja.ReadOnly = True
                btnBuscaLoja.Enabled = False
                cboUF.Enabled = False
                txtCidade.ReadOnly = True
                grdSegmentos.Columns(6).Visible = False
                cboIDCliente.Enabled = False
                cboIDRegiao.Enabled = False
                cboIDTipoLoja.Enabled = False
                cboIDLoja.Enabled = False

            End If

            btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
            btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Pesquisa.aspx?idpesquisa=" & cls.IDPesquisa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Protected Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
            BindSubCategoria()
            BindProduto()
        End Sub

        Protected Sub cboSubCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCategoria.SelectedIndexChanged
            BindProduto()
        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Pesquisas.aspx")
        End Sub

        Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
            cls.AdicionarProdutos(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, cboProduto.SelectedValue)
            BindGridProdutos()
        End Sub

        Protected Sub BindGridSegmentos(Optional ByVal p_TipoBusca As Integer = 0, Optional ByVal p_Filtro As String = "")
            grdSegmentos.DataSource = cls.ListarSegmentos(tdTipoBuscaLoja.SelectedItem.Value, txtBuscaLoja.Text)
            grdSegmentos.DataBind()
        End Sub

        Protected Sub btnAdicionarSegmento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarSegmento.Click
            cls.AdicionarSegmento(cboUF.SelectedValue, txtCidade.Text, cboIDCliente.SelectedValue, cboIDLoja.SelectedValue, cboIDRegiao.SelectedValue, cboIDTipoLoja.SelectedValue)
            BindGridSegmentos()
        End Sub

        Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
            If e.CommandName = "RetirarProduto" Then
                cls.RetirarProdutos(grdProdutos.DataKeys(e.CommandArgument).Value)
                BindGridProdutos()
            End If
        End Sub

        Protected Sub grdSegmentos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSegmentos.RowCommand
            If e.CommandName = "RetirarSegmento" Then
                cls.RetirarSegmento(grdSegmentos.DataKeys(e.CommandArgument).Value)
                BindGridSegmentos()
            End If
        End Sub

        Protected Sub grdPerguntas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdPerguntas.RowCommand
            If e.CommandName = "RetirarPergunta" Then
                cls.RetirarPerguntas(grdPerguntas.DataKeys(e.CommandArgument).Value)
                BindGridPerguntas()
            End If
        End Sub

        Protected Sub btnBuscarProdutos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProdutos.Click
            BindGridProdutos()
        End Sub

        Protected Sub btnBuscaLoja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaLoja.Click
            BindGridSegmentos()
        End Sub


        Protected Sub cboUF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUF.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub cboIDCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCliente.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub cboIDTipoLoja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDTipoLoja.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub cboIDRegiao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDRegiao.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub btnAddPergunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddPergunta.Click
            cls.AdicionarPergunta(cboPergunta.SelectedValue)
            BindGridPerguntas()
        End Sub

        Protected Sub btnBuscaPergunta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaPergunta.Click
            BindGridPerguntas()
        End Sub
    End Class

End Namespace

