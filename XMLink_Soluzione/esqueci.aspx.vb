Public Class esqueci
    Inherits XMWebPage
    Protected WithEvents txtCNPJ As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnOk As System.Web.UI.WebControls.ImageButton
    Protected pnlStart As System.Web.UI.WebControls.Panel
    Protected pnlMessage As System.Web.UI.WebControls.Panel
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents val_txtCNPJCPF_0 As System.Web.UI.WebControls.CustomValidator
    Protected WithEvents valSumary As System.Web.UI.WebControls.ValidationSummary
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected lblMessage As System.Web.UI.WebControls.Label

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

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim emp As New clsEmpresa(Me)
        pnlStart.Visible = False
        If emp.Pesquisar(txtCNPJ.Text) Then
            Dim mail As New Mail.MailMessage()
            mail.To = emp.EMail
            mail.From = "xmsistemas@xmsistemas.com.br"
            mail.Subject = "Dados de acesso para o E-Dispatch"
            mail.Body = "Conforme solicitado, estamos te enviando novamente os dados de acesso ao sistema E-Dispatch." & vbCrLf & vbCrLf & "Chave:" & emp.Chave & vbCrLf & "Login:" & emp.Login & vbCrLf & "Senha:" & emp.Senha & vbCrLf & vbCrLf & "Obrigado." & vbCrLf & "XM Sistemas" & vbCrLf
            SendMessage(mail)
            lblMessage.Text = "Já estamos enviando para o e-mail cadastrado a senha dessa conta. Obrigado"
        Else
            lblMessage.Text = "O CNPJ digitado não foi encontrado no nosso banco de dados. Obrigado"
        End If
        pnlMessage.Visible = True
    End Sub

End Class
