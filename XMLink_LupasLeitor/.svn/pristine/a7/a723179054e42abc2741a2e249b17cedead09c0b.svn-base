
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Justificativa
        Inherits XMWebPage
        Dim cls As clsJustificativa
        Protected Const VW_IDJUSTIFICATIVA As String = "IDJustificativa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsJustificativa()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta justificativa?")
                ViewState(VW_IDJUSTIFICATIVA) = Cint("0" & Request("IDJustificativa"))
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

				Inflate()
            Else
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtJustificativa.Text = cls.Justificativa
			If cls.Criado = "" Then
                lblCriado.Text = DateTime.Now
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Justificativa = txtJustificativa.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Justificativa.aspx?idjustificativa=" & cls.idjustificativa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Justificativas.aspx")
        End Sub

	
    End Class

End Namespace

