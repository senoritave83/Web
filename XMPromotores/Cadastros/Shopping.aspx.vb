Imports Classes

Partial Class Cadastros_Shopping
    Inherits XMWebEditPage

    Dim cls As clsShopping
    Protected Const VW_IDSHOPPING As String = "IDShopping"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsShopping()
        If Not Page.IsPostBack Then
            subAddConfirm(btnApagar, "Deseja realmente apagar esta shopping?")
            ViewState(VW_IDSHOPPING) = CInt("0" & Request("IDShopping"))
            cls.Load(ViewState(VW_IDSHOPPING))

            btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
            btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
            btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

            Inflate()
        Else
            cls.Load(ViewState(VW_IDSHOPPING))
        End If
    End Sub

    Protected Sub Inflate()
        txtShopping.Text = cls.Shopping
        Me.PageName = cls.Shopping
        lblCriado.Text = cls.Criado

        'Notify All Observers
        Me.NotifyInflate(enTipoEntidade.Shopping, cls.IDShopping)

    End Sub

    Protected Sub Deflate()
        cls.Shopping = txtShopping.Text
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        Deflate()
        If cls.isValid Then
            cls.Update()

            'Notify All Observers
            Me.NotifyUpdate(enTipoEntidade.Shopping, cls.IDShopping)

            Inflate()
            MostraGravado("~/cadastros/Shopping.aspx?idshopping=" & cls.idshopping)
        End If
        lstErros.DataSource = cls.BrokenRules
        lstErros.DataBind()

    End Sub

    Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
        If VerificaPermissao(Secao, ACAO_APAGAR) Then

            'Notify All Observers
            Me.NotifyDelete(enTipoEntidade.Shopping, cls.IDShopping)

            cls.Delete()
            Response.Redirect("Shoppings.aspx")
        End If
    End Sub

End Class
