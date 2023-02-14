Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports ITCOffLine

Public Class clsPropostaOrcamentos
    Inherits DataClass


#Region "Declarations"
    Protected m_intIdPropostaItem As Integer
    Protected m_intIdProposta As Integer
    Protected m_intIdOrcamento As Integer
    Protected m_intIdPlano As Integer
    Protected m_strPlano As String
    Protected m_strInicioPlano As String
    Protected m_strFimPlano As String
    Protected m_decValor As Decimal
    Protected m_strPlanoEspecifico As String
    Protected m_strPrazo As String
    Protected m_strCondPagamento As String
    Protected m_strPrimeiroVenc As String
    Protected m_blnIsNew As Boolean = True
    Protected m_decValorRenovacao As Decimal
    Protected m_strExpiraOrcamento As String
#End Region


#Region "Properties"
    Public Overridable ReadOnly Property IdPropostaItem() As Integer
        Get
            Return m_intIdPropostaItem
        End Get
    End Property

    Public Overridable Property IdProposta() As Integer
        Get
            Return m_intIdProposta
        End Get
        Set(ByVal Value As Integer)
            m_intIdProposta = Value
        End Set
    End Property

    Public Overridable Property IdOrcamento() As Integer
        Get
            Return m_intIdOrcamento
        End Get
        Set(ByVal Value As Integer)
            m_intIdOrcamento = Value
        End Set
    End Property

    Public Overridable Property IdPlano() As Integer
        Get
            Return m_intIdPlano
        End Get
        Set(ByVal Value As Integer)
            m_intIdPlano = Value
        End Set
    End Property

    Public Overridable Property Plano() As String
        Get
            Return m_strPlano
        End Get
        Set(ByVal Value As String)
            m_strPlano = Value
        End Set
    End Property


    Public Overridable Property InicioPlano() As String
        Get
            Return _getDatePropertyValue(m_strInicioPlano)
        End Get
        Set(ByVal Value As String)
            m_strInicioPlano = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable Property FimPlano() As String
        Get
            Return _getDatePropertyValue(m_strFimPlano)
        End Get
        Set(ByVal Value As String)
            m_strFimPlano = _setDateTimePropertyValue(Value)
        End Set
    End Property

    Public Overridable Property Valor() As Decimal
        Get
            Return m_decValor
        End Get
        Set(ByVal Value As Decimal)
            m_decValor = Value
        End Set
    End Property

    Public Overridable Property PlanoEspecifico() As String
        Get
            Return m_strPlanoEspecifico
        End Get
        Set(ByVal Value As String)
            m_strPlanoEspecifico = Value
        End Set
    End Property

    Public Overridable Property Prazo() As String
        Get
            Return m_strPrazo
        End Get
        Set(ByVal Value As String)
            m_strPrazo = Value
        End Set
    End Property

    Public Overridable Property CondicaoPagamento() As String
        Get
            Return m_strCondPagamento
        End Get
        Set(ByVal Value As String)
            m_strCondPagamento = Value
        End Set
    End Property

    Public Overridable Property PrimeiroVencimento() As String
        Get
            Return m_strPrimeiroVenc
        End Get
        Set(ByVal Value As String)
            m_strPrimeiroVenc = Value
        End Set
    End Property

    Public ReadOnly Property IsNew() As Boolean
        Get
            Return m_blnIsNew
        End Get
    End Property

    Public Overridable Property ValorRenovacao() As Decimal
        Get
            Return m_decValorRenovacao
        End Get
        Set(ByVal Value As Decimal)
            m_decValorRenovacao = Value
        End Set
    End Property

    Public Overridable Property ExpiraOrcamento() As String
        Get
            Return m_strExpiraOrcamento
        End Get
        Set(ByVal Value As String)
            m_strExpiraOrcamento = Value
        End Set
    End Property

#End Region

