Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics

Namespace Classes

    Public Class clsTipoEvento
        Inherits BaseClass

#Region "Declarations"
        Protected m_intIdTipoEvento As Integer
        Protected m_strTipoEvento As String
        Protected m_intIdContexto As Integer
        Protected m_indInstantaneo As Boolean
        Protected m_indPosicao As Boolean
        Protected m_indPermiteObs As Boolean
        Protected m_indExclusivo As Boolean
        Protected m_indUnico As Boolean
        Protected m_strCriado As String
        Protected m_indAtivo As Byte
#End Region

#Region "Properties"
        Public Overridable ReadOnly Property IdTipoEvento As Integer
            Get
                Return m_intIdTipoEvento
            End Get
        End Property

        Public Overridable Property TipoEvento As String
            Get
                Return m_strTipoEvento
            End Get
            Set(ByVal Value As String)
                m_strTipoEvento = Value
            End Set
        End Property

        Public Overridable Property IdContexto As Integer
            Get
                Return m_intIdContexto
            End Get
            Set(ByVal Value As Integer)
                m_intIdContexto = Value
            End Set
        End Property

        Public Overridable Property Instantaneo As Boolean
            Get
                Return m_indInstantaneo
            End Get
            Set(ByVal Value As Boolean)
                m_indInstantaneo = Value
            End Set
        End Property


        Public Overridable Property Posicao As Boolean
            Get
                Return m_indPosicao
            End Get
            Set(ByVal Value As Boolean)
                m_indPosicao = Value
            End Set
        End Property


        Public Overridable Property PermiteObs As Boolean
            Get
                Return m_indPermiteObs
            End Get
            Set(ByVal Value As Boolean)
                m_indPermiteObs = Value
            End Set
        End Property


        Public Overridable Property Exclusivo As Boolean
            Get
                Return m_indExclusivo
            End Get
            Set(ByVal Value As Boolean)
                m_indExclusivo = Value
            End Set
        End Property


        Public Overridable Property Unico As Boolean
            Get
                Return m_indUnico
            End Get
            Set(ByVal Value As Boolean)
                m_indUnico = Value
            End Set
        End Property

        Public Overridable Property Ativo As Byte
            Get
                Return m_indAtivo
            End Get
            Set(ByVal Value As Byte)
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
                Return m_intIdTipoEvento = 0
            End Get
        End Property

#End Region

