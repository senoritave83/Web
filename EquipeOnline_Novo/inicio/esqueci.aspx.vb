
Imports System.Configuration.ConfigurationManager
Imports System.Net.Mail


Partial Class home_esqueci
    Inherits XMWebPage

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim emp As New clsEmpresa
        Dim strSistema As String = "Equipe Online"
        trTrocar.Visible = False
        plhIdentificacao.Visible = False
        plhMensagem.Visible = True
        If emp.Pesquisar(txtBscs.Text) Then

            If emp.IDEmpresa > 0 Then

                Dim strSubject As String = AppSettings("SubjectC")
                strSubject = strSubject.Replace("[Sistema]", strSistema)
                strSubject = strSubject.Replace("[Empresa]", emp.Empresa)
                strSubject = strSubject.Replace("[Nome]", emp.Usuario)

                Dim strMsg As String = AppSettings("TextoEsqueci")
                strMsg = strMsg.Replace("[Sistema]", strSistema)
                strMsg = strMsg.Replace("[Empresa]", emp.Empresa)
                strMsg = strMsg.Replace("[Nome]", emp.Usuario)
                strMsg = strMsg.Replace("[Login]", emp.Login)
                strMsg = strMsg.Replace("[Senha]", emp.Senha)
                strMsg = strMsg.Replace("[Chave]", emp.Chave)

                strMsg = strMsg.Replace("[", "<")
                strMsg = strMsg.Replace("]", ">")

                Dim mail As New MailMessage(AppSettings("FromC"), emp.EMail, strSubject, strMsg)
                mail.IsBodyHtml = True
                Dim blnEnviOk As Boolean = True
                Try
                    SendMessage(mail)
                Catch ex As Exception
                    blnEnviOk = False
                    lblMensagem.Visible = True
                    lblMensagem.Text = "Houve um erro ao tentar enviar para o e-mail cadastrado: " & emp.EMail
                    trTrocar.Visible = True
                End Try

                If blnEnviOk Then

                    lblMensagem.Visible = True
                    lblMensagem.Text = "Os dados de acesso foram enviados para o e-mail " & emp.EMail & "!"
                    trTrocar.Visible = True

                End If

            Else

                lblMensagem.Visible = True
                lblMensagem.Text = "O cadastro não foi localizado!"

            End If
        Else

            lblMensagem.Visible = True
            lblMensagem.Text = "O cadastro não foi localizado!"

        End If
    End Sub
End Class
