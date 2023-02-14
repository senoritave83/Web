Imports Classes

Namespace Pages.Cadastros

    Partial Class Cadastros_TipoEvento
        Inherits XMWebEditPage

        Dim cls As clsTipoEvento
        Protected Const VW_IDTipoEvento As String = "IDTipoEvento"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoEvento()
            If Not Page.IsPostBack Then
                'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar este tipo de evento?")
                ViewState(VW_IDTipoEvento) = CInt("0" & Request("IDTipoEvento"))
                cls.Load(ViewState(VW_IDTipoEvento))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

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
                chkExclusivo.Checked = .Exclusivo
                chkInstantaneo.Checked = .Instantaneo
                chkPermiteObs.Checked = .PermiteObs
                chkPosicao.Checked = .Posicao
                chkUnico.Checked = .Unico

                Select Case .Ativo
                    Case 0 'Inativo
                        chkAtivo.Checked = False
                    Case 1 'Ativo
                        chkAtivo.Checked = True
                    Case 2 'Apagado
                        chkApagado.Checked = True
                        liApagado.Visible = True
                        CamposReadOnly()
                End Select

            End With

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.TipoEvento, cls.IdTipoEvento)


        End Sub


        Protected Sub CamposReadOnly()
            txtTipoEvento.ReadOnly = True
            drpIdContexto.Enabled = False
            chkInstantaneo.Enabled = False
            chkExclusivo.Enabled = False
            chkInstantaneo.Enabled = False
            chkPermiteObs.Enabled = False
            chkPosicao.Enabled = False
            chkUnico.Enabled = False
            chkAtivo.Enabled = False
            chkApagado.Enabled = False
            btnGravar.Enabled = False
            btnApagar.Enabled = False
        End Sub


        Protected Sub Deflate()
            With cls
                .TipoEvento = txtTipoEvento.Text
                .IdContexto = getComboValue(drpIdContexto)
                .Ativo = IIf(chkAtivo.Checked = True, 1, 0)
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

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.TipoEvento, cls.IdTipoEvento)

                Inflate()
                MostraGravado("~/cadastros/tipoevento.aspx?idtipoevento=" & cls.IdTipoEvento)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.TipoEvento, cls.IdTipoEvento)

                cls.Delete()
                Response.Redirect("tiposevento.aspx")

            End If

        End Sub
    End Class

End Namespace

