Imports Microsoft.VisualBasic
Imports System.Collections.Specialized
Imports System.Security.Principal
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Security

Public Class XMPrincipal
    Inherits DataClass
    Implements IPrincipal

    Protected _identity As System.Security.Principal.GenericIdentity
    Protected m_intIDEmpresa As Integer
    Protected m_strEmpresa As String
    Protected m_intIDRegional As Integer
    Protected m_intIDUser As Integer
    Protected m_strName As String
    Protected m_intIDVendedor As Integer
    Protected m_blnAdministrator As Boolean
    Protected m_strChave As String
    Protected m_strRoles() As String

    Public Sub New(ByVal data As NameValueCollection, ByVal internalname As String)

        m_intIDEmpresa = CInt("0" & data.Item("IDEmpresa"))
        m_strEmpresa = data.Item("Empresa") & ""
        m_intIDUser = CInt("0" & data.Item("UserID"))
        m_strName = data.Item("Name") & ""
        m_blnAdministrator = (data.Item("Admin") = "1" Or data.Item("Admin") = "True")
        m_intIDVendedor = CInt("0" & data.Item("IDVendedor"))
        m_intIDRegional = CInt("0" & data.Item("IDRegional"))
        If InStr(internalname, ".") > 0 Then
            m_strChave = internalname.Substring(0, InStr(internalname, "."))
        Else
            m_strChave = ""
        End If
        _identity = New System.Security.Principal.GenericIdentity(internalname)
        If Roles.Enabled Then
            m_strRoles = Roles.GetRolesForUser(internalname)
        End If

    End Sub

    Public ReadOnly Property Identity() As IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return _identity
        End Get
    End Property

    Public ReadOnly Property isAdmin() As Boolean
        Get
            Return m_blnAdministrator
        End Get
    End Property


    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        GravaAcesso(role)
        If m_blnAdministrator Then
            Return True
        ElseIf Roles.Enabled Then
            Dim i As Integer = 0
            For i = 0 To m_strRoles.Length - 1
                If m_strRoles(i) = role Then
                    Return True
                End If
            Next
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub GravaAcesso(ByVal vPermissao As String)
        Dim cn As SqlConnection = GetDBConnection()
        Dim cmd As New SqlCommand()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = PREFIXO & "SE_PERMISSAO_USUARIO"
        cmd.Parameters.Add("@IDEMPRESA", SqlDbType.Int).Value = m_intIDEmpresa
        cmd.Parameters.Add("@IDUSUARIO", SqlDbType.Int).Value = m_intIDUser
        cmd.Parameters.Add("@PERMISSAO", SqlDbType.VarChar).Value = vPermissao
        cn.Open()
        Try
            cmd.ExecuteNonQuery()
        Finally
            If (Not cn Is Nothing) Then
                cn.Close()
                cn = Nothing
            End If
        End Try
    End Sub


    Public ReadOnly Property IDEmpresa() As Integer
        Get
            Return m_intIDEmpresa
        End Get
    End Property

    Public ReadOnly Property Empresa() As String
        Get
            Return m_strEmpresa
        End Get
    End Property

    Public ReadOnly Property IDUser() As Integer
        Get
            Return m_intIDUser
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return m_strName
        End Get
    End Property

    Public ReadOnly Property IDVendedor() As Integer
        Get
            Return m_intIDVendedor
        End Get
    End Property

    Public ReadOnly Property IDRegional() As Integer
        Get
            Return m_intIDRegional
        End Get
    End Property


    Public ReadOnly Property Chave() As String
        Get
            Return m_strChave
        End Get
    End Property

    Sub Log(ByVal p1 As String, ByVal p2 As String)
        Throw New NotImplementedException
    End Sub

End Class

