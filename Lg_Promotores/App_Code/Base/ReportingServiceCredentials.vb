Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager

Public Class ReportServiceCredentials
    Implements Microsoft.Reporting.WebForms.IReportServerCredentials

    Private _username As String
    Private _password As String
    Private _domain As String

    Public Function GetFormsCredentials(ByRef authCookie As System.Net.Cookie, ByRef userName As String, ByRef password As String, ByRef authority As String) As Boolean Implements Microsoft.Reporting.WebForms.IReportServerCredentials.GetFormsCredentials
        ' not use FormsCredentials unless you have implements a custom autentication.
        authCookie = Nothing
        userName = Nothing
        password = Nothing
        authority = Nothing
        Return False
    End Function

    Public Sub New()
        _username = XMCrypto.Decrypt(AppSettings("rep_username") & "")
        _password = XMCrypto.Decrypt(AppSettings("rep_password") & "")
        _domain = XMCrypto.Decrypt(AppSettings("rep_domain") & "")
    End Sub

    Public Sub New(ByVal username As String, ByVal password As String, ByVal domain As String)
        _username = username
        _password = password
        _domain = domain
    End Sub

    Public ReadOnly Property ImpersonationUser As System.Security.Principal.WindowsIdentity Implements Microsoft.Reporting.WebForms.IReportServerCredentials.ImpersonationUser
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property NetworkCredentials As System.Net.ICredentials Implements Microsoft.Reporting.WebForms.IReportServerCredentials.NetworkCredentials
        Get
            Dim netCred As System.Net.ICredentials

            If _username <> "" And _password <> "" And _domain <> "" Then
                netCred = New Net.NetworkCredential(_username, _password, _domain)
            Else
                netCred = Net.CredentialCache.DefaultNetworkCredentials
            End If

            Return netCred

        End Get
    End Property
End Class
