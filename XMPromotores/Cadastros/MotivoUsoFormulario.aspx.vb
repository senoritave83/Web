
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MotivoUsoFormulario
        Inherits XMWebEditPage

        Dim cls As clsMotivoUsoFormulario
        Protected Const VW_IDMOTIVOUSOFORM As String = "IDMotivoUsoForm"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotivoUsoFormulario()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta motivousoformulario?")
                ViewState(VW_IDMOTIVOUSOFORM) = Cint("0" & Request("IDMotivoUsoForm"))
                cls.Load(ViewState(VW_IDMOTIVOUSOFORM))
				
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTIVOUSOFORM))
            End If
        End Sub

        Protected Sub Inflate()
            txtMotivoUsoForm.Text = cls.MotivoUsoForm

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.MotivoUsoForm, cls.IDMotivoUsoForm)

        End Sub

        Protected Sub Deflate()
            cls.MotivoUsoForm = txtMotivoUsoForm.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.MotivoUsoForm, cls.IDMotivoUsoForm)

                Inflate()
                MostraGravado("~/Cadastros/MotivoUsoFormulario.aspx?idmotivousoform=" & cls.idmotivousoform)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.MotivoUsoForm, cls.IDMotivoUsoForm)

                cls.Delete()
                Response.Redirect("MotivoUsoFormularios.aspx")
            End If
        End Sub

	
    End Class

End Namespace

