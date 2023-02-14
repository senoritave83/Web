
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Promotor
        Inherits XMWebPage
        Dim cls As clsPromotor
        Protected Const VW_IDPROMOTOR As String = "IDPromotor"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPromotor()
            If Not Page.IsPostBack Then
                'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta promotor?")
                ViewState(VW_IDPROMOTOR) = CInt("0" & Request("IDPromotor"))
                cls.Load(ViewState(VW_IDPROMOTOR))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Dim usu As New clsUsuario()
                drpIdUsuario.DataSource = usu.Listar(TipoPermissao.PROMOTOR, DataClass.enReturnType.DataReader)
                drpIdUsuario.DataBind()
                drpIdUsuario.Items.Insert(0, New ListItem("Selecione o usuário", "0"))
                usu = Nothing

                BindCategoria()
                BindSubCategoria()
                BindProduto()
                BindLideres()
                BindRegioes()
                bindEstados()

                MensagensErroPersonalizadas()
                Inflate()

            Else
                cls.Load(ViewState(VW_IDPROMOTOR))

            End If

        End Sub

        Private Sub MensagensErroPersonalizadas()
            reqValidacaolider.ErrorMessage = SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider") & " é um campo obrigatório!"
            compValidacaoLider.ErrorMessage = SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider") & "inválido"
        End Sub

        Protected Sub bindEstados()

            Dim clsEst As clsEstado
            clsEst = New clsEstado
            cboUF.DataSource = clsEst.Listar(DataClass.enReturnType.DataReader)
            cboUF.DataBind()
            cboUF.Items.Insert(0, New ListItem("Selecione a UF...", 0))
            clsEst = Nothing

        End Sub

        Protected Sub BindGridProdutos()
            grdProdutos.DataSource = cls.ListarProdutos()
            grdProdutos.DataBind()
        End Sub


        Protected Sub btnAddSegmentacao_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSegmentacao.Click
            cls.AdicionarProdutos(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, cboProduto.SelectedValue)
            BindGridProdutos()
        End Sub

        Protected Sub grdProdutos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProdutos.RowCommand
            If e.CommandName = "RetirarProduto" Then
                cls.RetirarProdutos(grdProdutos.DataKeys(e.CommandArgument).Value)
                BindGridProdutos()
            End If
        End Sub

        Protected Sub cboCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedIndexChanged
            BindSubCategoria()
            BindProduto()
        End Sub

        Protected Sub cboSubCategoria_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSubCategoria.SelectedIndexChanged
            BindProduto()
        End Sub

        Protected Sub BindRegioes()

            Dim reg As New clsRegiao()
            drpIdRegiao.DataSource = reg.Listar(DataClass.enReturnType.DataReader)
            drpIdRegiao.DataBind()
            drpIdRegiao.Items.Insert(0, New ListItem("Selecione a região", "0"))
            reg = Nothing

        End Sub

        Protected Sub BindLideres()

            Dim lid As New clsLider()
            drpIdLider.DataSource = lid.Listar(DataClass.enReturnType.DataReader)
            drpIdLider.DataBind()
            drpIdLider.Items.Insert(0, New ListItem("Selecione o " & SettingsExpression.GetProperty("caption", "Promotor.FiltroLider", "Lider"), "0"))
            lid = Nothing

        End Sub

        Protected Sub BindCategoria()
            Dim cat As New clsCategoria()
            cboCategoria.DataSource = cat.Listar(DataClass.enReturnType.DataReader)
            cboCategoria.DataBind()
            cboCategoria.Items.Insert(0, New ListItem("TODOS", "0"))
            cat = Nothing
        End Sub

        Protected Sub BindSubCategoria()
            Dim sct As New clsSubCategoria()
            cboSubCategoria.DataSource = sct.Listar(cboCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            cboSubCategoria.DataBind()
            cboSubCategoria.Items.Insert(0, New ListItem("TODAS", "0"))
            sct = Nothing
        End Sub

        Protected Sub BindProduto()

            Dim prd As New clsProduto()
            cboProduto.DataSource = prd.Listar(cboCategoria.SelectedValue, cboSubCategoria.SelectedValue, DataClass.enReturnType.DataReader)
            cboProduto.DataBind()
            cboProduto.Items.Insert(0, New ListItem("TODOS", "0"))
            prd = Nothing

        End Sub

        Protected Sub Inflate()

            txtPromotor.Text = cls.Promotor
            Me.PageName = cls.Promotor
            txtLogin.Text = cls.Login
            txtSenha.Text = cls.Senha
            txtEndereco.Text = cls.Endereco
            txtCidade.Text = cls.Cidade
            setComboValue(cboUF, cls.UF)
            txtCPF.Text = cls.CPF

            If cls.IDPromotor > 0 Then
                txtSenha.Visible = False
                btnNovaSenha.Visible = True
            Else
                txtSenha.Visible = True
                btnNovaSenha.Visible = False
            End If
            lblSenha.Text = cls.Senha
            txtCodigo.Text = cls.Codigo
            txtNumero.Text = cls.Numero
            txtComplemento.Text = cls.Complemento
            txtBairro.Text = cls.Bairro
            txtCep.Text = cls.Cep
            txtContato.Text = cls.Contato
            txtTelefone.Text = cls.Telefone
            txtCelular.Text = cls.Celular
            txtFax.Text = cls.Fax
            txtEmail.Text = cls.Email
            txtCargo.Text = cls.Cargo
            txtEmpresa.Text = cls.Empresa
            chkTeste.Checked = cls.Teste
            setComboValue(drpIdLider, cls.IDLider)
            setComboValue(drpIdRegiao, cls.IDRegiao)
            setComboValue(IdStatus, cls.IdStatus)
            ImageUploaderPromo.Imagem = cls.Foto
            txtSegmento.Text = cls.Segmento

            If SettingsExpression.GetProperty("visualiza", "Promotor.UsuarioWeb", False) = True Then

                chkAcessoWeb.Checked = cls.AcessoWeb
                setComboValue(drpIdUsuario, cls.IdUsuario)
                trUsuarioAcessoWeb.Visible = chkAcessoWeb.Checked
                drpIdUsuario.Visible = chkAcessoWeb.Checked

            End If

            With CamposAdicionais1
                .Entidade = "Promotor"
                .CarregaDados(cls.IDPromotor)
                .Visible = True
            End With

            BindGridProdutos()

        End Sub

        Protected Sub Deflate()

            cls.Promotor = txtPromotor.Text
            cls.Login = txtLogin.Text
            cls.Senha = txtSenha.Text
            cls.Endereco = txtEndereco.Text
            cls.Cidade = txtCidade.Text
            cls.UF = cboUF.SelectedValue
            cls.CPF = txtCPF.Text

            cls.Codigo = txtCodigo.Text
            cls.Numero = txtNumero.Text
            cls.Complemento = txtComplemento.Text
            cls.Bairro = txtBairro.Text
            cls.Cep = txtCep.Text
            cls.Contato = txtContato.Text
            cls.Telefone = txtTelefone.Text
            cls.Celular = txtCelular.Text
            cls.Fax = txtFax.Text
            cls.Email = txtEmail.Text
            cls.Cargo = txtCargo.Text
            cls.Empresa = txtEmpresa.Text
            cls.Teste = chkTeste.Checked
            cls.IDLider = getComboValues(drpIdLider)
            cls.IDRegiao = getComboValues(drpIdRegiao)

            cls.IdStatus = getComboValue(IdStatus)
            cls.Foto = ImageUploaderPromo.Imagem

            cls.AcessoWeb = IIf(chkAcessoWeb.Checked, 1, 0)
            cls.IdUsuario = getComboValue(drpIdUsuario)

        End Sub

        Protected Function GetLojasRoteiro(ByVal vIDRoteiro As Integer) As Object
            Dim rot As New clsRoteiro
            Return rot.ListarLojas(cls.IDPromotor, vIDRoteiro)
        End Function

        Protected Sub chkAcessoWeb_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAcessoWeb.CheckedChanged

            trUsuarioAcessoWeb.Visible = chkAcessoWeb.Checked
            setComboValue(drpIdUsuario, 0)

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid And Page.IsValid Then
                cls.Update()
                Inflate()
                If Not ImageUploaderPromo.ShowSaveButton And ImageUploaderPromo.HasPostedFile Then
                    ImageUploaderPromo.Gravar()
                End If
                With CamposAdicionais1
                    .Entidade = "Promotor"
                    .GravarDados(cls.IDPromotor)
                End With
                MostraGravado("~/cadastros/Promotor.aspx?idpromotor=" & cls.IDPromotor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Promotores.aspx")
        End Sub

        Protected Sub btnVerRoteiros_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVerRoteiros.Click
            Response.Redirect("Promotor_Roteiro.aspx?idpromotor=" & cls.IDPromotor & "&tp=" & XMCrypto.Encrypt("1"))
        End Sub

        Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
            txtSenha.Visible = True
            btnNovaSenha.Visible = False
            lblSenha.Visible = False
        End Sub

        Protected Sub ImageUploaderPromo_onSavingFile(ByRef filename As String) Handles ImageUploaderPromo.onSavingFile
            filename = Guid.NewGuid.ToString() & IO.Path.GetExtension(filename)
        End Sub
    End Class

End Namespace

