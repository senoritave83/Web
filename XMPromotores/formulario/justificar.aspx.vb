Imports Classes

Partial Class formulario_justificar
    Inherits XMWebPage

    Protected cls As clsFormVisita


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cls = New clsFormVisita

        If Not Page.IsPostBack Then

            ViewState("IDVISITA") = CInt("0" & Request("IDVISITA"))

            Dim jus As New clsTipoJustificativa
            cboJustificativa.DataSource = jus.Listar()
            cboJustificativa.DataBind()
            jus = Nothing
        End If

        cls.Load(ViewState("IDVISITA"))

        If Not Page.IsPostBack Then
            setComboValue(cboJustificativa, cls.IDTipoJustificativa)
        End If


    End Sub

    Protected Sub btnVoltar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVoltar.Click
        Response.Redirect("visita.aspx?idvisita=" & ViewState("IDVISITA"))
    End Sub

    Protected Sub btnGravar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGravar.Click
        cls.IDTipoJustificativa = cboJustificativa.SelectedValue
        cls.Update()
        Response.Redirect("finalizar.aspx?idvisita=" & ViewState("IDVISITA"))
    End Sub
End Class
