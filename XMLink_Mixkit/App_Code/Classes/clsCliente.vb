

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
		Protected m_strObservacao As String
		Protected m_strCriado As String
		Protected m_sngTabelaPreco As Single
		Protected m_sngDescontoMax As Single
        Protected m_decLimiteCredito As Decimal
        Protected m_objVendedores As clsVendedorCliente
        Protected m_objLinhaNegocio As clsClienteLinhaNegocio
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

		Public Overridable Property Observacao As String
			Get
				Return m_strObservacao
			End Get
			Set(ByVal Value As String)
				m_strObservacao = Value
			End Set
		End Property

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
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

        Public ReadOnly Property Vendedores() As clsVendedorCliente
            Get
                If m_objVendedores Is Nothing Then
                    m_objVendedores = New clsVendedorCliente(m_intIDCliente)
                End If
                Return m_objVendedores
            End Get
        End Property

        Public ReadOnly Property IDLinhaNegocio() As clsClienteLinhaNegocio
            Get
                If m_objLinhaNegocio Is Nothing Then
                    m_objLinhaNegocio = New clsClienteLinhaNegocio(m_intIDCliente)
                End If
                Return m_objLinhaNegocio
            End Get
            'Set(ByVal Value As Integer)
            '    m_intIDLinhaNegocio = Value
            'End Set
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
			if dr.IsDBNull(dr.GetOrdinal("Codigo")) Then 
				m_strCodigo = ""
			else
				m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			end if
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
			end if
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
            End If
            m_objVendedores = New clsVendedorCliente(m_intIDCliente)
            m_objLinhaNegocio = New clsClienteLinhaNegocio(m_intIDCliente)
            m_blnIsNew = False
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
			cmd.Parameters.Add("@CONTATO", SqlDbType.VarChar, 30).value = m_strContato
			cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 1000).value = m_strObservacao
			cmd.Parameters.Add("@TABELAPRECO", SqlDbType.Real).value = m_sngTabelaPreco
			cmd.Parameters.Add("@DESCONTOMAX", SqlDbType.Real).value = m_sngDescontoMax
            cmd.Parameters.Add("@LIMITECREDITO", SqlDbType.Money).Value = m_decLimiteCredito
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
			If vIDCliente = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CLIENTE"
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
			m_sngDescontoMax = 100
            m_decLimiteCredito = Nothing
            m_objLinhaNegocio = Nothing
            m_objVendedores = Nothing
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
		''' <param name="vIDVendedor">Filtro</param>
		''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
		''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
		''' <param name="vPage">Número da página a exibir</param>	
		''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDVendedor As Integer, ByVal vIDLinhaNegocio As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = vIDLinhaNegocio
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
        ''' <param name="vIDCliente">Chave primaria IDCliente do registro atual.</param>
		''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
		Public Function Existe(ByVal vIDCliente as Integer, ByVal vCodigo as String) As Boolean
			
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_CLIENTE_EXISTENTE"
			cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).value = vIDCliente
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = vCodigo
			return ExecuteScalar(cmd)
			
		End Function
	

		Protected Overrides Function CheckIfSubClassIsValid() as Boolean
			Dim blnValid as Boolean = true
			if m_strCodigo = "" Then 
				AddBrokenRule("O código é obrigatório!")
				blnValid = false
			elseif Existe(m_intIDCliente, m_strCodigo) Then 
				AddBrokenRule("O código informado já existe!")
				blnValid = false
			End if
	
			return blnValid
			
		End Function
		
	#End Region

    End Class



    Public Class clsVendedorCliente
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIDCliente As Integer
#End Region

        Friend Sub New(ByVal vIDCliente As Integer)
            m_intIDCliente = vIDCliente
        End Sub

#Region "Metodos"

        ''' <summary>
        ''' 	Função que adiciona um item na tabela
        ''' </summary>
        Public Sub Add(ByVal vIDVendedor As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_VENDEDOR_CLIENTE"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que remove um item na tabela
        ''' </summary>
        Public Sub Delete(ByVal vIDVendedor As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_VENDEDOR_CLIENTE"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem de Vendedores no Cliente
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTE_VENDEDORES"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function
#End Region

    End Class





    Public Class clsClienteLinhaNegocio
        Inherits BaseClass

        Protected m_intIDCliente As Integer

        Public Sub New(ByVal vIDCliente As Integer)
            m_intIDCliente = vIDCliente
        End Sub

#Region "Metodos"

        ''' <summary>
        ''' 	Função que adiciona um item na tabela
        ''' </summary>
        Public Sub Add(ByVal vIDLinhaNegocio As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "IN_CLIENTE_LINHANEGOCIO"
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = vIDLinhaNegocio
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que remove um item na tabela
        ''' </summary>
        Public Sub Delete(ByVal vIDLinhaNegocio As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CLIENTE_LINHANEGOCIO"
            cmd.Parameters.Add("@IDLINHANEGOCIO", SqlDbType.Int).Value = vIDLinhaNegocio
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem de Vendedores no Cliente
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_CLIENTE_LINHANEGOCIO"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function


#End Region

    End Class

End Namespace

