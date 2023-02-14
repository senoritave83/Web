
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class CategoriaCombinada
        Inherits XMWebPage
        Dim cls As clsCategoriaCombinada
        Protected Const VW_IDCATEGORIACOMBINADA As String = "IDCategoriaCombinada"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCategoriaCombinada()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta categoriacombinada?")
                ViewState(VW_IDCATEGORIACOMBINADA) = Cint("0" & Request("IDCategoriaCombinada"))
                cls.Load(ViewState(VW_IDCATEGORIACOMBINADA))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCATEGORIACOMBINADA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCategoriaCombinada.Text = cls.CategoriaCombinada
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.CategoriaCombinada = txtCategoriaCombinada.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/CategoriaCombinada.aspx?idcategoriacombinada=" & cls.idcategoriacombinada)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("CategoriaCombinadas.aspx")
        End Sub

	
    End Class

End Namespace

