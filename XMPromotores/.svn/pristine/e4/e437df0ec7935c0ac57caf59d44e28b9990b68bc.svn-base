Imports Classes

Namespace Pages.Cadastros

    Partial Public Class SubCategoria
        Inherits XMWebEditPage

        Dim cls As clsSubCategoria
        Protected Const VW_IDSUBCATEGORIA As String = "IDSubCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsSubCategoria()
            If Not Page.IsPostBack Then

                Dim clsCat As clsCategoria
                clsCat = New clsCategoria
                cboIDCategoria.DataSource = clsCat.Listar(DataClass.enReturnType.DataReader)
                cboIDCategoria.DataBind()
                cboIDCategoria.Items.Insert(0, New ListItem("Selecione o Segmento...", "0"))
                clsCat = Nothing

                subAddConfirm(btnApagar, SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem2", "Deseja realmente apagar esta subcategoria?"))
                valReqIDCategoria.ErrorMessage = SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem5", "Segmento é um campo obrigatório")
                valReqSubCategoria.ErrorMessage = SettingsExpression.GetProperty("texto", "SubCategoria.Mensagens.Mensagem5", "Categoria é um campo obrigatório")

                ViewState(VW_IDSUBCATEGORIA) = CInt("0" & Request("IDSubCategoria"))
                cls.Load(ViewState(VW_IDSUBCATEGORIA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()

                divOrdem.Visible = (cls.IDSubCategoria > 0)

            Else
                cls.Load(ViewState(VW_IDSUBCATEGORIA))

            End If
        End Sub

        Protected Sub Inflate()

            setComboValue(cboIDCategoria, cls.IDCategoria)
            txtSubCategoria.Text = cls.SubCategoria
            setComboValue(rdStatus, cls.IdStatus)
            txtOrdem.Text = cls.Ordem
			me.PageName = cls.SubCategoria
            lblCriado.Text = cls.Criado

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.SubCategoria, cls.IDSubCategoria)

        End Sub

        Protected Sub Deflate()
			cls.IDCategoria = cboIDCategoria.SelectedValue
            cls.SubCategoria = txtSubCategoria.Text
            cls.IdStatus = rdStatus.SelectedItem.Value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.SubCategoria, cls.IDSubCategoria)

                Inflate()
                MostraGravado("~/cadastros/SubCategoria.aspx?idsubcategoria=" & cls.idsubcategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.SubCategoria, cls.IDSubCategoria)

                If cls.Delete() Then
                    Response.Redirect("SubCategorias.aspx")
                Else
                    ShowMsg("A Categoria não pode ser apagada, pois existe(m) produto(s) vinculado(s) a ela!")
                End If

            End If
        End Sub
    End Class

End Namespace

