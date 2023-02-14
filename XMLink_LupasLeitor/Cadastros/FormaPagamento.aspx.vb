
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
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

				Inflate()
            Else
                cls.Load(ViewState(VW_IDFORMAPAGAMENTO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtFormaPagamento.Text = cls.FormaPagamento
			txtCorrecao.Text = cls.Correcao
			If cls.Criado = "" Then
                lblCriado.Text = DateTime.Now
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.FormaPagamento = txtFormaPagamento.Text
			cls.Correcao = txtCorrecao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
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
            cls.Delete()
            Response.Redirect("FormaPagamentos.aspx")
        End Sub

	
    End Class

End Namespace

