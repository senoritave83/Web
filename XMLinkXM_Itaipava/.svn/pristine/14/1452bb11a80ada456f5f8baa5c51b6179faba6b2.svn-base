
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Usuario
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Usuários"
        Dim cls As clsUsuario
        Protected Const VW_IDUSUARIO As String = "IDUsuario"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsUsuario()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta usuario?")
                ViewState(VW_IDUSUARIO) = Cint("0" & Request("IDUsuario"))
                cls.Load(ViewState(VW_IDUSUARIO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                Dim reg As New clsRegional
                cboRegional.DataSource = reg.Listar()
                cboRegional.DataBind()
                cboRegional.Items.Insert(0, New ListItem("", 0))
                reg = Nothing
                divRegional.Visible = (User.IDEmpresa = 0)

                Inflate()
                BindRoles()

            Else
                cls.Load(ViewState(VW_IDUSUARIO))

          End If
        End Sub

        Protected Sub BindGrupos()

            Dim grp As New clsGrupo
            Dim dr As System.Data.IDataReader = grp.ListarGrupos_Usuario(cls.IDUsuario)
            lstGrupos.Items.Clear()
            While dr.Read
                Dim li As New ListItem(dr.GetString(dr.GetOrdinal(lstGrupos.DataTextField)), dr.GetInt32(dr.GetOrdinal(lstGrupos.DataValueField)))
                li.Selected = dr.GetInt32(dr.GetOrdinal("Selecionado"))
                lstGrupos.Items.Add(li)
            End While

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
                grdRoles.Visible = True
            Else
                txtSenha.Visible = True
                btnNovaSenha.Visible = False
                grdRoles.Visible = False
            End If

            chkAdministrador.Checked = cls.Administrador

            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

            txtObservacao.Text = cls.Observacao
			txtEmail.Text = cls.Email
            setComboValue(cboRegional, cls.IDRegional)

            BindGrupos()

        End Sub

        Protected Sub Deflate()
			cls.Usuario = txtUsuario.Text
            cls.login = txtlogin.Text
            If txtSenha.Visible Then cls.Senha = txtSenha.Text
			cls.Observacao = txtObservacao.Text
            cls.Email = txtEmail.Text
            cls.IDRegional = cboRegional.SelectedValue

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then

                cls.Update()

                Dim grp As New clsGrupo
                'Grava os grupos ao qual pertence
                For Each li As ListItem In lstGrupos.Items
                    grp.GravaGrupoUsuario(cls.IDUsuario, li.Value, li.Selected)
                Next

                Inflate()
                MostraGravado("~/Cadastros/Usuario.aspx?idusuario=" & cls.IDUsuario)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Usuarios.aspx")
			end if
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
            btnNovaSenha.Visible = False
        End Sub

        Public Function GetFullLogin() As String

            Return Me.User.Chave & cls.login

        End Function


        Protected Sub chk_OnCheckedChange(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim checkbox As CheckBox = CType(sender, CheckBox)
            Dim row As GridViewRow = CType(checkbox.NamingContainer, GridViewRow)
            Dim strRole As String = grdRoles.DataKeys(row.DataItemIndex).Item(0)
            If Roles.IsUserInRole(GetFullLogin(), strRole) Then
                If checkbox.Checked = False Then Roles.RemoveUserFromRole(GetFullLogin(), strRole)
            Else
                If checkbox.Checked = True Then Roles.AddUserToRole(GetFullLogin(), strRole)
            End If
        End Sub

        Protected Sub grdRoles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRoles.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    CType(e.Row.FindControl("chk"), CheckBox).Checked = Roles.IsUserInRole(GetFullLogin(), grdRoles.DataKeys(e.Row.RowIndex).Value)
                Catch ex As Exception

                End Try
            End If
        End Sub
	
    End Class



End Namespace

