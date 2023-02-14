
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Justificativa
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Justificativas"
        Dim cls As clsJustificativa
        Protected Const VW_IDJUSTIFICATIVA As String = "IDJustificativa"
        Dim clsniv As New clsNivel

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsJustificativa()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta justificativa?")
                ViewState(VW_IDJUSTIFICATIVA) = Cint("0" & Request("IDJustificativa"))
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                chklNiveisJust.DataSource = clsniv.Listar()
                chklNiveisJust.DataBind()

                Inflate()
            Else
                cls.Load(ViewState(VW_IDJUSTIFICATIVA))
            End If


            'Marca nos checkbox os níveis ref. a justificativa gravados no banco
            For Each item As String In cls.IDNiveis.Split(",")

                For Each li As ListItem In chklNiveisJust.Items
                    If li.Value = item Then
                        li.Selected = True
                    End If
                Next

            Next

        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
			txtJustificativa.Text = cls.Justificativa
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Justificativa = txtJustificativa.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()

                Dim itens As String = ""
                For i As Integer = 0 To chklNiveisJust.Items.Count - 1
                    If chklNiveisJust.Items(i).Selected Then
                        itens += chklNiveisJust.Items(i).Value.ToString() & ","
                    End If
                Next

                If itens <> "" Then
                    clsniv.GravarNiveisJustificativa(cls.IDJustificativa, itens.Remove(itens.Length - 1))
                End If

                MostraGravado("~/Cadastros/Justificativa.aspx?idjustificativa=" & cls.IDJustificativa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Justificativas.aspx")
			end if
        End Sub

	
    End Class

End Namespace

