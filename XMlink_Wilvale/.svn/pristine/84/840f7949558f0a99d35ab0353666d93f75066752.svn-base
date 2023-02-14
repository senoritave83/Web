
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

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCONDICAO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtCondicao.Text = cls.Condicao
            txtCorrecao.Text = cls.Correcao
            rdStatus.SelectedValue = cls.IdStatus
            If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
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
                MostraGravado("~/Cadastros/Condicao.aspx?idcondicao=" & cls.idcondicao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Condicoes.aspx")
            End If
        End Sub

	
    End Class

End Namespace

