
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Propriedade
        Inherits XMWebEditPage
        Dim cls As clsPropriedades
        Protected Const VW_IDProperty As String = "IDPropriedade"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            cls = New clsPropriedades()

            If Not Page.IsPostBack Then

                subAddConfirm(btnApagar, SettingsExpression.GetProperty("texto", "Propriedade.Mensagens.Mensagem2", "Deseja realmente apagar esta propriedade?"))
                valReqProperty.ErrorMessage = SettingsExpression.GetProperty("texto", "Propriedade.Mensagens.Mensagem5", "Propriedade é um campo obrigatório")

                ViewState(VW_IDProperty) = CInt("0" & Request("IDPropriedade"))
                cls.Load(ViewState(VW_IDProperty))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                'divOrdem.Visible = (cls.IDPropriedade > 0)

                Inflate()

            Else

                cls.Load(ViewState(VW_IDProperty))

            End If
        End Sub

        Protected Sub Inflate()
            txtPropriedade.Text = cls.Propriedade
            setComboValue(rdStatus, cls.IdStatus)
            'txtOrdem.Text = cls.Ordem

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Propriedade, cls.IDPropriedade)


        End Sub

        Protected Sub Deflate()
            cls.Propriedade = txtPropriedade.Text
            cls.IdStatus = rdStatus.SelectedItem.Value
        End Sub


        Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

            If e.CommandName = "UP" Then
                Dim intIdCategoria As Integer = e.CommandArgument
                cls.TrocarOrdem(intIdCategoria, 1)
            ElseIf e.CommandName = "DOWN" Then
                Dim intIdCategoria As Integer = e.CommandArgument
                cls.TrocarOrdem(intIdCategoria, 2)
            End If
            DataBind()

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Propriedade, cls.IDPropriedade)

                Inflate()
                MostraGravado("~/cadastros/propriedade.aspx?IDPropriedade=" & cls.IDPropriedade)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Propriedade, cls.IDPropriedade)

                If cls.Delete() Then
                    Response.Redirect("Propriedades.aspx")
                Else
                    ShowMsg(SettingsExpression.GetProperty("texto", "Propriedades.Mensagens.Mensagem1", "A propriedade não pode ser apagada, pois existe(m) categoria(s) vinculada(s) a ele!"))
                End If

            End If
        End Sub

    End Class

End Namespace

