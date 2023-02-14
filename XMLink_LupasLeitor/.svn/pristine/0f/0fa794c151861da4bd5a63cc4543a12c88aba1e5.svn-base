
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
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)
                btnNovaSenha.Enabled = btnApagar.Enabled

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
            DataCriado.Text = cls.Criado
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
                DataCriado.Text = DateTime.Now
            Else
                DataCriado.Text = cls.Criado
            End If
            chkTodosClientes.Checked = cls.TodosClientes

            grdClientes.DataSource = cls.ListarClientes(ViewState(VW_IDVENDEDOR))
            grdClientes.DataBind()
            ltrQuantidadeClientes.Text = grdClientes.Rows.Count

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
            cls.Criado = DataCriado.Text

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
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
            cls.Delete()
            Response.Redirect("Vendedores.aspx")
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
	
    End Class

End Namespace

