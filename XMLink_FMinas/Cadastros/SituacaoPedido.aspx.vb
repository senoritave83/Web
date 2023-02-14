
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class SituacaoPedido
        Inherits XMWebPage
		
		Protected Const SECAO as String = "Cadastro de SituacaoPedido"
        Dim cls As clsSituacaoPedido
        Protected Const VW_IDSITUACAOPEDIDO As String = "IDSituacaoPedido"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsSituacaoPedido()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta situacaopedido?")
                ViewState(VW_IDSITUACAOPEDIDO) = Cint("0" & Request("IDSituacaoPedido"))
                cls.Load(ViewState(VW_IDSITUACAOPEDIDO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDSITUACAOPEDIDO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtSituacaoPedido.Text = cls.SituacaoPedido
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.SituacaoPedido = txtSituacaoPedido.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/SituacaoPedido.aspx?idsituacaopedido=" & cls.idsituacaopedido)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("SituacaoPedidos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

