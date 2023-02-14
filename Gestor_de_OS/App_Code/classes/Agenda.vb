Imports System.Data.SqlClient

Public Class clsAgenda
    Inherits DataClass

#Region "Declarations"
    Protected m_intIDAgendamento As Integer
    Protected m_strAgendamento As String
    Protected m_intIDUsuario As Integer
    Protected m_strCliente As String
    Protected m_strEndereco As String
    Protected m_strReferencia As String
    Protected m_strObservacao As String
    Protected m_intTempoLimite As Integer
    Protected m_intIDDestinatario As Integer
    Protected m_strCriado As String
    Protected m_intDia As Integer
    Protected m_intMes As Integer
    Protected m_intDiaSemana As Integer
    Protected m_indFrequenciaTipo As Byte
    Protected m_intIntervalo As Integer
    Protected m_strDataInicio As String
    Protected m_strDataFinal As String
    Protected m_intHoraInicio As Integer
    Protected m_intHoraFinal As Integer
    Protected m_blnAtivo As Boolean
    Protected m_blnIsNew As Boolean = True
    Protected m_intIDPrioridade As Integer
#End Region


#Region "Properties"
    Public Overridable ReadOnly Property IDAgendamento() As Integer
        Get
            Return m_intIDAgendamento
        End Get
    End Property

    Public Overridable Property Agendamento() As String
        Get
            Return m_strAgendamento
        End Get
        Set(ByVal Value As String)
            m_strAgendamento = Value
        End Set
    End Property

    Public Overridable Property IDUsuario() As Integer
        Get
            Return m_intIDUsuario
        End Get
        Set(ByVal Value As Integer)
            m_intIDUsuario = Value
        End Set
    End Property

    Public Overridable Property Cliente() As String
        Get
            Return m_strCliente
        End Get
        Set(ByVal Value As String)
            m_strCliente = Value
        End Set
    End Property

    Public Property Endereco() As String
        Get
            Return m_strEndereco
        End Get
        Set(ByVal value As String)
            m_strEndereco = value
        End Set
    End Property

    Public Property Referencia() As String
        Get
            Return m_strReferencia
        End Get
        Set(ByVal value As String)
            m_strReferencia = value
        End Set
    End Property

    Public Overridable Property Observacao() As String
        Get
            Return m_strObservacao
        End Get
        Set(ByVal Value As String)
            m_strObservacao = Value
        End Set
    End Property

    Public Overridable Property TempoLimite() As Integer
        Get
            Return m_intTempoLimite
        End Get
        Set(ByVal Value As Integer)
            m_intTempoLimite = Value
        End Set
    End Property

    Public Overridable Property IDDestinatario() As Integer
        Get
            Return m_intIDDestinatario
        End Get
        Set(ByVal Value As Integer)
            m_intIDDestinatario = Value
        End Set
    End Property

    Public Overridable ReadOnly Property Criado() As String
        Get
            Return _getDateTimePropertyValue(m_strCriado)
        End Get
    End Property

    Public Overridable Property Dia() As Integer
        Get
            Return m_intDia
        End Get
        Set(ByVal Value As Integer)
            m_intDia = Value
        End Set
    End Property

    Public Overridable Property Mes() As Integer
        Get
            Return m_intMes
        End Get
        Set(ByVal Value As Integer)
            m_intMes = Value
        End Set
    End Property

    Public Overridable Property DiaSemana() As Integer
        Get
            Return m_intDiaSemana
        End Get
        Set(ByVal Value As Integer)
            m_intDiaSemana = Value
        End Set
    End Property

    Public Overridable Property FrequenciaTipo() As Byte
        Get
            Return m_indFrequenciaTipo
        End Get
        Set(ByVal Value As Byte)
            m_indFrequenciaTipo = Value
        End Set
    End Property

    Public Overridable Property Intervalo() As Integer
        Get
            Return m_intIntervalo
        End Get
        Set(ByVal Value As Integer)
            m_intIntervalo = Value
        End Set
    End Property

    Public Overridable Property DataInicio() As String
        Get
            Return _getDatePropertyValue(m_strDataInicio)
        End Get
        Set(ByVal Value As String)
            m_strDataInicio = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable Property DataFinal() As String
        Get
            Return _getDatePropertyValue(m_strDataFinal)
        End Get
        Set(ByVal Value As String)
            m_strDataFinal = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable Property HoraInicio() As Integer
        Get
            Return m_intHoraInicio
        End Get
        Set(ByVal Value As Integer)
            m_intHoraInicio = Value
        End Set
    End Property

    Public Overridable Property HoraFinal() As Integer
        Get
            Return m_intHoraFinal
        End Get
        Set(ByVal Value As Integer)
            m_intHoraFinal = Value
        End Set
    End Property

    Public Property Ativo() As Boolean
        Get
            Return m_blnAtivo
        End Get
        Set(ByVal value As Boolean)
            m_blnAtivo = value
        End Set
    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return m_blnIsNew
        End Get
    End Property

    Public Overridable Property IDPrioridade() As Integer
        Get
            Return m_intIDPrioridade
        End Get
        Set(ByVal Value As Integer)
            m_intIDPrioridade = Value
        End Set
    End Property

