
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Fornecedor
        Inherits XMWebPage
        Dim cls As clsFornecedor
        Protected Const VW_IDFORNECEDOR As String = "IDFornecedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsFornecedor()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta fornecedor?")
                ViewState(VW_IDFORNECEDOR) = Cint("0" & Request("IDFornecedor"))
                cls.Load(ViewState(VW_IDFORNECEDOR))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

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
        End Sub

        Protected Sub Deflate()
            cls.Fornecedor = txtFornecedor.Text
            cls.Concorrente = Not chkConcorrente.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Fornecedor.aspx?idfornecedor=" & cls.idfornecedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Fornecedores.aspx")
        End Sub
    End Class

End Namespace

