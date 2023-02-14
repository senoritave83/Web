Imports Classes

Partial Class Pesquisas_VisitaPesquisaDet
    Inherits XMWebPage

    Protected cls As clsVisitaPesquisa
    Const VW_IDVISITA As String = "IDVISITA"
    Const VW_IDPESQUISA As String = "IDPESQUISA"
    Const VW_REINCIDENCIA As String = "REINCIDENCIA"
    Dim ven As clsVendedor

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsVisitaPesquisa()
        If Not Page.IsPostBack Then

            CarregaVisita(CInt("0" & Request("IDVisita")))

            Dim jus As New clsJustificativaPesquisa
            cboIDJustificativa.DataSource = jus.Listar
            cboIDJustificativa.DataBind()
            cboIDJustificativa.Items.Insert(0, New ListItem("PESQUISADAS", "0"))
            cboIDJustificativa.Items.Insert(0, New ListItem("TODAS", "-1"))
            jus = Nothing

            ven = New clsVendedor
            cboIdGerenteVendas.DataSource = ven.ListarGerenteVendas(User.IDEmpresa)
            cboIdGerenteVendas.DataBind()
            cboIdGerenteVendas.Items.Insert(0, New ListItem("TODOS", 0))
            ven = Nothing

            BindSupervisor(cboIdGerenteVendas.SelectedValue)
            BindVendedor(cboIDSupervisor.SelectedValue)

            setComboValue(cboIDJustificativa, -3)

            txtDataInicial.Text = Now.ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")

            Me.RecuperaFiltro(Paginate1, txtFiltro, cboIdVendedor, txtDataInicial, txtDataFinal, cboIDJustificativa, cboIdGerenteVendas, cboIDSupervisor)

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

        Dim ret As IPaginaResult = cls.Listar(txtFiltro.Text, txtDataInicial.Text, txtDataFinal.Text, cboIDJustificativa.SelectedValue, cboIdGerenteVendas.SelectedValue, cboIDSupervisor.SelectedValue, cboIdVendedor.SelectedValue, Paginate1.SortExpression, Paginate1.SortDirection, Paginate1.CurrentPage, Profile.Settings.PAGESIZE)
        GridView1.DataSource = ret.Data
        GridView1.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

        Me.GravaFiltro(Paginate1, txtFiltro, cboIdVendedor, txtDataInicial, txtDataFinal, cboIDJustificativa, cboIdGerenteVendas, cboIDSupervisor)

    End Sub

    Private Sub Paginate1_OnPageChanged() Handles Paginate1.OnPageChanged
        BindGrid()
    End Sub



    Private Sub GridView1_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Sorted
        BindGrid()
    End Sub

    Protected Sub cboIdGerenteVendas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIdGerenteVendas.SelectedIndexChanged
        BindSupervisor(cboIdGerenteVendas.SelectedValue)
    End Sub

    Protected Sub cboIDSupervisor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboIDSupervisor.SelectedIndexChanged
        BindVendedor(cboIDSupervisor.SelectedValue)
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
        ViewState(VW_IDVISITA) = vIDVisita
        If cls.Load(ViewState(VW_IDVISITA)) Then
            plhDetalhes.Visible = True
            Inflate()
        Else
            plhDetalhes.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Select" Then
            CarregaVisita(GridView1.DataKeys(e.CommandArgument).Value)
        End If
    End Sub

    Protected Sub btnForcarReincidencia_Click(sender As Object, e As System.EventArgs) Handles btnForcarReincidencia.Click

        Dim blnReincidencia As Boolean = Not ViewState(VW_REINCIDENCIA)

        cls.ForcarReincidencia(ViewState(VW_IDVISITA), ViewState(VW_IDPESQUISA), blnReincidencia)
        CarregaVisita(ViewState(VW_IDVISITA))

    End Sub

    Protected Sub Inflate()

        ViewState(VW_IDPESQUISA) = cls.IDPesquisa
        ViewState(VW_REINCIDENCIA) = cls.MarcadaReincidencia
        lnkVisita.Text = cls.IDVisita
        '    lnkVisita.Text = "Visita.aspx?idvisita=" & cls.IDVisita
        lblCliente.Text = cls.IDCliente & " - " & cls.Cliente
        lblVendedor.Text = cls.Vendedor
        lblData.Text = cls.Data
        lblStatus.Text = cls.Status
        lblInicio.Text = cls.Inicio
        lblTermino.Text = cls.Termino

        lblMarcadaParaReincidencia.Text = IIf(cls.MarcadaReincidencia = True, "Sim", "Não")

        Dim cli As New clsCliente()
        cli.Load(cls.IDCliente)
        lblEndereco.Text = cli.EnderecoCompleto
        cli = Nothing

        grdItensPesquisa.DataSource = cls.ListarItens(cls.IDVisita)
        grdItensPesquisa.DataBind()

        If cls.JustificaticaReincidencia Then
            'SE A JUSTIFICATIVA FOR DO TIPO REINCIDENTE, 
            'NÃO MOSTRA O CAMPO MARCADA COMO REINCIDENTE E NÃO MOSTRA O BOTÃO FORÇAR REINCIDÊNCIA

            divReincidencia.Visible = False
            btnForcarReincidencia.Visible = False
        Else
            'SE A JUSTIFICATIVA NÃO FOR DO TIPO REINCIDENTE, 
            'O USUÁRIO PODERÁ FORÇAR A REINCIDÊNCIA DA PESQUISA
            If cls.MarcadaReincidencia = True Then
                If VerificaPermissao("Pesquisa efetuadas", "Desmarcar como reincidência") Then
                    btnForcarReincidencia.Visible = True
                    btnForcarReincidencia.Text = "Desmarcar reincidência"
                    btnForcarReincidencia.OnClientClick = "return confirm('Deseja desmarcar a reincidência desta visita');"
                Else
                    btnForcarReincidencia.Visible = False
                End If
            ElseIf cls.MarcadaReincidencia = False Then
                If VerificaPermissao("Pesquisa efetuadas", "Marcar como reincidência") Then
                    btnForcarReincidencia.Visible = True
                    btnForcarReincidencia.Text = "Marcar como reincidência"
                    btnForcarReincidencia.OnClientClick = "return confirm('Deseja forçar a reincidência desta visita');"
                Else
                    btnForcarReincidencia.Visible = False
                End If
            End If
        End If

    End Sub

#End Region



End Class
