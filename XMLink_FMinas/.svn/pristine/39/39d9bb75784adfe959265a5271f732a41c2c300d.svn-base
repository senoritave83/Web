
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Regra
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Regras gerais"
        Dim cls As clsRegra

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRegra()
            If Not Page.IsPostBack Then
                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                Inflate()
            End If
        End Sub

        Protected Sub Inflate()

            lblData.Text = cls.Data
            lblResponsavel.Text = cls.Responsavel
			txtDescontoMax.Text = cls.DescontoMax
        End Sub

        Protected Sub Deflate()
			cls.DescontoMax = txtDescontoMax.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("regra.aspx")
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

    End Class

End Namespace

