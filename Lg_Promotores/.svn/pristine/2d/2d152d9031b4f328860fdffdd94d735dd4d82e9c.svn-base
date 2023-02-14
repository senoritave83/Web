
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoJustificativa
        Inherits XMWebPage
        Dim cls As clsTipoJustificativa
        Protected Const VW_IDTIPOJUSTIFICATIVA As String = "IDTipoJustificativa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoJustificativa()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta tipojustificativa?")
                ViewState(VW_IDTIPOJUSTIFICATIVA) = Cint("0" & Request("IDTipoJustificativa"))
                cls.Load(ViewState(VW_IDTIPOJUSTIFICATIVA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDTIPOJUSTIFICATIVA))
          End If
        End Sub

        Protected Sub Inflate()
			txtTipoJustificativa.Text = cls.TipoJustificativa
			me.PageName = cls.TipoJustificativa
            lblCriado.Text = cls.Criado
            setCheckValue(rdAbono, IIf(cls.Abono = True, 1, 0))
        End Sub

        Protected Sub Deflate()
            cls.TipoJustificativa = txtTipoJustificativa.Text
            cls.Abono = rdAbono.SelectedItem.Value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/tipojustificativa.aspx?idtipojustificativa=" & cls.IDTipoJustificativa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("tipojustificativas.aspx")
        End Sub
    End Class

End Namespace

