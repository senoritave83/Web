

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Collections.Generic

Namespace Classes

	Public Class clsCliente
		Inherits BaseClass


	#Region "Declarations" 
		Protected m_intIDCliente As Integer
		Protected m_strRazaoSocial As String
		Protected m_strFantasia As String

	#End Region  


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCliente As Integer
			Get
				Return m_intIDCliente
			End Get
		End Property

		Public Overridable Property RazaoSocial As String
			Get
				Return m_strRazaoSocial
			End Get
			Set(ByVal Value As String)
				m_strRazaoSocial = Value
			End Set
		End Property

		Public Overridable Property Fantasia As String
			Get
				Return m_strFantasia
			End Get
			Set(ByVal Value As String)
				m_strFantasia = Value
			End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDCliente = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IdCliente"))
            m_strRazaoSocial = dr.GetString(dr.GetOrdinal("RazaoSocial"))
            m_strFantasia = dr.GetString(dr.GetOrdinal("Fantasia"))


        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_CLIENTE"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar, 100).Value = m_strRazaoSocial
            cmd.Parameters.Add("@FANTASIA", SqlDbType.VarChar, 100).Value = m_strFantasia

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                dr.Close()
                dr = Nothing
            End Try

            Me.User.Log("Cadastro de Revendas", "Gravar - IDREVENDA=" & m_intIDCliente & " RAZAOSOCIAL=" & m_strRazaoSocial & " FANTASIA=" & m_strFantasia)

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

            Dim dr As IDataReader = ExecuteReader(cmd)
            Try
                If dr.Read Then
                    Inflate(dr)
                Else
                    Clear()
                End If
            Finally
                dr.Close()
                dr = Nothing
            End Try

            Me.User.Log("Cadastro de Revendas", "Visualizar - IDREVENDA=" & vIDCliente)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCliente = 0
            m_strRazaoSocial = ""
            m_strFantasia = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_CLIENTE"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = m_intIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Revendas", "Apagar - IDREVENDA=" & m_intIDCliente)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Cliente' the following row:  IDCliente=" & m_intIDCliente & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="prefixText">Texto da busca</param>		
        ''' <param name="count">qtde de itens da busca</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar_AutoComplete(ByVal prefixText As String, ByVal count As Integer) As SqlDataReader

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_CLIENTES_AUTOCOMPLETE"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 200).Value = prefixText

            Dim clientes As List(Of String) = New List(Of String)
            Dim sdr As SqlDataReader = MyBase.ExecuteCommand(cmd, enReturnType.DataReader)
            Return sdr

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem filtrada pela categoria
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(ByVal vIDCategoria As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCATEGORIA", SqlDbType.Int).Value = vIDCategoria
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenção utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_CLIENTES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
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
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCliente">Chave primaria IDCliente do registro atual.</param>
        ''' <param name="vFantasia">Fantasia que se deseja verificar a existência no banco de dados</param>
        ''' <param name="vRazaoSocial">RazaoSocial que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDCliente As Integer, ByVal vRazaoSocial As String, ByVal vFantasia As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_CLIENTE_EXISTENTE"
            cmd.Parameters.Add("@IDCLIENTE", SqlDbType.Int).Value = vIDCliente
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@RAZAOSOCIAL", SqlDbType.VarChar, 100).Value = vRazaoSocial
            cmd.Parameters.Add("@FANTASIA", SqlDbType.VarChar, 100).Value = vFantasia

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strRazaoSocial = "" Then
                AddBrokenRule("Por favor informe a Razão Social!")
                blnValid = False
            ElseIf m_strFantasia = "" Then
                AddBrokenRule("Por favor informe o nome Fantasia!")
                blnValid = False
            ElseIf Existe(m_intIDCliente, m_strRazaoSocial, m_strFantasia) Then
                AddBrokenRule("Cliente informado existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

