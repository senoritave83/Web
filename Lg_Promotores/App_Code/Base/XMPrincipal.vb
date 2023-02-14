Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Security.Principal
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Security
Imports XMSistemas.Web.Provider


Public Class XMPrincipal
    Inherits DataClass
    Implements IXMPrincipal

    Protected _identity As System.Security.Principal.GenericIdentity
    Protected m_intIDEmpresa As Integer
    Protected m_intIDUser As Integer
    Protected m_strName As String
    Protected m_blnAdministrator As Boolean
    Protected m_strRoles() As String
    Protected m_strInternalName As String
    Protected m_intIDCoordenador As Integer
    Protected m_intIDLider As Integer
    Protected m_intIDPromotor As Integer
    Protected m_strChave As String
    Protected _alldata As NameValueCollection

    Public Sub New(ByVal data As NameValueCollection, ByVal internalname As String)
        _alldata = data
        m_intIDEmpresa = CInt("0" & data.Item("IDEmpresa"))
        m_intIDUser = CInt("0" & data.Item("UserID"))
        m_strName = data.Item("Name") & ""
        m_blnAdministrator = (data.Item("Admin") = "1")
        m_strInternalName = internalname
        _identity = New System.Security.Principal.GenericIdentity(internalname)
        If Roles.Enabled Then
            m_strRoles = Roles.GetRolesForUser(internalname)
        End If
        m_intIDCoordenador = CInt("0" & data.Item("IdCoordenador"))
        m_intIDLider = CInt("0" & data.Item("IdLider"))
        m_intIDPromotor = CInt("0" & data.Item("IdPromotor"))
        m_strChave = CStr(data.Item("Chave") & "")

    End Sub

    Public Sub Log(ByVal vSecao As String, ByVal vAcao As String)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "IN_LOG"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = IDUser
        cmd.Parameters.Add("@SECAO", SqlDbType.VarChar).Value = vSecao
        cmd.Parameters.Add("@ACAO", SqlDbType.VarChar).Value = vAcao

        ExecuteNonQuery(cmd)

    End Sub

    Public Sub LogUsuario(ByVal vSecao As String, ByVal vAcao As String)

        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "IN_LOGUSUARIO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = IDUser
        cmd.Parameters.Add("@SECAO", SqlDbType.VarChar).Value = vSecao
        cmd.Parameters.Add("@ACAO", SqlDbType.VarChar).Value = vAcao

        ExecuteNonQuery(cmd)

    End Sub


    Public ReadOnly Property Identity() As IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return _identity
        End Get
    End Property

    Public ReadOnly Property isAdmin() As Boolean Implements IXMPrincipal.isAdmin
        Get
            Return m_blnAdministrator
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        If m_blnAdministrator Then
            Return True
        ElseIf Roles.Enabled Then
            Dim i As Integer = 0
            For i = 0 To m_strRoles.Length - 1
                If m_strRoles(i) = role Then
                    Return True
                End If
            Next
            Return Roles.IsUserInRole(m_strInternalName, role)
        Else
            Return True
        End If
    End Function

    Public ReadOnly Property IDEmpresa() As Integer Implements IXMPrincipal.IDEmpresa
        Get
            Return m_intIDEmpresa
        End Get
    End Property

    Public ReadOnly Property IDUser() As Integer Implements IXMPrincipal.IDUser
        Get
            Return m_intIDUser
        End Get
    End Property

    Public ReadOnly Property Name() As String Implements IXMPrincipal.Name
        Get
            Return m_strName
        End Get
    End Property

    Public ReadOnly Property Chave() As String
        Get
            Return m_strChave
        End Get
    End Property

    Public ReadOnly Property IdCoordenador() As String
        Get
            Return m_intIDCoordenador
        End Get
    End Property

    Public ReadOnly Property IdLider() As String
        Get
            Return m_intIDLider
        End Get
    End Property

    Public ReadOnly Property IdPromotor() As String
        Get
            Return m_intIDPromotor
        End Get
    End Property

    Public Function VerificaPermissao(ByVal vSecao As String, ByVal vAcao As String) As Boolean Implements IXMPrincipal.VerificaPermissao
        Dim cmd As New SqlCommand()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "BS_VERIFICAR_PERMISSAO"
        Dim parameter As New SqlParameter("@RETURN_VALUE", SqlDbType.Int)
        parameter.Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add(parameter)
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = IDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = IDUser
        cmd.Parameters.Add("@SECAO", SqlDbType.VarChar, 50).Value = vSecao
        cmd.Parameters.Add("@ACAO", SqlDbType.VarChar, 50).Value = vAcao
        ExecuteNonQuery(cmd)
        If cmd.Parameters("@RETURN_VALUE").Value = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public ReadOnly Property AllData() As System.Collections.Specialized.NameValueCollection Implements IXMPrincipal.AllData
        Get
            Return _alldata
        End Get
    End Property
End Class

