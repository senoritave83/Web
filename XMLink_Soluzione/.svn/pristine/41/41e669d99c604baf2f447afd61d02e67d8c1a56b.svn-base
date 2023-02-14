

Public MustInherit Class clsUsuarioBase

    Inherits clsBaseClass
    Protected m_intIDUsuario As Integer 'Primary Key
    Protected m_strNome As String
    Protected m_strLogin As String
    Protected m_blnAdministrador As Boolean
    Protected m_intIDVendedor As Integer

    Public ReadOnly Property IDUsuario() As Integer
        Get
            Return m_intIDUsuario
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

    Public Property Login() As String
        Get
            Return m_strLogin
        End Get
        Set(ByVal Value As String)
            m_strLogin = Value
        End Set
    End Property

    Public ReadOnly Property IDVendedor() As Integer
        Get
            Return m_intIDVendedor
        End Get
    End Property

    Public Property Administrador() As Boolean
        Get
            Return m_blnAdministrador
        End Get
        Set(ByVal Value As Boolean)
            m_blnAdministrador = Value
        End Set
    End Property


    Public Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
    End Sub

    Protected Overridable Sub Inflate(ByVal row As DataRow)
        m_intIDUsuario = CLng(0 & row("usu_Usuario_int_PK"))
        m_strNome = CStr(row("usu_Usuario_chr") & "")
        m_strLogin = CStr(row("usu_Login_chr") & "")
        m_blnAdministrador = CBool(0 & row("usu_Administrador_ind"))
        m_intIDVendedor = CLng(0 & row("ven_Vendedor_int_FK"))
    End Sub

    Protected Overridable Function Deflate() As String
        Dim strDeflate As String
        strDeflate &= m_intIDUsuario & ","
        strDeflate &= XMPage.IDEmpresa & ","
        strDeflate &= "'" & m_strNome.Replace("'", "''") & "',"
        strDeflate &= "'" & m_strLogin.Replace("'", "''") & "', "
        strDeflate &= IIf(m_blnAdministrador, 1, 0)
        Deflate = strDeflate
    End Function

    Protected Overridable Sub Clear()
        m_intIDUsuario = 0
        m_strLogin = ""
        m_strNome = ""
        m_blnAdministrador = False
    End Sub

    Public Function CheckPassword(ByVal vUsuario As String, ByVal vSenha As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_USUARIO_CHECASENHA " & m_intIDUsuario & ", '" & vSenha.Replace("'", "''") & "'")
        If myData.Tables.Count > 0 Then
            If myData.Tables(0).Rows.Count <= 0 Then
                Return False
            Else
                Return True
            End If
            myData.Dispose()
        Else
            Return False
        End If
    End Function

    Public Function ChangePassword(ByVal vUsuario As String, ByVal vSenha As String) As Boolean
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SV_USUARIO_ATUALIZASENHA " & m_intIDUsuario & ", '" & vSenha.Replace("'", "''") & "'")
        If myData.Tables.Count > 0 Then
            If myData.Tables(0).Rows.Count <= 0 Then
                Return False
            Else
                Return True
            End If
            myData.Dispose()
        Else
            Return False
        End If
    End Function

End Class
