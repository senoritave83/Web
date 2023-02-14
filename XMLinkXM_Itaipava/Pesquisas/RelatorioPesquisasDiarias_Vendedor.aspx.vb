Imports Classes

Partial Class Pesquisas_RelatorioPesquisasDiarias_Vendedor
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim v As String = Request("v") & ""
            Dim objDados As Object = Nothing
            If v <> "" Then

                '****************************************************
                'FORMATO DOS DADOS - PARAMETRO Request("v")
                'VEN=1_||_DI=24/11/2011_||_DF=30/11/2011
                '****************************************************
                'Dim strDecrypt As String = XMCrypto.Decrypt(v)
                'objDados = strDecrypt.Split("_||_")

                objDados = StrReverse(v).Split("_||_")
                For Each obj As Object In objDados

                    If CStr(obj).StartsWith("ger=") Then
                        ViewState("IdGerente") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("ven=") Then
                        ViewState("IdVendedor") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("sup=") Then
                        ViewState("IdSupervisor") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("ide=") Then
                        ViewState("IdEmpresa") = CStr(obj).Substring(4)
                    ElseIf CStr(obj).StartsWith("idp=") Then
                        ViewState("IdPesquisa") = CStr(obj).Substring(4)
                    End If

                Next

                Dim clsStatusJust As New clsJustificativaPesquisa()
                With drpStatusPesquisa
                    .DataSource = clsStatusJust.Listar()
                    .DataBind()
                    .Items.Insert(0, New ListItem("Realizadas", "2"))
                    .Items.Insert(0, New ListItem("Todas", "0"))
                End With
                clsStatusJust = Nothing

                Dim clsVen As New clsVendedor()
                clsVen.Load(ViewState("IdVendedor"), ViewState("IdEmpresa"))
                lblVendedor.Text = clsVen.Vendedor
                clsVen = Nothing

                BindGrid()

            End If

        End If

    End Sub

    Private Sub BindGrid()

        Dim vIdVendedor As Integer = 0
        Dim vIdStatus As String = drpStatusPesquisa.SelectedItem.Value
        If vIdStatus = "" Then vIdStatus = "0"

        Dim rep As New clsRelatorioPesquisa

        Dim ret As IPaginaResult = rep.GetRelatorioPesquisaDiariaVendedor(ViewState("IdEmpresa"), _
                                                                                          ViewState("IdPesquisa"), _
                                                                                          ViewState("IdVendedor"), _
                                                                                          vIdStatus, _
                                                                                          txtCliente.Text, _
                                                                                          Paginate1.SortExpression, _
                                                                                          Paginate1.SortDirection, _
                                                                                          Paginate1.CurrentPage, _
                                                                                          Profile.Settings.PAGESIZE)
        grdRelatorioPesquisasVendedor.DataSource = ret.Data
        grdRelatorioPesquisasVendedor.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

    End Sub

    Protected Sub btnVoltar_ServerClick(sender As Object, e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("relatoriopesquisasdiarias.aspx?v=" & StrReverse("ger=" & ViewState("IdGerente") & "_||_sup=" & ViewState("IdSupervisor") & "_||_ven=" & ViewState("IdVendedor") & "_||_di=" & ViewState("DataInicial") & "_||_df=" & ViewState("DataFinal") & "_||_vis=" & ViewState("IdVisita") & "_||_pes=" & ViewState("IdPesquisa")))

    End Sub

    Protected Sub btnFiltrar_Click(sender As Object, e As System.EventArgs) Handles btnFiltrar.Click

        BindGrid()

    End Sub

    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdRelatorioPesquisasVendedor.Sorting
        Paginate1.SortExpression = e.SortExpression
        BindGrid()
    End Sub

End Class
