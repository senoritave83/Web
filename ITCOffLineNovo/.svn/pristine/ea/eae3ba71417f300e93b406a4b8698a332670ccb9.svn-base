Imports System.Data.SqlClient
Imports System.Diagnostics.EventLog
Imports ITCOffLine
Imports System.Data

Public Class clsPedidoPlanos

    Inherits DataClass
#Region "Declarations"
    Private m_intIdPedido As Integer
    Private m_intIdPlano As Integer
    Private m_intIdPedidoItem As Integer
    Private m_dtmDataInicio As Object
    Private m_dtmDataTermino As Object
    Private m_dcmValor As Double
    Private m_strCondPagto As String
    Private m_strPeriodo As String
    Private m_strPlanoEspecifico As String
    Private m_MensagemErro As String
#End Region

#Region "Properties"

    Public Property IdPedido() As Integer
        Get
            Return m_intIdPedido
        End Get
        Set(ByVal Value As Integer)
            m_intIdPedido = Value
        End Set
    End Property

    Public Property IdPlano() As Integer
        Get
            Return m_intIdPlano
        End Get
        Set(ByVal Value As Integer)
            m_intIdPlano = Value
        End Set
    End Property

    Public Property IdPedidoItem() As Integer
        Get
            Return m_intIdPedidoItem
        End Get
        Set(ByVal Value As Integer)
            m_intIdPedidoItem = Value
        End Set
    End Property

    Public Property DataInicio() As String
        Get
            Return m_dtmDataInicio
        End Get
        Set(ByVal Value As String)
            m_dtmDataInicio = Value
        End Set
    End Property

    Public Property DataTermino() As String
        Get
            Return m_dtmDataTermino
        End Get
        Set(ByVal Value As String)
            m_dtmDataTermino = Value
        End Set
    End Property

    'Public Property DataInicio() As Object
    '    Get
    '        Return IIf(IsDate(m_dtmDataInicio), Right("00" & Day(m_dtmDataInicio), 2) & "/" & Right("00" & Month(m_dtmDataInicio), 2) & "/" & Right("0000" & Year(m_dtmDataInicio), 4), "")
    '    End Get
    '    Set(ByVal Value As Object)
    '        Dim strTemp As Object
    '        strTemp = Split(Value, "/")
    '        If UBound(strTemp) > 0 Then
    '            m_dtmDataInicio = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
    '        Else
    '            m_dtmDataInicio = Nothing
    '        End If
    '    End Set
    'End Property

    'Public Property DataTermino() As Object
    '    Get
    '        Return IIf(IsDate(m_dtmDataTermino), Right("00" & Day(m_dtmDataTermino), 2) & "/" & Right("00" & Month(m_dtmDataTermino), 2) & "/" & Right("0000" & Year(m_dtmDataTermino), 4), "")
    '    End Get
    '    Set(ByVal Value As Object)
    '        Dim strTemp As Object
    '        strTemp = Split(Value, "/")
    '        If UBound(strTemp) > 0 Then
    '            m_dtmDataTermino = strTemp(2) & "-" & strTemp(1) & "-" & strTemp(0)
    '        Else
    '            m_dtmDataTermino = Nothing
    '        End If
    '    End Set
    'End Property

    Public Property Valor() As Double
        Get
            Return m_dcmValor
        End Get
        Set(ByVal Value As Double)
            m_dcmValor = Value
        End Set
    End Property

    Public Property CondicaoPagamento() As String
        Get
            Return m_strCondPagto
        End Get
        Set(ByVal Value As String)
            m_strCondPagto = Value
        End Set
    End Property

    Public Property Periodo() As String
        Get
            Return m_strPeriodo
        End Get
        Set(ByVal Value As String)
            m_strPeriodo = Value
        End Set
    End Property

    Public Property PlanoEspecifico() As String
        Get
            Return m_strPlanoEspecifico
        End Get
        Set(ByVal Value As String)
            m_strPlanoEspecifico = Value
        End Set
    End Property
#End Region

