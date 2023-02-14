

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsProduto
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDProduto As Integer
		Protected m_strCodigo As String
		Protected m_strDescricao As String
		Protected m_intIDCategoria As Integer
		Protected m_strCategoria As String
		Protected m_intEstoque As Integer
		Protected m_decPrecoUnitario As Decimal
		Protected m_strCriado As String
        Protected m_decPrecoCusto As Decimal
        Protected m_intIDLinhaNegocio As Integer
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDProduto As Integer
			Get
				Return m_intIDProduto
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

		Public Overridable Property Descricao As String
			Get
				Return m_strDescricao
			End Get
			Set(ByVal Value As String)
				m_strDescricao = Value
			End Set
		End Property

		Public Overridable Property IDCategoria As Integer
			Get
				Return m_intIDCategoria
			End Get
			Set(ByVal Value As Integer)
				m_intIDCategoria = Value
			End Set
		End Property

		Public Overridable readonly Property Categoria As String
			Get
				Return m_strCategoria
			End Get
		End Property

		Public Overridable Property Estoque As Integer
			Get
				Return m_intEstoque
			End Get
			Set(ByVal Value As Integer)
				m_intEstoque = Value
			End Set
		End Property

		Public Overridable Property PrecoUnitario As Decimal
			Get
				Return m_decPrecoUnitario
			End Get
			Set(ByVal Value As Decimal)
				m_decPrecoUnitario = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property PrecoCusto As Decimal
			Get
				Return m_decPrecoCusto
			End Get
			Set(ByVal Value As Decimal)
				m_decPrecoCusto = Value
			End Set
		End Property

        Public Overridable Property IDLinhaNegocio As Integer
            Get
                Return m_intIDLinhaNegocio
            End Get
            Set(ByVal Value As Integer)
                m_intIDLinhaNegocio = Value
            End Set
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
			m_intIDProduto = dr.GetInt32(dr.GetOrdinal("IDProduto"))
			if dr.IsDBNull(dr.GetOrdinal("Codigo")) Then 
				m_strCodigo = ""
			else
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Descricao")) Then 
				m_strDescricao = ""
			else
				m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDCategoria")) Then 
				m_intIDCategoria = 0
			else
				m_intIDCategoria = dr.GetInt32(dr.GetOrdinal("IDCategoria"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Categoria")) Then 
				m_strCategoria = ""
			else
				m_strCategoria = dr.GetString(dr.GetOrdinal("Categoria"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Estoque")) Then 
				m_intEstoque = 0
			else
				m_intEstoque = dr.GetInt32(dr.GetOrdinal("Estoque"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("PrecoUnitario")) Then 
				m_decPrecoUnitario = Nothing
			else
				m_decPrecoUnitario = dr.GetDecimal(dr.GetOrdinal("PrecoUnitario"))
			end if
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			if dr.IsDBNull(dr.GetOrdinal("PrecoCusto")) Then 
				m_decPrecoCusto = Nothing
			else
				m_decPrecoCusto = dr.GetDecimal(dr.GetOrdinal("PrecoCusto"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IdLinhaNegocio")) Then
                m_intIDLinhaNegocio = 0
            Else
                m_intIDLinhaNegocio = dr.GetInt32(dr.GetOrdinal("IdLinhaNegocio"))
            End If
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_PRODUTO"
			cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = m_intIDProduto
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 20).value = m_strCodigo
			cmd.Parameters.Add("@DESCRICAO", SqlDbType.NVarChar, 60).value = m_strDescricao
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = m_intIDCategoria
			cmd.Parameters.Add("@ESTOQUE", SqlDbType.Int).value = m_intEstoque
			cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Money).value = m_decPrecoUnitario
            cmd.Parameters.Add("@PRECOCUSTO", SqlDbType.Money).Value = m_decPrecoCusto
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = m_intIDLinhaNegocio
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
        ''' <param name="vIDProduto">Chave primaria IDProduto</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDProduto As Integer) As Boolean
			If vIDProduto = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_PRODUTO"
			cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = vIDProduto
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
			m_intIDProduto = 0
			m_strCodigo = ""
			m_strDescricao = ""
			m_intIDCategoria = 0
			m_intEstoque = 0
			m_decPrecoUnitario = Nothing
			m_strCriado = ""
            m_decPrecoCusto = Nothing
            m_intIDLinhaNegocio = 0
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_PRODUTO"
			cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).value = m_intIDProduto
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Produto' the following row:  IDProduto=" & m_intIDProduto & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_PRODUTOS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vIDCategoria">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, vIDCategoria As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_PRODUTOS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).value = vIDCategoria
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
        ''' <param name="vIDProduto">Chave primaria IDProduto do registro atual.</param>
		''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDProduto As Integer, ByVal vCodigo As String, ByVal vLinhaNegocio As Integer) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PRODUTO_EXISTENTE"
            cmd.Parameters.Add("@IDPRODUTO", SqlDbType.Int).Value = vIDProduto
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 20).Value = vCodigo
            cmd.Parameters.Add("@LINHA", SqlDbType.Int).Value = m_intIDLinhaNegocio
            Return ExecuteScalar(cmd)

        End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			if m_strCodigo = "" Then 
				AddBrokenRule("O código é obrigatório!")
				blnValid = false
            ElseIf Existe(m_intIDProduto, m_strCodigo, m_intIDLinhaNegocio) Then
                AddBrokenRule("O código informado já existe!")
                blnValid = False
			End if
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

