
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Coordenador
        Inherits XMWebPage
		
		Protected Const SECAO as String = "Cadastro de Coordenador"
        Dim cls As clsCoordenador
        Protected Const VW_IDCOORDENADOR As String = "IDCoordenador"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCoordenador()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta coordenador?")
                ViewState(VW_IDCOORDENADOR) = Cint("0" & Request("IDCoordenador"))
                cls.Load(ViewState(VW_IDCOORDENADOR))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCOORDENADOR))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
            txtCoordenador.Text = cls.Coordenador
            rdStatus.SelectedValue = cls.IdStatus
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
            cls.Coordenador = txtCoordenador.Text
            cls.IdStatus = rdStatus.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Coordenador.aspx?idcoordenador=" & cls.idcoordenador)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Coordenadores.aspx")
			end if
        End Sub

	
    End Class

End Namespace

