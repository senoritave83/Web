
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class MotivoFolga
        Inherits XMWebPage

        Dim cls As clsMotivoFolga
        Protected Const VW_IDMOTIVOFOLGA As String = "IDMotivoFolga"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotivoFolga()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta motivofolga?")
                ViewState(VW_IDMOTIVOFOLGA) = CInt("0" & Request("IDMotivoFolga"))
                cls.Load(ViewState(VW_IDMOTIVOFOLGA))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTIVOFOLGA))
            End If
        End Sub

        Protected Sub Inflate()
            txtMotivoFolga.Text = cls.MotivoFolga
        End Sub

        Protected Sub Deflate()
            cls.MotivoFolga = txtMotivoFolga.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(SecaoAtual, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(SecaoAtual, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/MotivoFolga.aspx?idmotivofolga=" & cls.idmotivofolga)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(SecaoAtual, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("MotivoFolgas.aspx")
            End If
        End Sub


    End Class

End Namespace

