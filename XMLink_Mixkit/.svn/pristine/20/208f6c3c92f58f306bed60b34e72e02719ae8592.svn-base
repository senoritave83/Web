
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Motivo
        Inherits XMWebPage
		
        Dim cls As clsMotivo
        Protected Const VW_IDMOTIVO As String = "IDMotivo"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotivo()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta motivo?")
                ViewState(VW_IDMOTIVO) = Cint("0" & Request("IDMotivo"))
                cls.Load(ViewState(VW_IDMOTIVO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTIVO))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtMotivo.Text = cls.Motivo
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Motivo = txtMotivo.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Motivo.aspx?idmotivo=" & cls.idmotivo)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Motivos.aspx")
			end if
        End Sub

	
    End Class

End Namespace

