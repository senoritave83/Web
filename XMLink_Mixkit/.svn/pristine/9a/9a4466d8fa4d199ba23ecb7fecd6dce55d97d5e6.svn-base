Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports XMSistemas.Web.Base

Namespace Classes

    Public Class clsIntegracao
        Inherits BaseClass

#Region "Enumerations"


        Public Enum TIPO_EXPORTACAO
            PEDIDO = 1
            ITEMPEDIDO = 2
        End Enum

        Public Enum TIPO_EXPORTACAO_PEDIDOS_INDIRETOS
            PEDIDO = 1
            PEDIDOSNOVOS = 2
            PEDIDOITEM = 3
        End Enum

        Public Enum TIPO_EXPORTACAO_DEVOLUCAO_IMPROPRIAS
            PEDIDO = 1
            PEDIDOSNOVOS = 2
            PEDIDOITEM = 3
        End Enum

#End Region

        Public Function ExportarPedido(ByVal vIDStatus As Integer) As IDataReader

            '****************************************************************************************
            'EXPORTAÇÃO DE PEDIDOS E ITENS DE PEDIDO
            '****************************************************************************************

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_EXPORTAR_PEDIDOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@STATUS", SqlDbType.Int).Value = vIDStatus

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ExportaJustificativa(ByVal vIDStatus As Integer) As IDataReader

            '****************************************************************************************
            'EXPORTAÇÃO DE PEDIDOS E ITENS DE PEDIDO
            '****************************************************************************************

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_EXPORTAR_JUSTIFICATIVA"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@STATUS", SqlDbType.Int).Value = vIDStatus

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ExportarRoteiro(ByVal vIDStatus As Integer) As IDataReader

            '****************************************************************************************
            'EXPORTAÇÃO DE PEDIDOS E ITENS DE PEDIDO
            '****************************************************************************************

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_EXPORTAR_ROTEIRO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@STATUS", SqlDbType.Int).Value = vIDStatus

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function


        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete(ByVal vArquivo As String)

            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_PROCESSO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
            cn.Open()
            Try
                cmd.ExecuteNonQuery()
                MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Processo' the following row:  Arquivo=" & vArquivo & " IDEMPRESA=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try

        End Sub


        Public Function InsereArquivo(ByVal vTipo As Integer, ByVal vNomeOriginal As String) As String

            Dim strFileName As String = ""

            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_PROCESSO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo
            cmd.Parameters.Add("@NOMEORIGINAL", SqlDbType.VarChar).Value = vNomeOriginal
            cn.Open()
            Try
                strFileName = cmd.ExecuteScalar()
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try

            Return strFileName
        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vDataInicial">Filtro</param>
        ''' <param name="vDataFinal">Filtro</param>
        ''' <param name="vTipo">Filtro</param>
        ''' <param name="vStatus">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vDataInicial As String, ByVal vDataFinal As String, ByVal vTipo As Byte, ByVal vStatus As Byte, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult

            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PROCESSOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            If vDataInicial <> "" Then
                cmd.Parameters.Add("@DATAINCLUSAOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicial)
            End If
            If vDataFinal <> "" Then
                cmd.Parameters.Add("@DATAINCLUSAOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)
            End If
            cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = vTipo
            cmd.Parameters.Add("@STATUS", SqlDbType.TinyInt).Value = vStatus
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
            cn.Open()

            If vReturnType = enReturnType.DataReader Then
                Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If dr.Read Then
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = dr.GetInt32(0)
                    If dr.NextResult Then
                        ret.Data = dr
                    End If
                End If
            Else
                Try
                    Dim ad As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet
                    ad.Fill(ds)
                    ret.PageSize = vPageSize
                    ret.CurrentPage = vPage
                    ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                    ret.Data = ds.Tables(1)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            End If


            Return ret
        End Function


        Public Function GetDadosArquivo(ByVal vArquivo As String) As IDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "SE_ARQUIVO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

        End Function

        Public Function ProcessarArquivo(ByVal vArquivo As String, ByVal vPath As String) As Boolean

            Dim dts As New XMSistemas.Data.Import.XMDataImport(GetConnectionString(), Me.User.IDEmpresa, vPath, HttpContext.Current.Server.MapPath("~/files/") & "dts.log")
            Dim p_Result As Boolean = False
            dts.FileEncoding = System.Text.Encoding.GetEncoding(1252)
            Dim dr As IDataReader = GetDadosArquivo(vArquivo)
            Dim intIDTipo, intBatchSize As Integer
            Dim strColumns, strDescription, strDestinationTable, strDestinationColumns, strProcedure As String
            If dr.Read Then
                Try
                    intIDTipo = dr.GetInt32(dr.GetOrdinal("IDTipo"))
                    strColumns = dr.GetString(dr.GetOrdinal("Colunas"))
                    strDescription = dr.GetString(dr.GetOrdinal("Nome"))
                    strDestinationTable = dr.GetString(dr.GetOrdinal("TabelaDestino"))
                    strDestinationColumns = dr.GetString(dr.GetOrdinal("ColunasDestino"))
                    strProcedure = dr.GetString(dr.GetOrdinal("ProcedureUpdate"))
                    intBatchSize = dr.GetInt32(dr.GetOrdinal("BatchSize"))
                Catch e As Exception
                    Throw New ApplicationException("Erro recebendo informações sobre o formato do arquivo [" & e.Message & "]")
                Finally
                    dr.Close()
                    dr.Dispose()
                End Try

                Dim vfile As New XMSistemas.XMVirtualFile.XMFileStream(vPath & vArquivo, IO.FileMode.Open)

                dts.BatchSize = intBatchSize

                dts.Processar(vArquivo, intIDTipo, strColumns, strDescription, strDestinationTable, strDestinationColumns, strProcedure, vfile)

                p_Result = True
            Else
                dr.Close()
                dr.Dispose()
                p_Result = False
                Throw New ApplicationException("Não há informações disponíveis sobre o formato do arquivo")
            End If

            Return p_Result
        End Function


        Public Sub GravaStatusArquivo(ByVal vArquivo As String, ByVal vIDStatus As Integer, ByVal vObservacao As String)

            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_ARQUIVO_OBSERVACAO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
            cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar).Value = vObservacao
            cn.Open()
            Try
                cmd.ExecuteNonQuery()
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try


        End Sub


    End Class

End Namespace
