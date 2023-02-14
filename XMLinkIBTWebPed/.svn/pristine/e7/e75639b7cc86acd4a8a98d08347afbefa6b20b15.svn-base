

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace Classes

    Public Class clsAtendimentoCliente
        Inherits BaseClass



#Region "Declarations"
        Protected m_blnVencido As Boolean
        Protected m_blnExecutado As Boolean
        Protected m_blnFinalizado As Boolean
        Protected m_strData As String
        Protected m_intIDCliente As Integer
        Protected m_strCliente As String
        Protected m_strStatus As String
        Protected m_intIDJustificativa As Integer
        Protected m_strJustificativa As String
        Protected m_intPedidos As Integer
        Protected m_strInicio As String
        Protected m_strTermino As String
        Protected m_intIDVisita As Integer
        Protected m_blnPermitePedido As Boolean

#End Region


#Region "Properties"

        Public ReadOnly Property IDVisita() As Integer
            Get
                Return m_intIDVisita
            End Get
        End Property

        Public Property Vencido() As Boolean
            Get
                Return m_blnVencido
            End Get
            Set(ByVal value As Boolean)
                m_blnVencido = value
            End Set
        End Property

        Public Property Executado() As Boolean
            Get
                Return m_blnExecutado
            End Get
            Set(ByVal value As Boolean)
                m_blnExecutado = value
            End Set
        End Property

        Public Property Finalizado() As Boolean
            Get
                Return m_blnFinalizado
            End Get
            Set(ByVal value As Boolean)
                m_blnFinalizado = value
            End Set
        End Property

        Public ReadOnly Property IDCliente() As Integer
            Get
                Return m_intIDCliente
            End Get
        End Property

        Public ReadOnly Property Cliente() As String
            Get
                Return m_strCliente
            End Get
        End Property

        Public ReadOnly Property Status() As String
            Get
                Return m_strStatus
            End Get
        End Property

        Public ReadOnly Property IDJustificativa() As Integer
            Get
                Return m_intIDJustificativa
            End Get
        End Property

        Public ReadOnly Property Justificativa() As String
            Get
                Return m_strJustificativa
            End Get
        End Property

        Public ReadOnly Property Pedidos() As Integer
            Get
                Return m_intPedidos
            End Get
        End Property

        Public Overridable ReadOnly Property Data() As String
            Get
                Return _getDatePropertyValue(m_strData)
            End Get
        End Property

        Public ReadOnly Property Justificado() As Boolean
            Get
                Return m_intIDJustificativa > 0
            End Get
        End Property


        
        Public Overridable Property Inicio() As String
            Get
                Return _getDateTimePropertyValue(m_strInicio)
            End Get
            Set(ByVal Value As String)
                m_strInicio = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public Overridable Property Termino() As String
            Get
                Return _getDateTimePropertyValue(m_strTermino)
            End Get
            Set(ByVal Value As String)
                m_strTermino = _setDateTimePropertyValue(Value)
            End Set
        End Property

        Public ReadOnly Property PermitePedido() As Boolean
            Get
                Return m_blnPermitePedido
            End Get
        End Property


#End Region


#Region "Metodos"

        ''' <summary>
        ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
        ''' </summary>
        ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
        Protected Overridable Sub Inflate(ByVal dr As IDataReader)
            m_intIDVisita = dr.GetInt32(dr.GetOrdinal("IDVisita"))
            m_blnExecutado = dr.GetInt32(dr.GetOrdinal("Executado")) = 1
            m_blnFinalizado = dr.GetByte(dr.GetOrdinal("Finalizado")) = 1
            m_blnVencido = dr.GetByte(dr.GetOrdinal("Vencido")) = 1
            If dr.IsDBNull(dr.GetOrdinal("Data")) Then
                m_strData = ""
            Else
                m_strData = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Data")))
            End If
            m_intIDCliente = dr.GetInt32(dr.GetOrdinal("IDCliente"))
            m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
            m_strStatus = dr.GetString(dr.GetOrdinal("Status"))
            m_intIDJustificativa = dr.GetInt32(dr.GetOrdinal("IDJustificativa"))
            m_strJustificativa = dr.GetString(dr.GetOrdinal("Justificativa"))
            m_intPedidos = dr.GetInt32(dr.GetOrdinal("Pedidos"))
            m_blnPermitePedido = dr.GetBoolean(dr.GetOrdinal("PermitePedido"))
            If dr.IsDBNull(dr.GetOrdinal("Inicio")) Then
                m_strInicio = ""
            Else
                m_strInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Inicio")))
            End If
            If dr.IsDBNull(dr.GetOrdinal("Termino")) Then
                m_strTermino = ""
            Else
                m_strTermino = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Termino")))
            End If


        End Sub




        ''' <summary>
        ''' 	Função que obtem os dados do registro solicitado 
        ''' </summary>
        ''' <returns>Boolean</returns>
        Public Function Load(ByVal vIDCliente As Integer) As Boolean
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = PREFIXO & "SE_ATENDIMENTO_CLIENTE"
            cmd.Parameters.Add("@IDVENDEDOR", SqlDbType.Int).Value = User.IDUser
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
            m_intIDVisita = 0
            m_blnExecutado = False
            m_blnVencido = False
            m_blnFinalizado = False
            m_strData = _getDateTimeDBValue(Now())
            m_intIDCliente = 0
            m_strCliente = ""
            m_strStatus = ""
            m_intIDJustificativa = 0
            m_strJustificativa = ""
            m_intPedidos = 0
            m_strInicio = ""
            m_strTermino = ""
            m_blnPermitePedido = 0
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
        ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
        Public Function ListarPedidos(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "LS_ATENDIMENTO_CLIENTE_PEDIDOS"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            Return ExecuteCommand(cmd, vReturnType)

        End Function





        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        Public Sub ReabrirAtendimento()
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_ATENDIMENTO_CLIENTE_REABRIR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub

        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        Public Sub Finalizar()
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_ATENDIMENTO_CLIENTE_FINALIZAR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            ExecuteNonQuery(cmd)
        End Sub


        ''' <summary>
        ''' 	Função que retorna uma listagem completa
        ''' </summary>
        Public Sub Justificar(ByVal vIDJustificativa As Integer)
            Dim cmd As New SqlCommand()
            cmd.CommandText = PREFIXO & "BS_ATENDIMENTO_CLIENTE_JUSTIFICAR"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IDVISITA", SqlDbType.Int).Value = m_intIDVisita
            cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = User.IDEmpresa
            cmd.Parameters.Add("@IDJUSTIFICATIVA", SqlDbType.Int).Value = vIDJustificativa
            ExecuteNonQuery(cmd)
        End Sub
#End Region

    End Class
End Namespace

