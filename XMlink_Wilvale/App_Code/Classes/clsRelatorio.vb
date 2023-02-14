Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes


    Public Class clsRelatorio
        Inherits BaseClass

        Public Function GetRelatorioVendas(ByVal vTipo As Integer, ByVal vMes As Short, ByVal vAno As Short, ByVal vIDSupervisor As Integer, ByVal vIDLinhaNegocio As Integer) As IDataReader
            Dim cmd As New SqlCommand()
            If vTipo = 1 Then
                cmd.CommandText = PREFIXO & "RLT_RELATORIO_PEDIDOS"
            Else
                cmd.CommandText = PREFIXO & "RLT_RELATORIO_CAIXAS"
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@MES", SqlDbType.SmallInt).Value = vMes
            cmd.Parameters.Add("@ANO", SqlDbType.SmallInt).Value = vAno
            cmd.Parameters.Add("@IDSUPERVISOR", SqlDbType.Int).Value = vIDSupervisor
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDLinhaNegocio

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
        End Function

        Public Function GetRelatorioDevolucaoImproprias(ByVal vIDFilial As Integer, ByVal vIDVendedor As Integer, ByVal vdataInicio As String, ByVal vDataFim As String) As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PEDIDOS_DEVOLUCAO_IMPROPRIAS"
            
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDFILIAL", SqlDbType.Int).Value = vIDFilial
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vdataInicio
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFim

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
        End Function

        Public Function GetRelatorioPedidosIndiretos(ByVal vIDFilial As Integer, ByVal vIDVendedor As Integer, ByVal vdataInicio As String, ByVal vDataFim As String) As IDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PEDIDOS_INDIRETOS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDFILIAL", SqlDbType.Int).Value = vIDFilial
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vdataInicio
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFim

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
        End Function


        Public Function GetRelatorioDevolucao(ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vTipo As Integer) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_DEVOLUCAO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function



        Public Function GetRelatorioStatus(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_STATUS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioClientes(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_CLIENTES"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioPeriodo(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PERIODO"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioVendedor(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VENDEDOR"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioProdutos(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRODUTOS"

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function


        Public Function GetExportarVisitas(ByVal vFilter As String, ByVal vVendedor As Integer, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vJustificativa As Integer, Optional ByVal vIDUsuario As Integer = 0) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "RPT_VISITAS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vVendedor
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).Value = vJustificativa
            If vIDUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function


    End Class

End Namespace
