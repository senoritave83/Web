Public Class clsProdutos
    Inherits clsBaseClass
    Protected m_intIDProduto As Integer
    Protected m_strCodigo As String
    Protected m_strDescricao As String
    Protected m_intIDCategoria As Integer
    Protected m_intEstoque As Integer
    Protected m_decPrecoUnitario As Decimal

    Public ReadOnly Property IDProduto() As Integer
        Get
            Return m_intIDProduto
        End Get
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

    Public Property IDCategoria() As Integer
        Get
            Return m_intIDCategoria
        End Get
        Set(ByVal Value As Integer)
            m_intIDCategoria = Value
        End Set
    End Property

    Public Property Estoque() As Integer
        Get
            Return m_intEstoque
        End Get
        Set(ByVal Value As Integer)
            m_intEstoque = Value
        End Set
    End Property

    Public Property PrecoUnitario() As Decimal
        Get
            Return m_decPrecoUnitario
        End Get
        Set(ByVal Value As Decimal)
            m_decPrecoUnitario = Value
        End Set
    End Property


    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDProduto = CInt(0 & row("prd_Produto_int_PK"))
        m_strCodigo = row("prd_Codigo_chr") & ""
        m_strDescricao = row("prd_Descricao_chr") & ""
        m_intIDCategoria = CInt(0 & row("cat_Categoria_int_FK"))
        m_intEstoque = CInt(row("prd_Estoque_int"))
        m_decPrecoUnitario = CDec(row("prd_PrecoUnitario_cur"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDProduto & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strDescricao.Replace("'", "''") & "', "
        strDeflate &= m_intIDCategoria & ", "
        strDeflate &= m_intEstoque & ", "
        strDeflate &= m_decPrecoUnitario.ToString("#0.##").Replace(",", ".")
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_PRODUTO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDProduto As Integer)
        If p_intIDProduto = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_PRODUTO " & p_intIDProduto & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDProduto = 0
        m_strCodigo = ""
        m_strDescricao = ""
        m_intIDCategoria = 0
        m_intEstoque = 0
        m_decPrecoUnitario = 0
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_PRODUTO " & m_intIDProduto & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Function Existe(ByVal vIDProduto As Integer, ByVal vCodigo As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_PRODUTO_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDProduto & ", '" & vCodigo.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_PRODUTO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public Function Listar() As DataSet
        Return Listar(0, "", "", False, 0, 0)
    End Function

    Public Function Listar(ByVal vIDCategoria As Integer, ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_PRODUTOS " & XMPage.IDEmpresa & ", " & vIDCategoria & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

End Class
