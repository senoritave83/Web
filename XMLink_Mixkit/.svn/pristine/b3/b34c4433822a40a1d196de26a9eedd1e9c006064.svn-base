
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class FormaPagamento
        Inherits XMWebPage
		
        Dim cls As clsFormaPagamento
        Protected Const VW_IDFORMAPAGAMENTO As String = "IDFormaPagamento"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsFormaPagamento()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta formapagamento?")
                ViewState(VW_IDFORMAPAGAMENTO) = Cint("0" & Request("IDFormaPagamento"))
                cls.Load(ViewState(VW_IDFORMAPAGAMENTO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDFORMAPAGAMENTO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtFormaPagamento.Text = cls.FormaPagamento
			txtCorrecao.value = cls.Correcao
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.FormaPagamento = txtFormaPagamento.Text
			cls.Correcao = txtCorrecao.value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/FormaPagamento.aspx?idformapagamento=" & cls.idformapagamento)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("FormaPagamentos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

