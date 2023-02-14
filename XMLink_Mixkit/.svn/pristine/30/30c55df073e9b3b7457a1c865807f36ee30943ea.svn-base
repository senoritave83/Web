Imports Classes

Namespace Pages.Cadastros
    Partial Class LinhaNegocio
        Inherits XMWebPage

        Dim cls As clsLinhaNegocio
        Protected Const VW_IDLINHANEGOCIO As String = "IDLinhaNegocio"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsLinhaNegocio()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta linha de negócio?")
                ViewState(VW_IDLINHANEGOCIO) = CInt("0" & Request("IDLinha"))
                cls.Load(ViewState(VW_IDLINHANEGOCIO))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDLINHANEGOCIO))
            End If
        End Sub

        Protected Sub Inflate()
            txtLinhaNegocio.Text = cls.LinhaNegocio
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
            cls.LinhaNegocio = txtLinhaNegocio.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            cls.Update()
            Inflate()
            MostraGravado("~/Cadastros/LinhaNegocio.aspx?idlinha=" & cls.IDLinhaNegocio)
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("LinhasNegocio.aspx")
            End If
        End Sub


    End Class
End Namespace