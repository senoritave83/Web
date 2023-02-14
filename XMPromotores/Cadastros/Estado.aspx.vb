
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Estado
        Inherits XMWebPage
        Dim cls As clsEstado
        Protected Const VW_UF As String = "UF"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsEstado()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta estado?")
                ViewState(VW_UF) = Cint("0" & Request("UF"))
                cls.Load(ViewState(VW_UF))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_UF))
          End If
        End Sub

        Protected Sub Inflate()
			txtEstado.Text = cls.Estado
            Me.PageName = cls.Estado

        End Sub

        Protected Sub Deflate()
			cls.Estado = txtEstado.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Estado.aspx?uf=" & cls.uf)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Estados.aspx")
        End Sub
    End Class

End Namespace

