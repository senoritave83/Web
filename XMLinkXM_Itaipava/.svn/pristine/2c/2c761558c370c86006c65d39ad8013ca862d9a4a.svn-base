
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Cliente
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Clientes"
        Dim cls As clsCliente
        Protected Const VW_IDCLIENTE As String = "IDCliente"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCliente()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta cliente?")
                ViewState(VW_IDCLIENTE) = Cint("0" & Request("IDCliente"))
                cls.Load(ViewState(VW_IDCLIENTE))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

                'Bind Combos
                Dim uf As New clsUF
                cboUF.DataSource = uf.Listar
                cboUF.DataBind()
                cboUF.Items.Insert(0, New ListItem("TODOS", 0))
				uf = Nothing

                Dim clsGrupoCanal As New clsGrupoCanal
                cboIDGrupoCanal.DataSource = clsGrupoCanal.Listar
                cboIDGrupoCanal.DataBind()
                cboIDGrupoCanal.Items.Insert(0, New ListItem("Selecione o GRUPO...", 0))
                clsGrupoCanal = Nothing

                cboIDCanal.Items.Clear()
                cboIDCanal.Items.Insert(0, New ListItem("Selecione o Canal...", 0))


                Dim pas As New clsPasta
                cboIDPasta.DataSource = pas.Listar
                cboIDPasta.DataBind()
                cboIDPasta.Items.Insert(0, New ListItem("", 0))

                Dim blq As New clsBloqueio
                cboIDBloqueio.DataSource = blq.Listar
                cboIDBloqueio.DataBind()
                cboIDBloqueio.Items.Insert(0, New ListItem("", -1))


				Inflate()
            Else
                cls.Load(ViewState(VW_IDCLIENTE))
          End If
        End Sub


        Private Sub bindGrupoCanal(ByVal p_IDGrupoCanal As Integer)

            Dim clsCanal As clsCanal
            clsCanal = New clsCanal
            cboIDCanal.DataSource = clsCanal.Listar(p_IDGrupoCanal, DataClass.enReturnType.DataReader)
            cboIDCanal.DataBind()
            cboIDCanal.Items.Insert(0, New ListItem("Selecione o CANAL...", 0))
            clsCanal = Nothing

        End Sub

        Protected Sub Inflate()
			txtCliente.Text = cls.Cliente
			txtCNPJ.Text = cls.CNPJ
			txtEndereco.Text = cls.Endereco
			txtBairro.Text = cls.Bairro
			txtCidade.Text = cls.Cidade
			txtCEP.Text = cls.CEP
			SetComboValue(cboUF, cls.UF)
			txtTelefone.Text = cls.Telefone
			txtContato.Text = cls.Contato
			txtObservacao.Text = cls.Observacao
			txtLatitude.Text = cls.Latitude
            txtLongitude.Text = cls.Longitude

            bindGrupoCanal(cls.IDGrupo)
            setComboValue(cboIDGrupoCanal, cls.IDGrupo)
            setComboValue(cboIDCanal, cls.IDCanal)

            setComboValue(cboIDPasta, cls.IDPasta)
			SetComboValue(cboIDBloqueio, cls.IDBloqueio)
            txtLimite.Text = FormatNumber(cls.Limite, 2)
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
        End Sub

        Protected Sub Deflate()
			cls.Cliente = txtCliente.Text
			cls.CNPJ = txtCNPJ.Text
			cls.Endereco = txtEndereco.Text
			cls.Bairro = txtBairro.Text
			cls.Cidade = txtCidade.Text
			cls.CEP = txtCEP.Text
            cls.UF = cboUF.SelectedValue
            cls.IDGrupo = cboIDGrupoCanal.SelectedValue
            cls.IDCanal = cboIDCanal.SelectedValue
			cls.Telefone = txtTelefone.Text
			cls.Contato = txtContato.Text
			cls.Observacao = txtObservacao.Text
			cls.Latitude = txtLatitude.Text
			cls.Longitude = txtLongitude.Text
			cls.IDPasta = cboIDPasta.SelectedValue
			cls.IDBloqueio = cboIDBloqueio.SelectedValue
			cls.Limite = txtLimite.Text
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if


            Deflate()
            If cls.isValid Then
                cls.Update()
                'Inflate()
                MostraGravado("~/Cadastros/Cliente.aspx?idcliente=" & cls.idcliente)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Clientes.aspx")
			end if
        End Sub


        Protected Sub cboIDGrupoCanal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDGrupoCanal.SelectedIndexChanged
            bindGrupoCanal(cboIDGrupoCanal.SelectedValue)
        End Sub

       

    End Class

End Namespace

