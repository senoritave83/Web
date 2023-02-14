
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MensagemDia
        Inherits XMWebPage
        Dim cls As clsMensagemDia
        Protected Const VW_IDMENSAGEMDIA As String = "IDMensagemDia"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemDia()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagemdia?")
                ViewState(VW_IDMENSAGEMDIA) = Cint("0" & Request("IDMensagemDia"))
                cls.Load(ViewState(VW_IDMENSAGEMDIA))

                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMENSAGEMDIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtMensagem.Text = cls.Mensagem
			txtDataInicio.Text = cls.DataInicio
			txtDataDim.Text = cls.DataDim
        End Sub

        Protected Sub Deflate()
			cls.Mensagem = txtMensagem.Text
			cls.DataInicio = txtDataInicio.Text
			cls.DataDim = txtDataDim.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MensagemDias.aspx?idmensagemdia=" & cls.IDMensagemDia)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("MensagemDias.aspx")
        End Sub

	
    End Class

End Namespace

