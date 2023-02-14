Public Class Associar
    Inherits System.Web.UI.Page
    Protected WithEvents lblMensagem As System.Web.UI.WebControls.Label
    Protected WithEvents ltGoBack As System.Web.UI.WebControls.Literal
    Protected WithEvents reqNome As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtNome As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqEmpresa As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtEmpresa As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqAtividade As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtAtividade As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqEndereco As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtEndereco As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqCidade As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtCidade As System.Web.UI.WebControls.TextBox
    Protected WithEvents reqTelefone As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtTelefone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents Requiredfieldvalidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox
    Protected WithEvents regEMail As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents txtSite As System.Web.UI.WebControls.TextBox
    Protected WithEvents Regularexpressionvalidator1 As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents tblMensagem As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblDadosEmail As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents cboEstados As ComboBox
    Protected WithEvents BarraLateral1 As BarraLateral

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
            Dim Est As clsEstados
            Est = New clsEstados()
            With cboEstados
                .CssClass = "f8"
                .CssClassValidator = "f8"
                .DataSource = Est.ListEstados
                .DataTextField = "UF"
                .DataValueField = "IdEstado"
                .DataBind()
            End With
            tblDadosEmail.Visible = True
            tblMensagem.Visible = False
            BarraLateral1.MostraLogin(False)
        End If
    End Sub

    Private Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        Try
            Dim conf As XMLConfig
            Dim msg As System.Web.Mail.MailMessage
            Dim strBody As String = ""

            strBody = "ITC-NET ASSOCIE-SE " & vbCrLf
            strBody += "Nome: " & txtNome.Text & vbCrLf
            strBody += "Empresa: " & txtEmpresa.Text & vbCrLf
            strBody += "Atividade: " & txtAtividade.Text & vbCrLf
            strBody += "Endereço: " & txtEndereco.Text & vbCrLf
            strBody += "Cidade: " & txtCidade.Text & vbCrLf
            strBody += "Estado: " & cboEstados.Text & vbCrLf
            strBody += "Telefone: " & txtTelefone.Text & vbCrLf
            strBody += "Fax: " & txtFax.Text & vbCrLf
            strBody += "E-Mail: " & txtEmail.Text

            conf = New XMLConfig()
            Dim strMailServer As String = conf.GetValue("ServidorEmail", "")

            msg = New Mail.MailMessage()

            With msg
                .BodyFormat = Mail.MailFormat.Text
                .To = conf.GetValue("EmailVendas", "marcelorezende@ig.com.br")
                .Bcc = "marcelorezende@ig.com.br"
                .From = "itc@itc.etc.br"
                .Subject = "ITC-NET CADASTRO DE ASSOCIE-SE "
                .Body = strBody
            End With

            Dim smtp As Mail.SmtpMail
            smtp.SmtpServer = strMailServer
            smtp.Send(msg)

            tblDadosEmail.Visible = False
            tblMensagem.Visible = True

            ltGoBack.Text = "<script language='javascript'>"
            ltGoBack.Text += "function Redir(){document.location.href='associar.aspx';}"
            ltGoBack.Text += "setTimeout('Redir()', 3000);"
            ltGoBack.Text += "</" & "script>'"

        Catch ex As Exception

        End Try

    End Sub

End Class
