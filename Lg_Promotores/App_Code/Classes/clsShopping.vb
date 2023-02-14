Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsShopping
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDShopping As Integer
        Protected m_strShopping As String
        Protected m_strCriado As String

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDShopping() As Integer
            Get
                Return m_intIDShopping
            End Get
        End Property

        Public Overridable Property Shopping() As String
            Get
                Return m_strShopping
            End Get
            Set(ByVal Value As String)
                m_strShopping = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado() As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDShopping = 0
            End Get
        End Property
#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDShopping = dr.GetInt32(dr.GetOrdinal("IdShopping"))
            m_strShopping = dr.GetString(dr.GetOrdinal("Shopping"))
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_SHOPPING"
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = m_intIDShopping
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@SHOPPING", SqlDbType.VarChar, 100).Value = m_strShopping

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

            Me.User.Log("Cadastro de Shoppings", "Gravar - IDSHOPPING=" & m_intIDShopping & " SHOPPING=" & m_strShopping)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDShopping">Chave primaria IDShopping</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDShopping As Integer) As Boolean

            If vIDShopping = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_SHOPPING"
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = vIDShopping
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

            Me.User.Log("Cadastro de Shoppings", "Visualizar - IDSHOPPING=" & vIDShopping)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDShopping = 0
            m_strShopping = ""
            m_strCriado = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_SHOPPING"
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = m_intIDShopping
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Shopping' the following row:  IDShopping=" & m_intIDShopping & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

            Me.User.Log("Cadastro de Shoppings", "Apagar - IDSHOPPING=" & m_intIDShopping)

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_SHOPPING"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
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
            cmd.CommandText = PREFIXO & "NV_SHOPPING"
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
        ''' <param name="vIDShopping">Chave primaria do registro atual.</param>
        ''' <param name="vNome">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDShopping As Integer, ByVal vNome As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_SHOPPING_EXISTENTE"
            cmd.Parameters.Add("@IDSHOPPING", SqlDbType.Int).Value = vIDShopping
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@SHOPPING", SqlDbType.VarChar, 100).Value = vNome

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strShopping = "" Then
                AddBrokenRule("Por favor informe o nome do shopping!")
                blnValid = False
            ElseIf Existe(m_intIDShopping, m_strShopping) Then
                AddBrokenRule("Shopping informado já existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace



