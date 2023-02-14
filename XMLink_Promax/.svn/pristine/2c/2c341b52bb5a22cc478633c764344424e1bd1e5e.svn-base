
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class ObsPedido
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Observações de Pedidos"
        Dim cls As clsObsPedido
        Protected Const VW_IDOBSPEDIDO As String = "IDObsPedido"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsObsPedido()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta observação?")
                ViewState(VW_IDOBSPEDIDO) = Cint("0" & Request("IDObsPedido"))
                cls.Load(ViewState(VW_IDOBSPEDIDO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDOBSPEDIDO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtDescricao.Text = cls.Descricao
            chkHabilitaBrinde.Checked = (cls.HabilitaBrinde = 1)
            chkAtivo.Checked = (cls.Ativo = 1)
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Descricao = txtDescricao.Text
            cls.HabilitaBrinde = IIf(chkHabilitaBrinde.Checked, 1, 0)
            cls.Ativo = IIf(chkAtivo.Checked, 1, 0)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/ObsPedido.aspx?idobspedido=" & cls.idobspedido)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("ObsPedidos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