#End Region

#Region "Metodos"

    ''' <summary>
    ''' 	Função protegida que carrega nas variaveis internas os valores presentes no Data Reader
    ''' </summary>
    ''' <param name="dr">objeto IDataReader com os valores obtidos do banco de dados</param>		
    Protected Overridable Sub Inflate(ByVal dr As IDataReader)
        m_intIDAgendamento = dr.GetInt32(dr.GetOrdinal("IDAgendamento"))
        m_strAgendamento = dr.GetString(dr.GetOrdinal("Agendamento"))
        m_intIDUsuario = dr.GetInt32(dr.GetOrdinal("IDUsuario"))
        m_strCliente = dr.GetString(dr.GetOrdinal("Cliente"))
        m_strEndereco = dr.GetString(dr.GetOrdinal("Endereco"))
        m_strReferencia = dr.GetString(dr.GetOrdinal("Referencia"))
        m_strObservacao = dr.GetString(dr.GetOrdinal("Observacao"))
        m_intTempoLimite = dr.GetInt32(dr.GetOrdinal("TempoLimite"))
        If dr.IsDBNull(dr.GetOrdinal("IDDestinatario")) Then
            m_intIDDestinatario = 0
        Else
            m_intIDDestinatario = dr.GetInt32(dr.GetOrdinal("IDDestinatario"))
        End If
        m_strCriado = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("Criado")))
        m_intDia = dr.GetInt32(dr.GetOrdinal("Dia"))
        m_intMes = dr.GetInt32(dr.GetOrdinal("Mes"))
        m_intDiaSemana = dr.GetInt32(dr.GetOrdinal("DiaSemana"))
        m_indFrequenciaTipo = dr.GetByte(dr.GetOrdinal("FrequenciaTipo"))
        m_intIntervalo = dr.GetInt32(dr.GetOrdinal("Intervalo"))
        m_strDataInicio = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataInicio")))
        If dr.IsDBNull(dr.GetOrdinal("DataFinal")) Then
            m_strDataFinal = ""
        Else
            m_strDataFinal = _getDateTimeDBValue(dr.GetDateTime(dr.GetOrdinal("DataFinal")))
        End If
        m_intHoraInicio = dr.GetInt32(dr.GetOrdinal("HoraInicio"))
        m_intHoraFinal = dr.GetInt32(dr.GetOrdinal("HoraFinal"))
        m_blnAtivo = dr.GetBoolean(dr.GetOrdinal("Ativo"))
        m_blnIsNew = False
        If dr.IsDBNull(dr.GetOrdinal("IDPrioridade")) Then
            m_intIDPrioridade = 0
        Else
            m_intIDPrioridade = dr.GetInt32(dr.GetOrdinal("IDPrioridade"))
        End If
    End Sub




    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub Update()
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SV_AGENDAMENTO"
        cmd.Parameters.Add("@IDAGENDAMENTO", SqlDbType.Int).Value = m_intIDAgendamento
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = Identity.IDUsuario
        cmd.Parameters.Add("@AGENDAMENTO", SqlDbType.VarChar, 50).Value = m_strAgendamento
        cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar).Value = m_strCliente
        cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = m_strEndereco
        cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = m_strReferencia
        cmd.Parameters.Add("@OBSERVACAO", SqlDbType.VarChar, 500).Value = m_strObservacao
        cmd.Parameters.Add("@TEMPOLIMITE", SqlDbType.Int).Value = m_intTempoLimite
        cmd.Parameters.Add("@IDDESTINATARIO", SqlDbType.Int).Value = m_intIDDestinatario
        cmd.Parameters.Add("@DIA", SqlDbType.Int).Value = m_intDia
        cmd.Parameters.Add("@MES", SqlDbType.Int).Value = m_intMes
        cmd.Parameters.Add("@DIASEMANA", SqlDbType.Int).Value = m_intDiaSemana
        cmd.Parameters.Add("@FREQUENCIATIPO", SqlDbType.TinyInt).Value = m_indFrequenciaTipo
        cmd.Parameters.Add("@INTERVALO", SqlDbType.Int).Value = m_intIntervalo
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataInicio)
        If m_strDataFinal <> "" Then
            cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(m_strDataFinal)
        End If
        cmd.Parameters.Add("@HORAINICIO", SqlDbType.Int).Value = m_intHoraInicio
        cmd.Parameters.Add("@HORAFINAL", SqlDbType.Int).Value = m_intHoraFinal
        cmd.Parameters.Add("@ATIVO", SqlDbType.Bit).Value = m_blnAtivo
        cmd.Parameters.Add("@IDPRIORIDADE", SqlDbType.Int).Value = m_intIDPrioridade
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
    End Sub


    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIDAgendamento">Chave primaria IDAgendamento</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIDAgendamento As Integer) As Boolean
        If vIDAgendamento = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_AGENDAMENTO"
        cmd.Parameters.Add("@IDAGENDAMENTO", SqlDbType.Int).Value = vIDAgendamento
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
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
        Return True
    End Function

    ''' <summary>
    ''' 	Função interna que limpa as variaveis internas
    ''' </summary>
    Protected Sub Clear()
        m_intIDAgendamento = 0
        m_strAgendamento = ""
        m_intIDUsuario = 0
        m_strCliente = ""
        m_strEndereco = ""
        m_strReferencia = ""
        m_strObservacao = ""
        m_intTempoLimite = 0
        m_intIDDestinatario = 0
        m_strCriado = ""
        m_intDia = 0
        m_intMes = 0
        m_intDiaSemana = 0
        m_indFrequenciaTipo = 0
        m_intIntervalo = 0
        m_strDataInicio = ""
        m_strDataFinal = ""
        m_intHoraInicio = 0
        m_intHoraFinal = 0
        m_blnIsNew = True
        m_intIDPrioridade = 0
    End Sub



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete()

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "DE_AGENDAMENTO"
        cmd.Parameters.Add("@IDAGENDAMENTO", SqlDbType.Int).Value = m_intIDAgendamento
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa

        ExecuteNonQuery(cmd)
        Clear()

    End Sub

    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar(Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_AGENDAMENTOS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        Return ExecuteCommand(cmd, vReturnType)

    End Function

    ''' <summary>
    ''' 	Função que retorna um Data Reader com filtragem, navegação e ordenação
    ''' </summary>
    ''' <param name="vFilter">Filtro a ser utilizado na pesquisa dos dados</param>
    ''' <param name="vIDUsuario">Filtro</param>
    ''' <param name="vCliente">Filtro</param>
    ''' <param name="vResponsavel">Filtro</param>
    ''' <param name="vOrder">Campo a ser utilizado na ordenação</param>
    ''' <param name="vDescending">Informa qual tipo de ordenação utilizar. ascendente ou decrescente</param>		
    ''' <param name="vPage">Número da página a exibir</param>	
    ''' <param name="vPageSize">Tamanho da página em registros</param>		
    ''' <returns>PaginateResult</returns>
    Public Function Listar(ByVal vFilter As String, ByVal vIDUsuario As Integer, ByVal vCliente As String, ByVal vResponsavel As String, ByVal vDataInicio As String, ByVal vDataFinal As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As XMSistemas.Web.Base.PaginateResult

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "NV_AGENDAMENTOS"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataInicio)
        cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = _setDateTimeDBValue(vDataFinal)

        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = vIDUsuario
        cmd.Parameters.Add("@CLIENTE", SqlDbType.VarChar, 100).Value = vCliente
        cmd.Parameters.Add("@RESPONSAVEL", SqlDbType.VarChar, 100).Value = vResponsavel
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecutePaginate(cmd, vReturnType, vPageSize, vPage)

    End Function



    Protected Overrides Function CheckIfSubClassIsValid() As Boolean
        Dim blnValid As Boolean = True

        Return blnValid

    End Function

#End Region


#Region "Adicionais"

    Public Function GetAgendamentoDias(ByVal vData As Date, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_AGENDAMENTO_DIAS"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData.ToString("yyyy-MM-dd")
        Return ExecuteCommand(cmd, vReturnType)

    End Function


    Public Function GetAgendamentoDia(ByVal vData As Date, Optional ByVal vReturnType As enReturnType = enReturnType.DataReader) As Object

        Dim cmd As New SqlCommand()
        cmd.CommandText = SQLPREFIXO & "LS_AGENDAMENTO_DIA"
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData.ToString("yyyy-MM-dd")
        Return ExecuteCommand(cmd, vReturnType)

    End Function


#End Region

#Region "ANTIGAS"


    Protected Function ListaDias(ByVal vInicio As Date, ByVal vFim As Date) As IDataReader
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = "SELECT * FROM DBO.GETDATES(@DATAINICIO, @DATAFINAL)"

        cmd.Parameters.Add("@DATAINICIO", SqlDbType.DateTime).Value = vInicio.ToString("dd/MM/yyyy")
        cmd.Parameters.Add("@DATAFINAL", SqlDbType.DateTime).Value = vFim.ToString("dd/MM/yyyy")

        Return ExecuteReader(cmd)
    End Function


    Public Function ListMes(ByVal vMes As Integer, ByVal vAno As Integer) As IDataReader

        Dim dtStart, dtFim, dtTemp As Date
        dtTemp = CDate(vAno & "-" & Right("00" & vMes, 2) & "-01")
        dtStart = dtTemp.AddDays(-CInt(dtTemp.DayOfWeek))
        dtTemp = dtTemp.AddMonths(1).AddDays(-1)
        dtFim = dtTemp.AddDays(7 - CInt(dtTemp.DayOfWeek))

        Return ListaDias(dtStart, dtFim)

        'Return GetDataSet("SELECT * FROM DBO.GETDATES('" & dtStart.ToString("yyyy-MM-dd") & "', '" & dtFim.ToString("yyyy-MM-dd") & "')")
    End Function


    Public Function ListDia(ByVal vDia As Date) As IDataReader

        Return ListaDias(vDia, vDia.AddDays(1))

        'Return GetDataSet("SELECT * FROM DBO.GETDATES('" & vDia.ToString("yyyy-MM-dd") & "', '" & vDia.AddDays(1).ToString("yyyy-MM-dd") & "')")
    End Function

    Public Function GetTarefas(ByVal vData As Date, ByVal vMinutes As Integer) As IDataReader

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = SQLPREFIXO & "SE_ORDEM_SERVICO_DIA"

        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = Identity.IDEmpresa
        cmd.Parameters.Add("@DATA", SqlDbType.DateTime).Value = vData
        cmd.Parameters.Add("@MINUTES", SqlDbType.Int).Value = vMinutes

        Return ExecuteReader(cmd)

        '        Return GetDataSet("SP_WEB_SE_ORDEM_SERVICO_DIA " & Identity.IDEmpresa & ", '" & vData.ToString("yyyy-MM-dd HH:mm:ss") & "', " & vMinutes)
    End Function

#End Region

End Class
