Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class clsIntegracao
    Inherits DataClass

    Private _espaco As clsEspaco = Nothing

    Public Function GetPath() As String
        Return HttpContext.Current.Server.MapPath("~/integracao/files/")
    End Function


    Public ReadOnly Property Espaco() As clsEspaco
        Get
            If _espaco Is Nothing Then
                _espaco = GetEspaco()
            End If

            Return _espaco

        End Get
    End Property

    Public Class clsEspaco
        Public Total As Integer
        Public Utilizado As Integer

        Public ReadOnly Property Livre() As Integer
            Get
                Return Total - Utilizado
            End Get
        End Property

        Public Sub New()
            Total = 0
            Utilizado = 0
        End Sub
    End Class


    Private Function GetEspaco() As clsEspaco
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_ESPACO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Dim ret As New clsEspaco

        Dim dr As IDataReader = ExecuteReader(cmd)
        If dr.Read Then
            ret.Total = dr.GetInt32(0)
            ret.Utilizado = dr.GetInt32(1)
        End If
        dr.Close()
        dr.Dispose()
        Return ret

    End Function


    Public Function InsereArquivo(ByVal vTipo As Integer) As String

        Dim strFileName As String = ""

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "IN_PROCESSO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
        cmd.Parameters.Add("@TIPO", SqlDbType.Int).Value = vTipo
        strFileName = ExecuteScalar(cmd)
        Return strFileName

    End Function


    Public Sub GravaDetalhes(ByVal vArquivo As String, ByVal vSize As Integer, ByVal vTipo As Byte)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "UP_PROCESSO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
        cmd.Parameters.Add("@SIZE", SqlDbType.Int).Value = vSize
        cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).Value = vTipo
        ExecuteNonQuery(cmd)
        _espaco = Nothing

    End Sub

    Public Sub GravaDetalhes(ByVal vArquivo As String, ByVal vObservacao As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "UP_PROCESSO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
        cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar).Value = vObservacao
        ExecuteNonQuery(cmd)
        _espaco = Nothing

    End Sub


    Public Function VerificaTipoArquivo(ByVal vLinha As String) As Integer
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_VERIFICA_ARQUIVO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@LINHA", SqlDbType.VarChar).Value = vLinha & vbCrLf
        Return ExecuteScalar(cmd)
    End Function


    Public Sub Delete(ByVal vArquivo As String)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_PROCESSO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
        ExecuteNonQuery(cmd)
    End Sub


    ''' <summary>
    ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ''' </summary>
    ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ''' <param name="vPage">Número da página a exibir</param>	
    ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ''' <returns>PaginateResult</returns>
    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_PROCESSOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    End Function


    Public Function GetDadosArquivo(ByVal vArquivo As String) As IDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "SE_ARQUIVO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
        cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo

        Return MyBase.ExecuteCommand(cmd, enReturnType.DataReader)

    End Function

    Public Function ProcessarArquivo(ByVal vArquivo As String, ByVal vPath As String) As Boolean

        Dim p_Result As Boolean = False
        Dim dr As IDataReader = GetDadosArquivo(vArquivo)
        Dim intIDTipo, intBatchSize As Integer
        Dim strColumns, strDescription, strDestinationTable, strDestinationColumns, strProcedure, strFileEncoding As String
        If dr.Read Then
            Try
                intIDTipo = dr.GetInt32(dr.GetOrdinal("IDTipo"))
                strColumns = dr.GetString(dr.GetOrdinal("Colunas"))
                strDescription = dr.GetString(dr.GetOrdinal("Nome"))
                strDestinationTable = dr.GetString(dr.GetOrdinal("TabelaDestino"))
                strDestinationColumns = dr.GetString(dr.GetOrdinal("ColunasDestino"))
                strProcedure = dr.GetString(dr.GetOrdinal("ProcedureUpdate"))
                intBatchSize = dr.GetInt32(dr.GetOrdinal("BatchSize"))
                strFileEncoding = dr.GetString(dr.GetOrdinal("FileEncoding"))
            Catch e As Exception
                Throw New ApplicationException("Erro recebendo informações sobre o formato do arquivo [" & e.Message & "]")
            Finally
                dr.Close()
                dr.Dispose()
            End Try

            If intIDTipo = 1 Then

                Dim pEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding(1252)
                If strFileEncoding <> "" Then pEncoding = System.Text.Encoding.GetEncoding(strFileEncoding)
                p_Result = ProcessarXML(vArquivo, strProcedure, pEncoding)
            Else
                Dim dts As New XMSistemas.Data.Import.XMDataImport(GetConnectionString(), Me.Identity.IDEmpresa, vPath, "dts.log")
                dts.FileEncoding = System.Text.Encoding.GetEncoding(1252)
                dts.BatchSize = intBatchSize
                If strFileEncoding <> "" Then dts.FileEncoding = System.Text.Encoding.GetEncoding(strFileEncoding)

                dts.Processar(vArquivo, intIDTipo, strColumns, strDescription, strDestinationTable, strDestinationColumns, strProcedure)
                p_Result = True
            End If
        Else
            dr.Close()
            dr.Dispose()
            p_Result = False
            Throw New ApplicationException("Não há informações disponíveis sobre o formato do arquivo")
        End If

        Return p_Result
    End Function

    Private Function ProcessarXML(ByVal vArquivo As String, ByVal vProcedure As String, ByVal vEncoding As System.Text.Encoding) As Boolean

        Dim st As IO.StreamReader = Nothing
        Dim xml As String = ""
        Try

            st = New IO.StreamReader(GetPath() & vArquivo, vEncoding)
            Try
                xml = st.ReadToEnd()
            Finally
                st.Close()
            End Try
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = vProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
            cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar).Value = vArquivo
            cmd.Parameters.Add("@XML", SqlDbType.Text).Value = xml
            ExecuteNonQuery(cmd)
            Return True
        Finally
            If Not st Is Nothing Then
                st.Dispose()
            End If
        End Try
    End Function

End Class
