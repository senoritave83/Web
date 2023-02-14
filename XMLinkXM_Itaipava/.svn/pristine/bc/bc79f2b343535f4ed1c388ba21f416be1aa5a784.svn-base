
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class TipoVendedor
        Inherits XMWebPage

        Protected Const SECAO As String = "Cadastro de Tipo do Vendedor"
        Dim cls As clsTipoVendedor
        Protected Const VW_IDTIPOVENDEDOR As String = "IDTipoVendedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsTipoVendedor()
            If Not Page.IsPostBack Then

                If User.IDEmpresa <> 0 Then
                    Response.Redirect("default.aspx")
                End If

                subAddConfirm(btnApagar, "Deseja realmente apagar esta tipovendedor?")
                ViewState(VW_IDTIPOVENDEDOR) = CInt("0" & Request("IDTipoVendedor"))
                cls.Load(ViewState(VW_IDTIPOVENDEDOR))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(SECAO, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDTIPOVENDEDOR))
            End If
        End Sub

        Protected Sub Inflate()
			txtTipoVendedor.Text = cls.TipoVendedor
			txtFuso.Text = cls.Fuso
        End Sub

        Protected Sub Deflate()
			cls.TipoVendedor = txtTipoVendedor.Text
			cls.Fuso = txtFuso.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/TipoVendedor.aspx?idtipovendedor=" & cls.idtipovendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("TipoVendedores.aspx")
			end if
        End Sub

	
    End Class

End Namespace

