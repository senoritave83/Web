
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produto
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Produtos"
        Dim cls As clsProduto
        Protected Const VW_IDPRODUTO As String = "IDProduto"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsProduto()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar este produto?")
                ViewState(VW_IDPRODUTO) = Cint("0" & Request("IDProduto"))
                cls.Load(ViewState(VW_IDPRODUTO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDPRODUTO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtDescricao.Text = cls.Descricao
			txtContrato.Text = cls.Contrato
            txtEstoque.Text = cls.Estoque
			txtIPI.Text = cls.IPI
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
            BindPrecos()

        End Sub

        Protected Sub BindPrecos()
            grdPrecos.DataSource = cls.ListaPrecos(DataClass.enReturnType.DataSet)
            grdPrecos.DataBind()
            pnlPrecos.Visible = Not cls.IsNew
        End Sub



        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Descricao = txtDescricao.Text
			cls.Contrato = txtContrato.Text
			cls.Estoque = txtEstoque.Text
			cls.IPI = txtIPI.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Produto.aspx?idproduto=" & cls.idproduto)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Produtos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

