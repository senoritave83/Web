Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Usuario
        Inherits XMWebPage
        Dim cls As clsUsuario
        Protected Const VW_IDUSUARIO As String = "IDUsuario"
        Protected Const ACAO_DEFINIRADMINISTRADOR As String = "Definir como administrador"
        Protected Const ACAO_ALTERARPERMISSAO As String = "Alterar permissões"
        Protected Const ACAO_ALTERARSENHA As String = "Alterar senha"
        Protected Const ACAO_VISUALIZARPERMISSAO As String = "Visualizar Permissões"
        Protected Const ACAO_EDITARPERMISSAO As String = "Editar Permissões"
        Private strIdPermissoesTravar As String = SettingsExpression.GetProperty("TravarPermissoesUsuario", "Usuario.Permissoes", "")
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsUsuario()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar este usuario?")
                ViewState(VW_IDUSUARIO) = Cint("0" & Request("IDUsuario"))
                cls.Load(ViewState(VW_IDUSUARIO))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                btnAlterarSenha.Enabled = VerificaPermissao(SecaoAtual, ACAO_ALTERARSENHA)

                pnlPermissoes.Visible = VerificaPermissao(SecaoAtual, ACAO_VISUALIZARPERMISSAO)
                grdPermissao.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITARPERMISSAO)

                trAdministrador.Visible = User.isAdmin

                Inflate()

            Else
                cls.Load(ViewState(VW_IDUSUARIO))
            End If

        End Sub

        Protected Sub Inflate()

            txtUsuario.Text = cls.Usuario
			me.PageName = cls.Usuario
			txtlogin.Text = cls.login
			txtSenha.Text = cls.Senha
            SetCheckValue(rdAdmin, cls.Administrador)
            If IsDate(cls.UltimoAcesso) Then
                lblUltimoAcesso.Text = cls.UltimoAcesso
            Else
                lblUltimoAcesso.Text = "Inexistente"
            End If
            If IsDate(cls.SenhaAlterada) Then
                lblSenhaAlterada.Text = cls.SenhaAlterada
            Else
                lblSenhaAlterada.Text = "Sem Alteraç&atilde;o"
            End If
            If IsDate(cls.UltimaAtividade) Then
                lblUltimaAtividade.Text = cls.UltimaAtividade
            Else
                lblUltimaAtividade.Text = "Sem Informaç&otilde;es de Atividade"
            End If
            If IsDate(cls.Criado) Then
                lblCriado.Text = FormatDateTime(cls.Criado, DateFormat.ShortDate)
            Else
                lblCriado.Text = ""
            End If
            txtEmail.Text = cls.Email
            txtObservacao.Text = cls.Observacao
            If IsDate(cls.ValidSenha) Then
                lblValidSenha.Text = FormatDateTime(cls.ValidSenha, DateFormat.ShortDate)
            Else
                lblValidSenha.Text = ""
            End If

            If cls.IDUsuario > 0 Then

                trSenha.Visible = False
                trDadosAcesso.Visible = True
                trDadosAcesso2.Visible = True
                btnApagar.Visible = True
                btnAlterarSenha.Visible = True

                Dim clsPer As clsPermissao
                clsPer = New clsPermissao
                grdPermissao.DataSource = clsPer.Listar(ViewState(VW_IDUSUARIO), DataClass.enReturnType.DataReader)
                grdPermissao.DataBind()
                'chkPermissoes.DataSource = clsPer.Listar(ViewState(VW_IDUSUARIO), DataClass.enReturnType.DataReader)
                'chkPermissoes.DataBind()
                clsPer = Nothing

            Else

                trSenha.Visible = False
                trDadosAcesso.Visible = False
                trDadosAcesso2.Visible = False
                btnApagar.Visible = False
                btnAlterarSenha.Visible = False
                pnlPermissoes.Visible = False

            End If

        End Sub

        Protected Sub Deflate()

            cls.Usuario = txtUsuario.Text
            cls.login = txtlogin.Text
            cls.Administrador = rdAdmin.SelectedValue
            cls.Email = txtEmail.Text
            cls.Observacao = txtObservacao.Text
            If trSenha.Visible Then cls.Senha = txtSenha.Text

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            
            If cls.isValid Then
                cls.Update()
                cls.GravarPermissoes(Split(Request("Permissoes"), ","))
                Inflate()
                MostraGravado("~/sistema/Usuario.aspx?idusuario=" & cls.IDUsuario)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Usuarios.aspx")
        End Sub

        Protected Sub btnAlterarSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlterarSenha.Click

            Response.Redirect("UsuarioAltSenha.aspx?IdUsuario=" & ViewState(VW_IDUSUARIO))

        End Sub

        Public Function VerificaTravarPermissao(ByVal vIdPermissao As Integer) As String
            'AS PERMISSÕES QUE DEVEM SER TRAVADAS
            'DEVEM CONSTAR NO ARQUIVO DE CONFIGURAÇÕES settings.xml
            'NO FORMATO |5|7|9|
            If strIdPermissoesTravar.StartsWith("||") = False Then strIdPermissoesTravar = "|" & strIdPermissoesTravar
            If strIdPermissoesTravar.StartsWith("||") = False Then strIdPermissoesTravar = "|" & strIdPermissoesTravar
            Return IIf(strIdPermissoesTravar.IndexOf("|" & vIdPermissao & "|") > 0, "disabled", "")
        End Function

       
    End Class

End Namespace

