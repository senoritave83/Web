
Imports Classes

Namespace Pages.Pesquisas

    Partial Public Class Embalagem
        Inherits XMWebPage
		
        Dim cls As clsEmbalagem
        Protected Const VW_IDEMBALAGEM As String = "IDEmbalagem"
        Protected Const Secao As String = "Cadastro de Embalagem"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsEmbalagem()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta embalagem?")
                ViewState(VW_IDEMBALAGEM) = Cint("0" & Request("IDEmbalagem"))
                cls.Load(ViewState(VW_IDEMBALAGEM))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDEMBALAGEM))
          End If
        End Sub

        Protected Sub Inflate()
            txtCodigo.Text = cls.Codigo
            txtEmbalagem.Text = cls.Embalagem
            For Each chk As ListItem In chkTipoPergunta.Items
                If (chk.Value And cls.TipoPergunta) > 0 Then
                    chk.Selected = True
                End If
            Next
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
            cls.Codigo = txtCodigo.Text
            cls.Embalagem = txtEmbalagem.Text
            Dim intTipoPergunta As Integer = 0
            For Each chk As ListItem In chkTipoPergunta.Items
                If chk.Selected = True Then
                    intTipoPergunta = intTipoPergunta + chk.Value
                End If
            Next
            cls.TipoPergunta = intTipoPergunta
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Pesquisas/Embalagem.aspx?idembalagem=" & cls.idembalagem)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
                Response.Redirect("Embalagens.aspx")
			end if
        End Sub

	
    End Class

End Namespace

