

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsSegmentacao
		Inherits BaseClass


    #Region "Metodos"


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub AddSegmentacao(ByVal vIDEntidade As Integer, ByVal vIDReferencia As Integer, ByVal vConcorrente As Byte, ByVal vIDFornecedor As Integer, ByVal vIDCategoria As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDProduto As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_SEGMENTACAO"
            cmd.Parameters.Add("@TIPOENTIDADE", SqlDbType.TinyInt).Value = vIDEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CONCORRENTE", SqlDbType.TinyInt).Value = vConcorrente
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            ExecuteNonQuery(cmd)
        End Sub

	

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Remove(ByVal vIDSegmentacao As Integer)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_SEGMENTACAO"
            cmd.Parameters.Add("@IDSEGMENTACAO", SqlDbType.Int).Value = vIDSegmentacao
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            ExecuteNonQuery(cmd)

        End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vTipoBusca As String, ByVal vFiltro As String, ByVal vEntidade As enTipoEntidade, ByVal vIDReferencia As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SEGMENTACOES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@ENTIDADE", SqlDbType.TinyInt).Value = vEntidade
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TIPOBUSCA", SqlDbType.VarChar).Value = vTipoBusca
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar).Value = vFiltro
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_SEGMENTACOES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vIDReferencia">Filtro</param>
        ''' <param name="vIDFornecedor">Filtro</param>
		''' <param name="vIDSubCategoria">Filtro</param>
		''' <param name="vIDCategoria">Filtro</param>
		''' <param name="vIDProduto">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDReferencia As Integer, ByVal vIDFornecedor As Integer, ByVal vIDSubCategoria As Integer, ByVal vIDCategoria As Integer, ByVal vIDProduto As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_SEGMENTACOES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDREFERENCIA", SqlDbType.Int).Value = vIDReferencia
            cmd.Parameters.Add("@IDFORNECEDOR", SqlDbType.Int).Value = vIDFornecedor
            cmd.Parameters.Add("@IDSUBCATEGORIA", SqlDbType.Int).Value = vIDSubCategoria
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function
	  


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

