Imports Classes

Partial Class Pesquisas_PrevisaoPesquisas
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        If Request("pr") = "2" Then
            Me.MasterPageFile = "~/relatorios/imprimir.master"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState("IdEmpresa") = Filtro1.IDEmpresa
            If ViewState("IdEmpresa") <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    ViewState("IdEmpresa") = User.IDEmpresa
                End If
            End If

            BindGrid(ViewState("IdEmpresa"), ViewState("IdPesquisa"))

            If Request("pr") = "2" Then

                Filtro1.Visible = False
                divAreaBotoes.Visible = False
                divAreaAjuda.Visible = False
                Paginate1.Visible = False
                BindGrid(ViewState("IdEmpresa"), ViewState("IdPesquisa"))

            End If

        End If

    End Sub

    Private Sub BindGrid(ByVal vIdEmpresa As Integer, ByVal vIdPesquisa As Integer)

        Dim rep As New clsRelatorioPesquisa
        grdRelatorioPesquisas.DataSource = rep.GetRelatorioPrevisaoPesquisas(vIdEmpresa, vIdPesquisa)
        grdRelatorioPesquisas.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        BindGrid(ViewState("IdEmpresa"), Filtro1.IDPesquisa)

    End Sub


    Protected Sub grdRelatorioPesquisas_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdRelatorioPesquisas.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim lnk As HtmlGenericControl = e.Row.FindControl("lnkPesquisa")

            If Request("pr") = 2 Then
                lnk.Visible = False
                e.Row.Cells(0).Text = e.Row.DataItem("Pesquisa")
            End If

        End If

    End Sub

End Class
