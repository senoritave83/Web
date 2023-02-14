
Imports Classes

Namespace Pages.Pesquisas

    Partial Public Class Marca
        Inherits XMWebPage
		
        Dim cls As clsMarca
        Protected Const VW_IDMARCA As String = "IDMarca"
        Protected Const Secao As String = "Cadastro de Marca"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMarca()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta marca?")
                ViewState(VW_IDMARCA) = Cint("0" & Request("IDMarca"))
                cls.Load(ViewState(VW_IDMARCA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMARCA))
          End If
        End Sub

        Protected Sub Inflate()
            txtCodigo.Text = cls.Codigo
            txtMarca.Text = cls.Marca
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
            cls.Codigo = txtCodigo.Text
            cls.Marca = txtMarca.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Pesquisas/Marca.aspx?idmarca=" & cls.idmarca)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Marcas.aspx")
			end if
        End Sub

	
    End Class

End Namespace

