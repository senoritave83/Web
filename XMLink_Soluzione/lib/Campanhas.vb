Public Class clsCampanhas
    Inherits clsBaseClass

    Protected m_intIDCampanha As Integer
    Protected m_strCodigo As String
    Protected m_strDescricao As String
    Protected m_strValor As Integer
    Protected m_strDataini As String
    Protected m_strDatafim As String
    Protected m_intNumParcelas As Integer
    Protected m_strFoto As String
    Protected m_intPontos As Integer
    Protected m_strDetalhes As String

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Overridable Property IDCampanha() As Integer
        Get
            Return m_intIDCampanha
        End Get
        Set(ByVal value As Integer)
            m_intIDCampanha = value
        End Set
    End Property

    Public Property Codigo() As String
        Get
            Return m_strCodigo
        End Get
        Set(ByVal Value As String)
            m_strCodigo = Value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return m_strDescricao
        End Get
        Set(ByVal Value As String)
            m_strDescricao = Value
        End Set
    End Property

    Public Property ValorMin() As Integer
        Get
            Return m_strValor
        End Get
        Set(ByVal Value As Integer)
            m_strvalor = Value
        End Set
    End Property

    Public Property DataIni() As String
        Get
            Return m_strDataini
        End Get
        Set(ByVal Value As String)
            m_strdataini = Value
        End Set
    End Property

    Public Property DataFim() As String
        Get
            Return m_strDatafim
        End Get
        Set(ByVal Value As String)
            m_strdatafim = Value
        End Set
    End Property

    Public Property Parcelas() As Integer
        Get
            Return m_intNumParcelas
        End Get
        Set(ByVal Value As Integer)
            m_intNumParcelas = Value
        End Set
    End Property

    Public Property Foto() As String
        Get
            Return m_strFoto
        End Get
        Set(ByVal Value As String)
            m_strFoto = Value
        End Set
    End Property

    Public Property Pontos() As String
        Get
            Return m_intPontos
        End Get
        Set(ByVal Value As String)
            m_intPontos = Value
        End Set
    End Property

    Public Property Detalhes() As String
        Get
            Return m_strDetalhes
        End Get
        Set(ByVal Value As String)
            m_strDetalhes = Value
        End Set
    End Property

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_strCodigo = row("cmp_Codigo_chr") & ""
        m_intIDCampanha = CInt(0 & row("cmp_Campanha_int_PK"))
        m_strDescricao = row("cmp_Descricao_chr") & ""
        m_strValor = CInt(0 & row("cmp_ValorMinimo_num"))
        m_strDataini = row("cmp_ValidIni_dtm") & ""
        m_strDatafim = row("cmp_ValidFim_dtm") & ""
        m_intNumParcelas = CInt(0 & row("cmp_NumParcelas_int"))
        m_strFoto = row("cmp_Foto_chr") & ""
        m_strDetalhes = row("cmp_Detalhes_chr") & ""
        m_intPontos = CInt(0 & row("cmp_Pontos_int"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_strCodigo & "', "
        strDeflate &= m_intIDCampanha & ", '"
        strDeflate &= m_strDescricao & "', "
        strDeflate &= m_strValor & ", '"
        strDeflate &= m_strDataini & "', '"
        strDeflate &= m_strDatafim & "', '"
        strDeflate &= m_strFoto.ToLower() & "', "
        strDeflate &= m_intPontos & ", '"
        strDeflate &= m_strDetalhes & "', "
        strDeflate &= m_intNumParcelas
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_CAMPANHA '" & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Não foi possível salvar! Contate o desenvolvedor.")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDCampanha As Integer)
        If p_intIDCampanha = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CAMPANHA " & p_intIDCampanha)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("Campanha não encontrada! Contate o desenvolvedor.")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDCampanha = 0
        m_strCodigo = ""
        m_strDescricao = ""
        m_strValor = 0
        m_strDataini = ""
        m_strDatafim = ""
        m_intNumParcelas = 0
        m_strFoto = ""
        m_intPontos = 0
        m_strDetalhes = ""
    End Sub

    Public Function Existe(ByVal vCodigo As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CAMPANHA_EXISTENTE '" & vCodigo & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Public Sub Delete(ByVal IdCampanha As Integer)
        ExecuteNonQuery(PREFIXO & "DE_CAMPANHA " & IdCampanha)
        Clear()
    End Sub

    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_CAMPANHAS " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

End Class
