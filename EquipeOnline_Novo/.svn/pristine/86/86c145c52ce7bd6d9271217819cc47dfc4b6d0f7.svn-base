
Partial Class header
    Inherits System.Web.UI.MasterPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            plhLogado.Visible = (HttpContext.Current.Session.Item("IDUsuario") <> 0)
            ltrLogado.Text = Session("Login")

        End If
    End Sub
End Class

