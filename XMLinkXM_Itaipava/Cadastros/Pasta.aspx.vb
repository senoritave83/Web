
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Pasta
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Pastas"
        Dim cls As clsPasta
        Protected Const VW_IDPASTA As String = "IDPasta"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsPasta()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta pasta?")
                ViewState(VW_IDPASTA) = Cint("0" & Request("IDPasta"))
                cls.Load(ViewState(VW_IDPASTA))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                'Bind Combos
                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("TODOS", 0))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDPASTA))
          End If
        End Sub

        Protected Sub BindClientesPasta()
            grdClientes.DataSource = cls.ListarClientesPasta(cls.IDPasta)
            grdClientes.DataBind()
        End Sub

        Protected Sub Inflate()

            setComboValue(cboIDVendedor, cls.IDVendedor)
            txtDescricao.Text = cls.Descricao
            Roteiro1.DiaSemana = cls.Dias

            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If

            BindClientesPasta()

        End Sub

        Protected Sub Deflate()
			cls.IDVendedor = cboIDVendedor.SelectedValue
			cls.Descricao = txtDescricao.Text
            cls.Dias = Roteiro1.DiaSemana
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Pasta.aspx?idpasta=" & cls.idpasta)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Pastas.aspx")
			end if
        End Sub

	
    End Class

End Namespace

