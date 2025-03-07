

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsCliente
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCliente As Integer
		Protected m_strCodigo As String
		Protected m_intIDVendedor As Integer
        Protected m_strCliente As String
		Protected m_strCNPJ As String
		Protected m_strEndereco As String
		Protected m_strReferencia As String
		Protected m_strBairro As String
		Protected m_strCidade As String
		Protected m_strCEP As String
		Protected m_strUF As String
		Protected m_strTelefone As String
		Protected m_strContato As String
		Protected m_strObservacao As String
		Protected m_strCriado As String
		Protected m_sngTabelaPreco As Single
		Protected m_sngDescontoMax As Single
        Protected m_decLimiteCredito As Decimal
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
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

		Public Overridable Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
			Set(ByVal Value As Integer)
				m_intIDVendedor = Value
			End Set
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

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public Overridable Property TabelaPreco() As Single
            Get
                Return m_sngTabelaPreco
            End Get
            Set(ByVal Value As Single)
                m_sngTabelaPreco = Value
            End Set
        End Property

        Public Overridable Property DescontoMax() As Single
            Get
                Return m_sngDescontoMax
            End Get
            Set(ByVal Value As Single)
                m_sngDescontoMax = Value
            End Set
        End Property

        Public Overridable Property LimiteCredito() As Decimal
            Get
                Return m_decLimiteCredito
            End Get
            Set(ByVal Value As Decimal)
                m_decLimiteCredito = Value
            End Set
        End Property

        Public ReadOnly Property IsNew() As Boolean
            Get
                Return m_blnIsNew
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            If dr.IsDBNull(dr.GetOrdinal("IDVendedor")) Then
                m_intIDVendedor = 0
            Else
                m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            End If
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            If dr.IsDBNull(dr.GetOrdinal("CNPJ")) Then
                m_strCNPJ = ""
            Else
                m_strCNPJ = dr.GetString(dr.GetOrdinal("CNPJ"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Endereco")) Then
                m_strEndereco = ""
            Else
                m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Referencia")) Then
                m_strReferencia = ""
            Else
                m_strReferencia = dr.GetString(dr.GetOrdinal("Referencia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Bairro")) Then
                m_strBairro = ""
            Else
                m_strBairro = dr.GetString(dr.GetOrdinal("Bairro"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cidade")) Then
                m_strCidade = ""
            Else
                m_strCidade = dr.GetString(dr.GetOrdinal("Cidade"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("CEP")) Then
                m_strCEP = ""
            Else
                m_strCEP = dr.GetString(dr.GetOrdinal("CEP"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("UF")) Then
                m_strUF = ""
            Else
                m_strUF = dr.GetString(dr.GetOrdinal("UF"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Telefone")) Then
                m_strTelefone = ""
            Else
                m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Contato")) Then
                m_strContato = ""
            Else
                m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Observacao")) Then
                m_strObservacao = ""
            Else
                m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Criado")) Then
                m_strCriado = ""
            Else
                m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("TabelaPreco")) Then
                m_sngTabelaPreco = 0
            Else
                m_sngTabelaPreco = dr.GetFloat(dr.GetOrdinal("TabelaPreco"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DescontoMax")) Then
                m_sngDescontoMax = 0
            Else
                m_sngDescontoMax = dr.GetFloat(dr.GetOrdinal("DescontoMax"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("LimiteCredito")) Then
                m_decLimiteCredito = Nothing
            Else
                m_decLimiteCredito = dr.GetDecimal(dr.GetOrdinal("LimiteCredito"))
            End If

        
            m_blnIsNew = False
        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCliente">Chave primaria IDCliente</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCliente As Integer) As Boolean
            If vIDCliente = 0 Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CLIENTE"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Function



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vCodigo">Código do cliente</param>
        ''' <returns>Boolean</returns>
        Public Function LoadByCodigo(ByVal vCodigo As String) As Boolean
            If vCodigo = "" Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CLIENTE_CODIGO"
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar).Value = vCodigo
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                    LoadByCodigo = True
                Else
                    Clear()
                End If

            Finally
                If (Not dr Is Nothing) Then
                    dr.Close()
                    dr = Nothing
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCliente = 0
            m_strCodigo = ""
            m_intIDVendedor = 0
            m_strCliente = ""
            m_strCNPJ = ""
            m_strEndereco = ""
            m_strReferencia = ""
            m_strBairro = ""
            m_strCidade = ""
            m_strCEP = ""
            m_strUF = ""
            m_strTelefone = ""
            m_strContato = ""
            m_strObservacao = ""
            m_strCriado = ""
            m_sngTabelaPreco = 0
            m_sngDescontoMax = 0
            m_decLimiteCredito = 0
            m_blnIsNew = True
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDVendedor">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDVendedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


#End Region

    End Class
End Namespace

