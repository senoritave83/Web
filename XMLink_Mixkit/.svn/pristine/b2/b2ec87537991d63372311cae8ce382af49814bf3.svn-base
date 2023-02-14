
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
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

                Inflate()
            Else
                cls.Load(ViewState(VW_IDCLIENTE))
          End If
        End Sub

        Protected Sub Inflate()
			txtCodigo.Text = cls.Codigo
            txtCliente.Text = cls.Cliente
			txtCNPJ.Text = cls.CNPJ
			txtEndereco.Text = cls.Endereco
			txtReferencia.Text = cls.Referencia
			txtBairro.Text = cls.Bairro
			txtCidade.Text = cls.Cidade
			txtCEP.Text = cls.CEP
            txtUF.Text = cls.UF
			txtTelefone.Text = cls.Telefone
			txtContato.Text = cls.Contato
			txtObservacao.Text = cls.Observacao
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
			End If
            txtCorrecao.Value = cls.TabelaPreco
			txtDescontoMax.value = cls.DescontoMax
            txtLimiteCredito.Text = FormatNumber(cls.LimiteCredito, 2)

            BindCboLinhaNegocio()
            BindGridLinhaNegocio()
            BindVendedores()
        End Sub

        Protected Sub Deflate()
			cls.Codigo = txtCodigo.Text
			cls.Cliente = txtCliente.Text
			cls.CNPJ = txtCNPJ.Text
			cls.Endereco = txtEndereco.Text
			cls.Referencia = txtReferencia.Text
			cls.Bairro = txtBairro.Text
			cls.Cidade = txtCidade.Text
			cls.CEP = txtCEP.Text
            cls.UF = txtUF.Text
			cls.Telefone = txtTelefone.Text
			cls.Contato = txtContato.Text
			cls.Observacao = txtObservacao.Text
            cls.TabelaPreco = txtCorrecao.Value
			cls.DescontoMax = txtDescontoMax.value
			cls.LimiteCredito = txtLimiteCredito.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Cliente.aspx?idcliente=" & cls.idcliente)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Clientes.aspx")
			end if
        End Sub


#Region "Vendedores"
        Protected lstVendedoresCadastrados As New System.Collections.Generic.List(Of Integer)

        Protected Sub BindVendedores()
            grdVendedores.DataSource = cls.Vendedores.Listar
            grdVendedores.DataBind()
            cboNovoVendedor.Items.Clear()
            Dim ven As New clsVendedor
            Dim dr As System.Data.IDataReader = ven.Listar()
            Do While dr.Read
                If Not lstVendedoresCadastrados.Contains(dr.GetInt32(dr.GetOrdinal("IDVendedor"))) Then
                    cboNovoVendedor.Items.Add(New ListItem(dr.GetString(dr.GetOrdinal("Vendedor")), dr.GetInt32(dr.GetOrdinal("IDVendedor"))))
                End If
            Loop
            cboNovoVendedor.Items.Insert(0, New ListItem("Selecione...", 0))
        End Sub

        Protected Sub btnAdicionarVendedor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdicionarVendedor.Click
            If cboNovoVendedor.SelectedIndex > 0 Then
                cls.Vendedores.Add(cboNovoVendedor.SelectedValue)
                BindVendedores()
            End If
        End Sub


        Protected Sub grdVendedores_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdVendedores.RowCommand
            If e.CommandName = "RetirarVendedor" Then
                Dim iIDVendedor As Integer = grdVendedores.DataKeys(e.CommandArgument).Value
                cls.Vendedores.Delete(iIDVendedor)
                BindVendedores()
            End If
        End Sub

        Protected Sub grdVendedores_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVendedores.RowCreated
            If e.Row.RowType = DataControlRowType.DataRow Then
                lstVendedoresCadastrados.Add(grdVendedores.DataKeys(e.Row.RowIndex).Value)
            End If
        End Sub

#End Region


#Region "Linha de Negócio"

        Protected Sub BindCboLinhaNegocio()
            Dim lng As New clsLinhaNegocio
            cboLinhaNegocio.DataSource = lng.Listar()
            cboLinhaNegocio.DataBind()
            cboLinhaNegocio.Items.Insert(0, New ListItem("Selecione...", 0))
        End Sub

        Protected Sub BindGridLinhaNegocio()

            grdLinhaNegocio.DataSource = cls.IDLinhaNegocio.Listar
            grdLinhaNegocio.DataBind()
        End Sub

        Protected Sub btnAddLinhaNegocio_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddLinhaNegocio.Click
            If cboLinhaNegocio.SelectedIndex > 0 Then
                cls.IDLinhaNegocio.Add(cboLinhaNegocio.SelectedValue)
                BindGridLinhaNegocio()
            End If
        End Sub


        Protected Sub grdLinhaNegocio_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLinhaNegocio.RowCommand
            If e.CommandName = "RetirarLinhaNegocio" Then
                Dim IdLinhaNegocio As Integer = grdLinhaNegocio.DataKeys(e.CommandArgument).Value
                cls.IDLinhaNegocio.Delete(IdLinhaNegocio)
                BindGridLinhaNegocio()
            End If
        End Sub

#End Region

    End Class

End Namespace

