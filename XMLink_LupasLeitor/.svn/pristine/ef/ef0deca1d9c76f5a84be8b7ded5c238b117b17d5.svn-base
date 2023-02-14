Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes


    Public Class clsRelatorio
        Inherits BaseClass

        Public Function getPeriodos() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_FILTRO_PERIODOS"

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetExportarDados(ByVal vDataInicio As String, ByVal vDataFim As String, ByVal vIDTipoPedido As Integer, ByVal vIDVendedores As String, ByVal vIDClientes As String, ByVal vIDStatus As String, ByVal vIDCategorias As String, ByVal vIDProdutos As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "RPT_EXPORTARDADOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime, 10).Value = vDataInicio
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime, 10).Value = vDataFim
            cmd.Parameters.Add("@IDTIPOPEDIDO", SqlDbType.VarChar, 512).Value = vIDTipoPedido
            cmd.Parameters.Add("@IDVENDEDORES", SqlDbType.VarChar, 512).Value = vIDVendedores
            cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 512).Value = vIDClientes
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.VarChar, 512).Value = vIDStatus
            cmd.Parameters.Add("@IDCATEGORIAS", SqlDbType.VarChar, 512).Value = vIDCategorias
            cmd.Parameters.Add("@IDPRODUTOS", SqlDbType.VarChar, 512).Value = vIDProdutos

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioVendedor(ByVal vDataInicial As String, ByVal vDataFinal As String, Optional ByVal vIdUsuario As Integer = 0) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VENDEDOR"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            If vIdUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function


        Public Function GetRelatorioProdutos(ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDCategoria As Integer, Optional ByVal vIdUsuario As Integer = 0) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRODUTOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            If vIdUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioStatus(ByVal vDataInicial As String, ByVal vDataFinal As String, Optional ByVal vIdUsuario As Integer = 0) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_STATUS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            If vIdUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioPrecos() As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PRECOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            'If vIdUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIdUsuario

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioFechamento(ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal Tipo As String, ByVal vIDVendedor As String, Optional ByVal vIDCategoria As Integer = 0) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_FECHAMENTO"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar, 10).Value = Tipo
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.VarChar, 255).Value = vIDVendedor
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function GetRelatorioConsignados(ByVal vIDCliente As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTE_PRODUTOS_CONSIGNADOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function GetRelatorioEstoqueVendedor(ByVal vIDVendedor As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PRODUTOS_ESTQ_VENDEDOR"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function GetRelatorioVisitasPositivacao(ByVal vIDVendedor As String, ByVal vData As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_VISITAS_POSITIVACAO"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.VarChar, 255).Value = vIDVendedor
            cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData

            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        Public Function ListVendedoresRpt(ByVal p_IdVendedores As String, Optional ByVal p_IdUsuario As Integer = 0) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LS_VENDEDORES"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.VarChar, 255).Value = p_IdVendedores
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = p_IdUsuario

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ListVendedoresRpt(ByVal p_IdVendedores As String, ByVal vNomeRPT As String, ByVal vDataInicial As String, ByVal vDataFinal As String, Optional ByVal p_IdUsuario As Integer = 0) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LS_VENDEDORES"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.VarChar, 255).Value = p_IdVendedores
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = p_IdUsuario
            cmd.Parameters.Add("@NOMERPT", SqlDbType.VarChar, 50).Value = vNomeRPT
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ListCategoriaRpt(ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vIDVendedor As Integer) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LS_CATEGORIA"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ListClientesRptConsignado(ByVal p_IdClientes As String, Optional ByVal p_IdVendedores As String = "0") As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LS_CLIENTES"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 255).Value = p_IdClientes
            cmd.Parameters.Add("@IDVENDEDORES", SqlDbType.VarChar, 255).Value = p_IdVendedores

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ListVendedores(ByVal p_IdClientes As String, Optional ByVal p_IdVendedores As String = "0") As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_LS_CLIENTES"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTES", SqlDbType.VarChar, 255).Value = p_IdClientes
            cmd.Parameters.Add("@IDVENDEDORES", SqlDbType.VarChar, 255).Value = p_IdVendedores
            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function GetRelatorioRetornoReposicao(ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vAcao As Integer, Optional ByVal p_IdVendedores As String = "0") As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_ESTOQUE_CONSIGNADO"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@DATAINI", SqlDbType.DateTime).Value = vDataInicial
            cmd.Parameters.Add("@DATAFIM", SqlDbType.DateTime).Value = vDataFinal
            cmd.Parameters.Add("@IDACAO", SqlDbType.Int).Value = vAcao
            cmd.Parameters.Add("@IDVENDEDORES", SqlDbType.VarChar, 255).Value = p_IdVendedores

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Set 
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vCliente">Filtro</param>
        ''' <param name="vDataEmissaoInicial">Filtro</param>
        ''' <param name="vDataEmissaoFinal">Filtro</param>
        ''' <param name="vStatusPedido">Filtro</param>
        ''' <param name="vTipoPedido">Filtro</param>	
        ''' <returns>DataSet</returns>
        Public Function GetExportarPedidos(ByVal vFilter As String, ByVal vVendedor As Integer, ByVal vCliente As String, ByVal vDataEmissaoInicial As String, ByVal vDataEmissaoFinal As String, ByVal vStatusPedido As Byte, ByVal vTipoPedido As Byte, Optional ByVal vIDUsuario As Integer = 0) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "RPT_PEDIDOS"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vVendedor
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            If vDataEmissaoInicial <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoInicial)
            End If
            If vDataEmissaoFinal <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoFinal)
            End If
            cmd.Parameters.Add("@STATUSPEDIDO", SqlDbType.TinyInt).Value = vStatusPedido
            cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.TinyInt).Value = vTipoPedido
            If vIDUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Set 
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vJustificativa">Filtro</param>	
        ''' <returns>DataSet</returns>
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
