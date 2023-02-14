
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoLoja
        Inherits XMWebEditPage

        Dim cls As clsTipoLoja
        Protected Const VW_IDTIPOLOJA As String = "IDTipoLoja"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoLoja()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta tipoloja?")
                ViewState(VW_IDTIPOLOJA) = Cint("0" & Request("IDTipoLoja"))
                cls.Load(ViewState(VW_IDTIPOLOJA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDTIPOLOJA))
          End If
        End Sub

        Protected Sub Inflate()
			txtTipoLoja.Text = cls.TipoLoja
			me.PageName = cls.TipoLoja
			lblCriado.Text = cls.Criado

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.TipoLoja, cls.IDTipoLoja)

        End Sub

        Protected Sub Deflate()
			cls.TipoLoja = txtTipoLoja.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.TipoLoja, cls.IDTipoLoja)

                Inflate()
                MostraGravado("~/cadastros/TipoLoja.aspx?idtipoloja=" & cls.idtipoloja)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.TipoLoja, cls.IDTipoLoja)

                cls.Delete()
                Response.Redirect("TipoLojas.aspx")
            End If
        End Sub
    End Class

End Namespace

