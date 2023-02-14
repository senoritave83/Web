Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsRelatorioEnquete
    Inherits BaseClass

    Public Function GetRelatorio_DadosEnquete(ByVal vIdEnquete As String, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vData As String) As SqlDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETE"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Me.User.IDEmpresa
        cmd.Parameters.Add("@IDENQUETE", SqlDbType.Int).Value = vIdEnquete
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(vData)

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

    End Function

    Public Function GetRelatorio_FarolDesempenhoVendedor(ByVal vIdEmpresa As Integer, ByVal vIdEnquete As String, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vData As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETES_FAROLDESEMPENHOVENDEDOR"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@IDENQUETE", SqlDbType.Int).Value = vIdEnquete
        cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = _setDateTimeDBValue(vData)


        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function


    Public Function GetRelatorio_FarolDesempenhoEquipe(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETES_FAROLDESEMPENHOEQUIPE"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDGERENTE", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)


        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetRelatorio_FarolDesempenhoPerformance(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETES_FAROLDESEMPENHOPERFORMANCE"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDGERENTE", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)


        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function


    Public Function GetRelatorio_FarolDesempenhoEnquetes(ByVal vIdEmpresa As Integer, ByVal vIdGerente As Integer, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETES_FAROLDESEMPENHOENQUETES"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDGERENTE", SqlDbType.Int).Value = vIdGerente
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    Public Function GetRelatorio_SegmentacaoPDV(ByVal vIdEmpresa As Integer, ByVal vIdEnquete As String, ByVal vIdSupervisor As Integer, ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

        Dim cmd As New SqlCommand()
        cmd.CommandText = PREFIXO & "RPT_ENQUETES_SEGMENTACAO_PDV"

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
        cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
        cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
        cmd.Parameters.Add("@IDENQUETE", SqlDbType.Int).Value = vIdEnquete
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
        cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    End Function

    'Public Function GetRelatorioEvolucao_VolumePrecos(ByVal vIdEmpresa As Integer, _
    '                                                  ByVal vIdRegional As Integer, _
    '                                                  ByVal vIdGerente As Integer, _
    '                                                  ByVal vIdSupervisor As Integer, _
    '                                                  ByVal vIdVendedor As Integer, _
    '                                                  ByVal vIdPesquisa As Integer, _
    '                                                  ByVal vTipo As Integer) As DataSet
    '    Dim cmd As New SqlCommand()
    '    cmd.CommandText = PREFIXO & "RPT_GRAFICO_EVOLUCAO_VOLUMEPRECO"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
    '    cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
    '    cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIdGerente
    '    cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
    '    cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
    '    cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
    '    cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo

    '    Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    'End Function

    'Public Function GetRelatorioEvolucao_VolumePesquisas(ByVal vIdEmpresa As Integer, _
    '                                                  ByVal vIdRegional As Integer, _
    '                                                  ByVal vIdGerente As Integer, _
    '                                                  ByVal vIdSupervisor As Integer, _
    '                                                  ByVal vIdVendedor As Integer, _
    '                                                  ByVal vIdPesquisa As Integer, _
    '                                                  ByVal vTipo As Integer) As DataSet
    '    Dim cmd As New SqlCommand()
    '    cmd.CommandText = PREFIXO & "RPT_GRAFICO_EVOLUCAO_PESQUISAS"
    '    cmd.CommandType = CommandType.StoredProcedure
    '    cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
    '    cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
    '    cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIdGerente
    '    cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIdSupervisor
    '    cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor
    '    cmd.Parameters.Add("@IDPESQUISA", SqlDbType.Int).Value = vIdPesquisa
    '    cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo

    '    Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

    'End Function

End Class
