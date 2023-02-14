Public Class MudaSenha

    Inherits XMWebPage

    Protected WithEvents txtSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSenhaConf As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAlterarSenha As System.Web.UI.WebControls.Button
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents ltjava As System.Web.UI.WebControls.Literal
    Protected WithEvents req1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents comp1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblNO As System.Web.UI.WebControls.Label
    Protected WithEvents lblLogin As System.Web.UI.WebControls.Label
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents TxtOldSenha As System.Web.UI.WebControls.TextBox
    Protected WithEvents rowOldSenha As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents rowsenha As System.Web.UI.HtmlControls.HtmlTableRow

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
            lblLogin.Text = Usuario.Login
            lblNome.Text = Usuario.Nome
        End If
    End Sub

    Private Sub btnAlterarSenha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlterarSenha.Click
        If Usuario.CheckPassword(Usuario.Login, TxtOldSenha.Text) Then
            If Usuario.ChangePassword(TxtOldSenha.Text, txtSenha.Text) = True Then
                rowsenha.Visible = False
                rowOldSenha.Visible = False
                btnAlterarSenha.Visible = False
                Session("Authentication") = enAuthorize.Authorized
                lblMensagem.Text = "Sua senha foi alterada com sucesso. Espere... Você está sendo redirecionado para a página inicial."
                ltjava.Text = "<script language='javascript'>setTimeout(""document.location.href='principal.aspx'"", 3000);</script>"
            Else
                lblMensagem.Text = "Não foi possível alterar a senha. Entre em contato com o administrador."
            End If
        Else
            lblMensagem.Text = "Senha anterior inválida!"
        End If
    End Sub
End Class
