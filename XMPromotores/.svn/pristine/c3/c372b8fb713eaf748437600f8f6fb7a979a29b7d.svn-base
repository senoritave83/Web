Imports System.Configuration.ConfigurationManager
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Cargo
        Inherits XMWebPage
		
        Dim cls As clsCargo
        Protected Const VW_IDCARGO As String = "IDCargo"

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsCargo()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta cargo?")
                ViewState(VW_IDCARGO) = CInt("0" & Request("IDCargo"))
                cls.Load(ViewState(VW_IDCARGO))

                btnGravar.Enabled = IIf(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
                btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                CarregarModulos()

                cboSuperior.DataSource = cls.Listar
                cboSuperior.DataBind()
                cboSuperior.Items.Insert(0, New ListItem("Não tem", "0"))
                If cls.IDCargo > 0 Then
                    cboSuperior.Items.Remove(cboSuperior.Items.FindByValue(cls.IDCargo))
                End If

                Inflate()
                BindRoles()
            Else
                cls.Load(ViewState(VW_IDCARGO))
            End If
        End Sub

        Private Sub CarregarModulos()

            Dim mods As New clsModulo
            Dim dr As System.Data.SqlClient.SqlDataReader = mods.Listar()

            Do While dr.Read
                If dr("IdModulo") = 2 Then
                    Dim m_CargosPermitidos As String = AppSettings("CargosPermitidosNaPesquisa") & ""
                    If m_CargosPermitidos <> "" Then m_CargosPermitidos = "," & m_CargosPermitidos & ","
                    If m_CargosPermitidos = "" Or m_CargosPermitidos.IndexOf(cls.IDCargo) > 0 Then
                        chkModulos.Items.Add(New ListItem(dr("Modulo"), dr("IdModulo")))
                    End If
                Else
                    chkModulos.Items.Add(New ListItem(dr("Modulo"), dr("IdModulo")))
                End If

            Loop

            mods = Nothing

        End Sub

        Protected Sub BindRoles()
            Dim per As New clsPermissao
            grdRoles.DataSource = per.Listar()
            grdRoles.DataBind()
            per = Nothing
        End Sub

        Protected Sub Inflate()
			txtCargo.Text = cls.Cargo
            cboSuperior.SelectedValue = cls.IDSuperior
			If cls.Criado = "" Then
			    lblCriado.Text = "Sem data de cria&ccedil;&atilde;o"
			Else
			    lblCriado.Text = cls.Criado
            End If
            For Each it As ListItem In chkModulos.Items
                it.Selected = ((it.Value And cls.Modulos) > 0)
            Next
            cboAdicionarLoja.SelectedValue = cls.AdicionarLoja

        End Sub

        Protected Sub Deflate()
			cls.Cargo = txtCargo.Text
            cls.IDSuperior = cboSuperior.SelectedValue
            cls.Modulos = 0
            cls.AdicionarLoja = cboAdicionarLoja.SelectedValue
            For Each it As ListItem In chkModulos.Items
                If (it.Selected) Then
                    cls.Modulos += it.Value
                End If
            Next
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click
			
			if (cls.IsNew() and VerificaPermissao(Secao, ACAO_ADICIONAR) = false) OR (cls.IsNew() = false and VerificaPermissao(Secao, ACAO_EDITAR) = false) Then  
				Exit Sub
			end if
			
            Deflate()
            If cls.isValid Then
                cls.Update()

                For Each row As GRidViewRow In grdRoles.Rows
                    If row.RowType = DataControlRowType.DataRow Then
                        Dim chk As CheckBox = CType(row.FindControl("chk"), CheckBox)
                        Dim intIDPermissao As Integer = grdRoles.DataKeys(row.DataItemIndex).Item(0)
                        If cls.Permissoes.Contains(intIDPermissao) Then
                            If Not chk.Checked Then
                                cls.Permissoes.Delete(intIDPermissao)
                            End If
                        Else
                            If chk.Checked Then
                                cls.Permissoes.Add(intIDPermissao)
                            End If
                        End If
                    End If
                Next
                Inflate()
                MostraGravado("~/Sistema/Cargo.aspx?idcargo=" & cls.IDCargo)
            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
			if VerificaPermissao(Secao, ACAO_APAGAR) then 
				cls.Delete()
				Response.Redirect("Cargos.aspx")
			end if
        End Sub


        Protected Sub grdRoles_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRoles.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Try
                    CType(e.Row.FindControl("chk"), CheckBox).Checked = cls.Permissoes.Contains(grdRoles.DataKeys(e.Row.RowIndex).Value)
                Catch ex As Exception

                End Try
            End If
        End Sub


    End Class

End Namespace

