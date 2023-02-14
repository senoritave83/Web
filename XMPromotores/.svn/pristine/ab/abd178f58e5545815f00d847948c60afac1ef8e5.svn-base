
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produto
        Inherits XMWebEditPage

        Dim cls As clsProduto
        Protected Const VW_IDPRODUTO As String = "IDProduto"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsProduto()
            If Not Page.IsPostBack Then

                Dim clsCat As clsCategoria
                clsCat = New clsCategoria
                cboIdCategoria.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
                cboIdCategoria.DataBind()
                cboIdCategoria.Items.Insert(0, New ListItem("Selecione o Segmento...", "0"))
                clsCat = Nothing

                cboIDSubCategoria.Items.Clear()
                cboIDSubCategoria.Items.Insert(0, New ListItem("Selecione a Categoria...", "0"))

                Dim clsFor As clsFornecedor
                clsFor = New clsFornecedor
                cboIDFornecedor.DataSource = clsFor.Listar(DataClass.enReturnType.DataReader)
                cboIDFornecedor.DataBind()
                cboIDFornecedor.Items.Insert(0, New ListItem(SettingsExpression.GetProperty("Selecione", "Fornecedor", "Selecione o fornecedor..."), "0"))
                clsFor = Nothing

                subAddConfirm(btnApagar, "Deseja realmente apagar esta produto?")

                reqSegmento.ErrorMessage = SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem5", "Segmento &eacute; um campo obrigat&oacute;rio!")
                reqCategoria.ErrorMessage = SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem5", "Categoria &eacute; um campo obrigat&oacute;rio!")
                reqFornecedor.ErrorMessage = SettingsExpression.GetProperty("texto", "Fornecedor.Mensagens.Mensagem5", "Fornecedor &eacute; um campo obrigat&oacute;rio!")

                compSegmento.ErrorMessage = SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem5", "Segmento &eacute; um campo obrigat&oacute;rio!")
                compCategoria.ErrorMessage = SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem5", "Categoria &eacute; um campo obrigat&oacute;rio!")
                compFornecedor.ErrorMessage = SettingsExpression.GetProperty("texto", "Fornecedor.Mensagens.Mensagem5", "Fornecedor &eacute; um campo obrigat&oacute;rio!")

                ViewState(VW_IDPRODUTO) = CInt("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDPRODUTO))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                PrecoPorEstado.Visible = IIf(SettingsExpression.GetProperty("PrecoPorEstado", "Produto", "True") = "True", True, False)

                Inflate()

            Else
                cls.Load(ViewState(VW_IDPRODUTO))

            End If
        End Sub

        Private Sub bindSubcategorias(ByVal p_IdCategoria As Integer)

            Dim clsSubCat As clsSubCategoria
            clsSubCat = New clsSubCategoria
            cboIDSubCategoria.DataSource = clsSubCat.Listar(p_IdCategoria, DataClass.enReturnType.DataReader)
            cboIDSubCategoria.DataBind()
            cboIDSubCategoria.Items.Insert(0, New ListItem("Selecione a Categoria...", "0"))
            clsSubCat = Nothing

        End Sub

        Protected Sub Inflate()

            txtCodigo.Text = cls.Codigo
            Me.PageName = cls.Codigo
            txtDescricao.Text = cls.Descricao
            txtDescricaoResumida.Text = cls.DescricaoResumida
            SetComboValue(cboIdCategoria, cls.IDCategoria)
            If cls.IDCategoria > 0 Then
                bindSubcategorias(cls.IDCategoria)
            End If
            SetComboValue(cboIDSubCategoria, cls.IDSubCategoria)
            SetComboValue(cboIDFornecedor, cls.IDFornecedor)
            lblCriado.Text = cls.Criado
            If cls.PrecoMinimo = 0 Then
                txtPrecoMinimo.Text = ""
            Else
                txtPrecoMinimo.Text = FormatNumber(cls.PrecoMinimo, 2)
            End If
            If cls.PrecoMaximo = 0 Then
                txtPrecoMaximo.Text = ""
            Else
                txtPrecoMaximo.Text = FormatNumber(cls.PrecoMaximo, 2)
            End If
            If cls.PrecoSugerido = 0 Then
                txtPrecoSugerido.Text = ""
            Else
                txtPrecoSugerido.Text = FormatNumber(cls.PrecoSugerido, 2)
            End If

            txtCodigoBarras.Text = cls.CodigoBarras

            setComboValue(rdStatusComercio, cls.StatusComercio)
            setComboValue(rdStatusPesquisa, cls.StatusPesquisa)

            With CamposAdicionais1
                .Entidade = "Produto"
                .CarregaDados(cls.IDProduto)
                .Visible = True
            End With

            PrecoProduto1.IdProduto = cls.IDProduto

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Produto, cls.IDProduto)

        End Sub

        Protected Sub Deflate()

            cls.Codigo = txtCodigo.Text
            cls.Descricao = txtDescricao.Text
            cls.DescricaoResumida = txtDescricaoResumida.Text
            cls.IDSubCategoria = cboIDSubCategoria.SelectedValue
            cls.IDFornecedor = cboIDFornecedor.SelectedValue
            cls.CodigoBarras = txtCodigoBarras.Text

            If txtPrecoMinimo.Text = "" Then
                cls.PrecoMinimo = 0
            Else
                cls.PrecoMinimo = txtPrecoMinimo.Text
            End If
            If txtPrecoMaximo.Text = "" Then
                cls.PrecoMaximo = 0
            Else
                cls.PrecoMaximo = txtPrecoMaximo.Text
            End If
            If txtPrecoSugerido.Text = "" Then
                cls.PrecoSugerido = 0
            Else
                cls.PrecoSugerido = txtPrecoSugerido.Text
            End If

            cls.StatusComercio = rdStatusComercio.SelectedItem.Value
            cls.StatusPesquisa = rdStatusPesquisa.SelectedItem.Value

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()                

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Produto, cls.IDProduto)

                With CamposAdicionais1
                    .Entidade = "Produto"
                    .GravarDados(cls.IDProduto)
                End With
                Inflate()
                MostraGravado("~/cadastros/Produto.aspx?idproduto=" & cls.idproduto)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Produto, cls.IDProduto)

                cls.Delete()
                Response.Redirect("Produtos.aspx")
            End If
        End Sub

        Protected Sub cboIdCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdCategoria.SelectedIndexChanged
            bindSubcategorias(cboIdCategoria.SelectedItem.Value)
        End Sub

        Protected Sub rdStatusComercio_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdStatusComercio.SelectedIndexChanged

            If rdStatusComercio.SelectedItem.Value = 0 Then
                setComboValue(rdStatusPesquisa, "0")
            End If

        End Sub
    End Class

End Namespace

