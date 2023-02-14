
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Categoria
        Inherits XMWebPage
        Dim cls As clsCategoria
        Protected Const VW_IDCATEGORIA As String = "IDCategoria"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCategoria()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta categoria?")
                ViewState(VW_IDCATEGORIA) = Cint("0" & Request("IDCategoria"))
                cls.Load(ViewState(VW_IDCATEGORIA))
				btnGravar.Enabled = Me.User.IsInRole("Cadastrador")
				btnNovo.Disabled = Not btnGravar.Enabled
				btnApagar.Enabled = Me.User.IsInRole("Supervisor de Cadastro")

				Inflate()
            Else
                cls.Load(ViewState(VW_IDCATEGORIA))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
            txtCategoria.Text = cls.Categoria
            DataCriado.Text = cls.Criado
            If cls.Criado = "" Then
                DataCriado.Text = DateTime.Now
            Else
                DataCriado.Text = cls.Criado
            End If

        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
            cls.Categoria = txtCategoria.Text
            cls.Criado = DataCriado.Text

        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Categorias.aspx?idcategoria=" & cls.IDCategoria)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Categorias.aspx")
        End Sub

	
    End Class

End Namespace

