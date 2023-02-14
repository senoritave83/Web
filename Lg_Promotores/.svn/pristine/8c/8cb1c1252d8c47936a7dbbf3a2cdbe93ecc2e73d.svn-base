

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsCoordenador
		Inherits BaseClass



#Region "Declarations"

        Protected m_intIDCoordenador As Integer
        Protected m_strCoordenador As String
        Protected m_intIdUsuario As Integer
        Protected m_indAcessoWeb As Boolean

#End Region


	#Region "Properties" 
		Public Overridable ReadOnly Property IDCoordenador As Integer
			Get
				Return m_intIDCoordenador
			End Get
		End Property

		Public Overridable Property Coordenador As String
			Get
				Return m_strCoordenador
			End Get
			Set(ByVal Value As String)
				m_strCoordenador = Value
			End Set
        End Property

        Public Overridable Property IdUsuario() As Integer
            Get
                Return m_intIdUsuario
            End Get
            Set(ByVal value As Integer)
                m_intIdUsuario = value
            End Set
        End Property

        Public Overridable Property AcessoWeb() As Boolean
            Get
                Return m_indAcessoWeb
            End Get
            Set(ByVal value As Boolean)
                m_indAcessoWeb = value
            End Set
        End Property

        Public ReadOnly Property isNew() As Boolean
            Get
                Return m_intIDCoordenador = 0
            End Get
        End Property

#End Region

    #Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDCoordenador = dr.GetInt32(dr.GetOrdinal("IDCoordenador"))
            m_strCoordenador = dr.GetString(dr.GetOrdinal("Coordenador"))
            m_intIdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"))
            m_indAcessoWeb = IIf(dr.Item("AcessoWeb") = 0, False, True)

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_COORDENADOR"
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = m_intIDCoordenador
            cmd.Parameters.Add("@COORDENADOR", SqlDbType.VarChar, 100).Value = m_strCoordenador
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIdUsuario
            cmd.Parameters.Add("@ACESSOWEB", SqlDbType.Int).Value = m_indAcessoWeb
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

            Me.User.Log("Cadastro de Coordenadores", "Gravar - IDCOORDENADOR=" & m_intIDCoordenador & " COORDENADOR=" & m_strCoordenador & " ACESSOWEB=" & m_indAcessoWeb)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDCoordenador">Chave primaria IDCoordenador</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCoordenador As Integer) As Boolean


            If vIDCoordenador = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_COORDENADOR"
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
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

            Me.User.Log("Cadastro de Coordenadores", "Visualizar - IDCOORDENADOR=" & vIDCoordenador)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDCoordenador = 0
            m_strCoordenador = ""
            m_intIdUsuario = 0
            m_indAcessoWeb = False
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_COORDENADOR"
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = m_intIDCoordenador

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Coordenadores", "Apagar - IDCOORDENADOR=" & m_intIDCoordenador)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Coordenador' the following row:  IDCoordenador=" & m_intIDCoordenador & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)

            Clear()

        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_COORDENADORES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarCoordenadorSegmento(ByVal p_Segmento As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_COORDENADORES_SEGMENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@SEGMENTO", SqlDbType.VarChar, 1000).Value = p_Segmento
            Return MyBase.ExecuteCommand(cmd, vReturnType)

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

        Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_COORDENADORES"
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
        ''' <param name="vIDCoordenador">Chave primaria do registro atual.</param>
        ''' <param name="vCoordenador">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDCoordenador As Integer, ByVal vCoordenador As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_COORDENADOR_EXISTENTE"
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@COORDENADOR", SqlDbType.VarChar, 100).Value = vCoordenador

            Return ExecuteScalar(cmd)

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro de lider associado ao coordenador
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDCoordenador">Chave primaria do registro atual.</param>
        Public Function ExisteLideres(ByVal vIDCoordenador As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_COORDENADOR_EXISTE_LIDERES"
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteScalar(cmd)
        End Function

        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strCoordenador = "" Then
                AddBrokenRule("Por favor informe a nome do coordenador!")
                blnValid = False
            ElseIf Existe(m_intIDCoordenador, m_strCoordenador) Then
                AddBrokenRule("Coordenador informado existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

