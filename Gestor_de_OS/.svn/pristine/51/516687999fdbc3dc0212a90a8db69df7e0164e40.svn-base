
Partial Class home_OrdemServicoFotos
    Inherits System.Web.UI.Page
    Protected Const VW_IDOS As String = "IDOS"

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState(VW_IDOS) = Request("idos")
        End If
    End Sub

    Protected Sub btnVoltar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnVoltar.Click
        Response.Redirect("ordemservico.aspx?idos=" & ViewState(VW_IDOS))
    End Sub
End Class
