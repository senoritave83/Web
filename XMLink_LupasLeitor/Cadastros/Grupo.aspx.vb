
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Grupo
        Inherits XMWebPage
        Dim cls As clsGrupo
        Protected Const VW_IDGRUPO As String = "IDGrupo"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsGrupo()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta grupo?")
                ViewState(VW_IDGRUPO) = Cint("0" & Request("IDGrupo"))
                cls.Load(ViewState(VW_IDGRUPO))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

				Inflate()
            Else
                cls.Load(ViewState(VW_IDGRUPO))
          End If
        End Sub

        Protected Sub Inflate()
			txtGrupo.Text = cls.Grupo
			If cls.Criado = "" Then
                lblCriado.Text = DateTime.Now
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Grupo = txtGrupo.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Grupo.aspx?idgrupo=" & cls.idgrupo)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Grupos.aspx")
        End Sub

	
    End Class

End Namespace

