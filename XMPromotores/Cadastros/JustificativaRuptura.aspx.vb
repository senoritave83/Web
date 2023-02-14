
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class JustificativaRuptura
        Inherits XMWebEditPage

        Dim cls As clsJustificativaRuptura
        Protected Const VW_IDJUSTIFICATIVARUPTURA As String = "JustificativaRuptura"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsJustificativaRuptura()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta justificativa de ruptura?")
                ViewState(VW_IDJUSTIFICATIVARUPTURA) = CInt("0" & Request("IdJustRupt"))
                cls.Load(ViewState(VW_IDJUSTIFICATIVARUPTURA))
				
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDJUSTIFICATIVARUPTURA))
            End If
        End Sub

        Protected Sub Inflate()
            txtJustificativaRuptura.Text = cls.JustificativaRuptura
            cboConcorrenteMostrar.SelectedValue = cls.Concorrente
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.JustificativaRuptura, cls.IDJustificativaRuptura)

        End Sub

        Protected Sub Deflate()
            cls.JustificativaRuptura = txtJustificativaRuptura.Text
            cls.Concorrente = cboConcorrenteMostrar.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.JustificativaRuptura, cls.IDJustificativaRuptura)

                Inflate()
                MostraGravado("~/Cadastros/JustificativaRuptura.aspx?IdJustRupt=" & cls.IDJustificativaRuptura)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.JustificativaRuptura, cls.IDJustificativaRuptura)

                cls.Delete()
                Response.Redirect("JustificativaRupturas.aspx")
            End If
        End Sub

	
    End Class

End Namespace

