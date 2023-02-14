
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MensagemGeral
        Inherits XMWebPage
		
        Dim cls As clsMensagemGeral
        Protected Const VW_IDMENSAGEMGERAL As String = "IDMensagemGeral"
        Protected Const SECAO As String = "Cadastro de Mensagens Gerais"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMensagemGeral()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta mensagemgeral?")
                ViewState(VW_IDMENSAGEMGERAL) = Cint("0" & Request("IDMensagemGeral"))
                cls.Load(ViewState(VW_IDMENSAGEMGERAL))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMENSAGEMGERAL))
          End If
        End Sub

        Protected Sub Inflate()
			txtTitulo.Text = cls.Titulo
			txtMensagem.Text = cls.Mensagem
            lblData.Text = cls.Data
            If cls.IsNew Then
                lblData.Text = "Não gravada"
            End If
        End Sub

        Protected Sub Deflate()
			cls.Titulo = txtTitulo.Text
			cls.Mensagem = txtMensagem.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MensagemGeral.aspx?idmensagemgeral=" & cls.idmensagemgeral)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("MensagemGerais.aspx")
			end if
        End Sub

	
    End Class

End Namespace

