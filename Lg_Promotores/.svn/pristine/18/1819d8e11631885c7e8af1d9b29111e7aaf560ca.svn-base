
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Classificacao
        Inherits XMWebPage
        Dim cls As clsClassificacao
        Protected Const VW_IDCLASSIFICACAO As String = "IDClassificacao"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsClassificacao(CInt("0" & Request("idtipo")))
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta classificacao?")
                ViewState(VW_IDCLASSIFICACAO) = Cint("0" & Request("IDClassificacao"))
                cls.Load(ViewState(VW_IDCLASSIFICACAO))

                Dim strSecao As String = IIf(Request("Tipo") = 1, "Classificação de Consumo", "Classificação de Loja")

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(strSecao, ACAO_ADICIONAR), VerificaPermissao(strSecao, ACAO_EDITAR))
                btnNovo.Enabled = VerificaPermissao(strSecao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(strSecao, ACAO_APAGAR))


				Inflate()
            Else
                cls.Load(ViewState(VW_IDCLASSIFICACAO))
          End If
        End Sub

        Protected Sub Inflate()
			txtClassificacao.Text = cls.Classificacao
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Classificacao = txtClassificacao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Classificacao.aspx?idclassificacao=" & cls.IDClassificacao & "&idtipo=" & CInt("0" & Request("idtipo")))
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Classificacoes.aspx?idtipo=" & CInt("0" & Request("idtipo")))
        End Sub

	
        Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
            Response.Redirect("Classificacao.aspx?idclassificacao=0&idtipo=" & CInt("0" & Request("idtipo")))
        End Sub

        Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
            Response.Redirect("Classificacoes.aspx?idtipo=" & CInt("0" & Request("idtipo")))
        End Sub
    End Class

End Namespace

