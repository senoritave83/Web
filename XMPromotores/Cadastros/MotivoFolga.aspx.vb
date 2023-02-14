
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MotivoFolga
        Inherits XMWebEditPage

        Dim cls As clsMotivoFolga
        Protected Const VW_IDMOTIVOFOLGA As String = "IDMotivoFolga"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotivoFolga()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta motivofolga?")
                ViewState(VW_IDMOTIVOFOLGA) = CInt("0" & Request("IDMotivoFolga"))
                cls.Load(ViewState(VW_IDMOTIVOFOLGA))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTIVOFOLGA))
            End If
        End Sub

        Protected Sub Inflate()
            txtMotivoFolga.Text = cls.MotivoFolga

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.MotivoFolga, cls.IDMotivoFolga)

        End Sub

        Protected Sub Deflate()
            cls.MotivoFolga = txtMotivoFolga.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.MotivoFolga, cls.IDMotivoFolga)

                Inflate()
                MostraGravado("~/Cadastros/MotivoFolga.aspx?idmotivofolga=" & cls.idmotivofolga)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.MotivoFolga, cls.IDMotivoFolga)

                cls.Delete()
                Response.Redirect("MotivoFolgas.aspx")
            End If
        End Sub


    End Class

End Namespace

