Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Empresa
        Inherits XMWebPage

        Dim cls As clsEmpresa
        Protected Const SECAO As String = "Configuração da Revenda"
        Protected Const ACAO_BONIFICACAO As String = "Liberar Bonificação"
        Protected Const ACAO_PRECO_LIVRE As String = "Liberar Preço Livre"
        Protected Const ACAO_PERMITEFORAROTA As String = "Permitir Fora de Rota"
        Protected Const ACAO_LIMITE_CREDITO As String = "Aplicar regra LIMITE DE CRÉDITO do cliente"
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsEmpresa()
            If Not Page.IsPostBack Then                				

                btnGravar.Enabled = VerificaPermissao(SECAO, ACAO_EDITAR)
                trPermiteBonificacao.Visible = VerificaPermissao(SECAO, ACAO_BONIFICACAO)
                trPermitePrecoLivre.Visible = VerificaPermissao(SECAO, ACAO_PRECO_LIVRE)
                trPermiteForaRota.Visible = VerificaPermissao(SECAO, ACAO_PERMITEFORAROTA)
                trLimiteCredito.Visible = VerificaPermissao(SECAO, ACAO_LIMITE_CREDITO)

                Inflate()

          End If
        End Sub

        Protected Sub Inflate()			
			txtLatitude.Text = cls.Latitude
			txtLongitude.Text = cls.Longitude
			chkPermiteBonificacao.Checked = cls.PermiteBonificacao
            chkPermitePrecoLivre.Checked = cls.PermitePrecoLivre
            chkPermiteForaRota.Checked = cls.PermiteForaRota
            txtTransacaoBonificacao.Text = cls.TransacaoBonificacao
            txtTransacaoVenda.Text = cls.TransacaoVenda
            chkLimiteCreditoCliente.Checked = cls.AplicaLimiteCreditoCliente
        End Sub

        Protected Sub Deflate()		
			cls.Latitude = txtLatitude.Text
			cls.Longitude = txtLongitude.Text
			cls.PermiteBonificacao = chkPermiteBonificacao.Checked
            cls.PermitePrecoLivre = chkPermitePrecoLivre.Checked
            cls.TransacaoBonificacao = CInt(txtTransacaoBonificacao.Text)
            cls.TransacaoVenda = CInt(txtTransacaoVenda.Text)
            cls.PermiteForaRota = chkPermiteForaRota.Checked
            cls.AplicaLimiteCreditoCliente = chkLimiteCreditoCliente.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
            If (VerificaPermissao(SECAO, ACAO_EDITAR) = False) Then
                Exit Sub
            End If
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Empresa.aspx")
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub
	
    End Class

End Namespace

