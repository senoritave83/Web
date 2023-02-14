
Partial Class Cadastros_export_export
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=" & "export" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"
    End Sub
End Class

