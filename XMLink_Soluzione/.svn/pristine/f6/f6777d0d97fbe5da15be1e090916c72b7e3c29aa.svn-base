
Public Class UsuarioLogged
    Inherits clsUsuarioBase
    Private m_intAuthorized As enAuthorize

    Sub New(ByVal vXMPage As XMWebPage)
        MyBase.New(vXMPage)
        m_intIDUsuario = vXMPage.Session("sID")
        m_intAuthorized = vXMPage.Session("Authorized")
        m_strLogin = XMPage.Session("Login")
        m_strNome = XMPage.Session("Usuario")
        m_blnAdministrador = XMPage.Session("Administrador")
        m_intIDVendedor = XMPage.Session("IDVendedor")
    End Sub

    Public Function CheckPermission(ByVal vSecao As String, ByVal vAcao As String) As Boolean
        Return XMPage.CheckPermission(vSecao, vAcao)
    End Function

    Public Function Logout()
        m_intIDUsuario = 0
        m_intAuthorized = enAuthorize.NotAuthorized
        XMPage.Session("sID") = 0
        XMPage.Session("Login") = ""
        XMPage.Session("Usuario") = ""
        XMPage.Session("Authorized") = m_intAuthorized
        XMPage.Session("Administrador") = False
        XMPage.Session("IDVendedor") = 0
    End Function

    Public Function SavePassword(ByVal vNewPassword As String) As Boolean
        ExecuteNonQuery(PREFIXO & "UP_USUARIO_SENHA " & m_intIDUsuario & ", '" & vNewPassword.Replace("'", "''") & "'")
        m_intAuthorized = enAuthorize.Authorized
        XMPage.Session("Authorized") = m_intAuthorized
    End Function

    Protected Overrides Sub Inflate(ByVal row As DataRow)
        If IsDate(row("usu_ValidSenha_dtm")) Then
            If row("usu_ValidSenha_dtm") < Date.Now Then
                Me.m_intAuthorized = enAuthorize.PasswordNotSet
            Else
                Me.m_intAuthorized = enAuthorize.Authorized
            End If
        Else
            Me.m_intAuthorized = enAuthorize.Authorized
        End If
        MyBase.Inflate(row)
        XMPage.Session("sID") = m_intIDUsuario
        XMPage.Session("IDEmpresa") = row("emp_Empresa_int_FK")
        XMPage.Session("Login") = m_strLogin
        XMPage.Session("Usuario") = m_strNome
        XMPage.Session("Authorized") = m_intAuthorized
        XMPage.Session("Administrador") = m_blnAdministrador
        XMPage.Session("IDVendedor") = m_intIDVendedor
    End Sub

    Public Function Authenticate(ByVal vChave As String, ByVal vLogin As String, ByVal vPassword As String) As enAuthorize
        Dim myData As DataSet
        myData = GetDataSet(PREFIXO & "SE_USUARIO_LOGIN '" & vChave.Replace("'", "''") & "', '" & vLogin.Replace("'", "''") & "', '" & vPassword.Replace("'", "''") & "'")
        If myData.Tables.Count > 0 Then
            If myData.Tables(0).Rows.Count <= 0 Then
                Clear()
            Else
                Inflate(myData.Tables(0).Rows(0))
                If Not XMPage.CheckPermission("Sistema", "Acessar") Then
                    m_intAuthorized = enAuthorize.Denied
                    XMPage.Session("Authorized") = m_intAuthorized
                End If
            End If
            myData.Dispose()
        Else
            Clear()
        End If
        If m_intAuthorized = enAuthorize.PasswordNotSet Then XMPage.Session("senha") = vPassword
        Return m_intAuthorized
    End Function

    Public ReadOnly Property Authorized() As enAuthorize
        Get
            Return m_intAuthorized
        End Get
    End Property

    Protected Overrides Sub Clear()
        MyBase.Clear()
        m_intAuthorized = enAuthorize.NotAuthorized
    End Sub

End Class