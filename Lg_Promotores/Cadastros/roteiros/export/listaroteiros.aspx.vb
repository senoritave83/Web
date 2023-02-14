
Imports Classes

Namespace Pages.Cadastros.roteiros.export

    Partial Public Class ListaRoteiros
        Inherits XMWebPage

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim cls As New clsPromotor
            grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), CStr("" & Request("cboUF")), CStr("" & Request("cboTeste")), CInt(Request("cboIDLider")), CInt(Request("cboIDRegiao")), CInt(Request("cboIDCoordenador")), Request("SortExpression"), False, 0, 0, CInt(Request("cboIdStatus"))).Data
            grdExportar.DataBind()

            Response.AddHeader("Last-Modified", Now().ToString)
            Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Roteiros_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
            Response.ContentType = "application/vnd.ms-excel"


        End Sub

    End Class

End Namespace