
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
				
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDGRUPO))
          End If
        End Sub

        Protected Sub Inflate()
            txtGrupo.Text = cls.Grupo
            rdStatus.SelectedValue = cls.IdStatus
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
            cls.Grupo = txtGrupo.Text
            cls.IdStatus = rdStatus.SelectedItem.Value
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

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
            If VerificaPermissao(Secao, ACAO_APAGAR) Then
                cls.Delete()
                Response.Redirect("Grupos.aspx")
            End If
            
        End Sub

	
    End Class

End Namespace

