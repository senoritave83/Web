Public MustInherit Class Login

    Inherits System.Web.UI.UserControl

    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents btnLogin As Button
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents tblLogin As System.Web.UI.HtmlControls.HtmlTable
    Private Usuario As Usuario

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Response.Expires = -1
            Response.ExpiresAbsolute = Now().AddHours(-1)

            XMCookie.setEncryptedCookie("sID", 0)
            XMCookie.setEncryptedCookie("Usuario", "")
            XMCookie.setEncryptedCookie("IDGrupo", 0)
            XMCookie.setEncryptedCookie("Authorized", enAuthorize.NotAuthorized)
            XMCookie.setEncryptedCookie("Login", "")
            XMCookie.setEncryptedCookie("IDEmpresa", 0)
            XMCookie.setEncryptedCookie("DataInicioPlano", "")
            XMCookie.setEncryptedCookie("DataFimPlano", "")
            XMCookie.setEncryptedCookie("QuantidadeObras", 0)
            XMCookie.setEncryptedCookie("QuantidadeEmpresas", 0)
            XMCookie.setEncryptedCookie("Master", 0)
        End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim mp As New XMWebPage
        Usuario = New Usuario(mp)

        If mp.Debug Then
            Usuario.IniciarDebug()
            Page.Response.Redirect("home.aspx", True)
        End If

        Dim p_UserGuid As String = XMCookie.getEncryptedCookieValue("lgGuid")
        If p_UserGuid = "" Then
            p_UserGuid = System.Guid.NewGuid().ToString()
            XMCookie.setEncryptedCookie("lgGuid", p_UserGuid)
        End If

        Select Case Usuario.Authenticate(txtLogin.Text, txtSenha.Text, p_UserGuid)
            Case enAuthorize.SetPassword
                Page.Response.Redirect("mudasenha.aspx")
            Case enAuthorize.SubscriptionFinished
                lblMensagem.Text = "Plano finalizado. Entre em contato com <a href='mailto:itc@itc.etc.br'><font class=f8>itc@itc.etc.br</font></a>"
            Case enAuthorize.Authorized
                Page.Response.Redirect("home.aspx")
            Case enAuthorize.NotAuthorized
                lblMensagem.Text = "Usuário incorreto. Por favor, tente novamente..."
            Case enAuthorize.UserAlreadyLoggedIn
                lblMensagem.Text = "Usuário já está logado em outro IP ou Computador"
        End Select

    End Sub
End Class
