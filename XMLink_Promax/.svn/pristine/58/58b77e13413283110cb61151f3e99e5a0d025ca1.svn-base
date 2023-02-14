
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Vendedor
        Inherits XMWebPage
        Dim cls As clsVendedor
        Protected Const SECAO As String = "Cadastro de Vendedores"
        Protected Const ACAO_ALTERARSENHA As String = "Editar Senha"
        Protected Const VW_IDVENDEDOR As String = "IDVendedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVendedor()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta vendedor?")
                ViewState(VW_IDVENDEDOR) = Cint("0" & Request("IDVendedor"))
                cls.Load(ViewState(VW_IDVENDEDOR))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))
                btnNovaSenha.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_ALTERARSENHA))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDVENDEDOR))
          End If
        End Sub

        Protected Sub Inflate()
            txtCodigo.Text = cls.Codigo
            txtVendedor.Text = cls.Vendedor
            txtTelefone.Text = cls.Telefone
            txtLogin.Text = cls.Login
            If cls.IDVendedor > 0 Then
                txtSenha.Visible = False
                btnNovaSenha.Visible = True
            Else
                txtSenha.Visible = True
                btnNovaSenha.Visible = False
            End If
            txtID.Text = cls.ID
            txtObservacao.Text = cls.Observacao
            txtMaxDesconto.Text = cls.MaxDesconto
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
            chkTodosClientes.Checked = cls.TodosClientes
            rdStatus.SelectedValue = cls.IdStatus
            BindGrupos()
        End Sub

        Protected Sub BindGrupos()

            Dim grp As New clsGrupo
            Dim dr As System.Data.IDataReader = grp.Listar(cls.IDVendedor)
            lstGrupos.Items.Clear()
            While dr.Read
                Dim li As New ListItem(dr.GetString(dr.GetOrdinal(lstGrupos.DataTextField)), dr.GetInt32(dr.GetOrdinal(lstGrupos.DataValueField)))
                li.Selected = dr.GetInt32(dr.GetOrdinal("Selecionado"))
                lstGrupos.Items.Add(li)
            End While

        End Sub


        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Vendedor = txtVendedor.Text
			cls.Telefone = txtTelefone.Text
            cls.Login = txtLogin.Text
            If txtSenha.Visible And txtSenha.Text <> "" Then cls.Senha = txtSenha.Text
			cls.Senha = txtSenha.Text
			cls.ID = txtID.Text
			cls.Observacao = txtObservacao.Text
            cls.MaxDesconto = txtMaxDesconto.Text
            cls.TodosClientes = chkTodosClientes.Checked
            cls.IDStatus = rdStatus.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(SECAO, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()

                Dim grp As New clsGrupo
                'Grava os grupos ao qual pertence
                For Each li As ListItem In lstGrupos.Items
                    grp.GravaGrupoVendedor(cls.IDVendedor, li.Value, li.Selected)
                Next

                Inflate()
                MostraGravado("~/Cadastros/Vendedor.aspx?idvendedor=" & cls.idvendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SECAO, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Vendedores.aspx")
            End If
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
	
    End Class

End Namespace

