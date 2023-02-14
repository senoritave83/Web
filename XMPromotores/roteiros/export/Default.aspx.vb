Imports Classes

Partial Class roteiros_export_Default
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cls As New clsRoteiro
        grdExportar.DataSource = cls.Export(CStr("" & Request("txtFiltro")), CInt(Request("cboTeste")), CStr(IIf(Request("FiltroSuperior1") Is Nothing, "0,0", Request("FiltroSuperior1"))), CStr("" & Request("cboUF")))
        grdExportar.DataBind()

        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Roteiros_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"


    End Sub

End Class
