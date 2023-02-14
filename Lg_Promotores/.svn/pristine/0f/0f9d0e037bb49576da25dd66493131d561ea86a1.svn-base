
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Resolucao
        Inherits XMWebPage
        Dim cls As clsResolucao
        Protected Const VW_IDRESOLUCAO As String = "IDResolucao"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsResolucao()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta resolucao?")
                ViewState(VW_IDRESOLUCAO) = Cint("0" & Request("IDResolucao"))
                cls.Load(ViewState(VW_IDRESOLUCAO))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDRESOLUCAO))
          End If
        End Sub

        Protected Sub Inflate()
			txtResolucao.Text = cls.Resolucao
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Resolucao = txtResolucao.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Resolucao.aspx?idresolucao=" & cls.idresolucao)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Resolucoes.aspx")
        End Sub

	
    End Class

End Namespace

