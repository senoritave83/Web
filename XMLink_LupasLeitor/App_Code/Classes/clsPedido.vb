

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsPedido
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_varIDPedido As Guid
		Protected m_intIDVendedor As Integer
		Protected m_strVendedor As String
		Protected m_intIDCliente As Integer
		Protected m_strCliente As String
		Protected m_strCodigo As String
		Protected m_strDataEmissao As String
		Protected m_intIDCondicao As Integer
		Protected m_strCondicao As String
		Protected m_strDataEntrega As String
        Protected m_indStatusPedido As Byte
        Protected m_strStatusPedido As String
        Protected m_sngDesconto As Single
		Protected m_strTransportadora As String
		Protected m_intIDSituacaoPedido As Integer
		Protected m_strSituacaoPedido As String
		Protected m_intNumeroPedido As Integer
		Protected m_intNaturezaOperacao As Short
		Protected m_intIDFormaPagamento As Integer
		Protected m_strFormaPagamento As String
		Protected m_strObservacao As String
		Protected m_intNumDevice As Integer
		Protected m_sngLatitude As Single
		Protected m_sngLongitude As Single
        Protected m_indIDTipoPedido As Byte
        Protected m_strTipoPedido As String
        Protected m_intIDVisita As Integer
        Protected m_indIDOpcao As Byte
        Protected m_decTotal As Decimal

        Public Enum enTipoPedido
            Venda = 1
            Consignacao = 2
            Bonificacao = 3
        End Enum
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

		Public Overridable readonly Property Vendedor As String
			Get
				Return m_strVendedor
			End Get
		End Property

		Public Overridable Property IDCliente As Integer
			Get
				Return m_intIDCliente
			End Get
			Set(ByVal Value As Integer)
				m_intIDCliente = Value
			End Set
		End Property

		Public Overridable readonly Property Cliente As String
			Get
				Return m_strCliente
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

		Public Overridable readonly Property Condicao As String
			Get
				Return m_strCondicao
			End Get
		End Property

		Public Overridable Property DataEntrega As String
			Get
				Return _getDateTimePropertyValue(m_strDataEntrega)
			End Get
			Set(ByVal Value As String)
				m_strDataEntrega = _setDateTimePropertyValue(Value)
			End Set
        End Property

        Public ReadOnly Property IDStatusPedido() As Integer
            Get
                Return m_indStatusPedido
            End Get
        End Property

        Public Overridable Property StatusPedido() As String
            Get
                Return m_strStatusPedido
            End Get
            Set(ByVal Value As String)
                m_strStatusPedido = Value
            End Set
        End Property

		Public Overridable Property Desconto As Single
			Get
				Return m_sngDesconto
			End Get
			Set(ByVal Value As Single)
				m_sngDesconto = Value
			End Set
		End Property

		Public Overridable Property Transportadora As String
			Get
				Return m_strTransportadora
			End Get
			Set(ByVal Value As String)
				m_strTransportadora = Value
			End Set
		End Property

		Public Overridable Property IDSituacaoPedido As Integer
			Get
				Return m_intIDSituacaoPedido
			End Get
			Set(ByVal Value As Integer)
				m_intIDSituacaoPedido = Value
			End Set
		End Property

		Public Overridable readonly Property SituacaoPedido As String
			Get
				Return m_strSituacaoPedido
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

		Public Overridable Property NaturezaOperacao As Short
			Get
				Return m_intNaturezaOperacao
			End Get
			Set(ByVal Value As Short)
				m_intNaturezaOperacao = Value
			End Set
		End Property

		Public Overridable Property IDFormaPagamento As Integer
			Get
				Return m_intIDFormaPagamento
			End Get
			Set(ByVal Value As Integer)
				m_intIDFormaPagamento = Value
			End Set
		End Property

		Public Overridable readonly Property FormaPagamento As String
			Get
				Return m_strFormaPagamento
			End Get
		End Property

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

        Public Overridable ReadOnly Property NumDevice() As Integer
            Get
                Return m_intNumDevice
            End Get
        End Property

        Public Overridable ReadOnly Property Latitude() As Single
            Get
                Return m_sngLatitude
            End Get
        End Property

        Public Overridable ReadOnly Property Longitude() As Single
            Get
                Return m_sngLongitude
            End Get
        End Property

        Public Overridable ReadOnly Property TipoPedido() As String
            Get
                Return m_strTipoPedido
            End Get
        End Property

        Public Overridable ReadOnly Property IDTipoPedido() As enTipoPedido
            Get
                Return m_indIDTipoPedido
            End Get
        End Property

        Public Overridable ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Overridable ReadOnly Property Opcao() As Byte
            Get
                Return m_indIDOpcao
            End Get
        End Property

        Public Overridable ReadOnly Property Total() As Decimal
            Get
                Return m_decTotal
            End Get
        End Property

	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			try
				m_varIDPedido = dr.GetGuid(dr.GetOrdinal("IDPedido"))
				m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
				m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
				if dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then 
					m_intIDCliente = 0
				else
					m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Cliente")) Then 
					m_strCliente = ""
				else
					m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
				end if
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
				if dr.IsDBNull(dr.GetOrdinal("Condicao")) Then 
					m_strCondicao = ""
				else
					m_strCondicao = dr.GetString(dr.GetOrdinal("Condicao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("DataEntrega")) Then 
					m_strDataEntrega = ""
				else
					m_strDataEntrega = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEntrega")))
				end if
                If dr.IsDBNull(dr.GetOrdinal("IDStatusPedido")) Then
                    m_indStatusPedido = 0
                Else
                    m_indStatusPedido = dr.GetByte(dr.GetOrdinal("IDStatusPedido"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("StatusPedido")) Then
                    m_strStatusPedido = ""
                Else
                    m_strStatusPedido = dr.GetString(dr.GetOrdinal("StatusPedido"))
                End If
				if dr.IsDBNull(dr.GetOrdinal("Desconto")) Then 
					m_sngDesconto = 0
				else
					m_sngDesconto = dr.GetFloat(dr.GetOrdinal("Desconto"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Transportadora")) Then 
					m_strTransportadora = ""
				else
					m_strTransportadora = dr.GetString(dr.GetOrdinal("Transportadora"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("IDSituacaoPedido")) Then 
					m_intIDSituacaoPedido = 0
				else
					m_intIDSituacaoPedido = dr.GetInt32(dr.GetOrdinal("IDSituacaoPedido"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("SituacaoPedido")) Then 
					m_strSituacaoPedido = ""
				else
					m_strSituacaoPedido = dr.GetString(dr.GetOrdinal("SituacaoPedido"))
				end if
				m_intNumeroPedido = dr.GetInt32(dr.GetOrdinal("NumeroPedido"))
				if dr.IsDBNull(dr.GetOrdinal("NaturezaOperacao")) Then 
					m_intNaturezaOperacao = 0
				else
					m_intNaturezaOperacao = dr.GetInt16(dr.GetOrdinal("NaturezaOperacao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("IDFormaPagamento")) Then 
					m_intIDFormaPagamento = 0
				else
					m_intIDFormaPagamento = dr.GetInt32(dr.GetOrdinal("IDFormaPagamento"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("FormaPagamento")) Then 
					m_strFormaPagamento = ""
				else
					m_strFormaPagamento = dr.GetString(dr.GetOrdinal("FormaPagamento"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
					m_strObservacao = ""
				else
					m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("NumDevice")) Then 
					m_intNumDevice = 0
				else
					m_intNumDevice = dr.GetInt32(dr.GetOrdinal("NumDevice"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Latitude")) Then 
					m_sngLatitude = 0
				else
					m_sngLatitude = dr.GetFloat(dr.GetOrdinal("Latitude"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Longitude")) Then 
					m_sngLongitude = 0
				else
					m_sngLongitude = dr.GetFloat(dr.GetOrdinal("Longitude"))
				end if
                If dr.IsDBNull(dr.GetOrdinal("IDTipoPedido")) Then
                    m_indIDTipoPedido = 0
                Else
                    m_indIDTipoPedido = dr.GetByte(dr.GetOrdinal("IDTipoPedido"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("TipoPedido")) Then
                    m_strTipoPedido = ""
                Else
                    m_strTipoPedido = dr.GetString(dr.GetOrdinal("TipoPedido"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("IDVisita")) Then
                    m_intIDVisita = 0
                Else
                    m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("IDOpcao")) Then
                    m_indIDOpcao = 0
                Else
                    m_indIDOpcao = dr.GetByte(dr.GetOrdinal("IDOpcao"))
                End If
                m_decTotal = dr.GetDecimal(dr.GetOrdinal("Total"))

			Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDPedido">Chave primaria IDPedido</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDPedido As String) As Boolean
            Try
                If vIDPedido = Nothing Then
                    Clear()
                    Return False
                End If
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PEDIDO"
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    Dim dr As IDataReader = cmd.ExecuteReader()
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
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_varIDPedido = Nothing
            m_intIDVendedor = 0
            m_intIDCliente = 0
            m_strCodigo = ""
            m_strDataEmissao = ""
            m_intIDCondicao = 0
            m_strDataEntrega = ""
            m_indStatusPedido = 0
            m_sngDesconto = 0
            m_strTransportadora = ""
            m_intIDSituacaoPedido = 0
            m_intNumeroPedido = 0
            m_intNaturezaOperacao = 0
            m_intIDFormaPagamento = 0
            m_strObservacao = ""
            m_intNumDevice = 0
            m_sngLatitude = 0
            m_sngLongitude = 0
            m_indIDTipoPedido = 0
            m_strTipoPedido = ""
            m_strStatusPedido = ""
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa de acordo com a visita
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIdVisita As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_PEDIDOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = vIdVisita
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vVendedor">Filtro</param>
        ''' <param name="vCliente">Filtro</param>
        ''' <param name="vDataEmissaoInicial">Filtro</param>
        ''' <param name="vDataEmissaoFinal">Filtro</param>
        ''' <param name="vStatusPedido">Filtro</param>
        ''' <param name="vTipoPedido">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vVendedor As Integer, ByVal vCliente As String, ByVal vDataEmissaoInicial As String, ByVal vDataEmissaoFinal As String, ByVal vStatusPedido As Byte, ByVal vTipoPedido As Byte, ByVal vIDFormaPagto As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIDUsuario As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_PEDIDOS"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vVendedor
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = vCliente
                If vDataEmissaoInicial <> "" Then
                    cmd.Parameters.Add("@DATAEMISSAOINICIAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoInicial)
                End If
                If vDataEmissaoFinal <> "" Then
                    cmd.Parameters.Add("@DATAEMISSAOFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataEmissaoFinal)
                End If
                cmd.Parameters.Add("@STATUSPEDIDO", SqlDbType.TinyInt).Value = vStatusPedido
                cmd.Parameters.Add("@TIPOPEDIDO", SqlDbType.TinyInt).Value = vTipoPedido
                cmd.Parameters.Add("@IDFORMAPAGTO", SqlDbType.Int).Value = vIDFormaPagto
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                If vIDUsuario > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
                cn.Open()

                If vReturnType = enReturnType.DataReader Then
                    Dim dr As IDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    If dr.Read Then
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = dr.GetInt32(0)
                        If dr.NextResult Then
                            ret.Data = dr
                        End If
                    End If
                Else
                    Try
                        Dim ad As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet
                        ad.Fill(ds)
                        ret.PageSize = vPageSize
                        ret.CurrentPage = vPage
                        ret.RecordCount = ds.Tables(0).Rows(0).Item(0)
                        ret.Data = ds.Tables(1)
                    Finally
                        If (Not cn Is Nothing) Then
                            cn.Close()
                            cn = Nothing
                        End If
                    End Try
                End If

            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return ret
        End Function


        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDPedido">Chave primaria IDPedido do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDPedido As Guid, ByVal vCodigo As String) As Boolean
            Dim blnExiste As Boolean = True
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_PEDIDO_EXISTENTE"
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.UniqueIdentifier).value = vIDPedido
                cmd.Parameters.Add("@CODIGO", SqlDbType.NVarChar, 40).value = vCodigo
                cn.Open()
                Try
                    blnExiste = cmd.ExecuteScalar()
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnExiste
        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            Try
                If m_strCodigo = "" Then
                    AddBrokenRule("O código é obrigatório!")
                    blnValid = False
                ElseIf Existe(m_varIDPedido, m_strCodigo) Then
                    AddBrokenRule("O código informado já existe!")
                    blnValid = False
                End If
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
            Return blnValid
        End Function

        Public Function ListItensPedido(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDO_ITENS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_varIDPedido.ToString
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function ListItensRepostos(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDO_ITENS_REPOSTOS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_varIDPedido.ToString
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        Public Function Update(ByVal vIDCondicao As Integer, ByVal vIDForma As Integer) As String
            Dim vMessage As String = ""
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            Try
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "UP_PEDIDO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.UniqueIdentifier).Value = m_varIDPedido
                cmd.Parameters.Add("@IDCONDICAO", SqlDbType.Int).Value = vIDCondicao
                cmd.Parameters.Add("@IDFORMA", SqlDbType.Int).Value = vIDForma
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch e As SqlException
                vMessage = e.Message
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
            Return vMessage
        End Function

        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Function Delete() As String
            Dim vMessage As String = ""
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            Try
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_PEDIDO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.UniqueIdentifier).Value = m_varIDPedido
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
                cn.Open()
                cmd.ExecuteNonQuery()
                MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Pedido' the following row:  IDPedido=" & Convert.ToString(m_varIDPedido) & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Catch e As SqlException
                vMessage = e.Message
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
            Clear()
            Return vMessage
        End Function

        Public Function Historico(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_PEDIDO_HISTORICO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = m_varIDPedido.ToString
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna um DataSet
        ''' </summary>
        ''' <param name="vIDItemPedido">Filtro</param>
        ''' <param name="vIDPedido">Filtro</param>
        ''' <returns>DataSet</returns>
        Public Function LoadItemPedido(ByVal vIDItemPedido As String, ByVal vIDPedido As String) As DataSet

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ITEMPEDIDO"

            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDITEMPEDIDO", SqlDbType.VarChar).Value = vIDItemPedido
            cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido

            Return MyBase.ExecuteCommand(cmd, enReturnType.DataSet)

        End Function

        Public Function SalvarItemPedido(ByVal vIDItemPedido As String, ByVal vIDPedido As String, ByVal vPrecoUnitario As String) As Boolean

            Dim blnValid As Boolean = True
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            Try
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_ITEMPEDIDO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDITEMPEDIDO", SqlDbType.VarChar).Value = vIDItemPedido
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
                cmd.Parameters.Add("@PRECOUNITARIO", SqlDbType.Money).Value = vPrecoUnitario
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch e As SqlException
                blnValid = False
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
            Return blnValid

        End Function

        Public Function DeleteItemPedido(ByVal vIDItemPedido As String, ByVal vIDPedido As String) As Boolean

            Dim blnValid As Boolean = True
            Dim cn As SqlConnection = GetDBConnection()
            Dim cmd As New SqlCommand()
            Try
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_ITEMPEDIDO"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@IDITEMPEDIDO", SqlDbType.VarChar).Value = vIDItemPedido
                cmd.Parameters.Add("@IDPEDIDO", SqlDbType.VarChar).Value = vIDPedido
                cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = User.IDUser
                cn.Open()
                cmd.ExecuteNonQuery()
            Catch e As SqlException
                blnValid = False
            Finally
                If (Not cn Is Nothing) Then
                    cn.Close()
                    cn = Nothing
                End If
            End Try
            Return blnValid
        End Function

#End Region

    End Class
End Namespace

