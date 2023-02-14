

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsPedido
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_varIDPedido As Guid
		Protected m_intIDVendedor As Integer
        Protected m_strVendedor As String
        Protected m_intIDCliente As Integer
        Protected m_strCliente As String
        Protected m_strCnpj As String
        Protected m_strUf As String
		Protected m_intIDVisita As Integer
		Protected m_intNumeroPedido As Integer
        Protected m_strCodigo As String
        Protected m_decDesconto As Decimal
		Protected m_strDataEmissao As String
        Protected m_intIDCondicao As Integer
        Protected m_strCondicao As String
		Protected m_strDataEntrega As String
        Protected m_indIDStatusPedido As Byte
        Protected m_strStatusPedido As String
        Protected m_intIDSituacaoPedido As Integer
        Protected m_strSituacaoPedido As String
		Protected m_sngLatitude As Single
        Protected m_sngLongitude As Single
        Protected m_decTotal As Decimal
        Protected m_decSubTotal As Decimal
        Protected m_strObservacao As String
		Protected m_blnIsNew as Boolean = true
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDPedido As Guid
			Get
				Return m_varIDPedido
			End Get
		End Property

		Public Overridable Property IDVendedor As Integer
			Get
				Return m_intIDVendedor
			End Get
			Set(ByVal Value As Integer)
				m_intIDVendedor = Value
			End Set
		End Property

        Public Overridable ReadOnly Property Vendedor() As String
            Get
                Return m_strVendedor
            End Get
        End Property

        Public Overridable Property IDCliente() As Integer
            Get
                Return m_intIDCliente
            End Get
            Set(ByVal Value As Integer)
                m_intIDCliente = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public Overridable ReadOnly Property Cnpj() As String
            Get
                Return m_strCnpj
            End Get
        End Property

        Public Overridable ReadOnly Property Uf() As String
            Get
                Return m_strUf
            End Get
        End Property

        Public ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get

        End Property

		Public Overridable Property NumeroPedido As Integer
			Get
				Return m_intNumeroPedido
			End Get
			Set(ByVal Value As Integer)
				m_intNumeroPedido = Value
			End Set
		End Property

		Public Overridable Property Codigo As String
			Get
				Return m_strCodigo
			End Get
			Set(ByVal Value As String)
				m_strCodigo = Value
			End Set
		End Property

		Public Overridable Property DataEmissao As String
			Get
				Return _getDateTimePropertyValue(m_strDataEmissao)
			End Get
			Set(ByVal Value As String)
				m_strDataEmissao = _setDateTimePropertyValue(Value)
			End Set
		End Property

		Public Overridable Property IDCondicao As Integer
			Get
				Return m_intIDCondicao
			End Get
			Set(ByVal Value As Integer)
				m_intIDCondicao = Value
			End Set
		End Property

        Public Overridable ReadOnly Property Condicao() As String
            Get
                Return m_strCondicao
            End Get
        End Property

		Public Overridable Property DataEntrega As String
			Get
                Return _getDatePropertyValue(m_strDataEntrega)
			End Get
			Set(ByVal Value As String)
				m_strDataEntrega = _setDateTimePropertyValue(Value)
			End Set
		End Property

        Public Overridable Property IDStatusPedido() As Byte
            Get
                Return m_indIDStatusPedido
            End Get
            Set(ByVal Value As Byte)
                m_indIDStatusPedido = Value
            End Set
        End Property

        Public Overridable ReadOnly Property StatusPedido() As String
            Get
                Return m_strStatusPedido
            End Get
        End Property

		Public Overridable Property IDSituacaoPedido As Integer
			Get
				Return m_intIDSituacaoPedido
			End Get
			Set(ByVal Value As Integer)
				m_intIDSituacaoPedido = Value
			End Set
		End Property

        Public Overridable ReadOnly Property SituacaoPedido() As String
            Get
                Return m_strSituacaoPedido
            End Get
        End Property


		Public Overridable Property Latitude As Single
			Get
				Return m_sngLatitude
			End Get
			Set(ByVal Value As Single)
				m_sngLatitude = Value
			End Set
		End Property

		Public Overridable Property Longitude As Single
			Get
				Return m_sngLongitude
			End Get
			Set(ByVal Value As Single)
				m_sngLongitude = Value
			End Set
		End Property

        Public ReadOnly Property Desconto() As Decimal
            Get
                Return m_decDesconto
            End Get
        End Property

        Public ReadOnly Property Total() As Decimal
            Get
                Return m_decTotal
            End Get
        End Property

        Public ReadOnly Property SubTotal() As Decimal
            Get
                Return m_decSubTotal
            End Get
        End Property

        Public ReadOnly Property Observacao() As String
            Get
                Return m_strObservacao
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
			m_varIDPedido = dr.GetGuid(dr.GetOrdinal("IDPedido"))
			m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            If dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then
                m_intIDCliente = 0
            Else
                m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cliente")) Then
                m_strCliente = ""
            Else
                m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cnpj")) Then
                m_strCnpj = ""
            Else
                m_strCnpj = dr.GetString(dr.GetOrdinal("Cnpj"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Uf")) Then
                m_strUf = ""
            Else
                m_strUf = dr.GetString(dr.GetOrdinal("Uf"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDVisita")) Then
                m_intIDVisita = 0
            Else
                m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            End If
			m_intNumeroPedido = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
			if dr.IsDBNull(dr.GetOrdinal("Codigo")) Then 
				m_strCodigo = ""
			else
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("DataEmissao")) Then 
				m_strDataEmissao = ""
			else
				m_strDataEmissao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEmissao")))
			end if
			if dr.IsDBNull(dr.GetOrdinal("IDCondicao")) Then 
				m_intIDCondicao = 0
			else
				m_intIDCondicao = dr.GetInt32(dr.GetOrdinal("IDCondicao"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("Condicao")) Then
                m_strCondicao = ""
            Else
                m_strCondicao = dr.GetString(dr.GetOrdinal("Condicao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataEntrega")) Then
                m_strDataEntrega = ""
            Else
                m_strDataEntrega = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEntrega")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("IDStatusPedido")) Then
                m_indIDStatusPedido = 0
            Else
                m_indIDStatusPedido = dr.GetByte(dr.GetOrdinal("IDStatusPedido"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("StatusPedido")) Then
                m_strStatusPedido = ""
            Else
                m_strStatusPedido = dr.GetString(dr.GetOrdinal("StatusPedido"))
            End If

			if dr.IsDBNull(dr.GetOrdinal("IDSituacaoPedido")) Then 
				m_intIDSituacaoPedido = 0
			else
				m_intIDSituacaoPedido = dr.GetInt32(dr.GetOrdinal("IDSituacaoPedido"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("SituacaoPedido")) Then
                m_strSituacaoPedido = ""
            Else
                m_strSituacaoPedido = dr.GetString(dr.GetOrdinal("SituacaoPedido"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Latitude")) Then
                m_sngLatitude = 0
            Else
                m_sngLatitude = dr.GetFloat(dr.GetOrdinal("Latitude"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Longitude")) Then
                m_sngLongitude = 0
            Else
                m_sngLongitude = dr.GetFloat(dr.GetOrdinal("Longitude"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Desconto")) Then
                m_decDesconto = 0
            Else
                m_decDesconto = dr.GetFloat(dr.GetOrdinal("Desconto"))
            End If
            m_decTotal = dr.GetDecimal(dr.GetOrdinal("Total"))
            m_decSubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
            m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            m_blnIsNew = False
		End Sub

        Public Sub ConfirmaImpressao(ByVal confImp As String)

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "UP_CONFIRMAIMPRESSAO"
            cmd.Parameters.Add("@PEDIDOS", SqlDbType.VarChar).Value = confImp
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

        End Sub



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPedido">Chave primaria IDPedido</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPedido As String) As Boolean
            If vIDPedido = Nothing Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PEDIDO"
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
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
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_varIDPedido = Nothing
            m_intIDVendedor = 0
            m_strVendedor = ""
            m_intIDCliente = 0
            m_strCliente = ""
            m_strCnpj = ""
            m_strUf = ""
            m_intIDVisita = 0
            m_intNumeroPedido = 0
            m_strCodigo = ""
            m_strDataEmissao = ""
            m_intIDCondicao = 0
            m_strCondicao = ""
            m_strDataEntrega = ""
            m_indIDStatusPedido = 0
            m_strStatusPedido = ""
            m_intIDSituacaoPedido = 0
            m_strSituacaoPedido = ""
            m_sngLatitude = 0
            m_sngLongitude = 0
            m_decDesconto = 0
            m_decTotal = 0
            m_decSubTotal = 0
            m_strObservacao = ""
            m_blnIsNew = True
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDVisita As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIDVisita
            Return ExecuteCommand(cmd, vReturnType)

        End Function


        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vCliente">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vVendedor As String, ByVal vCliente As String, ByVal vCnpj As String, ByVal vUf As String, ByVal vIDStatus As Integer, ByVal vDataEmissaoInicial As String, ByVal vDataEmissaoFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_PEDIDOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar).Value = vVendedor
            cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
            cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = vCnpj
            cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = vUf
            cmd.Parameters.Add("@IDSTATUS", SqlDbType.Int).Value = vIDStatus
            If vDataEmissaoInicial <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoInicial)
            End If
            If vDataEmissaoFinal <> "" Then
                cmd.Parameters.Add("@DATAEMISSAOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoFinal)
            End If

            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function




        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDPedido">Chave primaria IDPedido do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDPedido As Guid, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_PEDIDO_EXISTENTE"
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.UniqueIdentifier).Value = vIDPedido
            cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 40).Value = vCodigo
            Return ExecuteScalar(cmd)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" Then
                AddBrokenRule("O código é obrigatório!")
                blnValid = False
            ElseIf Existe(m_varIDPedido, m_strCodigo) Then
                AddBrokenRule("O código informado já existe!")
                blnValid = False
            End If

            Return blnValid

        End Function



        Public Function ListItensPedido(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListItensPedido(m_varIDPedido.ToString, vReturnType)
        End Function

        Public Function ListItensPedido(ByVal vIDPedido As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDO_ITENS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que exclui pedidos do banco de dados
        ''' </summary>
        Public Sub CancelarPedido(ByVal vIDPedido As String)

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_PEDIDO_CANCELAR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
            ExecuteNonQuery(cmd)

        End Sub


#End Region

    End Class
End Namespace

