
Partial Class pedidos_cancelado
    Inherits XMWebPage



    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Response.Redirect("cliente.aspx?idcliente=" & Request("idcliente"))
    End Sub
End Class
