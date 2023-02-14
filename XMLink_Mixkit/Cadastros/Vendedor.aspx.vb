
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Vendedor
        Inherits XMWebPage
		
        Dim cls As clsVendedor
        Protected Const VW_IDVENDEDOR As String = "IDVendedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVendedor()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta vendedor?")
                ViewState(VW_IDVENDEDOR) = Cint("0" & Request("IDVendedor"))
                cls.Load(ViewState(VW_IDVENDEDOR))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

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
            'If cls.IDVendedor > 0 Then
            '	txtSenha.Visible = False
            '	btnNovaSenha.Visible = True
            'Else
            '	txtSenha.Visible = True
            '	btnNovaSenha.Visible = False
            'End If
            txtSenha.Text = cls.Senha
            txtSenha.Visible = True
            btnNovaSenha.Visible = False
            txtID.Text = cls.ID
			txtObservacao.Text = cls.Observacao
			txtSubscriberID.Text = cls.SubscriberID
            txtDescontoMax.Value = cls.MaxDesconto
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
            chkTodosClientes.Checked = IIf(cls.TodosClientes = 0, False, True)
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Vendedor = txtVendedor.Text
			cls.Telefone = txtTelefone.Text
			cls.Login = txtLogin.Text
			cls.Senha = txtSenha.Text
			cls.ID = txtID.Text
			cls.Observacao = txtObservacao.Text
			cls.SubscriberID = txtSubscriberID.Text
            cls.MaxDesconto = txtDescontoMax.Value
            cls.TodosClientes = IIf(chkTodosClientes.Checked, 1, 0)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Vendedor.aspx?idvendedor=" & cls.idvendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Vendedores.aspx")
			end if
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
	
    End Class

End Namespace

