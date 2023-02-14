
Public Class clsPermissoes
    Inherits clsBaseClass
    Protected m_intIDPermissao As Integer
    Protected m_strNome As String
    Protected m_lstUsuarios As clsLista
    Protected m_strAcoes As String

    Public ReadOnly Property IDPermissao() As Integer
        Get
            Return m_intIDPermissao
        End Get
    End Property

    Public ReadOnly Property Usuarios() As clsLista
        Get
            Return m_lstUsuarios
        End Get
    End Property

    Public Property Acoes() As String
        Get
            Return m_strAcoes
        End Get
        Set(ByVal Value As String)
            m_strAcoes = Value
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
        m_intIDPermissao = CLng(0 & row("per_Permissao_int_PK"))
        m_strNome = row("per_Permissao_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDPermissao & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "', "
        strDeflate &= "'" & m_lstUsuarios.GetLista.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strAcoes.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_PERMISSAO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDPermissao As Integer)
        If p_intIDPermissao = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_PERMISSAO " & p_intIDPermissao & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDPermissao = 0
        m_strNome = ""
        m_strAcoes = ""
        m_lstUsuarios = New clsLista
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_PERMISSAO " & m_intIDPermissao & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_PERMISSAO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
        Clear()
    End Sub


    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        Clear()
    End Sub

    Public Function Listar() As DataSet
        Return Listar("", "", False, 0, 0)
    End Function

    Public Function ListarSecoes()
        Return GetDataSet(PREFIXO & "LS_SECOES " & XMPage.IDEmpresa)
    End Function

    Public Function ListarPermissaoAcoes(ByVal vSecao As String)
        Return GetDataSet(PREFIXO & "LS_PERMISSAO_ACOES " & XMPage.IDEmpresa & ", '" & vSecao.Replace("'", "''") & "', " & m_intIDPermissao)
    End Function

    Public Function Listar(ByVal vFilter As String, ByVal vOrder As String, ByVal vDescending As Boolean, ByVal vPage As Integer, ByVal vPageSize As Integer) As DataSet
        Listar = GetDataSet(PREFIXO & "LS_PERMISSOES " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

    Public Function ListarUsuarios() As DataSet
        Return GetDataSet(PREFIXO & "LS_USUARIOS_PERMISSAO " & XMPage.IDEmpresa & ", " & m_intIDPermissao)
    End Function

End Class
