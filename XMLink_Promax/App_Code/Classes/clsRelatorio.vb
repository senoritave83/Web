Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes


    Public Class clsRelatorio
        Inherits BaseClass

        Public Function GetRelatorioStatus(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_STATUS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioClientes(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_CLIENTES"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioPeriodo(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PERIODO"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioVendedor(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VENDEDOR"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioProdutos(ByVal vDataInicial As String, ByVal vDataFinal As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRODUTOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function



    End Class

End Namespace
