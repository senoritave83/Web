
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Categoria
        Inherits XMWebPage
        Dim cls As clsCategoria
        Protected Const VW_IDCATEGORIA As String = "IDCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCategoria()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta categoria?")
                ViewState(VW_IDCATEGORIA) = Cint("0" & Request("IDCategoria"))
                cls.Load(ViewState(VW_IDCATEGORIA))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCATEGORIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
            txtCategoria.Text = cls.Categoria
            rdStatus.SelectedValue = cls.IdStatus
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
            cls.Categoria = txtCategoria.Text
            cls.IdStatus = rdStatus.SelectedItem.Value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

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
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Categorias.aspx")
            End If
        End Sub

	
    End Class

End Namespace

