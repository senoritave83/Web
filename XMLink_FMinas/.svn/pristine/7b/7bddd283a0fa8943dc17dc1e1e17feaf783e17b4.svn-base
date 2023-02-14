
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Bloqueio
        Inherits XMWebPage
		
        Dim cls As clsBloqueio
        Protected Const SECAO As String = "Cadastro de Bloqueio"
        Protected Const VW_IDBLOQUEIO As String = "IDBloqueio"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsBloqueio()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar este bloqueio?")
                ViewState(VW_IDBLOQUEIO) = Cint("0" & Request("IDBloqueio"))
                cls.Load(ViewState(VW_IDBLOQUEIO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDBLOQUEIO))
          End If
        End Sub

        Protected Sub Inflate()
			txtBloqueio.Text = cls.Bloqueio
			chkPermitePedido.Checked = cls.PermitePedido
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Bloqueio = txtBloqueio.Text
			cls.PermitePedido = chkPermitePedido.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Bloqueio.aspx?idbloqueio=" & cls.idbloqueio)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Bloqueios.aspx")
			end if
        End Sub

	
    End Class

End Namespace

