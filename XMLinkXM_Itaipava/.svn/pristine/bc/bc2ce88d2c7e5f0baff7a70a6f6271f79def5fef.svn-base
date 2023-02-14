Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsRelatorioPesquisa
    Inherits BaseClass

    Public Function GetRelatorioPesquisa(ByVal vPesquisa As String, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PERFORMANCE_PESQUISAS"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
        cmd.Parameters.Add("@PESQUISA", SqlDbType.VarChar).Value = vPesquisa
        If IsDate(vDataInicial) Then
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = CDate(vDataInicial)
        End If
        If IsDate(vDataFinal) Then
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = CDate(vDataFinal)
        End If

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
    End Function

    Public Function GetRelatorioPesquisaDiaria(ByVal vIdEmpresa As Integer, ByVal vIdPesquisa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, _
                                                       ByVal vOrder As String, _
                                                       ByVal vDescending As Boolean, _
                                                       ByVal vPage As Integer, _
                                                       ByVal vPageSize As Integer, _
                                                       Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PESQUISADIARIA"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
        cmd.Parameters.Add("@IDGERENTE", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    End Function

    Public Function GetRelatorioPesquisaDiariaVendedor(ByVal vIdEmpresa As Integer, ByVal vIdPEsquisa As Integer, _
                                                       ByVal vIdVendedor As Integer, ByVal vIdStatusPesquisa As Integer, _
                                                       ByVal vClientes As String, _
                                                       ByVal vOrder As String, _
                                                       ByVal vDescending As Boolean, _
                                                       ByVal vPage As Integer, _
                                                       ByVal vPageSize As Integer, _
                                                       Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PESQUISADIARIA_VENDEDOR"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPEsquisa
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@IdStatus", SqlDbType.TinyInt).Value = vIdStatusPesquisa
        cmd.Parameters.Add("@Clientes", SqlDbType.VarChar, 1000).Value = vClientes

        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    End Function

    Public Function GetRelatorioPrevisaoPesquisas(ByVal vIdEmpresa As Integer, ByVal vIdPesquisa As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PESQUISASPREVISAO_PESQUISAS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetRelatorioPrevisaoPesquisa(ByVal vIdPesquisa As Integer, ByVal vTipoVisualizacao As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PESQUISASPREVISAO_VENDEDOR"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
        cmd.Parameters.Add("@TIPOVISUALIZACAO", SqlDbType.TinyInt).Value = vTipoVisualizacao
        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetRelatorioPrevisaoPesquisaDetalhe(ByVal vIdPesquisa As Integer, ByVal vIdVendedor As Integer, ByVal vTipoVisualizacao As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PESQUISASPREVISAO_VENDEDORDETALHES"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@TIPOVISUALIZACAO", SqlDbType.TinyInt).Value = vTipoVisualizacao

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
    End Function

    Public Function GetPerformancePesquisa(ByVal vIDPesquisa As Integer, ByVal vEmpresas As String) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PERFORMANCE_PESQUISA"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
    End Function

    Public Function GetAcompanhamentoPesquisa(ByVal vIdEmpresa As Integer, ByVal vIDPesquisa As Integer) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ACOMPANHAMENTO_PESQUISAS"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetPerformanceRevenda(ByVal vIDPesquisa As Integer, ByVal vIDEmpresa As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PERFORMANCE_REVENDA"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIDPesquisa
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
    End Function

    Public Function GetPrecoeShare(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, _
                                   ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, _
                                   ByVal vIdCategoriaPesq As Integer, ByVal vIdProdutoPesq As Integer, ByVal vMarcas As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_PRECO_SHARE"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDGERENTE", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        If IsDate(vDataInicial) Then
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = CDate(vDataInicial)
        End If
        If IsDate(vDataFinal) Then
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = CDate(vDataFinal)
        End If
        cmd.Parameters.Add("@IDCATEGORIAPESQ", SqlDbType.Int).Value = vIdCategoriaPesq
        cmd.Parameters.Add("@IDPRODUTOPESQ", SqlDbType.Int).Value = vIdProdutoPesq
        cmd.Parameters.Add("@MARCAS", SqlDbType.VarChar).Value = vMarcas

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
    End Function

    Public Function GetRelatorioEvolucao_VolumePrecos(ByVal vIdEmpresa As Integer, _
                                                      ByVal vIdRegional As Integer, _
                                                      ByVal vIdGerente As Integer, _
                                                      ByVal vIdSupervisor As Integer, _
                                                      ByVal vIdVendedor As Integer, _
                                                      ByVal vIdPesquisa As Integer, _
                                                      ByVal vTipo As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_GRAFICO_EVOLUCAO_VOLUMEPRECO"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
        cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
        cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetRelatorioEvolucao_VolumePesquisas(ByVal vIdEmpresa As Integer, _
                                                      ByVal vIdRegional As Integer, _
                                                      ByVal vIdGerente As Integer, _
                                                      ByVal vIdSupervisor As Integer, _
                                                      ByVal vIdVendedor As Integer, _
                                                      ByVal vIdPesquisa As Integer, _
                                                      ByVal vTipo As Integer) As DataSet
        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_GRAFICO_EVOLUCAO_PESQUISAS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
        cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
        cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

End Class
