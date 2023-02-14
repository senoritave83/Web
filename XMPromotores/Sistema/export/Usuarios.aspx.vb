Imports Classes

Partial Class Cadastros_export_Usuarios
    Inherits XMWebPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim cls As New clsUsuario

        grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), Request.QueryString("cboIDCargo"), 0, "", False, 0, 0).Data
        grdExportar.DataBind()

        Response.AddHeader("Last-Modified", Now().ToString)
        Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_TipoLojas_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
        Response.ContentType = "application/vnd.ms-excel"


    End Sub

End Class
