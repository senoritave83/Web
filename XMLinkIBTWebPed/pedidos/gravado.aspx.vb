
Partial Class pedidos_gravado
    Inherits XMWebPage


    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Response.Redirect("cliente.aspx?idcliente=" & Request("idcliente"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblNumeroPedido.Text = Request("numpedido")
        End If
    End Sub
End Class
