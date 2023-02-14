
Partial Class home_login
    Inherits XMWebPage


    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnOk.Click
        Dim usu As New clsUsuario
        If usu.LoadLogin(txtChave.Text, txtUser.Text, txtPassword.Text) Then
            Identity.IDUsuario = usu.IDUsuario
            ' Identity.IDEmpresa = usu.idempresa
            Identity.Login = usu.Login
            If Request("RedirectTo") <> "" Then
                Response.Redirect(Request("RedirectTo"))
            Else
                Response.Redirect("~/home/default.aspx")
            End If
        Else
            txtPassword.Text = ""
            lblMensagem.Visible = True
            lblMensagem.Text = "Dados de acesso inválidos."
        End If
    End Sub
End Class
