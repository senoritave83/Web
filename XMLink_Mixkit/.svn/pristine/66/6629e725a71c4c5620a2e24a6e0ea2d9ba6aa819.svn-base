

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsCategoria
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCategoria As Integer
		Protected m_strCodigo As String
		Protected m_strCategoria As String
		Protected m_strCriado As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
		End Property

		Public Overridable Property Codigo As String
			Get
				Return m_strCodigo
			End Get
			Set(ByVal Value As String)
				m_strCodigo = Value
			End Set
		End Property

		Public Overridable Property Categoria As String
			Get
				Return m_strCategoria
			End Get
			Set(ByVal Value As String)
				m_strCategoria = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property



		Public readonly property IsNew() as Boolean
			Get
				return m_blnIsNew
			End Get
		end Property
		
	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
			if dr.IsDBNull(dr.GetOrdinal("Codigo")) Then 
				m_strCodigo = ""
			else
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Categoria")) Then 
				m_strCategoria = ""
			else
				m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
			end if
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_CATEGORIA"
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = m_intIDCategoria
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
			cmd.Parameters.Add("@CATEGORIA", SqlDbType.NVarChar, 50).value = m_strCategoria
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			Dim dr As IDataReader = ExecuteReader(cmd)
			try
				If dr.Read Then
					Inflate(dr)
				Else
					Clear()
				End If
			finally
				If (Not dr Is Nothing) Then
					dr.Close()
					dr = Nothing
				End If
			end try
		End Sub

	
        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCategoria">Chave primaria IDCategoria</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDCategoria As Integer) As Boolean
			If vIDCategoria = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CATEGORIA"
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = vIDCategoria
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			Dim dr As IDataReader = ExecuteReader(cmd)
			try
				If dr.Read Then
					Inflate(dr)
				Else
					Clear()
				End If
			finally
				If (Not dr Is Nothing) Then
					dr.Close()
					dr = Nothing
				End If
			end try
		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDCategoria = 0
			m_strCodigo = ""
			m_strCategoria = ""
			m_strCriado = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_CATEGORIA"
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = m_intIDCategoria
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Categoria' the following row:  IDCategoria=" & m_intIDCategoria & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_CATEGORIAS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_CATEGORIAS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
			cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
			cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
			cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

		End Function
	  


			
        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCategoria">Chave primaria IDCategoria do registro atual.</param>
		''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
		Public Function Existe(ByVal vIDCategoria as Integer, ByVal vCodigo as String) As Boolean
			
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CATEGORIA_EXISTENTE"
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = vIDCategoria
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = vCodigo
			return ExecuteScalar(cmd)
			
		End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			if m_strCodigo = "" Then 
				AddBrokenRule("O código é obrigatório!")
				blnValid = false
			elseif Existe(m_intIDCategoria, m_strCodigo) Then 
				AddBrokenRule("O código informado já existe!")
				blnValid = false
			End if
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

