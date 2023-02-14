
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Operadora
        Inherits XMWebPage
        Dim cls As clsOperadora
        Protected Const VW_IDOPERADORA As String = "IDOperadora"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsOperadora()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta operadora?")
                ViewState(VW_IDOPERADORA) = Cint("0" & Request("IDOperadora"))
                cls.Load(ViewState(VW_IDOPERADORA))

                btnGravar.Enabled = IIf(cls.isNew(), VerificaPermissao(SecaoAtual, ACAO_ADICIONAR), VerificaPermissao(SecaoAtual, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.isNew(), False, VerificaPermissao(SecaoAtual, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDOPERADORA))
          End If
        End Sub

        Protected Sub Inflate()
			txtOperadora.Text = cls.Operadora
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Operadora = txtOperadora.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Operadora.aspx?idoperadora=" & cls.idoperadora)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Operadoras.aspx")
        End Sub

	
    End Class

End Namespace

