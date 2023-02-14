Public Class _Default
    Inherits XMWebPage
    Protected WithEvents txtChave As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtUser As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnOk As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents trChave As System.Web.UI.HtmlControls.HtmlTableRow

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


    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Usuario.Authenticate(txtChave.Text, txtUser.Text, txtPassword.Text)
        If Usuario.Authorized = enAuthorize.Denied Then
            lblMessage.Text = "Seu acesso não foi liberado!"
        ElseIf Usuario.Authorized = enAuthorize.NotAuthorized Then
            lblMessage.Text = "Login inválido! Favor verificar a chave, login e senha de acesso"
        ElseIf Usuario.Authorized = enAuthorize.PasswordNotSet Then
            Response.Redirect("MudaSenha.aspx")
        ElseIf Usuario.Authorized = enAuthorize.Authorized Then
            Response.Redirect("principal.aspx")
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            If Application("chave") <> "" Then
                txtChave.Text = Application("chave")
                trChave.Visible = False
            End If
        End If
    End Sub
End Class
