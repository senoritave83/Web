
Imports Classes

Namespace Pages.Pedidos

    Partial Public Class Visitas
        Inherits XMWebPage

        Protected cls As clsVisita
        Protected ped As clsPedido
        Dim ven As clsVendedor

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            cls = New clsVisita()
            ped = New clsPedido()
            If Not Page.IsPostBack Then

                CarregaVisita(CInt("0" & Request("IDVisita")))

                Dim jus As New clsJustificativa
                cboIDJustificativa.DataSource = jus.Listar
                cboIDJustificativa.DataBind()
                cboIDJustificativa.Items.Insert(0, New ListItem("JUSTIFICADO", -2))
                cboIDJustificativa.Items.Insert(0, New ListItem("REALIZADO", -1))
                cboIDJustificativa.Items.Insert(0, New ListItem("PENDENTE", -3))
                cboIDJustificativa.Items.Insert(0, New ListItem("TODOS", 0))
                jus = Nothing

                ven = New clsVendedor
                cboIdGerenteVendas.DataSource = ven.ListarGerenteVendas(User.IDEmpresa)
                cboIdGerenteVendas.DataBind()
                cboIdGerenteVendas.Items.Insert(0, New ListItem("TODOS", 0))
                ven = Nothing

                cboIdVisForaRota.Items.Insert(0, New ListItem("TODOS", 2))
                cboIdVisForaRota.Items.Insert(1, New ListItem("Dentro da Rota", 0))
                cboIdVisForaRota.Items.Insert(2, New ListItem("Fora de Rota", 1))
                
                BindSupervisor(cboIdGerenteVendas.SelectedValue)
                BindVendedor(cboIDSupervisor.SelectedValue)

                Dim gru As New clsGrupo
                cboIdGrupo.DataSource = gru.ListarGrupos_Usuario(Me.User.IDUser, True)
                cboIdGrupo.DataBind()
                cboIdGrupo.Items.Insert(0, New ListItem("TODOS", 0))
                gru = Nothing

                setComboValue(cboIDJustificativa, -3)

                txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
                txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

                Me.RecuperaFiltro(Paginate1, txtCliente, cboIdVendedor, txtDataInicial, txtDataFinal, cboIDJustificativa, chkInvestimento, cboIdGerenteVendas, cboIDSupervisor, cboIdGrupo)

                BindGrid()

            End If
        End Sub

        Public Sub BindSupervisor(ByVal p_IdGerenteVendas As Integer)
            ven = New clsVendedor
            cboIDSupervisor.DataSource = ven.ListarSupervisores(p_IdGerenteVendas)
            cboIDSupervisor.DataBind()
            cboIDSupervisor.Items.Insert(0, New ListItem("TODOS", 0))
            ven = Nothing
        End Sub

        Public Sub BindVendedor(ByVal p_IdSupervisor As Integer)
            ven = New clsVendedor
            cboIdVendedor.DataSource = ven.ListarVendedoresSup(p_IdSupervisor)
            cboIdVendedor.DataBind()
            cboIdVendedor.Items.Insert(0, New ListItem("TODOS", 0))
            ven = Nothing
        End Sub

        Public Sub BindGrid()

            Dim ret As IPaginaResult = cls.Listar(txtCliente.Text, cboIdVendedor.SelectedValue, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue, cboIdGerenteVendas.SelectedValue, cboIDSupervisor.SelectedValue, cboIdGrupo.SelectedValue, chkInvestimento.Checked, cboIdVisForaRota.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
            GridView1.DataSource = ret.Data
            GridView1.DataBind()
            Paginate1.DataSource = ret
            Paginate1.DataBind()
            ret = Nothing

            Me.GravaFiltro(Paginate1, txtCliente, cboIdVendedor, txtDataInicial, txtDataFinal, cboIDJustificativa, chkInvestimento, cboIdGerenteVendas, cboIDSupervisor, cboIdGrupo)

        End Sub
		
        Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
            BindGrid()
        End Sub



        Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
            BindGrid()
        End Sub

        Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                If e.Row.DataItem.Item("Transito") = 1 Then
                    e.Row.CssClass = "VisitaTransito"
                End If
            End If

        End Sub



        Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
            Paginate1.CurrentPage = 0
            BindGrid()
        End Sub		

        Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
            Paginate1.SortExpression = e.SortExpression
        End Sub


#Region "Detalhes"

        Protected Sub CarregaVisita(ByVal vIDVisita As Integer)
            If cls.Load(vIDVisita) Then
                plhDetalhes.Visible = True
                Inflate()
                BindInvestimentos()
                BindPedidos()
            Else
                plhDetalhes.Visible = False
            End If
            ViewState("IDVisita") = vIDVisita
        End Sub

        Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
            If e.CommandName = "Select" Then
                CarregaVisita(GridView1.DataKeys(e.CommandArgument).Value)
            End If
        End Sub

        Private Sub BindInvestimentos()
            Dim vin As New clsVisitaInvestimento
            grdInvestimentos.DataSource = vin.Listar(cls.IDVisita)
            grdInvestimentos.DataBind()
            plhInvestimentos.Visible = grdInvestimentos.Rows.Count > 0
        End Sub

        Private Sub BindPedidos()
            grdPedidos.DataSource = ped.Listar(cls.IDVisita)
            grdPedidos.DataBind()
            'plhPedidos.Visible = grdPedidos.Rows.Count > 0
        End Sub

        Protected Sub Inflate()
            lnkVisita.Text = cls.IDVisita
            lnkVisita.NavigateUrl = "Visita.aspx?idvisita=" & cls.IDVisita
            lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
            lblVendedor.Text = cls.Vendedor
            lblData.Text = cls.Data
            lblStatus.Text = cls.Status
            LocalizacaoInicio.Latitude = cls.LatitudeInicio
            LocalizacaoInicio.Longitude = cls.LongitudeInicio
            LocalizacaoFinal.Latitude = cls.LatitudeFinal
            LocalizacaoFinal.Longitude = cls.LongitudeFinal
            lblInicio.Text = cls.Inicio
            lblTermino.Text = cls.Termino
            chkVisForaRota.Checked = cls.IDVisForaRota
            trVisForaRota.Visible = chkVisForaRota.Checked

            Dim cli As New clsCliente()
            cli.Load(cls.IDCliente)
            lblEndereco.Text = cli.EnderecoCompleto
            LocalizacaoCliente.Latitude = cli.Latitude
            LocalizacaoCliente.Longitude = cli.Longitude
            cli = Nothing


        End Sub
#End Region

        Protected Sub grdPedidos_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles grdPedidos.ItemCommand
            Dim vIDPedido As String = CType(e.Item.FindControl("hidIDPedido"), HiddenField).Value
            Dim vIDVisita As Integer = ViewState("IDVisita")
            If e.CommandName = "Aprovar" Then
                If ped.Load(vIDPedido) Then
                    ped.AprovarPedido()
                    CarregaVisita(vIDVisita)
                End If
            ElseIf e.CommandName = "Reprovar" Then
                Dim plhBotoesAprovar As PlaceHolder = CType(e.Item.FindControl("plhBotoesAprovar"), PlaceHolder)
                Dim plhReprovar As PlaceHolder = CType(e.Item.FindControl("plhReprovar"), PlaceHolder)
                Dim txtMotivo As TextBox = CType(e.Item.FindControl("txtMotivo"), TextBox)
                plhBotoesAprovar.Visible = False
                plhReprovar.Visible = True
                txtMotivo.Text = ""
            ElseIf e.CommandName = "CancelarReprovar" Then
                Dim plhReprovar As PlaceHolder = CType(e.Item.FindControl("plhReprovar"), PlaceHolder)
                Dim plhBotoesAprovar As PlaceHolder = CType(e.Item.FindControl("plhBotoesAprovar"), PlaceHolder)
                Dim btnReprovar As Button = CType(e.Item.FindControl("btnReprovar"), Button)
                plhBotoesAprovar.Visible = True
                plhReprovar.Visible = False
            ElseIf e.CommandName = "ConfirmarReprovar" Then
                Dim plhReprovar As PlaceHolder = CType(e.Item.FindControl("plhReprovar"), PlaceHolder)
                Dim plhBotoesAprovar As PlaceHolder = CType(e.Item.FindControl("plhBotoesAprovar"), PlaceHolder)
                Dim btnReprovar As Button = CType(e.Item.FindControl("btnReprovar"), Button)
                Dim txtMotivo As TextBox = CType(e.Item.FindControl("txtMotivo"), TextBox)
                If txtMotivo.Text <> "" Then
                    plhBotoesAprovar.Visible = True
                    plhReprovar.Visible = False
                    If ped.Load(vIDPedido) Then
                        ped.ReprovarPedido(txtMotivo.Text)
                        CarregaVisita(vIDVisita)
                    End If
                End If
            End If
        End Sub

        Protected Sub grdPedidos_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles grdPedidos.ItemDataBound
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                Dim vIDStatus As Integer = 0
                Dim plhBotoesAprovar As PlaceHolder = CType(e.Item.FindControl("plhBotoesAprovar"), PlaceHolder)
                Dim btnAprovar As Button = CType(e.Item.FindControl("btnAprovar"), Button)
                Dim btnReprovar As Button = CType(e.Item.FindControl("btnReprovar"), Button)
                vIDStatus = DataBinder.Eval(e.Item.DataItem, "IDStatusPedido")
                If vIDStatus = 3 Then
                    btnAprovar.Enabled = ped.PodeAprovar(DataBinder.Eval(e.Item.DataItem, "IDPedido").ToString()) And VerificaPermissao("Pedido", "Aprovar pedidos")
                    btnReprovar.Enabled = VerificaPermissao("Pedido", "Reprovar pedidos")
                    plhBotoesAprovar.Visible = True
                    subAddConfirm(btnAprovar, "Deseja realmente confirmar o pedido " & DataBinder.Eval(e.Item.DataItem, "NumeroPedido"))
                Else
                    plhBotoesAprovar.Visible = False
                End If
            End If
        End Sub

        Protected Sub cboIdGerenteVendas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdGerenteVendas.SelectedIndexChanged
            BindSupervisor(cboIdGerenteVendas.SelectedValue)
        End Sub

        Protected Sub cboIDSupervisor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDSupervisor.SelectedIndexChanged
            BindVendedor(cboIDSupervisor.SelectedValue)
        End Sub
    End Class

End Namespace

