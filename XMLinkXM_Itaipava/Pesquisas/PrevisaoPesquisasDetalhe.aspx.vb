Imports Classes

Partial Class Pesquisas_PrevisaoPesquisasDetalhe
    Inherits XMWebPage
    Protected Soma As New Somarizador
    Const VW_IDPESQUISA As String = "IDPESQUISA"
    Const VW_DATAINICIAL As String = "DATAINICIAL"
    Const VW_DATAFINAL As String = "DATAFINAL"
    Const VW_IDVENDEDOR As String = "IDVENDEDOR"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            ViewState(VW_IDPESQUISA) = CInt("0" & Request("IdPesquisa"))
            ViewState(VW_DATAINICIAL) = Request("di") & ""
            ViewState(VW_DATAFINAL) = Request("df") & ""

            If ViewState(VW_IDPESQUISA) > 0 Then

                Dim clsPes As New clsPesquisa()
                clsPes.Load(ViewState(VW_IDPESQUISA))
                lblPesquisa.Text = clsPes.Pesquisa
                lblDataInicial.Text = clsPes.DataInicio
                lblDataFinal.Text = clsPes.DataFim
                lblVisitasMes.Text = clsPes.VisitasMes
                clsPes = Nothing

                SetaGrids(1)
                BindGridDadosPesquisa()

            End If

        End If

    End Sub

    Private Sub SetaGrids(ByVal vIndex As Integer)

        grdRelatorioPesquisasVendedor.Visible = IIf(vIndex = 1, True, False)
        Paginate1.Visible = IIf(vIndex = 1, True, False)
        divVisualizar.Visible = IIf(vIndex = 1, True, False)

        grdRelatorioPesquisasVendedor_Detalhes.Visible = IIf(vIndex = 2, True, False)
        Paginate2.Visible = IIf(vIndex = 2, True, False)
        divVendedor.Visible = IIf(vIndex = 2, True, False)
        divVisualizarDetalhes.Visible = IIf(vIndex = 2, True, False)

    End Sub

    Private Sub BindGridDadosPesquisa()

        Dim vIdVendedor As Integer = 0

        Dim rep As New clsRelatorioPesquisa
        grdRelatorioPesquisasVendedor.DataSource = rep.GetRelatorioPrevisaoPesquisa(ViewState(VW_IDPESQUISA), rdpVisualizar.SelectedItem.Value)
        grdRelatorioPesquisasVendedor.DataBind()
        rep = Nothing

    End Sub

    Private Sub BindGridDadosPesquisa_Detalhes(ByVal vIdVendedor As Integer)

        Dim rep As New clsRelatorioPesquisa
        grdRelatorioPesquisasVendedor_Detalhes.DataSource = rep.GetRelatorioPrevisaoPesquisaDetalhe(ViewState(VW_IDPESQUISA), vIdVendedor, rdpVisualizarDetalhes.SelectedItem.Value)
        grdRelatorioPesquisasVendedor_Detalhes.DataBind()
        rep = Nothing

    End Sub

    Protected Sub btnVoltar_ServerClick(sender As Object, e As System.EventArgs) Handles btnVoltar.Click

        If grdRelatorioPesquisasVendedor.Visible Then
            Response.Redirect("previsaopesquisas.aspx?di=" & ViewState(VW_DATAINICIAL) & "&df=" & ViewState(VW_DATAFINAL))
        Else
            SetaGrids(1)
            BindGridDadosPesquisa()
        End If

    End Sub

    Protected Sub grdRelatorioPesquisasVendedor_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdRelatorioPesquisasVendedor.RowCommand

        If e.CommandName = "Detalhes" Then

            Dim p_Index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim p_IdPesquisa As String = grdRelatorioPesquisasVendedor.DataKeys(p_Index).Values(0).ToString()
            Dim p_IdVendedor As String = grdRelatorioPesquisasVendedor.DataKeys(p_Index).Values(1).ToString()

            ViewState(VW_IDVENDEDOR) = p_IdVendedor

            Dim clsVen As New clsVendedor()
            clsVen.Load(p_IdVendedor)
            lblVendedor.Text = clsVen.Vendedor
            clsVen = Nothing

            SetaGrids(2)
            BindGridDadosPesquisa_Detalhes(ViewState(VW_IDVENDEDOR))

        End If

    End Sub

    Protected Sub rdpVisualizar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdpVisualizar.SelectedIndexChanged

        BindGridDadosPesquisa()

    End Sub

    Protected Sub rdpVisualizarDetalhes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles rdpVisualizarDetalhes.SelectedIndexChanged

        BindGridDadosPesquisa_Detalhes(ViewState(VW_IDVENDEDOR))

    End Sub
End Class
