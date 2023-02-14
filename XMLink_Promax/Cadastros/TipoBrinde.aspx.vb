
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoBrinde
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Brinde"
        Dim cls As clsTipoBrinde
        Protected Const VW_IDTIPOBRINDE As String = "IDTipoBrinde"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoBrinde()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar este tipo de brinde?")
                ViewState(VW_IDTIPOBRINDE) = Cint("0" & Request("IDTipoBrinde"))
                cls.Load(ViewState(VW_IDTIPOBRINDE))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDTIPOBRINDE))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtTipoBrinde.Text = cls.TipoBrinde
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.TipoBrinde = txtTipoBrinde.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/TipoBrinde.aspx?idtipobrinde=" & cls.idtipobrinde)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("TipoBrindes.aspx")
			end if
        End Sub

	
    End Class

End Namespace

