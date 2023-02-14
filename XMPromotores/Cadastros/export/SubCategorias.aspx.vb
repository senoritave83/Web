

Imports Classes

Namespace Pages.Cadastros.export

    Partial Public Class SubCategorias
        Inherits XMWebPage
        
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			Dim cls As new clsSubCategoria
            grdExportar.DataSource = cls.Listar(Request.QueryString("Filtro"), CInt(Request("cboIDCategoria")), Request.QueryString("drpIdStatus"), Request("SortExpression"), False, 0, 0).Data
			grdExportar.DataBind()

			Response.AddHeader("Last-Modified", Now().ToString)
            Response.AddHeader("Content-Disposition", "inline; filename=EXPORTACAO_Categorias_" & Now.ToString("ddMMyyyyhhmmss") & ".xls")
			Response.ContentType = "application/vnd.ms-excel"


		End Sub

	End Class

End Namespace

