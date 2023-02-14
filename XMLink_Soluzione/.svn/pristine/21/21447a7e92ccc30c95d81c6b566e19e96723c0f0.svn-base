Imports System.Data.SqlClient


Public Class clsEmpresa
    Inherits clsBaseClass
    Private m_intIDEmpresa As Integer
    Private m_strChave As String
    Private m_strNome As String
    Private m_strRazao As String
    Private m_strCNPJ As String
    Private m_strCodigo As String
    Private m_strEMail As String
    Private m_strAdministrador As String
    Private m_strLogin As String
    Private m_strSenha As String

    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Public ReadOnly Property IDEmpresa() As Integer
        Get
            Return m_intIDEmpresa
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

    Public Property RazaoSocial() As String
        Get
            Return m_strRazao
        End Get
        Set(ByVal Value As String)
            m_strRazao = Value
        End Set
    End Property

    Public Property CNPJ() As String
        Get
            Return m_strCNPJ
        End Get
        Set(ByVal Value As String)
            m_strCNPJ = Value
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

    Public Property EMail() As String
        Get
            Return m_strEMail
        End Get
        Set(ByVal Value As String)
            m_strEMail = Value
        End Set
    End Property

    Public Property Administrador() As String
        Get
            Return m_strAdministrador
        End Get
        Set(ByVal Value As String)
            m_strAdministrador = Value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return m_strLogin
        End Get
        Set(ByVal Value As String)
            m_strLogin = Value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return m_strSenha
        End Get
        Set(ByVal Value As String)
            m_strSenha = Value
        End Set
    End Property

    Public ReadOnly Property Chave() As String
        Get
            Return m_strChave
        End Get
    End Property

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDEmpresa = CLng(0 & row("emp_Empresa_int_PK"))
        m_strNome = row("emp_Empresa_chr") & ""
        m_strRazao = row("emp_Razao_chr") & ""
        m_strCNPJ = row("emp_CNPJ_chr") & ""
        m_strCodigo = row("emp_Codigo_chr") & ""
        m_strAdministrador = row("emp_Administrador_chr") & ""
        m_strEMail = row("emp_Email_chr") & ""
        m_strLogin = row("emp_Login_chr") & ""
        m_strSenha = row("emp_Senha_chr") & ""
        m_strChave = row("emp_Chave_chr") & ""
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDEmpresa & ","
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strRazao.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strCNPJ.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strAdministrador.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strEMail.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strLogin.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strSenha.Replace("'", "''") & "'"
        Deflate = strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_EMPRESA " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDEmpresa As Integer)
        If p_intIDEmpresa = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_EMPRESA " & p_intIDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Public Function Pesquisar(ByVal p_strCNPJ As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_EMPRESA_CNPJ '" & p_strCNPJ & "'")
        If myData.Tables(0).Rows.Count <= 0 Then
            Pesquisar = False
        Else
            Inflate(myData.Tables(0).Rows(0))
            Pesquisar = True
        End If
        myData.Dispose()
    End Function

    Public Function ChecaDados(ByVal vCodigo As String, ByVal vSenha As String) As Boolean
        Return True
    End Function

    Protected Sub Clear()
        m_intIDEmpresa = 0
        m_strChave = ""
        m_strNome = ""
        m_strRazao = ""
        m_strCNPJ = ""
        m_strCodigo = ""
        m_strEMail = ""
        m_strAdministrador = ""
        m_strLogin = ""
        m_strSenha = ""
    End Sub


End Class
