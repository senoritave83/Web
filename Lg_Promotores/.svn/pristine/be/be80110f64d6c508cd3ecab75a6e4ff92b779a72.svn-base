
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

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDCATEGORIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCategoria.Text = cls.Categoria
			me.PageName = cls.Categoria
			lblCriado.Text = cls.Criado
			txtOrdem.Text = cls.Ordem
        End Sub

        Protected Sub Deflate()
			cls.Categoria = txtCategoria.Text
			cls.Ordem = txtOrdem.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Categoria.aspx?idcategoria=" & cls.idcategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Categorias.aspx")
        End Sub
    End Class

End Namespace

