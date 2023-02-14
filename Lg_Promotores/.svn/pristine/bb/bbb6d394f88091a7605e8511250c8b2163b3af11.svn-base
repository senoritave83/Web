
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MotivoUsoFormulario
        Inherits XMWebPage
		
        Dim cls As clsMotivoUsoFormulario
        Protected Const VW_IDMOTIVOUSOFORM As String = "IDMotivoUsoForm"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotivoUsoFormulario()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta motivousoformulario?")
                ViewState(VW_IDMOTIVOUSOFORM) = Cint("0" & Request("IDMotivoUsoForm"))
                cls.Load(ViewState(VW_IDMOTIVOUSOFORM))
				
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTIVOUSOFORM))
          End If
        End Sub

        Protected Sub Inflate()
			txtMotivoUsoForm.Text = cls.MotivoUsoForm
        End Sub

        Protected Sub Deflate()
			cls.MotivoUsoForm = txtMotivoUsoForm.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
            If (cls.IsNew() And VerificaPermissao(SecaoAtual, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SecaoAtual, ACAO_EDITAR) = False) Then
                Exit Sub
            End If
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MotivoUsoFormulario.aspx?idmotivousoform=" & cls.idmotivousoform)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SecaoAtual, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("MotivoUsoFormularios.aspx")
            End If
        End Sub

	
    End Class

End Namespace

