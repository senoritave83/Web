Imports xmlinkwm

Public Class clsVendedor
    Inherits clsBaseClass
    Protected m_intIDVendedor As Integer
    Protected m_strCodigo As String
    Protected m_strNome As String
    Protected m_decDescontoMaximo As Decimal
    Protected m_strLogin As String
    Protected m_strSenha As String
    Protected m_strTelefone As String
    Protected m_strID As String
    Protected m_strObservacao As String
    Protected m_blnTodosClientes As Boolean
    Protected m_blnAcessoWeb As Boolean
    Protected m_lstGrupo As clsLista
    Protected m_intStatus As Integer

    Public Enum STATUS_VENDEDOR
        NENHUM = 0
        ATIVO = 1
        PENDENTE = 2
        BLOQUEADO = 3
    End Enum
    Public ReadOnly Property IDVendedor() As Integer
        Get
            Return m_intIDVendedor
        End Get
    End Property

    Public ReadOnly Property Grupo() As clsLista
        Get
            Return m_lstGrupo
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

    Public Property ID() As String
        Get
            Return m_strID
        End Get
        Set(ByVal Value As String)
            m_strID = Value
        End Set
    End Property

    Public Property Telefone() As String
        Get
            Return m_strTelefone
        End Get
        Set(ByVal Value As String)
            m_strTelefone = Value
        End Set
    End Property

    Public Property DescontoMaximo() As Decimal
        Get
            Return m_decDescontoMaximo
        End Get
        Set(ByVal Value As Decimal)
            m_decDescontoMaximo = Value
        End Set
    End Property

    Public Property Observacao() As String
        Get
            Return m_strObservacao
        End Get
        Set(ByVal Value As String)
            m_strObservacao = Value
        End Set
    End Property

    Public Property TodosClientes() As Boolean
        Get
            Return m_blnTodosClientes
        End Get
        Set(ByVal Value As Boolean)
            m_blnTodosClientes = Value
        End Set
    End Property

    Public Property AcessoWeb() As Boolean
        Get
            Return m_blnAcessoWeb
        End Get
        Set(ByVal Value As Boolean)
            m_blnAcessoWeb = Value
        End Set
    End Property

    Public Property Status() As STATUS_VENDEDOR
        Get
            Return m_intStatus
        End Get
        Set(ByVal Value As STATUS_VENDEDOR)
            m_intStatus = Value
        End Set
    End Property

    Public Function Existe(ByVal vIDVendedor As Integer, ByVal vCodigo As String, ByVal vNome As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_VENDEDOR_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDVendedor & ", '" & vCodigo.Replace("'", "''") & "', '" & vNome.Replace("'", "''") & "'")
        If myData.Tables(0).Rows.Count > 0 Then
            Existe = True
        Else
            Existe = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Public Function ExisteLogin(ByVal vIDVendedor As Integer, ByVal vLogin As String, ByVal vAcessoWeb As Boolean) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_VENDEDOR_LOGIN_EXISTENTE " & XMPage.IDEmpresa & ", " & vIDVendedor & ", '" & vLogin.Replace("'", "''") & "', " & IIf(vAcessoWeb, "1", "0"))
        If myData.Tables(0).Rows.Count > 0 Then
            ExisteLogin = True
        Else
            ExisteLogin = False
        End If
        myData.Dispose()
        myData = Nothing
    End Function

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDVendedor = CLng(0 & row("ven_Vendedor_int_PK"))
        m_strNome = row("ven_Vendedor_chr") & ""
        m_strTelefone = row("ven_Telefone_chr") & ""
        m_strCodigo = row("ven_Codigo_chr") & ""
        m_strLogin = row("ven_Login_chr") & ""
        m_strSenha = row("ven_Senha_chr") & ""
        m_decDescontoMaximo = CDec(0 & row("ven_MaxDesconto_num"))
        m_strID = row("ven_ID_chr") & ""
        m_strObservacao = row("ven_Observacao_chr") & ""
        m_blnTodosClientes = CBool(row("ven_TodosClientes_ind"))
        m_blnAcessoWeb = CBool(row("ven_AcessoWeb_ind"))
        m_intStatus = CInt(0 & row("ven_Ativo_ind"))
    End Sub

    Private Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDVendedor & ", "
        strDeflate &= XMPage.IDEmpresa & ", "
        strDeflate &= "'" & m_strCodigo.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strTelefone.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strID.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strLogin.Replace("'", "''") & "', "
        strDeflate &= "'" & m_strSenha.Replace("'", "''") & "', "
        strDeflate &= m_decDescontoMaximo.ToString("#0.##").Replace(",", ".") & ", "
        strDeflate &= "'" & m_strObservacao.Replace("'", "''") & "', '"
        strDeflate &= m_lstGrupo.GetLista().Replace("'", "''") & "', "
        strDeflate &= IIf(m_blnTodosClientes, "1", "0") & ", "
        strDeflate &= IIf(m_blnAcessoWeb, "1", "0") & ", "
        strDeflate &= CStr(m_intStatus)
        Return strDeflate
    End Function

    Public Function Update()
        Dim sql As String
        sql = PREFIXO & "SV_VENDEDOR " & Deflate()
        Dim myData As DataSet
        myData = GetDataSet(sql)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("There was no data response!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Function

    Public Sub Load(ByVal p_intIDVendedor As Integer)
        If p_intIDVendedor = 0 Then
            Clear()
            Exit Sub
        End If
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_VENDEDOR " & p_intIDVendedor & ", " & XMPage.IDEmpresa)
        If myData.Tables(0).Rows.Count <= 0 Then
            Throw New ArgumentException("This key does not exist!")
        Else
            Inflate(myData.Tables(0).Rows(0))
        End If
        myData.Dispose()
    End Sub

    Protected Sub Clear()
        m_intIDVendedor = 0
        m_strNome = ""
        m_strTelefone = ""
        m_strObservacao = ""
        m_strID = ""
        m_strLogin = ""
        m_strSenha = ""
        m_strCodigo = ""
        m_decDescontoMaximo = 30
        m_blnTodosClientes = False
        m_blnAcessoWeb = False
        m_lstGrupo = New clsLista
        m_intStatus = 0
    End Sub

    Public Sub Delete()
        ExecuteNonQuery(PREFIXO & "DE_VENDEDOR " & m_intIDVendedor & ", " & XMPage.IDEmpresa)
        Clear()
    End Sub

    Public Sub Delete(ByVal vIDs As String)
        ExecuteNonQuery(PREFIXO & "DE_VENDEDOR_SEL '" & vIDs.Replace("'", "''") & "', " & XMPage.IDEmpresa)
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
        Listar = GetDataSet(PREFIXO & "NV_VENDEDORES " & XMPage.IDEmpresa & ", '" & vFilter & "','" & vOrder & "'," & IIf(vDescending, 1, 0) & ", " & vPage & ", " & vPageSize)
    End Function

    Public Function ListarHabilitados() As DataSet
        Return GetDataSet(PREFIXO & "LS_VENDEDORES_HABILITADOS " & XMPage.IDEmpresa)
    End Function

    Public Function ListarGrupos() As DataSet
        Return GetDataSet(PREFIXO & "LS_GRUPOS_VENDEDOR " & XMPage.IDEmpresa & ", " & m_intIDVendedor)
    End Function

    Public Function ListarFiltro() As DataSet
        Return GetDataSet(PREFIXO & "LS_VENDEDORES_FILTRO " & XMPage.IDEmpresa)
    End Function

    Public Function List() As DataSet
        Return GetDataSet(PREFIXO & "LS_VENDEDORES " & XMPage.IDEmpresa)
    End Function

    Public Function ListAll() As DataSet
        Return GetDataSet(PREFIXO & "LS_VENDEDORES_TODOS " & XMPage.IDEmpresa)
    End Function

End Class


Public Class clsLista
    Private m_strLista As String

    Public Sub Clear()
        m_strLista = ""
    End Sub

    Public Sub New()
        m_strLista = ""
    End Sub

    Public Function GetLista() As String
        Return m_strLista
    End Function

    Public Sub Add(ByVal vID As Integer)
        If m_strLista = "" Then
            m_strLista = vID
        Else
            m_strLista &= "," & vID
        End If
    End Sub

End Class
