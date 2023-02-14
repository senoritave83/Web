
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Investimento
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Investimentos"
        Dim cls As clsInvestimento
        Protected Const VW_IDINVESTIMENTO As String = "IDInvestimento"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsInvestimento()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta investimento?")
                ViewState(VW_IDINVESTIMENTO) = Cint("0" & Request("IDInvestimento"))
                cls.Load(ViewState(VW_IDINVESTIMENTO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDINVESTIMENTO))
          End If
        End Sub

        Protected Sub Inflate()
			txtInvestimento.Text = cls.Investimento
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Investimento = txtInvestimento.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Investimento.aspx?idinvestimento=" & cls.idinvestimento)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Investimentos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

