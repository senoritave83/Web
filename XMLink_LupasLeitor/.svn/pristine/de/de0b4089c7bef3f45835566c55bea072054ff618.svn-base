
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Condicao
        Inherits XMWebPage
        Dim cls As clsCondicao
        Protected Const VW_IDCONDICAO As String = "IDCondicao"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCondicao()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta condicao?")
                ViewState(VW_IDCONDICAO) = Cint("0" & Request("IDCondicao"))
                cls.Load(ViewState(VW_IDCONDICAO))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCONDICAO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtCondicao.Text = cls.Condicao
			txtCorrecao.Text = cls.Correcao
			If cls.Criado = "" Then
                lblCriado.Text = DateTime.Now
			Else
			    lblCriado.Text = cls.Criado
			End If
			txtParcelas.Text = cls.Parcelas
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Condicao = txtCondicao.Text
			cls.Correcao = txtCorrecao.Text
			cls.Parcelas = txtParcelas.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Condicao.aspx?idcondicao=" & cls.idcondicao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Condicoes.aspx")
        End Sub

	
    End Class

End Namespace

