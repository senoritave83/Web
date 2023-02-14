
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Vendedor
        Inherits XMWebPage
		
        Protected Const SECAO As String = "Cadastro de Vendedores"
        Dim cls As clsVendedor
        Protected Const VW_IDVENDEDOR As String = "IDVendedor"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVendedor()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta vendedor?")
                ViewState(VW_IDVENDEDOR) = Cint("0" & Request("IDVendedor"))
                cls.Load(ViewState(VW_IDVENDEDOR))

                Dim niv As New clsNivel
                cboIDNivel.DataSource = niv.Listar()
                cboIDNivel.DataBind()
                cboIDNivel.Items.Insert(0, New ListItem("", 0))

                Dim tpv As New clsTipoVendedor
                cboTipoVendedor.DataSource = tpv.Listar()
                cboTipoVendedor.DataBind()
                cboTipoVendedor.Items.Insert(0, New ListItem("", 0))

				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(SECAO, ACAO_ADICIONAR), VerificaPermissao(SECAO, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(SECAO, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(SECAO, ACAO_APAGAR))

				Inflate()
            Else
                cls.Load(ViewState(VW_IDVENDEDOR))
          End If
        End Sub

        Protected Sub Inflate()
			txtVendedor.Text = cls.Vendedor
			txtTelefone.Text = cls.Telefone
			txtLogin.Text = cls.Login
			If cls.IDVendedor > 0 Then
				txtSenha.Visible = False
				btnNovaSenha.Visible = True
			Else
				txtSenha.Visible = True
				btnNovaSenha.Visible = False
			End If
            txtID.Text = cls.ID
            chkTeste.Checked = cls.Teste
            chkEspecial.Checked = cls.Especial
            setComboValue(cboIDNivel, cls.IDNivel)
            cboTipoVendedor.SelectedIndex = cls.IDTipoVendedor
            If cls.Criado = "" Then
                lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
            Else
                lblCriado.Text = cls.Criado
            End If
            BindGrupos()
            BindTabelas()
        End Sub

        Protected Sub BindGrupos()

            Dim grp As New clsGrupo
            Dim dr As System.Data.IDataReader = grp.Listar(cls.IDVendedor)
            lstGrupos.Items.Clear()
            While dr.Read
                Dim li As New ListItem(dr.GetString(dr.GetOrdinal(lstGrupos.DataTextField)), dr.GetInt32(dr.GetOrdinal(lstGrupos.DataValueField)))
                li.Selected = dr.GetInt32(dr.GetOrdinal("Selecionado"))
                lstGrupos.Items.Add(li)
            End While

        End Sub

        Protected Sub BindTabelas()

            Dim tab As New clsTabela
            Dim dr As System.Data.IDataReader = tab.Listar(cls.IDVendedor)
            lstTabelas.Items.Clear()
            While dr.Read
                Dim li As New ListItem(dr.GetString(dr.GetOrdinal(lstTabelas.DataTextField)), dr.GetInt32(dr.GetOrdinal(lstTabelas.DataValueField)))
                li.Selected = dr.GetInt32(dr.GetOrdinal("Selecionado"))
                If dr.GetBoolean(dr.GetOrdinal("Ativo")) = False Then
                    li.Attributes.Add("style", "color: red;")
                ElseIf dr.GetBoolean(dr.GetOrdinal("Especial")) = True Then
                    li.Attributes.Add("style", "color: blue;")
                End If
                lstTabelas.Items.Add(li)
            End While

        End Sub


        Protected Sub Deflate()
			cls.Vendedor = txtVendedor.Text
			cls.Telefone = txtTelefone.Text
			cls.Login = txtLogin.Text
			cls.Senha = txtSenha.Text
            cls.ID = txtID.Text
            cls.Teste = chkTeste.Checked
            cls.Especial = chkEspecial.Checked
            cls.IDNivel = cboIDNivel.SelectedValue
            cls.IDTipoVendedor = cboTipoVendedor.SelectedIndex
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(SECAO, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(SECAO, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()

                Dim grp As New clsGrupo
                'Grava os grupos ao qual pertence
                For Each li As ListItem In lstGrupos.Items
                    grp.GravaGrupoVendedor(cls.IDVendedor, li.Value, li.Selected)
                Next

                Dim tab As New clsTabela
                'Grava as tabelas pertencentes ao Vendedor
                For Each li As ListItem In lstTabelas.Items
                    tab.GravaTabelasVendedor(cls.IDVendedor, li.Value, li.Selected)
                Next

                Inflate()
                MostraGravado("~/Cadastros/Vendedor.aspx?idvendedor=" & cls.idvendedor)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(SECAO, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Vendedores.aspx")
			end if
        End Sub

		Protected Sub btnNovaSenha_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovaSenha.Click
			txtSenha.Visible = True
			btnNovaSenha.Visible = False
		End Sub		
		
	
    End Class

End Namespace

