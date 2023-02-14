Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager

Public Class clsIdentity


    Public Property IDEmpresa() As Integer
        Get
            Return HttpContext.Current.Session.Item("IDEmpresa")
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session.Item("IDEmpresa") = Value
        End Set
    End Property


    Public ReadOnly Property Logado() As Boolean
        Get
            Return (IDUsuario > 0)
        End Get
    End Property

    Public Property IDUsuario() As Integer
        Get
            Return HttpContext.Current.Session.Item("IDUsuario")
        End Get
        Set(ByVal Value As Integer)
            HttpContext.Current.Session.Item("IDUsuario") = Value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return HttpContext.Current.Session.Item("Nome")
        End Get
        Set(ByVal Value As String)
            HttpContext.Current.Session.Item("Nome") = Value
        End Set
    End Property

    Public Property Login() As String
        Get
            Return HttpContext.Current.Session.Item("Login")
        End Get
        Set(ByVal Value As String)
            HttpContext.Current.Session.Item("Login") = Value
        End Set
    End Property

    Public Property Administrador() As Boolean
        Get
            Return HttpContext.Current.Session.Item("Administrador")
        End Get
        Set(ByVal Value As Boolean)
            HttpContext.Current.Session.Item("Administrador") = Value
        End Set
    End Property

    Public Sub New()
        If Not String.IsNullOrEmpty(AppSettings("debug_user")) Then
            Dim vUser() As String = AppSettings("debug_user").Split("|")
            If UBound(vUser) = 3 Then
                IDEmpresa = vUser(0)
                IDUsuario = vUser(1)
                Login = vUser(2)
                Administrador = CBool(vUser(3))
            End If
        End If

    End Sub

End Class
