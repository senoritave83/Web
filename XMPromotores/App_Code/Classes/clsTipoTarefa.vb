

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsTipoTarefa
        Inherits BaseClass



#Region "Declarations"
        Protected m_intIDTipoTarefa As Integer
        Protected m_strTipoTarefa As String
        Protected m_strCriado As String
        Protected m_indAtivo As Integer

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDTipoTarefa As Integer
            Get
                Return m_intIDTipoTarefa
            End Get
        End Property

        Public Overridable Property TipoTarefa As String
            Get
                Return m_strTipoTarefa
            End Get
            Set(ByVal Value As String)
                m_strTipoTarefa = Value
            End Set
        End Property

        Public Overridable Property Ativo As Integer
            Get
                Return m_indAtivo
            End Get
            Set(ByVal Value As Integer)
                m_indAtivo = Value
            End Set
        End Property

        Public Overridable ReadOnly Property Criado As String
            Get
                Return _getDateTimePropertyValue(m_strCriado)
            End Get
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDTipoTarefa = 0
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDTipoTarefa = dr.GetInt32(dr.GetOrdinal("IDTipoTarefa"))
            If dr.IsDBNull(dr.GetOrdinal("TipoTarefa")) Then
                m_strTipoTarefa = ""
            Else
                m_strTipoTarefa = dr.GetString(dr.GetOrdinal("TipoTarefa"))
            End If
            If dr.IsDBNull(dr.Item("Ativo")) Then
                m_indAtivo = 0
            Else
                m_indAtivo = dr.Item(dr.GetOrdinal("Ativo"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TipoTarefa"
            cmd.Parameters.Add("@IDTipoTarefa", SqlDbType.Int).Value = m_intIDTipoTarefa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TipoTarefa", SqlDbType.VarChar, 50).Value = m_strTipoTarefa
            cmd.Parameters.Add("@Ativo", SqlDbType.TinyInt).Value = m_indAtivo
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

            Me.User.Log("Cadastro de tipos de tarefa", "Gravar - IDTipoTarefa=" & m_intIDTipoTarefa & " TipoTarefa=" & m_strTipoTarefa)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDTipoTarefa">Chave primaria IDTipoTarefa</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDTipoTarefa As Integer) As Boolean

            If vIDTipoTarefa = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TipoTarefa"
            cmd.Parameters.Add("@IDTipoTarefa", SqlDbType.Int).value = vIDTipoTarefa
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

            Me.User.Log("Cadastro de tipos de tarefa", "Visualizar - IDTipoTarefa=" & vIDTipoTarefa)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDTipoTarefa = 0
            m_strTipoTarefa = ""
            m_strCriado = ""
            m_indAtivo = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_TipoTarefa"
            cmd.Parameters.Add("@IDTipoTarefa", SqlDbType.Int).value = m_intIDTipoTarefa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de tipos de tarefa", "Apagar - IDTipoTarefa=" & m_intIDTipoTarefa)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'TipoTarefa' the following row:  IDTipoTarefa=" & m_intIDTipoTarefa & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro passado</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_TipoTarefaS"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).value = User.IDEmpresa
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
            cmd.CommandText = PREFIXO & "NV_TipoTarefaS"
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
        ''' <param name="vIDTipoTarefa">Chave primaria do registro atual.</param>
        ''' <param name="vNome">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDTipoTarefa As Integer, ByVal vNome As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TipoTarefa_EXISTENTE"
            cmd.Parameters.Add("@IDTipoTarefa", SqlDbType.Int).Value = vIDTipoTarefa
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TipoTarefa", SqlDbType.VarChar, 50).Value = vNome

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strTipoTarefa = "" Then
                AddBrokenRule("Por favor informe o tipo de loja!")
                blnValid = False
            ElseIf Existe(m_intIDTipoTarefa, m_strTipoTarefa) Then
                AddBrokenRule("Tipo de loja informado já existente!")
                blnValid = False
            End If
            Return blnValid
        End Function


#End Region



    End Class
End Namespace

