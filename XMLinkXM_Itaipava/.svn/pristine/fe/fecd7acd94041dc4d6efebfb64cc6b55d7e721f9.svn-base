Imports Classes

Partial Class Relatorios_Performance_Pesquisas
    Inherits XMWebPage
    Protected Soma As New Somarizador

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim vIDEmpresa As Integer = CInt("0" & Request("em"))
            If vIDEmpresa <> User.IDEmpresa Then
                If Not VerificaPermissao("Relatórios", "Visualizar todas as empresas") Then
                    vIDEmpresa = User.IDEmpresa
                End If
            End If

            Filtro1.DataInicial = Now().AddDays(-62).ToShortDateString()
            Filtro1.DataFinal = Now().ToShortDateString()

            BindGrid(Filtro1.Filtro, Filtro1.DataInicial, Filtro1.DataFinal)

        End If

    End Sub

    Private Sub BindGrid(ByVal vFiltro As String, ByVal vDataInicial As String, ByVal VDataFinal As String)

        Dim rep As New clsRelatorioPesquisa
        grdRelatorioPesquisas.DataSource = rep.GetRelatorioPesquisa(vFiltro, vDataInicial, VDataFinal)
        grdRelatorioPesquisas.DataBind()
        rep = Nothing

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        BindGrid(Filtro1.Filtro, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

End Class
