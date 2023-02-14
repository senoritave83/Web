
Imports Classes

Namespace Pages.Pesquisas

    Partial Public Class JustificativaPesquisa
        Inherits XMWebPage
		
        Dim cls As clsJustificativaPesquisa
        Protected Const VW_IDJUSTIFICATIVA As String = "IDJustificativa"
        Protected Const Secao As String = "Cadastro de Justificativa Pesquisa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsJustificativaPesquisa()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta justificativapesquisa?")
                ViewState(VW_IDJUSTIFICATIVA) = Cint("0" & Request("IDJustificativa"))
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
          End If
        End Sub

        Protected Sub Inflate()
            txtJustificativa.Text = cls.Justificativa
            chkReicidencia.Checked = cls.Reincidencia
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
                lblCriado.Text = cls.Criado
                btnGravar.Enabled = False
                btnApagar.Enabled = False

			End If
        End Sub

        Protected Sub Deflate()
            cls.Justificativa = txtJustificativa.Text
            cls.Reincidencia = chkReicidencia.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Pesquisas/JustificativaPesquisa.aspx?idjustificativa=" & cls.idjustificativa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("JustificativaPesquisas.aspx")
			end if
        End Sub

	
    End Class

End Namespace

