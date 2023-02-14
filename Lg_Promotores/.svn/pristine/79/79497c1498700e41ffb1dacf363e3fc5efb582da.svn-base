
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Pergunta
        Inherits XMWebPage
        Dim cls As clsPergunta
        Protected Const VW_IDPERGUNTA As String = "IDPergunta"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPergunta()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta pergunta?")
                ViewState(VW_IDPERGUNTA) = Cint("0" & Request("IDPergunta"))
                cls.Load(ViewState(VW_IDPERGUNTA))

                VerifyPermissions()

                BindCategoria()
                BindSubCategoria()
                BindProduto()
                BindClientes()
                BindRegiao()
                BindEstados()
                BindTipoLoja()
                BindLojas()

                Inflate()

            Else

                cls.Load(ViewState(VW_IDPERGUNTA))

            End If

        End Sub

#Region "Segmentacao por loja"


        Protected Sub BindClientes()
            Dim cli As New clsCliente
            cboIDCliente.DataSource = cli.Listar()
            cboIDCliente.DataBind()
            cboIDCliente.Items.Insert(0, New ListItem("Todas", "0"))
        End Sub

        Protected Sub BindLojas()
            cboIDLoja.Items.Clear()
            Dim loj As New clsLoja
            cboIDLoja.DataSource = loj.Listar(cboIDCliente.SelectedValue, cboIDRegiao.SelectedValue, cboIDTipoLoja.SelectedValue, cboUF.SelectedValue, txtCidade.Text, DataClass.enReturnType.DataReader)
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


        Protected Sub cboIDCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCliente.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub BindGridSegmentos()
            pnlLojas.Visible = cls.IDPergunta > 0
            grdLojas.DataSource = cls.Listarlojas(tdTipoBuscaLoja.SelectedItem.Value, txtBuscaLoja.Text)
            grdLojas.DataBind()
        End Sub

        Protected Sub btnAdicionarSegmento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarSegmento.Click
            cls.AdicionarLoja(cboUF.SelectedValue, txtCidade.Text, cboIDCliente.SelectedValue, cboIDLoja.SelectedValue, cboIDRegiao.SelectedValue, cboIDTipoLoja.SelectedValue)
            BindGridSegmentos()
        End Sub


        Protected Sub grdLojas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLojas.RowCommand
            If e.CommandName = "RetirarLoja" Then
                cls.RetirarLoja(grdLojas.DataKeys(e.CommandArgument).Value)
                BindGridSegmentos()
            End If

        End Sub

#End Region

