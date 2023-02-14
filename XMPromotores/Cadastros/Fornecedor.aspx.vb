
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Fornecedor
        Inherits XMWebEditPage
        Dim cls As clsFornecedor
        Protected Const VW_IDFORNECEDOR As String = "IDFornecedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsFornecedor()
            If Not Page.IsPostBack Then
				'COMBOS

                subAddConfirm(btnApagar, SettingsExpression.GetProperty("texto", "Fornecedor.Mensagens.Mensagem2", "Deseja realmente apagar este fornecedor?"))
                valReqFornecedor.ErrorMessage = SettingsExpression.GetProperty("texto", "Fornecedor.Mensagens.Mensagem5", "Fornecedor é um campo obrigatório!")

                ViewState(VW_IDFORNECEDOR) = Cint("0" & Request("IDFornecedor"))
                cls.Load(ViewState(VW_IDFORNECEDOR))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDFORNECEDOR))
          End If
        End Sub

        Protected Sub Inflate()
			txtFornecedor.Text = cls.Fornecedor
			me.PageName = cls.Fornecedor
            lblCriado.Text = cls.Criado
            chkConcorrente.Checked = Not cls.Concorrente


            'Notify All Observers
            Me.NotifyInflate(enTipoEntidade.Marca, cls.IDFornecedor)

        End Sub

        Protected Sub Deflate()
            cls.Fornecedor = txtFornecedor.Text
            cls.Concorrente = Not chkConcorrente.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()

                'Notify All Observers
                Me.NotifyUpdate(enTipoEntidade.Marca, cls.IDFornecedor)

                Inflate()
                MostraGravado("~/cadastros/Fornecedor.aspx?idfornecedor=" & cls.idfornecedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                'Notify All Observers
                Me.NotifyDelete(enTipoEntidade.Marca, cls.IDFornecedor)

                If cls.Delete() Then
                    Response.Redirect("Fornecedores.aspx")
                Else
                    ShowMsg(SettingsExpression.GetProperty("texto", "Categoria.Mensagens.Mensagem1", "A Marca não pode ser apagada, pois existe(m) produto(s) vinculado(s) a ela!"))
                End If

            End If
        End Sub
    End Class

End Namespace

