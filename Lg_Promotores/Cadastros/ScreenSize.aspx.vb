
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class ScreenSize
        Inherits XMWebPage
        Dim cls As clsScreenSize
        Protected Const VW_IDSCREENSIZE As String = "IDScreenSize"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsScreenSize()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta screensize?")
                ViewState(VW_IDSCREENSIZE) = Cint("0" & Request("IDScreenSize"))
                cls.Load(ViewState(VW_IDSCREENSIZE))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDSCREENSIZE))
          End If
        End Sub

        Protected Sub Inflate()
			txtScreenSize.Text = cls.ScreenSize
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.ScreenSize = txtScreenSize.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/ScreenSize.aspx?idscreensize=" & cls.idscreensize)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("ScreenSizes.aspx")
        End Sub

	
    End Class

End Namespace

