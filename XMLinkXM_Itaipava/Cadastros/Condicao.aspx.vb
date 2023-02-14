
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Condicao
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Condições"
        Dim cls As clsCondicao
        Protected Const VW_IDCONDICAO As String = "IDCondicao"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCondicao()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta condicao?")
                ViewState(VW_IDCONDICAO) = Cint("0" & Request("IDCondicao"))
                cls.Load(ViewState(VW_IDCONDICAO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                Inflate()

            Else

                cls.Load(ViewState(VW_IDCONDICAO))

            End If
        End Sub

        Protected Sub Inflate()
			txtCondicao.Text = cls.Condicao
            txtValorMinimo.Text = FormatNumber(cls.ValorMinimo, 2)
            chkAprovacaoManual.Checked = cls.AprovacaoManual
            chkSobrepoeLimiteCredito.Checked = cls.SobrePoeLimiteCredito
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Condicao = txtCondicao.Text
            cls.ValorMinimo = txtValorMinimo.Text
            cls.AprovacaoManual = chkAprovacaoManual.Checked
            cls.SobrePoeLimiteCredito = chkSobrepoeLimiteCredito.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
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
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Condicoes.aspx")
			end if
        End Sub

	
    End Class

End Namespace

