
Public Class clsGrupos
    Inherits clsBaseClass
    Protected m_intIDGrupo As Integer
    Protected m_strNome As String
    
    Public ReadOnly Property IDGrupo() As Integer
        Get
            Return m_intIDGrupo
        End Get
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
        m_intIDGrupo = CLng(0 & row("grp_Grupo_int_PK"))
        m_strNome = row("grp_Grupo_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDGrupo & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "'"
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_GRUPO " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDGrupo As Integer)
        If p_intIDGrupo = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_GRUPO " & p_intIDGrupo & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDGrupo = 0
        m_strNome = ""
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_GRUPO " & m_intIDGrupo & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_GRUPO_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
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
        Listar = GetDataSet(PREFIXO & "LS_GRUPOS " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

End Class
