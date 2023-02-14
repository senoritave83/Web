
Public Class Cadastro
    Inherits XMWebPage
    Protected WithEvents txtEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRazao As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCodigo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtAdministrador As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLogin As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVerifyPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVerifyEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMessage As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCadastro2 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCadastro As System.Web.UI.WebControls.Panel
    Protected WithEvents Requiredfieldvalidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidadtor1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents val_txtCNPJCPF_0 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents Requiredfieldvalidator3 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator5 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Requiredfieldvalidator6 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Comparevalidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents Requiredfieldvalidator8 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents val_txtEmail_0 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents CompareValidator2 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents valSumary As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents btnAvancar As System.Web.UI.WebControls.Button
    Protected WithEvents Validationsummary1 As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents lblChecagem As System.Web.UI.WebControls.Label
    Protected emp As clsEmpresa

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
        emp = New clsEmpresa(Me)
    End Sub

    Private Sub Deflate()
        With emp
            .Nome = txtEmpresa.Text
            .Administrador = txtAdministrador.Text
            .CNPJ = txtCNPJ.Text
            .Codigo = txtCodigo.Text
            .EMail = txtEmail.Text
            .Login = txtLogin.Text
            .RazaoSocial = txtRazao.Text
            .Senha = txtPassword.Text
        End With
    End Sub

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Deflate()
        Try
            emp.Update()
        Catch er As System.Data.SqlClient.SqlException
            pnlCadastro.Visible = False
            pnlMessage.Visible = True
            lblMessage.Text = er.Message
            Exit Sub
        End Try
        Dim mail As New Mail.MailMessage()
        mail.To = emp.EMail
        mail.From = "xmsistemas@xmsistemas.com.br"
        mail.Subject = "Seja bem vindo ao sistema E-Dispatch"
        mail.Body = "Bom Dia, Seu cadastro já está sendo efetuado no sistema da Nextel. " & vbCrLf & "Favor anotar seus dados de acesso." & vbCrLf & vbCrLf & "Chave:" & emp.Chave & vbCrLf & "Login:" & emp.Login & vbCrLf & "Senha:" & emp.Senha & vbCrLf & vbCrLf & "Favor entrar em contato com a Central de atendimento da Nextel para habilitar este plano. " & vbCrLf & vbCrLf & "Obrigado." & vbCrLf & "XM Sistemas/Nextel" & vbCrLf
        SendMessage(mail)
        Response.Redirect("cadastrada.aspx?idempresa=" & emp.IDEmpresa)
    End Sub

    Private Sub btnAvancar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAvancar.Click
        If emp.ChecaDados(txtCodigo.Text, "") Then
            pnlCadastro.Visible = False
            pnlCadastro2.Visible = True
            lblChecagem.Visible = False
        Else
            lblChecagem.Visible = True
        End If
    End Sub
End Class