#Region "Segmentacao por produto"


        Protected Sub cboConcorrente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConcorrente.SelectedIndexChanged
            BindProduto()
        End Sub

        Protected Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
            BindSubCategoria()
            BindProduto()
        End Sub

        Protected Sub cboSubCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCategoria.SelectedIndexChanged
            BindProduto()
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
            If cboConcorrente.SelectedValue = 0 Then
                cboProduto.DataSource = prd.Listar(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            Else
                Dim blnConcorrente As Boolean
                blnConcorrente = (cboConcorrente.SelectedValue <> "1")
                cboProduto.DataSource = prd.Listar(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, blnConcorrente, DataClass.enReturnType.DataReader)
            End If
            cboProduto.DataBind()
            cboProduto.Items.Insert(0, New ListItem("TODOS", "0"))
        End Sub

        Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
            cls.AdicionarProdutos(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, cboProduto.SelectedValue, cboConcorrente.SelectedValue)
            BindGridProdutos()
        End Sub

        Protected Sub grdSegmentacao_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdSegmentacao.RowCommand
            If e.CommandName = "RetirarProduto" Then
                cls.RetirarProdutos(grdSegmentacao.DataKeys(e.CommandArgument).Value)
                BindGridProdutos()
            End If
        End Sub

        Protected Sub BindGridProdutos()
            pnlSegmentacao.Visible = cls.IDPergunta > 0
            grdSegmentacao.DataSource = cls.ListarSegmentacao(rdTipoBusCaProduto.SelectedItem.Value, txtBuscaProduto.Text)
            grdSegmentacao.DataBind()
        End Sub

#End Region

        Protected Sub VerifyPermissions()

            btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
            If btnGravar.Enabled = False Then

                'PAINEL - Pergunta cadastrada
                btnAdicionarSegmento.Enabled = False
                btnAddSegmentacao.Enabled = False
                txtPergunta.ReadOnly = True
                txtPerguntaRelatorio.ReadOnly = True
                txtPrioridade.ReadOnly = True
                cboTipoCampo.Enabled = False
                txtMinimo.ReadOnly = True
                txtMaximo.ReadOnly = True
                cboPerguntaLoja.Enabled = False
                chkAtivo.Enabled = False

                'PAINEL - Exibir a pergunta para a seguinte segmentação:
                rdTipoBusCaProduto.Enabled = False
                txtBuscaProduto.ReadOnly = True
                btnBuscarProdutos.Enabled = False
                grdSegmentacao.Columns(4).Visible = False
                cboCategoria.Enabled = False
                cboProduto.Enabled = False
                cboSubCategoria.Enabled = False
                cboConcorrente.Enabled = False

                'PAINEL - Exibir a pergunta para os seguintes critérios de lojas:
                tdTipoBuscaLoja.Enabled = False
                txtBuscaLoja.ReadOnly = True
                btnBuscaLoja.Enabled = False
                grdLojas.Columns(6).Visible = False
                cboUF.Enabled = False
                txtCidade.ReadOnly = True
                cboIDCliente.Enabled = False
                cboIDRegiao.Enabled = False
                cboIDTipoLoja.Enabled = False
                cboIDLoja.Enabled = False

            End If

            btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
            btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

        End Sub

        Protected Sub Inflate()

            txtPergunta.Text = cls.Pergunta
            txtPerguntaRelatorio.Text = cls.DescricaoRelatorio
            txtPrioridade.Text = IIf(ViewState(VW_IDPERGUNTA) = "0", 100, cls.Prioridade)
            Me.PageName = cls.Pergunta
            cboMultiResposta.SelectedIndex = IIf(cls.MultiResposta, 1, 0)
            cboPerguntaLoja.SelectedIndex = IIf(cls.PerguntaLoja, 1, 0)
            chkAtivo.Checked = cls.Ativo
            setComboValue(cboTipoCampo, cls.TipoCampo)
            txtMinimo.Text = IIf(cls.Minimo = 0, "", cls.Minimo)
            txtMaximo.Text = IIf(cls.Maximo = 0, "", cls.Maximo)
            grdRespostas.DataSource = cls.ListarRespostas()
            grdRespostas.DataBind()

            BindGridSegmentos()
            BindGridProdutos()
            'cboTipo.ClearSelection()
            'Dim op As ListItem = cboTipo.Items.FindByValue(cls.TipoCampo)
            'If Not op Is Nothing Then op.Selected = True

        End Sub

        Protected Sub Deflate()
            cls.Pergunta = txtPergunta.Text
            cls.DescricaoRelatorio = txtPerguntaRelatorio.Text
            cls.Prioridade = txtPrioridade.Text
            cls.MultiResposta = (cboMultiResposta.SelectedIndex = 1)
            cls.PerguntaLoja = (cboPerguntaLoja.SelectedIndex = 1)
            cls.Ativo = chkAtivo.Checked
            cls.TipoCampo = cboTipoCampo.SelectedValue
            cls.Minimo = IIf(txtMinimo.Text = "", 0, txtMinimo.Text)
            cls.Maximo = IIf(txtMaximo.Text = "", 0, txtMaximo.Text)
            cls.Respostas.Clear()
            Dim intIndex As Integer = 1
            Dim row As GridViewRow
            For Each row In grdRespostas.Rows
                If row.RowType = DataControlRowType.DataRow Then
                    Dim txt As TextBox
                    txt = CType(row.FindControl("txtResposta"), TextBox)
                    If txt.Text <> "" Then cls.Respostas.Add(txt.Text, ("" & Request("RespostaUnica") = CStr(intIndex)))
                    intIndex += 1
                End If
            Next
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Pergunta.aspx?idpergunta=" & cls.idpergunta)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()
        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Perguntas.aspx")
        End Sub

        Protected Sub btnBuscaLoja_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscaLoja.Click
            BindGridSegmentos()
        End Sub

        Protected Sub btnBuscarProdutos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscarProdutos.Click
            BindGridProdutos()
        End Sub

        Protected Sub drpBuscaMarca_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpBuscaMarca.SelectedIndexChanged

            txtBuscaProduto.Text = drpBuscaMarca.SelectedItem.Value

        End Sub

        Protected Sub rdTipoBusCaProduto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTipoBusCaProduto.SelectedIndexChanged

            If rdTipoBusCaProduto.SelectedItem.Value = "Marca" Then
                txtBuscaProduto.Visible = False
                drpBuscaMarca.Visible = True
                txtBuscaProduto.Text = drpBuscaMarca.SelectedItem.Value
            Else
                txtBuscaProduto.Visible = True
                drpBuscaMarca.Visible = False
                txtBuscaProduto.Text = ""
            End If

        End Sub

        Protected Sub cboIDRegiao_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDRegiao.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub cboIDTipoLoja_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDTipoLoja.SelectedIndexChanged
            BindLojas()
        End Sub

        Protected Sub cboUF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboUF.SelectedIndexChanged
            BindLojas()
        End Sub

    End Class

End Namespace

