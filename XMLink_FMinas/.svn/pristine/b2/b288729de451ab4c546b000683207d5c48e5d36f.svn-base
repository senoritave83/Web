
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Produto
        Inherits XMWebPage
		
		Protected Const SECAO as String = "Cadastro de Produto"
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

                'Bind Combos
                Dim cat As New clsCategoria
                cboIDCategoria.DataSource = cat.Listar
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("Selecione...", 0))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDPRODUTO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtDescricao.Text = cls.Descricao
			SetComboValue(cboIDCategoria, cls.IDCategoria)
			txtEstoque.Text = cls.Estoque
            txtPrecoUnitario.Text = FormatNumber(cls.PrecoUnitario, 2)
            txtCodigoOriginal.Text = cls.CodigoOriginal
            txtDescontoMax.Text = cls.DescontoMax
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
            If ViewState(VW_IDPRODUTO) = 0 Then
                chkProdAtivo.Checked = True
                chkProdAtivo.Enabled = False
            Else
                chkProdAtivo.Checked = cls.ProdutoAtivo
                chkProdAtivo.Enabled = True
            End If
            BindPrecos()

        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Descricao = txtDescricao.Text
			cls.IDCategoria = cboIDCategoria.SelectedValue
			cls.Estoque = txtEstoque.Text
            cls.PrecoUnitario = txtPrecoUnitario.Text
            cls.CodigoOriginal = txtCodigoOriginal.Text
            cls.DescontoMax = txtDescontoMax.Text
            cls.ProdutoAtivo = chkProdAtivo.Checked
        End Sub


        Private Sub BindPrecos()

            rptPrecoEstado.DataSource = cls.ListarPrecoEstado(cls.IDProduto)
            rptPrecoEstado.DataBind()

        End Sub

        Protected Function GetPreco(ByVal vPreco As Object) As String
            If IsDBNull(vPreco) Then
                Return ""
            Else
                Return FormatNumber(vPreco, 2)
            End If
        End Function


        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                For Each it As Object In rptPrecoEstado.Items

                    Dim vEstado As String = ""
                    Dim vPreco As String = ""

                    Dim lblEstado As Label = CType(it.FindControl("lblEstado"), Label)
                    Dim txtPreco As TextBox = CType(it.FindControl("txtPreco"), TextBox)

                    If Not lblEstado Is Nothing Then vEstado = lblEstado.Text
                    If Not txtPreco Is Nothing Then vPreco = txtPreco.Text

                    If vPreco <> "" And IsNumeric(vPreco) Then
                        cls.GravaPrecoProdutoEstado(cls.IDProduto, vEstado, vPreco)
                    End If

                Next
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

