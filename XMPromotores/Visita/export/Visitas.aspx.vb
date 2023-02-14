Imports Classes

Partial Class Visita_export_Visitas
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsVisita
        grdExportar.DataSource = cls.Listar(CStr(Request("txtFiltro")), Request("lstSuperior"), CInt(Request("drpTipoSelecao")), CStr("" & Request("txtDataInicial")), CStr(Request("txtDataFinal")), CInt(Request("cboIDTipoJustificativa")), CInt(Request("cboTeste")), Request("SortExpression"), False, 0, 0).Data
        grdExportar.DataBind()

        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Visitas_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"


    End Sub

End Class
