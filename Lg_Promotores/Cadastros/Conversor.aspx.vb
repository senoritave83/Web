
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Conversor
        Inherits XMWebPage
        Dim cls As clsConversor
        Protected Const VW_IDCONVERSOR As String = "IDConversor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsConversor()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta conversor?")
                ViewState(VW_IDCONVERSOR) = Cint("0" & Request("IDConversor"))
                cls.Load(ViewState(VW_IDCONVERSOR))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCONVERSOR))
          End If
        End Sub

        Protected Sub Inflate()
			txtConversor.Text = cls.Conversor
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Conversor = txtConversor.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Conversor.aspx?idconversor=" & cls.idconversor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Conversores.aspx")
        End Sub

	
    End Class

End Namespace

