
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoJustificativa
        Inherits XMWebEditPage

        Dim cls As clsTipoJustificativa
        Protected Const VW_IDTIPOJUSTIFICATIVA As String = "IDTipoJustificativa"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoJustificativa()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta tipojustificativa?")
                ViewState(VW_IDTIPOJUSTIFICATIVA) = Cint("0" & Request("IDTipoJustificativa"))
                cls.Load(ViewState(VW_IDTIPOJUSTIFICATIVA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

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
            chkAplicarRuptura.Checked = cls.AplicarRuptura

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.TipoJustificativa, cls.IDTipoJustificativa)

        End Sub

        Protected Sub Deflate()
            cls.TipoJustificativa = txtTipoJustificativa.Text
            cls.Abono = rdAbono.SelectedItem.Value
            cls.AplicarRuptura = chkAplicarRuptura.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.TipoJustificativa, cls.IDTipoJustificativa)

                Inflate()
                MostraGravado("~/cadastros/tipojustificativa.aspx?idtipojustificativa=" & cls.IDTipoJustificativa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.TipoJustificativa, cls.IDTipoJustificativa)

                cls.Delete()
                Response.Redirect("tipojustificativas.aspx")
            End If
        End Sub
    End Class

End Namespace

