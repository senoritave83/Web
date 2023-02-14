Imports Classes


Partial Class formulario_finalizar
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim cls As New clsFormVisita
            ViewState("IDVISITA") = CInt("0" & Request("IDVISITA"))
            cls.Load(ViewState("IDVISITA"))
            If cls.VisitaCompleta = False And cls.Justificada = False Then
                Response.Redirect("justificar.aspx?idvisita=" & ViewState("IDVISITA"))
            End If
            cls.FinalizarVisita()
            lblMensagem.Text = "Visita finalizada com sucesso!"
            btnOk.Visible = True
        End If
    End Sub

    Protected Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
