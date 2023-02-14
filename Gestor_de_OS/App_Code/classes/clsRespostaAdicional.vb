Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports XMSistemas.Web.Base


Public Class clsRespostaAdicional
    Inherits DataClass

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Gravar(ByVal vIDRespostaAdicional As Integer, ByVal vIDResposta As Integer, ByVal vTexto As String, ByVal vPreenchimento As Byte, ByVal vFormato As String, ByVal vResMultipla As Boolean)
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_RESPOSTA_ADICIONAL"
        cmd.Parameters.Add("@IDRESPOSTAADICIONAL", SqlDbType.Int).Value = vIDRespostaAdicional
        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = vIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@TEXTO", SqlDbType.VarChar, 50).Value = vTexto
        cmd.Parameters.Add("@PREENCHIMENTO", SqlDbType.TinyInt).Value = vPreenchimento
        cmd.Parameters.Add("@FORMATO", SqlDbType.VarChar, 30).Value = vFormato
        cmd.Parameters.Add("@RESMULTIPLA", SqlDbType.TinyInt).Value = vResMultipla
        ExecuteNonQuery(cmd)
    End Sub

    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete(ByVal vIDRespostaAdicional As Integer, ByVal vIDResposta As Integer)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_RESPOSTA_ADICIONAL"
        cmd.Parameters.Add("@IDRESPOSTAADICIONAL", SqlDbType.Int).Value = vIDRespostaAdicional
        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = vIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        ExecuteNonQuery(cmd)

    End Sub

    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar(ByVal vIDResposta As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_RESPOSTA_ADICIONAIS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = vIDResposta
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteCommand(cmd, vReturnType)

    End Function

    ''' <summary>
    ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ''' </summary>
    ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ''' <param name="vIDResposta">Filtro</param>
    ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ''' <param name="vPage">Número da página a exibir</param>	
    ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ''' <returns>PaginateResult</returns>
    Public Function Listar(ByVal vFilter As String, ByVal vIDResposta As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_RESPOSTA_ADICIONAIS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
        cmd.Parameters.Add("@IDRESPOSTA", SqlDbType.Int).Value = vIDResposta
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    End Function



End Class