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
    Protected WithEvents lblLogin As System.Web.UI.WebControls.Label
    Protected WithEvents lblNome As System.Web.UI.WebControls.Label
    Protected WithEvents frmCad As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents tblDados As System.Web.UI.HtmlControls.HtmlTable

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
        tblDados.Visible = False
        If Usuario.SavePassword(txtSenha.Text) = True Then
            lblMensagem.Text = "Alteração efetuada com sucesso. Aguarde... você está sendo redirecionado para a home do sistema."
            ltjava.Text = "<script language='javascript'>setTimeout(""document.location.href='home.aspx'"", 3000);</script>"
        Else
            lblMensagem.Text = "Não foi possível alterar sua senha. Entre em contato com o administrador do sistema."
        End If
    End Sub
End Class
