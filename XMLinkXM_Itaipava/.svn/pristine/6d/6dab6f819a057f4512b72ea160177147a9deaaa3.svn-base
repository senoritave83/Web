
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Tabela
        Inherits XMWebPage
		
		Protected Const SECAO as String = "Cadastro de Tabela"
        Dim cls As clsTabela
        Protected Const VW_IDTABELA As String = "IDtabela"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTabela()
            If Not Page.IsPostBack Then
                ViewState(VW_IDTABELA) = Cint("0" & Request("IDtabela"))
                cls.Load(ViewState(VW_IDTABELA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				
				Inflate()
            Else
                cls.Load(ViewState(VW_IDTABELA))
          End If
        End Sub

        Protected Sub Inflate()
			txtTabela.Text = cls.Tabela
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
            chkBonificacao.Checked = cls.Bonificacao
            chkAtivo.Checked = cls.Ativo
            chkAprovacaoManual.Checked = cls.AprovacaoManual
            chkEspecial.Checked = cls.Especial
        End Sub

        Protected Sub Deflate()
			cls.Tabela = txtTabela.Text
            cls.Bonificacao = chkBonificacao.Checked
            cls.Ativo = chkAtivo.Checked
            cls.AprovacaoManual = chkAprovacaoManual.Checked
            cls.Especial = chkEspecial.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Tabela.aspx?idtabela=" & cls.idtabela)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

    End Class

End Namespace

