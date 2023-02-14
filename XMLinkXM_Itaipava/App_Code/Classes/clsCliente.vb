

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsCliente
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCliente As Integer
		Protected m_strCliente As String
		Protected m_strCNPJ As String
		Protected m_strEndereco As String
		Protected m_strBairro As String
        Protected m_strCidade As String
        Protected m_intIDGrupoCanal As Integer
        Protected m_intIDCanal As Integer
		Protected m_strCEP As String
		Protected m_strUF As String
		Protected m_strTelefone As String
		Protected m_strContato As String
		Protected m_strObservacao As String
		Protected m_dblLatitude As Double
		Protected m_dblLongitude As Double
		Protected m_intIDPasta As Integer
		Protected m_intIDBloqueio As Integer
		Protected m_decLimite As Decimal
		Protected m_strCriado As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCliente As Integer
			Get
				Return m_intIDCliente
			End Get
		End Property

		Public Overridable Property Cliente As String
			Get
				Return m_strCliente
			End Get
			Set(ByVal Value As String)
				m_strCliente = Value
			End Set
		End Property

		Public Overridable Property CNPJ As String
			Get
				Return m_strCNPJ
			End Get
			Set(ByVal Value As String)
				m_strCNPJ = Value
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

        Public Overridable Property IDGrupo As String
            Get
                Return m_intIDGrupoCanal
            End Get
            Set(ByVal Value As String)
                m_intIDGrupoCanal = Value
            End Set
        End Property

        Public Overridable Property IDCanal As String
            Get
                Return m_intIDCanal
            End Get
            Set(ByVal Value As String)
                m_intIDCanal = Value
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

		Public Overridable Property Telefone As String
			Get
				Return m_strTelefone
			End Get
			Set(ByVal Value As String)
				m_strTelefone = Value
			End Set
		End Property

		Public Overridable Property Contato As String
			Get
				Return m_strContato
			End Get
			Set(ByVal Value As String)
				m_strContato = Value
			End Set
		End Property

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

		Public Overridable Property Latitude As Double
			Get
				Return m_dblLatitude
			End Get
			Set(ByVal Value As Double)
				m_dblLatitude = Value
			End Set
		End Property

		Public Overridable Property Longitude As Double
			Get
				Return m_dblLongitude
			End Get
			Set(ByVal Value As Double)
				m_dblLongitude = Value
			End Set
		End Property

		Public Overridable Property IDPasta As Integer
			Get
				Return m_intIDPasta
			End Get
			Set(ByVal Value As Integer)
				m_intIDPasta = Value
			End Set
		End Property

		Public Overridable Property IDBloqueio As Integer
			Get
				Return m_intIDBloqueio
			End Get
			Set(ByVal Value As Integer)
				m_intIDBloqueio = Value
			End Set
		End Property

		Public Overridable Property Limite As Decimal
			Get
				Return m_decLimite
			End Get
			Set(ByVal Value As Decimal)
				m_decLimite = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

        Public ReadOnly Property EnderecoCompleto() As String
            Get
                Dim strEnderecoCompleto As String = Endereco
                If Bairro <> "" Then strEnderecoCompleto &= ", " & Bairro
                If Cidade <> "" Then strEnderecoCompleto &= " - " & Cidade
                If CEP <> "" Then strEnderecoCompleto &= " - " & CEP
                If UF.Trim <> "" And UF.Trim <> "0" Then strEnderecoCompleto &= " - " & UF
                Return strEnderecoCompleto
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

            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))

            m_intIDGrupoCanal = dr.GetInt32(dr.GetOrdinal("IDGrupo"))
            m_intIDCanal = dr.GetInt32(dr.GetOrdinal("IDCanal"))


            If dr.IsDBNull(dr.GetOrdinal("CNPJ")) Then
                m_strCNPJ = ""
            Else
                m_strCNPJ = dr.GetString(dr.GetOrdinal("CNPJ"))
            End If
			if dr.IsDBNull(dr.GetOrdinal("Endereco")) Then 
				m_strEndereco = ""
			else
				m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
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
			if dr.IsDBNull(dr.GetOrdinal("Telefone")) Then 
				m_strTelefone = ""
			else
				m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Contato")) Then 
				m_strContato = ""
			else
				m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
				m_strObservacao = ""
			else
				m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Latitude")) Then 
				m_dblLatitude = 0
			else
				m_dblLatitude = dr.GetDouble(dr.GetOrdinal("Latitude"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Longitude")) Then 
				m_dblLongitude = 0
			else
				m_dblLongitude = dr.GetDouble(dr.GetOrdinal("Longitude"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDPasta")) Then 
				m_intIDPasta = 0
			else
				m_intIDPasta = dr.GetInt32(dr.GetOrdinal("IDPasta"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDBloqueio")) Then 
				m_intIDBloqueio = 0
			else
				m_intIDBloqueio = dr.GetInt32(dr.GetOrdinal("IDBloqueio"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Limite")) Then 
				m_decLimite = Nothing
			else
				m_decLimite = dr.GetDecimal(dr.GetOrdinal("Limite"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Criado")) Then 
				m_strCriado = ""
			else
				m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			end if
			m_blnIsNew = false
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_CLIENTE"
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = m_intIDCliente
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar, 60).value = m_strCliente
			cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 20).value = m_strCNPJ
			cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 80).value = m_strEndereco
			cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar, 20).value = m_strBairro
			cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 40).value = m_strCidade
			cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 10).value = m_strCEP
			cmd.Parameters.Add("@UF", SqlDbType.Char, 2).value = m_strUF
			cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).value = m_strTelefone
			cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 20).value = m_strContato
			cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 1000).value = m_strObservacao
			cmd.Parameters.Add("@LATITUDE", SqlDbType.Float).value = m_dblLatitude
			cmd.Parameters.Add("@LONGITUDE", SqlDbType.Float).value = m_dblLongitude
			cmd.Parameters.Add("@IDPASTA", SqlDbType.Int).value = m_intIDPasta
			cmd.Parameters.Add("@IDBLOQUEIO", SqlDbType.Int).value = m_intIDBloqueio
            cmd.Parameters.Add("@LIMITE", SqlDbType.Money).Value = m_decLimite
            cmd.Parameters.Add("@IDCANAL", SqlDbType.Int).Value = m_intIDCanal
            cmd.Parameters.Add("@IDGRUPOCANAL", SqlDbType.Int).Value = m_intIDGrupoCanal

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
        ''' <param name="vIDCliente">Chave primaria IDCliente</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCliente As Integer) As Boolean
            Dim blnReturn As Boolean = False
            If vIDCliente = 0 Then
                Clear()
                Return blnReturn
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CLIENTE"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    blnReturn = True
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
            Return blnReturn
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
		Protected Sub Clear()
			m_intIDCliente = 0
			m_strCliente = ""
			m_strCNPJ = ""
			m_strEndereco = ""
			m_strBairro = ""
			m_strCidade = ""
			m_strCEP = ""
			m_strUF = ""
			m_strTelefone = ""
			m_strContato = ""
			m_strObservacao = ""
			m_dblLatitude = 0
			m_dblLongitude = 0
			m_intIDPasta = 0
			m_intIDBloqueio = 0
			m_decLimite = Nothing
			m_strCriado = ""
			m_blnIsNew = true 
		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_CLIENTE"
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = m_intIDCliente
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Cliente' the following row:  IDCliente=" & m_intIDCliente & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_CLIENTES"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
		''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
		''' <param name="vUF">Filtro</param>
		''' <param name="vIDPasta">Filtro</param>
		''' <param name="vIDBloqueio">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
		Public Function Listar(ByVal vFilter As String, vUF As String, vIDPasta As Integer, vIDBloqueio As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As PaginateResult

			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "NV_CLIENTES"
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).value = vFilter
			cmd.Parameters.Add("@UF", SqlDbType.Char, 2).value = vUF
			cmd.Parameters.Add("@IDPASTA", SqlDbType.Int).value = vIDPasta
			cmd.Parameters.Add("@IDBLOQUEIO", SqlDbType.Int).value = vIDBloqueio
			cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).value = vOrder
			cmd.Parameters.Add("@DESC", SqlDbType.Bit).value = vDescending
			cmd.Parameters.Add("@PAGE", SqlDbType.Int).value = vPage
			cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

		End Function
	  


		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
	
			return blnValid
			
		End Function
		
	#End Region

	End Class
End Namespace

