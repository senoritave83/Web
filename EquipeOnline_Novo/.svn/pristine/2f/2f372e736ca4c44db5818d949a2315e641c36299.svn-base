Imports System.Configuration.ConfigurationManager
Imports System.Net.Mail



Partial Class inicio_registro
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ViewState("Codigo") = Request("cd")
        End If
        txtTelefone.Attributes.Add("onKeyPress", "fncPermitirNumeros()")
        txtUsuario.Attributes.Add("onKeyPress", "fncPermitirUS()")
        txtSenha.Attributes.Add("onKeyPress", "fncPermitirUS()")
        txtSenha2.Attributes.Add("onKeyPress", "fncPermitirUS()")

        txtUsuario.Attributes.Add("onpaste", "return false;")
        txtSenha.Attributes.Add("onpaste", "return false;")
        txtSenha2.Attributes.Add("onpaste", "return false;")
        txtEmail.Attributes.Add("onpaste", "return false;")
        txtEmail2.Attributes.Add("onpaste", "return false;")

        txtUsuario.Attributes.Add("onselectstart", "return false;")
        txtSenha.Attributes.Add("onselectstart", "return false;")
        txtSenha2.Attributes.Add("onselectstart", "return false;")
        txtEmail.Attributes.Add("onselectstart", "return false;")
        txtEmail2.Attributes.Add("onselectstart", "return false;")

    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim oEmpresa As New clsEmpresa()
        Dim strErro As String = ""
        Dim strSistema As String = "Equipe Online"

        Dim strChave As String = oEmpresa.GenerateKey()

        With oEmpresa
            .Chave = strChave
            .Empresa = txtEmpresa.Text
            .EMail = txtEmail.Text
            .Usuario = txtNome.Text
            .Login = txtUsuario.Text
            .Senha = txtSenha.Text
            .Telefone = txtTelefone.Text
            .Codigo = ViewState("Codigo")
            .Motivo = ""
            .Update()

        End With

        If oEmpresa.IDEmpresa > 0 Then

            oEmpresa.InserirEnvioEmail()

            If oEmpresa.Telefone <> "" Then

                oEmpresa.InserirEnvioSms()
            End If

            '***************\FORMA ANTIGA DE ENVIO/***********************
            'Dim strSubject As String = AppSettings("SubjectC")
            'strSubject = strSubject.Replace("[Sistema]", strSistema)
            'strSubject = strSubject.Replace("[Empresa]", txtEmpresa.Text)
            'strSubject = strSubject.Replace("[Nome]", txtNome.Text)

            'Dim strMsg As String = AppSettings("Texto")
            'strMsg = strMsg.Replace("[Sistema]", strSistema)
            'strMsg = strMsg.Replace("[Empresa]", txtEmpresa.Text)
            'strMsg = strMsg.Replace("[Nome]", txtNome.Text)
            'strMsg = strMsg.Replace("[Login]", txtUsuario.Text)
            'strMsg = strMsg.Replace("[Senha]", txtSenha.Text)
            'strMsg = strMsg.Replace("[Chave]", strChave)

            'If Not AppSettings("TextoEspecial") Is Nothing Then
            '    strMsg = strMsg.Replace("[TextoEspecial]", AppSettings("TextoEspecial"))
            'Else
            '    strMsg = strMsg.Replace("[TextoEspecial]", "")
            'End If

            'strMsg = strMsg.Replace("[", "<")
            'strMsg = strMsg.Replace("]", ">")

            'Dim mail As New MailMessage(AppSettings("FromC"), txtEmail.Text, strSubject, strMsg)
            'mail.IsBodyHtml = True
            'SendMessage(mail)

            'Dim strSMS As String = AppSettings("TextoSMS")
            'strSMS = strSMS.Replace("[Sistema]", strSistema)
            'strSMS = strSMS.Replace("[Empresa]", txtEmpresa.Text)
            'strSMS = strSMS.Replace("[Nome]", txtNome.Text)
            'strSMS = strSMS.Replace("[Login]", txtUsuario.Text)
            'strSMS = strSMS.Replace("[Senha]", txtSenha.Text)
            'strSMS = strSMS.Replace("[Chave]", strChave)


            'If Not AppSettings("SMSTextoEspecial") Is Nothing Then
            '    strSMS = strSMS.Replace("[TextoEspecial]", AppSettings("TextoEspecial"))
            'Else
            '    strSMS = strSMS.Replace("[TextoEspecial]", "")
            'End If


            'If txtTelefone.Text.Length = 10 Then
            '    SendSMS("55" & txtTelefone.Text, strSMS)
            'End If

            Response.Redirect("finaliza.aspx")
        Else
            lblMsg.Visible = True
            lblMsg.Text = strErro
        End If

    End Sub



End Class
