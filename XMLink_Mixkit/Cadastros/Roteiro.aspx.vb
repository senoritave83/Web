
Imports Classes

Namespace Pages.Cadastros

    Partial Public Class Roteiro
        Inherits XMWebPage
		
        Dim cls As clsRoteiro
        Protected Const VW_IDROTEIRO As String = "IDRoteiro"

        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsRoteiro()
            If Not Page.IsPostBack Then
                subAddConfirm(btnApagar, "Deseja realmente apagar esta roteiro?")
                ViewState(VW_IDROTEIRO) = Cint("0" & Request("IDRoteiro"))
                ViewState("IDCLIENTE") = CInt("0" & Request("IDCliente"))
                ViewState("IDVENDEDOR") = CInt("0" & Request("IDVendedor"))
                cls.Load(ViewState(VW_IDROTEIRO))
				
				btnGravar.Enabled = iif(cls.IsNew(), VerificaPermissao(Secao, ACAO_ADICIONAR), VerificaPermissao(Secao, ACAO_EDITAR))
				btnNovo.Disabled = Not VerificaPermissao(Secao, ACAO_ADICIONAR)
                btnApagar.Enabled = IIf(cls.IsNew(), False, VerificaPermissao(Secao, ACAO_APAGAR))

                'Settings
                With XMLinkSettings
                    dspRoteiro.ShowDayPanel = .Roteiro.PorDia
                    dspRoteiro.ShowMonthPanel = .Roteiro.PorMes
                    dspRoteiro.ShowYearPanel = .Roteiro.PorAno
                    dspRoteiro.ShowWeekDayPanel = .Roteiro.PorDiaSemana
                    dspRoteiro.showWeekMonthPanel = .Roteiro.PorSemanaMes

                    If .Roteiro.UtilizaVendedor Then
                        If .Roteiro.UtilizaVendedorMultiplo Then
                            divVendedorUnico.Visible = False
                            plhVendedores.Visible = True
                        Else
                            divVendedorUnico.Visible = True
                            plhVendedores.Visible = False
                        End If
                        BindVendedores()
                    Else
                        plhVendedores.Visible = False
                        divVendedorUnico.Visible = False
                    End If
                    BindClientesRoteiro()

                End With

                If ViewState("IDCLIENTE") > 0 Then
                    btnVoltar.Attributes.Add("onclick", "location.href='cliente.aspx?idcliente=" & ViewState("IDCLIENTE") & "';")
                    btnNovo.Attributes.Add("onclick", "location.href='roteiro.aspx?idroteiro=0&idcliente=" & ViewState("IDCLIENTE") & "';")
                ElseIf ViewState("IDVENDEDOR") Then
                    btnVoltar.Attributes.Add("onclick", "location.href='vendedor.aspx?idvendedor=" & ViewState("IDVENDEDOR") & "';")
                    btnNovo.Attributes.Add("onclick", "location.href='roteiro.aspx?idroteiro=0&idvendedor=" & ViewState("IDVENDEDOR") & "';")
                Else
                    btnVoltar.Attributes.Add("onclick", "location.href='Roteiros.aspx'")
                    btnNovo.Attributes.Add("onclick", "location.href='roteiro.aspx?idroteiro=0';")
                End If


                Inflate()
            Else
                cls.Load(ViewState(VW_IDROTEIRO))
          End If
        End Sub

        Protected Sub Inflate()
            txtCodigo.Text = cls.Codigo
            txtDescricao.Text = cls.Descricao
            dspRoteiro.Day = cls.Dia
            dspRoteiro.Month = cls.Mes
            dspRoteiro.WeekDay = cls.DiaSemana
            dspRoteiro.Year = cls.Ano
            dspRoteiro.WeekMonth = cls.SemanaMes

        End Sub

        Protected Sub Deflate()
            cls.Codigo = txtCodigo.Text
            cls.Descricao = txtDescricao.Text
            cls.Dia = dspRoteiro.Day
            cls.Mes = dspRoteiro.Month
            cls.DiaSemana = dspRoteiro.WeekDay
            cls.Ano = dspRoteiro.Year
            cls.SemanaMes = dspRoteiro.WeekMonth
        End Sub

        Protected Sub btnGravar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGravar.Click

            If (cls.IsNew() And VerificaPermissao(Secao, ACAO_ADICIONAR) = False) Or (cls.IsNew() = False And VerificaPermissao(Secao, ACAO_EDITAR) = False) Then
                Exit Sub
            End If

            Deflate()
            If cls.isValid Then
                cls.Update()

                If XMLinkSettings.Roteiro.UtilizaVendedor Then
                    GravarVendedor()
                End If

                Inflate()

                If ViewState("IDCLIENTE") > 0 Then
                    MostraGravado("~/Cadastros/Roteiro.aspx?idroteiro=" & cls.IDRoteiro & "&idcliente=" & ViewState("IDCLIENTE"))
                ElseIf ViewState("IDVENDEDOR") Then
                    MostraGravado("~/Cadastros/Roteiro.aspx?idroteiro=" & cls.IDRoteiro & "&idvendedor=" & ViewState("IDVENDEDOR"))
                Else
                    MostraGravado("~/Cadastros/Roteiro.aspx?idroteiro=" & cls.IDRoteiro)
                End If

            End If
            lstErros.DataSource = cls.BrokenRules
            lstErros.DataBind()

        End Sub

        Private Sub btnApagar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApagar.Click
            If VerificaPermissao(Secao, ACAO_APAGAR) Then

                cls.Delete()

                If ViewState("IDCLIENTE") > 0 Then
                    Response.Redirect("cliente.aspx?idcliente=" & ViewState("IDCLIENTE"))
                ElseIf ViewState("IDVENDEDOR") Then
                    Response.Redirect("vendedor.aspx?idvendedor=" & ViewState("IDVENDEDOR"))
                Else
                    Response.Redirect("Roteiros.aspx")
                End If
            End If
        End Sub

