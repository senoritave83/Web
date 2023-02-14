

Imports Classes

Namespace Pages.Cadastros.export

    Partial Public Class Promotores
        Inherits XMWebPage
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			Dim cls As new clsPromotor
            grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), CStr(Request("cboUF")), IIf(Request.QueryString("cboTeste") = -1, -1, 0), CInt(Request("cboIDLider")), CInt(Request("cboIDRegiao")), CInt(Request("cboIDCoordenador")), Request("SortExpression"), False, 0, 0, CInt(Request("cboIdStatus"))).Data
			grdExportar.DataBind()

            Response.AddHeader("Last-Modified", Now().ToString)
			Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Promotores_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
			Response.ContentType = "application/vnd.ms-excel"


		End Sub

	End Class

End Namespace

