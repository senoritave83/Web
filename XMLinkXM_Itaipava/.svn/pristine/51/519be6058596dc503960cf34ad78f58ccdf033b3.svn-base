Imports Classes

Partial Class Enquetes_FarolDesVendedor
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

            Try

            
                Dim strFiltroItens As String = Request("f") & ""
                If strFiltroItens <> "" Then

                    Dim objFiltroItens As Object = strFiltroItens.Split("|_|")
                    If UBound(objFiltroItens) > 0 Then
                        With Filtro1
                            .IDGerente = objFiltroItens(0)
                            .IDSupervisor = objFiltroItens(2)
                            .IDVendedor = objFiltroItens(4)
                            .DataInicial = objFiltroItens(6)
                            .DataFinal = objFiltroItens(8)
                        End With
                    End If



                End If

            Catch ex As Exception

                Response.Write("Erro ao coletar parametros" & ex.Message)

            End Try

            BindGrid(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

        End If

    End Sub

    Private Sub BindGrid(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String)

        Dim rep As New clsRelatorioEnquete
        Dim ds As System.Data.DataSet = rep.GetRelatorio_FarolDesempenhoEnquetes(vIdEmpresa, vIdGerente, vIdSupervisor, vIdVendedor, vDataInicial, vDataFinal)
        grdFarolDesempenhoEnquetes.DataSource = ds
        grdFarolDesempenhoEnquetes.DataBind()

        Me.GravaFiltro(Filtro1)

    End Sub

    Protected Sub Filtro1_Exibir(sender As Object, e As System.EventArgs) Handles Filtro1.Exibir

        BindGrid(Filtro1.IDEmpresa, Filtro1.IDGerente, Filtro1.IDSupervisor, Filtro1.IDVendedor, Filtro1.DataInicial, Filtro1.DataFinal)

    End Sub

End Class
