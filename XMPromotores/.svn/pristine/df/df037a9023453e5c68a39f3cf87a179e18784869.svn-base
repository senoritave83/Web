
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Usuario
        Inherits XMWebEditPage
        Dim cls As clsUsuario
        Protected Const VW_IDUSUARIO As String = "IDUsuario"
        Protected Const ACAO_DEFINIRADMINISTRADOR As String = "Definir como administrador"
        Protected Const ACAO_ALTERARPERMISSAO As String = "Alterar permissões"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsUsuario()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta usuario?")
                ViewState(VW_IDUSUARIO) = Cint("0" & Request("IDUsuario"))
                cls.Load(ViewState(VW_IDUSUARIO))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))

                chkAdministrador.Enabled = VerificaPermissao(SECAO, ACAO_DEFINIRADMINISTRADOR)
                Permissoes1.Visible = VerificaPermissao(Secao, ACAO_ALTERARPERMISSAO)

                If cls.Ativo = 0 Then
                    subAddConfirm(btnGravar, "Este usuário está inativo. Gravar os dados irá ativá-lo novamente. Deseja continuar?")
                    liAtivo.Visible = True
                Else
                    liAtivo.Visible = False
                End If

                Dim car As New clsCargo
                cboIDCargo.DataSource = car.Listar()
                cboIDCargo.DataBind()
                cboIDCargo.Items.Insert(0, New ListItem("Selecione...", "0"))
                car = Nothing

                bindEstados()

                Inflate()
            Else
                cls.Load(ViewState(VW_IDUSUARIO))
          End If
        End Sub


        Protected Sub bindEstados()

            Dim clsEst As clsEstado
            clsEst = New clsEstado
            cboUF.DataSource = clsEst.Listar(DataClass.enReturnType.DataReader)
            cboUF.DataBind()
            cboUF.Items.Insert(0, New ListItem("Selecione a UF...", 0))
            clsEst = Nothing

        End Sub

        Protected Sub BindSuperior()
            Dim car As New clsCargo
            car.Load(cboIDCargo.SelectedValue)
            If car.IsNew = False And car.IDSuperior > 0 Then
                Dim intIDTemp As Integer = CInt("0" & cboIDSuperior.SelectedValue)
                cboIDSuperior.Items.Clear()
                Dim dr As System.Data.IDataReader = cls.Listar(car.IDSuperior)
                cboIDSuperior.Items.Add(New ListItem("", "0"))
                Do While dr.Read
                    cboIDSuperior.Items.Add(New ListItem(dr.GetValue(dr.GetOrdinal(cboIDSuperior.DataTextField)), dr.GetValue(dr.GetOrdinal(cboIDSuperior.DataValueField))))
                Loop
                valReqSuperior.Enabled = True
                Dim sup As New clsCargo
                sup.Load(car.IDSuperior)
                ltrCargoSuperior.Text = sup.Cargo & ": "
                trSuperior.Visible = True
            Else
                valReqSuperior.Enabled = False
                trSuperior.Visible = False
            End If
        End Sub

        Protected Sub Inflate()
			txtUsuario.Text = cls.Usuario
			txtlogin.Text = cls.login
			If cls.IDUsuario > 0 Then
				txtSenha.Visible = False
                btnNovaSenha.Visible = True
                Permissoes1.Visible = True
			Else
				txtSenha.Visible = True
                btnNovaSenha.Visible = False
                Permissoes1.Visible = False
			End If
            chkAdministrador.Checked = cls.Administrador
            cboIDCargo.SelectedValue = cls.IDCargo

            BindSuperior()

            cboIDSuperior.SelectedValue = cls.IDSuperior
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If

            txtCPF.Text = cls.CPF
            txtObservacao.Text = cls.Observacao
            txtEmail.Text = cls.Email
            txtCodigo.Text = cls.Codigo
            txtEndereco.Text = cls.Endereco
            txtNumero.Text = cls.Numero
            txtComplemento.Text = cls.Complemento
            txtBairro.Text = cls.Bairro
            txtCep.Text = cls.Cep
            txtCidade.Text = cls.Cidade
            setComboValue(cboUF, cls.UF)
            txtContato.Text = cls.Contato
            txtTelefone.Text = cls.Telefone
            txtCelular.Text = cls.Celular
            txtFax.Text = cls.Fax
            chkTeste.Checked = (cls.Teste > 0)
            ImageUploaderUsuario.Imagem = cls.Foto
            cboAdicionarLoja.SelectedValue = cls.AdicionarLoja
            With CamposAdicionais1
                .Entidade = "Usuario"
                .CarregaDados(cls.IDUsuario)
                .Visible = True
            End With

            Permissoes1.IDCargo = cboIDCargo.SelectedValue



            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Usuario, cls.IDUsuario)

        End Sub

        Protected Sub Deflate()
			cls.Usuario = txtUsuario.Text
            cls.login = txtlogin.Text
            If txtSenha.Text <> "" Then cls.Senha = txtSenha.Text
            cls.Observacao = txtObservacao.Text
            cls.Email = txtEmail.Text
            cls.IDCargo = cboIDCargo.SelectedValue
            If cboIDSuperior.SelectedIndex > -1 Then
                cls.IDSuperior = CInt("0" & cboIDSuperior.SelectedValue)
            Else
                cls.IDSuperior = 0
            End If

            cls.Codigo = txtCodigo.Text
            cls.Numero = txtNumero.Text
            cls.CPF = txtCPF.Text
            cls.Complemento = txtComplemento.Text
            cls.Bairro = txtBairro.Text
            cls.Cidade = txtCidade.Text
            cls.UF = getComboValues(cboUF)
            cls.Endereco = txtEndereco.Text
            cls.Cep = txtCep.Text
            cls.Contato = txtContato.Text
            cls.Telefone = txtTelefone.Text
            cls.Celular = txtCelular.Text
            cls.Fax = txtFax.Text
            cls.Email = txtEmail.Text
            cls.Teste = IIf(chkTeste.Checked, 1, 0)
            cls.Foto = ImageUploaderUsuario.Imagem
            cls.AdicionarLoja = cboAdicionarLoja.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                If Not ImageUploaderUsuario.ShowSaveButton And ImageUploaderUsuario.HasPostedFile Then
                    ImageUploaderUsuario.Gravar()
                End If
                With CamposAdicionais1
                    .Entidade = "Usuario"
                    .GravarDados(cls.IDUsuario)
                End With

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Usuario, cls.IDUsuario)

                Inflate()
                MostraGravado("~/sistema/Usuario.aspx?idusuario=" & cls.IDUsuario)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SECAO, ACAO_APAGAR) Then
                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Usuario, cls.IDUsuario)

                cls.Delete()
                Response.Redirect("Usuarios.aspx")
            End If
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
        Protected Sub cboIDCargo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDCargo.SelectedIndexChanged
            BindSuperior()
            Permissoes1.IDCargo = cboIDCargo.SelectedValue
        End Sub

        Protected Sub btnRoteiro_Click(sender As Object, e As System.EventArgs) Handles btnRoteiro.Click
            Response.Redirect("~/roteiros/promotor_roteiro.aspx?idpromotor=" & ViewState(VW_IDUSUARIO))
        End Sub
    End Class

End Namespace

