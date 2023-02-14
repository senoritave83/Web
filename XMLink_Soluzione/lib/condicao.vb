Public Class clsCondicao
    Inherits clsBaseClass
    Protected m_intIDCondicao As Integer
    Protected m_strCondicao As String
    Protected m_decCorrecao As Decimal
    Protected m_strCodigo As String

    Public ReadOnly Property IDCondicao() As Integer
        Get
            Return m_intIDCondicao
        End Get
    End Property

    Public Property Condicao() As String
        Get
            Return m_strCondicao
        End Get
        Set(ByVal Value As String)
            m_strCondicao = Value
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

    Public Property Correcao() As Decimal
        Get
            Return m_decCorrecao
        End Get
        Set(ByVal Value As Decimal)
            m_decCorrecao = Value
        End Set
    End Property


    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDCondicao = CLng(0 & row("con_Condicao_int_PK"))
        m_decCorrecao = CDec(0 & row("con_Correcao_num"))
        m_strCondicao = row("con_Condicao_chr") & ""
        m_strCodigo = row("con_Codigo_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDCondicao & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strCondicao.Replace("'", "''") & "', "
        strDeflate &= m_decCorrecao.ToString("#0.##").Replace(",", ".")
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_CONDICAO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDCondicao As Integer)
        If p_intIDCondicao = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CONDICAO " & p_intIDCondicao & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDCondicao = 0
        m_strCondicao = ""
        m_decCorrecao = 0
        m_strCodigo = ""
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_CONDICAO " & m_intIDCondicao & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_CONDICAO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub


    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Public Function Listar() As DataSet
        Return Listar("", "", False, 0, 0)
    End Function

    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_CONDICOES " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function


    Public Function Existe(ByVal vIDCondicao As Integer, ByVal vCodigo As String, ByVal vNome As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CONDICAO_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDCondicao & ", '" & vNome.Replace("'", "''") & "', '" & vCodigo.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function


End Class
