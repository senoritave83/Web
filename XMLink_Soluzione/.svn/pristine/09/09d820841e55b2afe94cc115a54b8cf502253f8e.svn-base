Public Class clsCategoria
    Inherits clsBaseClass
    Protected m_intIDCategoria As Integer
    Protected m_strNome As String
    Protected m_strCodigo As String

    Public ReadOnly Property IDCategoria() As Integer
        Get
            Return m_intIDCategoria
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

    Public Property Nome() As String
        Get
            Return m_strNome
        End Get
        Set(ByVal Value As String)
            m_strNome = Value
        End Set
    End Property


    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDCategoria = CLng(0 & row("cat_Categoria_int_PK"))
        m_strCodigo = row("cat_Codigo_chr") & ""
        m_strNome = row("cat_Categoria_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDCategoria & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_CATEGORIA " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDCategoria As Integer)
        If p_intIDCategoria = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CATEGORIA " & p_intIDCategoria & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDCategoria = 0
        m_strNome = ""
        m_strCodigo = ""
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_CATEGORIA " & m_intIDCategoria & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_CATEGORIA_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
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
        Listar = GetDataSet(PREFIXO & "LS_CATEGORIAS " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function


    Public Function Existe(ByVal vIDCategoria As Integer, ByVal vCodigo As String, ByVal vNome As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_CATEGORIA_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDCategoria & ", '" & vNome.Replace("'", "''") & "', '" & vCodigo.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function



End Class
