Public Class Login1

    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents tblLogin As System.Web.UI.HtmlControls.HtmlTable

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Expires = -1
        Response.ExpiresAbsolute = Now().AddDays(-1)

        If Not Page.IsPostBack Then

            XMCookie.SetEncryptedCookie("sID", 0)
            XMCookie.SetEncryptedCookie("Usuario", "")
            XMCookie.SetEncryptedCookie("IDGrupo", 0)
            XMCookie.SetEncryptedCookie("Authorized", enAuthorize.NotAuthorized)
            XMCookie.SetEncryptedCookie("Login", "")
            XMCookie.SetEncryptedCookie("IDEmpresa", 0)
            XMCookie.SetEncryptedCookie("DataInicioPlano", "")
            XMCookie.SetEncryptedCookie("DataFimPlano", "")
            XMCookie.SetEncryptedCookie("QuantidadeObras", 0)
            XMCookie.SetEncryptedCookie("QuantidadeEmpresas", 0)
            XMCookie.setEncryptedCookie("Master", 0)

            If Request("txtChave") <> "" And Request("txtLogin") <> "" And Request("txtSenha") <> "" Then

                Dim XML As New XMLConfig
                Dim p_Key As String = XML.GetValue("ch", "")
                Dim p_Modo As String = XML.GetValue("modo", "1")

                If Request("txtChave").ToString = p_Key.ToString Then

                    Dim mp As New XMWebPage
                    Dim usu As Usuario = New Usuario(mp)

                    Dim p_UserGuid As String = XMCookie.getEncryptedCookieValue("lgGuid")

                    Response.Write("<script language='javascript'>alert('" & p_UserGuid & "');</script>")

                    Response.Clear()
                    Response.ClearContent()
                    Response.ContentType = "text/xml"

                    If p_UserGuid = "" Then
                        p_UserGuid = System.Guid.NewGuid().ToString()
                        XMCookie.setEncryptedCookie("lgGuid", p_UserGuid)
                    End If

                    Dim auth As ITC.enAuthorize
                    auth = usu.Authenticate(Request("txtLogin"), Request("txtSenha"), p_UserGuid, 1)

                    Select Case auth
                        Case enAuthorize.UserAlreadyLoggedIn
                            Page.Response.Redirect("default.asp?login=4")
                        Case enAuthorize.SetPassword
                            Page.Response.Redirect("mudasenha.aspx")
                        Case enAuthorize.SubscriptionFinished
                            Page.Response.Redirect("default.asp?login=2")
                        Case enAuthorize.Authorized
                            Page.Response.Redirect("home.aspx")
                        Case enAuthorize.NotAuthorized
                            Page.Response.Redirect("default.asp?login=0")
                        Case enAuthorize.UserSuspended
                            Page.Response.Redirect("default.asp?login=5")
                    End Select

                End If

            End If

        End If

    End Sub

End Class
