
Partial Class Relatorios_Relatorios
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtDataInicial.Text = Now.AddDays(-2).ToString("dd/MM/yyyy")
            txtDataFinal.Text = Now.ToString("dd/MM/yyyy")
        End If
    End Sub

    Protected Sub btnExibir_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExibir.ServerClick
        Dim strScript As String = "fncExibir()" ' document.getElementById('" & frmRelatorio.ClientID & "').location.href='" & cboRelatorio.SelectedValue & "_det.aspx?di=" & txtDataInicial.Text & "&df=" & txtDataFinal.Text & "'"
        ScriptManager1.RegisterClientScriptBlock(Me, Me.GetType(), "frame", strScript, True)

        '        frmRelatorio.Attributes.Add("url", cboRelatorio.SelectedValue & "_det.aspx?di=" & txtDataInicial.Text & "&df=" & txtDataFinal.Text)
        '       frmRelatorio.Visible = True
    End Sub

End Class
