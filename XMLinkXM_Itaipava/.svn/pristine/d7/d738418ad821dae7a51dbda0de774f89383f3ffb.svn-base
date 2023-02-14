Imports Classes

Partial Class Pesquisas_RelatorioPesquisasDiarias
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "~/relatorios/imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            If Request("pr") = "2" Then

                Filtro1.Visible = False
                divAreaBotoes.Visible = False
                divAreaAjuda.Visible = False
                Paginate1.Visible = False
                BindGrid(vIDEmpresa, CInt(Request("idpesq")), CInt(Request("ger")), CInt(Request("sup")), CInt(Request("vend")))

            Else

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
                        End If

                    Next

                    With Filtro1
                        .IDGerente = ViewState("IdGerente")
                        .IDSupervisor = ViewState("IdSupervisor")
                        .IDVendedor = ViewState("IdVendedor")
                    End With

                    BindGrid(Filtro1.IDEmpresa, Filtro1.IDPesquisa, ViewState("IdGerente"), ViewState("IdSupervisor"), ViewState("IdVendedor"))

                End If

            End If

        End If

    End Sub

    Private Sub BindGrid(ByVal vIdEmpresa As Integer, ByVal vIdPesquisa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupevisor As Integer, ByVal vIdVendedor As Integer)

        Dim rep As New clsRelatorioPesquisa
        Dim ret As IPaginaResult = rep.GetRelatorioPesquisaDiaria(vIdEmpresa, vIdPesquisa, vIdGerente, vIdSupevisor, vIdVendedor, _
                                                                                          Paginate1.SortExpression, _
                                                                                          Paginate1.SortDirection, _
                                                                                          Paginate1.CurrentPage, _
                                                                                          Profile.Settings.PAGESIZE)
        grdRelatorioPesquisas.DataSource = ret.Data
        grdRelatorioPesquisas.DataBind()
        Paginate1.DataSource = ret
        Paginate1.DataBind()
        ret = Nothing

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        BindGrid(Filtro1.IDEmpresa, Filtro1.IDPesquisa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor)

    End Sub

    Protected Sub grdRelatorioPesquisas_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorioPesquisas.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lnk As HtmlGenericControl = e.Row.FindControl("lnkVendedor")

            If Request("pr") = 2 Then
                lnk.Visible = False
                e.Row.Cells(0).Text = e.Row.DataItem("Vendedor")
            End If

        End If

    End Sub

    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles grdRelatorioPesquisas.Sorting

        Paginate1.SortExpression = e.SortExpression
        BindGrid(Filtro1.IDEmpresa, Filtro1.IDPesquisa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor)

    End Sub
End Class
