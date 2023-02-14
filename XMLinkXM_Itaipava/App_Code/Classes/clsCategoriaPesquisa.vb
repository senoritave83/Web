

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsCategoriaPesquisa
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCategoriaPesquisa As Integer
		Protected m_strCodigo As String
		Protected m_strCategoria As String
		Protected m_strCriado As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCategoriaPesquisa As Integer
			Get
				Return m_intIDCategoriaPesquisa
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
			m_intIDCategoriaPesquisa = dr.GetInt32(dr.GetOrdinal("IDCategoriaPesquisa"))
			m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_CATEGORIAPESQUISA"
			cmd.Parameters.Add("@IDCATEGORIAPESQUISA", SqlDbType.Int).value = m_intIDCategoriaPesquisa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 15).value = m_strCodigo
			cmd.Parameters.Add("@CATEGORIA", SqlDbType.VarChar, 50).value = m_strCategoria
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
        ''' <param name="vIDCategoriaPesquisa">Chave primaria IDCategoriaPesquisa</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDCategoriaPesquisa As Integer) As Boolean

            If vIDCategoriaPesquisa = 0 Then
                Clear()
                Return False
            End If
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CATEGORIAPESQUISA"
			cmd.Parameters.Add("@IDCATEGORIAPESQUISA", SqlDbType.Int).value = vIDCategoriaPesquisa
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
            End Try

            Return True

		End Function			

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDCategoriaPesquisa = 0
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
			cmd.CommandText = PREFIXO & "DE_CATEGORIAPESQUISA"
			cmd.Parameters.Add("@IDCATEGORIAPESQUISA", SqlDbType.Int).value = m_intIDCategoriaPesquisa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'CategoriaPesquisa' the following row:  IDCategoriaPesquisa=" & m_intIDCategoriaPesquisa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_CATEGORIAPESQUISAS"
            cmd.CommandType = CommandType.StoredProcedure
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
			cmd.CommandText = PREFIXO & "NV_CATEGORIAPESQUISAS"
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
        ''' <param name="vIDCategoriaPesquisa">Chave primaria IDCategoriaPesquisa do registro atual.</param>
		''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
		Public Function Existe(ByVal vIDCategoriaPesquisa as Integer, ByVal vCodigo as String) As Boolean
			
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CATEGORIAPESQUISA_EXISTENTE"
			cmd.Parameters.Add("@IDCATEGORIAPESQUISA", SqlDbType.Int).value = vIDCategoriaPesquisa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 15).value = vCodigo
			return ExecuteScalar(cmd)
			
		End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			if m_strCodigo = "" Then 
				AddBrokenRule("O código é obrigatório!")
				blnValid = false
			elseif Existe(m_intIDCategoriaPesquisa, m_strCodigo) Then 
				AddBrokenRule("O código informado já existe!")
				blnValid = false
			End if
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

