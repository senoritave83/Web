
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Cliente
        Inherits XMWebEditPage
        Dim cls As clsCliente
        Protected Const VW_IDCLIENTE As String = "IDCliente"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCliente()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta revenda?")
                ViewState(VW_IDCLIENTE) = Cint("0" & Request("IDCliente"))
                cls.Load(ViewState(VW_IDCLIENTE))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDCLIENTE))
          End If
        End Sub

        Protected Sub Inflate()
			txtRazaoSocial.Text = cls.RazaoSocial
			me.PageName = cls.RazaoSocial
            txtFantasia.Text = cls.Fantasia

            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Loja, cls.IDCliente)

        End Sub

        Protected Sub Deflate()
			cls.RazaoSocial = txtRazaoSocial.Text
			cls.Fantasia = txtFantasia.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Cliente, cls.IDCliente)

                Inflate()
                MostraGravado("~/cadastros/Cliente.aspx?idcliente=" & cls.idcliente)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Cliente, cls.IDCliente)

                cls.Delete()
                Response.Redirect("Clientes.aspx")
            End If
        End Sub
    End Class

End Namespace