#Region "Vendedores"

        Protected Sub BindVendedores()
            If XMLinkSettings.Roteiro.UtilizaVendedor Then
                If XMLinkSettings.Roteiro.UtilizaVendedorMultiplo Then
                    grdVendedores.DataSource = cls.Vendedores.Listar
                    grdVendedores.DataBind()
                    Dim ven As New clsVendedor
                    cboNovoVendedor.DataSource = ven.Listar()
                    cboNovoVendedor.DataBind()
                    cboNovoVendedor.Items.Insert(0, "")
                Else
                    Dim ven As New clsVendedor
                    cboIDVendedor.DataSource = ven.Listar()
                    cboIDVendedor.DataBind()
                    cboIDVendedor.Items.Insert(0, New ListItem("", "0"))
                    cboIDVendedor.SelectedValue = cls.Vendedores.GetFirstID

                End If
            End If
        End Sub


        Protected Sub GravarVendedor()
            If Not XMLinkSettings.Roteiro.UtilizaVendedorMultiplo Then
                cls.Vendedores.SetOnlyID(cboIDVendedor.SelectedValue)
            End If
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

#End Region

#Region "Clientes"


        Private Sub txtProcurarCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurarCliente.TextChanged
            Paginate1.CurrentPage = 0
            ProcurarClientes()
        End Sub


        Protected Sub ProcurarClientes()
            Dim cli As New clsCliente
            Dim ret As PaginateResult = cli.Listar(txtProcurarCliente.Text, cboIDVendedor.SelectedValue, "0", "0", False, Paginate1.CurrentPage, 10)
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            grdProcurar.DataSource = ret.Data
            grdProcurar.DataBind()
        End Sub

        Protected Sub BindClientesRoteiro()

            If cls.IDRoteiro > 0 Then
                grdClientesRoteiro.DataSource = cls.Clientes.Listar()
                grdClientesRoteiro.DataBind()
                lblNumeroClientes.Text = grdClientesRoteiro.Rows.Count
                plhClientes.Visible = True
            Else
                plhClientes.Visible = False
            End If
        End Sub

        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            ProcurarClientes()
        End Sub

        Protected Sub grdClientesRoteiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdClientesRoteiro.RowCommand
            If e.CommandName = "RetirarCliente" Then
                cls.Clientes.Delete(grdClientesRoteiro.DataKeys(e.CommandArgument).Value)
                BindClientesRoteiro()
            End If
        End Sub

        Protected Sub grdProcurar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcurar.RowCommand
            If e.CommandName = "AdicionarCliente" Then
                cls.Clientes.Add(grdProcurar.DataKeys(e.CommandArgument).Value)
                BindClientesRoteiro()
            End If
        End Sub

#End Region

    End Class

End Namespace

