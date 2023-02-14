
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Frequencia
        Inherits XMWebPage
        Dim cls As clsFrequencia
        Protected Const VW_IDFREQUENCIA As String = "IDFrequencia"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsFrequencia()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta frequencia?")
                ViewState(VW_IDFREQUENCIA) = Cint("0" & Request("IDFrequencia"))
                cls.Load(ViewState(VW_IDFREQUENCIA))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDFREQUENCIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtFrequencia.Text = cls.Frequencia
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Frequencia = txtFrequencia.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Frequencia.aspx?idfrequencia=" & cls.idfrequencia)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Frequencias.aspx")
        End Sub

	
    End Class

End Namespace