#Region "Metodos"

    ''' <summary>
    ''' 	Função protegida que carrega nas variaveis internas os valores presentes no DataRow
    ''' </summary>
    ''' <param name="row">objeto DataRow com os valores obtidos do banco de dados</param>
    Private Sub Inflate(ByVal row As SqlDataReader)
        Me.m_intIdOrcamento = CLng(0 & row("IdOrcamento"))
        Me.m_intIdPropostaItem = CLng(0 & row("IdPropostaItem"))
        Me.m_intIdProposta = CLng(0 & row("IdProposta"))
        Me.m_intIdPlano = CLng(0 & row("IdPlano"))
        Me.m_strPlano = CStr(0 & row("Plano"))
        If row.IsDBNull(row.GetOrdinal("Inicio")) Then
            m_strInicioPlano = ""
        Else
            m_strInicioPlano = row.GetString(row.GetOrdinal("Inicio"))
        End If
        If row.IsDBNull(row.GetOrdinal("Termino")) Then
            m_strFimPlano = ""
        Else
            m_strFimPlano = row.GetString(row.GetOrdinal("Termino"))
        End If
        Me.m_decValor = CDec(0 & row("Valor"))
        Me.m_strPlanoEspecifico = CStr(row("PlanoEspecifico"))
        Me.m_strPrazo = CStr(row("Periodo"))
        Me.m_strCondPagamento = CStr(row("CondPagamento") & "")
        Me.m_strPrimeiroVenc = CStr(row("PrimeiroVencimento") & "")
        Me.m_decValorRenovacao = CDec(0 & row("ValorRenovacao"))
        Me.m_strExpiraOrcamento = CStr(row("ExpiraOrcamento") & "")
    End Sub

    ''' <summary>
    ''' 	Função que grava os dados do registro atual
    ''' </summary>
    Public Sub SalvarPropostaOrcamentoItem(ByVal p_IdProposta As Integer, ByVal p_IdPlano As Integer, ByVal p_Inicio As DateTime, ByVal p_Termino As DateTime, ByVal p_Valor As String, ByVal p_PlanoEspecifico As String, ByVal p_Prazo As String, ByVal p_ValorRenovacao As String, ByVal p_CondPagamento As String, Optional ByVal p_IdOrcamento As Integer = 0, Optional ByVal p_IdPropostaItem As Integer = 0, Optional ByVal p_ExpiraOrcamento As String = "")
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SV_PROPOSTAORCAMENTO_ITEM"
        cmd.Parameters.Add("@IDPROPOSTAITEM", SqlDbType.Int).Value = p_IdPropostaItem
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = p_IdProposta
        cmd.Parameters.Add("@IDORCAMENTO", SqlDbType.Int).Value = p_IdOrcamento
        cmd.Parameters.Add("@IDPLANO", SqlDbType.Int).Value = p_IdPlano
        cmd.Parameters.Add("@INICIOPLANO", SqlDbType.DateTime).Value = IIf(p_Inicio = "#12:00:00 AM#", Nothing, _setDateTimeDBValue(p_Inicio))
        cmd.Parameters.Add("@FIMPLANO", SqlDbType.DateTime).Value = IIf(p_Termino = "#12:00:00 AM#", Nothing, _setDateTimeDBValue(p_Termino))
        cmd.Parameters.Add("@VALOR", SqlDbType.Money).Value = p_Valor
        If p_ValorRenovacao <> 0 Then
            cmd.Parameters.Add("@VALORRENOVACAO", SqlDbType.Money).Value = p_ValorRenovacao
        End If
        cmd.Parameters.Add("@PLANOESPECIFICO", SqlDbType.VarChar, 1000).Value = p_PlanoEspecifico
        cmd.Parameters.Add("@PERIODO", SqlDbType.VarChar, 15).Value = p_Prazo
        cmd.Parameters.Add("@CONDPAGAMENTO", SqlDbType.VarChar, 100).Value = p_CondPagamento
        If p_ExpiraOrcamento <> "" Then
            cmd.Parameters.Add("@EXPIRAORCAMENTO", SqlDbType.DateTime).Value = p_ExpiraOrcamento
        End If
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

    Public Sub AprovarOrcamento(ByVal p_IdProposta As Integer, ByVal p_IdOrcamento As Integer)

        Try
            Dim sql As String
            sql = "SP_SV_PROPOSTAORCAMENTO_ITEM_APROVAR " & p_IdProposta & "," & p_IdOrcamento
            ExecuteNonQuery(sql)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Sub

    Public Function ConvertDoubleToSQL(ByVal vDbl As Double) As String
        Return vDbl.ToString.Replace(".", "").Replace(",", ".")
    End Function

    ''' <summary>
    ''' 	Função que retorna um DataSet com a listagem dos planos inclusos na proposta
    ''' </summary>
    ''' <param name="p_IdOrcamento">Filtra a pesquisa pelo Número do Orcamento</param>
    ''' <returns>DataSet</returns>
    Public Function ListPropostaOrcamentoItem(ByVal p_IdOrcamento As Integer) As DataSet
        Try
            ListPropostaOrcamentoItem = GetDataSet("SP_SE_PROPOSTAORCAMENTOITEM " & p_IdOrcamento)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function

    ''' <summary>
    ''' 	Função que retorna um DataSet com a listagem dos planos inclusos na proposta
    ''' </summary>
    ''' <param name="p_IdOrcamento">Filtra a pesquisa pelo Número do Orcamento</param>
    ''' <returns>DataSet</returns>
    Public Function ListFormPropostaOrcamentoItem(ByVal p_IdOrcamento As Integer) As DataSet
        Try
            ListFormPropostaOrcamentoItem = GetDataSet("SP_SE_FORMULARIOPROPOSTAITEM " & p_IdOrcamento)
        Catch e As Exception
            ExecuteNonQuery("SP_BS_ERROS 1, '" & e.Message & "','" & e.Source & "','ITC-NET'")
        End Try
    End Function



    ''' <summary>
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIdOrcamento">Chave primaria IdOrcamento</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIdOrcamento As Integer) As Boolean
        If vIdOrcamento = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_PROPOSTAORCAMENTOITEM"
        cmd.Parameters.Add("@IDORCAMENTO", SqlDbType.Int).Value = vIdOrcamento
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
    ''' 	Função que obtem os dados do registro solicitado 
    ''' </summary>
    ''' <param name="vIdOrcamento">Chave primaria IdOrcamento</param>
    ''' <param name="vIdPropostaItem">Chave primaria IdPropostaItem</param>
    ''' <returns>Boolean</returns>
    Public Function Load(ByVal vIdOrcamento As Integer, ByVal vIdPropostaItem As Integer) As Boolean
        If vIdOrcamento = 0 Then
            Clear()
            Return False
        End If
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_SE_PROPOSTAORCAMENTOITEM"
        cmd.Parameters.Add("@IDORCAMENTO", SqlDbType.Int).Value = vIdOrcamento
        cmd.Parameters.Add("@IDPROPOSTAITEM", SqlDbType.Int).Value = vIdPropostaItem
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
        m_intIdPropostaItem = 0
        m_intIdProposta = 0
        m_intIdOrcamento = 0
        m_intIdPlano = 0
        m_strPlano = ""
        m_strInicioPlano = ""
        m_strFimPlano = ""
        m_decValor = Nothing
        m_strPlanoEspecifico = ""
        m_strPrazo = ""
        m_blnIsNew = True
        m_strCondPagamento = ""
        m_strPrimeiroVenc = ""
        m_decValorRenovacao = Nothing
        m_strExpiraOrcamento = ""
    End Sub

    Public Function DeleteOrcamento(ByVal IdProposta As Integer, ByVal IdOrcamento As Integer) As Boolean

        Try
            Dim cmd As New SqlCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SP_DE_PROPOSTAORCAMENTO"
            cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = IdProposta
            cmd.Parameters.Add("@IDORCAMENTO", SqlDbType.Int).Value = IdOrcamento

            ExecuteNonQuery(cmd)

        Catch ex As Exception
            Return False
        End Try

        Return True
        'MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'PropostaOrcamentoItem' the following row:  IdPropostaItem=" & m_intIdPropostaItem & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
    End Function



    ''' <summary>
    ''' 	Rotina que apaga o registro atual
    ''' </summary>
    Public Sub Delete()

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_DE_PROPOSTAORCAMENTOITEM"
        cmd.Parameters.Add("@IDPROPOSTAITEM", SqlDbType.Int).Value = m_intIdPropostaItem

        ExecuteNonQuery(cmd)

        'MyBase.LogEvent("User '" & User.Name & "', IDUser=" & User.IDUser & " is deleting on table 'PropostaOrcamentoItem' the following row:  IdPropostaItem=" & m_intIdPropostaItem & "", "Data Writing", 0, System.Diagnostics.TraceEventType.Information)
        Clear()

    End Sub

    Public Function DeleteItem(ByVal p_IdPropostaItem As Integer, ByVal p_IdOrcamento As Integer) As Boolean
        Try
            ExecuteNonQuery("SP_DE_PROPOSTAORCAMENTOITEM " & p_IdPropostaItem & "," & p_IdOrcamento)
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 	Função que retorna uma listagem completa
    ''' </summary>
    ''' <param name="vReturnType">Tipo de retorno (DataReader ou DataSet)</param>		
    ''' <returns>Retorna um objeto DataReader ou DataSet de acordo com o parâmetro de solicitação</returns>
    Public Function Listar() As SqlDataReader

        Dim cmd As New SqlCommand
        cmd.CommandText = "SP_LS_PROPOSTAORCAMENTOITEMES"
        cmd.CommandType = CommandType.StoredProcedure
        Return ExecuteReader(cmd)

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
    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As SqlDataReader

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_NV_PROPOSTAORCAMENTOITEMES"
        cmd.Parameters.Add("@FILTRO", SqlDbType.VarChar, 100).Value = vFilter
        cmd.Parameters.Add("@ORDER", SqlDbType.VarChar, 20).Value = vOrder
        cmd.Parameters.Add("@DESC", SqlDbType.Bit).Value = vDescending
        cmd.Parameters.Add("@PAGE", SqlDbType.Int).Value = vPage
        cmd.Parameters.Add("@PAGESIZE", SqlDbType.Int).Value = vPageSize

        Return ExecuteReader(cmd)

    End Function


    Public Function ListarOrcamentos(ByVal vIdProposta As Integer) As SqlDataReader

        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SP_LS_PROPOSTAORCAMENTOS"
        cmd.Parameters.Add("@IDPROPOSTA", SqlDbType.Int).Value = vIdProposta

        Return ExecuteReader(cmd)

    End Function


#End Region

End Class
