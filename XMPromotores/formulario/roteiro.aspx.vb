Imports Classes


Partial Class formulario_roteiro
    Inherits XMWebPage
    Private intIDVisitaAberta As Integer = 0
    Protected vis As clsFormVisita


    Protected Sub btnNaoUtilizarVisitaAberta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNaoUtilizarVisitaAberta.Click
        ViewState("NaoUtilizarVisitaAberta") = True
        BindRoteiro()
    End Sub

    Protected Sub btnUtilizarVisitaAberta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUtilizarVisitaAberta.Click
        intIDVisitaAberta = vis.GetIDVisitaAtiva(ViewState("IDPROMOTOR"))
        Response.Redirect("visita.aspx?idvisita=" & intIDVisitaAberta)
    End Sub

    Protected Sub MostraRoteiro()

        Dim clsProm As New clsUsuario
        clsProm.Load(ViewState("IDPROMOTOR"))
        If clsProm.IDUsuario = 0 Then
            Response.Redirect("default.aspx")
            Exit Sub
        End If
        lblPromotor.Text = clsProm.Usuario

        Dim vis As New clsFormVisita
        intIDVisitaAberta = vis.GetIDVisitaAtiva(clsProm.IDUsuario)

        plhAdicionarLoja.Visible = (vis.PromotorPermiteAdicionarLoja(clsProm.IDUsuario) <> 0)

        If intIDVisitaAberta > 0 And ViewState("NaoUtilizarVisitaAberta") = False Then
            pnlExistente.Visible = True
            vis.Load(intIDVisitaAberta)
            ViewState("IDLOJA") = vis.IDLoja
            lblMensagem.Text = "Já existe uma visita sendo editada para este promotor para a loja " & vis.Loja & "<br />Deseja utiliza-la? Caso abra a edição para outra loja, a atual será descartada!"
        Else
            pnlExistente.Visible = False
            BindRoteiro()
        End If
    End Sub

    Protected Sub BindRoteiro()
        Dim vis As New clsFormVisita

        If RoteiroRetroativo Then
            'Carrega roteiro passado.
            grdLojasRoteiro.DataSource = vis.ListarLojasRoteiroPendente(ViewState("IDPROMOTOR"), txtData.Text)
            grdLojasRoteiro.DataBind()
        Else
            grdLojasRoteiro.DataSource = vis.ListarLojasRoteiro(ViewState("IDPROMOTOR"))
            grdLojasRoteiro.DataBind()
        End If
    End Sub


    Protected ReadOnly Property RoteiroRetroativo() As Boolean
        Get
            Return txtData.Text <> Now.ToString("dd/MM/yyyy")
        End Get
    End Property

    Protected Sub grdLojasRoteiro_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdLojasRoteiro.RowCommand
        Dim intIDLoja As Integer = grdLojasRoteiro.DataKeys(e.CommandArgument).Value

        If RoteiroRetroativo Then
            vis.IniciarVisitaAntiga(ViewState("IDPROMOTOR"), intIDLoja, txtData.Text)
        Else
            vis.IniciarVisita(ViewState("IDPROMOTOR"), intIDLoja)
        End If

        Response.Redirect("visita.aspx?idvisita=" & vis.IDVisita)
        vis = Nothing
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vis = New clsFormVisita
        If Not Page.IsPostBack Then
            ViewState("NaoUtilizarVisitaAberta") = False
            txtData.Text = Now.ToString("dd/MM/yyyy")
            ViewState("IDPROMOTOR") = Request("idpromotor")
            MostraRoteiro()
        End If
    End Sub

    Protected Sub txtData_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtData.TextChanged
        AtualizaData()
    End Sub

    Protected Sub AtualizaData()
        If Not IsDate(txtData.Text) Then
            txtData.Text = Now.ToString("dd/MM/yyyy")
        ElseIf CDate(txtData.Text) < Now.AddDays(-7) Then
            txtData.Text = Now.ToString("dd/MM/yyyy")
        ElseIf CDate(txtData.Text) > Now Then
            txtData.Text = Now.ToString("dd/MM/yyyy")
        End If
        MostraRoteiro()
    End Sub

    Protected Sub btnAtualizarData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtualizarData.Click
        AtualizaData()
    End Sub


    Private Sub txtProcurarLoja_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcurarLoja.TextChanged
        Paginate1.CurrentPage = 0
        ProcurarLojas()
    End Sub

    Protected Sub ProcurarLojas()
        Dim loj As New clsLoja
        Dim ret As PaginateResult = vis.BuscarLojasAdicionar(ViewState("IDPROMOTOR"), txtProcurarLoja.Text, "", False, Paginate1.CurrentPage, PAGESIZE)
        Paginate1.DataSource = ret
        grdProcurar.DataSource = ret.Data
        grdProcurar.DataBind()
    End Sub


    Protected Sub grdProcurar_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProcurar.RowCommand
        If e.CommandName = "AdicionarLoja" Then
            Dim strMessage As String = ""
            strMessage = vis.AdicionarLojaRoteiro(ViewState("IDPROMOTOR"), grdProcurar.DataKeys(e.CommandArgument).Value)
            If strMessage <> "" Then
                ShowMsg(strMessage)
            Else
                BindRoteiro()
            End If
        End If
    End Sub

    Protected Sub btnProcurar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcurar.Click
        Paginate1.CurrentPage = 0
        ProcurarLojas()
    End Sub
End Class
