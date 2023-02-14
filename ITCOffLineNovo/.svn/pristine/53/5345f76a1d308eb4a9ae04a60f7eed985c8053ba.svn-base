Public MustInherit Class Login

    Inherits System.Web.UI.UserControl

    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents tblLogin As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnOK As Button
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
        'Put user code to initialize the page here
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As System.EventArgs) Handles btnOK.Click
        Dim mp As New XMWebPage()
        Usuario = New Usuario(mp)

        Select Case Usuario.Authenticate(txtLogin.Text, txtSenha.Text)
            Case enAuthorize.SetPassword
                Page.Response.Redirect("mudasenha.aspx", True)
            Case enAuthorize.SubscriptionFinished
                lblMensagem.Text = "Plano finalizado. Entre em contato com <a href='mailto:itc@itc.etc.br'><font class=f8>itc@itc.etc.br</font></a>"
            Case enAuthorize.Authorized
                Usuario.AddHistory(Usuario.IDUsuario, "", "", "", "home.aspx")
                Page.Response.Redirect("home.aspx", True)
            Case enAuthorize.NotAuthorized
                lblMensagem.Text = "Usuário incorreto. Por favor, tente novamente..."
            Case Else
                lblMensagem.Text = "Ocorreu um erro ao tentar se conectar ao servidor."
        End Select
    End Sub

End Class
