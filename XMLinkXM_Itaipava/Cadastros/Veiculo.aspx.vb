
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Veiculo
        Inherits XMWebPage
		
        Dim cls As clsVeiculo
        Protected Const VW_PLACA As String = "Placa"
        Protected Const SECAO As String = "Cadastro de Veiculo"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVeiculo()
            If Not Page.IsPostBack Then
                ViewState(VW_PLACA) = CStr("" & Request("Placa"))
                cls.Load(ViewState(VW_PLACA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_PLACA))
          End If
        End Sub

        Protected Sub Inflate()
            txtVeiculo.Text = cls.Veiculo
            txtPlaca.Text = cls.Placa
            If cls.Placa <> "" Then
                txtSenha.Visible = False
                btnNovaSenha.Visible = True
            Else
                txtSenha.Visible = True
                btnNovaSenha.Visible = False
            End If
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
        End Sub

        Protected Sub Deflate()
			cls.Veiculo = txtVeiculo.Text
			cls.Senha = txtSenha.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Veiculo.aspx?placa=" & cls.placa)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
            txtSenha.Visible = True
            btnNovaSenha.Visible = False
        End Sub
		
	
    End Class

End Namespace

