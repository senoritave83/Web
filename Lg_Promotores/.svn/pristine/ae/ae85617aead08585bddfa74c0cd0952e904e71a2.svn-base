Imports Classes

Partial Class Cadastros_UsuarioAltSenha
    Inherits XMWebPage
    Dim cls As clsUsuario
    Protected Const VW_IDUSUARIO As String = "IDUsuario"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            ViewState(VW_IDUSUARIO) = CInt("0" & Request("IDUsuario"))

            cls = New clsUsuario
            cls.Load(ViewState(VW_IDUSUARIO))

            lblLogin.Text = cls.login
            lblUsuario.Text = cls.Usuario

        End If

    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click

        cls = New clsUsuario
        cls.Load(ViewState(VW_IDUSUARIO))
        cls.AlterarSenha(txtAlterarSenha.Text, txtValidSenha.Text)
        cls = Nothing

        Response.Redirect("Usuario.aspx?IdUsuario=" & ViewState(VW_IDUSUARIO))

    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click

        Response.Redirect("Usuario.aspx?IdUsuario=" & ViewState(VW_IDUSUARIO))

    End Sub
End Class
