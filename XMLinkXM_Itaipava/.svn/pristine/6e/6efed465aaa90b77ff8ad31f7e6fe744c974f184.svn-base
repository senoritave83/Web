
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Categoria
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Categorias"
        Dim cls As clsCategoria
        Protected Const VW_IDCATEGORIA As String = "IDCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCategoria()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta categoria?")
                ViewState(VW_IDCATEGORIA) = Cint("0" & Request("IDCategoria"))
                cls.Load(ViewState(VW_IDCATEGORIA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCATEGORIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCategoria.Text = cls.Categoria
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Categoria = txtCategoria.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Categoria.aspx?idcategoria=" & cls.idcategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Categorias.aspx")
			end if
        End Sub

	
    End Class

End Namespace

