
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Regiao
        Inherits XMWebPage
        Dim cls As clsRegiao
        Protected Const VW_IDREGIAO As String = "IDRegiao"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRegiao()
            If Not Page.IsPostBack Then
				'COMBOS
                subAddConfirm(btnApagar, "Deseja realmente apagar esta regiao?")
                ViewState(VW_IDREGIAO) = Cint("0" & Request("IDRegiao"))
                cls.Load(ViewState(VW_IDREGIAO))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDREGIAO))
          End If
        End Sub

        Protected Sub Inflate()
			txtRegiao.Text = cls.Regiao
			me.PageName = cls.Regiao
			lblCriado.Text = cls.Criado
        End Sub

        Protected Sub Deflate()
			cls.Regiao = txtRegiao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/cadastros/Regiao.aspx?idregiao=" & cls.idregiao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Regioes.aspx")
        End Sub
    End Class

End Namespace

