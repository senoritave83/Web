
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Usuario
        Inherits XMWebPage

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

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                chkAdministrador.Enabled = VerificaPermissao(Secao, ACAO_DEFINIRADMINISTRADOR)
                grdRoles.Visible = VerificaPermissao(Secao, ACAO_ALTERARPERMISSAO)

                Inflate()
                BindRoles()
            Else
                cls.Load(ViewState(VW_IDUSUARIO))
          End If
        End Sub

        Protected Sub BindRoles()
            Dim per As New clsPermissao
            grdRoles.DataSource = per.Listar()
            grdRoles.DataBind()
            per = Nothing
        End Sub

        Protected Sub Inflate()
			txtUsuario.Text = cls.Usuario
			txtlogin.Text = cls.login
			If cls.IDUsuario > 0 Then
				txtSenha.Visible = False
				btnNovaSenha.Visible = True
			Else
				txtSenha.Visible = True
				btnNovaSenha.Visible = False
			End If
            chkAdministrador.Checked = cls.Administrador
			lblUltimoAcesso.Text = cls.UltimoAcesso
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
            '			lblValidSenha.Text = cls.ValidSenha
            '           lblSenhaAlterada.Text = cls.SenhaAlterada
			txtObservacao.Text = cls.Observacao
			txtEmail.Text = cls.Email
            '			lblUltimaAtividade.Text = cls.UltimaAtividade
        End Sub

        Protected Sub Deflate()
			cls.Usuario = txtUsuario.Text
			cls.login = txtlogin.Text
			cls.Senha = txtSenha.Text
            cls.Administrador = chkAdministrador.Checked
            cls.Observacao = txtObservacao.Text
			cls.Email = txtEmail.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/sistema/Usuario.aspx?idusuario=" & cls.IDUsuario)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Usuarios.aspx")
            End If            
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
        Protected Sub chk_OnCheckedChange(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim checkbox As CheckBox = CType(sender, CheckBox)
            Dim row As GridViewRow = CType(checkbox.NamingContainer, GridViewRow)
            Dim strRole As String = grdRoles.DataKeys(row.DataItemIndex).Item(0)
            If Roles.IsUserInRole(cls.login, strRole) Then
                If checkbox.Checked = False Then Roles.RemoveUserFromRole(cls.login, strRole)
            Else
                If checkbox.Checked = True Then Roles.AddUserToRole(cls.login, strRole)
            End If
        End Sub

        Protected Sub grdRoles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRoles.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    CType(e.Row.FindControl("chk"), CheckBox).Checked = Roles.IsUserInRole(cls.login, grdRoles.DataKeys(e.Row.RowIndex).Value)
                Catch ex As Exception

                End Try
            End If
        End Sub

    End Class

End Namespace

