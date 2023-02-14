Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes


    Public Class clsRelatorio
        Inherits BaseClass


        Public Function GetRelatorioRoteiro(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vData As String) As DataSet
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ROTEIRO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData
            'cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
        End Function

        Public Function GetRelatorioJustificativa(ByVal vIdEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, _
                                                  ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_JUSTIFICATIVA"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIdEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
        End Function

        Public Function GetRelatorioStatus(ByVal vIDEmpresa As Integer, ByVal vIDSupervisor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_STATUS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioAcompanhamentoPositivacao(ByVal vIDEmpresa As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ACOMPANHAMENTOPOSITIVACAO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioPositivacao(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vDias As String, ByVal vIDCategoriaProd As Integer, ByVal vIDProduto As Integer) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_POSITIVACAO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DIAS", SqlDbType.Int).Value = vDias
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoriaProd
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioClientes(ByVal vIDEmpresa As Integer, ByVal vIDSupervisor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_CLIENTES"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioVendedor(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, _
                                             ByVal vIdVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VENDEDOR"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIdVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioRota(ByVal vIDEmpresa As Integer, ByVal vIDVendedor As Integer, ByVal vData As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ROTA"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioRotaVendedor(ByVal vIDEmpresa As Integer, ByVal vIDVendedor As Integer, ByVal vIDCliente As Integer, ByVal vData As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ROTA_VENDEDOR"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioEntregas(ByVal vIDEmpresa As Integer, ByVal vPlaca As String, ByVal vData As String, ByVal vPrecisao As Integer) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ROTA_ENTREGAS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@PLACA", SqlDbType.VarChar, 10).Value = vPlaca
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData
            cmd.Parameters.Add("@PRECISAO", SqlDbType.Int).Value = vPrecisao

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioProdutos(ByVal vIDEmpresa As Integer, ByVal vIDSupervisor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRODUTOS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioPerformance(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PERFORMANCE"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function




        Public Function GetRelatorioPreco(ByVal VIDEmpresa As Integer, ByVal vIDCategoriaPesq As Integer, ByVal vIDMarcas As Integer, ByVal vIdIDProduto As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRECO_PRICING"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = VIDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoriaPesq
            cmd.Parameters.Add("@IDMARCA", SqlDbType.Int).Value = vIDMarcas
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIdIDProduto
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function




        Public Function GetRelatorioPerformanceRevenda(ByVal vIDEmpresa As Integer, ByVal vIdRegional As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PERFORMANCE_REVENDA_REGIONAL"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESAUSUARIO", SqlDbType.Int).Value = Me.User.IDEmpresa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioPerformanceLogistica(ByVal vIDEmpresa As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vPlaca As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PERFORMANCE_LOGISTICA"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@PLACA", SqlDbType.VarChar, 10).Value = vPlaca
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioMonitoramentoLogistica(ByVal vIDEmpresa As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vStatus As Integer, ByVal vPlaca As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_MONITORAMENTO_LOGISTICA"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = vStatus
            cmd.Parameters.Add("@PLACA", SqlDbType.VarChar, 10).Value = vPlaca

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioConsolidado(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_CONSOLIDADO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioVendasPorEmbalagem(ByVal vIDEmpresa As Integer, ByVal vIdRegional As Integer, ByVal vIdEmbalagem As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VENDASPOREMBALAGEM"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = vIdRegional
            cmd.Parameters.Add("@IDEMBALAGEM", SqlDbType.Int).Value = vIdEmbalagem
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            'cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            'cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            'cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioPedidos(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vIDStatus As Integer, ByVal vData As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PEDIDOS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIDStatus
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function


        Public Function GetRelatorioVisita(ByVal vIDEmpresa As Integer, ByVal vIDCliente As Integer, ByVal vCliente As String, ByVal vIDStatusVis As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDVendedor As Integer) As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VISITAS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            cmd.Parameters.Add("@STATUSVIS ", SqlDbType.Int).Value = vIDStatusVis
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
        End Function


        Public Function GetRelatorioHistoricoRoteiro(ByVal vIDEmpresa As Integer, ByVal vIDGerente As Integer, ByVal vIDSupervisor As Integer, ByVal vIDVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String) As DataSet
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_HISTORICO_ROTEIRO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDREGIONAL", SqlDbType.Int).Value = User.IDRegional
            cmd.Parameters.Add("@IDGERENTEVENDAS", SqlDbType.Int).Value = vIDGerente
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)
        End Function

        
        Public Function GetRelatorioLogAcessosUsuario(ByVal vIDEmpresa As Integer, ByVal vIDUsuario As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LOG_ACESSOS_USUARIO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = vIDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return MyBase.ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

    End Class

End Namespace
