Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsRelatorio
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_varIDRelatorio As Guid
		Protected m_strRelatorio As String
		Protected m_strParametros As String
		Protected m_intIDUsuario As Integer
		Protected m_strUsuario As String
		Protected m_indTipo As Byte
		Protected m_strAssembly As String
		Protected m_strClass As String
		Protected m_strCaminho As String
		Protected m_strArquivo As String
		Protected m_strData As String
		Protected m_strMensagem As String
		Protected m_indTentativas As Byte
		Protected m_strDataGerado As String
		Protected m_strChave As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDRelatorio As Guid
			Get
				Return m_varIDRelatorio
			End Get
		End Property

		Public Overridable Property Relatorio As String
			Get
				Return m_strRelatorio
			End Get
			Set(ByVal Value As String)
				m_strRelatorio = Value
			End Set
		End Property

		Public Overridable Property Parametros As String
			Get
				Return m_strParametros
			End Get
			Set(ByVal Value As String)
				m_strParametros = Value
			End Set
		End Property

		Public Overridable Property IDUsuario As Integer
			Get
				Return m_intIDUsuario
			End Get
			Set(ByVal Value As Integer)
				m_intIDUsuario = Value
			End Set
		End Property

		Public Overridable readonly Property Usuario As String
			Get
				Return m_strUsuario
			End Get
		End Property

		Public Overridable Property Tipo As Byte
			Get
				Return m_indTipo
			End Get
			Set(ByVal Value As Byte)
				m_indTipo = Value
			End Set
		End Property

		Public Overridable Property Assembly As String
			Get
				Return m_strAssembly
			End Get
			Set(ByVal Value As String)
				m_strAssembly = Value
			End Set
		End Property

        Public Overridable Property ClassLibrary As String
            Get
                Return m_strClass
            End Get
            Set(ByVal Value As String)
                m_strClass = Value
            End Set
        End Property

		Public Overridable Property Caminho As String
			Get
				Return m_strCaminho
			End Get
			Set(ByVal Value As String)
				m_strCaminho = Value
			End Set
		End Property

		Public Overridable Property Arquivo As String
			Get
				Return m_strArquivo
			End Get
			Set(ByVal Value As String)
				m_strArquivo = Value
			End Set
		End Property

		Public Overridable Property Data As String
			Get
				Return _getDateTimePropertyValue(m_strData)
			End Get
			Set(ByVal Value As String)
				m_strData = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property Mensagem As String
			Get
				Return m_strMensagem
			End Get
			Set(ByVal Value As String)
				m_strMensagem = Value
			End Set
		End Property

		Public Overridable Property Tentativas As Byte
			Get
				Return m_indTentativas
			End Get
			Set(ByVal Value As Byte)
				m_indTentativas = Value
			End Set
		End Property

		Public Overridable Property DataGerado As String
			Get
				Return _getDateTimePropertyValue(m_strDataGerado)
			End Get
			Set(ByVal Value As String)
				m_strDataGerado = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property Chave As String
			Get
				Return m_strChave
			End Get
			Set(ByVal Value As String)
				m_strChave = Value
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
			m_varIDRelatorio = dr.GetGuid(dr.GetOrdinal("IDRelatorio"))
			m_strRelatorio = dr.GetString(dr.GetOrdinal("Relatorio"))
			m_strParametros = dr.GetString(dr.GetOrdinal("Parametros"))
			m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
			m_strUsuario = dr.GetString(dr.GetOrdinal("Usuario"))
			if dr.IsDBNull(dr.GetOrdinal("Tipo")) Then 
				m_indTipo = 0
			else
				m_indTipo = dr.GetByte(dr.GetOrdinal("Tipo"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Assembly")) Then 
				m_strAssembly = ""
			else
				m_strAssembly = dr.GetString(dr.GetOrdinal("Assembly"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Class")) Then 
				m_strClass = ""
			else
				m_strClass = dr.GetString(dr.GetOrdinal("Class"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Caminho")) Then 
				m_strCaminho = ""
			else
				m_strCaminho = dr.GetString(dr.GetOrdinal("Caminho"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Arquivo")) Then 
				m_strArquivo = ""
			else
				m_strArquivo = dr.GetString(dr.GetOrdinal("Arquivo"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Data")) Then 
				m_strData = ""
			else
				m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Mensagem")) Then 
				m_strMensagem = ""
			else
				m_strMensagem = dr.GetString(dr.GetOrdinal("Mensagem"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Tentativas")) Then 
				m_indTentativas = 0
			else
				m_indTentativas = dr.GetByte(dr.GetOrdinal("Tentativas"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("DataGerado")) Then 
				m_strDataGerado = ""
			else
				m_strDataGerado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataGerado")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Chave")) Then 
				m_strChave = ""
			else
				m_strChave = dr.GetString(dr.GetOrdinal("Chave"))
			end if
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_RELATORIO"
			cmd.Parameters.Add("@IDRELATORIO", SqlDbType.UniqueIdentifier).value = m_varIDRelatorio
			cmd.Parameters.Add("@RELATORIO", SqlDbType.VarChar, 200).value = m_strRelatorio
			cmd.Parameters.Add("@PARAMETROS", SqlDbType.Text, 2147483647).value = m_strParametros
			cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = m_intIDUsuario
			cmd.Parameters.Add("@TIPO", SqlDbType.TinyInt).value = m_indTipo
			cmd.Parameters.Add("@ASSEMBLY", SqlDbType.VarChar, 500).value = m_strAssembly
			cmd.Parameters.Add("@CLASS", SqlDbType.VarChar, 50).value = m_strClass
			cmd.Parameters.Add("@CAMINHO", SqlDbType.VarChar, 500).value = m_strCaminho
			cmd.Parameters.Add("@ARQUIVO", SqlDbType.VarChar, 255).value = m_strArquivo
			If m_strData <> "" Then
				cmd.Parameters.Add("@DATA", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strData)
			End if
			cmd.Parameters.Add("@MENSAGEM", SqlDbType.VarChar, 500).value = m_strMensagem
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@TENTATIVAS", SqlDbType.TinyInt).value = m_indTentativas
			If m_strDataGerado <> "" Then
				cmd.Parameters.Add("@DATAGERADO", SqlDbType.DateTime).value = _setDateTimeDBValue(m_strDataGerado)
			End if
			cmd.Parameters.Add("@CHAVE", SqlDbType.VarChar, 10).value = m_strChave
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
        ''' <param name="vIDRelatorio">Chave primaria IDRelatorio</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDRelatorio As Guid) As Boolean
			If vIDRelatorio = Nothing Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_RELATORIO"
			cmd.Parameters.Add("@IDRELATORIO", SqlDbType.UniqueIdentifier).value = vIDRelatorio
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
			m_varIDRelatorio = Nothing
			m_strRelatorio = ""
			m_strParametros = ""
			m_intIDUsuario = 0
			m_indTipo = 0
			m_strAssembly = ""
			m_strClass = ""
			m_strCaminho = ""
			m_strArquivo = ""
			m_strData = ""
			m_strMensagem = ""
			m_indTentativas = 0
			m_strDataGerado = ""
			m_strChave = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_RELATORIO"
			cmd.Parameters.Add("@IDRELATORIO", SqlDbType.UniqueIdentifier).value = m_varIDRelatorio

			ExecuteNonQuery(cmd)

            Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_RELATORIOS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vIDUsuario">Filtro</param>
		''' <param name="vAtivo">Filtro</param>
		''' <param name="vDataInicial">Filtro</param>
		''' <param name="vDataFinal">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, vIDUsuario As Integer, vAtivo As Byte, vDataInicial As String, vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_RELATORIOS"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).value = vIDUsuario
			cmd.Parameters.Add("@ATIVO", SqlDbType.TinyInt).value = vAtivo
           		If vDataInicial <> "" Then
    				cmd.Parameters.Add("@DATAINICIAL", SqlDbType.DateTime).value = _setDateTimeDBValue(vDataInicial)
           		End if
           		If vDataFinal <> "" Then
    				cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).value = _setDateTimeDBValue(vDataFinal)
          		End if
			cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
			cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
			cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
			cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function

        ''' <summary>
        ''' 	Função que retorna latitude e longitude para desenhar o mapa.
        ''' </summary>
        ''' <param name="vIDEvento">Chave primária do evento que definirá o mapa</param>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function GetMapaRelatorio(ByVal vIDEvento As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataSet) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "RPT_PEG_MAPA_EVENTOSPROMOTOR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDEVENTO", SqlDbType.Int).Value = vIDEvento
            Return ExecuteCommand(cmd, vReturnType)

        End Function

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