#Region "Métodos"
    ''' <summary>
    ''' 	Função privada que carrega nas variaveis internas os valores presentes no DataRow
    ''' </summary>
    ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>
    Private Sub Inflate(ByVal dr As IDataReader)

        Me.m_intIdPedido = dr.GetInt32(dr.GetOrdinal("IdPedido"))
        Me.m_intIdPlano = dr.GetInt32(dr.GetOrdinal("IdPlano"))
        Me.m_intIdPedidoItem = dr.GetInt32(dr.GetOrdinal("IdPedidoItem"))
        Me.m_dcmValor = dr.GetDecimal(dr.GetOrdinal("Valor"))
        Me.m_strCondPagto = dr.GetString(dr.GetOrdinal("CondPagamento"))
        Me.m_strPlanoEspecifico = dr("PlanoEspecifico")
        Me.m_strPeriodo = dr.GetString(dr.GetOrdinal("Periodo"))

        '***********************************************************
        'CHECAGENS DE DATA PARA NÃO DAR INVALID USE OF NULL
        '***********************************************************
        'Me.m_dtmDataInicio = dr.GetString(dr.GetOrdinal("Inicio"))
        'Me.m_dtmDataTermino = dr.GetString(dr.GetOrdinal("Termino"))
        If IsDate(dr("Inicio")) Then
            Me.m_dtmDataInicio = FormatDateTime(CDate(dr("Inicio")), DateFormat.GeneralDate)
        Else
            Me.m_dtmDataInicio = ""
        End If
        If IsDate(dr("Termino")) Then
            Me.m_dtmDataTermino = FormatDateTime(CDate(dr("Termino")), DateFormat.ShortDate)
        Else
            Me.m_dtmDataTermino = ""
        End If

    End Sub

    ''' <summary>
    ''' 	Função privada que carrega a variavel strDeflate com os valores obtidos do formulário para gravação no banco de dados
    ''' </summary>
    'Private Function Deflate() As String
    '    Dim strDeflate As String
    '    strDeflate &= Me.m_intIdPlano & ","
    '    strDeflate &= "'" & Me.m_dtmDataInicio & "',"
    '    strDeflate &= "'" & Me.m_dtmDataTermino & "',"
    '    strDeflate &= Me.m_dcmValor & ","
    '    strDeflate &= "'" & Replace(m_strCondPagto, "'", "''") & "',"
    '    strDeflate &= Replace(Me.m_dcmPedidoRS, ",", ".") & ","
    '    strDeflate &= Me.m_intIdPedido & ","
    '    Deflate = strDeflate
    'End Function

    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="p_IdPedido">Chave primaria do pedido</param>
    Protected Sub Load(ByVal p_IdPedido As Integer)
        If p_IdPedido = 0 Then
            clear()
            Exit Sub
        End If
        m_MensagemErro = ""
        Dim myData As DataSet = GetDataSet("SP_SE_PEDIDOITEM " & p_IdPedido, m_MensagemErro)

        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("O cadastro indicado não existe!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()

    End Sub

    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="p_IdPedido">Chave primaria do pedido</param>
    ''' <param name="p_IdPedidoItem">Chave primaria da junção pedido plano</param>
    Public Sub Load(ByVal p_IdPedido As Integer, ByVal p_IdPedidoItem As Integer)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_PEDIDOITEM"
        cmd.Parameters.Add("@IDPEDIDO", SqlDbType.Int).Value = p_IdPedido
        cmd.Parameters.Add("@IDPEDIDOITEM", SqlDbType.Int).Value = p_IdPedidoItem
        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try

        'If p_IdPedido = 0 Then
        '    clear()
        '    Exit Sub
        'End If
        'm_MensagemErro = ""
        'Dim myData As DataSet = GetDataSet("SP_SE_PEDIDOITEM " & p_IdPedido & "," & p_IdPedidoItem, m_MensagemErro)

        'If myData.Tables(0).Rows.Count <= 0 Then
        '    Throw New ArgumentException("O cadastro indicado não existe!")
        'Else
        '    Inflate(myData.Tables(0).Rows(0))
        'End If
        'myData.Dispose()

    End Sub

    ''' <summary>
    ''' 	Função privada que limpa as variáveis internas 
    ''' </summary>
    Private Sub clear()
        m_intIdPedido = 0
        m_intIdPlano = 0
        m_intIdPedidoItem = 0
        m_dtmDataInicio = Nothing
        m_dtmDataTermino = Nothing
        m_dcmValor = 0
        m_strCondPagto = ""
        m_strPeriodo = ""
        m_strPlanoEspecifico = ""
    End Sub

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    ''' <param name="p_IdPedido">Chave primária do Pedido</param>
    ''' <param name="p_IdPlano">Chave primária do Plano selecionado</param>
    ''' <param name="p_Inicio">Data de inicio do plano</param>
    ''' <param name="p_Termino">Data de finalização do plano</param>
    ''' <param name="p_Valor">Valor do plano selecionado</param>
    ''' <param name="p_PlanoEspecifico">Plano não cadastrado no sistema</param>
    ''' <param name="p_Periodo">Periodo em que o plano é valido</param>
    ''' <param name="p_CondPagamento">Condição de pagamento para cada plano</param>
    ''' <param name="p_IdPedidoItem">Chave primário do plano já atribuído a um pedido</param>
    ''' <param name="p_IdUsuario">Chave primária do usuário do sistema</param>
    Public Sub Update(ByVal p_IdPedido As Integer, ByVal p_IdPlano As Integer, ByVal p_Inicio As DateTime, ByVal p_Termino As DateTime, ByVal p_Valor As Double, ByVal p_PlanoEspecifico As String, ByVal p_Periodo As String, ByVal p_CondPagamento As String, ByVal p_IdUsuario As Integer, Optional ByVal p_IdPedidoItem As Integer = 0)
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SV_PEDIDOITEM"
        cmd.Parameters.Add("@IDPEDIDO", SqlDbType.Int).Value = p_IdPedido
        cmd.Parameters.Add("@IDPLANO", SqlDbType.Int).Value = p_IdPlano
        cmd.Parameters.Add("@INICIOPLANO", SqlDbType.DateTime).Value = IIf(p_Inicio = "#12:00:00 AM#", Nothing, _setDateTimeDBValue(p_Inicio))
        cmd.Parameters.Add("@FIMPLANO", SqlDbType.DateTime).Value = IIf(p_Termino = "#12:00:00 AM#", Nothing, _setDateTimeDBValue(p_Termino))
        cmd.Parameters.Add("@VALOR", SqlDbType.Money).Value = p_Valor
        cmd.Parameters.Add("@PLANOESPECIFICO", SqlDbType.VarChar, 1000).Value = p_PlanoEspecifico
        cmd.Parameters.Add("@PERIODO", SqlDbType.VarChar, 15).Value = p_Periodo
        cmd.Parameters.Add("@IDPEDIDOITEM", SqlDbType.Int).Value = p_IdPedidoItem
        cmd.Parameters.Add("@CONDPAGAMENTO", SqlDbType.VarChar, 100).Value = p_CondPagamento
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = p_IdUsuario
        Dim dr As IDataReader = ExecuteReader(cmd)
        Try
            If dr.Read Then
                Inflate(dr)
            Else
                clear()
            End If
        Finally
            If (Not dr Is Nothing) Then
                dr.Close()
                dr = Nothing
            End If
        End Try
    End Sub

    ''' <summary>
    ''' 	Função que retorna um DataSet com a listagem dos planos inclusos no pedido
    ''' </summary>
    ''' <param name="p_IdPedido">Filtra a pesquisa pelo Número do Pedido</param>
    ''' <returns>DataSet</returns>
    Public Function ListPedidoItem(ByVal p_IdPedido As Integer) As DataSet
        Try
            ListPedidoItem = GetDataSet("SP_LS_PEDIDOITEM " & p_IdPedido)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    ''' <summary>
    ''' 	Rotina que apaga o plano vinculado ao pedido atual
    ''' </summary>
    ''' <param name="p_IdPedidoItem">Chave primária do plano agregado ao pedido</param>
    ''' <param name="p_IdUsuario">Chave primária do Usuário do sistema</param>
    Public Function DeleteItem(ByVal p_IdPedidoItem As Integer, ByVal p_IdUsuario As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PEDIDOITEM " & p_IdPedidoItem & "," & p_IdUsuario)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function
#End Region

End Class
