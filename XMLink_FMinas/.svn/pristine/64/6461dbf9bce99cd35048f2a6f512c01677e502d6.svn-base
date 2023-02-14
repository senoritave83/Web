
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MensagemDia
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Mensagens"
        Dim cls As clsMensagemDia
        Protected Const VW_IDMENSAGEMDIA As String = "IDMensagemDia"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemDia()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagem?")
                ViewState(VW_IDMENSAGEMDIA) = Cint("0" & Request("IDMensagemDia"))
                cls.Load(ViewState(VW_IDMENSAGEMDIA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

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
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MensagemDia.aspx?idmensagemdia=" & cls.idmensagemdia)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("MensagemDias.aspx")
			end if
        End Sub

	
    End Class

End Namespace

