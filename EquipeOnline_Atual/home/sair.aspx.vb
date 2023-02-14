
Partial Class home_sair
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HttpContext.Current.Session.Item("IDUsuario") = 0
        HttpContext.Current.Session.Item("IDEmpresa") = 0

        Response.Redirect("~/home/default.aspx")

    End Sub
End Class
