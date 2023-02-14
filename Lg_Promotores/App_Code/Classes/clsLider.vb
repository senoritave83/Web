

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

	Public Class clsLider
		Inherits BaseClass



	#Region "Declarations" 
		Protected m_intIDLider As Integer
		Protected m_strLider As String
        Protected m_intIDCoordenador As Integer
        Protected m_intIdUsuario As Integer
        Protected m_indAcessoWeb As Boolean
        Protected m_strFoto As String

#End Region


#Region "Properties"
        Public Overridable ReadOnly Property IDLider As Integer
            Get
                Return m_intIDLider
            End Get
        End Property

        Public Overridable Property Lider As String
            Get
                Return m_strLider
            End Get
            Set(ByVal Value As String)
                m_strLider = Value
            End Set
        End Property

        Public Overridable Property IDCoordenador As Integer
            Get
                Return m_intIDCoordenador
            End Get
            Set(ByVal Value As Integer)
                m_intIDCoordenador = Value
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
                Return m_intIDLider = 0
            End Get
        End Property

        Public Overridable Property Foto() As String
            Get
                Return m_strFoto
            End Get
            Set(ByVal value As String)
                m_strFoto = value
            End Set
        End Property
#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIDLider = dr.GetInt32(dr.GetOrdinal("IDLider"))
            m_strLider = dr.GetString(dr.GetOrdinal("Lider"))
            m_intIDCoordenador = dr.GetInt32(dr.GetOrdinal("IDCoordenador"))
            m_intIdUsuario = dr.GetInt32(dr.GetOrdinal("IdUsuario"))
            m_indAcessoWeb = IIf(dr.Item("AcessoWeb") = "0", False, True)

            If dr.IsDBNull(dr.GetOrdinal("Imagem")) Then
                m_strFoto = ""
            Else
                m_strFoto = dr.GetString(dr.GetOrdinal("Imagem"))
            End If
        End Sub


        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_LIDER"
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = m_intIDLider
            cmd.Parameters.Add("@LIDER", SqlDbType.VarChar, 100).Value = m_strLider
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = m_intIDCoordenador
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIdUsuario
            cmd.Parameters.Add("@ACESSOWEB", SqlDbType.Int).Value = m_indAcessoWeb
            cmd.Parameters.Add("@IMAGEM", SqlDbType.VarChar).Value = m_strFoto

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

            Me.User.Log("Cadastro de Lideres", "Gravar - IDLIDER=" & m_intIDLider & " LIDER=" & m_strLider & " IDCOORDENADOR=" & m_intIDCoordenador & " ACESSOWEB=" & m_indAcessoWeb & _
                        " IMAGEM=" & m_strFoto)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIDLider">Chave primaria IDLider</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDLider As Integer) As Boolean

            If vIDLider = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LIDER"
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
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

            Me.User.Log("Cadastro de Lideres", "Visualizar - IDLIDER=" & vIDLider)

            Return True
        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIDLider = 0
            m_strLider = ""
            m_intIDCoordenador = 0
            m_intIdUsuario = 0
            m_indAcessoWeb = False
            m_strFoto = ""
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_LIDER"
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = m_intIDLider

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Lideres", "Apagar - IDLIDER=" & m_intIDLider)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'Lider' the following row:  IDLider=" & m_intIDLider & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
            cmd.CommandText = PREFIXO & "LS_LIDERES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal p_Coordenadores As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LIDERES_COORDENADOR"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@COORDENADORES", SqlDbType.VarChar, 1000).Value = p_Coordenadores
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarLiderSegmento(ByVal p_Coordenadores As String, ByVal p_Segmento As String, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LIDERES_SEGMENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@COORDENADORES", SqlDbType.VarChar, 1000).Value = p_Coordenadores
            cmd.Parameters.Add("@SEGMENTO", SqlDbType.VarChar, 1000).Value = p_Segmento
            Return MyBase.ExecuteCommand(cmd, vReturnType)
        End Function


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function Listar(ByVal vIDCoordenador As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "LS_LIDERES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            Return MyBase.ExecuteCommand(cmd, vReturnType)

        End Function

        ''' <summary>
        ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
        ''' </summary>
        ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
        ''' <param name="vIDCoordenador">Filtro</param>
        ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
        ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
        ''' <param name="vPage">Número da página a exibir</param>	
        ''' <param name="vPageSize">Tamanho da página em registros</param>		
        ''' <returns>PaginateResult</returns>
        Public Function Listar(ByVal vFilter As String, ByVal vIDCoordenador As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_LIDERES"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
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
        ''' <param name="vIDLider">Chave primaria do registro atual.</param>
        ''' <param name="vNome">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIDLider As Integer, ByVal vIDCoordenador As Integer, ByVal vNome As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LIDER_EXISTENTE"
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDCOORDENADOR", SqlDbType.Int).Value = vIDCoordenador
            cmd.Parameters.Add("@LIDER", SqlDbType.VarChar, 100).Value = vNome

            Return ExecuteScalar(cmd)

        End Function

        ''' <summary>
        ''' 	Função que retorna se existe um cadastro de promotor associado ao lider
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks>Caso ocorra algum erro dentro do código a Função retorna "true" evitando o cadastramento duplicado</remarks>
        ''' <param name="vIDLider">Chave primaria do registro atual.</param>
        Public Function ExistePromotores(ByVal vIDLider As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_LIDER_EXISTE_PROMOTORES"
            cmd.Parameters.Add("@IDLIDER", SqlDbType.Int).Value = vIDLider
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteScalar(cmd)
        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strLider = "" Then
                AddBrokenRule("Por favor informe o nome do lider!")
                blnValid = False
            ElseIf Existe(m_intIDLider, m_intIDCoordenador, m_strLider) Then
                AddBrokenRule("Lider informado existente!")
                blnValid = False
            End If
            Return blnValid
        End Function

#End Region



    End Class
End Namespace

