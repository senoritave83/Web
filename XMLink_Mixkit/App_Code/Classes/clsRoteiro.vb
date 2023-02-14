

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

	Public Class clsRoteiro
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDRoteiro As Integer
		Protected m_strCodigo As String
		Protected m_strDescricao As String
		Protected m_strCriado As String
		Protected m_intDia As Integer
		Protected m_intMes As Integer
        Protected m_intDiaSemana As Integer
        Protected m_intSemanaMes As Integer
        Protected m_intAno As Integer
        Protected m_objVendedores As clsVendedorRoteiro.IVendedoresRoteiro
        Protected m_objClientes As clsClienteRoteiro.IClientesRoteiro
        Protected m_blnIsNew As Boolean = True
	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDRoteiro As Integer
			Get
				Return m_intIDRoteiro
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

		Public Overridable ReadOnly Property Criado As String
			Get
				Return _getDateTimePropertyValue(m_strCriado)
			End Get
		End Property

		Public Overridable Property Dia As Integer
			Get
				Return m_intDia
			End Get
			Set(ByVal Value As Integer)
				m_intDia = Value
			End Set
		End Property

		Public Overridable Property Mes As Integer
			Get
				Return m_intMes
			End Get
			Set(ByVal Value As Integer)
				m_intMes = Value
			End Set
		End Property

		Public Overridable Property DiaSemana As Integer
			Get
				Return m_intDiaSemana
			End Get
			Set(ByVal Value As Integer)
				m_intDiaSemana = Value
			End Set
        End Property

        Public Overridable Property SemanaMes() As Integer
            Get
                Return m_intSemanaMes
            End Get
            Set(ByVal Value As Integer)
                m_intSemanaMes = Value
            End Set
        End Property


        Public Overridable Property Ano() As Integer
            Get
                Return m_intAno
            End Get
            Set(ByVal Value As Integer)
                m_intAno = Value
            End Set
        End Property

        Public ReadOnly Property Vendedores() As clsVendedorRoteiro.IVendedoresRoteiro
            Get
                If m_objVendedores Is Nothing Then
                    m_objVendedores = New clsVendedorRoteiro(m_intIDRoteiro)
                End If
                Return m_objVendedores
            End Get
        End Property

        Public ReadOnly Property Clientes() As clsClienteRoteiro.IClientesRoteiro
            Get
                If m_objClientes Is Nothing Then
                    m_objClientes = New clsClienteRoteiro(m_intIDRoteiro)
                End If
                Return m_objClientes
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
			m_intIDRoteiro = dr.GetInt32(dr.GetOrdinal("IDRoteiro"))
			m_strCodigo = dr.GetString(dr.GetOrdinal("Codigo"))
			m_strDescricao = dr.GetString(dr.GetOrdinal("Descricao"))
			m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
			if dr.IsDBNull(dr.GetOrdinal("Dia")) Then 
				m_intDia = 0
			else
				m_intDia = dr.GetInt32(dr.GetOrdinal("Dia"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("Mes")) Then 
				m_intMes = 0
			else
				m_intMes = dr.GetInt32(dr.GetOrdinal("Mes"))
			end if
			if dr.IsDBNull(dr.GetOrdinal("DiaSemana")) Then 
				m_intDiaSemana = 0
			else
				m_intDiaSemana = dr.GetInt32(dr.GetOrdinal("DiaSemana"))
			end if
            If dr.IsDBNull(dr.GetOrdinal("SemanaMes")) Then
                m_intSemanaMes = 0
            Else
                m_intSemanaMes = dr.GetInt32(dr.GetOrdinal("SemanaMes"))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Ano")) Then
                m_intAno = 0
            Else
                m_intAno = dr.GetInt32(dr.GetOrdinal("Ano"))
            End If
            m_objVendedores = Nothing
            m_objClientes = Nothing
            m_blnIsNew = False
		End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
		Public Sub Update()
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SV_ROTEIRO"
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = m_intIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
			cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).value = m_strCodigo
			cmd.Parameters.Add("@DESCRICAO", SqlDbType.VarChar, 100).value = m_strDescricao
			cmd.Parameters.Add("@DIA", SqlDbType.Int).value = m_intDia
			cmd.Parameters.Add("@MES", SqlDbType.Int).value = m_intMes
            cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = m_intDiaSemana
            cmd.Parameters.Add("@SEMANAMES", SqlDbType.Int).Value = m_intSemanaMes
            cmd.Parameters.Add("@ANO", SqlDbType.Int).Value = m_intAno
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
        ''' <param name="vIDRoteiro">Chave primaria IDRoteiro</param>
        ''' <returns>Boolean</returns>
		Public Function Load(ByVal vIDRoteiro As Integer) As Boolean
			If vIDRoteiro = 0 Then 
				Clear()
				return false
			End if
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "SE_ROTEIRO"
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = vIDRoteiro
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
			m_intIDRoteiro = 0
			m_strCodigo = ""
			m_strDescricao = ""
			m_strCriado = ""
			m_intDia = 0
			m_intMes = 0
            m_intDiaSemana = 0
            m_intSemanaMes = 0
            m_intAno = 0
            m_objVendedores = Nothing
            m_objClientes = Nothing
            m_blnIsNew = True

		End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
		Public Sub Delete()
		
			Dim cmd As New SqlCommand()
			cmd.CommandType = CommandType.StoredProcedure
			cmd.CommandText = PREFIXO & "DE_ROTEIRO"
			cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).value = m_intIDRoteiro
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

			ExecuteNonQuery(cmd)
			
			myBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Roteiro' the following row:  IDRoteiro=" & m_intIDRoteiro & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
			Clear()
			
		End Sub
	
        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
		''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
		''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
		Public Function Listar(Optional ByVal vReturnType as enReturnType = enReturnType.DataReader) As Object

			Dim cmd As New SqlCommand()
			cmd.CommandText = PREFIXO & "LS_ROTEIROS"
            cmd.CommandType = CommandType.StoredProcedure
			cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
          	Return ExecuteCommand(cmd, vReturnType)

		End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCliente As Integer, ByVal vIDVendedor As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_ROTEIROS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = vIDVendedor
            cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
            cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
            cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
            cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

            Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

        End Function


        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult
            Return Listar(vFilter, 0, 0, vOrder, vDescending, vPage, vPageSize, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna se existe um cadastro com o mesmo código informado!
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDRoteiro">Chave primaria IDRoteiro do registro atual.</param>
        ''' <param name="vCodigo">Código que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDRoteiro As Integer, ByVal vCodigo As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ROTEIRO_EXISTENTE"
            cmd.Parameters.Add("@IDROTEIRO", SqlDbType.Int).Value = vIDRoteiro
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@CODIGO", SqlDbType.VarChar, 20).Value = vCodigo
            Return ExecuteScalar(cmd)

        End Function


        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCodigo = "" Then
                AddBrokenRule("O código é obrigatório!")
                blnValid = False
            ElseIf Existe(m_intIDRoteiro, m_strCodigo) Then
                AddBrokenRule("O código informado já existe!")
                blnValid = False
            End If

            Return blnValid

        End Function

#End Region

    End Class
End Namespace

