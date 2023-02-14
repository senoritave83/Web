Imports Microsoft.VisualBasic
Imports System.Web


Public Class _Global
    Inherits HttpApplication


    'Protected Shadows Sub AuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs)
    '    'Extract the forms authentication cookie
    '    Dim cookieName As String = FormsAuthentication.FormsCookieName
    '    Dim authCookie As HttpCookie = Context.Request.Cookies(cookieName)

    '    If authCookie Is Nothing Then
    '        'There is no authentication cookie.
    '        Exit Sub
    '    End If

    '    'Add the following code to extract and decrypt the authentication ticket from the forms authentication cookie.
    '    Dim authTicket As FormsAuthenticationTicket = Nothing

    '    Try
    '        authTicket = FormsAuthentication.Decrypt(authCookie.Value)
    '    Catch ex As Exception
    '        'Log exception details (omitted for simplicity)
    '        Exit Sub
    '    End Try

    '    If authTicket Is Nothing Then
    '        '// Cookie failed to decrypt.
    '        Exit Sub
    '    End If

    '    '// Create an Identity object
    '    Dim id As FormsIdentity = New FormsIdentity(authTicket)

    '    Dim s As XMSistemas.Web.Security.XMMemberShipProvider
    '    s = CType(Membership.Provider, XMSistemas.Web.Security.XMMemberShipProvider)
    '    Dim col As Collections.Specialized.NameValueCollection = s.GetUserIdentityData(id.Name)

    '    '// This principal will flow throughout the request.
    '    Dim principal As XMPrincipal = New XMPrincipal(col, id.Name)


    '    '// Attach the new principal object to the current HttpContext object
    '    Context.User = principal
    'End Sub




    Private Sub _Global_AuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AuthenticateRequest


    End Sub

    Private Sub _Global_PostAuthenticateRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PostAuthenticateRequest
        Dim s As String
        s = Context.User.Identity.Name

    End Sub

    Private Sub _Global_PostAuthorizeRequest(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PostAuthorizeRequest

        'Extract the forms authentication cookie
        Dim cookieName As String = FormsAuthentication.FormsCookieName
        Dim authCookie As HttpCookie = Context.Request.Cookies(cookieName)

        If authCookie Is Nothing Then
            'There is no authentication cookie.
            Exit Sub
        End If

        'Add the following code to extract and decrypt the authentication ticket from the forms authentication cookie.
        Dim authTicket As FormsAuthenticationTicket = Nothing

        Try
            authTicket = FormsAuthentication.Decrypt(authCookie.Value)
        Catch ex As Exception
            'Log exception details (omitted for simplicity)
            Exit Sub
        End Try

        If authTicket Is Nothing Then
            '// Cookie failed to decrypt.
            Exit Sub
        End If

        '// Create an Identity object
        Dim id As FormsIdentity = New FormsIdentity(authTicket)

        Dim s As XMSistemas.Web.Provider.XMMemberShipProvider
        s = CType(Membership.Provider, XMSistemas.Web.Provider.XMMemberShipProvider)
        Dim col As Collections.Specialized.NameValueCollection = s.GetUserIdentityData(id.Name)

        '// This principal will flow throughout the request.
        Dim principal As XMPrincipal = New XMPrincipal(col, id.Name)


        '// Attach the new principal object to the current HttpContext object
        Context.User = principal
    End Sub
End Class
