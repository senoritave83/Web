

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsEndereco
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDEndereco As Integer
		Protected m_intIDCliente As Integer
		Protected m_strCodigo As String
		Protected m_strEndereco As String
		Protected m_strReferencia As String
		Protected m_strBairro As String
		Protected m_strCidade As String
		Protected m_strCEP As String
		Protected m_strUF As String
		Protected m_varAtivo As Boolean

		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDEndereco As Integer
			Get
				Return m_intIDEndereco
			End Get
		End Property

		Public Overridable ReadOnly Property IDCliente As Integer
			Get
				Return m_intIDCliente
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

		Public Overridable Property Endereco As String
			Get
				Return m_strEndereco
			End Get
			Set(ByVal Value As String)
				m_strEndereco = Value
			End Set
		End Property

		Public Overridable Property Referencia As String
			Get
				Return m_strReferencia
			End Get
			Set(ByVal Value As String)
				m_strReferencia = Value
			End Set
		End Property

		Public Overridable Property Bairro As String
			Get
				Return m_strBairro
			End Get
			Set(ByVal Value As String)
				m_strBairro = Value
			End Set
		End Property

		Public Overridable Property Cidade As String
			Get
				Return m_strCidade
			End Get
			Set(ByVal Value As String)
				m_strCidade = Value
			End Set
		End Property

		Public Overridable Property CEP As String
			Get
				Return m_strCEP
			End Get
			Set(ByVal Value As String)
				m_strCEP = Value
			End Set
		End Property

		Public Overridable Property UF As String
			Get
				Return m_strUF
			End Get
			Set(ByVal Value As String)
				m_strUF = Value
			End Set
		End Property

		Public Overridable Property Ativo As Boolean
			Get
				Return m_varAtivo
			End Get
			Set(ByVal Value As Boolean)
				m_varAtivo = Value
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
			m_intIDEndereco = dr.GetInt32(dr.GetOrdinal("IDEndereco"))
			m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
			m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
			if dr.IsDBNull(dr.GetOrdinal("Referencia")) Then 
				m_strReferencia = ""
			else
				m_strReferencia = dr.GetString(dr.GetOrdinal("Referencia"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Bairro")) Then 
				m_strBairro = ""
			else
				m_strBairro = dr.GetString(dr.GetOrdinal("Bairro"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Cidade")) Then 
				m_strCidade = ""
			else
				m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("CEP")) Then 
				m_strCEP = ""
			else
				m_strCEP = dr.GetString(dr.GetOrdinal("CEP"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("UF")) Then 
				m_strUF = ""
			else
				m_strUF = dr.GetString(dr.GetOrdinal("UF"))
			end if
			m_varAtivo = dr.GetBoolean(dr.GetOrdinal("Ativo"))

			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDEndereco">Chave primaria IDEndereco</param>
        ''' <param name="vIDCliente">Chave primaria IDCliente</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDEndereco As Integer, ByVal vIDCliente As Integer) As Boolean
			If vIDEndereco = 0 AND vIDCliente = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_ENDERECO"
			cmd.Parameters.Add("@IDENDERECO", SqlDbType.Int).value = vIDEndereco
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
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
			m_intIDEndereco = 0
			m_intIDCliente = 0
			m_strCodigo = ""
			m_strEndereco = ""
			m_strReferencia = ""
			m_strBairro = ""
			m_strCidade = ""
			m_strCEP = ""
			m_strUF = ""
			m_varAtivo = Nothing
			m_blnIsNew = true 
		End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCliente As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ENDERECOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vIDCliente">Filtro</param>
		''' <param name="vUF">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, vIDCliente As Integer, vUF As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_ENDERECOS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@UF", SqlDbType.Char, 2).value = vUF
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
        ''' <param name="vIDEndereco">Chave primaria IDEndereco do registro atual.</param>
        ''' <param name="vIDCliente">Chave primaria IDCliente do registro atual.</param>
		''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
		Public Function Existe(ByVal vIDEndereco as Integer, ByVal vIDCliente as Integer, ByVal vCodigo as String) As Boolean
			
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_ENDERECO_EXISTENTE"
			cmd.Parameters.Add("@IDENDERECO", SqlDbType.Int).value = vIDEndereco
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 50).value = vCodigo
			return ExecuteScalar(cmd)
			
		End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			if m_strCodigo = "" Then 
				AddBrokenRule("O código é obrigatório!")
				blnValid = false
			elseif Existe(m_intIDEndereco, m_intIDCliente, m_strCodigo) Then 
				AddBrokenRule("O código informado já existe!")
				blnValid = false
			End if
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

