
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Regiao
        Inherits XMWebEditPage

        Dim cls As clsRegiao
        Protected Const VW_IDREGIAO As String = "IDRegiao"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRegiao()
            If Not Page.IsPostBack Then

                
                subAddConfirm(btnApagar, SettingsExpression.GetProperty("texto", "Regiao.Mensagens.Mensagem2", "Deseja realmente apagar esta região?"))
                valReqRegiao.ErrorMessage = SettingsExpression.GetProperty("texto", "Regiao.Mensagens.Mensagem5", "Região é um campo obrigatório!")
                ViewState(VW_IDREGIAO) = CInt("0" & Request("IDRegiao"))
                cls.Load(ViewState(VW_IDREGIAO))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDREGIAO))
            End If
        End Sub

        Protected Sub Inflate()
			txtRegiao.Text = cls.Regiao
			me.PageName = cls.Regiao
            lblCriado.Text = cls.Criado

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Regiao, cls.IDRegiao)

        End Sub

        Protected Sub Deflate()
			cls.Regiao = txtRegiao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Regiao, cls.IDRegiao)

                Inflate()
                MostraGravado("~/cadastros/Regiao.aspx?idregiao=" & cls.idregiao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Regiao, cls.IDRegiao)

                cls.Delete()
                Response.Redirect("Regioes.aspx")
            End If
        End Sub
    End Class

End Namespace

