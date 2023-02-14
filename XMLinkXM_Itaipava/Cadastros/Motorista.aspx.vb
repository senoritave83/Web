
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Motorista
        Inherits XMWebPage
		
        Dim cls As clsMotorista
        Protected Const VW_IDMOTORISTA As String = "IDMotorista"
        Protected Const SECAO As String = "Cadastro de Motoristas"
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsMotorista()
            If Not Page.IsPostBack Then
                ViewState(VW_IDMOTORISTA) = CInt("0" & Request("IDMotorista"))
                cls.Load(ViewState(VW_IDMOTORISTA))
				
                btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDMOTORISTA))
          End If
        End Sub

        Protected Sub Inflate()
			txtMotorista.Text = cls.Motorista
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
			chkAtivo.Checked = cls.Ativo
        End Sub

        Protected Sub Deflate()
			cls.Motorista = txtMotorista.Text
			cls.Ativo = chkAtivo.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Motorista.aspx?idmotorista=" & cls.idmotorista)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

    End Class

End Namespace

