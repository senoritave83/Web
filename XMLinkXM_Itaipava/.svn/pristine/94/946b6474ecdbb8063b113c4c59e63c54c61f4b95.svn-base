
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Regional
        Inherits XMWebPage
		
        Dim cls As clsRegional
        Protected Const VW_IDREGIONAL As String = "IDRegional"
        Protected Const SECAO As String = "Cadastro de Regionais"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRegional()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta regional?")
                ViewState(VW_IDREGIONAL) = Cint("0" & Request("IDRegional"))
                cls.Load(ViewState(VW_IDREGIONAL))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
				btnApagar.Enabled = iif(cls.IsNew(), false, VerificaPermissao(Secao, ACAO_APAGAR))

                BindComboSuperiores()


                Inflate()
                BindRevendasSelecionadas()
                BindRegionaisSubordinadas()
            Else
                cls.Load(ViewState(VW_IDREGIONAL))
          End If
        End Sub

        Protected Sub BindComboSuperiores()

            If cls.IsNew Then
                cboIDSuperior.DataSource = cls.Listar()
                cboIDSuperior.DataBind()
                cboIDSuperior.Items.Insert(0, New ListItem("", 0))
            Else
                cboIDSuperior.DataSource = cls.ListarRegionaisPossiveisSuperiores(cls.IDRegional)
                cboIDSuperior.DataBind()
                cboIDSuperior.Items.Insert(0, New ListItem("", 0))
            End If

        End Sub

        Protected Sub BindRegionaisSubordinadas()
            If cls.IDRegional = 0 Then
                grdRegionaisSubordinadas.DataSource = Nothing
            Else
                grdRegionaisSubordinadas.DataSource = cls.ListarRegionaisSubordinadas(cls.IDRegional)
                grdRegionaisSubordinadas.DataBind()
            End If
        End Sub

        Protected Sub Inflate()
			txtRegional.Text = cls.Regional
            setComboValue(cboIDSuperior, cls.IDSuperior)
            plhRegionaisSubordinadas.Visible = Not cls.IsNew
            plhRevendas.Visible = Not cls.IsNew
            
        End Sub

        Protected Sub Deflate()
			cls.Regional = txtRegional.Text
            cls.IDSuperior = cboIDSuperior.SelectedValue
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()
                Inflate()
                MostraGravado("~/Cadastros/Regional.aspx?idregional=" & cls.idregional)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Regionais.aspx")
			end if
        End Sub


#Region "Tabela de Revendas"

        Protected Sub BindRevendasSelecionadas()
            If cls.IDRegional = 0 Then
                grdEmpresas.DataSource = Nothing
            Else
                grdEmpresas.DataSource = cls.ListarEmpresas()
                grdEmpresas.DataBind()
            End If
        End Sub

        Protected Sub BindRevendas(ByVal vFiltro As String)
            If cls.IDRegional = 0 Then
                grdEmpresas.DataSource = Nothing
            Else
                Dim emp As New clsEmpresa
                grdEmpresas.DataSource = emp.Listar(vFiltro)
                grdEmpresas.DataBind()
            End If
        End Sub

        Protected Sub chk_OnCheckedChange(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim checkbox As CheckBox = CType(sender, CheckBox)
            Dim row As GridViewRow = CType(checkbox.NamingContainer, GridViewRow)
            Dim intIDEmpresa As Integer = grdEmpresas.DataKeys(row.DataItemIndex).Item(0)
            If cls.IsEmpresaInRegional(intIDEmpresa) Then
                If checkbox.Checked = False Then cls.RemoveEmpresaToRegional(intIDEmpresa)
            Else
                If checkbox.Checked = True Then cls.AddEmpresaToRegional(intIDEmpresa)
            End If
        End Sub

        Protected Sub grdEmpresas_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdEmpresas.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    CType(e.Row.FindControl("chk"), CheckBox).Checked = cls.IsEmpresaInRegional(grdEmpresas.DataKeys(e.Row.RowIndex).Value)
                Catch ex As Exception

                End Try
            End If
        End Sub


        Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
            BindRevendas(txtFiltro.Text)
        End Sub

        Protected Sub Letras1_Item_Selected(ByVal vLetra As String) Handles Letras1.Item_Selected
            BindRevendas(vLetra)
        End Sub

#End Region
	
    End Class

End Namespace

