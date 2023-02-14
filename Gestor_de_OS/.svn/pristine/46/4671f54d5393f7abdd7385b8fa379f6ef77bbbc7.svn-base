
Partial Class home_mostraerro
    Inherits XMWebPage

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            ViewState("Volta") = Request("Volta")
            lnkError.Visible = False
            lblMessage.Text = Request("Erro")
        End If
    End Sub

    Private Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect(ViewState("Volta"))
    End Sub

End Class
