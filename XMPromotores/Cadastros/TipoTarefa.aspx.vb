
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoTarefa
        Inherits XMWebEditPage

        Dim cls As clsTipoTarefa
        Protected Const VW_IDTipoTarefa As String = "IDTipoTarefa"


        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoTarefa()
            If Not Page.IsPostBack Then
                'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta TipoTarefa?")
                ViewState(VW_IDTipoTarefa) = CInt("0" & Request("IDTipoTarefa"))
                cls.Load(ViewState(VW_IDTipoTarefa))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDTipoTarefa))
            End If
        End Sub

        Protected Sub Inflate()

            txtTipoTarefa.Text = cls.TipoTarefa
            Me.PageName = cls.TipoTarefa
            lblCriado.Text = cls.Criado
            chkAtivo.Checked = (cls.Ativo = 1)

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.TipoTarefa, cls.IDTipoTarefa)

        End Sub

        Protected Sub Deflate()
            cls.TipoTarefa = txtTipoTarefa.Text
            cls.Ativo = IIf(chkAtivo.Checked, 1, 0)
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.TipoTarefa, cls.IDTipoTarefa)

                Inflate()
                MostraGravado("~/cadastros/TipoTarefa.aspx?idTipoTarefa=" & cls.IDTipoTarefa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.TipoTarefa, cls.IDTipoTarefa)

                cls.Delete()
                Response.Redirect("TipoTarefas.aspx")
            End If
        End Sub
    End Class

End Namespace

