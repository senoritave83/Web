

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsNegociacao
		Inherits BaseClass



	#Region "Declarations" 
        Protected m_varIDNegociacao As Guid
		Protected m_intIDVendedor As Integer
        Protected m_strCodigo As String
        Protected m_strVendedor As String
        Protected m_intIDCliente As Integer
        Protected m_strCodigoCliente As Integer
        Protected m_strCliente As String
        Protected m_intIDVisita As Integer
        Protected m_intNumeroNegociacao As Integer
        Protected m_strDataEmissao As String
        Protected m_intIDCondicao As Integer
        Protected m_strCondicao As String
		Protected m_strDataEntrega As String
        Protected m_decTotal As Decimal
        Protected m_decDesconto As Decimal
        Protected m_decSubTotal As Decimal
        Protected m_intIDFormaPagamento As Integer
        Protected m_strFormaPagamento As String

        Protected m_strReferencia As String
        Protected m_strOrdemHeader As String
        Protected m_strOrdemFooter As String
        Protected m_strPrioridade As String
        Protected m_curValorBruto As String
        Protected m_strMarketCode As String
        Protected m_strOrdemVenda As String
        Protected m_strObservacao As String

        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
        Public Overridable ReadOnly Property IDNegociacao() As Guid
            Get
                Return m_varIDNegociacao
            End Get
        End Property

        Public Overridable ReadOnly Property Codigo() As String
            Get
                Return m_strCodigo
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

        Public ReadOnly Property Observacao() As String
            Get
                Return m_strObservacao
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

        Public Overridable Property CodigoCliente() As String
            Get
                Return m_strCodigoCliente
            End Get
            Set(ByVal value As String)
                m_strCodigoCliente = value
            End Set
        End Property

        Public Overridable ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get

        End Property

        Public Overridable Property NumeroNegociacao() As Integer
            Get
                Return m_intNumeroNegociacao
            End Get
            Set(ByVal Value As Integer)
                m_intNumeroNegociacao = Value
            End Set
        End Property

        Public Overridable ReadOnly Property DataEmissao() As String
            Get
                Return _getDateTimePropertyValue(m_strDataEmissao)
            End Get
        End Property

        Public Overridable ReadOnly Property IDCondicao() As Integer
            Get
                Return m_intIDCondicao
            End Get
        End Property

        Public Overridable ReadOnly Property Condicao() As String
            Get
                Return m_strCondicao
            End Get
        End Property

        Public Overridable ReadOnly Property DataEntrega() As String
            Get
                Return _getDatePropertyValue(m_strDataEntrega)
            End Get
        End Property


        Public ReadOnly Property MarketCode() As String
            Get
                Return m_strMarketCode
            End Get
        End Property

        Public ReadOnly Property Desconto() As Decimal
            Get
                Return m_decDesconto
            End Get
        End Property

        Public ReadOnly Property PorcentagemDesconto() As Decimal
            Get
                If m_decSubTotal <> 0 Then
                    Return m_decDesconto / m_decSubTotal
                Else
                    Return 0
                End If
            End Get
        End Property

        Public ReadOnly Property FormaPagamento() As String
            Get
                Return m_strFormaPagamento
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

        Public ReadOnly Property ValorBruto() As Decimal
            Get
                Return m_curValorBruto
            End Get
        End Property

        Public ReadOnly Property Referencia() As String
            Get
                Return m_strReferencia
            End Get
        End Property

        Public ReadOnly Property OrdemHeader() As String
            Get
                Return m_strOrdemHeader
            End Get
        End Property

        Public ReadOnly Property OrdemFooter() As String
            Get
                Return m_strOrdemFooter
            End Get
        End Property

        Public ReadOnly Property Prioridade() As String
            Get
                Return m_strPrioridade
            End Get
        End Property

        Public ReadOnly Property OrdemVenda() As String
            Get
                Return m_strOrdemVenda
            End Get
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
            m_varIDNegociacao = dr.GetGuid(dr.GetOrdinal("IDNegociacao"))
            If dr.IsDBNull(dr.GetOrdinal("Codigo")) Then
                m_strCodigo = ""
            Else
                m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
            End If
            m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
            m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
            If dr.IsDBNull(dr.GetOrdinal("IDCliente")) Then
                m_intIDCliente = 0
            Else
                m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("CodigoCliente")) Then
                m_strCodigoCliente = ""
            Else
                m_strCodigoCliente = dr.GetString(dr.GetOrdinal("CodigoCliente"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Cliente")) Then
                m_strCliente = ""
            Else
                m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Referencia")) Then
                m_strReferencia = ""
            Else
                m_strReferencia = dr.GetString(dr.GetOrdinal("Referencia"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("OrdemHeader")) Then
                m_strOrdemHeader = ""
            Else
                m_strOrdemHeader = dr.GetString(dr.GetOrdinal("OrdemHeader"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("OrdemFooter")) Then
                m_strOrdemFooter = ""
            Else
                m_strOrdemFooter = dr.GetString(dr.GetOrdinal("OrdemFooter"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Prioridade")) Then
                m_strPrioridade = ""
            Else
                m_strPrioridade = dr.GetString(dr.GetOrdinal("Prioridade"))
            End If
            m_intIDVisita = 0
            m_intNumeroNegociacao = dr.GetInt32(dr.GetOrdinal("NumeroNegociacao"))
            If dr.IsDBNull(dr.GetOrdinal("DataEmissao")) Then
                m_strDataEmissao = ""
            Else
                m_strDataEmissao = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEmissao")))
            End If
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
            If dr.IsDBNull(dr.GetOrdinal("IDFormaPagamento")) Then
                m_intIDFormaPagamento = 0
            Else
                m_intIDFormaPagamento = dr.GetInt32(dr.GetOrdinal("IDFormaPagamento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("FormaPagamento")) Then
                m_strFormaPagamento = ""
            Else
                m_strFormaPagamento = dr.GetString(dr.GetOrdinal("FormaPagamento"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("DataEntrega")) Then
                m_strDataEntrega = ""
            Else
                m_strDataEntrega = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataEntrega")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Desconto")) Then
                m_decDesconto = 0
            Else
                m_decDesconto = dr.GetDecimal(dr.GetOrdinal("Desconto"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("ValorBruto")) Then
                m_curValorBruto = 0
            Else
                m_curValorBruto = dr.GetDecimal(dr.GetOrdinal("ValorBruto"))
            End If

            If dr.IsDBNull(dr.GetOrdinal("Observacao")) Then
                m_strObservacao = ""
            Else
                m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("MarketCode")) Then
                m_strMarketCode = ""
            Else
                m_strMarketCode = dr.GetString(dr.GetOrdinal("MarketCode"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("OrdemVenda")) Then
                m_strOrdemVenda = ""
            Else
                m_strOrdemVenda = dr.GetString(dr.GetOrdinal("OrdemVenda"))
            End If
            
            m_decTotal = dr.GetDecimal(dr.GetOrdinal("Total"))
            m_decSubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
            m_blnIsNew = False
		End Sub



        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDNegociacao">Chave primaria IDPedido</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDNegociacao As String) As Boolean
            If vIDNegociacao = Nothing Then
                Clear()
                Return False
            End If
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_NEGOCIACAO"
            cmd.Parameters.Add("@IDNEGOCIACAO", SqlDbType.VarChar).Value = vIDNegociacao
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
            m_varIDNegociacao = Nothing
            m_intIDVendedor = 0
            m_strVendedor = ""
            m_intIDCliente = 0
            m_strCodigoCliente = ""
            m_strCliente = ""
            m_intIDVisita = 0
            m_intNumeroNegociacao = 0
            m_strDataEmissao = ""
            m_intIDCondicao = 0
            m_strCondicao = ""
            m_strDataEntrega = ""
            m_decDesconto = 0
            m_decTotal = 0
            m_decSubTotal = 0
            m_strReferencia = ""
            m_strOrdemHeader = ""
            m_strOrdemFooter = ""
            m_strPrioridade = ""
            m_curValorBruto = 0
            m_strCodigo = ""
            m_strObservacao = ""
            m_strMarketCode = ""
            m_strOrdemVenda = ""
            m_blnIsNew = True
        End Sub


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
            cmd.CommandText = PREFIXO & "NV_NEGOCIACOES"
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

        Public Function ListaItens(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Return ListaItens(m_varIDNegociacao.ToString, vReturnType)
        End Function

        Public Function ListaItens(ByVal vIDNegociacao As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_NEGOCIACAO_ITENS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDNEGOCIACAO", SqlDbType.VarChar).Value = vIDNegociacao
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function


#End Region

    End Class
End Namespace