#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)

            m_intIdTipoEvento = dr.GetInt32(dr.GetOrdinal("IdTipoEvento"))
            If dr.IsDBNull(dr.GetOrdinal("TipoEvento")) Then
                m_strTipoEvento = ""
            Else
                m_strTipoEvento = dr.GetString(dr.GetOrdinal("TipoEvento"))
            End If
            m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))

            m_intIdContexto = dr.GetInt32(dr.GetOrdinal("IdContexto"))
            m_indInstantaneo = IIf(dr.GetByte(dr.GetOrdinal("Instantaneo")) = 0, False, True)
            m_indPosicao = IIf(dr.GetByte(dr.GetOrdinal("Posicao")) = 0, False, True)
            m_indPermiteObs = IIf(dr.GetByte(dr.GetOrdinal("PermiteObs")) = 0, False, True)
            m_indExclusivo = IIf(dr.GetByte(dr.GetOrdinal("Exclusivo")) = 0, False, True)
            m_indUnico = IIf(dr.GetByte(dr.GetOrdinal("Unico")) = 0, False, True)
            m_indAtivo = dr.GetByte(dr.GetOrdinal("Ativo"))

        End Sub




        ''' <summary>
        ''' 	Função que grava os dados do registro atual
        ''' </summary>
        Public Sub Update()

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SV_TIPOEVENTO"
            cmd.Parameters.Add("@IdTipoEvento", SqlDbType.Int).Value = m_intIdTipoEvento
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TipoEvento", SqlDbType.VarChar, 50).Value = m_strTipoEvento
            cmd.Parameters.Add("@IdContexto", SqlDbType.Int).Value = m_intIdContexto
            cmd.Parameters.Add("@Instantaneo", SqlDbType.TinyInt).Value = IIf(m_indInstantaneo = False, 0, 1)
            cmd.Parameters.Add("@Posicao", SqlDbType.TinyInt).Value = IIf(m_indPosicao = False, 0, 1)
            cmd.Parameters.Add("@PermiteObs", SqlDbType.TinyInt).Value = IIf(m_indPermiteObs = False, 0, 1)
            cmd.Parameters.Add("@Exclusivo", SqlDbType.TinyInt).Value = IIf(m_indExclusivo = False, 0, 1)
            cmd.Parameters.Add("@Unico", SqlDbType.TinyInt).Value = IIf(m_indUnico = False, 0, 1)
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

            Me.User.Log("Cadastro de Tipos de Eventos", "Gravar - IdTipoEvento=" & m_intIdTipoEvento & " TipoEvento=" & m_strTipoEvento)

        End Sub


        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <param name="vIdTipoEvento">Chave primaria IdTipoEvento</param>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIdTipoEvento As Integer) As Boolean

            If vIdTipoEvento = 0 Then
                Clear()
                Return False
            End If

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TIPOEVENTO"
            cmd.Parameters.Add("@IdTipoEvento", SqlDbType.Int).Value = vIdTipoEvento
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

            Me.User.Log("Cadastro de Tipos de Eventos", "Visualizar - IdTipoEvento=" & vIdTipoEvento)

        End Function

        ''' <summary>
        ''' 	Função interna que limpa as variaveis internas
        ''' </summary>
        Protected Sub Clear()
            m_intIdTipoEvento = 0
            m_strTipoEvento = ""
            m_strCriado = ""
            m_intIdContexto = 0
            m_indInstantaneo = 0
            m_indPosicao = 0
            m_indPermiteObs = 0
            m_indExclusivo = 0
            m_indUnico = 0
            m_indAtivo = 0
        End Sub



        ''' <summary>
        ''' 	Rotina que apaga o registro atual
        ''' </summary>
        Public Sub Delete()
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "DE_TIPOEVENTO"
            cmd.Parameters.Add("@IdTipoEvento", SqlDbType.Int).Value = m_intIdTipoEvento
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa

            ExecuteNonQuery(cmd)

            Me.User.Log("Cadastro de Tipos de Loja", "Apagar - IdTipoEvento=" & m_intIdTipoEvento)

            MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'TipoEvento' the following row:  IdTipoEvento=" & m_intIdTipoEvento & " IDEmpresa=" & User.IDEmpresa & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
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
            cmd.CommandText = PREFIXO & "LS_TipoEventoS"
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

        Public Function Listar(ByVal vFilter As String, ByVal vIDStatusEvento As Integer, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As PaginateResult

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "NV_TIPOEVENTO"
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
            cmd.Parameters.Add("@IDSTATUSEVENTO", SqlDbType.Int).Value = vIDStatusEvento
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
        ''' <param name="vIdTipoEvento">Chave primaria do registro atual.</param>
        ''' <param name="vNome">Nome que se deseja verificar a existência no banco de dados</param>
        Public Function Existe(ByVal vIdTipoEvento As Integer, ByVal vNome As String) As Boolean

            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_TIPOEVENTO_EXISTENTE"
            cmd.Parameters.Add("@IdTipoEvento", SqlDbType.Int).Value = vIdTipoEvento
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@TipoEvento", SqlDbType.VarChar, 50).Value = vNome

            Return ExecuteScalar(cmd)

        End Function



        Protected Overrides Function CheckIfSubClassIsValid() As Boolean
            Dim blnValid As Boolean = True
            If m_strTipoEvento = "" Then
                AddBrokenRule("Por favor informe o tipo de evento!")
                blnValid = False
            ElseIf Existe(m_intIdTipoEvento, m_strTipoEvento) Then
                AddBrokenRule("Tipo de evento informado já existente!")
                blnValid = False
            End If
            Return blnValid
        End Function


#End Region

    End Class

End Namespace


