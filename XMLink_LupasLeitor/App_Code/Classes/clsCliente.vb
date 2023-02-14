

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Namespace Classes

	Public Class clsCliente
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDCliente As Integer
		Protected m_strCodigo As String
		Protected m_intIDVendedor As Integer
		Protected m_strVendedor As String
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
        Protected m_strEmail As String
		Protected m_strObservacao As String
		Protected m_strCriado As String
		Protected m_sngTabelaPreco As Single
		Protected m_sngDescontoMax As Single
		Protected m_decLimiteCredito As Decimal
        Protected m_intIDCondicaoPadrao As Integer
        Protected m_clsConsignacao As clsConsignacao
        Protected m_strNomeFantasia As String
        Protected m_blnBloqueado As Boolean
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

		Public Overridable readonly Property Vendedor As String
			Get
				Return m_strVendedor
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
        Public Overridable Property Email As String
            Get
                Return m_strEmail
            End Get
            Set(ByVal Value As String)
                m_strEmail = Value
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

        Public Overridable Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
            Set(ByVal Value As String)
                m_strCriado = Value
            End Set
        End Property

		Public Overridable Property TabelaPreco As Single
			Get
				Return m_sngTabelaPreco
			End Get
			Set(ByVal Value As Single)
				m_sngTabelaPreco = Value
			End Set
		End Property

		Public Overridable Property DescontoMax As Single
			Get
				Return m_sngDescontoMax
			End Get
			Set(ByVal Value As Single)
				m_sngDescontoMax = Value
			End Set
		End Property

		Public Overridable Property LimiteCredito As Decimal
			Get
				Return m_decLimiteCredito
			End Get
			Set(ByVal Value As Decimal)
				m_decLimiteCredito = Value
			End Set
		End Property

		Public Overridable Property IDCondicaoPadrao As Integer
			Get
				Return m_intIDCondicaoPadrao
			End Get
			Set(ByVal Value As Integer)
				m_intIDCondicaoPadrao = Value
			End Set
		End Property

        Public ReadOnly Property Consignacao() As clsConsignacao
            Get
                If m_clsConsignacao Is Nothing Then
                    m_clsConsignacao = New clsConsignacao(m_intIDCliente)
                End If
                Return m_clsConsignacao
            End Get
        End Property

        Public Overridable Property NomeFantasia() As String
            Get
                Return m_strNomeFantasia
            End Get
            Set(ByVal value As String)
                m_strNomeFantasia = value
            End Set
        End Property


        Public Overridable Property Bloqueado() As Boolean
            Get
                Return m_blnBloqueado
            End Get
            Set(ByVal value As Boolean)
                m_blnBloqueado = value
            End Set
        End Property


	#End Region  
	
    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
		Protected Overridable Sub Inflate(ByVal dr As IDataReader)
			try
				m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
				if dr.IsDBNull(dr.GetOrdinal("IDVendedor")) Then 
					m_intIDVendedor = 0
				else
					m_intIDVendedor = dr.GetInt32(dr.GetOrdinal("IDVendedor"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Vendedor")) Then 
					m_strVendedor = ""
				else
					m_strVendedor = dr.GetString(dr.GetOrdinal("Vendedor"))
				end if
				m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
				if dr.IsDBNull(dr.GetOrdinal("CNPJ")) Then 
					m_strCNPJ = ""
				else
					m_strCNPJ = dr.GetString(dr.GetOrdinal("CNPJ"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Endereco")) Then 
					m_strEndereco = ""
				else
					m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
				end if
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
				if dr.IsDBNull(dr.GetOrdinal("Telefone")) Then 
					m_strTelefone = ""
				else
					m_strTelefone = dr.GetString(dr.GetOrdinal("Telefone"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Contato")) Then 
					m_strContato = ""
				else
					m_strContato = dr.GetString(dr.GetOrdinal("Contato"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("email")) Then
                    m_strEmail = ""
                Else
                    m_strEmail = dr.GetString(dr.GetOrdinal("email"))
                End If
				if dr.IsDBNull(dr.GetOrdinal("Observacao")) Then 
					m_strObservacao = ""
				else
					m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("Criado")) Then 
					m_strCriado = ""
				else
					m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
				end if
				if dr.IsDBNull(dr.GetOrdinal("TabelaPreco")) Then 
					m_sngTabelaPreco = 0
				else
					m_sngTabelaPreco = dr.GetFloat(dr.GetOrdinal("TabelaPreco"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("DescontoMax")) Then 
					m_sngDescontoMax = 0
				else
					m_sngDescontoMax = dr.GetFloat(dr.GetOrdinal("DescontoMax"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("LimiteCredito")) Then 
					m_decLimiteCredito = Nothing
				else
					m_decLimiteCredito = dr.GetDecimal(dr.GetOrdinal("LimiteCredito"))
				end if
				if dr.IsDBNull(dr.GetOrdinal("IDCondicaoPadrao")) Then 
					m_intIDCondicaoPadrao = 0
				else
					m_intIDCondicaoPadrao = dr.GetInt32(dr.GetOrdinal("IDCondicaoPadrao"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("NomeFantasia")) Then
                    m_strNomeFantasia = ""
                Else
                    m_strNomeFantasia = dr.GetString(dr.GetOrdinal("NomeFantasia"))
                End If
                If dr.IsDBNull(dr.GetOrdinal("Bloqueado")) Then
                    m_blnBloqueado = False
                Else
                    m_blnBloqueado = IIf(dr.Item(dr.GetOrdinal("Bloqueado")), True, False)
                End If
			Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SV_CLIENTE"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = m_intIDCliente
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).value = m_intIDVendedor
                cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar, 100).value = m_strCliente
                cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar, 20).value = m_strCNPJ
                cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar, 150).value = m_strEndereco
                cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar, 50).value = m_strReferencia
                cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar, 30).value = m_strBairro
                cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar, 50).value = m_strCidade
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar, 10).value = m_strCEP
                cmd.Parameters.Add("@UF", SqlDbType.Char, 2).value = m_strUF
                cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar, 20).value = m_strTelefone
                cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 30).Value = m_strContato
                cmd.Parameters.Add("@EMAIL", SqlDbType.VarChar, 50).Value = m_strEmail
                cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 1000).value = m_strObservacao
                cmd.Parameters.Add("@TABELAPRECO", SqlDbType.Real).value = m_sngTabelaPreco
                cmd.Parameters.Add("@DESCONTOMAX", SqlDbType.Real).value = m_sngDescontoMax
                cmd.Parameters.Add("@LIMITECREDITO", SqlDbType.Money).value = m_decLimiteCredito
                cmd.Parameters.Add("@IDCONDICAOPADRAO", SqlDbType.Int).Value = m_intIDCondicaoPadrao
                cmd.Parameters.Add("@NOMEFANTASIA", SqlDbType.VarChar, 100).Value = m_strNomeFantasia
                cmd.Parameters.Add("@DATACRIADO", SqlDbType.DateTime).Value = m_strCriado
                cmd.Parameters.Add("@BLOQUEADO", SqlDbType.Bit).Value = IIf(m_blnBloqueado = True, 1, 0)
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
        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCliente">Chave primaria IDCliente</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCliente As Integer) As Boolean
            Try
                If vIDCliente = 0 Then
                    Clear()
                    Return False
                End If
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_CLIENTE"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            m_decLimiteCredito = Nothing
            m_intIDCondicaoPadrao = 0
            m_strNomeFantasia = ""
            m_blnBloqueado = False
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_CLIENTE"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = m_intIDCliente
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Cliente' the following row:  IDCliente=" & m_intIDCliente & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
                Finally
                    If (Not cn Is Nothing) Then
                        cn.Close()
                        cn = Nothing
                    End If
                End Try
                Clear()
            Catch ex As Exception

                If (1 = 2) Then
                    Throw
                End If
            End Try
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vUF">Filtro</param>
        ''' <param name="vIDUser">Chave primária do usuário</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vUF As String, ByVal vReferencia As String, ByVal vClienteBloqueado As Short, _
                               ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIDUser As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Dim ret As New PaginateResult
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "NV_CLIENTES"
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
                cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar, 50).Value = vReferencia
                cmd.Parameters.Add("@UF", SqlDbType.Char, 2).Value = vUF
                cmd.Parameters.Add("@CLIENTEBLOQUEADO", SqlDbType.TinyInt).Value = vClienteBloqueado
                cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
                cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
                cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
                cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize
                If vIDUser > 0 Then cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUser
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
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vUF">Filtro</param>
        ''' <param name="vIDUser">Chave primária do usuário</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vUF As String, ByVal vReferencia As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vIDUser As Integer = 0, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Return Listar(vFilter, vUF, vReferencia, 2, vOrder, vDescending, vPage, vPage, vIDUser, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCliente">Chave primaria IDCliente do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDCliente As Integer, ByVal vCodigo As String) As Boolean
            Dim blnExiste As Boolean = True
            Try
                Dim cn As SQLConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "SE_CLIENTE_EXISTENTE"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
                cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = vCodigo
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
                ElseIf Existe(m_intIDCliente, m_strCodigo) Then
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

#End Region



#Region "Vendedores"

        Public Sub AdicionarVendedor(ByVal vIDVendedor As Integer)
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "IN_CLIENTE_VENDEDOR"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is adding on table 'ClienteVendedor' the following row:  IDCliente=" & m_intIDCliente & " IDVendedor=" & vIDVendedor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
        End Sub

        Public Sub RetirarVendedor(ByVal vIDVendedor As Integer)
            Try
                Dim cn As SqlConnection = GetDBConnection()
                Dim cmd As New SqlCommand()
                cmd.Connection = cn
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = PREFIXO & "DE_CLIENTE_VENDEDOR"
                cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
                cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
                cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
                cn.Open()
                Try
                    cmd.ExecuteNonQuery()
                    MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'ClienteVendedor' the following row:  IDCliente=" & m_intIDCliente & " IDVendedor=" & vIDVendedor & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarVendedores(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTE_VENDEDORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function


#End Region


    End Class
End Namespace

