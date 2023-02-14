
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Cliente
        Inherits XMWebPage
        Dim cls As clsCliente
        Protected Const VW_IDCLIENTE As String = "IDCliente"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCliente()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta cliente?")
                ViewState(VW_IDCLIENTE) = Cint("0" & Request("IDCliente"))
                cls.Load(ViewState(VW_IDCLIENTE))
                btnGravar.Enabled = VerificaPermissao(SecaoAtual, ACAO_EDITAR)
                btnNovo.Disabled = Not VerificaPermissao(SecaoAtual, ACAO_ADICIONAR)
                btnApagar.Enabled = VerificaPermissao(SecaoAtual, ACAO_APAGAR)

                Dim ven As New clsVendedor
                cboIDVendedor.DataSource = ven.Listar
                cboIDVendedor.DataBind()
                cboIDVendedor.Items.Insert(0, New ListItem("Selecione...", "0"))
                ven = Nothing

                Dim cliRef As New clsClienteReferencia
                drpReferencia.DataSource = cliRef.Listar
                drpReferencia.DataBind()
                drpReferencia.Items.Insert(0, New ListItem("NENHUMA REFERENCIA SELECIONADA", ""))
                cliRef = Nothing

                pnlVendedores.Visible = cls.IDCliente > 0

                Inflate()
            Else
                cls.Load(ViewState(VW_IDCLIENTE))
            End If
        End Sub


        Protected Sub BindVendedores()
            grdVendedores.DataSource = cls.ListarVendedores
            grdVendedores.DataBind()

            cboIDVendedor.Enabled = IIf(grdVendedores.Rows.Count > 0, False, True)
            btnAddVendedor.Enabled = IIf(grdVendedores.Rows.Count > 0, False, True)
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
            txtCliente.Text = cls.Cliente
			txtCNPJ.Text = cls.CNPJ
			txtEndereco.Text = cls.Endereco
            setComboValue(drpReferencia, cls.Referencia)
			txtBairro.Text = cls.Bairro
			txtCidade.Text = cls.Cidade
			txtCEP.Text = cls.CEP
			SetComboValue(cboUF, cls.UF)
			txtTelefone.Text = cls.Telefone
            txtContato.Text = cls.Contato
            TxtEmail.Text = cls.Email
			txtObservacao.Text = cls.Observacao
			If cls.Criado = "" Then
                DataCriado.Text = DateTime.Now
			Else
                DataCriado.Text = cls.Criado
			End If
			txtTabelaPreco.Text = cls.TabelaPreco
			txtDescontoMax.Text = cls.DescontoMax
            txtLimiteCredito.Text = cls.LimiteCredito.ToString("#0.00")
            txtNomeFantasia.Text = cls.NomeFantasia
            chkBloqueado.Checked = cls.Bloqueado
            BindVendedores()
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
            cls.Cliente = txtCliente.Text
			cls.CNPJ = txtCNPJ.Text
			cls.Endereco = txtEndereco.Text
            cls.Referencia = getComboValues(drpReferencia)
			cls.Bairro = txtBairro.Text
			cls.Cidade = txtCidade.Text
			cls.CEP = txtCEP.Text
			cls.UF = cboUF.SelectedValue
			cls.Telefone = txtTelefone.Text
            cls.Contato = txtContato.Text
            cls.Email = TxtEmail.Text
			cls.Observacao = txtObservacao.Text
			cls.TabelaPreco = txtTabelaPreco.Text
			cls.DescontoMax = txtDescontoMax.Text
            cls.LimiteCredito = txtLimiteCredito.Text
            cls.NomeFantasia = txtNomeFantasia.Text
            cls.Criado = DataCriado.Text
            cls.Bloqueado = chkBloqueado.Checked
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Cliente.aspx?idcliente=" & cls.IDCliente)
                'MostraGravado("~/Cadastros/Clientes.aspx")
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            cls.Delete()
            Response.Redirect("Clientes.aspx")
        End Sub

        Protected Sub btnAddVendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddVendedor.Click
            cls.AdicionarVendedor(cboIDVendedor.SelectedValue)
            BindVendedores()
            cboIDVendedor.SelectedIndex = -1
        End Sub

        Protected Sub grdVendedores_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdVendedores.RowCommand
            If e.CommandName = "Excluir" Then
                cls.RetirarVendedor(e.CommandArgument)
            End If
            BindVendedores()
        End Sub
    End Class

End Namespace

