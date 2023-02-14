Imports Classes

Namespace Pages.Cadastros

    Partial Class Cadastros_TipoEvento
        Inherits XMWebPage
        Dim cls As clsTipoEvento
        Protected Const VW_IDTipoEvento As String = "IDTipoEvento"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoEvento()
            If Not Page.IsPostBack Then
                'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar este tipo de evento?")
                ViewState(VW_IDTipoEvento) = CInt("0" & Request("IDTipoEvento"))
                cls.Load(ViewState(VW_IDTipoEvento))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()

            Else

                cls.Load(ViewState(VW_IDTipoEvento))

            End If

        End Sub

        Protected Sub Inflate()
            With cls

                txtTipoEvento.Text = .TipoEvento
                Me.PageName = .TipoEvento

                setComboValue(drpIdContexto, .IdContexto)
                lblCriado.Text = .Criado
                chkAtivo.Checked = .Ativo
                chkExclusivo.Checked = .Exclusivo
                chkInstantaneo.Checked = .Instantaneo
                chkPermiteObs.Checked = .PermiteObs
                chkPosicao.Checked = .Posicao
                chkUnico.Checked = .Unico

            End With
        End Sub

        Protected Sub Deflate()
            With cls
                .TipoEvento = txtTipoEvento.Text
                .IdContexto = getComboValue(drpIdContexto)
                .Ativo = chkAtivo.Checked
                .Exclusivo = chkExclusivo.Checked
                .Instantaneo = chkInstantaneo.Checked
                .PermiteObs = chkPermiteObs.Checked
                .Posicao = chkPosicao.Checked
                .Unico = chkUnico.Checked
            End With
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/tipoevento.aspx?idtipoevento=" & cls.IdTipoEvento)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("tiposevento.aspx")
        End Sub
    End Class

End Namespace

